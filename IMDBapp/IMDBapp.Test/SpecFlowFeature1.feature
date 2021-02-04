Feature: IMDB app features
	IMDB app for perfomring a set of operations on a db containing movies, actors and producers data.

@add-movie-to-list
Scenario: Add movie to list
	Given movie name is "Ford vs Ferrari"
	And year is "2019"
	And plot is "American Car Movie"
	And actor list is "1 2"
	And producer list is "1"
	When movie is added
	Then movie list should be-
	| Name            | Year         | Plot         |
	| Ford vs Ferrari | 2019   | American Car Movie |
	Then actor list should be-
	| Name           | DOB        |
	| Matt Damon     | 01/01/1980 |
	| Christian Bale | 01/01/1975 |
	Then producer list should be-
	| Name          |  DOB        |
	| James Mangold | 01/01/1985  |

@list-movies
Scenario: List all movies
	When all movies are fetched
	Then movie list should be-
	| Name             | Year         | Plot            |
	| Ford vs Ferrari  | 2019   | American Car Movie    |
	| Avengers         | 2019   | American Sci-Fi Movie |

	Then producer list should show-
	| Producer          | DOB        | Movie       |
	| James Mangold | 01/01/1985 | Ford vs Ferrari |
	| Kevin Feigi   | 01/01/1985 | Avengers        |
	
	Then actor list should show-
	| Actor          | DOB        | Movie            |
	| Matt Damon     | 01/01/1980 | Ford vs Ferrari  |
	| Christian Bale | 01/01/1975 | Ford vs Ferrari  |
	| RDJ            | 01/01/1980 | Avengers         |
	| Chris Evans    | 01/01/1975 | Avengers         |

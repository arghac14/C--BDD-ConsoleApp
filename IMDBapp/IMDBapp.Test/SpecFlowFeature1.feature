Feature: IMDB app features
	IMDB app for perfomring a set of operations on a db containing movies, actors and producers data.

@add-movie-to-list
Scenario: Add movie to list
	Given movie name is "Ford vs Ferrari"
	And year is "01/01/2019"
	And plot is "American Car Movie"
	And actor list is "1 2"
	And producer list is "1"
	When movie is added
	Then movie list should be-
	| Name            | Year         | Plot               |
	| Ford vs Ferrari | 01/01/2019   | American Car Movie |
	Then actor list should be-
	| ActorName      | ActorDOB   |
	| Matt Damon     | 01/01/1980 |
	| Christian Bale | 01/01/1975 |
	Then producer list should be-
	| ProducerName  | ProducerDOB |
	| James Mangold | 01/01/1985  |

@list-movies
Scenario: List all movies
	When all movies are fetched
	Then movie list should be-
	| Name            | Year         | Plot               |
	| Ford vs Ferrari | 01/01/2019   | American Car Movie |
	Then actor list should be-
	| ActorName      | ActorDOB   |
	| Matt Damon     | 01/01/1980 |
	| Christian Bale | 01/01/1975 |
	Then producer list should be-
	| ProducerName  | ProducerDOB |
	| James Mangold | 01/01/1985  |




#-----If taking actors and producers directly without index

#@add-movie-to-list
#Scenario: Add movie to list
#	Given movie name is "Ford vs Ferrari"
#	And year is "01/01/2019"
#	And plot is "American Car Movie"
#	And actor list is-
#	| ActorName      | ActorDOB   |
#	| Matt Damon     | 01/01/1980 |
#	| Christian Bale | 01/01/1975 |
#	And producer list is-
#	| ProducerName  | ProducerDOB |
#	| James Mangold | 01/01/1985  |
#	When movie is added
#	Then movie list should be-
#	| Name            | Year         | Plot               |
#	| Ford vs Ferrari | 01/01/2019   | American Car Movie |
#	Then actor list should be-
#	| ActorName      | ActorDOB   |
#	| Matt Damon     | 01/01/1980 |
#	| Christian Bale | 01/01/1975 |
#	Then producer list should be-
#	| ProducerName  | ProducerDOB |
#	| James Mangold | 01/01/1985  |

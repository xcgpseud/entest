## A few notes

1. With more time I would include integration tests and test the API with payloads and responses to get some broader test coverage.
2. I went with Sqlite just to make it super quick and easy with no additional DB config.
3. The stages of validating the data are a little bit all over the place. With more time I'd create a more modular service for validation in general.
4. I would like to add some unit tests with mocks so that I can test a bit more of the functionality in the way it is currently written. However I think #1 and #3 would be the better moves. I think Unit Tests should be super small and basic. I could adapt my code a bit to achieve a few more Unit Tests and provide Integration Test coverage also which would be the ideal solution. (Given more time)

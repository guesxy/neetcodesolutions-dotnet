package main

import "fmt"

// containsDuplicate checks if the given slice of integers contains any duplicates.
func containsDuplicate(nums []int) bool {
	seen := make(map[int]struct{})

	// Iterate through the slice
	for _, num := range nums {
		// Check if the number is already in the map
		if _, exists := seen[num]; exists {
			return true
		}

		// Mark the number as seen
		seen[num] = struct{}{}
	}

	// No duplicates found
	return false
}

func main() {
	fmt.Println("Start the program")
	fmt.Println(containsDuplicate([]int{1, 2, 3, 1})) // true
	fmt.Println(containsDuplicate([]int{1, 2, 3, 4})) // false
}
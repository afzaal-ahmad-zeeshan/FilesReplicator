# Parser

The application is capable of a very mediocre parsing. The parser can be used
to specify what the data corresponds to. 

## Structure

``` text
+ First directory
  - 
```

## Special characters

The following characters are special and thus have a special meaning in the structure.

* `~` - sets the parent directory.
* `+` - means a directory.
* `-` - means a file.
* `*` - means a directory without the resources.

> More items and structures to be added as the library grows.

## Tips

The parser is intended to be simple, yet enable a structure to be written in a
plain-text.

* Parser trims each line before reading it, so indentation can be used for better readability.
* Use the `\` character at the end of each line to break a line into multiple lines.
* The characters are special only when they appear first in line.

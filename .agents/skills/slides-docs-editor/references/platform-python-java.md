# Python via Java

- Prefer Python's standard file I/O (`pathlib.Path` or `open`) for reading and writing files.
  Pass a string path directly when the API supports it. Use Java types or I/O classes only when
  required by the called API or when the example specifically demonstrates Java streams or BLOB
  handling. Convert Python data to the required Java type at the API boundary and validate the
  interoperation with the existing Python via Java snippet checker.
- Link API mentions to classes and their members in the Python via Java API Reference
  (`https://reference.aspose.com/slides/python-java/aspose.slides/`). Do not link to interfaces
  or their members, and do not substitute Java API Reference links.
- Use the corresponding class names in prose and link labels, such as `Shape`, `TextFrameFormat`,
  and `ThreeDFormat`. Verify member anchors on the class pages.

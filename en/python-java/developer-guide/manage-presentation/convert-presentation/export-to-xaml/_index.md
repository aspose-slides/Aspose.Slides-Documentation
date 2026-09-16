---
title: Export Presentations to XAML in Python via Java
linktitle: Presentation to XAML
type: docs
weight: 30
url: /python-java/export-to-xaml/
keywords:
- export PowerPoint
- export OpenDocument
- export presentation
- convert PowerPoint
- convert OpenDocument
- convert presentation
- PowerPoint to XAML
- OpenDocument to XAML
- presentation to XAML
- PPT to XAML
- PPTX to XAML
- ODP to XAML
- save PPT as XAML
- save PPTX as XAML
- save ODP as XAML
- export PPT to XAML
- export PPTX to XAML
- export ODP to XAML
- Python
- Java
- Aspose.Slides
description: "Export PowerPoint and OpenDocument presentations to XAML with Aspose.Slides for Python via Java. Use default options or include hidden slides."
---

## **Overview**

This article explains how to export PowerPoint presentations to XAML using Aspose.Slides for Python via Java. It includes a brief introduction to XAML, shows how to save a presentation to XAML with default settings, and demonstrates how to customize the export through [XamlOptions](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/), including exporting hidden slides. The article also answers a few common questions related to fallback fonts, XAML stack compatibility, and hidden slide export behavior.

The examples require Aspose.Slides for Python via Java and a compatible Java runtime. Place `pres.pptx` in the current working directory. Each example starts the JVM only if it is not already running.

## **About XAML**

XAML is an XML-based markup language used to describe user interfaces in frameworks such as WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), and Xamarin.Forms.

You can work with XAML files in a visual designer or write and edit the markup directly.

## **Export Presentations to XAML With Default Options**

The following Python example shows how to export a presentation to XAML with default settings:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

By default, the exported slides are saved in a `pres` subfolder of the process's current working directory. The folder is created automatically, and any required images are saved there as well.

The output folder name is taken from the source file name without its extension. For `pres.pptx`, the output files are named `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, and so on. Even if you pass an absolute path to the input presentation, the output folder is created relative to the current working directory, rather than alongside the input file.

## **Export Presentations to XAML With Custom Options**

Use the [XamlOptions](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/) class to control how Aspose.Slides exports a presentation to XAML.

To save the output to a custom location, implement `IXamlOutputSaver` and pass an instance of your implementation to the [setOutputSaver](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/#setOutputSaver) method of [XamlOptions](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/).

To include hidden slides in the XAML output, call [setExportHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) with `True`, as shown in the following Python example:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Capture All Generated XAML Artifacts**

A XAML export can produce a XAML document for each exported slide plus separate images and supporting resources. Assign a custom `IXamlOutputSaver` to [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/#setOutputSaver) to receive these artifacts instead of using the default file-system saver. Start the export with the XAML-specific [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) overload that accepts XAML options.

In Python, use `jpype.JProxy` to implement the Java `IXamlOutputSaver` interface. Convert the callback path to `str` and copy the Java byte array to Python `bytes` before returning, as demonstrated below.

### **Understand the Callback Lifecycle**

The exporter calls `IXamlOutputSaver.save` separately for each generated artifact:

- `path` identifies the artifact and may include relative directories. Retain this information because XAML may reference resources using relative paths.
- `data` contains the artifact's bytes. Images and other binary resources must not be decoded as text.
- The saver is responsible for retaining or persisting the data before returning. The examples copy each byte array into application-owned memory.
- Treat export as successful only when the presentation save operation returns and every callback has completed successfully. Do not swallow storage errors or start unobserved background writes. If persistence happens afterward, report overall success only after that step also succeeds.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) also applies to a custom saver. The default setting, `False`, excludes hidden-slide XAML documents. Passing `True` includes them and any resources required for their export. Resource counts depend on the presentation; do not assume one callback per slide or a fixed callback order.

### **Export to Memory and Inspect the Artifacts**

This complete example loads `pres.pptx`, collects every artifact in a Python dictionary of names and immutable `bytes` values, and prints its name, type, and byte count. It preserves the supplied names exactly. Duplicate names mark the collection as invalid instead of silently overwriting an artifact. The example checks this before using the results.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Decode only XAML, and only when textual inspection is needed.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Extension checks are useful for inspection; retain all artifacts, including unfamiliar resource types. Leave the bytes unchanged when storing or transmitting them. Use `bytes.decode` with UTF-8 only for XAML that needs textual processing.

### **Package Collected Artifacts in a ZIP Archive**

This independent example collects the export, validates its names, and writes the original bytes into a ZIP archive. A unique archive name separates concurrent export jobs. ZIP entries use forward slashes and retain relative directories. Unsafe names or names that collide after normalization reject the entire package before it is written.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # Closing finalizes the ZIP directory before success is reported.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

The example uses Python’s `zipfile.ZipFile` to write one local archive; the exporter itself does not write loose XAML or image files. For remote storage, replace the archive-writing stage with uploads of the collected byte arrays. Use an export-job identifier plus the full relative artifact name as a blob key, or store the job identifier, relative name, and binary data in a database row. Publish the job only after all uploads complete or the database transaction commits. Clean up partial output if persistence fails.

For large presentations, a custom saver can persist each artifact directly to application storage to avoid keeping an additional copy of the entire export in application memory. Keep each callback synchronous from the exporter's perspective: return only after the destination has accepted the bytes, and allow failures to reach the caller.

### **Preserve Resource Names and Verify References**

- Normalize path separators when the destination requires it, but preserve relative directories. Do not use only `pathlib.Path.name` unless every generated name is known to be unique and resource references remain valid.
- Apply destination-specific name validation. When writing loose files, reject rooted paths and traversal segments, resolve the destination with `pathlib.Path.resolve`, and verify it stays beneath the intended export directory, including the directory separator in the containment check. Use an application-controlled directory without symbolic links that could redirect writes.
- Use a separate saver and storage namespace for each export job. Detect collisions after separator normalization and according to the destination's case-sensitivity rules.
- Before publishing, parse each XAML document as XML and inspect its file-based resource references, such as image `Source` or `ImageSource` attributes. Resolve each relative URI against the containing XAML artifact's directory, normalize the resulting storage name, and confirm that the corresponding map key, ZIP entry, or stored object exists. Treat external URIs and XAML markup expressions separately from relative file names.

For example, if `pres/Slide_1.xaml` references `images/image1.png`, the stored resource must be available as `pres/images/image1.png`. Keeping just `image1.png` would break that relationship. For object storage, preserve the same layout beneath the job prefix and make those resource URLs accessible to the XAML consumer. Reopen the completed ZIP to verify entry names and resource bytes, and load representative slides in the target XAML environment to confirm that images resolve correctly.

## **FAQ**

**How can I ensure predictable fonts if the original font is not available on the machine?**

Call [setDefaultRegularFont](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/) — it is used as a fallback font during export when the original is missing. This does not guarantee that the generated XAML references the fallback font or that the font is available on the target machine. Ensure that the fonts referenced by the XAML are available in the environment where it is displayed.

**Is the exported XAML intended only for WPF, or can it be used in other XAML stacks as well?**

Aspose.Slides exports WPF XAML through its public API. Compatibility with other XAML stacks, such as UWP and Xamarin.Forms, is not guaranteed. Test the generated markup in your target environment.

**Are hidden slides supported, and how can I prevent them from being exported by default?**

By default, hidden slides are not included. You can control this behavior via [setExportHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/python-java/aspose.slides/xamloptions/) — keep it disabled if you do not need to export them.

---
title: Export Presentations to XAML with Python
linktitle: Presentation to XAML
type: docs
weight: 30
url: /python-net/export-to-xaml/
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
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument slides to XAML with Python using Aspose.Slides—quick, Office-free solution that keeps your layout intact."
---

## **Overview**

This article explains how to export PowerPoint presentations to XAML using Aspose.Slides. It includes a brief introduction to XAML, shows how to save a presentation to XAML with default settings, and demonstrates how to customize the export through [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/), including exporting hidden slides. The article also answers a few common questions related to fallback fonts, XAML stack compatibility, and hidden slide export behavior.

## **About XAML**

XAML is an XML-based markup language used to describe user interfaces in frameworks such as WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), and Xamarin.Forms.

You can work with XAML files in a visual designer or write and edit the markup directly.

## **Export Presentations to XAML With Default Options**

The following Python example shows how to export a presentation to XAML with default settings:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

By default, the exported slides are saved in a `pres` subfolder of the process's current working directory, as returned by [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). The folder is created automatically, and any required images are saved there as well.

The output folder name is taken from the source file name without its extension. For `pres.pptx`, the output files are named `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, and so on. Even if you pass an absolute path to the input presentation, the output folder is created relative to the current working directory, rather than alongside the input file.

## **Export Presentations to XAML With Custom Options**

Use the [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) class to control how Aspose.Slides exports a presentation to XAML.

To include hidden slides in the XAML output, set the [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) property to `True`, as shown in the following Python example:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Capture All Generated XAML Artifacts**

A XAML export can produce a XAML document for each exported slide plus separate images and supporting resources. Retain all these files when storing or transmitting an export.

The examples below use the default file-system saver in a temporary directory, then collect the generated files.

### **Understand the Export Lifecycle**

- Start the export with the XAML-specific [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) overload that accepts XAML options. Read the generated files only after it returns successfully.
- Preserve each artifact's relative path because XAML may reference resources using relative paths.
- Read artifacts as bytes. Images and other binary resources must not be decoded as text.
- Report overall success only after collection and any subsequent storage operation complete. Let storage errors reach the caller, and clean up partial output if persistence fails.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) defaults to `False`, which excludes hidden-slide XAML documents. Setting it to `True` includes them and any resources required for their export. Resource counts depend on the presentation; do not assume one file per slide.

{{% alert color="warning" title="Warning" %}}
The examples temporarily change the process's current working directory, which affects all threads. Run each export in a dedicated worker process, or ensure that no other work in the process depends on the current directory during export. A unique temporary directory alone does not make concurrent exports in the same process safe.
{{% /alert %}}

### **Export to Memory and Inspect the Artifacts**

This complete example loads `pres.pptx`, exports it to a temporary directory, collects every artifact in a dictionary of relative names and bytes, and prints its name, type, and byte count. It preserves the generated directory structure and removes the temporary files after collection. The input path is resolved before changing the working directory.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Decode only XAML, and only when textual inspection is needed.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Extension checks are useful for inspection; retain all artifacts, including unfamiliar resource types. Leave the bytes unchanged when storing or transmitting them. Decode only XAML that needs textual processing. This approach uses temporary disk space as well as memory for the collected export.

### **Package Collected Artifacts in a ZIP Archive**

This independent example collects the export, validates its names, and writes the original bytes into a ZIP archive. A unique archive name separates export jobs. ZIP entries use forward slashes and retain relative directories. Unsafe names or names that collide after normalization reject the entire package before it is written.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # The ZIP directory has been finalized before reporting success.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

The example uses [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) to write one local archive after collecting the temporary export. For remote storage, replace the archive-writing stage with uploads of the collected bytes. Use an export-job identifier plus the full relative artifact name as an object key, or store the job identifier, relative name, and binary data in a database row. Publish the job only after all uploads complete or the database transaction commits. Clean up partial output if persistence fails.

For large presentations, process the temporary files one at a time after export instead of collecting all their bytes in a dictionary. This avoids an additional in-memory copy of the entire export, but does not eliminate the exporter's own memory requirements.

### **Preserve Resource Names and Verify References**

- Normalize path separators when the destination requires it, but preserve relative directories. Do not keep only the final file name unless every generated name is known to be unique and resource references remain valid.
- Apply destination-specific name validation. When writing loose files, reject absolute paths and traversal segments, resolve the destination, and verify that it stays beneath the intended export directory. Use an application-controlled directory without symbolic links that could redirect writes.
- Use a separate storage namespace for each export job. Detect collisions after separator normalization and according to the destination's case-sensitivity rules.
- Before publishing, parse each XAML document as XML and inspect its file-based resource references, such as image `Source` or `ImageSource` attributes. Resolve each relative URI against the containing XAML artifact's directory, normalize the resulting storage name, and confirm that the corresponding dictionary key, ZIP entry, or stored object exists. Treat external URIs and XAML markup expressions separately from relative file names.

For example, if `pres/Slide_1.xaml` references `images/image1.png`, the stored resource must be available as `pres/images/image1.png`. Keeping just `image1.png` would break that relationship. For object storage, preserve the same layout beneath the job prefix and make those resource URLs accessible to the XAML consumer. Reopen the completed ZIP to verify entry names and resource bytes, and load representative slides in the target XAML environment to confirm that images resolve correctly.

## **FAQ**

**How can I ensure predictable fonts if the original font is not available on the machine?**

Set [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) in [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — it is used as a fallback font during export when the original is missing. This does not guarantee that the generated XAML references the fallback font or that the font is available on the target machine. Ensure that the fonts referenced by the XAML are available in the environment where it is displayed.

**Is the exported XAML intended only for WPF, or can it be used in other XAML stacks as well?**

Aspose.Slides exports WPF XAML through its public API. Compatibility with other XAML stacks, such as UWP and Xamarin.Forms, is not guaranteed. Test the generated markup in your target environment.

**Are hidden slides supported, and how can I prevent them from being exported by default?**

By default, hidden slides are not included. You can control this behavior via [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) in [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — keep it disabled if you do not need to export them.

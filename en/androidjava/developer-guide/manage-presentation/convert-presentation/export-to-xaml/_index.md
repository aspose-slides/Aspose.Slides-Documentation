---
title: Export Presentations to XAML on Android
linktitle: Presentation to XAML
type: docs
weight: 30
url: /androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument slides to XAML in Java using Aspose.Slides for Android—quick, Office-free solution that keeps your layout intact."
---

## **Overview**

This article explains how to export PowerPoint presentations to XAML using Aspose.Slides for Android via Java. It includes a brief introduction to XAML, shows how to save a presentation to XAML with default settings, and demonstrates how to customize the export through [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/), including exporting hidden slides. The article also answers a few common questions related to fallback fonts, XAML stack compatibility, and hidden slide export behavior.

## **About XAML**

XAML is an XML-based markup language used to describe user interfaces in frameworks such as WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), and Xamarin.Forms.

You can work with XAML files in a visual designer or write and edit the markup directly.

## **Export Presentations to XAML With Default Options**

The following Java example shows how to export a presentation to XAML with default settings:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

By default, the exported slides are saved in a `pres` subfolder of the process's current working directory. The folder is created automatically, and any required images are saved there as well.

The output folder name is taken from the source file name without its extension. For `pres.pptx`, the output files are named `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, and so on. Even if you pass an absolute path to the input presentation, the output folder is created relative to the current working directory, rather than alongside the input file.

On Android, use an input file accessible to your app. The current working directory may not be writable; use a custom output saver to retain the export in memory or write it to app storage, as shown below. The generated WPF XAML is intended for a compatible consumer and is not an Android layout resource.

## **Export Presentations to XAML With Custom Options**

Use the [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ixamloptions/) interface to control how Aspose.Slides exports a presentation to XAML.

To save the output to a custom location, implement [IXamlOutputSaver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ixamloutputsaver/) and pass an instance of your implementation to the [setOutputSaver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) method of [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/).

To include hidden slides in the XAML output, call [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) with `true`, as shown in the following Java example:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Capture All Generated XAML Artifacts**

A XAML export can produce a XAML document for each exported slide plus separate images and supporting resources. Assign a custom [IXamlOutputSaver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ixamloutputsaver/) to [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) to receive these artifacts instead of using the default file-system saver. Start the export with the XAML-specific [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) overload that accepts XAML options.

### **Understand the Callback Lifecycle**

The exporter calls [IXamlOutputSaver.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separately for each generated artifact:

- `path` identifies the artifact and may include relative directories. Retain this information because XAML may reference resources using relative paths.
- `data` contains the artifact's bytes. Images and other binary resources must not be decoded as text.
- The saver is responsible for retaining or persisting the data before returning. The examples copy each byte array into application-owned memory.
- Treat export as successful only when the presentation save operation returns and every callback has completed successfully. Do not swallow storage errors or start unobserved background writes. If persistence happens afterward, report overall success only after that step also succeeds.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) also applies to a custom saver. The default setting, `false`, excludes hidden-slide XAML documents. Passing `true` includes them and any resources required for their export. Resource counts depend on the presentation; do not assume one callback per slide or a fixed callback order.

### **Export to Memory and Inspect the Artifacts**

This complete example loads `pres.pptx`, collects every artifact in a [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html), and prints its name, type, and byte count. It preserves the supplied names exactly. Duplicate names mark the collection as invalid instead of silently overwriting an artifact. The example checks this before using the results.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Decode only XAML, and only when textual inspection is needed.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Extension checks are useful for inspection; retain all artifacts, including unfamiliar resource types. Leave the bytes unchanged when storing or transmitting them. Use the [String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) with UTF-8 only for XAML that needs textual processing.

### **Package Collected Artifacts in a ZIP Archive**

This independent example collects the export, validates its names, and writes the original bytes into a ZIP archive. Replace `/path/to/app/files` with the path returned by your Android context's [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) method. A unique archive name separates concurrent export jobs. ZIP entries use forward slashes and retain relative directories. Unsafe names or names that collide after normalization reject the entire package before it is written.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // The ZIP directory has been finalized by closing before reporting success.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

The example uses [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) to write one local archive; the exporter itself does not write loose XAML or image files. For remote storage, replace the archive-writing stage with uploads of the collected byte arrays. Use an export-job identifier plus the full relative artifact name as a blob key, or store the job identifier, relative name, and binary data in a database row. Publish the job only after all uploads complete or the database transaction commits. Clean up partial output if persistence fails.

For large presentations, a custom saver can persist each artifact directly to application storage to avoid keeping an additional copy of the entire export in application memory. Keep each callback synchronous from the exporter's perspective: return only after the destination has accepted the bytes, and allow failures to reach the caller.

### **Preserve Resource Names and Verify References**

- Normalize path separators when the destination requires it, but preserve relative directories. Do not use only [File.getName](https://developer.android.com/reference/java/io/File#getName()) unless every generated name is known to be unique and resource references remain valid.
- Apply destination-specific name validation. When writing loose files, reject rooted paths and traversal segments, resolve the destination with [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()), and verify it stays beneath the intended export directory, including the directory separator in the containment check. Use an application-controlled directory without symbolic links that could redirect writes.
- Use a separate saver and storage namespace for each export job. Detect collisions after separator normalization and according to the destination's case-sensitivity rules.
- Before publishing, parse each XAML document as XML and inspect its file-based resource references, such as image `Source` or `ImageSource` attributes. Resolve each relative URI against the containing XAML artifact's directory, normalize the resulting storage name, and confirm that the corresponding map key, ZIP entry, or stored object exists. Treat external URIs and XAML markup expressions separately from relative file names.

For example, if `pres/Slide_1.xaml` references `images/image1.png`, the stored resource must be available as `pres/images/image1.png`. Keeping just `image1.png` would break that relationship. For object storage, preserve the same layout beneath the job prefix and make those resource URLs accessible to the XAML consumer. Reopen the completed ZIP to verify entry names and resource bytes, and load representative slides in the target XAML environment to confirm that images resolve correctly.

## **FAQ**

**How can I ensure predictable fonts if the original font is not available on the machine?**

Call [setDefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — it is used as a fallback font during export when the original is missing. This does not guarantee that the generated XAML references the fallback font or that the font is available on the target machine. Ensure that the fonts referenced by the XAML are available in the environment where it is displayed.

**Is the exported XAML intended only for WPF, or can it be used in other XAML stacks as well?**

Aspose.Slides exports WPF XAML through its public API. Compatibility with other XAML stacks, such as UWP and Xamarin.Forms, is not guaranteed. Test the generated markup in your target environment.

**Are hidden slides supported, and how can I prevent them from being exported by default?**

By default, hidden slides are not included. You can control this behavior via [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — keep it disabled if you do not need to export them.

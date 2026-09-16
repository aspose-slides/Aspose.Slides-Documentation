---
title: 在 Android 上将演示文稿导出为 XAML
linktitle: 演示文稿转 XAML
type: docs
weight: 30
url: /zh/androidjava/export-to-xaml/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出演示文稿
- 转换 PowerPoint
- 转换 OpenDocument
- 转换演示文稿
- PowerPoint 转 XAML
- OpenDocument 转 XAML
- 演示文稿转 XAML
- PPT 转 XAML
- PPTX 转 XAML
- ODP 转 XAML
- 将 PPT 保存为 XAML
- 将 PPTX 保存为 XAML
- 将 ODP 保存为 XAML
- 导出 PPT 为 XAML
- 导出 PPTX 为 XAML
- 导出 ODP 为 XAML
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML——快速、无需 Office 的解决方案，保持布局完整。"
---
## **概述**

本文说明如何使用 Aspose.Slides for Android via Java 将 PowerPoint 演示文稿导出为 XAML。内容包括对 XAML 的简要介绍，展示如何使用默认设置将演示文稿保存为 XAML，以及如何通过 [XamlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/xamloptions/) 自定义导出，包括导出隐藏幻灯片。本文还回答了有关回退字体、XAML 堆栈兼容性以及隐藏幻灯片导出行为的常见问题。

## **关于 XAML**

XAML 是一种基于 XML 的标记语言，用于在诸如 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin.Forms 等框架中描述用户界面。

您可以在可视化设计器中使用 XAML 文件，也可以直接编写和编辑标记。

## **使用默认选项将演示文稿导出为 XAML**

以下 Java 示例演示如何使用默认设置将演示文稿导出为 XAML：

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

默认情况下，导出的幻灯片会保存在进程当前工作目录的 `pres` 子文件夹中。该文件夹会自动创建，所需的图像也会保存在该文件夹中。

输出文件夹的名称取自源文件名（不含扩展名）。例如对于 `pres.pptx`，输出文件命名为 `pres/Slide_1.xaml`、`pres/Slide_2.xaml` 等。即使您传入了演示文稿的绝对路径，输出文件夹也会相对于当前工作目录创建，而不是与输入文件并列。

在 Android 上，请使用应用可访问的输入文件。当前工作目录可能不可写；请使用自定义输出保存器将导出保存在内存中或写入应用存储，如下所示。生成的 WPF XAML 旨在供兼容的消费者使用，并不是 Android 布局资源。

## **使用自定义选项将演示文稿导出为 XAML**

使用 [IXamlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ixamloptions/) 接口可控制 Aspose.Slides 将演示文稿导出为 XAML 的方式。

要将输出保存到自定义位置，请实现 [IXamlOutputSaver](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ixamloutputsaver/) 并将实现实例传递给 [XamlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/xamloptions/) 的 [setOutputSaver](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) 方法。

要在 XAML 输出中包含隐藏幻灯片，请使用 `true` 调用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-)，示例代码如下：

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

## **捕获所有生成的 XAML 产物**

XAML 导出可以为每个导出的幻灯片生成一个 XAML 文档，并附带单独的图像和支持资源。将自定义 [IXamlOutputSaver](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ixamloutputsaver/) 赋给 [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) 可接收这些产物，而不是使用默认的文件系统保存器。使用接受 XAML 选项的 XAML‑specific [Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 重载启动导出。

### **了解回调生命周期**

导出器会为每个生成的产物单独调用 [IXamlOutputSaver.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-)：

- `path` 标识产物，可包括相对目录。请保留此信息，因为 XAML 可能使用相对路径引用资源。
- `data` 包含产物的字节。图像和其他二进制资源不得解码为文本。
- 保存器需在返回前保留或持久化数据。示例将每个字节数组复制到应用拥有的内存中。
- 仅当演示文稿保存操作返回且所有回调均成功完成时，才视为导出成功。不要吞掉存储错误或启动未观察的后台写入。如果持久化在之后进行，仅在该步骤也成功后才报告整体成功。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) 同样适用于自定义保存器。默认设置 `false` 会排除隐藏幻灯片的 XAML 文档。传入 `true` 则会包括它们以及导出所需的所有资源。资源数量取决于演示文稿，不能假设每张幻灯片对应一个回调或回调顺序固定。

### **导出到内存并检查产物**

此完整示例加载 `pres.pptx`，将每个产物收集到一个 [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html)，并打印其名称、类型和字节数。它严格保留提供的名称。重复名称会标记集合为无效，而不会悄然覆盖产物。示例在使用结果前会进行此检查。

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

    // 仅在需要文本检查时才解码 XAML。
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

扩展名检查对检查有帮助；请保留所有产物，包括不熟悉的资源类型。存储或传输时保持字节不变。仅在需要文本处理的 XAML 场景下，使用带 UTF-8 的 [String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-)。

### **将收集的产物打包为 ZIP 存档**

此独立示例收集导出结果，验证名称，并将原始字节写入 ZIP 存档。将 `/path/to/app/files` 替换为 Android 上下文的 [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) 方法返回的路径。唯一的存档名称用于区分并发导出作业。ZIP 条目使用正斜杠并保留相对目录。对不安全的名称或规范化后冲突的名称在写入前会拒绝整个包。

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

        // ZIP 目录已在关闭后完成，在报告成功之前已完成。
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

示例使用 [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) 写入本地存档；导出器本身不会写入散开的 XAML 或图像文件。若使用远程存储，可将写入 ZIP 的阶段替换为对收集的字节数组的上传。使用导出作业标识加完整相对产物名称作为 Blob 键，或在数据库行中存储作业标识、相对名称和二进制数据。仅在所有上传完成或数据库事务提交后才发布作业。若持久化失败，请清理部分输出。

对于大型演示文稿，自定义保存器可以将每个产物直接持久化到应用存储，以避免在应用内存中保留整个导出的额外副本。请保持每个回调对导出器而言是同步的：仅在目标接受字节后返回，并让失败传递给调用者。

### **保留资源名称并验证引用**

- 当目标需要时规范化路径分隔符，但保留相对目录。除非每个生成的名称已知唯一且资源引用仍然有效，否则不要仅使用 [File.getName](https://developer.android.com/reference/java/io/File#getName())。
- 应用目标特定的名称验证。写入散文件时，拒绝根路径和遍历段，使用 [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()) 解析目标，并验证其仍位于预期的导出目录之下（在包含检查中包括目录分隔符）。使用没有符号链接的应用受控目录，以防写入被重定向。
- 为每个导出作业使用独立的保存器和存储命名空间。根据分隔符规范化后以及目标的区分大小写规则检测冲突。
- 在发布前，将每个 XAML 文档作为 XML 解析，检查其基于文件的资源引用，例如图像的 `Source` 或 `ImageSource` 属性。将每个相对 URI 相对于包含该 XAML 产物的目录进行解析，规范化得到的存储名称，并确认相应的 map 键、ZIP 条目或存储对象存在。对外部 URI 和 XAML 标记表达式应与相对文件名分开处理。

例如，若 `pres/Slide_1.xaml` 引用 `images/image1.png`，则必须以 `pres/images/image1.png` 形式存储该资源。仅保留 `image1.png` 会破坏这种关联。对于对象存储，请在作业前缀下保持相同的层级布局，并使这些资源 URL 对 XAML 消费者可访问。重新打开完成的 ZIP 以验证条目名称和资源字节，并在目标 XAML 环境中加载代表性幻灯片，以确认图像能够正确解析。

## **常见问题**

**如果原始字体在机器上不可用，如何确保字体的可预测性？**

在 [XamlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/xamloptions/) 中调用 [setDefaultRegularFont](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-)——当原始字体缺失时，它会作为回退字体使用。此操作并不能保证生成的 XAML 会引用回退字体，也不能保证目标机器上存在该字体。请确保 XAML 所引用的字体在显示环境中可用。

**导出的 XAML 仅适用于 WPF 吗？是否可以在其他 XAML 堆栈中使用？**

Aspose.Slides 通过公共 API 导出 WPF XAML。对其他 XAML 堆栈（如 UWP、Xamarin.Forms）的兼容性不作保证。请在目标环境中测试生成的标记。

**是否支持隐藏幻灯片？如何防止默认导出隐藏幻灯片？**

默认情况下不包含隐藏幻灯片。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/xamloptions/) 中使用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) 来控制此行为——若不需要导出隐藏幻灯片，请保持该选项为禁用状态。
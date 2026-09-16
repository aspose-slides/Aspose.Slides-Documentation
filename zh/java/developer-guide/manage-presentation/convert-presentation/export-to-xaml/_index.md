---
title: 将演示文稿导出为 Java 中的 XAML
linktitle: 演示文稿至 XAML
type: docs
weight: 30
url: /zh/java/export-to-xaml/
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
- 将 PPT 导出为 XAML
- 将 PPTX 导出为 XAML
- 将 ODP 导出为 XAML
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML——快速、无需 Office 的解决方案，保持布局完整。"
---
## **概述**

本文档说明了如何使用 Aspose.Slides 将 PowerPoint 演示文稿导出为 XAML。内容包括 XAML 的简要介绍，演示如何使用默认设置将演示文稿保存为 XAML，以及通过 [XamlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/xamloptions/) 自定义导出方式，包括导出隐藏幻灯片。文中还回答了一些常见问题，涉及回退字体、XAML 堆栈兼容性以及隐藏幻灯片的导出行为。

## **关于 XAML**

XAML 是一种基于 XML 的标记语言，用于在 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin.Forms 等框架中描述用户界面。

您可以在可视化设计器中使用 XAML 文件，也可以直接编写和编辑标记。

## **使用默认选项将演示文稿导出为 XAML**

以下 Java 示例展示了如何使用默认设置将演示文稿导出为 XAML：

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

默认情况下，导出的幻灯片会保存在进程当前工作目录的 `pres` 子文件夹中，该路径通过空路径与 [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-) 解析得到。文件夹会自动创建，所需的图像也会保存到该文件夹中。

输出文件夹的名称取自源文件名（不含扩展名）。例如，对于 `pres.pptx`，输出文件命名为 `pres/Slide_1.xaml`、`pres/Slide_2.xaml` 等。即使为输入演示文稿提供了绝对路径，输出文件夹仍相对于当前工作目录创建，而不是与输入文件并列。

## **使用自定义选项将演示文稿导出为 XAML**

使用 [IXamlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloptions/) 接口来控制 Aspose.Slides 将演示文稿导出为 XAML 的方式。

要将输出保存到自定义位置，请实现 [IXamlOutputSaver](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloutputsaver/) 并将您的实现实例传递给 [XamlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/xamloptions/) 的 [setOutputSaver](https://reference.aspose.com/slides/zh/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) 方法。

要在 XAML 输出中包含隐藏幻灯片，请按下例在 Java 示例中使用 `true` 调用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-)：

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

XAML 导出可以为每个导出的幻灯片生成一个 XAML 文档，并生成单独的图像和支持资源。将自定义的 [IXamlOutputSaver](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloutputsaver/) 绑定到 [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/zh/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) ，即可在不使用默认文件系统保存器的情况下获取这些产物。使用接受 XAML 选项的 XAML 专用 [Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 重载启动导出。

### **了解回调生命周期**

导出器会对每个生成的产物分别调用 [IXamlOutputSaver.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-)：

- `path` 标识产物，可能包含相对目录。请保留此信息，因为 XAML 可能使用相对路径引用资源。
- `data` 包含产物的字节数据。图像和其他二进制资源不得被解码为文本。
- 保存器负责在返回之前保留或持久化这些数据。示例将每个字节数组复制到应用程序拥有的内存中。
- 仅当演示文稿保存操作返回且所有回调均成功完成时，才视导出为成功。不要吞掉存储错误或启动未监控的后台写入。如果持久化在之后发生，仅在该步骤也成功后才报告整体成功。

[xamloptions.setexporthiddenslides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) 同样适用于自定义保存器。默认设置 `false` 会排除隐藏幻灯片的 XAML 文档。传入 `true` 则会包含它们以及导出所需的所有资源。资源数量取决于演示文稿；不要假设每张幻灯片对应一个回调或回调顺序固定。

### **导出到内存并检查产物**

下面的完整示例加载 `pres.pptx`，将每个产物收集到 [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) 中，并打印其名称、类型和字节计数。它会严格保留提供的名称。出现重复名称时，集合被标记为无效，而不是悄悄覆盖产物。示例在使用结果之前会进行此检查。

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

扩展名检查在检查时很有用；请保留所有产物，包括不熟悉的资源类型。存储或传输时保持字节不变。仅在需要对 XAML 进行文本处理时，才使用带 UTF-8 的 [String 构造函数](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-)。

### **将收集的产物打包为 ZIP 存档**

下面的独立示例收集导出内容，验证名称，并将原始字节写入 ZIP 存档。唯一的存档名称用于区分并发导出任务。ZIP 条目使用正斜杠并保留相对目录。若出现不安全的名称或归一化后冲突，整个包将在写入前被拒绝。

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
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

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // ZIP 目录已在报告成功之前通过关闭操作完成。
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

示例使用 [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) 写入单个本地存档；导出器本身不会写入松散的 XAML 或图像文件。对于远程存储，可用收集的字节数组上传代替写入存档。使用导出作业标识符加完整相对产物名称作为 Blob 键，或将作业标识符、相对名称和二进制数据存入数据库行。仅在所有上传完成或数据库事务提交后发布作业。若持久化失败，请清理部分输出。

对于大型演示文稿，自定义保存器可以将每个产物直接持久化到应用程序存储，以避免在应用程序内存中保留整个导出的额外副本。保持每个回调对导出器而言是同步的：仅在目标接受字节后返回，并让失败传播给调用方。

### **保留资源名称并验证引用**

- 当目标需要时对路径分隔符进行归一化，但保留相对目录。除非确认每个生成的名称唯一且资源引用仍然有效，否则不要仅使用 [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--)。
- 应用目标特定的名称验证。写入松散文件时，拒绝根路径和遍历段，使用 [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--) 解析目标，并确保其仍位于预期的导出目录下（在包含检查中包括目录分隔符）。使用不含可能导致重定向的符号链接的受控目录。
- 为每个导出作业使用独立的保存器和存储命名空间。根据分隔符合并后的名称以及目标的大小写敏感规则检测冲突。
- 在发布前，将每个 XAML 文档解析为 XML，检查其基于文件的资源引用，例如图像的 `Source` 或 `ImageSource` 属性。将每个相对 URI 相对于包含该 XAML 产物的目录解析，归一化得到的存储名称，并确认相应的映射键、ZIP 条目或存储对象存在。外部 URI 与 XAML 标记表达式应与相对文件名分开处理。

例如，若 `pres/Slide_1.xaml` 引用了 `images/image1.png`，则必须以 `pres/images/image1.png` 形式存储该资源。仅保留 `image1.png` 会导致关系断裂。对于对象存储，保持相同的层级结构在作业前缀下，并使这些资源 URL 可供 XAML 消费者访问。重新打开已完成的 ZIP 以验证条目名称和资源字节，并在目标 XAML 环境中加载示例幻灯片，确认图像能够正确解析。

## **常见问题解答**

**如果原始字体在机器上不可用，如何确保字体的可预测性？**

在 [XamlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/xamloptions/) 中调用 [setDefaultRegularFont](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) ——导出时缺少原始字体时会使用此回退字体。这并不保证生成的 XAML 会引用回退字体，也不保证该字体在目标机器上可用。请确保 XAML 所引用的字体在显示环境中已安装。

**导出的 XAML 是否仅针对 WPF，还是可以在其他 XAML 堆栈中使用？**

Aspose.Slides 通过其公共 API 导出 WPF XAML。对其他 XAML 堆栈（如 UWP 和 Xamarin.Forms）的兼容性没有保证。请在目标环境中测试生成的标记。

**是否支持隐藏幻灯片，如何防止它们默认被导出？**

默认情况下，隐藏幻灯片不会被包含。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/xamloptions/) 中使用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) 来控制此行为——如果不需要导出隐藏幻灯片，请保持该设置为禁用。
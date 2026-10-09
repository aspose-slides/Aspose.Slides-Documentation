---
title: 在 JavaScript 中将演示文稿导出为 XAML
linktitle: 演示文稿转 XAML
type: docs
weight: 30
url: /zh/nodejs-java/export-to-xaml/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出 演示文稿
- 转换 PowerPoint
- 转换 OpenDocument
- 转换 演示文稿
- PowerPoint 转 XAML
- OpenDocument 转 XAML
- 演示文稿 转 XAML
- PPT 转 XAML
- PPTX 转 XAML
- ODP 转 XAML
- 将 PPT 保存为 XAML
- 将 PPTX 保存为 XAML
- 将 ODP 保存为 XAML
- 导出 PPT 为 XAML
- 导出 PPTX 为 XAML
- 导出 ODP 为 XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML（JavaScript），快速、无 Office 的解决方案，保持布局完整。"
---
## **概述**

本文说明如何使用 Aspose.Slides 将 PowerPoint 演示文稿导出为 XAML。它包括对 XAML 的简要介绍，展示如何使用默认设置将演示文稿保存为 XAML，并演示如何通过 [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) 自定义导出，包括导出隐藏幻灯片。本文还回答了一些关于回退字体、XAML 堆栈兼容性以及隐藏幻灯片导出行为的常见问题。

## **关于 XAML**

XAML 是一种基于 XML 的标记语言，用于在诸如 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin.Forms 等框架中描述用户界面。

您可以在可视化设计器中使用 XAML 文件，或直接编写和编辑标记。

## **使用默认选项将演示文稿导出为 XAML**

下面的 JavaScript 示例展示了如何使用默认设置将演示文稿导出为 XAML：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

默认情况下，导出的幻灯片保存在进程当前工作目录的 `input` 子文件夹中。该文件夹会自动创建，所需的图像也会保存到该文件夹中。

输出文件夹名称取自源文件名（不含扩展名）。在 Aspose.Slides for Node.js via Java 26.8 中，导出 `input.pptx` 会生成类似 `input/input/Slide_1.xaml` 的嵌套路径。处理输出时请保留完整生成的路径。默认输出相对于当前工作目录，而不一定与输入文件位于同一目录。

## **使用自定义选项将演示文稿导出为 XAML**

使用 [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) 接口来控制 Aspose.Slides 如何将演示文稿导出为 XAML。

要将输出保存到自定义位置，请实现 [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) 并将您的实现实例传递给 [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) 的 [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) 方法。

要在 XAML 输出中包含隐藏幻灯片，请使用 `true` 调用 [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides)，示例如下 JavaScript 示例所示：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **捕获所有生成的 XAML 产物**

XAML 导出可以为每个导出的幻灯片生成一个 XAML 文档，并生成单独的图像和支持资源。将自定义的 [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) 分配给 [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) 以接收这些产物，而不是使用默认的文件系统保存器。使用接受 XAML 选项的 XAML‑specific [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) 重载启动导出。

在 Node.js 中，使用 Aspose.Slides 所使用的 `java` 包中的 `java.newProxy` 实现 Java 接口。保持代理可达，直至导出完成。

### **了解回调生命周期**

导出器会对每个生成的产物单独调用 [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-)：

- `path` 标识产物，并可能包含相对目录。请保留此信息，因为 XAML 可能使用相对路径引用资源。
- `data` 包含产物的字节。图像和其他二进制资源不得被解码为文本。
- 保存器负责在返回之前保留或持久化数据。示例将每个 Java 字节数组复制到应用拥有的 Node.js 缓冲区中。
- 仅当演示文稿保存操作返回且每个回调都成功完成时，才将导出视为成功。不要吞噬存储错误或启动未观察的后台写入。如果持久化在之后发生，仅在该步骤也成功后才报告总体成功。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) 也适用于自定义保存器。默认设置 `false` 会排除隐藏幻灯片的 XAML 文档。传入 `true` 则会包含它们以及导出所需的任何资源。资源数量取决于演示文稿；不要假设每张幻灯片只有一个回调或固定的回调顺序。

### **导出到内存并检查产物**

此完整示例加载 `input.pptx`，在 JavaScript 的名称‑到‑缓冲区映射中收集每个产物，并打印其名称、类型和字节数。它完全保留提供的名称。重复的名称会将集合标记为无效，而不是默默覆盖产物。示例在使用结果之前会进行此检查。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // 仅在需要进行文本检查时解码 XAML。
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

扩展名检查对于检查非常有用；保留所有产物，包括不熟悉的资源类型。存储或传输时保持字节不变。仅对需要文本处理的 XAML 使用 UTF‑8 解码。

### **将收集的产物打包为 ZIP 存档**

此独立示例收集导出结果，验证名称，并使用 Java 桥将原始字节写入 ZIP 存档。ZIP 在写入磁盘之前先在内存中组装。唯一的存档名称用于区分并发的导出作业。ZIP 条目使用正斜杠并保留相对目录。不安全的名称或规范化后冲突的名称会在写入之前拒绝整个包。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // 关闭操作会在归档持久化之前最终确定 ZIP 目录。
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

示例使用 [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) 写入单个本地存档；导出器本身不写入松散的 XAML 或图像文件。对于远程存储，可将写入存档的阶段替换为对收集的字节数组的上传。使用导出作业标识符加完整相对产物名称作为 Blob 键，或将作业标识符、相对名称和二进制数据存入数据库行。仅在所有上传完成或数据库事务提交后才发布作业。如果持久化失败，清理部分输出。

对于大型演示文稿，自定义保存器可以将每个产物直接持久化到应用存储，以避免在应用内存中保留整个导出的额外副本。保持每个回调对导出器而言是同步的：仅在目标接受字节后返回，并让失败传递给调用方。

### **保留资源名称并验证引用**

- 当目标要求时规范化路径分隔符，但保留相对目录。除非每个生成的名称已知唯一且资源引用仍然有效，否则不要仅使用基名。
- 应用目标特定的名称验证。写入松散文件时，拒绝根路径和遍历段，将目标解析为绝对路径，并验证其位于预期导出目录之下，包括在包含性检查中使用目录分隔符。使用没有可能重定向写入的符号链接的受控目录。
- 为每个导出作业使用单独的保存器和存储命名空间。根据目标的大小写敏感规则，在分隔符规范化后检测冲突。
- 在发布之前，将每个 XAML 文档解析为 XML，检查其基于文件的资源引用，例如图像 `Source` 或 `ImageSource` 属性。根据包含该 XAML 产物的目录解析每个相对 URI，规范化得到的存储名称，并确认相应的映射键、ZIP 条目或存储对象存在。将外部 URI 和 XAML 标记表达式与相对文件名分开处理。

例如，如果 `input/Slide_1.xaml` 引用 `images/image1.png`，则存储的资源必须以 `input/images/image1.png` 的形式可用。仅保留 `image1.png` 会破坏这种关系。对于对象存储，在作业前缀下保留相同的布局，并使这些资源 URL 对 XAML 消费者可访问。重新打开完成的 ZIP 以验证条目名称和资源字节，并在目标 XAML 环境中加载代表性幻灯片，以确认图像能够正确解析。

## **常见问题**

**如果原始字体在机器上不可用，如何确保字体可预测？**

调用 [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) 于 [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/)——在原始字体缺失时，它会作为导出期间的回退字体。这并不能保证生成的 XAML 会引用回退字体，或该字体在目标机器上可用。请确保 XAML 中引用的字体在显示环境中可用。

**导出的 XAML 仅用于 WPF，还是可以在其他 XAML 堆栈中使用？**

Aspose.Slides 通过其公共 API 导出 WPF XAML。对其他 XAML 堆栈（如 UWP 和 Xamarin.Forms）的兼容性不保证。请在目标环境中测试生成的标记。

**是否支持隐藏幻灯片，如何防止它们默认被导出？**

默认情况下，隐藏幻灯片不包含在内。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) 中使用 [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) 来控制此行为——如果不需要导出隐藏幻灯片，请保持其禁用状态。
---
title: 使用 JavaScript 将演示文稿导出为 XAML
linktitle: 演示文稿转 XAML
type: docs
weight: 30
url: /zh/nodejs-java/export-to-xaml/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出演示文稿
- 转换 PowerPoint
- 转换 OpenDocument
- 转换演示文稿
- PowerPoint 到 XAML
- OpenDocument 到 XAML
- 演示文稿到 XAML
- PPT 到 XAML
- PPTX 到 XAML
- ODP 到 XAML
- 将 PPT 保存为 XAML
- 将 PPTX 保存为 XAML
- 将 ODP 保存为 XAML
- 导出 PPT 为 XAML
- 导出 PPTX 为 XAML
- 导出 ODP 为 XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML——快速、无需 Office 的解决方案，保持布局完整。"
---
## **概述**

本文说明如何使用 Aspose.Slides 将 PowerPoint 演示文稿导出为 XAML。内容包括对 XAML 的简要介绍，展示如何使用默认设置将演示文稿保存为 XAML，以及通过 [XamlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/xamloptions/) 自定义导出，包括导出隐藏幻灯片。文章还回答了一些常见问题，涉及回退字体、XAML 堆栈兼容性以及隐藏幻灯片导出行为。

## **关于 XAML**

XAML 是一种基于 XML 的标记语言，用于在 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin.Forms 等框架中描述用户界面。

你可以在可视化设计器中使用 XAML 文件，也可以直接编写和编辑标记。

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

默认情况下，导出的幻灯片保存在进程当前工作目录的 `input` 子文件夹中。该文件夹会自动创建，所需的图像也会保存在其中。

输出文件夹的名称取自源文件名（不含扩展名）。在 Aspose.Slides for Node.js via Java 26.8 中，导出 `input.pptx` 会生成类似 `input/input/Slide_1.xaml` 的嵌套路径。处理输出时请保留完整生成的路径。默认输出是相对于当前工作目录，而不一定与输入文件位于同一目录。

## **使用自定义选项将演示文稿导出为 XAML**

使用 [IXamlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloptions/) 接口来控制 Aspose.Slides 如何将演示文稿导出为 XAML。

若要将输出保存到自定义位置，请实现 [IXamlOutputSaver](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloutputsaver/) 并将实现实例传递给 [setOutputSaver](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) 方法（位于 [XamlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/xamloptions/)）。

若要在 XAML 输出中包含隐藏幻灯片，请按以下 JavaScript 示例调用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) 并传入 `true`：

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

XAML 导出可能为每个导出的幻灯片生成一个 XAML 文档，并生成单独的图像和支持资源。将自定义的 [IXamlOutputSaver](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloutputsaver/) 关联到 [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/xamloptions/#setOutputSaver)，即可获取这些产物，而不是使用默认的文件系统保存器。使用接受 XAML 选项的 XAML‑specific [Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save) 重载启动导出。

在 Node.js 中，使用 Aspose.Slides 所用的 `java` 包的 `java.newProxy` 实现 Java 接口。保持代理可达，直至导出完成。

### **了解回调生命周期**

导出器会对每个生成的产物单独调用 [IXamlOutputSaver.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-)：

- `path` 标识产物，可能包含相对目录。请保留此信息，因为 XAML 可能会使用相对路径引用资源。
- `data` 包含产物的字节。图像和其他二进制资源不得被解码为文本。
- 保存器负责在返回前保留或持久化这些数据。示例将每个 Java 字节数组复制到应用拥有的 Node.js 缓冲区中。
- 只有当演示文稿保存操作返回且所有回调均成功完成时，才视导出为成功。不要吞掉存储错误或启动未监控的后台写入。如果持久化在后续进行，则仅在该步骤也成功后才报告整体成功。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) 同样适用于自定义保存器。默认设置 `false` 会排除隐藏幻灯片的 XAML 文档。传入 `true` 则会包含它们及其导出所需的任何资源。资源数量取决于演示文稿；不要假设每张幻灯片只有一个回调或回调顺序固定。

### **导出到内存并检查产物**

以下完整示例加载 `input.pptx`，将每个产物收集到 JavaScript 的名称‑到‑缓冲区映射中，并打印其名称、类型和字节数。示例严格保留提供的名称。出现重复名称时，集合被标记为无效，而不是悄悄覆盖产物。示例在使用结果前会进行此检查。

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

        // 仅在需要文本检查时解码 XAML。
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

扩展名检查对于检查很有帮助；保留所有产物，包括不熟悉的资源类型。存储或传输时保持字节不变。仅在需要对 XAML 进行文本处理时才使用 UTF-8 解码。

### **将收集的产物打包成 ZIP 存档**

此独立示例收集导出结果，验证名称，并使用 Java 桥将原始字节写入 ZIP 存档。ZIP 在内存中组装后再写入磁盘。唯一的存档名称用于区分并发导出任务。ZIP 条目使用正斜杠并保留相对目录。出现不安全的名称或经正规化后冲突的名称时，会在写入之前拒绝整个包。

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
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // 关闭操作在归档持久化之前完成 ZIP 目录的最终写入。
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

示例使用 [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) 写入单个本地存档；导出器本身不写入分散的 XAML 或图像文件。若使用远程存储，请将写入存档的阶段替换为对收集的字节数组进行上传。可以使用导出作业标识符加完整相对产物名称作为 Blob 键，或在数据库行中存储作业标识、相对名称和二进制数据。仅在所有上传完成或数据库事务提交后才发布作业。若持久化失败，请清理部分输出。

对于大型演示文稿，可使用自定义保存器直接将每个产物持久化到应用存储，以避免在内存中保留整个导出的额外副本。保持每个回调对导出器而言是同步的：只有在目标接受字节后才返回，并让错误传递给调用方。

### **保留资源名称并验证引用**

- 当目标需要时规范化路径分隔符，但保留相对目录。除非确定每个生成的名称都是唯一且资源引用保持有效，否则不要仅使用基名。
- 采用目标特定的名称验证。写入分散文件时，拒绝根路径和遍历段，解析目标为绝对路径，并验证其仍位于预期导出目录之下（在包含性检查中包括目录分隔符）。使用不含可能重定向写入的符号链接的受控目录。
- 为每个导出作业使用单独的保存器和存储命名空间。根据分隔符正规化后以及目标的大小写敏感规则检测冲突。
- 发布前，将每个 XAML 文档作为 XML 进行解析，检查其基于文件的资源引用，例如图像的 `Source` 或 `ImageSource` 属性。将每个相对 URI 相对于包含该 XAML 产物的目录进行解析，规范化得到的存储名称，并确认对应的映射键、ZIP 条目或存储对象存在。对外部 URI 和 XAML 标记表达式单独处理，区别于相对文件名。

例如，若 `input/Slide_1.xaml` 引用 `images/image1.png`，则必须以 `input/images/image1.png` 的形式存储该资源。仅保留 `image1.png` 会导致关系断裂。对对象存储而言，保持相同的层级结构位于作业前缀下，并使这些资源 URL 可供 XAML 消费者访问。重新打开已完成的 ZIP，验证条目名称和资源字节，并在目标 XAML 环境中加载代表性幻灯片，以确认图像能够正确解析。

## **常见问题**

**如果原始字体在机器上不可用，如何确保字体可预测？**

在 [XamlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/xamloptions/) 中调用 [setDefaultRegularFont](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) —— 当原始字体缺失时，它会作为导出过程的回退字体。此操作并不保证生成的 XAML 会引用该回退字体，也不保证目标机器上有该字体。请确保 XAML 所引用的字体在显示环境中可用。

**导出的 XAML 仅面向 WPF 吗？还是可以在其他 XAML 堆栈中使用？**

Aspose.Slides 通过其公开 API 导出 WPF XAML。对其他 XAML 堆栈（如 UWP 和 Xamarin.Forms）的兼容性不作保证。请在目标环境中测试生成的标记。

**是否支持隐藏幻灯片？如何防止它们默认被导出？**

默认情况下，不会包含隐藏幻灯片。你可以通过在 [XamlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/xamloptions/) 中使用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) 来控制此行为——如果不需要导出隐藏幻灯片，请保持该选项为禁用状态。
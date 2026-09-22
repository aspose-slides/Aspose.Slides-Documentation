---
title: 确定 Node.js 中原始演示文稿格式
linktitle: 源格式
type: docs
weight: 35
url: /zh/nodejs-java/detect-presentation-source-format/
keywords:
- 源格式
- 检测演示文稿格式
- PowerPoint
- OpenDocument
- 演示文稿
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 Node.js 中读取已加载演示文稿的原始格式，比较检测 API，并处理文件、流和旧版格式。"
---
## **概述**

加载演示文稿后，调用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getSourceFormat) 方法以确定其原始格式。当后续处理依赖于当前实例加载时的格式时，请使用它。

源格式不同于为输出文件选择的 [SaveFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/) 。将文件保存为其他格式不会更改现有实例的源格式。

## **读取文件的源格式**

此示例需要一个现有的 `sample.pptx` 文件。它加载文件并使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getSourceFormat) 选择应用程序处理策略，而不是使用文件名。更改输入路径以尝试其他格式。示例打印所选策略；请将消息替换为你的应用程序逻辑。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **识别受支持的值**

[SourceFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sourceformat/) 类定义整数常量，以区分以下演示文稿格式。下面的扩展名是常规扩展名，而非对原始文件名的重建。

| SourceFormat 值 | 扩展名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 演示文稿 |
| `Pptx` | `.pptx` | Office Open XML 演示文稿 |
| `Pptm` | `.pptm` | 支持宏的 Office Open XML 演示文稿 |
| `Pps` | `.pps` | PowerPoint 97–2003 幻灯片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 幻灯片放映 |
| `Ppsm` | `.ppsm` | 支持宏的 Office Open XML 幻灯片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 模板 |
| `Potx` | `.potx` | Office Open XML 模板 |
| `Potm` | `.potm` | 支持宏的 Office Open XML 模板 |
| `Odp` | `.odp` | OpenDocument 演示文稿 |
| `Otp` | `.otp` | OpenDocument 演示文稿模板 |
| `Fodp` | `.fodp` | Flat XML ODF 演示文稿 |
| `Xml` | `.xml` | PowerPoint XML 演示文稿 |

## **读取流的源格式**

此示例需要一个现有的 `sample.pps` 文件。将其字节读取到内存流中可模拟没有文件名的输入，例如数据库值或上传的字节数组。 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 构造函数只接受流。

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT、PPS 和 POT 使用相同的底层二进制格式。通过文件路径加载时，扩展名可以帮助区分幻灯片放映或模板。没有文件名时，旧版的 PPS 和 POT 内容可能被报告为 `SourceFormat.Ppt`；上面的 PPS 示例打印了 `SourceFormat.Ppt` 的整数值。

如果你的应用程序必须保留此区分，请单独保留原始文件名或子类型元数据。扩展名对于这些旧子类型是有用的提示，但不应成为识别任意演示文稿内容的唯一依据。

## **比较加载前后的检测**

在需要在完整加载演示文稿对象模型之前检查文件时，请使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) 和 [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat)。实例已经存在时，请使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getSourceFormat)。

此示例需要 `sample.pptx`，分别打印 `LoadFormat.Pptx` 和 `SourceFormat.Pptx` 的整数值。在生产环境中，根据处理阶段选择合适的 API；已经加载的演示文稿无需再次检查即可获取其源格式。

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

结果使用来自不同类的常量：[LoadFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadformat/) 和 [SourceFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sourceformat/)。不要比较它们的数值，也不要假设每种格式都有相同的检测结果。PowerPoint XML 在加载前可能报告为 `LoadFormat.Unknown`，加载后报告为 `SourceFormat.Xml`。

## **保持源格式和输出格式分离**

此示例需要 `sample.pptx` 并写入 `converted.odp`。它在保存原始实例前后都打印 `SourceFormat.Pptx` 的整数值。只有从 ODP 输出加载的新实例报告 `Odp`。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

使用 `new Presentation()` 从头创建的演示文稿报告 `SourceFormat.Pptx`。它没有输入文件：这是新创建实例的默认值，并不表示加载了 PPTX 文件。如果区分是创建还是加载实例对你的应用程序很重要，请单独跟踪此信息。

## **将源格式映射到扩展名**

以下示例需要 `sample.pptx`。它将每个当前受支持的 [SourceFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sourceformat/) 值映射到常规扩展名，而不解析输入文件名。回退机制可以避免对未识别的值悄然分配扩展名。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

此映射并不转换文件或恢复在流加载期间丢失的旧版 PPS/POT 子类型。实际保存时，请显式选择 [SaveFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/)，或使用在 [Save Presentations in Their Original Format](/slides/zh/nodejs-java/save-presentation/#save-presentations-in-their-original-format) 中演示的转换方式。

## **通过保存和重新打开验证格式**

此自包含示例在工作目录创建演示文稿并写入三个文件，使用相同名称的文件会被覆盖。它分别通过路径和内存流重新打开每个输出。对于 PPTX 和 ODP，两种方式都报告保存的格式。对于 PPS，按路径加载报告 `Pps`，而在没有文件名的情况下加载相同字节则报告 `Ppt`。

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

以下表格总结了具有匹配扩展名的演示文稿的源格式识别情况。名称表示常量；JavaScript 示例打印其整数值：

| 保存格式 | 文件路径的 SourceFormat | 无名流的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` 分别 | 与文件路径相同 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` 分别 | 与文件路径相同 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` 分别 | 与文件路径相同 |
| ODP, OTP | `Odp`, `Otp` 分别 | 与文件路径相同 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT 内容在无名流中被识别为 `Ppt`。该表描述了格式识别情况，并不保证在转换过程中保留每个演示文稿的所有特性。

## **常见问题**

**将演示文稿保存为 ODP 会改变从 PPTX 加载的演示文稿的源格式吗？**

不会。现有实例仍报告 `Pptx`。从已保存的 ODP 文件加载的实例报告 `Odp`。

**流能否始终区分旧版演示文稿、幻灯片放映和模板？**

不能。PPT、PPS 和 POT 共享相同的二进制格式。如果需要此区分，请单独保留文件名或子类型元数据。

**如果演示文稿已经加载，我应该使用哪个 API？**

读取 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getSourceFormat)。在加载之前进行检查时，请使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo)。
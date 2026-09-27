---
title: 在 Node.js via .NET 中打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/nodejs-net/open-presentation/
keywords:
- 打开演示文稿
- 打开 PowerPoint
- 打开 PPTX
- 打开 PPT
- 打开 ODP
- 加载演示文稿
- 来自缓冲区的演示文稿
- 幻灯片计数
- 转换演示文稿
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides for Node.js via .NET 打开 PPTX、PPT 和 ODP 演示文稿：从文件路径或 Buffer 加载，读取幻灯片计数，并另存为其他格式。"
---
## **概述**

Aspose.Slides for Node.js via .NET 可以从文件路径或 Node.js `Buffer` 打开 PowerPoint 和 OpenDocument 演示文稿，例如 PPTX、PPT 和 ODP 文件。本文演示这两种方式，读取幻灯片数量，并将打开的演示文稿另存为其他格式。

示例假设项目文件夹中存在名为 `sample.pptx` 的演示文稿，该文件夹已按照 [Installation](/slides/zh/nodejs-net/installation/) 中的步骤进行设置。任何 PowerPoint 演示文稿均可使用。将每个示例保存为项目文件夹中的 `.js` 文件，并在该文件夹中使用 `node` 运行。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET 没有独立的 API 文档。它镜像了 Aspose.Slides for .NET API，并使用 camelCase 命名，因此本文中的 API 链接指向 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) 中对应的类和成员。
{{% /alert %}}

## **从文件打开演示文稿**

要打开演示文稿，将其路径传递给 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) 构造函数。Aspose.Slides 会根据文件内容而非扩展名检测格式，因此相同代码可打开 PPTX、PPT 和 ODP 文件。相对路径相对于当前工作目录进行解析，而当您从项目文件夹运行脚本时，工作目录即为该文件夹。

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

脚本会输出 `sample.pptx` 中的幻灯片数量，例如 `Slide count: 9`。[slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 集合的 `count` 属性包括隐藏的幻灯片。如示例所示，在 `finally` 块中调用 `dispose`，以便即使代码出错，也能释放演示文稿背后的 .NET 资源。

## **从 Buffer 打开演示文稿**

当演示文稿来自数据库、HTTP 上传或其他以字节而非文件路径提供的来源时，将 Node.js `Buffer` 作为第二个构造函数参数，第一参数传 `null`。以下示例将 `sample.pptx` 读取到缓冲区，以模拟此类来源：

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

脚本会打印与前例相同的幻灯片数量。第二个参数必须是 `Buffer`。如果传入其他类型，如 `Uint8Array`，构造函数不会报错，而是创建一个仅含一张空幻灯片的新演示文稿。请先使用 `Buffer.from` 将其他二进制类型转换为 `Buffer`。

## **将演示文稿另存为其他格式**

要将演示文稿转换为其他演示文稿格式，打开后使用不同的 [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) 值进行保存。以下示例打印 Aspose.Slides 检测到的格式（由 [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) 属性返回），并将演示文稿保存为 OpenDocument 演示文稿：

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

脚本会输出 `Source format: Pptx` 并写入 `sample.odp`，其中包含相同的幻灯片。`sourceFormat` 返回 `Ppt`、`Pptx` 或 `Odp`。若想保存为 PDF 或图像，请参阅 [Convert PowerPoint to PDF](/slides/zh/nodejs-net/convert-powerpoint-to-pdf/) 和 [Convert Slides to Images](/slides/zh/nodejs-net/convert-slide/)。

## **常见问题**

**如何打开受密码保护的演示文稿？**

创建一个 [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) 对象，设置其 [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) 属性，然后将该对象作为构造函数的第三个参数传入：`new Presentation(\"protected.pptx\", null, loadOptions)`。若密码不正确，构造函数会抛出错误。

**为什么构造函数会抛出消息为空的 `Error`？**

当 .NET 中的 `Presentation` 构造函数失败时，例如文件缺失、不是演示文稿或需要不同的密码，JavaScript 会收到一个消息为空的 `Error`。在打开文件之前，请先检查文件相对于工作目录是否存在，例如使用 `fs.existsSync`。

**我可以打开哪些格式？**

PowerPoint 与 OpenDocument 演示文稿格式，包括 PPT、PPTX、PPS、POT、POTX、PPTM、ODP、OTP 和 FODP。
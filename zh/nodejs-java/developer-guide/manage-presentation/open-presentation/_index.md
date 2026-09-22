---
title: 在 JavaScript 中打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/nodejs-java/open-presentation/
keywords:
- 打开 PowerPoint
- 打开演示文稿
- 打开 PPTX
- 打开 PPT
- 打开 ODP
- 加载演示文稿
- 加载 PPTX
- 加载 PPT
- 加载 ODP
- 受保护的演示文稿
- 大型演示文稿
- 外部资源
- 二进制对象
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何在 JavaScript 中打开 PowerPoint 和 OpenDocument 演示文稿，提供打开密码，控制资源加载，并使用 Aspose.Slides for Node.js via Java 减少内存使用。"
---
## **简介**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/zh/nodejs-java/) 可以从文件和流中加载 PowerPoint 和 OpenDocument 演示文稿。加载演示文稿后，您可以检查其结构、编辑幻灯片、管理资源，并以原始格式或其他受支持的格式保存它。

可以通过 [LoadOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/) 类来自定义加载行为。例如，您可以提供打开密码、将大型二进制对象保留在 Node.js 内存之外、控制外部资源或省略嵌入的二进制数据。

## **打开演示文稿**

加载文件或流后，您可以 [确定其原始演示文稿格式](/slides/zh/nodejs-java/detect-presentation-source-format/) 以选择应用程序的处理方式。

要打开现有演示文稿，请将其文件路径传递给 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 构造函数。使用后释放 (Dispose) 演示文稿，以便及时释放文件句柄、临时数据和其他资源。

下面的 JavaScript 示例演示了如何打开演示文稿并获取其幻灯片计数：

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **打开受密码保护的演示文稿**

打开密码会加密演示文稿内容。要加载完整的演示文稿，请将正确的密码传递给 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setPassword) 并将选项提供给 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 构造函数。当密码缺失或不正确时，加载将失败。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

有关密码检测、验证和加密工作流，请参阅 [Password-Protect Presentations](/slides/zh/nodejs-java/password-protected-presentation/)。如果加密的演示文稿故意以公共文档属性保存，则可以在不提供密码的情况下读取这些属性；请参阅 [Manage Presentation Properties](/slides/zh/nodejs-java/presentation-properties/)。

## **打开大型演示文稿**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) 返回控制 Aspose.Slides 处理二进制大型对象（如图像、音频和视频）的选项。您可以保持源文件锁定、允许使用临时文件，并限制保留在内存中的 BLOB 数据量。

下面的 JavaScript 代码演示了加载大型演示文稿（例如 2 GB）：

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
使用 [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) 时，源文件将在演示文稿实例释放之前保持锁定。该实例存在期间，请勿移动、覆盖或删除源文件。

Aspose.Slides 在加载时可能会复制输入流的内容。对于大型演示文稿，文件路径通常比流更高效。有关其他存储和内存管理选项，请参阅 [Manage BLOBs](/slides/zh/nodejs-java/manage-blob/)。
{{% /alert %}}

## **控制外部资源**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) 接受一个 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iresourceloadingcallback/) 实现。回调可以提供替代数据、重定向资源、使用默认加载器或跳过资源。当演示文稿包含必须根据特定应用安全或存储规则解析的外部图像时，这非常有用。

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **加载不含嵌入二进制对象的演示文稿**

演示文稿可能包含应用程序不需要或不想保留的嵌入式二进制数据。例如包括：

- VBA 项目，可通过 [Presentation.getVbaProject](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getVbaProject) 获取；
- 嵌入的 OLE 数据，可通过 [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) 获取；
- ActiveX 控件数据，可通过 [Control.getActiveXControlBinary](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/control/#getActiveXControlBinary) 获取。

将 [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 设置为 `true`，即可在加载时删除这些二进制数据。保存已加载的演示文稿以保留清理后的结果。

此选项可降低不需要的嵌入式负载的风险，但它并非完整的恶意软件检测或内容消毒系统。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**如何判断文件已损坏且无法打开？**

Aspose.Slides 在加载期间会抛出解析或格式异常。请将此失败与密码错误错误分开处理，以便应用程序能够准确报告原因。

**如果缺少必需的字体会怎样？**

演示文稿仍然可以加载，但渲染和导出时可能会替换字体。您可以 [configure font substitution](/slides/zh/nodejs-java/font-substitution/) 或 [provide custom fonts](/slides/zh/nodejs-java/custom-font/) 以使输出更可预测。

**加载演示文稿是否也会加载其嵌入的媒体？**

嵌入的音频和视频可以通过演示文稿对象模型访问。外部资源将根据配置的资源加载行为进行解析，如果无法访问其位置，则可能不可用。
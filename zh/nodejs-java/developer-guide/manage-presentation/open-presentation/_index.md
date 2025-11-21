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
description: "使用 Aspose.Slides for Node.js 轻松打开 PowerPoint（.pptx、.ppt）和 OpenDocument（.odp）演示文稿——快速、可靠、功能齐全。"
---

## **概述**

除了从头创建 PowerPoint 演示文稿外，Aspose.Slides 还可以打开现有的演示文稿。加载演示文稿后，您可以检索其信息、编辑幻灯片内容、添加新幻灯片、删除现有幻灯片等。

## **打开演示文稿**

要打开现有演示文稿，请实例化[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)类并将文件路径传递给其构造函数。

以下 JavaScript 示例演示了如何打开演示文稿并获取其幻灯片计数：
```js
// 实例化 Presentation 类，并将文件路径传递给其构造函数。
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // 打印演示文稿中的幻灯片总数。
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **打开受密码保护的演示文稿**

当需要打开受密码保护的演示文稿时，请通过[LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/)类的[setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setPassword)方法传入密码以解密并加载。以下 JavaScript 代码演示了此操作：
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // 对已解密的演示文稿执行操作。
} finally {
    presentation.dispose();
}
```


## **打开大型演示文稿**

Aspose.Slides 提供选项——特别是[LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/)类中的[getBlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions)方法——帮助您加载大型演示文稿。

以下 JavaScript 代码演示了加载大型演示文稿（例如 2 GB）：
```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// 选择 KeepLocked 行为——演示文稿文件将在整个生命周期内保持锁定
// Presentation 实例，但不需要加载到内存或复制到临时文件。
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // 已加载大型演示文稿并可使用，同时内存占用保持低水平。
    
    // 对演示文稿进行更改。
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // 将演示文稿保存到另一个文件。此操作期间内存占用保持低水平。
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // 不要这样做！由于文件被锁定，直到释放演示文稿对象前会抛出 I/O 异常。
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// 这里这样做是可以的。源文件已不再被演示文稿对象锁定。
fs.unlinkSync(filePath);
```


{{% alert color="info" title="Info" %}}
为了解决在使用流时的某些限制，Aspose.Slides 可能会复制流的内容。从流加载大型演示文稿会导致演示文稿被复制，从而减慢加载速度。因此，当需要加载大型演示文稿时，我们强烈建议使用演示文稿文件路径而非流。

在创建包含大型对象（视频、音频、高分辨率图像等）的演示文稿时，您可以使用[BLOB 管理](/slides/zh/nodejs-java/manage-blob/)来降低内存消耗。
{{%/alert %}}

## **控制外部资源**

Aspose.Slides 提供[IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/)接口，让您管理外部资源。以下 JavaScript 代码展示了如何使用 `IResourceLoadingCallback` 接口：
```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // 加载替代图像。
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // 设置替代 URL。
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // 跳过所有其他图像。
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```


## **加载不含嵌入二进制对象的演示文稿**

PowerPoint 演示文稿可能包含以下类型的嵌入二进制对象：

- VBA 项目（通过[Presentation.getVbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject)访问）；
- OLE 对象嵌入数据（通过[OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData)访问）；
- ActiveX 控件二进制数据（通过[Control.getActiveXControlBinary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getActiveXControlBinary)访问）。

使用[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects)方法，您可以在不加载任何嵌入二进制对象的情况下打开演示文稿。

此方法可帮助移除可能的恶意二进制内容。以下 JavaScript 代码演示了如何在不加载任何嵌入二进制内容的情况下打开演示文稿：
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // 对演示文稿执行操作。
} finally {
    presentation.dispose();
}
```


## **常见问题**

**如何判断文件已损坏且无法打开？**

加载时会抛出解析/格式验证异常。此类错误通常提到 ZIP 结构无效或 PowerPoint 记录损坏。

**打开时缺少必需的字体会怎样？**

文件仍会打开，但后续[渲染/导出](/slides/zh/nodejs-java/convert-presentation/)可能会自动替代字体。请[配置字体替代](/slides/zh/nodejs-java/font-substitution/)或[将必需字体添加到运行时环境](/slides/zh/nodejs-java/custom-font/)。

**打开时嵌入的媒体（视频/音频）会怎样？**

它们会作为演示文稿资源可用。如果媒体通过外部路径引用，请确保这些路径在您的环境中可访问；否则[渲染/导出](/slides/zh/nodejs-java/convert-presentation/)可能会省略这些媒体。
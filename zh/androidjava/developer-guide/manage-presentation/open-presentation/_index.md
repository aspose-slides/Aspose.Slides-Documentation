---
title: 在 Android 上打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/androidjava/open-presentation/
keywords:
- 打开 PowerPoint
- 打开 OpenDocument
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
- Android
- Java
- Aspose.Slides
description: "通过 Java 使用 Aspose.Slides for Android，轻松打开 PowerPoint（.pptx、.ppt）和 OpenDocument（.odp）演示文稿——快速、可靠、功能齐全。"
---

## **概述**

除了从头创建 PowerPoint 演示文稿外，Aspose.Slides 还可以打开已有的演示文稿。加载演示文稿后，您可以检索其信息，编辑幻灯片内容，添加新幻灯片，删除已有幻灯片等。

## **打开演示文稿**

要打开已有演示文稿，请实例化 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类并将文件路径传入其构造函数。

下面的 Java 示例演示了如何打开演示文稿并获取其幻灯片数量：
```java
// 实例化 Presentation 类并将文件路径传递给其构造函数。
Presentation presentation = new Presentation("Sample.pptx");
try {
    // 打印演示文稿中的幻灯片总数。
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **打开受密码保护的演示文稿**

当需要打开受密码保护的演示文稿时，可通过 [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) 类的 [setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 方法传入密码，以解密并加载演示文稿。下面的 Java 代码演示了此操作：
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // 对已解密的演示文稿执行操作。
} finally {
    presentation.dispose();
}
```


## **打开大型演示文稿**

Aspose.Slides 提供了选项，特别是 [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) 类的 [getBlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) 方法，以帮助您加载大型演示文稿。

下面的 Java 代码演示了加载大型演示文稿（例如 2 GB）的方式：
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// 选择 KeepLocked 行为——演示文稿文件将在整个生命周期内保持锁定
// Presentation 实例，但它不需要加载到内存中或复制到临时文件。
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // 大型演示文稿已加载，可供使用，同时内存占用保持低水平。

    // 对演示文稿进行修改。
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // 将演示文稿保存到另一个文件。此操作期间内存占用仍保持低水平。
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // 不要这样做！会抛出 I/O 异常，因为文件会被锁定，直到释放演示稿对象。
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// 这里可以这样做。源文件已不再被演示文稿对象锁定。
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="信息" %}}

为了解决使用流时的某些限制，Aspose.Slides 可能会复制流的内容。从流加载大型演示文稿会导致演示文稿被复制，进而减慢加载速度。因此，当需要加载大型演示文稿时，强烈建议使用演示文稿文件路径而非流。

在创建包含大对象（视频、音频、高分辨率图像等）的演示文稿时，您可以使用 [BLOB management](/slides/zh/androidjava/manage-blob/) 来降低内存消耗。

{{%/alert %}}

## **控制外部资源**

Aspose.Slides 提供了 [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/) 接口，让您管理外部资源。下面的 Java 代码展示了如何使用 `IResourceLoadingCallback` 接口：
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // 加载替代图像。
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // 使用任何方法获取字节
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // 设置替代 URL。
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // 跳过所有其他图像。
        return ResourceLoadingAction.Skip;
    }
}
```


## **加载不含嵌入二进制对象的演示文稿**

PowerPoint 演示文稿可能包含以下类型的嵌入二进制对象：

- VBA 项目（可通过 [IPresentation.getVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) 访问）；
- OLE 对象嵌入数据（可通过 [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) 访问）；
- ActiveX 控件二进制数据（可通过 [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) 访问）。

使用 [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) 方法，您可以在加载演示文稿时删除所有嵌入的二进制对象。

此方法对去除可能的恶意二进制内容非常有用。下面的 Java 代码演示了如何在加载演示文稿时剔除所有嵌入的二进制内容：
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // 对演示文稿执行操作。
} finally {
    presentation.dispose();
}
```


## **常见问题**

**如何判断文件已损坏且无法打开？**

加载时会抛出解析/格式验证异常。此类错误通常会提及 ZIP 结构无效或 PowerPoint 记录损坏。

**打开时缺少必需的字体会怎样？**

文件仍会打开，但后续的 [渲染/导出](/slides/zh/androidjava/convert-presentation/) 可能会使用替代字体。请 [配置字体替代](/slides/zh/androidjava/font-substitution/) 或 [添加所需字体](/slides/zh/androidjava/custom-font/) 到运行时环境。

**打开时嵌入的媒体（视频/音频）会怎样处理？**

它们会作为演示文稿资源可用。如果媒体是通过外部路径引用，请确保这些路径在您的环境中可访问，否则 [渲染/导出](/slides/zh/androidjava/convert-presentation/) 可能会省略这些媒体。
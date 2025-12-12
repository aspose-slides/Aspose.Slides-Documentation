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
description: "通过 Aspose.Slides for Android 使用 Java 轻松打开 PowerPoint（.pptx、.ppt）和 OpenDocument（.odp）演示文稿——快速、可靠、功能齐全。"
---

## **概述**

除了从头创建 PowerPoint 演示文稿外，Aspose.Slides 还允许您打开现有的演示文稿。加载演示文稿后，您可以检索其信息、编辑幻灯片内容、添加新幻灯片、删除现有幻灯片等。

## **打开演示文稿**

要打开现有的演示文稿，请实例化 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类，并将文件路径传递给其构造函数。

以下 Java 示例展示了如何打开演示文稿并获取其幻灯片计数：
```java
// 实例化 Presentation 类并将文件路径传递给其构造函数。
Presentation presentation = new Presentation("Sample.pptx");
try {
    // 打印演示文稿中幻灯片的总数。
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **打开受密码保护的演示文稿**

当需要打开受密码保护的演示文稿时，请通过 [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) 类的 [setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 方法传递密码以解密并加载它。以下 Java 代码演示了此操作：
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

Aspose.Slides 提供了一些选项——尤其是 [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) 类中的 [getBlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) 方法——帮助您加载大型演示文稿。

以下 Java 代码演示了加载大型演示文稿（例如 2 GB）：
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Large presentation has been loaded and can be used, while memory consumption remains low.
    // 对大型演示文稿已加载并可使用，同时内存占用保持低水平。

    // Make changes to the presentation.
    // 对演示文稿进行更改。

    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Save the presentation to another file. Memory consumption remains low during this operation.
    // 将演示文稿保存到另一个文件。在此操作期间内存占用保持低水平。

    // Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
    // 不要这么做！因为文件被锁定直至释放演示文稿对象，都会抛出 I/O 异常。
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// It is OK to do it here. The source file is no longer locked by the presentation object.
 // 这里执行是可以的。源文件已不再被演示文稿对象锁定。
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
为了解决在使用流时的某些限制，Aspose.Slides 可能会复制流的内容。从流加载大型演示文稿会导致演示文稿被复制，从而降低加载速度。因此，当需要加载大型演示文稿时，我们强烈建议使用演示文稿文件路径而非流。

在创建包含大型对象（视频、音频、高分辨率图像等）的演示文稿时，您可以使用 [BLOB management](/slides/zh/androidjava/manage-blob/) 来降低内存消耗。
{{%/alert %}}

## **控制外部资源**

Aspose.Slides 提供了 [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/) 接口，允许您管理外部资源。以下 Java 代码展示了如何使用 `IResourceLoadingCallback` 接口：
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
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // 使用任意方法获取字节
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

此方法对于删除潜在的恶意二进制内容非常有用。以下 Java 代码演示了如何在不包含任何嵌入二进制内容的情况下加载演示文稿：
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


## **FAQ**

**如何判断文件已损坏且无法打开？**

在加载期间会抛出解析/格式验证异常。这类错误通常提及无效的 ZIP 结构或损坏的 PowerPoint 记录。

**打开时如果缺少必需的字体会怎样？**

文件仍会打开，但随后在 [渲染/导出](/slides/zh/androidjava/convert-presentation/) 时可能会替换字体。请在运行时环境中 [配置字体替换](/slides/zh/androidjava/font-substitution/) 或 [添加所需字体](/slides/zh/androidjava/custom-font/)。

**打开时嵌入的媒体（视频/音频）怎么办？**

它们会作为演示文稿资源可用。如果媒体通过外部路径引用，请确保这些路径在您的环境中可访问；否则在 [渲染/导出](/slides/zh/androidjava/convert-presentation/) 时可能会省略这些媒体。
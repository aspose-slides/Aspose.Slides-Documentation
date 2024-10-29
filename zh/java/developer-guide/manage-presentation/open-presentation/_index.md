---
title: 在 Java 中打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/java/open-presentation/
keywords: "打开 PowerPoint, PPTX, PPT, 打开演示文稿, 加载演示文稿, Java"
description: "在 Java 中打开或加载 PPT、PPTX、ODP 演示文稿"
---

除了从头创建 PowerPoint 演示文稿外，Aspose.Slides 还允许您打开现有的演示文稿。在加载演示文稿后，您可以获取有关该演示文稿的信息，编辑演示文稿（其幻灯片上的内容），添加新幻灯片或删除现有的幻灯片等。

## 打开演示文稿

要打开现有的演示文稿，您只需实例化 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类，并将文件路径（您想要打开的演示文稿的路径）传递给它的构造函数。

以下 Java 代码向您展示如何打开演示文稿并找出其包含的幻灯片数量：

```java
// 实例化 Presentation 类并将文件路径传递给其构造函数
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 打印演示文稿中当前幻灯片的总数
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **打开密码保护的演示文稿**

当您需要打开密码保护的演示文稿时，可以通过 [Password](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#getPassword--) 属性（来自 [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) 类）传递密码，以解密演示文稿并加载演示文稿。以下 Java 代码演示了该操作：

```java
 LoadOptions loadOptions = new LoadOptions();
 loadOptions.setPassword("YOUR_PASSWORD");
 Presentation pres = new Presentation("pres.pptx", loadOptions);
 try {
 // 对解密后的演示文稿执行某些操作
 } finally {
     if (pres != null) pres.dispose();
 }
```

## 打开大演示文稿

Aspose.Slides 在 [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions) 类下提供了一些选项（尤其是 [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) 属性），以允许您加载大演示文稿。

以下 Java 代码演示了加载一个大演示文稿（例如大小为 2GB）的操作：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0L);

Presentation pres = new Presentation("veryLargePresentation.pptx", loadOptions);
try {
    // 大演示文稿已加载并可以使用，但内存消耗仍然很低。
    // 对演示文稿进行更改。
    pres.getSlides().get_Item(0).setName("非常大的演示文稿");

    // 演示文稿将保存到其他文件。操作期间内存消耗保持较低。
    pres.save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

{{% alert color="info" title="信息" %}}

为绕过与流交互时某些限制，Aspose.Slides 可能会复制流的内容。通过其流加载大演示文稿将导致演示文稿内容的复制，并造成加载缓慢。因此，当您打算加载大演示文稿时，我们强烈建议您使用演示文稿文件路径，而不是其流。

当您想要创建包含大型对象（视频、音频、大图像等）的演示文稿时，可以使用 [Blob facility](https://docs.aspose.com/slides/java/manage-blob/) 以减少内存消耗。

{{%/alert %}} 

## 加载演示文稿

Aspose.Slides 提供了 [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) 及其单一方法，以便您管理外部资源。以下 Java 代码向您展示了如何使用 `IResourceLoadingCallback` 接口：

```java
LoadOptions opts = new LoadOptions();
opts.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation pres = new Presentation("presentation.pptx", opts);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback 
{
    public int resourceLoading(IResourceLoadingArgs args) 
    {
        if (args.getOriginalUri().endsWith(".jpg")) 
        {
            try // 加载替代图像
            {
                byte[] imageBytes = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // 设置替代 URL
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // 跳过所有其他图像
        return ResourceLoadingAction.Skip;
    }
}
```

## 加载不含嵌入二进制对象的演示文稿

PowerPoint 演示文稿可以包含以下类型的嵌入二进制对象：

- VBA 项目 ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- OLE 对象嵌入数据 ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX 控件二进制数据 ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

通过使用 [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) 属性，您可以加载不含任何嵌入二进制对象的演示文稿。

该属性可用于移除潜在的恶意二进制内容。

以下代码演示如何加载并保存不含任何恶意内容的演示文稿：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation pres = new Presentation("malware.ppt", loadOptions);
try {
    pres.save("clean.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## 打开和保存演示文稿

打开和保存演示文稿的步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例并传递您想要打开的文件。
2. 保存演示文稿。

```java
// 实例化一个表示 PPT 文件的 Presentation 对象
Presentation pres = new Presentation();
try {
    // ...在这里执行一些工作...
    
    // 将演示文稿保存到文件
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```
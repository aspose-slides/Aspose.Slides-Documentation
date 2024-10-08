---
title: 在Java中打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /androidjava/open-presentation/
keywords: "打开PowerPoint, PPTX, PPT, 打开演示文稿, 加载演示文稿, Java"
description: "在Java中打开或加载演示文稿PPT、PPTX、ODP"
---

除了从头创建PowerPoint演示文稿外，Aspose.Slides还允许您打开现有的演示文稿。在加载演示文稿后，您可以获取有关演示文稿的信息，编辑演示文稿（幻灯片上的内容），添加新幻灯片或删除现有幻灯片等。

## 打开演示文稿

要打开现有的演示文稿，只需实例化[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)类，并将文件路径（要打开的演示文稿的路径）传递给它的构造函数。

以下Java代码展示了如何打开一个演示文稿，并找出它包含的幻灯片数量：

```java
// 实例化 Presentation 类并将文件路径传递给它的构造函数
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 打印演示文稿中幻灯片的总数
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **打开受密码保护的演示文稿**

当您需要打开受密码保护的演示文稿时，可以通过[Password](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getPassword--)属性（来自[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)类）传递密码，以解密演示文稿并加载演示文稿。以下Java代码演示了该操作：

```java
 LoadOptions loadOptions = new LoadOptions();
 loadOptions.setPassword("YOUR_PASSWORD");
 Presentation pres = new Presentation("pres.pptx", loadOptions);
 try {
 // 对解密后的演示文稿进行一些操作
 } finally {
     if (pres != null) pres.dispose();
 }
```

## 打开大型演示文稿

Aspose.Slides提供了在[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions)类下的选项（特别是[BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-)属性）以允许您加载大型演示文稿。

以下Java代码演示了一个加载大型演示文稿（例如2GB大小）的操作：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0L);

Presentation pres = new Presentation("veryLargePresentation.pptx", loadOptions);
try {
    // 大型演示文稿已加载并可以使用，但内存消耗仍然很低。
    // 对演示文稿进行更改。
    pres.getSlides().get_Item(0).setName("非常大的演示文稿");

    // 演示文稿将保存到另一个文件。在操作期间内存消耗保持低。
    pres.save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

{{% alert color="info" title="信息" %}}

为了避免与流交互时的某些限制，Aspose.Slides可能会复制流的内容。通过流加载大型演示文稿将导致演示文稿内容的复制，并导致加载缓慢。因此，当您打算加载大型演示文稿时，我们强烈建议您使用演示文稿文件路径，而不是流。

当您想创建一个包含大型对象（视频、音频、大图像等）的演示文稿时，可以使用[Blob功能](https://docs.aspose.com/slides/androidjava/manage-blob/)来减少内存消耗。

{{%/alert %}} 

## 加载演示文稿

Aspose.Slides提供了[IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/)，其中包含一个方法，允许您管理外部资源。以下Java代码展示了如何使用`IResourceLoadingCallback`接口：

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
            // 设置替代网址
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // 跳过所有其他图像
        return ResourceLoadingAction.Skip;
    }
}
```

## 加载不包含嵌入式二进制对象的演示文稿

PowerPoint演示文稿可以包含以下类型的嵌入式二进制对象：

- VBA项目 ([IPresentation.VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/));
- 嵌入的OLE对象数据 ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX控件的二进制数据 ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--));

使用[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)属性，您可以加载不包含任何嵌入式二进制对象的演示文稿。

该属性对于删除潜在的恶意二进制内容非常有用。

以下代码演示如何加载并保存不包含任何恶意内容的演示文稿：

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

## 打开并保存演示文稿

打开和保存演示文稿的步骤：

1. 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例，并传递您想打开的文件。
2. 保存演示文稿。  

```java
// 实例化一个表示PPT文件的Presentation对象
Presentation pres = new Presentation();
try {
    // ...在这里进行一些工作...
    
    // 将您的演示文稿保存到文件
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```
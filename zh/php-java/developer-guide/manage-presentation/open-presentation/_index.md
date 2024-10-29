---
title: 打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/php-java/open-presentation/
keywords: "打开 PowerPoint, PPTX, PPT, 打开演示文稿, 加载演示文稿, Java"
description: "打开或加载演示文稿 PPT, PPTX, ODP "
---

除了从头开始创建 PowerPoint 演示文稿，Aspose.Slides 还允许您打开现有的演示文稿。在加载演示文稿后，您可以获取有关演示文稿的信息，编辑演示文稿（幻灯片上的内容），添加新幻灯片或删除现有幻灯片等。

## 打开演示文稿

要打开现有的演示文稿，您只需实例化 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类并将文件路径（要打开的演示文稿的路径）传递给它的构造函数。

以下 PHP 代码向您展示了如何打开演示文稿并找出其包含的幻灯片数量：

```php
  # 实例化 Presentation 类并将文件路径传递给其构造函数
  $pres = new Presentation("Presentation.pptx");
  try {
    # 打印演示文稿中幻灯片的总数量
    echo($pres->getSlides()->size());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **打开受密码保护的演示文稿**

当您需要打开一个受密码保护的演示文稿时，可以通过 [Password](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getPassword--) 属性（来自 [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) 类）传递密码，以解密演示文稿并加载它。以下 PHP 代码演示了该操作：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("YOUR_PASSWORD");
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
    # 对解密的演示文稿进行一些操作
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 打开大型演示文稿

Aspose.Slides 提供了选项（尤其是 [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) 属性）在 [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions) 类下，以允许您加载大型演示文稿。

以下 Java 演示了加载一个大型演示文稿（例如，大小为 2GB）的操作：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(0);
  $pres = new Presentation("veryLargePresentation.pptx", $loadOptions);
  try {
    # 大型演示文稿已加载，并且可以使用，但内存消耗仍然很低。
    # 对演示文稿进行更改。
    $pres->getSlides()->get_Item(0)->setName("非常大的演示文稿");
    # 演示文稿将保存到其他文件。在操作过程中内存消耗保持较低
    $pres->save("veryLargePresentation-copy.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="info" title="信息" %}}

为了规避与流交互时的某些限制，Aspose.Slides 可能会复制流的内容。通过其流加载大型演示文稿将导致演示文稿内容的复制并导致加载缓慢。因此，当您打算加载大型演示文稿时，我们强烈建议您使用演示文稿文件路径，而不是它的流。

当您想要创建一个包含大型对象（视频、音频、大图像等）的演示文稿时，您可以使用 [Blob facility](https://docs.aspose.com/slides/php-java/manage-blob/) 来减少内存消耗。

{{%/alert %}}

## 加载演示文稿

Aspose.Slides 提供 [IResourceLoadingCallback](https://reference.aspose.com/slides/php-java/aspose.slides/iresourceloadingcallback/) 的单一方法，以便让您管理外部资源。以下 PHP 代码向您展示了如何使用 `IResourceLoadingCallback` 接口：

```php

class ImageLoadingHandler {
    function resourceLoading($args) {
      if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
        # 加载替代图像
        $file = new Java("java.io.File", "aspose-logo.jpg");
        $Array = new JavaClass("java.lang.reflect.Array");
        $Byte = new JavaClass("java.lang.Byte");
        $imageBytes = $Array->newInstance($Byte, $Array->getLength($file));
        try {
            $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file));
            $dis->readFully($imageBytes);
        } finally {
            if (!java_is_null($dis)) $dis->close();
        }
          $args->setData($imageBytes);
          return ResourceLoadingAction::UserProvided;
      } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
        # 设置替代 URL
        $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
        return ResourceLoadingAction::Default;
      }
      # 跳过所有其他图像
      return ResourceLoadingAction::Skip;
    }
  }

  $opts = new LoadOptions();
  $loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));
  $opts->setResourceLoadingCallback($loadingHandler);
  $pres = new Presentation("presentation.pptx", $opts);
```

## 加载没有嵌入式二进制对象的演示文稿

PowerPoint 演示文稿可以包含以下类型的嵌入式二进制对象：

- VBA 项目 ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- 嵌入的 OLE 对象数据 ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX 控件二进制数据 ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

使用 [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) 属性，您可以加载没有任何嵌入式二进制对象的演示文稿。

此属性对于删除潜在的恶意二进制内容非常有用。

以下代码演示了如何加载并保存没有任何恶意内容的演示文稿：

```java
  $loadOptions = new LoadOptions();
  $loadOptions->setDeleteEmbeddedBinaryObjects(true);

  $pres = new Presentation("malware.ppt", $loadOptions);
  try {
    $pres->save("clean.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null(pres)) { 
      $pres->dispose();
    }
  }
```

## 打开和保存演示文稿

打开和保存演示文稿的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例，并传递您想要打开的文件。
2. 保存演示文稿。

```php
  # 实例化一个表示 PPT 文件的 Presentation 对象
  $pres = new Presentation();
  try {
    # ...在这里做一些工作...
    # 将您的演示文稿保存到文件
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
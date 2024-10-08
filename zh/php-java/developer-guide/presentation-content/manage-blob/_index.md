---
title: 管理 BLOB
type: docs
weight: 10
url: /php-java/manage-blob/
description: 使用 PHP 管理 PowerPoint 演示文稿中的 BLOB。使用 BLOB 来减少 PowerPoint 演示文稿中的内存消耗。通过 BLOB 将大文件添加到使用 PHP 的 PowerPoint 演示文稿中。从使用 PHP 的 PowerPoint 演示文稿中通过 BLOB 导出大文件。使用 PHP 将大型 PowerPoint 演示文稿作为 BLOB 加载。
---

## **关于 BLOB**

**BLOB**（**二进制大对象**）通常是以二进制格式保存的大型项目（照片、演示文稿、文档或媒体）。 

Aspose.Slides for PHP via Java 允许您以减少涉及大文件时的内存消耗的方式使用 BLOB。

{{% alert title="信息" color="info" %}}

为了规避与流交互时的某些限制，Aspose.Slides 可能会复制流的内容。通过其流加载大型演示文稿将导致演示文稿内容的复制，并造成加载缓慢。因此，当您打算加载大型演示文稿时，我们强烈建议您使用演示文稿文件路径而不是其流。

{{% /alert %}}

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 将大文件添加到演示文稿**

[Aspose.Slides](/slides/php-java/) for Java 允许您通过涉及 BLOB 的过程将大文件（在本例中是一个大型视频文件）添加到演示文稿中，以减少内存消耗。

下面的 Java 代码演示了如何通过 BLOB 过程将大型视频文件添加到演示文稿中：

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # 创建一个新演示文稿，视频将被添加到其中
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # 将视频添加到演示文稿 - 我们选择 KeepLocked 行为，因为我们
      # 不打算访问“veryLargeVideo.avi”文件。
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # 保存演示文稿。当一个大型演示文稿被输出时，内存消耗
      # 在 pres 对象的生命周期内保持较低
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **通过 BLOB 从演示文稿导出大文件**
Aspose.Slides for PHP via Java 允许您通过涉及 BLOB 的过程从演示文稿中导出大文件（在本例中为音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望该文件被加载到计算机的内存中。通过 BLOB 过程导出文件，您可以保持低内存消耗。

以下代码演示了所描述的操作：

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # 锁定源文件并不将其加载到内存中
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # 创建演示文稿的实例，锁定“hugePresentationWithAudiosAndVideos.pptx”文件。
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # 将每个视频保存到文件中。为了防止高内存使用，我们需要一个缓冲区，用于将数据从演示文稿的视频流传输到新创建的视频文件的流中。
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # 迭代视频
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # 打开演示文稿视频流。请注意，我们故意避免访问属性
      # 例如 video.BinaryData - 因为此属性返回一个包含完整视频的字节数组，这将导致
      # 字节加载到内存中。我们使用 video.GetStream，它将返回 Stream - 并且不需要
      # 我们将整个视频加载到内存中。
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # 无论视频或演示文稿的大小如何，内存消耗将保持较低。
    }
    # 如有必要，您可以对音频文件应用相同的步骤。
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **在演示文稿中将图像作为 BLOB 添加**
使用 [**IImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) 接口和 [**ImageCollection** ](https://reference.aspose.com/slides/php-java/aspose.slides/ImageCollection) 类中的方法，您可以将大型图像作为流添加，以将其视为 BLOB。

以下 PHP 代码演示了如何通过 BLOB 过程添加大型图像：

```php
  $pathToLargeImage = "large_image.jpg";
  # 创建一个新演示文稿，图片将被添加到其中。
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # 将图像添加到演示文稿 - 我们选择 KeepLocked 行为，因为我们不打算访问“largeImage.png”文件。
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # 保存演示文稿。当一个大型演示文稿被输出时，内存消耗
      # 在 pres 对象的生命周期内保持较低
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **内存与大型演示文稿**

通常，加载大型演示文稿，计算机需要大量临时内存。所有演示文稿的内容都被加载到内存中，并且停止使用（从中加载演示文稿的）文件。 

考虑一个大型 PowerPoint 演示文稿（large.pptx），它包含一个 1.5 GB 的视频文件。加载演示文稿的标准方法在以下 PHP 代码中描述：

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

但是这种方法消耗了大约 1.6 GB 的临时内存。 

### **将大型演示文稿作为 BLOB 加载**

通过涉及 BLOB 的过程，您可以在使用较少内存的情况下加载大型演示文稿。以下 PHP 代码描述了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **更改临时文件的文件夹**

使用 BLOB 过程时，您的计算机将在临时文件的默认文件夹中创建临时文件。如果您希望将临时文件保存在其他文件夹中，可以使用 `TempFilesRootPath` 更改存储设置：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="信息" color="info" %}}

使用 `TempFilesRootPath` 时，Aspose.Slides 不会自动创建存储临时文件的文件夹。您必须手动创建该文件夹。 

{{% /alert %}}
---
title: 管理 OLE
type: docs
weight: 40
url: /zh/php-java/manage-ole/
keywords:
- 添加 OLE
- 嵌入 OLE
- 添加对象
- 嵌入对象
- 嵌入文件
- 链接对象
- 对象链接与嵌入
- OLE 对象
- PowerPoint 
- 演示文稿
- PHP
- Java
- 通过 Java 的 Aspose.Slides for PHP
description: 在 PHP 中将 OLE 对象添加到 PowerPoint 演示文稿
---

{{% alert color="primary" %}} 

OLE (对象链接与嵌入) 是一种 Microsoft 技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入放置到另一个应用程序中。

{{% /alert %}} 

考虑在 MS Excel 中创建的图表。该图表被放置在 PowerPoint 幻灯片中。该 Excel 图表被视为 OLE 对象。

- OLE 对象可能会显示为图标。在这种情况下，当您双击图标时，该图表会在其关联的应用程序（Excel）中打开，或者系统会要求您选择一个应用程序来打开或编辑该对象。
- OLE 对象可能会显示实际内容，例如图表的内容。在这种情况下，图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 应用程序中修改图表的数据。

[Aspose.Slides for PHP 通过 Java](https://products.aspose.com/slides/php-java/) 允许您将 OLE 对象作为 OLE 对象框插入到幻灯片中（[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)）。

## **将 OLE 对象框添加到幻灯片**
假设您已经在 Microsoft Excel 中创建了一个图表，并想使用 Aspose.Slides for PHP 通过 Java 将该图表嵌入到幻灯片中的 OLE 对象框中，您可以这样做：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 使用其索引获取幻灯片的引用。
1. 打开包含 Excel 图表对象的 Excel 文件并将其保存到 `MemoryStream`。
1. 将 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame) 添加到包含字节数组及关于 OLE 对象的其他信息的幻灯片中。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们使用 Aspose.Slides for PHP 通过 Java 将 Excel 文件中的图表作为 OLE 对象框添加到幻灯片中。
**注意**，[IOleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IOleEmbeddedDataInfo) 构造函数的第二个参数是可嵌入对象的扩展名。此扩展名允许 PowerPoint 正确解释文件类型并选择正确的应用程序来打开此 OLE 对象。

```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 访问第一个幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 加载 Excel 文件到流中
    $fs = new Java("java.io.FileInputStream", "book1.xlsx");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $mstream = new Java("java.io.ByteArrayOutputStream");
    $buf = $Array->newInstance($Byte, 4096);
    while (true) {
      $bytesRead = $fs->read($buf, 0, $Array->getLength($buf));
      if ($bytesRead <= 0) {
        break;
      }
      $mstream->write($buf, 0, $bytesRead);
    } 
    $fs->close();
    # 创建用于嵌入的数据对象
    $dataInfo = new OleEmbeddedDataInfo($mstream->toByteArray(), "xlsx");
    $mstream->close();
    # 添加 Ole 对象框形状
    $oleObjectFrame = $sld->getShapes()->addOleObjectFrame(0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $dataInfo);
    # 将 PPTX 文件写入磁盘
    $pres->save("OleEmbed_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **访问 OLE 对象框**
如果一个 OLE 对象已经嵌入到幻灯片中，您可以轻松找到或访问该对象：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 使用其索引获取幻灯片的引用。
1. 访问 OLE 对象框形状。

   在我们的示例中，我们使用了先前创建的 PPTX，它在第一个幻灯片上仅有一个形状。然后我们将该对象 *强制转换* 为 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)。这是要访问的 OLE 对象框。
1. 一旦访问了 OLE 对象框，您可以对其执行任何操作。

在下面的示例中，访问了一个 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象），然后其文件数据被写入到 Excel 文件中。

```php
  # 将 PPTX 加载到 Presentation 对象中
  $pres = new Presentation("AccessingOLEObjectFrame.pptx");
  try {
    # 访问第一个幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 将形状强制转换为 OleObjectFrame
    $oleObjectFrame = $sld->getShapes()->get_Item(0);
    # 读取 OLE 对象并将其写入磁盘
    if (!java_is_null($oleObjectFrame)) {
      # 获取嵌入文件数据
      $data = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileData();
      # 获取嵌入文件扩展名
      $fileExtention = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension();
      # 创建保存提取文件的路径
      $extractedPath = "excelFromOLE_out" . $fileExtention;
      # 保存提取的数据
      $fstr = new Java("java.io.FileOutputStream", $extractedPath);
      $Array = new java_class("java.lang.reflect.Array");
      try {
        $fstr->write($data, 0, $Array->getLength($data));
      } finally {
        $fstr->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **更改 OLE 对象数据**

如果 OLE 对象已经嵌入到幻灯片中，您可以轻松访问该对象并以这种方式修改其数据：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例打开所需的包含嵌入 OLE 对象的演示文稿。
1. 通过其索引获取幻灯片的引用。 
1. 访问 OLE 对象框形状。

   在我们的示例中，我们使用了先前创建的 PPTX，该 PPTX 在第一个幻灯片上仅有一个形状。然后我们将该对象 *强制转换* 为 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)。这是要访问的 OLE 对象框。
1. 一旦访问了 OLE 对象框，您可以对其执行任何操作。
1. 创建工作簿对象并访问 OLE 数据。
1. 访问所需的工作表并修改数据。
1. 将更新后的工作簿保存在流中。
1. 将 OLE 对象数据从流数据更改。

在下面的示例中，访问了一个 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象），然后其文件数据被修改以更改图表数据：

```php
  $pres = new Presentation("ChangeOLEObjectData.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $ole = null;
    # 遍历所有形状以寻找 Ole 框
    foreach($slide->getShapes() as $shape) {
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $ole = $shape;
      }
    }
    if (!java_is_null($ole)) {
      $msln = new ByteArrayInputStream($ole->getEmbeddedData()->getEmbeddedFileData());
      try {
        # 在工作簿中读取对象数据
        $Wb = new Workbook($msln);
        $msout = new Java("java.io.ByteArrayOutputStream");
        try {
          # 修改工作簿数据
          $Wb->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
          $Wb->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
          $Wb->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
          $Wb->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);
          $so1 = new OoxmlSaveOptions(SaveFormat::XLSX);
          $Wb->save($msout, $so1);
          # 更改 Ole 框对象数据
          $newData = new OleEmbeddedDataInfo($msout->toByteArray(), $ole->getEmbeddedData()->getEmbeddedFileExtension());
          $ole->setEmbeddedData($newData);
        } finally {
          if (!java_is_null($msout)) {
            $msout->close();
          }
        }
      } finally {
        if (!java_is_null($msln)) {
          $msln->close();
        }
      }
    }
    $pres->save("OleEdit_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 在幻灯片中嵌入其他文件类型

除了 Excel 图表，Aspose.Slides for PHP 通过 Java 还允许您在幻灯片中嵌入其他类型的文件。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入到幻灯片中。当用户双击插入的对象时，该对象会自动在相关程序中启动，或者用户将被引导选择合适的程序来打开该对象。

以下 PHP 代码展示了如何在幻灯片中嵌入 HTML 和 ZIP：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.html"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $htmlBytes = $bytes;

    $dataInfoHtml = new OleEmbeddedDataInfo($htmlBytes, "html");
    $oleFrameHtml = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $dataInfoHtml);
    $oleFrameHtml->setObjectIcon(true);
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $zipBytes = $bytes;

    $dataInfoZip = new OleEmbeddedDataInfo($zipBytes, "zip");
    $oleFrameZip = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $dataInfoZip);
    $oleFrameZip->setObjectIcon(true);
    $pres->save("embeddedOle.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 为嵌入对象设置文件类型

在制作演示文稿时，您可能需要用新对象替换旧的 OLE 对象。或者您可能需要用支持的 OLE 对象替换不支持的对象。

Aspose.Slides for PHP 通过 Java 允许您设置嵌入对象的文件类型。这样，您就可以更改 OLE 框数据或其扩展名。

以下 Java 代码展示了如何为嵌入的 OLE 对象设置文件类型：

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    echo("当前嵌入数据扩展名为: " . $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension());
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $oleObjectFrame->setEmbeddedData(new OleEmbeddedDataInfo($bytes, "zip"));

    $pres->save("embeddedChanged.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 为嵌入对象设置图标图像和标题

在您嵌入 OLE 对象后，会自动添加包含图标图像和标题的预览。预览是用户在访问或打开 OLE 对象之前看到的内容。

如果您想使用特定的图像和文本作为预览中的元素，可以使用 Aspose.Slides for PHP 通过 Java 设置图标图像和标题。

以下 PHP 代码展示了如何为嵌入对象设置图标图像和标题：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    $oleImage;
    $image = Images->fromFile("image.png");
    try {
      $oleImage = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $oleObjectFrame->setSubstitutePictureTitle("我的标题");
    $oleObjectFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleObjectFrame->setObjectIcon(false);
    $pres->save("embeddedOle-newImage.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **防止 OLE 对象框被调整大小和重新定位**

在您将链接的 OLE 对象添加到演示文稿幻灯片后，当您在 PowerPoint 中打开演示文稿时，您可能会看到一条消息，询问您是否要更新链接。单击“更新链接”按钮可能会改变 OLE 对象框的大小和位置，因为 PowerPoint 更新源自链接 OLE 对象的数据并刷新对象预览。要防止 PowerPoint 提示更新对象数据，请将 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 类的 `setUpdateAutomatic` 方法设置为 `false`：

```php
$oleObjectFrame->setUpdateAutomatic(false);
```

## 提取嵌入文件

Aspose.Slides for PHP 通过 Java 允许您以 OLE 对象的形式提取嵌入在幻灯片中的文件，步骤如下：

1. 创建包含您打算提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 遍历演示文稿中的所有形状，访问 [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe) 形状。
3. 从 OLE 对象框访问嵌入文件的数据，并将其写入磁盘。

以下 PHP 代码展示了如何提取以 OLE 对象形式嵌入在幻灯片中的文件：

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($index = 0; $index < java_values($slide->getShapes()->size()) ; $index++) {
      $shape = $slide->getShapes()->get_Item($index);
      $oleFrame = $shape;
      if (!java_is_null($oleFrame)) {
        $data = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $extension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
        # 保存提取的数据
        $fstr = new Java("java.io.FileOutputStream", "oleFrame" . $index . $extension);
        $Array = new java_class("java.lang.reflect.Array");
        try {
          $fstr->write($data, 0, $Array->getLength($data));
        } finally {
          $fstr->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
---
title: 使用 PHP 管理演示文稿中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh/php-java/manage-ole/
keywords:
- OLE 对象
- 对象链接与嵌入
- 添加 OLE
- 嵌入 OLE
- 添加对象
- 嵌入对象
- 添加文件
- 嵌入文件
- 链接对象
- 链接文件
- 更改 OLE
- OLE 图标
- OLE 标题
- 提取 OLE
- 提取对象
- 提取文件
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 优化在 PowerPoint 和 OpenDocument 文件中的 OLE 对象管理，实现 OLE 内容的无缝嵌入、更新和导出。"
---
## **介绍**

{{% alert color="info" title="Note" %}}
OLE（对象链接与嵌入）是 Microsoft 的技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入方式放置到另一个应用程序中。 
{{% /alert %}} 

考虑一个在 Microsoft Excel 中创建的图表。该图表随后被放置在 PowerPoint 幻灯片中。该 Excel 图表被视为 OLE 对象。 

- OLE 对象可以以图标形式出现。在这种情况下，双击图标时，图表将在其关联的应用程序（Excel）中打开，或会提示选择一个应用程序来打开或编辑该对象。  
- OLE 对象也可以显示其实际内容，例如图表的内容。在这种情况下，图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 中修改图表的数据。  

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) 允许您将 OLE 对象插入到幻灯片中作为 OLE 对象框（[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)）。 

## **向幻灯片添加 OLE 对象框**

假设您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for PHP via Java 将其嵌入到幻灯片中作为 OLE 对象框，您可以按以下方式操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 将 Excel 文件读取为字节数组。  
4. 将包含字节数组和 OLE 对象其他信息的 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 添加到幻灯片。  
5. 将修改后的演示文稿写入为 PPTX 文件。  

在下面的示例中，我们使用 Aspose.Slides for PHP via Java 将 Excel 文件中的图表添加到幻灯片中作为 OLE 对象框。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) 构造函数将可嵌入对象的扩展名作为第二个参数。此扩展名使 PowerPoint 能够正确解释文件类型并选择正确的应用程序打开该 OLE 对象。  

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// 为 OLE 对象准备数据。
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// 向幻灯片添加 OLE 对象框。
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **添加链接的 OLE 对象框**

Aspose.Slides for PHP via Java 允许您添加一个 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 而不嵌入数据，仅提供指向文件的链接。

下面的 PHP 代码演示如何向幻灯片添加一个带有链接的 Excel 文件的 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)：

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// 添加一个带有链接 Excel 文件的 OLE 对象框。
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **访问 OLE 对象框**

如果 OLE 对象已经嵌入到幻灯片中，您可以按以下方式轻松找到或访问它：

1. 通过创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例来加载包含嵌入 OLE 对象的演示文稿。  
2. 使用索引获取幻灯片的引用。  
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 形状。在我们的示例中，使用了先前创建的仅在第一张幻灯片上具有一个形状的 PPTX。  
4. 一旦访问到 OLE 对象框，您可以对其执行任何操作。  

下面的示例演示了访问一个 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象）及其文件数据。  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // 获取嵌入的文件数据。
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // 获取嵌入文件的扩展名。
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **访问链接的 OLE 对象框属性**

Aspose.Slides 允许您访问链接的 OLE 对象框属性。

下面的 PHP 代码演示如何检查 OLE 对象是否为链接，并获取链接文件的路径：

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // 检查 OLE 对象是否为链接。
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // 打印链接文件的完整路径。
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // 如存在，打印链接文件的相对路径。
        // 仅 PPT 演示文稿可以包含相对路径。
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **更改 OLE 对象数据**

{{% alert color="info" title="Note" %}}
在本节中，下面的代码示例使用 [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/)。  
{{% /alert %}}

如果 OLE 对象已经嵌入到幻灯片中，您可以按以下方式轻松访问该对象并修改其数据：

1. 通过创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例来加载包含嵌入 OLE 对象的演示文稿。  
2. 通过索引获取幻灯片的引用。  
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 形状。在我们的示例中，使用了先前创建的在第一张幻灯片上仅有一个形状的 PPTX。  
4. 一旦访问到 OLE 对象框，您可以对其执行任何操作。  
5. 创建一个 `Workbook` 对象并访问 OLE 数据。  
6. 访问所需的 `Worksheet` 并修改数据。  
7. 在流中保存更新后的 `Workbook`。  
8. 从流中更改 OLE 对象数据。  

下面的示例演示了访问一个 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象），并修改其文件数据以更新图表数据。  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // 将 OLE 对象数据读取为 Workbook 对象。
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // 修改工作簿数据。
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // 更改 OLE 框对象的数据。
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **在幻灯片中嵌入其他文件类型**

除了 Excel 图表，Aspose.Slides for PHP via Java 还允许您将其他类型的文件嵌入到幻灯片中。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。当用户双击插入的对象时，它会自动在相应的程序中打开，或提示用户选择合适的程序来打开它。  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **为嵌入对象设置文件类型**

在处理演示文稿时，您可能需要将旧的 OLE 对象替换为新的，或将不受支持的 OLE 对象替换为受支持的对象。Aspose.Slides for PHP via Java 允许您为嵌入对象设置文件类型，从而更新 OLE 框的数据或其扩展名。  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// 将文件类型更改为 ZIP。
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **为嵌入对象设置图标图像和标题**

在嵌入 OLE 对象后，会自动添加由图标图像组成的预览。该预览是用户在访问或打开 OLE 对象之前看到的内容。如果您想使用特定的图像和文本作为预览元素，可以使用 Aspose.Slides for PHP via Java 设置图标图像和标题。  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// 向演示文稿资源添加图像。
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// 设置 OLE 预览的标题和图像。
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **防止 OLE 对象框被重新大小调整和重新定位**

在向演示文稿幻灯片添加链接的 OLE 对象后，打开 PowerPoint 时可能会看到一个提示更新链接的消息。单击 “Update Links” 按钮可能会更改 OLE 对象框的大小和位置，因为 PowerPoint 会从链接的 OLE 对象更新数据并刷新对象预览。为防止 PowerPoint 提示更新对象数据，请对 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 类调用 [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) 方法并传入 `false`：  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **提取嵌入的文件**

Aspose.Slides for PHP via Java 允许您按以下方式提取嵌入在幻灯片中作为 OLE 对象的文件：

1. 创建一个包含您要提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类实例。  
2. 遍历演示文稿中的所有形状并访问 [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 形状。  
3. 从 OLE 对象框中访问嵌入文件的数据并写入磁盘。  

下面的 PHP 代码演示如何提取幻灯片中作为 OLE 对象嵌入的文件：  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **FAQ**

**OLE 内容在导出为 PDF/图像时会被渲染吗？**

幻灯片上可见的内容会被渲染——即图标/替代图像（预览）。“实时” OLE 内容在渲染过程中不会执行。如有需要，请设置自己的预览图像，以确保在导出的 PDF 中呈现预期的外观。  

若要将嵌入的文件也保留为 PDF 附件，请调用 [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) 并传入 `true`。此选项默认是禁用的。有关示例和检查附件的说明，请参阅 [保留嵌入的 OLE 文件为 PDF 附件](/slides/zh/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)。  

**如何锁定幻灯片上的 OLE 对象，以防用户在 PowerPoint 中移动/编辑它？**

锁定形状：Aspose.Slides 提供形状级别的锁定功能。这不是加密，但能够有效防止意外编辑和移动。  

**在 PPTX 格式中，链接的 OLE 对象的相对路径会被保留吗？**

在 PPTX 中不存在“相对路径”信息——仅有完整路径。相对路径仅在旧的 PPT 格式中出现。为实现可移植性，建议使用可靠的绝对路径/可访问的 URI 或直接嵌入。
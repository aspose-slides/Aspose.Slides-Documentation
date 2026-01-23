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
description: "使用 Aspose.Slides for PHP via Java 优化 PowerPoint 和 OpenDocument 文件中的 OLE 对象管理。无缝嵌入、更新和导出 OLE 内容。"
---

{{% alert color="primary" %}} 

OLE（对象链接与嵌入）是 Microsoft 的一项技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入的方式放置到另一个应用程序中。 

{{% /alert %}} 

考虑在 MS Excel 中创建的图表。该图表随后放置在 PowerPoint 幻灯片中。该 Excel 图表即为 OLE 对象。 

- OLE 对象可以显示为图标。在此情况下，双击图标会在其关联的应用程序（Excel）中打开图表，或提示您选择用于打开或编辑对象的应用程序。 
- OLE 对象也可以直接显示其实际内容，例如图表的内容。此时，图表在 PowerPoint 中被激活，图表界面加载，您可以在 PowerPoint 中修改图表数据。 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) 允许您将 OLE 对象插入幻灯片作为 OLE 对象框（[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)）。 

## **向幻灯片添加 OLE 对象框**

假设您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for PHP via Java 将其嵌入到幻灯片中作为 OLE 对象框，您可以按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 将 Excel 文件读取为字节数组。  
1. 将包含字节数组以及 OLE 对象其他信息的 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 添加到幻灯片中。  
1. 将修改后的演示文稿写入为 PPTX 文件。  

下面的示例演示了我们如何使用 Aspose.Slides for PHP via Java 将 Excel 文件中的图表作为 OLE 对象框添加到幻灯片中。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) 构造函数接受可嵌入对象的扩展名作为第二参数。此扩展名使 PowerPoint 能够正确解释文件类型并选择正确的应用程序打开该 OLE 对象。  
```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


### **添加链接的 OLE 对象框**

Aspose.Slides for PHP via Java 允许您添加一个 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)，仅使用文件链接而不嵌入数据。  

以下 PHP 代码展示了如何将带有链接的 Excel 文件的 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 添加到幻灯片中：  
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// 添加一个带有链接的 Excel 文件的 OLE 对象框。
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **访问 OLE 对象框**

如果幻灯片中已经嵌入了 OLE 对象，您可以通过以下方式轻松查找或访问它：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例以加载包含嵌入 OLE 对象的演示文稿。  
2. 使用索引获取幻灯片的引用。  
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 形状。示例中，我们使用了之前创建的仅在第一张幻灯片上包含一个形状的 PPTX。  
4. 一旦访问到 OLE 对象框，您即可对其执行任何操作。  

下面的示例演示了如何访问 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象）及其文件数据。  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // 获取嵌入文件的数据。
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // 获取嵌入文件的扩展名。
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```


### **访问链接的 OLE 对象框属性**

Aspose.Slides 允许您访问链接的 OLE 对象框属性。  

以下 PHP 代码展示了如何检查 OLE 对象是否为链接以及获取链接文件的路径：  
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

        // 如果存在，打印链接文件的相对路径。
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

{{% alert color="primary" %}} 

本节中的代码示例使用了 [Aspose.Cells for PHP via Java](/cells/php-java/)。 

{{% /alert %}}

如果幻灯片中已经嵌入了 OLE 对象，您可以按以下方式轻松访问并修改其数据：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例以加载包含嵌入 OLE 对象的演示文稿。  
2. 通过索引获取幻灯片的引用。  
3. 访问 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 形状。示例中，我们使用了之前创建的仅在第一张幻灯片上有一个形状的 PPTX。  
4. 一旦访问到 OLE 对象框，您即可对其执行任何操作。  
5. 创建一个 `Workbook` 对象并访问 OLE 数据。  
6. 访问所需的 `Worksheet` 并修改数据。  
7. 将更新后的 `Workbook` 保存到流中。  
8. 从流中更改 OLE 对象数据。  

下面的示例演示了如何访问嵌入在幻灯片中的 OLE 对象框（Excel 图表对象），并修改其文件数据以更新图表数据。  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // 将 OLE 对象数据读取为 Workbook 对象。
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // 修改 Workbook 数据。
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // 更改 OLE 框对象数据。
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **在幻灯片中嵌入其他文件类型**

除了 Excel 图表外，Aspose.Slides for PHP via Java 还允许您将其他类型的文件嵌入幻灯片。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。当用户双击插入的对象时，它会自动在相应程序中打开，或提示用户选择适当的程序打开。  

以下 PHP 代码展示了如何将 HTML 和 ZIP 嵌入到幻灯片中：  
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


## **设置嵌入对象的文件类型**

在处理演示文稿时，您可能需要将旧的 OLE 对象替换为新的，或将不受支持的 OLE 对象替换为受支持的对象。Aspose.Slides for PHP via Java 允许您设置嵌入对象的文件类型，从而更新 OLE 框数据或其扩展名。  

以下 PHP 代码展示了如何将嵌入 OLE 对象的文件类型设置为 `zip`：  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// 将文件类型更改为 ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **设置嵌入对象的图标图像和标题**

嵌入 OLE 对象后，会自动添加一个由图标图像构成的预览。此预览是用户在访问或打开 OLE 对象之前看到的内容。如果您想使用特定的图像和文字作为预览元素，可以使用 Aspose.Slides for PHP via Java 设置图标图像和标题。  

以下 PHP 代码展示了如何为嵌入对象设置图标图像和标题：  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// 向演示文稿资源添加图像。
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// 为 OLE 预览设置标题和图像。
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **防止 OLE 对象框被重新定位和重新调整大小**

在向演示文稿幻灯片添加链接的 OLE 对象后，打开 PowerPoint 时可能会出现提示您更新链接的消息。点击“更新链接”按钮可能会因为 PowerPoint 从链接的 OLE 对象更新数据并刷新对象预览而改变 OLE 对象框的大小和位置。为防止 PowerPoint 提示更新对象数据，请将 [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 类的 `setUpdateAutomatic` 方法设置为 `false`：  
```php
$oleFrame->setUpdateAutomatic(false);
```


## **提取嵌入文件**

Aspose.Slides for PHP via Java 允许您按以下方式提取嵌入在幻灯片中作为 OLE 对象的文件：

1. 创建一个包含要提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类实例。  
2. 循环遍历演示文稿中的所有形状，访问 [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) 形状。  
3. 从 OLE 对象框中获取嵌入文件的数据并写入磁盘。  

以下 PHP 代码展示了如何提取幻灯片中作为 OLE 对象嵌入的文件：  
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


## **常见问题**

**在将幻灯片导出为 PDF/图像时，OLE 内容会被渲染吗？**

幻灯片上可见的内容会被渲染——即图标/替代图像（预览）。“实时” OLE 内容在渲染过程中不会执行。如有需要，可设置自己的预览图像，以确保导出 PDF 时的外观符合预期。  

**如何锁定幻灯片上的 OLE 对象，使用户无法在 PowerPoint 中移动/编辑它？**

锁定形状：Aspose.Slides 提供形状级别的锁定功能。这不是加密，但能有效防止意外编辑和移动。  

**在 PPTX 格式中，链接的 OLE 对象的相对路径会被保留吗？**

在 PPTX 中不存储“相对路径”信息——只有完整路径。相对路径仅在旧的 PPT 格式中出现。为实现可移植性，建议使用可靠的绝对路径/可访问的 URI 或将对象嵌入。
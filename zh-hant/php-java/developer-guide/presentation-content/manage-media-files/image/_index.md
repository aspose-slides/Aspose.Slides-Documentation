---
title: 使用 PHP 優化簡報中的影像管理
linktitle: 管理影像
type: docs
weight: 10
url: /zh-hant/php-java/image/
keywords:
- 新增影像
- 新增圖片
- 新增點陣圖
- 取代影像
- 取代圖片
- 來自網路
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- 新增 EMF
- 新增 WMF
- 新增 TIFF
- PowerPoint
- OpenDocument
- 簡報
- EMF
- SVG
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 簡化 PowerPoint 與 OpenDocument 中的影像管理，提升效能並自動化工作流程。"
---
## **簡介**

圖片讓簡報更具吸引力且更有趣味。在 Microsoft PowerPoint 中，您可以從檔案、網路或其他位置將圖片插入投影片。類似地，Aspose.Slides 允許您透過不同方式將圖片加入簡報的投影片中。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免費的轉換工具——[JPEG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓使用者可以快速從圖片建立簡報。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
如果您想將圖片作為框架物件加入——尤其是計畫使用標準格式選項來調整大小、添加效果等——請參閱 [Picture Frame](/slides/zh-hant/php-java/picture-frame/)。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
您可以操作涉及圖片和 PowerPoint 簡報的輸入/輸出，以將圖片從一種格式轉換為另一種格式。請參閱以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/php-java/conversion/image-to-jpg/)；轉換 [JPG to image](https://products.aspose.com/slides/zh-hant/php-java/conversion/jpg-to-image/)；轉換 [JPG to PNG](https://products.aspose.com/slides/zh-hant/php-java/conversion/jpg-to-png/)、轉換 [PNG to JPG](https://products.aspose.com/slides/zh-hant/php-java/conversion/png-to-jpg/)；轉換 [PNG to SVG](https://products.aspose.com/slides/zh-hant/php-java/conversion/png-to-svg/)、轉換 [SVG to PNG](https://products.aspose.com/slides/zh-hant/php-java/conversion/svg-to-png/)。 
{{% /alert %}}

Aspose.Slides 支援以下常見格式的圖片操作：JPEG、PNG、GIF 等等。

## **將本機儲存的圖片加入投影片**

您可以將電腦上的一張或多張圖片加入簡報的投影片。本範例程式碼示範如何將圖片加入投影片：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **將 Web 圖片加入投影片**

如果您想加入的圖片在電腦上找不到，您可以直接從網路將圖片加入投影片。

以下範例程式碼示範如何從 Web 加入圖片至投影片：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **將圖片加入投影片母版**

投影片母版是最高階的投影片，負責儲存與控制其下所有投影片的資訊（佈景主題、版面配置等）。因此，當您將圖片加入投影片母版時，該圖片會出現在該母版所屬的所有投影片上。

以下 Java 範例程式碼示範如何將圖片加入投影片母版：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **將圖片設定為投影片背景**

您可能會想將圖片設定為單一投影片或多張投影片的背景。此情況下，請參考[設定圖片為投影片背景](/slides/zh-hant/php-java/presentation-background/#set-an-image-as-a-slide-background)。

## **將 SVG 新增至簡報**
您可以使用屬於 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 類別的 [addPictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addpictureframe/) 方法，將任何圖片插入簡報。

若要根據 SVG 圖片建立圖像物件，可依照下列步驟：

1. 建立 SvgImage 物件以插入至 ImageShapeCollection  
2. 從 ISvgImage 建立 PPImage 物件  
3. 使用 PPImage 類別建立 PictureFrame 物件  

以下範例程式碼示範如何實作上述步驟，將 SVG 圖片加入簡報：

```php
  # 實例化表示 PPTX 檔案的 Presentation 類別
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **將 SVG 轉換為形狀集合**
Aspose.Slides 將 SVG 轉換為形狀集合的功能與 PowerPoint 處理 SVG 圖片的功能相似：

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 類別的其中一個 [addGroupShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addgroupshape/) 方法重載提供，該方法的第一個參數接受 [SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/) 物件。

以下範例程式碼示範如何使用上述方法將 SVG 檔案轉換為形狀集合：

```php
  # 建立新的簡報
  $presentation = new Presentation();
  try {
    # 讀取 SVG 檔案內容
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # 建立 SvgImage 物件
    $svgImage = new SvgImage($svgContent);
    # 取得投影片尺寸
    $slideSize = $presentation->getSlideSize()->getSize();
    # 將 SVG 圖片轉換為形狀群組，並縮放至投影片尺寸
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # 以 PPTX 格式儲存簡報
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **將圖片以 EMF 形式加入投影片**
Aspose.Slides for PHP via Java 允許您從 Excel 工作表產生 EMF 圖片，並搭配 Aspose.Cells 將 EMF 圖片加入投影片。

以下範例程式碼示範如何完成上述工作：

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # 將工作簿儲存至串流
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **取代影像集合中的圖片**

Aspose.Slides 讓您能取代簡報影像集合中儲存的圖片（包含投影片形狀使用的圖片）。本節說明多種更新集合中圖片的方法。API 提供簡單的方法，讓您使用原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 實例，或是已存在於集合中的其他圖片來取代圖片。

請依照下列步驟操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別載入包含圖片的簡報檔案。  
2. 從檔案載入新圖片至位元組陣列。  
3. 使用位元組陣列將目標圖片取代為新圖片。  
4. 在第二種方法中，將圖片載入至 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 物件，並以該物件取代目標圖片。  
5. 在第三種方法中，使用已存在於簡報影像集合中的圖片取代目標圖片。  
6. 將修改後的簡報寫出為 PPTX 檔案。  

```php
// 實例化表示簡報檔案的 Presentation 類別。
$presentation = new Presentation("sample.pptx");
try {
    // 第一種方式。
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // 第二種方式。
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // 第三種方式。
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // 將簡報儲存至檔案。
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
使用 Aspose FREE [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆為文字製作動畫、從文字建立 GIF 等。 
{{% /alert %}}

## **常見問題**

**插入後原始圖片解析度是否保持不變？**  
是的。來源像素會被保留，但最終顯示效果取決於 [picture](/slides/zh-hant/php-java/picture-frame/) 在投影片上的縮放方式以及儲存時是否套用了壓縮。

**如何一次取代多張投影片中的相同標誌？**  
將標誌放置於母版投影片或版面配置上，並在影像集合中取代它——所有使用該資源的元素都會同步更新。

**插入的 SVG 能否轉換為可編輯的形狀？**  
可以。您可以將 SVG 轉換為形狀群組，之後各個部件即可透過標準形狀屬性進行編輯。

**如何一次為多張投影片設定相同的背景圖片？**  
在母版投影片或相關版面配置上[指派圖片為背景](/slides/zh-hant/php-java/presentation-background/)，使用該母版/版面的所有投影片都會繼承該背景。

**如何避免因大量圖片導致簡報檔案體積暴增？**  
重複使用單一圖片資源、選擇適當解析度、儲存時套用壓縮，並在適當情況下將重複圖形放在母版上。
---
title: 在 PHP 中為簡報添加浮水印
linktitle: 浮水印
type: docs
weight: 40
url: /zh-hant/php-java/watermark/
keywords:
- 浮水印
- 文字浮水印
- 圖片浮水印
- 新增浮水印
- 變更浮水印
- 移除浮水印
- 刪除浮水印
- 新增浮水印至 PPT
- 新增浮水印至 PPTX
- 新增浮水印至 ODP
- 從 PPT 移除浮水印
- 從 PPTX 移除浮水印
- 從 ODP 移除浮水印
- 從 PPT 刪除浮水印
- 從 PPTX 刪除浮水印
- 從 ODP 刪除浮水印
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中管理 PowerPoint 與 OpenDocument 簡報的文字與圖片浮水印，以標示草稿、機密資訊、版權等。"
---
## **簡介**

**在簡報中，浮水印是一種文字或圖像印記，用於單張投影片或整份簡報的所有投影片。** 通常，浮水印用於表示簡報是草稿（例如「Draft」浮水印）、包含機密資訊（例如「Confidential」浮水印）、說明屬於哪家公司（例如「Company Name」浮水印）、辨識簡報作者等。浮水印透過表明簡報不應被複製，協助防止版權侵害。浮水印同時支援 PowerPoint 與 OpenOffice 的簡報格式。 在 Aspose.Slides 中，您可以為 PowerPoint PPT、PPTX 與 OpenOffice ODP 檔案格式加入浮水印。

在[**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/php-java/)，有多種方式可以在 PowerPoint 或 OpenOffice 文件中建立浮水印並修改其設計與行為。共通點是，若要加入文字浮水印，應使用[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)類別；若要加入圖片浮水印，則使用[PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/)類別或以圖片填滿浮水印形狀。`PictureFrame`實作了[Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/)類別，允許您使用形狀物件的所有彈性設定。由於`ITextFrame`不是形狀且其設定受限，會將其包裝成[Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/)物件。

浮水印的套用方式有兩種：套用於單一投影片或套用於所有簡報投影片。使用 Slide Master 可將浮水印套用至所有投影片──浮水印被加入 Slide Master，於該處完成設計，並套用至所有投影片，同時不影響個別投影片對浮水印的修改權限。

通常認為浮水印不應讓其他使用者編輯。為防止浮水印（或其父形狀）被編輯，Aspose.Slides 提供形狀鎖定功能。特定形狀可以在普通投影片或 Slide Master 上鎖定。當浮水印形狀在 Slide Master 上被鎖定時，所有投影片的浮水印皆會被鎖定。

您可以為浮水印設定名稱，未來若需刪除，只要依名稱在投影片的形狀集合中找到即可。

浮水印的設計方式多樣；然而，浮水印通常具備置中對齊、旋轉、前置等共通特徵。以下範例將說明如何使用這些特性。

## **文字浮水印**

### **將文字浮水印新增至投影片**

若要在 PPT、PPTX 或 ODP 中加入文字浮水印，您可以先在投影片上加入形狀，然後在該形狀上加入文字框。文字框由[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)類別表示。此類別未繼承自[Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/)，而[Shape]提供了彈性定位浮水印的廣泛屬性。因此，將[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)物件包裝在[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)物件中。要在形狀上加入浮水印文字，請使用[addTextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/#addTextFrame)方法，如下所示。

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="See also" %}} 
- [如何使用 TextFrame 類別](/slides/zh-hant/php-java/text-formatting/)
{{% /alert %}}

### **將文字浮水印新增至簡報**

如果要將文字浮水印加入整個簡報（即一次套用至所有投影片），請將其加入[MasterSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/)。其餘邏輯與在單一投影片上加入浮水印相同──建立[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)物件，然後使用[addTextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/#addTextFrame)方法加入浮水印。

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="See also" %}} 
- [如何使用投影片母片](/slides/zh-hant/php-java/slide-master/)
{{% /alert %}}

### **設定浮水印形狀透明度**

預設情況下，矩形形狀會套用填充與線條顏色。以下程式碼可將形狀設定為透明。

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **設定文字浮水印的字型**

您可以如下面範例所示變更文字浮水印的字型。

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **設定浮水印文字顏色**

要設定浮水印文字的顏色，請使用以下程式碼：

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **將文字浮水印置中**

可以將浮水印在投影片上置中，做法如下：

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

下圖顯示最終結果。

![文字浮水印](text_watermark.png)

## **圖片浮水印**

### **將圖片浮水印新增至簡報**

要在簡報投影片上加入圖片浮水印，您可以執行以下操作：

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **防止浮水印被編輯**

若需防止浮水印被編輯，請對形狀使用[AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/#getAutoShapeLock)方法。透過此屬性，您可以保護形狀不被選取、調整大小、重新定位、與其他元素群組、鎖定文字編輯等：

```php
// 鎖定浮水印形狀以防止被修改
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **將浮水印置於最前端**

在 Aspose.Slides 中，可透過[ShapeCollection.reorder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#reorder)方法設定形狀的 Z 序。您需要從簡報投影片清單呼叫此方法，並傳入形狀參考與其排序號碼。如此即可將形狀移至最前端或最底層。此功能在需要將浮水印放在簡報最前方時特別有用：

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **設定浮水印旋轉角度**

以下程式碼示範如何調整浮水印的旋轉，使其呈對角線方式分布於投影片：

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **為浮水印設定名稱**

Aspose.Slides 允許您為形狀設定名稱。透過形狀名稱，未來可依名稱存取並修改或刪除該形狀。若要為浮水印形狀設定名稱，請呼叫[AutoShape.setName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#setName)方法：

```php
$watermarkShape->setName("watermark");
```

### **移除浮水印**

若要移除浮水印形狀，請使用[AutoShape.getName](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getName)方法在投影片形狀集合中找到它，然後將該形狀傳入[ShapeCollection.remove](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#remove)方法：

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **常見問題**

**什麼是浮水印，為何需要使用它？**

浮水印是加在投影片上的文字或圖像覆蓋層，可協助保護智慧財產、提升品牌辨識度，或防止簡報被未授權使用。

**我可以將浮水印加到簡報的所有投影片嗎？**

可以，Aspose.Slides 允許您以程式方式將浮水印加入簡報的每一張投影片。您可以遍歷所有投影片，逐一套用浮水印設定。

**如何調整浮水印的透明度？**

您可以透過修改形狀的填充設定（[getFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getfillformat/)）來調整浮水印的透明度，以確保浮水印不會分散投影片內容的注意力。

**浮水印支援哪些圖像格式？**

Aspose.Slides 支援多種圖像格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自訂文字浮水印的字體與樣式嗎？**

可以，您可依簡報設計需求選擇任意字體、大小與樣式，維持品牌一致性。

**如何變更浮水印的位置或方向？**

您可程式化地調整形狀的座標、大小與旋轉屬性，從而變更浮水印的位置或方向。
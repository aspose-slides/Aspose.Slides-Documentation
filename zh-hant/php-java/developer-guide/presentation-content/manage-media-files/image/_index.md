---
title: 使用 PHP 優化簡報中的影像管理
linktitle: 管理影像
type: docs
weight: 10
url: /zh-hant/php-java/image/
keywords:
- 新增影像
- 新增圖片
- 取代影像
- 影像集合
- 圖片框
- 連結影像
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- SVG 轉形狀
- 外部 SVG 資源
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 與 OpenDocument 簡報中新增、重複使用、連結、取代與管理點陣圖與 SVG 影像。"
---
## **簡介**

Aspose.Slides for PHP via Java 提供多種操作影像的方式，每種方式都有不同的用途。您可以將影像儲存在簡報中、在圖片框中顯示、作為投影片背景、連結至外部影像、取代共享的影像資源，或將 SVG 內容轉換為可編輯的形狀。  
本文聚焦於影像資源以及它們在整個簡報中的使用方式。若需了解針對單一圖片框的裁切、透明度、效果、拉伸以及其他格式設定，請參閱[Picture Frame](/slides/zh-hant/php-java/picture-frame/)。

## **了解影像模型**

以下 API 概念密切相關，但不可互換：

- [presentation image collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagecollection/) 用於儲存簡報使用的影像資源。使用 [ImageCollection::addImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagecollection/) 可加入影像資料並取得 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 資源。
- [picture frame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 是在投影片、版面配置或母片上顯示影像的形狀。使用 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addpictureframe/) 可將影像資源放置於投影片上。
- 投影片背景會將影像作為投影片填充的一部分，而非作為形狀。因此其行為不同於圖片框。
- [PPImage::replaceImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 會取代影像資源。如果多個簡報元素使用該資源，皆會改用新的影像。
- 將 SVG 轉換為形狀會產生可編輯的投影片形狀。轉換後，內容不再以單一圖片資源管理。

因此，一般的工作流程為：將影像資料加入影像集合，取得一個 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/)，然後在一個或多個圖片框或填充中使用該資源。

## **新增嵌入式影像**

要插入本機影像，請載入檔案、將其加入影像集合，然後建立使用返回的 `PPImage` 的圖片框。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

以此方式加入的影像會嵌入於簡報中，因此最終檔案不依賴原始影像檔案仍然可用。

### **從網路新增影像**

當影像可透過 HTTP 或 HTTPS 取得時，下載其位元組，將其加入簡報的影像集合，並以與本機影像相同的方式使用返回的影像資源。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在長時間執行的應用程式中，應重複使用適合該應用程式的 HTTP 客戶端或連線管理策略，而非不斷建立不必要的網路基礎設施。當來源未受信任時，亦請驗證遠端 URL、回應大小與內容類型。

## **跨投影片重複使用影像**

如果同一影像需要多次使用，請僅在簡報中加入一次，然後在建立其他圖片框時重複使用返回的 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/)。 這可避免重複載入相同來源資料，並明確呈現共享影像資源與其使用之間的關係。  
對於應自動出現在多張投影片上的圖形（例如公司商標），請考慮將圖片框放置於[slide master](/slides/zh-hant/php-java/slide-master/)或版面配置上，而非在每張投影片中加入等同的形狀。

## **將影像作為投影片背景使用**

背景影像會指派給投影片填色；它不會以圖片框形狀加入。當圖片需要覆蓋整個投影片背景且不應被當作一般投影片物件操作時，此方式很有用。

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

欲了解更多背景選項（包括母片與版面配置背景），請參閱[Presentation Background](/slides/zh-hant/php-java/presentation-background/)。

## **嵌入式影像與連結影像**

嵌入式影像與連結影像有不同的可移植性與檔案大小取捨：

- **Embedded image:** 影像資料儲存在簡報內部。簡報為自包含，但檔案大小會包括影像資料。
- **Linked image:** 簡報會儲存指向外部影像的路徑或 URL。這可減少簡報大小，但在開啟或渲染簡報時，外部資源必須仍可存取。

可透過 [Picture::setLinkPathLong](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picture/) 指定外部路徑或 URL，建立連結圖片，而非嵌入影像資料。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

僅在部署環境能可靠存取外部資源時才使用連結影像。對於必須離線使用或在系統間移動的簡報，嵌入式影像通常較安全。

## **處理 SVG 影像**

SVG 為向量格式，適合用於圖示、圖表及其他需在放大縮小時仍保有細節的圖形。Aspose.Slides 同時支援將 SVG 作為影像資源與可編輯投影片形狀的來源。

### **將 SVG 作為影像新增**

建立一個 [SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/)，將其加入影像集合，並在圖片框中放置產生的影像資源。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **含外部資源的 SVG 檔案**

SVG 可引用外部影像、樣式表或字型。對於此類情況，[SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/) 提供接受 [ExternalResourceResolver](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/externalresourceresolver/) 與基礎 URI 的建構子。解析器可將相對 URI 映射為允許的絕對 URI，並回傳請求資源的串流。  
解析器在 Aspose.Slides 處理 SVG 時提供外部資源，但不會將 SVG 重新寫成自包含文件。若 SVG 必須保持可移植，請將所需資源嵌入 SVG 本身，例如使用 `data:` URI 來連結影像。  
當 SVG 檔案來源未受信任時，應限制解析器可存取的協定、檔案位置與主機。網路解析器亦應套用逾時、回應大小限制與內容驗證。

### **將 SVG 轉換為可編輯形狀**

Aspose.Slides 能將 SVG 轉換為一組可編輯的投影片形狀，類似於 PowerPoint 相對的指令。

![PowerPoint Popup Menu](img_01_01.png)

使用接受 [SvgImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgimage/) 的 [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addgroupshape/) 多載以執行轉換。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

當個別向量元素需要以 PowerPoint 形狀編輯時，請使用 SVG 轉形狀的轉換。若 SVG 僅需顯示，保留為影像較為簡單，且可避免產生大量獨立形狀。

## **取代現有影像資源**

當您想取代現有影像資源時，請使用 [PPImage::replaceImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/)。此功能對於共享圖形（如商標）特別有用。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

若多個圖片框、背景、母片或版面配置使用相同的影像資源，取代該資源會同時更新所有使用處。若僅需變更單一圖片框，請為該框指派不同的影像，而非取代共享資源。  
`PPImage::replaceImage` 亦提供接受位元組陣列或其他 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 的多載。

## **實務影像管理指引**

### **控制簡報大小**

大型點陣圖可能導致簡報體積過大。請使用尺寸符合預期顯示大小的來源影像，盡可能重複使用共享影像資源，並避免嵌入相同全解析度圖形的多重副本。  
對於已置於圖片框中的點陣圖，[PictureFillFormat::compressImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/) 可依選取的解析度與裁切設定減少影像資料。此屬於圖片框處理而非影像集合管理，相關格式化操作請參閱[Picture Frame](/slides/zh-hant/php-java/picture-frame/)。

### **選擇嵌入或連結內容**

嵌入可使簡報具備可移植性，因為所有必要的影像資料皆隨檔案一起傳遞。連結能減少檔案大小，但會產生外部相依性。僅在該相依性可接受且穩定時才使用連結。

### **重複使用共享品牌資源**

對於重複使用的商標、水印或裝飾圖形，請使用單一影像資源並重複使用。若圖形屬於簡報設計而非投影片內容，請將其放置於母片或版面配置，以便被相應投影片繼承。

### **保持 SVG 資源的可移植性**

自包含的 SVG 較易於搬移且能一致呈現，較之依賴外部檔案或網路資源的 SVG。若可能，請在匯入 SVG 前嵌入所需資源。僅在需要編輯個別向量元素時才將 SVG 轉換為形狀。

### **使用現代跨平台影像 API**

對於新的 PHP via Java 程式碼，請使用 Aspose.Slides 的 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 與 [Images](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/images/) API，取代以 `java.awt.image.BufferedImage` 為基礎的舊版公開 API。請參閱[Modern API](/slides/zh-hant/php-java/modern-api/) 取得遷移指南。  
WMF 與 EMF 需要特別考量。當這些格式透過 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 傳遞時，[ImageCollection::addImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagecollection/) 會在插入前將中繼檔轉換為點陣 PNG 表示。若必須保留中繼檔資料，請改用基於串流的 [ImageCollection::addImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagecollection/) 多載。從試算表或其他產品產生 EMF 內容屬於獨立的整合工作流程，超出本文範圍。

## **常見問題**

**影像集合與圖片框之間有何差異？**

影像集合用於儲存可重複使用的影像資源。圖片框則是投影片形狀，用於顯示其中一項資源，並提供如裁切與效果等圖片專屬的格式設定。

**如何在所有位置取代相同的商標？**

若商標已以單一影像資源共享，請使用 [PPImage::replaceImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 取代該資源。若要在整份簡報中統一品牌，將商標放置於母片或版面配置亦可減少重複的投影片內容。

**為何連結影像在其他電腦上會消失？**

連結圖片依賴其外部檔案或 URL。若其他電腦無法存取該資源，連結影像就會不可用。當簡報必須自包含時，請嵌入影像。

**插入的 SVG 能否編輯成 PowerPoint 形狀？**

可以。使用 [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addgroupshape/) 轉換 SVG；產生的群組包含可編輯的投影片形狀，而非單一 SVG 圖片。

**如何讓包含大量影像的簡報保持較小體積？**

重複使用共享影像資源、避免使用過大點陣來源、在適當情況壓縮符合條件的點陣圖、將重複的品牌資源放在母片或版面配置上，且僅在外部相依性可接受時才使用連結影像。
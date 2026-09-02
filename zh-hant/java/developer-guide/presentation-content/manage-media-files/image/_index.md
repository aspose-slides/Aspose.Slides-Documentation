---
title: 使用 Java 優化簡報中的影像管理
linktitle: 管理影像
type: docs
weight: 10
url: /zh-hant/java/image/
keywords:
- 新增影像
- 新增圖片
- 取代影像
- 影像集合
- 圖片框
- 鏈結影像
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- SVG 轉圖形
- 外部 SVG 資源
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 與 OpenDocument 簡報中新增、重複使用、鏈結、取代與管理點陣圖與 SVG 影像。"
---
## **簡介**

Aspose.Slides for Java 提供了多種處理影像的方式，每種方式都有不同的用途。您可以將影像儲存在簡報中、在圖片框中顯示、用作投影片背景、鏈結至外部影像、取代共享的影像資源，或將 SVG 內容轉換為可編輯的圖形。

本文聚焦於影像資源以及它們在簡報中的使用方式。若要了解裁切、透明度、效果、拉伸等套用於單一圖片框的格式，請參考 [圖片框](/slides/zh-hant/java/picture-frame/)。

## **了解影像模型**

以下 API 概念密切相關但不可互換：

- [簡報影像集合](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagecollection/) 保存簡報中使用的影像資源。使用 [ImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imagecollection/) 可加入影像資料並取得 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 資源。
- [圖片框](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/) 是在投影片、版面或母片上顯示影像的圖形。使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/) 可將影像資源放置於投影片上。
- 投影片背景使用影像作為投影片填充的一部分，而非圖形。因此其行為不同於圖片框。
- [IPPImage.replaceImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 用於取代影像資源。若有多個簡報元素使用該資源，皆會改為使用取代後的影像。
- 將 SVG 轉換為圖形會產生可編輯的投影片圖形。轉換後，內容不再以單一圖片資源管理。

典型的工作流程如下：先將影像資料加入影像集合，取得 [IPPImage]，然後在一個或多個圖片框或填充中使用該資源。

## **新增內嵌影像**

若要插入本機影像，先載入檔案，將其加入影像集合，並建立使用返回的 `IPPImage` 的圖片框。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以此方式加入的影像會內嵌於簡報中，最終檔案不會依賴原始影像檔案的可用性。

### **從 Web 新增影像**

當影像可透過 HTTP 或 HTTPS 取得時，先下載其位元組，將其加入簡報影像集合，並以相同方式在圖片框中使用返回的影像資源。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在長時間執行的應用程式中，請重複使用 HTTP 客戶端或適合應用程式的連線管理策略，而非重複建立不必要的網路基礎設施。若來源不受信任，亦請驗證遠端 URL、回應大小與內容類型。

## **在投影片間重複使用影像**

如果同一影像需要多次使用，只需在簡報中加入一次，然後在建立其他圖片框時重複使用返回的 [IPPImage]。這可避免重複載入相同來源資料，並明確表達共享影像資源與其使用之間的關係。

對於應自動出現在多張投影片上的圖形（例如公司標誌），考慮將圖片框放置於 [投影片母片](/slides/zh-hant/java/slide-master/) 或版面，而不是在每張投影片中各自新增等效圖形。

## **將影像作為投影片背景使用**

背景影像是指派給投影片填充的圖像；它不會以圖片框圖形的方式加入。當影像應覆蓋整個投影片背景且不需要像普通投影片物件那樣操作時，此作法相當有用。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若需其他背景選項（包括母片與版面背景），請參考 [簡報背景](/slides/zh-hant/java/presentation-background/)。

## **內嵌影像與鏈結影像**

內嵌影像與鏈結影像在可攜性與檔案大小上各有取捨：

- **內嵌影像**：影像資料儲存在簡報內。簡報是自包含的，但檔案大小會包含影像資料。
- **鏈結影像**：簡報僅儲存外部影像的路徑或 URL。可減小簡報大小，但在開啟或轉譯簡報時必須能存取外部資源。

可以透過 [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidespicture/) 指定外部路徑或 URL，而非內嵌影像資料，以建立鏈結圖片。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

僅在部署環境能可靠存取外部資源時才使用鏈結影像。對於必須離線或在不同系統間移動的簡報，內嵌影像通常較安全。

## **處理 SVG 影像**

SVG 為向量格式，適合圖示、圖表及其他需要在不失真情況下縮放的圖形。Aspose.Slides 同時支援將 SVG 作為影像資源以及作為可編輯投影片圖形的來源。

### **將 SVG 加入為影像**

建立一個 [SvgImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgimage/)，將其加入影像集合，然後在圖片框中放置產生的影像資源。

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **含外部資源的 SVG 檔案**

SVG 可以引用外部影像、樣式表或字型。針對此類情況，[SvgImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgimage/) 提供接受 [IExternalResourceResolver](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iexternalresourceresolver/) 與基礎 URI 的建構函式。解析器可將相對 URI 映射為允許的絕對 URI，並回傳該資源的串流。

解析器讓 Aspose.Slides 在處理 SVG 時能存取外部資源，但不會將 SVG 重寫為自包含文件。若 SVG 必須保持可攜，請將其所需資源直接嵌入 SVG（例如使用 `data:` URI 連結影像）。

當 SVG 檔案來自不受信任的來源時，請限制解析器可存取的協議、檔案位置與主機。網路解析器亦應套用逾時、回應大小上限與內容驗證。

### **將 SVG 轉換為可編輯圖形**

Aspose.Slides 能將 SVG 轉換為一組可編輯的投影片圖形，類似對應的 PowerPoint 指令。

![PowerPoint 快顯功能表](img_01_01.png)

使用接受 [ISvgImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/) 的 [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/) 重載來執行轉換。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

當需要個別向量元素以 PowerPoint 圖形方式編輯時，才使用 SVG 轉圖形的轉換。若 SVG 只需顯示，保留為影像較為簡單，且可避免產生大量獨立圖形。

## **取代現有影像資源**

當需要取代既有影像資源時，請使用 [IPPImage.replaceImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/)。此功能特別適用於共享的圖形，例如商標。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果多個圖片框、背景、母片或版面使用相同的影像資源，取代該資源會同時更新所有使用處。若只想變更單一圖片框，請為該框指派不同的影像，而非取代共享資源。

`replaceImage` 亦提供接受位元組陣列或其他 [IPPImage] 的重載。

## **實務影像管理建議**

### **控制簡報大小**

大型點陣圖會使簡報不必要地變大。請使用符合實際顯示尺寸的來源影像，盡可能重用共享影像資源，並避免嵌入同一高解析度圖形的多次副本。

對於已放置於圖片框中的點陣圖，[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/) 可依選擇的解析度與裁切設定壓縮影像資料。這屬於圖片框的處理，而非影像集合管理，相關格式化操作請參考 [圖片框](/slides/zh-hant/java/picture-frame/)。

### **在內嵌與鏈結內容之間選擇**

內嵌可使簡報具備可攜性，因為所有必要的影像資料都隨檔案一起攜帶。鏈結可減小檔案大小，但會產生外部依賴。僅在該依賴可接受且穩定時才使用鏈結。

### **重複使用共享品牌圖資**

對於重複出現的商標、水印或裝飾圖形，請使用單一影像資源並重複使用。若圖形屬於簡報設計而非投影片內容，請將其放置於母片或版面，以便讓相應投影片繼承。

### **保持 SVG 資源可攜**

自包含的 SVG 較易搬移且能一致呈現，勝於依賴外部檔案或網路資源的 SVG。若有可能，請在匯入 SVG 前先將所需資源嵌入。僅在需要編輯個別向量元素時才將 SVG 轉換為圖形。

### **使用現代跨平台影像 API**

對於新的 Java 程式碼，請使用 Aspose.Slides 的 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 與 [Images](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/images/) API，取代基於 `java.awt.image.BufferedImage` 的舊版公共 API。遷移指引請參考 [現代 API](/slides/zh-hant/java/modern-api/)。

WMF 與 EMF 需特別考量。當這些格式透過 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 傳遞時，[ImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imagecollection/) 會先將圖形檔轉換為點陣 PNG 後再插入。若需保留圖形檔資料，請改用接受串流的 [ImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imagecollection/) 重載。從試算表或其他產品產生 EMF 內容屬於另一個整合工作流程，超出本文範圍。

## **常見問題**

**影像集合與圖片框有何不同？**

影像集合保存可重複使用的影像資源。圖片框是投影片上的圖形，用於顯示其中一個資源，並提供裁切、效果等圖片專屬格式設定。

**要如何一次性取代所有相同的商標？**

若商標已作為單一影像資源共享，請使用 [IPPImage.replaceImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 取代該資源。若要在整個簡報中統一品牌標示，也可將商標放置於母片或版面，以減少重複的投影片內容。

**為什麼鏈結影像在另一台電腦上會消失？**

鏈結圖片依賴外部檔案或 URL。若該資源在另一台電腦上無法存取，鏈結影像就會無法顯示。當簡報必須自包含時，請內嵌影像。

**插入的 SVG 能否編輯成 PowerPoint 圖形？**

可以。使用 [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/) 轉換 SVG；轉換後的群組會包含可編輯的投影片圖形，而非單一 SVG 圖片。

**如何讓包含大量影像的簡報保持較小？**

重複使用共享影像資源，避免使用過大點陣來源，適時壓縮符合條件的點陣圖，將重複的品牌圖放置於母片或版面，且僅在外部依賴可接受時才使用鏈結影像。
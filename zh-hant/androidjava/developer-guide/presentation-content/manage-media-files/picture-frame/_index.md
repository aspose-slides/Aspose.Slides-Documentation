---
title: 在 Android 上管理簡報中的圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/androidjava/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 嵌入式圖像
- 連結圖像
- 抽取圖像
- 點陣圖像
- SVG 圖像
- 裁切圖像
- 刪除裁切區域
- 壓縮圖像
- StretchOffset
- 圖片框格式設定
- 相對比例尺
- 圖像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 在簡報中建立、格式化、連結、裁切、抽取與壓縮圖片框。"
---
## **概述**

圖片框是一種投影片形狀，用於顯示圖像。在 Aspose.Slides 中，圖像資源與顯示它的形狀是分離的物件：一個 [簡報](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 透過其 [IImageCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagecollection/) 擁有嵌入式圖像資源，而 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 控制圖像的位置、大小、線條格式、旋轉、裁切、圖片效果以及其他框架層級設定。

此分離在同一圖像顯示多次時相當有用。將圖像加入簡報一次，保留回傳的 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/)，在建立圖片框時重複使用該圖像資源。

圖片框可以包含 PNG 或 JPEG 等點陣圖，亦可包含 SVG 向量圖。它們也可以參考連結圖像，而不是把圖像位元組儲存在簡報中。此選擇會影響可攜性、檔案大小、抽取與匯出行為，因此在套用格式或最佳化之前，先決定圖像的儲存方式是很重要的。

## **新增與格式化嵌入式圖像**

對於嵌入式圖像，將圖像資料加入簡報，並使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 建立圖片框。圖像會成為簡報套件的一部分，因而在移動到其他電腦時仍保持自足。

以下範例加入 JPEG 圖像，依圖像原始尺寸建立框架，並套用線條格式與旋轉：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

圖片框控制顯示的幾何形狀；變更框架尺寸不會改變嵌入式圖像資源中儲存的原始像素尺寸。此差異在稍後裁切或壓縮圖像時變得重要。

## **使用相對比例尺**

[IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 透過 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) 與 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) 暴露相對寬度與高度的比例尺。值 `1.0` 代表原始圖片大小的 100%。相對比例尺在工作流程需要保留與來源圖像尺寸之關係，而不是手動計算最終尺寸時非常有用。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

相對比例尺會變更框架的比例設定；它不會重新取樣或壓縮嵌入式圖像。

## **嵌入式與連結圖像**

嵌入式圖片將圖像資料儲存在簡報內，是可攜性與可預測渲染最安全的選擇。連結圖片則透過 [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) 方法儲存外部位置，而不是以相同方式嵌入圖像資料。

連結圖像可以減少 PPTX 中儲存的圖像資料量，但會產生外部相依性。連結的檔案必須保持可供開啟或渲染簡報的應用程式存取。若路徑變更、檔案被移動或資源不可用，連結圖片可能無法如預期顯示。對於必須以電子郵件傳送、封存或在隔離環境中渲染的簡報，嵌入式圖像通常較為可靠。

### **新增連結圖像**

以下範例建立圖片框並指向本機圖像檔。此範例僅處理圖像連結；影片連結屬於另類媒體工作流程，故未混入此範例。

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在外部檔案管理是有意為之時使用連結。不要僅將其當作壓縮的替代方案：一個含有破損圖像相依性的 PPTX 通常不如較大的自足簡報實用。

## **從圖片框抽取圖像**

在從現有簡報抽取圖像之前，先確認形狀確實為 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 且包含嵌入式圖像。連結圖片框可能不含可直接抽取的圖像位元組。

### **抽取點陣圖像**

現代圖像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) ，不需要較舊的 Java 圖像封裝器。以下範例尋找投影片上第一個嵌入式點陣圖，並將其儲存為 PNG：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

透過 [IImage.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 進行儲存會將抽取的圖像轉換成指定的輸出格式。若需要簡報中儲存的編碼位元組，而非已轉換的點陣檔，請使用圖像資源的二進位資料。

### **抽取 SVG 圖像**

對於 SVG 圖片，[IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 會暴露一個 [ISvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/) 物件。這讓您可以直接取得 SVG 資料，而不必先將圖片光柵化。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

將 SVG 內容保留為 SVG 會在簡報內保留向量來源。PNG 或 JPEG 等點陣匯出必須將向量內容轉換為像素。PDF 或 SVG 投影片匯出同樣是一個渲染操作，因此匯出的圖形不應視為原始嵌入 SVG 的逐位元拷貝；若需要原始向量資源，請使用嵌入的 [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/#getSvgData--) 資料。

## **裁切圖像**

裁切會改變框架內可見的圖像區域。[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/) 上的裁切值是相對於來源圖像尺寸的百分比。裁切不會立即從嵌入式圖像中刪除被隱藏的像素；它僅改變可見區域。

以下範例安全地找到圖片框，並套用裁切值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

因為隱藏的圖像資料仍然存在，之後仍可更改裁切而不失去原始像素。若檔案大小比可逆性更重要，可如下一節所述實際移除裁切區域。

## **移除裁切圖像資料**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 會移除當前裁切矩形之外的圖像資料，並回傳結果圖像資源。這可以減少檔案大小，但屬於破壞性最佳化：簡報儲存後，被移除的像素將無法再用於稍後的取消裁切操作。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

此方法可能會在簡報中加入新的圖像資源。若原始圖像同時被其他圖片框使用，這些框仍需要其既有資源，因此刪除裁切區域不一定會降低圖像總數。使用此方法裁切 WMF 或 EMF 內容會將裁切結果光柵化為 PNG。

## **壓縮點陣圖像**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) 會根據圖片實際顯示尺寸降低點陣圖解析度。它也可以在同一次操作中移除裁切區域。當圖像被重新調整大小或裁切時，方法回傳 `true`；若無需變更則回傳 `false`。

當標準目標解析度足以時，可使用預定義的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/picturescompression/) 值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

若需要特定目標，可改為傳入自訂的正 DPI 數值。

壓縮僅適用於點陣圖像。SVG 與圖形檔內容不會透過此點陣壓縮工作流程減少。亦請記得，較低的解析度與已刪除的裁切區域無法從最佳化後的簡報中復原。應根據圖像實際檢視或匯出時的最大尺寸來選擇目標解析度，而非全局套用最低 DPI。

## **管理圖像變換效果**

欲取得涵蓋亮度、對比、顏色變換、模糊、透明度效果、排序鏈、檢查、移除與往返驗證的完整工作流程，請參閱 [Image Transform Effects](/androidjava/image-transform-effects/)。

## **鎖定圖片框幾何形狀**

[IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframelock/) 設定控制哪些編輯操作對圖片框被停用。舉例來說，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 會在調整大小時保留形狀比例。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此鎖定套用於圖片框形狀本身。它不會強制來源圖像重新取樣或永久改變為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/) 上的 stretch‑offset 值定義相對於圖片框邊界盒的填充矩形。正百分比會從邊緣向內縮進，負百分比則向外延伸。

這與裁切不同。裁切值決定來源圖像的哪一部份可見；stretch offset 則改變可見圖片填充被拉伸的矩形。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

使用 stretch offset 進行填充定位。若目標是隱藏來源圖像邊緣，請使用裁切屬性。

## **儲存、檔案大小與匯出考量**

當圖像儲存與圖片框格式分別處理時，主要權衡較易管理：

- **嵌入式圖像** 使簡報自足，對於共享與伺服器端渲染最可靠，但大型點陣圖會增加 PPTX 大小與記憶體使用量。
- **連結圖像** 可以讓套件較小，但簡報依賴外部檔案在儲存路徑或位置仍可存取。
- **裁切** 起初為非破壞性。隱藏的像素會持續嵌入，直至明確刪除裁切區域或在壓縮時移除。
- **壓縮** 能大幅減少過大點陣圖的檔案大小，但會犧牲來源解析度。應在已確定投影片上最終尺寸後再套用。
- **SVG 圖像** 若向量保存重要，應保留為 SVG。當需要向量資源本身時，直接抽取嵌入的 SVG。投影片的點陣匯出始終會將渲染的投影片轉換為像素。
- **重複圖像** 應盡可能重複使用已有的 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 資源，而不是在簡報工作流程中一再載入相同檔案。

對於大型簡報，圖像最佳化通常在選擇性執行時最有效：將標誌與圖表保留為向量內容，根據實際顯示尺寸壓縮照片，僅在不需日後編輯時移除裁切像素，除非相依性管理是部署設計的一部份，否則避免使用外部連結。

## **常見問答**

**圖片框與圖像資源有何不同？**

[IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 代表與簡報關聯的圖像資源。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 則是投影片上的形狀，用於顯示圖像並儲存框架層級的幾何與格式資訊，如大小、旋轉、裁切值、效果與鎖定。

**應該嵌入還是連結圖像？**

當簡報必須具備可攜性、封存或在沒有外部資源的情況下渲染時，請嵌入圖像。僅在刻意將圖像檔案保留在 PPTX 之外且能可靠維持外部位置時才使用連結圖像。

**裁切會減少 PPTX 檔案大小嗎？**

單純的裁切不會。一般裁切設定會隱藏來源圖像的部份，但仍保留底層像素。若想永久移除這些像素，可使用 [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 或在壓縮時同時移除裁切區域。

**壓縮後可以恢復圖像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，刪除裁切區域會丟棄圖像資料。若日後需要高解析度編輯，請將原始來源圖像保留在簡報外部。

**SVG 圖像該如何處理？**

當向量忠實度重要時，請將 SVG 內容保留為 SVG。可直接抽取嵌入的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/)。將投影片渲染為 PNG 或 JPEG 等點陣格式時，會將 SVG 向量光柵化為圖像。

**如何避免在讀取現有投影片時產生不安全的轉型？**

在使用圖片框專屬成員之前，先檢查形狀類型。對 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 做 `instanceof` 檢查，可避免無效的轉型，並讓程式碼能處理不含圖片框的投影片。
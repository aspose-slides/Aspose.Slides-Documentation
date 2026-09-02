---
title: 在 Android 上管理簡報中的圖片框架
linktitle: 圖片框架
type: docs
weight: 10
url: /zh-hant/androidjava/picture-frame/
keywords:
- 圖片框架
- 新增圖片框架
- 建立圖片框架
- 嵌入式影像
- 連結式影像
- 擷取影像
- 點陣圖影像
- SVG 影像
- 裁切影像
- 刪除已裁切區域
- 壓縮影像
- StretchOffset
- 圖片框架格式化
- 相對比例
- 影像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 於 Java 中建立、格式化、連結、裁切、擷取與壓縮簡報中的圖片框架。"
---
## **概觀**

圖片框架是一種顯示影像的投影片形狀。在 Aspose.Slides 中，影像資源與顯示該影像的形狀是分離的物件：一個 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 透過其 [IImageCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagecollection/) 持有嵌入式影像資源，而 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 控制影像的位置、大小、線條格式、旋轉、裁切、圖片效果以及其他框架層級的設定。

當相同影像顯示多次時，這種分離很有用。將影像加入簡報一次，保留回傳的 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/)，在建立圖片框架時使用該影像資源。

圖片框架可以包含 PNG 或 JPEG 等點陣圖，亦可包含 SVG 向量圖。它們也可以參照連結的影像，而不是將影像位元組儲存在簡報中。選擇方式會影響可移植性、檔案大小、擷取與匯出行為，因此在套用格式或最佳化之前，先決定影像應如何儲存是很有用的。

## **新增並格式化嵌入式影像**

對於嵌入式影像，將影像資料加入簡報，並使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 建立圖片框架。影像會成為簡報套件的一部份，因此當簡報移至其他電腦時仍能保持自包含。

以下範例加入 JPEG 影像，依影像的原始尺寸建立框架，並套用線條格式與旋轉：

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

圖片框架控制顯示的幾何形狀；變更框架大小不會改變嵌入式影像資源中儲存的原始像素尺寸。此差異在之後裁切或壓縮影像時變得重要。

## **使用相對比例**

[IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 透過 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) 與 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) 暴露相對寬度與高度的縮放。值 `1.0` 代表原始圖片大小的 100%。相對比例在工作流程需要保留與來源影像大小的關係，而不是手動計算最終尺寸時非常有用。

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

相對比例會變更框架的縮放設定；它不會重新取樣或壓縮嵌入式影像。

## **嵌入式與連結式影像**

嵌入式圖片將影像資料儲存在簡報內，因此是最安全的可移植性與可預測渲染的選擇。連結式圖片則透過 [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) 方法儲存外部位置，而不是以相同方式嵌入影像資料。

連結式影像可以減少 PPTX 中的影像資料量，但會產生外部相依性。連結的檔案必須保持可供開啟或渲染簡報的應用程式存取。若路徑變更、檔案被移動或資源不可用，連結圖片可能無法如預期顯示。對於必須透過電子郵件傳送、歸檔或在隔離環境中渲染的簡報，嵌入式影像通常更可靠。

### **新增連結式影像**

以下範例建立圖片框架，並指向本機影像檔案。它僅處理影像連結；影片連結屬於另一個媒體工作流程，故此範例未混入。

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

在外部檔案管理是刻意為之時才使用連結。不應僅將其作為壓縮的替代方案：一個帶有破損影像相依性的 PPTX 通常比較大的自包含簡報更沒用。

## **從圖片框架擷取影像**

在從現有簡報擷取影像之前，先確認形狀實際上是 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/)，且它包含嵌入式影像。連結式圖片框架可能不包含可相同方式擷取的影像位元組。

### **擷取點陣圖影像**

現代影像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/)，不需要舊的 Java 影像包裝器。以下範例在投影片上找到第一個嵌入的點陣圖，並以 PNG 儲存：

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

透過 [IImage.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 儲存會將擷取的影像轉換成請求的輸出格式。如果您需要簡報中儲存的編碼位元組，而不是已轉換的點陣檔，請使用影像資源的二進位資料。

### **擷取 SVG 影像**

對於 SVG 圖片，[IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 會曝光一個 [ISvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/) 物件。這讓您可以直接取得 SVG 資料，而不必先將圖片光柵化。

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

將 SVG 內容保留為 SVG 可在簡報內保留向量來源。PNG 或 JPEG 等點陣匯出必然會將該向量內容渲染為像素。PDF 或 SVG 投影片匯出同樣是渲染操作，因此匯出的圖形不應被視為原始嵌入 SVG 的逐位元複製；在需要原始向量資源時，請使用嵌入的 [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/#getSvgData--) 資料。

## **裁切影像**

裁切會改變在框架內可見的影像部分。[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/) 上的裁切值是來源影像尺寸的百分比。裁切不會立即從嵌入的影像中刪除隱藏的像素；它只會改變可見區域。

以下範例安全地找到圖片框架，並套用裁切值：

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

因為隱藏的影像資料仍然存在，之後可以更改裁切而不會失去原始像素。若檔案大小比可逆性更重要，可如下一節所述實際移除裁切區域。

## **移除已裁切的影像資料**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 會移除目前裁切矩形之外的影像資料，並回傳結果影像資源。這可以減小檔案大小，但屬於破壞性最佳化：簡報儲存後，已移除的像素將不再可用於之後的取消裁切操作。

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

此方法可能會在簡報中新增一個影像資源。如果原始影像同時被其他圖片框架使用，這些框架仍需要其現有資源，因此刪除裁切區域不一定會減少影像總數。使用此方法裁切 WMF 或 EMF 內容時，會將裁切結果光柵化為 PNG。

## **壓縮點陣圖影像**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) 會相對於圖片顯示尺寸降低點陣圖解析度。它也可以在同一次操作中移除裁切區域。當影像被重新調整大小或裁切時，方法會回傳 `true`，若未需要變更則回傳 `false`。

當標準目標解析度足以時，使用預先定義的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/picturescompression/) 值：

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

若需要特定目標，亦可傳入自訂的正 DPI 值取代預定義值。

壓縮僅適用於點陣圖影像。SVG 與圖形檔案內容不會被此點陣壓縮工作流程縮減。也請記得，較低的解析度與已刪除的裁切區域無法從最佳化後的簡報中復原。請根據實際檢視或匯出時的最大顯示尺寸來決定目標解析度，而非全域套用最低 DPI。

## **管理影像轉換效果**

欲取得涵蓋亮度、對比度、顏色變換、模糊、透明度、排序鏈、檢查、移除以及往返驗證的完整工作流程，請參閱 [Image Transform Effects](/slides/zh-hant/androidjava/image-transform-effects/)。

## **鎖定圖片框架幾何**

[IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframelock/) 設定控制哪些編輯操作會被禁用於圖片框架。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 在調整大小時保留形狀的比例。

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

此鎖定套用於圖片框架形狀本身。它不會強制將來源影像重新取樣或永久改變為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/) 上的 stretch‑offset 值定義相對於圖片框架邊界盒的填充矩形。正百分比會從邊緣向內縮進，負百分比則向外延伸。

這與裁切不同。裁切值決定來源影像的哪一部分可見；stretch offset 則改變可見圖片填充被拉伸的矩形。

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

使用 stretch offset 來放置填充。若目的是隱藏來源影像的邊緣，請使用裁切屬性。

## **儲存、檔案大小與匯出考量**

將影像儲存與圖片框架格式化分開處理時，主要的取捨較易管理：

- **嵌入式影像** 使簡報自包含，是分享與伺服器端渲染最可靠的選擇，但大型點陣圖會增加 PPTX 大小與記憶體使用量。
- **連結式影像** 可讓套件變小，但簡報依賴外部檔案在儲存路徑或位置仍然可用。
- **裁切** 初始為非破壞性。隱藏的像素會保留在嵌入影像中，直到明確刪除或在壓縮時移除裁切區域。
- **壓縮** 能大幅減少過大點陣圖的檔案大小，但會犧牲原始解析度。應在確定投影片上實際顯示尺寸後再套用。
- **SVG 影像** 當向量保留重要時應保持為 SVG。需要向量資源時直接擷取嵌入的 SVG。點陣投影片匯出始終會將渲染的投影片轉換為像素。
- **重複使用的影像** 應盡可能重用現有的 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 資源，而不是在簡報工作流程中重複載入相同檔案。

對於大型簡報，影像最佳化通常在選擇性執行時最有效：將標誌與圖表保留為向量內容，依實際顯示尺寸壓縮照片，僅在不再需要後期編輯時移除裁切像素，除非部署設計已涵蓋相依性管理，否則避免使用外部連結。

## **常見問題**

**圖片框架與影像資源有何不同？**

[IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 代表與簡報關聯的影像資源。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 是投影片上顯示影像的形狀，並儲存框架層級的幾何與格式設定，例如大小、旋轉、裁切值、效果與鎖定。

**應該嵌入還是連結影像？**

當簡報必須可移植、歸檔或在沒有外部資源的情況下渲染時，請嵌入影像。只有在有意將影像檔案保留在 PPTX 之外，且能可靠維護外部位置時才使用連結。

**裁切會減小 PPTX 檔案大小嗎？**

不會。普通的裁切設定會隱藏來源影像的部分，但仍保留底層像素。若想永久移除這些像素，請使用 [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 或在壓縮時移除裁切區域。

**壓縮後可以恢復影像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，且移除裁切區域會捨棄影像資料。若未來可能需要高解析度編輯，請在簡報外保留原始來源影像。

**應該如何處理 SVG 影像？**

在向量保真度重要時，請將 SVG 內容保留為 SVG。嵌入的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/) 可以直接擷取。將投影片渲染為 PNG 或 JPEG 等點陣格式時，會將 SVG 光柵化為像素。

**如何避免在讀取現有投影片時出現不安全的型別轉換？**

在使用圖片框架專屬成員前，先檢查形狀類型。對 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 進行 `instanceof` 檢查，可避免無效的型別轉換，並讓程式碼能處理不含圖片框架的投影片。
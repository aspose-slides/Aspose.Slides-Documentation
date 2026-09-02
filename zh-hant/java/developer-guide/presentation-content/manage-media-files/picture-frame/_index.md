---
title: 使用 Java 管理投影片中的圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/java/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 內嵌影像
- 連結影像
- 擷取影像
- 點陣影像
- SVG 影像
- 裁剪影像
- 刪除已裁剪區域
- 壓縮影像
- StretchOffset
- 圖片框格式設定
- 相對比例縮放
- 影像效果
- 長寬比
- PowerPoint
- OpenDocument
- 投影片
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在投影片中建立、格式化、連結、裁剪、擷取與壓縮圖片框。"
---
## **概覽**

圖片框是一種投影片形狀，用於顯示影像。在 Aspose.Slides 中，影像資源與顯示它的形狀是分離的物件：一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 透過其 [IImageCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagecollection/) 擁有內嵌影像資源，而一個 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/) 則控制影像的位置、大小、線條格式、旋轉、裁剪、圖片效果以及其他框級設定。

此分離在相同影像需要顯示多次時非常有用。將影像一次加入投影片，保留回傳的 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/)，在建立圖片框時重複使用該影像資源。

圖片框可以包含 PNG 或 JPEG 等點陣影像，也可以包含 SVG 向量影像。它們也可以參照連結影像，而不是將影像位元組儲存在投影片中。此選擇會影響可攜性、檔案大小、擷取與匯出行為，因此在套用格式或最佳化之前，先決定影像應該如何儲存是很重要的。

## **新增與格式化內嵌影像**

對於內嵌影像，將影像資料加入投影片並使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 建立圖片框。影像會成為投影片套件的一部份，因此在移動投影片至其他電腦時仍保持自足。

以下範例加入 JPEG 影像，依影像的原始尺寸建立框，並套用線條格式與旋轉：

```java
import com.aspose.slides.*;
import java.awt.Color;

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

圖片框控制顯示的幾何形狀；變更框的大小不會改變嵌入影像資源中儲存的原始像素尺寸。此區別在之後裁剪或壓縮影像時變得重要。

## **使用相對比例縮放**

[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/) 透過 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) 與 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) 露出相對寬度與高度的縮放設定。值 `1.0` 代表原始圖片大小的 100%。相對縮放在工作流程需要保留與來源影像尺寸的關係，而不是手動計算最終尺寸時非常有用。

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

相對縮放會變更框的縮放設定；它不會重新取樣或壓縮嵌入的影像。

## **內嵌與連結影像**

內嵌圖片將影像資料儲存在投影片內，因而是最安全的可攜性與可預測渲染選擇。連結圖片則透過 [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) 方法儲存外部位置，而不是以相同方式嵌入影像資料。

連結影像可以減少 PPTX 中儲存的影像資料量，但會產生外部相依性。連結的檔案必須保持可供開啟或渲染投影片的應用程式存取。若路徑變更、檔案搬移或資源不可用，連結圖片可能無法如預期顯示。對於必須透過電子郵件傳送、存檔或在隔離環境中渲染的投影片，內嵌影像通常較為可靠。

### **新增連結影像**

以下範例建立圖片框並指向本機影像檔案。它僅處理影像連結；影片連結屬於不同的媒體工作流程，故此範例未混入。

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

在外部檔案管理是刻意的情況下使用連結。不要僅將其作為壓縮的替代方案：一個帶有失效影像相依性的較小 PPTX 通常不如較大且自足的投影片有用。

## **從圖片框擷取影像**

在從現有投影片擷取影像之前，先確認形狀實際上是 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/) 且包含內嵌影像。連結圖片框可能不含可直接擷取的影像位元組。

### **擷取點陣影像**

現代影像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 並不需要較舊的 Java 影像封裝器。以下範例找出投影片上第一個內嵌的點陣圖片，並以 PNG 儲存：

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

透過 [IImage.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 儲存會將擷取的影像轉換為所請求的輸出格式。若需要投影片中儲存的編碼位元組而非已轉換的點陣檔，請使用影像資源的二進位資料。

### **擷取 SVG 影像**

對於 SVG 圖片，[IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 會公開一個 [ISvgImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/) 物件。這讓您能直接取得 SVG 資料，而不必先將圖片光柵化。

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

將 SVG 內容保留為 SVG 可在投影片內保留向量來源。PNG 或 JPEG 等點陣匯出必須將向量內容渲染為像素。PDF 或 SVG 投影片匯出同樣是一種渲染操作，因此匯出的圖形不應被視為原始內嵌 SVG 的逐位元拷貝；當需要原始向量資源本身時，請使用內嵌的 [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/#getSvgData--) 資料。

## **裁剪影像**

裁剪會變更框內可見的影像部分。[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/) 上的裁剪值是來源影像尺寸的百分比。裁剪最初不會刪除隱藏的像素，只是改變可見區域。

以下範例安全地尋找圖片框並套用裁剪值：

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

因為隱藏的影像資料仍然存在，之後可以更改裁剪而不會失去原始像素。若檔案大小比可逆性更重要，可如下一節所述實際移除裁剪區域。

## **移除已裁剪的影像資料**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 會移除當前裁剪矩形之外的影像資料，並回傳結果影像資源。這可以減小檔案大小，但屬於破壞性最佳化：投影片儲存後，已移除的像素將無法再用於取消裁剪。

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

此方法可能會在投影片中新增影像資源。若原始影像同時被其他圖片框使用，這些框仍需要其現有資源，因此刪除裁剪區域未必會減少總影像數量。使用此方法裁剪 WMF 或 EMF 內容會將裁剪結果光柵化為 PNG。

## **壓縮點陣影像**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) 會相對於圖片顯示尺寸降低點陣影像解析度。它也可以在同一次操作中移除裁剪區域。方法在影像被重新調整大小或裁剪時回傳 `true`，若未需要變更則回傳 `false`。

在標準目標解析度足以時，使用預先定義的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/picturescompression/) 值：

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

需要特定目標時，可傳入自訂的正 DPI 值取代預定義值。

壓縮僅適用於點陣影像。SVG 與圖形檔內容不會受到此點陣壓縮工作流程的影響。亦請記得，降低解析度與刪除已裁剪區域後無法從最佳化後的投影片恢復。請根據影像實際檢視或匯出的最大尺寸決定目標解析度，而非全域套用最低 DPI。

## **管理影像變換效果**

欲取得涵蓋亮度、對比、顏色變換、模糊、透明度效果、有序鏈、檢查、移除以及往返驗證的完整工作流程，請參閱 [Image Transform Effects](/java/image-transform-effects/)。

## **鎖定圖片框幾何**

[IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframelock/) 設定控制哪些編輯操作會被停用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 會在調整大小時維持形狀比例。

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

此鎖定套用於圖片框形狀。它不會強制將來源影像重新取樣或永久改為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/) 上的 stretch‑offset 值定義相對於圖片框邊界框的填充矩形。正百分比會從邊緣內縮，負百分比則會向外延伸。

這與裁剪不同。裁剪值決定來源影像哪一部分可見；stretch offset 改變可見圖片填充被拉伸的矩形。

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

使用 stretch offset 來放置填充。若目標是隱藏來源影像的邊緣，請使用裁剪屬性。

## **儲存、檔案大小與匯出考量**

當影像儲存與圖片框格式分開處理時，主要的權衡較易管理：

- **內嵌影像** 使投影片自足，且在共享與伺服器端渲染時最可靠，但大型點陣影像會增加 PPTX 大小與記憶體使用。
- **連結影像** 可以讓套件更小，但投影片依賴外部檔案在指定路徑或位置仍然可用。
- **裁剪** 初始為非破壞性。隱藏的像素會保留在內嵌影像中，直至明確刪除裁剪區域或在壓縮時移除。
- **壓縮** 能顯著減少過大點陣影像的檔案大小，但會犧牲來源解析度。應在確定投影片上最終尺寸後再套用。
- **SVG 影像** 若向量保留重要，應保持為 SVG。當需要向量資源本身時，直接擷取內嵌的 SVG。點陣投影片匯出始終會將渲染的投影片轉換為像素。
- **重複使用的影像** 應盡可能重用已存在的 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 資源，而非在工作流程中重複載入相同檔案。

對於大型投影片，影像最佳化通常在選擇性執行時最有效：將標誌與圖表保留為向量內容，根據實際顯示大小壓縮照片，只在不需要日後編輯時移除裁剪像素，除非相依管理是部署設計的一部分，否則避免使用外部連結。

## **常見問題**

**圖片框與影像資源有何差異？**

[IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 代表與投影片相關聯的影像資源。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/) 則是投影片上的形狀，用於顯示影像並儲存框級幾何與格式（例如大小、旋轉、裁剪值、效果與鎖定）。

**應該內嵌還是連結影像？**

在投影片必須可攜、存檔或在沒有外部資源的情況下渲染時，請內嵌影像。僅在刻意將影像檔案保留於 PPTX 之外且能可靠維護外部位置時才使用連結影像。

**裁剪會減少 PPTX 檔案大小嗎？**

單獨的裁剪不會。一般裁剪設定會隱藏來源影像的部份，但仍保留底層像素。若可以永久棄除這些像素，請使用 [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 或在壓縮時移除裁剪區域。

**壓縮後能恢復影像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，且移除裁剪區域會捨棄影像資料。若日後可能需要高解析度編輯，請在投影片外保留原始來源影像。

**應該如何處理 SVG 影像？**

在向量完整性重要時，請保留 SVG 內容為 SVG。內嵌的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/) 可直接擷取。將投影片渲染為 PNG 或 JPEG 等點陣格式時，SVG 會被光柵化為投影片影像的一部份。

**如何避免在讀取現有投影片時發生不安全的類型轉換？**

在使用圖片框專屬成員之前，先檢查形狀類型。對 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/) 進行 `instanceof` 檢查，可避免無效的類型轉換，並讓程式碼處理不含圖片框的投影片。
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
- 嵌入圖像
- 連結圖像
- 擷取圖像
- 光柵圖像
- SVG 圖像
- 裁剪圖像
- 刪除裁剪區域
- 壓縮圖像
- StretchOffset
- 圖片框格式化
- 相對比例
- 圖像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android（Java）建立、格式化、連結、裁剪、擷取與壓縮簡報中的圖片框。"
---
## **概觀**

圖片框是一種在投影片上顯示圖像的形狀。 在 Aspose.Slides 中，圖像資源與顯示它的形狀是分開的物件：一個 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 透過其 [IImageCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagecollection/) 擁有嵌入的圖像資源，而 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 控制圖像的位置、尺寸、線條格式、旋轉、裁剪、圖片效果以及其他框架層級的設定。

此分離在相同圖像需要顯示多次時非常有用。將圖像一次加入簡報，保留回傳的 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/)，在建立圖片框時重複使用該圖像資源。

圖片框可以包含 PNG、JPEG 等光柵圖像，也可以包含 SVG 向量圖像。它們也可以參照連結圖像，而非將圖像位元組存入簡報。此選擇會影響可攜性、檔案大小、擷取與匯出行為，因此在套用格式或最佳化之前，先決定圖像應如何儲存是有意義的。

## **新增及格式化嵌入圖像**

對於嵌入圖像，將圖像資料加入簡報，並使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 建立圖片框。圖像會成為簡報封裝的一部份，因而在移至其他電腦時仍保持自包含。

以下範例加入 JPEG 圖像、以圖像本身的尺寸建立框，並套用線條格式與旋轉：

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

圖片框控制顯示的幾何形狀；變更框的大小不會改變嵌入圖像資源中原始像素的尺寸。此區別在稍後裁剪或壓縮圖像時變得重要。

## **使用相對比例**

[IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 透過 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) 與 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) 曝露相對寬度與高度比例。`1.0` 代表原始圖片大小的 100%。相對比例在工作流程需要保留與來源圖像尺寸的關係，而非手動計算最終尺寸時非常有用。

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

相對比例會變更框的縮放設定；它不會重新取樣或壓縮嵌入圖像。

## **嵌入與連結圖像**

嵌入圖片將圖像資料儲存在簡報內部，因此是最安全的可攜性與可預測呈現的選擇。連結圖片則透過 [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) 方法儲存外部位置，而不是以相同方式嵌入圖像資料。

連結圖像可以減少 PPTX 中的圖像資料量，但會產生外部依賴。連結的檔案必須保持可供開啟或呈現簡報的應用程式存取。若路徑變更、檔案移動或資源不可用，連結圖片可能無法如預期顯示。對於必須透過電子郵件、封存或在隔離環境中呈現的簡報，嵌入圖像通常較為可靠。

### **新增連結圖像**

以下範例建立圖片框，並指向本機圖像檔。此範例僅處理圖像連結；影片連結屬於其他媒體工作流程，故刻意未混入此範例。

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

在需要外部檔案管理時使用連結。不要僅將其視為壓縮的替代方案：帶有斷裂圖像依賴關係的小型 PPTX 通常比較大的自包含簡報更沒用。

## **從圖片框擷取圖像**

在從現有簡報擷取圖像之前，先確認形狀實際上是 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 且包含嵌入圖像。連結的圖片框可能不含可直接擷取的圖像位元組。

### **擷取光柵圖像**

現代圖像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/)，不需要較舊的 Java 圖像包裝器。以下範例找出投影片上第一個嵌入的光柵圖片，並以 PNG 儲存：

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

透過 [IImage.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 儲存會將擷取的圖像轉換為指定的輸出格式。若需要簡報中儲存的編碼位元組，而非已轉換的光柵檔案，請使用圖像資源的二進位資料。

### **擷取 SVG 圖像**

對於 SVG 圖片，[IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 曝露一個 [ISvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/) 物件。這讓您能直接取得 SVG 資料，而不必先將圖片光柵化。

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

將 SVG 內容保留為 SVG 可在簡報內保護向量來源。PNG 或 JPEG 等光柵匯出必然將向量內容渲染成像素。PDF 或 SVG 投影片匯出同樣是渲染操作，因此匯出的圖形不應被視為原始嵌入 SVG 的逐位元拷貝；在需要原始向量資源時，請使用嵌入的 [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/#getSvgData--) 資料。

## **裁剪圖像**

裁剪會變更框內可見的圖像部份。[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/) 上的裁剪值是相對於來源圖像尺寸的百分比。裁剪最初不會刪除隱藏的像素，只是改變可見區域。

以下範例安全地找到圖片框並套用裁剪值：

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

因為隱藏的圖像資料仍然存在，之後可以更改裁剪而不會遺失原始像素。若檔案大小比可逆性更重要，可如下一節所示實際移除裁剪區域。

## **移除裁剪圖像資料**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 會移除目前裁剪矩形之外的圖像資料，並回傳結果圖像資源。這可以減少檔案大小，但屬於破壞性最佳化：簡報儲存後，被移除的像素將無法再用於之後的取消裁剪操作。

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

此方法可能會在簡報中新增一個圖像資源。若原始圖像同時被其他圖片框使用，這些框仍需保留其現有資源，因此刪除裁剪區域不一定會減少圖像總數。以此方法裁剪 WMF 或 EMF 內容會將裁剪結果光柵化為 PNG。

## **壓縮光柵圖像**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) 會根據圖片實際顯示的尺寸降低光柵圖像的解析度。它也可以在同一次操作中移除裁剪區域。若圖像被重新調整大小或裁剪，方法會回傳 `true`；若不需變更則回傳 `false`。

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

如果需要特定目標，亦可傳入自訂的正 DPI 數值。

壓縮僅適用於光柵圖像。SVG 與圖形檔內容不會因此光柵壓縮工作流程而減少。同時請記住，較低的解析度與已刪除的裁剪區域無法從最佳化後的簡報中復原。請依實際檢視或匯出時的最大顯示尺寸來決定目標解析度，而非全局套用最低 DPI。

## **檢查圖像效果**

圖片效果儲存在框所使用的圖片上。圖像變換集合可包含如固定透明度調變 (alpha) 以及亮度 (luminance) 等效果，以調整亮度與對比度。以下範例安全地讀取投影片上第一個圖片框的兩類效果：

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
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

這些效果會改變圖像在框內的呈現方式；它們不會改寫原始嵌入的圖像位元組。

## **鎖定圖片框幾何形狀**

[IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframelock/) 設定控制哪些編輯操作會被停用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 在調整大小時保留形狀比例。

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

此鎖定套用於圖片框形狀本身，並不會強制將來源圖像重新取樣或永久改變為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/) 上的 stretch‑offset 值定義相對於圖片框邊界盒的填充矩形。正百分比會從邊緣向內縮進，負百分比則向外延伸。

這與裁剪不同。裁剪值決定來源圖像的哪一部份可見；stretch offset 則改變可見圖片填充被拉伸的矩形。

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

使用 stretch offset 來調整填充位置；若目的是隱藏來源圖像的邊緣，則使用裁剪屬性。

## **儲存、檔案大小與匯出考量**

當圖像儲存方式與圖片框格式化分別處理時，主要的取捨較易掌握：

- **嵌入圖像** 使簡報自包含，是共享與伺服器端渲染最可靠的選擇，但大型光柵圖像會增加 PPTX 大小與記憶體使用。
- **連結圖像** 可以讓封裝較小，然而簡報必須依賴外部檔案在指定路徑或位置保持可用。
- **裁剪** 初始為非破壞性。隱藏的像素會保留在嵌入圖像中，直至明確刪除裁剪區域或在壓縮時移除。
- **壓縮** 能在圖像尺寸過大時顯著減少檔案大小，但會犧牲來源解析度。應在確定投影片上最終顯示尺寸後才套用。
- **SVG 圖像** 若向量保留重要，應保持為 SVG。當需要向量資源本身時，直接擷取嵌入的 SVG。光柵投影片匯出始終會將渲染的投影片轉換為像素。
- **重複圖像** 應盡可能重用既有的 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 資源，而非在簡報工作流程中多次載入相同檔案。

對於大型簡報，圖像最佳化通常在有選擇性地執行時最有效：將商標與圖表保留為向量內容，依實際顯示大小壓縮相片，僅在不需要日後編輯時移除裁剪像素，除非部署設計已涵蓋依賴管理，否則避免使用外部連結。

## **常見問題**

**圖片框與圖像資源有何不同？**

[IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 代表與簡報相關聯的圖像資源。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 是投影片上的一個形狀，用於顯示圖像並儲存框層級的幾何與格式設定，如尺寸、旋轉、裁剪值、效果與鎖定。

**應該嵌入還是連結圖像？**

當簡報必須可攜、封存或在無外部資源的情況下渲染時，請嵌入圖像。僅在有意將圖像檔案保留在 PPTX 之外且能可靠維護外部位置時才連結圖像。

**裁剪會減少 PPTX 檔案大小嗎？**

裁剪本身不會。普通的裁剪設定會隱藏來源圖像的部份，但仍保留底層像素。若希望永久移除這些像素，可使用 [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 或搭配裁剪區域移除的圖像壓縮。

**壓縮後能恢復圖像品質嗎？**

不能。壓縮會降低儲存的光柵解析度，且移除裁剪區域會捨棄圖像資料。若日後可能需要高解析度編輯，請將原始來源圖像保留於簡報之外。

**SVG 圖像應如何處理？**

在向量保真度重要時，請保留 SVG 為 SVG。嵌入的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/) 可直接擷取。將投影片渲染為 PNG、JPEG 等光柵格式時，SVG 會被光柵化為像素。

**如何避免在讀取現有投影片時產生不安全的型別轉換？**

在使用圖片框專屬成員之前，先檢查形狀類型。對 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 進行 `instanceof` 檢查，可避免非法轉型，並讓程式碼處理不含圖片框的投影片。
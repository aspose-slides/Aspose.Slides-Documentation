---
title: 使用 Java 管理簡報中的圖片框架
linktitle: 圖片框架
type: docs
weight: 10
url: /zh-hant/java/picture-frame/
keywords:
- 圖片框架
- 新增圖片框架
- 建立圖片框架
- 嵌入圖像
- 連結圖像
- 提取圖像
- 點陣圖像
- SVG 圖像
- 裁剪圖像
- 刪除已裁剪區域
- 壓縮圖像
- StretchOffset
- 圖片框架格式設定
- 相對比例
- 圖像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: 使用 Aspose.Slides for Java 在簡報中建立、格式化、連結、裁剪、提取及壓縮圖片框架。
---
## **概觀**

圖片框架是一種在投影片上顯示圖像的形狀。在 Aspose.Slides 中，圖像資源與顯示它的形狀是分離的物件：一個[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)透過其[IImageCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagecollection/)擁有嵌入的圖像資源，而[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/)控制圖像的位置、大小、線條格式、旋轉、裁剪、圖片效果以及其他框架層級的設定。

當同一圖像需要顯示多次時，這種分離非常有用。只需將圖像加入簡報一次，保留返回的[IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/)，在建立圖片框架時使用該圖像資源。

圖片框架可以容納 PNG 或 JPEG 等點陣圖，以及 SVG 向量圖。它們也可以引用連結圖像，而不是將圖像位元組儲存於簡報中。此選擇會影響可攜性、檔案大小、提取與匯出行為，因此在套用格式或最佳化之前，先決定圖像的儲存方式是明智的。

## **新增與格式化嵌入圖像**

對於嵌入圖像，將圖像資料加入簡報，並使用[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)建立圖片框架。圖像會成為簡報套件的一部份，因而在移動至其他電腦時，簡報仍保持自包含。

以下範例加入 JPEG 圖像，以圖像的原始尺寸建立框架，並套用線條格式與旋轉：

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

圖片框架控制顯示的幾何形狀；變更框架大小不會改變嵌入圖像資源中儲存的原始像素尺寸。此區別在之後裁剪或壓縮圖像時變得重要。

## **使用相對比例**

[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/)透過[setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-)與[setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-)公開框架的相對寬高比例。值為`1.0`表示原始圖片大小的 100%。相對比例在需要保留與來源圖像尺寸的關係，而非手動計算最終尺寸的工作流程中特別有用。

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

相對比例會變更框架的比例設定；它不會重新取樣或壓縮嵌入的圖像。

## **嵌入與連結圖像**

嵌入圖片將圖像資料儲存在簡報內，是可攜性與可預測渲染最安全的選擇。連結圖片則是透過[ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-)方法儲存外部位置，而非以相同方式嵌入圖像資料。

連結圖像可以減少 PPTX 中的圖像資料量，但會引入外部相依性。連結的檔案必須保持可供開啟或渲染簡報的應用程式存取。若路徑變更、檔案移動或資源不可用，連結圖片可能無法如預期顯示。對於必須透過電子郵件、歸檔或在隔離環境中渲染的簡報，嵌入圖像通常較可靠。

### **新增連結圖像**

以下範例建立圖片框架並指向本機圖像檔案。它僅處理圖像連結；影片連結屬於另一個媒體工作流程，故未混入此範例中。

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

在外部檔案管理有意圖時使用連結。不要僅將其當作壓縮的替代方案：一個帶有破損圖像相依性的 PPTX 通常比一個較大的自包含簡報更不實用。

## **從圖片框架提取圖像**

在從現有簡報提取圖像之前，先確認形狀實際上是[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/)，且它包含嵌入圖像。連結圖片框架可能不含可同方式提取的圖像位元組。

### **提取點陣圖像**

現代圖像 API 直接使用[IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/)，不再需要舊的 Java 圖像封裝器。以下範例找出投影片上第一個嵌入的點陣圖片，並將其另存為 PNG：

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

透過[IImage.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/#save-java.lang.String-int-)儲存會將提取的圖像轉換為請求的輸出格式。如果需要取得儲存在簡報中的編碼位元組，而非轉換後的點陣檔，請使用圖像資源的二進位資料。

### **提取 SVG 圖像**

對於 SVG 圖片，[IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/)提供[ISvgImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/)物件。這讓您可以直接取得 SVG 資料，而不必先將圖片光柵化。

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

將 SVG 內容保留為 SVG 可以在簡報中保留向量來源。PNG 或 JPEG 等點陣匯出必然將該向量內容轉換為像素。PDF 或 SVG 投影片匯出也是一次渲染操作，因此匯出的圖形不應視為原始嵌入 SVG 的逐位元複製；在需要原始向量資源時，請使用嵌入的[ISvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/#getSvgData--)資料。

## **裁剪圖像**

裁剪會變更在框架內可見的圖像部份。[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/)的裁剪值以來源圖像尺寸的百分比表示。裁剪不會立即從嵌入圖像中刪除被隱藏的像素；它僅改變可見區域。

以下範例安全地找到圖片框架並套用裁剪值：

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

因為隱藏的圖像資料仍然存在，之後可以變更裁剪而不會失去原始像素。如果檔案大小比可逆性更重要，可以如下一節所述實際移除裁剪區域。

## **移除裁剪的圖像資料**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)會移除目前裁剪矩形之外的圖像資料，並回傳結果圖像資源。這可以減少檔案大小，但屬於破壞性最佳化：簡報儲存後，被移除的像素將無法再進行取消裁剪的操作。

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

此方法可能會在簡報中新增圖像資源。如果原始圖像同時被其他圖片框架使用，這些框架仍需其現有資源，因此刪除裁剪區域不一定會減少總圖像數量。使用此方法裁剪 WMF 或 EMF 內容會將裁剪結果光柵化為 PNG。

## **壓縮點陣圖像**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-)會根據圖片顯示尺寸相對降低點陣圖像解析度。它也可以在同一次操作中移除裁剪區域。當圖像被調整大小或裁剪時，此方法回傳`true`；若未作任何變更則回傳`false`。

當標準目標解析度足以時，可使用預先定義的[PicturesCompression](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/picturescompression/)值：

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

壓縮僅適用於點陣圖像。SVG 與圖形檔內容不會因此光柵壓縮工作流程而減少。此外，較低的解析度與已刪除的裁剪區域無法從最佳化後的簡報中復原。請根據圖像實際觀看或匯出的最大尺寸選擇目標解析度，而非全局套用最低 DPI。

## **檢查圖像效果**

圖片效果儲存在框架使用的圖片上。圖像變換集合可以包含透明度的固定 Alpha 調變以及亮度/對比度的亮度調整等效果。以下範例安全地從投影片上第一個圖片框架讀取兩種效果：

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

這些效果改變圖像在框架中的呈現方式；它們不會改寫原始嵌入圖像的位元組。

## **鎖定圖片框架幾何**

[IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframelock/)設定控制哪種編輯操作會對圖片框架被停用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-)在調整大小時保留形狀的比例。

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

此鎖定套用於圖片框架形狀本身，並不會強制來源圖像被重新取樣或永久改變為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/)上的 stretch‑offset 值定義相對於圖片框架邊界框的填充矩形。正百分比會從邊緣向內縮進，負百分比則向外延伸。

這與裁剪不同。裁剪值選取來源圖像的可見部份；stretch offset 則改變可見圖片填充被拉伸的矩形。

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

使用 stretch offset 來放置填充。當目標是隱藏來源圖像邊緣時，使用裁剪屬性。

## **儲存、檔案大小與匯出考量**

當將圖像儲存與圖片框架格式分開處理時，主要的取捨較易管理：

- **嵌入圖像**使簡報自包含，對於分享與伺服器端渲染最可靠，但大型點陣圖會增加 PPTX 大小與記憶體使用。
- **連結圖像**可以讓套件更小，但簡報依賴外部檔案在儲存路徑或位置仍可取得。
- **裁剪**最初是非破壞性的。隱藏的像素會保留在嵌入圖像中，直至明確刪除裁剪區域或在壓縮時移除。
- **壓縮**可大幅減少過大的點陣圖檔案大小，但會犧牲來源解析度。應在確定投影片上最終顯示尺寸後再套用。
- **SVG 圖像**在向量保留重要時應保持 SVG。需要向量資源時直接提取嵌入的 SVG。點陣投影片匯出始終會將渲染的投影片轉為像素。
- **重複圖像**應盡可能重複使用現有的[IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/)資源，而非在簡報工作流程中多次載入相同檔案。

對於大型簡報，圖像最佳化通常在選擇性執行時最有效：將標誌與圖表保留為向量內容，依實際顯示尺寸壓縮照片，僅在不需日後編輯時移除裁剪像素，且除非依賴管理是部署設計的一部份，否則避免使用外部連結。

## **常見問與答**

**圖片框架與圖像資源有何差異？**

[IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/)代表與簡報關聯的圖像資源。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/)則是投影片上的形狀，用於顯示圖像並儲存框架層級的幾何與格式資訊，例如大小、旋轉、裁剪值、效果與鎖定。

**應該嵌入還是連結圖像？**

當簡報必須可攜、歸檔或在無法存取外部資源的環境中渲染時，請嵌入圖像。僅在刻意將圖像檔案保留在 PPTX 之外且能可靠維護外部位置時才使用連結圖像。

**裁剪會減少 PPTX 檔案大小嗎？**

單純的裁剪不會。一般的裁剪設定會隱藏來源圖像的部份，但仍保留底層像素。可使用[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)或在壓縮時移除裁剪區域，以永久刪除這些像素。

**壓縮後能恢復圖像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，且移除裁剪區域會丟棄圖像資料。如需日後高解析度編輯，請在簡報外保留原始來源圖像。

**SVG 圖像應如何處理？**

在向量完整性重要時，保留 SVG 內容為 SVG。可直接提取嵌入的[ISvgImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/)。將投影片渲染為 PNG 或 JPEG 等點陣格式時，SVG 會被光柵化為像素。

**如何避免在讀取現有投影片時產生不安全的型別轉換？**

在使用圖片框架相關成員前，先檢查形狀類型。對[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/)執行`instanceof`檢查，可避免無效的型別轉換，並讓程式碼能正確處理不含圖片框架的投影片。
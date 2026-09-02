---
title: 使用 Java 在簡報中管理圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/java/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 嵌入圖像
- 連結圖像
- 提取圖像
- 點陣圖像
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在簡報中建立、格式化、連結、裁剪、提取及壓縮圖片框。"
---
## **概觀**

圖片框是顯示圖像的投影片形狀。在 Aspose.Slides 中，圖像資源與顯示它的形狀是分開的物件：一個[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)透過其[IImageCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimagecollection/)擁有嵌入的圖像資源，而一個[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/)控制圖像的位置、大小、線條格式、旋轉、裁剪、圖片效果以及其他框級設定。

當同一圖像多次顯示時，這種分離很有用。將圖像加入簡報一次，保留返回的[IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/)，在建立圖片框時使用該圖像資源。

圖片框可以包含 PNG、JPEG 等點陣圖以及 SVG 向量圖。它們也可以引用連結的圖像而不是將圖像位元組儲存在簡報內。此選擇會影響可移植性、檔案大小、提取與匯出行為，因此在套用格式或最佳化之前，先決定圖像的儲存方式是有益的。

## **新增與格式化嵌入圖像**

對於嵌入圖像，將圖像資料加入簡報，並使用[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)建立圖片框。圖像會成為簡報套件的一部份，讓簡報在移至其他電腦時仍保持自足。

以下範例加入 JPEG 圖像，以圖像原始尺寸建立框，並套用線條格式與旋轉：

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

圖片框控制顯示的幾何形狀；更改框的大小不會改變嵌入圖像資源中儲存的原始像素尺寸。此區別在之後裁剪或壓縮圖像時變得重要。

## **使用相對比例**

[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/)透過[setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-)與[setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-)提供框的相對寬高比例。值 `1.0` 代表原圖大小的 100%。相對比例在需要保留與來源圖像尺寸關係，而不是手動計算最終尺寸的工作流程中很有用。

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

相對比例會變更框的比例設定；它不會重新取樣或壓縮嵌入圖像。

## **嵌入與連結圖像**

嵌入圖片將圖像資料儲存在簡報內，因此在可移植性與可預測的呈現上最安全。連結圖片則透過[ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-)方法儲存外部位置，而不是以相同方式嵌入圖像資料。

連結圖像可減少 PPTX 中的圖像資料量，但會產生外部依賴。開啟或呈現簡報的應用程式必須能存取該連結檔案。若路徑變更、檔案移動或資源不可用，連結圖片可能無法如預期顯示。對於必須以電子郵件傳送、存檔或在隔離環境中呈現的簡報，嵌入圖像通常較可靠。

### **新增連結圖像**

以下範例建立圖片框並指向本機圖像檔案。它僅處理圖像連結；影片連結屬於其他媒體工作流程，故此範例未混合處理。

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

在有意外部檔案管理時使用連結。不要僅將其作為壓縮的替代方案：一個帶有破損圖像依賴關係的小 PPTX 通常不如較大的自給自足簡報實用。

## **從圖片框提取圖像**

在從現有簡報提取圖像之前，請先確認形狀實際上是[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/)且包含嵌入圖像。連結圖片框可能不含可同樣方式提取的圖像位元組。

### **提取點陣圖像**

現代圖像 API 直接使用[IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/)，不需要較舊的 Java 圖像包裝器。以下範例在投影片上找到第一個嵌入的點陣圖片，並以 PNG 儲存：

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

透過[IImage.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/#save-java.lang.String-int-)儲存會將提取的圖像轉換為指定的輸出格式。如果需要簡報中儲存的已編碼位元組，而非轉換後的點陣檔，請使用圖像資源的二進位資料。

### **提取 SVG 圖像**

對於 SVG 圖片，[IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/)會暴露一個[ISvgImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/)物件。這讓您可以直接取得 SVG 資料，而不必先將圖片光柵化。

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

將 SVG 內容保留為 SVG 可在簡報內保留向量來源。PNG 或 JPEG 等點陣匯出必須將向量內容轉換為像素。PDF 或 SVG 投影片匯出同樣是渲染操作，因此匯出的圖形不應被視為原始嵌入 SVG 的位元複製；在需要原始向量資源時，請使用嵌入的[ISvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgimage/#getSvgData--)資料。

## **裁剪圖像**

裁剪會改變框內可見的圖像部分。[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/)上的裁剪值是來源圖像尺寸的百分比。裁剪最初不會刪除嵌入圖像中隱藏的像素；它僅改變可見區域。

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

因為隱藏的圖像資料仍然存在，之後仍可變更裁剪而不失去原始像素。若檔案大小比可逆性更重要，可參考下一節將裁剪區域實際移除。

## **移除裁剪的圖像資料**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)會移除當前裁剪矩形之外的圖像資料，並返回結果圖像資源。這可以減少檔案大小，但屬於破壞性最佳化：簡報儲存後，已移除的像素不再可用於之後的取消裁剪操作。

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

此方法可能會向簡報新增圖像資源。若原始圖像同時被其他圖片框使用，這些框仍需其既有資源，因此刪除裁剪區域不一定會降低圖像總數。使用此方法裁剪 WMF 或 EMF 內容會將裁剪結果光柵化為 PNG。

## **壓縮點陣圖像**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-)會相對於圖片顯示尺寸降低點陣圖解析度。它也可以在同一操作中移除裁剪區域。若圖像被重新調整大小或裁剪，方法會回傳 `true`；若未有變更則回傳 `false`。

當標準目標解析度足夠時，可使用預定義的[PicturesCompression](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/picturescompression/)值：

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

若需要特定目標，可傳入自訂的正 DPI 值，取代預定義值。

壓縮僅針對點陣圖像。SVG 與圖形檔內容不會因此點陣壓縮工作流程而降低。另外請記住，較低的解析度與已刪除的裁剪區域無法從最佳化後的簡報中復原。應根據圖像實際檢視或匯出的最大尺寸選擇目標解析度，而非全局使用最低 DPI。

## **管理圖像變換效果**

欲取得涵蓋亮度、對比、顏色變換、模糊、透明度效果、順序鏈、檢查、移除與往返驗證的完整工作流程，請參閱[Image Transform Effects](/slides/zh-hant/java/image-transform-effects/)。

## **鎖定圖片框幾何形狀**

[IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframelock/)設定控制哪些編輯操作會對圖片框被停用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-)在調整大小時保留形狀比例。

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

此鎖定套用於圖片框形狀本身，並不會強制來源圖像重新取樣或永久改變為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/)上的 stretch‑offset 值會相對於圖片框的邊界框定義填充矩形。正百分比會從邊緣向內縮進，負百分比則向外延伸。

這與裁剪不同。裁剪值選取來源圖像的可見部分；stretch offset 則改變可見圖片填充被拉伸的矩形。

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

使用 stretch offset 來放置填充；若目標是隱藏來源圖像的邊緣，則使用裁剪屬性。

## **儲存、檔案大小與匯出考量**

將圖像儲存與圖片框格式分開處理時，主要權衡較易管理：

- **嵌入圖像**讓簡報自給自足，對於分享與伺服器端呈現最可靠，但大型點陣圖會增加 PPTX 大小與記憶體使用量。
- **連結圖像**可讓套件較小，但簡報必須依賴外部檔案在指定路徑或位置保持可用。
- **裁剪**最初為非破壞性。隱藏的像素會保留於嵌入圖像中，直至明確刪除裁剪區域或在壓縮時移除。
- **壓縮**可大幅減少過大點陣圖的檔案大小，但會犧牲來源解析度。應在確定投影片上實際顯示尺寸後再進行。
- **SVG 圖像**在向量保真度重要時應保留為 SVG。需要向量資源時直接提取嵌入的 SVG。點陣投影片匯出始終將渲染的投影片轉換為像素。
- **重複圖像**應盡可能重複使用現有的[IPPImage]資源，而非在簡報工作流程中多次載入相同檔案。

對於大型簡報，圖像最佳化通常在有選擇性地執行時最有效：將標誌與圖表保留為向量內容，根據實際顯示大小壓縮照片，只在不需後續編輯時移除裁剪像素，除非部署設計已考慮依賴管理，否則避免使用外部連結。

## **常見問答**

**圖片框與圖像資源有何不同？**

[IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/)代表與簡報相關聯的圖像資源。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframe/)則是投影片上的形狀，用於顯示圖像並儲存框級幾何與格式（如大小、旋轉、裁剪值、效果與鎖定）。

**應該嵌入還是連結圖像？**

當簡報必須可移植、存檔或在無外部資源存取的情況下呈現時，請嵌入圖像。僅在有意將圖像檔案保留在 PPTX 之外且能可靠維持外部位置時才使用連結圖像。

**裁剪會減少 PPTX 檔案大小嗎？**

不會單獨減少。普通的裁剪設定會隱藏圖像部分，但仍保留底層像素。若需永久移除這些像素，請使用[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)或在壓縮時同時移除裁剪區域。

**壓縮後能恢復圖像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，刪除裁剪區域則會遺失圖像資料。如果日後需要高解析度編輯，請在簡報外保留原始來源圖像。

**應該如何處理 SVG 圖像？**

當向量保真度重要時，請保留 SVG 內容為 SVG。可直接提取嵌入的[ISvgImage]。將投影片渲染為 PNG 或 JPEG 等點陣格式會將 SVG 轉換為像素。

**如何避免在讀取現有投影片時產生不安全的型別轉換？**

在使用圖片框專屬成員之前，先檢查形狀類型。對[IPictureFrame]進行`instanceof`檢查，可避免無效的型別轉換，並讓程式碼處理不含圖片框的投影片。
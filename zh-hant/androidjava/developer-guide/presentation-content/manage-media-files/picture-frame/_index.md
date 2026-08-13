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
- 新增影像
- 建立影像
- 擷取影像
- 點陣圖影像
- 向量圖影像
- 裁切影像
- 已裁切區域
- StretchOff 屬性
- 圖片框格式設定
- 圖片框屬性
- 相對縮放
- 影像效果
- 長寬比
- 影像透明度
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 將圖片框新增至 PowerPoint 與 OpenDocument 簡報。精簡工作流程並提升投影片設計。"
---
## **簡介**

圖片框是一種包含影像的形狀——就像框中的圖片。

您可以透過圖片框將影像新增至投影片。如此一來，您可以透過格式化圖片框來調整影像的格式。

{{% alert  title="Tip" color="info" %}} 

Aspose 提供免費的轉換工具——[JPEG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓使用者能夠快速從圖片建立簡報。 

{{% /alert %}} 

## **建立圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 將影像新增至與簡報物件相關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IImageCollection)，以建立 [IPPImage]() 物件，用於填滿形狀。  
4. 指定影像的寬度與高度。  
5. 透過與參考投影片相關聯的 shape 物件所提供的 `AddPictureFrame` 方法，依據影像的寬度與高度建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/PictureFrame)。  
6. 將包含圖片的圖片框新增至投影片。  
7. 將修改後的簡報寫入為 PPTX 檔案。  

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// 建立代表 PPTX 檔案的 Presentation 類別實例
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 建立 Image 類別實例
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 以圖片相同的高度與寬度新增圖片框
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 將 PPTX 檔案寫入磁碟
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **建立相對縮放的圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 將影像新增至簡報的影像集合中。  
4. 將影像新增至與簡報物件相關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IImageCollection)，以建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPPImage) 物件，用於填滿形狀。  
5. 在圖片框中指定影像的相對寬度與高度。  
6. 將修改後的簡報寫入為 PPTX 檔案。  

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// 建立代表 PPTX 的 Presentation 類別實例
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 建立 Image 類別實例
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 以圖片相同的高度與寬度新增圖片框
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 設定相對縮放的寬度與高度
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // 將 PPTX 檔案寫入磁碟
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **從圖片框中擷取點陣圖影像**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/PictureFrame) 物件擷取點陣圖影像，並以 PNG、JPG 或其他格式儲存。下方程式碼範例示範如何從「sample.pptx」文件中擷取影像並以 PNG 格式儲存。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **從圖片框中擷取 SVG 影像**

當簡報包含放置在 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/) 形狀內的 SVG 圖形時，Aspose.Slides for Android via Java 可讓您以完整保真度取得原始向量圖。只要取得包含 SVG 內容的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/) 之 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/)，即可讀取該 SVG 圖像並以其原生 SVG 格式儲存至磁碟或串流。

以下程式碼範例示範如何從圖片框中擷取 SVG 影像：

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **取得影像的透明度**

Aspose.Slides 允許您取得套用在影像上的透明度效果。以下 Java 程式碼示範此操作：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **取得影像的亮度與對比度**

Aspose.Slides 允許您取得套用在影像上的亮度與對比度效果。[ILuminance](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iluminance/) 介面代表此影像轉換效果。

以下 Java 程式碼示範如何從圖片框取得亮度與對比度設定：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **圖片框格式設定**

Aspose.Slides 提供許多可套用於圖片框的格式設定選項。使用這些選項，您可以調整圖片框以符合特定需求。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 將影像新增至與簡報物件相關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IImageCollection)，以建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPPImage) 物件，用於填滿形狀。  
4. 指定影像的寬度與高度。  
5. 透過與參考投影片相關聯的 [IShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 物件所提供的 [AddPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法，依據影像的寬度與高度建立 `PictureFrame`。  
6. 將包含圖片的圖片框新增至投影片。  
7. 設定圖片框的線條顏色。  
8. 設定圖片框的線寬。  
9. 以正值或負值旋轉圖片框。  
   * 正值會順時針旋轉影像。  
   * 負值會逆時針旋轉影像。  
10. 再次將包含圖片的圖片框新增至投影片。  
11. 將修改後的簡報寫入為 PPTX 檔案。  

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// 建立代表 PPTX 的 Presentation 類別實例
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 建立 Image 類別實例
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 以圖片相同的高度與寬度新增圖片框
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 對 PictureFrameEx 套用一些格式設定
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // 將 PPTX 檔案寫入磁碟
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Aspose 最近開發了 [免費拼貼製作工具](https://products.aspose.app/slides/zh-hant/collage)。如果您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 圖片，或是 [從照片建立格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，都可以使用此服務。 

{{% /alert %}}

## **將影像作為連結新增**

為了避免簡報檔案過大，您可以透過連結的方式新增影像（或影片），而非直接嵌入檔案。以下 Java 程式碼示範如何將影像與影片新增至佔位元件：

```java
import com.aspose.slides.*;
import java.util.ArrayList;

Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **裁切影像**

以下 Java 程式碼示範如何在投影片上裁切既有影像：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// 建立新的影像物件
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 在投影片中新增圖片框
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // 裁切影像（百分比值）
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // 儲存結果
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **刪除圖片框的裁切區域**

如果想刪除框中影像的裁切區域，可以使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法。若不需要裁切，該方法會返回原始影像。

以下 Java 程式碼示範此操作：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 從第一張投影片取得 PictureFrame
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 刪除 PictureFrame 影像的裁切區域並返回已裁切的影像
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 儲存結果
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法會將裁切後的影像加入簡報的影像集合中。若該影像僅在已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/) 中使用，此設定可減少簡報大小；否則，最終簡報中的影像數量會增加。

此方法在裁切操作中會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 影像。 

{{% /alert %}}

## **壓縮影像**

您可以使用 [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) 方法在簡報中壓縮圖片。此方法會依據形狀大小與指定的解析度減少影像尺寸，且可選擇刪除裁切區域。

它會調整圖片的大小與解析度，類似 PowerPoint 的 **Picture Format > Compress Pictures > Resolution** 功能。

以下 Java 範例示範如何透過指定目標解析度，並可選擇刪除裁切區域，以壓縮簡報中的影像：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 以目標解析度 150 DPI（網路解析度）壓縮影像並移除裁切區域。
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // 檢查壓縮的結果。
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

或直接使用自訂 DPI 值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 以 150 DPI（網路解析度）壓縮影像，並移除裁切區域。
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

此方法會根據形狀尺寸與提供的 DPI 將影像轉換為較低解析度。也可以刪除裁切區域以優化檔案大小。若影像為中繪圖檔 (WMF/EMF) 或 SVG，則不會套用壓縮。JPEG 影像的品質會依解析度保留或微幅下降，行為與 PowerPoint 處理高解析度 JPEG 時相同。

{{% /alert %}}

## **鎖定長寬比**

若希望包含影像的形狀在更改影像尺寸後仍保持長寬比，可使用 [setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 方法設定 *Lock Aspect Ratio* 屬性。

以下 Java 程式碼示範如何鎖定形狀的長寬比：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // 設定形狀在調整大小時保留長寬比
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

此 *Lock Aspect Ratio* 設定僅保留形狀本身的長寬比，並不會鎖定其內含的影像。 

{{% /alert %}}

## **使用 StretchOff 屬性**

使用 [StretchOffsetLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) 與 [StretchOffsetBottom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) 屬性，來自 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPictureFillFormat) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPictureFillFormat) 類別，可指定填充矩形。

當對影像指定伸展時，來源矩形會按比例縮放以符合指定的填充矩形。填充矩形的每一邊皆以相對於形狀邊界盒相應邊的百分比偏移來定義。正的百分比表示內縮，負的百分比表示外延。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 新增一個矩形 `AutoShape`。  
4. 建立影像。  
5. 設定形狀的填充類型。  
6. 設定形狀的圖片填充模式。  
7. 新增用於填充形狀的影像。  
8. 指定影像相對於形狀邊界盒相應邊的偏移。  
9. 將修改後的簡報寫入為 PPTX 檔案。  

```java
import com.aspose.slides.*;

// 建立代表 PPTX 檔案的 Presentation 類別實例
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 建立 ImageEx 類別實例
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 新增 AutoShape 並設定為 Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 設定形狀的填充類型
    aShape.getFillFormat().setFillType(FillType.Picture);

    // 設定形狀的圖片填充模式
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // 設定影像以填滿形狀
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 指定影像相對於形狀邊界盒相應邊的偏移
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // 將 PPTX 檔案寫入磁碟
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### 如何查詢支援的 PictureFrame 圖像格式？

Aspose.Slides 支援點陣圖（PNG、JPEG、BMP、GIF 等）與向量圖（例如 SVG），這些圖像皆可指定給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/)。支援的格式通常與投影片與影像轉換引擎的能力相匹配。

### 大量新增大型圖像會如何影響 PPTX 大小與效能？

嵌入大型圖像會增加檔案大小與記憶體使用量；使用連結方式新增圖像可降低簡報檔案大小，但需確保外部檔案持續可存取。Aspose.Slides 提供以連結方式新增圖像的功能，以減少檔案大小。

### 如何防止圖像物件被意外移動/調整大小？

可使用 [shape locks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) 為 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/) 設定鎖定（例如禁用移動或調整大小）。此鎖定機制支援多種形狀類型，包括 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/)。

### 匯出簡報為 PDF/影像時，SVG 向量的保真度是否得以保留？

Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/) 中提取原始的 SVG 向量。若在 [匯出為 PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/) 或 [匯出為點陣格式](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 時，結果可能會根據匯出設定被點陣化；然而，提取行為證實原始 SVG 仍以向量形式保存。
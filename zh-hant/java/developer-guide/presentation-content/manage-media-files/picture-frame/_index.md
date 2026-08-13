---
title: 使用 Java 管理簡報中的圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/java/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 新增影像
- 建立影像
- 提取影像
- 點陣影像
- 向量影像
- 裁切影像
- 裁切區域
- StretchOff 屬性
- 圖片框格式設定
- 圖片框屬性
- 相對比例
- 影像效果
- 長寬比
- 影像透明度
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 為 PowerPoint 與 OpenDocument 簡報新增圖片框。簡化工作流程並提升投影片設計。"
---
## **簡介**

圖片框是一種包含影像的形狀——它就像框中的圖片。

您可以透過圖片框將影像加入投影片。這樣，您就可以透過格式化圖片框來格式化影像。

{{% alert  title="Tip" color="info" %}} 
Aspose 提供免費轉換工具——[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 和 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓使用者能夠快速從影像建立簡報。 
{{% /alert %}} 

## **建立圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 透過將影像新增至與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IImageCollection) 以建立 [IPPImage]() 物件，用於填充形狀。  
4. 指定影像的寬度與高度。  
5. 根據影像的寬度與高度，透過參考投影片關聯的形狀物件所提供的 `AddPictureFrame` 方法建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/PictureFrame)。  
6. 將包含圖片的圖片框加入投影片。  
7. 將修改後的簡報寫入為 PPTX 檔案。  

以下 Java 程式碼說明如何建立圖片框：

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 實例化 Image 類別
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 新增一個圖片框，其高度與寬度與圖片相同
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 將 PPTX 檔案寫入磁碟
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
圖片框讓您能快速以影像建立簡報投影片。當您將圖片框與 Aspose.Slides 的儲存選項結合時，可操作輸入/輸出以將影像從一種格式轉換為另一種格式。您可能想參考以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/java/conversion/image-to-jpg/)；轉換 [JPG to image](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-image/)；轉換 [JPG to PNG](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-png/)，轉換 [PNG to JPG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-jpg/)；轉換 [PNG to SVG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-svg/)，轉換 [SVG to PNG](https://products.aspose.com/slides/zh-hant/java/conversion/svg-to-png/)。 
{{% /alert %}} 

## **以相對比例建立圖片框**

透過調整影像的相對縮放，您可以建立更複雜的圖片框。  

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 將影像新增至簡報的影像集合中。  
4. 透過將影像新增至與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IImageCollection) 以建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPPImage) 物件，用於填充形狀。  
5. 在圖片框中指定影像的相對寬度與高度。  
6. 將修改後的簡報寫入為 PPTX 檔案。  

以下 Java 程式碼示範如何以相對比例建立圖片框：

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 實例化 Image 類別
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 新增圖片框，其高度與寬度與圖片相同
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 設定相對比例的寬度與高度
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // 將 PPTX 檔案寫入磁碟
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **從圖片框提取點陣圖像**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/PictureFrame) 物件提取點陣圖像，並以 PNG、JPG 等格式儲存。以下程式碼示例展示如何從文件「sample.pptx」中提取影像並儲存為 PNG 格式。

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

## **從圖片框提取 SVG 圖像**

當簡報包含置於 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/) 形狀內的 SVG 圖形時，Aspose.Slides for Java 可讓您以完整保真度取回原始向量圖像。透過遍歷投影片的形狀集合，您可以識別每個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/)，檢查底層的 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 是否包含 SVG 內容，然後將該影像以其原生 SVG 格式儲存至磁碟或串流。

以下程式碼示例說明如何從圖片框提取 SVG 圖像：

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

        // 當圖片是點陣圖時，getSvgImage 會返回 null。
        if (svgImage != null) {
            FileOutputStream fos = new FileOutputStream("output.svg");
            fos.write(svgImage.getSvgData());
            fos.close();
        }
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **取得影像的透明度**

Aspose.Slides 讓您取得套用於影像的透明效果。以下 Java 程式碼示範此操作：

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

Aspose.Slides 讓您取得套用於影像的亮度與對比度效果。[ILuminance](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iluminance/) 介面代表此影像轉換效果。

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

Aspose.Slides 提供多種可套用於圖片框的格式設定選項。利用這些選項，您可以調整圖片框以符合特定需求。  

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 透過將影像新增至與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IImageCollection) 以建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPPImage) 物件，用於填充形狀。  
4. 指定影像的寬度與高度。  
5. 透過參考投影片關聯的 [IShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection) 物件所提供的 [AddPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法，根據影像的寬度與高度建立 `PictureFrame`。  
6. 將包含圖片的圖片框加入投影片。  
7. 設定圖片框的線條顏色。  
8. 設定圖片框的線寬。  
9. 透過給予正值或負值來旋轉圖片框。  
   * 正值會使影像順時針旋轉。  
   * 負值會使影像逆時針旋轉。  
10. 將包含圖片的圖片框加入投影片。  
11. 將修改後的簡報寫入為 PPTX 檔案。  

以下 Java 程式碼示範圖片框格式設定的過程：

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 實例化 Image 類別
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 新增圖片框，其高度與寬度與圖片相同
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
Aspose 最近開發了 [免費拼貼製作工具](https://products.aspose.app/slides/zh-hant/collage)。若您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 影像，或是 [從相片建立格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，皆可使用此服務。 
{{% /alert %}} 

## **將影像加入為連結**

為了避免簡報檔案過大，您可以透過連結加入影像（或影片），而不是直接嵌入檔案。以下 Java 程式碼示範如何將影像與影片加入佔位區：

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

以下 Java 程式碼說明如何裁切投影片上的現有影像：

```java
import com.aspose.slides.*;

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

Presentation pres = new Presentation();
// 建立新的影像物件
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 在投影片上新增圖片框
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // 裁切影像（百分比值）
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // 儲存結果
    pres.save(outPptxFile, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **刪除圖片的裁切區域**

若您想刪除框內影像的裁切區域，可使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法。若無需裁切，該方法會回傳裁切後的影像或原始影像。

以下 Java 程式碼示範此操作：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 取得第一張投影片上的 PictureFrame
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 刪除 PictureFrame 影像的裁切區域並回傳裁切後的影像
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 儲存結果
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法會將裁切後的影像加入簡報的影像集合中。若該影像僅用於已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/)，此設定可減少簡報大小；否則最終簡報中的影像數量會增加。

此方法在裁切過程中會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 影像。 
{{% /alert %}} 

## **壓縮影像**

您可以使用 [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) 方法壓縮簡報中的圖片。此方法會根據形狀尺寸與指定的解析度縮減影像大小，並可選擇刪除裁切區域。

它會調整圖片的大小與解析度，類似 PowerPoint 的 **圖片格式 -> 壓縮圖片 -> 解析度** 功能。

以下 Java 範例示範如何透過指定目標解析度並選擇性刪除裁切區域來壓縮簡報中的影像：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 使用目標解析度 150 DPI（網路解析度）壓縮影像並移除裁切區域。
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // 檢查壓縮結果。
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

    // 壓縮影像至 150 DPI（網路解析度），並移除裁切區域。
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
此方法會根據形狀尺寸與提供的 DPI 將影像轉換為較低解析度。裁切區域亦可被刪除以優化檔案大小。  
若影像為中繪檔 (WMF/EMF) 或 SVG，則不會套用壓縮。JPEG 的品質則會根據解析度保留或稍微降低，類似 PowerPoint 處理高解析度 JPEG 的方式。 
{{% /alert %}} 

## **鎖定長寬比**

若您希望包含影像的形狀在變更影像尺寸後仍保持長寬比，可使用 [setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 方法設定 *Lock Aspect Ratio*。

以下 Java 程式碼說明如何鎖定形狀的長寬比：

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

    // 設定形狀在調整大小時保持長寬比例
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
此 *Lock Aspect Ratio* 設定僅保留形狀的長寬比，而非其內含影像的長寬比。 
{{% /alert %}} 

## **使用 StretchOff 屬性**

使用 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPictureFillFormat) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPictureFillFormat) 類別的 [StretchOffsetLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) 及 [StretchOffsetBottom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) 屬性，您可以指定填充矩形。

當為影像指定拉伸時，來源矩形會依比例縮放以符合指定的填充矩形。填充矩形的每一邊皆以相對於形狀邊界盒相應邊緣的百分比偏移來定義。正百分比表示內縮，負百分比表示外凸。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 新增一個矩形 `AutoShape`。  
4. 建立影像。  
5. 設定形狀的填充類型。  
6. 設定形狀的圖片填充模式。  
7. 新增設定的影像以填充形狀。  
8. 指定影像相對於形狀邊界盒相應邊緣的偏移。  
9. 將修改後的簡報寫入為 PPTX 檔案。  

以下 Java 程式碼示範使用 StretchOff 屬性的過程：

```java
import com.aspose.slides.*;

// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 實例化 ImageEx 類別
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 新增設定為矩形的 AutoShape
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 設定形狀的填充類型
    aShape.getFillFormat().setFillType(FillType.Picture);

    // 設定形狀的圖片填充模式
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // 設定圖片以填滿形狀
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 指定影像相對於形狀邊界盒相應邊緣的偏移
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    //Writes the PPTX file to disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

### 如何找出 PictureFrame 支援的影像格式？

Aspose.Slides 透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/) 的影像物件，同時支援點陣影像 (PNG、JPEG、BMP、GIF 等) 與向量影像 (例如 SVG)。支援的格式清單通常與投影片及影像轉換引擎的功能相互重疊。

### 加入大量大型影像會如何影響 PPTX 的大小與效能？

嵌入大型影像會增加檔案大小與記憶體使用量；透過連結影像可降低簡報大小，但需保持外部檔案可存取。Aspose.Slides 提供以連結方式加入影像的功能，以減少檔案大小。

### 如何防止影像物件被意外移動/調整大小？

可對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/#getPictureFrameLock--)（例如，停用移動或調整大小）。此鎖定機制於另一篇 [保護文章](/slides/zh-hant/java/applying-protection-to-presentation/) 中有說明，且支援包括 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/) 在內的多種形狀類型。

### 將簡報匯出為 PDF/影像時，SVG 向量的忠實度是否得以保留？

Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/) 提取原始 SVG 向量。當 [匯出為 PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/) 或 [點陣格式](/slides/zh-hant/java/convert-powerpoint-to-png/) 時，結果可能會依匯出設定而被點陣化；提取行為證實了原始 SVG 以向量形式儲存。
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
- 點陣圖影像
- 向量影像
- 裁切影像
- 裁切區域
- StretchOff 屬性
- 圖片框格式設定
- 圖片框屬性
- 相對縮放
- 影像效果
- 長寬比例
- 影像透明度
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 與 OpenDocument 簡報中加入圖片框。簡化工作流程並提升投影片設計。"
---
## **簡介**

圖片框是一個包含圖像的形狀——它就像相框裡的照片。

您可以透過圖片框將圖像加入投影片。這樣，您即可透過設定圖片框來格式化圖像。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免費的轉換器——[JPEG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓使用者能快速從圖像建立簡報。 
{{% /alert %}} 

## **建立圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 透過將圖像加入與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IImageCollection) 來建立 [IPPImage]() 物件，以填滿形狀。  
4. 指定圖像的寬度與高度。  
5. 透過參考投影片關聯的形狀物件所公開的 `AddPictureFrame` 方法，根據圖像的寬度與高度建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/PictureFrame)。  
6. 將包含圖片的圖片框加入投影片。  
7. 將修改後的簡報寫入為 PPTX 檔案。  

以下 Java 程式碼示範如何建立圖片框：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 實例化 Image 類別
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 新增一個圖片框，使用圖片相同的高度與寬度
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 將 PPTX 檔案寫入磁碟
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
圖片框可讓您快速依圖像建立投影片。將圖片框與 Aspose.Slides 的儲存選項結合使用，您可以操控輸入/輸出操作，將圖像從一種格式轉換為另一種格式。您可能想參考以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/java/conversion/image-to-jpg/)；轉換 [JPG to image](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-image/)；轉換 [JPG to PNG](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-png/)，轉換 [PNG to JPG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-jpg/)；轉換 [PNG to SVG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-svg/)，轉換 [SVG to PNG](https://products.aspose.com/slides/zh-hant/java/conversion/svg-to-png/)。 
{{% /alert %}}

## **建立相對縮放的圖片框**

透過調整圖像的相對縮放，您可以建立更複雜的圖片框。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 將圖像加入簡報的圖像集合。  
4. 透過將圖像加入與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IImageCollection) 來建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPPImage) 物件，以填滿形狀。  
5. 在圖片框中指定圖像的相對寬度與高度。  
6. 將修改後的簡報寫入為 PPTX 檔案。  

以下 Java 程式碼示範如何建立具有相對縮放的圖片框：

```java
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 實例化 Image 類別
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 新增圖片框，使用圖片相同的高度與寬度
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

## **從圖片框提取點陣圖影像**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/PictureFrame) 物件提取點陣圖影像，並將其儲存為 PNG、JPG 等格式。下方程式碼範例示範如何從文件「sample.pptx」提取影像並以 PNG 格式儲存。

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **從圖片框提取 SVG 影像**

當簡報在 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/) 形狀中放入 SVG 圖形時，Aspose.Slides for Java 讓您以完整保真度取回原始向量影像。透過遍歷投影片的形狀集合，您可以辨識每個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/)，檢查底層的 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 是否包含 SVG 內容，然後將該影像以本機 SVG 格式儲存至磁碟或串流。

以下程式碼範例示範如何從圖片框提取 SVG 影像：

```java
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

Aspose.Slides 允許您取得套用於影像的透明度效果。以下 Java 程式碼示範此操作：

```java
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

Aspose.Slides 允許您取得套用於影像的亮度與對比度效果。[ILuminance](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iluminance/) 介面代表此影像變換效果。

以下 Java 程式碼示範如何從圖片框取得亮度與對比度設定：

```java
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

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 透過將圖像加入與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IImageCollection) 來建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPPImage) 物件，以填滿形狀。  
4. 指定圖像的寬度與高度。  
5. 透過 [AddPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法，根據圖像的寬度與高度建立 `PictureFrame`，此方法由參考投影片關聯的 [IShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection) 物件公開。  
6. 將包含圖片的圖片框加入投影片。  
7. 設定圖片框的線條顏色。  
8. 設定圖片框的線條寬度。  
9. 以正值或負值旋轉圖片框。  
   * 正值會順時針旋轉影像。  
   * 負值會逆時針旋轉影像。  
10. 將圖片框（含圖片）加入投影片。  
11. 將修改後的簡報寫入為 PPTX 檔案。  

以下 Java 程式碼示範圖片框格式設定流程：

```java
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 實例化 Image 類別
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 新增與圖片相同高度與寬度的圖片框
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

{{% alert title="Tip" color="primary" %}}
Aspose 最近開發了免費的 [Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。若您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 影像，或是 [從相片建立格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，都可以使用此服務。 
{{% /alert %}}

## **將影像作為連結加入**

為了避免簡報檔案過大，您可以透過連結加入影像（或影片），而不是直接將檔案嵌入簡報。以下 Java 程式碼示範如何在佔位符內加入影像與影片：

```java
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

以下 Java 程式碼示範如何裁切投影片上現有的影像：

```java
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

    // 在投影片中新增圖片框
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // 裁切影像（百分比值）
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // 儲存結果
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **刪除圖片框的裁切區域**

如果您想刪除框內影像的裁切區域，可使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法。若不需要裁切，該方法會回傳原始影像。

以下 Java 程式碼示範此操作：

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 取得第一張投影片中的 PictureFrame
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
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法會將裁切後的影像加入簡報的圖像集合。若該影像僅在已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/) 中使用，這種設定可減少簡報大小。否則，最終簡報中的影像數量會增加。

此方法在裁切操作中會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 影像。 
{{% /alert %}}

## **壓縮影像**

您可以使用 [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) 方法壓縮簡報中的圖片。此方法會根據形狀大小與指定的解析度縮小影像尺寸，並可選擇刪除裁切區域。

它的運作方式類似 PowerPoint 的 **圖片格式 -> 壓縮圖片 -> 解析度** 功能。

以下 Java 範例示範如何透過指定目標解析度並選擇性刪除裁切區域來壓縮簡報中的影像：

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 以 150 DPI（網頁解析度）為目標解析度壓縮影像，並移除裁切區域。
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
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 將影像壓縮至 150 DPI（網頁解析度），並移除裁切區域。
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
此方法會根據形狀大小與提供的 DPI 降低影像解析度。也可以刪除裁切區域以優化檔案大小。  
若影像為 WMF/EMF 中繪圖檔或 SVG，則不會套用壓縮。JPEG 的品質會依解析度略有下降，與 PowerPoint 處理高解析度 JPEG 的方式相同。 
{{% /alert %}}

## **鎖定長寬比例**

若您希望包含影像的形狀在更改影像尺寸後仍保持長寬比例，可使用 [setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 方法設定 *Lock Aspect Ratio* 屬性。

以下 Java 程式碼示範如何鎖定形狀的長寬比例：

```java
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
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // 設定形狀在調整大小時保持長寬比例
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
此 *Lock Aspect Ratio* 設定僅保留形狀本身的長寬比例，而不會鎖定其內含的影像。 
{{% /alert %}}

## **使用 StretchOff 屬性**

利用 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPictureFillFormat) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPictureFillFormat) 類別的 [StretchOffsetLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) 及 [StretchOffsetBottom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) 屬性，您可以指定填充矩形。

當對影像指定拉伸時，來源矩形會被縮放以符合指定的填充矩形。每條填充矩形的邊緣皆以相對於形狀邊界框相應邊緣的百分比偏移來定義。正比例表示內縮，負比例表示外延。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 新增一個矩形 `AutoShape`。  
4. 建立影像。  
5. 設定形狀的填充類型。  
6. 設定形狀的圖片填充模式。  
7. 新增設定好的影像以填滿形狀。  
8. 指定影像相對於形狀邊界框相應邊緣的偏移。  
9. 將修改後的簡報寫入為 PPTX 檔案。  

以下 Java 程式碼示範使用 StretchOff 屬性的流程：

```java
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

    // 設定影像以填滿形狀
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 指定影像相對於形狀邊界框相應邊緣的偏移量
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // 將 PPTX 檔案寫入磁碟
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**如何找出 PictureFrame 支援的影像格式？**

Aspose.Slides 透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/) 的影像物件，支援點陣圖影像（PNG、JPEG、BMP、GIF 等）與向量影像（例如 SVG）。支援的格式清單通常與投影片與影像轉換引擎的功能相吻合。

**大量加入大型影像會如何影響 PPTX 的大小與效能？**

嵌入大型影像會增加檔案大小與記憶體使用量；以連結方式加入影像可降低簡報大小，但需要確保外部檔案仍可存取。Aspose.Slides 提供以連結方式加入影像的功能以減少檔案大小。

**如何防止影像物件被誤刪除或意外調整大小？**

對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/#getPictureFrameLock--)（例如停用移動或調整大小）。鎖定機制在形狀的 [保護文章](/slides/zh-hant/java/applying-protection-to-presentation/) 中有說明，且支援多種形狀類型，包括 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/)。 

**將簡報匯出為 PDF/影像時，SVG 向量的保真度是否保留？**

Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pictureframe/) 提取原始 SVG 向量。當 [匯出為 PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/) 或 [點陣格式](/slides/zh-hant/java/convert-powerpoint-to-png/) 時，結果可能會依匯出設定被點陣化；然而，提取行為證實原始 SVG 仍以向量形式保存。
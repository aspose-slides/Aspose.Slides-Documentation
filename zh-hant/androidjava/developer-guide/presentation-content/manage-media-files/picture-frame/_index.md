---
title: 管理 Android 上簡報中的圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/androidjava/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 新增圖像
- 建立圖像
- 擷取圖像
- 點陣圖像
- 向量圖像
- 裁切圖像
- 裁剪區域
- StretchOff 屬性
- 圖片框格式設定
- 圖片框屬性
- 相對比例
- 圖像效果
- 長寬比
- 圖像透明度
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 將圖片框新增至 PowerPoint 與 OpenDocument 簡報。簡化工作流程並提升投影片設計。"
---
## **簡介**

圖片框是一種包含圖像的形狀——就像框中的圖片。

您可以透過圖片框將圖像加入投影片。這樣，您可以透過格式化圖片框來格式化圖像。

{{% alert title="提示" color="primary" %}} 

Aspose 提供免費的轉換器——[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 和 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓使用者可以快速從圖像建立簡報。 

{{% /alert %}} 

## **建立圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 透過將圖像新增至與簡報物件相關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IImageCollection) 以建立 [IPPImage]() 物件，該物件將用於填充形狀。  
4. 指定圖像的寬度與高度。  
5. 透過參考投影片關聯的形狀物件所公開的 `AddPictureFrame` 方法，根據圖像的寬度與高度建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/PictureFrame)。  
6. 將包含圖片的圖片框新增至投影片。  
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
    
    // 新增圖片框，其尺寸與圖片的寬度和高度相同
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 將 PPTX 檔案寫入磁碟
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用相對比例建立圖片框**

透過調整圖像的相對縮放，可建立更複雜的圖片框。  

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 將圖像新增至簡報的圖像集合中。  
4. 透過將圖像新增至與簡報物件相關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IImageCollection) 以建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPPImage) 物件，該物件將用於填充形狀。  
5. 在圖片框中指定圖像的相對寬度與高度。  
6. 將修改後的簡報寫入為 PPTX 檔案。  

以下 Java 程式碼示範如何使用相對比例建立圖片框：

```java
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 實例化 Image 類別
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 新增與圖片等高寬的圖片框
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

## **從圖片框中擷取點陣圖像**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/PictureFrame) 物件中擷取點陣圖像，並儲存為 PNG、JPG 及其他格式。以下程式碼範例示範如何從文件「sample.pptx」中擷取圖像並存為 PNG 格式。

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

## **從圖片框中擷取 SVG 圖像**

當簡報包含放置於 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/) 形狀內的 SVG 圖形時，Aspose.Slides for Android（透過 Java）可讓您完整保留地取得原始向量圖像。透過遍歷投影片的形狀集合，您可以辨識每個 [PictureFrame]，檢查其底層的 [IPPImage] 是否包含 SVG 內容，然後將該圖像以原生 SVG 格式儲存至磁碟或串流。

以下程式碼範例示範如何從圖片框中擷取 SVG 圖像：

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

## **取得圖像的透明度**

Aspose.Slides 允許您取得套用於圖像的透明度效果。以下 Java 程式碼示範此操作：

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

## **圖片框格式設定**

Aspose.Slides 提供許多可套用於圖片框的格式設定選項。使用這些選項，您可以調整圖片框以符合特定需求。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 透過將圖像新增至與簡報物件相關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IImageCollection) 以建立 [IPPImage]() 物件，該物件將用於填充形狀。  
4. 指定圖像的寬度與高度。  
5. 透過參考投影片關聯的 [IShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 物件所公開的 [AddPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法，根據圖像的寬度與高度建立 `PictureFrame`。  
6. 將包含圖片的圖片框新增至投影片。  
7. 設定圖片框的線條顏色。  
8. 設定圖片框的線條寬度。  
9. 透過給予正值或負值來旋轉圖片框。  
   * 正值會使圖像順時針旋轉。  
   * 負值會使圖像逆時針旋轉。  
10. 將包含圖片的圖片框新增至投影片。  
11. 將修改後的簡報寫入為 PPTX 檔案。  

以下 Java 程式碼示範圖片框的格式設定過程：

```java
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 實例化 Image 類別
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 新增與圖片等高寬的圖片框
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 套用一些格式設定至 PictureFrameEx
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

{{% alert title="提示" color="primary" %}}

Aspose 最近開發了 [免費拼貼製作工具](https://products.aspose.app/slides/zh-hant/collage)。如果您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 圖像，或是 [從照片建立格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，皆可使用此服務。 

{{% /alert %}}

## **將圖像作為連結加入**

為了避免簡報檔案過大，您可以透過連結加入圖像（或影片），而非直接嵌入檔案。以下 Java 程式碼示範如何將圖像與影片加入占位區：

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

## **裁切圖像**

以下 Java 程式碼示範如何裁切投影片上的現有圖像：

```java
Presentation pres = new Presentation();
// 建立新的圖像物件
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 將 PictureFrame 新增至投影片
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // 裁切圖像（百分比值）
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

## **刪除圖片框的裁剪區域**

如果您想刪除框中圖像的裁剪區域，可以使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法。若不需裁剪，該方法會回傳原始圖像。

以下 Java 程式碼示範此操作：

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 從第一張投影片取得 PictureFrame
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 刪除 PictureFrame 圖像的裁剪區域並回傳裁剪後的圖像
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 儲存結果
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

[deletePictureCroppedAreas()] 方法會將裁剪後的圖像加入簡報的圖像集合。若圖像僅在已處理的 [PictureFrame] 中使用，則此設定可減少簡報大小；否則，最終簡報中的圖像數量會增加。  

此方法在裁剪操作中會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 圖像。 

{{% /alert %}}

## **壓縮圖像**

您可以使用 [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) 方法壓縮簡報中的圖片。此方法會根據形狀大小與指定的解析度縮減圖像大小，並可選擇刪除裁剪區域。  

它會調整圖片的尺寸與解析度，類似 PowerPoint 的 **圖片格式 > 壓縮圖片 > 解析度** 功能。  

以下 Java 範例示範如何透過指定目標解析度，並可選擇刪除裁剪區域，以壓縮簡報中的圖像：

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 以目標解析度 150 DPI（網路解析度）壓縮圖像，並移除裁剪區域。
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
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 壓縮圖像至 150 DPI（網路解析度），並移除裁剪區域。
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

此方法會根據形狀大小與提供的 DPI 將圖像轉換為較低解析度。亦可刪除裁剪區域以最佳化檔案大小。  
如果圖像為中繪檔（WMF/EMF）或 SVG，則不會套用壓縮。此外，JPEG 的品質會依解析度保留或稍微降低，類似 PowerPoint 處理高解析度 JPEG 的方式。 

{{% /alert %}}

## **鎖定長寬比**

如果您希望包含圖像的形狀在變更圖像尺寸後仍保留其長寬比，可使用 [setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 方法設定 *Lock Aspect Ratio*（鎖定長寬比）屬性。  

以下 Java 程式碼示範如何鎖定形狀的長寬比：

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

    // 設定形狀在調整大小時保留長寬比
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

此 *鎖定長寬比* 設定僅保留形狀本身的長寬比，而不會影響其所包含的圖像。 

{{% /alert %}}

## **使用 StretchOff 屬性**

使用 [StretchOffsetLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)、[StretchOffsetTop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--)、[StretchOffsetRight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) 以及 [StretchOffsetBottom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) 屬性（來自 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPictureFillFormat) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPictureFillFormat) 類別），您可以指定填充矩形。  

當為圖像指定拉伸時，來源矩形會依指定的填充矩形進行縮放。填充矩形的每一邊皆由相對於形狀邊界框相應邊緣的百分比偏移定義。正百分比表示內縮，負百分比表示外伸。  

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 新增一個矩形 `AutoShape`。  
4. 建立圖像。  
5. 設定形狀的填充類型。  
6. 設定形狀的圖片填充模式。  
7. 新增設定的圖像以填充形狀。  
8. 指定圖像相對於形狀邊界框相應邊緣的偏移量。  
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

    // 設定圖像以填充形狀
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 指定圖像相對於形狀邊界框相應邊緣的偏移量
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //將 PPTX 檔案寫入磁碟
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我如何查詢 PictureFrame 支援哪些圖像格式？**

Aspose.Slides 透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/) 的圖像物件，同時支援點陣圖（PNG、JPEG、BMP、GIF 等）與向量圖（例如 SVG）。支援的格式清單大致與投影片與圖像轉換引擎的功能相重疊。

**大量加入大型圖像會如何影響 PPTX 檔案大小與效能？**

嵌入大型圖像會增加檔案大小與記憶體使用量；以連結方式加入圖像則可降低簡報尺寸，但需確保外部檔案仍可存取。Aspose.Slides 提供透過連結加入圖像的功能，以減少檔案大小。

**我該如何鎖定圖像物件，以免誤觸移動/調整大小？**

可使用 [shape locks](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) 於 [PictureFrame]（例如，停用移動或調整大小）。此鎖定機制支援各種形狀類型，包括 [PictureFrame]。

**將簡報匯出為 PDF/圖像時，是否保留 SVG 向量的完整性？**

Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pictureframe/) 提取 SVG 作為原始向量。當 [匯出至 PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/) 或 [匯出至點陣格式](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 時，結果可能因匯出設定而被點陣化；然而，透過提取行為可確認原始 SVG 仍以向量方式儲存。
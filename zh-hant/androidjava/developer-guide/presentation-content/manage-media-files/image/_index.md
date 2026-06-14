---
title: 在 Android 上優化簡報的影像管理
linktitle: 管理影像
type: docs
weight: 10
url: /zh-hant/androidjava/image/
keywords:
- 新增影像
- 新增圖片
- 新增點陣圖
- 取代影像
- 取代圖片
- 來自網路
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- 新增 EMF
- 新增 WMF
- 新增 TIFF
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android（透過 Java）簡化 PowerPoint 與 OpenDocument 的影像管理，提升效能並自動化工作流程。"
---
## **簡介**

影像讓簡報更具吸引力與趣味。在 Microsoft PowerPoint 中，您可以從檔案、網路或其他位置將圖片插入投影片。類似地，Aspose.Slides 允許您透過多種方式將影像加入簡報的投影片中。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免費的轉換器——[JPEG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓使用者能快速從圖像建立簡報。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
如果您想將圖像作為框架物件加入——尤其是打算使用標準格式選項來調整大小、添加效果等——請參閱 [圖片框架](https://docs.aspose.com/slides/zh-hant/androidjava/picture-frame/)。
{{% /alert %}} 

Aspose.Slides 支援在這些常見格式（JPEG、PNG、GIF 等）中對影像進行操作。

## **在本機儲存的影像加入投影片**

您可以將電腦上的一張或多張影像加入簡報的投影片中。以下 Java 範例碼示範如何將影像加入投影片：

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **從網路加入影像至投影片**

如果您想加入投影片的影像在電腦上不存在，您可以直接從網路加入該影像。  
以下範例碼示範如何在 Java 中從網路將影像加入投影片：

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **將影像加入投影片母片**

投影片母片是位於最上層的投影片，負責儲存與控制其下所有投影片的資訊（主題、版面配置等）。因此，將影像加入投影片母片後，該影像會出現在該母片所屬的所有投影片上。  
以下 Java 範例碼示範如何將影像加入投影片母片：

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **將影像設為投影片背景**

您可能會決定將圖片作為特定投影片或多張投影片的背景。在此情況下，請參考 *[將影像設定為投影片背景](https://docs.aspose.com/slides/zh-hant/androidjava/presentation-background/#setting-images-as-background-for-slides)*。

## **將 SVG 加入簡報**

您可以使用屬於 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 介面的 [addPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法，將任何影像加入或插入簡報中。  
若要根據 SVG 圖像建立影像物件，您可以這樣做：

1. 建立 SvgImage 物件以插入至 ImageShapeCollection
2. 從 ISvgImage 建立 PPImage 物件
3. 使用 IPPImage 介面建立 PictureFrame 物件

以下範例碼示範如何實作上述步驟，將 SVG 圖像加入簡報：

```java 
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **將 SVG 轉換為多個形狀**

Aspose.Slides 將 SVG 轉換為多個形狀的功能類似於 PowerPoint 處理 SVG 圖像的功能：

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 介面的其中一個 [addGroupShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) 方法的多載提供，該方法以 [ISvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISvgImage) 物件作為第一個參數。  
以下範例碼示範如何使用上述方法將 SVG 檔案轉換為多個形狀：

```java 
// 建立新的簡報
IPresentation presentation = new Presentation();
try {
    // 讀取 SVG 檔案內容
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // 建立 SvgImage 物件
    ISvgImage svgImage = new SvgImage(svgContent);

    // 取得投影片尺寸
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // 將 SVG 圖片轉換為形狀群組，並依投影片尺寸縮放
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // 以 PPTX 格式儲存簡報
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **將影像以 EMF 形式加入投影片**

Aspose.Slides for Android（透過 Java）允許您從 Excel 工作表產生 EMF 影像，並使用 Aspose.Cells 將這些影像以 EMF 形式加入投影片中。  
以下範例碼示範如何執行上述任務：

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//將活頁簿儲存至資料流
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **取代影像集合中的影像**

Aspose.Slides 讓您取代儲存在簡報影像集合中的影像（包括投影片形狀使用的影像）。本節示範了更新集合中影像的多種方法。API 提供直接的方式，可使用原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 實例，或集合中已存在的其他影像來取代影像。  
請依照以下步驟：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別載入包含影像的簡報檔案。
1. 從檔案載入新影像至位元組陣列。
1. 使用位元組陣列將目標影像取代為新影像。
1. 在第二種方法中，將影像載入 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 物件，並以該物件取代目標影像。
1. 在第三種方法中，使用已存在於簡報影像集合中的影像取代目標影像。
1. 將修改後的簡報寫入為 PPTX 檔案。

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 第一種方式。
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // 第二種方式。
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // 第三種方式。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // 將簡報儲存至檔案。
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
使用 Aspose FREE [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆為文字製作動畫、從文字建立 GIF 等。 
{{% /alert %}}

## **常見問題**

**插入後原始影像解析度是否保持不變？**

是的。來源像素被保留，但最終呈現取決於投影片上 [圖片](/slides/zh-hant/androidjava/picture-frame/) 的縮放方式以及儲存時的壓縮情形。

**一次性在數十張投影片中取代相同標誌的最佳方法是什麼？**

將標誌放置於母片或版面配置上，並在簡報的影像集合中取代它——更新將會套用到所有使用該資源的元件。

**插入的 SVG 可以轉換成可編輯的形狀嗎？**

可以。您可以將 SVG 轉換為一組形狀，之後各個部件即可使用標準形狀屬性進行編輯。

**如何一次性為多張投影片設定圖片為背景？**

在母片或相關版面配置上 [指定影像為背景](/slides/zh-hant/androidjava/presentation-background/)，使用該母片/版面的所有投影片都會繼承此背景。

**如何防止因大量圖片導致簡報檔案大小「膨脹」？**

重複使用單一影像資源而非多個副本，選擇合理的解析度，儲存時套用壓縮，並在適當情況下將重複的圖形放在母片上。
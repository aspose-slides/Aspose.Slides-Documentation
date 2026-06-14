---
title: 使用 Java 優化簡報中的圖像管理
linktitle: 管理圖像
type: docs
weight: 10
url: /zh-hant/java/image/
keywords:
- 新增圖像
- 新增圖片
- 新增點陣圖
- 取代圖像
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
- EMF
- SVG
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 簡化 PowerPoint 和 OpenDocument 中的圖像管理，提升效能並自動化工作流程。"
---
## **簡介**

圖片讓簡報更具吸引力且更有趣味。在 Microsoft PowerPoint 中，您可以從檔案、網路或其他位置將圖片插入投影片。類似地，Aspose.Slides 也允許您透過不同的方式將圖片加入簡報的投影片中。

{{% alert  title="Tip" color="primary" %}} 

Aspose 提供免費的轉換工具——[JPEG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——可讓使用者快速從圖片建立簡報。

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

如果您想將圖片作為框架物件加入—尤其是想對其使用標準格式化選項來調整大小、加入效果等—請參考 [Picture Frame](https://docs.aspose.com/slides/zh-hant/java/picture-frame/)。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

您可以操作涉及圖片與 PowerPoint 簡報的輸入/輸出，以將圖片從一種格式轉換為另一種格式。請參閱以下頁面：將 [image 轉換為 JPG](https://products.aspose.com/slides/zh-hant/java/conversion/image-to-jpg/)；將 [JPG 轉換為 image](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-image/)；將 [JPG 轉換為 PNG](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-png/)、將 [PNG 轉換為 JPG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-jpg/)；將 [PNG 轉換為 SVG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-svg/)、將 [SVG 轉換為 PNG](https://products.aspose.com/slides/zh-hant/java/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slides 支援以下常見格式的圖片操作：JPEG、PNG、GIF 等。

## **將本機儲存的圖片新增至投影片**

您可以將電腦上的一張或多張圖片加入簡報的投影片中。以下 Java 範例程式碼展示如何將圖片新增至投影片：

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

## **將網路圖片新增至投影片**

如果您想加入的圖片在電腦上找不到，亦可直接從網路將圖片加入投影片。

以下範例程式碼示範如何在 Java 中將網路圖片加入投影片：

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

## **將圖片新增至投影片母片**

投影片母片是儲存並控制其下所有投影片資訊（主題、版面配置等）的最高層投影片。因此，將圖片加入投影片母片後，該圖片會出現在該母片下的所有投影片上。

以下 Java 範例程式碼展示如何將圖片新增至投影片母片：

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

## **將圖片設定為投影片背景**

您可能會決定將圖片作為特定投影片或多張投影片的背景。在此情況下，請參閱 *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/zh-hant/java/presentation-background/#setting-images-as-background-for-slides)*。

## **將 SVG 新增至簡報**
您可以使用屬於 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection) 介面的 [addPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法，將任何圖片新增或插入至簡報中。

若要根據 SVG 圖片建立圖片物件，可按以下方式進行：

1. 建立 SvgImage 物件以插入至 ImageShapeCollection  
2. 從 ISvgImage 建立 PPImage 物件  
3. 使用 IPPImage 介面建立 PictureFrame 物件  

以下範例程式碼示範如何實作上述步驟，將 SVG 圖片加入簡報中：
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

## **將 SVG 轉換為一組圖形**
Aspose.Slides 將 SVG 轉換為一組圖形的功能類似於 PowerPoint 處理 SVG 圖片的功能：

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection) 介面中 [addGroupShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) 方法的其中一個多載提供，該方法的第一個參數接受 [ISvgImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISvgImage) 物件。

以下範例程式碼展示如何使用上述方法將 SVG 檔案轉換為一組圖形：

```java 
// 建立新簡報
IPresentation presentation = new Presentation();
try {
    // 讀取 SVG 檔案內容
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // 建立 SvgImage 物件
    ISvgImage svgImage = new SvgImage(svgContent);

    // 取得投影片大小
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // 將 SVG 圖片轉換為形狀群組，並依投影片大小縮放
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // 以 PPTX 格式儲存簡報
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **將圖片以 EMF 形式新增至投影片**
Aspose.Slides for Java 允許您從 Excel 工作表產生 EMF 圖片，並透過 Aspose.Cells 將 EMF 圖片加入投影片。

以下範例程式碼示範如何執行上述工作：

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//將活頁簿儲存至串流
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

## **取代圖像集合中的圖片**

Aspose.Slides 讓您可以取代簡報圖像集合中儲存的圖片（包括投影片形狀使用的圖片）。本節展示了更新集合中圖片的多種方法。API 提供直接的方法，讓您能以原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 實例，或集合中已存在的其他圖片來取代圖片。

請依照以下步驟操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別載入包含圖片的簡報檔案。  
2. 從檔案載入新圖片至位元組陣列。  
3. 使用位元組陣列將目標圖片取代為新圖片。  
4. 在第二種做法中，將圖片載入為 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iimage/) 物件，並以該物件取代目標圖片。  
5. 在第三種做法中，使用簡報圖像集合中已存在的圖片取代目標圖片。  
6. 將修改後的簡報寫出為 PPTX 檔案。

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 第一種方式。
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
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

使用 Aspose 免費的 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆為文字製作動畫、從文字建立 GIF 等。

{{% /alert %}}

## **常見問題**

**插入後原始圖片解析度是否保持不變？**

是。來源像素會被保留，但最終外觀取決於投影片上 [picture](/slides/zh-hant/java/picture-frame/) 的縮放方式以及儲存時所使用的壓縮。

**一次要在大量投影片中取代相同的標誌，最佳方式是什麼？**

將標誌放在母片或版面配置上，然後在簡報的圖像集合中取代它——更新將會傳播至所有使用該資源的元素。

**插入的 SVG 能否轉換為可編輯的圖形？**

可以。您可以將 SVG 轉換為一組圖形，之後各個部分即可使用標準圖形屬性進行編輯。

**如何一次為多張投影片設定相同的背景圖片？**

在母片或相關版面配置上 [Assign the image as the background](/slides/zh-hant/java/presentation-background/)，所有使用該母片/版面的投影片都會繼承此背景。

**如何防止大量圖片導致簡報檔案尺寸「膨脹」？**

重複使用單一圖片資源而非多個副本，選擇合理的解析度，在儲存時使用壓縮，並在適當時將重複圖形放在母片上。
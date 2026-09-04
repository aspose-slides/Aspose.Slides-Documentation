---
title: 使用現代 API 在 Python 中提升影像處理
linktitle: 現代 API
type: docs
weight: 237
url: /zh-hant/python-java/modern-api/
keywords:
- 現代 API
- 繪圖
- 投影片縮圖
- 投影片轉圖像
- 形狀縮圖
- 形狀轉圖像
- 簡報縮圖
- 簡報轉圖像
- 新增影像
- 新增圖片
- Python
- Java
- Aspose.Slides
description: "透過 Java 的 Python 版 Aspose.Slides 現代 API，將影像處理現代化：渲染投影片與形狀、加入圖片，並將已棄用的影像呼叫遷移至 Aspose.Slides 現代 API。"
---
## **簡介**

Aspose.Slides for Python via Java 通過 JPype 存取 Java 函式庫。其舊有的影像處理 API 使用來自 `java.awt` 的 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 與 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)。

Java 函式庫自 24.4 版起已棄用這些影像 API。現代 API 使用 [IImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/) 來載入、呈現與儲存影像。請在新 Python 程式碼以及遷移既有影像處理工作流程時使用它。

{{% alert color="info" title="Note" %}}
以下舊方法名稱僅供遷移參考。它們已不再於目前版本中提供。可執行範例使用現代 API。
{{% /alert %}}

此變更並未移除所有 `java.awt` 型別：影像大小與圖案色彩的多載仍接受 [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) 與 [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html)。

## **現代 API**

主要的影像處理型別包括：

- [IImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/) — 表示光柵或向量影像。
- [ImageFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imageformat/) — 提供影像檔案格式常數。
- [Images](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/images/) — 建立影像，例如使用 [Images.fromFile](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/images/#fromFile)。

使用 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 或 [Shape.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage) 來呈現單一投影片或形狀。使用 [Presentation.getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages) 搭配呈現選項以一次渲染多張投影片。未傳入參數的多載會回傳簡報的影像集合。

透過 [Images.fromFile](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/images/#fromFile) 載入影像，使用 [ImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagecollection/#addImage) 加入，或使用 [PPImage.replaceImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/#replaceImage) 更新既有簡報影像。兩種影像集合操作皆接受 [IImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/)。

在 `finally` 區塊中呼叫每張載入或呈現的影像的 `dispose` 方法以釋放資源。使用 [Presentation.dispose](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#dispose) 釋放簡報。

### **準備 Python 環境**

依照 [Installation](/slides/zh-hant/python-java/installation/) 中的說明安裝套件。每個範例在啟動 JVM 前先匯入 `asposeslides`，然後在 JVM 執行中匯入 API。範例會保留 JVM 執行，以便重複使用。請參閱 [Limitations and API Differences](/slides/zh-hant/python-java/limitations-and-api-differences/#import-the-library) 取得筆記本與 JVM 生命週期的指引。

需要在工作目錄中放置 `pres.pptx` 的範例必須有簡報檔。需要載入 `image.png` 的範例則必須已有影像檔。

### **載入圖片並呈現投影片**

此範例將圖片加入第一張投影片，並將投影片儲存為 JPEG 影像。[IImage.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/#save) 會以指定格式寫入渲染後的影像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **以現代 API 取代舊程式碼**

將舊有的縮圖呼叫換成回傳 [IImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/) 的方法，然後使用 [IImage.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/#save) 儲存結果。這樣即可省去將渲染影像傳遞給 [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-) 的步驟。

### **以指定大小呈現投影片**

將舊的 `slide.getThumbnail(image_size)` 呼叫改為使用相同影像大小的 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **取得投影片縮圖**

將舊的 `slide.getThumbnail()` 呼叫改為不帶參數的 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **取得形狀縮圖**

將舊的 `shape.getThumbnail()` 呼叫改為 [Shape.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage)。在存取之前，請先確認投影片中確實包含該形狀。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **取得簡報縮圖**

將舊的 `presentation.getThumbnails(options, image_size)` 呼叫改為使用 [Presentation.getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages)。使用 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/renderingoptions/) 來配置呈現設定。

直接使用 Python 的 `enumerate` 迭代回傳的陣列。於 `finally` 區塊中釋放每張回傳的影像，以防儲存失敗時留下未釋放的影像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **將圖片加入簡報**

將透過 [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) 載入的方式改為使用 [Images.fromFile](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/images/#fromFile)，然後將取得的影像傳遞給 [ImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagecollection/#addImage)。將圖片加入投影片後儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **已棄用的方法與現代 API 的取代方式**

表格使用 Python 呼叫語法。舊欄位列出已移除的 API；請使用連結的取代方法。現代的影像呈現方法會回傳 [IImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/) 物件，而非 Java 緩衝影像。

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages) 在傳入呈現選項時會回傳已渲染影像的陣列。

| 舊版呼叫 | 現代取代 |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages) 使用 `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages) 使用 `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages) 使用 `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages) 使用 `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages) 使用 `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages) 使用 `options, image_size` |

此處的 `slides` 為 Java `int[]`（以 1 為起始索引）的投影片編號；可使用 `jpype.JArray(jpype.JInt)([1, 3])` 產生，以選取第 1 與第 3 張投影片。`image_size` 為 [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html)。

### **Shape**

| 舊版呼叫 | 現代取代 |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage) 不帶參數 |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage) 使用 `bounds, scale_x, scale_y` |

### **Slide**

| 舊版呼叫 | 現代取代 |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 不帶參數 |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 使用 `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 使用 `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 使用 `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 使用 `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 使用 `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 使用 `image_size` |
| `slide.renderToGraphics(options, graphics)` | 無直接取代；請改為渲染為影像 |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | 無直接取代；請改為渲染為影像 |
| `slide.renderToGraphics(options, graphics, image_size)` | 無直接取代；請改為渲染為影像 |

此處的 `options` 為 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/renderingoptions/)，`tiff_options` 為 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/)。

### **Output**

| 舊版呼叫 | 現代取代 |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/output/#add) 使用 `path, image`，其中 `image` 為 [IImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| 舊版呼叫 | 現代取代 |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagecollection/#addImage) 使用 [IImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/) |

### **PPImage**

| 舊版呼叫 | 現代取代 |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/#getImage) |

若要取代既有簡報影像的內容，請使用 [PPImage.replaceImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/#replaceImage) 並傳入 [IImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/)。

### **PatternFormat**

| 舊版呼叫 | 現代取代 |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/patternformat/#getTile) 使用 `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/patternformat/#getTile) 使用 `background, foreground` |

顏色參數仍為 Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html) 物件。

### **PatternFormatEffectiveData**

對於透過 JPype 從 Java API 取得的有效圖案資料，取代方法仍保留名稱 `getTileIImage`。

| 舊版呼叫 | 現代取代 |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`，回傳 [IImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/) |

## **Graphics2D 的 API 支援**

舊的 `renderToGraphics` 多載會在呼叫端提供的 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 內容中繪製。現代 API 並未提供直接繪製至該內容的取代方案。

請使用 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 來呈現單張投影片，或使用 [Presentation.getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages) 來呈現多張投影片，然後以 [IImage.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/#save) 儲存回傳的影像。需要將投影片渲染與自訂 Java 繪圖結合的應用程式，必須調整其合成步驟。

## **常見問答**

**為什麼會取代舊的 Java 影像 API？**

現代 API 將影像的載入、呈現與儲存都移至 [IImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/iimage/)。這為這些工作流程提供了統一的影像抽象層，而不再直接暴露 Java 緩衝影像或 Java 繪圖內容。

**我仍然需要 Java 與 JPype 嗎？**

需要。Aspose.Slides for Python via Java 仍然在 JVM 上執行。現代 API 只改變影像處理的呼叫方式，執行需求保持不變。請參閱 [System Requirements](/slides/zh-hant/python-java/system-requirements/)。

**如何在 Python 中釋放影像？**

在 `finally` 區塊中對每張載入或呈現的影像呼叫 `dispose`。若一次渲染多張投影片，請釋放回傳陣列中的每張影像。然後使用 [Presentation.dispose](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#dispose) 釋放簡報本身。

**切換到現代 API 是否保證縮圖產生更快？**

不保證效能提升。取代方法支援呈現選項、縮放與影像大小，實際效能仍需依您的簡報與輸出設定自行量測。

**為什麼影像取得方法有時會回傳集合？**

未傳入參數呼叫的 [Presentation.getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages) 會回傳內嵌於簡報的影像集合。傳入呈現選項的多載則會回傳已渲染的投影片影像。
---
title: 使用 Python 優化簡報中的圖像管理
linktitle: 管理圖像
type: docs
weight: 10
url: /zh-hant/python-net/image/
keywords:
- 新增圖像
- 新增圖片
- 替換圖像
- 圖像集合
- 圖片框
- 連結圖像
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- SVG 轉圖形
- 外部 SVG 資源
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中新增、重複使用、連結、替換與管理點陣圖與 SVG 圖像。"
---
## **簡介**

Aspose.Slides for Python via .NET 提供了多種操作圖像的方式，每種方式都有其不同的用途。您可以將圖像儲存在簡報中、在圖片框中顯示、作為投影片背景、連結到外部圖像、替換共享的圖像資源，或將 SVG 內容轉換為可編輯的圖形。

本文聚焦於圖像資源以及它們在整個簡報中的使用方式。若要了解對單一圖片框進行裁剪、透明度、效果、拉伸等格式設定，請參閱 [圖片框](/slides/zh-hant/python-net/picture-frame/)。

## **了解圖像模型**

以下 API 概念密切相關但不可互換：

- 簡報圖像集合（[presentation image collection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/)）儲存簡報使用的圖像資源。使用 [ImageCollection.add_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/add_image/) 新增圖像資料並取得 [IPPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ippimage/) 資源。
- 圖片框（[picture frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ipictureframe/)）是一個在投影片、版面或母片上顯示圖像的形狀。使用 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_picture_frame/) 將圖像資源放置於投影片。
- 投影片背景使用圖像作為投影片填充的一部分，而非作為形狀。因此其行為不同於圖片框。
- [IPPImage.replace_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ippimage/replace_image/) 可替換圖像資源。如果多個簡報元素使用該資源，全部都會使用替換後的圖像。
- 將 SVG 轉換為圖形會產生可編輯的投影片圖形。轉換後，內容不再作為單一圖片資源管理。

典型的工作流程如下：將圖像資料加入圖像集合，取得一個 [IPPImage]，然後在一個或多個圖片框或填充中使用該資源。

## **新增嵌入式圖像**

要插入本機圖像，請讀取檔案、將其資料加入圖像集合，並建立使用返回的 `IPPImage` 的圖片框。

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

以此方式加入的圖像會嵌入簡報中，因而最終檔案不依賴原始圖像檔仍然可用。

### **從網路新增圖像**

當圖像可透過 HTTP 或 HTTPS 取得時，下載其位元組、將它們加入簡報圖像集合，並以與本機圖像相同的方式使用返回的圖像資源。

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

在長時間執行的應用程式中，請酌情重複使用 HTTP 用戶端或連線池，而非為每個請求建立新連線。當來源不受信任時，亦請驗證遠端 URL、回應大小與內容類型。

## **跨投影片重複使用圖像**

如果同一圖像需要使用多次，請僅在簡報中加入一次，然後在建立其他圖片框時重用返回的 [IPPImage]。這可避免重複載入相同的來源資料，並使共享圖像資源與其使用情形更為明確。

對於應自動出現在多張投影片上的圖形（例如公司商標），建議將圖片框放在 [投影片母片](/slides/zh-hant/python-net/slide-master/) 或版面上，而不是在每張投影片中加入等效形狀。

## **將圖像作為投影片背景使用**

背景圖像會指定給投影片填充；它不是以圖片框形狀加入。當圖像需要覆蓋整個投影片背景且不應被當作普通投影片物件操作時，這種做法相當有用。

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

欲取得更多背景選項（包括母片與版面背景），請參閱 [簡報背景](/slides/zh-hant/python-net/presentation-background/)。

## **嵌入式圖像與連結圖像**

嵌入式與連結圖像在可移植性與檔案大小上各有取捨：

- **嵌入式圖像**：圖像資料儲存在簡報內。簡報是自包含的，但檔案大小會包含圖像資料。
- **連結圖像**：簡報僅儲存指向外部圖像的路徑或 URL。這可以減少簡報大小，但外部資源必須在開啟或轉譯簡報時仍可存取。

可以透過 [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/islidespicture/link_path_long/) 指定外部路徑或 URL，來建立連結圖片，而非嵌入圖像資料。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

僅在部署環境能可靠存取外部資源時才使用連結圖像。對於必須離線使用或在不同系統間搬遷的簡報，嵌入式圖像通常較為安全。

## **使用 SVG 圖像**

SVG 為向量格式，適用於圖示、圖表以及其他需要在不失真情況下縮放的圖形。Aspose.Slides 同時支援 SVG 作為圖像資源與可編輯的投影片圖形來源。

### **將 SVG 作為圖像新增**

建立 [SvgImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/)，將其加入圖像集合，並將產生的圖像資源放入圖片框。

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **將 SVG 轉換為可編輯圖形**

Aspose.Slides 可以將 SVG 轉換為一組可編輯的投影片圖形，類似對應的 PowerPoint 指令。

![PowerPoint Popup Menu](img_01_01.png)

使用接受 [ISvgImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/isvgimage/) 的 [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_group_shape/) 重載來執行轉換。

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

當需要將單獨的向量元素編輯為 PowerPoint 圖形時，請使用 SVG 轉圖形的方式。若 SVG 僅需顯示，保留為圖像較為簡單，亦可避免產生大量獨立圖形。

## **替換現有圖像資源**

當您想要替換現有圖像資源時，使用 [IPPImage.replace_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ippimage/replace_image/)。此功能對於共享圖形（例如商標）特別有用。

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

如果多個圖片框、背景、母片或版面使用相同的圖像資源，替換該資源會同時更新全部使用處。若僅需變更單一圖片框，請為該框指派不同的圖像，而非替換共享資源。

`replace_image` 亦提供接受 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 或另一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ippimage/) 的重載。

## **實務圖像管理建議**

### **控制簡報尺寸**

大型點陣圖會使簡報尺寸過大。請使用與預期顯示尺寸相稱的來源圖像、盡可能重複使用共享圖像資源，並避免嵌入相同全解析度圖形的多個副本。

對於已放入圖片框的點陣圖，您可以使用 [PictureFillFormat.compress_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/compress_image/) 依選取的解析度與裁切設定壓縮圖像資料。這屬於圖片框處理而非圖像集合管理，相關格式化操作請參閱 [圖片框](/slides/zh-hant/python-net/picture-frame/)。

### **在嵌入與連結內容之間做選擇**

嵌入使簡報可攜，因為所有必需的圖像資料都隨檔案一起傳遞。連結可減少檔案大小，但會產生外部相依性。僅在相依性可接受且穩定時才使用連結。

### **重複使用共享品牌圖示**

對於重複出現的商標、水印或裝飾圖形，請使用單一圖像資源並重複使用。若圖形屬於簡報設計而非投影片內容，請將其放在母片或版面上，以便被相應投影片繼承。

### **保持 SVG 資源可移植**

自包含的 SVG 比依賴外部檔案或網路資源的 SVG 更易搬移與一致渲染。若可能，請在匯入 SVG 前先嵌入所需資源。僅在需要編輯個別向量元素時才將 SVG 轉為圖形。

### **使用現代跨平台圖像 API**

對於新的 Python via .NET 程式碼，請使用 Aspose.Slides 的 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 與 [Images](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/images/) API，取代已棄用的 `aspose.pydrawing.Image` 或 `aspose.pydrawing.Bitmap` 圖像 API。遷移指南請參閱 [現代 API](/slides/zh-hant/python-net/modern-api/)。

WMF 與 EMF 需要特別考量。當這些格式透過 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 傳遞時，[ImageCollection.add_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/add_image/) 會先將中繼檔轉換為點陣 PNG 後再插入。如果必須保留中繼檔資料，請改用以串流為參數的 [ImageCollection.add_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imagecollection/add_image/) 重載。從試算表或其他產品產生 EMF 內容屬於獨立的整合工作流程，本文不予討論。

## **常見問題**

**圖像集合與圖片框有何差別？**

圖像集合儲存可重複使用的圖像資源。圖片框則是投影片形狀，用於顯示其中一個資源，並提供裁切、效果等圖片專屬的格式設定。

**要在所有位置替換相同的商標，最佳方式是？**

若商標已作為單一圖像資源共享，請使用 [IPPImage.replace_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ippimage/replace_image/) 替換該資源。若欲於整個簡報進行品牌統一，也可將商標放在母片或版面上，以減少重複的投影片內容。

**為何連結圖像在其他電腦上會消失？**

連結圖片依賴其外部檔案或 URL。如果該資源在其他電腦上無法存取，連結圖像就會無法顯示。當簡報必須自包含時，請將圖像嵌入。

**插入的 SVG 可以編輯成 PowerPoint 圖形嗎？**

可以。使用 [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_group_shape/) 轉換 SVG；產生的群組包含可編輯的投影片圖形，而非單一 SVG 圖片。

**如何讓含有大量圖像的簡報保持較小？**

重複使用共享圖像資源、避免使用過大的點陣來源、在適當時壓縮點陣圖、將重覆的品牌圖示放在母片或版面上，並僅在外部依賴可接受時使用連結圖像。
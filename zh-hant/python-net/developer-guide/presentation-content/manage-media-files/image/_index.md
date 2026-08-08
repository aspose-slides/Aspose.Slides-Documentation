---
title: 使用 Python 在 PowerPoint 中最佳化影像管理
linktitle: 管理影像
type: docs
weight: 10
url: /zh-hant/python-net/image/
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
- Python
- Aspose.Slides
description: "透過 Aspose.Slides for Python 於 .NET，簡化 PowerPoint 與 OpenDocument 的影像管理，提升效能並自動化工作流程。"
---
## **簡介**

圖片讓簡報更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以從檔案、網路或其他來源將圖片插入投影片。類似地，Aspose.Slides 允許您以多種方式向投影片添加圖片。

{{% alert  title="提示" color="primary" %}}
Aspose 提供免費的轉換器—[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 和 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)—讓您能快速從圖片建立簡報。
{{% /alert %}}

{{% alert title="資訊" color="info" %}}
如果您想將圖片作為框架物件新增——特別是計畫使用如調整大小或套用效果等標準格式選項——請參閱 [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/zh-hant/python-net/picture-frame/)。
{{% /alert %}}

{{% alert title="注意" color="warning" %}}
您可以使用影像與簡報的 I/O 操作在不同格式之間轉換影像。請參閱以下頁面：將 [圖片轉 JPG](https://products.aspose.com/slides/zh-hant/python-net/conversion/image-to-jpg/) 轉換；將 [JPG 轉 圖片](https://products.aspose.com/slides/zh-hant/python-net/conversion/jpg-to-image/) 轉換；將 [JPG 轉 PNG](https://products.aspose.com/slides/zh-hant/python-net/conversion/jpg-to-png/) 轉換；將 [PNG 轉 JPG](https://products.aspose.com/slides/zh-hant/python-net/conversion/png-to-jpg/) 轉換；將 [PNG 轉 SVG](https://products.aspose.com/slides/zh-hant/python-net/conversion/png-to-svg/) 轉換；以及將 [SVG 轉 PNG](https://products.aspose.com/slides/zh-hant/python-net/conversion/svg-to-png/) 轉換。
{{% /alert %}}

Aspose.Slides 支援使用 JPEG、PNG、BMP、GIF 等常見格式的圖片。

## **將本機儲存的圖片新增至投影片**

您可以從電腦將一張或多張圖片加入簡報中的投影片。以下 Python 範例說明如何將圖片新增至投影片：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **從網路新增圖片至投影片**

如果您想加入的圖片並未存於電腦中，亦可直接從網路插入。

以下 Python 範例說明如何從 URL 新增圖片至投影片：

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 下載原始圖片位元組。
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **將圖片新增至投影片母片**

投影片母片是最上層的投影片，負責儲存與控制所有子投影片的資訊——主題、版面配置等。當您在投影片母片上加入圖片時，該圖片會出現在所有使用此母片的投影片上。

以下 Python 範例說明如何將圖片新增至投影片母片：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **將圖片設定為投影片背景**

您可以將圖片用作一張或多張投影片的背景。欲了解更多資訊，請參閱 *[Setting Images as Backgrounds for Slides](/slides/zh-hant/python-net/presentation-background/#setting-images-as-background-for-slides)*。

## **將 SVG 新增至簡報**

可使用 [SvgImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/) 類別將 SVG 內容加入簡報。產生的 SVG 圖片可再加入簡報的圖像集合，並用於建立圖片框架。

以下 Python 範例匯入一段自包含的 SVG 字串。此 SVG 內的所有圖像、樣式與其他資源皆直接嵌入於 SVG 內容中。

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **將 SVG 轉換為形狀集合**

Aspose.Slides 會將 SVG 轉換為形狀集合，方式類似 PowerPoint 的 SVG 處理機制。

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/) 類別中的 [add_group_shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_group_shape/) 方法的多載提供，該方法的第一個參數接受 [SvgImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/)。

以下範例程式碼示範如何將 SVG 檔案轉換為形狀集合。

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 讀取 SVG 檔案內容。
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # 建立 SvgImage 物件。
        svg_image = slides.SvgImage(svg_content)

        # 取得投影片尺寸。
        slide_size = presentation.slide_size.size

        # 將 SVG 圖片轉換為形狀群組，並縮放至投影片尺寸。
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # 以 PPTX 格式儲存簡報。
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **將圖片以 EMF 新增至投影片**

Aspose.Slides for Python 允許您在簡報中插入增強型圖形檔案 (EMF) 圖片。

以下 Python 範例說明此操作：

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **取代影像集合中的圖片**

Aspose.Slides 允許您取代儲存在簡報影像集合中的圖片，包括投影片形狀使用的圖片。本節說明更新集合中圖片的多種方法。API 提供簡單的方式以原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 實例，或集合中已存在的其他圖片來取代目標圖片。

請依以下步驟操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別載入包含圖片的簡報。
2. 從檔案將新圖片載入為位元組陣列。
3. 使用該位元組陣列取代目標圖片。
4. 或者，將圖片載入為 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 物件，並以該物件取代目標圖片。
5. 或以簡報影像集合中已存在的圖片取代目標圖片。
6. 將修改後的簡報另存為 PPTX 檔案。

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# 建立代表簡報檔案的 Presentation 類別實例。
with slides.Presentation("sample.pptx") as presentation:

    # 第一種方法。
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # 第二種方法。
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # 第三種方法。
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # 將簡報儲存至檔案。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="資訊" color="info" %}}
使用 Aspose 免費的 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆為文字製作動畫並產生 GIF。
{{% /alert %}}

## **常見問題**

**插入後，原始圖片解析度是否保持不變？**

是的。來源的像素會被保留，但最終顯示效果取決於投影片上 [picture](/slides/zh-hant/python-net/picture-frame/) 的縮放方式以及儲存時的壓縮設定。

**一次取代大量投影片中的相同商標的最佳方式是什麼？**

將商標放置於母片或版面配置上，並在簡報的影像集合中取代它——所有使用該資源的元素都會自動更新。

**插入的 SVG 能否轉換為可編輯的形狀？**

可以。您可以將 SVG 轉換為形狀群組，之後各個部件即可透過標準形狀屬性進行編輯。

**如何一次為多張投影片設定相同的背景圖片？**

在母片或相關版面配置上 [Assign the image as the background](/slides/zh-hant/python-net/presentation-background/)。使用該母片/版面的所有投影片都會繼承此背景。

**如何防止因大量圖片導致簡報檔案過大？**

重複使用單一影像資源而非多份複製，選擇合理的解析度，儲存時使用壓縮，並盡可能在母片上放置重複的圖形。
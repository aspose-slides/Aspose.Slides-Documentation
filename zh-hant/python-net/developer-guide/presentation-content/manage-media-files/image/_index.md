---
title: 使用 Python 優化 PowerPoint 中的影像管理
linktitle: 管理影像
type: docs
weight: 10
url: /zh-hant/python-net/image/
keywords:
- 新增影像
- 新增圖片
- 新增位圖
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
- 簡報
- Python
- Aspose.Slides
description: "透過 Aspose.Slides for Python 於 .NET，簡化 PowerPoint 和 OpenDocument 中的影像管理，提升效能並自動化工作流程。"
---
## **簡介**

影像讓簡報更具吸引力與趣味性。在 Microsoft PowerPoint 中，您可以從檔案、網路或其他來源插入圖片至投影片。類似地，Aspose.Slides 也允許以多種方式將影像加入投影片。

{{% alert  title="Tip" color="primary" %}}
Aspose 提供免費的轉換工具—[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 以及 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)—讓您能快速從影像建立簡報。
{{% /alert %}}

{{% alert title="Info" color="info" %}}
如果您想將影像作為框架物件加入—特別是您計畫使用調整大小或套用效果等標準格式選項—請參考[使用 Python 將圖片框架加入簡報](https://docs.aspose.com/slides/zh-hant/python-net/picture-frame/)。
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
您可以使用影像與簡報的 I/O 操作在不同格式之間轉換影像。請參閱以下頁面：轉換[影像 轉 JPG](https://products.aspose.com/slides/zh-hant/python-net/conversion/image-to-jpg/); 轉換[JPG 轉 影像](https://products.aspose.com/slides/zh-hant/python-net/conversion/jpg-to-image/); 轉換[JPG 轉 PNG](https://products.aspose.com/slides/zh-hant/python-net/conversion/jpg-to-png/); 轉換[PNG 轉 JPG](https://products.aspose.com/slides/zh-hant/python-net/conversion/png-to-jpg/); 轉換[PNG 轉 SVG](https://products.aspose.com/slides/zh-hant/python-net/conversion/png-to-svg/); 以及轉換[SVG 轉 PNG](https://products.aspose.com/slides/zh-hant/python-net/conversion/svg-to-png/)。
{{% /alert %}}

Aspose.Slides 支援使用 JPEG、PNG、BMP、GIF 等常見格式的影像。

## **將本機儲存的影像加入投影片**

您可以將一或多個電腦中的影像加入簡報的投影片。以下 Python 範例示範如何將影像加入投影片：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **從網路將影像加入投影片**

如果您想加入投影片的影像在電腦上沒有，可直接從網路插入。

以下 Python 範例示範如何從 URL 將影像加入投影片：

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **將影像加入投影片母片**

投影片母片是最高層的投影片，儲存並控制所有下層投影片的資訊—主題、版面配置等。當您將影像加入投影片母片時，該影像會出現在使用該母片的每張投影片上。

以下 Python 範例示範如何將影像加入投影片母片：

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

## **將影像設為投影片背景**

您可能想將影像作為特定投影片或多張投影片的背景。詳情請參閱[將影像設為投影片背景](https://docs.aspose.com/slides/zh-hant/python-net/presentation-background/#set-image-as-background-for-slide)。

## **將 SVG 加入簡報**

您可以使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/) 類別的 [add_picture_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_picture_frame/) 方法將任意影像插入簡報。

若要從 SVG 建立影像物件，請依照以下步驟：

1. 建立 [SvgImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/) 並將其加入簡報的影像集合。
2. 從 [SvgImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/) 建立 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 物件。
3. 使用 [PPImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ppimage/) 建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 物件。

以下 Python 範例示範如何依上述步驟將 SVG 影像加入簡報：

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 讀取 SVG 檔案的內容。
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # 建立 SvgImage 物件。
        svg_image = slides.SvgImage(svg_content)

        # 建立 PPImage 物件。
        pp_image = presentation.images.add_image(svg_image)

        # 建立新的 PictureFrame。
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # 以 PPTX 格式儲存簡報。
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **將 SVG 轉換為一組圖形**

Aspose.Slides 會將 SVG 轉換為一組圖形，方式類似於 PowerPoint 的 SVG 處理。

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/) 類別中 [add_group_shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_group_shape/) 方法的重載提供，該方法的第一個參數為 [SvgImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/svgimage/)。

以下範例程式碼示範如何將 SVG 檔案轉換為一組圖形。

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 讀取 SVG 檔案內容。
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # 建立 SvgImage 物件。
        svg_image = slides.SvgImage(svg_content)

        # 取得投影片大小。
        slide_size = presentation.slide_size.size

        # 將 SVG 影像轉換為一組圖形，並依投影片大小縮放。
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # 以 PPTX 格式儲存簡報。
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **在投影片中以 EMF 形式加入影像**

Aspose.Slides for Python 允許您在簡報中插入增強型中繼檔案 (EMF) 影像。

以下 Python 範例示範此功能：

```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMM.pptx", slides.export.SaveFormat.PPTX)
```

## **取代影像集合中的影像**

Aspose.Slides 允許您取代儲存在簡報影像集合中的影像，包含投影片圖形使用的影像。此章節說明了更新集合中影像的幾種方法。API 提供簡易的方法，可使用原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 實例，或集合中已存在的其他影像來取代影像。

請依以下步驟執行：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別載入包含影像的簡報。
2. 從檔案載入新影像至位元組陣列。
3. 使用位元組陣列將目標影像取代為新影像。
4. 或者，將影像載入 [IImage](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iimage/) 物件，並以該物件取代目標影像。
5. 或以簡報影像集合中已存在的影像取代目標影像。
6. 將修改後的簡報儲存為 PPTX 檔案。

```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# 實例化代表簡報檔案的 Presentation 類別。
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

    # 將簡報儲存為檔案。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
使用 Aspose 提供的免費 [文字轉 GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換工具，您可以輕鬆為文字製作動畫並產生 GIF。
{{% /alert %}}

## **常見問題**

**插入後原始影像解析度是否保持不變？**

是的。原始像素會被保留，但最終顯示效果取決於投影片上 [圖片框架](/slides/zh-hant/python-net/picture-frame/) 的縮放方式以及儲存時的壓縮情況。

**一次取代多張投影片中相同標誌的最佳方法是什麼？**

將標誌放置於母片或版面配置，並在簡報的影像集合中取代；更新會傳播到所有使用該資源的元素。

**插入的 SVG 能否轉換為可編輯的圖形？**

可以。您可以將 SVG 轉換為一組圖形，之後各個部件即可使用標準圖形屬性進行編輯。

**如何一次為多張投影片設定圖片背景？**

在母片或相關版面配置上[將影像指定為背景](/slides/zh-hant/python-net/presentation-background/)，使用該母片/版面的投影片皆會繼承此背景。

**如何避免因大量圖片而使簡報檔案大小膨脹？**

使用單一影像資源取代重複，選擇合適的解析度，儲存時使用壓縮，並在可能的情況下將重複的圖形放置於母片上。
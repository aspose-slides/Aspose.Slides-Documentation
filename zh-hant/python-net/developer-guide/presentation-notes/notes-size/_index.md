---
title: 更改 Python 中的備註頁尺寸與方向
linktitle: 備註頁尺寸
type: docs
weight: 10
url: /zh-hant/python-net/notes-size/
keywords:
- 備註頁尺寸
- 備註方向
- 橫向備註
- 直向備註
- 講義尺寸
- PowerPoint
- 簡報
- PPT
- PPTX
- Python
- Aspose.Slides
description: "透過 .NET 在 Aspose.Slides for Python 中讀取並變更備註頁尺寸，切換方向，驗證已儲存的尺寸，並將備註或講義匯出為 PDF 與圖片。"
---
## **概觀**

使用 [Presentation.notes_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/notes_size/) 來存取簡報的備註頁設定。它會傳回一個 [NotesSize](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/notessize/) 物件，其 [size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/notessize/size/) 屬性是可寫入的。雖然設定物件本身是唯讀的，但您可以為其 size 屬性指派新的尺寸。

寬度和高度以 **點** 為單位指定，1 英吋等於 72 點。例如，900 × 600 點等於 12.5 × 8⅓ 英吋。這些設定套用於整份簡報，而非單獨投影片的備註。

| 設定 | 用途 |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/notes_size/) | 控制備註頁尺寸以及列印手冊匯出的頁面尺寸。 |
| [Presentation.slide_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slide_size/) | 透過 [SlideSize](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesize/) 控制一般簡報投影片尺寸。 |

更改任一設定不會自動更改另一個。變更備註頁的方向也不會旋轉一般投影片。請參閱 [投影片尺寸](/slides/zh-hant/python-net/slide-size/) 以調整一般投影片的尺寸。

下面的範例使用現有的 `sample.pptx`。對於匯出範例，請使用至少包含一張含有講者備註的投影片的簡報。每個範例皆可獨立執行。

## **讀取備註頁尺寸與方向**

讀取寬度與高度並比較它們以判斷方向：較寬的頁面為橫向，較高的頁面為直向，尺寸相同則為方形頁面。本範例會在點數單位中列印實際尺寸，且不會假設任何標準紙張大小。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **在不更改紙張尺寸的情況下切換為橫向**

若只想變更方向，交換現有的寬度與高度即可。這會保留兩側的長度，包括自訂紙張大小的長度。以下條件可防止已是橫向的頁面被切換回直向，且不會改變方形頁面。

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

若要直向，當 `size.width > size.height` 時使用相同的指派。除非您也想變更紙張大小，否則不要自行替換為 A4 或 Letter 尺寸。

## **設定與驗證自訂備註頁尺寸**

一次指派兩個尺寸，然後使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 將簡報寫入檔案。此範例設定 900 × 600 點的橫向頁面，將其儲存為 PPTX，並再次開啟已儲存的檔案以檢查持久化的值。比較時允許 0.01 點的容差，以因應浮點數值；此容差並不保證所有檔案格式皆具有相同精度。

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

預期結果為 `900 x 600 points` 以及 `Size preserved: True`。檢查剛開啟的簡報，可驗證已儲存的檔案，而不僅是記憶體中的設定。

## **匯出備註與講義**

頁面尺寸定義了備註或講義版面配置可用的區域。它們本身不會啟用這些版面配置：還必須設定匯出選項。一般投影片的匯出仍使用投影片尺寸。

### **匯出備註至 PDF 與 PNG**

將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notescommentslayoutingoptions/) 指派給 [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) 以在 PDF 中包含備註。此範例亦使用 [Slide.get_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/) 與 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/renderingoptions/) 將第一張含備註的投影片渲染為 PNG。

[ BOTTOM_TRUNCATED](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notespositions/) 模式會將備註保留在單一頁面；無法容納的備註會被截斷。PDF 使用 900 × 600 點的頁面。以下使用 1 × 1 的影像比例時，PNG 為 900 × 600 像素。點數描述頁面幾何；像素描述光柵輸出，其尺寸也受渲染比例影響。

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

若 PDF 匯出時備註過長，可使用 [BOTTOM_FULL](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notespositions/) 以在需要時產生額外頁面。請勿在上述單張投影片影像呼叫中使用該模式，因為它不支援。調整尺寸後，請檢查輸出是否有被裁切的備註以及現有備註母版物件的位置；僅變更頁面尺寸並不保證所有內容皆能完整呈現。更多備註匯出資訊請參閱 [Convert PowerPoint to PDF with Notes](/slides/zh-hant/python-net/convert-powerpoint-to-pdf-with-notes/)。

### **匯出講義至 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/handoutlayoutingoptions/) 可在單一頁面上放置多張投影片縮圖。以下範例設定 900 × 600 點的頁面，並使用 [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/handouttype/) 以每頁最多排列四張投影片。水平預設控制投影片排序；頁面方向則來自其寬度與高度。

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

變更頁面尺寸會改變講義格線的可用區域，但不會改變來源投影片的尺寸。對於講義影像，請使用 [Presentation.get_images](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/get_images/) 搭配講義版面，而非單一投影片的影像方法。在 Aspose.Slides 中，簡報層級的講義渲染會使用備註頁尺寸，而單獨投影片的影像呼叫不會產生講義頁面。更多版面選項請參閱 [Handout Mode](/slides/zh-hant/python-net/convert-powerpoint-in-handout-mode/)。

## **檢視器、匯出與列印中的頁面尺寸**

保留儲存的簡報尺寸、匯出的頁面尺寸以及列印的紙張尺寸之間的差異：

- **簡報檢視器：** 檢視器可使用自己的版面規則顯示或列印備註。若其他應用程式儲存檔案，請重新開啟並再次檢查尺寸；該應用程式的格式轉換可能會正規化它們。
- **匯出格式：** 上述備註與講義 PDF 範例使用已設定的頁面尺寸。光柵影像使用整數像素尺寸與渲染比例，故在影像輸出時可能會將小數點的點數四捨五入。匯出一般投影片不會套用備註頁尺寸。
- **印表機驅動程式：** 紙張選擇、自動旋轉以及適合頁面設定可能會在不變更簡報或 PDF 中儲存的尺寸的情況下改變實體輸出。若需特定紙張大小，請匹配印表機設定並檢查列印預覽。

## **常見問題**

**我可以為單一投影片設定備註尺寸嗎？**

備註頁尺寸是簡報層級的設定。個別投影片可以有不同的備註內容，但此屬性不提供每張投影片的獨立頁面尺寸。

**為什麼變更備註方向沒有改變我的投影片？**

備註頁與一般投影片具有獨立的尺寸。若要調整投影片本身的尺寸，請使用一般投影片尺寸設定。

**為什麼我的儲存或列印結果尺寸不同？**

首先重新開啟已儲存的簡報，並比較其備註尺寸。若尺寸已變更，請檢查是否在其他應用程式中儲存或轉換檔案時更改了頁面設定。若未變更，請檢查匯出版面、影像比例、檢視器設定以及印表機的紙張選擇。
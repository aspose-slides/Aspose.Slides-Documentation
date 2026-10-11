---
title: 透過 Java 在 Python 中變更備註頁的尺寸與方向
linktitle: 備註頁尺寸
type: docs
weight: 10
url: /zh-hant/python-java/notes-size/
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
- Java
- Aspose.Slides
description: "閱讀並變更 Aspose.Slides for Python via Java 中的備註頁尺寸，切換方向，驗證儲存的尺寸，並將備註或講義匯出為 PDF 與影像。"
---
## **概觀**

使用 [Presentation.getNotesSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getNotesSize) 來存取簡報的備註頁設定。它會傳回一個 [NotesSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notessize/) 物件，其 [setSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notessize/#setSize) 方法設定頁面尺寸。雖然設定物件本身無法取代，但您可以透過此方法指派新尺寸。

寬度和高度以 **points** 為單位指定，1 英吋等於 72 點。例如，900 × 600 點等於 12.5 × 8⅓ 英吋。這些設定套用於簡報，而非單一投影片的備註。

| 設定 | 目的 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getNotesSize) | 控制備註頁尺寸以及用於講義匯出的頁面尺寸。 |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlideSize) | 透過 [SlideSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesize/) 控制一般簡報投影片尺寸。 |

更改任一設定不會自動變更另一個。變更備註頁的方向也不會旋轉一般投影片。請參閱 [Slide Size](/slides/zh-hant/python-java/slide-size/) 以調整一般投影片的尺寸。

下面的範例使用現有的 `sample.pptx`。對於匯出範例，請使用至少包含一張含講者備註的投影片的簡報。每個範例皆可獨立執行。

## **讀取備註頁尺寸與方向**

讀取寬度與高度並比較以判斷方向：較寬的頁面為橫向，較高的頁面為直向，尺寸相等則為方形頁面。此範例會以點為單位列印實際尺寸，且不假設任何標準紙張大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **在不變更紙張尺寸的情況下切換為橫向**

若只想變更方向，交換現有的寬度與高度即可。這會保留兩側的長度，包括自訂紙張尺寸。下方條件會避免已為橫向的頁面被再度切換回直向，且不會改變方形頁面。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

對於直向，當 `size.getWidth() > size.getHeight()` 時使用相同的賦值。除非您同時想變更紙張尺寸，否則不要改為 A4 或 Letter 尺寸。

## **設定並驗證自訂備註頁尺寸**

同時指派兩個尺寸，然後使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 來寫入簡報。此範例設定 900 × 600 點的橫向頁面，將其保存為 PPTX，並再次開啟已保存的檔案以檢查持久化的值。比較允許 0.01 點的容差以因應浮點數值；此容差並不保證每種檔案格式的精確度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

預期結果為 `900.0 x 600.0 points` 與 `Size preserved: True`。檢查新開啟的簡報可驗證已保存的檔案，而非僅檢查記憶體中的設定。

## **匯出備註與講義**

頁面尺寸定義了備註或講義版面可用的區域。它們本身不會啟用這些版面：仍需設定匯出選項。一般投影片的匯出仍使用投影片尺寸。

### **匯出備註至 PDF 與 PNG**

將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/) 指派給 [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 以在 PDF 中包含備註。此範例亦使用 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 與 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/renderingoptions/) 將第一張帶備註的投影片渲染為 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notespositions/) 模式會將備註保留在同一頁；不適合的備註會被截斷。PDF 使用 900 × 600 點的頁面。以下 1 × 1 的影像比例下，PNG 為 900 × 600 像素。點描述頁面幾何；像素描述光柵輸出，其尺寸亦受渲染比例影響。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

若 PDF 匯出包含長備註，使用 [BottomFull](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notespositions/) 可在需要時產生額外頁面。請勿在上述單張投影片影像呼叫中使用該模式，因為它不支援。調整尺寸後，檢查輸出是否有被裁切的備註以及現有 notes‑master 物件的位置；僅變更頁面尺寸並不保證所有內容皆能容納。更多關於備註匯出的資訊，請參閱 [Convert PowerPoint to PDF with Notes](/slides/zh-hant/python-java/convert-powerpoint-to-pdf-with-notes/)。

### **匯出講義至 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/handoutlayoutingoptions/) 於單頁顯示多張投影片縮圖。以下範例設定 900 × 600 點的頁面，並使用 [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/handouttype/) 以水平排列最多四張投影片於每頁。水平預設控制投影片順序；頁面方向則由其寬度與高度決定。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

變更頁面尺寸會改變講義格線可用的區域，卻不會改變來源投影片的尺寸。對於講義影像，請使用 [Presentation.getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages) 搭配講義版面，而非單一投影片的影像方法。在 Aspose.Slides 中，簡報層級的講義渲染使用備註頁尺寸，而個別投影片影像呼叫不會產生講義頁面。請參閱 [Handout Mode](/slides/zh-hant/python-java/convert-powerpoint-in-handout-mode/) 了解版面選項。

## **檢視程式、匯出與列印中的頁面尺寸**

將儲存的簡報尺寸、匯出的頁面尺寸與列印的紙張尺寸區分開來：

- **簡報檢視程式**：檢視程式可以使用自身的版面規則顯示或列印備註。若其他應用程式儲存檔案，請重新開啟並再次檢查尺寸；該應用程式的格式轉換可能會正規化尺寸。
- **匯出格式**：上述備註與講義 PDF 範例使用已設定的頁面尺寸。光柵影像使用整數像素尺寸與渲染比例，因此在影像輸出中可能會四捨五入小數點的點值。匯出一般投影片時不會套用備註頁尺寸。
- **印表機驅動程式**：紙張選擇、自動旋轉與適合頁面設定可能會改變實體輸出，而不會變更簡報或 PDF 中儲存的尺寸。若使用特定紙張尺寸，請匹配印表機設定並檢查列印預覽。

## **常見問題**

**我可以只為單一投影片設定備註尺寸嗎？**

備註頁尺寸為簡報層級的設定。個別投影片可以有不同的備註內容，但此屬性不提供每張投影片各自的頁面尺寸。

**為什麼變更備註方向沒有影響我的投影片？**

備註頁與一般投影片的尺寸是獨立的。若要調整投影片本身的尺寸，請使用一般投影片尺寸設定。

**為什麼我的已保存或列印結果尺寸不同？**

首先重新開啟已保存的簡報並比較其備註尺寸。若有變更，請檢查是否在其他應用程式中儲存或轉換檔案時變更了頁面設定。若未變更，請檢查匯出版面、影像比例、檢視程式設定與印表機紙張選擇。
---
title: 在 Python via Java 中管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/python-java/manage-hyperlinks/
keywords:
- 新增 URL
- 新增超連結
- 建立超連結
- 格式化超連結
- 移除超連結
- 更新超連結
- 文字超連結
- 投影片超連結
- 圖形超連結
- 圖片超連結
- 影片超連結
- 可變更的超連結
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，搭配 Python 範例，在 PowerPoint 與 OpenDocument 簡報中新增、格式化、更新與移除超連結。"
---
## **簡介**

超連結可將簡報內容連結至網站或簡報內的特定位置。在 PowerPoint 中，超連結常用於兩種情況：

* 從文字、圖形或多媒體框架開啟網站。
* 從目錄等處跳轉至另一張投影片。

Aspose.Slides for Python via Java 讓您可以新增這些連結、控制其外觀與聲音、更新屬性，並移除它們。以下範例示範如何在單一元素上操作超連結，以及如何在簡報、投影片或文字框層級存取超連結。

{{% alert color="info" title="Note" %}}

您也可以使用[免費線上 Aspose PowerPoint 編輯器](https://products.aspose.app/slides/editor)編輯簡報。

{{% /alert %}}

## **新增 URL 超連結**

您可以將網站 URL 指派給文字、圖形或多媒體框架。指派超連結的元素決定可點擊範圍：文字部分只會讓選取的文字可點擊，而圖形或框架則會讓整個投影片物件可點擊。

對於包含相對超連結的簡報，請參閱[管理超連結基礎](/slides/zh-hant/python-java/presentation-properties/#manage-the-hyperlink-base)以讀取、變更或清除文件層級的基礎設定。

### **將 URL 超連結加入文字**

若要將文字連結至網站，請將[Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/)傳遞給文字部分的[setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick)方法，如下所示。只有該文字部分會變成可點擊。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **將 URL 超連結加入圖形與多媒體框架**

對矩形呼叫[setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick)即可讓其整個區域可點擊。使用[setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip)可在使用者將滑鼠懸停於矩形時顯示目的地提示。這兩個方法同樣適用於圖片、音訊與視訊框架。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **使用超連結建立目錄**

內部超連結讓讀者能從目錄跳轉至特定投影片。以下範例使用[setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick)將第一張投影片上的「第 2 頁」文字連結到第二張投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **格式化超連結**

您可以更改已連結文字的顏色、在讀者啟動連結時播放或停止聲音，並設定滑鼠懸停時顯示的工具提示。

### **顏色**

[Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) 的[setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource)方法決定超連結是使用簡報的預設超連結顏色，還是文字部分的格式。若要套用自訂文字顏色，請選取[HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/)並設定該部分的填色。此功能於 PowerPoint 2019 引入；舊版不會套用此設定。

在此範例中，[setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) 讓第一個連結使用文字部分的紅色填色。第二個連結則保留簡報的超連結顏色。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **聲音**

超連結可在啟動時播放聲音，或停止已在播放的聲音。請使用以下方法設定這些行為：

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) 指定與超連結相關的音訊。
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) 控制啟動超連結時是否停止先前的聲音。

#### **新增超連結聲音**

第一張投影片上的按鈕使用[Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound)在讀者點擊前進時播放 `sampleaudio.wav`。第二張投影片上的另一個按鈕則使用[Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)停止播放並保留讀者於該投影片。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **擷取超連結聲音**

以下範例開啟前述建立的簡報，並透過[getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound)與[getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData)將第一個圖形的超連結音訊讀入記憶體。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **工具提示與互動設定**

在將超連結指派給文字或圖形後，您可以呼叫以下[Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) 方法：

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) 設定觀眾在懸停時顯示的提示文字。
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) 指定父 HTML frameset 中的目標框架（如適用）。
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) 控制啟動連結時是否將目的地加入已檢視超連結清單。
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) 控制點擊時是否對超連結加以突顯。

## **從簡報中移除超連結**

使用[getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) 收集包括文字部分連結在內的超連結容器，之後再進行變更。以下範例同時移除第一張投影片的兩種啟動方式。若只想移除單一類型，僅呼叫[removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick)或[removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver)；移除點擊動作不會同時移除滑鼠懸停對應項。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

若要無條件移除，[removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) 會一次性在選取範圍內移除兩種啟動方式。若要有選擇性地清除且涵蓋母片、版面配置與註解，請參閱[報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)。

### **在取代 SmartArt 文字前清除超連結**

當您在現有 SmartArt 節點中取代段落時，若直接清除文字部分，舊的超連結可能仍然有效。透過[SmartArtNode.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getTextFrame)取得段落後，先對顯示該段落的節點圖形的文字框呼叫[getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries)，再對回傳的物件呼叫[removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)。如此會移除該框架中所有超連結，包括其他段落的連結。

此範例假設 `SmartArtHyperlink.pptx` 第一步投影片的第三個圖形是 SmartArt 圖形，並取代第四個節點的第一段落。該節點的第一個圖形顯示此段落。

在加入兩個部分後，範例使用[getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) 讀取其實際格式。對於該格式，`getHyperlinkClick` 會回傳第一個部分的新超連結，而第二個部分則回傳 `None`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Portion, Presentation

presentation = Presentation("SmartArtHyperlink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    smart_art = slide.getShapes().get_Item(2)
    node = smart_art.getAllNodes().get_Item(3)
    paragraph = node.getTextFrame().getParagraphs().get_Item(0)

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks()
    paragraph.getPortions().clear()

    link = Portion("New reference")
    link.getPortionFormat().setHyperlinkClick(Hyperlink("https://example.com/new"))
    paragraph.getPortions().add(link)
    text = Portion(" (updated)")
    paragraph.getPortions().add(text)

    print(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl())  # https://example.com/new
    print(text.getPortionFormat().getEffective().getHyperlinkClick())  # 無
finally:
    presentation.dispose()
```

## **建立完整的超連結清單**

在分發簡報之前，請盤點其互動動作與網路連結。[getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) 會回傳超連結容器，例如[Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)與[PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) 物件，而非單純的 URL 字串清單。請同時檢查每個容器的[getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) 與[getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver)。它們是獨立的：同一容器可以同時暴露兩種動作，因此完整報告可能需要每個容器最多兩列。

僅檢查圖形層級的超連結可能會遺漏文字部分的連結。請改為查詢適當的範圍，並保留回傳的容器，以便日後更新或移除其動作。

### **查詢簡報、投影片與文字框範圍**

[HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) 類別可透過[Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries)、[BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) 與 [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) 取得。每個範圍支援相同的查詢：

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) 回傳具有點擊動作的容器。
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) 回傳具有滑鼠懸停動作的容器。
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) 回傳同時或任一動作的容器。

此範例為圖形與其文字分別指派點擊與滑鼠懸停動作，並為另一個按鈕指派巨集動作。它比較 [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) 回傳的容器數量與各個啟動類型的計數。文字框查詢僅統計文字中的連結。外層圖形的動作會出現在投影片與簡報查詢中。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

對此範例而言，簡報與投影片查詢各報告三個點擊容器、兩個滑鼠懸停容器，以及三個任一動作的容器。文字框查詢則在每個類別中各報告一個容器。

### **將動作與目的地分類**

使用[Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) 先判斷動作類型，再解析其目的地。 [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) 的值覆蓋了除網路導覽之外的多種情況：

| 值 | 稽核時的意義 |
| --- | --- |
| `Hyperlink` | 外部超連結；檢查 URL 與其協定。 |
| `JumpSpecificSlide` | 內部導覽至特定投影片。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 內建投影片放映導覽，於放映環境中解析。 |
| `JumpEndShow`, `StartCustomSlideShow` | 結束目前的秀或啟動自訂秀。 |
| `StartMacro` | 執行巨集。 |
| `StartProgram` | 啟動程式。 |
| `OpenFile`, `OpenPresentation` | 開啟檔案或其他簡報；需與網路 URL 分別審查。 |
| `StartStopMedia` | 開始或停止媒體播放。 |
| `NoAction`, `Unknown` | 無導覽動作，或為未識別的動作，需進一步審查。 |

從[getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) 取得外部目的地，從[getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide) 取得特定內部目的地。內部動作與內建指令可能沒有外部 URL；空的 URL 不代表容器沒有動作。若[getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) 回傳的值與正規化 URL 不同，請保留原始值，並在可用時加入[getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) 回傳的工具提示。

### **報告、清理與驗證超連結**

此範例開啟前述簡報，為每個動作寫入一筆 JSON 記錄。它使用[getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) 收集普通投影片、母片、版面配置與註解中的容器，並在存在時包含註解與講義母片。透過參考相等性計算每個容器一次，套用下方敘述的政策，然後重新開啟已儲存的簡報以檢查點擊與滑鼠懸停動作。

報告記錄一個以 1 為起點的投影片索引以及可用時的[getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId)。[getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) 提供支援容器的所屬投影片。母片、版面配置與註解沒有普通投影片索引，會以其範圍標示。圖形容器與文字部分格式容器分別標記；其他容器類型保留其執行時類型名稱。每個容器取得報告本地 ID，以便關聯其兩個動作。報告將動作類型存為 Java 列舉定義的整數常數。

此限制性應用政策僅允許絕對的 HTTPS URL 與有效的內部投影片目標。它會拒絕巨集、程式、檔案動作、其他投影片秀動作、未知動作與其他 URL 協定。這些拒絕屬於政策決策，而非 Aspose.Slides 安全結論。僅 HTTPS 並不保證可信任：請為您的應用加入主機白名單與其他檢查。原始與正規化的外部 URL 皆會被檢查。此範例僅審計中繼資料，未跟隨連結或執行動作。

為了修正，容器的[getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) 支援[setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick)、[removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) 與 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver)。此處，違規的外部點擊連結會被替換為固定的 HTTPS 登陸頁面；其他違規的點擊與滑鼠懸停動作則分別被移除。將 `replace_external_clicks` 設為 `False` 可移除所有政策違規。請在部署前選擇由應用擁有的替換頁面。

報告的匯出旗標使用保守的 PDF 審查政策：將滑鼠懸停動作以及非外部連結或特定投影片跳轉的任何動作標記為可能不受支援。這僅是審查提示，非功能測試或保證未標記的連結在匯出後仍能存活。受支援的[PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)與[HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/) 匯出可能保留超連結，視動作、匯出選項與檢視器而定。點陣[圖片](/slides/zh-hant/python-java/convert-powerpoint-to-png/)與[視訊](/slides/zh-hant/python-java/convert-powerpoint-to-video/) 無法保留互動超連結；在審計此類輸出時請將每個動作皆標記。

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

使用上述產生的輸入，報告包含五筆動作列。檔案滑鼠懸停連結與巨集點擊被移除，HTTPS 連結與內部投影片導覽則保留。驗證階段列印零筆違規動作。若輸入包含違規的外部點擊 URL，亦會走到替換分支。含有允許點擊但違規滑鼠懸停的容器仍保留其點擊動作。

此選擇性清理不同於[removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)，後者會在選取範圍內不論政策如何都移除兩種啟動方式。此處的驗證僅檢查超連結動作，不會移除嵌入的 VBA 專案、OLE 物件或其他活躍內容，也不會驗證匯出的 PDF 或 HTML 檔案。

## **常見問題**

**如何連結至某個章節或其第一張投影片？**

PowerPoint 中的章節會將投影片分組，但內部超連結只能指向單一投影片。若要建立導覽至章節，請連結至該章節的第一張投影片。

**我可以將超連結附加到母片元素，使其在所有投影片上均有效嗎？**

可以。母片與版面配置的元素支援超連結。這些元素上的連結在投影片放映時會對使用相應母片或版面配置的投影片生效。

**匯出為 PDF、HTML、圖片或影片時，超連結會保留嗎？**

受支援的 PDF 與 HTML 匯出可能保留超連結；點陣圖片與影片則無法保留。請參閱[報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)中的匯出考量。
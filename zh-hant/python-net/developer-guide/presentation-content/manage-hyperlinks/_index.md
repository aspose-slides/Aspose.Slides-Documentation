---
title: 在 Python 中管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/python-net/manage-hyperlinks/
keywords:
- 新增 URL
- 新增 超連結
- 建立 超連結
- 格式化 超連結
- 移除 超連結
- 更新 超連結
- 文字 超連結
- 投影片 超連結
- 形狀 超連結
- 圖片 超連結
- 影片 超連結
- 可變更 超連結
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，搭配 Python 範例，在 PowerPoint 與 OpenDocument 簡報中新增、格式化、更新與移除超連結。"
---
## **簡介**

超連結將簡報內容連結至網站或簡報內的某個位置。在 PowerPoint 中，超連結通常具備兩個用途：

* 從文字、形狀或媒體框架開啟網站。
* 從目錄等位置導覽至另一張投影片。

Aspose.Slides for Python via .NET 讓您可以新增這些連結、控制其外觀與聲音、更新屬性以及移除連結。以下範例示範如何在單一元素上操作超連結，以及如何在簡報、投影片或文字框層級存取超連結。

{{% alert color="info" title="Note" %}}
您也可以使用[免費線上 Aspose PowerPoint 編輯器](https://products.aspose.app/slides/zh-hant/editor)編輯簡報。
{{% /alert %}}

## **新增 URL 超連結**

您可以將網站 URL 指派給文字、形狀或媒體框架。指派超連結的元素決定了可點擊的區域：文字部份只會讓所選文字變為可點擊；而形狀或框架則會讓整個投影片物件可點擊。

### **將 URL 超連結新增至文字**

若要將文字連結至網站，請將 [Hyperlink](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/) 指派給文字部份的 [hyperlink_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/hyperlink_click/) 屬性，如下所示。只有該文字部份會變為可點擊。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **將 URL 超連結新增至形狀和媒體框架**

若要讓形狀或框架可點擊，請設定其 [hyperlink_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/hyperlink_click/) 屬性。此超連結屬於物件本身，而不是內部的文字部份。

相同的做法適用於圖片、音訊與影片框架：將超連結指派給框架，並在需要時設定連結的 [tooltip](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/tooltip/)。

以下範例讓矩形可被點擊：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **使用超連結建立目錄**

內部超連結讓讀者可從目錄跳至特定投影片。以下範例使用 [set_internal_hyperlink_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/)，將第一張投影片上的「第 2 頁」文字連結至第二張投影片。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **設定超連結格式**

### **顏色**

[Hyperlink](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/) 的 [color_source](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/color_source/) 屬性決定超連結是使用簡報的超連結顏色，還是文字部份的格式。若要套用自訂文字顏色，請選擇 [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkcolorsource/) 並設定部份的填充顏色。此功能於 PowerPoint 2019 引入；較舊版本不會套用此設定。

以下範例在同一張投影片上新增兩個文字超連結。第一個使用紅色文字填充，第二個保留預設的超連結顏色。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **聲音**

超連結在被啟動時可以播放聲音，或停止已在播放的聲音。使用以下屬性可配置這些行為：

- [Hyperlink.sound](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/sound/) 指定與超連結關聯的音訊。
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/stop_sound_on_click/) 控制在啟動超連結時是否停止先前的聲音。

#### **新增超連結聲音**

以下範例載入 `sampleaudio.wav`，並將其與第一張投影片上的按鈕關聯。點擊按鈕會播放聲音並導覽至下一張投影片。該投影片上的第二個形狀在點擊時會停止先前的聲音，且不執行導覽動作。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **擷取超連結聲音**

以下範例開啟先前建立的簡報，並透過 [sound](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/sound/) 與 [binary_data](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/audio/binary_data/) 讀取第一個形狀的超連結音訊至記憶體。

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **工具提示和互動設定**

將超連結指派給文字或形狀後，您可以更新以下 [Hyperlink](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/) 屬性：

- [tooltip](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/tooltip/) 設定觀者可顯示的連結提示文字。
- [target_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/target_frame/) 在有父 HTML frameset 時指定目標框架。
- [history](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/history/) 控制啟動連結時是否將目的地加入已檢視超連結清單。
- [highlight_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/highlight_click/) 控制點擊時是否以高亮方式顯示超連結。

## **從簡報中移除超連結**

使用 [get_any_hyperlinks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) 先收集包括文字部份連結在內的超連結容器，之後再進行變更。以下範例移除第一張投影片的兩種啟動方式。若只想移除單一類型，僅呼叫 [remove_hyperlink_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) 或 [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) 即可；移除點擊動作不會同時移除滑鼠懸停對應動作。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

若要無條件移除，使用 [remove_all_hyperlinks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) 可在一次呼叫中於所選範圍內同時移除兩種啟動方式。若需在包括母片、版面配置與備註的情況下進行選擇性清理，請參閱【[報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)】。

## **建立完整的超連結清單**

在發佈簡報前，請先盤點其互動動作與網路連結。[get_any_hyperlinks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) 會回傳 [IHyperlinkContainer](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ihyperlinkcontainer/) 物件，而非單純的 URL 字串列表。請同時檢查每個容器的 [hyperlink_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) 與 [hyperlink_mouse_over](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/)。它們是獨立的：同一容器可以同時暴露兩種動作，因此完整報告每個容器可能需要兩列資料。

僅掃描形狀層級的超連結可能會遺漏附加於文字部份的連結。請改為查詢適當的範圍，並保留回傳的容器，以便稍後更新或移除其動作。

### **查詢簡報、投影片和文字框範圍**

[HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/) 類別可透過 [Presentation.hyperlink_queries](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/hyperlink_queries/)、[BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/hyperlink_queries/) 與 [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/hyperlink_queries/) 取得。每個範圍支援相同的查詢：

- [get_hyperlink_clicks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) 回傳具有點擊動作的容器。
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) 回傳具有滑鼠懸停動作的容器。
- [get_any_hyperlinks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) 回傳具有任一或兩種動作的容器。

以下範例建立 `hyperlink-audit-input.pptx`，其中包含外部點擊連結、檔案滑鼠懸停連結、內部投影片導覽、文字滑鼠懸停連結與巨集動作。它不會執行任何動作。相同的三個查詢於每個範圍皆可使用；計數描述的是容器數量，而非動作總數。文字框範圍會排除其外圍形狀本身的連結。

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

在此範例中，簡報與投影片查詢各回報三個點擊容器、兩個滑鼠懸停容器，以及三個包含任一動作的容器。文字框查詢則在每個類別中各回報一個容器。

### **分類動作與目的地**

使用 [Hyperlink.action_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/action_type/) 先判斷動作類型，再解析其目的地。[HyperlinkActionType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkactiontype/) 的值涵蓋超出網站導覽的情況：

| 值 | 審核說明 |
| --- | --- |
| `HYPERLINK` | 外部超連結；檢查 URL 與其協議。 |
| `JUMP_SPECIFIC_SLIDE` | 內部導覽至特定投影片。 |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | 內建投影片放映導覽，於放映情境中解析。 |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | 結束目前的放映或啟動自訂放映。 |
| `START_MACRO` | 執行巨集。 |
| `START_PROGRAM` | 啟動程式。 |
| `OPEN_FILE`, `OPEN_PRESENTATION` | 開啟檔案或其他簡報；需與網路 URL 分開審查。 |
| `START_STOP_MEDIA` | 開始或停止媒體播放。 |
| `NO_ACTION`, `UNKNOWN` | 無導覽動作，或未識別的動作，需要進一步檢查。 |

從 [external_url](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/external_url/) 讀取外部目的地，從 [target_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/target_slide/) 讀取特定的內部目的地。內部動作與內建指令可能沒有外部 URL；空的 URL 不代表容器沒有動作。若 [external_url_original](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/external_url_original/) 與正規化後的 URL 不同，請保留原始值，並在可用時加入 [tooltip](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/tooltip/)。

### **報告、清理與驗證超連結**

以下 Python 範例讀取先前建立的簡報，寫入 `hyperlink-audit.json`，套用政策後儲存為 `hyperlink-sanitized.pptx`，再重新開啟以再次檢查兩種啟動方式。它在變更前先收集容器，並於每張投影片範圍僅查詢一次，以避免重複處理。簡報查詢涵蓋普通投影片；若需全套件盤點，範例亦會查詢普通投影片、母片、版面配置、備註，以及備註與講義母片（若存在）。

報告會記錄以 1 為起點的投影片索引與（若可用）[slide_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/slide_id/)。收集器會保留擁有投影片與範圍的參考。母片、版面配置與備註沒有普通投影片索引，會以其範圍識別。形狀容器與文字部份格式容器會分別標記；其他容器類型保留其執行時類型名稱。每個容器會取得報告本地 ID，以便關聯其兩個動作。

此政策僅允許絕對的 HTTPS URL 與有效的內部投影片目標。它會拒絕巨集、程式、檔案動作、其他投影片放映動作、未知動作以及其他 URL 協議。這些拒絕屬於政策決策，而非 Aspose.Slides 安全性的判斷。僅允許 HTTPS 並不代表可信任：請為您的應用程式加入主機白名單與其他檢查。原始與正規化的外部 URL 皆會被檢查。範例僅審核中繼資料，不會跟隨連結或執行動作。

若需修正，容器的 [hyperlink_manager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) 支援 [set_external_hyperlink_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/)、[remove_hyperlink_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) 與 [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/)。此處會將被禁止的外部點擊連結取代為固定的 HTTPS 登陸頁面；其他被禁止的點擊與滑鼠懸停動作則分別移除。將 `replace_external_clicks` 設為 `False` 可直接移除所有政策違規項目。請於部署前預先決定應用程式擁有的取代頁面。

報告的匯出旗標使用保守的 PDF 審查政策：將滑鼠懸停動作與除外部連結或特定投影片跳轉外的任何動作標記為可能不支援。這僅是審查提示，非功能測試，也不保證未被標記的連結在匯出時一定能保存。支援的 [PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/) 與 [HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/) 匯出可能會根據動作、匯出選項與檢視器保留超連結；光柵 [images](/slides/zh-hant/python-net/convert-powerpoint-to-png/) 與 [video](/slides/zh-hant/python-net/convert-powerpoint-to-video/) 無法保留互動超連結；在針對這些輸出作審核時請將每個動作都標記。

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # 查詢每個投影片範圍一次，並保留每個容器的擁有者。
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

以先前建立的輸入為例，報告包含五筆動作列。檔案滑鼠懸停連結與巨集點擊被移除，而 HTTPS 連結與內部投影片導覽保留下來。驗證階段列印出零項違規動作。若輸入包含被禁止的外部點擊 URL，亦會走取代分支。容器若同時有允許的點擊與被禁止的滑鼠懸停，將保留點擊動作。

此選擇性清理與 [remove_all_hyperlinks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) 的行為不同，後者會在所選範圍內無條件移除兩種啟動方式。此處的驗證僅檢查超連結動作，不會移除嵌入的 VBA 專案、OLE 物件或其他主動內容，也不會驗證匯出的 PDF 或 HTML 檔案。

## **常見問題**

**如何將連結指向某個分節或其第一張投影片？**

PowerPoint 中的分節是投影片的分組，但內部超連結只能指向單一投影片。若要導向分節，請將連結指向該分節的第一張投影片。

**我可以將超連結附加到母片元素，使其在所有投影片上都有效嗎？**

可以。母片與版面配置的元素支援超連結。在投影片放映時，使用相應母片或版面配置的投影片皆會保有這些連結。

**匯出為 PDF、HTML、圖片或影片時，超連結會被保留嗎？**

支援的 PDF 與 HTML 匯出可能會保留超連結；光柵圖片與影片則不會保留。請參閱【[報告、清理與驗證超連結](#report-sanitize-and-verify-hyperlinks)】中的匯出注意事項。
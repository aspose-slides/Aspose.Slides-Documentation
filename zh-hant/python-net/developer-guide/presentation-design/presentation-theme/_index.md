---
title: 在 Python 中管理 PowerPoint 簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/python-net/presentation-theme/
keywords:
- PowerPoint 主題
- 簡報主題
- 投影片主題
- 設定主題
- 變更主題
- 管理主題
- 外部主題
- THMX
- 主題顏色
- 附加調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python（透過 .NET）中掌握簡報主題，建立、客製化與轉換具一致品牌的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一套協調的顏色、字型、背景樣式、填滿、線條與效果。具備主題感知的物件會參考這些共享定義，而不是將每個視覺屬性儲存為固定值，因而一次變更主題即可更新多個物件。

在 Aspose.Slides 中，簡報層級的主題可透過 [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) 屬性取得。簡報也可能在較低層級包含主題覆寫。母片可透過 [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/) 覆寫簡報主題，版面配置可透過 [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) 覆寫其繼承的主題，個別投影片亦可如此。實務上，投影片的實際主題會透過以下繼承鏈解析：簡報主題 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![主題組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下章節說明最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取實際值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) 物件會公開主題的 [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/)、[font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) 與 [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) 屬性。在變更前先檢查這些集合特別有用，因為從外部來源取得的簡報，其樣式項目的數量與內容可能各不相同。

以下範例讀取主要主題屬性，並回報主題中儲存了多少背景、填滿、線條與效果樣式：

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme

    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

如果檔案使用多個母片，請勿假設每張投影片都有相同的實際主題。檢查與投影片相關聯的母片，並在版面或投影片可能有覆寫時，使用本文後面說明的實際主題工作流程。

## **變更主題顏色**

具備主題感知的填滿、線條與文字可以參考 [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您變更主題的 [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) 中的對應項目時，所有仍參考該主題顏色的物件都會以新值重新解析。直接使用 RGB 顏色的物件則不會受到主題顏色更新的影響。

以下端對端範例建立一個使用 `ACCENT4` 的圖形，將主題的 `accent4` 顏色改為紅色，儲存簡報後重新開啟，並印出實際的填滿顏色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    presentation.master_theme.color_scheme.accent4.color = draw.Color.red

    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

因為矩形仍與 `ACCENT4` 連結，主題變更後其顯示顏色會變成紅色。如果您在圖形上將色系顏色改為直接顏色，之後對 `accent4` 的變更就不會再影響該填滿。

### **使用附加調色盤的顏色**

PowerPoint 會透過套用顏色變換，從主題色衍生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/) 列舉公開這些變換。

![主題主要顏色以及從附加調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要主題顏色。  
**2** - 由主要主題顏色產生的較亮與較暗變體。

以下範例建立六個以 `ACCENT4` 為基礎的矩形，對其中五個套用亮度變換，並儲存結果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

這些變體仍以主題顏色為基礎。如果之後 `accent4` 變更，變換後的顏色會依新 `accent4` 值重新計算。

### **將 `SchemeColor` 值映射到 `ColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) 列舉使用 `TEXT1`、`BACKGROUND1`、`TEXT2` 與 `BACKGROUND2`，而 [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) 以 `dark1`、`light1`、`dark2`、`light2` 曝露相同的主題槽位。映射關係固定：

* `TEXT1` = `dark1`  
* `BACKGROUND1` = `light1`  
* `TEXT2` = `dark2`  
* `BACKGROUND2` = `light2`

這些只是同一主題槽位的別名，並非會在執行時相互轉換的值。

## **變更主題字型**

主題字型方案包含標題用的主要字型集合與內文用的次要字型集合。[FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) 與 [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) 屬性會曝光這些集合。

PowerPoint 相容的主題字型識別碼可在文字格式化時使用：

* `+mn-lt` – 內文字型拉丁文（Minor Latin Font）  
* `+mj-lt` – 標題字型拉丁文（Major Latin Font）  
* `+mn-ea` – 內文字型東亞（Minor East Asian Font）  
* `+mj-ea` – 標題字型東亞（Major East Asian Font）  
* `+mn-cs` – 內文字型複合腳本（Minor Complex Script Font）  
* `+mj-cs` – 標題字型複合腳本（Major Complex Script Font）

以下範例建立一個使用主要拉丁字型的標題與一個使用次要拉丁字型的內文行，接著變更主題字型並儲存結果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")

    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")

    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")

    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

標題套用主要字型，內文則套用次要字型。若文字明確指定了字型名稱而非主題識別碼，則在字型方案變更時不會自動切換。

主要與次要字型集合還可以包含針對個別書寫系統（如西里爾文、阿拉伯文、日文、喬治亞文與Thaana）的字型對映。若要檢查、新增、取代或移除這些對映，請參閱 [特定腳本的主題字型](/slides/zh-hant/python-net/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲取得更多有關簡報字型的資訊，請參閱 [PowerPoint 字型](/slides/zh-hant/python-net/powerpoint-fonts/)。
{{% /alert %}}

### **解析主題字型參照**

在檢查文字時，[FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) 可能會包含像 `+mn-lt` 之類的主題參照，而非字型族名稱。呼叫 [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) 並傳入適當的 [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) 即可解析該參照。`+mj` 與 `+mn` 前綴分別選擇主要與次要字型集合；`-lt`、`-ea`、`-cs` 後綴則分別選擇其拉丁文、東亞與複合腳本字型。

透過 [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) 取得套用於檢查文字之物件的實際主題。對於一般投影片上的文字，使用 `slide.create_theme_effective` 以確保情境包含該投影片的繼承主題與本機覆寫。檢查版面或母片本身時，則使用其自己的實際主題。不要假設第一個母片的主題會套用到每張投影片。

以下範例建立一段明確參照次要拉丁字型的文字。它透過 [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) 初始化投影片字型方案，並將主要與次要拉丁字型族設為 `Arial` 與 `Calibri`，使範例在沒有輸入檔的情況下仍可重現。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

輸出為 `+mn-lt -> Calibri`，接著是 `Verdana -> Verdana`。儲存的參照保持不變，而明確的字型名稱則原樣返回。如果該段使用 `+mj-lt`，則會解析為此主題下的 `Arial`。

解析主題參照會找出主題指定的字型族，卻不會檢查字型可用性或在渲染時因替代或字形回退而最終使用的字型檔案。相關步驟請參閱 [字型選擇順序](/slides/zh-hant/python-net/font-selection-sequence/) 與 [字型替代](/slides/zh-hant/python-net/font-substitution/)。

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至依附於母片的投影片**

當您有 PowerPoint 主題檔（`.thmx`）且想要重新樣式化所有依賴特定母片的投影片時，使用 [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/)。從 [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) 集合（[MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)）中選取母片，並將主題檔路徑傳給此方法。

此方法會執行以下操作：

1. 以選取的母片為基礎建立新母片。  
1. 將外部主題套用至新母片。  
1. 將先前依賴該母片的所有投影片指派給新母片。  
1. 回傳新建立的 [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)。

以下範例將外部主題套用至依賴第一個母片的投影片，並儲存簡報：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

無效、損毀或不支援的主題可能拋出 [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) 或其格式相關子類別。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在主題成功套用後才儲存簡報。

僅會重新指派依賴所選母片的投影片。屬於其他母片的投影片保留其現有母片與主題。具備主題感知的顏色、字型、填滿、線條、背景與效果會依外部主題重新解析。直接指定的顏色、字型、填滿與其他明確格式可能保持不變。版面層級與投影片層級的覆寫亦可能優先於從新母片繼承的值。

主題可能參考執行環境中不存在的字型。為了保持一致的渲染與匯出，請安裝所需字型、透過 [自訂字型來源](/slides/zh-hant/python-net/custom-font/) 提供，或設定 [字型替代](/slides/zh-hant/python-net/font-substitution/)。

此為直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，且不需要手動建立投影片層級或版面層級的主題覆寫。

### **在多母片簡報中套用不同的外部主題**

當無法預先得知相關母片時，可透過 [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) 以及 [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/) 從代表性投影片取得。套用任何主題前，先記錄原始母片參照，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個區段的投影片來定位其母片，並對每個群組套用不同的外部主題：

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")

            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

第一次呼叫僅影響依賴 `first_group_master` 的投影片，第二次呼叫僅影響依賴 `second_group_master` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **搬移投影片時保留來源主題**

若要將投影片搬移至另一個簡報且保留原始設計，請先使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) 將來源母片克隆到目標簡報，接著使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) 並傳入已克隆的母片一起克隆投影片。這會同時攜帶母片、其版面配置以及相關主題。

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]

        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)

        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

此為在目標簡報中必須保持外觀相同的首選工作流程。僅將內容克隆至不相關的目標母片，可能會改變受主題驅動的顏色、字型、背景與效果。

### **將主題值套用至既有投影片**

若目標投影片必須保留目前的母片與版面，請從來源主題為投影片層級建立覆寫。使用 [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)、[OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) 與 [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) 方法將三個主要主題元件複製到覆寫中。

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]

        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)

        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

此會在不更動其他投影片繼承主題的情況下變更該投影片使用的主題。若要移除本機覆寫並返回繼承值，呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/)。

### **將主題覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的投影片，除非特定投影片另有自己的覆寫。相同的初始化方法也可透過版面的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) 使用：

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)

        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

在許多版面與投影片應共用相同基礎設計時，使用母片或簡報層級的主題；在單一版面族需要不同樣式時使用版面覆寫；僅在真正例外時使用投影片覆寫。過度的投影片層級覆寫會讓之後的全域主題變更變得難以預測。

## **更新主題背景樣式**

主題的背景填滿儲存在 [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/)。PowerPoint 在 UI 中可呈現比實際儲存在此集合中的填滿定義更多的背景選項，因為 UI 可以將主題填滿與主題顏色及其他樣式參照組合。

![PowerPoint 簡報主題的背景樣式圖庫](presentation-design_8.png)

在使用背景樣式前，請先檢查儲存的集合與目前的 [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/)。`style_index` 為 `0` 表示未使用主題填滿；正值則為主題背景樣式參照。這與直接以 Python 集合索引的概念不同，`[0]` 在集合中代表第一筆儲存項目。不要假設每個簡報都有相同數量的背景填滿樣式。

以下範例回報可用的背景填滿計數，將主題背景參照指派給第一個母片，並儲存簡報：

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:

    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")

    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")

    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1

    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

最終呈現結果取決於母片參照的主題項目以及版面或投影片層級的任何背景覆寫。如果投影片使用自己的背景，只變更母片背景可能不會影響該投影片。需要取得繼承後最終背景時，請使用 [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/)。

{{% alert color="warning" title="Warning" %}}
切勿將 `style_index` 視為零基的集合索引。同時避免硬編碼某檔案的樣式編號並假設在其他檔案中會有相同外觀；主題樣式定義是簡報專屬的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
若需直接的背景格式化與背景繼承，請參閱 [簡報背景](/slides/zh-hant/python-net/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含獨立的 [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/)、[FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/) 與 [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/) 集合。典型的 Office 主題常包含三個主要樣式項目，分別對應微妙、適中與濃烈的視覺效果，但程式碼應檢查每個集合，而非假設固定數量。

![在同一圖形上套用的微妙、適中與濃烈主題效果](presentation-design_10.png)

在 Python 中存取這些集合時，集合索引為零基：`[0]` 為第一筆儲存的樣式，`[2]` 為第三筆。圖形的樣式參照索引是另一概念，透過 [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/) 曝露。變更主題樣式會影響所有參照該主題樣式的圖形；直接格式化的圖形可能不會改變。

以下範例確認所需的樣式項目是否存在，變更第一個線條樣式、變更第三個填滿樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")

    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

對於參照這些槽位的圖形，第一個主題線條樣式會變成紅色，第三個主題填滿樣式會變成實心森林綠，且第三個效果樣式會加上距離 10 點的外部陰影。最終視覺結果仍取決於每個圖形參照的樣式槽位以及是否有直接格式覆寫。

![變更線條、填滿與陰影設定後的主題效果樣式](presentation-design_11.png)

## **為圖形選取主題填滿與線條樣式**

圖形可透過 [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) 與 [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/) 分別獨立選取填滿與輪廓。對於兩個屬性，索引 `1` 會選取相應主題集合的第一筆項目（`fill_styles[0]` 或 `line_styles[0]`），索引 `2` 會選取第二筆。

以下範例在新簡報的預設主題中定義兩種填滿（金色與天藍）以及兩種輪廓（6 pt 深藍與 12 pt 深紅），並在三個階段儲存投影片，以便在 PowerPoint 中比較結果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| 初始樣式 | 變更右側輪廓 | 編輯第一個主題填滿 |
|:---:|:---:|:---:|
| ![金色與天藍矩形，配以細深藍輪廓](theme-style-initial.png) | ![天藍矩形現在有粗深紅輪廓](theme-style-line-changed.png) | ![左側矩形變成綠色且兩個輪廓保持不變](theme-style-fill-changed.png) |

選取不同的線條樣式只會改變右側矩形的輪廓。編輯第一個主題填滿會更新所有使用該填滿的圖形，此處僅左側矩形變為綠色。

在現有圖形上，若本機的填色、線色或線寬覆寫了主題樣式的相應部分，則可能看不到索引變更的效果。如變更樣式索引後沒有視覺變化，請檢查圖形的 [直接格式化](/slides/zh-hant/python-net/shape-formatting/)。

## **判斷實際實心填滿是否使用主題顏色**

填滿可以直接儲存在物件上，或繼承自段落、版面、母片、主題樣式或其他格式層級。呼叫 [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) 可將該層級階層解析為不可變的 [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/)。首先檢查 [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/)。只有當其為 `FillType.SOLID` 時，才應讀取實心填滿屬性。

對於實心填滿，[IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) 會回傳繼承、主題查找與顏色變換後的最終 RGB 值。[IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) 會回傳對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) 槽位，例如 `TEXT1` 或 `ACCENT6`。`SchemeColor.NOT_DEFINED` 表示實際實心填滿並非基於色系顏色。在「填滿僅為主題顏色或直接 RGB 顏色」的工作流程中，此值即表明是直接 RGB 填滿。

不要僅使用本機的 [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) 來分類填滿。例如，文字片段可能本機未定義色系顏色，因而本機值為 `NOT_DEFINED`，但其實際填滿繼承自主題顏色並解析為 `TEXT1` 或 `ACCENT6`。相對地，`solid_fill_scheme_color` 告訴您是哪個邏輯主題槽位產生了最終顏色，但不會說明該槽位來自物件、段落、版面、母片或其他層級。

以下範例載入簡報，審核圖形填滿與文字片段填滿，印出每個最終 RGB 值與相關的色系顏色，並標記不會隨主題顏色變更的實心填滿：

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

`NOT_DEFINED` 分支會提供一份審核清單，列出在更換品牌調色盤時不會回應主題顏色槽位變更的實心填滿。檢視這些物件以確保簡報符合新品牌要求。回報的 RGB 值仍顯示目前的外觀，而色系值則說明該外觀是否與主題相連。

實際格式物件是快照。變更簡報主題、主題覆寫或任何繼承格式後，請再次呼叫 `get_effective` 並讀取新的 `IFillFormatEffectiveData` 物件，方可進行比較或報告顏色。

## **讀取實際主題值**

原始主題物件只能告訴您在特定層級定義了什麼。實際值則告訴您投影片或圖形在繼承與本機覆寫解析後實際使用了什麼。對於投影片，呼叫 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)。對於背景，使用 [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/)，對於填滿，使用 [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/)。

以下範例從投影片讀取實際主題、背景與第一個圖形的填滿：

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()

    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")

    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

使用實際資料進行渲染診斷、驗證與比較。如果僅檢查 [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/)，可能會錯過母片、版面、投影片或圖形的覆寫，從而遺漏最終外觀的變化。

## **常見問題集**

**套用外部主題會影響簡報中的每一張投影片嗎？**

不會。[MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) 只會重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其既有主題。

**我可以在不變更母片的情況下，僅對單一投影片套用主題嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) 並初始化其覆寫主題。變更僅會作用於該投影片；其他投影片仍會繼承既有主題。

**從一個簡報搬移主題到另一個簡報的最安全方式是什麼？**

在搬移投影片且要保留來源外觀時，請先使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) 將來源母片克隆至目標簡報，然後以相同的母片使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) 克隆投影片。這樣可同時保留母片、版面與主題。

**如何查看繼承與覆寫後的實際值？**

對於投影片或版面主題，使用 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)。對於格式物件，如背景與填滿，分別使用對應的 `get_effective` 方法（[Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) 與 [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/)）。這些 API 會在繼承與覆寫套用後回傳解析後的值。
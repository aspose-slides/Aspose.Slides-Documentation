---
title: 在 Python 中管理 PowerPoint 簡報佈景
linktitle: 簡報佈景
type: docs
weight: 10
url: /zh-hant/python-net/presentation-theme/
keywords:
- PowerPoint 佈景
- 簡報佈景
- 投影片佈景
- 設定佈景
- 變更佈景
- 管理佈景
- 外部佈景
- THMX
- 佈景顏色
- 額外調色盤
- 佈景字型
- 佈景樣式
- 佈景效果
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中管理主簡報佈景，建立、客製化與轉換具一致品牌的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題定義了一組協調的顏色、字型、背景樣式、填色、線條與效果。具備佈景概念的物件會參照這些共用定義，而不是將每個視覺屬性儲存為固定值，因而一次佈景變更即可同時更新多個物件。

在 Aspose.Slides 中，簡報層級的佈景可透過 [Presentation.master_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/master_theme/) 屬性取得。簡報亦可在較低層級提供佈景覆寫。母片可利用 [MasterThemeManager.override_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/masterthememanager/override_theme/) 覆寫簡報佈景，版面可透過 [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) 覆寫其繼承的佈景，個別投影片亦可如此。實務上，投影片的實際佈景會依此繼承鏈決定：簡報佈景 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下各節說明最常見的佈景工作流程：檢查佈景、變更顏色與字型、複製或套用佈景、更新背景與效果樣式，以及在繼承與覆寫解決後讀取實際值。

## **檢查佈景**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/) 物件會公開佈景的 [color_scheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/color_scheme/)、[font_scheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/font_scheme/) 與 [format_scheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/format_scheme/) 屬性。在變更之前先檢查這些集合特別有用，尤其當簡報來自外部來源時，樣式項目的數量與內容可能有所不同。

以下範例讀取主要佈景屬性，並回報佈景中儲存了多少個背景、填色、線條與效果樣式：

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

如果檔案使用了多個母片，切勿假設每張投影片都有相同的實際佈景。請檢查投影片所屬的母片，並在版面或投影片可能有覆寫時，使用本文稍後說明的實際佈景工作流程。

## **變更佈景顏色**

具備佈景概念的填色、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在佈景的 [ColorScheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/colorscheme/) 中變更相對應的項目時，所有仍參照該佈景顏色的物件都會改為使用新的值。直接使用 RGB 顏色的物件不會受到佈景顏色更新的影響。

以下端對端範例建立一個使用 `ACCENT4` 的形狀，將佈景的 `accent4` 顏色改為紅色，儲存簡報後重新開啟，並印出實際的填色顏色：

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

因為矩形仍連結至 `ACCENT4`，佈景變更後其可見顏色會變成紅色。若您在形狀上以直接顏色取代配色方案顏色，之後對 `accent4` 的變更將不再影響該填色。

### **使用額外調色板中的顏色**

PowerPoint 會根據佈景色套用顏色變換，以產生較淺或較深的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/colortransformoperation/) 列舉公開這些變換。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 主要佈景顏色。

**2** - 由主要佈景顏色產生的較淺與較深變體。

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

這些變體仍以佈景色為基礎。若稍後 `accent4` 變更，變換後的顏色會根據新的 `accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/schemecolor/) 列舉使用 `TEXT1`、`BACKGROUND1`、`TEXT2`、`BACKGROUND2`，而 [ColorScheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/colorscheme/) 則以 `dark1`、`light1`、`dark2`、`light2` 公開相同的佈景插槽。對映關係固定：

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

這些是同一佈景插槽的別名，並非會在執行時相互轉換的值。

## **變更佈景字型**

佈景字型方案包含標題的主要字型集合與正文的次要字型集合。[FontScheme.major](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/fontscheme/major/) 與 [FontScheme.minor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/fontscheme/minor/) 屬性會公開這兩個集合。

PowerPoint 相容的佈景字型識別碼可在文字格式化時使用：

* `+mn-lt` - 正文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 正文字型 East Asian（次要 East Asian 字型）
* `+mj-ea` - 標題字型 East Asian（主要 East Asian 字型）

以下範例建立一個使用主要 Latin 佈景字型的標題，與一個使用次要 Latin 佈景字型的正文，接著變更佈景字型並儲存結果：

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

標題會遵循主要字型，正文會遵循次要字型。若文字明確指定了字型名稱而非佈景識別碼，則在佈景字型方案變更時不會自動切換。

主要與次要字型集合亦可包含針對個別書寫系統的字型對映，如西里爾文、阿拉伯文、日文、喬治亞文與 Thaana。若要檢查、加入、取代或移除這些對映，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/python-net/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
如需更多關於簡報字型的資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/python-net/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用佈景**

以下工作流程可解決不同的佈景相關問題。

### **將外部佈景套用至特定母片相依的投影片**

當您擁有 PowerPoint 佈景檔 (`.thmx`) 且想重新樣式化每張依賴特定母片的投影片時，請使用 [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/)。先從 [Presentation.masters](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/masters/) 集合（實作自 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/)）選取母片，然後將佈景檔路徑傳入方法。

此方法執行的操作：

1. 以所選母片為基礎建立新母片。
1. 將外部佈景套用至新母片。
1. 將先前依賴所選母片的所有投影片指派給新母片。
1. 回傳新建立的 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterslide/)。

以下範例將外部佈景套用至依賴第一個母片的投影片，並儲存簡報：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

無效、損毀或不支援的佈景可能會拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pptxexception/) 或其格式相關的子類別。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在成功套用佈景後才儲存簡報。

僅重新指派依賴所選母片的投影片。與其他母片關聯的投影片會保留既有的母片與佈景。具佈景概念的顏色、字型、填色、線條、背景與效果會以外部佈景為基礎重新解析。直接指派的顏色、字型、填色與其他顯式格式可能保持不變。版面層級與投影片層級的覆寫仍可能優先於新母片繼承的值。

佈景可能參照執行環境中不存在的字型。為確保一致的算繪與匯出，請安裝必要字型、透過 [custom font sources](/slides/zh-hant/python-net/custom-font/) 提供，或設定 [font substitution](/slides/zh-hant/python-net/font-substitution/)。

此為直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，且不需要手動建立投影片層級或版面層級的佈景覆寫。

### **在多母片簡報中套用不同的外部佈景**

當事先不知道相關母片時，可透過 [Slide.layout_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/layout_slide/) 與 [LayoutSlide.master_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/master_slide/) 從具代表性的投影片取得母片。於套用任何佈景前先儲存原始母片參考，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個區段的投影片來找出其母片，並對每個群組套用不同的外部佈景：

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

### **搬移投影片時保留來源佈景**

若要將投影片搬移至另一份簡報且保留其原始設計，請使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/add_clone/) 將來源母片複製至目標簡報，接著以 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 及複製後的母片將投影片複製過去。如此即可同時攜帶母片、其版面與相關佈景。

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

此為在目的端必須維持原始外觀時的首選工作流程。僅將內容克隆至不相關的目標母片，可能會改變受佈景控制的顏色、字型、背景與效果。

### **將佈景值套用至已存在的投影片**

若目標投影片必須保留目前的母片與版面，可從來源佈景初始化投影片層級的覆寫。使用以下方法將三個主要佈景元件複製到覆寫中：

* [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)
* [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/)
* [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/)

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

此動作會變更該投影片使用的佈景，但不會改變其他投影片繼承的佈景。若要移除本機覆寫並回復繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/clear/)。

### **將佈景覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的投影片，除非特定投影片自行設定了覆寫。可透過版面的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/layoutslidethememanager/) 使用相同的初始化方法：

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

當多個版面與投影片需共用同一基礎設計時，使用母片或簡報層級的佈景；如果只有單一版面族需要不同樣式，則使用版面覆寫；僅在真實例外情況下才使用投影片覆寫。過多的投影片層級覆寫會使日後的全域佈景變更難以預測。

## **更新佈景背景樣式**

佈景的背景填色儲存在 [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) 中。PowerPoint 在 UI 中提供的背景選項可能多於此集合實際儲存的填色定義，因為 UI 能將佈景填色與佈景顏色及其他樣式參照組合。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

使用背景樣式前，請檢查已儲存的集合與目前的 [Background.style_index](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/style_index/)。`style_index` 為 `0` 時代表無佈景填色；正值代表佈景背景樣式參照。此概念不同於直接對 Python 集合索引（`[0]` 代表第一個項目）。請勿假設每個簡報都有相同數量的背景填色樣式。

以下範例回報可用的背景填色數量，將佈景背景參照指派給第一個母片，並儲存簡報：

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

可見結果取決於母片所參照的佈景條目，以及版面或投影片層級的任何背景覆寫。若投影片自行設定背景，只更改母片背景可能不會影響該投影片。需要取得繼承後最終背景時，請使用 [Background.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/get_effective/)。

{{% alert color="warning" title="Warning" %}}
請勿將 `style_index` 當作零基集合索引。也不要硬編碼某個檔案的樣式編號，並假設在另一個檔案中會有相同外觀；佈景樣式定義是依簡報而異的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
關於直接背景格式與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/python-net/presentation-background/)。
{{% /alert %}}

## **更新佈景效果**

佈景格式方案包含獨立的 [FormatScheme.fill_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/fill_styles/)、[FormatScheme.line_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/line_styles/) 與 [FormatScheme.effect_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/effect_styles/) 集合。典型的 Office 佈景常有三個主要樣式條目，分別對應微妙、中等與強烈的視覺效果，但程式碼應自行檢查每個集合，而非假設固定數量。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

在 Python 中存取這些集合時，索引為零基：`[0]` 為第一個儲存的樣式，`[2]` 為第三個。形狀的樣式參照索引是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ishapestyle/) 暴露。修改佈景樣式會影響所有參照該佈景樣式的形狀；直接格式化的形狀則可能保持不變。

以下範例檢查所需的樣式條目是否存在，變更第一個線條樣式、變更第三個填色樣式、在第三個效果樣式中啟用外部陰影，並儲存結果：

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

對於參照這些插槽的形狀而言，第一個佈景線條樣式會變成紅色，第三個佈景填色樣式會變成實心森林綠，第三個效果樣式會取得距離為 10 點的外部陰影。最終的視覺結果仍取決於每個形狀實際參照的樣式插槽，以及是否有直接格式覆寫佈景。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **判斷實際實心填色是否使用佈景顏色**

填色可以直接儲存於物件上，或繼承自段落、版面、母片、佈景樣式或其他格式層級。呼叫 [FillFormat.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/get_effective/) 可將此層級階層解析為不可變的 [IFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ifillformateffectivedata/)。先檢查 [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ifillformateffectivedata/fill_type/)。只有當它為 `FillType.SOLID` 時才應讀取實心填色屬性。

對於實心填色，[IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) 會返回在繼承、佈景查找與顏色變換後的最終 RGB 值。[IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) 則回傳相對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/schemecolor/) 插槽，例如 `TEXT1` 或 `ACCENT6`。若值為 `SchemeColor.NOT_DEFINED`，表示實際實心填色並非基於配色方案。於填色僅為佈景顏色或直接 RGB 顏色的工作流程中，此值即可辨識直接 RGB 填色。

不要僅以本地 [IColorFormat.scheme_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/icolorformat/scheme_color/) 值來分類填色。例如，文字片段可能沒有本地定義的配色方案顏色，因此其本地值為 `NOT_DEFINED`，但其實際填色可能繼承自佈景顏色，最終解析為 `TEXT1` 或 `ACCENT6`。相對地，`solid_fill_scheme_color` 告訴您是哪個邏輯佈景插槽產生了最終顏色，但不會說明該插槽是來自物件、段落、版面、母片或其他層級。

以下範例載入簡報，審核形狀填色與文字片段填色，印出每個最終 RGB 值與對應的配色方案，並標示不會追蹤佈景顏色變更的實心填色：

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

`NOT_DEFINED` 分支會列出那些在佈景配色變更時不會更新的實心填色。請在簡報必須遵循新品牌調色盤時檢查這些物件。報告的 RGB 值仍顯示目前的外觀，而配色方案值說明該外觀是否與佈景相連。

實際格式物件是快照。變更簡報佈景、佈景覆寫或任何繼承的格式後，請再次呼叫 `get_effective` 並讀取新的 `IFillFormatEffectiveData` 物件，之後再進行比較或報告顏色。

## **讀取實際佈景值**

原始佈景物件只能告訴您在特定層級上定義了什麼；實際值則告訴您投影片或形狀在繼承與本機覆寫解決後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)。對於背景，使用 [Background.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/get_effective/)，對於填色則使用 [FillFormat.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/get_effective/)。

以下範例讀取投影片的實際佈景、背景與第一個形狀的填色：

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

使用實際資料進行算繪診斷、驗證與比較。如果僅檢查 [Presentation.master_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/master_theme/)，可能會遺漏母片、版面、投影片或形狀的覆寫，進而改變最終外觀。

## **常見問題**

**套用外部佈景會影響簡報中的每張投影片嗎？**

不會。[IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) 僅重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其既有佈景。

**我可以在不變更母片的情況下只對單張投影片套用佈景嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/slidethememanager/) 並初始化其覆寫佈景。變更僅限於該投影片；其他投影片仍會繼承既有佈景。

**將佈景從一個簡報搬移至另一個簡報的最安全方式是什麼？**

在搬移投影片並保留來源外觀時，請使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/add_clone/) 將來源母片克隆至目的簡報，並以 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 搭配該母片克隆投影片。這樣可同時保留母片、版面與佈景。

**如何查看繼承與覆寫後的實際值？**

對於投影片或版面佈景，使用 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)；對於格式物件則使用相應的實際資料方法，如 [Background.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/get_effective/) 與 [FillFormat.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/get_effective/)。這些 API 會在繼承與覆寫套用後回傳解析後的值。
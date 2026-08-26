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
description: "在 Aspose.Slides for Python（透過 .NET）中掌握簡報主題，以建立、客製化與轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字型、背景樣式、填色、線條與效果。具主題感知的物件會參考這些共享定義，而不是將每個視覺屬性儲存為固定值，因而能在變更主題時一次更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過 [Presentation.master_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/master_theme/) 屬性取得。簡報也可以在較低層級包含主題覆寫。母片可透過 [MasterThemeManager.override_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/masterthememanager/override_theme/) 覆寫簡報主題，版面配置可透過 [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) 覆寫其繼承的主題，個別投影片也可以如此操作。實務上，投影片的有效主題是透過以下繼承鏈解決：簡報主題 → 母片覆寫 → 版面配置覆寫 → 投影片覆寫。

![主題組件：顏色、字型、背景樣式與效果](theme-constituents.png)

下列章節說明最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/) 物件會公開主題的 [color_scheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/color_scheme/)、[font_scheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/font_scheme/) 與 [format_scheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/format_scheme/) 屬性。在變更前檢查這些集合特別有用，因為來自外部來源的簡報其樣式項目數量與內容可能會有所不同。

以下範例讀取主要主題屬性，並回報主題中儲存了多少個背景、填色、線條與效果樣式：

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

如果檔案使用多個母片，切勿假設每張投影片都有相同的有效主題。檢查投影片所屬的母片，並在可能存在版面或投影片覆寫時使用本文稍後說明的有效主題工作流程。

## **變更主題顏色**

具主題感知的填色、線條與文字可以參考 [SchemeColor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您變更主題的 [ColorScheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/colorscheme/) 中對應的項目時，所有仍參考該主題顏色的物件都會以新值重新解析。直接使用 RGB 顏色的物件則不會因主題顏色更新而變更。

以下端到端範例建立一個使用 `ACCENT4` 的圖形，將主題的 `accent4` 顏色改為紅色，儲存簡報、重新開啟，並列印有效的填色：

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

因為矩形仍連結至 `ACCENT4`，主題變更後其可見顏色會變成紅色。若您在圖形上以直接顏色取代方案顏色，之後對 `accent4` 的變更將不再影響該填色。

### **使用附加調色盤的顏色**

PowerPoint 會透過套用顏色轉換，從主題顏色衍生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/colortransformoperation/) 列舉公開這些轉換。

![主題主色以及從附加調色盤產生的較亮與較暗色彩](additional-palette-colors.png)

**1** - 主題主色。

**2** - 由主題主色產生的較亮與較暗變體。

以下範例建立六個以 `ACCENT4` 為基礎的矩形，對其中五個套用亮度轉換，並儲存結果：

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

這些變體仍以主題顏色為基礎。如果之後 `accent4` 變更，轉換後的顏色會以新 `accent4` 的值重新計算。

### **將 `SchemeColor` 值對映到 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/schemecolor/) 列舉使用 `TEXT1`、`BACKGROUND1`、`TEXT2`、`BACKGROUND2`，而 [ColorScheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/colorscheme/) 則以 `dark1`、`light1`、`dark2`、`light2` 暴露相同的主題插槽。對映關係固定：

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

這些是同一主題插槽的別名；它們並非會動態互相轉換的值。

## **變更主題字型**

主題字型方案包含標題的主要字型集合與內文的次要字型集合。[FontScheme.major](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/fontscheme/major/) 與 [FontScheme.minor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/fontscheme/minor/) 屬性會公開這些集合。

PowerPoint 相容的主題字型識別碼可在文字格式設定中使用：

* `+mn-lt` - 正文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 正文字型 East Asian（次要 East Asian 字型）
* `+mj-ea` - 標題字型 East Asian（主要 East Asian 字型）

以下範例建立一個使用主要 Latin 主題字型的標題與一行使用次要 Latin 主題字型的內文，之後變更主題字型並儲存結果：

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

標題遵循主要字型，內文字則遵循次要字型。若文字使用了明確的字型名稱而非主題識別碼，在主題字型方案變更時不會自動切換。

主要與次要字型集合亦可包含針對個別書寫系統（如西里爾文、阿拉伯文、日文、喬治亞文與 Thaana）的字型對映。若要檢查、加入、取代或移除這些對映，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/python-net/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
如需取得有關簡報字型的更多資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/python-net/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

下列工作流程解決不同的主題相關問題。

### **將外部主題套用至母片所依賴的投影片**

當您手上有 PowerPoint 主題檔案（`.thmx`）且想要重新樣式化所有依賴特定母片的投影片時，請使用 [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/)。從 [Presentation.masters](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/masters/) 集合（實作 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/)）中選取母片，並將主題檔案路徑傳遞給方法。

此方法執行以下作業：

1. 建立一個基於所選母片的新母片投影片。
2. 將外部主題套用至新母片。
3. 將新母片指派給先前依賴所選母片的所有投影片。
4. 回傳新建立的 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterslide/)。

以下範例將外部主題套用至依賴第一個母片的投影片，並儲存簡報：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

無效、損毀或不支援的主題可能會拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pptxexception/) 或其格式相關子類別。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在主題成功套用後才儲存簡報。

僅會重新指派依賴所選母片的投影片。與其他母片相關聯的投影片會保留其現有的母片與主題。具主題感知的顏色、字型、填色、線條、背景與效果會以外部主題為基礎重新解析。直接指派的顏色、字型、填色與其他明確格式化可能保持不變。版面層級與投影片層級的覆寫也可能優先於從新母片繼承的值。

主題可能參照執行環境中不存在的字型。為確保一致的渲染與匯出，請安裝所需字型、透過 [custom font sources](/slides/zh-hant/python-net/custom-font/) 提供，或設定 [font substitution](/slides/zh-hant/python-net/font-substitution/)。

這是一個直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，且不需要手動建立投影片層級或版面層級的主題覆寫。

### **在多母片簡報中套用不同的外部主題**

當事前無法得知相關母片時，請透過 [Slide.layout_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/layout_slide/) 與 [LayoutSlide.master_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/master_slide/) 從代表性投影片取得母片。於套用任何主題前先儲存原始母片參考，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個章節的投影片找出其母片，並對每個群組套用不同的外部主題：

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

### **在移動投影片時保留來源主題**

若要將投影片移至另一個簡報且保留其原始設計，請使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/add_clone/) 將來源母片克隆至目標簡報，然後使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 與該克隆母片將投影片克隆。如此可同時攜帶母片、其版面配置與相關主題。

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

當來源投影片必須在目的地保持相同外觀時，這是首選工作流程。僅將內容克隆至不相關的目標母片可能會改變受主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

如果目標投影片必須保留現有的母片與版面配置，請從來源主題初始化投影片層級的覆寫。使用 [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)、[OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/)、[OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) 方法將三個主要主題元件複製到覆寫中。

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

此變更會只影響該投影片使用的主題，而不會改變其他投影片繼承的主題。若要移除本地覆寫並回復繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/clear/)。

### **將主題覆寫套用至版面配置**

版面層級的覆寫會套用至使用該版面的所有投影片，除非個別投影片有自己的覆寫。相同的初始化方法可透過版面的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/layoutslidethememanager/) 使用：

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

當許多版面與投影片需要共享相同基礎設計時，使用母片或簡報層級的主題；當某一版面族需要不同樣式時，使用版面覆寫；僅在真正的例外情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填色儲存在 [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/background_fill_styles/)。PowerPoint 的 UI 所呈現的背景選項可能多於此集合實際儲存的填色定義，因為 UI 可以將主題填色與主題顏色及其他樣式參考組合起來。

![PowerPoint 簡報主題的背景樣式畫廊](presentation-design_8.png)

在使用背景樣式前，請檢查儲存的集合與目前的 [Background.style_index](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/style_index/)。`style_index` 以 `0` 代表未使用主題填色；正值代表主題背景樣式參考。這與直接以 Python 索引集合不同，`[0]` 表示第一個儲存項目。切勿假設每個簡報皆含有相同數量的背景填色樣式。

以下範例回報可用的背景填色數量，將主題背景參考指派給第一個母片，並儲存簡報：

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

可見結果取決於母片參考的主題條目以及版面或投影片層級的任何背景覆寫。若投影片使用了自己的背景，僅變更母片背景可能不會影響該投影片。需要取得套用繼承後最終背景時，請使用 [Background.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/get_effective/)。

{{% alert color="warning" title="Warning" %}}
請勿將 `style_index` 視為零基集合索引。也避免從一個檔案硬編碼樣式編號，並假設在另一個檔案中具有相同外觀；主題樣式定義是依簡報而異的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
如需直接的背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/python-net/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含獨立的 [FormatScheme.fill_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/fill_styles/)、[FormatScheme.line_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/line_styles/) 與 [FormatScheme.effect_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/effect_styles/) 集合。典型的 Office 主題常包含三個主要樣式項目，視覺上對應細膩、適中與強烈的格式化，但程式碼應檢查每個集合，而非假設固定數量。

![對同一形狀套用的細膩、適中與強烈主題效果](presentation-design_10.png)

在 Python 中存取這些集合時，集合索引為零基：`[0]` 是第一個儲存的樣式，`[2]` 是第三個。形狀的樣式參考索引是另一概念，由 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ishapestyle/) 暴露。修改主題樣式會影響參考該主題樣式的形狀；直接格式化的形狀可能保持不變。

以下範例檢查所需的樣式項目是否存在，變更第一個線條樣式、變更第三個填色樣式、在第三個效果樣式中啟用外部陰影，並儲存結果：

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

對於參考這些插槽的形狀，第一個主題線條樣式會變成紅色，第三個主題填色樣式會變成實心森林綠，而第三個效果樣式會加入距離為 10 點的外部陰影。最終的視覺結果仍取決於每個形狀參考的樣式插槽以及是否有直接格式化覆寫主題。

![變更線條、填色與陰影設定後的主題效果樣式](presentation-design_11.png)

## **讀取有效主題值**

原始主題物件告訴您在特定層級所定義的內容。有效值則告訴您投影片或形狀在繼承與本地覆寫解析後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)。對於背景，使用 [Background.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/get_effective/)，對於填色，使用 [FillFormat.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/get_effective/)。

以下範例從投影片讀取有效的主題、背景與第一個形狀的填色：

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

使用有效資料進行渲染診斷、驗證與比較。如果僅檢查 [Presentation.master_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/master_theme/)，可能會錯過改變最終外觀的母片、版面、投影片或形狀覆寫。

## **常見問題**

**套用外部主題會影響簡報中的每一張投影片嗎？**

不會。 [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) 只會重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其現有主題。

**我可以在不變更母片的情況下將主題套用到單一投影片嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/slidethememanager/) 並初始化其覆寫主題。變更只會作用於該投影片；其他投影片仍會繼承其現有主題。

**將主題從一個簡報傳遞到另一個簡報的最安全方法是什麼？**

在移動投影片且需保留來源外觀時，請使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/add_clone/) 將來源母片克隆至目的地，並使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 搭配該克隆母片將投影片克隆。這樣可以同時保留母片、版面與主題。

**如何查看繼承與覆寫後的有效值？**

對於投影片或版面主題，使用 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)。對於格式物件，如背景與填色，分別使用 [Background.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/get_effective/) 與 [FillFormat.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/get_effective/)。這些 API 會在套用繼承與覆寫後回傳解析後的值。
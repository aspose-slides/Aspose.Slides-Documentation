---
title: 管理 PowerPoint 簡報主題於 Python
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
- 主題顏色
- 額外調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中掌握簡報主題，建立、客製化及轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一套協調的顏色、字型、背景樣式、填色、線條與效果。具備主題感知的物件會參照這些共同定義，而不是將每個視覺屬性儲存為固定值，因而在變更主題時可以一次更新多個物件。

在 Aspose.Slides 中，簡報層級的主題可透過 [Presentation.master_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/master_theme/) 屬性取得。簡報也可以在較低層級包含主題覆寫。母片可以透過 [MasterThemeManager.override_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/masterthememanager/override_theme/) 覆寫簡報主題，版面配置可以透過 [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) 覆寫其繼承的主題，單一投影片亦可如此。實務上，投影片的有效主題會依照以下繼承鏈解析：簡報主題 → 母片覆寫 → 版面配置覆寫 → 投影片覆寫。

![主題組成要素：顏色、字型、背景樣式與效果](theme-constituents.png)

以下章節說明最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫完成後讀取有效值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/) 物件會公開主題的 [color_scheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/color_scheme/)、[font_scheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/font_scheme/) 與 [format_scheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/format_scheme/) 屬性。在變更前檢查這些集合特別有用，尤其是簡報來自外部來源時，樣式條目數量與內容可能會不同。

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的有效主題。檢查與投影片相關的母片，並在可能存在版面配置或投影片覆寫時，使用本文稍後說明的有效主題工作流程。

## **變更主題顏色**

具備主題感知的填色、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您變更主題的 [ColorScheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/colorscheme/) 中對應的條目時，所有仍參照該主題顏色的物件會以新值重新解析。使用直接 RGB 顏色的物件不會因主題顏色更新而變更。

以下端對端範例建立一個使用 `ACCENT4` 的圖形，將主題的 `accent4` 顏色改為紅色，儲存簡報，重新開啟後印出有效填色顏色：

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

因為矩形仍連結到 `ACCENT4`，主題變更後其可見顏色會變成紅色。若您在圖形上將方案顏色取代為直接顏色，之後對 `accent4` 的變更將不再影響該填色。

### **使用額外調色盤的顏色**

PowerPoint 會透過套用顏色變換，從主題顏色衍生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/colortransformoperation/) 列舉公開這些變換。

![主要主題顏色與從額外調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要主題顏色。  
**2** - 從主要主題顏色產生的較亮與較暗變體。

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

這些變體仍以主題顏色為基礎。若 `accent4` 後續變更，變換後的顏色會根據新 `accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/schemecolor/) 列舉使用 `TEXT1`、`BACKGROUND1`、`TEXT2`、`BACKGROUND2`，而 [ColorScheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/colorscheme/) 以 `dark1`、`light1`、`dark2`、`light2` 暴露相同的主題插槽。對映固定如下：

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

這些是同一主題插槽的別名; 它們不是會在執行時相互轉換的值。

## **變更主題字型**

主題字型方案包含標題的主要字型集合與內文的次要字型集合。 [FontScheme.major](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/fontscheme/major/) 與 [FontScheme.minor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/fontscheme/minor/) 屬性會公開這兩個集合。

PowerPoint 相容的主題字型識別碼可在文字格式設定中使用：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 內文字型 East Asian（次要東亞字型）
* `+mj-ea` - 標題字型 East Asian（主要東亞字型）

以下範例建立一個使用主要 Latin 主題字型的標題，以及一個使用次要 Latin 主題字型的內文行。接著變更主題字型並儲存結果：

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

標題遵循主要字型，內文遵循次要字型。若文字使用了明確的字型名稱而非主題識別碼，當主題字型方案變更時不會自動切換。

主要與次要字型集合也可以為個別書寫系統（例如西里爾文、阿拉伯文、日文、格魯吉亞文與 Thaana）定義字型對映。若要檢查、加入、取代或移除這些對映，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/python-net/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲取得更多簡報字型資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/python-net/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

常見的兩種工作流程解決不同的問題。

### **在移動投影片時保留來源主題**

若要將投影片移至另一個簡報且保留其原始設計，請使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/add_clone/) 將來源母片複製到目標簡報，然後使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 與複製的母片將投影片複製過來。這會同時攜帶母片、其版面配置與相關的主題。

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

當來源投影片必須在目的地保持相同外觀時，這是首選流程。僅將內容克隆到不相關的目的地母片可能會改變受主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面配置，請從來源主題初始化投影片層級的覆寫。[OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)、[OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) 與 [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) 方法會將三個主要主題元件複製到覆寫中。

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

此變更僅影響該投影片使用的主題，不會改變其他投影片繼承的主題。若要移除本機覆寫並返回繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/clear/)。

### **將主題覆寫套用至版面配置**

版面配置層級的覆寫會套用至使用該版面配置的所有投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過版面配置的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/layoutslidethememanager/) 使用：

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

當多個版面配置與投影片應共享相同基礎設計時，使用母片或簡報層級的主題；當單一版面配置族需要不同樣式時使用版面配置覆寫；僅在真正的例外情況下使用投影片覆寫。過度的投影片層級覆寫會使之後的全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填色儲存在 [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) 中。PowerPoint 在 UI 中可以呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 可以將主題填色與主題顏色以及其他樣式參照結合。

![PowerPoint 簡報主題的背景樣式圖庫](presentation-design_8.png)

使用背景樣式前，先檢查已儲存的集合與目前的 [Background.style_index](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/style_index/)。`style_index` 為 `0` 時表示沒有主題填色；正值則是主題背景樣式參照。這與直接對 Python 集合索引不同，`[0]` 代表第一筆儲存項目。不要假設每個簡報都有相同數量的背景填色樣式。

以下範例回報可用的背景填色數量，將主母片的背景參照設定為有主題的樣式，並儲存簡報：

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

最終顯示結果取決於母片參照的主題條目以及版面配置或投影片層級的任何背景覆寫。如果投影片使用了自訂背景，僅變更母片背景可能不會影響該投影片。需要取得套用繼承後的最終背景時，請使用 [Background.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/get_effective/)。

{{% alert color="warning" title="Warning" %}}
請勿將 `style_index` 視為從零開始的集合索引。也請避免從單一檔案硬編碼樣式編號，並假設在另一檔案中會有相同外觀；主題樣式定義是簡報特定的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
欲了解直接背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/python-net/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含獨立的 [FormatScheme.fill_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/fill_styles/)、[FormatScheme.line_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/line_styles/) 與 [FormatScheme.effect_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/effect_styles/) 集合。典型的 Office 主題通常包含三個主要樣式條目，分別對應微妙、適中與強烈的格式，但程式碼應檢查每個集合，而非假設固定數量。

![在同一圖形上套用的微妙、適中與強烈主題效果](presentation-design_10.png)

在 Python 中存取這些集合時，集合索引為零基礎：`[0]` 為第一筆儲存樣式，`[2]` 為第三筆。圖形的樣式參照索引是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ishapestyle/) 暴露。修改主題樣式會影響參照該主題樣式的圖形；直接格式設定的圖形可能保持不變。

以下範例檢查必要的樣式條目是否存在，變更第一個線條樣式、變更第三個填色樣式、在第三個效果樣式中啟用外部陰影，並儲存結果：

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

對於參照這些插槽的圖形，第一個主題線條樣式會變為紅色，第三個主題填色樣式會變為實心森林綠，第三個效果樣式會新增距離為 10 點的外部陰影。最終視覺結果仍取決於每個圖形參照的樣式插槽以及是否有直接格式覆寫。

![變更線條、填色與陰影設定後的主題效果樣式](presentation-design_11.png)

## **讀取有效的主題值**

原始主題物件告訴您在特定層級定義了什麼。有效值則告訴您投影片或圖形在繼承與本機覆寫解析後實際使用的內容。對投影片呼叫 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)。對背景使用 [Background.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/get_effective/)，對填色使用 [FillFormat.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/get_effective/)。

以下範例從投影片讀取有效的主題、背景與第一個圖形的填色：

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

使用有效資料可用於呈現診斷、驗證與比較。如果只檢查 [Presentation.master_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/master_theme/)，可能會錯過母片、版面配置、投影片或圖形的覆寫，而這些覆寫會改變最終外觀。

## **FAQ**

**我可以在不變更母片的情況下，將主題套用到單一投影片嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/slidethememanager/) 並初始化其覆寫主題。變更僅限於該投影片；其他投影片仍會繼承現有的主題。

**將主題從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片並保留來源外觀時，使用 [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/add_clone/) 將來源母片克隆到目的地，然後使用 [SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/) 以該母片克隆投影片。這樣可同時保留母片、版面配置與主題。

**我如何在繼承與覆寫之後看到有效的值？**

對投影片或版面配置主題使用 [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)，以及對格式物件（如 [Background.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/get_effective/) 和 [FillFormat.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/get_effective/)）使用相應的有效資料方法。這些 API 會在繼承與覆寫套用後返回解析好的值。
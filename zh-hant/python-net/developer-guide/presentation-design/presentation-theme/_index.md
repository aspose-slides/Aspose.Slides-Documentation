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
- 主題色彩
- 額外調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "透過 .NET 在 Aspose.Slides for Python 中管理簡報主題，以建立、客製化及轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的色彩、字型、背景樣式、填色、線條與效果。具備主題感知的物件會參考這些共用定義，而不是將每個視覺屬性以固定值儲存，因此變更主題時可以同時更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過[Presentation.master_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/master_theme/)屬性取得。簡報亦可在較低層級上包含主題覆寫。母片可透過[MasterThemeManager.override_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/masterthememanager/override_theme/)覆寫簡報主題，版面配置可透過[BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/)覆寫其繼承的主題，個別投影片亦可如此。實務上，投影片的實際主題是透過以下繼承鏈解析：簡報主題 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![主題構成元件：色彩、字型、背景樣式與效果](theme-constituents.png)

以下章節說明最常見的主題工作流程：檢查主題、變更色彩與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取實際值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/)物件會公開主題的[color_scheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/color_scheme/)、[font_scheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/font_scheme/)與[format_scheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/mastertheme/format_scheme/)屬性。在變更之前先檢查這些集合特別有用，因為從外部來源取得的簡報，其樣式項目的數量與內容可能各不相同。

以下範例讀取主要主題屬性，並回報在主題中儲存了多少背景、填色、線條與效果樣式：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的實際主題。檢查與投影片相關的母片，並在可能存在版面或投影片覆寫時，使用本文稍後示範的實際主題工作流程。

## **變更主題色彩**

具備主題感知的填色、線條與文字可以參考[SchemeColor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/schemecolor/)列舉中的邏輯色彩。當您變更主題的[ColorScheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/colorscheme/)中相應的項目時，所有仍參考該主題色彩的物件會以新值重新解析。直接使用 RGB 色彩的物件不會因主題色彩更新而改變。

以下端對端範例建立一個使用`ACCENT4`的圖形，將主題的`accent4`色彩改為紅色，儲存簡報，重新開啟後列印實際的填色：

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

因為矩形仍連結到`ACCENT4`，在更改主題後其可見顏色會變成紅色。如果您將圖形的配色改為直接色彩，之後對`accent4`的變更就不會再影響該填色。

### **使用附加調色板的色彩**

PowerPoint 會透過套用色彩變換，從主題色彩衍生出較亮與較暗的變體。Aspose.Slides 透過[ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/colortransformoperation/)列舉公開這些變換。

![主要主題色彩與由附加調色板產生的較亮與較暗色彩](additional-palette-colors.png)

**1** - 主要主題色彩。  
**2** - 從主要主題色彩產生的較亮與較暗變體。

以下範例建立六個以`ACCENT4`為基礎的矩形，對其中五個套用亮度變換，並儲存結果：

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

這些變體仍基於主題色彩。如果之後`accent4`變更，變換後的色彩會根據新的`accent4`值重新計算。

### **將`SchemeColor`值對映到`ColorScheme`插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/schemecolor/)列舉使用`TEXT1`、`BACKGROUND1`、`TEXT2`與`BACKGROUND2`，而[ColorScheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/colorscheme/)則以`dark1`、`light1`、`dark2`、`light2`公開相同的主題插槽。對映固定如下：

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

這些是同一主題插槽的別名，並非會在執行時相互轉換的值。

## **變更主題字型**

主題字型方案包含標題的主要字型集合與本文的次要字型集合。`[FontScheme.major]`(https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/fontscheme/major/)與`[FontScheme.minor]`(https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/fontscheme/minor/)屬性會公開這些集合。

PowerPoint 相容的主題字型識別碼可在文字格式化時使用：

* `+mn-lt` - 本文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題文字型 Latin（主要 Latin 字型）
* `+mn-ea` - 本文字型 East Asian（次要 East Asian 字型）
* `+mj-ea` - 標題文字型 East Asian（主要 East Asian 字型）

以下範例建立一個使用主要 Latin 主題字型的標題與一個使用次要 Latin 主題字型的內文，然後變更主題字型並儲存結果：

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

標題遵循主要字型，本文遵循次要字型。若文字明確指定了字型名稱而非主題識別碼，則在主題字型方案變更時不會自動切換。

{{% alert color="info" title="Tip" %}}
如需取得更多關於簡報字型的資訊，請參閱[PowerPoint Fonts](/slides/zh-hant/python-net/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

有兩種常見工作流程，它們解決不同的問題。

### **移動投影片時保留來源主題**

若要將投影片移至另一個簡報且保留其原始設計，請使用[MasterSlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/add_clone/)將來源母片複製至目標簡報，然後使用[SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/)與已複製的母片一起複製投影片。這會同時攜帶母片、其版面配置與相關的主題。

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

此為在目的地必須保持來源投影片外觀時的首選工作流程。直接將內容複製至不相關的目的地母片可能會改變受主題驅動的色彩、字型、背景與效果。

### **將主題值套用至現有投影片**

如果目標投影片必須保持目前的母片與版面配置，請從來源主題初始化投影片層級的覆寫。`[OverrideTheme.init_color_scheme_from]`(https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)、`[OverrideTheme.init_font_scheme_from]`(https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/)與`[OverrideTheme.init_format_scheme_from]`(https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/)方法會將三個主要主題組件複製到覆寫中。

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

此變更只會影響該投影片使用的主題，不會改變其他投影片繼承的主題。若要移除本機覆寫並回復至繼承值，請呼叫`[OverrideTheme.clear]`(https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/overridetheme/clear/)。

### **將主題覆寫套用至版面**

版面層級的覆寫會套用到使用該版面的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過版面的[LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/layoutslidethememanager/)使用：

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

當許多版面與投影片應共享相同基礎設計時，使用母片或簡報層級的主題；當單一版面族需要不同樣式時使用版面覆寫；僅在真正例外時才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填色儲存在[FormatScheme.background_fill_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/background_fill_styles/)。PowerPoint 在 UI 中可能呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 可以將主題填色與主題色彩及其他樣式參照組合。

![PowerPoint 簡報主題的背景樣式圖庫](presentation-design_8.png)

在使用背景樣式之前，請檢查已儲存的集合與目前的[Background.style_index](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/style_index/)。`style_index`使用`0`表示沒有主題填色；正值表示主題背景樣式參照。這與直接對 Python 集合索引不同，`[0]`代表第一個儲存的項目。請勿假設每個簡報都有相同數量的背景填色樣式。

以下範例回報可用的背景填色數量，將主題背景參照指派給第一個母片，並儲存簡報：

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

最終顯示結果取決於母片所參照的主題項目，以及版面或投影片層級是否有背景覆寫。若投影片使用了自己的背景，只變更母片背景可能不會影響該投影片。需要取得繼承後最終背景時，請使用[Background.get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/get_effective/)。

{{% alert color="warning" title="Warning" %}}
請勿將`style_index`視為零基集合索引。也避免從單一檔案硬編碼樣式編號，然後假設在另一檔案中有相同外觀；主題樣式定義是簡報特有的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有關直接背景格式設定與背景繼承，請參閱[Presentation Background](/slides/zh-hant/python-net/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含獨立的[FormatScheme.fill_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/fill_styles/)、[FormatScheme.line_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/line_styles/)與[FormatScheme.effect_styles](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/formatscheme/effect_styles/)集合。典型的 Office 主題通常包含三個主要樣式項目，對應於微妙、適中與強烈的格式化效果，但程式碼應檢查每個集合，而不要假設固定數量。

![微妙、適中與強烈的主題效果套用於同一圖形](presentation-design_10.png)

在 Python 中存取這些集合時，集合索引是零基的：`[0]`是第一個儲存的樣式，`[2]`是第三個。圖形的樣式參照索引是另一概念，透過[IShapeStyle](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ishapestyle/)公開。修改主題樣式會影響引用該主題樣式的圖形；直接格式設定的圖形可能保持不變。

以下範例檢查所需的樣式項目是否存在，變更第一個線條樣式、變更第三個填色樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

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

對於引用這些插槽的圖形，第一個主題線條樣式會變成紅色，第三個主題填色樣式會變成實心森林綠，第三個效果樣式會加入距離 10 點的外部陰影。最終視覺結果仍取決於每個圖形所參照的樣式插槽以及是否有直接格式覆寫主題。

![變更線條、填色與陰影設定後的主題效果樣式](presentation-design_11.png)

## **讀取實際主題值**

原始主題物件告訴您在特定層級所定義的內容。實際值則告訴您投影片或圖形在繼承與本機覆寫解析後實際使用的內容。對於投影片，請呼叫`[BaseOverrideThemeManager.create_theme_effective]`(https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)。對於背景，使用`[Background.get_effective]`(https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/background/get_effective/)，對於填色，使用`[FillFormat.get_effective]`(https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/get_effective/)。

以下範例讀取投影片的實際主題、背景與第一個圖形的填色：

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

將實際資料用於繪製診斷、驗證與比較。如果僅檢查`[Presentation.master_theme]`，可能會遺漏改變最終外觀的母片、版面、投影片或圖形覆寫。

## **常見問題集**

**我可以在不變更母片的情況下，只對單一投影片套用主題嗎？**

可以。使用投影片的[SlideThemeManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/slidethememanager/)並初始化其覆寫主題。變更僅限於該投影片，其他投影片仍繼承其既有主題。

**將主題從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片並保留來源外觀時，先將來源母片以[MasterSlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/add_clone/)複製至目的地，然後使用[SlideCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_clone/)將投影片與該母片一起複製。這樣可以同時保留母片、版面與主題。

**如何在繼承與覆寫之後查看實際值？**

對於投影片或版面主題，使用`[BaseOverrideThemeManager.create_theme_effective]`；對於格式物件，如`[Background.get_effective]`與`[FillFormat.get_effective]`，使用相應的實際資料方法。這些 API 會在繼承與覆寫套用後返回解析後的值。
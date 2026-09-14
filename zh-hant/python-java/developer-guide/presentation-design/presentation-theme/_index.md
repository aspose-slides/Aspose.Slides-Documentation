---
title: 在 Python（透過 Java）中管理簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/python-java/presentation-theme/
keywords:
- PowerPoint 主題
- 簡報主題
- 投影片主題
- 設定主題
- 變更主題
- 管理主題
- 外部主題
- THMX
- 主題色彩
- 額外調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中管理簡報主題，以建立、客製化並轉換具有一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的色彩、字型、背景樣式、填色、線條與效果。支援主題的物件會參考這些共享定義，而不是將每個視覺屬性存成固定值，因而在變更主題時可以一次更新多個物件。

在 Aspose.Slides 中，簡報層級的主題可透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getMasterTheme) 取得。簡報亦可在較低層級包含主題覆寫。母片可透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterthememanager/#getOverrideTheme) 覆寫簡報主題，而版面或單一投影片則可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme) 覆寫其繼承的主題。實務上，投影片的有效主題是透過以下繼承鏈決定：簡報主題 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![主題元件：色彩、字型、背景樣式與效果](theme-constituents.png)

以下各節說明最常見的主題工作流程：檢視主題、變更色彩與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢視主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mastertheme/) 物件會透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mastertheme/#getColorScheme)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mastertheme/#getFontScheme) 與 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mastertheme/#getFormatScheme) 暴露主題的色彩方案、字型方案與格式方案。變更之前先檢查這些集合特別有用，尤其當簡報來源於外部檔案時，樣式項目的數量與內容可能各不相同。

以下範例會讀取主要主題屬性，並報告主題中儲存的背景、填色、線條與效果樣式的數量：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()
    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

若檔案使用多個母片，請勿假設每張投影片都有相同的有效主題。檢查投影片所屬的母片，並在版面或投影片可能有覆寫時，使用本文後續說明的有效主題工作流程。

## **變更主題色彩**

支援主題的填色、線條與文字可參考 [SchemeColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/schemecolor/) 列舉中的邏輯色彩。當你在 [ColorScheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/colorscheme/) 中變更對應的項目時，所有仍參考該主題色彩的物件皆會以新值解析。直接使用 RGB 色彩的物件則不會受到主題色彩更新的影響。

以下端對端範例會建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 色彩改為紅色，儲存簡報後重新開啟，並印出有效的填色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)
    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

因為矩形仍與 `Accent4` 連結，主題變更後其顯示顏色會變成紅色。若你將圖形的色彩直接改為實際顏色，之後對 `Accent4` 的變更就不會再影響該填色。

### **使用額外調色盤中的色彩**

PowerPoint 會透過色彩轉換從主題色彩衍生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/colortransformoperation/) 列舉公開這些轉換。

![主要主題色彩以及從額外調色盤產生的較亮與較暗色彩](additional-palette-colors.png)

**1** - 主要主題色彩。

**2** - 由主要主題色彩產生的較亮與較暗變體。

以下範例建立六個以 `Accent4` 為基礎的矩形，對其中五個套用亮度轉換，並儲存結果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

這些變體仍基於主題色彩。若之後 `Accent4` 變更，轉換後的色彩會依新 `Accent4` 重新計算。

### **將 `SchemeColor` 值對映至 `ColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [ColorScheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/colorscheme/) 以 `Dark1`、`Light1`、`Dark2`、`Light2` 暴露相同的主題槽位。對映固定如下：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些只是同一主題槽位的別名，並非會在執行時相互轉換的值。

## **變更主題字型**

主題字型方案包含標題的主要字型集合與內文的次要字型集合。[FontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontscheme/#getMajor) 與 [FontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontscheme/#getMinor) 方法會公開這兩個集合。

PowerPoint 相容的主題字型識別子可用於文字格式設定：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 內文字型東亞（次要 East Asian 字型）
* `+mj-ea` - 標題字型東亞（主要 East Asian 字型）

以下範例建立一個使用主要 Latin 主題字型的標題與一條使用次要 Latin 主題字型的內文，然後變更主題字型並儲存結果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

標題遵循主要字型，內文則遵循次要字型。若文字明確指定了字型名稱而非主題識別子，則在主題字型方案變更時不會自動切換。

主要與次要字型集合也可包含針對特定書寫系統（如西里爾文、阿拉伯文、日文、喬治亞文與塔安那文）的對映。若要檢查、加入、取代或移除這些對映，請參閱 [Script‑Specific Theme Fonts](/slides/zh-hant/python-java/script-specific-font-mappings/)。

{{% alert color="success" title="提示" %}}
欲取得更多簡報字型資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/python-java/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至母片相依的投影片**

當你擁有 PowerPoint 主題檔案（`.thmx`）且想重新樣式化所有依賴特定母片的投影片時，請使用 [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides)。先從 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getMasters) 取得母片集合（由 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslidecollection/) 表示），再將主題檔案路徑傳入該方法。

此方法執行以下步驟：

1. 以所選母片建立新的母片投影片。
1. 將外部主題套用至新母片。
1. 將先前依賴所選母片的所有投影片指派給新母片。
1. 回傳新建立的 [MasterSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/)。

以下範例將外部主題套用至依賴第一個母片的投影片，並儲存簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")

    print("Created master:", themed_master.getName())
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若主題檔案無效、損毀或不受支援，會拋出 [PptxReadException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxreadexception/)。請驗證使用者提供的路徑、處理檔案系統存取失敗，並於主題成功套用後再儲存簡報。

僅重新指派依賴所選母片的投影片。其他母片所屬的投影片會保留其既有母片與主題。支援主題的色彩、字型、填色、線條、背景與效果會依外部主題重新解析。直接指派的色彩、字型、填色與其他顯式格式可能保持不變。版面層級與投影片層級的覆寫亦可能優先於新母片繼承的值。

主題可能會參照執行環境中不存在的字型。為確保渲染與匯出一致，請安裝所需字型、透過 [custom font sources](/slides/zh-hant/python-java/custom-font/) 提供，或設定 [font substitution](/slides/zh-hant/python-java/font-substitution/)。

此為直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，不需要手動建立投影片層級或版面層級的主題覆寫。

### **在多母片簡報中套用不同的外部主題**

當事先不知道要使用哪個母片時，可透過 [Slide.getLayoutSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getLayoutSlide) 及 [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/#getMasterSlide) 從代表性投影片取得母片。於套用任何主題前先保存原始母片參考，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個章節的投影片找出它們的母片，並分別為每個群組套用不同的外部主題：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

第一次呼叫只會影響依賴 `first_group_master` 的投影片，第二次呼叫則只會影響依賴 `second_group_master` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **搬移投影片時保留來源主題**

若要將投影片搬移至另一個簡報且保留其原始設計，可先使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslidecollection/#addClone) 將來源母片克隆至目標簡報，然後再以 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 搭配已克隆的母片克隆投影片。如此即可同時攜帶母片、其版面以及相關主題。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

這是當來源投影片在目標簡報中必須保持相同外觀的首選工作流程。僅將內容克隆到不相關的目標母片可能會改變受主題驅動的色彩、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面，可從來源主題初始化投影片層級的覆寫。使用 [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/overridetheme/#initColorSchemeFrom)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) 方法將三個主要主題元件複製到覆寫中。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

此變更會影響該投影片使用的主題，而不會改變其他投影片繼承的主題。若要移除本機覆寫並回復繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/overridetheme/#clear)。

### **將主題覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的投影片，除非特定投影片自行有覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslidethememanager/) 使用：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

當多個版面與投影片應共享相同的基礎設計時，請使用母片或簡報層級的主題；若只有某一版面族需要不同樣式，則使用版面覆寫；僅在真正例外時才使用投影片覆寫。過度的投影片層級覆寫會使日後的全域主題變更變得難以預測。

## **更新主題背景樣式**

主題的背景填色儲存在 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles)。PowerPoint 在 UI 中提供的背景選項可能多於此集合實際儲存的填色定義，因為 UI 能將主題填色與主題色彩及其他樣式參照結合。

![PowerPoint 針對簡報主題的背景樣式圖庫](presentation-design_8.png)

在使用背景樣式前，請先檢查已儲存的集合以及目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/background/#getStyleIndex)。`0` 表示無主題填色；正值則為主題背景樣式參照。這與直接索引集合不同，`get_Item(0)` 代表第一個儲存項目。不要假設每個簡報都有相同數量的背景填色樣式。

以下範例列出可用的背景填色數量，將第一個母片的背景設定為主題參照，並儲存簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)
        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

最終呈現的結果取決於母片參照的主題項目，以及版面或投影片層級可能的背景覆寫。若投影片使用自己的背景，只變更母片背景可能不會影響該投影片。需要取得套用繼承後的最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/background/#getEffective)。

{{% alert color="warning" title="警告" %}}
請勿將樣式索引視為零基集合索引。亦避免硬編碼某檔案的樣式編號並假設在其他檔案中呈現相同外觀；主題樣式定義是依簡報而異的。
{{% /alert %}}

{{% alert color="success" title="提示" %}}
有關直接背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/python-java/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含獨立的填色、線條與效果樣式集合，可分別透過 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/formatscheme/#getFillStyles)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/formatscheme/#getLineStyles) 與 [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/formatscheme/#getEffectStyles) 取得。一般 Office 主題常包含三個主要樣式項目，分別對應微妙、適中與強烈的格式，但程式碼應自行檢查每個集合，而非假設固定數量。

![對同一圖形套用微妙、適中與強烈主題效果](presentation-design_10.png)

在 Python 透過 Java 存取這些集合時，集合索引為零基：`get_Item(0)` 為第一個儲存樣式，`get_Item(2)` 為第三個。圖形的樣式參照索引則是另一概念，透過 [ShapeStyle](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapestyle/) 暴露。修改主題樣式會影響所有參照該樣式的圖形；直接格式化的圖形則可能保持不變。

以下範例確認所需的樣式項目存在，變更第一個線條樣式、變更第三個填色樣式，並於第三個效果樣式中啟用外部陰影，最後儲存結果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)
        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

對於參照這些槽位的圖形而言，第一個主題線條樣式會變成紅色，第三個主題填色樣式會變成實心森林綠，第三個效果樣式會新增距離 10 點的外部陰影。最終的視覺結果仍取決於各圖形參照的樣式槽位以及是否有直接格式覆寫。

![變更線條、填色與陰影設定後的主題效果樣式](presentation-design_11.png)

## **判斷有效實心填色是否使用主題色彩**

填色可以直接儲存在物件上，或從段落、版面、母片、主題樣式或其他格式層級繼承。呼叫 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fillformat/#getEffective) 可將此階層解析為不可變的有效填色資料。先檢查有效資料物件的 `getFillType`。只有在回傳 `FillType.Solid` 時，才讀取實心填色屬性。

對於實心填色，`getSolidFillColor` 會在繼承、主題查找與色彩轉換後，回傳最終渲染的 RGB 值。`getSolidFillSchemeColor` 會回傳對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/schemecolor/) 槽位，如 `Text1` 或 `Accent6`。若回傳 `SchemeColor.NotDefined`，表示有效實心填色並非基於方案色彩。於只使用主題色彩或直接 RGB 色彩的工作流程中，這個值即代表直接 RGB 填色。

不要僅以本地的 [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/colorformat/#getSchemeColor) 值來分類填色。例如，文字的一段落可能本地未定義方案色彩，故其本地值為 `NotDefined`，但其有效填色可能繼承自主題色彩並解析為 `Text1` 或 `Accent6`。相反地，`getSolidFillSchemeColor` 告訴你是哪個邏輯主題槽位產生了最終色彩，但不會說明該槽位來自物件、段落、版面、母片或其他層級。

以下範例載入簡報、稽核圖形填色與文字段落填色，印出每個最終 RGB 值與相應的方案色彩，並標記不會隨主題色彩變更的實心填色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

`NotDefined` 分支會產生一份稽核清單，列出在更換品牌調色盤時不會跟隨主題色彩變化的實心填色。請在簡報必須遵循新品牌調色盤時檢查這些物件。報告的 RGB 值仍顯示當前外觀，而方案值說明該外觀是否與主題相連。

有效格式物件是快照。變更簡報主題、主題覆寫或任何繼承的格式後，請再次呼叫 `getEffective` 取得新的有效填色資料物件，再進行比較或報告。

## **讀取有效主題值**

原始主題物件只告訴你在特定層級所定義的內容。有效值則告訴你投影片或圖形在繼承與本機覆寫解析後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/background/#getEffective)；對於填色，使用 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fillformat/#getEffective)。

以下範例從投影片讀取有效主題、背景與第一個圖形的填色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

使用有效資料進行渲染診斷、驗證與比較。若僅檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getMasterTheme)，可能會錯過改變最終外觀的母片、版面、投影片或圖形覆寫。

## **常見問答**

**套用外部主題會影響簡報中的每張投影片嗎？**

不會。[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) 只會重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其現有主題。

**我可以在不變更母片的情況下，只對單一投影片套用主題嗎？**

可以。使用該投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更僅會套用於該投影片，其他投影片仍會繼承既有主題。

**將主題從一個簡報搬移至另一個簡報的最安全方法是什麼？**

在搬移投影片並保留來源外觀時，先以 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslidecollection/#addClone) 將來源母片克隆至目標簡報，然後使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addClone) 搭配該母片克隆投影片。如此即可同時保留母片、版面與主題。

**如何在繼承與覆寫之後查看有效值？**

對於投影片或版面主題，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective)；對於格式物件，如背景與填色，則分別使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/background/#getEffective) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fillformat/#getEffective)。這些 API 會回傳在繼承與覆寫套用後解析出的值。
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
- 主題顏色
- 附加調色板
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python (透過 Java) 中掌控簡報主題，以建立、客製化與轉換具一致品牌識別的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字型、背景樣式、填色、線條和效果。具備主題感知的物件會參照這些共享定義，而不是將每個視覺屬性儲存為固定值，因而一次變更主題即可更新許多物件。

在 Aspose.Slides 中，可透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme) 取得簡報層級的主題。簡報也可以在較低層級包含主題覆寫。母片可以透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/masterthememanager/#getOverrideTheme) 覆寫簡報主題，而版面或個別投影片則可以透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme) 覆寫其繼承的主題。實務上，投影片的有效主題會依照以下繼承鏈解析：簡報主題 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![主題組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下各節說明最常見的主題工作流程：檢視主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢視主題**

[MasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/) 物件透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getColorScheme)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFontScheme) 以及 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFormatScheme) 透露主題的配色、字型與格式方案。變更前先檢查這些集合特別有用，因為外部來源的簡報可能在樣式項目的數量與內容上有所不同。

以下範例讀取主要主題屬性，並回報主題中儲存了多少背景、填色、線條與效果樣式：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的有效主題。請檢查與投影片關聯的母片，並在版面或投影片可能存在覆寫時，使用本文稍後說明的有效主題工作流程。

## **變更主題色彩**

具備主題感知的填色、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在 [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) 中變更對應項目時，所有仍參照該主題色彩的物件都會依新值解析。直接使用 RGB 顏色的物件不會因主題色彩更新而改變。

以下端對端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色變為紅色，儲存簡報，重新開啟，並列印有效的填色顏色：

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

因為矩形仍連結至 `Accent4`，主題變更後其可見顏色會變成紅色。如果您將圖形的配色從方案色彩改為直接顏色，之後對 `Accent4` 的變更將不再影響該填色。

### **使用附加調色板的顏色**

PowerPoint 會透過顏色轉換從主題色彩衍生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/python-java/aspose.slides/colortransformoperation/) 列舉公開這些轉換。

![主題主要顏色與從附加調色板產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主題主要顏色。

**2** - 由主要主題顏色產生的較亮與較暗變體。

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

這些變體仍以主題色彩為基礎。若 `Accent4` 後續變更，轉換後的顏色會以新的 `Accent4` 值重新計算。

### **對應 `SchemeColor` 值至 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) 將相同的主題插槽以 `Dark1`、`Light1`、`Dark2`、`Light2` 呈現。對應關係固定：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些只是同一主題插槽的別名，並非會在執行時動態轉換的值。

## **變更主題字型**

主題字型方案包含標題的主要字型集合與正文的次要字型集合。可透過 [FontScheme.getMajor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMajor) 與 [FontScheme.getMinor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMinor) 取得這兩個集合。

PowerPoint 相容的主題字型識別碼可用於文字格式設定：

* `+mn-lt` - 正文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 正文字型 East Asian（次要東亞字型）
* `+mj-ea` - 標題字型 East Asian（主要東亞字型）
* `+mn-cs` - 正文字型 Complex Script（次要複雜文字字型）
* `+mj-cs` - 標題字型 Complex Script（主要複雜文字字型）

以下範例建立一個使用主要 Latin 主題字型的標題與一個使用次要 Latin 主題字型的正文行，然後變更主題字型並儲存結果：

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

標題遵循主要字型，正文則遵循次要字型。若文字明確指定字型名稱而非主題識別碼，則在主題字型方案變更時不會自動切換。

主要與次要字型集合亦可包含針對個別書寫系統（如西里爾文、阿拉伯文、日文、喬治亞文與 Thaana）的字型映射。若要檢查、加入、取代或移除這些映射，請參閱 [腳本特定主題字型](/slides/zh-hant/python-java/script-specific-font-mappings/)。

{{% alert color="success" title="Tip" %}}
有關簡報字型的更多資訊，請參閱 [PowerPoint 字型](/slides/zh-hant/python-java/powerpoint-fonts/)。
{{% /alert %}}

### **解析主題字型參照**

在檢查文字時，[FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) 可能會傳回像 `+mn-lt` 這樣的主題參照，而非字型家族名稱。請以適當的有效主題資料呼叫 [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) 以解析該參照。`+mj` 與 `+mn` 前綴分別選取主要與次要字型集合；`-lt`、`-ea`、`-cs` 後綴則分別選取其 Latin、East Asian 與 Complex Script 字型。

可透過在適用於檢查文字之物件的主題管理員上呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) 取得有效主題。對於普通投影片上的文字，使用投影片的主題管理員即可取得包含該投影片繼承主題與本地覆寫的上下文。檢查版面或母片本身時，則使用其自己的有效主題。切勿假設第一個母片的主題適用於每張投影片。

以下範例建立一段明確參照次要 Latin 字型的文字。它透過 [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFromInherited) 初始化投影片字型方案，並將主要與次要 Latin 家族設定為 `Arial` 與 `Calibri`，使結果在無輸入檔案的情況下可重現：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    theme = slide.getThemeManager().getOverrideTheme()
    theme.initFontSchemeFromInherited()
    major_font = FontData("Arial")
    theme.getFontScheme().getMajor().setLatinFont(major_font)
    minor_font = FontData("Calibri")
    theme.getFontScheme().getMinor().setLatinFont(minor_font)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Text using the minor theme font")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    theme_font = FontData("+mn-lt")
    portion.getPortionFormat().setLatinFont(theme_font)

    font = portion.getPortionFormat().getLatinFont()
    effective_theme = slide.getThemeManager().createThemeEffective()
    print(f"{font.getFontName()} -> {font.getFontName(effective_theme)}")

    explicit_font = FontData("Verdana")
    print(f"{explicit_font.getFontName()} -> {explicit_font.getFontName(effective_theme)}")
finally:
    presentation.dispose()
```

輸出為 `+mn-lt -> Calibri` 後接 `Verdana -> Verdana`。儲存的參照保持不變，而明確的家族名稱則原樣回傳。若該段使用 `+mj-lt`，則會在此主題中解析為 `Arial`。

解析主題參照會指出主題指定的字型家族。它不會檢查字型可用性，也不會在呈現期間決定最終使用的字型檔案或字形備援。相關步驟請參閱 [字型選擇順序](/slides/zh-hant/python-java/font-selection-sequence/) 與 [字型替代](/slides/zh-hant/python-java/font-substitution/)。

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至依賴特定母片的投影片**

當您有 PowerPoint 主題檔 (`.thmx`) 且想重新樣式化每張依賴特定母片的投影片時，請使用 [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides)。從 [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) 取得的集合（由 [MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/) 代表）中選取母片，並將主題檔路徑傳入方法。

此方法執行以下動作：

1. 依所選母片建立新的母片投影片。
2. 將外部主題套用至新母片。
3. 將先前依賴所選母片的所有投影片指派給新母片。
4. 回傳新建立的 [MasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/)。

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

不正確、損毀或不支援的主題可能會拋出 [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/)。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在主題成功套用後才儲存簡報。

只有依賴所選母片的投影片會被重新指派。使用其他母片的投影片會保留其既有母片與主題。具主題感知的顏色、字型、填色、線條、背景與效果會依外部主題解析；直接指定的顏色、字型、填色與其他明確格式可能保持不變。版面層級與投影片層級的覆寫仍可能優先於新母片繼承的值。

主題可能參照執行環境中不存在的字型。為確保一致的渲染與匯出，請安裝必要字型、透過 [自訂字型來源](/slides/zh-hant/python-java/custom-font/) 提供，或設定 [字型替代](/slides/zh-hant/python-java/font-substitution/)。

此為直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，且不需要手動建立投影片層級或版面層級的主題覆寫。

### **在多母片簡報中套用不同的外部主題**

當事先不知道相關母片時，請透過 [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) 及 [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getMasterSlide) 從代表性投影片取得母片。於套用任何主題前先儲存原始母片參照，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個章節的投影片找出其母片，並對每個組別套用不同的外部主題：

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

第一次呼叫僅影響依賴 `first_group_master` 的投影片，第二次呼叫僅影響依賴 `second_group_master` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **移動投影片時保留來源主題**

若要將投影片移至另一個簡報並保留其原始設計，請先使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) 將來源母片克隆至目標簡報，然後使用 [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) 及克隆的母片一起克隆投影片。這會將母片、其版面以及相關主題一起帶入。

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

在需要保證來源投影片在目標簡報中保持相同外觀時，這是首選工作流程。單純將內容克隆到不相關的目標母片可能會改變主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面，請從來源主題初始化投影片層級的覆寫。使用 [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initColorSchemeFrom)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) 方法將三個主要主題元件複製到覆寫中。

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

此作業會在不變更其他投影片繼承主題的情況下，變更該投影片使用的主題。若要移除本地覆寫並回復繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#clear)。

### **將主題覆寫套用至版面**

版面層級的覆寫會影響使用該版面的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslidethememanager/) 使用：

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

當許多版面與投影片應共享相同基礎設計時，請使用母片或簡報層級的主題；若只有單一版面族需要不同樣式，則使用版面覆寫；僅在真實例外情況下才使用投影片覆寫。過多的投影片層級覆寫會使之後的全域主題變更變得難以預測。

<!-- visual-explanation:presentation-theme:start -->
[![母片主題供兩個版面使用；版面覆寫影響其投影片，除非投影片有更局部的覆寫。](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*版面覆寫會套用至使用該版面的投影片，除非投影片自行提供覆寫。基於主題的值會遵循已解析的方案；明確格式化的物件則可保留其本地外觀。請將覆寫範圍限制於設計例外的必要範圍。*
<!-- visual-explanation:presentation-theme:end -->

## **更新主題背景樣式**

主題的背景填色儲存在 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles) 中。PowerPoint 在 UI 中可以呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 能將主題填色與主題顏色及其他樣式參照結合。

![PowerPoint 簡報主題的背景樣式圖庫](presentation-design_8.png)

在使用背景樣式前，請檢查已儲存的集合與目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getStyleIndex)。索引為 `0` 表示沒有主題填色；正值表示主題背景樣式參照。這與直接以 `get_Item(0)` 取得集合第一項不同。請勿假設每個簡報都有相同數量的背景填色樣式。

以下範例回報可用的背景填色數量，將主題背景參照指派給第一個母片，並儲存簡報：

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

最終顯示結果取決於母片參照的主題條目以及版面或投影片層級的任何背景覆寫。若投影片自行設定背景，只變更母片背景可能不會影響該投影片。需要得知繼承後最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective)。

{{% alert color="warning" title="Warning" %}}
不要將樣式索引視為從零開始的集合索引。也避免硬編碼某一檔案的樣式編號，並假設在另一檔案中會有相同外觀；主題樣式定義是簡報特有的。
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
有關直接背景格式設定與背景繼承，請參閱 [簡報背景](/slides/zh-hant/python-java/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含透過 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getFillStyles)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getLineStyles) 與 [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getEffectStyles) 暴露的獨立填色、線條與效果樣式集合。典型的 Office 主題通常包含三個主要樣式條目，分別對應微妙、適度與強烈的視覺格式，但程式碼應檢查每個集合，而非假設固定數量。

![對同一圖形套用微妙、適度與強烈主題效果](presentation-design_10.png)

在 Python 透過 Java 存取這些集合時，集合索引是從零開始：`get_Item(0)` 為第一筆儲存的樣式，`get_Item(2)` 為第三筆。圖形的樣式參照索引則是另一概念，透過 [ShapeStyle](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/) 暴露。修改主題樣式會影響參照該主題樣式的圖形；直接格式化的圖形可能保持不變。

以下範例檢查必要的樣式條目是否存在，變更第一個線條樣式、第三個填色樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

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

對於參照這些插槽的圖形，第一個主題線條樣式會變為紅色，第三個主題填色樣式會變為實心森林綠，第三個效果樣式會得到距離為 10 點的外部陰影。最終視覺結果仍取決於每個圖形參照的樣式插槽以及是否有直接格式化覆寫主題。

![變更線條、填色與陰影設定後的主題效果樣式](presentation-design_11.png)

## **為圖形選取主題填色與線條樣式**

圖形可透過 [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setFillStyleIndex) 與 [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setLineStyleIndex) 獨立選取其填色與外框。對於這兩個方法，索引 `1` 代表在對應主題集合中的第一筆項目 (`get_Item(0)`)；索引 `2` 代表第二筆 (`get_Item(1)`)。

以下範例在新簡報的預設主題中設定兩個填色樣式（金色與天藍）與兩個線條樣式（深藍 6 pt 與深紅 12 pt），並在三個階段儲存投影片，以便在 PowerPoint 中比較結果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    styles = presentation.getMasterTheme().getFormatScheme()

    gold_fill = styles.getFillStyles().get_Item(0)
    gold_fill.setFillType(FillType.Solid)
    gold_fill.getSolidFillColor().setColor(Color(255, 215, 0))
    blue_fill = styles.getFillStyles().get_Item(1)
    blue_fill.setFillType(FillType.Solid)
    blue_fill.getSolidFillColor().setColor(Color(135, 206, 235))

    thin_line = styles.getLineStyles().get_Item(0)
    thin_line.getFillFormat().setFillType(FillType.Solid)
    thin_line.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    thin_line.setWidth(6)
    thick_line = styles.getLineStyles().get_Item(1)
    thick_line.getFillFormat().setFillType(FillType.Solid)
    thick_line.getFillFormat().getSolidFillColor().setColor(Color(139, 0, 0))
    thick_line.setWidth(12)

    shapes = presentation.getSlides().get_Item(0).getShapes()
    left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130)
    right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130)
    left.getShapeStyle().setFillStyleIndex(1)
    right.getShapeStyle().setFillStyleIndex(2)
    left.getShapeStyle().setLineStyleIndex(1)
    right.getShapeStyle().setLineStyleIndex(1)
    presentation.save("01-initial.pptx", SaveFormat.Pptx)

    right.getShapeStyle().setLineStyleIndex(2)
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx)

    gold_fill.getSolidFillColor().setColor(Color(46, 139, 87))
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| 初始樣式 | 變更右側輪廓 | 編輯第一個主題填色 |
|:---:|:---:|:---:|
| ![金色與天藍矩形搭配細深藍輪廓](theme-style-initial.png) | ![天藍矩形現在有粗深紅輪廓](theme-style-line-changed.png) | ![左側矩形變為綠色，兩個輪廓維持不變](theme-style-fill-changed.png) |

選取不同的線條樣式僅會改變右側矩形的外框。編輯第一個主題填色會更新所有使用該樣式的圖形，此例中只有左側矩形變為綠色。

在既有圖形上，局部的填色、線條顏色或線條寬度可以覆寫該主題樣式的相應部分。若變更樣式索引後沒有可見效果，請檢查圖形的 [直接格式化](/slides/zh-hant/python-java/shape-formatting/)。

## **判斷有效實心填色是否使用主題顏色**

填色可以直接儲存在物件上，或是從段落、版面、母片、主題樣式或其他格式層級繼承。呼叫 [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) 可將該階層解析為不可變的有效填色資料。首先在有效資料物件上檢查 `getFillType`。只有在其為 `FillType.Solid` 時，才應讀取實心填色屬性。

對於實心填色，`getSolidFillColor` 會回傳繼承、主題查找與顏色轉換後的最終 RGB 值。`getSolidFillSchemeColor` 會回傳對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) 插槽，例如 `Text1` 或 `Accent6`。若返回 `SchemeColor.NotDefined`，表示有效實心填色並非基於方案顏色。在只使用主題顏色或直接 RGB 顏色的工作流程中，該值即代表直接 RGB 填色。

請勿僅依賴本地的 [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getSchemeColor) 值來分類填色。例如，文字段落可能沒有本地定義的方案顏色，其本地值為 `NotDefined`，但其有效填色可能繼承自主題顏色，最終解析為 `Text1` 或 `Accent6`。相對地，`getSolidFillSchemeColor` 告訴您是哪個邏輯主題插槽產生了有效顏色，但不會說明該插槽是來自物件、段落、版面、母片或其他層級。

以下範例載入簡報，稽核圖形填色與文字段落填色，列印每個最終 RGB 值與相關的方案顏色，並標示不會隨主題顏色變更的實心填色：

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

`NotDefined` 分支會產生一份稽核清單，列出在主題顏色變更時不會回應的實心填色。請在需要遵循新品牌調色盤的簡報中檢查這些物件。報告的 RGB 值仍顯示目前的外觀，而方案值則說明該外觀是否已與主題連結。

有效格式物件是快照。變更簡報主題、主題覆寫或任何繼承的格式後，請再次呼叫 `getEffective`，取得新的有效填色資料物件後再進行比較或報告。

## **讀取有效的主題值**

原始主題物件只告訴您在特定層級上定義了什麼。有效值則告訴您投影片或圖形在繼承與本地覆寫解析後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective)；對於填色，使用 [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective)。

以下範例讀取投影片的有效主題、背景以及第一個圖形的填色：

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

使用有效資料進行渲染診斷、驗證與比較。如果只檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme)，可能會錯過母片、版面、投影片或圖形的覆寫，這些覆寫會改變最終外觀。

## **FAQ**

**套用外部主題會影響簡報中的每一張投影片嗎？**

不會。[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) 僅重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其既有主題。

**我可以在不變更母片的情況下，將主題套用至單一投影片嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更僅限於該投影片；其他投影片仍會繼承其既有主題。

**將主題從一個簡報帶到另一個簡報的最安全方式是什麼？**

在移動投影片且需保留來源外觀時，請使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) 將來源母片克隆至目標簡報，然後使用 [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) 搭配該母片克隆投影片。這樣可同時保留母片、版面與主題。

**如何查看繼承與覆寫後的有效值？**

對於投影片或版面主題，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective)；對於格式物件，分別使用對應的有效資料方法，例如 [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective)。這些 API 會在繼承與覆寫套用後回傳解析後的值。
---
title: 在 Java 中管理簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/java/presentation-theme/
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中精通簡報主題，以建立、客製化與轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字型、背景樣式、填色、線條與效果。具備主題感知的物件會參考這些共用定義，而不是將每個視覺屬性儲存為固定值，因而在變更主題時能一次更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)取得。簡報也可以在較低層級包含主題覆寫。母片可以透過[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/masterthememanager/)覆寫簡報主題，而版面或單一投影片則可透過[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseoverridethememanager/)覆寫其繼承的主題。在實務上，投影片的有效主題是透過以下繼承鏈解析：簡報主題 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![主題組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下各節說明最常見的主題工作流程：檢視主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢視主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mastertheme/) 物件透過[MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mastertheme/) 與[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mastertheme/) 透露主題的顏色配色、字型配色與格式配色。在變更之前先檢查這些集合特別有用，因為來自外部來源的簡報其樣式項目的數量與內容可能不同。

以下範例讀取主要主題屬性，並回報主題中儲存了多少個背景、填色、線條與效果樣式：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

若檔案使用多個母片，請勿假設每張投影片都有相同的有效主題。檢查與投影片相關的母片，並在版面或投影片可能有覆寫時使用本文後面說明的有效主題工作流程。

## **變更主題顏色**

具備主題感知的填色、線條與文字可以參考[SchemeColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您變更[IColorScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icolorscheme/) 中的相應條目時，仍參考該主題顏色的所有物件都會以新值重新解析。直接使用 RGB 顏色的物件不會因主題顏色更新而改變。

以下端對端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色改為紅色，儲存簡報，重新開啟後列印有效的填色顏色：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

因為矩形仍連結至 `Accent4`，主題變更後其可見顏色會變成紅色。若您將圖形上的配色色彩直接改為實際顏色，之後對 `Accent4` 的變更將不再影響該填色。

### **使用附加調色盤的顏色**

PowerPoint 會透過顏色變換從主題色彩衍生較亮與較暗的變體。Aspose.Slides 透過[ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/colortransformoperation/) 列舉公開這些變換。

![主題主要顏色與從附加調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主題主要顏色。  
**2** - 從主要主題顏色產生的較亮與較暗變體。

以下範例建立六個基於 `Accent4` 的矩形，對其中五個套用亮度變換，並儲存結果：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

這些變體仍以主題顏色為基礎。若 `Accent4` 之後變更，變換後的顏色會根據新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 映射至 `IColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2` 與 `Background2`，而[IColorScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icolorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 曝露相同的主題插槽。映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是同一主題插槽的別名，並非會在執行時相互轉換的值。

## **變更主題字型**

主題字型配色包含一組用於標題的主要字型集合，以及一組用於內文的次要字型集合。[IFontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontscheme/) 與[IFontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontscheme/) 方法會公開這兩套字型。

PowerPoint 相容的主題字型識別碼可在文字格式化時使用：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 內文字型 East Asian（次要東亞字型）
* `+mj-ea` - 標題字型 East Asian（主要東亞字型）

以下範例建立一個使用主要 Latin 主題字型的標題與一個使用次要 Latin 主題字型的內文字段，然後變更主題字型並儲存結果：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

標題會遵循主要字型，內文則遵循次要字型。若文字使用了明確的字型名稱而非主題識別碼，當主題字型配色變更時，文字不會自動切換。

主要與次要字型集合也可以包含針對個別書寫系統（如西里爾、阿拉伯、日文、喬治亞與塔納）的字型映射。若要檢查、加入、取代或移除這些映射，請參閱[特定腳本的主題字型](/slides/zh-hant/java/script-specific-font-mappings/)。

{{% alert color="info" title="提示" %}}
欲取得更多關於簡報字型的資訊，請參閱[PowerPoint 字型](/slides/zh-hant/java/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

常見的兩種工作流程，解決不同的需求。

### **在搬移投影片時保留來源主題**

若要將投影片搬移至另一簡報且保留原始設計，請使用[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslidecollection/)將來源母片克隆至目標簡報，接著使用[ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/)與已克隆的母片一起克隆投影片。這會同時攜帶母片、其版面以及相關主題。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

當來源投影片必須在目的地保持相同外觀時，這是首選的工作流程。僅將內容克隆到不相關的目的地母片可能會改變受主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面，請從來源主題為投影片層級建立覆寫。使用[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/overridetheme/) 與[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/overridetheme/) 方法將三個主要主題元件複製到覆寫中。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

此做法會變更該投影片使用的主題，而不會影響其他投影片繼承的主題。若要移除本地覆寫並回復至繼承值，請呼叫[OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/overridetheme/)。

### **將主題覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過[LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/layoutslidethememanager/) 使用：

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

當多個版面與投影片應共享相同基礎設計時，請使用母片或簡報層級的主題；當單一版面族需要不同樣式時使用版面覆寫；僅在真正例外情況下才使用投影片覆寫。過度的投影片層級覆寫會讓之後的全域主題變更變得難以預測。

## **更新主題背景樣式**

主題的背景填色儲存在[IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iformatscheme/) 中。PowerPoint 在 UI 中可以呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 能將主題填色與主題顏色及其他樣式參考結合。

![PowerPoint 簡報主題的背景樣式庫](presentation-design_8.png)

在使用背景樣式前，請檢查已儲存的集合以及目前的[Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/background/)。樣式索引為 `0` 代表沒有主題填色；正值則是主題背景樣式的參考。這與直接對 Java 集合索引不同，`get_Item(0)` 代表第一個儲存項目。切勿假設每個簡報都有相同數量的背景填色樣式。

以下範例回報可用的背景填色數量，將主題背景參考指派給第一個母片，並儲存簡報：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

最終呈現結果取決於母片參考的主題條目以及版面或投影片層級的任何背景覆寫。如果投影片使用自己的背景，只變更母片背景可能不會影響該投影片。當您需要知道繼承後的最終背景時，請使用[Background.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/background/)。

{{% alert color="warning" title="警告" %}}
請勿將樣式索引視為零基集合索引。同時避免將某檔案的樣式編號硬編碼並假設在另一檔案中呈現相同外觀；主題樣式定義是簡報特定的。
{{% /alert %}}

{{% alert color="info" title="提示" %}}
關於直接背景格式設定與背景繼承，請參閱[簡報背景](/slides/zh-hant/java/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式配色方案包含分別的填色、線條與效果樣式集合，透過[IFormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iformatscheme/) 曝露。典型的 Office 主題往往包含三個主要樣式項目，視覺上對應微妙、適中與強烈的格式，但程式碼應檢查每個集合而非假設固定數量。

![相同圖形套用微妙、適中與強烈主題效果](presentation-design_10.png)

在 Java 中存取這些集合時，集合索引是零基的：`get_Item(0)` 為第一個儲存的樣式，`get_Item(2)` 為第三個。圖形的樣式參考索引是另一概念，透過[IShapeStyle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapestyle/) 曝露。修改主題樣式會影響參考該主題樣式的圖形；直接格式設定的圖形可能保持不變。

以下範例檢查必要的樣式項目是否存在，變更第一個線條樣式、第三個填色樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對於參考這些插槽的圖形而言，第一個主題線條樣式會變為紅色，第三個主題填色樣式會變為實心森林綠，第三個效果樣式會新增距離為 10 點的外部陰影。最終的視覺結果仍取決於每個圖形實際參考的樣式插槽以及是否有直接格式覆寫主題。

![變更線條、填色與陰影設定後的主題效果樣式](presentation-design_11.png)

## **讀取有效主題值**

原始主題物件告訴您在特定層級定義了什麼。有效值則告訴您投影片或圖形在繼承與本地覆寫解析後實際使用的內容。對投影片呼叫[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseoverridethememanager/)。對背景使用[Background.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/background/)，對填色使用[FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/)。

以下範例讀取投影片的有效主題、背景以及第一個圖形的填色：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

使用有效資料進行渲染診斷、驗證與比較。如果僅檢查[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)，可能會錯過改變最終外觀的母片、版面、投影片或圖形覆寫。

## **常見問答**

**我可以在不變更母片的情況下，將主題套用到單一投影片嗎？**

可以。使用投影片的[SlideThemeManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更僅影響該投影片，其餘投影片仍繼承現有主題。

**將主題從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片且保留來源外觀時，使用[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslidecollection/) 將來源母片克隆至目標簡報，然後使用[ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/) 以該母片克隆投影片。這樣可同時保留母片、版面與主題。

**我如何查看繼承與覆寫後的有效值？**

對投影片或版面主題使用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseoverridethememanager/)，並對格式物件（如[Background.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/background/) 與[FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/)）呼叫相應的有效資料方法。這些 API 會在繼承與覆寫套用後回傳解析後的值。
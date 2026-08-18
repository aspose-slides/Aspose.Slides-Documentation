---
title: 在 Java 中管理簡報佈景主題
linktitle: 簡報佈景主題
type: docs
weight: 10
url: /zh-hant/java/presentation-theme/
keywords:
- PowerPoint 佈景主題
- 簡報佈景主題
- 投影片佈景主題
- 設定佈景主題
- 變更佈景主題
- 管理佈景主題
- 佈景顏色
- 額外調色盤
- 佈景字型
- 佈景樣式
- 佈景效果
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中掌握簡報佈景主題，以建立、自訂及轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題定義了一套協調的顏色、字型、背景樣式、填色、線條與效果。具備佈景感知的物件會參照這些共享的定義，而不是將每個視覺屬性儲存為固定值，因而可在變更佈景時一次更新許多物件。

在 Aspose.Slides 中，簡報層級的佈景主題可透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 取得。簡報也可以在較低層級包含佈景覆寫。母片可透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/masterthememanager/) 覆寫簡報佈景，而版面配置或個別投影片可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseoverridethememanager/) 覆寫其繼承的佈景。實務上，投影片的有效佈景是透過此繼承鏈解析：簡報佈景、母片覆寫、版面覆寫與投影片覆寫。

![佈景組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下各節說明最常見的佈景工作流程：檢視佈景、變更顏色與字型、複製或套用佈景、更新背景與效果樣式，並在繼承與覆寫解析後讀取有效值。

## **檢視佈景**

透過 [MasterTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mastertheme/) 物件可取得佈景的色彩配置、字型配置與格式配置，分別使用 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mastertheme/)、與 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mastertheme/)。在變更之前先檢查這些集合特別有用，尤其當簡報來自外部來源時，樣式項目的數量與內容可能會有所不同。

下列範例讀取主要佈景屬性，並回報佈景中儲存了多少個背景、填色、線條與效果樣式：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的有效佈景。檢查與投影片相關聯的母片，且在版面或投影片可能有覆寫時，請使用本文後面說明的有效佈景工作流程。

## **變更佈景顏色**

具備佈景感知的填色、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在 [IColorScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icolorscheme/) 中變更相應的項目時，仍引用該佈景顏色的所有物件都會以新值重新解析。直接使用 RGB 顏色的物件則不會因佈景顏色更新而改變。

以下端對端範例建立一個使用 `Accent4` 的形狀，將佈景的 `Accent4` 顏色變更為紅色，儲存簡報、重新開啟，並列印有效的填色顏色：

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

由於矩形仍連結至 `Accent4`，佈景變更後其可見顏色會變為紅色。如果您在形狀上以直接顏色取代此方案顏色，之後對 `Accent4` 的變更將不再影響該填色。

### **使用額外調色盤中的顏色**

PowerPoint 透過套用顏色變換，從佈景顏色衍生出較亮與較暗的變體。Aspose.Slides 以 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/colortransformoperation/) 列舉公開這些變換。

![主要佈景顏色與由額外調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要佈景顏色。

**2** - 從主要佈景顏色產生的較亮與較暗變體。

下列範例根據 `Accent4` 建立六個矩形，對其中五個套用亮度變換，並儲存結果：

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

這些變體仍基於佈景顏色。若稍後 `Accent4` 變更，變換後的顏色會根據新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `IColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2` 與 `Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icolorscheme/) 將相同的佈景槽位顯示為 `Dark1`、`Light1`、`Dark2`、`Light2`。對映是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是相同佈景槽位的別名；它們不是會動態相互轉換的值。

## **變更佈景字型**

佈景字型方案包含用於標題的主要字型集合與用於內文的次要字型集合。[IFontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontscheme/) 與 [IFontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontscheme/) 方法可取得這兩個集合。

可在文字格式設定中使用相容於 PowerPoint 的佈景字型識別碼：

* `+mn-lt` - 正文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 正文字型 East Asian（次要 East Asian 字型）
* `+mj-ea` - 標題字型 East Asian（主要 East Asian 字型）

下列範例建立一個使用主要 Latin 佈景字型的標題，以及一行使用次要 Latin 佈景字型的正文。接著變更佈景字型並儲存結果：

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

標題使用主要字型，正文則使用次要字型。若文字使用明確的字型名稱而非佈景識別碼，則在佈景字型方案變更時不會自動切換。

{{% alert color="info" title="Tip" %}}
欲取得有關簡報字型的更多資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/java/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用佈景**

有兩種常見的工作流程，且它們解決不同的問題。

### **搬移投影片時保留來源佈景**

若要將投影片移至另一份簡報並保留其原始設計，可使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslidecollection/) 將來源母片克隆至目標簡報，然後使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/) 及該克隆的母片克隆投影片。這會一起攜帶母片、其版面配置以及相關的佈景。

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

當來源投影片必須在目標中保持相同外觀時，此為首選工作流程。僅將內容克隆至不相關的目標母片可能會變更受佈景驅動的顏色、字型、背景與效果。

### **將佈景值套用至現有投影片**

如果目標投影片必須保留在其現有的母片與版面上，請從來源佈景初始化投影片層級的覆寫。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/overridetheme/) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/overridetheme/) 方法會將三個主要佈景組件複製到覆寫中。

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

這會變更該投影片使用的佈景，而不會更動其他投影片繼承的佈景。若要移除本地覆寫並回復至繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/overridetheme/)。

### **將佈景覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/layoutslidethememanager/) 使用：

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

當多個版面與投影片應共享相同的基礎設計時，使用母片或簡報層級的佈景；當某個版面系列需要不同樣式時，使用版面覆寫；僅在真正例外的情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域佈景變更難以預測。

## **更新佈景背景樣式**

佈景的背景填色儲存在 [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iformatscheme/) 中。PowerPoint 在 UI 中可呈現的背景選項比此集合實際儲存的填色定義更多，因為 UI 能將佈景填色與佈景顏色以及其他樣式參照結合。

![PowerPoint 簡報佈景的背景樣式圖庫](presentation-design_8.png)

在使用背景樣式前，請檢查儲存的集合與目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/background/)。樣式索引為 `0` 表示無佈景填色；正值代表佈景背景樣式的參照。這與直接以 Java 集合索引不同，`get_Item(0)` 代表第一個儲存的項目。請勿假設每份簡報都有相同數量的背景填色樣式。

下列範例回報可用的背景填色計數，將佈景背景參照指派給第一個母片，並儲存簡報：

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

可見結果取決於母片參照的佈景項目以及版面或投影片層級的任何背景覆寫。若投影片使用自己的背景，僅變更母片背景可能不會影響該投影片。當需要得知套用繼承後的最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
請勿把樣式索引視為零基集合索引。亦避免硬編碼某個檔案的樣式編號，並假設在另一個檔案中會呈現相同外觀；佈景樣式定義是依簡報而異的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
欲了解直接背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/java/presentation-background/)。
{{% /alert %}}

## **更新佈景效果**

佈景格式方案包含透過 [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iformatscheme/)、與 [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iformatscheme/) 取得的分別填色、線條與效果樣式集合。一般 Office 佈景常包含三個主要樣式項目，視覺上對應微妙、適中與強烈的格式設定，但程式碼應檢查每個集合，而非假設固定數量。

![對同一形狀套用的微妙、適中與強烈佈景效果](presentation-design_10.png)

在 Java 中存取這些集合時，集合索引為零基：`get_Item(0)` 為第一個儲存的樣式，`get_Item(2)` 為第三個。形狀的樣式參照索引是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapestyle/) 可取得。修改佈景樣式會影響參照該佈景樣式的形狀；直接格式設定的形狀則可能保持不變。

下列範例檢查所需的樣式項目是否存在，變更第一個線條樣式、變更第三個填色樣式、在第三個效果樣式中啟用外部陰影，並儲存結果：

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

對於參照這些槽位的形狀而言，第一個佈景線條樣式會變為紅色，第三個佈景填色樣式會變為實心森林綠，第三個效果樣式則會新增外部陰影，距離為 10 點。最終的視覺結果仍取決於每個形狀參照的樣式槽位以及是否有直接格式設定覆寫佈景。

![變更線條、填色與陰影設定後的佈景效果樣式](presentation-design_11.png)

## **讀取有效佈景值**

原始佈景物件告訴您在特定層級定義了什麼。有效值則告訴您投影片或形狀在繼承與本地覆寫解析後實際使用的內容。對於投影片，請呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseoverridethememanager/)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/background/)，對於填色，使用 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/)。

下列範例從投影片讀取有效佈景、背景與第一個形狀的填色：

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

使用有效資料進行呈現診斷、驗證與比較。若僅檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)，可能會錯過會改變最終外觀的母片、版面、投影片或形狀覆寫。

## **常見問題**

**我可以在不變更母片的情況下將佈景套用到單一投影片嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidethememanager/) 並初始化其覆寫佈景。變更僅限於該投影片；其他投影片仍會繼承其現有的佈景。

**從一個簡報搬移佈景到另一個簡報，最安全的做法是什麼？**

在搬移投影片且保留來源外觀時，使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslidecollection/) 將來源母片克隆至目標，並使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/) 搭配該克隆的母片克隆投影片。這會一起保留母片、版面與佈景。

**如何在繼承與覆寫後查看有效值？**

對於投影片或版面佈景，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseoverridethememanager/)；對於格式物件如 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/)，使用相應的有效資料方法。這些 API 會回傳套用繼承與覆寫後的解析值。
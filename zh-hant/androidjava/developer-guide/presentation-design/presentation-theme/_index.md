---
title: 管理 Android 上的簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/androidjava/presentation-theme/
keywords:
- PowerPoint 主題
- 簡報主題
- 投影片主題
- 設定主題
- 變更主題
- 管理主題
- 主題顏色
- 其他調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "透過 Java 在 Aspose.Slides for Android 中管理主要簡報主題，以建立、客製化並轉換具有一致品牌識別的 PowerPoint 檔案。"
---
## **介紹**

簡報主題定義了一組協調的顏色、字型、背景樣式、填滿、線條和效果。具備主題感知的物件會參照這些共同定義，而不是將每個視覺屬性儲存為固定值，因而在變更主題時能一次更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 取得。簡報也可以在較低階層包含主題覆寫。Master 可透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/masterthememanager/) 覆寫簡報主題，而版面配置或個別投影片則可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseoverridethememanager/) 覆寫其繼承的主題。實務上，投影片的有效主題會透過以下繼承鏈解決：簡報主題 → Master 覆寫 → 版面配置覆寫 → 投影片覆寫。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

下面的章節說明最常見的主題工作流程：檢視主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢視主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mastertheme/) 物件透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mastertheme/) 與 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mastertheme/) 暴露主題的顏色方案、字型方案與格式方案。變更前先檢查這些集合尤其在簡報來自外部來源時有幫助，因為樣式項目的數量與內容可能有所不同。

以下範例讀取主要主題屬性，並報告主題中儲存了多少背景、填滿、線條與效果樣式：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

如果檔案使用多個 Master，請勿假設每張投影片都有相同的有效主題。請檢查與投影片相關的 Master，並在版面配置或投影片可能有覆寫時，使用本文稍後說明的有效主題工作流程。

## **變更主題顏色**

具備主題感知的填滿、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在 [IColorScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icolorscheme/) 中變更相應條目時，所有仍參照該主題顏色的物件都會以新值重新解析。使用直接 RGB 顏色的物件不會因主題顏色更新而改變。

以下端對端範例建立一個使用 `Accent4` 的形狀，將主題的 `Accent4` 顏色改為紅色，儲存簡報後重新開啟，並印出有效的填滿顏色：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

因為矩形仍與 `Accent4` 連結，主題變更後其可見顏色會變成紅色。如果您將形狀的配色改為直接顏色，之後 `Accent4` 的變更將不再影響該填滿。

### **使用額外調色盤中的顏色**

PowerPoint 會透過顏色變換從主題顏色衍生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/colortransformoperation/) 列舉公開這些變換。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 主要主題顏色。

**2** - 從主要主題顏色產生的較亮與較暗變體。

以下範例建立六個以 `Accent4` 為基礎的矩形，對其中五個套用亮度變換，並儲存結果：

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

這些變體仍以主題顏色為基礎。如果之後 `Accent4` 變更，變換後的顏色會根據新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `IColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2` 與 `Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icolorscheme/) 以 `Dark1`、`Light1`、`Dark2`、`Light2` 來呈現相同的主題槽位。對映固定如下：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是同一主題槽位的別名，並非會動態相互轉換的值。

## **變更主題字型**

主題字型方案包含標題的主要字型集合與內文的次要字型集合。[IFontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontscheme/) 與 [IFontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontscheme/) 方法暴露這兩套字型。

可在文字格式化中使用 PowerPoint 相容的主題字型識別碼：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 內文字型 East Asian（次要東亞字型）
* `+mj-ea` - 標題字型 East Asian（主要東亞字型）

以下範例建立一個使用主要 Latin 主題字型的標題，以及一個使用次要 Latin 主題字型的內文行，然後變更主題字型並儲存結果：

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

標題遵循主要字型，內文則遵循次要字型。若文字使用了明確的字型名稱而非主題識別碼，則在主題字型方案變更時不會自動切換。

{{% alert color="info" title="Tip" %}}
欲取得有關簡報字型的更多資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/androidjava/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

常見的兩種工作流程解決不同的問題。

### **在移動投影片時保留來源主題**

若要將投影片移至另一個簡報且保留其原始設計，請使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslidecollection/) 將來源 Master 複製到目標簡報，然後使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/) 以及已複製的 Master 複製投影片。如此可同時攜帶 Master、其版面配置與相關主題。

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

此流程在必須在目標簡報中保持來源投影片外觀時是首選。僅將內容複製到不相關的目標 Master 可能會改變受主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留其目前的 Master 與版面配置，請從來源主題為投影片層級建立覆寫。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/overridetheme/) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/overridetheme/) 方法會將三個主要主題元件複製到覆寫中。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

此方式會變更該投影片使用的主題，而不會影響其他投影片繼承的主題。若要移除本機覆寫並回復至繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/overridetheme/)。

### **將主題覆寫套用至版面配置**

版面配置層級的覆寫會套用至使用該版面配置的所有投影片，除非特定投影片自行有覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/layoutslidethememanager/) 使用：

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

當許多版面與投影片應共享相同基礎設計時，使用 Master 或簡報層級的主題；當單一版面族群需要不同樣式時，使用版面覆寫；僅在真正例外的情況下才使用投影片覆寫。過度的投影片層級覆寫會使後續全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填滿儲存在 [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iformatscheme/) 中。PowerPoint 在 UI 中可呈現的背景選項比此集合實際儲存的填滿定義更多，因為 UI 可以將主題填滿與主題顏色及其他樣式參照結合。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

在使用背景樣式前，請檢查儲存的集合與目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/background/)。`0` 表示沒有主題填滿；正值則代表主題背景樣式參照。這與直接以 Java 集合索引不同，`get_Item(0)` 代表第一筆儲存項目。請勿假設每個簡報都有相同數量的背景填滿樣式。

以下範例報告可用的背景填滿數量，將有主題的背景參照指派給第一個 Master，並儲存簡報：

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

最終顯示結果取決於 Master 參照的主題條目以及版面配置或投影片層級的任何背景覆寫。如果投影片使用自己的背景，僅變更 Master 背景可能不會影響該投影片。當需要取得繼承後的最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
請勿將樣式索引當作零基集合索引。也請避免硬編碼某檔案的樣式編號並假設在其他檔案中具相同外觀；主題樣式定義是簡報特有的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
欲了解直接背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/androidjava/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含分別的填滿、線條與效果樣式集合，透過 [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iformatscheme/) 暴露。典型的 Office 主題常包含三筆主要樣式條目，視覺上對應為細緻、適中與強烈的格式，但程式碼應檢查每個集合，而非假設固定數量。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

在 Java 中存取這些集合時，集合索引為零基：`get_Item(0)` 為第一筆儲存的樣式，`get_Item(2)` 為第三筆。形狀的樣式參照索引是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapestyle/) 暴露。修改主題樣式會影響參照該主題樣式的形狀；直接格式化的形狀可能保持不變。

以下範例檢查所需的樣式條目是否存在，變更第一筆線條樣式、變更第三筆填滿樣式，並在第三筆效果樣式中啟用外部陰影，最後儲存結果：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對於參照這些槽位的形狀，第一筆主題線條樣式將變為紅色，第三筆主題填滿樣式將變為實心森林綠，第三筆效果樣式則增加距離 10 點的外部陰影。最終視覺結果仍取決於每個形狀參照的樣式槽位以及是否有直接格式覆寫。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **讀取有效主題值**

原始主題物件告訴您在特定層級定義了什麼。有效值則告訴您投影片或形狀在繼承與本機覆寫解析後實際使用的內容。對投影片呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseoverridethememanager/)。對背景使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/background/)，對填滿使用 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/)。

以下範例從投影片讀取有效的主題、背景與第一個形狀的填滿：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

請使用有效資料進行呈現診斷、驗證與比較。如果只檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)，可能會錯過改變最終外觀的 Master、版面、投影片或形狀覆寫。

## **常見問題**

**我可以在不變更 Master 的情況下僅對單一投影片套用主題嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更僅限於該投影片，其他投影片仍保留各自的繼承主題。

**將主題從一個簡報搬移到另一個簡報的最安全方法是什麼？**

在搬移投影片且需保留來源外觀時，請使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslidecollection/) 將來源 Master 複製到目標簡報，然後使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/) 以該 Master 複製投影片。這樣可同時保留 Master、版面配置與主題。

**我如何查看繼承與覆寫後的有效值？**

對投影片或版面配置的主題使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseoverridethememanager/)，對格式物件如 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/) 使用相對應的有效資料方法。這些 API 會在繼承與覆寫套用後回傳解析後的值。
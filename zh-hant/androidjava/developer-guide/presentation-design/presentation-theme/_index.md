---
title: 在 Android 上管理簡報佈景主題
linktitle: 簡報佈景主題
type: docs
weight: 10
url: /zh-hant/androidjava/presentation-theme/
keywords:
- PowerPoint 佈景主題
- 簡報佈景主題
- 投影片佈景主題
- 設定佈景主題
- 變更佈景主題
- 管理佈景主題
- 佈景主題顏色
- 額外調色盤
- 佈景主題字型
- 佈景主題樣式
- 佈景主題效果
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "透過 Java 在 Android 上的 Aspose.Slides 掌握簡報佈景主題，以建立、客製化與轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題 定義了一組協調的顏色、字型、背景樣式、填滿、線條與效果。支援佈景主題的物件 會參照這些共用定義，而不是將每個視覺屬性儲存為固定值，因此變更佈景主題時 可以一次更新許多物件。

在 Aspose.Slides 中，可透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 取得投影片層級的佈景主題。投影片也可以在較低層級上覆寫佈景主題。母片可透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/masterthememanager/) 覆寫投影片佈景主題，而版面配置或單一投影片可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseoverridethememanager/) 覆寫繼承而來的佈景主題。實務上，投影片的實際佈景主題 會透過以下繼承鏈決定：投影片佈景主題 → 母片覆寫 → 版面配置覆寫 → 投影片覆寫。

![佈景主題組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下章節說明最常見的佈景主題工作流程：檢查佈景主題、變更顏色與字型、複製或套用佈景主題、更新背景與效果樣式，以及在繼承與覆寫完成後讀取實際值。

## **檢查佈景主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mastertheme/) 物件 會透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mastertheme/) 以及 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mastertheme/) 公開佈景主題的顏色配置、字型配置與格式配置。在變更前先檢視這些集合 非常有用，尤其是投影片來源於外部檔案時，樣式項目的數量與內容可能會不同。

以下範例讀取主要佈景主題屬性，並回報佈景主題中儲存了多少背景、填滿、線條與效果樣式：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的實際佈景主題。請檢查與投影片相關聯的母片，並在版面配置或投影片可能有覆寫時，使用本文後面說明的實際佈景主題工作流程。

## **變更佈景主題顏色**

支援佈景主題的填滿、線條與文字 可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在 [IColorScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icolorscheme/) 中變更相對應的項目時，所有仍參照該佈景主題顏色的物件 會以新值重新解析。直接使用 RGB 顏色的物件 則不會因佈景主題顏色的更新而改變。

以下端對端範例建立一個使用 `Accent4` 的圖形，將佈景主題的 `Accent4` 顏色改為紅色，儲存投影片，重新開啟後列印實際填滿顏色：

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

因為矩形仍與 `Accent4` 連結，佈景主題變更後其可見顏色會變成紅色。若您在圖形上將方案顏色取代為直接顏色，之後對 `Accent4` 的變更將不再影響該填滿。

### **使用附加調色盤的顏色**

PowerPoint 會透過顏色變換，從佈景主題顏色衍生出較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/colortransformoperation/) 列舉公開這些變換。

![主要佈景主題顏色與由附加調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要佈景主題顏色。

**2** - 由主要佈景主題顏色產生的較亮與較暗變體。

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

這些變體仍以佈景主題顏色為基礎。若之後變更 `Accent4`，變換後的顏色會根據新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映到 `IColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icolorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 來呈現相同的佈景主題插槽。對映固定如下：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是相同佈景主題插槽的別名；並非會在執行時動態轉換的值。

## **變更佈景主題字型**

佈景主題字型配置 包含標題的主要字型集合與內文字的次要字型集合。[IFontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontscheme/) 與 [IFontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontscheme/) 方法會公開這兩個集合。

PowerPoint 相容的佈景主題字型識別碼 可用於文字格式化：

* `+mn-lt` - 內文字拉丁字型 (Minor Latin Font)
* `+mj-lt` - 標題拉丁字型 (Major Latin Font)
* `+mn-ea` - 內文字東亞字型 (Minor East Asian Font)
* `+mj-ea` - 標題東亞字型 (Major East Asian Font)

以下範例建立一個使用主要拉丁佈景主題字型的標題與一個使用次要拉丁佈景主題字型的內文，然後變更佈景主題字型並儲存結果：

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

標題會遵循主要字型，內文則遵循次要字型。若文字使用了明確的字型名稱而非佈景主題識別碼，則在佈景主題字型方案變更時不會自動切換。

主要與次要字型集合亦可包含針對個別書寫系統（例如西里爾文、阿拉伯文、日文、喬治亞文與塔安那文）的字型對映。若要檢查、加入、取代或移除這些對映，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/androidjava/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲取得更多有關簡報字型的資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/androidjava/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用佈景主題**

有兩種常見工作流程，且它們解決的問題不同。

### **在搬移投影片時保留來源佈景主題**

若您想將投影片搬移至另一個簡報且保留其原始設計，請使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslidecollection/) 將來源母片複製到目標簡報，然後使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/) 搭配複製的母片來複製投影片。這樣會同時攜帶母片、其版面配置與相關聯的佈景主題。

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

這是當來源投影片必須在目的地保持相同外觀時的首選工作流程。直接將內容複製到不相關的目的地母片上，可能會改變受佈景主題驅動的顏色、字型、背景與效果。

### **將佈景主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面配置，請從來源佈景主題初始化投影片層級的覆寫。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/overridetheme/) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/overridetheme/) 方法會將三個主要佈景主題元件複製到覆寫中。

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

此做法會變更該投影片使用的佈景主題，而不會影響其他投影片繼承的佈景主題。若要移除本機覆寫並回復至繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/overridetheme/)。

### **將佈景主題覆寫套用至版面配置**

版面配置層級的覆寫會套用至使用該版面配置的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/layoutslidethememanager/) 使用：

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

當多個版面配置與投影片需要共享相同的基礎設計時，請使用母片或簡報層級的佈景主題；需要不同樣式的版面配置則使用版面配置覆寫；僅在真正例外時才使用投影片覆寫。過多的投影片層級覆寫會使之後的全域佈景主題變更變得難以預測。

## **更新佈景主題背景樣式**

佈景主題的背景填滿儲存在 [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iformatscheme/) 中。PowerPoint 在 UI 中可以呈現比此集合實際儲存的填滿定義更多的背景選項，因為 UI 能將佈景主題填滿與佈景主題顏色及其他樣式參照結合。

![PowerPoint 針對簡報佈景主題的背景樣式庫](presentation-design_8.png)

在使用背景樣式之前，請檢查已儲存的集合以及目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/background/)。`0` 表示沒有佈景主題填滿；正值則是佈景主題背景樣式的參照。這與直接以 Java 集合索引不同，`get_Item(0)` 代表第一筆儲存的項目。請勿假設每個簡報都有相同數量的背景填滿樣式。

以下範例回報可用的背景填滿數量，將佈景主題背景參照指派給第一個母片，並儲存簡報：

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

實際顯示的結果取決於母片所參照的佈景主題條目，以及版面配置或投影片層級的任何背景覆寫。如果投影片使用自己的背景，僅更改母片背景可能不會影響該投影片。需要取得繼承後的最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
請勿將樣式索引當作零基集合索引來使用。也不要從單一檔案硬編碼樣式編號，並假設在其他檔案中會有相同外觀；佈景主題樣式定義是針對簡報而定的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
欲取得直接背景格式設定與背景繼承相關資訊，請參閱 [Presentation Background](/slides/zh-hant/androidjava/presentation-background/)。
{{% /alert %}}

## **更新佈景主題效果**

佈景主題格式方案包含分別的填滿、線條與效果樣式集合，分別透過 [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iformatscheme/) 暴露。一般 Office 佈景主題常包含三個主要樣式條目，視覺上分別對應為淡雅、適中與強烈的格式，但程式碼應檢查每個集合，而不是假設固定的計數。

![淡雅、適中與強烈的佈景主題效果套用於同一圖形](presentation-design_10.png)

在 Java 中存取這些集合時，集合索引是從零開始：`get_Item(0)` 為第一筆儲存的樣式，`get_Item(2)` 為第三筆。圖形的樣式參照索引是另一個概念，透過 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapestyle/) 暴露。修改佈景主題樣式會影響所有參照該樣式的圖形；直接格式化的圖形可能保持不變。

以下範例檢查必要的樣式條目是否存在，變更第一個線條樣式、變更第三個填滿樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

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

對於參照這些插槽的圖形而言，第一個佈景主題線條樣式會變成紅色，第三個佈景主題填滿樣式會變成實心森林綠，第三個效果樣式會新增一個距離為 10 點的外部陰影。最終的視覺結果仍取決於每個圖形參照的樣式插槽以及是否有直接格式化覆寫佈景主題。

![變更線條、填滿與陰影設定後的佈景主題效果樣式](presentation-design_11.png)

## **讀取實際佈景主題值**

原始佈景主題物件告訴您在特定層級上定義了什麼。實際值告訴您投影片或圖形在繼承與本機覆寫解析後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseoverridethememanager/)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/background/)，對於填滿，使用 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/)。

以下範例讀取投影片的實際佈景主題、背景與第一個圖形的填滿：

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

將實際資料用於渲染偵錯、驗證與比較。如果僅檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)，可能會錯過改變最終外觀的母片、版面配置、投影片或圖形覆寫。

## **常見問題**

**我可以在不變更母片的情況下，將佈景主題套用到單一投影片嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidethememanager/) 並初始化其覆寫佈景主題。變更僅限於該投影片；其他投影片仍繼承現有佈景主題。

**從一個簡報搬移佈景主題到另一個簡報的最安全方式是什麼？**

在搬移投影片並保留來源外觀時，請將來源母片使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslidecollection/) 複製到目的地，然後使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/) 搭配該母片複製投影片。這樣可同時保留母片、版面配置與佈景主題。

**我該如何在繼承與覆寫完成後看到實際值？**

對於投影片或版面配置佈景主題，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseoverridethememanager/)。對於格式物件，如背景與填滿，分別使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/)。這些 API 會在繼承與覆寫套用後返回解析後的值。
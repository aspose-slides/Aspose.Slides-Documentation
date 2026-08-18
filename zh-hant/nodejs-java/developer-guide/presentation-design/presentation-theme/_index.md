---
title: 在 JavaScript 中管理簡報佈景主題
linktitle: 簡報佈景主題
type: docs
weight: 10
url: /zh-hant/nodejs-java/presentation-theme/
keywords:
- PowerPoint 佈景主題
- 簡報佈景主題
- 投影片佈景主題
- 設定佈景
- 變更佈景
- 管理佈景
- 佈景顏色
- 額外調色盤
- 佈景字型
- 佈景樣式
- 佈景效果
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中管理主簡報佈景主題，以建立、客製化並轉換具有一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題定義了一組協調的顏色、字型、背景樣式、填色、線條以及效果。具備佈景感知的物件會參考這些共享的定義，而不是將每個視覺屬性儲存為固定值，因此佈景變更可以一次更新許多物件。

在 Aspose.Slides 中，可以透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getmastertheme/) 取得簡報層級的佈景主題。簡報也可以在較低層級包含佈景覆寫。母片可透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterthememanager/) 覆寫簡報佈景，而版面配置或個別投影片則可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseoverridethememanager/) 覆寫其繼承的佈景。實務上，投影片的有效佈景會透過以下繼承鏈決定：簡報佈景、母片覆寫、版面覆寫以及投影片覆寫。

![佈景組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下章節說明最常見的佈景工作流程：檢查佈景、變更顏色與字型、複製或套用佈景、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢查佈景**

MasterTheme 物件透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/)、與 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/) 公開佈景的色彩配置、字型配置與格式配置。在變更之前檢查這些集合尤其在簡報來源於外部時很有用，因為樣式條目的數量與內容可能會不同。

以下範例會讀取主要佈景屬性，並回報佈景中儲存的背景、填色、線條與效果樣式數量：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

如果檔案使用多個母片，不應假設每張投影片都有相同的有效佈景。請檢查與投影片關聯的母片，且在可能存在版面或投影片覆寫的情況下，使用本文稍後示範的有效佈景工作流程。

## **變更佈景顏色**

具佈景感知的填色、線條與文字可以參考 [SchemeColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您變更 [ColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colorscheme/) 中對應的條目時，所有仍參考該佈景顏色的物件都會以新值進行解析。使用直接 RGB 顏色的物件不會受到佈景顏色更新的影響。

以下端對端範例會建立一個使用 `Accent4` 的圖形，將佈景的 `Accent4` 顏色變更為紅色，儲存簡報，重新開啟，並印出有效的填色顏色：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

因為矩形仍連結至 `Accent4`，在佈景變更後其可見顏色會變成紅色。如果您將圖形上的方案顏色改為直接顏色，之後對 `Accent4` 的變更將不再影響該填色。

### **使用額外調色盤的顏色**

PowerPoint 透過套用顏色變換，從佈景顏色衍生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colortransformoperation/) 列舉公開這些變換。

![主要佈景顏色以及從額外調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要佈景顏色。

**2** - 從主要佈景顏色產生的較亮與較暗變體。

以下範例會建立六個基於 `Accent4` 的矩形，對其中五個套用亮度變換，並儲存結果：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

這些變體仍以佈景顏色為基礎。如果稍後 `Accent4` 變更，變換後的顏色會根據新 `Accent4` 值重新計算。

### **對映 `SchemeColor` 值至 `ColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2` 與 `Background2`，而 [ColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colorscheme/) 以 `Dark1`、`Light1`、`Dark2`、`Light2` 方式公開相同的佈景槽位。對映是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是相同佈景槽位的別名；它們不是動態相互轉換的值。

## **變更佈景字型**

佈景字型配置包含用於標題的主要字型集合與用於正文的次要字型集合。[FontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontscheme/) 與 [FontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontscheme/) 方法會公開這些集合。

PowerPoint 相容的佈景字型識別碼可以用於文字格式化：

* `+mn-lt` - 正文字體 Latin（次要 Latin 字體）
* `+mj-lt` - 標題字體 Latin（主要 Latin 字體）
* `+mn-ea` - 正文字體 東亞（次要 東亞字體）
* `+mj-ea` - 標題字體 東亞（主要 東亞字體）

以下範例會建立一個使用主要 Latin 佈景字體的標題，以及一行使用次要 Latin 佈景字體的正文。然後變更佈景字型並儲存結果：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

標題會使用主要字型，正文則使用次要字型。若文字使用明確的字型名稱而非佈景識別碼，當佈景字型配置變更時不會自動切換。

{{% alert color="info" title="提示" %}}
如需有關簡報字型的更多資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/nodejs-java/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用佈景**

有兩種常見工作流程，且它們解決不同的問題。

### **在移動投影片時保留來源佈景**

如果您想將投影片移至另一個簡報且保留其原始設計，請使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslidecollection/) 將來源母片複製到目標簡報，然後使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/) 並搭配已複製的母片複製投影片。這會同時攜帶母片、其版面配置以及相關的佈景。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

當來源投影片必須在目的地保持相同外觀時，這是首選工作流程。僅將內容複製到不相關的目標母片上可能會改變受佈景影響的顏色、字型、背景與效果。

### **將佈景值套用到現有投影片**

如果目標投影片必須保留其目前的母片與版面配置，請從來源佈景初始化投影片層級的覆寫。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/)、與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/) 方法會將三個主要佈景組件複製到覆寫中。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

此變更會只改變該投影片使用的佈景，而不會更改其他投影片所繼承的佈景。若要移除本機覆寫並回復至繼承的值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/)。

### **將佈景覆寫套用至版面配置**

版面層級的覆寫會套用到使用該版面的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslidethememanager/) 使用：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

當許多版面與投影片應共享相同基礎設計時，請使用母片或簡報層級的佈景；當單一版面族需要不同樣式時，使用版面覆寫；僅在真正的例外情況下才使用投影片覆寫。過多的投影片層級覆寫會使之後的全域佈景變更較難預測。

## **更新佈景背景樣式**

佈景的背景填色儲存在 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/) 中。PowerPoint 在使用者介面中可以呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 可以將佈景填色與佈景顏色及其他樣式參考結合。

![PowerPoint 簡報佈景的背景樣式畫廊](presentation-design_8.png)

在使用背景樣式之前，請檢查儲存的集合與目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/)。樣式索引為 `0` 代表沒有佈景填色；正值則是佈景背景樣式的參考。這與直接對 JavaScript 集合索引不同，後者的索引 `0` 代表第一個儲存項目。請勿假設每個簡報都有相同數量的背景填色樣式。

以下範例會回報可用的背景填色數量，將佈景背景參考指派給第一個母片，並儲存簡報：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

可見結果取決於母片參考的佈景條目以及版面或投影片層級的任何背景覆寫。若投影片使用自己的背景，僅變更母片背景可能不會影響該投影片。當您需要知道套用繼承後的最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/)。

{{% alert color="warning" title="警告" %}}
不要將樣式索引視為零基集合索引。亦避免從一個檔案硬編碼樣式編號並假設在另一個檔案中具有相同外觀；佈景樣式定義是簡報特定的。
{{% /alert %}}

{{% alert color="info" title="提示" %}}
如需直接背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/nodejs-java/presentation-background/)。
{{% /alert %}}

## **更新佈景效果**

佈景格式方案包含透過 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/)、與 [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/) 所公開的獨立填色、線條與效果樣式集合。典型的 Office 佈景通常包含三個主要樣式條目，視覺上分別對應細緻、適度與強烈的格式，但程式碼應檢查每個集合，而非假設固定數量。

![細緻、適度與強烈的佈景效果套用於同一圖形](presentation-design_10.png)

在 JavaScript 中存取這些集合時，集合索引為零基：索引 `0` 為第一個儲存的樣式，索引 `2` 為第三個。圖形的樣式參考索引是另一個概念，透過 [ShapeStyle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapestyle/) 公開。修改佈景樣式會影響參考該佈景樣式的圖形；直接格式設定的圖形可能保持不變。

以下範例會檢查所需的樣式條目是否存在，變更第一個線條樣式、變更第三個填色樣式、在第三個效果樣式中啟用外部陰影，並儲存結果：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對於參考這些槽位的圖形而言，第一個佈景線條樣式會變成紅色，第三個佈景填色樣式會變成實心森林綠，且第三個效果樣式會新增距離 10 點的外部陰影。最終的視覺結果仍取決於每個圖形參考的樣式槽位以及直接格式設定是否覆寫佈景。

![變更線條、填色與陰影設定後的佈景效果樣式](presentation-design_11.png)

## **讀取有效佈景值**

原始佈景物件會告訴您在特定層級定義了什麼。有效值則告訴您投影片或圖形在繼承與本機覆寫解析後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseoverridethememanager/)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/ )；對於填色，使用 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/)。

以下範例會從投影片讀取有效佈景、背景以及第一個圖形的填色：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

使用有效資料可進行渲染診斷、驗證與比較。如果僅檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getmastertheme/)，可能會遺漏改變最終外觀的母片、版面、投影片或圖形覆寫。

## **常見問題**

**我可以在不變更母片的情況下，將佈景套用至單一投影片嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidethememanager/) 並初始化其覆寫佈景。此變更僅限於該投影片；其他投影片仍會繼承其現有佈景。

**從一個簡報搬移佈景到另一個簡報，最安全的做法是什麼？**

在搬移投影片且保留來源外觀時，請使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslidecollection/) 將來源母片複製到目標，然後使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/) 並搭配該母片複製投影片。這樣可同時保留母片、版面配置與佈景。

**如何在繼承與覆寫後查看有效值？**

使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseoverridethememanager/) 取得投影片或版面佈景的有效佈景，並使用格式物件的相應有效資料方法，如 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/)。這些 API 會在套用繼承與覆寫後回傳解析後的值。
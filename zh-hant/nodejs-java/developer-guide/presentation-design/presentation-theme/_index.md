---
title: 在 JavaScript 中管理簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/nodejs-java/presentation-theme/
keywords:
- PowerPoint 主題
- 簡報主題
- 投影片主題
- 設定主題
- 變更主題
- 管理主題
- 主題顏色
- 附加調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中掌握簡報主題，以建立、客製化及轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調一致的顏色、字型、背景樣式、填色、線條與效果。具備主題感知的物件會參考這些共享定義，而不是將每個視覺屬性儲存為固定值，這樣變更主題即可一次更新許多物件。

在 Aspose.Slides 中，可透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getmastertheme/) 取得簡報層級的主題。簡報也可以在較低層級包含主題覆寫。母片可透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterthememanager/) 覆寫簡報主題，而版面配置或單一投影片可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseoverridethememanager/) 覆寫其繼承的主題。實務上，投影片的最終主題會依照以下繼承鏈解析：簡報主題 → 母片覆寫 → 版面配置覆寫 → 投影片覆寫。

![主題組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下章節說明最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，並在繼承與覆寫解析後讀取有效值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/) 物件透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/) 與 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/) 透露主題的顏色配置、字型配置與格式配置。變更前先檢查這些集合非常有用，特別是當簡報來自外部來源時，樣式項目的數量與內容可能會不同。

以下範例讀取主要主題屬性，並回報主題中儲存了多少個背景、填色、線條與效果樣式：

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

如果檔案使用多個母片，請不要假設每張投影片都有相同的有效主題。檢查與投影片相關的母片，並在版面或投影片可能有覆寫時使用本文稍後說明的有效主題工作流程。

## **變更主題顏色**

具備主題感知的填色、線條與文字可參考 [SchemeColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您變更 [ColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colorscheme/) 中對應的條目時，仍參考該主題顏色的所有物件皆會以新值解析。直接使用 RGB 顏色的物件不會受到主題顏色更新的影響。

以下端對端範例建立一個使用 `Accent4` 的形狀，將主題的 `Accent4` 顏色改為紅色，儲存簡報，重新開啟，並列印有效的填色：

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

因為矩形仍連結至 `Accent4`，主題變更後其可見顏色會變成紅色。如果您在形狀上以直接顏色取代方案顏色，之後對 `Accent4` 的變更將不再影響該填色。

### **使用附加調色盤的顏色**

PowerPoint 會透過套用顏色變換，從主題顏色衍生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colortransformoperation/) 列舉公開這些變換。

![主要主題顏色與從附加調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要主題顏色。

**2** - 從主要主題顏色產生的較亮與較暗變體。

以下範例建立六個基於 `Accent4` 的矩形，對其中五個套用亮度變換，並儲存結果：

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

這些變體仍以主題顏色為基礎。如果之後 `Accent4` 變更，變換後的顏色會以新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [ColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colorscheme/) 以 `Dark1`、`Light1`、`Dark2`、`Light2` 暴露相同的主題插槽。對映固定如下：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是同一主題插槽的別名；並非會動態相互轉換的值。

## **變更主題字型**

主題字型配置包含標題的主要字型集合與內文的次要字型集合。[FontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontscheme/) 與 [FontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontscheme/) 方法公開這兩個集合。

PowerPoint 相容的主題字型識別子可在文字格式設定中使用：

* `+mn-lt` - 內文拉丁字型（次要拉丁字型）
* `+mj-lt` - 標題拉丁字型（主要拉丁字型）
* `+mn-ea` - 內文東亞字型（次要東亞字型）
* `+mj-ea` - 標題東亞字型（主要東亞字型）

以下範例建立一個使用主要拉丁字型的標題與一個使用次要拉丁字型的內文行，然後變更主題字型並儲存結果：

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

標題遵循主要字型，內文字則遵循次要字型。若文字明確指定字型名稱而非主題識別子，則在主題字型配置變更時不會自動切換。

主要與次要字型集合也可以包含針對個別書寫系統（如西里爾文、阿拉伯文、日文、喬治亞文與塔納文）的字型對映。若要檢查、加入、取代或移除這些對映，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/nodejs-java/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
如需更多關於簡報字型的資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/nodejs-java/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

有兩種常見工作流程，且解決不同的問題。

### **在移動投影片時保留來源主題**

如果您想將投影片移至另一個簡報且保留其原始設計，請使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslidecollection/) 將來源母片克隆到目標簡報，接著使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/) 以及克隆的母片將投影片克隆過去。這樣會同時攜帶母片、其版面配置與相關主題。

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

這是當來源投影片必須在目標檔案中保持相同外觀時的首選流程。僅在不相關的目標母片上克隆內容可能會改變受主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

如果目標投影片必須保留目前的母片與版面配置，請從來源主題為投影片層級建立覆寫。使用 [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/) 方法將三個主要主題元件複製到覆寫中。

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

這會變更該投影片使用的主題，而不會影響其他投影片繼承的主題。若要移除本地覆寫並回復至繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/)。

### **將主題覆寫套用至版面配置**

版面層級的覆寫會套用到使用該版面的所有投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslidethememanager/) 使用：

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

當許多版面與投影片應共享相同的基礎設計時，使用母片或簡報層級的主題；當某一版面族群需要不同樣式時，使用版面覆寫；僅在真正的例外情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填色儲存在 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/) 中。PowerPoint 在 UI 中可以呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 能將主題填色與主題顏色及其他樣式參考結合。

![PowerPoint 簡報主題的背景樣式圖庫](presentation-design_8.png)

在使用背景樣式前，請檢查已儲存的集合與目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/)。`0` 代表沒有主題填色；正值代表主題背景樣式參考。這與直接索引 JavaScript 集合不同，後者的 `0` 代表第一個儲存項目。不要假設每個簡報都有相同數量的背景填色樣式。

以下範例回報可用的背景填色數量，將主題背景參考指派給第一個母片，並儲存簡報：

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

可見結果取決於母片參考的主題項目以及版面或投影片層級的任何背景覆寫。如果投影片使用自己的背景，只變更母片背景可能不會影響該投影片。當您需要了解繼承套用後的最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
請勿將樣式索引視為零基集合索引。也避免從一個檔案硬編碼樣式編號，並假設在另一個檔案中會有相同外觀；主題樣式定義是簡報特有的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有關直接背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/nodejs-java/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式配置包含透過 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/) 公開的獨立填色、線條與效果樣式集合。典型的 Office 主題常包含三個主要樣式項目，對應視覺上為細緻、適中與強烈的格式，但程式碼應檢查每個集合，而非假設固定數量。

![相同圖形上套用的細緻、適中與強烈主題效果](presentation-design_10.png)

在 JavaScript 中存取這些集合時，集合索引為零基：`0` 為第一個儲存的樣式，`2` 為第三個。形狀的樣式參考索引是另一概念，透過 [ShapeStyle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapestyle/) 暴露。修改主題樣式會影響參考該主題樣式的形狀；直接格式設定的形狀可能保持不變。

以下範例檢查必要的樣式項目是否存在，變更第一個線條樣式、變更第三個填色樣式、在第三個效果樣式中啟用外部陰影，並儲存結果：

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

對於參考這些插槽的形狀而言，第一個主題線條樣式會變成紅色，第三個主題填色樣式會變成純森林綠，第三個效果樣式會獲得距離 10 點的外部陰影。最終的視覺結果仍取決於每個形狀參考的樣式插槽以及是否有直接格式覆寫主題。

![變更線條、填色與陰影設定後的主題效果樣式](presentation-design_11.png)

## **讀取有效的主題值**

原始主題物件告訴您在特定層級定義了什麼。有效值則告訴您投影片或形狀在繼承與本地覆寫解析後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseoverridethememanager/)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/)，對於填色，使用 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/)。

以下範例從投影片讀取有效的主題、背景與第一個形狀的填色：

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

使用有效資料進行渲染偵錯、驗證與比較。如果只檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getmastertheme/)，可能會錯過母片、版面、投影片或形狀的覆寫，從而改變最終外觀。

## **常見問題**

**我可以在不更改母片的情況下，只對單一投影片套用主題嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更僅保留於該投影片；其他投影片仍會繼承現有的主題。

**將主題從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片且保留來源外觀時，請使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslidecollection/) 將來源母片克隆至目的地，然後使用 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/) 搭配該母片克隆投影片。這樣可同時保留母片、版面與主題。

**如何在繼承與覆寫後查看有效的值？**

對於投影片或版面配置的主題，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseoverridethememanager/)。對於格式物件（例如 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/)），使用對應的有效資料方法。這些 API 會在繼承與覆寫套用後返回解析後的值。
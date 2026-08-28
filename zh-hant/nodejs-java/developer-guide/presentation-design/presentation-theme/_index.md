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
- 外部主題
- THMX
- 主題顏色
- 額外調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中掌握簡報主題，建立、客製化並轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字型、背景樣式、填充、線條與效果。具備主題感知的物件會參考這些共享定義，而不是將每個視覺屬性儲存為固定值，因此變更主題時可以一次更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getmastertheme/) 取得。簡報亦可在較低層級包含主題覆寫。主版可透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterthememanager/) 覆寫簡報主題，而版面配置或單一投影片則可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseoverridethememanager/) 覆寫其繼承的主題。實務上，投影片的實際主題是透過以下繼承鏈解析：簡報主題、主版覆寫、版面配置覆寫以及投影片覆寫。

![主題組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下段落說明最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取實際值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/) 物件透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/) 與 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/) 透露主題的顏色配置、字型配置與格式配置。在變更前檢查這些集合，特別是當簡報來源於外部檔案時十分有用，因為樣式項目的數量與內容可能有所不同。

以下範例讀取主要主題屬性，並回報主題中儲存了多少個背景、填充、線條與效果樣式：

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

如果檔案使用多個主版，請不要假設每張投影片都有相同的實際主題。檢查與投影片相關的主版，並在版面配置或投影片可能有覆寫時，使用本文稍後說明的實際主題工作流程。

## **變更主題顏色**

具備主題感知的填充、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在 [ColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colorscheme/) 中變更對應的條目時，仍參照該主題顏色的所有物件皆會以新值重新解析。使用直接 RGB 顏色的物件不會因主題顏色更新而變更。

以下端對端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色改為紅色，儲存簡報、重新開啟，並印出實際的填充顏色：

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

因為矩形仍然連結至 `Accent4`，主題變更後其可見顏色會變成紅色。若您在圖形上將此配色改為直接顏色，之後對 `Accent4` 的變更將不再影響該填充。

### **使用額外調色盤的顏色**

PowerPoint 會透過套用顏色變換，從主題顏色衍生出較淡與較深的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colortransformoperation/) 列舉公布這些變換。

![主要主題顏色與從額外調色盤產生的較淡與較深顏色](additional-palette-colors.png)

**1** - 主要主題顏色。  
**2** - 從主要主題顏色產生的較淡與較深變體。

以下範例依 `Accent4` 建立六個矩形，對其中五個套用亮度變換，並儲存結果：

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

這些變體仍以主題顏色為基礎。若之後 `Accent4` 變更，變換後的顏色會依新 `Accent4` 的值重新計算。

### **將 `SchemeColor` 值映射至 `ColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [ColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 暴露相同的主題插槽。映射是固定的：

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

這些是同一主題插槽的別名；它們不是會動態相互轉換的值。

## **變更主題字型**

主題字型配置包含標題的主要字型集合與正文的次要字型集合。[FontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontscheme/) 與 [FontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontscheme/) 方法公開這兩個集合。

PowerPoint 相容的主題字型識別子可用於文字格式化：

* `+mn-lt` - 正文字型拉丁文（Minor Latin Font）  
* `+mj-lt` - 標題字型拉丁文（Major Latin Font）  
* `+mn-ea` - 正文字型東亞語系（Minor East Asian Font）  
* `+mj-ea` - 標題字型東亞語系（Major East Asian Font）

以下範例建立一個使用主要拉丁文字型的標題與一個使用次要拉丁文字型的正文，然後變更主題字型並儲存結果：

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

標題遵循主要字型，正文遵循次要字型。若文字明確指定了字型名稱而非主題識別子，則在主題字型配置變更時不會自動切換。

主要與次要字型集合亦可包含針對個別書寫系統（如西里爾文、阿拉伯文、日文、喬治亞文與塔納字母）的字型對應。若要檢查、新增、取代或移除這些對應，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/nodejs-java/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲取得更多簡報字型資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/nodejs-java/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至主版相依的投影片**

當您有 PowerPoint 主題檔（`.thmx`）且想重新樣式化所有相依於特定主版的投影片時，使用 [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/)。先從 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 集合（由 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslidecollection/) 表示）選取主版，然後將主題檔路徑傳給此方法。

此方法執行以下操作：

1. 依所選主版建立新的主版投影片。  
1. 將外部主題套用至新主版。  
1. 將先前相依於所選主版的所有投影片指派給新主版。  
1. 回傳新建立的 [MasterSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/)。

以下範例將外部主題套用至相依於第一個主版的投影片，並儲存簡報：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

無效、損毀或不支援的主題可能會拋出 [PptxReadException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxreadexception/)。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在成功套用主題後才儲存簡報。

僅重新指派相依於所選主版的投影片。其他主版所屬的投影片保留其既有主版與主題。具備主題感知的顏色、字型、填充、線條、背景與效果會根據外部主題重新解析。直接指派的顏色、字型、填充與其他明確格式化可能保持不變。版面配置層級與投影片層級的覆寫亦可能優先於新主版繼承的值。

主題可能參照執行環境中不存在的字型。為了確保一致的描繪與匯出，請安裝所需字型、透過 [custom font sources](/slides/zh-hant/nodejs-java/custom-font/) 提供，或配置 [font substitution](/slides/zh-hant/nodejs-java/font-substitution/)。

此為直接的主版層級工作流程：方法接受 `.thmx` 檔案路徑，不需要自行建立投影片層級或版面配置層級的主題覆寫。

### **在多主版簡報中套用不同的外部主題**

當事先不知道相關主版時，可透過 [Slide.getLayoutSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/) 取得代表性投影片的版面配置，並以 [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/) 取得其主版。於套用任何主題前先儲存原始主版參考，因為每次呼叫都會在簡報中建立另一個主版。

以下範例使用兩個章節的投影片來找出其主版，並對每個群組套用不同的外部主題：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

第一次呼叫只會影響相依於 `firstGroupMaster` 的投影片，第二次呼叫只會影響相依於 `secondGroupMaster` 的投影片。屬於其他主版的投影片不會被重新樣式化。

### **移動投影片時保留來源主題**

若希望將投影片移至另一份簡報且保留其原始設計，可先以 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslidecollection/) 將來源主版克隆至目標簡報，然後以 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/) 及克隆的主版一起克隆投影片。這會同時攜帶主版、其版面配置以及相關的主題。

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

當來源投影片必須在目標簡報中保持相同外觀時，這是首選工作流程。僅僅將內容克隆到不相關的目標主版，可能會更改受主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留其目前的主版與版面配置，可從來源主題初始化投影片層級的覆寫。使用 [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/) 方法將三個主要主題元件複製到覆寫中。

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

此作法會變更該投影片使用的主題，而不會改變其他投影片所繼承的主題。若要移除本地覆寫並回復繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/)。

### **將主題覆寫套用至版面配置**

版面配置層級的覆寫會套用至使用該版面的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslidethememanager/) 使用：

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

當許多版面配置與投影片應共享相同基礎設計時，使用主版或簡報層級的主題；當某一版面配置家族需要不同樣式時，使用版面配置覆寫；僅在真正的例外情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填充儲存在 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/) 中。PowerPoint 在 UI 中可以呈現比實際儲存於此集合的填充定義更多的背景選項，因為 UI 可以將主題填充與主題顏色及其他樣式參考組合。

![PowerPoint 簡報主題的背景樣式庫](presentation-design_8.png)

在使用背景樣式前，請檢查儲存的集合與目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/)。`0` 表示沒有主題填充；正值表示主題背景樣式參考。這與直接以 JavaScript 索引集合不同，後者的 `0` 代表第一筆儲存項目。請不要假設每個簡報都有相同數量的背景填充樣式。

以下範例回報可用的背景填充計數，將主版的背景參考指派為主題樣式，並儲存簡報：

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

最終可見結果取決於主版參照的主題條目以及版面配置或投影片層級的任何背景覆寫。若投影片使用自己的背景，僅變更主版背景可能不會影響該投影片。需要得知繼承後最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
不要將樣式索引視為零基集合索引。也請避免從一個檔案硬編碼樣式編號，並假設在另一檔案中會有相同外觀；主題樣式定義是簡報專屬的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有關直接背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/nodejs-java/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式配置包含透過 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/) 暴露的獨立填充、線條與效果樣式集合。典型的 Office 主題常包含三個主要樣式條目，視覺上分別對應微妙、中等與強烈的格式化，但程式碼應檢查每個集合，而不是假設固定數量。

![對同一圖形套用微妙、中等與強烈主題效果](presentation-design_10.png)

在 JavaScript 中存取這些集合時，集合索引是零基的：`0` 為第一筆儲存樣式，`2` 為第三筆。圖形的樣式參考索引是另一概念，透過 [ShapeStyle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapestyle/) 暴露。修改主題樣式會影響所有參考該主題樣式的圖形；直接格式化的圖形可能保持不變。

以下範例確認所需的樣式條目存在，變更第一個線條樣式、變更第三個填充樣式、在第三個效果樣式中啟用外部陰影，並儲存結果：

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

對於參考這些插槽的圖形，第一個主題線條樣式會變為紅色，第三個主題填充樣式會變為實心森林綠，第三個效果樣式會增加距離為 10 點的外部陰影。最終的視覺結果仍取決於每個圖形參考的樣式插槽以及是否有直接格式化覆寫主題。

![變更線條、填充與陰影設定後的主題效果樣式](presentation-design_11.png)

## **判斷實際實心填充是否使用主題顏色**

填充可以直接儲存在物件上，或從段落、版面配置、主版、主題樣式或其他格式層級繼承。呼叫 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/) 可將該階層解析為不可變的實際填充快照。首先檢查其 `getFillType` 值，僅在其為 `FillType.Solid` 時才讀取實心填充屬性。

對於實心填充，`getSolidFillColor` 會在繼承、主題查找與顏色變換應用後返回最終渲染的 RGB 值。`getSolidFillSchemeColor` 方法則返回對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/schemecolor/) 插槽，例如 `Text1` 或 `Accent6`。`SchemeColor.NotDefined` 表示實際實心填充並未基於配色方案。於只使用主題顏色或直接 RGB 顏色的工作流程中，此值可識別直接 RGB 填充。

不要僅依賴本地的 [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colorformat/) 值來分類填充。例如，文字段落可能沒有本地定義的配色方案顏色，因此其本地值為 `NotDefined`，但其實際填充繼承自主題顏色並解析為 `Text1` 或 `Accent6`。相反，`getSolidFillSchemeColor` 告訴您是哪個邏輯主題插槽產生了最終顏色，但不告訴您該插槽是來自物件、段落、版面配置、主版或其他層級。

以下範例載入簡報，稽核圖形填充與文字段落填充，印出每個最終 RGB 值與關聯的配色方案，並標記不會追蹤主題顏色變更的實心填充：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`NotDefined` 分支提供了不會因主題顏色槽變更而更新的實心填充稽核清單。當簡報必須遵循新品牌調色盤時，請檢查這些物件。報告的 RGB 值仍顯示目前外觀，而配色方案值說明該外觀是否與主題相連。

實際格式物件是快照。變更簡報主題、主題覆寫或任何繼承格式後，請再次呼叫 `getEffective` 並在比較或報告顏色前讀取新的實際填充物件。

## **讀取實際主題值**

原始主題物件告訴您在特定層級定義了什麼。實際值則告訴您投影片或圖形在繼承與本地覆寫解析後實際使用了什麼。對於投影片，呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseoverridethememanager/)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/)，對於填充則使用 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/)。

以下範例從投影片讀取實際主題、背景與第一個圖形填充：

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

使用實際資料進行呈現診斷、驗證與比較。如果僅檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getmastertheme/)，可能會錯過會改變最終外觀的主版、版面配置、投影片或圖形覆寫。

## **常見問題**

**套用外部主題會影響簡報中的每張投影片嗎？**

不會。[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/) 僅重新指派相依於選取主版的投影片。使用其他主版的投影片會保留其既有主題。

**我可以在不變更主版的情況下，將主題套用到單一投影片嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更僅限於該投影片，其餘投影片仍然繼承既有主題。

**將主題從一個簡報移到另一個簡報最安全的做法是什麼？**

在移動投影片並保留來源外觀時，請使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslidecollection/) 將來源主版克隆至目的簡報，然後以 [SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/) 搭配該主版克隆投影片。這樣可同時保留主版、版面配置與主題。

**如何在繼承與覆寫之後查看實際值？**

對於投影片或版面配置主題，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseoverridethememanager/)。對於格式物件，如 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/)，則使用對應的實際資料方法。這些 API 會在繼承與覆寫套用後返回解析後的值。
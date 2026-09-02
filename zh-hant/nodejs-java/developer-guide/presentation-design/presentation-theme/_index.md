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
- 主題色彩
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
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中管理簡報主題，打造、客製化與轉換 PowerPoint 檔案，確保品牌一致性。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字型、背景樣式、填色、線條與效果。支援主題的物件會參考這些共用定義，而不是將每個視覺屬性儲存為固定值，因而在變更主題時能一次更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getmastertheme/)取得。簡報亦可在較低層級上覆寫主題。母片可透過[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterthememanager/)覆寫簡報主題，而版面或單一投影片則可透過[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseoverridethememanager/)覆寫其繼承的主題。實務上，投影片的最終主題是透過以下繼承鏈解析：簡報主題 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![主題組成：顏色、字型、背景樣式與效果](theme-constituents.png)

以下段落說明最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，並在繼承與覆寫解析後讀取實際值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/) 物件透過[MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/)與[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mastertheme/)公開主題的顏色構成、字型構成與格式構成。在變更之前先檢查這些集合尤其在簡報來源為外部檔案時很有用，因為樣式項目的數量與內容可能不同。

以下範例讀取主要主題屬性，並回報在主題中儲存了多少背景、填色、線條與效果樣式：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的實際主題。檢查投影片所屬的母片，並在版面或投影片可能有覆寫時使用本文稍後說明的實際主題工作流程。

## **變更主題顏色**

支援主題的填色、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您變更 [ColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colorscheme/) 中對應的項目時，所有仍參照該主題顏色的物件都會套用新值。直接使用 RGB 色彩的物件不會受到主題顏色更新的影響。

以下端對端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色改為紅色，保存簡報，重新開啟，並印出實際的填色：

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

因為長方形仍連結到 `Accent4`，主題變更後其可見顏色會變成紅色。如果您在圖形上以直接顏色取代色彩方案，之後對 `Accent4` 的變更將不再影響該填色。

### **使用額外調色盤的顏色**

PowerPoint 會對主題顏色套用顏色變換，產生較亮或較暗的變體。Aspose.Slides 透過[ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colortransformoperation/) 列舉公開這些變換。

![主要主題顏色與從額外調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要主題顏色。  
**2** - 從主要主題顏色產生的較亮與較暗變體。

以下範例建立六個以 `Accent4` 為基礎的長方形，對其中五個套用亮度變換，並保存結果：

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

這些變體仍以主題顏色為基礎。若之後 `Accent4` 變更，變換後的顏色會根據新的 `Accent4` 重新計算。

### **將 `SchemeColor` 值對映至 `ColorScheme` 欄位**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [ColorScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/colorscheme/) 以 `Dark1`、`Light1`、`Dark2`、`Light2` 透露相同的主題欄位。對映固定如下：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些只是相同主題欄位的別名，並非會在執行時相互轉換的值。

## **變更主題字型**

主題字型構成包含標題的主要字型集合與內文的次要字型集合。[FontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontscheme/) 與[FontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontscheme/) 方法可取得這兩套字型。

PowerPoint 相容的主題字型識別碼可在文字格式化時使用：

* `+mn-lt` - 內文字型 Latin（次要 Latin）
* `+mj-lt` - 標題字型 Latin（主要 Latin）
* `+mn-ea` - 內文字型 East Asian（次要 East Asian）
* `+mj-ea` - 標題字型 East Asian（主要 East Asian）

以下範例建立一個使用主要 Latin 主題字型的標題與一個使用次要 Latin 主題字型的內文，然後變更主題字型並保存結果：

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

標題會遵循主要字型，內文則遵循次要字型。若文字使用了明確的字型名稱而非主題識別碼，當主題字型構成變更時不會自動切換。

主要與次要字型集合也可以包含針對特定書寫系統（如西里爾、阿拉伯、日文、喬治亞文與 Thaana）的字型對映。若要檢查、加入、取代或移除這些對映，請參閱[Script-Specific Theme Fonts](/slides/zh-hant/nodejs-java/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲取得更多簡報字型資訊，請參考[PowerPoint Fonts](/slides/zh-hant/nodejs-java/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至母片相依的投影片**

當您有 PowerPoint 主題檔 (`.thmx`) 且想重新樣式化所有依賴特定母片的投影片時，使用[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/)。先從[Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 取得的[MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslidecollection/) 中選取母片，然後將主題檔路徑傳入該方法。

此方法執行以下步驟：

1. 依所選母片建立新母片。
1. 將外部主題套用至新母片。
1. 將先前依賴該母片的所有投影片指派給新母片。
1. 回傳新建立的[MasterSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/)。

以下範例將外部主題套用至依賴第一個母片的投影片，並保存簡報：

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

無效、損毀或不支援的主題可能拋出[PptxReadException](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pptxreadexception/)。請驗證使用者提供的路徑、處理檔案系統存取失敗，並於主題成功套用後才保存簡報。

僅會重新指派依賴所選母片的投影片。其他母片所屬的投影片會保留既有的母片與主題。支援主題的顏色、字型、填色、線條、背景與效果會以外部主題為基礎重新解析。直接指定的顏色、字型、填色與其他明確格式可能保持不變。版面層級與投影片層級的覆寫仍可能優先於新母片繼承的值。

主題可能參考執行環境中不存在的字型。為確保一致的渲染與匯出，請安裝必要字型、透過[custom font sources](/slides/zh-hant/nodejs-java/custom-font/) 提供，或設定[font substitution](/slides/zh-hant/nodejs-java/font-substitution/)。

此為直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，無需手動建立投影片或版面層級的主題覆寫。

### **在多母片簡報中套用不同的外部主題**

當無法事先得知相關母片時，可透過[Slide.getLayoutSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/) 與[LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/) 由代表性投影片取得母片。於套用任何主題前先儲存原始母片參考，因為每次呼叫都會在簡報中建立新的母片。

以下範例使用兩個區段的投影片來定位其母片，並分別套用不同的外部主題：

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

首次呼叫僅影響依賴 `firstGroupMaster` 的投影片，第二次呼叫僅影響依賴 `secondGroupMaster` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **搬移投影片時保留來源主題**

若要將投影片搬移至另一個簡報且保留其原始設計，先使用[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslidecollection/)將來源母片克隆至目標簡報，然後使用[SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/)將投影片與克隆的母片一起克隆。如此即可同時保留母片、其版面與關聯的主題。

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

此為在來源投影片必須在目標簡報中保持相同外觀的首選工作流程。僅將內容克隆至無關的目標母片可能會改變主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面，可從來源主題初始化投影片層級的覆寫。使用[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/)與[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/) 方法將三大主題元件複製至覆寫。

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

此作業會變更該投影片使用的主題，而不會影響其他投影片繼承的主題。若要移除本機覆寫並回復繼承值，請呼叫[OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/overridetheme/)。

### **將主題覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的所有投影片，除非個別投影片有自己的覆寫。相同的初始化方法可透過[LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslidethememanager/) 使用：

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

當許多版面與投影片應共享相同的基礎設計時，使用母片或簡報層級的主題；當單一版面族群需要不同樣式時，使用版面覆寫；僅在真正的例外情況下才使用投影片覆寫。過多的投影片層級覆寫會使之後的全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填色儲存在[FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/) 中。PowerPoint 在 UI 中可呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 可將主題填色與主題顏色及其他樣式參照組合。

![PowerPoint 簡報主題的背景樣式圖庫](presentation-design_8.png)

在使用背景樣式之前，請檢查已儲存的集合與目前的[Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/)。`0` 代表沒有主題填色；正值代表主題背景樣式的參照。這與直接以 JavaScript 索引集合不同，後者的 `0` 代表第一筆儲存項目。請勿假設每個簡報都有相同數量的背景填色樣式。

以下範例回報可用的背景填色數量，將第一個母片的背景設定為主題參照，並保存簡報：

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

最終呈現結果取決於母片參照的主題條目以及版面或投影片層級的任何背景覆寫。若投影片自行設定背景，僅變更母片背景可能不會影響該投影片。需要取得繼承後最終背景時，請使用[Background.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
請勿將樣式索引視為零基集合索引，也不要硬編碼某個檔案的樣式編號並假設在其他檔案中呈現相同外觀；主題樣式定義是依簡報而異的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有關直接背景格式化與背景繼承，請參閱[Presentation Background](/slides/zh-hant/nodejs-java/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式構成包含分別的填色、線條與效果樣式集合，可透過[FormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/formatscheme/) 取得。典型的 Office 主題通常包含三筆主要樣式，分別對應細緻、適中與強烈的視覺效果，但程式碼應檢查每個集合而非假設固定筆數。

![細緻、適中與強烈的主題效果套用於同一圖形](presentation-design_10.png)

在 JavaScript 中存取這些集合時，集合索引為零基：`0` 為第一筆儲存樣式，`2` 為第三筆。圖形的樣式參照索引是另一概念，透過[ShapeStyle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapestyle/) 暴露。修改主題樣式會影響參照該樣式的圖形；直接格式化的圖形可能保持不變。

以下範例檢查必要的樣式項目是否存在，變更第一筆線條樣式、第三筆填色樣式，並在第三筆效果樣式中啟用外部陰影，最後保存結果：

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

對於參照這些欄位的圖形，第一筆主題線條樣式會變紅，第三筆主題填色樣式會變為實心森林綠，第三筆效果樣式會加入距離 10 點的外部陰影。最終視覺結果仍取決於每個圖形引用的樣式欄位以及是否有直接格式覆寫。

![變更線條、填色與陰影設定後的主題效果樣式](presentation-design_11.png)

## **讀取實際主題值**

原始主題物件僅告訴您在特定層級上定義了什麼。實際值則告訴您投影片或圖形在繼承與本機覆寫解析後實際使用的內容。對投影片呼叫[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseoverridethememanager/)。對背景使用[Background.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/)，對填色使用[FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/)。

以下範例讀取投影片的實際主題、背景與第一個圖形的填色：

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

使用實際資料進行渲染診斷、驗證與比較。若只檢查[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getmastertheme/)，可能會遺漏母片、版面、投影片或圖形的覆寫，從而錯過最終外觀的變化。

## **常見問答**

**套用外部主題會影響簡報中的每一張投影片嗎？**

不會。[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/) 只會重新指派依賴所選母片的投影片。使用其他母片的投影片會保留既有主題。

**我可以在不變更母片的情況下，只對單一投影片套用主題嗎？**

可以。使用投影片的[SlideThemeManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更僅限於該投影片，其餘投影片仍繼承原有主題。

**將主題從一個簡報搬移到另一個簡報的最安全方式是什麼？**

搬移投影片且保留來源外觀時，請使用[MasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslidecollection/) 將來源母片克隆至目標簡報，然後以[SlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/) 克隆投影片並帶入該母片。這樣可同時保留母片、版面與主題。

**如何查看繼承與覆寫之後的實際值？**

對投影片或版面的主題使用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseoverridethememanager/)，對格式物件則使用[Background.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/background/) 與[FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fillformat/) 等對應的實際資料方法。這些 API 會在繼承與覆寫套用後回傳解析後的值。
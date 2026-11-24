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
- 設定佈景主題
- 變更佈景主題
- 管理佈景主題
- 外部佈景主題
- THMX
- 佈景顏色
- 附加調色盤
- 佈景字型
- 佈景樣式
- 佈景效果
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中掌握簡報佈景主題，以建立、客製化與轉換具有一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題定義了一組協調的顏色、字型、背景樣式、填色、線條與效果。具備佈景感知的物件會參照這些共用定義，而不是將每個視覺屬性儲存為固定值，因而一次變更佈景即可更新多個物件。

在 Aspose.Slides 中，可以透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/) 取得簡報層級的佈景。簡報也可以在較低層級包含佈景覆寫。母片可透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/) 覆寫簡報佈景，而版面配置或個別投影片則可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) 覆寫其繼承的佈景。實務上，投影片的有效佈景會依照此繼承鏈解析：簡報佈景 → 母片覆寫 → 版面配置覆寫 → 投影片覆寫。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下各節說明最常見的佈景工作流程：檢查佈景、變更顏色與字型、複製或套用佈景、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢查佈景**

[MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) 物件透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) 與 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) 暴露佈景的色彩配置、字型配置與格式配置。在變更之前先檢查這些集合特別有用，因為從外部來源取得的簡報，其樣式項目的數量與內容可能各有不同。

以下範例會讀取主要佈景屬性，並報告佈景中儲存了多少背景、填色、線條與效果樣式：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的有效佈景。檢查與投影片關聯的母片，並在版面配置或投影片可能有覆寫時，使用本文後續說明的有效佈景工作流程。

## **變更佈景顏色**

具佈景感知的填色、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當你變更 [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) 中對應的項目時，仍參照該佈景色彩的所有物件都會依新值解析。直接使用 RGB 顏色的物件不會因佈景顏色更新而改變。

以下完整範例會建立一個使用 `Accent4` 的圖形，將佈景的 `Accent4` 顏色改為紅色，儲存簡報、重新開啟後列印有效的填色：

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

因為矩形仍連結至 `Accent4`，佈景變更後其可見顏色會變為紅色。若你將圖形的配色從配色方案改為直接色彩，之後對 `Accent4` 的變更將不再影響該填色。

### **使用附加調色盤中的顏色**

PowerPoint 會從佈景色彩套用色彩變換，衍生出較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/) 列舉公開這些變換。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 主要佈景顏色。

**2** - 由主要佈景顏色產生的較亮與較暗變體。

以下範例建立六個以 `Accent4` 為基礎的矩形，對其中五個套用亮度變換，並儲存結果：

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

這些變體仍以佈景色彩為基礎。若稍後 `Accent4` 變更，變換後的顏色會根據新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `ColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) 將相同的佈景槽位以 `Dark1`、`Light1`、`Dark2`、`Light2` 呈現。對映關係固定：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些只是同一佈景槽位的別名，並非會動態相互轉換的值。

## **變更佈景字型**

佈景字型方案包含標題的主要字型集合與內文的次要字型集合。[FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) 與 [FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) 方法會曝露這些集合。

PowerPoint 相容的佈景字型識別碼可用於文字格式化：

* `+mn-lt` - 內文字型拉丁字母（次要拉丁字型）
* `+mj-lt` - 標題字型拉丁字母（主要拉丁字型）
* `+mn-ea` - 內文字型東亞（次要東亞字型）
* `+mj-ea` - 標題字型東亞（主要東亞字型）
* `+mn-cs` - 內文字型複合文字（次要複合文字字型）
* `+mj-cs` - 標題字型複合文字（主要複合文字字型）

以下範例建立一個使用主要拉丁佈景字型的標題，以及一個使用次要拉丁佈景字型的內文，然後變更佈景字型並儲存結果：

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

標題遵循主要字型，內文遵循次要字型。若文字使用明確的字型名稱而非佈景識別碼，則在佈景字型方案變更時不會自動切換。

主要與次要字型集合亦可包含針對個別書寫系統的字型對映，例如西里爾文、阿拉伯文、日文、喬治亞文與塔納文。若要檢查、加入、取代或移除這些對映，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/nodejs-java/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}

欲取得更多關於簡報字型的資訊，請參閱 [PowerPoint 字型](/slides/zh-hant/nodejs-java/powerpoint-fonts/)。

{{% /alert %}}

### **解析佈景字型參照**

檢查文字時，[FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) 可能會回傳類似 `+mn-lt` 的佈景參照，而非字型家族名稱。呼叫 [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) 並傳入適當的有效佈景即可解析該參照。`+mj` 與 `+mn` 前綴分別選擇主要與次要字型集合；`-lt`、`-ea`、`-cs` 後綴則分別選擇其拉丁、東亞與複合文字字型。

透過 [Slide.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) 取得針對檢查文字所屬物件的有效佈景。對於普通投影片上的文字，於投影片本身呼叫此方法，以確保上下文包含該投影片繼承的佈景與本地覆寫。檢查版面配置或母片本身時，使用它們各自的有效佈景。不要假設第一個母片的佈景會套用至所有投影片。

以下範例建立一段明確參照次要拉丁字型的文字，並透過 [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) 初始化投影片字型方案，將主要與次要拉丁字型家族設定為 `Arial` 與 `Calibri`，使範例在不需要輸入檔的情況下可重現。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Calibri"));

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    const font = portion.getPortionFormat().getLatinFont();
    const effectiveTheme = slide.createThemeEffective();
    console.log(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    const explicitFont = new aspose.slides.FontData("Verdana");
    console.log(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

輸出為 `+mn-lt -> Calibri`，接著是 `Verdana -> Verdana`。儲存的參照保持不變，而明確的字型名稱則原樣回傳。若使用 `+mj-lt`，則會在此佈景中解析為 `Arial`。

解析佈景參照會找出佈景所指定的字型家族。它不會檢查字型是否可用，也不會判斷在取代或字形回退期間最終使用的字型檔。相關步驟請參閱 [Font Selection Sequence](/slides/zh-hant/nodejs-java/font-selection-sequence/) 與 [Font Substitution](/slides/zh-hant/nodejs-java/font-substitution/)。

## **複製或套用佈景**

以下工作流程針對不同的佈景相關問題提供解決方案。

### **將外部佈景套用至依賴母片的投影片**

當你有 PowerPoint 佈景檔 (`.thmx`) 且想重新樣式化所有依賴特定母片的投影片時，請使用 [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/)。先從 [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 集合中選取母片（此集合由 [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) 表示），再將佈景檔路徑傳入方法。

該方法執行以下操作：

1. 以選取的母片為基礎建立新母片。
1. 將外部佈景套用至新母片。
1. 將先前依賴選取母片的所有投影片指派給新母片。
1. 回傳新建立的 [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/)。

以下範例將外部佈景套用至依賴第一個母片的投影片，並儲存簡報：

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

無效、損毀或不支援的佈景可能會拋出 [PptxReadException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxreadexception/)。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅於成功套用佈景後儲存簡報。

只有依賴選取母片的投影片會被重新指派。屬於其他母片的投影片會保留其既有母片與佈景。具佈景感知的顏色、字型、填色、線條、背景與效果會依外部佈景重新解析。直接指定的顏色、字型、填色與其他明確格式可能保持不變。版面配置層級與投影片層級的覆寫亦可能優先於新母片繼承的值。

佈景可能會參照執行環境中不存在的字型。為確保一致的渲染與匯出，請安裝必要的字型、透過 [custom font sources](/slides/zh-hant/nodejs-java/custom-font/) 提供字型，或設定 [font substitution](/slides/zh-hant/nodejs-java/font-substitution/)。

這是一個直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，且不需要手動建立投影片層級或版面配置層級的佈景覆寫。

### **在多母片簡報中套用不同的外部佈景**

當事先不知道相關的母片時，可透過 [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) 與 [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) 從代表性投影片取得母片。於套用任何佈景前先儲存原始母片參照，因為每次呼叫皆會在簡報中建立新母片。

以下範例使用兩個區段的投影片找出其母片，並對每個群組套用不同的外部佈景：

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

### **搬移投影片時保留來源佈景**

若需將投影片移至另一簡報且保留其原始設計，請使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) 將來源母片克隆至目標簡報，接著使用 [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) 並指定已克隆的母片，同時克隆投影片。這會將母片、其版面配置以及相關佈景一併帶入。

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

當來源投影片必須在目標簡報中保持相同外觀時，這是首選工作流程。僅將內容克隆至不相關的目標母片可能會改變受佈景控制的顏色、字型、背景與效果。

### **將佈景值套用至現有投影片**

若目標投影片必須保留其目前的母片與版面配置，可從來源佈景初始化投影片層級的覆寫。使用 [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) 方法將三個主要佈景元件複製到覆寫中。

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

此變更會套用於該投影片的佈景，而不會改變其他投影片繼承的佈景。若要移除本地覆寫並回復至繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)。

### **將佈景覆寫套用至版面配置**

版面配置層級的覆寫會套用至使用該版面配置的投影片，除非特定投影片有自己的覆寫。可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/) 使用相同的初始化方法：

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

當許多版面配置與投影片應共享相同基礎設計時，使用母片或簡報層級的佈景；若只有某個版面配置族群需要不同樣式，使用版面配置覆寫；僅在真正的例外情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域佈景變更更難預測。


<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*A layout override applies to slides using that layout unless a slide supplies its own override. Theme-based values follow their resolved scheme; explicitly formatted objects can retain their local appearance. Keep overrides as narrow as the intended design exception.*
<!-- visual-explanation:presentation-theme:end -->

## **更新佈景背景樣式**

佈景的背景填色儲存在 [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) 中。PowerPoint 的使用者介面可能會呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 可以將佈景填色與佈景顏色及其他樣式參照結合。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

在使用背景樣式前，請檢查已儲存的集合以及目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/)。`0` 的樣式索引表示沒有佈景填色；正值則為佈景背景樣式參照。這與直接以 JavaScript 索引集合不同，後者的 `0` 表示第一筆項目。請勿假設每個簡報都包含相同數量的背景填色樣式。

以下範例報告可用的背景填色數量，將佈景背景參照指派給第一個母片，並儲存簡報：

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

可見結果取決於母片所參照的佈景項目以及版面配置或投影片層級的任何背景覆寫。如果投影片使用自己的背景，僅變更母片背景可能不會影響該投影片。需要取得繼承後最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}

請勿將樣式索引視為零基集合索引。亦避免從單一檔案硬編碼樣式編號，並假設在另一檔案中會有相同外觀；佈景樣式定義為簡報專屬。

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

有關直接背景格式化與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/nodejs-java/presentation-background/)。

{{% /alert %}}

## **更新佈景效果**

佈景格式方案包含分別的填色、線條與效果樣式集合，分別透過 [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/) 暴露。一般的 Office 佈景通常包含三個主要樣式條目，視覺上分別對應細微、適中與強烈的格式化，但程式碼應檢查每個集合，而非假設固定數量。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

在 JavaScript 中存取這些集合時，集合索引為零基：索引 `0` 為第一筆儲存的樣式，索引 `2` 為第三筆。圖形的樣式參照索引是另一概念，透過 [ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/) 暴露。修改佈景樣式會影響參照該佈景樣式的圖形；直接格式化的圖形可能保持不變。

以下範例檢查必要的樣式條目是否存在，變更第一個線條樣式、變更第三個填色樣式，並在第三個效果樣式中啟用外側陰影，最後儲存結果：

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

對於參照這些槽位的圖形，第一個佈景線條樣式會變為紅色，第三個佈景填色樣式會變為實心森林綠，第三個效果樣式會獲得距離 10 點的外側陰影。最終視覺結果仍取決於每個圖形參照的樣式槽位以及直接格式化是否覆寫佈景。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **為圖形選取佈景填色與線條樣式**

圖形可透過 [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setfillstyleindex/) 與 [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setlinestyleindex/) 獨立選取填色與輪廓。對於任一方法，索引 `1` 代表對應佈景集合的第一筆項目 (`get_Item(0)`)，索引 `2` 代表第二筆項目 (`get_Item(1)`)。

以下範例在新簡報的預設佈景中設定兩個填色樣式（金色與天藍）與兩個線條樣式（深藍 6 pt 與深紅 12 pt），並在三個階段儲存投影片，以便在 PowerPoint 中比較結果：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const styles = presentation.getMasterTheme().getFormatScheme();

    const goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));
    const blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    blueFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 135, 206, 235));

    const thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thinLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
    thinLine.setWidth(6);
    const thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thickLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    thickLine.setWidth(12);

    const shapes = presentation.getSlides().get_Item(0).getShapes();
    const left = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 205, 200, 130);
    const right = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex(java.newShort(1));
    right.getShapeStyle().setFillStyleIndex(java.newShort(2));
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", aspose.slides.SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", aspose.slides.SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 46, 139, 87));
    presentation.save("03-theme-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 初始樣式 | 變更右側輪廓 | 編輯第一個佈景填色 |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

選取不同的線條樣式只會改變右側矩形的輪廓。編輯第一個佈景填色會更新所有使用該填色的圖形，此例中只有左側矩形變為綠色。

在現有圖形上，局部的填色、線條顏色或線寬可覆寫該佈景樣式的對應部分。若變更樣式索引後沒有可見效果，請檢查圖形的 [direct formatting](/slides/zh-hant/nodejs-java/shape-formatting/)。

## **判斷有效實心填色是否使用佈景顏色**

填色可以直接儲存在物件上，或繼承自段落、版面配置、母片、佈景樣式或其他格式層級。呼叫 [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) 可將該層級階層解析為不可變的有效填色快照。首先檢查其 `getFillType` 值；僅當其為 `FillType.Solid` 時才讀取實心填色屬性。

對於實心填色，`getSolidFillColor` 會回傳在繼承、佈景查找與色彩變換後的最終 RGB 值。`getSolidFillSchemeColor` 方法則回傳對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) 槽位，例如 `Text1` 或 `Accent6`。`SchemeColor.NotDefined` 表示有效實心填色並非基於配色方案。若工作流程中的填色僅為佈景色或直接 RGB 色彩，此值即代表直接 RGB 填色。

不要僅使用本地的 [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) 值來分類填色。例如，文字段落可能未在本地定義配色方案顏色，因而本地值為 `NotDefined`，但其有效填色可能繼承佈景顏色，最終解析為 `Text1` 或 `Accent6`。相反地，`getSolidFillSchemeColor` 告訴你是哪個邏輯佈景槽位產生了有效顏色，但不會告訴你該槽位來自物件、段落、版面配置、母片或其他層級。

以下範例載入簡報，稽核圖形填色與文字段落填色，列印每個最終 RGB 值與相關配色方案，並標記不會追蹤佈景顏色變更的實心填色：

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

`NotDefined` 分支會提供一份稽核清單，列出在佈景顏色槽位變更時不會回應的實心填色。請在簡報必須遵循新品牌調色盤時檢視這些物件。報告的 RGB 值仍顯示當前外觀，而配色方案值說明該外觀是否與佈景相連。

有效格式物件是快照。變更簡報佈景、佈景覆寫或任何繼承的格式後，請再次呼叫 `getEffective`，取得新的有效填色物件後再進行比較或報告。

## **讀取有效佈景值**

原始佈景物件告訴你在特定層級定義了什麼。有效值則告訴你投影片或圖形在繼承與本地覆寫解析後實際使用了什麼。對於投影片，呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/)，對於填色，使用 [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/)。

以下範例讀取投影片的有效佈景、背景與第一個圖形的填色：

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

使用有效資料進行渲染診斷、驗證與比較。如果僅檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/)，可能會錯過母片、版面配置、投影片或圖形的覆寫，從而改變最終外觀。

## **FAQ**

**套用外部佈景會影響簡報中的每張投影片嗎？**

不會。[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) 只會重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其既有佈景。

**我可以在不變更母片的情況下，將佈景套用到單一投影片嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) 並初始化其覆寫佈景。變更僅限於該投影片；其他投影片仍會繼承其既有佈景。

**將佈景從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片並保留來源外觀時，先將來源母片克隆至目標簡報，然後使用 [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) 與 [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) 連同該母片一起克隆投影片。這樣可同時保留母片、版面配置與佈景。

**如何在繼承與覆寫之後查看有效值？**

對於投影片或版面配置佈景，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/)；對於格式物件，如背景與填色，分別使用 [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/)。這些 API 會回傳在繼承與覆寫套用後解析出的值。
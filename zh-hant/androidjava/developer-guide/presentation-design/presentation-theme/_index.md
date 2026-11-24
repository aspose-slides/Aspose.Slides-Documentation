---
title: 管理 Android 上的簡報佈景主題
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
- Android
- Java
- Aspose.Slides
description: "透過 Java 在 Android 上的 Aspose.Slides 中管理主簡報佈景主題，以建立、客製化並轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題定義了一組協調的顏色、字型、背景樣式、填色、線條和效果。具有佈景感知的物件會參考這些共享定義，而不是將每個視覺屬性儲存為固定值，因此變更佈景時可以一次更新多個物件。

在 Aspose.Slides 中，可透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 取得投影片層級的佈景主題。投影片也可以在較低層級包含佈景覆寫。母片可透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/) 覆寫投影片的佈景，而版面配置或單一投影片則可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) 覆寫其繼承的佈景。實際上，投影片的有效佈景是透過以下繼承鏈解析的：投影片佈景、母片覆寫、版面配置覆寫及投影片覆寫。

![佈景組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下章節說明最常見的佈景工作流程：檢查佈景、變更顏色與字型、複製或套用佈景、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢查佈景**

[MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) 物件透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/)，[MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/)，以及 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) 透露佈景的色彩方案、字型方案與格式方案。在變更之前先檢查這些集合特別有用，因為來自外部來源的簡報其樣式條目的數量與內容可能會有所不同。

以下範例讀取主要佈景屬性，並回報佈景中儲存的背景、填色、線條與效果樣式數量：

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

如果檔案使用多個母片，請不要假設每張投影片都有相同的有效佈景。檢查與投影片關聯的母片，並在版面配置或投影片可能有覆寫時使用本文稍後說明的有效佈景工作流程。

## **變更佈景顏色**

具佈景感知的填色、線條與文字可以參考 [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您變更 [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) 中相對應的條目時，所有仍參考該佈景顏色的物件都會以新值解析。直接使用 RGB 顏色的物件不會受到佈景顏色更新的影響。

以下端對端範例建立一個使用 `Accent4` 的圖形，將佈景的 `Accent4` 顏色變更為紅色，儲存簡報，重新開啟，並印出有效的填色顏色：

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

因為矩形仍連結至 `Accent4`，佈景變更後其可見顏色會變成紅色。如果您將圖形的配色從方案色改為直接顏色，之後對 `Accent4` 的變更將不再影響該填色。

### **使用附加調色盤的顏色**

PowerPoint 會透過套用色彩變換來從佈景色衍生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/) 列舉公開這些變換。

![主要佈景顏色與從附加調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要佈景顏色。  
**2** - 從主要佈景顏色產生的較亮與較暗變體。

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

這些變體仍以佈景顏色為基礎。如果之後 `Accent4` 變更，變換後的顏色會以新 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `IColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 露出相同的佈景槽位。對映是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是同一佈景槽位的別名；它們不是會在兩種形式之間動態轉換的值。

## **變更佈景字型**

佈景字型方案包含標題的主要字型集合與內文的次要字型集合。[IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) 與 [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) 方法公開這兩套字型。

PowerPoint 相容的佈景字型識別碼可用於文字格式設定：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 內文字型 East Asian（次要東亞字型）
* `+mj-ea` - 標題字型 East Asian（主要東亞字型）
* `+mn-cs` - 內文字型 Complex Script（次要複合腳本字型）
* `+mj-cs` - 標題字型 Complex Script（主要複合腳本字型）

以下範例建立一個使用主要 Latin 佈景字型的標題，與一個使用次要 Latin 佈景字型的內文行，然後變更佈景字型並儲存結果：

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

標題遵循主要字型，內文遵循次要字型。若文字明確指定字型名稱而非佈景識別碼，則在佈景字型方案變更時不會自動切換。

主要與次要字型集合亦可包含針對個別書寫系統（如西里爾文、阿拉伯文、日文、格魯吉亞文與 Thaana）的字型對映。若要檢查、添加、取代或移除這些對映，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/androidjava/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲取得更多關於簡報字型的資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/androidjava/powerpoint-fonts/)。
{{% /alert %}}

### **解析佈景字型參照**

在檢查文字時，[IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) 可能會回傳像 `+mn-lt` 這樣的佈景參照，而非字型家族名稱。請以適當的 [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) 呼叫 [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) 以解析該參照。`+mj` 與 `+mn` 前綴選擇主要或次要字型集合；`-lt`、`-ea`、`-cs` 後綴分別選擇其 Latin、East Asian 與 Complex Script 字型。

在取得適用於被檢查文字之物件的有效佈景時，請於該物件呼叫 [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--)。對於投影片上的普通文字，於投影片本身呼叫此方法，以確保情境包含該投影片繼承的佈景與本機覆寫。若檢查的是版面或母片本身，則使用其自身的有效佈景。切勿假設第一個母片的佈景適用於所有投影片。

以下範例建立一段明確參照次要 Latin 字型的文字。它透過 [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) 初始化投影片字型方案，並將主要與次要 Latin 家族設為 `Arial` 與 `Calibri`，使結果在沒有輸入檔案的情況下亦可重現。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

輸出為 `+mn-lt -> Calibri`，接著是 `Verdana -> Verdana`。儲存的參照保持不變，而明確的家族名稱則原樣回傳。若使用 `+mj-lt`，則會在此佈景中解析為 `Arial`。

解析佈景參照會指出佈景所指定的字型家族。它不會檢查字型是否可用，也不會判斷最終在渲染期間使用的字型檔案。請參閱 [Font Selection Sequence](/slides/zh-hant/androidjava/font-selection-sequence/) 與 [Font Substitution](/slides/zh-hant/androidjava/font-substitution/) 以了解這些獨立步驟。

## **複製或套用佈景**

下列工作流程解決不同的佈景相關問題。

### **將外部佈景套用至母片所依賴的投影片**

當您有 PowerPoint 佈景檔（`.thmx`）且想重新樣式化所有依賴特定母片的投影片時，請使用 [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/)。從 [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 集合中選取母片（該集合實作 [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/)），並將佈景檔路徑傳入方法。

此方法執行以下操作：

1. 以選取的母片為基礎建立新母片。  
1. 將外部佈景套用至新母片。  
1. 將新母片指派給先前依賴選取母片的所有投影片。  
1. 回傳新建立的 [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/)。

以下範例將外部佈景套用至依賴第一個母片的投影片，並儲存簡報：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

無效、損毀或不支援的佈景可能會拋出 [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/)。請驗證使用者提供的路徑、處理檔案系統存取失敗，並於成功套用佈景後才儲存簡報。

僅重新指派依賴所選母片的投影片。與其他母片相關的投影片會保留其現有母片與佈景。具佈景感知的顏色、字型、填色、線條、背景與效果會依據外部佈景重新解析。直接指定的顏色、字型、填色與其他明確格式化可能保持不變。版面層級與投影片層級的覆寫也可能優先於從新母片繼承的值。

佈景可能參考執行環境中不存在的字型。為確保一致的渲染與匯出，請安裝所需字型、透過 [custom font sources](/slides/zh-hant/androidjava/custom-font/) 提供，或設定 [font substitution](/slides/zh-hant/androidjava/font-substitution/)。

這是直接的母片層級工作流程：該方法接受 `.thmx` 檔案路徑，且不需要手動建立投影片層級或版面層級的佈景覆寫。

### **在多母片簡報中套用不同的外部佈景**

當事先不知道相關母片時，可透過 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) 以及 [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/) 從代表性投影片取得母片。於套用任何佈景之前先儲存原始母片參考，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個區段的投影片定位其母片，並對每個群組套用不同的外部佈景：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

第一個呼叫僅影響依賴 `firstGroupMaster` 的投影片，第二個呼叫僅影響依賴 `secondGroupMaster` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **移動投影片時保留來源佈景**

若要將投影片移至另一個簡報且保留其原始設計，請使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) 將來源母片複製至目標簡報，然後使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) 及複製的母片將投影片複製。此作業會一併攜帶母片、其版面以及相關佈景。

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

當來源投影片必須在目的地呈現相同外觀時，這是首選工作流程。僅將內容複製到無關聯的目標母片可能會改變受佈景驅動的顏色、字型、背景與效果。

### **將佈景值套用至現有投影片**

若目標投影片必須保留其目前的母片與版面，請從來源佈景初始化投影片層級的覆寫。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/)、以及 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) 方法會將三個主要佈景組件複製到覆寫中。

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

此變更僅會影響該投影片使用的佈景，而不會更動其他投影片繼承的佈景。若要移除本機覆寫並回復繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/)。

### **將佈景覆寫套用至版面**

版面層級的覆寫會影響使用該版面的投影片，除非特定投影片有自己的覆寫。可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/) 使用相同的初始化方法：

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

當許多版面與投影片需要共享相同基礎設計時，請使用母片或投影片層級的佈景；當單一版面族群需要不同樣式時使用版面覆寫；僅在真正的例外情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域佈景變更更難預測。

<!-- visual-explanation:presentation-theme:start -->
[![母片佈景提供兩個版面；版面覆寫影響其投影片，除了一張具有更局部覆寫的投影片外。](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*版面覆寫會影響使用該版面的投影片，除非投影片自行提供覆寫。基於佈景的值會遵循其解析後的方案；明確格式化的物件可保留其本機外觀。請將覆寫範圍限制在設計例外所需的最小範圍。*
<!-- visual-explanation:presentation-theme:end -->

## **更新佈景背景樣式**

佈景的背景填色儲存在 [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) 中。PowerPoint 在 UI 中可以呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 能將佈景填色與佈景顏色及其他樣式參照結合起來。

![PowerPoint 針對簡報佈景的背景樣式圖庫](presentation-design_8.png)

在使用背景樣式之前，請檢查已儲存的集合以及目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/)。`0` 代表沒有佈景填色；正值則是佈景背景樣式參照。這與直接以 Java 索引集合不同，`get_Item(0)` 代表第一個儲存項目。請勿假設每個簡報都有相同數量的背景填色樣式。

以下範例回報可用的背景填色計數，將佈景背景參照指派給第一個母片，並儲存簡報：

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

最終顯示結果取決於母片參照的佈景條目以及版面或投影片層級的任何背景覆寫。如果投影片使用其自行的背景，只變更母片背景可能不會影響該投影片。需要取得繼承後的最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
請勿將樣式索引當作零基集合索引。也避免將某一檔案的樣式編號硬編碼，並假設在其他檔案中會有相同外觀；佈景樣式定義是針對簡報而定的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
欲取得直接的背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/androidjava/presentation-background/)。
{{% /alert %}}

## **更新佈景效果**

佈景格式方案包含分別的填色、線條與效果樣式集合，透過 [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/)、以及 [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) 公開。典型的 Office 佈景通常包含三個主要樣式條目，視覺上分別對應細緻、適中與強烈的格式化，但程式碼應檢查每個集合，而不是假設固定數量。

![細緻、適中與強烈的佈景效果套用於相同圖形](presentation-design_10.png)

在 Java 中存取這些集合時，集合索引是零基的：`get_Item(0)` 為第一個儲存樣式，`get_Item(2)` 為第三個。圖形的樣式參照索引是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/) 暴露。修改佈景樣式會影響參照該佈景樣式的圖形；直接格式化的圖形可能保持不變。

以下範例檢查必要的樣式條目是否存在，變更第一個線條樣式、變更第三個填色樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

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

對於參照這些槽位的圖形，第一個佈景線條樣式會變為紅色，第三個佈景填色樣式會變為實心森林綠，第三個效果樣式會新增距離為 10 點的外部陰影。最終的視覺結果仍取決於每個圖形參照的樣式槽位以及是否有直接格式化覆寫佈景。

![變更線條、填色與陰影設定後的佈景效果樣式](presentation-design_11.png)

## **為圖形選取佈景填色與線條樣式**

圖形可分別透過 [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) 與 [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-) 設定其填色與輪廓。對於任一方法，索引 `1` 代表對應佈景集合中的第一個條目 (`get_Item(0)`)，索引 `2` 代表第二個條目 (`get_Item(1)`)。

以下範例在新簡報的預設佈景中設定兩個填色樣式（金色與天空藍）以及兩個線條樣式（深藍 6 點與深紅 12 點），並在三個階段儲存投影片，以便在 PowerPoint 中比較結果。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 初始樣式 | 變更右側輪廓 | 編輯第一個佈景填色 |
|:---:|:---:|:---:|
| ![金色與天空藍矩形，配有相同的細深藍輪廓](theme-style-initial.png) | ![天空藍矩形現在有粗暗紅輪廓](theme-style-line-changed.png) | ![左側矩形變為綠色，兩個輪廓保持不變](theme-style-fill-changed.png) |

選取不同的線條樣式僅會變更右側矩形的輪廓。編輯第一個佈景填色會更新所有使用該填色的圖形，此例中僅左側矩形變為綠色。

在既有圖形上，局部的填色、線條顏色或線條寬度可覆寫該佈景樣式的該部分。如果變更樣式索引未產生可見效果，請檢查圖形的 [direct formatting](/slides/zh-hant/androidjava/shape-formatting/)。

## **判斷有效實色填色是否使用佈景顏色**

填色可以直接儲存在物件上，或從段落、版面、母片、佈景樣式或其他格式層級繼承。呼叫 [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) 可將該層級階層解析為不可變的 [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/)。首先檢查 [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/)。僅當其為 `FillType.Solid` 時才讀取實色填色屬性。

對於實色填色，[IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) 會回傳經過繼承、佈景查找與色彩變換後的最終 RGB 值。[IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) 會回傳對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) 槽位，如 `Text1` 或 `Accent6`。`SchemeColor.NotDefined` 表示有效實色填色並非基於方案顏色。在填色僅為佈景顏色或直接 RGB 顏色的工作流程中，此值即標示直接 RGB 填色。

不要僅使用本機 [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) 的值來分類填色。例如，文字段落可能沒有本機定義的方案顏色，其本機值為 `NotDefined`，但其有效填色可能繼承自佈景顏色並解析為 `Text1` 或 `Accent6`。相對地，`getSolidFillSchemeColor` 告訴您是哪個邏輯佈景槽位產生了有效顏色，但不會說明該槽位來自物件、段落、版面、母片或其他層級。

以下範例載入簡報，稽核圖形填色與文字段落填色，印出每個最終 RGB 值與相關的方案顏色，並標記不會追蹤佈景顏色變更的實色填色：

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`NotDefined` 分支提供了一份不會回應佈景顏色槽位變更之實色填色的稽核清單。當簡報必須遵循新品牌調色盤時，請檢查這些物件。回報的 RGB 值仍顯示目前外觀，而方案值則說明該外觀是否與佈景相連。

有效格式物件是快照。於變更簡報佈景、佈景覆寫或任何繼承格式後，請再次呼叫 `getEffective`，取得新的 `IFillFormatEffectiveData` 物件，再進行比較或報告顏色。

## **讀取有效佈景值**

原始佈景物件告訴您在特定層級所定義的內容。有效值告訴您投影片或圖形在繼承與本機覆寫解析後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/)，對於填色，使用 [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/)。

以下範例讀取投影片的有效佈景、背景以及第一個圖形的填色：

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

使用有效資料進行渲染診斷、驗證與比較。若僅檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)，可能會錯過會改變最終外觀的母片、版面、投影片或圖形覆寫。

## **常見問題集**

**套用外部佈景會影響簡報中的每張投影片嗎？**

不會。[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) 只會重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其既有佈景。

**可以在不變更母片的情況下只對單一投影片套用佈景嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) 並初始化其覆寫佈景。變更僅限於該投影片，其餘投影片仍會繼承現有佈景。

**將佈景從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片並保留來源外觀時，先將來源母片以 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) 複製至目的簡報，然後以 [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) 並使用該複製的母片將投影片複製。這會同時保留母片、版面與佈景。

**如何在繼承與覆寫後查看有效值？**

對於投影片或版面佈景，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/)。對於格式物件，使用對應的有效資料方法，如 [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/)。這些 API 會在繼承與覆寫應用後回傳解析後的值。
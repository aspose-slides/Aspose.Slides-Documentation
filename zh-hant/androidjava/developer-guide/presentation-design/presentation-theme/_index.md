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
- 額外調色盤
- 佈景字型
- 佈景樣式
- 佈景效果
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android（透過 Java）中掌握主要簡報佈景主題，以建立、客製化和轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題定義了一組協調的顏色、字型、背景樣式、填充、線條和效果。具備佈景主題感知的物件會參照這些共享定義，而不是將每個視覺屬性儲存為固定值，因而佈景主題變更能一次更新多個物件。

在 Aspose.Slides 中，簡報層級的佈景主題可透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 取得。簡報亦可在較低層級包含佈景主題的覆寫。母片可透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/masterthememanager/) 覆寫簡報佈景主題，而版面配置或單一投影片則可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseoverridethememanager/) 覆寫其繼承的佈景主題。實務上，投影片的有效佈景主題會依據此繼承鏈決定：簡報佈景主題、母片覆寫、版面覆寫與投影片覆寫。

![佈景主題組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下各節說明最常見的佈景主題工作流程：檢查佈景主題、變更顏色與字型、複製或套用佈景主題、更新背景與效果樣式，以及在繼承與覆寫完成後讀取有效值。

## **檢查佈景主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mastertheme/) 物件透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mastertheme/) 與 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mastertheme/) 讓使用者存取佈景主題的顏色配置、字型配置與版面配置。在變更之前先檢查這些集合尤其在簡報來自外部來源時很有用，因為樣式項目的數量與內容可能不同。

以下範例讀取主要佈景主題屬性，並回報佈景主題中儲存的背景、填充、線條與效果樣式的數量：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的有效佈景主題。必須檢查該投影片所屬的母片，並在版面或投影片可能有覆寫時使用本文稍後說明的有效佈景主題工作流程。

## **變更佈景主題顏色**

具備佈景主題感知的填充、線條與文字可參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在 [IColorScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icolorscheme/) 中變更對應項目時，所有仍參照該佈景主題顏色的物件都會根據新值重新解析。直接使用 RGB 顏色的物件不會受到佈景主題顏色更新的影響。

以下端對端範例建立一個使用 `Accent4` 的圖形，將佈景主題的 `Accent4` 顏色改為紅色，儲存簡報後重新開啟，並列印有效的填充顏色：

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

因為矩形仍連結至 `Accent4`，所以在佈景主題變更後其可見顏色會變為紅色。若您在圖形上以直接顏色取代方案顏色，之後對 `Accent4` 的變更將不再影響該填充。

### **使用額外調色盤的顏色**

PowerPoint 會透過套用顏色變換，從佈景主題顏色衍生出較亮或較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/colortransformoperation/) 列舉將這些變換公開。

![主要佈景主題顏色與從額外調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要佈景主題顏色。  
**2** - 從主要佈景主題顏色產生的較亮與較暗變體。

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

這些變體仍基於佈景主題顏色。如果之後 `Accent4` 變更，變換後的顏色會依新 `Accent4` 值重新計算。

### **將 `SchemeColor` 值映射至 `IColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icolorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 來表示相同的佈景主題插槽。對應關係固定：

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

這些只是相同佈景主題插槽的別名；不會在執行時相互轉換。

## **變更佈景主題字型**

佈景主題字型配置包含標題的主要字型集合與內文的次要字型集合。[IFontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontscheme/) 與 [IFontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontscheme/) 方法揭露這兩套字型。

PowerPoint 相容的佈景主題字型識別碼可用於文字格式設定：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）  
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）  
* `+mn-ea` - 內文字型 East Asian（次要東亞字型）  
* `+mj-ea` - 標題字型 East Asian（主要東亞字型）

以下範例建立一個使用主要 Latin 佈景字型的標題與一個使用次要 Latin 佈景字型的內文行，然後變更佈景主題字型並儲存結果：

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

標題遵循主要字型，內文遵循次要字型。若文字使用明確的字型名稱而非佈景識別碼，則在佈景字型配置變更時不會自動切換。

主要與次要字型集合亦可包含針對個別書寫系統（如西里爾文、阿拉伯文、日文、格魯吉亞文與Thaana）的字型對應。若要檢查、加入、取代或移除這些對應，請參閱 [Script‑Specific Theme Fonts](/slides/zh-hant/androidjava/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲取得更多有關簡報字型的資訊，請參考 [PowerPoint Fonts](/slides/zh-hant/androidjava/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用佈景主題**

以下工作流程解決不同的佈景主題相關問題。

### **將外部佈景主題套用至依賴特定母片的投影片**

當您手上有 PowerPoint 佈景主題檔（`.thmx`），且想重新樣式化所有依賴特定母片的投影片時，可使用 [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslide/)。先從 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 集合（實作自 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslidecollection/)）選取母片，然後將佈景檔路徑傳入該方法。

此方法執行下列步驟：

1. 以選取的母片建立新的母片投影片。  
1. 將外部佈景主題套用至新母片。  
1. 將先前依賴該母片的所有投影片指派至新母片。  
1. 回傳新建立的 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslide/)。

以下範例將外部佈景主題套用至依賴第一個母片的投影片，並儲存簡報：

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

無效、損毀或不支援的佈景主題可能拋出 [PptxReadException](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pptxreadexception/)。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在成功套用佈景主題後才儲存簡報。

僅會重新指派依賴所選母片的投影片。屬於其他母片的投影片保留其現有母片與佈景主題。具備佈景主題感知的顏色、字型、填充、線條、背景與效果會根據外部佈景主題重新解析。直接指派的顏色、字型、填充與其他明確格式可能保持不變。版面層級與投影片層級的覆寫仍可能優先於新母片繼承的值。

佈景主題可能參照執行環境中不存在的字型。為確保一致的渲染與匯出，請安裝必要字型、透過 [custom font sources](/slides/zh-hant/androidjava/custom-font/) 提供，或設定 [font substitution](/slides/zh-hant/androidjava/font-substitution/)。

這是一個直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，且不需要手動建立投影片層級或版面層級的佈景主題覆寫。

### **在多母片簡報中套用不同的外部佈景主題**

當事先不知道相關母片是哪一個時，可透過 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/) 取得代表投影片的版面，然後使用 [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutslide/) 取得母片。在套用任何佈景主題之前先保存原始母片參考，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個章節的投影片定位其母片，並對每個群組套用不同的外部佈景主題：

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

### **在移動投影片時保留來源佈景主題**

若要將投影片移至其他簡報且保留其原始設計，請使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslidecollection/) 將來源母片複製至目標簡報，然後以 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/) 搭配剛複製的母片將投影片複製過去。這樣會同時帶入母片、其版面與相關佈景主題。

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

在需要確保來源投影片在目的簡報中保持相同外觀時，建議使用此工作流程。僅將內容複製至不相關的目標母片可能會改變佈景主題驅動的顏色、字型、背景與效果。

### **將佈景主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面，可從來源佈景主題初始化投影片層級的覆寫。使用 [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/overridetheme/) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/overridetheme/) 方法將三大佈景主題組件複製到覆寫中。

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

此作法會變更該投影片使用的佈景主題，同時不影響其他投影片繼承的佈景主題。若要移除本機覆寫並回復至繼承值，呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/overridetheme/)。

### **將佈景主題覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的所有投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/layoutslidethememanager/) 使用：

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

當多個版面與投影片需要共享相同的基礎設計時，使用母片或簡報層級佈景主題；當單一版面族群需要不同樣式時，使用版面覆寫；而投影片覆寫則僅在真正的例外情況下使用。過度的投影片層級覆寫會使全域佈景主題變更的預測變得困難。

## **更新佈景主題背景樣式**

佈景主題的背景填充儲存在 [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iformatscheme/) 中。PowerPoint 在 UI 中可以呈現比此集合實際儲存的填充定義更多的背景選項，因為 UI 可以將佈景填充與佈景顏色及其他樣式參照結合。

![PowerPoint 針對簡報佈景主題的背景樣式庫](presentation-design_8.png)

在使用背景樣式前，請檢查儲存的集合以及目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/background/)。`0` 表示無佈景填充；正值則代表佈景背景樣式參照。這與直接以 Java 集合索引不同，`get_Item(0)` 代表第一筆儲存的項目。請勿假設每個簡報都有相同數量的背景填充樣式。

以下範例回報可用的背景填充數量，將佈景背景參照指派給第一個母片，並儲存簡報：

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

最終顯示的結果取決於母片參照的佈景條目以及版面或投影片層級的任何背景覆寫。如果投影片自己有背景，僅變更母片背景可能不會影響該投影片。當需要取得繼承後的最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
請勿將樣式索引當作零基集合索引使用。也不要硬編碼從一個檔案取得的樣式編號，並假設在另一個檔案中會有相同外觀；佈景樣式定義是依簡報而異的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有關直接背景格式設定與背景繼承，請參考 [Presentation Background](/slides/zh-hant/androidjava/presentation-background/)。
{{% /alert %}}

## **更新佈景主題效果**

佈景格式方案包含分別的填充、線條與效果樣式集合，可透過 [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iformatscheme/) 取得。一般 Office 佈景常包含三筆主要樣式，視覺上對應細緻、適中與強烈的格式，但程式碼應檢查每個集合，而非假設固定數量。

![細緻、適中與強烈的佈景效果套用於同一圖形](presentation-design_10.png)

在 Java 中存取這些集合時，集合索引為零基：`get_Item(0)` 為第一筆儲存的樣式，`get_Item(2)` 為第三筆。圖形的樣式參照索引是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapestyle/) 取得。修改佈景樣式會影響參照該樣式的圖形；直接格式設定的圖形則可能保持不變。

以下範例檢查必要的樣式項目是否存在，變更第一筆線條樣式，變更第三筆填充樣式，於第三筆效果樣式啟用外部陰影，並儲存結果：

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

對於參照這些插槽的圖形而言，第一筆佈景線條樣式會變成紅色，第三筆佈景填充樣式會變為實心森林綠，第三筆效果樣式會獲得距離 10 點的外部陰影。最終視覺結果仍取決於每個圖形實際參照的樣式插槽以及是否有直接格式覆寫。

![變更線條、填充與陰影設定後的佈景效果樣式](presentation-design_11.png)

## **判斷有效實心填充是否使用佈景主題顏色**

填充可以直接儲存在物件上，或從段落、版面、母片、佈景樣式或其他格式層級繼承。呼叫 [IFillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifillformat/) 可將此層級階層解析為不可變的 [IFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifillformateffectivedata/)。先檢查 [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifillformateffectivedata/)。只有在返回 `FillType.Solid` 時，才應讀取實心填充屬性。

對於實心填充，[IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifillformateffectivedata/) 會回傳經過繼承、佈景查找與顏色變換後的最終 RGB 值。[IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifillformateffectivedata/) 會回傳對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/schemecolor/) 插槽，例如 `Text1` 或 `Accent6`。若回傳 `SchemeColor.NotDefined`，表示有效實心填充並非基於方案顏色；在只使用佈景顏色或直接 RGB 顏色的工作流程中，此值即表示直接 RGB 填充。

不要僅依賴本地的 [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icolorformat/) 來分類填充。例如，文字片段可能本地沒有設定方案顏色，因而本地值為 `NotDefined`，但其有效填充可能繼承自佈景主題顏色，最終解析為 `Text1` 或 `Accent6`。相對地，`getSolidFillSchemeColor` 告訴您產生最終顏色的邏輯佈景插槽，但不指明該插槽來源於哪一層級（物件、段落、版面、母片或其他）。

以下範例載入簡報，稽核圖形填充與文字片段填充，列印每個最終 RGB 值與對應的方案顏色，並標記不會追蹤佈景顏色變更的實心填充：

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

`NotDefined` 分支提供了不會響應佈景顏色槽變更的實心填充稽核清單。當簡報必須遵循新的品牌調色盤時，請檢查這些物件。回報的 RGB 值仍顯示目前的外觀，而方案值則說明該外觀是否與佈景主題相連。

有效格式物件是快照。變更簡報佈景主題、佈景覆寫或任何繼承格式後，請再次呼叫 `getEffective`，取得新的 `IFillFormatEffectiveData` 物件再進行比較或報告。

## **讀取有效佈景主題值**

原始佈景主題物件僅告訴您在特定層級定義了什麼。有效值則告訴您投影片或圖形在繼承與本地覆寫解析後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseoverridethememanager/)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/background/)，對於填充則使用 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/)。

以下範例從投影片讀取有效佈景主題、背景與第一個圖形的填充：

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

使用有效資料進行渲染診斷、驗證與比較。若僅檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)，可能會遺漏母片、版面、投影片或圖形的覆寫，導致最終外觀不同。

## **常見問與答**

**套用外部佈景主題是否會影響簡報中的每一張投影片？**

不會。[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslide/) 僅重新指派依賴選取母片的投影片。使用其他母片的投影片會保留其現有佈景主題。

**我可以在不變更母片的情況下，只對單一投影片套用佈景主題嗎？**

可以。使用該投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidethememanager/) 並初始化其覆寫佈景主題。變更僅限於該投影片；其他投影片仍會繼承其既有佈景主題。

**將佈景主題從一個簡報搬移至另一個簡報的最安全方式是什麼？**

在搬移投影片且需保留來源外觀時，請將來源母片以 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imasterslidecollection/) 複製至目標簡報，然後再以 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/) 搭配該母片複製投影片。這樣可同時保留母片、版面與佈景主題。

**如何在繼承與覆寫後查看有效值？**

對於投影片或版面佈景主題，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseoverridethememanager/)。對於格式物件，例如背景與填充，分別使用對應的有效資料方法 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fillformat/)。這些 API 會回傳繼承與覆寫完成後的解析值。
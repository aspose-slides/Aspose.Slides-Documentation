---
title: 管理 Java 簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/java/presentation-theme/
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
- 附加調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中管理主簡報主題，以建立、客製化並轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字型、背景樣式、填滿、線條與效果。具備主題感知的物件會參照這些共享定義，而不是將每個視覺屬性儲存為固定值，因而在變更主題時可以一次更新許多物件。

在 Aspose.Slides 中，可透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 取得簡報層級的主題。簡報也可能在較低層級包含主題覆寫。母片可以透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/masterthememanager/) 覆寫簡報主題，而版面或單一投影片則可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) 覆寫其繼承的主題。實務上，投影片的有效主題是透過這條繼承鏈解析得到的：簡報主題 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![主題組件：顏色、字型、背景樣式和效果](theme-constituents.png)

以下各節說明最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) 物件透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) 與 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) 透露主題的顏色方案、字型方案與格式方案。在變更前先檢查這些集合尤其在簡報來源於外部檔案時很有用，因為樣式項目的數量與內容可能各不相同。

以下範例讀取主要主題屬性，並回報在主題中儲存了多少背景、填滿、線條與效果樣式：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的有效主題。檢查與投影片關聯的母片，並在版面或投影片可能有覆寫時使用本文稍後說明的有效主題工作流程。

## **變更主題顏色**

具備主題感知的填滿、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在 [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) 中變更相對應的條目時，所有仍參照該主題顏色的物件都會根據新值重新解析。直接使用 RGB 顏色的物件不會受到主題顏色更新的影響。

以下端對端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色改為紅色，儲存簡報，重新開啟，並列印有效的填滿顏色：

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

因為矩形仍連結到 `Accent4`，當主題變更後其可見顏色會變為紅色。若您將圖形的配色從方案顏色改為直接顏色，之後對 `Accent4` 的變更將不會再影響該填滿。

### **使用附加調色盤的顏色**

PowerPoint 會透過套用顏色變換，從主題顏色衍生出較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/java/com.aspose.slides/colortransformoperation/) 列舉公開這些變換。

![主題主要顏色與由附加調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主題主要顏色。  
**2** - 由主題主要顏色產生的較亮與較暗變體。

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

這些變體仍以主題顏色為基礎。如果之後 `Accent4` 變更，轉換後的顏色會以新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `IColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2` 與 `Background2`，而 [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) 以 `Dark1`、`Light1`、`Dark2`、`Light2` 露出相同的主題插槽。對映關係固定：

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

這些是同一主題插槽的別名，並非會動態相互轉換的值。

## **變更主題字型**

主題字型方案包含標題的主要字型集合與內文的次要字型集合。[IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) 與 [IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) 方法會公開這兩套字型。

PowerPoint 相容的主題字型辨識碼可於文字格式化時使用：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）  
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）  
* `+mn-ea` - 內文字型 East Asian（次要東亞字型）  
* `+mj-ea` - 標題字型 East Asian（主要東亞字型）  
* `+mn-cs` - 內文字型 Complex Script（次要複雜文字字型）  
* `+mj-cs` - 標題字型 Complex Script（主要複雜文字字型）

以下範例建立一個使用主要 Latin 主題字型的標題，與一個使用次要 Latin 主題字型的內文行，然後變更主題字型並儲存結果：

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

標題遵循主要字型，內文則遵循次要字型。若文字使用了明確的字型名稱而非主題辨識碼，則在主題字型方案變更時不會自動切換。

主要與次要字型集合亦可包含針對個別書寫系統的字型對映，例如西里爾、阿拉伯、日文、喬治亞與塔那。若要檢查、加入、取代或移除這些對映，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/java/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
欲取得更多關於簡報字型的資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/java/powerpoint-fonts/)。
{{% /alert %}}

### **解析主題字型參照**

在檢查文字時，[IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName--) 可能回傳類似 `+mn-lt` 的主題參照，而非字型家族名稱。請以適當的 [IThemeEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeeffectivedata/) 呼叫 [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) 以解析該參照。`+mj` 與 `+mn` 前綴選擇主要或次要字型集合；`-lt`、`-ea`、`-cs` 後綴分別選擇其 Latin、East Asian 與 Complex Script 字型。

透過在適用於欲檢查文字之物件上呼叫 [IThemeable.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeable/#createThemeEffective--) 取得有效主題。對於投影片上的普通文字，應在投影片本身呼叫此方法，讓上下文包含該投影片的繼承主題與本地覆寫。檢查版面或母片本身時，請使用其自身的有效主題。不要假設第一個母片的主題套用於所有投影片。

以下範例建立一段明確參照次要 Latin 字型的文字片段。它先透過 [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) 初始化投影片字型方案，並將主要與次要 Latin 家族設定為 `Arial` 與 `Calibri`，使結果在沒有輸入檔案的情況下可重現。

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

輸出為 `+mn-lt -> Calibri`，接著是 `Verdana -> Verdana`。儲存的參照保持不變，明確的家族名稱則直接回傳。若該片段使用 `+mj-lt`，則會在此主題中解析為 `Arial`。

解析主題參照會找出主題指定的字型家族。它不會檢查字型可用性，也不會決定在取代或字形回退後最終使用的字型檔案。相關步驟請參閱 [Font Selection Sequence](/slides/zh-hant/java/font-selection-sequence/) 與 [Font Substitution](/slides/zh-hant/java/font-substitution/)。

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至依賴於母片的投影片**

當您有 PowerPoint 主題檔 (`.thmx`) 且想重新樣式化所有依賴特定母片的投影片時，請使用 [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/)。先從 [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 取得母片集合（實作自 [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/)），然後將主題檔路徑傳入方法。

此方法執行以下動作：

1. 以選取的母片為基礎建立新母片。  
1. 將外部主題套用至新母片。  
1. 將新母片指派給先前依賴於選取母片的所有投影片。  
1. 回傳新建立的 [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/)。

以下範例將外部主題套用至依賴第一個母片的投影片，並儲存簡報：

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

無效、損毀或不支援的主題可能會拋出 [PptxReadException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxreadexception/)。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在主題成功套用後才儲存簡報。

僅會重新指派依賴於選取母片的投影片。屬於其他母片的投影片會保留其既有母片與主題。具備主題感知的顏色、字型、填滿、線條、背景與效果會根據外部主題重新解析。直接指派的顏色、字型、填滿與其他顯式格式化可能不會改變。版面層級與投影片層級的覆寫也可能優先於新母片繼承的值。

主題可能參照執行環境中不存在的字型。為確保一致的渲染與匯出，請安裝必要字型、透過 [custom font sources](/slides/zh-hant/java/custom-font/) 提供，或設定 [font substitution](/slides/zh-hant/java/font-substitution/)。

此為直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，無需手動建立投影片層級或版面層級的主題覆寫。

### **在多母片簡報中套用不同的外部主題**

當事先無法確定相關母片時，請透過 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) 以及 [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/) 從具代表性的投影片取得母片。於套用任何主題之前先儲存原始母片參照，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個章節的投影片來定位其母片，並分別對每個群組套用不同的外部主題：

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

第一次呼叫僅影響依賴 `firstGroupMaster` 的投影片，第二次呼叫僅影響依賴 `secondGroupMaster` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **搬移投影片時保留來源主題**

若要將投影片搬移至另一個簡報且保留其原始設計，請使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) 將來源母片複製至目標簡報，接著以 [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) 以及複製的母片來複製投影片。這會同時攜帶母片、其版面與相關主題。

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

這是在來源投影片必須在目的地保持相同外觀時的首選工作流程。若僅將內容複製到不相關的目的地母片，主題驅動的顏色、字型、背景與效果可能會被改變。

### **將主題值套用至現有投影片**

若目標投影片必須保留其目前的母片與版面，請從來源主題初始化投影片層級的覆寫。使用 [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) 方法，將三個主要主題元件複製到覆寫中。

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

此變更會影響該投影片使用的主題，但不會改變其他投影片繼承的主題。若要移除本地覆寫並回復至繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/)。

### **將主題覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslidethememanager/) 使用：

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

在需要多個版面與投影片共享相同基礎設計時，使用母片或簡報層級的主題；在單一版面族需要不同樣式時使用版面覆寫；僅在真正的例外情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域主題變更難以預測。

<!-- visual-explanation:presentation-theme:start -->
[![母片主題供應兩個版面；版面覆寫影響其投影片，除非投影片有更局部的覆寫。](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*版面覆寫會套用至使用該版面的投影片，除非投影片自行提供覆寫。基於主題的值會遵循解析後的方案；明確格式化的物件則可保留其本地外觀。請將覆寫限制在預期的設計例外範圍內。*
<!-- visual-explanation:presentation-theme:end -->

## **更新主題背景樣式**

主題的背景填滿儲存在 [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) 中。PowerPoint 在 UI 中可以呈現比此集合實際儲存的填充定義更多的背景選項，因為 UI 能將主題填充與主題顏色及其他樣式參照結合。

![PowerPoint 針對簡報主題的背景樣式庫](presentation-design_8.png)

在使用背景樣式之前，請檢查儲存的集合與目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/background/)。`0` 代表沒有套用主題填充；正值代表主題背景樣式參照。這與直接以 Java 集合索引不同，`get_Item(0)` 代表第一筆儲存項目。不要假設每個簡報都有相同數量的背景填充樣式。

以下範例回報可用的背景填充計數，將主題背景參照指派給第一個母片，並儲存簡報：

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

最終可見結果取決於母片參照的主題條目以及版面或投影片層級的任何背景覆寫。如果投影片使用自己的背景，僅變更母片背景可能不會影響該投影片。需要取得繼承後最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
不要將樣式索引視為零基索引。也避免硬編碼某個檔案的樣式編號，並假設在其他檔案中會有相同外觀；主題樣式定義是簡報專屬的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
欲取得直接的背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/java/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含獨立的填充、線條與效果樣式集合，分別透過 [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) 曝露。典型的 Office 主題常包含三個主要樣式條目，視覺上分別對應微妙、適中與強烈的格式，但程式碼應自行檢查每個集合，而非假設固定數量。

![對同一圖形套用微妙、適中與強烈的主題效果](presentation-design_10.png)

在 Java 中存取這些集合時，集合索引為零基：`get_Item(0)` 為第一筆儲存的樣式，`get_Item(2)` 為第三筆。圖形的樣式參照索引是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/) 曝露。修改主題樣式會影響參照該主題樣式的圖形；直接格式化的圖形可能保持不變。

以下範例檢查所需的樣式條目是否存在，變更第一個線條樣式、變更第三個填充樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

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

對於參照這些插槽的圖形，第一個主題線條樣式會變為紅色，第三個主題填充樣式會變為實心森林綠，第三個效果樣式會新增距離 10 點的外部陰影。最終視覺結果仍取決於每個圖形參照的樣式插槽以及是否有直接格式覆寫主題。

![變更線條、填充與陰影設定後的主題效果樣式](presentation-design_11.png)

## **為圖形選取主題填充與線條樣式**

圖形可透過 [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) 與 [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-) 分別獨立選取填充與輪廓。對於這兩個方法，索引 `1` 代表對應主題集合的第一筆 (`get_Item(0)`)；索引 `2` 代表第二筆 (`get_Item(1)`)。

以下範例在新簡報的預設主題中設定兩個填充樣式（金色與天藍）以及兩個線條樣式（深藍 6 pt 與深紅 12 pt），並在三個階段儲存投影片，以便在 PowerPoint 中比較結果。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(new Color(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(new Color(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
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

    goldFill.getSolidFillColor().setColor(new Color(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 初始樣式 | 變更右側輪廓 | 編輯第一個主題填充 |
|:---:|:---:|:---:|
| ![金色與天藍矩形，搭配相同的細深藍輪廓](theme-style-initial.png) | ![天藍矩形現在具有粗深紅輪廓](theme-style-line-changed.png) | ![左側矩形變為綠色，兩個輪廓保持不變](theme-style-fill-changed.png) |

選取不同的線條樣式只會改變右側矩形的輪廓。編輯第一個主題填充會更新所有使用該填充的圖形。在此例中，只有左側矩形變為綠色。

在已存在的圖形上，局部的填充顏色、線條顏色或線寬可以覆寫該主題樣式的相應部分。若變更樣式索引後沒有顯著效果，請檢查圖形的 [direct formatting](/slides/zh-hant/java/shape-formatting/)。

## **判斷有效實心填充是否使用主題顏色**

填充可以直接儲存在物件上，或從段落、版面、母片、主題樣式或其他格式層級繼承。呼叫 [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/) 可將此層級階層解析為不可變的 [IFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/)。首先檢查 [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/)；僅當回傳 `FillType.Solid` 時才讀取實心填充屬性。

對於實心填充，[IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) 會回傳在繼承、主題查找與顏色變換後的最終渲染 RGB 值。[IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) 會回傳相對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) 插槽，例如 `Text1` 或 `Accent6`。若回傳 `SchemeColor.NotDefined`，表示有效實心填充並非基於方案顏色。在僅有主題顏色或直接 RGB 顏色的工作流程中，這個值即可辨識為直接 RGB 填充。

請勿僅依賴本地的 [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) 來分類填充。例如，文字片段本地可能沒有定義方案顏色，其本地值為 `NotDefined`，但其有效填充繼承自主題顏色，最終解析為 `Text1` 或 `Accent6`。相對地，`getSolidFillSchemeColor` 告訴您哪個邏輯主題插槽產生了有效顏色，但不會說明該插槽來自於物件、段落、版面、母片或其他層級。

以下範例載入簡報，稽核圖形填充與文字片段填充，列印每個最終 RGB 值與相關方案顏色，並標示不會追蹤主題顏色變更的實心填充：

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
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

`NotDefined` 分支會提供一個稽核清單，列出在更換品牌調色盤時不會因主題顏色插槽變更而更新的實心填充。檢視這些物件以確保簡報符合新品牌需求。回報的 RGB 值仍顯示目前外觀，而方案值則說明該外觀是否與主題相連。

有效格式物件是快照。變更簡報主題、主題覆寫或任何繼承的格式後，請再次呼叫 `getEffective`，取得新的 `IFillFormatEffectiveData` 物件，然後再進行比較或報告。

## **讀取有效主題值**

原始主題物件告訴您在特定層級定義了什麼。有效值則告訴您投影片或圖形在繼承與本地覆寫解析後實際使用了什麼。對於投影片，呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/)，對於填充則使用 [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/)。

以下範例讀取投影片的有效主題、背景與第一個圖形的填充：

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

使用有效資料進行渲染診斷、驗證與比較。如果僅檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)，可能會遺漏母片、版面、投影片或圖形的覆寫，從而錯過最終外觀的變化。

## **常見問答**

**套用外部主題會影響簡報中的每一張投影片嗎？**

不會。[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) 僅重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其既有主題。

**我可以在不變更母片的情況下，只對單一投影片套用主題嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更僅於該投影片本地生效，其他投影片仍繼承其既有主題。

**將主題從一個簡報搬移到另一個簡報的最安全方法是什麼？**

在搬移投影片且需保留來源外觀時，請將來源母片以 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) 複製至目的地，然後以 [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) 搭配該母片複製投影片。此作法會同時保留母片、版面與主題。

**如何查看繼承與覆寫之後的有效值？**

對於投影片或版面主題，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/)。對於格式物件，則使用相對應的有效資料方法，如 [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/)。這些 API 會在繼承與覆寫套用後回傳解析完的值。
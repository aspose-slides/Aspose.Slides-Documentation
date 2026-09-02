---
title: 管理 Java 中的簡報主題
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
- 主題色彩
- 額外調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中掌握簡報主題，以建立、客製化與轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一套協調的顏色、字型、背景樣式、填充、線條與效果。具備主題感知的物件會參考這些共享定義，而不是將每個視覺屬性儲存為固定值，因而一次變更主題即可同時更新許多物件。

在 Aspose.Slides 中，可透過 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 取得簡報層級的主題。簡報亦可以在較低層級包含主題覆寫。母片可透過 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/masterthememanager/) 覆寫簡報主題，而版面或單一投影片則可透過 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseoverridethememanager/) 覆寫其繼承的主題。實務上，投影片的實際主題會透過以下繼承鏈解析：簡報主題 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![主題元件：顏色、字型、背景樣式與效果](theme-constituents.png)

下列章節說明最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，並在繼承與覆寫解析後讀取實際值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mastertheme/) 物件透過 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mastertheme/) 與 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mastertheme/) 透露主題的顏色配置、字型配置與格式配置。在變更之前先檢查這些集合特別有用，因為從外部來源取得的簡報其樣式項目的數量與內容可能不同。

以下範例讀取主要主題屬性，並回報在主題中儲存了多少背景、填充、線條與效果樣式：

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

如果檔案使用多個母片，切勿假設每張投影片都有相同的實際主題。請檢查與投影片關聯的母片，並在版面或投影片可能有覆寫時，使用本文後續說明的實際主題工作流程。

## **變更主題顏色**

具備主題感知的填充、線條與文字可以參考 [SchemeColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在 [IColorScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icolorscheme/) 中變更相對應的項目時，所有仍參考該主題顏色的物件都會解析為新值。直接使用 RGB 顏色的物件不會受到主題顏色更新的影響。

以下端到端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色改為紅色，儲存簡報後重新開啟，並印出實際的填充顏色：

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

因為矩形仍與 `Accent4` 連結，主題變更後其可見顏色會變成紅色。如果您將圖形的配色從方案顏色改為直接顏色，之後對 `Accent4` 的變更將不再影響該填充。

### **使用「額外調色盤」中的顏色**

PowerPoint 會從主題顏色套用顏色變換以產生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/colortransformoperation/) 列舉公開這些變換。

![主要主題顏色與由額外調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要主題顏色。  
**2** - 由主要主題顏色產生的較亮與較暗變體。

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

這些變體仍然基於主題顏色。如果之後 `Accent4` 變更，變換後的顏色會重新以新的 `Accent4` 值計算。

### **將 `SchemeColor` 值對映到 `IColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icolorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 曝露相同的主題插槽。對映固定如下：

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

這些只是相同主題插槽的別名，並非會在執行時相互轉換的值。

## **變更主題字型**

主題字型配置包含標題的主要字型集合與正文的次要字型集合。可透過 [IFontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontscheme/) 與 [IFontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontscheme/) 方法取得這兩個集合。

PowerPoint 相容的主題字型識別碼可在文字格式化時使用：

* `+mn-lt` – 正文字型 Latin（次要 Latin 字型）  
* `+mj-lt` – 標題字型 Latin（主要 Latin 字型）  
* `+mn-ea` – 正文字型 East Asian（次要東亞字型）  
* `+mj-ea` – 標題字型 East Asian（主要東亞字型）

以下範例建立一個使用主要 Latin 主題字型的標題，以及一個使用次要 Latin 主題字型的正文行，接著變更主題字型並儲存結果：

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

標題遵循主要字型，正文則遵循次要字型。若文字明確指定了字型名稱而非主題識別碼，則在主題字型配置變更時不會自動切換。

主要與次要字型集合還可以包含針對特定書寫系統（如西里爾文、阿拉伯文、日文、喬治亞文與塔安那文）的字型對映。若要檢查、加入、取代或移除這些對映，請參閱 [腳本特定主題字型](/slides/zh-hant/java/script-specific-font-mappings/)。

{{% alert color="info" title="提示" %}}
欲取得更多關於簡報字型的資訊，請參閱 [PowerPoint 字型](/slides/zh-hant/java/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至依賴特定母片的投影片**

當您手上有 PowerPoint 主題檔 (`.thmx`) 且想要重新樣式化所有依賴特定母片的投影片時，請使用 [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/) 。先從 [Presentation.getMasters](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 取得母片集合（實作 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslidecollection/)），再將主題檔路徑傳入該方法。

此方法執行以下步驟：

1. 以所選母片為基礎建立新的母片。  
1. 將外部主題套用至新母片。  
1. 將先前依賴該母片的所有投影片指派給新母片。  
1. 回傳新建的 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/)。

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

無效、損毀或不支援的主題可能拋出 [PptxReadException](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pptxreadexception/)。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在主題成功套用後才儲存簡報。

只有依賴所選母片的投影片會被重新指派。屬於其他母片的投影片保留其既有母片與主題。具備主題感知的顏色、字型、填充、線條、背景與效果會依外部主題重新解析。直接指派的顏色、字型、填充與其他明確格式化可能保持不變。版面層級與投影片層級的覆寫仍可能優先於從新母片繼承的值。

主題可能會參考執行環境中不存在的字型。為確保一致的呈現與匯出，請安裝所需字型、透過 [自訂字型來源](/slides/zh-hant/java/custom-font/) 提供，或設定 [字型替代](/slides/zh-hant/java/font-substitution/)。

此為直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，且不需要手動建立投影片層級或版面層級的主題覆寫。

### **在多母片簡報中套用不同外部主題**

當無法事先得知相關母片時，可透過 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/) 取得代表投影片的版面，進而使用 [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilayoutslide/) 取得母片。於套用任何主題之前，先儲存原始母片參考，因為每次呼叫皆會在簡報中建立另一個母片。

以下範例使用兩個章節的投影片定位其母片，並對每個群組套用不同的外部主題：

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

第一次呼叫只影響依賴 `firstGroupMaster` 的投影片，第二次呼叫只影響依賴 `secondGroupMaster` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **在搬移投影片時保留來源主題**

若要將投影片移至另一個簡報且保留原始設計，請使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslidecollection/) 將來源母片複製至目標簡報，然後使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/) 搭配已複製的母片複製投影片。這樣可同時攜帶母片、其版面以及相關主題。

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

此為在來源投影片必須在目的端保持相同外觀時的首選工作流程。僅將內容克隆至不相關的目的母片可能會改變受主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面，可從來源主題初始化投影片層級的覆寫。使用 [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/overridetheme/) 與 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/overridetheme/) 方法將三個主要主題組件複製至覆寫中。

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

此作法會僅變更該投影片使用的主題，而不影響其他投影片繼承的主題。若要移除本機覆寫並回復繼承值，請呼叫 [OverrideTheme.clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/overridetheme/)。

### **將主題覆寫套用至版面**

版面層級的覆寫會影響所有使用該版面的投影片，除非個別投影片另有自己的覆寫。相同的初始化方法可透過 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/layoutslidethememanager/) 使用：

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

當許多版面與投影片需要共用相同基礎設計時，請使用母片或簡報層級的主題；若單一版面族群需要不同樣式，則使用版面覆寫；僅在真實例外情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填充儲存在 [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iformatscheme/) 中。PowerPoint 在 UI 中可呈現的背景選項往往多於此集合實際儲存的填充定義，因為 UI 可將主題填充與主題顏色及其他樣式參考組合使用。

![PowerPoint 針對簡報主題的背景樣式畫廊](presentation-design_8.png)

在使用背景樣式前，請檢查已儲存的集合以及目前的 [Background.getStyleIndex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/background/)。樣式索引值 `0` 代表沒有主題填充；正值則為主題背景樣式的參考。這與直接索引 Java 集合不同，`get_Item(0)` 代表第一筆儲存項目。切勿假設每個簡報都有相同數量的背景填充樣式。

以下範例回報可用的背景填充數量，將主題背景參考指派給第一個母片，並儲存簡報：

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

可見結果取決於母片參考的主題條目以及版面或投影片層級的任何背景覆寫。若投影片自行設定背景，僅變更母片背景可能不會影響該投影片。需要取得繼承後最終背景時，請使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/background/)。

{{% alert color="warning" title="警告" %}}
請勿將樣式索引當作零基集合索引使用。也避免從單一檔案硬編碼樣式編號，並假設在其他檔案中會有相同外觀；主題樣式定義是依簡報而異的。
{{% /alert %}}

{{% alert color="info" title="提示" %}}
關於直接背景格式設定與背景繼承，請參閱 [簡報背景](/slides/zh-hant/java/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式配置透過 [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iformatscheme/) 與 [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iformatscheme/) 分別公開填充、線條與效果樣式集合。典型的 Office 主題通常包含三個主要樣式條目，分別對應微妙、適中與強烈的格式，但程式碼應檢查每個集合，而非假設固定數量。

![相同圖形套用微妙、適中與強烈主題效果](presentation-design_10.png)

在 Java 中存取這些集合時，集合索引為零基：`get_Item(0)` 為第一筆儲存樣式，`get_Item(2)` 為第三筆。圖形的樣式參考索引則是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapestyle/) 暴露。修改主題樣式會影響引用該主題樣式的圖形；直接格式化的圖形可能保持不變。

以下範例檢查所需的樣式條目是否存在，變更第一個線條樣式、第三個填充樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

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

對於引用這些插槽的圖形而言，第一個主題線條樣式將變為紅色，第三個主題填充樣式將變為實心森林綠，第三個效果樣式則新增距離為 10 點的外部陰影。最終視覺結果仍取決於每個圖形實際參考的樣式插槽，以及直接格式化是否覆寫主題。

![變更線條、填充與陰影設定後的主題效果樣式](presentation-design_11.png)

## **讀取實際主題值**

原始主題物件僅告訴您在特定層級定義了什麼。實際值則告訴您投影片或圖形在繼承與本地覆寫解析後實際使用的內容。對於投影片，可呼叫 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseoverridethememanager/)。對於背景，使用 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/background/)，對於填充則使用 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/)。

以下範例從投影片讀取實際主題、背景以及第一個圖形的填充：

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

使用實際資料進行呈現診斷、驗證與比較。如果僅檢查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)，可能會錯過母片、版面、投影片或圖形的覆寫所帶來的最終外觀變化。

## **常見問題**

**套用外部主題會影響簡報中的每張投影片嗎？**

不會。[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslide/) 只會重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其現有主題。

**我可以在不變更母片的情況下，僅對單一投影片套用主題嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidethememanager/) 並初始化其覆寫主題。變更僅限於該投影片；其他投影片仍會繼承各自的主題。

**將主題從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片並保留來源外觀時，請使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imasterslidecollection/) 將來源母片克隆至目標簡報，接著使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/) 搭配該克隆母片複製投影片。這樣可同時保留母片、版面與主題。

**我要如何在繼承與覆寫之後看到實際值？**

對於投影片或版面主題，使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseoverridethememanager/)。對於格式物件，則使用相應的實際資料方法，例如 [Background.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/background/) 與 [FillFormat.getEffective](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fillformat/)。這些 API 會在繼承與覆寫套用後回傳解析後的值。
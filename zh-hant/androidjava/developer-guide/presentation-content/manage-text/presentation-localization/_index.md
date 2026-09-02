---
title: 在 Android 上自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/androidjava/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 抑制拼寫檢查
- 校對語言
- 語言 ID
- 多語言文字
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides for Android via Java 為 PowerPoint 與 OpenDocument 簡報文字設定校對語言，包含預設值與多語言段落。"
---
## **概述**

Aspose.Slides for Android via Java 讓您能為單一文字部分設定校對中繼資料。使用[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 來指定校對語言，使用[IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) 來允許或抑制拼寫檢查，並使用[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) 來控制更廣泛的「不校對」狀態。由於這些設定是於部分層級套用，一個段落可以同時包含多種語言和不同的校對規則。

本文說明如何為特定文字指定語言、使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 為新文字設定預設語言、建立多語言段落、在 `SpellCheck` 與 `ProofDisabled` 之間做選擇，以及在使用[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) 時保留預期的設定。這些屬性僅儲存給簡報應用程式使用的中繼資料；它們不會翻譯文字、執行基於字典的拼寫檢查，或回傳錯字。

## **設定文字的校對語言**

建立或載入一個[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)，透過[IPortion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/#getPortionFormat--) 取得所需文字部分，並指派其語言識別碼。以下範例建立一個圖形，將校對語言設為英式英文，並使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 儲存結果：

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **為新文字設定預設語言**

使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 指定 Aspose.Slides 為新建立的文字指派的校對語言。當簡報中大部分或全部新文字使用相同語言時，此設定相當有用。它不會變更已經有明確語言的文字之語言中繼資料。

以下範例建立一個簡報，使其新文字使用德文校對規則：

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在同一段落中使用多種語言**

[IParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraph/) 包含一系列文字部分。為每種語言建立獨立的[Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portion/)，並分別設定其 `LanguageId`。

此範例建立一個段落，內含英文與法文部分：

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **為單一部分啟用或抑制拼寫檢查**

[IPortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportionformat/) 繼承自[IBasePortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseportionformat/) 所定義的共通文字屬性。透過[IPortion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/#getPortionFormat--) 取得部分的格式，並使用[IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) 來控制簡報應用程式是否檢查該部分的拼寫。預設值為 `false`：`true` 允許拼寫檢查，`false` 則抑制。

此設定適用於個別文字部分。因此，同一段落中的不同部分可以使用不同的設定。[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 與 `setSpellCheck` 互補：`setLanguageId` 用於識別校對語言，而 `setSpellCheck` 決定是否允許對該部分執行拼寫檢查。

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) 也會控制校對，但它以[NullableBool](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/nullablebool/) 形式表示較廣的「不校對」狀態。當您需要一個直接的布林開關專門控制拼寫檢查時，使用 `setSpellCheck`；若您需要保留或明確控制簡報的「不校對」中繼資料（包括 `NotDefined` 狀態），則使用 `setProofDisabled`。若同時設定兩個屬性，請保持其值一致；勿將 `setSpellCheck(true)` 與 `setProofDisabled(NullableBool.True)` 混用。

這些屬性會設定 PowerPoint 與其他簡報應用程式所使用的校對中繼資料。Aspose.Slides 不會利用它們執行字典式拼寫檢查或回傳錯字清單。

以下完整範例建立輸入簡報、載入它、為同一段落中的兩個部分指派不同的拼寫檢查設定與校對語言、儲存結果、重新開啟，並驗證所儲存的值：

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) 會合併相鄰且格式相同的部分。僅 `SpellCheck` 差異不足以讓這些部分保持分離；合併後的部分會保留第一個部分的 `SpellCheck` 值。若部分需要不同的拼寫檢查設定，請在指派這些設定之前呼叫 `joinPortionsWithSameFormatting`，或在合併後檢查產生的部分邊界並重新套用設定。具有不同 `LanguageId` 值的部分會因校對語言格式不同而保持獨立。

## **FAQ**

**語言 ID 會翻譯文字嗎？**

不會。[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 僅儲存拼寫與文法的校對中繼資料；它不會改變文字內容。請先自行翻譯文字，然後為每個翻譯后的部分設定適當的語言識別碼。

**校對語言會控制字型、斷字或換行嗎？**

不會。語言識別碼僅用於校對。文字的呈現與版面配置主要取決於可用的[字型](/slides/zh-hant/androidjava/powerpoint-fonts/)、書寫系統以及文字框設定。為確保正確呈現，請提供所需字型、設定[字型取代](/slides/zh-hant/androidjava/font-substitution/)，或在簡報中[嵌入字型](/slides/zh-hant/androidjava/embedded-font/)。

**一個段落可以使用多種校對語言嗎？**

可以。請像多語言段落範例那樣，為每種語言建立獨立的部分。

**應該使用 `setDefaultTextLanguage` 還是 `setLanguageId`？**

當您想為新建立的文字設定預設語言時，使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)。若特定部分需要明確的校對語言，或段落內包含多種語言，則使用[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)。
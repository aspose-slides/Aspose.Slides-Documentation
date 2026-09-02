---
title: 在 Java 中自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/java/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 抑制拼寫檢查
- 校對語言
- 語言 ID
- 多語言文字
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 為 PowerPoint 和 OpenDocument 簡報文字設定校對語言，包括預設語言和多語言段落。"
---
## **概觀**

Aspose.Slides for Java 讓您為單獨的文字片段設定校對中繼資料。使用 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 來識別校對語言，使用 [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) 以允許或抑制拼寫檢查，並使用 [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) 來控制更廣泛的「不校對」狀態。由於這些設定是套用在片段層級，同一段落可以包含多種語言與不同的校對規則。

本文說明如何將語言指派給特定文字、使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 為新文字設定預設語言、建構多語言段落、在 `SpellCheck` 與 `ProofDisabled` 之間做選擇，以及在使用 [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) 時保留預期的設定。這些屬性僅儲存簡報應用程式的中繼資料；它們不會翻譯文字、執行基於字典的拼寫檢查，亦不會回傳拼寫錯誤的字詞。

## **設定文字的校對語言**

建立或載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)，透過 [IPortion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#getPortionFormat--) 取得需要的文字片段，並指派其語言識別碼。以下範例建立一個圖形、將英式英文設定為校對語言，並使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 儲存結果：

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

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 來指定 Aspose.Slides 為新建立的文字指派的校對語言。當簡報中的大多數或全部新文字使用相同語言時，這項設定非常有用。它不會變更已明確設定語言的文字之中繼資料。

以下範例建立一個簡報，其新文字使用德語校對規則：

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

[IParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/) 包含一系列文字片段。為每種語言建立單獨的 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/)，並分別設定其 `LanguageId`。

此範例建立一個段落，內含英文與法文片段：

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

## **為個別片段啟用或抑制拼寫檢查**

[IPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportionformat/) 繼承自 [IBasePortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/) 定義的通用文字屬性。透過 [IPortion.getPortionFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/#getPortionFormat--) 取得片段的格式，並使用 [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) 來控制簡報應用程式是否檢查該片段的拼寫。預設值為 `false`：`true` 允許拼寫檢查，`false` 則抑制檢查。

此設定僅套用於單一文字片段。因此，同一段落中的不同片段可以擁有不同的值。[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 與 `setSpellCheck` 具互補關係：前者用於辨識校對語言，後者決定是否允許針對該片段進行拼寫檢查。

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) 亦可控制校對，但它以 [NullableBool](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/nullablebool/) 代表更廣泛的「不校對」狀態。當您需要一個直接的 Boolean 開關來處理拼寫檢查時，使用 `setSpellCheck`。當您需要保留或明確控制簡報的「不校對」中繼資料（包括其 `NotDefined` 狀態）時，使用 `setProofDisabled`。若同時設定兩者，請保持其值一致；不要將 `setSpellCheck(true)` 與 `setProofDisabled(NullableBool.True)` 結合使用。

這些屬性會配置 PowerPoint 與其他簡報應用程式使用的校對中繼資料。Aspose.Slides 不會利用它們執行字典式拼寫檢查或回傳錯字清單。

以下完整範例建立輸入簡報、載入它、為同一段落的兩個片段指派不同的拼寫檢查設定與校對語言，儲存結果、重新開啟，並驗證已儲存的值：

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) 會合併具有相同格式的相鄰片段。僅 `SpellCheck` 差異不會使片段保持分離；合併後的片段會保留第一個片段的 `SpellCheck` 值。若片段需要不同的拼寫檢查設定，請在指派這些設定之前呼叫 `joinPortionsWithSameFormatting`，或在合併後檢查產生的片段邊界並重新套用設定。具有不同 `LanguageId` 值的片段會因校對語言格式不同而保持分離。

## **常見問題**

**語言 ID 會翻譯文字嗎？**

不會。[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 只儲存拼寫與文法的校對中繼資料，並不會改變文字內容。請先自行翻譯文字，然後為每個已翻譯的片段設定適當的語言識別碼。

**校對語言會控制字型、斷字或換行嗎？**

不會。語言識別碼僅供校對使用。文字的呈現與版面配置主要取決於可用的 [fonts](/slides/zh-hant/java/powerpoint-fonts/)、書寫系統以及文字框設定。為確保可靠的呈現，請提供所需字型、設定 [font substitution](/slides/zh-hant/java/font-substitution/)，或在簡報中 [embed fonts](/slides/zh-hant/java/embedded-font/)。

**一個段落可以使用多種校對語言嗎？**

可以。如多語言段落範例所示，為每種語言建立獨立的片段並指派相應的語言。

**我應該使用 `setDefaultTextLanguage` 還是 `setLanguageId`？**

當您想為新建立的文字設定預設語言時，使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)。當特定片段需要明確的校對語言，或段落中包含多種語言時，使用 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)。
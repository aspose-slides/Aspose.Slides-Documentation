---
title: Android でプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーション ローカリゼーション
type: docs
weight: 100
url: /ja/androidjava/presentation-localization/
keywords:
- 言語を変更
- スペルチェック
- スペルチェックの抑制
- 校正言語
- 言語 ID
- 多言語テキスト
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android で Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument プレゼンテーションテキストの校正言語を設定します。デフォルト設定や多言語段落も含みます。"
---
## **概要**

Aspose.Slides for Android via Java では、個々のテキスト部分に対して校正メタデータを構成できます。校正言語を識別するには[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) を、スペルチェックの許可または抑制には[IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) を、より広範な「校正しない」状態を制御するには[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) を使用します。これらの設定は部分レベルで適用されるため、1 つの段落に複数の言語や異なる校正ルールを含めることができます。

本稿では、特定のテキストに言語を割り当てる方法、[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用して新規テキストのデフォルト言語を設定する方法、多言語段落の構築方法、`SpellCheck` と `ProofDisabled` の選択方法、そして[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) を使用した際に設定を保持する方法を説明します。これらのプロパティはプレゼンテーション アプリケーション向けのメタデータを格納しますが、テキストの翻訳、辞書ベースのスペルチェック、または誤字リストの取得は行いません。

## **テキストの校正言語を設定する**

[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) を作成または読み込み、[IPortion.getPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/#getPortionFormat--) で目的のテキスト部分にアクセスし、その言語識別子を割り当てます。次の例はシェイプを作成し、校正言語として英国英語を設定し、[Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) で結果を保存します。

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

## **新規テキストのデフォルト言語を設定する**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用して、Aspose.Slides が新規に作成するテキストに割り当てる校正言語を指定します。この設定は、プレゼンテーション内のほとんどまたはすべての新規テキストが同じ言語を使用する場合に便利です。既に明示的な言語が設定されているテキストのメタデータは変更されません。

次の例は、新規テキストがドイツ語の校正規則を使用するプレゼンテーションを作成します。

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

## **1 段落で複数言語を使用する**

[IParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/) はテキスト部分のコレクションを保持します。言語ごとに個別の[Portion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/portion/) を作成し、`LanguageId` を個別に設定します。

この例は、英語部分とフランス語部分を持つ 1 つの段落を作成します。

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

## **個々の部分でスペルチェックを有効または抑制する**

[IPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportionformat/) は[IBasePortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/) で定義された共通テキストプロパティを継承します。[IPortion.getPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/#getPortionFormat--) で部分の書式にアクセスし、[IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) を使用して、プレゼンテーション アプリケーションがその部分のスペルチェックを行うかどうかを制御します。デフォルト値は `false` で、`true` に設定するとスペルチェックが有効になり、`false` に設定すると抑制されます。

この設定は個々のテキスト部分に適用されます。同じ段落内の異なる部分は異なる値を使用できます。[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) と `setSpellCheck` は補完的な役割を果たします：`setLanguageId` は校正言語を識別し、`setSpellCheck` はその部分でスペルチェックを許可するかどうかを決定します。

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) も校正を制御しますが、これは [NullableBool](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/nullablebool/) としてより広範な「校正しない」状態を表します。スペルチェック専用のブールスイッチが必要な場合は `setSpellCheck` を使用し、プレゼンテーション の「校正しない」メタデータ（`NotDefined` 状態を含む）を保持または明示的に制御したい場合は `setProofDisabled` を使用してください。両方のプロパティを設定する場合は値を一貫させ、`setSpellCheck(true)` と `setProofDisabled(NullableBool.True)` を組み合わせないでください。

これらのプロパティは PowerPoint などのプレゼンテーション アプリケーションで使用される校正メタデータを構成します。Aspose.Slides はこれらを辞書ベースのスペルチェックや誤字リストの取得に使用しません。

以下の完全な例では、入力プレゼンテーションを作成し、ロード後に同一段落内の 2 つの部分に対して異なるスペルチェック設定と校正言語を割り当て、結果を保存し、再度開いて格納された値を検証します。

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) は、同一書式を持つ隣接部分を結合します。`SpellCheck` の違いだけでは部分は別々に保たれません。結合後の部分は最初の部分の `SpellCheck` 値を保持します。異なるスペルチェック設定が必要な場合は、設定を割り当てる前に `joinPortionsWithSameFormatting` を呼び出すか、結合後に結果の部分境界を確認して設定を再適用してください。`LanguageId` の値が異なる部分は、校正言語の書式が異なるため別々に残ります。

## **FAQ**

**言語 ID はテキストを翻訳しますか？**

いいえ。[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) はスペルチェックや文法校正のためのメタデータを格納するだけで、テキスト内容は変更しません。テキストは別途翻訳し、翻訳後の各部分に適切な言語識別子を設定してください。

**校正言語はフォント、ハイフネーション、改行を制御しますか？**

いいえ。言語識別子は校正用です。テキストの描画とレイアウトは使用可能な[フォント](/slides/ja/androidjava/powerpoint-fonts/)、文字体系、テキストフレーム設定に主に依存します。確実な表示のために必要なフォントを提供し、[フォント置換](/slides/ja/androidjava/font-substitution/) や[フォント埋め込み](/slides/ja/androidjava/embedded-font/) を設定してください。

**1 段落で複数の校正言語を使用できますか？**

はい。言語ごとに別々の部分を割り当てれば、例にある多言語段落のように実現できます。

**`setDefaultTextLanguage` と `setLanguageId` のどちらを使用すべきですか？**

新規に作成するテキスト全体のデフォルトを設定したい場合は[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用します。特定の部分に明示的な校正言語を設定したい、または段落内に複数言語が混在する場合は[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) を使用してください。
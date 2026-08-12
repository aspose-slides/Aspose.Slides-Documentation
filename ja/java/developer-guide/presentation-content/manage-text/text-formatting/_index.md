---
title: Javaでプレゼンテーションテキストをフォーマットする
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/java/text-formatting/
keywords:
- 段落の整列
- テキストスタイル
- テキストの背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- 自動調整プロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のプレゼンテーション内のテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストを書式設定する方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落の間隔、オートフィット動作、テキストのアンカー、タブ位置、言語設定などをカバーしています。

以下の例では、最初のスライドに単一のテキストボックスがあり、次のテキストが含まれる「sample.pptx」ファイルを使用します。

![サンプルテキスト](sample_text.png)

リテラルテキストや正規表現マッチを検索してハイライトする方法については、[テキストの検索と置換](/slides/ja/java/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定**

[IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用して段落のデフォルトハイライト色を設定するか、[IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) を使用して個別のテキスト部分のハイライト色を設定します。

次のコード例は **全段落** の背景色を設定する方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落全体のハイライト色を設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![灰色の段落](gray_paragraph.png)

次のコード例は **太字フォントのテキスト部分** の背景色を設定する方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // テキスト部分のハイライト色を設定します。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落の整列**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) を使用してテキストフレーム内の段落の配置を設定します。値は中央揃え、左揃え、右揃え、両端揃えなどが指定できます。

次のコード例は段落を **中央** に整列する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落の配置を中央揃えに設定します。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![整列された段落](aligned_paragraph.png)

## **テキストの透明度を設定**

テキストの透明度は [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) に割り当てられた色のアルファコンポーネントで制御します。以下の例では `alpha = 50` は 0〜255 スケールの ARGB アルファチャネル値であり、透明度のパーセンテージではありません。

次のコード例は **全段落** に透明度を適用する方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // テキストの塗りつぶし色を透明色に設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![透明な段落](transparent_paragraph.png)

次のコード例は **太字フォントのテキスト部分** に透明度を適用する方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // テキスト部分の透明度を設定します。
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔を設定**

[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) を使用してテキストボックス内の文字間隔を拡大または縮小します。

次の Java コードは **全段落** の文字間隔を拡大する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注: 文字間隔を縮めるには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 文字間隔を拡大します。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

次のコード例は **太字フォントのテキスト部分** の文字間隔を拡大する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注: 文字間隔を縮めるには負の値を使用します。
            portion.getPortionFormat().setSpacing(3); // 文字間隔を拡大します。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint に表示されるテキストより若干詰まって見えることがあります。これは PowerPoint が特定フォントのカーニングデータを無視することが原因です（フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっていても同様です）。

このような場合にレンダリング結果を PowerPoint に近づけるには、影響を受けたフォントを使用しているテキスト部分のカーニングを無効にします。実際のフォントサイズよりはるかに大きい値を [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) に設定します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この設定により、該当するテキスト部分にカーニングが適用されなくなり、PowerPoint 固有の動作の影響を受けたフォントでの表示がより一致します。

## **テキストフォントプロパティの管理**

フォントプロパティは、[IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用して段落レベルで設定するか、[IPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportionformat/) を使用して個々の部分で設定できます。

次のコードは段落全体のフォントとテキストスタイルを設定します。フォントサイズ、太字、イタリック、点線下線、そして Times New Roman フォントを段落内のすべての部分に適用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落のフォントプロパティを設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落のフォントプロパティ](font_properties_for_paragraph.png)

次のコード例は **太字フォントのテキスト部分** に同様のプロパティを適用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // テキスト部分のフォントプロパティを設定します。
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキスト回転を設定**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) を使用してシェイプ内の事前定義されたテキスト方向を設定します。

次のコード例はテキストの方向を `Vertical270` に設定し、テキストを **90 度反時計回り** に回転させます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![テキスト回転](text_rotation.png)

## **テキストフレームのカスタム回転を設定**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) を使用して [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) のカスタム回転角度を設定します。

次のコード例はシェイプ内でテキストフレームを時計回りに 3 度回転させます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間を設定**

Aspose.Slides は [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-)、[IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) を提供し、段落の間隔を制御します。これらのプロパティは次のように使用します。

* 正の値を使用すると、行間を行の高さのパーセンテージで指定します。  
* 負の値を使用すると、行間をポイントで指定します。

次のコード例は段落内の行間を指定する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落内の行間](line_spacing.png)

## **テキストフレームの自動調整タイプを設定**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) は、テキストがコンテナの境界を超えたときの挙動を決定します。テキストが縮小するか、はみ出すか、またはシェイプが自動的にサイズ変更されるかを制御できます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テキストフレームのアンカーを設定**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) は、テキストがシェイプ内で垂直方向にどの位置に配置されるか（上部、中央、下部など）を定義します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テキストのタブ設定**

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) と [IParagraphFormat.getTabs](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getTabs--) を使用して段落内のタブ位置を構成します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落タブ](paragraph_tabs.png)

## **校正言語を設定**

Aspose.Slides は [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックに使用される言語を決定します。

次のコード例はテキスト部分の校正言語を設定する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 校正言語の ID を設定します。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **デフォルト言語を設定**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新しい長方形シェイプをテキスト付きで追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 最初の部分の言語を確認します。
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **デフォルトテキストスタイルを設定**

プレゼンテーションレベルでデフォルトのテキスト書式を適用するには、[IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) を使用します。

次のコード例は新しいプレゼンテーション内のすべてのスライドで、太字 14pt フォントをデフォルトとして設定する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // トップレベルの段落書式を取得します。
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **All-Caps 効果でテキストを抽出**

PowerPoint では **All Caps** フォント効果を適用すると、スライド上のテキストが大文字で表示されます（元の入力が小文字でも同様です）。Aspose.Slides でそのテキスト部分を取得すると、ライブラリは入力されたままの文字列を返します。表示されたテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textcaptype/) を確認し、値が `All` のときに返された文字列を大文字に変換します。

以下は sample2.pptx の最初のスライドにあるテキストボックスの例です。

![All-Caps 効果](all_caps_effect.png)

次のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

出力:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上のテーブルのテキストを変更する方法は？**

テーブルのテキストを変更するには、[ITable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itable/) を使用します。セルを反復処理し、[ICell.getTextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icell/#getTextFrame--) を介して各セルのテキストフレームを取得し、[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getParagraphFormat--) を使用して段落書式を更新します。

**PowerPoint スライドのテキストにグラデーション色を適用する方法は？**

グラデーション色を適用するには、[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) を使用します。[IFillFormat.setFillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifillformat/#setFillType-byte-) に [FillType.Gradient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) を設定し、グラデーションストップ、方向、透明度を構成します。
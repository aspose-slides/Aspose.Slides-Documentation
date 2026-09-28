---
title: Java でプレゼンテーションテキストをフォーマットする
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/java/text-formatting/
keywords:
- 段落の整列
- テキストスタイル
- テキスト背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットする方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィットの動作、テキストのアンカリング、タブストップ、言語設定について説明します。

特に記載がない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキストボックスで、最初の段落に以下のテキストが含まれています。スライドとシェイプのインデックスは 0 ベースです。太字部分を選択する例は、継承された太字フォーマットを含む有効なフォーマットを使用します:

![サンプルテキスト](sample_text.png)

リテラルテキストや正規表現の一致を検索してハイライトする方法については、[Search and Replace Text](/slides/ja/java/search-and-replace-text/) を参照してください。

## **テキストの背景色の設定**

段落のデフォルトハイライト色を設定するには [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用し、個々のテキスト部分のハイライト色を設定するには [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) を使用します。

次の例は、最初の段落のデフォルトとして薄いグレーのハイライトを設定します。個々の部分に対する明示的なハイライト色はこのデフォルトより優先されます:

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

結果：

![灰色の段落](gray_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**の背景色を設定する方法を示します:

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

結果：

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

テキストフレーム内の段落配置を設定するには [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) を使用します。値には中央揃え、左揃え、右揃え、両端揃えなどがあります。

次のコード例は、段落を**中央揃え**にする方法を示します:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落の配置を中央に設定します。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![揃えた段落](aligned_paragraph.png)

## **テキストの透明度の設定**

テキストの透明度は [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) に割り当てられた色のアルファ成分で制御されます。以下の例では `alpha = 50` は 0〜255 のスケールの ARGB アルファチャンネル値であり、透明度のパーセンテージではありません。

以下のコード例は、**段落全体**に透明度を適用する方法を示します:

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

結果：

![透明な段落](transparent_paragraph.png)

次のコード例は、**太字フォントのテキスト部分**に透明度を適用する方法を示します:

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

結果：

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔の設定**

テキストボックス内の文字間隔を拡張または縮小するには [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) を使用します。例では 3 ポイントの間隔を追加しています。負の値はテキストを縮めます。

次の Java コードは、**段落全体**の文字間隔を拡張する方法を示します:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注: 文字間隔を圧縮するには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 文字間隔を拡張します。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**の文字間隔を拡張する方法を示します:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注: 文字間隔を圧縮するには負の値を使用します。
            portion.getPortionFormat().setSpacing(3); // 文字間隔を拡張します。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint で表示される同じテキストよりもやや詰まって見えることがあります。これは、フォントに有効なカーニング情報が含まれていて PowerPoint の設定でカーニングが有効になっていても、PowerPoint が特定のフォントのカーニングデータを無視するために起こります。

このようなケースでレンダリング結果を PowerPoint に近づけるには、該当フォントを使用するテキスト部分のカーニングを無効にできます。[IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) に実際のフォントサイズより大きな値を設定します。この例は、最初のスライドの最初のシェイプがテキストボックスである "presentation.pptx" が必要です。継承されたフォントを含む有効なフォント名を確認し、Roboto を使用する部分に対して 100 ポイントの閾値を設定します。これにより、フォントサイズが 100 ポイント未満の該当部分のカーニングが無効になります:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

閾値以下の該当テキストに対して、この設定はカーニングを防止し、PowerPoint 固有の動作の影響を受けるフォントの視覚的出力を Aspose.Slides のレンダリングと合わせるのに役立ちます。

## **テキストフォントプロパティの管理**

フォントプロパティは、段落レベルでは [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用し、個々の部分では [IPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportionformat/) を使用して設定できます。

次の例は、最初の段落のデフォルトフォントを 12 ポイントの Times New Roman に設定し、太字、斜体、点線の下線フォーマットを適用します。個々の部分の明示的なフォーマットはこれらのデフォルトより優先されます。

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

結果：

![段落のフォントプロパティ](font_properties_for_paragraph.png)

次の例は、実際のフォーマットが太字である部分に対して、13 ポイントの Times New Roman、斜体フォーマット、点線の下線を適用します。

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

結果：

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキスト回転の設定**

シェイプ内の事前定義されたテキスト方向を設定するには [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) を使用します。

次のコード例は、シェイプ内のテキスト方向を [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textverticaltype/) に設定し、テキストを **90 度反時計回り** に回転させます:

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

結果：

![テキスト回転](text_rotation.png)

## **テキストフレームのカスタム回転の設定**

[ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) のカスタム回転角度を設定するには [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) を使用します。

以下のコード例は、シェイプ内でテキストフレームを時計回りに 3 度回転させます:

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

結果：

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間設定**

Aspose.Slides は、段落間隔を制御するために [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-)、および [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) を提供します。これらのプロパティは次のように使用します:

* 正の値を使用すると、行間を行の高さのパーセンテージで指定します。
* 負の値を使用すると、行間をポイントで指定します。

次の例は、最初の段落の内部間隔を行の高さの 200%（二倍の行間）に設定します:

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

結果：

![段落内の行間隔](line_spacing.png)

## **改行制御**

段落の改行ルールは、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで便利です。以下のメソッドは [IParagraphFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/) に属し、段落全体に適用されます:

* [setLatinLineBreak](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) はラテン文字の改行ルールを制御します。混在テキストでは、これを変更すると隣接する東アジア文字や句読点の折り返し位置も変わります。
* [setEastAsianLineBreak](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) は東アジア文字の改行ルールを制御し、行頭・行末の文字に関する制限を含みます。

これらのルールは、テキストフレーム内で自動折り返しを有効にする [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) の代わりになるものではありません。折り返しが発生したときのレイアウトに影響を与えますが、改行文字を挿入するわけではありません。明示的な改行は、利用可能な幅に関係なく段落内に新しい行を強制します。

次の自己完結型の例は、中国語とラテン文字を含む狭いテキストブロックを作成します。両方の改行オプションを明示的に設定し、"line_breaking.pptx" として保存します。どちらかのルールを試すには、もう一方の設定を固定したまま対応する値を変更します。例では 24 ポイントの Arial と SimSun を使用し、フレーム幅 160 ポイント、水平テキストフレーム余白 0 に設定しています。[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) を [TextAutofitType.None](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textautofittype/) に設定し、テキストサイズとフレームサイズを固定しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ハンギング句読点の制御**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) は、対象となる句読点が次の行に入り込む代わりにテキスト行の右端を超えて伸びることを許可します。段落全体に適用され、ハンギングインデントとは異なります。

次の自己完結型の例は、幅 100 ポイントのテキストフレームでハンギング句読点を有効にし、"hanging_punctuation.pptx" として保存します。24 ポイント Arial と水平テキストフレーム余白 0 の設定で、最後のピリオドは "sentence" の後に残り、右端を超えて表示されます。比較のためにプロパティを [NullableBool.False](https://reference.aspose.com/slides/ja/java/com.aspose.slides/nullablebool/) に設定すると、ピリオドは別の行に配置されます。折り返しは有効で、オートフィットは無効にして利用可能幅を固定しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

すべての句読点がハンギングできるわけではありません。見た目はフォントの可用性やレイアウトに依存します。フォント、利用可能幅、余白、またはオートフィット設定を変更すると、見た目の差がなくなることがあります。

## **テキストフレームのオートフィットタイプ設定**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) はテキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、シェイプを自動的にサイズ変更するかを制御できます。次の例は、シェイプをテキストに合わせてサイズ変更するように設定し、結果を "autofit_type.pptx" として保存します。

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

自動折り返し後の行数をカウントし、テキストまたはシェイプの幅が結果にどのように影響するかを確認するには、[Count Rendered Lines](/slides/ja/java/manage-paragraph/) を参照してください。行数だけではテキストがコンテナからはみ出しているかどうかは判断できません。

## **テキストフレームのアンカー設定**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) はシェイプ内でテキストを垂直に配置する方法（上部、中央、下部など）を定義します。次の例は、最初のシェイプのテキストを下部にアンカーし、結果を "text_anchor.pptx" として保存します。

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

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) と [IParagraphFormat.getTabs](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getTabs--) を使用して段落のタブストップを設定します。次の例は、デフォルトのタブ間隔を 100 ポイントに設定し、30 ポイントに左揃えのタブストップを追加します。これらの設定はタブ文字を含むテキストに影響します。

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

結果：

![段落のタブ](paragraph_tabs.png)

## **校正言語の設定**

Aspose.Slides は [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックと文法チェックに使用される言語を決定します。

次の例は、最初のスライドの最初のシェイプがテキストボックスで、少なくとも1つの段落がある "presentation.pptx" が必要です。最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、簡体字中国語の校正言語 (`zh-CN`) を割り当てます。結果は "proofing_language.pptx" として保存されます:

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

    // 校正言語の Id を設定します。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **デフォルト言語の設定**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。次の例は、デフォルトテキスト言語を米国英語に設定したプレゼンテーションを作成し、テキストボックスを追加し、最初のテキスト部分に対して `en-US` を出力します。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // テキスト付きの新しい矩形シェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 最初の部分の言語を確認します。
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **デフォルトテキストスタイルの設定**

プレゼンテーションレベルでデフォルトのテキスト書式を適用するには、[IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) を使用します。

次の例は、新しいプレゼンテーションの最上位段落のデフォルトとして 14 ポイントの太字フォントを設定し、"default_text_style.pptx" として保存します。テキストは、より具体的な書式設定が上書きしない限り、これらのデフォルトを継承できます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // トップレベルの段落フォーマットを取得します。
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

## **All-Caps 効果でテキストを抽出する**

PowerPoint では、**All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上で大文字として表示されます。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは入力されたままのテキストを返します。表示されたテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textcaptype/) を確認し、値が `All` の場合は返された文字列を大文字に変換します。

この例は、最初のスライドの最初のシェイプがテキストボックスである "sample2.pptx" が必要です。最初の段落の最初の部分に All Caps 効果が適用された "Hello, Aspose!" が含まれています（下記参照）。

![All Caps 効果](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します:

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

出力：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上のテーブルのテキストを変更するにはどうすればよいですか？**

スライド上のテーブルのテキストを変更するには、[ITable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itable/) を使用します。セルを反復処理し、[ICell.getTextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icell/#getTextFrame--) で各セルを更新し、[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getParagraphFormat--) で段落の書式設定を行います。

**PowerPoint スライドのテキストにグラデーションカラーを適用するにはどうすればよいですか？**

テキストにグラデーションカラーを適用するには、[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) を使用します。[IFillFormat.setFillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifillformat/#setFillType-byte-) に [FillType.Gradient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) を設定し、グラデーションストップ、方向、透明度を構成します。
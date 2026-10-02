---
title: Javaでプレゼンテーションテキストをフォーマット
linktitle: テキストフォーマット
type: docs
weight: 50
url: /ja/java/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキスト背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキスト回転
- 回転角度
- テキストフレーム
- 行間隔
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットする方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット 動作、テキストのアンカリング、タブストップ、言語設定をカバーしています。

特に記載がない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキスト ボックスで、最初の段落には以下に示すテキストが含まれます。スライドとシェイプのインデックスはゼロベースです。太字部分を選択する例は、継承された太字書式を含む有効な書式を使用します。

![Sample text](sample_text.png)

文字列や正規表現の一致箇所を検索してハイライトするには、[テキストの検索と置換](/slides/ja/java/search-and-replace-text/) を参照してください。

## **テキストの背景色の設定**

段落のデフォルトのハイライト色を設定するには [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用し、個々のテキスト部分のハイライト色を設定するには [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) を使用します。

以下の例は、最初の段落のデフォルトとして薄いグレーのハイライトを設定します。個々の部分で明示的に設定されたハイライト色はこのデフォルトより優先されます。

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

![The gray paragraph](gray_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**の背景色を設定する方法を示しています。

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

![The gray text portions](gray_text_portions.png)

## **テキスト段落の配置**

テキスト フレーム内の段落の配置を設定するには [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) を使用します。値は中央揃え、左揃え、右揃え、両端揃えなどが指定できます。

以下のコード例は、段落を **中心** に揃える方法を示しています。

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

結果:

![The aligned paragraph](aligned_paragraph.png)

## **行内のフォントの配置**

行内の異なるフォントサイズのテキスト部分を垂直に揃えるには [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) を使用します。この設定は段落全体に適用され、各行内の揃え方を制御します。

以下の自己完結型例は、1枚のスライドに 4 つのラベル付きテキスト ボックスを作成します。各段落は 18、36、54 ポイントの同じテキストを含み、フォント配置が異なります。Arial を使用し、オートフィットと折り返しを無効にし、テキスト フレームは単一行が収まるサイズにしています。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

フォント配置はフォントメトリクスに基づくため、個々の文字の見える端が必ずしも正確に揃うわけではありません。例では大文字とディセンダを含め、ベースラインと底部配置の違いを示しています。使用可能なフォントや置換、文字種、フォントサイズの違いが結果に影響します。フレームのサイズ、余白、行間、折り返し、オートフィットもレイアウトに影響するため、モードを比較する際は同じフォントとレイアウト設定を使用してください。

この設定は、水平段落配置を制御する [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) や、シェイプ内でテキストブロックを垂直に配置する [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) とは異なります。上付き・下付きの書式は [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) によってベースラインに対して個々の部分をシフトさせるもので、段落行のフォント配置を設定するものではありません。

## **テキストの透明度の設定**

テキストの透明度は、[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) に割り当てられた色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 のスケールでの ARGB アルファチャネル値であり、透明度のパーセンテージではありません。

以下のコード例は、**段落全体** に透明度を適用する方法を示しています。

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

![The transparent paragraph](transparent_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** に透明度を適用する方法を示しています。

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

![The transparent text portions](transparent_text_portions.png)

## **テキストの文字間隔の設定**

テキスト ボックス内の文字間隔を拡大または縮小するには [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) を使用します。例では 3 ポイントの間隔を追加しています。負の値を指定するとテキストが縮まります。

以下の Java コードは、**段落全体** の文字間隔を拡大する方法を示しています。

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

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** の文字間隔を拡大する方法を示しています。

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

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の同じテキストよりもやや詰まって見えることがあります。これは、PowerPoint が特定のフォントに対してカーニング情報を無視することが原因です（フォントに有効なカーニング情報があり、PowerPoint の設定でカーニングが有効になっていても）。

このようなケースで PowerPoint に近い出力を得るには、影響を受けたフォントを使用するテキスト部分のカーニングを無効にします。[IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) に、実際のフォントサイズより大きい値を設定します。この例では、最初のスライドの最初のシェイプがテキスト ボックスである "presentation.pptx" が必要です。継承フォントを含む有効なフォント名をチェックし、Roboto を使用する部分に対して 100 ポイントのしきい値を設定します。これにより、100 ポイント未満のフォントサイズの該当部分のカーニングが無効になります。

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

しきい値未満の該当テキストに対しては、この設定によりカーニングが抑制され、PowerPoint 固有の挙動の影響を受けるフォントで Aspose.Slides のレンダリングを PowerPoint の視覚出力に近づけられます。

## **テキストフォントプロパティの管理**

フォントプロパティは、段落レベルで [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用するか、個々の部分で [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) を使用して設定できます。

以下の例は、最初の段落のデフォルトフォントを 12 ポイントの Times New Roman に設定し、太字、イタリック、点線下線を適用します。個々の部分で明示的に設定された書式はこれらのデフォルトより優先されます。

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

![The font properties for the paragraph](font_properties_for_paragraph.png)

以下の例は、実効書式が太字である部分に対して 13 ポイントの Times New Roman、イタリック、点線下線を適用します。

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

![The font properties for text portions](font_properties_for_text_portions.png)

## **テキストの回転の設定**

テキストの向きをシェイプ内で事前定義された方向に設定するには [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) を使用します。

以下のコード例は、シェイプ内のテキスト方向を [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/) に設定します。これによりテキストは **90 degrees counterclockwise** 回転します。

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

![The text rotation](text_rotation.png)

## **テキストフレームのカスタム回転の設定**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) を使用して、[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) のカスタム回転角度を設定します。

以下のコード例は、シェイプ内でテキスト フレームを時計回りに 3 度回転させます。

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

![The custom text rotation](custom_text_rotation.png)

## **段落の行間隔の設定**

Aspose.Slides は、段落間隔を制御するために [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-)、[IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) を提供します。これらのプロパティは次のように使用します。

* 正の値を使用すると、行間を行の高さのパーセンテージで指定します。  
* 負の値を使用すると、行間をポイントで指定します。

以下の例は、最初の段落の内部間隔を行の高さの 200%（二重行間）に設定します。

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

![The line spacing within the paragraph](line_spacing.png)

## **改行の制御**

段落の改行規則は、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで有用です。これらのメソッドはすべて [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) に属し、段落全体に適用されます。

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) はラテン文字の改行規則を制御します。混在テキストでは、これを変更すると隣接する東アジア文字や句読点の折り返し位置も変わることがあります。  
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) は東アジア文字の改行規則を制御し、行頭・行末文字の制限を含みます。

これらの規則は、テキストフレーム内で自動折り返しを有効にする [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) の代わりになるものではありません。折り返しが発生したときのレイアウトに影響しますが、改行文字を挿入するわけではありません。明示的な改行は、利用可能幅に関係なく段落内で新しい行を強制します。

以下の自己完結型例は、中国語とラテン文字を含む狭いテキストブロックを作成し、2 つの改行オプションを明示的に設定して "line_breaking.pptx" として保存します。任意の規則を試すには、もう一方の設定を固定したまま対応する値を変更してください。例では 24 ポイントの Arial と SimSun を使用し、フレーム幅 160 ポイント、水平テキストフレーム余白 0 に設定しています。[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) は [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) で呼び出し、テキストサイズとフレーム寸法を固定しています。

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

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) は、対象となる句読点がテキスト行の右端を超えて伸びることを可能にし、次の行に占有させません。段落全体に適用され、ハンギングインデントとは異なります。

以下の自己完結型例は、幅 100 ポイントのテキストフレームでハンギング句読点を有効にし、"hanging_punctuation.pptx" として保存します。24 ポイントの Arial と水平余白 0 の設定で、最後の句点は "sentence" の後に残り、右テキスト端を超えて表示されます。比較のためにプロパティを [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) に設定すると、句点が別行に配置されます。折り返しは有効でオートフィットは無効にし、利用可能幅を固定しています。

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

すべての句読点がハンギングできるわけではありません。上記の[フォントとレイアウト条件](#control-line-breaking)もこの比較に適用されます。フォント、利用可能幅、余白、オートフィット設定を変更すると、可視的な差が消えることがあります。

## **テキストフレームのオートフィットタイプの設定**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、シェイプを自動でリサイズするかを制御できます。以下の例は、シェイプをテキストに合わせてリサイズするよう構成し、結果を "autofit_type.pptx" として保存します。

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

自動折り返し後の行数をカウントし、テキストまたはシェイプ幅の変化が結果に与える影響を確認するには、[描画された行の数](/slides/ja/java/manage-paragraph/) を参照してください。行数だけではテキストがコンテナをはみ出しているかどうかは判断できません。

## **テキストフレームのアンカー設定**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) は、テキストをシェイプ内で垂直方向に配置する方法（上部、中央、下部など）を定義します。以下の例は、テキストを最初のシェイプの下部にアンカーし、結果を "text_anchor.pptx" として保存します。

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

段落内のタブストップを構成するには [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) と [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) を使用します。以下の例は、デフォルトタブ間隔を 100 ポイントに設定し、30 ポイントに左揃えタブストップを追加します。これらの設定はタブ文字を含むテキストに影響します。

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

![The paragraph tabs](paragraph_tabs.png)

## **校正言語の設定**

Aspose.Slides は、テキスト部分の校正言語を設定できる [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) を提供します。校正言語は PowerPoint におけるスペルチェックと文法チェックに使用される言語を決定します。

以下の例は、最初のスライドの最初のシェイプがテキスト ボックスである "presentation.pptx" が必要です。最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、簡体字中国語の校正言語 (`zh-CN`) を割り当てます。結果は "proofing_language.pptx" として保存されます。

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

## **デフォルト言語の設定**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。以下の例は、デフォルトテキスト言語を米国英語に設定したプレゼンテーションを作成し、テキスト ボックスを追加して、最初のテキスト部分の言語コードとして `en-US` を出力します。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新しい矩形シェイプをテキスト付きで追加します。
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

プレゼンテーション レベルでデフォルトのテキスト書式を適用するには [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) を使用します。

以下の例は、新しいプレゼンテーションのトップレベル段落のデフォルトとして 14 ポイントの太字フォントを設定し、結果を "default_text_style.pptx" として保存します。テキストは、より具体的な書式設定が上書きしない限り、これらのデフォルトを継承できます。

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

PowerPoint では、**All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、元の入力は小文字のままです。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは入力されたままのテキストを返します。表示されているテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) をチェックし、値が `All` の場合は取得文字列を大文字に変換します。

この例は、最初のスライドの最初のシェイプがテキスト ボックスである "sample2.pptx" が必要です。最初の段落の最初の部分に **All Caps** 効果が適用された "Hello, Aspose!" が含まれています（下図参照）。

![The All Caps effect](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示しています。

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

**スライド上のテーブルのテキストを変更するにはどうすればよいですか？**

スライド上のテーブルのテキストを変更するには [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) を使用します。セルを反復処理し、各セルを [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) で取得し、段落書式を [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) で更新します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するにはどうすればよいですか？**

テキストにグラデーションカラーを適用するには [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) を使用します。[IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) を [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成します。
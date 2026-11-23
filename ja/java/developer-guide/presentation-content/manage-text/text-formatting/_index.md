---
title: Java でプレゼンテーションテキストをフォーマット
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/java/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキストの背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキストの回転
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
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のプレゼンテーション内のテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストの書式設定方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカー設定、タブ位置、言語設定について説明します。

特に明記されていない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキストボックスで、その最初の段落には以下に示すテキストが含まれます。スライドとシェイプのインデックスはゼロベースです。太字部分を選択する例は、継承された太字書式を含む有効な書式設定を使用します：

![サンプルテキスト](sample_text.png)

文字列リテラルや正規表現の一致箇所を検索してハイライトするには、[テキストの検索と置換](/slides/ja/java/search-and-replace-text/) を参照してください。

## **テキストの背景色の設定**

[IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用して段落のデフォルトハイライト色を設定し、個々のテキスト部分には [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) を使用します。

以下の例は、最初の段落のデフォルトとして薄いグレーのハイライトを設定します。個々の部分に対する明示的なハイライト色はこのデフォルトよりも優先されます：

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

![グレーの段落](gray_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** の背景色を設定する方法を示します：

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

![グレーのテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) を使用してテキストフレーム内の段落の配置を設定します。値は中央揃え、左揃え、右揃え、両端揃えなどが指定できます。

以下のコード例は、段落を **中央** に配置する方法を示します：

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

![配置された段落](aligned_paragraph.png)

## **行内のフォントの配置**

[IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) を使用して、行内の異なるフォントサイズのテキスト部分を垂直に揃えます。この設定は段落全体に適用され、各行内の配置を制御します。

以下の自己完結型例は、1枚のスライドに4つのラベル付きテキストボックスを作成します。各段落は 18、36、54 ポイントの同じテキストを含み、フォント配置が異なります。Arial を使用し、オートフィットと折り返しを無効にして、テキストフレームが単一行に収まるようにしています。

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

![混在フォントサイズでのベースライン、上端、中央、下端フォント配置の比較](font_alignment.png)

フォント配置はフォントメトリクスに基づくため、個々の文字の見た目の端が必ずしも正確に揃うわけではありません。例では大文字とディセンダーの両方を含め、ベースラインと下端配置の違いを示しています。フォントの利用可否や代替、使用文字、フォントサイズの差は結果に影響します。フレームのサイズ、余白、行間、折り返し、オートフィットもレイアウトに影響するため、モードを比較する際は同じフォントとレイアウト設定を使用してください。

この設定は、水平段落配置を制御する [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) と、シェイプ内でテキストブロックを垂直に配置する [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) とは異なります。[IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) による上付き・下付きの書式設定は、段落行のフォント配置を設定するのではなく、ベースラインに対して個々の部分をシフトさせます。

## **テキストの透明度の設定**

テキストの透明度は、[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) に割り当てられた色のアルファ成分で制御します。以下の例では、`alpha = 50` は 0〜255 のスケールの ARGB アルファチャネル値であり、透明度のパーセンテージではありません。

以下のコード例は、**段落全体** に透明度を適用する方法を示します：

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

以下のコード例は、**太字フォントのテキスト部分** に透明度を適用する方法を示します：

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

## **テキストの文字間隔の設定**

[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) を使用して、テキストボックス内の文字間の間隔を拡大または縮小します。例では 3 ポイントの間隔を追加しています。負の値は文字を縮めます。

以下の Java コードは、**段落全体** の文字間隔を拡大する方法を示します：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注: 文字間隔を縮めるには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 文字間隔を拡張します。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** の文字間隔を拡大する方法を示します：

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
            portion.getPortionFormat().setSpacing(3); // 文字間隔を拡張します。
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

場合によっては、Aspose.Slides が描画するテキストが PowerPoint の同じテキストよりもやや詰まって見えることがあります。これは、PowerPoint が特定のフォントのカーニングデータを無視することがあり、フォントに有効なカーニング情報があり、PowerPoint の設定でカーニングが有効でも起こります。

このような場合にレンダリング結果を PowerPoint に近づけるには、影響を受けたフォントを使用するテキスト部分のカーニングを無効にできます。[IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) を実際のフォントサイズより大きい値に設定します。この例では、最初のスライドの最初のシェイプがテキストボックスである「presentation.pptx」が必要です。実効フォント名（継承フォントを含む）をチェックし、Roboto を使用する部分に 100 ポイントの閾値を設定します。これにより、フォントサイズが 100 ポイント未満の該当部分のカーニングが無効になります：

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

閾値未満の該当テキストに対しては、この設定によりカーニングが無効になり、PowerPoint 固有の動作の影響を受けるフォントの視覚的出力と Aspose.Slides のレンダリングを合わせるのに役立ちます。

## **テキストフォントプロパティの管理**

フォントプロパティは、段落レベルで [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用するか、個々の部分では [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) を使用して設定できます。

以下の例は、最初の段落のデフォルトフォントを 12 ポイントの Times New Roman に設定し、太字、斜体、点線下線の書式を適用します。個々の部分に対する明示的な書式設定はこれらのデフォルトよりも優先されます。

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

以下の例は、実効書式が太字である部分に対して、13 ポイントの Times New Roman、斜体、点線下線を適用します：

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

## **テキスト高さ正規化の制御**

テンプレートのタイポグラフィを再現したり文字高さの違いを調査したりする際には、[IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) を使用します。PowerPoint では、正規化を有効にすると、テキスト部分内の個々の文字が垂直方向に伸縮され、視覚的に均一な高さになりますが、異なるフォント間でテキストの高さが等しくなることは保証されません。

プロパティを [NullableBool.True または False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) に設定して、正規化を明示的に有効または無効にします。`NullableBool.NotDefined` はローカル設定を未設定のままにし、たとえば段落の [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) から値を継承させます。これは `False` を意味するわけではありません。[IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) を使用し、[IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) を参照して、解決されたブール値を取得してください。

以下の自己完結型例は **Arial** のインストールが必要です。54 ポイントで同じ大文字、小文字、ディセンダー、アクセント文字を含む 2 つのテキストブロックを作成します。両方の段落はデフォルトで正規化を有効にしています。上部の部分は明示的に無効にし、下部の部分は継承します。フレームサイズ、余白、段落間隔は同一で、比較を一貫させるために折り返しとオートフィットは無効にしています。例は `False: false` と `NotDefined: true` を出力し、"text_height_normalization.pptx" に保存します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下の比較は保存されたプレゼンテーションからエクスポートしたものです。上段は正規化が無効 (`False`) で、下段は有効設定を継承しています (`NotDefined` → `True`)。この外観を再現するには Arial をインストールしたままにしてください。

![Arial 54 ポイントのテキスト（上は正規化無効、下は正規化有効を継承）](text_height_normalization.png)

正規化は、ポイントでフォントサイズを指定する [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) の値を変更せずに文字の高さを変えます。段落の [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) は行間を制御し、テキストフレームの [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) はテキストまたはコンテナがフィットするように調整する方法を制御します。これらの設定は目的が異なり、全体レイアウトに独立して影響します。段落の書式設定と継承の詳細については、[段落の管理](/slides/ja/java/manage-paragraph/) を参照してください。

## **取り消し線の適用と削除**

テキスト部分に対して [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) を使用すると、元のテキストを削除せずに修正、キャンセルされた用語、以前の価格などを表示できます。テキストに 1 本または 2 本の線を引くには、[TextStrikethroughType.Single または Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) を設定します。

取り消し線を削除するには、[TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None) を渡します。これにより、周囲の書式が取り消し線を指定していても効果が明示的に無効化されます。対照的に、[TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) はローカル設定を未定義のままにし、例えば段落から書式を継承させます。これは取り消し線が確実に削除されるわけではありません。結果の書式（継承された値を含む）を取得するには、[IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) を使用してください。

以下の自己完結型例は、3 つの価格比較を作成します。各段落はラベル、以前の価格、現在の価格の別々の部分を持ち、影響を受けるのは以前の価格だけです。最初の行は取り消し線を適用してから削除し、他の行は単一および二重取り消し線を保持します。この設定を変更しても、テキストと他の書式（太字の以前価格を含む）は保持されます。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // 取り消し線を適用し、最初の以前価格から明示的に削除します。
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果は上から順に、取り消し線なし、単一取り消し線、二重取り消し線です。

![取り消し線なし、単一取り消し線、二重取り消し線の過去価格](strikethrough.png)

## **テキスト回転の設定**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) を使用して、シェイプ内の事前定義されたテキスト方向を設定します。

以下のコード例は、シェイプのテキスト方向を [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/) に設定します。これによりテキストが **反時計回りに 90 度** 回転します：

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

![テキストの回転](text_rotation.png)

## **縦書きテキストで数字を横並びで表示**

縦書きの日本語ラベルで 2 桁の数字を一緒に保持するには、両方の数字を 1 つのテキスト部分に入れ、その部分に対して [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) を呼び出します。例では [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) と 40 ポイントの MS Gothic を両ラベルに使用しています。数値部分に渡す [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) の値だけが異なります。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);
        
        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint では、左側のラベル（`True`）は数字が縦向きのまま 和 と 年 の間に横並びで表示されます。右側のラベル（`False`）では、数字のペアが時計回りに 90 度回転します。周囲の日本語文字は両ラベルで縦向きのままです。

![PowerPoint における縦書き日付ラベルの比較（左は数字が縦向きで横並び、右は数字が回転）](vertical_date.png)

## **テキストフレームのカスタム回転の設定**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) を使用して、[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) のカスタム回転角度を設定します。

以下のコード例は、シェイプ内でテキストフレームを時計回りに 3 度回転させます：

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

## **段落の行間設定**

Aspose.Slides は、段落間隔を制御するために [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) を提供します。これらのプロパティは次のように使用します：

* 正の値を使用すると、行間を行の高さのパーセンテージで指定します。
* 負の値を使用すると、行間をポイントで指定します。

以下の例は、最初の段落の行間を行の高さの 200%（二重行間）に設定します：

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

## **改行の制御**

段落の改行規則は、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで役立ちます。以下のメソッドは [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) に属し、段落全体に適用されます：

* [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) はラテン文字の改行規則を制御します。混在テキストでは、これを変更すると隣接する東アジア文字や句読点の折り返し位置も変わることがあります。
* [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) は東アジア文字の改行規則を制御し、行頭・行末の文字に関する制限を含みます。

これらの規則は、テキストフレーム内の自動折り返しを有効にする [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) の代替ではありません。折り返しが発生した際のレイアウトに影響しますが、改行文字を挿入するわけではありません。明示的な改行は、利用可能な幅に関係なく段落内に新しい行を強制します。

以下の自己完結型例は、中国語とラテン文字を含む狭いテキストブロックを作成します。両方の改行オプションを明示的に設定し、"line_breaking.pptx" に保存します。どちらかの規則を試すには、他の設定を固定したまま対応する値を変更します。例では 24 ポイントの Arial と SimSun を使用し、フレーム幅 160 ポイント、水平テキストフレーム余白 0 に設定しています。[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) は [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) で呼び出され、文字サイズとフレームサイズが固定されたままになります。

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

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) は、対象となる句読点が次の行に入る代わりにテキスト行の右端を超えてはみ出すことを許可します。段落全体に適用され、ハンギングインデントとは異なります。

以下の自己完結型例は、幅 100 ポイントのテキストフレームでハンギング句読点を有効にし、"hanging_punctuation.pptx" に保存します。24 ポイントの Arial と水平テキストフレーム余白 0 の設定で、最後の句点は "sentence" の後に残り、右端を超えてはみ出します。比較のためにプロパティを [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) に設定すると、句点が別行に配置されます。折り返しは有効で、オートフィットは無効にして利用可能幅を固定しています。

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

すべての句読点がハンギングできるわけではありません。上記の [フォントとレイアウト条件](#control-line-breaking) もこの比較に適用されます。フォント、利用可能幅、余白、オートフィット設定を変更すると目に見える違いがなくなることがあります。

## **テキストフレームのオートフィットタイプの設定**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小、はみ出し、またはシェイプを自動的にリサイズさせるかを制御できます。以下の例は、シェイプをテキストに合わせてリサイズするよう設定し、結果を "autofit_type.pptx" に保存します。

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

自動折り返し後の行数をカウントし、テキストやシェイプ幅の変更が結果に及ぼす影響を確認するには、[レンダリングされた行のカウント](/slides/ja/java/manage-paragraph/) を参照してください。行数だけではテキストがコンテナからはみ出しているかは判断できません。

## **テキストフレームのアンカー設定**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) は、テキストをシェイプ内で垂直方向に配置する方法（上部、中央、下部など）を定義します。以下の例は、最初のシェイプの底部にテキストをアンカーし、結果を "text_anchor.pptx" に保存します。

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

[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) と [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) を使用して、段落のタブ位置を設定します。以下の例は、デフォルトタブ間隔を 100 ポイントに設定し、30 ポイントに左寄せタブ位置を追加します。これらの設定はタブ文字を含むテキストに影響します。

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

![段落のタブ](paragraph_tabs.png)

## **校正言語の設定**

Aspose.Slides は [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックと文法チェックに使用される言語を決定します。

以下の例は、最初のスライドの最初のシェイプがテキストボックスである "presentation.pptx" と少なくとも 1 つの段落が必要です。最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、簡体字中国語の校正言語（`zh-CN`）を割り当てます。結果は "proofing_language.pptx" に保存されます：

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

### **言語メタデータのコピー**

テンプレートから多言語テキストをコピーする場合、[IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) と [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) の両方を保持してください。以下の自己完結型例は、ソース部分に米英語を言語、フランス語を代替言語として設定し、テキストと識別子を新しいプレゼンテーションの部分にコピーします。

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
        // ソースに代替言語がない場合、null は宛先の値をクリアします。
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

代替言語なしのソースを試すには、`"fr-FR"` の割り当てを省略します。その場合、代替識別子は `null` となり、同じコピー文はデフォルト値を導入せずにその欠如を保持します。たとえ宛先に以前代替言語が割り当てられていたとしても同様です。

これらの識別子は言語メタデータとして保存されます。これらを保持しても、PowerPoint がどの辞書をスペルチェックや文法チェックに使用するかは決まりません。

## **デフォルト言語の設定**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。以下の例は、米英語をデフォルトテキスト言語としてプレゼンテーションを作成し、テキストボックスを追加し、最初のテキスト部分の言語として `en-US` を出力します。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // テキスト付きの新しい長方形シェイプを追加します。
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

プレゼンテーションレベルでデフォルトのテキスト書式を適用するには、[IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) を使用します。

以下の例は、新しいプレゼンテーションのトップレベル段落のデフォルトとして 14 ポイントの太字フォントを設定し、"default_text_style.pptx" に保存します。テキストは、より具体的な書式が上書きしない限り、これらのデフォルトを継承できます。

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

## **全角大文字効果でテキストを抽出**

PowerPoint では、**All Caps** フォント効果を適用すると、元が小文字でもスライド上では大文字で表示されます。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは入力されたままのテキストを返します。表示されたテキストと合わせるには、[TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) を確認し、値が `All` の場合に返された文字列を大文字に変換します。

この例は、最初のスライドの最初のシェイプがテキストボックスである "sample2.pptx" が必要です。その最初の段落の最初の部分には、All Caps 効果が適用された "Hello, Aspose!" が含まれます（以下参照）。

![All Caps 効果](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します：

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

スライド上のテーブルのテキストを変更するには、[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) を使用します。セルを反復処理し、各セルを [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) で取得し、[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) を介して段落書式を更新します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するにはどうすればよいですか？**

テキストにグラデーションカラーを適用するには、[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) を使用します。[IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) を [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) に設定し、グラデーションストップ、方向、透明度を構成します。

関連機能: [スライド内のテキスト書式設定](/slides/ja/features/text-formatting/).
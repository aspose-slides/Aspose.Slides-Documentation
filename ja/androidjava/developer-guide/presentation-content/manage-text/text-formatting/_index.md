---
title: Android でプレゼンテーションテキストをフォーマット
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/androidjava/text-formatting/
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
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument プレゼンテーション内のテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Java を介した Android 用 Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーション内のテキストの書式設定方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィットの動作、テキストのアンカリング、タブストップ、言語設定について解説します。

特に記載がない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキスト ボックスで、その最初の段落に以下のテキストが含まれています。スライドおよびシェイプのインデックスは 0 から始まります。太字部分を選択する例は、継承された太字書式を含む実際の書式設定を使用します。

![サンプルテキスト](sample_text.png)

文字列や正規表現の一致を検索してハイライトする方法については、[Search and Replace Text](/slides/ja/androidjava/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定**

段落のデフォルトのハイライト色を設定するには [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用し、個々のテキスト部分のハイライト色を設定するには [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) を使用します。

次の例は、最初の段落のデフォルトハイライトとして薄いグレーを設定します。個々の部分に設定されたハイライト色はこのデフォルトより優先されます。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 段落全体のハイライト色を設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![グレイの段落](gray_paragraph.png)

以下のコード例は、**太字フォント** のテキスト部分の背景色を設定する方法を示します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // テキスト部分のハイライト色を設定します。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![グレイのテキスト部分](gray_text_portions.png)

## **段落のテキストを整列**

テキスト フレーム内の段落の配置を設定するには [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) を使用します。値は中央、左揃え、右揃え、両端揃えなどがあります。

次のコード例は段落を **中央** に揃える方法を示します。

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

![整列された段落](aligned_paragraph.png)

## **行内のフォントを整列**

異なるフォント サイズのテキスト部分を行内で垂直に整列させるには [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) を使用します。この設定は段落全体に適用され、各行内の整列を制御します。

次のセルフコンテインド例では、1 つのスライドに 4 つのラベル付きテキスト ボックスを作成します。各段落は 18、36、54 ポイントの同一テキストを含み、フォント整列が異なります。Arial を使用し、オートフィットと折り返しを無効にし、テキスト フレームは単一行が収まるように十分大きく保ちます。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![ベースライン、上端、中央、下端のフォント整列の比較（混在フォントサイズ）](font_alignment.png)

フォント整列はフォント メトリクスに基づくため、個々の文字の見た目の端が必ずしも正確に揃うわけではありません。例では大文字とディセンダーを含めてベースラインと下端整列の違いを示しています。フォントの可用性や代替、使用文字、フォント サイズの違いが結果に影響します。フレームのサイズ、余白、行間、折り返し、オートフィットもレイアウトに影響するため、モードを比較する際は同じフォントとレイアウト設定を使用してください。

この設定は、水平段落整列を制御する [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) や、シェイプ内でテキスト ブロックを垂直に配置する [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) とは異なります。上付き・下付きの書式は、[IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) がベースラインに対して個々の部分をシフトさせるため、段落の行に対するフォント整列とは別の挙動です。

## **テキストの透明度を設定**

テキストの透明度は、[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) に割り当てた色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 のスケールでの ARGB アルファチャンネル値であり、透明率パーセンテージではありません。

次のコード例は **段落全体** に透明度を適用する方法を示します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // テキストの塗りつぶし色を透明色に設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![透明な段落](transparent_paragraph.png)

次のコード例は **太字フォント** のテキスト部分に透明度を適用する方法を示します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
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

テキスト ボックス内の文字間隔を拡大または縮小するには [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) を使用します。例では 3 ポイントの間隔を追加しています。負の値を指定すると文字が詰まります。

次の Java コードは **段落全体** の文字間隔を拡大する方法を示します。

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

次のコード例は **太字フォント** のテキスト部分の文字間隔を拡大する方法を示します。

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

### **特定フォントのカーニングを無効化**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の表示よりやや詰まって見えることがあります。これは PowerPoint が特定フォントのカーニング データを無視するためです（フォントに有効なカーニング情報が含まれていても、PowerPoint 設定でカーニングが有効になっていても発生します）。

このようなケースで PowerPoint に近い出力にするには、該当フォントを使用しているテキスト部分のカーニングを無効にします。実際のフォント サイズより大きい値を [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) に設定します。この例では、最初のスライドの最初のシェイプがテキスト ボックスである "presentation.pptx" が必要です。継承されたフォントも含めた実効フォント名をチェックし、Roboto を使用している部分に対して 100 ポイントの閾値を設定します。これにより、フォント サイズが 100 ポイント未満の該当部分のカーニングが無効化されます。

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

閾値以下のテキストに対して、この設定はカーニングを抑制し、PowerPoint 固有の挙動で影響を受けるフォントの見た目を Aspose.Slides のレンダリングと合わせるのに役立ちます。

## **テキスト フォント プロパティを管理**

フォント プロパティは、段落レベルでは [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用し、個々の部分では [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/) を使用して設定できます。

次の例は、最初の段落のデフォルト フォントを 12 ポイントの Times New Roman に設定し、太字・斜体・点線下線を書式設定します。個々の部分に対する明示的な書式はこれらのデフォルトより優先されます。

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

![段落のフォント プロパティ](font_properties_for_paragraph.png)

次の例は、実効書式が太字である部分に対して 13 ポイント Times New Roman、斜体、点線下線を適用します。

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

![テキスト部分のフォント プロパティ](font_properties_for_text_portions.png)

## **テキストの回転を設定**

テキストの向きをシェイプ内で事前定義されたものに設定するには [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) を使用します。

次のコード例は、シェイプ内のテキスト向きを [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/) に設定し、テキストを **90 度左回転** させます。

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

## **テキスト フレームのカスタム回転を設定**

[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) のカスタム回転角度を設定するには [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) を使用します。

次のコード例は、シェイプ内のテキスト フレームを時計回りに 3 度回転させます。

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

Aspose.Slides は [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-)、[IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) を提供し、段落の行間を制御します。使用方法は次のとおりです。

* 正の値を指定すると、行間は行の高さのパーセンテージとして扱われます。  
* 負の値を指定すると、行間はポイントで指定されます。

次の例は、最初の段落の行間を行高さの 200%（二倍行間）に設定します。

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

段落の改行規則は、狭いテキスト ブロックやラテン文字とアジア文字が混在するプレゼンテーションで有用です。以下のメソッドは [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/) に属し、段落全体に適用されます。

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) はラテン文字の改行規則を制御します。混在テキストでは、これを変更すると隣接するアジア文字や句読点の折り返し位置も変わることがあります。  
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) はアジア文字の改行規則を制御し、行頭・行末の文字制限を含みます。

これらの規則は、テキスト フレーム内の自動折り返しを有効にする [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) に置き換わるものではありません。折り返しが発生したときのレイアウトに影響を与えますが、改行文字を挿入するわけではありません。明示的な改行は、利用可能な幅に関係なく段落内で新しい行を強制します。

次のセルフコンテインド例は、中国語とラテン文字を含む狭いテキスト ブロックを作成し、両方の改行オプションを明示的に設定して "line_breaking.pptx" として保存します。どちらかの規則を試したい場合は、もう一方の設定を固定したまま対応する値を変更してください。例では 24 ポイント Arial と SimSun、幅 160 ポイント、水平余白 0 のフレームを使用しています。[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) は [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) に設定し、テキストサイズとフレーム寸法を固定しています。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **行頭句読点の制御**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) を使用すると、対象の句読点がテキスト 行の右端を超えて表示され、次の行に占有されなくなります。段落全体に適用され、ハンギング インデントとは異なります。

次のセルフコンテインド例は、幅 100 ポイントのテキスト フレームでハンギング句読点を有効にし、"hanging_punctuation.pptx" として保存します。24 ポイント Arial、水平余白 0 の設定では、最後のピリオドが "sentence" の後に残り、右端を超えて表示されます。比較のためにプロパティを [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) に設定すると、ピリオドが別行に配置されます。折り返しは有効でオートフィットは無効にして、利用可能幅を固定しています。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

すべての句読点がハンギングできるわけではありません。上記の [フォントとレイアウト条件](#control-line-breaking) も比較時に適用されます。フォント、利用可能幅、余白、オートフィット設定を変更すると差異がなくなることがあります。

## **テキスト フレームのオートフィット タイプを設定**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストが縮小するか、はみ出すか、シェイプが自動的にサイズ変更されるかを制御できます。次の例はシェイプをテキストに合わせてリサイズし、結果を "autofit_type.pptx" として保存します。

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

自動折り返し後の行数を確認し、テキストやシェイプの幅が結果に与える影響を知りたい場合は、[Count Rendered Lines](/slides/ja/androidjava/manage-paragraph/) を参照してください。行数だけではテキストがコンテナからはみ出しているかどうかは判断できません。

## **テキスト フレームのアンカーを設定**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) は、シェイプ内でテキストを垂直方向に配置する方法（上部、中央、下部など）を定義します。次の例はテキストを最初のシェイプの下部にアンカーし、"text_anchor.pptx" として保存します。

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

段落内のタブストップを構成するには、[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) と [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) を使用します。次の例はデフォルトタブ幅を 100 ポイントに設定し、30 ポイント位置に左揃えタブを追加します。これらの設定はタブ文字を含むテキストに影響します。

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

## **校正言語を設定**

Aspose.Slides は [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックに使用される言語です。

次の例は "presentation.pptx"（最初のスライドの最初のシェイプがテキスト ボックスで、少なくとも 1 段落がある）を前提とし、最初の段落の内容を "1。" に置き換え、フォントを SimSun、校正言語を簡体字中国語 (`zh-CN`) に設定し、"proofing_language.pptx" として保存します。

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

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用すると、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義できます。次の例はデフォルトテキスト言語を米国英語に設定したプレゼンテーションを作成し、テキスト ボックスを追加して、最初のテキスト部分の言語コードとして `en-US` を出力します。

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

## **デフォルト テキスト スタイルを設定**

プレゼンテーション レベルでデフォルトのテキスト書式を適用するには、[IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) を使用します。

次の例は新規プレゼンテーションの上位レベル段落に対して 14 ポイントの太字フォントをデフォルトとして設定し、"default_text_style.pptx" として保存します。テキストは、より具体的な書式が上書きしない限り、これらのデフォルトを継承します。

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

## **All Caps 効果でテキストを抽出**

PowerPoint では **All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、元の文字列は小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、入力されたままの文字列が返されます。表示されるテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) を確認し、値が `All` のときに取得文字列を大文字に変換します。

この例は "sample2.pptx"（最初のスライドの最初のシェイプがテキスト ボックス）を前提とし、最初の段落の最初の部分に All Caps 効果が適用された "Hello, Aspose!" が含まれています（下図参照）。

![All Caps 効果](all_caps_effect.png)

次のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示します。

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

**スライド上の表のテキストを変更するにはどうすればよいですか？**

表のテキストを変更するには [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) を使用します。セルを走査し、[ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) で各セルのテキスト フレームを取得し、[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) で段落書式を更新します。

**PowerPoint スライド上のテキストにグラデーション カラーを適用するにはどうすればよいですか？**

グラデーション カラーを適用するには [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) を使用します。[IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) を [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成します。
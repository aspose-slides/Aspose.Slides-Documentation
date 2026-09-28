---
title: Android のプレゼンテーションテキストの書式設定
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/androidjava/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキスト背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java 経由で Android 用 Aspose.Slides を使用して、PowerPoint と OpenDocument のプレゼンテーション内のテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Java 経由で Android 用 Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットする方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカー設定、タブストップ、言語設定などをカバーします。

特に記載がない限り、例は [sample.pptx](sample.pptx) を使用します。最初のスライドの最初の図形はテキストボックスで、最初の段落に以下のテキストが含まれます。スライドおよび図形のインデックスは 0 から始まります。太字部分を選択する例は、継承された太字書式を含む実効書式を使用します。

![サンプルテキスト](sample_text.png)

リテラル文字列や正規表現の一致箇所を検索してハイライトする方法は、[Search and Replace Text](/slides/ja/androidjava/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定**

段落の既定ハイライト色を設定するには [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用し、個々のテキスト部分のハイライト色を設定するには [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) を使用します。

次の例は、最初の段落の既定ハイライトとして薄いグレーを設定します。個々の部分で明示的に設定されたハイライト色はこの既定より優先されます。

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

![グレイ段落](gray_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** の背景色を設定する方法を示します。

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

![グレイテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

テキスト フレーム内の段落配置を設定するには [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) を使用します。値は中央揃え、左揃え、右揃え、均等割付などが指定できます。

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

![揃えた段落](aligned_paragraph.png)

## **テキストの透明度を設定**

テキストの透明度は [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) に割り当てた色のアルファ成分で制御します。下の例では `alpha = 50` は 0〜255 のスケールの ARGB アルファ値であり、透明度のパーセンテージではありません。

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

![透明段落](transparent_paragraph.png)

次のコード例は **太字フォントのテキスト部分** に透明度を適用する方法を示します。

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

![透明テキスト部分](transparent_text_portions.png)

## **テキストの文字間隔を設定**

テキスト ボックス内の文字間隔を拡大または縮小するには [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) を使用します。例では 3 ポイントの間隔を追加しています。負の値は文字を縮めます。

次の Java コードは **段落全体** の文字間隔を拡大する方法を示します。

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

![段落の文字間隔](character_spacing_in_paragraph.png)

次のコード例は **太字フォントのテキスト部分** の文字間隔を拡大する方法を示します。

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

### **特定フォントのカーニングを無効化**

場合によっては、Aspose.Slides が生成したテキストが PowerPoint の表示より僅かに詰まって見えることがあります。これは PowerPoint が特定フォントのカーニング情報を無視するためです。

このようなケースでは、該当フォントを使用するテキスト部分のカーニングを無効にできます。[IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) に実際のフォントサイズより大きな値を設定します。以下の例は「presentation.pptx」の最初のスライドの最初の図形がテキストボックスであることを前提とし、実効フォント名（継承フォントを含む）をチェックし、Roboto を使用する部分のフォントサイズが 100 ポイント未満の場合にカーニングを無効にします。

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

この設定により、しきい値以下の該当テキストのカーニングが無効になり、PowerPoint 特有の挙動による表示差異を軽減できます。

## **テキストのフォントプロパティを管理**

フォントプロパティは段落レベルで [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用するか、個々の部分で [IPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportionformat/) を使用して設定できます。

次の例は最初の段落の既定フォントを 12 ポイントの Times New Roman に設定し、太字・斜体・点線下線を適用します。個々の部分で明示的に設定された書式はこれらの既定を上書きします。

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

次の例は、実効書式が太字である部分に対して 13 ポイントの Times New Roman、斜体、および点線下線を適用します。

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

## **テキストの回転を設定**

テキストの向きを事前定義された方向に設定するには [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) を使用します。

次のコード例はテキストの向きを [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textverticaltype/) に設定し、テキストを **90 度反時計回り** に回転させます。

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

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) を使用して、[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) のカスタム回転角度を設定できます。

次のコード例は図形内のテキストフレームを時計回りに 3 度回転させます。

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

Aspose.Slides は [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-)、[IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) を提供し、段落間隔を制御します。使用方法は次のとおりです。

* 正の値は行高さのパーセンテージで行間を指定します。
* 負の値はポイントで行間を指定します。

次の例は最初の段落の行間を行高さの 200%（2 倍行間）に設定します。

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

段落の改行規則は、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで便利です。以下のメソッドは [IParagraphFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/) に属し、段落全体に適用されます。

- [setLatinLineBreak](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) はラテン文字の改行規則を制御します。混在テキストでは、隣接する東アジア文字や句読点の折り返し位置にも影響します。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) は東アジア文字の改行規則を制御し、行頭・行末文字の制限を含みます。

これらの規則は自動折り返しを有効にする [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) の代替ではなく、折り返しが発生した際のレイアウトに影響します。改行文字を挿入するわけではありません。明示的な改行は、幅に関係なく段落内で新しい行を強制します。

次の自己完結型例は中国語とラテン文字を含む狭いテキストブロックを作成し、両方の改行オプションを明示的に設定して "line_breaking.pptx" として保存します。ルールを試すには、もう一方の設定を固定したまま対象の値を変更します。例では 24 ポイントの Arial と SimSun、フレーム幅 160 ポイント、水平マージン 0 を使用しています。[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) は [TextAutofitType.None](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textautofittype/) に設定し、テキストサイズとフレームサイズを固定しています。

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

## **句読点のハンギングを制御**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) を使用すると、対象の句読点がテキスト行の右端を超えて表示され、次の行に占有されません。段落全体に適用され、ハンギングインデントとは異なります。

次の自己完結型例は幅 100 ポイントのテキストフレームで句読点ハンギングを有効にし、"hanging_punctuation.pptx" として保存します。24 ポイントの Arial、水平マージン 0 の設定で、最終的な句点は "sentence" の後に残り、右端を超えて表示されます。比較のためにプロパティを [NullableBool.False](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/nullablebool/) に設定すると、句点が別行に配置されます。折り返しは有効、オートフィットは無効にして幅を固定しています。

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

すべての句読点がハンギングできるわけではありません。見た目はフォントの可用性やレイアウトに依存し、フォントや幅、マージン、オートフィット設定を変更すると差異がなくなることがあります。

## **テキスト フレームのオートフィット タイプを設定**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出させるか、またはシェイプを自動的にリサイズするかを制御できます。次の例はシェイプをテキストに合わせてリサイズし、結果を "autofit_type.pptx" として保存します。

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

自動折り返し後の行数を確認し、テキストやシェイプ幅の変化が結果に与える影響を把握するには、[Count Rendered Lines](/slides/ja/androidjava/manage-paragraph/) を参照してください。行数だけではテキストがコンテナからはみ出しているかどうかは判断できません。

## **テキスト フレームのアンカーを設定**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) は、テキストをシェイプ内で上下にどの位置に配置するか（上部、中央、下部など）を定義します。次の例はテキストを最初の図形の下部にアンカーし、結果を "text_anchor.pptx" として保存します。

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

段落のタブストップを構成するには [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) と [IParagraphFormat.getTabs](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) を使用します。次の例はデフォルトタブ間隔を 100 ポイントに設定し、30 ポイント位置に左揃えタブストップを追加します。これらの設定はタブ文字を含むテキストに影響します。

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

Aspose.Slides は [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックに使用される言語を決定します。

次の例は "presentation.pptx"（最初のスライドの最初の図形がテキストボックスで、少なくとも 1 つの段落があること）を前提とし、最初の段落を "1。" に置き換え、フォントを SimSun に設定し、簡体字中国語校正言語 (`zh-CN`) を割り当てます。結果は "proofing_language.pptx" に保存されます。

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

## **既定言語を設定**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用すると、プレゼンテーションの読み込みまたは作成時に作成されるテキストの既定言語を定義できます。次の例は既定テキスト言語を米国英語に設定したプレゼンテーションを作成し、テキストボックスを追加して最初のテキスト部分の言語コードとして `en-US` を出力します。

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

## **既定テキスト スタイルを設定**

プレゼンテーションレベルで既定のテキスト書式を適用するには [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) を使用します。

次の例は新規プレゼンテーションのトップレベル段落の既定フォントを 14 ポイントの太字に設定し、"default_text_style.pptx" として保存します。テキストはこれらの既定を継承しますが、より具体的な書式が上書きします。

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

## **すべて大文字効果でテキストを抽出**

PowerPoint では **All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、元のテキストは小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、入力時の文字列がそのまま返されます。表示と一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textcaptype/) を確認し、値が `All` の場合は取得文字列を大文字に変換します。

この例は "sample2.pptx"（最初のスライドの最初の図形がテキストボックス）を前提とし、最初の段落の最初の部分に All Caps 効果が適用された "Hello, Aspose!" が含まれています。

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

**スライド上のテーブルのテキストを変更するにはどうすればよいですか？**

テーブルのテキストを変更するには [ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itable/) を使用します。セルを走査し、各セルを [ICell.getTextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icell/#getTextFrame--) で取得し、段落書式を [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) で更新します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するにはどうすればよいですか？**

テキストにグラデーションカラーを適用するには [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) を使用します。[IFillFormat.setFillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) を [FillType.Gradient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成します。
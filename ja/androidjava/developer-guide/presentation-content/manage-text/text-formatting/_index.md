---
title: Android でプレゼンテーション テキストをフォーマットする
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
- フォント ファミリー
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- オートフィット プロパティ
- テキストフレーム アンカー
- テキスト タブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java 経由で Android 用 Aspose.Slides を使用して、PowerPoint および OpenDocument のプレゼンテーション内のテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Java 経由で Android 用 Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーションのテキスト書式設定方法を示します。背景色、透明度、文字間隔、フォント プロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブ ストップ、言語設定について説明します。

以下の例では、最初のスライドに単一のテキスト ボックスが含まれ、次のテキストが入っている「sample.pptx」というファイルを使用します。

![サンプルテキスト](sample_text.png)

リテラル テキストや正規表現の一致を検索してハイライトする方法については、[テキストの検索と置換](/slides/ja/androidjava/search-and-replace-text/) を参照してください。

## **テキストの背景色の設定**

段落のデフォルトのハイライト色を設定するには[IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用し、個々のテキスト部分のハイライト色を設定するには[IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) を使用します。

次のコード例は**段落全体**の背景色を設定する方法を示します：

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

結果：

![灰色の段落](gray_paragraph.png)

以下のコード例は**太字フォントのテキスト部分**の背景色を設定する方法を示します：

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

結果：

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

テキスト フレーム内の段落配置を設定するには[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) を使用します。値は中央揃え、左揃え、右揃え、両端揃えなどがあります。

次のコード例は段落を**中央**に揃える方法を示します：

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

![揃えられた段落](aligned_paragraph.png)

## **テキストの透明度の設定**

テキストの透明度は、[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) に割り当てられた色のアルファ成分で制御します。以下の例では、`alpha = 50` は 0–255 のスケールの ARGB アルファ値であり、透明度のパーセンテージではありません。

以下のコード例は**段落全体**に透明度を適用する方法を示します：

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // テキストの塗りつぶし色を透明に設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![透明な段落](transparent_paragraph.png)

以下のコード例は**太字フォントのテキスト部分**に透明度を適用する方法を示します：

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

結果：

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔の設定**

テキスト ボックス内の文字間隔を拡大または縮小するには[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) を使用します。

次の Java コードは**段落全体**の文字間隔を拡大する方法を示します：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注: 文字間隔を圧縮するには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 文字間隔を拡大します。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![段落の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は**太字フォントのテキスト部分**の文字間隔を拡大する方法を示します：

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
            portion.getPortionFormat().setSpacing(3); // 文字間隔を拡大します。
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

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の同じテキストよりやや詰まって見えることがあります。これは、PowerPoint が特定のフォントに対してカーニング データを無視するためで、フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっていても起こります。

このような場合に PowerPoint に近い出力にするには、影響を受けるフォントを使用するテキスト部分のカーニングを無効にできます。[IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) に実際のフォントサイズよりはるかに大きい値を設定します：

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

この設定により該当するテキスト部分にカーニングが適用されなくなり、PowerPoint 特有の動作の影響を受けるフォントの見た目を Aspose.Slides のレンダリングと合わせやすくなります。

## **テキストフォント プロパティの管理**

フォント プロパティは、[IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) を使用して段落レベルで設定するか、個々の部分は[IPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportionformat/) を使用して設定できます。

次のコードは段落全体のフォントとテキスト スタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman フォントを段落内のすべての部分に適用します。

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

![段落のフォント プロパティ](font_properties_for_paragraph.png)

以下のコード例は**太字フォントのテキスト部分**に同様のプロパティを適用します：

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

![テキスト部分のフォント プロパティ](font_properties_for_text_portions.png)

## **テキストの回転設定**

[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) を使用して、シェイプ内の事前定義されたテキストの向きを設定します。

次のコード例はシェイプ内のテキスト向きを[TextVerticalType.Vertical270](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textverticaltype/) に設定し、テキストを**90 度反時計回り**に回転させます：

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

![テキストの回転](text_rotation.png)

## **テキスト フレームのカスタム回転設定**

[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) を使用して、[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) のカスタム回転角度を設定します。

以下のコード例はシェイプ内でテキスト フレームを時計回りに 3 度回転させます：

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

Aspose.Slides は[IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-)、および[IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) を提供し、段落の間隔を制御します。これらのプロパティは次のように使用します：

* 正の値を使用すると、行間を行の高さのパーセンテージで指定します。
* 負の値を使用すると、行間をポイントで指定します。

以下のコード例は段落内の行間を指定する方法を示します：

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

![段落内の行間](line_spacing.png)

## **テキスト フレームのオートフィット タイプ設定**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストが縮小するか、はみ出すか、シェイプが自動的にサイズ変更されるかを制御できます。

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

自動折り返し後の行数を数え、テキストまたはシェイプの幅が結果にどのように影響するかを確認するには、[レンダリングされた行のカウント](/slides/ja/androidjava/manage-paragraph/) を参照してください。行数だけではテキストがコンテナからはみ出しているかどうかは判断できません。

## **テキスト フレームのアンカー設定**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) は、シェイプ内でテキストが垂直方向にどの位置に配置されるか（上部、中央、下部など）を定義します。

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

段落のタブ ストップを設定するには[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) と[IParagraphFormat.getTabs](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) を使用します。

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

Aspose.Slides は[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint でのスペルチェックや文法チェックに使用される言語を決定します。

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

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。

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

## **デフォルトテキスト スタイルの設定**

プレゼンテーションレベルでデフォルトのテキスト書式設定を適用するには[IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) を使用します。

次のコード例は新しいプレゼンテーションのすべてのスライドで、デフォルトの太字フォントを 14 pt に設定する方法を示します。

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

PowerPoint では、**All Caps** フォント効果を適用すると、元が小文字でもスライド上では大文字で表示されます。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは入力時のテキストをそのまま返します。表示されたテキストに合わせるには、値が[TextCapType.All](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textcaptype/) の場合に返された文字列を大文字に変換します。

sample2.pptx の最初のスライドに次のテキスト ボックスがあるとします。

![All Caps 効果](all_caps_effect.png)

以下のコード例は**All Caps** 効果が適用されたテキストを抽出する方法を示します：

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

**スライド上のテーブルのテキストを変更するには？**

スライド上のテーブルのテキストを変更するには[ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itable/) を使用します。セルを反復処理し、各セルを[ICell.getTextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icell/#getTextFrame--)で取得してテキスト フレームを取得し、[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--)で段落書式を更新します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するには？**

テキストにグラデーション カラーを適用するには[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) を使用します。[IFillFormat.setFillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) に[FillType.Gradient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) を設定し、グラデーション ストップ、方向、透明度を構成します。
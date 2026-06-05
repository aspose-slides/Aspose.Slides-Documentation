---
title: Android でのプレゼンテーションからの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/androidjava/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからのテキスト抽出
- プレゼンテーションからのテキスト抽出
- PowerPoint からのテキスト抽出
- OpenDocument からのテキスト抽出
- PPT からのテキスト抽出
- PPTX からのテキスト抽出
- ODP からのテキスト抽出
- テキスト取得
- スライドからのテキスト取得
- プレゼンテーションからのテキスト取得
- PowerPoint からのテキスト取得
- OpenDocument からのテキスト取得
- PPT からのテキスト取得
- PPTX からのテキスト取得
- ODP からのテキスト取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを素早く抽出できます。シンプルなステップバイステップ ガイドに従って、時間を節約しましょう。"
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的でありながら重要なタスクです。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument プレゼンテーション（ODP）を扱う場合でも、テキスト データへのアクセスと取得は、分析、 自動化、インデックス作成、コンテンツ移行などの目的で重要になることがあります。

本記事では、Aspose.Slides for Android via Java を使用して、PPT、PPTX、ODP といったさまざまなプレゼンテーション形式からテキストを効率的に抽出する方法を包括的に解説します。 プレゼンテーション要素を体系的に走査し、必要なテキスト コンテンツを正確に取得する手順を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for Android via Java は、[SlideUtil](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/) クラスを提供します。このクラスは、プレゼンテーションまたはスライド全体からテキストを抽出するための複数のオーバーロードされた静的メソッドを公開しています。 プレゼンテーション内のスライドからテキストを抽出するには、[getAllTextBoxes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) メソッドを使用します。このメソッドは、[IBaseSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseslide/) 型のオブジェクトをパラメーターとして受け取ります。 実行すると、メソッドはスライド全体を走査してテキストを検索し、[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキストの書式情報を保持します。

以下のコード スニペットは、プレゼンテーションの最初のスライドからすべてのテキストを抽出します。

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **プレゼンテーション全体からテキストを抽出する**

プレゼンテーション全体のテキストを走査するには、[SlideUtil](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/) クラスが提供する [getAllTextFrames](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) 静的メソッドを使用します。このメソッドは 2 つのパラメーターを受け取ります。

1. 最初のパラメーターは、テキストを抽出する対象となる PowerPoint または OpenDocument プレゼンテーションを表す [IPresentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/) オブジェクトです。
2. 2 番目のパラメーターは、プレゼンテーションのマスタースライドも走査対象に含めるかどうかを示す `boolean` 値です。

このメソッドは、[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキストの書式情報も含みます。以下のコードは、プレゼンテーション（マスタースライドを含む）からテキストと書式情報を走査します。

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **カテゴリ別・高速テキスト抽出**

[PresentationFactory](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出するメソッドを提供します。

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

`TextExtractionArrangingMode` 列挙体の引数は、テキスト抽出結果の整理方法を示し、次の値に設定できます。
- `Unarranged` - スライド上の位置を考慮せずに取得した生テキスト。
- `Arranged` - スライド上の順序と同じ順序でテキストが配置されたもの。

速度が重要な場合は、`Unarranged` モードを使用すると `Arranged` モードよりも高速に処理できます。

[IPresentationText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentationtext/) は、プレゼンテーションから抽出された生テキストを表します。その `getSlidesText` メソッドは、[ISlideText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidetext/) 型のオブジェクト配列を返します。各オブジェクトは対応するスライドのテキストを表します。`ISlideText` 型のオブジェクトには次のメソッドがあります。

- `getText` - スライド上のシェイプに含まれるテキスト。
- `getMasterText` - 当該スライドに関連付けられたマスタースライドのシェイプに含まれるテキスト。
- `getLayoutText` - 当該スライドに関連付けられたレイアウトスライドのシェイプに含まれるテキスト。
- `getNotesText` - 当該スライドのノートスライドのシェイプに含まれるテキスト。
- `getCommentsText` - 当該スライドに付随するコメントに含まれるテキスト。

```java
String presentationPath = "presentation.pptx";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **FAQ**

**Aspose.Slides は大規模なプレゼンテーションをテキスト抽出時にどれくらい高速に処理できますか？**

Aspose.Slides は高パフォーマンスに最適化されており、[大規模なプレゼンテーション](/slides/ja/androidjava/open-presentation/) でもリアルタイムやバルク処理シナリオに適した速度で処理できます。

**Aspose.Slides はプレゼンテーション内の表やグラフからテキストを抽出できますか？**

はい。Aspose.Slides はテーブルやチャート関連オブジェクトを含む多数のスライド要素からテキストを抽出できるため、一般的なプレゼンテーション
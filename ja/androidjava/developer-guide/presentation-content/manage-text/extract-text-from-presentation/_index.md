---
title: Android でのプレゼンテーションからの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/androidjava/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからテキスト抽出
- プレゼンテーションからテキスト抽出
- PowerPoint からテキスト抽出
- OpenDocument からテキスト抽出
- PPT からテキスト抽出
- PPTX からテキスト抽出
- ODP からテキスト抽出
- テキスト取得
- スライドからテキスト取得
- プレゼンテーションからテキスト取得
- PowerPoint からテキスト取得
- OpenDocument からテキスト取得
- PPT からテキスト取得
- PPTX からテキスト取得
- ODP からテキスト取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Java で Aspose.Slides を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを素早く抽出します。シンプルなステップバイステップガイドに従って、時間を節約しましょう。"
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的でありながら重要な作業です。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument プレゼンテーション（ODP）を扱う場合でも、テキストデータへのアクセスと取得は、分析、Automation、インデックス作成、コンテンツ移行などの目的で重要になることがあります。

本記事では、Aspose.Slides for Android via Java を使用して、PPT、PPTX、ODP などのさまざまなプレゼンテーション形式からテキストを効率的に抽出する方法を包括的に解説します。プレゼンテーション要素を体系的に反復処理し、必要なテキストコンテンツを正確に取得する手順を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for Android via Java は [SlideUtil](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/) クラスを提供します。このクラスには、プレゼンテーションまたはスライドからすべてのテキストを抽出するためのオーバーロードされた静的メソッドが多数用意されています。プレゼンテーション内のスライドからテキストを抽出するには、[getAllTextBoxes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) メソッドを使用します。このメソッドは [IBaseSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseslide/) 型のオブジェクトをパラメータとして受け取ります。実行されると、メソッドはスライド全体を走査してテキストを検出し、[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキスト書式情報を保持します。

以下のコードスニペットは、プレゼンテーションの最初のスライドからすべてのテキストを抽出します。

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

## **プレゼンテーションからテキストを抽出する**

プレゼンテーション全体のテキストをスキャンするには、[SlideUtil](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/) クラスが提供する静的メソッド [getAllTextFrames](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) を使用します。このメソッドは 2 つのパラメータを受け取ります。

1. 最初のパラメータは、テキストを抽出する対象となる PowerPoint または OpenDocument プレゼンテーションを表す [IPresentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/) オブジェクトです。  
1. 2 番目のパラメータは、プレゼンテーションのマスタースライドもテキスト走査の対象に含めるかどうかを示す `boolean` 値です。

このメソッドは、テキスト書式情報を含む [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) 型のオブジェクト配列を返します。以下のコードは、マスタースライドを含むプレゼンテーション全体のテキストと書式情報を走査します。

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

## **カテゴリ別かつ高速なテキスト抽出**

[PresentationFactory](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出するためのメソッドを提供します。

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textextractionarrangingmode/) 列挙体の引数は、テキスト抽出結果の配置モードを示し、次の値に設定できます：
- `Unarranged` - スライド上の位置を考慮しない生テキスト。  
- `Arranged` - スライド上の順序と同じ順序でテキストが配置されます。

速度が重要な場合は `Unarr
---
title: Java におけるプレゼンテーションの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/java/extract-text-from-presentation/
keywords:
- テキストを抽出
- スライドからテキストを抽出
- プレゼンテーションからテキストを抽出
- PowerPoint からテキストを抽出
- OpenDocument からテキストを抽出
- PPT からテキストを抽出
- PPTX からテキストを抽出
- ODP からテキストを抽出
- テキストを取得
- スライドからテキストを取得
- プレゼンテーションからテキストを取得
- PowerPoint からテキストを取得
- OpenDocument からテキストを取得
- PPT からテキストを取得
- PPTX からテキストを取得
- ODP からテキストを取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: Aspose.Slides for Java を使用して、PowerPoint と OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルで段階的なガイドに従って、時間を節約しましょう。
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的でありながら重要な作業です。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument の ODP 形式のファイルを扱う場合でも、テキスト データへのアクセスと取得は、分析、Automation、インデックス作成、コンテンツ移行などの目的で重要になることがあります。

本記事では、Aspose.Slides for Java を使用して PPT、PPTX、ODP の各プレゼンテーション形式からテキストを効率的に抽出する包括的な手順を紹介します。プレゼンテーション要素を体系的に反復処理し、必要なテキスト コンテンツを正確に取得する方法を学べます。

## **スライドからテキストを抽出する方法**

Aspose.Slides for Java は [SlideUtil](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideutil/) クラスを提供します。このクラスは、プレゼンテーションまたはスライドからすべてのテキストを抽出するためのオーバーロードされた static メソッドを多数公開しています。プレゼンテーション内のスライドからテキストを抽出するには、[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) メソッドを使用します。このメソッドは [IBaseSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/) 型のオブジェクトをパラメータとして受け取ります。実行されると、メソッドはスライド全体を走査してテキストを検索し、[ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキストの書式情報を保持します。

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

## **プレゼンテーション全体からテキストを抽出する方法**

プレゼンテーション全体のテキストを走査するには、[SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) static メソッドを使用します。このメソッドは [SlideUtil](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideutil/) クラスによって公開されています。2 つのパラメータを受け取ります。

1. 最初に、テキストを抽出する対象となる PowerPoint または OpenDocument プレゼンテーションを表す [IPresentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/) オブジェクト。
2. 次に、プレゼンテーションのテキスト走査時にマスタースライドも含めるかどうかを示す `boolean` 値。

このメソッドは [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキストの書式情報も含みます。以下のコードは、マスタースライドを含めてプレゼンテーションのテキストと書式情報を走査します。

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

[PresentationFactory](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出するメソッドを提供します。

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textextractionarrangingmode/) 列挙体引数は、テキスト抽出結果の整理モードを示し、以下の値に設定できます。

- `Unarranged` - スライド上の位置を考慮しない生テキスト。
- `Arranged` - スライド上の順序と同じ順序でテキストが整理されます。

速度が重要な場合は、`Unarranged` モードを使用できます。こちらの方が `Arranged` モードより高速です。

[IPresentationText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentationtext/) は、プレゼンテーションから抽出された生テキストを表します。その `getSlidesText` メソッドは [ISlideText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidetext/) 型のオブジェクト配列を返します。各オブジェクトは対応するスライド上のテキストを表します。[ISlideText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidetext/) 型のオブジェクトは次のメソッドを提供します。

- `getText` - スライド内のシェイプに含まれるテキスト。
- `getMasterText` - 当該スライドに関連付けられたマスタースライドのシェイプに含まれるテキスト。
- `getLayoutText` - 当該スライドに関連付けられたレイアウトスライドのシェイプに含まれるテキスト。
- `getNotesText` - 当該スライドに関連付けられたノートスライドのシェイプに含まれるテキスト。
- `getCommentsText` - 当該スライドに関連付けられたコメントに含まれるテキスト。

{{67149bd5-20e6-4
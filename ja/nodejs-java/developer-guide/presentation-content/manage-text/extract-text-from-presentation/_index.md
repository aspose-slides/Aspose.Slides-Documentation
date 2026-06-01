---
title: JavaScript でのプレゼンテーションからの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/nodejs-java/extract-text-from-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルなステップバイステップ ガイドに従って、時間を節約しましょう。"
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライド コンテンツを扱う開発者にとって一般的かつ重要な作業です。Microsoft PowerPoint の PPT または PPTX ファイル、あるいは OpenDocument プレゼンテーション (ODP) を扱う場合でも、テキスト データへのアクセスと取得は、分析、Automation、インデックス作成、コンテンツ移行などにおいて重要です。

本記事では、Aspose.Slides for Node.js via Java を使用して、PPT、PPTX、ODP などのさまざまなプレゼンテーション形式からテキストを効率的に抽出する総合的な手順を解説します。プレゼンテーション要素を体系的に走査し、必要なテキスト コンテンツを正確に取得する方法を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for Node.js via Java は [SlideUtil](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideutil/) クラスを提供します。このクラスは、プレゼンテーションまたはスライドからすべてのテキストを抽出するためのオーバーロードされた静的メソッドを多数公開しています。プレゼンテーション内のスライドからテキストを抽出するには、[getAllTextBoxes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) メソッドを使用します。このメソッドはスライド オブジェクトをパラメータとして受け取り、実行時にスライド全体を走査してテキストを検出し、テキスト フォーマットを保持したまま [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) オブジェクトの配列を返します。

以下のコード スニペットは、プレゼンテーションの最初のスライドからすべてのテキストを抽出します。

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **プレゼンテーション全体からテキストを抽出する**

プレゼンテーション全体のテキストを走査するには、[SlideUtil](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideutil/) クラスが提供する [getAllTextFrames](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) 静的メソッドを使用します。このメソッドは 2 つのパラメータを受け取ります。

1. 最初に、テキストを抽出する対象となる PowerPoint または OpenDocument プレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) オブジェクト。
2. 次に、プレゼンテーションのテキスト走査時にマスタースライドを含めるかどうかを示す `
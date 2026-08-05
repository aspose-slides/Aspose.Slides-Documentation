---
title: JavaScriptでプレゼンテーションから数式をエクスポート
linktitle: 数式をエクスポート
type: docs
weight: 30
url: /ja/nodejs-java/exporting-math-equations/
keywords:
- 数式のエクスポート
- 数式をLaTeXにエクスポート
- PowerPointからLaTeXへ
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint プレゼンテーションから数式を LaTeX または MathML に直接、Node.js 用 Aspose.Slides を使用して Java を介してエクスポートします。"
---
## **導入**

Aspose.Slidesはプレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーションのスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="primary" %}} 

数式をLaTeXまたはMathMLに直接エクスポートできます。MathMLはウェブや多くのアプリケーションで使用される一般的な数式コンテンツ標準です。

{{% /alert %}}

## **数式をLaTeXにエクスポート**

Aspose.SlidesはPowerPointの数式を直接LaTeXに変換できます。中間のMathMLファイルや外部コンバータは不要です。数式はテキストフレーム内に[MathPortion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathportion/)として保存されます。[MathPortion.getMathParagraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) を使用して[MathParagraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathparagraph/) を取得し、次に[MathParagraph.toLatex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathparagraph/#toLatex--) を呼び出します。このメソッドは文字列を返し、保存、表示、別のアプリケーションへの送信、またはさらに処理できます。

次の例は、すべてのスライドのすべてのテキストフレームを調べ、すべての数式部分を見つけ、各数式を個別の `.tex` ファイルに書き出します:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) はスライド上で見つかったすべてのテキストフレームを返します。[MathPortion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathportion/) の型チェックにより、通常のテキストや画像から本物の編集可能な数式を区別します。

LaTeXエンジンやドキュメントテンプレートはすべて同じコマンド、パッケージ、Unicode文字をサポートしているわけではありません。アプリケーションで使用しているLaTeXエンジンで返された文字列をテストしてください。シンボルやOffice Math要素に適切な表現が環境にない場合、返された文字列内でプロジェクト固有のコマンドに置き換えるか、数式をスキップして問題を記録し、後でレビューできるようにしてください。

## **数式をMathMLとして保存**

人間はLaTeXのような一部の数式形式のコードは簡単に書けますが、MathMLのコードは書きにくいです。後者はアプリで自動生成されることを想定しているためです。プログラムはXMLで記述されたMathMLを容易に読み取り、解析できるため、多くの分野で出力や印刷形式として一般的に使用されています。

このサンプルコードは、プレゼンテーションから数式をMathMLにエクスポートする方法を示します:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**MathMLにエクスポートされるものは、段落全体ですか、それとも個々の数式ブロックですか？**

全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathparagraph/)）または個別のブロック（[MathBlock](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathblock/)）のどちらでもMathMLにエクスポートできます。両方の型はMathMLへの書き出しメソッドを提供しています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることをどのように判断できますか？**

数式は[MathPortion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathportion/)に存在し、[MathParagraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathparagraph/) を持ちます。[MathParagraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathparagraph/) を持たない画像や通常のテキスト部分はエクスポート可能な数式ではありません。

**プレゼンテーションのMathMLはどこから来るのですか—PowerPoint固有ですか、標準ですか？**

エクスポートは標準のMathML（XML）を対象としています。AsposeはPresentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、これは多くのアプリケーションやウェブで広く利用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトが[MathParagraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathparagraph/) を含むテキスト部分（すなわち本物のPowerPoint数式）を持っている場合、エクスポートされます。数式が画像として埋め込まれている場合は対象外です。

**MathMLへのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathMLの書き出しは数式の内容をシリアライズするだけで、プレゼンテーションファイルを変更することはありません。
---
title: 数式のエクスポート
type: docs
weight: 30
url: /ja/nodejs-java/exporting-math-equations/
---

## **プレゼンテーションから数式をエクスポートする**

Aspose.Slides for Node.js via Java を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーションのスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="primary" %}} 
数式を MathML にエクスポートできます。MathML は、Web や多くのアプリケーションで見られる数式や類似コンテンツのための一般的なフォーマットまたは標準です。 
{{% /alert %}}

人間は LaTeX のような一部の数式フォーマットのコードは簡単に書けますが、MathML のコードは書くのが難しいです。MathML はアプリによって自動的に生成されることを想定しているためです。MathML のコードは XML 形式なので、プログラムは簡単に読み取り・解析できます。そのため、MathML は多くの分野で出力や印刷フォーマットとして一般的に使用されています。 

このサンプルコードは、プレゼンテーションから数式を MathML にエクスポートする方法を示しています:
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


## **よくある質問**

**MathML にエクスポートされるのは、段落全体ですか、それとも個々の数式ブロックですか？**

MathML へは、全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)）または個々のブロック（[MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/)）のいずれかをエクスポートできます。両方のタイプは MathML に書き出すメソッドを提供しています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であるかどうかは、どのように判断できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) を持ちます。[MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) を持たない画像や通常のテキスト部分は、エクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか——PowerPoint 固有ですか、それとも標準ですか？**

エクスポートは標準の MathML（XML）を対象としています。Aspose は Presentation MathML——標準のプレゼンテーションサブセット——を使用しており、アプリケーションや Web 全体で広く利用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトが [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) を含むテキスト部分を持っている場合（すなわち、実際の PowerPoint 数式）、エクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーション ファイルは変更されません。
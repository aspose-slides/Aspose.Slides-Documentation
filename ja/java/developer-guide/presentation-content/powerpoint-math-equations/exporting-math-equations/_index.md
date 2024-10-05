---
title: 数学方程式のエクスポート
type: docs
weight: 30
url: /java/exporting-math-equations/

---

## プレゼンテーションからの数学方程式のエクスポート

Aspose.Slides for Javaを使用すると、プレゼンテーションから数学方程式をエクスポートできます。たとえば、スライド上の数学方程式（特定のプレゼンテーションから）を抽出して、別のプログラムやプラットフォームで使用する必要があるかもしれません。

{{% alert color="primary" %}} 

方程式をMathML形式にエクスポートすることができます。MathMLは、ウェブや多くのアプリケーションで見られる数学方程式や類似のコンテンツのための一般的な形式または標準です。

{{% /alert %}}

人間はLaTeXのような一部の方程式形式のコードを書くのは簡単ですが、MathMLのコードを書くのは困難です。なぜなら、MathMLはアプリによって自動的に生成されることを目的としているからです。プログラムはMathMLを簡単に読み取り、解析できます。なぜなら、そのコードはXML形式だからです。そのため、MathMLは多くの分野で出力および印刷形式として一般的に使用されています。

以下のサンプルコードは、プレゼンテーションからMathMLに数学方程式をエクスポートする方法を示しています：

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
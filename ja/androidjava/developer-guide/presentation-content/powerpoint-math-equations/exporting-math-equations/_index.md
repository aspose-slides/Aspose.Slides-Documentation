---
title: 数学方程式のエクスポート
type: docs
weight: 30
url: /androidjava/exporting-math-equations/

---

## プレゼンテーションからの数学方程式のエクスポート

Aspose.Slides for Android via Javaを使用すると、プレゼンテーションから数学方程式をエクスポートできます。たとえば、特定のプレゼンテーションのスライドにある数学方程式を抽出し、別のプログラムやプラットフォームで使用する必要があるかもしれません。

{{% alert color="primary" %}} 

方程式をMathMLにエクスポートすることができます。MathMLは、ウェブや多くのアプリケーションで見られる数学方程式や類似のコンテンツのための一般的な形式または標準です。

{{% /alert %}}

人間はLaTeXのような一部の方程式形式のコードを書くことは簡単ですが、MathMLのコードを書くことは難しいです。なぜなら、後者はアプリによって自動的に生成されることを意図しているからです。プログラムはMathMLを簡単に読み取り、解析できるため、そのコードはXMLで記述されており、MathMLは多くの分野で一般的に出力および印刷形式として使用されます。

このサンプルコードは、プレゼンテーションからMathMLに数学方程式をエクスポートする方法を示しています:

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
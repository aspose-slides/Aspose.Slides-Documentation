---
title: 数学方程式のエクスポート
type: docs
weight: 30
url: /php-java/exporting-math-equations/

---

## プレゼンテーションからの数学方程式のエクスポート

Aspose.Slides for PHP via Javaを使用すると、プレゼンテーションから数学方程式をエクスポートできます。たとえば、特定のプレゼンテーションのスライドにある数学方程式を抽出し、別のプログラムやプラットフォームで使用する必要があるかもしれません。

{{% alert color="primary" %}} 

方程式をMathMLにエクスポートできます。MathMLは、ウェブや多くのアプリケーションで見られる数学方程式や同様のコンテンツのための一般的な形式または標準です。

{{% /alert %}}

人間はLaTeXのような一部の方程式形式のコードを書くのは簡単ですが、MathMLのコードを書くのは難しいです。なぜなら、後者はアプリによって自動的に生成されることを意図しているからです。プログラムはMathMLをXML形式で簡単に読み取り、解析できるため、MathMLは多くの分野で出力および印刷形式として一般的に使用されています。

このサンプルコードは、プレゼンテーションからMathMLに数学方程式をエクスポートする方法を示しています：

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
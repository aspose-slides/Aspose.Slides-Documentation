---
title: 在 PHP 中從簡報匯出數學方程式
linktitle: 匯出方程式
type: docs
weight: 30
url: /zh-hant/php-java/exporting-math-equations/
keywords:
- 匯出數學方程式
- MathML
- LaTeX
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，輕鬆將 PowerPoint 中的數學方程式匯出為 MathML——保留格式並提升相容性。"
---
## **簡介**

Aspose.Slides for PHP via Java 允許您從簡報中匯出數學方程式。例如，您可能需要從投影片（特定簡報）中提取數學方程式，並在其他程式或平台中使用它們。

{{% alert color="primary" %}} 
您可以將方程式匯出為 MathML，這是一種在 Web 以及許多應用程式中常見的數學方程式與類似內容的流行格式或標準。 
{{% /alert %}}

## **將數學方程式儲存為 MathML**

雖然人類能輕易為 LaTeX 等某些方程式格式撰寫程式碼，但對於 MathML 則較為困難，因為它應由應用程式自動產生。程式能輕鬆讀取和解析 MathML，因為其程式碼採用 XML，所以 MathML 常被用作許多領域的輸出與列印格式。

以下範例程式碼示範如何將簡報中的數學方程式匯出為 MathML：

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

## **常見問題**

**究竟匯出到 MathML 的是段落還是單獨的公式區塊？**

您可以將整段數學段落（[MathParagraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mathparagraph/)）或單獨的區塊（[MathBlock](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mathblock/)）匯出為 MathML。兩種型別皆提供寫入 MathML 的方法。

**如何判斷投影片上的物件是數學公式而非普通文字或圖像？**

公式位於 [MathPortion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mathportion/) 中，並且擁有 [MathParagraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/mathparagraph/)。沒有 [MathParagraph] 的影像和普通文字區段不屬於可匯出的公式。

**簡報中的 MathML 來源為何——是 PowerPoint 專屬還是標準？**

匯出目標為標準的 MathML（XML）。Aspose 使用 Presentation MathML——該標準的簡報子集，廣泛應用於各種應用程式與 Web。

**是否支援匯出位於表格、SmartArt、群組等內的公式？**

是的，只要這些物件的文字區段包含 [MathParagraph]（即真正的 PowerPoint 公式），就會被匯出。若公式以影像形式嵌入，則不會匯出。

**匯出為 MathML 會修改原始簡報嗎？**

不會。寫入 MathML 僅是將公式內容序列化，並不會更改簡報檔案。
---
title: Экспорт математических уравнений
type: docs
weight: 30
url: /ru/php-java/exporting-math-equations/

---

## Экспорт математических уравнений из презентаций

Aspose.Slides для PHP через Java позволяет экспортировать математические уравнения из презентаций. Например, вам может понадобиться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе.

{{% alert color="primary" %}} 

Вы можете экспортировать уравнения в MathML, популярный формат или стандарт для математических уравнений и аналогичного контента, который встречается в интернете и во многих приложениях. 

{{% /alert %}}

Хотя люди легко пишут код для некоторых форматов уравнений, таких как LaTeX, им сложно написать код для MathML, потому что последний предназначен для автоматической генерации приложениями. Программы легко читают и парсят MathML, так как его код находится в формате XML, поэтому MathML часто используется в качестве формата вывода и печати в многих областях. 

Этот образец кода показывает, как экспортировать математическое уравнение из презентации в MathML:

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
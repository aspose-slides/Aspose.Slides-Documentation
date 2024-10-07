---
title: Exportieren von mathematischen Gleichungen
type: docs
weight: 30
url: /php-java/exporting-math-equations/

---

## Exportieren von mathematischen Gleichungen aus Präsentationen

Aspose.Slides für PHP über Java ermöglicht es Ihnen, mathematische Gleichungen aus Präsentationen zu exportieren. Zum Beispiel müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="primary" %}} 

Sie können Gleichungen in MathML exportieren, einem beliebten Format oder Standard für mathematische Gleichungen und ähnlichen Inhalt, der im Web und in vielen Anwendungen zu sehen ist. 

{{% /alert %}}

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben, fällt es ihnen schwer, den Code für MathML zu schreiben, da letzteres dafür gedacht ist, automatisch von Anwendungen generiert zu werden. Programme lesen und analysieren MathML leicht, da sein Code im XML-Format vorliegt, weshalb MathML häufig als Ausgab- und Druckformat in vielen Bereichen verwendet wird. 

Dieser Beispielcode zeigt Ihnen, wie Sie eine mathematische Gleichung von einer Präsentation in MathML exportieren:

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
---
title: Mathegleichungen aus Präsentationen in PHP exportieren
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/php-java/exporting-math-equations/
keywords:
- Mathegleichungen exportieren
- MathML
- LaTeX
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Ermöglichen Sie den nahtlosen Export von mathematischen Gleichungen aus PowerPoint nach MathML mit Aspose.Slides für PHP über Java – erhalten Sie die Formatierung und erhöhen Sie die Kompatibilität."
---

## **Mathegleichungen aus Präsentationen exportieren**

Aspose.Slides für PHP über Java ermöglicht das Exportieren von mathematischen Gleichungen aus Präsentationen. Zum Beispiel müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="primary" %}} 
Sie können Gleichungen nach MathML exportieren, einem verbreiteten Format bzw. Standard für mathematische Gleichungen und ähnliche Inhalte, die im Web und in vielen Anwendungen zu finden sind. 
{{% /alert %}}

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, haben sie Schwierigkeiten, den Code für MathML zu schreiben, da Letzteres von Anwendungen automatisch generiert werden soll. Programme lesen und analysieren MathML problemlos, weil dessen Code in XML vorliegt, sodass MathML in vielen Bereichen häufig als Ausgabe‑ und Druckformat verwendet wird. 

Dieser Beispielcode zeigt, wie Sie eine mathematische Gleichung aus einer Präsentation nach MathML exportieren:
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


## **FAQ**

**Was genau wird nach MathML exportiert – ein Absatz oder ein einzelner Formelblock?**

Sie können entweder einen gesamten Mathematik‑Absatz ([MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode, um nach MathML zu schreiben.

**Wie erkenne ich, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**

Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) und besitzt ein [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). Bilder und reguläre Textabschnitte ohne ein [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) können nicht als Formeln exportiert werden.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export richtet sich nach dem standardisierten MathML (XML). Aspose verwendet Presentation MathML – das präsentationsbezogene Subset des Standards –, das in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textabschnitte mit einem [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) enthalten (d. h. echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie ändert die Präsentationsdatei nicht.
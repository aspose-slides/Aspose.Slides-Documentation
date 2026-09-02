---
title: Mathematische Gleichungen aus Präsentationen in PHP exportieren
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/php-java/exporting-math-equations/
keywords:
- Mathematische Gleichungen exportieren
- Gleichungen nach LaTeX exportieren
- PowerPoint nach LaTeX
- MathML
- LaTeX
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Mathematische Gleichungen aus PowerPoint-Präsentationen direkt nach LaTeX oder MathML exportieren mit Aspose.Slides für PHP via Java."
---
## **Einleitung**

Aspose.Slides für PHP via Java ermöglicht das Exportieren von mathematischen Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="primary" %}} 
Sie können Gleichungen direkt nach LaTeX oder nach MathML exportieren, einem weit verbreiteten Standard für mathematische Inhalte, der im Web und in vielen Anwendungen verwendet wird.
{{% /alert %}}

## **Mathegleichungen nach LaTeX exportieren**

Aspose.Slides kann eine PowerPoint‑Mathegleichung direkt nach LaTeX konvertieren; eine Zwischendatei im MathML‑Format und ein externer Konverter sind nicht erforderlich. Eine mathematische Gleichung wird in einem Textfeld als [MathPortion](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathportion/) gespeichert. Verwenden Sie [MathPortion::getMathParagraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathportion/#getMathParagraph), um ein [MathParagraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathparagraph/) zu erhalten, und rufen Sie dann [MathParagraph::toLatex](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathparagraph/#toLatex) auf. Die Methode gibt eine Zeichenkette zurück, die Sie speichern, anzeigen, an eine andere Anwendung senden oder weiterverarbeiten können.

Das folgende Beispiel untersucht jedes Textfeld auf jeder Folie, findet alle MathPortion‑Objekte und schreibt jede Gleichung in eine separate `.tex`‑Datei:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideutil/#getAllTextBoxes) gibt alle auf einer Folie gefundenen Textfelder zurück. Die Typprüfung von [MathPortion](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathportion/) trennt echte editierbare Gleichungen von gewöhnlichem Text und Bildern.

LaTeX‑Engines und Dokumentvorlagen unterstützen nicht alle dieselben Befehle, Pakete oder Unicode‑Zeichen. Testen Sie die zurückgegebene Zeichenkette mit der LaTeX‑Engine, die Ihre Anwendung verwendet. Wenn ein Symbol oder ein Office‑Math‑Element in dieser Umgebung keine geeignete Darstellung hat, ersetzen Sie es in der zurückgegebenen Zeichenkette durch einen projektspezifischen Befehl oder überspringen Sie die Gleichung und erfassen das Problem zur Überprüfung.

## **Mathegleichungen als MathML speichern**

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, tun sie sich schwer, den Code für MathML zu schreiben, da letzteres von Anwendungen automatisch erzeugt werden soll. Programme lesen und parsen MathML problemlos, weil dessen Code in XML vorliegt, sodass MathML in vielen Bereichen häufig als Ausgabe‑ und Druckformat verwendet wird. 

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

Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben von MathML.

**Wie kann ich feststellen, ob ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**

Eine Formel befindet sich in einer [MathPortion](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathportion/) und hat ein [MathParagraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathparagraph/). Bilder und reguläre Textabschnitte ohne ein [MathParagraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathparagraph/) sind keine exportierbaren Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export zielt auf das standardisierte MathML (XML) ab. Aspose verwendet Presentation MathML – das Präsentations‑Subset des Standards –, das in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textabschnitte mit einem [MathParagraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathparagraph/) enthalten (d. h. echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie verändert die Präsentationsdatei nicht.
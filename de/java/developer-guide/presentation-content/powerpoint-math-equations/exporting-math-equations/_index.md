---
title: Export von mathematischen Gleichungen aus Präsentationen in Java
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/java/exporting-math-equations/
keywords:
- mathematische Gleichungen exportieren
- Gleichungen nach LaTeX exportieren
- PowerPoint nach LaTeX
- MathML
- LaTeX
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Exportieren Sie mathematische Gleichungen aus PowerPoint-Präsentationen direkt nach LaTeX oder MathML mit Aspose.Slides für Java."
---
## **Einführung**

Aspose.Slides ermöglicht das Exportieren mathematischer Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden. 

{{% alert color="info" %}} 

Sie können Gleichungen direkt nach LaTeX oder nach MathML exportieren, einem beliebten Standard für mathematischen Inhalt, der im Web und in vielen Anwendungen verwendet wird.

{{% /alert %}}

## **Mathegleichungen nach LaTeX exportieren**

Aspose.Slides kann eine PowerPoint-math Gleichung direkt nach LaTeX konvertieren; eine Zwischen-MathML-Datei und ein externer Konverter sind nicht erforderlich. Eine Math-Gleichung wird in einem Text-Frame als [IMathPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathportion/) gespeichert. Verwenden Sie [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathportion/#getMathParagraph--) um ein [IMathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathparagraph/) zu erhalten und rufen Sie dann [IMathParagraph.toLatex](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathparagraph/#toLatex--) auf. Die Methode gibt einen String zurück, den Sie speichern, anzeigen, an eine andere Anwendung senden oder weiter verarbeiten können.

Das folgende Beispiel untersucht jeden Text-Frame auf jeder Folie, findet alle Math-Portions und schreibt jede Gleichung in eine separate `.tex`-Datei:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/de/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) gibt alle Text-Frames zurück, die auf einer Folie gefunden werden. Die Typprüfung von [IMathPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathportion/) trennt echte bearbeitbare Gleichungen von gewöhnlichem Text und Bildern.

LaTeX-Engines und Dokumentvorlagen unterstützen nicht alle dieselben Befehle, Pakete oder Unicode-Zeichen. Testen Sie den zurückgegebenen String mit der LaTeX-Engine, die Ihre Anwendung verwendet. Wenn ein Symbol oder Office-Math-Element in dieser Umgebung keine geeignete Darstellung hat, ersetzen Sie es im zurückgegebenen String durch einen projektspezifischen Befehl oder überspringen Sie die Gleichung und protokollieren das Problem zur Überprüfung.

## **Mathegleichungen als MathML speichern**

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, fällt es ihnen schwer, den Code für MathML zu schreiben, da Letzteres automatisch von Anwendungen erzeugt werden soll. Programme lesen und parsen MathML problemlos, weil sein Code in XML vorliegt, sodass MathML häufig als Ausgabe- und Druckformat in vielen Bereichen verwendet wird.

Dieses Beispielcode zeigt, wie Sie eine Math-Gleichung aus einer Präsentation nach MathML exportieren:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

## **FAQ**

**Was genau wird nach MathML exportiert - ein Paragraph oder ein einzelner Formelblock?**

Sie können entweder einen gesamten Math-Paragraphen ([MathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathblock/)) nach MathML exportieren. Beide Typen stellen eine Methode zum Schreiben nach MathML bereit.

**Wie kann ich erkennen, dass ein Objekt auf einer Folie eine mathematische Formel und kein gewöhnlicher Text oder ein Bild ist?**

Eine Formel befindet sich in einer [MathPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathportion/) und besitzt einen [MathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathparagraph/). Bilder und reguläre Text-Portions ohne einen [MathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathparagraph/) können nicht exportiert werden.

**Woher stammt das MathML in einer Präsentation - ist es PowerPoint-spezifisch oder ein Standard?**

Der Export zielt auf das standardisierte MathML (XML). Aspose verwendet Presentation MathML - das Präsentations-Subset des Standards -, das in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Text-Portions mit einem [MathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathparagraph/) enthalten (d. h. echte PowerPoint-Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie verändert die Präsentationsdatei nicht.
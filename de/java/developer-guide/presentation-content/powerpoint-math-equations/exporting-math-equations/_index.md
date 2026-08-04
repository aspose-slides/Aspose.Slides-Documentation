---
title: Mathematische Gleichungen aus Präsentationen in Java exportieren
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/java/exporting-math-equations/
keywords:
- Mathematische Gleichungen exportieren
- Gleichungen nach LaTeX exportieren
- PowerPoint nach LaTeX
- MathML
- LaTeX
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Mathematische Gleichungen aus PowerPoint-Präsentationen direkt mit Aspose.Slides für Java nach LaTeX oder MathML exportieren."
---
## **Einleitung**

Aspose.Slides ermöglicht den Export von mathematischen Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden. 

{{% alert color="primary" %}} 

Sie können Gleichungen direkt nach LaTeX oder nach MathML exportieren, einem populären Standard für mathematische Inhalte, der im Web und in vielen Anwendungen verwendet wird.

{{% /alert %}}

## **Math‑Gleichungen nach LaTeX exportieren**

Aspose.Slides kann eine PowerPoint‑Mathe‑Gleichung direkt nach LaTeX konvertieren; eine Zwischendatei im MathML‑Format und ein externer Konverter sind nicht erforderlich. Eine mathematische Gleichung wird in einem Textfeld als [IMathPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathportion/) gespeichert. Verwenden Sie [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathportion/#getMathParagraph--) um ein [IMathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathparagraph/) zu erhalten und rufen Sie anschließend [IMathParagraph.toLatex](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathparagraph/#toLatex--) auf. Die Methode gibt einen String zurück, den Sie speichern, anzeigen, an eine andere Anwendung senden oder weiter verarbeiten können.

Das folgende Beispiel prüft jedes Textfeld auf jeder Folie, findet alle mathematischen Abschnitte und schreibt jede Gleichung in eine separate `.tex`‑Datei:

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/de/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) gibt alle Textfelder einer Folie zurück. Der Typ‑Check von [IMathPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathportion/) trennt echte editierbare Gleichungen von normalem Text und Bildern.

LaTeX‑Engines und Dokumentvorlagen unterstützen nicht alle dieselben Befehle, Pakete oder Unicode‑Zeichen. Testen Sie den zurückgegebenen String mit der LaTeX‑Engine, die Ihre Anwendung verwendet. Wenn ein Symbol oder ein Office‑Math‑Element in dieser Umgebung keine passende Darstellung hat, ersetzen Sie es im zurückgegebenen String durch einen projektspezifischen Befehl oder überspringen Sie die Gleichung und protokollieren Sie das Problem zur Überprüfung.

## **Math‑Gleichungen als MathML speichern**

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, ist das Schreiben von MathML‑Code schwieriger, weil letzteres automatisch von Anwendungen erzeugt werden soll. Programme können MathML leicht lesen und verarbeiten, weil der Code in XML vorliegt; daher wird MathML häufig als Ausgabe‑ und Druckformat in vielen Bereichen verwendet. 

Dieser Beispielcode zeigt, wie Sie eine mathematische Gleichung aus einer Präsentation nach MathML exportieren:

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

## **FAQ**

**Was genau wird nach MathML exportiert – ein Absatz oder ein einzelner Formblock?**

Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathblock/)) nach MathML exportieren. Beide Typen stellen eine Methode zum Schreiben nach MathML bereit.

**Wie erkenne ich, dass ein Objekt auf einer Folie eine mathematische Formel und kein regulärer Text oder Bild ist?**

Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathportion/) und hat ein [MathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathparagraph/). Bilder und reguläre Textabschnitte ohne ein [MathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathparagraph/) können nicht als Formeln exportiert werden.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export zielt auf standard‑konformes MathML (XML) ab. Aspose verwendet Presentation MathML – den Präsentations‑Subset des Standards –, das in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Textabschnitte mit einem [MathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathparagraph/) enthalten (also echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Ändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; es verändert die Präsentationsdatei nicht.
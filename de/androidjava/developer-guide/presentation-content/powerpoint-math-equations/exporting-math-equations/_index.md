---
title: Mathematische Gleichungen aus Präsentationen auf Android exportieren
linktitle: Gleichungen exportieren
type: docs
weight: 30
url: /de/androidjava/exporting-math-equations/
keywords:
- Mathematische Gleichungen exportieren
- Gleichungen nach LaTeX exportieren
- PowerPoint nach LaTeX
- MathML
- LaTeX
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Exportieren Sie mathematische Gleichungen aus PowerPoint-Präsentationen direkt nach LaTeX oder MathML mit Aspose.Slides für Android via Java."
---
## **Einführung**

Aspose.Slides for Android via Java ermöglicht das Exportieren mathematischer Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="primary" %}} 
Sie können Gleichungen direkt nach LaTeX oder nach MathML exportieren, einem verbreiteten Standard für mathematische Inhalte, der im Web und in vielen Anwendungen verwendet wird.
{{% /alert %}}

## **Math-Gleichungen nach LaTeX exportieren**

Aspose.Slides kann eine PowerPoint‑Math-Gleichung direkt nach LaTeX konvertieren; eine Zwischen‑MathML‑Datei und ein externer Konverter sind nicht erforderlich. Eine Math‑Gleichung wird in einem Textfeld als [IMathPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathportion/) gespeichert. Verwenden Sie [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) um ein [IMathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathparagraph/) zu erhalten und rufen Sie anschließend [IMathParagraph.toLatex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathparagraph/#toLatex--) auf. Die Methode gibt einen String zurück, den Sie speichern, anzeigen, an eine andere Anwendung senden oder weiterverarbeiten können.

Das folgende Beispiel untersucht jedes Textfeld jeder Folie, findet alle Math‑Portionen und schreibt jede Gleichung in eine separate `.tex`‑Datei:

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
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) gibt alle Textfelder zurück, die auf einer Folie gefunden werden. Der Typ‑Check von [IMathPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathportion/) trennt echte editierbare Gleichungen von gewöhnlichem Text und Bildern.

LaTeX‑Engines und Dokumentvorlagen unterstützen nicht alle dieselben Befehle, Pakete oder Unicode‑Zeichen. Testen Sie den zurückgegebenen String mit der LaTeX‑Engine, die Ihre Anwendung verwendet. Wenn ein Symbol oder ein Office‑Math‑Element in dieser Umgebung keine geeignete Darstellung hat, ersetzen Sie es im zurückgegebenen String durch ein projektspezifisches Kommando oder überspringen Sie die Gleichung und protokollieren das Problem zur späteren Überprüfung.

## **Math‑Gleichungen als MathML speichern**

Während Menschen den Code für manche Gleichungsformate wie LaTeX leicht schreiben können, fällt es ihnen schwer, den Code für MathML zu erstellen, da Letzteres automatisch von Anwendungen generiert werden soll. Programme lesen und analysieren MathML problemlos, weil dessen Code in XML vorliegt; daher wird MathML häufig als Ausgabe‑ und Druckformat in vielen Bereichen verwendet.

Dieses Beispiel zeigt, wie Sie eine Math‑Gleichung aus einer Präsentation nach MathML exportieren:

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

**Was genau wird nach MathML exportiert – ein ganzer Absatz oder ein einzelner Formel‑Block?**

Sie können entweder einen gesamten Math‑Absatz ([MathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Woran erkenne ich, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**

Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathportion/) und besitzt ein [MathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathparagraph/). Bilder und reguläre Text‑Portionen ohne ein [MathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathparagraph/) sind keine exportierbaren Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export zielt auf Standard‑MathML (XML) ab. Aspose verwendet Presentation MathML – das präsentationsbezogene Subset des Standards –, das in vielen Anwendungen und im Web verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, wenn diese Objekte Text‑Portionen mit einem [MathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathparagraph/) enthalten (also echte PowerPoint‑Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie verändert die Präsentationsdatei nicht.
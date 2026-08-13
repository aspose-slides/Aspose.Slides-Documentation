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
description: "Mathematische Gleichungen aus PowerPoint-Präsentationen direkt nach LaTeX oder MathML exportieren mit Aspose.Slides für Android über Java."
---
## **Einleitung**

Aspose.Slides für Android über Java ermöglicht das Exportieren von mathematischen Gleichungen aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Gleichungen auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden.

{{% alert color="info" %}} 
Sie können Gleichungen direkt nach LaTeX oder nach MathML exportieren, einem weit verbreiteten Standard für mathematische Inhalte, der im Web und in vielen Anwendungen verwendet wird.
{{% /alert %}}

## **Exportieren von mathematischen Gleichungen nach LaTeX**

Aspose.Slides kann eine PowerPoint-Mathegleichung direkt nach LaTeX konvertieren; eine Zwischendatei im MathML-Format und ein externer Konverter sind nicht erforderlich. Eine mathematische Gleichung wird in einem Textfeld als [IMathPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathportion/) gespeichert. Verwenden Sie [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) um ein [IMathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathparagraph/) zu erhalten, und rufen Sie dann [IMathParagraph.toLatex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathparagraph/#toLatex--) auf. Die Methode gibt einen String zurück, den Sie speichern, anzeigen, an eine andere Anwendung senden oder weiter verarbeiten können.

Das folgende Beispiel prüft jedes Textfeld auf jeder Folie, findet alle mathematischen Abschnitte und schreibt jede Gleichung in eine separate `.tex`-Datei:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) gibt alle auf einer Folie gefundenen Textfelder zurück. Die Typprüfung von [IMathPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathportion/) trennt echte bearbeitbare Gleichungen von gewöhnlichem Text und Bildern.

LaTeX-Engines und Dokumentvorlagen unterstützen nicht alle dieselben Befehle, Pakete oder Unicode-Zeichen. Testen Sie den zurückgegebenen String mit der von Ihrer Anwendung verwendeten LaTeX-Engine. Wenn ein Symbol oder ein Office-Math-Element in dieser Umgebung keine geeignete Darstellung hat, ersetzen Sie es im zurückgegebenen String durch einen projektspezifischen Befehl oder überspringen Sie die Gleichung und protokollieren Sie das Problem zur Überprüfung.

## **Mathegleichungen als MathML speichern**

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, haben sie Schwierigkeiten, den Code für MathML zu erstellen, weil Letzteres automatisch von Anwendungen generiert werden soll. Programme lesen und analysieren MathML problemlos, weil der Code in XML vorliegt; daher wird MathML in vielen Bereichen häufig als Ausgabe- und Druckformat verwendet. 

Dieses Beispielcode zeigt, wie Sie eine mathematische Gleichung aus einer Präsentation nach MathML exportieren:

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

**Was genau wird nach MathML exportiert – ein Absatz oder ein einzelner Formelblock?**  
Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben nach MathML.

**Wie kann ich erkennen, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**  
Eine Formel befindet sich in einem [MathPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathportion/) und hat einen [MathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathparagraph/). Bilder und reguläre Textabschnitte ohne einen [MathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathparagraph/) können nicht als Formeln exportiert werden.

**Woher kommt das MathML in einer Präsentation – ist es PowerPoint-spezifisch oder ein Standard?**  
Der Export richtet sich an das standardisierte MathML (XML). Aspose verwendet Presentation MathML - das Präsentations-Subset des Standards -, das in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln innerhalb von Tabellen, SmartArt, Gruppen usw. unterstützt?**  
Ja, wenn diese Objekte Textabschnitte mit einem [MathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathparagraph/) enthalten (d.h. echte PowerPoint-Formeln), werden sie exportiert. Ist eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**  
Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; sie ändert die Präsentationsdatei nicht.
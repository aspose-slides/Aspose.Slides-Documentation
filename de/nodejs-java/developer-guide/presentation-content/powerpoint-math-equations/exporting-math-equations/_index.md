---
title: Export von mathematischen Formeln aus Präsentationen in JavaScript
linktitle: Formeln exportieren
type: docs
weight: 30
url: /de/nodejs-java/exporting-math-equations/
keywords:
- Matheformeln exportieren
- Formeln nach LaTeX exportieren
- PowerPoint nach LaTeX
- MathML
- LaTeX
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportieren Sie mathematische Formeln aus PowerPoint-Präsentationen direkt nach LaTeX oder MathML mit Aspose.Slides für Node.js über Java."
---
## **Einleitung**

Aspose.Slides ermöglicht das Exportieren mathematischer Formeln aus Präsentationen. Beispielsweise müssen Sie möglicherweise die mathematischen Formeln auf Folien (aus einer bestimmten Präsentation) extrahieren und in einem anderen Programm oder einer anderen Plattform verwenden. 

{{% alert color="primary" %}} 

Sie können Formeln direkt nach LaTeX oder MathML exportieren, einem weit verbreiteten Standard für mathematische Inhalte, der im Web und in vielen Anwendungen verwendet wird.

{{% /alert %}}

## **Math‑Formeln nach LaTeX exportieren**

Aspose.Slides kann eine PowerPoint‑Mathe‑Formel direkt nach LaTeX konvertieren; eine Zwischendatei im MathML‑Format und ein externer Konverter sind nicht erforderlich. Eine mathematische Formel wird in einem Textfeld als [MathPortion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mathportion/) gespeichert. Verwenden Sie [MathPortion.getMathParagraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) , um ein [MathParagraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mathparagraph/) zu erhalten, und rufen Sie anschließend [MathParagraph.toLatex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mathparagraph/#toLatex--) auf. Die Methode gibt einen String zurück, den Sie speichern, anzeigen, an eine andere Anwendung senden oder weiterverarbeiten können.

Das folgende Beispiel untersucht jedes Textfeld auf jeder Folie, findet alle MathPortion‑Objekte und schreibt jede Formel in eine separate `.tex`‑Datei:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) gibt alle auf einer Folie gefundenen Textfelder zurück. Die Typprüfung mit [MathPortion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mathportion/) trennt echte editierbare Formeln von normalem Text und Bildern.

LaTeX‑Engines und Dokumentvorlagen unterstützen nicht alle dieselben Befehle, Pakete oder Unicode‑Zeichen. Testen Sie den zurückgegebenen String mit der von Ihrer Anwendung genutzten LaTeX‑Engine. Hat ein Symbol oder ein Office‑Math‑Element keine geeignete Darstellung in dieser Umgebung, ersetzen Sie es im zurückgegebenen String durch einen projektspezifischen Befehl oder überspringen Sie die Formel und protokollieren das Problem zur späteren Überprüfung.

## **Math‑Formeln als MathML speichern**

Während Menschen den Code für einige Gleichungsformate wie LaTeX leicht schreiben können, haben sie Schwierigkeiten, den Code für MathML zu erstellen, da Letzteres von Anwendungen automatisch erzeugt werden soll. Programme lesen und parsen MathML problemlos, da der Code in XML vorliegt, weshalb MathML in vielen Bereichen häufig als Ausgabe‑ und Druckformat verwendet wird. 

Dieser Beispielcode zeigt, wie Sie eine mathematische Formel aus einer Präsentation nach MathML exportieren:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Was genau nach MathML exportiert wird – ein Absatz oder ein einzelner Formelblock?**

Sie können entweder einen gesamten mathematischen Absatz ([MathParagraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mathparagraph/)) oder einen einzelnen Block ([MathBlock](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mathblock/)) nach MathML exportieren. Beide Typen bieten eine Methode zum Schreiben in MathML.

**Wie erkenne ich, dass ein Objekt auf einer Folie eine mathematische Formel und kein normaler Text oder Bild ist?**

Eine Formel befindet sich in einer [MathPortion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mathportion/) und besitzt ein [MathParagraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mathparagraph/). Bilder und reguläre Textteile ohne ein [MathParagraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mathparagraph/) sind keine exportierbaren Formeln.

**Woher stammt das MathML in einer Präsentation – ist es PowerPoint‑spezifisch oder ein Standard?**

Der Export zielt auf standardisiertes MathML (XML). Aspose verwendet Presentation MathML – das Präsentations‑Subset des Standards –, das in vielen Anwendungen und im Web weit verbreitet ist.

**Wird das Exportieren von Formeln in Tabellen, SmartArt, Gruppen usw. unterstützt?**

Ja, sofern diese Objekte Textteile mit einem [MathParagraph](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/mathparagraph/) enthalten (d. h. echte PowerPoint‑Formeln), werden sie exportiert. Wird eine Formel als Bild eingebettet, wird sie nicht exportiert.

**Verändert das Exportieren nach MathML die ursprüngliche Präsentation?**

Nein. Das Schreiben von MathML ist eine Serialisierung des Inhalts der Formel; dabei wird die Präsentationsdatei nicht verändert.
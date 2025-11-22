---
title: Folien klonen
type: docs
weight: 35
url: /de/nodejs-java/clone-slides/
---

## **Folien in einer Präsentation klonen**
Klonen ist der Vorgang, eine exakte Kopie oder Replik eines Objekts zu erstellen. Aspose.Slides für Node.js via Java ermöglicht ebenfalls das Erstellen einer Kopie oder eines Klons einer beliebigen Folie und das anschließende Einfügen dieser geklonten Folie in die aktuelle oder jede andere geöffnete Präsentation. Der Vorgang des Folienklonens erstellt eine neue Folie, die von Entwicklern geändert werden kann, ohne die ursprüngliche Folie zu verändern. Es gibt mehrere mögliche Methoden, um eine Folie zu klonen:

- Klon am Ende innerhalb einer Präsentation.
- Klon an einer anderen Position innerhalb der Präsentation.
- Klon am Ende in einer anderen Präsentation.
- Klon an einer anderen Position in einer anderen Präsentation.
- Klon an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides für Node.js via Java stellt die (eine Sammlung von [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)-Objekten), die vom [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Objekt bereitgestellt wird, die Methoden [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) und [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) zur Verfügung, um die oben genannten Arten des Folienklonens auszuführen

## **Klon am Ende innerhalb einer Präsentation**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten, verwenden Sie die Methode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Instanziieren Sie die Klasse [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) durch Verweis auf die Slides‑Sammlung, die vom Objekt [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) bereitgestellt wird.
3. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) auf, die vom Objekt [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) bereitgestellt wird, und übergeben Sie die zu klonende Folie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
4. Schreiben Sie die modifizierte Präsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (die an der ersten Position – Index 0 – der Präsentation liegt) an das Ende der Präsentation geklont.
```javascript
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klonen Sie die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Schreiben Sie die modifizierte Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Klon an einer anderen Position innerhalb einer Präsentation**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei, jedoch an einer anderen Position verwenden möchten, nutzen Sie die Methode [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Instanziieren Sie die Klasse, indem Sie auf die vom Objekt [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) bereitgestellte [**Slides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) Sammlung verweisen.
3. Rufen Sie die Methode [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) auf, die vom Objekt [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) bereitgestellt wird, und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Folie (die am Index 0 – Position 1 – der Präsentation liegt) auf Index 1 – Position 2 – der Präsentation geklont.
```javascript
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klonen Sie die gewünschte Folie am Ende der Foliensammlung in derselben Präsentation
    var slds = pres.getSlides();
    // Klonen Sie die gewünschte Folie am angegebenen Index in derselben Präsentation
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Schreiben Sie die modifizierte Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Klon am Ende in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), die die Präsentation enthält, aus der die Folie geklont werden soll.
2. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
3. Instanziieren Sie die Klasse [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) durch Verweis auf die [**Slides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)‑Sammlung, die vom Presentation‑Objekt der Zielpräsentation bereitgestellt wird.
4. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) auf, die vom Objekt [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die Methode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
5. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.
```javascript
// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanziieren Sie die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klonen Sie die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Schreiben Sie die Zielpräsentation auf die Festplatte
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Klon an einer anderen Position in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
2. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), die die Präsentation enthält, zu der die Folie hinzugefügt werden soll.
3. Instanziieren Sie die Klasse [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) durch Verweis auf die Slides‑Sammlung, die vom Presentation‑Objekt der Zielpräsentation bereitgestellt wird.
4. Rufen Sie die Methode [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) auf, die vom Objekt [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
5. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem Index 0 der Quellpräsentation) zu Index 1 (Position 2) der Zielpräsentation geklont.
```javascript
// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanziieren Sie die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klonen Sie die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Schreiben Sie die Zielpräsentation auf die Festplatte
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Klon an einer bestimmten Position in einer anderen Präsentation**
Wenn Sie eine Folie mit einer Master‑Folie aus einer Präsentation klonen und in einer anderen Präsentation verwenden müssen, klonen Sie zunächst die gewünschte Master‑Folie von der Quell‑ zur Zielpräsentation. Anschließend verwenden Sie diese Master‑Folie für das Klonen der Folie mit Master‑Folie. Die [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) erwartet eine Master‑Folie aus der Zielpräsentation und nicht aus der Quellpräsentation. Befolgen Sie die nachstehenden Schritte, um eine Folie mit Master zu klonen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
2. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
3. Greifen Sie auf die zu klonende Folie zusammen mit der Master‑Folie zu.
4. Instanziieren Sie die Klasse [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) durch Verweis auf die Masters‑Sammlung, die vom [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Objekt der Zielpräsentation bereitgestellt wird.
5. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) auf, die vom Objekt [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) bereitgestellt wird, und übergeben Sie den Master aus der Quell‑PPTX, der geklont werden soll, als Parameter an die Methode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
6. Instanziieren Sie die Klasse [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) und setzen Sie die Referenz auf die Slides‑Sammlung, die vom [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Objekt der Zielpräsentation bereitgestellt wird.
7. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) auf, die vom Objekt [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation, die geklont werden soll, sowie die Master‑Folie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
8. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie mit Master (die am Index 0 der Quellpräsentation liegt) an das Ende der Zielpräsentation geklont, wobei ein Master aus der Quell‑Folie verwendet wurde.
```javascript
// Instanziieren Sie die Presentation‑Klasse, um die Quellpräsentationsdatei zu laden
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instanziieren Sie die Presentation‑Klasse für die Zielpräsentation (wo die Folie geklont werden soll)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instanziieren Sie ISlide aus der Foliensammlung der Quellpräsentation zusammen mit
        // Masterfolie
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Klonen Sie die gewünschte Masterfolie von der Quellpräsentation in die Mastersammlung der
        // Zielpräsentation
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Klonen Sie die gewünschte Masterfolie von der Quellpräsentation in die Mastersammlung der
        // Zielpräsentation
        var iSlide = masters.addClone(SourceMaster);
        // Klonen Sie die gewünschte Folie von der Quellpräsentation mit der gewünschten Masterfolie an das Ende der
        // Foliensammlung in der Zielpräsentation
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Speichern Sie die Zielpräsentation auf die Festplatte
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Klon am Ende in einem angegebenen Abschnitt**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei, jedoch in einem anderen Abschnitt verwenden möchten, verwenden Sie die Methode [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) , die von der Klasse [**SlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) bereitgestellt wird. Aspose.Slides für Node.js via Java ermöglicht das Klonen einer Folie aus dem ersten Abschnitt und das anschließende Einfügen dieser geklonten Folie in den zweiten Abschnitt derselben Präsentation.

Das folgende Code‑Snippet zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Speichern Sie die Zielpräsentation auf die Festplatte
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Werden Sprecher‑Notizen und Prüfer‑Kommentare geklont?**

Ja. Die Notizenseite und die Überprüfungskommentare sind im Klon enthalten. Wenn Sie sie nicht möchten, [entfernen Sie sie](/slides/de/nodejs-java/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagrammobjekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als ein [OLE‑Objekt](/slides/de/nodejs-java/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten überprüfen.

**Kann ich die Einfügeposition und die Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewählten [Abschnitt](/slides/de/nodejs-java/slide-section/) platzieren. Wenn der Zielabschnitt nicht existiert, erstellen Sie ihn zuerst und verschieben Sie anschließend die Folie hinein.
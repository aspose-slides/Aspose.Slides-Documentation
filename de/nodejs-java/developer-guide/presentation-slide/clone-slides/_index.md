---
title: Präsentationsfolien in JavaScript klonen
linktitle: Folien klonen
type: docs
weight: 35
url: /de/nodejs-java/clone-slides/
keywords:
- Folien klonen
- Folien kopieren
- Folien speichern
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Duplizieren Sie PowerPoint‑Folien schnell mit Aspose.Slides für Node.js. Folgen Sie unseren Code‑Beispielen, um die PPT‑Erstellung in Sekundenschnelle zu automatisieren und manuelle Arbeit zu vermeiden."
---
## **Einleitung**

Cloning ist der Vorgang, eine exakte Kopie oder Replikation von etwas zu erstellen. Aspose.Slides für Node.js via Java ermöglicht ebenfalls das Erstellen einer Kopie oder eines Klons einer beliebigen Folie und das Einfügen dieser geklonten Folie in die aktuelle oder eine andere geöffnete Präsentation. Beim Klonen einer Folie wird eine neue Folie erzeugt, die von Entwicklern modifiziert werden kann, ohne die Originalfolie zu verändern. Es gibt mehrere mögliche Methoden, um eine Folie zu klonen:

- Klon am Ende innerhalb einer Präsentation.
- Klon an einer anderen Position innerhalb einer Präsentation.
- Klon am Ende in einer anderen Präsentation.
- Klon an einer anderen Position in einer anderen Präsentation.
- Klon an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides für Node.js via Java stellt die (eine Sammlung von [Slide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Slide)-Objekten), die vom [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Objekt bereitgestellt wird, die Methoden [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) und [insertClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) zur Verfügung, um die oben genannten Arten des Folienklonens durchzuführen.

## **Klon am Ende innerhalb einer Präsentation**
Wenn Sie eine Folie klonen und dann innerhalb derselben Präsentationsdatei am Ende der bestehenden Folien verwenden möchten, verwenden Sie die [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methode gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Klasse.
1. Instanziieren Sie die [SlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation#getSlides--)‑Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Objekt bereitgestellte Folien‑Sammlung zugreifen.
1. Rufen Sie die von dem [SlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methode auf und übergeben Sie die zu klonende Folie als Parameter an die [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die modifizierte Präsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (die an der ersten Position – Index 0 – der Präsentation liegt) bis zum Ende der Präsentation geklont.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
Wenn Sie eine Folie klonen und dann innerhalb derselben Präsentationsdatei, jedoch an einer anderen Position, verwenden möchten, verwenden Sie die [insertClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)‑Methode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Klasse.
1. Instanziieren Sie die Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Objekt bereitgestellte [**Slides**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation#getSlides--)‑Sammlung zugreifen.
1. Rufen Sie die von dem [SlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [insertClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)‑Methode auf und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [insertClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Folie (die an Index 1 – Position 2 – der Präsentation liegt) zu Index 2 – Position 3 – der Präsentation geklont.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klonen Sie die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    var slds = pres.getSlides();
    // Klonen Sie die gewünschte Folie an den angegebenen Index in derselben Präsentation
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Schreiben Sie die modifizierte Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klon am Ende in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und sie in einer anderen Präsentationsdatei am Ende der bestehenden Folien verwenden wollen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [SlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection)-Klasse, indem Sie auf die von dem [**Slides**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation#getSlides--)‑Sammlung des Präsentations‑Objekts der Zielpräsentation zugreifen.
1. Rufen Sie die von dem [SlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem ersten Index der Quellpräsentation) bis zum Ende der Zielpräsentation geklont.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
Wenn Sie eine Folie aus einer Präsentation klonen und sie in einer anderen Präsentationsdatei an einer bestimmten Position verwenden wollen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Klasse, die die Präsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [SlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation#getSlides--)‑Klasse, indem Sie auf die Folien‑Sammlung des Präsentations‑Objekts der Zielpräsentation zugreifen.
1. Rufen Sie die von dem [SlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [insertClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [insertClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem Index 0 der Quellpräsentation) zu Index 1 (Position 2) der Zielpräsentation geklont.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanziieren Sie die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klonen Sie die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Schreiben Sie die Zielpräsentation auf die Festplatte
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon an einer spezifischen Position in einer anderen Präsentation**
Wenn Sie eine Folie mit einer Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden möchten, müssen Sie zunächst die gewünschte Masterfolie aus der Quellpräsentation in die Zielpräsentation klonen. Anschließend verwenden Sie diese Masterfolie zum Klonen der Folie mit Masterfolie. Die Methode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) erwartet eine Masterfolie aus der Zielpräsentation und nicht aus der Quellpräsentation. Gehen Sie dafür wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Klasse, die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
1. Greifen Sie auf die zu klonende Folie zusammen mit ihrer Masterfolie zu.
1. Instanziieren Sie die [MasterSlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/MasterSlideCollection)-Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Objekt der Zielpräsentation bereitgestellte Masters‑Sammlung zugreifen.
1. Rufen Sie die von dem [MasterSlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/MasterSlideCollection)-Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Masterfolie aus dem Quell‑PPTX als Parameter an die [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methode.
1. Instanziieren Sie die [SlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation#getSlides--)‑Klasse, indem Sie die Referenz auf die von dem [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation)-Objekt der Zielpräsentation bereitgestellte Folien‑Sammlung setzen.
1. Rufen Sie die von dem [SlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation sowie die Masterfolie als Parameter an die [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie mit einer Masterfolie (die am Index 0 der Quellpräsentation liegt) bis zum Ende der Zielpräsentation geklont, wobei die Masterfolie aus der Quellfolie verwendet wurde.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instanziieren Sie die Presentation-Klasse für die Zielpräsentation (wo die Folie geklont werden soll)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instanziieren Sie ISlide aus der Foliensammlung der Quellpräsentation zusammen mit
        // Master-Folie
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Klonen Sie die gewünschte Master-Folie aus der Quellpräsentation in die Master‑Sammlung der
        // Zielpräsentation
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Klonen Sie die gewünschte Folie aus der Quellpräsentation mit dem gewünschten Master an das Ende der
        // Foliensammlung in der Zielpräsentation
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
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
Wenn Sie eine Folie klonen und dann innerhalb derselben Präsentationsdatei, jedoch in einem anderen Abschnitt, verwenden möchten, verwenden Sie die [**addClone**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-)‑Methode, die von der [**SlideCollection**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/SlideCollection)-Klasse bereitgestellt wird. Aspose.Slides für Node.js via Java ermöglicht das Klonen einer Folie aus dem ersten Abschnitt und das Einfügen dieser geklonten Folie in den zweiten Abschnitt derselben Präsentation.

Der folgende Code‑Abschnitt zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Speichern Sie die Zielpräsentation auf die Festplatte
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Übereinstimmende Foliengröße sicherstellen**

Beim Klonen von Folien in eine andere Präsentation muss die Zielpräsentation dieselbe Foliengröße wie die Quellpräsentation haben. Wenn die Foliengrößen unterschiedlich sind, skaliert Aspose.Slides die geklonten Formen nicht automatisch – ihre ursprünglichen Koordinaten und Abmessungen bleiben erhalten, was dazu führen kann, dass Inhalte fehlerhaft ausgerichtet sind oder über die Folienränder hinausgehen.

Sie können die Foliengröße der Zielpräsentation vor dem Klonen von Master und Folie auf die Größe der Quellpräsentation einstellen:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Führen Sie dies aus, bevor Sie den Master und die Folie klonen.

## **FAQ**

**Werden Sprecher–Notizen und Review‑Kommentare geklont?**

Ja. Die Notizenseite und die Review‑Kommentare werden im Klon übernommen. Wenn Sie sie nicht benötigen, [entfernen Sie sie](/slides/de/nodejs-java/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagramm‑Objekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/nodejs-java/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten prüfen.

**Kann ich die Einfügeposition und die Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewählten [Abschnitt](/slides/de/nodejs-java/slide-section/) verschieben. Existiert der Zielabschnitt nicht, erstellen Sie ihn zuerst und verschieben dann die Folie hinein.
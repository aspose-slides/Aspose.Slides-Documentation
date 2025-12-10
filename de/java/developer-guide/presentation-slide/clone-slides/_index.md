---
title: Klonen von Präsentationsfolien in Java
linktitle: Folien klonen
type: docs
weight: 35
url: /de/java/clone-slides/
keywords:
- Folie klonen
- Folie kopieren
- Folie speichern
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Schnelles Duplizieren von PowerPoint-Folien mit Aspose.Slides für Java. Folgen Sie unseren klaren Code-Beispielen, um die PPT-Erstellung in Sekunden zu automatisieren und manuelle Arbeit zu beseitigen."
---

## **Folien in einer Präsentation klonen**
Klonen ist der Vorgang, bei dem eine exakte Kopie oder ein Duplikat von etwas erstellt wird. Aspose.Slides for Java ermöglicht es ebenfalls, eine Kopie bzw. einen Klon einer beliebigen Folie zu erstellen und diesen geklonten Folie in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Vorgang des Folienklonens erzeugt eine neue Folie, die von Entwicklern geändert werden kann, ohne die Originalfolie zu verändern. Es gibt mehrere mögliche Wege, eine Folie zu klonen:

- Klon am Ende innerhalb einer Präsentation.
- Klon an einer anderen Position innerhalb einer Präsentation.
- Klon am Ende in einer anderen Präsentation.
- Klon an einer anderen Position in einer anderen Präsentation.
- Klon an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides for Java (eine Sammlung von [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)‑Objekten), die vom [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Objekt bereitgestellt wird, stehen die Methoden [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) und [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) zur Verfügung, um die oben genannten Arten des Folienklonens auszuführen.

## **Klon einer Folie am Ende einer Präsentation**
Wenn Sie eine Folie klonen und anschließend am Ende der vorhandenen Folien in derselben Präsentationsdatei verwenden möchten, verwenden Sie die [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)‑Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Objekt bereitgestellte Folien‑Sammlung verweisen.
1. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die zu klonende Folie als Parameter an die [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die geänderte Präsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (die sich an der ersten Position – nullbasierter Index – der Präsentation befindet) an das Ende der Präsentation geklont.
```java
// Instanziiere die Presentation-Klasse, die eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klone die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Schreibe die geänderte Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Klon einer Folie an eine andere Position innerhalb einer Präsentation**
Wenn Sie eine Folie klonen und anschließend an einer anderen Position in derselben Präsentationsdatei verwenden möchten, verwenden Sie die [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse.
1. Instanziieren Sie die Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Objekt bereitgestellte [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)‑Sammlung verweisen.
1. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir eine Folie (die sich am nullbasierten Index – Position 1 – der Präsentation befindet) auf Index 1 – Position 2 – der Präsentation geklont.
```java
// Instanziiere die Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klone die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    ISlideCollection slds = pres.getSlides();

    // Klone die gewünschte Folie an den angegebenen Index in derselben Präsentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Schreibe die geänderte Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Klon einer Folie am Ende einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und sie in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection)‑Klasse, indem Sie auf die von dem Presentation‑Objekt der Zielpräsentation bereitgestellte [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)‑Sammlung verweisen.
1. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.
```java
// Präsentationsklasse instanziieren, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Präsentationsklasse für die Ziel-PPTX instanziieren (in die die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation klonen
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Die Zielpräsentation auf die Festplatte schreiben
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Klon einer Folie an eine andere Position in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und sie in einer anderen Präsentationsdatei an einer bestimmten Position verwenden möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)‑Klasse, indem Sie auf die von dem Presentation‑Objekt der Zielpräsentation bereitgestellte Folien‑Sammlung verweisen.
1. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem nullbasierten Index der Quellpräsentation) auf Index 1 (Position 2) der Zielpräsentation geklont.
```java
// Präsentationsklasse instanziieren, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Präsentationsklasse für die Ziel-PPTX instanziieren (wo die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Klone die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Die Zielpräsentation auf die Festplatte schreiben
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Klon einer Folie an einer bestimmten Position in einer anderen Präsentation**
Wenn Sie eine Folie mit einer Masterfolie aus einer Präsentation in einer anderen Präsentation klonen möchten, müssen Sie zuerst die gewünschte Masterfolie aus der Quellpräsentation in die Zielpräsentation klonen. Anschließend verwenden Sie diese Masterfolie zum Klonen der Folie mit Masterfolie. Die Methode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) erwartet eine Masterfolie aus der Zielpräsentation und nicht aus der Quellpräsentation. Um die Folie mit Masterfolie zu klonen, führen Sie die nachstehenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse, die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
1. Greifen Sie auf die zu klonende Folie zusammen mit der Masterfolie zu.
1. Instanziieren Sie die [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)‑Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Objekt der Zielpräsentation bereitgestellte Masters‑Sammlung verweisen.
1. Rufen Sie die von dem [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Masterfolie aus der Quell‑PPTX als Parameter an die [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)‑Klasse, indem Sie die Referenz auf die von dem [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Objekt der Zielpräsentation bereitgestellte Folien‑Sammlung setzen.
1. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation sowie die Masterfolie als Parameter an die [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie mit Master (die sich am nullbasierten Index der Quellpräsentation befindet) an das Ende der Zielpräsentation geklont, wobei die Masterfolie aus der Quellfolie verwendet wird.
```java
// Präsentationsklasse instanziieren, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Präsentationsklasse für die Zielpräsentation instanziieren (wo die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // ISlide aus der Foliensammlung der Quellpräsentation instanziieren zusammen mit
        // Masterfolie
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Die gewünschte Masterfolie aus der Quellpräsentation in die Master‑Sammlung der
        // Zielpräsentation klonen
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Die gewünschte Masterfolie aus der Quellpräsentation in die Master‑Sammlung der
        // Zielpräsentation klonen
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Die gewünschte Folie aus der Quellpräsentation mit dem gewünschten Master an das Ende der
        // Foliensammlung der Zielpräsentation klonen
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Zielpräsentation auf die Festplatte speichern
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Klon einer Folie am Ende eines angegebenen Abschnitts**
Wenn Sie eine Folie klonen und anschließend in derselben Präsentationsdatei, jedoch in einem anderen Abschnitt verwenden möchten, verwenden Sie die [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)‑Methode, die von der [**ISlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection)‑Schnittstelle bereitgestellt wird. Aspose.Slides for Java ermöglicht es, eine Folie aus dem ersten Abschnitt zu klonen und diese geklonte Folie in den zweiten Abschnitt derselben Präsentation einzufügen.

Der folgende Code‑Auszug zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen.
```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Zielpräsentation auf die Festplatte speichern
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**Werden Sprechernotizen und Reviewer‑Kommentare geklont?**

Ja. Die Notizenseite und die Review‑Kommentare sind im Klon enthalten. Wenn Sie sie nicht möchten, [entfernen Sie sie](/slides/de/java/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagrammobjekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/java/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten prüfen.

**Kann ich die Einfügeposition und die Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen ausgewählten [Abschnitt](/slides/de/java/slide-section/) verschieben. Existiert der Zielabschnitt nicht, erstellen Sie ihn zuerst und verschieben dann die Folie dorthin.
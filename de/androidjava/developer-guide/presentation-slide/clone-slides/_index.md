---
title: Folien einer Präsentation auf Android duplizieren
linktitle: Folien klonen
type: docs
weight: 35
url: /de/androidjava/clone-slides/
keywords:
- Folie klonen
- Folie kopieren
- Folie speichern
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Duplizieren Sie PowerPoint-Folien mit Aspose.Slides für Android. Folgen Sie unseren klaren Java-Code-Beispielen, um die Erstellung von PPTs in Sekunden zu automatisieren und manuelle Arbeit zu vermeiden."
---

## **Folien in einer Präsentation klonen**
Klonen ist der Vorgang, bei dem eine exakte Kopie oder ein Duplikat von etwas erstellt wird. Aspose.Slides for Android via Java ermöglicht es ebenfalls, eine Kopie oder einen Klon einer beliebigen Folie zu erstellen und diesen geklonten Folie in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Vorgang des Folienklonens erzeugt eine neue Folie, die von Entwicklern geändert werden kann, ohne die Originalfolie zu verändern. Es gibt mehrere mögliche Arten, eine Folie zu klonen:

- Klonen am Ende innerhalb einer Präsentation.
- Klonen an einer anderen Position innerhalb einer Präsentation.
- Klonen am Ende in einer anderen Präsentation.
- Klonen an einer anderen Position in einer anderen Präsentation.
- Klonen an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides for Android via Java stellt (eine Sammlung von [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide)‑Objekten), die vom [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Objekt bereitgestellt wird, die Methoden [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) und [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) zur Durchführung der oben genannten Arten des Folienklonens zur Verfügung.

## **Eine Folie am Ende einer Präsentation klonen**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten, verwenden Sie die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Klasse, indem Sie auf die Folien‑Sammlung zugreifen, die vom [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Objekt bereitgestellt wird.
1. Rufen Sie die von der [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die zu klonende Folie als Parameter an die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die geänderte Präsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (die an erster Position – Index 0 – der Präsentation liegt) an das Ende der Präsentation geklont.
```java
// Instanziiere die Presentation-Klasse, die eine Präsentationsdatei darstellt
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


## **Eine Folie an einer anderen Position innerhalb einer Präsentation klonen**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei, jedoch an einer anderen Position, verwenden möchten, verwenden Sie die [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
1. Instanziieren Sie die Klasse, indem Sie auf die [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Sammlung zugreifen, die vom [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Objekt bereitgestellt wird.
1. Rufen Sie die von der [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir eine Folie (die an Index 0 – Position 1 – der Präsentation liegt) auf Index 1 – Position 2 – der Präsentation geklont.
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


## **Eine Folie am Ende einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)‑Klasse, indem Sie auf die [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Sammlung zugreifen, die vom Präsentations‑Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die von der [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.
```java
// Instanziiere die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanziiere die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Klonen Sie die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Schreiben Sie die Zielpräsentation auf die Festplatte
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Eine Folie an einer anderen Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse, die die Präsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Klasse, indem Sie auf die Folien‑Sammlung zugreifen, die vom Präsentations‑Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die von der [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem Index 0 der Quellpräsentation) auf Index 1 (Position 2) der Zielpräsentation geklont.
```java
// Instanziiere die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanziiere die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Klone die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Schreibe die Zielpräsentation auf die Festplatte
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Eine Folie an einer bestimmten Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie mit einer Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden müssen, müssen Sie zunächst die gewünschte Masterfolie aus der Quellpräsentation in die Zielpräsentation klonen. Anschließend verwenden Sie diese Masterfolie, um die Folie mit Masterfolie zu klonen. Die Methode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) erwartet eine Masterfolie aus der Zielpräsentation und nicht aus der Quellpräsentation. Folgen Sie bitte den untenstehenden Schritten, um die Folie mit Master zu klonen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse, die die Zielpräsentation enthält, in die die Folie geklont werden soll.
1. Greifen Sie auf die zu klonende Folie zusammen mit der Masterfolie zu.
1. Instanziieren Sie die [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)‑Klasse, indem Sie auf die Masters‑Sammlung zugreifen, die vom [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die von der [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Masterfolie aus der Quell‑PPTX als Parameter an die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Klasse, indem Sie die Referenz auf die Folien‑Sammlung setzen, die vom [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die von der [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation sowie die Masterfolie als Parameter an die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode.
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie mit einer Masterfolie (die an Index 0 der Quellpräsentation liegt) an das Ende der Zielpräsentation geklont, wobei die Masterfolie aus der Quellfolie verwendet wurde.
```java
// Instanziiere die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instanziiere die Presentation-Klasse für die Zielpräsentation (in die die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Instanziiere ISlide aus der Foliensammlung der Quellpräsentation zusammen mit
        // Masterfolie
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Kopiere die gewünschte Masterfolie aus der Quellpräsentation in die Master-Sammlung der
        // Zielpräsentation
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Kopiere die gewünschte Masterfolie aus der Quellpräsentation in die Master-Sammlung der
        // Zielpräsentation
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klone die gewünschte Folie aus der Quellpräsentation mit dem gewünschten Master an das Ende der
        // Foliensammlung in der Zielpräsentation
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Speichere die Zielpräsentation auf die Festplatte
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Eine Folie am Ende eines angegebenen Abschnitts klonen**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei, jedoch in einem anderen Abschnitt, verwenden möchten, verwenden Sie die [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)‑Methode, die vom [**ISlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)‑Interface bereitgestellt wird. Aspose.Slides for Android via Java ermöglicht das Klonen einer Folie aus dem ersten Abschnitt und das Einfügen dieser geklonten Folie in den zweiten Abschnitt derselben Präsentation.

Der folgende Code‑Auszug zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen.
```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Speichern Sie die Zielpräsentation auf die Festplatte
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**Werden Notizen des Sprechers und Reviewer‑Kommentare geklont?**

Ja. Die Notizenseite und die Review‑Kommentare werden im Klon mitkopiert. Wenn Sie sie nicht möchten, [entfernen Sie sie](/slides/de/androidjava/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagramm‑Objekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm an eine externe Quelle (z. B. eine OLE‑eingebettete Arbeitsmappe) gebunden war, bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/androidjava/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit prüfen und das Aktualisierungsverhalten überprüfen.

**Kann ich die Einfügeposition und die Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewünschten [Abschnitt](/slides/de/androidjava/slide-section/) verschieben. Existiert der Zielabschnitt nicht, müssen Sie ihn zuerst erstellen und anschließend die Folie dort hineinverschieben.
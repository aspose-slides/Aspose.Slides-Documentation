---
title: Folien einer Präsentation in Java klonen
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
description: "Duplizieren Sie PowerPoint-Folien schnell mit Aspose.Slides für Java. Folgen Sie unseren klaren Code-Beispielen, um die PPT-Erstellung in Sekunden zu automatisieren und manuelle Arbeit zu vermeiden."
---
## **Einleitung**

Cloning ist der Vorgang, eine exakte Kopie oder Nachbildung von etwas zu erstellen. Aspose.Slides for Java ermöglicht es ebenfalls, eine Kopie oder einen Klon einer beliebigen Folie zu erstellen und diese geklonte Folie in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Vorgang des Folienklonens erzeugt eine neue Folie, die von Entwicklern geändert werden kann, ohne die Originalfolie zu verändern. Es gibt mehrere mögliche Arten, eine Folie zu klonen:

- Klon am Ende innerhalb einer Präsentation.
- Klon an einer anderen Position innerhalb einer Präsentation.
- Klon am Ende in einer anderen Präsentation.
- Klon an einer anderen Position in einer anderen Präsentation.
- Klon zusammen mit ihrer Masterfolie in eine andere Präsentation.

In Aspose.Slides for Java stellt (eine Sammlung von [ISlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlide)‑Objekten), die vom [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Objekt bereitgestellt wird, die Methoden [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) und [insertClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) zur Verfügung, um die oben genannten Arten des Folienklonens durchzuführen.

## **Eine Folie am Ende einer Präsentation klonen**
Wenn Sie eine Folie klonen und anschließend in derselben Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten, verwenden Sie die [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse.  
2. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getSlides--)‑Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Objekt bereitgestellte Slides‑Sammlung verweisen.  
3. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die zu klonende Folie als Parameter an die [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode.  
4. Schreiben Sie die modifizierte Präsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (die sich an der ersten Position – Null‑Index – der Präsentation befindet) an das Ende der Präsentation geklont.

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klonen Sie die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Schreiben Sie die geänderte Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Eine Folie an eine andere Position innerhalb einer Präsentation klonen**
Wenn Sie eine Folie klonen und anschließend in derselben Präsentationsdatei, jedoch an einer anderen Position, verwenden möchten, verwenden Sie die [insertClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse.  
2. Instanziieren Sie die Klasse, indem Sie auf die [**Slides**](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getSlides--)‑Sammlung verweisen, die vom [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Objekt bereitgestellt wird.  
3. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [insertClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [insertClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode.  
4. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir eine Folie (die sich an Index 1 – Position 2 – der Präsentation befindet) zu Index 2 – Position 3 – der Präsentation geklont.

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Abrufen der Folien-Sammlung in der Präsentation
    ISlideCollection slds = pres.getSlides();

    // Klonen der gewünschten Folie an den angegebenen Index in derselben Präsentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Schreiben Sie die geänderte Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Eine Folie am Ende einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.  
2. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.  
3. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection)‑Klasse, indem Sie auf die [**Slides**](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getSlides--)‑Sammlung verweisen, die vom Präsentationsobjekt der Zielpräsentation bereitgestellt wird.  
4. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode.  
5. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanziieren Sie die Presentation-Klasse für die Ziel-PPTX (in die die Folie geklont werden soll)
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

## **Eine Folie an eine andere Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.  
2. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.  
3. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getSlides--)‑Klasse, indem Sie auf die Slides‑Sammlung verweisen, die vom Präsentationsobjekt der Zielpräsentation bereitgestellt wird.  
4. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [insertClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [insertClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑Methode.  
5. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem Null‑Index der Quellpräsentation) zu Index 1 (Position 2) der Zielpräsentation geklont.

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanziieren Sie die Presentation-Klasse für die Ziel-PPTX (in die die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Klonen Sie die gewünschte Folie aus der Quellpräsentation an den angegebenen Index in der Zielpräsentation
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Schreiben Sie die Zielpräsentation auf die Festplatte
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Eine Folie zusammen mit ihrer Masterfolie in eine andere Präsentation klonen**
Wenn Sie eine Folie zusammen mit einer Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden möchten, müssen Sie zunächst die gewünschte Masterfolie von der Quellpräsentation in die Zielpräsentation klonen. Anschließend verwenden Sie diese Masterfolie für das Klonen der Folie mit Master. Die Methode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) erwartet eine Masterfolie aus der Zielpräsentation, nicht aus der Quellpräsentation. Gehen Sie dafür wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.  
2. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Klasse, die die Zielpräsentation enthält, zu der die Folie geklont werden soll.  
3. Greifen Sie auf die zu klonende Folie zusammen mit ihrer Masterfolie zu.  
4. Instanziieren Sie die [IMasterSlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/IMasterSlideCollection)‑Klasse, indem Sie auf die Masters‑Sammlung verweisen, die vom [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Objekt der Zielpräsentation bereitgestellt wird.  
5. Rufen Sie die von dem [IMasterSlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/IMasterSlideCollection)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode auf und übergeben Sie die Masterfolie aus der Quell‑PPTX, die geklont werden soll, als Parameter an die [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-)‑Methode.  
6. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getSlides--)‑Klasse, indem Sie die Referenz auf die Slides‑Sammlung setzen, die vom [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation)‑Objekt der Zielpräsentation bereitgestellt wird.  
7. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getSlides--)‑Objekt bereitgestellte [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation, die geklont werden soll, zusammen mit der Masterfolie als Parameter an die [addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-)‑Methode.  
8. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie mit einer Masterfolie (die sich am Null‑Index der Quellpräsentation befindet) an das Ende der Zielpräsentation geklont, wobei die Masterfolie aus der Quellfolie verwendet wurde.

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instanziieren Sie die Presentation-Klasse für die Zielpräsentation (in die die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Instanziieren Sie ISlide aus der Foliensammlung der Quellpräsentation zusammen mit
        // Masterfolie
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klonen Sie die gewünschte Masterfolie aus der Quellpräsentation in die Mastersammlung der
        // Zielpräsentation
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // Klonen Sie die gewünschte Folie aus der Quellpräsentation mit der gewünschten Masterfolie an das Ende der
        // Foliensammlung in der Zielpräsentation
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // Speichern Sie die Zielpräsentation auf die Festplatte
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Eine Folie am Ende eines bestimmten Abschnitts klonen**
Wenn Sie eine Folie klonen und anschließend in derselben Präsentationsdatei, jedoch in einem anderen Abschnitt, verwenden möchten, verwenden Sie die [**addClone**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)‑Methode, die vom [**ISlideCollection**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlideCollection)‑Interface bereitgestellt wird. Aspose.Slides for Java ermöglicht das Klonen einer Folie aus dem ersten Abschnitt und das Einfügen dieser geklonten Folie in den zweiten Abschnitt derselben Präsentation.

Der folgende Code‑Auszug zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // Speichern Sie die Zielpräsentation auf die Festplatte
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Übereinstimmende Foliengröße sicherstellen**

Wenn Sie Folien in eine andere Präsentation klonen, stellen Sie sicher, dass die Zielpräsentation dieselbe Foliengröße wie die Quelle hat. Bei unterschiedlichen Foliengrößen skaliert Aspose.Slides die geklonten Formen nicht automatisch – ihre ursprünglichen Koordinaten und Abmessungen bleiben erhalten, was dazu führen kann, dass Inhalte falsch ausgerichtet sind oder über die Folienränder hinausgehen.

Sie können die Foliengröße der Zielpräsentation vor dem Klonen von Master und Folie wie folgt festlegen:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Tun Sie dies, bevor Sie den Master und die Folie klonen.

## **FAQ**

**Werden Sprecher‑Notizen und Review‑Kommentare geklont?**

Ja. Die Notizenseite und Review‑Kommentare sind im Klon enthalten. Wenn Sie diese nicht wünschen, [entfernen Sie sie](/slides/de/java/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagrammobjekt, die Formatierung und eingebetteten Daten werden kopiert. Ist das Diagramm mit einer externen Quelle (z. B. einer OLE‑eingebetteten Arbeitsmappe) verknüpft, bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/java/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten prüfen.

**Kann ich die Einfügeposition und Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewünschten [Abschnitt](/slides/de/java/slide-section/) verschieben. Existiert der Zielabschnitt nicht, erstellen Sie ihn zuerst und verschieben Sie dann die Folie hinein.
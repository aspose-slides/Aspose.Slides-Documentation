---
title: Präsentationsfolien auf Android klonen
linktitle: Folien klonen
type: docs
weight: 35
url: /de/androidjava/clone-slides/
keywords:
- Folien klonen
- Folien kopieren
- Folien speichern
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Duplizieren Sie PowerPoint-Folien mit Aspose.Slides für Android. Folgen Sie unseren klaren Java-Code-Beispielen, um die PPT-Erstellung in Sekunden zu automatisieren und manuelle Arbeit zu vermeiden."
---
## **Einführung**

Klonen ist der Vorgang, eine exakte Kopie oder ein Duplikat von etwas zu erstellen. Aspose.Slides für Android via Java ermöglicht es ebenfalls, eine Kopie oder einen Klon einer beliebigen Folie zu erstellen und diesen geklonten Folie in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Vorgang des Folienklonens erzeugt eine neue Folie, die von Entwicklern geändert werden kann, ohne die Originalfolie zu verändern. Es gibt mehrere mögliche Methoden, um eine Folie zu klonen:

- Klon am Ende innerhalb einer Präsentation.
- Klon an anderer Position innerhalb einer Präsentation.
- Klon am Ende in einer anderen Präsentation.
- Klon an anderer Position in einer anderen Präsentation.
- Klon an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides für Android via Java stellt die (eine Sammlung von [ISlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlide) Objekten), die vom [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Objekt bereitgestellt wird, die Methoden [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) und [insertClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) zur Verfügung, um die oben genannten Arten des Folienklonens auszuführen

## **Eine Folie am Ende einer Präsentation klonen**
Wenn Sie eine Folie klonen und anschließend in derselben Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten, verwenden Sie die Methode [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
1. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getSlides--) , indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Objekt bereitgestellte Slides‑Sammlung verweisen.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf, die vom Objekt [ISlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getSlides--) bereitgestellt wird, und übergeben Sie die zu klonende Folie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Schreiben Sie die geänderte Präsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (die an der ersten Position – Index 0 – der Präsentation liegt) an das Ende der Präsentation geklont.

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

## **Eine Folie an einer anderen Position innerhalb einer Präsentation klonen**
Wenn Sie eine Folie klonen und anschließend in derselben Präsentationsdatei, jedoch an einer anderen Position verwenden möchten, nutzen Sie die Methode [insertClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
1. Instanziieren Sie die Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Objekt bereitgestellte [**Slides**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getSlides--) Sammlung verweisen.
1. Rufen Sie die Methode [insertClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) auf, die vom Objekt [ISlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getSlides--) bereitgestellt wird, und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Im nachfolgenden Beispiel haben wir eine Folie (die am Index 1 – Position 2 – der Präsentation liegt) zu Index 2 – Position 3 – der Präsentation geklont.

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Holen Sie die Sammlung von Folien in derselben Präsentation
    ISlideCollection slds = pres.getSlides();

    // Klonen Sie die gewünschte Folie an den angegebenen Index in derselben Präsentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Schreiben Sie die geänderte Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Eine Folie am Ende einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation), die die Präsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation), die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection) , indem Sie auf die von dem Presentation‑Objekt der Zielpräsentation bereitgestellte [**Slides**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getSlides--) Sammlung verweisen.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf, die vom Objekt [ISlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getSlides--) bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die Methode [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (vom ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.

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

## **Eine Folie an einer anderen Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation), die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation), die die Präsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getSlides--) , indem Sie auf die von dem Presentation‑Objekt der Zielpräsentation bereitgestellte Slides‑Sammlung verweisen.
1. Rufen Sie die Methode [insertClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) auf, die vom Objekt [ISlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getSlides--) bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (vom Index 0 der Quellpräsentation) zu Index 1 (Position 2) der Zielpräsentation geklont.

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

## **Eine Folie an einer bestimmten Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie inklusive einer Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden müssen, müssen Sie zunächst die gewünschte Masterfolie von der Quellpräsentation zur Zielpräsentation klonen. Anschließend verwenden Sie diese Masterfolie, um die Folie mit Master zu klonen. Die Methode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) erwartet eine Masterfolie aus der Zielpräsentation und nicht aus der Quellpräsentation. Um die Folie mit einem Master zu klonen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation), die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation), die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
1. Greifen Sie auf die zu klonende Folie zusammen mit der Masterfolie zu.
1. Instanziieren Sie die Klasse [IMasterSlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IMasterSlideCollection) , indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Objekt der Zielpräsentation bereitgestellte Masters‑Sammlung verweisen.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf, die vom Objekt [IMasterSlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IMasterSlideCollection) bereitgestellt wird, und übergeben Sie den Master aus der Quell‑PPTX, der geklont werden soll, als Parameter an die Methode [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getSlides--) , indem Sie die Referenz auf die von dem [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) Objekt der Zielpräsentation bereitgestellte Slides‑Sammlung setzen.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) auf, die vom Objekt [ISlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getSlides--) bereitgestellt wird, und übergeben Sie die zu klonende Folie aus der Quellpräsentation sowie die Masterfolie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie mit einem Master (die am Index 0 der Quellpräsentation liegt) an das Ende der Zielpräsentation geklont, wobei der Master aus der Quellfolie verwendet wurde.

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instanziieren Sie die Presentation-Klasse für die Zielpräsentation (in die die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Instanziieren Sie ISlide aus der Folien‑Sammlung der Quellpräsentation zusammen mit
        // Master‑Folie
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klonen Sie die gewünschte Master‑Folie aus der Quellpräsentation in die Master‑Sammlung der
        // Zielpräsentation
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klonen Sie die gewünschte Folie aus der Quellpräsentation mit dem gewünschten Master an das Ende der
        // Folien‑Sammlung in der Zielpräsentation
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Speichern Sie die Zielpräsentation auf der Festplatte
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Eine Folie am Ende eines angegebenen Abschnitts klonen**
Wenn Sie eine Folie klonen und anschließend in derselben Präsentationsdatei, jedoch in einem anderen Abschnitt verwenden möchten, verwenden Sie die [**addClone**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) Methode, die vom [**ISlideCollection**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection) Interface bereitgestellt wird. Aspose.Slides für Android via Java ermöglicht das Klonen einer Folie aus dem ersten Abschnitt und das Einfügen dieser geklonten Folie in den zweiten Abschnitt derselben Präsentation.

Das folgende Code‑Snippet zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Speichern Sie die Zielpräsentation auf der Festplatte
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Übereinstimmende Foliengröße sicherstellen**

Beim Klonen von Folien in eine andere Präsentation stellen Sie sicher, dass die Zielpräsentation die gleiche Foliengröße wie die Quellpräsentation hat. Wenn die Foliengrößen unterschiedlich sind, skaliert Aspose.Slides die geklonten Formen nicht automatisch – deren ursprüngliche Koordinaten und Abmessungen bleiben erhalten, was dazu führen kann, dass Inhalte missaligned erscheinen oder über die Folienränder hinausgehen.

Sie können die Foliengröße der Zielpräsentation vor dem Klonen von Master und Folie an die Quelle anpassen:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Führen Sie dies vor dem Klonen des Masters und der Folie durch.

## **FAQ**

**Werden Sprechernotizen und Prüfkommentare geklont?**

Ja. Die Notizseite und die Prüfkommentare werden in den Klon übernommen. Wenn Sie sie nicht wünschen, [entfernen Sie sie](/slides/de/androidjava/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagrammobjekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als ein [OLE‑Objekt](/slides/de/androidjava/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten überprüfen.

**Kann ich die Einfügeposition und die Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewählten [Abschnitt](/slides/de/androidjava/slide-section/) legen. Wenn der Zielabschnitt nicht existiert, erstellen Sie ihn zunächst und verschieben dann die Folie hinein.
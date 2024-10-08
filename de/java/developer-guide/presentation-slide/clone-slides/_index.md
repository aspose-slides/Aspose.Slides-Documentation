---
title: Folien klonen
type: docs
weight: 35
url: /de/java/clone-slides/
---


## **Folien in der Präsentation klonen**
Klonen ist der Prozess, eine exakte Kopie oder Nachbildung von etwas zu erstellen. Aspose.Slides für Java ermöglicht es auch, eine Kopie oder einen Klon einer beliebigen Folie zu erstellen und diese geklonte Folie dann in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Prozess des Folienklonens erstellt eine neue Folie, die von Entwicklern modifiziert werden kann, ohne die Originalfolie zu ändern. Es gibt mehrere Möglichkeiten, eine Folie zu klonen:

- Klonen am Ende innerhalb einer Präsentation.
- Klonen an einer anderen Position innerhalb der Präsentation.
- Klonen am Ende in einer anderen Präsentation.
- Klonen an einer anderen Position in einer anderen Präsentation.
- Klonen an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides für Java stellt eine Sammlung von [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) Objekten, die vom [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Objekt bereitgestellt wird, die Methoden [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) und [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) zur Verfügung, um die oben genannten Arten von Folienklonungen durchzuführen.

## **Klonen am Ende innerhalb einer Präsentation**
Wenn Sie eine Folie klonen und dann am Ende der vorhandenen Folien innerhalb derselben Präsentationsdatei verwenden möchten, verwenden Sie die Methode [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Objekt bereitgestellte Sammlung von Folien verweisen.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Schreiben Sie die modifizierte Präsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (an erster Stelle – Null-Index – der Präsentation) am Ende der Präsentation geklont.

```java
// Instanziiere die Presentation Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klone die gewünschte Folie am Ende der Sammlung von Folien in derselben Präsentation
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Schreibe die modifizierte Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonen an einer anderen Position innerhalb der Präsentation**
Wenn Sie eine Folie klonen und dann innerhalb derselben Präsentationsdatei an einer anderen Position verwenden möchten, verwenden Sie die Methode [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) :

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Instanziieren Sie die Klasse, indem Sie auf die [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) Sammlung verweisen, die vom [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Objekt bereitgestellt wird.
1. Rufen Sie die Methode [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Folie (am Null-Index – Position 1 – der Präsentation) an Index 1 – Position 2 – der Präsentation geklont.

```java
// Instanziiere die Presentation Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klone die gewünschte Folie am Ende der Sammlung von Folien in derselben Präsentation
    ISlideCollection slds = pres.getSlides();

    // Klone die gewünschte Folie an dem angegebenen Index in derselben Präsentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Schreibe die modifizierte Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonen am Ende in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse, die die Präsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt wird.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) Klasse, indem Sie auf die [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) Sammlung verweisen, die vom Präsentation Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die Methode [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (vom ersten Index der Quellpräsentation) am Ende der Zielpräsentation geklont.

```java
// Instanziiere die Presentation Klasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanziiere die Presentation Klasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Klone die gewünschte Folie aus der Quellpräsentation am Ende der Sammlung von Folien in der Zielpräsentation
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Schreibe die Zielpräsentation auf die Festplatte
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonen an einer anderen Position in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse, die die Präsentation enthält, zu der die Folie hinzugefügt wird.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) Klasse, indem Sie auf die von dem Präsentation Objekt der Zielpräsentation bereitgestellte Slides Sammlung verweisen.
1. Rufen Sie die Methode [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) .
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (vom Null-Index der Quellpräsentation) an Index 1 (Position 2) der Zielpräsentation geklont.

```java
// Instanziiere die Presentation Klasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanziiere die Presentation Klasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Klone die gewünschte Folie aus der Quellpräsentation am Ende der Sammlung von Folien in der Zielpräsentation
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

## **Klonen an einer bestimmten Position in einer anderen Präsentation**
Wenn Sie eine Folie mit einer Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden müssen, müssen Sie zunächst die gewünschte Masterfolie aus der Quellpräsentation in die Zielpräsentation klonen. Dann müssen Sie diese Masterfolie verwenden, um die Folie mit der Masterfolie zu klonen. Die [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) erwartet eine Masterfolie aus der Zielpräsentation und nicht aus der Quellpräsentation. Um die Folie mit einem Master zu klonen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse, die die Zielpräsentation enthält, in die die Folie geklont wird.
1. Greifen Sie auf die Folie zu, die geklont werden soll, zusammen mit der Masterfolie.
1. Instanziieren Sie die [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Objekt der Zielpräsentation bereitgestellte Masters Sammlung verweisen.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf, die vom [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) Objekt bereitgestellt wird, und übergeben Sie den Master von der Quell-PPTX, der geklont werden soll, als Parameter an die Methode [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Objekt der Zielpräsentation bereitgestellte Slides Sammlung verweisen.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation, die geklont werden soll, sowie die Masterfolie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie mit einem Master (an Null-Index der Quellpräsentation) am Ende der Zielpräsentation mit einer Masterfolie von der Quellfolie geklont.

```java
// Instanziiere die Presentation Klasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instanziiere die Presentation Klasse für die Zielpräsentation (wo die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Instanziiere ISlide aus der Sammlung von Folien in der Quellpräsentation zusammen mit
        // Masterfolie
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klone die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung von Masters in der
        // Zielpräsentation
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klone die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung von Masters in der
        // Zielpräsentation
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klone die gewünschte Folie aus der Quellpräsentation mit der gewünschten Masterfolie an das Ende der
        // Sammlung von Folien in der Zielpräsentation
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Speichere die Zielpräsentation auf der Festplatte
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonen am Ende im angegebenen Abschnitt**
Wenn Sie eine Folie klonen und dann innerhalb derselben Präsentationsdatei, jedoch in einem anderen Abschnitt verwenden möchten, verwenden Sie die [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) Methode, die vom [**ISlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) Interface bereitgestellt wird. Aspose.Slides für Java ermöglicht es, eine Folie aus dem ersten Abschnitt zu klonen und diese geklonte Folie dann in den zweiten Abschnitt derselben Präsentation einzufügen.

Der folgende Code-Snippet zeigt Ihnen, wie Sie eine Folie klonen und die geklonte Folie in einen bestimmten Abschnitt einfügen.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Abschnitt 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Abschnitt 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Speichere die Zielpräsentation auf der Festplatte
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
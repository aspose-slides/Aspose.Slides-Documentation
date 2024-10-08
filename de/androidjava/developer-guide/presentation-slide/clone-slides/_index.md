---
title: Folien klonen
type: docs
weight: 35
url: /de/androidjava/clone-slides/
---


## **Folien in der Präsentation klonen**
Klonen ist der Prozess, eine exakte Kopie oder Nachbildung von etwas zu erstellen. Aspose.Slides für Android über Java ermöglicht es, eine Kopie oder einen Klon einer beliebigen Folie zu erstellen und diese geklonte Folie dann in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Prozess des Folienklonens erstellt eine neue Folie, die von Entwicklern geändert werden kann, ohne die Originalfolie zu verändern. Es gibt mehrere mögliche Wege, eine Folie zu klonen:

- Klonen am Ende innerhalb einer Präsentation.
- Klonen an einer anderen Position innerhalb der Präsentation.
- Klonen am Ende in einer anderen Präsentation.
- Klonen an einer anderen Position in einer anderen Präsentation.
- Klonen an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides für Android über Java ermöglicht eine Sammlung von [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide)-Objekten, die durch das [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Objekt bereitgestellt wird, die Methoden [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) und [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) zur Durchführung der oben genannten Arten des Folienklonens.

## **Klonen am Ende innerhalb einer Präsentation**
Wenn Sie eine Folie klonen und dann am Ende der vorhandenen Folien innerhalb derselben Präsentationsdatei verwenden möchten, verwenden Sie die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode gemäß den nachstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.
1. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) durch Referenzierung der von dem [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Objekt bereitgestellten Folienkollektion.
1. Rufen Sie die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode ab, die von dem [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie als Parameter an die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode.
1. Schreiben Sie die bearbeitete Präsentationsdatei.

Im folgenden Beispiel haben wir eine Folie (die sich an der ersten Position – Null-Index – der Präsentation befindet) an das Ende der Präsentation geklont.

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klonen Sie die gewünschte Folie an das Ende der Sammlung von Folien in derselben Präsentation
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Schreiben Sie die bearbeitete Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonen an einer anderen Position innerhalb der Präsentation**
Wenn Sie eine Folie klonen und dann innerhalb derselben Präsentationsdatei, aber an einer anderen Position verwenden möchten, verwenden Sie die [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) Methode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse.
1. Instanziieren Sie die Klasse, indem Sie auf die [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) Sammlung zugreifen, die von dem [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Objekt bereitgestellt wird.
1. Rufen Sie die [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) Methode ab, die von dem [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) Methode.
1. Schreiben Sie die bearbeitete Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Folie (die sich an der Null-Index – Position 1 – der Präsentation befindet) an den Index 1 – Position 2 – der Präsentation geklont.

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klonen Sie die gewünschte Folie an das Ende der Sammlung von Folien in derselben Präsentation
    ISlideCollection slds = pres.getSlides();

    // Klonen Sie die gewünschte Folie an den angegebenen Index in derselben Präsentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Schreiben Sie die bearbeitete Präsentation auf die Festplatte
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klonen am Ende in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse, die die Präsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt wird.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) Klasse, indem Sie auf die [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) Sammlung zugreifen, die von dem Präsentationsobjekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode ab, die von dem [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode.
1. Schreiben Sie die bearbeitete Zielpräsentationsdatei.

Im folgenden Beispiel haben wir eine Folie (von der ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.

```java
// Instanziieren Sie die Präsentationsklasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanziieren Sie die Präsentationsklasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Klonen Sie die gewünschte Folie aus der Quellpräsentation an das Ende der Sammlung von Folien in der Zielpräsentation
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

## **Klonen an einer anderen Position in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse, die die Präsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) Klasse, indem Sie auf die Folienkollektion zugreifen, die von dem Präsentationsobjekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) Methode ab, die von dem [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) Methode.
1. Schreiben Sie die bearbeitete Zielpräsentationsdatei.

Im folgenden Beispiel haben wir eine Folie (von der Null-Index der Quellpräsentation) an den Index 1 (Position 2) der Zielpräsentation geklont.

```java
// Instanziieren Sie die Präsentationsklasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanziieren Sie die Präsentationsklasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Klonen Sie die gewünschte Folie aus der Quellpräsentation an das Ende der Sammlung von Folien in der Zielpräsentation
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Schreiben Sie die Zielpräsentation auf die Festplatte
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonen an einer bestimmten Position in einer anderen Präsentation**
Wenn Sie eine Folie mit einer Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden möchten, müssen Sie zuerst die gewünschte Masterfolie aus der Quellpräsentation in die Zielpräsentation klonen. Dann müssen Sie diese Masterfolie verwenden, um die Folie mit der Masterfolie zu klonen. Die [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) erwartet eine Masterfolie aus der Zielpräsentation und nicht aus der Quellpräsentation. Um die Folie mit einer Masterfolie zu klonen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)-Klasse, die die Zielpräsentation enthält, in die die Folie geklont werden soll.
1. Greifen Sie auf die Folie zu, die mit der Masterfolie geklont werden soll.
1. Instanziieren Sie die [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) Klasse, indem Sie auf die Masters-Sammlung zugreifen, die von dem [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode ab, die von dem [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) Objekt bereitgestellt wird, und übergeben Sie die Masterfolie aus der Quell-PPTX alsParameter an die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) Klasse, indem Sie die Referenz auf die Folienkollektion setzen, die von dem [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode ab, die von dem [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation, die geklont werden soll, und die Masterfolie als Parameter an die [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode.
1. Schreiben Sie die bearbeitete Zielpräsentationsdatei.

Im folgenden Beispiel haben wir eine Folie mit einer Masterfolie (die sich an der Null-Index der Quellpräsentation befindet) an das Ende der Zielpräsentation geklont, wobei wir eine Masterfolie von der Quellfolie verwendet haben.

```java
// Instanziieren Sie die Präsentationsklasse, um die Quellpräsentationsdatei zu laden
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instanziieren Sie die Präsentationsklasse für die Zielpräsentation (wo die Folie geklont werden soll)
    Presentation destPres = new Presentation();
    try {
        // Instanziieren Sie ISlide aus der Sammlung von Folien in der Quellpräsentation zusammen mit
        // Masterfolie
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klonen Sie die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung von Masterfolien in der
        // Zielpräsentation
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klonen Sie die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung von Masterfolien in der
        // Zielpräsentation
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klonen Sie die gewünschte Folie aus der Quellpräsentation mit der gewünschten Masterfolie an das Ende der
        // Sammlung von Folien in der Zielpräsentation
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Speichern Sie die Zielpräsentation auf die Festplatte
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klonen am Ende in einem angegebenen Abschnitt**
Wenn Sie eine Folie klonen und diese dann innerhalb derselben Präsentationsdatei, aber in einem anderen Abschnitt, verwenden möchten, verwenden Sie die [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) Methode, die von dem [**ISlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) Interface bereitgestellt wird. Aspose.Slides für Android über Java ermöglicht es, eine Folie aus dem ersten Abschnitt zu klonen und dann diese geklonte Folie in den zweiten Abschnitt derselben Präsentation einzufügen.

Der folgende Codeausschnitt zeigt Ihnen, wie Sie eine Folie klonen und die geklonte Folie in einen bestimmten Abschnitt einfügen.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Abschnitt 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Abschnitt 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Speichern Sie die Zielpräsentation auf die Festplatte
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
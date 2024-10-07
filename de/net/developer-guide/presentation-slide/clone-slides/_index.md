---
title: Folien klonen
type: docs
weight: 40
url: /net/clone-slides/
keywords: "Folien klonen, Folie kopieren, Folienkopie speichern, PowerPoint, Präsentation, C#, Csharp, .NET, Aspose.Slides"
description: "Klonen einer PowerPoint-Folie in C# oder .NET"
---

## **Folien in Präsentationen klonen**
Klonen ist der Prozess, eine exakte Kopie oder Nachbildung von etwas zu erstellen. Aspose.Slides für .NET ermöglicht es auch, eine Kopie oder Klon jeder Folie zu erstellen und diese geklonte Folie dann in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Prozess des Folienklonens erstellt eine neue Folie, die von Entwicklern modifiziert werden kann, ohne die ursprüngliche Folie zu ändern. Es gibt mehrere mögliche Methoden, um eine Folie zu klonen:

- Klonen am Ende innerhalb einer Präsentation.
- Klonen an einer anderen Position innerhalb der Präsentation.
- Klonen am Ende in einer anderen Präsentation.
- Klonen an einer anderen Position in einer anderen Präsentation.
- Klonen an einer bestimmten Position in einer anderen Präsentation.

Im Aspose.Slides für .NET (eine Sammlung von [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) Objekten), die vom [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt bereitgestellt wird, stehen die Methoden [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) und [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) zur Verfügung, um die oben genannten Arten des Folienklonens durchzuführen.

## **Klonen am Ende innerhalb einer Präsentation**
Wenn Sie eine Folie klonen und dann am Ende der vorhandenen Folien im selben Präsentationsdatei verwenden möchten, verwenden Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) Methode gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt bereitgestellte Folienkollektion verweisen.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Objekt bereitgestellt wird und übergeben Sie die zu klonende Folie als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) Methode.
1. Schreiben Sie die modifizierte Präsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (die sich an der ersten Position – Index null – der Präsentation befindet) am Ende der Präsentation geklont.

```c#
// Präsentationsklasse instanziieren, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Die gewünschte Folie am Ende der Folienkollektion in derselben Präsentation klonen
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Die modifizierte Präsentation auf die Festplatte schreiben
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **Klonen an einer anderen Position innerhalb der Präsentation**
Wenn Sie eine Folie klonen und dann in derselben Präsentationsdatei, aber an einer anderen Position verwenden möchten, verwenden Sie die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) Methode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Instanziieren Sie die Klasse, indem Sie auf die **Folien** Sammlung verweisen, die vom [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt bereitgestellt wird.
1. Rufen Sie die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) Methode.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Folie (die sich am Index null – Position 1 – der Präsentation befindet) an den Index 1 – Position 2 – der Präsentation geklont.

```c#
// Präsentationsklasse instanziieren, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Die gewünschte Folie am Ende der Folienkollektion in derselben Präsentation klonen
    ISlideCollection slds = pres.Slides;

    // Die gewünschte Folie an dem angegebenen Index in derselben Präsentation klonen
    slds.InsertClone(2, pres.Slides[1]);

    // Die modifizierte Präsentation auf die Festplatte schreiben
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **Klonen am Ende in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Präsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt wird.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Klasse, indem Sie auf die **Folien** Sammlung verweisen, die vom Präsentationsobjekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) Methode.
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem ersten Index der Quellpräsentation) am Ende der Zielpräsentation geklont.

```c#
// Präsentationsklasse instanziieren, um die Quelldatei zu laden
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Präsentationsklasse für die Ziel-PPTX instanziieren (wo die Folie geklont werden soll)
    using (Presentation destPres = new Presentation())
    {
        // Die gewünschte Folie von der Quellpräsentation ans Ende der Folienkollektion der Zielpräsentation klonen
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Die Zielpräsentation auf die Festplatte schreiben
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Klonen an einer anderen Position in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Präsentation enthält, zu der die Folie hinzugefügt wird.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Klasse, indem Sie auf die von dem Präsentationsobjekt der Zielpräsentation bereitgestellte Folienkollektion zugreifen.
1. Rufen Sie die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) Methode.
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem Index null der Quellpräsentation) an den Index 1 (Position 2) der Zielpräsentation geklont.

```c#
// Präsentationsklasse instanziieren, um die Quelldatei zu laden
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Präsentationsklasse für die Ziel-PPTX instanziieren (wo die Folie geklont werden soll)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Die Zielpräsentation auf die Festplatte schreiben
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Klonen an einer bestimmten Position in einer anderen Präsentation**
Wenn Sie eine Folie mit einer Masterfolie aus einer Präsentation klonen und diese in einer anderen Präsentation verwenden müssen, müssen Sie zuerst die gewünschte Masterfolie von der Quellpräsentation in die Zielpräsentation klonen. Dann müssen Sie diese Masterfolie verwenden, um die Folie mit der Masterfolie zu klonen. Die **AddClone(ISlide, IMasterSlide)** Methode erwartet eine Masterfolie von der Zielpräsentation und nicht von der Quellpräsentation. Um die Folie mit einer Master zu klonen, folgen Sie bitte den unten stehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, die die Zielpräsentation enthält, in die die Folie geklont wird.
1. Greifen Sie auf die Folie zu, die geklont werden soll, zusammen mit der Masterfolie.
1. Instanziieren Sie die [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) Klasse, indem Sie auf die Masters Sammlung verweisen, die vom [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) Methode auf, die vom [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) Objekt bereitgestellt wird, und übergeben Sie die Masterfolie von der Quell-PPTX, die geklont werden soll, als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) Methode.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Klasse, indem Sie die Referenz auf die von dem [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt der Zielpräsentation bereitgestellte Folienkollektion festlegen.
1. Rufen Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) Methode auf, die vom [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation, die geklont werden soll, sowie die Masterfolie als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) Methode.
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie mit einer Master (die sich am Index null der Quellpräsentation befindet) am Ende der Zielpräsentation unter Verwendung einer Masterfolie aus der Quellfolie geklont.

```c#
// Präsentationsklasse instanziieren, um die Quelldatei zu laden
using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Präsentationsklasse für die Zielpräsentation instanziieren (wo die Folie geklont werden soll)
    using (Presentation destPres = new Presentation())
    {

        // Instanziieren von ISlide aus der Sammlung von Folien in der Quelle zusammen mit
        // Masterfolie
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klonen der gewünschten Masterfolie von der Quellpräsentation in die Mastersammlung der
        // Zielpräsentation
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klonen der gewünschten Masterfolie von der Quellpräsentation in die Mastersammlung der
        // Zielpräsentation
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Klonen der gewünschten Folie von der Quellpräsentation mit der gewünschten Masterfolie an das Ende der
        // Sammlung von Folien in der Zielpräsentation
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Die gewünschte Masterfolie von der Quellpräsentation an die Mastersammlung der
        // Zielpräsentation klonen
        // Speichern der Zielpräsentation auf der Festplatte
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```



## Klonen am Ende im angegebenen Abschnitt

Mit Aspose.Slides für .NET können Sie eine Folie aus einem Abschnitt einer Präsentation klonen und die Folie in einen anderen Abschnitt derselben Präsentation einfügen. In diesem Fall müssen Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) Methode von der [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Schnittstelle verwenden. 

Dieser C#-Code zeigt Ihnen, wie man eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügt:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // zu klonende Folie
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```
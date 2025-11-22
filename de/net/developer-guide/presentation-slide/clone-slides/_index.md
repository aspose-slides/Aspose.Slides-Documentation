---
title: Folien klonen
type: docs
weight: 40
url: /de/net/clone-slides/
keywords: "Folien klonen, Folie kopieren, Folienkopie speichern, PowerPoint, Presentation, C#, Csharp, .NET, Aspose.Slides"
description: "PowerPoint-Folie in C# oder .NET klonen"
---

## **Folien in einer Präsentation klonen**
Cloning ist der Vorgang, eine exakte Kopie oder ein Duplikat von etwas zu erstellen. Aspose.Slides for .NET ermöglicht es ebenfalls, eine Kopie oder einen Klon einer beliebigen Folie zu erstellen und diesen geklonten Folie in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Vorgang des Folienklonens erzeugt eine neue Folie, die von Entwicklern geändert werden kann, ohne die Originalfolie zu verändern. Es gibt mehrere mögliche Methoden, eine Folie zu klonen:

- Klon am Ende innerhalb einer Präsentation.
- Klon an anderer Position innerhalb einer Präsentation.
- Klon am Ende in einer anderen Präsentation.
- Klon an anderer Position in einer anderen Präsentation.
- Klon an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides for .NET stellt die (eine Sammlung von [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) Objekte), die vom [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt bereitgestellt wird, die Methoden [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) und [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) zur Verfügung, um die oben genannten Arten des Folienklonens auszuführen
## **Klon am Ende innerhalb einer Präsentation**
Wenn Sie eine Folie klonen und sie anschließend in derselben Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten, verwenden Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)‑Methode gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) , indem Sie auf die von dem Objekt [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) bereitgestellte Slides‑Sammlung verweisen.
3. Rufen Sie die vom Objekt [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) bereitgestellte [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)‑Methode auf und übergeben Sie die zu klonende Folie als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)‑Methode.
4. Schreiben Sie die geänderte Präsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (die sich an der ersten Position – Index 0 – der Präsentation befindet) an das Ende der Präsentation geklont.
```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Klonen Sie die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Speichern Sie die modifizierte Präsentation auf der Festplatte
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```



## **Klon an anderer Position innerhalb einer Präsentation**
Wenn Sie eine Folie klonen und sie anschließend in derselben Präsentationsdatei, jedoch an einer anderen Position verwenden möchten, verwenden Sie die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)‑Methode:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Instanziieren Sie die Klasse, indem Sie auf die **Slides**‑Sammlung verweisen, die vom Objekt [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) bereitgestellt wird.
3. Rufen Sie die vom Objekt [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) bereitgestellte [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)‑Methode auf und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)‑Methode.
4. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir eine Folie (die sich am Index 0 – Position 1 – der Präsentation befindet) auf Index 1 – Position 2 – der Präsentation geklont.
```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Klonen Sie die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    ISlideCollection slds = pres.Slides;

    // Klonen Sie die gewünschte Folie an den angegebenen Index in derselben Präsentation
    slds.InsertClone(2, pres.Slides[1]);

    // Speichern Sie die modifizierte Präsentation auf der Festplatte
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```



## **Klon am Ende in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und sie in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), die die Präsentation enthält, aus der die Folie geklont werden soll.
2. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
3. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) , indem Sie auf die **Slides**‑Sammlung verweisen, die vom Presentation‑Objekt der Zielpräsentation bereitgestellt wird.
4. Rufen Sie die vom Objekt [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) bereitgestellte [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)‑Methode.
5. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (vom ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.
```c#
// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanziieren Sie die Presentation-Klasse für das Zielformat PPTX (wo die Folie geklont werden soll)
    using (Presentation destPres = new Presentation())
    {
        // Klonen Sie die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Schreiben Sie die Zielpräsentation auf die Festplatte
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```



## **Klon an anderer Position in einer anderen Präsentation**
Wenn Sie eine Folie aus einer Präsentation klonen und sie in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
2. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), die die Präsentation enthält, zu der die Folie hinzugefügt werden soll.
3. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) , indem Sie auf die Slides‑Sammlung verweisen, die vom Presentation‑Objekt der Zielpräsentation bereitgestellt wird.
4. Rufen Sie die vom Objekt [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) bereitgestellte [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)‑Methode.
5. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (vom Index 0 der Quellpräsentation) auf Index 1 (Position 2) der Zielpräsentation geklont.
```c#
// Instanziieren Sie die Presentation‑Klasse, um die Quellpräsentationsdatei zu laden
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanziieren Sie die Presentation‑Klasse für die Ziel‑PPTX (wo die Folie geklont werden soll)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Schreiben Sie die Zielpräsentation auf die Festplatte
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```



## **Klon an einer bestimmten Position in einer anderen Präsentation**
Wenn Sie eine Folie mit einer Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden müssen, müssen Sie zunächst die gewünschte Masterfolie von der Quellpräsentation in die Zielpräsentation klonen. Anschließend verwenden Sie diese Masterfolie, um die Folie mit Master zu klonen. Die Methode **AddClone(ISlide, IMasterSlide)** erwartet eine Masterfolie aus der Zielpräsentation und nicht aus der Quellpräsentation. Um die Folie mit einem Master zu klonen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
2. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
3. Greifen Sie auf die zu klonende Folie zusammen mit der Masterfolie zu.
4. Instanziieren Sie die Klasse [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) , indem Sie auf die Masters‑Sammlung verweisen, die vom Objekt [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) der Zielpräsentation bereitgestellt wird.
5. Rufen Sie die vom Objekt [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) bereitgestellte [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)‑Methode auf und übergeben Sie den Master aus der Quell‑PPTX, der geklont werden soll, als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)‑Methode.
6. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) , indem Sie die Referenz auf die Slides‑Sammlung setzen, die vom Objekt [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) der Zielpräsentation bereitgestellt wird.
7. Rufen Sie die vom Objekt [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) bereitgestellte [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)‑Methode auf und übergeben Sie die Folie aus der Quellpräsentation, die geklont werden soll, sowie die Masterfolie als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)‑Methode.
8. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie mit einem Master (die sich am Index 0 der Quellpräsentation befindet) an das Ende der Zielpräsentation geklont, wobei der Master aus der Quellfolie verwendet wurde.
```c#
// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instanziieren Sie die Presentation-Klasse für die Zielpräsentation (in der die Folie geklont werden soll)
    using (Presentation destPres = new Presentation())
    {

        // Instanziieren Sie ISlide aus der Foliensammlung der Quellpräsentation zusammen mit
        // Masterfolie
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klonen Sie die gewünschte Masterfolie von der Quellpräsentation in die Sammlung der Masterfolien in der
        // Zielpräsentation
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klonen Sie die gewünschte Masterfolie von der Quellpräsentation in die Sammlung der Masterfolien in der
        // Zielpräsentation
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Klonen Sie die gewünschte Folie aus der Quellpräsentation mit der gewünschten Masterfolie an das Ende der
        // Sammlung der Folien in der Zielpräsentation
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Klonen Sie die gewünschte Masterfolie von der Quellpräsentation in die Sammlung der Masterfolien in der // Zielpräsentation
        // Speichern Sie die Zielpräsentation auf der Festplatte
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```




## **Klon am Ende in einem angegebenen Abschnitt**
Mit Aspose.Slides for .NET können Sie eine Folie aus einem Abschnitt einer Präsentation klonen und diese Folie in einen anderen Abschnitt derselben Präsentation einfügen. In diesem Fall müssen Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)‑Methode aus dem Interface [ISlideCollection] verwenden. 

Dieser C#‑Code zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // zum Klonen
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Werden Sprecher‑Notizen und Prüferkommentare geklont?**

Ja. Die Notizenseite und Prüferkommentare sind im Klon enthalten. Wenn Sie sie nicht wünschen, [entfernen Sie sie](/slides/de/net/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagrammobjekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/net/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten überprüfen.

**Kann ich die Einfügeposition und Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folienindex einfügen und in einen ausgewählten [Abschnitt](/slides/de/net/slide-section/) platzieren. Wenn der Zielabschnitt nicht existiert, erstellen Sie ihn zuerst und verschieben Sie anschließend die Folie dorthin.
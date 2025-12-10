---
title: "Präsentationsfolien klonen in .NET"
linktitle: "Folien klonen"
type: docs
weight: 40
url: /de/net/clone-slides/
keywords:
- "Folie klonen"
- "Folie kopieren"
- "Folie speichern"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Duplizieren Sie PowerPoint‑Folien schnell mit Aspose.Slides für .NET. Folgen Sie unseren klaren Code‑Beispielen, um die PPT‑Erstellung in Sekunden zu automatisieren und manuelle Arbeit zu vermeiden."
---

## **Folien in einer Präsentation klonen**
Klonen ist der Vorgang, bei dem eine exakte Kopie oder ein Duplikat von etwas erstellt wird. Aspose.Slides für .NET ermöglicht es zudem, jede Folie zu kopieren oder zu klonen und das geklonte Objekt in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Vorgang des Folienklonens erzeugt eine neue Folie, die Entwickler ändern können, ohne die Originalfolie zu beeinflussen. Es gibt mehrere mögliche Methoden, eine Folie zu klonen:

- Klon am Ende innerhalb einer Präsentation.
- Klon an einer anderen Position innerhalb einer Präsentation.
- Klon am Ende in einer anderen Präsentation.
- Klon an einer anderen Position in einer anderen Präsentation.
- Klon an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides für .NET stellt die (eine Sammlung von [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)-Objekten), die vom [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekt bereitgestellt wird, die Methoden [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) und [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) zur Verfügung, um die oben genannten Klon‑Typen auszuführen.
## **Eine Folie am Ende einer Präsentation klonen**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten, nutzen Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)-Methode gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.  
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekt bereitgestellte Folien‑Sammlung verweisen.  
1. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Objekt bereitgestellte [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)-Methode auf und übergeben Sie die zu klonende Folie als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)-Methode.  
1. Schreiben Sie die modifizierte Präsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (die an erster Stelle – Index 0 – der Präsentation liegt) an das Ende der Präsentation geklont.
```c#
 // Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert
 using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
 {
 
     // Klonen Sie die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
     ISlideCollection slds = pres.Slides;
 
     slds.AddClone(pres.Slides[0]);
 
     // Schreiben Sie die modifizierte Präsentation auf die Festplatte
     pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
 
 }
```



## **Eine Folie an einer anderen Position innerhalb einer Präsentation klonen**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei, jedoch an einer anderen Position verwenden möchten, nutzen Sie die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)-Methode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.  
1. Instanziieren Sie die Klasse, indem Sie auf die **Slides**‑Sammlung verweisen, die vom [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekt bereitgestellt wird.  
1. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Objekt bereitgestellte [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)-Methode auf und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)-Methode.  
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Folie (die am Index 0 – Position 1 – der Präsentation liegt) zu Index 1 – Position 2 – der Präsentation geklont.
```c#
 // Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Klonen Sie die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    ISlideCollection slds = pres.Slides;

    // Klonen Sie die gewünschte Folie an den angegebenen Index in derselben Präsentation
    slds.InsertClone(2, pres.Slides[1]);

    // Schreiben Sie die modifizierte Präsentation auf die Festplatte
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```



## **Eine Folie am Ende einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien einfügen möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.  
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.  
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Klasse, indem Sie auf die **Slides**‑Sammlung verweisen, die vom Presentation‑Objekt der Zielpräsentation bereitgestellt wird.  
1. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Objekt bereitgestellte [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)-Methode auf und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)-Methode.  
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.
```c#
// Instanziieren Sie die Presentation‑Klasse, um die Quellpräsentationsdatei zu laden
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanziieren Sie die Presentation‑Klasse für die Ziel‑PPTX (wo die Folie geklont werden soll)
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



## **Eine Folie an einer anderen Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position einfügen möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.  
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.  
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Klasse, indem Sie auf die Slides‑Sammlung verweisen, die vom Presentation‑Objekt der Zielpräsentation bereitgestellt wird.  
1. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Objekt bereitgestellte [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)-Methode auf und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1)-Methode.  
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem Index 0 der Quellpräsentation) zu Index 1 (Position 2) der Zielpräsentation geklont.
```c#
// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Instanziieren Sie die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Schreiben Sie die Zielpräsentation auf die Festplatte
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```



## **Eine Folie an einer bestimmten Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie mit einer Master‑Folie aus einer Präsentation in eine andere Präsentation klonen möchten, müssen Sie zuerst die gewünschte Master‑Folie aus der Quellpräsentation in die Zielpräsentation klonen. Anschließend verwenden Sie diese Master‑Folie, um die Folie mit Master zu klonen. Die **AddClone(ISlide, IMasterSlide)**‑Methode erwartet eine Master‑Folie aus der Zielpräsentation und nicht aus der Quelle. Um die Folie mit Master zu klonen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.  
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse, die die Zielpräsentation enthält, zu der die Folie geklont wird.  
1. Greifen Sie auf die zu klonende Folie zusammen mit ihrer Master‑Folie zu.  
1. Instanziieren Sie die [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)-Klasse, indem Sie auf die Masters‑Sammlung verweisen, die vom [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekt der Zielpräsentation bereitgestellt wird.  
1. Rufen Sie die von dem [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)-Objekt bereitgestellte [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)-Methode auf und übergeben Sie den Master aus der Quell‑PPTX, der geklont werden soll, als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)-Methode.  
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Klasse, indem Sie die Referenz auf die Slides‑Sammlung setzen, die vom [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekt der Zielpräsentation bereitgestellt wird.  
1. Rufen Sie die von dem [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Objekt bereitgestellte [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)-Methode auf und übergeben Sie die zu klonende Folie aus der Quellpräsentation sowie die Master‑Folie als Parameter an die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)-Methode.  
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie mit Master (die am Index 0 der Quellpräsentation liegt) an das Ende der Zielpräsentation geklont, wobei der Master aus der Quell‑Folie verwendet wurde.
```c#
// Instanziieren Sie die Presentation-Klasse, um die Quellpräsentationsdatei zu laden

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instanziieren Sie die Presentation-Klasse für die Zielpräsentation (in die die Folie geklont werden soll)
    using (Presentation destPres = new Presentation())
    {

        // Instanziieren Sie ISlide aus der Foliensammlung der Quellpräsentation zusammen mit
        // Masterfolie
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klonen Sie die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung der Masterfolien in der
        // Zielpräsentation
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klonen Sie die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung der Masterfolien in der
        // Zielpräsentation
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Klonen Sie die gewünschte Folie aus der Quellpräsentation mit dem gewünschten Master an das Ende der
        // Foliensammlung in der Zielpräsentation
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Klonen Sie die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung der Masterfolien in der // Zielpräsentation
        // Speichern Sie die Zielpräsentation auf der Festplatte
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```




## **Eine Folie am Ende eines angegebenen Abschnitts klonen**

Mit Aspose.Slides für .NET können Sie eine Folie aus einem Abschnitt einer Präsentation klonen und diese Folie in einen anderen Abschnitt derselben Präsentation einfügen. Hierfür verwenden Sie die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index)-Methode des [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Interfaces.

Der folgende C#‑Code zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen:
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

**Werden Sprecher‑Notizen und Review‑Kommentare geklont?**

Ja. Die Notizenseite und die Review‑Kommentare werden mit geklont. Wenn Sie diese nicht benötigen, [entfernen Sie sie](/slides/de/net/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und ihre Datenquellen behandelt?**

Das Diagramm‑Objekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle (z. B. einer OLE‑eingebetteten Arbeitsmappe) verknüpft war, bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/net/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit prüfen und das Aktualisierungsverhalten testen.

**Kann ich die Einfügeposition und die Abschnitte für das Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen ausgewählten [Abschnitt](/slides/de/net/slide-section/) verschieben. Existiert der Ziel‑Abschnitt nicht, erstellen Sie ihn zuerst und verschieben anschließend die Folie dorthin.
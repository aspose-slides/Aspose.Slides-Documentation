---
title: Folien einer Präsentation in .NET klonen
linktitle: Folien klonen
type: docs
weight: 40
url: /de/net/clone-slides/
keywords:
- Folie klonen
- Folie kopieren
- Folie speichern
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Duplizieren Sie PowerPoint-Folien schnell mit Aspose.Slides für .NET. Folgen Sie unseren klaren Codebeispielen, um die PPT-Erstellung in Sekunden zu automatisieren und manuelle Arbeit zu eliminieren."
---
## **Einleitung**

Klonen ist der Vorgang, eine exakte Kopie oder ein Duplikat von etwas zu erstellen. Aspose.Slides ermöglicht es Ihnen außerdem, jede Folie zu kopieren (zu klonen) und die geklonte Folie in die aktuelle Präsentation oder eine andere geöffnete Präsentation einzufügen. Das Klonen von Folien erzeugt eine neue Folie, die Entwickler ändern können, ohne die Originalfolie zu beeinflussen. Es gibt mehrere Möglichkeiten, eine Folie zu klonen:

- Folie am Ende einer Präsentation klonen.
- Folie an einer anderen Position innerhalb einer Präsentation klonen.
- Folie am Ende einer anderen Präsentation klonen.
- Folie an einer anderen Position in einer anderen Präsentation klonen.
- Folie zusammen mit ihrer Masterfolie in eine andere Präsentation klonen.

In Aspose.Slides für .NET stellt die Folienkollektion (eine Sammlung von [ISlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide/) Objekten), die vom [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Objekt bereitgestellt wird, die Methoden [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/addclone/) und [InsertClone](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/insertclone/) zur Verfügung, um die oben beschriebenen Folienklon‑Operationen auszuführen.

## **Klonen einer Folie am Ende einer Präsentation**

Wenn Sie eine Folie klonen und anschließend im selben Präsentationsfile am Ende der vorhandenen Folien verwenden möchten, benutzen Sie die Methode [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/methods/addclone/index) gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) .
2. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection) , indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Objekt bereitgestellte Slides‑Sammlung verweisen.
3. Rufen Sie die Methode [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/methods/addclone/index) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie als Parameter an die Methode [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/methods/addclone/index) .
4. Schreiben Sie die modifizierte Präsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (die an der ersten Position – Index 0 – der Präsentation liegt) an das Ende der Präsentation geklont.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Klonen Sie die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Schreiben Sie die modifizierte Präsentation auf die Festplatte
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Klonen einer Folie an einer anderen Position innerhalb einer Präsentation**

Wenn Sie eine Folie klonen und anschließend im selben Präsentationsfile, jedoch an einer anderen Position, verwenden möchten, benutzen Sie die Methode [InsertClone](https://reference.aspose.com/slides/de/net/aspose.slides.ishapecollection/insertclone/methods/1) :

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) .
2. Instanziieren Sie die Klasse, indem Sie auf die **Slides**‑Sammlung verweisen, die vom [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Objekt bereitgestellt wird.
3. Rufen Sie die Methode [InsertClone](https://reference.aspose.com/slides/de/net/aspose.slides.ishapecollection/insertclone/methods/1) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die Methode [InsertClone](https://reference.aspose.com/slides/de/net/aspose.slides.ishapecollection/insertclone/methods/1) .
4. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir eine Folie (die an Index 1 – Position 2 – der Präsentation liegt) zu Index 2 – Position 3 – der Präsentation geklont.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Klonen einer Folie am Ende einer anderen Präsentation**

Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) , die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
2. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) , die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
3. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection) , indem Sie auf die **Slides**‑Sammlung verweisen, die vom Presentation‑Objekt der Zielpräsentation bereitgestellt wird.
4. Rufen Sie die Methode [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/methods/addclone/index) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die Methode [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/methods/addclone/index) .
5. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (aus dem ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Klonen einer Folie an einer anderen Position in einer anderen Präsentation**

Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden möchten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) , die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
2. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) , die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
3. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection) , indem Sie auf die Slides‑Sammlung verweisen, die vom Presentation‑Objekt der Zielpräsentation bereitgestellt wird.
4. Rufen Sie die Methode [InsertClone](https://reference.aspose.com/slides/de/net/aspose.slides.ishapecollection/insertclone/methods/1) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die Methode [InsertClone](https://reference.aspose.com/slides/de/net/aspose.slides.ishapecollection/insertclone/methods/1) .
5. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (aus dem Index 0 der Quellpräsentation) zu Index 1 (Position 2) der Zielpräsentation geklont.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Klonen einer Folie mit ihrer Masterfolie in eine andere Präsentation**

Wenn Sie eine Folie zusammen mit einer Masterfolie aus einer Präsentation klonen und in eine andere Präsentation einfügen möchten, müssen Sie zunächst die gewünschte Masterfolie von der Quell‑ in die Zielpräsentation klonen. Anschließend verwenden Sie diese Masterfolie für das Klonen der Folie mit Master. Die Methode **AddClone(ISlide, IMasterSlide)** erwartet eine Masterfolie aus der Zielpräsentation und nicht aus der Quellpräsentation. So klonen Sie die Folie mit Master:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) , die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
2. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) , die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
3. Greifen Sie auf die zu klonende Folie sowie deren Masterfolie zu.
4. Instanziieren Sie die Klasse [IMasterSlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection) , indem Sie auf die Masters‑Sammlung verweisen, die vom [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Objekt der Zielpräsentation bereitgestellt wird.
5. Rufen Sie die Methode [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/methods/addclone/index) auf, die vom [IMasterSlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/imasterslidecollection) Objekt bereitgestellt wird, und übergeben Sie den Master aus der Quell‑PPTX, der geklont werden soll, als Parameter an die Methode [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/methods/addclone/index) .
6. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection) , indem Sie die Referenz auf die Slides‑Sammlung setzen, die vom [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Objekt der Zielpräsentation bereitgestellt wird.
7. Rufen Sie die Methode [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/methods/addclone/index) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection) Objekt bereitgestellt wird, und übergeben Sie die zu klonende Folie aus der Quellpräsentation sowie die Masterfolie als Parameter an die Methode [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/methods/addclone/index) .
8. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie mit einem Master (die am Index 0 der Quellpräsentation liegt) an das Ende der Zielpräsentation geklont, wobei der Master aus der Quellfolie verwendet wurde.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, um die Quellpräsentationsdatei zu laden

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instanziieren Sie die Presentation‑Klasse für die Zielpräsentation (wo die Folie geklont werden soll)
    using (Presentation destPres = new Presentation())
    {

        // Instanziieren Sie ISlide aus der Sammlung von Folien in der Quellpräsentation zusammen mit
        // Masterfolie
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klonen Sie die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung von Masterfolien in der
        // Zielpräsentation
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Klonen Sie die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung von Masterfolien in der
        // Zielpräsentation
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Klonen Sie die gewünschte Folie aus der Quellpräsentation mit dem gewünschten Master bis zum Ende der
        // Sammlung von Folien in der Zielpräsentation
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Klonen Sie die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung von Masterfolien in der // Zielpräsentation
        // Speichern Sie die Zielpräsentation auf der Festplatte
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Klonen einer Folie am Ende eines angegebenen Abschnitts**

Mit Aspose.Slides für .NET können Sie eine Folie aus einem Abschnitt einer Präsentation klonen und diese Folie in einen anderen Abschnitt derselben Präsentation einfügen. Hierzu verwenden Sie die Methode [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/methods/addclone/index) aus dem Interface [ISlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection).

Der folgende C#‑Code zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // zu klonen
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Übereinstimmende Foliengröße sicherstellen**

Beim Klonen von Folien in eine andere Präsentation stellen Sie sicher, dass die Zielpräsentation dieselbe Foliengröße wie die Quellpräsentation hat. Wenn die Foliengrößen differieren, skaliert Aspose.Slides die geklonten Formen nicht automatisch – deren ursprüngliche Koordinaten und Abmessungen bleiben erhalten, was dazu führen kann, dass Inhalte falsch ausgerichtet sind oder über die Folienränder hinausgehen.

Sie können die Foliengröße der Zielpräsentation vor dem Klonen von Master und Folie auf die Größe der Quelle setzen:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Tun Sie dies, bevor Sie Master und Folie klonen.

## **FAQ**

**Werden Sprecher‑Notizen und Reviewer‑Kommentare geklont?**

Ja. Die Notizenseite und die Review‑Kommentare sind im Klon enthalten. Wenn Sie sie nicht wünschen, [entfernen Sie sie](/slides/de/net/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagrammobjekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/net/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten prüfen.

**Kann ich die Einfügeposition und Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewählten [Abschnitt](/slides/de/net/slide-section/) verschieben. Existiert der Zielabschnitt nicht, erstellen Sie ihn zuerst und verschieben dann die Folie hinein.
---
title: Gruppenformen in .NET
linktitle: Formgruppe
type: docs
weight: 40
url: /de/net/group/
keywords:
- Gruppenform
- Formgruppe
- Gruppe hinzufügen
- Alternativtext
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PowerPoint‑Präsentationen mit Aspose.Slides für .NET gruppieren und gruppieren aufheben – ein schneller, schrittweiser Leitfaden mit kostenlosem C#‑Code."
---

## **Gruppenform hinzufügen**
Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf Folien. Diese Funktion hilft Entwicklern, reichhaltigere Präsentationen zu erstellen. Aspose.Slides für .NET unterstützt das Hinzufügen oder den Zugriff auf Gruppenformen. Es ist möglich, Formen zu einer hinzugefügten Gruppenform hinzuzufügen, um sie zu füllen, oder auf jede Eigenschaft der Gruppenform zuzugreifen. So fügen Sie einer Folie mit Aspose.Slides für .NET eine Gruppenform hinzu:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Rufen Sie die Referenz einer Folie über deren Index ab.
1. Fügen Sie der Folie eine Gruppenform hinzu.
1. Fügen Sie die Formen der hinzugefügten Gruppenform hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

```c#
// Instanziieren Sie die Presentation-Klasse 
using (Presentation pres = new Presentation())
{
    // Holen Sie die erste Folie 
    ISlide sld = pres.Slides[0];

    // Zugriff auf die Formen-Sammlung der Folien 
    IShapeCollection slideShapes = sld.Shapes;

    // Hinzufügen einer Gruppenform zur Folie 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Hinzufügen von Formen innerhalb der hinzugefügten Gruppenform 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Hinzufügen des Gruppenform-Rahmens 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Schreiben Sie die PPTX-Datei auf die Festplatte 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```


## **Zugriff auf die AltText-Eigenschaft**
Dieses Thema zeigt einfache Schritte, inklusive Codebeispielen, zum Hinzufügen einer Gruppenform und zum Zugriff auf die AltText‑Eigenschaft von Gruppenformen auf Folien. So greifen Sie mit Aspose.Slides für .NET auf den AltText einer Gruppenform in einer Folie zu:

1. Instanziieren Sie die Klasse `Presentation`, die eine PPTX‑Datei repräsentiert.
1. Rufen Sie die Referenz einer Folie über deren Index ab.
1. Zugriff auf die Formen‑Sammlung der Folien.
1. Zugriff auf die Gruppenform.
1. Zugriff auf die AltText‑Eigenschaft.

```c#
// Instanzieren Sie die Presentation-Klasse, die die PPTX-Datei repräsentiert
Presentation pres = new Presentation("AltText.pptx");

// Holen Sie die erste Folie
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Zugriff auf die Formen-Sammlung der Folien
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Zugriff auf die Gruppenform.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Zugriff auf die AltText-Eigenschaft
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```


## **FAQ**

**Wird verschachteltes Gruppieren (eine Gruppe innerhalb einer Gruppe) unterstützt?**

Ja. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) verfügt über die Eigenschaft [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/), die die Hierarchiesunterstützung direkt anzeigt (eine Gruppe kann Kind einer anderen Gruppe sein).

**Wie kann ich die Z‑Reihenfolge der Gruppe im Verhältnis zu anderen Objekten auf der Folie steuern?**

Verwenden Sie die Eigenschaft [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) der [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/), um ihre Position im Anzeigestack zu prüfen.

**Kann ich das Verschieben/Bearbeiten/Aufheben der Gruppierung verhindern?**

Ja. Der Sperrbereich der Gruppe wird über [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/) bereitgestellt, wodurch Sie Vorgänge an dem Objekt einschränken können.
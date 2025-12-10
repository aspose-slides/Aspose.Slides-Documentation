---
title: Gruppenformen in Präsentationen mit .NET
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
description: "Erfahren Sie, wie Sie Formen in PowerPoint-Präsentationen mit Aspose.Slides für .NET gruppieren und auflösen - schnelle Schritt-für-Schritt-Anleitung mit kostenlosem C#-Code."
---

## **Eine Gruppenform hinzufügen**
Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf Folien. Diese Funktion hilft Entwicklern, reichhaltigere Präsentationen zu erstellen. Aspose.Slides für .NET unterstützt das Hinzufügen oder den Zugriff auf Gruppenformen. Es ist möglich, Formen zu einer hinzugefügten Gruppenform hinzuzufügen, um sie zu befüllen, oder auf irgendeine Eigenschaft der Gruppenform zuzugreifen. So fügen Sie einer Folie mit Aspose.Slides für .NET eine Gruppenform hinzu:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Rufen Sie die Referenz einer Folie über deren Index ab.
1. Fügen Sie der Folie eine Gruppenform hinzu.
1. Fügen Sie die Formen zur hinzugefügten Gruppenform hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Das nachstehende Beispiel fügt einer Folie eine Gruppenform hinzu.
```c#
// Instanziieren der Presentation-Klasse 
using (Presentation pres = new Presentation())
{
    // Erste Folie abrufen 
    ISlide sld = pres.Slides[0];

    // Zugriff auf die Formensammlung der Folien 
    IShapeCollection slideShapes = sld.Shapes;

    // Hinzufügen einer Gruppenform zur Folie 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Hinzufügen von Formen zur hinzugefügten Gruppenform 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Hinzufügen des Gruppenform-Frames 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // PPTX-Datei auf die Festplatte schreiben 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```



## **Zugriff auf die AltText-Eigenschaft**
Dieses Thema zeigt einfache Schritte, inklusive Codebeispielen, zum Hinzufügen einer Gruppenform und zum Zugriff auf die AltText-Eigenschaft von Gruppenformen auf Folien. Um den AltText einer Gruppenform in einer Folie mit Aspose.Slides für .NET zu erhalten:

1. Instanziieren Sie die Klasse `Presentation`, die eine PPTX-Datei darstellt.
1. Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Zugriff auf die Formensammlung der Folien.
1. Zugriff auf die Gruppenform.
1. Zugriff auf die AltText-Eigenschaft.

Das nachstehende Beispiel greift auf den Alternativtext der Gruppenform zu.
```c#
// Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation("AltText.pptx");

// Erste Folie abrufen
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Zugriff auf die Formensammlung der Folien
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

Ja. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) verfügt über die Eigenschaft [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/), die die Hierarchieunterstützung direkt anzeigt (eine Gruppe kann ein Kind einer anderen Gruppe sein).

**Wie steuere ich die Z-Reihenfolge der Gruppe im Verhältnis zu anderen Objekten auf der Folie?**

Verwenden Sie die Eigenschaft [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) der [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/), um ihre Position im Anzeigestapel zu prüfen.

**Kann ich das Verschieben/Bearbeiten/Entgruppieren verhindern?**

Ja. Der Sperrbereich der Gruppe wird über [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/) bereitgestellt, wodurch Sie Vorgänge an dem Objekt einschränken können.
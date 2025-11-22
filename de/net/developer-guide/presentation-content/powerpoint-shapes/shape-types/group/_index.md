---
title: Gruppe
type: docs
weight: 40
url: /de/net/group/
keywords: "Gruppenshape, PowerPoint-Form, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Gruppenshape zur PowerPoint-Präsentation in C# oder .NET hinzufügen"
---

## **Gruppenshape hinzufügen**
Aspose.Slides unterstützt die Arbeit mit Gruppenshapes auf Folien. Diese Funktion hilft Entwicklern, reichere Präsentationen zu unterstützen. Aspose.Slides für .NET unterstützt das Hinzufügen oder den Zugriff auf Gruppenshapes. Es ist möglich, Formen zu einer hinzugefügten Gruppenshape hinzuzufügen, um sie zu füllen oder auf jede Eigenschaft der Gruppenshape zuzugreifen. Um mit Aspose.Slides für .NET eine Gruppenshape zu einer Folie hinzuzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.
1. Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie der Folie eine Gruppenshape hinzu.
1. Fügen Sie der hinzugefügten Gruppenshape Formen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das Beispiel unten fügt einer Folie eine Gruppenshape hinzu.
```c#
// Instanzieren der Presentation-Klasse 
using (Presentation pres = new Presentation())
{
    // Erste Folie abrufen 
    ISlide sld = pres.Slides[0];

    // Zugriff auf die Formensammlung der Folien 
    IShapeCollection slideShapes = sld.Shapes;

    // Hinzufügen einer Gruppenshape zur Folie 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Hinzufügen von Formen in die hinzugefügte Gruppenshape 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Hinzufügen des Gruppenshape-Rahmens 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Schreibe die PPTX-Datei auf die Festplatte 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```




## **AltText‑Eigenschaft zugreifen**
Dieses Thema zeigt einfache Schritte, inklusive Codebeispielen, zum Hinzufügen einer Gruppenshape und zum Zugreifen auf die AltText‑Eigenschaft von Gruppenshapes auf Folien. Um mit Aspose.Slides für .NET den AltText einer Gruppenshape auf einer Folie zuzugreifen:

1. Instanziieren Sie die `Presentation`‑Klasse, die die PPTX‑Datei darstellt.
1. Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
1. Greifen Sie auf die Formensammlung der Folien zu.
1. Greifen Sie auf die Gruppenshape zu.
1. Greifen Sie auf die AltText‑Eigenschaft zu.

Das Beispiel unten greift auf den alternativen Text der Gruppenshape zu.
```c#
// Instanziieren der Presentation-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation("AltText.pptx");

// Erste Folie abrufen
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Zugriff auf die Formensammlung der Folien
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Zugriff auf die Gruppenshape.
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

Ja. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) hat eine [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/)‑Eigenschaft, die direkt die Hierarchiesunterstützung anzeigt (eine Gruppe kann Kind einer anderen Gruppe sein).

**Wie steuere ich die Z‑Reihenfolge der Gruppe im Verhältnis zu anderen Objekten auf der Folie?**

Verwenden Sie die [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/)‑[ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/)‑Eigenschaft, um ihre Position im Anzeigestapel zu prüfen oder zu ändern.

**Kann ich das Verschieben/Bearbeiten/Entgruppieren verhindern?**

Ja. Der Sperrabschnitt der Gruppe wird über [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/) bereitgestellt, mit dem Sie Vorgänge an dem Objekt einschränken können.
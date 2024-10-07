---
title: Gruppe
type: docs
weight: 40
url: /net/group/
keywords: "Gruppengeometrie, PowerPoint-Geometrie, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Fügen Sie einer PowerPoint-Präsentation in C# oder .NET eine Gruppengeometrie hinzu"
---

## **Gruppengeometrie hinzufügen**
Aspose.Slides unterstützt die Arbeit mit Gruppengeometrien auf Folien. Diese Funktion hilft Entwicklern, reichhaltigere Präsentationen zu unterstützen. Aspose.Slides für .NET unterstützt das Hinzufügen oder Zugreifen auf Gruppengeometrien. Es ist möglich, Geometrien zu einer hinzugefügten Gruppengeometrie hinzuzufügen, um sie zu bevölkern, oder auf eine beliebige Eigenschaft der Gruppengeometrie zuzugreifen. Um einer Folie mit Aspose.Slides für .NET eine Gruppengeometrie hinzuzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie der Folie eine Gruppengeometrie hinzu.
1. Fügen Sie die Geometrien zur hinzugefügten Gruppengeometrie hinzu.
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Das folgende Beispiel fügt einer Folie eine Gruppengeometrie hinzu.

```c#
// Instanziieren Sie die Presentation-Klasse 
using (Presentation pres = new Presentation())
{
    // Holen Sie sich die erste Folie 
    ISlide sld = pres.Slides[0];

    // Zugriff auf die Geometriesammlung der Folien 
    IShapeCollection slideShapes = sld.Shapes;

    // Fügen Sie der Folie eine Gruppengeometrie hinzu 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Fügen Sie Geometrien innerhalb der hinzugefügten Gruppengeometrie hinzu 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Fügen Sie den Rahmen der Gruppengeometrie hinzu 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Schreiben Sie die PPTX-Datei auf die Festplatte 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```

## **Auf die AltText-Eigenschaft zugreifen**
Dieses Thema zeigt einfache Schritte, komplett mit Codebeispielen, um eine Gruppengeometrie hinzuzufügen und die AltText-Eigenschaft von Gruppengeometrien auf Folien zuzugreifen. Um den AltText einer Gruppengeometrie in einer Folie mit Aspose.Slides für .NET zuzugreifen:

1. Instanziieren Sie die `Presentation`-Klasse, die die PPTX-Datei darstellt.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Zugriff auf die Geometriesammlung der Folien.
1. Zugriff auf die Gruppengeometrie.
1. Zugriff auf die AltText-Eigenschaft.

Das folgende Beispiel greift auf den alternativen Text der Gruppengeometrie zu.

```c#
// Instanziieren Sie die Presentation-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation("AltText.pptx");

// Holen Sie sich die erste Folie
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Zugriff auf die Geometriesammlung der Folien
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Zugriff auf die Gruppengeometrie.
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
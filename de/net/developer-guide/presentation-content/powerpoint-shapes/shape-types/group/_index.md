---
title: Gruppe
type: docs
weight: 40
url: /de/net/group/
keywords: "Gruppenform, PowerPoint-Form, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Gruppenform zu PowerPoint-Präsentation in C# oder .NET hinzufügen"
---

## **Gruppenform hinzufügen**
Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf Folien. Diese Funktion hilft Entwicklern, reichhaltigere Präsentationen zu erstellen. Aspose.Slides für .NET unterstützt das Hinzufügen oder den Zugriff auf Gruppenformen. Es ist möglich, Formen zu einer hinzugefügten Gruppenform hinzuzufügen, um sie zu befüllen, oder irgendeine Eigenschaft der Gruppenform zuzugreifen. So fügen Sie einer Folie eine Gruppenform mit Aspose.Slides für .NET hinzu:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden
1. Fügen Sie der Folie eine Gruppenform hinzu.
1. Fügen Sie die Formen zur hinzugefügten Gruppenform hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Das folgende Beispiel fügt einer Folie eine Gruppenform hinzu.
```c#
 // Instanziieren der Presentation-Klasse 
 using (Presentation pres = new Presentation())
 {
     // Die erste Folie holen 
     ISlide sld = pres.Slides[0];

     // Zugriff auf die Formensammlung der Folien 
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

     // Schreiben der PPTX-Datei auf die Festplatte 
     pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
 }
```




## **Zugriff auf die AltText-Eigenschaft**
Dieses Thema zeigt einfache Schritte, einschließlich Codebeispielen, zum Hinzufügen einer Gruppenform und zum Zugriff auf die AltText-Eigenschaft von Gruppenformen auf Folien. So greifen Sie auf den AltText einer Gruppenform in einer Folie mit Aspose.Slides für .NET zu:

1. Instanziieren Sie die Klasse `Presentation`, die eine PPTX-Datei repräsentiert.
1. Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Zugriff auf die Formensammlung der Folien.
1. Zugriff auf die Gruppenform.
1. Zugriff auf die AltText-Eigenschaft.

Das folgende Beispiel greift auf den alternativen Text einer Gruppenform zu.
```c#
// Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation("AltText.pptx");

// Erste Folie holen
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

**Unterstützt verschachtelte Gruppierung (eine Gruppe innerhalb einer Gruppe)?**

Ja. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) verfügt über die Eigenschaft [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/), die direkt die Hierarchieunterstützung anzeigt (eine Gruppe kann ein Kind einer anderen Gruppe sein).

**Wie kann ich die Z‑Reihenfolge der Gruppe relativ zu anderen Objekten auf der Folie steuern?**

Verwenden Sie die Eigenschaft [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) der [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/), um ihre Position im Anzeigestapel zu prüfen.

**Kann ich das Verschieben/Bearbeiten/Entgruppieren verhindern?**

Ja. Der Sperrbereich der Gruppe wird über [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/) bereitgestellt, wodurch Sie Vorgänge an dem Objekt einschränken können.
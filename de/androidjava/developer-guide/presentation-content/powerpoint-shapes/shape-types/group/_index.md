---
title: Gruppenpräsentationsformen auf Android
linktitle: Formgruppe
type: docs
weight: 40
url: /de/androidjava/group/
keywords:
- Gruppenform
- Formgruppe
- Gruppe hinzufügen
- Alternativtext
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PowerPoint-Präsentationen mit Aspose.Slides für Android gruppieren und Gruppierungen aufheben – ein schneller, schrittweiser Leitfaden mit kostenlosem Java-Code."
---

## **Gruppenform hinzufügen**
Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf Folien. Diese Funktion hilft Entwicklern, reichhaltigere Präsentationen zu unterstützen. Aspose.Slides für Android via Java unterstützt das Hinzufügen oder den Zugriff auf Gruppenformen. Es ist möglich, Formen zu einer hinzugefügten Gruppenform hinzuzufügen, um sie zu füllen, oder auf beliebige Eigenschaften der Gruppenform zuzugreifen. So fügen Sie einer Folie eine Gruppenform mit Aspose.Slides für Android via Java hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie der Folie eine Gruppenform hinzu.
1. Fügen Sie der hinzugefügten Gruppenform die Formen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Das nachstehende Beispiel fügt einer Folie eine Gruppenform hinzu.
```java
// Presentation‑Klasse instanziieren
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);

    // Zugriff auf die Formensammlung der Folien
    IShapeCollection slideShapes = sld.getShapes();

    // Hinzufügen einer Gruppenform zur Folie
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Hinzufügen von Formen zur hinzugefügten Gruppenform
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Hinzufügen des Gruppenformrahmens
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // PPTX‑Datei auf Datenträger schreiben
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zugriff auf die AltText‑Eigenschaft**
Dieses Thema zeigt einfache Schritte, einschließlich Codebeispielen, zum Hinzufügen einer Gruppenform und zum Zugriff auf die AltText‑Eigenschaft von Gruppenformen auf Folien. So greifen Sie mit Aspose.Slides für Android via Java auf den AltText einer Gruppenform in einer Folie zu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse, die eine PPTX-Datei darstellt.
1. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Greifen Sie auf die Formensammlung der Folien zu.
1. Greifen Sie auf die Gruppenform zu.
1. Greifen Sie auf die [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) Eigenschaft zu.

Das nachstehende Beispiel greift auf den alternativen Text der Gruppenform zu.
```java
// Instanziieren Sie die Presentation-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation("AltText.pptx");
try {
    // Erste Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Zugriff auf die Formensammlung der Folien
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Zugriff auf die Gruppenform.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Zugriff auf die AltText-Eigenschaft
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wird verschachteltes Gruppieren (eine Gruppe innerhalb einer Gruppe) unterstützt?**

Ja. [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/) verfügt über die Methode [getParentGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getParentGroup--), die direkt die Hierarchieunterstützung anzeigt (eine Gruppe kann ein Kind einer anderen Gruppe sein).

**Wie kann ich die Z‑Reihenfolge der Gruppe relativ zu anderen Objekten auf der Folie steuern?**

Verwenden Sie die Methode [getZOrderPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getZOrderPosition--) der [GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/), um ihre Position im Anzeigestapel zu prüfen.

**Kann ich das Verschieben/Bearbeiten/Entgruppieren verhindern?**

Ja. Der Sperrabschnitt der Gruppe ist über [getGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) verfügbar, sodass Sie Vorgänge an dem Objekt einschränken können.
---
title: Gruppe
type: docs
weight: 40
url: /de/java/group/
---

## **Gruppenform hinzufügen**
Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf Folien. Diese Funktion hilft Entwicklern, reichhaltigere Präsentationen zu unterstützen. Aspose.Slides für Java unterstützt das Hinzufügen oder den Zugriff auf Gruppenformen. Es ist möglich, Formen zu einer hinzugefügten Gruppenform hinzuzufügen, um sie zu füllen, oder auf eine beliebige Eigenschaft der Gruppenform zuzugreifen. Um eine Gruppenform zu einer Folie mit Aspose.Slides für Java hinzuzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie der Folie eine Gruppenform hinzu.
1. Fügen Sie die Formen zur hinzugefügten Gruppenform hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Das folgende Beispiel fügt einer Folie eine Gruppenform hinzu.

```java
// Instanziieren der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Zugriff auf die Formensammlung der Folien
    IShapeCollection slideShapes = sld.getShapes();

    // Hinzufügen einer Gruppenform zur Folie
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Hinzufügen von Formen innerhalb der hinzugefügten Gruppenform
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Hinzufügen des Gruppenformrahmens
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Schreiben Sie die PPTX-Datei auf die Festplatte
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **AltText-Eigenschaft zugreifen**
Dieses Thema zeigt einfache Schritte, komplett mit Codebeispielen, zum Hinzufügen einer Gruppenform und zum Zugreifen auf die AltText-Eigenschaft von Gruppenformen auf Folien. Um auf AltText einer Gruppenform in einer Folie mit Aspose.Slides für Java zuzugreifen:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse, die die PPTX-Datei darstellt.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Zugriff auf die Formensammlung der Folien.
1. Zugriff auf die Gruppenform.
1. Zugriff auf die [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--) Eigenschaft.

Das folgende Beispiel greift auf den alternativen Text der Gruppenform zu.

```java
// Instanziieren der Presentation-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation("AltText.pptx");
try {
    // Holen Sie sich die erste Folie
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
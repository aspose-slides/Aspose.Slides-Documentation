---
title: Gruppen-Präsentationsformen in Java
linktitle: Formgruppe
type: docs
weight: 40
url: /de/java/group/
keywords:
- Gruppenform
- Formgruppe
- Gruppe hinzufügen
- Alternativtext
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PowerPoint-Präsentationen mit Aspose.Slides für Java gruppieren und aufheben - schnelle, schrittweise Anleitung mit kostenlosem Java-Code."
---

## **Eine Gruppenform hinzufügen**
Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf Folien. Diese Funktion hilft Entwicklern, reichhaltigere Präsentationen zu erstellen. Aspose.Slides für Java unterstützt das Hinzufügen oder den Zugriff auf Gruppenformen. Es ist möglich, Formen zu einer hinzugefügten Gruppenform hinzuzufügen, um sie zu füllen, oder auf irgendeine Eigenschaft der Gruppenform zuzugreifen. So fügen Sie einer Folie mit Aspose.Slides für Java eine Gruppenform hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
2. Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
3. Fügen Sie der Folie eine Gruppenform hinzu.
4. Fügen Sie der hinzugefügten Gruppenform Formen hinzu.
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das nachstehende Beispiel fügt einer Folie eine Gruppenform hinzu.
```java
// Instanziieren der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Erste Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);

    // Zugriff auf die Formsammlung der Folien
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

    // PPTX-Datei auf Datenträger schreiben
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zugriff auf die AltText‑Eigenschaft**
Dieses Thema zeigt einfache Schritte, ergänzt durch Code‑Beispiele, zum Hinzufügen einer Gruppenform und zum Zugriff auf die AltText‑Eigenschaft von Gruppenformen auf Folien. So greifen Sie mit Aspose.Slides für Java auf AltText einer Gruppenform in einer Folie zu:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse, die die PPTX‑Datei repräsentiert.
2. Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
3. Greifen Sie auf die Form‑Sammlung der Folien zu.
4. Greifen Sie auf die Gruppenform zu.
5. Greifen Sie auf die [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--)‑Eigenschaft zu.

Das nachstehende Beispiel greift auf den Alternativtext einer Gruppenform zu.
```java
// Instanziieren der Presentation-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation("AltText.pptx");
try {
    // Erste Folie abrufen
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Zugriff auf die Formsammlung der Folien
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

Ja. [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/) verfügt über eine [getParentGroup](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getParentGroup--)‑Methode, die direkt die Hierarchie‑Unterstützung anzeigt (eine Gruppe kann Kind einer anderen Gruppe sein).

**Wie kann ich die Z‑Reihenfolge der Gruppe im Verhältnis zu anderen Objekten auf der Folie steuern?**

Verwenden Sie die [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/)‑Methode [getZOrderPosition](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--), um ihre Position im Anzeige‑Stack zu prüfen.

**Kann ich das Verschieben/Bearbeiten/Entgruppieren verhindern?**

Ja. Der Sperrabschnitt der Gruppe wird über [GroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/#getGroupShapeLock--) bereitgestellt, sodass Sie Vorgänge an dem Objekt einschränken können.
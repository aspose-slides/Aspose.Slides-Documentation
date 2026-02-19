---
title: Masterfolie
type: docs
weight: 30
url: /de/java/examples/elements/master-slide/
keywords:
- Codebeispiel
- Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie Beispiele für Masterfolien mit Aspose.Slides für Java: Erstellen, bearbeiten und gestalten Sie Master, Platzhalter und Designs in PPT, PPTX und ODP mit klarem Java-Code."
---
Masterfolien bilden die oberste Ebene der Folienvererbungshierarchie in PowerPoint. Eine **Masterfolie** definiert gemeinsame Designelemente wie Hintergründe, Logos und Textformatierung. **Layoutfolien** erben von Masterfolien, und **Standardfolien** erben von Layoutfolien.

Dieser Artikel zeigt, wie man Masterfolien mit Aspose.Slides für Java erstellt, bearbeitet und verwaltet.

## **Eine Masterfolie hinzufügen**

Dieses Beispiel zeigt, wie man eine neue Masterfolie erstellt, indem man die Standardfolie klont. Anschließend wird über die Layoutvererbung ein Firmenname‑Banner zu allen Folien hinzugefügt.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Klonen Sie die Standard-Masterfolie.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Fügen Sie ein Banner mit dem Firmennamen oben auf der Masterfolie hinzu.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Weisen Sie die neue Masterfolie einer Layoutfolie zu.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Weisen Sie die Layoutfolie der ersten Folie in der Präsentation zu.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Hinweis 1:** Masterfolien bieten die Möglichkeit, ein einheitliches Branding oder gemeinsame Designelemente auf alle Folien anzuwenden. Änderungen an der Masterfolie werden automatisch auf abhängige Layout‑ und Standardfolien übertragen.

> 💡 **Hinweis 2:** Alle Formen oder Formatierungen, die zu einer Masterfolie hinzugefügt werden, werden von Layoutfolien und wiederum von allen Standardfolien, die diese Layouts verwenden, geerbt.  
> Das Bild unten veranschaulicht, wie ein Textfeld, das auf einer Masterfolie hinzugefügt wurde, automatisch auf der endgültigen Folie dargestellt wird.

![Beispiel für Mastervererbung](master-slide-banner.png)

## **Auf eine Masterfolie zugreifen**

Sie können Masterfolien über die Master‑Sammlung der Präsentation abrufen. So holen Sie sie ab und arbeiten mit ihnen:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Ändern Sie den Hintergrundtyp.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Eine Masterfolie entfernen**

Masterfolien können entweder nach Index oder per Referenz entfernt werden.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Entfernen Sie eine Masterfolie nach Index.
        presentation.getMasters().removeAt(0);

        // Entfernen Sie eine Masterfolie per Referenz.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Unbenutzte Masterfolien entfernen**

Einige Präsentationen enthalten Masterfolien, die nicht verwendet werden. Das Entfernen dieser Folien kann die Dateigröße reduzieren.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Entfernen Sie alle nicht verwendeten Masterfolien (auch jene, die als Preserve markiert sind).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```
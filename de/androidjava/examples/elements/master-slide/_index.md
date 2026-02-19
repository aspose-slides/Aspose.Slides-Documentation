---
title: Masterfolie
type: docs
weight: 30
url: /de/androidjava/examples/elements/master-slide/
keywords:
- Codebeispiel
- Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie Masterfolien-Beispiele von Aspose.Slides für Android: Erstellen, Bearbeiten und Gestalten von Masterfolien, Platzhaltern und Designs in PPT, PPTX und ODP mit klarem Java-Code."
---
Masterfolien bilden die oberste Ebene der Folienvererbungshierarchie in PowerPoint. Eine **Masterfolie** definiert gemeinsame Designelemente wie Hintergründe, Logos und Textformatierung. **Layoutfolien** erben von Masterfolien, und **Normalfolien** erben von Layoutfolien.

Dieser Artikel zeigt, wie man Masterfolien mit Aspose.Slides für Android über Java erstellt, ändert und verwaltet.

## **Masterfolie hinzufügen**

Dieses Beispiel zeigt, wie man eine neue Masterfolie erstellt, indem man die Standardfolie klont. Anschließend wird ein Firmenname‑Banner zu allen Folien über die Layoutvererbung hinzugefügt.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Kopiere die standardmäßige Masterfolie.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Füge ein Banner mit dem Firmennamen oben auf der Masterfolie hinzu.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Weise die neue Masterfolie einer Layoutfolie zu.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Weise die Layoutfolie der ersten Folie in der Präsentation zu.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Hinweis 1:** Masterfolien ermöglichen es, ein konsistentes Branding oder gemeinsame Designelemente auf alle Folien anzuwenden. Änderungen an der Masterfolie werden automatisch auf abhängige Layout‑ und Normalfolien übertragen.

> 💡 **Hinweis 2:** Alle Formen oder Formatierungen, die einer Masterfolie hinzugefügt werden, werden von Layoutfolien und wiederum von allen Normalfolien, die diese Layouts verwenden, geerbt.
> Das untenstehende Bild veranschaulicht, wie ein auf einer Masterfolie hinzugefügtes Textfeld automatisch auf der endgültigen Folie dargestellt wird.

![Master-Inheritance-Beispiel](master-slide-banner.png)

## **Zugriff auf eine Masterfolie**

Sie können Masterfolien über die Master‑Sammlung der Präsentation zugreifen. So rufen Sie sie ab und arbeiten mit ihnen:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Ändere den Hintergrundtyp.
    } finally {
        presentation.dispose();
    }
}
```

## **Masterfolie entfernen**

Masterfolien können entweder über den Index oder über eine Referenz entfernt werden.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Entferne eine Masterfolie nach Index.
        presentation.getMasters().removeAt(0);

        // Entferne eine Masterfolie nach Referenz.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Unbenutzte Masterfolien entfernen**

Einige Präsentationen enthalten Masterfolien, die nicht verwendet werden. Das Entfernen dieser Folien kann helfen, die Dateigröße zu reduzieren.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Entferne alle unbenutzten Masterfolien (auch solche, die als Preserve markiert sind).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```
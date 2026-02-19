---
title: Hyperlink
type: docs
weight: 130
url: /de/java/examples/elements/hyperlink/
keywords:
- Codebeispiel
- Hyperlink
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Hyperlinks in Aspose.Slides für Java hinzufügen und verwalten: Text, Formen und Bilder verlinken, Ziele und Aktionen für PPT, PPTX und ODP festlegen, mit Java-Beispielen."
---
Dieser Artikel demonstriert das Hinzufügen, den Zugriff, das Entfernen und das Aktualisieren von Hyperlinks in Formen mithilfe von **Aspose.Slides for Java**.

## **Hyperlink hinzufügen**

Erstellen Sie eine Rechteckform mit einem Hyperlink, der auf eine externe Website verweist.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **Zugriff auf einen Hyperlink**

Lesen Sie Hyperlink-Informationen aus einem Textabschnitt einer Form.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Hyperlink entfernen**

Entfernen Sie den Hyperlink aus dem Text einer Form.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **Hyperlink aktualisieren**

Ändern Sie das Ziel eines vorhandenen Hyperlinks. Verwenden Sie `HyperlinkManager`, um Text zu ändern, der bereits einen Hyperlink enthält, was dem Vorgehen von PowerPoint beim sicheren Aktualisieren von Hyperlinks entspricht.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // Das Ändern eines Hyperlinks im vorhandenen Text sollte über
        // HyperlinkManager erfolgen, anstatt die Eigenschaft direkt zu setzen.
        // Dies ahmt nach, wie PowerPoint Hyperlinks sicher aktualisiert.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```
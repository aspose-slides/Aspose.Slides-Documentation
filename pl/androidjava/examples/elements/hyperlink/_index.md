---
title: Hiperłącze
type: docs
weight: 130
url: /pl/androidjava/examples/elements/hyperlink/
keywords:
- przykład kodu
- hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dodawaj i zarządzaj hiperłączami w Aspose.Slides for Android: teksty linków, kształty i obrazy, ustawiaj cele i akcje dla PPT, PPTX i ODP przy użyciu przykładów w Javie."
---
Ten artykuł demonstruje dodawanie, odczytywanie, usuwanie i aktualizowanie hiperłączy w kształtach przy użyciu **Aspose.Slides for Android via Java**.

## **Dodaj hiperłącze**

Utwórz prostokątny kształt z hiperłączem prowadzącym do zewnętrznej witryny.

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

## **Uzyskaj dostęp do hiperłącza**

Odczytaj informacje o hiperłączu z fragmentu tekstu kształtu.

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

## **Usuń hiperłącze**

Wyczyść hiperłącze z tekstu kształtu.

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

## **Zaktualizuj hiperłącze**

Zmień docelowy adres istniejącego hiperłącza. Użyj `HyperlinkManager`, aby zmodyfikować tekst, który już zawiera hiperłącze, co naśladuje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.

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

        // Zmiana hiperłącza w istniejącym tekście powinna być wykonana za pomocą
        // HyperlinkManager zamiast bezpośredniego ustawiania właściwości.
        // To naśladuje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```
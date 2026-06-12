---
title: Hypertextový odkaz
type: docs
weight: 130
url: /cs/java/examples/elements/hyperlink/
keywords:
- příklad kódu
- hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Přidejte a spravujte hypertextové odkazy v Aspose.Slides pro Java: odkazujte text, tvary a obrázky, nastavujte cíle a akce pro PPT, PPTX a ODP s příklady v Javě."
---
Tento článek ukazuje, jak přidávat, získávat, odstraňovat a aktualizovat hypertextové odkazy na tvarech pomocí **Aspose.Slides for Java**.

## **Přidat hypertextový odkaz**

Vytvořte obdélníkový tvar s hypertextovým odkazem směřujícím na externí webovou stránku.

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

## **Přístup k hypertextovému odkazu**

Přečtěte informace o hypertextovém odkazu z textové části tvaru.

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

## **Odstranit hypertextový odkaz**

Odstraňte hypertextový odkaz z textu tvaru.

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

## **Aktualizovat hypertextový odkaz**

Změňte cíl existujícího hypertextového odkazu. Použijte `HyperlinkManager` k úpravě textu, který již obsahuje hypertextový odkaz, což napodobuje způsob, jakým PowerPoint bezpečně aktualizuje hypertextové odkazy.

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

        // Změna hypertextového odkazu v existujícím textu by měla být provedena pomocí
        // HyperlinkManageru namísto přímého nastavení vlastnosti.
        // To napodobuje způsob, jakým PowerPoint bezpečně aktualizuje hypertextové odkazy.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```
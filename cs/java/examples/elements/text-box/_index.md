---
title: Textové pole
type: docs
weight: 40
url: /cs/java/examples/elements/text-box/
keywords:
- ukázka kódu
- textové pole
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Pracujte s textovými poli v Aspose.Slides pro Java: přidávejte, formátujte, zarovnávejte, zalamujte, automaticky přizpůsobujte a stylizujte text pomocí jazyka Java pro prezentace PPT, PPTX a ODP."
---
V Aspose.Slides je **textové pole** reprezentováno pomocí `AutoShape`. Téměř jakýkoli tvar může obsahovat text, ale typické textové pole nemá výplň ani ohraničení a zobrazuje jen text.

Tento průvodce vysvětluje, jak programově přidávat, přistupovat k a odstraňovat textová pole.

## **Přidání textového pole**

Textové pole je jednoduše `AutoShape` bez výplně nebo ohraničení a s nějakým formátovaným textem. Zde je návod, jak takové vytvořit:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Vytvořte obdélníkový tvar (ve výchozím nastavení vyplněný ohraničením a bez textu).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Odeberte výplň a ohraničení, aby vypadal jako typické textové pole.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Nastavte formátování textu.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Přiřaďte skutečný textový obsah.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Poznámka:** Každý `AutoShape`, který obsahuje neprázdný `TextFrame`, může fungovat jako textové pole.

## **Přístup k textovým polím podle obsahu**

Pro vyhledání všech textových polí obsahujících konkrétní klíčové slovo (e.g. "Slide") projděte tvary a zkontrolujte jejich text:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Pouze AutoShapes mohou obsahovat editovatelný text.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Proveďte něco s odpovídajícím textovým polem.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranění textových polí podle obsahu**

Tento příklad najde a smaže všechna textová pole na první snímku, která obsahují konkrétní klíčové slovo:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Tip:** Vždy vytvořte kopii kolekce tvarů před jejím upravováním během iterace, abyste se vyhnuli chybám při změně kolekce.
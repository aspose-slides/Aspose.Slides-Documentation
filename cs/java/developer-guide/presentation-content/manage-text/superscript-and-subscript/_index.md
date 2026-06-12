---
title: Správa horního a dolního indexu v prezentacích pomocí Java
linktitle: Horní a dolní index
type: docs
weight: 80
url: /cs/java/superscript-and-subscript/
keywords:
- horní index
- dolní index
- přidat horní index
- přidat dolní index
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Ovládněte horní a dolní index v Aspose.Slides pro Java a pozvedněte své prezentace profesionálním formátováním textu pro maximální dopad."
---
## **Přehled**

Aspose.Slides poskytuje funkce pro začlenění textu s horním a dolním indexem do vašich prezentací PowerPoint (PPT, PPTX) a OpenDocument (ODP). Ať už potřebujete zvýraznit chemické vzorce, matematické rovnice nebo anotovat obsah pomocí poznámek pod čarou, tyto specializované možnosti formátování pomáhají zachovat jasnost a přesnost. V tomto článku se dozvíte, jak snadno použít styly horního a dolního indexu a zajistit profesionální výsledek na každém snímku.

## **Správa horního a dolního indexu**

Můžete přidat text s horním a dolním indexem do libovolné části odstavce. Pro přidání textu s horním nebo dolním indexem v textovém rámečku Aspose.Slides je třeba použít metodu [**setEscapement**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) třídy [PortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/PortionFormat).

Tato vlastnost vrací nebo nastavuje text s horním nebo dolním indexem (hodnota od -100 % (dolní index) do 100 % (horní index)). Pro příklad:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho indexu.
- Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape) typu [Rectangle](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ShapeType#Rectangle) na snímek.
- Získejte přístup k [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrame) přidruženému k [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape).
- Vymažte existující odstavce.
- Vytvořte nový objekt odstavce pro uchování textu s horním indexem a přidejte jej do kolekce [IParagraphs collection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrame#getParagraphs--) [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrame).
- Vytvořte nový objekt portion.
- Nastavte vlastnost Escapement pro portion na hodnotu mezi 0 a 100 pro přidání horního indexu. (0 znamená žádný horní index)
- Nastavte nějaký text pro [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Portion) a poté jej přidejte do kolekce portion odstavce.
- Vytvořte nový objekt odstavce pro uchování textu s dolním indexem a přidejte jej do kolekce IParagraphs [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrame).
- Vytvořte nový objekt portion.
- Nastavte vlastnost Escapement pro portion na hodnotu mezi 0 a -100 pro přidání dolního indexu. (0 znamená žádný dolní index)
- Nastavte nějaký text pro [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Portion) a poté jej přidejte do kolekce portion odstavce.
- Uložte prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je uvedena níže.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získat snímek
    ISlide slide = pres.getSlides().get_Item(0);

    // Vytvořit textové pole
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Vytvořit odstavec pro text s horním indexem
    IParagraph superPar = new Paragraph();

    // Vytvořit část s běžným textem
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Vytvořit část s textem v horním indexu
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Vytvořit odstavec pro text s dolním indexem
    IParagraph paragraph2 = new Paragraph();

    // Vytvořit část s běžným textem
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Vytvořit část s textem v dolním indexu
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Přidat odstavce do textového pole
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Zůstane horní a dolní index zachován při exportu do PDF nebo jiných formátů?**

Ano, Aspose.Slides správně zachovává formátování horního a dolního indexu při exportu prezentací do PDF, PPT/PPTX, obrázků a dalších podporovaných formátů. Specializované formátování zůstává nedotčeno ve všech výstupních souborech.

**Lze kombinovat horní a dolní index s dalšími styly formátování, jako je tučné nebo kurzíva?**

Ano, Aspose.Slides umožňuje kombinovat různé styly textu v jedné části textu. Můžete povolit tučné, kurzívu, podtržení a zároveň použít horní nebo dolní index nastavením odpovídajících vlastností ve [PortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portionformat/).

**Funguje formátování horního a dolního indexu pro text uvnitř tabulek, grafů nebo SmartArt?**

Ano, Aspose.Slides podporuje formátování ve většině objektů, včetně tabulek a částí grafů. Při práci se SmartArt je nutné získat přístup k příslušným prvkům (například [SmartArtNode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/smartartnode/)) a jejich textovým kontejnerům a poté nastavit vlastnosti [PortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portionformat/) obdobným způsobem.
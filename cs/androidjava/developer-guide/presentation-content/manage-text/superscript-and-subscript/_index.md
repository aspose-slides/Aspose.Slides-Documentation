---
title: Správa horního a dolního indexu v prezentacích na Androidu
linktitle: Horní a dolní index
type: docs
weight: 80
url: /cs/androidjava/superscript-and-subscript/
keywords:
- horní index
- dolní index
- přidat horní index
- přidat dolní index
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Ovládněte horní a dolní index v Aspose.Slides pro Android pomocí Javy a vylepšete své prezentace profesionálním formátováním textu pro maximální dopad."
---
## **Přehled**

Aspose.Slides poskytuje funkce pro integraci textu ve formě horního a dolního indexu do vašich prezentací PowerPoint (PPT, PPTX) a OpenDocument (ODP). Ať už potřebujete zvýraznit chemické vzorce, matematické rovnice nebo anotovat obsah pomocí poznámek pod čarou, tyto specializované možnosti formátování pomáhají zachovat srozumitelnost a přesnost. V tomto článku se naučíte, jak hladce použít styly horního a dolního indexu a zajistit profesionální výsledek na každém snímku.

## **Spravovat text v horním a dolním indexu**
Můžete přidat text v horním nebo dolním indexu do libovolné části odstavce. Pro přidání textu v horním nebo dolním indexu v textovém rámečku Aspose.Slides je třeba použít metodu [**setEscapement**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) třídy [PortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/PortionFormat).

Tato vlastnost vrací nebo nastavuje text v horním či dolním indexu (hodnota od -100 % (dolní index) do 100 % (horní index)). Například:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho indexu.
- Přidejte objekt [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAutoShape) typu [Rectangle](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ShapeType#Rectangle) na snímek.
- Získejte přístup k [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrame) který je spojen s [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAutoShape).
- Vymažte existující odstavce
- Vytvořte nový objekt odstavce, který bude obsahovat text v horním indexu, a přidejte jej do kolekce [IParagraphs](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) objektu [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrame).
- Vytvořte nový objekt části
- Nastavte vlastnost Escapement pro část na hodnotu od 0 do 100 pro přidání horního indexu. (0 znamená žádný horní index)
- Nastavte nějaký text pro [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Portion) a poté jej přidejte do kolekce částí odstavce.
- Vytvořte nový objekt odstavce, který bude obsahovat text v dolním indexu, a přidejte jej do kolekce IParagraphs objektu ITextFrame.
- Vytvořte nový objekt části
- Nastavte vlastnost Escapement pro část na hodnotu od 0 do -100 pro přidání dolního indexu. (0 znamená žádný dolní index)
- Nastavte nějaký text pro [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Portion) a poté jej přidejte do kolekce částí odstavce.
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

    // Vytvořit odstavec pro text v horním indexu
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

    // Vytvořit odstavec pro text v dolním indexu
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

**Zachová se horní a dolní index při exportu do PDF nebo jiných formátů?**

Ano, Aspose.Slides správně zachovává formátování horního a dolního indexu při exportu prezentací do PDF, PPT/PPTX, obrázků a dalších podporovaných formátů. Specializované formátování zůstává v všech výstupních souborech nedotčeno.

**Lze kombinovat horní a dolní index s dalšími styly formátování, jako je tučný nebo kurzíva?**

Ano, Aspose.Slides umožňuje kombinovat různé styly textu v jedné části textu. Můžete aktivovat tučné, kurzívu, podtržení a současně použít horní nebo dolní index nastavením odpovídajících vlastností v [PortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portionformat/).

**Funguje formátování horního a dolního indexu pro text uvnitř tabulek, grafů nebo SmartArtu?**

Ano, Aspose.Slides podporuje formátování ve většině objektů, včetně tabulek a částí grafů. Při práci se SmartArtem je nutné získat přístup k příslušným prvkům (například [SmartArtNode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/smartartnode/)) a jejich textovým kontejnerům a poté nastavit vlastnosti [PortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portionformat/) podobným způsobem.
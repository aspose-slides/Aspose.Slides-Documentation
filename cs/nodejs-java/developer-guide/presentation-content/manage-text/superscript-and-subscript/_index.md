---
title: Správa horního a dolního indexu v prezentacích pomocí JavaScriptu
linktitle: Horní a dolní index
type: docs
weight: 80
url: /cs/nodejs-java/superscript-and-subscript/
keywords:
- horní index
- dolní index
- přidat horní index
- přidat dolní index
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Ovládněte horní a dolní index v Aspose.Slides pro Node.js pomocí Java a vylepšete své prezentace profesionálním formátováním textu pro maximální efekt."
---
## **Přehled**

Aspose.Slides poskytuje funkce pro integraci textu s horním a dolním indexem do vašich prezentací PowerPoint (PPT, PPTX) a OpenDocument (ODP). Ať už potřebujete zvýraznit chemické vzorce, matematické rovnice nebo anotovat obsah poznámkami pod čarou, tyto specializované možnosti formátování pomáhají zachovat jasnost a přesnost. V tomto článku se naučíte, jak snadno použít styly horního a dolního indexu a zajistit profesionální výsledek na každém snímku.

## **Správa textu s horním a dolním indexem**

Můžete přidat text s horním a dolním indexem uvnitř libovolné části odstavce. Pro přidání textu s horním nebo dolním indexem v textovém rámci Aspose.Slides je nutné použít metodu [**setEscapement**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) třídy [PortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PortionFormat).

Tato vlastnost vrací nebo nastavuje text s horním nebo dolním indexem (hodnota od -100% (dolní index) do 100% (horní index)). Například:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
- Získejte referenci na snímek pomocí jeho indexu.
- Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape) typu [Rectangle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeType#Rectangle).
- Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrame) přidruženému k [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape).
- Vymažte existující odstavce
- Vytvořte nový objekt odstavce pro uchování textu s horním indexem a přidejte jej do [Paragraphs collection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrame#getParagraphs--) [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrame).
- Vytvořte nový objekt portion
- Nastavte vlastnost Escapement pro portion na hodnotu mezi 0 a 100 pro přidání horního indexu. (0 znamená žádný horní index)
- Nastavte nějaký text pro [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Portion) a poté jej přidejte do kolekce portion odstavce.
- Vytvořte nový objekt odstavce pro uchování textu s dolním indexem a přidejte jej do kolekce IParagraphs ITextFrame.
- Vytvořte nový objekt portion
- Nastavte vlastnost Escapement pro portion na hodnotu mezi 0 a -100 pro přidání dolního indexu. (0 znamená žádný dolní index)
- Nastavte nějaký text pro [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Portion) a poté jej přidejte do kolekce portion odstavce.
- Uložte prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je uvedena níže.

```javascript
// Vytvořte instanci třídy Presentation, která představuje PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získejte snímek
    var slide = pres.getSlides().get_Item(0);
    // Vytvořte textové pole
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Vytvořte odstavec pro text s horním indexem
    var superPar = new aspose.slides.Paragraph();
    // Vytvořte část s běžným textem
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Vytvořte část s textem v horním indexu
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Vytvořte odstavec pro text s dolním indexem
    var paragraph2 = new aspose.slides.Paragraph();
    // Vytvořte část s běžným textem
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Vytvořte část s textem v dolním indexu
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Přidejte odstavce do textového pole
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Zůstanou horní a dolní index zachovány při exportu do PDF nebo jiných formátů?**

Ano, Aspose.Slides správně zachovává formátování horního a dolního indexu při exportu prezentací do PDF, PPT/PPTX, obrázků a dalších podporovaných formátů. Specializované formátování zůstává ve všech výstupních souborech nedotčeno.

**Lze kombinovat horní a dolní index s dalšími styly formátování, jako je tučné nebo kurzíva?**

Ano, Aspose.Slides umožňuje kombinovat různé styly textu v jedné části textu. Můžete povolit tučné, kurzívu, podtržení a zároveň použít horní nebo dolní index nastavením odpovídajících vlastností ve třídě [PortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/).

**Funguje formátování horního a dolního indexu pro text uvnitř tabulek, grafů nebo SmartArtu?**

Ano, Aspose.Slides podporuje formátování ve většině objektů, včetně tabulek a prvků grafů. Při práci se SmartArtem je třeba získat přístup k odpovídajícím prvkům (například [SmartArtNode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartartnode/)) a jejich textovým kontejnerům a poté nastavit vlastnosti [PortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/) podobným způsobem.
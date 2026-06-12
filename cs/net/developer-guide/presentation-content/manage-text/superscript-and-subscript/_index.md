---
title: Správa horního a dolního indexu v prezentacích v .NET
linktitle: Horní a dolní index
type: docs
weight: 80
url: /cs/net/superscript-and-subscript/
keywords:
- horní index
- dolní index
- přidat horní index
- přidat dolní index
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zvládněte horní a dolní index v Aspose.Slides pro .NET a pozvedněte své prezentace profesionálním formátováním textu pro maximální dopad."
---
## **Přehled**

Aspose.Slides for .NET poskytuje funkce pro integraci textu ve formě horního a dolního indexu do vašich prezentací PowerPoint (PPT, PPTX) a OpenDocument (ODP). Ať už potřebujete zdůraznit chemické vzorce, matematické rovnice nebo doplnit obsah podčářkami, tyto specializované možnosti formátování pomáhají zachovat přehlednost a přesnost. V tomto článku se naučíte, jak hladce použít styly horního a dolního indexu a zajistit profesionální výstup na každém snímku.

## **Přidání horního a dolního indexu**

Můžete přidat text ve formě horního a dolního indexu do libovolného odstavce v prezentaci. Pro dosažení tohoto v Aspose.Slides musíte použít vlastnost `Escapement` třídy [PortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/portionformat/).

Tato vlastnost umožňuje nastavit text jako horní nebo dolní index s hodnotami od -100 % (dolní index) po 100 % (horní index).

Postup implementace:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) typu `Rectangle`.
1. Získejte přístup k [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) přidruženému k [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Vymažte existující odstavce.
1. Vytvořte nový [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph/) pro text v horním indexu a přidejte jej do kolekce odstavců [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/).
1. Vytvořte nový objekt textové části.
1. Nastavte vlastnost `Escapement` pro textovou část na hodnotu od 0 do 100, aby se aplikoval horní index (0 znamená žádný horní index).
1. Nastavte nějaký text pro [Portion](https://reference.aspose.com/slides/cs/net/aspose.slides/portion/) a přidejte jej do kolekce částí odstavce.
1. Vytvořte další [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph/) pro text v dolním indexu a přidejte jej do kolekce odstavců.
1. Vytvořte nový objekt textové části.
1. Nastavte vlastnost `Escapement` pro textovou část na hodnotu od 0 do -100, aby se aplikoval dolní index (0 znamená žádný dolní index).
1. Nastavte nějaký text pro [Portion](https://reference.aspose.com/slides/cs/net/aspose.slides/portion/) a přidejte jej do kolekce částí odstavce.
1. Uložte prezentaci jako soubor PPTX.

Následující C# kód implementuje tyto kroky:

```c#
using (Presentation presentation = new Presentation())
{
    // Získat první snímek.
    ISlide slide = presentation.Slides[0];

    // Vytvořit textové pole.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Vytvořit odstavec pro text v horním indexu.
    IParagraph superPar = new Paragraph();

    // Vytvořit textovou část s běžným textem.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Vytvořit textovou část s textem v horním indexu.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Vytvořit odstavec pro text v dolním indexu.
    IParagraph paragraph2 = new Paragraph();

    // Vytvořit textovou část s běžným textem.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Vytvořit textovou část s textem v dolním indexu.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Přidat odstavce do textového pole.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Horní a dolní index](superscript_and_subscript.png)

## **FAQ**

**Zůstane horní a dolní index zachován při exportu do PDF nebo jiných formátů?**

Ano, Aspose.Slides for .NET správně zachovává formátování horního a dolního indexu při exportu prezentací do PDF, PPT/PPTX, obrázků a dalších podporovaných formátů. Specializované formátování zůstává v všech výstupních souborech nedotčeno.

**Lze horní a dolní index kombinovat s dalšími formáty, jako je tučné nebo kurzíva?**

Ano, Aspose.Slides umožňuje kombinovat různé styly textu v jedné části. Můžete zapnout tučné, kurzívu, podtržení a současně aplikovat horní nebo dolní index konfigurací odpovídajících vlastností v [PortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/portionformat/).

**Funguje formátování horního a dolního indexu pro text uvnitř tabulek, grafů nebo SmartArt?**

Ano, Aspose.Slides for .NET podporuje formátování ve většině objektů, včetně tabulek a prvků grafů. Při práci se SmartArt je třeba získat přístup k příslušným elementům (například [SmartArtNode](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/smartartnode/)) a jejich textovým kontejnerům a poté nastavit vlastnosti [PortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/portionformat/) obdobně.
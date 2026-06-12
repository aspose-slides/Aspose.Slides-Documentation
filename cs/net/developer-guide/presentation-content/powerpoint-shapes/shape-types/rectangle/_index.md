---
title: Přidání obdélníků do prezentací v .NET
linktitle: Obdélník
type: docs
weight: 80
url: /cs/net/rectangle/
keywords:
- přidat obdélník
- vytvořit obdélník
- tvar obdélníka
- jednoduchý obdélník
- formátovaný obdélník
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zrychlete své prezentace PowerPoint přidáním obdélníků pomocí Aspose.Slides pro .NET—jednoduše navrhujte a upravujte tvary programově."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat obdélníkové tvary do snímků PowerPoint. Popisuje vytvoření jednoduchého obdélníka, vytvoření formátovaného obdélníka a uložení aktualizované prezentace jako soubor PPTX.  

Uvidíte také, jak použít základní formátování obdélníka, například plnou barvu výplně, barvu čáry a šířku čáry. Navíc FAQ článku odkazuje na související úkoly s obdélníky, včetně zaoblených rohů, výplní obrázky, vizuálních efektů, hypertextových odkazů, uzamykání tvarů, možností exportu a efektivních vlastností.

## **Vytvořit jednoduchý obdélník**
Stejně jako předchozí témata, i toto se týká přidání tvaru a tentokrát se budeme zabývat obdélníkem. V tomto tématu jsme popsali, jak vývojáři mohou přidat jednoduché nebo formátované obdélníky do svých snímků pomocí Aspose.Slides pro .NET. Pro přidání jednoduchého obdélníka do vybraného snímku prezentace postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)class.
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přidejte IAutoShape typu Rectangle pomocí metody AddAutoShape, která je součástí objektu IShapes object.
1. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali jednoduchý obdélník na první snímek prezentace.

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
using (Presentation pres = new Presentation())
{

    // Získejte první snímek
    ISlide sld = pres.Slides[0];

    // Přidejte automatický tvar typu obdélník
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Zapište soubor PPTX na disk
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Vytvořit formátovaný obdélník**
Pro přidání formátovaného obdélníka na snímek postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)class.
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přidejte IAutoShape typu Rectangle pomocí metody AddAutoShape, která je součástí objektu IShapes object.
1. Nastavte typ výplně obdélníka na Solid.
1. Nastavte barvu obdélníka pomocí vlastnosti SolidFillColor.Color, která je součástí objektu FillFormat přidruženého k objektu IShape.
1. Nastavte barvu čar obdélníka.
1. Nastavte šířku čar obdélníka.
1. Uložte upravenou prezentaci jako soubor PPTX.  
Výše uvedené kroky jsou implementovány v níže uvedeném příkladu.

```c#
 // Vytvořte instanci třídy Presentation, která představuje soubor PPTX
 using (Presentation pres = new Presentation())
 {
 
     // Získejte první snímek
     ISlide sld = pres.Slides[0];
 
     // Přidejte automatický tvar typu obdélník
     IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);
 
     // Aplikujte nějaké formátování na tvar obdélníku
     shp.FillFormat.FillType = FillType.Solid;
     shp.FillFormat.SolidFillColor.Color = Color.Chocolate;
 
     // Aplikujte nějaké formátování na čáru obdélníku
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
     shp.LineFormat.Width = 5;
 
     //Write soubor PPTX na disk
     pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **FAQ**

**Jak přidám obdélník se zaoblenými rohy?**

Použijte typ tvaru s zaoblenými rohy [shape type](https://reference.aspose.com/slides/cs/net/aspose.slides/shapetype/) a upravte poloměr rohu ve vlastnostech tvaru; zaoblení lze také aplikovat na jednotlivé rohy pomocí geometrických úprav.

**Jak vyplním obdélník obrázkem (texturou)?**

Vyberte typ výplně obrázku [fill type](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/), zadejte zdroj obrázku a nastavte [režimy natáhnutí/kladení](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillmode/).

**Může obdélník mít stín a záři?**

Ano. [Outer/inner shadow, glow, and soft edges](/slides/cs/net/shape-effect/) jsou k dispozici s nastavitelnými parametry.

**Mohu přeměnit obdélník na tlačítko s hypertextovým odkazem?**

Ano. [Assign a hyperlink](/slides/cs/net/manage-hyperlinks/) na kliknutí tvaru (přechod na snímek, soubor, webovou adresu nebo e‑mail).

**Jak mohu chránit obdélník před přesouváním a změnami?**

[Use shape locks](/slides/cs/net/applying-protection-to-presentation/): můžete zakázat přesouvání, změnu velikosti, výběr nebo úpravu textu pro zachování rozvržení.

**Mohu převést obdélník na rastrový obrázek nebo SVG?**

Ano. Můžete [render the shape](http://reference.aspose.com/slides/cs/net/aspose.slides/shape/getimage/) do obrázku s určenou velikostí/měřítkem nebo [export it as SVG](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/writeassvg/) pro vektorové použití.

**Jak rychle získat skutečné (efektivní) vlastnosti obdélníka s ohledem na téma a dědičnost?**

[Use the shape’s effective properties](/slides/cs/net/shape-effective-properties/): API vrací vypočtené hodnoty, které zohledňují styl tématu, rozvržení a lokální nastavení, což usnadňuje analýzu formátování.
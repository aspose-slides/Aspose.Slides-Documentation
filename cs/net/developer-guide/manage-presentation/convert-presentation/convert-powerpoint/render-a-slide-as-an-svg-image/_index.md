---
title: Vykreslení snímků prezentace jako SVG obrázky v .NET
linktitle: Snímek do SVG
type: docs
weight: 50
url: /cs/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentace do SVG
- snímek do SVG
- PPT do SVG
- PPTX do SVG
- uložit PPT jako SVG
- uložit PPTX jako SVG
- exportovat PPT do SVG
- exportovat PPTX do SVG
- vykreslit snímek
- převést snímek
- exportovat snímek
- vektorový obrázek
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro .NET vykreslovat snímky PowerPointu jako SVG obrázky. Vysoce kvalitní vizuály s jednoduchými příklady kódu v C#."
---
## **Přehled**

Tento článek vysvětluje, jak vykreslit snímky prezentace jako SVG obrázky pomocí Aspose.Slides. Popisuje formát SVG a jeho výhody, včetně škálovatelnosti, přístupnosti a vhodnosti pro vývoj webu.

Dozvíte se, jak načíst soubor prezentace, projít jeho snímky a uložit každý snímek jako samostatný SVG soubor. Článek pokrývá formáty prezentací PowerPoint a OpenDocument, včetně PPT, PPTX, ODP a PPS, a ukazuje, jak provést konverzi programově pomocí třídy `Presentation` a metody `WriteAsSvg`.

## **Formát SVG**

SVG - zkratka pro Scalable Vector Graphics - je standardní typ grafiky nebo formát používaný k vykreslování dvourozměrných obrázků. SVG ukládá obrázky jako vektory v XML s podrobnostmi, které definují jejich chování nebo vzhled.

SVG je jedním z mála formátů obrázků, které splňují velmi vysoké nároky v těchto oblastech: škálovatelnost, interaktivita, výkon, přístupnost, programovatelnost a další. Z těchto důvodů je běžně používán ve vývoji webu.

Možná budete chtít používat SVG soubory, když potřebujete

- **vytisknout svou prezentaci ve *velmi velkém formátu*.** SVG obrázky se mohou škálovat na libovolné rozlišení nebo úroveň. Můžete měnit velikost SVG obrázků tolikrát, kolik je potřeba, aniž byste obětovali kvalitu.
- **používat grafy a diagramy ze svých snímků na *různých médiích nebo platformách*.** Většina čteček dokáže interpretovat SVG soubory.
- **používat *nejmenší možné velikosti obrázků***. SVG soubory jsou obecně menší než jejich vysoce rozlišené ekvivalenty v jiných formátech, zejména ve formátech založených na bitmapě (JPEG nebo PNG).

## **Vykreslení snímku jako SVG obrázku**

Aspose.Slides pro .NET umožňuje exportovat snímky ve vašich prezentacích jako SVG obrázky. Proveďte následující kroky k vytvoření SVG obrázků:

*_Kroky: Konverze PowerPoint do SVG v C#_*

Následující ukázkový kód vysvětluje tyto konverze pomocí .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Kroky: Převod PowerPointu do SVG v C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Kroky: Převod PPT do SVG v C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Kroky: Převod PPTX do SVG v C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Kroky: Převod ODP do SVG v C#</strong></a>

_Kroky kódu:_

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
   * _.ppt_ rozšíření pro načtení **PPT** souboru ve třídě _Presentation_.
   * _.pptx_ rozšíření pro načtení **PPTX** souboru ve třídě _Presentation_.
   * _.odp_ rozšíření pro načtení **ODP** souboru ve třídě _Presentation_.
   * _.pps_ rozšíření pro načtení **PPS** souboru ve třídě _Presentation_.
2. Procházejte všechny snímky v prezentaci.
3. Zapište každý snímek do vlastního SVG souboru pomocí FileStream.

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet naši [bezplatnou webovou aplikaci](https://products.aspose.app/slides/cs/conversion/ppt-to-svg), ve které jsme implementovali funkci konverze PPT do SVG z Aspose.Slides pro .NET.
{{% /alert %}} 

Tento ukázkový kód v C# vám ukáže, jak převést PowerPoint do SVG pomocí Aspose.Slides: 

``` csharp
// Objekt Presentation může načíst formáty PowerPointu jako PPT, PPTX, ODP atd.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## **ČASTÉ DOTAZY**

**Proč může vypadat výsledné SVG v různých prohlížečích odlišně?**

Podpora konkrétních funkcí SVG je implementována různě v enginech prohlížečů. Parametry [SVGOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/svgoptions/) pomáhají vyhladit nekompatibility.

**Je možné exportovat nejen snímky, ale také jednotlivé tvary do SVG?**

Ano. Každý [tvar lze uložit jako samostatné SVG](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/writeassvg/), což je výhodné pro ikony, piktogramy a opětovné používání grafiky.

**Lze kombinovat více snímků do jednoho SVG (pruh/dokument)?**

Standardní scénář je jeden snímek → jedno SVG. Kombinace několika snímků do jednoho SVG plátna je krok po zpracování prováděný na úrovni aplikace.

## **Viz také** 

Tento článek také pokrývá následující témata. Kódy jsou stejné jako výše.

_Formát_: **PowerPoint**
- [C# PowerPoint do SVG Kód](#csharp-powerpoint-to-svg)
- [C# PowerPoint do SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint do SVG programově](#csharp-powerpoint-to-svg)
- [C# PowerPoint do SVG knihovna](#csharp-powerpoint-to-svg)
- [C# Uložit PowerPoint jako SVG](#csharp-powerpoint-to-svg)
- [C# Generovat SVG z PowerPointu](#csharp-powerpoint-to-svg)
- [C# Vytvořit SVG z PowerPointu](#csharp-powerpoint-to-svg)
- [C# PowerPoint do SVG převodník](#csharp-powerpoint-to-svg)

_Formát_: **PPT**
- [C# PPT do SVG Kód](#csharp-ppt-to-svg)
- [C# PPT do SVG API](#csharp-ppt-to-svg)
- [C# PPT do SVG programově](#csharp-ppt-to-svg)
- [C# PPT do SVG knihovna](#csharp-ppt-to-svg)
- [C# Uložit PPT jako SVG](#csharp-ppt-to-svg)
- [C# Generovat SVG z PPT](#csharp-ppt-to-svg)
- [C# Vytvořit SVG z PPT](#csharp-ppt-to-svg)
- [C# PPT do SVG převodník](#csharp-ppt-to-svg)

_Formát_: **PPTX**
- [C# PPTX do SVG Kód](#csharp-pptx-to-svg)
- [C# PPTX do SVG API](#csharp-pptx-to-svg)
- [C# PPTX do SVG programově](#csharp-pptx-to-svg)
- [C# PPTX do SVG knihovna](#csharp-pptx-to-svg)
- [C# Uložit PPTX jako SVG](#csharp-pptx-to-svg)
- [C# Generovat SVG z PPTX](#csharp-pptx-to-svg)
- [C# Vytvořit SVG z PPTX](#csharp-pptx-to-svg)
- [C# PPTX do SVG převodník](#csharp-pptx-to-svg)

_Formát_: **ODP**
- [C# ODP do SVG Kód](#csharp-odp-to-svg)
- [C# ODP do SVG API](#csharp-odp-to-svg)
- [C# ODP do SVG programově](#csharp-odp-to-svg)
- [C# ODP do SVG knihovna](#csharp-odp-to-svg)
- [C# Uložit ODP jako SVG](#csharp-odp-to-svg)
- [C# Generovat SVG z ODP](#csharp-odp-to-svg)
- [C# Vytvořit SVG z ODP](#csharp-odp-to-svg)
- [C# ODP do SVG převodník](#csharp-odp-to-svg)
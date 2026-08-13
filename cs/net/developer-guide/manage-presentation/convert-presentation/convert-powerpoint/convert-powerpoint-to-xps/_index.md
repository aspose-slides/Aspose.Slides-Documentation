---
title: Převod prezentací PowerPoint na XPS v .NET
linktitle: PowerPoint na XPS
type: docs
weight: 70
url: /cs/net/convert-powerpoint-to-xps/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na XPS
- prezentace na XPS
- snímek na XPS
- PPT na XPS
- PPTX na XPS
- uložit PPT jako XPS
- uložit PPTX jako XPS
- exportovat PPT do XPS
- exportovat PPTX do XPS
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Převádějte PowerPoint PPT/PPTX na vysoce kvalitní, platformně nezávislý XPS v .NET pomocí Aspose.Slides. Získejte podrobný návod krok za krokem a ukázkový kód v C#."
---
## **Přehled**

Aspose.Slides umožňuje převádět prezentace PowerPoint do formátu XPS uložením souboru PPT nebo PPTX do formátu XPS. Tento článek vysvětluje, kdy může být formát XPS užitečný, a ukazuje, jak provést konverzi pomocí Aspose.Slides s výchozími nastaveními nebo s vlastními nastaveními [XpsOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions/).

## **O XPS**
Microsoft vyvinul [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternativu k [PDF](https://docs.fileformat.com/pdf/). Umožňuje tisknout obsah výstupem souboru velmi podobného PDF. Formát XPS je založen na XML. Rozvržení nebo struktura souboru XPS zůstává stejná na všech operačních systémech a tiskárnách. 

## **Kdy použít formát Microsoft XPS**

{{% alert color="info" %}} 

Chcete-li vidět, jak Aspose.Slides převádí prezentaci PPT nebo PPTX do formátu XPS, můžete si vyzkoušet [tuto bezplatnou online konverzní aplikaci](https://products.aspose.app/slides/cs/conversion). 

{{% /alert %}} 

Pokud chcete snížit náklady na úložiště, můžete převést svou prezentaci Microsoft PowerPoint do formátu XPS. Tím bude pro vás snazší ukládat, sdílet a tisknout dokumenty. 

Microsoft i nadále poskytuje silnou podporu pro XPS ve Windows (dokonce ve Windows 10), takže byste mohli zvážit ukládání souborů do tohoto formátu. Pokud pracujete s Windows 8.1, Windows 8, Windows 7 a Windows Vista, může být XPS ve skutečnosti nejlepší volbou pro určité operace. 

- **Windows 8** používá formát OXPS (Open XPS) pro soubory XPS. OXPS je standardizovaná verze původního formátu XPS. Windows 8 poskytuje lepší podporu pro soubory XPS než pro soubory PDF. 
  - **XPS:** Vestavěný prohlížeč/čtečka XPS a možnost tisku do XPS jsou k dispozici. 
  - **PDF**: K dispozici je čtečka PDF, ale chybí možnost tisku do PDF. 

- **Windows 7 a Windows Vista** používají původní formát XPS. Tyto operační systémy také poskytují lepší podporu pro soubory XPS než pro PDF. 
  - **XPS**: Vestavěný prohlížeč XPS a možnost tisku do XPS jsou k dispozici. 
  - **PDF**: Žádná čtečka PDF. Žádná možnost tisku do PDF. 

|<p>**Vstupní PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Výstupní XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft nakonec implementoval podporu tiskových operací v PDF prostřednictvím funkce Print to PDF ve Windows 10. Dříve bylo očekáváno, že uživatelé budou tisknout dokumenty pomocí formátu XPS. 

## **Konverze XPS pomocí Aspose.Slides**

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/net/) pro .NET můžete použít metodu [**Save**](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/methods/save/index) vystavenou třídou [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) k převodu celé prezentace do dokumentu XPS. 

Při převodu prezentace do XPS musíte prezentaci uložit pomocí jednoho z následujících nastavení:

- Výchozí nastavení (bez [**XPSOptions**](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions))
- Vlastní nastavení (s [**XPSOptions**](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions))

### **Převod prezentací do XPS pomocí výchozího nastavení**

Tento ukázkový kód v C# ukazuje, jak převést prezentaci do dokumentu XPS pomocí standardních nastavení:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte objekt Presentation, který představuje soubor prezentace
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Ukládání prezentace do XPS dokumentu
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **Převod prezentací do XPS pomocí vlastního nastavení**
Tento ukázkový kód ukazuje, jak převést prezentaci do dokumentu XPS pomocí vlastního nastavení v C#:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte objekt Presentation, který představuje soubor prezentace
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Vytvořte instanci třídy TiffOptions
    XpsOptions options = new XpsOptions();

    // Uložit MetaFiles jako PNG
    options.SaveMetafilesAsPng = true;

    // Uložit prezentaci do XPS dokumentu
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **Často kladené otázky**

### Mohu uložit XPS do streamu místo souboru?

Ano—Aspose.Slides vám umožní exportovat přímo do streamu, což je ideální pro webová API, server‑side pipeline nebo jakýkoli scénář, kde chcete XPS odeslat bez zásahu do souborového systému.

### Přenášejí se skryté snímky do XPS a mohu je vyloučit?

Ve výchozím nastavení jsou vykresleny pouze běžné (viditelné) snímky. Můžete [zahrnout nebo vyloučit skryté snímky](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions/showhiddenslides/) prostřednictvím [nastavení exportu](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions/) před uložením do XPS, čímž zajistíte, že výstup bude obsahovat přesně stránky, které chcete.
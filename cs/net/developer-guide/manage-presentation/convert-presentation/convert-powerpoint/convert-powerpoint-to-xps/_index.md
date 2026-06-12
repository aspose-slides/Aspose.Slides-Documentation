---
title: Převod prezentací PowerPoint do XPS v .NET
linktitle: PowerPoint do XPS
type: docs
weight: 70
url: /cs/net/convert-powerpoint-to-xps/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do XPS
- prezentace do XPS
- snímek do XPS
- PPT do XPS
- PPTX do XPS
- uložit PPT jako XPS
- uložit PPTX jako XPS
- exportovat PPT do XPS
- exportovat PPTX do XPS
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Převádějte PowerPoint PPT/PPTX na vysoce kvalitní, platformě nezávislý XPS v .NET pomocí Aspose.Slides. Získejte průvodce krok za krokem a ukázkový kód v C#."
---
## **Přehled**

Aspose.Slides vám umožňuje převádět prezentace PowerPoint do formátu XPS uložením souboru PPT nebo PPTX do formátu XPS. Tento článek vysvětluje, kdy může být formát XPS užitečný, a ukazuje, jak provést konverzi pomocí Aspose.Slides s výchozími nastaveními nebo s vlastními nastaveními [XpsOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions/) .

## **O XPS**
Microsoft vyvinul [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternativu k [PDF](https://docs.fileformat.com/pdf/). Umožňuje tisk obsahu vytvořením souboru velmi podobného PDF. Formát XPS je založen na XML. Rozvržení nebo struktura souboru XPS zůstává stejná na všech operačních systémech a tiskárnách.

## **Kdy použít formát Microsoft XPS**

{{% alert color="primary" %}} 

Chcete-li vidět, jak Aspose.Slides převádí prezentaci PPT nebo PPTX do formátu XPS, můžete si prohlédnout [tuto bezplatnou online konverzní aplikaci](https://products.aspose.app/slides/cs/conversion). 

{{% /alert %}} 

Pokud chcete snížit náklady na úložiště, můžete převést svou prezentaci Microsoft PowerPoint do formátu XPS. Tím bude pro vás jednodušší ukládat, sdílet a tisknout dokumenty.

Microsoft i nadále implementuje silnou podporu XPS ve Windows (dokonce ve Windows 10), takže můžete zvážit ukládání souborů do tohoto formátu. Pokud pracujete s Windows 8.1, Windows 8, Windows 7 a Windows Vista, pak může být XPS ve skutečnosti vaší nejlepší volbou pro určité operace.

- **Windows 8** používá formát OXPS (Open XPS) pro soubory XPS. OXPS je standardizovaná verze původního formátu XPS. Windows 8 poskytuje lepší podporu souborů XPS než souborů PDF. 
  - **XPS:** Vestavěný prohlížeč/čtečka XPS a funkce tisku do XPS jsou k dispozici. 
  - **PDF**: K dispozici je čtečka PDF, ale funkce tisku do PDF chybí. 

- **Windows 7 a Windows Vista** používají původní formát XPS. Tyto operační systémy také poskytují lepší podporu souborů XPS než PDF. 
  - **XPS**: Vestavěný prohlížeč XPS a funkce tisku do XPS jsou k dispozici. 
  - **PDF**: Žádná čtečka PDF. Žádná funkce tisku do PDF.

|<p>**Vstup PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Výstup XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft nakonec implementoval podporu tiskových operací v PDF prostřednictvím funkce Tisk do PDF ve Windows 10. Dříve uživatelé museli tisknout dokumenty přes formát XPS.

## **Konverze XPS pomocí Aspose.Slides**

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/net/) pro .NET můžete použít metodu [**Save**](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/methods/save/index) vystavenou třídou [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) k převodu celé prezentace do dokumentu XPS.

Při převodu prezentace do XPS musíte prezentaci uložit pomocí jednoho z následujících nastavení:

- Výchozí nastavení (bez [**XPSOptions**](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions))
- Vlastní nastavení (s [**XPSOptions**](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions))

### **Převést prezentace do XPS pomocí výchozího nastavení**

Tento ukázkový kód v jazyce C# ukazuje, jak převést prezentaci do dokumentu XPS pomocí standardních nastavení:

```c#
 // Vytvořte objekt Presentation, který představuje soubor prezentace
 using (Presentation pres = new Presentation("Convert_XPS.pptx"))
 {
     // Uložení prezentace do dokumentu XPS
     pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
 }
```

### **Převést prezentace do XPS pomocí vlastních nastavení**

Tento ukázkový kód ukazuje, jak převést prezentaci do dokumentu XPS pomocí vlastních nastavení v jazyce C#:

```c#
 // Vytvořte objekt Presentation, který představuje soubor prezentace
 using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
 {
     // Vytvořte instanci třídy TiffOptions
     XpsOptions options = new XpsOptions();

     // Uložit MetaFiles jako PNG
     options.SaveMetafilesAsPng = true;

     // Uložit prezentaci do dokumentu XPS
     pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
 }
```

## **Často kladené otázky**

**Mohu ukládat XPS do proudu místo souboru?**

Ano—Aspose.Slides umožňuje exportovat přímo do proudu, což je ideální pro webová API, server‑side pipeline nebo jakýkoli scénář, kde chcete XPS odeslat, aniž byste se dotkli souborového systému.

**Přenášejí se skryté snímky do XPS a mohu je vyloučit?**

Ve výchozím nastavení jsou vykreslovány pouze běžné (viditelné) snímky. Pomocí [exportních nastavení](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions/) můžete [zahrnout nebo vyloučit skryté snímky](https://reference.aspose.com/slides/cs/net/aspose.slides.export/xpsoptions/showhiddenslides/) před uložením do XPS, čímž zajistíte, že výstup obsahuje přesně stránky, které chcete.
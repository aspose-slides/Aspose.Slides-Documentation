---
title: "Převod prezentací PowerPoint do XPS v C++"
linktitle: "PowerPoint do XPS"
type: docs
weight: 70
url: /cs/cpp/convert-powerpoint-to-xps
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
- C++
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitního, platformně nezávislého XPS v C++ pomocí Aspose.Slides. Získejte krok za krokem návod a ukázkový kód."
---
## **Přehled**

Aspose.Slides vám umožňuje převádět prezentace PowerPoint do formátu XPS uložením souboru PPT nebo PPTX do formátu XPS. Tento článek vysvětluje, kdy může být formát XPS užitečný a ukazuje, jak provést konverzi pomocí Aspose.Slides s výchozími nastaveními nebo vlastním nastavením [XpsOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/xpsoptions/) .

## **O XPS**
Microsoft vyvinul [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternativu k [PDF](https://docs.fileformat.com/pdf/). Umožňuje tisknout obsah vytvořením souboru velmi podobného PDF. Formát XPS je založen na XML. Rozvržení nebo struktura souboru XPS zůstává stejná na všech operačních systémech a tiskárnách. 

## **Kdy použít formát Microsoft XPS**

{{% alert color="primary" %}} 

Chcete-li vidět, jak Aspose.Slides převádí prezentaci PPT nebo PPTX do formátu XPS, můžete si vyzkoušet [tuto bezplatnou online konverzní aplikaci](https://products.aspose.app/slides/cs/conversion). 

{{% /alert %}} 

Pokud chcete snížit náklady na úložiště, můžete svou prezentaci Microsoft PowerPoint převést do formátu XPS. Tím bude pro vás snadnější ukládat, sdílet a tisknout dokumenty. 

Microsoft i nadále implementuje silnou podporu XPS ve Windows (dokonce i ve Windows 10), takže byste mohli zvážit ukládání souborů do tohoto formátu. Pokud pracujete s Windows 8.1, Windows 8, Windows 7 a Windows Vista, může být XPS ve skutečnosti vaší nejlepší volbou pro určité operace. 

- **Windows 8** používá formát OXPS (Open XPS) pro soubory XPS. OXPS je standardizovaná verze původního formátu XPS. Windows 8 poskytuje lepší podporu pro soubory XPS než pro soubory PDF. 
  - **XPS:** Vestavěný XPS viewer/reader a printing to XPS feature available. 
  - **PDF**: PDF reader available but no printing to PDF feature. 

- **Windows 7 a Windows Vista** používají původní formát XPS. Tyto operační systémy také poskytují lepší podporu pro soubory XPS než pro PDF. 
  - **XPS**: Vestavěný XPS viewer and printing to XPS feature available. 
  - **PDF**: No PDF reader. No printing to PDF feature. 

|<p>**Vstup PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Výstup XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft nakonec implementoval podporu tiskových operací do PDF prostřednictvím funkce Print to PDF ve Windows 10. Dříve bylo od uživatelů očekáváno, že budou dokumenty tisknout přes formát XPS. 

## **Konverze XPS pomocí Aspose.Slides**

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/cpp/) pro C++ můžete použít metodu [**Save**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) zpřístupněnou třídou [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) k převodu celé prezentace do dokumentu XPS. 

Při konverzi prezentace do XPS musíte prezentaci uložit pomocí jednoho z následujících nastavení:

- Výchozí nastavení (bez [**XPSOptions**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.xps_options))
- Vlastní nastavení (s [**XPSOptions**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.xps_options))

### **Převod prezentací do XPS pomocí výchozích nastavení**

Tento ukázkový kód v C++ ukazuje, jak převést prezentaci do dokumentu XPS pomocí standardních nastavení:

``` cpp
// Vytvořte objekt Presentation, který představuje soubor prezentace
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Uložení prezentace do dokumentu XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Převod prezentací do XPS pomocí vlastních nastavení**
Tento ukázkový kód ukazuje, jak převést prezentaci do dokumentu XPS pomocí vlastních nastavení v C++:

``` cpp
// Vytvořte objekt Presentation, který představuje soubor prezentace
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Vytvořte instanci třídy TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Uložte MetaFiles jako PNG
options->set_SaveMetafilesAsPng(true);

// Uložte prezentaci do dokumentu XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **Časté dotazy**

**Mohu ukládat do XPS do proudu místo souboru?**

Ano — Aspose.Slides vám umožňuje exportovat přímo do proudu, což je ideální pro webová API, server‑side pipeline nebo jakýkoli scénář, kdy chcete XPS odeslat bez zásahu do souborového systému.

**Přenášejí se skryté snímky do XPS a mohu je vyloučit?**

Ve výchozím nastavení jsou vykresleny pouze běžné (viditelné) snímky. Můžete [zahrnout nebo vyloučit skryté snímky](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) pomocí [nastavení exportu](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/xpsoptions/) před uložením do XPS, čímž zajistíte, že výstup bude obsahovat přesně stránky, které chcete.
---
title: Převod prezentací PowerPoint do XPS v C++
linktitle: PowerPoint na XPS
type: docs
weight: 70
url: /cs/cpp/convert-powerpoint-to-xps
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
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
- C++
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitního, platformně nezávislého XPS v C++ pomocí Aspose.Slides. Získejte krok za krokem průvodce a ukázkový kód."
---
## **Přehled**

Aspose.Slides vám umožňuje převádět prezentace PowerPoint do formátu XPS uložením souboru PPT nebo PPTX do formátu XPS. Tento článek vysvětluje, kdy může být formát XPS užitečný, a ukazuje, jak provést konverzi pomocí Aspose.Slides s výchozími nebo vlastními nastaveními [XpsOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/xpsoptions/) .

## **O XPS**

Microsoft vyvinul [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternativu k [PDF](https://docs.fileformat.com/pdf/). Umožňuje tisknout obsah vytvořením souboru velmi podobného PDF. Formát XPS je založen na XML. Rozvržení nebo struktura souboru XPS zůstává stejná na všech operačních systémech a tiskárnách. 

## **Kdy použít formát Microsoft XPS**

{{% alert color="info" %}} 

Chcete-li vidět, jak Aspose.Slides převádí prezentaci PPT nebo PPTX do formátu XPS, můžete si vyzkoušet [tuto bezplatnou online konverzní aplikaci](https://products.aspose.app/slides/cs/conversion). 

{{% /alert %}} 

Pokud chcete snížit náklady na úložiště, můžete převést vaši prezentaci Microsoft PowerPoint do formátu XPS. Tím bude jednodušší ukládat, sdílet a tisknout vaše dokumenty. 

Microsoft nadále poskytuje silnou podporu pro XPS ve Windows (dokonce i ve Windows 10), takže byste mohli zvážit ukládání souborů do tohoto formátu. Pokud pracujete s Windows 8.1, Windows 8, Windows 7 a Windows Vista, pak může být XPS ve skutečnosti vaší nejlepší volbou pro určité operace. 

- **Windows 8** používá formát OXPS (Open XPS) pro soubory XPS. OXPS je standardizovaná verze původního formátu XPS. Windows 8 poskytuje lepší podporu pro soubory XPS než pro soubory PDF. 
  - **XPS:** Vestavěný prohlížeč/čtečka XPS a funkce tisk do XPS jsou k dispozici. 
  - **PDF**: K dispozici je čtečka PDF, ale není funkce tisku do PDF. 

- **Windows 7 a Windows Vista** používají původní formát XPS. Tyto operační systémy také poskytují lepší podporu pro soubory XPS než pro PDF. 
  - **XPS**: Vestavěný prohlížeč XPS a funkce tisk do XPS jsou k dispozici. 
  - **PDF**: Žádná čtečka PDF. Žádná funkce tisku do PDF. 

|<p>**Vstup PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Výstup XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft nakonec implementoval podporu tisku do PDF prostřednictvím funkce Print to PDF ve Windows 10. Dříve se od uživatelů očekávalo, že budou dokumenty tisknout přes formát XPS. 

## **Konverze XPS pomocí Aspose.Slides**

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/cpp/) pro C++ můžete použít metodu [**Save**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) vystavenou třídou [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) k převodu celé prezentace do dokumentu XPS. 

Při převodu prezentace do XPS musíte prezentaci uložit pomocí některého z těchto nastavení:

- Výchozí nastavení (bez [**XPSOptions**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.xps_options))
- Vlastní nastavení (s [**XPSOptions**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.xps_options))

### **Převod prezentací do XPS pomocí výchozího nastavení**

Tento ukázkový kód v C++ ukazuje, jak převést prezentaci do dokumentu XPS pomocí standardních nastavení:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Vytvořte objekt Presentation, který představuje soubor prezentace
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Ukládání prezentace do dokumentu XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Převod prezentací do XPS pomocí vlastního nastavení**

Tento ukázkový kód ukazuje, jak převést prezentaci do dokumentu XPS pomocí vlastních nastavení v C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Vytvořte objekt Presentation, který představuje soubor prezentace
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Vytvořte instanci třídy XpsOptions
auto options = System::MakeObject<XpsOptions>();

// Uložit MetaFiles jako PNG
options->set_SaveMetafilesAsPng(true);

// Uložit prezentaci do dokumentu XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **Často kladené otázky**

### Můžu uložit XPS do streamu místo souboru?

Ano — Aspose.Slides umožňuje exportovat přímo do streamu, což je ideální pro webová API, server‑side pipeline nebo jakýkoli scénář, kde chcete XPS odeslat bez zásahu do souborového systému.

### Přenášejí se skryté snímky do XPS a mohu je vyloučit?

Ve výchozím nastavení jsou renderovány pouze běžné (viditelné) snímky. Můžete [zahrnout nebo vyloučit skryté snímky](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) prostřednictvím [nastavení exportu](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/xpsoptions/) před uložením do XPS, což zajistí, že výstup bude obsahovat přesně stránky, které zamýšlíte.
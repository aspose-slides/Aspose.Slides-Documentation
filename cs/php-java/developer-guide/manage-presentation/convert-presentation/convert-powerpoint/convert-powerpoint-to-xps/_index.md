---
title: Převod prezentací PowerPoint do XPS v PHP
linktitle: PowerPoint do XPS
type: docs
weight: 70
url: /cs/php-java/convert-powerpoint-to-xps/
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
- PHP
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX na vysoce kvalitní, platformně nezávislé XPS pomocí Aspose.Slides pro PHP přes Java. Získáte podrobný návod a ukázkový kód."
---
## **Přehled**

Aspose.Slides vám umožňuje převést prezentace PowerPoint na XPS uložením souboru PPT nebo PPTX ve formátu XPS. Tento článek vysvětluje, kdy může být formát XPS užitečný, a ukazuje, jak provést konverzi pomocí Aspose.Slides s výchozími nastaveními nebo s vlastními nastaveními [XpsOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xpsoptions/).

## **O XPS**

Microsoft vyvinul [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternativu k [PDF](https://docs.fileformat.com/pdf/). Umožňuje vám tisknout obsah výstupem do souboru velmi podobného PDF. Formát XPS je založený na XML. Rozvržení nebo struktura souboru XPS zůstává stejná na všech operačních systémech a tiskárnách.

## **Kdy použít formát Microsoft XPS**

{{% alert color="primary" %}} 

Chcete-li vidět, jak Aspose.Slides převádí prezentaci PPT nebo PPTX do formátu XPS, můžete si prohlédnout [tuto bezplatnou online konvertovací aplikaci](https://products.aspose.app/slides/cs/conversion). 

{{% /alert %}} 

Pokud chcete snížit náklady na úložiště, můžete svou prezentaci Microsoft PowerPoint převést do formátu XPS. Tím bude pro vás jednodušší ukládat, sdílet a tisknout dokumenty. 

Microsoft i nadále poskytuje silnou podporu pro XPS ve Windows (dokonce i ve Windows 10), takže můžete zvážit ukládání souborů do tohoto formátu. Pokud pracujete s Windows 8.1, Windows 8, Windows 7 a Windows Vista, může být XPS ve skutečnosti vaší nejlepší volbou pro určité operace. 

- **Windows 8** používá formát OXPS (Open XPS) pro soubory XPS. OXPS je standardizovaná verze původního formátu XPS. Windows 8 poskytuje lepší podporu pro soubory XPS než pro soubory PDF. 
  - **XPS:** Vestavěný prohlížeč/čtečka XPS a funkce tisku do XPS jsou k dispozici. 
  - **PDF:** Čtečka PDF je k dispozici, ale funkce tisku do PDF chybí. 

- **Windows 7 a Windows Vista** používají původní formát XPS. Tyto operační systémy také poskytují lepší podporu pro soubory XPS než pro PDF. 
  - **XPS:** Vestavěná čtečka XPS a funkce tisku do XPS jsou k dispozici. 
  - **PDF:** Čtečka PDF chybí. Funkce tisku do PDF není k dispozici. 

|<p>**Vstup PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Výstup XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft nakonec implementoval podporu tisku do PDF prostřednictvím funkce Tisk do PDF ve Windows 10. Dříve uživatelé očekávali, že dokumenty budou tisknuty přes formát XPS. 

## **Konverze XPS pomocí Aspose.Slides**

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/php-java/) pro Java můžete použít metodu [**Save**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) poskytovanou třídou [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) k převodu celé prezentace do dokumentu XPS.

Při převodu prezentace do XPS musíte prezentaci uložit pomocí jednoho z těchto nastavení:

- Výchozí nastavení (bez [**XPSOptions**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xpsoptions))
- Vlastní nastavení (s [**XPSOptions**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xpsoptions))

### **Převod prezentací do XPS pomocí výchozích nastavení**

Tento ukázkový kód vám ukazuje, jak převést prezentaci do dokumentu XPS pomocí standardních nastavení:

```php
  # Vytvořte objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # Ukládání prezentace do XPS dokumentu
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Převod prezentací do XPS pomocí vlastních nastavení**

Tento ukázkový kód vám ukazuje, jak převést prezentaci do dokumentu XPS pomocí vlastních nastavení:

```php
  # Vytvořte objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Vytvořte instanci třídy TiffOptions
    $options = new XpsOptions();
    # Uložit MetaFiles jako PNG
    $options->setSaveMetafilesAsPng(true);
    # Uložit prezentaci do XPS dokumentu
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Mohu ukládat XPS do proudu místo souboru?**

Ano — Aspose.Slides vám umožňuje exportovat přímo do proudu, což je ideální pro webová API, server‑side pipeline nebo jakýkoli scénář, kdy chcete XPS poslat, aniž byste zasahovali do souborového systému.

**Přenesou se skryté snímky do XPS a mohu je vyloučit?**

Ve výchozím nastavení jsou renderovány pouze běžné (viditelné) snímky. Můžete [zahrnout nebo vyloučit skryté snímky](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) pomocí [nastavení exportu](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xpsoptions/) před uložením do XPS, čímž zajistíte, že výstup bude obsahovat přesně stránky, které zamýšlíte.
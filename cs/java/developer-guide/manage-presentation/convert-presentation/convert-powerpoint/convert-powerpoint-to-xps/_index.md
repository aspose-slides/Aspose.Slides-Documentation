---
title: Převod prezentací PowerPoint do XPS v Javě
linktitle: PowerPoint do XPS
type: docs
weight: 70
url: /cs/java/convert-powerpoint-to-xps/
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
- Java
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitního, platformově nezávislého XPS v Javě pomocí Aspose.Slides. Získáte krok za krokem průvodce a ukázkový kód."
---
## **Přehled**

Aspose.Slides vám umožňuje převést prezentace PowerPoint do formátu XPS uložením souboru PPT nebo PPTX do formátu XPS. Tento článek vysvětluje, kdy může být formát XPS užitečný, a ukazuje, jak provést konverzi pomocí Aspose.Slides s výchozími nastaveními nebo s vlastními nastaveními [XpsOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xpsoptions/).

## **O XPS**
Microsoft vyvinul [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternativu k [PDF](https://docs.fileformat.com/pdf/). Umožňuje tisk obsahu vytvořením souboru velmi podobného PDF. Formát XPS je založen na XML. Rozvržení nebo struktura souboru XPS zůstává stejná na všech operačních systémech a tiskárnách. 

## **Kdy použít formát Microsoft XPS**

{{% alert color="primary" %}} 

Chcete-li vidět, jak Aspose.Slides konvertuje prezentaci PPT nebo PPTX do formátu XPS, můžete si prohlédnout [tuto bezplatnou online konverzní aplikaci](https://products.aspose.app/slides/cs/conversion). 

{{% /alert %}} 

Pokud chcete snížit náklady na úložiště, můžete převést svou prezentaci Microsoft PowerPoint do formátu XPS. Tímto způsobem bude pro vás snazší ukládat, sdílet a tisknout dokumenty. 

Microsoft nadále poskytuje silnou podporu pro XPS ve Windows (dokonce i ve Windows 10), takže byste mohli zvážit ukládání souborů do tohoto formátu. Pokud pracujete s Windows 8.1, Windows 8, Windows 7 a Windows Vista, může být XPS ve skutečnosti pro některé operace nejlepší volbou. 

- **Windows 8** používá formát OXPS (Open XPS) pro soubory XPS. OXPS je standardizovaná verze původního formátu XPS. Windows 8 poskytuje lepší podporu pro soubory XPS než pro soubory PDF. 
  - **XPS:** Vestavěný prohlížeč/čtečka XPS a funkce tisku do XPS jsou k dispozici. 
  - **PDF**: K dispozici je PDF čtečka, ale funkce tisku do PDF není k dispozici. 

- **Windows 7 a Windows Vista** používají původní formát XPS. Tyto operační systémy také poskytují lepší podporu pro soubory XPS než pro PDF. 
  - **XPS**: Vestavěný prohlížeč XPS a funkce tisku do XPS jsou k dispozici. 
  - **PDF**: Žádná PDF čtečka. Žádná funkce tisku do PDF. 

|<p>**Vstup PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Výstup XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft nakonec zavedl podporu tiskových operací v PDF prostřednictvím funkce Print to PDF ve Windows 10. Dříve uživatelé očekávali tisk dokumentů přes formát XPS. 

## **Konverze XPS pomocí Aspose.Slides**

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/java/) pro Java můžete použít metodu [**Save**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) vystavenou třídou [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), která převádí celou prezentaci na dokument XPS. 

Při konverzi prezentace do XPS musíte prezentaci uložit s jedním z těchto nastavení:

- Výchozí nastavení (bez [**XPSOptions**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xpsoptions))
- Vlastní nastavení (s [**XPSOptions**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xpsoptions))

### **Převod prezentací do XPS pomocí výchozího nastavení**

Tento ukázkový kód v jazyce Java ukazuje, jak převést prezentaci do dokumentu XPS pomocí standardních nastavení:

```java
// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Ukládání prezentace do dokumentu XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Převod prezentací do XPS pomocí vlastních nastavení**
Tento ukázkový kód ukazuje, jak převést prezentaci do dokumentu XPS pomocí vlastních nastavení v jazyce Java:

```java
// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Vytvořte instanci třídy TiffOptions
    XpsOptions options = new XpsOptions();

    // Uložit MetaFiles jako PNG
    options.setSaveMetafilesAsPng(true);

    // Uložit prezentaci do dokumentu XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu uložit XPS do proudu místo souboru?**

Ano—Aspose.Slides vám umožňuje exportovat přímo do proudu, což je ideální pro webová rozhraní API, serverové pipeline nebo jakýkoli scénář, kde chcete XPS odeslat, aniž byste se dotkli souborového systému.

**Přenášejí se skryté snímky do XPS a mohu je vyloučit?**

Ve výchozím nastavení jsou renderovány pouze běžné (viditelné) snímky. Pomocí [zahrnutí nebo vyloučení skrytých snímků](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) můžete prostřednictvím [nastavení exportu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xpsoptions/) před uložením do XPS zajistit, že výstup bude obsahovat přesně stránky, které chcete.
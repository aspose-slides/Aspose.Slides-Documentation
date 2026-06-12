---
title: Převod prezentací PowerPoint na XPS v Androidu
linktitle: PowerPoint na XPS
type: docs
weight: 70
url: /cs/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX na vysoce kvalitní, platformově nezávislé XPS v Javě pomocí Aspose.Slides pro Android. Získáte podrobný návod a ukázkový kód."
---
## **Přehled**

Aspose.Slides vám umožňuje převést prezentace PowerPoint do formátu XPS uložením souboru PPT nebo PPTX do formátu XPS. Tento článek vysvětluje, kdy může být formát XPS užitečný, a ukazuje, jak provést konverzi pomocí Aspose.Slides s výchozími nastaveními nebo s vlastním nastavením [XpsOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xpsoptions/) .

## **O XPS**

Microsoft vyvinul [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternativu k [PDF](https://docs.fileformat.com/pdf/). Umožňuje tisknout obsah vytvořením souboru, který je velmi podobný PDF. Formát XPS je založen na XML. Rozvržení nebo struktura souboru XPS zůstává stejná na všech operačních systémech a tiskárnách. 

## **Kdy použít formát Microsoft XPS**

{{% alert color="primary" %}} 

Chcete-li vidět, jak Aspose.Slides převádí prezentaci PPT nebo PPTX do formátu XPS, můžete si vyzkoušet [tuto bezplatnou online konverzní aplikaci](https://products.aspose.app/slides/cs/conversion). 

{{% /alert %}} 

Pokud chcete snížit náklady na úložiště, můžete převést svou prezentaci Microsoft PowerPoint do formátu XPS. Tím bude jednodušší ukládat, sdílet a tisknout vaše dokumenty. 

Microsoft i nadále poskytuje silnou podporu pro XPS ve Windows (dokonce i ve Windows 10), takže můžete zvážit ukládání souborů do tohoto formátu. Pokud pracujete s Windows 8.1, Windows 8, Windows 7 a Windows Vista, může být XPS pro některé operace skutečně nejlepší volbou. 

- **Windows 8** používá formát OXPS (Open XPS) pro soubory XPS. OXPS je standardizovaná verze původního formátu XPS. Windows 8 poskytuje lepší podporu souborů XPS než souborů PDF. 
  - **XPS:** Vestavěný prohlížeč/čtečka XPS a funkce tisku do XPS jsou k dispozici. 
  - **PDF:** K dispozici je čtečka PDF, ale chybí funkce tisku do PDF. 

- **Windows 7 a Windows Vista** používají původní formát XPS. Tyto operační systémy také poskytují lepší podporu souborů XPS než PDF. 
  - **XPS:** Vestavěný prohlížeč XPS a funkce tisku do XPS jsou k dispozici. 
  - **PDF:** Žádná čtečka PDF. Žádná funkce tisku do PDF. 

|<p>**Vstup PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Výstup XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft nakonec implementoval podporu tiskových operací do PDF prostřednictvím funkce Tisk do PDF ve Windows 10. Dříve byly uživatelé očekáváni, že budou dokumenty tisknout přes formát XPS. 

## **Konverze XPS pomocí Aspose.Slides**

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/androidjava/) pro Java můžete použít metodu [**Save**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) zveřejněnou třídou [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation), která převádí celou prezentaci do dokumentu XPS.

Při převodu prezentace do XPS musíte prezentaci uložit pomocí jednoho z těchto nastavení:

- Výchozí nastavení (bez [**XPSOptions**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xpsoptions))
- Vlastní nastavení (s [**XPSOptions**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xpsoptions))

### **Převod prezentací do XPS s výchozími nastaveními**

Tento ukázkový kód v Java vám ukazuje, jak převést prezentaci do XPS dokumentu pomocí standardních nastavení:

```java
// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Uložení prezentace do dokumentu XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Převod prezentací do XPS s vlastními nastaveními**

Tento ukázkový kód vám ukazuje, jak převést prezentaci do XPS dokumentu pomocí vlastních nastavení v Java:

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

Ano—Aspose.Slides vám umožňuje exportovat přímo do proudu, což je ideální pro webová API, server‑side pipeline nebo jakýkoli scénář, kdy chcete XPS poslat, aniž byste se dotýkali souborového systému.

**Přenášejí se skryté snímky do XPS a mohu je vyloučit?**

Ve výchozím nastavení jsou vykresleny pouze běžné (viditelné) snímky. Pomocí [zahrnutí nebo vyloučení skrytých snímků](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) skrze [exportní nastavení](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xpsoptions/) před uložením do XPS můžete zajistit, že výstup bude obsahovat přesně stránky, které chcete.
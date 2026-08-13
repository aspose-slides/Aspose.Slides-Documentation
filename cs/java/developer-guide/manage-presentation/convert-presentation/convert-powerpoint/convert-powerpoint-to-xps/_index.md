---
title: Převod prezentací PowerPoint do XPS v Javě
linktitle: PowerPoint na XPS
type: docs
weight: 70
url: /cs/java/convert-powerpoint-to-xps/
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
- Java
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitního, platformně nezávislého XPS v Javě pomocí Aspose.Slides. Získáte podrobný návod a ukázkový kód."
---
## **Přehled**

Aspose.Slides umožňuje převádět prezentace PowerPoint do formátu XPS uložením souboru PPT nebo PPTX do formátu XPS. Tento článek vysvětluje, kdy může být formát XPS užitečný, a ukazuje, jak provést konverzi pomocí Aspose.Slides buď s výchozími nastaveními, nebo s vlastním [XpsOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xpsoptions/) nastavením.

## **O XPS**
Microsoft vyvinul [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternativu k [PDF](https://docs.fileformat.com/pdf/). Umožňuje tisk obsahu výstupem souboru velmi podobného PDF. Formát XPS je založený na XML. Rozvržení nebo struktura souboru XPS zůstává stejná na všech operačních systémech a tiskárnách. 

## **Kdy použít formát Microsoft XPS**

{{% alert color="info" %}} 
Chcete-li vidět, jak Aspose.Slides převádí prezentaci PPT nebo PPTX do formátu XPS, můžete vyzkoušet [tuto bezplatnou online konverzní aplikaci](https://products.aspose.app/slides/cs/conversion). 
{{% /alert %}} 

Pokud chcete snížit náklady na úložiště, můžete svou prezentaci Microsoft PowerPoint převést do formátu XPS. Tím bude jednodušší ukládat, sdílet i tisknout vaše dokumenty. 

Microsoft nadále poskytuje silnou podporu pro XPS ve Windows (dokonce i ve Windows 10), takže můžete zvážit ukládání souborů do tohoto formátu. Pokud pracujete s Windows 8.1, Windows 8, Windows 7 a Windows Vista, může být XPS ve skutečnosti vaší nejlepší volbou pro některé operace. 

- **Windows 8** používá formát OXPS (Open XPS) pro soubory XPS. OXPS je standardizovaná verze původního formátu XPS. Windows 8 poskytuje lepší podporu souborů XPS než pro soubory PDF. 
  - **XPS:** Vestavěný prohlížeč/čtečka XPS a funkce tisku do XPS jsou k dispozici. 
  - **PDF:** K dispozici je čtečka PDF, ale funkce tisku do PDF chybí. 

- **Windows 7 a Windows Vista** používají původní formát XPS. Tyto operační systémy také poskytují lepší podporu pro soubory XPS než pro PDF. 
  - **XPS:** Vestavěná prohlížeč XPS a funkce tisku do XPS jsou k dispozici. 
  - **PDF:** Žádná čtečka PDF. Funkce tisku do PDF chybí. 

|<p>**Vstup PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Výstup XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft nakonec implementoval podporu pro tiskové operace v PDF prostřednictvím funkce Tisk do PDF ve Windows 10. Dříve uživatelé očekávali tisk dokumentů přes formát XPS. 

## **Konverze XPS pomocí Aspose.Slides**

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/java/) pro Java můžete použít metodu [**Save**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) vystavenou třídou [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) k převodu celé prezentace do dokumentu XPS. 

Při převodu prezentace do XPS musíte prezentaci uložit pomocí jedné z těchto možností:

- Výchozí nastavení (bez [**XPSOptions**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xpsoptions))
- Vlastní nastavení (s [**XPSOptions**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xpsoptions))

### **Převod prezentací do XPS pomocí výchozích nastavení**

Tento ukázkový kód v jazyce Java ukazuje, jak převést prezentaci do dokumentu XPS pomocí standardních nastavení:

```java
import com.aspose.slides.*;

// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Ukládá prezentaci do XPS dokumentu
    pres.save("XPS_Output_Without_XPSOption.xls", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Převod prezentací do XPS pomocí vlastních nastavení**
Tento ukázkový kód ukazuje, jak převést prezentaci do dokumentu XPS pomocí vlastních nastavení v jazyce Java:

```java
import com.aspose.slides.*;

// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Vytvořte instanci třídy XpsOptions
    XpsOptions options = new XpsOptions();

    // Uložit MetaFiles jako PNG
    options.setSaveMetafilesAsPng(true);

    // Uložit prezentaci do XPS dokumentu
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

### Můžu uložit XPS do proudu místo souboru?

Ano—Aspose.Slides vám umožňuje exportovat přímo do proudu, což je ideální pro webová API, server‑side pipeline nebo jakýkoli scénář, kde chcete XPS poslat bez zásahu do souborového systému.

### Přenášejí se skryté snímky do XPS a mohu je vyloučit?

Ve výchozím nastavení jsou renderovány pouze běžné (viditelné) snímky. Můžete [include or exclude hidden slides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) prostřednictvím [export settings](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xpsoptions/) před uložením do XPS, čímž zajistíte, že výstup bude obsahovat přesně ty stránky, které chcete.
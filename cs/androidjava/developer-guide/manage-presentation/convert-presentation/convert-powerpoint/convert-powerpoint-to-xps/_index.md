---
title: Převod prezentací PowerPoint do XPS na Androidu
linktitle: PowerPoint na XPS
type: docs
weight: 70
url: /cs/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "Převést PowerPoint PPT/PPTX na vysoce kvalitní, platformně nezávislý XPS v Javě pomocí Aspose.Slides pro Android. Získáte podrobný návod a ukázkový kód."
---
## **Přehled**

Aspose.Slides vám umožňuje převést prezentace PowerPoint do formátu XPS uložením souboru PPT nebo PPTX do formátu XPS. Tento článek vysvětluje, kdy může být formát XPS užitečný, a ukazuje, jak provést konverzi pomocí Aspose.Slides s výchozími nastaveními nebo vlastními [XpsOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xpsoptions/) nastaveními.

## **O XPS**

Microsoft vyvinul [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternativu k [PDF](https://docs.fileformat.com/pdf/). Umožňuje tisknout obsah výstupem souboru velmi podobného PDF. Formát XPS je založen na XML. Rozvržení nebo struktura souboru XPS zůstává stejná na všech operačních systémech a tiskárnách.

## **Kdy použít formát Microsoft XPS**

{{% alert color="info" %}} 

Chcete-li vidět, jak Aspose.Slides převádí prezentaci PPT nebo PPTX do formátu XPS, můžete vyzkoušet [tuto bezplatnou online konvertovací aplikaci](https://products.aspose.app/slides/cs/conversion). 

{{% /alert %}} 

Pokud chcete snížit náklady na úložiště, můžete svou prezentaci Microsoft PowerPoint převést do formátu XPS. Tím bude pro vás jednodušší ukládat, sdílet a tisknout dokumenty.

Microsoft nadále poskytuje silnou podporu pro XPS ve Windows (dokonce i ve Windows 10), takže může být rozumné ukládat soubory do tohoto formátu. Pokud pracujete s Windows 8.1, Windows 8, Windows 7 nebo Windows Vista, může být XPS ve skutečnosti pro některé operace nejlepší volbou.

- **Windows 8** používá formát OXPS (Open XPS) pro soubory XPS. OXPS je standardizovaná verze původního formátu XPS. Windows 8 poskytuje lepší podporu pro soubory XPS než pro soubory PDF. 
  - **XPS:** Vestavěný prohlížeč/čtečka XPS a možnost tisku do XPS jsou k dispozici. 
  - **PDF:** K dispozici je PDF čtečka, ale není funkce tisku do PDF. 

- **Windows 7 a Windows Vista** používají původní formát XPS. Tyto operační systémy také poskytují lepší podporu pro soubory XPS než pro PDF. 
  - **XPS:** Vestavěný prohlížeč XPS a možnost tisku do XPS jsou k dispozici. 
  - **PDF:** PDF čtečka není. Funkce tisku do PDF není. 

|<p>**Vstupní PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Výstupní XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft nakonec implementoval podporu pro tiskové operace v PDF prostřednictvím funkce Tisk do PDF ve Windows 10. Dříve uživatelé očekávali, že dokumenty budou tisknuty pomocí formátu XPS.

## **Konverze XPS s Aspose.Slides**

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/androidjava/) pro Java můžete použít metodu [**Save**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) vystavenou třídou [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) k převodu celé prezentace do dokumentu XPS.

Při převodu prezentace do XPS musíte prezentaci uložit pomocí jedné z následujících možností:

- Výchozí nastavení (bez [**XPSOptions**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xpsoptions))
- Vlastní nastavení (s [**XPSOptions**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xpsoptions))

### **Převod prezentací do XPS pomocí výchozích nastavení**

Tento ukázkový kód v Javě vám ukazuje, jak převést prezentaci do dokumentu XPS pomocí standardních nastavení:

```java
import com.aspose.slides.*;

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

Tento ukázkový kód vám ukazuje, jak převést prezentaci do dokumentu XPS pomocí vlastních nastavení v Javě:

```java
import com.aspose.slides.*;

// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Vytvořte instanci třídy XpsOptions
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

### Mohu uložit XPS do proudu místo do souboru?

Ano — Aspose.Slides umožňuje exportovat přímo do proudu, což je ideální pro webové API, server‑side pipeline nebo jakýkoli scénář, kde chcete XPS poslat, aniž byste se dotkli souborového systému.

### Přenesou se skryté snímky do XPS a lze je vyloučit?

Ve výchozím nastavení jsou renderovány pouze běžné (viditelné) snímky. Můžete [zahrnout nebo vyloučit skryté snímky](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) pomocí [nastavení exportu](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xpsoptions/) před uložením do XPS, čímž zajistíte, že výstup bude obsahovat přesně ty stránky, které potřebujete.
---
title: Převod prezentací PowerPoint do XPS v Pythonu
linktitle: PowerPoint do XPS
type: docs
weight: 70
url: /cs/python-net/convert-powerpoint-to-xps/
keywords:
- převést PowerPoint
- převést prezentaci
- PowerPoint do XPS
- prezentace do XPS
- PPT do XPS
- PPTX do XPS
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Převod PowerPoint PPT/PPTX do vysoce kvalitního, platformově nezávislého XPS v Pythonu pomocí Aspose.Slides. Získejte podrobný návod a ukázkový kód."
---
## **Přehled**

Aspose.Slides umožňuje převést prezentace PowerPoint do formátu XPS uložením souboru PPT nebo PPTX do formátu XPS. Tento článek vysvětluje, kdy může být formát XPS užitečný, a ukazuje, jak provést konverzi pomocí Aspose.Slides s výchozími nastaveními nebo s vlastními nastaveními [XpsOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/xpsoptions/) .

## **O XPS**

Microsoft vyvinul [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternativu k [PDF](https://docs.fileformat.com/pdf/). Umožňuje tisk obsahu vytvořením souboru velmi podobného PDF. Formát XPS je založen na XML. Rozložení nebo struktura souboru XPS zůstává stejná na všech operačních systémech a tiskárnách. 

## Kdy použít formát Microsoft XPS

{{% alert color="primary" %}} 

Chcete-li vidět, jak Aspose.Slides převádí prezentaci PPT nebo PPTX do formátu XPS, můžete si prohlédnout [tuto bezplatnou online konverzní aplikaci](https://products.aspose.app/slides/cs/conversion). 

{{% /alert %}} 

Pokud chcete snížit náklady na úložiště, můžete převést svou prezentaci Microsoft PowerPoint do formátu XPS. Tím bude pro vás snazší ukládat, sdílet a tisknout vaše dokumenty. 

Microsoft nadále poskytuje silnou podporu pro XPS ve Windows (dokonce i ve Windows 10), takže můžete zvážit ukládání souborů do tohoto formátu. Pokud pracujete s Windows 8.1, Windows 8, Windows 7 a Windows Vista, může být XPS ve skutečnosti vaší nejlepší volbou pro některé operace. 

- **Windows 8** používá formát OXPS (Open XPS) pro soubory XPS. OXPS je standardizovaná verze původního formátu XPS. Windows 8 poskytuje lepší podporu pro soubory XPS než pro soubory PDF. 
  - **XPS:** Vestavěný prohlížeč/čtečka XPS a funkce tisku do XPS jsou k dispozici. 
  - **PDF**: K dispozici je čtečka PDF, ale funkce tisku do PDF není. 

- **Windows 7 a Windows Vista** používají původní formát XPS. Tyto operační systémy také poskytují lepší podporu pro soubory XPS než pro PDF. 
  - **XPS**: Vestavěný prohlížeč XPS a funkce tisku do XPS jsou k dispozici. 
  - **PDF**: Žádná čtečka PDF. Funkce tisku do PDF není k dispozici. 

|<p>**Vstup PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Výstup XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft nakonec implementoval podporu tiskových operací v PDF prostřednictvím funkce Print to PDF ve Windows 10. Dříve bylo očekáváno, že uživatelé budou tisknout dokumenty pomocí formátu XPS. 

## Převod XPS pomocí Aspose.Slides

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/python-net/) pro .NET můžete použít metodu [**Save**](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) vystavenou třídou [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/), která převádí celou prezentaci do dokumentu XPS. 

Při převodu prezentace do XPS musíte prezentaci uložit pomocí jednoho z následujících nastavení:

- Výchozí nastavení (bez [**XPSOptions**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/xpsoptions/))
- Vlastní nastavení (s [**XPSOptions**](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/xpsoptions/))

### **Převod prezentací na XPS pomocí výchozích nastavení**

Tento ukázkový kód v Pythonu ukazuje, jak převést prezentaci do dokumentu XPS pomocí standardních nastavení:

```py
import aspose.slides as slides

# Vytvořte objekt Presentation, který představuje soubor prezentace
pres = slides.Presentation("Convert_XPS.pptx")

# Ukládání prezentace do dokumentu XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **Převod prezentací na XPS pomocí vlastních nastavení**

Tento ukázkový kód ukazuje, jak převést prezentaci do dokumentu XPS pomocí vlastních nastavení v Pythonu:

```py
import aspose.slides as slides

# Vytvořte objekt Presentation, který představuje soubor prezentace
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Instancujte třídu TiffOptions
options = slides.export.XpsOptions()

# Uložit MetaFiles jako PNG
options.save_metafiles_as_png = True

# Uložit prezentaci do XPS dokumentu
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **Často kladené otázky**

**Mohu uložit XPS do streamu místo souboru?**

Ano—Aspose.Slides vám umožňuje exportovat přímo do streamu, což je ideální pro webová API, server-side pipeline nebo jakýkoli scénář, kdy chcete XPS odeslat bez zásahu do souborového systému.

**Přenesou se skryté snímky do XPS a mohu je vyloučit?**

Ve výchozím nastavení jsou vykresleny pouze běžné (viditelné) snímky. Můžete [zahrnout nebo vyloučit skryté snímky](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) pomocí [nastavení exportu](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/xpsoptions/) před uložením do XPS, což zajistí, že výstup bude obsahovat přesně stránky, které chcete.
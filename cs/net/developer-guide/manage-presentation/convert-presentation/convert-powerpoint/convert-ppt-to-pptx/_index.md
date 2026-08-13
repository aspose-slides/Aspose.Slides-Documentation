---
title: Převod PPT na PPTX v .NET
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/net/convert-ppt-to-pptx/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- PPT na PPTX
- uložit PPT jako PPTX
- exportovat PPT do PPTX
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Rychle převádějte staré prezentace PPT na moderní PPTX v .NET pomocí Aspose.Slides — přehledný tutoriál, zdarma C# ukázky kódu, bez závislosti na Microsoft Office."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci PowerPoint ve formátu PPT na formát PPTX pomocí C# a online aplikace pro konverzi PPT na PPTX. Pokrývá následující téma.

- [Převést PPT na PPTX v C#](#convert-ppt-to-pptx)

## **Převést PPT na PPTX v .NET**

Pro ukázkový kód v C# pro převod PPT na PPTX viz sekce níže, tj. [Convert PPT to PPTX](#convert-ppt-to-pptx). Kód jen načte soubor PPT a uloží jej ve formátu PPTX. Výběrem různých formátů ukládání můžete také uložit soubor PPT do mnoha dalších formátů, jako je PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích.

- [Převést PPT na PDF v .NET](/slides/cs/net/convert-powerpoint-to-pdf/)
- [Převést PPT na XPS v .NET](/slides/cs/net/convert-powerpoint-to-xps/)
- [Převést PPT na HTML v .NET](/slides/cs/net/convert-powerpoint-to-html/)
- [Převést PPT na ODP v .NET](/slides/cs/net/save-presentation/)
- [Převést PPT na PNG v .NET](/slides/cs/net/convert-powerpoint-to-png/)

## **O převodu PPT na PPTX**
Převod starého formátu PPT na PPTX pomocí Aspose.Slides API. Pokud potřebujete převést tisíce prezentací PPT do formátu PPTX, nejlepší řešení je provést to programově. S Aspose.Slides API je to možné udělat v několika řádcích kódu. API podporuje úplnou kompatibilitu pro převod PPT prezentace na PPTX a umožňuje:

- Převést složité struktury hlav, rozvržení a snímků.
- Převést prezentaci s grafy.
- Převést prezentaci s skupinovými tvary, automatickými tvary (jako jsou obdélníky a elipsy), tvary s vlastní geometrií.
- Převést prezentaci, která obsahuje textury a obrázky jako výplňové styly pro automatické tvary.
- Převést prezentaci s zástupci, textovými rámečky a textovými nosiči.

{{% alert color="info" %}} 

Podívejte se na [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) aplikaci:

[](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

Tato aplikace je postavena na **Aspose.Slides API**, takže můžete vidět živý příklad základních možností převodu PPT na PPTX. Aspose.Slides Conversion je webová aplikace, která umožňuje přetáhnout soubor prezentace ve formátu PPT a stáhnout jej po převodu do PPTX.

Najděte další živé [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/) příklady.
{{% /alert %}} 

## **Převést PPT na PPTX**
Pro převod PPT na PPTX stačí předat název souboru a formát ukládání metodě [**Save**](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/methods/save/index) třídy [**Presentation**](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation). Níže uvedený ukázkový kód v C# převádí prezentaci z PPT na PPTX pomocí výchozích možností.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciujte objekt Presentation, který představuje soubor PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Ukládání prezentace PPTX do formátu PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

Přečtěte si více o formátech prezentací [**PPT vs PPTX**](/slides/cs/net/ppt-vs-pptx/) a o tom, jak [**Aspose.Slides podporuje převod PPT na PPTX**](/slides/cs/net/convert-ppt-to-pptx/).

## **Často kladené otázky**

### Jaký je rozdíl mezi formáty PPT a PPTX?

PPT je starší binární formát souboru používaný Microsoft PowerPoint, zatímco PPTX je novější formát založený na XML, zavedený s Microsoft Office 2007. Soubory PPTX nabízejí lepší výkon, menší velikost souboru a vylepšené obnovení dat.

### Může .NET převést PPT na PPTX?

Ano, pomocí knihovny Aspose.Slides pro .NET můžete snadno načíst soubor PPT a uložit jej ve formátu PPTX pomocí několika řádků kódu.

### Podporuje Aspose.Slides hromadný převod více souborů PPT na PPTX?

Ano, můžete použít Aspose.Slides v ciklusu k programovému převodu více souborů PPT na PPTX, což je vhodné pro scénáře hromadného převodu.

### Zůstane po převodu zachován obsah a formátování?

Aspose.Slides udržuje vysokou věrnost při převodu prezentací. Rozvržení snímků, animace, tvary, grafy a další designové prvky jsou během převodu PPT na PPTX zachovány.

### Mohu převést jiné formáty, jako PDF nebo HTML, ze souborů PPT?

Ano, Aspose.Slides podporuje převod souborů PPT do několika formátů, včetně PDF, XPS, HTML, ODP a obrázkových formátů jako PNG a JPEG.

### Je možné převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?

Ano, Aspose.Slides pro .NET je samostatné API a nevyžaduje Microsoft PowerPoint ani žádný třetí software k provedení převodu.

### Existuje online nástroj pro převod PPT na PPTX?

Ano, můžete použít bezplatnou webovou aplikaci [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) k provedení převodu přímo ve vašem prohlížeči bez psaní kódu.
---
title: Převod PPT na PPTX v .NET
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/net/convert-ppt-to-pptx/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- PPT na PPTX
- uložit PPT jako PPTX
- exportovat PPT do PPTX
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Rychle převést staré PPT prezentace na moderní PPTX v .NET pomocí Aspose.Slides — přehledný tutoriál, zdarma ukázky kódu v C#, bez závislosti na Microsoft Office."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci PowerPoint ve formátu PPT na formát PPTX pomocí C# a online aplikace pro převod PPT na PPTX. Pokrývá následující téma.

- [Convert PPT to PPTX in C#](#convert-ppt-to-pptx)

## **Convert PPT to PPTX v .NET**

Pro ukázkový kód v C# převádějící PPT na PPTX viz část níže tj. [Convert PPT to PPTX](#convert-ppt-to-pptx). Stačí načíst soubor PPT a uložit jej ve formátu PPTX. Specifikací různých formátů uložení můžete PPT soubor uložit i do mnoha dalších formátů, jako PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích.

- [Convert PPT to PDF in .NET](/slides/cs/net/convert-powerpoint-to-pdf/)
- [Convert PPT to XPS in .NET](/slides/cs/net/convert-powerpoint-to-xps/)
- [Convert PPT to HTML in .NET](/slides/cs/net/convert-powerpoint-to-html/)
- [Convert PPT to ODP in .NET](/slides/cs/net/save-presentation/)
- [Convert PPT to PNG in .NET](/slides/cs/net/convert-powerpoint-to-png/)

## **O převodu PPT na PPTX**
Převod starého formátu PPT na PPTX pomocí Aspose.Slides API. Pokud potřebujete převést tisíce prezentací PPT na formát PPTX, nejlepší řešení je provést to programově. S Aspose.Slides API je to možné udělat jen v několika řádcích kódu. API podporuje úplnou kompatibilitu při převodu PPT prezentací na PPTX a umožňuje:

- Převod složitých struktur masterů, rozvržení a snímků.
- Převod prezentací s grafy.
- Převod prezentací se skupinovými tvary, automatickými tvary (jako obdélníky a elipsy), tvary se speciální geometrií.
- Převod prezentací s texturami a obrázky vyplňujícími automatické tvary.
- Převod prezentací s místními držáky, textovými rámečky a textovými držáky.

{{% alert color="primary" %}} 

Podívejte se na **Aspose.Slides PPT to PPTX Conversion** aplikaci:

[](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

Tato aplikace je postavena na **Aspose.Slides API**, takže můžete vidět živý příklad základních možností převodu PPT na PPTX. Aspose.Slides Conversion je webová aplikace, která umožňuje přetáhnout soubor prezentace ve formátu PPT a stáhnout jej převedený na PPTX.

Najděte další živé **Aspose.Slides Conversion** příklady.
{{% /alert %}} 


## **Convert PPT to PPTX**
Pro převod PPT na PPTX stačí předat název souboru a formát uložení metodě **Save** třídy **Presentation**. Níže uvedený C# kód převádí prezentaci z PPT na PPTX pomocí výchozích možností.

```c#
// Vytvořte objekt Presentation, který představuje soubor PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Ukládání prezentace PPTX do formátu PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

Přečtěte si více o formátech prezentací **PPT vs PPTX**(/slides/cs/net/ppt-vs-pptx/) a o tom, jak **Aspose.Slides podporuje převod PPT na PPTX**(/slides/cs/net/convert-ppt-to-pptx/).

## **FAQ**

**Jaký je rozdíl mezi formáty PPT a PPTX?**

PPT je starší binární formát souboru používaný Microsoft PowerPoint, zatímco PPTX je novější formát založený na XML, zavedený s Microsoft Office 2007. Soubory PPTX nabízejí lepší výkon, menší velikost souboru a vylepšené obnovení dat.

**Mohu převést PPT na PPTX pomocí .NET?**

Ano, pomocí knihovny Aspose.Slides pro .NET můžete snadno načíst soubor PPT a uložit jej ve formátu PPTX během několika řádků kódu.

**Podporuje Aspose.Slides hromadný převod více souborů PPT na PPTX?**

Ano, můžete použít Aspose.Slides ve smyčce k programovému převodu více souborů PPT na PPTX, což je vhodné pro scénáře hromadného převodu.

**Zůstane po převodu zachován obsah a formátování?**

Aspose.Slides zachovává vysokou věrnost při převodu prezentací. Rozvržení snímků, animace, tvary, grafy a další návrhové prvky jsou během převodu PPT na PPTX zachovány.

**Mohu převést jiné formáty, jako PDF nebo HTML, ze souborů PPT?**

Ano, Aspose.Slides podporuje převod souborů PPT do více formátů, včetně PDF, XPS, HTML, ODP a obrazových formátů jako PNG a JPEG.

**Je možné převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano, Aspose.Slides pro .NET je samostatné API a nevyžaduje Microsoft PowerPoint ani žádný software třetích stran pro provedení převodu.

**Existuje online nástroj pro převod PPT na PPTX?**

Ano, můžete použít bezplatnou webovou aplikaci **Aspose.Slides PPT to PPTX Converter**(https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) k provedení převodu přímo ve vašem prohlížeči bez psaní kódu.
---
title: Převod PPT na PPTX v Pythonu
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/python-net/convert-ppt-to-pptx/
keywords:
- převod PPT
- PPT na PPTX
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Převádějte staré prezentace PPT na moderní PPTX rychle v Pythonu s Aspose.Slides — přehledný tutoriál, bezplatné ukázky kódu, bez závislosti na Microsoft Office."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Pythonu a online aplikace pro konverzi PPT na PPTX převést prezentaci PowerPoint ve formátu PPT do formátu PPTX. Následující téma je pokryto:

- Převod PPT na PPTX v Pythonu

## **Python převod PPT na PPTX**

Pro ukázkový kód v Pythonu pro převod PPT na PPTX viz níže uvedená sekce, tj. [Convert PPT to PPTX](#convert-ppt-to-pptx). Jednoduše načte soubor PPT a uloží jej ve formátu PPTX. Zadáním různých formátů ukládání můžete také uložit soubor PPT do mnoha dalších formátů, jako jsou PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích:

- [Převod PPT na PDF v Pythonu](/slides/cs/python-net/convert-powerpoint-to-pdf/)
- [Převod PPT na XPS v Pythonu](/slides/cs/python-net/convert-powerpoint-to-xps/)
- [Převod PPT na HTML v Pythonu](/slides/cs/python-net/convert-powerpoint-to-html/)
- [Převod PPT na ODP v Pythonu](/slides/cs/python-net/save-presentation/)
- [Převod PPT na PNG v Pythonu](/slides/cs/python-net/convert-powerpoint-to-png/)

## **O převodu PPT na PPTX**

Convert the old PPT format to PPTX with Aspose.Slides API. If you need to convert thousands of PPT presentations to PPTX format, the best solution is to do it programmatically. With Aspose.Slides API, it is possible to do it in just a few lines of code. The API supports full compatibility to convert a PPT presentation to PPTX, and it is possible to:

- Převést složité struktury mistrů, rozložení a snímků.
- Převést prezentaci s grafy.
- Převést prezentaci se skupinovými tvary, automatickými tvary (jako obdélníky a elipsy) a tvary s vlastní geometrií.
- Převést prezentaci obsahující textury a styly výplně obrázků pro automatické tvary.
- Převést prezentaci s místotry, textovými rámy a textovými držáky.

{{% alert color="primary" %}}

Podívejte se na aplikaci [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

Tato aplikace je postavena na **Aspose.Slides API**, takže si můžete prohlédnout živý příklad základních možností převodu PPT na PPTX. Aspose.Slides Conversion je webová aplikace, která vám umožní nahrát soubor prezentace ve formátu PPT a stáhnout jej převedený do PPTX.

Najděte další živé [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/) příklady.
{{% /alert %}}

## **Převod PPT na PPTX**

Pro převod PPT na PPTX jednoduše předáte název souboru a formát ukládání do metody [**Save**](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) třídy [**Presentation**](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Níže uvedený ukázkový kód v Pythonu převádí prezentaci z PPT na PPTX s výchozími možnostmi.

```python
import aspose.slides as slides

# Vytvořte objekt Presentation, který představuje soubor PPT
pres = slides.Presentation("PPTtoPPTX.ppt")

# Uložte prezentaci ve formátu PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

Více informací o formátech prezentací [**PPT vs PPTX**](/slides/cs/python-net/ppt-vs-pptx/) a o tom, jak [**Aspose.Slides supports PPT to PPTX conversion**](/slides/cs/python-net/convert-ppt-to-pptx/).

## **Často kladené otázky**

**Jaký je rozdíl mezi formáty PPT a PPTX?**

PPT je starší binární formát souboru používaný Microsoft PowerPoint, zatímco PPTX je novější formát založený na XML, který byl představen v Microsoft Office 2007. Soubory PPTX nabízejí lepší výkon, menší velikost souboru a vylepšené obnovení dat.

**Mohu převést PPT na PPTX pomocí Pythonu?**

Ano, pomocí knihovny Aspose.Slides for Python via .NET můžete snadno načíst soubor PPT a uložit jej ve formátu PPTX pomocí pouhých několika řádků kódu.

**Podporuje Aspose.Slides hromadný převod více souborů PPT na PPTX?**

Ano, můžete použít Aspose.Slides v cyklu k programatickému převodu více souborů PPT na PPTX, což je vhodné pro scénáře hromadného převodu.

**Zachová se obsah a formátování po převodu?**

Aspose.Slides udržuje vysokou věrnost při převodu prezentací. Rozvržení snímků, animace, tvary, grafy a další designové prvky jsou během převodu PPT na PPTX zachovány.

**Mohu převádět jiné formáty jako PDF nebo HTML ze souborů PPT?**

Ano, Aspose.Slides podporuje převod souborů PPT do mnoha formátů, včetně PDF, XPS, HTML, ODP a obrazových formátů jako PNG a JPEG.

**Je možné převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano, Aspose.Slides for Python via .NET je samostatné API a nevyžaduje Microsoft PowerPoint ani žádný software třetích stran k provedení převodu.

**Existuje online nástroj pro převod PPT na PPTX?**

Ano, můžete použít bezplatnou [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) webovou aplikaci k provedení převodu přímo ve vašem prohlížeči bez psaní jakéhokoli kódu.
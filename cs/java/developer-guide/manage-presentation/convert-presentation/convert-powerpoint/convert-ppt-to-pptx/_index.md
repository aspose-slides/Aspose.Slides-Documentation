---
title: Převod PPT na PPTX v Javě
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Rychle převádějte starší PPT prezentace na moderní PPTX v Javě pomocí Aspose.Slides — přehledný tutoriál, bezplatné ukázky kódu, bez závislosti na Microsoft Office."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci PowerPoint ve formátu PPT do formátu PPTX pomocí Javy a online aplikace pro konverzi PPT na PPTX. Následující téma je pokryto.

- Převod PPT na PPTX v Javě

## **Převod PPT na PPTX v Javě**

Pro ukázkový kód v Javě pro převod PPT na PPTX si prosím prohlédněte sekci níže, tj. [Převod PPT na PPTX](#convert-ppt-to-pptx). Stačí načíst soubor PPT a uložit jej ve formátu PPTX. Zadáním různých formátů uložení můžete také uložit soubor PPT do mnoha dalších formátů, jako jsou PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích.

- [Převod PPT na PDF v Javě](/slides/cs/java/convert-powerpoint-to-pdf/)
- [Převod PPT na XPS v Javě](/slides/cs/java/convert-powerpoint-to-xps/)
- [Převod PPT na HTML v Javě](/slides/cs/java/convert-powerpoint-to-html/)
- [Převod PPT na ODP v Javě](/slides/cs/java/save-presentation/)
- [Převod PPT na PNG v Javě](/slides/cs/java/convert-powerpoint-to-png/)

## **O konverzi PPT na PPTX**

Převod starého formátu PPT na PPTX pomocí Aspose.Slides API. Pokud potřebujete převést tisíce prezentací PPT do formátu PPTX, nejlepší řešení je provést to programově. S Aspose.Slides API je to možné udělat během několika řádků kódu. API poskytuje plnou kompatibilitu pro konverzi prezentace PPT na PPTX a je možné:

- Převést složité struktury mistrů, rozložení a snímků.
- Převést prezentaci s grafy.
- Převést prezentaci se skupinovými tvary, automatickými tvary (jako jsou obdélníky a elipsy), tvary se vlastní geometrií.
- Převést prezentaci s texturami a styly výplně obrázky pro automatické tvary.
- Převést prezentaci s místodržíči, textovými rámečky a textovými držáky.

{{% alert color="primary" %}} 

Podívejte se na [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) aplikaci:

[](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

Tato aplikace je postavena na [**Aspose.Slides API**](https://products.aspose.com/slides/cs/java/), takže můžete vidět živý příklad základních schopností konverze PPT na PPTX. Aspose.Slides Conversion je webová aplikace, která umožňuje přetáhnout soubor prezentace ve formátu PPT a stáhnout jej převedený do PPTX.

Najděte další živé příklady [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/).

{{% /alert %}} 

## **Převod PPT na PPTX**

Aspose.Slides for Java now facilitates the developers to access the PPT using [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) class instance and converting that to respective [PPTX](https://docs.fileformat.com/presentation/pptx/) format. Presently, it supports partial conversion of [PPT ](https://docs.fileformat.com/presentation/ppt/)to PPTX. For more details about what features are supported and unsupported in PPT to PPTX conversion, please proceed to this documentation [odkaz](/slides/cs/java/ppt-to-pptx-conversion/).

Aspose.Slides for Java offers [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) class that represents a **PPTX** presentation file. Presentation class can now also access **PPT** through Presentation when the object is instantiated. The following example shows how to convert a PPT presentation into PPTX Presentation.

```java
// Vytvořte objekt Presentation, který představuje soubor PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
    // Uložení PPTX prezentace do formátu PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Obrázek: Zdrojová PPT prezentace**|

The above code snippet generated the following PPTX presentation after conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Obrázek: Vygenerovaná PPTX prezentace po konverzi**|

## **Často kladené otázky**

**Jaký je rozdíl mezi formáty PPT a PPTX?**

PPT je starší binární formát souboru používaný Microsoft PowerPoint, zatímco PPTX je novější formát založený na XML, zavedený s Microsoft Office 2007. Soubory PPTX nabízejí lepší výkon, menší velikost souboru a vylepšené obnovení dat.

**Podporuje Aspose.Slides dávkovou konverzi více souborů PPT na PPTX?**

Ano, můžete použít Aspose.Slides ve smyčce k programovému převodu více souborů PPT na PPTX, což je vhodné pro scénáře hromadné konverze.

**Bude obsah a formátování po konverzi zachováno?**

Aspose.Slides zachovává vysokou přesnost při konverzi prezentací. Rozložení snímků, animace, tvary, grafy a další designové prvky jsou během konverze PPT na PPTX zachovány.

**Mohu převést jiné formáty, jako PDF nebo HTML, ze souborů PPT?**

Ano, Aspose.Slides podporuje převod souborů PPT do [více formátů](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/), včetně PDF, XPS, HTML, ODP a formátů obrázků, jako jsou PNG a JPEG.

**Je možné převést PPT na PPTX bez nainstalovaného Microsoft PowerPointu?**

Ano, Aspose.Slides je samostatné API a nevyžaduje Microsoft PowerPoint ani žádný software třetí strany k provedení konverze.

**Existuje online nástroj pro konverzi PPT na PPTX?**

Ano, můžete použít bezplatnou webovou aplikaci [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) k provedení konverze přímo ve vašem prohlížeči bez psaní kódu.
---
title: Převod PPT na PPTX na Androidu
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Rychle převádějte staré PPT prezentace na moderní PPTX v Javě s Aspose.Slides pro Android — přehledný tutoriál, zdarma ukázky kódu, bez závislosti na Microsoft Office."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci PowerPoint ve formátu PPT do formátu PPTX pomocí Javy a online aplikace pro konverzi PPT na PPTX. Následující téma je pokryto.

- Převod PPT na PPTX v Javě

## **Převod PPT na PPTX na Androidu**

Pro ukázkový kód v Javě pro převod PPT na PPTX viz níže uvedená sekce, tj. [Convert PPT to PPTX](#convert-ppt-to-pptx). Kód jen načte soubor PPT a uloží jej ve formátu PPTX. Specifikací různých formátů ukládání můžete také uložit soubor PPT do mnoha dalších formátů, jako jsou PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích.

- [Převod PPT na PDF na Androidu](/slides/cs/androidjava/convert-powerpoint-to-pdf/)
- [Převod PPT na XPS na Androidu](/slides/cs/androidjava/convert-powerpoint-to-xps/)
- [Převod PPT na HTML na Androidu](/slides/cs/androidjava/convert-powerpoint-to-html/)
- [Převod PPT na ODP na Androidu](/slides/cs/androidjava/save-presentation/)
- [Převod PPT na PNG na Androidu](/slides/cs/androidjava/convert-powerpoint-to-png/)

## **O konverzi PPT na PPTX**

Převod starého formátu PPT na PPTX pomocí Aspose.Slides API. Pokud potřebujete převést tisíce prezentací PPT do formátu PPTX, nejlepším řešením je provést to programově. S Aspose.Slides API je to možné provést během několika řádků kódu. API podporuje plnou kompatibilitu pro převod prezentace PPT na PPTX a je možné:

- Převést složité struktury hlav, rozvržení a snímků.
- Převést prezentaci s grafy.
- Převést prezentaci se skupinovými tvary, automatickými tvary (jako jsou obdélníky a elipsy), tvary s vlastní geometrií.
- Převést prezentaci obsahující textury a styly výplní obrázků pro automatické tvary.
- Převést prezentaci s místodržiteli, textovými rámy a textovými bloky.

{{% alert color="info" %}} 

Podívejte se na aplikaci [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

Tato aplikace je postavena na základě [**Aspose.Slides API**](https://products.aspose.com/slides/cs/androidjava/), takže můžete vidět živý příklad základních možností převodu PPT na PPTX. Aspose.Slides Conversion je webová aplikace, která umožňuje přetáhnout soubor prezentace ve formátu PPT a stáhnout jej převedený do PPTX.

Najděte další živé příklady [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/).

{{% /alert %}} 

## **Převod PPT na PPTX**

Aspose.Slides pro Android přes Java nyní usnadňuje vývojářům přístup k PPT pomocí instance třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a převod do příslušného formátu [PPTX](https://docs.fileformat.com/presentation/pptx/). V současné době podporuje částečný převod [PPT ](https://docs.fileformat.com/presentation/ppt/)to PPTX.

Aspose.Slides pro Android přes Java nabízí třídu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation), která představuje soubor prezentace **PPTX**. Třída Presentation nyní může také přistupovat k **PPT** prostřednictvím Presentation při vytvoření objektu. Následující příklad ukazuje, jak převést PPT prezentaci na PPTX prezentaci.

```java
import com.aspose.slides.*;

// Vytvořte objekt Presentation, který představuje soubor PPT
Presentation pres = new Presentation("Aspose.ppt");
try {
// Uložení PPT prezentace do formátu PPTX
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
|**Obrázek: Vygenerovaná PPTX prezentace po převodu**|

## **Často kladené otázky**

### Jaký je rozdíl mezi formáty PPT a PPTX?

PPT je starší binární formát souboru používaný Microsoft PowerPoint, zatímco PPTX je novější formát založený na XML, zavedený s Microsoft Office 2007. Soubory PPTX nabízejí lepší výkon, menší velikost souboru a vylepšené obnovení dat.

### Podporuje Aspose.Slides hromadný převod více souborů PPT na PPTX?

Ano, můžete použít Aspose.Slides v cyklu k programovému převodu více souborů PPT na PPTX, což je vhodné pro scénáře hromadné konverze.

### Zůstanou po převodu zachovány obsah a formátování?

Aspose.Slides zachovává vysokou věrnost při převodu prezentací. Rozvržení snímků, animace, tvary, grafy a další prvky návrhu jsou během převodu PPT na PPTX zachovány.

### Mohu převádět jiné formáty, jako PDF nebo HTML, ze souborů PPT?

Ano, Aspose.Slides podporuje převod souborů PPT do [více formátů](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/), včetně PDF, XPS, HTML, ODP a obrazových formátů jako PNG a JPEG.

### Je možné převést PPT na PPTX bez nainstalovaného Microsoft PowerPointu?

Ano, Aspose.Slides je samostatné API a nevyžaduje Microsoft PowerPoint ani žádný software třetí strany k provedení konverze.

### Existuje online nástroj pro převod PPT na PPTX?

Ano, můžete použít bezplatnou webovou aplikaci [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx), která umožňuje provést konverzi přímo ve vašem prohlížeči bez psaní kódu.
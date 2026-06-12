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
description: "Rychle převádějte starší PPT prezentace na moderní PPTX v Javě s Aspose.Slides pro Android — jasný tutoriál, bezplatné ukázky kódu, bez závislosti na Microsoft Office."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci PowerPoint ve formátu PPT do formátu PPTX pomocí Javy a online aplikace pro konverzi PPT na PPTX. Jsou pokryta následující témata.

- Převod PPT na PPTX v Javě

## **Převod PPT na PPTX na Androidu**

Pro ukázkový kód v Javě pro převod PPT na PPTX viz sekce níže, tj. [Convert PPT to PPTX](#convert-ppt-to-pptx). Kód pouze načte soubor PPT a uloží jej ve formátu PPTX. Zadáním různých formátů uložení můžete také uložit soubor PPT do mnoha dalších formátů, jako jsou PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích.

- [Convert PPT to PDF on Android](/slides/cs/androidjava/convert-powerpoint-to-pdf/)
- [Convert PPT to XPS on Android](/slides/cs/androidjava/convert-powerpoint-to-xps/)
- [Convert PPT to HTML on Android](/slides/cs/androidjava/convert-powerpoint-to-html/)
- [Convert PPT to ODP on Android](/slides/cs/androidjava/save-presentation/)
- [Convert PPT to PNG on Android](/slides/cs/androidjava/convert-powerpoint-to-png/)

## **O konverzi PPT na PPTX**
Převod starého formátu PPT na PPTX pomocí Aspose.Slides API. Pokud potřebujete převést tisíce prezentací PPT do formátu PPTX, nejlepší řešení je provést to programově. S Aspose.Slides API je to možné udělat během několika řádků kódu. API poskytuje plnou kompatibilitu pro převod prezentace PPT na PPTX a umožňuje:

- Převést složité struktury mistrů, rozvržení a snímků.
- Převést prezentaci s grafy.
- Převést prezentaci se skupinovými tvary, auto-tvary (jako obdélníky a elipsy), tvary s vlastní geometrií.
- Převést prezentaci s texturami a obrázkovými výplňovými styly pro auto-tvary.
- Převést prezentaci s zástupnými symboly, textovými rámy a textovými držáky.

{{% alert color="primary" %}} 

Podívejte se na [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) aplikaci:

[](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

Tato aplikace je postavena na [**Aspose.Slides API**](https://products.aspose.com/slides/cs/androidjava/), takže můžete vidět živý příklad základních schopností konverze PPT na PPTX. Aspose.Slides Conversion je webová aplikace, která umožňuje přetáhnout soubor prezentace ve formátu PPT a stáhnout jej po konverzi do PPTX.

Najděte další živé příklady [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/) .

{{% /alert %}} 

## **Převod PPT na PPTX**
Aspose.Slides pro Android přes Javu nyní usnadňuje vývojářům přístup k PPT pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) a její převod do příslušného formátu [PPTX](https://docs.fileformat.com/presentation/pptx/). V současné době podporuje částečný převod z [PPT](https://docs.fileformat.com/presentation/ppt/) na PPTX.

Aspose.Slides pro Android přes Javu nabízí třídu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation), která představuje soubor prezentace **PPTX**. Třída Presentation nyní může také přistupovat k **PPT** přes Presentation při vytvoření instance objektu. Následující příklad ukazuje, jak převést prezentaci PPT na prezentaci PPTX.

```java
// Vytvořte objekt Presentation, který představuje soubor PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// Ukládání PPTX prezentace do formátu PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Obrázek: Zdrojová PPT prezentace**|

Výše uvedený útržek kódu vygeneroval po konverzi následující prezentaci PPTX

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Obrázek: Vygenerovaná PPTX prezentace po konverzi**|

## **Často kladené otázky**

**Jaký je rozdíl mezi formáty PPT a PPTX?**

PPT je starší binární formát souboru používaný Microsoft PowerPoint, zatímco PPTX je novější formát založený na XML, který byl představen s Microsoft Office 2007. Soubory PPTX nabízejí lepší výkon, menší velikost souboru a vylepšené obnovení dat.

**Podporuje Aspose.Slides hromadný převod více souborů PPT na PPTX?**

Ano, můžete použít Aspose.Slides ve smyčce k programovému převodu více souborů PPT na PPTX, což je vhodné pro scénáře hromadné konverze.

**Zůstanou po převodu zachovány obsah a formátování?**

Aspose.Slides zachovává vysokou věrnost při převodu prezentací. Rozvržení snímků, animace, tvary, grafy a další designové prvky jsou během převodu PPT na PPTX zachovány.

**Mohu převést další formáty, jako PDF nebo HTML, z PPT souborů?**

Ano, Aspose.Slides podporuje převod souborů PPT do [více formátů](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/), včetně PDF, XPS, HTML, ODP a formátů obrázků jako PNG a JPEG.

**Je možné převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano, Aspose.Slides je samostatné API a nevyžaduje Microsoft PowerPoint ani žádný software třetí strany k provedení konverze.

**Existuje online nástroj pro převod PPT na PPTX?**

Ano, můžete použít bezplatnou webovou aplikaci [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) k provedení převodu přímo ve vašem prohlížeči bez psaní kódu.
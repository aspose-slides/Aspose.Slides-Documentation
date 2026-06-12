---
title: Převod PPT na PPTX v JavaScriptu
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Převést staré PPT prezentace na moderní PPTX rychle s Aspose.Slides pro Node.js — jasný tutoriál, bezplatné ukázky kódu, bez závislosti na Microsoft Office."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci PowerPoint ve formátu PPT do formátu PPTX pomocí JavaScriptu a online aplikace pro konverzi PPT na PPTX. Následující téma je pokryto.

- Převést PPT na PPTX v JavaScriptu

## **JavaScript převod PPT na PPTX**

Pro ukázkový kód JavaScriptu pro převod PPT na PPTX se podívejte na sekci níže, tj. [Převést PPT na PPTX](#convert-ppt-to-pptx). Kód pouze načte soubor PPT a uloží jej ve formátu PPTX. Specifikací různých formátů uložení můžete také uložit soubor PPT do mnoha dalších formátů, jako jsou PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích.

- [Převést PPT na PDF v JavaScriptu](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/)
- [Převést PPT na XPS v JavaScriptu](/slides/cs/nodejs-java/convert-powerpoint-to-xps/)
- [Převést PPT na HTML v JavaScriptu](/slides/cs/nodejs-java/convert-powerpoint-to-html/)
- [Převést PPT na ODP v JavaScriptu](/slides/cs/nodejs-java/save-presentation/)
- [Převést PPT na PNG v JavaScriptu](/slides/cs/nodejs-java/convert-powerpoint-to-png/)

## **O konverzi PPT na PPTX**

Zkonvertujte starý formát PPT na PPTX pomocí Aspose.Slides API. Pokud potřebujete převést tisíce PPT prezentací do formátu PPTX, nejlepší řešení je provést to programově. S Aspose.Slides API je to možné udělat během několika řádků kódu. API podporuje plnou kompatibilitu pro převod PPT prezentace na PPTX a je možné:

- Převést složité struktury hlav, rozložení a snímků.
- Převést prezentaci s grafy.
- Převést prezentaci se skupinovými tvary, automatickými tvary (jako jsou obdélníky a elipsy), tvary s vlastní geometrií.
- Převést prezentaci, která obsahuje textury a styly výplně obrázků pro automatické tvary.
- Převést prezentaci s placeholdery, textovými rámečky a textovými držáky.

{{% alert color="primary" %}} 

Podívejte se na [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) aplikaci:

[](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

Tato aplikace je postavena na [**Aspose.Slides API**](https://products.aspose.com/slides/cs/nodejs-java/), takže můžete vidět živý příklad základních možností konverze PPT na PPTX. Aspose.Slides Conversion je webová aplikace, která umožňuje přetáhnout soubor prezentace ve formátu PPT a stáhnout jej po konverzi do PPTX.

Najděte další živé příklady [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/).

{{% /alert %}} 

## **Převést PPT na PPTX**
Aspose.Slides pro Node.js prostřednictvím Javy nyní usnadňuje vývojářům přístup k PPT pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) a převod do příslušného formátu [PPTX](https://docs.fileformat.com/presentation/pptx/). V současné době podporuje částečný převod [PPT ](https://docs.fileformat.com/presentation/ppt/)na PPTX.

Aspose.Slides pro Node.js prostřednictvím Javy nabízí třídu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation), která představuje soubor prezentace **PPTX**. Třída Presentation nyní také umožňuje přístup k **PPT** prostřednictvím Presentation, když je objekt vytvořen. Následující příklad ukazuje, jak převést PPT prezentaci na PPTX prezentaci.

```javascript
// Vytvořte objekt Presentation, který představuje soubor PPTX
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // Ukládá PPTX prezentaci do formátu PPTX
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Obrázek : Zdrojová PPT prezentace**|

Výše uvedený úryvek kódu vygeneroval následující PPTX prezentaci po konverzi

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Obrázek: Vygenerovaná PPTX prezentace po konverzi**|

## **Často kladené otázky**

**Jaký je rozdíl mezi formáty PPT a PPTX?**

PPT je starší binární formát souboru používaný Microsoft PowerPoint, zatímco PPTX je novější formát založený na XML, zavedený s Microsoft Office 2007. Soubory PPTX nabízejí lepší výkon, menší velikost souboru a vylepšené obnovení dat.

**Podporuje Aspose.Slides dávkovou konverzi více souborů PPT do PPTX?**

Ano, můžete použít Aspose.Slides v cyklu k programové konverzi více souborů PPT do PPTX, což je vhodné pro scénáře dávkové konverze.

**Zůstane po konverzi zachována obsah a formátování?**

Aspose.Slides zachovává vysokou věrnost při konverzi prezentací. Rozvržení snímků, animace, tvary, grafy a další designové prvky jsou během konverze PPT na PPTX zachovány.

**Mohu převést další formáty, jako PDF nebo HTML, z PPT souborů?**

Ano, Aspose.Slides podporuje konverzi PPT souborů do více formátů, včetně PDF, XPS, HTML, ODP a formátů obrázků jako PNG a JPEG.

**Je možné převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano, Aspose.Slides je samostatné API a nevyžaduje Microsoft PowerPoint ani žádný software třetí strany pro provedení konverze.

**Existuje online nástroj pro konverzi PPT na PPTX?**

Ano, můžete použít zdarma webovou aplikaci [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) k provedení konverze přímo ve vašem prohlížeči bez psaní kódu.
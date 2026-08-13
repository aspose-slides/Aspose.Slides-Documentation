---
title: Převést PPT na PPTX v Javě
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Převést starší prezentace PPT na moderní PPTX rychle v Javě pomocí Aspose.Slides – přehledný tutoriál, zdarma ukázkové kódy, bez závislosti na Microsoft Office."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci PowerPoint ve formátu PPT na formát PPTX pomocí Javy a online aplikace pro konverzi PPT na PPTX. Následující téma je pokryto.

- Převést PPT na PPTX v Javě

## **Převést PPT na PPTX v Javě**

Pro ukázkový kód v Javě pro převod PPT na PPTX viz část níže, tj. [Convert PPT to PPTX](#convert-ppt-to-pptx). Kód pouze načte soubor PPT a uloží jej ve formátu PPTX. Zadáním různých formátů uložení můžete také soubor PPT uložit do mnoha dalších formátů, jako je PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích.

- [Převést PPT na PDF v Javě](/slides/cs/java/convert-powerpoint-to-pdf/)
- [Převést PPT na XPS v Javě](/slides/cs/java/convert-powerpoint-to-xps/)
- [Převést PPT na HTML v Javě](/slides/cs/java/convert-powerpoint-to-html/)
- [Převést PPT na ODP v Javě](/slides/cs/java/save-presentation/)
- [Převést PPT na PNG v Javě](/slides/cs/java/convert-powerpoint-to-png/)

## **O konverzi PPT na PPTX**

Převést starý formát PPT na PPTX pomocí Aspose.Slides API. Pokud potřebujete převést tisíce prezentací PPT do formátu PPTX, nejlepší řešení je provést to programově. S Aspose.Slides API je to možné udělat v několika řádcích kódu. API podporuje plnou kompatibilitu pro převod prezentace PPT na PPTX a lze:

- Převést složité struktury masterů, rozvržení a snímků.
- Převést prezentaci s grafy.
- Převést prezentaci se skupinovými tvary, automatickými tvary (např. obdélníky a elipsy), tvary s vlastní geometrií.
- Převést prezentaci s texturami a styly výplně obrázky pro automatické tvary.
- Převést prezentaci s zástupnými prvky, textovými rámečky a držáky textu.

{{% alert color="info" %}} 

Podívejte se na aplikaci [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

Tato aplikace je postavena na [**Aspose.Slides API**](https://products.aspose.com/slides/cs/java/), takže můžete vidět živý příklad základních možností konverze PPT na PPTX. Aspose.Slides Conversion je webová aplikace, která umožňuje přetáhnout soubor prezentace ve formátu PPT a stáhnout jej převedený na PPTX.

Najděte další živé příklady [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/).

{{% /alert %}} 

## **Převést PPT na PPTX**

Aspose.Slides pro Javu nyní usnadňuje vývojářům přístup k PPT pomocí instance třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) a převod na příslušný formát [PPTX](https://docs.fileformat.com/presentation/pptx/). V současné době podporuje částečný převod [PPT ](https://docs.fileformat.com/presentation/ppt/) na PPTX. Další podrobnosti o tom, které funkce jsou při převodu PPT na PPTX podporovány a které ne, naleznete v této dokumentaci [link](/slides/cs/java/ppt-to-pptx-conversion/).

Aspose.Slides pro Javu nabízí třídu [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation), která představuje soubor prezentace **PPTX**. Třída Presentation může nyní také přistupovat k **PPT** prostřednictvím Presentation při vytvoření instance objektu. Následující příklad ukazuje, jak převést prezentaci PPT na prezentaci PPTX.

```java
import com.aspose.slides.*;

// Vytvořte objekt Presentation, který představuje soubor PPT
Presentation pres = new Presentation("Aspose.ppt");
try {
// Ukládání prezentace PPT do formátu PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Obrázek: Zdrojová PPT prezentace**|

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Obrázek: Vygenerovaná PPTX prezentace po konverzi**|

## **Často kladené otázky**

### Jaký je rozdíl mezi formáty PPT a PPTX?

PPT je starší binární formát souboru používaný Microsoft PowerPoint, zatímco PPTX je novější formát založený na XML, představený v Microsoft Office 2007. Soubory PPTX nabízejí lepší výkon, menší velikost souboru a vylepšené obnovení dat.

### Podporuje Aspose.Slides hromadnou konverzi více souborů PPT na PPTX?

Ano, můžete použít Aspose.Slides ve smyčce k programové konverzi více souborů PPT na PPTX, což je vhodné pro scénáře hromadné konverze.

### Bude po konverzi zachováno obsahu a formátování?

Aspose.Slides zachovává vysokou věrnost při konverzi prezentací. Rozvržení snímků, animace, tvary, grafy a další designové prvky jsou během konverze PPT na PPTX zachovány.

### Mohu převést další formáty, jako PDF nebo HTML, z souborů PPT?

Ano, Aspose.Slides podporuje převod souborů PPT do [více formátů](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/), včetně PDF, XPS, HTML, ODP a formátů obrázků jako PNG a JPEG.

### Je možné převést PPT na PPTX bez nainstalovaného Microsoft PowerPointu?

Ano, Aspose.Slides je samostatné API a nevyžaduje Microsoft PowerPoint ani žádný software třetích stran k provedení konverze.

### Existuje online nástroj pro konverzi PPT na PPTX?

Ano, můžete použít zdarma [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) webovou aplikaci k provedení konverze přímo ve vašem prohlížeči bez psaní jakéhokoli kódu.
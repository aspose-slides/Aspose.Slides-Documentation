---
title: Převést PPT na PPTX v PHP
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/php-java/convert-ppt-to-pptx/
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
- PHP
- Aspose.Slides
description: "Převádějte staré PPT prezentace na moderní PPTX rychle pomocí Aspose.Slides pro PHP přes Java — jasný tutoriál, zdarma ukázkové kódy, bez závislosti na Microsoft Office."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci PowerPoint v formátu PPT na formát PPTX pomocí PHP a online aplikace pro konverzi PPT na PPTX. Pokrývá následující téma.

- Převést PPT na PPTX

## **Převod PPT na PPTX v PHP**

Pro ukázkový kód v Javě pro převod PPT na PPTX se podívejte na sekci níže, tj. [Convert PPT to PPTX](#convert-ppt-to-pptx). Kód pouze načte soubor PPT a uloží jej ve formátu PPTX. Zadáním různých formátů ukládání můžete také uložit soubor PPT do mnoha dalších formátů, jako PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích.

- [Převést PPT na PDF v PHP](/slides/cs/php-java/convert-powerpoint-to-pdf/)
- [Převést PPT na XPS v PHP](/slides/cs/php-java/convert-powerpoint-to-xps/)
- [Převést PPT na HTML v PHP](/slides/cs/php-java/convert-powerpoint-to-html/)
- [Převést PPT na ODP v PHP](/slides/cs/php-java/save-presentation/)
- [Převést PPT na PNG v PHP](/slides/cs/php-java/convert-powerpoint-to-png/)

## **O konverzi PPT na PPTX**

Převod starého formátu PPT na PPTX pomocí Aspose.Slides API. Pokud potřebujete převést tisíce PPT prezentací do formátu PPTX, nejlepší řešení je provést to programově. S Aspose.Slides API je to možné udělat jen v několika řádcích kódu. API podporuje plnou kompatibilitu pro převod PPT prezentací na PPTX a je možné:

- Převést složité struktury mistra, rozložení a snímků.
- Převést prezentaci s grafy.
- Převést prezentaci se skupinovými tvary, automatickými tvary (jako obdélníky a elipsy), tvary s vlastní geometrií.
- Převést prezentaci s texturami a styly výplně obrázků pro automatické tvary.
- Převést prezentaci s místodržícími objekty, textovými rámečky a textovými držáky.

{{% alert color="primary" %}} 

Podívejte se na [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx)

Tato aplikace je vytvořena na základě [**Aspose.Slides API**](https://products.aspose.com/slides/cs/php-java/), takže můžete vidět živý příklad základních schopností převodu PPT na PPTX. Aspose.Slides Conversion je webová aplikace, která umožňuje vložit soubor prezentace ve formátu PPT a stáhnout jej po převodu do PPTX.

Najděte další živé příklady [**Aspose.Slides Conversion**](https://products.aspose.app/slides/cs/conversion/).
{{% /alert %}} 

## **Převod PPT na PPTX**

Aspose.Slides pro PHP přes Java nyní usnadňuje vývojářům přístup k PPT pomocí instance třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) a převod na příslušný formát [PPTX](https://docs.fileformat.com/presentation/pptx/). V současné době podporuje částečný převod [PPT ](https://docs.fileformat.com/presentation/ppt/)to PPTX. Pro podrobnější informace o tom, které funkce jsou v převodu PPT na PPTX podporovány a které ne, přejděte na tuto dokumentaci [link](/slides/cs/php-java/ppt-to-pptx-conversion/).

Aspose.Slides pro PHP přes Java nabízí třídu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) , která představuje soubor prezentace **PPTX**. Třída Presentation nyní může také přistupovat k **PPT** prostřednictvím Presentation, když je objekt vytvořen. Následující příklad ukazuje, jak převést PPT prezentaci na PPTX prezentaci.

```php
  # Vytvoření objektu Presentation, který představuje soubor PPTX
  $pres = new Presentation("Aspose.ppt");
  try {
    # Ukládání prezentace PPTX do formátu PPTX
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
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

**Jaký je rozdíl mezi formáty PPT a PPTX?**

PPT je starší binární formát souboru používaný Microsoft PowerPoint, zatímco PPTX je novější formát založený na XML, zavedený s Microsoft Office 2007. Soubory PPTX nabízejí vyšší výkon, menší velikost souboru a lepší obnovu dat.

**Podporuje Aspose.Slides hromadný převod více souborů PPT na PPTX?**

Ano, můžete použít Aspose.Slides v cyklu k programovému převodu více souborů PPT na PPTX, což je vhodné pro scenáře hromadného převodu.

**Zůstane po převodu zachován obsah a formátování?**

Aspose.Slides zachovává vysokou věrnost při převodu prezentací. Rozvržení snímků, animace, tvary, grafy a další návrhové prvky jsou během převodu PPT na PPTX zachovány.

**Mohu převést PPT soubory i do jiných formátů, jako PDF nebo HTML?**

Ano, Aspose.Slides podporuje převod souborů PPT do [multiple formats](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/), včetně PDF, XPS, HTML, ODP a formátů obrázků jako PNG a JPEG.

**Je možné převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano, Aspose.Slides je samostatné API a nevyžaduje k provedení převodu Microsoft PowerPoint ani žádný jiný software třetí strany.

**Existuje online nástroj pro převod PPT na PPTX?**

Ano, můžete použít zdarma webovou aplikaci [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) k provedení převodu přímo ve vašem prohlížeči bez psaní jakéhokoli kódu.
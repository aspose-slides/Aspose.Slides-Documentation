---
title: Převod prezentací OpenDocument v PHP
linktitle: Převod OpenDocument
type: docs
weight: 10
url: /cs/php-java/convert-openoffice-odp/
keywords:
- převod ODP
- ODP na obrázek
- ODP na GIF
- ODP na HTML
- ODP na JPG
- ODP na MD
- ODP na PDF
- ODP na PNG
- ODP na PPT
- ODP na PPTX
- ODP na TIFF
- ODP na video
- ODP na Word
- ODP na XPS
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Aspose.Slides pro PHP vám umožní snadno převádět ODP do PDF, HTML a formátů obrázků. Zrychlete své PHP aplikace rychlou a přesnou konverzí prezentací."
---
## **Úvod**

[**Aspose.Slides API**](https://products.aspose.com/slides/cs/php-java/) umožňuje převádět prezentace OpenDocument (ODP) do mnoha formátů (HTML, PDF, TIFF, SWF, XPS, atd.). API používané k převodu souborů ODP do dalších formátů dokumentů je stejné jako to, které se používá pro konverzní operace PowerPoint (PPT a PPTX).

## **Převod ODP do PDF**

Například pokud potřebujete převést prezentaci ODP do PDF, můžete to provést následujícím způsobem:

```php
$presentation = null;
try {
    $presentation = new Presentation("pres.odp");
    $presentation->save("pres.pdf", SaveFormat::Pdf);
    
} finally {
    if ($presentation != null) {
        $presentation->dispose();
    }
}
```

## **Často kladené otázky**

**Co když se po konverzi změní formátování mého souboru ODP?**

ODP a PowerPoint používají odlišné prezentační modely a některé prvky — jako tabulky, vlastní písma nebo styly výplní — se nemusí vykreslit přesně stejně. Doporučuje se zkontrolovat výstup a v případě potřeby upravit rozložení nebo formátování v kódu.

**Potřebuji mít nainstalovaný OpenOffice nebo LibreOffice pro použití konverze ODP?**

Ne, Aspose.Slides je samostatná knihovna a nevyžaduje, aby byl OpenOffice nebo LibreOffice nainstalován ve vašem systému.

**Mohu během konverze ODP přizpůsobit výstupní formát (např. nastavit možnosti PDF)?**

Ano, Aspose.Slides poskytuje bohaté možnosti pro přizpůsobení výstupu. Například při ukládání do PDF můžete řídit kompresi, kvalitu obrázků, vykreslování textu a další prostřednictvím třídy [PdfOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/) .

**Je Aspose.Slides vhodný pro serverové nebo cloudové zpracování ODP?**

Rozhodně. Aspose.Slides je navrženo tak, aby fungovalo jak v desktopových, tak v serverových prostředích, včetně cloudových platforem jako Azure, AWS a Docker kontejnery, bez jakýchkoli UI závislostí.
---
title: Převod prezentací OpenDocument v Javě
linktitle: Převod OpenDocument
type: docs
weight: 10
url: /cs/java/convert-openoffice-odp/
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
- Java
- Aspose.Slides
description: "Aspose.Slides pro Javu vám umožňuje snadno převádět ODP do PDF, HTML a obrazových formátů. Zvyšte výkon svých Java aplikací rychlým a přesným převodem prezentací."
---
## **Úvod**

[**Aspose.Slides API**](https://products.aspose.com/slides/cs/java/) umožňuje převádět prezentace OpenDocument (ODP) do mnoha formátů (HTML, PDF, TIFF, SWF, XPS a další). API používané k převodu souborů ODP do jiných formátů dokumentů je stejné jako to, které se používá pro konverzi PowerPoint (PPT a PPTX) operací.

Například pokud potřebujete převést prezentaci ODP do PDF, můžete to provést následujícím způsobem:

```java
Presentation presentation = null;
try {
    presentation = new Presentation("pres.odp");
    presentation.save("pres.pdf", SaveFormat.Pdf);
    
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Prezentace OpenDocument v různých aplikacích**

Když je soubor prezentace OpenDocument (ODP) otevřen v PowerPointu, nemusí zachovat původní formátování z aplikace, ve které byl vytvořen. K tomu dochází, protože aplikace pro OpenDocument prezentaci a PowerPoint nabízejí odlišné funkce a způsoby vykreslování.

Zde jsou některé rozdíly:

- V PowerPointu jsou tabulky obvykle vykreslovány jako poslední a mohou překrývat jiné tvary, bez ohledu na jejich pořadí na snímku ODP.
- Výplň obrázkem pro tabulky ODP není v PowerPointu podporována.
- Vertikální otočení textu (270°, vrstvené) a rozložené zarovnání nejsou v LibreOffice/OpenOffice Impress podporovány.
- Výplň obrázkem, přechodová výplň a vzorková výplň textu nejsou v LibreOffice/OpenOffice Impress podporovány.

MS PowerPoint a LibreOffice/OpenOffice Impress také zacházejí s seznamy odlišně. Soubor ODP vytvořený v PowerPointu se nemusí v LibreOffice/OpenOffice Impress zobrazit správně a naopak.

Níže uvedený obrázek ukazuje, jak seznam vypadá při vytvoření v LibreOffice Impress:

![Příklad seznamu ODP](odp-list-example.png)

Aspose.Slides ukládá seznamy ODP takovým způsobem, že jsou v LibreOffice/OpenOffice Impress zobrazeny správně.

[Další informace o formátu OpenDocument a PowerPointu](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0)

## **Často kladené otázky**

**Co když se po konverzi změní formátování mého souboru ODP?**

ODP a PowerPoint používají odlišné modely prezentací a některé prvky - například tabulky, vlastní písma nebo styly výplní - se nemusí vykreslit přesně stejným způsobem. Doporučuje se výstup zkontrolovat a v případě potřeby upravit rozložení nebo formátování v kódu.

**Potřebuji mít nainstalovaný OpenOffice nebo LibreOffice pro použití konverze ODP?**

Ne, Aspose.Slides je samostatná knihovna a nevyžaduje, aby byl na vašem systému nainstalován OpenOffice nebo LibreOffice.

**Mohu přizpůsobit výstupní formát během konverze ODP (např. nastavit možnosti PDF)?**

Ano, Aspose.Slides poskytuje bohaté možnosti pro přizpůsobení výstupu. Například při ukládání do PDF můžete pomocí třídy [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/) řídit kompresi, kvalitu obrázků, vykreslování textu a další.

**Je Aspose.Slides vhodný pro serverové nebo cloudové zpracování ODP?**

Rozhodně. Aspose.Slides je navržen tak, aby fungoval jak v desktopových, tak v serverových prostředích, včetně cloudových platforem jako Azure, AWS a Docker kontejnery, bez jakýchkoli UI závislostí.
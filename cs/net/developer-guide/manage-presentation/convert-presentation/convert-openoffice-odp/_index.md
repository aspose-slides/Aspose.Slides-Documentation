---
title: Převod prezentací OpenDocument v .NET
linktitle: Převod OpenDocument
type: docs
weight: 10
url: /cs/net/convert-openoffice-odp/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET vám umožňuje snadno převádět ODP do PDF, HTML a formátů obrázků. Zvyšte výkon svých .NET aplikací rychlým a přesným převodem prezentací."
---
## **Úvod**

[**Aspose.Slides API**](https://products.aspose.com/slides/cs/net/) umožňuje převádět prezentace OpenDocument (ODP) do mnoha formátů (HTML, PDF, TIFF, SWF, XPS, atd.). API používané k převodu souborů ODP do jiných formátů dokumentů je stejné jako to, které se používá pro konverzní operace PowerPoint (PPT a PPTX).

Například pokud potřebujete převést prezentaci ODP do PDF, můžete tak učinit následovně:

```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```

## **Prezentace OpenDocument v různých aplikacích**

Když se soubor prezentace OpenDocument (ODP) otevře v PowerPointu, nemusí zachovat původní formátování z aplikace, ve které byl vytvořen. K tomu dochází, protože aplikace OpenDocument a PowerPoint nabízejí odlišné funkce a způsoby vykreslování.

Zde jsou některé rozdíly:

- V PowerPointu jsou tabulky obvykle vykresleny jako poslední a mohou překrývat jiné tvary, bez ohledu na jejich pořadí na snímku ODP.
- Vyplnění obrázkem pro tabulky ODP není v PowerPointu podporováno.
- Vertikální rotace textu (270°, v řadě) a rozložené zarovnání nejsou podporovány v LibreOffice/OpenOffice Impress.
- Vyplnění obrázkem, gradientní vyplnění a vzorové vyplnění textu nejsou v LibreOffice/OpenOffice Impress podporovány.

MS PowerPoint i LibreOffice/OpenOffice Impress také zacházejí s seznamy odlišně. Soubor ODP vytvořený v PowerPointu se nemusí v LibreOffice/OpenOffice Impress zobrazit správně a naopak.

Obrázek níže ukazuje, jak seznam vypadá při vytvoření v LibreOffice Impress:

![ODP list example](odp-list-example.png)

Aspose.Slides ukládá seznamy ODP tak, že jsou v LibreOffice/OpenOffice Impress zobrazeny správně.

[Další informace o formátu OpenDocument a PowerPointu](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **Často kladené otázky**

**Co když se po konverzi změní formátování mého souboru ODP?**

ODP a PowerPoint používají odlišné modely prezentací a některé prvky — například tabulky, vlastní písma nebo styly výplně — nemusí být vykresleny naprosto stejně. Doporučuje se zkontrolovat výstup a v případě potřeby upravit rozvržení nebo formátování v kódu.

**Potřebuji mít nainstalovaný OpenOffice nebo LibreOffice pro použití konverze ODP?**

Ne, Aspose.Slides pro .NET je samostatná knihovna a nevyžaduje instalaci OpenOffice ani LibreOffice ve vašem systému.

**Mohu během konverze ODP přizpůsobit výstupní formát (např. nastavit možnosti PDF)?**

Ano, Aspose.Slides poskytuje rozsáhlé možnosti přizpůsobení výstupu. Například při ukládání do PDF můžete pomocí třídy [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/) řídit kompresi, kvalitu obrázků, vykreslování textu a další.

**Je Aspose.Slides vhodný pro serverové nebo cloudové zpracování ODP?**

Rozhodně. Aspose.Slides pro .NET je navržen tak, aby fungoval jak v desktopových, tak serverových prostředích, včetně cloudových platforem jako Azure, AWS a Docker kontejnery, bez jakýchkoli UI závislostí.
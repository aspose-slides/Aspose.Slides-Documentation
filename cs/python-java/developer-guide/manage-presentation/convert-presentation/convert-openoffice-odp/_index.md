---
title: Převod OpenDocument prezentací v Pythonu
linktitle: Převod OpenDocument
type: docs
weight: 10
url: /cs/python-java/convert-openoffice-odp/
keywords:
- převést ODP
- ODP do PDF
- ODP do HTML
- ODP do TIFF
- ODP do PPT
- ODP do PPTX
- ODP do XPS
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Převést prezentace OpenDocument (ODP) do PDF, HTML a dalších formátů pomocí Aspose.Slides pro Python přes Java, aniž byste museli instalovat OpenOffice nebo LibreOffice."
---
## **Úvod**

Aspose.Slides pro Python přes Java umožňuje převádět prezentace OpenDocument (ODP) do formátů jako PDF, HTML, TIFF, XPS, PPT a PPTX. Převod ODP používá stejné API jako převod PowerPoint: načtěte zdrojový soubor pomocí [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a vyberte výstupní formát pomocí [SaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/).

## **Převést ODP na PDF**

Postupujte podle [instrukcí instalace](/slides/cs/python-java/installation/) před spuštěním příkladu. Umístěte prezentaci ODP nazvanou `pres.odp` do pracovního adresáře. Následující kód spustí JVM, pokud je to nutné, načte prezentaci a uloží ji jako `pres.pdf`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Prezentace OpenDocument v různých aplikacích**

Prezentace ODP se může v PowerPointu a LibreOffice/OpenOffice Impress lišit, protože tyto aplikace podporují různé funkce prezentací a chování vykreslování. Přezkoumejte převedené prezentace, pokud jejich rozvržení závisí na složitém formátování.

Kompatibilitní rozdíly mohou ovlivnit:

- Tabulky, včetně jejich pořadí vrstvení vzhledem k ostatním tvarům a podpory výplní obrázky.
- Rotaci a zarovnání textu.
- Obrázkové, gradientní a vzorové výplně aplikované na text.
- Číslované a odrážkové seznamy.

Obrázek níže zobrazuje seznam vytvořený v LibreOffice Impress:

![Příklad seznamu ODP v LibreOffice Impress](odp-list-example.png)

Aspose.Slides ukládá seznamy ODP pro kompatibilitu s LibreOffice/OpenOffice Impress.

Pro podrobnosti o kompatibilitě funkcí viz [průvodce Microsoftu k formátu OpenDocument Presentation](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **Často kladené otázky**

**Co když se formátování mého souboru ODP změní po převodu?**

ODP a PowerPoint používají odlišné modely prezentací. Tabulky, písma a styly výplní se mohou vykreslovat odlišně. Zkontrolujte, že požadovaná písma jsou dostupná, přezkoumejte výstup a v případě potřeby upravte rozvržení nebo formátování.

**Potřebuji mít nainstalovaný OpenOffice nebo LibreOffice pro převod souborů ODP?**

Ne. Aspose.Slides pro Python přes Java zpracovává prezentace bez jakékoli z těchto aplikací. Je potřeba kompatibilní Java runtime a Python balíček.

**Mohu přizpůsobit výstup PDF při převodu prezentace ODP?**

Ano. Použijte [PdfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/) k nastavení parametrů exportu PDF, jako je kvalita obrazu a komprese.

**Mohu převádět prezentace ODP na serveru nebo v kontejneru?**

Ano. Nainstalujte Python balíček, kompatibilní Java runtime a písma vyžadovaná vašimi prezentacemi v cílovém prostředí. Není potřeba žádná kancelářská aplikace.
---
title: Podporované formáty souborů
type: docs
weight: 30
url: /cs/php-java/supported-file-formats/
keywords:
- formát souboru
- podporovaný formát
- PPT
- POT
- PPS
- PPTX
- POTX
- PPSX
- PPTM
- PPSM
- POTM
- ODP
- FODP
- OTP
- TIFF
- EMF
- PDF
- XPS
- JPEG
- PNG
- GIF
- BMP
- SVG
- SWF
- HTML
- XAML
- MD
- XML
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Objevte všechny formáty souborů, které Aspose.Slides pro PHP via Java dokáže otevřít, uložit a převést — s přehlednými poznámkami o podpoře importu/exportu."
---
## **Přehled**

Aspose.Slides podporuje soubory prezentací od Microsoft PowerPoint 97 po Office 365, včetně Microsoft PowerPoint pro Mac. Tento článek uvádí verze PowerPointu podporované knihovnou a poskytuje tabulku formátů souborů, které lze načíst, uložit nebo obojí.

Článek také odpovídá na časté otázky ohledně souladu PDF, vkládání písem, souborů chráněných heslem, vlastních písem, náhradních písem a možností exportu do XPS.

## **Podporované verze Microsoft PowerPoint**
- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for MAC
- Office 365

## **Podporované formáty souborů**
Tato tabulka obsahuje formáty souborů, které Aspose.Slides for PHP via Java může načíst a uložit:

|**Formát**|**Popis**|**Načíst**|**Uložit**|**Poznámky**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Prezentace PowerPoint 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|Šablona PowerPoint 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|Ukázka PowerPoint 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Prezentace PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|Šablona PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Ukázka PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Prezentace PowerPoint s makry|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Ukázka PowerPoint s makry|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|Šablona PowerPoint s makry|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Prezentace OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|Šablona prezentace OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formát souboru Tag Image| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Rozšířený formát Metafile| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Formát přenosného dokumentu|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Specifikace XML Paper| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|Přenosná síťová grafika| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Formát výměny grafiky| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|Nezávislá bitmapa zařízení| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Škálovatelná vektorová grafika| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Malý webový formát| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|Hypertextový značkovací jazyk|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|Rozšiřitelný značkovací jazyk aplikací| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|Prezentace PowerPoint XML| |{{< emoticons/tick >}}| |

## **FAQ**

**Mohu ukládat prezentace do PDF, které splňují archivní a přístupové standardy (PDF/A a PDF/UA)?**

Ano. Aspose.Slides podporuje export do PDF s úrovněmi souladu jako PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b a také PDF/UA prostřednictvím nastavení [compliance](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/setcompliance/) v [PDF export options](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/).

**Podporuje knihovna vkládání písem při exportu do PDF s podrobnou kontrolou toho, co se vloží?**

Ano. Můžete ovládat, zda jsou písma plně vložena nebo podmnožinována (pouze použité glyfy), určit, jak se zachází s běžnými systémovými písmy, a konfigurovat chování pro ASCII text pomocí [PDF export options](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfoptions/).

**Dokážu zjistit, zda je soubor chráněn heslem, ještě před jeho načtením?**

Ano. Pomocí [factory-based inspection API](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/) můžete dotazovat soubor prezentace a zjistit, zda je chráněn heslem, aniž byste ho plně otevřeli.

**Existují mechanismy náhradních písem a podpora vlastních písem?**

Ano. Knihovna podporuje [loading](/slides/cs/php-java/custom-font/) a [embedding](/slides/cs/php-java/embedded-font/) vlastních písem a poskytuje pravidla [fallback font](/slides/cs/php-java/fallback-font/) k zabránění chybějícím glyfům během vykreslování a konverze.

**Mohu exportovat snímky do XPS a jsou k dispozici možnosti úpravy výstupu XPS?**

Ano. [Export to XPS](/slides/cs/php-java/convert-powerpoint-to-xps/) je podporován a můžete upravit příslušné [save options](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xpsoptions/) pro řízení kvality a obsahu dokumentu XPS.
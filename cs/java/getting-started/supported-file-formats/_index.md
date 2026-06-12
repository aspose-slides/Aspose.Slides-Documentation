---
title: Podporované formáty souborů
type: docs
weight: 20
url: /cs/java/supported-file-formats/
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
- Java
- Aspose.Slides
description: "Objevte všechny formáty souborů, které Aspose.Slides pro Java může otevírat, ukládat a převádět — včetně PPT, PPTX a ODP — s přehlednými poznámkami o podpoře importu/exportu."
---
## **Přehled**

Aspose.Slides podporuje soubory prezentací z Microsoft PowerPoint 97 až po Office 365, včetně Microsoft PowerPoint pro Mac. Tento článek uvádí verze PowerPointu podporované knihovnou a poskytuje tabulku formátů souborů, které lze načíst, uložit nebo obojí.

Článek také odpovídá na časté otázky ohledně souladu s PDF, vkládání fontů, souborů chráněných heslem, vlastních fontů, náhradních fontů a možností exportu do XPS.

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
- Microsoft PowerPoint pro MAC
- Office 365

## **Podporované formáty souborů**
Tato tabulka obsahuje formáty souborů, které Aspose.Slides for Java může načíst a uložit:

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
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formát obrázku TIFF| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Rozšířený formát metafilu| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Formát PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Specifikace XML Paper| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Formát JPEG (Joint Photographic Experts Group)| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|Formát PNG (Portable Network Graphics)| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Formát GIF (Graphics Interchange Format)| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|Formát BMP (Device Independent Bitmap)| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Formát SVG (Scalable Vector Graphics)| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Formát SWF (Small Web Format)| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|Jazyk HTML (Hypertext Markup Language)|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|Jazyk XAML (Extensible Application Markup Language)| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|Prezentace PowerPoint XML| |{{< emoticons/tick >}}| |

## **Často kladené otázky**

**Mohu ukládat prezentace do PDF, které splňují archivní a přístupové standardy (PDF/A a PDF/UA)?**

Ano. Aspose.Slides podporuje export do PDF s úrovněmi souladu, jako jsou PDF/A‑2a, PDF/A‑2b, PDF/A‑2u, PDF/A‑3a, PDF/A‑3b, a také PDF/UA prostřednictvím nastavení [soulad](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/#setCompliance-int-) v [možnosti exportu PDF](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/).

**Podporuje knihovna vkládání fontů při exportu do PDF s podrobnou kontrolou toho, co se vloží?**

Ano. Můžete řídit, zda jsou fonty plně vloženy nebo podmnoženy (pouze použité glyfy), určit, jak se zachází se běžnými systémovými fonty, a nakonfigurovat chování pro ASCII text prostřednictvím [možnosti exportu PDF](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/).

**Mohu zjistit, zda je soubor chráněn heslem, před tím, než jej načtu?**

Ano. Pomocí [API pro inspekci založenou na továrně](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/) můžete dotazovat soubor prezentace a zjistit, zda je chráněn heslem, aniž byste jej plně otevřeli.

**Existují mechanismy náhradních fontů a podpora vlastních fontů?**

Ano. Knihovna podporuje [načítání](/slides/cs/java/custom-font/) a [vkládání](/slides/cs/java/embedded-font/) vlastních fontů a poskytuje [pravidla náhradních fontů](/slides/cs/java/fallback-font/) k zabránění chybějících glyfů při vykreslování a konverzi.

**Mohu exportovat snímky do XPS a jsou k dispozici možnosti nastavení výstupu XPS?**

Ano. [Export do XPS](/slides/cs/java/convert-powerpoint-to-xps/) je podporován a můžete upravit příslušné [možnosti uložení](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xpsoptions/) pro řízení kvality výstupu a obsahu dokumentu XPS.
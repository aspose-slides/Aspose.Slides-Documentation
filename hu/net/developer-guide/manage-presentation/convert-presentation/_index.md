---
title: Prezentációk konvertálása több formátumba .NET-ben
linktitle: Prezentáció konvertálása
type: docs
weight: 70
url: /hu/net/convert-presentation/
keywords:
- prezentáció konvertálása
- prezentáció exportálása
- PPT PPTX-re
- PPTX PPT-re
- ODP PPTX-re
- PPT PDF-re
- PPTX PDF-re
- ODP PDF-re
- PPT HTML-re
- PPTX HTML-re
- ODP HTML-re
- PPT PNG-re
- PPTX PNG-re
- ODP PNG-re
- PPTX JPG-re
- ODP JPG-re
- PPT XPS-re
- PPTX XPS-re
- ODP XPS-re
- PPT TIFF-re
- PPTX TIFF-re
- ODP TIFF-re
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a PowerPoint és OpenDocument prezentációkat PPTX, PDF, HTML, képek, XPS, TIFF és további formátumokra az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for .NET képes betölteni PowerPoint és OpenDocument prezentációkat, és számos más formátumba menteni vagy renderelni őket a Microsoft PowerPoint, OpenOffice vagy LibreOffice nélkül. Átalakíthatja a régi PPT fájlokat a modern PPTX formátumba, exportálhatja a prezentációkat rögzített elrendezésű dokumentumokba, például PDF és XPS formátumba, közzéteheti a diákat HTML-ként, vagy a diákat képfájlokként renderelheti előnézetekhez, bélyegképekhez és archívumokhoz.

A legtöbb dokumentumkonverzió ugyanazt az általános munkafolyamatot követi: betölti a forrásfájlt, kiválasztja a szükséges kimeneti formátumot, és szükség esetén alkalmazza a formátumspecifikus beállításokat. Képek esetén minden diát külön renderelnek, majd raszteres vagy vektoros képként mentik. Az alább hivatkozott dedikált cikkek részletezik a megvalósítást minden esetben.

## **Válasszon Konverziós Forgatókönyvet**

Használja az alábbi cikkeket a teljes C# példákhoz és a formátumspecifikus opciókhoz.

| Forgatókönyv | Mikor használja | Cikk |
| --- | --- | --- |
| PPT/PPTX/ODP PPTX-re | Modernizálja a régi PPT fájlokat, normalizálja a meglévő PPTX fájlokat, vagy konvertálja az OpenDocument prezentációkat PowerPoint PPTX-be. | [PPT konvertálása PPTX-re](/slides/hu/net/convert-ppt-to-pptx/), [ODP konvertálása PPTX-re](/slides/hu/net/convert-odp-to-pptx/), [Prezentációk mentése](/slides/hu/net/save-presentation/) |
| PPTX PPT-re | Modern PowerPoint prezentáció mentése a régi bináris PPT formátumba a régebbi munkafolyamatok kompatibilitásáért. | [PPTX konvertálása PPT-re](/slides/hu/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP PDF-re | Hordozható, kereshető, rögzített elrendezésű dokumentumok létrehozása megosztáshoz, nyomtatáshoz vagy archiváláshoz. | [PowerPoint konvertálása PDF-re](/slides/hu/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP PDF-re jegyzetekkel | Az előadói jegyzetek exportálása a diák tartalmával együtt. | [PowerPoint konvertálása PDF-re jegyzetekkel](/slides/hu/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP HTML-re | Prezentációk közzététele HTML oldalakon, valamint képek, betűtípusok, jegyzetek és reszponzív elrendezés beállítása. | [PowerPoint konvertálása HTML-re](/slides/hu/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP HTML5-re | Diák exportálása HTML5-be böngészőalapú megjelenítéshez, a formázás és interaktivitás megőrzésével. | [Prezentációk konvertálása HTML5-re](/slides/hu/net/export-to-html5/) |
| PPT/PPTX/ODP PNG-re | Minden dia renderelése PNG képként előnézetekhez, bélyegképekhez vagy webes kimenethez. | [PowerPoint konvertálása PNG-re](/slides/hu/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP JPG-re | Diák renderelése JPG képekbe, valamint a kép méretének és minőségének szabályozása. | [PowerPoint konvertálása JPG-re](/slides/hu/net/convert-powerpoint-to-jpg/) |
| Dia SVG-re | Az egyes diák exportálása skálázható vektorgrafikaként. | [Dia renderelése SVG-ként](/slides/hu/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP XPS-re | Rögzített elrendezésű XPS dokumentumok előállítása. | [PowerPoint konvertálása XPS-re](/slides/hu/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP TIFF-re | Prezentáció mentése többoldalas TIFF fájlként nyomtatáshoz, szkenneléshez, faxhoz vagy archiválási munkafolyamatokhoz. | [PowerPoint konvertálása TIFF-re](/slides/hu/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP TIFF-re jegyzetekkel | Diák mentése előadói jegyzetekkel TIFF formátumban. | [PowerPoint konvertálása TIFF-re jegyzetekkel](/slides/hu/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX Word-re | Diák konvertálása Word dokumentummá, ha dokumentum‑stílusú kimenetre van szükség. | [PowerPoint konvertálása Word-re](/slides/hu/net/convert-powerpoint-to-word/) |
| PPT/PPTX Markdownra | Prezentáció tartalmának kinyerése Markdown formátumba dokumentáció és szöveges munkafolyamatok számára. | [PowerPoint konvertálása Markdownra](/slides/hu/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP XML-re | Szöveges alapú PowerPoint XML prezentáció létrehozása ellenőrzéshez, összehasonlításhoz, hibakereséshez vagy XML‑alapú munkafolyamatokhoz. | [PowerPoint konvertálása XML-re](/slides/hu/net/convert-powerpoint-to-xml/) |
| PPT/PPTX animált GIF-re | Animált GIF létrehozása a diákból. | [PowerPoint konvertálása animált GIF-re](/slides/hu/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX videóra | Videó exportálási munkafolyamat felépítése a prezentáció diákból. | [PowerPoint konvertálása videóra](/slides/hu/net/convert-powerpoint-to-video/) |
| Prezentáció XAML-re | Diák exportálása XAML-be .NET UI szcenáriókhoz. | [Prezentációk exportálása XAML-be](/slides/hu/net/export-to-xaml/) |

A bemeneti és kimeneti formátumok átfogó listájáért tekintse meg a [Támogatott fájlformátumok](/slides/hu/net/supported-file-formats/) oldalt.

## **PowerPoint és OpenDocument konverzió**

Az Aspose.Slides for .NET támogatja a gyakran használt prezentációs formátumok konvertálását, mint a PPT, PPTX, PPS, PPSX, POT, POTX és ODP. Ugyanazt a konverziós API-t használja a PowerPoint és az OpenDocument fájlok esetén, így egy PPTX fájl PDF‑be mentésére szolgáló munkafolyamat általában alkalmazható ODP fájlra is, ha csak a bemeneti fájlt cseréljük.

ODP fájlok konvertálásakor vegye figyelembe, hogy a PowerPoint és az OpenDocument alkalmazások nem támogatják minden elrendezési és formázási funkciót pontosan ugyanúgy. Ha egy ODP fájlt LibreOffice vagy OpenOffice Impress segítségével hoztak létre, ellenőrizze a kimenetet, és használja a [OpenDocument prezentációk konvertálása](/slides/hu/net/convert-openoffice-odp/) szakaszban leírt opciókat, amikor formátumspecifikus útmutatásra van szükség.

## **PPT PPTX-re konvertálás**

A PPT a régebbi bináris PowerPoint formátum, míg a PPTX a modern Office Open XML formátum. Az Aspose.Slides for .NET magas pontosságú PPT‑PPTX konverziót támogat, megőrizve a komplex prezentációs struktúrákat, mint például a mesterlapok, elrendezések, diák, diagramok, csoportos alakzatok, helyőrzők, szövegkeretek, textúrák és képtöltések.

Részletekért tekintse meg a [PPT konvertálása PPTX-re](/slides/hu/net/convert-ppt-to-pptx/) és a [PPT vs PPTX](/slides/hu/net/ppt-vs-pptx/) cikkeket.

## **Rögzített elrendezésű export**

A PDF, XPS és TIFF hasznos, ha a kimenetnek minden eszközön ugyanolyannak kell lennie, és nem kell prezentációként szerkeszteni. Használja a [PdfOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/xpsoptions/), és a [TiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/) osztályokat a megfelelőség, rejtett diák, jegyzetek, képminőség, tömörítés, pixel formátum és kimeneti méret szabályozásához.

## **HTML és kép export**

Az HTML és HTML5 exportálás hasznos a böngészőben történő megtekintéshez, webes közzétételhez és könnyű megosztáshoz. Kép exportálás akkor hasznos, ha minden diát külön előnézet, bélyegkép vagy raszteres eszköz kell legyen. Használja a PNG, JPG és SVG cikkeket a formátumspecifikus renderelési útmutatáshoz.

## **GYIK**

**Szükségem van a Microsoft PowerPoint‑re a prezentációk konvertálásához?**

Nem. Az Aspose.Slides for .NET egy önálló könyvtár, és nem igényel Microsoft PowerPoint‑et vagy Office automatizációt.

**Több prezentációt batch módon konvertálhatok?**

Igen. Töltsön be minden prezentációt, mentse a szükséges formátumba, és a feldolgozás után szabadítsa fel a `Presentation` objektumot. Párhuzamos feldolgozás esetén használjon különálló prezentációs példányokat, és kövesse a [többszálú feldolgozás](/slides/hu/net/multithreading/) útmutatót.

**Exportálhatok csak a kiválasztott diákat?**

Igen. Számos export metódus lehetővé teszi a diák indexeinek megadását vagy az egyedi diák renderelését, a kimeneti formátumtól függően. Tekintse meg a dedikált cikket a célformátumhoz.

**Belefoglalhatom a rejtett diákat PDF vagy XPS exportálásakor?**

Igen. Használja a `ShowHiddenSlides` tulajdonságot a [PdfOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pdfoptions/) vagy [XpsOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/xpsoptions/) osztályokban.

**Létrehozhatok PDF/A kimenetet?**

Igen. A PDF megfelelőségi beállítások elérhetők a [PdfOptions.Compliance](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pdfoptions/compliance/) és a [PdfCompliance](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pdfcompliance/) segítségével.

**Hogyan kezelődnek a betűtípusok a konverzió során?**

Az Aspose.Slides használhat beágyazott betűtípusokat, betűtípus visszalépést és betűtípus helyettesítési beállításokat. Tekintse meg a [Beágyazott betűtípus](/slides/hu/net/embedded-font/), [Visszalépő betűtípus](/slides/hu/net/fallback-font/), és a [Betűtípus helyettesítés](/slides/hu/net/font-substitution/) cikkeket.
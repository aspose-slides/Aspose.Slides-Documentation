---
title: Bemutatók konvertálása több formátumba C++-ban
linktitle: Bemutató konvertálása
type: docs
weight: 70
url: /hu/cpp/convert-presentation/
keywords:
- bemutató konvertálása
- bemutató exportálása
- PPT-ról PPTX-re
- PPTX-ról PPT-re
- ODP-ról PPTX-re
- PPT-ról PDF-re
- PPTX-ról PDF-re
- ODP-ról PDF-re
- PPT-ról HTML-re
- PPTX-ról HTML-re
- ODP-ról HTML-re
- PPT-ról PNG-re
- PPTX-ról PNG-re
- ODP-ról PNG-re
- PPTX-ról JPG-re
- ODP-ról JPG-re
- PPT-ról XPS-re
- PPTX-ról XPS-re
- ODP-ról XPS-re
- PPT-ról TIFF-re
- PPTX-ról TIFF-re
- ODP-ról TIFF-re
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "PowerPoint és OpenDocument bemutatók konvertálása PPTX, PDF, HTML, képek, XPS, TIFF és egyéb formátumokba az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az Aspose.Slides for C++ képes betölteni PowerPoint és OpenDocument bemutatókat, és számos más formátumba menteni vagy renderelni azokat anélkül, hogy a Microsoft PowerPoint, az OpenOffice vagy a LibreOffice szükséges lenne. Átalakíthatja a régi PPT fájlokat a modern PPTX formátumba, exportálhatja a bemutatókat rögzített elrendezésű dokumentumokba, például PDF és XPS formátumba, közzéteheti a diakat HTML‑ként, vagy képfájlokként renderelheti a diák előnézeteihez, bélyegképekhez és archívumokhoz.

A legtöbb dokumentumkonverzió ugyanazt az általános munkafolyamatot használja: betölti a forrásfájlt, kiválasztja a szükséges kimeneti formátumot, és szükség esetén alkalmazza a formátumspecifikus beállításokat. Képfájl formátumoknál minden diát külön renderelnek, majd raszteres vagy vektoralaként mentik. Az alább linken lévő dedikált cikkek részletezik a megvalósítást minden esetben.

## **Válasszon egy konverziós forgatókönyvet**

| Forgatókönyv | Használja, ha | Cikk |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | A régi PPT fájlok modernizálása, meglévő PPTX fájlok normalizálása, vagy az OpenDocument bemutatók PowerPoint PPTX formátumba konvertálása. | [PPT átalakítása PPTX-re](/slides/hu/cpp/convert-ppt-to-pptx/), [ODP átalakítása PPTX-re](/slides/hu/cpp/convert-odp-to-pptx/), [Bemutatók mentése](/slides/hu/cpp/save-presentation/) |
| PPTX to PPT | Mentse a modern PowerPoint bemutatót a régebbi bináris PPT formátumba a régi munkafolyamatok kompatibilitása érdekében. | [PPTX átalakítása PPT-re](/slides/hu/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Hordozható, kereshető, rögzített elrendezésű dokumentumok létrehozása megosztáshoz, nyomtatáshoz vagy archiváláshoz. | [PowerPoint átalakítása PDF-re](/slides/hu/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | A előadói jegyzetek exportálása a diáktartalommal együtt. | [PowerPoint átalakítása PDF-re jegyzetekkel](/slides/hu/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Bemutatók közzététele HTML oldalakon, és a képek, betűtípusok, jegyzetek és a reszponzív elrendezés beállítása. | [PowerPoint átalakítása HTML-re](/slides/hu/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Dia exportálása HTML5-be a böngészőben történő megtekintéshez, megőrzött formázással és interaktivitással. | [Bemutatók átalakítása HTML5-re](/slides/hu/cpp/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Minden dia renderelése PNG képre előnézetek, bélyegképek vagy webes kimenet számára. | [PowerPoint átalakítása PNG-re](/slides/hu/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Dia‑k renderelése JPG képekre, és a képmérettel, minőséggel való szabályozás. | [PowerPoint átalakítása JPG-re](/slides/hu/cpp/convert-powerpoint-to-jpg/) |
| Slide to SVG | Egyes diák exportálása méretezhető vektorgrafikaként. | [Dia renderelése SVG-ként](/slides/hu/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Rögzített elrendezésű XPS dokumentumok előállítása. | [PowerPoint átalakítása XPS-re](/slides/hu/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Bemutató mentése többoldalas TIFF fájlként nyomtatáshoz, szkenneléshez, faxhoz vagy archiválási folyamatokhoz. | [PowerPoint átalakítása TIFF-re](/slides/hu/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Dia‑k mentése előadói jegyzetekkel TIFF‑be. | [PowerPoint átalakítása TIFF-re jegyzetekkel](/slides/hu/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Dia‑k konvertálása Word dokumentummá, ha dokumentum‑stílusú kimenetre van szükség. | [PowerPoint átalakítása Word-re](/slides/hu/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | A bemutató tartalmának kinyerése Markdown‑be dokumentációs és szövegalapú munkafolyamatokhoz. | [PowerPoint átalakítása Markdown-re](/slides/hu/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Animált GIF létrehozása a diákból. | [PowerPoint átalakítása animált GIF-re](/slides/hu/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Videó exportáló munkafolyamat építése a bemutató diákból. | [PowerPoint átalakítása videóra](/slides/hu/cpp/convert-powerpoint-to-video/) |
| Presentation to XAML | Dia‑k exportálása XAML‑be C++ UI forgatókönyvekhez. | [Bemutatók exportálása XAML-re](/slides/hu/cpp/export-to-xaml/) |

A bemeneti és kimeneti formátumok szélesebb listájáért lásd [Támogatott fájlformátumok](/slides/hu/cpp/supported-file-formats/).

## **PowerPoint és OpenDocument konverzió**

Az Aspose.Slides for C++ támogatja a konverziót a gyakran használt bemutatóformátumok között, mint a PPT, PPTX, PPS, PPSX, POT, POTX és ODP. Ugyanazt a konverziós API‑t használják a PowerPoint és az OpenDocument fájlokhoz, így egy PPTX fájl PDF‑be mentésére szolgáló munkafolyamat általában alkalmazható ODP fájlra is, csak a bemeneti fájlt kell módosítani.

ODP fájlok konvertálásakor tartsa szem előtt, hogy a PowerPoint és az OpenDocument alkalmazások nem támogatják minden elrendezési és formázási funkciót pontosan ugyanúgy. Ha egy ODP fájlt a LibreOffice vagy az OpenOffice Impress hozott létre, ellenőrizze a kimenetet, és használja a [OpenDocument bemutatók konvertálása](/slides/hu/cpp/convert-openoffice-odp/) leírt beállításokat, ha formátumspecifikus útmutatásra van szüksége.

## **PPT to PPTX konverzió**

A PPT a régebbi bináris PowerPoint formátum, míg a PPTX a modern Office Open XML formátum. Az Aspose.Slides for C++ magas hűségű PPT‑ről PPTX‑re konverziót támogat, megőrizve a komplex bemutatóstruktúrákat, mint a mesterdiák, elrendezések, diák, diagramok, csoportos alakzatok, helyőrzők, szövegkeretek, textúrák és képkitöltések.

Részletekért lásd a [PPT átalakítása PPTX-re](/slides/hu/cpp/convert-ppt-to-pptx/) cikket.

## **Rögzített elrendezésű export**

A PDF, XPS és TIFF hasznos, ha a kimenetnek minden eszközön ugyanúgy kell kinéznie, és nem szabad bemutatóként szerkeszteni. A dedikált PDF, XPS és TIFF cikkek bemutatják, hogyan szabályozhatók a megfelelőség, a rejtett diák, a jegyzetek, a képminőség, a tömörítés, a pixel formátum és a kimeneti méret.

## **HTML és kép export**

A HTML és HTML5 export hasznos böngészőben történő megtekintéshez, webes közzétételhez és könnyű megosztáshoz. Kép export akkor hasznos, ha minden diához külön előnézet, bélyegkép vagy raszteres asset kell. Használja a PNG, JPG és SVG cikkeket a formátumspecifikus renderelési útmutatáshoz.

## **GYIK**

**Szükségem van a Microsoft PowerPointre a bemutatók konvertálásához?**

Nem. Az Aspose.Slides for C++ egy önálló könyvtár, és nem igényel Microsoft PowerPointet vagy Office automatizálást.

**Tömegesen konvertálhatok sok bemutatót?**

Igen. Töltse be minden bemutatót, mentse a kívánt formátumba, majd a feldolgozás után szabadítsa fel a bemutató objektumot. Párhuzamos feldolgozáshoz használjon külön bemutató példányokat, és kövesse a [többszálú feldolgozás](/slides/hu/cpp/multithreading/) útmutatót.

**Exportálhatok csak kiválasztott diákat?**

Igen. Több exportálási mód lehetővé teszi diák indexének megadását vagy egyedi diák renderelését a kimeneti formátumtól függően. Lásd a célformátumra vonatkozó dedikált cikket.

**Rejtett diákat is belevehetünk a PDF vagy XPS exportba?**

Igen. Használja a rejtett dia export beállításait, amelyeket a [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/) és [XPS](/slides/hu/cpp/convert-powerpoint-to-xps/) konverziós cikkekben talál.

**Létrehozhatok PDF/A kimenetet?**

Igen. PDF megfelelőség beállítások érhetők el a PDF exporthoz. Részletekért lásd a [PowerPoint átalakítása PDF-re](/slides/hu/cpp/convert-powerpoint-to-pdf/) cikket.

**Hogyan kezelik a betűtípusokat a konverzió során?**

Az Aspose.Slides használhat beágyazott betűtípusokat, betűtípus tartalékot és betűtípus helyettesítés beállításokat. Lásd a [Beágyazott betűtípus](/slides/hu/cpp/embedded-font/), a [Betűtípus tartalék](/slides/hu/cpp/fallback-font/), és a [Betűtípus helyettesítés](/slides/hu/cpp/font-substitution/) cikkeket.
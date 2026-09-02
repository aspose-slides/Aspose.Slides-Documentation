---
title: Prezentációk konvertálása több formátumba PHP-ben
linktitle: Prezentáció konvertálása
type: docs
weight: 70
url: /hu/php-java/convert-presentation/
keywords:
- prezentáció konvertálása
- prezentáció exportálása
- PPT → PPTX
- PPTX → PPT
- ODP → PPTX
- PPT → PDF
- PPTX → PDF
- ODP → PDF
- PPT → HTML
- PPTX → HTML
- ODP → HTML
- PPT → PNG
- PPTX → PNG
- ODP → PNG
- PPTX → JPG
- ODP → JPG
- PPT → XPS
- PPTX → XPS
- ODP → XPS
- PPT → TIFF
- PPTX → TIFF
- ODP → TIFF
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Konvertálja a PowerPoint és OpenDocument prezentációkat PPTX, PDF, HTML, képek, XPS, TIFF és további formátumokra az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for PHP via Java betöltheti a PowerPoint és OpenDocument prezentációkat, és sok más formátumba mentheti vagy renderelheti őket Microsoft PowerPoint, OpenOffice vagy LibreOffice nélkül. Átalakíthatja a régi PPT fájlokat modern PPTX formátumba, exportálhat prezentációkat rögzített elrendezésű dokumentumokként, például PDF és XPS, közzéteheti a diákat HTML-ként, vagy a diákat képfájlokként renderelheti előnézetekhez, bélyegképekhez és archiváláshoz.

A legtöbb dokumentumkonverzió ugyanazt az általános munkafolyamatot követi: betölti a forrásfájlt, kiválasztja a kívánt kimeneti formátumot, és szükség esetén alkalmazza a formátumspecifikus beállításokat. Képformátumok esetén minden diát külön renderelnek, majd raszteres vagy vektorképként mentik. Az alább hivatkozott dedikált cikkek tartalmazzák az egyes esetek megvalósítási részleteit.

## **Válasszon egy Konverziós Forgatókönyvet**

Használja az alábbi cikkeket teljes PHP példákhoz és formátumspecifikus beállításokhoz.

| Forgatókönyv | Használd, ha szükséges | Cikk |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernizálja a régi PPT fájlokat, normalizálja a meglévő PPTX fájlokat, vagy konvertálja az OpenDocument prezentációkat PowerPoint PPTX-be. | [PPT konvertálása PPTX-be](/slides/hu/php-java/convert-ppt-to-pptx/), [ODP konvertálása PPTX-be](/slides/hu/php-java/convert-odp-to-pptx/), [Prezentációk mentése](/slides/hu/php-java/save-presentation/) |
| PPTX to PPT | Mentse a modern PowerPoint prezentációt régebbi bináris PPT formátumba a régebbi munkafolyamatokkal való kompatibilitás érdekében. | [PPTX konvertálása PPT-be](/slides/hu/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Hozzon létre hordozható, kereshető, rögzített elrendezésű dokumentumokat megosztáshoz, nyomtatáshoz vagy archiváláshoz. | [PowerPoint konvertálása PDF-be](/slides/hu/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportálja a jegyzeteket a diák tartalmával együtt. | [PowerPoint konvertálása PDF-be jegyzetekkel](/slides/hu/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Tegye közzé a prezentációkat HTML oldalként, és szabályozza a képeket, betűtípusokat, jegyzeteket és a reszponzív elrendezést. | [PowerPoint konvertálása HTML-re](/slides/hu/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportálja a diákat HTML5-re böngészőalapú megtekintéshez, megőrizve a formázást és az interaktivitást. | [Prezentációk exportálása HTML5-re](/slides/hu/php-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Rendereljen minden diát PNG képként előnézetekhez, bélyegképekhez vagy webes kimenethez. | [PowerPoint konvertálása PNG-re](/slides/hu/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Rendereljen diákat JPG képként, és szabályozza a képméretet és minőséget. | [PowerPoint konvertálása JPG-re](/slides/hu/php-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportálja az egyes diákat skálázható vektorgrafikaként. | [Dia renderelése SVG-ként](/slides/hu/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Generáljon rögzített elrendezésű XPS dokumentumokat. | [PowerPoint konvertálása XPS-be](/slides/hu/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Mentse a prezentációt többoldalas TIFF fájlként nyomtatáshoz, szkenneléshez, faxhoz vagy archiválási munkafolyamatokhoz. | [PowerPoint konvertálása TIFF-be](/slides/hu/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Mentse a diákat a jegyzetekkel együtt TIFF formátumban. | [PowerPoint konvertálása TIFF-be jegyzetekkel](/slides/hu/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Exportálja a prezentáció tartalmát Markdown formátumba dokumentációs és szövegalapú munkafolyamatokhoz. | [PowerPoint konvertálása Markdown-be](/slides/hu/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Hozzon létre szöveges PowerPoint XML prezentációt ellenőrzéshez, összehasonlításhoz, hibaelhárításhoz vagy XML-alapú munkafolyamatokhoz. | [PowerPoint konvertálása XML-re](/slides/hu/php-java/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Készítsen animált GIF-et a diákból. | [PowerPoint konvertálása animált GIF-re](/slides/hu/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Készítsen videó export munkafolyamatot a prezentációs diákból. | [PowerPoint konvertálása videóra](/slides/hu/php-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportálja a diákat XAML-be PHP vagy Java UI forgatókönyvekhez. | [Prezentációk exportálása XAML-be](/slides/hu/php-java/export-to-xaml/) |

A bemeneti és kimeneti formátumok szélesebb listájáért tekintse meg a [Támogatott fájlformátumok](/slides/hu/php-java/supported-file-formats/) oldalt.

## **PowerPoint és OpenDocument Konverzió**

Az Aspose.Slides for PHP via Java támogatja a gyakran használt prezentációs formátumok közötti konverziót, például PPT, PPTX, PPS, PPSX, POT, POTX és ODP. Ugyanazt a konverziós API-t használja a PowerPoint és az OpenDocument fájlokhoz, így egy PPTX fájl PDF-be mentése általában alkalmazható ODP fájlra is, csak a bemeneti fájlt kell módosítani.

ODP fájlok konvertálásakor vegye figyelembe, hogy a PowerPoint és az OpenDocument alkalmazások nem támogatják pontosan ugyanazt a elrendezést és formázási funkciót. Ha egy ODP fájlt LibreOffice vagy OpenOffice Impress környezetben hoztak létre, ellenőrizze a kimenetet, és használja a [OpenDocument prezentációk konvertálása](/slides/hu/php-java/convert-openoffice-odp/) cikkben leírt beállításokat, ha formátumspecifikus útmutatásra van szüksége.

## **PPT to PPTX Konverzió**

A PPT a régi bináris PowerPoint formátum, míg a PPTX a modern Office Open XML formátum. Az Aspose.Slides for PHP via Java magas hűségű PPT → PPTX konverziót támogat, megőrizve a komplex prezentációs struktúrákat, például mastereket, elrendezéseket, diákat, diagramokat, csoportosított alakzatokat, helyőrzőket, szövegkereteket, textúrákat és képkitöltéseket.

Részletekért lásd a [PPT konvertálása PPTX-be](/slides/hu/php-java/convert-ppt-to-pptx/) és a [PPT vs PPTX](/slides/hu/php-java/ppt-vs-pptx/) cikkeket.

## **Rögzített Elrendezésű Export**

A PDF, XPS és TIFF hasznos, ha a kimenetnek minden eszközön ugyanúgy kell kinéznie, és nem kívánják szerkeszteni prezentációként. A dedikált PDF, XPS és TIFF cikkek bemutatják, hogyan szabályozhatja a megfelelőséget, rejtett diákat, jegyzeteket, képminőséget, tömörítést, pixel formátumot és a kimeneti méretet.

## **HTML és Kép Export**

A HTML és HTML5 export hasznos böngészőben történő megtekintéshez, webes közzétételhez és könnyű megosztáshoz. A képexport akkor hasznos, ha minden diát külön előnézet, bélyegkép vagy raszter eszköz kell. Használja a PNG, JPG és SVG cikkeket a formátumspecifikus renderelési útmutatóhoz.

## **GYIK**

**Szükségem van Microsoft PowerPoint-re a prezentációk konvertálásához?**

Nem. Az Aspose.Slides for PHP via Java egy önálló könyvtár, és nem igényel Microsoft PowerPoint vagy Office automatizálást.

**Tömegesen tudok konvertálni sok prezentációt?**

Igen. Töltse be minden prezentációt, mentse a kívánt formátumba, és a feldolgozás után szabadítsa fel a prezentáció objektumot. Párhuzamos feldolgozáshoz használjon külön prezentációs példányokat, és kövesse a [többszálú feldolgozás](/slides/hu/php-java/multithreading/) útmutatót.

**Kiválaszthatok csak bizonyos diákat exportáláskor?**

Igen. Számos export módszer lehetővé teszi diák indexének megadását vagy egyedi diák renderelését, a kimeneti formátumtól függően. Lásd a célformátumra vonatkozó dedikált cikket.

**Rejtett diákat is belevehet a PDF vagy XPS exportba?**

Igen. Használja a rejtett-diák export beállításait, amint azt a [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/) és [XPS](/slides/hu/php-java/convert-powerpoint-to-xps/) konverziós cikkek leírják.

**Létrehozhatok PDF/A kimenetet?**

Igen. PDF megfelelőségi beállítások érhetők el PDF exportálásához. Részletekért tekintse meg a [PowerPoint konvertálása PDF-be](/slides/hu/php-java/convert-powerpoint-to-pdf/) cikket.

**Hogyan kezelik a betűtípusokat a konverzió során?**

Az Aspose.Slides használhat beágyazott betűtípusokat, betűtípus helyettesítést és betűtípus visszaesést. Lásd a [Beágyazott betűtípus](/slides/hu/php-java/embedded-font/), [Helyettesítő betűtípus](/slides/hu/php-java/fallback-font/), és a [Betűtípus helyettesítés](/slides/hu/php-java/font-substitution/) cikkeket.
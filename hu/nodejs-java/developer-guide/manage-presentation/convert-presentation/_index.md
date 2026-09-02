---
title: "Prezentációk konvertálása több formátumba JavaScript-ben"
linktitle: "Prezentáció konvertálása"
type: docs
weight: 70
url: /hu/nodejs-java/convert-presentation/
keywords:
- "prezentáció konvertálása"
- "prezentáció exportálása"
- "PPT → PPTX"
- "PPTX → PPT"
- "ODP → PPTX"
- "PPT → PDF"
- "PPTX → PDF"
- "ODP → PDF"
- "PPT → HTML"
- "PPTX → HTML"
- "ODP → HTML"
- "PPT → PNG"
- "PPTX → PNG"
- "ODP → PNG"
- "PPTX → JPG"
- "ODP → JPG"
- "PPT → XPS"
- "PPTX → XPS"
- "ODP → XPS"
- "PPT → TIFF"
- "PPTX → TIFF"
- "ODP → TIFF"
- "PowerPoint"
- "OpenDocument"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Konvertálja a PowerPoint és OpenDocument prezentációkat PPTX, PDF, HTML, képek, XPS, TIFF és egyéb formátumokba az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java képes betölteni PowerPoint és OpenDocument prezentációkat, és számos más formátumba menteni vagy renderelni őket a Microsoft PowerPoint, OpenOffice vagy LibreOffice nélkül. Átalakíthatja a régi PPT fájlokat modern PPTX-re, exportálhat prezentációkat rögzített elrendezésű dokumentumokba, például PDF és XPS, közzéteheti a diákot HTML-ként, vagy a diákból képfájlokat készíthet előnézetekhez, bélyegképekhez és archívumokhoz.

A legtöbb dokumentumkonverzió ugyanazt az általános munkafolyamatot használja: betölti a forrásfájlt, kiválasztja a kívánt kimeneti formátumot, és szükség esetén alkalmazza a formátumspecifikus beállításokat. Képfájlok esetén minden diát külön renderelnek, majd raszter vagy vektor képként mentik. Az alább található dedikált cikkek tartalmazzák a részletes megvalósítást.

## **Válasszon egy konverziós forgatókönyvet**

Használja az alábbi cikkeket a teljes JavaScript példákhoz és formátumspecifikus beállításokhoz.

| Forgatókönyv | Használja, ha szüksége van rá | Cikk |
| --- | --- | --- |
| PPT/PPTX/ODP → PPTX | Régi PPT fájlok modernizálása, meglévő PPTX fájlok normalizálása, vagy OpenDocument prezentációk PowerPoint PPTX formátumba konvertálása. | [PPT konvertálása PPTX-be](/slides/hu/nodejs-java/convert-ppt-to-pptx/), [ODP konvertálása PPTX-be](/slides/hu/nodejs-java/convert-odp-to-pptx/), [Prezentációk mentése](/slides/hu/nodejs-java/save-presentation/) |
| PPTX → PPT | Modern PowerPoint prezentáció mentése a régi bináris PPT formátumba az idősebb munkafolyamatok kompatibilitásáért. | [PPTX konvertálása PPT-be](/slides/hu/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP → PDF | Hordozható, kereshető, rögzített elrendezésű dokumentumok létrehozása megosztáshoz, nyomtatáshoz vagy archiváláshoz. | [PowerPoint konvertálása PDF-be](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP → PDF jegyzetekkel | Előadói jegyzetek exportálása a dia tartalmával együtt. | [PowerPoint konvertálása PDF-be jegyzetekkel](/slides/hu/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP → HTML | Prezentációk közzététele HTML oldalakon, valamint képek, betűtípusok, jegyzetek és reszponzív elrendezés vezérlése. | [PowerPoint konvertálása HTML-be](/slides/hu/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP → HTML5 | Diai exportálás HTML5-be böngészőben történő megtekintéshez, a formázás és interaktivitás megőrzésével. | [Prezentációk konvertálása HTML5-be](/slides/hu/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP → PNG | Minden dia PNG képpé renderelése előnézetekhez, bélyegképekhez vagy webes kimenethez. | [PowerPoint konvertálása PNG-be](/slides/hu/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP → JPG | Diai exportálás JPG képként, a kép méretének és minőségének szabályozásával. | [PowerPoint konvertálása JPG-be](/slides/hu/nodejs-java/convert-powerpoint-to-jpg/) |
| Dia → SVG | Egyedi diák exportálása méretezhető vektoros grafikaként. | [Dia renderelése SVG képként](/slides/hu/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP → XPS | Rögzített elrendezésű XPS dokumentumok létrehozása. | [PowerPoint konvertálása XPS-be](/slides/hu/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP → TIFF | Prezentáció mentése többoldalas TIFF fájlként nyomtatáshoz, szkenneléshez, faxhoz vagy archiválási folyamatokhoz. | [PowerPoint konvertálása TIFF-be](/slides/hu/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP → TIFF jegyzetekkel | Diák mentése előadói jegyzetekkel TIFF-be. | [PowerPoint konvertálása TIFF-be jegyzetekkel](/slides/hu/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX → Markdown | Prezentáció tartalmának kinyerése Markdown formátumba dokumentációhoz és szöveges munkafolyamatokhoz. | [PowerPoint konvertálása Markdown-be](/slides/hu/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP → XML | Szöveges alapú PowerPoint XML prezentáció létrehozása ellenőrzéshez, összehasonlításhoz, hibaelhárításhoz vagy XML-alapú munkafolyamatokhoz. | [PowerPoint konvertálása XML-be](/slides/hu/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX → animált GIF | Animált GIF létrehozása diákból. | [PowerPoint konvertálása animált GIF-be](/slides/hu/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX → videó | Videó export munkafolyamat létrehozása a prezentáció diákból. | [PowerPoint konvertálása videóba](/slides/hu/nodejs-java/convert-powerpoint-to-video/) |
| Prezentáció → XAML | Diák exportálása XAML-be JavaScript vagy Java UI forgatókönyvekhez. | [Prezentációk exportálása XAML-be](/slides/hu/nodejs-java/export-to-xaml/) |

A bemeneti és kimeneti formátumok szélesebb listájáért lásd a [Támogatott fájlformátumok](/slides/hu/nodejs-java/supported-file-formats/) oldalt.

## **PowerPoint és OpenDocument átalakítás**

Az Aspose.Slides for Node.js via Java támogatja a gyakran használt prezentációformátumok, például PPT, PPTX, PPS, PPSX, POT, POTX és ODP konvertálását. Ugyanazt a konverziós API-t használja a PowerPoint és OpenDocument fájlok esetén, így egy PPTX fájlt PDF-be mentő munkafolyamat általában alkalmazható ODP fájlra is, csak a bemeneti fájlt kell módosítani.

ODP fájlok konvertálásakor vegye figyelembe, hogy a PowerPoint és az OpenDocument alkalmazások nem támogatják minden elrendezési és formázási funkciót pontosan ugyanúgy. Ha egy ODP fájl a LibreOffice vagy az OpenOffice Impress programban készült, ellenőrizze a kimenetet, és használja a [OpenDocument prezentációk konvertálása](/slides/hu/nodejs-java/convert-openoffice-odp/) leírt beállításokat, ha formátumspecifikus útmutatásra van szüksége.

## **PPT → PPTX konverzió**

A PPT a régebbi bináris PowerPoint formátum, míg a PPTX a modern Office Open XML formátum. Az Aspose.Slides for Node.js via Java magas pontosságú PPT → PPTX konverziót támogat, miközben megőrzi a komplex prezentációs struktúrákat, például mesterlapokat, elrendezéseket, diák, diagramok, csoportosított alakzatok, helykitöltőket, szövegkereteket, textúrákat és képkitöltéseket.

Részletekért lásd a [PPT konvertálása PPTX-be](/slides/hu/nodejs-java/convert-ppt-to-pptx/) és a [PPT vs PPTX](/slides/hu/nodejs-java/ppt-vs-pptx/) cikkeket.

## **Rögzített elrendezésű export**

A PDF, XPS és TIFF hasznos, ha a kimenetnek minden eszközön ugyanúgy kell kinéznie, és nem szabad prezentációként szerkeszteni. A dedikált PDF, XPS és TIFF cikkek bemutatják, hogyan lehet szabályozni a megfelelőséget, rejtett diákot, jegyzeteket, képminőséget, tömörítést, pixel formátumot és a kimeneti méretet.

## **HTML és képek exportálása**

A HTML és HTML5 export hasznos a böngészőben való megtekintéshez, webes közzétételhez és könnyű megosztáshoz. Kép export akkor hasznos, ha minden diához külön előnézet, bélyegkép vagy raszter elem szükséges. A PNG, JPG és SVG cikkek nyújtanak formátumspecifikus renderelési útmutatást.

## **FAQ**

**Szükségem van a Microsoft PowerPoint-re a prezentációk konvertálásához?**

Nem. Az Aspose.Slides for Node.js via Java egy önálló könyvtár, és nem igényli a Microsoft PowerPoint vagy az Office automatizálást.

**Tömegesen konvertálhatok sok prezentációt?**

Igen. Töltsön be minden prezentációt, mentse a kívánt formátumba, és a feldolgozás után szabadítsa fel a prezentáció objektumot. Párhuzamos feldolgozás esetén használjon külön prezentációs példányokat, és kövesse a [több szálú](/slides/hu/nodejs-java/multithreading/) útmutatót.

**Exportálhatok csak kiválasztott diákot?**

Igen. Számos exportálási módszer lehetővé teszi a diák indexének megadását vagy egyedi diák renderelését a kimeneti formátumtól függően. Tekintse meg a célformátumra vonatkozó dedikált cikket.

**Bele tudom-e foglalni a rejtett diákot PDF vagy XPS exportálásakor?**

Igen. Használja a [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) és [XPS](/slides/hu/nodejs-java/convert-powerpoint-to-xps/) konverziós cikkekben leírt rejtett dia export beállításokat.

**Létrehozhatok PDF/A kimenetet?**

Igen. PDF megfelelőségi beállítások elérhetők a PDF exporthoz. Részletekért lásd a [PowerPoint konvertálása PDF-be](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) cikket.

**Hogyan kezelődnek a betűtípusok a konverzió során?**

Az Aspose.Slides használhat beágyazott betűtípusokat, betűtípus tartalékot és betűtípus helyettesítési beállításokat. Lásd a [Beágyazott betűtípus](/slides/hu/nodejs-java/embedded-font/), [Betűtípus tartalék](/slides/hu/nodejs-java/fallback-font/), és a [Betűtípus helyettesítés](/slides/hu/nodejs-java/font-substitution/) cikkeket.
---
title: Prezentációk átalakítása több formátumba Androidon
linktitle: Prezentáció átalakítása
type: docs
weight: 70
url: /hu/androidjava/convert-presentation/
keywords:
- prezentáció átalakítása
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
- Android
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint és OpenDocument prezentációkat PPTX, PDF, HTML, képek, XPS, TIFF és egyéb formátumokra az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Android via Java képes betölteni PowerPoint és OpenDocument prezentációkat, és számos egyéb formátumba menteni vagy renderelni azokat anélkül, hogy Microsoft PowerPoint, OpenOffice vagy LibreOffice szükséges lenne. Átalakíthatja a régi PPT fájlokat modern PPTX formátumba, exportálhatja a prezentációkat rögzített elrendezésű dokumentumokként, például PDF vagy XPS, közzéteheti a diákot HTML-ként, vagy képfájlokként renderelheti a diákat előnézetek, bélyegképek és archívumok céljából.

Általában a dokumentumkonverziók ugyanazt az általános munkafolyamatot követik: betöltik a forrásfájlt, kiválasztják a szükséges kimeneti formátumot, és szükség esetén alkalmazzák a formátumspecifikus beállításokat. Képek esetén minden diát külön renderelnek, majd raszter vagy vektor képként mentik. Az alább hivatkozott dedikált cikkek részletezik az egyes esetek megvalósítását.

## **Válasszon konverziós forgatókönyvet**

Használja az alábbi cikkeket a teljes Java példákhoz és a formátumspecifikus beállításokhoz.

| Forgatókönyv | Használja, ha szüksége van rá | Cikk |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernizálja a régi PPT fájlokat, normalizálja a meglévő PPTX fájlokat, vagy alakítsa át az OpenDocument prezentációkat PowerPoint PPTX formátumba. | [PPT átalakítása PPTX-re](/slides/hu/androidjava/convert-ppt-to-pptx/), [ODP átalakítása PPTX-re](/slides/hu/androidjava/convert-odp-to-pptx/), [Prezentációk mentése](/slides/hu/androidjava/save-presentation/) |
| PPTX to PPT | Mentse a modern PowerPoint prezentációt a régebbi bináris PPT formátumba a régi munkafolyamatokkal való kompatibilitás érdekében. | [PPTX átalakítása PPT-re](/slides/hu/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Hozzon létre hordozható, kereshető, rögzített elrendezésű dokumentumokat megosztáshoz, nyomtatáshoz vagy archiváláshoz. | [PowerPoint átalakítása PDF-re](/slides/hu/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportálja a jegyzetelődik megjegyzéseket a diák tartalmával együtt. | [PowerPoint átalakítása PDF-re jegyzetekkel](/slides/hu/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Közzéteszi a prezentációkat HTML oldalként, és szabályozhatja a képeket, betűtípusokat, jegyzeteket és a választható elrendezési beállításokat. | [PowerPoint átalakítása HTML-re](/slides/hu/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportálja a diákat HTML5-re böngésző alapú megtekintéshez, megőrizve a formázást és az interaktivitást. | [Prezentációk átalakítása HTML5-re](/slides/hu/androidjava/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Renderelje minden diát PNG képre előnézetek, bélyegképek vagy webkimenet céljából. | [PowerPoint átalakítása PNG-re](/slides/hu/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Renderelje a diákat JPG képekre, és szabályozza a képméreteket és a minőséget. | [PowerPoint átalakítása JPG-re](/slides/hu/androidjava/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportálja az egyes diákat méretezhető vektoros grafikaként (SVG). | [Dia renderelése SVG-ként](/slides/hu/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Készítsen rögzített elrendezésű XPS dokumentumokat. | [PowerPoint átalakítása XPS-re](/slides/hu/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Mentse a prezentációt többlapos TIFF fájlként nyomtatás, szkennelés, fax vagy archiválás céljából. | [PowerPoint átalakítása TIFF-re](/slides/hu/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Mentse a diákat a jegyzetelődik megjegyzésekkel együtt TIFF-be. | [PowerPoint átalakítása TIFF-re jegyzetekkel](/slides/hu/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Alakítsa a diákat Word dokumentummá, ha dokumentumszerű kimenetre van szükség. | [PowerPoint átalakítása Word-re](/slides/hu/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Extrahálja a prezentáció tartalmát Markdown formátumba dokumentációhoz és szövegalapú munkafolyamatokhoz. | [PowerPoint átalakítása Markdown-re](/slides/hu/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Hozzon létre szöveges alapú PowerPoint XML prezentációt ellenőrzéshez, összehasonlításhoz, hibaelhárításhoz vagy XML-alapú munkafolyamatokhoz. | [PowerPoint átalakítása XML-re](/slides/hu/androidjava/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Készítsen animált GIF-et a diákról. | [PowerPoint átalakítása animált GIF-re](/slides/hu/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Építsen videó export munkafolyamatot a prezentáció diákból. | [PowerPoint átalakítása videóra](/slides/hu/androidjava/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportálja a diákat XAML-be Android vagy Java UI szcenáriókhoz. | [Prezentációk exportálása XAML-be](/slides/hu/androidjava/export-to-xaml/) |

A bemeneti és kimeneti formátumok szélesebb listájáért tekintse meg a [Támogatott fájlformátumok](/slides/hu/androidjava/supported-file-formats/).

## **PowerPoint és OpenDocument konverzió**

Az Aspose.Slides for Android via Java támogatja a gyakran használt prezentációs formátumok, például PPT, PPTX, PPS, PPSX, POT, POTX és ODP közötti konverziót. Ugyanazt a konverziós API-t használja PowerPoint és OpenDocument fájlokhoz, így egy PPTX fájl PDF-re mentését végző munkafolyamat általában az ODP fájlra is alkalmazható, ha csak a bemeneti fájlt cseréljük.

ODP fájlok konvertálásakor ne feledje, hogy a PowerPoint és OpenDocument alkalmazások nem támogatják pontosan ugyanúgy az összes elrendezési és formázási funkciót. Ha egy ODP fájlt LibreOffice vagy OpenOffice Impress segítségével hoztak létre, ellenőrizze a kimenetet, és használja a [OpenDocument prezentációk konvertálása](/slides/hu/androidjava/convert-openoffice-odp/) cikkben leírt beállításokat, ha formátumspecifikus útmutatásra van szükség.

## **PPT → PPTX konverzió**

A PPT a régebbi bináris PowerPoint formátum, míg a PPTX a modern Office Open XML formátum. Az Aspose.Slides for Android via Java magas hűségű PPT → PPTX konverziót támogat, miközben megőrzi a komplex prezentációs struktúrákat, mint például a masterek, elrendezések, diák, diagramok, csoportosított objektumok, helyőrzők, szövegkeretek, textúrák és képtöltések.

A részletekért tekintse meg a [PPT átalakítása PPTX-re](/slides/hu/androidjava/convert-ppt-to-pptx/) és a [PPT vs PPTX](/slides/hu/androidjava/ppt-vs-pptx/) cikkeket.

## **Rögzített elrendezés exportálása**

A PDF, XPS és TIFF akkor hasznos, ha a kimenetnek minden eszközön ugyanolyannak kell lennie, és nem kell prezentációként szerkeszteni. A dedikált PDF, XPS és TIFF cikkek bemutatják, hogyan szabályozhatók a megfelelőség, a rejtett diák, a jegyzetek, a képi minőség, a tömörítés, a pixelformátum és a kimeneti méret.

## **HTML és kép exportálása**

A HTML és HTML5 exportálás hasznos böngészőben történő megtekintéshez, webes közzétételhez és könnyű megosztáshoz. Kép exportálásra akkor van szükség, ha minden diát külön előnézet, bélyegkép vagy raszteres eszköz kell legyen. Használja a PNG, JPG és SVG cikkeket a formátumspecifikus renderelési útmutatáshoz.

## **GYIK**

**Szükségem van Microsoft PowerPoint-re a prezentációk konvertálásához?**

Nem. Az Aspose.Slides for Android via Java önálló könyvtár, és nem igényel Microsoft PowerPoint-et vagy Office automatizálást.

**Tömegesen konvertálhatok sok prezentációt?**

Igen. Töltsön be minden prezentációt, mentse a kívánt formátumba, majd a feldolgozás után szabadítsa fel a prezentáció objektumot. Párhuzamos feldolgozáshoz használjon külön prezentációs példányokat, és kövesse a [többszálúság](/slides/hu/androidjava/multithreading/) útmutatót.

**Exportálhatok csak kiválasztott diákat?**

Igen. Számos exportálási módszer lehetővé teszi diák indexének megadását vagy egyedi diák renderelését a kimeneti formátumtól függően. Lásd a dedikált cikket a célformátumhoz.

**Bele lehet foglalni a rejtett diákat PDF vagy XPS exportálásakor?**

Igen. Használja a rejtett dia exportálási beállításokat, amelyek a [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/) és a [XPS](/slides/hu/androidjava/convert-powerpoint-to-xps/) konverziós cikkekben vannak leírva.

**Készíthetek PDF/A kimenetet?**

Igen. PDF megfelelőségi beállítások állnak rendelkezésre a PDF exportáláshoz. Részletekért tekintse meg a [PowerPoint átalakítása PDF-re](/slides/hu/androidjava/convert-powerpoint-to-pdf/) cikket.

**Hogyan kezelődnek a betűtípusok a konverzió során?**

Az Aspose.Slides használhat beágyazott betűtípusokat, helyettesítő betűtípust és betűtípus helyettesítés beállításokat. Lásd a [Beágyazott betűtípus](/slides/hu/androidjava/embedded-font/), a [Helyettesítő betűtípus](/slides/hu/androidjava/fallback-font/) és a [Betűtípus helyettesítés](/slides/hu/androidjava/font-substitution/) cikkeket.
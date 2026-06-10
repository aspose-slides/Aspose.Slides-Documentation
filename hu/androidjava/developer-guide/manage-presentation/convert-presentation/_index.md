---
title: Prezentációk konvertálása több formátumba Androidon
linktitle: Prezentáció konvertálása
type: docs
weight: 70
url: /hu/androidjava/convert-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint és OpenDocument prezentációkat PPTX, PDF, HTML, képek, XPS, TIFF és egyéb formátumokba az Aspose.Slides for Android via Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java képes betölteni PowerPoint és OpenDocument prezentációkat, és számos egyéb formátumba menteni vagy renderelni őket a Microsoft PowerPoint, OpenOffice vagy LibreOffice nélkül. A régi PPT fájlokat átalakíthatja modern PPTX formátumba, exportálhatja a prezentációkat rögzített elrendezésű dokumentumokba, például PDF és XPS formátumba, közzéteheti a diákat HTML‑ként, vagy renderelheti a diákat képfájlokként előnézetekhez, bélyegképekhez és archiváláshoz.

A legtöbb dokumentumkonverzió ugyanazt az általános munkafolyamatot használja: betölti a forrásfájlt, kiválasztja a kívánt kimeneti formátumot, és szükség esetén alkalmazza a formátumspecifikus beállításokat. Képformátumok esetén minden diákat külön renderel, majd raszteres vagy vektorképként menti. Az alább hivatkozott dedikált cikkek részletes megvalósítási útmutatót nyújtanak az egyes esetekhez.

## **Válasszon egy konverziós forgatókönyvet**

Használja az alábbi cikkeket a teljes Java példákhoz és a formátumspecifikus beállításokhoz.

| Szenárió | Akkor használja, ha | Cikk |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernizálja a régi PPT fájlokat, normalizálja a meglévő PPTX fájlokat, vagy alakítsa át az OpenDocument prezentációkat PowerPoint PPTX‑évé. | [PPT konvertálása PPTX‑be](/slides/hu/androidjava/convert-ppt-to-pptx/), [ODP konvertálása PPTX‑be](/slides/hu/androidjava/convert-odp-to-pptx/), [Prezentációk mentése](/slides/hu/androidjava/save-presentation/) |
| PPTX to PPT | Modern PowerPoint prezentáció mentése a régebbi bináris PPT formátumba a régebbi munkafolyamatokhoz való kompatibilitás érdekében. | [PPTX konvertálása PPT‑be](/slides/hu/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Hordozható, kereshető, rögzített elrendezésű dokumentumok létrehozása megosztáshoz, nyomtatáshoz vagy archiváláshoz. | [PowerPoint konvertálása PDF‑be](/slides/hu/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Előadói jegyzetek exportálása a diák tartalmával együtt. | [PowerPoint konvertálása PDF‑be jegyzetekkel](/slides/hu/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Prezentációk közzététele HTML oldalakon, és képek, betűtípusok, jegyzetek, valamint reszponzív elrendezés beállításainak vezérlése. | [PowerPoint konvertálása HTML‑re](/slides/hu/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Diák exportálása HTML5‑be böngészőben történő megtekintéshez a formázás és interaktivitás megőrzésével. | [Prezentációk konvertálása HTML5‑re](/slides/hu/androidjava/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Minden diát PNG képpé renderel előnézetekhez, bélyegképekhez vagy webes kimenethez. | [PowerPoint konvertálása PNG‑re](/slides/hu/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Diák renderelése JPG képekbe, és a kép méretének és minőségének szabályozása. | [PowerPoint konvertálása JPG‑re](/slides/hu/androidjava/convert-powerpoint-to-jpg/) |
| Slide to SVG | Egyes diák exportálása skálázható vektorgrafikaként. | [Dia renderelése SVG‑ként](/slides/hu/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Rögzített elrendezésű XPS dokumentumok létrehozása. | [PowerPoint konvertálása XPS‑re](/slides/hu/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Prezentáció mentése többoldalas TIFF fájlként nyomtatáshoz, szkenneléshez, faxhoz vagy archiváláshoz. | [PowerPoint konvertálása TIFF‑re](/slides/hu/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Diák előadói jegyzetekkel történő mentése TIFF‑be. | [PowerPoint konvertálása TIFF‑be jegyzetekkel](/slides/hu/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Diák konvertálása Word dokumentummá, ha dokumentum stílusú kimenetre van szükség. | [PowerPoint konvertálása Word‑re](/slides/hu/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Prezentáció tartalmának kinyerése Markdown formátumba dokumentációhoz és szöveges munkafolyamatokhoz. | [PowerPoint konvertálása Markdown‑ra](/slides/hu/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Animált GIF létrehozása a diákból. | [PowerPoint konvertálása animált GIF‑be](/slides/hu/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Videó export munkafolyamat létrehozása a prezentáció diákból. | [PowerPoint konvertálása videóra](/slides/hu/androidjava/convert-powerpoint-to-video/) |
| Presentation to XAML | Diák exportálása XAML‑be Android vagy Java UI forgatókönyvekhez. | [Prezentációk exportálása XAML‑re](/slides/hu/androidjava/export-to-xaml/) |

A bemeneti és kimeneti formátumok szélesebb listájáért tekintse meg a [Támogatott fájlformátumok](/slides/hu/androidjava/supported-file-formats/) oldalt.

## **PowerPoint és OpenDocument konverzió**

Az Aspose.Slides for Android via Java támogatja a gyakran használt prezentációs formátumok, például a PPT, PPTX, PPS, PPSX, POT, POTX és ODP közötti konverziót. Ugyanazt a konverziós API‑t használja a PowerPoint és az OpenDocument fájlok esetén, így egy PPTX‑ből PDF‑be mentő munkafolyamat általában az ODP fájlra is alkalmazható, csak a bemeneti fájlt cserélve.

ODP fájlok konvertálásakor vegye figyelembe, hogy a PowerPoint és az OpenDocument alkalmazások nem támogatják minden elrendezési és formázási funkciót pontosan ugyanúgy. Ha egy ODP fájlt LibreOffice vagy OpenOffice Impressben hoztak létre, ellenőrizze a kimenetet, és használja a [OpenDocument prezentációk konvertálása](/slides/hu/androidjava/convert-openoffice-odp/) cikkben leírt opciókat, amikor formátumspecifikus útmutatásra van szüksége.

## **PPT konvertálása PPTX‑be**

A PPT a régi bináris PowerPoint formátum, míg a PPTX a modern Office Open XML formátum. Az Aspose.Slides for Android via Java magas hűségű PPT‑t‑PPTX konverziót támogat, miközben megőrzi az összetett prezentációs struktúrákat, például master‑eket, elrendezéseket, diákat, diagramokat, csoportos alakzatokat, helyőrzőket, szövegkereteket, textúrákat és képpel kitöltéseket.

Részletekért tekintse meg a [PPT konvertálása PPTX‑be](/slides/hu/androidjava/convert-ppt-to-pptx/) és a [PPT vs PPTX](/slides/hu/androidjava/ppt-vs-pptx/) cikkeket.

## **Rögzített elrendezésű export**

A PDF, XPS és TIFF akkor hasznos, ha a kimenetnek minden eszközön ugyanúgy kell kinéznie, és nem kell szerkeszteni prezentációként. A dedikált PDF, XPS és TIFF cikkek bemutatják, hogyan szabályozhatja a megfelelőséget, a rejtett diákat, a jegyzeteket, a képminőséget, a tömörítést, a pixelformátumot és a kimeneti méretet.

## **HTML és kép export**

A HTML és HTML5 export hasznos böngészőben való megtekintéshez, webes közzétételhez és könnyű megosztáshoz. A képexport akkor előnyös, ha minden diát külön előnézet, bélyegkép vagy raszteres eszköz kell. Használja a PNG, JPG és SVG cikkeket a formátumspecifikus renderelési útmutatóhoz.

## **GYIK**

**Szükségem van a Microsoft PowerPointra a prezentációk konvertálásához?**

Nem. Az Aspose.Slides for Android via Java önálló könyvtár, és nem igényli a Microsoft PowerPointot vagy az Office automatizálást.

**Konvertálhatok tömegesen sok prezentációt?**

Igen. Töltsön be minden prezentációt, mentse a kívánt formátumba, majd a feldolgozás után szabadítsa fel a prezentációobjektumot. Párhuzamos feldolgozáshoz használjon különálló prezentációs példányokat, és kövesse a [multithreading](/slides/hu/androidjava/multithreading/) útmutatót.

**Exportálhatok csak a kiválasztott diákat?**

Igen. Számos exportálási módszer lehetővé teszi diák indexek megadását vagy egyes diák renderelését, a kimeneti formátumtól függően. Tekintse meg a célformátumra vonatkozó dedikált cikket.

**Bele tudom-e foglalni a rejtett diákat PDF vagy XPS exportálásakor?**

Igen. Használja a rejtett-diák exportálási beállításokat a [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/) és [XPS](/slides/hu/androidjava/convert-powerpoint-to-xps/) konverziós cikkekben leírtak szerint.

**Létrehozhatok PDF/A kimenetet?**

Igen. PDF megfelelőségi beállítások állnak rendelkezésre PDF exportáláshoz. Részletekért tekintse meg a [PowerPoint konvertálása PDF‑be](/slides/hu/androidjava/convert-powerpoint-to-pdf/) cikket.

**Hogyan kezelődnek a betűtípusok a konverzió során?**

Az Aspose.Slides beágyazott betűtípusokat, betűtípus‑helyettesítést és betűtípus‑utólagos beállításokat használhat. Tekintse meg a [Embedded Font](/slides/hu/androidjava/embedded-font/), [Fallback Font](/slides/hu/androidjava/fallback-font/) és [Font Substitution](/slides/hu/androidjava/font-substitution/) cikkeket.
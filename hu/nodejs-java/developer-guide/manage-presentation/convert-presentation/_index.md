---
title: Prezentációk konvertálása több formátumba JavaScriptben
linktitle: Prezentáció konvertálása
type: docs
weight: 70
url: /hu/nodejs-java/convert-presentation/
keywords:
- prezentáció konvertálása
- prezentáció exportálása
- PPT to PPTX
- PPTX to PPT
- ODP to PPTX
- PPT to PDF
- PPTX to PDF
- ODP to PDF
- PPT to HTML
- PPTX to HTML
- ODP to HTML
- PPT to PNG
- PPTX to PNG
- ODP to PNG
- PPTX to JPG
- ODP to JPG
- PPT to XPS
- PPTX to XPS
- ODP to XPS
- PPT to TIFF
- PPTX to TIFF
- ODP to TIFF
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a PowerPoint és OpenDocument bemutatókat PPTX, PDF, HTML, képek, XPS, TIFF és egyéb formátumokra az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java betöltheti a PowerPoint és OpenDocument bemutatókat, és sok más formátumba mentheti vagy renderelheti őket a Microsoft PowerPoint, OpenOffice vagy LibreOffice nélkül. Átalakíthatja a régi PPT fájlokat modern PPTX formátumba, exportálhatja a bemutatókat rögzített elrendezésű dokumentumokba, például PDF és XPS, közzéteheti a diákot HTML-ként, vagy renderelheti a diákat képfájlokként előnézetekhez, miniatűrökhöz és archívumokhoz.

A legtöbb dokumentumkonverzió ugyanazt az általános munkafolyamatot használja: betölti a forrásfájlt, kiválasztja a kívánt kimeneti formátumot, és szükség esetén alkalmazza a formátumspecifikus beállításokat. Képfájlformátumok esetén minden diát külön renderelnek, majd raszter vagy vektor képként mentik. Az alább hivatkozott dedikált cikkek részletezik a megvalósítást minden esetben.

## **Válasszon egy konverziós szcenáriót**

Használja az alábbi cikkeket teljes JavaScript példákhoz és formátumspecifikus beállításokhoz.

| Szcenárió | Használja, ha | Cikk |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Legyen korszerű a régi PPT fájlok, normalizálja a meglévő PPTX fájlokat, vagy konvertálja az OpenDocument bemutatókat PowerPoint PPTX formátumba. | [Convert PPT to PPTX](/slides/hu/nodejs-java/convert-ppt-to-pptx/),[Convert ODP to PPTX](/slides/hu/nodejs-java/convert-odp-to-pptx/),[Save Presentations](/slides/hu/nodejs-java/save-presentation/) |
| PPTX to PPT | Mentse a modern PowerPoint bemutatót a régi bináris PPT formátumba a régebbi munkafolyamatok kompatibilitásáért. | [Convert PPTX to PPT](/slides/hu/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Hozzon létre hordozható, kereshető, rögzített elrendezésű dokumentumokat megosztáshoz, nyomtatáshoz vagy archiváláshoz. | [Convert PowerPoint to PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Exportálja a előadói jegyzeteket a diákat tartalommal együtt. | [Convert PowerPoint to PDF with Notes](/slides/hu/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Tegye közzé a bemutatókat HTML oldalként, és irányítsa a képeket, betűtípusokat, jegyzeteket és a reszponzív elrendezési beállításokat. | [Convert PowerPoint to HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Exportálja a diákat HTML5-be a böngészőben való megjelenítéshez, megőrizve a formázást és az interaktivitást. | [Convert Presentations to HTML5](/slides/hu/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Renderelje minden diát PNG képre előnézetekhez, miniatűrökhöz vagy webes kimenethez. | [Convert PowerPoint to PNG](/slides/hu/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Renderelje a diákat JPG képekké, és szabályozza a kép méretét és minőségét. | [Convert PowerPoint to JPG](/slides/hu/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Exportáljon egyedi diákat méretezhető vektoros grafikaként. | [Render Slide as SVG](/slides/hu/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Generáljon rögzített elrendezésű XPS dokumentumokat. | [Convert PowerPoint to XPS](/slides/hu/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Mentse a bemutatót több oldalas TIFF fájlként nyomtatáshoz, szkenneléshez, faxhoz vagy archiválási munkafolyamatokhoz. | [Convert PowerPoint to TIFF](/slides/hu/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Mentse a diákat előadói jegyzetekkel TIFF-be. | [Convert PowerPoint to TIFF with Notes](/slides/hu/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | Nyújtsa ki a bemutató tartalmát Markdown-be dokumentáció és szöveges munkafolyamatok céljából. | [Convert PowerPoint to Markdown](/slides/hu/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | Hozzon létre animált GIF-et a diákról. | [Convert PowerPoint to Animated GIF](/slides/hu/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Építsen videó export munkafolyamatot a bemutató diákból. | [Convert PowerPoint to Video](/slides/hu/nodejs-java/convert-powerpoint-to-video/) |
| Presentation to XAML | Exportálja a diákat XAML-be JavaScript vagy Java UI szcenáriókhoz. | [Export Presentations to XAML](/slides/hu/nodejs-java/export-to-xaml/) |

A bemeneti és kimeneti formátumok szélesebb listájáért lásd a [Supported File Formats](/slides/hu/nodejs-java/supported-file-formats/).

## **PowerPoint és OpenDocument konverzió**

Az Aspose.Slides for Node.js via Java támogatja a konverziót a gyakran használt bemutatóformátumokból, például PPT, PPTX, PPS, PPSX, POT, POTX és ODP. Ugyanazt a konverziós API-t használják a PowerPoint és OpenDocument fájlokhoz, így egy munkafolyamat, amely PPTX fájlt PDF-be ment, általában alkalmazható ODP fájlra is, csak a bemeneti fájlt kell cserélni.

ODP fájlok konvertálásakor tartsa szem előtt, hogy a PowerPoint és OpenDocument alkalmazások nem támogatják ugyanúgy minden elrendezési és formázási funkciót. Ha egy ODP fájl LibreOffice vagy OpenOffice Impress-ben készült, ellenőrizze a kimenetet, és használja a [Convert OpenDocument Presentations](/slides/hu/nodejs-java/convert-openoffice-odp/) leírt beállításokat, ha formátumspecifikus útmutatásra van szükség.

## **PPT → PPTX konverzió**

A PPT a régebbi bináris PowerPoint formátum, míg a PPTX a modern Office Open XML formátum. Az Aspose.Slides for Node.js via Java magas hűségű PPT → PPTX konverziót támogat, megőrizve a komplex bemutatóstruktúrákat, például master oldalakat, elrendezéseket, diákat, diagramokat, csoportosított alakzatokat, helyőrzőket, szövegkereteket, textúrákat és képtöltéseket.

Részletekért lásd a [Convert PPT to PPTX](/slides/hu/nodejs-java/convert-ppt-to-pptx/) és a [PPT vs PPTX](/slides/hu/nodejs-java/ppt-vs-pptx/) oldalakat.

## **Rögzített elrendezésű export**

A PDF, XPS és TIFF hasznos, ha a kimenetnek minden eszközön ugyanolyannak kell lennie, és nem szabad szerkeszteni bemutatóként. A dedikált PDF, XPS és TIFF cikkek bemutatják, hogyan szabályozható a kompatibilitás, rejtett diák, jegyzetek, képminőség, tömörítés, pixel formátum és a kimeneti méret.

## **HTML és kép export**

A HTML és HTML5 export hasznos a böngészőben történő megtekintéshez, webes közzétételhez és könnyű megosztáshoz. Kép export akkor hasznos, amikor minden diát külön előnézetként, miniatűrként vagy raszter eszközként kell kezelni. Használja a PNG, JPG és SVG cikkeket a formátumspecifikus renderelési útmutatáshoz.

## **GYIK**

**Szükségem van Microsoft PowerPoint-ra a bemutatók konvertálásához?**  
Nem. Az Aspose.Slides for Node.js via Java egy önálló könyvtár, és nem igényli a Microsoft PowerPoint vagy Office automatizálást.

**Tömegesen konvertálhatok sok bemutatót?**  
Igen. Töltse be minden bemutatót, mentse a kívánt formátumba, majd a feldolgozás után szüntesse meg a bemutató objektumot. Párhuzamos feldolgozás esetén használjon külön bemutató példányokat, és kövesse a [multithreading](/slides/hu/nodejs-java/multithreading/) útmutatót.

**Exportálhatok csak a kiválasztott diákat?**  
Igen. Számos exportálási módszer lehetővé teszi, hogy diák indexeit adja meg vagy egyes diákat rendereljen, a kimeneti formátumtól függően. Lásd a cél formátumra vonatkozó dedikált cikket.

**Bele tudom-e foglalni a rejtett diákat PDF vagy XPS exportálásakor?**  
Igen. Használja a rejtett-diák export beállításait, amelyek a [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) és [XPS](/slides/hu/nodejs-java/convert-powerpoint-to-xps/) konverziós cikkekben vannak leírva.

**Létrehozhatok PDF/A kimenetet?**  
Igen. A PDF exporthez elérhetők a PDF-kompatibilitási beállítások. Részletekért lásd a [Convert PowerPoint to PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) oldalt.

**Hogyan kezelődnek a betűtípusok a konverzió során?**  
Az Aspose.Slides használhat beágyazott betűtípusokat, betűtípus fallback-et és betűtípus helyettesítési beállításokat. Lásd a [Embedded Font](/slides/hu/nodejs-java/embedded-font/), [Fallback Font](/slides/hu/nodejs-java/fallback-font/) és a [Font Substitution](/slides/hu/nodejs-java/font-substitution/) cikkeket.
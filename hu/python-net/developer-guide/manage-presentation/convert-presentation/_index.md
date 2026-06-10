---
title: Prezentációk konvertálása több formátumba Pythonban
linktitle: Prezentációk konvertálása
type: docs
weight: 70
url: /hu/python-net/convert-presentation/
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
- Python
- Aspose.Slides
description: "Konvertálja a PowerPoint és OpenDocument prezentációkat PPTX, PDF, HTML, képek, XPS, TIFF és egyéb formátumokra az Aspose.Slides for Python via .NET használatával."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET betöltheti a PowerPoint és OpenDocument prezentációkat, és sok más formátumba mentheti vagy renderelheti őket anélkül, hogy a Microsoft PowerPoint, az OpenOffice vagy a LibreOffice szükséges lenne. Átalakíthatja a régi PPT-fájlokat a modern PPTX formátumba, exportálhatja a prezentációkat rögzített elrendezésű dokumentumokba, például PDF és XPS, közzéteheti a diákot HTML‑ként, vagy renderelheti a diákat képfájlokként előnézetekhez, miniatűrökhöz és archívumokhoz.

A legtöbb dokumentumkonverzió ugyanazt a általános munkafolyamatot használja: betölti a forrásfájlt, kiválasztja a kívánt kimeneti formátumot, és szükség esetén alkalmazza a formátumspecifikus beállításokat. Képek esetén minden diát külön renderelnek, majd raszter vagy vektor képként mentik el. Az alább megadott dedikált cikkek részletes megvalósítási információkat nyújtanak az egyes esetekhez.

## **Válasszon egy konverziós forgatókönyvet**

Használja az alábbi cikkeket a teljes Python példákhoz és a formátumspecifikus beállításokhoz.

| Forgatókönyv | Akkor használja, ha | Cikk |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Régi PPT-fájlok modernizálása, meglévő PPTX fájlok normalizálása, vagy OpenDocument prezentációk PowerPoint PPTX formátumba konvertálása. | [Convert PPT to PPTX](/slides/hu/python-net/convert-ppt-to-pptx/),[Convert ODP to PPTX](/slides/hu/python-net/convert-odp-to-pptx/),[Save Presentations](/slides/hu/python-net/save-presentation/) |
| PPTX to PPT | Modern PowerPoint prezentáció mentése a régebbi bináris PPT formátumba a régi munkafolyamatok kompatibilitása érdekében. | [Convert PPTX to PPT](/slides/hu/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Hordozható, kereshető, rögzített elrendezésű dokumentumok létrehozása megosztáshoz, nyomtatáshoz vagy archiváláshoz. | [Convert PowerPoint to PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Előadói jegyzetek exportálása a diák tartalmával együtt. | [Convert PowerPoint to PDF with Notes](/slides/hu/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Prezentációk közzététele HTML oldalakon, képek, betűtípusok, jegyzetek és responzív elrendezés beállítása. | [Convert PowerPoint to HTML](/slides/hu/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Dia exportálása HTML5-be böngészőben való megtekintéshez, megőrizve a formázást és az interaktivitást. | [Convert Presentations to HTML5](/slides/hu/python-net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Minden dia renderelése PNG képre előnézetekhez, miniatűrökhöz vagy webes kimenethez. | [Convert PowerPoint to PNG](/slides/hu/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Diák renderelése JPG képekre, a kép méretek és minőség szabályozásával. | [Convert PowerPoint to JPG](/slides/hu/python-net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Egyedi diák exportálása méretezhető vektorgrafikaként. | [Render Slide as SVG](/slides/hu/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Rögzített elrendezésű XPS dokumentumok generálása. | [Convert PowerPoint to XPS](/slides/hu/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Prezentáció mentése többlapos TIFF fájlba nyomtatás, szkennelés, fax vagy archiválási munkafolyamatokhoz. | [Convert PowerPoint to TIFF](/slides/hu/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Diák mentése előadói jegyzetekkel TIFF-be. | [Convert PowerPoint to TIFF with Notes](/slides/hu/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP to Word | Diák konvertálása Word dokumentummá, ha dokumentumstílusú kimenetre van szükség. | [Convert PowerPoint to Word](/slides/hu/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP to Markdown | Prezentáció tartalmának kinyerése Markdown-be dokumentációhoz és szövegalapú munkafolyamatokhoz. | [Convert PowerPoint to Markdown](/slides/hu/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to animated GIF | Animált GIF létrehozása a diákból. | [Convert PowerPoint to Animated GIF](/slides/hu/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP to video | Videó exportálási munkafolyamat felépítése a prezentáció diákból. | [Convert PowerPoint to Video](/slides/hu/python-net/convert-powerpoint-to-video/) |
| Presentation to XAML | Diák exportálása XAML-be Python vagy .NET UI forgatókönyvekhez. | [Export Presentations to XAML](/slides/hu/python-net/export-to-xaml/) |

A bemeneti és kimeneti formátumok szélesebb listájáért lásd a [Supported File Formats](/slides/hu/python-net/supported-file-formats/) cikket.

## **PowerPoint és OpenDocument konverzió**

Az Aspose.Slides for Python via .NET támogatja a gyakran használt prezentációs formátumok, például PPT, PPTX, PPS, PPSX, POT, POTX és ODP konverzióját. Ugyanazt a konverziós API-t használják a PowerPoint és az OpenDocument fájlok esetén, ezért egy PPTX fájl PDF-be mentésére szolgáló munkafolyamat általában alkalmazható ODP fájlra is, ha csak a bemeneti fájlt cserélik.

ODP fájlok konvertálásakor tartsa szem előtt, hogy a PowerPoint és az OpenDocument alkalmazások nem támogatják minden elrendezési és formázási funkciót pontosan ugyanúgy. Ha egy ODP fájlt LibreOffice vagy OpenOffice Impress segítségével hoztak létre, ellenőrizze a kimenetet, és a [Convert OpenDocument Presentations](/slides/hu/python-net/convert-openoffice-odp/) cikkben leírt beállításokat használja, ha formátumspecifikus útmutatásra van szükség.

## **PPT‑t PPTX‑re konvertálás**

A PPT a régebbi bináris PowerPoint formátum, míg a PPTX a modern Office Open XML formátum. Az Aspose.Slides for Python via .NET magas hűségű PPT‑t PPTX‑re konvertálást támogat, miközben megőrzi a komplex prezentációs struktúrákat, például a master‑eket, elrendezéseket, diákat, diagramokat, csoportosított alakzatokat, helyettesítőket, szövegkereteket, textúrákat és képtöltéseket.

Részletekért lásd a [Convert PPT to PPTX](/slides/hu/python-net/convert-ppt-to-pptx/) és a [PPT vs PPTX](/slides/hu/python-net/ppt-vs-pptx/) cikket.

## **Rögzített elrendezésű export**

A PDF, XPS és TIFF hasznos, ha a kimenetnek minden eszközön azonosnak kell lennie, és nem szabad prezentációként szerkeszteni. A dedikált PDF, XPS és TIFF cikkek bemutatják, hogyan kell szabályozni a megfelelőséget, a rejtett diákat, a jegyzeteket, a képminőséget, a tömörítést, a pixel formátumot és a kimeneti méretet.

## **HTML és kép export**

A HTML és HTML5 exportálás hasznos a böngészőben való megtekintéshez, webes közzétételhez és könnyű megosztáshoz. A kép exportálás akkor hasznos, ha minden diáknak külön előnézetnek, miniatűrnek vagy raszteres eszköznek kell lennie. Használja a PNG, JPG és SVG cikkeket a formátumspecifikus renderelési útmutatáshoz.

## **GYIK**

**Szükségem van a Microsoft PowerPoint‑ra a prezentációk konvertálásához?**

Nem. Az Aspose.Slides for Python via .NET egy önálló könyvtár, és nem igényli a Microsoft PowerPoint vagy Office automatizálását.

**Készíthetek kötegelt konverziót sok prezentációval?**

Igen. Töltse be minden prezentációt, mentse a kívánt formátumba, és a feldolgozás után szabadítsa fel a prezentáció objektumot. Párhuzamos feldolgozáshoz használjon különálló prezentációs példányokat, és kövesse a [multithreading](/slides/hu/python-net/multithreading/) útmutatót.

**Exportálhatok csak kiválasztott diákat?**

Igen. Több exportálási módszer lehetővé teszi diák indexének megadását vagy egyedi diák renderelését a kimeneti formátumtól függően. Lásd a dedikált cikket a célformátumhoz.

**Belefoglalhatom a rejtett diákot PDF vagy XPS exportálásakor?**

Igen. Használja a [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/) és [XPS](/slides/hu/python-net/convert-powerpoint-to-xps/) konverziós cikkekben leírt rejtett diák exportálási beállításait.

**Készíthetek PDF/A kimenetet?**

Igen. PDF megfelelőségi beállítások elérhetők a PDF exportáláshoz. Részletekért lásd a [Convert PowerPoint to PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/) cikket.

**Hogyan kezelődnek a betűtípusok a konverzió során?**

Az Aspose.Slides használhat beágyazott betűtípusokat, betűtípus visszaesést és betűtípus helyettesítést. Lásd a [Embedded Font](/slides/hu/python-net/embedded-font/), [Fallback Font](/slides/hu/python-net/fallback-font/) és [Font Substitution](/slides/hu/python-net/font-substitution/) cikkeket.
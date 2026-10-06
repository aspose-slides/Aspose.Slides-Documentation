---
title: Funkciók áttekintése
type: docs
weight: 104
url: /hu/java/features-overview/
keywords:
- funkciók
- támogatott platformok
- fájlformátumok
- konverzió
- renderelés
- prezentáció tartalma
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át, hogy az Aspose.Slides for Java milyen területeket lefed, mielőtt értékelné: támogatott platformok, fájlformátumok, dia renderelése és a létrehozható illetve szerkeszthető tartalom."
---
## **Áttekintés**

Aspose.Slides for Java egy osztálykönyvtár PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez, konvertálásához és megjelenítéséhez. Nem rendelkezik saját felhasználói felülettel, és nem igényli a Microsoft PowerPoint vagy a Microsoft Office programokat. Ez a cikk összefoglalja, hogy a könyvtár milyen területeket fed le, és hivatkozásokat tartalmaz az egyes témákat részletező cikkekre.

## **Támogatott platformok**

Aspose.Slides for Java egyetlen JAR fájl, amely az Aspose Maven tárolójában a `jdk16` osztályozóval jelenik meg. Tiszta Java nyelven íródott: a JAR nem tartalmaz natív könyvtárakat, és nem függ más csomagoktól.

- **Java:** Java 8 vagy újabb. Az Aspose.Slides for Java 26.9‑es és korábbi verziói Java 6‑on és 7‑en is futnak, amelyet a 26.10‑es verzió már nem támogat; lásd a [26.9 release notes](/slides/hu/java/release-notes/2026/aspose-slides-for-java-26-9-release-notes/).
- **Operációs rendszerek:** bármely operációs rendszer, amely Java futtatókörnyezetet biztosít, például Windows, Linux és macOS. Linuxon a fontconfig könyvtárnak és legalább egy betűtípusnak telepítve kell lennie.

[Installation](/slides/hu/java/installation/) bemutatja, hogyan adható hozzá a könyvtár egy projekthez, és felsorolja a Linux előfeltételeket. [System Requirements](/slides/hu/java/system-requirements/) részletesen listázza a támogatott platformokat.

## **Fájlformátumok és konverziók**

Az Aspose.Slides megnyitja és menti a PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP és PowerPoint XML prezentációkat. PDF és HTML tartalmat importál diákba, és a prezentációkat PDF, XPS, HTML, HTML5, TIFF, animált GIF, SWF, Markdown és XAML formátumban menti. [Supported File Formats](/slides/hu/java/supported-file-formats/) felsorolja az összes formátumot és a hozzájuk tartozó olvasó‑/író API‑t.

|**Funkció**|**Leírás**|
| :- | :- |
|[PPT és PPTX](/slides/hu/java/ppt-vs-pptx/)|Binaris PowerPoint 97‑2003 és az Office Open XML formátum egyaránt olvasható és írható.|
|[PPT‑ról PPTX‑re konvertálás](/slides/hu/java/convert-ppt-to-pptx/)|Régi PPT prezentációk PPTX‑re konvertálása.|
|[ODP‑ról PPTX‑re konvertálás](/slides/hu/java/convert-odp-to-pptx/)|ODP, OTP és FODP prezentációk megnyitása és mentése, valamint ODP‑k PPTX‑re konvertálása.|
|[Portable Document Format (PDF)](/slides/hu/java/convert-powerpoint-to-pdf/)|Prezentációk exportálása PDF‑be, beleértve a PDF/A és PDF/UA dokumentumokat.|
|[XML Paper Specification (XPS)](/slides/hu/java/convert-powerpoint-to-xps/)|Prezentációk exportálása XPS dokumentumokba.|
|[Tagged Image File Format (TIFF)](/slides/hu/java/convert-powerpoint-to-tiff/)|Prezentációk exportálása többoldalas TIFF képekbe, egy oldal diánként.|
|[HTML](/slides/hu/java/convert-powerpoint-to-html/)|Prezentációk exportálása HTML‑be és HTML5‑be.|
|[PDF és HTML import](/slides/hu/java/import-presentation/)|Diák létrehozása PDF‑oldalakból és HTML tartalomból.|

## **Prezentáció renderelése**

Az Aspose.Slides a diák és az egyedi alakzatok PNG, JPEG, BMP, GIF, TIFF és SVG képekként, valamint a diákat EMF metafájlokként jeleníti meg. Lásd a [Convert Presentation Slides to Images](/slides/hu/java/convert-slide/), a [Render Presentation Slides as SVG Images](/slides/hu/java/render-a-slide-as-an-svg-image/) és a [Create Thumbnails of Presentation Shapes](/slides/hu/java/create-shape-thumbnails/) útmutatókat.

## **Tartalom funkciói**

Az Aspose.Slides lehetővé teszi a prezentáció szinte minden tartalmának létrehozását, olvasását és módosítását:

|**Terület**|**Mit tehetsz**|
| :- | :- |
|[Slides](/slides/hu/java/presentation-slide/)|Diák hozzáadása, klónozása, átrendezése és eltávolítása; elrendezések és mesterek alkalmazása; diák szekciókba szervezése; diaméret módosítása.|
|[Design](/slides/hu/java/presentation-design/)|Háttér, témaszínek, fejléc és lábléc, valamint betűtípusok beállítása.|
|[Text](/slides/hu/java/manage-text/)|Szövegdobozok, bekezdések és szakaszok létrehozása és szerkesztése; betűtípusok, színek, felsorolások és igazítás beállítása; keresés és csere.|
|[Shapes](/slides/hu/java/powerpoint-shapes/)|AutoShape‑ok, vonalak, csatlakozók, alakzatcsoportok és képkockák létrehozása; pozíció, méret, vonal és egyszínű, fokozatos vagy mintás kitöltés beállítása; alakzat keresése alternatív szöveg alapján.|
|[Tables](/slides/hu/java/powerpoint-table/), [charts](/slides/hu/java/powerpoint-charts/), and [SmartArt](/slides/hu/java/powerpoint-smartart/)|Táblák, Microsoft Office diagramok és SmartArt diagramok létrehozása és szerkesztése.|
|[Media](/slides/hu/java/manage-media-files/), [OLE objects](/slides/hu/java/manage-ole/), and [ActiveX controls](/slides/hu/java/activex/)|Beágyazott vagy hivatkozott audio‑ és videókockák hozzáadása, OLE objektumok beágyazása, valamint ActiveX vezérlők hozzáadása, módosítása vagy eltávolítása.|
|[Notes](/slides/hu/java/presentation-notes/) and [comments](/slides/hu/java/presentation-comments/)|Előadói jegyzetek és felülvizsgálati megjegyzések hozzáadása, olvasása és szerkesztése.|
|[Animation](/slides/hu/java/powerpoint-animation/) and [transitions](/slides/hu/java/slide-transition/)|Animációs effektusok alkalmazása alakzatokra, diaátmenetek beállítása és diavetítés‑beállítások konfigurálása.|
|[Security](/slides/hu/java/presentation-security/)|Prezentációk jelszóval történő titkosítása, írásvédettség beállítása, valamint [digital signatures](/slides/hu/java/digital-signature-in-powerpoint/) kezelése.|
|[VBA macros](/slides/hu/java/presentation-via-vba/)|VBA modulok hozzáadása, kinyerése és eltávolítása makró‑engedélyezett prezentációkban.|
|[Properties](/slides/hu/java/presentation-properties/)|Dokumentumtulajdonságok olvasása és szerkesztése.|

## **GYIK**

**Szükséges-e a Microsoft PowerPoint telepítése a szerveren vagy a gépen a könyvtár működéséhez?**

Nem. A PowerPoint nem kötelező; az Aspose.Slides egy önálló motor a prezentációk létrehozásához, szerkesztéséhez, konvertálásához és megjelenítéséhez.

**Hogyan működik a többthreades feldolgozás? Párhuzamosítható a feldolgozás?**

Biztonságos különböző dokumentumok külön szálakon való feldolgozása; ugyanazt a [Presentation](/slides/hu/java/multithreading/) objektumot nem szabad [multiple threads](/slides/hu/java/multithreading/) egy időben használni.

**Támogatottak-e a fájl jelszavak és a titkosítás?**

Igen. [You can](/slides/hu/java/password-protected-presentation/) megnyitni titkosított prezentációkat, beállítani vagy eltávolítani megnyitási és írási jelszót, valamint ellenőrizni a védelem állapotát.

**Gondoskodni kell a betűtípusokról Linux konténerekben?**

Igen. Linuxon a fontconfig könyvtárnak és legalább egy betűtípusnak telepítve kell lennie, valamint a prezentációkban használt betűtípusoknak vagy megfelelő helyettesítőknek is elérhetőknek kell lenniük a helyes megjelenítéshez. A [specify font directories](/slides/hu/java/custom-font/) is beállítható az alkalmazásban. Lásd a [Installation](/slides/hu/java/installation/#linux) részt.

**Vannak-e korlátozások az értékelő verzióban?**

Igen. Licenc [license](/slides/hu/java/licensing/) hiányában az Aspose.Slides minden mentett diára értékelő vízjelet helyez, és levágja a kódból kiolvasott szöveget. Egy [30‑napos ideiglenes licenc](https://purchase.aspose.com/temporary-license/) elérhető a teljes funkcionalitás teszteléséhez.

**Támogatott-e külső formátumok (PDF vagy HTML) importálása prezentációba (PPTX‑be)?**

Igen. PDF‑oldalakat és HTML‑tartalmat [PDF pages and HTML content](/slides/hu/java/import-presentation/) adhat a prezentációhoz, amely diákká alakul.
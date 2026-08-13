---
title: Miért nem az Open XML SDK
type: docs
weight: 120
url: /hu/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- összehasonlítás
- prezentációs objektummodell
- magas minőségű konverzió
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Lásd, miért jobb választás az Aspose.Slides, mint az ingyenes Open XML SDK: hasonlítsd össze a funkciókat, az automatizálás nélküli konverziót, és a PPT, PPTX és ODP széleskörű támogatását."
---
## **Áttekintés**

Ez a cikk azt magyarázza, hogy a fejlesztők mikor választhatják az Open XML SDK-t vagy az Aspose.Slides-t prezentációs dokumentumok kezelésére. Leírja az Open XML SDK-t, mint OOXML csomagok és azok alatta lévő XML elemek manipulálására szolgáló könyvtárat, míg az Aspose.Slides egy prezentációfeldolgozó könyvtárként jelenik meg, magas szintű objektummodellel és számos PowerPoint-hez kapcsolódó feladat támogatásával.

A cikk összehasonlítja a két lehetőséget a támogatott formátumok, a programozási modell, a renderelési és nyomtatási képességek, a platformtámogatás és a gyakori felhasználási esetek alapján. Az is tisztázza, hogy az Open XML SDK alkalmas lehet alapvető PPTX műveletekre vagy az OOXML elemek közvetlen elérésére, míg az Aspose.Slides inkább összetett prezentációs feladatokhoz megfelelő, például több PowerPoint formátummal való munka, alakzatok másolása vagy klónozása, szöveg cseréje, animációk alkalmazása, valamint a prezentációk PDF, TIFF vagy XPS formátumba konvertálása.

## **Mi az Open XML SDK?**

A [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) szerint az Open XML SDK a következőképpen van definiálva:

Az Open XML SDK 2.0 egyszerűsíti az Open XML csomagok és egy csomagon belüli alatta lévő Open XML sémaelemek manipulálásának feladatát. Az Open XML SDK 2.0 számos gyakori feladatot kapszuláz, amelyet a fejlesztők az Open XML csomagokon hajtanak végre, így csak néhány kódsorral végezhetnek komplex műveleteket.

Az OOXML dokumentumok lényegében tömörített XML fájlok, és az Open XML SDK egy osztálykészlet, amely lehetővé teszi, hogy erősen típusos módon dolgozzon az OOXML dokumentumok tartalmával. Ez azt jelenti, hogy a fájl kicsomagolása és az XML kinyerése, az XML DOM-fákká betöltése és az XML elemekkel és attribútumokkal való közvetlen munka helyett az Open XML SDK osztályokat biztosít ehhez.

## **Mi az Aspose.Slides?**

Aspose.Slides egy osztálykönyvtár, amely lehetővé teszi az alkalmazás számára a következő prezentációfeldolgozási feladatok végrehajtását:

- Programozás egy **Presentation** objektummodellel.
- Magas minőségű konverziók az összes népszerű támogatott PowerPoint prezentációs formátum között, beleértve a konvertálást PDF, XPS és TIFF formátumokba.
- Képesség diakicsinyítők (slide thumbnails) generálására jól ismert formátumokban, mint a PNG, JPEG és BMP, valamint a diák exportálása SVG formátumba.
- Képesség prezentációk létrehozására alapoktól vagy egy vagy több dokumentum kombinálásával.
- Támogatás animációk, Ole keretek, táblák hozzáadásához, diagramok létrehozásához és kezeléséhez.
- Kiterjedt vezérlés elérhetősége a szövegformázás kezeléséhez TextFrames, Paragraphs és Portions szinteken.

További részletekért a támogatott funkciókról, kérjük, látogassa meg a [Aspose.Slides funkciói](/slides/hu/java/product-overview/) oldalt.

## **Open XML SDK összehasonlítása az Aspose.Slides-sel**
{{% alert color="info" %}} 
Az alábbi táblázat összehasonlítja az Open XML SDK és az Aspose.Slides funkcióit.
{{% /alert %}} 

|**Funkció vagy Funkciókategória**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Támogatott prezentációformátumok|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertálás PPT-ről PPTX-re|Nem|Igen|
|<p>Magas szintű programozás egy Presentation Document Object Model (DOM) használatával:</p><p>- Szöveg keresése és cseréje.</p><p>- Diák összeállítása prezentációkban.</p>|Nem|Igen|
|Részletes programozás egy dokumentumobjektum-modell segítségével, egyedi elemekhez és formázáshoz való hozzáférés, például TextHolders, TextFrames, Paragraphs és Portions.|Igen|Igen|
|Alacsony szintű közvetlen és teljes hozzáférés az alatta lévő XML elemekhez és attribútumokhoz, mint például a kapcsolati azonosítók, egy OOXML dokumentum listanévazonosítói.|Igen|Nem|
|<p>Renderelés:</p><p>- Prezentációk renderelése PDF, PDF Notes, XPS, TIFF képekre.</p><p>- Diakicsinyítők renderelése PNG, JPEG, BMP, SVG és TIFF formátumokba.</p><p>- Kép felbontásának, minőségének, tömörítésének és egyéb beállításainak megadása.</p>|Nem|Igen|
|Támogatott platformok|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Összegzés**
{{% alert color="info" %}} 

Az Open XML SDK és az Aspose.Slides nem versenyeznek közvetlenül, mivel teljesen eltérő igényeket és célközönségeket szolgálnak ki. Az Open XML SDK egy osztálykönyvtár, amely erősen típusos módot biztosít az OOXML dokumentumok kezelésére. Az Aspose.Slides egy nagyon hasznos prezentációfeldolgozó könyvtár, amely kiváló támogatást nyújt szinte minden Microsoft PowerPoint fájlformátumhoz.

Ha csak egy meglehetősen egyszerű programozási műveletet kell végrehajtani egy PPTX dokumentumon, akkor az Open XML SDK megfelelő választás lehet. Az Open XML SDK-val kényelmesen elvégezhető egyszerű feladatok, mint egy egyszerű PPTX dokumentum generálása vagy megjegyzések, fejléc/lábléc eltávolítása, képek kinyerése vagy egyéb műveletek. Néhány feladat megvalósítható az Open XML SDK-val, de nem valósítható meg az Aspose.Slides-szel. Például, ha közvetlenül hozzá kell férnie egy OOXML dokumentum XML elemeihez és attribútumaihoz, akkor az Open XML SDK-t kell használni. Azonban, ha összetett műveleteket kell végrehajtani dokumentumokon, mint az alábbi feladatok, akkor az Aspose.Slides a legjobb lehetőség:

- Régebbi PowerPoint formátumok támogatása a PPTX mellett.
- Alakzatok másolása vagy klónozása a diákon olyan módon, amely kombinálja az objektumokat, stílusokat és egyéb formázásokat megfelelően.
- Formázott vagy nem formázott szöveg cseréje.
- Animációk alkalmazása és a alakzatok közötti csatlakozók használata.
- Dokumentum konvertálása PDF, TIFF vagy XPS formátumba, hogy pontosan úgy jelenjen meg, mint a Microsoft PowerPoint konvertálta volna.
- .NET vagy Java alkalmazás fejlesztése mind asztali, mind webes környezetben.

{{% /alert %}}
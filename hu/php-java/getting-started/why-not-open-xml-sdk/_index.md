---
title: Miért ne használja az Open XML SDK-t
type: docs
weight: 120
url: /hu/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- összehasonlítás
- prezentációs objektummodell
- magas minőségű konverzió
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Lásd, miért jobb választás az Aspose.Slides, mint az ingyenes Open XML SDK: hasonlítsd össze a funkciókat, az automatizálás nélküli konvertálást és a PPT, PPTX és ODP széles körű támogatását."
---
## **Áttekintés**

Ez a cikk leírja, hogy a fejlesztők mikor választhatják az Open XML SDK‑t vagy az Aspose.Slides‑t prezentációs dokumentumok kezelésére. Bemutatja az Open XML SDK‑t, mint egy könyvtárat az OOXML csomagok és az azok mögötti XML elemek manipulálására, míg az Aspose.Slides egy prezentációfeldolgozó könyvtárként magas szintű objektummodellt és sok PowerPoint‑hez kapcsolódó feladat támogatását kínálja.

A cikk összehasonlítja a két megoldást a támogatott formátumok, programozási modell, renderelés, platformtámogatás és gyakori felhasználási esetek szerint. Világossá teszi, hogy az Open XML SDK alkalmas lehet alapvető PPTX műveletekre vagy az OOXML elemek közvetlen elérésére, míg az Aspose.Slides inkább összetett prezentációs feladatokra, például több PowerPoint formátum kezelésére, alakzatok másolására vagy klónozására, szöveg cseréjére, animációk alkalmazására és a prezentációk PDF, TIFF vagy XPS formátumba való konvertálására.

## **Mi az Open XML SDK?**
Az [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) szerint az Open XML SDK a következőképpen definiálható:

Az Open XML SDK 2.0 megkönnyíti az Open XML csomagok és a csomagon belüli Open XML sémaelemek manipulálását. Az Open XML SDK 2.0 sok gyakori feladatot összegzett, amelyet a fejlesztők az Open XML csomagokon végeznek, így összetett műveleteket csak néhány kódsorral hajthat végre.

Az OOXML dokumentumok lényegében tömörített XML fájlok, és az Open XML SDK egy osztálygyűjtemény, amely lehetővé teszi az OOXML dokumentumok tartalmának erősen típusos módon történő kezelését. Ez azt jelenti, hogy a fájl kibontása, az XML kinyerése, annak DOM‑fába betöltése és az XML elemekkel, attribútumokkal való közvetlen munka helyett az Open XML SDK osztályokat biztosít ehhez.

## **Mi az Aspose.Slides?**
Az Aspose.Slides egy osztálykönyvtár, amely lehetővé teszi az alkalmazásának a következő prezentációfeldolgozó feladatok elvégzését:

- Programozás **Presentation** objektummodell segítségével.
- Kiváló minőségű konverziók minden népszerű támogatott PowerPoint‑prezentációs formátum között, többek között PDF, XPS és TIFF formátumba.
- Diakép‑bélyegképek generálása jól ismert formátumokban, például PNG, JPEG és BMP, valamint diák exportálása SVG‑be.
- Prezentációk felépítése a semmiből vagy egy vagy több dokumentum egyesítésével.
- Animációk, OLE‑keretek, táblázatok hozzáadása, diagramok létrehozása és kezelése.
- Kiterjedt vezérlés a szövegformázás kezeléséhez TextFrames, Paragraphs és Portions szinten.

A támogatott funkciókról részletesebb információkért látogasson el a [Aspose.Slides Features](/slides/hu/php-java/product-overview/) oldalra.

## **Az Open XML SDK és az Aspose.Slides összehasonlítása**
{{% alert color="info" %}} 

Az alábbi táblázat hasonlítja össze az Open XML SDK és az Aspose.Slides funkcióit.

{{% /alert %}} 

|**Funkció vagy Funkciókategória**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Támogatott prezentációs formátumok|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertálás PPT‑ből PPTX‑be|Nem|Igen|
|<p>Magas szintű programozás Presentation Document Object Model (DOM) segítségével:</p><p>- Szöveg keresése és cseréje.</p><p>- Diák összeállítása a prezentációkban.</p>|Nem|Igen|
|Részletes programozás dokumentumobjektum-modelllel, hozzáférés egyedi elemekhez és formázáshoz, például TextHolders, TextFrames, Paragraphs és Portions.|Igen|Igen|
|Alacsony szintű, közvetlen és teljes hozzáférés a háttér‑XML elemekhez és attribútumokhoz, például kapcsolati azonosítók, listaazonosítók egy OOXML dokumentumban.|Igen|Nem|
|<p>Renderelés:</p><p>- Prezentációk renderelése PDF, PDF Notes, XPS, TIFF képekbe.</p><p>- Diabélyegképek renderelése PNG, JPEG, BMP, SVG és TIFF formátumba.</p><p>- Kép felbontás, minőség, tömörítés és egyéb beállítások megadása.</p>|Nem|Igen|
|Támogatott platformok|Windows, .NET|Windows, Linux, UNIX, MAC, Java, PHP, Mono|

## **Következtetés**
{{% alert color="info" %}} 

Az Open XML SDK és az Aspose.Slides nem versenyeznek közvetlenül, mivel eltérő igényeket és célcsoportokat céloznak meg. Az Open XML SDK egy osztálykönyvtár, amely erősen típusos módon teszi lehetővé az OOXML dokumentumok kezelését. Az Aspose.Slides egy nagyon hasznos prezentációfeldolgozó könyvtár, amely szinte minden Microsoft PowerPoint fájlformátumot támogat.

Ha csak egy meglehetősen egyszerű programozási műveletet kell végrehajtania egy PPTX dokumentumon, akkor az Open XML SDK megfelelő választás lehet. Az Open XML SDK-val könnyedén végezhet egyszerű feladatokat, például egy egyszerű PPTX dokumentum generálását, megjegyzések, fejléc/lábléc eltávolítását, képek kicsomagolását vagy egyéb műveleteket. Bizonyos feladatok elvégezhetők az Open XML SDK‑val, de nem az Aspose.Slides‑szel. Például ha közvetlenül kell hozzáférnie egy OOXML dokumentum XML elemeihez és attribútumaihoz, akkor az Open XML SDK‑t kell használnia. Ha azonban összetett műveleteket kell végrehajtania a dokumentumokon, mint például a következő feladatok, akkor az Aspose.Slides a legjobb választás:

- Régebbi PowerPoint formátumok támogatása a PPTX mellett.
- Alakzatok másolása vagy klónozása diákon belül úgy, hogy kombinálja az objektumokat, stílusokat és egyéb formázásokat megfelelő módon.
- Formázott vagy nem formázott szöveg cseréje.
- Animációk alkalmazása és kapcsolók használata alakzatokhoz.
- Dokumentum konvertálása PDF, TIFF vagy XPS formátumba, hogy pontosan úgy nézzen ki, ahogy a Microsoft PowerPoint konvertálna.
- .NET vagy Java alkalmazás fejlesztése asztali és web‑alapú környezetben.

{{% /alert %}}
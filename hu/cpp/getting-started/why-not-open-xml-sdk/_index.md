---
title: Miért ne Open XML SDK
type: docs
weight: 100
url: /hu/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- összehasonlítás
- prezentációs objektummodell
- magas minőségű konverzió
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Lásd, miért jobb választás az Aspose.Slides, mint az ingyenes Open XML SDK: hasonlítsd össze a funkciókat, az automatizálás nélküli konverziót, és a PPT, PPTX és ODP széleskörű támogatását."
---
## **Áttekintés**

Ez a cikk azt magyarázza, hogy a fejlesztők mikor választhatják az Open XML SDK vagy az Aspose.Slides használatát prezentációs dokumentumok kezelésére. Leírja az Open XML SDK-t, mint egy könyvtárat az OOXML csomagok és az alatta lévő XML elemek manipulálására, míg az Aspose.Slides-t, mint egy prezentációfeldolgozó könyvtárat magas szintű objektummodellel és számos PowerPoint‑hez kapcsolódó feladatra való támogatással.

A cikk összehasonlítja a két lehetőséget a támogatott formátumok, a programozási modell, a renderelés, a platformtámogatás és a tipikus felhasználási esetek alapján. Továbbá tisztázza, hogy az Open XML SDK alkalmas lehet egyszerű PPTX műveletekre vagy közvetlen hozzáférésre az OOXML elemekhez, míg az Aspose.Slides inkább összetett prezentációs feladatokhoz, például több PowerPoint formátummal való munka, alakzatok másolása vagy klónozása, szöveg helyettesítése, animációk alkalmazása és a prezentációk PDF, TIFF vagy XPS formátumba konvertálása esetén.

## **Mi az Open XML SDK?**
Néha felmerül a kérdés: Miért használjunk Aspose termékeket a szabad Open XML SDK helyett? Erre a kérdésre egyszerű a válasz: funkciók és lehetőségek. A[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) szerint az Open XML SDK úgy van definiálva, hogy: Az Open XML SDK 2.0 egyszerűsíti az Open XML csomagok és a csomagon belüli Open XML sémaelemek manipulálását. Az Open XML SDK 2.0 sok általános feladatot kapszuláz, amelyet a fejlesztők az Open XML csomagokon végeznek, lehetővé téve komplex műveletek elvégzését néhány kódsorral. Az OOXML dokumentumok lényegében tömörített XML fájlok, és az Open XML SDK osztályok gyűjteménye, amely lehetővé teszi az OOXML dokumentumok tartalmának erősen típusos módon történő kezelését. Ez azt jelenti, hogy a fájl kicsomagolása XML kinyerése, az XML betöltése DOM fába és az XML elemekkel és attribútumokkal való közvetlen munka helyett az Open XML SDK osztályok biztosítják ezt a funkciót.

## **Mi az Aspose.Slides?**
Az Aspose.Slides egy osztálykönyvtár, amely lehetővé teszi az alkalmazásod számára a következő prezentációfeldolgozó feladatok elvégzését:

- Programozás egy **Presentation** objektummodellel.
- Magas minőségű konverziók minden népszerű támogatott PowerPoint prezentációformátum között, beleértve a PDF és XPS formátumba konvertálást.
- Képes diák előnézeti képeinek generálása jól ismert formátumokban, mint PNG, JPEG és BMP, valamint diák exportálása SVG-be.
- Képes prezentációk építésére a semmiből vagy egy vagy több dokumentum kombinálásával.
- Támogatás animációk, Ole Frame-ek, táblázatok hozzáadásához, valamint diagramok létrehozásához és kezeléséhez.
- Kiterjedt vezérlés a szövegformázás kezelése érdekében TextFrames, Paragraphs és Portions szinten.
  További részletekért a támogatott funkciókról látogasd meg a [Aspose.Slides Features](/slides/hu/cpp/product-overview/).

## **Open XML SDK és Aspose.Slides összehasonlítása**
Az alábbi táblázat összehasonlítja az Open XML SDK és az Aspose.Slides funkcióit.

|**Funkció vagy Funkciókategória**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Támogatott prezentációformátumok|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Átalakítás PPT‑ből PPTX‑be|Nem|Igen|
|<p>Magas szintű programozás Presentation Document Object Model (DOM) használatával:</p><p>- Szöveg keresése és helyettesítése.</p><p>- Diák összeállítása prezentációkban.</p>|Nem|Igen|
|Részletes programozás dokumentumobjektum-modell segítségével, egyedi elemekhez és formázáshoz való hozzáférés, például TextHolders, TextFrames, Paragraphs és Portions.|Igen|Igen|
|Alacsony szintű közvetlen és teljes hozzáférés az alaprendszer XML elemeihez és attribútumaihoz, például a kapcsolati azonosítókhoz, egy OOXML dokumentum listaazonosítóihoz.|Igen|Nem|
|<p>Renderelés:</p><p>- Prezentációk renderelése PDF, PDF Notes, XPS, TIFF képekre.</p><p>- Diakép előnézetek renderelése PNG, JPEG, BMP, SVG és TIFF formátumba.</p><p>- Kép felbontásának, minőségének, tömörítésének és egyéb beállításainak meghatározása.</p>|Nem|Igen|

## **Következtetés**
Az Open XML SDK és az Aspose.Slides nem versenyeznek közvetlenül, mert nagyon eltérő igényeket és célközönséget szolgálnak ki. Az Open XML SDK egy osztálykönyvtár, amely erősen típusos módon teszi lehetővé az OOXML dokumentumok kezelését. Az Aspose.Slides egy rendkívül hasznos prezentációfeldolgozó könyvtár, amely nagyszerű támogatást nyújt szinte minden Microsoft PowerPoint fájlformátumhoz. Ha csak egy meglehetősen egyszerű programozási műveletre van szükséged egy PPTX dokumentumban, akkor az Open XML SDK megfelelő választás lehet. Az Open XML SDK-val kényelmesen meg tudsz valósítani egyszerű feladatokat, például egy egyszerű PPTX dokumentum létrehozását vagy megjegyzések, fejléc/lábléc eltávolítását, képek kinyerését vagy hasonlókat. Bizonyos feladatok megvalósíthatók az Open XML SDK-val, de nem valósíthatók meg az Aspose.Slides-szel. Például ha közvetlenül kell hozzáférned egy OOXML dokumentum XML elemeihez és attribútumaihoz, akkor az Open XML SDK-t kell használnod. Ha azonban komplex műveleteket kell végrehajtanod a dokumentumokon, mint például az alábbi feladatok, akkor az Aspose.Slides a legjobb választás:

- Régebbi PowerPoint formátumok támogatása a PPTX mellett.
- Alakzatok másolása vagy klónozása diákon belül oly módon, hogy kombinálja az objektumokat, stílusokat és egyéb formázásokat megfelelően.
- Formázott vagy nem formázott szöveg helyettesítése.
- Animációk alkalmazása és összekötők használata alakzatokkal.
- Dokumentum konvertálása PDF‑be vagy XPS‑be úgy, hogy pontosan úgy jelenjen meg, mint a Microsoft PowerPoint konvertálása.
- C++ alkalmazás fejlesztése asztali és konzolos környezetben.
---
title: Miért nem Open XML SDK
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
description: "Lásd, miért jobb választás az Aspose.Slides, mint a ingyenes Open XML SDK: hasonlítsd össze a funkciókat, az automatikus konverzió nélküli konvertálást, valamint a PPT, PPTX és ODP széles körű támogatását."
---
## **Áttekintés**

Ez a cikk azt magyarázza, hogy mikor választhatják a fejlesztők az Open XML SDK‑t vagy az Aspose.Slides‑t a prezentációs dokumentumokkal való munkához. Az Open XML SDK‑t OOXML csomagok és az azok alatti XML elemek manipulálására szolgáló könyvtárként mutatja be, míg az Aspose.Slides‑t egy prezentációfeldolgozó könyvtárként, magas szintű objektummodellel és számos PowerPoint‑feladatra való támogatással tárgyalja.

A cikk összehasonlítja a két lehetőséget a támogatott formátumok, a programozási modell, a renderelés és nyomtatás képességei, a platformtámogatás és a tipikus felhasználási esetek alapján. Továbbá tisztázza, hogy az Open XML SDK megfelelő lehet alapvető PPTX műveletekhez vagy közvetlen OOXML elemek eléréséhez, míg az Aspose.Slides inkább összetett prezentációs feladatokhoz, például több PowerPoint formátummal való munka, alakzatok másolása vagy klónozása, szövegcsere, animációk alkalmazása és a prezentációk PDF, TIFF vagy XPS formátumba konvertálása esetén ajánlott.

## **Mi az Open XML SDK?**
Néha felmerül a kérdés: Miért használjunk Aspose termékeket a szabad Open XML SDK helyett? A válasz egyszerű: funkciók és funkcionalitás. Az [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) szerint az Open XML SDK‑t úgy határozzák meg: Az Open XML SDK 2.0 egyszerűsíti az Open XML csomagok és a csomagon belüli Open XML sémaelemek manipulálását. Az Open XML SDK 2.0 számos gyakori feladatot foglal magába, amelyeket a fejlesztők az Open XML csomagokon végeznek, így összetett műveleteket néhány kódsorral hajthatunk végre. Az OOXML dokumentumok lényegében tömörített XML fájlok, és az Open XML SDK olyan osztálygyűjtemény, amely erősen típusos módon teszi lehetővé az OOXML dokumentumok tartalmával való munkát. Ez azt jelenti, hogy a fájl kibontása az XML kinyeréséhez, az XML betöltése DOM‑fa struktúrába és az XML elemekkel, attribútumokkal való közvetlen munka helyett, az Open XML SDK osztályokat biztosít ehhez.

## **Mi az Aspose.Slides?**
Az Aspose.Slides egy osztálykönyvtár, amely lehetővé teszi alkalmazásod számára, hogy a következő prezentációfeldolgozó feladatokat végezze:

- Programozás egy **Presentation** objektummodellel.
- Kiváló minőségű konverziók minden népszerű támogatott PowerPoint prezentációs formátum között, beleértve a PDF‑re és XPS‑re történő átalakítást.
- Diakép-bélyegképek generálása jól ismert formátumokban, például PNG, JPEG és BMP, valamint diák exportálása SVG‑be.
- Prezentációk építése a nulláról vagy egy vagy több dokumentum kombinálásával.
- Animációk, Ole keretek, táblázatok hozzáadása, diagramok létrehozása és kezelése.
- Kiterjedt irányítás a szövegformázás kezeléséhez TextFrame‑eken, bekezdéseken és részek szintjén.

További részletekért a támogatott funkciókról látogass el az [Aspose.Slides funkciók](/slides/hu/cpp/product-overview/) oldalra.

## **Open XML SDK és Aspose.Slides összehasonlítása**
Az alábbi táblázat összehasonlítja az Open XML SDK és az Aspose.Slides funkcióit.

|**Funkció vagy funkciókategória**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Támogatott prezentációformátumok|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Átalakítás PPT‑ről PPTX‑re|Nem|Igen|
|<p>Magas szintű programozás egy Presentation Document Object Model (DOM) segítségével:</p><p>- Szöveg keresése és cseréje.</p><p>- Diák összeszerelése a prezentációkban.</p>|Nem|Igen|
|Részletes programozás dokumentumobjektum-modelllel, egyedi elemekhez és formázáshoz való hozzáférés, például TextHolders, TextFrames, Paragraphs és Portions.|Igen|Igen|
|Alacsony szintű közvetlen és teljes hozzáférés az alá‑XML elemekhez és attribútumokhoz, például a kapcsolati azonosítókhoz, listázási azonosítókhoz egy OOXML dokumentumban.|Igen|Nem|
|<p>Renderelés:</p><p>- Prezentációk renderelése PDF, PDF Notes, XPS, TIFF képek formátumba.</p><p>- Diabelyegképek renderelése PNG, JPEG, BMP, SVG és TIFF formátumokba.</p><p>- Kép felbontás, minőség, tömörítés és egyéb beállítások megadása.</p>|Nem|Igen|

## **Következtetés**
Az Open XML SDK és az Aspose.Slides nem versengenek közvetlenül, mivel különböző igényeket és közönséget szolgálnak ki. Az Open XML SDK egy osztálykönyvtár, amely erősen típusos módon teszi lehetővé az OOXML dokumentumokkal való munkát. Az Aspose.Slides egy nagyon hasznos prezentációfeldolgozó könyvtár, amely kiváló támogatást nyújt szinte minden Microsoft PowerPoint fájlformátumhoz. Ha csak egy meglehetősen egyszerű programozási műveletet kell végrehajtanod egy PPTX dokumentumon, akkor az Open XML SDK megfelelő választás lehet. Az Open XML SDK‑val kényelmesen elvégezheted az egyszerű feladatokat, például egy egyszerű PPTX dokumentum generálását, megjegyzések, fejléc/lábléc eltávolítását, képek kinyerését vagy hasonlókat. Egyes feladatok megvalósíthatók az Open XML SDK‑val, de nem az Aspose.Slides‑szel. Például, ha közvetlenül kell hozzáférned egy OOXML dokumentum XML elemeihez és attribútumaihoz, akkor az Open XML SDK‑t kell használni. Ha azonban összetett műveleteket kell végrehajtanod dokumentumokon, mint az alább felsorolt feladatok, akkor az Aspose.Slides a legjobb megoldás:

- Régebbi PowerPoint formátumok támogatása a PPTX‑en kívül is.
- Alakzatok másolása vagy klónozása diákon belül úgy, hogy az objektumok, stílusok és egyéb formázások megfelelően kombinálódjanak.
- Formázott vagy nem formázott szöveg cseréje.
- Animációk alkalmazása és csatlakozók használata alakzatokkal.
- Dokumentum konvertálása PDF‑re vagy XPS‑re, hogy pontosan úgy nézzen ki, ahogyan a Microsoft PowerPoint konvertálná.
- C++ alkalmazás fejlesztése asztali és konzolos környezetben.
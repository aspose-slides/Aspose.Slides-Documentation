---
title: Miért ne Open XML SDK
type: docs
weight: 50
url: /hu/net/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- összehasonlítás
- prezentációs objektummodell
- magas színvonalú konvertálás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Lásd, miért jobb választás az Aspose.Slides, mint az ingyenes Open XML SDK: hasonlítsd össze a funkciókat, az automatizálás nélküli konvertálást, és a PPT, PPTX és ODP széles körű támogatását."
---
## **Áttekintés**

Ez a cikk bemutatja, hogy mikor választhatják a fejlesztők az Open XML SDK-t vagy az Aspose.Slides-t prezentációs dokumentumok kezeléséhez. Az Open XML SDK-t OOXML csomagok és az azok alapszintű XML elemeinek manipulálására szolgáló könyvtárként írja le, míg az Aspose.Slides egy prezentációfeldolgozó könyvtár magas szintű objektummodelllel és számos PowerPoint‑hoz kapcsolódó feladatra vonatkozó támogatással.

A cikk összehasonlítja a két lehetőséget a támogatott formátumok, a programozási modell, a renderelés és nyomtatás képességei, a platformtámogatás és a gyakori felhasználási esetek szerint. Továbbá tisztázza, hogy az Open XML SDK megfelelő lehet alapvető PPTX műveletekhez vagy közvetlen OOXML elemekhez való hozzáféréshez, míg az Aspose.Slides komplex prezentációs feladatokhoz alkalmasabb, például több PowerPoint formátummal való munka, alakzatok másolása vagy klónozása, szövegcsere, animációk alkalmazása, valamint a prezentációk PDF, TIFF vagy XPS formátumba történő konvertálása.

## **Mi az Open XML SDK?**
Néha felmerül ez a kérdés: *Miért használjunk Aspose termékeket a szabad Open XML SDK helyett?*

Könnyű válaszolni erre a kérdésre funkciók és lehetőségek szempontjából.

A [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) szerint az Open XML SDK így van definiálva:

> "Az Open XML SDK 2.0 leegyszerűsíti az Open XML csomagok és a csomagon belüli Open XML sémálelemek manipulálását. Az Open XML SDK 2.0 számos gyakori feladatot kapszuláz, amelyet a fejlesztők az Open XML csomagokon hajtanak végre, így összetett műveleteket csak néhány kódsorral végezhetünk. Az OOXML dokumentumok lényegében tömörített XML fájlok, az Open XML SDK pedig osztálygyűjtemény, amely lehetővé teszi az OOXML dokumentumok tartalmának típusbiztos módon történő kezelését. Így a fájl kicsomagolása, XML kinyerése, DOM-fa betöltése és az XML elemekkel és attribútumokkal való közvetlen munka helyett az Open XML SDK osztályai végzik ezeket a feladatokat."

## **Mi az Aspose.Slides?**
Az Aspose.Slides egy osztálykönyvtár, amely lehetővé teszi az alkalmazások számára a következő prezentációfeldolgozó feladatok elvégzését:

- Programozás egy prezentációs objektummodell segítségével.
- Magas színvonalú átalakítások az összes népszerű PowerPoint prezentációs formátum támogatásával, beleértve a PDF, XPS, TIFF konvertálást és nyomtatást.
- Diakép előnézetek generálása jól ismert formátumokban, például PNG, JPEG és BMP, valamint diák exportálása SVG‑ként.
- Prezentációk építése nulláról vagy elemek kombinálásával egy vagy több dokumentumból.
- Animációk, OLE keretek, táblák, diagramok hozzáadása, létrehozása és kezelése.
- Kiterjedt vezérlés és kezelése a szövegformázásnak a TextFrames, Paragraphs és Portions szinteken.

További részletek a rendelkezésre álló funkciókról a [Aspose.Slides Features](/slides/hu/net/product-overview/) oldalon találhatók.

## **Open XML SDK és Aspose.Slides összehasonlítása**
Ez a táblázat az Open XML SDK képességeit és funkcióit hasonlítja össze az Aspose.Slides‑szel.

|**Funkció vagy Funkciókategória**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Támogatott prezentációs formátumok|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Átalakítás PPT‑ről PPTX‑re|Nem|Igen|
|<p>Magas szintű programozás Presentation Document Object Model (DOM) használatával:</p><p>- Szövegek keresése és cseréje.</p><p>- Diák összeállítása a prezentációkban.</p>|Nem|Igen|
|Részletes programozás dokumentum objektummodellel; egyedi elemek és formázások elérése, például TextHolders, TextFrames, Paragraphs és Portions.|Igen|Igen|
|Alacsony szintű közvetlen és teljes hozzáférés az alapszintű XML elemekhez és attribútumokhoz, például kapcsolati azonosítók, listaazonosítók egy OOXML dokumentumban.|Igen|Nem|
|<p>Renderelés és nyomtatás:</p><p>- Prezentációk renderelése PDF, PDF Notes, XPS, TIFF képekké.</p><p>- Diaképek előnézetének renderelése PNG, JPEG, BMP, SVG és TIFF formátumban.</p><p>- Kép felbontás, minőség, tömörítés és egyéb beállítások megadása.</p><p>- Prezentációk nyomtatása a .NET nyomtatási infrastruktúrájával. A komponens beépített nyomtatási metódussal rendelkezik a prezentációk a Microsoft PowerPoint nyomtatási előnézetének megfelelő nyomtatásához.</p>|Nem|Igen|
|Támogatott platformok|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Következtetés**
Az Open XML SDK és az Aspose.Slides nem versenyeznek közvetlenül, mivel teljesen eltérő igényeket elégítenek ki, és különböző célközönségeket céloznak.

{{% alert color="primary" %}} 

Az Open XML SDK egy osztálykönyvtár, amely típusbiztos módot biztosít az OOXML dokumentumok kezelésére, míg az Aspose.Slides egy rendkívül hasznos prezentációfeldolgozó könyvtár, amely kiváló támogatást nyújt szinte minden Microsoft PowerPoint fájlformátumhoz. 

{{% /alert %}} 

Ha a munkafolyamatod egy alapvető programozási művelet egy PPTX dokumentumon, akkor az Open XML SDK jó választás lehet. Az Open XML SDK‑val kényelmes egyszerű feladatokat végezni, mint egy egyszerű PPTX dokumentum generálása vagy megjegyzések, fejléc/lábléc eltávolítása, képek kinyerése vagy egyéb tevékenységek. Bizonyos feladatok elvégezhetők az Open XML SDK‑val, de nem az Aspose.Slides‑szel. Például ha közvetlenül hozzá kell férned egy OOXML dokumentum XML elemeihez és attribútumaihoz, akkor az Open XML SDK‑t kell használnod.

Ha komplex feladatokat kell végrehajtanod dokumentumokon – mint az alábbi lista – akkor az Aspose.Slides a legjobb lehetőség.

- Régebbi PowerPoint formátumokkal (és PPTX‑szel) kapcsolatos műveletek.
- Alakzatok másolása vagy klónozása diákon belül úgy, hogy egyesítse az objektumokat, stílusokat és egyéb formázási elemeket megfelelő módon.
- Formázott vagy nem formázott szöveg cseréje.
- Animációk alkalmazása és kapcsolók használata alakzatokkal.
- Dokumentum konvertálása PDF, TIFF vagy XPS formátumba úgy, hogy a Microsoft PowerPoint által végzett konverziót utánozza.
- .NET vagy Java alkalmazás fejlesztése asztali és webes környezetben.
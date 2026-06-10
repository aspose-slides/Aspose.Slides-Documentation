---
title: Miért ne az Open XML SDK
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

Ez a cikk bemutatja, hogy mikor választhatják a fejlesztők az Open XML SDK-t vagy az Aspose.Slides‑t prezentációs dokumentumokkal való munkához. Leírja, hogy az Open XML SDK egy könyvtár az OOXML csomagok és azok alapszintű XML elemeinek manipulálására, míg az Aspose.Slides egy prezentációfeldolgozó könyvtár magas szintű objektummodelllel és számos PowerPoint‑feladatra vonatkozó támogatással.

A cikk összehasonlítja a két lehetőséget a támogatott formátumok, a programozási modell, a renderelési és nyomtatási képességek, a platformtámogatás és a tipikus felhasználási esetek alapján. Továbbá tisztázza, hogy az Open XML SDK alkalmas lehet alapvető PPTX‑műveletekre vagy a OOXML elemek közvetlen elérésére, míg az Aspose.Slides jobban megfelel összetett prezentációs feladatokhoz, például több PowerPoint‑formátummal való munka, alakzatok másolása vagy klónozása, szöveg cseréje, animációk alkalmazása és a prezentációk PDF, TIFF vagy XPS formátumba konvertálása.

## **Mi az Open XML SDK?**
Az [MSDN könyvtár](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) szerint az Open XML SDK a következőképpen definiálható:

Az Open XML SDK 2.0 egyszerűsíti az Open XML csomagok és a csomagon belüli alapszintű Open XML sémaelemek manipulálását. Az Open XML SDK 2.0 számos gyakori feladatot foglal magába, amelyet a fejlesztők az Open XML csomagokon végeznek, így összetett műveleteket csak néhány kódsorral hajthat végre.

Az OOXML dokumentumok lényegében tömörített XML fájlok, az Open XML SDK pedig olyan osztályok gyűjteménye, amely lehetővé teszi az OOXML dokumentumok tartalmának erősen típusos módon történő kezelését. Ez azt jelenti, hogy a fájlt nem kell kibontani a XML kinyeréséhez, majd azt DOM‑fába betölteni és közvetlenül az XML elemekkel és attribútumokkal dolgozni; az Open XML SDK osztályok ezt a feladatot végzik el helyetted.

## **Mi az Aspose.Slides?**
Az Aspose.Slides egy osztálykönyvtár, amely lehetővé teszi az alkalmazásod számára a következő prezentációfeldolgozó feladatok elvégzését:

- Programozás egy **Presentation** objektummodell segítségével.
- Magas minőségű konverziók minden népszerű támogatott PowerPoint‑prezentációs formátum között, beleértve a PDF, XPS és TIFF formátumokat is.
- Diakép‑bélyegképek generálása jól ismert formátumokban, például PNG, JPEG és BMP, valamint diák exportálása SVG‑be.
- Prezentációk felépítése teljesen újonnan vagy több dokumentum egyesítésével.
- Animációk, Ole‑keretek, táblázatok, diagramok hozzáadása, létrehozása és kezelése.
- Kiterjedt vezérlés a szövegformázás kezeléséhez a TextFrames, Paragraphs és Portions szinteken.

A támogatott funkciók részletes listájáért látogass el a [Az Aspose.Slides funkciói](/slides/hu/java/product-overview/) oldalra.

## **Az Open XML SDK és az Aspose.Slides összehasonlítása**
{{% alert color="primary" %}} 

Az alábbi táblázat összehasonlítja az Open XML SDK és az Aspose.Slides funkcióit.

{{% /alert %}} 

|**Funkció vagy Funkciókategória**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Támogatott prezentációformátumok|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Átalakítás PPT‑ről PPTX‑re|No|Yes|
|<p>Magas szintű programozás a Presentation Document Object Model (DOM) segítségével:</p><p>- Szöveg keresése és cseréje.</p><p>- Diák összeállítása a prezentációkban.</p>|No|Yes|
|Részletes programozás dokumentumobjektum‑modellel, egyedi elemek és formázás elérése, például TextHolders, TextFrames, Paragraphs és Portions.|Yes|Yes|
|Alacsony szintű, közvetlen és teljes hozzáférés az alapszintű XML elemekhez és attribútumokhoz, mint például a kapcsolati azonosítók, listaazonosítók egy OOXML dokumentumban.|Yes|No|
|<p>Renderelés:</p><p>- Prezentációk renderelése PDF, PDF Notes, XPS, TIFF képekre.</p><p>- Diakép‑bélyegképek renderelése PNG, JPEG, BMP, SVG és TIFF formátumokba.</p><p>- Kép felbontás, minőség, tömörítés és egyéb beállítások meghatározása.</p>|No|Yes |
|Támogatott platformok|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Következtetés**
{{% alert color="primary" %}} 

Az Open XML SDK és az Aspose.Slides nem versenyeznek közvetlenül egymással, mivel különböző igényekre és felhasználói csoportokra irányulnak. Az Open XML SDK egy osztálykönyvtár, amely erősen típusos módon teszi lehetővé az OOXML dokumentumok kezelését. Az Aspose.Slides egy nagyon hasznos prezentációfeldolgozó könyvtár, amely kiváló támogatást nyújt szinte minden Microsoft PowerPoint fájlformátumhoz.

Ha csak egy meglehetősen egyszerű programozási műveletet kell végezni egy PPTX dokumentumon, akkor az Open XML SDK megfelelő választás lehet. Az Open XML SDK‑val kényelmesen elvégezhetők egyszerű feladatok, mint például egy egyszerű PPTX dokumentum generálása, megjegyzések, fejléc/lábléc eltávolítása, képek kinyerése vagy egyéb műveletek. Egyes feladatok megvalósíthatók az Open XML SDK‑val, de nem az Aspose.Slides‑szel. Például ha közvetlenül kell hozzáférned egy OOXML dokumentum XML elemeihez és attribútumaihoz, akkor az Open XML SDK‑t kell használnod. Ha viszont összetett műveleteket kell végrehajtanod a dokumentumokon, például az alábbiakat, akkor az Aspose.Slides a legjobb megoldás:

- Régebbi PowerPoint formátumok támogatása a PPTX‑en kívül.
- Alakzatok másolása vagy klónozása a diákon olyan módon, amely kombinálja az objektumokat, stílusokat és egyéb formázásokat.
- Formázott vagy nem formázott szöveg cseréje.
- Animációk alkalmazása és kapcsolók (connectors) használata az alakzatokkal.
- Dokumentum konvertálása PDF, TIFF vagy XPS formátumba, hogy pontosan úgy nézzen ki, mint a Microsoft PowerPoint által konvertált verzió.
- .NET vagy Java alkalmazás fejlesztése asztali és web‑alapú környezetben.

{{% /alert %}}
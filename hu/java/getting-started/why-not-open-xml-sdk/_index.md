---
title: Miért nem Open XML SDK
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
description: "Lásd, miért jobb választás az Aspose.Slides a szabad Open XML SDK-nál: funkciók összehasonlítása, automatizálás nélküli konverzió és széles körű támogatás PPT, PPTX és ODP formátumokhoz."
---
## **Áttekintés**

Ez a cikk ismerteti, mikor választhatnak a fejlesztők az Open XML SDK vagy az Aspose.Slides megoldások közül a prezentációs dokumentumok kezeléséhez. Leírja az Open XML SDK-t, mint egy könyvtárat az OOXML csomagok és az alatta lévő XML elemek manipulálására, míg az Aspose.Slides egy prezentációfeldolgozó könyvtárként jelenik meg magas szintű objektummodelllel és a PowerPoint-hoz kapcsolódó feladatok széles körű támogatásával.

A cikk azonosított formátumok, a programozási modell, a renderelés, a platformtámogatás és a tipikus felhasználási esetek alapján hasonlítja össze a két lehetőséget. Azt is tisztázza, hogy az Open XML SDK alkalmas lehet alapvető PPTX műveletekre vagy közvetlen hozzáférésre az OOXML elemekhez, míg az Aspose.Slides inkább összetett prezentációs feladatokra, például több PowerPoint formátum kezelésére, alakzatok másolására vagy klónozására, szöveg cseréjére, animációk alkalmazására és a prezentációk PDF, TIFF vagy XPS formátumba konvertálására.

## **Mi az Open XML SDK?**

Az [MSDN Könyvtár](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) szerint az Open XML SDK a következőképpen definiálható:

Az Open XML SDK 2.0 egyszerűsíti az Open XML csomagok és a csomagon belüli Open XML sémaelemek manipulálásával járó feladatot. Az Open XML SDK 2.0 számos gyakori feladatot kapszuláz, amelyeket a fejlesztők az Open XML csomagokon hajtanak végre, így összetett műveleteket csak néhány kódsorral végezhetsz el.

Az OOXML dokumentumok lényegében tömörített XML fájlok, és az Open XML SDK egy osztálykészlet, amely lehetővé teszi az OOXML dokumentumok tartalmának erősen típusos módon történő feldolgozását. Ez azt jelenti, hogy a fájl kibontása és az XML kinyerése, az XML betöltése egy DOM-fa struktúrába, valamint az XML elemekkel és attribútumokkal való közvetlen munka helyett, az Open XML SDK osztályokkal biztosítja ezt.

## **Mi az Aspose.Slides?**

Az Aspose.Slides egy osztálykönyvtár, amely lehetővé teszi az alkalmazásod számára a következő prezentációfeldolgozó feladatok elvégzését:

- Programozás a **Presentation** objektummodell használatával.
- Magas minőségű konverziók az összes népszerű, támogatott PowerPoint prezentációformátum között, beleértve a PDF, XPS és TIFF formátumokba való konvertálást.
- Képesség diakép bélyegképek generálására ismert formátumokban, például PNG, JPEG és BMP, valamint diák exportálása SVG formátumba.
- Képesség prezentációk létrehozására a semmiből vagy több dokumentum egyesítésével.
- Támogatás animációk, Ole keretek, táblázatok hozzáadásához, valamint diagramok létrehozásához és kezeléséhez.
- Kiterjedt vezérlés a szövegformázás kezeléséhez TextFrames, Paragraphs és Portions szinteken.

Az elérhető funkciókkal kapcsolatos további információkért kérjük, látogasd meg a [Aspose.Slides funkciói](/slides/hu/java/product-overview/) oldalt.

## **Open XML SDK összehasonlítása az Aspose.Slides-szel**
{{% alert color="info" %}} 
Az alábbi táblázat összehasonlítja az Open XML SDK és az Aspose.Slides funkcióit.
{{% /alert %}} 

|**Funkció vagy Funkciókategória**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Támogatott prezentációformátumok|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertálás PPT-ről PPTX-re|No|Yes|
|<p>Magas szintű programozás a Presentation Document Object Model (DOM) használatával:</p><p>- Szöveg keresése és cseréje.</p><p>- Diák összeállítása a prezentációkban.</p>|No|Yes|
|Részletes programozás dokumentum objektummodell használatával, egyedi elemekhez és formázáshoz való hozzáférés, például TextHolders, TextFrames, Paragraphs és Portions.|Yes|Yes|
|Alacsony szintű közvetlen és teljes hozzáférés az alapul szolgáló XML elemekhez és attribútumokhoz, például kapcsolati azonosítókhoz, listaadatokhoz egy OOXML dokumentumban.|Yes|No|
|<p>Renderelés:</p><p>- Prezentációk renderelése PDF, PDF Notes, XPS, TIFF képekbe.</p><p>- Diabélyegképek renderelése PNG, JPEG, BMP, SVG és TIFF formátumra.</p><p>- Kép felbontás, minőség, tömörítés és egyéb beállítások megadása.</p>|No|Yes |
|Támogatott platformok|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Következtetés**
{{% alert color="info" %}} 

Az Open XML SDK és az Aspose.Slides nem versenyeznek közvetlenül, mivel teljesen eltérő igényeket és közönségeket céloznak meg. Az Open XML SDK egy osztálykönyvtár, amely erősen típusos módon biztosítja az OOXML dokumentumok kezelését. Az Aspose.Slides egy nagyon hasznos prezentációfeldolgozó könyvtár, amely szinte minden Microsoft PowerPoint fájlformátumhoz kiváló támogatást nyújt.

Ha csak egy meglehetősen egyszerű programozási műveletet kell végrehajtanod egy PPTX dokumentumon, akkor az Open XML SDK megfelelő választás lehet. Az Open XML SDK-val kényelmesen végezhetsz egyszerű feladatokat, például egyszerű PPTX dokumentum generálását, megjegyzések, fejlécek/láblécek eltávolítását, képek kinyerését vagy egyéb feladatokat. Néhány feladat megvalósítható az Open XML SDK-val, de nem hajtható végre az Aspose.Slides-szel. Például, ha közvetlenül kell hozzáférned egy OOXML dokumentum XML elemeihez és attribútumaihoz, akkor az Open XML SDK-t kell használni. Azonban, ha összetett műveleteket kell végrehajtanod a dokumentumokon, mint az alábbi feladatok, akkor az Aspose.Slides a legjobb választás:

- Támogatás régebbi PowerPoint formátumok számára a PPTX mellett.
- Alakzatok másolása vagy klónozása a diáknál úgy, hogy az objektumok, stílusok és egyéb formázás megfelelően kombinálódjon.
- Formázott vagy nem formázott szöveg cseréje.
- Animációk alkalmazása és csatlakozók használata az alakzatoknál.
- Dokumentum konvertálása PDF, TIFF vagy XPS formátumba, hogy pontosan úgy nézzen ki, ahogyan a Microsoft PowerPoint konvertálta volna.
- .NET vagy Java alkalmazás fejlesztése mind asztali, mind webes környezetben.

{{% /alert %}}
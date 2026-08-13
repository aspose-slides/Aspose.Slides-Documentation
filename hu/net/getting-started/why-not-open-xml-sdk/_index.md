---
title: Miért ne az Open XML SDK
type: docs
weight: 50
url: /hu/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- összehasonlítás
- prezentációs objektummodell
- magas minőségű konverzió
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse meg, miért jobb választás az Aspose.Slides a szabad Open XML SDK-nél: funkciók összehasonlítása, automatizálás nélküli konverzió és széles körű támogatás a PPT, PPTX és ODP formátumokhoz."
---
## **Áttekintés**

Ez a cikk ismerteti, hogy a fejlesztők mikor választhatják az Open XML SDK-t vagy az Aspose.Slides-t prezentációs dokumentumok kezelésére. Leírja, hogy az Open XML SDK egy könyvtár az OOXML csomagok és azok alapszintű XML elemeinek manipulálására, míg az Aspose.Slides egy prezentációfeldolgozó könyvtár, magas szintű objektummodelllel és számos PowerPoint‑al kapcsolatos feladat támogatásával.

A cikk összehasonlítja a két lehetőséget a támogatott formátumok, a programozási modell, a renderelés és nyomtatás képességei, a platformtámogatás és a tipikus felhasználási esetek alapján. Továbbá tisztázza, hogy az Open XML SDK alkalmas lehet egyszerű PPTX műveletekre vagy az OOXML elemek közvetlen elérésére, míg az Aspose.Slides jobban megfelel összetett prezentációs feladatokra, például több PowerPoint formátum kezelése, alakzatok másolása vagy klónozása, szövegcserék, animációk alkalmazása és a prezentációk PDF, TIFF vagy XPS formátumba történő konvertálása.

## **Mi az Open XML SDK?**
Néha felmerül ez a kérdés: *Miért használjunk Aspose termékeket a szabad Open XML SDK helyett?*  

Könnyen válaszolhatunk erre a kérdésre a funkciók és képességek alapján.  

A [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) szerint az Open XML SDK így van definiálva:

> "Az Open XML SDK 2.0 leegyszerűsíti az Open XML csomagok és a csomagon belüli alapszintű Open XML sémaelemek manipulálását. Az Open XML SDK 2.0 számos gyakori feladatot foglal össze, amelyeket a fejlesztők az Open XML csomagokon végeznek, így csak néhány sor kóddal hajthatóak végre összetett műveletek. Az OOXML dokumentumok lényegében tömörített XML fájlok, és az Open XML SDK egy osztálygyűjtemény, amely lehetővé teszi az OOXML dokumentumok tartalmának erősen tipizált módon történő kezelését. Ez azt jelenti, hogy a fájl kicsomagolása, az XML kinyerése, egy DOM-fa betöltése és az XML elemekkel, attribútumokkal való közvetlen munka helyett az Open XML SDK olyan osztályokat biztosít, amelyek ezt végzik."

## **Mi az Aspose.Slides?**
Az Aspose.Slides egy osztálykönyvtár, amely lehetővé teszi a következő prezentációfeldolgozó feladatok elvégzését:

- Programozás egy prezentációs objektummodell segítségével.
- Magas minőségű konverziók a népszerű PowerPoint prezentációformátumok között, beleértve a PDF, XPS, TIFF formátumokba való átalakítást és a nyomtatást.
- Diakép bélyegképek generálása jól ismert formátumokban, például PNG, JPEG és BMP, valamint a diák SVG‑ként történő exportálása.
- Prezentációk építése alapból vagy több dokumentum elemeinek kombinálásával.
- Animációk, OLE keretek, táblázatok, diagramok hozzáadása, létrehozása és kezelése.
- Kiterjedt vezérlés és kezelés a szövegformázásra TextFrames, Paragraphs és Portions szinten.  

További részletek a rendelkezésre álló funkciókról a [Aspose.Slides Features](/slides/hu/net/product-overview/) oldalon találhatók.

## **Open XML SDK és Aspose.Slides összehasonlítása**
Ez a táblázat hasonlítja össze az Open XML SDK képességeit és funkcióit az Aspose.Slides‑kel.

|**Funkció vagy Funkciókategória**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Támogatott prezentációformátumok|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Átalakítás PPT‑ről PPTX‑re|No|Yes|
|<p>Magas szintű programozás Presentation Document Object Model (DOM) segítségével:</p><p>- Szövegkeresés és csere.</p><p>- Diák összeállítása a prezentációkban.</p>|No|Yes|
|Részletes programozás dokumentumobjektum-modelllel; hozzáférés az egyedi elemekhez és formázásokhoz, például TextHolders, TextFrames, Paragraphs és Portions.|Yes|Yes|
|Alacsony szintű, közvetlen és teljes hozzáférés az alapszintű XML elemekhez és attribútumokhoz, például a kapcsolati azonosítókhoz, listaadatokhoz egy OOXML dokumentumban.|Yes|No|
|<p>Renderelés és nyomtatás:</p><p>- Prezentációk renderelése PDF, PDF Notes, XPS, TIFF képekre.</p><p>- Diabélyegképek renderelése PNG, JPEG, BMP, SVG és TIFF formátumokba.</p><p>- Kép felbontás, minőség, tömörítés és egyéb opciók megadása.</p><p>- Prezentációk nyomtatása .NET nyomtatási infrastruktúrával. A komponens beépített nyomtatási módszerrel rendelkezik, amely a PowerPoint Nyomtatási előnézetben látható módon nyomtat.</p>|No|Yes|
|Támogatott platformok|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Összegzés**
Az Open XML SDK és az Aspose.Slides nem versenyeznek közvetlenül, mivel jelentősen eltérő igényeket elégítenek ki, és különböző célközönségeket céloznak meg.  

{{% alert color="info" %}} 

Az Open XML SDK egy osztálykönyvtár, amely erősen tipizált módon biztosítja az OOXML dokumentumok kezelését, míg az Aspose.Slides egy rendkívül hasznos prezentációfeldolgozó könyvtár, amely nagyszerű támogatást nyújt szinte minden Microsoft PowerPoint fájlformátumhoz. 

{{% /alert %}} 

Ha a munkafolyamatod egyszerű programozási művelet egy PPTX dokumentumon, akkor az Open XML SDK jó választás lehet. Az Open XML SDK‑val kényelmesen végezhetsz egyszerű feladatokat, például egy egyszerű PPTX dokumentum generálását vagy megjegyzések, fejléc/lábléc eltávolítását, képek kinyerését stb. Bizonyos feladatok elvégezhetők az Open XML SDK‑val, de nem az Aspose.Slides‑szel. Például ha közvetlenül kell hozzáférned egy OOXML dokumentum XML elemeihez és attribútumaihoz, akkor az Open XML SDK‑t kell használnod.  

Ha összetett feladatokat kell végrehajtanod a dokumentumokon – például az alábbi lista szerint – akkor az Aspose.Slides a legjobb megoldás.

- Műveletek régebbi PowerPoint formátumokkal (és PPTX‑szel is).
- Alakzatok másolása vagy klónozása diákon belül oly módon, hogy a objektumok, stílusok és egyéb formázási elemek megfelelően kombinálódjanak.
- Formázott vagy nem formázott szöveg cseréje.
- Animációk alkalmazása és kapcsolók használata alakzatokkal.
- Dokumentum konvertálása PDF, TIFF vagy XPS formátumba úgy, hogy a végeredmény olyan legyen, mintha a Microsoft PowerPoint végezte volna a konvertálást.
- .NET vagy Java alkalmazás fejlesztése mind asztali, mind webes környezetben.
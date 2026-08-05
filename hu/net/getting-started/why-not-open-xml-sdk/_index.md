---
title: Miért ne Open XML SDK
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
description: "Lásd, miért jobb választás az Aspose.Slides a ingyenes Open XML SDK-nél: hasonlítsd össze a funkciókat, az automatizálás nélküli konverziót és a PPT, PPTX és ODP széleskörű támogatását."
---
## **Áttekintés**

Ez a cikk azt magyarázza, hogy a fejlesztők mikor választhatják az Open XML SDK-t vagy az Aspose.Slides-t a prezentációs dokumentumokkal való munkához. Az Open XML SDK-t OOXML csomagok és azok alapterületi XML elemeinek manipulálására szolgáló könyvtárként mutatja be, míg az Aspose.Slides egy prezentációfeldolgozó könyvtár, magas szintű objektummodellel és számos PowerPoint‑hoz kapcsolódó feladat támogatásával.

A cikk összehasonlítja a két lehetőséget a támogatott formátumok, a programozási modell, a renderelési és nyomtatási lehetőségek, a platformtámogatás és a gyakori felhasználási esetek alapján. Az is tisztázza, hogy az Open XML SDK megfelelő lehet alapvető PPTX műveletekhez vagy az OOXML elemek közvetlen eléréséhez, míg az Aspose.Slides inkább összetett prezentációs feladatokhoz alkalmas, például több PowerPoint formátummal való munka, alakzatok másolása vagy klónozása, szöveg cseréje, animációk alkalmazása, illetve a prezentációk PDF, TIFF vagy XPS formátumba konvertálása.

## **Mi az Open XML SDK?**
Néha felmerül ez a kérdés: *Miért használjunk Aspose termékeket a szabad Open XML SDK helyett?*  

Könnyűnek találjuk ezt a kérdést funkciók és képességek szempontjából megválaszolni.  

Az [MSDN Könyvtár](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) szerint az Open XML SDK így van definiálva:  

> "Az Open XML SDK 2.0 leegyszerűsíti az Open XML csomagok és a csomagon belüli alapuló Open XML sémaelemek manipulálásának feladatát. Az Open XML SDK 2.0 sok gyakori feladatot foglal magába, amelyet a fejlesztők az Open XML csomagokon végeznek, így csak néhány kódsorral hajthatunk végre összetett műveleteket. Az OOXML dokumentumok lényegében tömörített XML fájlok, és az Open XML SDK egy osztálygyűjtemény, amely lehetővé teszi az OOXML dokumentumok tartalmának erősen típusos módon történő kezelését. Vagyis ahelyett, hogy egy fájlt kibontanánk az XML kinyeréséhez, betöltenénk azt egy DOM fába, és közvetlenül az XML elemekkel és attribútumokkal dolgoznánk, az Open XML SDK olyan osztályokat biztosít ennek megvalósításához."

## **Mi az Aspose.Slides?**
Az Aspose.Slides egy osztálykönyvtár, amely lehetővé teszi az alkalmazások számára, hogy ezeket a prezentációfeldolgozási feladatokat végrehajtsák:

- Programozás egy prezentációs objektummodell használatával.  
- Magas minőségű konverziók, amelyek minden népszerű támogatott PowerPoint prezentációs formátumot érintnek, beleértve a PDF, XPS, TIFF formátumokba és nyomtatásba történő konvertálást.  
- Dia bélyegképek generálása jól ismert formátumokban, mint a PNG, JPEG és BMP, valamint diák exportálása SVG formátumba.  
- Prezentációk építése nulláról vagy elemek kombinálásával egy vagy több dokumentumból.  
- Animációk, OLE keretek, táblázatok hozzáadása, diagramok létrehozása és kezelése.  
- A szövegformázás részletes vezérlése és kezelése TextFrames, Paragraphs és Portions szinten.  

A rendelkezésre álló funkciókról további részletekért lásd az [Aspose.Slides funkciók](/slides/hu/net/product-overview/) oldalt.

## **Open XML SDK és Aspose.Slides összehasonlítása**
This table compares Open XML SDK capabilities and features with Aspose.Slides.

|**Funkció vagy Funkciókategória**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Támogatott prezentációformátumok|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konvertálás PPT‑ről PPTX‑re |Nem|Igen|
|<p>Magas szintű programozás egy Presentation Document Object Model (DOM) segítségével:</p><p>- Szöveg keresése és cseréje.</p><p>- Diák összerakása a prezentációkban.</p>|Nem|Igen|
|Részletes programozás egy dokumentum objektummodell segítségével; egyedi elemekhez és formázáshoz való hozzáférés, mint a TextHolders, TextFrames, Paragraphs és Portions.|Igen|Igen|
|Alacsony szintű közvetlen és teljes hozzáférés az alapuló XML elemekhez és attribútumokhoz, például kapcsolati azonosítókhoz, egy OOXML dokumentum listaazonosítóihoz.|Igen|Nem|
|<p>Renderelés és nyomtatás:</p><p>- Prezentációk renderelése PDF, PDF Notes, XPS, TIFF képekre.</p><p>- Diabélyegképek renderelése PNG, JPEG, BMP, SVG és TIFF formátumba.</p><p>- Kép felbontás, minőség, tömörítés és egyéb beállítások megadása.</p><p>- Prezentációk nyomtatása a .NET nyomtatási infrastruktúra használatával. A komponens beépített nyomtatási metódussal rendelkezik, amely a prezentációkat a MS PowerPoint Nyomtatási előnézet szerint nyomtatja.</p>|Nem|Igen|
|Támogatott platformok|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Következtetés**
Az Open XML SDK és az Aspose.Slides nem versengenek közvetlenül, mivel lényegesen eltérő igényeket szolgálnak ki, és különböző közönségeket céloznak.  

{{% alert color="primary" %}}  
Az Open XML SDK egy osztálykönyvtár, amely erősen típusos módot biztosít az OOXML dokumentumok kezelésére, míg az Aspose.Slides egy rendkívül hasznos prezentációfeldolgozó könyvtár, amely szinte minden Microsoft PowerPoint fájlformátumhoz kiváló támogatást nyújt.  
{{% /alert %}}  

Ha a munkafolyamatod egyszerű programozási művelet egy PPTX dokumentumon, akkor az Open XML SDK jó választás lehet. Az Open XML SDK-val kényelmesen elvégezheted az egyszerű feladatokat, mint egy egyszerű PPTX dokumentum létrehozása vagy megjegyzések, fejlécek/láblécek eltávolítása, képek kinyerése vagy egyebek. Bizonyos feladatok elvégezhetők az Open XML SDK-val, de nem hajthatók végre az Aspose.Slides-szel. Például, ha közvetlenül hozzá kell férned egy OOXML dokumentum XML elemeihez és attribútumaihoz, akkor az Open XML SDK-t kell használnod.  

Ha összetett feladatokat kell végrehajtanod dokumentumokon – mint az alábbi listában szereplő feladatok – akkor az Aspose.Slides a legjobb választás.  

- Műveletek régebbi PowerPoint formátumokkal (és PPTX‑szel is).  
- Alakzatok másolása vagy klónozása diákon belül úgy, hogy megfelelő módon kombinálja az objektumokat, stílusokat és egyéb formázó elemeket.  
- Formázott vagy formázatlan szöveg cseréje.  
- Animációk alkalmazása és csatlakozók használata alakzatokkal.  
- Dokumentum konvertálása PDF, TIFF vagy XPS formátumba, hogy úgy nézzen ki, mintha a Microsoft PowerPoint végezte volna a konverziót.  
- .NET vagy Java alkalmazás fejlesztése asztali és webes környezetben egyaránt.
---
title: Prezentáció információinak lekérése és frissítése .NET-ben
linktitle: Prezentáció információk
type: docs
weight: 30
url: /hu/net/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentumtulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok módosítása
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel a diák, a szerkezet és a metaadatok részleteit PowerPoint és OpenDocument prezentációkban .NET használatával a gyorsabb betekintés és az intelligensebb tartalomelemzés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet ellenőrizni a prezentáció információkat az Aspose.Slides-ban. Ismerteti, hogyan határozható meg egy prezentáció aktuális formátuma a teljes fájl betöltése nélkül, hogyan olvashatók a dokumentum tulajdonságai, és hogyan frissíthetők ezek a tulajdonságok szükség esetén.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/documentproperties/) API-kon alapulnak, és tipikus műveleteket mutatnak be a prezentáció metaadatokkal való munka során.

## **A prezentáció formátumának ellenőrzése**

Mielőtt a prezentációval dolgozna, érdemes megtudni, milyen formátumban (PPT, PPTX, ODP és egyebek) van a prezentáció jelenleg.

A prezentáció formátuma betöltés nélkül ellenőrizhető. Lásd ezt a C# kódot:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **A prezentáció tulajdonságainak lekérése**

Ez a C# kód bemutatja, hogyan lehet lekérni a prezentáció tulajdonságait (információk a prezentációról):

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

Érdemes megtekinteni a [DocumentProperties osztály alatti tulajdonságokat](https://reference.aspose.com/slides/hu/net/aspose.slides/documentproperties/#properties).

## **A prezentáció tulajdonságainak frissítése**

Az Aspose.Slides biztosítja a [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) metódust, amely lehetővé teszi a prezentáció tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint prezentáció a lenti dokumentumtulajdonságokkal.

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

Ez a kódrészlet bemutatja, hogyan lehet szerkeszteni néhány prezentációtulajdonságot:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

A dokumentumtulajdonságok módosításának eredményei alább láthatók.

![A PowerPoint prezentáció módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

A prezentációról és annak biztonsági attribútumairól további információkért hasznosak lehetnek a következő hivatkozások:

- [Jelszóval védett prezentációk](/slides/hu/net/password-protected-presentation/)
- [Írásvédett prezentációk](/slides/hu/net/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok be vannak-e ágyazva, és melyek azok?**

Keresse a [beágyazott betűtípus információkat](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getembeddedfonts/) a prezentáció szintjén, majd hasonlítsa össze ezeket a [valóban a tartalomban használt betűtípusok](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getfonts/) halmazával, hogy azonosítsa, mely betűtípusok kritikusak a megjelenítéshez.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz rejtett diáket, és hány?**

Iteráljon a [diakollekción](https://reference.aspose.com/slides/hu/net/aspose.slides/slidecollection/) és ellenőrizze minden dia [láthatósági jelzőjét](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/hidden/).

**Felismerhető-e, hogy egyedi dia méret és tájolás van-e használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Hasonlítsa össze a jelenlegi [dia méretet](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slidesize/) és tájolást a szabványos előbeállításokkal; ez segít előre jelezni a nyomtatási és exportálási viselkedést.

**Van-e gyors módszer annak megtekintésére, hogy a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Böngéssze végig az összes [diagramot](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/), ellenőrizze azok [adatforrását](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/datasourcetype/), és jegyezze fel, hogy az adat belső vagy hivatkozáson alapuló, beleértve a törött hivatkozásokat is.

**Hogyan értékelhetem a 'nehéz' diákat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Minden diához számolja meg az objektumok számát, és keressen nagy képeket, átlátszóságot, árnyékokat, animációkat és multimédiát; adjon hozzá nagyjából kiszámított komplexitási pontszámot, hogy jelezze a lehetséges teljesítményproblémákat.
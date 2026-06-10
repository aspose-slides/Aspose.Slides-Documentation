---
title: Prezentációs információk lekérése és frissítése .NET-ben
linktitle: Prezentációs információk
type: docs
weight: 30
url: /hu/net/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentum tulajdonságok
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
description: "Fedezze fel a diák, a szerkezet és a metaadatok állapotát PowerPoint és OpenDocument prezentációkban .NET használatával a gyorsabb betekintés és az intelligensebb tartalom-ellenőrzés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan ellenőrizhetők a prezentáció adatai az Aspose.Slides-ben. Leírja, hogyan határozható meg egy prezentáció aktuális formátuma a teljes fájl betöltése nélkül, hogyan olvashatók ki a dokumentumtulajdonságai, és hogyan frissíthetők ezek a tulajdonságok szükség esetén.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/documentproperties/) API-kon alapulnak, és bemutatják a prezentáció metaadataival való tipikus műveleteket.

## **Ellenőrizze a prezentáció formátumát**

Mielőtt dolgozna egy prezentáción, érdemes megtudni, hogy jelenleg milyen formátumban (PPT, PPTX, ODP és egyéb) van a prezentáció.

A prezentáció formátuma betöltés nélkül ellenőrizhető. Lásd ezt a C# kódot:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Szerezze meg a prezentáció tulajdonságait**

Ez a C# kód megmutatja, hogyan szerezhetők meg a prezentáció tulajdonságai (információk a prezentációról):

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

Érdemes megtekinteni a [tulajdonságokat a DocumentProperties alatt](https://reference.aspose.com/slides/hu/net/aspose.slides/documentproperties/#properties) osztály.

## **A prezentáció tulajdonságainak frissítése**

Az Aspose.Slides biztosítja a [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) metódust, amely lehetővé teszi a prezentáció tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint prezentáció a lenti dokumentumtulajdonságokkal.

![Az eredeti dokumentumtulajdonságok a PowerPoint prezentációban](input_properties.png)

Ez a kódrészlet bemutatja, hogyan szerkeszthető néhány prezentáció tulajdonság:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

A dokumentumtulajdonságok módosításának eredménye alább látható.

![Megváltozott dokumentumtulajdonságok a PowerPoint prezentációban](output_properties.png)

## **Hasznos hivatkozások**

További információkért egy prezentációról és biztonsági attribútumairól az alábbi hivatkozások lehetnek hasznosak:

- [A prezentáció titkosítva van-e](https://docs.aspose.com/slides/hu/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [A prezentáció írásvédett (csak olvasható) állapotban van-e](https://docs.aspose.com/slides/hu/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [A prezentáció jelszóval védett-e, mielőtt betöltenénk](https://docs.aspose.com/slides/hu/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [A prezentáció védéséhez használt jelszó megerősítése](https://docs.aspose.com/slides/hu/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek be vannak-e ágyazva és melyek azok?**

Keresse a [beágyazott betűkészlet információkat](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getembeddedfonts/) a prezentáció szintjén, majd hasonlítsa össze ezeket a [valóban a tartalomban használt betűkészletek](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getfonts/) listájával, hogy azonosítsa, mely betűkészletek kritikusak a megjelenítéshez.

**Hogyan ellenőrizhetem gyorsan, hogy a fájl rejtett diákot tartalmaz-e és hányat?**

Iteráljon a [diák gyűjteményén](https://reference.aspose.com/slides/hu/net/aspose.slides/slidecollection/), és vizsgálja meg minden dia [láthatósági jelzőjét](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/hidden/).

**Felderíthetem-e, hogy egyedi dia méret és tájolás van-e használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Hasonlítsa össze a jelenlegi [dia méretet](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slidesize/) és tájolást a szabványos beállításokkal; ez segít előre jelezni a nyomtatásra és exportálásra vonatkozó viselkedést.

**Van-e gyors módja annak, hogy lássam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Járja be az összes [diagramot](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/), ellenőrizze azok [adatelérési típusát](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/datasourcetype/), és vegye figyelembe, hogy az adatok belsőek vagy hivatkozáson alapulnak, beleértve a hibás hivatkozásokat is.

**Hogyan értékelhetem a „nehéz” diákokat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Minden dián számolja meg az objektumok mennyiségét, és keressen nagy képeket, átlátszóságot, árnyékokat, animációkat és multimédiát; adjon egy durva összetettségi pontszámot, amely jelzi a lehetséges teljesítményproblémákat.
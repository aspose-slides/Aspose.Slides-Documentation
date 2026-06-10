---
title: Prezentációs információk lekérése és frissítése C++-ban
linktitle: Prezentációs információk
type: docs
weight: 30
url: /hu/cpp/examine-presentation/
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
- C++
- Aspose.Slides
description: "Fedezze fel a diák, a felépítés és a metaadatok a PowerPoint és OpenDocument prezentációkban C++ használatával a gyorsabb betekintés és az intelligensebb tartalomelemzés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan ellenőrizhetők a bemutató információi az Aspose.Slides használatával. Ismerteti, hogyan határozható meg egy bemutató aktuális formátuma a teljes fájl betöltése nélkül, hogyan olvashatók a dokumentum tulajdonságai, és hogyan frissíthetők ezek a tulajdonságok szükség esetén.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/documentproperties/) API-kon alapulnak, és tipikus műveleteket mutatnak be a prezentáció metaadataival való munka során.

## **A prezentáció formátumának ellenőrzése**

Mielőtt egy prezentációval dolgozna, előfordulhat, hogy meg szeretné tudni, milyen formátumban (PPT, PPTX, ODP és egyebek) van a prezentáció jelenleg.

Ellenőrizheti a prezentáció formátumát a fájl betöltése nélkül. Lásd a következő C++ kódot:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **A prezentáció tulajdonságainak lekérése**

Ez a C++ kód bemutatja, hogyan kérhetőek le a prezentáció tulajdonságai (információk a prezentációról):

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **A prezentáció tulajdonságainak frissítése**

Az Aspose.Slides a [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) metódust biztosítja, amely lehetővé teszi a prezentáció tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint prezentáció, amelynek a dokumentum tulajdonságai az alábbiek.

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

Ez a kódpélda bemutatja, hogyan szerkeszthető néhány prezentáció tulajdonság:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

A dokumentumtulajdonságok módosításának eredménye az alábbiakban látható.

![A PowerPoint prezentáció módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

További információkért a prezentációról és annak biztonsági attribútumairól, az alábbi hivatkozások lehetnek hasznosak:

- [Annak ellenőrzése, hogy a prezentáció titkosított-e](https://docs.aspose.com/slides/hu/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Annak ellenőrzése, hogy a prezentáció írásvédelem alatt áll-e (csak olvasható)](https://docs.aspose.com/slides/hu/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Annak ellenőrzése, hogy a prezentáció jelszóval védett-e betöltés előtt](https://docs.aspose.com/slides/hu/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [A prezentáció védéséhez használt jelszó megerősítése](https://docs.aspose.com/slides/hu/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek be vannak-e ágyazva, és melyek azok?**

Keresse a [beágyazott betűtípusra vonatkozó információkat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getembeddedfonts/) a prezentáció szintjén, majd hasonlítsa össze ezeket a bejegyzéseket a [tartalomban ténylegesen használt betűtípusok](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/getfonts/) halmazával, hogy azonosítsa, mely betűtípusok kritikusak a megjelenítéshez.

**Hogyan tudom gyorsan megállapítani, hogy a fájl rejtett diákot tartalmaz-e, és hány darabot?**

Iteráljon a [dia gyűjteményen](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidecollection/) és vizsgálja meg minden dia [láthatósági jelzőjét](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/get_hidden/).

**Felderíthető-e, hogy egyedi dia méret és tájolás van-e használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Hasonlítsa össze a jelenlegi [dia méretet és tájolást](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slidesize/) a szabványos előrebeállított értékekkel; ez segít előre jelezni a nyomtatás és exportálás viselkedését.

**Van-e gyors módszer annak megállapítására, hogy a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Járja be az összes [diagramot](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chart/), ellenőrizze azok [adatforrását](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_datasourcetype/), és jegyezze fel, hogy az adat belső vagy hivatkozáson alapuló, beleértve a hibás hivatkozásokat is.

**Hogyan értékelhetem a ‘nehéz’ diákat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Minden diához számolja össze az objektumok számát, és keressen nagy képeket, átlátszóságot, árnyékokat, animációkat és multimédiát; adjon hozzá egy durva összetettségi pontszámot, hogy jelölje a lehetséges teljesítményproblémákat.
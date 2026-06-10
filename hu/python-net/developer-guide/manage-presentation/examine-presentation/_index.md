---
title: Pythonban a prezentáció információinak lekérése és frissítése
linktitle: Prezentáció információk
type: docs
weight: 30
url: /hu/python-net/examine-presentation/
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
- Python
- Aspose.Slides
description: "Fedezze fel a diák, a szerkezet és a metaadatok részleteit PowerPoint és OpenDocument prezentációkban Python használatával, hogy gyorsabb betekintést nyerjen és okosabb tartalom-ellenőrzéseket végezzen."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet megvizsgálni egy prezentáció információit az Aspose.Slides használatával. Ismerteti, hogyan határozható meg a prezentáció aktuális formátuma a teljes fájl betöltése nélkül, hogyan olvashatók ki a dokumentumtulajdonságai, és hogyan frissíthetők ezek a tulajdonságok szükség esetén.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/) API-ken alapulnak, és tipikus műveleteket mutatnak be a prezentáció metaadataival való munka során.

## **Ellenőrizze a prezentáció formátumát**

Mielőtt dolgozna egy prezentáción, érdemes megtudni, hogy jelenleg milyen formátumban (PPT, PPTX, ODP és egyebek) van a prezentáció.

A prezentáció formátumát a prezentáció betöltése nélkül is ellenőrizheti. Lásd a következő Python kódot:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Szerezze be a prezentáció tulajdonságait**

Ez a Python kód megmutatja, hogyan kérhető le a prezentáció tulajdonságai (információk a prezentációról):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Érdemes megtekinteni a [a DocumentProperties alatti tulajdonságok](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/#properties) osztályt.

## **Frissítse a prezentáció tulajdonságait**

Az Aspose.Slides a [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) metódust biztosítja, amely lehetővé teszi a prezentáció tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint prezentáció, amelynek a dokumentumtulajdonságai az alább láthatók.

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

Ez a kódrészlet megmutatja, hogyan szerkeszthet néhány prezentációtulajdonságot:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

A dokumentumtulajdonságok módosításának eredményei az alábbiakban láthatók.

![A PowerPoint prezentáció módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

A prezentációval és annak biztonsági attribútumaival kapcsolatos további információkért a következő hivatkozások lehetnek hasznosak:

- [Ellenőrzés, hogy a prezentáció titkosítva van-e](https://docs.aspose.com/slides/hu/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Ellenőrzés, hogy a prezentáció írásvédett (csak olvasható) legyen-e](https://docs.aspose.com/slides/hu/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Ellenőrzés, hogy a prezentáció jelszóval védett-e betöltés előtt](https://docs.aspose.com/slides/hu/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [A prezentációt védő jelszó megerősítése](https://docs.aspose.com/slides/hu/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek be vannak-e ágyazva, és melyek azok?**

Keresse a [beágyazott betűkészlet információkat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) a prezentáció szintjén, majd hasonlítsa össze ezeket a [ténylegesen használt betűkészletek](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_fonts/) halmazával, hogy azonosítsa, mely betűkészletek kritikusak a megjelenítéshez.

**Hogyan tudom gyorsan megállapítani, hogy a fájl rejtett diákot tartalmaz-e, és hány darabot?**

Iteráljon a [dia gyűjteményen](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/), és vizsgálja meg minden dia [láthatósági jelzőjét](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/hidden/).

**Felismerhetem-e, hogy egyéni dia méret és tájolás van-e használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Hasonlítsa össze a jelenlegi [dia méretet](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/slide_size/) és tájolást a szabványos előbeállításokkal; ez segít előre jelezni a nyomtatás és exportálás viselkedését.

**Van gyors mód arra, hogy lássam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Járja be az összes [diagramot](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/), ellenőrizze azok [adatforrását](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/data_source_type/), és jegyezze fel, hogy az adat belső vagy hivatkozáson alapul-e, beleértve a hibás hivatkozásokat is.

**Hogyan értékelhetem a 'nehéz' diákat, amelyek lassíthatják a renderelést vagy a PDF exportálást?**

Minden egyes diánál számolja meg az objektumok számát, és keresse a nagy képeket, átlátszóságot, árnyékokat, animációkat és multimédiát; rendeljön hozzá egy durva összetettségi pontszámot a lehetséges teljesítményproblémák jelzésére.
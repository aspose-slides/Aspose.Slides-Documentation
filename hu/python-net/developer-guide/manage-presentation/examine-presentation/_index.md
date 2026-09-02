---
title: Prezentációs információk lekérése és frissítése Pythonban
linktitle: Prezentációs információk
type: docs
weight: 30
url: /hu/python-net/examine-presentation/
keywords:
- prezentáció formátuma
- prezentáció tulajdonságai
- dokumentum tulajdonságai
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
description: "Fedezze fel a diákat, a szerkezetet és a metaadatokat PowerPoint és OpenDocument prezentációkban Python használatával a gyorsabb betekintés és okosabb tartalom auditok érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet megvizsgálni a prezentáció információit az Aspose.Slides-ban. Ismerteti, hogyan határozható meg egy prezentáció aktuális formátuma a teljes fájl betöltése nélkül, hogyan olvashatók ki a dokumentum tulajdonságai, és hogyan frissíthetőek ezek a tulajdonságok szükség esetén.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/) API-kon alapulnak, és bemutatják a prezentáció metaadatokkal való munka tipikus műveleteit.

## **Ellenőrizze a prezentáció formátumát**

Mielőtt egy prezentációval dolgozna, esetleg meg szeretné tudni, hogy a prezentáció jelenleg milyen formátumban (PPT, PPTX, ODP és egyebek) van.

Ellenőrizheti a prezentáció formátumát a prezentáció betöltése nélkül. Lásd ezt a Python kódot:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Szerezze meg a prezentáció tulajdonságait**

Ez a Python kód megmutatja, hogyan szerezhetők meg a prezentáció tulajdonságai (információk a prezentációról):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Előfordulhat, hogy meg szeretné tekinteni a [DocumentProperties osztály alatti tulajdonságokat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/#properties).

## **Frissítse a prezentáció tulajdonságait**

Az Aspose.Slides biztosítja a [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) metódust, amely lehetővé teszi a prezentáció tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint prezentációja az alább látható dokumentumtulajdonságokkal.

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

Ez a kódrészlet megmutatja, hogyan szerkeszthet néhány prezentációs tulajdonságot:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

A dokumentumtulajdonságok módosításának eredményei alább láthatók.

![A PowerPoint prezentáció módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

A prezentációval és annak biztonsági attribútumaival kapcsolatos további információkért ezek a hivatkozások lehetnek hasznosak:

- [Jelszóval védett prezentációk](/slides/hu/python-net/password-protected-presentation/)
- [Írásvédett prezentációk](/slides/hu/python-net/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűk be vannak ágyazva, és melyek azok?**  
Keresse a [beágyazott betűk információját](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) a prezentáció szintjén, majd hasonlítsa össze ezeket a bejegyzéseket a [valóban a tartalomban használt betűk](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_fonts/) halmazával, hogy azonosítsa, mely betűk kritikusak a megjelenítéshez.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz rejtett diákat, és ha igen, hányat?**  
Iteráljon a [dia gyűjteményen](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidecollection/), és vizsgálja meg minden dia [láthatósági jelzőjét](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/hidden/).

**Feldobhatom-e, hogy egyedi dia méret és orientáció van-e használatban, és hogy eltérnek-e az alapértelmezettektől?**  
Igen. Hasonlítsa össze a jelenlegi [dia méretet](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/slide_size/) és orientációt a szabványos előbeállításokkal; ez segít előre jelezni a nyomtatásra és exportálásra vonatkozó viselkedést.

**Van-e gyors módja annak, hogy lássam, a diagramok külső adatforrásokra hivatkoznak-e?**  
Igen. Járja be az összes [diagramot](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/), ellenőrizze azok [adatforrását](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/data_source_type/), és vegye figyelembe, hogy az adat belső vagy hivatkozáson alapul-e, beleértve a hibás hivatkozásokat is.

**Hogyan értékelhetem az 'nehéz' diákat, amelyek lelassíthatják a renderelést vagy a PDF exportot?**  
Minden diához számolja meg az objektumok mennyiségét, és keressen nagy képeket, átlátszóságot, árnyékokat, animációkat és multimédiát; adjon hozzá egy durva komplexitási pontszámot, hogy jelölje a lehetséges teljesítményproblémákat.
---
title: Címkék és egyedi adatok kezelése prezentációkban Python segítségével
linktitle: Címkék és egyedi adatok
type: docs
weight: 300
url: /hu/python-net/managing-tags-and-custom-data/
keywords:
- dokumentumtulajdonságok
- címke
- egyedi adat
- címke hozzáadása
- páros értékek
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet címkéket és egyedi adatokat hozzáadni, olvasni, frissíteni és eltávolítani az Aspose.Slides for Python via .NET‑ben, PowerPoint és OpenDocument prezentációkra vonatkozó példákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozik az Aspose.Slides címkékkel és egyedi adatokkal a PowerPoint‑prezentációkban. Röviden ismerteti, hogyan tárolódnak az adatok a PPTX‑fájlokban, megjegyzi, hogy a prezentációra jellemző adatok címkék és egyedi XML részek formájában is létezhetnek, és leírja a címkéket kulcs‑érték karakterlánc párokként.

Emellett bemutatja, hogyan lehet kiolvasni a címkék értékeit, valamint hogyan lehet címkéket hozzáadni egy prezentációhoz, egy adott diára vagy egy alakzathoz. Továbbá a cikk kitér a gyakori címke‑kezelési feladatokra, például az összes címke törlésére, egy címke nevével való eltávolítására és a címkék nevének listájának lekérésére.

## **Adattárolás a prezentációfájlokban**

A PPTX fájlok — azaz a .pptx kiterjesztésű elemek — a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML formátum határozza meg a prezentációkban tárolt adatok szerkezetét.

Mivel egy *dia* a prezentációk egyik eleme, egy *dia‑rész* tartalmazza egyetlen dia tartalmát. Egy dia‑résznek megengedett, hogy explicit kapcsolatokat tartalmazzon számos részhez — például a Felhasználó által definiált Címkékhez — amelyeket az ISO/IEC 29500 határoz meg.

Egyedi adatok (a prezentációra jellemző) vagy felhasználói adatok létezhetnek címkéként ([ITagCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/itagcollection/)) és CustomXmlParts‑ként ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 
A címkék lényegében karakterlánc kulcs‑érték párok. 
{{% /alert %}} 

## **Címkék értékének lekérése**

A diákban egy címke megfelel az IDocumentProperties.Keywords tulajdonságnak. Az alábbi példa kóddal megmutatjuk, hogyan lehet egy címke értékét lekérni az Aspose.Slides for Python via .NET [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályával:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Címkék hozzáadása a prezentációkhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- egy egyedi tulajdonság neve — `MyTag` 
- az egyedi tulajdonság értéke — `My Tag Value`

Ha bizonyos prezentációkat egy adott szabály vagy tulajdonság alapján szeretne csoportosítani, a címkék hozzáadása hasznos lehet. Például, ha a Észak‑Amerikai országokból származó prezentációkat szeretné egy helyen látni, létrehozhat egy „North American” címkét, és az értékekhez hozzárendelheti az érintett országokat (az USA, Mexikó és Kanada).

Az alábbi példa kóddal megmutatjuk, hogyan lehet egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumhoz címkét hozzáadni az Aspose.Slides for Python via .NET használatával:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Címkék beállíthatók [Slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/) esetén is:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Vagy bármely egyedi [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) esetén:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Korlátozások**

A `custom_data.tags` gyűjteményen keresztül hozzáadott címkék csak a PowerPoint‑fájlban tárolódnak. **Nem** kerülnek átvitelre a PDF‑címkeszerkezetbe, ha a prezentációt PDF‑be exportálják. Ennek következtében egy egyedi azonosító, amelyet címkeként rendeltünk, nem hívható le a címkézett PDF‑ből.

**Megoldás**: Tárolhat egy egyedi azonosítót az objektum **Alt Text** mezőjében (például `shape.alternative_text = "MyId"`). PDF‑export után az Alt Text megjelenhet a PDF‑címkeszerkezetben.

## **GYIK**

**Eltávolíthatom az összes címkét egy prezentációból, diából vagy alakzatból egy lépésben?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/clear/) műveletet, amely egyszerre törli az összes kulcs‑érték párt.

**Hogyan törölhetek egyetlen címkét a nevével anélkül, hogy végigjárnám az egész gyűjteményt?**

Használja a [remove(name)](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/remove/) műveletet a [TagCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/) objektumon a címke kulcs szerinti törléséhez.

**Hogyan kérhetem le a címkék teljes neves listáját elemzéshez vagy szűréshez?**

Használja a [get_names_of_tags](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/get_names_of_tags/) metódust a [tag collection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/tagcollection/) esetén; ez egy tömböt ad vissza az összes címkenévvel.
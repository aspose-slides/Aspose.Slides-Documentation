---
title: Címkék és egyéni adatok kezelése a prezentációkban .NET-ben
linktitle: Címkék és egyéni adatok
type: docs
weight: 300
url: /hu/net/managing-tags-and-custom-data/
keywords:
- dokumentumtulajdonságok
- címke
- egyéni adatok
- címke hozzáadása
- páros értékek
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tudja meg, hogyan adhat hozzá, olvashat, frissíthet és távolíthat el címkéket és egyéni adatokat az Aspose.Slides for .NET-ben, példákkal a PowerPoint és az OpenDocument prezentációkhoz."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan működik az Aspose.Slides a címkékkel és egyéni adatokkal a PowerPoint‑prezentációkban. Röviden bemutatja, hogyan tárolódnak az adatok a PPTX‑fájlokban, megjegyzi, hogy a prezentációra jellemző adatok címkék és egyéni XML‑részek formájában létezhetnek, és leírja a címkéket kulcs‑érték karakterlánc pároként.

Megmutatja továbbá, hogyan olvashatók ki a címkék értékei és hogyan adhatók hozzá címkék egy prezentációhoz, egyetlen diára vagy alakzatra. Emellett a cikk bemutatja a gyakori címke‑kezelési feladatokat, például az összes címke törlését, egy címke nevének szerinti eltávolítását és a címkenevek listájának lekérését.

## **Adattárolás a prezentációfájlokban**

A PPTX fájlok—a .pptx kiterjesztésű elemek— a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML formátum meghatározza a prezentációkban tárolt adatok szerkezetét.

Mivel a *dia* a prezentációk egyik eleme, egy *dia rész* tartalmazza egyetlen dia tartalmát. Egy dia résznek megengedett, hogy explicit kapcsolatokat tartalmazzon számos részhez — például a felhasználó által definiált címkékhez — amelyet az ISO/IEC 29500 határoz meg.

Az egyéni adatok (egy prezentációra jellemzőek) vagy a felhasználó létezhetnek címkéként ([ITagCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/itagcollection)) és CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/icustomxmlpartcollection)).

{{% alert color="primary" %}} 
A címkék lényegében karakterlánc‑kulcs páros értékek. 
{{% /alert %}} 

## **Címkék értékének lekérése**

A diákban egy címke az IDocumentProperties.Keywords tulajdonsággal felel meg. Ez a mintakód bemutatja, hogyan lehet lekérni egy címke értékét az Aspose.Slides for .NET segítségével a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) esetén:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Címkék hozzáadása a prezentációkhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- egy egyéni tulajdonság neve – `MyTag`
- az egyéni tulajdonság értéke – `My Tag Value`

Ha néhány prezentációt egy konkrét szabály vagy tulajdonság alapján kell osztályozni, akkor hasznos lehet címkék hozzáadása ezekhez a prezentációkhoz. Például, ha az összes Észak‑amerikai ország prezentációit egy csoportba szeretné sorolni, létrehozhat egy Észak‑amerikai címkét, és a megfelelő országokat (az USA‑t, Mexikót és Kanadát) a címke értékeiként hozzárendelheti.

Ez a mintakód bemutatja, hogyan adhatunk hozzá egy címkét egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektumhoz az Aspose.Slides for .NET használatával:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

A címkéket a [Slide](https://reference.aspose.com/slides/hu/net/aspose.slides/slide) esetén is beállíthatja:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Vagy bármely egyéni [Shape](https://reference.aspose.com/slides/hu/net/aspose.slides/shape) esetén:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Korlátozások**

A `CustomData.Tags` gyűjteményen keresztül hozzáadott címkék csak a PowerPoint‑fájlban tárolódnak. A **nem** kerülnek át a PDF címkeszerkezetbe, amikor a prezentációt PDF‑be exportálják. Ennek következtében egy címkeként hozzárendelt egyéni azonosító nem kérhető le a címkézett PDF‑ből.

**Megoldás**: Tárolhat egy egyéni azonosítót az objektum **Alt Text** mezőjében (pl. `shape.AlternativeText = "MyId"`). PDF‑be exportálás után az Alt Text megjelenhet a PDF címkeszerkezetben.

## **GYIK**

**Eltávolíthatok minden címkét egy prezentációból, diából vagy alakzatról egyetlen műveletben?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/clear/) műveletet, amely egyszerre törli az összes kulcs‑érték párt.

**Hogyan törölhetek egyetlen címkét a nevének megadása alapján anélkül, hogy végigiterálnék a teljes gyűjteményen?**

Használja a [Remove(name)](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/remove/) műveletet a [TagCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/) objektumon a címke kulcsa szerinti törléshez.

**Hogyan kérhetem le a címkék teljes nevek listáját elemzéshez vagy szűréshez?**

Használja a [GetNamesOfTags](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/getnamesoftags/) metódust a [tag collection](https://reference.aspose.com/slides/hu/net/aspose.slides/tagcollection/) objektumon; ez egy tömböt ad vissza az összes címkenévvel.
---
title: Címkék és egyéni adatok kezelése bemutatókban C++ használatával
linktitle: Címkék és egyéni adatok
type: docs
weight: 300
url: /hu/cpp/managing-tags-and-custom-data/
keywords:
- dokumentum tulajdonságok
- címke
- egyéni adatok
- címke hozzáadása
- páros értékek
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, olvashat, frissíthet és távolíthat el címkéket és egyéni adatokat az Aspose.Slides for C++-ben, PowerPoint és OpenDocument bemutatók példáival."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan működik az Aspose.Slides a címkékkel és egyéni adatokkal a PowerPoint‑bemutatókban. Röviden ismerteti, hogyan tárolódnak az adatok a PPTX‑fájlokban, megjegyzi, hogy a bemutatóra jellemző adatok címkék és egyéni XML‑részek formájában is létezhetnek, és leírja a címkéket kulcs‑érték string párokként.

Emellett bemutatja, hogyan lehet címkeértékeket kiolvasni, illetve címkéket hozzáadni egy bemutatóhoz, egy adott diához vagy egy alakzathoz. Továbbá tárgyalja a gyakori címke‑kezelési feladatokat, például az összes címke törlését, egy címke eltávolítását név szerint, illetve a címkenév‑lista lekérését.

## **Adattárolás a bemutató fájlokban**

A .pptx kiterjesztésű PPTX‑fájlok a PresentationML formátumban vannak tárolva, amely az Office Open XML specifikáció része. Az Office Open XML formátum határozza meg a bemutatókban tárolt adatok szerkezetét.

A *dia* a bemutatók elemei közé tartozik, egy *dia‑rész* egyetlen dia tartalmát tartalmazza. Egy dia‑résznek explicite kapcsolatai lehetnek sok részhez – például a felhasználó által definiált címkékhez – amelyeket az ISO/IEC 29500 definiál.

Egyéni adat (a bemutatóra specifikus) vagy felhasználó létezhet címkeként ([ITagCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itagcollection/)) és CustomXmlParts‑ként ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 

A címkék lényegében string‑kulcs párok.

{{% /alert %}} 

## **Címkék értékeinek lekérése**

A slide‑okban egy címke megfelel az IDocumentProperties.Keywords tulajdonságnak. Ez a mintakód megmutatja, hogyan olvasható ki egy címke értéke az Aspose.Slides for C++ használatával a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) esetén:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Címkék hozzáadása a bemutatókhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a bemutatókhoz. Egy címke általában két elemből áll:

- a egyéni tulajdonság neve - `MyTag`
- a egyéni tulajdonság értéke - `My Tag Value`

Ha szeretné egyes bemutatókat egy adott szabály vagy tulajdonság alapján osztályozni, akkor hasznos lehet a címkék használata. Például, ha az összes észak‑amerikai országból származó bemutatót egy csoportba szeretné rendezni, létrehozhat egy „North American” címkét, és hozzárendelheti a megfelelő országokat (az USA‑t, Mexikót és Kanadát) értékként.

Ez a mintakód megmutatja, hogyan adhat hozzá egy címkét egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumhoz az Aspose.Slides for C++ használatával:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Címkék állíthatók be [Slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/) esetén is:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Vagy egy adott [Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/) esetén:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Korlátozások**

A `get_CustomData()->get_Tags()` segítségével a saját adatcímke‑gyűjteménybe felvett címkék csak a PowerPoint‑fájlban tárolódnak. **Nem** kerülnek át a PDF‑címke‑struktúrába, amikor a bemutató PDF‑be exportálódik. Ennek következtében a címkeként hozzárendelt egyéni azonosító nem hívható le a címkézett PDF‑ből.

**Megoldás**: A saját azonosítót tárolhatja az objektum **Alt Text**‑ében (például `shape->set_AlternativeText(u"MyId")`). PDF‑export után az Alt Text megjelenhet a PDF‑címke‑struktúrában.

## **GYIK**

**Eltávolíthatok minden címkét egy bemutatóból, diából vagy alakzatból egyetlen művelettel?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/clear/) műveletet, amely egyszerre törli az összes kulcs‑érték párt.

**Hogyan törölhetek egyetlen címkét a neve alapján anélkül, hogy végigjárnám a teljes gyűjteményt?**

Használja a [Remove(name)](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/remove/) műveletet a [TagCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/)‑n, hogy a kulcs szerint törölje a címkét.

**Hogyan kérhetem le a címkenév‑lista teljes sorát elemzés vagy szűrés céljából?**

Használja a [GetNamesOfTags](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/getnamesoftags/) metódust a [tag collection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/tagcollection/)‑n; ez egy tömböt ad vissza az összes címkenévvel.
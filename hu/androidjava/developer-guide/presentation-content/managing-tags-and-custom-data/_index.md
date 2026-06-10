---
title: Címkék és egyéni adatok kezelése a prezentációkban Androidon
linktitle: Címkék és egyéni adatok
type: docs
weight: 300
url: /hu/androidjava/managing-tags-and-custom-data
keywords:
- dokumentum tulajdonságok
- címke
- egyéni adatok
- címke hozzáadása
- páros értékek
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Címkék és egyéni adatok hozzáadása, olvasása, frissítése és eltávolítása az Aspose.Slides for Androidban, Java példákkal PowerPoint és OpenDocument prezentációk esetén."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan működik az Aspose.Slides a címkékkel és az egyéni adatokkal a PowerPoint‑prezentációkban. Röviden ismerteti, hogyan tárolódnak az adatok a PPTX‑fájlokban, megjegyzi, hogy a prezentációra specifikus adatok létezhetnek címkék és egyéni XML‑részek formájában, és leírja a címkéket kulcs‑érték karakterlánc párokként. A cikk bemutatja továbbá, hogyan olvashatók ki a címkeértékek és hogyan adhatók hozzá címkék egy prezentációhoz, egy adott diára vagy egy alakzathoz. Emellett a cikk lefedi a gyakori címke‑kezelési feladatokat, mint például az összes címke törlése, egy címke nevének alapján történő eltávolítása és a címkék nevének listájának lekérdezése.

## **Az adatok tárolása a prezentációs fájlokban**

A .pptx kiterjesztésű PPTX‑fájlok a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML formátum határozza meg a prezentációkban tárolt adatok szerkezetét.

Mivel a *dia* a prezentációk elemei közé tartozik, egy *dia rész* (slide part) egyetlen dia tartalmát tartalmazza. Egy dia résznek engedélyezett a kifejezett kapcsolata több részhez — például a felhasználó által definiált címkékhez — amelyeket az ISO/IEC 29500 definiál.

Az egyéni adatok (a prezentációra jellemző) vagy a felhasználó létezhet címkéként ([ITagCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITagCollection)) és CustomXmlParts‑ként ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
A címkék lényegében karakterlánc‑kulcs páros értékek. 
{{% /alert %}} 

## **Címkeértékek lekérése**

A diák esetében egy címke megfelel az [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) és [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) metódusoknak. Ez a példakód megmutatja, hogyan lehet lekérni egy címke értékét az Aspose.Slides for Android Java‑környezetben a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation)-hez:

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Címkék hozzáadása a prezentációkhoz**

Az Aspose.Slides lehetővé teszi, hogy címkéket adjunk a prezentációkhoz. Egy címke általában két elemből áll:
- egy egyéni tulajdonság neve – `MyTag`
- egyéni tulajdonság értéke – `My Tag Value`

Ha bizonyos prezentációkat egy adott szabály vagy tulajdonság alapján szeretnél osztályozni, akkor előnyös lehet címkék hozzáadása ezekhez a prezentációkhoz. Például, ha az Észak‑Amerikai országokból származó prezentációkat egy csoportba kívánod helyezni, létrehozhatsz egy „Észak‑Amerikai” címkét, és hozzárendelheted a megfelelő országokat (az USA‑t, Mexikót és Kanadát) értékként.

Ez a példakód megmutatja, hogyan lehet egy címkét hozzáadni egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation)-hez az Aspose.Slides for Android Java‑környezetben:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

A címkék beállíthatók a [Slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlide)-nél is:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Vagy bármely egyedi [Shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape)-nél:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Korlátozások**

A `getCustomData().getTags()` használatával a saját adatcímke‑gyűjteménybe hozzáadott címkék csak a PowerPoint‑fájlban tárolódnak. **Nem** kerülnek át a PDF‑címke struktúrába, amikor a prezentáció PDF‑be exportálódik. Ennek következtében egy egyéni azonosító, amelyet címkének adtunk, nem kérhető le a címkézett PDF‑ből.

**Megoldás**: Egy egyéni azonosítót elhelyezhetsz az objektum **Alt Text**‑ében (pl. `shape.setAlternativeText("MyId")`). PDF‑be exportálás után az Alt Text megjelenhet a PDF‑címke struktúrában.

## **GYIK**

**Eltávolíthatok minden címkét a prezentációból, diából vagy alakzatból egyetlen művelettel?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/#clear--) műveletet, amely egyszerre törli az összes kulcs‑érték párt.

**Hogyan törölhetek egyetlen címkét a nevével anélkül, hogy végigiterálnék a teljes gyűjteményen?**

Használd a [remove(name)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) műveletet a [tag collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/)‑en, hogy a kulcs alapján töröld a címkét.

**Hogyan tudom lekérni a címkék teljes neves listáját elemzéshez vagy szűréshez?**

Használd a [getNamesOfTags](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) metódust a [tag collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tagcollection/)-on; ez egy tömböt ad vissza az összes címkenévvel.
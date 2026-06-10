---
title: Címkék és egyéni adatok kezelése prezentációkban Java-val
linktitle: Címkék és egyéni adatok
type: docs
weight: 300
url: /hu/java/managing-tags-and-custom-data/
keywords:
- dokumentum tulajdonságok
- címke
- egyéni adatok
- címke hozzáadása
- páros értékek
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, olvashat, frissíthet és távolíthat el címkéket és egyéni adatokat az Aspose.Slides for Java-ban, PowerPoint és OpenDocument prezentációkra vonatkozó példákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan működik az Aspose.Slides a címkékkel és egyéni adatokat tartalmazó PowerPoint‑prezentációkkal. Röviden ismerteti, hogyan tárolódnak az adatok PPTX fájlokban, megjegyzi, hogy a bemutatóra jellemző adatok létezhetnek címkék és egyéni XML részek formájában, valamint leírja a címkéket kulcs‑érték páros karakterláncokként.

Megmutatja, hogyan lehet kiolvasni a címke értékeket, illetve hogyan lehet címkéket hozzáadni egy prezentációhoz, egyetlen diára vagy egy alakzatra. Emellett a cikk lefedi a gyakori címke‑kezelési feladatokat, például az összes címke törlését, egy címke nevével történő eltávolítását, valamint a címkenév‑lista lekérését.

## **Adattárolás a bemutató fájlokban**

A PPTX fájlok – a .pptx kiterjesztésű elemek – a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML formátum határozza meg a prezentációkban tárolt adatok szerkezetét.

Mivel a *slide* a prezentációk egyik eleme, egy *slide part* egyetlen dia tartalmát tartalmazza. Egy slide partnak megengedett, hogy explicit kapcsolatokat tartson fenn számos más részhez – például a Felhasználó által definiált címkékhez – amelyeket az ISO/IEC 29500 definiál.

Az egyéni adatok (a prezentációra jellemző) vagy a felhasználó létezhetnek címkéként ([ITagCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITagCollection)) és CustomXmlParts‑ként ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

A címkék lényegében karakterlánc‑kulcs páros értékek. 

{{% /alert %}} 

## **Címkék értékeinek lekérése**

A diákban egy címke a [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IDocumentProperties#getKeywords--) és a [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) metódusoknak felel meg. Ez a mintakód azt mutatja be, hogyan lehet egy címke értékét lekérni az Aspose.Slides for Java segítségével a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) esetén:

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Címkék hozzáadása a bemutatókhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- a saját tulajdonság neve - `MyTag`  
- a saját tulajdonság értéke - `My Tag Value`

Ha bizonyos prezentációkat egy adott szabály vagy tulajdonság alapján szeretnél kategorizálni, hasznos lehet címkék hozzáadása ezekhez a prezentációkhoz. Például, ha az Észak‑amerikai országokból származó prezentációkat egyesíteni szeretnéd, létrehozhatsz egy Észak‑amerikai címkét, majd hozzárendelheted a megfelelő országokat (az USA, Mexikó és Kanada) értékként.

Ez a mintakód azt mutatja be, hogyan lehet egy címkét hozzáadni egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) objektumhoz az Aspose.Slides for Java használatával:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

A címkék beállíthatók [Slide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlide) esetén is:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Vagy bármely egyedi [Shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) esetén:

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

A `getCustomData().getTags()` használatával a saját adatcímke‑gyűjteményen keresztül hozzáadott címkék csak a PowerPoint‑fájlban tárolódnak. **Nem** kerülnek át a PDF‑címkeszerkezetbe, amikor a prezentációt PDF‑ként exportálod. Ennek következtében egy címkeként hozzárendelt egyéni azonosítót nem lehet lekérni a címkézett PDF‑ből.

**Megoldás**: Egy egyéni azonosítót tárolhatsz az objektum **Alt Text**‑ében (például `shape.setAlternativeText("MyId")`). PDF‑export után az Alt Text megjelenhet a PDF‑címkeszerkezetben.

## **GYIK**

**Eltávolíthatok minden címkét egy bemutatóból, diából vagy alakzatról egy műveletben?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/) támogatja a [clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/#clear--) műveletet, amely egy lépésben törli az összes kulcs‑érték párt.

**Hogyan törölhetek egyetlen címkét a neve alapján anélkül, hogy végigiterálnék a teljes gyűjteményen?**

Használd a [Remove(name)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) műveletet a [tag collection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/)‑on, hogy a kulcs szerint töröld a címkét.

**Hogyan kaphatom meg a címkék teljes listáját elemzéshez vagy szűréshez?**

Használd a [getNamesOfTags](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/#getNamesOfTags--) metódust a [tag collection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tagcollection/)‑on; ez egy tömböt ad vissza az összes címkenévvel.
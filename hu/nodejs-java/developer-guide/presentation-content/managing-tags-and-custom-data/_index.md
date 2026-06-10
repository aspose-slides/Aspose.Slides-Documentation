---
title: Címkék és egyéni adatok kezelése a prezentációkban JavaScript használatával
linktitle: Címkék és egyéni adatok
type: docs
weight: 300
url: /hu/nodejs-java/managing-tags-and-custom-data/
keywords:
- dokumentumtulajdonságok
- címke
- egyéni adatok
- címke hozzáadása
- páros értékek
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá, olvashat, frissíthet és távolíthat el címkéket és egyéni adatokat az Aspose.Slides for Node.js-ben, példákkal a PowerPoint és OpenDocument prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan működik az Aspose.Slides a címkékkel és az egyéni adatokkal a PowerPoint‑prezentációkban. Röviden ismerteti, hogyan tárolódik az adat a PPTX‑fájlokban, megjegyzi, hogy a prezentációra jellemző adatok létezhetnek címkék és egyéni XML‑részek formájában, valamint leírja a címkéket kulcs‑érték string pároként.

Emellett bemutatja, hogyan olvashatók a címkeértékek, illetve hogyan adhatók hozzá címkék egy prezentációhoz, egy egyedi diára vagy egy alakzathoz. Továbbá a cikk áttekinti a gyakori címke‑kezelési feladatokat, mint például az összes címke törlése, egy címke név alapján történő eltávolítása és a címkenévek listájának lekérése.

## **Adattárolás a bemutató fájlokban**

A .pptx kiterjesztésű PPTX‑fájlok a PresentationML formátumban tárolódnak, amely az Office Open XML specifikáció része. Az Office Open XML formátum meghatározza a prezentációkban tárolt adatok szerkezetét.

A *dia* a prezentációk egyik eleme, egy *dia rész* tartalmazza egyetlen dia tartalmát. A dia résznek kifejezett kapcsolatot lehet tartalmaznia sok részhez – például a felhasználó által definiált címkékhez – melyeket az ISO/IEC 29500 definiál.

Egyéni adatok (a prezentációra jellemző) vagy felhasználóként létezhetnek címkéként ([TagCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TagCollection)) és CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 
A címkék alapvetően karakterlánc‑kulcs páros értékek. 
{{% /alert %}} 

## **Címkék értékeinek lekérése**

A diákban egy címke a [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) és a [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) metódóknak felel meg. Ez a példa kód bemutatja, hogyan szerezhető meg egy címke értéke az Aspose.Slides for Node.js via Java segítségével a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) esetén:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Címkék hozzáadása a bemutatókhoz**

Az Aspose.Slides lehetővé teszi címkék hozzáadását a prezentációkhoz. Egy címke általában két elemből áll:

- az egyéni tulajdonság neve – `MyTag`  
- az egyéni tulajdonság értéke – `My Tag Value`

Ha bizonyos prezentációkat egy adott szabály vagy tulajdonság alapján szeretnél osztályozni, akkor hasznos lehet, ha címkéket adsz hozzá azokhoz a prezentációkhoz. Például, ha az Észak‑Amerikai országokból származó összes prezentációt egy kategóriába szeretnéd sorolni, létrehozhatsz egy Észak‑Amerikai címkét, majd a megfelelő országok (az USA, Mexikó és Kanada) neveit adhatod meg értékként.

Ez a példa kód bemutatja, hogyan adhatunk hozzá egy címkét egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) objektumhoz az Aspose.Slides for Node.js via Java használatával:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Címkék beállíthatók egy [Slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Slide) esetén is:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Vagy bármely egyedi [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) esetén:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Korlátozások**

A `getCustomData().getTags()` segítségével a saját adatcímke‑gyűjteményhez hozzáadott címkék csak a PowerPoint‑fájlban tárolódnak. A **nem** kerülnek át a PDF‑címkeszerkezetbe, amikor a prezentáció PDF‑re exportálódik. Ennek következtében egy címkéként rendelt egyéni azonosító nem kérhető le a címkézett PDF‑ből.

**Megelőző megoldás**: Tárolhatsz egy egyéni azonosítót az objektum **Alt Text**‑ében (pl. `shape.setAlternativeText("MyId")`). PDF‑re exportálás után az Alt Text megjelenhet a PDF‑címkeszerkezetben.

## **GYIK**

**Eltávolíthatok minden címkét egy prezentációból, diából vagy alakzatból egyetlen művelettel?**

Igen. A [tag collection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tagcollection/) támogat egy [clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tagcollection/clear/) műveletet, amely egyszerre törli az összes kulcs‑érték párost.

**Hogyan töröljek egyetlen címkét a neve alapján anélkül, hogy végig iterálnám az egész gyűjteményt?**

Használd a [remove(name)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tagcollection/remove/) műveletet a [TagCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tagcollection/)‑on a címke kulcsa szerinti törléshez.

**Hogyan kaphatom vissza a címkenév‑listát elemzés vagy szűrés céljából?**

Használd a [getNamesOfTags](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tagcollection/getnamesoftags/)‑t a [tag collection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tagcollection/); ez egy tömböt ad vissza az összes címkenévről.
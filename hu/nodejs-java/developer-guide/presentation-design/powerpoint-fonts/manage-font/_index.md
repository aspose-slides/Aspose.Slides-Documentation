---
title: Betűtípusok kezelése bemutatókban JavaScript segítségével
linktitle: Betűtípusok kezelése
type: docs
weight: 10
url: /hu/nodejs-java/manage-fonts/
keywords:
- betűtípusok kezelése
- betűtípus tulajdonságok
- bekezdés
- szövegformázás
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "A betűtípusok irányítása az Aspose.Slides for Node.js via Java segítségével: beágyazás, helyettesítés és egyéni betűtípusok betöltése a PPT, PPTX és ODP bemutatók tisztaságának és konzisztenciájának megőrzéséhez."
---
## **Bevezetés**

Az előadások általában szöveget és képeket egyaránt tartalmaznak. A szöveget különféle módon lehet formázni, akár egyes szakaszok és szavak kiemelésére, vagy a vállalati stílusnak megfelelően. A szövegformázás lehetővé teszi a felhasználók számára, hogy változatos megjelenést biztosítsanak a bemutató tartalmának. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for Node.js via Java a diákon lévő bekezdések betűtípus‑tulajdonságainak beállítására.

## **Betűtípusra vonatkozó tulajdonságok kezelése**

A betűtípus‑tulajdonságok kezeléséhez egy bekezdésben az Aspose.Slides for Node.js via Java használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
1. Szerezze meg egy dia hivatkozását a indexe alapján.
1. Érje el a [Placeholder](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/placeholder/) alakzatokat a dián, és alakítsa át őket [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) típusúra.
1. Szerezze be a [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) objektumot a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑ből, amelyet az [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) szolgáltat.
1. Igazítsa a bekezdést.
1. Érje el egy [Paragraph](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/) szövegének [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) elemét.
1. Definiálja a betűtípust a [FontData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontdata/) segítségével, és állítsa be a **Font** értékét a szöveg [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) megfelelően.
   1. Állítsa be a betűtípust félkövérre.
   1. Állítsa be a betűtípust dőltre.
1. Állítsa be a betűszínét a [FillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/) segítségével, amelyet a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) objektum szolgáltat.
1. Mentse a módosított bemutatót PPTX fájlba.

A fenti lépések megvalósítása alább látható. Egy egyszerű bemutatót vesz alapul, és formázza a betűtípusokat az egyik dián. Az alábbi képernyőképek a bemeneti fájlt és a kódrészletek által végzett módosításokat mutatják. A kód megváltoztatja a betűtípust, a színt és a betűstílust.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Ábra: A szöveg a bemeneti fájlban**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Ábra: Ugyanaz a szöveg frissített formázással**|

```javascript
// Létrehozza a Presentation objektumot, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Diát ér el a pozíciója alapján
    var slide = pres.getSlides().get_Item(0);
    // A dián lévő első és második placeholder elérése, és AutoShape típusra konvertálása
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Az első bekezdés elérése
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // A bekezdés igazítása
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Az első rész (portion) elérése
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Új betűtípusok meghatározása
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Új betűtípusok hozzárendelése a részhez
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // A betűtípust félkövérre állítja
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // A betűtípust dőltre állítja
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // A betűtípus színének beállítása
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // A PPTX mentése lemezre
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Szöveg betűtípusának beállítása**
{{% alert color="primary" %}} 

Amint a **Betűtípusra vonatkozó tulajdonságok kezelése** részben említettük, egy [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) használatos a hasonló formázású szöveg egy bekezdésben való tárolására. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for Node.js via Java egy szövegdoboz létrehozására, szöveg hozzáadására, majd egy adott betűtípus és a betűcsalád egyéb tulajdonságainak meghatározására.

{{% /alert %}} 

Egy szövegdoboz létrehozásához és a benne lévő szöveg betűtípus‑tulajdonságainak beállításához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
1. Szerezze meg egy dia hivatkozását a indexe alapján.
1. Adjon egy **Rectangle** típusú [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
1. Távolítsa el az [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/)‑hez kapcsolódó kitöltési stílust.
1. Hozzáférjen az [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumához.
1. Adjon szöveget a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑hez.
1. Hozzáférjen a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) objektumhoz, amely a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/)‑hez tartozik.
1. Definiálja a betűtípust, amelyet a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) használ.
1. Állítson be további betűtípus‑tulajdonságokat, például félkövér, dőlt, aláhúzott, szín és magasság, a [Portion](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portion/) objektum által biztosított megfelelő tulajdonságokkal.
1. Írja ki a módosított bemutatót PPTX fájlként.

A fenti lépések megvalósítása alább látható.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Ábra: Szöveg néhány betűtípus‑tulajdonsággal, amelyet az Aspose.Slides for Node.js via Java állít be**|

```javascript
// Létrehozza a Presentation objektumot, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Az első dia lekérése
    var sld = pres.getSlides().get_Item(0);
    // Egy Rectangle típusú AutoShape hozzáadása
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Az AutoShape-hez társított kitöltési stílus eltávolítása
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Az AutoShape-hez tartozó TextFrame elérése
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // A TextFrame-hez tartozó Portion elérése
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // A Portion betűtípusának beállítása
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // A betűtípus félkövér tulajdonságának beállítása
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // A betűtípus dőlt tulajdonságának beállítása
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // A betűtípus aláhúzási tulajdonságának beállítása
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // A betűtípus magasságának beállítása
    port.getPortionFormat().setFontHeight(25);
    // A betűtípus színének beállítása
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // A bemutató lemezre mentése
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
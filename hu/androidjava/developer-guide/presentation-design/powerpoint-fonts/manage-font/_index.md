---
title: Betűtípusok kezelése bemutatókban Androidon
linktitle: Betűtípusok kezelése
type: docs
weight: 10
url: /hu/androidjava/manage-fonts/
keywords:
- betűtípusok kezelése
- betűtípus tulajdonságok
- bekezdés
- szövegformázás
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "A betűtípusok vezérlése Java-ban az Aspose.Slides for Android segítségével: beágyazás, helyettesítés és egyedi betűtípusok betöltése, hogy a PPT, PPTX és ODP bemutatók tiszták, márkaszabályoknak megfelelőek és konzisztensnek maradjanak."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a betűtípus tulajdonságainak kezelését a bemutató szövegében közvetlenül a kódból. Szöveget érhet el a diákon alakzatokon, szövegkereteken, bekezdéseken és részeken (Portion) keresztül, majd formázhatja a kiválasztott szöveget.

Ez a cikk bemutatja, hogyan állítható be a betűtípusra vonatkozó tulajdonságok a meglévő szöveghez egy bemutatóban, beleértve a betűcsaládot, a félkövér és dőlt stílusokat, a bekezdés igazítását és a betűszínt. Emellett megmutatja, hogyan hozhat létre egy szövegdobozt, adhat hozzá szöveget, és állíthatja be a betűtípus tulajdonságait, például a betűcsaládot, félkövér, dőlt, aláhúzott, betűméret és szín, mielőtt a eredményt PPTX fájlként mentené.

## **Betűtípushoz kapcsolódó tulajdonságok kezelése**
{{% alert color="primary" %}} 

A bemutatók általában szöveget és képeket egyaránt tartalmaznak. A szöveget különféleképpen lehet formázni, akár kiemelve bizonyos részeket és szavakat, akár a vállalati stílusoknak megfelelően. A szövegformázás segít a felhasználóknak változatosabbá tenni a bemutató tartalmának megjelenését. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for Android via Java a diák szövegbekezdéseinek betűtípus‑tulajdonságainak konfigurálásához.
{{% /alert %}} 

Az Aspose.Slides for Android via Java használatával a bekezdés betűtípus‑tulajdonságainak kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Szerezze meg a dia hivatkozását az indexének használatával.
1. Érje el a dia [Placeholder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholder/) alakzatait, és alakítsa át őket [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/)‑ra.
1. Szerezze meg a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) elemet a [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) által kitetts [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/)-ből.
1. Igazítsa a bekezdést.
1. Érje el egy [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) szövegének [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) elemét.
1. Határozza meg a betűtípust a [FontData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontdata/) segítségével, és állítsa be a szöveg [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) **Font** tulajdonságát ennek megfelelően.
   1. Állítsa be a betűtípust félkövérre.
   1. Állítsa be a betűtípust dőltre.
1. Állítsa be a betűszínt a [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) objektum által kitetts [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) segítségével.
1. Mentse a módosított bemutatót egy PPTX fájlba.

Az előző lépések megvalósítása alább látható. Egy egyszerű bemutatót vesz alapul, és formázza a betűtípusokat egy dián. Az alábbi képernyőképek a bemeneti fájlt és a kódrészletek által végzett változtatásokat mutatják. A kód megváltoztatja a betűtípust, a színt és a betűstílust.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Ábra: A szöveg a bemeneti fájlban**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Ábra: Ugyanaz a szöveg frissített formázással**|

```java
// Példányosít egy Presentation objektumot, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Diát ér el a dia pozíciója alapján
	ISlide slide = pres.getSlides().get_Item(0);

	// Az első és második placeholder-t érjük el a dián, és AutoShape‑ként típuskényszerítjük
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Az első bekezdést érjük el
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// A bekezdést igazítjuk
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Az első részt (portion) érjük el
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Új betűtípusok definiálása
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Új betűtípusok hozzárendelése a részhez
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Betűtípust félkövérre állítjuk
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Betűtípust dőltre állítjuk
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Betűszín beállítása
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// A PPTX mentése lemezre
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Szöveg betűtípus‑tulajdonságainak beállítása**
{{% alert color="primary" %}} 

Az **Betűtípushoz kapcsolódó tulajdonságok kezelése** részben említett módon, a [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) a bekezdésben hasonló formázási stílussal rendelkező szöveget tárolja. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for Android via Java egy szövegdoboz létrehozásához némi szöveggel, majd egy adott betűtípus és a betűcsalád kategória különféle egyéb tulajdonságainak meghatározásához.

Az alábbi lépések elvégzéséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Szerezze meg egy dia hivatkozását az indexének használatával.
1. Adjon hozzá egy **Rectangle** típusú [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) alakzatot a diára.
1. Távolítsa el a [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) alakzathoz tartozó kitöltési stílust.
1. Érje el a [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/) elemét.
1. Adjon hozzá szöveget a [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/)-hez.
1. Érje el a [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/)‑hez tartozó [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) objektumot.
1. Határozza meg a [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) számára használandó betűtípust.
1. Állítsa be a többi betűtípus tulajdonságot, például félkövér, dőlt, aláhúzott, szín és magasság, a [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) objektum által biztosított megfelelő tulajdonságok használatával.
1. Írja ki a módosított bemutatót PPTX fájlként.

Az előző lépések megvalósítása alább látható.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Ábra: Szöveg néhány betűtípus‑tulajdonsággal, amelyet az Aspose.Slides for Android via Java állított be**|

```java
// Példányosít egy Presentation objektumot, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
	// Az első diát lekéri
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Hozzáad egy Rectangle típusú AutoShape‑t
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Eltávolítja az AutoShape‑hez kapcsolódó kitöltési stílust
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Eléri az AutoShape‑hez kapcsolódó TextFrame‑et
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Eléri a TextFrame‑hez kapcsolódó Portion‑t
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Beállítja a betűtípust a Portion számára
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// A betűtípus Félkövér tulajdonságát állítja be
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// A betűtípus Dőlt tulajdonságát állítja be
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// A betűtípus Aláhúzás tulajdonságát állítja be
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Beállítja a betűtípus magasságát
	port.getPortionFormat().setFontHeight(25);
	
	// Beállítja a betűtípus színét
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Mentse a bemutatót a lemezre
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
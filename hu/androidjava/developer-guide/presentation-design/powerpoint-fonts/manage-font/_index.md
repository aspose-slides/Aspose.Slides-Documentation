---
title: Androidon a prezentációk betűtípusainak kezelése
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
- prezentáció
- Android
- Java
- Aspose.Slides
description: "A betűtípusok irányítása Java-ban az Aspose.Slides for Android segítségével: beágyazás, helyettesítés és egyedi betűtípusok betöltése, hogy a PPT, PPTX és ODP prezentációk tiszták, márkajelzést követőek és konzisztensak legyenek."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a betűtípus tulajdonságok kezelését a bemutató szövegében közvetlenül a kódból. A szöveget a diákon keresztül elérheted alakzatok, szövegkeretek, bekezdések és részek segítségével, majd formázhatod a kiválasztott szöveget.

Ez a cikk bemutatja, hogyan konfigurálhatók a betűtípusokkal kapcsolatos tulajdonságok a meglévő szöveghez egy prezentációban, beleértve a betűcsaládot, félkövér és dőlt stílusokat, bekezdésigazítást és a betűszínt. Emellett megmutatja, hogyan hozhatsz létre egy szövegdobozt, adhatsz hozzá szöveget, és állíthatsz be betűtulajdonságokat, mint a betűcsalád, félkövér, dőlt, aláhúzott, betűméret és szín, mielőtt a végeredményt PPTX fájlként mentenéd.

## **Betűtípusokkal Kapcsolatos Tulajdonságok Kezelése**
{{% alert color="info" %}} 

A prezentációk általában tartalmaznak szöveget és képeket. A szöveget különböző módon formázhatjuk, akár a specifikus részek és szavak kiemelésére, akár a vállalati stílusoknak megfelelően. A szövegformázás segít a felhasználóknak változatosabbá tenni a prezentáció tartalmát. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for Android via Java a diák bekezdéseinek betűtípus tulajdonságainak beállításához.

{{% /alert %}} 

A betűtípus tulajdonságainak egy bekezdésben történő kezelése az Aspose.Slides for Android via Java használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
2. Szerezze meg egy dia referencia értékét az index használatával.
3. Érje el a [Placeholder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/placeholder/) alakzatokat a dián és konvertálja őket [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) típusra.
4. Szerezze meg a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraph/) elemet a [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/)‑ből, amelyet az [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) nyújt.
5. Igazítsa a bekezdést.
6. Érje el egy [Paragraph] szöveg [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) elemét.
7. Határozza meg a betűtípust a [FontData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontdata/) használatával és állítsa be a szöveg [Portion] **Font**‑ját ennek megfelelően.
   1. Állítsa be a betűtípust félkövérre.
   2. Állítsa be a betűtípust dőltre.
8. Állítsa be a betűtípus színét a [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fillformat/) használatával, amelyet a [Portion] objektum biztosít.
9. Mentse a módosított prezentációt PPTX fájlba.

A fenti lépések megvalósítása alább látható. Egy egyszerű prezentációt vesz alapul, és formázza a betűket az egyik dián. Az alábbi képernyőképek a bemeneti fájlt és a kódrészletek által végrehajtott módosításokat mutatják. A kód megváltoztatja a betűtípust, a színt és a betűstílust.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Ábra: A szöveg a bemeneti fájlban**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Ábra: Ugyanaz a szöveg frissített formázással**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosít egy Presentation objektumot, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// A diát a diapozíciója alapján érjük el
	ISlide slide = pres.getSlides().get_Item(0);

	// A dia első és második helyfoglalóját érjük el, és AutoShape‑ként típuscastoljuk
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Az első bekezdést érjük el
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// A bekezdést sorkizárással igazítjuk
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Az első részt érjük el
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Új betűtípusok meghatározása
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Új betűtípusok hozzárendelése a részhez
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Betűtípus beállítása félkövérre
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Betűtípus beállítása dőltre
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Betűszín beállítása
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// A PPTX mentése a lemezre
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Szöveg Betűtípus Tulajdonságainak Beállítása**
{{% alert color="info" %}} 

Mint a **Betűtípusokkal Kapcsolatos Tulajdonságok Kezelése** részben említettük, egy [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) használatos a hasonló formázású szöveg tárolására egy bekezdésben. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for Android via Java egy szövegdoboz létrehozásához némi szöveggel, majd egy adott betűtípus és a betűtípuscsalád kategória különböző egyéb tulajdonságainak meghatározásához.

{{% /alert %}} 

Szövegdoboz létrehozása és a benne lévő szöveg betűtípusának beállítása:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
2. Szerezze meg egy dia referencia értékét az index használatával.
3. Adjon egy **Rectangle** típusú [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) elemet a diához.
4. Távolítsa el a [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/)‑hez kapcsolódó kitöltési stílust.
5. Érje el az [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/)‑jét.
6. Adjon hozzá némi szöveget a [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/)‑hez.
7. Érje el a [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/)‑hez tartozó [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) objektumot.
8. Határozza meg a [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) számára használandó betűtípust.
9. Állítsa be a további betűtípus tulajdonságokat, mint félkövér, dőlt, aláhúzott, szín és magasság, a [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) objektum által biztosított megfelelő tulajdonságok használatával.
10. Írja ki a módosított prezentációt PPTX fájlként.

A fenti lépések megvalósítása alább látható.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Ábra: Szöveg néhány betűtípus tulajdonsággal, amelyet az Aspose.Slides for Android via Java állított be**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosít egy Presentation objektumot, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
	// Az első diát lekéri
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Hozzáad egy Rectangle típusú AutoShape‑t
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Eltávolítja az AutoShape‑hez tartozó kitöltési stílust
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Eléri az AutoShape‑hez tartozó TextFrame‑et
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Eléri a TextFrame‑hez tartozó Portion‑t
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Beállítja a Portion betűtípusát
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// A betűtípus félkövér tulajdonságát állítja be
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// A betűtípus dőlt tulajdonságát állítja be
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// A betűtípus aláhúzott tulajdonságát állítja be
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// A betűtípus magasságát állítja be
	port.getPortionFormat().setFontHeight(25);
	
	// A betűtípus színét állítja be
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Mentés a prezentációt a lemezre
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
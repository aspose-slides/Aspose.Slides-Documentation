---
title: Betűtípusok kezelése prezentációkban Java-val
linktitle: Betűtípusok kezelése
type: docs
weight: 10
url: /hu/java/manage-fonts/
keywords:
- betűtípusok kezelése
- betűtípus-tulajdonságok
- bekezdés
- szöveg formázása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Szabályozza a betűtípusokat Java-ban az Aspose.Slides segítségével: ágyazzon be, cseréljen ki, és töltsön be egyedi betűtípusokat, hogy a PPT, PPTX és ODP prezentációk tiszták, márkaszabályoknak megfelelőek és egységesek maradjanak."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi betűtípus-tulajdonságok kezelését a prezentáció szövegében közvetlenül a kódból. A szövegekhez a diákon keresztül a formák, szövegkeretek, bekezdések és részek (portions) révén férhet hozzá, majd formázhatja a kiválasztott szöveget.

Ez a cikk bemutatja, hogyan konfigurálhatja a betűtípusra vonatkozó tulajdonságokat a meglévő szöveghez a prezentációban, beleértve a betűtípus-családot, a félkövér és dőlt stílusokat, a bekezdésigazítást és a betűszínt. Emellett megmutatja, hogyan hozhat létre egy szövegdobozt, adjon hozzá szöveget, és állítson be betűtípus-tulajdonságokat, mint a betűtípus-család, félkövér, dőlt, aláhúzott, betűméret és szín, mielőtt a végeredményt PPTX fájlként mentené.

## **Betűtípus‑tulajdonságok kezelése**
{{% alert color="info" %}} 

A prezentációk általában szöveget és képeket is tartalmaznak. A szöveget különféle módokon lehet formázni, akár egyes részek vagy szavak kiemelésére, akár a vállalati stílusok betartására. A szövegformázás segíti a felhasználókat a prezentáció tartalmának megjelenésének változtatásában. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for Java a diákon lévő bekezdések betűtípus‑tulajdonságainak beállítására.

{{% /alert %}} 

A betűtípus‑tulajdonságok egy bekezdésben való kezeléséhez az Aspose.Slides for Java használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.
1. Szerezze be a dia hivatkozását az indexével.
1. Nyissa meg a dia [Placeholder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholder/) alakjait, és castolja őket [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) típusra.
1. Szerezze meg a [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) objektumot a [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/)‑ből, amelyet az [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) biztosít.
1. Igazítsa a bekezdést.
1. Nyissa meg egy [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) szövegének [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) részét.
1. Definiálja a betűtípust a [FontData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontdata/)‑val, és állítsa be a **Font** értékét a szöveg [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) objektumban.
   1. Állítsa a betűtípust félkövérre.
   1. Állítsa a betűtípust dőltre.
1. Állítsa be a betűszínt a [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) segítségével, amely a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) objektumon keresztül elérhető.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbiakban a fenti lépések megvalósítása látható. Egy egyszerű prezentációt vesz alapul, és formázza a betűtípusokat az egyik dián. A következő képernyőképek a bemeneti fájlt, valamint a kódrészletek által végrehajtott módosításokat mutatják. A kód megváltoztatja a betűtípust, a színt és a betűstílust.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Ábra: A bemeneti fájl szövege**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Ábra: Ugyanaz a szöveg frissített formázással**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Egy Presentation objektum példányosítása, amely egy PPTX fájlt reprezentál
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Dia elérése a pozíciója alapján
	ISlide slide = pres.getSlides().get_Item(0);

	// Az első és második helyőrző elérése a dián, és AutoShape típusra való átkonvertálása
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Az első bekezdés elérése
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// A bekezdés igazítása
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Az első rész (portion) elérése
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Új betűtípusok definiálása
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Új betűtípusok hozzárendelése a részhez
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Betűtípus félkövérre állítása
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Betűtípus dőltre állítása
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Betűszín beállítása
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// PPTX mentése lemezre
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Szöveg betűtípus‑tulajdonságainak beállítása**
{{% alert color="info" %}} 

A **Betűtípus‑tulajdonságok kezelése** részben említett [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) olyan szövegrészt tartalmaz, amelyben a formázás egységes egy bekezdésen belül. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for Java egy szövegdoboz létrehozására, szöveg hozzáadására, majd egy adott betűtípus és a betűtípus‑család egyéb tulajdonságainak meghatározására.

{{% /alert %}} 

Egy szövegdoboz létrehozásához és a benne lévő szöveg betűtípus‑tulajdonságainak beállításához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.
1. Szerezze be a dia hivatkozását az indexével.
1. Adjon egy **Rectangle** típusú [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) elemet a diához.
1. Távolítsa el a [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) kitöltési stílusát.
1. Nyissa meg az [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/) objektumát.
1. Adjon hozzá szöveget a [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/)‑hez.
1. Szerezze meg a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) objektumot, amely a [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/)‑hez tartozik.
1. Definiálja a betűtípust, amelyet a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) használni fog.
1. Állítson be további betűtípus‑tulajdonságokat, például félkövér, dőlt, aláhúzott, szín és magasság, a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) objektum megfelelő tulajdonságain keresztül.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbiakban a fenti lépések megvalósítása látható.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Ábra: Szöveg néhány betűtípus‑tulajdonsággal, amelyet az Aspose.Slides for Java állított be**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX fájlt reprezentáló Presentation objektum példányosítása
Presentation pres = new Presentation();
try {
	// Az első dia lekérése
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle típusú AutoShape hozzáadása
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Az AutoShape-hez tartozó bármely kitöltési stílus eltávolítása
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Az AutoShape-hez tartozó TextFrame elérése
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// A TextFrame-hez tartozó Portion elérése
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// A Portion számára betűtípus beállítása
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// A betűtípus félkövér tulajdonságának beállítása
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// A betűtípus dőlt tulajdonságának beállítása
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// A betűtípus aláhúzás tulajdonságának beállítása
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// A betűtípus magasságának beállítása
	port.getPortionFormat().setFontHeight(25);
	
	// A betűtípus színének beállítása
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// A prezentáció mentése lemezre
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
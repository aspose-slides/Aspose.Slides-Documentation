---
title: Betűtípusok kezelése prezentációkban Java használatával
linktitle: Betűtípusok kezelése
type: docs
weight: 10
url: /hu/java/manage-fonts/
keywords:
- betűtípusok kezelése
- betűtípus tulajdonságok
- bekezdés
- szövegformázás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "A betűtípusok szabályozása Java-ban az Aspose.Slides segítségével: beágyazás, helyettesítés és egyéni betűtípusok betöltése, hogy a PPT, PPTX és ODP prezentációk tiszták, márkavédett és következetesek maradjanak."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy közvetlenül a kódból kezeld a betűtípus tulajdonságait a bemutató szövegében. A szöveget a diákon a formák, szövegdobozok, bekezdések és részek segítségével érheted el, majd alkalmazhatsz formázást a kijelölt szövegre.

Ez a cikk bemutatja, hogyan konfigurálhatók a betűtípushoz kapcsolódó tulajdonságok a meglévő szövegben egy bemutatóban, beleértve a betűcsaládot, a félkövér és dőlt stílusokat, a bekezdés igazítást és a betűszínét. Emellett megmutatja, hogyan hozhatsz létre szövegdobozt, adhatod hozzá a szöveget, és állíthatod be a betűtípus tulajdonságait, például a betűcsaládot, félkövért, dőltet, aláhúzást, betűméretet és színt, mielőtt a végeredményt PPTX fájlként mentenéd.

## **Betűtípushoz kapcsolódó tulajdonságok kezelése**
{{% alert color="primary" %}} 

Az prezentációk általában szöveget és képeket is tartalmaznak. A szöveget különféle módon lehet formázni, akár kiemelve bizonyos szakaszokat és szavakat, akár a vállalati stílusoknak megfelelően. A szövegformázás segíti a felhasználókat, hogy változatosabbá tegyék a bemutató tartalmának megjelenését. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for Java a diákon lévő bekezdések betűtípus‑tulajdonságainak konfigurálásához.
{{% /alert %}} 

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
1. Szerezd meg egy dia referenciáját az indexének használatával.  
1. Érj hozzá a dián lévő [Placeholder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/placeholder/) alakzatokhoz, és konvertáld őket [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) típusra.  
1. Szerezd meg a [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) elemet a [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) által biztosított [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/)‑ból.  
1. Állítsd be a bekezdés sorkizárását.  
1. Érj hozzá egy [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraph/) szöveg [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) eleméhez.  
1. Határozd meg a betűtípust a [FontData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontdata/) használatával, és állítsd be a szöveg [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) **Font** tulajdonságát ennek megfelelően.  
   1. Állítsd be a betűtípust félkövérre.  
   1. Állítsd be a betűtípust dőltre.  
1. Állítsd be a betűszínt a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) objektum által biztosított [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fillformat/) segítségével.  
1. Mentsd el a módosított bemutatót PPTX fájlként.  

A fenti lépések megvalósítása az alábbiakban látható. Egy egyszerű prezentációt vesz alapul, és formázza a betűket az egyik dián. A következő képernyőképek bemutatják a bemeneti fájlt és azt, hogyan módosítja a kódrészlet. A kód megváltoztatja a betűtípust, a színt és a betűstílust.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Ábra: A szöveg a bemeneti fájlban**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Ábra: Ugyanaz a szöveg frissített formázással**|

```java
// PPTX fájlt reprezentáló Presentation objektum példányosítása
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Dia elérése a pozíciójával
	ISlide slide = pres.getSlides().get_Item(0);

	// A dia első és második helykitöltőjének elérése, és AutoShape típusra való átalakítása
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Az első bekezdés elérése
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// A bekezdés sorkizárása
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Az első rész elérése
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Új betűtípusok definiálása
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

	// PPTX mentése lemezre
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Szöveg betűtípus tulajdonságainak beállítása**
{{% alert color="primary" %}} 

Az **Betűtípushoz kapcsolódó tulajdonságok kezelése** című részben említett módon a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) egy bekezdésben hasonló formázású szöveget tárol. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for Java egy szövegdoboz létrehozására szöveggel, majd egy adott betűtípus és a betűcsalád egyéb tulajdonságainak meghatározására.
{{% /alert %}} 

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
1. Szerezd meg egy dia referenciáját az indexének használatával.  
1. Adj hozzá egy **Rectangle** típusú [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) elemet a diához.  
1. Távolítsd el a [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) elemhez társított kitöltési stílust.  
1. Érj hozzá az [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/) eleméhez.  
1. Adj hozzá szöveget a [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/)‑hez.  
1. Érj hozzá a [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/)‑hez társított [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) objektumhoz.  
1. Határozd meg a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) számára használandó betűtípust.  
1. Állíts be további betűtípus‑tulajdonságokat, például félkövér, dőlt, aláhúzott, szín és magasság értékeket a [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) objektum által biztosított megfelelő tulajdonságokkal.  
1. Írd ki a módosított bemutatót PPTX fájlként.  

A fenti lépések megvalósítása az alábbiakban található.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Ábra: Szöveg néhány betűtípus tulajdonsággal, amelyet az Aspose.Slides for Java állított be**|

```java
// PPTX fájlt reprezentáló Presentation objektum példányosítása
Presentation pres = new Presentation();
try {
	// Az első dia lekérése
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Egy Rectangle típusú AutoShape hozzáadása
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Az AutoShape-hez kapcsolódó kitöltési stílus eltávolítása
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Az AutoShape-hez kapcsolódó TextFrame elérése
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// A TextFrame-hez kapcsolódó Portion elérése
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// A Portion betűtípusának beállítása
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// A betűtípus félkövér tulajdonságának beállítása
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// A betűtípus dőlt tulajdonságának beállítása
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// A betűtípus aláhúzás tulajdonságának beállítása
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// A betűtípus méretének beállítása
	port.getPortionFormat().setFontHeight(25);
	
	// A betűtípus színének beállítása
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// A prezentáció lemezre mentése
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
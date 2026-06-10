---
title: "Többszálú feldolgozás az Aspose.Slides for Android Java segítségével"
linktitle: "Többszálúság"
type: docs
weight: 310
url: /hu/androidjava/multithreading/
keywords:
- többszálúság
- több szál
- párhuzamos munka
- diák konvertálása
- diák képekké alakítása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Android Java-n keresztül történő többszálú feldolgozása felgyorsítja a PowerPoint és OpenDocument dokumentumok kezelését. Fedezze fel a hatékony prezentációs munkafolyamatok legjobb gyakorlatait."
---
## **Bevezetés**

Bár a prezentációkkal való párhuzamos munka lehetséges (a beolvasás/töltés/másolás mellett) és a legtöbb esetben minden rendben működik, mégis van egy kis esély arra, hogy helytelen eredményeket kapjon, amikor a könyvtárat több szálban használja.

Erősen ajánljuk, hogy **ne** használjon egyetlen [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) példányt több szálas környezetben, mert ez kiszámíthatatlan hibákhoz vagy olyan meghibásodásokhoz vezethet, amelyeket nehéz észrevenni.

Nem biztonságos betölteni, menteni és/vagy klónozni egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály példányát több szálon. Az ilyen műveletek **nem** támogatottak. Ha ilyen feladatokat kell végeznie, a műveleteket több egyetlen szálas folyamat segítségével kell párhuzamosítani – és minden ilyen folyamatnak a saját prezentáció példányát kell használnia.

## **Prezentációs diák képekké konvertálása párhuzamosan**

Tegyük fel, hogy szeretnénk a PowerPoint prezentáció összes diáját PNG képekbe konvertálni párhuzamosan. Mivel nem biztonságos egyetlen `Presentation` példányt több szálban használni, a prezentáció diákat különálló prezentációkra bontjuk, és a diákat párhuzamosan képekké konvertáljuk, minden prezentációt külön szálban használva. Az alábbi kódrészlet bemutatja, hogyan kell ezt megtenni.

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Kivonja a i. diát egy külön prezentációba.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Átalakítja a diát képpé egy külön feladatban.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// Várja meg, hogy az összes feladat befejeződjön.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **GYIK**

**Szükséges-e minden szálban licencbeállítást meghívni?**

Nem. Elég egyszer, a **process/app domain**-onként végrehajtani, mielőtt a **szálak** elindulnak. Ha a [license setup](/slides/hu/androidjava/licensing/) párhuzamosan hívható (például lazy inicializálás során), akkor szinkronizálni kell ezt a hívást, mert magának a licencbeállítási metódusnak nincs szálbiztonsága.

**Átadhatok `Presentation` vagy `Slide` objektumokat szálak között?**

Az „élő” prezentációs objektumok szálak közötti átadása nem ajánlott: használjon önálló példányokat szálanként, vagy előre hozza létre a különálló prezentációkat/diakonténereket minden szál számára. Ez a megközelítés követi az általános ajánlást, hogy ne osszon meg egyetlen prezentáció példányt a szálak között.

**Biztonságos-e a különböző formátumok (PDF, HTML, képek) exportjának párhuzamosítása, ha minden szálnak saját `Presentation` példánya van?**

Igen. Független példányokkal és külön kimeneti útvonalakkal az ilyen feladatok általában helyesen párhuzamosíthatók; kerülje a megosztott prezentáció objektumokat és a megosztott I/O folyamatokat.

**Mit tegyek a globális betűtípus beállításokkal (mappák, helyettesítések) több szálos környezetben?**

Inicializálja az összes globális [font settings](/slides/hu/androidjava/powerpoint-fonts/) beállítást a szálak indítása előtt, és ne változtassa meg őket a párhuzamos munka során. Ez megszünteti a versenyhelyzeteket a megosztott betűtípus erőforrások hozzáférésekor.
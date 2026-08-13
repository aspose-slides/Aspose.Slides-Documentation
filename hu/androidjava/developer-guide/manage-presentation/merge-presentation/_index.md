---
title: Hatékony bemutatók egyesítése Androidon
linktitle: Bemutatók egyesítése
type: docs
weight: 40
url: /hu/androidjava/merge-presentation/
keywords:
- PowerPoint egyesítése
- bemutatók egyesítése
- diák egyesítése
- PPT egyesítése
- PPTX egyesítése
- ODP egyesítése
- PowerPoint kombinálása
- bemutatók kombinálása
- diák kombinálása
- PPT kombinálása
- PPTX kombinálása
- ODP kombinálása
- Android
- Java
- Aspose.Slides
description: "Könnyedén egyesítheti a PowerPoint (PPT, PPTX) és OpenDocument (ODP) bemutatókat az Aspose.Slides for Android segítségével Java nyelven, egyszerűsítve a munkafolyamatát."
---
## **Áttekintés**

PowerPoint és OpenDocument bemutatók egyesítése gyakori feladat számos Android-alkalmazásban, különösen jelentések generálásakor, diák összeállításakor különböző forrásokból, vagy a prezentációs munkafolyamatok automatizálásakor. Az Aspose.Slides egy hatékony és könnyen használható API-t kínál több PPT, PPTX vagy ODP fájl egyetlen bemutatóba való egyesítéséhez, anélkül, hogy a Microsoft PowerPoint, a LibreOffice vagy az OpenOffice telepítve lenne.

Ebben az útmutatóban megtanulja, hogyan egyesíthet PowerPoint és OpenDocument bemutatókat néhány kódsor segítségével. Rendelkezésre álló példákat biztosítunk, és bemutatjuk, hogyan őrizhetők meg a dia formázása, elrendezései és egyéb bemutatóelemek az egyesítési folyamat során.

Akár vállalati szintű alkalmazást, akár egyszerű automatizálási eszközt épít, az Aspose.Slides gyors, megbízható és skálázható módon teszi lehetővé a bemutatók egyesítését. Az Aspose.Slides többféle módon is egyesítheti a bemutatókat. Kombinálhatja a bemutatókat az összes alakzatukkal, stílusaikkal, szövegükkel, formázásukkal, megjegyzéseikkel, animációikkal és egyebekkel – anélkül, hogy aggódna a minőség vagy az adatok elvesztése miatt.

{{% alert color="info" %}}
Lásd még: [Clone Slides](https://docs.aspose.com/slides/hu/androidjava/clone-slides/)
{{% /alert %}}

### **Mi egyesíthető**

Az Aspose.Slides segítségével egyesíthet 

* teljes bemutatókat. A bemutatók összes diája egyetlen bemutatóba kerül.
* specifikus diákot. A kiválasztott diák egyetlen bemutatóba kerülnek.
* bemutatókat egy formátumban (PPT to PPT, PPTX to PPTX stb.) és különböző formátumokban (PPT to PPTX, PPTX to ODP stb.) egymáshoz. 

### **Egyesítési beállítások**

Alkalmazhat olyan beállításokat, amelyek meghatározzák, hogy

* az egyes diák a kimeneti bemutatóban egyedi stílust megtartanak.
* egy meghatározott stílus legyen használva az összes dián a kimeneti bemutatóban. 

A bemutatók egyesítéséhez az Aspose.Slides a [AddClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) módszereket (az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection) interfészből) biztosítja. Számos `AddClone` metódus megvalósítás létezik, amelyek meghatározzák a bemutató egyesítési folyamat paramétereit. Minden Presentation objektumnak van egy [Slides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) gyűjteménye, ezért a `AddClone` metódust a bemutatóból hívhatja meg, amelybe be szeretné egyesíteni a diát.

A `AddClone` metódus egy `ISlide` objektumot ad vissza, amely a forrásdia klónja. A kimeneti bemutató diái egyszerűen a forrás diáinak másolatai. Ennek eredményeként módosíthatja a kialakult diákat (például stílusok, formázási beállítások vagy elrendezések alkalmazásával) anélkül, hogy aggódna a forrásbemutatók érintettsége miatt. 

## **Bemutatók egyesítése** 

Az Aspose.Slides a [**AddClone(ISlide)**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust biztosítja, amely lehetővé teszi a diák egyesítését, miközben a diák megtartják az elrendezéseiket és stílusaikat (alapértelmezett paraméterek).

Ez a Java kód bemutatja, hogyan egyesíthetőek a bemutatók:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Bemutatók egyesítése dia mesterrel** 

Aspose.Slides a [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) metódust biztosítja, amely lehetővé teszi a diák egyesítését egy dia mester bemutató sablon alkalmazásával. Így szükség esetén módosíthatja a kimeneti bemutató diáinak stílusát.

Ez a Java kód demonstrálja a leírt műveletet:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Az dia mester elrendezése automatikusan kerül meghatározásra. Ha megfelelő elrendezés nem határozható meg, és az `allowCloneMissingLayout` logikai paraméter a `AddClone` metódusban igazra van állítva, a forrásdia elrendezése lesz használva. Ellenkező esetben a [PptxEditException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PptxEditException) lesz dobva.
{{% /alert %}}

Ha azt szeretné, hogy a kimeneti bemutató diái más elrendezéssel rendelkezzenek, használja a [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) metódust az egyesítés során.

## **Specifikus diák egyesítése bemutatókból** 

A több bemutatóból származó specifikus diák egyesítése hasznos saját diavetítések létrehozásához. Az Androidra szánt Aspose.Slides Java segítségével lehetővé teszi, hogy csak a szükséges diák kiválasztását és importálását tegye meg. Az API megőrzi az eredeti diák formázását, elrendezését és dizájnját.

A következő Java kód létrehoz egy új bemutatót, két másik bemutatóból cím diákot ad hozzá, és elmenti az eredményt egy fájlba:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);

    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Bemutatók egyesítése dia elrendezéssel** 

Ez a Java kód bemutatja, hogyan kombinálható a diák bemutatókból, miközben a kívánt dia elrendezést alkalmazza rájuk, hogy egy kimeneti bemutatót kapjon:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Bemutatók egyesítése különböző dia méretekkel** 

{{% alert title="Note" color="warning" %}} 
Nem egyesíthet bemutatókat különböző dia méretekkel. 
{{% /alert %}}

Két különböző dia méretű bemutató egyesítéséhez át kell méretezni az egyiket, hogy mérete megegyezzen a másik bemutató méretével. 

Ez a mintakód demonstrálja a leírt műveletet:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Diák egyesítése egy bemutató szekcióba** 

Ez a Java kód bemutatja, hogyan egyesíthető egy adott dia egy bemutató szekcióba:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

A dia a szekció végéhez kerül hozzáadva. 

{{% alert title="Tip" color="info" %}} 
Az Aspose egy [INGYENES Collage webalkalmazást](https://products.aspose.app/slides/hu/collage) biztosít. Ezen az online szolgáltatáson keresztül egyesíthet [JPG to JPG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG to PNG képeket, létrehozhat [fotórácsokat](https://products.aspose.app/slides/hu/collage/photo-grid), stb. 
{{% /alert %}}

## **GYIK**

### Van-e korlátozás a diák számában a bemutatók egyesítésekor?

Nincs szigorú korlátozás. Az Aspose.Slides képes nagy fájlok kezelésére, de a teljesítmény a mérettől és a rendszer erőforrásaitól függ. Nagyon nagy bemutatók esetén ajánlott 64 bites JVM-et használni és elegendő heap memóriát lefoglalni.

### Egyesíthetek-e beágyazott videóval vagy audióval rendelkező bemutatókat?

Igen, az Aspose.Slides megőrzi a diákba beágyazott multimédia tartalmakat, de a végleges bemutató jelentősen nagyobbá válhat.

### Megmaradnak-e a betűtípusok a bemutatók egyesítésekor?

Igen. A forrásbemutatókban használt betűtípusok megmaradnak a kimeneti fájlban, feltéve, hogy a rendszeren telepítve vannak vagy [beágyazottak](/slides/hu/androidjava/embedded-font/).
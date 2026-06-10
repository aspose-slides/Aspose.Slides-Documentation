---
title: "Hatékonyan egyesítse a prezentációkat Androidon"
linktitle: "Prezentációk egyesítése"
type: docs
weight: 40
url: /hu/androidjava/merge-presentation/
keywords:
- "PowerPoint egyesítése"
- "prezentációk egyesítése"
- "diák egyesítése"
- "PPT egyesítése"
- "PPTX egyesítése"
- "ODP egyesítése"
- "PowerPoint kombinálása"
- "prezentációk kombinálása"
- "diák kombinálása"
- "PPT kombinálása"
- "PPTX kombinálása"
- "ODP kombinálása"
- Android
- Java
- Aspose.Slides
description: "Könnyedén egyesítheti a PowerPoint (PPT, PPTX) és az OpenDocument (ODP) prezentációkat az Aspose.Slides Androidra Java-val, egyszerűsítve a munkafolyamatát."
---
## **Áttekintés**

A PowerPoint és az OpenDocument prezentációk egyesítése gyakori feladat számos Android alkalmazásban, különösen jelentések generálásakor, különböző forrásokból származó diák összeállításakor vagy a prezentációs munkafolyamatok automatizálásakor. Az Aspose.Slides egy hatékony és könnyen használható API-t biztosít több PPT, PPTX vagy ODP fájl egyetlen prezentációba való kombinálásához, anélkül, hogy a Microsoft PowerPoint, a LibreOffice vagy az OpenOffice telepítve lenne.

Ebben az útmutatóban megtanulja, hogyan egyesíthet PowerPoint és OpenDocument prezentációkat csak néhány kódsor segítségével. Kész, felhasználásra kész példákat nyújtunk, és bemutatjuk, hogyan őrizhető meg a diaformázás, az elrendezés és a többi prezentációelemt a egyesítési folyamat során.

Akár vállalati szintű alkalmazást, akár egyszerű automatizálási eszközt fejleszt, az Aspose.Slides gyors, megbízható és skálázható prezentációk egyesítését teszi lehetővé. Az Aspose.Slides többféle módon teszi lehetővé a prezentációk egyesítését. Kombinálhatja a prezentációkat minden alakzatukkal, stílusukkal, szövegükkel, formázásukkal, megjegyzéseikkel, animációikkal és egyebekkel – minőség vagy adatvesztés nélkül.

{{% alert color="primary" %}}
See also: [Clone Slides](https://docs.aspose.com/slides/hu/androidjava/clone-slides/)
{{% /alert %}}

### **Mit lehet egyesíteni**

* teljes prezentációk. Az összes diát a prezentációkból egy prezentációba fűzi össze
* konkrét diák. Kiválasztott diák egy prezentációba kerülnek
* prezentációk egyformátumban (PPT to PPT, PPTX to PPTX, stb.) és különböző formátumokban (PPT to PPTX, PPTX to ODP, stb.) egymásba

### **Egyesítési beállítások**

* az eredményes prezentáció minden diája megtartja az egyedi stílusát
* egy meghatározott stílus használata az összes dián az eredményes prezentációban  

A prezentációk egyesítéséhez az Aspose.Slides a [AddClone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódusokat (az [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection) interfészből) biztosítja. Számos megvalósítása létezik az `AddClone` metódusoknak, amelyek meghatározzák a prezentáció egyesítési folyamatának paramétereit. Minden Presentation objektumnak van egy [Slides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) gyűjteménye, így a diák egyesítését végző prezentációból hívhatja meg egy `AddClone` metódust.

Az `AddClone` metódus egy `ISlide` objektumot ad vissza, amely a forrásdia klónja. A kimeneti prezentáció diái egyszerűen a forrásdiák másolatai. Így a kapott diákon (például stílusok, formázási beállítások vagy elrendezések alkalmazása) változtatásokat végezhet anélkül, hogy a forrásprezentációk érintettek lennének.

## **Prezentációk egyesítése**

Az Aspose.Slides a [**AddClone(ISlide)**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metódust kínálja, amely lehetővé teszi a diák kombinálását úgy, hogy a diák megtartják saját elrendezésüket és stílusukat (alapértelmezett paraméterek).

Ez a Java kód bemutatja a prezentációk egyesítését:

```java
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

## **Prezentációk egyesítése dia mesterrel**

Az Aspose.Slides a [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) metódust biztosítja, amely lehetővé teszi a diák kombinálását egy dia mester sablon alkalmazásával. Így szükség esetén megváltoztathatja a kimeneti prezentáció diáinak stílusát.

Ez a Java kód demonstrálja a leírt műveletet:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Megjegyzés" color="warning" %}} 
A dia elrendezése a dia mesterhez automatikusan kerül meghatározásra. Ha megfelelő elrendezést nem lehet meghatározni, és a `allowCloneMissingLayout` logikai paraméter a `AddClone` metódusban true értékre van állítva, akkor a forrásdia elrendezése kerül felhasználásra. Ellenkező esetben a [PptxEditException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PptxEditException) lesz dobva.
{{% /alert %}}

Ha azt szeretné, hogy a kimeneti prezentáció diái más elrendezést kapjanak, akkor a [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) metódust használja az egyesítés során.

## **Specifikus diák egyesítése prezentációkból**

Több prezentációból származó konkrét diák egyesítése hasznos egyedi diavetítések létrehozásához. Az Aspose.Slides for Android via Java lehetővé teszi, hogy csak a szükséges diák kiválasztásával és importálásával dolgozzon. Az API megőrzi az eredeti diák formázását, elrendezését és dizájnját.

Az alábbi Java kód új prezentációt hoz létre, két másik prezentációból cím diákat ad hozzá, és elmenti az eredményt egy fájlba:

```java
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
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Prezentációk egyesítése diaelrendezéssel**

Ez a Java kód bemutatja, hogyan kombinálhat diák egyes prezentációkból, miközben a kívánt diaelrendezést alkalmazza, hogy egyetlen kimeneti prezentációt kapjon:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Prezentációk egyesítése különböző dia méretekkel**

{{% alert title="Megjegyzés" color="warning" %}} 
Nem lehet különböző dia méretekkel rendelkező prezentációkat egyesíteni. 
{{% /alert %}}

Két különböző dia mérettel rendelkező prezentáció egyesítéséhez az egyik prezentáció méretét át kell méretezni, hogy megegyezzen a másikéval.

Ez a példa kód demonstrálja a leírt műveletet:

```java
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

## **Diák egyesítése a prezentáció szekciójába**

Ez a Java kód bemutatja, hogyan egyesíthet egy konkrét diát egy szekcióba a prezentációban:

```java
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

A dia a szekció végére kerül hozzáadásra. 

{{% alert title="Tipp" color="primary" %}} 
Az Aspose egy [INGYENES Collage webalkalmazást](https://products.aspose.app/slides/hu/collage) kínál. Ezzel az online szolgáltatással [JPG‑t JPG‑re](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG‑t PNG‑re képeket egyesíthet, [fotorácsokat](https://products.aspose.app/slides/hu/collage/photo-grid) hozhat létre, és így tovább. 
{{% /alert %}}

## **GYIK**

**Vannak-e korlátozások a diák számát illetően a prezentációk egyesítésekor?**  
Nincs szigorú korlátozás. Az Aspose.Slides nagy fájlokkal is megbirkózik, de a teljesítmény a fájl méretétől és a rendszer erőforrásaitól függ. Nagyon nagy prezentációk esetén ajánlott 64‑bit JVM-et használni, és elegendő halommemóriát lefoglalni.

**Egyesíthetek‑e olyan prezentációkat, amelyekbe videó vagy hang van beágyazva?**  
Igen, az Aspose.Slides megőrzi a diákba beágyazott multimédiás tartalmakat, de a végleges prezentáció jelentősen nagyobb lehet.

**Megmaradnak‑e a betűtípusok az egyesítés során?**  
Igen. A forrásprezentációkban használt betűtípusok megmaradnak a kimeneti fájlban, feltéve, hogy azok telepítve vannak a rendszeren vagy [beágyazott](/slides/hu/androidjava/embedded-font/).
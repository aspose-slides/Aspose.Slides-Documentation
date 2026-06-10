---
title: Fejlécek és láblécek kezelése prezentációkban Androidon
linktitle: Fejléc & Lábléc
type: docs
weight: 140
url: /hu/androidjava/presentation-header-and-footer/
keywords:
- fejléc
- fejléc szöveg
- lábléc
- lábléc szöveg
- fejléc beállítása
- lábléc beállítása
- jegyzetlap
- jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Használja az Aspose.Slides for Android for Java-t, hogy fejléceket és lábléceket adjon hozzá és testreszabjon PowerPoint és OpenDocument prezentációkban, professzionális megjelenés érdekében."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi fejléc‑ és lábléc‑beállítások kezelését PowerPoint‑prezentációkban. A fejlécek és láblécek a prezentáció mester‑szintjén kerülnek kezelve, és az API olyan metódusokat biztosít, amelyekkel beállítható a lábléc szövege, módosítható a lábléc láthatósága, valamint frissíthető a fejléc szövege a mester‑jegyzet diákon.

A kézbesítési (handout) és jegyzetdiák fejléceit és láblécét is kezelheti. Ez magában foglalja a fejléc, lábléc, dia szám és dátum‑idő helyfoglalók láthatóságának és szövegének módosítását a jegyzet‑mesterben, az összes gyermek‑jegyzetdián vagy egy adott jegyzetdián.

## **Fejlécek és láblécek kezelése egy prezentációban**
Néhány konkrét dia jegyzete eltávolítható, ahogyan az alábbi példában látható:

```java
// Prezentáció betöltése
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Lábléc beállítása
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Fejléc elérése és frissítése
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Prezentáció mentése
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Metódus a fejléc/lábléc szöveg beállításához
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Fejlécek és láblécek kezelése kézbesítési és jegyzetdiákon**
Az Aspose.Slides for Android Java‑környezetben támogatja a fejléceket és lábléceket kézbesítési és jegyzetdiákon. Kövesse az alábbi lépéseket:

- Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) videóval.
- Módosítsa a fejléc‑ és lábléc‑beállításokat a jegyzet‑mesterben és az összes jegyzetdián.
- Állítsa be a mester‑jegyzetdiát és az összes gyermek‑lábléc‑helyfoglalót láthatóvá.
- Állítsa be a mester‑jegyzetdiát és az összes gyermek‑dátum‑idő‑helyfoglalót láthatóvá.
- Módosítsa a fejléc‑ és lábléc‑beállításokat csak az első jegyzetdián.
- Állítsa be a jegyzetdia fejléc‑helyfoglalóját láthatóvá.
- Adja meg a szöveget a jegyzetdia fejléc‑helyfoglalójához.
- Adja meg a szöveget a jegyzetdia dátum‑idő‑helyfoglalójához.
- Írja ki a módosított prezentációfájlt.

Az alábbi példában a kódrészlet is szerepel.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Change Header and Footer settings for notes master and all notes slides
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // make the master notes slide and all child Footer placeholders visible
        headerFooterManager.setFooterAndChildFootersVisibility(true); // make the master notes slide and all child Header placeholders visible
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // make the master notes slide and all child SlideNumber placeholders visible
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // make the master notes slide and all child Date and time placeholders visible

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // set text to master notes slide and all child Header placeholders
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // set text to master notes slide and all child Footer placeholders
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // set text to master notes slide and all child Date and time placeholders
    }

    // Change Header and Footer settings for first notes slide only
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // make this notes slide Header placeholder visible

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // make this notes slide Footer placeholder visible

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // make this notes slide SlideNumber placeholder visible

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // make this notes slide Date-time placeholder visible

        headerFooterManager.setHeaderText("New header text"); // set text to notes slide Header placeholder
        headerFooterManager.setFooterText("New footer text"); // set text to notes slide Footer placeholder
        headerFooterManager.setDateTimeText("New date and time text"); // set text to notes slide Date-time placeholder
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hozzáadhatok „fejlécet” a normál diákhoz?**

PowerPoint‑ban a „fejléc” csak jegyzetekhez és kézbesítésekhez létezik; általános diákon a támogatott elemek a lábléc, a dátum/idő és a dia száma. Az Aspose.Slides ugyanazokat a korlátozásokat követi: fejléc csak jegyzetekhez/kézbesítésekhez, a diákon pedig – lábléc/dátum‑idő/dia‑szám.

**Mi van, ha az elrendezés nem tartalmaz lábléc‑területet – bekapcsolhatom a láthatóságát?**

Igen. Ellenőrizze a láthatóságot a fejléc/lábléc kezelőn keresztül, és szükség esetén engedélyezze. Ezek az API‑jelzők és metódusok olyan esetekre lettek tervezve, amikor a helyfoglaló hiányzik vagy rejtve van.

**Hogyan állíthatom be, hogy a dia‑szám 1‑től eltérő értékkel induljon?**

Állítsa be a prezentáció [első dia számát](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-); ezután az összes számozás újraszámolódik. Például kezdheti 0‑nál vagy 10‑nél, és elrejtheti a számot a címdian.

**Mi történik a fejlécekkel/láblécekkel PDF‑/képek/HTML‑exportáláskor?**

A fejlécek és láblécek a prezentáció szokásos szövegelemeként kerülnek renderelésre. Vagyis ha az elemek láthatóak a diákon/jegyzetoldalakon, akkor a kimeneti formátumban is megjelennek a többi tartalommal együtt.
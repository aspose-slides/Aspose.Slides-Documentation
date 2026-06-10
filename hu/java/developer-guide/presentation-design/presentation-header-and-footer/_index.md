---
title: Prezentáció fejlécek és láblécek kezelése Java-ban
linktitle: Fejléc és lábléc
type: docs
weight: 140
url: /hu/java/presentation-header-and-footer/
keywords:
- fejléc
- fejléc szöveg
- lábléc
- lábléc szöveg
- fejléc beállítása
- lábléc beállítása
- kézjegyzet
- jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Használja az Aspose.Slides for Java-t, hogy fejléceket és lábléceket adjon hozzá és testreszabjon PowerPoint és OpenDocument prezentációkban a professzionális megjelenés érdekében."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy kezelje a fejléc- és láblécbeállításokat PowerPoint‑prezentációkban. A fejlécek és láblécek a prezentáció mester szintjén vannak kezelve, és az API metódusokat biztosít a lábléc szövegének beállításához, a lábléc láthatóságának módosításához és a mester jegyzetdiák fejlécszövegének frissítéséhez.

A kézjegyzet‑ és jegyzetdiák fejléceit és lábléceit is kezelheti. Ez magában foglalja a fejléc, lábléc, dia száma és dátum‑idő helyőrzőinek láthatóságának és szövegének módosítását a jegyzetmester, az összes gyermek jegyzetdia vagy egy adott jegyzetdia esetén.

## **Fejlécek és láblécek kezelése egy prezentációban**
Egyes diák jegyzetei eltávolíthatók, ahogy az alábbi példában látható:

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
// Metódus a Fejléc/Lábléc szövegének beállításához
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

## **Fejlécek és láblécek kezelése kézjegyzet és jegyzet diákon**
Az Aspose.Slides for Java támogatja a fejlécek és láblécek használatát kézjegyzet és jegyzet diákon. Kövesse az alábbi lépéseket:

- Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) elemet, amely videót tartalmaz.
- Módosítsa a fejléc és lábléc beállításait a jegyzetmesteren és az összes jegyzetdián.
- Állítsa be a mester jegyzetdiát és az összes gyermek lábléc helyőrzőt láthatóvá.
- Állítsa be a mester jegyzetdiát és az összes gyermek dátum‑ és időhelyőrzőt láthatóvá.
- Csak az első jegyzetdián módosítsa a fejléc és lábléc beállításait.
- Állítsa be a jegyzetdia fejléc helyőrzőjét láthatóvá.
- Állítsa be a szöveget a jegyzetdia fejléc helyőrzőjére.
- Állítsa be a szöveget a jegyzetdia dátum‑idő helyőrzőjére.
- Írja ki a módosított prezentációfájlt.

A kódrészlet az alábbi példában található.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Fejléc- és lábléc beállításainak módosítása a jegyzetmestre és az összes jegyzetdiára
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // láthatóvá teszi a mester jegyzetdiát és az összes gyermek lábléc helyőrzőt
        headerFooterManager.setFooterAndChildFootersVisibility(true); // láthatóvá teszi a mester jegyzetdiát és az összes gyermek fejléc helyőrzőt
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // láthatóvá teszi a mester jegyzetdiát és az összes gyermek dia szám helyőrzőt
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // láthatóvá teszi a mester jegyzetdiát és az összes gyermek dátum és idő helyőrzőt

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // szöveget állít be a mester jegyzetdiára és az összes gyermek fejléc helyőrzőre
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // szöveget állít be a mester jegyzetdiára és az összes gyermek lábléc helyőrzőre
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // szöveget állít be a mester jegyzetdiára és az összes gyermek dátum és idő helyőrzőre
    }

    // Fejléc- és lábléc beállításainak módosítása csak az első jegyzetdiára
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // láthatóvá teszi ennek a jegyzetdiának a fejléc helyőrzőjét

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // láthatóvá teszi ennek a jegyzetdiának a lábléc helyőrzőjét

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // láthatóvá teszi ennek a jegyzetdiának a dia szám helyőrzőjét

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // láthatóvá teszi ennek a jegyzetdiának a dátum-idő helyőrzőjét

        headerFooterManager.setHeaderText("New header text"); // beállítja a szöveget a jegyzetdia fejléc helyőrzőjére
        headerFooterManager.setFooterText("New footer text"); // beállítja a szöveget a jegyzetdia lábléc helyőrzőjére
        headerFooterManager.setDateTimeText("New date and time text"); // beállítja a szöveget a jegyzetdia dátum-idő helyőrzőjére
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hozzáadhatok „fejlécet” a normál diákhoz?**

PowerPoint‑ban a „fejléc” csak a jegyzetek és kézjegyzetek esetén létezik; a normál diákon a támogatott elemek a lábléc, a dátum/ idő és a dia száma. Az Aspose.Slides is ugyanazokat a korlátozásokat követi: a fejléc csak a Jegyzetek/Kézjegyzetek esetén érhető el, a diákon pedig – Lábléc/DátumIdő/DiaSzám.

**Mi van, ha az elrendezés nem tartalmaz lábléc területet – bekapcsolhatom a láthatóságát?**

Igen. Ellenőrizze a láthatóságot a fejléc/lábléc kezelőn keresztül, és szükség esetén engedélyezze. Ezek az API‑mutatók és metódusok olyan esetekre lettek tervezve, amikor a helyőrző hiányzik vagy rejtve van.

**Hogyan állíthatom be, hogy a dia számozás ne 1‑től kezdődjön?**

Állítsa be a prezentáció [first slide number](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) értékét; ezután az összes számozás újraszámításra kerül. Például kezdheti 0‑nál vagy 10‑nél, és elrejtheti a számot a címdin.

**Mi történik a fejlécekkel/láblécekkel PDF‑, kép‑ vagy HTML‑exportáláskor?**

Azok a prezentáció szabályos szövegelemeként kerülnek renderelésre. Vagyis ha az elemek láthatóak a diákon/jegyzett oldalakon, akkor a kimeneti formátumban is megjelennek a többi tartalommal együtt.
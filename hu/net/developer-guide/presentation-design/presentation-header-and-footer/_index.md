---
title: Prezentáció fejlécek és láblécek kezelése .NET-ben
linktitle: Fejléc és Lábléc
type: docs
weight: 140
url: /hu/net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "Használja az Aspose.Slides for .NET-et, hogy fejléceket és lábléceket adjon hozzá és testreszabjon PowerPoint és OpenDocument prezentációkban a professzionális megjelenés érdekében."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a fejléc- és lábléc-beállítások kezelését a PowerPoint‑prezentációkban. A fejlécet és láblécet a prezentáció mester‑szintjén kezelik, és az API módszereket biztosít a lábléc szövegének beállításához, a lábléc láthatóságának módosításához, valamint a mester‑jegyzet diákon a fejléc szövegének frissítéséhez.

A kézjegyzet‑ és jegyzetdiák számára is kezelheti a fejléceket és lábléceket. Ez magában foglalja a fejléc, lábléc, diaszám és dátum‑idő helyőrzők láthatóságának és szövegének módosítását a jegyzet‑mesterben, az összes gyermek‑jegyzet dián vagy egy adott jegyzet dián.

## **Fejléc‑ és lábléc‑szöveg kezelése**

Néhány adott dia jegyzete frissíthető az alábbi példában bemutatott módon:

```c#
// Prezentáció betöltése
Presentation pres = new Presentation("headerTest.pptx");

// Lábléc beállítása
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Fejléc elérése és frissítése
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Prezentáció mentése
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// Metódus a fejléc/lábléc szövegének beállításához
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```




## **Fejlécek és láblécek kezelése kézjegyzet és jegyzet diákon**
Az Aspose.Slides for .NET támogatja a fejlécet és láblécet kézjegyzet és jegyzet diákon. Kérjük, kövesse az alábbi lépéseket:

- Töltsön be egy [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)videót tartalmazó prezentációt.
- Módosítsa a fejléc és lábléc beállításait a jegyzet‑mesterben és az összes jegyzet dián.
- Állítsa be a mester‑jegyzet diát és az összes gyermek lábléc helyőrzőt láthatóvá.
- Állítsa be a mester‑jegyzet diát és az összes gyermek dátum‑ és idő helyőrzőt láthatóvá.
- Módosítsa a fejléc és lábléc beállításait csak az első jegyzet dián.
- Állítsa be a jegyzet dia fejléc helyőrzőt láthatóvá.
- Állítsa be a szöveget a jegyzet dia fejléc helyőrzőjéhez.
- Állítsa be a szöveget a jegyzet dia dátum‑idő helyőrzőjéhez.
- Írja ki a módosított prezentáció fájlt.

A kódrészlet a lenti példában található.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Módosítsa a fejléc és lábléc beállításait a jegyzet mester és az összes jegyzet dia számára
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // a mester jegyzet dia és az összes gyermek lábléc helyőrző láthatóvá tétele
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // a mester jegyzet dia és az összes gyermek fejléc helyőrző láthatóvá tétele
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // a mester jegyzet dia és az összes gyermek diaszám helyőrző láthatóvá tétele
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // a mester jegyzet dia és az összes gyermek dátum és idő helyőrző láthatóvá tétele

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // szöveg beállítása a mester jegyzet dia és az összes gyermek fejléc helyőrző számára
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // szöveg beállítása a mester jegyzet dia és az összes gyermek lábléc helyőrző számára
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // szöveg beállítása a mester jegyzet dia és az összes gyermek dátum és idő helyőrző számára
	}

	// Csak az első jegyzet dia fejléc és lábléc beállításainak módosítása
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // a jelenlegi jegyzet dia fejléc helyőrzőjének láthatóvá tétele

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // a jelenlegi jegyzet dia lábléc helyőrzőjének láthatóvá tétele

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // a jelenlegi jegyzet dia diaszám helyőrzőjének láthatóvá tétele

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // a jelenlegi jegyzet dia dátum-idő helyőrzőjének láthatóvá tétele

		headerFooterManager.SetHeaderText("New header text"); // szöveg beállítása a jegyzet dia fejléc helyőrzőjére
		headerFooterManager.SetFooterText("New footer text"); // szöveg beállítása a jegyzet dia lábléc helyőrzőjére
		headerFooterManager.SetDateTimeText("New date and time text"); // szöveg beállítása a jegyzet dia dátum-idő helyőrzőjére
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **GYIK**

**Hozzáadhatok „fejlécet” a normál diákhoz?**

A PowerPoint‑ban a „Fejléc” csak a jegyzetekhez és kézjegyzetekhez létezik; a normál diákon csak a lábléc, a dátum/idő és a diaszám elemek támogatottak. Az Aspose.Slidesben ez ugyanazokkal a korlátozásokkal egyezik: fejléc csak Jegyzetek/Kézjegyzet esetén, a diákon—Lábléc/DátumIdő/Diaszám.

**Mi van, ha az elrendezés nem tartalmaz lábléc területet—bekapcsolhatom a láthatóságát?**

Igen. Ellenőrizze a láthatóságot a fejléc/lábléc kezelőn keresztül, és szükség esetén engedélyezze. Ezek az API‑jelek és módszerek arra az esetre lettek tervezve, amikor a helyőrző hiányzik vagy el van rejtve.

**Hogyan állíthatom be, hogy a diaszám 1‑től eltérő értékkel kezdődjön?**

Állítsa be a prezentáció [első diaszámát](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/firstslidenumber/); ezt követően az összes számozás újraszámításra kerül. Például kezdhet 0‑val vagy 10‑zel, és elrejtheti a számot a címdián.

**Mi történik a fejlécekkel/láblécekkel PDF/képek/HTML exportálásakor?**

Azok a prezentáció szokásos szövegelemeként kerülnek renderelésre. Vagyis ha az elemek láthatóak a diákon/jegyzetoldalakon, akkor a kimeneti formátumban is megjelennek a többi tartalom mellett.
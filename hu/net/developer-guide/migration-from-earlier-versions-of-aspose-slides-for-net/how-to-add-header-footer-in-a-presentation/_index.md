---
title: Hogyan adjunk hozzá fejlécet és láblécet a prezentációkhoz .NET-ben
linktitle: Fejléc és lábléc hozzáadása
type: docs
weight: 20
url: /hu/net/how-to-add-header-footer-in-a-presentation/
keywords:
- migráció
- fejléc hozzáadása
- lábléc hozzáadása
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá fejlécet és láblécet a PowerPoint PPT, PPTX és ODP prezentációkhoz .NET-ben, mind az örökölt, mind a modern Aspose.Slides API-k használatával."
---
{{% alert color="primary" %}} 

Megjelent egy új [Aspose.Slides for .NET API](/slides/hu/net/), és most ez a termék képes teljesen új PowerPoint dokumentumok létrehozására, valamint a meglévők szerkesztésére.

{{% /alert %}} 
## **Legacy kód támogatása**
Az Aspose.Slides for .NET 13.x előtti verziókhoz készült örökölt kód használatához kisebb módosításokra van szükség a kódban, hogy az korábban működjön. Az összes, a régi Aspose.Slides for .NET-ben az Aspose.Slide és az Aspose.Slides.Pptx névterek alatt található osztály most egyetlen Aspose.Slides névtérbe van összevonva. Tekintse meg az alábbi egyszerű kódrészletet, amely a fejléc és lábléc hozzáadását mutatja a prezentációhoz a régi Aspose.Slides API-ban, és kövesse a lépéseket a új összevont API-ra való áttéréshez.
## **Legacy Aspose.Slides for .NET megközelítés**
```c#
PresentationEx sourcePres = new PresentationEx();

//Fejléc és lábléc láthatósági beállításai
sourcePres.UpdateSlideNumberFields = true;

//Dátum és idő mezők frissítése
sourcePres.UpdateDateTimeFields = true;

//Dátum és idő helyőrző megjelenítése
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Lábléc helyőrző megjelenítése
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Dia szám megjelenítése
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//A címdia fejléc és lábléc láthatóságának beállítása
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//A prezentáció kiírása a lemezre
sourcePres.Write("NewSource.pptx");
```

```c#
 //A prezentáció létrehozása
 Presentation pres = new Presentation();
 
 //Az első dia lekérése
 Slide sld = pres.GetSlideByPosition(1);
 
 //A dia fejlécének/láblécének elérése
 HeaderFooter hf = sld.HeaderFooter;
 
 //Oldalszám láthatóságának beállítása
 hf.PageNumberVisible = true;
 
 //Lábléc láthatóságának beállítása
 hf.FooterVisible = true;
 
 //Fejléc láthatóságának beállítása
 hf.HeaderVisible = true;
 
 //Dátum és idő láthatóságának beállítása
 hf.DateTimeVisible = true;
 
 //Dátum és idő formátumának beállítása
 hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;
 
 //Fejléc szövegének beállítása
 hf.HeaderText = "Header Text";
 
 //Lábléc szövegének beállítása
 hf.FooterText = "Footer Text";
 
 //A prezentáció írása a lemezre
 pres.Write("HeadFoot.ppt");
```



## **Új Aspose.Slides for .NET 13.x megközelítés**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //Fejléc és lábléc láthatósági beállításai
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Dátum és idő mezők frissítése
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Dátum és idő helyőrző megjelenítése
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Lábléc helyőrző megjelenítése
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //A címdia fejléc és lábléc láthatóságának beállítása
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //A prezentáció írása a lemezre
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
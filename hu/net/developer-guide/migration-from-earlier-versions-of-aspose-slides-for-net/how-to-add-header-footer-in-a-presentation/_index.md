---
title: Hogyan adjunk fejléceket és lábléceket a prezentációkhoz .NET-ben
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
description: "Ismerje meg, hogyan adhat hozzá fejléceket és lábléceket PowerPoint PPT, PPTX és ODP prezentációkhoz .NET-ben, a régi és az új Aspose.Slides API-k használatával."
---
{{% alert color="info" %}} 

Megjelent egy új [Aspose.Slides for .NET API](/slides/hu/net/), és most ez a termék képes üres PowerPoint dokumentumok létrehozására, valamint a meglévők szerkesztésére.

{{% /alert %}} 
## **Legacy kód támogatása**
Az Aspose.Slides for .NET 13.x-el előtti verziókhoz fejlesztett legacy kód használatához néhány kisebb módosítást kell végrehajtani a kódban, és az kód továbbra is a korábbi módon fog működni. Az összes osztály, amely a régi Aspose.Slides for .NET-ben az Aspose.Slide és az Aspose.Slides.Pptx névterekben található volt, most egyetlen Aspose.Slides névtérbe egyesült. Kérjük, tekintse meg az alábbi egyszerű kódrészletet, amely a fejléc és lábléc hozzáadását mutatja a prezentációhoz a régi Aspose.Slides API-ban, és kövesse az új egyesített API-ra történő migráció lépéseit.
## **Legacy Aspose.Slides for .NET megközelítés**
```c#
PresentationEx sourcePres = new PresentationEx();

//Fejléc és lábléc láthatósági tulajdonságainak beállítása
sourcePres.UpdateSlideNumberFields = true;

//Dátum és idő mezők frissítése
sourcePres.UpdateDateTimeFields = true;

//Dátum és idő helyőrző megjelenítése
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Lábléc helyőrző megjelenítése
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Dia szám megjelenítése
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Set the  header footer visibility on Title Slide
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//A prezentáció írása a lemezre
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//Prezentáció létrehozása
Presentation pres = new Presentation();

//Első dia lekérése
Slide sld = pres.GetSlideByPosition(1);

//A dia fejlécének és láblécének elérése
HeaderFooter hf = sld.HeaderFooter;

//Dia szám láthatóságának beállítása
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

//Prezentáció írása a lemezre
pres.Write("HeadFoot.ppt");
```



## **Új Aspose.Slides for .NET 13.x megközelítés**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //Fejléc és lábléc láthatósági tulajdonságainak beállítása
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //Dátum és idő mezők frissítése
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Dátum és idő helyőrző megjelenítése
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //Lábléc helyőrző megjelenítése
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //A címoldalon a fejléc és lábléc láthatóságának beállítása
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //A prezentáció írása a lemezre
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
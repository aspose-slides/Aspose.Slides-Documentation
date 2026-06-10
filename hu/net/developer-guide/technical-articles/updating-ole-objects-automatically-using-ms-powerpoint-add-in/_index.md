---
title: OLE-objektumok automatikus frissítése PowerPoint bővítmény segítségével
type: docs
weight: 10
url: /hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE objektum
- OLE frissítése
- automatikusan
- bővítmény
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan lehet automatikusan frissíteni az OLE diagramokat és objektumokat a PowerPointban bővítmény és az Aspose.Slides for .NET segítségével, gyakorlati kóddal és optimalizálási tippekkel."
---
## **Bevezetés**

Az Aspose.Slides for .NET ügyfelei leggyakrabban felmerülő kérdése, hogyan hozhatók létre vagy módosíthatók szerkeszthető diagramok (vagy egyéb OLE-objektumok), hogy a bemutató megnyitásakor automatikusan frissüljenek. Sajnos a PowerPoint nem támogatja az automatikus makrókat ugyanúgy, mint az Excel és a Word. Az egyetlen elérhető makró a `Auto_Open` és a `Auto_Close`, és ezek csak bővítményből futnak automatikusan. Ez a rövid technikai tipp bemutatja, hogyan lehet ezt elérni.

## **OLE-objektumok automatikus frissítése**

Először is több ingyenes bővítmény is elérhető, amely a PowerPointhez hozzáadja az Auto_Open makró funkciót, például az [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) és a [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Az egyik bővítmény telepítése után egyszerűen adja hozzá a `Auto_Open()` makrót (vagy a `OnPresentationOpen()`‑t, ha az Event Generator‑t használja) a sablonbemutatóhoz, ahogyan az alább látható:

```cs
public void Auto_Open()
{
    // A bemutató minden diáján végigiterál.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Az aktuális dián lévő összes alakzaton végigiterál.
        foreach (var oShape in oSlide.Shapes)
        {
            // Ellenőrzi, hogy az alakzat OLE-objektum-e.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // OLE-objektumot talált. Lekéri az objektum hivatkozását, majd frissíti.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Most kilép az OLE kiszolgáló programból.
                // Ez felszabadítja a memóriát, és megakadályozza a problémákat.
                // Továbbá a oObject-et Nothing-ra állítja, hogy felszabadítsa az objektumot.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

Az Aspose.Slides for .NET‑tel készített OLE-objektumok bármely módosítása automatikusan frissül, amikor a PowerPoint megnyitja a bemutatót. Ha sok OLE-objektum van, és nem szeretné mindet frissíteni, egyszerűen adjon egy egyedi címkét a feldolgozni kívánt alakzatokhoz, és ellenőrizze azt a makróban.
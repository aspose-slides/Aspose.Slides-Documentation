---
title: Prezentáció Diák Elérése .NET-ben
linktitle: Dia Elérése
type: docs
weight: 20
url: /hu/net/access-slide-in-presentation/
keywords:
- dia elérése
- dia index
- dia azonosító
- dia pozíció
- pozíció módosítása
- dia tulajdonságok
- dia száma
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan lehet elérni és kezelni a diákot PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET segítségével. Növelje a termelékenységet kódpéldákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet hozzáférni és kezelni a diákot egy bemutatóban az Aspose.Slides használatával. Megmutatja, hogyan lehet a diákot lekérni a nulla alapú indexük alapján a `Slides` gyűjteményből, és hogyan lehet egy diát elérni az egyedi azonosítója segítségével a `GetSlideById` metódussal.

Megtanulja, hogyan lehet megváltoztatni egy dia helyét a `SlideNumber` tulajdonság beállításával, és hogyan lehet meghatározni a bemutató kezdő diaszámát a `FirstSlideNumber` tulajdonsággal. A példák bemutatják a bemutató betöltését, a diareferenciák lekérését, a dia sorrendjének vagy számozásának frissítését és a módosított bemutató mentését.

## **Dia elérése index szerint**

A bemutató összes diáját numerikusan rendezik a dia pozíciója alapján, 0-tól kezdve. Az első dia elérhető a 0 indexen; a második a 1 indexen; stb.

A Presentation osztály, amely egy bemutató fájlt képvisel, az összes diát egy [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) gyűjteményként (a [ISlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/) objektumok gyűjteménye) teszi elérhetővé. Ez a C# kód megmutatja, hogyan lehet egy diát elérni az indexe alapján:

```c#
// Létrehozza a Presentation objektumot, amely egy prezentációfájlt képvisel
Presentation presentation = new Presentation("AccessSlides.pptx");

// Lekéri egy dia referenciáját az indexe alapján
ISlide slide = presentation.Slides[0];
```

## **Dia elérése azonosító szerint**

Minden diának a bemutatóban egy egyedi azonosítója van. A [GetSlideById](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/methods/getslidebyid) metódust (amely a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályban érhető el) használhatja az adott azonosító célzásához. Ez a C# kód megmutatja, hogyan adjon meg egy érvényes diák azonosítót, és hogyan érje el azt a [GetSlideById](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/methods/getslidebyid) metódussal:

```c#
// Létrehozza a Presentation objektumot, amely egy prezentációfájlt képvisel
Presentation presentation = new Presentation("AccessSlides.pptx");

// Lekéri egy dia azonosítóját
uint id = presentation.Slides[0].SlideId;

// Eléri a diát az azonosítója alapján
IBaseSlide slide = presentation.GetSlideById(id);
```

## **Dia helyének módosítása**

Az Aspose.Slides lehetővé teszi a dia pozíciójának megváltoztatását. Például megadhatja, hogy az első dia a második diává váljon.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezze meg a dia referenciáját (amelynek a pozícióját módosítani szeretné) az indexe alapján
1. Állítson be egy új pozíciót a diához a [SlideNumber](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/slidenumber/) tulajdonság segítségével.
1. Mentse el a módosított bemutatót.

Ez a C# kód bemutat egy olyan műveletet, ahol az 1 pozícióban lévő dia a 2 pozícióba kerül:

```c#
// Létrehozza a Presentation objektumot, amely egy prezentációfájlt képvisel
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Lekéri azt a diát, amelynek a pozícióját megváltoztatjuk
    ISlide sld = pres.Slides[0];

    // Beállítja a dia új pozícióját
    sld.SlideNumber = 2;

    // Mentés a módosított prezentációt
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

Az első dia a második lett; a második dia az első lett. Amikor megváltoztatja egy dia pozícióját, a többi dia automatikusan igazodik.

## **Dia számának beállítása**

A [FirstSlideNumber](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/firstslidenumber/) tulajdonság (amely a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályban érhető el) használatával megadhat egy új számot a bemutató első diája számára. Ez a művelet az összes többi diaszám újraszámítását eredményezi.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezze meg a dia számát.
1. Állítsa be a dia számát.
1. Mentse el a módosított bemutatót.

Ez a C# kód bemutat egy olyan műveletet, ahol az első dia száma 10-re van beállítva:

```c#
// Létrehozza a Presentation objektumot, amely egy prezentációfájlt képvisel
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Lekéri a dia számát
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Beállítja a dia számát
    presentation.FirstSlideNumber=10;
    
    // Mentés a módosított prezentációt
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

Ha inkább kihagyja az első diát, a számozást a második diával kezdheti (és elrejtheti az első dia számozását) így:

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Beállítja az első prezentációs dia számát
    // Megjeleníti a dia számokat az összes dián
    // Elrejti az első dia számát
    // Mentés a módosított prezentációt
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Gyakran Ismételt Kérdések**

**A felhasználó által látható diaszám megegyezik a gyűjtemény nulla alapú indexével?**

A dián megjelenő szám tetszőleges értéktől (például 10) kezdődhet, és nem kell, hogy megegyezzen az indexszel; a kapcsolatot a bemutató [first slide number](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/firstslidenumber/) beállítása szabályozza.

**A rejtett diák befolyásolják az indexelést?**

Igen. A rejtett dia a gyűjteményben marad és számít az indexelésnél; a "hidden" a megjelenítésre vonatkozik, nem a gyűjteményben betöltött pozíciójára.

**Változik egy dia indexe, ha más diák hozzáadódnak vagy eltávolításra kerülnek?**

Igen. Az indexek mindig a diák aktuális sorrendjét tükrözik, és a beszúrás, törlés és áthelyezés műveletek során újraszámításra kerülnek.
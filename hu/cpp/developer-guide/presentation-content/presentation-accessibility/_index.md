---
title: Prezentációhozzáférhetőség kezelése C++-ban
linktitle: Prezentációhozzáférhetőség
type: docs
weight: 30
url: /hu/cpp/presentation-accessibility/
keywords:
- prezentáció hozzáférhetőség
- alternatív szöveg
- alternatív szövegcím
- alternatív szövegleírás
- dekoratívként megjelölés
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Automatizálja a prezentációk hozzáférhetőségi ellenőrzését PPT, PPTX és ODP fájlokban az Aspose.Slides for C++ segítségével - javítsa a képernyőolvasó élményét és növelje a megfelelőséget."
---
## **Bevezetés**

Az alternatív szöveg segíti a segédeszközöket használó embereket megérteni a képek, diagramok és egyéb tájékoztató alakzatok jelentését. Ez a cikk bemutatja, hogyan lehet olvasni és frissíteni az alternatív szövegcímeket és leírásokat az Aspose.Slides for C++‑vel, megkülönböztetni a hozzáférhetőségi leírásokat a kódban használt alakzatal nevektől, és ellenőrizni, hogy egy alakzat dekoratívként van‑e jelölve.

Ezek a funkciók támogatják a prezentációk hozzáférhetőségét, de nem garantálják azt. A felolvasási sorrendet, a színkontrasztot, a szöveg olvashatóságát és egyéb hozzáférhetőségi követelményeket is felül kell vizsgálni.

## **Az alternatív szövegcímek és leírások kezelése**

Az alternatív szöveget arra használjuk, hogy elmagyarázzuk a képek, diagramok és egyéb tájékoztató alakzatok jelentését azok számára, akik nem láthatják őket. A következő tulajdonságok különböző célokat szolgálnak:

| Tulajdonság vagy tartalom | Cél |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_alternativetexttitle/) | Az alternatív leírás rövid címe. |
| [AlternativeText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_alternativetext/) | Az alakzat tartalmának vagy céljának értelmes leírása a dia kontextusában. |
| [Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_name/) | Az alakzat neve, amelyet a kód használhat egy adott alakzat megtalálásához a prezentációban. |
| Visible text | A dián megjelenő tartalom, például az alakzat szövege vagy a diagram címe és címkéi. Az alternatív szöveg frissítése nem módosítja ezt a tartalmat. |

Amikor egy prezentációt sablonként használnak újra, a kód megtalálhat egy alakzatot a [Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_name/) segítségével, mielőtt frissítené azt. Ez a név más célra szolgál, mint az alternatív szöveg, amely azt magyarázza, mit közvetít a vizuális elem az olvasónak. Név szerinti keresés lehetővé teszi a szerzők számára, hogy javítsák vagy lefordítsák a leírásokat anélkül, hogy megváltoztatnák, hogyan találja meg a kód az alakzatot. A neveket szerkeszthető, és nincs garancia arra, hogy egyediek, ezért ellenőrizni kell, hogy a név a kívánt alakzatra mutat; lásd [Identify and Find Shapes](/slides/hu/cpp/shape-manipulations/#identify-and-find-shapes).

A következő példa egy `input.pptx` fájlt igényel, amelyen egy irodai bejárat képe van az első dia első alakzataként. A képet nem szabad dekoratívként megjelölni. A példa kiolvassa és kiírja az aktuális alternatív szövegcímet és leírást, frissíti mindkét értéket, majd a prezentációt `output.pptx`‑ként menti. A szöveget igazítsa a tényleges képhez és a közvetített információkhoz.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az alternatív szöveg hozzáadása önmagában nem garantálja a prezentáció hozzáférhetőségét vagy a hozzáférhetőségi szabványoknak való megfelelést. Ellenőrizze a leírások pontosságát és relevanciáját, valamint vizsgálja meg a felolvasási sorrendet, a színkontrasztot, az olvasható szöveget és egyéb hozzáférhetőségi követelményeket. A tájékoztató vizuális elemeket nem szabad dekoratívként jelölni; a következő szakasz bemutatja, hogyan olvasható a [IsDecorative](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_isdecorative/).

## **Dekoratívként jelölés**

A „Mark as decorative” jelző a pusztán díszítő vizuális elemeket jelöli meg, hogy a képernyőolvasók átugorják őket, csökkentve a zajt és a figyelmet a lényeges tartalomra irányítva. Alkalmazza háttérképekre, díszítőelemekre és elválasztókra – soha diagramokra, ikonokra vagy információt közvetítő képekre ne. Az Aspose.Slides ezt a jelzőt elérhetővé teszi a felderítéshez és ellenőrzéshez, lehetővé téve az automatikus hozzáférhetőségi ellenőrzéseket és a takarítást.

![Mark as Decorative](mark_as_decorative.png)

A következő kódminta bemutatja, hogyan lehet meghatározni, hogy egy alakzat dekoratívként van‑e jelölve.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **GYIK**

**Mit kell a alternatív szövegcímbe és leírásba helyezni?**

Használjon rövid címet a tárgy azonosításához, és leírást, hogy elmagyarázza, milyen információt közvetít a vizuális elem a dia kontextusában. Diagram esetén írja le a releváns trendet vagy összehasonlítást, ahelyett, hogy csak „diagram”‑nak nevezné.

**Használjam az alternatív szöveget a sablonban lévő alakzatok megtalálására?**

Előnyben részesítse az alakzat megtalálását a [Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_name/) segítségével, és ellenőrizze, hogy a várt alakzatról van‑e szó. Az alternatív szöveget szerkeszthetik vagy lefordíthatják, ami tönkreteheti a pontos leírást kereső kódot; lásd [Identify and Find Shapes](/slides/hu/cpp/shape-manipulations/).

**Mikor kell egy alakzatot dekoratívként jelölni?**

Használja a dekoratív jelzőt olyan vizuális elemeknél, amelyek nem adnak információt, például díszítő mintáknál. A jelentést közvetítő képeknek és diagramoknak megfelelő leírással kell rendelkezniük.

**Az alternatív szöveg hozzáadása teljesen hozzáférhetővé teszi a prezentációt?**

Nem. Az alternatív szöveg csak a hozzáférhetőség egy részét fedi le. Ellenőrizze a felolvasási sorrendet, a színkontrasztot, a szöveg olvashatóságát és egyéb vonatkozó követelményeket; ezeknek a tulajdonságoknak a beállítása önmagában nem biztosítja a megfelelést.
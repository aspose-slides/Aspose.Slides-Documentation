---
title: Prezentációk konvertálása HTML5-re C++-ban
linktitle: Prezentáció HTML5-re
type: docs
weight: 40
url: /hu/cpp/export-to-html5/
keywords:
- PowerPoint HTML5-re
- OpenDocument HTML5-re
- prezentáció HTML5-re
- dia HTML5-re
- PPT HTML5-re
- PPTX HTML5-re
- ODP HTML5-re
- PPT mentése HTML5-ként
- PPTX mentése HTML5-ként
- ODP mentése HTML5-ként
- PPT exportálása HTML5-re
- PPTX exportálása HTML5-re
- ODP exportálása HTML5-re
- C++
- Aspose.Slides
description: "Exportálja a PowerPoint és OpenDocument prezentációkat reszponzív HTML5-re az Aspose.Slides for C++ használatával. Megőrizze a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációkat HTML5‑re konvertálni az Aspose.Slides használatával. Lefedi az alapvető HTML5‑exportálást webes kiterjesztések vagy további függőségek nélkül, valamint a formák animációinak és a diák átmeneteinek vezérlésének lehetőségeit. A cikk bemutatja a szabványos PowerPoint‑HTML exportfolyamatot, megmagyarázza, hogyan generálhat HTML5 kimenetet dianézet módban, és bemutatja, hogyan lehet megjegyzéseket belefoglalni az exportált dokumentumba a elrendezés beállításával.

## **PowerPoint exportálása HTML5‑re**

Ez a C++ kód bemutatja, hogyan lehet egy prezentációt HTML5‑re exportálni.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
Ebben az esetben tiszta HTML-et kap.
{{% /alert %}}

Ily módon megadhatja a formaanimációk és diaátmenetek beállításait:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **PowerPoint exportálása HTML‑re**

Ez a C++ bemutatja a szabványos PowerPoint‑HTML folyamatot:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

Ebben az esetben a prezentáció tartalma SVG‑n keresztül jelenik meg, ilyen formában:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
Ha ezt a módszert használja a PowerPoint HTML‑re exportálásához, az SVG renderelés miatt nem lesz lehetősége stílusokat alkalmazni vagy specifikus elemeket animálni. 
{{% /alert %}}

## **PowerPoint exportálása HTML5 dia nézetben**

**Aspose.Slides** lehetővé teszi, hogy egy PowerPoint‑prezentációt HTML5 dokumentummá konvertáljon, amelyben a diák dia‑nézet módban jelennek meg. Ebben az esetben, amikor a keletkezett HTML5 fájlt egy böngészőben megnyitja, a prezentációt dia‑nézet módban láthatja egy weboldalon. 

Ez a C++ kód bemutatja a PowerPoint‑HTML5 dia‑nézet exportfolyamatot:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Prezentáció konvertálása HTML5 dokumentummá megjegyzésekkel**

Megjegyzések a PowerPointban olyan eszközök, amelyek lehetővé teszik a felhasználók számára, hogy jegyzeteket vagy visszajelzéseket hagyjanak a prezentáció diáin. Különösen hasznosak együttműködési projektekben, ahol több személy is hozzáadhatja javaslatait vagy megjegyzéseit a diához tartozó konkrét elemekhez anélkül, hogy a fő tartalmat módosítaná. Minden megjegyzés megjeleníti a szerző nevét, így könnyű nyomon követni, ki hagyta a megjegyzést.

Legyen például, hogy a következő PowerPoint‑prezentáció a "sample.pptx" fájlban van mentve.

![Két megjegyzés a prezentáció diáján](two_comments_pptx.png)

Amikor egy PowerPoint‑prezentációt HTML5 dokumentummá konvertál, könnyen megadhatja, hogy a megjegyzéseket belevegye‑e a kimeneti dokumentumba. Ehhez be kell állítania a megjegyzések megjelenítési paramétereit a `get_NotesCommentsLayouting` metódusban a [Html5Options](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/) osztályban.

A következő kódrészlet egy prezentációt konvertál HTML5 dokumentummá, ahol a megjegyzések a diák jobb oldalán jelennek meg.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Az "output.html" dokumentum az alábbi képen látható.

![A megjegyzések a kimeneti HTML5 dokumentumban](two_comments_html5.png)

## **GYIK**

### Lehet‑e szabályozni, hogy az objektum animációk és a diaátmenetek lejátszódjanak‑e HTML5‑ben?

Igen, a HTML5 különálló beállításokat kínál a [formaanimációk](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/set_animateshapes/) és a [diaátmenetek](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/set_animatetransitions/) engedélyezésére vagy letiltására.

### Támogatott‑e a megjegyzések kimenete, és hol helyezhetők el a diahoz képest?

Igen, a megjegyzések hozzáadhatók a HTML5‑ben, és a jegyzetek és megjegyzések elrendezési beállításain keresztül elhelyezhetők (például a dia jobb oldalán).

### Kihagyhatok JavaScript‑hívásokat tartalmazó linkeket biztonsági vagy CSP okokból?

Igen, létezik egy [beállítás](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), amely lehetővé teszi a JavaScript hívásokat tartalmazó hiperhivatkozások kihagyását mentéskor. Ez segít a szigorú biztonsági irányelvek betartásában.
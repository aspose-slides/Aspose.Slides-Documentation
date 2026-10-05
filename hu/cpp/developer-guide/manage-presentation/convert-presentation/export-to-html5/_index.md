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
- PPT exportálása HTML5-be
- PPTX exportálása HTML5-be
- ODP exportálása HTML5-be
- C++
- Aspose.Slides
description: "Exportálja a PowerPoint és OpenDocument prezentációkat reszponzív HTML5-be az Aspose.Slides for C++ segítségével. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet PowerPoint‑prezentációkat HTML5‑re konvertálni az Aspose.Slides for C++ használatával. Lefedi az alapvető exportálást, az alakzat‑animációk és a diaátmenetek vezérlését, valamint a megjegyzések elrendezését. Továbbá összehasonlítja a HTML5‑kimenetet a szabványos HTML‑export SVG‑alapú kimenetével.

## **PowerPoint exportálása HTML5‑re**

Az alábbi példa betölti a prezentációt a munkakönyvtárból, és HTML5 formátumban menti el. Az alapértelmezett exportbeállításokat használja; a következő példa kifejezetten bemutatja az animáció lejátszásának vezérlését. Cserélje le a bemeneti útvonalat a saját prezentációja útvonalára.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
A HTML-dokumentum mellett az export támogatást ír ki CSS és JavaScript fájlok formájában a diastílusokhoz, animációkhoz, effektusokhoz és navigációhoz. Ezeket a fájlokat a HTML-dokumentummal együtt tartsa meg a kimenet áthelyezésekor vagy közzétételénél. A generált oldal jQuery‑t és Anime.js‑t tölt be nyilvános CDN‑ekről; ezek nélkül a dia‑navigáció és az animációk nem működnek.
{{% /alert %}}

A formaanimációk vagy diaátmenetek lejátszása nélküli exportáláshoz `false` értéket kell megadni a [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) és a [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) metódusoknak a [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) objektumban. Ezek a beállítások függetlenek, ezért egyet engedélyezhet, miközben a másikat letiltja. A példában a prezentáció mindkét animációt letiltva kerül exportálásra a generált oldalon.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **PowerPoint exportálása HTML‑re**

A szabványos HTML‑export másik megjelenítési megközelítést használ: a dia‑tartalom SVG‑ként jelenik meg egy HTML‑oldalon belül. Az alábbi példa egy prezentációt HTML‑dokumentummá konvertál ezzel a megjelenítési megközelítéssel.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

Az alább bemutatott egyszerűsített jelölőkód illusztrálja a generált oldal felépítését. Az SVG‑elem tartalmazza a renderelt dia‑tartalmat; a helyőrző szöveg azt a tartalmat képviseli, és nem a tényleges exportkimenet.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
Az SVG‑alapú export nem teszi elérhetővé a PowerPoint‑alakzatokat egyedi HTML elemekként. Használja a HTML5 exportot, ha a cikkben bemutatott alakzat‑animációs és dia‑átmenet‑opciókra van szüksége.
{{% /alert %}}

## **PowerPoint exportálása HTML5 dianézetre**

A HTML5 export egy oldalt hoz létre a prezentációs diák böngészőben való megtekintéséhez és navigálásához. Ez a példa `true`‑t ad meg mind a [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/), mind a [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) számára, így az exportált dianézet le tudja játszani a forrás‑prezentáció effektjeit.

Használjon olyan prezentációt, amely már tartalmaz alakzat‑animációkat és dia‑átmeneteket, hogy lássa ezen beállítások hatását. Ezek engedélyezése nem ad hozzá új effektusokat azokhoz a diákhoz, amelyeknek egyikük sincs. Exportálás után nyissa meg a generált HTML5 dokumentumot egy böngészőben, ahol a támogató fájlok elérhetők.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Prezentáció konvertálása HTML5 dokumentummá megjegyzésekkel**

A meglévő diamegjegyzések beilleszthetők a HTML5‑kimenetbe, így az olvasók a visszajelzéseket a dia‑tartalom mellett láthatják. Az ebben a szakaszban szereplő példa azt a feltételezi, hogy a forrás‑prezentáció tartalmaz megjegyzéseket, ahogyan azt lentebb illusztrálják. Ezeket a megjegyzéseket exportálja; újakat nem hoz létre.

![Két megjegyzés a prezentációs dián](two_comments_pptx.png)

Adj át egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) objektumot a [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) metódusnak a [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) példányban. Hívja meg a [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) metódust a `CommentsPositions::Right` értékkel a [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) felsorolásból, hogy a megjegyzéseket az egyes diák jobb oldalára helyezze.

Az alábbi példa a prezentációt HTML5‑re exportálja ezzel a megjegyzés‑elrendezéssel. Egy megjegyzéseket nem tartalmazó prezentáció nem jelenít meg semmilyen megjegyzés‑szöveget.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

![A megjegyzések a kimeneti HTML5 dokumentumban](two_comments_html5.png)

## **JavaScript hiperhivatkozások kizárása az exportálás során**

Tegyük fel, hogy a `hyperlinks.pptx` tartalmaz olyan hivatkozott szöveget, amelynek célja egy `javascript:alert('Hello')` hívás, valamint egy szokványos `https://example.com/` hivatkozás. A JavaScript hiperhivatkozás kizárásához az exportálás során hívd meg a [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) metódust `true` értékkel. Az alapértelmezett érték `false`, így ezek a hivatkozások nem lesznek szűrve, hacsak nem engedélyezi a lehetőséget.

Az alábbi példa betölti a prezentációt a munkakönyvtárból, és [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) használatával exportálja:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Az exportált fájl kihagyja a JavaScript hiperhivatkozást, miközben megtartja annak szövegét és a szokványos HTTPS hivatkozást. A forrás‑prezentáció változatlan marad.

Ez a beállítás JavaScript hiperhivatkozásokat szűr, de nem távolít el minden szkriptet vagy egyéb aktív tartalmat, és nem garantál CSP‑megtartást. Például a HTML5‑kimenet továbbra is tartalmaz szkripteket a dia‑navigációhoz és az animációkhoz.

## **GYIK**

**Le tudom szabályozni, hogy az objektumanimációk és diaátmenetek lejátszódjanak-e HTML5-ben?**  
Igen, a HTML5 export különálló beállításokat biztosít a [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) és a [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) engedélyezésére vagy letiltására.

**Támogatottak a megjegyzések, és hol helyezhetők el a diához képest?**  
Igen, a meglévő megjegyzések belefoglalhatók a HTML5 kimenetbe, és elhelyezhetők (például a dia jobb oldalára) a [layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) segítségével a jegyzetek és megjegyzések számára.

**Kihagyhatom a JavaScript‑et meghívó hivatkozásokat biztonsági vagy CSP okokból?**  
Igen, a [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) metódus lehetővé teszi, hogy a mentés során kihagyja a JavaScript hívásokat tartalmazó hiperhivatkozásokat. Az alapértelmezett érték `false`. Lásd a [JavaScript hiperhivatkozások kizárása az exportálás során](/slides/hu/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) szakaszt egy HTML5 exportálási példáért és a szűrő hatóköréért. Ez a beállítás nem távolítja el a HTML5 néző által a navigációhoz és animációkhoz használt JavaScript‑et.
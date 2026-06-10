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
description: "Exportálja a PowerPoint és OpenDocument prezentációkat reszponzív HTML5-be az Aspose.Slides for C++ használatával. Megőrzi a formázást, animációkat és az interaktivitást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan konvertálhatók PowerPoint‑prezentációk HTML5-re az Aspose.Slides segítségével. Lefedi az egyszerű HTML5‑exportot webes kiegészítők vagy további függőségek nélkül, valamint a formaanimációk és diaátmenetek vezérlésének lehetőségeit. A cikk bemutatja a szabványos PowerPoint‑HTML exportfolyamatot, elmagyarázza, hogyan generálható HTML5‑kimenet dia‑nézet módban, és megmutatja, hogyan lehet megjegyzéseket belefoglalni a exportált dokumentumba a elrendezés konfigurálásával.

## **PowerPoint exportálása HTML5-be**

Ez a C++ kód megmutatja, hogyan exportálhat egy prezentációt HTML5‑be.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 
Ebben az esetben tiszta HTML‑t kapunk. 
{{% /alert %}}

Lehet, hogy így szeretné beállítani a formaanimációk és diaátmenetek paramétereit:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **PowerPoint exportálása HTML-be**

Ez a C++ bemutatja a szabványos PowerPoint‑HTML folyamatot:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

Ebben az esetben a prezentáció tartalma SVG‑ként kerül megjelenítésre a következő módon:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Megjegyzés" color="warning" %}} 
Ha ezzel a módszerrel exportál PowerPoint‑ot HTML‑be, az SVG‑renderelés miatt nem lesz képes stílusokat alkalmazni vagy egyes elemeket animálni. 
{{% /alert %}}

## **PowerPoint exportálása HTML5 dia‑nézetbe**

**Aspose.Slides** lehetővé teszi, hogy egy PowerPoint‑prezentációt HTML5 dokumentummá konvertáljon, amelyben a diák dia‑nézet módban jelennek meg. Ebben az esetben, ha a létrejött HTML5‑fájlt egy böngészőben nyitja meg, a prezentációt dia‑nézetben láthatja egy weboldalon.

Ez a C++ kód demonstrálja a PowerPoint‑HTML5 dia‑nézet export folyamatát:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Prezentáció konvertálása HTML5 dokumentummá megjegyzésekkel**

A PowerPoint megjegyzései olyan eszközök, amelyek lehetővé teszik a felhasználók számára, hogy megjegyzéseket vagy visszajelzéseket hagyjanak a prezentációs diákon. Különösen hasznosak együttműködő projektekben, ahol több ember is hozzáadhatja javaslatait vagy megjegyzéseit adott diaelemekhez anélkül, hogy a fő tartalmat módosítaná. Minden megjegyzés megjeleníti a szerző nevét, így könnyen nyomon követhető, ki hagyta a megjegyzést.

Tegyük fel, hogy a következő PowerPoint‑prezentációt a „sample.pptx” fájlban mentettük.

![Két megjegyzés a prezentációs dián](two_comments_pptx.png)

Amikor egy PowerPoint‑prezentációt HTML5‑dokumentummá konvertál, könnyen megadhatja, hogy a prezentációból származó megjegyzéseket bele szeretné-e foglalni a kimeneti dokumentumba. Ehhez a `get_NotesCommentsLayouting` metódusban kell beállítania a megjegyzések megjelenítési paramétereit a [Html5Options](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/) osztályban.

Az alábbi kódrészlet egy prezentációt konvertál HTML5‑dokumentummá, a megjegyzéseket a diák jobb oldalán megjelenítve.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Az „output.html” dokumentum az alábbi képen látható.

![A megjegyzések az output HTML5 dokumentumban](two_comments_html5.png)

## **GYIK**

**Képes vagyok szabályozni, hogy az objektumanimációk és diaátmenetek lejátszódjanak-e HTML5‑ben?**

Igen, a HTML5 külön beállításokat kínál a [shape animációk](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/set_animateshapes/) és a [slide átmenetek](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/html5options/set_animatetransitions/) engedélyezésére vagy letiltására.

**Támogatott-e a megjegyzések kimenete, és hol helyezhetők el a diához képest?**

Igen, a megjegyzések hozzáadhatók HTML5‑ben, és elhelyezhetők (például a dia jobb oldalán) a jegyzetek és megjegyzések elrendezési beállításaival.

**Kihagyhatom-e azokat a hivatkozásokat, amelyek JavaScript‑et hívnak meg biztonsági vagy CSP‑okból adódó okokból?**

Igen, van egy [beállítás](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), amely lehetővé teszi a JavaScript‑hívásokat tartalmazó hiperhivatkozások kihagyását mentéskor. Ez segít a szigorú biztonsági irányelvek betartásában.
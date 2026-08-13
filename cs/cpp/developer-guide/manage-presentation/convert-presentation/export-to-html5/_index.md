---
title: Převod prezentací do HTML5 v C++
linktitle: Prezentace do HTML5
type: docs
weight: 40
url: /cs/cpp/export-to-html5/
keywords:
- PowerPoint do HTML5
- OpenDocument do HTML5
- prezentace do HTML5
- snímek do HTML5
- PPT do HTML5
- PPTX do HTML5
- ODP do HTML5
- uložit PPT jako HTML5
- uložit PPTX jako HTML5
- uložit ODP jako HTML5
- exportovat PPT do HTML5
- exportovat PPTX do HTML5
- exportovat ODP do HTML5
- C++
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do responzivního HTML5 pomocí Aspose.Slides pro C++. Zachovejte formátování, animace a interaktivitu."
---
## **Přehled**

Tento článek popisuje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides. Pokrývá základní export do HTML5 bez webových rozšíření nebo dalších závislostí, stejně jako možnosti řízení animací tvarů a přechodů snímků. Článek také ukazuje standardní proces exportu PowerPoint do HTML, vysvětluje, jak vygenerovat výstup HTML5 v režimu zobrazení snímků, a demonstruje, jak zahrnout komentáře do exportovaného dokumentu konfigurací jejich rozvržení.

## **Export PowerPoint do HTML5**

Tento C++ kód ukazuje, jak exportovat prezentaci do HTML5.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
V tomto případě získáte čisté HTML. 
{{% /alert %}}

Možná budete chtít tímto způsobem specifikovat nastavení pro animace tvarů a přechody snímků:

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

## **Export PowerPoint do HTML**

Tento C++ demonstrativně ukazuje standardní proces exportu PowerPoint do HTML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

V tomto případě je obsah prezentace vykreslen pomocí SVG v následující podobě:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Poznámka" color="warning" %}} 
Když použijete tuto metodu pro export PowerPoint do HTML, kvůli vykreslování SVG nebudete moci aplikovat styly ani animovat konkrétní prvky. 
{{% /alert %}}

## **Export PowerPoint do HTML5 v režimu zobrazení snímků**

**Aspose.Slides** umožňuje převést prezentaci PowerPoint do dokumentu HTML5, ve kterém jsou snímky zobrazeny v režimu zobrazení snímků. V tomto případě, když otevřete výsledný soubor HTML5 v prohlížeči, vidíte prezentaci v režimu zobrazení snímků na webové stránce.

Tento C++ kód demonstruje proces exportu PowerPoint do HTML5 v režimu zobrazení snímků:

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

## **Převod prezentace do HTML5 dokumentu s komentáři**

Komentáře v PowerPoint jsou nástrojem, který uživatelům umožňuje zanechat poznámky nebo zpětnou vazbu k snímkům prezentace. Jsou zvláště užitečné v kolaborativních projektech, kde více lidí může přidávat své návrhy nebo připomínky k jednotlivým prvkům snímků, aniž by měnili hlavní obsah. Každý komentář zobrazuje jméno autora, což usnadňuje sledovat, kdo připomínku zanechal.

Předpokládejme, že máme následující prezentaci PowerPoint uloženou v souboru „sample.pptx“.

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Když převádíte prezentaci PowerPoint do HTML5 dokumentu, můžete snadno určit, zda zahrnout komentáře z prezentace do výstupního dokumentu. K tomu je nutné nastavit parametry zobrazení komentářů v metodě `get_NotesCommentsLayouting` třídy [Html5Options](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/).

Následující ukázka kódu převádí prezentaci do HTML5 dokumentu s komentáři zobrazenými vpravo od snímků.
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

Dokument „output.html“ je zobrazen na obrázku níže.

![Komentáře v exportovaném dokumentu HTML5](two_comments_html5.png)

## **Často kladené otázky**

### Můžu řídit, zda se animace objektů a přechody snímků přehrávají v HTML5?

Ano, HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [shape animations](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/set_animateshapes/) a [slide transitions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/set_animatetransitions/).

### Je podpora výstupu komentářů a kde je lze umístit vzhledem k snímku?

Ano, komentáře lze v HTML5 přidat a umístit (například vpravo od snímku) pomocí nastavení rozvržení pro poznámky a komentáře.

### Mohu vynechat odkazy, které volají JavaScript, z důvodu bezpečnosti nebo CSP?

Ano, existuje [setting](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), který umožňuje během ukládání vynechat hypertextové odkazy s voláním JavaScriptu. To pomáhá splňovat přísné bezpečnostní politiky.
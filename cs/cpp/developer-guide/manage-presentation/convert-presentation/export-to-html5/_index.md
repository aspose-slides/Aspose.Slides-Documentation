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

Tento článek vysvětluje, jak převést prezentace PowerPoint do HTML5 pomocí Aspose.Slides pro C++. Pokrývá základní export, řízení animací tvarů a přechodů snímků a rozvržení komentářů. Také porovnává výstup HTML5 s výstupem založeným na SVG při standardním exportu HTML.

## **Export PowerPoint do HTML5**

Následující příklad načte prezentaci z pracovního adresáře a uloží ji ve formátu HTML5. Používá výchozí nastavení exportu; následující příklad ukazuje, jak explicitně řídit přehrávání animací. Nahraďte vstupní cestu cestou k vaší prezentaci.

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
Vedle HTML dokumentu export vytvoří podpůrné soubory CSS a JavaScript pro stylování snímků, animace, efekty a navigaci. Uchovávejte tyto soubory spolu s HTML dokumentem při přesouvání nebo publikování výstupu. Vygenerovaná stránka také načítá jQuery a Anime.js z veřejných CDN; bez nich navigace snímků a animace nefungují.
{{% /alert %}}

Pro export bez přehrávání animací tvarů nebo přechodů snímků předávejte `false` metodám [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) a [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) v [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Tato nastavení jsou nezávislá, takže můžete povolit jedno a zakázat druhé. Příklad exportuje prezentaci s oběma typy animací vypnutými ve vytvořené stránce.

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

## **Export PowerPoint do HTML**

Standardní export do HTML používá odlišný přístup k vykreslování: obsah snímku je reprezentován jako SVG uvnitř HTML stránky. Následující příklad převádí prezentaci do HTML dokumentu pomocí tohoto renderovacího přístupu.

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

Zjednodušené značkování níže ilustruje strukturu vygenerované stránky. Prvek SVG obsahuje vykreslený obsah snímku; text zástupného řetězce představuje tento obsah a není doslovným výstupem exportu.

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
Export založený na SVG neexponuje tvary PowerPointu jako jednotlivé HTML elementy. Použijte export do HTML5, pokud potřebujete možnosti animace tvarů a přechodů snímků demonstrováné v tomto článku.
{{% /alert %}}

## **Export PowerPoint do HTML5 zobrazení snímků**

Export do HTML5 vytváří stránku pro prohlížení a navigaci snímky prezentace v prohlížeči. Tento příklad předává `true` jak metodě [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/), tak metodě [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/), aby exportované zobrazení snímků mohlo přehrávat efekty ze zdrojové prezentace.

Použijte prezentaci, která již obsahuje animace tvarů a přechody snímků, abyste viděli vliv těchto nastavení. Povolení nepřidá nové efekty k snímkům, které žádné nemají. Po exportu otevřete vygenerovaný HTML5 dokument v prohlížeči se všemi podporujícími soubory.

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

## **Převod prezentace na HTML5 dokument s komentáři**

Můžete zahrnout existující komentáře ke snímkům do výstupu HTML5, aby čtenáři viděli zpětnou vazbu vedle obsahu snímku. Příklad v této sekci předpokládá, že zdrojová prezentace obsahuje komentáře, jak je znázorněno níže. Exportuje tyto komentáře; nevytváří nové.

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Předajte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) metodě [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) třídy [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Zavolejte [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) s hodnotou `CommentsPositions::Right` z výčtu [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/), aby se komentáře umístily vpravo od každého snímku.

Následující příklad exportuje prezentaci do HTML5 s tímto rozvržením komentářů. Prezentace bez komentářů nebude mít žádný text komentáře k zobrazení.

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

![Komentáře ve výstupním HTML5 dokumentu](two_comments_html5.png)

## **Vyloučení JavaScriptových hypertextových odkazů během exportu**

Předpokládejme, že `hyperlinks.pptx` obsahuje propojený text s cílem `javascript:alert('Hello')` a běžný odkaz `https://example.com/`. Pro vyloučení JavaScriptového hypertextového odkazu během exportu zavolejte [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) s hodnotou `true`. Výchozí hodnota je `false`, takže tyto odkazy nejsou filtrovány, pokud možnost neaktivujete.

Následující příklad načte prezentaci z pracovního adresáře a exportuje ji pomocí [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

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

Exportovaný soubor vynechá JavaScriptový hypertextový odkaz a zachová jeho text i běžný HTTPS odkaz. Zdrojová prezentace zůstane beze změny.

Tato možnost filtruje JavaScriptové hypertextové odkazy; neodstraňuje všechny skripty ani jiný aktivní obsah, ani nezaručuje shodu s CSP. Například výstup HTML5 stále obsahuje skripty pro navigaci snímky a animace.

## **Často kladené otázky**

**Mohu řídit, zda se animace objektů a přechody snímků přehrávají v HTML5?**

Ano, export do HTML5 poskytuje samostatné možnosti pro povolení nebo zakázání [animací tvarů](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) a [přechodů snímků](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Jsou komentáře podporovány a kde lze umístit vzhledem k snímku?**

Ano, existující komentáře lze zahrnout do výstupu HTML5 a umístit (například vpravo od snímku) pomocí [nastavení rozvržení](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) pro poznámky a komentáře.

**Mohu přeskočit odkazy, které volají JavaScript z bezpečnostních nebo CSP důvodů?**

Ano, metoda [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) vám umožní při ukládání přeskočit hypertextové odkazy s voláním JavaScriptu. Výchozí hodnota je `false`. Viz [Exclude JavaScript Hyperlinks During Export](/slides/cs/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) pro příklad exportu do HTML5 a rozsah filtru. Toto nastavení neodstraňuje JavaScript, který HTML5 prohlížeč používá pro navigaci a animace.
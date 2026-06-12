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
description: "Exportujte PowerPoint a OpenDocument prezentace do responsivního HTML5 pomocí Aspose.Slides pro C++. Zachovejte formátování, animace a interaktivitu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides převést prezentace PowerPoint do HTML5. Pokrývá základní export do HTML5 bez webových rozšíření či dalších závislostí, stejně jako možnosti řízení animací tvarů a přechodů mezi snímky. Článek také ukazuje standardní proces exportu z PowerPointu do HTML, vysvětluje, jak vygenerovat výstup HTML5 v režimu zobrazení snímků, a demonstruje, jak do exportovaného dokumentu zahrnout komentáře nastavením jejich rozložení.

## **Export PowerPointu do HTML5**

Tento C++ kód ukazuje, jak exportovat prezentaci do HTML5.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 
V tomto případě získáte čisté HTML. 
{{% /alert %}}

Můžete chtít nastavit možnosti pro animace tvarů a přechody mezi snímky tímto způsobem:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Export PowerPointu do HTML**

Tento C++ kód demonstruje standardní proces převodu PowerPointu do HTML:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

V tomto případě je obsah prezentace vykreslen pomocí SVG v podobě jako tato:

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
Když použijete tuto metodu pro export PowerPointu do HTML, kvůli vykreslování SVG nebudete moci aplikovat styly nebo animovat konkrétní prvky. 
{{% /alert %}}

## **Export PowerPointu do HTML5 Slide View**

**Aspose.Slides** umožňuje převést prezentaci PowerPoint do HTML5 dokumentu, ve kterém jsou snímky zobrazeny v režimu náhledu snímků. V tomto případě, když otevřete výsledný HTML5 soubor v prohlížeči, uvidíte prezentaci v režimu náhledu snímků na webové stránce. 

Tento C++ kód demonstruje proces exportu PowerPointu do HTML5 ve zobrazení snímků:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Převod prezentace do HTML5 dokumentu s komentáři**

Komentáře v PowerPointu jsou nástrojem, který umožňuje uživatelům zanechat poznámky nebo zpětnou vazbu na snímcích prezentace. Jsou zvláště užitečné v kolaborativních projektech, kde více lidí může přidávat své návrhy nebo připomínky k určitým prvkům snímků, aniž by měnili hlavní obsah. Každý komentář zobrazuje jméno autora, což usnadňuje sledovat, kdo připomínku zanechal.

Předpokládejme, že máme následující prezentaci PowerPoint uloženou v souboru "sample.pptx".

![Dva komentáře na snímku prezentace](two_comments_pptx.png)

Když převádíte PowerPoint prezentaci do HTML5 dokumentu, můžete snadno určit, zda zahrnout komentáře z prezentace do výstupního dokumentu. K tomu je třeba nastavit parametry zobrazení komentářů v metodě `get_NotesCommentsLayouting` třídy [Html5Options](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/).

Následující ukázka kódu převádí prezentaci do HTML5 dokumentu s komentáři zobrazenými vpravo od snímků.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Dokument „output.html“ je zobrazen na obrázku níže.

![Komentáře ve výstupním HTML5 dokumentu](two_comments_html5.png)

## **Často kladené otázky**

**Mohu ovládat, zda se animace objektů a přechody mezi snímky přehrávají v HTML5?**

Ano, HTML5 nabízí samostatné možnosti pro povolení nebo zakázání [animací tvarů](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/set_animateshapes/) a [přechodů mezi snímky](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Je podpora výstupu komentářů zajištěna a kde mohou být umístěny relativně k snímku?**

Ano, komentáře lze přidat do HTML5 a umístit (například vpravo od snímku) pomocí nastavení rozložení poznámek a komentářů.

**Mohu přeskočit odkazy, které spouštějí JavaScript z bezpečnostních důvodů nebo kvůli CSP?**

Ano, existuje [nastavení](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), které umožňuje při ukládání přeskočit hypertextové odkazy s voláním JavaScriptu. To pomáhá dodržovat přísné bezpečnostní zásady.
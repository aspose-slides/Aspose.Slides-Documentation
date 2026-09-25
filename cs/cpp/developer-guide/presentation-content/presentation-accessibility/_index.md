---
title: Spravovat přístupnost prezentace v C++
linktitle: Přístupnost prezentace
type: docs
weight: 30
url: /cs/cpp/presentation-accessibility/
keywords:
- přístupnost prezentace
- alternativní text
- název alternativního textu
- popis alternativního textu
- označit jako dekorativní
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Automatizujte kontrolu přístupnosti prezentací v souborech PPT, PPTX a ODP pomocí Aspose.Slides pro C++—zlepšete zážitek ze čteček obrazovky a zvýšte soulad."
---
## **Úvod**

Alternativní text pomáhá lidem používajícím asistenční technologie pochopit význam obrázků, grafů a dalších informativních tvarů. Tento článek vysvětluje, jak číst a aktualizovat alternativní textové tituly a popisy pomocí Aspose.Slides pro C++, rozlišovat popisy použitelnosti od názvů tvarů používaných v kódu a kontrolovat, zda je tvar označen jako dekorativní.

Tyto funkce podporují přístupnost prezentace, ale nezaručují ji. Pořadí čtení, kontrast barev, čitelnost textu a další požadavky na přístupnost také vyžadují kontrolu.

## **Správa alternativních textových titulů a popisů**

Používejte alternativní text k vysvětlení významu obrázků, grafů a dalších informativních tvarů lidem, kteří je nemohou vidět. Následující vlastnosti slouží různým účelům:

| Vlastnost nebo obsah | Účel |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_alternativetexttitle/) | Krátký titul pro alternativní popis. |
| [AlternativeText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_alternativetext/) | Významný popis obsahu nebo účelu tvaru v kontextu snímku. |
| [Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_name/) | Název tvaru, který může kód použít k nalezení konkrétního tvaru v prezentaci. |
| Visible text | Obsah zobrazený na snímku, například text tvaru nebo titulek a popisky grafu. Aktualizace alternativního textu tento obsah nemění. |

Když je prezentace znovu použita jako šablona, kód může najít tvar podle jeho [Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_name/) před jeho aktualizací. Tento název slouží jinému účelu než alternativní text, který vysvětluje, co vizuál sděluje čtenáři. Vyhledávání podle názvu umožňuje autorům vylepšovat nebo překládat popisy, aniž by měnili způsob, jakým kód tvar najde. Názvy lze upravovat a nejsou zaručeně jedinečné, takže je třeba zkontrolovat, že název odpovídá požadovanému tvaru; viz [Identify and Find Shapes](/slides/cs/cpp/shape-manipulations/#identify-and-find-shapes).

Následující příklad vyžaduje soubor `input.pptx` s obrázkem vchodových dveří kanceláře jako první tvar na prvním snímku. Obrázek by neměl být označen jako dekorativní. Příklad přečte a vypíše aktuální alternativní textový titul a popis, aktualizuje obě hodnoty a uloží prezentaci jako `output.pptx`. Přizpůsobte text skutečnému obrázku a informacím, které předává.

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

Pouze přidání alternativního textu nezaručuje přístupnost prezentace ani shodu s normami přístupnosti. Zkontrolujte popisy z hlediska přesnosti a relevance a také prověřte pořadí čtení, kontrast barev, čitelnost textu a další požadavky na přístupnost. Informační vizuály by neměly být označeny jako dekorativní; v následující sekci se dozvíte, jak číst [IsDecorative](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_isdecorative/).

## **Označit jako dekorativní**

Označte jako dekorativní čistě ornamentální vizuály, aby je čtečky obrazovky přeskočily, čímž se sníží šum a zachová se pozornost na významný obsah. Použijte jej u pozadí, ozdob a oddělovačů — nikdy u grafů, ikon nebo obrázků, které předávají informace. Aspose.Slides tuto vlajku zpřístupňuje pro detekci a ověření, což umožňuje automatické kontroly přístupnosti a úklid.

![Mark as Decorative](mark_as_decorative.png)

Následující ukázka kódu ukazuje, jak zjistit, zda je tvar označen jako dekorativní.

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

## **Často kladené otázky**

**Co bych měl uvést do alternativního textového titulku a popisu?**

Použijte krátký titul k identifikaci předmětu a popis k vysvětlení informací, které vizuál předává v kontextu snímku. U grafu popište relevantní trend nebo srovnání místo pouhého označení „graf“.

**Mám používat alternativní text k lokalizaci tvarů v šabloně?**

Upřednostněte nalezení tvaru podle jeho [Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_name/) a zkontrolujte, že jde o očekávaný tvar. Alternativní text může být editován nebo přeložen, což může narušit kód hledající přesný popis; viz [Identify and Find Shapes](/slides/cs/cpp/shape-manipulations/).

**Kdy by měl být tvar označen jako dekorativní?**

Použijte dekorativní vlajku pro vizuály, které nepřinášejí žádné informace, například ornamentální ozdoby. Obrázky a grafy, které nesou význam, potřebují odpovídající popis místo označení jako dekorativní.

**Zajišťuje přidání alternativního textu, že je prezentace plně přístupná?**

Ne. Alternativní text řeší jen část přístupnosti. Je také nutné zkontrolovat pořadí čtení, kontrast barev, čitelnost textu a další relevantní požadavky; nastavení těchto vlastností samostatně nezaručuje soulad s normami.
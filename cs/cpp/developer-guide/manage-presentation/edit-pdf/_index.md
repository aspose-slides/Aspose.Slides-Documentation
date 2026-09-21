---
title: Upravit PDF dokumenty v C++
linktitle: Upravit PDF
type: docs
weight: 65
url: /cs/cpp/edit-pdf/
keywords:
- Upravit PDF
- Nahradit text PDF
- PDF na PPTX
- PPTX na PDF
- C++
- Aspose.Slides
description: "Upravte PDF dokumenty v C++ jejich importem do Aspose.Slides, nahrazením textu a uložením upravené prezentace zpět do PDF."
---
## **Přehled**

Aspose.Slides for C++ vám umožňuje upravovat obsah PDF importováním jeho stránek jako snímků, úpravou prezentace a exportem zpět do PDF. Tento článek ukazuje jednoduchou náhradu textu. Prezentace zůstává v paměti, takže ukládání mezilehlého souboru PPTX je volitelné.

## **Nahrazení textu v PDF**

Použijte [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidecollection/addfrompdf/) k importování stránek, [Presentation::ReplaceText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/replacetext/) k aktualizaci textu a [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) k exportu výsledku.

Následující příklad předpokládá, že `input.pdf` obsahuje slovo \"Draft\" jako upravitelný text po importu. Nahrazuje toto slovo slovem \"Final\" a zapíše `edited.pdf`. Vymazání počátečního snímku před importem zabraňuje extra prázdné stránce ve výstupu. Vyhledávání odpovídá celým slovům se stejným velikostí písmen; `nullptr` znamená, že není potřeba žádná zpětná volání výsledku.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

Pro více možností viz [Vyhledávání a nahrazení textu](/slides/cs/cpp/search-and-replace-text/) a [Převod PowerPointu na PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Nahrazení textu funguje na importovaném textu, nikoli na textu uvnitř naskenovaných obrázků. Konverze může ovlivnit rozvržení a formátování, takže zkontrolujte výstup, zejména když je náhradní text delší než původní.
{{% /alert %}}

## **Často kladené otázky**

**Potřebuji uložit soubor PPTX před exportem do PDF?**

Ne. Můžete upravovat a exportovat stejnou prezentaci v paměti. Kopii PPTX uložte pouze, pokud ji chcete dále upravovat v PowerPointu; viz [Uložení prezentací](/slides/cs/cpp/save-presentation/).

**Proč může některý text zůstat nezměněn?**

Příklad odpovídá celému slovu \"Draft\" s přesnou velikostí písmen. Text importovaný jako obrázek nebo rozdělený do samostatných textových rámců nemusí nutně odpovídat vyhledávání. Zkontrolujte importovaný obsah a upravte vyhledávání pro váš dokument.
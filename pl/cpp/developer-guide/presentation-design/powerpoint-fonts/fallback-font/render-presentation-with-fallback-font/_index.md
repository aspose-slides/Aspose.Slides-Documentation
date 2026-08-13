---
title: Renderowanie prezentacji z czcionkami awaryjnymi w C++
linktitle: Renderowanie prezentacji
type: docs
weight: 30
url: /pl/cpp/render-presentation-with-fallback-font/
keywords:
- czcionka awaryjna
- renderowanie PowerPoint
- renderowanie prezentacji
- renderowanie slajdu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Renderowanie prezentacji z czcionkami awaryjnymi w Aspose.Slides dla C++ – zachowaj spójny tekst w PPT, PPTX i ODP dzięki krok po kroku przykładowym kodom C++."
---
## **Przegląd**

Aspose.Slides pozwala renderować prezentacje przy użyciu reguł czcionek awaryjnych. Ten artykuł pokazuje, jak utworzyć kolekcję reguł czcionek awaryjnych, modyfikować jej reguły poprzez usuwanie lub dodawanie czcionek awaryjnych oraz przypisać kolekcję przy użyciu metody `FontsManager::set_FontFallBackRulesCollection`.

Po przypisaniu kolekcji reguł czcionek awaryjnych do `FontsManager` prezentacji, reguły te są stosowane podczas operacji takich jak zapisywanie, renderowanie i konwertowanie prezentacji. Przykład demonstruje, jak używać skonfigurowanych reguł przy renderowaniu miniatury slajdu i zapisywaniu jej jako obrazu PNG.

## **Renderowanie slajdu przy użyciu reguł czcionek awaryjnych**

Poniższy przykład obejmuje następujące kroki:

1. Tworzymy [kolekcję reguł czcionek awaryjnych](/slides/pl/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/remove/) regułę czcionki awaryjnej i [AddFallBackFonts()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) do innej reguły.
3. Przekaż kolekcję reguł do metody [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
4. Za pomocą metody [Presentation::Save()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) możemy zapisać prezentację w tym samym formacie lub w innym. Po ustawieniu kolekcji reguł czcionek awaryjnych w FontsManager, reguły te są stosowane podczas wszelkich operacji na prezentacji: zapisywanie, renderowanie, konwertowanie itp.

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

// Utwórz nową instancję kolekcji reguł
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Utwórz kilka reguł
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Próba usunięcia czcionki awaryjnej "Tahoma" z załadowanych reguł
	fallBackRule->Remove(u"Tahoma");

	// I aktualizacji reguł dla określonego zakresu
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) &&
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Możemy również usunąć istniejące reguły z listy
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
Przeczytaj więcej o tym, jak [konwertować slajdy PowerPoint do PNG w C++](/slides/pl/cpp/convert-powerpoint-to-png/).
{{% /alert %}}
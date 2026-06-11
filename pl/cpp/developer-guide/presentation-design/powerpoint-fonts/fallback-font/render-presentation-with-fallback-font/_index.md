---
title: Renderowanie prezentacji z czcionkami zapasowymi w С++
linktitle: Renderowanie prezentacji
type: docs
weight: 30
url: /pl/cpp/render-presentation-with-fallback-font/
keywords:
- czcionka zapasowa
- renderowanie PowerPoint
- renderowanie prezentacji
- renderowanie slajdu
- PowerPoint
- OpenDocument
- prezentacja
- С++
- Aspose.Slides
description: "Renderowanie prezentacji z czcionkami zapasowymi w Aspose.Slides dla С++ – zachowaj spójny tekst w PPT, PPTX i ODP dzięki krok po kroku przykładowym kodom C++."
---
## **Przegląd**

Aspose.Slides umożliwia renderowanie prezentacji przy użyciu zasad czcionek zapasowych. Ten artykuł pokazuje, jak utworzyć kolekcję zasad czcionek zapasowych, modyfikować jej zasady poprzez usuwanie lub dodawanie czcionek zapasowych oraz przypisać kolekcję za pomocą metody `FontsManager::set_FontFallBackRulesCollection`.

Po przypisaniu kolekcji zasad czcionek zapasowych do `FontsManager` prezentacji, zasady są stosowane podczas operacji, takich jak zapisywanie, renderowanie i konwertowanie prezentacji. Przykład demonstruje, jak używać skonfigurowanych zasad przy renderowaniu miniatury slajdu i zapisywaniu jej jako obrazu PNG.

## **Renderowanie slajdu przy użyciu zasad czcionek zapasowych**

Poniższy przykład zawiera następujące kroki:

1. Tworzymy [kolekcję zasad czcionek zapasowych](/slides/pl/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/remove/) zasadę czcionki zapasowej i [AddFallBackFonts()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) do innej zasady.
1. Przekaż kolekcję zasad do metody [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Za pomocą metody [Presentation::Save()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save()) możemy zapisać prezentację w tym samym formacie lub w innym. Po ustawieniu kolekcji zasad czcionek zapasowych w FontsManager, zasady te są stosowane podczas wszystkich operacji na prezentacji: zapisywanie, renderowanie, konwertowanie itp.

``` cpp
// Utwórz nową instancję kolekcji reguł
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Utwórz kilka reguł
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Próba usunięcia czcionki zapasowej "Tahoma" z załadowanych reguł
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
// Przypisywanie przygotowanej listy reguł do użycia
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Renderowanie miniatury przy użyciu zainicjowanej kolekcji reguł i zapisywanie jako PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
Dowiedz się więcej, jak [konwertować slajdy PowerPoint do PNG w C++](/slides/pl/cpp/convert-powerpoint-to-png/).
{{% /alert %}}
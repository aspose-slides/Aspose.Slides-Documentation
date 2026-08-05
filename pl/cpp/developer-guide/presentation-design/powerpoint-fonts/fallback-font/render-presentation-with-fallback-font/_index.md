---
title: Renderowanie prezentacji z zastępczymi czcionkami w C++
linktitle: Renderowanie prezentacji
type: docs
weight: 30
url: /pl/cpp/render-presentation-with-fallback-font/
keywords:
- zastępcza czcionka
- renderowanie PowerPoint
- renderowanie prezentacji
- renderowanie slajdu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Renderowanie prezentacji z zastępczymi czcionkami w Aspose.Slides dla C++ – zapewnij spójność tekstu w plikach PPT, PPTX i ODP dzięki przykładowemu kodowi C++ krok po kroku."
---
## **Przegląd**

Aspose.Slides umożliwia renderowanie prezentacji przy użyciu reguł zastępczych czcionek. W tym artykule pokazano, jak utworzyć kolekcję reguł zastępczych czcionek, modyfikować jej zasady przez usuwanie lub dodawanie czcionek zastępczych oraz przypisać kolekcję przy użyciu metody `FontsManager::set_FontFallBackRulesCollection`.

Po przypisaniu kolekcji reguł zastępczych czcionek do `FontsManager` prezentacji, reguły są stosowane podczas operacji, takich jak zapisywanie, renderowanie i konwertowanie prezentacji. Przykład demonstruje, jak używać skonfigurowanych reguł przy renderowaniu miniatury slajdu i zapisywaniu jej jako obrazu PNG.

## **Renderowanie slajdu przy użyciu reguł zastępczych czcionek**

Poniższy przykład obejmuje następujące kroki:

1. Tworzymy [kolekcję reguł zastępczych czcionek](/slides/pl/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/remove/) regułę zastępczą czcionki i [AddFallBackFonts()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) dodajemy do innej reguły.
3. Przekazujemy kolekcję reguł do metody [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
4. Za pomocą metody [Presentation::Save()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) możemy zapisać prezentację w tym samym formacie lub w innym. Po ustawieniu kolekcji reguł zastępczych czcionek w `FontsManager`, reguły te są stosowane podczas wszystkich operacji na prezentacji: zapisywanie, renderowanie, konwertowanie itp.

``` cpp
// Utwórz nową instancję kolekcji reguł
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Utwórz kilka reguł
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Próba usunięcia czcionki zastępczej "Tahoma" z załadowanych reguł
	fallBackRule->Remove(u"Tahoma");

	// I aktualizacja reguł dla określonego zakresu
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Możemy także usunąć istniejące reguły z listy
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
Przeczytaj więcej o tym, jak [przekształcić slajdy PowerPoint do PNG w C++](/slides/pl/cpp/convert-powerpoint-to-png/).
{{% /alert %}}
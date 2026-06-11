---
title: Renderowanie prezentacji z czcionkami zastępczymi w .NET
linktitle: Renderowanie prezentacji
type: docs
weight: 30
url: /pl/net/render-presentation-with-fallback-font/
keywords:
- czcionka zastępcza
- renderowanie PowerPoint
- renderowanie prezentacji
- renderowanie slajdu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Renderowanie prezentacji z czcionkami zastępczymi w Aspose.Slides dla .NET – zachowaj spójność tekstu w plikach PPT, PPTX i ODP dzięki szczegółowym przykładom kodu C#."
---
## **Przegląd**

Aspose.Slides umożliwia renderowanie prezentacji przy użyciu reguł zastępczych czcionek. Ten artykuł pokazuje, jak utworzyć kolekcję reguł zastępczych czcionek, modyfikować jej reguły poprzez usuwanie lub dodawanie czcionek zastępczych oraz przypisać kolekcję do właściwości `FontsManager.FontFallBackRulesCollection`.

Po przypisaniu kolekcji reguł zastępczych czcionek do `FontsManager` prezentacji, reguły są stosowane podczas operacji takich jak zapisywanie, renderowanie i konwertowanie prezentacji. Przykład demonstruje, jak używać skonfigurowanych reguł podczas renderowania miniatury slajdu i zapisywania jej jako obrazu PNG.

## **Renderowanie slajdu przy użyciu reguł zastępczych czcionek**

Poniższy przykład zawiera następujące kroki:

1. Tworzymy [kolekcję reguł zastępczych czcionek](/slides/pl/net/create-fallback-fonts-collection/).
2. Usuwamy [Remove()](https://reference.aspose.com/slides/pl/net/aspose.slides/fontfallbackrule/methods/remove) regułę zastępczej czcionki i [AddFallBackFonts()](https://reference.aspose.com/slides/pl/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) do innej reguły.
3. Ustawiamy kolekcję reguł w właściwości [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
4. Za pomocą metody [Presentation.Save()](https://reference.aspose.com/slides/pl/net/aspose.slides.presentation/save/methods/4) możemy zapisać prezentację w tym samym formacie lub w innym. Po ustawieniu kolekcji reguł zastępczych czcionek w FontsManager, reguły te są stosowane podczas wszelkich operacji na prezentacji: zapisywanie, renderowanie, konwertowanie itp.

```c#
// Utwórz nową instancję kolekcji reguł
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// utwórz kilka reguł
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Próba usunięcia czcionki zastępczej "Tahoma" z załadowanych reguł
	fallBackRule.Remove("Tahoma");

	// I aktualizacja reguł dla określonego zakresu
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Możemy również usunąć istniejące reguły z listy
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Przypisanie przygotowanej listy reguł do użycia
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Renderowanie miniatury przy użyciu zainicjowanej kolekcji reguł i zapisywanie do PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
Dowiedz się więcej o [zapisie i konwersji w prezentacji](/slides/pl/net/convert-powerpoint-to-png/).
{{% /alert %}}
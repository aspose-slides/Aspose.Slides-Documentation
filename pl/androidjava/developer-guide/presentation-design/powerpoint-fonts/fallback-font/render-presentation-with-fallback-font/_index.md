---
title: Renderowanie prezentacji z czcionkami awaryjnymi na Androidzie
linktitle: Renderowanie prezentacji
type: docs
weight: 30
url: /pl/androidjava/render-presentation-with-fallback-font/
keywords:
- czcionka awaryjna
- renderowanie PowerPoint
- renderowanie prezentacji
- renderowanie slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Renderowanie prezentacji z czcionkami awaryjnymi w Aspose.Slides dla Android – zapewnij spójność tekstu w PPT, PPTX i ODP przy użyciu krok po kroku przykładów kodu Java."
---
## **Przegląd**

Aspose.Slides umożliwia renderowanie prezentacji przy użyciu zasad czcionek awaryjnych. Ten artykuł pokazuje, jak stworzyć kolekcję zasad czcionek awaryjnych, modyfikować jej zasady poprzez usuwanie lub dodawanie czcionek awaryjnych oraz przypisać kolekcję przy użyciu metody `FontsManager.setFontFallBackRulesCollection`.

Po przypisaniu kolekcji zasad czcionek awaryjnych do `FontsManager` prezentacji, zasady są stosowane podczas operacji takich jak zapisywanie, renderowanie i konwertowanie prezentacji. Przykład pokazuje, jak używać skonfigurowanych zasad przy renderowaniu miniatury slajdu i zapisywaniu jej jako obrazu PNG.

## **Renderowanie slajdu przy użyciu zasad czcionek awaryjnych**

Poniższy przykład zawiera następujące kroki:

1. Tworzymy [kolekcję zasad czcionek awaryjnych](/slides/pl/androidjava/create-fallback-fonts-collection/).
2. [Usuń](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) zasadę czcionki awaryjnej i [addFallBackFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do innej zasady.
3. Ustaw kolekcję zasad przy pomocy metody [getFontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
4. Za pomocą metody [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) możemy zapisać prezentację w tym samym formacie lub w innym. Po ustawieniu kolekcji zasad czcionek awaryjnych w [FontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsManager), zasady te są stosowane podczas wszystkich operacji na prezentacji: zapisywanie, renderowanie, konwertowanie itp.

```java
// Utwórz nową instancję kolekcji reguł
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// utwórz pewną liczbę reguł
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Próba usunięcia czcionki awaryjnej "Tahoma" z załadowanych reguł
    fallBackRule.remove("Tahoma");

    // I aktualizacja reguł dla określonego zakresu
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Możemy też usunąć dowolne istniejące reguły z listy
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Przypisywanie przygotowanej listy reguł do użycia
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Renderowanie miniatury przy użyciu zainicjowanej kolekcji reguł i zapisywanie jako JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Zapisz obraz na dysku w formacie JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Przeczytaj więcej o [Konwertowanie PPT i PPTX do JPG na Androidzie](/slides/pl/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}
---
title: Renderowanie prezentacji z czcionkami zastępczymi w Javie
linktitle: Renderowanie prezentacji
type: docs
weight: 30
url: /pl/java/render-presentation-with-fallback-font/
keywords:
- czcionka zastępcza
- renderowanie PowerPoint
- renderowanie prezentacji
- renderowanie slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Renderowanie prezentacji z czcionkami zastępczymi w Aspose.Slides dla Javy – zachowaj spójność tekstu w formatach PPT, PPTX i ODP dzięki szczegółowym przykładom kodu w Javie."
---
## **Przegląd**

Aspose.Slides umożliwia renderowanie prezentacji przy użyciu zasad zastępczych czcionek. Ten artykuł pokazuje, jak utworzyć kolekcję zasad zastępczych czcionek, modyfikować jej zasady poprzez usuwanie lub dodawanie czcionek zastępczych oraz przypisać kolekcję za pomocą metody `FontsManager.setFontFallBackRulesCollection`.

Po przypisaniu kolekcji zasad zastępczych czcionek do `FontsManager` prezentacji, zasady są stosowane podczas operacji takich jak zapisywanie, renderowanie i konwertowanie prezentacji. Przykład pokazuje, jak używać skonfigurowanych zasad przy renderowaniu miniatury slajdu i zapisywaniu jej jako obrazu JPEG.

## **Renderowanie slajdu przy użyciu zasad zastępczych czcionek**

1. Tworzymy [kolekcję zasad zastępczych czcionek](/slides/pl/java/create-fallback-fonts-collection/).
1. [Usuń](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) zasadę czcionki zastępczej i [addFallBackFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do innej zasady.
1. Ustaw kolekcję zasad w metodzie [getFontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metody.
1. Za pomocą metody [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#save-java.lang.String-int-) możemy zapisać prezentację w tym samym formacie lub w innym. Po ustawieniu kolekcji zasad zastępczych czcionek w [FontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsManager), te zasady są stosowane podczas wszelkich operacji na prezentacji: zapisywanie, renderowanie, konwersja itp.

```java
import com.aspose.slides.*;

// Utwórz nową instancję kolekcji reguł
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Próba usunięcia czcionki zastępczej "Tahoma" z załadowanych reguł
    fallBackRule.remove("Tahoma");

    // i aktualizacja reguł dla określonego zakresu
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Możemy także usunąć dowolne istniejące reguły z listy, pozostawiając przynajmniej jedną regułę do renderowania
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

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

{{% alert color="info" %}} 
Przeczytaj więcej o tym, jak konwertować PPT i PPTX na JPG w Javie[/slides/pl/java/convert-powerpoint-to-jpg/].
{{% /alert %}}
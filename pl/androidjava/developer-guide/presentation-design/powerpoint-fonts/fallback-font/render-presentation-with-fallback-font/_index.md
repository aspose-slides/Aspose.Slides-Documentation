---
title: Renderowanie prezentacji z czcionkami zastępczymi na Androidzie
linktitle: Renderowanie prezentacji
type: docs
weight: 30
url: /pl/androidjava/render-presentation-with-fallback-font/
keywords:
- czcionka zastępcza
- renderowanie PowerPoint
- renderowanie prezentacji
- renderowanie slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Renderowanie prezentacji z czcionkami zastępczymi w Aspose.Slides dla Android – zachowaj spójność tekstu w PPT, PPTX i ODP dzięki przykładowemu kodowi Java krok po kroku."
---
## **Przegląd**

Aspose.Slides umożliwia renderowanie prezentacji z użyciem reguł zastępczych czcionek. Ten artykuł pokazuje, jak utworzyć kolekcję reguł zastępczych czcionek, zmodyfikować jej reguły poprzez usuwanie lub dodawanie czcionek zastępczych oraz przypisać kolekcję za pomocą metody `FontsManager.setFontFallBackRulesCollection`.

Po przypisaniu kolekcji reguł zastępczych czcionek do `FontsManager` prezentacji, reguły są stosowane podczas operacji takich jak zapisywanie, renderowanie i konwertowanie prezentacji. Przykład demonstruje, jak używać skonfigurowanych reguł przy renderowaniu miniatury slajdu i zapisywaniu jej jako obrazu JPEG.

## **Renderowanie slajdu przy użyciu reguł zastępczych czcionek**

Poniższy przykład obejmuje następujące kroki:

1. [tworzymy kolekcję reguł zastępczych czcionek](/slides/pl/androidjava/create-fallback-fonts-collection/).
1. [Usuwamy](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) regułę czcionki zastępczej i [addFallBackFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do innej reguły.
1. Ustawiamy kolekcję reguł w [getFontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metodzie.
1. Za pomocą metody [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) możemy zapisać prezentację w tym samym formacie lub w innym. Po ustawieniu kolekcji reguł zastępczych czcionek w [FontsManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontsManager), reguły te są stosowane podczas dowolnych operacji na prezentacji: zapisywanie, renderowanie, konwertowanie itp.

```java
import com.aspose.slides.*;

// Utwórz nową instancję kolekcji reguł
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //    Próba usunięcia czcionki zastępczej "Tahoma" z załadowanych reguł
    fallBackRule.remove("Tahoma");

    //    I aktualizacja reguł dla określonego zakresu
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//Możemy również usunąć istniejące reguły z listy, pozostawiając co najmniej jedną regułę do renderowania
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //    Przypisywanie przygotowanej listy reguł do użycia
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    //    Renderowanie miniatury przy użyciu zainicjowanej kolekcji reguł i zapisywanie jako JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   //   Zapisz obraz na dysku w formacie JPEG
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
Przeczytaj więcej o [Konwersji PPT i PPTX do JPG na Androidzie](/slides/pl/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}
---
title: Renderowanie prezentacji z fontami zastępczymi w Javie
linktitle: Renderowanie prezentacji
type: docs
weight: 30
url: /pl/java/render-presentation-with-fallback-font/
keywords:
  - font zastępczy
  - renderowanie PowerPoint
  - renderowanie prezentacji
  - renderowanie slajdu
  - PowerPoint
  - OpenDocument
  - prezentacja
  - Java
  - Aspose.Slides
description: "Renderowanie prezentacji z fontami zastępczymi w Aspose.Slides dla Javy – zachowaj spójność tekstu w PPT, PPTX i ODP dzięki przykładowemu kodowi Java krok po kroku."
---
## **Przegląd**

Aspose.Slides umożliwia renderowanie prezentacji przy użyciu reguł fontów zastępczych. Ten artykuł pokazuje, jak utworzyć kolekcję reguł fontów zastępczych, modyfikować jej reguły poprzez usuwanie lub dodawanie fontów zastępczych oraz przypisać kolekcję przy użyciu metody `FontsManager.setFontFallBackRulesCollection`.

Gdy kolekcja reguł fontów zastępczych zostanie przypisana do `FontsManager` prezentacji, reguły są stosowane podczas operacji takich jak zapisywanie, renderowanie i konwertowanie prezentacji. Przykład pokazuje, jak używać skonfigurowanych reguł podczas renderowania miniatury slajdu i zapisywania jej jako obrazu PNG.

## **Renderowanie slajdu przy użyciu reguł fontów zastępczych**

1. [utwórz kolekcję reguł fontów zastępczych](/slides/pl/java/create-fallback-fonts-collection/).
2. [Usuń](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) regułę fontu zastępczego i [addFallBackFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do innej reguły.
3. Ustaw kolekcję reguł przy użyciu [getFontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) metody.
4. Za pomocą metody [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#save-java.lang.String-int-) możemy zapisać prezentację w tym samym formacie lub w innym. Po ustawieniu kolekcji reguł fontów zastępczych w [FontsManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsManager), reguły są stosowane podczas wszelkich operacji na prezentacji: zapisywanie, renderowanie, konwertowanie itp.

```java
// Utwórz nową instancję kolekcji reguł
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// utwórz kilka reguł
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Próba usunięcia fontu zastępczego "Tahoma" z załadowanych reguł
    fallBackRule.remove("Tahoma");

    // I aktualizacja reguł dla określonego zakresu
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Również możemy usunąć istniejące reguły z listy
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Przypisanie przygotowanej listy reguł do użycia
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
Przeczytaj więcej o tym, jak [Konwertować PPT i PPTX do JPG w Javie](/slides/pl/java/convert-powerpoint-to-jpg/).
{{% /alert %}}
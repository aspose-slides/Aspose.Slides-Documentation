---
title: Renderowanie prezentacji z czcionkami zastępczymi w JavaScript
linktitle: Renderowanie prezentacji
type: docs
weight: 30
url: /pl/nodejs-java/render-presentation-with-fallback-font/
keywords:
- czcionka zastępcza
- renderowanie PowerPoint
- renderowanie prezentacji
- renderowanie slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Renderuj prezentacje z czcionkami zastępczymi w Aspose.Slides dla Node.js – zachowaj spójność tekstu w PPT, PPTX i ODP dzięki szczegółowym przykładom kodu JavaScript."
---
## **Przegląd**

Aspose.Slides pozwala na renderowanie prezentacji przy użyciu reguł zastępczych czcionek. Ten artykuł pokazuje, jak utworzyć kolekcję reguł zastępczych czcionek, zmodyfikować jej reguły przez usunięcie lub dodanie czcionek zastępczych oraz przypisać kolekcję przy użyciu metody `FontsManager.setFontFallBackRulesCollection`.

Po przypisaniu kolekcji reguł zastępczych czcionek do `FontsManager` prezentacji, reguły są stosowane podczas operacji takich jak zapisywanie, renderowanie i konwertowanie prezentacji. Przykład demonstruje, jak używać skonfigurowanych reguł przy renderowaniu miniatury slajdu i zapisywaniu jej jako obrazu PNG.

## **Renderowanie slajdu przy użyciu reguł zastępczych czcionek**

Poniższy przykład obejmuje następujące kroki:

1. Tworzymy [kolekcję reguł zastępczych czcionek](/slides/pl/nodejs-java/create-fallback-fonts-collection/).
1. [Remove](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) regułę zastępczej czcionki i [addFallBackFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do innej reguły.
1. Ustawiamy kolekcję reguł w [getFontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) metodzie.
1. Za pomocą metody [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) możemy zapisać prezentację w tym samym formacie lub w innym. Po ustawieniu kolekcji reguł zastępczych czcionek w [FontsManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontsManager), reguły te są stosowane podczas wszelkich operacji na prezentacji: zapisywanie, renderowanie, konwertowanie itp.

```javascript
// Utwórz nową instancję kolekcji reguł
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// utwórz kilka reguł
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Próba usunięcia czcionki zastępczej "Tahoma" z załadowanych reguł
    fallBackRule.remove("Tahoma");
    // I aktualizacja reguł dla określonego zakresu
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Możemy także usunąć istniejące reguły z listy
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Przypisanie przygotowanej listy reguł do użycia
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Renderowanie miniatury przy użyciu zainicjowanej kolekcji reguł i zapisywanie jako JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Zapisz obraz na dysku w formacie JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Więcej informacji o tym, jak konwertować PPT i PPTX do JPG w JavaScript [Konwertować PPT i PPTX do JPG w JavaScript](/slides/pl/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}
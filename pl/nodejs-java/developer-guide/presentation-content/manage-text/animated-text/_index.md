---
title: Animowanie tekstu PowerPoint w JavaScript
linktitle: Animowany tekst
type: docs
weight: 60
url: /pl/nodejs-java/animated-text/
keywords:
- animowany tekst
- animacja tekstu
- animowany akapit
- animacja akapitu
- efekt animacji
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz dynamiczny animowany tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js, z łatwymi do śledzenia, zoptymalizowanymi przykładami kodu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z animowanym tekstem w Aspose.Slides, stosując efekty animacji do pojedynczych akapitów oraz pobierając efekty już przypisane do akapitów w ramce tekstowej. Skupia się na metodach API używanych do dodawania animacji na poziomie akapitu oraz przeglądania istniejących efektów animacji akapitów w prezentacji.

## **Dodawanie efektów animacji do akapitów**

Dodaliśmy metodę [**addEffect()**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) do klas [**Sequence**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Sequence) i [**Sequence**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Sequence). Metoda ta pozwala dodać efekty animacji do pojedynczego akapitu. Poniższy przykładowy kod pokazuje, jak dodać efekt animacji do jednego akapitu:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // wybierz akapit, aby dodać efekt
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // dodaj efekt animacji Fly do wybranego akapitu
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Pobieranie efektów animacji w akapitach**

Możesz chcieć dowiedzieć się, jakie efekty animacji zostały dodane do akapitu — na przykład w jednej sytuacji możesz potrzebować pobrać efekty animacji w akapicie, ponieważ planujesz zastosować te efekty w innym akapicie lub kształcie.  
Aspose.Slides for Node.js via Java umożliwia pobranie wszystkich efektów animacji zastosowanych do akapitów znajdujących się w ramce tekstowej (kształcie). Ten przykładowy kod pokazuje, jak uzyskać efekty animacji w akapicie:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**Jak animacje tekstu różnią się od przejść slajdów i czy można je łączyć?**

Animacje tekstu kontrolują zachowanie obiektu w czasie na slajdzie, podczas gdy [przejścia](/slides/pl/nodejs-java/slide-transition/) kontrolują sposób zmiany slajdów. Są niezależne i mogą być używane razem; kolejność odtwarzania jest sterowana przez oś czasu animacji oraz ustawienia przejść.

**Czy animacje tekstu są zachowywane przy eksporcie do PDF lub obrazów?**

Nie. PDF i obrazy rastrowe są statyczne, więc zobaczysz jedynie jedną, nieruchomą wersję slajdu. Aby zachować ruch, użyj eksportu do [wideo](/slides/pl/nodejs-java/convert-powerpoint-to-video/) lub [HTML](/slides/pl/nodejs-java/export-to-html5/).

**Czy animacje tekstu działają w układach i w szablonie slajdu?**

Efekty zastosowane do obiektów układu/szablonu są dziedziczone przez slajdy, jednak ich synchronizacja i interakcja z animacjami na poziomie slajdu zależą od ostatecznej kolejności na slajdzie.
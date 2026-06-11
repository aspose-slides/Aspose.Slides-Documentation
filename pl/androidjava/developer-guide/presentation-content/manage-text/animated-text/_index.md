---
title: Animuj tekst PowerPoint na Androidzie
linktitle: Animowany tekst
type: docs
weight: 60
url: /pl/androidjava/animated-text/
keywords:
- animowany tekst
- animacja tekstu
- animowany akapit
- animacja akapitu
- efekt animacji
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Utwórz dynamiczny animowany tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida, z łatwymi do śledzenia, zoptymalizowanymi przykładami kodu Java."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z animowanym tekstem w Aspose.Slides, stosując efekty animacji do poszczególnych akapitów oraz pobierając efekty już przypisane do akapitów w ramce tekstowej. Skupia się na metodach API używanych do dodawania animacji na poziomie akapitu oraz przeglądania istniejących efektów animacji akapitów w prezentacji.

## **Dodawanie efektów animacji do akapitów**

Dodaliśmy metodę [**addEffect()**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) do klas [**Sequence**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Sequence) oraz [**ISequence**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISequence). Ta metoda umożliwia dodanie efektów animacji do pojedynczego akapitu. Poniższy przykład kodu pokazuje, jak dodać efekt animacji do jednego akapitu:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // wybierz akapit, aby dodać efekt
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // dodaj efekt animacji Fly do wybranego akapitu
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Pobieranie efektów animacji akapitów**

Możesz chcieć dowiedzieć się, jakie efekty animacji zostały dodane do akapitu — na przykład w jednej sytuacji chcesz pobrać efekty animacji z akapitu, aby zastosować je w innym akapicie lub kształcie.

Aspose.Slides for Android via Java umożliwia pobranie wszystkich efektów animacji zastosowanych do akapitów zawartych w ramce tekstowej (kształcie). Poniższy przykład kodu pokazuje, jak pobrać efekty animacji w akapicie:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**Jak animacje tekstu różnią się od przejść slajdów i czy można je łączyć?**

Animacje tekstu kontrolują zachowanie obiektu w czasie na slajdzie, podczas gdy [transitions](/slides/pl/androidjava/slide-transition/) kontrolują sposób zmiany slajdów. Są niezależne i mogą być używane razem; kolejność odtwarzania jest określana przez oś czasu animacji oraz ustawienia przejścia.

**Czy animacje tekstu są zachowywane podczas eksportu do PDF lub obrazów?**

Nie. PDF i obrazy rastrowe są statyczne, więc zobaczysz jedynie jedną, nieruchomą wersję slajdu. Aby zachować ruch, użyj eksportu do [video](/slides/pl/androidjava/convert-powerpoint-to-video/) lub [HTML](/slides/pl/androidjava/export-to-html5/).

**Czy animacje tekstu działają w układach i wzorcu slajdu?**

Efekty zastosowane do obiektów układu/wzoru są odziedziczone przez slajdy, ale ich synchronizacja i interakcja z animacjami na poziomie slajdu zależą od ostatecznej kolejności na slajdzie.
---
title: Zarządzanie polami zastępczymi w prezentacji w Java
linktitle: Zarządzaj polami zastępczymi
type: docs
weight: 10
url: /pl/java/manage-placeholder/
keywords:
- pole zastępcze
- pole zastępcze tekstu
- pole zastępcze obrazu
- pole zastępcze wykresu
- tekst podpowiedzi
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Bezproblemowo zarządzaj polami zastępczymi w Aspose.Slides dla Java: zamieniaj tekst, dostosowuj podpowiedzi i ustawiaj przezroczystość obrazu w PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia programowe zarządzanie polami zastępczymi prezentacji. Ten artykuł wyjaśnia, jak znajdować pola zastępcze na slajdach i zmieniać ich tekst, ustawiać własny tekst podpowiedzi dla układów pól zastępczych oraz regulować przezroczystość obrazu używanego jako tło pola zastępczego. Zawiera także krótkie FAQ, które wyjaśnia różnicę między podstawowymi polami zastępczymi a lokalnymi kształtami, opisuje, jak zmiany pól zastępczych mogą być stosowane poprzez układy lub wzorce, oraz wskazuje na zarządzanie polami zastępczymi nagłówka i stopki.

## **Zmienianie tekstu w polu zastępczym**
Korzystając z [Aspose.Slides for Java](/slides/pl/java/), możesz znajdować i modyfikować pola zastępcze na slajdach w prezentacjach. Aspose.Slides pozwala na wprowadzanie zmian w tekście pola zastępczego.

**Wymaganie wstępne**: Potrzebujesz prezentacji zawierającej pole zastępcze. Taką prezentację możesz utworzyć w standardowej aplikacji Microsoft PowerPoint.

Oto jak używać Aspose.Slides do zastąpienia tekstu w polu zastępczym w tej prezentacji:

1. Utwórz instancję klasy [`Presentation`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) i przekaż prezentację jako argument.
2. Pobierz odwołanie do slajdu za pośrednictwem jego indeksu.
3. Przejdź przez wszystkie kształty, aby znaleźć pole zastępcze.
4. Rzutuj kształt pola zastępczego na [`AutoShape`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/AutoShape) i zmień tekst przy użyciu [`TextFrame`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrame) powiązanego z [`AutoShape`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/AutoShape).
5. Zapisz zmodyfikowaną prezentację.

Ten kod w języku Java pokazuje, jak zmienić tekst w polu zastępczym:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Iteruje po kształtach, aby znaleźć pole zastępcze
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Zmienia tekst w każdym polu zastępczym
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Zapisuje prezentację na dysku
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustawianie tekstu podpowiedzi w polu zastępczym**
Standardowe i wbudowane układy zawierają teksty podpowiedzi, takie jak ***Click to add a title*** lub ***Click to add a subtitle***. Korzystając z Aspose.Slides, możesz wstawić własne teksty podpowiedzi do układów pól zastępczych.

Ten kod w języku Java pokazuje, jak ustawić tekst podpowiedzi w polu zastępczym:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Iteruje po slajdzie
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint wyświetla "Click to add title"
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Dodaje podtytuł
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustawianie przezroczystości obrazu w polu zastępczym**

Aspose.Slides pozwala ustawić przezroczystość obrazu tła w polu zastępczym tekstowym. Dostosowując przezroczystość obrazu w takim ramce, możesz podkreślić tekst lub obraz (w zależności od kolorów tekstu i obrazu).

Ten kod w języku Java pokazuje, jak ustawić przezroczystość tła obrazu (wewnątrz kształtu):

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Czym jest podstawowe pole zastępcze i jak różni się od lokalnego kształtu na slajdzie?**

Podstawowe pole zastępcze jest oryginalnym kształtem w układzie lub wzorcu, z którego dziedziczy kształt slajdu — typ, pozycja i niektóre formatowania pochodzą z niego. Lokalny kształt jest niezależny; jeśli nie ma podstawowego pola zastępczego, dziedziczenie nie ma zastosowania.

**Jak mogę zaktualizować wszystkie tytuły lub podpisy w całej prezentacji bez iterowania po każdym slajdzie?**

Edytuj odpowiednie pole zastępcze w układzie lub wzorcu. Slajdy oparte na tych układach/wzorcu automatycznie odziedziczą zmianę.

**Jak kontrolować standardowe pola zastępcze nagłówka/stopki — datę i godzinę, numer slajdu oraz tekst stopki?**

Użyj menedżerów HeaderFooter w odpowiednim zasięgu (zwykłe slajdy, układy, wzorzec, notatki/ulotki), aby włączać lub wyłączać te pola zastępcze i ustawiać ich zawartość.
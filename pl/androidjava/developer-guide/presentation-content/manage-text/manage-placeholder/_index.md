---
title: Zarządzaj elementami zastępczymi prezentacji na Androidzie
linktitle: Zarządzaj elementami zastępczymi
type: docs
weight: 10
url: /pl/androidjava/manage-placeholder/
keywords:
- element zastępczy
- element zastępczy tekstu
- element zastępczy obrazu
- element zastępczy wykresu
- tekst podpowiedzi
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Łatwo zarządzaj elementami zastępczymi w Aspose.Slides dla Androida za pomocą Java: zamieniaj tekst, dostosowuj podpowiedzi i ustawiaj przezroczystość obrazu w PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia programowe zarządzanie elementami zastępczymi prezentacji. Ten artykuł wyjaśnia, jak znaleźć elementy zastępcze na slajdach i zmienić ich tekst, ustawić własny tekst podpowiedzi dla układów elementów zastępczych oraz dostosować przezroczystość obrazu używanego jako tło elementu zastępczego. Zawiera również krótkie FAQ, które wyjaśnia różnicę między podstawowymi elementami zastępczymi a lokalnymi kształtami, opisuje, w jaki sposób zmiany elementów zastępczych mogą być zastosowane poprzez układy lub wzorce, oraz wskazuje zarządzanie elementami zastępczymi nagłówka i stopki.

## **Zmienianie tekstu w elemencie zastępczym**
Korzystając z [Aspose.Slides for Android via Java](/slides/pl/androidjava/), możesz znajdować i modyfikować elementy zastępcze na slajdach w prezentacjach. Aspose.Slides umożliwia wprowadzanie zmian w tekście elementu zastępczego.

**Wymaganie wstępne**: potrzebujesz prezentacji zawierającej element zastępczy. Taki plik możesz utworzyć w standardowej aplikacji Microsoft PowerPoint.

Tak używać Aspose.Slides do zastąpienia tekstu w elemencie zastępczym w tej prezentacji:

1. Utwórz instancję klasy [`Presentation`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) i przekaż prezentację jako argument.
2. Uzyskaj odwołanie do slajdu poprzez jego indeks.
3. Przejdź przez kształty, aby znaleźć element zastępczy.
4. Rzutuj kształt elementu zastępczego na [`AutoShape`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/AutoShape) i zmień tekst przy użyciu [`TextFrame`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/TextFrame) powiązanego z [`AutoShape`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/AutoShape).
5. Zapisz zmodyfikowaną prezentację.

Ten kod Java pokazuje, jak zmienić tekst w elemencie zastępczym:

```java
// Instancjonuje klasę Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Iteruje po kształtach, aby znaleźć element zastępczy
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Zmienia tekst w każdym elemencie zastępczym
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Zapisuje prezentację na dysku
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustawianie tekstu podpowiedzi w elemencie zastępczym**
Standardowe i wbudowane układy zawierają teksty podpowiedzi elementów zastępczych, takie jak ***Kliknij, aby dodać tytuł*** lub ***Kliknij, aby dodać podtytuł***. Przy użyciu Aspose.Slides możesz wstawić własne teksty podpowiedzi do układów elementów zastępczych.

Ten kod Java pokazuje, jak ustawić tekst podpowiedzi w elemencie zastępczym:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Iteruje po slajdzie
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint wyświetla "Kliknij, aby dodać tytuł" 
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

## **Ustawianie przezroczystości obrazu w elemencie zastępczym**

Aspose.Slides pozwala ustawić przezroczystość obrazu tła w elemencie zastępczym tekstu. Dostosowując przezroczystość obrazu w takim ramce, możesz podkreślić tekst lub obraz (w zależności od kolorów tekstu i obrazu).

Ten kod Java pokazuje, jak ustawić przezroczystość tła obrazu (wewnątrz kształtu):

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

**Co to jest podstawowy element zastępczy i czym różni się od lokalnego kształtu na slajdzie?**

Podstawowy element zastępczy to oryginalny kształt w układzie lub wzorcu, z którego dziedziczy kształt slajdu – typ, pozycja i niektóre formatowania pochodzą z niego. Lokalne kształty są niezależne; jeśli nie ma podstawowego elementu zastępczego, dziedziczenie nie ma zastosowania.

**Jak mogę zaktualizować wszystkie tytuły lub podpisy w całej prezentacji bez iteracji po każdym slajdzie?**

Edytuj odpowiedni element zastępczy w układzie lub wzorcu. Slajdy oparte na tych układach/wzorcu automatycznie odziedziczą zmianę.

**Jak kontrolować standardowe elementy zastępcze nagłówka/stopki — datę i godzinę, numer slajdu oraz tekst stopki?**

Użyj menedżerów HeaderFooter w odpowiednim zakresie (zwykłe slajdy, układy, wzorzec, notatki/ulotki), aby włączyć lub wyłączyć te elementy zastępcze i ustawić ich zawartość.
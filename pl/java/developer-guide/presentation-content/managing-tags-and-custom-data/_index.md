---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach przy użyciu Java
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/java/managing-tags-and-custom-data/
keywords:
- właściwości dokumentu
- tag
- dane niestandardowe
- dodaj tag
- wartości par
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodawać, odczytywać, aktualizować i usuwać tagi oraz dane niestandardowe w Aspose.Slides dla Java, z przykładami dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides współpracuje z tagami i danymi niestandardowymi w prezentacjach PowerPoint. Krótko opisuje, jak dane są przechowywane w plikach PPTX, zauważa, że dane specyficzne dla prezentacji mogą istnieć jako tagi i niestandardowe części XML, oraz opisuje tagi jako pary klucz‑wartość typu string.

Pokazuje również, jak odczytać wartości tagów oraz jak dodać tagi do prezentacji, pojedynczego slajdu lub kształtu. Dodatkowo artykuł omawia typowe zadania zarządzania tagami, takie jak usuwanie wszystkich tagów, usuwanie tagu po nazwie oraz pobieranie listy nazw tagów.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — elementy z rozszerzeniem .pptx — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Format Office Open XML definiuje strukturę danych zawartych w prezentacjach. 

Przy czym *slide* jest jednym z elementów prezentacji, a *slide part* zawiera zawartość pojedynczego slajdu. Część slajdu może mieć explicite powiązania z wieloma częściami — na przykład User Defined Tags — zdefiniowanymi w ISO/IEC 29500. 

Dane niestandardowe (specyficzne dla prezentacji) lub użytkownika mogą istnieć jako tagi ([ITagCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITagCollection)) oraz CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICustomXmlPartCollection)). 

{{% alert color="primary" %}} 
Tagi są w zasadzie parami klucz‑wartość w postaci ciągów znaków. 
{{% /alert %}} 

## **Pobieranie wartości tagów**

W Slides tag odpowiada metodom [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IDocumentProperties#getKeywords--) i [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Ten przykładowy kod pokazuje, jak uzyskać wartość tagu przy użyciu Aspose.Slides for Java dla [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides umożliwia dodawanie tagów do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwa właściwości niestandardowej — `MyTag` 
- wartość właściwości niestandardowej — `My Tag Value`

Jeśli musisz klasyfikować niektóre prezentacje według określonej reguły lub właściwości, możesz skorzystać z dodawania tagów do tych prezentacji. Na przykład, aby pogrupować wszystkie prezentacje pochodzące z krajów Ameryki Północnej, możesz utworzyć tag „North American” i przypisać odpowiednie kraje (USA, Meksyk, Kanada) jako wartości.

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) przy użyciu Aspose.Slides for Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Tagi można również ustawiać dla [Slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

lub dowolnego pojedynczego [Shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ograniczenia**

Tagi dodane przez kolekcję tagów danych niestandardowych przy użyciu `getCustomData().getTags()` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF podczas eksportu prezentacji do formatu PDF. W konsekwencji niestandardowy identyfikator przypisany jako tag nie może zostać odczytany z oznaczonego PDF‑a.

**Rozwiązanie obejściowe**: można przechowywać niestandardowy identyfikator w **Alt Text** obiektu (np. `shape.setAlternativeText("MyId")`). Po wyeksportowaniu do PDF, Alt Text może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. Kolekcja [tag collection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/#clear--) usuwającą wszystkie pary klucz‑wartość naraz.

**Jak usunąć pojedynczy tag po nazwie bez iteracji po całej kolekcji?**

Użyj operacji [Remove(name)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) na [tag collection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/), aby usunąć tag po jego kluczu.

**Jak pobrać pełną listę nazw tagów w celach analitycznych lub filtrowania?**

Użyj [getNamesOfTags](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/#getNamesOfTags--) na [tag collection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tagcollection/); metoda zwraca tablicę wszystkich nazw tagów.
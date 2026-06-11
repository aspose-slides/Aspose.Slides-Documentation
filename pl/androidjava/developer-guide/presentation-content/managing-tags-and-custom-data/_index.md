---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach na Androidzie
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/androidjava/managing-tags-and-custom-data
keywords:
- właściwości dokumentu
- tag
- dane niestandardowe
- dodaj tag
- wartości par
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dodawaj, odczytuj, aktualizuj i usuwaj tagi oraz dane niestandardowe w Aspose.Slides dla Androida, z przykładami w Javie dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides działa z tagami i danymi niestandardowymi w prezentacjach PowerPoint. Krótko opisuje, jak dane są przechowywane w plikach PPTX, zauważa, że dane specyficzne dla prezentacji mogą istnieć jako tagi i niestandardowe części XML, oraz opisuje tagi jako pary klucz‑wartość w postaci ciągów znaków.

Pokazuje również, jak odczytywać wartości tagów oraz jak dodawać tagi do prezentacji, pojedynczego slajdu lub kształtu. Dodatkowo artykuł omawia typowe zadania związane z zarządzaniem tagami, takie jak usuwanie wszystkich tagów, usuwanie tagu po nazwie i pobieranie listy nazw tagów.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — elementy z rozszerzeniem .pptx — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Format Office Open XML definiuje strukturę danych zawartych w prezentacjach.

Przy slajdzie będącym jednym z elementów prezentacji, część slajdu zawiera zawartość jednego slajdu. Część slajdu może mieć wyraźne powiązania z wieloma częściami — takimi jak User Defined Tags — zdefiniowanymi w ISO/IEC 29500.

Dane niestandardowe (specyficzne dla prezentacji) lub użytkownika mogą istnieć jako tagi ([ITagCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITagCollection)) i CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Tagi są zasadniczo parami klucz‑wartość w postaci ciągów znaków. 

{{% /alert %}} 

## **Pobieranie wartości tagów**

W slajdach tag odpowiada metodom [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) i [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Ten przykładowy kod pokazuje, jak uzyskać wartość tagu przy użyciu Aspose.Slides dla Android w Javie dla [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation):

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

- nazwa własnej właściwości - `MyTag`
- wartość własnej właściwości - `My Tag Value`

Jeśli potrzebujesz klasyfikować niektóre prezentacje według określonej reguły lub własności, możesz skorzystać z dodawania tagów do tych prezentacji. Na przykład, aby pogrupować wszystkie prezentacje z krajów Ameryki Północnej, możesz utworzyć tag „North American” i przypisać odpowiednie kraje (USA, Meksyk, Kanada) jako wartości.

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) przy użyciu Aspose.Slides dla Android w Javie:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Tagi można także ustawić dla [Slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Lub dowolnego pojedynczego [Shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IAutoShape):

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

Tagi dodane poprzez kolekcję tagów danych niestandardowych przy użyciu `getCustomData().getTags()` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF, gdy prezentacja jest eksportowana do PDF. W konsekwencji niestandardowy identyfikator przypisany jako tag nie może zostać odczytany z otagowanego pliku PDF.

**Workaround**: Możesz przechowywać niestandardowy identyfikator w **Alt Text** obiektu (np. `shape.setAlternativeText("MyId")`). Po eksporcie do PDF tekst alternatywny może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. [tag collection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tagcollection/#clear--) usuwającą wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy tag po nazwie bez iterowania po całej kolekcji?**

Użyj operacji [remove(name)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) na [tag collection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tagcollection/) aby usunąć tag po jego kluczu.

**Jak mogę pobrać kompletną listę nazw tagów do analizy lub filtrowania?**

Użyj [getNamesOfTags](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) na [tag collection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tagcollection/); zwraca ona tablicę wszystkich nazw tagów.
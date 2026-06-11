---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach przy użyciu JavaScript
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/nodejs-java/managing-tags-and-custom-data/
keywords:
- właściwości dokumentu
- tag
- dane niestandardowe
- dodaj tag
- pary wartości
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak dodawać, odczytywać, aktualizować i usuwać tagi oraz dane niestandardowe w Aspose.Slides dla Node.js, z przykładami dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides działa z tagami i danymi niestandardowymi w prezentacjach PowerPoint. Krótko opisuje, jak dane są przechowywane w plikach PPTX, zauważa, że dane specyficzne dla prezentacji mogą istnieć jako tagi i niestandardowe części XML, oraz opisuje tagi jako pary klucz‑wartość typu string. Pokazuje także, jak odczytać wartości tagów i jak dodać tagi do prezentacji, pojedynczego slajdu lub kształtu. Dodatkowo artykuł omawia typowe zadania zarządzania tagami, takie jak czyszczenie wszystkich tagów, usuwanie tagu po nazwie oraz pobieranie listy nazw tagów.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — elementy z rozszerzeniem .pptx — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Format Office Open XML definiuje strukturę danych zawartych w prezentacjach.  

Ponieważ *slajd* jest jednym z elementów w prezentacjach, *część slajdu* zawiera treść pojedynczego slajdu. Część slajdu może mieć jawne powiązania z wieloma częściami — takimi jak User Defined Tags — zdefiniowane przez ISO/IEC 29500.  

Dane niestandardowe (specyficzne dla prezentacji) lub użytkownika mogą istnieć jako tagi ([TagCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TagCollection)) oraz CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 
Tagi są zasadniczo parami klucz‑wartość typu string. 
{{% /alert %}} 

## **Pobieranie wartości tagów**

W slajdach tag odpowiada metodom [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) i [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Ten przykładowy kod pokazuje, jak uzyskać wartość tagu przy użyciu Aspose.Slides dla Node.js via Java dla [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides pozwala dodawać tagi do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwa własności niestandardowej – `MyTag`
- wartość własności niestandardowej – `My Tag Value`

Jeśli potrzebujesz klasyfikować niektóre prezentacje według określonej reguły lub własności, możesz skorzystać z dodawania tagów do tych prezentacji. Na przykład, jeśli chcesz pogrupować wszystkie prezentacje pochodzące z krajów Ameryki Północnej, możesz utworzyć tag North American i przypisać jako wartości odpowiednie kraje (USA, Meksyk i Kanada).

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) przy użyciu Aspose.Slides dla Node.js via Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Tagi można również ustawić dla [Slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Slide):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Lub dowolnego pojedynczego [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ograniczenia**

Tagi dodane przez kolekcję tagów danych niestandardowych przy użyciu `getCustomData().getTags()` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF po wyeksportowaniu prezentacji do PDF. W konsekwencji niestandardowy identyfikator przypisany jako tag nie może zostać pobrany z otagowanego PDF.

**Obejście**: Możesz przechowywać niestandardowy identyfikator w **Alt Text** obiektu (np. `shape.setAlternativeText("MyId")`). Po wyeksportowaniu do PDF, Alt Text może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**  

Tak. [tag collection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tagcollection/clear/), która usuwa wszystkie pary klucz‑wartość jednocześnie.  

**Jak usunąć pojedynczy tag po jego nazwie bez iteracji po całej kolekcji?**  

Użyj operacji [remove(name)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tagcollection/), aby usunąć tag po jego kluczu.  

**Jak mogę pobrać pełną listę nazw tagów w celu analizy lub filtrowania?**  

Użyj [getNamesOfTags](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) na [tag collection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tagcollection/); zwraca tablicę wszystkich nazw tagów.
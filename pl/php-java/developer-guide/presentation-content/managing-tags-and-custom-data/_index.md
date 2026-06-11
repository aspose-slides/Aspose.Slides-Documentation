---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach przy użyciu PHP
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/php-java/managing-tags-and-custom-data/
keywords:
- właściwości dokumentu
- znacznik
- dane niestandardowe
- dodaj znacznik
- wartości pary
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak dodawać, odczytywać, aktualizować i usuwać tagi oraz dane niestandardowe w Aspose.Slides dla PHP via Java, z przykładami dla prezentacji PowerPoint i OpenDocument."
---
## **Omówienie**

Ten artykuł wyjaśnia, jak Aspose.Slides działa z tagami i danymi niestandardowymi w prezentacjach PowerPoint. Krótko opisuje, jak dane są przechowywane w plikach PPTX, informuje, że dane specyficzne dla prezentacji mogą istnieć jako tagi i niestandardowe części XML, oraz opisuje tagi jako pary klucz‑wartość w postaci łańcucha znaków.

Pokazuje również, jak odczytywać wartości tagów oraz jak dodawać tagi do prezentacji, pojedynczego slajdu lub kształtu. Dodatkowo artykuł opisuje typowe zadania zarządzania tagami, takie jak czyszczenie wszystkich tagów, usuwanie tagu po nazwie oraz pobieranie listy nazw tagów.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — elementy z rozszerzeniem .pptx — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Format Office Open XML definiuje strukturę danych zawartych w prezentacjach. 

Przy *slajdzie* będącym jednym z elementów prezentacji, *część slajdu* zawiera treść pojedynczego slajdu. Część slajdu może mieć explicite relacje do wielu części — takich jak Definiowane przez użytkownika tagi — określonych w ISO/IEC 29500. 

Dane niestandardowe (specyficzne dla prezentacji) lub użytkownika mogą istnieć jako tagi ([TagCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tagcollection/)) i CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 
Tagi są zasadniczo parami klucz‑wartość w postaci łańcucha znaków. 
{{% /alert %}} 

## **Pobieranie wartości tagów**

W slajdach tag odpowiada metodom [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#getKeywords) i [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#setKeywords). Ten przykładowy kod pokazuje, jak uzyskać wartość tagu przy użyciu Aspose.Slides for PHP via Java dla [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation):

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides umożliwia dodawanie tagów do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwa własnej właściwości — `MyTag`
- wartość własnej właściwości — `My Tag Value`

Jeśli potrzebujesz klasyfikować niektóre prezentacje według określonej reguły lub właściwości, możesz skorzystać z dodawania tagów do tych prezentacji. Na przykład, jeśli chcesz kategoryzować lub zgrupować wszystkie prezentacje z krajów Ameryki Północnej, możesz utworzyć tag Ameryka Północna i przypisać odpowiednie kraje (USA, Meksyk i Kanada) jako wartości. 

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) przy użyciu Aspose.Slides for PHP via Java:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Tagi mogą być również ustawione dla [Slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Lub dowolnego pojedynczego [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ograniczenia**

Tagi dodane za pośrednictwem kolekcji tagów danych niestandardowych przy użyciu `getCustomData()->getTags()` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF podczas eksportu prezentacji do PDF. W konsekwencji, niestandardowy identyfikator przypisany jako tag nie może zostać odczytany z otagowanego PDF.

**Obejście**: Możesz przechowywać niestandardowy identyfikator w **Alt Text** obiektu (np. `$shape->setAlternativeText("MyId")`). Po eksporcie do PDF, Alt Text może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. [Kolekcja tagów](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tagcollection/clear/) , która usuwa wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy tag po nazwie bez iteracji po całej kolekcji?**

Użyj operacji [remove(name)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tagcollection/remove/) na [kolekcji tagów](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tagcollection/), aby usunąć tag po jego kluczu.

**Jak mogę pobrać pełną listę nazw tagów w celu analizy lub filtrowania?**

Użyj [getNamesOfTags](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tagcollection/getnamesoftags/) na [kolekcji tagów](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tagcollection/); zwraca ona tablicę wszystkich nazw tagów.
---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach przy użyciu Pythona
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/python-net/managing-tags-and-custom-data/
keywords:
- właściwości dokumentu
- tag
- dane niestandardowe
- dodaj tag
- pary wartości
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak dodawać, odczytywać, aktualizować i usuwać tagi oraz dane niestandardowe w Aspose.Slides for Python via .NET, z przykładami dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides obsługuje tagi i dane niestandardowe w prezentacjach PowerPoint. Krótko opisuje, jak dane są przechowywane w plikach PPTX, zauważa, że dane specyficzne dla prezentacji mogą istnieć jako tagi i niestandardowe części XML, oraz opisuje tagi jako pary klucz‑wartość typu string. Pokazuje również, jak odczytać wartości tagów oraz jak dodać tagi do prezentacji, pojedynczego slajdu lub kształtu. Dodatkowo artykuł opisuje typowe zadania zarządzania tagami, takie jak czyszczenie wszystkich tagów, usuwanie tagu po nazwie oraz pobieranie listy nazw tagów.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — elementy z rozszerzeniem .pptx — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Format Office Open XML definiuje strukturę danych zawartych w prezentacjach.

Ponieważ *slajd* jest jednym z elementów prezentacji, *część slajdu* zawiera treść jednego slajdu. Część slajdu może mieć jawne powiązania z wieloma częściami — takimi jak Użytkownik definiowane tagi — określone w ISO/IEC 29500.

Dane niestandardowe (specyficzne dla prezentacji) lub użytkownik mogą istnieć jako tagi ([ITagCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/itagcollection/)) oraz CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 
Tagi są zasadniczo parami klucz‑wartość typu string. 
{{% /alert %}} 

## **Pobieranie wartości tagów**

W slajdach tag odpowiada właściwości IDocumentProperties.Keywords. Ten przykładowy kod pokazuje, jak uzyskać wartość tagu przy użyciu Aspose.Slides for Python via .NET dla [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides pozwala na dodawanie tagów do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwa własnej właściwości – `MyTag`
- wartość własnej właściwości – `My Tag Value`

Jeśli potrzebujesz klasyfikować niektóre prezentacje na podstawie konkretnej reguły lub właściwości, możesz skorzystać z dodawania tagów do tych prezentacji. Na przykład, jeśli chcesz pogrupować wszystkie prezentacje z krajów Ameryki Północnej, możesz utworzyć tag „North American” i przypisać odpowiednie kraje (USA, Meksyk i Kanadę) jako wartości.

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) przy użyciu Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Tagi mogą być również ustawiane dla [Slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Lub dowolnego pojedynczego [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Ograniczenia**

Tagi dodane za pośrednictwem kolekcji `custom_data.tags` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF podczas eksportu prezentacji do PDF. W konsekwencji niestandardowy identyfikator przypisany jako tag nie może być pobrany z otagowanego pliku PDF.

**Rozwiązanie obejściowe**: Możesz przechowywać niestandardowy identyfikator w **Alt Text** obiektu (np. `shape.alternative_text = "MyId"`). Po eksporcie do PDF, Alt Text może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. [Kolekcja tagów](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/clear/), która usuwa wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy tag po nazwie bez iteracji po całej kolekcji?**

Użyj operacji [remove(name)](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/), aby usunąć tag po jego kluczu.

**Jak mogę pobrać pełną listę nazw tagów do analizy lub filtrowania?**

Użyj [get_names_of_tags](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/get_names_of_tags/) na [kolekcji tagów](https://reference.aspose.com/slides/pl/python-net/aspose.slides/tagcollection/); zwraca ona tablicę wszystkich nazw tagów.
---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach przy użyciu C++
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/cpp/managing-tags-and-custom-data/
keywords:
- właściwości dokumentu
- znacznik
- dane niestandardowe
- dodaj znacznik
- pary wartości
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak dodawać, odczytywać, aktualizować i usuwać tagi oraz dane niestandardowe w Aspose.Slides dla C++, z przykładami dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides działa z tagami i danymi niestandardowymi w prezentacjach PowerPoint. Krótko opisuje, jak dane są przechowywane w plikach PPTX, zauważa, że dane specyficzne dla prezentacji mogą istnieć jako tagi i niestandardowe części XML, oraz opisuje tagi jako pary klucz‑wartość typu string.

Pokazuje również, jak odczytać wartości tagów oraz jak dodać tagi do prezentacji, pojedynczego slajdu lub kształtu. Ponadto artykuł omawia typowe zadania zarządzania tagami, takie jak czyszczenie wszystkich tagów, usuwanie taga po nazwie oraz pobieranie listy nazw tagów.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — elementy z rozszerzeniem .pptx — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Format Office Open XML definiuje strukturę danych zawartych w prezentacjach. 

Ponieważ *slajd* jest jednym z elementów w prezentacjach, *część slajdu* zawiera zawartość pojedynczego slajdu. Część slajdu może mieć explicite relacje do wielu części — takich jak Użytkownik definiowane tagi — określone w ISO/IEC 29500. 

Dane niestandardowe (specyficzne dla prezentacji) lub użytkownika mogą istnieć jako tagi ([ITagCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itagcollection/)) oraz CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 
Tagi są zasadniczo parami klucz‑wartość typu string. 
{{% /alert %}} 

## **Pobieranie wartości tagów**

W slajdach tag odpowiada właściwości IDocumentProperties.Keywords. Ten przykładowy kod pokazuje, jak pobrać wartość tagu przy użyciu Aspose.Slides for C++ dla [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides umożliwia dodawanie tagów do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwa własnej właściwości – `MyTag`
- wartość własnej właściwości – `My Tag Value`

Jeśli potrzebujesz klasyfikować niektóre prezentacje według określonej reguły lub właściwości, możesz skorzystać z dodawania tagów do tych prezentacji. Na przykład, jeśli chcesz pogrupować wszystkie prezentacje z krajów Ameryki Północnej, możesz utworzyć tag North American i przypisać odpowiednie kraje (USA, Meksyk i Kanadę) jako wartości. 

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) przy użyciu Aspose.Slides for C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Tagi mogą być również ustawione dla [Slide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Lub dowolnego pojedynczego [Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Ograniczenia**

Tagi dodane poprzez kolekcję tagów danych niestandardowych przy użyciu `get_CustomData()->get_Tags()` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF przy eksporcie prezentacji do PDF. W konsekwencji niestandardowy identyfikator przypisany jako tag nie może być pobrany z otagowanego PDF.

**Obejście**: Możesz przechowywać niestandardowy identyfikator w **Alt Text** obiektu (np. `shape->set_AlternativeText(u\"MyId\")`). Po eksporcie do PDF, Alt Text może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu jedną operacją?**

Tak. [Kolekcja tagów](https://reference.aspose.com/slides/pl/cpp/aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/cpp/aspose.slides/tagcollection/clear/), która usuwa wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy tag po jego nazwie bez iteracji po całej kolekcji?**

Użyj operacji [Remove(name)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/tagcollection/), aby usunąć tag po jego kluczu.

**Jak mogę pobrać pełną listę nazw tagów w celu analizy lub filtrowania?**

Użyj [GetNamesOfTags](https://reference.aspose.com/slides/pl/cpp/aspose.slides/tagcollection/getnamesoftags/) na [kolekcji tagów](https://reference.aspose.com/slides/pl/cpp/aspose.slides/tagcollection/); zwraca ona tablicę wszystkich nazw tagów.
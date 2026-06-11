---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach w .NET
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/net/managing-tags-and-custom-data/
keywords:
- właściwości dokumentu
- tag
- dane niestandardowe
- dodaj tag
- pary wartości
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak dodawać, odczytywać, aktualizować i usuwać tagi oraz dane niestandardowe w Aspose.Slides dla .NET, z przykładami dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides obsługuje tagi i dane niestandardowe w prezentacjach PowerPoint. Krótko opisuje, w jaki sposób dane są przechowywane w plikach PPTX, zauważa, że dane specyficzne dla prezentacji mogą istnieć jako tagi i niestandardowe części XML, oraz opisuje tagi jako pary klucz‑wartość w postaci ciągów znaków.

Pokazuje także, jak odczytywać wartości tagów oraz jak dodawać tagi do prezentacji, pojedynczego slajdu lub kształtu. Dodatkowo artykuł omawia typowe zadania zarządzania tagami, takie jak usuwanie wszystkich tagów, usuwanie tagu po nazwie oraz pobieranie listy nazw tagów.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — elementy z rozszerzeniem .pptx — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Format Office Open XML definiuje strukturę danych zawartych w prezentacjach.

*Slide* jest jednym z elementów prezentacji, a *slide part* zawiera zawartość pojedynczego slajdu. *Slide part* może mieć jawne powiązania z wieloma częściami — na przykład z User Defined Tags — zgodnie z ISO/IEC 29500.

Dane niestandardowe (specyficzne dla prezentacji) lub użytkownika mogą istnieć jako tagi ([ITagCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/itagcollection)) i części CustomXml ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpartcollection)).

{{% alert color="primary" %}} 
Tagi są zasadniczo parami klucz‑wartość typu string. 
{{% /alert %}} 

## **Pobieranie wartości tagów**

W Slides tag odpowiada właściwości IDocumentProperties.Keywords. Poniższy przykładowy kod pokazuje, jak uzyskać wartość tagu przy użyciu Aspose.Slides for .NET dla [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides umożliwia dodawanie tagów do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwa własności niestandardowej — `MyTag`
- wartość własności niestandardowej — `My Tag Value`

Jeśli potrzebujesz klasyfikować niektóre prezentacje według określonej reguły lub własności, możesz skorzystać z dodawania tagów do tych prezentacji. Na przykład, jeżeli chcesz pogrupować wszystkie prezentacje z krajów Ameryki Północnej, możesz utworzyć tag „North American” i przypisać odpowiednie kraje (USA, Meksyk, Kanada) jako wartości.

Poniższy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) przy użyciu Aspose.Slides for .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Tagi można również ustawić dla [Slide](https://reference.aspose.com/slides/pl/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Lub dowolnego pojedynczego [Shape](https://reference.aspose.com/slides/pl/net/aspose.slides/shape):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Ograniczenia**

Tagi dodane przy użyciu kolekcji `CustomData.Tags` są przechowywane wyłącznie w pliku PowerPoint. **Nie** są przenoszone do struktury tagów PDF podczas eksportu prezentacji do PDF. W konsekwencji identyfikator niestandardowy przypisany jako tag nie może zostać odczytany z otagowanego pliku PDF.

**Obejście**: możesz przechowywać identyfikator niestandardowy w **Alt Text** obiektu (np. `shape.AlternativeText = "MyId"`). Po eksporcie do PDF tekst alternatywny może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. [tag collection](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/) obsługuje operację [clear](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/clear/), która usuwa wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy tag po nazwie bez iteracji po całej kolekcji?**

Użyj operacji [Remove(name)](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/), aby usunąć tag po jego kluczu.

**Jak mogę pobrać pełną listę nazw tagów w celu analizy lub filtrowania?**

Użyj [GetNamesOfTags](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/getnamesoftags/) na [tag collection](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/); zwraca ona tablicę wszystkich nazw tagów.
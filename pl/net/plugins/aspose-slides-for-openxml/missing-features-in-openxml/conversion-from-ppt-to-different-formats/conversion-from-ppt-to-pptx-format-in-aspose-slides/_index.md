---
title: Konwersja formatu PPT do PPTX w Aspose.Slides
type: docs
weight: 10
url: /pl/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** for .NET umożliwia programistom dostęp do pliku PPT za pomocą instancji klasy Presentation i konwertowanie go do odpowiedniego formatu PPTX. Obecnie obsługuje częściową konwersję PPT do PPTX. Po więcej informacji o obsługiwanych i nieobsługiwanych funkcjach konwersji PPT do PPTX, przejdź do tego linku dokumentacji.

**Aspose.Slides** for .NET oferuje klasę Presentation, która reprezentuje plik prezentacji PPTX. Klasa Presentation może teraz również uzyskać dostęp do PPT poprzez Presentation, gdy obiekt jest tworzony.

``` csharp

 //Utwórz obiekt Presentation, który reprezentuje plik PPTX

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Zapisywanie prezentacji PPTX w formacie PPTX

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Pobierz przykładowy kod**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)
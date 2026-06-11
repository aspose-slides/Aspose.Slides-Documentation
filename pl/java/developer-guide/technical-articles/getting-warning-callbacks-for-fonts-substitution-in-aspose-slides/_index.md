---
title: Uzyskaj wywołania zwrotne ostrzeżeń dla podstawiania czcionek
type: docs
weight: 90
url: /pl/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- wywołanie zwrotne ostrzeżenia
- podstawianie czcionek
- proces renderowania
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak uzyskać wywołania zwrotne ostrzeżeń dla podstawiania czcionek w Aspose.Slides dla Javy i dokładnie wyświetlać prezentacje PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides for Java umożliwia odbieranie wywołań zwrotnych ostrzeżeń dotyczących podstawiania czcionek, gdy wymagana czcionka nie jest dostępna na komputerze podczas renderowania. Te wywołania zwrotne pomagają diagnozować problemy z brakującymi lub niedostępnymi czcionkami.

## **Włączenie wywołań zwrotnych ostrzeżeń**

Aspose.Slides for Java udostępnia proste interfejsy API do odbierania wywołań zwrotnych ostrzeżeń podczas renderowania slajdów prezentacji. Postępuj zgodnie z poniższymi krokami, aby skonfigurować wywołania zwrotne ostrzeżeń:

1. Utwórz własną klasę wywołania zwrotnego, która implementuje interfejs [IWarningCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iwarningcallback/) aby obsługiwać ostrzeżenia.
1. Ustaw wywołanie zwrotne ostrzeżenia, używając klas opcji, takich jak [RenderingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmloptions/) i innych.
1. Załaduj prezentację, która używa czcionki niedostępnej na docelowym komputerze.
1. Wygeneruj miniaturę slajdu lub wyeksportuj prezentację, aby zobaczyć efekt.

**Niestandardowa klasa wywołania zwrotnego ostrzeżenia:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// Przykładowe wyjście:
//
// Czcionka zostanie podstawiona z XYZ na {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Wygeneruj miniaturę slajdu:**

```java
// Ustaw wywołanie zwrotne ostrzeżenia, aby obsłużyć ostrzeżenia związane z czcionkami podczas renderowania slajdów.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// Załaduj prezentację z określonej ścieżki pliku.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Wygeneruj miniaturę obrazu dla każdego slajdu w prezentacji.
    for (ISlide slide : presentation.getSlides()) {
        // Pobierz miniaturę slajdu przy użyciu określonych opcji renderowania.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**Eksportuj do formatu PDF:**

```java
// Ustaw wywołanie zwrotne ostrzeżenia, aby obsłużyć ostrzeżenia związane z czcionkami podczas eksportu PDF.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// Załaduj prezentację z określonej ścieżki pliku.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Wyeksportuj prezentację jako PDF.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**Eksportuj do formatu HTML:**

```java
// Ustaw wywołanie zwrotne ostrzeżenia, aby obsłużyć ostrzeżenia związane z czcionkami podczas eksportu HTML.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// Załaduj prezentację z określonej ścieżki pliku.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Wyeksportuj prezentację w formacie HTML.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```
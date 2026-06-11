---
title: Eksportuj prezentacje do XAML w JavaScript
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/nodejs-java/export-to-xaml/
keywords:
- eksportuj PowerPoint
- eksportuj OpenDocument
- eksportuj prezentację
- konwertuj PowerPoint
- konwertuj OpenDocument
- konwertuj prezentację
- PowerPoint do XAML
- OpenDocument do XAML
- prezentacja do XAML
- PPT do XAML
- PPTX do XAML
- ODP do XAML
- zapisz PPT jako XAML
- zapisz PPTX jako XAML
- zapisz ODP jako XAML
- eksportuj PPT do XAML
- eksportuj PPTX do XAML
- eksportuj ODP do XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML w JavaScript przy użyciu Aspose.Slides dla Node.js — szybkie, wolne od Office rozwiązanie zachowujące układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak eksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótkie wprowadzenie do XAML, pokazuje, jak zapisać prezentację w formacie XAML z ustawieniami domyślnymi oraz demonstruje, jak dostosować eksport za pomocą [XamlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/), w tym eksportowanie ukrytych slajdów. Artykuł odpowiada również na kilka typowych pytań dotyczących czcionek zapasowych, kompatybilności stosu XAML oraz zachowania przy eksporcie ukrytych slajdów.

## **O XAML**

XAML jest opisowym językiem programowania, który umożliwia tworzenie lub pisanie klas użytkownika dla aplikacji, szczególnie tych wykorzystujących WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) oraz Xamarin Forms.

XAML, będący językiem opartym na XML, jest wariantem Microsoftu służącym do opisywania interfejsu graficznego (GUI). Najczęściej używasz projektanta do pracy z plikami XAML, ale nadal możesz pisać i edytować swój interfejs.

## **Eksportowanie prezentacji do XAML z ustawieniami domyślnymi**

Ten kod JavaScript pokazuje, jak wyeksportować prezentację do XAML przy użyciu ustawień domyślnych:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Możesz wybrać opcje z klasy [XamlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/XamlOptions), które kontrolują proces eksportu i określają, w jaki sposób Aspose.Slides eksportuje Twoją prezentację do XAML.

Na przykład, jeśli chcesz, aby Aspose.Slides dodał ukryte slajdy z prezentacji podczas eksportu do XAML, możesz ustawić metodę [setExportHiddenSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) na true. Zobacz ten przykładowy kod JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jak mogę zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na komputerze?**

Użyj [setDefaultRegularFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) w [XamlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/) — jest używana jako czcionka zapasowa, gdy oryginalna jest niedostępna. Pomaga to uniknąć nieoczekiwanych podstawień.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy można go używać także w innych stosach XAML?**

XAML jest ogólnym językiem znaczników interfejsu UI używanym w WPF, UWP i Xamarin.Forms. Eksport ma na celu kompatybilność ze stosami Microsoft XAML; dokładne zachowanie i wsparcie dla konkretnych konstrukcji zależą od docelowej platformy. Przetestuj znacznik w swoim środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**

Domyślnie ukryte slajdy nie są uwzględniane. Możesz kontrolować to zachowanie za pomocą [setExportHiddenSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) w [XamlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xamloptions/) — pozostaw tę opcję wyłączoną, jeśli nie potrzebujesz ich eksportować.
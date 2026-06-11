---
title: Eksportowanie prezentacji do XAML w PHP
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/php-java/export-to-xaml/
keywords:
- eksport PowerPoint
- eksport OpenDocument
- eksport prezentacji
- konwersja PowerPoint
- konwersja OpenDocument
- konwersja prezentacji
- PowerPoint do XAML
- OpenDocument do XAML
- prezentacja do XAML
- PPT do XAML
- PPTX do XAML
- ODP do XAML
- zapisz PPT jako XAML
- zapisz PPTX jako XAML
- zapisz ODP jako XAML
- eksport PPT do XAML
- eksport PPTX do XAML
- eksport ODP do XAML
- PHP
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML przy użyciu Aspose.Slides dla PHP poprzez Java — szybkie, wolne od Office rozwiązanie, które zachowuje układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak wyeksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótki wstęp do XAML, pokazuje, jak zapisać prezentację w formacie XAML z ustawieniami domyślnymi oraz demonstruje, jak dostosować eksport za pomocą [XamlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/), w tym eksport ukrytych slajdów. Artykuł zawiera także odpowiedzi na kilka często zadawanych pytań dotyczących czcionek zastępczych, zgodności stosu XAML oraz zachowania eksportu ukrytych slajdów.

## **O XAML**

XAML jest językiem programowania opisowym, który umożliwia tworzenie lub pisanie interfejsów użytkownika dla aplikacji, zwłaszcza tych korzystających z WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) oraz Xamarin Forms.  
XAML, będący językiem opartym na XML, jest wariantem Microsoftu służącym do opisywania interfejsu graficznego (GUI). Najczęściej używasz projektanta do pracy z plikami XAML, ale wciąż możesz pisać i edytować swój interfejs.

## **Eksportowanie prezentacji do XAML z opcjami domyślnymi**

Ten kod PHP pokazuje, jak wyeksportować prezentację do XAML z ustawieniami domyślnymi:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Możesz wybrać opcje z klasy [XamlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/), które kontrolują proces eksportu i określają, w jaki sposób Aspose.Slides eksportuje twoją prezentację do XAML.  

Na przykład, jeśli chcesz, aby Aspose.Slides dodało ukryte slajdy z prezentacji podczas eksportu do XAML, możesz użyć metody [setExportHiddenSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/setexporthiddenslides/) z wartością `true`. Zobacz poniższy przykładowy kod PHP:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jak mogę zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na maszynie?**  
Ustaw [domyślną czcionkę regularną](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) w [XamlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/) — jest ona używana jako czcionka zastępcza, gdy brak jest oryginalnej. Pomaga to uniknąć nieoczekiwanych zamian.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany również w innych stosach XAML?**  
XAML jest ogólnym językiem znakowania interfejsu UI używanym w WPF, UWP i Xamarin.Forms. Eksport ma na celu zgodność ze stosami Microsoft XAML; dokładne zachowanie i wsparcie dla konkretnych konstrukcji zależą od docelowej platformy. Przetestuj znacznik w swoim środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**  
Domyślnie ukryte slajdy nie są dołączane. Możesz kontrolować to zachowanie za pomocą [setExportHiddenSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/setexporthiddenslides/) w [XamlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xamloptions/) — pozostaw je wyłączone, jeśli nie potrzebujesz ich eksportować.
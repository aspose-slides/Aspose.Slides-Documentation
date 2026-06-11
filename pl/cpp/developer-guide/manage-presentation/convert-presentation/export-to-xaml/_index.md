---
title: Eksportowanie prezentacji do XAML w C++
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/cpp/export-to-xaml/
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
- eksportuj PPT do XAML
- eksportuj PPTX do XAML
- eksportuj ODP do XAML
- C++
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML w C++ przy użyciu Aspose.Slides—szybkie, wolne od Office rozwiązanie, które zachowuje układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak eksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótki wstęp do XAML, pokazuje, jak zapisać prezentację do XAML z ustawieniami domyślnymi oraz demonstruje, jak dostosować eksport za pomocą [XamlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/), w tym eksport ukrytych slajdów. Artykuł odpowiada również na kilka typowych pytań związanych z czcionkami zastępczymi, kompatybilnością stosu XAML oraz zachowaniem eksportu ukrytych slajdów.

## **O XAML**

XAML jest opisowym językiem programowania, który pozwala tworzyć lub pisać interfejsy użytkownika dla aplikacji, szczególnie tych wykorzystujących WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) oraz Xamarin Forms.  

XAML, będący językiem opartym na XML, jest wariantem Microsoftu służącym do opisywania interfejsu graficznego. Najczęściej korzystasz z projektanta, aby pracować nad plikami XAML, ale nadal możesz pisać i edytować swój interfejs GUI. 

## **Eksportowanie prezentacji do XAML z ustawieniami domyślnymi**

Ten kod C++ pokazuje, jak wyeksportować prezentację do XAML z ustawieniami domyślnymi:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **Eksportowanie prezentacji do XAML z niestandardowymi opcjami**

Możesz wybrać opcje z interfejsu [IXamlOptions](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.xaml.i_xaml_options), które kontrolują proces eksportu i określają, w jaki sposób Aspose.Slides eksportuje Twoją prezentację do XAML. 

Na przykład, jeśli chcesz, aby Aspose.Slides dodał ukryte slajdy z prezentacji podczas eksportu do XAML, możesz przekazać wartość true do metody [set_ExportHiddenSlides()](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Zobacz ten przykładowy kod C++: 

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **FAQ**

**Jak mogę zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na komputerze?**

Użyj [set_DefaultRegularFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) w [XamlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/) — jest ona używana jako czcionka zastępcza, gdy oryginalna jest nieobecna. Pomaga to uniknąć nieoczekiwanych zamian.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany także w innych stosach XAML?**

XAML jest ogólnym językiem znaczników interfejsu UI używanym w WPF, UWP i Xamarin.Forms. Eksport jest skierowany na kompatybilność z zestawami Microsoft XAML; dokładne zachowanie i obsługa konkretnych konstrukcji zależą od platformy docelowej. Przetestuj znacznik w swoim środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**

Domyślnie ukryte slajdy nie są uwzględniane. Możesz kontrolować to zachowanie za pomocą [set_ExportHiddenSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) w [XamlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export.xaml/xamloptions/) — pozostaw je wyłączone, jeśli nie musisz ich exportować.
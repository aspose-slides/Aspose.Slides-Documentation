---
title: Eksportowanie prezentacji do XAML w Pythonie
linktitle: Eksport do XAML
type: docs
weight: 30
url: /pl/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML w Pythonie przy użyciu Aspose.Slides — szybkie, wolne od Office rozwiązanie, które zachowuje układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak eksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótkie wprowadzenie do XAML, pokazuje, jak zapisać prezentację w formacie XAML z ustawieniami domyślnymi oraz demonstruje, jak dostosować eksport przy użyciu [XamlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/), w tym eksportowanie ukrytych slajdów. Artykuł odpowiada także na kilka typowych pytań związanych z czcionkami zapasowymi, kompatybilnością stosu XAML oraz zachowaniem przy eksporcie ukrytych slajdów.

## **O XAML**

XAML jest opisowym językiem programowania, który umożliwia tworzenie lub pisanie interfejsów użytkownika dla aplikacji, szczególnie tych wykorzystujących WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) oraz Xamarin Forms.  
XAML, będący językiem opartym na XML, jest wariantem Microsoftu służącym do opisywania interfejsu graficznego. Najczęściej będziesz używać projektanta do pracy z plikami XAML, ale wciąż możesz pisać i edytować swój interfejs graficzny.

## **Eksportowanie prezentacji do XAML z opcjami domyślnymi**

Ten kod w Pythonie pokazuje, jak wyeksportować prezentację do XAML z ustawieniami domyślnymi:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Możesz wybrać opcje z klasy [XamlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/), które kontrolują proces eksportu i określają, w jaki sposób Aspose.Slides eksportuje Twoją prezentację do XAML.  

Na przykład, jeśli chcesz, aby Aspose.Slides dodał ukryte slajdy z Twojej prezentacji podczas eksportu do XAML, możesz ustawić właściwość [export_hidden_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) na `True`. Zobacz ten przykładowy kod w Pythonie:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **FAQ**

**Jak mogę zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na komputerze?**

Ustaw [default_regular_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) w [XamlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/) — jest używany jako czcionka zapasowa, gdy oryginalna jest niedostępna. Pomaga to uniknąć nieoczekiwanych zamian.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany także w innych stosach XAML?**

XAML jest ogólnym językiem znaczników UI używanym w WPF, UWP oraz Xamarin.Forms. Eksport ma na celu zgodność ze stosami XAML firmy Microsoft; dokładne zachowanie i wsparcie dla konkretnych konstrukcji zależą od platformy docelowej. Przetestuj znacznik w swoim środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**

Domyślnie ukryte slajdy nie są dołączane. Możesz kontrolować to zachowanie za pomocą [export_hidden_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) w [XamlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/) — pozostaw je wyłączone, jeśli nie musisz ich eksportować.
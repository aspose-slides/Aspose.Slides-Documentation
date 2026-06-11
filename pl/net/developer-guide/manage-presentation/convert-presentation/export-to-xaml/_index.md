---
title: Eksportowanie prezentacji do XAML w .NET
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/net/export-to-xaml/
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
- .NET
- C#
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML w .NET przy użyciu Aspose.Slides — szybkie rozwiązanie bez potrzeby Office, które zachowuje układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak wyeksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótkie wprowadzenie do XAML, pokazuje, jak zapisać prezentację w formacie XAML przy domyślnych ustawieniach oraz demonstruje, jak dostosować eksport przy użyciu [XamlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/), w tym eksportowanie ukrytych slajdów. Artykuł odpowiada również na kilka często zadawanych pytań dotyczących czcionek zapasowych, kompatybilności stosu XAML oraz zachowania przy eksporcie ukrytych slajdów.

## **O XAML**

XAML jest opisowym językiem programowania, który umożliwia tworzenie lub pisanie interfejsów użytkownika dla aplikacji, szczególnie tych wykorzystujących WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) oraz Xamarin Forms.  
XAML, będący językiem opartym na XML, jest wariantem Microsoftu służącym do opisywania interfejsu graficznego (GUI). Najczęściej korzystasz z projektanta, aby pracować nad plikami XAML, ale możesz także samodzielnie pisać i edytować swój interfejs.

## **Eksportowanie prezentacji do XAML z domyślnymi opcjami**

Ten kod C# pokazuje, jak wyeksportować prezentację do XAML przy użyciu domyślnych ustawień:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **Eksportowanie prezentacji do XAML z niestandardowymi opcjami**

Możesz wybrać opcje z interfejsu [IXamlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/ixamloptions), które kontrolują proces eksportu i określają, w jaki sposób Aspose.Slides eksportuje Twoją prezentację do XAML.  

Na przykład, jeśli chcesz, aby Aspose.Slides dodał ukryte slajdy z prezentacji podczas eksportu do XAML, możesz ustawić właściwość [ExportHiddenSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) na wartość true. Zobacz poniższy przykładowy kod C#:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **FAQ**

**Jak mogę zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na komputerze?**  
Ustaw [DefaultRegularFont](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveoptions/defaultregularfont/) w [XamlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/) — jest używany jako czcionka zapasowa, gdy oryginalna jest nieobecna. Pomaga to uniknąć nieoczekiwanych zamian.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany również w innych stosach XAML?**  
XAML jest ogólnym językiem znaczników interfejsu UI używanym w WPF, UWP i Xamarin.Forms. Eksport ma na celu zapewnienie kompatybilności ze stosami Microsoft XAML; dokładne zachowanie i wsparcie dla konkretnych konstrukcji zależą od docelowej platformy. Przetestuj znacznik w swoim środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**  
Domyślnie ukryte slajdy nie są włączane. Możesz kontrolować to zachowanie za pomocą [ExportHiddenSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) w [XamlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export.xaml/xamloptions/) — pozostaw je wyłączone, jeśli nie potrzebujesz ich eksportować.
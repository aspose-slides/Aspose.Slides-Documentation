---
title: Eksportowanie prezentacji do XAML w Javie
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML w Javie przy użyciu Aspose.Slides — szybkie rozwiązanie niezależne od Office, które zachowuje układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak eksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótkie wprowadzenie do XAML, pokazuje, jak zapisać prezentację jako XAML z ustawieniami domyślnymi oraz demonstruje, jak dostosować eksport za pomocą [XamlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/), w tym eksportowanie ukrytych slajdów. Artykuł odpowiada również na kilka typowych pytań dotyczących czcionek zapasowych, kompatybilności stosu XAML oraz zachowania przy eksporcie ukrytych slajdów.

## **O XAML**

XAML jest opisowym językiem programowania, który pozwala tworzyć lub pisać interfejsy użytkownika dla aplikacji, szczególnie tych wykorzystujących WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) oraz Xamarin Forms.  
XAML, będący językiem opartym na XML, jest wariantem Microsoftu służącym do opisywania interfejsu graficznego. Najczęściej korzystasz z projektanta, aby pracować nad plikami XAML, ale możesz także samodzielnie pisać i edytować interfejs.

## **Eksportowanie prezentacji do XAML z ustawieniami domyślnymi**

Ten kod Java pokazuje, jak wyeksportować prezentację do XAML z ustawieniami domyślnymi:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Możesz wybierać opcje z interfejsu [IXamlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IXamlOptions), które kontrolują proces eksportu i określają, w jaki sposób Aspose.Slides eksportuje Twoją prezentację do XAML.  

Na przykład, jeśli chcesz, aby Aspose.Slides dodawał ukryte slajdy z prezentacji podczas eksportu do XAML, możesz ustawić właściwość [ExportHiddenSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) na true. Zobacz ten przykładowy kod Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jak mogę zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na komputerze?**

Ustaw [domyślną czcionkę regularną](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) w [XamlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/) — jest używana jako czcionka zapasowa, gdy oryginalna jest nieobecna. Pomaga to uniknąć nieoczekiwanych zamian.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany także w innych stosach XAML?**

XAML jest ogólnym językiem znaczników UI używanym w WPF, UWP i Xamarin.Forms. Eksport ma na celu kompatybilność ze stakcami Microsoft XAML; dokładne zachowanie i wsparcie konkretnych konstrukcji zależą od platformy docelowej. Przetestuj znacznik w swoim środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**

Domyślnie ukryte slajdy nie są uwzględniane. Możesz kontrolować to zachowanie za pomocą [setExportHiddenSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) w [XamlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xamloptions/) — pozostaw je wyłączone, jeśli nie potrzebujesz ich eksportować.
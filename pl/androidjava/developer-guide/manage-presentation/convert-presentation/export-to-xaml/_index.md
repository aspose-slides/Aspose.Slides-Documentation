---
title: Eksportowanie prezentacji do XAML na Androidzie
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML w Javie przy użyciu Aspose.Slides dla Androida — szybkie, niezależne od Office rozwiązanie, które zachowuje układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak eksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótkie wprowadzenie do XAML, pokazuje, jak zapisać prezentację jako XAML z ustawieniami domyślnymi oraz demonstruje, jak dostosować eksport przy użyciu [XamlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/), w tym eksportowanie ukrytych slajdów. Artykuł odpowiada również na kilka typowych pytań dotyczących czcionek zapasowych, kompatybilności stosów XAML oraz zachowania przy eksporcie ukrytych slajdów.

## **O XAML**

XAML jest językiem programowania opisowym, który pozwala tworzyć lub pisać interfejsy użytkownika dla aplikacji, szczególnie tych wykorzystujących WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) oraz Xamarin Forms.  

XAML, będący językiem opartym na XML, jest wariantem Microsoftu służącym do opisywania interfejsu graficznego (GUI). Najczęściej używasz projektanta do pracy nad plikami XAML, ale nadal możesz pisać i edytować swój interfejs.

## **Eksportowanie prezentacji do XAML z opcjami domyślnymi**

Ten kod w języku Java pokazuje, jak wyeksportować prezentację do XAML z ustawieniami domyślnymi:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Masz możliwość wyboru opcji z interfejsu [IXamlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IXamlOptions) które sterują procesem eksportu i określają, jak Aspose.Slides eksportuje Twoją prezentację do XAML.  

Na przykład, jeśli chcesz, aby Aspose.Slides dodało ukryte slajdy z Twojej prezentacji podczas eksportu do XAML, możesz ustawić właściwość [ExportHiddenSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) na true. Zobacz przykład kodu w Javie:

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

Ustaw [domyślną czcionkę regularną](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) w [XamlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/) — jest ona używana jako czcionka zapasowa, gdy oryginalna jest nieobecna. Pomaga to uniknąć nieoczekiwanych zamian.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany również w innych stosach XAML?**  

XAML jest ogólnym językiem znaczników UI używanym w WPF, UWP i Xamarin.Forms. Eksport ma na celu zapewnienie zgodności z zestawami Microsoft XAML; dokładne zachowanie i wsparcie dla konkretnych konstrukcji zależą od docelowej platformy. Przetestuj znacznik w swoim środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**  

Domyślnie ukryte slajdy nie są uwzględniane. Możesz kontrolować to zachowanie za pomocą [setExportHiddenSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) w [XamlOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xamloptions/) — pozostaw je wyłączone, jeśli nie potrzebujesz ich eksportować.
---
title: "Jak wyodrębnić tekst z PPT, PPTX i ODP przy użyciu Aspose.Slides"
linktitle: "Slajdy"
type: docs
weight: 30
url: /pl/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- platformy chmurowe
- integracja chmurowa
- wyodrębnianie tekstu
- wyodrębniać tekst
- PPT
- PPTX
- ODP
- pliki prezentacji
- wieloplatformowe
- niezależne od Office
- notatki i komentarze
- indeksowanie korporacyjne
- wzbogacanie danych
- .NET
- Aspose.Slides
description: "Wyodrębnia tekst z prezentacji na popularnych platformach chmurowych przy użyciu interfejsów Aspose.Slides API, automatyzując wyszukiwanie, analizę i eksport dla PPT, PPTX i ODP."
---
## **Wprowadzenie**

Aspose.Slides udostępnia **potężne, wysokopoziomowe API** do wyodrębniania tekstu z plików prezentacji, w tym **PPT, PPTX i ODP**. W przeciwieństwie do Open XML SDK — które obsługuje jedynie PPTX i wymaga skomplikowanego parsowania XML — Aspose.Slides upraszcza wyodrębnianie tekstu, pozwalając skupić się na integracji uzyskanego kontentu w Twoich procesach.

## **Szybkie wyodrębnianie tekstu za pomocą PresentationFactory.Instance.GetPresentationText**

Aby wyodrębnić tekst z prezentacji, **Aspose.Slides API** oferuje metodę statyczną `PresentationFactory.Instance.GetPresentationText`. Posiada ona wiele przeciążeń umożliwiających pracę z plikiem prezentacji lub strumieniem danych, pobierając tekst ze **slajdów, slajdów master, układów, notatek i komentarzy**. Wyodrębniony tekst jest dostępny poprzez interfejs `IPresentationText`.

Przykładowe użycie:

```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```

## **Tryby działania GetPresentationText**

Metoda `GetPresentationText` w klasie `PresentationFactory` pozwala precyzyjnie dostosować wyodrębnianie tekstu przy użyciu parametru `TextExtractionArrangingMode`, który określa sposób organizacji tekstu w wyniku.

### **Dostępne tryby**

- **TextExtractionArrangingMode.Unarranged** – Wyodrębnia tekst w sposób swobodny, ignorując pierwotny układ slajdu.  
- **TextExtractionArrangingMode.Arranged** – Zachowuje kolejność tekstu zgodnie z jego rozmieszczeniem na każdym slajdzie.

Przykład użycia:

```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```

## **Kluczowe zalety metod PresentationFactory**

- **Brak konieczności ładowania całych prezentacji**: Minimalizuje zużycie pamięci i zwiększa szybkość przetwarzania.  
- **Optymalizacja pod duże pliki**: Efektywnie radzi sobie nawet z obszerne prezentacjami, szybko wyodrębniając tekst.  
- **Pobiera notatki i komentarze**: Zawiera adnotacje użytkownika, zapewniając pełne pokrycie treści.  
- **Idealne do indeksowania i analizy treści**: Doskonałe dla systemów korporacyjnych wymagających automatycznego przetwarzania i wzbogacania danych.  
- **Niezależne od Office**: Działa bez zainstalowanego Microsoft PowerPoint, oferując naprawdę samodzielne rozwiązanie.  
- **Obsługa wielu formatów**: Działa płynnie z **PPT, PPTX i ODP**.  
- **Elastyczne, potężne API**: Udostępnia wszechstronne metody strukturalnego wyodrębniania tekstu.  
- **Kompletne pokrycie slajdów**: Wyodrębnia tekst z **układów, slajdów master, standardowych slajdów, tła, notatek prelegenta i komentarzy**.  
- **Kompatybilność wieloplatformowa**: Działa na **Windows, Linux, macOS**, oraz w środowiskach chmurowych.  
- **Wysoka wydajność i skalowalność**: Odpowiednie dla **aplikacji SaaS** i dużych wdrożeń przedsiębiorstw.

## **Obsługiwane systemy operacyjne**

Aspose.Slides działa na różnych systemach operacyjnych:

- **Windows** (np. Windows 7, 8, 10, 11 oraz edycje Server)  
- **Linux** (różne dystrybucje, w tym Ubuntu, Debian, Fedora, CentOS itp.)  
- **macOS** (w tym nowoczesne wersje takie jak 10.15 Catalina i nowsze)  

## **Obsługiwane języki programowania**

Aspose.Slides integruje się z wieloma platformami i językami:

- **C#** – Głównie wspierany poprzez Aspose.Slides for .NET.  
- **Java** – Pełnoprawne API dostępne w Aspose.Slides for Java.  
- **C++** – Wykorzystaj Aspose.Slides w aplikacjach C++ o krytycznym znaczeniu wydajnościowym.  
- **Python via .NET** – Włącz funkcjonalność Aspose.Slides przy użyciu interoperacyjności .NET.  
- **Inne języki zgodne z .NET** – Korzystaj z biblioteki w dowolnym środowisku obsługiwanym przez .NET.

## **Podsumowanie**

Aspose.Slides zapewnia **kompleksowe wyodrębnianie tekstu** z prezentacji PowerPoint i OpenDocument, obsługując **różnorodne formaty plików, intuicyjne strukturyzowanie tekstu i prostą implementację** w porównaniu z Open XML SDK. Od **slajdów i notatek po treści szablonów**, **Aspose.Slides** to wydajne, bogate w funkcje rozwiązanie do wyodrębniania i zarządzania tekstem prezentacji.
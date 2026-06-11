---
title: Integracja Aspose.Slides z Google Slides
linktitle: Google Slides
type: docs
weight: 50
url: /pl/net/integrating-aspose-slides-with-google-slides/
keywords:
- platformy chmurowe
- integracja chmurowa
- Google Slides
- Google Drive
- Google API
- Konto usługi Google
- integracja SaaS
- OAuth 2.0
- PPT do PDF
- automatyzacja PowerPoint
- przetwarzanie prezentacji
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Połącz Aspose.Slides z Google Slides, aby importować, synchronizować i konwertować prezentacje, automatyzować przepływy pracy oraz utrzymywać PowerPoint i OpenDocument w jednym potoku."
---
## **Wprowadzenie**

Aspose.Slides teraz zapewnia integrację z Google Slides i Google Drive poprzez swoje [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations). Ta integracja umożliwia aplikacjom .NET konwertowanie, edytowanie, pobieranie i przesyłanie prezentacji Google Slides.

## **Czym jest Google Slides?**
[Google Slides](https://workspace.google.com/products/slides/pl/) to darmowe, internetowe oprogramowanie do tworzenia prezentacji opracowane przez Google. Umożliwia użytkownikom tworzenie, edytowanie i udostępnianie slajdów online, podobnie jak Microsoft PowerPoint. Obsługuje współpracę w czasie rzeczywistym, przechowywanie w chmurze i działa na każdym urządzeniu z dostępem do Internetu.

## **Google API**
Zanim rozpoczniesz pracę z prezentacją Google Slides za pomocą Aspose.Slides, musisz utworzyć projekt Google API i założyć [Google Cloud project](https://developers.google.com/workspace/guides/create-project), a następnie włączyć wymagane API.

Następnie musisz wybrać sposób, w jaki będziesz uzyskiwać dostęp do Google API – [Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) obsługuje dwa tryby dostępu do Google API:
- `Google Service Account`
- `OAuth 2.0` z interakcją użytkownika w przeglądarce.

### **Google Service Account**
Konto usługi jest specjalnym kontem Google używanym przez aplikacje lub serwery do programowego dostępu do API Google bez interakcji z użytkownikiem. Jest powszechnie wykorzystywane w systemach back‑end lub zadaniach automatycznych. Konta usługi uwierzytelniane są za pomocą pliku klucza JSON i posiadają własny adres e‑mail. Mogą mieć przypisane określone uprawnienia poprzez [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) i często używane są z API takimi jak Google Drive, Sheets czy BigQuery, zapewniając bezpieczny, zautomatyzowany dostęp do zasobów.

### **OAuth 2.0**
Innym popularnym sposobem uzyskiwania dostępu do API Google jest OAuth 2.0 z interakcją użytkownika w przeglądarce. W tym scenariuszu użytkownik jest przekierowywany na stronę logowania Google, gdzie przyznaje aplikacji odpowiednie uprawnienia. Po zatwierdzeniu aplikacja otrzymuje kod autoryzacji, który wymienia na token dostępu oraz token odświeżania.

Token dostępu umożliwia tymczasowy dostęp do API Google, natomiast token odświeżania może być przechowywany i używany do uzyskiwania nowych tokenów dostępu bez konieczności ponownego logowania użytkownika. Oznacza to, że interakcja w przeglądarce jest wymagana tylko raz, a kolejne wywołania API są w pełni zautomatyzowane. Metoda ta jest zwykle stosowana w aplikacjach, które potrzebują dostępu do danych użytkownika (np. Gmail, Calendar lub Drive) za jego zgodą.

## **Zacznijmy kodować**
Najpierw dodaj pakiet NuGet [Aspose.Slides SaaS Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) do swojego projektu:

```
dotnet add package Aspose.Slides.SaaSIntegrations
```

### **Przykład 1**
W poniższym przykładzie pobierzemy prezentację Google Slides z Google Drive i zapisujemy ją na dysku lokalnym jako plik PDF. Do uwierzytelnienia użyjemy konta usługi Google, zakładając, że plik JSON z poświadczeniami został już pobrany.

```csharp
// Utwórz zewnętrznie zarządzany HttpClient
HttpClient httpClient = new HttpClient();

// Utwórz dostawcę autoryzacji przy użyciu pliku JSON konta usługi
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// Zainicjalizuj usługę integracji Google Slides z dostawcą autoryzacji
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Załaduj prezentację z Google Drive po jej ID pliku do instancji Aspose.Slides IPresentation
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// Modyfikuj prezentację w razie potrzeby (np. usuń drugi slajd)
pres.Slides.RemoveAt(1);

// Zapisz prezentację lokalnie jako plik PDF
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```

Dla wygody Aspose.Slides SaaS Integration udostępnia metodę listującą wszystkie pliki dostępne dla użytkownika. Zwracane dane zawierają nazwę pliku, typ MIME oraz identyfikator pliku.

```csharp
// Pobierz listę plików dostępnych dla podanego konta usługi
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```

Innym sposobem znalezienia identyfikatora pliku jest otwarcie prezentacji w aplikacji internetowej Google Slides i odczytanie go z adresu URL.

Na przykład w następującym adresie URL:

```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```

Identyfikator pliku to:

```
1A2B3C4D5E6F7G8H9I0J
```

## **Przykład 2**
W kolejnym przykładzie stworzymy prezentację PowerPoint od podstaw i prześlemy ją do Google Drive w formacie Google Slides. Do uwierzytelnienia użyjemy OAuth 2.0.

```csharp
// Utwórz zewnętrznie zarządzany HttpClient
HttpClient httpClient = new HttpClient();

// Utwórz dostawcę autoryzacji przy użyciu OAuth z identyfikatorem klienta i tajnym kluczem klienta
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// Zainicjalizuj usługę integracji Google Slides z dostawcą autoryzacji
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Utwórz przykładową prezentację
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // Zapisz prezentację w katalogu głównym Google Drive w formacie Google Slides
    // Możesz również wybrać dowolny inny format eksportu obsługiwany przez Aspose.Slides
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```

Jeśli w swojej aplikacji stosujesz ten typ uwierzytelnienia, `interaction with the browser is required`. Musisz wybrać konto i potwierdzić, że zezwalasz aplikacji na dostęp do API Google Drive. To wszystko — operacja jest wymagana tylko przy pierwszym uruchomieniu.

### **Przykład 3**
W poniższym przykładzie skorzystamy z uprzednio uzyskanego tokena dostępu. `GoogleAccessTokenAuthProvider` jest implementacją interfejsu `IGoogleAuthorizationProvider`, która używa istniejącego tokena OAuth 2.0 do autoryzacji żądań do API Google. W przeciwieństwie do dostawców inicjujących lub zarządzających przepływem OAuth, ta klasa polega na tym, że wywołujący dostarczy ważny token dostępu.

Ten dostawca jest przydatny w systemach, w których token dostępu jest uzyskiwany zewnętrznie — zazwyczaj przez aplikację front‑end lub inny serwis — i przekazywany do warstwy back‑end. Jest szczególnie odpowiedni dla rozproszonych środowisk, w których zarządzanie tokenami odświeżania po stronie serwera wprowadza dodatkową złożoność lub ryzyko ich unieważnienia przy jednoczesnych próbach odświeżenia.

Przykład demonstruje, jak zastąpić plik i zaktualizować jego nazwę w Google Drive, zachowując jednocześnie jego identyfikator.

```csharp
// Utwórz klienta HTTP do wykonywania żądań
using HttpClient httpClient = new HttpClient();

// Skonfiguruj uwierzytelnianie Google Drive przy użyciu tokena dostępu
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// Zainicjalizuj integrację z Google Slides/Drive używając uwierzytelnienia i klienta HTTP
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Create a sample presentation using Aspose.Slides
using (var presentation = new Presentation())
{
    // Dodaj prostokątny kształt do pierwszego slajdu i ustaw jego tekst
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // Zdefiniuj opcje zapisu PDF z określoną jakością i ustawieniami zgodności
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // Zapisz (zastąp) istniejący plik w Google Drive po ID pliku, zaktualizuj jego nazwę i wyeksportuj jako PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // ID istniejącego pliku w Google Drive
        GoogleSaveFormatType.Pdf,         // Żądany format zapisu
        saveOptions,           
        "NewFileName.pdf"                 // Nowa nazwa pliku
    );
}
```

## **Podsumowanie**
Aspose.Slides teraz obsługuje dodatkowy format pliku do zarządzania, upraszczając automatyzację przepływów pracy w chmurze związanych z tworzeniem, udostępnianiem i edycją prezentacji.

W tym artykule przedstawiono podstawowe funkcje. Możesz także zapisywać pliki w podfolderach, zastępować istniejące pliki oraz eksportować do Google Drive w różnych formatach — nie tylko w formacie Google Slides.

Aspose.Slides SaaS Integration będzie nadal rozszerzać wsparcie dla platform SaaS prezentacji, więc sprawdzaj aktualizacje w przyszłości.

## **FAQ**

**Czy do korzystania z tej integracji potrzebne jest konto Google Workspace?**  
Nie. Możesz używać zarówno darmowego konta Google, jak i konta Google Workspace. Wymagany dostęp zależy od uprawnień w Google Drive i Slides.

** którą metodę uwierzytelniania wybrać — Service Account czy OAuth 2.0?**  
Użyj **Service Account** dla procesów back‑end lub automatycznych, które nie wymagają interakcji użytkownika.  
Użyj **OAuth 2.0**, jeśli musisz uzyskać dostęp do plików Google Slides lub Drive konkretnego użytkownika za jego zgodą.

**Czy mogę pracować z formatami innymi niż Google Slides?**  
Tak. Aspose.Slides pozwala zapisywać prezentacje w różnych formatach (np. PDF, PPTX, HTML) przed ich przesłaniem do Google Drive.

**Jak mogę uzyskać identyfikator pliku prezentacji Google Slides?**  
Możesz pobrać go metodą `GetDriveFileInfosAsync()` lub skopiować z adresu URL prezentacji w Google Slides.

**Czy integracja umożliwia zastąpienie istniejącego pliku na Google Drive?**  
Tak. Użyj metody `SavePresentationToExistingFileAsync`, aby zaktualizować plik przy zachowaniu jego identyfikatora.

**Czy przy użyciu OAuth 2.0 wymagana jest interakcja w przeglądarce przy każdym użyciu?**  
Nie. Interakcja w przeglądarce jest wymagana tylko podczas pierwszej autoryzacji. Następnie przechowywane tokeny odświeżania umożliwiają automatyczny dostęp.
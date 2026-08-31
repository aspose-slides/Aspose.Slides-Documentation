---
title: Instalacja
type: docs
weight: 70
url: /pl/net/installation/
keywords:
- instalacja Aspose.Slides
- pobierz Aspose.Slides
- użyj Aspose.Slides
- instalacja Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak szybko zainstalować Aspose.Slides dla .NET. Przewodnik krok po kroku, wymagania systemowe oraz przykłady kodu — zacznij już dziś pracować z prezentacjami PowerPoint!"
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zainstalować Aspose.Slides for .NET w systemach Windows, Linux i macOS. Skupia się na instalacji z wykorzystaniem NuGet i pokazuje, jak dodać bibliotekę poprzez Menedżer pakietów NuGet lub Konsolę Menedżera pakietów w systemie Windows, do projektu .NET w systemie Linux oraz do projektu Visual Studio w systemie macOS. Opisuje także, jak zaktualizować pakiet i zainstalować wersje prerelease, gdy jest to potrzebne.

Przed instalacją zapoznaj się z obsługiwanymi systemami operacyjnymi, implementacjami .NET oraz dodatkowymi zależnościami w [Wymagania systemowe](/slides/pl/net/system-requirements/).

## **Windows**
NuGet zapewnia najłatwiejszą drogę do pobrania i instalacji interfejsów Aspose dla .NET na komputerach.

### **Metoda 1: Instalacja lub aktualizacja Aspose.Slides za pomocą Menedżera pakietów NuGet**

1. Otwórz Microsoft Visual Studio.  
2. Utwórz prostą aplikację konsolową lub otwórz istniejący projekt.  
3. Przejdź do **Tools** > **NuGet package manager**.  
4. W zakładce **Browse** wpisz w polu tekstowym *Aspose Slides*.  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Kliknij **Aspose.Slides.NET**, a następnie **Install**.  
   * Jeśli chcesz zaktualizować Aspose.Slides — zakładając, że już jest zainstalowany — zamiast tego kliknij **Update**.  

Wybrany interfejs zostanie pobrany i dodany jako odwołanie w Twoim projekcie.

### **Metoda 2: Instalacja lub aktualizacja Aspose.Slides poprzez Konsolę Menedżera pakietów**

Tak odwołujesz [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) w konsoli Menedżera pakietów:

1. Otwórz Microsoft Visual Studio.  
2. Utwórz prostą aplikację konsolową lub otwórz istniejący projekt.  
3. Przejdź do **Tools** > **Library Package Manager** > **Package Manager Console**.  
![todo:image_alt_text](installation_2.png)
4. Uruchom następujące polecenie: `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
Najświeższe pełne wydanie zostanie zainstalowane w Twojej aplikacji.  

* Opcjonalnie możesz dodać przyrostek `-prerelease` do polecenia, aby zainstalować najnowszą wersję (wraz z poprawkami).

W dolnej części okna pojawia się wskazówka **Installing Aspose.Slides.NET**.  
![todo:image_alt_text](installation_4.png)

Po zakończeniu pobierania powinny się wyświetlić komunikaty potwierdzające.

Jeśli nie jesteś zaznajomiony z [Aspose EULA](https://about.aspose.com/legal/eula), warto zapoznać się z licencją podanym pod tym adresem.  
![todo:image_alt_text](installation_5.png)

W Twojej aplikacji powinno być widoczne, że Aspose.Slides został pomyślnie dodany i odwołany.  
![todo:image_alt_text](installation_6.png)

W Konsoli Menedżera pakietów możesz uruchomić polecenie `Update-Package Aspose.Slides.NET`, aby sprawdzić dostępność aktualizacji pakietu Aspose.Slides. Znalezione aktualizacje zostaną zainstalowane automatycznie. Możesz również użyć przyrostka `-prerelease`, aby zaktualizować najnowszą wersję.

#### **Uwagi przy uruchamianiu w środowisku serwera współdzielonego**
Zalecamy uruchamianie wszystkich komponentów Aspose .NET z zestawem uprawnień **Full Trust**, ponieważ komponenty Aspose czasami muszą uzyskać dostęp do ustawień rejestru i plików znajdujących się poza wirtualnym katalogiem — na przykład gdy muszą odczytać czcionki.

Ponadto komponenty Aspose.NET opierają się na podstawowych klasach systemu .NET, a niektóre z nich również wymagają uprawnień Full Trust w określonych sytuacjach.

Dostawcy usług internetowych, którzy hostują wiele aplikacji różnych firm, najczęściej wymuszają poziom bezpieczeństwa Medium Trust. W przypadku .NET 2.0 taki poziom może wprowadzać ograniczenia wpływające na działanie Aspose.Slides:

- **RegistryPermission** nie jest dostępny. Oznacza to brak możliwości dostępu do rejestru, co jest potrzebne do wyliczania zainstalowanych czcionek podczas renderowania dokumentów.  
- **FileIOPermission** jest ograniczony. Oznacza to, że można uzyskać dostęp jedynie do plików w hierarchii wirtualnego katalogu aplikacji. Może to również uniemożliwić odczyt czcionek podczas operacji eksportu.  

Z tych powodów zdecydowanie zalecamy uruchamianie Aspose.Slides z uprawnieniami **Full Trust**. Jeśli używasz **Medium trust**, możesz napotkać niezgodności — niektóre funkcje biblioteki (np. renderowanie) mogą nie działać przy określonych zadaniach.

## **Linux**

NuGet zapewnia najłatwiejszą drogę do pobrania i instalacji Aspose.Slides for .NET w systemie Linux. Dodaj pakiet [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) do swojego projektu .NET.

## **macOS**

NuGet zapewnia najłatwiejszą drogę do pobrania i instalacji Aspose.Slides for .NET na komputerach Mac.

### **Instalacja Aspose.Slides**

1. Otwórz Visual Studio.  
2. Utwórz prostą aplikację konsolową lub otwórz istniejący projekt.  
3. Przejdź do **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Wpisz *Aspose.Slides* w polu tekstowym.  
5. Kliknij **Aspose.Slides for .NET**, a następnie **Add Package**.  
6. Dodaj prosty fragment kodu.  
   * Możesz skopiować kod z [tej strony](/slides/pl/net/create-presentation/).  
7. Uruchom aplikację.  
8. Otwórz *folder/bin/Debug/presentation_file_name* swojego projektu.

## **FAQ**

**Czy istnieje wersja darmowa lub ograniczenia wersji próbnej?**

Tak, domyślnie Aspose.Slides działa w trybie ewaluacji, co powoduje umieszczanie znaków wodnych i może wprowadzać inne ograniczenia. Aby usunąć ograniczenia, musisz zastosować ważną [licencję](/slides/pl/net/licensing/).
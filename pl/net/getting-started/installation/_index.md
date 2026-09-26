---
title: Instalcja
type: docs
weight: 70
url: /pl/net/installation/
keywords:
- zainstaluj Aspose.Slides
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
description: "Zainstaluj Aspose.Slides dla .NET z NuGet na Windows, Linux i macOS: wybierz jeden z dwóch pakietów, dodaj go za pomocą .NET CLI lub Visual Studio oraz zainstaluj wymagane zależności dla Linuxa."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać Aspose.Slides for .NET do projektu w systemach Windows, Linux i macOS. Aspose.Slides jest dystrybuowany przez NuGet. Można go dodać za pomocą .NET CLI na dowolnym systemie operacyjnym lub za pomocą Menedżera pakietów NuGet albo Konsoli Menedżera pakietów w Visual Studio na Windows. Artykuł opisuje także, który z dwóch pakietów NuGet wybrać i co jest dodatkowo potrzebne w Linuxie.

Przed instalacją zapoznaj się z obsługiwanymi systemami operacyjnymi, implementacjami .NET oraz dodatkowymi zależnościami w [System Requirements](/slides/pl/net/system-requirements/).

## **Wybór pakietu**

Aspose.Slides for .NET jest publikowany jako dwa pakiety NuGet. Oba dostarczają te same przestrzenie nazw i klasy Aspose.Slides, więc kod nie zmienia się przy przełączaniu między nimi; różni się jedynie odwołanie do pakietu i wymagania platformy.

| Pakiet | Użyj go dla | Dodatkowe wymagania |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Aplikacje Windows i .NET Framework | W Linux i macOS: biblioteka `libgdiplus` oraz włączony przełącznik `System.Drawing.EnableUnixSupport` przy uruchamianiu aplikacji |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 lub nowszy w systemach Windows, Linux i macOS | W Linux: biblioteka `fontconfig`, jeśli nie jest już zainstalowana |

Jeśli nie masz pewności, użyj Aspose.Slides.NET w Windows oraz Aspose.Slides.NET6.CrossPlatform w Linux i macOS. W Alpine Linux oraz w systemach Linux, których glibc jest starsza niż 2.23 (x64) lub 2.39 (ARM64), użyj Aspose.Slides.NET. [System Requirements](/slides/pl/net/system-requirements/) wymienia obsługiwane platformy każdego pakietu.

## **Instalacja za pomocą .NET CLI**

Te kroki działają w Windows, Linux i macOS przy użyciu .NET SDK 6 lub nowszego. Utwórz aplikację konsolową:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Następnie dodaj pakiet odpowiedni dla twojej platformy. Dodaj tylko jeden z dwóch pakietów do projektu.

- W Windows: `dotnet add package Aspose.Slides.NET`
- W Linux i macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (w Linuxie najpierw zainstaluj wymagane zależności; zobacz [Linux](#linux))

Aby sprawdzić, czy pakiet działa, zastąp zawartość *Program.cs* pierwszym przykładem w [Create Presentations](/slides/pl/net/create-presentation/) i uruchom `dotnet run`. Zapisze on *hello.pptx* w folderze projektu.

## **Windows**

### **Metoda 1: Instalacja lub aktualizacja Aspose.Slides z Menedżera pakietów NuGet**

1. Otwórz Microsoft Visual Studio.  
2. Utwórz aplikację konsolową lub otwórz istniejący projekt.  
3. W **Solution Explorer** kliknij prawym przyciskiem projektu i wybierz **Manage NuGet Packages** (lub przejdź do **Project** > **Manage NuGet Packages**).  
4. W zakładce **Browse** wyszukaj *Aspose.Slides*.  
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}  
5. Kliknij **Aspose.Slides.NET**, a następnie **Install**.  
   * Jeśli już zainstalowałeś Aspose.Slides i chcesz go zaktualizować, kliknij **Update**.

Pakiet zostanie pobrany i dodany jako odwołanie w projekcie.

### **Metoda 2: Instalacja lub aktualizacja Aspose.Slides przez Konsolę Menedżera pakietów**

Tak odwołujesz pakiet [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) w Konsoli Menedżera pakietów:

1. Otwórz Microsoft Visual Studio.  
2. Utwórz aplikację konsolową lub otwórz istniejący projekt.  
3. Przejdź do **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
![Opening the Package Manager Console](installation_2.png)  
4. Uruchom polecenie: `Install-Package Aspose.Slides.NET`  
![Running the Install-Package command](installation_3.png)  
Najbardziej aktualna wersja zostanie zainstalowana w projekcie.

W oknie pojawi się komunikat **Installing Aspose.Slides.NET** u dołu.  
![Installation progress in the Package Manager Console](installation_4.png)

Po zakończeniu pobierania pojawią się komunikaty potwierdzające. Pakiet jest dystrybuowany na warunkach [Aspose EULA](https://about.aspose.com/legal/eula).  
![Installation confirmation messages](installation_5.png)

Aspose.Slides zostaje teraz dodany do projektu i odwołany.  
![Aspose.Slides referenced in the project](installation_6.png)

Aby zaktualizować pakiet, uruchom `Update-Package Aspose.Slides.NET` w Konsoli Menedżera pakietów.

## **Linux**

Użyj kroków .NET CLI opisanych powyżej. Wybierz pakiet i zainstaluj jego zależność przy pomocy menedżera pakietów twojej dystrybucji. W Debian i Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: zainstaluj `fontconfig`.  

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: zainstaluj `libgdiplus` i włącz obsługę Unix dla System.Drawing przed użyciem Aspose.Slides.  

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

  Dodaj to polecenie na początku aplikacji, przed jakimkolwiek wywołaniem Aspose.Slides. W *Program.cs* z instrukcjami poziomu top-level umieść je po dyrektywach `using`:

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

  Używaj tego pakietu w Alpine Linux oraz w systemach, których glibc jest za stara dla Aspose.Slides.NET6.CrossPlatform.

Czcionki używane w prezentacjach lub ich odpowiednie zamienniki muszą być zainstalowane w systemie, aby tekst był renderowany prawidłowo. [System Requirements](/slides/pl/net/system-requirements/) opisuje pakiety potrzebne Aspose.Slides.NET w Alpine Linux, w tym czcionki.

## **macOS**

Użyj kroków .NET CLI opisanych powyżej z pakietem **Aspose.Slides.NET6.CrossPlatform**, który obsługuje zarówno komputery Intel (x86_64), jak i Apple silicon (ARM64) Macs:

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Czy istnieje darmowa wersja lub ograniczenia wersji próbnej?**

Tak. Bez licencji Aspose.Slides działa w trybie ewaluacyjnym: dodaje znak wodny „evaluation” do każdego zapisanego slajdu i przycina tekst odczytany z prezentacji. Aby usunąć te ograniczenia, zastosuj ważną [licencję](/slides/pl/net/licensing/).
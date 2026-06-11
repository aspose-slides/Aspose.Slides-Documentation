---
title: Instalacja
type: docs
weight: 70
url: /pl/cpp/installation/
keywords:
- instalacja Aspose.Slides
- pobierz Aspose.Slides
- korzystanie z Aspose.Slides
- instalacja Aspose.Slides
- Windows
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak szybko zainstalować Aspose.Slides dla C++. Przewodnik krok po kroku, wymagania systemowe i przykłady kodu — zacznij pracować z prezentacjami PowerPoint już dziś!"
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zainstalować Aspose.Slides w systemie Windows. Skupia się na instalacji opartej na NuGet i pokazuje, jak dodać bibliotekę do projektu Visual Studio, zarówno za pośrednictwem Menedżera pakietów NuGet, jak i konsoli Menedżera pakietów w Windows. Opisuje również, jak zaktualizować pakiet i zainstalować wersje prerelease w razie potrzeby.

## **Windows**
NuGet zapewnia najłatwiejszą drogę do pobierania i instalacji interfejsów API Aspose dla C++ na komputerach PC. 

### **Opcja pierwsza: Instalacja lub aktualizacja Aspose.Slides dla C++ z Menedżera pakietów NuGet**

1. Otwórz Microsoft Visual Studio. 
2. Utwórz prostą aplikację konsolową. Możesz również otworzyć wybrany projekt. 
3. Przejdź do **Tools** > **NuGet package manager**.
4. W sekcji **Browse** wpisz *Aspose.Slides.Cpp* w polu tekstowym. 

![todo:image_alt_text](installation_1.png)

3. Kliknij wersję, której potrzebujesz **Aspose.Slides.Cpp**, a następnie kliknij **Install**. 
   * Jeśli chcesz zaktualizować Aspose.Slides (co oznacza, że jest już zainstalowany), kliknij **Update** zamiast tego. 

Wybrany interfejs API zostaje pobrany i dodany jako odwołanie w Twoim projekcie.

### **Opcja 2: Instalacja lub aktualizacja Aspose.Slides przy użyciu konsoli Menedżera pakietów**

Aby odwołać się do [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) przy użyciu konsoli Menedżera pakietów, wykonaj następujące kroki:

1. Otwórz rozwiązanie/projekt w Visual Studio.

1. Przejdź do **Tools** > **NuGet Package Manager** > **Package Manager Console**. 

Konsola Menedżera pakietów zostanie otwarta. 

![todo:image_alt_text](installation_2.png)

4. Wpisz następujące polecenie: `Install-Package Aspose.Slides.Cpp` 
> Jeśli chcesz zainstalować wersję x86, użyj pakietu Aspose.Slides.Cpp.x86: `Install-Package Aspose.Slides.Cpp.x86`

5. Naciśnij klawisz Enter.

Najbardziej aktualna pełna wersja zostaje zainstalowana w Twojej aplikacji. 

* Alternatywnie możesz dodać sufiks `-prerelease` do polecenia, aby określić, że ma zostać zainstalowana najnowsza wersja (w tym poprawki). 

![todo:image_alt_text](installation_3.png)

Po zakończeniu pobierania powinieneś zobaczyć komunikaty potwierdzające.  

![todo:image_alt_text](installation_4.png)

Jeśli nie znasz [licencji Aspose EULA](https://about.aspose.com/legal/eula), możesz chcieć przeczytać licencję podaną w tym adresie URL.  

W konsoli Menedżera pakietów możesz uruchomić polecenie `Update-Package Aspose.Slides.Cpp`, aby sprawdzić dostępność aktualizacji pakietu Aspose.Slides. Aktualizacje (jeśli dostępne) są instalowane automatycznie. Możesz również użyć sufiksu `-prerelease`, aby zaktualizować najnowszą wersję.

### **Używanie folderów Include i lib**
1. [Pobierz](https://downloads.aspose.com/slides/pl/cpp) najnowszą wersję Aspose.Slides dla C++.
1. Rozpakuj folder w środowisku produkcyjnym.
1. Aby używać Aspose.Slides dla C++, odwołaj foldery Include i lib w swoim projekcie

## **FAQ**

**Czy istnieje darmowa wersja lub ograniczenia wersji próbnej?**

Tak, domyślnie Aspose.Slides działa w trybie ewaluacyjnym, który dodaje znak wodny i może mieć inne ograniczenia. Aby usunąć restrykcje, musisz zastosować ważną [licencję](/slides/pl/cpp/licensing/).
---
title: Jak uruchomić przykłady
type: docs
weight: 130
url: /pl/net/how-to-run-examples/
keywords:
- przykłady
- wymagania oprogramowania
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Szybko uruchom przykłady Aspose.Slides dla .NET: sklonuj repozytorium, przywróć pakiety, a następnie zbuduj i przetestuj funkcje dla PPT, PPTX i ODP."
---
## **Wymagania oprogramowania**
Przed pobraniem i uruchomieniem przykładów, sprawdź i potwierdź, że Twoje środowisko spełnia te wymagania: 

- Visual Studio 2010 lub nowsze.
- Zainstalowany w Visual Studio Menedżer pakietów NuGet. Zweryfikuj, że najnowsza wersja API NuGet jest zainstalowana w Visual Studio. 

Aby uzyskać instrukcje instalacji Menedżera pakietów NuGet, przejdź do tej strony: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Przejdź do **Tools** > **Options** > **NuGet Package Manager**.

1. Rozwiń **NuGet Package Manager** (klikając dwukrotnie) i wybierz **Package Sources**. 

1. Sprawdź i potwierdź, że parametr nuget.org jest wybrany. 

   Projekt przykładowy korzysta z funkcji automatycznego przywracania pakietów NuGet, więc musisz mieć aktywne połączenie internetowe. 

   Jeśli nie masz aktywnego połączenia internetowego na maszynie, na której zamierzasz uruchamiać przykłady, sprawdź [Installation](https://docs.aspose.com/slides/pl/net/installation/) i (ręcznie) dodaj odwołanie do Aspose.Slides.dll w projekcie przykładu.
## **Pobierz Aspose.Slides z GitHub**
Wszystkie przykłady Aspose.Slides dla .NET są dostępne na [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET).

Możesz sklonować repozytorium za pomocą swojego ulubionego klienta GitHub lub pobrać plik ZIP [tutaj](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip).

1. Jeśli pobierzesz plik ZIP, musisz wypakować jego zawartość do folderu na swoim komputerze. 

Wszystkie przykłady są przechowywane w folderze **Examples**.

W repozytorium znajduje się plik rozwiązania Visual Studio w C#. Projekty zostały utworzone w Visual Studio 2013, ale pliki rozwiązania są zgodne z Visual Studio 2010 SP1 i nowszymi.

2. Otwórz plik rozwiązania w Visual Studio i zbuduj projekt.

   Podczas pierwszego uruchomienia zależności są automatycznie pobierane przez NuGet.

Folder **Data** w katalogu głównym **Examples** zawiera pliki wejściowe używane w przykładach C#. Musisz pobrać folder **Data** razem z projektem przykładów.

3. Otwórz plik RunExamples.cs. Wszystkie przykłady są wywoływane z tego pliku.

4. Odkomentuj przykłady, które chcesz uruchomić w projekcie.

Jeśli napotkasz problemy z konfiguracją lub uruchamianiem przykładów, śmiało skontaktuj się z nami na forum.
## **Współtwórz**
Możesz przyczynić się do projektu, dodając lub udoskonalając przykład. Wszystkie przykłady i projekty demonstracyjne w repozytorium są open-source, więc Ty (oraz inni) możecie ich swobodnie używać w aplikacjach.

Aby współtworzyć, możesz forknąć repozytorium, edytować kod źródłowy i stworzyć pull request. Przejrzymy zmiany. Jeśli uznamy je za przydatne, dodamy je do repozytorium.
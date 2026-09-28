---
title: Rozpoczęcie
type: docs
weight: 10
url: /pl/net/getting-started/
keywords:
- rozpoczęcie
- wymagania systemowe
- instalacja
- pierwsza prezentacja
- NuGet
- przetwarzanie PPT
- przetwarzanie PPTX
- przetwarzanie ODP
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Ścieżka od nowego projektu .NET do pierwszej zapisanej prezentacji przy użyciu Aspose.Slides: sprawdź wymagania, zainstaluj pakiet, uruchom pierwszy program i kontynuuj z typowymi zadaniami."
---
## **Przegląd**

Przejdź kolejno przez cztery poniższe kroki. Każdy krok określa, co zrobić i odsyła do artykułu ze szczegółami. Ocena, licencjonowanie i wsparcie są opisane po krokach.

## **Krok 1: Sprawdź wymagania systemowe**

Aspose.Slides for .NET działa na systemach Windows, Linux i macOS. [Wymagania systemowe](/slides/pl/net/system-requirements/) wymienia systemy operacyjne i wersje .NET, które obsługuje każdy pakiet, oraz dodatkowe biblioteki wymagane w Linuxie.

## **Krok 2: Zainstaluj pakiet**

Aspose.Slides for .NET jest dystrybuowany przez NuGet jako dwa pakiety zawierające te same klasy. Dodaj jeden z nich do swojego projektu:

- Na Windows: `dotnet add package Aspose.Slides.NET`
- Na Linux i macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Na Linux, najpierw zainstaluj bibliotekę `fontconfig`.
- Na Alpine Linux oraz na systemach Linux, których glibc jest starsza niż 2.23 (x64) lub 2.39 (ARM64): Aspose.Slides.NET, z zainstalowaną biblioteką `libgdiplus`.

[Instalacja](/slides/pl/net/installation/) podaje polecenia Linux, dodatkowe ustawienie uruchomieniowe, które Aspose.Slides.NET wymaga w Linuxie, oraz kroki dla Visual Studio.

## **Krok 3: Utwórz swoją pierwszą prezentację**

[Szybki start na stronie głównej Aspose.Slides for .NET](/slides/pl/net/#your-first-presentation) jest kompletnym programem konsolowym: dodaje pole tekstowe do slajdu i zapisuje prezentację jako plik PPTX. [Tworzenie prezentacji](/slides/pl/net/create-presentation/) wyjaśnia te same kroki w większych szczegółach i pokazuje, jak otworzyć istniejącą prezentację oraz zapisać ją w innym formacie.

## **Krok 4: Kontynuuj z typowymi zadaniami**

- [Otwórz prezentację](/slides/pl/net/open-presentation/)
- [Zapisz prezentację](/slides/pl/net/save-presentation/)
- [Konwertuj prezentację na PDF](/slides/pl/net/convert-powerpoint-to-pdf/)
- [Renderuj slajdy jako obrazy](/slides/pl/net/convert-slide/)
- [Edytuj tekst prezentacji](/slides/pl/net/manage-text/)
- [Przykłady według elementu slajdu](/slides/pl/net/examples/)

## **Ewaluacja i licencja**

Bez licencji Aspose.Slides działa w trybie ewaluacyjnym: dodaje znak wodny do każdego zapisanego slajdu i przycina tekst odczytywany z prezentacji.

- [Ewaluuj Aspose.Slides](/slides/pl/net/evaluate-aspose-slides/) opisuje ograniczenia wersji ewaluacyjnej i sposób uzyskania tymczasowej licencji.
- [Licencjonowanie](/slides/pl/net/licensing/) pokazuje, jak zastosować licencję z pliku, strumienia lub zasobu osadzonego.
- [Licencjonowanie rozliczane](/slides/pl/net/metered-licensing/) obejmuje licencje rozliczane według użycia.
- [Obsługiwane formaty plików](/slides/pl/net/supported-file-formats/) wymienia formaty, które Aspose.Slides może wczytywać i zapisywać.

## **Uzyskaj pomoc**

[Wsparcie produktu](/slides/pl/net/product-support/) wyjaśnia, jak zadać pytanie na [bezpłatnym forum wsparcia](https://forum.aspose.com/c/slides/pl/11) i co powinno znaleźć się w raporcie o problemie.

## **FAQ**

**Czy potrzebuję zainstalowanego Microsoft PowerPoint?**

Nie. Aspose.Slides samodzielnie odczytuje i zapisuje pliki prezentacji i nie korzysta z PowerPoint, więc działa również na serwerach i w systemie Linux.

**Który pakiet powinienem użyć w aplikacji .NET Framework?**

Aspose.Slides.NET. Zawiera wersje dla .NET Framework 4.6.2 i nowszych, .NET 6 i nowszych oraz .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform wymaga .NET 6 lub nowszego.
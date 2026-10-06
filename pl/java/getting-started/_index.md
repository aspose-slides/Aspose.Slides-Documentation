---
title: Rozpoczęcie
type: docs
weight: 10
url: /pl/java/getting-started/
keywords:
  - rozpoczęcie
  - wymagania systemowe
  - instalacja
  - pierwsza prezentacja
  - Maven
  - przetwarzanie PPT
  - przetwarzanie PPTX
  - przetwarzanie ODP
  - PowerPoint
  - OpenDocument
  - prezentacja
  - Java
  - Aspose.Slides
description: "Ścieżka od nowego projektu Java do pierwszej zapisanej prezentacji z Aspose.Slides: sprawdź wymagania, dodaj bibliotekę z repozytorium Maven Aspose, uruchom pierwszy program i kontynuuj z typowymi zadaniami."
---
## **Przegląd**

Pracuj przez cztery poniższe kroki w kolejności. Każdy krok określa, co zrobić i odwołuje się do artykułu z szczegółami. Ocena, licencjonowanie i wsparcie są omówione po krokach.

## **Krok 1: Sprawdź wymagania systemowe**

Aspose.Slides for Java jest pojedynczym plikiem JAR bez kodu natywnego, więc działa na każdym systemie operacyjnym, który ma obsługiwane środowisko uruchomieniowe Java. [Wymagania systemowe](/slides/pl/java/system-requirements/) wymienia obsługiwane systemy operacyjne i wersje Java. Projekt i polecenia w kolejnych krokach wymagają JDK 11 lub nowszego oraz, w przypadku ścieżki Maven, [Apache Maven](https://maven.apache.org/install.html).

## **Krok 2: Dodaj bibliotekę do swojego projektu**

Aspose.Slides for Java jest publikowane w własnym repozytorium Maven Aspose, nie w Maven Central. Wybierz jedną z tych ścieżek:

- Z Maven: zadeklaruj repozytorium `https://releases.aspose.com/java/repo/` w swoim *pom.xml* i dodaj zależność `com.aspose:aspose-slides` z klasyfikatorem `jdk16`.
- Bez Maven: pobierz plik JAR, którego nazwa kończy się na *-jdk16.jar* z repozytorium i umieść go na ścieżce klas.

W systemie Linux zainstaluj również bibliotekę fontconfig i przynajmniej jedną czcionkę. Bez nich zapisywanie prezentacji kończy się błędem „Fontconfig head is null, check your fonts or fonts configuration”.

[Instalacja](/slides/pl/java/installation/) podaje wpisy *pom.xml*, pobranie JAR oraz polecenie Linux.

## **Krok 3: Utwórz swoją pierwszą prezentację**

[Szybki start na stronie głównej Aspose.Slides for Java](/slides/pl/java/#your-first-presentation) to kompletny projekt Maven: plik *pom.xml* oraz program, który dodaje kształt chmury z tekstem do slajdu i zapisuje prezentację jako plik PPTX. Uruchom go przy pomocy `mvn compile exec:java`. [Tworzenie prezentacji](/slides/pl/java/create-presentation/) wyjaśnia ten sam program krok po kroku. Aby otworzyć istniejącą prezentację i zapisać ją w innym formacie, zobacz [Otwieranie prezentacji](/slides/pl/java/open-presentation/) i [Zapisywanie prezentacji](/slides/pl/java/save-presentation/).

## **Krok 4: Kontynuuj z typowymi zadaniami**

- [Otwórz prezentację](/slides/pl/java/open-presentation/)
- [Zapisz prezentację](/slides/pl/java/save-presentation/)
- [Konwertuj prezentację do PDF](/slides/pl/java/convert-powerpoint-to-pdf/)
- [Renderuj slajdy jako obrazy](/slides/pl/java/convert-slide/)
- [Edytuj tekst prezentacji](/slides/pl/java/manage-text/)
- [Przykłady według elementu slajdu](/slides/pl/java/examples/)

## **Ocena i licencjonowanie**

Bez licencji Aspose.Slides działa w trybie ewaluacyjnym: dodaje znak wodny do każdego zapisanego slajdu i przycina tekst odczytywany z prezentacji przez Twój kod.

- [Ewaluuj Aspose.Slides](/slides/pl/java/evaluate-aspose-slides/) opisuje ograniczenia ewaluacji i sposób uzyskania tymczasowej licencji.
- [Licencjonowanie](/slides/pl/java/licensing/) pokazuje, jak zastosować licencję z pliku lub strumienia.
- [Licencjonowanie rozliczane według zużycia](/slides/pl/java/metered-licensing/) omawia licencje rozliczane na podstawie wykorzystania.
- [Obsługiwane formaty plików](/slides/pl/java/supported-file-formats/) wymienia formaty, które Aspose.Slides może wczytać i zapisać.

## **Uzyskaj pomoc**

[Wsparcie techniczne](/slides/pl/java/technical-support/) wyjaśnia, jak zadać pytanie na [darmowym forum wsparcia](https://forum.aspose.com/c/slides/pl/11) i co należy dołączyć przy zgłaszaniu problemu.

## **FAQ**

**Czy muszę mieć zainstalowany Microsoft PowerPoint?**

Nie. Aspose.Slides odczytuje i zapisuje pliki prezentacji samodzielnie i nie korzysta z PowerPoint, więc działa także na serwerach i w systemie Linux.

**Dlaczego Maven nie znajduje Aspose.Slides for Java?**

Biblioteka nie znajduje się w Maven Central. Zadeklaruj repozytorium Aspose w swoim *pom.xml*, jak pokazano w [Instalacji](/slides/pl/java/installation/), a Maven pobierze bibliotekę stamtąd.

**Czy klasyfikator `jdk16` oznacza, że biblioteka wymaga Java 16?**

Nie. Klasyfikator wybiera wersję biblioteki zbudowaną dla Java SE; inna wersja jest przeznaczona dla Androida. Ta sama wersja działa na aktualnych JDK, takich jak JDK 21.
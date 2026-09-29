---
title: Bezpieczeństwo
type: docs
weight: 160
url: /pl/java/security/
keywords:
- bezpieczeństwo
- zależności
- komponenty firm trzecich
- Maven
- podpis JAR
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przegląd tego, jak Aspose.Slides for Java przetwarza prezentacje, co dodaje do zależności Twojego projektu, jak zweryfikować plik JAR oraz które komponenty firm trzecich zawiera."
---
## **Wstęp**

Ten artykuł zbiera informacje, które zazwyczaj są potrzebne przy przeglądzie bezpieczeństwa aplikacji używającej Aspose.Slides for Java: jak biblioteka przetwarza prezentacje, co dodaje do zależności Twojego projektu, jak sprawdzić, że plik JAR pochodzi od Aspose oraz które komponenty innych firm zawiera plik JAR.

## **Bezpieczeństwo w Aspose.Slides**

* Aspose.Slides for Java służy do tworzenia, modyfikowania i konwertowania prezentacji. Nie uruchamia skryptów w prezentacjach. Aspose.Slides analizuje strukturę prezentacji i umożliwia Twojemu kodowi pracę z modelem obiektowym.
* Aspose.Slides działa jako biblioteka, która analizuje i interpretuje dokumenty bez wykonywania zdalnego kodu. Wszystkie produkty Aspose działają na Twoich maszynach. Nie przesyłają żadnych danych do Aspose. Jedynym wyjątkiem jest [metered licensing](/slides/pl/java/metered-licensing/): jeśli go używasz, przetwarzane są jedynie informacje o użyciu API.
* Komponenty Aspose działają w tym samym kontekście użytkownika co zwykłe aplikacje. Dlatego komponenty Aspose nie stanowią ryzyka dla kluczowych zasobów systemu. Ponadto, gdy komponent Aspose otwiera dokument, makra nie są uruchamiane automatycznie.

## **Zależności Maven**

Artefakt Maven dla Aspose.Slides for Java, `com.aspose:aspose-slides`, nie deklaruje zależności: jego plik POM zawiera tylko współrzędne samego artefaktu. Gdy dodasz go do projektu, Maven dodaje jedynie ten plik JAR i nic więcej. Aby wyświetlić wszystkie artefakty, które rozwiązuje Twój projekt, włącznie z zależnościami przechodnimi, uruchom to polecenie w folderze projektu:

```bash
mvn dependency:tree
```

W projekcie z [Installation](/slides/pl/java/installation/), wynik wymienia Aspose.Slides jako jedyną zależność:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **Weryfikacja pliku JAR**

Aspose podpisuje plik JAR. Aby sprawdzić podpis, uruchom narzędzie `jarsigner` z JDK w folderze, który zawiera plik JAR:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

Polecenie wypisuje `jar verified.` gdy podpis jest prawidłowy i żadna pozycja nie została zmieniona od czasu podpisania pliku. Ta wiadomość nie podaje nazwy podpisującego. Aby potwierdzić, że plik został podpisany przez Aspose, dodaj opcje `-verbose` i `-certs` oraz sprawdź, że certyfikat podpisującego jest wydany na `CN=ASPOSE PTY LTD`. Gdy Maven pobiera plik JAR, sprawdza również sumę kontrolną SHA-1 publikowaną w repozytorium obok pliku.

## **Komponenty firm trzecich**

Aspose.Slides for Java zawiera kod i dane z komponentów firm trzecich. Są one częścią pliku JAR, a nie oddzielnymi artefaktami Maven, więc `mvn dependency:tree` i inne narzędzia czytające zależności Maven nie wymieniają ich. Plik JAR zawiera informację *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*, w której wymieniono komponenty i ich licencje:

| Component | Licencja podana w informacji |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | licencja w stylu MIT |
| Mono | licencja MIT; niektóre części na innych licencjach wymienionych w informacji |
| RSWOP.ICM color profile | warunki licencji Microsoft |
| sRGB_v4_ICC_preference.icc color profile | zgoda ICC na użycie, kopiowanie i dystrybucję niezmienionego pliku |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

Aby wyodrębnić informację z pliku JAR, uruchom narzędzie `jar` z JDK w folderze, który zawiera plik JAR:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **FAQ**

**Czy Aspose.Slides for Java używa zewnętrznych pakietów?**

Nie ma zależności Maven, jak pokazuje sekcja [Maven Dependencies](#maven-dependencies), ale zawiera komponenty firm trzecich wymienione w [Third-Party Components](#third-party-components). Uwzględnij zarówno plik JAR, jak i te komponenty w przeglądzie bezpieczeństwa.

**Czy Aspose.Slides for Java wymaga dostępu do sieci?**

Nie. Tworzenie, zapisywanie i renderowanie prezentacji działa na systemie bez połączenia sieciowego. Jedyną funkcją, która wysyła dane do Aspose, jest [metered licensing](/slides/pl/java/metered-licensing/), która raportuje użycie API.

**Czy Aspose.Slides for Java zawiera kod natywny?**

Nie. Plik JAR zawiera wyłącznie klasy i zasoby Java, więc nie dodaje do aplikacji bibliotek natywnych. Na systemie Linux obsługa czcionek w środowisku Java wymaga biblioteki fontconfig oraz czcionek z systemu operacyjnego; zobacz [System Requirements](/slides/pl/java/system-requirements/#linux).
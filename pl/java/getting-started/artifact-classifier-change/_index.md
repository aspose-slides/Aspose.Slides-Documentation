---
title: Deklaracja
type: docs
weight: 60
url: /pl/java/artifact-classifier-change/
keywords:
- klasyfikator Aspose.Slides
- klasyfikator artefaktu
- użyj Aspose.Slides
- instalacja Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Aspose.Slides dla Javy teraz używa klasyfikatora jdk8 zamiast jdk16. Dowiedz się, dlaczego i jak zaktualizować swoje zależności."
---
## Zmiana klasyfikatora artefaktu z `jdk16` na `jdk8`

Od wersji **26.10** zmieniliśmy klasyfikator używany w naszych publikowanych artefaktach z **`jdk16`** (Java 6) na **`jdk8`** (Java 8).

### Co się zmieniło

| | Przed | Po |
|---|---|---|
| Klasyfikator | `jdk16` | `jdk8` |
| Minimalna wersja Java | Java 1.6 | Java 8 |

**Przed:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Po:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### Dlaczego wprowadziliśmy tę zmianę

Po wewnętrznym przeglądzie postanowiliśmy **zrezygnować z obsługi starszych wersji Java**, które nie przynosiły już wartości i aktywnie utrudniały utrzymanie. Java 8 została wybrana jako nowa, bezpieczna podstawa dla wszystkich odbiorców.

W ramach tego klasyfikator został zaktualizowany, aby odzwierciedlał rzeczywistą minimalną wspieraną wersję. Dostosowaliśmy się również do aktualnej konwencji nazewnictwa Oracle, w której produkt jest oficjalnie określany jako **JDK 8** (zamiast legacy formatu `1.8`).

### Co musisz zrobić

1. **Zaktualizuj klasyfikator** w deklaracjach zależności z `jdk16` na `jdk8`.

   **Maven:**
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle:**
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. **Zweryfikuj środowisko uruchomieniowe**, aby było Java 8 lub nowsze.

3. **Odśwież wszystkie pliki blokujące** lub pamięci podręczne zależności, które utrwalają stary klasyfikator.

### Uwaga dotycząca migracji: jdk16 i jdk8

Od wersji 26.10​ oba klasyfikatory jdk16 i jdk8 będą dostarczać pliki JAR zgodne z Java 8 (zbudowane ze źródłową/ docelową kompatybilnością ustawioną na Java 8).

- `jdk16` → będzie kontynuowany w publikacji dla kompatybilności wstecznej (istniejące integracje).
- `jdk8` → wprowadzony jako nowy preferowany klasyfikator dla środowisk Java 8.

⚠️ Uwaga: Ta faza podwójnej publikacji jest zaplanowana na zakończenie 31 marca 2027 r. Po tej dacie klasyfikator jdk16 zostanie wycofany, a jedynie jdk8 będzie wspierany.

### Uwagi dotyczące kompatybilności

- Klasyfikator `jdk16` **nie jest już publikowany** po **31 marca 2027 r.**.
- Jeśli nadal potrzebujesz wsparcia dla Java 1.6, pozostań na poprzedniej linii wersji głównej, aż będziesz w stanie przejść na migrację.

### Potrzebujesz pomocy?

Jeśli napotkasz problemy podczas migracji, skontaktuj się z [wsparciem Aspose](https://forum.aspose.com/) w celu uzyskania dalszej pomocy.
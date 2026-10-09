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
## **Zmiana klasyfikatora artefaktu z `jdk16` na `jdk8`**

Od wersji **26.10** zmieniliśmy klasyfikator używany w naszych publikowanych artefaktach z **`jdk16`** (Java 6) na **`jdk8`** (Java 8).

### **Co się zmieniło**

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

### **Dlaczego wprowadziliśmy tę zmianę**

Po wewnętrznym przeglądzie zdecydowaliśmy się **zrezygnować z obsługi starszych wersji Java**, które nie przynosiły już wartości i aktywnie utrudniały utrzymanie. Java 8 została wybrana jako nowa, bezpieczna podstawa dla wszystkich użytkowników.

W ramach tego klasyfikator został zaktualizowany, aby odzwierciedlał rzeczywistą minimalną wspieraną wersję. Dodatkowo dostosowaliśmy się do aktualnej konwencji nazewnictwa Oracle, gdzie produkt jest oficjalnie określany jako **JDK 8** (zamiast starszego formatu `1.8`).

### **Co musisz zrobić**

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

2. **Sprawdź, czy środowisko uruchomieniowe** jest Java 8 lub wyższe.

3. **Odśwież wszelkie pliki blokujące** lub pamięci podręczne zależności, które utrwalają stary klasyfikator.

### **Uwaga dotycząca migracji: jdk16 i jdk8**

Od wersji 26.10​ oba klasyfikatory jdk16 i jdk8 będą dostarczać JAR-y zgodne z Java 8 (zbudowane z ustawioną zgodnością źródła/docelową na Java 8).

 - `jdk16` → będzie nadal publikowany w celu zachowania kompatybilności wstecznej (istniejące integracje).
 - `jdk8` → wprowadzony jako nowy preferowany klasyfikator dla środowisk Java 8.

⚠️ Uwaga: Ta faza podwójnego publikowania jest planowana do zakończenia 31 marca 2027 r. Po tej dacie klasyfikator jdk16 zostanie wycofany, a jedynie jdk8 będzie wspierany.

### **Uwagi dotyczące kompatybilności**

- Klasyfikator `jdk16` **nie jest już publikowany** po **31 marca 2027**.
- Jeśli nadal potrzebujesz wsparcia dla Java 1.6, pozostań przy poprzedniej linii wersji głównej, aż będziesz mógł przeprowadzić migrację.

### **Potrzebujesz pomocy?**

Jeśli napotkasz problemy podczas migracji, skontaktuj się z [pomocą Aspose](https://forum.aspose.com/) po dalszą pomoc.
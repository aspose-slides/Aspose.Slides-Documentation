---
title: Zmiana klasyfikatora artefaktu
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

Począwszy od wersji **26.10**, zmieniliśmy klasyfikator używany w naszych publikowanych artefaktach z **`jdk16`** (Java 6) na **`jdk8`** (Java 8).

### **Co się zmieniło**

| | Poprzednio | Po zmianie |
|---|---|---|
| Klasyfikator | `jdk16` | `jdk8` |
| Minimalna wersja Java | Java 1.6 | Java 8 |

**Poprzednio:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Po zmianie:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **Dlaczego wprowadziliśmy tę zmianę**

Po wewnętrznej analizie zdecydowaliśmy się **zrezygnować z obsługi starszych wersji Java**, które nie przynosiły już korzyści i aktywnie utrudniały konserwację. Java 8 została wybrana jako nowa, bezpieczna podstawa dla wszystkich użytkowników.

W ramach tego klasyfikator został zaktualizowany, aby odzwierciedlał rzeczywistą minimalną obsługiwaną wersję. Dostosowaliśmy się również do bieżącej konwencji nazewnictwa Oracle, w której produkt jest oficjalnie określany jako **JDK 8** (zamiast starszego formatu `1.8`).

### **Co należy zrobić**

1. **Zaktualizuj klasyfikator** w swoich deklaracjach zależności z `jdk16` na `jdk8`.

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

2. **Sprawdź środowisko uruchomieniowe** jest Java 8 lub wyższa.

3. **Odśwież** wszystkie pliki blokad lub pamięci podręczne zależności, które określają stary klasyfikator.

### **Uwaga dotycząca migracji: jdk16 i jdk8**

Od wersji 26.10​ oba klasyfikatory jdk16 i jdk8 będą dostarczać pliki JAR zgodne z Java 8 (zbudowane z ustawioną zgodnością źródła/target na Java 8).

- `jdk16` → pozostaje publikowany w celu zachowania kompatybilności wstecz (istniejące integracje).
- `jdk8` → wprowadzony jako nowy preferowany klasyfikator dla środowisk Java 8.

⚠️ Uwaga: Ta faza podwójnego publikowania ma zakończyć się 31 marca 2027​. Po tej dacie klasyfikator jdk16 zostanie wycofany, a jedynie jdk8 będzie wspierany.

### **Uwagi dotyczące kompatybilności**

- `jdk16` klasyfikator **nie jest już publikowany** po **31 marca 2027**.
- Jeśli nadal potrzebujesz wsparcia dla Java 1.6, pozostaw poprzednią główną wersję do momentu migracji.

### **Potrzebujesz pomocy?**

Jeśli napotkasz problemy podczas migracji, skontaktuj się z [supportem Aspose](https://forum.aspose.com/) w celu uzyskania dalszej pomocy.
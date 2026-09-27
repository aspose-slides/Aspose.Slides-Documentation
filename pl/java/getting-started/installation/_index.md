---
title: Instalacja
type: docs
weight: 70
url: /pl/java/installation/
keywords:
- instalacja Aspose.Slides
- pobieranie Aspose.Slides
- korzystanie z Aspose.Slides
- instalacja Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zainstaluj Aspose.Slides for Java z repozytorium Maven firmy Aspose lub jako plik JAR, skonfiguruj wymagania wstępne dla Linuksa i sprawdź instalację za pomocą pierwszego programu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać Aspose.Slides for Java do projektu. Aspose.Slides for Java jest publikowany w własnym repozytorium Maven firmy Aspose, a nie w Maven Central, więc projekt Maven musi zadeklarować to repozytorium. Można także pobrać plik JAR i umieścić go samodzielnie na ścieżce klasy. Obie drogi kończą się krótkim programem, który potwierdza, że biblioteka działa.

Aspose.Slides for Java nie wymaga Microsoft PowerPoint. Programowo generuje niezbędne pliki prezentacji. Jednak aby wyświetlić wygenerowane prezentacje, może być potrzebny Microsoft PowerPoint lub inny przeglądarka prezentacji.

## **Wymagania wstępne**

- Zestaw Java Development Kit (JDK). Projekt i polecenia w tym artykule wymagają JDK 11 lub nowszego. W JDK 11 program sprawdzający instalację wypisuje ostrzeżenie zaczynające się od "WARNING: An illegal reflective access operation has occurred"; nie wpływa ono na wynik i można je zignorować.
- [Apache Maven](https://maven.apache.org/install.html), jeśli używasz ścieżki Maven.
- W Linuksie biblioteka fontconfig oraz co najmniej jedna zainstalowana czcionka. Zobacz [Linux](#linux).

## **Instalacja z repozytorium Maven**

Aspose udostępnia swoje biblioteki Java w własnym [repozytorium Maven](https://releases.aspose.com/java/repo/com/aspose/). Aby używać [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) w projekcie Maven, dodaj dwa wpisy do swojego *pom.xml*.

1. **Zadeklaruj repozytorium Maven Aspose**.

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Dodaj zależność Aspose.Slides for Java**.

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

Klasyfikator `jdk16` jest wymagany: wybiera on wersję Java SE biblioteki. Zamień `26.9` na najnowszą wersję wymienioną w [repozytorium](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Repozytorium publikuje plik sumy kontrolnej SHA‑1 obok każdego pliku JAR, który Maven weryfikuje przy pobieraniu biblioteki.

### **Sprawdź instalację**

Aby sprawdzić konfigurację w nowym projekcie:

1. Utwórz folder dla projektu i zapisz w nim ten *pom.xml*:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.9</version>
               <classifier>jdk16</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   Oprócz repozytorium i zależności, ten *pom.xml* określa wersję Java do kompilacji, podaje nazwę klasy, którą uruchamia `mvn exec:java`, oraz ustawia wersję wtyczki kompilatora, ponieważ starsza wtyczka używana domyślnie przez niektóre instalacje Maven ignoruje ustawienie `maven.compiler.release`.

2. Zapisz pierwszy przykład z [Create Presentations](/slides/pl/java/create-presentation/) jako *src/main/java/HelloSlides.java*.

3. W folderze projektu uruchom:

   ```bash
   mvn compile exec:java
   ```

Maven pobiera Aspose.Slides for Java, kompiluje program i go uruchamia. Program zapisuje *new_presentation.pptx* w folderze projektu.

## **Użycie pliku JAR bez Maven**

1. Pobierz *aspose-slides-26.9-jdk16.jar* z [folderu wersji](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) w repozytorium. Dla innej wersji otwórz jej folder w [repozytorium](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) i pobierz plik kończący się na *-jdk16.jar*.

2. Zapisz pierwszy przykład z [Create Presentations](/slides/pl/java/create-presentation/) jako *HelloSlides.java* w tym samym folderze co plik JAR.

3. W tym folderze uruchom:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

JDK kompiluje i uruchamia pojedynczy plik źródłowy, a program zapisuje *new_presentation.pptx* w folderze. W własnej aplikacji dodaj plik JAR do ścieżki klasy w swoim narzędziu do budowania lub IDE.

## **Linux**

Aspose.Slides for Java korzysta z obsługi czcionek Java, co w Linuksie wymaga biblioteki fontconfig oraz co najmniej jednej zainstalowanej czcionki. Bez nich zapisywanie prezentacji kończy się błędem "Fontconfig head is null, check your fonts or fonts configuration". Minimalne obrazy serwerowe i kontenerowe mogą nie mieć obu; oficjalny obraz kontenera Ubuntu, na przykład, nie zawiera żadnego z nich.

Na Debianie i Ubuntu to polecenie instaluje JDK, Maven, fontconfig i czcionki DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Czcionki używane w Twoich prezentacjach, lub ich odpowiednie zamienniki, muszą być również zainstalowane, aby tekst był renderowany poprawnie.

## **FAQ**

### Jak mogę zweryfikować, że Aspose.Slides jest prawidłowo zintegrowany?

Zbuduj swój projekt, utwórz pustą [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i zapisz ją pod nową nazwą. Jeśli plik zostanie utworzony bez wyrzucania wyjątków, biblioteka została pomyślnie zintegrowana.

### Jak mogę ograniczyć zużycie pamięci podczas przetwarzania dużych prezentacji?

Zwiększaj limity pamięci JVM tylko do niezbędnego poziomu i wywołuj [dispose](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#dispose--) na każdej instancji [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) w bloku `finally`, aby niezwłocznie zwolnić pamięć podręczną. Zapobiega to błędom braku pamięci i utrzymuje przewidywalne ogólne zużycie pamięci podczas operacji wsadowych.

### Czy mogę wykluczyć niechciane formaty eksportu, aby zmniejszyć ostateczny rozmiar JAR?

Obecne wydania Aspose.Slides są dostarczane jako jednorodna biblioteka, dlatego nie można wyłączyć konkretnych eksporterów, takich jak PDF czy SVG, w czasie budowania.
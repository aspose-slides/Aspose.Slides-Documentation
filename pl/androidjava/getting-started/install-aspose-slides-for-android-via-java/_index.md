---
title: Instalacja Aspose.Slides for Android via Java
type: docs
weight: 90
url: /pl/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- instalacja Aspose.Slides
- pobieranie Aspose.Slides
- używanie Aspose.Slides
- instalacja Aspose.Slides
- Gradle
- repozytorium Maven
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dodaj Aspose.Slides for Android via Java do projektu Android Studio przy użyciu Gradle z repozytorium Maven firmy Aspose lub dodaj plik JAR ręcznie."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać Aspose.Slides for Android via Java do projektu Android. Zalecanym sposobem jest pozwolenie Gradle'owi na pobranie biblioteki z repozytorium Maven firmy Aspose. Można także pobrać plik JAR i dodać go ręcznie do projektu.

Biblioteka nie jest publikowana w Maven Central ani w repozytorium Maven Google. Jest dostępna w własnym repozytorium Aspose, jako artefakt `aspose-slides` z klasyfikatorem `android.via.java`.

## **Instalacja z repozytorium Maven firmy Aspose**

### **Krok 1: Dodaj repozytorium**

Nowe projekty Android Studio deklarują swoje repozytoria w bloku `dependencyResolutionManagement` w pliku *settings.gradle.kts*, a Gradle odrzuca repozytoria dodawane w pliku budowania modułu. Dodaj poniższą linię `maven` do bloku `repositories` wewnątrz istniejącego bloku, zamiast wklejać drugi blok `dependencyResolutionManagement`:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

### **Krok 2: Dodaj zależność**

Dodaj bibliotekę do bloku `dependencies` w pliku budowania modułu aplikacji, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

Ostatnia część współrzędnych, `android.via.java`, to klasyfikator wybierający wersję Android biblioteki. Bez niego Gradle nie może znaleźć artefaktu.

Następnie zsynchronizuj projekt z plikami Gradle, aby Gradle pobrał bibliotekę.

### **Wybierz wersję**

Aspose.Slides for Android via Java nie jest budowany dla każdej wersji w repozytorium. Jego kompilacje są publikowane tylko dla niektórych wersji Aspose.Slides for Java, a wersja bez kompilacji Android nie zostanie znaleziona. Wybierz wersję wymienioną na [Aspose.Slides for Android via Java download page](https://releases.aspose.com/slides/pl/androidjava/).

### **Skrypty budowania Groovy**

Jeśli projekt używa skryptów budowania Groovy, dodaj linię `maven` do bloku `repositories` wewnątrz istniejącego bloku `dependencyResolutionManagement` w pliku *settings.gradle*:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

I dodaj zależność do *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **Dodaj plik JAR ręcznie**

Jeśli nie możesz używać repozytorium Maven, dodaj plik JAR do swojego projektu:

1. Pobierz plik JAR z katalogu wersji w [Aspose's Maven repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Dla wersji 26.9 plik to *aspose-slides-26.9-android.via.java.jar* w folderze *26.9*.
1. Skopiuj plik do folderu *app/libs* w swoim projekcie. Utwórz folder, jeśli nie istnieje.
1. Dodaj plik do bloku `dependencies` w *app/build.gradle.kts*, a następnie zsynchronizuj projekt:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Utwórz swoją pierwszą prezentację**

Po synchronizacji projektu kontynuuj z [Create Presentations](/slides/pl/androidjava/create-presentation/). Jej pierwszy przykład dodaje pole tekstowe do slajdu i zapisuje prezentację w prywatnym magazynie aplikacji, co nie wymaga uprawnień do przechowywania. Bez licencji Aspose.Slides dodaje znak wodny oceny do każdego zapisywanego slajdu; zobacz [Licensing](/slides/pl/androidjava/licensing/).

## **Wersjonowanie**

Od 2018 roku wersjonowanie Aspose.Slides for Android via Java jest zgodne z wersjonowaniem Aspose.Slides for Java. Kompilacje Android nie są publikowane dla każdej wersji Java; zobacz [Choose a Version](#choose-a-version).

## **FAQ**

### Jak mogę zweryfikować, że Aspose.Slides jest poprawnie zintegrowany?

Zbuduj projekt, utwórz pustą [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i zapisz ją pod nową nazwą. Jeśli plik zostanie utworzony bez wyjątków, biblioteka została pomyślnie zintegrowana.

### Jak mogę ograniczyć zużycie pamięci podczas przetwarzania dużych prezentacji?

Wywołaj metodę [dispose](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#dispose--) każdego obiektu [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) w bloku `finally`, aby szybko zwolnić jego zasoby, i przetwarzaj jedną dużą prezentację na raz. Pomaga to zapobiegać błędom braku pamięci i utrzymuje przewidywalne zużycie pamięci podczas operacji wsadowych.

### Czy mogę wykluczyć niechciane formaty eksportu, aby zmniejszyć ostateczny rozmiar JAR?

Obecne wydania Aspose.Slides są dostarczane jako jednorazowa monolityczna biblioteka, więc nie można wyłączyć konkretnych eksporterów, takich jak PDF czy SVG, w czasie kompilacji.
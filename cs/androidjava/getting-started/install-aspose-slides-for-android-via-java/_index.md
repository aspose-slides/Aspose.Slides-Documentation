---
title: Instalace Aspose.Slides pro Android via Java
type: docs
weight: 90
url: /cs/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- instalovat Aspose.Slides
- stáhnout Aspose.Slides
- použít Aspose.Slides
- instalace Aspose.Slides
- Gradle
- Maven úložiště
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přidejte Aspose.Slides for Android via Java do projektu Android Studio pomocí Gradle z Maven úložiště Aspose, nebo přidejte soubor JAR ručně."
---
## **Přehled**

Tento článek vysvětluje, jak přidat Aspose.Slides for Android via Java do Android projektu. Doporučený způsob je nechat Gradle stáhnout knihovnu z Maven úložiště Aspose. Můžete si také stáhnout soubor JAR a přidat jej do projektu ručně.

Knihovna není publikována v Maven Central ani v Maven úložišti Google. Je dostupná pouze v úložišti Aspose jako artefakt `aspose-slides` s klasifikátorem `android.via.java`.

## **Instalace z Maven úložiště Aspose**

### **Krok 1: Přidání úložiště**

Nové projekty Android Studio deklarují svá úložiště v bloku `dependencyResolutionManagement` souboru *settings.gradle.kts* a Gradle odmítá úložiště, která přidá soubor sestavení modulu. Přidejte řádek `maven` uvedený níže do bloku `repositories` uvnitř tohoto existujícího bloku, místo abyste vkládali druhý blok `dependencyResolutionManagement`:

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

### **Krok 2: Přidání závislosti**

Přidejte knihovnu do bloku `dependencies` souboru sestavení modulu aplikace, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

Poslední část koordinát, `android.via.java`, je klasifikátor, který vybírá Android verzi knihovny. Bez ní Gradle nemůže artefakt najít.

Poté synchronizujte projekt s Gradle soubory, aby Gradle stáhl knihovnu.

### **Vyberte verzi**

Aspose.Slides for Android via Java není postavena pro každou verzi v úložišti. Její sestavení jsou publikována jen pro některé verze Aspose.Slides for Java a verze bez Android sestavení se nepodaří vyřešit. Vyberte verzi uvedenou na [stránce ke stažení Aspose.Slides for Android via Java](https://releases.aspose.com/slides/cs/androidjava/).

### **Skripty sestavení v Groovy**

Pokud váš projekt používá skripty sestavení v Groovy, přidejte řádek `maven` do bloku `repositories` uvnitř existujícího bloku `dependencyResolutionManagement` souboru *settings.gradle*:

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

A přidejte závislost do *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **Manuální přidání souboru JAR**

1. Stáhněte soubor JAR ze složky konkrétní verze v [Maven úložišti Aspose](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Pro verzi 26.9 je soubor *aspose-slides-26.9-android.via.java.jar* ve složce *26.9*.
2. Zkopírujte soubor do složky *app/libs* ve vašem projektu. Vytvořte složku, pokud neexistuje.
3. Přidejte soubor do bloku `dependencies` souboru *app/build.gradle.kts*, pak projekt synchronizujte:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Vytvoření první prezentace**

Po synchronizaci projektu pokračujte na [Vytvoření prezentací](/slides/cs/androidjava/create-presentation/). První příklad přidá textové pole do snímku a uloží prezentaci do soukromého úložiště aplikace, což nevyžaduje oprávnění k úložišti. Bez licence Aspose.Slides přidá do každého uloženého snímku evaluační vodoznak; viz [Licencování](/slides/cs/androidjava/licensing/).

## **Verzování**

Od roku 2018 se verzování Aspose.Slides for Android via Java řídí verzováním Aspose.Slides for Java. Android verze nejsou publikovány pro každou verzi Javy; viz [Vyberte verzi](#choose-a-version).

## **Často kladené otázky**

### Jak mohu ověřit, že je Aspose.Slides integrováno správně?

Sestavte svůj projekt, vytvořte prázdnou [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) a uložte ji pod novým názvem. Pokud je soubor vytvořen bez vyhození výjimek, knihovna byla úspěšně integrována.

### Jak mohu omezit spotřebu paměti při zpracování velkých prezentací?

Zavolejte metodu [dispose](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#dispose--) každé instance [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) v bloku `finally`, aby se její prostředky okamžitě uvolnily, a zpracovávejte po jedné velké prezentaci. To pomáhá předcházet chybám nedostatku paměti a udržuje celkovou spotřebu paměti předvídatelnou během dávkových operací.

### Mohu vyloučit nežádoucí exportní formáty, aby se zmenšila konečná velikost JAR?

Aktuální vydání Aspose.Slides jsou distribuována jako jediná monolitická knihovna, takže nelze při sestavení zakázat konkrétní exportéry, jako je PDF nebo SVG.
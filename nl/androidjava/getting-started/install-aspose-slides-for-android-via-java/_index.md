---
title: Installeer Aspose.Slides voor Android via Java
type: docs
weight: 90
url: /nl/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- installeer Aspose.Slides
- download Aspose.Slides
- gebruik Aspose.Slides
- Aspose.Slides installatie
- Gradle
- Maven-repository
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Voeg Aspose.Slides for Android via Java toe aan een Android Studio-project met Gradle vanuit de Maven-repository van Aspose, of voeg het JAR-bestand handmatig toe."
---
## **Overzicht**

Dit artikel legt uit hoe je Aspose.Slides for Android via Java toevoegt aan een Android‑project. De aanbevolen manier is om Gradle de bibliotheek uit de Maven‑repo van Aspose te laten downloaden. Je kunt ook het JAR‑bestand downloaden en handmatig aan je project toevoegen.

De bibliotheek wordt niet gepubliceerd naar Maven Central of de Maven‑repo van Google. Hij is beschikbaar via de eigen repository van Aspose, als het `aspose-slides`‑artifact met de `android.via.java`‑classifier.

## **Installeren vanuit de Maven‑repository van Aspose**

### **Stap 1: Voeg de repository toe**

Nieuwe Android‑Studio‑projecten declareren hun repositories in het `dependencyResolutionManagement`‑blok van *settings.gradle.kts*, en Gradle weigert repositories die een module‑build‑bestand toevoegt. Voeg de onderstaande `maven`‑regel toe aan het `repositories`‑blok binnen dat bestaande blok, in plaats van een tweede `dependencyResolutionManagement`‑blok te plakken:

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

### **Stap 2: Voeg de afhankelijkheid toe**

Voeg de bibliotheek toe aan het `dependencies`‑blok van het build‑bestand van de app‑module, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

Het laatste deel van de coördinaten, `android.via.java`, is de classifier die de Android‑build van de bibliotheek selecteert. Zonder deze kan Gradle het artifact niet vinden.

Synchroniseer vervolgens het project met de Gradle‑bestanden, zodat Gradle de bibliotheek downloadt.

### **Kies een versie**

Aspose.Slides for Android via Java wordt niet voor elke versie in de repository gebouwd. De builds worden alleen gepubliceerd voor bepaalde Aspose.Slides for Java‑versies, en een versie zonder Android‑build kan niet worden gevonden. Kies een versie die vermeld staat op de [Aspose.Slides for Android via Java downloadpagina](https://releases.aspose.com/slides/androidjava/).

### **Groovy‑build‑scripts**

Als je project Groovy‑build‑scripts gebruikt, voeg dan de `maven`‑regel toe aan het `repositories`‑blok binnen het bestaande `dependencyResolutionManagement`‑blok van *settings.gradle*:

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

En voeg de afhankelijkheid toe aan *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **JAR‑bestand handmatig toevoegen**

Als je geen Maven‑repository kunt gebruiken, voeg dan het JAR‑bestand toe aan je project:

1. Download het JAR‑bestand uit de map van de versie in de [Maven‑repository van Aspose](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Voor versie 26.9 is het bestand *aspose-slides-26.9-android.via.java.jar* in de map *26.9*.
1. Kopieer het bestand naar de map *app/libs* van je project. Maak de map aan als deze nog niet bestaat.
1. Voeg het bestand toe aan het `dependencies`‑blok van *app/build.gradle.kts*, en synchroniseer vervolgens het project:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Maak je eerste presentatie**

Na het synchroniseren van het project ga je verder met [Presentaties maken](/slides/nl/androidjava/create-presentation/). Het eerste voorbeeld voegt een tekstvak toe aan een dia en slaat de presentatie op in de private opslag van je app, waardoor geen opslag‑toestemming nodig is. Zonder licentie voegt Aspose.Slides een evaluatiewatermerk toe aan elke dia die wordt opgeslagen; zie [Licenties](/slides/nl/androidjava/licensing/).

## **Versiebeheer**

Vanaf 2018 volgt de versiebeheer van Aspose.Slides for Android via Java de versiebeheer van Aspose.Slides for Java. Android‑builds worden niet gepubliceerd voor elke Java‑versie; zie [Kies een versie](#choose-a-version).

## **FAQ**

### Hoe kan ik verifiëren dat Aspose.Slides correct is geïntegreerd?

Bouw je project, instantiate een lege [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) en sla deze op onder een nieuwe naam. Als het bestand wordt aangemaakt zonder dat er uitzonderingen worden gegooid, is de bibliotheek succesvol geïntegreerd.

### Hoe kan ik het geheugengebruik beperken bij het verwerken van grote presentaties?

Roep de [dispose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#dispose--)‑methode van elke [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) instantie aan in een `finally`‑block om haar resources direct vrij te geven, en verwerk één grote presentatie tegelijk. Dit helpt om out‑of‑memory‑fouten te voorkomen en houdt het totale geheugengebruik voorspelbaar tijdens batch‑operaties.

### Kan ik ongewenste exportformaten uitsluiten om de uiteindelijke JAR‑grootte te verkleinen?

Huidige Aspose.Slides‑releases worden geleverd als één monolithische bibliotheek, dus je kunt specifieke exporteurs zoals PDF of SVG niet uitschakelen tijdens het bouwen.
---
title: Installera Aspose.Slides för Android via Java
type: docs
weight: 90
url: /sv/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- installera Aspose.Slides
- ladda ner Aspose.Slides
- använd Aspose.Slides
- Aspose.Slides-installation
- Gradle
- Maven-arkiv
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Lägg till Aspose.Slides för Android via Java i ett Android Studio-projekt med Gradle från Aspose's Maven-arkiv, eller lägg till JAR-filen manuellt."
---
## **Översikt**

Den här artikeln förklarar hur man lägger till Aspose.Slides for Android via Java i ett Android‑projekt. Det rekommenderade sättet är att låta Gradle ladda ner biblioteket från Asposes Maven‑arkiv. Du kan också ladda ner JAR‑filen och lägga till den i ditt projekt manuellt.

Biblioteket publiceras inte i Maven Central eller Googles Maven‑arkiv. Det finns tillgängligt i Asposes eget arkiv, som artefakten `aspose-slides` med klassificeraren `android.via.java`.

## **Installera från Asposes Maven‑arkiv**

### **Steg 1: Lägg till arkivet**

Nya Android‑Studio‑projekt deklarerar sina arkiv i `dependencyResolutionManagement`‑blocket i *settings.gradle.kts*, och Gradle avvisar arkiv som en modulens byggfil lägger till. Lägg till `maven`‑raden som visas nedan i `repositories`‑blocket inom det befintliga blocket, istället för att klistra in ett andra `dependencyResolutionManagement`‑block:

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

### **Steg 2: Lägg till beroendet**

Lägg till biblioteket i `dependencies`‑blocket i app‑modulens byggfil, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

Den sista delen av koordinaterna, `android.via.java`, är klassificeraren som väljer Android‑byggnaden av biblioteket. Utan den kan Gradle inte hitta artefakten.

Synkronisera sedan projektet med Gradle‑filerna så att Gradle laddar ner biblioteket.

### **Välj en version**

Aspose.Slides for Android via Java byggs inte för varje version i arkivet. Dess byggnader publiceras endast för vissa Aspose.Slides for Java‑versioner, och en version utan Android‑byggnad kan inte lösas. Välj en version som listas på [Aspose.Slides for Android via Java nedladdningssida](https://releases.aspose.com/slides/androidjava/).

### **Groovy‑byggskript**

Om ditt projekt använder Groovy‑byggskript, lägg till `maven`‑raden i `repositories`‑blocket inom det befintliga `dependencyResolutionManagement`‑blocket i *settings.gradle*:

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

Och lägg till beroendet i *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **Lägg till JAR‑filen manuellt**

Om du inte kan använda ett Maven‑arkiv, lägg till JAR‑filen i ditt projekt:

1. Ladda ner JAR‑filen från versionens mapp i [Asposes Maven‑arkiv](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). För version 26.9 är filen *aspose-slides-26.9-android.via.java.jar* i mappen *26.9*.
2. Kopiera filen till *app/libs*-mappen i ditt projekt. Skapa mappen om den inte finns.
3. Lägg till filen i `dependencies`‑blocket i *app/build.gradle.kts*, och synkronisera sedan projektet:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Skapa din första presentation**

När projektet har synkroniserats, fortsätt med [Create Presentations](/slides/sv/androidjava/create-presentation/). Dess första exempel lägger till en textruta på en bild och sparar presentationen i appens privata lagring, vilket inte kräver lagringsbehörighet. Utan licens lägger Aspose.Slides till ett utvärderingsvattenmärke på varje bild som sparas; se [Licensing](/slides/sv/androidjava/licensing/).

## **Versionering**

Sedan 2018 har versioneringen av Aspose.Slides for Android via Java följt Aspose.Slides for Java. Android‑byggnader publiceras inte för varje Java‑version; se [Choose a Version](#choose-a-version).

## **FAQ**

### Hur kan jag verifiera att Aspose.Slides är korrekt integrerat?

Bygg ditt projekt, skapa en tom [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) och spara den under ett nytt namn. Om filen skapas utan att kasta undantag har biblioteket integrerats framgångsrikt.

### Hur kan jag begränsa minnesanvändningen när jag behandlar stora presentationer?

Anropa metoden [dispose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#dispose--) för varje [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)-instans i ett `finally`‑block för att snabbt frigöra dess resurser, och behandla en stor presentation åt gången. Detta hjälper till att förhindra out‑of‑memory‑fel och håller den totala minnesanvändningen förutsägbar under batch‑operationer.

### Kan jag exkludera oönskade exportformat för att minska den slutliga JAR‑storleken?

Aktuella Aspose.Slides‑utgåvor levereras som ett enda monolitiskt bibliotek, så du kan inte inaktivera specifika exportörer som PDF eller SVG vid byggtiden.
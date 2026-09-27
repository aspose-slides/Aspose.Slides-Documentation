---
title: Aspose.Slides für Android via Java installieren
type: docs
weight: 90
url: /de/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- Aspose.Slides installieren
- Aspose.Slides herunterladen
- Aspose.Slides verwenden
- Aspose.Slides Installation
- Gradle
- Maven-Repository
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Fügen Sie Aspose.Slides für Android via Java zu einem Android-Studio-Projekt mit Gradle aus Asposes Maven-Repository hinzu oder fügen Sie die JAR-Datei manuell hinzu."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides for Android via Java zu einem Android‑Projekt hinzugefügt wird. Empfohlen wird, Gradle das Herunterladen der Bibliothek aus Asposes Maven‑Repository zu überlassen. Sie können die JAR‑Datei auch herunterladen und manuell zu Ihrem Projekt hinzufügen.

Die Bibliothek ist nicht im Maven Central oder im Google Maven‑Repository veröffentlicht. Sie ist im eigenen Repository von Aspose verfügbar, als `aspose-slides`‑Artefakt mit dem Klassifizierer `android.via.java`.

## **Installation aus dem Maven‑Repository von Aspose**

### **Schritt 1: Repository hinzufügen**

Neue Android‑Studio‑Projekte deklarieren ihre Repositories im `dependencyResolutionManagement`‑Block von *settings.gradle.kts*, und Gradle verwirft Repositories, die eine Modul‑Build‑Datei hinzufügt. Fügen Sie die unten gezeigte `maven`‑Zeile zum `repositories`‑Block innerhalb dieses vorhandenen Blocks hinzu, anstatt einen zweiten `dependencyResolutionManagement`‑Block einzufügen:

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

### **Schritt 2: Abhängigkeit hinzufügen**

Fügen Sie die Bibliothek zum `dependencies`‑Block der Build‑Datei des App‑Moduls, *app/build.gradle.kts*, hinzu:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

Der letzte Teil der Koordinaten, `android.via.java`, ist der Klassifizierer, der den Android‑Build der Bibliothek auswählt. Ohne ihn kann Gradle das Artefakt nicht finden.

Synchronisieren Sie anschließend das Projekt mit den Gradle‑Dateien, sodass Gradle die Bibliothek herunterlädt.

### **Version auswählen**

Aspose.Slides for Android via Java wird nicht für jede Version im Repository gebaut. Die Builds werden nur für einige Aspose.Slides‑Versionen für Java veröffentlicht, und eine Version ohne Android‑Build lässt sich nicht auflösen. Wählen Sie eine Version, die auf der [Aspose.Slides for Android via Java‑Download‑Seite](https://releases.aspose.com/slides/de/androidjava/) aufgeführt ist.

### **Groovy‑Buildskripte**

Verwendet Ihr Projekt Groovy‑Buildskripte, fügen Sie die `maven`‑Zeile zum `repositories`‑Block innerhalb des vorhandenen `dependencyResolutionManagement`‑Blocks von *settings.gradle* hinzu:

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

Und fügen Sie die Abhängigkeit zu *app/build.gradle* hinzu:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **JAR‑Datei manuell hinzufügen**

Falls Sie kein Maven‑Repository verwenden können, fügen Sie die JAR‑Datei manuell zu Ihrem Projekt hinzu:

1. Laden Sie die JAR‑Datei aus dem Versionsordner im [Aspose Maven‑Repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) herunter. Für Version 26.9 heißt die Datei *aspose-slides-26.9-android.via.java.jar* im Ordner *26.9*.
1. Kopieren Sie die Datei in den Ordner *app/libs* Ihres Projekts. Erstellen Sie den Ordner, falls er nicht existiert.
1. Fügen Sie die Datei zum `dependencies`‑Block von *app/build.gradle.kts* hinzu und synchronisieren Sie das Projekt:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Erste Präsentation erstellen**

Nachdem das Projekt synchronisiert wurde, fahren Sie mit [Create Presentations](/slides/de/androidjava/create-presentation/) fort. Das erste Beispiel fügt einer Folie ein Textfeld hinzu und speichert die Präsentation im privaten Speicher Ihrer App, ohne dass eine Speicherberechtigung erforderlich ist. Ohne Lizenz fügt Aspose.Slides jedem gespeicherten Folienblatt ein Evaluierungs‑Wasserzeichen ein; siehe [Licensing](/slides/de/androidjava/licensing/).

## **Versionierung**

Seit 2018 entspricht die Versionierung von Aspose.Slides for Android via Java der von Aspose.Slides for Java. Android‑Builds werden nicht für jede Java‑Version veröffentlicht; siehe [Version auswählen](#choose-a-version).

## **FAQ**

### Wie kann ich überprüfen, ob Aspose.Slides korrekt integriert ist?

Bauen Sie Ihr Projekt, erstellen Sie eine leere [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) und speichern Sie sie unter einem neuen Namen. Wenn die Datei ohne Ausnahmen erstellt wird, wurde die Bibliothek erfolgreich integriert.

### Wie kann ich den Speicherverbrauch bei der Verarbeitung großer Präsentationen begrenzen?

Rufen Sie die [dispose](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#dispose--)‑Methode jeder [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)-Instanz in einem `finally`‑Block auf, um deren Ressourcen sofort freizugeben, und verarbeiten Sie jeweils nur eine große Präsentation. Das hilft, Out‑of‑Memory‑Fehler zu verhindern und den Gesamtspeicherverbrauch während Batch‑Operationen vorhersehbar zu halten.

### Kann ich unerwünschte Exportformate ausschließen, um die endgültige JAR‑Größe zu verkleinern?

Aktuelle Aspose.Slides‑Releases werden als ein einziges monolithisches Bibliothekspaket ausgeliefert, sodass Sie bestimmte Exporter wie PDF oder SVG nicht zur Build‑Zeit deaktivieren können.
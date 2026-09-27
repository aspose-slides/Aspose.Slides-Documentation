---
title: Install Aspose.Slides for Android via Java
type: docs
weight: 90
url: /androidjava/install-aspose-slides-for-android-via-java/
keywords:
- install Aspose.Slides
- download Aspose.Slides
- use Aspose.Slides
- Aspose.Slides installation
- Gradle
- Maven repository
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Add Aspose.Slides for Android via Java to an Android Studio project with Gradle from Aspose's Maven repository, or add the JAR file manually."
---

## **Overview**

This article explains how to add Aspose.Slides for Android via Java to an Android project. The recommended way is to let Gradle download the library from Aspose's Maven repository. You can also download the JAR file and add it to your project manually.

The library is not published to Maven Central or Google's Maven repository. It is available from Aspose's own repository, as the `aspose-slides` artifact with the `android.via.java` classifier.

## **Install from Aspose's Maven Repository**

### **Step 1: Add the Repository**

New Android Studio projects declare their repositories in the `dependencyResolutionManagement` block of *settings.gradle.kts*, and Gradle rejects repositories that a module's build file adds. Add the `maven` line shown below to the `repositories` block inside that existing block, rather than pasting a second `dependencyResolutionManagement` block:

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

### **Step 2: Add the Dependency**

Add the library to the `dependencies` block of the app module's build file, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

The last part of the coordinates, `android.via.java`, is the classifier that selects the Android build of the library. Without it, Gradle cannot find the artifact.

Then sync the project with the Gradle files, so that Gradle downloads the library.

### **Choose a Version**

Aspose.Slides for Android via Java is not built for every version in the repository. Its builds are published for some Aspose.Slides for Java versions only, and a version without an Android build fails to resolve. Pick a version listed on the [Aspose.Slides for Android via Java download page](https://releases.aspose.com/slides/androidjava/).

### **Groovy Build Scripts**

If your project uses Groovy build scripts, add the `maven` line to the `repositories` block inside the existing `dependencyResolutionManagement` block of *settings.gradle*:

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

And add the dependency to *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **Add the JAR File Manually**

If you cannot use a Maven repository, add the JAR file to your project:

1. Download the JAR file from the version's folder in [Aspose's Maven repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). For version 26.9, the file is *aspose-slides-26.9-android.via.java.jar* in the *26.9* folder.
1. Copy the file into the *app/libs* folder of your project. Create the folder if it does not exist.
1. Add the file to the `dependencies` block of *app/build.gradle.kts*, then sync the project:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Create Your First Presentation**

After the project syncs, continue with [Create Presentations](/slides/androidjava/create-presentation/). Its first example adds a text box to a slide and saves the presentation to your app's private storage, which needs no storage permission. Without a license, Aspose.Slides adds an evaluation watermark to every slide it saves; see [Licensing](/slides/androidjava/licensing/).

## **Versioning**

Since 2018, the versioning of Aspose.Slides for Android via Java has complied with Aspose.Slides for Java. Android builds are not published for every Java version; see [Choose a Version](#choose-a-version).

## **FAQ**

### How can I verify that Aspose.Slides is integrated correctly?

Build your project, instantiate a blank [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) and save it under a new name. If the file is created without throwing exceptions, the library has been integrated successfully.

### How can I limit memory consumption when processing large presentations?

Call the [dispose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#dispose--) method of each [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) instance in a `finally` block to release its resources promptly, and process one large presentation at a time. This helps prevent out-of-memory errors and keeps overall memory usage predictable during batch operations.

### Can I exclude unwanted export formats to shrink the final JAR size?

Current Aspose.Slides releases are shipped as a single monolithic library, so you cannot disable specific exporters such as PDF or SVG at build time.

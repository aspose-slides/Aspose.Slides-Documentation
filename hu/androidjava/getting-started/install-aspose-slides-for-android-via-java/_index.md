---
title: Aspose.Slides for Android via Java telepítése
type: docs
weight: 90
url: /hu/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- Aspose.Slides telepítése
- Aspose.Slides letöltése
- Aspose.Slides használata
- Aspose.Slides telepítése
- Gradle
- Maven tároló
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Adja hozzá az Aspose.Slides for Android via Java-t egy Android Studio projekthez Gradle segítségével az Aspose Maven tárolójából, vagy adja hozzá a JAR fájlt manuálisan."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatja hozzá az Aspose.Slides for Android via Java-t egy Android projekthez. Az ajánlott mód az, hogy a Gradle letölti a könyvtárat az Aspose Maven tárolójából. A JAR fájlt is letöltheti, és manuálisan hozzáadhatja a projekthez.

A könyvtár nincs közzétéve a Maven Central vagy a Google Maven tárolójában. Az Aspose saját tárolójából érhető el, `aspose-slides` artefaktként az `android.via.java` osztályozóval.

## **Telepítés az Aspose Maven tárolójából**

### **1. lépés: Tároló hozzáadása**

Az új Android Studio projektek a tárolóikat a `dependencyResolutionManagement` blokkban deklarálják a *settings.gradle.kts* fájlban, és a Gradle elutasítja azokat a tárolókat, amelyeket egy modul build fájlja ad hozzá. A meglévő blokk `repositories` részéhez adja hozzá az alább látható `maven` sort, ahelyett, hogy egy második `dependencyResolutionManagement` blokkot illesztene be:

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

### **2. lépés: Függőség hozzáadása**

Adja hozzá a könyvtárat az alkalmazásmodul build fájljának `dependencies` blokkjához, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

A koordináták utolsó része, `android.via.java`, a klasszifikátor, amely kiválasztja a könyvtár Android változatát. Enélkül a Gradle nem találja az artefaktot.

Ezután szinkronizálja a projektet a Gradle fájlokkal, hogy a Gradle letöltse a könyvtárat.

### **Verzió kiválasztása**

Az Aspose.Slides for Android via Java nem minden verzióra épül a tárolóban. A buildjei csak néhány Aspose.Slides for Java verzióhoz vannak kiadva, és egy Android build nélküli verzió feloldása sikertelen. Válasszon ki egy verziót a [Aspose.Slides for Android via Java letöltési oldalon](https://releases.aspose.com/slides/hu/androidjava/).

### **Groovy build script-ek**

Ha a projekt Groovy build script-eket használ, adja hozzá a `maven` sort a meglévő `dependencyResolutionManagement` blokk `repositories` részéhez a *settings.gradle* fájlban:

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

És adja hozzá a függőséget az *app/build.gradle* fájlhoz:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **A JAR fájl manuális hozzáadása**

Ha nem tud Maven tárolót használni, adja hozzá a JAR fájlt a projekthez:

1. Töltse le a JAR fájlt a verzió mappájából az [Aspose Maven tárolóban](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). A 26.9-es verzió esetén a fájl neve *aspose-slides-26.9-android.via.java.jar* a *26.9* mappában.
2. Másolja a fájlt a projekt *app/libs* mappájába. Ha a mappa nem létezik, hozza létre.
3. Adja hozzá a fájlt a `dependencies` blokkhoz az *app/build.gradle.kts* fájlban, majd szinkronizálja a projektet:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Az első prezentáció létrehozása**

A projekt szinkronizálása után folytassa a [Create Presentations](/slides/hu/androidjava/create-presentation/) cikkel. Az első példája egy szövegdobozt ad egy diára, és a prezentációt az alkalmazás privát tárhelyére menti, amelyhez nem szükséges tárolási engedély. Licenc nélkül az Aspose.Slides minden mentett diára értékelési vízjelet helyez; lásd a [Licensing](/slides/hu/androidjava/licensing/) oldalt.

## **Verziókezelés**

2018 óta az Aspose.Slides for Android via Java verziókezelése összhangban van az Aspose.Slides for Java verziókkal. Android build-ek nem minden Java verzióhoz kerülnek kiadásra; lásd a [Verzió kiválasztása](#choose-a-version) részt.

## **GYIK**

### Hogyan ellenőrizhetem, hogy az Aspose.Slides helyesen integrálva van?

Építse fel a projektet, hozzon létre egy üres [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt, és mentse el egy új név alatt. Ha a fájl kivétel dobása nélkül jön létre, a könyvtár sikeresen integrálva lett.

### Hogyan korlátozhatom a memóriafelhasználást nagy prezentációk feldolgozásakor?

Hívja meg minden [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példány `dispose` módszerét egy `finally` blokkban, hogy a erőforrások gyorsan felszabaduljanak, és egyszerre csak egy nagy prezentációt dolgozzon fel. Ez segít megakadályozni a memóriahiány hibákat, és előre láthatóvá teszi a memóriahasználatot kötegelt műveletek során.

### Kizárhatok nem kívánt exportformátumokat a végső JAR méretének csökkentéséhez?

A jelenlegi Aspose.Slides kiadások egyetlen monolitikus könyvtárként kerülnek szállításra, ezért a build időben nem tiltható le például a PDF vagy SVG exportálás.
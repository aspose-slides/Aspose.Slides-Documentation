---
title: Telepítés
type: docs
weight: 70
url: /hu/java/installation/
keywords:
- Aspose.Slides telepítése
- Aspose.Slides letöltése
- Aspose.Slides használata
- Aspose.Slides telepítése
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Telepítse az Aspose.Slides for Java-t az Aspose Maven tárolójából vagy JAR fájlként, állítsa be a Linux előfeltételeket, és ellenőrizze a telepítést egy első programmal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet hozzáadni az Aspose.Slides for Java‑t egy projekthez. Az Aspose.Slides for Java az Aspose saját Maven tárolójában kerül közzétételre, nem a Maven Centralben, ezért egy Maven projektnek fel kell tüntetnie ezt a tárolót. Letöltheti a JAR fájlt, és saját maga helyezheti a classpath‑ra. Mindkét útvonal egy rövid programmal végződik, amely megerősíti, hogy a könyvtár működik.

Az Aspose.Slides for Java nem igényel Microsoft PowerPoint‑ot. Programból generálja a szükséges prezentációs fájlokat. A generált prezentációk megtekintéséhez azonban szükség lehet a Microsoft PowerPoint‑ra vagy egy másik prezentációs megjelenítőre.

## **Előfeltételek**

- Egy Java Development Kit (JDK). A projekt és a cikkben szereplő parancsok JDK 11 vagy újabb verziót igényelnek. JDK 11 esetén a telepítést ellenőrző program figyelmeztetést ír ki, amely így kezdődik: "WARNING: An illegal reflective access operation has occurred"; ez nem befolyásolja az eredményt, és figyelmen kívül hagyható.
- [Apache Maven](https://maven.apache.org/install.html), ha Maven útvonalat használ.
- Linuxon a fontconfig könyvtár és legalább egy telepített betűtípus szükséges. Lásd [Linux](#linux).

## **Telepítés a Maven tárolóból**

Az Aspose a Java könyvtárait saját [Maven tárolójában](https://releases.aspose.com/java/repo/com/aspose/) helyezi el. A [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) Maven projektben való használatához adjon hozzá két bejegyzést a *pom.xml*-hez.

1. **Az Aspose Maven tároló deklarálása.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Az Aspose.Slides for Java függőség hozzáadása.**

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

A `jdk16` osztályozó kötelező: a könyvtár Java SE változatát választja ki. Cserélje ki a `26.9` értéket a [tárolóban](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) szereplő legújabb verzióra. A tároló minden JAR mellé egy SHA‑1 ellenőrzőösszeg fájlt is közzétét, amelyet a Maven a letöltés során ellenőriz.

### **Ellenőrizze a telepítést**

Új projekttel a beállítás ellenőrzéséhez:

1. Hozzon létre egy mappát a projekthez, és mentse el ebbe a *pom.xml*-t:

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

   A tároló és a függőség mellett ez a *pom.xml* beállítja a lefordítani kívánt Java kiadást, megadja a `mvn exec:java` által futtatott osztályt, és rögzíti a fordító‑plugint, mert a régebbi plugin, amelyet egyes Maven telepítések alapértelmezés szerint használnak, figyelmen kívül hagyja a `maven.compiler.release` beállítást.

2. Mentse el az első példát a [Prezentációk létrehozása](/slides/hu/java/create-presentation/) útvonalon *src/main/java/HelloSlides.java*‑ként.

3. A projekt mappájában futtassa:

   ```bash
   mvn compile exec:java
   ```

A Maven letölti az Aspose.Slides for Java‑t, lefordítja a programot, és futtatja. A program elmenti a *new_presentation.pptx*-t a projekt mappájába.

## **A JAR fájl használata Maven nélkül**

1. Töltse le a *aspose-slides-26.9-jdk16.jar*-t a [verzió mappából](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) a tárolóban. Más verzióhoz nyissa meg annak mappáját a [tárolóban](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), és töltse le a *-jdk16.jar* végződésű fájlt.

2. Mentse el az első példát a [Prezentációk létrehozása](/slides/hu/java/create-presentation/) útvonalon *HelloSlides.java*‑ként ugyanabban a mappában, ahol a JAR fájl található.

3. Ebben a mappában futtassa:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

A JDK lefordítja és futtatja az egyetlen forrásfájlt, a program elmenti a *new_presentation.pptx*-t a mappába. Saját alkalmazásában adja hozzá a JAR‑t a classpath‑hoz a build eszközben vagy az IDE‑ben.

## **Linux**

Az Aspose.Slides for Java a Java betűtípus‑támogatását használja, amely Linuxon a fontconfig könyvtárat és legalább egy telepített betűtípust igényli. Ezek hiányában a prezentáció mentése a következő hibával sikertelen: "Fontconfig head is null, check your fonts or fonts configuration". Egyes minimális szerver‑ és konténer‑képek egyaránt hiányolják ezeket; például a hivatalos Ubuntu konténerkép egyikét sem tartalmazza.

Debianon és Ubuntu‑n a következő parancs telepíti a JDK‑t, a Maven‑t, a fontconfig‑ot és a DejaVu betűtípusokat:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

A prezentációkban használt betűtípusokat, vagy megfelelő helyettesítőket, szintén telepíteni kell a helyes szövegmegjelenítéshez.

## **GYIK**

### Hogyan ellenőrizhetem, hogy az Aspose.Slides helyesen integrálva van?

Építse fel a projektet, hozzon létre egy üres [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) objektumot, és mentse el egy új néven. Ha a fájl kivétel nélkül létrejön, a könyvtár sikeresen integrálva van.

### Hogyan korlátozhatom a memóriafelhasználást nagy prezentációk feldolgozásakor?

Növelje a JVM memóriakorlátot csak annyira, amennyire szükség van, és hívja meg a [dispose](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#dispose--) metódust minden [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányon egy `finally` blokkban, hogy a gyorsítótár időben felszabaduljon. Ez megakadályozza a memória‑hiány hibákat, és előre láthatóvá teszi a memóriahasználatot kötegelt műveletek során.

### Kizárhatok‑e nem kívánt exportformátumokat a végső JAR méretének csökkentése érdekében?

A jelenlegi Aspose.Slides kiadások egyetlen monolitikus könyvtárként kerülnek szállításra, így nem lehetséges egyes exportereket, például a PDF‑et vagy az SVG‑t a build időben letiltani.
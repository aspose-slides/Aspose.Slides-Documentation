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

Ez a cikk elmagyarázza, hogyan lehet hozzáadni az Aspose.Slides for Java-t egy projekthez. Az Aspose.Slides for Java az Aspose saját Maven tárolójában kerül kiadásra, nem a Maven Centralban, ezért egy Maven projektnek deklarálnia kell ezt a tárolót. A JAR fájlt is letöltheti, és saját maga a class path‑ra helyezheti. Mindkét út egy rövid programmal végződik, amely megerősíti, hogy a könyvtár működik.

Az Aspose.Slides for Java nem igényli a Microsoft PowerPointot. Programozott módon generálja a szükséges prezentációs fájlokat. A generált prezentációk megtekintéséhez azonban szükség lehet a Microsoft PowerPointra vagy egy másik prezentációs megjelenítőre.

## **Előfeltételek**

- Java Fejlesztői Készlet (JDK). A projektnek és a cikkben szereplő parancsoknak JDK 11 vagy újabb szükséges. JDK 11 esetén a telepítést ellenőrző program egy figyelmeztetést ír ki, amely a „WARNING: An illegal reflective access operation has occurred” szöveggel kezdődik; ez nem befolyásolja az eredményt, és figyelmen kívül hagyható.
- [Apache Maven](https://maven.apache.org/install.html), ha a Maven útvonalat használja.
- Linuxon a fontconfig könyvtárra és legalább egy telepített betűtípusra van szükség. Lásd [Linux](#linux).

## **Telepítés a Maven tárolóból**

Az Aspose saját [Maven tárolójában](https://releases.aspose.com/java/repo/com/aspose/) helyezi el a Java könyvtárait. Ahhoz, hogy a [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) egy Maven projektben használható legyen, adjon hozzá két bejegyzést a *pom.xml* fájlhoz.

1. **Deklarálja az Aspose Maven tárolót.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Adja hozzá az Aspose.Slides for Java függőséget.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

A `jdk8` osztályozó kötelező: ez választja ki a könyvtár Java SE változatát. Cserélje le a `26.10` értéket a [tárolóban](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) felsorolt legújabb verzióra. A tároló minden JAR mellett egy SHA-1 ellenőrzőösszeg fájlt tesz közzé, amelyet a Maven ellenőriz a könyvtár letöltésekor.

### **Telepítés ellenőrzése**

A beállítás ellenőrzéséhez új projekttel:

1. Hozzon létre egy mappát a projekthez, és mentse el ebbe ezt a *pom.xml* fájlt:

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
               <version>26.10</version>
               <classifier>jdk8</classifier>
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

   A tárolón és a függőségen kívül ez a *pom.xml* beállítja a lefordítandó Java verziót, megadja azt az osztályt, amelyet a `mvn exec:java` futtat, és rögzíti a fordító plugin-t, mivel a régebbi plugin, amelyet egyes Maven telepítések alapértelmezésben használnak, figyelmen kívül hagyja a `maven.compiler.release` beállítást.

2. Mentse az első példát a [Prezentációk létrehozása](/slides/hu/java/create-presentation/) útvonalon *src/main/java/HelloSlides.java* néven.

3. A projekt mappájában futtassa:

   ```bash
   mvn compile exec:java
   ```

A Maven letölti az Aspose.Slides for Java-t, lefordítja a programot, és futtatja. A program a *new_presentation.pptx* fájlt menti a projekt mappájába.

## **A JAR fájl használata Maven nélkül**

1. Töltse le az *aspose-slides-26.10-jdk8.jar* fájlt a [verzió mappájából](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) a tárolóban. Másik verzió esetén nyissa meg annak mappáját a [tárolóban](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), és töltse le azt a fájlt, amely *-jdk8.jar* végződésű.

2. Mentse az első példát a [Prezentációk létrehozása](/slides/hu/java/create-presentation/) útvonalon *HelloSlides.java* néven ugyanabban a mappában, ahol a JAR fájl található.

3. Ebben a mappában futtassa:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

A JDK lefordítja és futtatja az egyetlen forrásfájlt, a program a *new_presentation.pptx* fájlt menti a mappába. A saját alkalmazásában adja hozzá a JAR fájlt a class path-hez a build eszközben vagy az IDE-ben.

## **Linux**

Az Aspose.Slides for Java a Java betűtípus támogatását használja, amely Linuxon a fontconfig könyvtárat és legalább egy telepített betűtípust igényli. Ezek hiányában a prezentáció mentése a "Fontconfig head is null, check your fonts or fonts configuration" hibával sikertelen. Minimális szerver- és konténerképek gyakran nem tartalmazzák ezeket; például a hivatalos Ubuntu konténerkép egyikét sem tartalmazza.

Debianon és Ubuntun ez a parancs telepíti a JDK-t, a Maven‑t, a fontconfig‑ot és a DejaVu betűtípusokat:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

A prezentációkban használt betűtípusokat, vagy megfelelő helyettesítőket, szintén telepíteni kell ahhoz, hogy a szöveg helyesen jelenjen meg.

## **FAQ**

### Hogyan ellenőrizhetem, hogy az Aspose.Slides megfelelően van integrálva?

Építse fel a projektet, hozzon létre egy üres [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) példányt, és mentse el egy új néven. Ha a fájl kivétel dobása nélkül jön létre, a könyvtár sikeresen integrálva lett.

### Hogyan korlátozhatom a memóriafelhasználást nagy prezentációk feldolgozásakor?

Növelje a JVM memória limitet csak annyira, amennyire szükség van, és minden [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) példányon hívja meg a [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) metódust egy `finally` blokkban a gyors gyorsítótár felszabadításához. Ez megakadályozza a memóriahiányos hibákat, és előre láthatóvá teszi a memóriahasználatot kötegelt műveletek során.

### Kizárhatok nem kívánt export formátumokat a végleges JAR méretének csökkentése érdekében?

A jelenlegi Aspose.Slides kiadások egyetlen monolitikus könyvtárként kerülnek szállításra, így a build időpontjában nem lehet letiltani egyes exportálókat, például a PDF vagy SVG formátumot.
---
title: Hogyan kell futtatni a példákat
type: docs
weight: 140
url: /hu/php-java/how-to-run-the-examples/
keywords:
- példák
- szoftverkövetelmények
- GitHub
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Futtassa gyorsan az Aspose.Slides for PHP via Java példákat: klónozza a repót, állítsa vissza a csomagokat, majd építse és tesztelje a PPT, PPTX és ODP funkciókat."
---
## **Letöltés a GitHub-ról**
Az összes Aspose.Slides for PHP via Java példát a [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java) tárolja. A tárolót klónozhatja a kedvenc GitHub kliensével, vagy letöltheti a ZIP-fájlt [itt](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Bontsa ki a ZIP-fájl tartalmát egy tetszőleges mappába a számítógépén. Az összes példa a **Examples** mappában található.

![todo:image_alt_text](examples_directory.png)

## **Példák importálása az IDE-be**
A projekt Maven felépítési rendszert használ. Bármely modern IDE könnyen megnyithatja vagy importálhatja a projektet és annak függőségeit. Az alábbiakban bemutatjuk, hogyan használhatja a népszerű IDE-ket a példák felépítéséhez és futtatásához.

### **IntelliJ IDEA**
Kattintson a **File** menüre, majd válassza az **Open** lehetőséget. Tallózzon a projekt mappájához, és válassza ki a **pom.xml** fájlt.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

A projekt megnyílik, és a függőségek automatikusan letöltődnek. A Project fülön tallózhat a **src/main/java** mappában lévő példák között. Egy példa futtatásához kattintson jobb gombbal a fájlra, majd válassza a „Run …” lehetőséget; a példa végrehajtódik, és a kimenet a beépített konzolablakban jelenik meg.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Kattintson a **File** menüre, majd válassza az **Import** lehetőséget. Válassza a **Maven** – **Existing Maven Projects** opciót.

![todo:image_alt_text](eclipse_import.png)

Tallózzon a GitHub‑ról klónozott vagy letöltött mappához, és válassza ki a **pom.xml** fájlt. A projekt megnyílik, és a függőségek automatikusan letöltődnek. A Package Explorer fülön tallózhat a **src/main/java** mappában lévő példák között. Egy példa futtatásához kattintson jobb gombbal a fájlra, majd válassza a **Run As** – **Java Application** lehetőséget; a példa végrehajtódik, és a kimenet a beépített konzolablakban jelenik meg.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Kattintson a **File** menüre, majd válassza az **Open Project** lehetőséget. Tallózzon a GitHub‑ról klónozott vagy letöltött mappához. A **Examples** mappa ikonja jelzi, hogy Maven projektről van szó. Válassza ki az **Examples** mappát, és nyissa meg.

![todo:image_alt_text](netbeans_openproject.png)

A projekt megnyílik, és a függőségek automatikusan letöltődnek. A Projects fülön tallózhat a **source packages** mappában lévő példák között. Egy példa futtatásához kattintson jobb gombbal a fájlra, majd válassza a **Run File** lehetőséget; a példa végrehajtódik, és a kimenet a beépített konzolablakban jelenik meg.

![todo:image_alt_text](netbeans_run_example.png)

## **Az Aspose.Slides könyvtár hozzáadása a Maven helyi tárolóhoz**
Amikor az **Aspose.Slides Examples** projektet importálja az IDE-be, a Maven automatikusan letölti az aspose.slides JAR‑t a [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/) oldaláról. Ha nincs internetkapcsolata, a JAR‑t manuálisan kell hozzáadnia a helyi tárolóhoz.

### **mvn install**
Töltse le az [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/) csomagot, bontsa ki, és másolja az aspose.slides‑version.jar‑t valahová, például a C: meghajtóra. Ezután futtassa a következő parancsot:

```php

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```php

```

Most az **aspose.slides** JAR a Maven helyi tárolójába lett másolva.

### **pom.xml**
A telepítés után egyszerűen adja meg az **aspose.slides** koordinátákat a pom.xml‑ben. Adja hozzá a következő tárolót a **repositories** szekcióhoz, és a függőséget a **dependencies** szekcióhoz.

``` xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```php

### **Kész**
Építse fel a projektet, és most már az **aspose.slides** JAR elérhető a Maven helyi tárolójából.

## **Hozzájárulás**
Ha szeretne példát hozzáadni vagy javítani, ösztönözzük, hogy járuljon hozzá a projekthez. Az ebben a tárolóban található összes példa és bemutató nyílt forráskódú, és szabadon felhasználható saját alkalmazásaiban.

A hozzájáruláshoz fork-olja a tárolót, szerkessze a forráskódot, majd küldjön be egy Pull Request‑et. Áttekintjük a változtatásokat, és ha hasznosnak találjuk, belefoglaljuk a tárolóba.
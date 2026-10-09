---
title: Hogyan futtassunk példákat
type: docs
weight: 140
url: /hu/java/how-to-run-the-examples/
keywords:
- példák
- szoftverkövetelmények
- GitHub
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Futtassa gyorsan az Aspose.Slides for Java példákat: klónozza a repót, állítsa helyre a csomagokat, majd építse és tesztelje a PPT, PPTX és ODP funkciókat."
---
## **Az Aspose.Slides letöltése a GitHub-ról**
Az Aspose.Slides for Java összes példája a [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) címen érhető el. A tárolót klónozhatja kedvenc Github kliensével, vagy letöltheti a ZIP fájlt [itt](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Csomagolja ki a ZIP fájl tartalmát bármelyik mappába a számítógépén. Az összes példa a **Examples** mappában található.

![todo:image_alt_text](examples_directory.png)

## **Példák importálása az IDE-be**
A projekt a Maven build rendszert használja. Bármely modern IDE könnyedén megnyithatja vagy importálhatja a projektet és függőségeit. Az alábbiakban bemutatjuk, hogyan használhat népszerű IDE-ket a példák felépítésére és futtatására.

### **IntelliJ IDEA**
Kattintson a **File** menüre, majd válassza a **Open** lehetőséget. Tallózzon a projekt mappájához, és válassza a **pom.xml** fájlt.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Megnyílik a projekt, és a függőségek automatikusan letöltődnek. A Project fülön tallózhatja a példákat a **src/main/java** mappában. Egy példa futtatásához kattintson jobb gombbal a fájlra, és válassza a “Run ..” lehetőséget, a példa végrehajtódik, és a kimenet a beépített konzolablakban jelenik meg.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Kattintson a **File** menüre, majd válassza az **Import** lehetőséget. Válassza a **Maven** – Existing Maven Projects opciót.

![todo:image_alt_text](eclipse_import.png)

Tallózzon a klónozott vagy letöltött GitHub mappához, és válassza a **pom.xml** fájlt. A projekt megnyílik, és a függőségek automatikusan letöltődnek. A Package Explorer fülön tallózhatja a példákat a **src/main/java** mappában. Egy példa futtatásához kattintson jobb gombbal a fájlra, és válassza a **Run As** – **Java Application** lehetőséget, a példa végrehajtódik, és a kimenet a beépített konzolablakban jelenik meg.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Kattintson a **File** menüre, majd válassza az **Open Project** lehetőséget. Tallózzon a klónozott vagy letöltött GitHub mappához. A **Examples** mappa ikonja jelzi, hogy Maven projektről van szó. Válassza ki az Examples elemet, és nyissa meg.

![todo:image_alt_text](netbeans_openproject.png)

Megnyílik a projekt, és a függőségek automatikusan letöltődnek. A Projects fülön tallózhatja a példákat a **source packages** alatt. Egy példa futtatásához kattintson jobb gombbal a fájlra, és válassza a **Run File** lehetőséget, a példa végrehajtódik, és a kimenet a beépített konzolablakban jelenik meg.

![todo:image_alt_text](netbeans_run_example.png)

## **Az Aspose.Slides könyvtár hozzáadása a Maven helyi tárolóhoz**
Amikor importálja az **Aspose.Slides Examples** projektet az IDE-be, a Maven automatikusan letölti az aspose.slides JAR fájlt a [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/) címről. Ha nincs internetkapcsolata, manuálisan is hozzáadhatja a JAR-t a helyi tárolóhoz.

### **mvn install**
Töltse le az [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) fájlt, csomagolja ki, és másolja az aspose.slides-version.jar fájlt egy másik helyre, például a C meghajtóra. Adja ki a következő parancsot:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

Most az **aspose.slides** JAR a Maven helyi tárolójába másolva van.

### **pom.xml**
A telepítés után egyszerűen deklarálja az **aspose.slides** koordinátákat a pom.xml-ben. Adja hozzá a következő tárolót a repositories fülhöz, és a függőséget a dependencies fülhöz.

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>26.10</version>
    <classifier>jdk8</classifier>
</dependency>
```

### **Kész**
Építse fel, most már a **aspose.slides** JAR a Maven helyi tárolójából érhető el.

## **Hozzájárulás**
Ha szeretne példát hozzáadni vagy javítani, bátorítjuk, hogy járuljon hozzá a projekthez. Az összes példa és bemutató projekt ebben a tárolóban nyílt forráskódú, és szabadon felhasználható saját alkalmazásaiban.

A hozzájáruláshoz fork-olhatja a tárolót, szerkesztheti a forráskódot, és benyújthat egy Pull Requestet. Átnézzük a változtatásokat, és ha hasznosnak találjuk, beépítjük a tárolóba.
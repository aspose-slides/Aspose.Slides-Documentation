---
title: Jak spustit příklady
type: docs
weight: 140
url: /cs/java/how-to-run-the-examples/
keywords:
- příklady
- softwarové požadavky
- GitHub
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Rychle spusťte příklady Aspose.Slides pro Java: klonujte repozitář, obnovte balíčky a poté sestavte a otestujte funkce pro PPT, PPTX a ODP."
---
## **Stáhnout Aspose.Slides z GitHubu**
Všechny příklady Aspose.Slides pro Java jsou hostovány na [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Můžete buď klonovat repozitář pomocí svého oblíbeného Github klienta, nebo stáhnout ZIP soubor z [zde](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Rozbalte obsah ZIP souboru do libovolné složky ve vašem počítači. Všechny příklady jsou umístěny ve složce **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importovat příklady do IDE**
Projekt používá build systém Maven. Jakékoli moderní IDE může snadno otevřít nebo importovat projekt a jeho závislosti. Níže ukazujeme, jak používat populární IDE k sestavení a spuštění příkladů.

### **IntelliJ IDEA**
Klikněte na nabídku **File** a zvolte **Open**. Procházejte do složky projektu a vyberte soubor **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Projekt se otevře a závislosti se stáhnou automaticky. Na kartě **Project** procházejte příklady ve složce **src/main/java**. Pro spuštění příkladu stačí kliknout pravým tlačítkem na soubor a zvolit “Run ..”, příklad se spustí a výstup se zobrazí ve vestavěném okně konzole.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klikněte na nabídku **File** a zvolte **Import**. Vyberte **Maven** – Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Procházejte do složky, kterou jste klonovali nebo stáhli z GitHubu, a vyberte soubor **pom.xml**. Projekt se otevře a závislosti se stáhnou automaticky. V kartě **Package Explorer** procházejte příklady ve složce **src/main/java**. Pro spuštění příkladu stačí kliknout pravým tlačítkem na soubor a zvolit **Run As** – **Java Application**, příklad se spustí a výstup se zobrazí ve vestavěném okně konzole.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klikněte na nabídku **File** a zvolte **Open Project**. Procházejte do složky, kterou jste klonovali nebo stáhli z GitHubu. Ikona složky **Examples** ukazuje, že se jedná o Maven projekt. Vyberte **Examples** a otevřete jej.

![todo:image_alt_text](netbeans_openproject.png)

Projekt se otevře a závislosti se stáhnou automaticky. Na kartě **Projects** procházejte příklady v **source packages**. Pro spuštění příkladu stačí kliknout pravým tlačítkem na soubor a zvolit **Run File**, příklad se spustí a výstup se zobrazí ve vestavěném okně konzole.

![todo:image_alt_text](netbeans_run_example.png)

## **Přidat knihovnu Aspose.Slides do lokálního Maven repozitáře**
Když importujete projekt **Aspose.Slides Examples** do IDE, Maven automaticky stáhne JAR soubor aspose.slides z [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). V případě, že nemáte přístup k internetu, můžete JAR přidat ručně do svého lokálního repozitáře.

### **mvn install**
Stáhněte [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), rozbalte jej a zkopírujte soubor aspose.slides‑version.jar někam jinam, například na jednotku C. Spusťte následující příkaz:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

Nyní je JAR **aspose.slides** zkopírován do vašeho lokálního Maven repozitáře.

### **pom.xml**
Po instalaci stačí v pom.xml deklarovat koordináty **aspose.slides**. Přidejte následující úložiště do sekce repositories a závislost do sekce dependencies.

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>25.12</version>
    <classifier>jdk16</classifier>
</dependency>
```

### **Hotovo**
Postavte projekt, nyní je JAR **aspose.slides** dostupný z vašeho lokálního Maven repozitáře.

## **Přispět**
Pokud chcete přidat nebo vylepšit příklad, vyzýváme vás k přispění do projektu. Všechny příklady a ukázkové projekty v tomto repozitáři jsou open source a mohou být volně použity ve vašich aplikacích.

Pro přispění můžete forkovat repozitář, upravit zdrojový kód a odeslat Pull Request. Změny přezkoumáme a zařadíme je do repozitáře, pokud budou užitečné.
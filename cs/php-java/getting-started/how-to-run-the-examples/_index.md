---
title: Jak spustit příklady
type: docs
weight: 140
url: /cs/php-java/how-to-run-the-examples/
keywords:
  - příklady
  - softwarové požadavky
  - GitHub
  - PowerPoint
  - OpenDocument
  - prezentace
  - PHP
  - Aspose.Slides
description: "Rychle spusťte příklady Aspose.Slides pro PHP via Java: naklonujte repozitář, obnovte balíčky a poté sestavte a otestujte funkce pro PPT, PPTX a ODP."
---
## **Stáhnout z GitHubu**
Všechny příklady Aspose.Slides pro PHP via Java jsou hostovány na [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Můžete buď klonovat repozitář pomocí svého oblíbeného Github klienta nebo stáhnout soubor ZIP z [zde](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Rozbalte obsah souboru ZIP do libovolné složky ve vašem počítači. Všechny příklady se nacházejí ve složce **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importovat příklady do IDE**
Projekt používá sestavovací systém Maven. Jakékoli moderní IDE může snadno otevřít nebo importovat projekt a jeho závislosti. Níže ukazujeme, jak pomocí populárních IDE sestavit a spustit příklady.

### **IntelliJ IDEA**
Klikněte na nabídku **File** a zvolte **Open**. Procházejte do složky projektu a vyberte soubor **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Otevře projekt a automaticky stáhne závislosti. Na kartě Project procházejte příklady ve složce **src/main/java**. Pro spuštění příkladu stačí kliknout pravým tlačítkem na soubor a zvolit „Run ..“, příklad se spustí a výstup se zobrazí ve vestavěném okně konzole.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klikněte na nabídku **File** a zvolte **Import**. Vyberte **Maven** – Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Procházejte do složky, kterou jste klonovali nebo stáhli z GitHubu, a vyberte soubor **pom.xml**. Otevře projekt a automaticky stáhne závislosti. Na kartě Package Explorer procházejte příklady ve složce **src/main/java**. Pro spuštění příkladu stačí kliknout pravým tlačítkem na soubor a zvolit **Run As** - **Java Application**, příklad se spustí a výstup se zobrazí ve vestavěném okně konzole.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klikněte na nabídku **File** a zvolte **Open Project**. Procházejte do složky, kterou jste klonovali nebo stáhli z GitHubu. Ikona složky **Examples** ukáže, že se jedná o Maven projekt. Vyberte **Examples** a otevřete ho.

![todo:image_alt_text](netbeans_openproject.png)

Otevře projekt a automaticky stáhne závislosti. Na kartě Projects procházejte příklady v **source packages**. Pro spuštění příkladu stačí kliknout pravým tlačítkem na soubor a zvolit **Run File**, příklad se spustí a výstup se zobrazí ve vestavěném okně konzole.

![todo:image_alt_text](netbeans_run_example.png)

## **Přidat knihovnu Aspose.Slides do místního Maven repozitáře**
Když importujete projekt **Aspose.Slides Examples** do IDE, Maven automaticky stáhne soubor JAR aspose.slides z [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). Pokud nemáte přístup k internetu, můžete JAR přidat ručně do svého místního repozitáře.

### **mvn install**
Stáhněte [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/), rozbalte jej a zkopírujte soubor aspose.slides-version.jar někam jinam, například na jednotku C. Proveďte následující příkaz:

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

Nyní je jar **aspose.slides** zkopírována do vašeho místního Maven repozitáře.

### **pom.xml**
Po instalaci stačí deklarovat koordináty **aspose.slides** v pom.xml. Přidejte následující úložiště do sekce repositories a závislost do sekce dependencies.

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


### **Hotovo**
Sestavte projekt, nyní může být jar **aspose.slides** načten z vašeho místního Maven repozitáře.

## **Přispívat**
Pokud chcete přidat nebo vylepšit příklad, vyzýváme vás k přispění do projektu. Všechny příklady a ukázkové projekty v tomto repozitáři jsou open source a mohou být volně použity ve vašich aplikacích.

Pro přispění můžete forknout repozitář, upravit zdrojový kód a odeslat Pull Request. Změny přezkoumáme a zařadíme je do repozitáře, pokud budou užitečné.
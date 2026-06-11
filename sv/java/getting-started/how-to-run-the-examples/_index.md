---
title: Hur man kör exempel
type: docs
weight: 140
url: /sv/java/how-to-run-the-examples/
keywords:
- exempel
- programvarukrav
- GitHub
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Kör Aspose.Slides för Java-exempel snabbt: klona repot, återställ paket, och bygg sedan testa funktioner för PPT, PPTX och ODP."
---
## **Ladda ner Aspose.Slides från GitHub**
Alla exempel på Aspose.Slides för Java finns på [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java). Du kan antingen klona repot med din föredragna GitHub‑klient eller ladda ner ZIP‑filen från [här](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Extrahera innehållet i ZIP‑filen till en valfri mapp på din dator. Alla exempel finns i mappen **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importera exempel till IDE:n**
Projektet använder Maven‑byggsystemet. Alla moderna IDE:er kan enkelt öppna eller importera projektet och dess beroenden. Nedan visar vi hur du använder populära IDE:er för att bygga och köra exemplen.

### **IntelliJ IDEA**
Klicka på menyn **Arkiv** och välj **Öppna**. Bläddra till projektmappen och välj filen **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Den öppnar projektet och hämtar beroenden automatiskt. Från fliken **Project** bläddrar du till exemplen i mappen **src/main/java**. För att köra ett exempel, högerklicka på filen och välj "Kör ..", så körs exemplet och resultatet visas i den inbyggda konsolens utskriftsfönster.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klicka på menyn **Arkiv** och välj **Importera**. Välj **Maven** – Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Bläddra till den mapp du klonade eller laddade ner från GitHub och välj filen **pom.xml**. Den öppnar projektet och hämtar beroenden automatiskt. Från fliken **Package Explorer** bläddrar du till exemplen i mappen **src/main/java**. För att köra ett exempel, högerklicka på filen och välj **Run As** – **Java Application**, så körs exemplet och utskriften visas i den inbyggda konsolens fönster.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klicka på menyn **Arkiv** och välj **Öppna projekt**. Bläddra till den mapp du klonade eller laddade ner från GitHub. Ikonen för mappen **Examples** visar att den är ett Maven‑projekt. Välj **Examples** och öppna den.

![todo:image_alt_text](netbeans_openproject.png)

Den öppnar projektet och hämtar beroenden automatiskt. Från fliken **Projects** bläddrar du till exemplen i **source packages**. För att köra ett exempel, högerklicka på filen och välj **Run File**, så körs exemplet och resultatet visas i den inbyggda konsolens utskriftsfönster.

![todo:image_alt_text](netbeans_run_example.png)

## **Lägg till Aspose.Slides‑biblioteket i Maven‑lokalrepositoryt**
När du importerar **Aspose.Slides Examples**‑projektet i en IDE laddar Maven automatiskt ner aspose.slides‑JAR‑filen från [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). Om du saknar internetåtkomst kan du manuellt lägga till JAR‑filen i ditt lokala repository.

### **mvn install**
Ladda ner [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), extrahera den och kopiera filen aspose.slides‑version.jar någonstans, till exempel på C‑enheten. Kör följande kommando:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

Nu har **aspose.slides**‑JAR‑filen kopierats till ditt lokala Maven‑repository.

### **pom.xml**
Efter installationen deklarerar du bara **aspose.slides**‑koordinaten i pom.xml. Lägg till följande repository i fliken *repositories* och beroendet i fliken *dependencies*.

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

### **Klart**
Bygg projektet, nu kan **aspose.slides**‑JAR‑filen hämtas från ditt lokala Maven‑repository.

## **Bidra**
Om du vill lägga till eller förbättra ett exempel uppmuntrar vi dig att bidra till projektet. Alla exempel och showcase‑projekt i detta repository är öppna källkodsprojekt och kan fritt användas i dina egna applikationer.

För att bidra kan du fork:a repot, redigera källkoden och skicka en Pull Request. Vi kommer att granska ändringarna och inkludera dem i repot om de visar sig vara hjälpsamma.
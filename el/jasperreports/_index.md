---
title: "Aspose.Slides για JasperReports"
second_title: "Aspose.Slides για JasperReports"
type: docs
weight: 70
url: /el/jasperreports/
keywords:
- τεκμηρίωση
- JasperReports
- JasperReports Server
- εξαγωγή αναφοράς
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Ξεκινήστε εδώ: εγκαταστήστε το Aspose.Slides για JasperReports, εξάγετε την πρώτη αναφορά σε PowerPoint και βρείτε τους οδηγούς για εξαγωγή, ενσωμάτωση JasperReports Server και υποστήριξη."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides για JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Το Aspose.Slides for JasperReports προσθέτει εξαγωγείς PowerPoint στη βιβλιοθήκη JasperReports Library και στον JasperReports Server, ώστε οι εφαρμογές Java και οι διακομιστές αναφορών να μπορούν να αποθηκεύουν συμπληρωμένες αναφορές ως παρουσιάσεις χωρίς το Microsoft PowerPoint.

Εξάγει μια συμπληρωμένη αναφορά σε PPT και PPTX, μία διαφάνεια ανά σελίδα αναφοράς, καθώς και σε PDF και HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Ξεκινήστε</b></p>
<hr>
<p>ΞΕΚΙΝΗΣΜΑ</p>
<ul>
<li><a href="/slides/el/jasperreports/installing-aspose-slides-for-jasperreports/">Εγκατάσταση</a></li>
<li><a href="/slides/el/jasperreports/product-overview/">Επισκόπηση προϊόντος</a></li>
<li><a href="/slides/el/jasperreports/system-requirements/">Απαιτήσεις συστήματος</a></li>
<li><a href="/slides/el/jasperreports/getting-started/">Οδηγός εκκίνησης</a></li>
</ul>
<p>ΑΞΙΟΛΟΓΗΣΗ</p>
<ul>
<li><a href="/slides/el/jasperreports/supported-file-formats/">Υποστηριζόμενες μορφές αρχείου</a></li>
<li><a href="/slides/el/jasperreports/evaluate-aspose-slides/">Περιορισμοί δοκιμής</a></li>
<li><a href="/slides/el/jasperreports/licensing/">Αδειοδότηση</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Δημιουργία με Slides</b></p>
<hr>
<p>ΕΞΑΓΩΓΗ</p>
<ul>
<li><a href="/slides/el/jasperreports/ppt-pptx-pdf-and-html-export/">Εξαγωγή σε PPT, PPTX, PDF και HTML</a></li>
<li><a href="/slides/el/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Χαρτογράφηση γραμματοσειρών</a></li>
<li><a href="/slides/el/jasperreports/integration-with-jasperserver/">Ενσωμάτωση JasperReports Server</a></li>
</ul>
<p>ΠΑΡΑΔΕΙΓΜΑΤΑ</p>
<ul>
<li><a href="/slides/el/jasperreports/demos-setup/">Δείγματα έργων</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Αναφορά &amp; Υποστήριξη</b></p>
<hr>
<p>ΑΝΑΦΟΡΑ</p>
<ul>
<li><a href="https://releases.aspose.com/slides/el/jasperreport/release-notes/">Σημειώσεις έκδοσης</a></li>
<li><a href="https://releases.aspose.com/slides/el/jasperreport/">Λήψη</a></li>
</ul>
<p>ΥΠΟΣΤΗΡΙΞΗ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/el/11">Δωρεάν φόρουμ υποστήριξης</a></li>
<li><a href="https://helpdesk.aspose.com/">Πληρωμένη βοήθεια υποστήριξης</a></li>
</ul>
</div>
</div>

------

## **Η πρώτη σας εξαγωγή**

Αυτά τα βήματα δημιουργούν μια αναφορά μιας γραμμής, τη συμπληρώνουν και την εξάγουν σε PPTX με το JasperReports 6.16.0 από το Maven Central. Χρειάζεστε JDK 11 ή μεταγενέστερο και Apache Maven.

1. Κατεβάστε το ZIP από τη [download page](https://releases.aspose.com/slides/el/jasperreport/) και αποσυμπιέστε το. Ο φάκελος *lib* περιέχει έναν υποφάκελο για κάθε εύρος εκδόσεων JasperReports, και κάθε υποφάκελος περιέχει το jar για εκείνο το εύρος. Για το JasperReports 6.16.0, αντιγράψτε το *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* σε έναν άδειο φάκελο έργου.

2. Το jar περιλαμβάνεται στο ZIP αντί για αποθετήριο Maven, επομένως εγκαταστήστε το στο τοπικό αποθετήριο Maven. Εκτελέστε αυτήν την εντολή στον φάκελο του έργου:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Αποθηκεύστε αυτό το *pom.xml* στον φάκελο του έργου. Προσθέτει το JasperReports 6.16.0 και το jar που εγκαταστήσατε, και ορίζει την κλάση που θα εκτελεστεί. Το JasperReports 6.16.0 δηλώνει μια διορθωμένη έκδοση του iText που δεν υπάρχει στο Maven Central, γι' αυτό το αρχείο το αποκλείει· οι εξαγωγείς Aspose δεν το χρειάζονται.

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-jasper-export</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloExport</exec.mainClass>
    </properties>

    <dependencies>
        <dependency>
            <groupId>net.sf.jasperreports</groupId>
            <artifactId>jasperreports</artifactId>
            <version>6.16.0</version>
            <exclusions>
                <exclusion>
                    <groupId>com.lowagie</groupId>
                    <artifactId>itext</artifactId>
                </exclusion>
            </exclusions>
        </dependency>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides-jasperreports</artifactId>
            <version>26.6</version>
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

4. Αποθηκεύστε αυτό το σχέδιο αναφοράς ως *hello.jrxml* στον φάκελο του έργου. Εμφανίζει μια γραμμή κειμένου στην κορδέλα τίτλου:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<jasperReport xmlns="http://jasperreports.sourceforge.net/jasperreports"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xsi:schemaLocation="http://jasperreports.sourceforge.net/jasperreports http://jasperreports.sourceforge.net/xsd/jasperreport.xsd"
        name="Hello" pageWidth="595" pageHeight="842" columnWidth="555"
        leftMargin="20" rightMargin="20" topMargin="20" bottomMargin="20">
    <title>
        <band height="50">
            <staticText>
                <reportElement x="0" y="0" width="555" height="40"/>
                <textElement>
                    <font size="24"/>
                </textElement>
                <text><![CDATA[Hello from JasperReports!]]></text>
            </staticText>
        </band>
    </title>
</jasperReport>
```

5. Αποθηκεύστε αυτόν τον κώδικα ως *src/main/java/HelloExport.java*. Συγκεντρώει το σχέδιο, το γεμίζει με μία κενή εγγραφή και εξάγει το αποτέλεσμα με `ASPptxExporter`:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class HelloExport {
    public static void main(String[] args) throws Exception {
        // Μεταγλώττιση του σχεδίου αναφοράς και γέμισμα του με μία κενή εγγραφή.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Εξαγωγή της συμπληρωμένης αναφοράς σε PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Εκτελέστε αυτήν την εντολή στον φάκελο του έργου:

```bash
mvn compile exec:java
```

Το πρόγραμμα αποθηκεύει το *hello.pptx* στον φάκελο του έργου, με μία διαφάνεια που περιέχει το κείμενο της αναφοράς. Ο μεταγλωττιστής σημειώνει ότι ο κώδικας χρησιμοποιεί παρωχημένο API: οι εξαγωγείς λαμβάνουν την είσοδο και την έξοδο μέσω του `JRExporterParameter` και δεν δέχονται τις νεότερες ρυθμίσεις `setExporterInput` και `setExporterOutput`. Σε Linux, πρέπει να είναι εγκατεστημένα το fontconfig και τουλάχιστον μια γραμματοσειρά, αλλιώς η συμπλήρωση της αναφοράς αποτυγχάνει. Χωρίς άδεια, κάθε διαφάνεια φέρει ένα υδατογράφημα αξιολόγησης στο κέντρο — δείτε τη [Licensing](/slides/el/jasperreports/licensing/). Για εξαγωγή σε PPT, PDF ή HTML, δείτε την [PPT, PPTX, PDF and HTML Export](/slides/el/jasperreports/ppt-pptx-pdf-and-html-export/).
---
title: Εξαγωγή PPT, PPTX, PDF και HTML
type: docs
weight: 20
url: /el/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Επιλέξτε τον εξαγωγέα Aspose.Slides for JasperReports για έξοδο PPT, PPTX, PDF ή HTML, εξάγετε μια συμπληρωμένη αναφορά με αυτόν και αντιστοιχίστε τις γραμματοσειρές της αναφοράς στις γραμματοσειρές της παρουσίασης."
---
## **Εξαγωγείς**

Το Aspose.Slides for JasperReports προσθέτει τέσσερις εξαγωγείς στο JasperReports. Κάθε ένας παίρνει μια συμπληρωμένη αναφορά (`JasperPrint`) και εξάγει κάθε σελίδα της αναφοράς: ως διαφάνεια σε PPT και PPTX, ως σελίδα σε PDF και ως εικόνα SVG σε ένα ενιαίο αρχείο HTML.

| Μορφή εξόδου | Κλάση εξαγωγέα |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Οι κλάσεις βρίσκονται στο πακέτο `com.aspose.slides.jasperreports` του αρχείου JAR της βιβλιοθήκης και δεν χρησιμοποιούν το Microsoft PowerPoint. Περάστε την αναφορά και το αρχείο εξόδου σε έναν εξαγωγέα με τις μεθόδους `setParameter` και `JRExporterParameter`, τις οποίες το JasperReports σημειώνει ως παρωχημένες: οι εξαγωγείς δεν δέχονται τη νεότερη διαμόρφωση `setExporterInput` και `setExporterOutput`.

## **Εξαγωγή αναφοράς σε όλες τις τέσσερις μορφές**

Το παρακάτω πρόγραμμα βασίζεται στο έργο από [Η πρώτη σας εξαγωγή](/slides/el/jasperreports/#your-first-export). Μεταγλωττίζει και συμπληρώνει το *hello.jrxml* μία φορά, στη συνέχεια περνά τη συμπληρωμένη αναφορά σε κάθε εξαγωγέα διαδοχικά. Αποθηκεύστε το ως *src/main/java/ExportAllFormats.java* σε αυτό το έργο:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASAbstractExporter;
import com.aspose.slides.jasperreports.ASHtmlExporter;
import com.aspose.slides.jasperreports.ASPdfExporter;
import com.aspose.slides.jasperreports.ASPptExporter;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class ExportAllFormats {
    public static void main(String[] args) throws Exception {
        // Μεταγλώττιση και συμπλήρωση της αναφοράς μία φορά.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Εξαγωγή της ίδιας συμπληρωμένης αναφοράς με κάθε εξαγωγέα.
        export(new ASPptExporter(), jasperPrint, "hello.ppt");
        export(new ASPptxExporter(), jasperPrint, "hello.pptx");
        export(new ASPdfExporter(), jasperPrint, "hello.pdf");
        export(new ASHtmlExporter(), jasperPrint, "hello.html");
    }

    private static void export(ASAbstractExporter exporter, JasperPrint jasperPrint, String outputFileName) throws JRException {
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, outputFileName);
        exporter.exportReport();
    }
}
```

Τρέξτε το από το φάκελο του έργου:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

Το πρόγραμμα αποθηκεύει τα *hello.ppt*, *hello.pptx*, *hello.pdf* και *hello.html* στο φάκελο του έργου. Η βοηθητική μέθοδος δέχεται `ASAbstractExporter`, τη βάση κλάση όλων των τεσσάρων εξαγωγέων. Χωρίς άδεια, κάθε αρχείο εξόδου φέρει το υδατογράφημα αξιολόγησης — δείτε [Αξιολόγηση Aspose.Slides](/slides/el/jasperreports/evaluate-aspose-slides/).

![Μια αναφορά που εξήχθη σε παρουσίαση χωρίς άδεια](ppt-pptx-pdf-and-html-export_1.png)

## **Αντιστοίχιση γραμματοσειρών**

Οι εξαγωγείς PPT και PPTX γράφουν τα ονόματα των γραμματοσειρών του σχεδίου της αναφοράς στην παρουσίαση αμετάβλητα. Όταν ένα στοιχείο κειμένου δεν καθορίζει γραμματοσειρά, το JasperReports χρησιμοποιεί την προεπιλεγμένη γραμματοσειρά του, `SansSerif`, η οποία είναι λογικό όνομα γραμματοσειράς της Java και όχι εγκατεστημένη γραμματοσειρά. Για να αντικαταστήσετε τέτοια ονόματα, περάστε ένα χάρτη από τα ονόματα γραμματοσειρών της αναφοράς στα ονόματα γραμματοσειρών που θέλετε στην παρουσίαση στη παράμετρο `ASExporterParameters.PPT_FONT_MAP`. Τα κλειδιά πρέπει να ταιριάζουν ακριβώς με τα ονόματα γραμματοσειρών στην αναφορά, συμπεριλαμβανομένης της διάκρισης πεζών‑κεφαλαίων. Κάθε τιμή πρέπει να είναι μια γραμματοσειρά που η Java εντοπίζει στο μηχάνημα που εκτελεί την εξαγωγή· οι εξαγωγείς αγνοούν μια καταγραφή της οποίας η γραμματοσειρά δεν μπορεί να βρεθεί από τη Java.

Αποθηκεύστε αυτό το πρόγραμμα ως *src/main/java/MapFonts.java* στο ίδιο έργο. Εξάγει το *hello.jrxml* σε PPTX με αντικατάσταση του `SansSerif` με Arial:

```java
import java.util.HashMap;
import java.util.Map;

import com.aspose.slides.jasperreports.ASExporterParameters;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class MapFonts {
    public static void main(String[] args) throws Exception {
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Αντιστοιχίστε το όνομα γραμματοσειράς της αναφοράς στο όνομα γραμματοσειράς που θα γραφτεί στην παρουσίαση.
        Map<String, String> fontMap = new HashMap<String, String>();
        fontMap.put("SansSerif", "Arial");

        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello-arial.pptx");
        exporter.setParameter(ASExporterParameters.PPT_FONT_MAP, fontMap);
        exporter.exportReport();
    }
}
```

Τρέξτε το από το φάκελο του έργου:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

Στο αποθηκευμένο *hello-arial.pptx*, το κείμενο της αναφοράς χρησιμοποιεί Arial αντί του `SansSerif`. Σε μηχάνημα όπου η Java δεν εντοπίζει το Arial, όπως σε σύστημα Linux χωρίς αυτήν, το κείμενο διατηρεί το `SansSerif`. Στον JasperReports Server, ορίστε τον ίδιο χάρτη μέσω της ιδιότητας `fontMap` του bean παραμέτρων εξαγωγής — δείτε [Ενσωμάτωση με JasperServer](/slides/el/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).
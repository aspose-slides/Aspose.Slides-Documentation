---
title: Αδειοδότηση
type: docs
weight: 50
url: /el/jasperreports/licensing/
description: "Μάθετε τι προσθέτει η έκδοση αξιολόγησης του Aspose.Slides for JasperReports στα εξαγώμενα αρχεία και πώς να εφαρμόσετε μια άδεια στο JasperReports και στο JasperReports Server."
---
{{% alert color="info" title="Note" %}}

Το Aspose.Slides for JasperReports διατίθεται ως δωρεάν, απεριόριστη στη διάρκεια αξιολόγηση από τη [σελίδα λήψης](https://releases.aspose.com/slides/jasperreport/). Η έκδοση αξιολόγησης και η άδεια έκδοση του προϊόντος είναι η ίδια λήψη.

Όταν είστε ικανοποιημένοι με την αξιολόγηση, [αγοράστε άδεια](https://purchase.aspose.com/pricing/slides/jasperreports/). Βεβαιωθείτε ότι καταλαβαίνετε και συμφωνείτε με τους όρους συνδρομής.

Η άδεια είναι διαθέσιμη για λήψη από τη σελίδα παραγγελίας μετά την πληρωμή της παραγγελίας. Η άδεια είναι ένα απλό κείμενο, ψηφιακά υπογεγραμμένο αρχείο XML που περιέχει πληροφορίες όπως το όνομα του πελάτη, το αγορασθέν προϊόν και τον τύπο άδειας. Μην τροποποιήσετε το περιεχόμενο του αρχείου άδειας με κανέναν τρόπο: η τροποποίηση ακυρώνει την άδεια.

Κατεβάστε την άδεια στον υπολογιστή σας και αντιγράψτε την στον κατάλληλο φάκελο (για παράδειγμα στο φάκελο της εφαρμογής σας ή **JasperReports\lib**).
{{% /alert %}}

## **Περιορισμός Έκδοσης Αξιολόγησης**
Η έκδοση αξιολόγησης του Aspose.Slides for JasperReports (χωρίς καθορισμένη άδεια) εξάγει κάθε σελίδα της αναφοράς, αλλά τοποθετεί ένα υδ.γράφημα αξιολόγησης στο κέντρο κάθε διαφάνειας ή σελίδας, σε όλες τις τέσσερις μορφές εξόδου (PPT, PPTX, PDF και HTML), όπως φαίνεται στην παρακάτω εικόνα. Δείτε [Αξιολόγηση Aspose.Slides](/slides/el/jasperreports/evaluate-aspose-slides/) για λεπτομέρειες.

![Το υδ.γράφημα αξιολόγησης στο κέντρο μιας εξαγόμενης διαφάνειας](evaluation_watermark.png)

## **Εφαρμογή Άδειας**
Υπάρχουν διάφοροι τρόποι για να εφαρμόσετε μια άδεια, ανάλογα με το αν εργάζεστε στο JasperReports ή στο JasperServer.

### **Εφαρμογή Άδειας για JasperReports**
Κάλεσε τη μέθοδο `setLicense` της κλάσης `License` με μια ροή που διαβάζει το αρχείο άδειας, όπως στο Aspose.Slides for Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Δημιουργήστε ένα αντικείμενο ροής που περιέχει το αρχείο άδειας.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Δημιουργία αντικειμένου της κλάσης License.
            License license = new License();

            // Ορίστε την άδεια μέσω του αντικειμένου ροής.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Ή, περάστε τη διαδρομή του αρχείου άδειας στον εξαγωγέα στην παράμετρο `ASExporterParameters.PPT_LICENSE`. Σε αυτό το απόσπασμα, το `jasperPrint` είναι μια γεμισμένη αναφορά, όπως στη [Πρώτη σας εξαγωγή](/slides/el/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Εφαρμογή Άδειας στο JasperServer**
Ορίστε την ιδιότητα `licenseFile` του bean `pptExportParameters` στο *applicationContext.xml* στη διαδρομή του αρχείου άδειας, όπως φαίνεται στην [Ενσωμάτωση με JasperServer](/slides/el/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).
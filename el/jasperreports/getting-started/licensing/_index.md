---
title: Αδειοδότηση
type: docs
weight: 50
url: /el/jasperreports/licensing/
---
{{% alert color="info" %}} 

Το Aspose.Slides για JasperReports διατίθεται ως δωρεάν, απεριόριστης διάρκειας εκδοχή αξιολόγησης από τη [σελίδα λήψης](https://downloads.aspose.com/slides/el/jasperreport). Η εκδοχή αξιολόγησης και οι άδειες εκδόσεις του προϊόντος είναι η ίδια λήψη.

Όταν είστε ικανοποιημένοι με την αξιολόγηση, [αγοράστε μια άδεια](https://purchase.aspose.com/buy). Βεβαιωθείτε ότι κατανοείτε και συμφωνείτε με τους όρους συνδρομής.

Η άδεια είναι διαθέσιμη για λήψη από τη σελίδα παραγγελίας μετά την ολοκλήρωση της πληρωμής. Η άδεια είναι ένα αρχείο κειμένου, ψηφιακά υπογραμμισμένο XML που περιέχει πληροφορίες όπως το όνομα πελάτη, το αγορασμένο προϊόν και τον τύπο άδειας. Μην τροποποιήσετε το περιεχόμενο του αρχείου άδειας με οποιονδήποτε τρόπο: η τροποποίηση ακυρώνει την άδεια.

Κατεβάστε την άδεια στον υπολογιστή σας και αντιγράψτε τη στον κατάλληλο φάκελο (για παράδειγμα στον φάκελο της εφαρμογής σας ή **JasperReports\lib**).
{{% /alert %}}

## **Περιορισμός έκδοσης αξιολόγησης**
Η έκδοση αξιολόγησης του Aspose.Slides (χωρίς καθορισμένη άδεια) παρέχει πλήρη λειτουργικότητα του προϊόντος, αλλά (όταν αποθηκεύετε τις παρουσιάσεις σας) εισάγει ένα υδατογράφημα αξιολόγησης στο κέντρο κάθε διαφάνειας όπως φαίνεται στην παρακάτω εικόνα:

![todo:image_alt_text](evaluation_watermark.png) 

## **Εφαρμογή άδειας**
Υπάρχουν διάφοροι τρόποι για να εφαρμόσετε μια άδεια, ανάλογα με το αν εργάζεστε με JasperReports ή JasperServer.

### **Εφαρμογή άδειας για JasperReports**
Χρησιμοποιήστε απευθείας κλήση της μεθόδου setLicense παρόμοια με το Aspose.Slides για Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Δημιουργήστε ένα αντικείμενο ροής που περιέχει το αρχείο άδειας
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Δημιουργήστε μια παρουσία της κλάσης License
    License license = new License();
	
    //Ορίστε την άδεια μέσω του αντικειμένου ροής
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Ή, ορίστε την παράμετρο του εξαγωγέα στον κώδικα.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Εφαρμογή άδειας στο JasperServer**
Ορίστε την παράμετρο του εξαγωγέα στο applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
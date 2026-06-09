---
title: Αδειοδότηση
type: docs
weight: 50
url: /el/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Το Aspose.Slides for JasperReports διατίθεται ως δωρεάν αξιολόγηση χωρίς χρονικό περιορισμό από τη [σελίδα λήψης](https://downloads.aspose.com/slides/el/jasperreport). Η εκδοχή αξιολόγησης και οι αδειοδοτημένες εκδοχές του προϊόντος διανέμονται από την ίδια λήψη.

Όταν είστε ικανοποιημένοι με την αξιολόγηση, [αγοράστε άδεια](https://purchase.aspose.com/buy). Σιγουρευτείτε ότι καταλαβαίνετε και συμφωνείτε με τους όρους συνδρομής.

Η άδεια είναι διαθέσιμη για λήψη από τη σελίδα παραγγελίας μετά την πληρωμή της παραγγελίας. Η άδεια είναι ένα αρχείο XML απλού κειμένου, ψηφιακά υπογεγραμμένο, το οποίο περιέχει πληροφορίες όπως το όνομα του πελάτη, το αγορασμένο προϊόν και τον τύπο άδειας. Μην τροποποιήσετε το περιεχόμενο του αρχείου άδειας με οποιονδήποτε τρόπο: η τροποποίηση την ακυρώνει.

Κατεβάστε την άδεια στον υπολογιστή σας και αντιγράψτε την στο κατάλληλο φάκελο (π.χ. στο φάκελο της εφαρμογής σας ή **JasperReports\lib**).

## **Περιορισμός Έκδοσης Αξιολόγησης**
Η έκδοση αξιολόγησης του Aspose.Slides (χωρίς καθορισμένη άδεια) παρέχει πλήρη λειτουργικότητα του προϊόντος, αλλά (κατά την αποθήκευση των παρουσιάσεών σας) εισάγει ένα υδατογράφημα αξιολόγησης στο κέντρο κάθε διαφάνειας όπως φαίνεται στην παρακάτω εικόνα:

![todo:image_alt_text](evaluation_watermark.png) 

## **Εφαρμογή Άδειας**
Υπάρχουν πολλαπλοί τρόποι για την εφαρμογή άδειας, ανάλογα με το αν εργάζεστε με JasperReports ή JasperServer.

### **Εφαρμογή Άδειας για JasperReports**
Χρησιμοποιήστε μια άμεση κλήση της μεθόδου setLicense παρόμοια με το Aspose.Slides for Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Δημιουργεί ένα αντικείμενο ροής που περιέχει το αρχείο άδειας
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Δημιουργεί μια παρουσία της κλάσης License
    License license = new License();
	
    //Ορίζει την άδεια μέσω του αντικειμένου ροής
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Ή, ορίστε την παράμετρο exporter στον κώδικα.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Εφαρμογή Άδειας σε JasperServer**
Ορίστε την παράμετρο exporter στο applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
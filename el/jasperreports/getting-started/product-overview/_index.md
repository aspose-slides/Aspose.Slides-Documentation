---
title: Επισκόπηση προϊόντος
type: docs
weight: 10
url: /el/jasperreports/product-overview/
---
![Aspose.Slides για JasperReports](product-overview_1.png)

## **Καλώς ήρθατε στο Aspose.Slides για JasperReports!**

Aspose.Slides για JasperReports είναι μια βιβλιοθήκη ειδικά σχεδιασμένη και αναπτυγμένη για προγραμματιστές που χρειάζονται εύκολη εξαγωγή αναφορών από το JasperReports σε μορφές Microsoft PowerPoint Presentation (PPT) και Microsoft PowerPoint Show (PPS) στις εφαρμογές Java τους. Όλες οι δυνατότητες της αναφοράς μετατρέπονται με το υψηλότερο επίπεδο ακρίβειας σε παρουσιάσεις Microsoft PowerPoint. Το Aspose.Slides για JasperReports περιλαμβάνει υποστήριξη για JasperReports 5+.

## **Περιγραφή προϊόντος**
Το JasperReports και το JasperServer δεν διαθέτουν ενσωματωμένες δυνατότητες εξαγωγής αναφορών ως παρουσιάσεις Microsoft PowerPoint, αλλά το Aspose.Slides για JasperReports σας δίνει πρόσβαση σε δύο επιπλέον μορφές εξαγωγής:

- PPT – Παρουσίαση PowerPoint μέσω Aspose.Slides
- PPS – Παρουσίαση PowerPoint Show μέσω Aspose.Slides
- PPTX – Παρουσίαση PowerPoint μέσω Aspose.Slides
- PPSX – Παρουσίαση PowerPoint Show μέσω Aspose.Slides

Το Aspose.Slides για JasperReports χρησιμοποιεί εσωτερικά τις 100% καθαρές βιβλιοθήκες Java Aspose.Slides για Java και Aspose.Metafiles για Java, βιβλιοθήκες παγκόσμιας κλάσης για επεξεργασία παρουσιάσεων και μετααρχείων από τη μεριά του διακομιστή.

Το Aspose.Slides για JasperReports καθιστά δυνατόν τον εξαγωγή οποιασδήποτε αναφοράς σε μορφή PPT ή PPS.

### **Παράδειγμα εξόδου**
Η κλάση ASPptExporter κληρονομεί την κλάση ASAbstractExporter ώστε να μπορεί να χρησιμοποιηθεί με τον ίδιο τρόπο όπως οποιοσδήποτε άλλος τυπικός εξαγωγέας. Αυτό το σύντομο παράδειγμα δείχνει τυπικό κώδικα και στιγμιότυπο οθόνης μιας αναφοράς που προβλήθηκε στο MS PowerPoint. Αναλυτικά παραδείγματα μπορούν να βρεθούν στις παρεχόμενες δοκιμαστικές αναφορές.

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Παρουσίαση που δημιουργήθηκε με το demo xmldatasource του JasperReports** 

![Παρουσίαση που δημιουργήθηκε με JasperReports](product-overview_2.png)
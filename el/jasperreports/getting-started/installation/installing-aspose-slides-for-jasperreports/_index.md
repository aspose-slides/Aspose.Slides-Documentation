---
title: Εγκατάσταση Aspose.Slides για JasperReports
type: docs
weight: 40
url: /el/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Επιλέξτε τα αρχεία JAR του Aspose.Slides για JasperReports που ταιριάζουν με την έκδοση του JasperReports σας και προσθέστε τα στο JasperReports, σε ένα έργο Maven ή στο JasperReports Server."
---
## **Επιλέξτε τα αρχεία JAR για την έκδοση του JasperReports σας**

Το Aspose.Slides for JasperReports διανέμεται ως αρχείο ZIP στη [download page](https://releases.aspose.com/slides/jasperreport/). Ο φάκελος *lib* του περιέχει έναν υποφάκελο για κάθε εύρος εκδόσεων του JasperReports. Παίρνετε τα JAR από τον υποφάκελο που καλύπτει την έκδοση του JasperReports που χρησιμοποιείτε:

| Έκδοση JasperReports | Υποφάκελος του *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Δεν υπάρχει υποφάκελος για το JasperReports 6.17.0 ή νεότερο, συμπεριλαμβανομένου του JasperReports 7. Ο υποφάκελος *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* δεν περιέχει JAR, μόνο μια σημείωση ότι η υποστήριξη για αυτές τις εκδόσεις τερματίστηκε στο Aspose.Slides for JasperReports 17.6.

Κάθε υποφάκελος περιέχει δύο JAR· *xx.x* στα ονόματά τους είναι η έκδοση του προϊόντος:

- *aspose.slides.jasperreports.library-xx.x.jar* περιέχει τους εξαγωγείς για το JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` και `ASHtmlExporter`) και την κλάση `License`.
- *aspose.slides.jasperreports.server-xx.x.jar* περιέχει τις ενέργειες εξαγωγής για το JasperReports Server. Βασίζεται στο αρχείο βιβλιοθήκης, έτσι ο διακομιστής χρειάζεται πάντα και τα δύο JAR από τον ίδιο υποφάκελο.

## **Προσθέστε το αρχείο βιβλιοθήκης JAR στο JasperReports ή στην εφαρμογή σας**

Αντιγράψτε το *aspose.slides.jasperreports.library-xx.x.jar* από τον αντίστοιχο υποφάκελο στον φάκελο *lib* του JasperReports ή στο classpath της εφαρμογής σας. Η εφαρμογή σας μπορεί τότε να δημιουργήσει τους εξαγωγείς μέσω κώδικα.

{{% alert color="info" title="Note" %}}
Σε Linux, το JasperReports χρειάζεται fontconfig και τουλάχιστον μια εγκατεστημένη γραμματοσειρά για τη δημιουργία μιας αναφοράς. Χωρίς γραμματοσειρές, η δημιουργία αποτυγχάνει με το σφάλμα "Error initializing graphic environment".
{{% /alert %}}

## **Προσθέστε το αρχείο βιβλιοθήκης JAR σε ένα έργο Maven**

Το JAR περιλαμβάνεται στο ZIP και όχι σε αποθετήριο Maven. Για να το χρησιμοποιήσετε σε μια κατασκευή Maven, εγκαταστήστε το στο τοπικό αποθετήριο Maven. Για την έκδοση 26.6, εκτελέστε αυτή την εντολή στον φάκελο που περιέχει το JAR:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Στη συνέχεια, προσθέστε το στις εξαρτήσεις του *pom.xml*, μαζί με μια έκδοση JasperReports που καλύπτεται από τον υποφάκελο του JAR:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

Τα group και artifact ID είναι αυτά που επιλέξατε στην εντολή εγκατάστασης· πρέπει απλώς να ταιριάζουν. Ένα πλήρες έργο που χρησιμοποιεί το JasperReports 6.16.0 βρίσκεται στο [Η πρώτη σας εξαγωγή](/slides/el/jasperreports/#your-first-export).

## **Προσθέστε τα αρχεία JAR στο JasperReports Server**

Αντιγράψτε και τα δύο JAR από τον αντίστοιχο υποφάκελο στον φάκελο *WEB-INF/lib* της web εφαρμογής JasperReports Server, στη συνέχεια εγγραφείτε τους εξαγωγείς όπως περιγράφεται στην [Ενσωμάτωση με JasperServer](/slides/el/jasperreports/integration-with-jasperserver/).
---
title: Διαμόρφωση Demo
type: docs
weight: 70
url: /el/jasperreports/demos-setup/
description: "Ρυθμίστε τα έργα demo από τη λήψη Aspose.Slides for JasperReports, αλλάξτε την κλάση εξαγωγέα που χρησιμοποιούν και δημιουργήστε τα με Ant."
---
## **Τι είναι τα demo**

Ο φάκελος *samples* της λήψης Aspose.Slides for JasperReports περιέχει οκτώ έργα demo: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* και *xmldatasource*. Είναι τυπικά demo του JasperReports, που τροποποιήθηκαν ώστε να προσθέσουν έναν προορισμό κατασκευής `ppt` που εξάγει την γεμάτη αναφορά σε PPT. Η λήψη δεν περιέχει εξαγώμενες παρουσιάσεις· τις δημιουργείτε κατασκευάζοντας ένα demo.

## **Αλλάξτε την κλάση εξαγωγέα πριν τη δημιουργία**

Στην αρχική έκδοση, ο κώδικας Java των demo χρησιμοποιεί το `com.aspose.slides.jasperreports.JRPptExporter`, μια κλάση που δεν περιλαμβάνεται στα τρέχοντα αρχεία jar, επομένως τα demo δεν μεταγλωττίζονται. Στην κλάση εφαρμογής του demo (π.χ., *ShapesApp.java* στο demo *shapes*), αντικαταστήστε το `JRPptExporter` με το `ASPptExporter`, τον εξαγωγέα PPT στο ίδιο πακέτο. Το demo *fonts* εισάγει ολόκληρο το πακέτο, έτσι μόνο το όνομα της κλάσης στον κώδικά του αλλάζει.

Τα demo επίσης χρησιμοποιούν κλάσεις JasperReports που αφαιρέθηκαν σε μεταγενέστερες εκδόσεις, όπως το `JExcelApiExporter` και το `JRExporterParameter.FONT_MAP`. Με την παραπάνω αλλαγή, τα demo μεταγλωττίζονται ως εξής:

| Έκδοση JasperReports | Demo που μεταγλωττίζονται |
| :- | :- |
| 5.5.1 | όλα τα οκτώ |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* και *xmldatasource* |
| 6.16.0 | *charts* |

## **Κατασκευή demo**

Κάθε *build.xml* του demo αναμένει τη δομή φακέλων ενός έργου JasperReports: μεταγλωττίζει εναντίον του *../../../build/classes* και των αρχείων jar στο *../../../lib*, σχετικά με το φάκελο του demo.

1. Αντιγράψτε το φάκελο του demo στο *demo/samples* στο φάκελο έργου JasperReports.
2. Αντιγράψτε το *aspose.slides.jasperreports.library-xx.x.jar* από τον υποφάκελο *lib* της λήψης που ταιριάζει με την έκδοση του JasperReports σας στο φάκελο *lib* του έργου JasperReports. Δείτε [Εγκατάσταση Aspose.Slides για JasperReports](/slides/el/jasperreports/installing-aspose-slides-for-jasperreports/).
3. Τοποθετήστε το jar της έκδοσης του JasperReports σας και τα jar που εξαρτώνται από αυτό στον ίδιο φάκελο *lib*. Εκτός από τα αρχεία demo, το *build.xml* προσθέτει μόνο το *build/classes* και τα jar κάτω από *lib* στο classpath, και το *build/classes* περιέχει κλάσεις JasperReports μόνο μετά τη μεταγλώττιση του JasperReports από πηγαίο κώδικα.
4. Τα demo *charts*, *subreport* και *text* διαβάζουν τη δείγμα βάση δεδομένων HSQLDB του JasperReports (`jdbc:hsqldb:hsql://localhost`), επομένως ξεκινήστε πρώτα τον διακομιστή του, όπως περιγράφεται στο *samples/Readme.txt* της λήψης. Τα άλλα demo δεν απαιτούν βάση δεδομένων.
5. Στον φάκελο του demo, μεταγλωττίστε την εφαρμογή, μεταγλωττίστε το σχεδιασμό της αναφοράς, γεμίστε το και εξάγετε το σε PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

Ο προορισμός `ppt` γράφει την παρουσίαση δίπλα στην γεμάτη αναφορά, ονομασμένη όπως η αναφορά (π.χ., *LandscapeReport.ppt*).

Δύο demo απαιτούν περισσότερα από τα παραπάνω βήματα:

- Το demo *images* φορτώνει μια εικόνα από `http://jasperreports.sourceforge.net/jasperreports.png` κατά την εξαγωγή. Η διεύθυνση αυτή τώρα ανακατευθύνει σε HTTPS, έτσι το βήμα `ppt` δεν δημιουργεί παρουσίαση μέχρι να αλλάξετε τη διεύθυνση σε `https://` στο *ImagesReport.jrxml*. Με το JasperReports 6.4.0, η εξαγωγή αυτής της εικόνας αποτυγχάνει ακόμη κι μέσω HTTPS.
- Η αναφορά *xmldatasource* χρησιμοποιεί τη γραμματοσειρά Arial. Σε σύστημα χωρίς Arial, το `ant fill` εκτυπώνει ότι η γραμματοσειρά "is not available to the JVM" και δεν δημιουργεί γεμάτη αναφορά, επομένως το `ant ppt` δεν έχει κάτι να εξάγει. Η κατασκευή εξακολουθεί να αναφέρει επιτυχία, γι' αυτό ελέγξτε την έξοδο κάθε βήματος.
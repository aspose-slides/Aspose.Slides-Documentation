---
title: Πώς να Εκτελέσετε τα Παραδείγματα
type: docs
weight: 140
url: /el/php-java/how-to-run-the-examples/
keywords:
- παραδείγματα
- απαιτήσεις λογισμικού
- GitHub
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εκτελέστε γρήγορα τα παραδείγματα Aspose.Slides για PHP μέσω Java: κλωνοποιήστε το αποθετήριο, επαναφέρετε τα πακέτα, και στη συνέχεια δημιουργήστε και δοκιμάστε τις λειτουργίες για PPT, PPTX και ODP."
---
## **Λήψη από το GitHub**
Όλα τα παραδείγματα του Aspose.Slides για PHP μέσω Java φιλοξενούνται στο [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Μπορείτε είτε να κλωνοποιήσετε το αποθετήριο χρησιμοποιώντας τον αγαπημένο σας πελάτη Github, είτε να κατεβάσετε το αρχείο ZIP από [εδώ](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Εξαγάγετε τα περιεχόμενα του αρχείου ZIP σε οποιονδήποτε φάκελο στον υπολογιστή σας. Όλα τα παραδείγματα βρίσκονται στον φάκελο **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Εισαγωγή Παραδειγμάτων στο IDE**
Το έργο χρησιμοποιεί το σύστημα κατασκευής Maven. Οποιοδήποτε σύγχρονο IDE μπορεί εύκολα να ανοίξει ή να εισάγει το έργο και τις εξαρτήσεις του. Παρακάτω σας δείχνουμε πώς να χρησιμοποιήσετε δημοφιλή IDEs για να δημιουργήσετε και να εκτελέσετε τα παραδείγματα.

### **IntelliJ IDEA**
Κάντε κλικ στο μενού **File** και επιλέξτε **Open**. Περιηγηθείτε στο φάκελο του έργου και επιλέξτε το αρχείο **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Θα ανοίξει το έργο και θα κατεβάσει τις εξαρτήσεις αυτόματα. Από την καρτέλα Project, περιηγηθείτε στα παραδείγματα στο φάκελο **src/main/java**. Για να εκτελέσετε ένα παράδειγμα, κάντε δεξί κλικ στο αρχείο και επιλέξτε "Run ..", το παράδειγμα θα εκτελεστεί και η έξοδος θα εμφανιστεί στο ενσωματωμένο παράθυρο εξόδου της κονσόλας.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Κάντε κλικ στο μενού **File** και επιλέξτε **Import**. Επιλέξτε **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Περιηγηθείτε στο φάκελο που κλωνοποιήσατε ή κατεβάσατε από το GitHub και επιλέξτε το αρχείο **pom.xml**. Θα ανοίξει το έργο και θα κατεβάσει τις εξαρτήσεις αυτόματα. Από την καρτέλα Package Explorer, περιηγηθείτε στα παραδείγματα στο φάκελο **src/main/java**. Για να εκτελέσετε ένα παράδειγμα, κάντε δεξί κλικ στο αρχείο και επιλέξτε **Run As** - **Java Application**, το παράδειγμα θα εκτελεστεί και η έξοδος θα εμφανιστεί στο ενσωματωμένο παράθυρο εξόδου της κονσόλας.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Κάντε κλικ στο μενού **File** και επιλέξτε **Open Project**. Περιηγηθείτε στο φάκελο που κλωνοποιήσατε ή κατεβάσατε από το GitHub. Το εικονίδιο του φακέλου **Examples** θα δείξει ότι είναι ένα έργο Maven. Επιλέξτε το Examples και ανοίξτε το.

![todo:image_alt_text](netbeans_openproject.png)

Θα ανοίξει το έργο και θα κατεβάσει τις εξαρτήσεις αυτόματα. Από την καρτέλα Projects, περιηγηθείτε στα παραδείγματα στα **source packages**. Για να εκτελέσετε ένα παράδειγμα, κάντε δεξί κλικ στο αρχείο και επιλέξτε **Run File**, το παράδειγμα θα εκτελεστεί και η έξοδος θα εμφανιστεί στο ενσωματωμένο παράθυρο εξόδου της κονσόλας.

![todo:image_alt_text](netbeans_run_example.png)

## **Προσθήκη Βιβλιοθήκης Aspose.Slides στο Τοπικό Αποθετήριο Maven**
Όταν εισάγετε το έργο **Aspose.Slides Examples** στο IDE, το Maven κατεβάζει αυτόματα το αρχείο JAR aspose.slides από το [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). Σε περίπτωση που δεν έχετε πρόσβαση στο διαδίκτυο, μπορείτε να προσθέσετε χειροκίνητα το JAR στο τοπικό σας αποθετήριο.

### **mvn install**
Κατεβάστε το [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/), εξάγετε το και αντιγράψτε το αρχείο aspose.slides-version.jar κάπου αλλού, για παράδειγμα, στον δίσκο c. Εκτελέστε την παρακάτω εντολή:

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

Τώρα, το αρχείο **aspose.slides** jar έχει αντιγραφεί στο τοπικό αποθετήριο Maven.

### **pom.xml**
Μετά την εγκατάσταση, απλώς δηλώνετε την συντεταγμένη **aspose.slides** στο pom.xml. Προσθέστε το παρακάτω αποθετήριο στην καρτέλα repositories και την εξάρτηση στην καρτέλα dependencies.

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

```

### **Ολοκληρώθηκε**
Κατασκευάστε το, τώρα το αρχείο **aspose.slides** jar μπορεί να ληφθεί από το τοπικό σας αποθετήριο Maven.

## **Συμβάλε**
Αν θέλετε να προσθέσετε ή να βελτιώσετε ένα παράδειγμα, σας ενθαρρύνουμε να συνεισφέρετε στο έργο. Όλα τα παραδείγματα και τα showcase projects σε αυτό το αποθετήριο είναι ανοιχτού κώδικα και μπορούν να χρησιμοποιηθούν ελεύθερα στις δικές σας εφαρμογές.

Για να συνεισφέρετε, μπορείτε να κάνετε fork το αποθετήριο, να επεξεργαστείτε τον πηγαίο κώδικα και να υποβάλετε ένα Pull Request. Θα εξετάσουμε τις αλλαγές και θα τις ενσωματώσουμε στο αποθετήριο εάν θεωρηθούν χρήσιμες.
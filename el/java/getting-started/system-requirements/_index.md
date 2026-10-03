---
title: Απαιτήσεις Συστήματος
type: docs
weight: 60
url: /el/java/system-requirements/
keywords:
- απαιτήσεις συστήματος
- υποστηριζόμενες πλατφόρμες
- εκδόσεις Java
- JDK
- JRE
- fontconfig
- γραμματοσειρές
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ελέγξτε τι χρειάζεται το Aspose.Slides for Java πριν το εγκαταστήσετε: οι υποστηριζόμενες εκδόσεις Java και λειτουργικά συστήματα, καθώς και η βιβλιοθήκη γραμματοσειρών και οι γραμματοσειρές που απαιτούνται από το Linux."
---
## **Εισαγωγή**

Το Aspose.Slides for Java είναι μια ανεξάρτητη βιβλιοθήκη: δεν χρειάζεται το Microsoft PowerPoint ούτε το Microsoft Office. Είναι ένα μόνο αρχείο JAR, που δημοσιεύεται στο αποθετήριο Maven της Aspose. Το αρχείο JAR περιέχει μόνο κλάσεις και πόρους Java, χωρίς εγγενείς βιβλιοθήκες, και δεν δηλώνει εξαρτήσεις από άλλες βιβλιοθήκες. Το ίδιο αρχείο επομένως εκτελείται σε κάθε λειτουργικό σύστημα και επεξεργαστή για τους οποίους υπάρχει υποστηριζόμενη εκτέλεση Java.

Αυτό το άρθρο παραθέτει τις υποστηριζόμενες εκδόσεις Java και λειτουργικά συστήματα καθώς και τη βιβλιοθήκη γραμματοσειρών και τις γραμματοσειρές που απαιτεί το Linux, και κλείνει με ένα σύντομο πρόγραμμα που ελέγχει τη ρύθμισή σας. Για να προσθέσετε τη βιβλιοθήκη σε ένα έργο, δείτε [Εγκατάσταση](/slides/el/java/installation/).

## **Υποστηριζόμενες Εκδόσεις Java**

Το Aspose.Slides for Java λειτουργεί σε Java 8 ή νεότερη, με JDK ή JRE. Αυτό περιλαμβάνει τις εκδόσεις υποστήριξης μακροπρόθεσμης συντήρησης Java 8, 11, 17, 21 και 25, καθώς και μεταγενέστερες εκδόσεις όπως Java 26 και Java 27. Η εκτέλεση Java μπορεί να προέρχεται από οποιονδήποτε προμηθευτή, για παράδειγμα Eclipse Temurin, Amazon Corretto, Oracle ή τα πακέτα OpenJDK μιας διανομής Linux.

Το Aspose.Slides δεν χρειάζεται επιλογές JVM, όπως `--add-opens`, σε καμία από αυτές τις εκδόσεις. Σε Java 11, η JVM εκτυπώνει μια προειδοποίηση που αρχίζει με «WARNING: An illegal reflective access operation has occurred»· η προειδοποίηση δεν επηρεάζει το αποτέλεσμα.

{{% alert color="warning" title="Warning" %}}
Java 6 και Java 7 είναι παρωχημένες. Το Aspose.Slides for Java 26.9 εξακολουθεί να λειτουργεί σε αυτές αλλά εμφανίζει προειδοποίηση αποσυγχώρησης. Ξεκινώντας από την έκδοση 26.10, η ελάχιστη έκδοση είναι Java 8, και οι Java 6 και Java 7 δεν υποστηρίζονται πλέον.
{{% /alert %}}

Το έργο Maven και οι εντολές στο [Εγκατάσταση](/slides/el/java/installation/) απαιτούν JDK 11 ή νεότερο. Με Java 8, μεταγλωττίστε και εκτελέστε το πρόγραμμα όπως φαίνεται στο [Έλεγχος Ρύθμισης](#check-your-setup).

## **Υποστηριζόμενα Λειτουργικά Συστήματα**

Επειδή το αρχείο JAR δεν περιέχει εγγενή κώδικα, το Aspose.Slides for Java λειτουργεί σε Windows, Linux και macOS, σε οποιαδήποτε αρχιτεκτονική επεξεργαστή που υποστηρίζει η εκτέλεση Java, όπως x64 και ARM64. Η εκτέλεση Java είναι η μόνη απαίτηση στα Windows. Σε Linux, η υποστήριξη γραμματοσειρών της Java χρειάζεται επίσης τη βιβλιοθήκη γραμματοσειρών και τις γραμματοσειρές που περιγράφονται στο [Linux](#linux).

## **Linux**

Το Aspose.Slides for Java διατάζει και σχεδιάζει κείμενο με την υποστήριξη γραμματοσειρών της εκτέλεσης Java. Σε Linux, αυτή η υποστήριξη απαιτεί τη βιβλιοθήκη fontconfig και τουλάχιστον μία εγκατεστημένη γραμματοσειρά. Τα επίσημα images κοντέινερ διανομών Linux συχνά δεν τα περιέχουν. Χωρίς αυτά, το πρώτο παράδειγμα στο [Create Presentations](/slides/el/java/create-presentation/) αποτυγχάνει όταν αποθηκεύει την παρουσίαση, αφήνει κενό αρχείο και αναφέρει το εξής σφάλμα:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Τα επίσημα images `eclipse-temurin` για Ubuntu και για Alpine Linux περιέχουν ήδη το fontconfig και τις γραμματοσειρές DejaVu, οπότε δεν χρειάζεται να εγκατασταθεί τίποτα. Σε άλλα συστήματα, εγκαταστήστε τα πακέτα παρακάτω. Οι εντολές για Debian, Ubuntu και Red Hat χρησιμοποιούν `sudo`; σε Dockerfile, εκτελέστε τες σε εντολή `RUN` χωρίς `sudo`. Οι γραμματοσειρές DejaVu αρκούν για την εκτέλεση του Aspose.Slides· οι γραμματοσειρές που χρησιμοποιούν οι παρουσιάσεις σας καλύπτονται στο [Fonts](#fonts).

### **Debian και Ubuntu**

Αν εγκαταστήσετε τη Java από τα πακέτα Debian ή Ubuntu με τις προεπιλεγμένες ρυθμίσεις `apt-get`, όπως κάνει η εντολή στο [Εγκατάσταση](/slides/el/java/installation/#linux), τα πακέτα Java εγκαθιστούν επίσης τη βιβλιοθήκη fontconfig, τις γραμματοσειρές DejaVu και τη βιβλιοθήκη HarfBuzz που χρειάζονται αυτά τα πακέτα, και δεν απαιτείται κάτι άλλο.

Με εκτέλεση Java από άλλη πηγή, όπως ένα αρχείο Eclipse Temurin, εγκαταστήστε fontconfig και τις γραμματοσειρές DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Ένα Dockerfile συχνά εγκαθιστά τα πακέτα Java Debian ή Ubuntu, όπως `openjdk-21-jdk-headless` ή `default-jdk-headless`, με την επιλογή `--no-install-recommends`, η οποία παραλείπει και τα τρία. Εγκαταστήστε fontconfig και τις γραμματοσειρές DejaVu με την εντολή παραπάνω, και εγκαταστήστε επίσης το HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Χωρίς HarfBuzz, αυτά τα πακέτα Java εκτυπώνουν το μήνυμα «Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless», και η αποθήκευση αποτυγχάνει με `UnsatisfiedLinkError` που αναφέρει ότι δεν μπορεί να ανοιχτεί το `libharfbuzz.so.0`.

### **Red Hat Enterprise Linux**

Τα πακέτα `java-<version>-openjdk-headless` του Red Hat Enterprise Linux δεν εγκαθιστούν τη βιβλιοθήκη fontconfig. Εγκαταστήστε τη μαζί με τις γραμματοσειρές DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Τα πλήρη πακέτα `java-<version>-openjdk` εγκαθιστούν fontconfig και γραμματοσειρές ως εξαρτήσεις, όπως κάνουν και τα πακέτα Amazon Corretto του Amazon Linux 2023, π.χ. `java-21-amazon-corretto-headless`.

### **Alpine Linux**

Σε Dockerfile βασισμένο σε Alpine Linux, εγκαταστήστε fontconfig και τις γραμματοσειρές DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Σε τρέχουσες εκδόσεις Alpine, το `ttf-dejavu` εγκαθιστά το πακέτο `font-dejavu`. Εγκαταστήστε Java με το πακέτο `openjdk<version>-jre` ή `openjdk<version>-jdk`, π.χ. `openjdk25-jdk`. Τα πακέτα `openjdk<version>-jre-headless` του Alpine δεν περιέχουν τη βιβλιοθήκη γραμματοσειρών της Java, οπότε με αυτά το πρόγραμμα αποτυγχάνει με `UnsatisfiedLinkError: no fontmanager in system library path`, ακόμη και αν οι γραμματοσειρές είναι εγκατεστημένες.

### **Γραμματοσειρές**

Για να αποτυπώνονται τα κείμενα με τις σωστές γραμματοσειρές και μετρήσεις, οι γραμματοσειρές που χρησιμοποιούν οι παρουσιάσεις σας, ή κατάλληλες εναλλακτικές, πρέπει να είναι εγκατεστημένες στο σύστημα ή να φορτώνονται από την εφαρμογή σας. Δείτε το [Deploy Fonts](/slides/el/java/deploy-fonts/), το [Font Substitution](/slides/el/java/font-substitution/) και το [Custom Fonts](/slides/el/java/custom-font/).

## **Έλεγχος Ρύθμισης**

Για να ελέγξετε ότι η βιβλιοθήκη και οι προαπαιτούμενες εξαρτήσεις υπάρχουν, εκτελέστε ένα πρόγραμμα που αποθηκεύει μια παρουσίαση και αποδίδει μια διαφάνεια σε εικόνα. Η αποθήκευση και η απόδοση χρησιμοποιούν την υποστήριξη γραμματοσειρών της εκτέλεσης Java, που παρέχεται από τις παραπάνω απαιτήσεις Linux.

Αποθηκεύστε τον κώδικα παρακάτω ως *CheckSetup.java* στον φάκελο που περιέχει το αρχείο JAR του Aspose.Slides. Για λήψη του αρχείου JAR, δείτε [Use the JAR File without Maven](/slides/el/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Προσθέστε ένα ορθογώνιο με κείμενο στην πρώτη διαφάνεια και αποθηκεύστε την παρουσίαση.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Αποδώστε τη διαφάνεια με ένα pixel ανά σημείο και αποθηκεύστε την εικόνα.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

Με JDK 11 ή νεότερο, εκτελέστε το πρόγραμμα στον φάκελο αυτό με την εντολή παρακάτω. Αν το αρχείο JAR έχει διαφορετικό όνομα, αλλάξτε το όνομα στις εντολές.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Με Java 8, ή σε σύστημα που έχει μόνο JRE, μεταγλωττίστε το πρόγραμμα με `javac` από ένα JDK και, στη συνέχεια, εκτελέστε την κλασική. Σε Linux και macOS, τρέξτε:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

Σε Windows, τρέξτε την ίδια εντολή `javac`, και μετά εκτελέστε την κλάση με το ελληνικό ερωτηματικό ως διαχωριστικό διαδρομών κλάσεων. Κρατήστε τα εισαγωγικά, ώστε το PowerShell να μην θεωρήσει το ερωτηματικό ως τέλος της εντολής: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

Το πρόγραμμα προσθέτει ένα ορθογώνιο με κείμενο στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση ως *hello.pptx* με τη μέθοδο [save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Στη συνέχεια αποδίδει τη διαφάνεια με το [getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/slide/#getImage-float-float-) και αποθηκεύει το αποτέλεσμα ως *hello.png* με το [IImage.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/iimage/#save-java.lang.String-int-) σε μορφή [ImageFormat.Png](https://reference.aspose.com/slides/el/java/com.aspose.slides/imageformat/). Οι παράγοντες κλίμακας 1 αποδίδουν ένα pixel ανά σημείο, έτσι η προεπιλεγμένη διαφάνεια 720 × 540 σημείων γίνεται εικόνα 720 × 540 pixel, με το κείμενο ορατό μέσα στο ορθογώνιο. Χωρίς άδεια, και τα δύο αρχεία φέρουν υδατογράφημα αξιολόγησης· δείτε το [Licensing](/slides/el/java/licensing/). Αν λείπει κάποια απαίτηση, το πρόγραμμα σταματάει με ένα από τα σφάλματα που περιγράφονται στο [Linux](#linux).

## **Εργαλεία Ανάπτυξης**

Μπορείτε να δημιουργήσετε εφαρμογές που χρησιμοποιούν Aspose.Slides με οποιοδήποτε JDK υποστηριζόμενης έκδοσης Java. Χρησιμοποιήστε Apache Maven με το αποθετήριο Maven της Aspose, όπως περιγράφεται στην [Εγκατάσταση](/slides/el/java/installation/), ή οποιοδήποτε άλλο εργαλείο κατασκευής που μπορεί να χρησιμοποιήσει αποθετήριο Maven. Μπορείτε επίσης να προσθέσετε το αρχείο JAR στην διαδρομή κλάσεων του IDE ή του εργαλείου κατασκευής σας.

## **Συχνές Ερωτήσεις**

**Χρειάζεται το Microsoft PowerPoint να είναι εγκατεστημένο για μετατροπές και απόδοση;**

Όχι, το PowerPoint δεν απαιτείται. Το Aspose.Slides είναι μια αυτόνομη μηχανή για [δημιουργία](/slides/el/java/create-presentation/), τροποποίηση, [μετατροπή](/slides/el/java/convert-presentation/) και [απόδοση](/slides/el/java/convert-powerpoint-to-png/) παρουσιάσεων.

**Χρειάζεται το Aspose.Slides for Java κάποιον προβάλλον οθόνης ή desktop σε διακομιστή Linux;**

Όχι. Το Aspose.Slides δεν χρειάζεται X server ή οθόνη, οπότε λειτουργεί σε διακομιστές και κοντέινερ. Σε Linux, χρειάζεται μόνο τη βιβλιοθήκη γραμματοσειρών και τις γραμματοσειρές που περιγράφονται στο [Linux](#linux).

**Ποιες γραμματοσειρές απαιτούνται για σωστή απόδοση;**

Οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση, ή κατάλληλες [εναλλακτικές](/slides/el/java/font-substitution/), πρέπει να είναι διαθέσιμες. Σε Linux και macOS, εγκαταστήστε τα πακέτα γραμματοσειρών που χρειάζονται οι παρουσιάσεις σας για σταθερή απόδοση.

**Γιατί μια προσαρμοσμένη γραμματοσειρά εμφανίζεται ως εναλλακτική ή λείπουν κείμενα σε Linux;**

Αν το αρχείο γραμματοσειράς έχει ασυνεπείς ή κατεστραμμένες καταχωρήσεις στον πίνακα ονομάτων, η στοίβα αντιστοίχισης γραμματοσειρών του Linux (FreeType/fontconfig) μπορεί να επιλέξει μια μη έγκυρη εγγραφή, με αποτέλεσμα η γραμματοσειρά να μην αναγνωρίζεται. Η χρήση μιας έκδοσης γραμματοσειράς με διορθωμένες καταχωρήσεις ή η εγκατάσταση μιας συνεπούς αντικατάστασης λύνει το πρόβλημα.
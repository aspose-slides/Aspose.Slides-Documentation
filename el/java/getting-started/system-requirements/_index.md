---
title: "Απαιτήσεις Συστήματος"
type: docs
weight: 60
url: /el/java/system-requirements/
keywords:
- "απαιτήσεις συστήματος"
- "υποστηριζόμενες πλατφόρμες"
- "εκδόσεις Java"
- JDK
- JRE
- fontconfig
- "γραμματοσειρές"
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
description: "Ελέγξτε τι χρειάζεται το Aspose.Slides for Java πριν το εγκαταστήσετε: οι υποστηριζόμενες εκδόσεις Java και λειτουργικά συστήματα, καθώς και η βιβλιοθήκη γραμματοσειρών και οι γραμματοσειρές που απαιτεί το Linux."
---
## **Εισαγωγή**

Aspose.Slides for Java είναι μια ανεξάρτητη βιβλιοθήκη: δεν απαιτεί Microsoft PowerPoint ή Microsoft Office. Είναι ένα μοναδικό αρχείο JAR, που δημοσιεύεται στο αποθετήριο Maven της Aspose. Το αρχείο JAR περιέχει μόνο κλάσεις Java και πόρους, χωρίς εγγενείς βιβλιοθήκες, και δεν δηλώνει εξαρτήσεις από άλλες βιβλιοθήκες. Έτσι το ίδιο αρχείο τρέχει σε κάθε λειτουργικό σύστημα και επεξεργαστή για τους οποίους είναι διαθέσιμη μια υποστηριζόμενη Java runtime.

Αυτό το άρθρο παραθέτει τις υποστηριζόμενες εκδόσεις Java και λειτουργικά συστήματα καθώς και τη βιβλιοθήκη γραμματοσειρών και τις γραμματοσειρές που χρειάζεται το Linux, και καταλήγει με ένα μικρό πρόγραμμα που ελέγχει τη ρύθμιση σας. Για να προσθέσετε τη βιβλιοθήκη σε ένα έργο, δείτε [Εγκατάσταση](/slides/el/java/installation/).

## **Υποστηριζόμενες Εκδόσεις Java**

Aspose.Slides for Java λειτουργεί σε Java 8 ή νεότερη, με JDK ή JRE. Περιλαμβάνει τις εκδόσεις μακροπρόθεσμης υποστήριξης Java 8, 11, 17, 21 και 25, καθώς και μεταγενέστερες εκδόσεις όπως Java 26 και Java 27. Η Java runtime μπορεί να προέρχεται από οποιονδήποτε προμηθευτή, π.χ. Eclipse Temurin, Amazon Corretto, Oracle ή τα πακέτα OpenJDK μιας διανομής Linux.

Το Aspose.Slides δεν χρειάζεται επιλογές JVM, όπως `--add-opens`, σε καμία από αυτές τις εκδόσεις. Στη Java 11, η JVM εκτυπώνει μια προειδοποίηση που αρχίζει με "WARNING: An illegal reflective access operation has occurred"· η προειδοποίηση δεν επηρεάζει το αποτέλεσμα.

{{% alert color="warning" title="Warning" %}}
Η Java 6 και η Java 7 είναι παρωχημένες. Το Aspose.Slides for Java 26.9 εξακολουθεί να λειτουργεί σε αυτές αλλά εκτυπώνει προειδοποίηση παρωνημέρωσης. Ξεκινώντας από την έκδοση 26.10, η ελάχιστη έκδοση είναι η Java 8, και η Java 6 και η Java 7 δεν υποστηρίζονται πια.
{{% /alert %}}

Το Maven project και οι εντολές στο [Εγκατάσταση](/slides/el/java/installation/) απαιτούν JDK 11 ή νεότερο. Με Java 8, μεταγλωττίστε και εκτελέστε το πρόγραμμα όπως φαίνεται στο [Ελέγξτε τη Ρύθμιση](#check-your-setup).

## **Υποστηριζόμενα Λειτουργικά Συστήματα**

Επειδή το αρχείο JAR δεν περιέχει εγγενή κώδικα, το Aspose.Slides for Java λειτουργεί σε Windows, Linux και macOS, σε οποιαδήποτε αρχιτεκτονική επεξεργαστή που υποστηρίζει η Java runtime, όπως x64 και ARM64. Η Java runtime είναι η μόνη απαίτηση στα Windows. Στο Linux, η υποστήριξη γραμματοσειρών της Java απαιτεί επίσης τη βιβλιοθήκη γραμματοσειρών και τις γραμματοσειρές που περιγράφονται στο [Linux](#linux).

## **Linux**

Το Aspose.Slides for Java τοποθετεί και σχεδιάζει κείμενο με την υποστήριξη γραμματοσειρών της Java runtime. Στο Linux, αυτή η υποστήριξη απαιτεί τη βιβλιοθήκη fontconfig και τουλάχιστον μία εγκατεστημένη γραμματοσειρά. Τα επίσημα images κοντέινερ διανομών Linux συχνά δεν τα έχουν. Χωρίς αυτά, το πρώτο παράδειγμα στο [Δημιουργία Παρουσιασών](/slides/el/java/create-presentation/) αποτυγχάνει όταν αποθηκεύει την παρουσίαση, αφήνει κενό αρχείο και αναφέρει το σφάλμα:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Τα επίσημα images κοντέινερ `eclipse-temurin`, για Ubuntu και για Alpine Linux, περιλαμβάνουν ήδη το fontconfig και τις γραμματοσειρές DejaVu, οπότε δεν χρειάζεται να εγκατασταθεί τίποτα. Σε άλλα συστήματα, εγκαταστήστε τα παρακάτω πακέτα. Οι εντολές για Debian, Ubuntu και Red Hat χρησιμοποιούν `sudo`; σε Dockerfile, εκτελέστε τις σε οδηγία `RUN` χωρίς `sudo`. Οι γραμματοσειρές DejaVu αρκούν για τη λειτουργία του Aspose.Slides· οι γραμματοσειρές που χρησιμοποιούν οι παρουσιάσεις σας καλύπτονται στο [Γραμματοσειρές](#fonts).

### **Debian και Ubuntu**

Εάν εγκαταστήσετε τη Java από τα πακέτα Debian ή Ubuntu με τις προεπιλεγμένες ρυθμίσεις `apt-get`, όπως κάνει η εντολή στο [Εγκατάσταση](/slides/el/java/installation/#linux), τα πακέτα Java εγκαθιστούν επίσης τη βιβλιοθήκη fontconfig, τις γραμματοσειρές DejaVu και τη βιβλιοθήκη HarfBuzz που χρειάζονται αυτά τα πακέτα Java, και δεν απαιτείται τίποτα άλλο.

Με μια Java runtime από άλλη πηγή, όπως ένα αρχείο Eclipse Temurin, εγκαταστήστε το fontconfig και τις γραμματοσειρές DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Ένα Dockerfile συχνά εγκαθιστά τα πακέτα Java του Debian ή Ubuntu, όπως `openjdk-21-jdk-headless` ή `default-jdk-headless`, με την επιλογή `--no-install-recommends`, η οποία παραλείπει και τα τρία. Εγκαταστήστε το fontconfig και τις γραμματοσειρές DejaVu με την παραπάνω εντολή, και εγκαταστήστε επίσης το HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Χωρίς το HarfBuzz, αυτά τα πακέτα Java εκτυπώνουν `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, και η αποθήκευση αποτυγχάνει με ένα `UnsatisfiedLinkError` που αναφέρει ότι δεν μπορεί να ανοιχθεί το `libharfbuzz.so.0`.

### **Red Hat Enterprise Linux**

Τα πακέτα `java-<version>-openjdk-headless` του Red Hat Enterprise Linux δεν εγκαθιστούν τη βιβλιοθήκη fontconfig. Εγκαταστήστε την μαζί με τις γραμματοσειρές DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Τα πλήρη πακέτα `java-<version>-openjdk` εγκαθιστούν το fontconfig και τις γραμματοσειρές ως εξαρτήσεις, όπως επίσης και τα πακέτα Amazon Corretto του Amazon Linux 2023, όπως το `java-21-amazon-corretto-headless`.

### **Alpine Linux**

Σε ένα Dockerfile βασισμένο στο Alpine Linux, εγκαταστήστε το fontconfig και τις γραμματοσειρές DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Στις τρέχουσες εκδόσεις του Alpine, το `ttf-dejavu` εγκαθιστά το πακέτο `font-dejavu`. Εγκαταστήστε τη Java με το πακέτο `openjdk<version>-jre` ή `openjdk<version>-jdk`, όπως `openjdk25-jdk`. Τα πακέτα `openjdk<version>-jre-headless` του Alpine Linux δεν περιέχουν τη βιβλιοθήκη γραμματοσειρών της Java, έτσι με αυτά το πρόγραμμα αποτυγχάνει με `UnsatisfiedLinkError: no fontmanager in system library path`, ακόμα και όταν οι γραμματοσειρές είναι εγκατεστημένες.

### **Γραμματοσειρές**

Για το κείμενο να αποδίδεται με τις σωστές γραμματοσειρές και μετρικές, οι γραμματοσειρές που χρησιμοποιούν οι παρουσιάσεις σας, ή κατάλληλες εναλλακτικές, πρέπει να είναι εγκατεστημένες στο σύστημα ή να φορτώνονται από την εφαρμογή σας. Δείτε [Ανάπτυξη Γραμματοσειρών](/slides/el/java/deploy-fonts/), [Αντικατάσταση Γραμματοσειράς](/slides/el/java/font-substitution/), και [Προσαρμοσμένες Γραμματοσειρές](/slides/el/java/custom-font/).

## **Έλεγχος Ρύθμισης**

Για να ελέγξετε ότι η βιβλιοθήκη και οι απαιτήσεις της είναι σε θέση, εκτελέστε ένα πρόγραμμα που αποθηκεύει μια παρουσίαση και αποδίδει μια διαφάνεια σε εικόνα. Η αποθήκευση και η απόδοση χρησιμοποιούν την υποστήριξη γραμματοσειρών της Java runtime, η οποία παρέχεται από τις παραπάνω απαιτήσεις του Linux.

Αποθηκεύστε τον κώδικα παρακάτω ως *CheckSetup.java* στον φάκελο που περιέχει το αρχείο JAR του Aspose.Slides. Για λήψη του αρχείου JAR, δείτε [Χρησιμοποιήστε το Αρχείο JAR χωρίς Maven](/slides/el/java/installation/#use-the-jar-file-without-maven).

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

Με JDK 11 ή νεότερο, εκτελέστε το πρόγραμμα σε αυτόν το φάκελο με την παρακάτω εντολή. Εάν το αρχείο JAR σας έχει διαφορετικό όνομα, αλλάξτε το όνομα στις εντολές.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Με Java 8, ή σε σύστημα που έχει μόνο JRE, μεταγλωττίστε το πρόγραμμα με `javac` από ένα JDK και στη συνέχεια εκτελέστε την μεταγλωττισμένη κλάση. Σε Linux και macOS, εκτελέστε:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

Σε Windows, εκτελέστε την ίδια εντολή `javac`, και στη συνέχεια εκτελέστε την κλάση με άνω-κάτω τελεία ως διαχωριστικό διαδρομών κλάσης. Διατηρήστε τα εισαγωγικά, ώστε το PowerShell να μην θεωρήσει την άνω-κάτω τελεία ως τέλος της εντολής: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

Το πρόγραμμα προσθέτει ένα ορθογώνιο με κείμενο στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση ως *hello.pptx* με τη μέθοδο [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Στη συνέχεια αποδίδει τη διαφάνεια με [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) και αποθηκεύει το αποτέλεσμα ως *hello.png* με [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) στη μορφή [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/). Οι συντελεστές κλίμακας 1 αποδίδουν ένα pixel ανά σημείο, έτσι η προεπιλεγμένη διαφάνεια 720 × 540 σημείων γίνεται εικόνα 720 × 540 pixel, με το κείμενο ορατό μέσα στο ορθογώνιο. Χωρίς άδεια, και τα δύο αρχεία φέρουν υδατογράφημα αξιολόγησης· δείτε [Αδειοδότηση](/slides/el/java/licensing/). Εάν λείπει κάποια απαίτηση, το πρόγραμμα διακόπτεται με ένα από τα σφάλματα που περιγράφονται στο [Linux](#linux).

## **Εργαλεία Ανάπτυξης**

Μπορείτε να δημιουργείτε εφαρμογές που χρησιμοποιούν το Aspose.Slides με οποιοδήποτε JDK υποστηριζόμενης έκδοσης Java. Χρησιμοποιήστε το Apache Maven με το Maven αποθετήριο της Aspose, όπως περιγράφεται στην [Εγκατάσταση](/slides/el/java/installation/), ή οποιοδήποτε άλλο εργαλείο κατασκευής που μπορεί να χρησιμοποιήσει Maven αποθετήριο. Μπορείτε επίσης να προσθέσετε το αρχείο JAR στο class path του IDE ή του εργαλείου κατασκευής σας.

## **Συχνές Ερωτήσεις**

**Χρειάζεται να είναι εγκατεστημένο το Microsoft PowerPoint για μετατροπές και απόδοση;**

Όχι, το PowerPoint δεν απαιτείται. Το Aspose.Slides είναι μια αυτόνομη μηχανή για [δημιουργία](/slides/el/java/create-presentation/), τροποποίηση, [μετατροπή](/slides/el/java/convert-presentation/), και [απόδοση](/slides/el/java/convert-powerpoint-to-png/) παρουσιάσεων.

**Χρειάζεται το Aspose.Slides for Java μια οθόνη ή περιβάλλον επιφάνειας εργασίας σε διακομιστή Linux;**

Όχι. Το Aspose.Slides δεν χρειάζεται X server ή οθόνη, έτσι τρέχει σε διακομιστές και κοντέινερ. Σε Linux, χρειάζεται μόνο τη βιβλιοθήκη γραμματοσειρών και τις γραμματοσειρές που περιγράφονται στο [Linux](#linux).

**Ποιες γραμματοσειρές απαιτούνται για σωστή απόδοση;**

Οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση, ή κατάλληλες [αντικαταστάσεις](/slides/el/java/font-substitution/), πρέπει να είναι διαθέσιμες. Σε Linux και macOS, εγκαταστήστε τα πακέτα γραμματοσειρών που χρειάζονται οι παρουσιάσεις σας για σταθερή απόδοση.

**Γιατί μια προσαρμοσμένη γραμματοσειρά αποδίδεται ως εναλλακτική ή κείμενο που λείπει στο Linux;**

Εάν το αρχείο γραμματοσειράς έχει ασυνεπή ή κατεστραμμένα στοιχεία πίνακα ονομάτων, η στοίβα αντιστοίχισης γραμματοσειρών του Linux (FreeType/fontconfig) μπορεί να επιλέξει μη έγκυρη εγγραφή, προκαλώντας την μη αναγνώριση της γραμματοσειράς. Η χρήση μιας έκδοσης γραμματοσειράς με διορθωμένα στοιχεία πίνακα ονομάτων ή η εγκατάσταση μιας συνεπούς εναλλακτικής λύνει το πρόβλημα.
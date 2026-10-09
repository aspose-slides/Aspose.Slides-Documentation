---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/java/installation/
keywords:
- εγκατάσταση Aspose.Slides
- λήψη Aspose.Slides
- χρήση Aspose.Slides
- Εγκατάσταση Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εγκαταστήστε το Aspose.Slides for Java από το αποθετήριο Maven της Aspose ή ως αρχείο JAR, ρυθμίστε τις προαπαιτούμενες ρυθμίσεις Linux και ελέγξτε την εγκατάσταση με ένα πρώτο πρόγραμμα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε το Aspose.Slides for Java σε ένα έργο. Το Aspose.Slides for Java κυκλοφορεί στο δικό του αποθετήριο Maven της Aspose, όχι στο Maven Central, επομένως ένα έργο Maven πρέπει να δηλώσει αυτό το αποθετήριο. Μπορείτε επίσης να κατεβάσετε το αρχείο JAR και να το προσθέσετε στο class path μόνοι σας. Και οι δύο διαδρομές καταλήγουν σε ένα σύντομο πρόγραμμα που επιβεβαιώνει ότι η βιβλιοθήκη λειτουργεί.

Το Aspose.Slides for Java δεν απαιτεί το Microsoft PowerPoint. Δημιουργεί προγραμματιστικά τα απαραίτητα αρχεία παρουσίασης. Ωστόσο, για να προβάλετε τις παραγόμενες παρουσιάσεις, ενδέχεται να χρειαστείτε το Microsoft PowerPoint ή κάποιον άλλο προβολέα παρουσιάσεων.

## **Προαπαιτούμενα**

- Ένα Java Development Kit (JDK). Το έργο και οι εντολές σε αυτό το άρθρο απαιτούν JDK 11 ή νεότερο. Στο JDK 11, το πρόγραμμα που ελέγχει την εγκατάσταση εμφανίζει μια προειδοποίηση που αρχίζει με "WARNING: An illegal reflective access operation has occurred"· δεν επηρεάζει το αποτέλεσμα και μπορεί να αγνοηθεί.
- [Apache Maven](https://maven.apache.org/install.html), if you use the Maven route.
- Σε Linux, η βιβλιοθήκη fontconfig και τουλάχιστον μία εγκατεστημένη γραμματοσειρά. Δείτε [Linux](#linux).

## **Εγκατάσταση από το αποθετήριο Maven**

Η Aspose φιλοξενεί τις βιβλιοθήκες Java της σε δικό της [αποθετήριο Maven](https://releases.aspose.com/java/repo/com/aspose/). Για να χρησιμοποιήσετε το [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) σε ένα έργο Maven, προσθέστε δύο καταχωρήσεις στο *pom.xml* σας.

1. **Δηλώστε το αποθετήριο Maven της Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Προσθέστε την εξάρτηση Aspose.Slides for Java.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

Ο ταξινομητής `jdk8` απαιτείται: επιλέγει την έκδοση Java SE της βιβλιοθήκης. Αντικαταστήστε το `26.10` με την πιο πρόσφατη έκδοση που εμφανίζεται στο [αποθετήριο](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Το αποθετήριο δημοσιεύει ένα αρχείο ελέγχου SHA-1 δίπλα σε κάθε JAR, το οποίο ελέγχει το Maven όταν κατεβάζει τη βιβλιοθήκη.

### **Έλεγχος της εγκατάστασης**

Για να ελέγξετε τη διαμόρφωση με ένα νέο έργο:

1. Δημιουργήστε ένα φάκελο για το έργο και αποθηκεύστε αυτό το *pom.xml* σε αυτόν:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.10</version>
               <classifier>jdk8</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   Εκτός του αποθετηρίου και της εξάρτησης, αυτό το *pom.xml* ορίζει την έκδοση Java για τη μεταγλώττιση, ονομάζει την κλάση που εκτελεί το `mvn exec:java`, και κλειδώνει το plugin του μεταγλωττιστή, επειδή το παλαιότερο plugin που χρησιμοποιούν κάποιες εγκαταστάσεις Maven από προεπιλογή αγνοεί τη ρύθμιση `maven.compiler.release`.

2. Αποθηκεύστε το πρώτο παράδειγμα στο [Create Presentations](/slides/el/java/create-presentation/) ως *src/main/java/HelloSlides.java*.

3. Στον φάκελο του έργου, εκτελέστε:

   ```bash
   mvn compile exec:java
   ```

Maven κατεβάζει το Aspose.Slides for Java, μεταγλωττίζει το πρόγραμμα και το εκτελεί. Το πρόγραμμα αποθηκεύει το *new_presentation.pptx* στον φάκελο του έργου.

## **Χρήση του αρχείου JAR χωρίς Maven**

1. Κατεβάστε *aspose-slides-26.10-jdk8.jar* από το [version folder](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) στο αποθετήριο. Για άλλη έκδοση, ανοίξτε τον φάκελο της στο [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) και κατεβάστε το αρχείο που τελειώνει σε *-jdk8.jar*.
2. Αποθηκεύστε το πρώτο παράδειγμα στο [Create Presentations](/slides/el/java/create-presentation/) ως *HelloSlides.java* στον ίδιο φάκελο με το αρχείο JAR.
3. Σε αυτόν τον φάκελο, εκτελέστε:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

Το JDK μεταγλωττίζει και εκτελεί το μοναδικό αρχείο πηγαίου κώδικα, και το πρόγραμμα αποθηκεύει το *new_presentation.pptx* στον φάκελο. Στην δική σας εφαρμογή, προσθέστε το αρχείο JAR στο class path στο εργαλείο κατασκευής ή στο IDE σας.

## **Linux**

Το Aspose.Slides for Java χρησιμοποιεί τη υποστήριξη γραμματοσειρών της Java, η οποία σε Linux απαιτεί τη βιβλιοθήκη fontconfig και τουλάχιστον μία εγκατεστημένη γραμματοσειρά. Χωρίς αυτά, η αποθήκευση μιας παρουσίασης αποτυγχάνει με το σφάλμα "Fontconfig head is null, check your fonts or fonts configuration". Ελάχιστες εικόνες διακομιστών και containers μπορεί να μην έχουν και τα δύο· για παράδειγμα η επίσημη εικόνα container Ubuntu δεν διαθέτει κανένα από τα δύο.

Σε Debian και Ubuntu, αυτή η εντολή εγκαθιστά ένα JDK, Maven, fontconfig και τις γραμματοσειρές DejaVu:

```bash
   sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Οι γραμματοσειρές που χρησιμοποιούνται στις παρουσιάσεις σας, ή κατάλληλες εναλλακτικές, πρέπει επίσης να εγκατασταθούν ώστε το κείμενο να αποδίδεται σωστά.

## **Συχνές Ερωτήσεις**

### Πώς μπορώ να επαληθεύσω ότι το Aspose.Slides είναι ενσωματωμένο σωστά;

Δομήστε το έργο σας, δημιουργήστε μια κενή [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) και αποθηκεύστε την με νέο όνομα. Εάν το αρχείο δημιουργηθεί χωρίς εξαίρεσεις, η βιβλιοθήκη έχει ενσωματωθεί επιτυχώς.

### Πώς μπορώ να περιορίσω την κατανάλωση μνήμης κατά την επεξεργασία μεγάλων παρουσιάσεων;

Αυξήστε τα όρια μνήμης του JVM μόνο όσο χρειάζεται, και καλέστε το [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) σε κάθε παράδειγμα [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) σε ένα μπλοκ `finally` για να απελευθερώσετε την κρυφή μνήμη άμεσα. Αυτό αποτρέπει σφάλματα έλλειψης μνήμης και διατηρεί τη χρήση μνήμης προβλέψιμη κατά τις παρτίδες λειτουργίες.

### Μπορώ να εξαιρέσω ανεπιθύμητες μορφές εξαγωγής για να μειώσω το τελικό μέγεθος του JAR;

Οι τρέχουσες εκδόσεις του Aspose.Slides διανέμονται ως μία μονολιθική βιβλιοθήκη, επομένως δεν μπορείτε να απενεργοποιήσετε συγκεκριμένους εξαγωγείς όπως PDF ή SVG κατά τη διαδικασία κατασκευής.
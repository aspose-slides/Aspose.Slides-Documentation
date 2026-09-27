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
description: "Εγκαταστήστε το Aspose.Slides for Java από το αποθετήριο Maven της Aspose ή ως αρχείο JAR, ρυθμίστε τις προαπαιτήσεις Linux και ελέγξτε την εγκατάσταση με ένα πρώτο πρόγραμμα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε το Aspose.Slides for Java σε ένα έργο. Το Aspose.Slides for Java δημοσιεύεται στο δικό του αποθετήριο Maven της Aspose, όχι στο Maven Central, επομένως ένα έργο Maven πρέπει να δηλώσει αυτό το αποθετήριο. Μπορείτε επίσης να κατεβάσετε το αρχείο JAR και να το τοποθετήσετε στην διαδρομή κλάσεων (classpath) μόνοι σας. Και οι δύο διαδρομές καταλήγουν σε ένα μικρό πρόγραμμα που επιβεβαιώνει ότι η βιβλιοθήκη λειτουργεί.

Το Aspose.Slides for Java δεν απαιτεί το Microsoft PowerPoint. Δημιουργεί προγραμματιστικά τα απαραίτητα αρχεία παρουσίασης. Ωστόσο, για να δείτε τις δημιουργημένες παρουσιάσεις, ίσως χρειαστεί το Microsoft PowerPoint ή κάποιο άλλο πρόγραμμα προβολής παρουσιάσεων.

## **Προαπαιτούμενα**

- Ένα Java Development Kit (JDK). Το έργο και οι εντολές σε αυτό το άρθρο απαιτούν JDK 11 ή νεότερο. Στο JDK 11, το πρόγραμμα που ελέγχει την εγκατάσταση εκτυπώνει μια προειδοποίηση που αρχίζει με "WARNING: An illegal reflective access operation has occurred"· δεν επηρεάζει το αποτέλεσμα και μπορεί να αγνοηθεί.
- [Apache Maven](https://maven.apache.org/install.html), εάν χρησιμοποιείτε τη διαδρομή Maven.
- Σε Linux, η βιβλιοθήκη fontconfig και τουλάχιστον μία εγκατεστημένη γραμματοσειρά. Δείτε το [Linux](#linux).

## **Εγκατάσταση από το αποθετήριο Maven**

Η Aspose φιλοξενεί τις βιβλιοθήκες Java της σε δικό της [αποθετήριο Maven](https://releases.aspose.com/java/repo/com/aspose/). Για να χρησιμοποιήσετε το [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) σε ένα έργο Maven, προσθέστε δύο καταχωρίσεις στο *pom.xml* σας.

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
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

Ο ταξινομητής `jdk16` είναι απαιτητός: επιλέγει την έκδοση Java SE της βιβλιοθήκης. Αντικαταστήστε το `26.9` με την πιο πρόσφατη έκδοση που εμφανίζεται στο [αποθετήριο](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Το αποθετήριο δημοσιεύει ένα αρχείο ελέγχου SHA-1 δίπλα σε κάθε JAR, το οποίο το Maven ελέγχει κατά τη λήψη της βιβλιοθήκης.

### **Έλεγχος της εγκατάστασης**

Για να ελέγξετε τη ρύθμιση με ένα νέο έργο:

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
               <version>26.9</version>
               <classifier>jdk16</classifier>
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

   Εκτός από το αποθετήριο και την εξάρτηση, αυτό το *pom.xml* ορίζει την έκδοση Java για τη μεταγλώττιση, ονομάζει την κλάση που εκτελεί το `mvn exec:java`, και καθορίζει την έκδοση του plugin μεταγλώττισης, επειδή το παλαιότερο plugin που ορισμένες εγκαταστάσεις Maven χρησιμοποιούν από προεπιλογή αγνοεί τη ρύθμιση `maven.compiler.release`.

2. Αποθηκεύστε το πρώτο παράδειγμα στο [Create Presentations](/slides/el/java/create-presentation/) ως *src/main/java/HelloSlides.java*.

3. Στο φάκελο του έργου, εκτελέστε:

   ```bash
   mvn compile exec:java
   ```

Το Maven κατεβάζει το Aspose.Slides for Java, μεταγλωττίζει το πρόγραμμα και το εκτελεί. Το πρόγραμμα αποθηκεύει το *new_presentation.pptx* στο φάκελο του έργου.

## **Χρήση του αρχείου JAR χωρίς Maven**

1. Κατεβάστε το *aspose-slides-26.9-jdk16.jar* από το [φάκελο έκδοσης](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) στο αποθετήριο. Για άλλη έκδοση, ανοίξτε το φάκελο της στο [αποθετήριο](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) και κατεβάστε το αρχείο που τελειώνει σε *-jdk16.jar*.
2. Αποθηκεύστε το πρώτο παράδειγμα στο [Create Presentations](/slides/el/java/create-presentation/) ως *HelloSlides.java* στον ίδιο φάκελο με το αρχείο JAR.
3. Σε αυτόν το φάκελο, εκτελέστε:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

Το JDK μεταγλωττίζει και εκτελεί το ενιαίο αρχείο πηγαίου κώδικα, και το πρόγραμμα αποθηκεύει το *new_presentation.pptx* στον φάκελο. Στην εφαρμογή σας, προσθέστε το αρχείο JAR στη διαδρομή κλάσεων (classpath) του εργαλείου κατασκευής ή του IDE σας.

## **Linux**

Το Aspose.Slides for Java χρησιμοποιεί την υποστήριξη γραμματοσειρών της Java, η οποία σε Linux απαιτεί τη βιβλιοθήκη fontconfig και τουλάχιστον μία εγκατεστημένη γραμματοσειρά. Χωρίς αυτά, η αποθήκευση μιας παρουσίασης αποτυγχάνει με το σφάλμα "Fontconfig head is null, check your fonts or fonts configuration". Οι ελάχιστες εικόνες διακομιστή και κοντέινερ μπορεί να μην περιλαμβάνουν και τα δύο· η επίσημη εικόνα κοντέινερ Ubuntu, για παράδειγμα, δεν τα έχει.

Σε Debian και Ubuntu, αυτή η εντολή εγκαθιστά ένα JDK, Maven, fontconfig και τις γραμματοσειρές DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Οι γραμματοσειρές που χρησιμοποιούνται στις παρουσιάσεις σας, ή κατάλληλες εναλλακτικές, πρέπει επίσης να εγκατασταθούν για να εμφανίζεται το κείμενο σωστά.

## **Συχνές ερωτήσεις**

### Πώς μπορώ να επαληθεύσω ότι το Aspose.Slides ενσωματώθηκε σωστά;

Δομήστε το έργο σας, δημιουργήστε ένα κενό [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) και αποθηκεύστε το με νέο όνομα. Εάν το αρχείο δημιουργηθεί χωρίς να πετάξει εξαιρέσεις, η βιβλιοθήκη έχει ενσωματωθεί επιτυχώς.

### Πώς μπορώ να περιορίσω την κατανάλωση μνήμης κατά την επεξεργασία μεγάλων παρουσιάσεων;

Αυξήστε τα όρια μνήμης του JVM μόνο όσο χρειάζεται, και καλέστε το [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) σε κάθε αντικείμενο [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) μέσα σε μπλοκ `finally` για να απελευθερώσετε την κρυφή μνήμη αμέσως. Αυτό αποτρέπει σφάλματα έλλειψης μνήμης και διατηρεί τη συνολική χρήση μνήμης προβλέψιμη κατά τις λειτουργίες δέσμης.

### Μπορώ να εξακριβώσω ανεπιθύμητες μορφές εξαγωγής ώστε να μειώσω το τελικό μέγεθος του JAR;

Οι τρέχουσες εκδόσεις του Aspose.Slides διανέμονται ως μια ενιαία μονολιθική βιβλιοθήκη, επομένως δεν μπορείτε να απενεργοποιήσετε συγκεκριμένους εξαγωγείς όπως PDF ή SVG κατά τη διαδικασία κατασκευής.
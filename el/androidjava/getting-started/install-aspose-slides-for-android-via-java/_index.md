---
title: Εγκατάσταση Aspose.Slides για Android μέσω Java
type: docs
weight: 90
url: /el/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- εγκατάσταση Aspose.Slides
- λήψη Aspose.Slides
- χρήση Aspose.Slides
- Aspose.Slides installation
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Εγκαταστήστε γρήγορα το Aspose.Slides για Android. Οδηγίες βήμα‑βήμα, απαιτήσεις συστήματος και παραδείγματα κώδικα Java — ξεκινήστε να εργάζεστε με παρουσιάσεις PowerPoint σήμερα!"
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εγκαταστήσετε το Aspose.Slides for Android via Java και να το προσθέσετε σε ένα έργο Android. Περιγράφει δύο επιλογές εγκατάστασης: την προσθήκη του αρχείου JAR του Aspose.Slides στο έργο χειροκίνητα και την εγκατάσταση της βιβλιοθήκης από το αποθετήριο Maven.

Το άρθρο παρέχει επίσης ένα βήμα‑βήμα παράδειγμα που δείχνει πώς να δημιουργήσετε μια νέα εφαρμογή Android στο Android Studio, να αναφέρετε τη βιβλιοθήκη Aspose.Slides, να δημιουργήσετε μια παρουσίαση PowerPoint προγραμματιστικά και να την αποθηκεύσετε σε μορφή PPTX. Περιλαμβάνει επίσης σημειώσεις για την έκδοση και απαντά σε συχνές ερωτήσεις σχετικά με τον έλεγχο ενσωμάτωσης, τη διαχείριση χρήσης μνήμης και τη μείωση του τελικού μεγέθους του JAR.

## **Εγκατάσταση**
Προηγουμένως, το Aspose.Slides for Android via Java διανέμεται ως ένα μοναδικό αρχείο ZIP που περιέχει το αρχείο JAR, τις επιδείξεις και την τεκμηρίωση του προϊόντος. 

1. Εάν θέλετε να χρησιμοποιήσετε μια έκδοση παλαιότερη από το Aspose.Words for Android via Java 18.9, πρέπει να αποσυμπιέσετε την έκδοση Aspose.Slides.Android.zip στον προτιμώμενο κατάλογό σας. 
1. Προσθέστε το αποσυμπιεσμένο αρχείο JAR στην εφαρμογή σας χρησιμοποιώντας τη διαμόρφωση Build Path. 
### **Προσθήκη Αναφοράς στο Aspose.Slides for Android via Java Jar**
1. Κατεβάστε τη πιο πρόσφατη έκδοση του [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/el/androidjava)
1. Αντιγράψτε το aspose-slides-18.9-android.via.java.jar στον φάκελο *libs/* του έργου σας

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **Εγκατάσταση Aspose.Slides for Android via Java από το αποθετήριο Maven**
1. Προσθέστε το αποθετήριο Maven στο αρχείο build.gradle. 
1. Προσθέστε το JAR του [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) ως εξάρτηση.

``` java

 // 1. Προσθέστε το αποθετήριο Maven στο build.gradle σας 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. Προσθέστε το JAR 'Aspose.Slides for Android via Java' ως εξάρτηση

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}
```
## **Η Πρώτη Σας Εφαρμογή Χρησιμοποιώντας Aspose.Slides για Android via Java**
Σε αυτή την ενότητα, θα μάθετε πώς να ξεκινήσετε με το Aspose.Slides for Android via Java. Σκοπός μας είναι να σας δείξουμε πώς να δημιουργήσετε ένα νέο έργο Android από την αρχή, να προσθέσετε μια αναφορά στο JAR του Aspose.Slides και να δημιουργήσετε μια νέα παρουσίαση PowerPoint η οποία αποθηκεύεται στον δίσκο σε μορφή PPTX. Το παράδειγμα χρησιμοποιεί το [Android Studio](https://developer.android.com/studio/index.html) για ανάπτυξη και η εφαρμογή εκτελείται στον Android Emulator. Για να ξεκινήσετε με το Aspose.Slides for Android via Java, ακολουθήστε αυτό το βήμα‑βήμα tutorial για να δημιουργήσετε μια εφαρμογή που χρησιμοποιεί το Aspose.Slides for Android via Java:

1. Κατεβάστε και εγκαταστήστε το [Android Studio](https://developer.android.com/studio/index.html) σε οποιοδήποτε φάκελο.
1. Εκκινήστε το Android Studio.
1. Δημιουργήστε ένα νέο Έργο Εφαρμογής Android.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)

1. Αντιγράψτε το aspose-slides-XX.XX-android.via.java.jar στον φάκελο libs του έργου σας

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)

1. Επιλέξτε την ενότητα Project (από το μενού αρχείου) και κάντε κλικ στην καρτέλα Dependencies.
   1. Κάντε κλικ στο κουμπί "+" . Επιλέξτε την επιλογή file dependency.
   1. Επιλέξτε τη βιβλιοθήκη Aspose.Slides από το φάκελο libs και κάντε κλικ στο OK.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)

1. Συγχρονίστε το έργο με τα αρχεία gradle αν είναι απαραίτητο. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)

1. Για πρόσβαση στην SDcard, πρέπει να προστεθούν ειδικά δικαιώματα. Κάντε κλικ στο αρχείο AndroidManifest.xml και επιλέξτε προβολή XML. Προσθέστε τη γραμμή <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" /> στο αρχείο.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)

1. Επιστρέψτε στην ενότητα κώδικα της εφαρμογής και προσθέστε αυτές τις δηλώσεις εισαγωγής: 

``` java

 import java.io.File;

import com.aspose.slides.IAutoShape;

import com.aspose.slides.IParagraph;

import com.aspose.slides.IPortion;

import com.aspose.slides.ISlide;

import com.aspose.slides.ITextFrame;

import com.aspose.slides.Presentation;

import com.aspose.slides.SaveFormat;

import com.aspose.slides.ShapeType;

import android.os.Environment;

```

Τώρα, ενσωματώστε αυτόν τον κώδικα στο σώμα της μεθόδου onCreate για να δημιουργήσετε μια νέα Presentation από την αρχή χρησιμοποιώντας το Aspose.Slides και να την αποθηκεύσετε στην SDCard σε μορφή PPTX.

``` java

 try

{

    // Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει PPTX
    Presentation pres = new Presentation();



    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide sld = pres.getSlides().get_Item(0);



    // Προσθήκη AutoShape τύπου Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // Προσθήκη TextFrame στο Rectangle
    ashp.addTextFrame(" ");



    // Πρόσβαση στο πλαίσιο κειμένου
    ITextFrame txtFrame = ashp.getTextFrame();



    // Δημιουργία αντικειμένου Paragraph για το πλαίσιο κειμένου
    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // Δημιουργία αντικειμένου Portion για την παράγραφο
    IPortion portion = para.getPortions().get_Item(0);



    // Ορισμός κειμένου
    portion.setText("Aspose TextBox");



    // Αποθήκευση του PPTX στην κάρτα
    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;
    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);
}

catch (Exception e)

{
   e.printStackTrace();
}
```

Ο πλήρης κώδικας θα πρέπει να μοιάζει ως εξής:

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)

1. Τώρα εκτελέστε ξανά την εφαρμογή. Αυτή τη φορά, ο κώδικας Aspose.Slides θα εκτελεστεί στο παρασκήνιο και θα δημιουργήσει ένα έγγραφο που αποθηκεύεται στην SDcard.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Για να δείτε το δημιουργημένο έγγραφο, μεταβείτε στο μενού Tools. Επιλέξτε Android και, στη συνέχεια, Android Device Monitor

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **Διαχείριση Εκδόσεων**
Από το 2018, η διαχείριση εκδόσεων του Aspose.Slides for Android via Java είναι σύμφωνη με το Aspose.Slides for Java.  

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να επαληθεύσω ότι το Aspose.Slides έχει ενσωματωθεί σωστά;**

Δομήστε το έργο σας, δημιουργήστε μια κενή [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και αποθηκεύστε την με νέο όνομα. Εάν το αρχείο δημιουργηθεί χωρίς να ρίξει εξαιρέσεις, η βιβλιοθήκη έχει ενσωματωθεί επιτυχώς.

**Πώς μπορώ να περιορίσω την κατανάλωση μνήμης κατά την επεξεργασία μεγάλων παρουσιάσεων;**

Αυξήστε τα όρια μνήμης της JVM μόνο όσο χρειάζεται και κλείστε κάθε αντικείμενο [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) σε ένα `finally` block για άμεση απελευθέρωση της κρύπτης. Αυτό αποτρέπει σφάλματα έλλειψης μνήμης και διατηρεί τη συνολική χρήση μνήμης προβλέψιμη κατά τις παρτίδες λειτουργιών.

**Μπορώ να εξαιρέσω ανεπιθύμητες μορφές εξαγωγής για να μειώσω το τελικό μέγεθος του JAR;**

Οι τρέχουσες εκδόσεις του Aspose.Slides διανέμονται ως μία ενιαία βιβλιοθήκη, επομένως δεν μπορείτε να απενεργοποιήσετε συγκεκριμένους εξαγωγείς όπως PDF ή SVG κατά το χτίσιμο.
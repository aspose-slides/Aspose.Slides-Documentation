---
title: Εγκατάσταση Aspose.Slides για Android via Java
type: docs
weight: 90
url: /el/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- εγκατάσταση Aspose.Slides
- λήψη Aspose.Slides
- χρήση Aspose.Slides
- εγκατάσταση Aspose.Slides
- Gradle
- αποθετήριο Maven
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Προσθέστε το Aspose.Slides για Android via Java σε ένα έργο Android Studio με Gradle από το αποθετήριο Maven της Aspose, ή προσθέστε το αρχείο JAR χειροκίνητα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε το Aspose.Slides for Android via Java σε ένα έργο Android. Ο προτεινόμενος τρόπος είναι να αφήσετε το Gradle να κατεβάσει τη βιβλιοθήκη από το αποθετήριο Maven της Aspose. Μπορείτε επίσης να κατεβάσετε το αρχείο JAR και να το προσθέσετε στο έργο σας χειροκίνητα.

Η βιβλιοθήκη δεν εκδίδεται στο Maven Central ή στο αποθετήριο Maven της Google. Είναι διαθέσιμη από το δικό της αποθετήριο της Aspose, ως το τεχνούργημα `aspose-slides` με τον ταξινομητή `android.via.java`.

## **Εγκατάσταση από το αποθετήριο Maven της Aspose**

### **Βήμα 1: Προσθήκη του αποθετηρίου**

Νέα έργα Android Studio δηλώνουν τα αποθετήριά τους στο μπλοκ `dependencyResolutionManagement` του *settings.gradle.kts*, και το Gradle απορρίπτει αποθετήρια που προστίθενται από το αρχείο κατασκευής ενός μονάδας. Προσθέστε τη γραμμή `maven` που φαίνεται παρακάτω στο μπλοκ `repositories` μέσα σε αυτό το υπάρχον μπλοκ, αντί να επικολλήσετε δεύτερο μπλοκ `dependencyResolutionManagement`:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

### **Βήμα 2: Προσθήκη της εξάρτησης**

Προσθέστε τη βιβλιοθήκη στο μπλοκ `dependencies` του αρχείου κατασκευής του μονάδας εφαρμογής, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

Το τελευταίο μέρος των συντεταγμένων, `android.via.java`, είναι ο ταξινομητής που επιλέγει την Android έκδοση της βιβλιοθήκης. Χωρίς αυτόν, το Gradle δεν μπορεί να βρει το τεχνούργημα.

Στη συνέχεια συγχρονίστε το έργο με τα αρχεία Gradle, ώστε το Gradle να κατεβάσει τη βιβλιοθήκη.

### **Επιλογή έκδοσης**

Το Aspose.Slides for Android via Java δεν είναι κατασκευασμένο για κάθε έκδοση στο αποθετήριο. Οι εκδόσεις του δημοσιεύονται μόνο για ορισμένες εκδόσεις του Aspose.Slides for Java, και μια έκδοση χωρίς Android κατασκευή αποτυγχάνει στην ανάλυση. Επιλέξτε μια έκδοση που εμφανίζεται στη [σελίδα λήψης του Aspose.Slides for Android via Java](https://releases.aspose.com/slides/androidjava/).

### **Σενάρια κατασκευής Groovy**

Αν το έργο σας χρησιμοποιεί σενάρια κατασκευής Groovy, προσθέστε τη γραμμή `maven` στο μπλοκ `repositories` μέσα στο υπάρχον μπλοκ `dependencyResolutionManagement` του *settings.gradle*:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

Και προσθέστε την εξάρτηση στο *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **Προσθήκη του αρχείου JAR χειροκίνητα**

Αν δεν μπορείτε να χρησιμοποιήσετε αποθετήριο Maven, προσθέστε το αρχείο JAR στο έργο σας:

1. Κατεβάστε το αρχείο JAR από το φάκελο της έκδοσης στο [αποθετήριο Maven της Aspose](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Για την έκδοση 26.9, το αρχείο είναι *aspose-slides-26.9-android.via.java.jar* στο φάκελο *26.9*.
1. Αντιγράψτε το αρχείο στον φάκελο *app/libs* του έργου σας. Δημιουργήστε το φάκελο αν δεν υπάρχει.
1. Προσθέστε το αρχείο στο μπλοκ `dependencies` του *app/build.gradle.kts*, μετά συγχρονίστε το έργο:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Δημιουργία της Πρώτης Παρουσίασης**

Μετά το συγχρονισμό του έργου, προχωρήστε στο [Create Presentations](/slides/el/androidjava/create-presentation/). Το πρώτο του παράδειγμα προσθέτει ένα πλαίσιο κειμένου σε μια διαφάνεια και αποθηκεύει την παρουσίαση στη ιδιωτική αποθήκευση της εφαρμογής σας, χωρίς να χρειάζεται άδεια αποθήκευσης. Χωρίς άδεια, το Aspose.Slides προσθέτει υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει· δείτε το [Licensing](/slides/el/androidjava/licensing/).

## **Έκδοση**

Από το 2018, η διαχείριση εκδόσεων του Aspose.Slides for Android via Java συμμορφώνεται με το Aspose.Slides for Java. Οι Android εκδόσεις δεν εκδίδονται για κάθε έκδοση Java· δείτε το [Choose a Version](#choose-a-version).

## **Συχνές Ερωτήσεις**

### Πώς μπορώ να επαληθεύσω ότι το Aspose.Slides ενσωματώθηκε σωστά;

Κατασκευάστε το έργο σας, δημιουργήστε μια κενή [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) και αποθηκεύστε τη με νέο όνομα. Αν το αρχείο δημιουργηθεί χωρίς να προκύψουν εξαιρέσεις, η βιβλιοθήκη έχει ενσωματωθεί επιτυχώς.

### Πώς μπορώ να περιορίσω την κατανάλωση μνήμης κατά την επεξεργασία μεγάλων παρουσιάσεων;

Καλέστε τη μέθοδο [dispose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#dispose--) κάθε αντικειμένου [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) σε ένα μπλοκ `finally` για άμεση απελευθέρωση των πόρων του, και επεξεργαστείτε μία μεγάλη παρουσίαση τη φορά. Αυτό βοηθά στην αποφυγή σφαλμάτων “έλλειψη μνήμης” και διατηρεί τη συνολική χρήση μνήμης προβλέψιμη κατά τις μαζικές λειτουργίες.

### Μπορώ να εξαιρέσω ανεπιθύμητες μορφές εξαγωγής για να μειώσω το τελικό μέγεθος του JAR;

Οι τρέχουσες εκδόσεις του Aspose.Slides διανέμονται ως μία ενιαία μονολιθική βιβλιοθήκη, επομένως δεν είναι δυνατόν να απενεργοποιήσετε συγκεκριμένους εξαγωγείς όπως PDF ή SVG κατά τη διαδικασία κατασκευής.
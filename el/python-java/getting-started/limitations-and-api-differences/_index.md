---
title: Περιορισμοί και Διαφορές API
type: docs
weight: 100
url: /el/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides for Python μέσω Java
- Διαφορές API
- Python
- Java
- JPype
- Περιορισμοί JVM
- PowerPoint
description: "Μάθετε για τους περιορισμούς του JVM και τις διαφορές API μεταξύ Aspose.Slides για Java και Python μέσω Java, συμπεριλαμβανομένων των εισαγωγών, του καθαρισμού πόρων και της διαχείρισης αρχείων."
---
## **Επισκόπηση**

Το Aspose.Slides για Python μέσω Java χρησιμοποιεί το JPype για πρόσβαση στη βιβλιοθήκη Java από την Python. Τα παραδείγματα παρακάτω συγκρίνουν τις εισαγωγές πακέτων, τη δημιουργία παρουσιάσεων και τη διαχείριση αρχείων στις δύο API.

## **Γνωστοί Περιορισμοί**

- **Κύκλος ζωής JVM:** Το JPype υποστηρίζει ένα JVM ανά διεργασία Python. Μετά τον τερματισμό του δεν μπορείτε να το επανεκκινήσετε στην ίδια διεργασία. Ξεκινήστε το μία φορά και επαναχρησιμοποιήστε το για επόμενες λειτουργίες παρουσίασης.
- **Συμβατότητα αρχιτεκτονικής:** Η Python και η Java πρέπει να έχουν αντίστοιχες αρχιτεκτονικές. Δείτε το [System Requirements](/slides/el/python-java/system-requirements/#python-java-and-jpype-requirements) για λεπτομέρειες.

Δείτε τον [JPype User Guide](https://jpype.readthedocs.io/en/latest/userguide.html) για λεπτομέρειες σχετικά με αυτούς τους περιορισμούς και τη διαλειτουργικότητα με τη Java.

## **Διαφορές Δημόσιου API**

Συγκρίνετε τα παρακάτω παραδείγματα Java και Python. Για λεπτομέρειες μελών Python μέσω Java, δείτε το [API Reference](/slides/el/python-java/api-reference/).

### **Εισαγωγή της Βιβλιοθήκης**

Η Java εισάγει κλάσεις από `com.aspose.slides`. Στην Python, εισάγετε το `asposeslides` πριν ξεκινήσετε το JVM, έπειτα εισάγετε κλάσεις από `asposeslides.api` αφού το JVM είναι ενεργό. Χρησιμοποιήστε το [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) για να αποφύγετε την εκκίνηση ενός ήδη ενεργού JVM.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
Τα παραδείγματα Python διατηρούν το JVM ενεργό μέχρι το τερματισμό της διεργασίας Python. Σε ένα notebook, επαναχρησιμοποιήστε το ενεργό JVM μεταξύ κελιών. Εάν έχει ήδη τερματιστεί, επανεκκινήστε τον πυρήνα του notebook πριν χρησιμοποιήσετε ξανά αντικείμενα Java.
{{% /alert %}}

### **Δημιουργία Παρουσίασης**

Η Java χρησιμοποιεί τη λέξη-κλειδί `new`; η Python καλεί την κλάση [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) απευθείας. Αποδεσμεύστε τους πόρους της παρουσίασης με το [Presentation.dispose](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#dispose) σε ένα μπλοκ `finally`.

Και τα δύο παραδείγματα αποθηκεύουν μια κενή παρουσίαση χρησιμοποιώντας το [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) και το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#pptx).

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ανάγνωση Αρχείων και Χρήση Σταθερών Μορφής**

Η Java μπορεί να φορτώσει μια παρουσίαση από μια ροή εισόδου Java. Στην Python, διαβάστε το αρχείο ως δυαδικά δεδομένα και περάστε τα παραγόμενα bytes στο [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#createpresentationfrombytes). Ένα αρχείο Python δεν είναι ροή εισόδου Java.

Τα παρακάτω παραδείγματα απαιτούν ένα υπάρχον `presentation.pptx` στον τρέχοντα φάκελο και αποθηκεύουν ένα αντίγραφο ως `result.pptx`. Και τα δύο κλείνουν το αρχείο εισόδου και αποδεσμεύουν τους πόρους της παρουσίασης. Το παράδειγμα Python διαβάζει ολόκληρο το αρχείο εισόδου στη μνήμη.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Συχνές Ερωτήσεις**

**Πρέπει να επανεκκινήσω το JVM για κάθε παρουσίαση;**

Όχι. Διατηρήστε το JVM ενεργό και δημιουργήστε και αποδεσμεύστε αντικείμενα παρουσίασης όπως απαιτείται. Η διακοπή του JVM εμποδίζει περαιτέρω λειτουργίες Java στην ίδια διεργασία Python.

**Μπορώ να ανοίξω μια παρουσίαση απευθείας από διαδρομή αρχείου;**

Ναι. Ο κατασκευαστής [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) δέχεται μια διαδρομή αρχείου. Χρησιμοποιήστε το βοηθητικό εργαλείο βασισμένο σε bytes όταν τα δεδομένα της παρουσίασης είναι ήδη διαθέσιμα ως bytes στην Python.

**Πρέπει να αλλάξω τα ονόματα των σταθερών μορφής όταν μεταφράζω παραδείγματα Java σε Python;**

Όχι. Για παράδειγμα, το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/python-java/aspose.slides/saveformat/#pptx) χρησιμοποιεί την ίδια ορθογραφία και κεφαλαιοποίηση και στις δύο API.
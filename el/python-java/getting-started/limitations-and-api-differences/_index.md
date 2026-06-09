---
title: "Περιορισμοί και Διαφορές API"
type: docs
weight: 100
url: /el/python-java/limitations-and-api-differences/
keywords: "κόμβος, PowerPoint, περιορισμός, API, διαφορές"
description: "Περιορισμοί και διαφορές API του Aspose.Slides for Python μέσω Java."
---
## **Γνωστά Σφάλματα/Περιορισμοί**
Οι κλάσεις Java εκτός πακέτου (στο `default`) δεν μπορούν να εισαχθούν.
Λόγω έλλειψης υποστήριξης JVM, δεν μπορείτε να τερματίσετε τη JVM και στη συνέχεια να την επανεκκινήσετε. Επίσης, δεν μπορείτε να ξεκινήσετε περισσότερα από ένα αντίγραφα της JVM.
Ο συνδυασμός 64‑bit Python με 32‑bit Java και αντίστροφα προκαλεί κατάρρευση κατά την εισαγωγή του module jpipe.

## **Διαφορές Δημόσιου API**
Η παρακάτω λίστα (με παραδείγματα κώδικα) δείχνει ορισμένες διαφορές μεταξύ Aspose.Slides for Java και Aspose.Slides for Python μέσω Java APIs.

### **Εισαγωγή βιβλιοθήκης (Συγκρίσεις Πακέτων)**

**Aspose.Slides for Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()

```

### **Δημιουργία νέας Παρουσίασης**

**Aspose.Slides for Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **Ροή Αρχείων και Σταθερών**

**Aspose.Slides for Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input = open("presentation.pptx", mode="rb")
data = input.read()
pres = Presentation.createPresentationFromBytes(data)
pres.save("result.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

### **Άλλοι Περιορισμοί του Aspose.Slides for Python μέσω Java API σε σύγκριση με το Aspose.Slides for Java API**

Για περισσότερες πληροφορίες σχετικά με άλλους περιορισμούς, ανατρέξτε στην τεκμηρίωση του jpype:
- https://jpype.readthedocs.io/en/latest/
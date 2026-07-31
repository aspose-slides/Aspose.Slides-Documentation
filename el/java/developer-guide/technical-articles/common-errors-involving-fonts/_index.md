---
title: Κοινές εξαιρέσεις και σφάλματα που αφορούν τις γραμματοσειρές σε Linux
type: docs
weight: 200
url: /el/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Εξαίρεση γραμματοσειράς, Σφάλμα γραμματοσειράς, Linux, Java, Aspose.Slides for Java"
description: "Εξαιρέσεις και σφάλματα γραμματοσειρών σε Linux"
---
## **Επισκόπηση**

Όταν το Aspose.Slides χρησιμοποιείται σε Linux, μπορεί να προκύψουν προβλήματα σχετιζόμενα με τις γραμματοσειρές εάν η διεργασία Java δεν μπορεί να έχει πρόσβαση στους απαιτούμενους φακέλους γραμματοσειρών ή στον προσωρινό φάκελο, εάν δεν έχουν εγκατασταθεί γραμματοσειρές στο σύστημα, ή εάν λείπουν απαιτούμενες βιβλιοθήκες συστήματος όπως το fontconfig ή το libfreetype.

Αυτό το άρθρο περιγράφει συνήθη σφάλματα και εξαιρέσεις σχετικά με τις γραμματοσειρές σε Linux και παρέχει λύσεις για την επίλυσή τους. Εξηγεί πώς να ελέγξετε την πρόσβαση στους φακέλους γραμματοσειρών και TEMP, να εγκαταστήσετε τις απαιτούμενες γραμματοσειρές και βιβλιοθήκες, και να χρησιμοποιήσετε `FontsLoader` για τη φόρτωση γραμματοσειρών χωρίς να τις εγκαταστήσετε σε ολόκληρο το σύστημα.

## **Λείπουν Κείμενο ή Εικόνες (EMF ή WMF) Όταν ο Κώδικας Εκτελείται σε Linux**

Αυτό το πρόβλημα εμφανίζεται σε συστήματα με περιορισμούς στις εξής περιπτώσεις:

1. Όταν δεν υπάρχουν εγκατεστημένες γραμματοσειρές ή όταν ο φάκελος γραμματοσειρών για τη διεργασία java δεν είναι προσβάσιμος
2. Όταν δεν είναι προσβάσιμος ο φάκελος TEMP.

### **Λύση**

Ελέγξτε και επιβεβαιώστε ότι έχει δοθεί πρόσβαση στον φάκελο TEMP και στον φάκελο γραμματοσειρών. 

{{% alert color="warning" %}}
Σε ορισμένες περιπτώσεις, ίσως να μην μπορείτε να παραχωρήσετε πρόσβαση σε φακέλους λόγω περιορισμών που επιβάλλει το περιβάλλον ή μια πολιτική ασφαλείας. Δοκιμάστε τις παρακάτω παρακάμψεις: 
{{% /alert %}}

**Παράκαμψη**

Χρησιμοποιήστε [FontsLoader](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsLoader) για να φορτώσετε τις απαιτούμενες γραμματοσειρές χωρίς να τις εγκαταστήσετε:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Αν δεν είναι προσβάσιμος ο φάκελος TEMP, χρησιμοποιήστε αυτόν τον κώδικα για να ορίσετε έναν άλλο φάκελο ως TEMP για τη Java:
```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **Εξαίρεση: InvalidOperationException: Cannot Find Any Fonts Installed on the System**

Αυτή η εξαίρεση εμφανίζεται όταν

1) η διεργασία Java δεν μπορεί να έχει πρόσβαση στον φάκελο γραμματοσειρών
2) δεν έχουν εγκατασταθεί γραμματοσειρές.

### **Λύση**

1. Ελέγξτε και επιβεβαιώστε ότι έχει δοθεί πρόσβαση στον φάκελο γραμματοσειρών για τη διεργασία Java.

2. Εγκαταστήστε κάποιες γραμματοσειρές ή χρησιμοποιήστε [FontsLoader](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsLoader).

3. Εγκατάσταση γραμματοσειρών.

   * Ubuntu: 

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
     ```

   * CentOS: 

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
     ```

   * Χρήση [FontsLoader](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Εξαίρεση: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

Αυτή η εξαίρεση εμφανίζεται σε σύστημα Linux που λείπουν τα fontconfig και οι γραμματοσειρές. 

### **Λύση**

Εγκαταστήστε fontconfig:

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

Επιπλέον, ορισμένες εκδόσεις open-jdk (για παράδειγμα, **alpine JDK**) επίσης **απαιτούν εγκατεστημένες γραμματοσειρές**.

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **Εξαίρεση: UnsatisfiedLinkError: libfreetype.so.6: Cannot Open Shared Object File: No Such File or Directory**

Αυτή η εξαίρεση εμφανίζεται σε σύστημα Linux που λείπει η βιβλιοθήκη libfreetype. 

### **Λύση**

Εγκαταστήστε libfreetype και fontconfig:

* Ubuntu: 

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS: 

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="TIP" color="primary" %}} 
Μην ξεχάσετε να εγκαταστήσετε γραμματοσειρές ή να χρησιμοποιήσετε FontsLoader.
{{% /alert %}}
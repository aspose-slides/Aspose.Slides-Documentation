---
title: Κοινές Εξαιρέσεις και Σφάλματα που Αφορούν τις Γραμματοσειρές σε Linux
type: docs
weight: 200
url: /el/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Εξαίρεση γραμματοσειράς, Σφάλμα γραμματοσειράς, Linux, Java, Aspose.Slides for Java"
description: "Εξαιρέσεις και σφάλματα γραμματοσειρών σε Linux"
---
## **Επισκόπηση**

Όταν το Aspose.Slides χρησιμοποιείται σε Linux, ενδέχεται να προκύψουν προβλήματα σχετιζόμενα με τις γραμματοσειρές εάν η διαδικασία Java δεν μπορεί να έχει πρόσβαση στους απαιτούμενους φακέλους γραμματοσειρών ή στον προσωρινό κατάλογο, εάν δεν υπάρχουν εγκατεστημένες γραμματοσειρές στο σύστημα, ή εάν λείπουν απαιτούμενες βιβλιοθήκες συστήματος όπως το fontconfig ή το libfreetype.

Αυτό το άρθρο περιγράφει κοινά σφάλματα και εξαιρέσεις που σχετίζονται με τις γραμματοσειρές σε Linux και παρέχει λύσεις για την επίλυσή τους. Εξηγεί πώς να ελέγξετε την πρόσβαση στους καταλόγους γραμματοσειρών και TEMP, να εγκαταστήσετε τις απαιτούμενες γραμματοσειρές και βιβλιοθήκες, και να χρησιμοποιήσετε `FontsLoader` για τη φόρτωση γραμματοσειρών χωρίς να τις εγκαταστήσετε σε ολόκληρο το σύστημα.

## **Λείπει κείμενο ή εικόνες (EMF ή WMF) όταν ο κώδικας εκτελείται σε Linux**

Αυτό το πρόβλημα εμφανίζεται σε συστήματα με περιορισμούς στις παρακάτω περιπτώσεις:

1. Όταν δεν υπάρχει εγκατεστημένη γραμματοσειρά ή όταν δεν μπορεί να προσπελαστεί ο φάκελος γραμματοσειρών για τη διαδικασία java
2. Όταν δεν μπορεί να προσπελαστεί ο κατάλογος TEMP.

### **Λύση**

Ελέγξτε και επιβεβαιώστε ότι η πρόσβαση στον κατάλογο TEMP και στο φάκελο γραμματοσειρών έχει χορηγηθεί. 

{{% alert color="warning" %}}
Σε ορισμένες περιπτώσεις, ενδέχεται να μην μπορείτε να χορηγήσετε πρόσβαση σε φακέλους λόγω περιορισμών που επιβάλλει το περιβάλλον ή μια πολιτική ασφαλείας. Δοκιμάστε αυτές τις παρακάμπτησεις: 
{{% /alert %}}

**Παράκαμψη**

Χρησιμοποιήστε [FontsLoader](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsLoader) για να φορτώσετε τις απαιτούμενες γραμματοσειρές χωρίς να τις εγκαταστήσετε:
```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Εάν δεν μπορεί να προσπελαστεί ο κατάλογος TEMP, χρησιμοποιήστε αυτόν τον κώδικα για να ορίσετε έναν άλλο κατάλογο ως TEMP για τη Java:
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

1) η διαδικασία Java δεν μπορεί να προσπελάσει το φάκελο γραμματοσειρών  
2) δεν έχουν εγκατασταθεί γραμματοσειρές.

### **Λύση**

1. Ελέγξτε και επιβεβαιώστε ότι η πρόσβαση στο φάκελο γραμματοσειρών για τη διαδικασία Java έχει χορηγηθεί.

2. Εγκαταστήστε μερικές γραμματοσειρές ή χρησιμοποιήστε [FontsLoader](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsLoader).

3. Εγκαταστήστε γραμματοσειρές.

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

   * Χρήση του [FontsLoader](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Εξαίρεση: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

Αυτή η εξαίρεση εμφανίζεται σε σύστημα Linux που λείπουν το fontconfig και οι γραμματοσειρές. 

### **Λύση**

Εγκαταστήστε το fontconfig:

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

Επιπλέον, ορισμένες εκδόσεις open-jdk (π.χ., **alpine JDK**) απαιτούν επίσης εγκατεστημένες γραμματοσειρές.

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

Εγκαταστήστε το libfreetype και το fontconfig:

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

{{% alert title="TIP" color="info" %}} 
Μην ξεχάσετε να εγκαταστήσετε γραμματοσειρές ή να χρησιμοποιήσετε FontsLoader.
{{% /alert %}}
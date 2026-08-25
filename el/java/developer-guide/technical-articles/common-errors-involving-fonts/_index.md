---
title: Κοινές Εξαιρέσεις και Σφάλματα που Αφορούν τις Γραμματοσειρές σε Linux
type: docs
weight: 200
url: /el/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Εξαίρεση γραμματοσειράς, Σφάλμα γραμματοσειράς, Linux, Java, Aspose.Slides για Java"
description: "Εξαιρέσεις και σφάλματα γραμματοσειρών σε Linux"
---
## **Επισκόπηση**

Όταν το Aspose.Slides χρησιμοποιείται σε Linux, ενδέχεται να προκύψουν προβλήματα σχετιζόμενα με τις γραμματοσειρές εάν η διεργασία Java δεν μπορεί να έχει πρόσβαση στους απαιτούμενους φακέλους γραμματοσειρών ή στο προσωρινό κατάλογο, εάν δεν υπάρχουν εγκατεστημένες γραμματοσειρές στο σύστημα, ή εάν λείπουν απαιτούμενες σύστημα βιβλιοθήκες όπως το fontconfig ή το libfreetype.

Αυτό το άρθρο περιγράφει συνήθη σφάλματα και εξαιρέσεις σχετικές με τις γραμματοσειρές σε Linux και παρέχει λύσεις για την επίλυσή τους. Εξηγεί πώς να ελέγξετε την πρόσβαση στους φακέλους γραμματοσειρών και TEMP, να εγκαταστήσετε τις απαιτούμενες γραμματοσειρές και βιβλιοθήκες, και να χρησιμοποιήσετε `FontsLoader` για να φορτώσετε γραμματοσειρές χωρίς να τις εγκαταστήσετε καθολικά στο σύστημα.

## **Απουσία Κειμένου ή Εικόνων (EMF ή WMF) Όταν ο Κώδικας Εκτελείται σε Linux**

Αυτό το πρόβλημα εμφανίζεται σε συστήματα με περιορισμούς στις παρακάτω περιπτώσεις:

1. Όταν δεν υπάρχουν εγκατεστημένες γραμματοσειρές ή όταν ο φάκελος γραμματοσειρών για τη διεργασία Java δεν είναι προσβάσιμος
2. Όταν ο φάκελος TEMP δεν είναι προσβάσιμος.

### **Λύση**

Ελέγξτε και επιβεβαιώστε ότι έχει δοθεί πρόσβαση στον φάκελο TEMP και στον φάκελο γραμματοσειρών. 

{{% alert color="warning" %}}
Σε ορισμένες περιπτώσεις, ενδέχεται να μην μπορείτε να παρέχετε πρόσβαση σε φακέλους λόγω περιορισμών που επιβάλλει το περιβάλλον ή μια πολιτική ασφαλείας. Δοκιμάστε τις ακόλουθες παρακάμψεις:
{{% /alert %}}

**Παράκαμψη**

Χρησιμοποιήστε [FontsLoader](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsLoader) για να φορτώσετε τις απαιτούμενες γραμματοσειρές χωρίς να τις εγκαταστήσετε:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Εάν δεν είναι δυνατόν να προσπελαστεί ο φάκελος TEMP, χρησιμοποιήστε αυτόν τον κώδικα για να ορίσετε άλλον φάκελο ως TEMP για τη Java:
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

## **Εξαίρεση: InvalidOperationException: Αδυναμία Εύρεσης Καμίας Εγκατεστημένης Γραμματοσειράς στο Σύστημα**

Αυτή η εξαίρεση εμφανίζεται όταν

1) η διεργασία Java δεν μπορεί να προσπελάσει το φάκελο γραμματοσειρών
2) δεν έχουν εγκατασταθεί γραμματοσειρές.

### **Λύση**

1. Ελέγξτε και επιβεβαιώστε ότι έχει δοθεί πρόσβαση στο φάκελο γραμματοσειρών για τη διεργασία Java.

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

   * Using [FontsLoader](https://reference.aspose.com/slides/el/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Εξαίρεση: InternalError: InvocationTargetException**

Κατά τη μετατροπή ενός αρχείου PPTX σε PDF σε Linux, η μετατροπή μπορεί να αποτύχει με `java.lang.InternalError: java.lang.reflect.InvocationTargetException`. Εάν το υποκείμενο σφάλμα δηλώνει `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`, η ρύθμιση γραμματοσειρών του Linux δεν είναι διαθέσιμη ή η προσωρινή μνήμη της δεν έχει αρχικοποιηθεί.

### **Λύση**

Εγκαταστήστε το fontconfig και ξαναχτίστε την προσωρινή μνήμη γραμματοσειρών:

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **Εξαίρεση: NoClassDefFoundError: Αδυναμία Αρχικοποίησης της Κλάσης com.aspose.slides.internal.ey.this**

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

Επιπλέον, ορισμένες εκδόσεις του open-jdk (για παράδειγμα, **alpine JDK**) επίσης **απαιτούν εγκατεστημένες γραμματοσειρές**.

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

## **Εξαίρεση: UnsatisfiedLinkError: libfreetype.so.6: Αδυναμία Άνοιγμα Κοινού Αρχείου: Δεν Υπάρχει Τέτοιο Αρχείο ή Κατάλογος**

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
Μην ξεχνάτε να εγκαθιστάτε γραμματοσειρές ή να χρησιμοποιείτε FontsLoader.
{{% /alert %}}
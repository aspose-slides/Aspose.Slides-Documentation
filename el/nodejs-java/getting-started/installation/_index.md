---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/nodejs-java/installation/
keywords:
- εγκατάσταση Aspose.Slides
- λήψη Aspose.Slides
- χρήση Aspose.Slides
- εγκατάσταση Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εγκαταστήστε το Aspose.Slides για Node.js μέσω Java από το npm στα Windows, Linux και macOS: το JDK, το Python και τα εργαλεία κατασκευής C++ που χρειάζεται, την εντολή npm, και ένα πρώτο script για να ελέγξετε την εγκατάσταση."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εγκαταστήσετε το Aspose.Slides for Node.js via Java σε Windows, Linux και macOS, και πώς να ελέγξετε ότι η εγκατάσταση λειτουργεί.

Το Aspose.Slides for Node.js via Java διανέμεται ως το πακέτο `aspose.slides.via.java` στο npm. Εκτελεί το Aspose.Slides σε μια εικονική μηχανή Java μέσω του πακέτου [`java`](https://github.com/joeferner/node-java), ενός αυτόχθονα πρόσθετου Node.js που το npm μεταγλωττίζει στον υπολογιστή σας κατά την εγκατάσταση. Γι' αυτό η εγκατάσταση απαιτεί, εκτός του Node.js, τα εξής:

- **Java Development Kit (JDK) 8 ή νεότερο.** Ένα μόνο runtime Java δεν είναι αρκετό: η διαδικασία κατασκευής χρειάζεται τα αρχεία κεφαλίδας του JDK.
- **Python 3**, ο οποίος χρησιμοποιείται από το εργαλείο κατασκευής [node-gyp](https://github.com/nodejs/node-gyp).
- **Σειρά εργαλείων κατασκευής C++** για το λειτουργικό σας σύστημα.

## **Προαπαιτούμενα**

### **Windows**

1. Εγκαταστήστε το [Node.js](https://nodejs.org/en/download) 20 ή νεότερο.  
1. Εγκαταστήστε ένα JDK, για παράδειγμα το [Eclipse Temurin](https://adoptium.net/), και ορίστε τη μεταβλητή περιβάλλοντος `JAVA_HOME` στο φάκελο εγκατάστασής του. Η διαδικασία κατασκευής χρησιμοποιεί το JDK στο οποίο δείχνει η `JAVA_HOME`.  
1. Εγκαταστήστε το [Python 3](https://www.python.org/downloads/).  
1. Εγκαταστήστε τα [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) με το workload **Desktop development with C++**. Διατηρήστε τα προεπιλεγμένα στοιχεία του workload, τα οποία περιλαμβάνουν **MSVC v143 - VS 2022 C++ x64/x86 build tools** και το **Windows 11 SDK**. Το Visual Studio 2026 δεν λειτουργεί: η έκδοση του node-gyp που χρησιμοποιεί το πακέτο `java` δεν το αναγνωρίζει.

### **Linux**

Εγκαταστήστε το Node.js 20 ή νεότερο από το [nodejs.org](https://nodejs.org/en/download) ή από το αποθετήριο πακέτων της διανομής σας. Στη συνέχεια εγκαταστήστε ένα JDK, το Python 3 και τα εργαλεία κατασκευής C++. Στο Debian και το Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Σε Linux, η διαδικασία κατασκευής βρίσκει το εγκατεστημένο JDK χωρίς περαιτέρω ρύθμιση. Εάν είναι εγκατεστημένα πολλαπλά JDK, ορίστε τη `JAVA_HOME` στο που θέλετε να χρησιμοποιήσετε.

### **macOS**

Εγκαταστήστε το Node.js 20 ή νεότερο, ένα JDK, και τα Xcode Command Line Tools, τα οποία περιλαμβάνουν το Python 3 και τον μεταγλωττιστή C++. Δείτε τη σελίδα [Troubleshooting Installation](/slides/el/nodejs-java/troubleshooting-installation/) για σημειώσεις ειδικά για macOS.

## **Εγκατάσταση από npm**

Δημιουργήστε έναν φάκελο έργου και εγκαταστήστε το πακέτο:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Το npm κατεβάζει το Aspose.Slides και μεταγλωττίζει τη γέφυρα `java`, πράξη που μπορεί να διαρκέσει λίγα λεπτά. Εάν η μεταγλώττιση αποτύχει, δείτε τη σελίδα [Troubleshooting Installation](/slides/el/nodejs-java/troubleshooting-installation/).

## **Έλεγχος εγκατάστασης**

Δημιουργήστε ένα αρχείο με όνομα *hello.js* στον φάκελο του έργου με τον παρακάτω κώδικα. Δημιουργεί μια παρουσίαση, προσθέτει ένα πλαίσιο κειμένου στην πρώτη διαφάνειά της και αποθηκεύει το αποτέλεσμα ως *hello.pptx*:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Το Aspose.Slides εκτελείται σε μια εικονική μηχανή Java που κρατά το Node.js σε εκτέλεση, επομένως τερματίστε τη διαδικασία ρητά.
process.exit(0);
```

Εκτελέστε το script:

```bash
node hello.js
```

Εάν το *hello.pptx* εμφανιστεί στον φάκελο του έργου, η εγκατάσταση λειτουργεί. Η εικονική μηχανή Java που εκτελεί το Aspose.Slides εμποδίζει το Node.js να τερματιστεί από μόνο του, γι' αυτό το script τελειώνει με `process.exit(0)`. Η σελίδα [Create Presentations](/slides/el/nodejs-java/create-presentation/) εξηγεί τον κώδικα.

## **Εγκατάσταση από αρχείο ZIP**

Το πακέτο είναι επίσης διαθέσιμο ως αρχείο ZIP με το ίδιο περιεχόμενο με το npm πακέτο. Για να το εγκαταστήσετε από το αρχείο:

1. Εγκαταστήστε τις προαπαιτήσεις για το λειτουργικό σας σύστημα, όπως περιγράφηκε παραπάνω.  
1. Κατεβάστε το αρχείο από τη [σελίδα λήψης Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/el/nodejs-java/).  
1. Δημιουργήστε έναν φάκελο έργου:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

1. Αποσυμπιέστε το αρχείο σε έναν υποφάκελο με όνομα *aspose.slides.via.java* μέσα στον φάκελο του έργου, έτσι ώστε το *package.json* του αρχείου να βρίσκεται στο *hello-slides/aspose.slides.via.java/package.json*.  
1. Εγκαταστήστε το πακέτο από αυτόν τον φάκελο:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    Το npm εγκαθιστά τη γέφυρα `java` από την οποία εξαρτάται το πακέτο και τη μεταγλωττίζει, όπως κάνει για το npm πακέτο.

1. Ελέγξτε την εγκατάσταση όπως περιγράφηκε στη [Check the Installation](#check-the-installation).

## **Συχνές ερωτήσεις**

**Υπάρχει δωρεάν έκδοση ή περιορισμός δοκιμής;**

Ναι. Χωρίς άδεια, το Aspose.Slides λειτουργεί σε λειτουργία αξιολόγησης: προσθέτει υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει και περικόπτει κείμενο που διαβάζεται από παρουσιάσεις. Για να αφαιρέσετε αυτούς τους περιορισμούς, εφαρμόστε μια έγκυρη [license](/slides/el/nodejs-java/licensing/).

**Γιατί το script μου δεν τερματίζει μετά το τέλος της εκτέλεσης;**

Το πακέτο `java` ξεκινά μια εικονική μηχανή Java μέσα στη διεργασία Node.js, και αυτή η εικονική μηχανή κρατά τη διεργασία ενεργή. Καλέστε `process.exit` όταν το script σας ολοκληρώσει την εργασία του.
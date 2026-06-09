---
title: Αντιμετώπιση προβλημάτων εγκατάστασης του Aspose.Slides για Node.js μέσω Java
linktitle: Αντιμετώπιση προβλημάτων εγκατάστασης
type: docs
weight: 75
url: /el/nodejs-java/troubleshooting-installation/
keywords:
- λήψη Aspose.Slides
- εγκατάσταση Aspose.Slides
- αντιμετώπιση προβλημάτων εγκατάστασης
- απαιτήσεις έκδοσης
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Αντιμετωπίστε προβλήματα εγκατάστασης του Aspose.Slides για Node.js μέσω Java, διορθώστε κοινά σφάλματα και εξαρτήσεις, και εξασφαλίστε ομαλή εργασία με PPT, PPTX και ODP."
---
## **Εισαγωγή**

Κατά την [εγκατάσταση](/slides/el/nodejs-java/installation/) `aspose.slides.via.java` χρησιμοποιώντας `npm`, υπάρχουν περιπτώσεις όπου προκύπτουν σφάλματα κατά την μεταγλώττιση των μονάδων `java` και `node-gyp`. Εξετάσαμε αυτά τα σφάλματα πιο λεπτομερώς και εντοπίσαμε συγκεκριμένες απαιτήσεις για τις εκδόσεις των εγκατεστημένων προγραμμάτων και πακέτων. 

## **Απαιτήσεις έκδοσης**

1. Για Node.js 12 και παλαιότερο:
   - Python όχι υψηλότερο από 3.10.
   - Για Windows, συνιστάται η εγκατάσταση του Visual Studio Build Tools όχι νεότερου από το 2017.
   - Έκδοση πακέτου npm java: 0.12.1.

2. Για Node.js 13:
   - Ίδιες απαιτήσεις όπως για Node.js 12.

3. Για Node.js 14:
   - Python 3.10.
   - Έκδοση πακέτου npm java: 0.14.0.

4. Για Node.js 15:
   - Python 3.12.
   - Έκδοση πακέτου npm java: 0.14.0.

5. Για Node.js 16 και νεότερο:
   - Python 3.12.
   - Έκδοση πακέτου npm java: 0.14.0.

**Ακολουθήστε τις οδηγίες παρακάτω για να εγκαταστήσετε τα απαιτούμενα προγράμματα.**

### **Εγκατάσταση σε Unix**

- Εγκαταστήστε [Node.js](https://nodejs.org/en/download).
- Εγκαταστήστε [Python](https://devguide.python.org/versions/).
- Εγκαταστήστε Java (JDK 1.8).
- Εγκαταστήστε ένα κατάλληλο εργαλείο αλυσίδας μεταγλωττιστών C/C++, όπως το [GCC](https://gcc.gnu.org).

### **Εγκατάσταση σε macOS**

- Εγκαταστήστε [Node.js](https://nodejs.org/en/download).
- Εγκαταστήστε [Python](https://devguide.python.org/versions/).
- Εγκαταστήστε Java (JDK 1.8) και τροποποιήστε την ενότητα JVMCapabilities στο /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist με προνόμια διαχειριστή. Το jdk1.8.x_xxx.jdk εξαρτάται από την έκδοση του jdk σας. Κάντε το να φαίνεται έτσι:
```
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
- Εγκαταστήστε τα `Xcode Command Line Tools` ξεχωριστά τρέχοντας `xcode-select --install`. -- OR -- Εναλλακτικά, εάν έχετε ήδη εγκατεστημένο το [πλήρες Xcode](https://developer.apple.com/xcode/download/), μπορείτε να εγκαταστήσετε τα Command Line Tools από το μενού `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Εγκατάσταση σε Windows**

- Εγκαταστήστε [Node.js](https://nodejs.org/en/download).
- Εγκαταστήστε [Python](https://devguide.python.org/versions/) από το [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Εγκαταστήστε Java (JDK 1.8).
- Εγκαταστήστε το [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (χρησιμοποιώντας το "Visual C++ build tools" εάν χρησιμοποιείτε έκδοση παλαιότερη από το VS2019, διαφορετικά χρησιμοποιήστε το φορτίο εργασίας "Desktop development with C++" ή το [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) με το φορτίο εργασίας "Desktop development with C++").

Βεβαιωθείτε ότι το Node.js, το Python και το Java έχουν προστεθεί στη μεταβλητή PATH.

## **Εγκατάσταση του Aspose.Slides για Node.js μέσω Java σε έκδοση Node.js 14 και νεότερη**

Απλώς χρησιμοποιήστε την εντολή:
```
npm i aspose.slides.via.java
```

## **Εγκατάσταση του Aspose.Slides για Node.js μέσω Java σε έκδοση Node.js 12 ή 13**

Το Aspose.Slides for Node.js via Java χρειάζεται να εγκατασταθεί χειροκίνητα. Χρησιμοποιήστε την ακόλουθη εντολή:

- Για Node.js 12:
```
npm i java@0.12.1
```
- Για Node.js 13:
```
npm i java@0.13.0
```

Μετά από αυτό, κατεβάστε [aspose.slides.via.java](https://releases.aspose.com/slides/el/nodejs-java/) και εξαγάγετε το στον φάκελο `node_modules/aspose.slides.via.java`.

## **Επικύρωση της εγκατάστασης**

Για την επικύρωση της εγκατάστασης, δημιουργήστε ένα αρχείο `index.js` στη ρίζα του έργου σας με το ακόλουθο περιεχόμενο:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Εκτελέστε αυτό το αρχείο χρησιμοποιώντας την εντολή `node index.js`.

## **Πρόσθετες Πληροφορίες**

Δεν είναι δυνατόν να καλυφθούν όλα τα πιθανά προβλήματα εντός του αυτού του άρθρου. Καθώς τα προβλήματα προκύπτουν εξαιτίας της μεταγλώττισης των μονάδων `java` και `node-gyp`, οι παρακάτω σύνδεσμοι θα είναι επίσης χρήσιμοι:
- [Εγκατάσταση java](https://www.npmjs.com/package/java#installation)
- [Εγκατάσταση node-gyp](https://www.npmjs.com/package/node-gyp#installation)
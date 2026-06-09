---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/nodejs-java/installation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Μάθετε πώς να εγκαταστήσετε γρήγορα το Aspose.Slides. Οδηγός βήμα-βήμα, απαιτήσεις συστήματος και παραδείγματα κώδικα — ξεκινήστε να εργάζεστε με παρουσιάσεις PowerPoint σήμερα!"
---
## **Εισαγωγή**

Το Aspose.Slides for Node.js via Java είναι μια ανεξάρτητη από πλατφόρμα API και μπορεί να χρησιμοποιηθεί σε οποιαδήποτε πλατφόρμα (Windows, Linux και MacOS) όπου είναι εγκατεστημένα τα `Node.js` και η γέφυρα [`java`](https://www.npmjs.com/package/java).

## **Εγκατάσταση από NPM**

Μπορείτε εύκολα να εγκαταστήσετε το Aspose.Slides for Node.js via Java από το [NPM](https://www.npmjs.com/).

1. Δημιουργήστε ένα νέο φάκελο και ξεκινήστε ένα νέο έργο χρησιμοποιώντας την ακόλουθη εντολή:
	```
	$ npm init
	```
	
2. Fill in the title and version fields (leave the remaining fields with their default values).

3. Install Aspose.Slides for Node.js via Java using the following command:
	```
	$ npm install aspose.slides.via.java
	```

If you encounter any problem during the installation process, please refer to this [article](/slides/el/nodejs-java/troubleshooting-installation/).

**Usage Example**:

Create a file named `hello.js` in your project folder and add the following sample code:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Εγκατάσταση από αρχείο ZIP**

Για να εγκαταστήσετε και να χρησιμοποιήσετε το Aspose.Slides for Node.js via Java από αρχείο ZIP, ακολουθήστε αυτές τις οδηγίες:

### **Windows**

1. Εγκαταστήστε το JDK8 και διαμορφώστε τη μεταβλητή περιβάλλοντος `JAVA_HOME`.
2. Εγκαταστήστε το Node.js (https://nodejs.org/en/download/) και προσθέστε το node.exe στο `PATH`.
3. Εγκαταστήστε το node-gyp.
4. Εγκαταστήστε τα Windows Build Tools.
5. Εγκαταστήστε τη γέφυρα [`java`](https://www.npmjs.com/package/java) και εκτελέστε αυτές τις εντολές στο Command Prompt ως διαχειριστής:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Κατεβάστε το Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/el/nodejs-java/) και εξαγάγετε το στο `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Δημιουργήστε ένα αρχείο με όνομα `hello.js` στον φάκελο `aspose.slides.nodejs` χρησιμοποιώντας τον παρακάτω κώδικα δείγματος:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

8. Τώρα εκτελέστε `node hello.js` στο command prompt για να το τρέξετε.

### **Linux**

1. Εγκαταστήστε το Node.js (https://nodejs.org/en/download/).
2. Εγκαταστήστε το JDK8 για Linux και διαμορφώστε τη μεταβλητή περιβάλλοντος `JAVA_HOME`.
3. Εγκαταστήστε την python 2.x
4. Εγκαταστήστε τη γέφυρα [`java`](https://www.npmjs.com/package/java). Μπορείτε να εκτελέσετε αυτές τις εντολές στο τερματικό:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Κατεβάστε το Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/el/nodejs-java/) και εξαγάγετε το στο `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Δημιουργήστε ένα αρχείο δοκιμής με όνομα `hello.js` χρησιμοποιώντας αυτόν τον κώδικα δείγματος στον φάκελο `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Τώρα εκτελέστε `node hello.js` στο command prompt για να το τρέξετε.

### **Mac**

1. Εγκαταστήστε το Node.js (https://nodejs.org/en/download/).
2. Εγκαταστήστε το JDK8 για Mac και διαμορφώστε τη μεταβλητή περιβάλλοντος `JAVA_HOME`.
3. Τροποποιήστε την ενότητα JVMCapabilities στο `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` με δικαιώματα root. Το `jdk1.8.x_xxx.jdk` εξαρτάται από την έκδοση του jdk σας. Κάντε το να φαίνεται ως εξής:
	```xml
	<key>JavaVM</key>
		<dict>
			<key>JVMCapabilities</key>
			<array>
					<string>JNI</string>
					<string>BundledApp</string>
					<string>CommandLine</string>
			</array>
	```
4. Εγκαταστήστε την python 2.x (αν δεν είναι εγκατεστημένη).
5. Εγκαταστήστε τα Xcode Command Line Tools.
6. Εγκαταστήστε τη γέφυρα [`java`](https://www.npmjs.com/package/java). Μπορείτε να εκτελέσετε τις παρακάτω εντολές στο τερματικό:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Κατεβάστε το Aspose.Slides for Node.js via Java και εξαγάγετε το στο `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Δημιουργήστε ένα αρχείο δοκιμής με όνομα `hello.js` χρησιμοποιώντας αυτόν τον κώδικα δείγματος στον φάκελο `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Τώρα εκτελέστε `node hello.js` στο command prompt για να το τρέξετε.

{{% alert color="primary" %}}

Παρακαλώ χρησιμοποιήστε το ακόλουθο [άρθρο](https://docs.aspose.com/slides/el/nodejs-java/troubleshooting-installation/) εάν αντιμετωπίσετε σφάλματα μεταγλώττισης κατά την εγκατάσταση του Aspose.Slides for Node.js via Java.

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υπάρχει δωρεάν έκδοση ή περιορισμός δοκιμής;**

Ναι, από προεπιλογή, το Aspose.Slides λειτουργεί σε λειτουργία αξιολόγησης, η οποία προσθέτει υδατογραφήματα και μπορεί να έχει άλλους περιορισμούς. Για να αφαιρέσετε τους περιορισμούς, πρέπει να εφαρμόσετε μια έγκυρη [άδεια](/slides/el/nodejs-java/licensing/).
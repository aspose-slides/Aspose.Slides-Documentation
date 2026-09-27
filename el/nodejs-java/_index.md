---
title: Aspose.Slides για Node.js μέσω Java
second_title: Aspose.Slides για Node.js
type: docs
weight: 47
url: /el/nodejs-java/
keywords:
- τεκμηρίωση
- επεξεργασία παρουσίασης
- μετατροπή παρουσίασης
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Ξεκινήστε εδώ: εγκαταστήστε το Aspose.Slides για Node.js μέσω Java, δημιουργήστε την πρώτη παρουσίαση και βρείτε οδηγούς για τις κοινές εργασίες, την αναφορά API και την υποστήριξη."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides για Node.js μέσω Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides για Node.js μέσω Java είναι μια βιβλιοθήκη για δημιουργία, ανάγνωση, επεξεργασία και μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε εφαρμογές Node.js, χωρίς το Microsoft PowerPoint.

Φορτώνει και αποθηκεύει αρχεία PPT, PPTX, PPS, POT και ODP, συμπεριλαμβανομένων των εκδόσεων με μακροεντολές και προτύπων, και εξάγει σε PDF, XPS, HTML, SVG, TIFF, Markdown και εικόνες.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Ξεκινήστε</b></p>
<hr>
<p>ΞΕΚΙΝΗΣΤΕ</p>
<ul>
<li><a href="/slides/el/nodejs-java/installation/">Εγκατάσταση</a></li>
<li><a href="/slides/el/nodejs-java/create-presentation/">Δημιουργήστε την πρώτη σας παρουσίαση</a></li>
<li><a href="/slides/el/nodejs-java/getting-started/">Οδηγός εκκίνησης</a></li>
</ul>
<p>ΑΞΙΟΛΟΓΗΣΤΕ</p>
<ul>
<li><a href="/slides/el/nodejs-java/supported-file-formats/">Υποστηριζόμενοι τύποι αρχείων</a></li>
<li><a href="/slides/el/nodejs-java/evaluate-aspose-slides/">Περιορισμοί δοκιμής</a></li>
<li><a href="/slides/el/nodejs-java/licensing/">Άδεια χρήσης</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Δόμηση με Slides</b></p>
<hr>
<p>ΚΑΝΟΝΙΚΕΣ ΕΡΓΑΣΙΕΣ</p>
<ul>
<li><a href="/slides/el/nodejs-java/open-presentation/">Άνοιγμα παρουσίασης</a></li>
<li><a href="/slides/el/nodejs-java/save-presentation/">Αποθήκευση παρουσίασης</a></li>
<li><a href="/slides/el/nodejs-java/convert-powerpoint-to-pdf/">Μετατροπή σε PDF</a></li>
<li><a href="/slides/el/nodejs-java/convert-slide/">Απόδοση διαφάνειας ως εικόνα</a></li>
<li><a href="/slides/el/nodejs-java/manage-text/">Επεξεργασία κειμένου και σχημάτων</a></li>
</ul>
<p>ΡΟΠΟΙ ΕΡΓΑΣΙΩΝ ΣΛΑΪΔΩΝ</p>
<ul>
<li><a href="/slides/el/nodejs-java/powerpoint-charts/">Διαγράμματα</a></li>
<li><a href="/slides/el/nodejs-java/powerpoint-animation/">Κινούμενα σχέδια</a></li>
<li><a href="/slides/el/nodejs-java/manage-media-files/">Ήχος και βίντεο</a></li>
<li><a href="/slides/el/nodejs-java/presentation-design/">Σχεδίαση διαφάνειας</a></li>
<li><a href="/slides/el/nodejs-java/merge-presentation/">Συγχώνευση παρουσιάσεων</a></li>
</ul>
<p>ΠΑΡΑΔΕΙΓΜΑΤΑ</p>
<ul>
<li><a href="/slides/el/nodejs-java/examples/">Παραδείγματα ανά στοιχείο διαφάνειας</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Αναφορά &amp; Υποστήριξη</b></p>
<hr>
<p>ΑΝΑΦΟΡΑ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/el/nodejs-java/">API αναφορά</a></li>
<li><a href="https://releases.aspose.com/slides/el/nodejs-java/release-notes/">Σημειώσεις έκδοσης</a></li>
<li><a href="/slides/el/nodejs-java/known-issues/">Γνωστά προβλήματα</a></li>
<li><a href="https://releases.aspose.com/slides/el/nodejs-java/">Λήψη</a></li>
</ul>
<p>ΥΠΟΣΤΗΡΙΞΗ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/el/11">Δωρεάν φόρουμ υποστήριξης</a></li>
<li><a href="https://helpdesk.aspose.com/">Πληρωμένη υποστήριξη helpdesk</a></li>
</ul>
</div>
</div>

------

## **Η πρώτη σας παρουσίαση**

Εκτός από το Node.js 20 ή νεότερο, το πακέτο απαιτεί Java Development Kit (JDK), Python και μια αλυσίδα εργαλείων C++· επειδή το npm μεταγλωττίζει τη γέφυρα `java` κατά την εγκατάσταση. Δείτε την [Installation](/slides/el/nodejs-java/installation/) για τα βήματα σε κάθε λειτουργικό σύστημα. Στη συνέχεια δημιουργήστε ένα έργο και εγκαταστήστε το πακέτο από το npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Αποθηκεύστε αυτόν τον κώδικα ως *hello.js* στο φάκελο του έργου:

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

// Το Aspose.Slides εκτελείται σε μια εικονική μηχανή Java που διατηρεί το Node.js σε λειτουργία, έτσι τερματίστε τη διαδικασία ρητά.
process.exit(0);
```

Τρέξτε το με `node hello.js`. Το σενάριο αποθηκεύει *hello.pptx* με μία διαφάνεια που περιέχει πλαίσιο κειμένου. Χωρίς άδεια, το αποθηκευμένο αρχείο έχει υδατογράφημα αξιολόγησης — δείτε το [Licensing](/slides/el/nodejs-java/licensing/). Για περισσότερους τρόπους δημιουργίας και πλήρωσης μιας παρουσίασης, δείτε το [Create Presentations](/slides/el/nodejs-java/create-presentation/).
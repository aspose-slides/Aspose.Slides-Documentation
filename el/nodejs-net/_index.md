---
title: Aspose.Slides για Node.js μέσω .NET
second_title: Aspose.Slides για Node.js
type: docs
weight: 47
url: /el/nodejs-net/
keywords:
- τεκμηρίωση
- επεξεργασία παρουσίασης
- μετατροπή παρουσίασης
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Ξεκινήστε εδώ: εγκαταστήστε το Aspose.Slides for Node.js via .NET, δημιουργήστε την πρώτη παρουσίαση και βρείτε τους οδηγούς για συνηθισμένες εργασίες, αδειοδότηση, την αναφορά API και την υποστήριξη."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides για Node.js μέσω .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET είναι μια βιβλιοθήκη για δημιουργία, ανάγνωση, επεξεργασία και μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε εφαρμογές Node.js, χωρίς το Microsoft PowerPoint ή την αυτοματοποίηση του Office. Εκτελεί το Aspose.Slides for .NET μέσω της γέφυρας edge‑js, έτσι ώστε το JavaScript API της να αντικατοπτρίζει το .NET API, με ονόματα με camelCase.

Φορτώνει και αποθηκεύει αρχεία PPT, PPTX, PPS, POT και ODP, συμπεριλαμβανομένων των εκδόσεων με μακροεντολές και προτύπων, και εξάγει σε PDF, XPS, HTML, TIFF, Markdown και εικόνες.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Ξεκινήστε</b></p>
<hr>
<p>ΞΕΚΙΝΗΣΗ</p>
<ul>
<li><a href="/slides/el/nodejs-net/installation/">Εγκατάσταση</a></li>
<li><a href="/slides/el/nodejs-net/create-presentation/">Δημιουργήστε την πρώτη σας παρουσίαση</a></li>
<li><a href="/slides/el/nodejs-net/developer-guide/">Οδηγός προγραμματιστή</a></li>
</ul>
<p>ΑΞΙΟΛΟΓΗΣΗ</p>
<ul>
<li><a href="/slides/el/nodejs-net/evaluate-aspose-slides/">Περιορισμοί δοκιμής</a></li>
<li><a href="/slides/el/nodejs-net/licensing/">Αδειοδότηση</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Δημιουργήστε με Slides</b></p>
<hr>
<p>ΣΥΝΑΝΤΑΞΗ ΕΡΓΑΣΙΩΝ</p>
<ul>
<li><a href="/slides/el/nodejs-net/open-presentation/">Άνοιγμα και αποθήκευση παρουσίασης</a></li>
<li><a href="/slides/el/nodejs-net/convert-powerpoint-to-pdf/">Μετατροπή σε PDF</a></li>
<li><a href="/slides/el/nodejs-net/convert-slide/">Απόδοση διαφανειών ως εικόνες</a></li>
<li><a href="/slides/el/nodejs-net/manage-text/">Επεξεργασία κειμένου</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Αναφορά &amp; Υποστήριξη</b></p>
<hr>
<p>ΑΝΑΦΟΡΑ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/el/net/">.NET API αναφορά</a></li>
<li><a href="https://releases.aspose.com/slides/el/nodejs-net/release-notes/">Σημειώσεις έκδοσης</a></li>
<li><a href="https://releases.aspose.com/slides/el/nodejs-net/">Λήψη</a></li>
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

Χρειάζεστε Node.js 22 ή 24 και το .NET SDK 8 ή νεότερο· το Linux απαιτεί επίσης μερικά πακέτα συστήματος. [Εγκατάσταση](/slides/el/nodejs-net/installation/) τα παραθέτει μαζί με τις πλατφόρμες που δοκιμάστηκαν. Δημιουργήστε ένα πρότζεκτ, προσθέστε μια παράκαμψη που ενημερώνει το npm ποια έκδοση του edge‑js να εγκαταστήσει, και εγκαταστήστε το πακέτο:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Μία φορά ανά μηχάνημα, αποκαταστήστε τα .NET πακέτα στα οποία εξαρτάται η βιβλιοθήκη. Αποθηκεύστε το αρχείο `deps.csproj` από [Αποκατάσταση των .NET Εξαρτήσεων](/slides/el/nodejs-net/installation/#restore-the-net-dependencies) σε έναν φάκελο `deps` μέσα στον φάκελο του πρότζεκτ, και στη συνέχεια εκτελέστε:

```sh
dotnet restore deps/deps.csproj
```

Αποθηκεύστε αυτόν τον κώδικα ως *hello.js* στον φάκελο του πρότζεκτ:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Μια νέα παρουσίαση περιέχει μία κενή διαφάνεια.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Η θέση και το μέγεθος δίνονται σε points (1/72 ίντσα): x, y, πλάτος, ύψος.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Αποδέσμευση του αντικειμένου .NET που υποστηρίζει την παρουσίαση.
    presentation.dispose();
}
```

Τρέξτε το από τον φάκελο του πρότζεκτ:

```sh
node hello.js
```

Το σενάριο εκτυπώνει `Saved hello.pptx` και αποθηκεύει το *hello.pptx* με μία διαφάνεια που περιέχει ένα ορθογώνιο με το κείμενο. Χωρίς άδεια, το αποθηκευμένο αρχείο φέρει ένα υδατογράφημα αξιολόγησης — δείτε [Αδειοδότηση](/slides/el/nodejs-net/licensing/). Για περισσότερους τρόπους δημιουργίας και γέμισης μιας παρουσίασης, δείτε [Δημιουργία Παρουσίασης](/slides/el/nodejs-net/create-presentation/).
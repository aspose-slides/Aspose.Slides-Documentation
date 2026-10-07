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
description: "Ξεκινήστε εδώ: εγκαταστήστε το Aspose.Slides για Node.js μέσω .NET, δημιουργήστε την πρώτη παρουσίαση και βρείτε τις οδηγίες για τις κοινές εργασίες, την αδειοδότηση, την αναφορά API και την υποστήριξη."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Το Aspose.Slides για Node.js μέσω .NET είναι μια βιβλιοθήκη για δημιουργία, ανάγνωση, επεξεργασία και μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε εφαρμογές Node.js, χωρίς το Microsoft PowerPoint ή τη Αυτόματη Επεξεργασία του Office. Εκτελεί το Aspose.Slides για .NET μέσω της γέφυρας edge‑js, έτσι ώστε το JavaScript API του να αντικατοπτρίζει το .NET API, με ονόματα μελών σε camelCase.

Φορτώνει και αποθηκεύει αρχεία PPT, PPTX, PPS, POT και ODP, συμπεριλαμβανομένων των εκδόσεων με μακροεντολές και των προτύπων, και εξάγει σε PDF, XPS, HTML, TIFF, Markdown και εικόνες.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Ξεκινήστε</b></p>
<hr>
<p>ΞΕΚΙΝΗΜΑ</p>
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
<p><b>Δομήστε με Slides</b></p>
<hr>
<p>ΚΑΝΟΝΙΚΕΣ ΕΡΓΑΣΙΕΣ</p>
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
<li><a href="https://reference.aspose.com/slides/net/">Αναφορά API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Σημειώσεις έκδοσης</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">Σελίδα προϊόντος</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Λήψη</a></li>
</ul>
<p>ΥΠΟΣΤΗΡΙΞΗ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Δωρεάν φόρουμ υποστήριξης</a></li>
<li><a href="https://helpdesk.aspose.com/">Πληρωμένο helpdesk υποστήριξης</a></li>
</ul>
</div>
</div>

------

## **Η πρώτη σας παρουσίαση**

Χρειάζεστε Node.js 22 ή 24 και το .NET SDK 8 ή νεότερο· το Linux χρειάζεται επίσης μερικά πακέτα συστήματος. Η [Εγκατάσταση](/slides/el/nodejs-net/installation/) τα καταγράφει και τις πλατφόρμες που δοκιμήθηκαν. Δημιουργήστε ένα έργο, προσθέστε μια παράκαμψη που ενημερώνει το npm για την έκδοση του edge‑js που θα εγκατασταθεί, και εγκαταστήστε το πακέτο:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Μία φορά ανά μηχάνημα, αποκαταστήστε τα πακέτα .NET από τα οποία εξαρτάται η βιβλιοθήκη. Αποθηκεύστε το αρχείο `deps.csproj` από την [Αποκατάσταση των εξαρτήσεων .NET](/slides/el/nodejs-net/installation/#restore-the-net-dependencies) σε έναν φάκελο `deps` μέσα στο φάκελο του έργου, και έπειτα εκτελέστε:

```sh
dotnet restore deps/deps.csproj
```

Αποθηκεύστε αυτόν τον κώδικα ως *hello.js* στο φάκελο του έργου:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Μία νέα παρουσίαση περιέχει μία κενή διαφάνεια.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Η θέση και το μέγεθος είναι σε μονάδες point (1/72 ίντσα): x, y, πλάτος, ύψος.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Απελευθερώστε το αντικείμενο .NET που υποστηρίζει την παρουσίαση.
    presentation.dispose();
}
```

Εκτελέστε το από το φάκελο του έργου:

```sh
node hello.js
```

Το script εκτυπώνει `Saved hello.pptx` και αποθηκεύει το *hello.pptx* με μία διαφάνεια που περιέχει ένα ορθογώνιο με το κείμενο. Χωρίς άδεια, το αποθηκευμένο αρχείο φέρει υδατογράφημα αξιολόγησης — δείτε το [Αδειοδότηση](/slides/el/nodejs-net/licensing/). Για περισσότερους τρόπους δημιουργίας και συμπλήρωσης μιας παρουσίασης, δείτε το [Δημιουργία Παρουσίασης](/slides/el/nodejs-net/create-presentation/).
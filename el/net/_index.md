---
title: Aspose.Slides για .NET
second_title: Aspose.Slides για .NET
type: docs
weight: 10
url: /el/net/
keywords:
- τεκμηρίωση
- επεξεργασία παρουσιάσεων
- μετατροπή παρουσιάσεων
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Ξεκινήστε εδώ: εγκαταστήστε το Aspose.Slides for .NET, δημιουργήστε την πρώτη παρουσίαση και βρείτε τους οδηγούς για κοινές εργασίες, την τεκμηρίωση API και την υποστήριξη."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Το Aspose.Slides for .NET είναι μια βιβλιοθήκη κλάσεων για τη δημιουργία, ανάγνωση, επεξεργασία και μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε εφαρμογές .NET, χωρίς το Microsoft PowerPoint ή την αυτοματοποίηση του Office.

Φορτώνει και αποθηκεύει αρχεία PPT, PPTX, PPS, POT και ODP, συμπεριλαμβανομένων των εκδόσεων με μακροεντολές και προτύπων, και εξάγει σε PDF, XPS, HTML, SVG, TIFF, Markdown και εικόνες.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Ξεκινήστε</b></p>
<hr>
<p>ΞΕΚΙΝΗΜΑ</p>
<ul>
<li><a href="/slides/el/net/installation/">Εγκατάσταση</a></li>
<li><a href="/slides/el/net/create-presentation/">Δημιουργήστε την πρώτη σας παρουσίαση</a></li>
<li><a href="/slides/el/net/getting-started/">Οδηγός έναρξης</a></li>
</ul>
<p>ΑΞΙΟΛΟΓΗΣΗ</p>
<ul>
<li><a href="/slides/el/net/supported-file-formats/">Υποστηριζόμενες μορφές αρχείων</a></li>
<li><a href="/slides/el/net/evaluate-aspose-slides/">Περιορισμοί δοκιμής</a></li>
<li><a href="/slides/el/net/licensing/">Αδειοδότηση</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Δημιουργία με Slides</b></p>
<hr>
<p>ΚΑΝΟΝΙΚΕΣ ΕΡΓΑΣΙΕΣ</p>
<ul>
<li><a href="/slides/el/net/open-presentation/">Άνοιγμα παρουσίασης</a></li>
<li><a href="/slides/el/net/save-presentation/">Αποθήκευση παρουσίασης</a></li>
<li><a href="/slides/el/net/convert-powerpoint-to-pdf/">Μετατροπή σε PDF</a></li>
<li><a href="/slides/el/net/convert-slide/">Απόδοση διαφανειών ως εικόνες</a></li>
<li><a href="/slides/el/net/manage-text/">Επεξεργασία κειμένου και σχημάτων</a></li>
</ul>
<p>ΔΙΑΔΡΟΜΕΣ SLIDES</p>
<ul>
<li><a href="/slides/el/net/powerpoint-charts/">Διαγράμματα</a></li>
<li><a href="/slides/el/net/powerpoint-animation/">Κινούμενα σχέδια</a></li>
<li><a href="/slides/el/net/manage-media-files/">Ήχος και βίντεο</a></li>
<li><a href="/slides/el/net/presentation-design/">Σχεδίαση διαφανειών</a></li>
<li><a href="/slides/el/net/merge-presentation/">Συγχώνευση παρουσιάσεων</a></li>
</ul>
<p>ΠΑΡΑΔΕΙΓΜΑΤΑ</p>
<ul>
<li><a href="/slides/el/net/examples/">Παραδείγματα ανά στοιχείο διαφάνειας</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Παραδείγματα στο GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Αναφορά &amp; Υποστήριξη</b></p>
<hr>
<p>ΑΝΑΦΟΡΑ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Τεκμηρίωση API</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Σημειώσεις έκδοσης</a></li>
<li><a href="/slides/el/net/known-issues/">Γνωστά ζητήματα</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Λήψη</a></li>
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

Δημιουργήστε μια εφαρμογή κονσόλας με το .NET SDK 6 ή νεότερο:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Στη συνέχεια προσθέστε ένα πακέτο για την πλατφόρμα σας:

- Σε Windows: `dotnet add package Aspose.Slides.NET`
- Σε Linux και macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — δείτε [Εγκατάσταση](/slides/el/net/installation/) για την προαπαιτούμενη ρύθμιση στο Linux και για τα συστήματα που χρειάζονται Aspose.Slides.NET αντί αυτού.

Αντικαταστήστε τα περιεχόμενα του *Program.cs* με αυτόν τον κώδικα και εκτελέστε `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Το πρόγραμμα αποθηκεύει το *hello.pptx* με μία διαφάνεια που περιέχει ένα πλαίσιο κειμένου. Χωρίς άδεια, το αποθηκευμένο αρχείο περιέχει υδατογράφημα αξιολόγησης — δείτε [Αδειοδότηση](/slides/el/net/licensing/). Για περισσότερους τρόπους δημιουργίας και πλήρωσης μιας παρουσίασης, δείτε [Δημιουργία Παρουσιάσεων](/slides/el/net/create-presentation/).
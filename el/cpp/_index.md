---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /el/cpp/
keywords:
- τεκμηρίωση
- επεξεργασία παρουσίασης
- μετατροπή παρουσίασης
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Ξεκινήστε εδώ: εγκαταστήστε το Aspose.Slides for C++, δημιουργήστε την πρώτη παρουσίαση και βρείτε τους οδηγούς για κοινές εργασίες, την τεκμηρίωση API και την υποστήριξη."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Το Aspose.Slides for C++ είναι μια εγγενής βιβλιοθήκη C++ για δημιουργία, ανάγνωση, επεξεργασία και μετατροπή παρουσιάσεων PowerPoint και OpenDocument, χωρίς το Microsoft PowerPoint ή την αυτοματοποίηση του Office.

Φορτώνει και αποθηκεύει αρχεία PPT, PPTX, PPS, POT και ODP, περιλαμβάνοντας εκδόσεις με μακροεντολές και πρότυπα, και εξάγει σε PDF, XPS, HTML, SVG, TIFF, Markdown και εικόνες.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Ξεκινήστε</b></p>
<hr>
<p>ΞΕΚΙΝΗΣΤΕ</p>
<ul>
<li><a href="/slides/el/cpp/installation/">Εγκατάσταση</a></li>
<li><a href="/slides/el/cpp/create-presentation/">Δημιουργία της πρώτης σας παρουσίασης</a></li>
<li><a href="/slides/el/cpp/getting-started/">Οδηγός έναρξης</a></li>
</ul>
<p>ΑΞΙΟΛΟΓΗΣΤΕ</p>
<ul>
<li><a href="/slides/el/cpp/supported-file-formats/">Υποστηριζόμενες μορφές αρχείων</a></li>
<li><a href="/slides/el/cpp/evaluate-aspose-slides/">Περιορισμοί δοκιμής</a></li>
<li><a href="/slides/el/cpp/licensing/">Αδειοδότηση</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Δημιουργήστε με Slides</b></p>
<hr>
<p>ΚΑΝΟΝΙΚΕΣ ΕΡΓΑΣΙΕΣ</p>
<ul>
<li><a href="/slides/el/cpp/open-presentation/">Άνοιγμα παρουσίασης</a></li>
<li><a href="/slides/el/cpp/save-presentation/">Αποθήκευση παρουσίασης</a></li>
<li><a href="/slides/el/cpp/convert-powerpoint-to-pdf/">Μετατροπή σε PDF</a></li>
<li><a href="/slides/el/cpp/convert-slide/">Απόδοση διαφανειών ως εικόνες</a></li>
<li><a href="/slides/el/cpp/manage-text/">Επεξεργασία κειμένου και σχημάτων</a></li>
</ul>
<p>ΡΟΙΣΜΟΙ ΕΡΓΑΣΙΩΝ SLIDES</p>
<ul>
<li><a href="/slides/el/cpp/powerpoint-charts/">Διαγράμματα</a></li>
<li><a href="/slides/el/cpp/powerpoint-animation/">Κινούμενα σχέδια</a></li>
<li><a href="/slides/el/cpp/manage-media-files/">Ήχος και βίντεο</a></li>
<li><a href="/slides/el/cpp/presentation-design/">Σχεδίαση διαφάνειας</a></li>
<li><a href="/slides/el/cpp/merge-presentation/">Συγχώνευση παρουσιάσεων</a></li>
</ul>
<p>ΠΑΡΑΔΕΙΓΜΑΤΑ</p>
<ul>
<li><a href="/slides/el/cpp/examples/">Παραδείγματα ανά στοιχείο διαφάνειας</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Παραδείγματα στο GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Αναφορά &amp; Υποστήριξη</b></p>
<hr>
<p>ΑΝΑΦΟΡΑ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">Τεκμηρίωση API</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">Σημειώσεις έκδοσης</a></li>
<li><a href="/slides/el/cpp/known-issues/">Γνωστά προβλήματα</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">Λήψη</a></li>
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

Στα Windows, δημιουργήστε ένα έργο **Console App** C++ στο Visual Studio και εγκαταστήστε το πακέτο NuGet στην Κονσόλα Διαχειριστή Πακέτων (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

Στα Linux, κατεβάστε το πακέτο ZIP για Linux και ρυθμίστε το έργο CMake όπως περιγράφεται στην [Εγκατάσταση](/slides/el/cpp/installation/#linux).

Στη συνέχεια, χρησιμοποιήστε αυτόν τον κώδικα ως το κύριο αρχείο πηγαίου κώδικα του προγράμματός σας. Δημιουργεί μια παρουσίαση με ένα πλαίσιο κειμένου και την αποθηκεύει:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Για να το εκτελέσετε στα Windows, επιλέξτε την πλατφόρμα **x64** στη γραμμή εργαλείων και πατήστε **Ctrl+F5**. Στα Linux, αποθηκεύστε το ως *main.cpp* στο φάκελο του έργου, στη συνέχεια δημιουργήστε το και τρέξτε το εκεί:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

Το πρόγραμμα αποθηκεύει το *hello.pptx* με μία διαφάνεια που περιέχει ένα πλαίσιο κειμένου. Χωρίς άδεια, το αποθηκευμένο αρχείο περιέχει υδατογράφημα αξιολόγησης — δείτε την [Αδειοδότηση](/slides/el/cpp/licensing/). Για περισσότερους τρόπους δημιουργίας και συμπλήρωσης παρουσίασης, δείτε την [Δημιουργία Παρουσιάσεων](/slides/el/cpp/create-presentation/).
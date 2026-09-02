---
title: Διαχείριση Αντικειμένων Μελάνης Παρουσίασης σε C++
linktitle: Διαχείριση Μελάνης
type: docs
weight: 95
url: /el/cpp/manage-ink/
keywords:
- μελάνη
- αντικείμενο μελάνης
- ίχνος μελάνης
- διαχείριση μελάνης
- σχεδίαση μελάνης
- σχέδιο
- εξαγωγή μελάνης
- απόδοση μελάνης
- απόκρυψη μελάνης
- IInkOptions
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Διαχειριστείτε τα αντικείμενα μελάνης του PowerPoint, επεξεργαστείτε τα ίχνη και τις ιδιότητες του πινέλου, και ελέγξτε την εμφάνιση της μελάνης κατά την εξαγωγή σε PDF, HTML, SVG, TIFF και εικόνα με το Aspose.Slides για C++."
---
## **Εισαγωγή**

Το PowerPoint παρέχει μια δυνατότητα μελάνης που σας επιτρέπει να σχεδιάζετε ελεύθερες γραμμές. Η μελάνι μπορεί να χρησιμοποιηθεί για να τονίσει άλλα αντικείμενα, να εμφανίσει συνδέσεις και διαδικασίες, και να εστιάσει την προσοχή σε συγκεκριμένα στοιχεία σε μια διαφάνεια.

Ο χώρος ονομάτων [Aspose.Slides.Ink](https://reference.aspose.com/slides/el/cpp/aspose.slides.ink/) περιέχει τις κλάσεις και τις διεπαφές που απαιτούνται για εργασία με αντικείμενα μελάνης. Για παράδειγμα, η διεπαφή [IInk](https://reference.aspose.com/slides/el/cpp/aspose.slides.ink/iink/) αντιπροσωπεύει ένα αντικείμενο μελάνης σε μια διαφάνεια.

## **Διαφορές μεταξύ Κανονικών Αντικειμένων και Αντικειμένων Μελάνης**

Τα αντικείμενα σε μια διαφάνεια PowerPoint αντιπροσωπεύονται συνήθως από αντικείμενα σχήματος. Στην πιο απλή του μορφή, ένα σχήμα είναι ένα δοχείο που ορίζει την περιοχή του ίδιου του αντικειμένου (το πλαίσιο του) μαζί με ιδιότητες όπως το μέγεθος του δοχείου, το σχήμα και το φόντο. Για περισσότερες πληροφορίες, δείτε το [Shape Layout Format](https://docs.aspose.com/slides/el/cpp/shape-manipulations/#access-layout-formats-for-shape).

Ωστόσο, όταν το PowerPoint διαχειρίζεται ένα αντικείμενο μελάνης, αγνοεί όλες τις ιδιότητες του πλαισίου του αντικειμένου (δοχείου) εκτός από το μέγεθός του. Το μέγεθος της περιοχής του δοχείου καθορίζεται από τις τυπικές μεθόδους [IShape::get_Width](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_width/) και [IShape::get_Height](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ίχνη Μελάνης**

Ένα ίχνος μελάνης είναι ένα βασικό στοιχείο που χρησιμοποιείται για την καταγραφή της τροχιάς ενός στυλό καθώς ο χρήστης γράφει ψηφιακή μελάνη. Ένα ίχνος αποθηκεύει μια ακολουθία συνδεδεμένων σημείων.

Η πιο απλή μορφή κωδικοποίησης καθορίζει τις συντεταγμένες X και Y κάθε δείγματος σημείου. Όταν όλα τα συνδεδεμένα σημεία αποδοθούν, παράγουν μια εικόνα όπως αυτή:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ιδιότητες Πινέλου για Σχέδιο**

Ένα πινέλο χρησιμοποιείται για να σχεδιάσει γραμμές που συνδέουν τα σημεία ενός ίχνους μελάνης. Το πινέλο έχει το δικό του χρώμα και μέγεθος, που αντιπροσωπεύονται από τις μεθόδους [IInkBrush::get_Color](https://reference.aspose.com/slides/el/cpp/aspose.slides.ink/iinkbrush/get_color/) και [IInkBrush::get_Size](https://reference.aspose.com/slides/el/cpp/aspose.slides.ink/iinkbrush/get_size/).

### **Ορισμός Χρώματος Πινέλου Μελάνης**

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Ορισμός Μεγέθους Πινέλου Μελάνης**

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

Γενικά, το πλάτος και το ύψος ενός πινέλου δεν ταιριάζουν, επομένως το PowerPoint δεν εμφανίζει το μέγεθος του πινέλου (η αντίστοιχη ενότητα δεδομένων είναι ανοιχτή σε γκρι). Όταν το πλάτος και το ύψος του πινέλου ταιριάζουν, το PowerPoint εμφανίζει το μέγεθός του ως εξής:

![ink_powerpoint3](ink_powerpoint3.png)

Για σαφήνεια, ας αυξήσουμε το ύψος του αντικειμένου μελάνης και να εξετάσουμε τις σημαντικές διαστάσεις:

![ink_powerpoint4](ink_powerpoint4.png)

Το δοχείο (πλαίσιο) δεν λαμβάνει υπόψη το μέγεθος των πινέλων — υποθέτει πάντα ότι το πάχος της γραμμής είναι μηδέν (δείτε την προηγούμενη εικόνα).

Έτσι, για να προσδιοριστεί η ορατή περιοχή ολόκληρου του αντικειμένου μελάνης, πρέπει να ληφθεί υπόψη το μέγεθος του πινέλου των ιχνών του. Εδώ, το αντικείμενο-στόχος (το ίχνος του χειρόγραφου κειμένου) έχει κλιμακωθεί στο μέγεθος του δοχείου (πλαισίου). Όταν το μέγεθος του δοχείου αλλάξει, το μέγεθος του πινέλου παραμένει σταθερό, και αντίστροφα.

![ink_powerpoint5](ink_powerpoint5.png)

Το PowerPoint χρησιμοποιεί παρόμοια συμπεριφορά για αντικείμενα κειμένου:

![ink_powerpoint6](ink_powerpoint6.png)

## **Έλεγχος Εμφάνισης Μελάνης Κατά την Εξαγωγή και Απόδοση**

Το Aspose.Slides παρέχει τη διεπαφή [IInkOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/iinkoptions/) για να ελέγξει πώς εμφανίζονται τα αντικείμενα μελάνης σε εξαγόμενο ή αποδομένο αποτέλεσμα. Μπορείτε να χρησιμοποιήσετε τις μεθόδους της για να κρύψετε εντελώς τη μελάνη ή να αλλάξετε τον τρόπο ερμηνείας των λειτουργιών μάσκας πινέλου μελάνης.

Οι επιλογές μελάνης διατίθενται μέσω των επιλογών εξαγωγής ή απόδοσης για διάφορους τύπους εξόδου:

| Έξοδος | Μέθοδος επιλογών Μελάνης |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Εικόνα διαφάνειας | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Οι ίδιες δύο ρυθμίσεις είναι διαθέσιμες μέσω αυτών των μεθόδων:

- [IInkOptions::set_HideInk] καθορίζει αν τα αντικείμενα μελάνης περιλαμβάνονται στην έξοδο. Η προεπιλεγμένη τιμή είναι `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity] καθορίζει αν μια λειτουργία μάσκας ερμηνεύεται ως αδιαφάνεια κατά την απόδοση ενός πινέλου μελάνης. Η προεπιλεγμένη τιμή είναι `true`; θέστε την σε `false` για χρήση της λειτουργίας ROP.

### **Απόκρυψη Αντικειμένων Μελάνης στην Εξαγωγή PDF**

Από προεπιλογή, τα αντικείμενα μελάνης παραμένουν ορατά κατά την εξαγωγή. Καλέστε το [IInkOptions::set_HideInk] με `true` όταν χρειάζεστε ένα καθαρό αρχείο χωρίς χειρόγραφες σημειώσεις ή άλλο περιεχόμενο μελάνης.

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Απόκρυψη Αντικειμένων Μελάνης Κατά την Απόδοση μιας Διαφάνειας ως Εικόνα**

Για να κρύψετε τα αντικείμενα μελάνης όταν αποδίδονται οι διαφάνειες ως bitmap εικόνες, ρυθμίστε το [RenderingOptions::get_InkOptions] και περάστε τις επιλογές απόδοσης στη μέθοδο [ISlide::GetImage].

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Έλεγχος Απόδοσης Μάσκας Μελάνης**

Η μέθοδος [IInkOptions::set_InterpretMaskOpAsOpacity] ελέγχει πώς ερμηνεύονται οι λειτουργίες μάσκας κατά την απόδοση πινέλων μελάνης. Η προεπιλεγμένη τιμή είναι `true`, που χρησιμοποιεί αδιαφάνεια. Καλέστε τη μέθοδο με `false` για χρήση της λειτουργίας ROP.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

Η ίδια ρύθμιση μπορεί να εφαρμοστεί μέσω του [TiffOptions::get_InkOptions] κατά την εξαγωγή μιας παρουσίασης ή την απόδοση μιας διαφάνειας σε TIFF.

### **Επιλέξτε αν Θα Κρύψετε ή Θα Διατηρήσετε τη Μελάνη**

Χρησιμοποιήστε το [IInkOptions::set_HideInk] με `true` όταν το εξαγόμενο αρχείο πρέπει να είναι μια καθαρή έκδοση μιας σημειωμένης παρουσίασης, π.χ. ένα τελικό αντίγραφο για διανομή χωρίς σημάδια ελέγχου.

Διατηρήστε τη μελάνη ορατή (η προεπιλεγμένη ρύθμιση `false`) όταν οι σημειώσεις μελάνης αποτελούν μέρος του προοριζόμενου περιεχομένου, όπως σχόλια ελέγχου, χειρόγραφες σημειώσεις, επισημάνσεις ή σχέδια που πρέπει να παραμείνουν ορατά στο εξαγόμενο αποτέλεσμα. Αυτό επιτρέπει στις εφαρμογές να δημιουργούν ξεχωριστές εκδόσεις ελέγχου και τελικές εκδόσεις από την ίδια παρουσίαση χωρίς τροποποίηση των αρχικών αντικειμένων μελάνης.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να αλλάξω το χρώμα ή το μέγεθος μιας υπάρχουσας γραμμής μελάνης;**

Ναι. Αποκτήστε το ίχνος από το [IInk::get_Traces](https://reference.aspose.com/slides/el/cpp/aspose.slides.ink/iink/get_traces/), έπειτα αλλάξτε το [IInkTrace::get_Brush](https://reference.aspose.com/slides/el/cpp/aspose.slides.ink/iinktrace/get_brush/). Μπορείτε να καλέσετε το [IInkBrush::set_Color](https://reference.aspose.com/slides/el/cpp/aspose.slides.ink/iinkbrush/set_color/) και το [IInkBrush::set_Size](https://reference.aspose.com/slides/el/cpp/aspose.slides.ink/iinkbrush/set_size/) στο πινέλο.

**Αλλάζει η απόκρυψη της μελάνης την πηγαία παρουσίαση;**

Όχι. Το [IInkOptions::set_HideInk](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/iinkoptions/set_hideink/) επηρεάζει μόνο το αποδοθέν ή εξαγόμενο αποτέλεσμα· δεν αφαιρεί ή τροποποιεί τα αντικείμενα μελάνης στην πηγαία παρουσίαση.

**Ποιοι τύποι εξαγωγής υποστηρίζουν επιλογές μελάνης;**

Μπορείτε να ρυθμίσετε τις επιλογές μελάνης για PDF, HTML, SVG, TIFF και bitmap εικόνες διαφανειών μέσω των αντίστοιχων επιλογών εξαγωγής ή απόδοσης που φαίνονται παραπάνω.

**Περαιτέρω ανάγνωση**

* Για γενική ενημέρωση σχετικά με τα σχήματα, δείτε την ενότητα [PowerPoint Shapes](https://docs.aspose.com/slides/el/cpp/powerpoint-shapes/).
* Για περισσότερες πληροφορίες σχετικά με τις αποτελεσματικές τιμές, δείτε το [Shape Effective Properties](https://docs.aspose.com/slides/el/cpp/shape-effective-properties/#get-effective-font-height-value).
* Για λεπτομέρειες εξαγωγής PDF, δείτε το [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/el/cpp/convert-powerpoint-to-pdf/).
* Για λεπτομέρειες εξαγωγής HTML, δείτε το [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/el/cpp/convert-powerpoint-to-html/).
* Για λεπτομέρειες εξαγωγής SVG, δείτε το [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/el/cpp/render-a-slide-as-an-svg-image/).
* Για λεπτομέρειες εξαγωγής TIFF, δείτε το [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/el/cpp/convert-powerpoint-to-tiff/).
* Για λεπτομέρειες απόδοσης διαφάνειας σε εικόνα, δείτε το [Convert Presentation Slides to Images](https://docs.aspose.com/slides/el/cpp/convert-slide/).
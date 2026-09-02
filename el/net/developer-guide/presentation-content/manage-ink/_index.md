---
title: Διαχείριση Αντικειμένων Μελάνης Παρουσίασης σε .NET
linktitle: Διαχείριση Μελάνης
type: docs
weight: 95
url: /el/net/manage-ink/
keywords:
- μελάνη
- αντικείμενο μελάνης
- ίχνος μελάνης
- διαχείριση μελάνης
- σχεδίαση μελάνης
- σχεδίαση
- εξαγωγή μελάνης
- απόδοση μελάνης
- απόκρυψη μελάνης
- IInkOptions
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε τα αντικείμενα μελάνης του PowerPoint, επεξεργαστείτε τα ίχνη και τις ιδιότητες του πινέλου, και ελέγξτε την εμφάνιση της μελάνης κατά την εξαγωγή σε PDF, HTML, SVG, TIFF και εικόνες με το Aspose.Slides για .NET."
---
## **Εισαγωγή**

Το PowerPoint παρέχει μια λειτουργία μελάνης που σάς επιτρέπει να σχεδιάζετε ελεύθερες γραμμές. Η μελάνη μπορεί να χρησιμοποιηθεί για να τονίσει άλλα αντικείμενα, να δείξει συνδέσεις και διαδικασίες, και να εστιάσει την προσοχή σε συγκεκριμένα στοιχεία μιας διαφάνειας.

Ο χώρος ονομάτων [Aspose.Slides.Ink](https://reference.aspose.com/slides/el/net/aspose.slides.ink/) περιέχει τις κλάσεις και τις διεπαφές που απαιτούνται για εργασία με αντικείμενα μελάνης. Για παράδειγμα, η διεπαφή [IInk](https://reference.aspose.com/slides/el/net/aspose.slides.ink/iink/) αντιπροσωπεύει ένα αντικείμενο μελάνης σε μια διαφάνεια.

## **Διαφορές μεταξύ Κανονικών Αντικειμένων και Αντικειμένων Μελάνης**

Τα αντικείμενα σε μια διαφάνεια PowerPoint αντιπροσωπεύονται συνήθως από αντικείμενα σχήματος. Στην πιο απλή μορφή, ένα σχήμα είναι ένα περιέκτη που ορίζει την περιοχή του ίδιου του αντικειμένου (το πλαίσιο του) μαζί με ιδιότητες όπως το μέγεθος του περιέκτη, το σχήμα και το παρασκήνιο. Για περισσότερες πληροφορίες, δείτε το [Shape Layout Format](https://docs.aspose.com/slides/el/net/shape-manipulations/#access-layout-formats-for-shape).

Ωστόσο, όταν το PowerPoint διαχειρίζεται ένα αντικείμενο μελάνης, αγνοεί όλες τις ιδιότητες του πλαισίου του αντικειμένου (περιέκτη) εκτός από το μέγεθός του. Το μέγεθος της περιοχής του περιέκτη καθορίζεται από τις τυπικές ιδιότητες [IShape.Width](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/width/) και [IShape.Height](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ίχνοι Μελάνης**

Ένας ίχνος μελάνης είναι ένα βασικό στοιχείο που χρησιμοποιείται για την καταγραφή της τροχιάς ενός στυλό καθώς ο χρήστης γράφει ψηφιακή μελάνη. Ένας ίχνος αποθηκεύει μια ακολουθία συνδεδεμένων σημείων.

Η πιο απλή μορφή κωδικοποίησης ορίζει τις συντεταγμένες X και Y κάθε δείγματος σημείου. Όταν όλα τα συνδεδεμένα σημεία αποδοθούν, παράγουν μια εικόνα όπως αυτή:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ιδιότητες Πινέλου για Σχέδιο**

Ένα πινέλο χρησιμοποιείται για τη σχεδίαση γραμμών που συνδέουν τα σημεία ενός ίχνους μελάνης. Το πινέλο έχει το δικό του χρώμα και μέγεθος, που αντιπροσωπεύονται από τις ιδιότητες [IInkBrush.Color](https://reference.aspose.com/slides/el/net/aspose.slides.ink/iinkbrush/color/) και [IInkBrush.Size](https://reference.aspose.com/slides/el/net/aspose.slides.ink/iinkbrush/size/).

### **Ορισμός Χρώματος Πινέλου Μελάνης**

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε το χρώμα ενός πινέλου μελάνης:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Ορισμός Μεγέθους Πινέλου Μελάνης**

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε το μέγεθος ενός πινέλου μελάνης:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

Γενικά, το πλάτος και το ύψος ενός πινέλου δεν ταιριάζουν, έτσι το PowerPoint δεν εμφανίζει το μέγεθος του πινέλου (η αντίστοιχη ενότητα δεδομένων είναι αμαυρωμένη). Όταν το πλάτος και το ύψος του πινέλου ταιριάζουν, το PowerPoint εμφανίζει το μέγεθός του ως εξής:

![ink_powerpoint3](ink_powerpoint3.png)

Για σαφήνεια, ας αυξήσουμε το ύψος του αντικειμένου μελάνης και να εξετάσουμε τις σημαντικές διαστάσεις:

![ink_powerpoint4](ink_powerpoint4.png)

Ο περιέκτης (πλαίσιο) δεν λαμβάνει υπόψη το μέγεθος των πινέλων — υποθέτει πάντα ότι το πάχος της γραμμής είναι μηδέν (δείτε την προηγούμενη εικόνα).

Ως εκ τούτου, για να καθοριστεί η ορατή περιοχή ολόκληρου του αντικειμένου μελάνης, πρέπει να ληφθεί υπόψη το μέγεθος του πινέλου των ιχνών του. Εδώ, το στόχο αντικείμενο (ο ίχνος του χειρόγραφου κειμένου) έχει κλιμακωθεί στο μέγεθος του περιέκτη (πλαισίου). Όταν αλλάξει το μέγεθος του περιέκτη, το μέγεθος του πινέλου παραμένει σταθερό, και αντίστροφα.

![ink_powerpoint5](ink_powerpoint5.png)

Το PowerPoint χρησιμοποιεί παρόμοια συμπεριφορά για αντικείμενα κειμένου:

![ink_powerpoint6](ink_powerpoint6.png)

## **Έλεγχος Εμφάνισης Μελάνης Κατά την Εξαγωγή και Απόδοση**

Η Aspose.Slides παρέχει τη διεπαφή [IInkOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/iinkoptions/) για να ελέγξετε πώς εμφανίζονται τα αντικείμενα μελάνης σε εξαγόμενο ή αποδοθέν αποτέλεσμα. Μπορείτε να χρησιμοποιήσετε τις ιδιότητές της για να κρύψετε πλήρως τη μελάνη ή να αλλάξετε τον τρόπο ερμηνείας των λειτουργιών μάσκας πινέλου μελάνης.

Οι επιλογές μελάνης είναι διαθέσιμες μέσω των επιλογών εξαγωγής ή απόδοσης για διάφορους τύπους εξόδου:

| Έξοδος | Ιδιότητα επιλογών μελάνης |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/el/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Εικόνα διαφάνειας | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/el/net/aspose.slides.export/renderingoptions/inkoptions/) |

Οι ίδιες δύο ρυθμίσεις είναι διαθέσιμες μέσω αυτών των ιδιοτήτων:

- [`HideInk`](https://reference.aspose.com/slides/el/net/aspose.slides.export/iinkoptions/hideink/) καθορίζει αν τα αντικείμενα μελάνης περιλαμβάνονται στην έξοδο. Η προεπιλεγμένη τιμή είναι `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/el/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) καθορίζει αν μια λειτουργία μάσκας ερμηνεύεται ως αδιαφάνεια κατά την απόδοση ενός πινέλου μελάνης. Η προεπιλεγμένη τιμή είναι `true`; ορίστε την σε `false` για χρήση της λειτουργίας ROP αντί αυτού.

### **Απόκρυψη Αντικειμένων Μελάνης στην Έξοδο PDF**

Από προεπιλογή, τα αντικείμενα μελάνης παραμένουν ορατά κατά την εξαγωγή. Ορίστε το [IInkOptions.HideInk](https://reference.aspose.com/slides/el/net/aspose.slides.export/iinkoptions/hideink/) σε `true` όταν χρειάζεστε καθαρή έξοδο χωρίς χειρόγραφες σημειώσεις ή άλλο περιεχόμενο μελάνης.

Το ακόλουθο παράδειγμα C# εξάγει μια παρουσίαση σε PDF κρύβοντας όλα τα αντικείμενα μελάνης:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Απόκρυψη Αντικειμένων Μελάνης Κατά την Απόδοση μιας Διαφάνειας ως Εικόνας**

Για να κρύψετε τα αντικείμενα μελάνης κατά την απόδοση διαφανειών ως bitmap εικόνες, διαμορφώστε το [RenderingOptions.InkOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/renderingoptions/inkoptions/) και περάστε τις επιλογές απόδοσης στη μέθοδο [ISlide.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/islide/getimage/).

Το παρακάτω παράδειγμα C# αποδίδει την πρώτη διαφάνεια ως PNG εικόνα χωρίς αντικείμενα μελάνης:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Έλεγχος Απόδοσης Μάσκας Μελάνης**

Η ιδιότητα [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/el/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) ελέγχει πώς ερμηνεύονται οι λειτουργίες μάσκας κατά την απόδοση πινέλων μελάνης. Η προεπιλεγμένη τιμή είναι `true`, η οποία χρησιμοποιεί αδιαφάνεια. Ορίστε την ιδιότητα σε `false` για χρήση της λειτουργίας ROP αντί αυτού.

Το παρακάτω παράδειγμα C# εξάγει μια διαφάνεια σε SVG και χρησιμοποιεί απόδοση βασισμένη σε ROP για λειτουργίες μάσκας μελάνης:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

Η ίδια ρύθμιση μπορεί να εφαρμοστεί μέσω του [TiffOptions.InkOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/tiffoptions/inkoptions/) όταν εξάγετε μια παρουσίαση ή αποδίδετε μια διαφάνεια σε TIFF.

### **Επιλογή Ανάμεσα σε Απόκρυψη ή Διατήρηση Μελάνης**

Χρησιμοποιήστε το [IInkOptions.HideInk](https://reference.aspose.com/slides/el/net/aspose.slides.export/iinkoptions/hideink/) ορισμένο σε `true` όταν το εξαγόμενο αρχείο πρέπει να είναι μια καθαρή έκδοση μιας σχολιασμένης παρουσίασης, π.χ. ένα τελικό αντίγραφο προορισμένο για διανομή χωρίς σημειώσεις αξιολόγησης.

Αφήστε το [IInkOptions.HideInk](https://reference.aspose.com/slides/el/net/aspose.slides.export/iinkoptions/hideink/) στην προεπιλεγμένη τιμή του `false` όταν οι σημειώσεις μελάνης αποτελούν μέρος του επιθυμητού περιεχομένου, όπως σχόλια αξιολόγησης, χειρόγραφες σημειώσεις, υπογραμμίσεις ή σκίτσα που πρέπει να παραμείνουν ορατά στο εξαγόμενο αποτέλεσμα. Αυτό επιτρέπει στις εφαρμογές να δημιουργούν ξεχωριστές εκδόσεις ανασκόπησης και τελικές εκδοχές από την ίδια παρουσίαση χωρίς να τροποποιούν τα αρχικά αντικείμενα μελάνης.

## **Συχνές Ερωτήσεις**

**Μπορώ να αλλάξω το χρώμα ή το μέγεθος μιας υπάρχουσας γραμμής μελάνης;**

Ναι. Λάβετε το ίχνος από το [IInk.Traces](https://reference.aspose.com/slides/el/net/aspose.slides.ink/iink/traces/), έπειτα αλλάξτε το [IInkTrace.Brush](https://reference.aspose.com/slides/el/net/aspose.slides.ink/iinktrace/brush/). Μπορείτε να ορίσετε το [IInkBrush.Color](https://reference.aspose.com/slides/el/net/aspose.slides.ink/iinkbrush/color/) και το [IInkBrush.Size](https://reference.aspose.com/slides/el/net/aspose.slides.ink/iinkbrush/size/).

**Αλλάζει η απόκρυψη της μελάνης την πηγαία παρουσίαση;**

Όχι. Το [IInkOptions.HideInk](https://reference.aspose.com/slides/el/net/aspose.slides.export/iinkoptions/hideink/) επηρεάζει μόνο το αποδοθέν ή εξαγόμενο αποτέλεσμα· δεν αφαιρεί ούτε τροποποιεί τα αντικείμενα μελάνης στην πηγαία παρουσίαση.

**Ποιοι τύποι εξαγωγής υποστηρίζουν επιλογές μελάνης;**

Μπορείτε να διαμορφώσετε επιλογές μελάνης για PDF, HTML, SVG, TIFF και εικόνες bitmap διαφανειών μέσω των αντίστοιχων επιλογών εξαγωγής ή απόδοσης που εμφανίζονται παραπάνω.

**Περαιτέρω ανάγνωση**

* Για γενικές πληροφορίες σχετικά με τα σχήματα, δείτε την ενότητα [PowerPoint Shapes](https://docs.aspose.com/slides/el/net/powerpoint-shapes/).
* Για περισσότερα σχετικά με τις αποτελεσματικές τιμές, δείτε το [Shape Effective Properties](https://docs.aspose.com/slides/el/net/shape-effective-properties/#get-effective-font-height-value).
* Για λεπτομέρειες εξαγωγής PDF, δείτε το [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/el/net/convert-powerpoint-to-pdf/).
* Για λεπτομέρειες εξαγωγής HTML, δείτε το [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/el/net/convert-powerpoint-to-html/).
* Για λεπτομέρειες εξαγωγής SVG, δείτε το [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/el/net/render-a-slide-as-an-svg-image/).
* Για λεπτομέρειες εξαγωγής TIFF, δείτε το [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/el/net/convert-powerpoint-to-tiff/).
* Για λεπτομέρειες απόδοσης διαφάνειας σε εικόνα, δείτε το [Convert Presentation Slides to Images](https://docs.aspose.com/slides/el/net/convert-slide/).
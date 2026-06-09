---
title: Προσθήκη Σχημάτων Γραμμής σε Παρουσιάσεις στο .NET
linktitle: Γραμμή
type: docs
weight: 50
url: /el/net/Line/
keywords:
- γραμμή
- δημιουργία γραμμής
- προσθήκη γραμμής
- απλή γραμμή
- ρύθμιση γραμμής
- προσαρμογή γραμμής
- στυλ διακεκομμένων
- άκρο βέλους
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε τη μορφοποίηση γραμμής σε παρουσιάσεις PowerPoint με το Aspose.Slides για .NET. Ανακαλύψτε ιδιότητες, μεθόδους και παραδείγματα."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να προσθέτετε σχήματα γραμμής σε διαφάνειες PowerPoint προγραμματιστικά. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια απλή γραμμή και πώς να προσαρμόσετε μια γραμμή ώστε να εμφανίζεται ως βέλος.

Θα μάθετε πώς να προσθέσετε ένα σχήμα γραμμής σε μια διαφάνεια, να προσαρμόσετε την οπτική της εμφάνιση και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Τα παραδείγματα επικεντρώνονται σε πρακτικές ρυθμίσεις μορφοποίησης γραμμής όπως το στυλ, το πλάτος, το πρότυπο διακεκομμένων, οι επιλογές άκρων βέλους και το χρώμα γεμίσματος.

## **Δημιουργία Απλής Γραμμής**
Για να προσθέσετε μια απλή γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation ](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)class.
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο [AddAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/methods/addautoshape/index) που εκτίθεται από το αντικείμενο Shapes.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Στο παρακάτω παράδειγμα, προσθέσαμε μια γραμμή στην πρώτη διαφάνεια της παρουσίασης.

```c#
 // Δημιουργία αντικειμένου PresentationEx που αντιπροσωπεύει το αρχείο PPTX
 using (Presentation pres = new Presentation())
 {
     // Λήψη της πρώτης διαφάνειας
     ISlide sld = pres.Slides[0];
 
     // Προσθήκη autoshape τύπου γραμμής
     sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
 
     // Αποθήκευση του PPTX στο δίσκο
     pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
 }
```

## **Δημιουργία Γραμμής σε Σχήμα Βέλους**
Το Aspose.Slides for .NET επιτρέπει επίσης στους προγραμματιστές να ρυθμίσουν ορισμένες ιδιότητες της γραμμής ώστε να φαίνεται πιο ελκυστική. Ας προσπαθήσουμε να ρυθμίσουμε μερικές ιδιότητες της γραμμής ώστε να μοιάζει με βέλος. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation ](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/el/aspose.slides/)[](http://www.aspose.com/api/net/slides/el/aspose.slides/).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο AddAutoShape που εκτίθεται από το αντικείμενο Shapes.
- Ορίστε το Line Style σε ένα από τα στυλ που προσφέρει το Aspose.Slides for .NET.
- Ορίστε το Width της γραμμής.
- Ορίστε το [Dash Style](https://reference.aspose.com/slides/el/net/aspose.slides/linedashstyle) της γραμμής σε ένα από τα στυλ που προσφέρει το Aspose.Slides for .NET.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/net/aspose.slides/linearrowheadstyle) και το Length του σημείου έναρξης της γραμμής.
- Ορίστε το Arrow Head Style και το Length του σημείου λήξης της γραμμής.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```c#
 // Δημιουργία αντικειμένου PresentationEx που αντιπροσωπεύει το αρχείο PPTX
using (Presentation pres = new Presentation())
{
 
    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.Slides[0];
 
    // Προσθήκη autoshape τύπου γραμμής
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
 
    // Εφαρμογή κάποιων μορφοποιήσεων στη γραμμή
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;
 
    shp.LineFormat.DashStyle = LineDashStyle.DashDot;
 
    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;
 
    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
 
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;
 
    //Αποθήκευση του PPTX στο δίσκο
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να μετατρέψω μια κανονική γραμμή σε σύνδεσμο ώστε να «προσκολλάται» σε σχήματα;**

Όχι. Μια κανονική γραμμή (ένα [AutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) τύπου [Line](https://reference.aspose.com/slides/el/net/aspose.slides/shapetype/)) δεν μετατρέπεται αυτόματα σε σύνδεσμο. Για να την προσκαλιάσετε σε σχήματα, χρησιμοποιήστε τον ειδικό τύπο [Connector](https://reference.aspose.com/slides/el/net/aspose.slides/connector/) και τα [αντίστοιχα API](/slides/el/net/connector/) για συνδέσεις.

**Τι πρέπει να κάνω αν οι ιδιότητες μιας γραμμής κληρονομούνται από το θέμα και είναι δύσκολο να προσδιοριστούν οι τελικές τιμές;**

[Διαβάστε τις αποτελεσματικές ιδιότητες](/slides/el/net/shape-effective-properties/) μέσω των διεπαφών [ILineFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ilinefillformateffectivedata/) — αυτές λαμβάνουν ήδη υπόψη την κληρονομικότητα και τα στυλ του θέματος.

**Μπορώ να κλειδώσω μια γραμμή ενάντια σε επεξεργασία (μετακίνηση, αλλαγή μεγέθους);**

Ναι. Τα σχήματα παρέχουν [αντικείμενα κλειδώματος](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/autoshapelock/) που σας επιτρέπουν να [απαγορεύσετε τις λειτουργίες επεξεργασίας](/slides/el/net/applying-protection-to-presentation/).
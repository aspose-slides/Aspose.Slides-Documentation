---
title: Προσθήκη Σχημάτων Γραμμών σε Παρουσιάσεις στο .NET
linktitle: Γραμμή
type: docs
weight: 50
url: /el/net/line/
keywords:
- γραμμή
- δημιουργία γραμμής
- προσθήκη γραμμής
- απλή γραμμή
- διαμόρφωση γραμμής
- προσαρμογή γραμμής
- στυλ παύλας
- κεφαλή βέλους
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να χειρίζεστε τη μορφοποίηση γραμμών σε παρουσιάσεις PowerPoint με το Aspose.Slides για .NET. Ανακαλύψτε ιδιότητες, μεθόδους και παραδείγματα."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να προσθέτετε σχήματα γραμμών σε διαφάνειες PowerPoint προγραμματιστικά. Αυτό το άρθρο δείχνει πώς να δημιουργήσετε μια απλή γραμμή και πώς να προσαρμόσετε μια γραμμή ώστε να εμφανίζεται ως βέλος.

Θα μάθετε πώς να προσθέσετε ένα σχήμα γραμμής σε μια διαφάνεια, να προσαρμόσετε την οπτική του εμφάνιση και να αποθηκεύσετε την ενημερωμένη παρουσίαση. Τα παραδείγματα εστιάζουν σε πρακτικές ρυθμίσεις μορφοποίησης γραμμής όπως το στυλ, το πλάτος, το μοτίβο παύλων, οι ρυθμίσεις κεφαλής βέλους και το χρώμα γεμίσματος.

## **Δημιουργία Απλής Γραμμής**
Για να προσθέσετε μια απλή γραμμή σε μια επιλεγμένη διαφάνεια της παρουσίασης, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσίαση της κλάσης [Presentation ](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)class.
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

    // Προσθήκη autoshape τύπου line
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Γράψιμο του PPTX στο δίσκο
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Δημιουργία Γραμμής Σχήματος Βέλους**
Το Aspose.Slides για .NET επιτρέπει επίσης στους προγραμματιστές να διαμορφώσουν ορισμένες ιδιότητες της γραμμής ώστε να φαίνεται πιο ελκυστική. Ας προσπαθήσουμε να διαμορφώσουμε μερικές ιδιότητες μιας γραμμής ώστε να μοιάζει με βέλος. Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσίαση της κλάσης [Presentation ](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/el/aspose.slides/)[](http://www.aspose.com/api/net/slides/el/aspose.slides/).
- Αποκτήστε την αναφορά μιας διαφάνειας χρησιμοποιώντας το Index της.
- Προσθέστε ένα AutoShape τύπου Line χρησιμοποιώντας τη μέθοδο AddAutoShape που εκτίθεται από το αντικείμενο Shapes.
- Ορίστε το Line Style σε ένα από τα στυλ που προσφέρει το Aspose.Slides για .NET.
- Ορίστε το πλάτος (Width) της γραμμής.
- Ορίστε το [Dash Style](https://reference.aspose.com/slides/el/net/aspose.slides/linedashstyle) της γραμμής σε ένα από τα στυλ που προσφέρει το Aspose.Slides για .NET.
- Ορίστε το [Arrow Head Style](https://reference.aspose.com/slides/el/net/aspose.slides/linearrowheadstyle) και το Length του αρχικού σημείου της γραμμής.
- Ορίστε το Arrow Head Style και το Length του τελικού σημείου της γραμμής.
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```c#
// Δημιουργία PresentationEx class που αντιπροσωπεύει το αρχείο PPTX
using (Presentation pres = new Presentation())
{

    // Λήψη της πρώτης διαφάνειας
    ISlide sld = pres.Slides[0];

    // Προσθήκη autoshape τύπου line
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

    //Γράψιμο του PPTX στο δίσκο
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω μια κανονική γραμμή σε σύνδεσμο ώστε να «συνελλάσσεται» με σχήματα;**

Όχι. Μια κανονική γραμμή (ένα [AutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) τύπου [Line](https://reference.aspose.com/slides/el/net/aspose.slides/shapetype/)) δεν μετατρέπεται αυτόματα σε σύνδεσμο. Για να συναντάται με σχήματα, χρησιμοποιήστε τον ειδικό τύπο [Connector](https://reference.aspose.com/slides/el/net/aspose.slides/connector/) και τις [αντίστοιχες API](/slides/el/net/connector/) για συνδέσεις.

**Τι πρέπει να κάνω αν οι ιδιότητες μιας γραμμής κληρονομούνται από το θέμα και είναι δύσκολο να προσδιορισούν οι τελικές τιμές;**

[Διαβάστε τις αποτελεσματικές ιδιότητες](/slides/el/net/shape-effective-properties/) μέσω των διεπαφών [ILineFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/el/net/aspose.slides/ilinefillformateffectivedata/) — αυτές λαμβάνουν ήδη υπόψη την κληρονομικότητα και τα στυλ του θέματος.

**Μπορώ να κλειδώσω μία γραμμή ώστε να μην επεξεργαστεί (μετακίνηση, αλλαγή μεγέθους);**

Ναι. Τα σχήματα παρέχουν [lock objects](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/autoshapelock/) που σας επιτρέπουν να [απαγορεύσετε τις λειτουργίες επεξεργασίας](/slides/el/net/applying-protection-to-presentation/).
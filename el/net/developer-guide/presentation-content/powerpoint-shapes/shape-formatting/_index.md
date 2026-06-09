---
title: Διαμόρφωση Σχημάτων PowerPoint σε .NET
linktitle: Διαμόρφωση Σχήματος
type: docs
weight: 20
url: /el/net/shape-formatting/
keywords:
- διαμόρφωση σχήματος
- διαμόρφωση γραμμής
- διαμόρφωση στυλ σύνδεσης
- γεμισμα διαβάθμισης
- γεμισμα μοτίβου
- γεμισμα εικόνας
- γεμισμα υφής
- γεμισμα στερεού χρώματος
- διαφάνεια σχήματος
- περιστροφή σχήματος
- εφέ 3Δ λείανσης
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να διαμορφώνετε σχήματα PowerPoint σε C# χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT και PPTX με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Επειδή τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στις περιγράμματα τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν τα εσωτερικά τους.

![Μορφοποίηση σχήματος PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides for .NET παρέχει διεπαφές και ιδιότητες που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [στυλ γραμμής](https://reference.aspose.com/slides/el/net/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [στυλ παύλας](https://reference.aspose.com/slides/el/net/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα της γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς μορφοποιείται ένα ορθογώνιο `AutoShape`:

```c#
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για το ορθογώνιο σχήμα.
    shape.FillFormat.FillType = FillType.NoFill;

    // Εφαρμόστε μορφοποίηση στις γραμμές του ορθογωνίου.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Ορίστε το χρώμα για τη γραμμή του ορθογωνίου.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Μορφοποίηση Στυλ Σύνδεσης**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Στρογγυλό
* Κόνα
* Λοξότμηση

Από προεπιλογή, όταν το PowerPoint ενώνει δύο γραμμές σε γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη **Στρογγυλή** ρύθμιση. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με κοφτερές γωνίες, ίσως προτιμάτε την επιλογή **Κόνα**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας C# δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνεται στην παραπάνω εικόνα) χρησιμοποιώντας τις ρυθμίσεις τύπου σύνδεσης Κόνα, Λοξότμηση και Στρογγυλό:

```c#
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε τρία αυτόματα σχήματα τύπου Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για κάθε ορθογώνιο σχήμα.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Ορίστε το πάχος της γραμμής.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Ορίστε το χρώμα για τη γραμμή του κάθε ορθογωνίου.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Ορίστε το στυλ σύνδεσης.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Προσθέστε κείμενο σε κάθε ορθογώνιο.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Διαβάθμιση**

Στο PowerPoint, η Διαβάθμιση είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε μια συνεχόμενη ανάμιξη χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο που το ένα ξεθωριάζει σταδιακά στο άλλο.

Ακολουθεί η διαδικασία για να εφαρμόσετε διαβάθμιση σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `Add` της συλλογής gradient stop που εκτίθενται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/el/net/aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς εφαρμόζεται το εφέ διαβάθμισης σε μια έλλειψη:

```c#
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Εφαρμόστε μορφοποίηση διαβάθμισης στην έλλειψη.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Ορίστε την κατεύθυνση της διαβάθμισης.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Προσθέστε δύο σημεία διαβάθμισης.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η έλλειψη με διαβάθμιση γεμίσματος](gradient-fill.png)

## **Γέμισμα Μοτίβου**

Στο PowerPoint, το Γέμισμα Μοτίβου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχεδιαστικό μοτίβο δύο χρωμάτων—όπως κουκκίδες, λωρίδες, διαγώνιες γραμμές ή σκαναρίσματα—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το φόντο του μοτίβου.

Το Aspose.Slides παρέχει πάνω από 45 προ-ορισμένα στυλ μοτίβου που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμα και μετά την επιλογή ενός προ-ορισμένου μοτίβου, μπορείτε να καθορίσετε τα ακριβή χρώματα που θα χρησιμοποιηθούν.

Ακολουθεί η διαδικασία για να εφαρμόσετε γεμισμό μοτίβου σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προ-ορισμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/net/aspose.slides/ipatternformat/backcolor/) του μοτίβου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/net/aspose.slides/ipatternformat/forecolor/) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς εφαρμόζεται γεμισμός μοτίβου σε ένα ορθογώνιο:

```c#
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Ορίστε το στυλ μοτίβου.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Ορίστε τα χρώματα φόντου και προσκηνίου του μοτίβου.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με γεμισμό μοτίβου](pattern-fill.png)

## **Γεμισμα Εικόνας**

Στο PowerPoint, το Γεμισμα Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθεί η διαδικασία για να χρησιμοποιήσετε το Aspose.Slides ώστε να εφαρμόσετε γεμισμα εικόνας σε ένα σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γεμίσματος εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Αναθέστε αυτήν την εικόνα στην ιδιότητα `Picture.Image` του `PictureFillFormat` του σχήματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας πούμε ότι έχουμε ένα αρχείο «lotus.png» με την εξής εικόνα:

![Η εικόνα lotus](lotus.png)

Ο παρακάτω κώδικας C# δείχνει πώς γεμίζεται ένα σχήμα με την εικόνα:

```c#
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Ορίστε τον τύπο γεμίσματος σε Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Ορίστε τη λειτουργία γεμίσματος εικόνας.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Φορτώστε μια εικόνα και προσθέστε τη στους πόρους της παρουσίασης.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Ορίστε την εικόνα.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το σχήμα με γεμισμα εικόνας](picture-fill.png)

### **Πλακίδιο Εικόνας Ως Υφή**

Αν θέλετε να ορίσετε μια πλακιδική εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά του πλακιδίου, μπορείτε να χρησιμοποιήσετε τις παρακάτω ιδιότητες της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/picturefillmode/): Ορίζει τη λειτουργία γεμίσματος εικόνας—είτε `Tile` είτε `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tilealignment/): Καθορίζει την εναρμόνιση των πλακιδίων μέσα στο σχήμα.
- [TileFlip](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tileflip/): Ελέγχει αν το πλακίδιο θα αναστραφεί οριζόντια, κατακόρυφα ή και τα δύο.
- [TileOffsetX](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tileoffsetx/): Ορίζει την οριζόντια απόκλιση του πλακιδίου (σε points) από το αρχικό σημείο του σχήματος.
- [TileOffsetY](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tileoffsety/): Ορίζει την κάθετη απόκλιση του πλακιδίου (σε points) από το αρχικό σημείο του σχήματος.
- [TileScaleX](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tilescalex/): Καθορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [TileScaleY](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tilescaley/): Καθορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς προστίθεται ένα ορθογώνιο σχήμα με πλακιδικό γεμισμα εικόνας και ρυθμίζονται οι επιλογές του πλακιδίου:

```c#
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide firstSlide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Φορτώστε την εικόνα και προσθέστε τη στους πόρους της παρουσίασης.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Αντιστοιχίστε την εικόνα στο σχήμα.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Διαμορφώστε τη λειτουργία γεμίσματος εικόνας και τις ιδιότητες πλακιδίων.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίου](tile-options.png)

## **Γεμισμα Στερεού Χρώματος**

Στο PowerPoint, το Γεμισμα Στερεού Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε γεμισμα στερεού χρώματος σε ένα σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς εφαρμόζεται γεμισμα στερεού χρώματος σε ένα ορθογώνιο σε μια διαφάνεια PowerPoint:

```c#
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Ορίστε το χρώμα γεμίσματος.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το σχήμα με στερεό χρώμα γεμίσματος](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε στερεό χρώμα, διαβάθμιση, εικόνα ή υφή σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε τη διαφάνεια του γεμίσματος. Ένα υψηλότερο επίπεδο διαφάνειας κάνει το σχήμα πιο διαφανές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να είναι μερικώς ορατά.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας τη τιμή άλφα στο χρώμα που χρησιμοποιείται για το γέμισμα. Δείτε πώς:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε `Color.FromArgb(alpha, baseColor)` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς εφαρμόζεται χρώμα γεμίσματος με διαφάνεια σε ένα ορθογώνιο:

```c#
const int alpha = 128;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα γεμάτο ορθογωνικό αυτόματο σχήμα.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθέστε ένα διάφανο ορθογωνικό αυτόματο σχήμα πάνω από το γεμάτο σχήμα.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σας επιτρέπει να περιστρέψετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να φανεί χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένες ευθυγραμμίσεις ή σχεδιαστικές απαιτήσεις.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα `Rotation` του σχήματος στη ζητούμενη γωνία.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς περιστρέφεται ένα σχήμα κατά 5 μοίρες:

```c#
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Περιστρέψτε το σχήμα κατά 5 μοίρες.
    shape.Rotation = 5;

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3Δ Εφέ Λείανσης**

Το Aspose.Slides σάς επιτρέπει να εφαρμόζετε 3Δ εφέ λείανσης σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/).

Για να προσθέσετε 3Δ εφέ λείανσης σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Διαμορφώστε το [ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/) του σχήματος ώστε να ορίσετε τις ρυθμίσεις λείανσης.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς εφαρμόζονται 3Δ εφέ λείανσης σε ένα σχήμα:

```c#
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα σχήμα στη διαφάνεια.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Ορίστε τις ιδιότητες ThreeDFormat του σχήματος.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το 3Δ εφέ λείανσης](3D-bevel-effect.png)

## **Προσθήκη 3Δ Εφέ Περιστροφής**

Το Aspose.Slides σάς επιτρέπει να εφαρμόζετε 3Δ εφέ περιστροφής σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε ένα σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [CameraType](https://reference.aspose.com/slides/el/net/aspose.slides/icamera/cameratype/) και το [LightType](https://reference.aspose.com/slides/el/net/aspose.slides/ilightrig/lighttype/) του σχήματος ώστε να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς εφαρμόζονται 3Δ εφέ περιστροφής σε ένα σχήμα:

```c#
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το 3Δ εφέ περιστροφής](3D-rotation-effect.png)

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας C# δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στην [LayoutSlide](https://reference.aspose.com/slides/el/net/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Επαναφορά κάθε σχήματος στη διαφάνεια που έχει placeholder στη διάταξη.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση των σχημάτων το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι των σχημάτων όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν σχεδόν κανένα επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ταυτόσημη μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος—ρυθμίσεις γεμίσματος, γραμμής και εφέ. Αν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε το στυλ τους ως ταυτόσημο και ομαδοποιήστε λογικά αυτά τα σχήματα, γεγονός που απλοποιεί τη διαχείριση του στυλ αργότερα.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε μια προεπιλεγμένη παρουσίαση ή σε αρχείο προτύπου .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλ σχήματος που χρειάζεστε και επαναλάβετε τη μορφοποίησή τους όπου απαιτείται.
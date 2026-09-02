---
title: Μορφοποίηση Σχημάτων PowerPoint σε .NET
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/net/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκέτσου
- γραμμή σχήματος σκέτσου
- μορφοποίηση στυλ σύνδεσης
- γέμισμα κλίσης
- γέμισμα μοτίβου
- γέμισμα εικόνας
- γέμισμα υφής
- γέμισμα στερεού χρώματος
- διαφάνεια σχήματος
- περιστροφή σχήματος
- εφέ 3Δ κλίεσης
- εφέ 3Δ περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε C# χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT και PPTX με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέτετε σχήματα σε διαφάνειες. Καθώς τα σχήματα αποτελούνται από γραμμές, μπορείτε να μορφοποιήσετε τις γραμμές τους τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζει το εσωτερικό τους.

![Μορφοποίηση σχήματος PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET παρέχει διεπαφές και ιδιότητες που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που είναι διαθέσιμες στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Ορίστε το [στυλ γραμμής](https://reference.aspose.com/slides/el/net/aspose.slides/linestyle/) του σχήματος.
5. Ορίστε το πάχος της γραμμής.
6. Ορίστε το [στυλ παύλας](https://reference.aspose.com/slides/el/net/aspose.slides/linedashstyle/) της γραμμής.
7. Ορίστε το χρώμα της γραμμής για το σχήμα.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```c#
// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για το σχήμα rectangle.
    shape.FillFormat.FillType = FillType.NoFill;

    // Εφαρμόστε μορφοποίηση στις γραμμές του rectangle.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Ορίστε το χρώμα για τη γραμμή του rectangle.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Εφαρμογή Εφέ Σκέτσου στις Γραμμές Σχήματος**

Ένα εφέ σκέτσου κάνει τη γραμμή ενός σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε το [IShape.LineFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/lineformat/) για πρόσβαση στις ρυθμίσεις γραμμής, το [ILineFormat.SketchFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ilineformat/sketchformat/) για τις ρυθμίσεις σκέτσου και το [ISketchFormat.SketchType](https://reference.aspose.com/slides/el/net/aspose.slides/isketchformat/sketchtype/) για επιλογή τιμής από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/el/net/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/el/net/aspose.slides/linesketchtype/), να διαβάσετε την ρητά ορισμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.None](https://reference.aspose.com/slides/el/net/aspose.slides/linesketchtype/):

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

Η τιμή που επιστρέφει το `ISketchFormat.SketchType` αντιπροσωπεύει τη ρύθμιση που έχει ανατεθεί άμεσα στο σχήμα. Εάν η μορφοποίηση γραμμής μπορεί να κληθεί από θέμα, κύρια διαφάνεια ή διάταξη, χρησιμοποιήστε το [ILineFormat.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/ilineformat/geteffective/), προσπελάστε το [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ilineformateffectivedata/sketchformat/) και διαβάστε το [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/el/net/aspose.slides/isketchformateffectivedata/sketchtype/). Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομιάς:

```csharp
using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Μορφοποίηση Στυλ Συνένωσης (Join Styles)**

Οι τρεις επιλογές τύπου συνένωσης είναι:

* Round
* Miter
* Bevel

Από προεπιλογή, όταν το PowerPoint ενώνει δύο γραμμές σε γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Round**. Ωστόσο, εάν σχεδιάζετε σχήμα με οξείες γωνίες, μπορεί να προτιμάτε την επιλογή **Miter**.

![Το στυλ συνένωσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας C# δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνεται στην παραπάνω εικόνα) χρησιμοποιώντας τις ρυθμίσεις τύπου συνένωσης Miter, Bevel και Round:

```c#
// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη τριών αυτόματων σχημάτων τύπου Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ορισμός χρώματος γεμίσματος για κάθε σχήμα rectangle.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Ορισμός πλάτους γραμμής.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Ορισμός χρώματος για τη γραμμή κάθε rectangle.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Ορισμός στυλ σύνδεσης.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Προσθήκη κειμένου σε κάθε rectangle.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Γραμμικό Γέμισμα (Gradient Fill)**

Στο PowerPoint, το Gradient Fill είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόζετε μια συνεχής διαβάθμιση χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα έτσι ώστε το ένα να εξασθενίζει σταδιακά στο άλλο.

Ακολουθεί η διαδικασία για την εφαρμογή γραμμικού γέμισματος σε σχήμα με χρήση του Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του σχήματος σε `Gradient`.
5. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `Add` της συλλογής gradient stop που εκτίθεται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/el/net/aspose.slides/igradientformat/).
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε εφέ γραμμικού γέμισματος σε μια έλλειψη:

```c#
// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη αυτόματου σχήματος τύπου Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Εφαρμογή μορφοποίησης gradient στην έλλειψη.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Ορισμός κατεύθυνσης του gradient.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Προσθήκη δύο gradient stops.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η έλλειψη με γραμμικό γέμισμα](gradient-fill.png)

## **Γέμισμα Μοτίβου (Pattern Fill)**

Στο PowerPoint, το Pattern Fill είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχέδιο δύο χρωμάτων—όπως κουκίδες, λωρίδες, διαγώνιες γραμμές ή σκαλοπάτια—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το εμπρόσθιο και το παρασκήνιο του μοτίβου.

Το Aspose.Slides παρέχει πάνω από 45 προ‑ορισμένα στυλ μοτίβου που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική απήχηση των παρουσιάσεών σας. Ακόμη και αφού επιλέξετε ένα προ‑ορισμένο μοτίβο, μπορείτε να καθορίσετε τα ακριβή χρώματα που θα χρησιμοποιηθούν.

Ακολουθεί η διαδικασία για την εφαρμογή pattern fill σε σχήμα με χρήση του Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του σχήματος σε `Pattern`.
5. Επιλέξτε ένα στυλ μοτίβου από τις προ‑ορισμένες επιλογές.
6. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/net/aspose.slides/ipatternformat/backcolor/) του μοτίβου.
7. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/net/aspose.slides/ipatternformat/forecolor/) του μοτίβου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε pattern fill σε ένα ορθογώνιο:

```c#
// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορισμός τύπου γεμίσματος σε Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Ορισμός στυλ μοτίβου.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Ορισμός χρωμάτων παρασκηνίου και προσκηνίου του μοτίβου.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με pattern fill](pattern-fill.png)

## **Γέμισμα Εικόνας (Picture Fill)**

Στο PowerPoint, το Picture Fill είναι μια επιλογή μορφοποίησης που σας επιτρέπει να ενσωματώσετε μια εικόνα μέσα σε σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως παρασκήνιο του σχήματος.

Ακολουθεί η διαδικασία για χρήση του Aspose.Slides ώστε να εφαρμόσετε picture fill σε σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του σχήματος σε `Picture`.
5. Ορίστε τη λειτουργία picture fill σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
6. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
7. Εκχωρήστε αυτήν την εικόνα στην ιδιότητα `Picture.Image` του `PictureFillFormat` του σχήματος.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας υποθέσουμε ότι διαθέτουμε αρχείο «lotus.png» με την ακόλουθη εικόνα:

![Η εικόνα lotus](lotus.png)

Ο παρακάτω κώδικας C# δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```c#
// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Ορισμός τύπου γεμίσματος σε Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Ορισμός λειτουργίας picture fill.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Φόρτωση εικόνας και προσθήκη της στους πόρους της παρουσίασης.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Ορισμός της εικόνας.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το σχήμα με picture fill](picture-fill.png)

### **Tile Picture As Texture**

Εάν θέλετε να ορίσετε μια επαναλαμβανόμενη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά επανάληψης, μπορείτε να χρησιμοποιήσετε τις ακόλουθες ιδιότητες της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/picturefillmode/): Ορίζει τη λειτουργία picture fill—είτε `Tile` είτε `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tilealignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [TileFlip](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tileflip/): Ελέγχει εάν το πλακίδιο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [TileOffsetX](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tileoffsetx/): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε points) από το σημείο προέλευσης του σχήματος.
- [TileOffsetY](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tileoffsety/): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε points) από το σημείο προέλευσης του σχήματος.
- [TileScaleX](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tilescalex/): Καθορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [TileScaleY](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tilescaley/): Καθορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω δείγματος κώδικα δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με tiled picture fill και να διαμορφώσετε τις επιλογές πλακιδίων:

```c#
// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λήψη της πρώτης διαφάνειας.
    ISlide firstSlide = presentation.Slides[0];

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ορισμός τύπου γεμίσματος του σχήματος σε Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Φόρτωση της εικόνας και προσθήκη της στους πόρους της παρουσίασης.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Ανάθεση της εικόνας στο σχήμα.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Ρύθμιση της λειτουργίας picture fill και των ιδιοτήτων επικάλυψης.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίων](tile-options.png)

## **Συμπλήρωση Συμπαγούς Χρώματος (Solid Color Fill)**

Στο PowerPoint, το Solid Color Fill είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε solid color fill σε σχήμα με χρήση του Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του σχήματος σε `Solid`.
5. Εκχωρήστε το προτιμώμενο χρώμα γεμίσματος στο σχήμα.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε solid color fill σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```c#
// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λήξη της πρώτης διαφάνειας.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορισμός τύπου γεμίσματος σε Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Ορισμός χρώματος γεμίσματος.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το σχήμα με solid color fill](solid-color-fill.png)

## **Ορισμός Διαφάνειας (Set Transparency)**

Στο PowerPoint, όταν εφαρμόζετε solid color, gradient, picture ή texture fill σε σχήματα, μπορείτε επίσης να ορίσετε επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γεμίσματος. Μια υψηλότερη τιμή διαφάνειας κάνει το σχήμα πιο διαυγές, επιτρέποντας στο παρασκήνιο ή στα υποκείμενα αντικείμενα να φαίνονται εν μέρει.

Το Aspose.Slides σάς δίνει τη δυνατότητα να ορίσετε το επίπεδο διαφάνειας προσαρμόζοντας την τιμή άλφα στο χρώμα που χρησιμοποιείται για το γέμισμα. Δείτε πώς:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) σε `Solid`.
5. Χρησιμοποιήστε `Color.FromArgb(alpha, baseColor)` για να ορίσετε χρώμα με διαφάνεια (το στοιχείο `alpha` ελέγχει τη διαφάνεια).
6. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε χρώμα γεμίσματος με διαφάνεια σε ένα ορθογώνιο:

```c#
const int alpha = 128;

// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη αυτόματου σχήματος ορθογωνίου με συμπαγές γέμισμα.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθήκη διαφανούς αυτόματου σχήματος ορθογωνίου πάνω από το συμπαγές σχήμα.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων (Rotate Shapes)**

Το Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένη ευθυγράμμιση ή σχεδιαστικές απαιτήσεις.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα εξής βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Ορίστε την ιδιότητα `Rotation` του σχήματος στην επιθυμητή γωνία.
5. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```c#
// Δημιουργία αντικειμένου της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λήψη της πρώτης διαφάνειας.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη αυτόματου σχήματος τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Περιστροφή του σχήματος κατά 5 μοίρες.
    shape.Rotation = 5;

    // Αποθήκευση του αρχείου PPTX στον δίσκο.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3D Εφέ Κλίεσης (Add 3D Bevel Effects)**

Το Aspose.Slides σας επιτρέπει να εφαρμόσετε 3D εφέ κλίεσης σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/).

Για να προσθέσετε 3D εφέ κλίεσης σε σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Ρυθμίστε το [ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις κλίεσης.
5. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε 3D εφέ κλίεσης σε σχήμα:

```c#
// Δημιουργία ενός αντικειμένου της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Προσθήκη σχήματος στη διαφάνεια.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Ορισμός ιδιοτήτων ThreeDFormat του σχήματος.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το 3D εφέ κλίεσης](3D-bevel-effect.png)

## **Προσθήκη 3D Εφέ Περιστροφής (Add 3D Rotation Effects)**

Το Aspose.Slides σας επιτρέπει να εφαρμόσετε 3D εφέ περιστροφής σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/).

Για να εφαρμόσετε 3D περιστροφή σε σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
3. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Ορίστε το [CameraType](https://reference.aspose.com/slides/el/net/aspose.slides/icamera/cameratype/) και το [LightType](https://reference.aspose.com/slides/el/net/aspose.slides/ilightrig/lighttype/) του σχήματος για να ορίσετε την 3D περιστροφή.
5. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε 3D εφέ περιστροφής σε σχήμα:

```c#
// Δημιουργία ενός αντικειμένου της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το 3D εφέ περιστροφής](3D-rotation-effect.png)

## **Επαναφορά Μορφοποίησης (Reset Formatting)**

Ο παρακάτω κώδικας C# δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στη [LayoutSlide](https://reference.aspose.com/slides/el/net/aspose.slides/layoutslide/) στις προεπιλεγμένες τους ρυθμίσεις:

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

## **Συχνές Ερωτήσεις (FAQ)**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν σχεδόν καθόλου επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν ταυτοποίηση μορφοποίησης ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος—γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ ως ταυτοποίηση και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη διαχείριση στυλ αργότερα.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρήση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο αρχείο διαφανειών ή σε αρχείο .POTX. Κατά τη δημιουργία νέας παρουσίασης, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλ σχήματος που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίηση όπου απαιτείται.
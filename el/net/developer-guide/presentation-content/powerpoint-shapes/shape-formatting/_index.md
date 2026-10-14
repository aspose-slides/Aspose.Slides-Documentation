---
title: Μορφοποίηση Σχημάτων PowerPoint σε .NET
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/net/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσο
- γραμμή σχήματος σκίτσο
- μορφοποίηση στυλ σύνδεσης
- γέμισμα διαβάθμισης
- γέμισμα σχεδίου
- γέμισμα εικόνας
- γέμισμα υφής
- γέμισμα στερεού χρώματος
- διαφάνεια σχήματος
- μαυροάσπρος αποτύπωση σχήματος
- απόδοση σχήματος σε γκρι κλίμακα
- περιστροφή σχήματος
- εφέ 3D κεφαλής
- εφέ 3D περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε C# χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γέμισματος, γραμμής και εφέ για αρχεία PPT και PPTX με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Επειδή τα σχήματα αποτελούνται από γραμμές, μπορείτε να μορφοποιήσετε τις γραμμές τους τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν το πώς γεμίζουν τα εσωτερικά τους.

![μορφοποίηση-σχήματος-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides for .NET παρέχει διεπαφές και ιδιότητες που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να καθορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πάχος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα της γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς να μορφοποιήσετε ένα ορθογώνιο `AutoShape`:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε το αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για το σχήμα Rectangle.
    shape.FillFormat.FillType = FillType.NoFill;

    // Εφαρμόστε μορφοποίηση στις γραμμές του Rectangle.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Ορίστε το χρώμα για τη γραμμή του Rectangle.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

## **Εφαρμογή Σχεδίου Εφέ στις Γραμμές Σχήματος**

Ένα εφέ σχεδίου κάνει τη γραμμή ενός σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε το [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) για πρόσβαση στις ρυθμίσεις γραμμής, το [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) για τις ρυθμίσεις σχεδίου, και το [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) για να επιλέξετε μια τιμή από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/), να διαβάσετε την ρητά ορισμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using Aspose.Slides;

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

Η τιμή που επιστρέφει το `ISketchFormat.SketchType` αντιπροσωπεύει τη ρύθμιση που έχει οριστεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληρονομηθεί από ένα θέμα, τη ματρική διαφάνεια ή τη διάταξη διαφάνειας, χρησιμοποιήστε το [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), αποκτήστε πρόσβαση στο [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), και διαβάστε το [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Η αποτελεσματική τιμή αντανακλά τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονόμησης:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Μορφοποίηση Στυλ Συνδέσμων**

Τα τρία διαθέσιμα στυλ σύνδεσης είναι:

* Στρογγυλό
* Οξυγώνιο
* Κωνικό

Από προεπιλογή, όταν το PowerPoint συνδέει δύο γραμμές σε γωνία (όπως στην γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν σχεδιάζετε ένα σχήμα με οξυγώνιες γωνίες, μπορεί να προτιμήσετε την επιλογή **Οξυγώνιο**.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Ο παρακάτω κώδικας C# δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνονται στην εικόνα παραπάνω) χρησιμοποιώντας τις ρυθμίσεις στυλ σύνδεσης Οξυγώνιο, Κωνικό και Στρογγυλό:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε τρία αυτόματα σχήματα τύπου Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για κάθε σχήμα Rectangle.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Ορίστε το πλάτος της γραμμής.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Ορίστε το χρώμα για τη γραμμή κάθε Rectangle.
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

    // Προσθέστε κείμενο σε κάθε Rectangle.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Γέμισμα Διαβάθμισης**

Στο PowerPoint, το Γέμισμα Διαβάθμισης είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε μια συνεχόμενη ανάμειξη χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τέτοιο τρόπο που το ένα να εξασθενεί σταδιακά στο άλλο.

Ακολουθεί ο τρόπος εφαρμογής γέμισης διαβάθμισης σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `Add` της συλλογής διαβάθμισης που εκτίθενται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε το εφέ γέμισης διαβάθμισης σε μία έλλειψη:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Εφαρμόστε μορφοποίηση διαβάθμισης στην Ellipse.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Ορίστε την κατεύθυνση της διαβάθμισης.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Προσθέστε δύο στάσεις διαβάθμισης.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η έλλειψη με γέμισμα διαβάθμισης](gradient-fill.png)

Εάν μια διαβάθμιση φαίνεται διαφορετική σε μια εξαγόμενη εικόνα σε σχέση με το PowerPoint, δείτε το άρθρο [Choose a Gradient Rendering Style](/slides/el/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε ένα στυλ απόδοσης χωρίς να αλλάξετε το γέμισμα διαβάθμισης που αποθηκεύεται στην παρουσίαση.

## **Γέμισμα Σχεδίου**

Στο PowerPoint, το Γέμισμα Σχεδίου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε ένα σχέδιο δύο χρωμάτων—όπως κουκκίδες, λωρίδες, σταυρόγραφα ή σκακιές—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το φόντο του σχεδίου.

Το Aspose.Slides παρέχει πάνω από 45 προεγκατεστημένα στυλ σχεδίου που μπορείτε να εφαρμόσετε σε σχήματα για να ενισχύσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και μετά την επιλογή ενός προκαθορισμένου σχεδίου, μπορείτε να καθορίσετε τα ακριβή χρώματα που θα χρησιμοποιηθούν.

Ακολουθεί ο τρόπος εφαρμογής γέμισματος σχεδίου σε σχήμα χρησιμοποιώντας το Aspose.Slides:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ σχεδίου από τις προκαθορισμένες επιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) του σχεδίου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) του σχεδίου.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε γέμισμα σχεδίου σε ένα ορθογώνιο:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ορίστε τον τύπο γεμίσματος σε Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Ορίστε το στυλ του προτύπου.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Ορίστε τα χρώματα φόντου και προσκηνίου του προτύπου.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμισμα σχεδίου](pattern-fill.png)

## **Γέμισμα Εικόνας**

Στο PowerPoint, το Γέμισμα Εικόνας είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εισάγετε μια εικόνα μέσα σε ένα σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθεί ο τρόπος χρήσης του Aspose.Slides για να εφαρμόσετε γέμισμα εικόνας σε σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γέμισης εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Αναθέστε αυτήν την εικόνα στην ιδιότητα `Picture.Image` του `PictureFillFormat` του σχήματος.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ας πούμε ότι έχουμε ένα αρχείο "lotus.png" με την παρακάτω εικόνα:

![Η εικόνα λωτού](lotus.png)

Ο παρακάτω κώδικας C# δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Ορίστε τον τύπο γεμίσματος σε Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Ορίστε τη λειτουργία γέμισης εικόνας.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Φορτώστε μια εικόνα και προσθέστε την στους πόρους της παρουσίασης.
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

![Το σχήμα με γέμισμα εικόνας](picture-fill.png)

### **Τίλ ταινισμένη Εικόνα ως Υφή**

Αν θέλετε να ορίσετε μια επαναλαμβανόμενη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά της επαναφοράς, μπορείτε να χρησιμοποιήσετε τις παρακάτω ιδιότητες της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Ορίζει τη λειτουργία γέμισης εικόνας—είτε `Tile` είτε `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Ελέγχει αν το πλακίδιο αναστρέφεται οριζόντια, κάθετα ή και τα δύο.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Ορίζει τη λοξή μετατόπιση του πλακιδίου (σε σημεία) από την αρχή του σχήματος.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Ορίζει την κατακόρυφη μετατόπιση του πλακιδίου (σε σημεία) από την αρχή του σχήματος.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω δείγμα κώδικα δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με επαναλαμβανόμενο γέμισμα εικόνας και να ρυθμίσετε τις επιλογές πλακιδίων:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λάβετε την πρώτη διαφάνεια.
    ISlide firstSlide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα Rectangle.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Φορτώστε την εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Αναθέστε την εικόνα στο σχήμα.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Διαμορφώστε τη λειτουργία γέμισης εικόνας και τις ιδιότητες επικάλυψης.
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

![Οι επιλογές πλακιδίων](tile-options.png)

## **Γέμισμα Στερεού Χρώματος**

Στο PowerPoint, το Γέμισμα Στερεού Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή σχέδια.

Για να εφαρμόσετε γέμισμα στερεού χρώματος σε σχήμα χρησιμοποιώντας το Aspose.Slides, ακολουθήστε τα εξής βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Αναθέστε το προτιμώμενο χρώμα γέμισης στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσία ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε γέμισμα στερεού χρώματος σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λάβετε την πρώτη διαφάνεια.
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

![Το σχήμα με στερεό χρώμα γέμισης](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε στερεό χρώμα, διαβάθμιση, εικόνα ή υφή σε σχήματα, μπορείτε επίσης να ορίσετε ένα επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γεμίσματος. Ένα υψηλότερο επίπεδο διαφάνειας κάνει το σχήμα πιο διάφανο, επιτρέποντας στο παρασκήνιο ή στα υποκείμενα αντικείμενα να είναι μερικώς ορατά.

Το Aspose.Slides σας επιτρέπει να ορίσετε το επίπεδο διαφάνειας ρυθμίζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε `Color.FromArgb(alpha, baseColor)` για να ορίσετε ένα χρώμα με διαφάνεια (το συστατικό `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε χρώμα γεμίσματος με διαφάνεια σε ένα ορθογώνιο:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λάβετε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα στερεό αυτόματο σχήμα Rectangle.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθέστε ένα διαφανές αυτόματο σχήμα Rectangle πάνω στο στερεό σχήμα.
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

Το Aspose.Slides σας επιτρέπει να περιστρέψετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένη ευθυγράμμιση ή σχεδιαστικές απαιτήσεις.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε την ιδιότητα `Rotation` του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας C# δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Λάβετε την πρώτη διαφάνεια.
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

## **Προσθήκη Εφέ 3D Κεφαλής**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε εφέ 3Δ κεφαλής σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) .

Για να προσθέσετε εφέ 3D κεφαλής σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ρυθμίστε το [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις παραμέτρους κεφαλής.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε εφέ 3D κεφαλής σε ένα σχήμα:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![Το εφέ 3D κεφαλής](3D-bevel-effect.png)

## **Προσθήκη Εφέ 3D Περιστροφής**

Το Aspose.Slides σας επιτρέπει να εφαρμόζετε εφέ 3D περιστροφής σε σχήματα ρυθμίζοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) .

Για να εφαρμόσετε 3D περιστροφή σε ένα σχήμα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση τον δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) στη διαφάνεια.
1. Ορίστε το [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) και το [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) του σχήματος για να ορίσετε την 3D περιστροφή.
1. Αποθηκεύστε την παρουσία.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε εφέ 3D περιστροφής σε ένα σχήμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία ενός αντικειμένου της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το εφέ 3D περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Μαυρισμού-Ασπρόμαυρης Απόδοσης για Σχήματα**

Η ιδιότητα [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) καθορίζει πώς αποδίδεται ένα μεμονωμένο σχήμα όταν μια παρουσία προβάλλεται ή επεξεργάζεται σε μαυρισμό-ασπρόμαυρη λειτουργία. Η ιδιότητα αυτή δεν ενεργοποιεί μόνο η μαυρισμός-ασπρόμαυρη προβολή· δεν αλλάζει το γέμισμα, τη γραμμή ή άλλες μορφοποιήσεις του σχήματος σε κανονική λειτουργία χρώματος.

Χρησιμοποιήστε μια τιμή από την απαρίθμηση [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) για να επιλέξετε τη συμπεριφορά που επιθυμείτε. Για παράδειγμα, το `Automatic` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκριχρώματα, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και άσπρο, τα `Black` και `White` επιβάλλουν ένα ενιαίο χρώμα, το `Color` διατηρεί το κανονικό χρώμα, ενώ το `Hidden` αποκρύπτει το σχήμα στη μαυρισμό-ασπρόμαυρη λειτουργία. Το `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Ο παρακάτω κώδικας C# δημιουργεί ένα χρωματιστό σχήμα και το εμφανίζει γκρι σε μαυρισμό-ασπρόμαυρη προβολή:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Σε κανονική λειτουργία χρώματος, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμά του. Σε ροή εργασίας μαυρισμού-ασπρόμαυρης προβολής, εμφανίζεται με γκρι χρώμα επειδή το mode του έχει οριστεί σε `Gray`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρως έγχρωμη διαφάνεια, ορίζοντας ταυτόχρονα μια ξεχωριστή εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που λαμβάνουν υπόψη τις ρυθμίσεις μαυρισμού-ασπρόμαυρης προβολής της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας C# δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με σύμβολα στην [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Επαναφορά κάθε σχήματος στη διαφάνεια που έχει σύμβολο κράτησης θέσης στη διάταξη.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα μέσα καταλαμβάνουν το μεγαλύτερο μέρος του χώρου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και δεν προσθέτουν ουσιαστικά επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται ταυτόσημη μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις κύριες ιδιότητες μορφοποίησης κάθε σχήματος—ρυθμίσεις γέμισης, γραμμής και εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε ότι τα στυλ είναι ταυτόσημα και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρήση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγμα σχήματος με τα επιθυμητά στυλ σε μια διαφάνεια προτύπου ή σε αρχείο .POTX. Όταν δημιουργείτε νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.
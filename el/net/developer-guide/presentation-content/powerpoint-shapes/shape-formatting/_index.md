---
title: Διαμόρφωση Σχημάτων PowerPoint σε .NET
linktitle: Διαμόρφωση Σχήματος
type: docs
weight: 20
url: /el/net/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσου
- γραμμή σκίτσου σχήματος
- μορφοποίηση στυλ σύνδεσης
- γέμιση διαβάθμισης
- γέμιση μοτίβου
- γέμιση εικόνας
- γέμιση υφής
- συμπαγής γέμιση χρώματος
- διαφάνεια σχήματος
- απόδοση σχήματος σε μαύρο-λευκό
- απόδοση σχήματος σε γκρι κλίμακα
- περιστροφή σχήματος
- εφέ λοξότμησης 3Δ
- εφέ περιστροφής 3Δ
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να διαμορφώνετε σχήματα PowerPoint σε C# χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT και PPTX με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Στο PowerPoint, μπορείτε να προσθέσετε σχήματα στις διαφάνειες. Επειδή τα σχήματα αποτελούνται από γραμμές, μπορείτε να τα μορφοποιήσετε τροποποιώντας ή εφαρμόζοντας εφέ στα περιγράμματά τους. Επιπλέον, μπορείτε να μορφοποιήσετε τα σχήματα καθορίζοντας ρυθμίσεις που ελέγχουν πώς γεμίζουν τα εσωτερικά τους.

![format-shape-powerpoint](format-shape-powerpoint.png)

Το Aspose.Slides for .NET παρέχει διεπαφές και ιδιότητες που σας επιτρέπουν να μορφοποιήσετε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που είναι διαθέσιμες στο PowerPoint.

## **Διαμόρφωση Γραμμών**

Χρησιμοποιώντας το Aspose.Slides, μπορείτε να ορίσετε προσαρμοσμένο στυλ γραμμής για ένα σχήμα. Τα παρακάτω βήματα περιγράφουν τη διαδικασία:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στην διαφάνεια.
1. Ορίστε το [line style](https://reference.aspose.com/slides/el/net/aspose.slides/linestyle/) του σχήματος.
1. Ορίστε το πλάτος της γραμμής.
1. Ορίστε το [dash style](https://reference.aspose.com/slides/el/net/aspose.slides/linedashstyle/) της γραμμής.
1. Ορίστε το χρώμα γραμμής για το σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς να μορφοποιήσετε ένα `AutoShape` ορθογώνιο:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε μια αυτόματη μορφή τύπου Rectangle.
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

![The formatted lines in the presentation](formatted-lines.png)

## **Εφαρμογή Σχεδίου Εφέ σε Γραμμές Σχήματος**

Ένα εφέ σκίτσο κάνει τη γραμμή ενός σχήματος να φαίνεται σχεδιασμένη με το χέρι. Χρησιμοποιήστε το [IShape.LineFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/lineformat/) για πρόσβαση στις ρυθμίσεις γραμμής, το [ILineFormat.SketchFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ilineformat/sketchformat/) για πρόσβαση στις ρυθμίσεις σκίτσο, και το [ISketchFormat.SketchType](https://reference.aspose.com/slides/el/net/aspose.slides/isketchformat/sketchtype/) για επιλογή τιμής από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/el/net/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/el/net/aspose.slides/linesketchtype/), να διαβάσετε την ρητά ανατεθειμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType.None](https://reference.aspose.com/slides/el/net/aspose.slides/linesketchtype/):

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

Η τιμή που επιστρέφει το `ISketchFormat.SketchType` αντιπροσωπεύει τη ρύθμιση που έχει ανατεθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληρονομηθεί από θέμα, κύρια διαφάνεια ή διάταξη, χρησιμοποιήστε το [ILineFormat.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/ilineformat/geteffective/), προσπελάστε το [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ilineformateffectivedata/sketchformat/), και διαβάστε το [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/el/net/aspose.slides/isketchformateffectivedata/sketchtype/). Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται μετά την επίλυση της κληρονομίας:

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

## **Διαμόρφωση Στυλ Συνδέσεων**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Στρογγυλό
* Μυτερό
* Λοξότμητο

Από προεπιλογή, όταν το PowerPoint συνδέει δύο γραμμές υπό γωνία (όπως στη γωνία ενός σχήματος), χρησιμοποιεί τη ρύθμιση **Στρογγυλό**. Ωστόσο, εάν σχεδιάζετε σχήμα με οξυγόνες γωνίες, μπορεί να προτιμήσετε την επιλογή **Μυτερό**.

![The join style in the presentation](join-style-powerpoint.png)

Ο παρακάτω κώδικας C# δείχνει πώς δημιουργήθηκαν τρία ορθογώνια (όπως φαίνονται στην εικόνα παραπάνω) χρησιμοποιώντας τις ρυθμίσεις τύπου σύνδεσης Μυτερό, Λοξότμητο και Στρογγυλό:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε τρία αυτόματα σχήματα τύπου Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ορίστε το χρώμα γεμίσματος για κάθε σχήμα rectangle.
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

    // Ορίστε το χρώμα για τη γραμμή κάθε rectangle.
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

    // Προσθέστε κείμενο σε κάθε rectangle.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Γέμιση Διαβάθμισης**

Στο PowerPoint, η Γέμιση Διαβάθμισης είναι μια επιλογή μορφοποίησης που επιτρέπει την εφαρμογή συνεχούς μίξης χρωμάτων σε ένα σχήμα. Για παράδειγμα, μπορείτε να εφαρμόσετε δύο ή περισσότερα χρώματα με τρόπο που το ένα να εξασθένει σταδιακά στο άλλο.

Ακολουθεί ο τρόπος εφαρμογής γέμισης διαβάθμισης σε σχήμα με χρήση του Aspose.Slides:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στην διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του σχήματος σε `Gradient`.
1. Προσθέστε τα δύο προτιμώμενα χρώματά σας με καθορισμένες θέσεις χρησιμοποιώντας τις μεθόδους `Add` της συλλογής διαβάθμισης που εκτίθεται από τη διεπαφή [IGradientFormat](https://reference.aspose.com/slides/el/net/aspose.slides/igradientformat/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε το εφέ γέμισης διαβάθμισης σε μια έλλειψη:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // Προσθέστε δύο σημείο διαβάθμισης.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![The ellipse with gradient fill](gradient-fill.png)

## **Γέμιση Μοτίβου**

Στο PowerPoint, η Γέμιση Μοτίβου είναι μια επιλογή μορφοποίησης που σας επιτρέπει να εφαρμόσετε σχεδίαση δύο χρωμάτων—όπως κουκκίδες, λωρίδες, σταυρογραμμές ή σκαναρίσματα—σε ένα σχήμα. Μπορείτε να επιλέξετε προσαρμοσμένα χρώματα για το προσκήνιο και το παρασκήνιο του μοτίβου.

Το Aspose.Slides παρέχει πάνω από 45 προεπιλεγμένα στυλ μοτίβου που μπορείτε να εφαρμόσετε σε σχήματα για να βελτιώσετε την οπτική ελκυστικότητα των παρουσιάσεών σας. Ακόμη και μετά την επιλογή ενός προεπιλεγμένου μοτίβου, μπορείτε να καθορίσετε τα ακριβή χρώματα που θα χρησιμοποιηθούν.

Ακολουθεί η διαδικασία για την εφαρμογή γέμισης μοτίβου σε σχήμα με χρήση του Aspose.Slides:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στην διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του σχήματος σε `Pattern`.
1. Επιλέξτε ένα στυλ μοτίβου από τις προεπιλογές.
1. Ορίστε το [Background Color](https://reference.aspose.com/slides/el/net/aspose.slides/ipatternformat/backcolor/) του μοτίβου.
1. Ορίστε το [Foreground Color](https://reference.aspose.com/slides/el/net/aspose.slides/ipatternformat/forecolor/) του μοτίβου.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε γέμιση μοτίβου σε ένα ορθογώνιο:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![The rectangle with pattern fill](pattern-fill.png)

## **Γέμιση Εικόνας**

Στο PowerPoint, η Γέμιση Εικόνας είναι μια επιλογή μορφοποίησης που επιτρέπει την εισαγωγή μιας εικόνας μέσα σε σχήμα—χρησιμοποιώντας ουσιαστικά την εικόνα ως φόντο του σχήματος.

Ακολουθεί ο τρόπος χρήσης του Aspose.Slides για την εφαρμογή γέμισης εικόνας σε σχήμα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στην διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του σχήματος σε `Picture`.
1. Ορίστε τη λειτουργία γέμισης εικόνας σε `Tile` (ή άλλη προτιμώμενη λειτουργία).
1. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) από την εικόνα που θέλετε να χρησιμοποιήσετε.
1. Εκχωρήστε αυτήν την εικόνα στην ιδιότητα `Picture.Image` του `PictureFillFormat` του σχήματος.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ας πούμε ότι έχουμε το αρχείο «lotus.png» με την παρακάτω εικόνα:

![The lotus picture](lotus.png)

Ο παρακάτω κώδικας C# δείχνει πώς να γεμίσετε ένα σχήμα με την εικόνα:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

![The shape with picture fill](picture-fill.png)

### **Πλακίδιο Εικόνας ως Υφή**

Εάν θέλετε να ορίσετε μια παρναρισμένη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά του παρναρισμού, μπορείτε να χρησιμοποιήσετε τις παρακάτω ιδιότητες της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/picturefillmode/): Ορίζει τη λειτουργία γεμίσματος εικόνας—είτε `Tile` είτε `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tilealignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [TileFlip](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tileflip/): Ελέγχει εάν το πλακίδιο θα αναστραφεί οριζόντια, κάθετα ή και τα δύο.
- [TileOffsetX](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tileoffsetx/): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε points) από το σημείο προέλευσης του σχήματος.
- [TileOffsetY](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tileoffsety/): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε points) από το σημείο προέλευσης του σχήματος.
- [TileScaleX](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tilescalex/): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [TileScaleY](https://reference.aspose.com/slides/el/net/aspose.slides/ipicturefillformat/tilescaley/): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Ο παρακάτω κώδικας δείχνει πώς να προσθέσετε ένα ορθογώνιο σχήμα με γέμισμα εικόνας σε μορφή παρναρισμού και να ρυθμίσετε τις επιλογές παρναρισμού:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide firstSlide = presentation.Slides[0];

    // Προσθέστε ένα αυτόματο σχήμα τύπου Rectangle.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ορίστε τον τύπο γεμίσματος του σχήματος σε Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Φορτώστε την εικόνα και προσθέστε την στους πόρους της παρουσίασης.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Εκχωρήστε την εικόνα στο σχήμα.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Διαμορφώστε τη λειτουργία γεμίσματος εικόνας και τις ιδιότητες παρναρισμού.
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

![The tile options](tile-options.png)

## **Συμπαγής Γέμιση Χρώματος**

Στο PowerPoint, η Συμπαγής Γέμιση Χρώματος είναι μια επιλογή μορφοποίησης που γεμίζει ένα σχήμα με ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το απλό χρώμα φόντου εφαρμόζεται χωρίς διαβαθμίσεις, υφές ή μοτίβα.

Για να εφαρμόσετε συμπαγή γέμιση χρώματος σε σχήμα με χρήση του Aspose.Slides, ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στην διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) του σχήματος σε `Solid`.
1. Εκχωρήστε το επιθυμητό χρώμα γεμίσματος στο σχήμα.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε συμπαγή γέμιση χρώματος σε ένα ορθογώνιο σε διαφάνεια PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![The shape with solid color fill](solid-color-fill.png)

## **Ορισμός Διαφάνειας**

Στο PowerPoint, όταν εφαρμόζετε συμπαγές χρώμα, διαβάθμιση, εικόνα ή υφή σε σχήματα, μπορείτε επίσης να ορίσετε επίπεδο διαφάνειας για να ελέγξετε την αδιαφάνεια του γεμίσματος. Μια μεγαλύτερη τιμή διαφάνειας κάνει το σχήμα πιο διαφανές, επιτρέποντας στο φόντο ή στα υποκείμενα αντικείμενα να φαίνονται εν μέρει.

Το Aspose.Slides επιτρέπει τον καθορισμό του επιπέδου διαφάνειας προσαρμόζοντας την τιμή alpha στο χρώμα που χρησιμοποιείται για το γέμισμα. Δείτε πώς:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στην διαφάνεια.
1. Ορίστε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) σε `Solid`.
1. Χρησιμοποιήστε `Color.FromArgb(alpha, baseColor)` για να ορίσετε ένα χρώμα με διαφάνεια (το στοιχείο `alpha` ελέγχει τη διαφάνεια).
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε χρώμα γεμίσματος με διαφάνεια σε ένα ορθογώνιο:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Δημιουργήστε ένα αντικείμενο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using (Presentation presentation = new Presentation())
{
    // Αποκτήστε την πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθέστε ένα συμπαγό αυτόματο σχήμα τύπου Rectangle.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Προσθέστε ένα διαφανές αυτόματο σχήμα τύπου Rectangle πάνω από το συμπαγές σχήμα.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Αποθηκεύστε το αρχείο PPTX στον δίσκο.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![The transparent shape](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Το Aspose.Slides σας επιτρέπει να περιστρέφετε σχήματα σε παρουσιάσεις PowerPoint. Αυτό μπορεί να είναι χρήσιμο όταν τοποθετείτε οπτικά στοιχεία με συγκεκριμένη στοίχιση ή σχεδιαστικές ανάγκες.

Για να περιστρέψετε ένα σχήμα σε μια διαφάνεια, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στην διαφάνεια.
1. Ορίστε την ιδιότητα `Rotation` του σχήματος στην επιθυμητή γωνία.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς να περιστρέψετε ένα σχήμα κατά 5 μοίρες:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

![The shape rotation](shape-rotation.png)

## **Προσθήκη 3Δ Εφέ Λοξότμησης**

Το Aspose.Slides επιτρέπει την εφαρμογή 3Δ εφέ λοξότμησης σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/).

Για να προσθέσετε 3Δ εφέ λοξότμησης σε ένα σχήμα, ακολουθήστε τα βήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στην διαφάνεια.
1. Διαμορφώστε το [ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/) του σχήματος για να ορίσετε τις ρυθμίσεις λοξότμησης.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε 3Δ εφέ λοξότμησης σε ένα σχήμα:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
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

![The 3D bevel effect](3D-bevel-effect.png)

## **Προσθήκη 3Δ Εφέ Περιστροφής**

Το Aspose.Slides επιτρέπει την εφαρμογή 3Δ εφέ περιστροφής σε σχήματα διαμορφώνοντας τις ιδιότητες του [ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/).

Για να εφαρμόσετε 3Δ περιστροφή σε ένα σχήμα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Λάβετε μια αναφορά σε μια διαφάνεια με βάση το δείκτη της.
1. Προσθέστε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στην διαφάνεια.
1. Ορίστε τις ιδιότητες [CameraType](https://reference.aspose.com/slides/el/net/aspose.slides/icamera/cameratype/) και [LightType](https://reference.aspose.com/slides/el/net/aspose.slides/ilightrig/lighttype/) του σχήματος για να ορίσετε την 3Δ περιστροφή.
1. Αποθηκεύστε την παρουσίαση.

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε 3Δ εφέ περιστροφής σε ένα σχήμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Αποθηκεύστε την παρουσίαση ως αρχείο PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![The 3D rotation effect](3D-rotation-effect.png)

## **Έλεγχος Μαύρο-Λευκής Απόδοσης για Σχήματα**

Η ιδιότητα [IShape.BlackWhiteMode](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/blackwhitemode/) καθορίζει πώς αποδίδεται ένα ατομικό σχήμα όταν η παρουσίαση προβάλλεται ή υποβάλλεται σε επεξεργασία σε μαύρο-λευκό τρόπο. Δεν ενεργοποιεί αυτόματα την εμφάνιση σε μαύρο-λευκό και δεν αλλάζει τη γέμιση, τη γραμμή ή άλλες μορφοποιήσεις του σχήματος σε κανονική έγχρωμη λειτουργία.

Χρησιμοποιήστε μια τιμή από την απαρίθμηση [BlackWhiteMode](https://reference.aspose.com/slides/el/net/aspose.slides/blackwhitemode/) για να επιλέξετε τη συμπεριφορά. Για παράδειγμα, το `Automatic` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκρι χρωματική απόδοση, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, τα `Black` και `White` επιβάλλουν ένα ενιαίο χρώμα, το `Color` διατηρεί το κανονικό χρώμα, και το `Hidden` αποκρύπτει το σχήμα σε μαύρο-λευκό τρόπο. Το `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Ο παρακάτω κώδικας C# δημιουργεί ένα χρωματιστό σχήμα και το κάνει να εμφανίζεται γκρι σε μαύρο-λευκό τρόπο εμφάνισης:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Διατηρήστε το πορτοκαλί γέμισμα σε έγχρωμη λειτουργία, αλλά αποδώστε το σχήμα με γκρι χρωματισμό σε λειτουργία μαύρο-λευκό.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Σε κανονική έγχρωμη λειτουργία, το ορθογώνιο διατηρεί τη ντομάτα-πορτοκαλί γέμιση του. Σε ροή εργασίας εμφάνισης μαύρο-λευκού, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του είναι ορισμένη σε `Gray`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρως έγχρωμη διαφάνεια ενώ ορίζετε ξεχωριστή εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις μαύρο-λευκής εμφάνισης της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Ο παρακάτω κώδικας C# δείχνει πώς να επαναφέρετε τη μορφοποίηση μιας διαφάνειας και να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση όλων των σχημάτων με placeholders στο [LayoutSlide](https://reference.aspose.com/slides/el/net/aspose.slides/layoutslide/) στις προεπιλεγμένες ρυθμίσεις τους:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Επαναφορά κάθε σχήματος στη διαφάνεια που έχει placeholder στην διάταξη.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Επιφέρει η μορφοποίηση των σχημάτων στο τελικό μέγεθος του αρχείου παρουσίασης;**

Μόνο ελάχιστα. Οι ενσωματωμένες εικόνες και τα πολυμέσα καταλαμβάνουν το μεγαλύτερο μέρος του αρχείου, ενώ οι παράμετροι σχήματος όπως χρώματα, εφέ και διαβαθμίσεις αποθηκεύονται ως μεταδεδομένα και προσθέτουν πρακτικά μηδενικό επιπλέον μέγεθος.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος—γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ ως τα ίδια και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλουστεύει τη μετέπειτα διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο σετ διαφανειών ή σε αρχείο προτύπου .POTX. Κατά τη δημιουργία νέας παρουσίασης, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλιζαρισμένα σχήματα που χρειάζεστε και επαναεφαρμόστε τη μορφοποίησή τους όπου απαιτείται.
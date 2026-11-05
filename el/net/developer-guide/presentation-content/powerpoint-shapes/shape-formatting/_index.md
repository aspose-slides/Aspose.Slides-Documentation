---
title: Διαμορφώστε Σχήματα PowerPoint σε .NET
linktitle: Μορφοποίηση Σχήματος
type: docs
weight: 20
url: /el/net/shape-formatting/
keywords:
- μορφοποίηση σχήματος
- μορφοποίηση γραμμής
- εφέ σκίτσο
- εφέ γραμμής σκίτσο
- μορφοποίηση στυλ σύνδεσης
- γέμισμα διαβάθμισης
- γέμισμα μοτίβου
- γέμισμα εικόνας
- γέμισμα υφής
- γέμισμα στερεού χρώματος
- διαφάνεια σχήματος
- απεικόνιση σχήματος σε ασπρόμαυρο
- απεικόνιση σχήματος σε αποχρώσεις του γκρι
- περιστροφή σχήματος
- εφέ 3D bevel
- εφέ 3D περιστροφής
- επαναφορά μορφοποίησης
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε C# χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT και PPTX με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Διαμορφώστε σχήματα στο PowerPoint προσαρμόζοντας τα περιγράμματά τους, τις γεμίσεις και τα εφέ. Το Aspose.Slides για .NET σας επιτρέπει να ελέγχετε αυτές τις ρυθμίσεις προγραμματιστικά, συμπεριλαμβανομένης της διαφάνειας, της περιστροφής και της 3D μορφοποίησης.

![Επιλογές μορφοποίησης σχήματος στο PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides για .NET παρέχει διεπαφές και ιδιότητες που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιήστε [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) για να ελέγξετε το περίγραμμα ενός σχήματος. Αυτό το παράδειγμα δημιουργεί ένα μη γεμιστό ορθογώνιο με μπλε, διακεκομμένο περίγραμμα. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) επιλέγει μια σύνθετη γραμμή παχιά-λεπτή, ενώ [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) ορίζει το πλάτος της στα 7 σημεία και [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) επιλέγει το μοτίβο παύλας.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

### **Ορισμός προσαρμοσμένων μοτίβων παύλας γραμμής**

Χρησιμοποιήστε [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) όταν τα προεπιλεγμένα στυλ γραμμής δεν παρέχουν τα μήκη παύλων και κενών που χρειάζεστε, για παράδειγμα για σήματα περιγράμματος ή τεχνικά διαγράμματα. Η ανάθεση ενός μοτίβου ορίζει αυτόματα το [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) σε [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

Τα στοιχεία του πίνακα εναλλάσσονται μεταξύ μηκών παύλης και κενών, αρχίζοντας με παύλη. Κάθε τιμή είναι πολλαπλάσιο του πλάτους της γραμμής: `{ 4, 2 }` σε πλάτος 3 σημείων παράγει μια παύλη 12 σημείων ακολουθούμενη από κενό 6 σημείων. Χρησιμοποιήστε ζεύγη πεπερασμένων, μη αρνητικών τιμών για να ορίσετε πλήρη τμήματα παύλας-κενού. Το παράδειγμα χρησιμοποιεί θετικές τιμές ώστε κάθε παύλα και κενό να είναι ορατά.

Αυτό το παράδειγμα δημιουργεί πέντε μπλε γραμμές με το ίδιο μήκος και επίπεδες άκρες. Οι πρώτες τρεις συγκρίνουν μοτίβα σε πλάτος 3 σημείων. Η τέταρτη επαναλαμβάνει το πρώτο μοτίβο στο διπλάσιο πλάτος, διπλασιάζοντας τόσο τις παύλες όσο και τα κενά. Η πέμπτη αλλάζει από προσαρμοσμένο μοτίβο σε γεμετρή γραμμή.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Επιστρέψτε την τελευταία γραμμή σε στερεό στυλ.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Για να επιστρέψετε σε προεπιλεγμένο στυλ διακεκομμένων, εκχωρήστε το [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) στο [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). Το επιλεγμένο στυλ ελέγχει την εμφάνιση της γραμμής.

Το αποτέλεσμα στο PowerPoint, από πάνω προς κάτω: **{4, 2}, 3 pt**· **{1, 2}, 3 pt**· **{6, 2, 1, 2}, 3 pt**· **{4, 2}, 6 pt**· και **Solid, 3 pt**.

![Τρία προσαρμοσμένα μοτίβα παύλας, μια πιο παχιά γραμμή που χρησιμοποιεί το πρώτο μοτίβο, και μια γεμάτη γραμμή στο PowerPoint](custom-dash-patterns.png)

### **Ορισμός άκρων γραμμής**

Χρησιμοποιήστε [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) για να ορίσετε τα άκρα μιας ανοιχτής γραμμής. Η απαρίθμηση [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) παρέχει τρία ρητά στυλ άκρων:

- `Flat`: Η γραμμή τελειώνει στο άκρο.
- `Round`: Μια ημικυκλική άκρη εκτείνεται πέρα από το άκρο κατά το μισό του πλάτους της γραμμής.
- `Square`: Μια τετράγωνη άκρη εκτείνεται πέρα από το άκρο κατά το μισό του πλάτους της γραμμής.

Η απαρίθμηση περιλαμβάνει επίσης το `NotDefined`, που σημαίνει ότι δεν έχει οριστεί ρητά κάποιο στυλ άκρου.

Οι άκρες διαφέρουν από τα βέλη, που προσθέτουν σύμβολα στα άκρα της γραμμής, και τις συνδέσεις, που ελέγχουν τις γωνίες μεταξύ τμημάτων γραμμής. Αυτό το παράδειγμα απενεργοποιεί τα βέλη μέσω των [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) και [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) ώστε να συγκριθούν μόνο τα σχήματα των άκρων.

Το ακόλουθο παράδειγμα δημιουργεί τρεις οριζόντιες γραμμές, κατά τα άλλα παρόμοιες, πλάτους 20 σημείων. Από πάνω προς κάτω, χρησιμοποιούν επίπεδες, στρογγυλές και τετράγωνες άκρες. Τα άκρα τους έχουν τις ίδιες οριζόντιες συντεταγμένες· οι στρογγυλές και τετράγωνες άκρες επεκτείνονται 10 σημεία πέρα από κάθε άκρο.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα στο PowerPoint, από πάνω προς κάτω: **Flat**, **Round**, και **Square**.

![Επίπεδες, στρογγυλές και τετράγωνες άκρες σε πανομοιότυπες παχιές γραμμές στο PowerPoint](line-caps.png)

## **Εφαρμογή εφέ σκίτσο σε γραμμές σχήματος**

Ένα εφέ σκίτσο κάνει τη γραμμή ενός σχήματος να φαίνεται χειροποίητη. Χρησιμοποιήστε [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) για πρόσβαση στις ρυθμίσεις γραμμής, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) για πρόσβαση στις ρυθμίσεις σκίτσο, και [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) για να επιλέξετε μια τιμή από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας C# δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) , να διαβάσετε την ρητά εκχωρημένη τιμή, και να αφαιρέσετε το εφέ με το [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

Η τιμή που επιστρέφεται από το [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) αντιπροσωπεύει τη ρύθμιση που έχει εκχωρηθεί απευθείας στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληρονομηθεί από ένα θέμα, την κύρια διαφάνεια ή τη διάταξη, χρησιμοποιήστε το [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), προσπελάστε το [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), και διαβάστε το [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Η αποτελεσματική τιμή αντανακλά τη μορφοποίηση που εφαρμόζεται πραγματικά μετά την επίλυση της κληρονομικότητας. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με τουλάχιστον ένα σχήμα στην πρώτη διαφάνεια και εκτυπώνει και τις δύο τιμές:

```csharp
using System;
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

## **Μορφοποίηση στυλ συνδέσεων**

Αυτές είναι οι τρεις επιλογές τύπου σύνδεσης:

* Round
* Miter
* Bevel

Το στυλ σύνδεσης ελέγχει πώς δύο τμήματα περιγράμματος συναντώνται σε μια γωνία. Χρησιμοποιήστε **Round** για στρογγυλεμένες γωνίες, **Miter** για αιχμηρές γωνίες, ή **Bevel** για επίπεδες γωνίες.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Αυτό το παράδειγμα δημιουργεί τρία μαύρα ορθογώνια με μπλε περιγράμματα πλάτους 15 σημείων. Ορίζει το [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) στις τιμές miter, bevel και round της [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/), αντίστοιχα, για να συγκρίνει πώς σχεδιάζονται οι γωνίες.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **Περιορισμός συνδέσεων κόψης σε αιχμηρές γωνίες**

Χρησιμοποιήστε το [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) με το [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) ορισμένο σε [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) για να περιορίσετε το πόσο μακριά μπορεί να εκτείνεται μια αιχμηρή γωνία.

Το όριο είναι ένα λόγο της απόστασης μεταξύ της εσωτερικής και εξωτερικής γωνίας της σύνδεσης προς το πλάτος της γραμμής. Για παράδειγμα, η τιμή `8` επιτρέπει μήκος κόψης μέχρι οκτώ φορές το πλάτος της γραμμής· δεν είναι μέτρηση σε σημεία. Εάν η γωνία υπερβεί το όριο, το PowerPoint χρησιμοποιεί μια κατιστημένη σύνδεση σε εκείνη τη γωνία. Μεγαλύτερο όριο επιτρέπει πιο αιχμηρά σημεία. Η ρύθμιση επηρεάζει μόνο τις συνδέσεις κόψης, και η αλλαγή της δεν έχει οπτικό αποτέλεσμα όταν η γωνία παραμένει εντός των ορίων.

Αυτό το παράδειγμα δημιουργεί δύο πανομοιότυπα, μη γεμισμένα τρίγωνα με περιγράμματα πλάτους 20 σημείων. Το αριστερό τρίγωνο χρησιμοποιεί όριο `2`, και το δεξί `8`. Κάθε τρίγωνο είναι 80 σημείων πλατύ και 160 σημεία ψηλό, δίνοντας στην κορυφαία γωνία του λόγο μήκους κόψης προς πλάτος γραμμής περίπου `4.12`. Συνεπώς, το PowerPoint κατιστούνει την αριστερή άκρη και διατηρεί την δεξιά.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα στο PowerPoint: **Miter limit 2** αριστερά και **miter limit 8** δεξιά.

![Μια κατιστημένη άκρη με όριο κόψης 2 και μια αιχμηρή άκρη με όριο κόψης 8 στο PowerPoint](miter-limits.png)

## **Γέμισμα διαβάθμισης**

Ένα γέμισμα με διαβάθμιση αναμειγνύει χρώματα σε ένα σχήμα. Αυτό το παράδειγμα γεμίζει μια έλλειψη με γραμμική διαβάθμιση υπό γωνία 45 μοιρών από το κόκκινο στο μοβ χρησιμοποιώντας το [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). Η μέθοδος [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) τοποθετεί τα σημεία χρώματος στο 0 και 1, την αρχή και το τέλος της διαβάθμισης. Η εκκαθάριση των υπάρχοντων σημείων εξασφαλίζει ότι χρησιμοποιούνται μόνο αυτά τα δύο χρώματα.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η έλλειψη με γέμισμα διαβάθμισης](gradient-fill.png)

Εάν μια διαβάθμιση φαίνεται διαφορετική σε εξαγόμενο εικόνα από ότι στο PowerPoint, δείτε το [Choose a Gradient Rendering Style](/slides/el/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε ένα στυλ απόδοσης χωρίς να αλλάξετε το γέμισμα διαβάθμισης αποθηκευμένο στην παρουσίαση.

### **Ορισμός γωνίας γραμμικής διαβάθμισης**

Χρησιμοποιήστε το [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) για να ελέγξετε τον προσανατολισμό μιας γέμισης [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/). Η γωνία μετριέται σε μοίρες και αυξάνεται δεξιόστροφα: `0` τρέχει από αριστερά προς δεξιά, `90` από πάνω προς τα κάτω, `180` από δεξιά προς αριστερά, και `270` από κάτω προς τα πάνω. Υποστηρίζονται κλασματικές γωνίες. Πεπερασμένες γωνίες εκτός του `[0, 360)` κανονικοποιούνται σε μία πλήρη περιστροφή· για παράδειγμα, το `-45` γίνεται `315` και το `360` γίνεται `0`.

Αυτό το παράδειγμα δημιουργεί έξι ορθογώνια με τα ίδια σημεία κόκκινου, πράσινου και μπλε στις θέσεις `0`, `0.5` και `1`. Η κλιμάκωση είναι απενεργοποιημένη ώστε η γωνία να συγκρίνεται ανεξάρτητα από τις αναλογίες των ορθογωνίων. Οι γωνίες, από αριστερά προς δεξιά, είναι `0`, `45` και `90` στην πρώτη σειρά, και `135`, `180` και `270` στη δεύτερη σειρά.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα στο PowerPoint:

![Γραμμικές διαβαθμίσεις στις 0, 45 και 90 μοίρες στην επάνω σειρά, και 135, 180 και 270 μοίρες στην κάτω σειρά](linear-gradient-angles.png)

### **Κλιμάκωση γραμμικής διαβάθμισης με το σχήμα**

Το [IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) δέχεται μια τιμή [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/). Ορίστε το ρητά σε `False` για να διατηρήσετε τη γεωμετρική γωνία της διαβάθμισης καθώς αλλάζουν οι αναλογίες του σχήματος, ή σε `True` για να κλιμακώσετε τη διαβάθμιση με το πλάτος και το ύψος του σχήματος. Με ενεργή κλιμάκωση, η ορατή γωνία μπορεί να διαφέρει από την εκχωρημένη γωνία σε σχήμα που δεν είναι τετράγωνο.

Το παρακάτω παράδειγμα χρησιμοποιεί γωνία `45` μοιρών και τα ίδια σημεία χρώματος όπως στην σύγκριση γωνίας. Η αριστερή στήλη χρησιμοποιεί `False`; η δεξιά στήλη χρησιμοποιεί `True`. Κάθε στήλη περιέχει ένα πλατύ ορθογώνιο πάνω από ένα ψηλό ορθογώνιο. Και οι δύο ξεκινούν με τις ίδιες πλατιές διαστάσεις· η αλλαγή του πλάτους και του ύψους του δεύτερου ορθογωνίου δείχνει πώς η γέμιση ανταποκρίνεται στην αλλαγή μεγέθους χωρίς να αλλάζει τις ρυθμίσεις της διαβάθμισης.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα στο PowerPoint, με απενεργοποιημένη κλιμάκωση στα αριστερά και ενεργοποιημένη στα δεξιά:

![Πλατιά και ψηλά ορθογώνια με διαβάθμιση 45 μοιρών, σύγκριση LinearGradientScaled False στα αριστερά με True στα δεξιά](linear-gradient-scaling.png)

Με την κλιμάκωση απενεργοποιημένη, οι διαγώνιες λωρίδες χρώματος διατηρούν την ίδια προσανατολισμό και στα δύο ορθογώνια. Με την κλιμάκωση ενεργοποιημένη, οι λωρίδες τεντώνονται με τις αναλογίες του σχήματος. Αυτό βοηθά στην αναπαραγωγή της διαβάθμισης ενός προτύπου όταν προσαρμόζεται το σχήμα σε διαφορετικό μέγεθος. Σε ένα τετράγωνο, η ενεργοποίηση της κλιμάκωσης δεν αλλάζει την εμφάνιση αυτής της διαβάθμισης `45` μοιρών.

Τanto η γωνία όσο και οι ρυθμίσεις κλιμάκωσης εφαρμόζονται σε γραμμικές διαβάθμιση. Δεν ελέγχουν τις [GradientShape.Radial ή GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **Συνδυασμός γωνίας με κατεύθυνση διαβάθμισης**

Το [IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) επιλέγει στυλ διαβάθμισης από την απαρίθμηση [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/). Δεν αντικαθιστά μια αριθμητική γωνία. Για μια γραμμική διαβάθμιση, τα στυλ γωνιών μπορούν να αλλάξουν την περιοχή όπου διανέμονται τα χρώματα χωρίς να αλλάζουν το [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/). Διατηρήστε την κατεύθυνση αμετάβλητη όταν συγκρίνετε γωνίες ή κλιμάκωση.

Το παρακάτω παράδειγμα εφαρμόζει τις ίδιες ρυθμίσεις σε αντίθετη σειρά. Τα δύο ορθογώνια έχουν την ίδια εμφάνιση: η ανάθεση της κατεύθυνσης πριν ή μετά τη γωνία δεν αλλάζει το αποτέλεσμα.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **Γέμισμα με μοτίβο**

Ένα γέμισμα με μοτίβο εφαρμόζει σχεδίαση δύο χρωμάτων, όπως τελεί, λωρίδες ή σκακιές. Αυτό το παράδειγμα χρησιμοποιεί το [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) για να επιλέξει ένα μοτίβο πλέγματος. Το [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) παρέχει το ανοιχτό γκρι φόντο, και το [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) παρέχει το κίτρινο χρώμα του μοτίβου.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμισμα μοτίβου](pattern-fill.png)

## **Γέμισμα εικόνας**

Ένα γέμισμα εικόνας χρησιμοποιεί μια εικόνα μέσα σε σχήμα. Αυτό το παράδειγμα απαιτεί τοπική εικόνα και χρησιμοποιεί το [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) για να τη φορτώσει στη συλλογή εικόνων της παρουσίασης. Ο ορισμός του [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) σε λειτουργία τύλιγμα επαναλαμβάνει την εικόνα εντός του ορθογωνίου. Η πηγή εικόνας που χρησιμοποιείται εδώ φαίνεται παρακάτω:

![Η εικόνα λωτού](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα εικόνας](picture-fill.png)

### **Τύλιξη εικόνας ως υφή**

Εάν θέλετε να ορίσετε μια τυλιγμένη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά του τυλιγμού, μπορείτε να χρησιμοποιήσετε τις ακόλουθες ιδιότητες της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Ορίζει τη λειτουργία γέμισης εικόνας — είτε `Tile` είτε `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων μέσα στο σχήμα.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Ελέγχει αν το πλακίδιο θα αναστραφεί οριζόντια, κατακόρυφα ή και τα δύο.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από το σημείο προέλευσης του σχήματος.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Ορίζει την κατακόρυφη μετατόπιση του πλακιδίου (σε σημεία) από το σημείο προέλευσης του σχήματος.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Ορίζει την κατακόρυφη κλίμακα του πλακιδίου ως ποσοστό.

Αυτό το παράδειγμα απαιτεί τοπική εικόνα και ρυθμίζει το [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) ώστε να την επαναλαμβάνει στο 50% του αρχικού της μεγέθους. Μετατοπίσεις −32 σημείων μετακινούν τα πλακίδια οριζόντια και κατακόρυφα· η ευθυγράμμιση κάτω δεξιά και η αναστροφή και στις δύο κατευθύνσεις καθορίζουν πώς διατάσσεται η επαναλαμβανόμενη υφή.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Οι επιλογές τυλιγμού](tile-options.png)

## **Συμπλήρωση στερεού χρώματος**

Ένα στερεό γέμισμα δίνει σε ένα σχήμα ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το παράδειγμα ορίζει το [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) στη λειτουργία στερεού γεμίσματος και εκχωρεί κίτρινο μέσω του [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/), έπειτα αποθηκεύει το ορθογώνιο σε παρουσίαση.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το σχήμα με στερεό χρώμα γέμισης](solid-color-fill.png)

### **Αντιγραφή χρωμάτων διατηρώντας τις αναφορές θέματος**

Χρησιμοποιήστε το [IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) για να αντιγράψετε έναν ορισμό χρώματος, συμπεριλαμβανομένου του τύπου χρώματος, της αναφοράς θέματος και των μετασχηματισμών. Αυτό είναι χρήσιμο όταν μεταφέρετε ένα χρώμα γέμισματος μεταξύ σχημάτων που πρέπει να συνεχίσουν να ακολουθούν το θέμα της παρουσίασης. Η μέθοδος αντιγράφει μόνο το χρώμα: δεν αντιγράφει τον τύπο γέμισματος, το περίγραμμα ή άλλες μορφοποιήσεις σχήματος. Ορίστε ρητά το [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) του προορισμού.

Αυτό το παράδειγμα δημιουργεί τρία ορθογώνια, από αριστερά προς δεξιά: την πηγή, ένα αντίγραφο που λαμβάνει υπόψη το θέμα, και ένα σταθερό RGB αντίγραφο. Η πηγή χρησιμοποιεί το [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) για να αναφερθεί στο πρώτο χρώμα έμφασης και προσθέτει απόχρωση μέσω του [IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/). Το RGB αντίγραφο χρησιμοποιεί το αποτελεσματικό χρώμα γέμισμα της πηγής, ώστε όλα τα τρία αρχικά να φαίνονται τα ίδια. Η εκχώρηση του [IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) ορίζει σταθερή τιμή RGB και καθαρίζει τυχόν υπάρχουσες μετασχηματισμούς χρώματος.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// Theme references follow the new accent color; the fixed RGB value does not.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

Πριν την αλλαγή θέματος, όλα τα τρία γέμισμα ταιριάζουν:

![Πηγή, προορισμός CopyFrom και σταθερός RGB προορισμός με ταυτόσημα μπλε γέμισμα](color-copy-before.png)

Μετά την αλλαγή θέματος, η πηγή και το αντίγραφο που λαμβάνει υπόψη το θέμα ακολουθούν το νέο χρώμα έμφασης και διατηρούν την απόχρωσή τους. Το σταθερό RGB αντίγραφο παραμένει μπλε:

![Πηγή και προορισμός CopyFrom με πορτοκαλί γέμισμα, ενώ ο σταθερός RGB προορισμός παραμένει μπλε](color-copy-after.png)

Ο αντίγραφος ορισμός είναι ανεξάρτητος από την πηγή. Η μεταγενέστερη αλλαγή της αναφοράς θέματος της πηγής, η εκχώρηση άλλου χρώματος ή η προσθήκη/αφαίρεση των μετασχηματισμών της δεν αλλάζει τον προορισμό. Μια αλλαγή θέματος εξακολουθεί να επηρεάζει και τα δύο σχήματα επειδή κάθε ένα αναφέρεται ανεξάρτητα στο ίδιο χρώμα θέματος.

Η αποθήκευση και επαναφόρτωση του PPTX διατηρεί την [IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/), την αναφορά θέματος και τη συλλογή [IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/) του αντιγραμένου χρώματος· δεν μετατρέπει τον ορισμό σε RGB.

Κατά την αντιγραφή μεταξύ διαφορετικών συμφραζομένων θέματος, όπως παρουσιάσεις με διαφορετικές παλέτες έμφασης, η αντιγραμμένη αναφορά επιλύεται με βάση το θέμα του προορισμού. Η ίδια αναφορά και οι μετασχηματισμοί μπορούν έτσι να παράγουν διαφορετικό ορατό χρώμα. Δείτε το [Presentation Theme](/slides/el/net/presentation-theme/) για περισσότερα σχετικά με τη διαμόρφωση των χρωμάτων θέματος.

## **Χρήση του φόντου διαφάνειας ως γέμισμα σχήματος**

Χρησιμοποιήστε το [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) όταν ένα σχήμα πρέπει να ταιριάζει με το φόντο της διαφάνειας, για παράδειγμα σε πρότυπο παρουσίασης. Ορίστε το [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) στο [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) πρώτα για να αφαιρέσετε τυχόν ρητό γέμισμα. Με αυτόν τον συνδυασμό, το σχήμα χρησιμοποιεί το φόντο της διαφάνειας αντί για το γέμισμα του στιλ του. Η ενεργοποίηση της σημαίας μόνη δεν αφαιρεί υπάρχον ρητό γέμισμα.

Αυτό διαφέρει από το [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): το γέμισμα φόντου καλύπτει αντικείμενα πίσω από το σχήμα με την αντίστοιχη περιοχή του φόντου της διαφάνειας, ενώ το NoFill αφήνει αυτά τα αντικείμενα εμφανή. Μια διαβάθμιση παραμένει ευθυγραμμισμένη με τη διαφάνεια αντί να ξεκινά ξανά εντός κάθε σχήματος.

Το παρακάτω παράδειγμα δημιουργεί ένα φόντο master που κληρονομείται από τη διαφάνεια και τοποθετεί μια μαγέτσα ταινία πίσω από τρία ορθογώνια. Το αριστερό ορθογώνιο χρησιμοποιεί το φόντο, το μεσαίο δεν έχει γέμισμα, και το δεξί αλλάζει από γέμισμα φόντου σε ρητό πορτοκαλί γέμισμα.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// Κληρονόμηση της διαβάθμισης από το master.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// Προσθέστε αυτό το αντικείμενο πρώτα ώστε να εμφανίζεται πίσω από τα ορθογώνια.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// Απενεργοποιήστε το γέμισμα φόντου πριν εφαρμόσετε ρητό γέμισμα.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα, από αριστερά προς δεξιά: **background fill**, **no fill**, και **explicit fill**. Η μαγέτσα ταινία κρύβεται από τα αριστερά και δεξιά ορθογώνια, αλλά παραμένει ορατή μέσω του μεσαίου ορθογώνιου.

![Γέμισμα φόντου, χωρίς γέμισμα και ρητό πορτοκαλί γέμισμα πάνω σε μαγέτσα ταινία](background-fill.png)

Η ίδια συμπεριφορά ισχύει για φόντο που ορίζεται απευθείας στη διαφάνεια ή κληρονομείται από διάταξη. Το σχήμα χρησιμοποιεί το επεξεργασμένο φόντο της διαφάνειας· το παράδειγμα αφήνει τα φόντα της διαφάνειας και της διάταξης ακαθόριστα ώστε το master να το παρέχει.

## **Ορισμός διαφάνειας**

Για ένα στερεό γέμισμα, το άλφα του χρώματος ελέγχει τη διαφάνεια: 0 είναι πλήρως διαφανές και 255 πλήρως αδιαφανές. Αυτό το παράδειγμα χρησιμοποιεί τιμή άλφα 128 για ένα κίτρινο ορθογώνιο, καθιστώντας το περίπου 50 % διαφανές ώστε το ορθογώνιο από κάτω να παραμένει ορατό. Το χρώμα εκχωρείται μέσω του [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή σχημάτων**

Χρησιμοποιήστε το [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) για να περιστρέψετε ένα σχήμα στο επίπεδο της διαφάνειας. Η γωνία μετριέται σε μοίρες· αυτό το παράδειγμα περιστρέφει ένα ορθογώνιο 5 μοίρες δεξιόστροφα και αποθηκεύει την παρουσίαση.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3Δ εφέ bevel**

Χρησιμοποιήστε το [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) για να δώσετε σε ένα σχήμα βάθος και καμπυλωτές άκρες. Αυτό το παράδειγμα δημιουργεί μια πράσινη έλλειψη με πορτοκαλί περίγραμμα, ορίζει το [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) σε 4 σημεία, και εφαρμόζει έναν κυκλικό άνω bevel με πλάτος και ύψος 6 σημείων μέσω του [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). Μια κάμερα προοπτικής με πρόσωπο προς το προάστιο και τριπλή φωτισμός κάνουν το bevel ορατό.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το 3D εφέ bevel](3D-bevel-effect.png)

## **Προσθήκη 3Δ εφέ περιστροφής**

Η 3Δ προβολή ενός σχήματος ελέγχεται από τις ρυθμίσεις της κάμερας του. Αυτό το παράδειγμα χρησιμοποιεί το [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) με γωνίες γεωγραφικού πλάτους, μήκους και επανάληψης 40, 35 και 20 μοίρες, αντίστοιχα. Επιλέγει μια ισομετρική κάμερα μέσω του [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) και ισορροπημένο φωτισμό μέσω του [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), έπειτα αποθηκεύει το μορφοποιημένο ορθογώνιο.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το 3D εφέ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος απόδοσης ασπρόμαυρου για σχήματα**

Η ιδιότητα [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) καθορίζει πώς αποδίδεται ένα μεμονωμένο σχήμα όταν μια παρουσίαση προβάλλεται ή επεξεργάζεται σε ασπρόμαυρη λειτουργία. Δεν ενεργοποιεί την ασπρόμαυρη προβολή από μόνη της και δεν αλλάζει το γέμισμα, τη γραμμή ή άλλες μορφοποιήσεις του σχήματος σε κανονική λειτουργία χρώματος.

Χρησιμοποιήστε μια τιμή από την απαρίθμηση [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) για να επιλέξετε την επιθυμητή συμπεριφορά. Για παράδειγμα, το `Automatic` αφήνει την εφαρμογή απόδοσης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκρι χρώμα, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, τα `Black` και `White` επιβάλλουν ένα μοναδικό χρώμα, το `Color` διατηρεί το κανονικό χρώμα, και το `Hidden` παραλείπει το σχήμα σε ασπρόμαυρη λειτουργία. Το `NotDefined` σημαίνει ότι δεν έχει εκχωρηθεί λειτουργία επιπέδου σχήματος.

Αυτό το παράδειγμα δημιουργεί ένα πορτοκαλί ορθογώνιο και ορίζει το [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) σε γκρι. Το αποθηκευμένο σχήμα διατηρεί το πορτοκαλί γέμισμα για κανονική προβολή χρώματος και ζητά γκρι χρωματισμό από εφαρμογές που σέβονται τις ρυθμίσεις ασπρόμαυρης προβολής:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Σε κανονική λειτουργία χρώματος, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμα. Σε μια διαδικασία εμφάνισης ασπρόμαυρου, χρησιμοποιεί γκρι χρωματισμό επειδή η λειτουργία του έχει οριστεί σε `Gray`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρως έγχρωμη διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες διαδικασίες που σέβονται τις ρυθμίσεις ασπρόμαυρης προβολής της παρουσίασης.

## **Επαναφορά μορφοποίησης**

Χρησιμοποιήστε το [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) για να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση των δεσμευτικών θέσεων της διαφάνειας από τις αντίστοιχες δεσμευτικές θέσεις της διάταξης. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με δεσμευτικές θέσεις συνδεδεμένες σε διάταξη και επαναφέρει κάθε διαφάνεια πριν από την αποθήκευση. Τα σχήματα χωρίς αντίστοιχες δεσμευτικές θέσεις διάταξης δεν επαναφέρονται.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση των σχημάτων το τελικό μέγεθος του αρχείου παρουσίασης;**

Τα χρώματα, τα στυλ γραμμής και οι ρυθμίσεις εφέ προσθέτουν γενικά λίγα δεδομένα σε σύγκριση με τις ενσωματωμένες εικόνες και πολυμέσα. Τα γέμισματα εικόνας μπορούν να αυξήσουν το μέγεθος του αρχείου επειδή οι εικόνες τους αποθηκεύονται στην παρουσίαση.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που έχουν την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος — γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ τους ως ταυτόσημα και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη μετέπειθεν διαχείριση στυλ.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα σετ διαφανειών προτύπου ή σε αρχείο .POTX. Κατά τη δημιουργία νέας παρουσίασης, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλιζαρισμένα σχήματα που χρειάζεστε και εφαρμόστε ξανά τη μορφοποίησή τους όπου απαιτείται.
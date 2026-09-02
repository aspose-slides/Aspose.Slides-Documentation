---
title: Διαχείριση Θεμάτων Παρουσίασης σε .NET
linktitle: Θέμα Παρουσίασης
type: docs
weight: 10
url: /el/net/presentation-theme/
keywords:
- Θέμα PowerPoint
- Θέμα παρουσίασης
- Θέμα διαφάνειας
- Ορισμός θέματος
- Αλλαγή θέματος
- Διαχείριση θέματος
- Χρώμα θέματος
- Επιπλέον παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης σε Aspose.Slides για .NET για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή επωνυμία."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ υποβάθρου, γεμίσματος, γραμμών και εφέ. Τα αντικείμενα που είναι ευαίσθητα στο θέμα αναφέρονται σε αυτές τις κοινές ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, έτσι μια αλλαγή θέματος μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι διαθέσιμο μέσω της ιδιότητας [Presentation.MasterTheme](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/mastertheme/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας κύριος (master) μπορεί να παρακάμψει το θέμα παρουσίασης μέσω του [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/masterthememanager/overridetheme/), μια διάταξη μπορεί να παρακάμψει το κληρονομημένο θέμα μέσω του [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), και μια μεμονωμένη διαφάνεια μπορεί να κάνει το ίδιο. Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παράκαμψη master, παράκαμψη διάταξης και παράκαμψη διαφάνειας.

![Στοιχεία θέματος: χρώματα, γραμματοσειρές, στυλ υποβάθρου και εφέ](theme-constituents.png)

Τα παρακάτω τμήματα δείχνουν τις πιο συνηθισμένες ροές εργασίας με το θέμα: έλεγχος ενός θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ υποβάθρου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την κληρονομικότητα και τις παρακάμψεις.

## **Έλεγχος Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/mastertheme/) εκθέτει το [ColorScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/mastertheme/colorscheme/), το [FontScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/mastertheme/fontscheme/) και το [FormatScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/mastertheme/formatscheme/) του θέματος. Ο έλεγχος αυτών των συλλογών πριν από την αλλαγή τους είναι ιδιαίτερα χρήσιμος όταν μια παρουσίαση προέρχεται από εξωτερική πηγή, καθώς ο αριθμός και το περιεχόμενο των καταχωρήσεων στυλ μπορεί να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και εμφανίζει πόσες καταχωρήσεις στυλ υποβάθρου, γεμίσματος, γραμμής και εφέ αποθηκεύονται στο θέμα:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Αν ένα αρχείο χρησιμοποιεί πολλαπλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Ελέγξτε τον master που συνδέεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού‑θέματος που φαίνεται αργότερα σε αυτό το άρθρο όταν μπορεί να υπάρχει παράκαμψη διάταξης ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που είναι ευαίσθητα στο θέμα μπορούν να αναφέρονται σε ένα λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/net/aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώρηση στο [IColorScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/icolorscheme/) του θέματος, όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε αυτό το χρώμα θέματος επιλύονται με τη νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με μια ενημέρωση χρώματος θέματος.

Το παρακάτω παράδειγμα από‑α‑τέλος δημιουργεί ένα σχήμα που χρησιμοποιεί `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Αν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, οι μεταγενέστερες αλλαγές στο `Accent4` δεν θα επηρεάσουν πια αυτό το γέμισμα.

### **Χρήση Χρωμάτων από την Επιπλέον Παλέτα**

Το PowerPoint παράγει ανοιχτές και σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω του [ColorTransformOperation](https://reference.aspose.com/slides/el/net/aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και ανοιχτές και σκούρες χρωματικές παραλλαγές που δημιουργούνται από την επιπλέον παλέτα](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος.

**2** - Ανοιχτές και σκούρες παραλλαγές που προέρχονται από τα κύρια χρώματα θέματος.

Το παρακάτω παράδειγμα δημιουργεί έξι ορθογώνια βασισμένα στο `Accent4`, εφαρμόζει μετασχηματισμούς φωτεινότητας σε πέντε από αυτά και αποθηκεύει το αποτέλεσμα:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Αν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα υπολογίζονται εκ νέου από τη νέα τιμή του `Accent4`.

### **Αντιστοίχιση Τιμών `SchemeColor` στις Θέσεις του `IColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/net/aspose.slides/schemecolor/) χρησιμοποιεί `Text1`, `Background1`, `Text2` και `Background2`, ενώ το [IColorScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/icolorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχιση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν είναι τιμές που μετατρέπονται δυναμικά από τη μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιέχει ένα κύριο σύνολο γραμματοσειρών για κεφαλίδες και ένα δευτερεύον σύνολο για το κυρίως κείμενο. Οι ιδιότητες [FontScheme.Major](https://reference.aspose.com/slides/el/net/aspose.slides.theme/fontscheme/major/) και [FontScheme.Minor](https://reference.aspose.com/slides/el/net/aspose.slides.theme/fontscheme/minor/) εκθέτουν αυτά τα σύνολα.

Οι αναγνωριστές γραμματοσειρών θέματος συμβατοί με το PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn-lt` - Γραμματοσειρά Κυρίως Κειμένου Λατινική (Minor Latin Font)
* `+mj-lt` - Γραμματοσειρά Κεφαλίδας Λατινική (Major Latin Font)
* `+mn-ea` - Γραμματοσειρά Κυρίως Κειμένου Ανατολική Ασιά (Minor East Asian Font)
* `+mj-ea` - Γραμματοσειρά Κεφαλίδας Ανατολική Ασιά (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί μια κεφαλίδα που χρησιμοποιεί τη κύρια λατινική γραμματοσειρά θέματος και μια γραμμή κυρίως κειμένου που χρησιμοποιεί τη δευτερεύουσα λατινική γραμματοσειρά θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

Η κεφαλίδα ακολουθεί τη μεγάλη γραμματοσειρά και το κυρίως κείμενο τη μικρή. Κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για ταυτοποιητή θέματος δεν θα αλλάξει αυτόματα όταν αλλάξει το σχήμα γραμματοσειρών θέματος.

Οι συλλογές μεγάλων και μικρών γραμματοσειρών μπορούν επίσης να περιέχουν αντιστοιχίσεις γραμματοσειρών για επιμέρους συστήματα γραφής, όπως κυριλλική, αραβική, ιαπωνική, γεωργιανή και θάνα. Για έλεγχο, προσθήκη, αντικατάσταση ή αφαίρεση αυτών των αντιστοιχίσεων, δείτε την ενότητα [Script-Specific Theme Fonts](/slides/el/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε το [PowerPoint Fonts](/slides/el/net/powerpoint-fonts/).
{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Υπάρχουν δύο συνηθισμένες ροές εργασίας, και λύνουν διαφορετικά προβλήματα.

### **Διατήρηση Πρωταρχικού Θέματος Κατά τη Μετακίνηση Διαφανειών**

Αν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε τον πηγαίο master στη στόχευση παρουσίαση με την μέθοδο [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection/addclone/), έπειτα κλωνοποιήστε τη διαφάνεια με την [ISlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) και τον κλωνοποιημένο master. Έτσι μεταφέρονται μαζί ο master, οι διατάξεις του και το σχετικό θέμα.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

Αυτή είναι η προτιμώμενη ροή όταν η πηγαία διαφάνεια πρέπει να φαίνεται η ίδια στον προορισμό. Η απλή κλωνοποίηση περιεχομένου πάνω σε έναν μη συσχετισμένο master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, υποβάθρα και εφέ που οδηγούν από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υφιστάμενη Διαφάνεια**

Αν η διαφάνεια-στόχος πρέπει να παραμείνει στον τρέχοντα master και διάταξη, αρχικοποιήστε μια παραμετροποίηση στο επίπεδο διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/el/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/el/net/aspose.slides.theme/overridetheme/initfontschemefrom/) και [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/el/net/aspose.slides.theme/overridetheme/initformatschemefrom/) αντιγράφουν τα τρία κύρια στοιχεία του θέματος στην παράκαμψη.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

Αυτό αλλάζει το θέμα που χρησιμοποιείται από τη συγκεκριμένη διαφάνεια χωρίς να επηρεάζει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παράκαμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.Clear](https://reference.aspose.com/slides/el/net/aspose.slides.theme/overridetheme/clear/).

### **Εφαρμογή Παράκαμψης Θέματος σε Διάταξη**

Μια παράκαμψη στο επίπεδο διάταξης εφαρμόζεται στις διαφάνειες που χρησιμοποιούν αυτή τη διάταξη, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παράκαμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/net/aspose.slides.theme/layoutslidethememanager/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Χρησιμοποιήστε ένα θέμα σε επίπεδο master ή παρουσίαση όταν πολλά layout και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παράκαμψη διάταξης όταν μια οικογένεια διατάξεων χρειάζεται διαφορετικό στυλ, και μια παράκαμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Πάρα πολλές παρακάμψεις σε επίπεδο διαφάνειας κάνουν τις παγκόσμιες αλλαγές θέματος πιο δύσκολες στην πρόβλεψη.

## **Ενημέρωση Στυλ Υποβάθρου Θέματος**

Τα γεμίσματα υποβάθρου του θέματος αποθηκεύονται στο [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές υποβάθρου στο UI του από ό,τι αριθμούν οι πραγματικές ορισμοί γεμίσματος που αποθηκεύονται σε αυτή τη συλλογή, επειδή το UI μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ υποβάθρου PowerPoint για θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ υποβάθρου, ελέγξτε τη αποθηκευμένη συλλογή και το τρέχον [Background.StyleIndex](https://reference.aspose.com/slides/el/net/aspose.slides/background/styleindex/). Το `StyleIndex` χρησιμοποιεί `0` για κανένα θέμα‑γεμίσμα· οι θετικές τιμές είναι αναφορές σε στυλ υποβάθρου θέματος. Αυτό διαφέρει από την απευθείας δεικτοδότηση της συλλογής .NET, όπου το `[0]` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ γεμίσματος υποβάθρου.

Το παρακάτω παράδειγμα αναφέρει τον αριθμό διαθέσιμων γεμισμάτων υποβάθρου, εκχωρεί μια αναφορά θέματος‑υποβάθρου στον πρώτο master και αποθηκεύει την παρουσίαση:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

Το ορατό αποτέλεσμα εξαρτάται από την καταχώρηση θέματος που αναφέρεται από τον master και από τυχόν παρακάμψεις υποβάθρου στη διάταξη ή τη διαφάνεια. Αν μια διαφάνεια χρησιμοποιεί το δικό της υπόβαθρο, η αλλαγή μόνο του υποβάθρου του master μπορεί να μην αλλάξει αυτή τη διαφάνεια. Χρησιμοποιήστε το [Background.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/background/geteffective/) όταν χρειάζεστε την τελική εικόνα υποβάθρου μετά την εφαρμογή κληρονομικότητας.

{{% alert color="warning" title="Warning" %}}
Μη θεωρείτε το `StyleIndex` ως δείκτη μηδενικής βάσης. Επίσης, αποφύγετε την σκληρή κωδικοποίηση αριθμού στυλ από ένα αρχείο και την υπόθεση ότι θα έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Για άμεση μορφοποίηση υποβάθρου και κληρονομικότητα υποβάθρου, δείτε το [Presentation Background](/slides/el/net/presentation-background/).
{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιλαμβάνει ξεχωριστές συλλογές [FillStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/linestyles/) και [EffectStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/effectstyles/). Τα τυπικά θέματα Office συχνά περιέχουν τρεις κύριες καταχωρήσεις στυλ που αντιστοιχούν οπτικά σε διακριτά, μετριασμένα και έντονα στυλ, αλλά ο κώδικας πρέπει να ελέγχει κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Διακριτά, μετριασμένα και έντονα εφέ θέματος που εφαρμόζονται στο ίδιο σχήμα](presentation-design_10.png)

Όταν προσπελάζετε αυτές τις συλλογές σε C#, ο δείκτης συλλογής είναι μηδενική βάση: `[0]` είναι το πρώτο αποθηκευμένο στυλ και `[2]` το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, εκτεθειμένη μέσω του [IShapeStyle](https://reference.aspose.com/slides/el/net/aspose.slides/ishapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που το αναφέρουν· τα σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει αν υπάρχουν οι απαιτούμενες καταχωρήσεις στυλ, αλλάζει το πρώτο στυλ γραμμής, το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ και αποθηκεύει το αποτέλεσμα:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής του θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος του θέματος γίνεται εντελώς σκούρο πράσινο δάσους, και το τρίτο στυλ εφέ προσθέτει εξωτερική σκιά με απόσταση 10 σημείων. Το ακριβές οπτικό αποτέλεσμα εξακολουθεί να εξαρτάται από το ποια θέσεις στυλ αναφέρει κάθε σχήμα και αν η άμεση μορφοποίηση υπερισχύει του θέματος.

![Στυλ εφέ θέματος μετά την αλλαγή ρυθμίσεων γραμμής, γεμίσματος και σκιάς](presentation-design_11.png)

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος σας λένε τι ορίζεται σε συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί πραγματικά μια διαφάνεια ή σχήμα μετά την κληρονομικότητα και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/el/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Για υποβάθρο, χρησιμοποιήστε το [Background.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/background/geteffective/), και για γέμισμα, το [FillFormat.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/geteffective/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το υπόβαθρο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Χρησιμοποιήστε αποτελεσματικά δεδομένα για διαγνωστικά, επαλήθευση και συγκρίσεις. Αν ελέγχετε μόνο το [Presentation.MasterTheme](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/mastertheme/), μπορεί να παραβλέψετε μια παράκαμψη master, διάταξης, διαφάνειας ή σχήματος που αλλάζει το τελικό αποτέλεσμα.

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω ένα θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/el/net/aspose.slides.theme/slidethememanager/) της διαφάνειας και αρχικοποιήστε την παράκαμψη θέματος. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα.

**Ποιος είναι ο ασφαλέστερος τρόπος για να μεταφέρω ένα θέμα από μία παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της αρχικής της εμφάνισης, κλωνοποιήστε τον πηγαίο master στον προορισμό και κλωνοποιήστε τη διαφάνεια με αυτόν το master χρησιμοποιώντας τις μεθόδους [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection/addclone/) και [ISlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/). Αυτό κρατάει μαζί τον master, τις διατάξεις και το θέμα.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομικότητα και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/el/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) για θέμα διαφάνειας ή διάταξης και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/background/geteffective/) και το [FillFormat.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/geteffective/). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την εφαρμογή κληρονομικότητας και παρακάμψεων.
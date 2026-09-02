---
title: Διαχείριση Θεμάτων Παρουσίασης στο .NET
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
- Εξωτερικό θέμα
- THMX
- Χρώμα θέματος
- Πρόσθετη παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για .NET για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή επωνυμία."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ φόντου, γεμισμάτων, γραμμών και εφέ. Τα αντικείμενα που είναι ευαίσθητα στο θέμα αναφέρονται σε αυτούς τους κοινά ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως στατική τιμή, ώστε μια αλλαγή θέματος να μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι διαθέσιμο μέσω της ιδιότητας [Presentation.MasterTheme](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/mastertheme/). Μια παρουσίαση μπορεί επίσης να περιλαμβάνει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα της παρουσίασης μέσω του [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/masterthememanager/overridetheme/), ένα layout μπορεί να παρακάμψει το κληρονομημένο θέμα μέσω του [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), και μια μεμονωμένη διαφάνεια μπορεί να κάνει το ίδιο. Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παράκαμψη master, παράκαμψη layout και παράκαμψη διαφάνειας.

![Στοιχεία θέματος: χρώματα, γραμματοσειρές, στυλ φόντου και εφέ](theme-constituents.png)

Οι παρακάτω ενότητες δείχνουν τις πιο κοινές ροές εργασίας με τα θέματα: επιθεώρηση θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ φόντου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την κληρονομικότητα και τις παρακάμψεις.

## **Επιθεώρηση Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/mastertheme/) αποκαλύπτει το [ColorScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/mastertheme/colorscheme/), το [FontScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/mastertheme/fontscheme/) και το [FormatScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/mastertheme/formatscheme/) του θέματος. Η επιθεώρηση αυτών των συλλογών πριν από τις αλλαγές είναι ιδιαίτερα χρήσιμη όταν η παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των καταχωρίσεων στυλ μπορεί να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ φόντου, γεμίσματος, γραμμής και εφέ αποθηκεύονται στο θέμα:

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

Αν ένα αρχείο χρησιμοποιεί πολλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Επιθεωρήστε τον master που σχετίζεται με τη διαφάνειά σας και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού‑θέματος που φαίνεται αργότερα στο άρθρο όταν μπορεί να υπάρξουν παρακάμψεις layout ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που είναι ευαίσθητα στο θέμα μπορούν να αναφέρονται σε λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/net/aspose.slides/schemecolor/). Όταν αλλάξετε την αντίστοιχη καταχώριση στο [IColorScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/icolorscheme/) του θέματος, όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε αυτό το χρώμα θέματος επιλύονται με τη νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με την ενημέρωση του χρώματος θέματος.

Το παρακάτω ολοκληρωμένο παράδειγμα δημιουργεί ένα σχήμα που χρησιμοποιεί `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

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

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Αν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, μεταγενέστερες αλλαγές στο `Accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από το Πρόσθετο Παλέτα**

Το PowerPoint παράγει πιο ανοιχτές και πιο σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω του [ColorTransformOperation](https://reference.aspose.com/slides/el/net/aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και πιο ανοιχτά και πιο σκούρα χρώματα που παράγονται από το πρόσθετο παλέτα](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος.

**2** - Πιο ανοιχτές και πιο σκούρες παραλλαγές που προέρχονται από τα κύρια χρώματα θέματος.

Το παρακάτω παράδειγμα δημιουργεί έξι ορθογώνια βάσει του `Accent4`, εφαρμόζει μετασχηματισμούς φωτεινότητας σε πέντε από αυτά και αποθηκεύει το αποτέλεσμα:

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

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Εάν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα επανυπολογίζονται από τη νέα τιμή του `Accent4`.

### **Αντιστοίχιση Τιμών `SchemeColor` σε Θέσεις `IColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/net/aspose.slides/schemecolor/) χρησιμοποιεί `Text1`, `Background1`, `Text2` και `Background2`, ενώ το [IColorScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/icolorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχιση είναι στατική:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν είναι τιμές που μετατρέπονται δυναμικά από τη μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιλαμβάνει ένα κύριο σύνολο γραμματοσειρών για επικεφαλίδες και ένα δευτερεύον σύνολο για το κυρίως κείμενο. Οι ιδιότητες [FontScheme.Major](https://reference.aspose.com/slides/el/net/aspose.slides.theme/fontscheme/major/) και [FontScheme.Minor](https://reference.aspose.com/slides/el/net/aspose.slides.theme/fontscheme/minor/) εκθέτουν αυτά τα σύνολα.

Οι ταυτότητες γραμματοσειρών θεμάτων συμβατών με PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn‑lt` - Γραμματοσειρά σώματος Latin (Minor Latin Font)
* `+mj‑lt` - Γραμματοσειρά επικεφαλίδας Latin (Major Latin Font)
* `+mn‑ea` - Γραμματοσειρά σώματος East Asian (Minor East Asian Font)
* `+mj‑ea` - Γραμματοσειρά επικεφαλίδας East Asian (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί μία επικεφαλίδα που χρησιμοποιεί τη μεγαλύτερη γραμματοσειρά Latin του θέματος και μία γραμμή κειμένου που χρησιμοποιεί τη μικρότερη γραμματοσειρά Latin. Στη συνέχεια αλλάζει τις γραμματοσειρές του θέματος και αποθηκεύει το αποτέλεσμα:

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

Η επικεφαλίδα ακολουθεί τη μεγάλη γραμματοσειρά και το κυρίως κείμενο ακολουθεί τη μικρή γραμματοσειρά. Το κείμενο που έχει explicit όνομα γραμματοσειράς αντί για αναγνωριστικό θέματος δεν θα αλλάξει αυτόματα όταν το σχήμα γραμματοσειρών θέματος αλλάξει.

Οι συλλογές κύριας και δευτέρας γραμματοσειράς μπορούν επίσης να περιλαμβάνουν αντιστοιχίες γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως κυριλλικά, αραβικά, ιαπωνικά, γεωργιανά και θανά. Για επιθεώρηση, προσθήκη, αντικατάσταση ή αφαίρεση αυτών των αντιστοιχιών, δείτε [Script‑Specific Theme Fonts](/slides/el/net/script-specific-font-mappings/).

{{% alert color="info" title="Συμβουλή" %}}
Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε τις [Γραμματοσειρές PowerPoint](/slides/el/net/powerpoint-fonts/).
{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Οι παρακάτω ροές εργασίας λύνουν διαφορετικά προβλήματα σχετικά με το θέμα.

### **Εφαρμογή Εξωτερικού Θέματος σε Διαφάνειες που Εξαρτώνται από Master**

Χρησιμοποιήστε το [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) όταν έχετε ένα αρχείο θέματος PowerPoint (`.thmx`) και θέλετε να επανασχεδιάσετε κάθε διαφάνεια που εξαρτάται από έναν συγκεκριμένο master. Επιλέξτε τον master από τη συλλογή [Presentation.Masters](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/masters/), η οποία υλοποιεί το [IMasterSlideCollection](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection/), και περάστε τη διαδρομή του αρχείου θέματος στη μέθοδο.

Η μέθοδος εκτελεί τις ακόλουθες ενέργειες:

1. Δημιουργεί μια νέα διαφάνεια master βασισμένη στον επιλεγμένο master.
1. Εφαρμόζει το εξωτερικό θέμα στη νέα διαφάνεια master.
1. Αναθέτει τη νέα διαφάνεια master σε όλες τις διαφάνειες που προηγουμένως εξαρτώνταν από τον επιλεγμένο master.
1. Επιστρέφει το νεοδημιουργημένο [IMasterSlide](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/).

Το παρακάτω παράδειγμα εφαρμόζει ένα εξωτερικό θέμα στις διαφάνειες που εξαρτώνται από τον πρώτο master, αποθηκεύει την παρουσίαση και ανοίγει ξανά το αποτέλεσμα:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Ένα μη έγκυρο, κατεστραμμένο ή μη υποστηριζόμενο θέμα μπορεί να προκαλέσει [PptxException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxexception/) ή μία από τις υποκατηγορίες του που σχετίζονται με μορφή. Επικυρώστε τις διαδρομές που παρέχονται από τους χρήστες, διαχειριστείτε αποτυχίες πρόσβασης στο σύστημα αρχείων και αποθηκεύστε την παρουσίαση μόνο αφού το θέμα έχει εφαρμοστεί επιτυχώς.

Μόνο οι διαφάνειες που εξαρτώνταν από τον επιλεγμένο master αντιστοιχίζονται εκ νέου. Οι διαφάνειες που σχετίζονται με άλλους masters διατηρούν τους υπάρχοντες masters και θέματα τους. Τα χρώματα, οι γραμματοσειρές, τα γεμίσματα, οι γραμμές, τα φόντα και τα εφέ που είναι ευαίσθητα στο θέμα επιλύονται με βάση το εξωτερικό θέμα. Τα χρώματα, οι γραμματοσειρές, τα γεμίσματα και άλλες άμεσες μορφοποιήσεις που έχουν εκχωρηθεί ρητά μπορεί να παραμείνουν αμετάβλητα. Οι παρακάμψεις σε επίπεδο layout και διαφάνειας μπορούν επίσης να έχουν προτεραιότητα έναντι των τιμών που κληρονομούνται από το νέο master.

Το θέμα μπορεί να αναφερθεί σε γραμματοσειρές που δεν είναι διαθέσιμες στο περιβάλλον εκτέλεσης. Για συνεπή απόδοση και εξαγωγή, εγκαταστήστε τις απαιτούμενες γραμματοσειρές, προσφέρετέ τις μέσω [προσαρμοσμένων πηγών γραμματοσειρών](/slides/el/net/custom-font/), ή ρυθμίστε την [αντικατάσταση γραμματοσειρών](/slides/el/net/font-substitution/).

Αυτή είναι μια άμεση ροή εργασίας επιπέδου master: η μέθοδος δέχεται διαδρομή αρχείου `.thmx` και δεν απαιτεί τη δημιουργία παρακάμψεων θέματος σε επίπεδο διαφάνειας ή layout με μη αυτόματο τρόπο.

### **Εφαρμογή Διαφορετικών Εξωτερικών Θεμάτων σε Παρουσίαση με Πολλούς Masters**

Όταν ο σχετικός master δεν είναι γνωστός εκ των προτέρων, αποκτήστε τον από μια αντιπροσωπευτική διαφάνεια μέσω του [ISlide.LayoutSlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/layoutslide/) και του [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/masterslide/). Αποθηκεύστε τις αρχικές αναφορές master πριν εφαρμόσετε οποιαδήποτε θέματα, επειδή κάθε κλήση δημιουργεί έναν νέο master στην παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί διαφάνειες από δύο ενότητες για να εντοπίσει τους masters τους και εφαρμόζει διαφορετικό εξωτερικό θέμα σε κάθε ομάδα:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

Η πρώτη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνταν από το `firstGroupMaster`, και η δεύτερη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνται από το `secondGroupMaster`. Οι διαφάνειες που ανήκουν σε οποιονδήποτε άλλο master δεν επανασχεδιάζονται.

### **Διατήρηση Πηγικού Θέματος κατά τη Μετακίνηση Διαφανειών**

Εάν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε τον πηγαίο master στην προορισμένη παρουσίαση με το [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection/addclone/), έπειτα κλωνοποιήστε τη διαφάνεια με το [ISlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) και τον κλωνοποιημένο master. Αυτό μεταφέρει μαζί του τον master, τα layouts και το σχετικό θέμα.

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

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η πηγαία διαφάνεια πρέπει να παραμείνει ακριβώς ίδια στο προορισμό. Η απλή κλωνοποίηση περιεχομένου σε έναν μη σχετικό master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, φόντα και εφέ που καθοδηγούνται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υπάρχουσα Διαφάνεια**

Εάν η διαφάνεια-στόχος πρέπει να παραμείνει στον τρέχοντα master και layout, αρχικοποιήστε μια παράκαμψη σε επίπεδο διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/el/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/el/net/aspose.slides.theme/overridetheme/initfontschemefrom/) και [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/el/net/aspose.slides.theme/overridetheme/initformatschemefrom/) αντιγράφουν τα τρία κύρια στοιχεία του θέματος στην παράκαμψη.

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

Αυτή η ενέργεια αλλάζει το θέμα που χρησιμοποιείται από εκείνη τη διαφάνεια χωρίς να επηρεάζει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παράκαμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme.Clear](https://reference.aspose.com/slides/el/net/aspose.slides.theme/overridetheme/clear/).

### **Εφαρμογή Παράκαμψης Θέματος σε Layout**

Μια παράκαμψη σε επίπεδο layout εφαρμόζεται στις διαφάνειες που χρησιμοποιούν αυτό το layout, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παράκαμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [LayoutSlideThemeManager](https://reference.aspose.com/slides/el/net/aspose.slides.theme/layoutslidethememanager/):

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

Χρησιμοποιήστε ένα θέμα σε επίπεδο master ή παρουσίασης όταν πολλαπλά layouts και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παράκαμψη layout όταν μια οικογένεια layout χρειάζεται διαφορετικό στυλ, και μια παράκαμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Υπερβολικές παρακάμψεις σε επίπεδο διαφάνειας καθιστούν τις μετέπειτα παγκόσμιες αλλαγές θέματος πιο δύσκολες στην πρόβλεψη.

## **Ενημέρωση Στυλ Φόντου Θέματος**

Τα γεμίσματα φόντου του θέματος αποθηκεύονται στο [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές φόντου στη διεπαφή του από τον αριθμό των ορισμών γεμίσματος που είναι φυσικά αποθηκευμένοι σε αυτή τη συλλογή, επειδή η διεπαφή μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ φόντου PowerPoint για ένα θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ φόντου, επιθεωρήστε τη συλλογή που αποθηκεύεται και το τρέχον [Background.StyleIndex](https://reference.aspose.com/slides/el/net/aspose.slides/background/styleindex/). Το `StyleIndex` χρησιμοποιεί `0` για κανένα θεματικό γέμισμα· οι θετικές τιμές είναι αναφορές στυλ φόντου θέματος. Αυτό διαφέρει από την ευρετηρίωση της συλλογής .NET, όπου το `[0]` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ γεμίσματος φόντου.

Το παρακάτω παράδειγμα αναφέρει τον διαθέσιμο αριθμό γεμισμάτων φόντου, αντιστοιχίζει μια θεματική αναφορά φόντου στον πρώτο master και αποθηκεύει την παρουσίαση:

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

Το ορατό αποτέλεσμα εξαρτάται από την καταχώριση θέματος που αναφέρεται από τον master και από τυχόν παρακάμψεις φόντου στο layout ή στη διαφάνεια. Εάν μια διαφάνεια χρησιμοποιεί το δικό της φόντο, η αλλαγή μόνο του φόντου του master μπορεί να μην αλλάξει εκείνη τη διαφάνεια. Χρησιμοποιήστε το [Background.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/background/geteffective/) όταν χρειάζεστε να ξέρετε το τελικό φόντο μετά την εφαρμογή της κληρονομικότητας.

{{% alert color="warning" title="Προειδοποίηση" %}}
Μην αντιμετωπίζετε το `StyleIndex` ως δείκτη μηδενικής βάσης. Επίσης, αποφύγετε την κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.
{{% /alert %}}

{{% alert color="info" title="Συμβουλή" %}}
Για άμεση μορφοποίηση φόντου και κληρονομικότητα φόντου, δείτε το [Presentation Background](/slides/el/net/presentation-background/).
{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφής θέματος περιλαμβάνει ξεχωριστές συλλογές [FillStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/linestyles/), και [EffectStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/effectstyles/). Τα τυπικά θέματα Office συχνά περιέχουν τρία κύρια στοιχεία στυλ που αντιστοιχούν οπτικά σε διακριτά, μέτρια και έντονα μορφοποιήσεις, αλλά ο κώδικας θα πρέπει να επιθεωρεί κάθε συλλογή αντί να υποθέτει έναν σταθερό αριθμό.

![Διακριτά, μέτρια και έντονα εφέ θέματος που εφαρμόζονται στο ίδιο σχήμα](presentation-design_10.png)

Κατά την πρόσβαση σε αυτές τις συλλογές με C#, ο δείκτης της συλλογής είναι μηδενικής βάσης: το `[0]` είναι το πρώτο αποθηκευμένο στυλ και το `[2]` το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, που εκτίθενται μέσω του [IShapeStyle](https://reference.aspose.com/slides/el/net/aspose.slides/ishapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό το στυλ θέματος· τα σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει αν οι απαιτούμενες καταχωρίσεις στυλ υπάρχουν, αλλάζει το πρώτο στυλ γραμμής, αλλάζει το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ, και αποθηκεύει το αποτέλεσμα:

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

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος θέματος γίνεται συμπαγές δασώδες πράσινο, και το τρίτο στυλ εφέ αποκτά εξωτερική σκιά με απόσταση 10 points. Το ακριβές οπτικό αποτέλεσμα εξακολουθεί να εξαρτάται από το ποια θέσεις στυλ αναφέρονται σε κάθε σχήμα και εάν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή γραμμής, γεμίσματος και ρυθμίσεων σκιάς](presentation-design_11.png)

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος σας λένε τι ορίζεται σε ένα συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι μια διαφάνεια ή σχήμα χρησιμοποιεί πραγματικά μετά την κληρονομικότητα και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/el/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Για ένα φόντο, χρησιμοποιήστε το [Background.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/background/geteffective/), και για ένα γέμισμα, το [FillFormat.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/geteffective/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το φόντο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

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

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διάγνωση απόδοσης, επικύρωση και συγκρίσεις. Εάν επιθεωρήσετε μόνο το [Presentation.MasterTheme](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/mastertheme/), μπορεί να χάσετε μια παράκαμψη master, layout, διαφάνειας ή σχήματος που αλλάζει την τελική εμφάνιση.

## **Συχνές Ερωτήσεις**

**Επηρεάζει η εφαρμογή ενός εξωτερικού θέματος κάθε διαφάνεια στην παρουσίαση;**

Όχι. Το [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) αντιστοιχίζει μόνο τις διαφάνειες που εξαρτώνται από τον επιλεγμένο master. Οι διαφάνειες που χρησιμοποιούν άλλους masters διατηρούν τα υπάρχοντα θέματα τους.

**Μπορώ να εφαρμόσω ένα θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε το [SlideThemeManager](https://reference.aspose.com/slides/el/net/aspose.slides.theme/slidethememanager/) της διαφάνειας και αρχικοποιήστε την παράκαμψη θέματος. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονόμησουν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο ασφαλέστερος τρόπος να μεταφέρω ένα θέμα από μια παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση του αρχικού της σχεδίου, κλωνοποιήστε τον πηγαίο master στην προορισμένη παρουσίαση με το [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslidecollection/addclone/) και κλωνοποιήστε τη διαφάνεια με το [ISlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) και τον κλωνοποιημένο master. Αυτό διατηρεί μαζί του τον master, τα layouts και το θέμα.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομικότητα και τις παρακάμψεις;**

Χρησιμοποιήστε το [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/el/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) για ένα θέμα διαφάνειας ή layout και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφής όπως το [Background.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/background/geteffective/) και το [FillFormat.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides/fillformat/geteffective/). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την εφαρμογή κληρονομικότητας και παρακάμψεων.
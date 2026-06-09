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
description: "Διαχειριστείτε τα θέματα παρουσίασης στο Aspose.Slides για .NET ώστε να δημιουργείτε, προσαρμόζετε και μετατρέπετε αρχεία PowerPoint με συνεπή επωνυμία."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει τις ιδιότητες των στοιχείων σχεδίασης. Όταν επιλέγετε ένα θέμα παρουσίασης, στην ουσία επιλέγετε ένα συγκεκριμένο σύνολο οπτικών στοιχείων και τις ιδιότητές τους.

Στο PowerPoint, ένα θέμα περιλαμβάνει χρώματα, [γραμματοσειρές](/slides/el/net/powerpoint-fonts/), [στυλ υποβάθρου](/slides/el/net/presentation-background/), και εφέ.

![theme-constituents](theme-constituents.png)

## **Αλλαγή Χρώματος Θέματος**

Ένα θέμα PowerPoint χρησιμοποιεί ένα συγκεκριμένο σύνολο χρωμάτων για διαφορετικά στοιχεία σε μια διαφάνεια. Εάν δεν σας αρέσουν τα χρώματα, τα αλλάζετε εφαρμόζοντας νέα χρώματα στο θέμα. Για να μπορείτε να επιλέξετε νέο χρώμα θέματος, το Aspose.Slides παρέχει τιμές στην απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/net/aspose.slides/schemecolor/).

Αυτός ο κώδικας C# δείχνει πώς να αλλάξετε το χρώμα έμφασης για ένα θέμα:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Μπορείτε να καθορίσετε την αποτελεσματική τιμή του προκύπτοντος χρώματος με αυτόν τον τρόπο:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

Για να επιδείξουμε περαιτέρω τη λειτουργία αλλαγής χρώματος, δημιουργούμε ένα άλλο στοιχείο και του αναθέτουμε το χρώμα έμφασης (από την αρχική λειτουργία). Στη συνέχεια αλλάζουμε το χρώμα στο θέμα:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

Το νέο χρώμα εφαρμόζεται αυτόματα και στα δύο στοιχεία.

### **Ορισμός Χρώματος Θέματος από Πρόσθετη Παλέτα**

Όταν εφαρμόζετε μετασχηματισμούς φωτεινότητας στο κύριο χρώμα θέματος(1), δημιουργούνται χρώματα από την πρόσθετη παλέτα(2). Στη συνέχεια μπορείτε να ορίσετε και να λάβετε αυτά τα χρώματα θέματος.

![additional-palette-colors](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος  
**2** - Χρώματα από την πρόσθετη παλέτα.

Αυτός ο κώδικας C# δείχνει μια λειτουργία όπου τα χρώματα της πρόσθετης παλέτας λαμβάνονται από το κύριο χρώμα θέματος και στη συνέχεια χρησιμοποιούνται σε σχήματα:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Έμφαση 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Έμφαση 4, Φωτεινότερο 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Έμφαση 4, Φωτεινότερο 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Έμφαση 4, Φωτεινότερο 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Έμφαση 4, Σκοτεινότερο 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Έμφαση 4, Σκοτεινότερο 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **Αντιστοίχιση `SchemeColor` σε Χρώματα `IColorScheme`**

Όταν εργάζεστε με το [SchemeColor](https://reference.aspose.com/slides/el/net/aspose.slides/schemecolor/), μπορεί να παρατηρήσετε ότι περιέχει τις παρακάτω τιμές χρωμάτων θέματος:

`Background1`, `Background2`, `Text1`, and `Text2`.

Ωστόσο, το `Presentation.MasterTheme.ColorScheme` επιστρέφει το [IColorScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/icolorscheme/), το οποίο εκθέτει τα αντίστοιχα χρώματα ως:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

Αυτή η διαφορά ονομασίας προέρχεται από την ορολογία του Microsoft Office. Οι παλαιότερες εκδόσεις του Office χρησιμοποιούσαν τα `Dark 1`, `Light 1`, `Dark 2` και `Light 2`, ενώ οι νεότερες εκδόσεις UI εμφανίζουν τις ίδιες θέσεις ως `Text 1`, `Background 1`, `Text 2` και `Background 2`.

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Δεν υπάρχει δυναμική μετατροπή μεταξύ `Text`/`Background` και `Dark`/`Light`. Απλώς είναι εναλλακτικές ονομασίες για τα ίδια χρώματα θέματος.

## **Αλλαγή Γραμματοσειράς Θέματος**

Για να μπορείτε να επιλέγετε γραμματοσειρές για θέματα και άλλους σκοπούς, το Aspose.Slides χρησιμοποιεί αυτούς τους ειδικούς ταυτοποιητές (παρόμοιους με αυτούς που χρησιμοποιούνται στο PowerPoint):

* **+mn-lt** - Γραμματοσειρά σώματος Latin (Minor Latin Font)
* **+mj-lt** - Γραμματοσειρά κεφαλίδας Latin (Major Latin Font)
* **+mn-ea** - Γραμματοσειρά σώματος East Asian (Minor East Asian Font)
* **+mj-ea** - Γραμματοσειρά σώματος East Asian (Minor East Asian Font)

Αυτός ο κώδικας C# δείχνει πώς να αντιστοιχίσετε τη γραμματοσειρά Latin σε ένα στοιχείο θέματος:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Αυτός ο κώδικας C# δείχνει πώς να αλλάξετε τη γραμματοσειρά του θέματος παρουσίασης:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

Η γραμματοσειρά σε όλα τα πλαίσια κειμένου θα ενημερωθεί.

{{% alert color="primary" title="TIP" %}} 
Μπορεί να θέλετε να δείτε τις [γραμματοσειρές PowerPoint](/slides/el/net/powerpoint-fonts/).
{{% /alert %}}

## **Αλλαγή Στυλ Υποβάθρου Θέματος**

Από προεπιλογή, η εφαρμογή PowerPoint παρέχει 12 προορισμένους υπόβαθρους, αλλά μόνο 3 από αυτούς τους 12 αποθηκεύονται σε μια τυπική παρουσίαση.

![todo:image_alt_text](presentation-design_8.png)

Για παράδειγμα, μετά την αποθήκευση μιας παρουσίασης στην εφαρμογή PowerPoint, μπορείτε να εκτελέσετε αυτόν τον κώδικα C# για να μάθετε τον αριθμό των προορισμένων υποβάθρων στην παρουσίαση:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
Χρησιμοποιώντας την ιδιότητα [BackgroundFillStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/), μπορείτε να προσθέσετε ή να προσπελάσετε το στυλ υποβάθρου σε ένα θέμα PowerPoint. 
{{% /alert %}}

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε το υπόβαθρο για μια παρουσίαση:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Οδηγός ευρετηρίου**: 0 χρησιμοποιείται για χωρίς γέμισμα. Το ευρετήριο ξεκινά από 1.

{{% alert color="primary" title="TIP" %}} 
Μπορεί να θέλετε να δείτε το [Υπόβαθρο PowerPoint](/slides/el/net/presentation-background/).
{{% /alert %}}

## **Αλλαγή Εφέ Θέματος**

Ένα θέμα PowerPoint συνήθως περιέχει 3 τιμές για κάθε σειρά στυλ. Αυτές οι σειρές συνδυάζονται σε αυτά τα 3 εφέ: διακριτικό, μέτρια, και έντονο. Για παράδειγμα, αυτό είναι το αποτέλεσμα όταν τα εφέ εφαρμόζονται σε ένα συγκεκριμένο σχήμα:

![todo:image_alt_text](presentation-design_10.png)

Χρησιμοποιώντας τις 3 ιδιότητες ([FillStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/effectstyles)) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme) μπορείτε να αλλάξετε τα στοιχεία σε ένα θέμα (ακόμη πιο ευέλικτα από τις επιλογές στο PowerPoint).

Αυτός ο κώδικας C# δείχνει πώς να αλλάξετε ένα εφέ θέματος τροποποιώντας τμήματα στοιχείων:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Οι προκύπτουσες αλλαγές στο χρώμα γέμισης, τύπο γέμισης, εφέ σκιάς κ.λπ.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Μπορώ να εφαρμόσω ένα θέμα σε μια μόνο διαφάνεια χωρίς να αλλάξω το κύριο θέμα;**

Ναι. Το Aspose.Slides υποστηρίζει παρακάμψεις θέματος επιπέδου διαφάνειας, έτσι μπορείτε να εφαρμόσετε ένα τοπικό θέμα μόνο σε αυτή τη διαφάνεια διατηρώντας το κύριο θέμα αμετάβλητο (μέσω του [SlideThemeManager](https://reference.aspose.com/slides/el/net/aspose.slides.theme/slidethememanager/)).

**Ποιος είναι ο πιο ασφαλής τρόπος να μεταφέρετε ένα θέμα από μια παρουσίαση σε άλλη;**

[Κλωνοποίηση διαφανειών](/slides/el/net/clone-slides/) μαζί με το κύριό τους στην προορισμένη παρουσίαση. Αυτό διατηρεί το αρχικό master, τις διατάξεις και το σχετικό θέμα, ώστε η εμφάνιση να παραμένει συνεπής.

**Πώς μπορώ να δω τις «αποτελεσματικές» τιμές μετά από όλες τις κληρονομήσεις και παρακάμψεις;**

Χρησιμοποιήστε τις «αποτελεσματικές» προβολές του API [/slides/el/net/shape-effective-properties/] για θέμα/χρώμα/γραμματοσειρά/εφέ. Αυτές επιστρέφουν τις τελικές, επιλυμένες ιδιότητες μετά την εφαρμογή του master και τυχόν τοπικών παρακάμψεων.
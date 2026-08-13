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
- Παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για .NET για τη δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή επωνυμία."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει τις ιδιότητες των στοιχείων σχεδίασης. Όταν επιλέγετε ένα θέμα παρουσίασης, ουσιαστικά επιλέγετε ένα συγκεκριμένο σύνολο οπτικών στοιχείων και των ιδιοτήτων τους.

Στο PowerPoint, ένα θέμα περιλαμβάνει χρώματα, [fonts](/slides/el/net/powerpoint-fonts/), [background styles](/slides/el/net/presentation-background/), και εφέ.

![theme-constituents](theme-constituents.png)

## **Αλλαγή Χρώματος Θέματος**

Ένα θέμα PowerPoint χρησιμοποιεί ένα συγκεκριμένο σύνολο χρωμάτων για διαφορετικά στοιχεία σε μια διαφάνεια. Αν δεν σας αρέσουν τα χρώματα, τα αλλάζετε εφαρμόζοντας νέα χρώματα για το θέμα. Για να επιλέξετε νέο χρώμα θέματος, η Aspose.Slides παρέχει τιμές στην απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/net/aspose.slides/schemecolor/).

Αυτός ο κώδικας C# δείχνει πώς να αλλάξετε το χρώμα έμφασης για ένα θέμα:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Μπορείτε να καθορίσετε την αποτελεσματική τιμή του προκύπτοντος χρώματος με τον εξής τρόπο:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Χρώμα [A=255, R=128, G=100, B=162])
}
```

Για να επαληθεύσετε περαιτέρω τη λειτουργία αλλαγής χρώματος, δημιουργούμε άλλο στοιχείο και του αναθέτουμε το χρώμα έμφασης (από την αρχική λειτουργία). Στη συνέχεια αλλάζουμε το χρώμα στο θέμα:

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

Το νέο χρώμα εφαρμόζεται αυτόματα και στα δύο στοιχεία.

### **Ορισμός Χρώματος Θέματος από Πρόσθετη Παλέτα**

Όταν εφαρμόζετε μετασχηματισμούς φωτεινότητας στο κύριο χρώμα θέματος(1), σχηματίζονται χρώματα από την πρόσθετη παλέτα(2). Μπορείτε μετά να ορίσετε και να λάβετε αυτά τα χρώματα θέματος. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος

**2** - Χρώματα από την πρόσθετη παλέτα.

Αυτός ο κώδικας C# παρουσιάζει μια λειτουργία όπου τα χρώματα της πρόσθετης παλέτας λαμβάνονται από το κύριο χρώμα θέματος και στη συνέχεια χρησιμοποιούνται σε σχήματα:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **Χαρτογράφηση `SchemeColor` σε `IColorScheme` Χρώματα**

Όταν εργάζεστε με [SchemeColor](https://reference.aspose.com/slides/el/net/aspose.slides/schemecolor/), μπορεί να παρατηρήσετε ότι περιέχει τις παρακάτω τιμές χρωμάτων θέματος:

`Background1`, `Background2`, `Text1`, και `Text2`.

Ωστόσο, το `Presentation.MasterTheme.ColorScheme` επιστρέφει [IColorScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/icolorscheme/), το οποίο εκθέτει τα αντίστοιχα χρώματα ως:

`Dark1`, `Dark2`, `Light1`, και `Light2`.

Αυτή η διαφορά είναι μόνο στην ονομασία. Οι τιμές αυτές αναφέρονται στα ίδια υποδοχέα χρωμάτων θέματος και η χαρτογράφηση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Δεν υπάρχει δυναμική μετατροπή μεταξύ `Text`/`Background` και `Dark`/`Light`. Είναι απλώς εναλλακτικές ονομασίες για τα ίδια χρώματα θέματος.

Αυτή η διαφορά στην ονομασία προέρχεται από την ορολογία του Microsoft Office. Παλαιότερες εκδόσεις του Office χρησιμοποιούσαν `Dark 1`, `Light 1`, `Dark 2` και `Light 2`, ενώ οι νεότερες εκδόσεις UI εμφανίζουν τους ίδιους υποδοχείς ως `Text 1`, `Background 1`, `Text 2` και `Background 2`.

## **Αλλαγή Γραμματοσειράς Θέματος**

Για να μπορείτε να επιλέγετε γραμματοσειρές για θέματα και άλλους σκοπούς, η Aspose.Slides χρησιμοποιεί αυτούς τους ειδικούς ταυτοποιητές (παρόμοιους με αυτούς που χρησιμοποιεί το PowerPoint):

* **+mn-lt** - Σώμα Γραμματοσειράς Λατινικής (Minor Latin Font)
* **+mj-lt** - Γραμματοσειρά Επικεφαλίδας Λατινική (Major Latin Font)
* **+mn-ea** - Σώμα Γραμματοσειράς Ανατολικής Ασίας (Minor East Asian Font)
* **+mj-ea** - Σώμα Γραμματοσειράς Ανατολικής Ασίας (Minor East Asian Font)

Αυτός ο κώδικας C# δείχνει πώς να αναθέσετε τη λατινική γραμματοσειρά σε ένα στοιχείο θέματος:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

Αυτός ο κώδικας C# δείχνει πώς να αλλάξετε τη γραμματοσειρά θέματος παρουσίασης:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

Η γραμματοσειρά σε όλα τα πλαίσια κειμένου θα ενημερωθεί.

{{% alert color="info" title="TIP" %}} 

Μπορεί να θέλετε να δείτε [PowerPoint fonts](/slides/el/net/powerpoint-fonts/).

{{% /alert %}}

## **Αλλαγή Στυλ Παρασκηνίου Θέματος**

Από προεπιλογή, η εφαρμογή PowerPoint παρέχει 12 προρυθμισμένα παρασκήνια, αλλά μόνο 3 από αυτά αποθηκεύονται σε μια τυπική παρουσίαση. 

![todo:image_alt_text](presentation-design_8.png)

Για παράδειγμα, αφού αποθηκεύσετε μια παρουσίαση στην εφαρμογή PowerPoint, μπορείτε να εκτελέσετε αυτόν τον κώδικα C# για να μάθετε πόσα προρυθμισμένα παρασκήνια υπάρχουν στην παρουσίαση:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 

Χρησιμοποιώντας την ιδιότητα [BackgroundFillStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/), μπορείτε να προσθέσετε ή να προσπελάσετε το στυλ παρασκηνίου σε ένα θέμα PowerPoint. 

{{% /alert %}}

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε το παρασκήνιο για μια παρουσίαση:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**Οδηγός δείκτη**: 0 χρησιμοποιείται για χωρίς γέμισμα. Ο δείκτης ξεκινά από το 1.

{{% alert color="info" title="TIP" %}} 

Μπορεί να θέλετε να δείτε [PowerPoint Background](/slides/el/net/presentation-background/).

{{% /alert %}}

## **Αλλαγή Εφέ Θέματος**

Ένα θέμα PowerPoint συνήθως περιέχει 3 τιμές για κάθε σειρά στυλ. Αυτές οι σειρές συνδυάζονται σε αυτά τα 3 εφέ: διακριτικό, μέτριο και έντονο. Για παράδειγμα, αυτό είναι το αποτέλεσμα όταν τα εφέ εφαρμόζονται σε ένα συγκεκριμένο σχήμα:

![todo:image_alt_text](presentation-design_10.png)

Χρησιμοποιώντας 3 ιδιότητες ([FillStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme/effectstyles)) από την κλάση [FormatScheme](https://reference.aspose.com/slides/el/net/aspose.slides.theme/formatscheme) μπορείτε να αλλάξετε τα στοιχεία σε ένα θέμα (ακόμη πιο ευέλικτα από τις επιλογές στο PowerPoint).

Αυτός ο κώδικας C# δείχνει πώς να αλλάξετε ένα εφέ θέματος τροποποιώντας μέρη των στοιχείων:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Οι resulting αλλαγές σε χρώμα γεμίσματος, τύπο γεμίσματος, σκιά, κ.λπ.:

![todo:image_alt_text](presentation-design_11.png)

## **Συχνές Ερωτήσεις**

### Μπορώ να εφαρμόσω ένα θέμα σε μία διαφάνεια χωρίς να αλλάξω το master;

Ναι. Η Aspose.Slides υποστηρίζει παρακάμψεις θέματος επιπέδου διαφάνειας, ώστε να μπορείτε να εφαρμόσετε τοπικό θέμα μόνο σε εκείνη τη διαφάνεια ενώ το master theme παραμένει αμετάβλητο (μέσω του [SlideThemeManager](https://reference.aspose.com/slides/el/net/aspose.slides.theme/slidethememanager/)).

### Ποιος είναι ο πιο ασφαλής τρόπος για να μεταφέρω ένα θέμα από μία παρουσίαση σε άλλη;

[Clone slides](/slides/el/net/clone-slides/) μαζί με το master τους στην προορισμένη παρουσίαση. Αυτό διατηρεί το αρχικό master, τις διατάξεις και το συσχετισμένο θέμα ώστε η εμφάνιση να παραμείνει συνεπής.

### Πώς μπορώ να δω τις «αποτελεσματικές» τιμές μετά από όλες τις κληρονομήσεις και παρακάμψεις;

Χρησιμοποιήστε τις «αποτελεσματικές» προβολές του API [/slides/el/net/shape-effective-properties/] για θέμα/χρώμα/γραμματοσειρά/εφέ. Αυτές επιστρέφουν τις τελικές, επιλυμένες ιδιότητες μετά την εφαρμογή του master και τυχόν τοπικών παρακάμψεων.
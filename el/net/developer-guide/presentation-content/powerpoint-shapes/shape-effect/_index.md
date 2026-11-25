---
title: Εφαρμογή Εφέ Σχημάτων σε Παρουσιάσεις σε .NET
linktitle: Εφέ Σχήματος
type: docs
weight: 30
url: /el/net/shape-effect/
keywords:
- εφέ σχήματος
- εφέ σκιάς
- εφέ αντανάκλασης
- εφέ λάμψης
- εφέ μαλακών άκρων
- μορφή εφέ
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε τα αρχεία PPT και PPTX σας με προηγμένα εφέ σχήματος χρησιμοποιώντας το Aspose.Slides για .NET—δημιουργήστε εντυπωσιακές, επαγγελματικές διαφάνειες σε δευτερόλεπτα."
---
## **Εισαγωγή**

Ενώ τα εφέ στο PowerPoint μπορούν να χρησιμοποιηθούν για να ξεχωρίσει ένα σχήμα, διαφέρουν από τις [γέμιση](/slides/el/net/shape-formatting/#gradient-fill) ή τα περιγράμματα. Χρησιμοποιώντας τα εφέ του PowerPoint, μπορείτε να δημιουργήσετε πειστικές αντανακλάσεις σε ένα σχήμα, να διαστέλλετε τη λάμψη ενός σχήματος κ.λπ.

![Εφέ σχήματος](shape-effect.png)

Το PowerPoint παρέχει έξι εφέ που μπορούν να εφαρμοστούν σε σχήματα. Μπορείτε να εφαρμόσετε ένα ή περισσότερα εφέ σε ένα σχήμα.

Ορισμένοι συνδυασμοί εφέ φαίνονται καλύτεροι από άλλους. Για το λόγο αυτό, το PowerPoint διαθέτει επιλογές κάτω από **Προεπιλογή**. Οι επιλογές Προεπιλογής είναι ουσιαστικά ένας γνωστός, καλός συνδυασμός δύο ή περισσότερων εφέ. Έτσι, επιλέγοντας μια προεπιλογή, δεν χρειάζεται να χάσετε χρόνο ελέγχοντας ή συνδυάζοντας διαφορετικά εφέ για να βρείτε έναν καλό συνδυασμό.

Το Aspose.Slides παρέχει ιδιότητες και μεθόδους στην κλάση [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) που σας επιτρέπουν να εφαρμόζετε τα ίδια εφέ σε σχήματα σε παρουσιάσεις PowerPoint.

## **Εφαρμογή Εφέ Σκιάς**

Το Aspose.Slides για .NET υποστηρίζει εξωτερικές και εσωτερικές σκιές για σχήματα. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώματος ώστε να ταιριάζει με το σχεδιασμό της παρουσίασής σας.

### **Εφαρμογή Εξωτερικής Σκιάς**

Χρησιμοποιήστε μια εξωτερική σκιά για να κάνετε μια κάρτα ή πίνακα να ξεχωρίζει από το φόντο της διαφάνειας. Η σκιά επεκτείνεται πέρα από τις άκρες του σχήματος, δημιουργώντας την εντύπωση ότι το σχήμα είναι ανυψωμένο πάνω από τη διαφάνεια. Ρυθμίστε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώματος ώστε να ταιριάζει με το φωτισμό και το στυλ του προτύπου σας.

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε το [εφέ εξωτερικής σκιάς](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) σε ένα παραλληλόγραμμο:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Εφέ σκιάς](shadow_effect.png)

### **Εφαρμογή Εσωτερικής Σκιάς**

Κατά την αναπαραγωγή του οπτικού στυλ ενός προτύπου, χρησιμοποιήστε μια εσωτερική σκιά για να δώσετε σε μια κάρτα ή πίνακα μια εσοπτική εμφάνιση. Μια εξωτερική σκιά επεκτείνεται έξω από το σχήμα και το κάνει να φαίνεται ανυψωμένο, ενώ μια εσωτερική σκιά φωτίζει το εσωτερικό των άκρων του.

Καλέστε το [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), στη συνέχεια διαμορφώστε το [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Μεγαλύτερες τιμές παράγουν πιο απαλές άκρες.

Αυτό το παράδειγμα C# δημιουργεί μια ανοιχτόχρωμη μπλε κάρτα με μια σκούρο γκρι εσωτερική σκιά και την αποθηκεύει ως αρχείο PPTX:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![Ανοικτό μπλε παραλληλόγραμμο με εσωτερική σκιά](inner_shadow_effect.png)

Για να αφαιρέσετε την εσωτερική σκιά, καλέστε το [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) στη μορφή εφέ του σχήματος.

### **Εφαρμογή, Αλλαγή και Αφαίρεση Προεπιλογής Σκιάς**

Καλέστε το [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) και ορίστε το [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) σε έναν ονομασμένο [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/). Για να αλλάξετε το στυλ, αλλάξτε την προεπιλογή στο ίδιο σχήμα. Καλέστε το [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) για να αφαιρέσετε τη σκιά διατηρώντας τη γέμιση και το περίγραμμα.

Αυτό το παράδειγμα κρατάει ένα αντίγραφο του παραλληλογράμμου σε κάθε στάδιο. Και οι δύο σκιές μετατοπίζονται κατά 10 μοντέλα. Μία κατεύθυνση 225° τοποθετεί την πρώτη σκιά πάνω και στα αριστερά του παραλληλογράμμου, ενώ 45° τοποθετεί τη δεύτερη κάτω και δεξιά.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| Αρχικό | Πρώτη προεπιλογή | Δεύτερη προεπιλογή | Μετά την αφαίρεση |
| :---: | :---: | :---: | :---: |
| ![Χωρίς σκιά](preset_shadow_original.png) | ![Σκιά Πάνω Αριστερά](preset_shadow_top_left.png) | ![Σκιά Κάτω Δεξιά](preset_shadow_bottom_right.png) | ![Χωρίς σκιά μετά την αφαίρεση](preset_shadow_removed.png) |

## **Εφαρμογή Εφέ Αντανάκλασης**

Για να εφαρμόσετε ένα εφέ αντανάκλασης στο Aspose.Slides για .NET, μπορείτε να προσθέσετε μια καθρέφτη-όμοια αντανάκλαση σε σχήματα, ρυθμίζοντας παραμέτρους όπως η απόσταση, η διαφάνεια και το μέγεθος. Αυτό το εφέ ενισχύει την αισθητική των παρουσιάσεών σας δίνοντας στα σχήματα μια πιο γυαλιστερή και εξελιγμένη εμφάνιση. Είναι εύκολο στην υλοποίηση με απλό κώδικα, επιτρέποντας γρήγορη εφαρμογή σε πολλά στοιχεία για συνεπές σχεδιασμό.

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε το [εφέ αντανάκλασης](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) σε ένα σχήμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![Εφέ αντανάκλασης](reflection_effect.png)

## **Εφαρμογή Εφέ Λάμψης**

Για να εφαρμόσετε ένα εφέ λάμψης σε ένα σχήμα στο Aspose.Slides για .NET, μπορείτε να προσθέσετε μια ήπια, φωτεινή αύρα γύρω από τα σχήματα, ρυθμίζοντας ιδιότητες όπως το χρώμα και το μέγεθος. Αυτό το εφέ βοηθά τα σχήματα να ξεχωρίζουν και προσθέτει ένα ελκυστικό, εντυπωσιακό οπτικό στοιχείο στην παρουσίασή σας. Είναι εύκολο στην υλοποίηση με ελάχιστο κώδικα, βελτιώνοντας τη συνολική εμφάνιση των διαφανειών σας.

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε το [εφέ λάμψης](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) σε ένα σχήμα:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Εφέ λάμψης](glow_effect.png)

## **Εφαρμογή Εφέ Μαλακών Άκρων**

Για να εφαρμόσετε ένα εφέ μαλακών άκρων στο Aspose.Slides για .NET, μπορείτε να δημιουργήσετε μια ομαλή, θολή μετάβαση γύρω από τις άκρες ενός σχήματος. Αυτό το εφέ προσθέτει μια πιο διακριτική και εκλεπτυσμένη εμφάνιση, ιδανική για σχεδιασμούς που χρειάζονται μια απαλή, πιο μαλακή εμφάνιση. Μπορείτε εύκολα να ρυθμίσετε παραμέτρους όπως η ακτίνα για να επιτύχετε το επιθυμητό αποτέλεσμα σε διάφορα σχήματα της παρουσίασής σας.

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε τα [μαλακά άκρα](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) σε ένα σχήμα:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Εφέ μαλακών άκρων](soft_edges_effect.png)

## **Εφαρμογή Εφέ Θόλωσης**

Χρησιμοποιήστε τη θόλωση σχήματος για να μαλακώσετε τη γέμιση και το περίγραμμα ενός σχήματος ενώ παραμένετε επεξεργάσιμο το σχήμα. Καλέστε το [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) στη μορφή εφέ του σχήματος. Η ακτίνα μετράται σε μοντέλα (1/72 ίντσα): χρησιμοποιήστε μια μη αρνητική τιμή, με μεγαλύτερες τιμές που προκαλούν πιο ισχυρή θόλωση. Μια ακτίνα μηδέν αφήνει την εμφάνιση αμετάβλητη.

Η ρύθμιση [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) ελέγχει τα ορατά όρια του εφέ. Με `false`, η θόλωση περιορίζεται στα αρχικά βαμμένα όρια, συμπεριλαμβανομένου του περιγράμματος. Με `true`, η θόλωση μπορεί να επεκταθεί πέρα από αυτά τα όρια. Κανένα από τα δύο δεν αλλάζει τη θέση ή τις διαστάσεις του σχήματος.

Η σύγκριση παρακάτω χρησιμοποιεί την ίδια γέμιση, περίγραμμα και διαστάσεις σχήματος σε όλο το παράδειγμα. Η πάνω σειρά χρησιμοποιεί `grow = false`; η κάτω σειρά χρησιμοποιεί `grow = true`.

![Αρχικό παραλληλόγραμμο συγκρινόμενο με ακτίνες θόλωσης 5 και 15 μοντέλων, με grow απενεργοποιημένο και ενεργοποιημένο](shape_blur_comparison.png)

Αυτό το παράδειγμα C# δημιουργεί ένα πορτοκαλί παραλληλόγραμμο με σκούρο μπλε περίγραμμα, εφαρμόζει θόλωση 5 μοντέλων και έπειτα το ενημερώνει σε θόλωση 15 μοντέλων καλώντας ξανά το [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/). Αποθηκεύει και τις δύο καταστάσεις με θόλωση, στη συνέχεια καλεί το [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) και αποθηκεύει το σχήμα χωρίς θόλωση.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

Η θόλωση σχήματος επηρεάζει τη γέμιση και το περίγραμμα μαζί. Το εφέ μαλακών άκρων εξασθενίζει τις άκρες του σχήματος, ενώ η θόλωση της σκιάς μαλακώνει μόνο τη σκιά. Τα εφέ μετασχηματισμού εικόνας λειτουργούν στο περιεχόμενο της εικόνας· αυτό το παράδειγμα εφαρμόζει θόλωση απευθείας στη μορφή εφέ του σχήματος χωρίς να μετατρέπει το σχήμα σε εικόνα.

## **FAQ**

**Μπορώ να εφαρμόσω πολλαπλά εφέ στο ίδιο σχήμα;**

Ναι, μπορείτε να συνδυάσετε διαφορετικά εφέ, όπως σκιά, αντανάκλαση και λάμψη, σε ένα μόνο σχήμα για να δημιουργήσετε μια πιο δυναμική εμφάνιση.

**Σε ποια σχήματα μπορώ να εφαρμόσω εφέ;**

Μπορείτε να εφαρμόσετε εφέ σε διάφορα σχήματα, συμπεριλαμβανομένων αυτόματων σχημάτων, διαγραμμάτων, πινάκων, εικόνων, αντικειμένων SmartArt, αντικειμένων OLE κ.ά.

**Μπορώ να εφαρμόσω εφέ σε ομαδοποιημένα σχήματα;**

Ναι, μπορείτε να εφαρμόσετε εφέ σε ομαδοποιημένα σχήματα. Το εφέ θα εφαρμοστεί σε ολόκληρη την ομάδα.
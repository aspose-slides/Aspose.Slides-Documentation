---
title: Εφαρμογή εφέ σχήματος σε παρουσιάσεις στο .NET
linktitle: Εφέ σχήματος
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
description: "Μετατρέψτε τα αρχεία PPT και PPTX σας με προχωρημένα εφέ σχήματος χρησιμοποιώντας το Aspose.Slides για .NET—δημιουργήστε εντυπωσιακές, επαγγελματικές διαφάνειες σε δευτερόλεπτα."
---
## **Εισαγωγή**

Ενώ τα εφέ στο PowerPoint μπορούν να χρησιμοποιηθούν για να κάνει ένα σχήμα να ξεχωρίζει, διαφέρουν από τις [συμπληρώσεις](/slides/el/net/shape-formatting/#gradient-fill) ή τα περιγράμματα. Με τη χρήση των εφέ του PowerPoint, μπορείτε να δημιουργήσετε πειστικές αντανακλάσεις σε ένα σχήμα, να διαχέσετε τη λάμψη ενός σχήματος, κ.ά.

![Εφέ σχήματος](shape-effect.png)

Το PowerPoint παρέχει έξι εφέ που μπορούν να εφαρμοστούν σε σχήματα. Μπορείτε να εφαρμόσετε ένα ή περισσότερα εφέ σε ένα σχήμα.

Μερικοί συνδυασμοί εφέ φαίνονται καλύτεροι από άλλους. Γι' αυτό το λόγο, το PowerPoint διαθέτει επιλογές κάτω από **Preset**. Οι επιλογές Preset είναι ουσιαστικά ένας γνωστός, καλόγλωσσος συνδυασμός δύο ή περισσότερων εφέ. Με αυτόν τον τρόπο, επιλέγοντας ένα preset, δεν θα χρειαστεί να σπαταλήσετε χρόνο δοκιμάζοντας ή συνδυάζοντας διαφορετικά εφέ για να βρείτε έναν ωραίο συνδυασμό.

Το Aspose.Slides παρέχει ιδιότητες και μεθόδους στην κλάση [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) που επιτρέπουν την εφαρμογή των ίδιων εφέ σε σχήματα σε παρουσιάσεις PowerPoint.

## **Εφαρμογή Εφέ Σκιάς**

Το Aspose.Slides για .NET υποστηρίζει εξωτερικές και εσωτερικές σκιές για σχήματα. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώματος ώστε να ταιριάζουν με το σχεδιασμό της παρουσίασής σας.

### **Εφαρμογή Εξωτερικής Σκιάς**

Χρησιμοποιήστε μια εξωτερική σκιά για να κάνετε μια κάρτα ή έναν πίνακα να ξεχωρίζει από το φόντο της διαφάνειας. Η σκιά εκτείνεται πέρα από τις άκρες του σχήματος, δημιουργώντας την εντύπωση ότι το σχήμα είναι ανυψωμένο πάνω από τη διαφάνεια. Ρυθμίστε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώματος ώστε να ταιριάζουν με το φωτισμό και το στυλ του προτύπου σας.

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε το [εφέ εξωτερικής σκιάς](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) σε ένα ορθογώνιο:

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

Κατά την αναπαραγωγή του οπτικού στυλ ενός προτύπου, χρησιμοποιήστε μια εσωτερική σκιά για να δώσετε σε μια κάρτα ή έναν πίνακα μια εσομένη εμφάνιση. Μια εξωτερική σκιά εκτείνεται έξω από το σχήμα και το κάνει να φαίνεται ανυψωμένο, ενώ μια εσωτερική σκιά σκιάζει το εσωτερικό των άκρων του.

Καλέστε το [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), στη συνέχεια διαμορφώστε το [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Μεγαλύτερες τιμές παράγουν πιο απαλές άκρες.

Αυτό το παράδειγμα C# δημιουργεί μια ανοιχτό μπλε κάρτα με μια σκούρο γκρι εσωτερική σκιά και το αποθηκεύει ως αρχείο PPTX:

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

![Ανοιχτό μπλε ορθογώνιο με εσωτερική σκιά](inner_shadow_effect.png)

Για να αφαιρέσετε την εσωτερική σκιά, καλέστε το [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) στο format εφέ του σχήματος.

## **Εφαρμογή Εφέ Αντανάκλασης**

Για να εφαρμόσετε ένα εφέ αντανάκλασης στο Aspose.Slides για .NET, μπορείτε να προσθέσετε μια καθρεπτική αντανάκλαση σε σχήματα, ρυθμίζοντας παραμέτρους όπως η απόσταση, η διαφάνεια και το μέγεθος. Αυτό το εφέ ενισχύει την αισθητική των παρουσιάσεών σας δίνοντας στα σχήματα μια πιο γυαλισμένη και εκλεπτυσμένη εμφάνιση. Είναι εύκολο να υλοποιηθεί με απλό κώδικα, επιτρέποντας γρήγορη εφαρμογή σε πολλά στοιχεία για συνεπές σχέδιο.

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε το [reflection effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) σε ένα σχήμα:

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

Για να εφαρμόσετε ένα εφέ λάμψης σε ένα σχήμα στο Aspose.Slides για .NET, μπορείτε να προσθέσετε μια απαλή, λαμπρή αύρα γύρω από τα σχήματα, ρυθμίζοντας ιδιότητες όπως το χρώμα και το μέγεθος. Αυτό το εφέ βοηθά τα σχήματα να ξεχωρίζουν και προσθέτει ένα ελκυστικό, εντυπωσιακό οπτικό στοιχείο στην παρουσίασή σας. Είναι εύκολο να υλοποιηθεί με ελάχιστο κώδικα, βελτιώνοντας τη συνολική εμφάνιση των διαφανειών σας.

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε το [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) σε ένα σχήμα:

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

Για να εφαρμόσετε ένα εφέ μαλακών άκρων στο Aspose.Slides για .NET, μπορείτε να δημιουργήσετε μια ομαλή, θολή μετάβαση γύρω από τις άκρες ενός σχήματος. Αυτό το εφέ προσθέτει μια πιο διακριτική και εκλεπτυσμένη εμφάνιση, ιδανική για σχέδια που χρειάζονται μια ήπια, πιο απαλή εμφάνιση. Μπορείτε εύκολα να ρυθμίσετε παραμέτρους όπως η ακτίνα για να επιτύχετε το επιθυμητό αποτέλεσμα σε διάφορα σχήματα της παρουσίασής σας.

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε τα [μαλακές άκρες](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) σε ένα σχήμα:

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

## **Εφαρμογή Εφέ Θολώματος**

Χρησιμοποιήστε θόλωση σχήματος για να μαλακώσετε τη γέμιση και το περίγραμμα ενός σχήματος, διατηρώντας το σχήμα επεξεργάσιμο. Καλέστε το [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) στο format εφέ του σχήματος. Η ακτίνα μετράται σε σημείο (1/72 ίντσα): χρησιμοποιήστε μια μη αρνητική τιμή, με μεγαλύτερες τιμές να παράγουν ισχυρότερη θόλωση. Μια ακτίνα μηδέν αφήνει την εμφάνιση αμετάβλητη.

Η επιλογή [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) ελέγχει τα ορατά όρια του εφέ. Με `false`, η θόλωση κόβεται στα αρχικά ζωγραφισμένα όρια, συμπεριλαμβανομένου του περιγράμματος. Με `true`, η θόλωση μπορεί να επεκταθεί πέρα από αυτά τα όρια. Καμία ρύθμιση δεν αλλάζει τη θέση ή τις διαστάσεις του σχήματος.

Η παρακάτω σύγκριση χρησιμοποιεί την ίδια γέμιση, το ίδιο περίγραμμα και τις ίδιες διαστάσεις σχήματος σε όλη τη διάρκεια. Η πάνω σειρά χρησιμοποιεί `grow = false`; η κάτω σειρά χρησιμοποιεί `grow = true`.

![Αρχικό ορθογώνιο συγκρινόμενο με ακτίνες θολώματος 5 και 15 σημείων, με το grow απενεργοποιημένο και ενεργοποιημένο](shape_blur_comparison.png)

Αυτό το παράδειγμα C# δημιουργεί ένα πορτοκαλί ορθογώνιο με σκούρο μπλε περίγραμμα, εφαρμόζει θόλωση 5 σημείων και στη συνέχεια το ενημερώνει σε θόλωση 15 σημείων καλών

ξανά το [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/). Αποθηκεύει και τις δύο καταστάσεις με θόλωση, στη συνέχεια καλεί το [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) και αποθηκεύει το σχήμα χωρίς θόλωση.

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

Η θόλωση σχήματος επηρεάζει τη γέμιση και το περίγραμμα μαζί. Ένα εφέ μαλακών άκρων ξεθωριάζει τις άκρες του σχήματος, ενώ η θόλωση σκιάς μαλακώνει μόνο τη σκιά. Τα εφέ μετασχηματισμού εικόνας λειτουργούν στο περιεχόμενο της εικόνας· αυτό το παράδειγμα εφαρμόζει θόλωση απευθείας στο format εφέ του σχήματος χωρίς τη μετατροπή του σχήματος σε εικόνα.

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω πολλαπλά εφέ στο ίδιο σχήμα;**

Ναι, μπορείτε να συνδυάσετε διαφορετικά εφέ, όπως σκιά, αντανάκλαση και λάμψη, σε ένα μόνο σχήμα για να δημιουργήσετε μια πιο δυναμική εμφάνιση.

**Σε ποια σχήματα μπορώ να εφαρμόσω εφέ;**

Μπορείτε να εφαρμόσετε εφέ σε διάφορα σχήματα, συμπεριλαμβανομένων των αυτόματων σχημάτων, διαγραμμάτων, πινάκων, εικόνων, αντικειμένων SmartArt, αντικειμένων OLE και άλλων.

**Μπορώ να εφαρμόσω εφέ σε ομαδοποιημένα σχήματα;**

Ναι, μπορείτε να εφαρμόσετε εφέ σε ομαδοποιημένα σχήματα. Το εφέ θα εφαρμοστεί σε ολόκληρη την ομάδα.
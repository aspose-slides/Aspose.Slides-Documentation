---
title: Εφαρμογή εφέ σχήματος σε παρουσιάσεις στο .NET
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
description: "Μετατρέψτε τα αρχεία PPT και PPTX σας με προχωρημένα εφέ σχήματος χρησιμοποιώντας το Aspose.Slides για .NET—δημιουργήστε εντυπωσιακές, επαγγελματικές διαφάνειες σε δευτερόλεπτα."
---
## **Εισαγωγή**

Ενώ τα εφέ στο PowerPoint μπορούν να χρησιμοποιηθούν για να αναδείξουν ένα σχήμα, διαφέρουν από τα [γεμίσματα](/slides/el/net/shape-formatting/#gradient-fill) ή τα περιγράμματα. Χρησιμοποιώντας τα εφέ του PowerPoint, μπορείτε να δημιουργήσετε πειστικές αντανακλάσεις σε ένα σχήμα, να διασπείρετε τη λάμψη ενός σχήματος κ.λπ.

![Εφέ σχήματος](shape-effect.png)

Το PowerPoint παρέχει έξι εφέ που μπορούν να εφαρμοστούν σε σχήματα. Μπορείτε να εφαρμόσετε ένα ή περισσότερα εφέ σε ένα σχήμα.

Ορισμένοι συνδυασμοί εφέ φαίνονται καλύτεροι από άλλους. Για αυτό το λόγο, το PowerPoint έχει επιλογές κάτω από **Preset**. Οι επιλογές Preset είναι ουσιαστικά ένας γνωστός, ωραία εμφανιζόμενος συνδυασμός δύο ή περισσότερων εφέ. Με αυτόν τον τρόπο, επιλέγοντας ένα preset, δεν θα χρειαστεί να σπαταλήσετε χρόνο δοκιμάζοντας ή συνδυάζοντας διαφορετικά εφέ για να βρείτε έναν ωραίο συνδυασμό.

Το Aspose.Slides παρέχει ιδιότητες και μεθόδους στην κλάση [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) που σας επιτρέπουν να εφαρμόζετε τα ίδια εφέ σε σχήματα σε παρουσιάσεις PowerPoint.

## **Εφαρμογή Εφέ Σκιάς**

Το Aspose.Slides για .NET υποστηρίζει εξωτερικές και εσωτερικές σκιές για σχήματα. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώματος ώστε να ταιριάζουν με το σχεδιασμό της παρουσίασής σας.

### **Εφαρμογή Εξωτερικής Σκιάς**

Χρησιμοποιήστε μια εξωτερική σκιά για να κάνετε μια κάρτα ή πίνακα να ξεχωρίζει από το φόντο της διαφάνειας. Η σκιά επεκτείνεται εκτός των ακμών του σχήματος, δημιουργώντας την εντύπωση ότι το σχήμα είναι ανυψωμένο πάνω από τη διαφάνεια. Προσαρμόστε το χρώμα, την κατεύθυνση, την απόσταση και την ακτίνα θολώματος ώστε να ταιριάζουν με το φωτισμό και το στυλ του προτύπου σας.

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

![Εφέ Σκιάς](shadow_effect.png)

### **Εφαρμογή Εσωτερικής Σκιάς**

Κατά την αναπαραγωγή του οπτικού στυλ ενός προτύπου, χρησιμοποιήστε μια εσωτερική σκιά για να δώσετε σε μια κάρτα ή πίνακα μια εσοχή. Μια εξωτερική σκιά επεκτείνεται έξω από το σχήμα και το κάνει να φαίνεται ανυψωμένο, ενώ μια εσωτερική σκιά σκιάζει το εσωτερικό των άκρων του.

Κλήστε την [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), στη συνέχεια διαμορφώστε την [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Μεγαλύτερες τιμές παράγουν πιο μαλακές άκρες.

Αυτό το παράδειγμα C# δημιουργεί μια ανοιχτό μπλε κάρτα με σκούρο γκρι εσωτερική σκιά και το αποθηκεύει ως αρχείο PPTX:

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

![Ορθογώνιο ανοιχτό μπλε με εσωτερική σκιά](inner_shadow_effect.png)

Για να αφαιρέσετε την εσωτερική σκιά, καλέστε την [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) στη μορφή εφέ του σχήματος.

## **Εφαρμογή Εφέ Αντανάκλασης**

Για να εφαρμόσετε ένα εφέ αντανάκλασης στο Aspose.Slides για .NET, μπορείτε να προσθέσετε μια καθρεφτική αντανακλαστική στο σχήματα, ρυθμίζοντας παραμέτρους όπως η απόσταση, η διαφάνεια και το μέγεθος. Αυτό το εφέ ενισχύει την αισθητική των παρουσιάσεών σας δίνοντας στα σχήματα μια πιο επαγγελματική και πολυτελή εμφάνιση. Είναι εύκολο να το υλοποιήσετε με απλό κώδικα, επιτρέποντας γρήγορη εφαρμογή σε πολλαπλά στοιχεία για ένα συνεπές σχέδιο.

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

![Εφέ Αντανάκλασης](reflection_effect.png)

## **Εφαρμογή Εφέ Λάμψης**

Για να εφαρμόσετε ένα εφέ λάμψης σε ένα σχήμα στο Aspose.Slides για .NET, μπορείτε να προσθέσετε μια απαλό, φωτεινό αύρα γύρω από τα σχήματα, ρυθμίζοντας ιδιότητες όπως το χρώμα και το μέγεθος. Αυτό το εφέ βοηθά τα σχήματα να ξεχωρίζουν και προσθέτει ένα ελκυστικό, εντυπωσιακό οπτικό στοιχείο στην παρουσίασή σας. Είναι εύκολο να το υλοποιήσετε με ελάχιστο κώδικα, βελτιώνοντας τη συνολική εμφάνιση των διαφανειών σας.

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

![Εφέ Λάμψης](glow_effect.png)

## **Εφαρμογή Εφέ Μαλακών Άκρων**

Για να εφαρμόσετε ένα εφέ μαλακών άκρων στο Aspose.Slides για .NET, μπορείτε να δημιουργήσετε μια ομαλή, θολή μετάβαση γύρω από τις άκρες ενός σχήματος. Αυτό το εφέ προσθέτει μια πιο ήπια και εκλεπτυσμένη εμφάνιση, ιδανική για σχέδια που χρειάζονται μια απαλή, πιο ήπια εμφάνιση. Μπορείτε εύκολα να ρυθμίσετε παραμέτρους όπως η ακτίνα για να πετύχετε το επιθυμητό εφέ σε διάφορα σχήματα στην παρουσίασή σας.

Αυτός ο κώδικας C# δείχνει πώς να εφαρμόσετε τις [μαλακές άκρες](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) σε ένα σχήμα:

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

![Εφέ Μαλακών Άκρων](soft_edges_effect.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να εφαρμόσω πολλαπλά εφέ στο ίδιο σχήμα;**

Ναι, μπορείτε να συνδυάσετε διαφορετικά εφέ, όπως σκιά, αντανάκλαση και λάμψη, σε ένα μόνο σχήμα για να δημιουργήσετε μια πιο δυναμική εμφάνιση.

**Σε ποια σχήματα μπορώ να εφαρμόσω εφέ;**

Μπορείτε να εφαρμόσετε εφέ σε διάφορα σχήματα, συμπεριλαμβανομένων των αυτόματων σχημάτων, διαγραμμάτων, πινάκων, εικόνων, αντικειμένων SmartArt, αντικειμένων OLE και άλλων.

**Μπορώ να εφαρμόσω εφέ σε ομαδοποιημένα σχήματα;**

Ναι, μπορείτε να εφαρμόσετε εφέ σε ομαδοποιημένα σχήματα. Το εφέ θα εφαρμοστεί σε ολόκληρη την ομάδα.
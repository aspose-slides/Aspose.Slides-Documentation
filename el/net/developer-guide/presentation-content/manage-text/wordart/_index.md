---
title: Δημιουργία και Εφαρμογή Εφέ WordArt σε .NET
linktitle: WordArt
type: docs
weight: 110
url: /el/net/wordart/
keywords:
- WordArt
- Δημιουργία WordArt
- Πρότυπο WordArt
- Εφέ WordArt
- Εφέ Σκιάς
- Εφέ Ανάκλασης
- Εφέ Λάμψης
- Μετασχηματισμός WordArt
- 3Δ Εφέ
- Εξωτερικό Εφέ Σκιάς
- Εσωτερικό Εφέ Σκιάς
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides για .NET. Αυτός ο οδηγός βήμα-βήμα βοηθά τους προγραμματιστές να βελτιώσουν τις παρουσιάσεις με επαγγελματικό κείμενο σε C#."
---
## **Επισκόπηση**

Τα εφέ WordArt σάς επιτρέπουν να μορφοποιήσετε το κείμενο με γεμίσεις, περίγραμμα, σκιές, ανακλάσεις, λάμψη, μετασχηματισμούς και 3Δ μορφοποίηση. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να προσαρμόσετε αυτά τα εφέ σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides for .NET, χωρίς εγκατεστημένο το Microsoft Office.

## **Δημιουργία ενός Απλού Προτύπου WordArt και Εφαρμογή του σε Κείμενο**

Τα παρακάτω παραδείγματα δημιουργούν ένα απλό στυλ WordArt ορίζοντας το κείμενο, τη γραμματοσειρά, τη γεμιστική μορφή μοτίβου και το περίγραμμα.

Κάθε παράδειγμα δημιουργεί μια νέα παρουσίαση και προσθέτει ένα ορθογώνιο στην πρώτη διαφάνεια· δεν απαιτείται αρχείο εισόδου. Το πρώτο παράδειγμα ορίζει το κείμενο σε "Aspose.Slides". Η θέση και οι διαστάσεις του σχήματος μετρώνται σε μονάδες (points):
```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Ορίστε τη γραμματοσειρά σε Arial Black σε μέγεθος 36 points για να είναι πιο εμφανής η μορφοποίηση:
```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

Εφαρμόστε ένα μοτίβο [SmallGrid](https://reference.aspose.com/slides/el/net/aspose.slides/patternstyle/) με σκούρο πορτοκαλί χρώμα προσκηνίου και λευκό φόντο, στη συνέχεια προσθέστε ένα μαύρο περίγραμμα κειμένου με πλάτος 1 point:
```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Το παραγόμενο κείμενο:
![Το απλό πρότυπο WordArt](WordArt_template.png)

## **Εφαρμογή Άλλων Εφέ WordArt**

Τα παρακάτω παραδείγματα δείχνουν πώς να εφαρμόσετε σκιές, ανακλάσεις, λάμψη, μετασχηματισμούς και 3Δ εφέ στο κείμενο.

### **Εφαρμογή Εξωτερικών Σκιών**

Μια εξωτερική σκιά προσθέτει βάθος τοποθετώντας μια σκιά πίσω από το κείμενο. Μπορείτε να προσαρμόσετε το χρώμα, την κατεύθυνση, την απόσταση, την ακτίνα θολώματος, την κλίμακα και την κλίση της.

Αυτό το παράδειγμα καλεί την μέθοδο [EnableOuterShadowEffect](https://reference.aspose.com/slides/el/net/aspose.slides/effectformat/enableoutershadoweffect/) και ορίζει μια μαύρη σκιά με ακτίνα θολώματος 4 point, κατεύθυνση 230 μοίρες και απόσταση 30 point. Οι τιμές κλίμακας 100 διατηρούν το μέγεθος της σκιάς, ενώ η οριζόντια κλίση την περιστρέφει κατά 20 μοίρες. Η μετατροπή άλφα θέτει τη διαφάνεια στο 32%:
```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

Το παραγόμενο κείμενο:
![Το εφέ Εξωτερικής Σκιάς](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Όταν χρησιμοποιούνται ταυτόχρονα εξωτερικές και προκαθορισμένες σκιές, εφαρμόζεται μόνο η εξωτερική σκιά.
- Εάν χρησιμοποιούνται ταυτόχρονα εξωτερικές και εσωτερικές σκιές, το αποτέλεσμα εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013 το εφέ διπλασιάζεται, ενώ στο PowerPoint 2007 εφαρμόζεται μόνο η εξωτερική σκιά.
{{% /alert %}}

### **Εφαρμογή Εφέ Ανάκλασης**

Μια ανάκλαση δημιουργεί ένα καθρεπτικό αντίγραφο του κειμένου. Ρυθμίστε τη θέση, την κλίμακα, το θόλωμα και τη διαφάνεια για να ελέγξετε την εμφάνισή της.

Αυτό το παράδειγμα καλεί την μέθοδο [EnableReflectionEffect](https://reference.aspose.com/slides/el/net/aspose.slides/effectformat/enablereflectioneffect/) και ανεστρέφει την ανάκλαση κατακόρυφα με κλίμακα -100%. Χρησιμοποιεί ακτίνα θολώματος 0.5 point και απόσταση 4.72 point. Η διαφάνεια μειώνεται από 60% σε 0.9% μεταξύ θέσεων 0% και 60% κατά μήκος της ανάκλασης:
```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
```

Το παραγόμενο κείμενο:
![Το εφέ Ανάκλασης](reflection_effect.png)

### **Εφαρμογή Εφέ Λάμψης**

Μια λάμψη προσθέτει ένα ήπιο χρωματιστό περίγραμμα γύρω από το κείμενο. Ρυθμίστε το χρώμα, τη διαφάνεια και την ακτίνα για να ελέγξετε το εφέ.

Αυτό το παράδειγμα καλεί την μέθοδο [EnableGlowEffect](https://reference.aspose.com/slides/el/net/aspose.slides/effectformat/enablegloweffect/) και εφαρμόζει μια κόκκινη λάμψη με 54% διαφάνεια και ακτίνα 7 points:
```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Το παραγόμενο κείμενο:
![Το εφέ Λάμψης](glow_effect.png)

### **Εφαρμογή Μετασχηματισμών WordArt**

Οι μετασχηματισμοί WordArt λυγίζουν, τεντώνουν ή παραμορφώνουν ένα τμήμα κειμένου.

Ορίστε το [Transform](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat/transform/) σε [ArchUpPour](https://reference.aspose.com/slides/el/net/aspose.slides/textshapetype/) για να κυρτώσετε το σύνολο του πλαισίου κειμένου προς τα πάνω:
```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Το παραγόμενο κείμενο:
![Ο μετασχηματισμός WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET παρέχει ένα σύνολο προεπιλεγμένων [transformation types](https://reference.aspose.com/slides/el/net/aspose.slides/textshapetype/).
{{% /alert %}}

### **Εφαρμογή 3Δ Εφέ σε Σχήματα και Κείμενο**

Μπορείτε να εφαρμόσετε 3Δ εφέ σε ένα σχήμα ή στο κείμενό του. Οι κλίσεις, η εξώθηση, ο φωτισμός και οι ρυθμίσεις της κάμερας ελέγχουν την τελική εμφάνιση.

Το παρακάτω παράδειγμα χρησιμοποιεί το [ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/) για να προσθέσει κυκλικές κλίσεις, πορτοκαλί εξώθηση και σκοτεινό κόκκινο περίγραμμα στο ορθογώνιο. Οι διαστάσεις της κλίσης, το ύψος εξώθησης, το πλάτος και το βάθος του περιγράμματος μετρώνται σε points. Ένα πλαστικό υλικό, ισορροπημένος φωτισμός με περιστροφή 40 μοίρες γύρω από τον άξονα Z, και μια προοπτική κάμερα καθορίζουν την εμφάνισή του:
```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
autoShape.TextFrame.Text = "Aspose.Slides";

autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Το παραγόμενο σχήμα:
![Το εφέ 3Δ του σχήματος](shape_3D_effect.png)

Αυτό το παράδειγμα εφαρμόζει παρόμοια 3Δ μορφοποίηση στο κείμενο μέσω του [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat/threedformat/). Μικρότερες κλίσεις διαμορφώνουν τις άκρες των γραμμάτων, ενώ η εξώθηση και ο φωτισμός προσδίδουν βάθος στο κείμενο:
```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";

textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Το παραγόμενο κείμενο:
![Το εφέ 3Δ του κειμένου](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Η εφαρμογή 3Δ εφέ σε κείμενο ή στα σχήματά του—και η αλληλεπίδραση μεταξύ αυτών των εφέ—ρυθμίζεται από συγκεκριμένους κανόνες. Σκεφτείτε μια σκηνή που περιλαμβάνει τόσο το κείμενο όσο και το σχήμα που το περιέχει. Ένα 3Δ εφέ περιλαμβάνει την 3Δ αναπαράσταση του αντικειμένου και τη σκηνή στην οποία τοποθετείται.

- Εάν έχει οριστεί σκηνή τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος έχει προτεραιότητα και η σκηνή του κειμένου αγνοείται.
- Εάν το σχήμα δεν έχει δική του σκηνή αλλά διαθέτει 3Δ αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου.
- Εάν το σχήμα δεν έχει κανένα 3Δ εφέ, θεωρείται επίπεδο και το 3Δ εφέ εφαρμόζεται μόνο στο κείμενο.

Αυτές οι συμπεριφορές σχετίζονται με τις ιδιότητες [ThreeDFormat.LightRig](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/lightrig/) και [ThreeDFormat.Camera](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Για να διατηρήσετε το κείμενο επίπεδο και ευανάγνωστο ενώ διατηρείτε τη 3Δ μορφοποίηση του σχήματος του, δείτε το [Keep Text Flat on a 3D Shape](/slides/el/net/3d-presentation/) για σύγκριση και ένα πλήρες παράδειγμα C#.

## **Συχνές Ερωτήσεις**

**Μπορώ να χρησιμοποιήσω εφέ WordArt με διαφορετικές γραμματοσειρές ή γραπτά (π.χ., Αραβικά, Κινεζικά);**

Ναι, το Aspose.Slides for .NET υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και γραφές. Τα εφέ WordArt όπως σκιά, γέμιση και περίγραμμα μπορούν να εφαρμοστούν ανεξάρτητα από τη γλώσσα, αν και η διαθεσιμότητα των γραμματοσειρών και η απόδοση ενδέχεται να εξαρτώνται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του master slide;**

Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα των master slides, συμπεριλαμβανομένων των placeholders τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές που γίνονται στη διάταξη του master θα αντικατοπτρίζονται σε όλες τις συσχετισμένες διαφάνειες.

**Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου παρουσίασης;**

Ελαφρώς. Τα εφέ WordArt όπως σκιές, λάμψη και διαβαθμισμένες γεμίσεις μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, αλλά η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προεπισκοπήσω το αποτέλεσμα των εφέ WordArt χωρίς να αποθηκεύσω την παρουσίαση;**

Ναι, μπορείτε να αποδώσετε τις διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ., PNG, JPEG) χρησιμοποιώντας την [ISlide.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/islide/getimage/), ή να αποδώσετε μεμονωμένα σχήματα μέσω της [IShape.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/getimage/). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξάγετε ολόκληρη την παρουσίαση.
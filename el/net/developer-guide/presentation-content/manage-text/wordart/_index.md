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
- Εφέ σκιάς
- Εφέ εμφάνισης
- Εφέ λάμψης
- Μετασχηματισμός WordArt
- 3Δ εφέ
- Εξωτερική σκιά
- Εσωτερική σκιά
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε εφέ WordArt στο Aspose.Slides για .NET. Αυτός ο οδηγός βήμα-βήμα βοηθά τους προγραμματιστές να ενισχύσουν τις παρουσιάσεις με επαγγελματικό κείμενο σε C#."
---
## **Επισκόπηση**

Τα εφέ WordArt σάς επιτρέπουν να προσθέσετε οπτικά ελκυστικό, μορφοποιημένο κείμενο στις παρουσιάσεις PowerPoint. Με το Aspose.Slides for .NET, οι προγραμματιστές μπορούν να δημιουργούν, προσαρμόζουν και να διαχειρίζονται WordArt προγραμματικά, όπως στο Microsoft PowerPoint—χωρίς να απαιτείται εγκατάσταση του Office. Αυτό το άρθρο παρέχει μια επισκόπηση της εργασίας με WordArt σε .NET, συμπεριλαμβανομένου του πώς να εφαρμόζετε μετασχηματισμούς κειμένου, στυλ γεμισμάτων, περιγράμματα, σκιές και άλλες επιλογές μορφοποίησης για να κάνετε το περιεχόμενο της παρουσίασής σας πιο εκφραστικό και ελκυστικό. Το WordArt σας επιτρέπει να αντιμετωπίζετε το κείμενο ως γραφικό αντικείμενο. Αποτελείται από εφέ ή ειδικές τροποποιήσεις που εφαρμόζονται στο κείμενο για να το κάνουν πιο ελκυστικό ή εμφανές.

## **Δημιουργία ενός Απλού Προτύπου WordArt και Εφαρμογή του σε Κείμενο**

Σε αυτήν την ενότητα, θα εξερευνήσουμε πώς να δημιουργήσουμε ένα απλό πρότυπο WordArt και να το εφαρμόσουμε σε κείμενο χρησιμοποιώντας το Aspose.Slides for .NET. Το WordArt προσφέρει έναν εύκολο τρόπο ενίσχυσης της εμφάνισης του κειμένου με εντυπωσιακά οπτικά εφέ και στυλ. Μαθαίνοντας τα βασικά βήματα δημιουργίας και χρήσης του WordArt, μπορείτε άμεσα να προσαρμόσετε αυτές τις τεχνικές σε οποιοδήποτε έργο, καθιστώντας τις παρουσιάσεις σας πιο ζωντανές και αξέχαστες.

Πρώτα, δημιουργούμε απλό κείμενο με τον ακόλουθο κώδικα C#:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

Τώρα, ορίζουμε το ύψος γραμματοσειράς του κειμένου σε μεγαλύτερη τιμή ώστε το εφέ να είναι πιο εμφανές, χρησιμοποιώντας τον ακόλουθο κώδικα:

```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```

Εδώ, εφαρμόζουμε το γεμιστικό μοτίβο SmallGrid στο κείμενο και προσθέτουμε ένα μαύρο περίγραμμα κειμένου με πλάτος 1, χρησιμοποιώντας τον ακόλουθο κώδικα:

```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Το παραγόμενο κείμενο:

![The simple WordArt template](WordArt_template.png)

## **Εφαρμογή Άλλων Εφέ WordArt**

Εκτός από βασικούς μετασχηματισμούς, το Aspose.Slides for .NET σας επιτρέπει να εφαρμόσετε μια ποικιλία προχωρημένων εφέ WordArt για να βελτιώσετε την εμφάνιση του κειμένου σας. Αυτά περιλαμβάνουν περιγράμματα, γεμίσματα, σκιές, αντανακλάσεις και εφέ λάμψης. Συνδυάζοντας αυτές τις δυνατότητες, μπορείτε να δημιουργήσετε εντυπωσιακά στυλ κειμένου που ξεχωρίζουν στις παρουσιάσεις σας. Η ενότητα αυτή δείχνει πώς να εφαρμόζετε αυτά τα εφέ προγραμματικά με απλά, καθαρά δείγματα κώδικα.

### **Εφαρμογή Εξωτερικών Σκιών**

Τα εφέ εξωτερικής σκιάς βοηθούν το κείμενο να ξεχωρίζει προσθέτοντας μια σκιά πίσω από το περίγραμμά του, δημιουργώντας αίσθηση βάθους και απομάκρυνσης από το φόντο. Το Aspose.Slides for .NET επιτρέπει την εύκολη εφαρμογή και προσαρμογή εξωτερικών σκιών σε κείμενο WordArt. Σε αυτήν την ενότητα, θα μάθετε πώς να ορίζετε χρώμα σκιάς, κατεύθυνση, απόσταση, ακτίνα θολώματος και άλλα για να πετύχετε το επιθυμητό οπτικό αποτέλεσμα.

Το παρακάτω απόσπασμα κώδικα C# εφαρμόζει ένα εφέ σκιάς στο κείμενο που δημιουργήθηκε παραπάνω.

```cs
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

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="primary" %}} 
- Όταν χρησιμοποιούνται μαζί OuterShadow και PresetShadow, εφαρμόζεται μόνο το εφέ OuterShadow.
- Αν χρησιμοποιηθούν ταυτόχρονα OuterShadow και InnerShadow, το τελικό εφέ εξαρτάται από την έκδοση του PowerPoint. Για παράδειγμα, στο PowerPoint 2013 το εφέ διπλασιάζεται, ενώ στο PowerPoint 2007 εφαρμόζεται μόνο το εφέ OuterShadow.
{{% /alert %}}

### **Εφαρμογή Εφέ Αντανάκλασης**

Σε αυτήν την ενότητα, θα εξερευνήσουμε πώς να εφαρμόσετε εφέ αντανάκλασης στις διαφάνειές σας χρησιμοποιώντας το Aspose.Slides for .NET. Τα εφέ αντανάκλασης μπορούν να δώσουν στο κείμενο ή στα σχήματά σας μια κομψή και σύγχρονη εμφάνιση, βοηθώντας τα βασικά στοιχεία να ξεχωρίζουν και προσθέτοντας βάθος στην παρουσίασή σας. Κατανοώντας τη διαδικασία εφαρμογής και προσαρμογής αυτών των εφέ, μπορείτε εύκολα να τα προσαρμόσετε στις ανάγκες σχεδίασης και την εταιρική σας ταυτότητα.

Προσθέστε ένα εφέ αντανάκλασης στο κείμενο με το ακόλουθο παράδειγμα κώδικα C#:

```cs
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

![The Reflection effect](reflection_effect.png)

### **Εφαρμογή Εφέ Λάμψης**

Σε αυτήν την ενότητα, θα εξερευνήσουμε πώς να εφαρμόσετε ένα εφέ λάμψης σε κείμενο χρησιμοποιώντας το Aspose.Slides for .NET. Το εφέ λάμψης μπορεί να κάνει το κείμενό σας πιο εμφανές με ένα φωτεινό περίγραμμα, ενισχύοντας την οπτική ελκυστικότητα των διαφανειών σας. Ρυθμίζοντας παραμέτρους όπως το χρώμα και η ένταση, μπορείτε εύκολα να προσαρμόσετε τη λάμψη ώστε να ταιριάζει στο σχεδιασμό και την εταιρική σας εικόνα, διασφαλίζοντας ότι τα βασικά σημεία της παρουσίασής σας κεντρίζουν την προσοχή του κοινού.

Εφαρμόστε ένα εφέ λάμψης στο κείμενο ώστε να λάμπει ή να ξεχωρίσει, χρησιμοποιώντας τον ακόλουθο κώδικα:

```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Το παραγόμενο κείμενο:

![The Glow effect](glow_effect.png)

### **Εφαρμογή Μετασχηματισμών WordArt**

Σε αυτήν την ενότητα, θα εξερευνήσουμε πώς να χρησιμοποιήσετε μετασχηματισμούς στο WordArt με το Aspose.Slides for .NET. Οι μετασχηματισμοί σάς επιτρέπουν να κάμπτετε, να τεντώνετε ή να παραμορφώνετε το κείμενο, δημιουργώντας μοναδικά και εντυπωσιακά οπτικά εφέ. Καθώς δεσμεύεστε σε αυτές τις τεχνικές, μπορείτε εύκολα να προσαρμόσετε τα σχήματα και τα στυλ του κειμένου ώστε να ταιριάζουν στην εταιρική σας ταυτότητα ή δημιουργική σας όραση, διασφαλίζοντας μια πειστική και εκλεπτυσμένη παρουσίαση.

Χρησιμοποιήστε την ιδιότητα `Transform` (που εφαρμόζεται σε ολόκληρο το μπλοκ κειμένου) με τον ακόλουθο κώδικα:

```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Το παραγόμενο κείμενο:

![The WordArt transformation](transform_effect.png)

{{% alert color="primary" %}} 
Το Aspose.Slides for .NET παρέχει ένα σύνολο προεγκατεστημένων [τύπους μετασχηματισμού](https://reference.aspose.com/slides/el/net/aspose.slides/textshapetype/).
{{% /alert %}} 

### **Εφαρμογή 3D Εφέ σε Σχήματα και Κείμενο**

Η δημιουργία ρεαλιστικών, εντυπωσιακών οπτικών μπορεί να βελτιώσει σημαντικά την απήχηση των παρουσιάσεών σας. Σε αυτήν την ενότητα, θα εξερευνήσουμε πώς να εφαρμόσετε τρισδιάστατα (3D) εφέ σε σχήματα χρησιμοποιώντας το Aspose.Slides for .NET. Με την τροποποίηση παραμέτρων όπως το βάθος, η γωνία και ο φωτισμός, μπορείτε να παράγετε εντυπωσιακούς 3D μετασχηματισμούς που τραβούν αμέσως την προσοχή του κοινού σας. Είτε στοχεύετε σε ήπιες επισημάνσεις είτε σε δραματικές ψευδαισθήσεις, αυτές οι δυνατότητες προσφέρουν ευέλικτους τρόπους αναβάθμισης του σχεδίου σας και μετάδοσης ιδεών με πιο ελκυστικό τρόπο.

Χρησιμοποιήστε τον παρακάτω δείγμα κώδικα για να ορίσετε ένα 3D εφέ στο σχήμα:

```cs
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

![The shape 3D effect](shape_3D_effect.png)

Χρησιμοποιήστε τον παρακάτω δείγμα κώδικα για να ορίσετε ένα 3D εφέ στο κείμενο:

```cs
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Το παραγόμενο κείμενο:

![The text 3D effect](text_3D_effect.png)

{{% alert color="primary" %}} 
Η εφαρμογή 3D εφέ σε κείμενο ή στα σχήματά του—και η αλληλεπίδραση μεταξύ αυτών των εφέ—ρυθμίζεται από συγκεκριμένους κανόνες. Σκεφτείτε μια σκηνή που περιλαμβάνει τόσο κείμενο όσο και το σχήμα που το περιέχει. Ένα 3D εφέ περιλαμβάνει την τρισδιάστατη αναπαράσταση του αντικειμένου και τη σκηνή στην οποία τοποθετείται.

- Εάν οριστεί σκηνή τόσο για το σχήμα όσο και για το κείμενο, η σκηνή του σχήματος έχει προτεραιότητα και η σκηνή του κειμένου αγνοείται.
- Εάν το σχήμα δεν έχει δική του σκηνή αλλά διαθέτει τρισδιάστατη αναπαράσταση, χρησιμοποιείται η σκηνή του κειμένου.
- Εάν το σχήμα δεν έχει καθόλου 3D εφέ, θεωρείται επίπεδο, και το 3D εφέ εφαρμόζεται μόνο στο κείμενο.

Αυτές οι συμπεριφορές σχετίζονται με τις ιδιότητες [ThreeDFormat.LightRig](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/lightrig/) και [ThreeDFormat.Camera](https://reference.aspose.com/slides/el/net/aspose.slides/threedformat/camera/).
{{% /alert %}} 

## **Συχνές Ερωτήσεις**

**Μπορώ να χρησιμοποιήσω εφέ WordArt με διαφορετικές γραμματοσειρές ή συστήματα γραφής (π.χ., Αραβικά, Κινέζικα);**

Ναι, το Aspose.Slides for .NET υποστηρίζει Unicode και λειτουργεί με όλες τις κύριες γραμματοσειρές και συστήματα γραφής. Τα εφέ WordArt όπως σκιά, γέμισμα και περίγραμμα μπορούν να εφαρμοστούν ανεξάρτητα από τη γλώσσα, αν και η διαθεσιμότητα των γραμματοσειρών και η απόδοση μπορεί να εξαρτώνται από τις γραμματοσειρές του συστήματος.

**Μπορώ να εφαρμόσω εφέ WordArt σε στοιχεία του master slide;**

Ναι, μπορείτε να εφαρμόσετε εφέ WordArt σε σχήματα στα master slides, συμπεριλαμβανομένων των placeholders τίτλου, υποσέλιδων ή κειμένου φόντου. Οι αλλαγές που γίνονται στη διάταξη του master θα αντικατοπτρίζονται σε όλες τις συνδεδεμένες διαφάνειες.

**Επηρεάζουν τα εφέ WordArt το μέγεθος του αρχείου παρουσίασης;**

Ελαφρώς. Τα εφέ WordArt όπως σκιές, λάμψεις και γεμίσματα διαβάθμισης μπορεί να αυξήσουν ελαφρώς το μέγεθος του αρχείου λόγω πρόσθετων μεταδεδομένων μορφοποίησης, όμως η διαφορά είναι συνήθως αμελητέα.

**Μπορώ να προεπισκοπήσω το αποτέλεσμα των εφέ WordArt χωρίς να αποθηκεύσω την παρουσίαση;**

Ναι, μπορείτε να αποδώσετε διαφάνειες που περιέχουν WordArt σε εικόνες (π.χ., PNG, JPEG) χρησιμοποιώντας τη μέθοδο `GetImage` από τις διεπαφές [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) ή [ISlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide/). Αυτό σας επιτρέπει να προεπισκοπήσετε το αποτέλεσμα στη μνήμη ή στην οθόνη πριν αποθηκεύσετε ή εξαγάγετε ολόκληρη την παρουσίαση.
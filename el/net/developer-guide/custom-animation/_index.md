---
title: Δημιουργία και τροποποίηση προσαρμοσμένων συμπεριφορών κίνησης σε .NET
linktitle: Προσαρμοσμένη κίνηση
type: docs
weight: 151
url: /el/net/custom-animation/
keywords:
- προσαρμοσμένη κίνηση
- συμπεριφορά κίνησης
- διαδρομή κίνησης
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε, εξετάστε και τροποποιήστε προσαρμοσμένες συμπεριφορές κίνησης και επεξεργάσιμες διαδρομές κίνησης σε παρουσιάσεις PowerPoint με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Οι προσαρμοσμένες συμπεριφορές κίνησης σάς επιτρέπουν να ελέγχετε μεμονωμένες λειτουργίες εντός ενός εφέ κίνησης, όπως η αλλαγή χρώματος, η περιστροφή σχήματος ή η ακολουθία επεξεργάσιμης διαδρομής κίνησης. Αυτός ο οδηγός δείχνει πώς να δημιουργείτε και να συνδυάζετε συμπεριφορές, να ρυθμίζετε το χρονισμό τους, να εξετάζετε και να τροποποιείτε υπάρχουσες κινήσεις και να επαληθεύετε ότι οι ιδιότητές τους διατηρούνται κατά την αποθήκευση και το άνοιγμα μιας παρουσίασης.

Για προεπιλεγμένα εφέ και ενεργοποιητές κλικ, δείτε το [Κίνηση Σχήματος](/slides/el/net/shape-animation/).

## **Κατανόηση του Μοντέλου Κίνησης**

Μια κίνηση οργανώνεται ως **Timeline → Sequence → Effect → Behaviors**:

- Το [Timeline](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/timeline/) του διαφάνειας περιέχει τη κύρια ακολουθία του και διαδραστικές ακολουθίες.
- Ένα [ISequence](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/) περιέχει εφέ, ενδεχομένως με στόχο διαφορετικά σχήματα.
- Ένα [IEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/) καθορίζει ένα σχήμα-στόχο, preset, υπότυπο και το χρόνο του εφέ.
- Το [IEffect.Behaviors](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/behaviors/) περιέχει τις λειτουργίες που υλοποιούν το εφέ: αλλαγή χρώματος, μετακίνηση, περιστροφή, ορισμό ιδιότητας κ.ά.

## **Δημιουργία Μεμονωμένων Συμπεριφορών**

Κλήστε το [ISequence.AddEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/isequence/addeffect/) για να δημιουργήσετε ένα εφέ και να αποκτήσετε πρόσβαση στη συλλογή [Behaviors](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/behaviors/). Ένας preset μπορεί να γεμίσει αυτόματα τη συλλογή. Διατηρήστε τις λειτουργίες του όταν επεκτείνετε το preset, ή χρησιμοποιήστε το [Clear](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorcollection/clear/) όταν αντικαθιστάτε σκόπιμα.

[IBehaviorFactory](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorfactory/) δημιουργεί τους οκτώ τύπους συμπεριφοράς που απεικονίζονται παρακάτω. Η κίνηση καλύπτεται στο [Build a Motion Path](#build-a-motion-path). Κάθε παράδειγμα δημιουργίας είναι ένα πλήρες πρόγραμμα· τα επόμενα παραδείγματα επεξεργασίας δηλώνουν ποιο αρχείο εξόδου χρησιμοποιούν.

### **Περιστροφή**

Χρησιμοποιήστε το [CreateRotationEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) για να δημιουργήσετε μια περιστροφή. Το [By](https://reference.aspose.com/slides/el/net/aspose.slides.animation/irotationeffect/by/) ορίζει μια σχετική γωνία σε μοίρες· τα [From](https://reference.aspose.com/slides/el/net/aspose.slides.animation/irotationeffect/from/) και [To](https://reference.aspose.com/slides/el/net/aspose.slides.animation/irotationeffect/to/) καθορίζουν τα άκρα.

Το παράδειγμα ξεκινά με ένα εφέ Spin, αντικαθιστά τις προεπιλεγμένες λειτουργίες του με μία συμπεριφορά περιστροφής και δίνει σε αυτήν διάρκεια δύο δευτερολέπτων. Μια σχετική γωνία 90 μοιρών εκφράζει μια τεταρτηροκύκληση από την αρχική προσανατολισμό του σχήματος, οπότε δεν απαιτείται ρητή γωνία εκκίνησης.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` περιέχει ένα σχήμα και μία συμπεριφορά περιστροφής. Η συλλογή, ο χρονισμός και τα παραδείγματα επεξεργασίας περιστροφής παρακάτω χρησιμοποιούν αυτό το αρχείο.

### **Κλιμάκωση**

Χρησιμοποιήστε το [CreateScaleEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) με ποσοστά X/Y: τα [From](https://reference.aspose.com/slides/el/net/aspose.slides.animation/iscaleeffect/from/) και [To](https://reference.aspose.com/slides/el/net/aspose.slides.animation/iscaleeffect/to/) περιγράφουν το αρχικό και το τελικό μέγεθος, ενώ το [By](https://reference.aspose.com/slides/el/net/aspose.slides.animation/iscaleeffect/by/) περιγράφει μια σχετική αλλαγή. Εδώ, το 100 σημαίνει το αρχικό μέγεθος.

Το παράδειγμα αυξάνει και τις δύο διαστάσεις από 100 % σε 125 % σε δύο δευτερόλεπτα. Η χρήση ίσων οριζόντιων και κάθετων ποσοστών διατηρεί τις αναλογίες του σχήματος· διαφορετικά ποσοστά θα τράχουν μία διάσταση περισσότερο από την άλλη.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **Χρώμα**

Χρησιμοποιήστε το [CreateColorEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) για να αλλάξετε τη γέμιση από μπλε σε πορτοκαλί. Τα [From](https://reference.aspose.com/slides/el/net/aspose.slides.animation/icoloreffect/from/) και [To](https://reference.aspose.com/slides/el/net/aspose.slides.animation/icoloreffect/to/) είναι χρώματα· το [By](https://reference.aspose.com/slides/el/net/aspose.slides.animation/icoloreffect/by/) είναι μια μετατόπιση χρώματος. Το [IBehavior.Properties](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehavior/properties/) προσδιορίζει το χαρακτηριστικό που ανιχνεύεται.

Η γεμιστική συμπλήρωση του σχήματος αρχικοποιείται σε μπλε, ταιριάζοντας με το αρχικό χρώμα της κίνησης. Η επιλογή του χαρακτηριστικού fill-color λέει στη συμπεριφορά ποιο μέρος του σχήματος να αλλάξει· τα άκρα χρώματος μόνο του δεν προσδιορίζουν αυτό το χαρακτηριστικό. Το αποθηκευμένο εφέ περιγράφει μια διευθέτηση δύο δευτερολέπτων στο πορτοκαλί.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **Φίλτρο**

Χρησιμοποιήστε το [CreateFilterEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) για να επιλέξετε ένα wipe. Τα [Type](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ifiltereffect/subtype/), και [Reveal](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ifiltereffect/reveal/) καθορίζουν το φίλτρο, την κατεύθυνση και το αν θα αποκαλυφθεί ή θα κρυφτεί το σχήμα.

Αυτό το παράδειγμα ρυθμίζει ένα wipe δύο δευτερολέπτων που αποκαλύπτει το σχήμα χρησιμοποιώντας το υποτύπο κατεύθυνσης δεξιά. Οι ρυθμίσεις του φίλτρου ανήκουν στη συμπεριφορά εντός του εφέ, έτσι ρυθμίζονται μετά την αφαίρεση των αρχικών λειτουργιών του preset.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **Ιδιότητα**

Χρησιμοποιήστε το [CreatePropertyEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) για να κινήσετε τη διαφάνεια. Τα [From](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ipropertyeffect/to/), και [By](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ipropertyeffect/by/) είναι συμβολοσειρές που ερμηνεύονται χρησιμοποιώντας [ValueType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ipropertyeffect/valuetype/) και [CalcMode](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ipropertyeffect/calcmode/). Επιλέξτε άκρα ή σχετική μετατόπιση αντί να ορίσετε και τα τρία αδιάφορα.

Εδώ, το επιλεγμένο χαρακτηριστικό είναι η διαφάνεια, και οι αριθμητικές συμβολοσειρές αντιπροσωπεύουν μια αλλαγή από 25 % διαφάνειας σε πλήρη διαφάνεια. Η γραμμική παρεμβολή περιγράφει μια σταδιακή αλλαγή μεταξύ αυτών των τιμών. Όταν προσαρμόζετε αυτό το παράδειγμα σε άλλο χαρακτηριστικό, επιλέξτε έναν τύπο τιμής και τιμές άκρων κατάλληλες για το χαρακτηριστικό αυτό.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **Ορισμός**

Χρησιμοποιήστε το [CreateSetEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) για να ορίσετε την ορατότητα μέσω του [To](https://reference.aspose.com/slides/el/net/aspose.slides.animation/iseteffect/to/). Μια συμπεριφορά set δεν παρεμβάλλει μεταξύ των άκρων.

Το παράδειγμα επιλέγει το χαρακτηριστικό ορατότητας και εκχωρεί τη συμβολοσειρά `visible` όταν εκτελείται η συμπεριφορά. Το ορθογώνιο είναι ήδη ορατό σε αυτήν την ελάχιστη παρουσίαση, έτσι η εκχώρηση ίσως να μην προκαλέσει εμφανή οπτική αλλαγή από μόνη της. Μια τέτοια λειτουργία είναι χρήσιμη ως μέρος ενός μεγαλύτερου εφέ που ελέγχει επίσης πότε το σχήμα κρύβεται ή εμφανίζεται.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **Εντολή**

Χρησιμοποιήστε το [CreateCommandEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) και διαμορφώστε τα [Type](https://reference.aspose.com/slides/el/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/el/net/aspose.slides.animation/icommandeffect/commandstring/), και [ShapeTarget](https://reference.aspose.com/slides/el/net/aspose.slides.animation/icommandeffect/shapetarget/). Τοποθετήστε μια ηχογράφηση WAV με όνομα `sample.wav` στον τρέχοντα φάκελο εργασίας. Αυτό το παράδειγμα την ενσωματώνει με το [AddAudioFrameEmbedded](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addaudioframeembedded/) και συνδέει μια εντολή αναπαραγωγής στο πλαίσιο ήχου.

Το πλαίσιο ήχου είναι ταυτόχρονα ο στόχος του εφέ και ο στόχος της εντολής. Αυτό συνδέει το αίτημα αναπαραγωγής στην ενσωματωμένη ηχογράφηση· μια συμβολοσειρά εντολής από μόνη της δεν προσδιορίζει ποιο αντικείμενο πολυμέσων να ελέγξει. Το εφέ ρυθμίζεται να ξεκινά με κλικ κατά τη διάρκεια της παρουσίασης.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

Η αποθήκευση αποθηκεύει την εντολή στο `command.pptx`; δεν αναπαράγει την ηχογράφηση. Η αναπαραγωγή απαιτεί έναν προγραμματιστή παρουσίασης που υποστηρίζει την εντολή και τον στόχο πολυμέσων της.

## **Διαχείριση της Συλλογής Συμπεριφορών**

[IBehaviorCollection](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorcollection/) υποστηρίζει τα [Add](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorcollection/remove/), και [RemoveAt](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorcollection/removeat/). Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, προσθέτει κλιμάκωση, τη μετακινεί πριν την περιστροφή και αφαιρεί την περιστροφή. Η αφαίρεση και η επανατοποθέτηση του ίδιου αντικειμένου αλλάζει τη θέση του αποθηκευμένου αντικειμένου χωρίς να δημιουργεί αντίγραφο.

Η σειρά των επεξεργασιών αλλάζει τη συλλογή από περιστροφή–κλιμάκωση σε κλιμάκωση–περιστροφή, στη συνέχεια μόνο κλιμάκωση. Τα ευρετήρια αναφέρονται στην τρέχουσα συλλογή, έτσι η αφαίρεση χρησιμοποιεί το νέο ευρετήριο της περιστροφής μετά την αναδιάταξη. Η τελική απαρίθμηση επιβεβαιώνει ποια συμπεριφορά θα αποθηκευτεί.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

Η έξοδος είναι `ScaleEffect`: παραμένει μόνο η κλιμάκωση. Η σειρά της συλλογής από μόνη της δεν προγραμματίζει τις συμπεριφορές μία μετά την άλλη. Καθαρίστε τη συλλογή μόνο όταν αντικαθιστάτε όλες τις λειτουργίες της.

## **Ρύθμιση Χρονισμού Συμπεριφοράς**

[IBehavior.Timing](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehavior/timing/) εκθέτει το [ITiming](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/), ανεξάρτητα από το [IEffect.Timing](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/timing/). Ο χρονισμός του εφέ προγραμματίζει το περιβάλλον εφέ· ο χρονισμός της συμπεριφοράς περιγράφει μια λειτουργία εντός αυτού.

### **Ορισμός Διάρκειας, Καθυστέρησης, Επανάληψης και Επιτάχυνσης**

Ανοίξτε το `rotation.pptx` και ορίστε τα [Duration](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/duration/) και [TriggerDelayTime](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/triggerdelaytime/) σε δευτερόλεπτα, στη συνέχεια διαμορφώστε το [RepeatCount](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatcount/). Τα [Accelerate](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/accelerate/) και [Decelerate](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/decelerate/) είναι κλάσματα της διάρκειας· κρατήστε το άθροισμά τους το πολύ 1.

Το αρχείο εισόδου είναι αυτό που δημιουργήθηκε στο παράδειγμα περιστροφής, όπου η πρώτη συμπεριφορά είναι γνωστή ως περιστροφή. Αυτό το παράδειγμα αλλάζει μόνο το χρονισμό εκείνης της συμπεριφοράς· η γωνία των 90 μοιρών παραμένει αμετάβλητη. Η διατήρηση της γωνίας και του χρονισμού ξεχωριστά διευκολύνει τη ρύθμιση του ρυθμού χωρίς επαναδημιουργία της κίνησης.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

Η συμπεριφορά χρησιμοποιεί διάρκεια δύο δευτερολέπτων, καθυστέρηση ενός μισού δευτερολέπτου και αριθμό επαναλήψεων 3. Το πρώτο και το τελευταίο 20 % της διάρκειάς της χρησιμοποιούνται για επιτάχυνση και επιβράδυνση.

Άλλες πολιτικές επανάληψης περιλαμβάνουν τα [RepeatDuration](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilendslide/), και [RepeatUntilNextClick](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/repeatuntilnextclick/); επιλέξτε μια πολιτική αντί να τις ενεργοποιήσετε όλες μαζί. Το [AutoReverse](https://reference.aspose.com/slides/el/net/aspose.slides.animation/itiming/autoreverse/) παίζει την κίνηση ανάποδα μετά το προώθηση. Η επιτάχυνση και η επιβράδυνση εφαρμόζονται σε συνεχείς αλλαγές, όχι σε διακριτές εκχωρήσεις ή εντολές.

## **Δημιουργία Διαδρομής Κίνησης**

Χρησιμοποιήστε το [CreateMotionEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) για να δημιουργήσετε κίνηση. Τα [From](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotioneffect/to/), και [By](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotioneffect/by/) περιγράφουν συντεταγμένες ή μετατοπίσεις βάσει ποσοστών. Για επεξεργάσιμη διαδρομή, δημιουργήστε ένα [MotionPath](https://reference.aspose.com/slides/el/net/aspose.slides.animation/motionpath/) και αντιστοιχίστε το στο [IMotionEffect.Path](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotioneffect/path/). Το [IMotionPath](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotionpath/) αποθηκεύει τις εντολές της διαδρομής.

| Εντολή | Σημεία | Σημασία |
| --- | --- | --- |
| MoveTo | One | Ορισμός της αρχικής θέσης. |
| LineTo | One | Μετακίνηση κατά μήκος ευθύ γραμμικού τμήματος προς το τέλος του. |
| CurveTo | Three | Ακολουθεί μια κυβάρια καμπύλη που ορίζεται από δύο σημεία ελέγχου και ένα σημείο τέλους. |
| CloseLoop | None | Επιστροφή στην αρχική θέση. |
| End | None | Ολοκλήρωση της διαδρομής. |

[MotionPathPointsType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/motionpathpointstype/) περιγράφει τις χαρακτηριστικές επεξεργασίας σημείων, όπως γωνιακά ή ομαλά σημεία. Δεν αντικαθιστά τον τύπο εντολής. Χρησιμοποιήστε έναν τύπο σημείου καμπύλης για το παράδειγμα καμπύλης παρακάτω και έναν τύπο σημείου γωνίας για τα ευθύγραμμα τμήματα.

Οι συντεταγμένες της διαδρομής είναι κανονικοποιημένες στις διαστάσεις της διαφάνειας: μια μετατόπιση X 0.25 αντιπροσωπεύει το ένα τέταρτο του πλάτους της διαφάνειας, όχι 0.25 μονάδες. Το θετικό Y κατευθύνεται προς τα κάτω. Οι απόλυτες εντολές καθορίζουν θέσεις στο σύστημα συντεταγμένων της διαδρομής· οι σχετικές εντολές καθορίζουν μετατοπίσεις από την τρέχουσα θέση. Αυτό είναι ξεχωριστό από το [Origin](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotioneffect/origin/), που επιλέγει το πλαίσιο αναφοράς της διαδρομής, και το [PathEditMode](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotioneffect/patheditmode/), που ελέγχει πώς η διαδρομή κινείται όταν μετακινείται το σχήμα.

### **Δημιουργία Ευθείας Διαδρομής**

Δημιουργήστε μια συμπεριφορά κίνησης με σημείο εκκίνησης, ένα ευθύ τμήμα και εντολή λήξης. Το [IMotionPath.Add](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotionpath/add/) δέχεται τον τύπο εντολής, τα σημεία του, τον τύπο σημείου και μια σημαία σχετικών συντεταγμένων.

Η εντολή εκκίνησης καθορίζει (0, 0), και η γραμμή τελειώνει στο (0.25, 0), δίνοντας στη διαδρομή μια οριζόντια μετατόπιση ενός τετάρτου του πλάτους της διαφάνειας. Η εντολή λήξης δεν έχει σημεία συντεταγμένων. Μόλις η διαδρομή ανατεθεί, η προσθήκη της συμπεριφοράς κίνησης στο εφέ συνδέει αυτή τη διαδρομή με το ορθογώνιο.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` περιέχει μία συμπεριφορά κίνησης με τρεις εντολές διαδρομής. Τα παρακάτω παραδείγματα επεξεργασίας αρχείου χρησιμοποιούν αυτή τη γνωστή δομή.

### **Σύγκριση Απόλυτων και Σχετικών Συντεταγμένων**

Αυτά τα δύο αντικείμενα διαδρομής περιγράφουν την ίδια διαδρομή. Η απόλυτη εντολή τελειώνει στο (0.3, 0.1); η σχετική εντολή προσθέτει (0.1, 0.1) στην τρέχουσα θέση, (0.2, 0).

Και οι δύο διαδρομές ξεκινούν από την ίδια θέση. Για τη σχετική γραμμή, προσθέστε τις X και Y μετατοπίσεις στην τρέχουσα θέση για να λάβετε το σημείο λήξης· για την απόλυτη γραμμή, διαβάστε το σημείο λήξης απευθείας. Η αλλαγή της σημαίας χωρίς να μετατρέψετε τις συντεταγμένες θα περιέγραφε διαφορετική διαδρομή.

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Αναθέστε οποιαδήποτε από τις διαδρομές σε μια συμπεριφορά κίνησης για να τη χρησιμοποιήσετε σε παρουσίαση. Το τελικό λογικό όρισμα επιλέγει σχετικές συντεταγμένες για εκείνη την εντολή.

### **Αντικατάσταση Γραμμής με Καμπύλη**

Ανοίξτε το `motion.pptx` και αντικαταστήστε την εντολή γραμμής του με μια κυβάρια καμπύλη. Παρέχετε πρώτα τα δύο σημεία ελέγχου, ακολουθούμενα από το σημείο τέλους.

Η θέση εκκίνησης παρέχεται από την προηγούμενη εντολή. Τα πρώτα δύο σημεία διαμορφώνουν την καμπύλη, ενώ το τρίτο είναι ο προορισμός της· δεν είναι τρία διαδοχικά σημεία προορισμού. Η ενημέρωση του τύπου εντολής, του τύπου επεξεργασίας σημείων και του πίνακα σημείων μαζί διατηρεί το τμήμα συνεπές με τη νέα γεωμετρία του.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

Η διαδρομή στο `curve.pptx` εξακολουθεί να έχει τρεις εντολές· η μεσαία εντολή τώρα ορίζει μια καμπύλη.

## **Επιθεώρηση και Επεξεργασία Αποθηκευμένης Διαδρομής**

Κάθε [IMotionCmdPath](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotioncmdpath/) εκθέτει τα [Points](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotioncmdpath/pointstype/), και [IsRelative](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotioncmdpath/isrelative/). Τα παρακάτω παραδείγματα χρησιμοποιούν τη γνωστή διαδρομή τριών εντολών στο `motion.pptx`. Για τυχαία είσοδο, εντοπίστε το επιθυμητό εφέ και ελέγξτε τους τύπους εντολών και τους αριθμούς σημείων πριν επεξεργαστείτε κατά ευρετήριο.

### **Ανάγνωση Εντολών και Συντεταγμένων**

Διαβάστε τη διαδρομή χωρίς να την αλλάξετε. Οι εντολές End και CloseLoop δεν χρειάζονται σημεία, επομένως επιτρέψτε έναν μηδενικό πίνακα σημείων.

Η έξοδος εμφανίζει ζεύγος κάθε εντολής με τη σημαία σχετικών συντεταγμένων πριν καταγράψει τα σημεία της. Αυτό σας επιτρέπει να διακρίνετε ένα σημείο λήξης από μια μετατόπιση πριν τροποποιήσετε τη διαδρομή. Μια καμπύλη θα εμφανίσει τρία σημεία, ενώ η ευθεία γραμμή σε αυτό το αρχείο εμφανίζει μόνο ένα.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

Η λίστα περιλαμβάνει ένα σημείο εκκίνησης, μία απόλυτη γραμμή που τελειώνει στο (0.25, 0), και μια εντολή λήξης.

### **Αλλαγή Τελικού Σημείου**

Ανοίξτε το `motion.pptx` και αντικαταστήστε τον πίνακα σημείων της γραμμής για να μετακινήσετε το τελικό της σημείο.

Στο αρχείο εισόδου, το ευρετήριο 0 είναι η εντολή εκκίνησης και το ευρετήριο 1 είναι η γραμμή. Η αντικατάσταση του μοναδικού σημείου της γραμμής αλλάζει τον προορισμό της χωρίς να αλλάζει τον τύπο εντολής, το χρόνο ή τη θέση στη συλλογή. Επειδή η εντολή χρησιμοποιεί απόλυτες συντεταγμένες, το νέο ζεύγος ορίζει θέση αντί για πρόσθετη μετατόπιση.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

Η γραμμή στο `motion-endpoint.pptx` τελειώνει στο (0.4, 0.1); το αρχικό αρχείο παραμένει αμετάβλητο.

### **Αντικατάσταση Τμήματος**

Χρησιμοποιήστε τα [Insert](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotionpath/insert/) και [RemoveAt](https://reference.aspose.com/slides/el/net/aspose.slides.animation/imotionpath/removeat/) για να αντικαταστήσετε τη γραμμή στο `motion.pptx`. Η εισαγωγή μετακινεί την παλαιά γραμμή στο ευρετήριο 2.

Αυτό δείχνει την αντικατάσταση ενός αντικειμένου εντολής αντί για την επεξεργασία των υπαρχουσών συντεταγμένων του. Μετά την εισαγωγή, η συλλογή περιέχει προσωρινά την εντολή εκκίνησης, τη νέα γραμμή, την παλαιά γραμμή και την εντολή λήξης. Η αφαίρεση του ευρετηρίου 2 απορρίπτει την παλαιά γραμμή και αφήνει τη νέα διαδρομή στη θέση της.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

Η αποθηκευμένη διαδρομή εξακολουθεί να έχει τρεις εντολές, με τη νέα γραμμή να τελειώνει στο (0.2, 0.1) και την εντολή λήξης τελευταία.

## **Τροποποίηση και Επαλήθευση Υπάρχουσας Συμπεριφοράς**

Όταν το ευρετήριο της συμπεριφοράς είναι άγνωστο, επιλέξτε το κατά τύπο. Αυτό το παράδειγμα ανοίγει το `rotation.pptx`, εντοπίζει το [IRotationEffect](https://reference.aspose.com/slides/el/net/aspose.slides.animation/irotationeffect/), αλλάζει τη γωνία και ελέγχει την αποθηκευμένη τιμή μετά το ξανά άνοιγμα.

Η έλεγχος τύπου επιτρέπει στο βρόχο να παραλείπει συμπεριφορές που δεν είναι περιστροφές. Η δεύτερη φόρτωση διαβάζει το αποθηκευμένο αρχείο σε ξεχωριστό αντικείμενο παρουσίασης, έτσι η σύγκριση ελέγχει τα αποθηκευμένα δεδομένα αντί για την τιμή που παραμένει στη μνήμη. Αυτό το παράδειγμα υποθέτει ακόμη ότι το γνωστό εφέ είναι πρώτο στην κύρια ακολουθία· η επιλογή μιας συμπεριφοράς κατά τύπο δεν εντοπίζει το σωστό εφέ σε τυχαία παρουσίαση.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

Η έξοδος είναι `Rotation preserved: True`. Εφαρμόστε το ίδιο μοτίβο ελέγχου τύπου σε άλλες συμπεριφορές. Για έναν πλήρη έλεγχο διατήρησης, συγκρίνετε το σχήμα-στόχο, το εφέ, τους τύπους και τη σειρά των συμπεριφορών, τον χρονισμό και τις εντολές της διαδρομής. Χρησιμοποιήστε αριθμητική ανοχή για τιμές κινητής υποδιαστολής. Για μια παρουσίαση με άγνωστη διάταξη κίνησης, δείτε το [Read Shape Animations](/slides/el/net/shape-animation/#read-shape-animations) για την περιήγηση των κύριων και διαδραστικών ακολουθιών.

## **Σειρά Συμπεριφορών, Προεπιλογές και Αναπαραγωγή**

Η σειρά στο [IBehaviorCollection](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehaviorcollection/) είναι η αποθηκευμένη σειρά των λειτουργιών ενός εφέ. Δεν είναι μια λίστα αναπαραγωγής όπου κάθε συμπεριφορά περιμένει αυτόματα την προηγούμενη. Ο χρονισμός και το περιβάλλον εφέ καθορίζουν το προγραμματισμό. Οι συμπεριφορές μπορούν να επικαλύπτονται, και οι λειτουργίες στο ίδιο χαρακτηριστικό ενδέχεται να αλληλεπιδρούν μέσω των [Additive](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehavior/additive/) και [Accumulate](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ibehavior/accumulate/). Μην χρησιμοποιείτε μόνο την αναδιάταξη της συλλογής για να προγραμματίσετε «μετακίνηση, έπειτα περιστροφή»· χρησιμοποιήστε ρητό χρονισμό ή ξεχωριστά εφέ όπως περιγράφεται στην [Shape Animation](/slides/el/net/shape-animation/).

Το [Type](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/type/) και το [Subtype](https://reference.aspose.com/slides/el/net/aspose.slides.animation/ieffect/subtype/) του εφέ περιγράφουν το preset του. Δεν αποτελούν πλήρη περιγραφή ενός επεξεργασμένου δένδρου συμπεριφορών. Επιλέξτε το preset και το υποτύπο πριν προσαρμόσετε τις συμπεριφορές: η αλλαγή του preset μπορεί να ξαναδημιουργήσει τη συλλογή και να διαγράψει τις προσαρμοσμένες σας λειτουργίες. Για παράδειγμα, η αλλαγή ενός προσαρμοσμένου εφέ Spin σε Fade μπορεί να αντικαταστήσει τη συμπεριφορά περιστροφής με συμπεριφορές set και filter. Επιθεωρήστε ξανά τη συλλογή μετά την αλλαγή preset ή υποτύπου. Η εκκαθάριση των συμπεριφορών του preset μπορεί επίσης να αφαιρέσει λειτουργίες ορατότητας ή αρχικοποίησης που χρειάζεται το preset. Τα παραδείγματα χρησιμοποιούνσκόπιμα ορατά σχήματα και αντικαθιστούν τις συμπεριφορές· δεν αναδημιουργούν την υλοποίηση κάθε preset.

## **Συμβατότητα Μορφής**

Ένα διατηρημένο δέντρο συμπεριφορών δεν εγγυάται την ίδια αναπαραγωγή σε κάθε προβολέα ή εξαγωγέα. Ελέγξτε τα αποθηκευμένα δεδομένα και το παραγόμενο αποτέλεσμα ξεχωριστά.

| Μορφή ή έξοδος | Τι να ελέγξετε |
| --- | --- |
| PPTX | Χρησιμοποιήστε ως κύρια μορφή για αυτά τα παραδείγματα. Ανοίξτε ξανά το αρχείο για να επαληθεύσετε το επεξεργάσιμο δέντρο συμπεριφορών, έπειτα ελέγξτε την αναπαραγωγή στην επιθυμητή έκδοση του PowerPoint. |
| PPT | Η παλαιότερη δυαδική αναπαράσταση μπορεί να διαφέρει από το PPTX. Δοκιμάστε έναν ξεχωριστό κύκλο αποθήκευσης-ανοίγματος και αναπαραγωγής· μην υποθέτετε υποστήριξη για κάθε προσαρμοσμένο συνδυασμό από την επιτυχημένη έξοδο PPTX. |
| PDF, PNG, JPEG, and other static slide images | Περιέχουν μια στατική αναπαράσταση διαφάνειας, όχι μια αναπαγώμενη χρονική γραμμή συμπεριφορών ή εγγυημένο τελικό καρέ κίνησης. |
| HTML5 | Μπορεί να αναπαράγει υποστηριζόμενες κινήσεις όταν η κίνηση σχήματος είναι ενεργοποιημένη στις επιλογές εξαγωγής. Δοκιμάστε προσαρμοσμένους συνδυασμούς στο πρόγραμμα περιήγησης. |
| Animated GIF | Αποθηκεύει τα παραγόμενα καρέ, όχι επεξεργάσιμες συμπεριφορές ή αλληλεπίδραση με κλικ. Ελέγξτε την πραγματική κίνηση που δημιουργείται. |
| Video | Παράγει τα καρέ της κίνησης και τα κωδικοποιεί ως βίντεο. Η υποστήριξη περιορίζεται στις κινήσεις και εφέ που υποστηρίζει ο εξαγωγέας· οι εντολές και τα διαδραστικά γεγονότα δεν γίνονται επεξεργάσιμη χρονική γραμμή. |

## **Συχνές Ερωτήσεις**

**Γιατί το εφέ μου περιέχει συμπεριφορές πριν προσθέσω οποιαδήποτε;**

Η δημιουργία ενός προεπιλεγμένου εφέ μπορεί να δημιουργήσει τις υποκείμενες λειτουργίες του. Επιθεωρήστε τις πριν αποφασίσετε αν θα επεκτείνετε το preset ή θα αντικαταστήσετε τις συμπεριφορές του.

**Η μετακίνηση μιας συμπεριφοράς στην αρχή την κάνει να εκτελείται πρώτη;**

Δεν είναι απαραίτητα. Η σειρά της συλλογής δεν αντικαθιστά το χρονισμό. Ελέγξτε τις καθυστερήσεις, τις διάρκειες και τις αλληλεπιδράσεις μεταξύ λειτουργιών στο ίδιο χαρακτηριστικό.

**Γιατί μια εντολή End δεν έχει σημεία;**

Σημαίνει το τέλος της διαδρομής και δεν χρειάζεται συντεταγμένες. Ελέγξτε για μηδενικό πίνακα σημείων όταν επιθεωρείτε μια διαδρομή που διαβάστηκε από αρχείο.

**Είναι μια επιτυχής διαδρομή κύκλου (round trip) επαρκής για επιβεβαίωση της αναπαραγωγής;**

Όχι. Το ξανά άνοιγμα επιβεβαιώνει τη διατήρηση των ιδιοτήτων που ελέγξατε. Δοκιμάστε ξεχωριστά τον προοχέτη παρουσίασης ή την εξαγωγή animation για να επιβεβαιώσετε τη οπτική συμπεριφορά του.
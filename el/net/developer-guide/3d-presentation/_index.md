---
title: Δημιουργία 3Δ Εφέ σε Παρουσιάσεις Χρησιμοποιώντας .NET
linktitle: 3Δ Παρουσίαση
type: docs
weight: 232
url: /el/net/3d-presentation/
keywords:
- 3Δ PowerPoint
- 3Δ παρουσίαση
- 3Δ περιστροφή
- 3Δ βάθος
- 3Δ εξώθηση
- 3Δ διαβάθμιση
- 3Δ κείμενο
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3Δ εφέ για σχήματα και κείμενο PowerPoint σε .NET με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3Δ κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides για .NET μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει μορφοποίηση 3Δ σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3Δ όπως περιστροφή, εξώθηση, λοξοκοπές, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα με εικόνα και κείμενο 3Δ.

{{% alert color="info" %}}
Αυτό το άρθρο αφορά τα εφέ μορφοποίησης 3Δ σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή επεξεργασία ανεξάρτητων αρχείων 3Δ μοντέλων. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3Δ στην εξαγόμενη 2Δ έξοδο.
{{% /alert %}}

## **Έννοιες Μορφοποίησης 3Δ**

Χρησιμοποιήστε την ιδιότητα [IShape.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/properties/threedformat) για να εφαρμόσετε μορφοποίηση 3Δ σε ένα σχήμα. Η ιδιότητα εκθέτει το [IThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat), το οποίο ελέγχει τη σκηνή 3Δ για το συγκεκριμένο σχήμα.

Για κείμενο, χρησιμοποιήστε την ιδιότητα [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/properties/threedformat). Αυτό εφαρμόζει μορφοποίηση 3Δ στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Οι πιο σημαντικές ιδιότητες είναι:

| Ιδιότητα | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/camera) | Σημείο θέασης, προρυθμισμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε τρισδιάστατο χώρο ή ταιριάξτε μια προρυθμισμένη περιστροφή 3Δ του PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/lightrig) | Προρύθμιση φωτός, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο με τον οποίο εμφανίζονται οι αντανακλάσεις και οι σκιές στην επιφάνεια 3Δ. |
| [Material](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/material) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακή, γυαλιστερή ή μεταλλική. |
| [ExtrusionHeight](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusionheight) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από το εμπρός του πρόσωπο. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα εμφανίσιμα παχύ 3Δ αντικείμενο. |
| [ExtrusionColor](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με το εμπρός γέμισμα. |
| [Depth](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/depth) | Πρόσθετο βάθος 3Δ που χρησιμοποιείται από τη μορφοποίηση 3Δ του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ειδικά μαζί με τις ρυθμίσεις λοξοκοπής και υλικού. |
| [BevelTop](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/beveltop) και [BevelBottom](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/bevelbottom) | Ανυψωμένες ή στρογγυλεμένες άκρες στα εμπρός και πίσω πρόσωπα. | Προσθέστε μια μαλακή ή μορφοποιημένη άκρη αντί για μια αιχμηρή επίπεδη επιφάνεια. |
| [ContourColor](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/contourcolor) και [ContourWidth](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/contourwidth) | Περίγραμμα γύρω από το 3Δ αντικείμενο. | Τονίστε το όριο του αντικειμένου στην αποδίδοντα έξοδο. |

## **Δημιουργία Σχήματος 3Δ**

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, καθώς ο φωτισμός κάνει τις επιφάνειες και τις πλευρές ευανάγνωστες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στο εμπρός πρόσωπο, εφαρμόζει μορφοποίηση 3Δ, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

Η αποδιδόμενη εικόνα της διαφάνειας εμφανίζει το ορθογώνιο ως παχύ 3Δ μπλοκ:

![Απόδοση μπλε 3Δ ορθογωνίου με λευκό 3Δ κείμενο στο εμπρός πρόσωπο](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η περιστροφή 3Δ ρυθμίζεται από το πλαίσιο 3‑Δ Περιστροφής. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![PowerPoint 3‑Δ Περιστροφής με επισημασμένες τιμές X, Y και Z](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο κάμερας και την περιστροφή μέσω [IThreeDFormat.Camera](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/camera):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία του 2Δ σχήματος στη διαφάνεια. Αλλάζει το 3Δ σημείο θέασης που χρησιμοποιείται από το PowerPoint και από το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από το εμπρός πρόσωπο. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, ενώ ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Ρυθμίσεις βάθους του PowerPoint αντιστοιχούν στις ιδιότητες χρώματος και ύψους εξώθησης](img_02_02.png)

Ορίστε [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusionheight) για το πάχος και [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusioncolor) για το χρώμα των πλευρών:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Χρησιμοποιήστε το [IThreeDFormat.Depth](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/depth) όταν χρειάζεται να εργαστείτε απευθείας με την τιμή βάθους του PowerPoint ή να συνδυάσετε το βάθος με λοξοκοπίες, υλικό και εφέ κειμένου. Σε πολλές περιπτώσεις σχήματος, το `ExtrusionHeight` είναι πιο ξεκάθαρη ρύθμιση επειδή εκφράζει άμεσα την ορατή εξώθηση.

## **Χρήση Διαβάθμισης ή Γεμίσματος Εικόνας με Εφέ 3Δ**

Η μορφοποίηση 3Δ είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε ένα μονόχρωμο, διαβάθμιση, μοτίβο ή εικόνα στο εμπρός πρόσωπο και να διατηρήσετε τις ίδιες ρυθμίσεις κάμερας, φωτός, υλικού και εξώθησης.

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

Η αποδιδόμενη έξοδος διατηρεί τη διαβάθμιση στο εμπρός πρόσωπο και αποδίδει την εξώθηση ξεχωριστά:

![Απόδοση 3Δ ορθογωνίου με γέμισμα διαβάθμισης από μπλε σε πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και ορίστε τη ως γέμισμα σχήματος:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Η εικόνα αποδίδεται στο εμπρός πρόσωπο, ενώ η εξώθηση αποδίδεται ως η 3Δ πλευρική επιφάνεια:

![Απόδοση 3Δ ορθογωνίου με φωτογραφικό γέμισμα στο εμπρός πρόσωπο και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3Δ σε Κείμενο**

Η μορφοποίηση 3Δ του σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3Δ του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

Το κείμενο αποδίδεται ως καμπυλωτά, εξωθημένα 3Δ γράμματα:

![Απόδοση 3Δ κειμένου με καμπύλη μεταμόρφωση WordArt, πορτοκαλί γέμισμα μοτίβου και σκούρα εξώθηση](img_02_05.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3Δ όταν αποθηκεύει σε μορφές PowerPoint όπως PPTX. Κατά την απόδοση ή την εξαγωγή σε μορφές στατικού περιεχομένου, η σκηνή 3Δ rasterizes ή σχεδιάζεται στην έξοδο ως 2Δ αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/net/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/net/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/net/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [μετατροπή βίντεο](/slides/el/net/convert-powerpoint-to-video/).

Λάβετε υπόψη τα ακόλουθα:

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτεινού σύρματος, υλικού, εξώθησης, γεμίσματος και κλίμακας διαφάνειας.
- Εάν χρειάζεται να ελέγξετε κληρονομημένες ή τιμές μορφοποίησης βάσει θέματος, διαβάστε τις [effective shape properties](/slides/el/net/shape-effective-properties/).
- Ορισμένες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3Δ του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3Δ.

## **Συχνές Ερωτήσεις**

### Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3Δ παρουσιάσεις;

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3Δ του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή σελίδες HTML διαδραστικές σκηνές 3Δ που ο θεατής μπορεί να περιστρέψει. Στο PPTX, η μορφοποίηση 3Δ παραμένει επεξεργάσιμη στο PowerPoint όταν το μορφότυπο το υποστηρίζει.

### Ποια είναι η διαφορά μεταξύ μοντέλου 3Δ και εφέ 3Δ;

Ένα μοντέλο 3Δ είναι ένα ανεξάρτητο 3Δ αντικείμενο που εισάγεται στην παρουσίαση. Ένα εφέ 3Δ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λοξοκοπή, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει εφέ 3Δ.

### Ποιες ρυθμίσεις απαιτούνται για ένα ορατό σχήμα 3Δ;

Στο ελάχιστο, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης ένα σύστημα φωτισμού και υλικό ώστε οι αποδιδόμενες όψεις να έχουν ξεκάθαρες αντανακλάσεις και σκιές.

### Μπορώ να εφαρμόσω εφέ 3Δ τόσο σε σχήματα όσο και σε κείμενο;

Ναι. Χρησιμοποιήστε [IShape.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/properties/threedformat) για το σώμα του σχήματος και [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/properties/threedformat) για το κείμενο.

### Θα εμφανίζονται τα εφέ 3Δ κατά την εξαγωγή σε εικόνες, PDF, HTML ή καρέ βίντεο;

Ναι. Το Aspose.Slides αποδίδει εφέ 3Δ όταν παράγει εικόνες διαφανειών, PDF, HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Το εξαγόμενο αποτέλεσμα περιέχει την αποδιδόμενη εμφάνιση, όχι ένα επεξεργάσιμο 3Δ αντικείμενο.

### Μπορώ να διαβάσω τις τελικές τιμές 3Δ μετά την κληρονομιά και τις ρυθμίσεις θέματος;

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/net/shape-effective-properties/) για να διαβάσετε τελικές τιμές κάμερας, φωτεινού συρματιάς, λοξοκοπής και σχετικών τιμών 3Δ.
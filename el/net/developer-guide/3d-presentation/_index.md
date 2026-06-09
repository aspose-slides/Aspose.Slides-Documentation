---
title: Δημιουργία 3D εφέ σε παρουσιάσεις με .NET
linktitle: 3D Παρουσίαση
type: docs
weight: 232
url: /el/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D παρουσίαση
- 3D περιστροφή
- 3D βάθος
- 3D εξώθηση
- 3D διαβάθμιση
- 3D κείμενο
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εφαρμόστε και αποδώστε 3D εφέ για σχήματα και κείμενο PowerPoint σε .NET με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσεις και 3D κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει μορφοποίηση 3D σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3D όπως περιστροφή, εξώθηση, λοξοτομές, φωτισμό, υλικό, γέμιση με διαβάθμιση ή εικόνα και κείμενο 3D.

{{% alert color="primary" %}}
Αυτό το άρθρο αφορά εφέ μορφοποίησης 3D σε σχήματα και κείμενο PowerPoint. Δεν αφορά την εισαγωγή ή την επεξεργασία αυτόνομων αρχείων 3D μοντέλων. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3D στην εξαγόμενη 2D έξοδο.
{{% /alert %}}

## **Έννοιες Μορφοποίησης 3D**

Χρησιμοποιήστε την ιδιότητα [IShape.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/properties/threedformat) για να εφαρμόσετε μορφοποίηση 3D σε ένα σχήμα. Η ιδιότητα εκθέτει το [IThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat), το οποίο ελέγχει τη σκηνή 3D για εκείνο το σχήμα.

Για κείμενο, χρησιμοποιήστε την ιδιότητα [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/properties/threedformat). Αυτό εφαρμόζει μορφοποίηση 3D στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Οι πιο σημαντικές ιδιότητες είναι:

| Ιδιότητα | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/camera) | Θέα, τύπος προρυθμισμένης κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο στο 3D χώρο ή ταιριάξτε μια προρυθμισμένη περιστροφή 3D του PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/lightrig) | Προρύθμιση φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο εμφάνισης των φωτεινών σημείων και των σκιών στην επιφάνεια 3D. |
| [Material](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/material) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαγική, γυαλιστερή ή μεταλλική. |
| [ExtrusionHeight](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusionheight) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από την εμπρόσθια όψη. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα εμφανώς παχύ 3D αντικείμενο. |
| [ExtrusionColor](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με τη γέμιση του προπομπιού. |
| [Depth](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/depth) | Πρόσθετο 3D βάθος που χρησιμοποιείται από τη μορφοποίηση 3D του PowerPoint. | Ρυθμίστε ακριβεία το βάθος για σχήματα ή κείμενο, ειδικά μαζί με λοξοτομή και ρυθμίσεις υλικού. |
| [BevelTop](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/beveltop) και [BevelBottom](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/bevelbottom) | Ανασηκωμένα ή στρογγυλεμένα άκρα στις εμπρόσθιες και οπίσθιες όψεις. | Προσθέστε ένα απαλό ή καλυμμένο άκρο αντί για μια κοφτερή επίπεδη όψη. |
| [ContourColor](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/contourcolor) και [ContourWidth](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/contourwidth) | Περίγραμμα γύρω από το αντικείμενο 3D. | Δηλώστε το όριο του αντικειμένου στην αποδιδόμενη έξοδο. |

## **Δημιουργία 3D Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν φαίνεται 3D με πειστικό τρόπο:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές αναγνώσιμες.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην εμπρόσθια όψη του, εφαρμόζει μορφοποίηση 3D, αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σε εικόνα PNG.

```csharp
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

Η αποδιδόμενη εικόνα διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3D μπλοκ:

![Αποδιδόμενο μπλε 3D ορθογώνιο με λευκό 3D κείμενο στην εμπρόσθια όψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η περιστροφή 3D ρυθμίζεται από τον πίνακα 3‑D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Πίνακας PowerPoint 3‑D Rotation με επισημασμένες τιμές X, Y και Z](img_02_01.png)

Στο Aspose.Slides, ορίστε τον τύπο κάμερας και την περιστροφή μέσω του [IThreeDFormat.Camera](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/camera):

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία 2D του σχήματος στη διαφάνεια. Αλλάζει το 3D σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από την εμπρόσθια όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint αντιστοιχούν στις ιδιότητες extrusion color και extrusion height](img_02_02.png)

Ορίστε το [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusionheight) για το πάχος και το [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusioncolor) για το χρώμα των πλευρών:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Χρησιμοποιήστε το [IThreeDFormat.Depth](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/depth) όταν πρέπει να εργαστείτε άμεσα με την τιμή βάθους του PowerPoint ή να συνδυάσετε βάθος με λοξοτομή, υλικό και εφέ κειμένου. Σε πολλαπλές περιπτώσεις σχήματος, το `ExtrusionHeight` είναι η πιο σαφής ρύθμιση επειδή εκφράζει άμεσα την ορατή εξώθηση.

## **Χρήση Γεμίσεων Διαβάθμισης ή Εικόνας με Εφέ 3D**

Η μορφοποίηση 3D είναι ανεξάρτητη από τη γέμιση του σχήματος. Μπορείτε να εφαρμόσετε συμπαγές χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην εμπρόσθια όψη και να διατηρήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Το παράδειγμα αυτό εφαρμόζει διαβάθμιση στο σχήμα και ένα πιο σκούρο χρώμα εξώθησης στις πλευρές:

```csharp
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

Η αποδιδόμενη έξοδος διατηρεί τη διαβάθμιση στην εμπρόσθια όψη και αποδίδει την εξώθηση χωριστά:

![Αποδιδόμενο 3D ορθογώνιο με γαλάζια‑πορτοκαλί διαβάθμιση και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και εκχωρήστε την ως γέμισμα σχήματος:

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Η εικόνα αποδίδεται στην εμπρόσθια όψη, ενώ η εξώθηση αποδίδεται ως η 3D πλευρική επιφάνεια:

![Αποδιδόμενο 3D ορθογώνιο με γέμισμα φωτογραφίας στην εμπρόσθια όψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3D σε Κείμενο**

Η μορφοποίηση 3D του σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3D του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με γέμισμα μοτίβου, εφαρμόζει μετασχηματισμό WordArt και ρυθμίζει τις ρυθμίσεις 3D στο [ITextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat):

```csharp
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

Το κείμενο αποδίδεται ως καμπυλωτό, εξωθημένο 3D γράψιμο:

![Αποδιδόμενο 3D κείμενο με καμπυλωτό μετασχηματισμό WordArt, πορτοκαλί γέμισμα μοτίβου και σκούρα εξώθηση](img_02_05.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3D όταν αποθηκεύει σε μορφές PowerPoint όπως PPTX. Όταν αποδίδει ή εξάγει σε μορφές σταθερής διάταξης, η σκηνή 3D ρηματογραφείται ή σχεδιάζεται στην έξοδο ως 2D αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/net/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/net/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/net/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [video conversion](/slides/el/net/convert-powerpoint-to-video/).

Λάβετε υπόψη τα εξής:

- Οι εξαγόμενες εικόνες και τα PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από τον συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γέμισης και κλίμακας διαφάνειας.
- Εάν χρειάζεστε να ελέγξετε κληρονομημένες ή θεματικές τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/net/shape-effective-properties/).
- Κάποιες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3D του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμη ρύθμιση 3D.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει εφέ 3D του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή HTML σελίδες διαδραστικές 3D σκηνές που ένας θεατής μπορεί να περιστρέψει. Στο PPTX, η μορφοποίηση 3D παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή την υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ 3D μοντέλου και 3D εφέ;**

Ένα 3D μοντέλο είναι ένα ξεχωριστό 3D αντικείμενο που εισάγεται σε μια παρουσίαση. Ένα 3D εφέ είναι μορφοποίηση που εφαρμόζεται σε ένα κανονικό σχήμα ή κείμενο PowerPoint, όπως περιστροφή, εξώθηση, λοξοτομή, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει 3D εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3D σχήμα;**

Ελάχιστα, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδιδόμενες όψεις να έχουν σαφή υψηλά φωτεινά σημεία και σκιές.

**Μπορώ να εφαρμόσω εφέ 3D τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [IShape.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/properties/threedformat) για το σώμα του σχήματος και το [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/properties/threedformat) για το κείμενο.

**Θα εμφανιστούν τα 3D εφέ κατά την εξαγωγή σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3D εφέ όταν παράγει εικόνες διαφανειών, έξοδο PDF, έξοδο HTML και καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδιδόμενη εμφάνιση, όχι ένα επεξεργάσιμο 3D αντικείμενο.

**Μπορώ να διαβάσω τις τελικές τιμές 3D μετά την κληρονομιά και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα API αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/net/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, λοξοτομής και σχετιζόμενων 3D τιμών.
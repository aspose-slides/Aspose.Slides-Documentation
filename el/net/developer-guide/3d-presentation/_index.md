---
title: Δημιουργία 3D Εφέ σε Παρουσιάσεις με .NET
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
description: "Εφαρμόστε και αποδώστε 3D εφέ για σχήματα και κείμενο PowerPoint σε .NET με Aspose.Slides. Ρυθμίστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3D κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει μορφοποίηση 3D τύπου PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3D όπως περιστροφή, εξώθηση, λοξοτμησίες, φωτισμό, υλικό, διαβάθμιση ή γέμισμα εικόνας και κείμενο 3D.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά τα εφέ μορφοποίησης 3D σε σχήματα και κείμενο του PowerPoint. Δεν αφορά την εισαγωγή ή την επεξεργασία ανεξάρτητων αρχείων 3D μοντέλων. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3D στην εξαγόμενη 2D έξοδο.
{{% /alert %}}

## **Έννοιες μορφοποίησης 3D**

Χρησιμοποιήστε την ιδιότητα [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) για να εφαρμόσετε μορφοποίηση 3D σε ένα σχήμα. Η ιδιότητα εκθέτει το [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat), το οποίο ελέγχει τη σκηνή 3D για το συγκεκριμένο σχήμα.

Για κείμενο, χρησιμοποιήστε την ιδιότητα [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). Αυτό εφαρμόζει μορφοποίηση 3D στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Οι πιο σημαντικές ιδιότητες είναι:

| Ιδιότητα | Τι ελέγχει | Πότε να το χρησιμοποιήσετε |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | Σημείο θέασης, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο στο χώρο 3D ή ταιριάξτε μια προεπιλογή περιστροφής 3D του PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | Προεπιλογή φωτός, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο με τον οποίο εμφανίζονται τα φωτιστικά σημεία και οι σκιές στην επιφάνεια 3D. |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακότερη, γυαλιστερή ή μεταλλική. |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από την μπροστινή του πλευρά. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3D αντικείμενο. |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Χρώμα των εξωθήσεων πλευρών. | Κάντε το βάθος ορατό ή εναρμονίστε το χρώμα των πλευρών με το γέμισμα του μπροστινού μέρους. |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | Επικερδόν βάθος 3D που χρησιμοποιείται από τη μορφοποίηση 3D του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ειδικά μαζί με τις ρυθμίσεις λοξοτμησίας και υλικού. |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | Ανασηκωμένα ή στρογγυλεμένα άκρα στις μπροστινές και οπίσθιες πλευρές. | Προσθέστε ένα μαλακό ή χωνευμένο άκρο αντί για μια αιχμηρή επίπεδη επιφάνεια. |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | Περίγραμμα γύρω από το 3D αντικείμενο. | Τονίστε τα όρια του αντικειμένου στην αποδοθείσα έξοδο. |

## **Δημιουργία 3D Σχήματος**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν εμφανιστεί πειστικά 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προοπτική μπορεί να κρύβει την εξώθηση.
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις όψεις και τις πλευρές ορατές.
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τη απόδοση του φωτός.
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην μπροστινή του πλευρά και εφαρμόζει μορφοποίηση 3D. Οι τιμές περιστροφής της κάμερας δίνονται σε μοίρες, και το ύψος εξώθησης είναι 100 points. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG διπλάσιας των προεπιλεγμένων διαστάσεων και αποθηκεύει την παρουσίαση ως PPTX.

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

![Αποδοθέντε μπλε 3D ορθογώνιο με λευκό 3D κείμενο στην μπροστινή πλευρά](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3D περιστροφή ρυθμίζεται από το πλαίσιο 3‑Δ Περιστροφών. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Πανό των 3‑Δ Περιστροφών του PowerPoint με τιμές X, Y, Z τονισμένες](img_02_01.png)

Στο Aspose.Slides, αποκτήστε πρόσβαση στην κάμερα μέσω του [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει μια ορθογραφική προοπτική μπροστά και θέτει τις περιστροφές X, Y, Z σε 20, 30 και 40 μοίρες αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεστε να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρία 2D του σχήματος στη διαφάνεια· αλλάζει το 3D σημείο θέασης που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

### **Αντιγραφή Προσανατολισμού Κάμερας από Σχήμα Προτύπου**

Για να ταιριάξετε ένα σχήμα σε ένα πρότυπο, αντιγράψτε το προεπιλεγμένο [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) και διαβάστε τις γωνίες του με το [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/). Το παράδειγμα ανοίγει το `template.pptx`, διαβάζει την κάμερα από το πρώτο σχήμα της πρώτης διαφάνειας και εφαρμόζει τον προσανατολισμό στο δεύτερο σχήμα. Και τα δύο σχήματα έχουν ήδη 3D φωτισμό, ενώ το δεύτερο σχήμα δεν έχει ρητή περιστροφή κάμερας.

Οι γωνίες δίνονται σε μοίρες. Ο δείκτης `0` είναι γεωγραφικό πλάτος, ο `1` γεωγραφικό μήκος και ο `2` περιφορά. Περάστε τα στο [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) με αυτή τη σειρά. Εάν η πηγή επιστρέψει `null`, δεν υπάρχει ρητή περιστροφή, οπότε αφήστε τις γωνίες του δεύτερου σχήματος ακαθορισμένες. Μια ρητή περιστροφή `(0, 0, 0)` επιστρέφει τρία μηδενικά και πρέπει να αντιγραφεί.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

Όταν ξανανοίξετε το `camera-copy.pptx`, τα δύο σχήματα έχουν το ίδιο προεπιλεγμένο ρυθμό κάμερας και περιστροφή. Στο PowerPoint, το βέλος στα δεξιά χρησιμοποιεί τον προσανατολισμό κάμερας που αντιγράφηκε από το ορθογώνιο στα αριστερά. Και τα δύο σχήματα χρησιμοποιούν το ίδιο φωτισμό και βάθος εξώθησης.

![Μπλε 3D ορθογώνιο και δεξιό βέλος με ταιριαστό προσανατολισμό κάμερας, προβαλλόμενο από πάνω και δεξιά](camera-orientation.png)

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντας το πίσω από την μπροστινή επιφάνεια. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, ενώ ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Ρυθμίσεις βάθους του PowerPoint αντιστοιχισμένες στις ιδιότητες χρώματος εξώθησης και ύψους εξώθησης](img_02_02.png)

Ορίστε το [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) για το πάχος και το [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) για το χρώμα των πλευρών. Αυτό το παράδειγμα δίνει σε ένα ορθογώνιο εξώθηση 100 points με μοβ πλευρές και περιστρέφει την κάμερα για να αποκαλύψει το πάχος. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

Η ιδιότητα [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) ορίζει το βάθος ενός 3D σχήματος. Η ιδιότητα [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβαθμίσεων ή Γεμίσεων Εικόνας με Εφέ 3D**

Η μορφοποίηση 3D είναι ανεξάρτητη από το γέμισμα του σχήματος. Μπορείτε να εφαρμόσετε στερεό χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στη μπροστινή επιφάνεια και να χρησιμοποιήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει διαβάθμιση μπλε‑πορτοκαλί στη μπροστινή επιφάνεια και σκούρο πορτοκαλί χρώμα στην εξώθηση 150 points. Τα σημεία διαβάθμισης στα 0 και 100 σηματοδοτούν την έναρξη και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας δίνονται σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG διπλάσιων των προεπιλεγμένων διαστάσεων:

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

![Αποδοθέντε 3D ορθογώνιο με γέμισμα διαβάθμισης μπλε‑πορτοκαλί και πορτοκαλί εξώθηση](img_02_03.png)

Για να χρησιμοποιήσετε γέμισμα εικόνας, προσθέστε την εικόνα στην παρουσίαση και αντιστοιχίστε την στο γέμισμα σχήματος. Αυτό το παράδειγμα απαιτεί υπάρχον αρχείο με όνομα «image.jpg» στον τρέχοντα φάκελο. Τεντώνει την εικόνα ώστε να καλύπτει το ορθογώνιο, εφαρμόζει εξώθηση 150 points και θέτει την περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

![Αποδοθέντε 3D ορθογώνιο με γέμισμα φωτογραφίας στη μπροστινή πλευρά και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3D σε Κείμενο**

Η μορφοποίηση 3D του σχήματος επηρεάζει το σώμα του σχήματος. Η μορφοποίηση 3D του κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ παρόμοια με WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πορτοκαλί‑λευκό πλέγμα, εφαρμόζει ένα κυρτό τόξο και διαμορφώνει ρυθμίσεις 3D μέσω του [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat). Το ύψος εξώθησης και το βάθος δίνονται σε points, και η περιστροφή φωτισμού σε μοίρες. Το γέμισμα και το περίγραμμα του σχήματος είναι κρυμμένα ώστε να φαίνεται μόνο το κείμενο. Το παράδειγμα αποδίδει μια εικόνα PNG διπλάσιας των προεπιλεγμένων διαστάσεων της διαφάνειας και αποθηκεύει την παρουσίαση ως PPTX:

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

![Αποδοθέντε 3D κείμενο με κυρτή μετατροπή WordArt, γέμισμα μοτίβου πορτοκαλί και σκούρα εξώθηση](img_02_05.png)

## **Διατήρηση του Κειμένου Επίπεδου σε 3D Σχήμα**

Για να διατηρήσετε το κείμενο αναγνώσιμο ενώ διατηρείται η 3D εμφάνιση του σχήματος, ορίστε το [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) μέσω του [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/). Όταν η τιμή είναι `true`, το κείμενο παραμένει εκτός της 3D σκηνής. Όταν είναι `false`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον 3D προσανατολισμό.

Αυτή η ρύθμιση δεν αφαιρεί τη μορφοποίηση 3D του σχήματος: η κάμερα, ο φωτισμός, το υλικό και η εξώθηση παραμένουν ρυθμισμένα μέσω του [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/). Είναι επίσης διαφορετικό από την κανονική περιστροφή. Η [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ η [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου εκτός της 3D σκηνής δεν επαναφέρει καμία από αυτές τις γωνίες.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το αντιγράφει δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια μορφοποίηση 3D· μόνο η ρύθμιση κειμένου διαφέρει: `false` στα αριστερά και `true` στα δεξιά. Οι γωνίες της κάμερας δίνονται σε μοίρες, και το ύψος εξώθησης είναι 40 points. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG διπλάσιας των προεπιλεγμένων διαστάσεων.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

![Δυο 3D ορθογώνια ζευγάρια: KeepTextFlat είναι false στα αριστερά και true στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγής και Απόδοσης**

Το Aspose.Slides διατηρεί τη μορφοποίηση 3D κατά την αποθήκευση σε μορφές PowerPoint όπως PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές σταθερής διάταξης, η 3D σκηνή rasterizes ή σχεδιάζεται στην έξοδο ως 2D αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/net/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/net/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/net/convert-powerpoint-to-html/), ή δημιουργείτε πλαίσια για [video conversion](/slides/el/net/convert-powerpoint-to-video/).

Κρατήστε αυτά τα σημεία κατά νου:

- Οι εξαγόμενες εικόνες και PDF δεν είναι διαδραστικές. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτισμού, υλικού, εξώθησης, γεμίσματος και κλίμακας διαφάνειας.
- Εάν χρειάζεται να ελέγξετε κληρονομημένες ή θεματικές τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/net/shape-effective-properties/).
- Κάποιες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη μορφοποίηση 3D του PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες ρυθμίσεις 3D.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει τα 3D εφέ του PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή HTML σε διαδραστικές 3D σκηνές που ο θεατής μπορεί να περιστρέψει. Σε PPTX, η μορφοποίηση 3D παραμένει επεξεργάσιμη στο PowerPoint όταν η μορφή την υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ ενός 3D μοντέλου και ενός 3D εφέ;**

Ένα 3D μοντέλο είναι ξεχωριστό αντικείμενο 3D που εισάγεται σε παρουσίαση. Ένα 3D εφέ είναι μορφοποίηση που εφαρμόζεται σε κανονικό σχήμα ή κείμενο του PowerPoint, όπως περιστροφή, εξώθηση, λοξοτμησία, φωτισμός και υλικό. Αυτό το άρθρο καλύπτει τα 3D εφέ.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3D σχήμα;**

Ελάχιστα, ορίστε περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτισμό και υλικό ώστε οι αποδοθείσες όψεις να έχουν σαφή φωτεινά σημεία και σκιές.

**Μπορώ να εφαρμόσω 3D εφέ τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) για το σώμα του σχήματος και το [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) για το κείμενο.

**Θα εμφανιστούν τα 3D εφέ όταν εξάγονται σε εικόνες, PDF, HTML ή πλαισίων βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα 3D εφέ κατά την παραγωγή εικόνων διαφανειών, εξόδου PDF, εξόδου HTML και πλαισίων που χρησιμοποιούνται για μετατροπή βίντεο. Η εξαγόμενη έξοδος περιέχει την αποδοθείσα εμφάνιση, όχι ένα επεξεργάσιμο 3D αντικείμενο.

**Μπορώ να διαβάσω τις τελικές 3D τιμές μετά την κληρονομικότητα και τις θεματικές ρυθμίσεις;**

Ναι. Χρησιμοποιήστε τα APIs μορφοποίησης αποτελεσματικότητας που περιγράφονται στις [Shape Effective Properties](/slides/el/net/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτισμού, λοξοτμησίας και σχετικών 3D τιμών.
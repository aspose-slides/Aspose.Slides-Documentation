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
description: "Εφαρμόστε και αποδώστε 3D εφέ για σχήματα και κείμενο PowerPoint σε .NET με Aspose.Slides. Διαμορφώστε κάμερα, φωτισμό, υλικό, εξώθηση, γεμίσματα και 3D κείμενο."
---
## **Επισκόπηση**

Το Aspose.Slides για .NET μπορεί να δημιουργεί, να επεξεργάζεται, να διατηρεί και να αποδίδει μορφοποίηση 3D σε στυλ PowerPoint για σχήματα και κείμενο. Αυτό το άρθρο καλύπτει εφέ 3D όπως περιστροφή, εξώθηση, λοξότητα, φωτισμό, υλικό, διαβάθμιση ή γεμίσματα εικόνας, και κείμενο 3D.

{{% alert color="info" title="Note" %}}
Αυτό το άρθρο αφορά τα εφέ μορφοποίησης 3D σε σχήματα και κείμενο PowerPoint. Δεν αφορά την εισαγωγή ή την επεξεργασία ξεχωριστών αρχείων μοντέλων 3D. Όταν εξάγετε μια διαφάνεια σε εικόνα, PDF ή HTML, το Aspose.Slides αποδίδει αυτά τα εφέ 3D στην εξαγόμενη 2D έξοδο.
{{% /alert %}}

## **Έννοιες Μορφοποίησης 3D**

Χρησιμοποιήστε την ιδιότητα [IShape.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/properties/threedformat) για να εφαρμόσετε μορφοποίηση 3D σε ένα σχήμα. Η ιδιότητα εκθέτει το [IThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat), το οποίο ελέγχει τη σκηνή 3D για αυτό το σχήμα.

Για κείμενο, χρησιμοποιήστε την ιδιότητα [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/properties/threedformat). Αυτό εφαρμόζει μορφοποίηση 3D στο πλαίσιο κειμένου αντί στο σώμα του σχήματος.

Οι πιο σημαντικές ιδιότητες είναι:

| Ιδιότητα | Τι ελέγχει | Πότε να τη χρησιμοποιήσετε |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/camera) | Οπτική γωνία, προεπιλεγμένος τύπος κάμερας, περιστροφή, ζουμ και προοπτική. | Περιστρέψτε το αντικείμενο σε χώρο 3D ή ταιριάξτε με προεπιλεγμένη περιστροφή 3D του PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/lightrig) | Προεπιλογή φωτισμού, κατεύθυνση και περιστροφή φωτός. | Αλλάξτε τον τρόπο με τον οποίο εμφανίζονται τα φωτεινά σημεία και οι σκιές στην επιφάνεια 3D. |
| [Material](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/material) | Υλικό επιφάνειας, όπως επίπεδο, ματ, πλαστικό ή μέταλλο. | Κάντε την ίδια γεωμετρία να φαίνεται πιο επίπεδη, μαλακότερη, γυαλιστερή ή μεταλλική. |
| [ExtrusionHeight](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusionheight) | Πόσο μακριά το σχήμα εκτείνεται προς τα πίσω από την εμπρόσθια όψη του. | Μετατρέψτε ένα επίπεδο σχήμα σε ένα ορατά παχύ 3D αντικείμενο. |
| [ExtrusionColor](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Χρώμα των εξωθημένων πλευρών. | Κάντε το βάθος ορατό ή συντονίστε το χρώμα των πλευρών με το γέμισμα του εμπρός. |
| [Depth](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/depth) | Επιπλέον βάθος 3D που χρησιμοποιείται από τη μορφοποίηση 3D του PowerPoint. | Ρυθμίστε ακριβώς το βάθος για σχήματα ή κείμενο, ειδικά σε συνδυασμό με τις ρυθμίσεις λοξότητας και υλικού. |
| [BevelTop](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/beveltop) και [BevelBottom](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/bevelbottom) | Ανασηκωμένα ή στρογγυλεμένα άκρα στις εμπρόσθιες και οπίσθιες όψεις. | Προσθέστε ένα μαλακοποιημένο ή καλυμμένο άκρο αντί για μια αιχμηρή επίπεδη όψη. |
| [ContourColor](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/contourcolor) και [ContourWidth](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/contourwidth) | Περίγραμμα γύρω από το αντικείμενο 3D. | Τονίστε το όριο του αντικειμένου στην αποδιδόμενη έξοδο. |

## **Δημιουργία Σχήματος 3D**

Ένα σχήμα συνήθως χρειάζεται τέσσερις τύπους ρυθμίσεων πριν φαίνεται πειστικά 3D:

- Ρυθμίσεις κάμερας, επειδή η προεπιλεγμένη προβολή από εμπρός μπορεί να κρύβει την εξώθηση.  
- Ρυθμίσεις φωτισμού, επειδή ο φωτισμός κάνει τις πλευρές αναγνώσιμες.  
- Ρυθμίσεις υλικού, επειδή η επιφάνεια επηρεάζει τον τρόπο απόδοσης του φωτός.  
- Ρυθμίσεις εξώθησης ή βάθους, επειδή ένα επίπεδο σχήμα χρειάζεται πάχος.

Το παρακάτω παράδειγμα δημιουργεί ένα ορθογώνιο, προσθέτει κείμενο στην εμπρόσθια όψη του και εφαρμόζει μορφοποίηση 3D. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες και το ύψος εξώθησης είναι 100 points. Το παράδειγμα αποδίδει τη διαφάνεια σε εικόνα PNG με διπλάσια προεπιλεγμένα διαστάσεις και αποθηκεύει την παρουσίαση ως PPTX.

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

Η αποδιδόμενη εικόνα της διαφάνειας δείχνει το ορθογώνιο ως ένα παχύ 3D μπλοκ:

![Αποδιδόμενο μπλε 3D ορθογώνιο με λευκό 3D κείμενο στην εμπρόσθια όψη](img_01_01.png)

## **Περιστροφή Σχήματος με την Κάμερα**

Στο PowerPoint, η 3D περιστροφή ρυθμίζεται από το παράθυρο 3‑D Rotation. Οι τιμές περιστροφής X, Y και Z αντιστοιχούν στην περιστροφή που ορίζετε μέσω του API της κάμερας.

![Παράθυρο 3‑D Rotation του PowerPoint με επισημασμένες τιμές περιστροφής X, Y και Z](img_02_01.png)

Στο Aspose.Slides, προσπελάστε την κάμερα μέσω του [IThreeDFormat.Camera](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/camera). Αυτό το παράδειγμα δημιουργεί ένα ορθογώνιο, επιλέγει ορθογραφική προβολή από εμπρός και ορίζει τις περιστροφές X, Y, Z στα 20, 30 και 40 μοίρες αντίστοιχα. Διαμορφώνει το σχήμα στη μνήμη χωρίς να αποθηκεύσει αρχείο:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Χρησιμοποιήστε την κάμερα όταν χρειάζεται να αλλάξετε τον τρόπο που ο θεατής βλέπει το αντικείμενο. Δεν αλλάζει τη γεωμετρική μορφή του 2D σχήματος στη διαφάνεια. Αλλάζει την 3D οπτική γωνία που χρησιμοποιούν το PowerPoint και το Aspose.Slides κατά την απόδοση.

## **Προσθήκη Εξώθησης και Βάθους**

Η εξώθηση κάνει ένα σχήμα να φαίνεται παχύ επεκτείνοντάς το πίσω από την εμπρόσθια όψη. Στο PowerPoint, ο έλεγχος βάθους ορίζει αυτό το ορατό πάχος, και ο έλεγχος χρώματος ορίζει το χρώμα των πλευρικών όψεων.

![Έλεγχοι βάθους του PowerPoint συνδεδεμένοι με τις ιδιότητες extrusion color και extrusion height](img_02_02.png)

Ορίστε το [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusionheight) για το πάχος και το [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusioncolor) για το χρώμα των πλευρών. Αυτό το παράδειγμα δίνει σε ένα ορθογώνιο εξώθηση 100 points με μωβ πλευρές και περιστρέφει την κάμερα ώστε να αποκαλύψει το πάχος. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση αρχείου:

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

Η ιδιότητα [IThreeDFormat.Depth](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/depth) ορίζει το βάθος ενός 3D σχήματος. Η ιδιότητα [ExtrusionHeight](https://reference.aspose.com/slides/el/net/aspose.slides/ithreedformat/properties/extrusionheight) ελέγχει το ύψος του εφέ εξώθησης, όπως φαίνεται σε αυτό το παράδειγμα.

## **Χρήση Διαβάθμισης ή Γεμίσματος Εικόνας με Εφέ 3D**

Η μορφοποίηση 3D είναι ανεξάρτητη από το γέμισμα σχήματος. Μπορείτε να εφαρμόσετε στερεό χρώμα, διαβάθμιση, μοτίβο ή γέμισμα εικόνας στην εμπρόσθια όψη και να διατηρήσετε τις ίδιες ρυθμίσεις κάμερας, φωτισμού, υλικού και εξώθησης.

Αυτό το παράδειγμα εφαρμόζει διαβάθμιση από μπλε σε πορτοκαλί στην εμπρόσθια όψη και σκούρο πορτοκαλί χρώμα στην εξώθηση 150 points. Τα σημεία διαβάθμισης στο 0 και 100 σηματοδοτούν την αρχή και το τέλος της διαβάθμισης. Οι τιμές περιστροφής της κάμερας είναι σε μοίρες. Η διαφάνεια αποδίδεται σε εικόνα PNG με διπλάσια προεπιλεγμένες διαστάσεις:

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

Το αποδιδόμενο αποτέλεσμα διατηρεί τη διαβάθμιση στην εμπρόσθια όψη και αποδίδει την εξώθηση ξεχωριστά:

![Αποδιδόμενη 3D ορθογώνια με διαβάθμιση μπλε‑πορτοκαλί και εξώθηση πορτοκαλί](img_02_03.png)

Για χρήση γεμίσματος εικόνας, προσθέστε την εικόνα στην παρουσίαση και αναθέστε την στο γέμισμα σχήματος. Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο με όνομα "image.jpg" στον τρέχοντα φάκελο. Τεντώνει την εικόνα ώστε να καλύψει το ορθογώνιο, εφαρμόζει εξώθηση 150 points και ορίζει τη περιστροφή της κάμερας σε μοίρες. Διαμορφώνει το σχήμα στη μνήμη χωρίς αποθήκευση ή απόδοση αρχείου:

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

Η εικόνα αποδίδεται στην εμπρόσθια όψη, ενώ η εξώθηση αποδίδεται ως η 3D πλευρική επιφάνεια:

![Αποδιδόμενη 3D ορθογώνια με γέμισμα φωτογραφίας στην εμπρόσθια όψη και πορτοκαλί εξώθηση](img_02_04.png)

## **Εφαρμογή Μορφοποίησης 3D σε Κείμενο**

Η 3D μορφοποίηση σχήματος επηρεάζει το σώμα του σχήματος. Η 3D μορφοποίηση κειμένου επηρεάζει το πλαίσιο κειμένου. Αυτό είναι χρήσιμο για εφέ τύπου WordArt όπου τα γράμματα χρειάζονται εξώθηση, υλικό, φωτισμό και ρυθμίσεις κάμερας.

Το παρακάτω παράδειγμα δημιουργεί κείμενο με μοτίβο πορτοκαλί‑λευκό πλέγμα, εφαρμόζει καμπύλη προς τα πάνω, και διαμορφώνει τις ρυθμίσεις 3D μέσω του [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/properties/threedformat). Το ύψος εξώθησης και το βάθος είναι σε points, και η περιστροφή φωτός σε μοίρες. Το γέμισμα και το περίγραμμα του σχήματος κρύβονται ώστε να φαίνεται μόνο το κείμενο. Το παράδειγμα αποδίδει PNG εικόνα με διπλάσια προεπιλεγμένες διαστάσεις της διαφάνειας και αποθηκεύει την παρουσίαση ως PPTX:

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

Το κείμενο αποδίδεται ως καμπυλωτά, εξωθημένα 3D γράμματα:

![Αποδιδόμενο 3D κείμενο με καμπύλωση WordArt, γεμιστό μοτίβο πορτοκαλί και σκούρο εξώθηση](img_02_05.png)

## **Διατήρηση Κειμένου Επί Πεδίο 3D Σχήματος**

Για να διατηρείται το κείμενο ευανάγνωστο διατηρώντας την 3D εμφάνιση του σχήματος, ορίστε το [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/keeptextflat/) μέσω του [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/textframeformat/). Όταν η τιμή είναι `true`, το κείμενο παραμένει εκτός της 3D σκηνής. Όταν είναι `false`, το κείμενο συμμετέχει στη σκηνή και ακολουθεί τον 3D προσανατολισμό της.

Αυτή η ρύθμιση δεν αφαιρεί τη 3D μορφοποίηση του σχήματος: η κάμερα, το φωτιστικό, το υλικό και η εξώθηση παραμένουν ρυθμισμένα μέσω του [IShape.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/threedformat/). Είναι επίσης διαφορετικό από την απλή περιστροφή. Το [IShape.Rotation](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/rotation/) περιστρέφει το σχήμα στο επίπεδο της διαφάνειας, ενώ το [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/rotationangle/) ελέγχει την προσαρμοσμένη περιστροφή του κειμένου μέσα στο πλαίσιο του. Η διατήρηση του κειμένου εκτός της 3D σκηνής δεν μηδενίζει κανένα από αυτά τα γωνιακά στοιχεία.

Το παρακάτω αυτόνομο παράδειγμα δημιουργεί ένα μπλε ορθογώνιο με κείμενο και το κλωνοποιεί δίπλα στο αρχικό. Και τα δύο σχήματα έχουν την ίδια 3D μορφοποίηση· η μόνη διαφορά είναι η ρύθμιση κειμένου: `false` στα αριστερά και `true` στα δεξιά. Οι γωνίες της κάμερας είναι σε μοίρες και το ύψος εξώθησης 40 points. Το παράδειγμα αποθηκεύει την παρουσίαση ως PPTX και αποδίδει τη διαφάνεια σύγκρισης σε PNG με διπλάσια προεπιλεγμένες διαστάσεις.

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

Στα αριστερά, το κείμενο ακολουθεί τον 3D προσανατολισμό. Στα δεξιά, παραμένει επίπεδο και πιο εύκολο στην ανάγνωση. Και τα δύο ορθογώνια διατηρούν την ίδια ορατή εξώθηση και 3D προσανατολισμό.

![Δύο 3D ορθογώνια πλάι‑πλάι: KeepTextFlat είναι false στα αριστερά και true στα δεξιά](keep_text_flat.png)

## **Συμπεριφορά Εξαγωγών και Απόδοσης**

Το Aspose.Slides διατηρεί τη 3D μορφοποίηση κατά την αποθήκευση σε μορφές PowerPoint όπως PPTX. Κατά την απόδοση ή εξαγωγή σε μορφές στατικού περιεχομένου, η 3D σκηνή ραστεροποιείται ή σχεδιάζεται στην έξοδο ως 2D αποτέλεσμα. Αυτό ισχύει όταν αποδίδετε διαφάνειες σε [PNG](/slides/el/net/convert-powerpoint-to-png/), εξάγετε σε [PDF](/slides/el/net/convert-powerpoint-to-pdf/), εξάγετε σε [HTML](/slides/el/net/convert-powerpoint-to-html/), ή δημιουργείτε καρέ για [μετατροπή βίντεο](/slides/el/net/convert-powerpoint-to-video/).

Λάβετε υπόψη τα εξής:

- Οι εξαγόμενες εικόνες και PDF δεν είναι διαδραστικά. Το αντικείμενο δεν μπορεί να περιστραφεί από τον θεατή μετά την εξαγωγή.  
- Η τελική εμφάνιση εξαρτάται από το συνδυασμό κάμερας, φωτιστικού, υλικού, εξώθησης, γεμίσματος και κλίμακας διαφάνειας.  
- Εάν χρειάζεται να εξετάσετε κληρονομημένες ή θεματικές τιμές μορφοποίησης, διαβάστε τις [effective shape properties](/slides/el/net/shape-effective-properties/).  
- Κάποιες μορφές εξόδου δεν μπορούν να αποθηκεύσουν επεξεργάσιμη 3D μορφοποίηση PowerPoint. Σε αυτές τις μορφές, το οπτικό αποτέλεσμα αποδίδεται αντί να διατηρείται ως επεξεργάσιμες 3D ρυθμίσεις.

## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να δημιουργήσει διαδραστικές 3D παρουσιάσεις;**

Το Aspose.Slides δημιουργεί και αποδίδει 3D εφέ PowerPoint για σχήματα και κείμενο. Δεν κάνει τις εξαγόμενες εικόνες, PDF ή HTML σελίδες διαδραστικές 3D σκηνές που ο θεατής μπορεί να περιστρέψει. Σε PPTX, η 3D μορφοποίηση παραμένει επεξεργάσιμη στο PowerPoint όπου η μορφή το υποστηρίζει.

**Ποια είναι η διαφορά μεταξύ μοντέλου 3D και εφέ 3D;**

Ένα μοντέλο 3D είναι ένα ξεχωριστό 3D αντικείμενο που εισάγεται στην παρουσίαση. Ένα εφέ 3D είναι μορφοποίηση που εφαρμόζεται σε κανονικό σχήμα ή κείμενο PowerPoint, όπως περιστροφή, εξώθηση, λοξότητα, φωτισμό και υλικό. Αυτό το άρθρο καλύπτει εφέ 3D.

**Ποιες ρυθμίσεις απαιτούνται για ένα ορατό 3D σχήμα;**

Τουλάχιστον, ορίστε μια περιστροφή κάμερας και είτε εξώθηση είτε βάθος. Στην πράξη, ορίστε επίσης φωτιστικό και υλικό ώστε οι αποδιδόμενες όψεις να έχουν καθαρά φωτιστικά σημεία και σκιές.

**Μπορώ να εφαρμόσω εφέ 3D τόσο σε σχήματα όσο και σε κείμενο;**

Ναι. Χρησιμοποιήστε το [IShape.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/properties/threedformat) για το σώμα του σχήματος και το [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/properties/threedformat) για το κείμενο.

**Θα εμφανιστούν τα εφέ 3D όταν εξάγω σε εικόνες, PDF, HTML ή καρέ βίντεο;**

Ναι. Το Aspose.Slides αποδίδει τα εφέ 3D όταν παράγει εικόνες διαφανειών, PDF, HTML ή καρέ που χρησιμοποιούνται για μετατροπή βίντεο. Το εξαγόμενο αρχείο περιέχει την αποδιδόμενη εμφάνιση, όχι ένα επεξεργάσιμο 3D αντικείμενο.

**Μπορώ να διαβάσω τις τελικές τιμές 3D μετά την κληρονομικότητα και τις ρυθμίσεις θέματος;**

Ναι. Χρησιμοποιήστε τα APIs αποτελεσματικής μορφοποίησης που περιγράφονται στις [Shape Effective Properties](/slides/el/net/shape-effective-properties/) για να διαβάσετε τις τελικές τιμές κάμερας, φωτιστικού, λοξότητας και σχετικών 3D τιμών.
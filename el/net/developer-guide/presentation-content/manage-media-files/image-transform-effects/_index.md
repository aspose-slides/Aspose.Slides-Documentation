---
title: Διαχείριση επιδράσεων μετασχηματισμού εικόνας σε παρουσιάσεις με .NET
linktitle: Επιδράσεις μετασχηματισμού εικόνας
type: docs
weight: 11
url: /el/net/image-transform-effects/
keywords:
- μετασχηματισμός εικόνας
- επίδραση εικόνας
- φωτεινότητα
- αντίθεση
- γκρίζα απόχρωση
- δυότονο
- απόχρωση
- HSL
- αντικατάσταση χρώματος
- θόλωση
- διαφάνεια
- εφέ άλφα
- αλυσίδα επιδράσεων
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εφαρμόστε, αλυσσοποιήστε, επιθεωρήστε, αφαιρέστε και επαληθεύστε τις επιδράσεις μετασχηματισμού εικόνας για πλαίσια εικόνας με Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides αναπαριστά τις ρυθμίσεις εικόνας ως μια ταξινομημένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) και αποκτήστε πρόσβαση στο [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/). Η επιστρεφόμενη [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) σάς επιτρέπει να προσθέτετε, να απαριθμείτε, να ελέγχετε, να αφαιρείτε και να καθαρίζετε τις επιδράσεις χωρίς να ξαναγράψετε τα αρχικά bytes της εικόνας.

Αυτό το άρθρο παρουσιάζει μια πλήρη ροή εργασίας για φωτεινότητα και αντίθεση, μετασχηματισμούς χρώματος, θόλωση, διαφάνεια, αλυσίδες επιδράσεων με σειρά, αποτελεσματικές τιμές, αφαίρεση και επαλήθευση γύρω από το PPTX.

## **Κατανόηση Ιδιοκτησίας Επιδράσεων και Επαναχρησιμοποίησης Εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) αποθηκεύει ή αναφέρει τα δεδομένα της πηγαίας εικόνας που ανήκει στην παρουσίαση.
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) ανήκει σε ένα γέμισμα εικόνας και αναφέρεται σε έναν πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμών εικόνας.
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) είναι το σχήμα της διαφάνειας που κατέχει το σχετικό γέμισμα εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις σε επίπεδο πλαισίου.

Επομένως, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα byte στο [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). Όταν το ίδιο `IPPImage` περάσει στο [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `ISlidesPicture` και τη δική του συλλογή μετασχηματισμών. Η εφαρμογή γκρι απόχρωσης (grayscale) σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι, ακόμη και αν όλα χρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `ISlidesPicture.ImageTransform` χρησιμοποιείται επίσης από άλλα γέμισματα εικόνας, όπως ένα σχήμα ή το φόντο μιας διαφάνειας. Τα παραδείγματα παρακάτω επικεντρώνονται στα πλαίσια εικόνας.

## **Χρήση Έγκυρων Εύρους Παραμέτρων και Μονάδων**

Οι παρουσιάζονται μέθοδοι χρησιμοποιούν τα παρακάτω λογικά εύρη και μονάδες. Κρατήστε τις τιμές εντός αυτών των ορίων ακόμα και αν κάποια έκδοση της βιβλιοθήκης δεν απορρίπτει αμέσως κάθε τιμή εκτός ορίου· η μορφή στόχου της παρουσίασης μπορεί να κανονικοποιήσει, παραλείψει ή απορρίψει μη έγκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίγει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρο εύρος και μονάδα |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` μέχρι `100`, ποσοστό· `0` αφήνει το στοιχείο αμετάβλητο. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Κανένα | Χωρίς αριθμητικές παραμέτρους. Η άλφα παραμένει αμετάβλητη. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Δύο χρώματα για σκούρα και ανοιχτά pixel. Τα κανάλια RGB και άλφα στο `System.Drawing.Color` χρησιμοποιούν τιμές `0` με `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Η απόχρωση είναι `0` (συμπεριλαμβανομένη) μέχρι `360` (αποκλειστική) μοίρες· το ποσό είναι `-100` μέχρι `100`, ποσοστό. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Η απόχρωση είναι `0` (συμπ.) μέχρι `360` (απ.) μοίρες· ο κορεσμός και η φωτεινότητα είναι `-100` μέχρι `100`, ποσοστό. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών από `0` μέχρι `255`. Οι υπάρχουσες τιμές άλφα παραμένουν αμετάβλητες. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετράται σε points· το `grow` είναι Boolean που ελέγχει αν το θολό περιεχόμενο μπορεί να εκτείνεται εκτός των αρχικών ορίων. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε `0` με `100` για τυπική κλιμάκωση διαύγειας: `0` είναι πλήρως διαφανές και `100` διατηρεί την υπάρχουσα άλφα. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` με `100`, ποσοστό διαύγειας. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` με `100`, ποσοστό κατωφλίου άλφα. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή πάνω γίνονται αδιαφανείς. |

Για σταθερή διαμόρφωση άλφα, η διαφάνεια και η αδιαφάνεια είναι αλληλοσυμπληρωματικές. Για παράδειγμα, 35 % διαφάνεια αντιστοιχεί σε ποσό διαμόρφωσης άλφα 65 %.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) επιστρέφει μια λειτουργία [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/). Οι κλιμακωτές τιμές παρέχονται όταν δημιουργείται η λειτουργία. Το [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) επιστρέφει υπολογισμένες τιμές μόνο για ανάγνωση που μπορούν να επιθεωρηθούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, στη συνέχεια αποδίδει μια προεπισκόπηση χωρίς να τροποποιεί την ενσωματωμένη εικόνα:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) είναι μια επέκταση εικόνας του Office 2010 και είναι λιγότερο φορητή από το πρότυπο εφέ luminance του DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά από κύκλο αποθήκευσης PPTX, χρησιμοποιήστε το [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) και επαληθεύστε το αποτέλεσμα ανοίγοντας ξανά το αρχείο. Η ενότητα περιορισμών μορφής εξηγεί αυτή τη διάκριση με περισσότερες λεπτομέρειες.

## **Εφαρμογή Μετασχηματισμών Χρώματος**

Οι επιδράσεις χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που επαναχρησιμοποιούν έναν πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι απόχρωση, δυότονο, απόχρωση (tint), ρύθμιση HSL και αντικατάσταση χρώματος.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `Color1` αντιστοιχεί στα σκούρα pixel, ενώ το `Color2` στα ανοιχτά pixel. Αυτό το καθιστά χρήσιμο παράδειγμα μιας επίδρασης των ρυθμίσεων της οποίας είναι πιο πολύπλοκη από μια μοναδική κλιμακωτή τιμή.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) αντικαθιστά το χρώμα κάθε pixel με ένα σταθερό χρώμα διατηρώντας την άλφα. Είναι διαφορετικό από το [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), το οποίο αντιστοιχίζει ένα χρώμα πηγής σε άλλο και εκθέτει και τις μορφές χρώματος πηγής και προορισμού.

### **Εφαρμογή Κατωφλίου Φωτεινότητας**

Ένα κατώφλι φωτεινότητας μπορεί να κάνει τις αχνές σημαδέσιες σε σκαναρισμένη σελίδα πιο ευδιάκριτες από το φόντο. Το [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) διατηρεί ενδιάμεσες αποχρώσεις του γκρι. Το [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) αντιστοιχεί τη φωτεινότητα σε μαύρο ή λευκό, ενώ το [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) εφαρμόζει ένα κατώφλι στην αδιαφάνεια.

Το κατώφλι φωτεινότητας κυμαίνεται από 0 % έως 100 %, και τα pixel κάτω από το κατώφλι γίνονται μαύρα. Τα pixel ίσα ή πάνω γίνονται λευκά. Η αύξηση του κατωφλίου μετατρέπει περισσότερες αποχρώσεις σε μαύρο επειδή περισσότερα pixel πέφτουν κάτω από το όριο.

Κατεβάστε το αρχείο [grayscale-swatches.png](grayscale-swatches.png) στον φάκελο εργασίας. Κάθε ετικέτα δείχνει το αρχικό επίπεδο γκρι σε κλίμακα από 0 έως 255. Το παράδειγμα τοποθετεί το αρχικό δίπλα σε δύο αντίγραφα και αποθηκεύει το κατώφλι του κάθε αντιγράφου στην παρουσίαση.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

Ανοίξτε την παραγόμενη παρουσίαση στο PowerPoint για να συγκρίνετε τα τρία πλαίσια. Το δείγμα με ετικέτα 96 έχει περίπου 38 % φωτεινότητα (96 από 255). Μετατρέπεται σε λευκό στο κατώφλι 20 % και σε μαύρο στο κατώφλι 60 %.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Προσθήκη Θόλωσης, Διαφάνειας και Επιδράσεων Άλφα**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένης της άλφα. Ορίστε `grow` σε `true` όταν η θολή άκρη μπορεί να εκτείνεται πέρα από τα αρχικά όρια της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε το [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, ώστε τα μερικώς διαφανή pixel να παραμένουν αναλογικά διαφορετικά. Το [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) αντιθέτως αντιστοιχίζει μια τιμή άλφα σε όλα τα pixel. Το [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) μετατρέπει την άλφα σε δύο επίπεδα βάσει ενός κατωφλίου.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

Άλλες λειτουργίες άλφα χωρίς παραμέτρους περιλαμβάνουν το [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), που κάνει κάθε μη μηδενική άλφα πλήρως αδιαφανή· το [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), που κάνει κάθε άλφα κάτω από 100 % πλήρως διαφανές· και το [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), που μετατρέπει την άλφα σε `100% - alpha`.

## **Δημιουργία Ταξινομημένης Αλυσίδας Επιδράσεων**

Κάθε μέθοδος `Add...Effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο προδράστης (renderer) χρησιμοποιεί τη συλλογή ως μια ταξινομημένη διαδρομή: η έξοδος της λειτουργίας 0 γίνεται η είσοδος της λειτουργίας 1, κ.ο.κ. Συνεπώς, οι ίδιες λειτουργίες σε διαφορετική σειρά μπορούν να παραγάγουν διαφορετική εικόνα.

Για παράδειγμα, η γκρι απόχρωση ακολουθούμενη από απόχρωση (tint) πρώτα αφαιρεί τις χρωματικές πληροφορίες και μετά επαναχρωματίζει το αποτέλεσμα της φωτεινότητας. Η απόχρωση πριν τη γκρι απόχρωση αφαιρεί ξανά την απόχρωση. Αντίστοιχα, η αντικατάσταση άλφα μπορεί να υπερισχύσει των τιμών άλφα που υπολογίστηκαν από προγενέστερες λειτουργίες, ενώ η διαμόρφωση άλφα διατηρεί τις σχετικές τους διαφορές.

Το παρακάτω παράδειγμα δημιουργεί μια αλυσίδα τεσσάρων λειτουργιών, την αποθηκεύει ως PPTX, ανοίγει ξανά την παρουσίαση, ελέγχει τόσο τους τύπους λειτουργιών όσο και τη σειρά τους, και αποδίδει το ξαναανοιγμένο αποτέλεσμα:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

Η συλλογή δεν επιβάλλει έναν πίνακα συμβατότητας που περιορίζει τις λειτουργίες χρώματος, άλφα και θόλωσης σε χωριστές αλυσίδες. Μπορούν να συνδυαστούν, αλλά οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Η σταθερή αντικατάσταση χρώματος αφαιρεί τις διακυμάνσεις RGB που προέκυψαν από προηγούμενες επιδράσεις χρώματος· η γκρι μετά το δυότονο αφαιρεί τα δύο επιλεγμένα χρώματα· και οι λειτουργίες άλφα ceiling, floor, replacement ή bi‑level μπορούν να καταργήσουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Δημιουργήστε την αλυσίδα σύμφωνα με την επιθυμητή ακολουθία επεξεργασίας pixel και όχι ως αδιάτακτες σημαίες μορφοποίησης.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Σε αυτή την εικονογραφική απόδοση του Aspose.Slides for .NET 26.11, μια απόχρωση 220° με 25 % δεν αλλάζει την γκρι εικόνα. Η εφαρμογή της ίδιας απόχρωσης πριν από τη γκρι απόχρωση παράγει διαφορετικούς τόνους.*
<!-- visual-explanation:image-transform-effects:end -->

## **Επιθεώρηση Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο αποθηκευμένο στο `ISlidesPicture.ImageTransform`. Ανάλογα με την επίδραση, μπορεί να εκθέτει εγγράψιμα μέλη απευθείας. Για παράδειγμα, το [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) εκθέτει εγγράψιμα `Radius` και `Grow`, το [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) εκθέτει εγγράψιμο `Amount`, και το [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) εκθέτει εγγράψιμο `Threshold`. Οι επιδράσεις χρώματος όπως το [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) εκθέτουν μεταβλητά αντικείμενα [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/).

Κάποιες διεπαφές λειτουργιών, όπως τα [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/), και [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/), δεν εκθέτουν τα αρχικά τους σκαλοποιημένα δεδομένα ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στη ζητούμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει το `GetEffective()` είναι υπολογισμένα και μόνο για ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων εξαρτώμενων από το θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο προδράστης, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα απαριθμεί την αλυσίδα και επιθεωρεί τις αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

Οι λειτουργίες χωρίς παραμέτρους, όπως η γκρι απόχρωση, το αλφα ceiling και το αλφα inverse, έχουν επίσης αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν κλιμακωτές τιμές για εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι η σημαντική πληροφορία.

## **Αφαίρεση ή Εκκαθάριση Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε το [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) για να αφαιρέσετε μια λειτουργία βάσει δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, αναζητήστε πρώτα τον στόχο και αφαιρέστε τον μετά την απαρίθμηση. Χρησιμοποιήστε το `Clear()` για να αφαιρέσετε ολόκληρη την αλυσίδα.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

Η αφαίρεση ή η εκκαθάριση των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, δεν συμπιέζει ξανά και δεν τροποποιεί τον επαναχρησιμοποιούμενο πόρο [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).

## **Σκέψη Μορφών Παρουσίασης και Στόχων Εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, επομένως το PPTX είναι η προτιμώμενη επεξεργάσιμη μορφή για αλυσίδες επιδράσεων. Ακόμα και με PPTX, δεν είναι όλες οι λειτουργίες εξίσου φορητές:

- Οι τυπικές λειτουργίες DrawingML όπως luminance, grayscale, duotone, tint, HSL, blur και κοινές λειτουργίες άλφα έχουν τις καλύτερες πιθανότητες να παραμείνουν μετά από κύκλο αποθήκευσης PPTX. Πάντα ανοίξτε ξανά το παραγόμενο αρχείο και επιθεωρήστε τη συλλογή όταν η διατήρηση είναι απαραίτητη.
- Το [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) είναι μια επέκταση του Office 2010 και όχι η τυπική λειτουργία luminance του DrawingML. Μπορεί να χρησιμοποιηθεί για απόδοση εν όρους μνήμης, αλλά δεν εγγυάται ότι θα παραμείνει ως επεξεργάσιμο [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) μετά την αποθήκευση και ξαναφόρτωση του PPTX. Προτιμήστε το [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) για μόνιμες ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προπορεύεται του πλήρους μοντέλου αποτελεσμάτων DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει την αλυσίδα σε υποσύνολο ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για μια πολύπλοκη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλες οπτικές εξόδους εφαρμόζει την υποστηριζόμενη αλυσίδα στην αποδιδόμενη εμφάνιση. Αυτές οι εξόδους δεν περιέχουν την επεξεργάσιμη `IImageTransformOperationCollection`; οι μορφές raster ισοπεδώνουν το αποτέλεσμα σε pixel, ενώ οι εξαγωγές εγγράφου/διανύσματος αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Οι επιδράσεις δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν φορτώνεται η παρουσίαση.

Διαφορετικοί καταναλωτές παρουσιάσεων μπορεί να αποδίδουν περιπτώσεις ορίων διαφορετικά, ειδικά όταν συνδυάζονται πολλές λειτουργίες άλφα ή χρωματικής κβαντοποίησης. Για κρίσιμα αποτελέσματα, δοκιμάστε τόσο τον επεξεργάσιμο κύκλο όσο και τη μορφή τελικής εξαγωγής με την ίδια έκδοση του Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **Συχνές Ερωτήσεις**

**Τροποποιούν οι επιδράσεις μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `ISlidesPicture` που χρησιμοποιείται από το γέμισμα εικόνας. Τα υποκείμενα byte του `IPPImage` παραμένουν αμετάβλητα.

**Θα μοιραστούν δύο πλαίσια εικόνας που επαναχρησιμοποιούν την ίδια εικόνα τις επιδράσεις τους;**

Όχι. Η επαναχρήση ενός `IPPImage` αποφεύγει διπλά δεδομένα εικόνας, αλλά κάθε πλαίσιο εικόνας συνήθως έχει ξεχωριστό `ISlidesPicture` και τη δική του συλλογή μετασχηματισμών εικόνας.

**Μπορούν να συνδυαστούν οι επιδράσεις χρώματος, θόλωσης και άλφα;**

Ναι. Η συλλογή τις αποδέχεται σε μια ταξινομημένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, επειδή οι λειτουργίες αντικατάστασης και κατωφλίου μπορούν να εξαφανίσουν χρωματικές ή άλφα λεπτομέρειες από προηγούμενες λειτουργίες.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο για ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που είναι αποθηκευμένη στη συλλογή μετασχηματισμών όπου υπάρχουν εγγράψιμα μέλη· διαφορετικά αφαιρέστε την και προσθέστε μια αντικατάσταση με νέα αρχικά παραμέτρους.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμών;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντας το ξανά. Η παλαιότερη μορφή PPT δεν μπορεί να αντιπροσωπεύσει το πλήρες μοντέλο αποτελεσμάτων DrawingML, και οι μορφές εξαγωγής διατηρούν μόνο την εμφάνιση, όχι τις επεξεργάσιμες λειτουργίες μετασχηματισμού.
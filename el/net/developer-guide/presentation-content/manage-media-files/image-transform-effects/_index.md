---
title: Διαχείριση εφέ μετασχηματισμού εικόνας σε παρουσιάσεις με .NET
linktitle: Εφέ μετασχηματισμού εικόνας
type: docs
weight: 11
url: /el/net/image-transform-effects/
keywords:
- μετασχηματισμός εικόνας
- εφέ εικόνας
- φωτεινότητα
- αντίθεση
- γκρι κλίμακα
- δυτονικό
- χρωματισμός
- HSL
- αντικατάσταση χρώματος
- θόλωση
- διαφάνεια
- εφέ άλφα
- αλυσίδα εφέ
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εφαρμόστε, συνδυάστε, ελέγξτε, αφαιρέστε και επαληθεύστε εφέ μετασχηματισμού εικόνας για πλαίσια εικόνας με Aspose.Slides για .NET."
---
## **Επισκόπηση**

Aspose.Slides αντιπροσωπεύει τις ρυθμίσεις εικόνας ως μια διατεταγμένη συλλογή λειτουργιών μετασχηματισμού εικόνας. Για ένα πλαίσιο εικόνας, ξεκινήστε με το πλαίσιο του [ISlidesPicture](https://reference.aspose.com/slides/el/net/aspose.slides/islidespicture/) και αποκτήστε πρόσβαση στο [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/el/net/aspose.slides/islidespicture/imagetransform/). Η επιστρεφόμενη [IImageTransformOperationCollection](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/) σας επιτρέπει να προσθέτετε, να καταμετράτε, να ελέγχετε, να αφαιρείτε και να καθαρίζετε εφέ χωρίς να ξαναγράψετε τα αρχικά image bytes.

Αυτό το άρθρο δείχνει μια πλήρη ροή εργασίας για τη φωτεινότητα και αντίθεση, τις μετασχηματισμούς χρώματος, την θόλωση, τη διαφάνεια, τις διατεταγμένες αλυσίδες εφέ, τις αποτελεσματικές τιμές, την αφαίρεση και την επαλήθευση γύρω από το PPTX.

## **Κατανόηση Ιδιοκτησίας Εφέ και Επαναχρησιμοποίησης Εικόνας**

Ένας πόρος εικόνας και η εικόνα που την εμφανίζει είναι διαφορετικά αντικείμενα:

- [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) αποθηκεύει ή αναφέρει τα δεδομένα πηγής εικόνας που ανήκουν στην παρουσίαση.
- [ISlidesPicture](https://reference.aspose.com/slides/el/net/aspose.slides/islidespicture/) ανήκει σε γέμιση εικόνας και αναφέρεται σε πόρο εικόνας ενώ αποθηκεύει τη συλλογή μετασχηματισμού εικόνας.
- [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) είναι το σχήμα διαφάνειας που κατέχει το σχετικό γέμισμα εικόνας, τη γεωμετρία, τις ρυθμίσεις περικοπής και άλλες μορφοποιήσεις επιπέδου πλαισίου.

Συνεπώς, οι λειτουργίες μετασχηματισμού εικόνας δεν τροποποιούν τα bytes στο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/). Όταν το ίδιο `IPPImage` περάσει στο [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/addpictureframe/) περισσότερες από μία φορές, κάθε νέο πλαίσιο εικόνας λαμβάνει το δικό του `ISlidesPicture` και τη δική του συλλογή μετασχηματισμού. Η εφαρμογή γκρι κλίμακας σε ένα πλαίσιο δεν κάνει τα άλλα πλαίσια γκρι κλίμακας, ακόμη και αν όλα χρησιμοποιούν τον ίδιο ενσωματωμένο πόρο εικόνας.

Το ίδιο μοντέλο `ISlidesPicture.ImageTransform` χρησιμοποιείται επίσης από άλλες γεμίσεις εικόνας, όπως σχήμα ή φόντο διαφάνειας. Τα παραδείγματα παρακάτω επικεντρώνονται στα πλαίσια εικόνας.

## **Χρήση Έγκυρων Διαστημάτων Παραμέτρων και Μονάδων**

Οι παρουσιαζόμενες μέθοδοι χρησιμοποιούν τα ακόλουθα λογικά διαστήματα και μονάδες. Κρατήστε τις τιμές εντός αυτών των διαστημάτων ακόμα και αν μια συγκεκριμένη έκδοση της βιβλιοθήκης δεν απορρίπτει αμέσως κάθε τιμή εκτός διαστήματος· η μορφή παρουσίασης-στόχος μπορεί να κανονικοποιήσει, να παραλείψει ή να απορρίψει τα μη έγκυρα δεδομένα κατά την αποθήκευση ή όταν το PowerPoint ανοίξει το αρχείο.

| Λειτουργία | Παράμετροι | Έγκυρη εμβέλεια και μονάδα |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` έως `100`, ποσοστό· `0` αφήνει το στοιχείο αμετάβλητο. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | Καμία αριθμητική παράμετρος. Το άλφα παραμένει αμετάβλητο. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Δύο χρώματα για σκοτεινά και φωτεινά pixel. Τα κανάλια RGB και άλφα στο System.Drawing.Color χρησιμοποιούν τιμές από `0` έως `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` είναι από `0` (συμπεριλαμβανομένου) έως `360` (μη συμπεριλαμβανομένου) μοίρες· `amount` είναι από `-100` έως `100` ποσοστό. |
| [AddHSLEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` είναι από `0` (συμπεριλαμβανομένου) έως `360` (μη συμπεριλαμβανομένου) μοίρες· `saturation` και `luminance` είναι από `-100` έως `100` ποσοστό. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Το χρώμα αντικατάστασης χρησιμοποιεί τιμές καναλιών από `0` έως `255`. Οι υπάρχουσες τιμές άλφα παραμένουν αμετάβλητες. |
| [AddBlurEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Η ακτίνα είναι μη αρνητική και μετριέται σε σημείο· `grow` είναι Boolean που ελέγχει αν το θολό περιεχόμενο μπορεί να εκτείνεται εκτός των αρχικών ορίων. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Μη αρνητικό ποσοστό. Χρησιμοποιήστε `0` έως `100` για κανονική κλιμάκωση διαφάνειας: `0` είναι πλήρως διαφανές και `100` διατηρεί το υπάρχον άλφα. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` έως `100`, ποσοστό αδιαφάνειας. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` έως `100`, ποσοστό κατωφλίου άλφα. Τιμές κάτω από αυτό γίνονται διαφανείς· τιμές ίσες ή άνω γίνονται αδιαφανείς. |

Για σταθερό μοντέλο άλφα, η διαφάνεια και η αδιαφάνεια είναι συμπληρωματικές. Για παράδειγμα, 35 % διαφάνεια αντιστοιχεί σε ποσό μοντελοποίησης άλφα 65 %.

## **Εφαρμογή Φωτεινότητας και Αντίθεσης**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) επιστρέφει μια λειτουργία [IBrightnessContrast](https://reference.aspose.com/slides/el/net/aspose.slides.effects/ibrightnesscontrast/). Οι μονάδες ρυθμίσεις της παρέχονται όταν δημιουργείται η λειτουργία. Το [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/el/net/aspose.slides.effects/brightnesscontrast/geteffective/) επιστρέφει υπολογισμένες μόνο-ανάγνωση τιμές που μπορούν να ελεγχθούν ή να καταγραφούν.

Το παρακάτω παράδειγμα αυξάνει τη φωτεινότητα κατά 15 % και την αντίθεση κατά 20 %, στη συνέχεια αποδίδει προεπισκόπηση χωρίς να τροποποιεί την ενσωματωμένη εικόνα:

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

[BrightnessContrast](https://reference.aspose.com/slides/el/net/aspose.slides.effects/brightnesscontrast/) είναι μια επέκταση εφέ εικόνας του Office 2010 και είναι λιγότερο φορητή από το τυπικό εφέ luminance του DrawingML. Όταν η φωτεινότητα και η αντίθεση πρέπει να παραμείνουν επεξεργάσιμες μετά από κύκλο PPTX, χρησιμοποιήστε το [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) και επαληθεύστε το αποτέλεσμα μετά το άνοιγμα του αρχείου. Η ενότητα περιορισμών μορφοτύπου εξηγεί αυτή τη διάκριση με περισσότερες λεπτομέρειες.

## **Εφαρμογή Μετασχηματισμών Χρώματος**

Τα εφέ χρώματος μπορούν να εφαρμοστούν ανεξάρτητα σε διαφορετικά πλαίσια εικόνας που χρησιμοποιούν τον ίδιο πόρο εικόνας. Το παρακάτω παράδειγμα δημιουργεί πέντε πλαίσια και εφαρμόζει γκρι κλίμακα, duetone, χρωματισμό, ρύθμιση HSL και αντικατάσταση χρώματος.

[IDuotone](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iduotone/) περιέχει δύο ανεξάρτητα επεξεργάσιμες παραμέτρους χρώματος: το `Color1` αντιστοιχεί σε σκοτεινά pixel, ενώ το `Color2` αντιστοιχεί σε φωτεινά pixel. Αυτό το καθιστά χρήσιμο παράδειγμα εφέ των ρυθμίσεων του οποίου είναι πιο πολύπλοκες από μια μοναδική κλιμακωτή τιμή.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) αντικαθιστά το χρώμα κάθε pixel με ένα σταθερό χρώμα διατηρώντας το άλφα. Είναι διαφορετικό από το [AddColorChangeEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), το οποίο αντιστοιχίζει ένα χρώμα προέλευσης σε ένα άλλο και εκθέτει και τις μορφές χρώματος προέλευσης και στόχου.

## **Προσθήκη Θόλωσης, Διαφάνειας και Εφέ Άλφα**

[AddBlurEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) επηρεάζει όλα τα κανάλια χρώματος, συμπεριλαμβανομένου του άλφα. Ορίστε `grow` σε `true` όταν η θολή άκρη μπορεί να εκτείνεται πέρα από τα αρχικά όρια της εικόνας.

Για ομοιόμορφη διαφάνεια, χρησιμοποιήστε το [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Πολλαπλασιάζει κάθε υπάρχουσα τιμή άλφα, ώστε τα μερικώς διαφανή pixel να παραμένουν αναλογικά διαφορετικά. Το [AddAlphaReplaceEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) αντιθέτως εκχωρεί μία τιμή άλφα σε όλα τα pixel. Το [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) μετατρέπει το άλφα σε δύο επίπεδα βάσει ενός κατωφλίου.

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

Άλλες λειτουργίες άλφα χωρίς παραμέτρους περιλαμβάνουν το [AddAlphaCeilingEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), που κάνει κάθε μη μηδενικό άλφα πλήρως αδιαφανές· το [AddAlphaFloorEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), που κάνει κάθε άλφα κάτω από 100 % πλήρως διαφανές· και το [AddAlphaInverseEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), που αλλάζει το άλφα σε `100% - alpha`.

## **Δημιουργία Διατεταγμένης Αλυσίδας Εφέ**

Κάθε μέθοδος `Add...Effect` προσθέτει μια νέα λειτουργία στο τέλος της συλλογής. Ο αποδοχέας χρησιμοποιεί τη συλλογή ως διατεταγμένο pipeline: η έξοδος της λειτουργίας 0 γίνεται η είσοδος της λειτουργίας 1, κλπ. Συνεπώς, οι ίδιες λειτουργίες με διαφορετική σειρά μπορούν να παράγουν διαφορετική εικόνα.

Για παράδειγμα, γκρι κλίμακα ακολουθούμενη από χρωματισμό αφαιρεί πρώτα τις χρωματιστές πληροφορίες και μετά επαναχρωματίζει το αποτέλεσμα luminance. Χρωματισμός ακολουθούμενος από γκρι κλίμακα αφαιρεί ξανά τον χρωματισμό. Ομοίως, η αντικατάσταση άλφα μπορεί να παρακάμψει τιμές άλφα που υπολογίστηκαν από παλαιότερες λειτουργίες, ενώ η διαμόρφωση άλφα διατηρεί τις σχετικές διαφορές τους.

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

Η συλλογή δεν επιβάλλει μια μήτρα συμβατότητας που περιορίζει χρώμα, άλφα και λειτουργίες θόλωσης σε ξεχωριστές αλυσίδες. Μπορούν να συνδυαστούν, όμως οι συνδυασμοί δεν είναι πάντα χρήσιμοι. Μια σταθερή αντικατάσταση χρώματος αφαιρεί την μεταβλητότητα RGB που προκάλεσαν προηγούμενα εφέ χρώματος· η γκρι κλίμακα μετά το duetone αφαιρεί τα δύο επιλεγμένα χρώματα· και λειτουργίες άλφα όπως ceiling, floor, replacement ή bi‑level μπορούν να διαγράψουν λεπτομέρειες άλφα που δημιουργήθηκαν νωρίτερα. Κατασκευάστε την αλυσίδα σύμφωνα με τη ζητούμενη ακολουθία επεξεργασίας pixel αντί να θεωρείτε τα στοιχεία της ως μη ταξινομημένες σημαίες μορφοποίησης.

## **Έλεγχος Επεξεργάσιμων και Αποτελεσματικών Τιμών**

Μια επεξεργάσιμη λειτουργία είναι το αντικείμενο που αποθηκεύεται στο `ISlidesPicture.ImageTransform`. Ανάλογα με το εφέ, μπορεί να εκθέτει εγγράψιμα μέλη απευθείας. Για παράδειγμα, το [IBlur](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iblur/) εκθέτει εγγράψιμα `Radius` και `Grow`, το [IAlphaModulateFixed](https://reference.aspose.com/slides/el/net/aspose.slides.effects/ialphamodulatefixed/) εκθέτει εγγράψιμο `Amount`, και το [IAlphaBiLevel](https://reference.aspose.com/slides/el/net/aspose.slides.effects/ialphabilevel/) εκθέτει εγγράψιμο `Threshold`. Εφέ χρώματος όπως το [IDuotone](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iduotone/) εκθέτουν μεταβλητά αντικείμενα [IColorFormat](https://reference.aspose.com/slides/el/net/aspose.slides/icolorformat/).

Ορισμένες διεπαφές λειτουργιών, όπως τα [IBrightnessContrast](https://reference.aspose.com/slides/el/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/el/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/el/net/aspose.slides.effects/itint/), και [IAlphaReplace](https://reference.aspose.com/slides/el/net/aspose.slides.effects/ialphareplace/), δεν εκθέτουν τα αρχικά τους scalars ως εγγράψιμες ιδιότητες. Για να αλλάξετε αυτές τις ρυθμίσεις, αφαιρέστε τη λειτουργία και προσθέστε μια αντικατάσταση στην απαιτούμενη θέση.

Τα αποτελεσματικά δεδομένα που επιστρέφει το `GetEffective()` υπολογίζονται και είναι μόνο‑ανάγνωση. Είναι χρήσιμα για την επίλυση χρωμάτων εξαρτώμενων από θέμα και για την ανάγνωση των κανονικοποιημένων τιμών που χρησιμοποιεί ο αποδοχέας, αλλά δεν αποτελούν άλλη επιφάνεια επεξεργασίας. Το παρακάτω παράδειγμα καταμετρά την αλυσίδα και ελέγχει τις αποτελεσματικές τιμές όπου το αντίστοιχο API τις παρέχει:

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

Οι λειτουργίες χωρίς παραμέτρους όπως γκρι κλίμακα, αλφα ceiling και αλφα inverse διαθέτουν ακόμη αντικείμενο αποτελεσματικών δεδομένων, αλλά δεν υπάρχουν scalar ρυθμίσεις προς εκτύπωση. Η παρουσία και η θέση τους στη συλλογή είναι οι σημαντικές πληροφορίες.

## **Αφαίρεση ή Καθαρισμός Μετασχηματισμών Εικόνας**

Χρησιμοποιήστε το [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) για να αφαιρέσετε μια λειτουργία με βάση το δείκτη. Επειδή οι δείκτες μετατοπίζονται μετά την αφαίρεση, αναζητήστε πρώτα τον στόχο και αφαιρέστε τον μετά την καταμέτρηση. Χρησιμοποιήστε `Clear()` για να αφαιρέσετε ολόκληρη την αλυσίδα.

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

Η αφαίρεση ή ο καθαρισμός των μετασχηματισμών αλλάζει μόνο τη μορφοποίηση της εικόνας. Δεν διαγράφει, δεν συμπιέζει ξανά και δεν τροποποιεί με άλλο τρόπο τον επαναχρησιμοποιούμενο πόρο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/).

## **Λήψη Υπόψη Μορφών Παρουσίασης και Στόχων Εξαγωγής**

Οι μετασχηματισμοί εικόνας προέρχονται από το DrawingML, επομένως το PPTX είναι η προτιμώμενη επεξεργάσιμη μορφή για αλυσίδες εφέ. Ακόμη και με PPTX, δεν έχει κάθε λειτουργία την ίδια φορητότητα:

- Οι τυπικές λειτουργίες DrawingML όπως luminance, grayscale, duotone, tint, HSL, blur και κοινές λειτουργίες άλφα έχουν την καλύτερη πιθανότητα να επιβιώσουν σε κύκλο PPTX. Πάντα ανοίξτε ξανά το παραχθέν αρχείο και ελέγξτε τη συλλογή όταν η διατήρηση είναι απαίτηση.
- Το [BrightnessContrast](https://reference.aspose.com/slides/el/net/aspose.slides.effects/brightnesscontrast/) είναι μια επέκταση Office 2010 αντί για την τυπική λειτουργία luminance του DrawingML. Μπορεί να χρησιμοποιηθεί για απόδοση εν ενόσειρα, αλλά δεν είναι εγγυημένο ότι θα παραμείνει ως επεξεργάσιμο [IBrightnessContrast](https://reference.aspose.com/slides/el/net/aspose.slides.effects/ibrightnesscontrast/) μετά την αποθήκευση και το άνοιγμα του PPTX. Προτιμήστε το [AddLuminanceEffect](https://reference.aspose.com/slides/el/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) για επίμονες ρυθμίσεις φωτεινότητας και αντίθεσης.
- Η δυαδική μορφή PPT προηγήθηκε του πλήρους μοντέλου εφέ DrawingML. Η αποθήκευση σε PPT μπορεί να παραλείψει μη υποστηριζόμενες λειτουργίες, να μειώσει μια αλυσίδα σε ένα υποστηριζόμενο υποσύνολο ή να προσεγγίσει την εμφάνιση. Μην χρησιμοποιείτε το PPT ως μορφή επαλήθευσης για σύνθετη επεξεργάσιμη αλυσίδα.
- Η απόδοση σε PNG, JPEG, TIFF, PDF, SVG, HTML ή άλλα οπτικά αρχεία εφαρμόζει την υποστηριζόμενη αλυσίδα στην απόδοση. Αυτές οι εξαγωγές δεν περιέχουν επεξεργάσιμο `IImageTransformOperationCollection`; οι μορφές raster ισοσταθμίζουν το αποτέλεσμα σε pixel, ενώ οι εξαγωγές εγγράφου/διανύσματος αποθηκεύουν τη δική τους αναπαράσταση απόδοσης.
- Τα εφέ δεν κάνουν μια συνδεδεμένη εικόνα αυτόνομη. Η απόδοση μιας συνδεδεμένης εικόνας εξακολουθεί να εξαρτάται από τη διαθεσιμότητα του συνδεδεμένου πόρου όταν φορτώνεται η παρουσίαση.

Διάφοροι καταναλωτές παρουσίασης μπορεί να αποδίδουν περιπτώσεις άκρων διαφορετικά, ειδικά όταν συνδυάζονται πολλές λειτουργίες άλφα ή χρωματικής ποσοτικοποίησης. Για κρίσιμη έξοδο, δοκιμάστε τόσο τον επεξεργάσιμο κύκλο όσο και την τελική μορφή εξαγωγής με την ίδια έκδοση Aspose.Slides που χρησιμοποιείται στην παραγωγή.

## **FAQ**

**Τροποποιούν οι λειτουργίες μετασχηματισμού εικόνας τα ενσωματωμένα δεδομένα εικόνας;**

Όχι. Οι λειτουργίες ανήκουν στο `ISlidesPicture` που χρησιμοποιείται από τη γέμιση εικόνας. Τα υποκείμενα bytes του `IPPImage` παραμένουν αμετάβλητα.

**Μοιράζονται δύο πλαίσια εικόνας που χρησιμοποιούν την ίδια εικόνα τα εφέ τους;**

Όχι. Η επαναχρησιμοποίηση ενός `IPPImage` αποτρέπει την επανάληψη δεδομένων εικόνας, αλλά κάθε πλαίσιο εικόνας συνήθως έχει ξεχωριστό `ISlidesPicture` και συλλογή μετασχηματισμού εικόνας.

**Μπορούν να συνδυαστούν χρωματικά, θολής και άλφα εφέ;**

Ναι. Η συλλογή τα αποδέχεται σε μία διατεταγμένη αλυσίδα. Σκεφτείτε τι κάνει κάθε λειτουργία στην έξοδο της προηγούμενης, επειδή οι λειτουργίες αντικατάστασης και κατωφλίου μπορούν να διαγράψουν χρώμα ή άλφα που είχαν παραχθεί νωρίτερα.

**Γιατί οι αποτελεσματικές τιμές είναι μόνο‑ανάγνωση;**

Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν υπολογισμένες τιμές που χρησιμοποιούνται για απόδοση, συμπεριλαμβανομένων των επιλυμένων χρωμάτων. Επεξεργαστείτε τη λειτουργία που αποθηκεύεται στη συλλογή μετασχηματισμού όπου υπάρχουν εγγράψιμα μέλη· διαφορετικά αφαιρέστε τη και προσθέστε μια αντικατάσταση με νέες παραμέτρους δημιουργίας.

**Ποια μορφή πρέπει να χρησιμοποιήσω για να διατηρήσω μια αλυσίδα μετασχηματισμών;**

Χρησιμοποιήστε PPTX και επαληθεύστε το αρχείο ανοίγοντάς το ξανά. Η παλαιότερη μορφή PPT δεν μπορεί να αντιπροσωπεύσει το πλήρες μοντέλο εφέ DrawingML, ενώ οι μορφές εξαγωγής αποθηκεύουν την εμφάνιση αντί για επεξεργάσιμες λειτουργίες μετασχηματισμού.
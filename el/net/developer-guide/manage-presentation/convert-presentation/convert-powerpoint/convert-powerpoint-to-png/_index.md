---
title: Μετατροπή Διαφανειών PowerPoint σε PNG σε .NET
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/net/convert-powerpoint-to-png/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε PNG
- παρουσίαση σε PNG
- διαφάνεια σε PNG
- PPT σε PNG
- PPTX σε PNG
- αποθήκευση PPT ως PNG
- αποθήκευση PPTX ως PNG
- εξαγωγή PPT σε PNG
- εξαγωγή PPTX σε PNG
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint σε εικόνες PNG υψηλής ποιότητας γρήγορα με το Aspose.Slides για .NET, εξασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε διαφάνειες παρουσίασης σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides για .NET. Μπορείτε να φορτώσετε παρουσιάσεις σε μορφές όπως PPT, PPTX και ODP, να αποδώσετε κάθε διαφάνεια και να την αποθηκεύσετε ως ξεχωριστή εικόνα PNG.

Τα παρακάτω παραδείγματα επιδεικνύουν την απόδοση μικρογραφιών, τον ορισμό συντελεστών κλίμακας, τον καθορισμό των διαστάσεων εξόδου σε εικονοστοιχεία και την επιλογή στυλ απόδοσης διαβάθμισης.

## **Μετατροπή PowerPoint σε PNG**

Φορτώστε μια παρουσίαση με την κλάση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) και αποκτήστε πρόσβαση στις διαφάνειες της μέσω της συλλογής [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). Το παράδειγμα αποδίδει κάθε διαφάνεια με το [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) χωρίς παραμέτρους για να δημιουργήσει μια μικρογραφία. Στη συνέχεια καλεί το [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) με το [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) για να αποθηκεύσει κάθε αποδοθείσα διαφάνεια ως εικόνα PNG.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
Η υπερφόρτωση [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) χωρίς παραμέτρους αποδίδει με κλίμακα 0.2. Για παράδειγμα, μια διαφάνεια μεγέθους 720 × 540 σημεία παράγει μια μικρογραφία 144 × 108 εικονοστοιχεία. Για να ελέγξετε τις διαστάσεις εξόδου, χρησιμοποιήστε τις υπερφορτώσεις με συντελεστές κλίμακας ή ένα σαφές μέγεθος εικόνας όπως φαίνεται παρακάτω.
{{% /alert %}}

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένες Διαστάσεις**

Περάστε οριζόντιους και κάθετους συντελεστές κλίμακας στο [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) για να ελέγξετε τις αποδοθείσες διαστάσεις. Σε αυτό το παράδειγμα, και οι δύο συντελεστές είναι 2, έτσι μια διαφάνεια μεγέθους 720 × 540 σημεία παράγει μια εικόνα 1440 × 1080 εικονοστοιχεία. Οι ίσοι συντελεστές κλίμακας διατηρούν την αναλογία διαστάσεων της διαφάνειας. Κάθε εικόνα αποθηκεύεται σε μορφή PNG με το [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένο Μέγεθος**

Για να καθορίσετε τις διαστάσεις εξόδου σε εικονοστοιχεία, περάστε ένα μέγεθος στο [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) αντί για συντελεστές κλίμακας. Αυτό το παράδειγμα αποδίδει κάθε διαφάνεια σε 960 × 720 εικονοστοιχεία και αποθηκεύει το αποτέλεσμα με το [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Επιλέξτε διαστάσεις που ταιριάζουν με την αναλογία διαστάσεων της διαφάνειας ώστε να αποφύγετε το τράντσαλιση της εικόνας.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Επιλέξτε Στυλ Απόδοσης Διαβάθμισης**

Υποθέστε ότι μια διαφάνεια περιέχει γεμίσματα διαβάθμισης, αλλά οι μεταβάσεις στην εξαγόμενη PNG εμφανίζονται πιο ανοιχτές ή διαφορετικές από ό,τι βλέπετε στο PowerPoint. Μπορείτε να χρησιμοποιήσετε την ιδιότητα [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) της [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) για να επιλέξετε πώς θα αποδίδονται οι διαβαθμίσεις.

Κατεβάστε το [gradient-styles.pptx](gradient-styles.pptx) και τοποθετήστε το στον φάκελο εργασίας της εφαρμογής. Η πρώτη του διαφάνεια περιέχει δύο γραμμικές διαβαθμίσεις: κυανό σε πορτοκαλί στην κορυφή και μπλε σε κίτρινο στο κάτω μέρος. Κάθε διαβάθμιση έχει δύο στάσεις, στο 0 % και στο 100 %.

Το παρακάτω παράδειγμα φορτώνει αυτήν την παρουσίαση και αποδίδει την ίδια πρώτη διαφάνεια και στις δύο λειτουργίες με το [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

Οι παρακάτω εικόνες δείχνουν την έξοδο από την ίδια διαφάνεια, με και τις δύο διαβαθμίσεις σε κάθε εικόνα:

| Προεπιλογή | PowerPointUI |
| --- | --- |
| ![Διαβαθμίσεις κυανό‑πορτοκαλί και μπλε‑κίτρινο αποδομένες με Default](gradient-Default.png) | ![Οι ίδιες διαβαθμίσεις αποδομένες με PowerPointUI](gradient-PowerPointUI.png) |

Σε αυτό το παράδειγμα, `Default` παράγει πιο ανοιχτά ενδιάμεσα χρώματα, ενώ `PowerPointUI` παράγει πιο σκούρα ενδιάμεσα χρώματα. Η διαφορά εξαρτάται από τα χρώματα και τις στάσεις στη διαβάθμιση.

Επιλέξτε `Default` όταν η τυπική έξοδος του Aspose.Slides ανταποκρίνεται στις ανάγκες σας. Δοκιμάστε το `PowerPointUI` όταν η προτεραιότητά σας είναι η αντιστοίχιση της εμφάνισης στο PowerPoint. Συγκρίνετε και τις δύο εξόδους με το επιθυμητό αποτέλεσμα· κανένας τρόπος δεν είναι παγκοσμιώς προτιμότερος.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξάγω ένα συγκεκριμένο σχήμα, όπως ένα διάγραμμα ή εικόνα, αντί για ολόκληρη τη διαφάνεια;**

Το Aspose.Slides υποστηρίζει τη [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/net/create-shape-thumbnails/), επιτρέποντάς σας να αποδώσετε ένα σχήμα ως εικόνα PNG.

**Υποστηρίζεται η παράλληλη μετατροπή σε διακομιστή;**

Ναι. Χρησιμοποιήστε ξεχωριστό αντικείμενο παρουσίασης για κάθε νήμα ή διεργασία· [μην μοιράζεστε ένα ενιαίο αντικείμενο μεταξύ νημάτων](/slides/el/net/multithreading/).

**Ποιες είναι οι περιορισμοί της δοκιμαστικής έκδοσης κατά την εξαγωγή σε PNG;**

Η δοκιμαστική λειτουργία προσθέτει υδατογράφημα στις εικόνες εξόδου και εφαρμόζει [άλλους περιορισμούς](/slides/el/net/licensing/) μέχρι να εφαρμοστεί άδεια.
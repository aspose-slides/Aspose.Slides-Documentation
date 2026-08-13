---
title: Μετατροπή Διαφανειών PowerPoint σε PNG στο .NET
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/net/convert-powerpoint-to-png/
keywords:
- Μετατροπή PowerPoint
- Μετατροπή παρουσίασης
- Μετατροπή διαφάνειας
- Μετατροπή PPT
- Μετατροπή PPTX
- PowerPoint σε PNG
- Παρουσίαση σε PNG
- Διαφάνεια σε PNG
- PPT σε PNG
- PPTX σε PNG
- Αποθήκευση PPT ως PNG
- Αποθήκευση PPTX ως PNG
- Εξαγωγή PPT σε PNG
- Εξαγωγή PPTX σε PNG
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint σε εικόνες PNG υψηλής ποιότητας γρήγορα με το Aspose.Slides για .NET, εξασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να φορτώνετε αρχεία παρουσίασης σε μορφές όπως PPT, PPTX και ODP, να αποδίδετε τις διαφάνειες ως εικόνες και να αποθηκεύετε τα αποτελέσματα σε μορφή PNG.

Το άρθρο επίσης παρουσιάζει πώς να προσαρμόσετε τις παραγόμενες εικόνες PNG ορίζοντας τιμές κλίμακας ή καθορίζοντας το επιθυμητό πλάτος και ύψος.

## **Μετατροπή PowerPoint σε PNG**

Πραγματοποιήστε τα εξής βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Αποκτήστε το αντικείμενο διαφάνειας από τη συλλογή [Presentation.Slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/properties/slides) μέσω της διεπαφής [ISlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide).
3. Χρησιμοποιήστε τη μέθοδο [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/el/net/aspose.slides/islide/getimage/) για να αποδώσετε κάθε διαφάνεια στην κλίμακα που χρειάζεστε.
4. Χρησιμοποιήστε τη μέθοδο [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/el/net/aspose.slides.ipresentation/save/methods/5) για να αποθηκεύσετε τη μικρογραφία της διαφάνειας σε μορφή PNG.

Αυτός ο κώδικας C# σας δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PNG. Το αντικείμενο Presentation μπορεί να φορτώσει PPT, PPTX, ODP κ.λπ., και στη συνέχεια κάθε διαφάνεια στο αντικείμενο Presentation μετατρέπεται σε μορφή PNG ή άλλη μορφή εικόνας.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**Σημείωση:** Τα ορίσματα κλίμακας `1f, 1f` αποδίδουν κάθε διαφάνεια στο πλήρες μέγεθός της, έτσι μια διαφάνεια 720×540 pt παράγει μια εικόνα 720×540 px. Η υπερφόρτωση [GetImage()](https://reference.aspose.com/slides/el/net/aspose.slides/islide/getimage/) χωρίς παραμέτρους επιστρέφει μια πολύ μικρότερη μικρογραφία προεπισκόπησης.
{{% /alert %}} 

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένες Διαστάσεις**

Αν θέλετε να λάβετε αρχεία PNG με συγκεκριμένη κλίμακα, μπορείτε να ορίσετε τις τιμές για `desiredX` και `desiredY`, που καθορίζουν τις διαστάσεις της προκύπτουσας μικρογραφίας. 

Αυτός ο κώδικας σε C# επιδεικνύει τη περιγραφόμενη λειτουργία:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένο Μέγεθος**

Αν θέλετε να λάβετε αρχεία PNG με συγκεκριμένο μέγεθος, μπορείτε να περάσετε τα προτιμώμενα ορίσματα `width` και `height` για το `imageSize`. 

Αυτός ο κώδικας σας δείχνει πώς να μετατρέψετε ένα PowerPoint σε PNG ενώ καθορίζετε το μέγεθος των εικόνων: 

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Συχνές Ερωτήσεις**

### Πώς μπορώ να εξάγω μόνο ένα συγκεκριμένο σχήμα (π.χ., διάγραμμα ή εικόνα) αντί για ολόκληρη τη διαφάνεια;

Το Aspose.Slides υποστηρίζει τη [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/net/create-shape-thumbnails/); μπορείτε να αποδώσετε ένα σχήμα σε εικόνα PNG.

### Υποστηρίζεται η παράλληλη μετατροπή σε διακομιστή;

Ναι, αλλά [μην μοιράζεστε](/slides/el/net/multithreading/) ένα μόνο αντικείμενο παρουσίασης μεταξύ νημάτων. Χρησιμοποιήστε ξεχωριστό αντικείμενο ανά νήμα ή διεργασία.

### Ποιες είναι οι περιορισμοί της δοκιμαστικής έκδοσης κατά την εξαγωγή σε PNG;

Η λειτουργία αξιολόγησης προσθέτει υδατογράφημα στις εικόνες εξόδου και επιβάλλει [άλλους περιορισμούς](/slides/el/net/licensing/) μέχρι να εφαρμοστεί άδεια.
---
title: Μετατροπή διαφανειών PowerPoint σε PNG στο .NET
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
description: Μετατρέψτε παρουσιάσεις PowerPoint σε εικόνες PNG υψηλής ποιότητας γρήγορα με το Aspose.Slides για .NET, διασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα.
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να φορτώνετε αρχεία παρουσίασης σε μορφές όπως PPT, PPTX και ODP, να αποδίδετε τις διαφάνειες ως εικόνες και να αποθηκεύετε τα αποτελέσματα σε μορφή PNG.

Το άρθρο επίσης παρουσιάζει πώς να προσαρμόσετε τις δημιουργημένες εικόνες PNG ορίζοντας τιμές κλίμακας ή καθορίζοντας το επιθυμητό πλάτος και ύψος.

## **Μετατροπή PowerPoint σε PNG**

Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Λάβετε το αντικείμενο διαφάνειας από τη συλλογή [Presentation.Slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/properties/slides) υπό το περιβάλλον [ISlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide).
3. Χρησιμοποιήστε τη μέθοδο [ISlide.GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/islide/getimage/) για να πάρετε τη μικρογραφία για κάθε διαφάνεια.
4. Χρησιμοποιήστε τη μέθοδο [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/el/net/aspose.slides.ipresentation/save/methods/5) για να αποθηκεύσετε τη μικρογραφία της διαφάνειας σε μορφή PNG.

Αυτός ο κώδικας C# δείχνει πώς να μετατρέψετε μια παρουσίαση PowerPoint σε PNG. Το αντικείμενο Presentation μπορεί να φορτώσει PPT, PPTX, ODP κ.λπ., μετά κάθε διαφάνεια στο αντικείμενο παρουσίασης μετατρέπεται σε μορφή PNG ή σε άλλη μορφή εικόνας.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένες Διαστάσεις**

Αν θέλετε να λάβετε αρχεία PNG με συγκεκριμένο κλίμακα, μπορείτε να ορίσετε τις τιμές για `desiredX` και `desiredY`, οι οποίες καθορίζουν τις διαστάσεις της προκύπτουσας μικρογραφίας.

Αυτός ο κώδικας C# δείχνει τη διαδικασία:

```c#
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

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε ένα PowerPoint σε PNG καθορίζοντας το μέγεθος των εικόνων:

```c#
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

## **ΣΥΝΑΡΤΗΣΕΙΣ (FAQ)**

**Πώς μπορώ να εξάγω μόνο ένα συγκεκριμένο σχήμα (π.χ. γράφημα ή εικόνα) αντί για ολόκληρη τη διαφάνεια;**

Το Aspose.Slides υποστηρίζει [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/net/create-shape-thumbnails/); μπορείτε να αποδώσετε ένα σχήμα σε εικόνα PNG.

**Υποστηρίζεται η παράλληλη μετατροπή σε διακομιστή;**

Ναι, αλλά [μην μοιράζεστε](/slides/el/net/multithreading/) ένα ενιαίο αντικείμενο παρουσίασης μεταξύ νημάτων. Χρησιμοποιήστε ξεχωριστό αντικείμενο ανά νήμα ή διαδικασία.

**Ποιους περιορισμούς έχει η δοκιμαστική έκδοση κατά την εξαγωγή σε PNG;**

Η λειτουργία αξιολόγησης προσθέτει υδατογράφημα στις εξαγόμενες εικόνες και επιβάλλει [άλλους περιορισμούς](/slides/el/net/licensing/) μέχρι να εφαρμοστεί άδεια.
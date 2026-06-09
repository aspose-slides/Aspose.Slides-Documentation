---
title: Μετατροπή PPT και PPTX σε JPG στο .NET
linktitle: PowerPoint σε JPG
type: docs
weight: 60
url: /el/net/convert-powerpoint-to-jpg/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε JPG
- παρουσίαση σε JPG
- διαφάνεια σε JPG
- PPT σε JPG
- PPTX σε JPG
- αποθήκευση PowerPoint ως JPG
- αποθήκευση παρουσίασης ως JPG
- αποθήκευση διαφάνειας ως JPG
- αποθήκευση PPT ως JPG
- αποθήκευση PPTX ως JPG
- εξαγωγή PPT σε JPG
- εξαγωγή PPTX σε JPG
- .NET
- C#
- Aspose.Slides
description: "Μετατροπή διαφανειών PowerPoint (PPT, PPTX) σε εικόνες JPG υψηλής ποιότητας σε C# με Aspose.Slides για .NET χρησιμοποιώντας γρήγορα, αξιόπιστα παραδείγματα κώδικα."
---
## **Εισαγωγή**

Η μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε εικόνες JPG βοηθά στην κοινή χρήση διαφανειών, στη βελτιστοποίηση της απόδοσης και στην ενσωμάτωση περιεχομένου σε ιστοσελίδες ή εφαρμογές. Το Aspose.Slides για .NET σας επιτρέπει να μετατρέπετε αρχεία PPTX, PPT και ODP σε εικόνες JPEG υψηλής ποιότητας. Αυτός ο οδηγός εξηγεί διάφορες μεθόδους μετατροπής.

Με αυτά τα χαρακτηριστικά, είναι εύκολο να υλοποιήσετε το δικό σας πρόγραμμα προβολής παρουσίασης και να δημιουργήσετε μικρογραφία για κάθε διαφάνεια. Αυτό μπορεί να είναι χρήσιμο εάν θέλετε να προστατεύσετε τις διαφάνειες της παρουσίασης από αντιγραφή ή να παρουσιάσετε την παρουσίαση σε λειτουργία μόνο‑ανάγνωσης. Το Aspose.Slides σας επιτρέπει να μετατρέψετε ολόκληρη την παρουσίαση ή μια συγκεκριμένη διαφάνεια σε μορφές εικόνας.

## **Μετατροπή διαφανειών παρουσίασης σε εικόνες JPG**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
1. Αποκτήστε το αντικείμενο διαφάνειας του τύπου [ISlide](https://reference.aspose.com/slides/el/net/aspose.slides/islide) από τη συλλογή [Presentation.Slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/properties/slides).
1. Δημιουργήστε μια εικόνα της διαφάνειας χρησιμοποιώντας τη μέθοδο [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/el/net/aspose.slides/islide/getimage/#getimage_5).
1. Καλέστε τη μέθοδο [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/save/#save_3) στο αντικείμενο εικόνας. Περάστε το όνομα του αρχείου εξόδου και τη μορφή εικόνας ως παραμέτρους.

{{% alert color="primary" %}} 
**Σημείωση:** Η μετατροπή PPT, PPTX ή ODP σε JPG διαφέρει από τη μετατροπή σε άλλες μορφές στο Aspose.Slides .NET API. Για άλλες μορφές, συνήθως χρησιμοποιείτε τη μέθοδο [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/save/#save_5). Ωστόσο, για μετατροπή σε JPG, πρέπει να χρησιμοποιήσετε τη μέθοδο [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/save/#save_3).
{{% /alert %}} 

```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Δημιουργήστε μια εικόνα διαφάνειας με την καθορισμένη κλίμακα.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Αποθηκεύστε την εικόνα στο δίσκο σε μορφή JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Μετατροπή διαφανειών σε JPG με προσαρμοσμένες διαστάσεις**

Για να αλλάξετε τις διαστάσεις των παραγόμενων εικόνων JPG, μπορείτε να ορίσετε το μέγεθος εικόνας περνώντας το στη μέθοδο [ISlide.GetImage(Size)](https://reference.aspose.com/slides/el/net/aspose.slides/islide/getimage/#getimage_6). Αυτό σας επιτρέπει να δημιουργείτε εικόνες με συγκεκριμένα πλάτη και ύψη, εξασφαλίζοντας ότι το αποτέλεσμα πληροί τις απαιτήσεις σας για ανάλυση και αναλογία διαστάσεων. Αυτή η ευελιξία είναι ιδιαίτερα χρήσιμη όταν δημιουργείτε εικόνες για διαδικτυακές εφαρμογές, αναφορές ή τεκμηρίωση, όπου απαιτούνται ακριβείς διαστάσεις εικόνας.

```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Δημιουργήστε μια εικόνα διαφάνειας με το καθορισμένο μέγεθος.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Αποθηκεύστε την εικόνα στο δίσκο σε μορφή JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Απόδοση σχολίων κατά την αποθήκευση διαφανειών ως εικόνες**

Το Aspose.Slides για .NET παρέχει μια δυνατότητα που επιτρέπει την απόδοση σχολίων στις διαφάνειες μιας παρουσίασης κατά τη μετατροπή τους σε εικόνες JPG. Αυτή η λειτουργία είναι ιδιαίτερα χρήσιμη για τη διατήρηση σημειώσεων, σχολίων ή συζητήσεων που προσθέτουν συνεργάτες σε παρουσιάσεις PowerPoint. Ενεργοποιώντας αυτήν την επιλογή, εξασφαλίζετε ότι τα σχόλια είναι ορατά στις παραγόμενες εικόνες, καθιστώντας ευκολότερη την ανασκόπηση και την κοινή χρήση σχολίων χωρίς την ανάγκη ανοίγματος του αρχικού αρχείου παρουσίασης.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης, "sample.pptx", με μια διαφάνεια που περιέχει σχόλια:

![Η διαφάνεια με σχόλια](slide_with_comments.png)

Ο παρακάτω κώδικας C# μετατρέπει τη διαφάνεια σε εικόνα JPG διατηρώντας τα σχόλια:

```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Ορίστε επιλογές για τα σχόλια της διαφάνειας.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // Μετατρέψτε την πρώτη διαφάνεια σε εικόνα.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

Το αποτέλεσμα:

![Η εικόνα JPG με σχόλια](image_with_comments.png)

## **Δείτε επίσης**

- [Μετατροπή PowerPoint σε GIF](/slides/el/net/convert-powerpoint-to-animated-gif/)
- [Μετατροπή PowerPoint σε PNG](/slides/el/net/convert-powerpoint-to-png/)
- [Μετατροπή PowerPoint σε TIFF](/slides/el/net/convert-powerpoint-to-tiff/)
- [Μετατροπή PowerPoint σε SVG](/slides/el/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Για να δείτε πώς το Aspose.Slides μετατρέπει το PowerPoint σε εικόνες JPG, δοκιμάστε αυτούς τους δωρεάν online μετατροπείς: PowerPoint [PPTX σε JPG](https://products.aspose.app/slides/el/conversion/pptx-to-jpg) και [PPT σε JPG](https://products.aspose.app/slides/el/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Δωρεάν online μετατροπέας PPTX σε JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Το Aspose προσφέρει μια [ΔΩΡΕΑΝ Collage web app](https://products.aspose.app/slides/el/collage). Χρησιμοποιώντας αυτή την online υπηρεσία, μπορείτε να συνδυάσετε [JPG σε JPG](https://products.aspose.app/slides/el/collage/jpg) ή PNG σε PNG εικόνες, να δημιουργήσετε [πλέγματα φωτογραφιών](https://products.aspose.app/slides/el/collage/photo-grid), κ.λπ. 

Χρησιμοποιώντας τις ίδιες αρχές που περιγράφονται σε αυτό το άρθρο, μπορείτε να μετατρέψετε εικόνες από μια μορφή σε άλλη. Για περισσότερες πληροφορίες, δείτε αυτές τις σελίδες: μετατροπή [εικόνας σε JPG](https://products.aspose.com/slides/el/net/conversion/image-to-jpg/); μετατροπή [JPG σε εικόνα](https://products.aspose.com/slides/el/net/conversion/jpg-to-image/); μετατροπή [JPG σε PNG](https://products.aspose.com/slides/el/net/conversion/jpg-to-png/), μετατροπή [PNG σε JPG](https://products.aspose.com/slides/el/net/conversion/png-to-jpg/); μετατροπή [PNG σε SVG](https://products.aspose.com/slides/el/net/conversion/png-to-svg/), μετατροπή [SVG σε PNG](https://products.aspose.com/slides/el/net/conversion/svg-to-png/).

{{% /alert %}}

## **Συχνές ερωτήσεις**

**Υποστηρίζει αυτή η μέθοδος τη μαζική μετατροπή;**

Ναι, το Aspose.Slides επιτρέπει τη μαζική μετατροπή πολλαπλών διαφανειών σε JPG σε μία ενέργεια.

**Υποστηρίζει η μετατροπή SmartArt, γραφήματα και άλλα σύνθετα αντικείμενα;**

Ναι, το Aspose.Slides αποδίδει όλο το περιεχόμενο, συμπεριλαμβανομένων των SmartArt, γραφημάτων, πινάκων, σχημάτων κ.ά. Ωστόσο, η ακρίβεια απόδοσης μπορεί να διαφέρει ελαφρώς σε σύγκριση με το PowerPoint, ειδικά όταν χρησιμοποιούνται προσαρμοσμένες ή ελλιπείς γραμματοσειρές.

**Υπάρχουν περιορισμοί στον αριθμό των διαφανειών που μπορούν να επεξεργαστούν;**

Το ίδιο το Aspose.Slides δεν επιβάλλει αυστηρούς περιορισμούς στον αριθμό των διαφανειών που μπορείτε να επεξεργαστείτε. Ωστόσο, μπορεί να αντιμετωπίσετε σφάλμα έλλειψης μνήμης όταν εργάζεστε με μεγάλες παρουσιάσεις ή εικόνες υψηλής ανάλυσης.
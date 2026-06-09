---
title: Μετατροπή PPT και PPTX σε JPG σε C++
linktitle: PowerPoint σε JPG
type: docs
weight: 60
url: /el/cpp/convert-powerpoint-to-jpg/
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
- C++
- Aspose.Slides
description: "Μετατρέψτε τις διαφάνειες PowerPoint (PPT, PPTX) σε εικόνες JPG υψηλής ποιότητας σε C++ με το Aspose.Slides χρησιμοποιώντας γρήγορα, αξιόπιστα παραδείγματα κώδικα."
---
## **Εισαγωγή**

Η μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε εικόνες JPG βοηθά στην κοινή χρήση διαφανειών, τη βελτιστοποίηση της απόδοσης και την ενσωμάτωση περιεχομένου σε ιστότοπους ή εφαρμογές. Το Aspose.Slides for C++ σας επιτρέπει να μετατρέπετε αρχεία PPTX, PPT και ODP σε εικόνες JPEG υψηλής ποιότητας. Αυτός ο οδηγός εξηγεί διαφορετικές μεθόδους μετατροπής.

Με αυτές τις δυνατότητες, είναι εύκολο να υλοποιήσετε το δικό σας πρόγραμμα προβολής παρουσιάσεων και να δημιουργήσετε μια μικρογραφία για κάθε διαφάνεια. Αυτό μπορεί να είναι χρήσιμο εάν θέλετε να προστατεύσετε τις διαφάνειες από αντιγραφή ή να παρουσιάσετε τη διαφάνεια σε λειτουργία μόνο‑ανάγνωσης. Το Aspose.Slides σας επιτρέπει να μετατρέψετε ολόκληρη την παρουσίαση ή μια συγκεκριμένη διαφάνεια σε μορφές εικόνας.

## **Μετατροπή Διαφανειών Παρουσίασης σε Εικόνες JPG**

Ακολουθούν τα βήματα για να μετατρέψετε ένα αρχείο PPT, PPTX ή ODP σε JPG:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Αποκτήστε το αντικείμενο διαφάνειας του τύπου [ISlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/) από τη συλλογή διαφανειών της παρουσίασης.
3. Δημιουργήστε μια εικόνα της διαφάνειας χρησιμοποιώντας τη μέθοδο [ISlide.GetImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/getimage/).
4. Καλέστε τη μέθοδο [IImage.Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/save/) στο αντικείμενο εικόνας. Περάστε το όνομα αρχείου εξόδου και τη μορφή εικόνας ως ορίσματα.

{{% alert color="primary" %}} 

**Σημείωση:** Η μετατροπή PPT, PPTX ή ODP σε JPG διαφέρει από τη μετατροπή σε άλλες μορφές στο API του Aspose.Slides for C++. Για άλλες μορφές, συνήθως χρησιμοποιείτε τη μέθοδο [IPresentation.Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/save/). Ωστόσο, για τη μετατροπή σε JPG, πρέπει να χρησιμοποιήσετε τη μέθοδο [IImage.Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/save/).

{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Δημιουργήστε μια εικόνα διαφάνειας με την καθορισμένη κλίμακα.
    auto image = slide->GetImage(scaleX, scaleY);

    // Αποθηκεύστε την εικόνα στο δίσκο σε μορφή JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Μετατροπή Διαφανειών σε JPG με Προσαρμοσμένες Διαστάσεις**

Για να αλλάξετε τις διαστάσεις των παραγόμενων εικόνων JPG, μπορείτε να ορίσετε το μέγεθος της εικόνας περνώντας το στη μέθοδο [ISlide.GetImage(Size)](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Αυτό σας επιτρέπει να δημιουργείτε εικόνες με συγκεκριμένες τιμές πλάτους και ύψους, διασφαλίζοντας ότι το αποτέλεσμα πληροί τις απαιτήσεις σας για ανάλυση και λόγο διαστάσεων. Αυτή η ευελιξία είναι ιδιαίτερα χρήσιμη κατά τη δημιουργία εικόνων για διαδικτυακές εφαρμογές, εκθέσεις ή τεκμηρίωση, όπου απαιτούνται ακριβείς διαστάσεις εικόνας.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Δημιουργήστε μια εικόνα διαφάνειας με το καθορισμένο μέγεθος.
    auto image = slide->GetImage(imageSize);

    // Αποθηκεύστε την εικόνα στο δίσκο σε μορφή JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Απόδοση Σχολίων Κατά την Αποθήκευση Διαφανειών ως Εικόνες**

Το Aspose.Slides for C++ παρέχει μια δυνατότητα που σας επιτρέπει να αποδίδετε σχόλια στις διαφάνειες μιας παρουσίασης όταν τις μετατρέπετε σε εικόνες JPG. Αυτή η λειτουργία είναι ιδιαίτερα χρήσιμη για τη διατήρηση σημειώσεων, σχολίων ή συζητήσεων που προστέθηκαν από συνεργάτες σε παρουσιάσεις PowerPoint. Ενεργοποιώντας αυτήν την επιλογή, διασφαλίζετε ότι τα σχόλια είναι ορατά στις παραγόμενες εικόνες, καθιστώντας ευκολότερη την επισκόπηση και την κοινοποίηση των σχολίων χωρίς να χρειάζεται να ανοίξετε το αρχικό αρχείο παρουσίασης.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης, "sample.pptx", με μια διαφάνεια που περιέχει σχόλια:

![Η διαφάνεια με σχόλια](slide_with_comments.png)

Ο παρακάτω κώδικας C++ μετατρέπει τη διαφάνεια σε εικόνα JPG διατηρώντας τα σχόλια:

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Ορίστε τις επιλογές για τα σχόλια της διαφάνειας.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Μετατρέψτε την πρώτη διαφάνεια σε εικόνα.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Το αποτέλεσμα:

![Η εικόνα JPG με σχόλια](image_with_comments.png)

## **Δείτε επίσης**

- [Μετατροπή PowerPoint σε GIF](/slides/el/cpp/convert-powerpoint-to-animated-gif/)
- [Μετατροπή PowerPoint σε PNG](/slides/el/cpp/convert-powerpoint-to-png/)
- [Μετατροπή PowerPoint σε TIFF](/slides/el/cpp/convert-powerpoint-to-tiff/)
- [Μετατροπή PowerPoint σε SVG](/slides/el/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Για να δείτε πώς το Aspose.Slides μετατρέπει το PowerPoint σε εικόνες JPG, δοκιμάστε αυτούς τους δωρεάν διαδικτυακούς μετατροπείς: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/el/conversion/pptx-to-jpg) και [PPT to JPG](https://products.aspose.app/slides/el/conversion/ppt-to-jpg). 

{{% /alert %}}

![Δωρεάν Διαδικτυακός Μετατροπέας PPTX σε JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Το Aspose παρέχει μια [ΔΩΡΕΑΝ εφαρμογή Collage web](https://products.aspose.app/slides/el/collage). Χρησιμοποιώντας αυτήν την online υπηρεσία, μπορείτε να συγχωνεύσετε [JPG σε JPG](https://products.aspose.app/slides/el/collage/jpg) ή PNG σε PNG εικόνες, να δημιουργήσετε [πλέγματα φωτογραφιών](https://products.aspose.app/slides/el/collage/photo-grid), κ.ά.

Με τις ίδιες αρχές που περιγράφονται σε αυτό το άρθρο, μπορείτε να μετατρέπετε εικόνες από μια μορφή σε άλλη. Για περισσότερες πληροφορίες, δείτε αυτές τις σελίδες: μετατρέψτε [image to JPG](https://products.aspose.com/slides/el/cpp/conversion/image-to-jpg/); μετατρέψτε [JPG to image](https://products.aspose.com/slides/el/cpp/conversion/jpg-to-image/); μετατρέψτε [JPG to PNG](https://products.aspose.com/slides/el/cpp/conversion/jpg-to-png/), μετατρέψτε [PNG to JPG](https://products.aspose.com/slides/el/cpp/conversion/png-to-jpg/); μετατρέψτε [PNG to SVG](https://products.aspose.com/slides/el/cpp/conversion/png-to-svg/), μετατρέψτε [SVG to PNG](https://products.aspose.com/slides/el/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υποστηρίζει αυτή η μέθοδος τη μαζική μετατροπή;**

Ναι, το Aspose.Slides επιτρέπει τη μαζική μετατροπή πολλαπλών διαφανειών σε JPG σε μία ενέργεια.

**Υποστηρίζει η μετατροπή SmartArt, γραφήματα και άλλα σύνθετα αντικείμενα;**

Ναι, το Aspose.Slides αποδίδει όλο το περιεχόμενο, συμπεριλαμβανομένων SmartArt, γραφημάτων, πινάκων, σχημάτων κλπ. Ωστόσο, η ακρίβεια απόδοσης μπορεί να διαφέρει ελαφρώς σε σύγκριση με το PowerPoint, ειδικά όταν χρησιμοποιούνται προσαρμοσμένες ή ελλιπείς γραμματοσειρές.

**Υπάρχουν περιορισμοί στον αριθμό των διαφανειών που μπορούν να επεξεργαστούν;**

Το ίδιο το Aspose.Slides δεν επιβάλλει αυστηρούς περιορισμούς στον αριθμό των διαφανειών που μπορείτε να επεξεργαστείτε. Ωστόσο, μπορεί να αντιμετωπίσετε σφάλμα έλλειψης μνήμης όταν εργάζεστε με μεγάλες παρουσιάσεις ή εικόνες υψηλής ανάλυσης.
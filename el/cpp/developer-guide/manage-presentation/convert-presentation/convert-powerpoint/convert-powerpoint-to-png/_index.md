---
title: Μετατροπή Διαφανειών PowerPoint σε PNG σε C++
linktitle: PowerPoint σε PNG
type: docs
weight: 30
url: /el/cpp/convert-powerpoint-to-png/
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
- C++
- Aspose.Slides
description: "Μετατρέψτε παρουσιάσεις PowerPoint σε εικόνες PNG υψηλής ποιότητας γρήγορα με το Aspose.Slides για C++, εξασφαλίζοντας ακριβή, αυτοματοποιημένα αποτελέσματα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε εικόνες PNG χρησιμοποιώντας το Aspose.Slides. Επιδεικνύει πώς να φορτώνετε αρχεία παρουσίασης σε μορφές όπως PPT, PPTX και ODP, να αποδίδετε τις διαφάνειες ως εικόνες και να αποθηκεύετε τα αποτελέσματα σε μορφή PNG.

Το άρθρο επίσης δείχνει πώς να προσαρμόσετε τις παραγόμενες εικόνες PNG ορίζοντας τιμές κλίμακας ή καθορίζοντας το επιθυμητό πλάτος και το ύψος.

## **Μετατροπή PowerPoint σε PNG**

Ακολουθήστε τα παρακάτω βήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
2. Αποκτήστε το αντικείμενο διαφάνειας από τη συλλογή [Presentation::get_Slides()](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) υπό την διεπαφή [ISlide](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.i_slide).
3. Χρησιμοποιήστε τη μέθοδο [ISlide::GetImage()](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/getimage) για να λάβετε τη μικρογραφία για κάθε διαφάνεια.
4. Χρησιμοποιήστε τη μέθοδο [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) για να αποθηκεύσετε τη μικρογραφία της διαφάνειας σε μορφή PNG.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσία PowerPoint σε PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένες Διαστάσεις**

Αν θέλετε να λάβετε αρχεία PNG με συγκεκριμένη κλίμακα, μπορείτε να ορίσετε τις τιμές για `desiredX` και `desiredY`, οι οποίες καθορίζουν τις διαστάσεις της προκύπτουσας μικρογραφίας.

Αυτός ο κώδικας σε C++ επιδεικνύει τη περιγραφόμενη λειτουργία:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **Μετατροπή PowerPoint σε PNG με Προσαρμοσμένο Μέγεθος**

Αν θέλετε να λάβετε αρχεία PNG με συγκεκριμένο μέγεθος, μπορείτε να περάσετε τις προτιμώμενες παραμέτρους `width` και `height` για το `ImageSize`.

Αυτός ο κώδικας δείχνει πώς να μετατρέψετε ένα PowerPoint σε PNG καθορίζοντας το μέγεθος των εικόνων:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **Συχνές ερωτήσεις**

**Πώς μπορώ να εξάγω μόνο ένα συγκεκριμένο σχήμα (π.χ. γράφημα ή εικόνα) αντί για ολόκληρη τη διαφάνεια;**

Το Aspose.Slides υποστηρίζει τη [δημιουργία μικρογραφιών για μεμονωμένα σχήματα](/slides/el/cpp/create-shape-thumbnails/); μπορείτε να αποδώσετε ένα σχήμα σε εικόνα PNG.

**Υπάρχει υποστήριξη για παράλληλη μετατροπή σε διακομιστή;**

Ναι, αλλά [μην μοιράζεστε](/slides/el/cpp/multithreading/) μια ενιαία παρουσία παρουσίασης μεταξύ νημάτων. Χρησιμοποιήστε ξεχωριστή παρουσία ανά νήμα ή διαδικασία.

**Ποιες είναι οι περιορισμοί της δοκιμαστικής έκδοσης κατά την εξαγωγή σε PNG;**

Η λειτουργία αξιολόγησης προσθέτει υδατογράφημα στις εικόνες εξόδου και επιβάλλει [άλλους περιορισμούς](/slides/el/cpp/licensing/) μέχρι να εφαρμοστεί άδεια.
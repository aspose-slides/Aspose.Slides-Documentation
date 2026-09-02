---
title: Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις Χρησιμοποιώντας C++
linktitle: Διαχείριση Εικόνων
type: docs
weight: 10
url: /el/cpp/image/
keywords:
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- αντικατάσταση εικόνας
- συλλογή εικόνων
- πλαίσιο εικόνας
- συνδεδεμένη εικόνα
- φόντο
- προσθήκη PNG
- προσθήκη JPG
- προσθήκη SVG
- SVG σε σχήματα
- εξωτερικοί πόροι SVG
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, επαναχρησιμοποιείτε, συνδέετε, αντικαθιστάτε και διαχειρίζεστε ραστερικές και SVG εικόνες σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για C++."
---
## **Εισαγωγή**

Το Aspose.Slides για C++ παρέχει πολλούς τρόπους εργασίας με εικόνες, και καθένας εξυπηρετεί διαφορετικό σκοπό. Μπορείτε να αποθηκεύσετε μια εικόνα σε μια παρουσίαση, να την εμφανίσετε σε ένα πλαίσιο εικόνας, να τη χρησιμοποιήσετε ως φόντο διαφάνειας, να συνδέσετε σε εξωτερική εικόνα, να αντικαταστήσετε έναν κοινόχρηστο πόρο εικόνας ή να μετατρέψετε περιεχόμενο SVG σε επεξεργάσιμα σχήματα.

Αυτό το άρθρο εστιάζει στους πόρους εικόνας και στον τρόπο χρήσης τους σε μια παρουσίαση. Για περικοπή, διαφάνεια, εφέ, τέντωμα και άλλες μορφοποιήσεις που εφαρμόζονται σε μεμονωμένο πλαίσιο εικόνας, δείτε [Πλαίσιο Εικόνας](/slides/el/cpp/picture-frame/).

## **Κατανόηση του Μοντέλου Εικόνας**

Οι παρακάτω έννοιες του API σχετίζονται στενά αλλά δεν είναι εναλλάξιμες:

- Η [συλλογή εικόνων παρουσίασης](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimagecollection/) αποθηκεύει τους πόρους εικόνας που χρησιμοποιούνται από την παρουσίαση. Χρησιμοποιήστε [IImageCollection::AddImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimagecollection/addimage/) για να προσθέσετε δεδομένα εικόνας και να λάβετε έναν πόρο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/).
- Ένα [πλαίσιο εικόνας](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) είναι ένα σχήμα που εμφανίζει μια εικόνα σε διαφάνεια, διάταξη ή κύριο πρότυπο. Χρησιμοποιήστε [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addpictureframe/) για να τοποθετήσετε έναν πόρο εικόνας σε μια διαφάνεια.
- Ένα φόντο διαφάνειας χρησιμοποιεί εικόνα ως μέρος του γέμισης της διαφάνειας αντί για σχήμα. Συνεπώς δεν συμπεριφέρεται όπως ένα πλαίσιο εικόνας.
- Το [IPPImage::ReplaceImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/replaceimage/) αντικαθιστά έναν πόρο εικόνας. Εάν πολλά στοιχεία της παρουσίασης χρησιμοποιούν αυτόν τον πόρο, όλα θα χρησιμοποιήσουν την αντικατάσταση.
- Η μετατροπή SVG σε σχήματα δημιουργεί επεξεργάσιμα σχήματα διαφάνειας. Μετά τη μετατροπή, το περιεχόμενο δεν διαχειρίζεται πλέον ως ένας ενιαίος πόρος εικόνας.

Έτσι, η τυπική ροή εργασίας είναι: προσθέστε δεδομένα εικόνας στη συλλογή εικόνων, λάβετε ένα [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/), και στη συνέχεια χρησιμοποιήστε αυτόν τον πόρο σε ένα ή περισσότερα πλαίσια εικόνας ή γέμισμα.

## **Προσθήκη Ενσωματωμένης Εικόνας**

Για να εισάγετε μια τοπική εικόνα, διαβάστε το αρχείο, προσθέστε τα δεδομένα της στη συλλογή εικόνων και δημιουργήστε ένα πλαίσιο εικόνας που χρησιμοποιεί τον επιστρεφόμενο πόρο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/).

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η εικόνα που προστίθεται με αυτόν τον τρόπο ενσωματώνεται στην παρουσίαση, έτσι το παραγόμενο αρχείο δεν εξαρτάται από τη διαθεσιμότητα του αρχικού αρχείου εικόνας.

### **Προσθήκη Εικόνας από τον Ιστό**

Όταν μια εικόνα είναι διαθέσιμη μέσω HTTP ή HTTPS, κατεβάστε τα byte της, προσθέστε τα στη συλλογή εικόνων της παρουσίασης και χρησιμοποιήστε τον επιστρεφόμενο πόρο εικόνας με τον ίδιο τρόπο όπως για μια τοπική εικόνα.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Επικυρώστε απομακρυσμένα URL, μεγέθη αποκρίσεων και τύπους περιεχομένου όταν η πηγή δεν είναι αξιόπιστη. Σε εφαρμογές που ήδη χρησιμοποιούν άλλο πελάτη HTTP, μπορείτε να κατεβάσετε την εικόνα με αυτόν τον πελάτη και να περάσετε τα byte ή τη ροή στο [IImageCollection::AddImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimagecollection/addimage/).

## **Επαναχρησιμοποίηση Εικόνων σε Πολλές Διαφάνειες**

Αν η ίδια εικόνα χρειάζεται περισσότερες από μία φορές, προσθέστε την μία φορά στην παρουσίαση και επαναχρησιμοποιήστε το επιστρεφόμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) κατά τη δημιουργία επιπλέον πλαισίων εικόνας. Αυτό αποτρέπει την επαναλαμβανόμενη φόρτωση των ίδιων δεδομένων πηγής και κάνει τη σχέση μεταξύ του κοινόχρηστου πόρου εικόνας και των χρήσεών του σαφή.

Για γραφικά που πρέπει να εμφανίζονται αυτόματα σε πολλές διαφάνειες, όπως το λογότυπο μιας εταιρείας, σκεφτείτε να τοποθετήσετε το πλαίσιο εικόνας σε έναν [κύριο πρότυπο διαφάνειας](/slides/el/cpp/slide-master/) ή σε διάταξη αντί να προσθέτετε ένα ισοδύναμο σχήμα σε κάθε διαφάνεια.

## **Χρήση Εικόνας ως Φόντο Διαφάνειας**

Μια εικόνα φόντου ανατίθεται στο γέμισμα της διαφάνειας· δεν προστίθεται ως σχήμα πλαισίου εικόνας. Αυτό είναι χρήσιμο όταν η εικόνα πρέπει να καλύπτει το φόντο της διαφάνειας και δεν πρέπει να χειρίζεται ως κανονικό αντικείμενο διαφάνειας.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Για πρόσθετες επιλογές φόντου, συμπεριλαμβανομένων φόντων κύριων προτύπων και διατάξεων, δείτε [Φόντο Παρουσίασης](/slides/el/cpp/presentation-background/).

## **Ενσωματωμένες και Συνδεδεμένες Εικόνες**

Οι ενσωματωμένες και οι συνδεδεμένες εικόνες έχουν διαφορετικά πλεονεκτήματα σε φορητότητα και μέγεθος αρχείου:

- **Ενσωματωμένη εικόνα:** τα δεδομένα εικόνας αποθηκεύονται μέσα στην παρουσίαση. Η παρουσίαση είναι αυτόνομη, αλλά το μέγεθος του αρχείου περιλαμβάνει τα δεδομένα εικόνας.
- **Συνδεδεμένη εικόνα:** η παρουσίαση αποθηκεύει μια διαδρομή ή URL σε εξωτερική εικόνα. Αυτό μπορεί να μειώσει το μέγεθος της παρουσίασης, αλλά ο εξωτερικός πόρος πρέπει να παραμένει προσβάσιμος όταν ανοίγει ή αποδίδεται η παρουσίαση.

Μια συνδεδεμένη εικόνα μπορεί να δημιουργηθεί ορίζοντας τη διαδρομή ή το URL μέσω του [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidespicture/set_linkpathlong/) αντί να ενσωματώνετε τα δεδομένα εικόνας.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Χρησιμοποιήστε συνδεδεμένες εικόνες μόνο όταν το περιβάλλον διανομής μπορεί αξιόπιστα να προσπελάσει τον εξωτερικό πόρο. Για παρουσιάσεις που πρέπει να λειτουργούν εκτός σύνδεσης ή να μεταφέρονται μεταξύ συστημάτων, οι ενσωματωμένες εικόνες είναι συνήθως πιο ασφαλείς.

## **Εργασία με Εικόνες SVG**

Το SVG είναι μορφή διανυσματική, επομένως μπορεί να είναι χρήσιμη για εικονίδια, διαγράμματα και άλλα γραφικά που πρέπει να κλιμακώνονται χωρίς να χάνουν λεπτομέρεια όπως οι ραστερικές εικόνες. Το Aspose.Slides υποστηρίζει SVG τόσο ως πόρο εικόνας όσο και ως πηγή για επεξεργάσιμα σχήματα διαφάνειας.

### **Προσθήκη SVG ως Εικόνας**

Δημιουργήστε ένα [SvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/svgimage/), προσθέστε το στη συλλογή εικόνων και τοποθετήστε τον προκύπτοντα πόρο εικόνας σε ένα πλαίσιο εικόνας.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Αρχεία SVG με Εξωτερικούς Πόρους**

Ένα SVG μπορεί να αναφέρει εξωτερικές εικόνες, φύλλα στυλ ή γραμματοσειρές. Για αυτές τις περιπτώσεις, το [SvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/svgimage/) παρέχει κατασκευαστές που δέχονται έναν [IExternalResourceResolver](https://reference.aspose.com/slides/el/cpp/aspose.slides.import/iexternalresourceresolver/) και ένα βασικό URI. Ο resolver μπορεί να αντιστοιχίσει ένα σχετικό URI σε επιτρεπόμενο απόλυτο URI και να επιστρέψει μια ροή για τον ζητούμενο πόρο.

Ο resolver καθιστά διαθέσιμους τους εξωτερικούς πόρους ενώ το Aspose.Slides επεξεργάζεται το SVG, αλλά δεν ξαναγράφει το SVG σε αυτόνομο έγγραφο. Εάν το SVG πρέπει να παραμείνει φορητό, ενσωματώστε τους απαιτούμενους πόρους στο ίδιο το SVG, π.χ. χρησιμοποιώντας URIs `data:` για συνδεδεμένες εικόνες.

Όταν τα αρχεία SVG προέρχονται από μη αξιόπιστες πηγές, περιορίστε τα σχήματα, τις θέσεις αρχείων και τους κεντρικούς υπολογιστές που ο resolver μπορεί να προσπελάσει. Οι δικτυακοί resolvers θα πρέπει επίσης να εφαρμόζουν χρονικά όρια, όρια μεγέθους απόκρισης και επικύρωση περιεχομένου.

### **Μετατροπή SVG σε Επεξεργάσιμα Σχήματα**

Το Aspose.Slides μπορεί να μετατρέψει ένα SVG σε ομάδα επεξεργάσιμων σχημάτων διαφάνειας, παρόμοια με την αντίστοιχη εντολή του PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Χρησιμοποιήστε την υπερφόρτωση του [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addgroupshape/) που δέχεται έναν [ISvgImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/isvgimage/) για να εκτελέσετε τη μετατροπή.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Χρησιμοποιήστε τη μετατροπή SVG‑σε‑σχήματα όταν τα μεμονωμένα διανυσματικά στοιχεία χρειάζεται να επεξεργαστούν ως σχήματα PowerPoint. Εάν το SVG χρειάζεται μόνο προβολή, η διατήρησή του ως εικόνα είναι πιο απλή και αποφεύγει τη δημιουργία πολλών ξεχωριστών σχημάτων.

## **Αντικατάσταση Υφιστάμενου Πόρου Εικόνας**

Χρησιμοποιήστε το [IPPImage::ReplaceImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/replaceimage/) όταν θέλετε να αντικαταστήσετε έναν υπάρχοντα πόρο εικόνας. Αυτό είναι ιδιαίτερα χρήσιμο για κοινόχρηστα γραφικά όπως λογότυπα.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Εάν πολλαπλά πλαίσια εικόνας, φόντα, πρότυπα ή διατάξεις χρησιμοποιούν τον ίδιο πόρο εικόνας, η αντικατάσταση του πόρου ενημερώνει όλες τις χρήσεις. Εάν πρέπει να αλλάξει μόνο ένα πλαίσιο εικόνας, εκχωρήστε μια διαφορετική εικόνα σε αυτό το πλαίσιο αντί να αντικαταστήσετε τον κοινόχρηστο πόρο.

Το [IPPImage::ReplaceImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/replaceimage/) παρέχει επίσης υπερφορτώσεις που δέχονται ένα [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) ή ένα άλλο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/).

## **Πρακτικές Οδηγίες Διαχείρισης Εικόνων**

### **Έλεγχος Μεγέθους Παρουσίασης**

Μεγάλες ραστερικές εικόνες μπορούν να κάνουν την παρουσίαση άσκοπα μεγάλη. Χρησιμοποιήστε εικόνες πηγής με διαστάσεις κατάλληλες για το σκοπό εμφάνισης, επαναχρησιμοποιήστε κοινόχρηστους πόρους εικόνας όπου είναι δυνατόν και αποφύγετε την ενσωμάτωση επαναλαμβανόμενων αντιγράφων του ίδιου γραφικού πλήρους ανάλυσης.

Για ραστερικές εικόνες που έχουν ήδη τοποθετηθεί σε πλαίσια εικόνας, το [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/compressimage/) μπορεί να μειώσει τα δεδομένα εικόνας σύμφωνα με την επιλεγμένη ανάλυση και τις ρυθμίσεις περικοπής. Αυτό αποτελεί επεξεργασία πλαισίου εικόνας και όχι διαχείριση συλλογής εικόνων, οπότε δείτε [Πλαίσιο Εικόνας](/slides/el/cpp/picture-frame/) για σχετικές λειτουργίες μορφοποίησης.

### **Επιλογή μεταξύ Ενσωματωμένου και Συνδεδεμένου Περιεχομένου**

Η ενσωμάτωση κάνει την παρουσίαση φορητή επειδή όλα τα απαιτούμενα δεδομένα εικόνας μετακινούνται με το αρχείο. Η σύνδεση μπορεί να μειώσει το μέγεθος του αρχείου, αλλά εισάγει εξωτερική εξάρτηση. Χρησιμοποιήστε συνδέσμους μόνο όταν αυτή η εξάρτηση είναι αποδεκτή και σταθερή.

### **Επαναχρησιμοποίηση Κοινής Επωνυμίας**

Για επαναλαμβανόμενα λογότυπα, υδατογραφήματα ή διακοσμητικά γραφικά, χρησιμοποιήστε έναν πόρο εικόνας και επαναχρησιμοποιήστε τον. Εάν το γραφικό ανήκει στο σχεδιασμό της παρουσίασης αντί για το περιεχόμενο των διαφανειών, τοποθετήστε το σε πρότυπο ή διάταξη ώστε να κληρονομείται από τις αντίστοιχες διαφάνειες.

### **Διατήρηση Φορητότητας Πόρων SVG**

Ένα αυτόνομα SVG είναι πιο εύκολο να μετακινηθεί και να αποδοθεί σταθερά από ένα SVG που εξαρτάται από εξωτερικά αρχεία ή δικτυακούς πόρους. Όταν είναι δυνατόν, ενσωματώστε τους απαιτούμενους πόρους πριν την εισαγωγή του SVG. Μετατρέψτε SVG σε σχήματα μόνο όταν τα μεμονωμένα διανυσματικά στοιχεία χρειάζεται να επεξεργαστούν.

### **Χρήση του Aspose.Slides Image API**

Για εργασίες εικόνας σε C++, χρησιμοποιήστε τα API Aspose.Slides [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) και [Images](https://reference.aspose.com/slides/el/cpp/aspose.slides/images/) όταν χρειάζεστε αντικείμενο εικόνας, και χρησιμοποιήστε το [IImageCollection::AddImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimagecollection/addimage/) όταν πρέπει να καταχωρίσετε δεδομένα εικόνας ως πόρο παρουσίασης. Οι υπερφορτώσεις της συλλογής υποστηρίζουν επίσης πίνακες byte και ροές, χρήσιμες όταν τα δεδομένα εικόνας προέρχονται από αρχεία, πελάτες δικτύου, βάσεις δεδομένων ή άλλες βιβλιοθήκες.

Η δημιουργία περιεχομένου EMF από λογιστικά φύλλα ή άλλο προϊόν είναι ξεχωριστή διαδικασία ενσωμάτωσης και εκτός του πεδίου αυτού του άρθρου. Εάν ένα υπάρχον αρχείο WMF ή EMF χρειάζεται μόνο να εισαχθεί σε μια παρουσίαση, περάστε τα δεδομένα του σε κατάλληλη υπερφόρτωση του [IImageCollection::AddImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimagecollection/addimage/) χωρίς να προσθέτετε εξάρτηση δεύτερου προϊόντος στη ροή εργασίας διαχείρισης εικόνων.

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ της συλλογής εικόνων και ενός πλαισίου εικόνας;**

Η συλλογή εικόνων αποθηκεύει επαναχρησιμοποιήσιμους πόρους εικόνας. Ένα πλαίσιο εικόνας είναι σχήμα διαφάνειας που εμφανίζει έναν από αυτούς τους πόρους και παρέχει μορφοποίηση ειδική για εικόνες όπως περικοπή και εφέ.

**Ποιος είναι ο καλύτερος τρόπος για να αντικαταστήσω το ίδιο λογότυπο παντού;**

Εάν το λογότυπο είναι ήδη κοινόχρηστος ως ένας πόρος εικόνας, αντικαταστήστε αυτόν τον πόρο με το [IPPImage::ReplaceImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/replaceimage/). Για ευρεία επωνυμία παρουσίασης, η τοποθέτηση του λογότυπου σε κύριο πρότυπο ή διάταξη μπορεί επίσης να μειώσει το διπλό περιεχόμενο διαφανειών.

**Γιατί μια συνδεδεμένη εικόνα εξαφανίζεται σε άλλο υπολογιστή;**

Μια συνδεδεμένη εικόνα εξαρτάται από το εξωτερικό αρχείο ή URL. Εάν δεν είναι εφικτή η πρόσβαση στον πόρο από τον άλλον υπολογιστή, η εικόνα μπορεί να μην είναι διαθέσιμη. Ενσωματώστε την εικόνα όταν η παρουσίαση πρέπει να είναι αυτόνομη.

**Μπορεί ένα εισαχθέν SVG να επεξεργαστεί ως σχήματα PowerPoint;**

Ναι. Μετατρέψτε το SVG με το [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addgroupshape/); η προκύπτουσα ομάδα περιέχει επεξεργάσιμα σχήματα διαφάνειας αντί για μία εικόνα SVG.

**Πώς μπορώ να διατηρήσω τις παρουσιάσεις με πολλές εικόνες μικρότερες;**

Επαναχρησιμοποιήστε κοινόχρηστους πόρους εικόνας, αποφύγετε υπερβολικά μεγάλες ραστερικές πηγές, συμπιέστε κατάλληλες ραστερικές εικόνες όταν είναι σκόπιμο, τοποθετήστε επαναλαμβανόμενη επωνυμία σε πρότυπα ή διατάξεις και χρησιμοποιήστε συνδεδεμένες εικόνες μόνο όταν η εξωτερική εξάρτηση είναι αποδεκτή.
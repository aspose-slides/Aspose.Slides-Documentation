---
title: "Βελτιώστε την επεξεργασία εικόνας με το σύγχρονο API"
linktitle: "Σύγχρονο API"
type: docs
weight: 280
url: /el/cpp/modern-api/
keywords:
- System.Drawing
- σύγχρονο API
- σχεδίαση
- μικρογραφία διαφάνειας
- διαφάνεια σε εικόνα
- μικρογραφία σχήματος
- σχήμα σε εικόνα
- μικρογραφία παρουσίασης
- παρουσίαση σε εικόνες
- προσθήκη εικόνας
- προσθήκη φωτογραφίας
- C++
- Aspose.Slides
description: "Εκσυγχρονίστε την επεξεργασία εικόνων διαφανειών αντικαθιστώντας τις παρωχημένες διεπαφές εικόνας με το C++ ΣΥΓΧΡΟΝΟ API για απρόσκοπτη αυτοματοποίηση PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Προς το παρόν, η βιβλιοθήκη Aspose.Slides για C++ έχει εξαρτήσεις στο δημόσιο API της από τις ακόλουθες κλάσεις του System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/el/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/el/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/el/cpp/system.drawing/bitmap/)

Από την έκδοση 24.4, αυτό το δημόσιο API θεωρείται παρωχημένο.

Για να απαλλαγούμε από τις εξαρτήσεις στο System::Drawing στο δημόσιο API, προσθέσαμε το λεγόμενο «Σύγχρονο API». Οι μέθοδοι με [System::Drawing::Image](https://reference.aspose.com/slides/el/cpp/system.drawing/image/) και [System::Drawing::Bitmap](https://reference.aspose.com/slides/el/cpp/system.drawing/bitmap/) θεωρούνται παρωχημένες και πρέπει να αντικατασταθούν με τις αντίστοιχες μεθόδους του Σύγχρονου API. Οι μέθοδοι με [System::Drawing::Graphics](https://reference.aspose.com/slides/el/cpp/system.drawing/graphics/) θεωρούνται παρωχημένες και δεν έχουν άμεση αντικατάσταση στο Σύγχρονο API.

Στις τρέχουσες εκδόσεις, θεωρήστε το δημόσιο API που εξαρτάται από τύπους System::Drawing ως κληρονομημένο/παρωχημένο. Χρησιμοποιήστε το Σύγχρονο API για νέο κώδικα και όταν μεταφέρετε υπάρχουσες ροές εργασίας επεξεργασίας εικόνας.

## **Σύγχρονο API**

Προστέθηκαν οι ακόλουθες κλάσεις και απαριθμήσεις (enums) στο δημόσιο API:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) - αντιπροσωπεύει την raster ή vector εικόνα.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/imageformat/) - αντιπροσωπεύει τη μορφή αρχείου της εικόνας.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/el/cpp/aspose.slides/images/) - μεθόδους για τη δημιουργία και τη χρήση της διεπαφής [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/).

Χρησιμοποιήστε το `GetImage` για να αποδώσετε μία ενιαία διαφάνεια ή σχήμα. Χρησιμοποιήστε το `GetImages` για να αποδώσετε πολλές διαφάνειες παρουσίασης. Χρησιμοποιήστε τις μεθόδους του [Images](https://reference.aspose.com/slides/el/cpp/aspose.slides/images/) για να φορτώσετε εικόνες, το `AddImage` με το [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) για να τις προσθέσετε σε μια παρουσίαση, και το `ReplaceImage` με το [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) για να ενημερώσετε μια υπάρχουσα εικόνα παρουσίασης.

Ένα τυπικό σενάριο χρήσης του νέου API μπορεί να φαίνεται ως εξής:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// δημιουργία μιας διανιμαζόμενης εμφάνισης IImage από το αρχείο στον δίσκο.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// δημιουργήστε μια εικόνα PowerPoint προσθέτοντας μια εμφάνιση IImage στις εικόνες της παρουσίασης.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// προσθέστε ένα σχήμα εικόνας στη διαφάνεια #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// λάβετε μια εμφάνιση IImage που αντιπροσωπεύει τη διαφάνεια #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// αποθηκεύστε την εικόνα στο δίσκο.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Αντικατάσταση Παλαιού Κώδικα με το Σύγχρονο API**

Για ευκολία της μετάβασης, η διεπαφή του νέου [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) επαναλαμβάνει τις ξεχωριστές υπογραφές των κλάσεων [System::Drawing::Image](https://reference.aspose.com/slides/el/cpp/system.drawing/image/) και [System::Drawing::Bitmap](https://reference.aspose.com/slides/el/cpp/system.drawing/bitmap/). Γενικά, αρκεί να αντικαταστήσετε την κλήση της παλιάς μεθόδου που χρησιμοποιεί το System::Drawing με τη νέα.

### **Λήψη Μικρογραφίας Διαφάνειας**

API κληρονομημένο/παρωχημένο:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Σύγχρονο API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Λήψη Μικρογραφίας Σχήματος**

API κληρονομημένο/παρωχημένο:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Σύγχρονο API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Λήψη Μικρογραφίας Παρουσίασης**

API κληρονομημένο/παρωχημένο:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

Σύγχρονο API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **Προσθήκη Εικόνας σε Παρουσίαση**

API κληρονομημένο/παρωχημένο:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

Σύγχρονο API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **Παρωχημένες Μέθοδοι/Ιδιότητες και η Αντικατάστασή τους στο Σύγχρονο API**

### **Κλάση Presentation**
|Υπογραφή Μεθόδου|Υπογραφή Μεθόδου Αντικατάστασης|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Κλάση Slide**
|Υπογραφή Μεθόδου|Υπογραφή Μεθόδου Αντικατάστασης|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **Κλάση Shape**
|Υπογραφή Μεθόδου|Υπογραφή Μεθόδου Αντικατάστασης|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **Κλάση ImageCollection**
|Υπογραφή Μεθόδου|Υπογραφή Μεθόδου Αντικατάστασης|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **Κλάση PPImage**
|Υπογραφή Μεθόδου|Υπογραφή Μεθόδου Αντικατάστασης|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **Κλάση PatternFormat**
|Υπογραφή Μεθόδου|Υπογραφή Μεθόδου Αντικατάστασης|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **Κλάση IPatternFormatEffectiveData**
|Υπογραφή Μεθόδου|Υπογραφή Μεθόδου Αντικατάστασης|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Υποστήριξη API για System::Drawing::Graphics**

Οι μέθοδοι με [System::Drawing::Graphics](https://reference.aspose.com/slides/el/cpp/system.drawing/graphics/) θεωρούνται παρωχημένες και δεν έχουν άμεση αντικατάσταση στο Σύγχρονο API.

Χρησιμοποιήστε τις μεθόδους απόδοσης εικόνας του Σύγχρονου API αντί του API που αποδίδει σε [System::Drawing::Graphics](https://reference.aspose.com/slides/el/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/el/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/el/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/el/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **Συχνές Ερωτήσεις**

**Γιατί αφαιρέθηκε το [System::Drawing::Graphics](https://reference.aspose.com/slides/el/cpp/system.drawing/graphics/);**

Η υποστήριξη για το [System::Drawing::Graphics](https://reference.aspose.com/slides/el/cpp/system.drawing/graphics/) είναι παρωχημένη στο δημόσιο API για να ενοποιήσει την εργασία με απόδοση και εικόνες, να εξαλείψει τις εξαρτήσεις από ειδικές πλατφόρμες και να μεταβεί σε μια πλατφόρμα‑ανεξάρτητη προσέγγιση με το [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/). Χρησιμοποιήστε το `GetImage` ή το `GetImages` αντί για απόδοση σε [System::Drawing::Graphics](https://reference.aspose.com/slides/el/cpp/system.drawing/graphics/).

**Ποιο είναι το πρακτικό όφελος του [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) σε σύγκριση με το [System::Drawing::Image](https://reference.aspose.com/slides/el/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/el/cpp/system.drawing/bitmap/);**

Το [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) ενοποιεί τη δουλειά με raster και vector εικόνες, απλοποιεί την αποθήκευση σε διάφορες μορφές μέσω του [ImageFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/imageformat/), μειώνει την εξάρτηση από το `System::Drawing` και κάνει τον κώδικα πιο φορητό μεταξύ διαφορετικών περιβαλλόντων.

**Θα επηρεάσει το Σύγχρονο API την απόδοση της δημιουργίας μικρογραφιών;**

Η μετάβαση από `GetThumbnail` σε `GetImage` δεν επιδεινώνει τις περιπτώσεις: οι νέες μέθοδοι παρέχουν τις ίδιες δυνατότητες παραγωγής εικόνων με επιλογές και μεγέθη, διατηρώντας παράλληλα την υποστήριξη για επιλογές απόδοσης. Το συγκεκριμένο κέρδος ή η απώλεια εξαρτάται από το σενάριο, αλλά λειτουργικά οι αντικαταστάσεις είναι ισοδύναμες.
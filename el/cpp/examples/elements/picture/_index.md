---
title: Εικόνα
type: docs
weight: 50
url: /el/cpp/examples/elements/picture/
keywords:
- παράδειγμα κώδικα
- εικόνα
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εργαστείτε με εικόνες στο Aspose.Slides for C++: εισαγάγετε, περικοπή, συμπίεση, αλλαγή χρώματος και εξαγωγή εικόνων με παραδείγματα C++ για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εισάγετε και να αποκτήσετε πρόσβαση σε εικόνες από εικόνες στη μνήμη χρησιμοποιώντας **Aspose.Slides for C++**. Τα παραδείγματα παρακάτω δημιουργούν μια εικόνα στη μνήμη, την τοποθετούν σε μια διαφάνεια και, στη συνέχεια, την επανακτούν.

## **Add a Picture**
Αυτός ο κώδικας δημιουργεί ένα μικρό bitmap, το μετατρέπει σε ροή και το εισάγει ως πλαίσιο εικόνας στην πρώτη διαφάνεια.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Δημιουργήστε μια απλή εικόνα στη μνήμη.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Μετατρέψτε το bitmap σε πίνακα bytes.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Προσθέστε την εικόνα στην παρουσίαση.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Εισάγετε ένα πλαίσιο εικόνας που εμφανίζει την εικόνα στην πρώτη διαφάνεια.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Access a Picture**
Αυτό το παράδειγμα διασφαλίζει ότι μια διαφάνεια περιέχει πλαίσιο εικόνας και στη συνέχεια προσπελαύνει το πρώτο που εντοπίζει.

```cpp
static void AccessPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto bitmap = MakeObject<Bitmap>(40, 40, PixelFormat::Format32bppArgb);
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0, 0, 40, 40, image);

    auto pictureFrame = SharedPtr<IPictureFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            pictureFrame = ExplicitCast<IPictureFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```
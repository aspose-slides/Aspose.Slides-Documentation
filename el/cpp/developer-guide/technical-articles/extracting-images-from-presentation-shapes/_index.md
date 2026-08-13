---
title: "Εξαγωγή εικόνων από σχήματα παρουσίασης σε C++"
linktitle: "Εικόνα από σχήμα"
type: docs
weight: 90
url: /el/cpp/extracting-images-from-presentation-shapes/
keywords:
- "εξαγωγή εικόνας"
- "ανάκτηση εικόνας"
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εξαγωγή εικόνων από σχήματα σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για C++ – γρήγορη, φιλική προς τον κώδικα λύση."
---
## **Επισκόπηση**

Οι εικόνες σε μια παρουσίαση μπορούν να εμφανιστούν σε διάφορους τύπους σχήματος: ως κανονικά πλαίσια εικόνας, ως γεμίσεις εικόνας που εφαρμόζονται σε σχήματα, ως προεπισκοπήσεις εικόνων αντικειμένων OLE, ως μικρογραφίες πλαισίων βίντεο ή ήχου, ως εικόνες μεγέθυνσης ή ως εικόνες ενσωματωμένες μέσα σε σχήματα πίνακα, γραφήματος και SmartArt. Το Aspose.Slides αποθηκεύει αυτές τις εικόνες στη συλλογή εικόνων της παρουσίασης, η οποία εκτίθεται μέσω [IImageCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimagecollection/) και [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) αντικειμένων.

Αν χρειάζεστε μόνο την εξαγωγή κάθε ενσωματωμένου πόρου εικόνας σε μια παρουσίαση, διατρέξτε το `presentation->get_Images()`. Αυτό το άρθρο εστιάζει σε διαφορετική εργασία: την περιήγηση στα σχήματα για να εντοπίσετε πού χρησιμοποιούνται οι εικόνες στις διαφάνειες, ώστε τα αποθηκευμένα αρχεία να διατηρούν χρήσιμο πλαίσιο όπως ο αριθμός διαφάνειας, η θέση του σχήματος και ο τύπος προέλευσης (πλαίσιο εικόνας, εικόνα γεμίσεως, προεπισκόπηση μέσου, προεπισκόπηση OLE ή εικόνα μεγέθυνσης).

{{% alert title="Tip" color="info" %}}

Χρησιμοποιήστε [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_BinaryData()` για να διατηρήσετε τα αρχικά κωδικοποιημένα δεδομένα εικόνας και τον τύπο αρχείου. Χρησιμοποιήστε [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_Image()` με [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/)::`Save` όταν θέλετε να κανονικοποιήσετε την έξοδο σε συγκεκριμένη μορφή όπως PNG.

{{% /alert %}}

## **Κοινές Βοηθητικές Μεθόδους**

Οι παρακάτω βοηθητικές μέθοδοι κρατούν τα παραδείγματα σύντομα. Η `SaveOriginalImage` γράφει τα αρχικά ενσωματωμένα byte, επιλέγει ασφαλή επέκταση από τον τύπο MIME και παραλείπει διπλότυπα δυαδικά δεδομένα εικόνας βάσει κατακερματισμού SHA‑256.

```cpp
#include <vector>
#include <system/array.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <security/cryptography/hash_algorithm.h>
#include <system/text/string_builder.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGroupShape.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlidesPicture.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Security::Cryptography;
using namespace System::Text;

struct ShapeInfo
{
    SharedPtr<IShape> Shape;
    String NamePart;
};

String GetSha256Hash(ArrayPtr<uint8_t> data);
String GetExtensionFromContentType(String contentType);
String MakeSafeFileNamePart(String value);

bool SaveOriginalImage(
    SharedPtr<IPPImage> image,
    String outputDirectory,
    String fileNameBase,
    SharedPtr<HashSet<String>> savedImageHashes)
{
    auto imageData = image->get_BinaryData();
    String imageHash = GetSha256Hash(imageData);
    if (savedImageHashes->Contains(imageHash))
    {
        return false;
    }

    savedImageHashes->Add(imageHash);

    String extension = GetExtensionFromContentType(image->get_ContentType());
    String fileName = String::Format(u"{0}.{1}", fileNameBase, extension);
    String outputPath = Path::Combine(outputDirectory, fileName);
    File::WriteAllBytes(outputPath, imageData);
    return true;
}

void SaveImageAsPng(SharedPtr<IPPImage> image, String outputDirectory, String fileNameBase)
{
    String fileName = String::Format(u"{0}.png", fileNameBase);
    String outputPath = Path::Combine(outputDirectory, fileName);

    auto outputImage = image->get_Image();
    outputImage->Save(outputPath, ImageFormat::Png);
    outputImage->Dispose();
}

SharedPtr<IPPImage> GetPictureFillImage(SharedPtr<IFillFormat> fillFormat)
{
    if (fillFormat == nullptr || fillFormat->get_FillType() != FillType::Picture)
    {
        return nullptr;
    }

    return fillFormat->get_PictureFillFormat()->get_Picture()->get_Image();
}

void EnumerateShapes(
    SharedPtr<IShapeCollection> shapes,
    String prefix,
    bool includeGroupedShapes,
    std::vector<ShapeInfo>& result)
{
    int shapeCount = shapes->get_Count();
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = shapes->idx_get(shapeIndex);
        int displayIndex = shapeIndex + 1;
        String shapeNamePart = String::Format(u"{0}_shape_{1}", prefix, displayIndex);
        result.push_back({ shape, shapeNamePart });

        auto groupShape = System::AsCast<IGroupShape>(shape);
        if (includeGroupedShapes && groupShape != nullptr)
        {
            EnumerateShapes(groupShape->get_Shapes(), shapeNamePart, includeGroupedShapes, result);
        }
    }
}

String GetSha256Hash(ArrayPtr<uint8_t> data)
{
    auto sha256 = HashAlgorithm::Create(u"SHA256");
    auto hash = sha256->ComputeHash(data);
    auto builder = MakeObject<StringBuilder>();

    int hashLength = hash->get_Length();
    for (int index = 0; index < hashLength; index++)
    {
        uint8_t hashByte = hash[index];
        builder->Append(String::Format(u"{0:x2}", hashByte));
    }

    return builder->ToString();
}

String GetExtensionFromContentType(String contentType)
{
    if (String::IsNullOrWhiteSpace(contentType))
    {
        return u"bin";
    }

    int separatorIndex = contentType.IndexOf(u";");
    String mediaType = separatorIndex >= 0 ? contentType.Substring(0, separatorIndex) : contentType;
    mediaType = mediaType.Trim().ToLower();

    if (mediaType == u"image/jpeg")
    {
        return u"jpg";
    }
    if (mediaType == u"image/png")
    {
        return u"png";
    }
    if (mediaType == u"image/gif")
    {
        return u"gif";
    }
    if (mediaType == u"image/bmp")
    {
        return u"bmp";
    }
    if (mediaType == u"image/tiff")
    {
        return u"tiff";
    }
    if (mediaType == u"image/x-emf" || mediaType == u"image/emf")
    {
        return u"emf";
    }
    if (mediaType == u"image/x-wmf" || mediaType == u"image/wmf")
    {
        return u"wmf";
    }
    if (mediaType == u"image/svg+xml")
    {
        return u"svg";
    }
    if (mediaType.StartsWith(u"image/"))
    {
        String extension = mediaType.Substring(String(u"image/").get_Length());
        return MakeSafeFileNamePart(extension);
    }

    return u"bin";
}

String MakeSafeFileNamePart(String value)
{
    auto invalidCharacters = Path::GetInvalidFileNameChars();
    int invalidCharacterCount = invalidCharacters->get_Length();
    for (int index = 0; index < invalidCharacterCount; index++)
    {
        value = value.Replace(invalidCharacters[index], u'_');
    }

    return value;
}
```

## **Εξαγωγή Εικόνων από Πλαισίων Εικόνας**

Χρησιμοποιήστε αυτή την προσέγγιση για εικόνες που εισάγονται ως ανεξάρτητα αντικείμενα. Ένα [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) αποθηκεύει την εικόνα του στο `get_PictureFormat()->get_Picture()->get_Image()`, η οποία επιστρέφει ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/).

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"extracted-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto pictureFrame = System::AsCast<IPictureFrame>(item.Shape);
            if (pictureFrame != nullptr)
            {
                auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **Εξαγωγή Εικόνων από Σχήματα γεμισμένα με Εικόνα**

Τα σχήματα μπορούν να χρησιμοποιούν μια εικόνα ως γέμιση. Ελέγξτε πρώτα τον τύπο γέμισης του σχήματος: αν δεν είναι [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/)::`Picture`, δεν υπάρχει εικόνα για εξαγωγή από αυτήν τη γέμιση. Το παρακάτω παράδειγμα διαχειρίζεται αντικείμενα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) και αποθηκεύει κάθε εικόνα ως PNG μέσω [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_Image()`.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"shape-fill-images");
    Directory::CreateDirectory_(outputDirectory);

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto autoShape = System::AsCast<IAutoShape>(item.Shape);
            if (autoShape != nullptr)
            {
                auto image = GetPictureFillImage(autoShape->get_FillFormat());
                if (image != nullptr)
                {
                    SaveImageAsPng(image, outputDirectory, item.NamePart);
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **Εξαγωγή Προεπισκοπήσεων Εικόνας από Πλαισίων Αντικειμένων OLE**

Ένα [IOleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ioleobjectframe/) μπορεί να έχει υποκατάστατη εικόνα που το PowerPoint χρησιμοποιεί ως προεπισκόπηση του αντικειμένου στη διαφάνεια. Η εικόνα αυτή είναι διαθέσιμη μέσω `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Η εξαγωγή αυτής της εικόνας δίνει τη προεπισκόπηση, όχι τα ενσωματωμένα περιεχόμενα του πακέτου OLE.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"ole-preview-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto oleObjectFrame = System::AsCast<IOleObjectFrame>(item.Shape);
            if (oleObjectFrame != nullptr)
            {
                auto image = oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->get_Image();
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_ole_preview", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **Εξαγωγή Προεπισκοπήσεων Εικόνας από Πλαισίων Βίντεο**

Ένα [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) μπορεί επίσης να αποθηκεύει μια προεπισκόπηση στο `get_PictureFormat()->get_Picture()->get_Image()`. Αυτό είναι το αφίσα ή η μικρογραφία που εμφανίζεται στη διαφάνεια, όχι ένα πλαίσιο αποκωδικοποιημένο από τη ροή βίντεο.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"video-preview-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto videoFrame = System::AsCast<IVideoFrame>(item.Shape);
            if (videoFrame != nullptr)
            {
                auto image = videoFrame->get_PictureFormat()->get_Picture()->get_Image();
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_video_preview", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **Εξαγωγή Προεπισκοπήσεων Εικόνας από Πλαισίων Ήχου**

Ένα [IAudioFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/iaudioframe/) μπορεί να αποθηκεύσει μια μικρογραφία στο `get_PictureFormat()->get_Picture()->get_Image()`. Αυτή είναι η εικόνα που εμφανίζεται για το αντικείμενο ήχου στη διαφάνεια.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"audio-preview-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto audioFrame = System::AsCast<IAudioFrame>(item.Shape);
            if (audioFrame != nullptr)
            {
                auto image = audioFrame->get_PictureFormat()->get_Picture()->get_Image();
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_audio_preview", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **Εξαγωγή Εικόνων από Αντικείμενα Zoom**

Τα σχήματα [IZoomFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/izoomframe/) και [ISectionZoomFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/isectionzoomframe/) μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες. Διαβάστε `get_ZoomImage()` από το πλαίσιο ζουμ.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"zoom-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto zoomFrame = System::AsCast<IZoomFrame>(item.Shape);
            if (zoomFrame != nullptr && zoomFrame->get_ZoomImage() != nullptr)
            {
                String fileNameBase = String::Format(u"{0}_zoom", item.NamePart);
                SaveOriginalImage(zoomFrame->get_ZoomImage(), outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

            auto sectionZoomFrame = System::AsCast<ISectionZoomFrame>(item.Shape);
            if (sectionZoomFrame != nullptr && sectionZoomFrame->get_ZoomImage() != nullptr)
            {
                String fileNameBase = String::Format(u"{0}_section_zoom", item.NamePart);
                SaveOriginalImage(sectionZoomFrame->get_ZoomImage(), outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **Εξαγωγή Εικόνων από Πλαισίων Σύνοψης Zoom**

Ένα [ISummaryZoomFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/isummaryzoomframe/) είναι επίσης σχήμα. Τα στοιχεία της ενότητας σύνοψης μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες, εκτεθειμένες μέσω της μεθόδου `get_ZoomImage()` του κάθε τμήματος σύνοψης.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"summary-zoom-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto summaryZoomFrame = System::AsCast<ISummaryZoomFrame>(item.Shape);
            if (summaryZoomFrame != nullptr)
            {
                auto summaryZoomCollection = summaryZoomFrame->get_SummaryZoomCollection();
                int sectionCount = summaryZoomCollection->get_Count();
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    auto section = summaryZoomCollection->idx_get(sectionIndex);
                    if (section->get_ZoomImage() != nullptr)
                    {
                        int displayIndex = sectionIndex + 1;
                        String fileNameBase = String::Format(u"{0}_summary_zoom_{1}", item.NamePart, displayIndex);
                        SaveOriginalImage(section->get_ZoomImage(), outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **Εξαγωγή Εικόνων από Σχήματα Πίνακα**

Ένα [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) είναι σχήμα. Οι εικόνες σε έναν πίνακα αποθηκεύονται συνήθως ως γεμίσεις εικόνας στα κελιά του πίνακα.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"table-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, true, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto table = System::AsCast<ITable>(item.Shape);
            if (table != nullptr)
            {
                int rowCount = table->get_Rows()->get_Count();
                int columnCount = table->get_Columns()->get_Count();
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        auto column = table->get_Column(columnIndex);
                        auto cell = column->idx_get(rowIndex);
                        auto image = GetPictureFillImage(cell->get_CellFormat()->get_FillFormat());
                        if (image != nullptr)
                        {
                            String fileNameBase = String::Format(
                                u"{0}_cell_{1}_{2}", item.NamePart, rowIndex + 1, columnIndex + 1);
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **Εξαγωγή Εικόνων από Σχήματα Γραφήματος**

Ένα [IChart](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/) είναι σχήμα. Το παρακάτω παράδειγμα εξάγει μια εικόνα από τη γεμιστική εικόνα της περιοχής του γραφήματος.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"chart-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, true, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto chart = System::AsCast<Aspose::Slides::Charts::IChart>(item.Shape);
            if (chart != nullptr)
            {
                auto fillFormat = chart->get_FillFormat();
                auto image = GetPictureFillImage(fillFormat);
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_chart_area", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **Εξαγωγή Εικόνων από Σχήματα SmartArt**

Ένα αντικείμενο [ISmartArt](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/ismartart/) είναι σχήμα. Ανάλογα με τη διάταξη του SmartArt, οι εικόνες μπορεί να αποθηκεύονται σε γεμίσματα bullet κόμβων ή στις μορφές γεμίσματος των σχήματος κόμβων.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"smartart-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, true, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto smartArt = System::AsCast<Aspose::Slides::SmartArt::ISmartArt>(item.Shape);
            if (smartArt != nullptr)
            {
                int nodeCount = smartArt->get_AllNodes()->get_Count();
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    auto node = smartArt->get_NodeFromAll(nodeIndex);
                    auto bulletImage = GetPictureFillImage(node->get_BulletFillFormat());
                    if (bulletImage != nullptr)
                    {
                        String fileNameBase = String::Format(
                            u"{0}_smartart_node_{1}_bullet", item.NamePart, nodeIndex + 1);
                        SaveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node->get_Shapes()->get_Count();
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        auto nodeShape = node->get_Shape(nodeShapeIndex);
                        auto image = GetPictureFillImage(nodeShape->get_FillFormat());
                        if (image != nullptr)
                        {
                            String fileNameBase = String::Format(
                                u"{0}_smartart_node_{1}_shape_{2}",
                                item.NamePart,
                                nodeIndex + 1,
                                nodeShapeIndex + 1);
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **Συμπερίληψη Εικόνων Μέσα σε Ομαδοποιημένα Σχήματα**

Τα ομαδοποιημένα σχήματα περιέχουν τις δικές τους συλλογές σχημάτων. Η κοινή βοηθητική μέθοδος `EnumerateShapes` έχει επιλογή `includeGroupedShapes`. Ορίστε την σε `true` όταν θέλετε να εξετάσετε σχήματα μέσα σε αντικείμενα [IGroupShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/igroupshape/). Το παρακάτω παράδειγμα εξάγει εικόνες από πλαίσια εικόνας, σχήματα γεμισμένα με εικόνα, προεπισκοπήσεις αντικειμένων OLE, μικρογραφίες πλαισίων βίντεο και μικρογραφίες πλαισίων ήχου. Για να συμπεριλάβετε εικόνες πίνακα, γραφήματος, SmartArt και σύνοψης ζουμ επίσης, χρησιμοποιήστε ξανά τη εξειδικευμένη λογική εξαγωγής από τα προηγούμενα τμήματα διατηρώντας την ίδια αναδρομική περιήγηση σχημάτων.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"all-shape-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, true, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto pictureFrame = System::AsCast<IPictureFrame>(item.Shape);
            if (pictureFrame != nullptr)
            {
                auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                continue;
            }

            auto autoShape = System::AsCast<IAutoShape>(item.Shape);
            if (autoShape != nullptr)
            {
                auto image = GetPictureFillImage(autoShape->get_FillFormat());
                if (image != nullptr)
                {
                    SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                }

                continue;
            }

            auto oleObjectFrame = System::AsCast<IOleObjectFrame>(item.Shape);
            if (oleObjectFrame != nullptr)
            {
                auto image = oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->get_Image();
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_ole_preview", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            auto videoFrame = System::AsCast<IVideoFrame>(item.Shape);
            if (videoFrame != nullptr)
            {
                auto image = videoFrame->get_PictureFormat()->get_Picture()->get_Image();
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_video_preview", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            auto audioFrame = System::AsCast<IAudioFrame>(item.Shape);
            if (audioFrame != nullptr)
            {
                auto image = audioFrame->get_PictureFormat()->get_Picture()->get_Image();
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_audio_preview", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **Περιπτώσεις Ακρότητας και Πρακτικές Σημειώσεις**

- **Διπλότυπες εικόνες:** Πολλά σχήματα μπορεί να αναφέρονται στην ίδια εικόνα ή σε διαφορετικές εικόνες με ταυτόσες bytes. Κατακερματίστε το [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_BinaryData()` πριν γράψετε αρχεία αν θέλετε ένα αρχείο εξόδου ανά μοναδική εικόνα.  
- **Αρχικά δεδομένα vs. μετατρεπόμενη έξοδος:** Η αποθήκευση του [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_BinaryData()` διατηρεί τα ενσωματωμένα δεδομένα JPEG, PNG, GIF, SVG, EMF ή WMF. Η αποθήκευση του [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_Image()` μέσω [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/)::`Save` είναι χρήσιμη όταν θέλετε σταθερή μορφή εξόδου.  
- **Μη υποστηριζόμενοι τύποι γεμίσεων:** Σχήματα με συμπαγή, διαβαθμισμένη, πρότυπη ή χωρίς γέμιση δεν περιέχουν εικόνα γέμισης. Ελέγξτε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) πριν διαβάσετε το `get_PictureFillFormat()`.  
- **Ομαδοποιημένα σχήματα:** Η συλλογή σχημάτων της διαφάνειας ανώτερου επιπέδου δεν «εξομαλύνει» τις ομάδες. Εξετάστε αναδρομικά το [IGroupShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/igroupshape/)::`get_Shapes()` όταν το περιεχόμενο της ομάδας έχει σημασία.  
- **Προεπισκοπήσεις αντικειμένων OLE:** Ένα [IOleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ioleobjectframe/) μπορεί να εκθέτει προεπισκόπηση μέσω `get_SubstitutePictureFormat()`, αλλά αυτή η εικόνα είναι μόνο η προεπισκόπηση της διαφάνειας. Δεν είναι το ενσωματωμένο αρχείο μέσα στο αντικείμενο OLE.  
- **Μικρογραφίες πλαισίων βίντεο:** Ένα [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) μπορεί να εκθέτει προεπισκόπηση μέσω `get_PictureFormat()`, αλλά αυτή η εικόνα είναι μόνο η αφίσα που εμφανίζεται στη διαφάνεια. Δεν εξάγεται από τη ροή βίντεο.  
- **Μικρογραφίες πλαισίων ήχου:** Ένα [IAudioFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/iaudioframe/) μπορεί να εκθέτει εικονίδιο ή μικρογραφία μέσω `get_PictureFormat()`· δεν είναι τα ενσωματωμένα δεδομένα ήχου.  
- **Εικόνες μεγέθυνσης:** Τα σχήματα μεγέθυνσης διαφάνειας, ενότητας και σύνοψης μπορεί να χρησιμοποιούν προσαρμοσμένα αντικείμενα [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) μέσω `get_ZoomImage()`.  
- **Νεστά μοντέλα σχημάτων:** Τα αντικείμενα πίνακα, γραφήματος και SmartArt υλοποιούν το [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/), αλλά οι εικόνες τους συχνά αποθηκεύονται σε νεστές μορφές κελιού πίνακα, στοιχείου γραφήματος ή μορφοποίησης κόμβου SmartArt.  
- **Κομμένες ή μετασχηματισμένες εικόνες:** Η πρόσβαση στο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) σας δίνει τον αποθηκευμένο πόρο εικόνας. Δεν αποδίδει κοψίματα, διαφάνεια, επαναχρωματισμό, περιστροφή ή άλλα οπτικά εφέ που εφαρμόζει το σχήμα.

## **Συχνές Ερωτήσεις**

### Μπορώ να εξάγω την αρχική εικόνα χωρίς κοψίματα, εφέ ή μετασχηματισμούς σχήματος;

Ναι. Πρόσβαση στο αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) και εγγραφή του `get_BinaryData()` στο δίσκο. Αυτό διατηρεί την αρχική κωδικοποιημένη εικόνα που αποθηκεύεται στην παρουσίαση, όχι τον τρόπο με τον οποίο απεικονίζεται στη διαφάνεια.

### Μπορώ να εξάγω κάθε εξαγόμενη εικόνα ως PNG;

Ναι. Χρησιμοποιήστε [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_Image()` για να λάβετε ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) και, στη συνέχεια, καλέστε [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/)::`Save` με [ImageFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/imageformat/)::`Png`. Αυτό μετατρέπει την έξοδο και μπορεί να μην διατηρήσει τον αρχικό τύπο αρχείου ή τα διανυσματικά δεδομένα.

### Πώς αποφεύγω να αποθηκεύω την ίδια εικόνα περισσότερες από μία φορές;

Χρησιμοποιήστε έναν κατακερματισμό του [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_BinaryData()` και διατηρήστε τους κατακερματισμούς σε ένα σύνολο. Αν μια νέα εικόνα έχει κατακερματισμό που ήδη υπάρχει, παραλείψτε την ή καταγράψτε άλλη αναφορά στο υπάρχον αρχείο εξόδου.

### Γιατί μερικά σχήματα δεν παράγουν εικόνα;

Τα πλαίσια εικόνας, τα σχήματα γεμισμένα με εικόνα, τα πλαίσια αντικειμένων OLE, τα πλαίσια μέσων, τα πλαίσια μεγέθυνσης, οι πίνακες, τα γραφήματα και τα αντικείμενα SmartArt μπορούν να αναφέρονται σε εικόνες. Ορισμένοι τύποι σχημάτων εκθέτουν εικόνες μέσω νεστών αντικειμένων μορφοποίησης, οπότε ένας απλός έλεγχος `get_PictureFormat()` ή `get_FillFormat()` δεν είναι πάντα επαρκής.

### Μπορώ να εξάγω τη μικρογραφία που εμφανίζεται για ένα πλαίσιο βίντεο;

Ναι. Χρησιμοποιήστε [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` και διαβάστε το `get_PictureFormat()->get_Picture()->get_Image()`. Αυτό εξάγει την αφίσα εικόνας που αποθηκεύεται με το πλαίσιο βίντεο, όχι ένα πλαίσιο που δημιουργείται από το αρχείο βίντεο.

### Πώς μπορώ να καθορίσω ποια σχήματα χρησιμοποιούν μια συγκεκριμένη εικόνα από τη συλλογή εικόνων της παρουσίασης;

Το Aspose.Slides δεν αποθηκεύει αντίστροφους συνδέσμους από το [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) προς τα σχήματα. Κατασκευάστε έναν χάρτη κατά τη διάρκεια της περιήγησης: κάθε φορά που βρίσκετε μια αναφορά εικόνας, καταγράψτε τον αριθμό διαφάνειας, τη διαδρομή σχήματος και το κατακερματισμό ή το στοιχείο της συλλογής.

### Μπορώ να εξάγω εικόνες ενσωματωμένες μέσα σε αντικείμενα OLE, όπως συνημμένα έγγραφα;

Μπορείτε να εξάγετε την προεπισκόπηση διαφάνειας του αντικειμένου OLE από το [IOleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()`. Ωστόσο, αυτή η προεπισκόπηση δεν είναι το ενσωματωμένο έγγραφο καθαυτό. Για να εξάγετε εικόνες από το ενσωματωμένο αρχείο, εξάγετε τα δεδομένα OLE και εξετάστε τα με εργαλεία κατάλληλα για τον τύπο αρχείου.
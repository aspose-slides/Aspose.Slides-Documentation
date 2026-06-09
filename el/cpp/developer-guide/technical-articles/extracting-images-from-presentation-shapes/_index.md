---
title: Εξαγωγή εικόνων από σχήματα παρουσίασης σε C++
linktitle: Εικόνα από σχήμα
type: docs
weight: 90
url: /el/cpp/extracting-images-from-presentation-shapes/
keywords:
- εξαγωγή εικόνας
- ανάκτηση εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εξάγετε εικόνες από σχήματα σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για C++ - γρήγορη, φιλική προς τον κώδικα λύση."
---
## **Επισκόπηση**

Οι εικόνες σε μια παρουσίαση μπορούν να εμφανιστούν σε πολλούς τύπους σχήματος: ως συνηθισμένα πλαίσια εικόνας, ως γεμίσματα εικόνας που εφαρμόζονται σε σχήματα, ως εικόνες προεπισκόπησης αντικειμένου OLE, ως μικρογραφίες πλαισίων βίντεο ή ήχου, ως εικόνες ζουμ ή ως εικόνες ενσωματωμένες μέσα σε σχήματα πίνακα, διαγράμματος και SmartArt. Το Aspose.Slides αποθηκεύει αυτές τις εικόνες στη συλλογή εικόνων της παρουσίασης, η οποία εκτίθεται μέσω των αντικειμένων [IImageCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimagecollection/) και [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/).

Αν χρειάζεστε μόνο να εξάγετε κάθε ενσωματωμένο πόρο εικόνας σε μια παρουσίαση, επαναλάβετε τη συλλογή `presentation->get_Images()`. Αυτό το άρθρο εστιάζει σε διαφορετικό έργο: η διέλευση των σχημάτων για να βρεθεί πού χρησιμοποιούνται εικόνες στις διαφάνειες, ώστε τα αποθηκευμένα αρχεία να διατηρούν χρήσιο πλαίσιο όπως ο αριθμός διαφάνειας, η θέση του σχήματος και ο τύπος προέλευσης (πλαίσιο εικόνας, γεμισμένη εικόνα, προεπισκόπηση πολυμέσων, προεπισκόπηση OLE ή εικόνα ζουμ).

{{% alert title="Tip" color="primary" %}}
Χρησιμοποιήστε το [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_BinaryData()` για να διατηρήσετε τα αρχικά κωδικοποιημένα δεδομένα της εικόνας και τον τύπο αρχείου. Χρησιμοποιήστε το [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_Image()` μαζί με το [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/)::`Save` όταν θέλετε να ομαλοποιήσετε την έξοδο σε συγκεκριμένο μορφότυπο όπως PNG.
{{% /alert %}}

## **Κοινές Βοηθητικές Μεθόδοι**

Οι παρακάτω βοηθητικές μέθοδοι κρατούν τα παραδείγματα σύντομα. `SaveOriginalImage` γράφει τα αρχικά ενσωματωμένα bytes, επιλέγει ένα ασφαλές πρόσθετο από τον τύπο MIME και παραλείπει διπλότυπα δυαδικά δεδομένα εικόνας με βάση το κατακερματισμό SHA-256.

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
    if (!savedImageHashes->Add(imageHash))
    {
        return false;
    }

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

    sha256->Dispose();
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

## **Απόσπαση Εικόνων από Πλαίσια Εικόνας**

Χρησιμοποιήστε αυτή την προσέγγιση για εικόνες που εισάγονται ως ανεξάρτητα αντικείμενα. Ένα [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) αποθηκεύει την εικόνα του στο `get_PictureFormat()->get_Picture()->get_Image()`, το οποίο επιστρέφει ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/).

```cpp
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
```

## **Απόσπαση Εικόνων από Σχήματα με Γέμισμα Εικόνας**

Τα σχήματα μπορούν να χρησιμοποιούν μια εικόνα ως γέμισμα. Ελέγξτε πρώτα τον τύπο γεμίσματος του σχήματος: αν δεν είναι [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/)::`Picture`, δεν υπάρχει εικόνα για απόσπαση από αυτό το γέμισμα. Το παρακάτω παράδειγμα επεξεργάζεται αντικείμενα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) και αποθηκεύει κάθε εικόνα ως PNG μέσω του [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_Image()`.

```cpp
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
```

## **Απόσπαση Προεπισκοπήσεων Εικόνων από Πλαίσια Αντικειμένου OLE**

Ένα [IOleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ioleobjectframe/) μπορεί να έχει μια υποκατάστατη εικόνα που το PowerPoint χρησιμοποιεί ως προεπισκόπηση του αντικειμένου σε μια διαφάνεια. Αυτή η εικόνα είναι διαθέσιμη μέσω του `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Η απόσπαση αυτής της εικόνας σας δίνει τη εικόνα προεπισκόπησης, όχι το ενσωματωμένο περιεχόμενο του πακέτου OLE.

```cpp
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
```

## **Απόσπαση Προεπισκοπήσεων Εικόνων από Πλαίσια Βίντεο**

Ένα [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) μπορεί επίσης να αποθηκεύσει μια προεπισκόπηση εικόνας στο `get_PictureFormat()->get_Picture()->get_Image()`. Αυτή είναι η αφίσα ή μικρογραφία που εμφανίζεται στη διαφάνεια, όχι ένα καρέ που αποκωδικοποιείται από τη ροή βίντεο.

```cpp
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
```

## **Απόσπαση Προεπισκοπήσεων Εικόνων από Πλαίσια Ήχου**

Ένα [IAudioFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/iaudioframe/) μπορεί να αποθηκεύσει μια μικρογραφία στο `get_PictureFormat()->get_Picture()->get_Image()`. Αυτή είναι η εικόνα που εμφανίζεται για το αντικείμενο ήχου στη διαφάνεια.

```cpp
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
```

## **Απόσπαση Εικόνων από Αντικείμενα Ζουμ**

Τα σχήματα [IZoomFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/izoomframe/) και [ISectionZoomFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/isectionzoomframe/) μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες. Διαβάστε το `get_ZoomImage()` από το πλαίσιο ζουμ.

```cpp
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
```

## **Απόσπαση Εικόνων από Πλαίσια Σύνοψης Ζουμ**

Ένα [ISummaryZoomFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/isummaryzoomframe/) είναι επίσης σχήμα. Τα αντικείμενα των τμημάτων του μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες, που εκτίθενται μέσω της μεθόδου `get_ZoomImage()` του κάθε τμήματος σύνοψης ζουμ.

```cpp
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
```

## **Απόσπαση Εικόνων από Σχήματα Πίνακα**

Ένα [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) είναι σχήμα. Οι εικόνες σε έναν πίνακα αποθηκεύονται συνήθως ως γεμίσματα εικόνας στα κελιά του πίνακα.

```cpp
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
```

## **Απόσπαση Εικόνων από Σχήματα Διαγράμματος**

Ένα [IChart](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/) είναι σχήμα. Το παρακάτω παράδειγμα εξάγει μια εικόνα από το γέμισμα εικόνας της περιοχής του διαγράμματος.

```cpp
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
```

## **Απόσπαση Εικόνων από Σχήματα SmartArt**

Ένα αντικείμενο [ISmartArt](https://reference.aspose.com/slides/el/cpp/aspose.slides.smartart/ismartart/) είναι σχήμα. Ανάλογα με τη διάταξη του SmartArt, οι εικόνες μπορεί να αποθηκεύονται στα γεμίσματα κουκίδων των κόμβων ή στις μορφές γεμίσματος των σχημάτων των κόμβων.

```cpp
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
```

## **Συμπερίληψη Εικόνων μέσα σε Ομαδοποιημένα Σχήματα**

Τα ομαδοποιημένα σχήματα περιέχουν τις δικές τους συλλογές σχημάτων. Η κοινή βοηθητική μέθοδος `EnumerateShapes` διαθέτει την επιλογή `includeGroupedShapes`. Ορίστε την σε `true` όταν θέλετε να ελέγξετε τα σχήματα μέσα σε αντικείμενα [IGroupShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/igroupshape/). Το παρακάτω παράδειγμα εξάγει εικόνες από πλαίσια εικόνας, σχήματα με γέμισμα εικόνας, προεπισκοπήσεις αντικειμένων OLE, μικρογραφίες πλαισίων βίντεο και μικρογραφίες πλαισίων ήχου. Για να συμπεριλάβετε επίσης εικόνες από πίνακες, διαγράμματα, SmartArt και σύνοψη ζουμ, επαναχρησιμοποιήστε τη εξειδικευμένη λογική εξαγωγής από τις προηγούμενες ενότητες διατηρώντας την ίδια αναδρομική διαδρομή σχημάτων.

```cpp
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
```

## **Ακραίες Περιπτώσεις και Πρακτικές Σημειώσεις**

- **Διπλότυπες εικόνες:** Πολλά σχήματα μπορεί να αναφέρονται στην ίδια εικόνα ή σε διαφορετικές εικόνες με ίδιους byte. Υπολογίστε το κατακερματισμό [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_BinaryData()` πριν γράψετε τα αρχεία αν θέλετε ένα αρχείο εξόδου ανά μοναδική εικόνα.
- **Αρχικά δεδομένα vs. μετατρεπόμενη έξοδο:** Η αποθήκευση του [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_BinaryData()` διατηρεί τα ενσωματωμένα δεδομένα JPEG, PNG, GIF, SVG, EMF ή WMF. Η αποθήκευση του [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_Image()` μέσω του [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/)::`Save` είναι χρήσιμη όταν θέλετε μια συνεπή μορφή εξόδου.
- **Μη υποστηριζόμενα είδη γεμίσματος:** Σχήματα με γεμίσματα στερεά, διαβαθμισμένα, μοτίβο ή χωρίς γεμίσματα δεν περιέχουν εικόνα γεμίσματος. Ελέγξτε το [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/filltype/) πριν διαβάσετε το `get_PictureFillFormat()`.
- **Ομαδοποιημένα σχήματα:** Η συλλογή σχημάτων επιπέδου διαφάνειας δεν «ισοπεδώνει» τις ομάδες. Ελέγξτε αναδρομικά το [IGroupShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/igroupshape/)::`get_Shapes()` όταν το περιεχόμενο της ομάδας είναι σημαντικό.
- **Προεπισκοπήσεις αντικειμένων OLE:** Ένα [IOleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ioleobjectframe/) μπορεί να αποκαλύψει μια εικόνα προεπισκόπησης μέσω του `get_SubstitutePictureFormat()`, αλλά αυτή η εικόνα είναι μόνο η προεπισκόπηση της διαφάνειας. Δεν είναι το ενσωματωμένο αρχείο μέσα στο αντικείμενο OLE.
- **Μικρογραφίες πλαισίων βίντεο:** Ένα [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/) μπορεί να αποκαλύψει μια εικόνα προεπισκόπησης μέσω του `get_PictureFormat()`, αλλά αυτή η εικόνα είναι μόνο η αφίσα που εμφανίζεται στη διαφάνεια. Δεν εξάγεται από τη ροή βίντεο.
- **Μικρογραφίες πλαισίων ήχου:** Ένα [IAudioFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/iaudioframe/) μπορεί να αποκαλύψει ένα εικονίδιο ή μικρογραφία μέσω του `get_PictureFormat()`· δεν είναι τα ενσωματωμένα δεδομένα ήχου.
- **Εικόνες ζουμ:** Τα σχήματα ζουμ διαφάνειας, τμήματος ζουμ και σύνοψης ζουμ μπορεί να χρησιμοποιούν προσαρμοσμένα [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) μέσω του `get_ZoomImage()`.
- **Φωλιασμένα μοντέλα σχημάτων:** Τα αντικείμενα πίνακα, διαγράμματος και SmartArt υλοποιούν το [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/), αλλά οι εικόνες τους συχνά αποθηκεύονται σε φωλιασμένα αντικείμενα μορφοποίησης κελιών πίνακα, στοιχείων διαγράμματος ή κόμβων SmartArt.
- **Περικομμένες ή μετασχηματισμένες εικόνες:** Η πρόσβαση στο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) σας δίνει τον αποθηκευμένο πόρο εικόνας. Δεν αποδίδει την περικοπή, τη διαφάνεια, την αλλαγή χρώματος, την περιστροφή ή άλλα οπτικά εφέ που εφαρμόζονται από το σχήμα.

## **Συχνές Ερωτήσεις**

**Μπορώ να εξάγω την αρχική εικόνα χωρίς περικοπή, εφέ ή μετασχηματισμούς σχήματος;**

Ναι. Πρόσβαση στο αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) και εγγραφή του [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_BinaryData()` στο δίσκο. Αυτό διατηρεί την αρχική κωδικοποιημένη εικόνα που είναι αποθηκευμένη στην παρουσίαση, όχι τον τρόπο που η εικόνα αποδίδεται στη διαφάνεια.

**Μπορώ να εξάγω κάθε εξαγόμενη εικόνα ως PNG;**

Ναι. Χρησιμοποιήστε το [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_Image()` για να πάρετε ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/) και, στη συνέχεια, καλέστε το [IImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/iimage/)::`Save` με [ImageFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/imageformat/)::`Png`. Αυτό μετατρέπει την έξοδο και μπορεί να μην διατηρεί τον αρχικό τύπο αρχείου ή τα διανυσματικά δεδομένα.

**Πώς μπορώ να αποφύγω την αποθήκευση της ίδιας εικόνας περισσότερες από μία φορές;**

Χρησιμοποιήστε ένα κατακερματισμό του [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/)::`get_BinaryData()` και αποθηκεύστε τα κατατεματα σε ένα σύνολο. Εάν μια νέα εικόνα έχει κατακερματισμό που υπάρχει ήδη, παραλείψτε την ή καταγράψτε άλλη αναφορά στο υπάρχον αρχείο εξόδου.

**Γιατί ορισμένα σχήματα δεν παράγουν εικόνα;**

Τα πλαίσια εικόνας, τα σχήματα με γέμισμα εικόνας, τα πλαίσια αντικειμένου OLE, τα πολυμέσα, τα πλαίσια ζουμ, οι πίνακες, τα διαγράμματα και τα αντικείμενα SmartArt μπορούν να αναφέρονται σε εικόνες. Ορισμένοι τύποι σχημάτων εκθέτουν εικόνες μέσω φωλιασμένων αντικειμένων μορφοποίησης, έτσι ένας απλός έλεγχος `get_PictureFormat()` ή `get_FillFormat()` δεν είναι πάντα επαρκής.

**Μπορώ να εξάγω τη μικρογραφία που εμφανίζεται για ένα πλαίσιο βίντεο;**

Ναι. Χρησιμοποιήστε το [IVideoFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` και διαβάστε το `get_PictureFormat()->get_Picture()->get_Image()`. Αυτό εξάγει την εικόνα αφίσας που είναι αποθηκευμένη με το πλαίσιο βίντεο, όχι ένα καρέ που παράγεται από το αρχείο βίντεο.

**Πώς μπορώ να καθορίσω ποια σχήματα χρησιμοποιούν μια συγκεκριμένη εικόνα από τη συλλογή εικόνων της παρουσίασης;**

Το Aspose.Slides δεν αποθηκεύει αντίστροφους συνδέσμους από το [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) προς τα σχήματα. Κατασκευάστε μια αντιστοίχηση κατά τη διάρκεια της διαδρομής: κάθε φορά που βρίσκετε μια αναφορά εικόνας, καταγράψτε τον αριθμό διαφάνειας, τη διαδρομή του σχήματος και το κατακερματισμό ή το στοιχείο της συλλογής.

**Μπορώ να εξάγω εικόνες ενσωματωμένες μέσα σε αντικείμενα OLE, όπως συνημμένα έγγραφα;**

Μπορείτε να εξάγετε την προεπισκόπηση διαφάνειας του αντικειμένου OLE μέσω του [IOleObjectFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()`. Ωστόσο, αυτή η προεπισκόπηση δεν είναι το ενσωματωμένο έγγραφο. Για να εξάγετε εικόνες από μέσα στο ενσωματωμένο αρχείο, εξάγετε τα δεδομένα OLE και ελέγξτε τα με εργαλεία για τον αντίστοιχο τύπο αρχείου.
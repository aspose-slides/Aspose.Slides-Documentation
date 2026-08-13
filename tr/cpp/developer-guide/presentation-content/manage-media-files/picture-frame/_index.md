---
title: C++ Kullanarak Sunumlarda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/cpp/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- görüntü ekle
- görüntü oluştur
- görüntü çıkar
- raster görüntü
- vektör görüntü
- görüntüyü kırp
- kırpılmış alan
- StretchOff özelliği
- resim çerçevesi biçimlendirme
- resim çerçevesi özellikleri
- göreceli ölçek
- görüntü efekti
- en boy oranı
- görüntü şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı kolaylaştırın ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Bir resim çerçevesi, bir resmi içeren bir şekildir—çerçeve içinde bir resim gibi.  

Bir resmi bir slayta resim çerçevesi aracılığıyla ekleyebilirsiniz. Bu şekilde, resmi resim çerçevesini biçimlendirerek biçimlendirebilirsiniz.

{{% alert  title="Tip" color="info" %}} 

Aspose, görüntülerden hızlı bir şekilde sunum oluşturmayı sağlayan ücretsiz dönüştürücüler—[JPEG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar. 

{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Sunum sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slaydın referansını alın. 
3. Şekli doldurmak için kullanılacak sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_image_collection)’a bir görüntü ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_p_p_image) nesnesi oluşturun.
4. Görüntünün genişliğini ve yüksekliğini belirtin.
5. Referans alınan slayda bağlı şekil nesnesinin sunduğu `AddPictureFrame` yöntemi ile görüntünün genişliği ve yüksekliğine dayalı bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_frame) oluşturun.
6. Slayta bir resim çerçevesi (resmi içeren) ekleyin.
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Belge dizinine giden yol.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// İstenen sunumu yükle.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Sunumun görüntü koleksiyonuna eklenecek görüntüyü yükler
// Resmi alır
auto image = Images::FromFile(filePath);

// Görüntüyü sunumun görüntü koleksiyonuna ekler
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Slayta bir resim çerçevesi ekler
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Göreceli ölçek genişliğini ve yüksekliğini ayarlar
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Resim çerçevesine bazı biçimlendirmeler uygular
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// PPTX dosyasını diske yazar
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Resim çerçeveleri, görüntülere dayalı sunum slaytlarını hızlı bir şekilde oluşturmanızı sağlar. Resim çerçevesini Aspose.Slides kaydetme seçenekleriyle birleştirerek, görüntüleri bir formattan diğerine dönüştürmek için giriş/çıkış işlemlerini yönetebilirsiniz. Aşağıdaki sayfalara göz atmak isteyebilirsiniz: [görüntüyü JPG'e dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/image-to-jpg/); [JPG'yi görüntüye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-image/); [JPG'yi PNG'e dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-png/), [PNG'yi JPG'e dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/png-to-jpg/); [PNG'yi SVG'e dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/png-to-svg/), [SVG'yi PNG'e dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Göreceli Ölçekli Resim Çerçevesi Oluşturma**

Bir görüntünün göreceli ölçeğini değiştirerek daha karmaşık bir resim çerçevesi oluşturabilirsiniz. 

1. Sunum sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slaydın referansını alın. 
3. Sunumun görüntü koleksiyonuna bir resim ekleyin.
4. Şekli doldurmak için kullanılacak sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_image_collection)’a bir görüntü ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_p_p_image) nesnesi oluşturun.
5. Resim çerçevesinde görüntünün göreceli genişliğini ve yüksekliğini belirtin.
6. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Belgeler dizinine giden yol.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// İstenen sunumu yükler
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Sunumun görüntü koleksiyonuna eklenecek görüntüyü yükler
// Resmi alır
auto image = Images::FromFile(filePath);

// Görüntüyü sunumun görüntü koleksiyonuna ekler
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Slayta bir resim çerçevesi ekler
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Göreceli ölçek genişliğini ve yüksekliğini ayarlar
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTX dosyasını diske yazar
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Resim Çerçevelerinden Raster Görüntüler Çıkarma**

Raster görüntüleri [PictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_frame) nesnelerinden çıkarabilir ve PNG, JPG ve diğer formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, “sample.pptx” belgesinden bir görüntüyü nasıl çıkarıp PNG formatında kaydedebileceğinizi gösterir.

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_Image();

    image->Save(u"slide_1_shape_1.png", ImageFormat::Png);
}

presentation->Dispose();
```

## **Resim Çerçevelerinden SVG Görüntüler Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) şekilleri içinde SVG grafikler içerdiğinde, Aspose.Slides for C++ orijinal vektör görüntülerini tam doğrulukla almanıza olanak tanır. Slaytın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) nesnesini tanımlayabilir, alttaki [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) SVG içeriği tutup tutmadığını kontrol edebilir ve ardından bu görüntüyü yerel SVG formatında diske veya akışa kaydedebilirsiniz.

Aşağıdaki kod örneği, bir resim çerçevesinden SVG görüntüsünü nasıl çıkaracağınızı gösterir:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **Bir Görüntünün Şeffaflığını Almak**

Aspose.Slides, bir görüntüye uygulanan şeffaflık etkisini almanıza olanak tanır. Bu C++ kodu işlemi gösterir:

```c++
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="info" %}} 
Görüntülere uygulanan tüm etkiler [Aspose::Slides::Effects](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/) içinde bulunabilir.
{{% /alert %}}

## **Bir Görüntünün Parlaklık ve Kontrastını Almak**

Aspose.Slides, bir görüntüye uygulanan parlaklık ve kontrast etkisini almanıza olanak tanır. [ILuminance](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iluminance/) arayüzü bu görüntü dönüşüm etkisini temsil eder.

Bu C++ kodu, bir resim çerçevesinden parlaklık ve kontrast ayarlarını nasıl alacağınızı gösterir:

```c++
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulanabilecek birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, bir resim çerçevesini belirli gereksinimlere uyacak şekilde değiştirebilirsiniz.

1. Sunum sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slaydın referansını alın. 
3. Şekli doldurmak için kullanılacak sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_image_collection)’a bir görüntü ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_p_p_image) nesnesi oluşturun.
4. Görüntünün genişliğini ve yüksekliğini belirtin.
5. Referans alınan slayda bağlı [IShapes](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape_collection) nesnesinin sunduğu [AddPictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) yöntemi ile görüntünün genişliği ve yüksekliğine dayalı bir `PictureFrame` oluşturun.
6. Resim çerçevesini (resmi içeren) slayta ekleyin.
7. Resim çerçevesinin çizgi rengini ayarlayın.
8. Resim çerçevesinin çizgi kalınlığını ayarlayın.
9. Resim çerçevesini pozitif ya da negatif bir değer vererek döndürün.
   * Pozitif bir değer görüntüyü saat yönünde döndürür. 
   * Negatif bir değer görüntüyü saat yönünün tersine döndürür.
10. Resim çerçevesini (resmi içeren) slayta ekleyin.
11. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Bu C++ kodu, resim çerçevesi biçimlendirme sürecini gösterir:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Belgeler dizinine giden yol.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// İstenen sunumu yükler
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Sunumun görüntü koleksiyonuna eklenecek görüntüyü yükler
// Resmi alır
auto image = Images::FromFile(filePath);

// Görüntüyü sunumun görüntü koleksiyonuna ekler
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Slayta bir resim çerçevesi ekler
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Göreceli ölçek genişliğini ve yüksekliğini ayarlar
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTX dosyasını diske yazar
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="info" %}}

Aspose, yakın zamanda ücretsiz bir [Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG veya PNG görüntülerini birleştirmek, fotoğraflardan ızgara oluşturmak istediğinizde bu hizmeti kullanabilirsiniz. 

{{% /alert %}}

## **Bir Görüntüyü Bağlantı Olarak Ekle**

Sunum dosyasının boyutunu büyütmekten kaçınmak için, dosyaları doğrudan gömmek yerine görüntüleri (veya videoları) bağlantılar aracılığıyla ekleyebilirsiniz. Bu C++ kodu, bir yer tutucuya bir görüntü ve bir video nasıl ekleyeceğinizi gösterir:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IVideoFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/collections/list.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Görüntüleri Kırpma**

Bu C++ kodu, bir slayttaki mevcut bir görüntüyü nasıl kırpacağınızı gösterir: 

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// Yeni görüntü nesnesi oluşturur
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Bir slayta PictureFrame ekler
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Görüntüyü kırpar (yüzde değerleri)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Sonucu kaydeder
presentation->Save(u"cropped.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bir Resmin Kırpılmış Alanlarını Silme**

Bir çerçevede bulunan bir görüntünün kırpılmış alanlarını silmek istiyorsanız, [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) yöntemini kullanabilirsiniz. Bu yöntem, kırpma gereksizse kırpılmış resmi veya orijinal resmi döndürür.

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// İlk slayttan PictureFrame'i alır
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// PictureFrame görüntüsünün kırpılmış alanlarını siler ve kırpılmış resmi döndürür
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Sonucu kaydeder
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) yöntemi kırpılmış resmi sunumun görüntü koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) içinde kullanılıyorsa, bu yapı sunum boyutunu azaltabilir. Aksi takdirde, ortaya çıkan sunumdaki görüntü sayısı artar.

Bu yöntem, kırpma işlemi sırasında WMF/EMF metafilelarını raster PNG görüntüsüne dönüştürür. 

{{% /alert %}}

## **Görüntüleri Sıkıştırma**

[IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/compressimage/) yöntemiyle bir sunumdaki resmi sıkıştırabilirsiniz. Bu yöntem, şekil boyutuna ve belirtilen çözünürlüğe göre görüntünün boyutunu küçülterek, kırpılmış alanları silme seçeneği sunar.

Görüntünün boyut ve çözünürlüğünü PowerPoint'in **Resim Biçimi -> Resimleri Sıkıştır -> Çözünürlük** özelliğine benzer şekilde ayarlar.

Aşağıdaki C++ örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki resmi nasıl sıkıştırabileceğinizi gösterir:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Görüntüyü 150 DPI (Web çözünürlüğü) hedef çözünürlükte sıkıştır ve kırpılmış alanları kaldır.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Sıkıştırmanın sonucunu kontrol et.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Veya doğrudan özel bir DPI değeri kullanarak:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Görüntüyü 150 DPI (web çözünürlüğü) sıkıştır, kırpılmış alanları kaldır.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

Yöntem, şekil boyutuna ve verilen DPI'ye göre görüntüyü daha düşük bir çözünürlüğe dönüştürür. Dosya boyutunu optimize etmek için kırpılmış bölgeler de silinebilir. Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. Ayrıca, JPEG kalitesi çözünürlüğe bağlı olarak korunur veya hafifçe düşürülür; bu, PowerPoint'in yüksek çözünürlüklü JPEG'leri nasıl ele aldığını yansıtır.

{{% /alert %}}

## **En Boy Oranını Kilitleme**

Bir şeklin içinde bulunan görüntünün boyutlarını değiştirdikten sonra bile şeklin en boy oranını korumasını istiyorsanız, *Lock Aspect Ratio* ayarını belirlemek için [set_AspectRatioLocked()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) yöntemini kullanabilirsiniz. 

Bu C++ kodu, bir şeklin en boy oranını nasıl kilitleyeceğinizi gösterir:

```c++
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

Bu *Lock Aspect Ratio* ayarı yalnızca şeklin en boy oranını korur, içinde bulunan görüntünün oranını korumaz.

{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[IPictureFillFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_picture_fill_format) arayüzü ve [PictureFillFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format) sınıfından [StretchOffsetLeft](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) ve [StretchOffsetBottom](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) özelliklerini kullanarak bir doldurma dikdörtgeni belirtebilirsiniz. 

Bir görüntünün gerilmesi belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarından yüzde bazlı bir offset ile tanımlanır. Pozitif yüzde bir iç boşluk, negatif yüzde ise dışarı çıkma anlamına gelir.

1. Sunum sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slaydın referansını alın.
3. Bir `AutoShape` dikdörtgen ekleyin. 
4. Bir görüntü oluşturun.
5. Şeklin doldurma türünü ayarlayın.
6. Şeklin resim doldurma modunu ayarlayın.
7. Şekli doldurmak için bir görüntü ekleyin.
8. Şeklin sınırlayıcı kutusunun ilgili kenarından görüntü ofsetlerini belirtin
9. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C++ kodu, StretchOff özelliğinin kullanıldığı bir süreci gösterir:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Şekil gövdesinde görüntünün her taraftan gerilmesini ayarlar
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **SSS**

### Resim Çerçevesi için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) nesnesine atanan görüntü nesnesi aracılığıyla raster görüntüler (PNG, JPEG, BMP, GIF vb.) ve vektör görüntüler (örneğin SVG) destekler. Desteklenen formatların listesi genellikle slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.

### Birçok büyük görüntü eklemek PPTX boyutunu ve performansını nasıl etkiler?

Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntülere bağlantı vermek sunum boyutunu düşük tutmaya yardımcı olur ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için bağlantı yoluyla görüntü ekleme imkanı sunar.

### Bir görüntü nesnesinin yanlışlıkla taşınması/yeniden boyutlandırılmasını nasıl engelleyebilirim?

[Şekil kilitleri](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/get_pictureframelock/) ile bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) nesnesini (örneğin taşıma veya yeniden boyutlandırmayı devre dışı bırakma) kilitleyebilirsiniz. Kilitleme mekanizması, şekiller için ayrı bir [koruma makalesinde](/slides/tr/cpp/applying-protection-to-presentation/) açıklanmıştır ve çeşitli şekil türleri, özellikle [PictureFrame] için desteklenir.

### PDF/görüntülere dışa aktarırken SVG vektör bütünlüğü korunuyor mu?

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) içindeki SVG'yi orijinal vektör olarak çıkarabilir. PDF'ye ([buradan](/slides/tr/cpp/convert-powerpoint-to-pdf/)) veya raster formatlara ([buradan](/slides/tr/cpp/convert-powerpoint-to-png/)) dışa aktarırken, ayarlara bağlı olarak sonuç rasterleştirilebilir; orijinal SVG'nin vektör olarak saklandığı çıkarma davranışıyla doğrulanır.
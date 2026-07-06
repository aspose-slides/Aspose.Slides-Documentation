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
- göreli ölçek
- görüntü efekti
- en-boy oranı
- görüntü şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı kolaylaştırın ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Resim çerçevesi, bir görüntüyü içeren bir şekildir—çerçeve içinde bir resim gibidir. 

Bir slayta bir resim çerçevesi aracılığıyla görüntü ekleyebilirsiniz. Böylece, resmi resim çerçevesini biçimlendirerek biçimlendirebilirsiniz.

{{% alert  title="İpucu" color="primary" %}} 

Aspose, insanlara görüntülerden hızlı bir şekilde sunumlar oluşturma imkanı sağlayan ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sunmaktadır. 

{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Sunum sınıfının bir örneğini oluşturun.
2. İndeksi aracılığıyla bir slaydın referansını alın. 
3. Şekli doldurmak için kullanılacak sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_image_collection)'a bir görüntü ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_p_p_image) nesnesi oluşturun.
4. Görüntünün genişliğini ve yüksekliğini belirtin.
5. Referans alınan slayda bağlı şekil nesnesi tarafından sunulan `AddPictureFrame` yöntemiyle görüntünün genişliği ve yüksekliğine dayalı bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_frame) oluşturun.
6. Slayta bir resim çerçevesi (resmi içeren) ekleyin.
7. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Bu C++ kodu, bir resim çerçevesi nasıl oluşturulacağını gösterir:

```c++
// Belge dizinine giden yol.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// İstenen sunumu yükle
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Sunumun görüntü koleksiyonuna eklenecek görüntüyü yükler
// Resmi alır
auto image = Images::FromFile(filePath);

// Sunumun görüntü koleksiyonuna bir görüntü ekler
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Slayta bir resim çerçevesi ekler
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Göreli ölçek genişliğini ve yüksekliğini ayarlar
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// PictureFrame'e bazı biçimlendirmeler uygular
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//PPTX dosyasını diske yazar
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Resim çerçeveleri, görüntülere dayalı sunum slaytlarını hızlı bir şekilde oluşturmanızı sağlar. Resim çerçevesini Aspose.Slides kaydetme seçenekleriyle birleştirdiğinizde, görüntüleri bir formatta diğerine dönüştürmek için giriş/çıkış işlemlerini yönetebilirsiniz. Şu sayfalara göz atabilirsiniz: [image to JPG](https://products.aspose.com/slides/tr/cpp/conversion/image-to-jpg/) dönüştürme; [JPG to image](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-image/) dönüştürme; [JPG to PNG](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-png/) dönüştürme, [PNG to JPG](https://products.aspose.com/slides/tr/cpp/conversion/png-to-jpg/) dönüştürme; [PNG to SVG](https://products.aspose.com/slides/tr/cpp/conversion/png-to-svg/) dönüştürme, [SVG to PNG](https://products.aspose.com/slides/tr/cpp/conversion/svg-to-png/) dönüştürme.

{{% /alert %}}

## **Göreli Ölçekle Resim Çerçevesi Oluşturma**

Bir görüntünün göreli ölçeklendirmesini değiştirerek daha karmaşık bir resim çerçevesi oluşturabilirsiniz. 

1. Sunum sınıfının bir örneğini oluşturun.
2. İndeksi aracılığıyla bir slaydın referansını alın. 
3. Sunumun görüntü koleksiyonuna bir resim ekleyin.
4. Şekli doldurmak için kullanılacak sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_image_collection)'a bir görüntü ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_p_p_image) nesnesi oluşturun.
5. Resim çerçevesinde görüntünün göreli genişliğini ve yüksekliğini belirtin.
6. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Bu C++ kodu, göreli ölçekli bir resim çerçevesi nasıl oluşturulacağını gösterir:

```c++
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

// Sunumun görüntü koleksiyonuna bir görüntü ekler
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Slayta bir resim çerçevesi ekler
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Göreli ölçek genişliğini ve yüksekliğini ayarlar
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//PPTX dosyasını diske yazar
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Resim Çerçevelerinden Raster Görüntüleri Çıkarma**

[IPictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_frame) nesnelerinden raster görüntüler çıkarabilir ve PNG, JPG ve diğer formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, "sample.pptx" belgesinden bir görüntüyü çıkarıp PNG formatında kaydetmeyi göstermektedir.

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **Resim Çerçevelerinden SVG Görüntüleri Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) şekilleri içinde SVG grafikleri içerdiğinde, Aspose.Slides for C++ orijinal vektör görüntülerini tam doğrulukla almanıza olanak tanır. Slaydın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) öğesini belirleyebilir, altında bulunan [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) SVG içeriğine sahip mi kontrol edebilir ve ardından bu görüntüyü yerel SVG formatında diske ya da akışa kaydedebilirsiniz.

Aşağıdaki kod örneği, bir resim çerçevesinden SVG görüntüsü nasıl çıkarılacağını göstermektedir:

```cpp
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

## **Bir Görüntünün Şeffaflığını Alma**

Aspose.Slides, bir görüntüye uygulanan şeffaflık efektini almanıza izin verir. Bu C++ kodu işlemi göstermektedir:

```c++
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

{{% alert color="primary" %}} 
Görüntülere uygulanan tüm efektler [Aspose::Slides::Effects](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/) içinde bulunabilir.
{{% /alert %}}

## **Bir Görüntünün Parlaklık ve Kontrastını Alma**

Aspose.Slides, bir görüntüye uygulanan parlaklık ve kontrast efektini almanıza izin verir. [ILuminance](https://reference.aspose.com/slides/tr/cpp/aspose.slides.effects/iluminance/) arayüzü bu görüntü dönüşüm efektini temsil eder.

Bu C++ kodu, bir resim çerçevesinden parlaklık ve kontrast ayarlarını nasıl alacağınızı gösterir:

```c++
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

Aspose.Slides, bir resim çerçevesine uygulanabilen birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, belirli gereksinimlere uyması için bir resim çerçevesini değiştirebilirsiniz.

1. Sunum sınıfının bir örneğini oluşturun.
2. İndeksi aracılığıyla bir slaydın referansını alın. 
3. Şekli doldurmak için kullanılacak sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_image_collection)'a bir görüntü ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_p_p_image) nesnesi oluşturun.
4. Görüntünün genişliğini ve yüksekliğini belirtin.
5. Referans alınan slayda bağlı [IShapes](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape_collection) nesnesi tarafından sunulan [AddPictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) yöntemiyle görüntünün genişliği ve yüksekliğine dayalı bir `PictureFrame` oluşturun.
6. Resim çerçevesini (içindeki resimle birlikte) slayta ekleyin.
7. Resim çerçevesinin çizgi rengini ayarlayın.
8. Resim çerçevesinin çizgi kalınlığını ayarlayın.
9. Resim çerçevesini pozitif ya da negatif bir değer vererek döndürün.
   * Pozitif bir değer görüntüyü saat yönünde döndürür. 
   * Negatif bir değer görüntüyü saat yönünün tersine döndürür.
10. Resim çerçevesini (içindeki resimle birlikte) slayta ekleyin.
11. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Bu C++ kodu, resim çerçevesi biçimlendirme sürecini göstermektedir:

```c++
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

// Sunumun görüntü koleksiyonuna bir görüntü ekler
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Slayta bir resim çerçevesi ekler
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Göreli ölçek genişliğini ve yüksekliğini ayarlar
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//PPTX dosyasını diske yazar
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="İpucu" color="primary" %}}

Aspose, yakın zamanda ücretsiz bir [Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG veya PNG görüntülerini birleştirmeniz, fotoğraflardan ızgara oluşturmanız gerektiğinde bu hizmeti kullanabilirsiniz. 

{{% /alert %}}

## **Bir Görüntüyü Bağlantı Olarak Ekleme**

Sunum dosyalarının boyutunu büyük ölçüde azaltmak için, dosyaları doğrudan gömmek yerine bağlantılar üzerinden resim (veya video) ekleyebilirsiniz. Bu C++ kodu, bir yer tutucuya nasıl resim ve video ekleyeceğinizi gösterir:

```cpp
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

Bu C++ kodu, bir slayd üzerindeki mevcut bir resmi nasıl kırpacağınızı gösterir: 

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Yeni resim nesnesi oluşturur
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Slayta bir PictureFrame ekler
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Görüntüyü kırpar (yüzde değerleri)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Sonucu kaydeder
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bir Resmin Kırpılmış Alanlarını Silme**

Bir çerçeve içinde bulunan bir görüntünün kırpılmış alanlarını silmek istiyorsanız, [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) metodunu kullanabilirsiniz. Bu yöntem, kırpma gereksizse kırpılmış görüntüyü ya da orijinal görüntüyü döndürür.

Bu C++ kodu, işlemi göstermektedir: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// İlk slayttan PictureFrame'i alır
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// PictureFrame görüntüsünün kırpılmış alanlarını siler ve kırpılmış görüntüyü döndürür
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Sonucu kaydeder
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOT" color="warning" %}} 

[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) yöntemi, kırpılmış görüntüyü sunumun görüntü koleksiyonuna ekler. Görüntü sadece işlenen [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) içinde kullanılıyorsa, bu yapı sunum boyutunu azaltabilir. Aksi takdirde, sonuçtaki sunumdaki görüntü sayısı artar.

Bu yöntem, kırpma işlemi sırasında WMF/EMF metafilelerini raster PNG görüntüsüne dönüştürür. 

{{% /alert %}}

## **Görüntüleri Sıkıştırma**

Bir sunumdaki resmi, [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/compressimage/) yöntemiyle sıkıştırabilirsiniz.
Bu yöntem, şekil boyutuna ve belirtilen çözünürlüğe göre görüntünün boyutunu azaltarak sıkıştırır ve kırpılmış alanları silme seçeneği sunar.

Resmin boyut ve çözünürlüğünü PowerPoint'in **Picture Format → Compress Pictures → Resolution** özelliğine benzer şekilde ayarlar.

Aşağıdaki C++ örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki resmi nasıl sıkıştıracağınızı göstermektedir:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Görüntüyü 150 DPI (Web çözünürlüğü) hedef çözünürlük ile sıkıştır ve kırpılmış alanları kaldır.
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
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Görüntüyü 150 DPI (web çözünürlüğü) sıkıştırarak, kırpılmış alanları kaldır.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOT" color="warning" %}}

Yöntem, şeklin boyutu ve sağlanan DPI'ye göre görüntüyü daha düşük bir çözünürlüğe dönüştürür. Kırpılmış bölgeler de dosya boyutunu optimize etmek için silinebilir.
Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. Ayrıca JPEG kalitesi, çözünürlüğe bağlı olarak hafifçe düşebilir; bu, PowerPoint'in yüksek çözünürlüklü JPEG'leri nasıl ele aldığına benzer.

{{% /alert %}}

## **En-Boy Oranını Kilitleme**

Bir görüntü içeren bir şeklin, görüntü boyutları değiştirildiğinde bile en-boy oranını korumasını istiyorsanız, *Lock Aspect Ratio* ayarını ayarlamak için [set_AspectRatioLocked()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) yöntemini kullanabilirsiniz. 

Bu C++ kodu, bir şeklin en‑boy oranını nasıl kilitleyeceğinizi gösterir:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// Şeklin yeniden boyutlandırmada en-boy oranını korumasını ayarla
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOT" color="warning" %}} 

Bu *Lock Aspect Ratio* ayarı yalnızca şeklin en‑boy oranını korur, içinde bulunan görüntüyü değil.

{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[IPictureFillFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_picture_fill_format) arayüzü ve [PictureFillFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format) sınıfındaki [StretchOffsetLeft](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) ve [StretchOffsetBottom](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) özelliklerini kullanarak bir doldurma dikdörtgeni belirtebilirsiniz. 

Bir görüntünün uzatılması belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarından bir yüzde kaymasıyla tanımlanır. Pozitif bir yüzde içeri çekmeyi, negatif bir yüzde dışarı itmeyi gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
2. İndeksi aracılığıyla bir slaydın referansını alın.
3. Bir `AutoShape` dikdörtgeni ekleyin. 
4. Bir görüntü oluşturun.
5. Şeklin dolgu tipini ayarlayın.
6. Şeklin resim dolgu modunu ayarlayın.
7. Şekli dolduracak bir görüntü ekleyin.
8. Görüntü ofsetlerini şeklin sınırlayıcı kutusunun ilgili kenarına göre belirtin.
9. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Bu C++ kodu, StretchOff özelliğinin kullanıldığı bir süreci göstermektedir:

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Şekil gövdesinde görüntünün her taraftan gerildiğini ayarlar
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **SSS**

**PictureFrame için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?**

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) içine atanan görüntü nesnesi üzerinden raster görüntüler (PNG, JPEG, BMP, GIF vb.) ve vektör görüntüler (örneğin SVG) desteği sunar. Desteklenen formatların listesi genellikle slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.

**Yüzlerce büyük görüntü eklemek PPTX dosyasının boyutunu ve performansını nasıl etkiler?**

Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntülere bağlantı vermek sunum boyutunu düşük tutar ancak harici dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için bağlantı yoluyla resim ekleme imkanı sağlar.

**Bir görüntü nesnesini yanlışlıkla hareket ettirilmekten/yeniden boyutlandırılmaktan nasıl koruyabilirim?**

[PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) için [shape locks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/get_pictureframelock/) kullanın (örneğin hareketi veya yeniden boyutlandırmayı devre dışı bırakın). Kilitleme mekanizması, şekiller için ayrı bir [protection article](/slides/tr/cpp/applying-protection-to-presentation/) içinde açıklanmıştır ve [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) dahil çeşitli şekil tipleri için desteklenir.

**Bir sunumu PDF/görüntülere dışa aktarırken SVG vektör bütünlüğü korunur mu?**

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) içinden SVG'yi orijinal vektör olarak çıkarabilir. PDF'ye [/slides/tr/cpp/convert-powerpoint-to-pdf/] veya raster formatlara [/slides/tr/cpp/convert-powerpoint-to-png/] dışa aktarırken, sonuç ayarlara bağlı olarak rasterleştirilebilir; orijinal SVG'nin vektör olarak depolandığı çıkarım davranışıyla doğrulanır.
---
title: C++ Kullanarak Sunumlardaki Resim Çerçevelerini Yönetme
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
- en-boy oranı
- görüntü şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı basitleştirin ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Bir resim çerçevesi, bir görüntüyü içeren bir şekildir—çerçeve içindeki bir resim gibidir.

Bir resmi bir slayda, resim çerçevesi aracılığıyla ekleyebilirsiniz. Bu şekilde, resmi resim çerçevesini biçimlendirerek biçimlendirebilirsiniz.

{{% alert  title="Tip" color="primary" %}} 
Aspose, insanlara görüntülerden hızlı bir şekilde sunumlar oluşturma imkanı sağlayan ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sunmaktadır. 
{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Bir [Presentation sınıfı](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) örneği oluşturun.  
2. Bir slaydın referansını indeks aracılığıyla alın.  
3. Şekli doldurmak için kullanılacak, sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_image_collection)'a bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_p_p_image) nesnesi oluşturun.  
4. Resmin genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slayta bağlı şekil nesnesinin sunduğu `AddPictureFrame` yöntemiyle, resmin genişliği ve yüksekliğine dayalı bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_frame) oluşturun.  
6. Slayta bir resim çerçevesi (resmi içeren) ekleyin.  
7. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

Bu C++ kodu, bir resim çerçevesi nasıl oluşturulacağını gösterir:

```c++
// Belgeler dizinine giden yol.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// İstenen sunumu yükle.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir.
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Sunumun resim koleksiyonuna eklenecek resmi yükler.
// Resmi alır.
auto image = Images::FromFile(filePath);

// Resmi sunumun resim koleksiyonuna ekler.
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Slayta bir resim çerçevesi ekler.
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Göreceli ölçek genişlik ve yüksekliğini ayarlar.
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Resim çerçevesine bazı biçimlendirmeler uygular.
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//PPTX dosyasını diske yazar.
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
Resim çerçeveleri, görüntülere dayalı sunum slaytlarını hızlı bir şekilde oluşturmanızı sağlar. Resim çerçevesini Aspose.Slides'in kaydetme seçenekleriyle birleştirdiğinizde, görüntüleri bir formattan diğerine dönüştürmek için giriş/çıkış işlemlerini yönetebilirsiniz. Şu sayfalara göz atmak isteyebilirsiniz: convert [image to JPG](https://products.aspose.com/slides/tr/cpp/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/tr/cpp/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/tr/cpp/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/tr/cpp/conversion/svg-to-png/). 
{{% /alert %}}

## **Göreceli Ölçekli Resim Çerçevesi Oluşturma**

Bir görüntünün göreceli ölçeklemesini değiştirerek, daha karmaşık bir resim çerçevesi oluşturabilirsiniz. 

1. Bir [Presentation sınıfı](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) örneği oluşturun.  
2. Bir slaydın referansını indeks aracılığıyla alın.  
3. Sunumun resim koleksiyonuna bir resim ekleyin.  
4. Şekli doldurmak için kullanılacak, sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_image_collection)'a bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_p_p_image) nesnesi oluşturun.  
5. Resmin göreceli genişliğini ve yüksekliğini resim çerçevesinde belirtin.  
6. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

Bu C++ kodu, göreceli ölçekli bir resim çerçevesi nasıl oluşturulacağını gösterir:

```c++
// Belgeler dizinine giden yol.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// İstenen sunumu yükler
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Sunumun resim koleksiyonuna eklenecek görüntüyü yükler
// Görüntüyü alır
auto image = Images::FromFile(filePath);

// Görüntüyü sunumun resim koleksiyonuna ekler
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Slayta bir resim çerçevesi ekler
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Göreceli ölçek genişlik ve yüksekliğini ayarlar
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTX dosyasını diske yazar
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Resim Çerçevelerinden Raster Görüntü Çıkarma**

Raster görüntüleri, [PictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_frame) nesnelerinden çıkarabilir ve PNG, JPG ve diğer formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, "sample.pptx" belgesinden bir görüntüyü çıkarıp PNG formatında kaydetmeyi göstermektedir.

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

## **Resim Çerçevelerinden SVG Görüntü Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) şekilleri içinde yer alan SVG grafikler içerdiğinde, Aspose.Slides for C++ orijinal vektör görüntülerini tam doğrulukla almanıza olanak tanır. Slaydın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) nesnesini tanımlayabilir, altındaki [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) SVG içeriği barındırıyorsa bunu diske veya bir akıma, yerel SVG formatında kaydedebilirsiniz.

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

Aspose.Slides, bir görüntüye uygulanan şeffaflık etkisini almanıza olanak tanır. Bu C++ kodu işlemi göstermektedir:

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

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulanabilecek birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, bir resim çerçevesini belirli gereksinimlere uygun şekilde değiştirebilirsiniz.

1. Bir [Presentation sınıfı](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) örneği oluşturun.  
2. Bir slaydın referansını indeks aracılığıyla alın.  
3. Şekli doldurmak için kullanılacak, sunum nesnesine bağlı [IImagescollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_image_collection)'a bir resim ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_p_p_image) nesnesi oluşturun.  
4. Resmin genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slayta bağlı [IShapes](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape_collection) nesnesinin sunduğu [AddPictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) yöntemiyle, resmin genişliği ve yüksekliğine dayalı bir `PictureFrame` oluşturun.  
6. Resim çerçevesini (resmi içeren) slayta ekleyin.  
7. Resim çerçevesinin çizgi rengini ayarlayın.  
8. Resim çerçevesinin çizgi kalınlığını ayarlayın.  
9. Resim çerçevesini pozitif ya da negatif bir değer vererek döndürün.  
   * Pozitif bir değer, görüntüyü saat yönünde döndürür.  
   * Negatif bir değer, görüntüyü saat yönünün tersine döndürür.  
10. Resim çerçevesini (resmi içeren) slayta ekleyin.  
11. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

Bu C++ kodu, resim çerçevesi biçimlendirme sürecini göstermektedir:

```c++
// Belgeler dizinine giden yol.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// İstenen sunumu yükler
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Sunumun resim koleksiyonuna eklenecek görüntüyü yükler
// Görüntüyü alır
auto image = Images::FromFile(filePath);

// Görüntüyü sunumun resim koleksiyonuna ekler
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Slayta bir resim çerçevesi ekler
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Göreceli ölçek genişlik ve yüksekliğini ayarlar
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTX dosyasını diske yazar
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}

Aspose, yakın zamanda bir [free Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG ([merge JPG/JPEG](https://products.aspose.app/slides/tr/collage/jpg)) veya PNG görüntülerini birleştirmeniz ([create grids from photos](https://products.aspose.app/slides/tr/collage/photo-grid)) gerektiğinde bu hizmeti kullanabilirsiniz. 
{{% /alert %}}

## **Bir Görüntüyü Bağlantı Olarak Ekle**

Büyük sunum boyutlarından kaçınmak için, dosyaları doğrudan sunulara gömmek yerine bağlantılar aracılığıyla resim (veya video) ekleyebilirsiniz. Bu C++ kodu, bir yer tutucuya resim ve video nasıl ekleneceğini gösterir:

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

Bu C++ kodu, bir slaytta mevcut bir görüntüyü nasıl kırpacağınızı gösterir: 

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Yeni görüntü nesnesi oluşturur
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Bir slayta PictureFrame ekler
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

Bir çerçevede bulunan bir görüntünün kırpılmış alanlarını silmek istiyorsanız, [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) yöntemini kullanabilirsiniz. Bu yöntem, kırpma gereksizse kırpılmış görüntüyü veya orijinal görüntüyü döndürür.

Bu C++ kodu işlemi göstermektedir: 

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

{{% alert title="NOTE" color="warning" %}} 

[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) yöntemi, kırpılmış görüntüyü sunumun resim koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) içinde kullanılıyorsa, bu düzenleme sunum boyutunu azaltabilir. Aksi takdirde, sonuç sunumdaki resim sayısı artar.

Bu yöntem, kırpma işlemi sırasında WMF/EMF metafilelarını raster PNG görüntüsüne dönüştürür. 
{{% /alert %}}

## **Görüntüleri Sıkıştırma**

[IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/compressimage/) yöntemiyle bir sunumdaki resmi sıkıştırabilirsiniz. Bu yöntem, şekil boyutuna ve belirtilen çözünürlüğe göre görüntüyü küçülterek sıkıştırır; ayrıca kırpılmış alanları silme seçeneği sunar.

Boyut ve çözünürlük ayarı, PowerPoint'in **Picture Format -> Compress Pictures -> Resolution** özelliğine benzer şekilde çalışır.

Aşağıdaki C++ örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki görüntüyü nasıl sıkıştıracağınızı gösterir:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Görüntüyü 150 DPI (Web çözünürlüğü) hedef çözünürlüğüyle sıkıştır ve kırpılmış alanları kaldır.
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

// Görüntüyü 150 DPI (web çözünürlüğü) seviyesine sıkıştır, kırpılmış alanları kaldır.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}} 

Yöntem, şeklin boyutuna ve verilen DPI değerine göre görüntüyü daha düşük bir çözünürlüğe dönüştürür. Kırpılmış bölgeler de dosya boyutunu optimize etmek için silinebilir. Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. Ayrıca, JPEG kalitesi çözünürlüğe göre korunur veya hafifçe düşer; bu, PowerPoint'in yüksek çözünürlüklü JPEG'lerle başa çıkma şekline benzer. 
{{% /alert %}}

## **En-Boy Oranını Kilitleme**

Bir şeklin içinde bulunan görüntünün boyutlarını değiştirdikten sonra bile en-boy oranını korumasını istiyorsanız, *Lock Aspect Ratio* ayarını belirlemek için [set_AspectRatioLocked()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) yöntemini kullanabilirsiniz. 

Bu C++ kodu, bir şeklin en-boy oranını nasıl kilitleyeceğinizi gösterir:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// şeklin yeniden boyutlandırıldığında en-boy oranını korumasını ayarla
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

Bu *Lock Aspect Ratio* ayarı yalnızca şeklin en-boy oranını korur; içindeki görüntüyü korumaz. 
{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[IPictureFillFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_picture_fill_format) arayüzünden ve [PictureFillFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format) sınıfından [StretchOffsetLeft](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) ve [StretchOffsetBottom](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) özelliklerini kullanarak bir doldurma dikdörtgeni belirtebilirsiniz. 

Bir görüntünün uzatılması belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklenir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarından yüzde olarak bir ofsetle tanımlanır. Pozitif yüzde bir iç boşluk (inset) belirtirken, negatif yüzde bir dış boşluk (outset) belirtir. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı örneği oluşturun.  
2. Bir slaydın referansını indeks aracılığıyla alın.  
3. Bir `AutoShape` dikdörtgen ekleyin.  
4. Bir görüntü oluşturun.  
5. Şeklin doldurma tipini ayarlayın.  
6. Şeklin resim doldurma modunu ayarlayın.  
7. Şekli doldurmak için bir görüntü ekleyin.  
8. Görüntünün, şeklin sınırlayıcı kutusunun ilgili kenarından ofsetlerini belirtin  
9. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

Bu C++ kodu, StretchOff özelliğinin kullanıldığı bir süreci göstermektedir:

```cpp
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

**PictureFrame için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?**  
Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) nesnesine atanmış görüntü nesnesi aracılığıyla hem raster (PNG, JPEG, BMP, GIF vb.) hem de vektör (örneğin SVG) görüntüleri destekler. Desteklenen formatların listesi genellikle slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.  

**Onlarca büyük görüntü eklemek PPTX dosya boyutu ve performansını nasıl etkileyecek?**  
Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntülere bağlantı vermek sunum boyutunu düşük tutmaya yardımcı olur ancak dış dosyaların erişilebilir olması gerekir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı olarak ekleme olanağı sunar.  

**Bir görüntü nesnesini kazara hareket etmeye/yeniden boyutlandırmaya karşı nasıl kilitleyebilirim?**  
Bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) için [shape locks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/get_pictureframelock/) kullanabilirsiniz (örneğin hareketi veya yeniden boyutlandırmayı devre dışı bırakmak). Kilitleme mekanizması, şekiller için ayrı bir [koruma makalesinde](/slides/tr/cpp/applying-protection-to-presentation/) açıklanmıştır ve [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) dahil çeşitli şekil tipleri için desteklenir.  

**Bir sunumu PDF/görüntülere dışa aktarırken SVG vektör doğruluğu korunur mu?**  
Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) içindeki SVG'yi orijinal vektör olarak çıkarabilir. PDF'ye [/slides/tr/cpp/convert-powerpoint-to-pdf/] veya raster formatlara [/slides/tr/cpp/convert-powerpoint-to-png/] dışa aktarırken, ayarlara bağlı olarak sonuç rasterleşebilir; fakat çıkarma davranışı, orijinal SVG'nin vektör olarak saklandığını doğrular.
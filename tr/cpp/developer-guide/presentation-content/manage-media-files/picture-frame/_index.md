---
title: Presentasyonlarda Resim Çerçevelerini C++ ile Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/cpp/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- gömülü görüntü
- bağlantılı görüntü
- görüntü çıkar
- raster görüntü
- SVG görüntü
- görüntüyü kırp
- kırpılmış alanları sil
- görüntüyü sıkıştır
- StretchOffset
- resim çerçevesi biçimlendirme
- göreceli ölçek
- görüntü efekti
- en-boy oranı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile sunumlarda resim çerçevelerini oluşturma, biçimlendirme, bağlama, kırpma, çıkarma ve sıkıştırma."
---
## **Genel Bakış**

Bir resim çerçevesi, görüntüyü gösteren bir slayt şeklidir. Aspose.Slides içinde, görüntü kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) gömülü görüntü kaynaklarını [image collection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_images/) aracılığıyla sahip olur, bir [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) ise görüntünün konumunu, boyutunu, kenar biçimlendirmesini, dönüşünü, kırpmasını, resim efektlerini ve diğer çerçeve düzeyindeki ayarları kontrol eder.

Bu ayrım, aynı görüntünün birden çok kez gösterildiği durumlarda yararlıdır. Görüntüyü sunuma bir kez ekleyin, döndürülen [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) yi saklayın ve resim çerçeveleri oluştururken bu görüntü kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntülerin yanı sıra vektör SVG görüntülerini de içerebilir. Ayrıca görüntüyü sunuma gömmek yerine bağlantılı (linked) görüntülere de başvurabilirler. Seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu yüzden biçimlendirme veya optimizasyon uygulamadan önce görüntünün nasıl depolanacağına karar vermek faydalıdır.

## **Gömülü Bir Görüntü Ekle ve Biçimlendir**

Gömülü bir görüntü için, görüntü verisini sunuma ekleyin ve [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapecollection/addpictureframe/) ile bir resim çerçevesi oluşturun. Görüntü sunum paketinin bir parçası hâline gelir, bu yüzden sunum başka bir bilgisayara taşındığında bile kendine yeterli kalır.

Aşağıdaki örnek bir JPEG görüntüsü ekler, görüntünün yerel boyutlarında bir çerçeve oluşturur ve kenar biçimlendirmesi ile dönüş uygulamaktadır:

```cpp
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
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resim çerçevesi görüntülenen geometrinin kontrolünü sağlar; çerçeve boyutunun değiştirilmesi gömülü görüntü kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu fark, daha sonra görüntüyü kırpma veya sıkıştırma yaparken önem kazanır.

## **Göreceli Ölçeği Kullan**

[IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) çerçeve için göreceli genişlik ve yükseklik ölçeklendirmesini ortaya koyar. `1.0` değeri, orijinal resim boyutunun %100’üne karşılık gelir. Göreceli ölçek, bir iş akışının son boyutları manuel olarak hesaplamak yerine kaynak görüntü boyutuyla ilişkili kalmasını gerektirdiğinde yararlıdır.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Göreceli ölçek çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlantılı Görüntüler**

Gömülü bir resim, görüntü verisini sunum içinde depolar ve bu nedenle taşınabilirlik ve öngörülebilir render için en güvenli seçenektir. Bağlantılı bir resim ise [ISlidesPicture](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidespicture/) bağlantı yolu aracılığıyla dış bir konumu saklar; görüntü verisi aynı şekilde gömülmez.

Bağlantılı görüntüler PPTX içindeki veri miktarını azaltabilir, ancak dış bir bağımlılık getirir. Bağlantılı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir kalmalıdır. Yol değişirse, dosya taşınırsa veya kaynak kullanılamaz hâle gelirse, bağlantılı resim beklendiği gibi görüntülenmeyebilir. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamlarda render edilmesi gereken sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlantılı Bir Görüntü Ekle**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve yerel bir görüntü dosyasına işaret eder. Sadece görüntü bağlantılamayı ele alır; video bağlantısı ayrı bir medya iş akışıdır ve bu örneğe bilinçli olarak dahil edilmemiştir.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Dış dosya yönetimi amaçlanıyorsa bağlantıları kullanın. Sıkıştırmanın yerine sadece bir ikame olarak kullanmayın: kırık görüntü bağımlılıkları olan küçük bir PPTX, daha büyük kendi kendine yeten bir sunumdan genellikle daha az faydalıdır.

## **Resim Çerçevelerinden Görüntü Çıkar**

Mevcut bir sunumdan görüntü çıkarmadan önce, bir şeklin gerçekten bir [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) olup olmadığını ve gömülü bir görüntü içerdiğini kontrol edin. Bağlantılı resim çerçeveleri, aynı şekilde çıkarılabilecek görüntü baytlarını içermeyebilir.

### **Raster Görüntü Çıkar**

Modern görüntü API’si doğrudan [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

[IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) üzerinden kaydetmek, çıkarılan görüntüyü istenen çıktıya dönüştürür. Sunum içinde saklanan kodlanmış baytlara (dönüştürülmüş raster dosyası yerine) ihtiyacınız varsa, görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntü Çıkar**

SVG resmi için, [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) bir [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) nesnesi sunar. Böylece resmi rasterleştirmeden doğrudan SVG verisini alabilirsiniz.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
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

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarmalar bu vektör içeriği piksellere çevirir. PDF veya SVG slayt dışa aktarma da bir render işlemidir; dışa aktarılan grafik, orijinal gömülü SVG’nin bayt‑bayt kopyası olarak ele alınmamalıdır; orijinal vektör kaynağı gerektiğinde gömülü [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) verisi kullanılmalıdır.

## **Bir Görüntüyü Kırp**

Kırpma, bir görüntünün çerçeve içinde hangi kısmının görüneceğini değiştirir. [IPictureFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/) üzerindeki kırpma değerleri, kaynak görüntünün boyutlarının yüzdesi olarak verilir. Kırpma, gömülü görüntüden gizli pikselleri başlangıçta silmez; sadece görünür bölgeyi değiştirir.

Aşağıdaki örnek bir resim çerçevesini güvenli bir şekilde bulur ve kırpma değerlerini uygular:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Gizli görüntü verisi hâlâ mevcut olduğu için, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu daha önemliyse ve geri dönüşüm gerekmezse, kırpılmış bölgeler sonraki bölümde fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldır**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) mevcut kırpma dikdörtgeni dışındaki görüntü verisini siler ve sonuçta oluşan görüntü kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonraki bir kırpma geri alma işleminde bulunamaz.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

Yöntem sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü başka resim çerçeveleri tarafından da kullanılıyorsa, bu çerçevelerin hâlâ mevcut kaynaklara ihtiyacı olur; bu yüzden kırpılmış alanların silinmesi mutlaka toplam görüntü sayısını azaltmaz. WMF veya EMF içeriklerini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterleştirir.

## **Raster Görüntüleri Sıkıştır**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/compressimage/) raster görüntü çözünürlüğünü, resmin görüntülendiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Yöntem, görüntü yeniden boyutlandırıldıysa veya kırpıldıysa `true`, hiçbir değişiklik gerekmediyse `false` döndürür.

Standart bir hedef çözünürlük yeterli olduğunda, önceden tanımlı bir [PicturesCompression](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/picturescompression/) değeri kullanın:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Belirli bir hedef gerektiğinde enum değeri yerine pozitif bir DPI değeri özel olarak geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metafile içerikleri bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca düşük çözünürlük ve silinen kırpılmış bölgeler, optimize edilmiş sunumdan geri getirilemez. Hedef çözünürlüğü, görüntünün gerçek izlenme veya dışa aktarılma boyutuna göre seçin; tüm PPTX boyunca en düşük DPI’yı uygulamaktan kaçının.

## **Görüntü Efektlerini İncele**

Resim efektleri, çerçeve tarafından kullanılan resimde depolanır. Görüntü dönüşüm koleksiyonu, şeffaflık için sabit alfa modülasyonu ve parlaklık/kontrast için ışıklılık gibi efektler içerebilir. Aşağıdaki örnek, bir slayttaki ilk resim çerçevesinden her iki tür efekti de güvenli bir şekilde okur:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

Bu efektler, resmin çerçevede nasıl render edildiğini değiştirir; orijinal gömülü görüntü baytlarını yeniden yazarlar.

## **Resim Çerçevesi Geometrisini Kilitle**

[IPictureFrameLock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [aspect-ratio lock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) yeniden boyutlandırma sırasında şeklin oranlarını korur.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kilit, resim çerçevesi şekline uygulanır. Kaynak görüntünün aynı en-boy oranına yeniden örneklenmesini veya kalıcı olarak değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarla**

Resim doldurma modu stretch olduğunda, [IPictureFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzdeler bir kenardan içe doğru bir iç boşluk oluştururken, negatif yüzdeler dışa doğru bir çıkıntı oluşturur.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynaktan hangi kısmın görüneceğini seçerken; stretch offset’leri, görünür resim doldurmasının hangi dikdörtgene gerileceğini değiştirir.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Doldurma yerleşimi için stretch offset’leri kullanın. Kaynak görüntünün kenarlarını gizleme amacınız varsa kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Görüntü depolama ve resim‑çerçeve biçimlendirmesinin ayrı ayrı ele alındığı zaman temel dengelemeler daha kolay yönetilir:

- **Gömülü görüntüler** sunumu kendi içinde tutar ve paylaşım ve sunucu‑tarafı render için en güvenilir olandır; ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlantılı görüntüler** paketi daha küçük tutabilir, fakat sunum, belirtilen yollar veya konumlardaki dış dosyaların mevcut olmasına bağımlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene veya sıkıştırma sırasında kaldırılana kadar gömülü kalır.
- **Sıkıştırma**, aşırı büyük raster görüntüler için dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Kaydedilmeden önce slayt üzerindeki hedef boyut bilindiğinde uygulanmalıdır.
- **SVG görüntüler**, vektör korumasının önemli olduğu durumlarda SVG olarak tutulmalıdır. Vektör kaynağı gerektiğinde gömülü SVG doğrudan çıkarılabilir. Raster slayt dışa aktarmaları her zaman slaytı piksellere dönüştürür.
- **Tekrarlanan görüntüler**, aynı dosyayı tekrar‑tekrar yüklemek yerine mevcut bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) kaynağını yeniden kullanmalıdır.

Büyük sunumlarda, görüntü optimizasyonu genellikle seçici olarak yapıldığında daha etkilidir: logoları ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutlarına göre sıkıştırın, kırpılmış pikselleri yalnızca daha sonra düzenleme gerekmiyorsa kaldırın ve dış bağlantılardan kaçının, dış bağımlılık yönetimi dağıtım tasarımının bir parçası değilse.

## **SSS**

**Resim çerçevesi ile görüntü kaynağı arasındaki fark nedir?**

[IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) sunuma ait bir görüntü kaynağını temsil eder. [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) ise bir slaytta görüntüyü gösteren, çerçeve‑düzeyi geometri ve biçimlendirme (boyut, dönüş, kırpma değerleri, efektler, kilitler) saklayan bir şekildir.

**Görüntüleri gömmeli mi yoksa bağlamalı mı?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerekiyorsa görüntüleri gömün. Görüntü dosyalarını PPTX dışına tutmak ve dış konumların güvenilir bir şekilde korunabileceği durumlarda yalnızca bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden değil. Normal kırpma ayarları, kaynak görüntünün bir kısmını gizler fakat alttaki pikselleri tutar. Kırpılmış pikselleri kalıcı olarak silmek için [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) veya kırpma‑alanı kaldırma ile sıkıştırma kullanılmalıdır.

**Sıkıştırma sonrası görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma saklanan raster çözünürlüğü azaltır ve kırpılmış bölgelerin kaldırılması görüntü verisini yok eder. Daha sonraki yüksek‑çözünürlük düzenlemeleri gerekebileceği durumlarda orijinal kaynak görüntüyü sunum dışında tutun.

**SVG görüntüler nasıl ele alınmalı?**

Vektör bütünlüğünün önemli olduğu durumlarda SVG içeriğini SVG olarak tutun. Gömülü [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) doğrudan çıkarılabilir. PNG veya JPEG gibi raster formata bir slayt render edildiğinde SVG, slayt görüntüsünün bir parçası olarak piksellere rasterleştirilir.

**Mevcut slaytları okurken güvenli olmayan tip dönüşümlerinden nasıl kaçınırım?**

Resim‑çerçevesi‑özel üyeleri kullanmadan önce şekil tipini kontrol edin. Çalışma zamanında tip dönüşümü uygulamadan önce şekli [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) ile test edin ve tip dönüşüm sonucunu yerel bir değişkene atayın.
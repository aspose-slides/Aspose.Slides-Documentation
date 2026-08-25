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
- bağıl ölçek
- görüntü efekti
- en-boy oranı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile sunumlarda resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

Bir resim çerçevesi, bir resmi görüntüleyen slayt şeklidir. Aspose.Slides'ta, görüntü kaynağı ve onu görüntüleyen şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) kendi [görüntü koleksiyonu](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_images/) aracılığıyla gömülü görüntü kaynaklarını sahiplenirken, bir [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) görüntünün konumunu, boyutunu, çizgi biçimlendirmesini, döndürmesini, kırpmasını, resim efektlerini ve diğer çerçeve düzeyindeki ayarları kontrol eder.

Bu ayrım, aynı görüntünün birden fazla kez gösterildiği durumlarda yararlıdır. Görüntüyü sunuma bir kez ekleyin, döndürülen [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu görüntü kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntüleri ve SVG gibi vektör görüntüleri içerebilir. Ayrıca görüntü baytlarını sunuma depolamak yerine bağlantılı görüntülere de başvurabilirler. Bu seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce görüntünün nasıl depolanacağına karar vermek faydalıdır.

## **Gömülü Bir Görüntüyü Ekle ve Biçimlendir**

Gömülü bir görüntü için, görüntü verilerini sunuma ekleyin ve [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapecollection/addpictureframe/) ile bir resim çerçevesi oluşturun. Görüntü, sunum paketinin bir parçası haline gelir, böylece sunum başka bir bilgisayara taşındığında da bağımsız kalır.

Aşağıdaki örnek bir JPEG görüntüsü ekler, görüntünün yerel boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile döndürme uygular:

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

Resim çerçevesi görüntülenen geometriyi kontrol eder; çerçeve boyutunu değiştirmek gömülü görüntü kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra görüntüyü kırpma veya sıkıştırma yapıldığında önem kazanır.

## **Bağıl Ölçeği Kullan**

[IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) çerçeve için bağıl genişlik ve yükseklik ölçeklemesini sunar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Bağıl ölçek, bir iş akışının son boyutları manuel olarak hesaplamak yerine kaynak görüntü boyutuna bir ilişki koruması gerektiğinde kullanışlıdır.

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

Bağıl ölçek, çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örnekleme veya sıkıştırma yapmaz.

## **Gömülü ve Bağlantılı Görüntüler**

Gömülü bir resim, görüntü verilerini sunum içinde depolar ve bu yüzden taşınabilirlik ve öngörülebilir render için en güvenli seçenektir. Bağlantılı bir resim, aynı şekilde görüntü verilerini gömmek yerine [ISlidesPicture](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidespicture/) bağlantı yolu aracılığıyla harici bir konumu saklar.

Bağlantılı görüntüler PPTX içinde depolanan görüntü verisi miktarını azaltabilir, ancak dış bağımlılık getirir. Bağlantılı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak kullanılamaz olursa, bağlantılı resim beklendiği gibi görüntülenmeyebilir. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamda render edilmesi gereken sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlantılı Bir Görüntü Ekle**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve onu yerel bir görüntü dosyasına yönlendirir. Bu sadece görüntü bağlantısını gösterir; video bağlantısı ayrı bir medya iş akışıdır ve kasıtlı olarak bu örneğe karıştırılmamıştır.

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

Dış dosya yönetimi kasıtlıysa bağlantıları kullanın. Sıkıştırma yerine sadece bir yedekleme olarak kullanmayın: kırık görüntü bağımlılıklarına sahip küçük bir PPTX, genellikle daha büyük, bağımsız bir sunumdan daha az kullanışlıdır.

## **Resimleri Resim Çerçevelerinden Çıkar**

Mevcut bir sunumdan bir görüntüyü çıkarmadan önce, bir şeklin gerçekten bir [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) olduğu ve gömülü bir görüntü içerdiği doğrulanmalıdır. Bağlantılı resim çerçeveleri aynı şekilde çıkarılabilecek görüntü baytlarını içermeyebilir.

### **Raster Görüntü Çıkar**

Modern görüntü API'si doğrudan [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

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

[IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) üzerinden kaydetmek, çıkarılan görüntüyü istenen çıktı formatına dönüştürür. Sunumda saklanan kodlanmış baytlara ihtiyacınız varsa, dönüştürülmüş raster dosya yerine görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntü Çıkar**

SVG resmi için, [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) bir [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) nesnesi sunar. Bu sayede SVG verisini doğrudan alabilir, resmi önce rasterleştirmeniz gerekmez.

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

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarmalar bu vektör içeriği piksel olarak render eder. PDF veya SVG slayt dışa aktarması da bir render işlemi olduğundan, dışa aktarılan grafikler orijinal gömülü SVG'nin bayt‑bayt kopyası olarak görülmemelidir; orijinal vektör kaynağı gerektiğinde gömülü [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) verisi kullanılmalıdır.

## **Bir Görüntüyü Kırp**

Kırpma, çerçeve içinde görüntünün hangi kısmının görüneceğini değiştirir. [IPictureFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/) üzerindeki kırpma değerleri, kaynak görüntü boyutlarının yüzdesidir. Kırpma, gömülü görüntüden gizli pikselleri başlangıçta silmez; sadece görünür bölgeyi değiştirir.

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

Gizli görüntü verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu, geri dönüşümden daha çok bir sorun ise, sonraki bölümde açıklanan şekilde kırpılmış bölgeler fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldır**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) mevcut kırpma dikdörtgeni dışındaki görüntü verisini kaldırır ve sonuçtaki görüntü kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonraki bir kırpmayı geri alma işlemi için mevcut değildir.

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

Bu yöntem sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü diğer resim çerçeveleri tarafından da kullanılıyorsa, bu çerçeveler hâlâ mevcut kaynaklarını gerektirir; bu nedenle kırpılmış bölgelerin silinmesi toplam görüntü sayısını mutlaka azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG'ye rasterleştirir.

## **Raster Görüntüleri Sıkıştır**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/compressimage/) raster görüntü çözünürlüğünü, resmin görüntülendiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Yöntem, resim yeniden boyutlandırıldıysa veya kırpıldıysa `true`, hiçbir değişiklik gerekmediyse `false` döndürür.

Standart bir hedef çözünürlük yeterli olduğunda önceden tanımlanmış bir [PicturesCompression](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/picturescompression/) değeri kullanın:

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

Belirli bir hedef gerektiğinde bir enum değeri yerine özel pozitif DPI değeri de geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metafile içeriği bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca düşük çözünürlük ve silinmiş kırpılmış bölgelerin optimize edilmiş sunumdan geri getirilemeyeceğini unutmayın. Hedef çözünürlüğü, görüntünün gerçekte görüntülenecek veya dışa aktarılacak en büyük boyutuna göre seçin; küresel olarak en düşük DPI'yı uygulamaktan kaçının.

## **Görüntü Dönüşüm Efektlerini Yönet**

Parlaklık, kontrast, renk dönüşümleri, bulanıklaştırma, alfa efektleri, sıralı zincirler, denetleme, kaldırma ve çift yönlü doğrulama gibi tam bir iş akışı için [Image Transform Effects](/slides/tr/cpp/image-transform-effects/) bölümüne bakın.

## **Resim Çerçevesi Geometrisini Kilitle**

[IPictureFrameLock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakıldığını kontrol eder. Örneğin, [aspect-ratio lock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) yeniden boyutlandırma sırasında şeklin oranını korur.

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

Kilitleme, resim çerçevesi şekline uygulanır. Kaynak görüntünün aynı en boy oranına yeniden örneklenmesini veya kalıcı olarak değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarla**

Resim doldurma modu stretch olduğunda, [IPictureFillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri bir kenardan içe doğru bir boşluk oluştururken, negatif yüzde değerleri dışa doğru bir genişleme yapar.

Bu, kırpmadan farklıdır. Kırpma değerleri kaynak görüntünün hangi kısmının görüneceğini seçerken, stretch offsetler görüntünün uzatılacağı dikdörtgeni değiştirir.

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

Doldurma yerleştirmesi için stretch offsetleri kullanın. Kaynak görüntünün kenarlarını gizlemek istiyorsanız kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Görüntü depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında temel tavizler yönetimi daha kolaydır:

- **Gömülü görüntüler** sunumu bağımsız hâle getirir ve paylaşım ve sunucu tarafı render için en güvenilir olandır, ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlantılı görüntüler** paketi daha küçük tutabilir, ancak sunumun dış dosyaların belirtilen yollar veya konumlarda mevcut olmasına bağımlı olmasını gerektirir.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene veya sıkıştırma sırasında kaldırılıncaya kadar gömülü kalır.
- **Sıkıştırma**, aşırı büyük raster görüntüler için dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Slayt üzerindeki hedef boyut bilindikten sonra uygulanmalıdır.
- **SVG görüntüler**, vektör korumasının önemli olduğu durumlarda SVG olarak kalmalıdır. Vektör kaynağı gerektiğinde gömülü SVG doğrudan çıkarılabilir. Raster slayt dışa aktarmaları her zaman render edilen slaytı piksele dönüştürür.
- **Tekrarlanan görüntüler**, mümkün olduğunda aynı [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) kaynağını yeniden kullanmalı, aynı dosyayı sunuma defalarca yüklemekten kaçınmalıdır.

Büyük sunumlar için görüntü optimizasyonu genellikle seçici olarak yapıldığında en etkilidir: logoları ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutuna göre sıkıştırın, kırpılmış pikselleri yalnızca daha sonra düzenleme gerekmiyorsa kaldırın ve dış bağlantıları yalnızca bağımlılık yönetimi dağıtım tasarımının bir parçasıysa kullanın.

## **SSS**

**Bir resim çerçevesi ile bir görüntü kaynağı arasındaki fark nedir?**

[IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) sunuma bağlı bir görüntü kaynağını temsil eder. [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) bir slayttaki şekildir ve bir görüntüyü gösterir; çerçeve‑seviyesinde boyut, döndürme, kırpma değerleri, efektler ve kilitlemeler gibi biçimlendirmeleri depolar.

**Görüntüleri gömmeli miyim yoksa bağlamalı mı?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklar olmadan render edilmesi gerekiyorsa görüntüleri gömün. Görüntü dosyalarını PPTX dışına tutmak ve dış konumların güvenilir şekilde yönetilebileceği durumlarda yalnızca bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Tek başına azaltmaz. Normal kırpma ayarları, kaynak görüntünün parçalarını gizler ancak altındaki pikselleri tutar. Kırpılmış bölgeleri tamamen kaldırmak için [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) veya kırpılmış alan kaldırma içeren görüntü sıkıştırmasını kullanın.

**Sıkıştırmadan sonra görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma depolanan raster çözünürlüğü düşürebilir ve kırpılmış bölgelerin kaldırılması görüntü verisini yok eder. Daha sonra yüksek çözünürlüklü düzenleme gerekebileceği durumlarda orijinal kaynak görüntüyü sunum dışında tutun.

**SVG görüntüler nasıl ele alınmalı?**

Vektör bütünlüğünün önemsediği durumlarda SVG içeriğini SVG olarak tutun; gömülü [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) doğrudan çıkarılabilir. PNG veya JPEG gibi raster formatlara slayt render edildiğinde SVG piksele rasterleştirilir.

**Mevcut slaytları okurken güvenli olmayan tip dönüşümlerinden nasıl kaçınılır?**

Resim‑çerçeve‑özel üyeleri kullanmadan önce şekil tipini kontrol edin. [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) ile denetleyin, ardından çalışma zamanında tip dönüşümünü uygulayın ve dönüşüm sonucunu yerel bir değişkende tutarak çerçeve‑özel üyelere erişin.
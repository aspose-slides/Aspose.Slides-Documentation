---
title: C++ Kullanarak Sunumlarda Görüntü Yönetimini Optimize Etme
linktitle: Görüntüleri Yönet
type: docs
weight: 10
url: /tr/cpp/image/
keywords:
- görüntü ekle
- resim ekle
- görüntüyü değiştir
- görüntü koleksiyonu
- resim çerçevesi
- bağlantılı görüntü
- arka plan
- PNG ekle
- JPG ekle
- SVG ekle
- SVG'yi şekillere dönüştür
- harici SVG kaynakları
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument sunumlarında raster ve SVG görüntülerini ekleme, yeniden kullanma, bağlama, değiştirme ve yönetme konusunda bilgi edinin."
---
## **Giriş**

Aspose.Slides for C++ görüntülerle çalışmanın birkaç yolunu sunar ve her biri farklı bir amaca hizmet eder. Bir görüntüyü sunuma depolayabilir, bir resim çerçevesinde görüntüleyebilir, slayt arka planı olarak kullanabilir, harici bir görüntüye bağlanabilir, paylaşılan bir görüntü kaynağını değiştirebilir veya SVG içeriğini düzenlenebilir şekillere dönüştürebilirsiniz.

Bu makale görüntü kaynaklarına ve bir sunum boyunca nasıl kullanıldıklarına odaklanır. Kırpma, şeffaflık, efektler, genişletme ve bireysel bir resim çerçevesine uygulanan diğer biçimlendirmeler için [Resim Çerçevesi](/slides/tr/cpp/picture-frame/) bölümüne bakın.

## **Görüntü Modelini Anlama**

Aşağıdaki API kavramları yakından ilişkilidir ancak birbirinin yerine kullanılamaz:

- [sunum görüntü koleksiyonu](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimagecollection/) sunum tarafından kullanılan görüntü kaynaklarını depolar. Görüntü verilerini eklemek ve bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) kaynağı elde etmek için [IImageCollection::AddImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimagecollection/addimage/) kullanın.
- [resim çerçevesi](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) bir slayt, düzen veya ana sayfada görüntüyü gösteren bir şekildir. Bir görüntü kaynağını slayta yerleştirmek için [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addpictureframe/) kullanın.
- bir slayt arka planı, görüntüyü bir şekil olarak değil, slayt doldurmasının bir parçası olarak kullanır. Bu nedenle bir resim çerçevesi gibi davranmaz.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/replaceimage/) bir görüntü kaynağını değiştirir. Bu kaynağı kullanan birden çok sunum öğesi varsa, hepsi değişikliği kullanır.
- SVG'yi şekillere dönüştürmek, düzenlenebilir slayt şekilleri oluşturur. Dönüştürmeden sonra içerik artık tek bir resim kaynağı olarak yönetilmez.

Tipik bir iş akışı şu şekildedir: görüntü verilerini görüntü koleksiyonuna ekleyin, bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) alın ve ardından bu kaynağı bir veya daha fazla resim çerçevesi veya doldurmalarda kullanın.

## **Gömülü Görüntü Ekleme**

Yerel bir görüntüyü eklemek için dosyayı okuyun, verilerini görüntü koleksiyonuna ekleyin ve dönen [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) kaynağını kullanan bir resim çerçevesi oluşturun.

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

Bu şekilde eklenen görüntü sunuma gömülür, böylece ortaya çıkan dosya orijinal görüntü dosyasının hâlâ mevcut olmasına bağlı olmaz.

### **Web'den Görüntü Ekleme**

Bir görüntü HTTP veya HTTPS üzerinden kullanılabilir olduğunda, baytlarını indirin, onları sunum görüntü koleksiyonuna ekleyin ve dönen görüntü kaynağını yerel bir görüntü gibi aynı şekilde kullanın.

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

Kaynak güvenilir olmadığında uzak URL'leri, yanıt boyutlarını ve içerik türlerini doğrulayın. Başka bir HTTP istemcisi zaten kullanılan uygulamalarda, resmi o istemciyle indirebilir ve elde edilen baytları veya akışı [IImageCollection::AddImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimagecollection/addimage/) metoduna geçirebilirsiniz.

## **Slaytlar Arasında Görüntüleri Yeniden Kullanma**

Aynı görüntü birden fazla kez gerektiğinde, görüntüyü sunuma bir kez ekleyin ve ek resim çerçeveleri oluştururken dönen [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) kullanın. Bu, aynı kaynak verisinin tekrar tekrar yüklenmesini önler ve paylaşılan görüntü kaynağı ile kullanımları arasındaki ilişkiyi açıkça gösterir.

Birçok slaytta otomatik olarak görünmesi gereken grafikler (ör. şirket logosu) için, her slayda eşdeğer bir şekil eklemek yerine resmi bir [slayt ana sayfası](/slides/tr/cpp/slide-master/) veya düzene yerleştirmeyi düşünün.

## **Görüntüyü Slayt Arka Planı Olarak Kullanma**

Bir arka plan resmi slayt doldurmasına atanır; bir resim çerçevesi şekli olarak eklenmez. Bu, resmin slayt arka planını kaplaması ve normal bir slayt nesnesi gibi manipüle edilmemesi gerektiğinde kullanışlıdır.

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

Ek arka plan seçenekleri için, ana sayfa ve düzen arka planları dahil, [Sunum Arka Planı](/slides/tr/cpp/presentation-background/) bölümüne bakın.

## **Gömülü Görüntüler ve Bağlantılı Görüntüler**

Gömülü ve bağlantılı görüntülerin taşınabilirlik ve dosya boyutu açısından farklı ticaret-offları vardır:

- **Gömülü görüntü:** görüntü verileri sunum içinde depolanır. Sunum kendi içinde tamdır, ancak dosya boyutu görüntü verilerini içerir.
- **Bağlantılı görüntü:** sunum harici bir görüntüye yol veya URL saklar. Bu, sunum boyutunu azaltabilir, ancak harici kaynağın sunum açıldığında veya render edildiğinde erişilebilir olması gerekir.

Bir bağlantılı resim, görüntü verisini gömmek yerine [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidespicture/set_linkpathlong/) aracılığıyla harici yol veya URL'yi atayarak oluşturulabilir.

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

Bağlantılı görüntüleri yalnızca dağıtım ortamı harici kaynağa güvenilir bir şekilde erişebildiğinde kullanın. Çevrimdışı çalışması veya sistemler arasında taşınması gereken sunumlar için gömülü görüntüler genellikle daha güvenlidir.

## **SVG Görüntülerle Çalışma**

SVG bir vektör formatıdır; bu nedenle simgeler, diyagramlar ve raster görüntülerdeki ayrıntı kaybı olmadan ölçeklenmesi gereken diğer grafikler için yararlı olabilir. Aspose.Slides, SVG'yi hem bir görüntü kaynağı hem de düzenlenebilir slayt şekilleri için bir kaynak olarak destekler.

### **SVG'yi Görüntü Olarak Ekleme**

Bir [SvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/svgimage/) oluşturun, bunu görüntü koleksiyonuna ekleyin ve ortaya çıkan görüntü kaynağını bir resim çerçevesine yerleştirin.

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

### **Harici Kaynaklı SVG Dosyaları**

Bir SVG harici görüntüler, stil sayfaları veya yazı tiplerine başvurabilir. Bu durumlar için [SvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/svgimage/) bir [IExternalResourceResolver](https://reference.aspose.com/slides/tr/cpp/aspose.slides.import/iexternalresourceresolver/) ve bir temel URI kabul eden kurucular sağlar. Çözücü, göreli bir URI'yi izin verilen mutlak bir URI'ye eşleyebilir ve istenen kaynak için bir akış döndürebilir.

Çözücü, SVG işlenirken harici kaynakların kullanılabilir olmasını sağlar, ancak SVG'yi kendi içinde bütün bir belgeye dönüştürmez. SVG'nin taşınabilir kalması gerekiyorsa, gerekli kaynakları SVG içinde gömün; örneğin bağlanmış görüntüler için `data:` URI'lerini kullanabilirsiniz.

Güvenilmeyen kaynaklardan gelen SVG dosyaları için, çözücünün erişebileceği şema, dosya konumu ve ana bilgisayarları sınırlayın. Ağ çözücülerinin ayrıca zaman aşımı, yanıt boyutu limitleri ve içerik doğrulaması uygulaması gerekir.

### **SVG'yi Düzenlenebilir Şekillere Dönüştürme**

Aspose.Slides, bir SVG'yi düzenlenebilir slayt şekilleri grubuna dönüştürebilir; bu, karşılık gelen PowerPoint komutuna benzer.

![PowerPoint Popup Menu](img_01_01.png)

Dönüştürmeyi gerçekleştirmek için bir [ISvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/) kabul eden [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addgroupshape/) aşırı yüklemesini kullanın.

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

SVG'den şekillere dönüşümü, bireysel vektör öğelerinin PowerPoint şekilleri olarak düzenlenmesi gerektiğinde kullanın. SVG yalnızca görüntülenmesi gerekiyorsa, görüntü olarak tutmak daha basittir ve birçok ayrı şekil oluşturmayı önler.

## **Mevcut Bir Görüntü Kaynağını Değiştirme**

Mevcut bir görüntü kaynağını değiştirmek istediğinizde [IPPImage::ReplaceImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/replaceimage/) kullanın. Bu, logolar gibi paylaşılan grafikler için özellikle kullanışlıdır.

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

Birden çok resim çerçevesi, arka plan, ana sayfa veya düzen aynı görüntü kaynağını kullanıyorsa, bu kaynağı değiştirmek tüm kullanım noktalarını günceller. Sadece bir resim çerçevesinin değişmesi gerekiyorsa, paylaşılan kaynağı değiştirmek yerine o çerçeveye farklı bir görüntü atayın.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/replaceimage/) ayrıca bir [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) veya başka bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) kabul eden aşırı yüklemeler sunar.

## **Uygulamalı Görüntü Yönetimi Rehberi**

### **Sunum Boyutunu Kontrol Etme**

Büyük raster görüntüler sunumu gereksiz yere büyütebilir. Görüntüleri hedef gösterim boyutuna uygun boyutlarda kullanın, mümkün olduğunca paylaşılan görüntü kaynaklarını yeniden kullanın ve aynı yüksek çözünürlüklü grafiğin tekrarlanan kopyalarını gömmekten kaçının.

Resim çerçevelerine yerleştirilmiş raster resimler için, [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipicturefillformat/compressimage/) seçilen çözünürlük ve kırpma ayarlarına göre görüntü verisini azaltabilir. Bu, görüntü koleksiyonu yönetimi yerine resim çerçevesi işleme olduğundan, ilgili biçimlendirme işlemleri için [Resim Çerçevesi](/slides/tr/cpp/picture-frame/) bölümüne bakın.

### **Gömülü ve Bağlantılı İçerik Arasındaki Seçim**

Gömme, tüm gerekli görüntü verileri dosyayla birlikte hareket ettiği için sunumu taşınabilir kılar. Bağlantı dosya boyutunu azaltabilir, ancak harici bir bağımlılık getirir. Bağlantıyı yalnızca bu bağımlılığın kabul edilebilir ve istikrarlı olduğu durumlarda kullanın.

### **Paylaşılan Marka Kimliğini Yeniden Kullanma**

Tekrarlanan logolar, filigranlar veya dekoratif grafikler için tek bir görüntü kaynağı kullanın ve yeniden kullanın. Grafik, slayt içeriği yerine sunum tasarımına aitse, uygun slaytlar tarafından devralınması için bir ana sayfa veya düzene yerleştirin.

### **SVG Kaynaklarını Taşınabilir Tutma**

Kendi içinde bütün bir SVG, harici dosyalara veya ağ kaynaklarına bağlı bir SVG'den daha kolay taşınır ve tutarlı render edilir. Mümkün olduğunda, SVG'yi içe aktarmadan önce gerekli kaynakları gömün. SVG'yi yalnızca bireysel vektör öğelerinin düzenlenmesi gerektiğinde şekillere dönüştürün.

### **Aspose.Slides Görüntü API'sini Kullanma**

C++ görüntü iş akışları için, bir görüntü nesnesine ihtiyacınız olduğunda Aspose.Slides [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) ve [Images](https://reference.aspose.com/slides/tr/cpp/aspose.slides/images/) API'lerini, bir görüntü verisini sunum kaynağı olarak kaydetmeniz gerektiğinde ise [IImageCollection::AddImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimagecollection/addimage/) kullanın. Koleksiyon aşırı yüklemeleri ayrıca bayt dizileri ve akışları destekler; bu, görüntü verileri dosyalardan, ağ istemcilerinden, veritabanlarından veya diğer kütüphanelerden geldiğinde yararlıdır.

Elektronik tablolar veya başka bir üründen EMF içeriği üretmek ayrı bir bütünleşme iş akışıdır ve bu makalenin kapsamı dışındadır. Mevcut bir WMF veya EMF dosyasının yalnızca bir sunuma eklenmesi gerekiyorsa, görüntü yönetimi iş akışına ikinci bir ürün bağımlılığı eklemeden uygun bir [IImageCollection::AddImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimagecollection/addimage/) aşırı yüklemesine verisini gönderin.

## **SSS**

**Görüntü koleksiyonu ile bir resim çerçevesi arasındaki fark nedir?**

Görüntü koleksiyonu yeniden kullanılabilir görüntü kaynaklarını depolar. Bir resim çerçevesi, bu kaynaklardan birini gösteren bir slayt şeklidir ve kırpma, efektler gibi resim‑özel biçimlendirmeler sunar.

**Aynı logoyu her yerde değiştirmek için en iyi yol nedir?**

Logo zaten tek bir görüntü kaynağı olarak paylaşılıyorsa, bu kaynağı [IPPImage::ReplaceImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/replaceimage/) ile değiştirin. Sunum çapında marka kimliği için logoyu bir ana sayfa veya düzene koymak da yinelenen slayt içeriğini azaltabilir.

**Bağlantılı bir görüntü başka bir bilgisayarda neden kaybolur?**

Bağlantılı resim dış dosya veya URL'ye bağlıdır. Bu kaynak diğer bilgisayardan erişilemezse, bağlantılı görüntü mevcut olmayabilir. Sunumun kendi içinde olması gerekiyorsa görüntüyü gömün.

**Eklenen bir SVG PowerPoint şekilleri olarak düzenlenebilir mi?**

Evet. SVG'yi [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addgroupshape/) ile dönüştürün; ortaya çıkan grup tek bir SVG resmi yerine düzenlenebilir slayt şekilleri içerir.

**Birçok görüntülü sunumları nasıl daha küçük tutabilirim?**

Paylaşılan görüntü kaynaklarını yeniden kullanın, gereksiz yere büyük raster kaynaklardan kaçının, uygun olduğunda raster resimleri sıkıştırın, tekrarlanan marka öğelerini ana sayfalara veya düzenlere koyun ve bağlantılı görüntüleri yalnızca harici bağımlılık kabul edilebilir olduğunda kullanın.
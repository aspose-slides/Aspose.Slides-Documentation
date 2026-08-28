---
title: C++ ile Sunum Slaytlarını Görüntülere Dönüştürme
linktitle: Slayttan Görüntüye
type: docs
weight: 41
url: /tr/cpp/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slayttan görüntüye
- slaytı görüntü olarak kaydet
- slayttan EMF
- slayttan PNG
- slayttan JPEG
- slayttan bitmap
- slayttan TIFF
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "PPT, PPTX ve ODP sunumlarından slaytları PNG, JPEG, GIF, TIFF, EMF ve diğer görüntü formatlarına C++ içinde Aspose.Slides for C++ ile dönüştürün."
---
## **Giriş**

Aspose.Slides for C++ PowerPoint ve OpenDocument sunumlarından tek tek slaytları PNG, JPEG, GIF, TIFF ve diğer görüntü formatları olarak oluşturabilir.

Bir slaytı görüntüye dönüştürmek için aşağıdaki adımları izleyin:

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı ile yükleyin.
2. Oluşturmak istediğiniz slaytı seçin.
3. Gerekirse, renderlemeyi [RenderingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/renderingoptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/) sınıfı ile yapılandırın.
4. Çağırın [ISlide::GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage/) metodunu. Bu metod bir [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) nesnesi döndürür.
5. [IImage::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/save/) metodunu çağırın ve çıkış formatını bir [ImageFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imageformat/) değeri ile belirtin.

## **Bir Slaytı PNG Görüntüsüne Dönüştürme**

En basit dönüşüm, varsayılan renderleme ayarlarını kullanır. Oluşan [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) nesnesi bellek içinde işlenebilir veya bir dosyaya kaydedilebilir.

Aşağıdaki C++ örneği ilk slaytı oluşturur ve PNG görüntüsü olarak kaydeder:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Özel Boyutlarla Slaytları Görüntülere Dönüştürme**

[ISlide::GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage/) aşırı yüklemesini, tam piksel boyutlarıyla bir slaytı oluşturmak için [Size](https://reference.aspose.com/slides/tr/cpp/system.drawing/size/) değerini kabul eden sürümünü kullanın.

Aşağıdaki örnek 1820 × 1040 JPEG görüntüsü oluşturur:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Notlar ve Yorumlarla Slaytları Görüntülere Dönüştürme**

Varsayılan olarak, slayt görüntüleri notları veya yorumları içermez. Notların ve yorumların nerede görüneceğini kontrol etmek için bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/) nesnesini [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) metoduna atayın.

Aşağıdaki örnek, kırpılmış notları slaytın altına ve yorumları sağına yerleştirir:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
Slaytı-görüntüye dönüştürme için, [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) metodunu [BottomFull](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notespositions/) olarak ayarlamayın. Notlar, sabit görüntü boyutunun alabileceğinden daha fazla metin içerebilir. Bunun yerine [BottomTruncated](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notespositions/) kullanın.
{{% /alert %}}

## **TIFF Seçenekleri Kullanarak Slaytları Görüntülere Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/) sınıfı, oluşturulan TIFF görüntüsünün boyutunu, çözünürlüğünü ve diğer özelliklerini kontrol etmenizi sağlar.

Aşağıdaki örnek ilk slaytı 300 DPI'de 2160 × 2880 TIFF görüntüsü olarak oluşturur:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Tüm Slaytları Görüntülere Dönüştürme**

Tüm sunumu bir dizi görüntüye dönüştürmek için slayt koleksiyonunu döngüye alın. Gizli slaytlar, açıkça atlamadığınız sürece dahil edilir.

Aşağıdaki örnek, her slaytı yatay ve dikey ölçek faktörleri 2 olan JPEG görüntüsü olarak oluşturur:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Gelişmiş Metafayl Çıktısı Oluşturma**

Gelişmiş Metafayl (EMF), vektör tabanlı grafiklerin Microsoft Office veya Windows metafayllarını destekleyen diğer Windows uygulamalarıyla değiş tokuş edilmesi gerektiğinde kullanışlıdır. Piksel tabanlı bir görüntünün aksine, EMF vektör çizim işlemlerini koruyabilir ve ölçeklendiğinde aynı netlik kaybını yaşamaz. Ancak EMF, öncelikle Windows metafayl desteği olan uygulamalar için bir uyumluluk formatıdır, evrensel bir değişim formatı değildir. Ayrıca, bitmap görüntüler ve bazı efektler gibi karmaşık slayt içeriği, vektör metafayl kapsayıcısı içinde rasterleştirilmiş öğeler olarak saklanabilir.

### **Bir Slaytı EMF Olarak Dışa Aktarma**

[ISlide::WriteAsEmf](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/writeasemf/) metodu bir [ISlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/) nesnesini hedef akışa EMF formatında yazar. Aşağıdaki örnek bir sunumu yükler, ilk slaytı seçer ve bir EMF dosya akışına yazar:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

Çağıran, [ISlide::WriteAsEmf](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/writeasemf/) metoduna geçirilen akışa sahiptir ve onu kapatmalı veya yok etmelidir. Aspose.Slides, akışın mevcut konumunda yazar ve akışı açık bırakır.

### **Bir SVG Görüntüsünü EMF'ye Dönüştürme ve Sunuma Ekleme**

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/writeasemf/) yöntemini kullanarak SVG içeriğini EMF'ye dönüştürün. Oluşan baytlar, [IImageCollection::AddImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimagecollection/addimage/) aracılığıyla sunuma eklenebilir ve bir slayta [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addpictureframe/) ile yerleştirilebilir.

Aşağıdaki örnek SVG işaretlemesinden bir [SvgImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/svgimage/) oluşturur, bellekte bir EMF'ye dönüştürür, metafaylı ilk slayta ekler ve sunumu kaydeder:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isvgimage/writeasemf/) hedef akışın sahipliğini almaz. Yazdıktan sonra, akış konumu oluşturulan verinin sonunda olur. Örnek, akışın mevcut konumundan bağımsız olarak tam tamponu elde etmek için [MemoryStream::ToArray](https://reference.aspose.com/slides/tr/cpp/system.io/memorystream/toarray/) metodunu çağırır, ardından bu bayt dizisini [IImageCollection::AddImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimagecollection/addimage/) metoduna geçirir. Akışı, tüketici okumasını tamamlayana kadar açık tutun ve ardından kapatın.

EMF oluşturma, Aspose.Slides for C++ tarafından desteklenen işletim sistemlerinde mevcuttur, ancak yazı tipleri veya yerel grafik bağımlılıkları bulunmadığında platformlar arasında renderleme farklılık gösterebilir. Kaynak içeriğin kullandığı yazı tiplerini kurun veya uygun ikameler yapılandırın, Aspose.Slides for C++ için [platform gereksinimlerini](/slides/tr/cpp/system-requirements/) izleyin ve hedef EMF tüketen uygulamada sonucu doğrulayın. Linux ve macOS uygulamaları genellikle Windows metafayllarının görüntülenmesi ve düzenlenmesi konusunda sınırlı veya tutarsız destek sunar.

## **Renkli Emoji Renderleme**

{{% alert title="Note" color="info" %}}
Sunum slaytlarını görüntülere dönüştürürken renkli emoji'leri doğru şekilde renderlemek için, sunumda kullanılan emoji yazı tiplerinin dönüştürmeyi yapan sistemde kurulu ve kullanılabilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu yazı tipi eksikse, emoji'ler çıktı görüntülerinde tek renkli görünebilir.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytların renderlanmasını destekliyor mu?**

Hayır. [ISlide::GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage/) metodu slaytın statik bir görüntüsünü oluşturur ve animasyonları dışa aktarmaz.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet. Gizli slaytlar normal slaytlar gibi renderlenebilir. Yukarıdaki örnekte gösterildiği gibi işleme döngüsüne dahil edin.

**Gölge ve diğer efektler slayt görüntülerinde korunur mu?**

Evet. Aspose.Slides, gölgeleri, şeffaflığı ve diğer desteklenen grafik efektlerini slayt görüntülerinde renderlar.
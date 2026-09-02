---
title: C++'ta PowerPoint Mürekkep Nesnelerini Yönet
linktitle: Mürekkebi Yönet
type: docs
weight: 95
url: /tr/cpp/manage-ink/
keywords:
- mürekkep
- mürekkep nesnesi
- mürekkep izi
- mürekkebi yönet
- mürekkep çiz
- çizim
- mürekkep dışa aktarım
- mürekkep işleme
- mürekkebi gizle
- IInkOptions
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint mürekkep nesnelerini yönetin, izleri ve fırça özelliklerini düzenleyin ve PDF, HTML, SVG, TIFF ve resim dışa aktarımı sırasında mürekkep görünümünü kontrol edin."
---
## **Giriş**

PowerPoint, serbest biçimli darbeler çizebilmenizi sağlayan bir mürekkep özelliği sunar. Mürekkep, diğer nesneleri vurgulamak, bağlantı ve süreçleri göstermek ve bir slayttaki belirli öğelere dikkat çekmek için kullanılabilir.

[Aspose.Slides.Ink](https://reference.aspose.com/slides/tr/cpp/aspose.slides.ink/) ad alanı, mürekkep nesneleriyle çalışmak için gereken sınıfları ve arabirimleri içerir. Örneğin, [IInk](https://reference.aspose.com/slides/tr/cpp/aspose.slides.ink/iink/) arabirimi bir slayttaki mürekkep nesnesini temsil eder.

## **Normal Nesneler ile Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaytındaki nesneler tipik olarak şekil (shape) nesneleri ile temsil edilir. En basit biçimde bir şekil, nesnenin kendisinin (çerçevesinin) alanını tanımlayan, ayrıca kapsayıcı boyutu, şekli ve arka planı gibi özellikleri içeren bir kapsayıcıdır. Daha fazla bilgi için [Shape Layout Format](https://docs.aspose.com/slides/tr/cpp/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Ancak PowerPoint bir mürekkep nesnesini işlediğinde, çerçeve (kapsayıcı) özelliklerinin tamamını, yalnızca boyutunu hariç tutarak görmezden gelir. Kapsayıcı alanının boyutu, standart [IShape::get_Width](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_width/) ve [IShape::get_Height](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_height/) yöntemleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Mürekkep İzleri**

Bir mürekkep izi, bir kullanıcının kalemiyle dijital mürekkep yazarken izlediği yolu kaydetmek için kullanılan temel bir öğedir. İz, birbirine bağlı bir nokta dizisini depolar.

Kodlamanın en basit biçimi, her örnek noktanın X ve Y koordinatlarını belirtir. Tüm bağlanmış noktalar işlendiğinde aşağıdaki gibi bir görüntü ortaya çıkar:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

Bir fırça, bir mürekkep izinin noktalarını birleştiren çizgileri çizmeye yarar. Fırçanın kendine ait bir rengi ve boyutu vardır; bu, [IInkBrush::get_Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides.ink/iinkbrush/get_color/) ve [IInkBrush::get_Size](https://reference.aspose.com/slides/tr/cpp/aspose.slides.ink/iinkbrush/get_size/) yöntemleriyle temsil edilir.

### **Mürekkep Fırçası Rengini Ayarla**

Bu C++ kodu, bir mürekkep fırçasının rengini nasıl ayarlayacağınızı gösterir:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Mürekkep Fırçası Boyutunu Ayarla**

Bu C++ kodu, bir mürekkep fırçasının boyutunu nasıl ayarlayacağınızı gösterir:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

Genel olarak, bir fırçanın genişliği ve yüksekliği eşleşmez, bu yüzden PowerPoint fırça boyutunu göstermez (ilgili veri bölümü gri renktedir). Fırça genişliği ve yüksekliği eşleştiğinde, PowerPoint boyutu aşağıdaki gibi gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık getirmek için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları inceleyelim:

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırçaların boyutunu hesaba katmaz—her zaman çizgi kalınlığının sıfır olduğunu varsayar (önceki görüntüye bakın).

Bu nedenle, tüm mürekkep nesnesinin görünen alanını belirlemek için izlerin fırça boyutu dikkate alınmalıdır. Burada, hedef nesne (el yazısı metin izi), kapsayıcının (çerçevenin) boyutuna göre ölçeklendirilmiştir. Kapsayıcının boyutu değiştiğinde, fırça boyutu sabit kalır ve tersine de geçerlidir.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metin nesneleri için benzer bir davranış sergiler:

![ink_powerpoint6](ink_powerpoint6.png)

## **Dışa Aktarım ve İşleme Sırasında Mürekkep Görünümünü Kontrol Et**

Aspose.Slides, mürekkep nesnelerinin dışa aktarılmış veya işlenmiş çıktıda nasıl görüneceğini kontrol etmek için [IInkOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/iinkoptions/) arabirimini sunar. Bu arabirimin yöntemlerini kullanarak mürekkebi tamamen gizleyebilir veya mürekkep fırçası maske işlemlerinin nasıl yorumlandığını değiştirebilirsiniz.

Mürekkep seçenekleri, çeşitli çıktı türleri için dışa aktarım veya işleme seçenekleri aracılığıyla kullanılabilir:

| Çıktı | Mürekkep seçenekleri yöntemi |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Slayt resmi | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Bu yöntemler aracılığıyla aynı iki ayar mevcuttur:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/iinkoptions/set_hideink/) mürekkep nesnelerinin çıktıya dahil edilip edilmediğini belirler. Varsayılan değer `false`tır.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) bir mürekkep fırçası işlenirken maske işleminin opaklık olarak yorumlanıp yorumlanmayacağını belirler. Varsayılan değer `true`dır; bunun yerine ROP işlemini kullanmak için `false` olarak ayarlayın.

### **PDF Çıktısında Mürekkep Nesnelerini Gizle**

Varsayılan olarak, mürekkep nesneleri dışa aktarım sırasında görünür kalır. El yazısı notları veya başka bir mürekkep içeriği olmadan temiz bir çıktı gerektiğinde [IInkOptions::set_HideInk](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/iinkoptions/set_hideink/) yöntemini `true` ile çağırın.

Aşağıdaki C++ örneği, tüm mürekkep nesnelerini gizleyerek bir sunumu PDF olarak dışa aktarır:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Slaytı Resim Olarak İşlerken Mürekkep Nesnelerini Gizle**

Slaytları bitmap resim olarak işlerken mürekkep nesnelerini gizlemek için [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) yapılandırın ve işleme seçeneklerini [ISlide::GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage/) yöntemine geçirin.

Aşağıdaki C++ örneği, ilk slaytı mürekkep nesneleri olmadan bir PNG resmi olarak işler:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Mürekkep Maske İşlemesini Kontrol Et**

[IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) yöntemi, mürekkep fırçaları işlenirken maske işlemlerinin nasıl yorumlandığını kontrol eder. Varsayılan değer `true` olup opaklık kullanır. Yöntemi `false` ile çağırarak bunun yerine ROP işlemini kullanabilirsiniz.

Aşağıdaki C++ örneği, bir slaytı SVG olarak dışa aktarır ve mürekkep maske işlemleri için ROP temelli işleme kullanır:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

Aynı ayar, bir sunumu dışa aktarırken veya bir slaytı TIFF olarak işlerken [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) aracılığıyla da uygulanabilir.

### **Mürekkebi Gizleme veya Korumayı Seç**

Dışa aktarılan dosyanın, yorum işaretleri olmadan dağıtıma hazır bir sürüm olması gerektiğinde, [IInkOptions::set_HideInk](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/iinkoptions/set_hideink/) yöntemini `true` olarak kullanın.

Mürekkep ek açıklamaları, yorumlar, el yazısı notlar, vurgular veya çizimler gibi içeriğin bir parçası olduğunda (varsayılan `false` ayarı) mürekkebi görünür bırakın. Bu, aynı sunumdan kaynak mürekkep nesnelerini değiştirmeden ayrı inceleme ve son çıktılar üretmenize olanak tanır.

## **SSS**

**Mevcut bir mürekkep darbesinin rengini veya boyutunu değiştirebilir miyim?**

Evet. [IInk::get_Traces](https://reference.aspose.com/slides/tr/cpp/aspose.slides.ink/iink/get_traces/) yöntemini kullanarak izi alın, ardından [IInkTrace::get_Brush](https://reference.aspose.com/slides/tr/cpp/aspose.slides.ink/iinktrace/get_brush/) yöntemini değiştirin. Fırça üzerinde [IInkBrush::set_Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides.ink/iinkbrush/set_color/) ve [IInkBrush::set_Size](https://reference.aspose.com/slides/tr/cpp/aspose.slides.ink/iinkbrush/set_size/) çağırabilirsiniz.

**Mürekkebi gizlemek kaynak sunumu değiştirir mi?**

Hayır. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/iinkoptions/set_hideink/) yalnızca işlenmiş veya dışa aktarılmış sonucu etkiler; kaynak sunumdaki mürekkep nesnelerini kaldırmaz veya değiştirmez.

**Hangi dışa aktarım formatları mürekkep seçeneklerini destekliyor?**

Yukarıda gösterilen ilgili dışa aktarım veya işleme seçenekleri aracılığıyla PDF, HTML, SVG, TIFF ve bitmap slayt resimleri için mürekkep seçeneklerini yapılandırabilirsiniz.

**İlave okuma**

* Şekiller hakkında genel bilgi için [PowerPoint Shapes](https://docs.aspose.com/slides/tr/cpp/powerpoint-shapes/) bölümüne bakın.
* Etkili değerler hakkında daha fazla bilgi için [Shape Effective Properties](https://docs.aspose.com/slides/tr/cpp/shape-effective-properties/#get-effective-font-height-value) bölümünü inceleyin.
* PDF dışa aktarımı için [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/tr/cpp/convert-powerpoint-to-pdf/) sayfasına göz atın.
* HTML dışa aktarımı için [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/tr/cpp/convert-powerpoint-to-html/) sayfasını okuyun.
* SVG dışa aktarımı için [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/tr/cpp/render-a-slide-as-an-svg-image/) bölümünü inceleyin.
* TIFF dışa aktarımı için [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/tr/cpp/convert-powerpoint-to-tiff/) bölümüne bakın.
* Slaytı resme dönüştürme işlemi için [Convert Presentation Slides to Images](https://docs.aspose.com/slides/tr/cpp/convert-slide/) sayfasını kullanın.
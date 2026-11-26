---
title: C++'ta Sunum Şekillerini Özelleştirme
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/cpp/custom-shape/
keywords:
- özel şekil
- şekil ekle
- şekil oluştur
- şekil değiştir
- şekil geometrisi
- geometri yolu
- yol noktaları
- düzenleme noktaları
- nokta ekle
- nokta kaldır
- düzenleme işlemi
- eğimli köşe
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, eğimli köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, sunum şekillerini Aspose.Slides içinde düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek nasıl özelleştireceğinizi açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemlerini gerçekleştirmek, nokta ekleyip kaldırmak ve güncellenen geometrinin bir şekle uygulanmasını göstermek için [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) ve [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) ile nasıl çalışılacağını gösterir.

Ayrıca özel ve bileşik şekiller oluşturmayı, köşeleri eğimli şekiller inşa etmeyi ve bir şekil geometrisinin kapalı olup olmadığını belirlemeyi de gösterir.

## **Düzenleme Noktalarıyla Bir Şekli Değiştirme**

PowerPoint’te **Edit Points** (Düzenleme Noktaları) kullanarak bir kareyi şu şekilde değiştirebilirsiniz:

* Bir köşeyi içe veya dışa doğru hareket ettirin.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Düzenleme noktaları, bir şeklin dış hatlarını değiştirmenize veya mevcut bir şekli yeni bir şeklin temelini oluşturmak için kullanmanıza olanak tanır.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken aşağıdaki kavramları aklınızda bulundurun:

* Bir şeklin (veya yolunun) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle birleştirilmiş ankraj noktalardan oluşur.
* Bir segment düz veya eğimli olabilir. Ankraj noktaları ve kontrol kolları şeklin biçimini belirler.
* Ankraj noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olabilir:
  * Köşe noktasında, bitişik segmentler bir açıyla birleşebilir.
  * Yumuşak noktada, iki kontrol kolu hizalanmış ve ankraj noktasından eşit mesafededir.
  * Düz noktada, iki kontrol kolu hizalanmış ancak ankraj noktasından farklı mesafelerde olabilir.
* Ankraj noktalarını hareket ettirmek veya kollarını ayarlamak şeklin dış hatlarını değiştirir.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) sınıfını ve [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) arayüzünü sağlar.

* Bir [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) örneği, [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) nesnesinin geometri yolunu temsil eder.
* [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)’i [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) örneğinden almak için [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) yöntemini kullanabilirsiniz.
* Bir şekil için [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) ayarlamak istediğinizde, tek bir yola sahip şekiller için [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), birden fazla yola sahip şekiller için ise [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) yöntemlerini kullanabilirsiniz.
* Segment eklemek için [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) ve [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) yöntemleriyle bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) yöntemi, bir [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/)’in geometri yolunu yol segmentleri dizisi olarak almanızı sağlar.

## **Basit Düzenleme İşlemleri**

Bir geometri yolunu düzenlemek için aşağıdaki yöntemleri kullanın. Bir indeks kabul eden aşırı yüklemeler, segmenti yolun segment dizisindeki sıfır‑tabanlı konumuna ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekle veya ekle. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| İki kontrol noktası ve bir uç noktası olan kübik Bézier eğrisi ekle veya ekle. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Bir kontrol noktası ve bir uç noktası olan ikinci dereceden Bézier eğrisi ekle veya ekle. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Belirtilen boyut ve derecedeki açıyla eliptik yay ekle. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Mevcut figürü, uç noktasını başlangıç noktasına bağlayarak kapat. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Bir figürün başlangıç noktasını ayarla. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Sıfır‑tabanlı bir indeksteki segmenti kaldır. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Bir Şekle Özel Noktalar Ekleme**

Bu örnek, bir dikdörtgen şekline iki nokta eklemek için [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) kullanır ve düzenlenmiş yolu [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ile uygular. Koordinatlar şekle özgüdür: her iki yeni nokta da şeklin merkezinde, sol kenardan 100 puan ve üst kenardan 50 puan uzaklıktadır. 1 ve 4 segment indeksleri, noktaları üst ve alt kenarlara yerleştirir ve bu kenarları içe doğru çeker.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Bir Şekilden Noktalar Kaldırma**

Bu örnek, [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) ile sıfır‑tabanlı 2 indeksindeki segmenti kaldırarak kalp biçimli bir dış hatı değiştirir. Değiştirilmiş yolu [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ile uygulamak, şeklin konturunu günceller.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Özel Bir Şekil Oluşturma**

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız oluşturur. 100 ve 50 puanlık dış ve iç yarıçapların dönüşümlü olarak kullanılması uçları ve girintileri tanımlar; 72 derece adım beş ucu eşit olarak aralar. Yol, [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) ile kapatılır ve [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ile bir dikdörtgen şekle uygulanarak dış hatı değiştirilir.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **Bileşik Özel Şekil Oluşturma**

Bu örnek, bir şeklin üst ve alt üçte birleri için iki kapalı [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yolu da [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) ile uygulamak, ortasında bir boşluk bulunan tek bir bileşik şekil oluşturur.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(0.0f, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **Eğimli Köşeli Özel Şekil Oluşturma**

Bu örnek, düz segmentleri [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) ile birleştirerek içe doğru eğimli köşelere sahip bir şekil üretir. Her köşe boyutu, yayı puan cinsinden en ve boy olarak ayarlar ve -90 derece süpürme, saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ile uygulanır ve sunum PPTX formatında kaydedilir.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenme**

Aşağıdaki yardımcı, her dolu olmayan geometri yolunun kapanış segmentiyle bitip bitmediğini kontrol eder. [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) okur ve son segmentin [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) değerini [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/) ile karşılaştırır. Boş olmayan yol bulunmadığında false döner. Bu, her yolun son komutunu kontrol eder; bir yol içindeki her alt şekli incelemez. Örnek, bir dikdörtgen için `True` yazdırır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **Geometri Yol Komutlarını İnceleme**

[contour.pptx](contour.pptx) dosyasını indirip uygulamanın çalışma dizinine koyun. İlk slayttaki ilk şeklin üst kenarı düz, bir kübik Bézier eğrisi ve kapanış kenarı düzdür. Yollarını okumak için [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) kullanın. Her yol için [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) çizim sırasındaki segmentleri döndürür. [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) tarafından döndürülen komut, [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/) tarafından döndürülen değerlerin nasıl yorumlanacağını belirler.

```cpp
#include <DOM/IGeometryPath.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IPathSegment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/PathCommandType.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"contour.pptx");

auto shape = ExplicitCast<IGeometryShape>(presentation->get_Slide(0)->get_Shape(0));
auto paths = shape->GetGeometryPaths();

for (auto i = 0; i < paths->get_Length(); ++i)
{
    auto segments = paths->idx_get(i)->get_PathData();
    for (auto j = 0; j < segments->get_Length(); ++j)
    {
        auto segment = segments->idx_get(j);
        auto command = segment->get_PathCommand();
        auto data = segment->get_SegmentData();
        String detail;
        switch (command)
        {
            case PathCommandType::MoveTo:
            case PathCommandType::LineTo:
                detail = String::Format(u"destination=({0}, {1})", data->idx_get(0), data->idx_get(1));
                break;
            case PathCommandType::CubicBezierTo:
                detail = String::Format(u"control1=({0}, {1}) control2=({2}, {3}) end=({4}, {5})", data);
                break;
            case PathCommandType::Close:
                detail = u"no coordinates";
                break;
            default:
            {
                auto values = MakeArray<String>(data->get_Length());
                for (auto k = 0; k < data->get_Length(); ++k)
                {
                    values->idx_set(k, String::Format(u"{0}", data->idx_get(k)));
                }
                detail = String::Format(u"raw=[{0}]", String::Join(u", ", values));
                break;
            }
        }
        Console::WriteLine(u"Path {0}, segment {1}: {2} {3}", i, j, Enum<PathCommandType>::GetName(command), detail);
    }
}
```

Şekil, slaytta (200, 100) puan konumunda bulunur. Rapor edilen puanlar şekle yereldir; (0, 0) sol‑üst köşededir, x sağa, y aşağı artar. Kapanış segmenti, ek koordinat olmadan başlangıç noktasına geri döner.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Şekil Elemanlarını Çıkarma ve İnceleme**

[IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) kullanarak mevcut bir şekli, yol noktaları ve nokta türlerini içeren elemanlar olarak inceleyin. Döndürülen her [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) nesnesini [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) tipine dönüştürerek [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) ve [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) tarafından döndürülen dizileri okuyabilirsiniz. Bu temsil, kontur analizi veya geometrinin özel çizim araçlarına aktarılması için yararlıdır.

Örnek, bir sunumu açar, ilk slayttaki ilk geometri şekli bulur ve yol segmentlerini yazdırır. Düz ve eğimli segmentlere sahip bir şekil içeren bir sunum kullanın; grup içindeki şekilleri aramaz.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // Segment türünü tut, bayrakları hariç.
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // Hem kontrol noktalarını hem de uç noktasını tüket.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Diziler indeksle eşleşir: `points[i]` bir noktadır ve `types[i]` onun rolünü tanımlar. Tip `0` bir figürü başlatır, tip `1` önceki noktadan mevcut noktaya bir çizgi çizer. Kübik Bézier segmenti, önceki uç noktadan başlar ve üç ardışık tip‑`3` girdisi kullanır: iki kontrol noktası ve yeni uç nokta. Döngü bu üç girişi birlikte tüketir ve uç noktanın kapanış olup olmadığını kontrol eder.

Nokta türleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesi uygulanır, kapanmış bir alt yol olup olmadığını tespit etmek için `0x80` ayrı olarak test edilir. Örneğin, `129` (`0x81`) bir çizgi uç noktasının aynı zamanda bir alt yolu kapattığını, `131` (`0x83`) ise bir Bézier uç noktasının kapattığını gösterir. Ham değeri yalnızca `1` veya `3` ile karşılaştırmak bu durumları kaçırır. Çizgi (`0x10`) ve işaretleyici (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar, inçin 1/72’si olan puan biriminde ölçülür; X sağa, Y aşağı artar. Gruplandırılmamış bir şekil için, çıkarılan koordinatlar zaten [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) ve [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) tarafından döndürülen konumu içerir ve mevcut genişlik ve yüksekliği yansıtır. Örneğin, `(100, 200)` konumunda ve `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` şeklindedir. Şeklin konumunu tekrar eklemeyin. Koordinatları, X ve Y’sini çıkartarak şeklin döndürülmemiş çerçevesine göre göreli hâle getirin.

Çıkarılan noktalar, [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) ile ayarlanan dönüşümü veya yatay ve dikey çevirileri içermez. Görüntülenen konturu yeniden oluşturmak için bu dönüşümleri şeklin merkez etrafında uygulayın. Gruplandırılmış şekillerde, grup koordinat eşlemesi ve dönüşümlerini de hesaba katın; çıkarılan noktaların zaten çocuğun çerçevesine yansıtılmış olabileceğini varsaymayın ve bir çeviri ya da ölçeklemeyi iki kez uygulamayın.

**İnceleme vs. düzenleme.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz veya çizim kodunuz nokta/tür dizilerine ihtiyaç duyduğunda bu yaklaşımı seçin. Şeklin yerel koordinat sisteminde geometri komutlarına ihtiyacınız varsa ya da geometrisini düzenlemek istiyorsanız [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) kullanın. Düzenlenmiş yolları [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) veya [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) üzerinden uygulayın.

## **GeometryPath’i GraphicsPath’e Dönüştürme**

Aspose.Slides for C++’ın mevcut herkese açık API’si, geometri yolları ile grafik yolları arasında dönüşümleri ortaya çıkarmaz. Bir konturu incelemek için yukarıda açıklandığı gibi şekil elemanlarını kullanın. Bir şekli düzenlemek için geometri yollarını ve güncellenmiş yolları şekle uygulamayı kullanın.

## **SSS**

**Geometriyi değiştirdikten sonra dolgu ve dış hat ne olur?**

Stil şekil ile kalır; yalnızca kontur değişir. Dolgu ve dış hat otomatik olarak yeni geometriye uygulanır.

**Özel bir şekli geometrisiyle birlikte nasıl doğru şekilde döndürürüm?**

Şeklin [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) yöntemini kullanın; geometri şeklin kendi koordinat sistemine bağlı olduğu için şekille birlikte döner.

**Özel bir şekli “kilitlemek” için bir görsele dönüştürebilir miyim?**

Evet. Gerekli [slide](/slides/tr/cpp/convert-powerpoint-to-png/) bölgesi ya da [shape](/slides/tr/cpp/shape-thumbnails/) kendisini raster formatına dışa aktarın; bu, karmaşık geometrilerle çalışmayı basitleştirir.
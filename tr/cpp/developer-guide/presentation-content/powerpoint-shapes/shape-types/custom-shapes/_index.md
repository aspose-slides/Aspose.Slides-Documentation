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
- şekli değiştir
- şekil geometrisi
- geometri yolu
- yol noktaları
- düzenleme noktaları
- nokta ekle
- nokta kaldır
- düzenleme işlemi
- kıvrımlı köşe
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, kıvrımlı köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek nasıl özelleştireceğinizi açıklar. [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) ve [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) ile mevcut şekilleri nasıl değiştireceğinizi, temel yol düzenleme işlemlerini nasıl yapacağınızı, nokta ekleyip kaldıracağınızı ve güncellenen geometrinin bir şekle nasıl uygulanacağını gösterir. Ayrıca, özel ve birleşik şekillerin nasıl oluşturulacağını, eğimli köşeli şekillerin nasıl inşa edileceğini ve bir şekil geometrisinin kapalı olup olmadığını nasıl belirleyeceğinizi gösterir.

## **Düzenleme Noktalarıyla Bir Şekli Değiştirme**

PowerPoint'te **Edit Points** özelliğini kullanarak bir kareyi değiştirebilirsiniz:

* Bir köşeyi içeriye veya dışarıya hareket ettirin.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Nokta düzenleme, bir şeklin dış hattını değiştirmenizi veya mevcut bir şekli yeni bir şeklin temeli olarak kullanmanızı sağlar.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken şu kavramları aklınızda tutun:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Bir şeklin yolu, bölümlerle birbirine bağlanan tutma noktalarından oluşur.
* Bir bölüm düz veya eğimli olabilir. Tutma noktaları ve kontrol tutamaçları şeklinin şeklini belirler.
* Tutma noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:
  * Köşe noktasında, bitişik bölümler bir açıyla birleşir.
  * Yumuşak noktada, iki kontrol tutamaç hizalanır ve tutma noktasına eşit mesafededir.
  * Düz noktada, iki kontrol tutamaç hizalanır ancak tutma noktasına farklı mesafelerde olabilir.
* Tutma noktalarını hareket ettirmek veya tutamaçlarını ayarlamak şeklin dış hattını değiştirir.

Düzenleme noktalarıyla PowerPoint şekillerini düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) sınıfını ve [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) arayüzünü sağlar.

* Bir [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) örneği, [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) nesnesinin bir geometri yolunu temsil eder.
* [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) öğesini [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) örneğinden almak için [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) yöntemini kullanabilirsiniz.
* Bir şekle [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) ayarlamak için şu yöntemleri kullanabilirsiniz: tek bir yola sahip şekiller için [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ve birden fazla yola sahip şekiller için [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).
* Bölümler eklemek için [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) ve [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) yöntemlerini kullanarak bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) yöntemini kullanarak bir [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) geometrisinin yol verisini yol segmentleri dizisi olarak alabilirsiniz.

## **Basit Düzenleme İşlemleri**

Bir geometri yolunu düzenlemek için aşağıdaki yöntemleri kullanın. Dizini kabul eden aşırı yüklemeler, yolun segment dizisinde sıfırdan başlayan bir konuma bir segment ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekleyin veya yerleştirin. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| İki kontrol noktası ve bir bitiş noktasıyla kübik Bézier eğrisi ekleyin veya yerleştirin. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Bir kontrol noktası ve bir bitiş noktasına sahip ikili Bézier eğrisi ekleyin veya yerleştirin. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Belirtilen boyut ve derecelerde bir eliptik yay ekleyin. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Geçerli şekli, bitiş noktasını başlangıç noktasına bağlayarak kapatın. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Şeklin başlangıç noktasını ayarlayın. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Sıfırdan başlayan bir dizinde bir bölümü kaldırın. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Bir Şekle Özel Noktalar Ekleme**

Bu örnek, bir dikdörtgen şekline iki nokta eklemek için [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) kullanır ve düzenlenmiş yolu [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ile uygular. Koordinatlar şekle göre lokalizedir: her iki yeni nokta da şeklin ortasında, soldan 100 puan ve üstten 50 puan uzaklıkta bulunur. 1 ve 4 indeksli bölümler bu noktaları üst ve alt kenarlara yerleştirir, bu kenarları içe doğru çeker.

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

## **Bir Şekilden Noktaları Kaldırma**

Bu örnek, [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) kullanarak sıfırdan başlayan 2. indeksteki bölümü kaldırarak kalp şeklindeki dış hatı değiştirir. Değiştirilmiş yolu [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ile uygulamak şeklin konturunu günceller.

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

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız oluşturur. 100 ve 50 puanlık dış ve iç yarıçapların dönüşümlü olarak kullanılması uçları ve girintileri belirler; 72 derece adım beş ucu eşit aralıklarla yerleştirir. Yol, [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) ile kapatılır ve [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) kullanılarak bir dikdörtgen şekle uygulanır, böylece dış hattı değiştirilir.

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

Bu örnek, bir şeklin üst ve alt üçte bir bölümleri için iki kapalı [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yolu da [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) ile uygulamak, ortasında bir boşluk bulunan tek bir bileşik şekil oluşturur.

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

## **Eğri Köşeli Özel Şekil Oluşturma**

Bu örnek, içe doğru kıvrılmış köşelere sahip bir şekil oluşturmak için düz bölümleri [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) ile birleştirir. Her köşe boyutu, yayı puan cinsinden genişlik ve yükseklik olarak ayarlar ve -90 derece süpürme, saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ile uygulanır ve sunum PPTX formatında kaydedilir.

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

Aşağıdaki yardımcı, her boş olmayan geometri yolunun kapanış segmentiyle bitip bitmediğini denetler. [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) okur ve son segmentin [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) değerini [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/) ile karşılaştırır. Boş yol olmadığında false döndürür. Bu, her yolun son komutunu kontrol eder; yol içinde her alt şekli incelemez. Örnek, bir dikdörtgen için `True` yazdırır.

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

## **Şekil Öğelerini Çıkarma ve İnceleme**

[IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) yöntemini kullanarak mevcut bir şekli yol noktaları ve nokta türleri içeren öğeler olarak inceleyin. Döndürülen her [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) öğesini [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) tipine dönüştürerek [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) ve [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) tarafından dönen dizileri okuyabilirsiniz. Bu temsili, kontur analizi veya geometrinin özel çizim araçlarına aktarılması için kullanışlıdır.

Bu örnek bir sunumu açar, ilk slayttaki ilk geometri şekline doğrudan ulaşır ve yol segmentlerini yazdırır. Hem düz hem de eğimli segmentlere sahip bir şekil içeren bir sunum kullanarak her iki çıktıyı da görebilirsiniz. Grupların içini aramaz.

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
        auto pointType = types[i] & 0x07; // Bölüm tipini koru, bayrakları hariç tut.
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
                i += 2; // Consume both control points and the endpoint.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Diziler indeks bazında eşleşir: `points[i]` bir noktadır ve `types[i]` onun rolünü tanımlar. Tip `0` bir şekli başlatır, tip `1` önceki noktadan mevcut noktaya bir çizgi çizer. Kübik Bézier segmenti, önceki bitiş noktasından başlar ve üç ardışık tip-`3` girdisini kullanır: iki kontrol noktası ve ardından yeni bitiş noktası. Döngü bu üç girişi birlikte tüketir ve kapanış için bitiş noktasını kontrol eder.

Nokta tipleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesini, kapalı bir alt yolu tespit etmek için ise `0x80` değerini ayrı ayrı test edin. Örneğin, `129` (`0x81`) bir alt yolu kapatan çizgi bitiş noktasını, `131` (`0x83`) ise bir Bézier bitiş noktasını kapatır. Ham değeri yalnızca `1` veya `3` ile karşılaştırmak bu durumları kaçırır. Çizgi (`0x10`) ve işaretçi (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar puan (1/72 inç) cinsinden ölçülür; X sağa doğru, Y aşağı doğru artar. Gruplanmamış bir şekil için, çıkarılan koordinatlar zaten [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) ve [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) tarafından döndürülen konumu içerir ve mevcut genişlik ve yüksekliğini yansıtır. Örneğin, `(100, 200)` konumunda ve `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` şeklindedir. Şeklin konumunu tekrar eklemeyin. X ve Y değerini çıkararak koordinatları döndürülmemiş çerçeveye göre elde edin.

Çıkarılan noktalar, [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) ile ayarlanan döndürmeyi veya yatay ve dikey çevirileri uygulamaz. Görüntülenen konturu yeniden üretmek için bu dönüşümleri şeklin merkezinde uygulayın. Gruplu şekiller için ayrıca grup koordinat haritalamasını ve dönüşümleri hesaba katın; çıkarılan noktaların nihai slayt koordinatları olduğunu varsaymayın ve çocuğun çerçevesinde zaten yansıtılmışsa bir çeviri veya ölçeklendirmeyi iki kez uygulamayın.

**İnceleme vs. düzenleme.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz veya çizim kodunuzun nokta/tür dizilerine ihtiyacı olduğunda bu yöntemi seçin. Şeklin yerel koordinat sistemindeki geometri komutlarına ihtiyacınız olduğunda veya geometrisini düzenlemek istediğinizde [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) kullanın. Düzenlenmiş yolları [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) veya [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) aracılığıyla uygulayın.

## **GeometryPath'i GraphicsPath'e Dönüştürme**

C++ için mevcut Aspose.Slides genel API'si, geometri yolları ile grafik yolları arasındaki dönüşümleri sunmaz. Bir konturu incelemek için yukarıda açıklanan şekil öğelerini kullanın. Bir şekli düzenlemek için geometri yollarını kullanın ve güncellenen yolları şekle uygulayın.

## **SSS**

**Geometriyi değiştirdikten sonra dolgu ve dış hat ne olur?**  
Stil şekille kalır; yalnızca kontur değişir. Dolgu ve dış hat otomatik olarak yeni geometriye uygulanır.

**Özel bir şekli geometrisiyle birlikte doğru şekilde nasıl döndürürüm?**  
Şeklin [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) metodunu kullanın; geometri, şeklin kendi koordinat sistemine bağlı olduğu için şekille birlikte döner.

**Sonucu "kilitlemek" için özel bir şekli görüntüye dönüştürebilir miyim?**  
Evet. Gerekli [slayt](/slides/tr/cpp/convert-powerpoint-to-png/) alanını veya [şekil](/slides/tr/cpp/shape-thumbnails/) öğesini raster bir formata dışa aktarın; bu, karmaşık geometrilerle çalışmayı basitleştirir.
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
description: "Aspose.Slides for C++ ile PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, eğimli köşeler, bileşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek özelleştirmenin yolunu açıklar. `GeometryPath` ve `IGeometryPath` ile mevcut şekilleri değiştirmeyi, temel yol düzenleme işlemlerini yapmayı, nokta eklemeyi veya kaldırmayı ve güncellenen geometriyi bir şekle geri uygulamayı gösterir.

## **Düzenleme Noktalarını Kullanarak Bir Şekli Değiştirme**
Bir kareyi düşünün. PowerPoint’te **düzenleme noktalarını** kullanarak  

* karenin köşesini içe ya da dışa hareket ettirin  
* bir köşe ya da nokta için eğrilik belirleyin  
* kareye yeni noktalar ekleyin  
* kare üzerindeki noktaları düzenleyin, vb.  

Temelde, bu görevleri herhangi bir şekil üzerinde gerçekleştirebilirsiniz. Düzenleme noktalarını kullanarak bir şekli değiştirebilir ya da mevcut bir şekilden yeni bir şekil oluşturabilirsiniz. 

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenleme noktalarıyla düzenlemeye başlamadan önce şekiller hakkında şu noktalara dikkat edebilirsiniz:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.  
* Bir şekil kapalı olduğunda bir başlangıç ya da bitiş noktası yoktur. Açık olduğunda ise bir başlangıcı ve bir sonu vardır.  
* Tüm şekiller en az 2 tutama noktasından oluşur ve bu noktalar çizgilerle birbirine bağlanır.  
* Bir çizgi düz ya da eğridir. Tutama noktaları çizginin niteliğini belirler.  
* Tutama noktaları köşe noktaları, düz noktalar veya yumuşak noktalar şeklinde bulunur:  
  * Köşe noktası, iki düz çizginin bir açıda birleştiği noktadır.  
  * Yumuşak nokta, iki tutamağın düz bir hat üzerinde olduğu ve çizgi segmentlerinin yumuşak bir kırıma birleştiği noktadır. Bu durumda, tüm tutamaçlar tutama noktasından eşit mesafede bulunur.  
  * Düz nokta, iki tutamağın düz bir hat üzerinde olduğu ve o hat segmentlerinin yumuşak bir kıvrıma birleştiği noktadır. Bu durumda tutamaçların tutama noktasından eşit mesafede olması gerekmez.  
* Tutama noktalarını hareket ettirerek ya da düzenleyerek (çizgi açılarını değiştirerek) şeklin görünümünü değiştirebilirsiniz.  

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [**GeometryPath**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.geometry_path) sınıfını ve [**IGeometryPath**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_geometry_path) arabirimini sağlar.  

* Bir [GeometryPath] örneği, [IGeometryShape] nesnesinin geometri yolunu temsil eder.  
* `IGeometryShape` örneğinden `GeometryPath`'i almak için [IGeometryShape::GetGeometryPaths] yöntemini kullanabilirsiniz.  
* Bir şekil için `GeometryPath`'i ayarlamak üzere bu yöntemleri kullanabilirsiniz: katı şekiller için [IGeometryShape::SetGeometryPath()] ve birleşik şekiller için [IGeometryShape::SetGeometryPaths()].  
* Segment eklemek için [IGeometryPath] altındaki yöntemleri kullanabilirsiniz.  
* [IGeometryPath::set_Stroke()] ve [IGeometryPath::set_FillMode()] yöntemlerini kullanarak bir geometri yolunun görünümünü ayarlayabilirsiniz.  
* [IGeometryPath::get_PathData()] yöntemiyle bir `GeometryShape`'in geometri yolunu yol segmentleri dizisi olarak alabilirsiniz.  
* Ek şekil geometri özelleştirme seçeneklerine erişmek için [GeometryPath]'i [GraphicsPath]'e dönüştürebilirsiniz.  
* [GeometryPathToGraphicsPath] ve [GraphicsPathToGeometryPath] yöntemlerini ( [ShapeUtil] sınıfından ) kullanarak [GeometryPath]'i [GraphicsPath]'e geri ve ileri dönüştürebilirsiniz.  

## **Basit Düzenleme İşlemleri**

Bu C++ kodu size nasıl yapılacağını gösterir  

**Bir çizgi ekle** yolun sonuna  

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Bir çizgi ekle** yoldaki belirli bir konuma:  

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Bir kübik Bezier eğrisi ekle** yolun sonuna:  

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Bir kübik Bezier eğrisi ekle** yoldaki belirli bir konuma:  

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Bir ikinci derece Bezier eğrisi ekle** yolun sonuna:  

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**İkinci derece Bezier eğrisi ekle** yoldaki belirli bir konuma:  

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Verilen bir yay ekle** bir yola:  

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Mevcut şekli kapat** bir yolda:  

``` cpp
void CloseFigure();
```
**Sonraki nokta için konumu ayarla**:  

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Belirli bir indeksteki yol segmentini kaldır**:  

``` cpp
void RemoveAt(int32_t index);
```
## **Şekle Özel Noktalar Ekleme**
1. [GeometryShape] sınıfının bir örneğini oluşturun ve [ShapeType.Rectangle] tipini ayarlayın.  
2. Şekilden [GeometryPath] sınıfının bir örneğini alın.  
3. Yoldaki iki üst nokta arasında yeni bir nokta ekleyin.  
4. Yoldaki iki alt nokta arasında yeni bir nokta ekleyin.  
5. Yolu şekle uygulayın.  

Bu C++ kodu size şekle özel noktalar eklemenin nasıl yapılacağını gösterir:  

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Şekilden Noktaları Kaldırma**

1. [GeometryShape] sınıfının bir örneğini oluşturun ve [ShapeType.Heart] tipini ayarlayın.  
2. Şekilden [GeometryPath] sınıfının bir örneğini alın.  
3. Yolun segmentini kaldırın.  
4. Yolu şekle uygulayın.  

Bu C++ kodu size şekilden noktaları kaldırmanın nasıl yapılacağını gösterir:  

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Özel Bir Şekil Oluşturma**

1. Şekil için noktaları hesaplayın.  
2. [GeometryPath] sınıfının bir örneğini oluşturun.  
3. Yolu noktalarla doldurun.  
4. [GeometryShape] sınıfının bir örneğini oluşturun.  
5. Yolu şekle uygulayın.  

Bu C++ kodu size özel bir şekil oluşturmanın nasıl yapılacağını gösterir:  

``` cpp
SharedPtr<List<PointF>> points = System::MakeObject<List<PointF>>();

float R = 100.0f, r = 50.0f;
int32_t step = 72;

for (int32_t angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math::PI / 180.f);
    double x = outerRadius * Math::Cos(radians);
    double y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + step / 2) / 180.0;
    x = innerRadiusr * Math::Cos(radians);
    y = innerRadiusr * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

SharedPtr<GeometryPath> starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (int32_t i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, R * 2, R * 2));

shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)


## **Bileşik Özel Şekil Oluşturma**

1. [GeometryShape] sınıfının bir örneğini oluşturun.  
2. [GeometryPath] sınıfının ilk örneğini oluşturun.  
3. [GeometryPath] sınıfının ikinci örneğini oluşturun.  
4. Yolları şekle uygulayın.  

Bu C++ kodu size bileşik bir özel şekil oluşturmayı gösterir:  

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath0 = System::MakeObject<GeometryPath>();
geometryPath0->MoveTo(0.0f, 0.0f);
geometryPath0->LineTo(shape->get_Width(), 0.0f);
geometryPath0->LineTo(shape->get_Width(), shape->get_Height() / 3);
geometryPath0->LineTo(0.0f, shape->get_Height() / 3);
geometryPath0->CloseFigure();

SharedPtr<IGeometryPath> geometryPath1 = System::MakeObject<GeometryPath>();
geometryPath1->MoveTo(0.0f, shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height());
geometryPath1->LineTo(0.0f, shape->get_Height());
geometryPath1->CloseFigure();

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ geometryPath0, geometryPath1 }));
```
![example4_image](custom_shape_4.png)

## **Eğimli Köşelerle Özel Şekil Oluşturma**

Bu C++ kodu size içe doğru eğimli köşelere sahip bir özel şekil oluşturmanın nasıl yapılacağını gösterir;  

```cpp
float shapeX = 20.f;
float shapeY = 20.f;
float shapeWidth = 300.f;
float shapeHeight = 200.f;

float leftTopSize = 50.f;
float rightTopSize = 20.f;
float rightBottomSize = 40.f;
float leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();

auto childShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto geometryPath = System::MakeObject<GeometryPath>();

PointF point1(leftTopSize, 0.0f);
PointF point2(shapeWidth - rightTopSize, 0.0f);
PointF point3(shapeWidth, shapeHeight - rightBottomSize);
PointF point4(leftBottomSize, shapeHeight);
PointF point5(0.0f, leftTopSize);

geometryPath->MoveTo(point1);
geometryPath->LineTo(point2);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(point3);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(point4);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(point5);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);

geometryPath->CloseFigure();

childShape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenin**

Kapalı bir şekil, tüm kenarları birbirine bağlanarak boşluk bırakmayan tek bir sınır oluşturduğu durum olarak tanımlanır. Böyle bir şekil basit bir geometrik form ya da karmaşık bir özel kontur olabilir. Aşağıdaki kod örneği bir şekil geometrisinin kapalı olup olmadığını kontrol etmeyi gösterir:  

```cpp
bool IsGeometryClosed(SharedPtr<IGeometryShape> geometryShape)
{
    bool isClosed = false;

    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto dataLength = geometryPath->get_PathData()->get_Length();
        if (dataLength == 0)
            continue;

        auto lastSegment = geometryPath->get_PathData()[dataLength - 1];
        isClosed = lastSegment->get_PathCommand() == PathCommandType::Close;

        if (!isClosed)
            return false;
    }

    return isClosed;
}
```

## **GeometryPath'i GraphicsPath'e Dönüştürme** 

1. [GeometryShape] sınıfının bir örneğini oluşturun.  
2. [System.Drawing.Drawing2D] ad alanının [GraphicsPath] sınıfının bir örneğini oluşturun.  
3. [GraphicsPath] örneğini [ShapeUtil] kullanarak [GeometryPath] örneğine dönüştürün.  
4. Yolları şekle uygulayın.  

Bu C++ kodu—yukarıdaki adımların bir uygulaması—**GeometryPath**'i **GraphicsPath**'e dönüştürme sürecini gösterir:  

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Text in shape", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```
![example5_image](custom_shape_5.png)

## **SSS**

**Geometri değiştirildiğinde dolgu ve kontur ne olur?**  
Stil şekilyle birlikte kalır; sadece kontur değişir. Dolgu ve kontur yeni geometriye otomatik olarak uygulanır.  

**Özel bir şekli ve geometrisini nasıl doğru şekilde döndürürüm?**  
Şeklin [rotation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/set_rotation/) özelliğini kullanın; geometri şeklin kendi koordinat sistemine bağlı olduğundan şekil ile birlikte döner.  

**Sonucu “kilitlemek” için özel bir şekli bir görüntüye dönüştürebilir miyim?**  
Evet. Gerekli [slide](/slides/tr/cpp/convert-powerpoint-to-png/) alanını ya da [shape](/slides/tr/cpp/create-shape-thumbnails/) kendisini raster bir formata dışa aktarın; bu, ağır geometrilerle çalışmayı basitleştirir.
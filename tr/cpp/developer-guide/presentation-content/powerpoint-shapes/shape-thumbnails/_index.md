---
title: "C++'ta Sunum Şekillerinin Küçük Resimlerini Oluşturma"
linktitle: "Şekil Küçük Resimleri"
type: docs
weight: 70
url: /tr/cpp/shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekil render et
- şekil renderleme
- görsel sınırlar
- şekil sınırları
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint slaytlarından yüksek kaliteye sahip şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca yaratın ve dışa aktarın."
---
## **Giriş**

Aspose.Slides, her sayfası bir slayt olan sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, Microsoft PowerPoint kullanılarak sunum dosyaları açılarak görüntülenebilir. Ancak bazen, geliştiricilerin şekillerin görüntülerini ayrı bir görüntüleyicide görmek isteyebileceği durumlar ortaya çıkar. Bu gibi durumlarda, Aspose.Slides slayt şekillerinin küçük resim görüntülerini oluşturmanıza yardımcı olur. Bu özelliğin nasıl kullanılacağı bu makalede açıklanmıştır.

Bu makale, slayt küçük resimlerini farklı şekillerde nasıl oluşturacağınızı açıklar:

- Bir slayt içinde şekil küçük resmi oluşturma.
- Kullanıcı tanımlı boyutlarla bir slayt şekli için şekil küçük resmi oluşturma.
- Bir şeklin görünüm sınırları içinde şekil küçük resmi oluşturma.

## **Bir Slayttan Şekil Küçük Resmi Oluşturma**
Aspose.Slides for C++ kullanarak herhangi bir slayttan şekil küçük resmi oluşturmak için:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Herhangi bir slaytın referansını ID veya indeksini kullanarak alın.
1. Referans alınan slaytın şekil küçük resim görüntüsünü varsayılan ölçekle alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir resim formatında kaydedin.

Aşağıdaki örnek şekil küçük resmi oluşturmaktadır.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Kullanıcı Tanımlı Ölçek Faktörü Küçük Resmi Oluşturma**
Aspose.Slides for C++ kullanarak herhangi bir slayt şeklinin şekil küçük resmini oluşturmak için:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Herhangi bir slaytın referansını ID veya indeksini kullanarak alın.
1. Referans alınan slaytın şekil sınırlarıyla küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir resim formatında kaydedin.

Aşağıdaki örnek, kullanıcı tanımlı ölçek faktörüyle bir küçük resim oluşturur.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // X ve Y eksenleri boyunca ölçekleme.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Sınır Tabanlı Şekil Görünümü Küçük Resmi Oluşturma**
Bu yöntem, şekillerin küçük resimlerini oluştururken geliştiricilerin şeklin görünüm sınırları içinde bir küçük resim üretmelerine olanak tanır. Tüm şekil etkilerini dikkate alır. Oluşturulan şekil küçük resmi, slayt sınırlarıyla kısıtlanır. Görünüm sınırları içinde herhangi bir slayt şeklinin küçük resmini oluşturmak için aşağıdaki örnek kodu kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Herhangi bir slaytın referansını ID veya indeksini kullanarak alın.
1. Referans alınan slaytın şekil sınırlarını görünüm olarak alarak küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir resim formatında kaydedin.

Aşağıdaki örnek, görünüm sınırlarıyla bir küçük resim oluşturur.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // X ve Y eksenleri boyunca ölçekleme.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Bir Şeklin Gerçek Görsel Sınırlarını Alın**

[IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) arayüzünün çerçeve özellikleri—`IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()`, ve `IShape::get_Height()`—sunum modelinde depolanan dikdörtgeni tanımlar. Aslında işlenen içerik bu çerçevenin ötesine uzanabilir veya farklı bir eksen hizalı dikdörtgeni kaplayabilir. Döndürme, konturlar, ok başları, metin düzeni ve taşma, oluşturulan SmartArt geometrisi ve diğer render etkileri, kaplanan alanı değiştirebilir.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getvisualbounds/) yöntemini kullanarak bir görüntü oluşturmadan bu kaplanan alanı hesaplayabilirsiniz. Yöntem, slayt koordinatlarında bir [RectangleF](https://reference.aspose.com/slides/tr/cpp/system.drawing/rectanglef/) döner. Döndürülen dikdörtgen slayta kırpılmadığından, içerik slayt başlangıcının ötesine uzandığında koordinatları negatif olabilir.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getvisualbounds/) şu anda [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) arayüzü tarafından bildirilmiyor. Bu nedenle, slaytın şekil koleksiyonundan alınan şekli bir arayüz değeri olarak tutun ve yalnızca yöntemi çağırırken dönüştürün.

Aşağıdaki örnek, çerçeve ve görsel sınırları alır ve karşılaştırır:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

Aynı [RectangleF](https://reference.aspose.com/slides/tr/cpp/system.drawing/rectanglef/) `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` veya `RectangleF::get_Bottom()` kenarlarına yakın şekilleri hizalamak; oluşturulan bir yerleşimde yeterli alan ayırmak; veya izin verilen bir bölgenin dışındaki içeriği tespit etmek için kullanılabilir. Görsel sınırlar, depolanan çerçevenin tam render sonucunu temsil etmeyebileceği SmartArt, metin kutuları, oklar, resimler, döndürülmüş şekiller ve grup şekilleri için özellikle yararlıdır.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getvisualbounds/) yerleşim veya doğrulama için koordinatlara ihtiyacınız olduğunda ve bitmap gerekmiyorsa kullanın. Şekli render etmeniz gerektiğinde ise [IShape::GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/getimage/) kullanın. [ShapeThumbnailBounds](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapethumbnailbounds/) ile `ShapeThumbnailBounds::Shape` görüntüyü şekil sınırlarından, kontur ayarları dahil, boyutlandırırken `ShapeThumbnailBounds::Appearance` görüntüyü şeklin görünümünden boyutlandırır ve sonucu slayt sınırlarıyla kısıtlar. Buna karşılık, [Shape::GetVisualBounds](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getvisualbounds/) yalnızca hesaplanan dikdörtgeni döner ve slayta kırpmaz.

## **SSS**

**Şekil küçük resimleri kaydedilirken hangi görüntü formatları kullanılabilir?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imageformat/) ve diğerleri. Şekiller, şeklin içeriği SVG olarak kaydedilerek ayrıca [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/writeassvg/).

**Küçük resim oluşturulurken Shape ve Appearance sınırları arasındaki fark nedir?**

`Shape` şeklin geometrisini kullanır; `Appearance` [görsel efektleri](/slides/tr/cpp/shape-effect/) (gölgeler, parlamalar vb.) dikkate alır.

**Bir şekil gizli olarak işaretlenirse ne olur? Yine de küçük resim olarak render edilir mi?**

Gizli bir şekil modelin bir parçası olmaya devam eder ve render edilebilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün oluşturulmasını engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**

Evet. [Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/) olarak temsil edilen herhangi bir nesne ([GroupShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chart/) ve [SmartArt](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartart/) dahil) bir küçük resim ya da SVG olarak kaydedilebilir.

**Sistemde yüklü yazı tipleri metin şekilleri için küçük resim kalitesini etkiler mi?**

Evet. İstenmeyen yedeklemeleri ve metin akışını önlemek için gerekli yazı tiplerini [sağlamalısınız](/slides/tr/cpp/custom-font/) (veya [yazı tipi ikamelerini yapılandırmalısınız](/slides/tr/cpp/font-substitution/)).
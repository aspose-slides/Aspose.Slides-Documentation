---
title: C++ ile Sunum Şekillerinin Küçük Resimlerini Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/cpp/shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekli render et
- şekil renderleme
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca oluşturun ve dışa aktarın."
---
## **Giriş**

Aspose.Slides, her sayfanın bir slayt olduğu sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, Microsoft PowerPoint kullanılarak sunum dosyaları açıldığında görüntülenebilir. Ancak bazen geliştiricilerin şekillerin görüntülerini ayrı bir görüntüleyicide görmek istemeleri gerekir. Bu gibi durumlarda Aspose.Slides, slayt şekillerinin küçük resim (thumbnail) görüntülerini oluşturmanıza yardımcı olur. Bu özelliğin nasıl kullanılacağı bu makalede açıklanmıştır.  
Bu makale, slayt küçük resimlerini farklı şekillerde oluşturmayı açıklar:

- Bir slayt içinde şekil küçük resmi oluşturma.
- Kullanıcı tanımlı boyutlarla bir slayt şekli için şekil küçük resmi oluşturma.
- Bir şeklin görünüm sınırları içinde şekil küçük resmi oluşturma.

## **Bir Slayttan Şekil Küçük Resmi Oluşturma**
Bir slayttan şekil küçük resmi oluşturmak için Aspose.Slides for C++ kullanarak:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Kimliği veya dizini kullanarak herhangi bir slaytın referansını alın.
1. Referans alınan slaytın şekil küçük resim görüntüsünü varsayılan ölçekte alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

Aşağıdaki örnek şekil küçük resmi oluşturur.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Kullanıcı Tanımlı Ölçekleme Faktörü ile Küçük Resim Oluşturma**
Herhangi bir slayt şeklinin şekil küçük resmini oluşturmak için Aspose.Slides for C++ kullanarak:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Kimliği veya dizini kullanarak herhangi bir slaytın referansını alın.
1. Referans alınan slaytın şekil sınırlarıyla birlikte küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

Aşağıdaki örnek, kullanıcı tanımlı ölçekleme faktörüyle bir küçük resim oluşturur.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // X ve Y eksenlerinde ölçekleme.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Sınır Tabanlı Şekil Görünümü Küçük Resmi Oluşturma**
Bu yöntem, şekillerin küçük resimlerini oluştururken geliştiricilerin şeklin görünüm sınırları içinde bir küçük resim üretmelerine olanak tanır. Tüm şekil efektlerini dikkate alır. Oluşturulan şekil küçük resmi slayt sınırlarıyla kısıtlanır. Görünüm sınırında herhangi bir slayt şeklinin küçük resmini oluşturmak için aşağıdaki örnek kodu kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Kimliği veya dizini kullanarak herhangi bir slaytın referansını alın.
1. Referans alınan slaytın şekil sınırlarını görünüm olarak alarak küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

Aşağıdaki örnek, kullanıcı tanımlı ölçekleme faktörüyle bir küçük resim oluşturur.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // X ve Y eksenlerinde ölçekleme.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **SSS**

**Şekil küçük resimleri kaydederken hangi görüntü formatları kullanılabilir?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imageformat/), ve diğerleri. Şekiller ayrıca şeklin içeriğini SVG olarak kaydederek [vektörel SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/writeassvg/).

**Küçük resim oluştururken Shape ve Appearance sınırları arasındaki fark nedir?**

`Shape` şeklin geometrisini kullanır; `Appearance` [görsel efektleri](/slides/tr/cpp/shape-effect/) (gölgeler, ışıldamalar vb.) dikkate alır.

**Bir şekil gizli olarak işaretlenmişse ne olur? Yine de küçük resim olarak render edilir mi?**

Gizli bir şekil modelin bir parçası olarak kalır ve render edilebilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün üretilmesini engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**

Evet. [Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/) olarak temsil edilen herhangi bir nesne (örn. [GroupShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chart/), ve [SmartArt](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartart/)) bir küçük resim veya SVG olarak kaydedilebilir.

**Sistem tarafından yüklü yazı tipleri metin şekilleri için küçük resim kalitesini etkiler mi?**

Evet. İstenmeyen yazı tipi geri dönüşlerini ve metin kaymalarını önlemek için [gerekli yazı tiplerini sağlayın](/slides/tr/cpp/custom-font/) (veya [yazı tipi ikamelerini yapılandırın](/slides/tr/cpp/font-substitution/)).
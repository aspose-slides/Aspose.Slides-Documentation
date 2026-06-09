---
title: C++'ta Sunum Şekillerini Yönetme
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/cpp/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil kopyalama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- Interop şekil kimliğini al
- şekil alternatif metni
- şekil düzen formatları
- Şekil SVG olarak
- Şekli SVG'ye
- şekil hizalama
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta şekilleri oluşturmayı, düzenlemeyi ve optimize etmeyi öğrenin ve yüksek performanslı PowerPoint sunumları sunun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunularda şekillerle nasıl çalışılacağını açıklar. Bir slaytta şekil bulma, kopyalama, kaldırma, gizleme, sırasını değiştirme, Interop şekil kimliğini alma ve tanımlama ile sonraki işleme yönelik alternatif metin ayarlama konularını gösterir.

Ayrıca şekiller için düzen formatlarına nasıl erişileceği, bir şeklin SVG olarak render edilmesi, slaytta şekillerin hizalanması ve yatay ve dikey yansıtma için flip özelliklerinin kullanılması konularını kapsar. Ek olarak, makale şekil birleştirme, yığılma sırası ve şekil kilitleme hakkında kısa bir SSS içerir.

## **Bir Slaytta Şekil Bulma**
Bu konu, geliştiricilerin bir slayttaki belirli bir şekli iç kimliğini (Id) kullanmadan bulmalarını kolaylaştıran basit bir teknik açıklayacaktır. PowerPoint sunum dosyalarının bir slayttaki şekilleri iç kimlik dışındaki bir şekilde tanımlamanın bir yolu olmadığını bilmek önemlidir. Geliştiricilerin iç benzersiz Id'siyle bir şekil bulması zor görünebilir. Slaytlara eklenen tüm şekillerin bir Alternatif Metni (Alt Text) vardır. Geliştiricilere belirli bir şekli bulmak için alternatif metin kullanmalarını öneririz. Gelecekte değiştirmeyi planladığınız nesneler için alternatif metni tanımlamak üzere MS PowerPoint'i kullanabilirsiniz.

İstediğiniz bir şeklin alternatif metni ayarlandıktan sonra, Aspose.Slides for C++ kullanarak bu sunumu açabilir ve bir slayta eklenen tüm şekiller arasında döngü yapabilirsiniz. Her yinelemede, şeklin alternatif metnini kontrol edebilir ve eşleşen alternatif metne sahip şekil sizin ihtiyaç duyduğunuz şekil olur. Bu tekniği daha iyi göstermek için, bir slaytta belirli bir şekli bulup sadece o şekli döndüren bir yöntem oluşturduk: [FindShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **Bir Şekli Kopyalama**
Aspose.Slides for C++ kullanarak bir şekli slayta kopyalamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının örneğini oluşturun.
2. İndeksini kullanarak bir slaydın referansını alın.
3. Kaynak slaydın şekil koleksiyonuna erişin.
4. Sunuma yeni bir slayt ekleyin.
5. Kaynak slayd şekil koleksiyonundaki şekilleri yeni slayta kopyalayın.
6. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek bir grup şekli slayta ekler.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **Bir Şekli Kaldırma**
Aspose.Slides for C++ geliştiricilerin herhangi bir şekli kaldırmasına olanak tanır. Bir slayttan şekli kaldırmak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının örneğini oluşturun.
2. İlk slayta erişin.
3. Belirli AlternativeText'e sahip şekli bulun.
4. Şekli kaldırın.
5. Dosyayı diske kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **Bir Şekli Gizleme**
Aspose.Slides for C++ geliştiricilerin herhangi bir şekli gizlemesine olanak tanır. Bir slayttan şekli gizlemek için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının örneğini oluşturun.
2. İlk slayta erişin.
3. Belirli AlternativeText'e sahip şekli bulun.
4. Şekli gizleyin.
5. Dosyayı diske kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **Şekil Sırasını Değiştirme**
Aspose.Slides for C++ geliştiricilerin şekilleri yeniden sıralamasına olanak tanır. Şekil sıralaması, hangi şeklin ön sırada hangi şeklin arka sırada olduğunu belirler. Bir slayttaki şekilleri yeniden sıralamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının örneğini oluşturun.
2. İlk slayta erişin.
3. Bir şekil ekleyin.
4. Şeklin metin çerçevesine metin ekleyin.
5. Aynı koordinatlarla başka bir şekil ekleyin.
6. Şekilleri yeniden sırala.
7. Dosyayı diske kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Interop Şekil Kimliğini Alma**
Aspose.Slides for C++ geliştiricilerin UniqueId özelliğinin aksine, slayt kapsamı içinde benzersiz bir şekil tanımlayıcısı almasına izin verir; UniqueId özelliği sunum kapsamında benzersiz bir tanımlayıcı sağlar. OfficeInteropShapeId özelliği IShape arayüzlerine ve Shape sınıfına eklenmiştir. OfficeInteropShapeId özelliği tarafından döndürülen değer, Microsoft.Office.Interop.PowerPoint.Shape nesnesinin Id değerine karşılık gelir. Aşağıda örnek kod verilmiştir.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **AlternativeText Özelliğini Ayarlama**
Aspose.Slides for C++ geliştiricilerin herhangi bir şeklin AlternativeText özelliğini ayarlamasına izin verir. Bir şeklin AlternativeText özelliğini ayarlamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının örneğini oluşturun.
2. İlk slayta erişin.
3. Slayta herhangi bir şekil ekleyin.
4. Yeni eklenen şekille bazı işlemler yapın.
5. Şekilleri dolaşarak bir şekil bulun.
6. AlternativeText'i ayarlayın.
7. Dosyayı diske kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **Bir Şekil İçin Düzen Formatlarına Erişim**
Aspose.Slides for C++ geliştiricilerin bir şekil için düzen formatlarına erişmesine olanak tanır. Bu makale, bir şekil için **FillFormat** ve **LineFormat** özelliklerine nasıl erişileceğini gösterir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Şekli SVG Olarak Render Etme**
Şimdi Aspose.Slides for C++ bir şekli SVG olarak render etme desteğine sahiptir. WriteAsSvg yöntemi (ve aşırı yüklemesi) Shape sınıfına ve IShape arayüzüne eklenmiştir. Bu yöntem, şeklin içeriğini bir SVG dosyası olarak kaydetmeye imkan verir. Aşağıdaki kod parçacığı, slaydın şeklinin bir SVG dosyasına nasıl dışa aktarılacağını gösterir.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Şekil Hizalama**
Aspose.Slides, şekilleri slayt kenar boşluklarına göre ya da birbirlerine göre hizalamaya izin verir. Bu amaçla, aşırı yüklenmiş bir [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) yöntemi eklenmiştir. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) enumarasyonu olası hizalama seçeneklerini tanımlar.

**Örnek 1**

Aşağıdaki kaynak kod, 1, 2 ve 4 indeksli şekilleri slaydın üst kenarı boyunca hizalar.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Örnek 2**

Aşağıdaki örnek, şekil koleksiyonundaki en alttaki şekle göre tüm koleksiyonun nasıl hizalanacağını gösterir.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **Flip Özellikleri**
Aspose.Slides içinde, [ShapeFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapeframe/) sınıfı, `flipH` ve `flipV` özellikleri aracılığıyla şekillerin yatay ve dikey yansımasını kontrol eder. Her iki özellik de [NullableBool](https://reference.aspose.com/slides/tr/cpp/aspose.slides/nullablebool/) türündedir; `True` değeri bir yansıtma, `False` yansıtma yok ve `NotDefined` varsayılan davranışı kullan anlamına gelir. Bu değerler bir şeklin [Frame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_frame/) üzerinden erişilebilir.

Flip ayarlarını değiştirmek için, şeklin mevcut konumu ve boyutu, istenen `flipH` ve `flipV` değerleri ve dönüş açısı ile yeni bir [ShapeFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shapeframe/) örneği oluşturulur. Bu örnek şeklin [Frame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_frame/) özelliğine atanır ve sunum kaydedildiğinde yansıma dönüşümleri uygulanır ve çıktı dosyasına işlenir.

Örneğin, ilk slaytta varsayılan flip ayarlarına sahip tek bir şekil içeren bir sample.pptx dosyamız olduğunu varsayalım; aşağıda gösterilmiştir.

![The shape to be flipped](shape_to_be_flipped.png)

Aşağıdaki kod örneği, şeklin mevcut flip özelliklerini alır ve hem yatay hem de dikey olarak çevirir.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Şeklin yatay çevirme özelliğini al.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Şeklin dikey çevirme özelliğini al.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Yatay olarak çevir.
auto flipV = NullableBool::True; // Yatay olarak çevir.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![The flipped shape](flipped_shape.png)

## **SSS**

**Bir masaüstü düzenleyicide olduğu gibi bir slaytta şekilleri (birleştirme/kesişim/çıkarma) birleştirebilir miyim?**

Yerleşik bir Boolean işlem API'si bulunmamaktadır. İstenilen konturu kendiniz oluşturup (örneğin [GeometryPath](https://reference.aspose.com/slides/tr/cpp/aspose.slides/geometrypath/) ile sonuç geometrisini hesaplayarak) yeni bir şekil yaratabilir, isteğe bağlı olarak orijinal şekilleri kaldırabilirsiniz.

**Bir şeklin her zaman “üstte” kalması için yığılma sırasını (z-order) nasıl kontrol edebilirim?**

Şeklin bulunduğu slaydın [shapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseslide/get_shapes/) koleksiyonundaki ekleme/taşıma sırasını değiştirin. Öngörülebilir sonuçlar için, diğer tüm slayt değişikliklerinden sonra z-order'ı sonlandırın.

**PowerPoint'te kullanıcıların şekli düzenlemesini önlemek için bir şekli “kilitleyebilir” miyim?**

Evet. [shape-level protection flags](/slides/tr/cpp/applying-protection-to-presentation/) (örneğin seçim, hareket, yeniden boyutlandırma, metin düzenleme kilidi) ayarlayın. Gerekirse bu kısıtlamaları master veya layout üzerinde de uygulayın. Bu UI düzeyinde bir korumadır, güvenlik özelliği değildir; daha güçlü koruma için [salt okunur önerileri veya parolalar](/slides/tr/cpp/password-protected-presentation/) gibi dosya seviyesinde kısıtlamalarla birleştirin.
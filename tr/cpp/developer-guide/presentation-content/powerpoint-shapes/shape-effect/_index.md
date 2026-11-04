---
title: C++ Kullanarak Sunumlarda Şekil Efektleri Uygulama
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/cpp/shape-effect/
keywords:
- şekil efekti
- gölge efekti
- yansıma efekti
- parıltı efekti
- yumuşak kenarlar efekti
- efekt formatı
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün — saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki etkiler, bir şekli öne çıkarmak için kullanılabilirken, [doldurmalar](/slides/tr/cpp/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şekil üzerinde ikna edici yansımalar oluşturabilir, şeklin parıltısını yayabilirsiniz, vb.

![Şekil efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilecek altı efekt sunar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu yüzden PowerPoint, **Preset** altında seçenekler sunar. Preset seçenekleri, birlikte güzel görünmesi bilinen iki veya daha fazla efektin bir kombinasyonudur. Böylece bir preset seçerek, güzel bir kombinasyon bulmak için farklı efektleri denemek veya birleştirmek için zaman kaybetmezsiniz.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) sınıfı altında özellikler ve metodlar sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for C++ şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklık yarıçapını sunum tasarımınıza uygun şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygulama**

Bir kartı veya paneli slayt arka planına karşı öne çıkarmak için dış gölge kullanın. Gölge, şeklin kenarlarının ötesine uzanarak şeklin slayt üzerinde yükselmiş gibi görünmesini sağlar. Renk, yön, mesafe ve bulanıklık yarıçapını şablonunuzun aydınlatması ve stiline uygun şekilde ayarlayın.

Bu C++ kodu, bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) uygulamayı gösterir:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![Gölge efekti](shadow_effect.png)

### **İç Gölge Uygulama**

Bir şablonun görsel stilini yeniden üretirken, bir kartı veya paneli gömülmüş bir görünüm kazandırmak için iç gölge kullanın. Dış gölge şeklin dışına uzanarak yükselmiş görünmesini sağlarken, iç gölge kenarların iç kısmını gölgelendirir.

[EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) metodunu çağırın, ardından [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) ayarlayın. Daha büyük bulanıklık yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu C++ örneği, açık mavi bir kartı koyu gri iç gölge ile oluşturur ve PPTX dosyası olarak kaydeder:

```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![İç gölgelikli açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için, şeklin effect formatında [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) metodunu çağırın.

## **Yansıma Efekti Uygulama**

Aspose.Slides for C++'da yansıma efekti uygulamak için şekillere ayna benzeri bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit kodla kolayca uygulanabilir ve tutarlı bir tasarım için birden çok öğeye hızlıca uygulanmasını sağlar.

Bu C++ kodu, bir şekle [yansıma efekti](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) uygulamayı gösterir:

```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![Yansıma efekti](reflection_effect.png)

## **Parıltı Efekti Uygulama**

Aspose.Slides for C++'da bir şekle parıltı efekti uygulamak için renk ve boyut gibi özellikleri ayarlayarak şekillerin etrafına yumuşak, ışıklı bir aura ekleyebilirsiniz. Bu efekt, şekilleri öne çıkarmaya yardımcı olur ve sunumunuza çekici, göz alıcı bir görsel unsur ekler. Minimum kodla kolayca uygulanabilir ve slaytlarınızın genel görünümünü iyileştirir.

Bu C++ kodu, bir şekle [parıltı efekti](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) uygulamayı gösterir:

```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![Parıltı efekti](glow_effect.png)

## **Yumuşak Kenarlar Efekti Uygulama**

Aspose.Slides for C++'da yumuşak kenarlar efekti uygulamak için bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha nazik ve rafine bir görünüm ekler; nazik, daha yumuşak bir görünüm gerektiren tasarımlar için mükemmeldir. Sunumunuzdaki çeşitli şekillerde istenen etkiyi elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

Bu C++ kodu, bir şekle [yumuşak kenarlar](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) uygulamayı gösterir:

```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![Yumuşak kenarlar efekti](soft_edges_effect.png)

## **Bulanıklık Efekti Uygulama**

Şekil bulanıklığını, şeklin doldurmasını ve kenarlığını yumuşatmak, fakat şekli düzenlenebilir tutmak için kullanın. Şeklin effect formatında [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) metodunu çağırın. Yarıçap, nokta cinsinden ölçülür (1/72 inç): negatif olmayan bir değer kullanın; daha büyük değerler daha güçlü bulanıklık üretir. Sıfır yarıçap görünümü değiştirmez.

[Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) ayarı, etkinin görünür sınırlarını kontrol eder. `false` olduğunda, bulanıklık orijinal boyanmış sınırlara, kenarlık dahil, kırpılır. `true` olduğunda, bulanıklık bu sınırların ötesine uzanabilir. Hiçbir ayar şeklin konumunu veya boyutlarını değiştirmez.

Aşağıdaki karşılaştırma, aynı doldurmayı, kenarlığı ve şekil boyutlarını kullanır. Üst satır `grow = false`; alt satır `grow = true` kullanır.

![Büyütme devre dışı ve etkin iken 5 ve 15 nokta yarıçaplı bulanıklıkla karşılaştırılan orijinal dikdörtgen](shape_blur_comparison.png)

Bu C++ örneği, koyu mavi bir kenarlığa sahip turuncu bir dikdörtgen oluşturur, 5 noktalık bir bulanıklık uygular ve ardından [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) metodunu tekrar çağırarak 15 noktalık bir bulanıklığa günceller. Her iki bulanık durumu kaydeder, ardından [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) metodunu çağırır ve şekli bulanıklık olmadan kaydeder.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

Şekil bulanıklığı, doldurma ve kenarlığı birlikte etkiler. Yumuşak kenarlar efekti, şeklin kenarlarını solarken, gölge bulanıklığı yalnızca gölgeyi yumuşatır. Görüntü dönüşüm efektleri görüntü içeriği üzerinde çalışır; bu örnek, şekli bir görsele dönüştürmeden doğrudan şeklin effect formatına bulanıklık uygular.

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, gölge, yansıma ve parıltı gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Etki, tüm grup üzerine uygulanır.
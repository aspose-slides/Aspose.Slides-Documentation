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

PowerPoint'teki efektler bir şeklin öne çıkmasını sağlamak için kullanılabilir, ancak [fills](/slides/tr/cpp/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şeklin üzerine ikna edici yansımalar ekleyebilir, şeklin parlaklığını yayabilir vb.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint, şekillere uygulanabilen altı efekt sağlar. Bir şekle bir veya birden fazla efekt uygulayabilirsiniz. 

* Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri, temelde iki veya daha fazla efektten oluşan iyi görünen bir kombinasyondur. Böylece bir preset seçerek, farklı efektleri denemek veya birleştirmek için zaman kaybetmezsiniz.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.effect_format/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Bu C++ kodu, bir dikdörtgene dış gölge efekti ([OuterShadowEffect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) uygulamayı gösterir:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(System::Drawing::Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Yansıma Efekti Uygulama**

Bu C++ kodu, bir şekle yansıma efekti uygulamayı gösterir:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(55);
reflectionEffect->set_BlurRadius(4);

pres->Save(u"reflection.pptx", SaveFormat::Pptx);
```

## **Parıltı Efekti Uygulama**

Bu C++ kodu, bir şekle parıltı efekti uygulamayı gösterir:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(System::Drawing::Color::get_Magenta());
glowEffect->set_Radius(15);

pres->Save(u"glow.pptx", SaveFormat::Pptx);
```

## **Yumuşak Kenarlar Efekti Uygulama**

Bu C++ kodu, bir şekle yumuşak kenarlar uygulamayı gösterir:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(15);

pres->Save(u"softEdges.pptx", SaveFormat::Pptx);
```

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, gölge, yansıma ve parıltı gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplanmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt tüm grup üzerine uygulanır.
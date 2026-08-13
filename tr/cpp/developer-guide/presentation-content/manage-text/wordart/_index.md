---
title: C++'da WordArt Efektleri Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/cpp/wordart/
keywords:
- WordArt
- WordArt Oluştur
- WordArt Şablonu
- WordArt Efekti
- Gölge Efekti
- Görüntü Efekti
- Parlama Efekti
- WordArt Dönüşümü
- 3D Efekti
- Dış Gölge Efekti
- İç Gölge Efekti
- PowerPoint
- Sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım kılavuz, geliştiricilerin C++ ile profesyonel metinle sunumları geliştirmelerine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, PowerPoint sunumlarınıza görsel olarak çekici, stilize metin eklemenizi sağlar. Aspose.Slides ile geliştiriciler, Microsoft PowerPoint’te yaptıkları gibi WordArt’ı programatik olarak oluşturabilir, özelleştirebilir ve yönetebilir—Office yüklü olmasına gerek yok. Bu makale, WordArt ile çalışmaya genel bir bakış sunar; metin dönüşümleri, dolgu stilleri, hatlar, gölgeler ve diğer biçimlendirme seçeneklerini nasıl uygulayacağınızı gösterir, böylece sunum içeriğinizi daha etkileyici ve ilgi çekici hâle getirebilirsiniz. WordArt, metni bir grafik nesne gibi ele almanıza olanak tanır. Metni daha çekici veya dikkat çekici hâle getirmek için uygulanan efektler veya özel düzenlemelerden oluşur.

## **Basit bir WordArt Şablonu Oluşturun ve Metne Uygulayın**

**Aspose.Slides Kullanarak**  

İlk olarak, bu C++ kodu ile basit bir metin oluşturuyoruz:

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Şimdi, efekti daha belirgin hâle getirmek için metnin yazı tipi yüksekliğini daha büyük bir değere ayarlıyoruz:

``` cpp 
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Microsoft PowerPoint Kullanarak**

Microsoft PowerPoint’te WordArt efektleri menüsüne gidin:

![todo:image_alt_text](image-20200930113926-1.png)

Sağdaki menüden önceden tanımlı bir WordArt efekti seçebilirsiniz. Soldaki menüden yeni bir WordArt için ayarları belirtebilirsiniz.

Mevcut bazı parametreler veya seçenekler şunlardır:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides Kullanarak**

Burada, metne SmallGrid desen rengi uygular ve bu kodla 1 genişliğinde siyah bir metin kenarlığı ekleriz:

``` cpp 
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

Elde edilen metin:

![todo:image_alt_text](image-20200930114108-4.png)

## **Diğer WordArt Efektlerini Uygulayın**

**Microsoft PowerPoint Kullanarak**

Program arayüzünden bu efektleri bir metne, metin bloğuna, şekle veya benzeri bir öğeye uygulayabilirsiniz:

![todo:image_alt_text](image-20200930114129-5.png)

Örneğin, Gölge, Yansıma ve Parlama efektleri bir metne uygulanabilir; 3D Biçim ve 3D Döndürme efektleri bir metin bloğuna uygulanabilir; Yumuşak Kenarlar özelliği bir Şekil Nesnesine (3D Biçim özelliği ayarlı olmasa bile) uygulanabilir.

### **Metne Gölge Efektleri Uygulama**

Burada yalnızca metne ilişkin özellikleri ayarlamayı amaçlıyoruz. Aşağıdaki C++ kodu ile metne gölge efekti eklenir:

``` cpp 
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Aspose.Slides API üç tür gölgeyi destekler: OuterShadow, InnerShadow ve PresetShadow.

PresetShadow ile önceden tanımlı değerler kullanarak bir metne gölge uygulayabilirsiniz.

**Microsoft PowerPoint Kullanarak**

PowerPoint’te yalnızca bir tür gölge kullanılabilir. İşte bir örnek:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides Kullanarak**

Aspose.Slides, aynı anda iki tür gölge uygulamanıza izin verir: InnerShadow ve PresetShadow.

**Notlar:**

- OuterShadow ve PresetShadow birlikte kullanıldığında yalnızca OuterShadow efekti uygulanır.  
- OuterShadow ve InnerShadow aynı anda kullanılırsa, uygulanan efekt PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013’te efekt iki kez uygulanır. PowerPoint 2007’de ise OuterShadow efekti uygulanır.

### **Yansıma Efektleri Uygulama**

Aşağıdaki C++ kod örneği ile metne yansıma ekliyoruz:

``` cpp 
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### **Parlama (Glow) Efektleri Uygulama**

Metne parlama efekti ekleyerek öne çıkmasını şu kodla sağlarız:

``` cpp 
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

İşlemin sonucu:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}}  
Gölge, gösterim ve parlama parametrelerini değiştirebilirsiniz. Efekt özellikleri, metnin her bölümü için ayrı ayrı ayarlanır.  
{{% /alert %}}  

### **WordArt’ta Dönüşümler Kullanma**

Aşağıdaki kod ile tüm metin bloğu üzerinde set_Transform metodunu (yerleşik) kullanıyoruz:

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Sonuç:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}}  
Hem Microsoft PowerPoint hem de Aspose.Slides for C++ belirli sayıda önceden tanımlı dönüşüm türü sağlar.  
{{% /alert %}}  

**PowerPoint Kullanarak**

Önceden tanımlı dönüşüm türlerine erişmek için şu yolu izleyin: **Format** -> **TextEffect** -> **Transform**

**Aspose.Slides Kullanarak**

Bir dönüşüm türü seçmek için TextShapeType enum’ını kullanın.

### **Metin ve Şekillere 3D Efektleri Uygulama**

Aşağıdaki örnek kod ile bir metin şekline 3D efekt ayarları yapılır:

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
autoShape->get_TextFrame()->set_Text(u"Aspose.Slides");

auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Elde edilen metin ve şekli:

![todo:image_alt_text](image-20200930114816-9.png)

Metne 3D efektini bu C++ kodu ile uyguluyoruz:

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

İşlemin sonucu:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}}  
Metinlere veya şekillerine 3D efektlerinin uygulanması ve efektler arasındaki etkileşimler belirli kurallara dayanır.  

Bir metin ve onu içeren şekil için bir sahne düşünün. 3D efekt, 3D nesne temsili ve nesnenin yerleştirildiği sahneyi içerir.  

- Sahne hem şekil hem de metin için ayarlandığında, şekil sahnesi öncelikli olur—metin sahnesi göz ardı edilir.  
- Şeklin kendi sahnesi yoksa ancak 3D temsili varsa, metin sahnesi kullanılır.  
- Aksi takdirde—şeklin başlangıçta 3D etkisi yoksa—şekil düz kalır ve 3D efekt yalnızca metne uygulanır.  

Bu açıklamalar ThreeDFormat.getLightRig() ve ThreeDFormat.getCamera() metodlarıyla bağlantılıdır.  
{{% /alert %}}  

## **Şekillere Dış Gölge Efektleri Uygulama**
Aspose.Slides for C++ aşağıdaki sınıfları sunar: [**IOuterShadow**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.effects.i_outer_shadow) ve [**IInnerShadow**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.effects.i_inner_shadow). Bu sınıflar, TextFrame içinde taşınan metne gölge efektleri eklemenizi sağlar. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.  
2. İndeksini kullanarak bir slayt referansı alın.  
3. Slayta Rectangle türünde bir AutoShape ekleyin.  
4. AutoShape ile ilişkili TextFrame’e erişin.  
5. AutoShape’in FillType’ını NoFill olarak ayarlayın.  
6. OuterShadow sınıfını örnekleyin.  
7. Gölgenin BlurRadius değerini ayarlayın.  
8. Gölgenin Direction değerini ayarlayın.  
9. Gölgenin Distance değerini ayarlayın.  
10. RectangleAlign değerini TopLeft olarak ayarlayın.  
11. Gölgenin PresetColor değerini Black olarak ayarlayın.  
12. Sunumu PPTX dosyası olarak kaydedin.  

Aşağıdaki C++ örnek kodu, yukarıdaki adımları uygulayarak bir metne dış gölge efekti nasıl eklenir gösterir:

``` cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
// Slayt referansını al
auto sld = pres->get_Slides()->idx_get(0);

// Rectangle türünde bir AutoShape ekle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Rectangle'a TextFrame ekle
ashp->AddTextFrame(u"Aspose TextBox");

// Metnin gölgesini alabilmek için şekil dolgusunu devre dışı bırak
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Dış gölge ekle ve gerekli tüm parametreleri ayarla
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Sunumu diske kaydet
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **Şekillere İç Gölge Efektleri Uygulama**
Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.  
2. Slayt referansını alın.  
3. Rectangle türünde bir AutoShape ekleyin.  
4. InnerShadowEffect’i etkinleştirin.  
5. Gerekli tüm parametreleri ayarlayın.  
6. ColorType değerini Scheme olarak belirleyin.  
7. Scheme Color’ı ayarlayın.  
8. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.  

Aşağıdaki örnek kod (yukarıdaki adımlara dayanarak) iki şekil arasında bir bağlayıcı eklemenin C++’da nasıl yapılacağını gösterir:

``` cpp
#include <DOM/ColorType.h>
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// Slayt referansını al
auto slide = presentation->get_Slides()->idx_get(0);

// Rectangle türünde bir AutoShape ekle
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Rectangle'a TextFrame ekle
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// İç Gölge Etkisini Etkinleştir    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Gerekli tüm parametreleri ayarla
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Renk türünü Scheme olarak ayarla
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Scheme Rengini ayarla
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Sunumu kaydet
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **SSS**

### Farklı yazı tipleri veya betikler (ör. Arapça, Çince) ile WordArt efektleri kullanabilir miyim?

Evet, Aspose.Slides Unicode’u destekler ve tüm büyük yazı tipleri ve betiklerle çalışır. Gölge, doldurma ve hat gibi WordArt efektleri dil bağımsızdır; ancak yazı tipi bulunabilirliği ve işlenmesi sistem yazı tiplerine bağlı olabilir.

### WordArt efektlerini slayt ana sayfa öğelerine uygulayabilir miyim?

Evet, ana slayt üzerindeki şekillere, başlık yer tutucularına, altbilgilere veya arka plan metnine WordArt efektleri uygulayabilirsiniz. Ana sayfa düzeninde yapılan değişiklikler tüm ilgili slaytlara yansır.

### WordArt efektleri sunum dosyasının boyutunu etkiler mi?

Biraz. Gölge, parlama ve degrade doldurma gibi WordArt efektleri, ek biçimlendirme meta verileri eklediği için dosya boyutunu hafifçe artırabilir; ancak fark genellikle önemsizdir.

### Sunumu kaydetmeden WordArt efektlerinin sonucunu önizleyebilir miyim?

Evet, WordArt içeren slaytları `GetImage` yöntemiyle (ör. PNG, JPEG) görüntülere dönüştürebilirsiniz. Bu sayede tam sunumu kaydetmeden veya dışa aktarmadan hafızada veya ekranda önizleme yapabilirsiniz.
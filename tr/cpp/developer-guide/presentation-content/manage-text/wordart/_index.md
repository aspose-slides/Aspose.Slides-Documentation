---
title: C++'ta WordArt Efektleri Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/cpp/wordart/
keywords:
- WordArt
- WordArt oluştur
- WordArt şablonu
- WordArt efekti
- gölge efekti
- gösterim efekti
- parıltı efekti
- WordArt dönüşümü
- 3D efekti
- dış gölge efekti
- iç gölge efekti
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım rehber, geliştiricilerin C++'ta profesyonel metinle sunumları geliştirmelerine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, PowerPoint sunumlarınıza görsel olarak çekici, stilize metin eklemenizi sağlar. Aspose.Slides ile geliştiriciler, Microsoft PowerPoint’te olduğu gibi WordArt’i programlı olarak oluşturabilir, özelleştirebilir ve yönetebilir—Office yüklü olmasına gerek olmadan. Bu makale, metin dönüşümleri, doldurma stilleri, konturlar, gölgeler ve diğer biçimlendirme seçeneklerini uygulayarak sunum içeriğinizi daha ifadeli ve etkileyici hâle getirmeyi kapsayan WordArt ile çalışma hakkında bir genel bakış sunar. WordArt, metni bir grafik nesne olarak ele almanıza olanak tanır. Metni daha çekici veya dikkat çekici kılmak için uygulanan efektler veya özel değişikliklerden oluşur.

## **Basit Bir WordArt Şablonu Oluşturun ve Metne Uygulayın**

**Aspose.Slides Kullanarak** 

İlk olarak, bu C++ kodunu kullanarak basit bir metin oluşturuyoruz: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Şimdi, metnin yazı tipi yüksekliğini daha büyük bir değere ayarlayarak efekti daha belirgin hâle getiriyoruz: 

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Microsoft PowerPoint Kullanarak**

Microsoft PowerPoint’te WordArt efektleri menüsüne gidin: 

![todo:image_alt_text](image-20200930113926-1.png)

Sağdaki menüden önceden tanımlı bir WordArt efekti seçebilir, soldaki menüden yeni bir WordArt için ayarları belirtebilirsiniz. 

Mevcut bazı parametreler veya seçenekler şunlardır: 

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides Kullanarak**

Burada, metne SmallGrid desen rengini uyguluyor ve bu kodu kullanarak 1 birim genişliğinde siyah bir metin kenarlığı ekliyoruz: 

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

Ortaya çıkan metin: 

![todo:image_alt_text](image-20200930114108-4.png)

## **Diğer WordArt Efektlerini Uygulama**

**Microsoft PowerPoint Kullanarak**

Programın arayüzünden bu efektleri bir metne, metin bloğuna, şekle veya benzeri bir öğeye uygulayabilirsiniz: 

![todo:image_alt_text](image-20200930114129-5.png)

Örneğin, Gölge, Yansıma ve Parıltı efektleri bir metne; 3D Biçim ve 3D Döndürme efektleri bir metin bloğuna; Yumuşak Kenarlar özelliği bir Şekil Nesnesine uygulanabilir (3D Biçim özelliği ayarlı olmasa bile etkisi vardır). 

### **Metne Gölge Efektleri Uygulama**

Burada yalnızca metne ilişkin özellikleri ayarlamayı amaçlıyoruz. Bu C++ kodunu kullanarak metne gölge etkisi uyguluyoruz: 

``` cpp 
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

PresetShadow ile önceden tanımlı değerleri kullanarak metne gölge uygulayabilirsiniz. 

**Microsoft PowerPoint Kullanarak**

PowerPoint’te tek bir gölge türü kullanılabilir. İşte bir örnek: 

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides Kullanarak**

Aspose.Slides, aynı anda iki tür gölge uygulamanıza olanak tanır: InnerShadow ve PresetShadow. 

Notlar: 

- OuterShadow ve PresetShadow birlikte kullanıldığında, yalnızca OuterShadow efekti uygulanır. 
- OuterShadow ve InnerShadow aynı anda kullanılırsa, ortaya çıkan veya uygulanan efekt PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013’te efekt iki kat olur. Ancak PowerPoint 2007’de OuterShadow efekti uygulanır. 

### **Yansıma Efektleri Uygulama**

Bu C++ kod örneği ile metne yansıma ekliyoruz: 

``` cpp 
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

### **Parıltı Efektleri Uygulama**

Bu kodu kullanarak metne parıltı efekti uyguluyor ve parlak ya da öne çıkmasını sağlıyoruz: 

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

İşlemin sonucu: 

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Gölge, gösterim ve parıltı parametrelerini değiştirebilirsiniz. Efektlerin özellikleri metnin her kısmına ayrı ayrı ayarlanır. 
{{% /alert %}} 

### **WordArt’ta Dönüşümleri Kullanma**

Bu kod aracılığıyla set_Transform metodunu (tüm metin bloğu için geçerli) kullanıyoruz: 

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Sonuç: 

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint ve C++ için Aspose.Slides, belirli sayıda önceden tanımlı dönüşüm tipi sunar. 
{{% /alert %}} 

**PowerPoint Kullanarak**

Önceden tanımlı dönüşüm türlerine erişmek için şu adımları izleyin: **Format** -> **TextEffect** -> **Transform**  

**Aspose.Slides Kullanarak**

Dönüşüm türünü seçmek için TextShapeType enum’ını kullanın.  

### **Metin ve Şekillere 3D Efektleri Uygulama**

Bu örnek kodu kullanarak bir metin şekline 3D efekt uyguluyoruz: 

``` cpp 
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

Ortaya çıkan metin ve şekli: 

![todo:image_alt_text](image-20200930114816-9.png)

Bu C++ kodu ile metne 3D efekt uyguluyoruz: 

``` cpp 
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

{{% alert color="primary" %}} 
Metinlere veya şekillerine 3D efekt uygulamaları ve efektler arasındaki etkileşimler belirli kurallara dayanır.

Bir metin ve o metni içeren şekil için bir sahneyi düşünün. 3D efekt, 3D nesne temsili ve nesnenin yerleştirildiği sahneyi içerir.

- Sahne hem şekil hem de metin için ayarlandığında, şekil sahnesi daha yüksek önceliğe sahiptir—metin sahnesi yok sayılır.
- Şeklin kendi sahnesi yok ancak 3D temsili varsa, metin sahnesi kullanılır.
- Aksi taktirde—şeklin başlangıçta 3D etkisi yoksa—şekil düzdür ve 3D efekt yalnızca metne uygulanır.

Bu açıklamalar ThreeDFormat.getLightRig() ve ThreeDFormat.getCamera() yöntemleriyle ilişkilidir. 
{{% /alert %}} 

## **Şekillere Dış Gölge Efektleri Uygulama**
C++ için Aspose.Slides, TextFrame içinde taşınan bir metne gölge efektleri uygulamanızı sağlayan [**IOuterShadow**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.effects.i_outer_shadow) ve [**IInnerShadow**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.effects.i_inner_shadow) sınıflarını sunar. Bu adımları izleyin:

1. **Presentation** sınıfının bir örneğini oluşturun.  
2. Slaytın indeksini kullanarak referansını alın.  
3. Slayta Dikdörtgen tipinde bir AutoShape ekleyin.  
4. AutoShape ile ilişkili TextFrame’e erişin.  
5. AutoShape’in FillType özelliğini NoFill olarak ayarlayın.  
6. OuterShadow sınıfını örnekleyin.  
7. Gölgenin BlurRadius değerini ayarlayın.  
8. Gölgenin Direction (yön) değerini ayarlayın.  
9. Gölgenin Distance (mesafe) değerini ayarlayın.  
10. RectanglelAlign değerini TopLeft olarak ayarlayın.  
11. Gölgenin PresetColor değerini Black olarak ayarlayın.  
12. Sunumu PPTX dosyası olarak kaydedin.  

Yukarıdaki adımların C++ hâlindeki örnek kodu, bir metne dış gölge etkisi nasıl uygulanır gösterir: 

``` cpp
auto pres = System::MakeObject<Presentation>();
// Slayt referansını al
auto sld = pres->get_Slides()->idx_get(0);

// Dikdörtgen tipinde bir AutoShape ekle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Dikdörtgene TextFrame ekle
ashp->AddTextFrame(u"Aspose TextBox");

// Metnin gölgesini alabilmek için şekil dolgusu devre dışı bırak
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
Bu adımları izleyin:

1. **Presentation** sınıfının bir örneğini oluşturun.  
2. Slaytın referansını alın.  
3. Dikdörtgen tipinde bir AutoShape ekleyin.  
4. InnerShadowEffect’i etkinleştirin.  
5. Gerekli tüm parametreleri ayarlayın.  
6. ColorType değerini Scheme olarak ayarlayın.  
7. Scheme rengini belirleyin.  
8. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.  

Bu örnek kod (yukarıdaki adımlara dayanarak) iki şekil arasında bir bağlayıcı eklemenin C++ kodunu gösterir: 

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Bir slaydın referansını al
auto slide = presentation->get_Slides()->idx_get(0);

// Dikdörtgen tipinde bir AutoShape ekle
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Dikdörtgene TextFrame ekle
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// İç gölge efektini etkinleştir
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Gerekli tüm parametreleri ayarla
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// ColorType'ı Scheme olarak ayarla
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Scheme rengini ayarla
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Sunumu kaydet
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Farklı yazı tipleri veya betiklerle (ör. Arapça, Çince) WordArt efektleri kullanabilir miyim?**

Evet, Aspose.Slides Unicode desteğine sahiptir ve tüm başlıca yazı tipleri ve betiklerle çalışır. Gölge, doldurma ve kontur gibi WordArt efektleri dilinden bağımsız olarak uygulanabilir; ancak yazı tipi bulunabilirliği ve renderleme sistem yazı tiplerine bağlı olabilir.

**WordArt efektlerini slayt master öğelerine uygulayabilir miyim?**

Evet, WordArt efektlerini master slayt üzerindeki şekillere, başlık yer tutucularına, altbilgilere veya arka plan metnine uygulayabilirsiniz. Master düzeninde yapılan değişiklikler, ilişkili tüm slaytlara yansır.

**WordArt efektleri sunum dosya boyutunu etkiler mi?**

Biraz. Gölgeler, parıltılar ve degrade doldurmalar gibi WordArt efektleri, ek biçimlendirme meta verileri nedeniyle dosya boyutunu hafifçe artırabilir, fakat fark genellikle ihmal edilebilir.

**Sunumu kaydetmeden WordArt efektlerinin sonucunu önizleyebilir miyim?**

Evet, WordArt içeren slaytları PNG, JPEG gibi resimlere dönüştürmek için [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) veya [ISlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/) arayüzlerinin `GetImage` metodunu kullanabilirsiniz. Böylece sunumu kaydetmeden veya dışa aktarmadan bellekte ya da ekranda sonucu önizleyebilirsiniz.
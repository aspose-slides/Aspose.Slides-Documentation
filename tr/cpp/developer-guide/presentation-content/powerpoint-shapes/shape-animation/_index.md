---
title: C++ Kullanarak Sunumlarda Şekil Animasyonları Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/cpp/shape-animation/
keywords:
- şekil
- animasyon
- efekt
- animasyonlu şekil
- animasyonlu metin
- animasyon ekle
- animasyon al
- animasyon çıkart
- efekt ekle
- efekt al
- efekt çıkart
- efekt sesi
- animasyon uygula
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint sunumlarında şekil animasyonları oluşturmayı ve özelleştirmeyi keşfedin. Öne çıkın!"
---
## **Giriş**

Animasyonlar, metinlere, görüntülere, şekillere veya [grafiklere](/slides/tr/cpp/animated-charts/) uygulanabilen görsel efektlerdir. Sunumlara veya onların bileşenlerine yaşam verir. 

## **Sunumlarda Animasyonları Neden Kullanmalısınız?**

* bilgi akışını kontrol et
* önemli noktaları vurgula
* seyircileriniz arasında ilgiyi veya katılımı artır
* içeriği okumayı, özümsemeyi veya işlemi daha kolay hale getir
* okuyucularınızın veya izleyicilerinizin dikkatini sunumdaki önemli bölümlere çek

PowerPoint, **giriş**, **çıkış**, **vurgulama** ve **hareket yolları** kategorileri kapsamında animasyonlar ve animasyon efektleri için birçok seçenek ve araç sağlar. 

## **Aspose.Slides'ta Animasyonlar**

* Aspose.Slides, animasyonlarla çalışmak için gereken sınıfları ve türleri [Aspose.Slides.Animation](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.animation) ad alanı altında sağlar,
* Aspose.Slides, [EffectType](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) sayımında **150** animasyon efekti sağlar. Bu efektler temelde PowerPoint'te kullanılan aynı (veya eşdeğer) efektlerdir.

## **Metin Kutusuna Animasyon Uygulama**

Aspose.Slides for C++, bir şeklin içindeki metne animasyon uygulamanıza olanak tanır. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation/) sınıfının bir örneğini oluşturun.
2. İndeks aracılığıyla bir slaytın referansını alın.
3. Bir `rectangle` [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) ekleyin. 
4. Metni [IAutoShape.TextFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3)'e ekleyin.
5. Efektlerin ana sırasını alın.
6. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape)'e bir animasyon efekti ekleyin. 
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) özelliğini [BuildType Enumeration](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) değerine ayarlayın.
8. Sunumu bir PPTX dosyası olarak diske yazın.

Bu C++ kodu, `Fade` efektini AutoShape'e nasıl uygulayacağınızı ve metin animasyonunu *By 1st Level Paragraphs* değerine nasıl ayarlayacağınızı gösterir:

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Sunum dosyasını temsil eden bir sunum sınıfını örnekler.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adds new AutoShape with text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Adds Fade animation effect to shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animates shape text by 1st level paragraphs
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Save the PPTX file to disk
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

Metinlere animasyon uygulamanın yanı sıra, tek bir [Paragraph](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_paragraph)'e de animasyon uygulayabilirsiniz. Bakınız [**Animasyonlu Metin**](/slides/tr/cpp/animated-text/).

{{% /alert %}} 

## **Resim Çerçevesine Animasyon Uygulama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation/) sınıfının bir örneğini oluşturun.
2. İndeks aracılığıyla bir slaytın referansını alın.
3. Slaytta bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_picture_frame) ekleyin veya alın. 
4. Efektlerin ana sırasını alın.
5. [PictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_picture_frame)'e bir animasyon efekti ekleyin.
6. Sunumu bir PPTX dosyası olarak diske yazın.

Bu C++ kodu, `Fly` efektini bir resim çerçevesine nasıl uygulayacağınızı gösterir:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Bir sunum dosyasını temsil eden bir sunum sınıfını örnekler.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Sunumun görüntü koleksiyonuna eklenecek resmi yükle
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Slayta resim çerçevesi ekler
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Slaydın ana dizisini alır.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Resim çerçevesine Soldan Uçuş animasyon efektini ekler
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// PPTX dosyasını diske kaydeder
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Şekle Animasyon Uygulama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation/) sınıfının bir örneğini oluşturun.
2. İndeks aracılığıyla bir slaytın referansını alın.
3. Bir `rectangle` [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) ekleyin. 
4. `Bevel` bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) ekleyin (bu nesne tıklandığında animasyon oynatılır).
5. `Bevel` şekli üzerinde bir efekt dizisi oluşturun.
6. Özel bir `UserPath` oluşturun.
7. `UserPath`'e hareket etmek için komutlar ekleyin.
8. Sunumu bir PPTX dosyası olarak diske yazın.

Bu C++ kodu, bir şekle `PathFootball` (yol futbolu) efektini nasıl uygulayacağınızı gösterir:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// Belge dizini yolu.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Sunumu yükler
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// İlk slaytı alır
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Seçilen slayt için şekil koleksiyonuna erişir
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Mevcut şekil için sıfırdan PathFootball efekti oluşturur.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// PathFootBall animasyon efektini ekler
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Bir çeşit "düğme" oluşturur.
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Bu düğme için bir efekt dizisi oluşturur.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Özel bir kullanıcı yolu oluşturur. Nesnemiz yalnızca düğmeye tıklandıktan sonra hareket ettirilecektir.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	 // Oluşturulan yol boş olduğu için hareket komutları ekler.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // PPTX dosyasını diske yazar
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bir Şekle Uygulanan Animasyon Efektlerini Al**

Aşağıdaki örnekler, bir şekle uygulanan tüm animasyon efektlerini almak için [ISequence](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/) arabirimindeki `GetEffectsByShape` yöntemini nasıl kullanacağınızı gösterir.

### **Örnek 1: Normal bir slaytta bir şekle uygulanan animasyon efektlerini al**

Daha önce, PowerPoint sunumlarındaki şekillere animasyon efektleri eklemeyi öğrenmiştiniz. Aşağıdaki örnek kod, `AnimExample_out.pptx` sunumundaki ilk normal slayttaki ilk şekle uygulanan efektleri nasıl alacağınızı gösterir:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Gets the main animation sequence of the slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on the first slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Gets animation effects applied to the shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

### **Örnek 2: Yer tutuculardan miras alınanlar dahil tüm animasyon efektlerini al**

Eğer normal bir slayttaki bir şeklin, düzen slaytı ve/veya ana slayt üzerinde yer tutucuları varsa ve bu yer tutuculara animasyon efektleri eklenmişse, şeklin tüm efektleri slayt gösterisi sırasında oynatılır; bu, yer tutuculardan miras alınan efektleri de içerir.

Diyelim ki `sample.pptx` adlı bir PowerPoint sunum dosyamız var; bu dosyada tek bir slayt bulunuyor ve sadece alt bilgi (footer) şekli içinde "Made with Aspose.Slides" metni var ve şekle **Random Bars** efekti uygulanmış.

![Slide shape animation effect](slide-shape-animation.png)

Ayrıca **layout** slaytındaki alt bilgi yer tutucusuna **Split** efektinin uygulandığını varsayalım.

![Layout shape animation effect](layout-shape-animation.png)

Ve son olarak, **master** slaytındaki alt bilgi yer tutucusuna **Fly In** efekti uygulanmıştır.

![Master shape animation effect](master-shape-animation.png)

Aşağıdaki örnek kod, [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) arabirimindeki `GetBasePlaceholder` yöntemini kullanarak şekil yer tutucularına erişmeyi ve alt bilgi şekline uygulanan animasyon efektlerini, düzen ve ana slaytlarda bulunan yer tutuculardan miras alınanlar dahil olmak üzere nasıl alacağınızı gösterir:

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Normal slayttaki şeklin animasyon efektlerini al.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Düzen slaydındaki yer tutucunun animasyon efektlerini al.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Ana slaydındaki yer tutucunun animasyon efektlerini al.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Uç, Alt
Type: 134, subtype: 45            // Böl, Dikeyİçeri
Type: 126, subtype: 22            // Rastgele Çubuklar, Yatay
```

## **Animasyon Efekti Zamanlama Özelliklerini Değiştir**

Aspose.Slides for C++, bir animasyon efektinin Zamanlama özelliklerini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Zamanlama bölmesidir:

![example1_image](shape-animation.png)

Bunlar, PowerPoint Zamanlama ile [Effect.Timing](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) özellikleri arasındaki eşleşmelerdir:

- PowerPoint Zamanlama **Start** açılır listesi, [Effect.Timing.TriggerType](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) özelliğiyle eşleşir. 
- PowerPoint Zamanlama **Duration** [Effect.Timing.Duration](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) özelliğiyle eşleşir. Bir animasyonun süresi (saniye cinsinden), animasyonun bir döngüyü tamamlaması için geçen toplam süredir. 
- PowerPoint Zamanlama **Delay** [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) özelliğiyle eşleşir. 

Effect Timing özelliklerini nasıl değiştirirsiniz:

1. [Apply](#apply-animation-to-shape) veya animasyon efektini alın.
2. İhtiyacınız olan [Effect.Timing](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) özelliklerine yeni değerler atayın. 
3. Değiştirilmiş PPTX dosyasını kaydedin.

Bu C++ kodu işlemi gösterir:

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Bir sunum dosyasını temsil eden bir sunum sınıfını örnekler.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Gets the first effect of main sequence.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Efektin TriggerType'ını tıklamayla başlaması için değiştirir
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Efektin süresini değiştirir
effect->get_Timing()->set_Duration(3.f);

// Efektin TriggerDelayTime'ını değiştirir
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// PPTX dosyasını diske kaydeder
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animasyon Efekti Ses**

Aspose.Slides, animasyon efektlerinde seslerle çalışmanıza olanak tanıyan şu özellikleri sağlar: 

- [set_Sound()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Animasyon Efekti Ses Ekleme**

Bu C++ kodu, bir animasyon efekti sesini nasıl ekleyeceğinizi ve bir sonraki efekt başladığında nasıl durduracağınızı gösterir:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Sunum ses koleksiyonuna ses ekler
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Slaydın ana dizisini alır.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Ana dizinin ilk efektini alır
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Efekti "Ses Yok" için kontrol eder
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // İlk efekt için ses ekler
    firstEffect->set_Sound(effectSound);
}

// Slaydın ilk etkileşimli dizisini alır.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Efektin "Önceki sesi durdur" bayrağını ayarlar
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// PPTX dosyasını diske yazar
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Animasyon Efekti Sesini Çıkarma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeks aracılığıyla bir slaytın referansını alın. 
3. Efektlerin ana sırasını alın. 
4. Her bir animasyon efektine gömülü olan [set_Sound()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effect/set_sound/) metodunu çıkarın. 

Bu C++ kodu, bir animasyon efektine gömülü sesin nasıl çıkarılacağını gösterir:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Bir sunum dosyasını temsil eden bir sunum sınıfını örnekler.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Animasyondan Sonra**

Aspose.Slides for C++, bir animasyon efektinin After animation (sonrası) özelliğini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Efekti bölmesi ve genişletilmiş menüdür:

![example1_image](shape-after-animation.png)

PowerPoint Efekti **After animation** açılır listesi şu özelliklerle eşleşir: 

- [set_AfterAnimationType()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) özelliği, After animation tipini tanımlar :
  * PowerPoint **More Colors** [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/afteranimationtype/) tipine eşittir;
  * PowerPoint **Don't Dim** seçeneği, [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/afteranimationtype/) tipine eşittir (varsayılan after animation tipi);
  * PowerPoint **Hide After Animation** seçeneği, [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/afteranimationtype/) tipine eşittir;
  * PowerPoint **Hide on Next Mouse Click** seçeneği, [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/afteranimationtype/) tipine eşittir;
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) özelliği, bir after animation renk formatı tanımlar. Bu özellik, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/afteranimationtype/) tipiyle birlikte çalışır. Tipi başka bir şeye değiştirirseniz, after animation rengi temizlenir.

Bu C++ kodu, bir after animation efektini nasıl değiştireceğinizi gösterir:

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Bir sunum dosyasını temsil eden bir sunum sınıfını örnekler.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ana dizinin ilk efektini alır.
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// After animation tipini Renk olarak değiştirir.
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// After animation karartma rengini ayarlar.
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// PPTX dosyasını diske yazar.
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Metni Animasyonla**

Aspose.Slides, bir animasyon efektinin *Animate text* (Metni Animasyonla) bloğu ile çalışmanıza olanak tanıyan şu özellikleri sağlar: 

- [set_AnimateTextType()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) özelliği, efektin animate text tipini tanımlar. Şekil metni şu şekilde animasyonlanabilir:
  * Hepsi bir anda ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/animatetexttype/) tipi)
  * Kelime kelime ([AnimateTextType.ByWord](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/animatetexttype/) tipi)
  * Harf harf ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/animatetexttype/) tipi)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) animasyonlu metin parçaları (kelimeler veya harfler) arasında bir gecikme ayarlar. Pozitif bir değer, efekt süresinin yüzdesini belirtir. Negatif bir değer ise gecikmeyi saniye cinsinden belirtir.

Effect Animate text (Efekt Metni Animasyonu) özelliklerini şu şekilde değiştirebilirsiniz:

1. [Apply](#apply-animation-to-shape) veya animasyon efektini alın.
2. [set_BuildType()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itextanimation/set_buildtype/) özelliğini [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/buildtype/) değerine ayarlayarak *By Paragraphs* (Paragraflara Göre) animasyon modunu devre dışı bırakın.
3. Yeni değerleri [set_AnimateTextType()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) ve [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) özelliklerine atayın.
4. Değiştirilmiş PPTX dosyasını kaydedin.

Bu C++ kodu işlemi gösterir:

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Bir sunum dosyasını temsil eden bir sunum sınıfını örnekler.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ana dizinin ilk efektini alır
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Efektin Metin animasyonu tipini "Tek Nesne Olarak" değiştirir
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Efektin Metni Animasyon tipini "Kelime Kelime" değiştirir
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Kelimeler arasındaki gecikmeyi efekt süresinin %20'si olarak ayarlar
firstEffect->set_DelayBetweenTextParts(20.0f);

// PPTX dosyasını diske yazar
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Sunumu web'e yayınlarken animasyonların korunmasını nasıl sağlayabilirim?

[Export to HTML5](/slides/tr/cpp/export-to-html5/) sayfasını kullanın ve [shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/html5options/set_animateshapes/) ve [transition](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/html5options/set_animatetransitions/) animasyonlarından sorumlu [options](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/html5options/) ayarlarını etkinleştirin. Düz HTML slayt animasyonlarını oynatmaz, HTML5 ise oynatır.

### Şekillerin z-order (katman sırası) değişikliği animasyonu nasıl etkiler?

Animasyon ve çizim sırası bağımsızdır: bir efekt, görünme/gizlenme zamanlamasını ve tipini kontrol eder, [z-order](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/get_zorderposition/) ise hangi şeyin neyi örtüp örtmediğini belirler. Görünür sonuç, bunların kombinasyonu ile tanımlanır. (Bu, genel PowerPoint davranışıdır; Aspose.Slides efektler ve şekiller modeli aynı mantığı izler.)

### Belirli efektler için animasyonları videoya dönüştürürken sınırlamalar var mı?

Genel olarak, [animations are supported](/slides/tr/cpp/convert-powerpoint-to-video/) (animasyonlar desteklenir), ancak nadir durumlar veya belirli efektler farklı işlenebilir. Kullandığınız efektlerle ve kütüphane sürümüyle test etmeniz önerilir.
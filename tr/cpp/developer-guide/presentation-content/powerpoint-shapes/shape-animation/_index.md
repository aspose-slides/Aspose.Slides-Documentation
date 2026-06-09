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
- animasyon çıkar
- efekt ekle
- efekt al
- efekt çıkar
- efekt sesi
- animasyon uygula
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint sunumlarında şekil animasyonları oluşturmayı ve özelleştirmeyi keşfedin. Öne çıkın!"
---
## **Giriş**

Animasyonlar, metinlere, görüntülere, şekillere veya [grafiklere](/slides/tr/cpp/animated-charts/) uygulanabilen görsel efektlerdir. Sunumlara ya da bileşenlerine hayat verir. 

## **Sunumlarda Animasyonları Neden Kullanmalısınız?**

Animasyonları kullanarak

* bilgi akışını kontrol edin
* önemli noktaları vurgulayın
* izleyicilerinizin ilgisini veya katılımını artırın
* içeriği okumayı, sindirmeyi ya da işlemeyi kolaylaştırın
* okuyucularınızın ya da izleyicilerinizin bir sunumda önemli bölümlere dikkatini çekin

PowerPoint, **giriş**, **çıkış**, **vurgulama** ve **hareket yolları** kategorileri kapsamında animasyonlar ve animasyon efektleri için çok sayıda seçenek ve araç sunar. 

## **Aspose.Slides'ta Animasyonlar**

* Aspose.Slides, animasyonlarla çalışmak için gereken sınıfları ve tipleri [Aspose.Slides.Animation](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.animation) ad alanı altında sağlar,
* Aspose.Slides, [EffectType](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) enumarasyonu altında **150'den fazla animasyon efekti** sağlar. Bu efektler, temelde PowerPoint'te kullanılan aynı (veya eşdeğer) efektlerdir.

## **Bir Metin Kutusuna Animasyon Uygulama**

Aspose.Slides for C++, bir şeklin içindeki metne animasyon uygulamanıza izin verir. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre bir slaytın referansını alın.  
3. `rectangle` tipinde bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) ekleyin.  
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) öğesine metin ekleyin.  
5. Efektlerin ana dizisini alın.  
6. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) öğesine bir animasyon efekti ekleyin.  
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) özelliğini [BuildType Enumeration](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) değerine ayarlayın.  
8. Sunumu bir PPTX dosyası olarak diske kaydedin.

Bu C++ kodu, `Fade` efektini AutoShape'e uygulamayı ve metin animasyonunu *By 1st Level Paragraphs* değerine ayarlamayı gösterir:

```c++
// Sunum dosyasını temsil eden bir sunum sınıfı örnekler.
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
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Metne animasyon uygulamanın yanı sıra tek bir [Paragraph](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_paragraph) öğesine de animasyon uygulayabilirsiniz. [**Animated Text**](/slides/tr/cpp/animated-text/) bölümüne bakın.

{{% /alert %}} 

## **PictureFrame'e Animasyon Uygulama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation/) sınıfının örneğini oluşturun.  
2. İndeksine göre bir slaytın referansını alın.  
3. Slayta bir [PictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_picture_frame) ekleyin ya da alın.  
4. Efektlerin ana dizisini alın.  
5. [PictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_picture_frame) öğesine bir animasyon efekti ekleyin.  
6. Sunumu bir PPTX dosyası olarak diske kaydedin.

Bu C++ kodu, bir resim çerçevesine `Fly` efektini nasıl uygulayacağınızı gösterir:

```c++
// Sunum dosyasını temsil eden bir sunum sınıfı örnekler.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Sunuma eklenecek resmi görüntü koleksiyonuna yükle
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Slayta resim çerçevesi ekler
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Slaytın ana dizisini alır.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Resim çerçevesine soldan gelen Fly animasyon efektini ekler
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// PPTX dosyasını diske kaydeder
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bir Şekle Animasyon Uygulama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation/) sınıfının örneğini oluşturun.  
2. İndeksine göre bir slaytın referansını alın.  
3. `rectangle` tipinde bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) ekleyin.  
4. `Bevel` bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) ekleyin (bu nesne tıklandığında animasyon oynatılır).  
5. Bevel şekli üzerinde bir efekt dizisi oluşturun.  
6. Özel bir `UserPath` oluşturun.  
7. `UserPath`'e hareket için komutlar ekleyin.  
8. Sunumu bir PPTX dosyası olarak diske kaydedin.

Bu C++ kodu, bir şekle `PathFootball` (yol futbolu) efektini nasıl uygulayacağınızı gösterir:

```c++
	// Doküman dizinine giden yol.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Sunumu yükler
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// İlk slayta erişir
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Seçili slayt için şekil koleksiyonuna erişir
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Mevcut şekil için sıfırdan PathFootball efekti oluşturur.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// PathFootBall animasyon efektini ekler
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Bir tür "düğme" oluşturur.
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

## **Bir Şekle Uygulanan Animasyon Efektlerini Almak**

Aşağıdaki örnekler, bir şekle uygulanan tüm animasyon efektlerini almak için [ISequence](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/) arayüzündeki `GetEffectsByShape` yönteminin nasıl kullanılacağını gösterir.

**Örnek 1: Normal bir slaytta bir şekle uygulanan animasyon efektlerini al**

Daha önce, PowerPoint sunumlarındaki şekillere animasyon efektleri eklemeyi öğrenmiştiniz. Aşağıdaki örnek kod, `AnimExample_out.pptx` sunumundaki ilk normal slaytın ilk şekline uygulanan efektleri nasıl alacağınızı gösterir:

```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Slaytın ana animasyon dizisini alır.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// İlk slayttaki ilk şekli alır.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Şekle uygulanan animasyon efektlerini alır.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Örnek 2: Yer tutuculardan devralınanlar dahil olmak üzere tüm animasyon efektlerini al**

Normal bir slayttaki bir şeklin, düzen slaytı ve/veya ana slaytta bulunan yer tutucuları varsa ve bu yer tutuculara animasyon efektleri eklenmişse, şeklin tüm efektleri slayt gösterisi sırasında, yer tutuculardan devralınanlar da dahil olmak üzere oynatılır.

Diyelim ki `sample.pptx` adlı bir PowerPoint sunum dosyamız var; bu dosyada yalnızca "Made with Aspose.Slides" metnini içeren bir alt bilgi şekli bulunan bir slayt var ve şekle **Random Bars** efekti uygulanmış.

![Slayt şekil animasyon efekti](slide-shape-animation.png)

Ayrıca **Split** efektinin düzen slaydındaki alt bilgi yer tutucusuna uygulandığını varsayalım.

![Düzen şekil animasyon efekti](layout-shape-animation.png)

Ve nihayet **Fly In** efektinin ana slaydındaki alt bilgi yer tutucusuna uygulandığını varsayalım.

![Ana slayt şekil animasyon efekti](master-shape-animation.png)

Aşağıdaki örnek kod, [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) arayüzündeki `GetBasePlaceholder` metodunu kullanarak şekil yer tutucularına erişip alt bilgi şekline uygulanan animasyon efektlerini, düzen ve ana slaytlardaki yer tutuculardan devralınanları da dahil olmak üzere nasıl alacağınızı gösterir:

```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```
```cpp
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

Çıktı:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Uçuş, Alt
Type: 134, subtype: 45            // Böl, Dikeyİçeri
Type: 126, subtype: 22            // RastgeleÇubuklar, Yatay
```

## **Animasyon Efekti Zamanlama Özelliklerini Değiştirme**

Aspose.Slides for C++, bir animasyon efektinin Zamanlama özelliklerini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Zamanlama bölmesidir:

![example1_image](shape-animation.png)

PowerPoint Zamanlama **Start** açılır listesi, [Effect.Timing.TriggerType] özelliğiyle eşleşir.  
PowerPoint Zamanlama **Duration** özelliği, [Effect.Timing.Duration] özelliğiyle eşleşir. Bir animasyonun süresi (saniye cinsinden), animasyonun bir döngüyü tamamlaması için gereken toplam zamandır.  
PowerPoint Zamanlama **Delay** özelliği, [Effect.Timing.TriggerDelayTime] özelliğiyle eşleşir. 

Bu, Effect Timing özelliklerini değiştirme adımlarıdır:

1. [Apply](#apply-animation-to-shape) ya da animasyon efektini alın.  
2. İhtiyacınız olan [Effect.Timing] özellikleri için yeni değerler ayarlayın.  
3. Değiştirilmiş PPTX dosyasını kaydedin.

Bu C++ kodu, işlemi gösterir:

```c++
// Sunum dosyasını temsil eden bir sunum sınıfı örnekler.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Slaytın ana dizisini alır.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Ana dizinin ilk etkisini alır.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Etkinin TriggerType'ını tıklamayla başlatacak şekilde değiştirir
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Etkinin süresini değiştirir
effect->get_Timing()->set_Duration(3.f);

// Etkinin TriggerDelayTime'ını değiştirir
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// PPTX dosyasını diske kaydeder
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Animasyon Efekti Sesi**

Aspose.Slides, animasyon efektlerinde seslerle çalışmanızı sağlayan aşağıdaki özellikleri sunar: 

- [set_Sound()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Bir Animasyon Efekti Sesi Ekleme**

Bu C++ kodu, bir animasyon efekti sesini nasıl ekleyeceğinizi ve bir sonraki efekt başladığında nasıl durdurulacağını gösterir:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Sunum ses koleksiyonuna ses ekler
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Slaytın ana dizisini alır.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Ana dizinin ilk etkisini alır
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// "Ses Yok" için efekti kontrol eder
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // İlk efekt için ses ekler
    firstEffect->set_Sound(effectSound);
}

// Slaytın ilk etkileşimli dizisini alır.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Efektin "Önceki sesi durdur" bayrağını ayarlar
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// PPTX dosyasını diske yazar
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Bir Animasyon Efekti Sesini Çıkarma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
2. İndeksine göre bir slaytın referansını alın.  
3. Efektlerin ana dizisini alın.  
4. Her animasyon efektine gömülü [set_Sound()] metodunu çıkarın.  

Bu C++ kodu, bir animasyon efektine gömülü sesi nasıl çıkartacağınızı gösterir:

```c++
// Sunum dosyasını temsil eden bir sunum sınıfı örnekler.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Slaytın ana dizisini alır.
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

Aspose.Slides for C++, bir animasyon efektinin Animasyondan Sonra özelliğini değiştirmenizi sağlar.

Bu, Microsoft PowerPoint'teki Animasyon Efekti bölmesi ve genişletilmiş menüsüdür:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** açılır listesi şu özelliklerle eşleşir: 

- [set_AfterAnimationType()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) özelliği, Animasyondan Sonra tipini açıklar:
  * PowerPoint **More Colors** seçeneği, [AfterAnimationType.Color] tipine karşılık gelir;
  * PowerPoint **Don't Dim** seçeneği, [AfterAnimationType.DoNotDim] tipine karşılık gelir (varsayılan animasyondan sonra tipi);
  * PowerPoint **Hide After Animation** seçeneği, [AfterAnimationType.HideAfterAnimation] tipine karşılık gelir;
  * PowerPoint **Hide on Next Mouse Click** seçeneği, [AfterAnimationType.HideOnNextMouseClick] tipine karşılık gelir;
- [set_AfterAnimationColor()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) özelliği, animasyondan sonraki renk formatını tanımlar. Bu özellik, [AfterAnimationType.Color] tipiyle birlikte çalışır. Tipi başka bir şeye değiştirirseniz, animasyondan sonraki renk temizlenir.

Bu C++ kodu, bir animasyondan sonra efektini nasıl değiştireceğinizi gösterir:

```c++
// Sunum dosyasını temsil eden bir sunum sınıfı örnekler
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ana dizinin ilk etkisini alır
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Animasyondan sonraki tipi Renk olarak değiştirir
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Animasyondan sonraki karartma rengini ayarlar
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// PPTX dosyasını diske yazar
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Metni Animasyonla**

Aspose.Slides, bir animasyon efektinin *Animate text* bloğu ile çalışmanızı sağlayan şu özellikleri sunar:

- [set_AnimateTextType()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) özelliği, efektin metin animasyon tipini açıklar. Şekil metni şu şekilde animasyonlanabilir:
  - Hepsi bir anda ([AnimateTextType.AllAtOnce] tipi)
  - Kelime kelime ([AnimateTextType.ByWord] tipi)
  - Harfe harf ([AnimateTextType.ByLetter] tipi)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) animasyonlu metin bölümleri (kelimeler ya da harfler) arasındaki gecikmeyi ayarlar. Pozitif bir değer, efekt süresinin yüzde oranını belirtir. Negatif bir değer ise gecikmeyi saniye cinsinden belirtir.

Bu, Effect Animate text özelliklerini değiştirme adımlarıdır:

1. [Apply](#apply-animation-to-shape) ya da animasyon efektini alın.  
2. *By Paragraphs* animasyon modunu devre dışı bırakmak için [set_BuildType()] özelliğini, [BuildType.AsOneObject] değerine ayarlayın.  
3. Yeni değerleri [set_AnimateTextType()] ve [set_DelayBetweenTextParts()] özelliklerine ayarlayın.  
4. Değiştirilmiş PPTX dosyasını kaydedin.

Bu C++ kodu, işlemi gösterir:

```c++
// Sunum dosyasını temsil eden bir sunum sınıfı örnekler.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ana dizinin ilk etkisini alır
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Etkinin Metin animasyon tipini "Tek Nesne Olarak" olarak değiştirir
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Etkinin Animasyon metin tipini "Kelimeye göre" olarak değiştirir
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Kelimeler arasındaki gecikmeyi efekt süresinin %20'sine ayarlar
firstEffect->set_DelayBetweenTextParts(20.0f);

// PPTX dosyasını diske yazar
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **SSS**

**Sunumu web'e yayınlarken animasyonların korunmasını nasıl sağlayabilirim?**

[Export to HTML5](/slides/tr/cpp/export-to-html5/) ve şekil ([shape]) ve geçiş ([transition]) animasyonlarından sorumlu [options]... seçeneklerini etkinleştirin. Düz HTML slayt animasyonlarını oynatmaz, HTML5 ise oynatır.

**Şekillerin z-sırasını (katman sırasını) değiştirmek animasyonu nasıl etkiler?**

Animasyon ve çizim sırası bağımsızdır: bir efekt, görünme/görünmez olma zamanlamasını ve tipini kontrol eder, [z-order](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/get_zorderposition/) ise neyin neyi örteceğini belirler. Görünür sonuç, birleşimleriyle tanımlanır. (Bu, genel PowerPoint davranışıdır; Aspose.Slides efekt‑ve‑şekil modeli aynı mantığı izler.)

**Belirli efektler için animasyonları videoya dönüştürürken sınırlamalar var mı?**

Genel olarak, [animasyonlar desteklenir](/slides/tr/cpp/convert-powerpoint-to-video/), ancak nadir durumlar ya da belirli efektler farklı işlenebilir. Kullandığınız efektleri ve kitaplık sürümünü test etmeniz önerilir.
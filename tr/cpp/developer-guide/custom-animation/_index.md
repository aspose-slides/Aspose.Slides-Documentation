---
title: C++'ta Özel Animasyon Davranışlarını Oluşturma ve Değiştirme
linktitle: Özel Animasyon
type: docs
weight: 151
url: /tr/cpp/custom-animation/
keywords:
- özel animasyon
- animasyon davranışı
- hareket yolu
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint sunumlarında özel animasyon davranışlarını ve düzenlenebilir hareket yollarını oluşturun, inceleyin ve değiştirin."
---
## **Genel Bakış**

Özel animasyon davranışları, bir renk değiştirme, bir şekli döndürme veya düzenlenebilir bir hareket yolu izleme gibi bir animasyon etkisi içinde bireysel işlemleri kontrol etmenizi sağlar. Bu kılavuz, davranışları nasıl oluşturup birleştireceğinizi, zamanlamalarını nasıl yapılandıracağınızı, mevcut animasyonları nasıl inceleyip değiştireceğinizi ve özelliklerinin bir sunumu kaydedip yeniden açtıktan sonra korunup korunmadığını nasıl doğrulayacağınızı gösterir.

Önceden tanımlı etkiler ve tıklama tetikleyicileri için bakınız [Şekil Animasyonu](/slides/tr/cpp/shape-animation/).

## **Animasyon Modelini Anlama**

- Slaytın [get_Timeline](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/get_timeline/) ana sırasını ve etkileşimli sıraları içerir.  
- Bir [ISequence](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/) efektleri içerir, potansiyel olarak farklı şekilleri hedefleyebilir.  
- Bir [IEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/) hedef şekli, ön ayarı, alt tipini ve efekt zamanlamasını tanımlar.  
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/get_behaviors/) efekti uygulayan işlemleri içerir: renk değiştirme, taşıma, döndürme, bir özelliği ayarlama vb.

## **Bireysel Davranışlar Oluşturma**

[ISequence::AddEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/isequence/addeffect/) çağırarak bir efekt oluşturup onun [get_Behaviors](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/get_behaviors/) koleksiyonuna erişin. Bir ön ayar bu koleksiyonu otomatik olarak doldurabilir. Özelleştirirken işlemleri koruyun veya bilinçli olarak değiştirmek istediğinizde [Clear](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorcollection/clear/) kullanın.

[IBehaviorFactory](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorfactory/) aşağıda gösterilen sekiz davranış türünü oluşturur. Hareket, [Build a Motion Path](#build-a-motion-path) bölümünde ele alınır. Her oluşturma örneği bir fonksiyon içinde çalıştırılacak bağımsız kodlardır; sonraki düzenleme örnekleri hangi çıktı dosyasını kullandıklarını belirtir.

### **Dönme**

[CreateRotationEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) bir dönüş oluşturmak için kullanın. [get_By](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/irotationeffect/get_by/) derece cinsinden relatif açı belirtir; [get_From](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/irotationeffect/get_from/) ve [get_To](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/irotationeffect/get_to/) uç noktaları belirler.

Örnek bir Spin etkisiyle başlar, ön ayar işlemlerini tek bir dönme davranışıyla değiştirir ve bu işleme iki saniyelik bir süre verir. 90 derecelik bir relatif açı, şeklin başlangıç yönünden çeyrek dönüşü ifade eder, bu yüzden açık bir başlangıç açısına ihtiyaç yoktur.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` bir şekil ve bir dönme davranışı içerir. Aşağıdaki koleksiyon, zamanlama ve dönme‑düzenleme örnekleri bu dosyayı kullanır.

### **Ölçekleme**

[X/Y yüzdeleriyle] [CreateScaleEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) kullanın: [get_From](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/iscaleeffect/get_from/) ve [get_To](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/iscaleeffect/get_to/) başlangıç ve bitiş boyutunu tanımlar, [get_By](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/iscaleeffect/get_by/) ise relatif bir değişikliği tanımlar. Burada 100, özgün boyutu temsil eder.

Örnek her iki boyutu da %100'den %125'e iki saniye içinde büyütür. Yatay ve dikey yüzde aynı olduğunda şeklin oranı korunur; farklı yüzde değerleri bir boyutu diğerinden daha fazla uzatır.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Renk**

[CreateColorEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) kullanarak doldurmayı maviden turuncuya değiştirin. [get_From](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/icoloreffect/get_from/) ve [get_To](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/icoloreffect/get_to/) renklerdir; [get_By](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/icoloreffect/get_by/) bir renk ofsetidir. [IBehavior::get_Properties](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehavior/get_properties/) animasyon yapılan özelliği tanımlar.

Şeklin katı doldurması mavidir ve animasyonun başlangıç rengine uygundur. Doldurma‑renk özelliğini seçmek, davranışa hangi kısmın değişeceğini söyler; sadece renk uç noktaları bu özelliği belirlemez. Kaydedilen efekt iki saniyelik bir turuncuya geçişi tanımlar.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Filtre**

[CreateFilterEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) kullanarak bir silme (wipe) seçin. [get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ifiltereffect/get_subtype/) ve [get_Reveal](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) filtreyi, yönü ve şekli ortaya çıkarıp gizleyeceğini belirtir.

Bu örnek, sağ‑yön alt tipiyle şekli ortaya çıkaran iki saniyelik bir silme ayarlar. Filtre ayarları efektin içindeki davranışa aittir; bu nedenle ön ayarın orijinal işlemleri kaldırıldıktan sonra yapılandırılır.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Özellik**

[CreatePropertyEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) kullanarak opaklığı animasyonlayın. [get_From](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ipropertyeffect/get_to/) ve [get_By](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ipropertyeffect/get_by/) dizeler, [get_ValueType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) ve [get_CalcMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/) ile yorumlanır. Üçünü aynı anda ayarlamaktan kaçının; uç noktalar ya da relatif ofset seçin.

Bu örnekte seçilen özellik opaklıkdır ve sayısal dizeler %25 opaklıktan tam opaklığa değişimi temsil eder. Doğrusal ara değerleme bu değerler arasında kademeli bir değişim tanımlar. Başka bir özelliğe uyarlarken, o özelliğe uygun bir değer türü ve uç değerler seçin.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Ayarla**

[CreateSetEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) kullanarak [get_To](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/iseteffect/get_to/) ile görünürlük atayın. Bir set davranışı uç noktalar arasında ara değerleme yapmaz.

Örnek, görünürlük özelliğini seçer ve davranış çalıştığında `visible` dizisini atar. C++’ta diziyi bir nesne olarak kutup içinde set davranışına atayın. Dikdörtgen bu minimal sunumda zaten görünür olduğundan atama tek başına belirgin bir görsel değişim oluşturmayabilir. Bu işlem, şeklin gizlenip görünür hâle geleceği daha büyük bir etki içinde yararlı olur.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Komut**

[CreateCommandEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) kullanın ve [get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), [get_ShapeTarget](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/) yapılandırın. Çalışma dizinine `sample.wav` adlı bir WAV kaydı koyun. Bu örnek, [AddAudioFrameEmbedded](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) ile gömülmüş şekilde ekler ve çalma komutunu ses çerçevesine bağlar.

Ses çerçevesi hem etkinin hem de komutun hedefidir. Bu, çalma isteğini gömülü kayda bağlar; yalnız bir komut dizesi hangi medya nesnesinin kontrol edileceğini belirlemez. Etki, slayt gösterisi sırasında bir tıklamayla başlaması için yapılandırılır.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

Kaydetme, komutu `command.pptx` içinde tutar; kaydı çalmaz. Çalma, komutu ve medya hedefini destekleyen bir slayt gösterisi oynatıcı gerektirir.

## **Davranış Koleksiyonunu Yönetme**

[IBehaviorCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorcollection/) [Add](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorcollection/remove/), [RemoveAt](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorcollection/removeat/) destekler. Bu örnek `rotation.pptx` dosyasını açar, ölçekleme ekler, döndürmeden önce taşır ve döndürmeyi kaldırır. Aynı nesneyi kaldırıp yeniden eklemek, kopya oluşturmaz; sadece saklanan konumu değiştirir.

Düzenlemeler sırasıyla koleksiyonu döndürme‑ölçeklemeden ölçekle‑döndürmeye, ardından yalnız ölçeğe değiştirir. İndeksler mevcut koleksiyona göre değerlendirilir; kaldırma, yeniden sıralamadan sonra döndürmenin yeni indeksini kullanır. Son sayım, kaydedilecek davranışı onaylar.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Çıktı `ScaleEffect` olur: yalnız ölçekleme kalır. Koleksiyon sırası tek başına davranışların birbiri ardına çalışmasını planlamaz. Tüm işlemleri değiştirecekseniz koleksiyonu temizleyin.

## **Davranış Zamanlamasını Yapılandırma**

[IBehavior::get_Timing](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehavior/get_timing/) [IEffect::get_Timing](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/get_timing/) bağımsız olarak [ITiming](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/) nesnesini ortaya çıkarır. Etki zamanlaması kapsayan efekti planlarken, davranış zamanlaması içinde bir işlemi tanımlar.

### **Süre, Gecikme, Tekrar ve Hızlanma Ayarlama**

`rotation.pptx` dosyasını açın ve saniye cinsinden [get_Duration](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/get_duration/) ve [get_TriggerDelayTime](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) ayarlayın, ardından [get_RepeatCount](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/get_repeatcount/) yapılandırın. [get_Accelerate](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/get_accelerate/) ve [get_Decelerate](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/get_decelerate/) süreye oran olarak verir; toplamları en fazla 1 olmalıdır.

Girdi dosyası, döndürme örneğinde oluşturulan dosyadır; ilk davranışın bir döndürme olduğu bilinir. Bu örnek yalnız o davranışın zamanlamasını değiştirir; 90 derecelik açı aynı kalır. Açıyı ve zamanlamayı ayrı tutmak, temponun yeniden düzenlenmesini kolaylaştırır.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Davranış iki saniyelik bir süre, yarım saniyelik bir gecikme ve 3 tekrar sayısı kullanır. Süresinin ilk ve son %20’si hızlanma ve yavaşlama için ayrılmıştır.

Diğer tekrar politikaları arasında [get_RepeatDuration](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), [get_RepeatUntilNextClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/) bulunur; hepsini aynı anda etkinleştirmek yerine birini seçin. [get_AutoReverse](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/itiming/get_autoreverse/) ileri geçişten sonra animasyonu tersine oynatır. Hızlanma ve yavaşlama, kesintisiz değişikliklerde uygulanır; tekil atamalar veya komutlar için geçerli değildir.

## **Bir Hareket Yolu Oluşturma**

[CreateMotionEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) bir hareket oluşturur. [get_From](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotioneffect/get_to/), [get_By](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotioneffect/get_by/) yüzde tabanlı koordinatlar ya da ofsetler tanımlar. Düzenlenebilir bir rota için bir [MotionPath](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/motionpath/) oluşturun ve bunu [IMotionEffect::get_Path](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotioneffect/get_path/)’a atayın. [IMotionPath](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotionpath/) yol komutlarını depolar.

[MotionCommandPathType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/motioncommandpathtype/) işlemi seçer:

| Komut | Nokta Sayısı | Anlam |
| --- | --- | --- |
| MoveTo | Bir | Başlangıç konumunu ayarlar. |
| LineTo | Bir | Düz bir segment boyunca uç noktasına hareket eder. |
| CurveTo | Üç | İki kontrol noktası ve bir uç nokta ile tanımlanan kübik bir eğriyi izler. |
| CloseLoop | Yok | Başlangıç konumuna geri döner. |
| End | Yok | Yolu sonlandırır. |

[MotionPathPointsType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/motionpathpointstype/) köşe ya da yumuşak nokta gibi nokta‑düzenleme özelliklerini tanımlar; komut tipini değiştirmez. Aşağıdaki eğri örneğinde bir eğri nokta tipi, düz segmentlerde köşe nokta tipi kullanın.

Yol koordinatları slayt boyutlarına göre normalleştirilir: X ekseninde 0.25 kaydırma, slayt genişliğinin dörtte birine eşittir, 0.25 puana değil. Y ekseni aşağı doğru pozitif olur. Mutlak komutlar yol koordinat sistemindeki konumları, relatif komutlar ise mevcut konuma göre ofsetleri belirtir. Bu, [get_Origin](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotioneffect/get_origin/) ile yolun referans çerçevesini ve [get_PathEditMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/) ile şekil taşındığında yolun nasıl hareket edeceğini denetler.

### **Düz Bir Yol Oluşturma**

Bir başlangıç noktası, bir düz segment ve bir end komutu içeren bir hareket davranışı oluşturun. [IMotionPath::Add](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotionpath/add/) komut tipini, noktalarını, nokta tipini ve relatif‑koordinat bayrağını kabul eder.

Başlangıç komutu (0, 0) ayarlar, çizgi (0.25, 0)’da sona erer; bu, slayt genişliğinin dörtte birine kadar yatay bir kaydırma oluşturur. End komutunun koordinat noktası yoktur. Yol atandıktan sonra hareket davranışı efekti içine eklendiğinde bu rota dikdörtgene bağlanır.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` bir hareket davranışı ve üç yol komutu içerir. Aşağıdaki dosya‑düzenleme örnekleri bu yapıyı kullanır.

### **Mutlak ve Relatif Koordinatları Karşılaştırma**

Bu iki yol nesnesi aynı rotayı tanımlar. Mutlak komut (0.3, 0.1)’de sona erer; relatif komut (0.1, 0.1)’i mevcut konuma (0.2, 0) ekler.

Her iki yol da aynı konumda başlar. Relatif çizgi için X ve Y ofsetlerini mevcut konuma ekleyerek uç nokta elde edilir; mutlak çizgi için uç nokta doğrudan okunur. Bayrağı dönüştürmeden değiştirmek farklı bir rota oluşturur.

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

Her iki yolu da bir hareket davranışına atayarak sunumda kullanabilirsiniz. Son Boolean argüman, o komut için relatif koordinatları seçer.

### **Bir Çizgiyi Eğriyle Değiştirme**

`motion.pptx` dosyasını açın ve çizgi komutunu bir kübik eğriyle değiştirin. İlk olarak iki kontrol noktasını, ardından uç noktayı verin.

Başlangıç konumu önceki komut tarafından sağlanır. İlk iki nokta eğriyi şekillendirir, üçüncü ise hedefidir; üç nokta ardışık hedefler değildir. Komut tipini, nokta‑düzenleme tipini ve nokta dizisini birlikte güncellemek, segmentin yeni geometrisiyle tutarlı kalmasını sağlar.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`curve.pptx` dosyasındaki yol hâlâ üç komut içerir; orta komut artık bir eğri tanımlar.

## **Kaydedilmiş Bir Yolu İnceleme ve Düzenleme**

Her [IMotionCmdPath](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotioncmdpath/) [get_Points](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), [get_IsRelative](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/) sunar. Aşağıdaki örnekler `motion.pptx` içindeki üç‑komutluk yolu kullanır. Rastgele bir girdi için, düzenlemeden önce hedef efekti bulun, komut tiplerini ve nokta sayılarını kontrol edin.

### **Komutları ve Koordinatları Okuma**

Yolu değiştirmeden okuyun. End ve CloseLoop komutlarının noktaya ihtiyacı yoktur; bu yüzden boş bir nokta dizisine izin verin.

Çıktı, her komutu relatif‑koordinat bayrağıyla birlikte listeler ve ardından nokta dizisini gösterir. Bu, yolu değiştirmeden önce bir uç nokta mı yoksa bir ofset mi olduğunu ayırt etmenizi sağlar. Bir eğri üç nokta listeler, bu dosyadaki düz çizgi ise yalnız bir nokta listeler.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

Liste bir başlangıç noktası, (0.25, 0)’de biten mutlak bir çizgi ve bir end komutu içerir.

### **Bir Uç Noktayı Değiştirme**

`motion.pptx` dosyasını açın ve çizginin nokta dizisini değiştirerek uç noktasını taşıyın.

Girdi dosyasında indeks 0 başlangıç komutu, indeks 1 çizgidir. Çizginin tek noktasını değiştirerek komut tipini, zamanlamasını veya koleksiyondaki konumunu etkilemeden hedefini değiştirirsiniz. Komut mutlak koordinat kullandığından yeni çift bir konumu, bir ofset değil, belirtir.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion-endpoint.pptx` dosyasındaki çizgi (0.4, 0.1)’de sona erer; orijinal dosya değişmez.

### **Bir Segmenti Değiştirme**

[Insert](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotionpath/insert/) ve [RemoveAt](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/imotionpath/removeat/) kullanarak `motion.pptx` içindeki çizgiyi değiştirin. Ekleme, eski çizgiyi indeks 2’ye kaydırır.

Bu, mevcut koordinatları düzenlemek yerine bir komut nesnesini değiştirmeyi gösterir. Eklendikten sonra koleksiyon geçici olarak başlangıç komutu, yeni çizgi, eski çizgi ve end komutunu içerir. İndeks 2’yi kaldırmak eski çizgiyi siler ve yeni rotayı bırakır.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Kaydedilen yol hâlâ üç komut taşır; yeni çizgi (0.2, 0.1)’de biter ve end komutu sonundadır.

## **Mevcut Bir Davranışı Değiştir ve Doğrula**

Davranışın indeksi bilinmiyorsa, tipine göre seçin. Bu örnek `rotation.pptx` dosyasını açar, [IRotationEffect](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/irotationeffect/) bulur, açıyı değiştirir ve yeniden açtıktan sonra kaydedilen değeri kontrol eder.

Tip kontrolü, döndürme olmayan davranışların döngüde atlanmasını sağlar. İkinci yükleme, kaydedilen dosyayı ayrı bir sunum nesnesine okur; böylece karşılaştırma bellekteki değerden ziyade kalıcı veriyi inceler. Bu örnek, bilinen etkinin ana sırada ilk olduğu varsayımına dayanır; tip‑bazlı seçim rastgele bir sunumda doğru efekti bulmayabilir.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

Çıktı `Rotation preserved: True` olur. Aynı tip‑kontrol desenini diğer davranışlara da uygulayın. Tam bir koruma kontrolü için hedef şekil, etki, davranış tipleri ve sırası, zamanlama ve yol komutları karşılaştırın. Nokta tipindeki kayan‑nokta değerleri için sayısal tolerans kullanın. Bilinmeyen bir animasyon düzeni olan bir sunum için bakınız [Read Shape Animations](/slides/tr/cpp/shape-animation/#read-shape-animations).

## **Davranış Sırası, Ön Ayarlar ve Oynatma**

[IBehaviorCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehaviorcollection/) içindeki sıralama, bir etkinin işlemlerinin saklanan sırasıdır. Bu, otomatik olarak bir önceki davranışı bekleyen bir çalma listesi değildir; zamanlama ve kapsayan etki planlamayı belirler. Davranışlar çakışabilir ve aynı özelliğe uygulanan işlemler [get_Additive](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehavior/get_additive/) ve [get_Accumulate](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ibehavior/get_accumulate/) aracılığıyla etkileşebilir. “Taşı, sonra döndür” gibi bir sıralamayı sadece koleksiyon yeniden sıralamasıyla elde etmeyin; açık zamanlama ya da ayrı etkiler kullanın; ayrıntılar için [Şekil Animasyonu](/slides/tr/cpp/shape-animation/).

Etkinin [get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/get_type/) ve [get_Subtype](https://reference.aspose.com/slides/tr/cpp/aspose.slides.animation/ieffect/get_subtype/) ön ayarını tanımlar. Bu, düzenlenmiş bir davranış ağacının tam tanımı değildir. Ön ayarı ve alt tipi, davranışları özelleştirmeden önce seçin: ön ayarı değiştirmek koleksiyonu yeniden oluşturur ve özel işlemlerinizi silebilir. Örneğin, özelleştirilmiş bir Spin etkisini Fade’a dönüştürmek, dönme davranışını set ve filter davranışlarıyla değiştirebilir. Ön ayar veya alt tip değiştirildikten sonra koleksiyonu yeniden inceleyin. Ön ayar davranışlarını temizlemek, ön ayarın ihtiyaç duyduğu görünürlük veya başlatma işlemlerini de kaldırabilir. Örnekler görünür şekiller kullanır ve davranışları değiştirir; her ön ayarın tüm uygulamasını yeniden oluşturmaz.

## **Biçim Uyumluluğu**

Bir davranış ağacının korunması, her görüntüleyicide veya dışa aktarma işleyicisinde aynı oynatmayı garantilemez. Kaydedilen verileri ve oluşturulan çıktıyı ayrı ayrı kontrol edin.

| Format veya çıktı | Ne Kontrol Edilmeli |
| --- | --- |
| PPTX | Bu örnekler için birincil format olarak kullanın. Düzenlenebilir davranış ağacını doğrulamak için yeniden açın, ardından hedef PowerPoint sürümünde oynatmayı kontrol edin. |
| PPT | Eski ikili temsil PPTX’ten farklı olabilir. Ayrı bir kaydet‑yeniden‑aç döngüsü ve oynatma testi yapın; PPTX çıktısının başarılı olması, her özel kombinasyonun desteklendiği anlamına gelmez. |
| PDF, PNG, JPEG ve diğer statik slayt görselleri | Statik slayt temsili içerir; oynatılabilir bir davranış zaman çizelgesi veya garantili bir son animasyon çerçevesi sağlamaz. |
| [HTML5](/slides/tr/cpp/export-to-html5/) | Dışa aktarma seçeneklerinde şekil animasyonu etkinleştirildiğinde desteklenen animasyonları oynatabilir. Tarayıcıda özel kombinasyonları test edin. |
| [Animated GIF](/slides/tr/cpp/convert-powerpoint-to-animated-gif/) | Oluşturulan çerçeveleri saklar; düzenlenebilir davranışları veya tıklama‑tetiklenen etkileşimi içermez. Gerçekleşen hareketi kontrol edin. |
| [Video](/slides/tr/cpp/convert-powerpoint-to-video/) | Animasyon çerçevelerini render eder ve video olarak kodlar. Destek, oluşturucunun [desteklediği animasyon ve efektler](/slides/tr/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) ile sınırlıdır; komutlar ve etkileşimli olaylar düzenlenebilir bir zaman çizelgesine dönüşmez. |

## **SSS**

**Neden efektim davranışlar içeriyor eklemeden önce?**  
Önceden tanımlı bir etki oluşturulduğunda temel işlemleri de oluşturabilir. Bunları inceleyip ön ayarı genişletecek veya davranışlarını değiştirecek kararını verin.

**Bir davranışı başa taşımanın önce oynatılmasını sağlar mı?**  
Zorunlu değildir. Koleksiyon sırası zamanlama yerine geçmez. Gecikmeleri, süreleri ve aynı özellik üzerindeki işlemlerin etkileşimini kontrol edin.

**Neden bir end komutunun nokta yok?**  
Yolun sonunu işaret eder ve koordinata ihtiyaç duymaz. Dosyadan okunan bir yolda nokta dizisi null olabilir; bunu kontrol edin.

**Başarılı bir geri dönüş oynatmayı doğrulamak için yeterli mi?**  
Hayır. Yeniden açma, kontrol ettiğiniz özelliklerin korunmasını gösterir. Görsel davranışı teyit etmek için slayt gösterisi oynatıcıyı veya animasyonlu dışa aktarımı ayrı ayrı test edin.
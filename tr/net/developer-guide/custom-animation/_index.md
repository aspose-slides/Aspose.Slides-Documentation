---
title: .NET'te Özel Animasyon Davranışlarını Oluşturma ve Değiştirme
linktitle: Özel Animasyon
type: docs
weight: 151
url: /tr/net/custom-animation/
keywords:
- özel animasyon
- animasyon davranışı
- hareket yolu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarında özel animasyon davranışlarını ve düzenlenebilir hareket yollarını oluşturun, inceleyin ve değiştirin."
---
## **Genel Bakış**

Özel animasyon davranışları, bir renk değişikliği, bir şeklin döndürülmesi veya düzenlenebilir bir hareket yolu izlenmesi gibi bir animasyon etkisi içindeki bireysel işlemleri kontrol etmenizi sağlar. Bu kılavuz, davranışların nasıl oluşturulup birleştirileceğini, zamanlamalarının nasıl yapılandırılacağını, mevcut animasyonların nasıl inceleneceğini ve değiştirileceğini ve özelliklerinin bir sunumun kaydedilip yeniden açılması sırasında korunup korunmadığını gösterir.

Önceden tanımlı efektler ve tıklama tetikleyicileri için [Şekil Animasyonu](/slides/tr/net/shape-animation/) bölümüne bakın.

## **Animasyon Modelini Anlama**

Bir animasyon **Zaman Çizelgesi → Dizi → Efekt → Davranışlar** şeklinde düzenlenir:

- Slaytın [Timeline](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/timeline/) içinde ana dizi ve etkileşimli diziler bulunur.
- Bir [ISequence](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/) efektleri içerir; bu efektler farklı şekilleri hedefleyebilir.
- Bir [IEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/) hedef şekli, hazır ayarı, alt tipini ve efekt zamanlamasını tanımlar.
- [IEffect.Behaviors](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/behaviors/) etkili işlemleri içerir: renk değiştirme, taşıma, döndürme, özellik ayarlama vb.

## **Tek Tek Davranışlar Oluşturma**

Bir efekt oluşturmak ve onun [Behaviors](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/behaviors/) koleksiyonuna erişmek için [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) çağırın. Bir hazır ayar bu koleksiyonu otomatik olarak doldurabilir. Hazır ayarı genişletirken operasyonlarını koruyun veya kasıtlı olarak değiştirmek istiyorsanız [Clear](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorcollection/clear/) kullanın.

[IBehaviorFactory](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorfactory/) aşağıda gösterilen sekiz davranış türünü oluşturur. Hareket, [Bir Hareket Yolu Oluşturma](#build-a-motion-path) bölümünde ele alınır. Her oluşturma örneği tam bir programdır; sonraki düzenleme örnekleri hangi çıktı dosyasını kullandıklarını belirtir.

### **Döndürme**

Bir döndürme oluşturmak için [CreateRotationEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) kullanın. [By](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/irotationeffect/by/) derece cinsinden göreceli bir açı belirtir; [From](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/irotationeffect/from/) ve [To](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/irotationeffect/to/) uç noktaları tanımlar.

Örnek bir Spin etkisiyle başlar, hazır ayarın işlemlerini bir döndürme davranışıyla değiştirir ve bu işleme iki saniyelik bir süre verir. 90 derecelik göreceli bir açı, şeklin başlangıç yönünden bir çeyrek dönüş anlamına gelir; bu yüzden açık bir başlangıç açısına gerek yoktur.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` bir şekil ve bir döndürme davranışı içerir. Aşağıdaki koleksiyon, zamanlama ve döndürme‑düzenleme örnekleri bu dosyayı kullanır.

### **Ölçeklendirme**

[X/Y] yüzde değerleriyle [CreateScaleEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) kullanın: [From](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/iscaleeffect/from/) ve [To](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/iscaleeffect/to/) başlangıç ve bitiş boyutlarını tanımlar, [By](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/iscaleeffect/by/) ise göreceli bir değişikliği tanımlar. Burada 100 orijinal boyutu ifade eder.

Örnek iki saniye içinde hem yatay hem de düşey boyutları %100'den %125'e çıkarır. Yatay ve düşey yüzde değerlerini eşit tutmak şeklin en/boy oranını korur; farklı yüzde değerleri bir boyutu diğerinden daha fazla uzatır.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **Renk**

[CreateColorEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) ile dolgu rengini mavi → turuncu olarak değiştirin. [From](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/icoloreffect/from/) ve [To](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/icoloreffect/to/) renklerdir; [By](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/icoloreffect/by/) bir renk ofsetidir. [IBehavior.Properties](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehavior/properties/) animasyonun hangi özelliği etkilediğini belirler.

Şeklin katı dolgusu mavi olarak başlatılır; bu, animasyonun başlangıç rengine uyar. Dolgu‑renk özelliğini seçmek davranışa hangi kısımların değişeceğini söyler; sadece renk uç noktaları bu özelliği tanımlamaz. Kaydedilen efekt, iki saniyelik bir turuncuya geçişi tanımlar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **Filtre**

[CreateFilterEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) ile bir süpürme (wipe) seçin. [Type](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ifiltereffect/subtype/) ve [Reveal](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ifiltereffect/reveal/) sırasıyla filtreyi, yönü ve şeklin gösterilip gizleneceğini belirler.

Bu örnek, sağ‑yön alt tipini kullanarak şekli gösterecek iki saniyelik bir süpürme ayarlar. Filtre ayarları, efekt içindeki davranışa ait olduğundan, hazır ayarın orijinal işlemleri kaldırıldıktan sonra yapılandırılır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **Özellik**

[CreatePropertyEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) ile saydamlığı animasyonlayın. [From](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ipropertyeffect/to/) ve [By](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ipropertyeffect/by/) dizeleri, sırasıyla [ValueType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ipropertyeffect/valuetype/) ve [CalcMode](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ipropertyeffect/calcmode/) ile yorumlanır. Üç değeri de rastgele ayarlamak yerine uç noktaları ya da göreceli bir ofseti seçin.

Burada seçilen özellik saydamlık; sayısal dizeler %25 saydamlıktan tam saydamlığa bir değişimi temsil eder. Doğrusal içbükeylik, bu değerler arasındaki kademeli değişimi tanımlar. Başka bir özellik için bu örneği uyarlarken, o özelliğe uygun bir değer türü ve uç değerler seçin.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **Ayarlama (Set)**

[CreateSetEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) ile [To](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/iseteffect/to/) aracılığıyla görünürlüğü belirleyin. Bir set davranışı uç noktalar arasında ara değer üretmez.

Örnek görünürlük özelliğini seçer ve davranış çalıştığında `visible` dizisini atar. Dikdörtgen bu minimal sunumda zaten görünür olduğundan, atama tek başına belirgin bir görsel değişiklik yaratmayabilir. Bu işlem, aynı zamanda şeklin ne zaman gizleneceğini ya da görünür hâle geleceğini kontrol eden daha büyük bir etkinin parçası olarak faydalıdır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **Komut**

[CreateCommandEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) kullanın ve [Type](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/icommandeffect/commandstring/) ile [ShapeTarget](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/icommandeffect/shapetarget/) ayarlayın. Çalışma dizinine `sample.wav` adlı bir WAV kaydı koyun. Bu örnek, [AddAudioFrameEmbedded](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addaudioframeembedded/) ile kaydı gömer ve ses çerçevesine bir oynatma komutu ekler.

Ses çerçevesi hem efektin hem de komutun hedefidir. Bu, oynatma isteğini yerleşik kayda bağlar; yalnız bir komut dizisi hangi medya nesnesinin kontrol edileceğini belirtmez. Efekt, slayt gösterisi sırasında bir tıklamayla başlaması için yapılandırılır.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

Kaydetme, komutu `command.pptx` içinde saklar; kaydı otomatik olarak çalmaz. Çalma, komutu ve medya hedefini destekleyen bir slayt gösterisi oynatıcı gerektirir.

## **Davranış Koleksiyonunu Yönetme**

[IBehaviorCollection](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorcollection/) [Add](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorcollection/remove/), ve [RemoveAt](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorcollection/removeat/) metodlarını destekler. Bu örnek `rotation.pptx` dosyasını açar, ölçeklendirme ekler, döndürmeden önce taşır ve döndürmeyi kaldırır. Aynı nesneyi kaldırıp yeniden eklemek, kopya oluşturmadan konumunu değiştirir.

Düzenleme sırası koleksiyonu döndürme–ölçeklendirme’den ölçeklendirme–döndürme’ye, ardından yalnız ölçeklendirmeye değiştirir. Dizinler mevcut koleksiyona göre değerlendirilir; kaldırma işlemi yeniden sıralamadan sonra döndürmenin yeni dizinini kullanır. Son sıralama, hangi davranışın kaydedileceğini doğrular.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

Çıktı `ScaleEffect` olur: yalnız ölçeklendirme kalır. Koleksiyon sırası tek başına davranışları birbiri ardına zamanlamak için kullanılmaz. Tüm işlemleri değiştirdiğinizde koleksiyonu [Clear](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorcollection/clear/) edin.

## **Davranış Zamanlamasını Yapılandırma**

[IBehavior.Timing](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehavior/timing/) [ITiming](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/) nesnesini, [IEffect.Timing](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/timing/) bağımsız olarak ortaya koyar. Efekt zamanlaması içinde bulunduğu efekti planlarken, davranış zamanlaması onun içindeki bir işlemi tanımlar.

### **Süre, Gecikme, Tekrar ve Hızlanma Ayarlama**

`rotation.pptx` dosyasını açın ve saniye cinsinden [Duration](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/duration/) ile [TriggerDelayTime](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/triggerdelaytime/) ayarlayın; ardından [RepeatCount](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatcount/) yapılandırın. [Accelerate](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/accelerate/) ve [Decelerate](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/decelerate/) süreye oran olarak verilirdir; toplamları en fazla 1 olmalıdır.

Girdi dosyası, döndürme örneğinde oluşturulan dosyadır; ilk davranışın bir döndürme olduğu bilinir. Bu örnek yalnız o davranışın zamanlamasını değiştirir; 90 derecelik açı aynı kalır. Açıyı ve zamanlamayı ayrı tutmak, animasyonu yeniden oluşturmadan hızı ayarlamayı kolaylaştırır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

Davranış iki saniyelik bir süre, yarım saniyelik bir gecikme ve 3 tekrar sayısı kullanır. Süresinin ilk ve son %20'si hızlanma ve yavaşlamaya ayrılmıştır.

Diğer tekrar politikaları arasında [RepeatDuration](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilendslide/), ve [RepeatUntilNextClick](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilnextclick/) bulunur; hepsini aynı anda etkinleştirmek yerine birini seçin. [AutoReverse](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/autoreverse/) animasyonu ileri geçişin ardından geriye oynatır. Hızlanma ve yavaşlama, sürekli değişimlere uygulanır; ayrı atamalar ya da komutlar bu etkiye tabi değildir.

## **Bir Hareket Yolu Oluşturma**

[CreateMotionEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) ile hareket oluşturun. [From](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotioneffect/to/) ve [By](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotioneffect/by/) yüzde tabanlı koordinatları veya ofsetleri tanımlar. Düzenlenebilir bir rota için bir [MotionPath](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/motionpath/) oluşturun ve bunu [IMotionEffect.Path](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotioneffect/path/) özelliğine atayın. [IMotionPath](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotionpath/) yol komutlarını depolar.

[MotionCommandPathType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/motioncommandpathtype/) aşağıdaki işlemi seçer:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Başlangıç konumunu ayarlar. |
| LineTo | One | Düz bir segment boyunca uç noktasına hareket eder. |
| CurveTo | Three | İki kontrol noktası ve bir uç nokta ile tanımlı kübik eğriyi izler. |
| CloseLoop | None | Başlangıç konumuna geri döner. |
| End | None | Yolu tamamlar. |

[MotionPathPointsType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/motionpathpointstype/) nokta düzenleme özelliklerini (köşe ya da pürüzsüz nokta gibi) tanımlar; komut tipini değiştirmez. Aşağıdaki eğri örneği için bir curve point type, düz segmentler için ise bir corner point type kullanın.

Yol koordinatları slayt boyutlarına göre normalize edilir: X ekseninde 0.25 kayma slayt genişliğinin dörtte birini temsil eder, 0.25 puan değil. Y ekseni pozitif yönde aşağı doğru ilerler. Mutlak komutlar yol koordinat sistemindeki konumları, göreceli komutlar ise mevcut konuma olan ofsetleri belirtir. Bu, [Origin](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotioneffect/origin/) ile seçilen referans çerçevesi ve [PathEditMode](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotioneffect/patheditmode/) ile şekil taşındığında yolun nasıl hareket edeceği ayarlarından ayrıdır.

### **Düz Bir Yol Oluşturma**

Başlangıç noktasına, bir düz segmente ve bir son komuta sahip bir hareket davranışı oluşturun. [IMotionPath.Add](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotionpath/add/) komut tipini, noktalarını, nokta tipini ve göreceli‑koordinat bayrağını alır.

Başlangıç komutu (0, 0) konumunu belirler ve çizgi (0.25, 0)’da sona erer; bu, slayt genişliğinin dörtte birine yatay bir kayma verir. Son komutun koordinat noktası yoktur. Yol atandığında, hareket davranışı bu rotayı dikdörtgene bağlar.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` üç yol komutu içeren bir hareket davranışı barındırır. Aşağıdaki dosya‑düzenleme örnekleri bu yapıyı varsayar.

### **Mutlak ve Göreceli Koordinatları Karşılaştırma**

Bu iki yol nesnesi aynı rotayı tanımlar. Mutlak komut (0.3, 0.1)’de biter; göreceli komut mevcut konuma (0.1, 0.1) ekleyerek (0.2, 0)’e ulaşır.

Her iki yol da aynı konumdan başlar. Göreceli çizgi için X ve Y ofsetlerini mevcut konuma ekleyerek uç nokta elde edilir; mutlak çizgi için uç nokta doğrudan okunur. Bayrağı koordinatları dönüştürmeden değiştirirseniz farklı bir rota tanımlanır.

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Her iki yolu da bir hareket davranışına atayarak sunumda kullanabilirsiniz. Son Boolean argüman, o komut için göreceli koordinatları seçer.

### **Bir Çizgiyi Eğriyle Değiştirme**

`motion.pptx` dosyasını açın ve çizgi komutunu bir kübik eğriyle değiştirin. Önce iki kontrol noktasını, ardından uç noktayı sağlayın.

Başlangıç konumu önceki komut tarafından belirlenir. İlk iki nokta eğriyi şekillendirirken üçüncüsü varış noktasını belirler; bunlar ardışık üç hedef değildir. Komut tipini, nokta‑düzenleme tipini ve nokta dizisini birlikte güncellemek, segmenti yeni geometrisiyle tutarlı tutar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

`curve.pptx` içindeki yol hâlâ üç komuta sahiptir; orta komut şimdi bir eğri tanımlar.

## **Kaydedilmiş Bir Yolu İnceleme ve Düzenleme**

Her [IMotionCmdPath](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotioncmdpath/) [Points](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotioncmdpath/pointstype/) ve [IsRelative](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotioncmdpath/isrelative/) özelliklerini sunar. Aşağıdaki örnekler `motion.pptx` içinde bilinen üç‑komutlu yolu kullanır. Rastgele bir girdi için önce hedef efekti bulun, komut tiplerini ve nokta sayılarını indeksle düzenlemeden önce kontrol edin.

### **Komutları ve Koordinatları Okuma**

Yolu değişmeden okuyun. End ve close‑loop komutları nokta gerektirmez; bu yüzden null bir nokta dizisine izin verin.

Çıktı, her komutu ilgili göreceli‑koordinat bayrağıyla eşleştirir, ardından noktalarını listeler. Bu, yolu değiştirmeden önce bir uç noktayı ofsetten ayırmanıza olanak tanır. Eğri üç nokta listeler; bu dosyadaki düz çizgi yalnız bir nokta listeler.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

Liste bir başlangıç noktası, (0.25, 0)’de biten mutlak bir çizgi ve bir end komutu içerir.

### **Uç Noktayı Değiştirme**

`motion.pptx` dosyasını açın ve çizginin nokta dizisini değiştirerek uç noktasını taşıyın.

Girdi dosyasında indeks 0 başlangıç komutu, indeks 1 çizgidir. Çizginin tek noktasını değiştirerek hedefi, komut tipini, zamanlamasını veya koleksiyondaki konumunu etkilemeden değiştirirsiniz. Komut mutlak koordinat kullandığından, yeni çift bir konumu temsil eder; ofset eklemez.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

`motion-endpoint.pptx` içindeki çizgi (0.4, 0.1)’de biter; orijinal dosya değişmemiştir.

### **Bir Segmenti Değiştirme**

[Insert](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotionpath/insert/) ve [RemoveAt](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/imotionpath/removeat/) kullanarak `motion.pptx` içindeki çizgiyi değiştirin. Ekleme, eski çizgiyi indeks 2’ye kaydırır.

Bu, mevcut koordinatları düzenlemek yerine bir komut nesnesini değiştirmenin gösterimidir. Eklemeden sonra koleksiyon geçici olarak başlangıç komutu, yeni çizgi, eski çizgi ve end komutu içerir. İndeks 2’yi kaldırmak eski çizgiyi atar ve yeni rotayı yerinde bırakır.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

Kaydedilen yol hâlâ üç komuta sahiptir; yeni çizgi (0.2, 0.1)’de biter ve end komutu son sıradadır.

## **Mevcut Bir Davranışı Değiştirme ve Doğrulama**

Davranışın indeksi bilinmiyorsa, türüne göre seçin. Bu örnek `rotation.pptx` dosyasını açar, [IRotationEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/irotationeffect/) bulur, açıyı değiştirir ve dosyayı yeniden açtıktan sonra kaydedilen değeri kontrol eder.

Tür kontrolü, döndürme olmayan davranışları döngüde atlamanızı sağlar. İkinci yükleme, kaydedilen dosyayı ayrı bir sunum nesnesine okur; böylece karşılaştırma bellekte hâlâ tutulan değer yerine kalıcı veriyi inceler. Bu örnek, bilinen etkinin ana dizide ilk olduğu varsayımına dayanır; türüne göre davranış seçmek rastgele bir sunumda doğru etkiyi bulmayabilir.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

Çıktı `Rotation preserved: True` olur. Aynı tür‑kontrol desenini diğer davranışlar için de uygulayın. Tam bir koruma kontrolü için hedef şekil, efekt, davranış türleri ve sırası, zamanlama ve yol komutlarını karşılaştırın. Ondalıklı değerler için sayısal bir tolerans kullanın. Animasyon düzeni bilinmeyen bir sunum için, ana ve etkileşimli dizileri dolaşmak üzere [Şekil Animasyonlarını Oku](/slides/tr/net/shape-animation/#read-shape-animations) bölümüne bakın.

## **Davranış Sırası, Hazır Ayarlar ve Oynatma**

[IBehaviorCollection](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehaviorcollection/) içindeki sıra, bir efektin işlemlerinin depolanma sırasıdır. Bu, her davranışın otomatik olarak öncekini bekleyeceği bir çalma listesi değildir. Zamanlama ve kapsayan efekt planlamayı belirler. Davranışlar örtüşebilir ve aynı özelliğe ait işlemler [Additive](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehavior/additive/) ve [Accumulate](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ibehavior/accumulate/) yoluyla etkileşebilir. “Taşı, sonra döndür” gibi bir zamanlama elde etmek için sadece koleksiyon sırasını değiştirmeyin; [Şekil Animasyonu](/slides/tr/net/shape-animation/) bölümünde açıklandığı gibi açık zamanlama veya ayrı efektler kullanın.

Efektin [Type](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/type/) ve [Subtype](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/subtype/) hazır ayarı tanımlar; bu, düzenlenmiş bir davranış ağacının tam bir tanımı değildir. Özelleştirilmiş davranışları özelleştirmeden önce hazır ayar ve alt tipini seçin: hazır ayarı değiştirmek koleksiyonu yeniden oluşturur ve özel işlemlerinizi silebilir. Örneğin, özelleştirilmiş bir Spin etkisini Fade’a değiştirirseniz, döndürme davranışı set ve filter davranışlarıyla değiştirilir. Hazır ayar veya alt tip değiştirildikten sonra koleksiyonu tekrar inceleyin. Hazır ayar davranışlarını temizlemek, hazır ayarın ihtiyaç duyduğu görünürlük veya başlatma işlemlerini de kaldırabilir. Örnekler, görünür şekiller kullanır ve davranışları değiştirir; her hazır ayarın tüm uygulamasını yeniden oluşturmaz.

## **Biçim Uyumluluğu**

Korunan bir davranış ağacı, her izleyici veya dışa aktarım motorunda aynı oynatımı garanti etmez. Kaydedilen veriyi ve oluşturulan çıktıyı ayrı ayrı kontrol edin.

| Biçim veya çıktı | Kontrol Edilecekler |
| --- | --- |
| PPTX | Bu örneklerde birincil biçim olarak kullanın. Düzenlenebilir davranış ağacını doğrulamak için yeniden açın, ardından hedef PowerPoint sürümünde oynatımı test edin. |
| PPT | Eski ikili temsil PPTX’den farklılık gösterebilir. Ayrı bir kaydet‑yeniden‑aç döngüsü ve oynatım testi yapın; PPTX çıktısının başarılı olması, her özel kombinasyonun desteklendiğini göstermez. |
| PDF, PNG, JPEG ve diğer statik slayt görselleri | Statik slayt temsili içerir; oynatılabilir bir davranış zaman çizelgesi veya garantili bir son animasyon karesi yoktur. |
| [HTML5](/slides/tr/net/export-to-html5/) | Dışa aktarma seçeneklerinde şekil animasyonu etkinleştirildiğinde desteklenen animasyonları oynatabilir. Tarayıcıda özel kombinasyonları test edin. |
| [Animasyonlu GIF](/slides/tr/net/convert-powerpoint-to-animated-gif/) | Oluşturulmuş kareleri saklar; düzenlenebilir davranışları veya tıklama‑tetiklenen etkileşimi içermez. Gerçek hareketi kontrol edin. |
| [Video](/slides/tr/net/convert-powerpoint-to-video/) | Animasyon karelerini işleyip videoya kodlar. Destek, renderlayıcının [desteklenen animasyon ve efektleri](/slides/tr/net/convert-powerpoint-to-video/#supported-animations-and-effects) ile sınırlıdır; komutlar ve etkileşimli olaylar düzenlenebilir bir zaman çizelgesine dönüşmez. |

## **SSS**

**Efektime bir davranış eklemeden önce neden zaten davranışlar var?**

Önceden tanımlı bir efekt, temel işlemlerini otomatik olarak oluşturabilir. Hazır ayarı genişletmek mi yoksa davranışlarını değiştirmek mi istediğinize karar vermeden önce onları inceleyin.

**Bir davranışı başa taşısam önce mi oynatılır?**

Zorunlu değildir. Koleksiyon sırası zamanlamanın yerini tutmaz. Gecikmeleri, süreleri ve aynı özellik üzerindeki işlemlerin etkileşimini kontrol edin.

**Neden bir end komutunun noktası yok?**

Yolun sonunu işaret eder ve koordinat gerektirmez. Dosyadan okunan bir yolda null bir nokta dizisi olup olmadığını kontrol edin.

**Başarılı bir tur (round‑trip) oynatımı teyit etmek için yeterli mi?**

Hayır. Yeniden açma, kontrol ettiğiniz özelliklerin korunup korunmadığını gösterir. Görsel davranışı teyit etmek için slayt gösterisi oynatıcı veya animasyonlu dışa aktarımı ayrı ayrı test edin.
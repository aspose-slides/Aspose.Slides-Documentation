---
title: Sunumlarda Şekil Animasyonlarını .NET'te Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/net/shape-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile şekil animasyonlarını, zamanlamayı, sesleri, animasyon sonrası davranışı ve animasyonlu metni ekleme, inceleme ve özelleştirme yöntemlerini öğrenin."
---
## **Genel Bakış**

Aspose.Slides for .NET slayt animasyonlarını bir slayt zaman çizelgesindeki efektler olarak temsil eder. Bir efektin hedef şekli, bir animasyon tipi ve alt tipi, bir tetikleyicisi, zamanlama ayarları ve ses ya da animasyon sonrası davranış gibi isteğe bağlı özellikleri bulunur.

Zaman çizelgesi iki tür dizi içerir:

- **Ana dizi** slayt ilerledikçe oynatılır.
- **Etkileşimli dizi** tetikleyici şekli tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) arayüzünü uyguladığından, çoğu slayt içeriği için aynı [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) metodunu kullanırsınız. Kullanılabilir efektler [EffectType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttype/) sayımında listelenmiştir.

## **Şekil Animasyonlarını Ekle**

Bir animasyon eklemek için slaytın ana dizisini alın ve hedef şekil, efekt tipi, alt tip ve tetikleyici ile [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) metodunu çağırın. Başka bir şekil tıklandığında başlayan bir efekt için, tetikleyicisi o başka şekil olan bir etkileşimli dizi oluşturun.

Aşağıdaki örnek her iki animasyon tipini oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

Tetikleyici, bir efektin ne zaman başlayacağını kontrol eder:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttriggertype/) ana dizide bir tıklama veya etkileşimli dizide tetikleyici şekle tıklama bekler.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttriggertype/) önceki efekt ile birlikte başlar.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttriggertype/) önceki efekt tamamlandığında başlar.

Bir resmi, grafiği veya başka bir şekil türünü animasyonlamak için, `targetShape` yerine bu nesneyi [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) metoduna geçirin. Grafiklere özgü grup seçenekleri için [Animated Charts](/slides/tr/net/animated-charts/) sayfasına bakın.

## **Şekil Animasyonlarını Oku**

Hedef şekli bildiğinizde [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/geteffectsbyshape/) metodunu kullanın. Her bir efekti incelemek için ana diziyi ve tüm etkileşimli dizileri döngüyle enumerate edin. Enumerasyon, bir dizinin `0` indeksinde bir efekt olduğunu varsımaktan kaçınır.

Aşağıdaki örnek, ana dizi ve etkileşimli efektlere sahip bir şekil oluşturur, şekli hedefleyen efektleri alır ve ardından slayttaki her diziyi enumerate eder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

Sadece bir şekil için efektlere ihtiyacınız varsa, önce şekli ad, yer tutucu türü veya başka bir sabit özellik ile tanımlayın; ardından [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/geteffectsbyshape/) metodunu çağırın. [IShapeCollection.Item](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/item/) metodunun `0` indeksindeki öğenin her zaman istenen nesne olduğunu varsımayın.

## **Kalıtılmış Yer Tutucu Efektleriyle Çalışma**

Normal bir slayttaki bir yer tutucu, düzen slaytı ve ana slaytındaki karşılık gelen yer tutucudan animasyon davranışını devralabilir. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/getbaseplaceholder/) bu üst yer tutucuyu döndürür; yoksa `null`.

Aşağıdaki örnek sunumda, altbilgi normal slaytta **Random Bars**, düzen slaytta **Split** ve ana slaytta **Fly In** animasyonuna sahiptir.

![Normal slayttaki altbilgi animasyon etkisi](slide-shape-animation.png)
![Düzen slayttaki altbilgi yer tutucu animasyon etkisi](layout-shape-animation.png)
![Ana slayttaki altbilgi yer tutucu animasyon etkisi](master-shape-animation.png)

Sonraki örnek yer tutucu hiyerarşisini kendisi oluşturur. Bir ana yer tutucuya, bir düzen yer tutucuya ve normal slayttaki karşılık gelen yer tutucuya efektler ekler. Döndürülen şekil kullanılmadan önce her [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/getbaseplaceholder/) çağrısı kontrol edilir.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **Animasyon Zamanlamasını Değiştirme**

PowerPoint **Timing** iletişim kutusu [ITiming](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/) özelliklerine karşılık gelir.

![Bir animasyon efekti için PowerPoint Zamanlama iletişim kutusu](shape-animation.png)

- **Başlat** [ITiming.TriggerType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/triggertype/) ile eşlenir.
- **Süre** [ITiming.Duration](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/duration/) ile eşlenir, saniye cinsinden.
- **Gecikme** [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/triggerdelaytime/) ile eşlenir, saniye cinsinden.
- **Tekrar** [ITiming.RepeatCount](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilnextclick/) ya da [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilendslide/) ile eşlenir.
- **Oynatma tamamlandığında geri sar** [ITiming.Rewind](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/rewind/) ile eşlenir.

Bu bağımsız örnek bir efekt ekler, zamanlamasını [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) tarafından döndürülen nesne üzerinden değiştirir ve sonucu kaydeder. Döndürülen [IEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/) referansının tutulması gereksiz bir koleksiyon indeksinden kaçınır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

Bilerek yalnızca bir tekrar modunu kullanın. Tekrar sayısını bir “until” bayrağıyla birleştirmek farklı görüntüleyicilerde kafa karıştırıcı sonuçlar doğurabilir. Tekrar modlarını değiştirirken önce [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilnextclick/) ve [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilendslide/) ayarlayın, ardından [ITiming.RepeatCount](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatcount/) ayarlayın; çünkü bu bayrakların ayarlanması aktif tekrar modunu da değiştirir.

## **Animasyon Seslerini Ekle ve Çıkar**

Bir animasyon efekti, gömülü ses dosyasına [IEffect.Sound](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/sound/) aracılığıyla başvurabilir. [IEffect.StopPreviousSound](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/stopprevioussound/) bir efektin önceki bir efekt tarafından başlatılan sesi durdurmasını sağlar.

### **Bir Efekte Ses Ekle**

Aşağıdaki örnek `animation-sound.wav` adlı yerel bir ses dosyası olduğunu varsayar. İki efekt oluşturur, bu dosyayı birinci efekt için ses olarak gömer ve ikinci efekti sesi durduracak şekilde yapılandırır. [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) tarafından döndürülen nesneleri kullanır, bu yüzden bir dizi indeksi gerekli değildir.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **Gömülü Efekt Seslerini Çıkar**

Aşağıdaki örnek `presentation-with-animation-sounds.pptx` adlı yerel bir sunum olduğunu varsayar. Hem ana hem de etkileşimli dizileri tarar ve her gömülü efekt sesini `extracted-animation-sounds` dizinine yazar. Uzantı, [IAudio.ContentType](https://reference.aspose.com/slides/tr/net/aspose.slides/iaudio/contenttype/) tarafından sunulan ses MIME türünden seçilir.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

Büyük ses nesneleri için, tüm nesneyi bayt dizisine yüklemek yerine [IAudio.GetStream](https://reference.aspose.com/slides/tr/net/aspose.slides/iaudio/getstream/) kullanın ve akışı bir dosyaya kopyalayın.

## **Animasyon Sonrası Davranışı Ayarla**

**After animation** seçeneği, bir efekt tamamlandıktan sonra şeklin ne olacağını kontrol eder.

![After animation ayarlarını gösteren PowerPoint Efekt Seçenekleri iletişim kutusu](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) sayımı, şekli değiştirmeden bırakmayı, rengini değiştirmeyi, animasyondan sonra gizlemeyi ya da bir sonraki tıklamada gizlemeyi destekler. Tür [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) olduğunda, ayrıca [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/afteranimationcolor/) ayarlanmalıdır.

Bu bağımsız örnek bir efekt oluşturur, döndürülen efekt nesnesi aracılığıyla animasyon sonrası davranışını ayarlar ve sonucu kaydeder.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) dışındaki bir tipe geçmek, animasyon sonrası renk ayarını temizler.

## **Metni Animasyonla**

Metin animasyonu iki ilgili kontrol içerir:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itextanimation/buildtype/) paragrafların birlikte mi yoksa paragraf seviyesinde mi görüneceğini kontrol eder.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/animatetexttype/) metnin hepsinin bir anda, kelime kelime ya da harf harf görünüp görünmeyeceğini kontrol eder. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/delaybetweentextparts/) kelimeler veya harfler arasındaki gecikmeyi ayarlar. Pozitif değer, etkinin süresinin bir yüzdesidir; negatif değer saniye cinsinden bir gecikmedir.

Aşağıdaki bağımsız örnek bir metin kutusundaki kelimeleri animasyonlar. [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/buildtype/) paragraf bazlı oluşturmayı devre dışı bırakır, böylece kelime ayarı tüm metin çerçevesine uygulanır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

Metin kutusunu paragraf bazında oluşturmak için [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/buildtype/) (veya başka bir paragraf seviyesi) ayarlayın. Tek bir paragrafı kendi efektiyle hedeflemek için, bir [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) kabul eden [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) aşırı yüklemesini kullanın. Paragraf seviyesindeki örnekler için [Animated Text](/slides/tr/net/animated-text/) sayfasına bakın.

## **Dışa Aktarma ve Uyumluluk Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından kontrol edilir.
- PDF ve statik görüntüler animasyonları oynatmaz. Çıktının hareket göstermesi gerektiğinde [HTML5 export](/slides/tr/net/export-to-html5/), animasyonlu GIF veya [video conversion](/slides/tr/net/convert-powerpoint-to-video/) kullanın.
- HTML5 için, [Html5Options.AnimateShapes](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/animateshapes/) etkinleştirin ve gerektiğinde [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/animatetransitions/) etkinleştirin.
- Video işleme, birçok yaygın giriş, vurgu, çıkış ve hareket yolu efektini destekler, ancak her PowerPoint efekti desteklenmez. Mevcut [supported animations and effects](/slides/tr/net/convert-powerpoint-to-video/#supported-animations-and-effects) sayfasını kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzle test edin.
- Gelişmiş özel efektler ve diğer sunum formatlarından içe aktarılan efektler dosyada saklanabilir ancak PowerPoint, HTML5 veya videoda farklı şekilde işlenebilir. Sonucu yalnızca efekt adına güvenmek yerine dışa aktarılan sonucu doğrulayın.

## **SSS**

**Neden bir animasyon PowerPoint'te görünür fakat PDF'de görünmez?**

PDF statik bir format olduğundan animasyonlar ve slayt geçişleri oynatılmaz. Hareketin korunması gerektiğinde HTML5, animasyonlu GIF veya video olarak dışa aktarın.

**Neden bir efekt videoda farklı oynatılır?**

Video dışa aktarımı, animasyonları render eder, orijinal PowerPoint davranışını saklamaz. Bazı gelişmiş efektler desteklenmez veya yaklaşık olarak işlenir. Desteklenen efektler tablosunu inceleyin ve üretim öncesinde gerçek sunumu test edin.

**Bir şekli ileri ya da geri taşımak animasyon sırasını değiştirir mi?**

Hayır. Şeklin z-sırası üst üste binmeyi kontrol eder, dizi sırası ve tetikleyiciler animasyon oynatımını kontrol eder. Farklı bir oynatma sırası gerekiyorsa zaman çizelgesini değiştirin.
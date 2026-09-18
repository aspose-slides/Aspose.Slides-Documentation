---
title: .NET'te Sunumlarda Şekil Animasyonlarını Uygulama
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
description: "Aspose.Slides for .NET ile şekil animasyonları, zamanlamalar, sesler, animasyon sonrası davranışlar ve animasyonlu metin eklemeyi, incelemeyi ve özelleştirmeyi öğrenin."
---
## **Genel Bakış**

Bir etki içindeki bireysel davranışlarla çalışmak veya hareket yolu segmentlerini düzenlemek için, bakınız [Özel Animasyon](/slides/tr/net/custom-animation/).

Aspose.Slides for .NET, slayt animasyonlarını bir slayt zaman çizelgesindeki efektler olarak temsil eder. Bir efektin hedef şekli, bir animasyon tipi ve alt tipi, bir tetikleyicisi, zamanlama ayarları ve ses ya da animasyon sonrası davranış gibi isteğe bağlı özellikleri vardır.

Zaman çizelgesi iki tür dizi içerir:

- **Ana dizi**, slayt ilerledikçe oynatılır.
- **Etkin etkileşimli dizi**, tetikleyici şekli tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) uyguladığı için, çoğu slayt içeriği için aynı [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) metodunu kullanırsınız. Kullanılabilir efektler [EffectType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttype/) sayımında listelenir.

## **Şekil Animasyonları Ekleme**

Bir animasyon eklemek için, slaytın ana dizisini alın ve hedef şekil, efekt tipi, alt tip ve tetikleyici ile [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) metodunu çağırın. Başka bir şekil tıklandığında başlayan bir efekt için, tetikleyicisi o diğer şekil olan bir etkileşimli dizi oluşturun.

Aşağıdaki örnek her iki animasyon türünü oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttriggertype/) ana dizide bir tıklama veya etkileşimli dizide tetikleyici şekle bir tıklama bekler.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttriggertype/) önceki efektle birlikte başlar.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttriggertype/) önceki efekt tamamlandığında başlar.

Bir resmi, grafiği veya başka bir şekil türünü animasyonlamak için, `targetShape` yerine o nesneyi [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) metoduna geçirin. Grafik özel grup seçenekleri için, bakınız [Animasyonlu Grafikler](/slides/tr/net/animated-charts/).

## **Şekil Animasyonlarını Okuma**

Hedef şekli bildiğinizde [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/geteffectsbyshape/) metodunu kullanın. Her efekti incelemek için, ana diziyi ve her etkileşimli diziyi döngüyle gezinin. Döngüleme, bir dizinin `0` indeksinde bir efekt olduğunu varsaymayı önler.

Aşağıdaki örnek, ana dizi ve etkileşimli efektlerle bir şekil oluşturur, şekli hedefleyen efektleri alır ve ardından slayttaki her diziyi döngüyle gezerek listeler.

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

Yalnızca tek bir şekil için efektlere ihtiyacınız varsa, önce şekli ad, yer tutucu türü veya başka bir sabit özellik ile tanımlayın; ardından [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/geteffectsbyshape/) metodunu çağırın. [IShapeCollection.Item](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/item/) metodunun `0` indeksindeki nesnenin her zaman istediğiniz nesne olduğunu varsaymayın.

## **Kalıtılmış Yer Tutucu Efektleriyle Çalışma**

Normal bir slayttaki yer tutucu, yerleşim slaytındaki ve ana slayttaki karşılık gelen yer tutucudan animasyon davranışını devralabilir. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/getbaseplaceholder/) bu ebeveyn yer tutucusunu döndürür veya ebeveyn yoksa `null` döner.

Aşağıdaki örnek sunumda, alt bilgi normal slaytta **Random Bars**, yerleşim slaytında **Split** ve ana slaytta **Fly In** efektine sahiptir.

![Alt bilgi animasyon efekti normal slaytta](slide-shape-animation.png)

![Alt bilgi yer tutucu animasyon efekti yerleşim slaytında](layout-shape-animation.png)

![Alt bilgi yer tutucu animasyon efekti ana slaytta](master-shape-animation.png)

Sonraki örnek, yer tutucu hiyerarşisini kendisi oluşturur. Bir ana yer tutucuya, bir yerleşim yer tutucuya ve normal bir slayttaki karşılık gelen yer tutucuya efekt ekler. Döndürülen şekil kullanılmadan önce her [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/getbaseplaceholder/) çağrısı kontrol edilir.

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

PowerPoint **Timing** ileti kutusu, [ITiming](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/) özelliklerine eşlenir.

![PowerPoint Zamanlama ileti kutusu bir animasyon efekti için](shape-animation.png)

- **Start** [ITiming.TriggerType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/triggertype/) ile eşlenir.
- **Duration** [ITiming.Duration](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/duration/) ile eşlenir, saniye cinsinden.
- **Delay** [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/triggerdelaytime/) ile eşlenir, saniye cinsinden.
- **Repeat** [ITiming.RepeatCount](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilnextclick/) veya [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilendslide/) ile eşlenir.
- **Rewind when done playing** [ITiming.Rewind](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/rewind/) ile eşlenir.

Bu bağımsız örnek bir efekt ekler, zamanlamasını [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) tarafından döndürülen nesne üzerinden değiştirir ve sonucu kaydeder. Döndürülen [IEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/) referansını tutmak, gereksiz bir koleksiyon indeksinden kaçınır.

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

Tek bir tekrar modunu kasıtlı olarak kullanın. Bir tekrar sayısını bir “until” bayrağı ile birleştirmek, farklı görüntüleyicilerde kafa karıştırıcı sonuçlar doğurabilir. Tekrar modlarını değiştirirken, önce [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilnextclick/) ve [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilendslide/) ayarlayın, ardından [ITiming.RepeatCount](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatcount/) ayarlayın; çünkü herhangi bir bayrağın ayarlanması aktif tekrar modunu da değiştirir.

## **Animasyon Seslerini Ekleme ve Çıkarma**

Bir animasyon efekti, yerleşik ses dosyasına [IEffect.Sound](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/sound/) aracılığıyla referans verebilir. [IEffect.StopPreviousSound](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/stopprevioussound/) bir efekti, önceki bir efekt tarafından başlatılan sesi durdurmaya yönlendirir.

### **Bir Efekte Ses Ekleme**

Aşağıdaki örnek, `animation-sound.wav` adıyla yerel bir ses dosyası bekler. İki efekt oluşturur, bu dosyayı ilk efektin sesi olarak gömer ve ikinci efekti sesi durduracak şekilde yapılandırır. [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) tarafından döndürülen nesneleri kullandığı için dizi indeksine gerek yoktur.

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

### **Gömülü Efekt Seslerini Çıkarma**

Aşağıdaki örnek, `presentation-with-animation-sounds.pptx` adlı yerel bir sunum bekler. Hem ana hem de etkileşimli dizileri tarar ve her gömülü efekt sesini `extracted-animation-sounds` dizinine yazar. Uzantı, [IAudio.ContentType](https://reference.aspose.com/slides/tr/net/aspose.slides/iaudio/contenttype/) tarafından sunulan ses MIME tipinden seçilir.

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

Büyük ses nesneleri için, [IAudio.GetStream](https://reference.aspose.com/slides/tr/net/aspose.slides/iaudio/getstream/) kullanın ve nesneyi bir bayt dizisine yüklemek yerine akışı bir dosyaya kopyalayın.

## **Animasyon Sonrası Davranışı Ayarlama**

**After animation** seçeneği, bir şeklin efekt bitiminde ne olacağını kontrol eder.

![PowerPoint Efekt Seçenekleri ileti kutusu After animation ayarlarını gösteriyor](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) sayımı, şekli değiştirmeden bırakma, rengini değiştirme, animasyondan sonra gizleme veya bir sonraki tıklamada gizleme seçeneklerini destekler. Tür [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) olduğunda, ayrıca [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/afteranimationcolor/) ayarlanmalıdır.

Bu bağımsız örnek bir efekt oluşturur, after‑animation davranışını döndürülen efekt nesnesi aracılığıyla ayarlar ve sonucu kaydeder.

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

[AfterAnimationType.Color](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) türünden başka bir tipe geçmek, after‑animation renk ayarını temizler.

## **Metni Animasyonla**

Metin animasyonu iki ilgili kontrole sahiptir:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itextanimation/buildtype/) paragrafların birlikte mi yoksa paragraf seviyesine göre mi görüneceğini kontrol eder.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/animatetexttype/) metnin tek seferde, kelime bazında veya harf bazında görünüp görünmeyeceğini kontrol eder. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/delaybetweentextparts/) kelimeler veya harfler arasındaki gecikmeyi ayarlar. Pozitif bir değer, efekt süresinin yüzde oranıdır; negatif bir değer saniye cinsinden gecikmedir.

Aşağıdaki bağımsız örnek bir metin kutusundaki kelimeleri animasyonlar. [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/buildtype/) paragraf‑paragraf inşa etmeyi devre dışı bırakır, böylece kelime ayarı tüm metin çerçevesine uygulanır.

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

Bir metin kutusunu paragraf bazında inşa etmek için, [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/buildtype/) (veya başka bir paragraf seviyesi) ayarlayın. Kendi efektine sahip tek bir paragrafı hedeflemek için, bir [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) kabul eden [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/addeffect/) aşırı yüklemesini kullanın. Paragraf‑seviyesi örnekleri için [Animasyonlu Metin](/slides/tr/net/animated-text/) bölümüne bakın.

## **Dışa Aktarım ve Uyumluluk Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından kontrol edilir.
- PDF ve statik görüntüler animasyon oynatmaz. Çıktının hareket göstermesi gerektiğinde [HTML5 dışa aktarma](/slides/tr/net/export-to-html5/), animasyonlu GIF veya [video dönüştürme](/slides/tr/net/convert-powerpoint-to-video/) kullanın.
- HTML5 için, [Html5Options.AnimateShapes](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/animateshapes/) özelliğini etkinleştirin ve gerektiğinde [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/animatetransitions/) özelliğini etkinleştirin.
- Video oluşturma, birçok yaygın giriş, vurgulama, çıkış ve hareket yolu efektini destekler, ancak tüm PowerPoint efektleri desteklenmez. Mevcut [desteklenen animasyonlar ve efektler](/slides/tr/net/convert-powerpoint-to-video/#supported-animations-and-effects) kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzle test edin.
- Gelişmiş özel efektler ve diğer sunum formatlarından içe aktarılan efektler dosyada korunabilir ancak PowerPoint, HTML5 veya video ortamlarında farklı işlenebilir. Yalnızca efekt adına güvenmek yerine dışa aktarılan sonucu doğrulayın.

## **SSS**

**Neden bir animasyon PowerPoint'te görünür ancak PDF'de görünmez?**

PDF statik bir formattır, bu yüzden animasyonlar ve slayt geçişleri oynatılmaz. Hareketin korunması gerektiğinde HTML5, animasyonlu GIF veya video olarak dışa aktarın.

**Neden bir efekt video içinde farklı oynatılır?**

Video dışa aktarımı, orijinal PowerPoint davranışını saklamak yerine animasyonları render eder. Bazı gelişmiş efektler desteklenmez veya yaklaşık olarak uygulanır. Desteklenen efektler tablosunu inceleyin ve üretim öncesinde gerçek sunumu test edin.

**Bir şekli öne veya arkaya taşımak animasyon sırasını değiştirir mi?**

Hayır. Şeklin z‑order'ı üst üste binmeyi kontrol eder, dizi sırası ve tetikleyiciler animasyon oynatımını kontrol eder. Farklı bir oynatma sırası gerekiyorsa zaman çizelgesini değiştirin.
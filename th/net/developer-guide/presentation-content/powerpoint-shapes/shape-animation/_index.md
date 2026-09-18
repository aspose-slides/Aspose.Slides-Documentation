---
title: ประยุกต์ใช้การเคลื่อนไหวรูปทรงในงานนำเสนอด้วย .NET
linktitle: การเคลื่อนไหวรูปทรง
type: docs
weight: 60
url: /th/net/shape-animation/
keywords:
- รูปทรง
- การเคลื่อนไหว
- เอฟเฟกต์
- รูปทรงเคลื่อนไหว
- ข้อความเคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- ดึงการเคลื่อนไหว
- สกัดการเคลื่อนไหว
- เพิ่มเอฟเฟกต์
- ดึงเอฟเฟกต์
- สกัดเอฟเฟกต์
- เสียงของเอฟเฟกต์
- ประยุกต์การเคลื่อนไหว
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่ม ตรวจสอบ และปรับแต่งการเคลื่อนไหวของรูปทรง เวลา เสียง พฤติกรรมหลังการเคลื่อนไหว และข้อความเคลื่อนไหวด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

หากต้องการทำงานกับพฤติกรรมแต่ละอย่างภายในเอฟเฟกต์หรือแก้ไขส่วนของ motion‑path ให้ดูที่ [การเคลื่อนที่กำหนดเอง](/slides/th/net/custom-animation/)

Aspose.Slides for .NET แสดงการเคลื่อนไหวของสไลด์เป็นเอฟเฟกต์ในไทม์ไลน์ของสไลด์ เอฟเฟกต์หนึ่งมีรูปทรงเป้าหมาย, ประเภทและชนิดย่อยของการเคลื่อนที่, ตัวกระตุ้น, การตั้งค่าเวลา, และคุณสมบัติเสริมเช่น เสียงหรือพฤติกรรมหลังการเคลื่อนที่

ไทม์ไลน์ประกอบด้วยสองประเภทของลำดับ:

- **ลำดับหลัก** จะเล่นเมื่อสไลด์ก้าวหน้า
- **ลำดับเชิงโต้ตอบ** จะเริ่มเมื่อรูปทรงตัวกระตุ้นถูกคลิก

เนื่องจากกล่องข้อความ, รูปภาพ, แผนภูมิ, ตารางและวัตถุสไลด์อื่น ๆ ทำตาม [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) คุณจึงใช้เมธอดเดียวกันคือ [ISequence.AddEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/addeffect/) สำหรับเนื้อหาสไลด์ส่วนใหญ่ ผลลัพธ์ของเอฟเฟกต์ที่ใช้ได้อยู่ใน enumeration [EffectType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effecttype/)

## **เพิ่มการเคลื่อนไหวให้รูปทรง**

เพื่อเพิ่มการเคลื่อนไหว ให้รับลำดับหลักของสไลด์และเรียก [ISequence.AddEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/addeffect/) พร้อมรูปทรงเป้าหมาย, ประเภทเอฟเฟกต์, ชนิดย่อยและตัวกระตุ้น สำหรับเอฟเฟกต์ที่เริ่มเมื่อรูปทรงอื่นถูกคลิก ให้สร้างลำดับเชิงโต้ตอบโดยตั้งค่าตัวกระตุ้นเป็นรูปทรงนั้น

ตัวอย่างต่อไปนี้สร้างการเคลื่อนไหวทั้งสองประเภทและบันทึกผลลัพธ์เป็น `shape-animations.pptx`

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

ตัวกระตุ้นกำหนดว่าเอฟเฟกต์จะเริ่มเมื่อใด:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effecttriggertype/) รอการคลิกในลำดับหลัก หรือคลิกบนรูปทรงตัวกระตุ้นในลำดับเชิงโต้ตอบ
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effecttriggertype/) เริ่มพร้อมกับเอฟเฟกต์ก่อนหน้า
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effecttriggertype/) เริ่มเมื่อเอฟเฟกต์ก่อนหน้าจบ

เพื่อทำการเคลื่อนไหวรูปภาพ, แผนภูมิหรือรูปทรงประเภทอื่น ให้ส่งออบเจ็กต์นั้นไปยัง [ISequence.AddEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/addeffect/) แทน `targetShape` สำหรับตัวเลือกการจัดกลุ่มเฉพาะแผนภูมิ ดูที่ [แผนภูมิที่เคลื่อนไหว](/slides/th/net/animated-charts/)

## **อ่านการเคลื่อนไหวของรูปทรง**

ใช้ [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/geteffectsbyshape/) เมื่อคุณทราบรูปทรงเป้าหมาย เพื่อตรวจสอบทุกเอฟเฟกต์ ให้วนลูปผ่านลำดับหลักและทุกลำดับเชิงโต้ตอบ การวนลูปช่วยหลีกเลี่ยงการสมมติว่าลำดับมีเอฟเฟกต์ที่ตำแหน่ง `0`

ตัวอย่างต่อไปนี้สร้างรูปทรงที่มีเอฟเฟกต์ในลำดับหลักและเชิงโต้ตอบ, ดึงเอฟเฟกต์ที่เป้าหมายเป็นรูปทรงนั้น, จากนั้นวนลูปทุกลำดับบนสไลด์

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

หากคุณต้องการเอฟเฟกต์สำหรับรูปทรงเดียวเท่านั้น ให้ระบุตัวรูปทรงโดยชื่อ, ชนิด placeholder หรือคุณสมบัติอื่นที่คงที่ก่อน แล้วเรียก [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/geteffectsbyshape/) อย่าสมมติว่า [IShapeCollection.Item](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/item/) ที่ตำแหน่ง `0` เป็นออบเจ็กต์ที่ต้องการเสมอ

## **ทำงานกับเอฟเฟกต์ Placeholder ที่สืบทอดมาจากแม่แบบ**

Placeholder บนสไลด์ปกติสามารถสืบทอดพฤติกรรมการเคลื่อนไหวจาก placeholder ที่สอดคล้องบนสไลด์เลย์เอาต์และมาสเตอร์ได้ [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/getbaseplaceholder/) จะคืน placeholder พาเรนท์นั้น หรือ `null` หากไม่มีพาเรนท์

ในตัวอย่างงานนำเสนอต่อไปนี้, ส่วนท้ายของสไลด์ปกติมี **Random Bars**, ส่วนบนเลย์เอาต์มี **Split**, ส่วนบนมาสเตอร์มี **Fly In**

![เอฟเฟกต์การเคลื่อนไหวของส่วนท้ายบนสไลด์ปกติ](slide-shape-animation.png)

![เอฟเฟกต์การเคลื่อนไหวของ placeholder ส่วนท้ายบนสไลด์เลย์เอาต์](layout-shape-animation.png)

![เอฟเฟกต์การเคลื่อนไหวของ placeholder ส่วนท้ายบนสไลด์มาสเตอร์](master-shape-animation.png)

ตัวอย่างต่อไปนี้สร้าง hierarchy ของ placeholder เอง เพิ่มเอฟเฟกต์ให้กับ placeholder ของมาสเตอร์, placeholder ของเลย์เอาต์, และ placeholder ที่สอดคล้องบนสไลด์ปกติ ทุกครั้งที่เรียก [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/getbaseplaceholder/) จะตรวจสอบผลลัพธ์ก่อนนำไปใช้

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

## **เปลี่ยนการตั้งค่าเวลาของการเคลื่อนไหว**

กล่องโต้ตอบ **Timing** ของ PowerPoint แ映กับคุณสมบัติของ [ITiming](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/)

![กล่องโต้ตอบ Timing ของ PowerPoint สำหรับเอฟเฟกต์การเคลื่อนไหว](shape-animation.png)

- **Start** แ映กับ [ITiming.TriggerType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/triggertype/)
- **Duration** แ映กับ [ITiming.Duration](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/duration/) หน่วยเป็นวินาที
- **Delay** แ映กับ [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/triggerdelaytime/) หน่วยเป็นวินาที
- **Repeat** แ映กับ [ITiming.RepeatCount](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatuntilnextclick/), หรือ [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatuntilendslide/)
- **Rewind when done playing** แ映กับ [ITiming.Rewind](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/rewind/)

ตัวอย่างอิสระนี้เพิ่มเอฟเฟกต์, เปลี่ยนเวลาผ่านออบเจ็กต์ที่คืนจาก [ISequence.AddEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/addeffect/), แล้วบันทึกผลลัพธ์ การเก็บอ้างอิงของ [IEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/) ที่คืนมาช่วยหลีกเลี่ยงการเข้าถึงดัชนีคอลเลกชันที่ไม่จำเป็น

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

ใช้โหมดการทำซ้ำแบบใดแบบหนึ่งเท่านั้น การผสมจำนวนการทำซ้ำกับแฟล็ก “until” อาจทำให้ผลลัพธ์สับสนในโปรแกรมเล่นต่าง ๆ เมื่อเปลี่ยนโหมดการทำซ้ำ ให้ตั้งค่า [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatuntilnextclick/) และ [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatuntilendslide/) ก่อน [ITiming.RepeatCount](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatcount/) เนื่องจากการตั้งค่าใดแฟล็กหนึ่งจะเปลี่ยนโหมดการทำซ้ำที่ใช้งานอยู่

## **เพิ่มและสกัดเสียงของการเคลื่อนไหว**

เอฟเฟกต์การเคลื่อนไหวสามารถอ้างอิงไฟล์เสียงที่ฝังไว้ผ่าน [IEffect.Sound](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/sound/) [IEffect.StopPreviousSound](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/stopprevioussound/) บอกเอฟเฟกต์ให้หยุดเสียงที่เริ่มจากเอฟเฟกต์ก่อนหน้า

### **เพิ่มเสียงลงในเอฟเฟกต์**

ตัวอย่างต่อไปนี้คาดว่า จะมีไฟล์เสียงท้องถิ่นชื่อ `animation-sound.wav` สร้างเอฟเฟกต์สองตัว, ฝังไฟล์นั้นเป็นเสียงของเอฟเฟกต์แรก, และตั้งค่าให้เอฟเฟกต์ที่สองหยุดเสียง ใช้ออบเจ็กต์ที่คืนจาก [ISequence.AddEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/addeffect/) ดังนั้นไม่ต้องระบุดัชนีลำดับ

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

### **สกัดเสียงที่ฝังอยู่ในเอฟเฟกต์**

ตัวอย่างต่อไปนี้คาดว่า จะมีงานนำเสนอท้องถิ่นชื่อ `presentation-with-animation-sounds.pptx` สแกนทั้งลำดับหลักและเชิงโต้ตอบและเขียนเสียงเอฟเฟกต์ที่ฝังไว้ทั้งหมดไปยังโฟลเดอร์ `extracted-animation-sounds` ส่วนขยายไฟล์จะเลือกจาก MIME type ของเสียงที่เปิดเผยโดย [IAudio.ContentType](https://reference.aspose.com/slides/th/net/aspose.slides/iaudio/contenttype/)

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

สำหรับออบเจ็กต์เสียงขนาดใหญ่ ให้ใช้ [IAudio.GetStream](https://reference.aspose.com/slides/th/net/aspose.slides/iaudio/getstream/) แล้วคัดลอกสตรีมไปยังไฟล์แทนการโหลดออบเจ็กต์ทั้งหมดเข้าสู่ byte array

## **กำหนดพฤติกรรมหลังการเคลื่อนไหว**

ตัวเลือก **After animation** ควบคุมว่าจะทำอะไรกับรูปทรงหลังจากเอฟเฟกต์จบ

![กล่องโต้ตอบ Effect Options ของ PowerPoint แสดงการตั้งค่า After animation](shape-after-animation.png)

enumeration [AfterAnimationType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/) รองรับการไม่เปลี่ยนแปลงรูปทรง, การเปลี่ยนสี, การซ่อนหลังการเคลื่อนไหว, หรือการซ่อนเมื่อคลิกครั้งต่อไป เมื่อประเภทเป็น [AfterAnimationType.Color](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/) ให้ตั้งค่า [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/afteranimationcolor/) ด้วย

ตัวอย่างอิสระนี้สร้างเอฟเฟกต์, ตั้งค่าพฤติกรรมหลังการเคลื่อนไหวผ่านออบเจ็กต์เอฟเฟกต์ที่คืน, แล้วบันทึกผลลัพธ์

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

การเปลี่ยนประเภทจาก [AfterAnimationType.Color](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/) จะลบการตั้งค่าสีหลังการเคลื่อนไหวออก

## **เคลื่อนไหวข้อความ**

การเคลื่อนไหวข้อความมีสองการควบคุมที่เกี่ยวข้อง:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itextanimation/buildtype/) ควบคุมว่าข้อความย่อย (paragraph) จะปรากฏพร้อมกันหรือแยกตามระดับย่อย
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/animatetexttype/) ควบคุมว่าข้อความปรากฏทั้งหมดพร้อมกัน, ตามคำ, หรือตามอักษร [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/delaybetweentextparts/) ตั้งค่าความล่าช้าระหว่างคำหรืออักษร ค่าเป็นเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์ (บวก) หรือเป็นวินาที (ลบ)

ตัวอย่างอิสระต่อไปนี้เคลื่อนไหวคำในกล่องข้อความ [BuildType.AsOneObject](https://reference.aspose.com/slides/th/net/aspose.slides.animation/buildtype/) ปิดการสร้างตามย่อหน้าจึงทำให้การตั้งค่าคำใช้กับทั้งเฟรมข้อความ

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

เพื่อสร้างกล่องข้อความตามย่อหน้า ให้ตั้งค่า [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/th/net/aspose.slides.animation/buildtype/) (หรือระดับย่อยอื่น) เพื่อกำหนดเอฟเฟกต์ให้กับย่อหน้าเดียว ให้ใช้ overload ของ [ISequence.AddEffect](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/addeffect/) ที่รับ [IParagraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph/) ดูตัวอย่างระดับย่อหน้าที่ [Animated Text](/slides/th/net/animated-text/)

## **การส่งออกและหมายเหตุความเข้ากันได้**

- การบันทึกเป็น PPT หรือ PPTX จะคงโมเดลการเคลื่อนไหวไว้, แต่การเล่นสุดท้ายขึ้นอยู่กับโปรแกรมดูงานนำเสนอ
- PDF และรูปภาพแบบคงที่จะไม่เล่นการเคลื่อนไหว ใช้ [การส่งออกเป็น HTML5](/slides/th/net/export-to-html5/), GIF เคลื่อนไหว, หรือ [การแปลงเป็นวิดีโอ](/slides/th/net/convert-powerpoint-to-video/) เมื่อผลลัพธ์ต้องแสดงการเคลื่อนไหว
- ใน HTML5 ให้เปิดใช้งาน [Html5Options.AnimateShapes](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/animateshapes/) และตามความจำเป็น [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/animatetransitions/)
- การเรนเดอร์วิดีโอสนับสนุนเอฟเฟกต์การเข้ามา, เน้น, ออก, และ motion‑path ที่พบบ่อย, แต่ไม่ใช่ทุกเอฟเฟกต์ของ PowerPoint ตรวจสอบ [รายการการเคลื่อนไหวและเอฟเฟกต์ที่สนับสนุน](/slides/th/net/convert-powerpoint-to-video/#supported-animations-and-effects) และทดสอบงานนำเสนอวิกฤติด้วยรุ่น Aspose.Slides ที่คุณใช้
- เอฟเฟกต์กำหนดเองขั้นสูงและเอฟเฟกต์ที่นำเข้าจากรูปแบบงานนำเสนออื่นอาจถูกเก็บในไฟล์แต่แสดงผลต่างกันใน PowerPoint, HTML5 หรือวิดีโอ ตรวจสอบผลลัพธ์ที่ส่งออกแทนการพึ่งพาชื่อเอฟเฟกต์เพียงอย่างเดียว

## **คำถามที่พบบ่อย**

**ทำไมการเคลื่อนไหวถึงปรากฏใน PowerPoint แต่ไม่ปรากฏใน PDF?**

PDF เป็นรูปแบบคงที่ ดังนั้นการเคลื่อนไหวและการเปลี่ยนสไลด์จะไม่ได้เล่น ส่งออกเป็น HTML5, GIF เคลื่อนไหว หรือวิดีโอเมื่อจำเป็นต้องรักษาการเคลื่อนไหวไว้

**ทำไมเอฟเฟกต์ถึงเล่นต่างกันในวิดีโอ?**

การส่งออกเป็นวิดีโอทำการเรนเดอร์การเคลื่อนไหวแทนการบันทึกพฤติกรรมดั้งเดิมของ PowerPoint บางเอฟเฟกต์ขั้นสูงอาจไม่ได้สนับสนุนหรือถูกประมาณค่า ตรวจสอบตารางเอฟเฟกต์ที่สนับสนุนและทดสอบงานนำเสนอจริงก่อนการใช้งานจริง

**การย้ายรูปทรงไปข้างหน้า หรือข้างหลังส่งผลต่อลำดับการเคลื่อนไหวหรือไม่?**

ไม่ การจัดลำดับ z‑order ของรูปทรงควบคุมการทับกัน, ส่วนลำดับของลำดับและตัวกระตุ้นควบคุมการเล่นการเคลื่อนไหว เปลี่ยนไทม์ไลน์หากต้องการลำดับการเล่นที่แตกต่าง**
---
title: ใช้การเคลื่อนไหวของรูปร่างในงานนำเสนอบน Android
linktitle: การเคลื่อนไหวของรูปร่าง
type: docs
weight: 60
url: /th/androidjava/shape-animation/
keywords:
- รูปร่าง
- การเคลื่อนไหว
- เอฟเฟกต์
- รูปร่างเคลื่อนไหว
- ข้อความเคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- รับการเคลื่อนไหว
- สกัดการเคลื่อนไหว
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- สกัดเอฟเฟกต์
- เสียงของเอฟเฟกต์
- นำการเคลื่อนไหวไปใช้
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม ตรวจสอบ และปรับแต่งการเคลื่อนไหวของรูปร่าง การตั้งเวลา เสียง พฤติกรรมหลังการเคลื่อนไหว และข้อความเคลื่อนไหวด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Android via Java แทนที่การเคลื่อนไหวของสไลด์เป็นเอฟเฟกต์ในไทม์ไลน์ของสไลด์ เอฟเฟกต์หนึ่งมีรูปทรงเป้าหมาย ประเภทและชนิดย่อยของการเคลื่อนไหว ตัวกระตุ้น การตั้งค่าเวลา และคุณสมบัติอื่น ๆ เช่น เสียงหรือพฤติกรรมหลังการเคลื่อนไหว

ไทม์ไลน์มีลำดับสองประเภท:

- **main sequence** ทำงานเมื่อสไลด์ก้าวหน้า
- **interactive sequence** เริ่มเมื่อคลิกรูปร่างตัวกระตุ้น

เนื่องจากกล่องข้อความ รูปภาพ แผนภูมิ ตาราง และวัตถุสไลด์อื่น ๆ เขimplements [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) คุณจึงใช้เมธอด [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) เดียวกันสำหรับเนื้อหาสไลด์ส่วนใหญ่ เอฟเฟกต์ที่ใช้ได้จะระบุไว้ในคลาส [EffectType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effecttype/)

## **เพิ่มการเคลื่อนไหวของรูปร่าง**

เพื่อเพิ่มการเคลื่อนไหว ให้ดึงลำดับหลักของสไลด์และเรียก [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) พร้อมกับรูปทรงเป้าหมาย ประเภทเอฟเฟกต์ ชนิดย่อย และตัวกระตุ้น สำหรับเอฟเฟกต์ที่เริ่มเมื่อคลิกรูปร่างอื่น ให้สร้าง interactive sequence ที่ตัวกระตุ้นคือรูปร่างนั้น

ตัวอย่างต่อไปนี้สร้างการเคลื่อนไหวสองประเภทและบันทึกผลลัพธ์เป็น `shape-animations.pptx`

```java
import com.aspose.slides.*;

public class AddShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);

            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Click to animate this shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            IEffect entranceEffect = mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            entranceEffect.getTiming().setDuration(1.5f);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            presentation.save("shape-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

ตัวกระตุ้นกำหนดว่าเอฟเฟกต์เริ่มใดเมื่อใด:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effecttriggertype/#OnClick) รอการคลิกในลำดับหลัก หรือคลิกบนรูปทรงตัวกระตุ้นในลำดับเชิงโต้ตอบ
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) เริ่มพร้อมกับเอฟเฟกต์ก่อนหน้า
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) เริ่มเมื่อเอฟเฟกต์ก่อนหน้าจบ

เพื่อทำให้รูปภาพ แผนภูมิ หรือรูปทรงชนิดอื่นเคลื่อนไหว ให้ส่งออบเจ็กต์นั้นไปยัง [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) แทน `targetShape` สำหรับตัวเลือกการจัดกลุ่มเฉพาะแผนภูมิ ดูที่ [Animated Charts](/slides/th/androidjava/animated-charts/)

## **อ่านการเคลื่อนไหวของรูปร่าง**

ใช้ [ISequence.getEffectsByShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) เมื่อต้องการทราบรูปทรงเป้าหมาย เพื่อตรวจสอบทุกเอฟเฟกต์ ให้วนลูปผ่านลำดับหลักและลำดับเชิงโต้ตอบทั้งหมด การวนลูปหลีกเลี่ยงการสันนิษฐานว่าลำดับมีเอฟเฟกต์ที่ดัชนี `0`

ตัวอย่างต่อไปสร้างรูปร่างที่มีเอฟเฟกต์ในลำดับหลักและเชิงโต้ตอบ ดึงเอฟเฟกต์ที่เป้าหมายเป็นรูปร่างนั้น แล้ววนลูปทุกลำดับบนสไลด์

```java
import com.aspose.slides.*;

public class ReadShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Animated shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            IEffect[] targetEffects = mainSequence.getEffectsByShape(targetShape);
            System.out.println("The main sequence contains " + targetEffects.length + " effect(s) for " + targetShape.getName() + ".");

            printSequence("Main sequence", mainSequence);

            int interactiveIndex = 1;
            for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                String triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
                String sequenceLabel = "Interactive sequence " + interactiveIndex + ", trigger: " + triggerName;
                printSequence(sequenceLabel, sequence);
                interactiveIndex++;
            }
        } finally {
            presentation.dispose();
        }
    }

    private static void printSequence(String label, ISequence sequence) {
        System.out.println("  " + label + ": " + sequence.getCount() + " effect(s)");

        for (IEffect effect : sequence) {
            String targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            String triggerName = EffectTriggerType.getName(EffectTriggerType.class, effect.getTiming().getTriggerType());
            String effectDescription = typeName + " " + subtypeName + "; target: " + targetName + "; trigger: " + triggerName;
            System.out.println("    " + effectDescription);
        }
    }
}
```

หากต้องการเอฟเฟกต์เพียงรูปทรงเดียว ให้ระบุตัวกำหนดรูปทรงด้วยชื่อ ประเภท placeholder หรือคุณสมบัติคงที่อื่น แล้วเรียก [ISequence.getEffectsByShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) อย่าเชื่อว่า [IShapeCollection.get_Item](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) ที่ดัชนี `0` เป็นออบเจ็กต์ที่ต้องการเสมอ

## **ทำงานกับเอฟเฟกต์ของ Placeholder ที่สืบทอด**

Placeholder บนสไลด์ปกติอาจสืบทอดพฤติกรรมการเคลื่อนไหวจาก placeholder ที่สอดคล้องบนสไลด์เลย์เอาต์และมาสเตอร์ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) จะคืนค่า placeholder พาเรนท์นั้น หรือ `null` หากไม่มีพาเรนท์

ในงานนำเสนอตัวอย่างต่อไป ส่วนท้ายมี **Random Bars** บนสไลด์ปกติ, **Split** บนสไลด์เลย์เอาต์, และ **Fly In** บนสไลด์มาสเตอร์

![เอฟเฟกต์การเคลื่อนไหวของส่วนท้ายบนสไลด์ปกติ](slide-shape-animation.png)

![เอฟเฟกต์การเคลื่อนไหวของ placeholder ส่วนท้ายบนสไลด์เลย์เอาต์](layout-shape-animation.png)

![เอฟเฟกต์การเคลื่อนไหวของ placeholder ส่วนท้ายบนสไลด์มาสเตอร์](master-shape-animation.png)

ตัวอย่างต่อไปใช้โครงสร้าง hierarchy ของ placeholder จากงานนำเสนอใหม่ เพิ่มเอฟเฟกต์ให้กับ placeholder มาสเตอร์, placeholder เลย์เอาต์, และ placeholder ที่สอดคล้องบนสไลด์ปกติ ทุกการเรียก [IShape.getBasePlaceholder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) จะตรวจสอบก่อนนำรูปทรงที่ได้ไปใช้

```java
import com.aspose.slides.*;

public class InheritedPlaceholderAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);
            IShape layoutPlaceholder = findPlaceholderWithBase(layoutSlide);

            if (layoutPlaceholder == null) {
                throw new IllegalStateException("The layout slide does not contain a placeholder linked to its master slide.");
            }

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
            layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

            ISlide slide = presentation.getSlides().addEmptySlide(layoutSlide);
            IShape slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

            if (slidePlaceholder == null) {
                throw new IllegalStateException("The slide does not contain a placeholder linked to its layout slide.");
            }

            slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
            printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

            IShape baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
            if (baseLayoutPlaceholder != null) {
                printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

                IShape baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
                if (baseMasterPlaceholder != null) {
                    printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
                }
            }

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static IShape findPlaceholderWithBase(ILayoutSlide layoutSlide) {
        for (IShape shape : layoutSlide.getShapes()) {
            if (shape.getBasePlaceholder() != null) {
                return shape;
            }
        }

        return null;
    }

    private static IShape findPlaceholderWithBase(ISlide slide, IShape expectedBase) {
        for (IShape shape : slide.getShapes()) {
            if (shape.getBasePlaceholder() == expectedBase) {
                return shape;
            }
        }

        return null;
    }

    private static void printEffects(String source, IEffect[] effects) {
        System.out.println(source + ": " + effects.length + " effect(s)");

        for (IEffect effect : effects) {
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            System.out.println("  " + typeName + " " + subtypeName);
        }
    }
}
```

## **เปลี่ยนการตั้งเวลาแอนิเมชัน**

กล่องโต้ตอบ PowerPoint **Timing** จะแมพกับคุณสมบัติของ [ITiming](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/)

![กล่องโต้ตอบการตั้งเวลา PowerPoint สำหรับเอฟเฟกต์แอนิเมชัน](shape-animation.png)

- **Start** แมพกับ [ITiming.getTriggerType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getTriggerType--)
- **Duration** แมพกับ [ITiming.getDuration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getDuration--)(วินาที)
- **Delay** แมพกับ [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)(วินาที)
- **Repeat** แมพกับ [ITiming.getRepeatCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), หรือ [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--)
- **Rewind when done playing** แมพกับ [ITiming.getRewind](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getRewind--)

ตัวอย่างอิสระนี้เพิ่มเอฟเฟกต์ เปลี่ยนการตั้งเวลาผ่านออบเจ็กต์ที่คืนจาก [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) แล้วบันทึกผลลัพธ์ การเก็บอ้างอิง [IEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/) ที่คืนช่วยหลีกเลี่ยงการอ้างอิงดัชนีคอลเลกชันที่ไม่จำเป็น

```java
import com.aspose.slides.*;

public class ChangeAnimationTiming {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Timed animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTiming().setTriggerType(EffectTriggerType.OnClick);
            effect.getTiming().setDuration(2.0f);
            effect.getTiming().setTriggerDelayTime(0.5f);
            effect.getTiming().setRepeatUntilNextClick(false);
            effect.getTiming().setRepeatUntilEndSlide(false);
            effect.getTiming().setRepeatCount(2.0f);
            effect.getTiming().setRewind(true);

            presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

ใช้โหมดการทำซ้ำแบบใดแบบหนึ่งเท่านั้น การผสมการตั้งค่า repeat count กับแฟล็ก “until” อาจทำให้ผลลัพธ์สับสนในผู้ชมต่าง ๆ เมื่อเปลี่ยนโหมดการทำซ้ำ ให้ตั้งค่า [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) และ [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) ก่อน [ITiming.setRepeatCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) เนื่องจากการตั้งค่าใดแฟล็กหนึ่งจะเปลี่ยนโหมดการทำซ้ำที่ใช้งานอยู่

## **เพิ่มและสกัดเสียงแอนิเมชัน**

เอฟเฟกต์การเคลื่อนไหวสามารถอ้างอิงไฟล์เสียงฝังด้วย [IEffect.getSound](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getSound--) [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) บอกให้เอฟเฟกต์หยุดเสียงที่เริ่มโดยเอฟเฟกต์ก่อนหน้า

### **เพิ่มเสียงให้กับเอฟเฟกต์**

ตัวอย่างต่อไปคาดหวังไฟล์เสียงโลคัลชื่อ `animation-sound.wav` สร้างเอฟเฟกต์สองอัน ฝังไฟล์นั้นเป็นเสียงของเอฟเฟกต์แรก และกำหนดให้เอฟเฟกต์ที่สองหยุดเสียง ใช้ออบเจ็กต์ที่คืนจาก [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) จึงไม่ต้องระบุดัชนีลำดับ

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class AddAnimationSound {
    public static void main(String[] args) throws IOException {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
            IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
            firstShape.addTextFrame("Starts sound");
            secondShape.addTextFrame("Stops sound");

            ISequence sequence = slide.getTimeline().getMainSequence();
            IEffect firstEffect = sequence.addEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            IEffect secondEffect = sequence.addEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            byte[] audioData = Files.readAllBytes(Paths.get("animation-sound.wav"));
            IAudio effectSound = presentation.getAudios().addAudio(audioData);
            firstEffect.setSound(effectSound);
            secondEffect.setStopPreviousSound(true);

            presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

### **สกัดเสียงเอฟเฟกต์ที่ฝังอยู่**

ตัวอย่างต่อไปคาดหวังงานนำเสนอโลคัลชื่อ `presentation-with-animation-sounds.pptx` ตรวจสอบทั้งลำดับหลักและเชิงโต้ตอบ แล้วเขียนเสียงเอฟเฟกต์ที่ฝังไว้ทั้งหมดไปยังโฟลเดอร์ `extracted-animation-sounds` ส่วนขยายไฟล์เลือกจาก MIME type ของเสียงที่ให้โดย [IAudio.getContentType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudio/#getContentType--)

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

public class ExtractAnimationSounds {
    public static void main(String[] args) throws IOException {
        Path inputPath = Paths.get("presentation-with-animation-sounds.pptx");
        Path outputDirectory = Paths.get("extracted-animation-sounds");

        Files.createDirectories(outputDirectory);

        Presentation presentation = new Presentation(inputPath.toString());
        try {
            int soundIndex = 1;

            for (ISlide slide : presentation.getSlides()) {
                soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

                for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                    soundIndex = saveSounds(sequence, outputDirectory, soundIndex);
                }
            }

            System.out.println("Extracted " + (soundIndex - 1) + " sound file(s) to " + outputDirectory.toAbsolutePath() + ".");
        } finally {
            presentation.dispose();
        }
    }

    private static int saveSounds(ISequence sequence, Path outputDirectory, int soundIndex) throws IOException {
        for (IEffect effect : sequence) {
            if (effect.getSound() == null) {
                continue;
            }

            String extension = getAudioExtension(effect.getSound().getContentType());
            Path outputPath = outputDirectory.resolve("effect-sound-" + soundIndex + extension);
            Files.write(outputPath, effect.getSound().getBinaryData());
            soundIndex++;
        }

        return soundIndex;
    }

    private static String getAudioExtension(String contentType) {
        String normalizedType = contentType == null ? "" : contentType.toLowerCase(Locale.ROOT);

        if (normalizedType.equals("audio/mpeg")) {
            return ".mp3";
        }

        if (normalizedType.equals("audio/mp4")) {
            return ".m4a";
        }

        if (normalizedType.equals("audio/ogg")) {
            return ".ogg";
        }

        if (normalizedType.equals("audio/wav") || normalizedType.equals("audio/x-wav")) {
            return ".wav";
        }

        return ".bin";
    }
}
```

สำหรับออบเจ็กต์เสียงขนาดใหญ่ ให้ใช้ [IAudio.getStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudio/#getStream--) แล้วคัดลอกสตรีมไปยังไฟล์ แทนการโหลดออบเจ็กต์ทั้งหมดเป็นอาเรย์ไบต์

## **ตั้งค่าพฤติกรรมหลังแอนิเมชัน**

ตัวเลือก **After animation** กำหนดสิ่งที่จะเกิดขึ้นกับรูปร่างหลังจากเอฟเฟกต์จบ

![กล่องโต้ตอบตัวเลือกเอฟเฟกต์ PowerPoint แสดงการตั้งค่า After animation](shape-after-animation.png)

คลาส [AfterAnimationType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/) รองรับการคงรูปร่างไว้ ไม่เปลี่ยนสี ซ่อนหลังแอนิเมชัน หรือซ่อนเมื่อคลิกครั้งถัดไป เมื่อประเภทเป็น [AfterAnimationType.Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#Color) ให้ตั้งค่า [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--) ด้วย

ตัวอย่างอิสระนี้สร้างเอฟเฟกต์ ตั้งค่าพฤติกรรมหลังแอนิเมชันผ่านออบเจ็กต์เอฟเฟกต์ที่คืน แล้วบันทึกผลลัพธ์

```java
import com.aspose.slides.*;
import android.graphics.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LTGRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

การเปลี่ยนประเภทออกจาก [AfterAnimationType.Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#Color) จะลบการตั้งค่าสีหลังแอนิเมชัน

## **เคลื่อนภาพข้อความ**

การเคลื่อนไหวข้อความมีการควบคุมสองอย่างที่เกี่ยวข้อง:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextanimation/#getBuildType--) ควบคุมว่าบรรทัดย่อยปรากฏพร้อมกันหรือเป็นระดับบรรทัด
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) ควบคุมว่าข้อความปรากฏทั้งหมดพร้อมกัน, ตามคำ, หรือ ตามตัวอักษร [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) ตั้งค่าความล่าช้าระหว่างคำหรืออักษร ค่าเป็นบวกเป็นเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์; ค่าเป็นลบเป็นความล่าช้าหน่วยวินาที

ตัวอย่างอิสระต่อไปเคลื่อนไหวคำในกล่องข้อความ [BuildType.AsOneObject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/buildtype/#AsOneObject) ปิดการสร้างแบบบรรทัดต่อบรรทัด ทำให้การตั้งค่าคำใช้กับทั้งเฟรมข้อความ

```java
import com.aspose.slides.*;

public class AnimateTextByWord {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
            textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTextAnimation().setBuildType(BuildType.AsOneObject);
            effect.setAnimateTextType(AnimateTextType.ByWord);
            effect.setDelayBetweenTextParts(20.0f);

            presentation.save("animated-text.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

หากต้องการสร้างกล่องข้อความตามบรรทัด ให้ตั้งค่า [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (หรือระดับบรรทัดอื่น) เพื่อกำหนดเอฟเฟกต์ให้กับบรรทัดเดียวใช้ overload ของ [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) ที่รับ [IParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/) ดูที่ [Animated Text](/slides/th/androidjava/animated-text/) สำหรับตัวอย่างระดับบรรทัด

## **การส่งออกและหมายเหตุความเข้ากันได้**

- การบันทึกเป็น PPT หรือ PPTX จะคงโมเดลการเคลื่อนไหวไว้ แต่การเล่นขั้นสุดท้ายขึ้นกับโปรแกรมดูงานนำเสนอ
- PDF และภาพนิ่งไม่เล่นแอนิเมชัน ใช้ [การส่งออก HTML5](/slides/th/androidjava/export-to-html5/), GIF เคลื่อนไหว, หรือ [การแปลงเป็นวิดีโอ](/slides/th/androidjava/convert-powerpoint-to-video/) เมื่อผลลัพธ์ต้องแสดงการเคลื่อนไหว
- สำหรับ HTML5 ให้เปิดใช้งาน [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และตามต้องการ [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)
- การเรนเดอร์วิดีโอรองรับเอฟเฟกต์เข้า, เน้น, ออก, และเส้นทางการเคลื่อนที่หลายประเภท แต่ไม่ใช่ทุกเอฟเฟกต์ของ PowerPoint ตรวจสอบ [การสนับสนุนแอนิเมชันและเอฟเฟกต์](/slides/th/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) ปัจจุบันและทดสอบงานนำเสนอสำคัญกับเวอร์ชัน Aspose.Slides ที่ใช้งาน
- เอฟเฟกต์ที่กำหนดเองขั้นสูงและเอฟเฟกต์ที่นำเข้าจากรูปแบบงานนำเสนออื่นอาจถูกเก็บในไฟล์แต่การเรนเดอร์อาจแตกต่างใน PowerPoint, HTML5 หรือวิดีโอ ตรวจสอบผลลัพธ์ที่ส่งออกแทนการเชื่อถือแค่ชื่อเอฟเฟกต์

## **คำถามที่พบบ่อย**

**ทำไมแอนิเมชันจึงปรากฏใน PowerPoint แต่ไม่แสดงใน PDF?**

PDF เป็นรูปแบบคงที่ ดังนั้นแอนิเมชันและการเปลี่ยนสไลด์จะไม่ทำงาน ส่งออกเป็น HTML5, GIF เคลื่อนไหว หรือวิดีโอเมื่อจำเป็นต้องรักษาการเคลื่อนไหว

**ทำไมเอฟเฟกต์ถึงแสดงผลแตกต่างในวิดีโอ?**

การส่งออกวิดีโอเรนเดอร์แอนิเมชันแทนการเก็บพฤติกรรมดั้งเดิมของ PowerPoint บางเอฟเฟกต์ขั้นสูงอาจไม่ได้รับการสนับสนุนหรือถูกประมาณค่า ตรวจสอบตารางเอฟเฟกต์ที่สนับสนุนและทดสอบงานนำเสนอจริงก่อนการใช้งานจริง

**การย้ายรูปร่างไปข้างหน้าหรือข้างหลังเปลี่ยนลำดับการเคลื่อนไหวหรือไม่?**

ไม่ การจัดลำดับ z‑order ของรูปร่างควบคุมการทับซ้อน ส่วนลำดับใน sequence และตัวกระตุ้นควบคุมการเล่นแอนิเมชัน หากต้องการลำดับการเล่นที่แตกต่างให้ปรับไทม์ไลน์**
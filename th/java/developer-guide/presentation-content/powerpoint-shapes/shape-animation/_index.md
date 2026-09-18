---
title: ใช้แอนิเมชันรูปทรงในงานนำเสนอโดยใช้ Java
linktitle: แอนิเมชันรูปทรง
type: docs
weight: 60
url: /th/java/shape-animation/
keywords:
- รูปทรง
- แอนิเมชัน
- เอฟเฟ็กต์
- รูปทรงที่แอนิเมชัน
- ข้อความที่แอนิเมชัน
- เพิ่มแอนิเมชัน
- รับแอนิเมชัน
- สกัดแอนิเมชัน
- เพิ่มเอฟเฟ็กต์
- รับเอฟเฟ็กต์
- สกัดเอฟเฟ็กต์
- เสียงของเอฟเฟ็กต์
- ใช้แอนิเมชัน
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม ตรวจสอบ และปรับแต่งแอนิเมชันรูปทรง การตั้งเวลา เสียง พฤติกรรมหลังแอนิเมชัน และข้อความที่แอนิเมชันด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

เพื่อทำงานกับพฤติกรรมแต่ละอย่างภายในเอฟเฟ็กต์หรือแก้ไขส่วนของ motion-path ให้ดูที่ [การทำแอนิเมชันแบบกำหนดเอง](/slides/th/java/custom-animation/).

Aspose.Slides for Java แสดงการแอนิเมชันของสไลด์เป็นเอฟเฟ็กต์ในไทม์ไลน์ของสไลด์. เอฟเฟ็กต์มีรูปทรงเป้าหมาย, ประเภทและชนิดย่อยของการแอนิเมชัน, ตัวกระตุ้น, การตั้งค่าเวลา, และคุณสมบัติเสริมเช่นเสียงหรือพฤติกรรมหลังแอนิเมชัน.

ไทม์ไลน์ประกอบด้วยสองประเภทของลำดับ:

- **ลำดับหลัก** เล่นเมื่อสไลด์ก้าวหน้า.
- **ลำดับเชิงโต้ตอบ** เริ่มเมื่อรูปทรงตัวกระตุ้นถูกคลิก.

เนื่องจากกล่องข้อความ, รูปภาพ, แผนภูมิ, ตาราง และอ็อบเจกต์สไลด์อื่น ๆ implement [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/), คุณใช้เมธอด [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) เดียวกันสำหรับเนื้อหาสไลด์ส่วนใหญ่. เอฟเฟ็กต์ที่มีอยู่แสดงในคลาส [EffectType](https://reference.aspose.com/slides/th/java/com.aspose.slides/effecttype/).

## **เพิ่มแอนิเมชันให้รูปทรง**

เพื่อเพิ่มแอนิเมชัน, ดึงลำดับหลักของสไลด์และเรียกเมธอด [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) โดยระบุรูปทรงเป้าหมาย, ประเภทเอฟเฟ็กต์, ชนิดย่อย, และตัวกระตุ้น. สำหรับเอฟเฟ็กต์ที่เริ่มเมื่อรูปทรงอื่นถูกคลิก, สร้างลำดับเชิงโต้ตอบที่ตัวกระตุ้นคือรูปทรงนั้น.

ตัวอย่างต่อไปนี้สร้างแอนิเมชันทั้งสองประเภทและบันทึกผลลัพธ์ลงในไฟล์ `shape-animations.pptx`.

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

ตัวกระตุ้นกำหนดว่าเอฟเฟ็กต์เริ่มเมื่อใด:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/effecttriggertype/#OnClick) รอการคลิกในลำดับหลัก, หรือรอการคลิกบนรูปทรงตัวกระตุ้นในลำดับเชิงโต้ตอบ.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/th/java/com.aspose.slides/effecttriggertype/#WithPrevious) เริ่มพร้อมกับเอฟเฟ็กต์ก่อนหน้า.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/th/java/com.aspose.slides/effecttriggertype/#AfterPrevious) เริ่มเมื่อเอฟเฟ็กต์ก่อนหน้าจบลง.

เพื่อทำแอนิเมชันรูปภาพ, แผนภูมิ หรือรูปทรงประเภทอื่น, ส่งอ็อบเจกต์นั้นไปยังเมธอด [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) แทน `targetShape`. สำหรับตัวเลือกการจัดกลุ่มเฉพาะแผนภูมิ, ดูที่ [แผนภูมิที่แอนิเมชัน](/slides/th/java/animated-charts/).

## **อ่านแอนิเมชันของรูปทรง**

ใช้เมธอด [ISequence.getEffectsByShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) เมื่อคุณทราบรูปทรงเป้าหมาย. เพื่อสำรวจทุกเอฟเฟ็กต์, ให้วนลำดับหลักและลำดับเชิงโต้ตอบแต่ละอัน. การวนทำให้ไม่ต้องสมมติว่าลำดับมีเอฟเฟ็กต์ที่ดัชนี `0`.

ตัวอย่างต่อไปนี้สร้างรูปทรงที่มีเอฟเฟ็กต์ในลำดับหลักและลำดับเชิงโต้ตอบ, ดึงเอฟเฟ็กต์ที่เป้าหมายเป็นรูปทรงนั้น, แล้ววนลำดับทั้งหมดบนสไลด์.

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

หากคุณต้องการเอฟเฟ็กต์เฉพาะสำหรับรูปทรงหนึ่งเท่านั้น, ให้ระบุตัวรูปทรงโดยชื่อ, ประเภท placeholder, หรือคุณสมบัติที่คงที่อื่น; แล้วเรียกเมธอด [ISequence.getEffectsByShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). อย่าสมมติว่า [IShapeCollection.get_Item](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#get_Item-int-) ที่ดัชนี `0` เป็นอ็อบเจกต์ที่ต้องการเสมอ.

## **ทำงานกับเอฟเฟ็กต์ Placeholder ที่สืบทอด**

Placeholder บนสไลด์ปกติสามารถสืบทอดพฤติกรรมแอนิเมชันจาก Placeholder ที่สอดคล้องบนสไลด์เลย์เอาต์และมาสเตอร์สไลด์ได้. เมธอด [IShape.getBasePlaceholder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getBasePlaceholder--) จะคืนค่า Placeholder พ่อแม่นั้น, หรือ `null` ถ้าไม่มีพ่อแม่.

ในตัวอย่างพรีเซนเทชันต่อไปนี้, ส่วนท้าย (footer) มี **Random Bars** บนสไลด์ปกติ, **Split** บนสไลด์เลย์เอาต์, และ **Fly In** บนสไลด์มาสเตอร์.

![เอฟเฟ็กต์แอนิเมชันส่วนท้ายบนสไลด์ปกติ](slide-shape-animation.png)

![เอฟเฟ็กต์แอนิเมชัน Placeholder ส่วนท้ายบนสไลด์เลย์เอาต์](layout-shape-animation.png)

![เอฟเฟ็กต์แอนิเมชัน Placeholder ส่วนท้ายบนสไลด์มาสเตอร์](master-shape-animation.png)

ตัวอย่างต่อไปนี้ใช้โครงสร้าง Placeholder จากพรีเซนเทชันใหม่. มันเพิ่มเอฟเฟ็กต์ให้กับ master placeholder, layout placeholder, และ placeholder ที่สอดคล้องบนสไลด์ปกติ. การเรียกทุกครั้งที่ [IShape.getBasePlaceholder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getBasePlaceholder--) จะตรวจสอบก่อนนำรูปทรงที่คืนค่าไปใช้.

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

## **เปลี่ยนการตั้งค่าเวลาแอนิเมชัน**

กล่องโต้ตอบ **Timing** ของ PowerPoint เชื่อมโยงกับคุณสมบัติของ [ITiming](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/).

![กล่องโต้ตอบ Timing ของ PowerPoint สำหรับเอฟเฟ็กต์แอนิเมชัน](shape-animation.png)

- **Start** เชื่อมกับ [ITiming.getTriggerType](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** เชื่อมกับ [ITiming.getDuration](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getDuration--), หน่วยเป็นวินาที.
- **Delay** เชื่อมกับ [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getTriggerDelayTime--), หน่วยเป็นวินาที.
- **Repeat** เชื่อมกับ [ITiming.getRepeatCount](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), หรือ [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** เชื่อมกับ [ITiming.getRewind](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getRewind--).

ตัวอย่างอิสระนี้เพิ่มเอฟเฟ็กต์, ปรับเวลาโดยใช้วัตถุที่คืนค่าจาก [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), และบันทึกผลลัพธ์. การเก็บอ้างอิง [IEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/) ที่คืนค่ามาช่วยหลีกเลี่ยงการอ้างอิงดัชนีคอลเลกชันที่ไม่จำเป็น.

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

ใช้โหมดการทำซ้ำอย่างเดียวเท่านั้น. การรวมจำนวนการทำซ้ำกับแฟล็็ก “until” อาจทำให้ผลลัพธ์สับสนในตัวชมต่าง ๆ. เมื่อเปลี่ยนโหมดทำซ้ำ, ให้ตั้งค่า [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) และ [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) ก่อน [ITiming.setRepeatCount](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#setRepeatCount-float-), เพราะการตั้งค่าแฟล็กใดแฟล็กหนึ่งจะเปลี่ยนโหมดทำซ้ำที่ใช้งานอยู่โดยอัตโนมัติ.

## **เพิ่มและสกัดเสียงแอนิเมชัน**

เอฟเฟ็กต์แอนิเมชันสามารถอ้างอิงไฟล์เสียงที่ฝังอยู่ผ่าน [IEffect.getSound](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getSound--). เมธอด [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) บอกให้เอฟเฟ็กต์หยุดเสียงที่เริ่มจากเอฟเฟ็กต์ก่อนหน้า.

### **เพิ่มเสียงให้กับเอฟเฟ็กต์**

ตัวอย่างต่อไปนี้ต้องการไฟล์เสียงโลคัลชื่อ `animation-sound.wav`. มันสร้างเอฟเฟ็กต์สองตัว, ฝังไฟล์นั้นเป็นเสียงสำหรับเอฟเฟ็กต์แรก, และกำหนดค่าเอฟเฟ็กต์ที่สองให้หยุดเสียง. ใช้วัตถุที่คืนค่าจาก [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), ดังนั้นไม่จำเป็นต้องระบุดัชนีลำดับ.

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

### **สกัดเสียงเอฟเฟ็กต์ที่ฝังอยู่**

ตัวอย่างต่อไปนี้ต้องการพรีเซนเทชันโลคัลชื่อ `presentation-with-animation-sounds.pptx`. มันสแกนลำดับหลักและลำดับเชิงโต้ตอบทั้งสองและเขียนเสียงเอฟเฟ็กต์ที่ฝังอยู่ทั้งหมดลงในไดเรกทอรี `extracted-animation-sounds`. ส่วนขยายไฟล์เลือกจาก MIME type ของเสียงที่เปิดโดย [IAudio.getContentType](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaudio/#getContentType--).

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

สำหรับอ็อบเจกต์เสียงขนาดใหญ่, ใช้ [IAudio.getStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaudio/#getStream--) และคัดลอกสตรีมไปยังไฟล์แทนการโหลดอ็อบเจกต์ทั้งหมดเป็นอาร์เรย์ไบต์.

## **ตั้งค่าพฤติกรรมหลังแอนิเมชัน**

ตัวเลือก **After animation** ควบคุมว่ารูปทรงจะทำอะไรหลังจากเอฟเฟ็กต์เสร็จสิ้น.

![กล่องโต้ตอบตัวเลือกเอฟเฟ็กต์ของ PowerPoint แสดงการตั้งค่า After animation](shape-after-animation.png)

คลาส [AfterAnimationType](https://reference.aspose.com/slides/th/java/com.aspose.slides/afteranimationtype/) รองรับการทิ้งรูปทรงไว้โดยไม่เปลี่ยน, เปลี่ยนสี, ซ่อนหลังแอนิเมชัน, หรือซ่อนเมื่อคลิกครั้งถัดไป. เมื่อประเภทเป็น [AfterAnimationType.Color](https://reference.aspose.com/slides/th/java/com.aspose.slides/afteranimationtype/#Color), ให้ตั้งค่า [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getAfterAnimationColor--) ด้วย.

ตัวอย่างอิสระนี้สร้างเอฟเฟ็กต์, ตั้งค่าพฤติกรรมหลังแอนิเมชันผ่านอ็อบเจกต์เอฟเฟ็กต์ที่คืนค่า, และบันทึกผลลัพธ์.

```java
import com.aspose.slides.*;
import java.awt.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

การเปลี่ยนประเภทออกจาก [AfterAnimationType.Color](https://reference.aspose.com/slides/th/java/com.aspose.slides/afteranimationtype/#Color) จะล้างการตั้งค่าสีหลังแอนิเมชัน.

## **ทำแอนิเมชันข้อความ**

แอนิเมชันข้อความมีการควบคุมสองอย่างที่เกี่ยวข้อง:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextanimation/#getBuildType--) ควบคุมว่าข้อความปรากฏพร้อมกันหรือระดับย่อยของย่อหน้า.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getAnimateTextType--) ควบคุมว่าข้อความปรากฏทั้งหมดพร้อมกัน, แบ่งตามคำ, หรือแบ่งตามอักษร. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) ตั้งค่าการหน่วงเวลาระหว่างคำหรืออักษร. ค่าบวกเป็นเปอร์เซ็นต์ของระยะเวลาเอฟเฟ็กต์; ค่าลบเป็นหน่วงเวลาหน่วยวินาที.

ตัวอย่างอิสระต่อไปนี้ทำแอนิเมชันคำในกล่องข้อความ. [BuildType.AsOneObject](https://reference.aspose.com/slides/th/java/com.aspose.slides/buildtype/#AsOneObject) ปิดการสร้างตามย่อหน้าเพื่อให้การตั้งค่าคำใช้กับทั้งเฟรมข้อความ.

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

เพื่อสร้างข้อความในกล่องตามย่อหน้า, ตั้งค่า [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/th/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (หรือระดับย่อหน้าอื่น). เพื่อกำหนดย่อหน้าเดียวให้มีเอฟเฟ็กต์ของตนเอง, ใช้เมธอด overload ของ [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) ที่รับ [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/). ดูที่ [ข้อความที่แอนิเมชัน](/slides/th/java/animated-text/) สำหรับตัวอย่างระดับย่อหน้า.

## **การส่งออกและหมายเหตุเกี่ยวกับความเข้ากันได้**

- การบันทึกเป็น PPT หรือ PPTX จะคงโมเดลแอนิเมชัน, แต่การเล่นขั้นสุดท้ายถูกควบคุมโดยโปรแกรมแสดงสไลด์.
- PDF และภาพนิ่งไม่สามารถเล่นแอนิเมชันได้. ใช้การส่งออกเป็น [การส่งออกเป็น HTML5](/slides/th/java/export-to-html5/), GIF แอนิเมชัน, หรือ [การแปลงเป็นวิดีโอ](/slides/th/java/convert-powerpoint-to-video/) เมื่อผลลัพธ์ต้องแสดงการเคลื่อนไหว.
- สำหรับ HTML5, เปิดใช้งาน [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และเมื่อต้องการ, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- การเรนเดอร์วิดีโอรองรับเอฟเฟ็กต์การเข้ามา, เน้น, ออก, และ motion-path ที่พบบ่อย, แต่ไม่รองรับเอฟเฟ็กต์ PowerPoint ทั้งหมด. ตรวจสอบ [เอฟเฟ็กต์และการแอนิเมชันที่รองรับ](/slides/th/java/convert-powerpoint-to-video/#supported-animations-and-effects) และทดสอบพรีเซนเทชันสำคัญกับเวอร์ชัน Aspose.Slides ที่ใช้.
- เอฟเฟ็กต์แบบกำหนดเองขั้นสูงและเอฟเฟ็กต์ที่นำเข้าจากรูปแบบพรีเซนเทชันอื่นอาจถูกเก็บในไฟล์แต่เรนเดอร์แตกต่างกันใน PowerPoint, HTML5, หรือวิดีโอ. ตรวจสอบผลลัพธ์ที่ส่งออกแทนการอ้างอิงชื่อเอฟเฟ็กต์อย่างเดียว.

## **คำถามที่พบบ่อย**

**ทำไมแอนิเมชันถึงปรากฏใน PowerPoint แต่ไม่แสดงใน PDF?**

PDF เป็นรูปแบบคงที่, ดังนั้นแอนิเมชันและการเปลี่ยนสไลด์จะไม่เล่น. ให้ส่งออกเป็น HTML5, GIF แอนิเมชัน, หรือวิดีโอเมื่อจำเป็นต้องคงการเคลื่อนไหว.

**ทำไมเอฟเฟ็กต์จึงเล่นแตกต่างกันในวิดีโอ?**

การแปลงเป็นวิดีโอทำการเรนเดอร์แอนิเมชันแทนการบันทึกพฤติกรรมเดิมของ PowerPoint. บางเอฟเฟ็กต์ขั้นสูงไม่ได้รับการสนับสนุนหรือถูกประมาณค่า. ตรวจสอบตารางเอฟเฟ็กต์ที่รองรับและทดสอบพรีเซนเทชันจริงก่อนใช้งานจริง.

**การย้ายรูปทรงไปข้างหน้าหรือหลังเปลี่ยนลำดับแอนิเมชันหรือไม่?**

ไม่. การจัดลำดับ z-order ของรูปทรงควบคุมการซ้อนทับ, ส่วนลำดับของซีเควนซ์และตัวกระตุ้นควบคุมการเล่นแอนิเมชัน. ปรับไทม์ไลน์หากต้องการเปลี่ยนลำดับการเล่น.
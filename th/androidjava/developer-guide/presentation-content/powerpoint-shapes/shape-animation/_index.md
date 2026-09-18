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
- รูปร่างที่เคลื่อนไหว
- ข้อความที่เคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- รับการเคลื่อนไหว
- สกัดการเคลื่อนไหว
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- สกัดเอฟเฟกต์
- เสียงของเอฟเฟกต์
- ใช้การเคลื่อนไหว
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, ตรวจสอบ และปรับแต่งการเคลื่อนไหวของรูปร่าง, การตั้งเวลา, เสียง, พฤติกรรมหลังการเคลื่อนไหว, และข้อความที่เคลื่อนไหวด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

หากต้องการทำงานกับพฤติกรรมแต่ละอย่างภายในเอฟเฟกต์หรือแก้ไขส่วนของเส้นทางการเคลื่อนที่ ให้ดูที่ [การเคลื่อนไหวแบบกำหนดเองสำหรับ Java](/slides/th/java/custom-animation/).

Aspose.Slides สำหรับ Android ผ่าน Java แสดงการเคลื่อนไหวของสไลด์เป็นเอฟเฟกต์ในไทม์ไลน์ของสไลด์ เอฟเฟกต์หนึ่งมีรูปร่างเป้าหมาย, ประเภทและชนิดย่อยของการเคลื่อนไหว, ตัวกระตุ้น, การตั้งค่าเวลา, และคุณสมบัติเสริมเช่นเสียงหรือพฤติกรรมหลังการเคลื่อนไหว.

The timeline contains two kinds of sequences:

- **ลำดับหลัก** เล่นเมื่อสไลด์เคลื่อนต่อไป.
- **ลำดับโต้ตอบ** เริ่มเมื่อรูปร่างตัวกระตุ้นถูกคลิก.

เนื่องจากกล่องข้อความ, รูปภาพ, แผนภูมิ, ตาราง และวัตถุสไลด์อื่น ๆ ทำการ implement [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/), คุณจึงใช้เมธอด [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) เดียวกันสำหรับเนื้อหาสไลด์ส่วนใหญ่ เอฟเฟกต์ที่ใช้ได้จะถูกแสดงในคลาส [EffectType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effecttype/).

## **เพิ่มการเคลื่อนไหวของรูปร่าง**

ในการเพิ่มการเคลื่อนไหว, รับลำดับหลักของสไลด์และเรียกเมธอด [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) พร้อมด้วยรูปร่างเป้าหมาย, ประเภทเอฟเฟกต์, ชนิดย่อย, และตัวกระตุ้น. สำหรับเอฟเฟกต์ที่เริ่มเมื่อรูปร่างอื่นถูกคลิก, สร้างลำดับโต้ตอบที่ตัวกระตุ้นคือรูปร่างนั้น.

ตัวอย่างต่อไปนี้สร้างการเคลื่อนไหวทั้งสองประเภทและบันทึกผลลัพธ์เป็น `shape-animations.pptx`.

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

The trigger controls when an effect starts:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effecttriggertype/#OnClick) รอการคลิกในลำดับหลัก, หรือการคลิกบนรูปร่างตัวกระตุ้นในลำดับโต้ตอบ.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) เริ่มกับเอฟเฟกต์ก่อนหน้า.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) เริ่มเมื่อเอฟเฟกต์ก่อนหน้าจบลง.

เพื่อทำให้รูปภาพ, แผนภูมิ, หรือรูปแบบรูปร่างอื่นเคลื่อนไหว, ส่งอ็อบเจ็กต์นั้นไปยัง [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) แทน `targetShape`. สำหรับตัวเลือกการจัดกลุ่มเฉพาะแผนภูมิ, ดู [แผนภูมิที่เคลื่อนไหว](/slides/th/androidjava/animated-charts/).

## **อ่านการเคลื่อนไหวของรูปร่าง**

ใช้ [ISequence.getEffectsByShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) เมื่อคุณทราบรูปร่างเป้าหมาย. เพื่อตรวจสอบทุกเอฟเฟกต์, ทำการวนลำดับหลักและลำดับโต้ตอบทั้งหมด. การวนลูปช่วยหลีกเลี่ยงการสมมติว่าลำดับมีเอฟเฟกต์ที่ตำแหน่ง `0`.

ตัวอย่างต่อไปนี้สร้างรูปร่างที่มีเอฟเฟกต์ในลำดับหลักและลำดับโต้ตอบ, ดึงเอฟเฟกต์ที่ชี้เป้าไปยังรูปร่างนั้น, แล้วทำการวนลูปทุกลำดับบนสไลด์.

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

หากคุณต้องการเอฟเฟกต์สำหรับรูปร่างเดียวเท่านั้น, ให้ระบุตัวรูปร่างโดยชื่อ, ชนิด placeholder, หรือคุณสมบัติอื่นที่มั่นคงก่อน; แล้วเรียก [ISequence.getEffectsByShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). อย่าสมมติว่า [IShapeCollection.get_Item](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) ที่ตำแหน่ง `0` เป็นอ็อบเจ็กต์ที่ต้องการเสมอ.

## **ทำงานกับเอฟเฟกต์ Placeholder ที่สืบทอด**

Placeholder บนสไลด์ปกติสามารถสืบทอดพฤติกรรมการเคลื่อนไหวจาก Placeholder ที่สอดคล้องบนสไลด์เลเอาท์และมาสเตอร์สไลด์ได้. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) คืนค่า Placeholder พ่อแม่นั้น, หรือ `null` หากไม่มีพ่อแม่.

ในตัวอย่างงานนำเสนอต่อไปนี้, ส่วนท้ายมี **Random Bars** บนสไลด์ปกติ, **Split** บนสไลด์เลเอาท์, และ **Fly In** บนสไลด์มาสเตอร์.

![เอฟเฟกต์การเคลื่อนไหวของส่วนท้ายบนสไลด์ปกติ](slide-shape-animation.png)

![เอฟเฟกต์การเคลื่อนไหวของ Placeholder ส่วนท้ายบนสไลด์เลเอาท์](layout-shape-animation.png)

![เอฟเฟกต์การเคลื่อนไหวของ Placeholder ส่วนท้ายบนสไลด์มาสเตอร์](master-shape-animation.png)

ตัวอย่างต่อไปนี้ใช้โครงสร้าง hierarchy ของ placeholder จากงานนำเสนอใหม่. มันเพิ่มเอฟเฟกต์ให้กับ master placeholder, layout placeholder, และ placeholder ที่สอดคล้องบนสไลด์ปกติ. ทุกการเรียก [IShape.getBasePlaceholder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) จะถูกตรวจสอบก่อนนำรูปร่างที่คืนค่าไปใช้.

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

## **เปลี่ยนการตั้งค่าเวลาเคลื่อนไหว**

กล่องโต้ตอบ **Timing** ของ PowerPoint จะสอดคล้องกับคุณสมบัติของ [ITiming](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/).

![กล่องโต้ตอบ Timing ของ PowerPoint สำหรับเอฟเฟกต์การเคลื่อนไหว](shape-animation.png)

- **Start** สอดคล้องกับ [ITiming.getTriggerType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** สอดคล้องกับ [ITiming.getDuration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getDuration--), หน่วยเป็นวินาที.
- **Delay** สอดคล้องกับ [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--), หน่วยเป็นวินาที.
- **Repeat** สอดคล้องกับ [ITiming.getRepeatCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), หรือ [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** สอดคล้องกับ [ITiming.getRewind](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getRewind--).

ตัวอย่างอิสระนี้เพิ่มเอฟเฟกต์, ปรับเวลาผ่านอ็อบเจ็กต์ที่คืนค่าจาก [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), และบันทึกผลลัพธ์. การเก็บอ้างอิง [IEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/) ที่คืนค่ามาช่วยหลีกเลี่ยงการเข้าถึงดัชนีคอลเลคชันที่ไม่จำเป็น.

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

ใช้โหมดการทำซ้ำเพียงหนึ่งแบบโดยเจตนา. การรวมจำนวนการทำซ้ำกับแฟล็ก “until” อาจทำให้ผลลัพธ์สับสนในผู้ชมต่าง ๆ. เมื่อเปลี่ยนโหมดการทำซ้ำ, ให้ตั้งค่า [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) และ [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) ก่อน [ITiming.setRepeatCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-), เนื่องจากการตั้งค่าแฟล็กใดแฟล็กหนึ่งจะเปลี่ยนโหมดการทำซ้ำที่ใช้งาน.

## **เพิ่มและดึงเสียงการเคลื่อนไหว**

เอฟเฟกต์การเคลื่อนไหวสามารถอ้างอิงไฟล์เสียงที่ฝังอยู่ผ่าน [IEffect.getSound](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) บอกให้เอฟเฟกต์หยุดเสียงที่เริ่มโดยเอฟเฟกต์ก่อนหน้า.

### **เพิ่มเสียงให้กับเอฟเฟกต์**

ตัวอย่างต่อไปนี้คาดว่าไฟล์เสียงในเครื่องที่ชื่อ `animation-sound.wav`. มันสร้างสองเอฟเฟกต์, ฝังไฟล์นั้นเป็นเสียงให้กับเอฟเฟกต์แรก, และตั้งค่าให้เอฟเฟกต์ที่สองหยุดเสียง. มันใช้อ็อบเจ็กต์ที่คืนค่าจาก [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), ดังนั้นไม่จำเป็นต้องระบุดัชนีลำดับ.

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

### **ดึงเสียงที่ฝังอยู่ในเอฟเฟกต์**

ตัวอย่างต่อไปนี้คาดว่าไฟล์งานนำเสนอในเครื่องที่ชื่อ `presentation-with-animation-sounds.pptx`. มันสแกนลำดับหลักและลำดับโต้ตอบทั้งสองและเขียนเสียงเอฟเฟกต์ที่ฝังอยู่ทุกไฟล์ลงในไดเรกทอรี `extracted-animation-sounds`. ส่วนขยายไฟล์จะถูกเลือกตาม MIME type ของเสียงที่ให้โดย [IAudio.getContentType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudio/#getContentType--).

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

สำหรับอ็อบเจ็กต์เสียงขนาดใหญ่, ใช้ [IAudio.getStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudio/#getStream--) และคัดลอกสตรีมไปยังไฟล์แทนการโหลดอ็อบเจ็กต์ทั้งหมดเข้าสู่ byte array.

## **ตั้งค่าพฤติกรรมหลังการเคลื่อนไหว**

ตัวเลือก **After animation** ควบคุมสิ่งที่จะเกิดขึ้นกับรูปร่างหลังจากเอฟเฟกต์เสร็จสิ้น.

![กล่องโต้ตอบ PowerPoint Effect Options แสดงการตั้งค่า After animation](shape-after-animation.png)

คลาส [AfterAnimationType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/) รองรับการทำให้รูปร่างคงเดิม, เปลี่ยนสี, ซ่อนหลังการเคลื่อนไหว, หรือซ่อนเมื่อคลิกครั้งถัดไป. เมื่อประเภทเป็น [AfterAnimationType.Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#Color), ให้ตั้งค่า [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--) ด้วย.

ตัวอย่างอิสระนี้สร้างเอฟเฟกต์, ตั้งค่าพฤติกรรมหลังการเคลื่อนไหวผ่านอ็อบเจ็กต์เอฟเฟกต์ที่คืนค่า, และบันทึกผลลัพธ์.

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

การเปลี่ยนประเภทออกจาก [AfterAnimationType.Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#Color) จะลบการตั้งค่าสีหลังการเคลื่อนไหว.

## **เคลื่อนไหวข้อความ**

Text animation has two related controls:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextanimation/#getBuildType--) ควบคุมว่าข้อความย่อหน้าจะแสดงพร้อมกันหรือเป็นระดับย่อหน้า.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) ควบคุมว่าข้อความจะแสดงทั้งหมดพร้อมกัน, ตามคำ, หรือ ตามตัวอักษร. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) ตั้งค่าการหน่วงเวลาระหว่างคำหรืออักษร. ค่าบวกเป็นเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์; ค่าติดลบเป็นหน่วงเวลาวินาที.

ตัวอย่างอิสระต่อไปนี้ทำให้คำในกล่องข้อความเคลื่อนไหว. [BuildType.AsOneObject] ปิดการสร้างตามย่อหน้าตามย่อหน้า ทำให้การตั้งค่าคำใช้กับกรอบข้อความทั้งหมด.

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

เพื่อสร้างกล่องข้อความตามย่อหน้า, ตั้งค่า [BuildType.ByLevelParagraphs1] (หรือระดับย่อหน้าอื่น). เพื่อให้ย่อหน้าเดียวมีเอฟเฟกต์ของมันเอง, ใช้ overload ของ [ISequence.addEffect] ที่รับ [IParagraph]. ดู [ข้อความที่เคลื่อนไหว](/slides/th/androidjava/animated-text/) สำหรับตัวอย่างระดับย่อหน้า.

## **การส่งออกและบันทึกหมายเหตุความเข้ากันได้**

- การบันทึกเป็น PPT หรือ PPTX จะคงโมเดลการเคลื่อนไหวไว้, แต่การเล่นขั้นสุดท้ายขึ้นกับโปรแกรมแสดงผลงานนำเสนอ.
- PDF และรูปภาพนิ่งไม่สามารถเล่นการเคลื่อนไหวได้. ใช้ [HTML5 export](/slides/th/androidjava/export-to-html5/), GIF ที่เคลื่อนไหว, หรือ [video conversion](/slides/th/androidjava/convert-powerpoint-to-video/) เมื่อผลลัพธ์ต้องแสดงการเคลื่อนที่.
- สำหรับ HTML5, เปิดใช้งาน [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และเมื่อจำเป็น, เปิด [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- การเรนเดอร์วิดีโอรองรับเอฟเฟกต์การเข้ามา, เน้น, ออกจาก, และเส้นทางการเคลื่อนที่ที่พบบ่อยหลายประเภท, แต่ไม่ใช่ทุกเอฟเฟ็กต์ของ PowerPoint ที่รองรับ. ตรวจสอบ [supported animations and effects](/slides/th/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) ปัจจุบันและทดสอบงานนำเสนอสำคัญกับเวอร์ชัน Aspose.Slides ที่คุณใช้.
- เอฟเฟกต์ที่กำหนดเองขั้นสูงและเอฟเฟกต์ที่นำเข้าจากรูปแบบงานนำเสนออื่นอาจถูกเก็บไว้ในไฟล์แต่แสดงผลแตกต่างใน PowerPoint, HTML5 หรือวิดีโอ. ตรวจสอบผลลัพธ์ที่ส่งออกแทนการพึ่งพาแค่ชื่อเอฟเฟกต์.

## **คำถามที่พบบ่อย**

**ทำไมการเคลื่อนไหวนั้นจึงแสดงใน PowerPoint แต่ไม่แสดงใน PDF?**

PDF เป็นรูปแบบสถิต, ดังนั้นการเคลื่อนไหวและการเปลี่ยนสไลด์จะไม่เล่น. ส่งออกเป็น HTML5, GIF ที่เคลื่อนไหว, หรือวิดีโอเมื่อต้องการเก็บการเคลื่อนไหว.

**ทำไมเอฟเฟกต์จึงเล่นแตกต่างในวิดีโอ?**

การส่งออกวิดีโอเรนเดอร์การเคลื่อนไหวแทนการเก็บพฤติกรรมเดิมของ PowerPoint. เอฟเฟกต์ขั้นสูงบางอย่างไม่รองรับหรือถูกประมาณค่า. ตรวจสอบตารางเอฟเฟกต์ที่รองรับและทดสอบงานนำเสนอจริงก่อนการใช้งานจริง.

**การย้ายรูปร่างไปข้างหน้าหรือข้างหลังส่งผลต่อลำดับการเคลื่อนไหวหรือไม่?**

ไม่. การเรียงลำดับ z-order ของรูปร่างควบคุมการซ้อนกัน, ส่วนลำดับของซีเควนซ์และตัวกระตุ้นควบคุมการเล่นการเคลื่อนไหว. ให้ปรับไทม์ไลน์หากต้องการลำดับการเล่นที่แตกต่าง.
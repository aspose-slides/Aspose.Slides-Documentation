---
title: ประยุกต์ใช้การเคลื่อนไหวของรูปร่างในงานนำเสนอด้วย Java
linktitle: การเคลื่อนไหวของรูปร่าง
type: docs
weight: 60
url: /th/java/shape-animation/
keywords:
- รูปร่าง
- การเคลื่อนไหว
- เอฟเฟกต์
- รูปร่างที่เคลื่อนไหว
- ข้อความที่เคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- รับการเคลื่อนไหว
- ดึงการเคลื่อนไหว
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- ดึงเอฟเฟกต์
- เสียงของเอฟเฟกต์
- ประยุกต์การเคลื่อนไหว
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่ม, ตรวจสอบ และปรับแต่งการเคลื่อนไหวของรูปร่าง, การตั้งเวลา, เสียง, พฤติกรรมหลังการเคลื่อนไหว, และข้อความที่เคลื่อนไหวด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Aspose.Slides for Java แสดงการเคลื่อนไหวของสไลด์เป็นเอฟเฟกต์ในไทม์ไลน์ของสไลด์ เอฟเฟกต์หนึ่งมีรูปทรงเป้าหมาย, ชนิดและประเภทย่อยของการเคลื่อนไหว, ตัวกระตุ้น, การตั้งค่าเวลา, และคุณสมบัติเสริมเช่นเสียงหรือพฤติกรรมหลังการเคลื่อนไหว

ไทม์ไลน์ประกอบด้วยสองประเภทของลำดับ:

- **ลำดับหลัก** เล่นเมื่อสไลด์เลื่อนต่อไป
- **ลำดับโต้ตอบ** เริ่มเมื่อรูปทรงที่เป็นตัวกระตุ้นถูกคลิก

เนื่องจากกล่องข้อความ, รูปภาพ, แผนภูมิ, ตาราง และวัตถุสไลด์อื่น ๆ ใช้งานได้ผ่าน [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/), คุณสามารถใช้เมธอดเดียวกันคือ [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) สำหรับส่วนใหญ่ของเนื้อหาสไลด์ สิทธิ์การใช้งานของเอฟเฟกต์ต่าง ๆ ถูกระบุไว้ในคลาส [EffectType](https://reference.aspose.com/slides/th/java/com.aspose.slides/effecttype/)

## **เพิ่มการเคลื่อนไหวของรูปร่าง**

เพื่อเพิ่มการเคลื่อนไหว ให้ดึงลำดับหลักของสไลด์และเรียก [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) พร้อมกับรูปทรงเป้าหมาย, ชนิดเอฟเฟกต์, ประเภทย่อย, และตัวกระตุ้น สำหรับเอฟเฟกต์ที่เริ่มเมื่อรูปทรงอื่นถูกคลิก ให้สร้างลำดับโต้ตอบที่ตัวกระตุ้นคือรูปทรงอื่นนั้น

ตัวอย่างต่อไปนี้สร้างการเคลื่อนไหวทั้งสองประเภทและบันทึกผลลัพธ์เป็น `shape-animations.pptx`

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

ตัวกระตุ้นกำหนดว่าเอฟเฟกต์จะเริ่มเมื่อใด:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/effecttriggertype/#OnClick) รอการคลิกในลำดับหลัก, หรือการคลิกบนรูปทรงที่เป็นตัวกระตุ้นในลำดับโต้ตอบ
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/th/java/com.aspose.slides/effecttriggertype/#WithPrevious) เริ่มพร้อมกับเอฟเฟกต์ก่อนหน้า
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/th/java/com.aspose.slides/effecttriggertype/#AfterPrevious) เริ่มเมื่อเอฟเฟกต์ก่อนหน้าจบ

เพื่อเคลื่อนไหวรูปภาพ, แผนภูมิ หรือรูปทรงประเภทอื่น ให้ส่งอ็อบเจ็กต์นั้นไปยัง [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) แทน `targetShape`. สำหรับตัวเลือกการจัดกลุ่มเฉพาะแผนภูมิ ดูที่ [Animated Charts](/slides/th/java/animated-charts/)

## **อ่านการเคลื่อนไหวของรูปร่าง**

ใช้ [ISequence.getEffectsByShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) เมื่อคุณรู้จักรูปทรงเป้าหมาย. เพื่อสำรวจทุกเอฟเฟกต์ ให้วนลูปลำดับหลักและลำดับโต้ตอบทุกลำดับ. การวนลูปช่วยหลีกเลี่ยงการสันนิษฐานว่าลำดับมีเอฟเฟกต์ที่ตำแหน่ง `0`

ตัวอย่างต่อไปนี้สร้างรูปร่างที่มีเอฟเฟกต์ในลำดับหลักและลำดับโต้ตอบ, ดึงเอฟเฟกต์ที่เป้าหมายคือรูปร่างนั้น, แล้ววนลูปทุกลำดับบนสไลด์

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

หากคุณต้องการเอฟเฟกต์สำหรับรูปทรงเดียวเท่านั้น, ให้ระบุตัวรูปทรงตามชื่อ, ประเภทพลาเซฮอลเดอร์, หรือคุณสมบัติที่คงที่อื่น ๆ; จากนั้นเรียก [ISequence.getEffectsByShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). อย่าสันนิษฐานว่า [IShapeCollection.get_Item](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#get_Item-int-) ที่ตำแหน่ง `0` เป็นอ็อบเจกต์ที่ต้องการเสมอ

## **ทำงานกับเอฟเฟกต์ของพลาเซฮอลเดอร์ที่สืบทอด**

พลาเซฮอลเดอร์บนสไลด์ปกติสามารถสืบทอดพฤติกรรมการเคลื่อนไหวจากพลาเซฮอลเดอร์ที่สอดคล้องบนสไลด์เลย์เอาต์และสไลด์มาสเตอร์ได้. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getBasePlaceholder--) คืนค่าพลาเซฮอลเดอร์พาเรนท์นั้น, หรือ `null` หากไม่มีพาเรนท์

ในตัวอย่างงานนำเสนอต่อไปนี้, ส่วนท้ายมี **Random Bars** บนสไลด์ปกติ, **Split** บนสไลด์เลย์เอาต์, และ **Fly In** บนสไลด์มาสเตอร์

![เอฟเฟกต์การเคลื่อนไหวของส่วนท้ายบนสไลด์ปกติ](slide-shape-animation.png)

![เอฟเฟกต์การเคลื่อนไหวของพลาเซฮอลเดอร์ส่วนท้ายบนสไลด์เลย์เอาต์](layout-shape-animation.png)

![เอฟเฟกต์การเคลื่อนไหวของพลาเซฮอลเดอร์ส่วนท้ายบนสไลด์มาสเตอร์](master-shape-animation.png)

ตัวอย่างต่อไปนี้ใช้ลำดับชั้นพลาเซฮอลเดอร์จากงานนำเสนอใหม่. มันเพิ่มเอฟเฟกต์ให้กับพลาเซฮอลเดอร์มาสเตอร์, พลาเซฮอลเดอร์เลย์เอาต์, และพลาเซฮอลเดอร์ที่สอดคล้องบนสไลด์ปกติ. ทุกการเรียก [IShape.getBasePlaceholder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getBasePlaceholder--) จะตรวจสอบก่อนที่รูปทรงที่คืนค่าจะถูกใช้

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

กล่องโต้ตอบ **Timing** ของ PowerPoint จะเชื่อมกับคุณสมบัติของ [ITiming](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/)

![กล่องโต้ตอบ Timing ของ PowerPoint สำหรับเอฟเฟกต์การเคลื่อนไหว](shape-animation.png)

- **Start** เชื่อมกับ [ITiming.getTriggerType](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getTriggerType--)
- **Duration** เชื่อมกับ [ITiming.getDuration](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getDuration--), หน่วยเป็นวินาที
- **Delay** เชื่อมกับ [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getTriggerDelayTime--), หน่วยเป็นวินาที
- **Repeat** เชื่อมกับ [ITiming.getRepeatCount](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), หรือ [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--)
- **Rewind when done playing** เชื่อมกับ [ITiming.getRewind](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getRewind--)

ตัวอย่างอิสระนี้เพิ่มเอฟเฟกต์, เปลี่ยนเวลาผ่านอ็อบเจ็กต์ที่คืนมาจาก [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), และบันทึกผลลัพธ์. การเก็บอ้างอิงของ [IEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/) ที่คืนมาช่วยหลีกเลี่ยงการใช้ดัชนีคอลเลกชันโดยไม่จำเป็น

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

ใช้โหมดการทำซ้ำแบบเดียวโดยเจตนา. การผสมจำนวนการทำซ้ำกับแฟล็ก “until” อาจทำให้ผลลัพธ์สับสนในโปรแกรมดูต่าง ๆ. เมื่อเปลี่ยนโหมดการทำซ้ำ ให้ตั้งค่า [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) และ [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) ก่อน [ITiming.setRepeatCount](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#setRepeatCount-float-), เนื่องจากการตั้งค่าแฟล็กใด ๆ จะเปลี่ยนโหมดการทำซ้ำที่ใช้งาน

## **เพิ่มและดึงเสียงของการเคลื่อนไหว**

เอฟเฟกต์การเคลื่อนไหวสามารถอ้างอิงไฟล์เสียงฝังอยู่ผ่าน [IEffect.getSound](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) บอกให้เอฟเฟกต์หยุดเสียงที่เริ่มจากเอฟเฟกต์ก่อนหน้า

### **เพิ่มเสียงให้กับเอฟเฟกต์**

ตัวอย่างต่อไปนี้คาดว่าไฟล์เสียงท้องถิ่นชื่อ `animation-sound.wav`. มันสร้างสองเอฟเฟกต์, ฝังไฟล์นั้นเป็นเสียงสำหรับเอฟเฟกต์แรก, และกำหนดให้เอฟเฟกต์ที่สองหยุดเสียง. มันใช้วัตถุที่คืนมาจาก [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), ดังนั้นไม่ต้องระบุดัชนีลำดับ

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

ตัวอย่างต่อไปนี้คาดว่าไฟล์งานนำเสนอท้องถิ่นชื่อ `presentation-with-animation-sounds.pptx`. มันสแกนทั้งลำดับหลักและลำดับโต้ตอบและเขียนเสียงที่ฝังอยู่ของทุกเอฟเฟกต์ไปยังโฟลเดอร์ `extracted-animation-sounds`. นามสกุลไฟล์เลือกจาก MIME type ของเสียงที่เปิดเผยโดย [IAudio.getContentType](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaudio/#getContentType--)

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

สำหรับไฟล์เสียงขนาดใหญ่, ใช้ [IAudio.getStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaudio/#getStream--) แล้วคัดลอกสตรีมไปยังไฟล์แทนการโหลดอ็อบเจ็กต์ทั้งหมดเข้าสู่ byte array

## **ตั้งค่าพฤติกรรมหลังการเคลื่อนไหว**

ตัวเลือก **After animation** ควบคุมว่าจะเกิดอะไรกับรูปร่างหลังจากเอฟเฟกต์เสร็จสิ้น

![กล่องโต้ตอบ Effect Options ของ PowerPoint แสดงการตั้งค่า After animation](shape-after-animation.png)

คลาส [AfterAnimationType](https://reference.aspose.com/slides/th/java/com.aspose.slides/afteranimationtype/) รองรับการทิ้งรูปร่างให้อยู่เหมือนเดิม, การเปลี่ยนสี, การซ่อนหลังการเคลื่อนไหว, หรือการซ่อนเมื่อคลิกครั้งต่อไป. เมื่อประเภทเป็น [AfterAnimationType.Color](https://reference.aspose.com/slides/th/java/com.aspose.slides/afteranimationtype/#Color), ต้องตั้งค่า [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getAfterAnimationColor--) ด้วย

ตัวอย่างอิสระนี้สร้างเอฟเฟกต์, ตั้งค่าพฤติกรรมหลังการเคลื่อนไหวผ่านอ็อบเจ็กต์เอฟเฟกต์ที่คืนค่า, และบันทึกผลลัพธ์

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

การเปลี่ยนประเภทออกจาก [AfterAnimationType.Color](https://reference.aspose.com/slides/th/java/com.aspose.slides/afteranimationtype/#Color) จะล้างการตั้งค่าสีหลังการเคลื่อนไหว

## **เคลื่อนไหวข้อความ**

การเคลื่อนไหวข้อความมีการควบคุมสองอย่างที่เกี่ยวข้อง:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextanimation/#getBuildType--) ควบคุมว่าข้อความย่อหน้าจะปรากฏพร้อมกันหรือเป็นระดับย่อหน้า
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getAnimateTextType--) ควบคุมว่าข้อความปรากฏทั้งหมดพร้อมกัน, ตามคำ, หรือตามตัวอักษร. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) ตั้งค่าการหน่วงเวลาระหว่างคำหรืออักษร. ค่าเป็นบวกเป็นเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์; ค่าเป็นลบเป็นหน่วงเวลาเป็นวินาที

ตัวอย่างอิสระต่อไปนี้เคลื่อนไหวคำในกล่องข้อความ

[BuildType.AsOneObject](https://reference.aspose.com/slides/th/java/com.aspose.slides/buildtype/#AsOneObject) ปิดการสร้างตามย่อหน้าทีละย่อหน้าเพื่อให้การตั้งค่าคำใช้กับกรอบข้อความทั้งหมด

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

หากต้องการสร้างกล่องข้อความตามย่อหน้า, ตั้งค่า [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/th/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (หรือระดับย่อหน้าอื่น). เพื่อให้ย่อหน้าเดียวมีเอฟเฟกต์ของตนเอง, ใช้การโอเวอร์โหลดของ [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) ที่รับ [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/). ดู [Animated Text](/slides/th/java/animated-text/) สำหรับตัวอย่างระดับย่อหน้า

## **บันทึกและหมายเหตุความเข้ากันได้**

- การบันทึกเป็น PPT หรือ PPTX จะรักษาโมเดลการเคลื่อนไหว, แต่การเล่นสุดท้ายขึ้นอยู่กับโปรแกรมดูงานนำเสนอ
- PDF และรูปภาพนิ่งไม่สามารถเล่นการเคลื่อนไหวได้. ใช้ [HTML5 export](/slides/th/java/export-to-html5/), GIF ที่เคลื่อนไหว, หรือ [video conversion](/slides/th/java/convert-powerpoint-to-video/) เมื่อผลลัพธ์ต้องแสดงการเคลื่อนไหว
- สำหรับ HTML5, เปิดใช้งาน [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และเมื่อจำเป็น, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)
- การเรนเดอร์วิดีโอรองรับเอฟเฟกต์เช่น การเข้ามา, เน้น, ออก, และเส้นทางเคลื่อนที่หลายแบบ, แต่ไม่รองรับทุกเอฟเฟกต์ของ PowerPoint. ตรวจสอบ [supported animations and effects](/slides/th/java/convert-powerpoint-to-video/#supported-animations-and-effects) และทดสอบงานนำเสนอสำคัญกับรุ่น Aspose.Slides ที่ใช้
- เอฟเฟกต์แบบกำหนดเองขั้นสูงและเอฟเฟกต์ที่นำเข้าจากรูปแบบงานนำเสนออื่น ๆ อาจถูกเก็บไว้ในไฟล์แต่แสดงผลต่างกันใน PowerPoint, HTML5, หรือวิดีโอ. ตรวจสอบผลการส่งออกแทนการพึ่งพาชื่อเอฟเฟกต์เพียงอย่างเดียว

## **คำถามที่พบบ่อย**

**ทำไมการเคลื่อนไหวจึงแสดงใน PowerPoint แต่ไม่แสดงใน PDF?**

PDF เป็นรูปแบบคงที่, ดังนั้นการเคลื่อนไหวและการเปลี่ยนสไลด์ไม่ทำงาน. ส่งออกเป็น HTML5, GIF ที่เคลื่อนไหว, หรือวิดีโอเมื่อต้องการรักษาการเคลื่อนไหว

**ทำไมเอฟเฟกต์ถึงเล่นแตกต่างในวิดีโอ?**

การส่งออกวิดีโอเรนเดอร์การเคลื่อนไหวแทนการเก็บพฤติกรรมดั้งเดิมของ PowerPoint. เอฟเฟกต์ขั้นสูงบางอย่างไม่รองรับหรือถูกประมาณค่า. ตรวจสอบตารางเอฟเฟกต์ที่สนับสนุนและทดสอบงานนำเสนอจริงก่อนการใช้ในผลิตภัณฑ์

**การย้ายรูปร่างไปข้างหน้าหรือข้างหลังจะเปลี่ยนลำดับการเคลื่อนไหวหรือไม่?**

ไม่. การจัดลำดับ z-order ของรูปร่างควบคุมการทับซ้อน, ส่วนลำดับของลำดับและตัวกระตุ้นควบคุมการเล่นการเคลื่อนไหว. ปรับไทม์ไลน์หากต้องการลำดับการเล่นที่ต่างกัน
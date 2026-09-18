---
title: สร้างและแก้ไขพฤติกรรมการเคลื่อนไหวที่กำหนดเองใน Java
linktitle: การเคลื่อนไหวแบบกำหนดเอง
type: docs
weight: 151
url: /th/java/custom-animation/
keywords:
- การเคลื่อนไหวแบบกำหนดเอง
- พฤติกรรมการเคลื่อนไหว
- เส้นทางการเคลื่อนที่
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้าง, ตรวจสอบ, และแก้ไขพฤติกรรมการเคลื่อนไหวที่กำหนดเองและเส้นทางการเคลื่อนที่ที่แก้ไขได้ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

พฤติกรรมการเคลื่อนไหวแบบกำหนดเองช่วยให้คุณควบคุมการทำงานแต่ละอย่างภายในเอฟเฟกต์การเคลื่อนไหวได้ เช่น การเปลี่ยนสี การหมุนรูปร่าง หรือการตามเส้นทางการเคลื่อนที่ที่แก้ไขได้ คู่มือนี้แสดงวิธีการสร้างและผสานพฤติกรรมต่าง ๆ ตั้งค่าเวลา ตรวจสอบและแก้ไขการเคลื่อนไหวที่มีอยู่ และตรวจสอบว่าคุณสมบัติเหล่านั้นยังคงอยู่หลังจากบันทึกและเปิดนำเสนอใหม่

สำหรับเอฟเฟกต์ที่กำหนดล่วงหน้าและการเรียกใช้ด้วยคลิก ดูที่ [การเคลื่อนไหวของรูปร่าง](/slides/th/java/shape-animation/)

## **ทำความเข้าใจโมเดลการเคลื่อนไหว**

การเคลื่อนไหวถูกจัดระเบียบเป็น **Timeline → Sequence → Effect → Behaviors**:

- วิธีการ [getTimeline](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/#getTimeline--) คืนค่าไทม์ไลน์ของสไลด์ ซึ่งบรรจุซีเควนส์หลักและซีเควนส์เชิงโต้ตอบ
- [ISequence](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/) มีเอฟเฟกต์ต่าง ๆ ที่อาจกำหนดเป้าหมายไปยังรูปร่างที่แตกต่างกัน
- [IEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/) ระบุรูปร่างเป้าหมาย, พรีเซ็ต, ประเภทย่อย, และเวลาของเอฟเฟกต์
- คอลเลกชันที่คืนค่าจาก [IEffect.getBehaviors](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getBehaviors--) มีการดำเนินการที่ทำให้เอฟเฟกต์ทำงาน: การเปลี่ยนสี, การย้าย, การหมุน, การกำหนดค่า, ฯลฯ

## **สร้างพฤติกรรมเดี่ยว**

เรียก [ISequence.addEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) เพื่อสร้างเอฟเฟกต์และเข้าถึงคอลเลกชัน [getBehaviors](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getBehaviors--) พรีเซ็ตอาจเติมคอลเลกชันนี้โดยอัตโนมัติ เก็บการดำเนินการไว้เมื่อขยายพรีเซ็ต หรือใช้ [clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorcollection/#clear--) เมื่อกำหนดให้แทนที่อย่างเจตนา

[IBehaviorFactory](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorfactory/) สร้างพฤติกรรม 8 ประเภทตามที่แสดงด้านล่าง การเคลื่อนไหวจะอธิบายในหัวข้อ [สร้างเส้นทางการเคลื่อนไหว] (#build-a-motion-path) ตัวอย่างแต่ละส่วนรวมการนำเข้า; ใส่คำสั่งที่สามารถทำงานได้ไว้ภายในเมธอด ตัวอย่างการแก้ไขในภายหลังจะบอกว่าไฟล์ผลลัพธ์ใช้ไฟล์ใด

### **การหมุน**

ใช้ [createRotationEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) เพื่อสร้างการหมุน [getBy](https://reference.aspose.com/slides/th/java/com.aspose.slides/irotationeffect/#getBy--) ระบุมุมสัมพัทธ์เป็นองศา; [getFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/irotationeffect/#getFrom--) และ [getTo](https://reference.aspose.com/slides/th/java/com.aspose.slides/irotationeffect/#getTo--) ระบุจุดเริ่มต้นและปลาย

ตัวอย่างเริ่มด้วยเอฟเฟกต์ Spin, แทนที่การดำเนินการพรีเซ็ตด้วยพฤติกรรมการหมุนหนึ่งรายการ และกำหนดระยะเวลาให้สองวินาที มุมสัมพัทธ์ 90 องศาแสดงการหมุนไตรมาสจากทิศทางเริ่มต้นของรูปร่าง ดังนั้นไม่จำเป็นต้องกำหนดมุมเริ่มต้นอย่างชัดเจน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` มีรูปร่างหนึ่งอันและพฤติกรรมการหมุนหนึ่งรายการ คอลเลกชัน, เวลา, และตัวอย่างการแก้ไขการหมุนด้านล่างใช้ไฟล์นี้

### **การสเกล**

ใช้ [createScaleEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) พร้อมเปอร์เซ็นต์ X/Y: [getFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/iscaleeffect/#getFrom--) และ [getTo](https://reference.aspose.com/slides/th/java/com.aspose.slides/iscaleeffect/#getTo--) บรรยายขนาดเริ่มต้นและสิ้นสุด, ในขณะที่ [getBy](https://reference.aspose.com/slides/th/java/com.aspose.slides/iscaleeffect/#getBy--) บรรยายการเปลี่ยนแปลงสัมพัทธ์ ที่นี่ 100 หมายถึงขนาดเดิม

ตัวอย่างทำให้มิติทั้งสองเพิ่มจาก 100 % เป็น 125 % ในสองวินาที การใช้เปอร์เซ็นต์แนวนอนและแนวตั้งเท่ากันจะคงอัตราส่วนของรูปร่าง; เปอร์เซ็นต์ที่ต่างกันจะยืดมิติหนึ่งมากกว่าที่อื่น

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **สี**

ใช้ [createColorEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) เพื่อเปลี่ยนสีเติมจากสีน้ำเงินเป็นสีส้ม [getFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/icoloreffect/#getFrom--) และ [getTo](https://reference.aspose.com/slides/th/java/com.aspose.slides/icoloreffect/#getTo--) เป็นสี; [getBy](https://reference.aspose.com/slides/th/java/com.aspose.slides/icoloreffect/#getBy--) เป็นค่าชดเชยสี [IBehavior.getProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehavior/#getProperties--) ระบุแอตทริบิวต์ที่กำลังเคลื่อนไหว

การเติมสีของรูปร่างเริ่มต้นเป็นสีน้ำเงินสอดคล้องกับสีเริ่มต้นของการเคลื่อนไหว การเลือกแอตทริบิวต์สีเติมบอกพฤติกรรมว่าต้องเปลี่ยนส่วนใดของรูปร่าง; จุดสีปลายทางเพียงอย่างเดียวไม่สามารถบ่งบอกแอตทริบิวต์นั้นได้ เอฟเฟกต์ที่บันทึกไว้บรรยายการเปลี่ยนเป็นสีส้มในสองวินาที

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ฟิลเตอร์**

ใช้ [createFilterEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) เพื่อเลือกการลบล้าง [getType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifiltereffect/#getSubtype--), และ [getReveal](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifiltereffect/#getReveal--) ระบุฟิลเตอร์, ทิศทาง, และว่าจะเปิดหรือซ่อนรูปร่าง

ตัวอย่างนี้ตั้งค่าการลบล้างสองวินาทีที่เปิดเผยรูปร่างโดยใช้ประเภทย่อยทิศทางด้านขวา การตั้งค่าฟิลเตอร์เป็นของพฤติกรรมภายในเอฟเฟกต์ ดังนั้นจึงตั้งค่าหลังจากที่ลบการดำเนินการเดิมของพรีเซ็ตออกแล้ว

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **แอตทริบิวต์**

ใช้ [createPropertyEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) เพื่อทำให้ความทึบแสงเคลื่อนไหว [getFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipropertyeffect/#getTo--), และ [getBy](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipropertyeffect/#getBy--) เป็นสตริงที่ถูกตีความด้วย [getValueType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipropertyeffect/#getValueType--) และ [getCalcMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipropertyeffect/#getCalcMode--) เลือกจุดปลายหรือการชดเชยสัมพัทธ์แทนการตั้งค่าทั้งสามพร้อมกันโดยไม่มีการคัดกรอง

ที่นี่แอตทริบิวต์ที่เลือกคือ opacity และสตริงตัวเลขแสดงการเปลี่ยนจากความทึบ 25 % ไปเป็นความทึบเต็ม การเชื่อมต่อเชิงเส้นบรรยายการเปลี่ยนแปลงอย่างค่อยเป็นค่อยไประหว่างค่าทั้งสอง เมื่อนำตัวอย่างนี้ไปใช้กับแอตทริบิวต์อื่น ๆ ให้เลือกชนิดค่าที่เหมาะสมและค่าจุดปลายที่สอดคล้องกับแอตทริบิวต์นั้น

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **กำหนดค่า**

ใช้ [createSetEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) เพื่อกำหนดความมองเห็นผ่าน [getTo](https://reference.aspose.com/slides/th/java/com.aspose.slides/iseteffect/#getTo--) พฤติกรรม set ไม่ได้ทำการเชื่อมต่อระหว่างจุดปลาย

ตัวอย่างเลือกแอตทริบิวต์ visibility และกำหนดสตริง `visible` เมื่อพฤติกรรมทำงาน สี่เหล้เหลือมองเห็นอยู่แล้วในงานนำเสนอขนาดเล็กนี้ ดังนั้นการกำหนดอาจไม่ทำให้เห็นการเปลี่ยนแปลงที่ชัดเจนโดยตัวมันเอง การดำเนินการเช่นนี้มีประโยชน์เมื่อเป็นส่วนหนึ่งของเอฟเฟกต์ที่ใหญ่ขึ้นซึ่งควบคุมเวลาให้รูปร่างซ่อนหรือแสดง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **คำสั่ง**

ใช้ [createCommandEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) แล้วตั้งค่า [getType](https://reference.aspose.com/slides/th/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/th/java/com.aspose.slides/icommandeffect/#getCommandString--), และ [getShapeTarget](https://reference.aspose.com/slides/th/java/com.aspose.slides/icommandeffect/#getShapeTarget--) ใส่ไฟล์เสียง WAV ชื่อ `sample.wav` ไว้ในไดเรกทอรีทำงาน ตัวอย่างนี้ฝังไฟล์ด้วย [addAudioFrameEmbedded](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) และแนบคำสั่งเล่นไปยังเฟรมเสียง

เฟรมเสียงเป็นทั้งเป้าหมายของเอฟเฟกต์และของคำสั่ง การเชื่อมต่อคำสั่งเล่นกับการบันทึกที่ฝังอยู่; สตริงคำสั่งอย่างเดียวไม่บ่งบอกวัตถุสื่อใดที่จะควบคุม เอฟเฟกต์ตั้งค่าให้เริ่มต้นเมื่อคลิกขณะการนำเสนอ

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

การบันทึกจะเก็บคำสั่งใน `command.pptx`; ไฟล์นี้จะไม่เล่นการบันทึก การเล่นต้องอาศัยตัวเล่นสไลด์ที่รองรับคำสั่งและเป้าหมายสื่อของมัน

## **จัดการคอลเลกชันพฤติกรรม**

[IBehaviorCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorcollection/) รองรับ [add](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), และ [removeAt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-) ตัวอย่างนี้เปิด `rotation.pptx`, เพิ่มสเกล, ย้ายมันก่อนการหมุน, และลบการหมุน การลบและแทรกซ้ำวัตถุเดียวกันจะเปลี่ยนตำแหน่งที่จัดเก็บโดยไม่ทำสำเนา

ลำดับของการแก้ไขจะเปลี่ยนคอลเลกชันจาก rotation–scale เป็น scale–rotation แล้วเป็น scale เท่านั้น ดัชนีอ้างอิงคอลเลกชันปัจจุบัน ดังนั้นการลบใช้ดัชนีใหม่ของการหมุนหลังจากจัดเรียงใหม่ การนับครั้งสุดท้ายยืนยันพฤติกรรมใดที่จะถูกบันทึก

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์คือ `ScaleEffect`: เหลือแค่การสเกล คอลเลกชันโดยตัวมันเองไม่ได้กำหนดให้พฤติกรรมทำงานต่อเนื่องกันให้ใช้เวลาเท่านั้น ทำความสะอาดคอลเลกชันก็ต่อเมื่อต้องการแทนที่การดำเนินการทั้งหมด

## **กำหนดเวลาพฤติกรรม**

[IBehavior.getTiming](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehavior/#getTiming--) เปิดให้เข้าถึง [ITiming](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/), แยกจาก [IEffect.getTiming](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getTiming--) เวลาเอฟเฟกต์จัดตารางให้เอฟเฟกต์รอบนอก; เวลาพฤติกรรมบรรยายการดำเนินการภายในเอฟเฟกต์นั้น

### **กำหนดระยะเวลา, ความหน่วง, การทำซ้ำ, และการเร่งความเร็ว**

เปิด `rotation.pptx` และตั้งระยะเวลา ([getDuration](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getDuration--)) และความหน่วงของตัวกระตุ้น ([getTriggerDelayTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) เป็นวินาที แล้วกำหนดจำนวนการทำซ้ำด้วย [setRepeatCount](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#setRepeatCount-float-) [getAccelerate](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getAccelerate--) และ [getDecelerate](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getDecelerate--) เป็นส่วนของระยะเวลา; ให้ผลรวมไม่เกิน 1

ไฟล์อินพุตคือไฟล์ที่สร้างจากตัวอย่างการหมุน ซึ่งพฤติกรรมแรกเป็นการหมุน ตัวอย่างนี้เปลี่ยนเฉพาะเวลาเดียวของพฤติกรรมนั้น; มุม 90 องศายังคงเดิม การแยกมุมและเวลาออกจากกันทำให้ปรับความเร็วได้ง่ายโดยไม่ต้องสร้างเอฟเฟกต์ใหม่

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

พฤติกรรมนี้ใช้ระยะเวลา 2 วินาที, หน่วงครึ่งวินาที, และทำซ้ำ 3 ครั้ง 20 % แรกและสุดของระยะเวลาใช้สำหรับเร่งความเร็วและชะลอความเร็ว

นโยบายการทำซ้ำอื่น ๆ ได้แก่ [getRepeatDuration](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), และ [getRepeatUntilNextClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--) – เลือกนโยบายหนึ่งแทนการเปิดทั้งหมดพร้อมกัน [getAutoReverse](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiming/#getAutoReverse--) จะเล่นเอฟเฟกต์ย้อนกลับหลังจากรอบหน้า การเร่งและชะลอใช้กับการเปลี่ยนแปลงต่อเนื่อง ไม่ใช่การกำหนดค่าที่ตัดสินใจหรือคำสั่ง

## **สร้างเส้นทางการเคลื่อนไหว**

ใช้ [createMotionEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) เพื่อสร้างการเคลื่อนไหว [getFrom](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotioneffect/#getTo--), และ [getBy](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotioneffect/#getBy--) บรรยายพิกัดหรือชดเชยแบบเป็นเปอร์เซ็นต์ สำหรับเส้นทางที่แก้ไขได้ ให้สร้าง [MotionPath](https://reference.aspose.com/slides/th/java/com.aspose.slides/motionpath/) แล้วกำหนดด้วย [IMotionEffect.setPath](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) [IMotionPath](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotionpath/) เก็บคำสั่งเส้นทาง

[MotionCommandPathType](https://reference.aspose.com/slides/th/java/com.aspose.slides/motioncommandpathtype/) เลือกการดำเนินการ:

| คำสั่ง | จุด | ความหมาย |
| --- | --- | --- |
| MoveTo | หนึ่ง | ตั้งตำแหน่งเริ่มต้น |
| LineTo | หนึ่ง | ย้ายตามเส้นตรงจุดสุดท้าย |
| CurveTo | สาม | ตามเส้นโค้งคิวบิกที่กำหนดด้วยจุดควบคุมสองจุดและจุดสุดท้าย |
| CloseLoop | ไม่มี | กลับสู่ตำแหน่งเริ่มต้น |
| End | ไม่มี | สิ้นสุดเส้นทาง |

[MotionPathPointsType](https://reference.aspose.com/slides/th/java/com.aspose.slides/motionpathpointstype/) อธิบายคุณลักษณะการแก้ไขจุด เช่น จุดมุมหรือจุดเรียบ ไม่ได้แทนที่ประเภทคำสั่ง ใช้ประเภทจุดโค้งสำหรับตัวอย่างโค้งด้านล่าง และประเภทจุดมุมสำหรับส่วนตรง

พิกัดเส้นทางเป็นมาตรฐานตามขนาดสไลด์: การเลื่อน X 0.25 หมายถึงหนึ่งในสี่ของความกว้างสไลด์ ไม่ใช่ 0.25 จุด Y บวกคือทิศทางลง คำสั่งแบบ Absolute ระบุตำแหน่งในระบบพิกัดของเส้นทาง; คำสั่งแบบ Relative ระบุชดเชยจากตำแหน่งปัจจุบัน สิ่งนี้แยกจาก [getOrigin](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotioneffect/#getOrigin--) ที่เลือกกรอบอ้างอิงของเส้นทาง และ [getPathEditMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotioneffect/#getPathEditMode--) ที่ควบคุมการเคลื่อนที่ของเส้นทางเมื่อรูปร่างเคลื่อนที่

### **สร้างเส้นทางตรง**

สร้างพฤติกรรมการเคลื่อนที่ด้วยจุดเริ่มต้น, ส่วนตรงหนึ่งส่วน, และคำสั่งจบ [IMotionPath.add](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) รับประเภทคำสั่ง, จุดของมัน, ประเภทจุด, และแฟล็กพิกัดสัมพัทธ์

คำสั่งเริ่มต้นกำหนด (0, 0) และเส้นตรงจบที่ (0.25, 0) ทำให้เส้นทางมีการย้ายแนวนอนหนึ่งในสี่ของความกว้างสไลด์ คำสั่งจบไม่มีจุดพิกัด หลังจากกำหนดเส้นทางแล้ว การเพิ่มพฤติกรรมการเคลื่อนที่เข้าไปในเอฟเฟกต์จะเชื่อมเส้นทางนั้นกับสี่เหลี่ยม

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` มีพฤติกรรมการเคลื่อนที่หนึ่งรายการที่มีสามคำสั่งเส้นทาง ตัวอย่างการแก้ไขไฟล์ต่อไปใช้โครงสร้างนี้

### **เปรียบเทียบพิกัด Absolute กับ Relative**

อ็อบเจกต์เส้นทางสองอันนี้บรรยายเส้นทางเดียวกัน คำสั่ง Absolute จบที่ (0.3, 0.1); คำสั่ง Relative เพิ่ม (0.1, 0.1) ให้กับตำแหน่งปัจจุบัน (0.2, 0)

ทั้งสองเส้นทางเริ่มจากตำแหน่งเดียวกัน สำหรับเส้น Relative ให้บวกชดเชย X และ Y กับตำแหน่งปัจจุบันเพื่อให้ได้จุดสุดท้าย; สำหรับเส้น Absolute ให้ใช้จุดสุดท้ายโดยตรง การสลับแฟล็กโดยไม่แปลงพิกัดจะทำให้เส้นทางต่างกัน

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

กำหนดเส้นทางใดเส้นทางหนึ่งให้กับพฤติกรรมการเคลื่อนที่เพื่อใช้ในงานนำเสนอ อาร์กิวเมนต์ Boolean สุดท้ายเลือกพิกัดสัมพัทธ์สำหรับคำสั่งนั้น

### **แทนที่เส้นตรงด้วยโค้ง**

เปิด `motion.pptx` แล้วแทนที่คำสั่งเส้นตรงด้วยโค้งคิวบิก ใส่จุดควบคุมสองจุดแรก แล้วตามด้วยจุดสิ้นสุด

ตำแหน่งเริ่มต้นมาจากคำสั่งก่อนหน้า จุดสองจุดแรกกำหนดรูปร่างของโค้ง ส่วนจุดที่สามเป็นปลายทาง; ไม่ใช่สามจุดต่อเนื่อง การอัปเดตประเภทคำสั่ง, ประเภทจุด, และอาร์เรย์จุดพร้อมกันทำให้ส่วนเชื่อมต่อสอดคล้องกับเรขาคณิตใหม่

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เส้นทางใน `curve.pptx` ยังมีสามคำสั่ง; คำสั่งกลางตอนนี้เป็นโค้ง

## **ตรวจสอบและแก้ไขเส้นทางที่บันทึกไว้**

แต่ละ [IMotionCmdPath](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotioncmdpath/) เปิดให้เข้าถึง [getPoints](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotioncmdpath/#getPointsType--), และ [isRelative](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotioncmdpath/#isRelative--) ตัวอย่างต่อไปใช้เส้นทางที่มีสามคำสั่งใน `motion.pptx` สำหรับอินพุตใด ๆ ให้ค้นหาเอฟเฟกต์ที่ต้องการและตรวจสอบประเภทคำสั่งและจำนวนจุดก่อนแก้ไขโดยดัชนี

### **อ่านคำสั่งและพิกัด**

อ่านเส้นทางโดยไม่เปลี่ยนแปลง คำสั่ง End และ CloseLoop ไม่ต้องการจุด ดังนั้นควรรองรับอาร์เรย์จุดเป็น null

ผลลัพธ์แสดงคู่ของประเภทคำสั่งเชิงตัวเลขกับแฟล็กพิกัดสัมพัทธ์ก่อนแสดงจุดของมัน ช่วยให้คุณแยกจุดปลายจากการชดเชยก่อนแก้ไขเส้นทาง โค้งจะมีสามจุด ส่วนเส้นตรงในไฟล์นี้มีเพียงหนึ่งจุด

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

รายการนี้มีจุดเริ่มต้น, เส้นตรง Absolute ที่จบที่ (0.25, 0), และคำสั่ง End

### **เปลี่ยนจุดปลาย**

เปิด `motion.pptx` แล้วแทนที่อาร์เรย์จุดของเส้นเพื่อย้ายจุดปลาย

ในไฟล์อินพุต ดัชนี 0 คือคำสั่งเริ่มต้น ดัชนี 1 คือเส้น การแทนที่จุดเดียวของเส้นจะเปลี่ยนปลายทางโดยไม่กระทบประเภทคำสั่ง, เวลา, หรือสถานะในคอลเลกชัน เพราะคำสั่งใช้พิกัด Absolute ค่าคู่ใหม่จะระบุตำแหน่งแทนการเพิ่มชดเชย

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เส้นใน `motion-endpoint.pptx` จบที่ (0.4, 0.1); ไฟล์ต้นฉบับไม่มีการเปลี่ยนแปลง

### **แทนที่ส่วน**

ใช้ [insert](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) และ [removeAt](https://reference.aspose.com/slides/th/java/com.aspose.slides/imotionpath/#removeAt-int-) เพื่อแทนที่เส้นใน `motion.pptx` การแทรกทำให้เส้นเดิมย้ายไปยังดัชนี 2

นี่คือการแทนที่วัตถุคำสั่งแทนการแก้ไขพิกัดเดิม หลังจากแทรก คอลเลกชันอาจมีคำสั่งเริ่มต้น, เส้นใหม่, เส้นเก่า, และคำสั่ง End ชั่วคราว การลบดัชนี 2 จะทิ้งเส้นเก่าและเหลือเส้นใหม่ในตำแหน่ง

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เส้นทางที่บันทึกยังคงมีสามคำสั่ง, เส้นใหม่จบที่ (0.2, 0.1) และคำสั่ง End อยู่สุดท้าย

## **แก้ไขและตรวจสอบพฤติกรรมที่มีอยู่**

เมื่อไม่ทราบดัชนีพฤติกรรม ให้เลือกตามประเภท ตัวอย่างนี้เปิด `rotation.pptx`, หาตัว [IRotationEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/irotationeffect/), เปลี่ยนมุม, แล้วตรวจสอบค่าที่บันทึกหลังจากเปิดใหม่

การตรวจสอบประเภททำให้ลูปข้ามพฤติกรรมที่ไม่ใช่การหมุน การโหลดครั้งที่สองอ่านไฟล์ที่บันทึกลงในออบเจกต์งานนำเสนอแยกต่างหาก ทำให้การเปรียบเทียบตรวจสอบข้อมูลที่คงอยู่จริง ไม่ใช่ค่าที่ยังคงอยู่ในหน่วยความจำ ตัวอย่างยังคงสมมติว่าเอฟเฟกต์ที่รู้จักอยู่เป็นรายการแรกในซีเควนส์หลัก; การเลือกพฤติกรรมตามประเภทอาจไม่พบเอฟเฟกต์ที่ถูกต้องในงานนำเสนอใด ๆ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์คือ `Rotation preserved: true` ใช้รูปแบบตรวจสอบประเภทเดียวกันกับพฤติกรรมอื่น ๆ เพื่อทำการตรวจสอบการคงสภาพอย่างครบถ้วน ให้เปรียบเทียบรูปร่างเป้าหมาย, เอฟเฟกต์, ประเภทและลำดับพฤติกรรม, เวลา, และคำสั่งเส้นทาง ใช้ความคลาดเคลื่อนเชิงตัวเลขสำหรับค่าตัวเลขที่เป็นฟลอต สำหรับงานนำเสนอที่มีโครงสร้างการเคลื่อนไหวไม่ทราบ ให้ดูที่ [อ่านการเคลื่อนไหวของรูปทรง](/slides/th/java/shape-animation/#read-shape-animations) เพื่อทริเวอร์สผ่านซีเควนส์หลักและเชิงโต้ตอบ

## **ลำดับพฤติกรรม, พรีเซ็ต, และการเล่น**

ลำดับใน [IBehaviorCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehaviorcollection/) คือลำดับที่จัดเก็บของการดำเนินการเอฟเฟกต์ ไม่ใช่เพลย์ลิสต์ที่พฤติกรรมทุกอย่างต้องรอคำสั่งก่อนหน้า เวลาและเอฟเฟกต์ที่ครอบคลุมกำหนดการจัดตาราง พฤติกรรมอาจทับซ้อนกันและการดำเนินการบนแอตทริบิวต์เดียวกันอาจโต้ตอบผ่าน [getAdditive](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehavior/#getAdditive--) และ [getAccumulate](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibehavior/#getAccumulate--) อย่าใช้การจัดลำดับคอลเลกชันอย่างเดียวเพื่อกำหนด “ย้ายแล้วหมุน” ให้ใช้เวลาอย่างชัดเจนหรือเอฟเฟกต์แยกตามที่อธิบายใน [การเคลื่อนไหวของรูปร่าง](/slides/th/java/shape-animation/)

[getType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getType--) และ [getSubtype](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#getSubtype--) ของเอฟเฟกต์บรรยายพรีเซ็ต ไม่ได้อธิบายต้นไม้พฤติกรรมที่แก้ไขอย่างครบถ้วน เลือกพรีเซ็ตและประเภทย่อยก่อนปรับพฤติกรรม: การเปลี่ยนพรีเซ็ตอาจสร้างคอลเลกชันใหม่และลบการดำเนินการที่กำหนดเองของคุณ ตัวอย่างเช่น การเปลี่ยนเอฟเฟกต์ Spin ที่กำหนดเองเป็น Fade อาจแทนที่พฤติกรรมการหมุนด้วยพฤติกรรม set และ filter ตรวจสอบคอลเลกชันอีกครั้งหลังจากเปลี่ยนพรีเซ็ตหรือประเภทย่อย การล้างพฤติกรรมพรีเซ็ตอาจลบการดำเนินการการมองเห็นหรือการเริ่มต้นที่พรีเซ็ตต้องการ ตัวอย่างใช้รูปร่างที่มองเห็นและแทนที่พฤติกรรม ไม่ได้สร้างต้นแบบของพรีเซ็ตทั้งหมดใหม่

## **ความเข้ากันได้ของฟอร์แมต**

ต้นไม้พฤติกรรมที่คงไว้ ไม่ได้รับประกันการเล่นที่เหมือนกันในทุกตัวดูหรือเรนเดอร์เอาต์พุต ตรวจสอบข้อมูลที่บันทึกและผลลัพธ์ที่เรนเดอร์แยกกัน

| ฟอร์แมตหรือเอาต์พุต | สิ่งที่ต้องตรวจสอบ |
| --- | --- |
| PPTX | ใช้เป็นฟอร์แมตหลักสำหรับตัวอย่างเหล่านี้ เปิดใหม่เพื่อยืนยันต้นไม้พฤติกรรมที่แก้ไขได้ แล้วตรวจสอบการเล่นในเวอร์ชัน PowerPoint ที่ต้องการ |
| PPT | ตัวแทนไบนารีเก่าอาจแตกต่างจาก PPTX ทดสอบวงจรบันทึก‑เปิด‑ใหม่และการเล่น; อย่าอนุมานว่ารองรับทุกการผสมผสานแบบกำหนดเองจากผลลัพธ์ PPTX เพียงอย่างเดียว |
| PDF, PNG, JPEG และรูปภาพสไลด์คงที่อื่น ๆ | เป็นการแสดงสไลด์แบบคงที่ ไม่ใช่ไทม์ไลน์พฤติกรรมที่เล่นได้หรือเฟรมแอนิเมชั่นสุดท้ายที่รับประกัน |
| [HTML5](/slides/th/java/export-to-html5/) | สามารถเล่นการเคลื่อนไหวที่รองรับได้เมื่อเปิดใช้การเคลื่อนไหวของรูปร่างในตัวเลือกการส่งออก ทดสอบการผสมผสานกำหนดเองในเบราว์เซอร์ |
| [Animated GIF](/slides/th/java/convert-powerpoint-to-animated-gif/) | เก็บเฟรมที่เรนเดอร์ ไม่ใช่พฤติกรรมที่แก้ไขได้หรือการโต้ตอบตามคลิก ตรวจสอบการเคลื่อนไหวที่เรนเดอร์จริง |
| [Video](/slides/th/java/convert-powerpoint-to-video/) | เรนเดอร์เฟรมแอนิเมชั่นและเข้ารหัสเป็นวิดีโอ การรองรับจำกัดตาม [การเคลื่อนไหวและเอฟเฟกต์ที่รองรับ](/slides/th/java/convert-powerpoint-to-video/#supported-animations-and-effects) คำสั่งและเหตุการณ์เชิงโต้ตอบจะไม่กลายเป็นไทม์ไลน์ที่แก้ไขได้ |

## **คำถามที่พบบ่อย**

**ทำไมเอฟเฟกต์ของฉันจึงมีพฤติกรรมอยู่ก่อนที่ฉันจะเพิ่มอะไรเข้าไป?**

การสร้างเอฟเฟกต์ที่กำหนดล่วงหน้าอาจสร้างการดำเนินการภายในของมัน ตรวจสอบก่อนตัดสินใจว่าจะขยายพรีเซ็ตหรือแทนที่พฤติกรรม

**การย้ายพฤติกรรมไปยังจุดเริ่มต้นทำให้มันเล่นก่อนหรือไม่?**

ไม่จำเป็น คอลเลกชันไม่ได้แทนที่เวลา ตรวจสอบความหน่วง, ระยะเวลา, และการโต้ตอบระหว่างการดำเนินการบนแอตทริบิวต์เดียวกัน

**ทำไมคำสั่ง End ไม่มีจุด?**

มันทำเครื่องหมายจบเส้นทางและไม่ต้องการพิกัด ตรวจสอบอาร์เรย์จุดเป็น null เมื่ออ่านเส้นทางจากไฟล์

**การรอบรอบสำเร็จถือว่าพอสำหรับยืนยันการเล่นหรือไม่?**

ไม่ การเปิดใหม่ยืนยันการคงสภาพของคุณสมบัติที่ตรวจสอบเท่านั้น ต้องทดสอบตัวเล่นสไลด์หรือการส่งออกแอนิเมชั่นแยกต่างหากเพื่อยืนยันพฤติกรรมแบบภาพจริง
---
title: สร้างและแก้ไขพฤติกรรมแอนิเมชันแบบกำหนดเองบน Android
linktitle: แอนิเมชันแบบกำหนดเอง
type: docs
weight: 151
url: /th/androidjava/custom-animation/
keywords:
- แอนิเมชันแบบกำหนดเอง
- พฤติกรรมแอนิเมชัน
- เส้นทางการเคลื่อนที่
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้าง ตรวจสอบ และแก้ไขพฤติกรรมแอนิเมชันแบบกำหนดเองและเส้นทางการเคลื่อนที่ที่แก้ไขได้ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

พฤติกรรมแอนิเมชันแบบกำหนดเองช่วยให้คุณควบคุมการดำเนินการแต่ละอย่างภายในผลลัพธ์แอนิเมชัน เช่น การเปลี่ยนสี การหมุนรูปร่าง หรือการติดตามเส้นทางการเคลื่อนที่ที่สามารถแก้ไขได้ คู่มือนี้จะแสดงวิธีสร้างและรวมพฤติกรรม ตั้งค่าเวลาของพวกมัน ตรวจสอบและแก้ไขแอนิเมชันที่มีอยู่ และยืนยันว่าคุณสมบัติเหล่านั้นยังคงอยู่หลังการบันทึกและเปิดพรีเซนเทชันใหม่

สำหรับเอฟเฟกต์ที่กำหนดล่วงหน้าและทริกเกอร์การคลิก ดูที่ [แอนิเมชันรูปร่าง](/slides/th/androidjava/shape-animation/)

## **ทำความเข้าใจแบบจำลองแอนิเมชัน**

แอนิเมชันถูกจัดระเบียบเป็น **Timeline → Sequence → Effect → Behaviors**:

- เมธอด [getTimeline](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) คืนค่าไทม์ไลน์ของสไลด์ ซึ่งรวมลำดับหลักและลำดับเชิงโต้ตอบ
- [ISequence](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/) มีเอฟเฟกต์ต่าง ๆ ซึ่งอาจกำหนดเป้าหมายเป็นรูปร่างที่แตกต่างกัน
- [IEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/) ระบุรูปร่างเป้าหมาย, พรีเซ็ต, ชนิดย่อย, และเวลาของเอฟเฟกต์
- คอลเลกชันที่คืนค่าจาก [IEffect.getBehaviors](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getBehaviors--) มีการดำเนินการที่ทำให้เอฟเฟกต์ทำงาน: การเปลี่ยนสี, การเคลื่อนที่, การหมุน, การตั้งค่าคุณสมบัติ ฯลฯ

## **สร้างพฤติกรรมแต่ละรายการ**

เรียกใช้ [ISequence.addEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) เพื่อสร้างเอฟเฟกต์และเข้าถึงคอลเลกชัน [getBehaviors](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getBehaviors--) พรีเซ็ตสามารถเติมคอลเลกชันนี้โดยอัตโนมัติ คงการดำเนินการของพรีเซ็ตไว้เมื่อต่อขยายพรีเซ็ต, หรือใช้ [clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) หากต้องการแทนที่โดยเจตนา

[IBehaviorFactory](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorfactory/) สร้างพฤติกรรมประเภทแปดแบบที่แสดงด้านล่าง การเคลื่อนที่จะอธิบายในส่วน [สร้างเส้นทางการเคลื่อนที่](#build-a-motion-path) ตัวอย่างแต่ละส่วนจะรวมการนำเข้า; ให้วางคำสั่งที่ทำงานได้ภายในเมธอด ตัวอย่างการแก้ไขต่อมาจะระบุว่าใช้ไฟล์ผลลัพธ์ใด สำหรับ Android ให้แทนที่ชื่อไฟล์ตัวอย่างด้วยเส้นทางเต็มในไดเรกทอรีที่แอปเข้าถึงได้ เช่นไดเรกทอรี files ของแอป

### **การหมุน**

ใช้ [createRotationEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) เพื่อสร้างการหมุน [getBy](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/irotationeffect/#getBy--) ระบุมุมสัมพัทธ์เป็นองศา; [getFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/irotationeffect/#getFrom--) และ [getTo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/irotationeffect/#getTo--) กำหนดจุดสิ้นสุด

ตัวอย่างเริ่มด้วยเอฟเฟกต์ Spin, แทนที่การดำเนินงานพรีเซ็ตด้วยพฤติกรรมการหมุนหนึ่งรายการ และตั้งระยะเวลาของการดำเนินการนั้นเป็นสองวินาที มุมสัมพัทธ์ 90 องศาแสดงการหมุนหนึ่งไตรมาสจากทิศทางเริ่มต้นของรูปร่าง ดังนั้นจึงไม่จำเป็นต้องกำหนดมุมเริ่มต้นอย่างชัดเจน

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

`rotation.pptx` มีรูปร่างหนึ่งและพฤติกรรมการหมุนหนึ่งคอลเลกชัน เวลา และตัวอย่างการแก้ไขการหมุนด้านล่างใช้ไฟล์นี้

### **การปรับขนาด**

ใช้ [createScaleEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) พร้อมเปอร์เซ็นต์ X/Y: [getFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) และ [getTo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iscaleeffect/#getTo--) ระบุขนาดเริ่มต้นและสิ้นสุด, ขณะที่ [getBy](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iscaleeffect/#getBy--) ระบุการเปลี่ยนแปลงสัมพัทธ์ ที่นี่ 100 หมายถึงขนาดต้นฉบับ

ตัวอย่างขยายมิติทั้งสองจาก 100% ไปเป็น 125% ในสองวินาที การใช้เปอร์เซ็นต์แนวนอนและแนวตั้งเท่ากันทำให้รูปร่างรักษาสัดส่วน; หากเปอร์เซ็นต์ต่างกันรูปร่างจะยืดในมิติหนึ่งมากกว่ามิติอื่น

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **สี**

ใช้ [createColorEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) เพื่อเปลี่ยนสีเติมจากสีน้ำเงินเป็นสีส้ม [getFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icoloreffect/#getFrom--) และ [getTo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icoloreffect/#getTo--) เป็นสี; [getBy](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icoloreffect/#getBy--) เป็นการปรับสีออฟเซ็ต [IBehavior.getProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehavior/#getProperties--) ระบุแอตทริบิวต์ที่กำลังแอนิเมต

การเติมสีทึบของรูปร่างเริ่มต้นด้วยสีน้ำเงินเพื่อให้ตรงกับสีเริ่มต้นของแอนิเมชัน การเลือกแอตทริบิวต์สีเติมบอกพฤติกรรมว่าต้องเปลี่ยนส่วนใดของรูปร่าง; จุดสิ้นสุดของสีเพียงอย่างเดียวไม่สามารถระบุแอตทริบิวต์นั้นได้ เอฟเฟกต์ที่บันทึกไว้บรรยายการเปลี่ยนเป็นสีส้มในสองวินาที

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filter**

ใช้ [createFilterEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) เพื่อเลือกการลบล้าง [getType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), และ [getReveal](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) ระบุฟิลเตอร์, ทิศทาง, และว่าจะเปิดเผยหรือซ่อนรูปร่าง

ตัวอย่างนี้กำหนดการลบล้างสองวินาทีที่เปิดเผยรูปร่างโดยใช้ชนิดย่อยทิศทางขวา การตั้งค่าฟิลเตอร์เป็นส่วนของพฤติกรรมภายในเอฟเฟกต์ ดังนั้นจึงตั้งค่าหลังจากเอฟเฟกต์พรีเซ็ตเดิมถูกลบออกแล้ว

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

### **Property**

ใช้ [createPropertyEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) เพื่อแอนิเมตความโปร่งใส [getFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), และ [getBy](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) เป็นสตริงที่ตีความด้วย [getValueType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) และ [getCalcMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--) เลือกจุดสิ้นสุดหรือออฟเซ็ตสัมพัทธ์แทนการตั้งค่าทั้งสามพร้อมกันโดยไม่ได้คัดเลือก

ในตัวอย่างนี้แอตทริบิวต์ที่เลือกคือความโปร่งใส และสตริงตัวเลขแสดงการเปลี่ยนจากความโปร่งใส 25% ไปเป็นความโปร่งใสเต็ม การไลเนียร์อินเทอร์โพเลชันบรรยายการเปลี่ยนอย่างค่อยเป็นค่อยไประหว่างค่าทั้งสอง เมื่อปรับใช้ตัวอย่างนี้กับแอตทริบิวต์อื่น ให้เลือกชนิดค่าและค่าจุดสิ้นสุดที่เหมาะสมกับแอตทริบิวต์นั้น

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

### **Set**

ใช้ [createSetEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) เพื่อกำหนดการมองเห็นผ่าน [getTo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iseteffect/#getTo--) พฤติกรรม set จะไม่ทำการอินเทอร์โพเลตระหว่างจุดปลาย

ตัวอย่างเลือกแอตทริบิวต์การมองเห็นและกำหนดสตริง `visible` เมื่อพฤติกรรมทำงาน สี่เหลี่ยมผืนผ้าในตัวอย่างนี้มองเห็นอยู่แล้วจึงอาจไม่เห็นการเปลี่ยนแปลงที่ชัดเจน การดำเนินการเช่นนี้มีประโยชน์เมื่อเป็นส่วนของเอฟเฟกต์ที่ใหญ่กว่า ที่ควบคุมการซ่อนหรือแสดงรูปร่างในเวลาต่าง ๆ

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

### **Command**

ใช้ [createCommandEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) และกำหนด [getType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), และ [getShapeTarget](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--) วางไฟล์เสียง WAV ชื่อ `sample.wav` ไว้ในไดเรกทอรีทำงาน ตัวอย่างนี้ฝังไฟล์เสียงด้วย [addAudioFrameEmbedded](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) และแนบคำสั่งเล่นเข้าไปในเฟรมเสียง

เฟรมเสียงเป็นทั้งเป้าหมายของเอฟเฟกต์และของคำสั่ง การเชื่อมคำสั่งเล่นกับการบันทึกที่ฝังอยู่ทำให้คำสั่งทำงาน; สตริงคำสั่งเพียงอย่างเดียวไม่ระบุว่าจะควบคุมสื่อใด เอฟเฟกต์ตั้งค่าให้เริ่มเมื่อคลิกขณะสไลด์โชว์

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

การบันทึกเก็บคำสั่งไว้ใน `command.pptx`; ไม่ได้เล่นไฟล์เสียง การเล่นต้องใช้โปรแกรมสไลด์โชว์ที่รองรับคำสั่งและสื่อเป้าหมาย

## **จัดการคอลเลกชันพฤติกรรม**

[IBehaviorCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorcollection/) รองรับ [add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), และ [removeAt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-). ตัวอย่างนี้เปิด `rotation.pptx`, เพิ่มการปรับขนาด, ย้ายมันก่อนการหมุน, แล้วลบการหมุน การลบและแทรกออบเจกต์เดียวกันใหม่จะเปลี่ยนตำแหน่งที่เก็บโดยไม่สร้างสำเนา

ลำดับการแก้ไขจะเปลี่ยนคอลเลกชันจาก rotation–scale เป็น scale–rotation แล้วเป็น scale เท่านั้น ดัชนีอ้างอิงคอลเลกชันปัจจุบัน ดังนั้นการลบจะใช้ดัชนีใหม่ของการหมุนหลังการจัดลำดับใหม่ การวนลูปสุดท้ายยืนยันพฤติกรรมใดจะถูกบันทึก

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
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

ผลลัพธ์คือ `ScaleEffect`: เหลือการปรับขนาดเท่านั้น คำสั่งลำดับในคอลเลกชันไม่เป็นตัวกำหนดให้พฤติกรรมทำงานต่อเนื่องโดยอัตโนมัติ ให้ล้างคอลเลกชันเฉพาะเมื่อต้องแทนที่การดำเนินงานทั้งหมด

## **กำหนดเวลาพฤติกรรม**

[IBehavior.getTiming](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehavior/#getTiming--) เปิดเผย [ITiming](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/), แยกจาก [IEffect.getTiming](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getTiming--) เวลาเอฟเฟกต์กำหนดการทำงานของเอฟเฟกต์โดยรอบ; เวลาพฤติกรรมบรรยายการดำเนินการภายในเอฟเฟกต์นั้น

### **ตั้งค่าระยะเวลา, ความล่าช้า, การทำซ้ำ, และความเร่ง**

เปิด `rotation.pptx` และตั้งระยะเวลา ([getDuration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getDuration--)) และความล่าช้าทริกเกอร์ ([getTriggerDelayTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) เป็นวินาที จากนั้นกำหนดจำนวนครั้งทำซ้ำผ่าน [setRepeatCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getAccelerate--) และ [getDecelerate](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getDecelerate--) เป็นส่วนของระยะเวลา; รักษาผลรวมไม่เกิน 1

ไฟล์อินพุตคือไฟล์ที่สร้างในตัวอย่างการหมุน ซึ่งพฤติกรรมแรกเป็นการหมุน ตัวอย่างนี้เปลี่ยนเวลาเฉพาะของพฤติกรรมนั้น; มุม 90 องศายังคงอยู่ การแยกมุมและเวลาออกจากกันทำให้ปรับจังหวะได้ง่ายโดยไม่ต้องสร้างแอนิเมชันใหม่

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

พฤติกรรมใช้ระยะเวลาสองวินาที, ความล่าช้าครึ่งวินาที, และทำซ้ำ 3 ครั้ง 20% แรกและสุดท้ายของระยะเวลาถูกใช้สำหรับเร่งและชะลอ

นโยบายทำซ้ำอื่น ๆ รวมถึง [getRepeatDuration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), และ [getRepeatUntilNextClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--) ให้เลือกใช้นโยบายหนึ่งแทนการเปิดใช้งานทั้งหมดพร้อมกัน [getAutoReverse](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiming/#getAutoReverse--) จะเล่นแอนิเมชันถอยหลังหลังจากเล่นด้านหน้า การเร่งและชะลอใช้กับการเปลี่ยนแปลงต่อเนื่อง ไม่ใช่การกำหนดค่าตรงหรือคำสั่ง

## **สร้างเส้นทางการเคลื่อนที่**

ใช้ [createMotionEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) เพื่อสร้างการเคลื่อนที่ [getFrom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotioneffect/#getTo--), และ [getBy](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotioneffect/#getBy--) อธิบายพิกัดหรือออฟเซ็ตแบบเปอร์เซ็นต์ สำหรับเส้นทางที่แก้ไขได้ สร้าง [MotionPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/motionpath/) แล้วกำหนดด้วย [IMotionEffect.setPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotionpath/) เก็บคำสั่งเส้นทาง

[MotionCommandPathType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/motioncommandpathtype/) เลือกการดำเนินการ:

| คำสั่ง | จุด | ความหมาย |
| --- | --- | --- |
| MoveTo | One | กำหนดตำแหน่งเริ่มต้น |
| LineTo | One | เคลื่อนที่ตามส่วนตรงไปยังจุดปลาย |
| CurveTo | Three | ตามเส้นโค้งคิวบิกที่กำหนดโดยจุดควบคุมสองจุดและจุดปลาย |
| CloseLoop | None | กลับไปยังตำแหน่งเริ่มต้น |
| End | None | สิ้นสุดเส้นทาง |

[MotionPathPointsType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/motionpathpointstype/) อธิบายลักษณะการแก้ไขจุด เช่น จุดหัวมุมหรือจุดเรียบ ไม่ได้แทนที่ชนิดคำสั่ง ใช้ชนิดจุดโค้งสำหรับตัวอย่างโค้งด้านล่าง และใช้ชนิดจุดหัวมุมสำหรับส่วนตรง

พิกัดของเส้นทางได้รับการทำให้เป็นมาตรฐานตามขนาดสไลด์: การเลื่อน X ที่ 0.25 หมายถึงหนึ่งในสี่ของความกว้างสไลด์ ไม่ใช่ 0.25 พอยท์ Y บวกลงด้านล่าง คำสั่งแบบ absolute ระบุตำแหน่งในระบบพิกัดของเส้นทาง; คำสั่งแบบ relative ระบุออฟเซ็ตจากตำแหน่งปัจจุบัน สิ่งนี้แยกจาก [getOrigin](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotioneffect/#getOrigin--) ที่เลือกเฟรมอ้างอิงของเส้นทาง, และ [getPathEditMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--) ที่ควบคุมการเคลื่อนที่ของเส้นทางเมื่อรูปร่างเคลื่อนที่

### **สร้างเส้นทางตรง**

สร้างพฤติกรรมการเคลื่อนที่ด้วยจุดเริ่มต้น, ส่วนตรงหนึ่งส่วน, และคำสั่งจบ [IMotionPath.add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) รับชนิดคำสั่ง, จุดของมัน, ชนิดจุด, และแฟล็กพิกัดสัมพัทธ์

คำสั่งเริ่มต้นกำหนด (0, 0) และเส้นตรงจบที่ (0.25, 0) ให้เส้นทางเคลื่อนที่ตามแนวนอนหนึ่งในสี่ของความกว้างสไลด์ คำสั่งจบไม่มีจุดพิกัด เมื่อกำหนดเส้นทางแล้ว การเพิ่มพฤติกรรมการเคลื่อนที่เข้าไปในเอฟเฟกต์จะเชื่อมเส้นทางนั้นกับสี่เหลี่ยมผืนผ้า

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` มีพฤติกรรมการเคลื่อนที่หนึ่งที่มีคำสั่งเส้นทางสามคำสั่ง ตัวอย่างการแก้ไขไฟล์ต่อไปนี้ใช้โครงสร้างที่รู้จักนี้

### **เปรียบเทียบพิกัด Absolute และ Relative**

สองออบเจกต์เส้นทางนี้อธิบายเส้นทางเดียวกัน คำสั่ง absolute จบที่ (0.3, 0.1); คำสั่ง relative เพิ่ม (0.1, 0.1) ให้กับตำแหน่งปัจจุบัน (0.2, 0)

ทั้งสองเส้นทางเริ่มที่ตำแหน่งเดียวกัน สำหรับเส้นทาง relative ให้บวกออฟเซ็ต X และ Y กับตำแหน่งปัจจุบันเพื่อได้จุดปลาย; สำหรับเส้นทาง absolute ให้อ่านจุดปลายโดยตรง การสลับแฟล็กโดยไม่แปลงพิกัดจะทำให้เส้นทางต่างกัน

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

กำหนดเส้นทางใดเส้นทางหนึ่งให้กับพฤติกรรมการเคลื่อนที่เพื่อใช้ในพรีเซนเทชัน อาร์กิวเมนต์ Boolean สุดท้ายเลือกพิกัดสัมพัทธ์สำหรับคำสั่งนั้น

### **แทนที่เส้นตรงด้วยโค้ง**

เปิด `motion.pptx` และแทนที่คำสั่งเส้นตรงด้วยโค้งคิวบิก ให้ระบุจุดควบคุมสองจุดก่อน แล้วตามด้วยจุดปลาย

ตำแหน่งเริ่มต้นมาจากคำสั่งก่อนหน้า จุดสองแรกกำหนดรูปร่างของโค้ง ส่วนจุดที่สามเป็นจุดปลาย; ไม่ได้เป็นจุดปลายต่อเนื่องสามจุด การอัปเดตทั้งชนิดคำสั่ง, ชนิดการแก้ไขจุด, และอาเรย์จุดพร้อมกันทำให้ส่วนสอดคล้องกับรูปทรงใหม่

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เส้นทางใน `curve.pptx` ยังมีสามคำสั่ง; คำสั่งกลางตอนนี้เป็นโค้ง

## **ตรวจสอบและแก้ไขเส้นทางที่บันทึกไว้**

แต่ละ [IMotionCmdPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotioncmdpath/) เปิดเผย [getPoints](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), และ [isRelative](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--) ตัวอย่างต่อไปใช้เส้นทางสามคำสั่งที่รู้จักใน `motion.pptx` สำหรับข้อมูลเข้าแบบสุ่ม ให้ค้นหาเอฟเฟกต์ที่ต้องการและตรวจสอบชนิดคำสั่งและจำนวนจุดก่อนแก้ไขตามดัชนี

### **อ่านคำสั่งและพิกัด**

อ่านเส้นทางโดยไม่เปลี่ยนแปลง คำสั่ง End และ CloseLoop ไม่ต้องการจุด ดังนั้นต้องรองรับอาเรย์จุดที่เป็น null

ผลลัพธ์จับคู่ชนิดคำสั่งเชิงตัวเลขกับแฟล็กพิกัดสัมพัทธ์ก่อนแสดงรายการจุดของมัน ทำให้คุณแยกจุดสิ้นสุดจากออฟเซ็ตก่อนแก้ไขเส้นทาง คำสั่งโค้งจะแสดงสามจุด ส่วนเส้นตรงในไฟล์นี้จะแสดงเพียงหนึ่งจุด

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

รายการประกอบด้วยจุดเริ่มต้น, เส้นตรง absolute ที่จบที่ (0.25, 0), และคำสั่ง End

### **เปลี่ยนจุดสิ้นสุด**

เปิด `motion.pptx` และแทนที่อาเรย์จุดของเส้นเพื่อย้ายจุดสิ้นสุดของมัน

ในไฟล์อินพุต ดัชนี 0 คือคำสั่งเริ่มต้นและดัชนี 1 คือเส้น การแทนที่จุดเดียวของเส้นจะเปลี่ยนจุดหมายโดยไม่เปลี่ยนชนิดคำสั่ง, เวลา, หรือตำแหน่งในคอลเลกชัน เนื่องจากคำสั่งใช้พิกัด absolute คู่ใหม่จึงระบุตำแหน่งแทนการเพิ่มออฟเซ็ต

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เส้นใน `motion-endpoint.pptx` จบที่ (0.4, 0.1); ไฟล์ต้นฉบับไม่ได้เปลี่ยนแปลง

### **แทนที่ส่วน**

ใช้ [insert](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) และ [removeAt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) เพื่อแทนที่เส้นใน `motion.pptx` การแทรกทำให้เส้นเดิมย้ายไปที่ดัชนี 2

นี่เป็นการแทนที่ออบเจกต์คำสั่งแทนการแก้ไขพิกัดเดิม หลังจากแทรก คอลเลกชันจะมีคำสั่งเริ่มต้น, เส้นใหม่, เส้นเดิม, และคำสั่ง End ชั่วคราว การลบดัชนี 2 จะลบเส้นเดิมและทำให้เส้นใหม่คงอยู่

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เส้นที่บันทึกยังคงมีสามคำสั่ง, เส้นใหม่จบที่ (0.2, 0.1) และคำสั่ง End อยู่เป็นคำสั่งสุดท้าย

## **แก้ไขและตรวจสอบพฤติกรรมที่มีอยู่**

เมื่อไม่ทราบดัชนีพฤติกรรม ให้เลือกตามชนิด ตัวอย่างนี้เปิด `rotation.pptx`, หา [IRotationEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/irotationeffect/), เปลี่ยนมุม, แล้วตรวจสอบค่าที่บันทึกหลังเปิดใหม่

การตรวจสอบชนิดทำให้ลูปข้ามพฤติกรรมที่ไม่ใช่การหมุน การโหลดครั้งที่สองอ่านไฟล์ที่บันทึกลงในออบเจกต์พรีเซนเทชันแยกต่างหาก ทำให้การเปรียบเทียบตรวจสอบข้อมูลที่คงอยู่จริง ไม่ใช่ค่าที่ยังคงอยู่ในหน่วยความจำ ตัวอย่างนี้ยังคงสมมติว่าเอฟเฟกต์ที่รู้จักอยู่เป็นรายการแรกในลำดับหลัก; การเลือกพฤติกรรมตามชนิดไม่รับประกันว่าจะเจอเอฟเฟกต์ที่ต้องการในพรีเซนเทชันใด ๆ

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

ผลลัพธ์คือ `Rotation preserved: true` ใช้รูปแบบการตรวจสอบชนิดเดียวกันกับพฤติกรรมอื่น ๆ สำหรับการตรวจสอบการคงที่อย่างสมบูรณ์ ให้เปรียบเทียบรูปร่างเป้าหมาย, เอฟเฟกต์, ชนิดและลำดับพฤติกรรม, เวลา, และคำสั่งเส้นทาง ใช้ความทนทานเชิงตัวเลขสำหรับค่าจุดทศนิยม สำหรับพรีเซนเทชันที่มีโครงสร้างแอนิเมชันไม่ทราบ ดูที่ [อ่านแอนิเมชันรูปร่าง](/slides/th/androidjava/shape-animation/#read-shape-animations) เพื่อท่องลำดับหลักและลำดับเชิงโต้ตอบ

## **ลำดับพฤติกรรม, พรีเซ็ต, และการเล่น**

ลำดับใน [IBehaviorCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehaviorcollection/) คือลำดับที่จัดเก็บของการดำเนินงานเอฟเฟกต์ ไม่ใช่เพลย์ลิสต์ที่พฤติกรรมแต่ละรายการรอคอยอัตโนมัติก่อนรายการก่อนหน้า เวลาและเอฟเฟกต์ที่ห่อหุ้มกำหนดการจัดเวลา พฤติกรรมสามารถซ้อนทับกันได้, และการดำเนินงานบนคุณสมบัติเ�เดียวกันอาจโต้ตอบกันผ่าน [getAdditive](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehavior/#getAdditive--) และ [getAccumulate](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibehavior/#getAccumulate--) อย่าใช้การจัดลำดับคอลเลกชันอย่างเดียวเพื่อกำหนดให้ “ย้ายแล้วหมุน”; ให้ใช้เวลาโดยชัดเจนหรือเอฟเฟกต์แยกตามที่อธิบายใน [แอนิเมชันรูปร่าง](/slides/th/androidjava/shape-animation/)

พรีเซ็ตของเอฟเฟกต์ [getType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getType--) และ [getSubtype](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#getSubtype--) ระบุพรีเซ็ตนั้น ไม่ได้เป็นคำอธิบายเต็มของต้นไม้พฤติกรรมที่แก้ไขแล้ว เลือกพรีเซ็ตและชนิดย่อยก่อนปรับแต่งพฤติกรรม: การเปลี่ยนพรีเซ็ตอาจสร้างคอลเลกชันใหม่และลบการดำเนินการกำหนดเองของคุณ การเปลี่ยน Spin ที่กำหนดเองเป็น Fade จะเปลี่ยนพฤติกรรมการหมุนเป็นพฤติกรรม set และ filter ตรวจสอบคอลเลกชันอีกครั้งหลังเปลี่ยนพรีเซ็ตหรือชนิดย่อย การลบพฤติกรรมพรีเซ็ตอาจทำให้การมองเห็นหรือการตั้งค่าเริ่มต้นที่พรีเซ็ตต้องการหายไป ตัวอย่างใช้รูปร่างที่มองเห็นและแทนที่พฤติกรรม; ไม่ได้สร้างต้นไม้พรีเซ็ตทั้งหมดใหม่

## **ความเข้ากันได้ของฟอร์แมต**

ต้นไม้พฤติกรรมที่คงที่ไม่ได้รับประกันการเล่นเดียวกันในทุกโปรแกรมดูหรือเรนเดอร์เอาต์พุต ตรวจสอบข้อมูลที่บันทึกและผลลัพธ์ที่เรนเดอร์แยกกัน

| ฟอร์แมตหรือผลลัพธ์ | สิ่งที่ต้องตรวจสอบ |
| --- | --- |
| PPTX | ใช้เป็นฟอร์แมตหลักสำหรับตัวอย่างนี้ เปิดใหม่เพื่อยืนยันต้นไม้พฤติกรรมที่แก้ไขได้ แล้วตรวจสอบการเล่นในเวอร์ชัน PowerPoint ที่ต้องการ |
| PPT | ตัวแทนไบนารีแบบเก่าอาจแตกต่างจาก PPTX ทดสอบการบันทึก–เปิดใหม่และการเล่นแยกกัน; อย่าอนุมานการสนับสนุนทุกการผสมผสานจากผลลัพธ์ PPTX ที่สำเร็จ |
| PDF, PNG, JPEG, และภาพสไลด์คงที่อื่น ๆ | มีการแสดงสไลด์แบบคงที่ ไม่ใช่ไทม์ไลน์พฤติกรรมที่เล่นได้หรือเฟรมแอนิเมชันสุดท้ายที่รับประกัน |
| [HTML5](/slides/th/androidjava/export-to-html5/) | สามารถเล่นแอนิเมชันที่รองรับเมื่อเปิดใช้งานแอนิเมชันรูปร่างในตัวเลือกการส่งออก ทดสอบการผสมผสานแบบกำหนดเองในเบราว์เซอร์ |
| [Animated GIF](/slides/th/androidjava/convert-powerpoint-to-animated-gif/) | เก็บเฟรมที่เรนเดอร์ ไม่ใช่พฤติกรรมแก้ไขได้หรือการโต้ตอบที่ทำโดยคลิก ตรวจสอบการเคลื่อนที่ที่เรนเดอร์จริง |
| [Video](/slides/th/androidjava/convert-powerpoint-to-video/) | เรนเดอร์เฟรมแอนิเมชันและเข้ารหัสเป็นวิดีโอ การสนับสนุนจำกัดอยู่ที่ [แอนิเมชันและเอฟเฟกต์ที่รองรับ](/slides/th/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects); คำสั่งและเหตุการณ์เชิงโต้ตอบจะไม่กลายเป็นไทม์ไลน์แก้ไขได้ |

## **คำถามที่พบบ่อย**

**ทำไมเอฟเฟกต์ของฉันถึงมีพฤติกรรมก่อนที่ฉันจะเพิ่มอะไรเลย?**

การสร้างเอฟเฟกต์ที่กำหนดล่วงหน้าอาจสร้างการดำเนินงานพื้นฐาน ตรวจสอบมันก่อนตัดสินใจว่าจะขยายพรีเซ็ตหรือแทนที่พฤติกรรม

**การย้ายพฤติกรรมไปยังจุดเริ่มต้นทำให้มันเล่นก่อนหรือไม่?**

ไม่จำเป็นลำดับคอลเลกชันไม่ใช่การแทนที่เวลา ตรวจสอบความล่าช้า, ระยะเวลา, และการโต้ตอบระหว่างการดำเนินงานบนคุณสมบัติเ�เดียวกัน

**ทำไมคำสั่ง End ถึงไม่มีจุด?**

มันระบุจบของเส้นทางและไม่ต้องการพิกัด ตรวจสอบอาเรย์จุดที่เป็น null เมื่อ inspe​ct เส้นทางจากไฟล์

**การวนรอบสำเร็จถือพอที่จะยืนยันการเล่นหรือไม่?**

ไม่ การเปิดใหม่ยืนยันว่าคุณสมบัติเ�ที่ตรวจสอบคงอยู่ ต้องทดสอบโปรแกรมสไลด์โชว์หรือการส่งออกแบบแอนิเมชันแยกกันเพื่อยืนยันพฤติกรรมภาพที่เห็น
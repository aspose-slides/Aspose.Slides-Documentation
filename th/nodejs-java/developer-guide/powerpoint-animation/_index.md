---
title: "เพิ่มประสิทธิภาพการนำเสนอ PowerPoint ด้วยการเคลื่อนไหวใน JavaScript"
linktitle: "การเคลื่อนไหว PowerPoint"
type: docs
weight: 150
url: /th/nodejs-java/powerpoint-animation/
keywords:
- "เพิ่มการเคลื่อนไหว"
- "อัปเดตการเคลื่อนไหว"
- "เปลี่ยนการเคลื่อนไหว"
- "ลบการเคลื่อนไหว"
- "จัดการการเคลื่อนไหว"
- "ควบคุมการเคลื่อนไหว"
- "เอฟเฟกต์การเคลื่อนไหว"
- "การเคลื่อนไหว PowerPoint"
- "ไทม์ไลน์การเคลื่อนไหว"
- "การเคลื่อนไหวแบบโต้ตอบ"
- "การเคลื่อนไหวแบบกำหนดเอง"
- "การเคลื่อนไหวของรูปร่าง"
- "แผนภูมิที่เคลื่อนไหว"
- "ข้อความที่เคลื่อนไหว"
- "รูปร่างที่เคลื่อนไหว"
- "วัตถุ OLE ที่เคลื่อนไหว"
- "ภาพที่เคลื่อนไหว"
- "ตารางที่เคลื่อนไหว"
- "PowerPoint"
- "การนำเสนอ"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "ใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อจัดการการเคลื่อนไหวของ PowerPoint ภาพรวมนี้เน้นคุณสมบัติหลักและให้ข้อมูลเชิงลึกเพื่อปรับปรุงการนำเสนอของคุณ"
---
## **บทนำ**

เนื่องจากการนำเสนอมีจุดประสงค์เพื่อแสดงข้อมูล ลักษณะภาพและพฤติกรรมเชิงโต้ตอบจึงถูกพิจารณาตลอดการสร้าง

**PowerPoint animation** plays an important role in order to make presentation eye-catching and attractive for the viewers. Aspose.Slides for Node.js via Java offers a wide range of options to add animation to PowerPoint presentation:

- apply various types of PowerPoint animation effects on shapes, charts, tables, OLE Objects and other presentation elements.
- use multiple PowerPoint animation effects on a shape.
- use animation timeline to control animation effects.
- create custom animation.

In Aspose.Slides for Node.js via Java, various animations effects can be applied on the shapes. As every element on the slide including text, pictures, OLE Object, table etc is considered as a shape, it means we can apply animation effect on every element of a slide.

## **เอฟเฟกต์การเคลื่อนไหว**
Aspose.Slides supports **150+ animation effects**, including basic animation effects like Bounce, PathFootball, Zoom effect and specific animation effects as OLEObjectShow, OLEObjectOpen. You can find a full listing of animation effects in [**EffectType**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effecttype/) enumeration.

Additionally, these animation effects can be used in combination with them:

- [ColorEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SetEffect)

## **การเคลื่อนไหวแบบกำหนดเอง**
It is possible to create your own **custom animations** in Aspose.Slides. 
This can be achieved if you combine several behaviours together into a new custom animation.

[**Behavior**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Behavior) is a building unit of any PowerPoint animation effect. All animation effects are actually a set of behaviours composed into one strategy. You can combine behaviours into a custom animation once and reuse it in other presentations. If you add a new behaviour into a standard PowerPoint animation effect - it will be another custom animation. For example, you can add repeat behaviour to an animation to make it repeat a few times.

[**Animation Point**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Point) is a point where behaviour should be applied.

## **ไทม์ไลน์การเคลื่อนไหว**
[**Sequence**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Sequence) is a collection of animation effects, applied on a concrete shape.

[**Timeline**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AnimationTimeLine) is a set of Sequences used in a concrete slide. It is an animation engine represented since PowerPoint 2002. In previous Powerpoint versions, it was challenging to add animation effects to presentation, which could be achieved only with different workarounds. Timeline comes to replace on old AnimationSettings class and provide more clear object model for PowerPoint animation. One slide can have only one animation timeline.

## **การเคลื่อนไหวแบบโต้ตอบ**
[**Trigger**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/EffectTriggerType) allows to define user actions (e.g. button click), that will make a certain animation start. Triggers have been added into the latest PowerPoint version only.

## **การเคลื่อนไหวของรูปร่าง**
Aspose.Slides allows to apply animation to shapes, that can be actually text, rectangle, line, frame, OLE Object, etc.

{{% alert color="primary" %}} 
Read more [**เกี่ยวกับการเคลื่อนไหวของรูปร่าง**](/slides/th/nodejs-java/shape-animation/).
{{% /alert %}}

## **แผนภูมิที่เคลื่อนไหว**
To create animated charts, you should use all the same classes as for the shapes. However, it is possible to use PowerPoint animation only on chart categories or chart series. You can also apply animation effect to a category element or series element.

{{% alert color="primary" %}} 
Read more [**เกี่ยวกับแผนภูมิที่เคลื่อนไหว**](/slides/th/nodejs-java/animated-charts/).
{{% /alert %}}

## **ข้อความที่เคลื่อนไหว**
Except animated text, it is also possible to apply animation to a paragraph.

{{% alert color="primary" %}} 
Read more [**เกี่ยวกับข้อความที่เคลื่อนไหว**](/slides/th/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Will animations be preserved when exporting to PDF?**

No. PDF is a static format, so animations and [slide transitions](/slides/th/nodejs-java/slide-transition/) don’t play. If you need motion, export to [HTML5](/slides/th/nodejs-java/export-to-html5/), [animated GIF](/slides/th/nodejs-java/convert-powerpoint-to-animated-gif/), or [video](/slides/th/nodejs-java/convert-powerpoint-to-video/) instead.

**Can I turn an animated presentation into a video and control the frame rate and frame size?**

Yes. You can [render the presentation as frames](/slides/th/nodejs-java/convert-powerpoint-to-video/) and encode them into a video (e.g., via ffmpeg), choosing the FPS and resolution. Animations and slide transitions are played during rendering.

**Will animations remain intact when working with ODP (not just PPTX)?**

PPT, PPTX, and ODP are supported for [reading](/slides/th/nodejs-java/open-presentation/) and [writing](/slides/th/nodejs-java/save-presentation/), but format differences mean certain effects may look or behave slightly differently. Validate critical cases with real samples.
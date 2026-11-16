---
title: ดึงและอัปเดตคุณสมบัติมุมมองการนำเสนอใน Python
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/python-net/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- การจัดแนวตัวแบ่งแนวตั้ง
- มุมมองเดียว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- การซูมเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ใช้ Aspose.Slides for Python via .NET เพื่อกำหนดค่าการจัดวางมุมมองปกติ, การซูมสไลด์และโน้ต, ระยะห่างกริด, และการแสดงความเห็นในงานนำเสนอ PowerPoint"
---
## **บทนำ**

ในมุมมองปกติของ PowerPoint สไลด์จะแสดงระหว่างแถบด้านข้างสำหรับรูปย่อหรือโครงร่างและแถบนโน๊ตด้านล่าง Aspose.Slides for Python via .NET เปิดเผยค่าการตั้งค่าการแก้ไขที่บันทึกไว้ของงานนำเสนอผ่าน [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). ค่าตั้งค่าเหล่านี้รวมถึงการจัดเรียงแถบ, ระดับการซูม, ระยะห่างของเส้นกริด, และการแสดงความเห็น

## **เกี่ยวกับ NormalViewProperties**

ใช้ [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) เพื่อเข้าถึงอ็อบเจ็กต์ [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) ควบคุมว่าจะให้ไอคอนปรากฏข้างชื่อสไลด์ในโครงร่างหรือไม่. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) ทำให้แถบด้านข้าง snap ไปยังสถานะย่อเมื่อผู้ใช้ปรับความกว้างให้แคบ. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) แสดงความต้องการให้แสดงแถบเดียวในหน้าต่างเต็ม.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) ควบคุมตัวแบ่งระหว่างแถบด้านข้างและสไลด์. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) ควบคุมตัวแบ่งเหนือแถบนโน๊ต. ทั้งสองรับค่า [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) ที่เป็น `MINIMIZED`, `MAXIMIZED`, หรือ `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![โปรแกรมแก้ไขเชิงแนวคิดแยกแถบด้านข้าง, พื้นที่สไลด์และพื้นที่ด้านล่างด้วยตัวแบ่งแนวตั้งและแนวนอนที่มีป้ายกำกับ.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*ในมุมมองปกติ ตัวแบ่งแนวตั้งควบคุมความกว้างของแถบด้านข้าง. ตัวแบ่งแนวนอนควบคุมพื้นที่เหนือแถบนโน๊ต.*
<!-- visual-explanation:presentation-view-properties:end -->

## **เกี่ยวกับการคืนค่า NormalViewProperties**

เมื่อมีการคืนค่าตัวแบ่ง, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) ให้ขนาดที่บันทึกของแถบด้านข้างและ [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) ให้ขนาดที่บันทึกของพื้นที่สไลด์ด้านบน. ทั้งสองเปิดเผย [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). คุณสมบัติ [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) ของมันรับเปอร์เซ็นต์ตั้งแต่ 0 ถึง 100, และ [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) ควบคุมว่าตัวแก้ไขจะปรับขนาดอัตโนมัติเมื่อหน้าต่างถูกปรับขนาดหรือไม่.

ตัวอย่างนี้อัปเดตงานนำเสนอที่มีอยู่. มันคืนค่าตัวแบ่งแนวนอน, ตั้งค่า [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) เป็น 80% พร้อมเปิดใช้งานการปรับอัตโนมัติ, และขยายตัวแบ่งแนวตั้งให้เต็ม. ตัวอย่างนี้ยังเปิดใช้งาน [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) สำหรับมุมมองโครงร่าง.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดค่าการซูมเริ่มต้น**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) และ [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) เก็บการตั้งค่าการซูมแยกกันสำหรับตัวแก้ไข. การตั้งค่าเหล่านี้ไม่ได้มีผลต่อขนาดสไลด์, การเล่นสไลด์โชว์, หรือความละเอียดการส่งออกภาพ.

ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และเปิดใช้งาน [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) เพื่อให้สไลด์พอดีกับหน้าต่างการแก้ไข. สำหรับหน้าบันทึก, มันปิดการปรับสเกลอัตโนมัติและตั้งค่า [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) เป็นการซูมคงที่ 80%.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการเว้นระยะกริด**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) กำหนดระยะห่างระหว่างเส้นกริดการแก้ไขทั่วทั้งงานนำเสนอ. ค่าที่รับต้องเป็นจำนวนบวกในหน่วยพอยต์, โดยมี 72 พอยต์ต่อหนึ่งนิ้ว. ตัวอย่างนี้พิมพ์ค่าการเว้นระยะปัจจุบันในงานนำเสนอที่มีอยู่และบันทึกกริดหนึ่งในสี่นิ้วโดยตั้งค่าช่วงเป็น 18 พอยต์.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

กริดจะทำซ้ำที่ช่วงคงที่. [Drawing guides](/slides/th/python-net/drawing-guides/) ทำเครื่องหมายตำแหน่งแนวนอนหรือแนวตั้งแต่ละตำแหน่ง. ทั้งสองเป็นเครื่องมือช่วยการแก้ไขและจะแสดงเฉพาะในตัวแก้ไขที่แสดงมัน. การนำเสนอและการส่งออกเป็น PDF, ภาพ, หรือ SVG จะไม่รวมเครื่องมือนี้.

## **แสดงหรือซ่อนความคิดเห็นเมื่อเปิดงานนำเสนอ**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) เก็บค่าความต้องการที่ตัวแก้ไขที่รองรับจะใช้เมื่อเปิดงานนำเสนอ. สำหรับงานนำเสนอที่มีความคิดเห็นอยู่, ตัวอย่างนี้พิมพ์ค่าปัจจุบันและบันทึกสำเนาที่ซ่อนความคิดเห็น. ตัวอย่างนี้ยังตั้งค่า [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) เป็น [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) เพื่อให้สำเนาเปิดในมุมมองสไลด์.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

การซ่อนความคิดเห็นจะรักษาข้อความ, ผู้เขียน, ตำแหน่ง, การตอบกลับ, และสถานะของความคิดเห็นไว้. หากต้องการเปลี่ยนแปลงความคิดเห็นเอง, ดูที่ [Presentation Comments](/slides/th/python-net/presentation-comments/). การตั้งค่าการส่งออกจะควบคุมว่าความคิดเห็นปรากฏใน PDF, HTML, ภาพ, โน๊ต, หรือเอกสารแจกหรือไม่.

## **FAQ**

**ทำไมกริดจึงหายไปเมื่อฉันเปิดงานนำเสนอใหม่?**

งานนำเสนอบันทึกช่วงกริดไว้. เพื่อดูกริด, ให้เปิดการแสดงกริดในตัวแก้ไข.

**การล้าง Drawing guides จะทำให้ระยะห่างของกริดเปลี่ยนหรือไม่?**

ไม่. การเพิ่ม, ย้าย, หรือล้างไกด์จะไม่ได้เปลี่ยนช่วงของกริด.

**ส่วนต่าง ๆ ของงานนำเสนอสามารถมีการตั้งค่ามุมมองที่แตกต่างกันได้หรือไม่?**

ไม่ได้. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) ใช้กับงานนำเสนอทั้งหมด.

**ฉันสามารถบันทึกการตั้งค่ามุมมองที่แตกต่างกันสำหรับผู้ใช้คนต่าง ๆ ได้หรือไม่?**

ไฟล์บันทึกชุดการตั้งค่ามุมมองเดียวสำหรับทุกคน. ตัวแก้ไขอาจประยุกต์ใช้ค่าเริ่มต้นของผู้ใช้ท้องถิ่นเพิ่มเติม.

**ฉันสามารถบันทึกการตั้งค่ามุมมองในแม่แบบได้หรือไม่?**

ได้. งานนำเสนอที่สร้างจากแม่แบบจะสืบทอดการตั้งค่ามุมมองที่บันทึกไว้ในแม่แบบ.
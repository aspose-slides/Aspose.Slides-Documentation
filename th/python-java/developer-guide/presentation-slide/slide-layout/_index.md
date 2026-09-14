---
title: ใช้หรือเปลี่ยนเค้าโครงสไลด์ใน Python ผ่าน Java
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/python-java/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตัวแทน
- การออกแบบงานนำเสนอ
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การแสดงผลส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- หัวข้อส่วน
- สองเนื้อหา
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- เค้าโครงว่าง
- เนื้อหาพร้อมคำอธิบาย
- รูปภาพพร้อมคำอธิบาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้, สร้างและแก้ไขเค้าโครงสไลด์ใน Aspose.Slides สำหรับ Python ผ่าน Java, เพิ่มตัวแทน, ลบเค้าโครงที่ไม่ได้ใช้, และควบคุมการแสดงผลส่วนท้าย."
---
## **ภาพรวม**

เค้าโครงสไลด์กำหนดตำแหน่งและรูปแบบของตัวแทนเช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิ, และตาราง การใช้เค้าโครงทำให้สไลด์มีโครงสร้างที่สม่ำเสมอขณะยังให้แต่ละสไลด์สามารถมีเนื้อหาของตนเองได้.

เค้าโครงที่พบบ่อยที่สุดรวมถึง:

- **Title Slide**: มีตัวแทนชื่อเรื่องและชื่อเรื่องย่อย
- **Title and Content**: มีตัวแทนชื่อเรื่องและตัวแทนเนื้อหาทั่วไป
- **Blank**: ไม่มีตัวแทนเนื้อหาและมีประโยชน์เมื่อรูปทรงทุกอย่างจะถูกจัดตำแหน่งด้วยตนเอง

## **เข้าใจการสืบทอดเค้าโครง**

งานนำเสนอมีระดับที่เกี่ยวข้องสามระดับ:

1. [สไลด์แม่](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/) กำหนดธีม, รูปแบบที่แชร์, พื้นหลัง, และวัตถุทั่วไป.
2. [สไลด์เค้าโครง](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/) เป็นส่วนหนึ่งของสไลด์แม่และกำหนดการจัดวางตัวแทนเฉพาะ.
3. [สไลด์ปกติ](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/) ใช้เค้าโครงหนึ่งและเก็บเนื้อหาที่ป้อนสำหรับสไลด์นั้น.

สไลด์ปกติสืบทอดธีมและรูปแบบจากเค้าโครงของมัน และเค้าโครงสืบทอดจากสไลด์แม่ ค่าที่ตั้งโดยตรงบนสไลด์ปกติจะทับค่าที่สืบทอดในระดับนั้น เมื่อสร้างสไลด์ปกติ รูปร่างตัวแทนของมันจะสร้างจากเค้าโครงที่เลือก ในขณะที่เนื้อหาที่ป้อนเข้าสู่ตัวแทนนั้นเป็นของสไลด์ปกติ

เพิ่มตัวแทนที่จำเป็นลงในเค้าโครงก่อนสร้างสไลด์จากเค้าโครงนั้น การเพิ่มตัวแทนเพิ่มเติมในภายหลังจะไม่ได้เพิ่มรูปร่างตัวแทนที่สอดคล้องให้กับสไลด์ปกติที่มีอยู่โดยอัตโนมัติ

ความสัมพันธ์นี้มีผลสำคัญสองประการ:

- การเปลี่ยนรูปแบบที่สืบทอดหรือรูปทรงของตัวแทนที่มีอยู่บนเค้าโครงอาจอัปเดตสไลด์ทุกสไลด์ที่พึ่งพา ก่อนแก้ไขเค้าโครงที่ใช้งานอยู่แล้ว ให้ตรวจสอบสไลด์ที่พึ่งพาและตรวจทานงานนำเสนอที่ได้.
- เค้าโครงที่ยังถูกสไลด์ใช้อยู่ไม่สามารถลบได้ ให้นำสไลด์ที่พึ่งพาเปลี่ยนไปใช้เค้าโครงอื่นก่อน หรือให้ลบเฉพาะเค้าโครงที่ไม่ได้ใช้เท่านั้น.

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนสุดของลำดับชั้นนี้ ดูที่ [สไลด์แม่](/slides/th/python-java/slide-master/).

## **เลือกและใช้เค้าโครงสไลด์**

ใช้ประเภทเค้าโครงเมื่อการนำเสนอปฏิบัติตามคำนิยามเค้าโครงมาตรฐานของ PowerPoint. ชื่อเค้าโครงสามารถแก้ไขได้โดยผู้ใช้และสามารถทำให้เป็นภาษาท้องถิ่นได้ ดังนั้นการเลือกโดยอ้างอิงชื่อจึงไม่ค่อยน่าเชื่อถือ หากคุณไม่ควบคุมแม่แบบต้นทาง.

ตัวอย่างต่อไปจะค้นหา **Title and Content** บนสไลด์แม่แรก หากไม่พบเค้าโครงนั้น จะสลับกลับไปใช้ **Blank** อย่างเจตนา การตรวจสอบครั้งที่สองสำหรับ `None` จำเป็นเพราะงานนำเสนออาจมีเฉพาะเค้าโครงที่กำหนดเองเท่านั้น เค้าโครงที่เลือกจะถูกนำไปใช้กับสไลด์ปกติแรกผ่านเมธอด [Slide.setLayoutSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การเปลี่ยนเค้าโครงของสไลด์ไม่ได้ลบรูปร่างปกติที่เพิ่มโดยตรงบนสไลด์ อย่างไรก็ตาม ตำแหน่งตัวแทน, รูปแบบที่สืบทอด, และความสอดคล้องระหว่างตัวแทนที่มีอยู่กับเค้าโครงใหม่อาจเปลี่ยนแปลง ดังนั้นควรตรวจสอบผลลัพธ์เมื่อสลับระหว่างเค้าโครงที่แตกต่างอย่างมาก.

## **เพิ่มสไลด์เค้าโครง**

การเลือกและการสร้างเป็นการดำเนินการแยกกัน ตัวอย่างก่อนหน้าเลือกเค้าโครงที่มีอยู่; ไม่ได้สร้างเค้าโครงใหม่ เพื่อสร้างเค้าโครงให้เรียกเมธอด [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterlayoutslidecollection/#add) บนคอลเลกชันเค้าโครงของสไลด์แม่เป้าหมาย.

ตัวอย่างต่อไปจะเพิ่มเค้าโครง **Title and Content** ใหม่ชื่อ `Report Title and Content` เสมอ จากนั้นเพิ่มสไลด์ปกติที่อิงจากเค้าโครงนั้น ชื่อเค้าโครงต้องไม่ซ้ำกันภายในคอลเลกชัน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เพิ่มเค้าโครงเฉพาะเมื่อเทมเพลตต้องการโครงสร้างที่สามารถใช้ซ้ำได้จริง หากมีเค้าโครงที่เหมาะสมอยู่แล้ว ให้เลือกและใช้ซ้ำแทนการสร้างซ้ำ.

## **เพิ่มตัวแทนลงในสไลด์เค้าโครง**

เมธอด [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#getPlaceholderManager) ให้ [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/) เพื่อเพิ่มรูปร่างตัวแทนลงในเค้าโครง.

| ตัวแทน PowerPoint | [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/) Method |
| ----------------- | ---------------------------------- |
| ![เนื้อหา](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![ข้อความ](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![ข้อความ (แนวตั้ง)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![รูปภาพ](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![แผนภูมิ](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![ตาราง](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![สื่อ](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![ภาพออนไลน์](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

ตัวอย่างต่อไปตรวจสอบว่าเค้าโครง **Blank** มีอยู่, เพิ่มตัวแทนสี่รายการลงในเค้าโครงนั้น, แล้วสร้างสไลด์ปกติที่ใช้เค้าโครงที่แก้ไขแล้ว ลำดับนี้ตั้งใจไว้: ตัวแทนจะถูกเพิ่มก่อนที่สไลด์ปกติจะสร้าง เพื่อให้ Aspose.Slides สามารถสร้างรูปร่างตัวแทนที่สอดคล้องบนสไลด์นั้น.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ตัวแทนบนสไลด์เค้าโครง](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนรูปแบบที่สืบทอดหรือรูปทรงของตัวแทนเค้าโครงที่มีอยู่สามารถส่งผลต่อสไลด์ที่พึ่งพาได้ ตัวแทนเค้าโครงที่เพิ่มใหม่จะไม่ถูกเติมกลับในสไลด์ปกติที่มีอยู่ ทดสอบการเปลี่ยนแปลงเค้าโครงบนสำเนาของงานนำเสนอและตรวจสอบสไลด์ที่พึ่งพาทุกสไลด์.
{{% /alert %}}

## **ลบสไลด์เค้าโครงที่ไม่ได้ใช้**

ใช้เมธอด [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) เพื่อลบเค้าโครงที่ไม่มีสไลด์ปกติอ้างอิง เมธอดจะคงเค้าโครงที่ยังใช้งานไว้.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เพื่อเอาเค้าโครงเฉพาะหนึ่งออก ให้ใช้เมธอด [hasDependingSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#hasDependingSlides) หรือ [getDependingSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#getDependingSlides) ของมันก่อน ย้ายสไลด์ที่พึ่งพาใด ๆ ก่อนเรียก [LayoutSlide.remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#remove). การพยายามลบเค้าโครงที่ยังใช้งานจะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxeditexception/).

## **ควบคุมการแสดงผลส่วนท้ายบนสไลด์เค้าโครง**

เค้าโครงมีตัวแทนส่วนท้าย, ตัวเลขสไลด์, และตัวแทนวันที่เวลาเป็นของตัวเอง ใช้เมธอด [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) เพื่อควบคุมตัวแทนเหล่านั้นสำหรับเค้าโครงหนึ่ง การทำเช่นนี้มีประโยชน์เมื่อเช่น เค้าโครงเนื้อหาควรแสดงส่วนท้ายแต่เค้าโครงชื่อเรื่องไม่ควรแสดง.

ตัวอย่างต่อไปเลือกเค้าโครงอย่างปลอดภัยและทำให้ส่วนท้ายของมันแสดงผล:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ควบคุมการแสดงผลส่วนท้ายบนสไลด์แม่และเค้าโครงลูกของมัน**

เพื่อใช้การตั้งค่าส่วนท้ายที่สอดคล้องกันทั่วระดับสไลด์แม่ ให้ใช้เมธอด [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/#getHeaderFooterManager). วิธีการกระจายของ [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslideheaderfootermanager/) ทำงานบนสไลด์แม่และสไลด์เค้าโครงและสไลด์ปกติที่พึ่งพา; ไม่ได้มุ่งเป้าแค่สไลด์ปกติหนึ่งเท่านั้น.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างสไลด์แม่และสไลด์เค้าโครงคืออะไร?**

สไลด์แม่กำหนดธีมและรูปแบบที่แชร์ของงานนำเสนอ สไลด์เค้าโครงเป็นส่วนของสไลด์แม่และกำหนดการจัดวางตัวแทนที่ใช้ซ้ำได้หนึ่งแบบ สไลด์ปกติใช้เค้าโครงเหล่านั้นและเก็บเนื้อหาเฉพาะของสไลด์.

**ฉันสามารถคัดลอกสไลด์เค้าโครงจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งได้หรือไม่?**

ได้เลย. เพิ่มสำเนาไปยังคอลเลกชันปลายทางโดยใช้เมธอด [addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/globallayoutslidecollection/#addClone). เมื่อคัดลอกระหว่างงานนำเสนอ ควรตรวจสอบฟอนต์, ธีม, รูปภาพ, และทรัพยากรอื่น ๆ ที่เค้าโครงต้นทางใช้.

**จะเกิดอะไรขึ้นเมื่อฉันแก้ไขเค้าโครงที่กำลังใช้งานอยู่?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงของเค้าโครง เว้นแต่พวกเขาจะทับรูปแบบหรือวัตถุที่ได้รับผลกระทบในระดับท้องถิ่น ดังนั้นรูปทรงของตัวแทนและสไตล์ที่สืบทอดอาจเปลี่ยนแปลงในหลายสไลด์พร้อมกัน ใช้ [getDependingSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#getDependingSlides) เพื่อระบุสไลด์ที่ได้รับผลก่อนแก้ไขเค้าโครง.

**จะเกิดอะไรขึ้นหากฉันลบเค้าโครงที่ยังถูกใช้งานอยู่?**

Aspose.Slides จะโยงข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxeditexception/). ให้ย้ายสไลด์ที่พึ่งพาออกก่อน หรือใช้ [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) เพื่อลบเค้าโครงที่ไม่ได้อ้างอิงเท่านั้น.
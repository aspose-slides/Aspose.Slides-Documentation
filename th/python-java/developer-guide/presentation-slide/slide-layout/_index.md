---
title: Apply or Change Slide Layouts in Python via Java
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/python-java/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตัวยึด
- การออกแบบการนำเสนอ
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การมองเห็นส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- หัวข้อส่วน
- สองเนื้อหา
- เปรียบเทียบ
- เฉพาะหัวเรื่อง
- เค้าโครงว่าง
- เนื้อหาพร้อมคำอธิบายภาพ
- รูปภาพพร้อมคำอธิบาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้, สร้าง และแก้ไขเค้าโครงสไลด์ใน Aspose.Slides สำหรับ Python ผ่าน Java, เพิ่มตัวยึด, ลบเค้าโครงที่ไม่ได้ใช้, และควบคุมการมองเห็นส่วนท้าย."
---
## **ภาพรวม**

เค้าโครงสไลด์กำหนดตำแหน่งและการจัดรูปแบบของตัวยึดต่าง ๆ เช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิ, และตาราง การใช้เค้าโครงทำให้สไลด์มีโครงสร้างที่สอดคล้องกันในขณะเดียวกันยังให้แต่ละสไลด์สามารถมีเนื้อหาเฉพาะของตนได้

- **สไลด์หัวข้อ**: มีตัวยึดหัวเรื่องและหัวเรื่องย่อย
- **หัวเรื่องและเนื้อหา**: มีตัวยึดหัวเรื่องและตัวยึดเนื้อหาทั่วไป
- **ว่าง**: ไม่มีตัวยึดเนื้อหาและมีประโยชน์เมื่อทุกรูปทรงจะถูกจัดตำแหน่งด้วยตนเอง

## **ทำความเข้าใจการสืบทอดเค้าโครง**

งานนำเสนอมีระดับที่เกี่ยวข้องสามระดับ:

1. A [สไลด์แม่](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/) กำหนดธีม, การจัดรูปแบบร่วม, พื้นหลัง, และออบเจ็กต์ที่ใช้ร่วมกัน
1. A [สไลด์เค้าโครง](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/) อยู่ภายใต้สไลด์แม่และกำหนดการจัดเรียงตัวยึดเฉพาะ
1. A [สไลด์ปกติ](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/) ใช้เค้าโครงหนึ่งแบบและเก็บเนื้อหาที่ป้อนเข้ามาสำหรับสไลด์นั้น

สไลด์ปกติสืบทอดธีมและการจัดรูปแบบจากเค้าโครงของมัน, ส่วนเค้าโครงสืบทอดจากสไลด์แม่ ค่าที่ตั้งโดยตรงบนสไลด์ปกติจะลบค่าที่สืบทอดไว้ในระดับนั้นออก เมื่อสไลด์ปกติถูกสร้างขึ้น, รูปทรงตัวยึดของมันจะถูกสร้างจากเค้าโครงที่เลือก, ในขณะที่เนื้อหาที่ป้อนเข้าไปในตัวยึดเหล่านั้นเป็นของสไลด์ปกติ

เพิ่มตัวยึดที่จำเป็นลงในเค้าโครงก่อนสร้างสไลด์จากมัน การเพิ่มตัวยึดใหม่ในเค้าโครงภายหลังจะไม่เพิ่มรูปทรงตัวยึดที่สอดคล้องบนสไลด์ปกติที่มีอยู่โดยอัตโนมัติ

ความสัมพันธ์นี้มีผลสำคัญสองประการ:

- การเปลี่ยนแปลงการจัดรูปแบบที่สืบทอดหรือรูปทรงตัวยึดที่มีอยู่บนเค้าโครงสามารถอัปเดตสไลด์ทั้งหมดที่พึ่งพาได้ ก่อนแก้ไขเค้าโครงที่กำลังใช้อยู่, ตรวจสอบสไลด์ที่พึ่งพาและตรวจทานผลลัพธ์ของการนำเสนอ
- เค้าโครงที่ยังคงถูกสไลด์ใช้ไม่สามารถลบได้ ต้องกำหนดสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อน, หรือทำการลบเฉพาะเค้าโครงที่ไม่ได้ใช้

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนสุดของลำดับชั้นนี้, ดูที่ [Slide Master](/slides/th/python-java/slide-master/)

เพื่อซ่อนโลโก้หรือรูปแบบสไลด์แม่ที่สืบทอดบนสไลด์หนึ่งหรือผ่านเค้าโครงที่ใช้ร่วมกัน, ดูที่ [Control the Visibility of Master Graphics](/slides/th/python-java/slide-master/) ตัวอย่างเปรียบเทียบสองสไลด์ที่ใช้สไลด์แม่เดียวกัน

## **เลือกและใช้เค้าโครงสไลด์**

ใช้ประเภทเค้าโครงเมื่อการนำเสนอปฏิบัติตามคำนิยามเค้าโครง PowerPoint มาตรฐาน ชื่อเค้าโครงสามารถแก้ไขได้โดยผู้ใช้และสามารถแปลเป็นภาษาอื่นได้, ดังนั้นการเลือกโดยอิงชื่อจะน่าเชื่อถือน้อยกว่าถ้าคุณไม่ควบคุมเทมเพลตต้นฉบับ

ตัวอย่างต่อไปมองหา **Title and Content** บนสไลด์แม่แรก หากเค้าโครงนั้นไม่มีอยู่, จะย้อนกลับไปใช้ **Blank** อย่างตั้งใจ การตรวจสอบครั้งที่สองสำหรับ `None` จำเป็นเพราะงานนำเสนออาจมีเฉพาะเค้าโครงที่กำหนดเองเท่านั้น เค้าโครงที่เลือกจะถูกนำไปใช้กับสไลด์ปกติแรกผ่านเมธอด [Slide.setLayoutSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#setLayoutSlide)

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

การเปลี่ยนเค้าโครงของสไลด์ไม่ทำลายรูปทรงทั่วไปที่เพิ่มโดยตรงบนสไลด์ อย่างไรก็ตามตำแหน่งตัวยึด, การจัดรูปแบบที่สืบทอด, และความสอดคล้องระหว่างตัวยึดที่มีอยู่กับเค้าโครงใหม่อาจเปลี่ยนแปลงได้ ดังนั้นควรตรวจสอบผลลัพธ์เมื่อสลับระหว่างเค้าโครงที่แตกต่างอย่างมาก

## **เพิ่มสไลด์เค้าโครง**

การเลือกและการสร้างเป็นการดำเนินการแยกจากกัน ตัวอย่างก่อนหน้านี้เลือกเค้าโครงที่มีอยู่; มันไม่ได้สร้างเค้าโครงใหม่ เพื่อสร้างเค้าโครง, เรียกเมธอด [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterlayoutslidecollection/#add) บนคอลเลกชันเค้าโครงของสไลด์แม่เป้าหมาย

ตัวอย่างต่อไปนี้จะเพิ่มเค้าโครง **Title and Content** ใหม่ที่ชื่อ `Report Title and Content` เสมอ, จากนั้นเพิ่มสไลด์ปกติที่อิงจากเค้าโครงนั้น ชื่อเค้าโครงต้องเป็นเอกลักษณ์ภายในคอลเลกชัน

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

เพิ่มเค้าโครงเฉพาะเมื่อเทมเพลตต้องการโครงสร้างที่ใช้ซ้ำได้จริง หากมีเค้าโครงที่เหมาะสมอยู่แล้ว, ให้เลือกและใช้ซ้ำแทนการสร้างสำเนา

## **เพิ่มตัวยึดในสไลด์เค้าโครง**

เมธอด [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#getPlaceholderManager) ให้บริการ [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/) สำหรับการเพิ่มรูปทรงตัวยึดลงในเค้าโครง

| ตัวยึด PowerPoint | เมธอด LayoutPlaceholderManager |
| ------------------- | -------------------------------- |
| ![เนื้อหา](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![ข้อความ](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![ข้อความ (แนวตั้ง)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![รูปภาพ](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![แผนภูมิ](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![ตาราง](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![สื่อ](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![รูปภาพออนไลน์](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

ตัวอย่างต่อไปนี้ตรวจสอบว่าเค้าโครง **Blank** มีอยู่, เพิ่มตัวยึดสี่รายการลงในมัน, แล้วสร้างสไลด์ปกติที่ใช้เค้าโครงที่แก้ไขแล้ว ลำดับนี้ตั้งใจให้เพิ่มตัวยึดก่อนสร้างสไลด์ปกติ เพื่อให้ Aspose.Slides สามารถสร้างรูปทรงตัวยึดที่สอดคล้องบนสไลด์นั้น

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

![ตัวยึดบนสไลด์เค้าโครง](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนแปลงการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวยึดเค้าโครงที่มีอยู่สามารถส่งผลต่อสไลด์ที่พึ่งพาได้ ตัวยึดเค้าโครงที่เพิ่มใหม่จะไม่ถูกเติมอัตโนมัติในสไลด์ปกติที่มีอยู่แล้ว ทดสอบการเปลี่ยนแปลงเค้าโครงบนสำเนาของงานนำเสนอและตรวจสอบทุกสไลด์ที่พึ่งพา
{{% /alert %}}

## **ลบสไลด์เค้าโครงที่ไม่ได้ใช้**

ใช้เมธอด [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) เพื่อลบเค้าโครงที่ไม่มีสไลด์ปกติอ้างอิง เมธอดจะทิ้งเค้าโครงที่ยังคงใช้งานอยู่ไว้ไม่ถูกแก้ไข

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

เพื่อทำการลบเค้าโครงหนึ่งเฉพาะ, ก่อนอื่นใช้เมธอด [hasDependingSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#hasDependingSlides) หรือ [getDependingSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#getDependingSlides) จากนั้นกำหนดสไลด์ที่พึ่งพาใหม่ก่อนเรียกเมธอด [LayoutSlide.remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#remove). การพยายามลบเค้าโครงที่ถูกใช้จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxeditexception/)

## **ควบคุมการมองเห็นส่วนท้ายบนสไลด์เค้าโครง**

เค้าโครงมีตัวยึดส่วนท้าย, หมายเลขสไลด์, และวันที่-เวลาเป็นของตนเอง ใช้เมธอด [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) เพื่อควบคุมตัวยึดเหล่านี้สำหรับเค้าโครงหนึ่ง ซึ่งเป็นประโยชน์เมื่อตัวอย่างเช่น เค้าโครงเนื้อหาควรแสดงส่วนท้ายแต่เค้าโครงหัวเรื่องไม่ควรแสดง

ตัวอย่างต่อไปนี้เลือกเค้าโครงอย่างปลอดภัยและทำให้ส่วนท้ายของมันแสดงผล

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

## **ควบคุมการมองเห็นส่วนท้ายบนสไลด์แม่และเค้าโครงลูกของมัน**

เพื่อใช้การตั้งค่าส่วนท้ายอย่างสอดคล้องทั่วทั้งลำดับชั้นสไลด์แม่, ใช้เมธอด [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/#getHeaderFooterManager) วิธีการกระจายของ [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslideheaderfootermanager/) ทำงานบนสไลด์แม่และสไลด์เค้าโครงและสไลด์ปกติที่พึ่งพา; ไม่ได้มุ่งเป้าแค่สไลด์ปกติหนึ่งสไลด์

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

สไลด์แม่กำหนดธีมและการจัดรูปแบบร่วมของงานนำเสนอ สไลด์เค้าโครงเป็นส่วนหนึ่งของสไลด์แม่และกำหนดการจัดเรียงตัวยึดที่สามารถใช้ซ้ำได้ สไลด์ปกติใช้เค้าโครงเหล่านั้นและเก็บเนื้อหาที่เฉพาะเจาะจงของสไลด์

**ฉันสามารถคัดลอกสไลด์เค้าโครงจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอได้หรือไม่?**

ได้ เพิ่มสำเนาเข้าไปในคอลเลกชันเป้าหมายด้วยเมธอด [addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/globallayoutslidecollection/#addClone) เมื่อคัดลอกจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่ง, ควรตรวจสอบฟอนต์, ธีม, รูปภาพ, และทรัพยากรอื่น ๆ ที่ใช้โดยเค้าโครงต้นฉบับด้วย

**จะเกิดอะไรขึ้นเมื่อฉันแก้ไขเค้าโครงที่กำลังใช้งานอยู่?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงของเค้าโครง เว้นแต่จะมีการเขียนทับการจัดรูปแบบหรือออบเจ็กต์ที่เกี่ยวข้องในระดับสไลด์เอง รูปทรงตัวยึดและสไตล์ที่สืบทอดอาจเปลี่ยนแปลงบนหลายสไลด์พร้อมกัน ใช้เมธอด [getDependingSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#getDependingSlides) เพื่อตรวจสอบสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเค้าโครง

**จะเกิดอะไรขึ้นหากฉันลบเค้าโครงที่ยังคงถูกใช้งาน?**

Aspose.Slides จะโยน [PptxEditException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxeditexception/) ต้องกำหนดสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อน, หรือใช้เมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) เพื่อลบเฉพาะเค้าโครงที่ไม่มีการอ้างอิง
---
title: เรนเดอร์พรีเซนเทชันด้วยฟอนต์สำรองใน Python
linktitle: เรนเดอร์พรีเซนเทชัน
type: docs
weight: 30
url: /th/python-net/render-presentation-with-fallback-font/
keywords:
- ฟอนต์สำรอง
- เรนเดอร์ PowerPoint
- เรนเดอร์พรีเซนเทชัน
- เรนเดอร์สไลด์
- PowerPoint
- พรีเซนเทชัน
- Python
- Aspose.Slides
description: "เรนเดอร์พรีเซนเทชันด้วยฟอนต์สำรองใน Aspose.Slides สำหรับ Python ผ่าน .NET - รักษาข้อความให้สอดคล้องใน PPT, PPTX และ ODP ด้วยตัวอย่างโค้ดที่ทำตามขั้นตอน."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเรนเดอร์พรีเซนเทชันโดยใช้กฎฟอนต์สำรอง บทความนี้แสดงวิธีการสร้างคอลเลกชันของกฎฟอนต์สำรอง, แก้ไขกฎโดยการลบหรือเพิ่มฟอนต์สำรอง, และกำหนดคอลเลกชันให้กับ property `FontsManager.font_fall_back_rules_collection`  

เมื่อคอลเลกชันของกฎฟอนต์สำรองถูกกำหนดให้กับ `fonts_manager` ของพรีเซนเทชัน, กฎเหล่านั้นจะถูกนำไปใช้ระหว่างการดำเนินการต่าง ๆ เช่น การบันทึก, การเรนเดอร์, และการแปลงพรีเซนเทชัน ตัวอย่างแสดงวิธีใช้กฎที่กำหนดไว้เมื่อเรนเดอร์รูปย่อของสไลด์และบันทึกเป็นภาพ PNG  

## **เรนเดอร์สไลด์โดยใช้กฎฟอนต์สำรอง**

ตัวอย่างต่อไปนี้รวมขั้นตอนต่อไปนี้:

1. เรา [สร้างคอลเลกชันของกฎฟอนต์สำรอง](/slides/th/python-net/create-fallback-fonts-collection/).
2. [ลบ](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontfallbackrule/remove/) กฎฟอนต์สำรองและ [add_fall_back_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) ไปยังกฎอื่น.
3. กำหนดคอลเลกชันของกฎให้กับ property [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/).
4. ด้วยเมธอด [Presentation.save()](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เราสามารถบันทึกพรีเซนเทชันในรูปแบบเดียวกัน หรือบันทึกในรูปแบบอื่นได้ หลังจากที่คอลเลกชันของกฎฟอนต์สำรองถูกกำหนดให้กับ FontsManager, กฎเหล่านี้จะถูกนำไปใช้ระหว่างการดำเนินการใด ๆ กับพรีเซนเทชัน: บันทึก, เรนเดอร์, แปลง, เป็นต้น.

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ใหม่ของคอลเลกชันกฎ
rulesList = slides.FontFallBackRulesCollection()

# สร้างกฎหลายรายการ
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# พยายามลบฟอนต์สำรอง "Tahoma" จากกฎที่โหลด
	fallBackRule.remove("Tahoma")

	# และอัปเดตกฎสำหรับช่วงที่ระบุ
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# เรายังสามารถลบกฎที่มีอยู่แล้วจากรายการได้
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# กำหนดรายการกฎที่เตรียมไว้สำหรับการใช้งาน
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# เรนเดอร์รูปย่อโดยใช้คอลเลกชันกฎที่กำหนดค่าไว้และบันทึกเป็น PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธีการ [แปลงสไลด์ PowerPoint เป็น PNG ใน Python](/slides/th/python-net/convert-powerpoint-to-png/).
{{% /alert %}}
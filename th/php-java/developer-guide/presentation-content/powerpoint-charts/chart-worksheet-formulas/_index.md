---
title: ใช้สูตร Worksheet ของแผนภูมิในงานนำเสนอด้วย PHP
linktitle: สูตร Worksheet
type: docs
weight: 70
url: /th/php-java/chart-worksheet-formulas/
keywords:
- สเปรดชีตของแผนภูมิ
- แผ่นงานของแผนภูมิ
- สูตรแผนภูมิ
- สูตร worksheet
- สูตรสเปรดชีต
- แหล่งข้อมูล
- ค่าคงที่ตรรกะ
- ค่าคงที่เชิงตัวเลข
- ค่าคงที่สตริง
- ค่าคงที่ข้อผิดพลาด
- ค่าคงที่คณิตศาสตร์
- ตัวดำเนินการเปรียบเทียบ
- สไตล์ A1
- สไตล์ R1C1
- ฟังก์ชันที่กำหนดไว้ล่วงหน้า
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้สูตรสไตล์ Excel ใน Aspose.Slides สำหรับ PHP ผ่าน worksheet แผนภูมิของ Java และอัตโนมัติรายงานในไฟล์ PPT และ PPTX"
---
## **ภาพรวม**

Worksheet ของแผนภูมิคือแหล่งข้อมูลที่อยู่เบื้องหลังแผนภูมิในงานนำเสนอ มันเก็บชื่อหมวดหมู่และชื่อชุดข้อมูลพร้อมกับค่าตัวเลขที่แผนภูมิแสดง ใน Aspose.Slides worksheet นี้สามารถเข้าถึงได้ผ่าน chart data workbook ซึ่งให้คุณทำงานกับข้อมูลแผนภูมิโดยใช้โปรแกรมได้  

บทความนี้อธิบายวิธีใช้สูตรใน worksheet ของข้อมูลแผนภูมิเพื่อให้ค่าของเซลล์ถูกคำนวณและอัปเดตโดยอัตโนมัติ แทนการป้อนค่าด้วยตนเอง จะแสดงวิธีกำหนดสูตร ใช้การอ้างอิงแบบ A1‑style และ R1C1‑style คำนวนสูตรใน workbook ใหม่ และทำงานกับค่าคงที่ ตัวดำเนินการ การอ้างอิงเซลล์ และฟังก์ชันที่กำหนดไว้ล่วงหน้าซึ่งสนับสนุนสำหรับ worksheet ของแผนภูมิในงานนำเสนอ  

## **เกี่ยวกับสูตรสเปรดชีตของแผนภูมิในงานนำเสนอ**
**Chart spreadsheet** (หรือ chart worksheet) ในงานนำเสนอคือแหล่งข้อมูลของแผนภูมิ Chart spreadsheet มีข้อมูลที่แสดงบนแผนภูมิในรูปแบบกราฟิก เมื่อคุณสร้างแผนภูมิใน PowerPoint worksheet ที่เชื่อมโยงกับแผนภูมินี้จะถูกสร้างโดยอัตโนมัติเช่นกัน Worksheet ของแผนภูมิถูกสร้างสำหรับทุกประเภทของแผนภูมิ: แผนภูมิเส้น, แผนภูมิแท่ง, แผนภูมิลูกศรแบบวงกลม, แผนภูมิวงกลม ฯลฯ เพื่อตรวจดู chart spreadsheet ใน PowerPoint ให้ดับเบิ้ลคลิกที่แผนภูมิ:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet มีชื่อขององค์ประกอบแผนภูมิ (Category Name: *Category1*, Serie Name) และตารางข้อมูลตัวเลขที่สอดคล้องกับหมวดหมู่และชุดข้อมูลเหล่านั้น โดยค่าเริ่มต้นเมื่อคุณสร้างแผนภูมิใหม่ – ข้อมูล chart spreadsheet จะถูกตั้งเป็นข้อมูลเริ่มต้น จากนั้นคุณสามารถเปลี่ยนข้อมูลใน worksheet ด้วยมือได้  

โดยทั่วไปแผนภูมิแสดงข้อมูลที่ซับซ้อน (เช่น นักวิเคราะห์การเงิน, นักวิทยาศาสตร์) ซึ่งมีเซลล์ที่คำนวณจากค่าของเซลล์อื่นหรือจากข้อมูลแบบไดนามิก การคำนวณค่าของเซลล์ด้วยตนเองและใส่ค่าแบบคงที่ลงในเซลล์ทำให้การเปลี่ยนแปลงในอนาคตทำได้ยาก หากคุณเปลี่ยนค่าของเซลล์หนึ่ง เซลล์ที่พึ่งพิงค่าดังกล่าวทั้งหมดต้องได้รับการอัปเดตด้วย นอกจากนี้ข้อมูลในตารางอาจพึ่งพาข้อมูลจากตารางอื่น ทำให้โครงสร้างข้อมูลของงานนำเสนอซับซ้อนและต้องการการอัปเดตอย่างง่ายและยืดหยุ่น  

**Chart spreadsheet formula** ในงานนำเสนอคือ นิพจน์ที่คำนวณและอัปเดตข้อมูล chart spreadsheet โดยอัตโนมัติ สูตรสเปรดชีตกำหนดตรรกะการคำนวณข้อมูลสำหรับเซลล์หรือกลุ่มเซลล์หนึ่งๆ สูตรสเปรดชีตอาจเป็นสูตรคณิตศาสตร์หรือสูตรตรรกะ ซึ่งใช้: การอ้างอิงเซลล์, ฟังก์ชันคณิตศาสตร์, ตัวดำเนินการตรรกะ, ตัวดำเนินการคณิตศาสตร์, ฟังก์ชันการแปลง, ค่าคงที่สตริง ฯลฯ นิยามของสูตรจะเขียนลงในเซลล์ และเซลล์นั้นจะไม่บรรจุค่าธรรมดา สูตรสเปรดชีตคำนวณค่าและคืนค่ากลับ แล้วค่าที่ได้จะถูกกำหนดให้กับเซลล์ สูตรสเปรดชีตในงานนำเสนอเทียบเท่ากับสูตร Excel และสนับสนุนฟังก์ชัน, ตัวดำเนินการ, ค่าคงที่เริ่มต้นเดียวกันสำหรับการใช้งาน  

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/php-java/) chart spreadsheet แทนด้วยเมธอด  
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#getChartDataWorkbook) ของประเภท  
[**ChartDataWorkbook**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
สูตรสเปรดชีตสามารถกำหนดและเปลี่ยนได้ด้วยเมธอด  
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setFormula)  
ฟังก์ชันต่อไปนี้ได้รับการสนับสนุนสำหรับสูตรใน Aspose.Slides:

- ค่าคงที่ตรรกะ
- ค่าคงที่เชิงตัวเลข
- ค่าคงที่สตริง
- ค่าคงที่ข้อผิดพลาด
- ตัวดำเนินการคณิตศาสตร์
- ตัวดำเนินการเปรียบเทียบ
- การอ้างอิงเซลล์แบบ A1‑style
- การอ้างอิงเซลล์แบบ R1C1‑style
- ฟังก์ชันที่กำหนดไว้ล่วงหน้า


โดยทั่วไปสเปรดชีตจะเก็บค่าผลลัพธ์ของสูตรที่คำนวณล่าสุด หากหลังจากโหลดงานนำเสนอข้อมูลแผนภูมิไม่ได้เปลี่ยนแปลง – [**ChartDataCell::getValue**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#getValue) จะส่งค่าที่เก็บไว้เมื่ออ่านค่า แต่หากข้อมูลสเปรดชีตถูกเปลี่ยนแปลง ในระหว่างการอ่านค่า ระบบจะโยนข้อยกเว้น [**CellUnsupportedDataException**](https://reference.aspose.com/slides/th/php-java/aspose.slides/CellUnsupportedDataException) สำหรับสูตรที่ไม่รองรับ นั่นเป็นเพราะเมื่อสูตรถูกแยกวิเคราะห์สำเร็จ การกำหนดความขึ้นต่อกันของเซลล์จะถูกระบุและความถูกต้องของค่าที่สุดท้ายจะได้รับการตรวจสอบ แต่หากสูตรไม่สามารถแยกวิเคราะห์ได้ ความถูกต้องของค่าของเซลล์จะไม่สามารถรับประกันได้  

## **เพิ่มสูตรสเปรดชีตของแผนภูมิในงานนำเสนอ**
ขั้นแรกให้เพิ่มแผนภูมิไปยังสไลด์แรกของงานนำเสนอใหม่ด้วยเมธอด  
[ShapeCollection::addChart](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addChart)  
Worksheet ของแผนภูมิจะแสดงขึ้นโดยอัตโนมัติและสามารถเข้าถึงได้ด้วยเมธอด  
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#getChartDataWorkbook) :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

มาเขียนค่าบางอย่างลงในเซลล์ด้วยเมธอด  
[**ChartDataCell::setValue**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setValue) ของประเภท **Object** ซึ่งหมายความว่าคุณสามารถกำหนดค่าใดก็ได้:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

ตอนนี้เพื่อเขียนสูตรลงในเซลล์ คุณสามารถใช้เมธอด  
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setFormula)  

*Note*: เมธอด [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setFormula) ใช้สำหรับกำหนดการอ้างอิงเซลล์แบบ A1‑style  

เพื่อกำหนดสูตรแบบ R1C1 คุณสามารถใช้เมธอด [**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setR1C1Formula)  

จากนั้นหากคุณลองอ่านค่าจากเซลล์ B2 และ C2 ค่าจะถูกคำนวณออกมา:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **ค่าคงที่ตรรกะ**
คุณสามารถใช้ค่าคงที่ตรรกะเช่น *FALSE* และ *TRUE* ในสูตรของเซลล์ได้:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// ค่าที่ได้เป็นบูลีน "false"


```

## **ค่าคงที่เชิงตัวเลข**
สามารถใช้ตัวเลขในรูปแบบทั่วไปหรือรูปแบบเชิงวิทยาศาสตร์เพื่อสร้างสูตรสเปรดชีตของแผนภูมิได้:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **ค่าคงที่สตริง**
ค่าคงที่สตริง (หรือ literal) คือค่าที่ใช้ตามที่เป็นและไม่เปลี่ยนแปลง ค่าคงที่สตริงอาจเป็น: วันที่, ข้อความ, ตัวเลข ฯลฯ:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **ค่าคงที่ข้อผิดพลาด**
บางครั้งสูตรไม่สามารถคำนวณผลลัพธ์ได้ ในกรณีนั้น รหัสข้อผิดพลาดจะแสดงในเซลล์แทนค่าปกติ แต่ละประเภทของข้อผิดพลาดมีรหัสเฉพาะ:

- #DIV/0! – สูตรพยายามหารด้วยศูนย์
- #GETTING_DATA – อาจปรากฏบนเซลล์ขณะที่ค่ากำลังคำนวณอยู่
- #N/A – ข้อมูลหายหรือไม่พร้อมใช้งาน สาเหตุอาจเป็น: เซลล์ที่ใช้ในสูตรว่างเปล่า, มีอักขระช่องว่างเพิ่ม, ตัวสะกดผิด ฯลฯ
- #NAME? – ไม่พบเซลล์หรือวัตถุสูตรด้วยชื่อนั้น
- #NULL! – เกิดขึ้นเมื่อสูตรมีข้อผิดพลาด เช่น (,) หรือมีอักขระช่องว่างแทนเครื่องหมายโคลอน (:)
- #NUM! – ตัวเลขในสูตรอาจไม่ถูกต้อง ยาวเกินไป หรือสั้นเกินไป ฯลฯ
- #REF! – การอ้างอิงเซลล์ไม่ถูกต้อง
- #VALUE! – ชนิดค่าที่ไม่คาดคิด ตัวอย่างเช่น มีค่าสตริงใส่ในเซลล์ตัวเลข

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// ค่าที่ได้เป็นสตริง "#DIV/0!"


```

## **ตัวดำเนินการคณิตศาสตร์**
คุณสามารถใช้ตัวดำเนินการคณิตศาสตร์ทั้งหมดในสูตร worksheet ของแผนภูมิได้:

|**Operator**|**Meaning**|**Example**|
| :- | :- | :- |
|+ (plus sign)|Addition or unary plus|2 + 3|
|- (minus sign)|Subtraction or negation|2 - 3<br>-3|
|* (asterisk)|Multiplication|2 * 3|
|/ (forward slash)|Division|2 / 3|
|% (percent sign)|Percent|30%|
|^ (caret)|Exponentiation|2 ^ 3|

*Note*: เพื่อเปลี่ยนลำดับการประมวลผล ให้ใส่วงเล็บครอบส่วนของสูตรที่ต้องการคำนวณก่อน

## **ตัวดำเนินการเปรียบเทียบ**
คุณสามารถเปรียบเทียบค่าของเซลล์ด้วยตัวดำเนินการเปรียบเทียบ เมื่อตัวดำเนินการเหล่านี้เปรียบเทียบค่า ผลลัพธ์จะเป็นค่าตรรกะ *TRUE* หรือ FALSE:

|**Operator**|**Meaning**|**Meaning**|
| :- | :- | :- |
|= (equal sign)|Equal to|A2 = 3|
|<> (not equal sign)|Not equal to|A2 <> 3|
|> (greater than sign)|Greater than|A2 > 3|
|>= (greater than or equal to sign)|Greater than or equal to|A2 >= 3|
|< (less than sign)|Less than|A2 < 3|
|<= (less than or equal to sign)|Less than or equal to|A2 <= 3|

## **การอ้างอิงเซลล์แบบ A1‑Style**
**A1‑style cell references** ใช้สำหรับ worksheet ที่คอลัมน์มีตัวอักษรเป็นตัวระบุ (เช่น "*A*") และแถวมีตัวเลขเป็นตัวระบุ (เช่น "*1*") การอ้างอิงแบบ A1‑style สามารถใช้ได้ตามรูปแบบต่อไปนี้:

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||Absolute|Relative|Mixed|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


ตัวอย่างการใช้การอ้างอิงเซลล์แบบ A1‑style ในสูตร:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **การอ้างอิงเซลล์แบบ R1C1‑Style**
**R1C1‑style cell references** ใช้สำหรับ worksheet ที่ทั้งแถวและคอลัมน์มีตัวเลขเป็นตัวระบุ การอ้างอิงแบบ R1C1‑style สามารถใช้ได้ตามรูปแบบต่อไปนี้:

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||Absolute|Relative|Mixed|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


ตัวอย่างการใช้การอ้างอิงเซลล์แบบ A1‑style ในสูตร:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **ฟังก์ชันที่กำหนดไว้ล่วงหน้า**
มีฟังก์ชันที่กำหนดไว้ล่วงหน้า ที่สามารถใช้ในสูตรเพื่อความง่ายในการใช้งาน ฟังก์ชันเหล่านี้สรุปการทำงานที่ใช้บ่อยที่สุด เช่น:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (ระบบวันที่ 1900)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**สูตรแผนภูมิสามารถอ้างอิงไฟล์ Excel ภายนอกเป็นแหล่งข้อมูลได้หรือไม่?**

ใช่ Aspose.Slides รองรับ workbook ภายนอกเป็น [chart's data source](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatasourcetype/) ซึ่งทำให้คุณสามารถใช้สูตรจากไฟล์ XLSX นอกงานนำเสนอได้

**สูตรของแผนภูมิสามารถอ้างอิงแผ่นงานภายใน workbook เดียวกันตามชื่อแผ่นได้หรือไม่?**

ใช่ สูตรจะทำตามโมเดลการอ้างอิงของ Excel มาตรฐาน ดังนั้นคุณสามารถอ้างอิงแผ่นงานอื่นใน workbook เดียวกันหรือ workbook ภายนอกได้ สำหรับการอ้างอิงภายนอกให้ระบุเส้นทางและชื่อ workbook ตามไวยากรณ์ของ Excel
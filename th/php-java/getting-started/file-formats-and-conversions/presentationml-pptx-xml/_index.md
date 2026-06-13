---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /th/php-java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML คือชื่อของกลุ่มรูปแบบที่อิง XML สำหรับเอกสารการนำเสนอ Office OpenXML (OOXML) เป็นรูปแบบที่ใช้อิง XML ซึ่งถูกแนะนำในแอปพลิเคชัน Microsoft Office 2007 Office OpenXML เป็นรูปแบบคอนเทนเนอร์สำหรับหลายภาษา markup ที่อิง XML พิเศษ PresentationML คือภาษา markup ที่ Microsoft Office PowerPoint 2007 ใช้เพื่อเก็บเอกสาร

{{% /alert %}} 

## **PresentationML ใน Aspose.Slides for PHP via Java**
เอกสาร OOXML PresentationML จะมาเป็นไฟล์ PPTX ซึ่งเป็นแพ็คเกจ XML ที่บีบอัดตามสเปค [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) Aspose.Slides for PHP via Java รองรับการสร้าง การอ่าน การจัดการและการเขียนเอกสาร PresentationML อย่างครอบคลุม นอกจากนี้ Aspose.Slides for PHP via Java ยังสามารถส่งออกเอกสาร PresentationML ไปเป็นรูปแบบเอกสารที่ใช้กันอย่างแพร่หลายเช่น PDF ได้ สิ่งนี้เป็นไปได้เพราะ Aspose.Slides for PHP via Java ถูกออกแบบมาเพื่อจัดการเอกสารการนำเสนออย่างเต็มรูปแบบและ PresentationML เก็บข้อมูลการนำเสนอของเอกสารเป็นแพ็คเกจ XML ที่บีบอัด

**เอกสาร PPTX ที่สร้างโดย Aspose.Slides for PHP via Java และเปิดใน Microsoft PowerPoint**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**ดูไฟล์ PPTX เดียวกันที่สร้างโดย Aspose.Slides for PHP via Java ในรูปแบบ ZIP**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML เป็นแบบเปิด ทำไมต้องใช้ Aspose.Slides for PHP via Java?**
เนื่องจาก PresentationML เป็น XML จึงสามารถสร้างแอปพลิเคชันเพื่อประมวลผลและสร้างเอกสาร PresentationML ด้วยคลาส XML ได้โดยไม่ต้องพึ่งพาไลบรารีคลาสของบุคคลที่สามเช่น Aspose.Slides for PHP via Java อย่างไรก็ตาม การใช้ Aspose.Slides for PHP via Java มีข้อได้เปรียบหลายประการเมื่อเทียบกับการใช้คลาส XML ในการทำงานกับเอกสาร PresentationML

สเปค OOXML มีความยาวหลายพันหน้า ดังนั้นการจัดการเอกสาร PresentationML อย่างถูกต้องต้องใช้เวลาและความพยายามอย่างมากในการทำความเข้าใจรูปแบบ ในอีกฝ่ายหนึ่งด้วย Aspose.Slides for PHP via Java คุณเพียงแค่ใช้คลาสและเมธอดรวมถึงพร็อพเพอร์ตีต่าง ๆ เพื่อทำการดำเนินการที่ดูซับซ้อนหากทำด้วยคลาส XML

คุณสมบัติบางอย่างที่ Aspose.Slides มีให้ยังไม่มีให้ใช้เมื่อทำงานกับเอกสาร PresentationML ผ่านคลาส XML:

- ส่งออกไฟล์ PPT ไปเป็นรูปแบบ PDF
- เรนเดอร์สไลด์เป็นรูปภาพใด ๆ ที่รองรับโดย Java Framework
- คัดลอกมาสเตอร์จากงานนำเสนอต้นฉบับโดยอัตโนมัติด้วยฟีเจอร์การคล cloning
- ใช้การป้องกันกับรูปร่าง

ด้านล่างเป็นตัวอย่างเอกสาร PresentationML ที่มีสไลด์เดียวซึ่งมีกล่องข้อความที่มีข้อความ “Hello World” เพื่อนำข้อความออกโดยใช้คลาส XML คุณต้องเขียนโปรแกรมเพื่อพาร์สข้อความง่าย ๆ นี้จากส่วนย่อยต่อไปนี้ Aspose.Slides ทำให้คุณทำได้โดยอัตโนมัติ

**XML**

``` xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">
  <p:cSld>
    <p:spTree>
      <p:nvGrpSpPr>
        <p:cNvPr id="1" name=""/>
        <p:cNvGrpSpPr/>
        <p:nvPr/>
      </p:nvGrpSpPr>
      <p:grpSpPr>
        <a:xfrm>
          <a:off x="0" y="0"/>
          <a:ext cx="0" cy="0"/>
          <a:chOff x="0" y="0"/>
          <a:chExt cx="0" cy="0"/>
        </a:xfrm></p:grpSpPr><p:sp>
          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>
          <p:cNvSpPr txBox="1"/>
            <p:nvPr/>
          </p:nvSpPr>
          <p:spPr>
            <a:xfrm>
              <a:off x="2819400" y="2590800"/>
              <a:ext cx="1297086" cy="369332"/>
            </a:xfrm>
            <a:prstGeom prst="rect">
              <a:avLst/>
            </a:prstGeom>
            <a:noFill/>
          </p:spPr>
          <p:txBody>
            <a:bodyPr wrap="none" rtlCol="0">
              <a:spAutoFit/>
            </a:bodyPr>
            <a:lstStyle/>
            <a:p>
              <a:r>
                <a:rPr lang="en-US"/>
                <a:t>Hello World
                </a:t>
              </a:r>
              <a:endParaRPr lang="en-US"/>
            </a:p>
          </p:txBody>
        </p:sp>
    </p:spTree>
  </p:cSld>
  <p:clrMapOvr>
    <a:masterClrMapping/>
  </p:clrMapOvr>
</p:sld>
```php

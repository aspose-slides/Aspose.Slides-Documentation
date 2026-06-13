---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /th/java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 
PresentationML คือชื่อของตระกูลรูปแบบที่ใช้ XML สำหรับเอกสารการนำเสนอ Office OpenXML (OOXML) คือรูปแบบที่ใช้ XML ที่แนะนำในแอปพลิเคชัน Microsoft Office 2007 Office OpenXML เป็นรูปแบบคอนเทนเนอร์สำหรับหลายภาษามาร์กอัปที่ใช้ XML พิเศษ PresentationML คือภาษามาร์กอัปที่ Microsoft Office PowerPoint 2007 ใช้เพื่อเก็บเอกสาร
{{% /alert %}} 

## **PresentationML ใน Aspose.Slides สำหรับ Java**
เอกสาร OOXML PresentationML จะอยู่ในรูปแบบไฟล์ PPTX ซึ่งเป็นแพคเกจ XML ที่บีบอัดและเป็นไปตามข้อกำหนดของ [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) Aspose.Slides สำหรับ Java รองรับอย่างกว้างขวางในการสร้าง, อ่าน, ดัดแปลงและเขียนเอกสาร PresentationML นอกจากนี้ Aspose.Slides สำหรับ Java ยังสามารถส่งออกเอกสาร PresentationML ไปยังรูปแบบเอกสารที่ใช้กันอย่างกว้างขวางเช่น PDF สิ่งนี้เป็นไปได้เพราะ Aspose.Slides สำหรับ Java ถูกออกแบบด้วยเป้าหมายเพื่อจัดการเอกสารการนำเสนออย่างครบถ้วนและ PresentationML เก็บการนำเสนอภายในของเอกสารเป็นแพคเกจ XML ที่บีบอัด

**เอกสาร PPTX ที่สร้างโดย Aspose.Slides สำหรับ Java และเปิดใน Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**ดูเอกสาร PPTX เดียวกันที่สร้างโดย Aspose.Slides สำหรับ Java ในรูปแบบ ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML เป็นแบบเปิด, ทำไมต้องใช้ Aspose.Slides สำหรับ Java?**
เนื่องจาก PresentationML ใช้ XML ดังนั้นจึงสามารถสร้างแอปพลิเคชันเพื่อประมวลผลและสร้างเอกสาร PresentationML ด้วยคลาส XML ได้โดยไม่ต้องพึ่งพาไลบรารีคลาสของบุคคลที่สามเช่น Aspose.Slides สำหรับ Java อย่างไรก็ตาม มีข้อได้เปรียบหลายประการในการใช้ Aspose.Slides สำหรับ Java แทนการใช้คลาส XML เมื่อทำงานกับเอกสาร PresentationML

ข้อกำหนด OOXML มีหลายพันหน้า ดังนั้นเพื่อจัดการเอกสาร PresentationML อย่างถูกต้อง คุณต้องใช้เวลาและความพยายามอย่างมากในการเข้าใจรูปแบบนี้ อย่างไรก็ตาม ด้วย Aspose.Slides สำหรับ Java คุณเพียงใช้คลาสและเมธอดและพร็อพเพอร์ตี้ของมันเพื่อทำการดำเนินการที่ดูซับซ้อนหากทำผ่านคลาส XML

บางคุณลักษณะที่ Aspose.Slides มีให้ไม่ได้มีอยู่เลยเมื่อคุณทำงานกับเอกสาร PresentationML ผ่านคลาส XML:

- ส่งออกเอกสาร PPT ไปเป็นรูปแบบ PDF
- แสดงสไลด์เป็นรูปภาพในรูปแบบใดก็ได้ที่ Java Framework รองรับ
- คัดลอกมาสเตอร์จากงานนำเสนอแหล่งโดยอัตโนมัติด้วยฟีเจอร์การโคลน
- ใส่การป้องกันให้กับรูปร่าง

ต่อไปนี้เป็นตัวอย่างเอกสาร PresentationML ที่มีสไลด์เดียวซึ่งมีช่องข้อความที่มีข้อความ “Hello World”. เพื่ออ่านข้อความโดยใช้คลาส XML คุณต้องเขียนโปรแกรมที่สามารถแยกข้อความง่ายนี้จากส่วนย่อยต่อไปนี้ Aspose.Slides ทำให้คุณได้

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
```
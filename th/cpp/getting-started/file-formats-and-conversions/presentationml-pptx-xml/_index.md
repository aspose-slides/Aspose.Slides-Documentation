---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /th/cpp/presentationml-pptx-xml/
---
## **เกี่ยวกับ PresentationML**
PresentationML คือชื่อของตระกูลรูปแบบที่อิง XML สำหรับเอกสารการนำเสนอ. Office OpenXML (OOXML) เป็นรูปแบบที่อิง XML ที่แนะนำในแอปพลิเคชัน Microsoft Office 2007. Office OpenXML เป็นรูปแบบคอนเทนเนอร์สำหรับหลายภาษา markup ที่อิง XML แบบเฉพาะ. PresentationML เป็นภาษา markup ที่ใช้โดย Microsoft Office PowerPoint 2007 เพื่อเก็บเอกสารของมัน. 

## **PresentationML ใน Aspose.Slides for C++**
เอกสาร OOXML PresentationML จะอยู่ในรูปแบบไฟล์ PPTX ซึ่งเป็นแพ็กเกจ XML ที่บีบอัดตามข้อกำหนด [ข้อกำหนด OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) . Aspose.Slides for C++ รองรับอย่างเต็มที่ในการสร้าง, อ่าน, ปรับเปลี่ยนและเขียนเอกสาร PresentationML. นอกจากนี้ Aspose.Slides for C++ ยังสามารถส่งออกเอกสาร PresentationML ไปยังรูปแบบเอกสารที่ใช้กันอย่างกว้างขวางหลายรูปแบบ เช่น PDF, TIFF และ XPS. สิ่งนี้เป็นไปได้เพราะ Aspose.Slides for C++ ถูกออกแบบด้วยเป้าหมายเพื่อจัดการเอกสารการนำเสนออย่างครอบคลุมและ PresentationML โดยพื้นฐานแล้วถือเป็นการจัดเก็บการนำเสนอของเอกสารเป็นแพ็กเกจ XML ที่บีบอัด. 

## **PresentationML เป็นแบบเปิด, ทำไมต้องใช้ Aspose.Slides for C++**
จากที่ PresentationML อิง XML ทำให้สามารถสร้างแอปพลิเคชันสำหรับประมวลผลและสร้างเอกสาร PresentationML โดยใช้คลาส XML ได้โดยไม่ต้องพึ่งพาไลบรารีคลาสของบุคคลที่สามเช่น Aspose.Slides for C++. อย่างไรก็ตาม มีข้อได้เปรียบหลายประการในการใช้ Aspose.Slides for C++ แทนคลาส XML ขณะทำงานกับเอกสาร PresentationML.  

ข้อกำหนด OOXML ยาวหลายพันหน้า ซึ่งหมายความว่าการจัดการเอกสาร PresentationML อย่างถูกต้องจำเป็นต้องใช้เวลามากและความพยายามในการทำความเข้าใจรูปแบบของเอกสารเหล่านั้น. ในทางกลับกันเมื่อต้องใช้ Aspose.Slides for C++ คุณเพียงแค่ใช้คลาสที่เกี่ยวข้องและเมธอด/พร็อพเพอร์ตีที่สอดคล้องกันเพื่อทำงานที่ดูซับซ้อนหากทำผ่านคลาส XML.  

ต่อไปนี้เป็นคุณลักษณะบางส่วนที่ยังไม่มีให้เมื่อจัดการเอกสาร PresentationML ผ่านคลาส XML:
- ส่งออกเอกสาร PPT ไปยังรูปแบบ PDF, TIFF, XPS
- ส่งออกสไลด์ในเอกสาร PPT ไปยังรูปแบบ SVG
- เรนเดอร์สไลด์เป็นรูปแบบภาพใด ๆ ที่รองรับโดย C++ Framework
- คัดลอกมาสเตอร์จากการนำเสนอแหล่งโดยอัตโนมัติด้วยฟีเจอร์การโคลน
- ใช้การป้องกันบนรูปร่าง  

ให้เราพิจารณาตัวอย่างของเอกสาร PresentationML ที่มีสไลด์เดียวที่มีกล่องข้อความหนึ่งเก็บข้อความ “Hello World”. เพื่ออ่านข้อความผ่านคลาส XML คุณจะต้องเขียนโปรแกรมที่สามารถแยกข้อความง่าย ๆ นี้จากส่วนย่อยต่อไปนี้: 

## **Example**


``` cpp

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
---
title: แปลงการนำเสนอเป็น HTML5 ใน PHP
linktitle: การนำเสนอเป็น HTML5
type: docs
weight: 40
url: /th/php-java/export-to-html5/
keywords:
- PowerPoint เป็น HTML5
- OpenDocument เป็น HTML5
- การนำเสนอเป็น HTML5
- สไลด์เป็น HTML5
- PPT เป็น HTML5
- PPTX เป็น HTML5
- ODP เป็น HTML5
- บันทึก PPT เป็น HTML5
- บันทึก PPTX เป็น HTML5
- บันทึก ODP เป็น HTML5
- ส่งออก PPT เป็น HTML5
- ส่งออก PPTX เป็น HTML5
- ส่งออก ODP เป็น HTML5
- PHP
- Aspose.Slides
description: "ส่งออกการนำเสนอ PowerPoint และ OpenDocument ไปยัง HTML5 แบบตอบสนองด้วย Aspose.Slides สำหรับ PHP ผ่าน Java. รักษาการจัดรูปแบบ, การเคลื่อนไหว, และการโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแปลงการนำเสนอ PowerPoint ให้อยู่ในรูปแบบ HTML5 ด้วย Aspose.Slides ครอบคลุมการส่งออก HTML5 พื้นฐานโดยไม่มีส่วนขยายเว็บหรือการพึ่งพาเพิ่มเติม รวมถึงตัวเลือกสำหรับการควบคุมการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ บทความยังแสดงกระบวนการส่งออกจาก PowerPoint ไปยัง HTML มาตรฐาน อธิบายวิธีการสร้างผลลัพธ์ HTML5 ในโหมดมุมมองสไลด์ และสาธิตวิธีการรวมคอมเมนต์ในเอกสารที่ส่งออกโดยการกำหนดค่าการจัดวางของมัน

## **ส่งออก PowerPoint ไปยัง HTML5**

โค้ด PHP นี้แสดงวิธีการส่งออกการนำเสนอเป็น HTML5 โดยไม่มีส่วนขยายเว็บและการพึ่งพา:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
ในกรณีนี้คุณจะได้ HTML ที่สะอาดเรียบร้อย 
{{% /alert %}}

คุณอาจต้องการระบุการตั้งค่าสำหรับการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ดังนี้:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ส่งออก PowerPoint ไปยัง HTML**

โค้ด Java นี้สาธิตกระบวนการส่งออก PowerPoint ไปยัง HTML มาตรฐาน:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

ในกรณีนี้เนื้อหาการนำเสนอจะถูกเรนเดอร์ผ่าน SVG ในรูปแบบดังต่อไปนี้:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="Note" color="warning" %}} 

When you use this method to export PowerPoint to HTML, due to the SVG rendering, you will not be to apply styles or animate specific elements. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** allows you to convert a PowerPoint presentation to an HTML5 document in which the slides are presented in a slide view mode. In this case, when you open the resulting HTML5 file in a browser, you see the presentation in slide view mode on a web page. 

This PHP code demonstrates the PowerPoint to HTML5 Slide View export process:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convert Presentations to HTML5 Documents with Comments**

Comments in PowerPoint are a tool that allows users to leave notes or feedback on presentation slides. They are especially useful in collaborative projects, where multiple people can add their suggestions or remarks to specific slide elements without altering the main content. Each comment shows the author's name, making it easy to track who left the remark.

Let's say we have the following PowerPoint presentation saved in the "sample.pptx" file.

![Two comments on the presentation slide](two_comments_pptx.png)

When you convert a PowerPoint presentation to an HTML5 document, you can easily specify whether to include comments from the presentation in the output document. To do this, you need to specify the display parameters for comments in the `getNotesCommentsLayouting` method of the `Html5Options` class.

The following code example converts a presentation to an HTML5 document with comments displayed to the right of the slides.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();

เอกสาร "output.html" จะแสดงในภาพด้านล่าง

![The comments in the output HTML5 document](two_comments_html5.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมว่าการเคลื่อนไหวของวัตถุและการเปลี่ยนสไลด์จะทำงานใน HTML5 หรือไม่?**

ได้, HTML5 มีตัวเลือกแยกต่างหากเพื่อเปิดหรือปิด [การเคลื่อนไหวของรูปร่าง](https://reference.aspose.com/slides/th/php-java/aspose.slides/html5options/setanimateshapes/) และ [การเปลี่ยนสไลด์](https://reference.aspose.com/slides/th/php-java/aspose.slides/html5options/setanimatetransitions/)  

**การสนับสนุนการส่งออกคอมเมนต์เป็นอย่างไรและสามารถวางตำแหน่งคอมเมนต์สัมพันธ์กับสไลด์ได้ที่ไหน?**

ได้, สามารถเพิ่มคอมเมนต์ใน HTML5 และกำหนดตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่าน [การตั้งค่าเลย์เอาต์](https://reference.aspose.com/slides/th/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) สำหรับโน๊ตและคอมเมนต์  

**ฉันสามารถข้ามลิงก์ที่เรียกใช้ JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?**

ได้, มี [การตั้งค่า](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) ที่ให้คุณข้ามไฮเปอร์ลิงก์ที่มีการเรียก JavaScript ระหว่างการบันทึก ซึ่งช่วยให้สอดคล้องกับนโยบายความปลอดภัยที่เข้มงวด
---
title: แปลงงานนำเสนอเป็น HTML5 บน Android
linktitle: งานนำเสนอเป็น HTML5
type: docs
weight: 40
url: /th/androidjava/export-to-html5/
keywords:
- PowerPoint ไปยัง HTML5
- OpenDocument ไปยัง HTML5
- งานนำเสนอไปยัง HTML5
- สไลด์ไปยัง HTML5
- PPT ไปยัง HTML5
- PPTX ไปยัง HTML5
- ODP ไปยัง HTML5
- บันทึก PPT เป็น HTML5
- บันทึก PPTX เป็น HTML5
- บันทึก ODP เป็น HTML5
- ส่งออก PPT เป็น HTML5
- ส่งออก PPTX เป็น HTML5
- ส่งออก ODP เป็น HTML5
- Android
- Java
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint & OpenDocument ไปเป็น HTML5 ที่ตอบสนองได้ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. รักษาการจัดรูปแบบ, แอนิเมชัน, และความโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint ไปเป็น HTML5 โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java ซึ่งครอบคลุมการส่งออกพื้นฐาน การควบคุมการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ รวมถึงการจัดวางความคิดเห็น และยังเปรียบเทียบผลลัพธ์ HTML5 กับผลลัพธ์ที่อิง SVG ของการส่งออก HTML มาตรฐาน

## **ส่งออก PowerPoint ไปยัง HTML5**

ตัวอย่างต่อไปนี้โหลดงานนำเสนอจากไดเรกทอรีทำงานและบันทึกเป็นรูปแบบ HTML5 ใช้การตั้งค่าการส่งออกเริ่มต้น; ตัวอย่างถัดไปจะแสดงวิธีควบคุมการเล่นแอนิเมชันอย่างชัดเจน ให้เปลี่ยนเส้นทางอินพุตเป็นเส้นทางไปยังงานนำเสนอของคุณ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
นอกจากเอกสาร HTML แล้ว การส่งออกยังเขียนไฟล์ CSS และ JavaScript ที่สนับสนุนสำหรับการจัดรูปแบบสไลด์ แอนิเมชัน เอฟเฟกต์ และการนำทาง ควรเก็บไฟล์เหล่านี้ไว้กับเอกสาร HTML เมื่อย้ายหรือเผยแพร่ผลลัพธ์ หน้าเว็บที่สร้างขึ้นยังโหลด jQuery และ Anime.js จาก CDN สาธารณะ; หากไม่มีไฟล์เหล่านี้ การนำทางสไลด์และแอนิเมชันจะไม่ทำงาน
{{% /alert %}}

เพื่อส่งออกโดยไม่เล่นแอนิเมชันของรูปร่างหรือการเปลี่ยนสไลด์ ให้ส่งค่า `false` ไปยัง [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) ใน [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). การตั้งค่าเหล่านี้เป็นอิสระกัน ดังนั้นคุณสามารถเปิดใช้งานอันหนึ่งในขณะที่ปิดอีกอันได้ ตัวอย่างนี้ส่งออกงานนำเสนอโดยปิดการทำงานของแอนิเมชันทั้งสองประเภทในหน้าที่สร้างขึ้น

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **ส่งออก PowerPoint ไปยัง HTML**

การส่งออก HTML มาตรฐานใช้วิธีการเรนเดอร์ที่แตกต่าง: เนื้อหาสไลด์จะแสดงเป็น SVG ภายในหน้า HTML ตัวอย่างต่อไปนี้จะแปลงงานนำเสนอเป็นเอกสาร HTMLโดยใช้วิธีการเรนเดอร์นี้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

มาร์คอัปที่เรียบง่ายด้านล่างแสดงโครงสร้างของหน้าที่สร้างขึ้น ส่วนประกอบ SVG จะบรรจุเนื้อหาสไลด์ที่เรนเดอร์; ข้อความตัวแทนเป็นเพียงตัวอย่างของเนื้อหานั้นและไม่ใช่ผลลัพธ์การส่งออกจริง

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
การส่งออกแบบอิง SVG ไม่เปิดเผยรูปร่างของ PowerPoint เป็นองค์ประกอบ HTML แยกเดี่ยว ใช้การส่งออก HTML5 เมื่อคุณต้องการตัวเลือกการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ที่อธิบายในบทความนี้
{{% /alert %}}

## **ส่งออก PowerPoint ไปยังมุมมองสไลด์ HTML5**

การส่งออก HTML5 จะสร้างหน้าเว็บสำหรับการดูและนำทางสไลด์ของงานนำเสนอในเบราว์เซอร์ ตัวอย่างนี้เปิดใช้งานทั้ง [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) เพื่อให้มุมมองสไลด์ที่ส่งออกสามารถเล่นเอฟเฟกต์จากงานนำแหล่งได้

ใช้งานนำเสนอที่มีการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์อยู่แล้วเพื่อดูผลของการตั้งค่าเหล่านี้ การเปิดใช้งานไม่ทำให้สไลด์ที่ไม่มีเอฟเฟกต์ใด ๆ เพิ่มเอฟเฟกต์ใหม่ หลังจากการส่งออก ให้เปิดเอกสาร HTML5 ที่สร้างขึ้นในเบราว์เซอร์พร้อมไฟล์สนับสนุนที่พร้อมใช้งาน

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **แปลงงานนำเสนอเป็นเอกสาร HTML5 พร้อมความคิดเห็น**

คุณสามารถรวมความคิดเห็นของสไลด์ที่มีอยู่ในผลลัพธ์ HTML5 เพื่อให้ผู้อ่านเห็นข้อเสนอแนะพร้อมกับเนื้อหาสไลด์ ตัวอย่างในส่วนนี้คาดว่าภาพนำแหล่งมีความคิดเห็นตามที่แสดงด้านล่าง จะส่งออกความคิดเห็นเหล่านั้น; ไม่ได้สร้างใหม่

![สองความคิดเห็นบนสไลด์งานนำเสนอ](two_comments_pptx.png)

ส่งออบเจกต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) ไปยังเมธอด [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) ของ [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). ใช้ [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) เพื่อเลือก `Right` จาก enumeration [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) เพื่อวางความคิดเห็นทางด้านขวาของแต่ละสไลด์

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น HTML5 พร้อมเค้าโครงความคิดเห็นนี้ งานนำเสนอที่ไม่มีความคิดเห็นจะไม่มีข้อความความคิดเห็นให้แสดง

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![ความคิดเห็นในเอกสาร HTML5 ที่ส่งออก](two_comments_html5.png)

## **ยกเว้นลิงก์ JavaScript ระหว่างการส่งออก**

สมมติว่า `hyperlinks.pptx` มีข้อความที่ลิงก์กับเป้าหมาย `javascript:alert('Hello')` และลิงก์ธรรมดา `https://example.com/` เพื่อยกเว้นลิงก์ JavaScript ระหว่างการส่งออก ให้ส่งค่า `true` ไปยัง [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). ค่าเริ่มต้นคือ `false` ดังนั้นลิงก์เหล่านี้จะไม่ถูกกรองจนกว่าคุณจะเปิดใช้ตัวเลือก

ตัวอย่างต่อไปนี้โหลดงานนำเสนอจากไดเรกทอรีทำงานและส่งออกโดยใช้ [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

ไฟล์ที่ส่งออกจะละเว้นลิงก์ JavaScript แต่ยังคงเก็บข้อความและลิงก์ HTTPS ธรรมดาไว้ งานนำเสนอแหล่งที่มาจะไม่เปลี่ยนแปลง

ตัวเลือกนี้กรองลิงก์ JavaScript; แต่ไม่ได้ลบสคริปต์ทั้งหมดหรือเนื้อหาใช้งานอื่น ๆ และไม่รับประกันการปฏิบัติตาม CSP ตัวอย่างเช่น ผลลัพธ์ HTML5 ยังคงมีสคริปต์สำหรับการนำทางสไลด์และแอนิเมชัน

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมได้หรือไม่ว่าแอนิเมชันของวัตถุและการเปลี่ยนสไลด์จะเล่นใน HTML5 หรือไม่?**

ใช่, การส่งออก HTML5 มีตัวเลือกแยกกันเพื่อเปิดหรือปิด [การเคลื่อนไหวของรูปร่าง](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [การเปลี่ยนสไลด์](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**ความคิดเห็นได้รับการสนับสนุนหรือไม่ และสามารถวางไว้ที่ตำแหน่งใดสัมพันธ์กับสไลด์?**

ใช่, ความคิดเห็นที่มีอยู่สามารถรวมไว้ในผลลัพธ์ HTML5 และจัดตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่าน [การตั้งค่าเค้าโครง](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) สำหรับโน้ตและความคิดเห็น.

**ฉันสามารถข้ามลิงก์ที่เรียกใช้ JavaScript เพื่อความปลอดภัยหรือเหตุผลของ CSP ได้หรือไม่?**

ใช่, การตั้งค่า [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ทำให้คุณสามารถข้ามลิงก์ที่มีการเรียกใช้ JavaScript ระหว่างการบันทึก ค่าเริ่มต้นคือ `false`. ดู [ยกเว้นลิงก์ JavaScript ระหว่างการส่งออก](/slides/th/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) สำหรับตัวอย่างการส่งออก HTML5 และขอบเขตของการกรอง ตัวเลือกนี้ไม่ลบ JavaScript ที่ใช้โดยตัวดู HTML5 สำหรับการนำทางและแอนิเมชัน.
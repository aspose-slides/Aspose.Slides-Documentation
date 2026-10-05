---
title: แปลงการนำเสนอเป็น HTML5 ด้วย Java
linktitle: การนำเสนอเป็น HTML5
type: docs
weight: 40
url: /th/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "ส่งออกการนำเสนอ PowerPoint และ OpenDocument ไปเป็น HTML5 ที่ตอบสนองได้ด้วย Aspose.Slides for Java. รักษาการจัดรูปแบบ, แอนิเมชัน, และการโต้ตอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint ไปเป็น HTML5 โดยใช้ Aspose.Slides for Java ครอบคลุมการส่งออกพื้นฐาน การควบคุมการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์ รวมถึงการจัดเลย์เอาต์ของความคิดเห็น นอกจากนี้ยังเปรียบเทียบผลลัพธ์ HTML5 กับผลลัพธ์แบบ SVG ของการส่งออก HTML มาตรฐาน

## **ส่งออก PowerPoint ไปยัง HTML5**

ตัวอย่างต่อไปนี้โหลดงานนำเสนอจากไดเรกทอรีทำงานและบันทึกเป็นรูปแบบ HTML5 ใช้การตั้งค่าการส่งออกค่าเริ่มต้น; ตัวอย่างถัดไปจะแสดงวิธีควบคุมการเล่นแอนิเมชันอย่างชัดเจน แทนที่เส้นทางอินพุตด้วยเส้นทางไปยังงานนำเสนอของคุณ

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
นอกจากเอกสาร HTML แล้ว การส่งออกยังเขียนไฟล์ CSS และ JavaScript ที่สนับสนุนสำหรับการจัดรูปแบบสไลด์ แอนิเมชัน เอฟเฟ็กต์และการนำทาง ควรเก็บไฟล์เหล่านี้ไว้พร้อมกับเอกสาร HTML เมื่อย้ายหรือเผยแพร่ผลลัพธ์ หน้าเพจที่สร้างขึ้นยังโหลด jQuery และ Anime.js จาก CDN สาธารณะ; หากไม่มีไฟล์เหล่านี้ การนำทางและแอนิเมชันของสไลด์จะไม่ทำงาน
{{% /alert %}}

เพื่อส่งออกโดยไม่เล่นการเคลื่อนไหวของรูปร่างหรือการเปลี่ยนสไลด์ ให้ส่งค่า `false` ไปยัง [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) ใน [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) การตั้งค่าเหล่านี้เป็นอิสระต่อกัน ดังนั้นคุณสามารถเปิดใช้งานอันหนึ่งขณะปิดอันอื่น ตัวอย่างนี้ส่งออกงานนำเสนอโดยปิดการเคลื่อนไหวทั้งสองประเภทในหน้าเพจที่สร้างขึ้น

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

การส่งออก HTML มาตรฐานใช้วิธีการเรนเดอร์ที่แตกต่าง: เนื้อหาของสไลด์จะแสดงเป็น SVG ภายในหน้า HTML ตัวอย่างต่อไปนี้แปลงงานนำเสนอเป็นเอกสาร HTML ด้วยวิธีการเรนเดอร์นี้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

มาร์กอัปแบบง่ายด้านล่างแสดงโครงสร้างของหน้าเพจที่สร้างขึ้น องค์ประกอบ SVG ประกอบด้วยเนื้อหาสไลด์ที่เรนเดอร์; ข้อความตัวแทนเป็นเพียงข้อความแทนที่และไม่ได้เป็นผลลัพธ์การส่งออกจริง

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
การส่งออกแบบ SVG ไม่เปิดเผยรูปร่าง PowerPoint เป็นองค์ประกอบ HTML แยกส่วน ใช้การส่งออก HTML5 เมื่อคุณต้องการตัวเลือกการเคลื่อนไหวของรูปทรงและการเปลี่ยนสไลด์ที่อธิบายในบทความนี้
{{% /alert %}}

## **ส่งออก PowerPoint ไปยังมุมมองสไลด์ HTML5**

การส่งออก HTML5 สร้างหน้าเว็บสำหรับดูและนำทางสไลด์ของงานนำเสนอในเบราว์เซอร์ ตัวอย่างนี้เปิดใช้งานทั้ง [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) เพื่อให้มุมมองสไลด์ที่ส่งออกสามารถเล่นเอฟเฟ็กต์จากงานนำแหล่งได้

ใช้งานนำเสนอที่มีการเคลื่อนไหวของรูปร่างและการเปลี่ยนสไลด์อยู่แล้วเพื่อดูผลของการตั้งค่าเหล่านี้ การเปิดใช้งานไม่เพิ่มเอฟเฟ็กต์ใหม่ให้สไลด์ที่ไม่มีเอฟเฟ็กต์ หลังจากส่งออกให้เปิดเอกสาร HTML5 ที่สร้างขึ้นในเบราว์เซอร์พร้อมไฟล์สนับสนุนที่พร้อมใช้งาน

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

คุณสามารถรวมความคิดเห็นของสไลด์ที่มีอยู่ในผลลัพธ์ HTML5 เพื่อให้ผู้อ่านเห็นข้อเสนอแนะข้างเนื้อหาสไลด์ ตัวอย่างในส่วนนี้คาดว่างานนำแหล่งจะมีความคิดเห็นตามที่แสดงด้านล่าง จะส่งออกความคิดเห็นเหล่านั้น; ไม่ได้สร้างใหม่

![ความคิดเห็นสองข้อบนสไลด์งานนำเสนอ](two_comments_pptx.png)

ส่งอ็อบเจกต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) ไปยังเมธอด [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) ของ [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) ใช้ [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) เพื่อเลือกค่า `Right` จากการนับประเภท [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) เพื่อวางความคิดเห็นทางด้านขวาของแต่ละสไลด์

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น HTML5 พร้อมการจัดเลย์เอาต์ของความคิดเห็น งานนำเสนอที่ไม่มีความคิดเห็นจะไม่มีข้อความแสดงความคิดเห็นให้แสดง

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

รูปภาพด้านล่างแสดงเอกสาร HTML5 ที่ส่งออกพร้อมความคิดเห็นที่แสดงข้างสไลด์

![ความคิดเห็นในเอกสาร HTML5 ที่ส่งออก](two_comments_html5.png)

## **ยกเว้นไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก**

สมมติว่า `hyperlinks.pptx` มีข้อความที่เชื่อมโยงกับเป้าหมาย `javascript:alert('Hello')` และลิงก์ธรรมดา `https://example.com/` เพื่อยกเว้นไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก ให้ส่งค่า `true` ไปยัง [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ค่าเริ่มต้นคือ `false` ดังนั้นลิงก์เหล่านี้จะไม่ถูกกรองจนกว่าคุณจะเปิดใช้งานตัวเลือก

ตัวอย่างต่อไปนี้โหลดงานนำเสนอจากไดเรกทอรีทำงานและส่งออกโดยใช้ [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/):

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

ไฟล์ที่ส่งออกจะละเลยไฮเปอร์ลิงก์ JavaScript แต่ยังคงข้อความของมันและลิงก์ HTTPS ธรรมดา งานนำแหล่งไม่ถูกเปลี่ยนแปลง

ตัวเลือกนี้กรองไฮเปอร์ลิงก์ JavaScript; ไม่ได้ลบสคริปต์ทั้งหมดหรือเนื้อหาแอคทีฟอื่นๆ และไม่ได้รับประกันการปฏิบัติตาม CSP ตัวอย่างเช่น ผลลัพธ์ HTML5 ยังคงรวมสคริปต์สำหรับการนำทางสไลด์และแอนิเมชัน

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมได้หรือไม่ว่าการเคลื่อนไหวของวัตถุและการเปลี่ยนสไลด์จะเล่นใน HTML5?**

ใช่, การส่งออก HTML5 มีตัวเลือกแยกต่างหากเพื่อเปิดหรือปิด [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**ความคิดเห็นได้รับการสนับสนุนหรือไม่ และสามารถวางตำแหน่งสัมพันธ์กับสไลด์ได้ที่ไหน?**

ใช่, ความคิดเห็นที่มีอยู่สามารถรวมในผลลัพธ์ HTML5 และตำแหน่ง (เช่น ทางขวาของสไลด์) ผ่าน [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) สำหรับบันทึกย่อและความคิดเห็น

**ฉันสามารถข้ามลิงก์ที่เรียกใช้ JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?**

ใช่, การตั้งค่า [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ให้คุณข้ามไฮเปอร์ลิงก์ที่มีการเรียก JavaScript ระหว่างการบันทึก ค่าเริ่มต้นคือ `false` ดู [ยกเว้นไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก](/slides/th/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) สำหรับตัวอย่างการส่งออก HTML5 และขอบเขตของตัวกรอง การตั้งค่านี้ไม่ได้ลบ JavaScript ที่ใช้โดยตัวดู HTML5 สำหรับการนำทางและแอนิเมชัน.
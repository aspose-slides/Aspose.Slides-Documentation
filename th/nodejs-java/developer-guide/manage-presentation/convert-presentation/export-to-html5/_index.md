---
title: แปลงพรีเซนเทชันเป็น HTML5 ด้วย JavaScript
linktitle: พรีเซนเทชันเป็น HTML5
type: docs
weight: 40
url: /th/nodejs-java/export-to-html5/
keywords:
  - PowerPoint เป็น HTML5
  - OpenDocument เป็น HTML5
  - พรีเซนเทชันเป็น HTML5
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
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "ส่งออกพรีเซนเทชัน PowerPoint และ OpenDocument เป็น HTML5 ที่ตอบสนองต่ออุปกรณ์ด้วย Aspose.Slides สำหรับ Node.js เก็บรูปแบบ, แอนิเมชัน, และการโต้ตอบไว้"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแปลงไฟล์พรีเซนเทชัน PowerPoint ไปเป็น HTML5 ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java มันครอบคลุมการส่งออกพื้นฐาน การควบคุมแอนิเมชันของรูปทรงและการเปลี่ยนสไลด์ รวมถึงการจัดวางคอมเมนต์ นอกจากนี้ยังเปรียบเทียบผลลัพธ์ HTML5 กับผลลัพธ์แบบ SVG ของการส่งออก HTML มาตรฐาน

## **ส่งออก PowerPoint เป็น HTML5**

ตัวอย่างต่อไปนี้โหลดพรีเซนเทชันจากไดเรกทอรีทำงานและบันทึกเป็นรูปแบบ HTML5 โดยใช้การตั้งค่าส่งออกเริ่มต้น; ตัวอย่างถัดไปจะแสดงวิธีการควบคุมการเล่นแอนิเมชันอย่างชัดเจน แทนที่เส้นทางอินพุตด้วยเส้นทางของพรีเซนเทชันของคุณ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
นอกจากเอกสาร HTML แล้ว การส่งออกจะเขียนไฟล์ CSS และ JavaScript ที่สนับสนุนสำหรับการจัดสไตล์สไลด์, แอนิเมชัน, เอฟเฟกต์ และการนำทาง ให้เก็บไฟล์เหล่านี้ไว้พร้อมกับเอกสาร HTML เมื่อย้ายหรือเผยแพร่ผลลัพธ์ หน้าเว็บที่สร้างขึ้นยังโหลด jQuery และ Anime.js จาก CDN สาธารณะ; หากไม่มีไฟล์เหล่านี้ การนำทางสไลด์และแอนิเมชันจะไม่ทำงาน
{{% /alert %}}

หากต้องการส่งออกโดยไม่เล่นแอนิเมชันรูปทรงหรือการเปลี่ยนสไลด์ ให้ส่งค่า `false` ไปยัง [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) และ [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) ใน [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). การตั้งค่าเหล่านี้เป็นอิสระต่อกัน ดังนั้นคุณสามารถเปิดใช้งานหนึ่งขณะปิดอีกหนึ่งได้ ตัวอย่างนี้ส่งออกพรีเซนเทชันโดยปิดการทำงานของแอนิเมชันทั้งสองประเภทในหน้าเว็บที่สร้างขึ้น

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **ส่งออก PowerPoint เป็น HTML**

การส่งออก HTML ปกติใช้แนวทางการเรนเดอร์ที่แตกต่างกัน: เนื้อหาสไลด์จะแสดงเป็น SVG ภายในหน้า HTML ตัวอย่างต่อไปนี้แปลงพรีเซนเทชันเป็นเอกสาร HTML ด้วยแนวทางการเรนเดอร์นี้

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

มาร์กอัปแบบง่ายด้านล่างแสดงโครงสร้างของหน้าที่สร้างขึ้น รายการ SVG จะบรรจุเนื้อหาสไลด์ที่เรนเดอร์; ข้อความตัวแทนเป็นเพียงตัวแทนของเนื้อหานั้นและไม่ใช่ผลลัพธ์การส่งออกจริง

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
การส่งออกแบบ SVG ไม่เปิดเผยรูปทรงของ PowerPoint เป็นองค์ประกอบ HTML แยกส่วน ใช้การส่งออก HTML5 เมื่อคุณต้องการตัวเลือกการแอนิเมชันรูปทรงและการเปลี่ยนสไลด์ที่แสดงในบทความนี้
{{% /alert %}}

## **ส่งออก PowerPoint เป็นมุมมองสไลด์ HTML5**

การส่งออก HTML5 สร้างหน้าสำหรับการดูและนำทางสไลด์ของพรีเซนเทชันในเบราว์เซอร์ ตัวอย่างนี้เปิดใช้ทั้ง [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) และ [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) เพื่อให้มุมมองสไลด์ที่ส่งออกสามารถเล่นเอฟเฟกต์จากพรีเซนเทชันต้นฉบับได้

ใช้พรีเซนเทชันที่มีแอนิเมชันรูปทรงและการเปลี่ยนสไลด์อยู่แล้วเพื่อดูผลของการตั้งค่าเหล่านี้ การเปิดใช้งานจะไม่เพิ่มเอฟเฟกต์ใหม่ให้กับสไลด์ที่ไม่มีเอฟเฟกต์ หลังจากการส่งออก เปิดเอกสาร HTML5 ที่สร้างขึ้นในเบราว์เซอร์พร้อมไฟล์สนับสนุนที่พร้อมใช้งาน

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **แปลงพรีเซนเทชันเป็นเอกสาร HTML5 พร้อมคอมเมนต์**

คุณสามารถรวมคอมเมนต์ของสไลด์ที่มีอยู่ในผลลัพธ์ HTML5 เพื่อให้ผู้อ่านเห็นข้อเสนอแนะควบคู่กับเนื้อหาสไลด์ ตัวอย่างในส่วนนี้คาดว่าพรีเซนเทชันต้นฉบับมีคอมเมนต์ตามที่แสดงด้านล่าง มันจะส่งออกคอมเมนต์เหล่านั้น; ไม่ได้สร้างคอมเมนต์ใหม่

![คอมเมนต์สองรายการบนสไลด์พรีเซนเทชัน](two_comments_pptx.png)

ส่งออบเจ็กต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) ไปยังเมธอด [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) ของ [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) ใช้ [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) เพื่อเลือก `Right` จากการนับ [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) เพื่อวางคอมเมนต์ทางขวาของแต่ละสไลด์

ตัวอย่างต่อไปนี้ส่งออกพรีเซนเทชันเป็น HTML5 พร้อมการจัดวางคอมเมนต์นี้ พรีเซนเทชันที่ไม่มีคอมเมนต์จะไม่มีข้อความคอมเมนต์ให้แสดง

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![คอมเมนต์ในเอกสาร HTML5 ที่ส่งออก](two_comments_html5.png)

## **ยกเว้นไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก**

สมมติว่า `hyperlinks.pptx` มีข้อความเชื่อมโยงที่มีเป้าหมาย `javascript:alert('Hello')` และลิงก์ธรรมดา `https://example.com/` เพื่อยกเว้นไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก ให้ส่งค่า `true` ไปยัง [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) ค่าเริ่มต้นคือ `false` ดังนั้นลิงก์เหล่านี้จะไม่ถูกกรองเว้นแต่คุณเปิดใช้งานตัวเลือกนี้

ตัวอย่างต่อไปนี้โหลดพรีเซนเทชันจากไดเรกทอรีทำงานและส่งออกโดยใช้ [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

ไฟล์ที่ส่งออกจะละเว้นไฮเปอร์ลิงก์ JavaScript แต่ยังคงข้อความและลิงก์ HTTPS ธรรมดาไว้ พรีเซนเทชันต้นฉบับไม่มีการเปลี่ยนแปลง

ตัวเลือกนี้กรองไฮเปอร์ลิงก์ JavaScript; ไม่ได้ลบสคริปต์ทั้งหมดหรือเนื้อหาแอคทีฟอื่น ๆ และไม่รับประกันการปฏิบัติตาม CSP ตัวอย่างเช่น ผลลัพธ์ HTML5 ยังคงมีสคริปต์สำหรับการนำทางสไลด์และแอนิเมชัน

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมว่าการแอนิเมชันของวัตถุและการเปลี่ยนสไลด์จะเล่นใน HTML5 หรือไม่?**

ใช่, การส่งออก HTML5 มีตัวเลือกแยกกันเพื่อเปิดหรือปิด [แอนิเมชันรูปทรง](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) และ [การเปลี่ยนสไลด์](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-).

**คอมเมนต์ได้รับการสนับสนุนหรือไม่, และสามารถวางตำแหน่งใดได้บ้างสัมพันธ์กับสไลด์?**

ใช่, คอมเมนต์ที่มีอยู่สามารถรวมไว้ในผลลัพธ์ HTML5 และวางตำแหน่ง (เช่น ทางด้านขวาของสไลด์) ผ่าน [การตั้งค่าเค้าโครง](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-).

**ฉันสามารถละเว้นลิงก์ที่เรียกใช้ JavaScript เพื่อเหตุผลด้านความปลอดภัยหรือ CSP ได้หรือไม่?**

ใช่, การตั้งค่า [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) อนุญาตให้คุณละเว้นไฮเปอร์ลิงก์ที่มีการเรียก JavaScript ระหว่างการบันทึก ค่าเริ่มต้นคือ `false`. ดู [ยกเว้นไฮเปอร์ลิงก์ JavaScript ระหว่างการส่งออก](/slides/th/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) สำหรับตัวอย่างการส่งออก HTML5 และขอบเขตของตัวกรอง ตัวเลือกนี้ไม่ลบ JavaScript ที่ใช้โดยตัวชม HTML5 สำหรับการนำทางและแอนิเมชัน.
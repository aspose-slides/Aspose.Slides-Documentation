---
title: แปลงงานนำเสนอ PowerPoint เป็น HTML ใน Node.js
linktitle: PowerPoint เป็น HTML
type: docs
weight: 30
url: /th/nodejs-java/convert-powerpoint-to-html/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น HTML
- งานนำเสนอเป็น HTML
- สไลด์เป็น HTML
- PPT เป็น HTML
- PPTX เป็น HTML
- บันทึก PowerPoint เป็น HTML
- บันทึกงานนำเสนอเป็น HTML
- บันทึกสไลด์เป็น HTML
- บันทึก PPT เป็น HTML
- บันทึก PPTX เป็น HTML
- ส่งออก PPT เป็น HTML
- ส่งออก PPTX เป็น HTML
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น HTML ใน Node.js ใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อส่งออกไฟล์ PPT และ PPTX, สไลด์ที่เลือก, โน้ต, ฟอนต์, รูปภาพ, SVG และสื่อ"
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java สามารถบันทึกงานนำเสนอ PowerPoint เป็น HTML ได้โดยไม่ต้องใช้ Microsoft PowerPoint การแปลงพื้นฐานคือทำการโหลด [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เพียงครั้งเดียวและเรียก `save` ด้วย [SaveFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/). ใช้ [HtmlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmloptions/) เมื่อคุณต้องการควบคุมการจัดเรียง, ฟอนต์, รูปภาพ, โน้ต, คอมเมนต์, การสร้าง SVG, หรือทรัพยากรที่เชื่อมโยง

แนวทางนี้มุ่งเน้นที่สถานการณ์การส่งออก HTML ที่ใช้งานได้จริง:

- ส่งออกงานนำเสนอทั้งหมดหรือสไลด์ที่เลือก
- สร้าง HTML แบบ layout คงที่, responsive หรืออิง SVG
- รวมโน้ตผู้พูดและคอมเมนต์
- ควบคุมคุณภาพภาพและข้อมูลภาพที่ถูกตัด
- ฝังฟอนต์ หรือบันทึกไฟล์ฟอนต์แยกต่างหาก
- เลือกวิธีการเขียนและอ้างอิงทรัพยากรภายนอกและไฟล์สื่อ

โดยค่าเริ่มต้น การส่งออก HTML จะสร้างเอกสาร HTML ที่เป็นอิสระโดยส่วนใหญ่ของทรัพยากรจะถูกฝังไว้ ซึ่งสะดวกสำหรับการแชร์ไฟล์เดียว แต่จะทำให้ขนาดไฟล์เพิ่มขึ้น สำหรับการเผยแพร่บนเว็บ ควรพิจารณาใช้ทรัพยากรภายนอก, ลด DPI ของภาพ, และฝังฟอนต์เฉพาะที่ไม่มีในสภาพแวดล้อมเป้าหมายเท่านั้น

## **แปลงงานนำเสนอเป็น HTML**

เพื่อส่งออกงานนำเสนอเป็น HTML ให้โหลดด้วย [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) แล้วบันทึกด้วย [SaveFormat.Html](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

ตัวอย่างนี้จะเขียนไฟล์ HTML หนึ่งไฟล์ วัตถุ Presentation จะถูก Dispose ในบล็อก `finally` ซึ่งจะปล่อยแฮนด์เลอร์ไฟล์และทรัพยากรการเรนเดอร์หลังการส่งออก

## **ใช้ HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmloptions/) เป็นคลาสกำหนดค่าหลักสำหรับการส่งออก HTML การตั้งค่าที่พบบ่อยได้แก่:

- `SlidesLayoutOptions`: เพิ่มโน้ต, คอมเมนต์, ใบแจก, หรือข้อมูลการจัดเรียงอื่น ๆ
- `HtmlFormatter`: เปลี่ยนโครงสร้างของเอกสาร HTML หรือมอบหมายการจัดรูปแบบให้กับคอนโทรลเลอร์
- `SlideImageFormat`: เปลี่ยนวิธีการแสดงสไลด์, ตัวอย่างเช่นเป็น SVG
- `PicturesCompression`: ควบคุม DPI ของภาพและขนาดผลลัพธ์
- `DeletePicturesCroppedAreas`: เก็บหรือเอาข้อมูลภาพที่ถูกตัดออก
- `SvgResponsiveLayout`: ทำให้เนื้อหา SVG ที่ส่งออกปรับตัวเข้ากับคอนเทนเนอร์
- `ShowHiddenSlides`: รวมสไลด์ที่ซ่อนไว้เมื่อจำเป็น

ส่วนต่อไปนี้จะแสดงตัวเลือกที่พบบ่อยที่สุดแยกกันเพื่อให้คุณสามารถรวมเฉพาะตัวเลือกที่ต้องการในเวิร์กโฟลว์ของคุณได้

## **แปลงสไลด์ที่เลือกเป็น HTML**

โอเวอร์โหลด `Presentation.save` ที่รับหมายเลขสไลด์ใช้ตำแหน่งสไลด์แบบ 1‑based ลูปด้านล่างจะบันทึกแต่ละสไลด์เป็นไฟล์ HTML แยกกัน

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

ใช้รูปแบบนี้เมื่อเว็บไซต์หรือแอปพลิเคชันต้องการหน้า HTML หนึ่งหน้าต่อสไลด์ หากสไลด์แต่ละอันต้องการเลย์เอาต์เดียวกัน ให้สร้างอ็อบเจกต์ [HtmlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmloptions/) หนึ่งตัวและส่งต่อให้กับการเรียก `save` ทุกครั้ง

## **สร้าง HTML แบบ Responsive**

[ResponsiveHtmlController](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/responsivehtmlcontroller/) ให้ผลลัพธ์ HTML แบบตอบสนองผ่าน [HtmlFormatter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmlformatter/). ใช้เมื่อหน้าที่ส่งออกต้องปรับให้เข้ากับความกว้างของเบราว์เซอร์ได้ดียิ่งขึ้น

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

สำหรับเลย์เอาต์ responsive ที่อิง SVG ให้ตั้งค่า `SvgResponsiveLayout` บน [HtmlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmloptions/). นี้มีประโยชน์เมื่อเนื้อหาสไลด์ถูกส่งออกเป็นมาร์คอัป SVG ที่ขยายได้

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **รวมโน้ตผู้พูดและคอมเมนต์**

ใช้ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notescommentslayoutingoptions/) ผ่าน `HtmlOptions.setSlidesLayoutOptions` เพื่อรวมโน้ตผู้พูดหรือคอมเมนต์ โน้ตและคอมเมนต์จะถูกซ่อนไว้เป็นค่าเริ่มต้นเว้นแต่คุณจะกำหนดตำแหน่งของมัน

สมมติว่าตัวงานนำเสนอมีโน้ตผู้พูด:

![สไลด์พร้อมโน้ตผู้พูดใน PowerPoint](slide_with_notes.png)

โค้ดต่อไปนี้จะส่งออกเนื้อหาสไลด์พร้อมโน้ตผู้พูดด้านล่างสไลด์

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

HTML ที่ส่งออกจะรวมพื้นที่โน้ตด้วย:

![ผลลัพธ์ HTML พร้อมสไลด์และโน้ตผู้พูด](HTML_with_notes.png)

หากต้องการส่งออกคอมเมนต์ ตั้งค่า `CommentsPosition` เช่น `CommentsPositions.Right` หรือ `CommentsPositions.Bottom`. หากต้องการแค่คอมเมนต์ให้ละ `NotesPosition`. หากต้องการรวมทั้งโน้ตและคอมเมนต์ให้ตั้งค่าทั้งสองคุณสมบัติ

## **ควบคุมคุณภาพภาพและพื้นที่ที่ถูกตัด**

การส่งออก HTML สามารถบีบอัดภาพสไลด์เพื่อทำให้ขนาดไฟล์ลดลง ตั้งค่า `PicturesCompression` เป็นค่าจาก [PicturesCompression](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturescompression/) เมื่อคุณต้องการคุณภาพภาพที่สูงขึ้น

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

โดยค่าเริ่มต้น พื้นที่ที่ถูกตัดของภาพอาจถูกลบออกจากผลลัพธ์ที่ส่งออกเก็บข้อมูลที่ถูกตัดไว้เฉพาะเมื่อผู้ใช้จำเป็นต้องกู้คืนหรือตรวจสอบส่วนภาพที่ซ่อนเหล่านั้น การเก็บไว้จะทำให้ขนาด HTML เพิ่มขึ้น

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **เพิ่ม CSS**

สำหรับการสไตลิงแบบง่าย ให้ส่งสตริง CSS ไปยัง `HtmlFormatter.createDocumentFormatter`. นี้จะเปลี่ยนเอกสาร HTML รอบ ๆ ในขณะที่ Aspose.Slides ยังคงเรนเดอร์เนื้อหาสไลด์ต่อไป

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

หากต้องการส่วนหัวของเอกสารแบบกำหนดเอง, ไฟล์ CSS เชื่อมโยง, หรือมาร์คอัปกำหนดเองรอบสไลด์และรูปร่าง ให้ใช้ [HtmlFormatter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmlformatter/) พร้อมคอนโทรลเลอร์จัดรูปแบบ

## **ฝังฟอนต์**

หากสภาพแวดล้อมเป้าหมายอาจไม่มีฟอนต์ของงานนำเสนอที่ติดตั้งไว้ ให้ฝังฟอนต์ใน HTML ด้วย [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). การฝังช่วยปรับปรุงความแม่นยำของการแสดงผลแต่ขนาดไฟล์จะเพิ่มขึ้น

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

ให้ยกเว้นฟอนต์เฉพาะเมื่อคุณมั่นใจว่าเบราว์เซอร์หรือระบบเป้าหมายมีฟอนต์เหล่านั้นแล้ว สำหรับฟอนต์แบรนด์หรือฟอนต์ที่ไม่พบบ่อย การฝังมักจะปลอดภัยกว่า

## **เชื่อมโยงไฟล์ฟอนต์แทนการฝัง**

เพื่อลดขนาดไฟล์ HTML คุณสามารถบันทึกข้อมูลฟอนต์เป็นไฟล์ WOFF แยกต่างหากและเพิ่มกฎ `@font-face` ลงใน HTML ใน Node.js via Java ปัญหานี้มักจะทำด้วยคลาสช่วยเหลือ Java เล็ก ๆ ที่สืบทอดจาก [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/embedallfontshtmlcontroller/), เขียนไบต์ฟอนต์ไปยังไดเรกทอรีผลลัพธ์, และแทรกกฎ `@font-face` ลงใน HTML ที่สร้างจากนั้นคอมไพล์คลาสช่วยเหลือนั้น, เพิ่มลงใน classpath ของโมดูล Node.js, และสร้างอินสแตนซ์จาก JavaScript ด้วย `java.newInstanceSync`

เมื่อคุณสร้างคลาสช่วยเหลือดังกล่าว ให้เลือกสองเส้นทางอย่างชัดเจน:

- เส้นทางผลลัพธ์ของระบบไฟล์, ที่ไฟล์ฟอนต์ที่สร้างขึ้นจะถูกเขียน
- เส้นทาง URL, ซึ่งเป็นเส้นทางที่เบราว์เซอร์ใช้จากเอกสาร HTML เพื่อโหลดไฟล์ฟอนต์เหล่านั้น

## **บันทึกทรัพยากรเป็นไฟล์ภายนอก**

HTML ที่เป็นอิสระทำให้ง่ายต่อการย้าย แต่ทรัพยากร Base64 ที่ฝังอยู่สามารถทำให้ไฟล์ใหญ่ หากแอปพลิเคชันของคุณต้องการรูปภาพ, ฟอนต์, ไฟล์เสียงหรือวิดีโอแบบภายนอก ให้ใช้คอนโทรลเลอร์ส่งออกที่เขียนทรัพยากรไปยังไดเรกทอรีที่เลือกและสร้าง URL ที่เบราว์เซอร์มองเห็น จัดให้เส้นทางระบบไฟล์และเส้นทาง URL สอดคล้องกับโครงสร้างการปรับใช้ของคุณ

## **ส่งออกไฟล์สื่อ**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) ส่งออกไฟล์วิดีโอและออดิโอและเขียน HTML ที่สามารถเล่นไฟล์เหล่านั้นในเบราว์เซอร์ ตัวสร้างมีพารามิเตอร์:

- `path`: ไดเรกทอรีที่ไฟล์สื่อที่สร้างขึ้นจะถูกเขียน
- `fileName`: ชื่อไฟล์ HTML ที่กำลังสร้าง
- `baseUri`: คำนำหน้า URI ที่เป็นแบบเต็มที่ใช้ในลิงก์ HTML ไปยังไฟล์สื่อ

ถ้าไฟล์ HTML อยู่ที่ `html-output/presentation.html` และไฟล์สื่อถูกบันทึกที่ `html-output/media` `path` ควรชี้ไปยังไดเรกทอรีสื่อบนดิสก์ขณะที่ `baseUri` ควรชี้ไปยังไดเรกทอรีเดียวกันจากมุมมองของเบราว์เซอร์ สำหรับการพรีวิวแบบโลคัล คุณสามารถสร้าง URI `file:///` จากไดเรกทอรีสื่อได้ สำหรับแอปพลิเคชันที่ปรับใช้แล้ว ให้ใช้ URL แบบเต็มของไดเรกทอรีสื่อที่เผยแพร่

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

ใช้ไดเรกทอรีผลลัพธ์ที่เป็นเอกลักษณ์ต่องานส่งออก โดยเฉพาะในแอปพลิเคชันเซิร์ฟเวอร์ เส้นทางผลลัพธ์ที่แชร์กันอาจทำให้ไฟล์จากการแปลงต่าง ๆ ขัดเขียนทับกันได้

## **ประสิทธิภาพและการจัดการทรัพยากร**

การแปลง HTML คือกระบวนการเรนเดอร์ ดังนั้นเวลาใช้งานและการใช้หน่วยความจำจะขึ้นอยู่กับจำนวนสไลด์, ความละเอียดภาพ, ฟอนต์, เอฟเฟกต์, แชートและสื่อที่ฝังอยู่ ค่า DPI ของ `PicturesCompression` ที่สูงกว่า, ฟอนต์ที่ฝัง, ผลลัพธ์ SVG และการเก็บพื้นที่ภาพที่ถูกตัดสามารถเพิ่มความแม่นยำได้แต่ส่วนใหญ่จะทำให้ขนาดไฟล์เพิ่มขึ้น

สำหรับการแปลงเป็นชุด:

- ทำการ Dispose อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ทุกตัวโดยเร็ว
- ใช้ไดเรกทอรีผลลัพธ์แยกกันสำหรับงานแยกต่าง ๆ
- หลีกเลี่ยงการฝังฟอนต์ทั่วไป หากไม่ได้ต้องการความแม่นยำสูง
- ลด DPI ของภาพเมื่อ HTML ใช้สำหรับพรีวิวหรือรูปย่อ
- เก็บงานนำเสนอต้นฉบับ, HTML ที่สร้าง, และทรัพยากรภายนอกไว้ด้วยกันจนกว่าจะกำหนดเส้นทางการปรับใช้ขั้นสุดท้าย

## **FAQ**

**ลิงก์ไฮเปอร์ลิงก์ถูกรักษาไว้ในผลลัพธ์ HTML หรือไม่?**

ใช่. ลิงก์ไฮเปอร์ลิงก์ของงานนำเสนอจะถูกส่งออกเป็น HTML และยังคงคลิกได้เมื่อ URL ปลายทางเป็นค่าที่ถูกต้อง

**ฉันสามารถแปลงงานนำเสนอเป็น HTML แบบขนานได้หรือไม่?**

ได้, แต่ห้ามแชร์อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เดียวกันระหว่าง worker ต่าง ๆ ประมวลผลไฟล์ต่างกันด้วยอินสแตนซ์ Presentation แยกกัน, สตรีมแยกกัน, และไดเรกทอรีผลลัพธ์แยกกัน ดูคำแนะนำเกี่ยวกับ [multithreading guidance](/slides/th/nodejs-java/multithreading/) สำหรับรายละเอียด

**อ็อบเจกต์ Presentation ปลอดภัยต่อการทำงานหลายเธรดหรือไม่?**

ไม่. อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ควรโหลด, แก้ไข, บันทึก, และ Dispose ภายใน worker เดียวเท่านั้น สำหรับการทำงานขนานให้สร้างอินสแตนซ์อิสระต่อ worker หรือกระบวนการ

**ทำไมไฟล์ HTML ที่สร้างขึ้นถึงมีขนาดใหญ่?**

การส่งออกแบบค่าเริ่มต้นจะฝังทรัพยากรโดยตรงใน HTML ฟอนต์ที่ฝัง, ภาพ DPI สูง, สื่อ, เนื้อหา SVG, และการเก็บพื้นที่ภาพที่ถูกตัดทั้งหมดจะทำให้ขนาดเพิ่มขึ้น ใช้ทรัพยากรภายนอก, ยกเว้นฟอนต์ทั่วไปจากการฝัง, และลด `PicturesCompression` เมื่อขนาดไฟล์เล็กสำคัญกว่าความแม่นยำสูงสุด

**ทำไมขนาดฟอนต์ PowerPoint เช่น 24 pt ถึงปรากฏเป็น 17.999819 pt ใน HTML?**

สิ่งนี้อาจเกิดจาก PowerPoint และ HTML ใช้โมเดล DPI ที่แตกต่างกัน PowerPoint เก็บขนาดข้อความเป็นจุดเชิงพิมพ์โดยอาศัย 72 DPI ในขณะที่การจัดหน้า HTML ใช้พิกเซล CSS ในโมเดล 96 DPI เมื่อ Aspose.Slides ส่งออกงานนำเสนอเป็น HTML ขนาดฟอนต์จะถูกแปลงระหว่างระบบเหล่านี้และการแปลงอาจทำให้เกิดความแตกต่างการปัดจำนวนเล็กน้อย ค่าดังกล่าวไม่ได้แสดงว่าขนาดฟอนต์ที่มองเห็นจริงเปลี่ยนแปลง เพียงเป็นผลข้างเคียงทางคณิตศาสตร์ของการแปลงเมตริกซ์ข้อความระหว่าง PowerPoint และ HTML

**ฉันควรเลือก baseUri สำหรับการส่งออกสื่ออย่างไร?**

เลือก `baseUri` จากมุมมองของเบราว์เซอร์และส่งเป็น URI แบบเต็ม สำหรับการพรีวิวโลคัลคุณสามารถสร้างจากไดเรกทอรีผลลัพธ์ด้วย URI `file:///` สำหรับการปรับใช้ ให้ใช้ URL แบบเต็มของไดเรกทอรีสื่อที่เผยแพร่ `path` และ `baseUri` ไม่จำเป็นต้องเป็นสตริงเดียวกัน แต่ต้องอธิบายตำแหน่งทรัพยากรเดียวกัน

**ฉันสามารถรวมสไลด์ที่ซ่อนไว้ได้หรือไม่?**

ได้. ตั้งค่า `ShowHiddenSlides` เป็น `true` บน [HtmlOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmloptions/) เมื่อสไลด์ที่ซ่อนต้องถูกส่งออก
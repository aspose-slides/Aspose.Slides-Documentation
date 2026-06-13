---
title: แปลงการนำเสนอ PowerPoint เป็น HTML ใน PHP
linktitle: PowerPoint เป็น HTML
type: docs
weight: 30
url: /th/php-java/convert-powerpoint-to-html/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น HTML
- การนำเสนอเป็น HTML
- สไลด์เป็น HTML
- PPT เป็น HTML
- PPTX เป็น HTML
- บันทึก PowerPoint เป็น HTML
- บันทึกการนำเสนอเป็น HTML
- บันทึกสไลด์เป็น HTML
- บันทึก PPT เป็น HTML
- บันทึก PPTX เป็น HTML
- ส่งออก PPT เป็น HTML
- ส่งออก PPTX เป็น HTML
- PHP
- Aspose.Slides
description: "แปลงการนำเสนอ PowerPoint เป็น HTML ใน PHP ใช้ Aspose.Slides เพื่อส่งออกไฟล์ PPT และ PPTX, สไลด์ที่เลือก, โน้ต, ฟอนต์, รูปภาพ, SVG และสื่อ"
---
## **ภาพรวม**

Aspose.Slides for PHP via Java สามารถบันทึกการนำเสนอ PowerPoint เป็น HTML โดยไม่ต้องใช้ Microsoft PowerPoint การแปลงพื้นฐานคือการโหลด [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ครั้งเดียวและเรียก `save` ด้วย [SaveFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/). ใช้ [HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/) เมื่อคุณต้องการควบคุมเลย์เอาต์ที่ส่งออก, ฟอนต์, รูปภาพ, โน้ต, ความคิดเห็น, ผลลัพธ์ SVG, หรือทรัพยากรที่เชื่อมโยง.

คู่มือฉบับนี้มุ่งเน้นไปที่สถานการณ์การส่งออก HTML ที่เป็นประโยชน์เชิงปฏิบัติ:

- ส่งออกการนำเสนอทั้งหมดหรือสไลด์ที่เลือก.
- สร้าง HTML แบบ layout คงที่, รองรับการตอบสนอง, หรือแบบ SVG.
- รวมโน้ตผู้พูดและความคิดเห็น.
- ควบคุมคุณภาพภาพและข้อมูลส่วนที่ถูกตัดของรูปภาพ.
- ฝังฟอนต์หรือบันทึกไฟล์ฟอนต์แยกต่างหาก.
- เลือกวิธีการเขียนและอ้างอิงทรัพยากรภายนอกและไฟล์สื่อ.

โดยค่าเริ่มต้น การส่งออก HTML จะผลิตเอกสาร HTML เองที่รวมทรัพยากรส่วนใหญ่เอาไว้ในไฟล์ ซึ่งสะดวกสำหรับการแบ่งปันไฟล์เดียว แต่ขนาดไฟล์อาจเพิ่มขึ้น สำหรับการเผยแพร่บนเว็บ ควรพิจารณาใช้ทรัพยากรภายนอก, ลด DPI ของภาพ, และฝังฟอนต์เฉพาะที่ไม่มีในสภาพแวดล้อมเป้าหมายอย่างน่าเชื่อถือเท่านั้น.

## **แปลงการนำเสนอเป็น HTML**

เพื่อส่งออกการนำเสนอเป็น HTML ให้โหลดด้วย [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) แล้วบันทึกด้วย [SaveFormat.Html](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

ตัวอย่างนี้เขียนไฟล์ HTML หนึ่งไฟล์ วัตถุ presentation จะถูกทำลายในบล็อก `finally` ซึ่งจะปล่อยตัวจัดการไฟล์และทรัพยากรการเรนเดอร์หลังจากการส่งออก.

## **ใช้ HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/) คือคลาสการกำหนดค่าหลักสำหรับการส่งออก HTML การตั้งค่าทั่วไปรวมถึง:

- `SlidesLayoutOptions`: เพิ่มโน้ต, ความคิดเห็น, เอกสารแจกจ่าย, หรือข้อมูลเลย์เอาต์อื่น ๆ.
- `HtmlFormatter`: เปลี่ยนโครงสร้างเอกสาร HTML หรือมอบหมายการจัดรูปแบบให้กับคอนโทรลเลอร์.
- `SlideImageFormat`: เปลี่ยนวิธีการแสดงสไลด์ ตัวอย่างเช่นเป็น SVG.
- `PicturesCompression`: ควบคุม DPI ของภาพและขนาดผลลัพธ์.
- `DeletePicturesCroppedAreas`: เก็บหรือเอาข้อมูลส่วนที่ตัดของรูปภาพออก.
- `SvgResponsiveLayout`: ทำให้เนื้อหา SVG ที่ส่งออกปรับตัวตามคอนเทนเนอร์.
- `ShowHiddenSlides`: รวมสไลด์ที่ซ่อนเมื่อจำเป็น.

ส่วนต่อไปนี้แสดงตัวเลือกที่ใช้บ่อยที่สุดแยกกัน เพื่อให้คุณสามารถรวมเฉพาะตัวเลือกที่ workflow ของคุณต้องการได้.

## **แปลงสไลด์ที่เลือกเป็น HTML**

`save` overload ที่รับหมายเลขสไลด์ใช้ตำแหน่งสไลด์แบบเริ่มต้นจาก 1 ลูปด้านล่างจะบันทึกแต่ละสไลด์เป็นไฟล์ HTML แยกกัน.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

ใช้รูปแบบนี้เมื่อเว็บไซต์หรือแอปพลิเคชันต้องการหน้า HTML หนึ่งหน้าต่อสไลด์ หากทุกสไลด์ต้องการเลย์เอาต์เดียวกัน ให้สร้างอินสแตนซ์ของ [HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/) หนึ่งอันและส่งผ่านให้กับการเรียก `save` แต่ละครั้ง.

## **สร้าง Responsive HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/th/php-java/aspose.slides/responsivehtmlcontroller/) ให้ผลลัพธ์ HTML ที่ตอบสนองผ่าน [HtmlFormatter](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmlformatter/). ใช้เมื่อหน้าที่ส่งออกควรปรับตัวให้เข้ากับความกว้างของเบราว์เซอร์ได้ดีขึ้น.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

สำหรับเลย์เอาต์ที่ตอบสนองด้วย SVG ให้ตั้งค่า `SvgResponsiveLayout` บน [HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/). การตั้งค่านี้มีประโยชน์เมื่อเนื้อหาสไลด์ถูกส่งออกเป็น markup SVG ที่ขยายได้.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **รวมโน้ตผู้พูดและความคิดเห็น**

ใช้ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/notescommentslayoutingoptions/) ผ่าน `HtmlOptions.SlidesLayoutOptions` เพื่อรวมโน้ตผู้พูดหรือคอมเมนท์ โน้ตและคอมเมนท์จะถูกซ่อนโดยค่าเริ่มต้นเว้นแต่ว่าคุณจะกำหนดตำแหน่งของมัน.

สมมติว่าการนำเสนอแหล่งข้อมูลมีโน้ตผู้พูด:

![สไลด์ที่มีโน้ตผู้พูดใน PowerPoint](slide_with_notes.png)

โค้ดต่อไปนี้ส่งออกเนื้อหาสไลด์พร้อมโน้ตผู้พูดด้านล่างสไลด์.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

HTML ที่ส่งออกจะรวมพื้นที่โน้ต:

![ผลลัพธ์ HTML ที่มีสไลด์และโน้ตผู้พูด](HTML_with_notes.png)

หากต้องการส่งออกความคิดเห็น ให้ตั้งค่า `CommentsPosition` เช่น `CommentsPositions.Right` หรือ `CommentsPositions.Bottom`. หากต้องการเฉพาะความคิดเห็นให้ละเว้น `NotesPosition`. หากต้องการทั้งโน้ตและความคิดเห็นให้ตั้งค่าทั้งสองคุณสมบัติ.

## **ควบคุมคุณภาพภาพและส่วนที่ตัด**

การส่งออก HTML สามารถบีบอัดภาพสไลด์เพื่อลดขนาดผลลัพธ์ได้ ตั้งค่า `PicturesCompression` เป็นค่าจาก [PicturesCompression](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturescompression/) เมื่อคุณต้องการคุณภาพภาพที่สูงขึ้น.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

โดยค่าเริ่มต้น ส่วนที่ตัดของภาพอาจถูกลบออกจากผลลัพธ์ที่ส่งออก เก็บข้อมูลส่วนที่ตัดไว้เฉพาะเมื่อผู้ใช้จำเป็นต้องกู้คืนหรือตรวจสอบส่วนภาพที่ซ่อนนั้น การเก็บไว้จะทำให้ขนาด HTML เพิ่มขึ้น.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **เพิ่ม CSS**

สำหรับการสไตลิ่งอย่างง่าย ให้ส่งสตริง CSS ไปยัง [HtmlFormatter](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmlformatter/) ผ่าน `createDocumentFormatter`. วิธีนี้จะเปลี่ยนเอกสาร HTML รอบข้างในขณะที่ Aspose.Slides ยังคงเรนเดอร์เนื้อหาสไลด์ต่อไป.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

หากต้องการส่วนหัวเอกสารที่กำหนดเอง, ไฟล์ CSS เชื่อมโยง, หรือ markup เฉพาะรอบสไลด์และรูปร่าง ให้ใช้คอนโทรลเลอร์จัดรูปแบบแบบกำหนดเองและส่งผ่านให้กับ [HtmlFormatter](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmlformatter/) ด้วย `createCustomFormatter`.

## **ฝังฟอนต์**

หากสภาพแวดล้อมเป้าหมายอาจไม่มีฟอนต์ของการนำเสนอที่ติดตั้งอยู่, สามารถฝังฟอนต์ใน HTML ด้วย [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/php-java/aspose.slides/embedallfontshtmlcontroller/). การฝังช่วยให้ความเที่ยงตรงของภาพเพิ่มขึ้นแต่ขนาดผลลัพธ์ก็เพิ่มเช่นกัน.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

ให้ยกเว้นฟอนต์เฉพาะเมื่อคุณมั่นใจว่าเบราว์เซอร์หรือระบบเป้าหมายมีฟอนต์เหล่านั้นอยู่แล้ว สำหรับฟอนต์ของแบรนด์หรือฟอนต์ที่ไม่ค่อยพบ การฝังมักจะปลอดภัยกว่า.

## **เชื่อมโยงไฟล์ฟอนต์แทนการฝัง**

เพื่อทำให้ขนาดไฟล์ HTML เล็กลง คุณสามารถเขียนข้อมูลฟอนต์ลงในไฟล์ WOFF แยกต่างหากและเพิ่มกฎ `@font-face` ลงใน HTML ใน PHP via Java สถานการณ์นี้มักจะทำด้วยคลาสช่วยเหลือ Java เล็ก ๆ ที่สืบทอดจาก [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/php-java/aspose.slides/embedallfontshtmlcontroller/), เขียนไบต์ฟอนต์ลงในไดเรกทอรีผลลัพธ์, และแทรกกฎ `@font-face` ลงใน HTML ที่สร้างขึ้น คอมไพล์คลาสช่วยเหลือนี้, เพิ่มเข้าไปใน classpath ของ PHP Java Bridge, แล้วสร้างอ็อบเจกต์จาก PHP ด้วย `new Java(...)`.

เมื่อคุณสร้างตัวช่วยเหลือนี้ ให้เลือกสองเส้นทางอย่างชัดเจน:

- เส้นทางระบบไฟล์สำหรับไฟล์ฟอนต์ที่สร้างขึ้น.
- เส้นทาง URL ที่เบราว์เซอร์จะใช้จากเอกสาร HTML เพื่อโหลดไฟล์ฟอนต์เหล่านั้น.

## **บันทึกทรัพยากรเป็นไฟล์ภายนอก**

HTML ที่เป็นแบบ self‑contained ง่ายต่อการเคลื่อนย้าย, แต่ทรัพยากร Base64 ที่ฝังไว้ทำให้ไฟล์ใหญ่ หากแอปของคุณต้องการไฟล์รูปภาพภายนอก ให้จัดหาคอนโทรลเลอร์ลิงก์/ฝังแบบกำหนดเองให้กับคอนสตรัคเตอร์ของ [HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/).

เมื่อคุณทำให้ทรัพยากรเป็นภายนอก, ให้เลือกสองเส้นทางอย่างชัดเจน:

- เส้นทางระบบไฟล์ที่แอปของคุณจะเขียนรูปภาพ, ฟอนต์, เสียง, หรือวิดีโอที่สร้างขึ้น.
- เส้นทาง URL ที่เบราว์เซอร์จะใช้จากเอกสาร HTML เพื่อโหลดไฟล์เหล่านั้น.

รักษาเส้นทางเหล่านี้ให้สอดคล้องกับโครงสร้างการปรับใช้ของคุณ เพื่อให้ HTML ที่สร้างขึ้นสามารถโหลดทรัพยากรภายนอกได้หลังจากย้ายไปยังเซิร์ฟเวอร์เว็บหรือไดเรกทอรีอื่น.

## **ส่งออกไฟล์สื่อ**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/th/php-java/aspose.slides/videoplayerhtmlcontroller/) ส่งออกไฟล์วิดีโอและเสียงและเขียน HTML ที่สามารถเล่นได้ในเบราว์เซอร์ คอนสตรัคเตอร์รับ:

- `path`: ไดเรกทอรีผลลัพธ์ที่ใช้โดย HTML ที่สร้างขึ้นและไฟล์สื่อ.
- `fileName`: ชื่อไฟล์ HTML ที่กำลังสร้าง.
- `baseUri`: คำนำหน้า URI แบบเต็มที่ใช้ในลิงก์ HTML ไปยังไฟล์สื่อ.

หากไฟล์ HTML คือ `html-output/presentation.html`, `path` ควรชี้ไปที่ `html-output`, และ `baseUri` ควรชี้ไปยังไดเรกทอรีเดียวกันจากมุมมองของเบราว์เซอร์. สำหรับการพรีวิวแบบโลคัล, คุณสามารถสร้าง URI `file:///` จากไดเรกทอรีผลลัพธ์. สำหรับแอปที่ปรับใช้, ใช้ URL แบบเต็มของไดเรกทอรีผลลัพธ์ที่เผยแพร่แล้ว.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

ใช้ไดเรกทอรีผลลัพธ์ที่เป็นเอกลักษณ์ต่อแต่ละงานส่งออก, โดยเฉพาะในแอปเซิร์ฟเวอร์. เส้นทางผลลัพธ์ที่แชร์กันอาจทำให้ไฟล์จากการแปลงต่าง ๆ เขียนทับกันได้.

## **ประสิทธิภาพและการจัดการทรัพยากร**

การแปลงเป็น HTML เป็นการดำเนินการเรนเดอร์, ดังนั้นเวลาประมวลผลและการใช้หน่วยความจำขึ้นอยู่กับจำนวนสไลด์, ความละเอียดของภาพ, ฟอนต์, เอฟเฟกต์, แผนภูมิ, และสื่อที่ฝังอยู่ ค่าดีพี `PicturesCompression` สูง, ฟอนต์ที่ฝัง, ผลลัพธ์ SVG, และการเก็บส่วนที่ตัดของภาพสามารถเพิ่มความเที่ยงตรงได้แต่ส่วนใหญ่จะเพิ่มขนาดผลลัพธ์.

สำหรับการแปลงเป็นชุด:

- ทำลายแต่ละอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) อย่างเร็ว.
- ใช้ไดเรกทอรีผลลัพธ์แยกสำหรับงานแยก.
- อย่าฝังฟอนต์ที่ทั่วไปเว้นแต่ความเที่ยงตรงจำเป็น.
- ลด DPI ของภาพเมื่อ HTML ใช้เพื่อพรีวิวหรือรูปย่อ.
- เก็บการนำเสนอแหล่ง, HTML ที่สร้าง, และทรัพยากรภายนอกไว้ด้วยกันจนกว่าจะกำหนดเส้นทางการปรับใช้ขั้นสุดท้าย.

## **คำถามที่พบบ่อย**

**ลิงก์ไฮเปอร์เท็กซ์จะถูกเก็บไว้ในผลลัพธ์ HTML หรือไม่?**

ใช่. ลิงก์ไฮเปอร์เท็กซ์ของการนำเสนอจะถูกส่งออกเป็น HTML และสามารถคลิกได้เมื่อ URL เป้าหมายถูกต้อง.

**ฉันสามารถแปลงการนำเสนอเป็น HTML พร้อมกันหลายงานได้หรือไม่?**

ได้, แต่ห้ามแชร์อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ระหว่างเธรด. ประมวลผลไฟล์ต่าง ๆ ด้วยอินสแตนซ์การนำเสนอที่แยกจากกัน, stream ที่แยกกัน, และไดเรกทอรีผลลัพธ์ที่แยกกัน.

**อ็อบเจกต์ Presentation ปลอดภัยต่อการทำงานหลายเธรดหรือไม่?**

ไม่. อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ควรโหลด, แก้ไข, บันทึก, และทำลายบนเธรดเดียว. สำหรับงานแบบขนาน, สร้างอินสแตนซ์แยกสำหรับแต่ละเธรดหรือกระบวนการ.

**ทำไมไฟล์ HTML ที่สร้างขึ้นจึงมีขนาดใหญ่?**

การส่งออกค่าเริ่มต้นจะฝังทรัพยากรโดยตรงใน HTML. ฟอนต์ที่ฝัง, ภาพ DPI สูง, สื่อ, เนื้อหา SVG, และการเก็บส่วนที่ตัดของภาพทั้งหมดทำให้ขนาดเพิ่มขึ้น. ให้ใช้ทรัพยากรภายนอก, ยกเว้นฟอนต์ทั่วไปจากการฝัง, และลด `PicturesCompression` เมื่อขนาดเล็กสำคัญกว่าความเที่ยงตรงสูงสุด.

**ทำไมขนาดฟอนต์ใน PowerPoint เช่น 24 pt ถึงปรากฏเป็น 17.999819 pt ใน HTML?**

เหตุการณ์นี้เกิดจาก PowerPoint และ HTML ใช้โมเดล DPI ที่แตกต่างกัน. PowerPoint เก็บขนาดข้อความเป็นจุดแบบพิมพ์โดยอ้างอิง 72 DPI, ส่วนการจัดวาง HTML ใช้พิกเซล CSSในโมเดล 96 DPI. เมื่อ Aspose.Slides ส่งออกการนำเสนอเป็น HTML, ขนาดฟอนต์จะถูกแปลงระหว่างระบบเหล่านี้และอาจเกิดความแตกต่างในการปัดเศษเล็กน้อย.

ค่าดังกล่าวไม่ได้บ่งบอกว่าขนาดฟอนต์ที่มองเห็นจริงเปลี่ยนแปลง. มันเป็นผลของการคำนวณเชิงคณิตศาสตร์เมื่อแปลงเมตริกซ์ข้อความระหว่าง PowerPoint และ HTML.

**ควรเลือก baseUri สำหรับการส่งออกสื่ออย่างไร?**

เลือก `baseUri` จากมุมมองของเบราว์เซอร์และส่งเป็น URI แบบเต็ม. สำหรับการพรีวิวแบบโลคัล, คุณสามารถสร้างจากไดเรกทอรีผลลัพธ์ด้วย URI ไฟล์ Java. สำหรับการปรับใช้, ใช้ URL แบบเต็มของไดเรกทอรีสื่อที่เผยแพร่. `path` ของระบบไฟล์และ `baseUri` ของเบราว์เซอร์ไม่จำเป็นต้องเป็นสตริงเดียวกัน, แต่ต้องอธิบายตำแหน่งทรัพยากรเดียวกัน.

**ฉันสามารถรวมสไลด์ที่ซ่อนได้หรือไม่?**

ได้. ตั้งค่า `ShowHiddenSlides` เป็น `true` บน [HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/) เมื่อสไลด์ที่ซ่อนต้องการส่งออก.
---
title: แปลงงานนำเสนอ PowerPoint เป็น HTML บน Android
linktitle: PowerPoint เป็น HTML
type: docs
weight: 30
url: /th/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น HTML บน Android ใช้ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อส่งออกไฟล์ PPT และ PPTX, สไลด์ที่เลือก, โน้ต, ฟอนต์, รูปภาพ, SVG และสื่อ"
---
## **ภาพรวม**

Aspose.Slides for Android via Java สามารถบันทึกงานนำเสนอ PowerPoint เป็น HTML โดยไม่ต้องใช้ Microsoft PowerPoint การแปลงพื้นฐานคือการโหลด [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เพียงครั้งเดียวและเรียก `save` ด้วย [SaveFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/). ใช้ [HtmlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/htmloptions/) เมื่อคุณต้องการควบคุมการจัดรูปแบบที่ส่งออก ฟอนต์ ภาพ โน้ต ความคิดเห็น การสร้างผลลัพธ์ SVG หรือทรัพยากรที่เชื่อมโยง

คู่มือนี้เน้นที่สถานการณ์การส่งออก HTML แบบปฏิบัติ:

- ส่งออกงานนำเสนอทั้งหมดหรือสไลด์ที่เลือก
- สร้าง HTML แบบ Layout คงที่, แบบตอบสนอง, หรือแบบใช้ SVG
- รวมโน้ตผู้พูดและความคิดเห็น
- ควบคุมคุณภาพภาพและข้อมูลภาพที่ถูกตัด
- ฝังฟอนต์หรือบันทึกไฟล์ฟอนต์แยกต่างหาก
- เลือกวิธีการเขียนและอ้างอิงทรัพยากรภายนอกและไฟล์สื่อ

โดยค่าเริ่มต้น การส่งออก HTML จะผลิตเอกสาร HTML ที่รวมทรัพยากรส่วนใหญ่ไว้ในไฟล์เดียว สิ่งนี้สะดวกสำหรับการแชร์ไฟล์เดียว แต่ขนาดผลลัพธ์อาจเพิ่มขึ้น สำหรับการเผยแพร่บนเว็บ ควรพิจารณาใช้ทรัพยากรภายนอก, ลด DPI ของภาพ, และฝังฟอนต์เฉพาะที่ไม่มีในสภาพแวดล้อมเป้าหมายเท่านั้น

## **แปลงงานนำเสนอเป็น HTML**

เพื่อส่งออกงานนำเสนอเป็น HTML ให้โหลดด้วย [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และบันทึกด้วย [SaveFormat.Html](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/)

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

ตัวอย่างนี้จะเขียนไฟล์ HTML หนึ่งไฟล์ วัตถุ Presentation จะถูกทำลายในบล็อก `finally` ซึ่งจะปล่อยตัวจัดการไฟล์และทรัพยากรการเรนเดอร์หลังการส่งออก

## **ใช้ HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/htmloptions/) เป็นคลาสกำหนดค่าหลักสำหรับการส่งออก HTML การตั้งค่าที่พบบ่อยรวมถึง:

- `SlidesLayoutOptions`: เพิ่มโน้ต, ความคิดเห็น, เอกสารแจกจ่าย, หรือข้อมูลการจัดรูปแบบอื่น
- `HtmlFormatter`: เปลี่ยนโครงสร้างเอกสาร HTML หรือมอบหมายการจัดรูปแบบให้กับคอนโทรลเลอร์
- `SlideImageFormat`: เปลี่ยนวิธีการแสดงสไลด์ เช่น เป็น SVG
- `PicturesCompression`: ควบคุม DPI ของภาพและขนาดผลลัพธ์
- `DeletePicturesCroppedAreas`: รักษาหรือลบข้อมูลภาพที่ถูกตัด
- `SvgResponsiveLayout`: ทำให้เนื้อหา SVG ที่ส่งออกปรับตัวตามคอนเทนเนอร์
- `ShowHiddenSlides`: รวมสไลด์ที่ซ่อนเมื่อจำเป็น

ส่วนต่อไปนี้แสดงตัวเลือกที่พบบ่อยที่สุดโดยแยกกันเพื่อให้คุณสามารถรวมเฉพาะสิ่งที่ต้องการในเวิร์กโฟลว์ของคุณ

## **แปลงสไลด์ที่เลือกเป็น HTML**

`Presentation.save` overload ที่รับหมายเลขสไลด์ใช้ตำแหน่งสไลด์แบบ 1‑based ลูปด้านล่างจะบันทึกแต่ละสไลด์เป็นไฟล์ HTML แยกกัน

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

ใช้รูปแบบนี้เมื่อเว็บไซต์หรือแอปพลิเคชันต้องการหน้า HTML หนึ่งหน้าต่อสไลด์ หากสไลด์แต่ละสไลด์ต้องการเลย์เอาต์เดียวกัน ให้สร้างอินสแตนซ์ [HtmlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/htmloptions/) หนึ่งตัวและส่งผ่านให้กับการเรียก `save` แต่ละครั้ง

## **สร้าง HTML แบบตอบสนอง**

[ResponsiveHtmlController](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/responsivehtmlcontroller/) ให้ผลลัพธ์ HTML แบบตอบสนองผ่าน [HtmlFormatter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/htmlformatter/). ใช้เมื่อหน้าที่ส่งออกต้องปรับให้เข้ากับความกว้างของเบราว์เซอร์ได้ดียิ่งขึ้น

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

สำหรับเลย์เอาต์แบบตอบสนองที่ใช้ SVG ให้ตั้งค่า `SvgResponsiveLayout` บน [HtmlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/htmloptions/). สิ่งนี้มีประโยชน์เมื่อเนื้อหาสไลด์ถูกส่งออกเป็นมาร์กอัป SVG ที่ขยายได้

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **รวมโน้ตผู้พูดและความคิดเห็น**

ใช้ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notescommentslayoutingoptions/) ผ่าน `HtmlOptions.SlidesLayoutOptions` เพื่อรวมโน้ตผู้พูดหรือความคิดเห็น โน้ตและความคิดเห็นจะถูกซ่อนโดยค่าเริ่มต้น เว้นแต่คุณจะกำหนดตำแหน่งของมัน

สมมติว่าการนำเสนอแหล่งที่มามีโน้ตผู้พูด:

![สไลด์ที่มีโน้ตผู้พูดใน PowerPoint](slide_with_notes.png)

โค้ดต่อไปนี้ส่งออกเนื้อหาสไลด์พร้อมโน้ตผู้พูดที่อยู่ด้านล่างสไลด์

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

HTML ที่ส่งออกจะรวมพื้นที่โน้ต:

![ผลลัพธ์ HTML ที่มีสไลด์และโน้ตผู้พูด](HTML_with_notes.png)

เพื่อส่งออกความคิดเห็น ให้ตั้งค่า `CommentsPosition` เช่น `CommentsPositions.Right` หรือ `CommentsPositions.Bottom` หากต้องการเพียงความคิดเห็นเท่านั้น ให้ละเว้น `NotesPosition` หากต้องการทั้งโน้ตและความคิดเห็น ให้ตั้งค่าทั้งสองคุณสมบัติ

## **ควบคุมคุณภาพภาพและพื้นที่ที่ถูกตัด**

การส่งออก HTML สามารถบีบอัดภาพสไลด์เพื่อให้ขนาดผลลัพธ์เล็กลง ตั้งค่า `PicturesCompression` เป็นค่าจาก [PicturesCompression](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/picturescompression/) เมื่อคุณต้องการคุณภาพภาพที่สูงขึ้น

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

โดยค่าเริ่มต้น พื้นที่ที่ถูกตัดของภาพอาจถูกลบจากผลลัพธ์ที่ส่งออก เก็บข้อมูลที่ถูกตัดไว้เฉพาะเมื่อผู้ใช้ต้องการกู้คืนหรือตรวจสอบส่วนที่ซ่อนเหล่านั้น การเก็บไว้จะทำให้ขนาด HTML เพิ่มขึ้น

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **เพิ่ม CSS**

สำหรับการจัดรูปแบบอย่างง่าย ให้ส่งสตริง CSS ไปยัง `HtmlFormatter.createDocumentFormatter` สิ่งนี้จะเปลี่ยนเอกสาร HTML ที่ล้อมรอบในขณะที่ Aspose.Slides ยังคงเรนเดอร์เนื้อหาสไลด์ต่อไป

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

สำหรับส่วนหัวเอกสารที่กำหนดเอง, ไฟล์ CSS ที่เชื่อมโยง, หรือมาร์กอัปที่กำหนดรอบสไลด์และรูปร่าง ให้ทำการ Implement [IHtmlFormattingController](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihtmlformattingcontroller/) และส่งผ่านให้กับ [HtmlFormatter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/htmlformatter/) ด้วย `createCustomFormatter`

## **ฝังฟอนต์**

หากสภาพแวดล้อมเป้าหมายอาจไม่มีฟอนต์ของงานนำเสนอที่ติดตั้งไว้ ให้ฝังฟอนต์ใน HTML ด้วย [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/embedallfontshtmlcontroller/). การฝังช่วยปรับปรุงความแม่นยำในการแสดงผล แต่เพิ่มขนาดผลลัพธ์

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

ให้ยกเว้นฟอนต์เท่านั้นเมื่อคุณมั่นใจว่าเบราว์เซอร์หรือระบบเป้าหมายมีฟอนต์เหล่านั้นแล้ว สำหรับฟอนต์ของแบรนด์หรือฟอนต์ที่ค่อนข้างหายาก การฝังมักจะปลอดภัยกว่า

## **เชื่อมโยงไฟล์ฟอนต์แทนการฝัง**

เพื่อให้ไฟล์ HTML มีขนาดเล็กลง คุณสามารถเขียนข้อมูลฟอนต์ลงในไฟล์ WOFF แยกต่างหากและเพิ่มกฎ `@font-face` ลงใน HTML ตัวช่วยด้านล่างนี้ขยาย [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) และ Override `writeFont`

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

ในตัวอย่างนี้ไฟล์ฟอนต์จะถูกบันทึกลงใน `html-output/fonts` และ HTML จะอ้างอิงไฟล์เหล่านั้นด้วย URL เช่น `fonts/BrandFont-normal-400.woff` หากไฟล์ HTML และฟอนต์ถูกปรับใช้ในตำแหน่งอื่น ให้เลือก `fontUrlPrefix` ให้ตรงกับเส้นทาง URL ที่ปรับใช้

## **บันทึกทรัพยากรเป็นไฟล์ภายนอก**

HTML ที่รวมทุกอย่างไว้ในไฟล์เดียวง่ายต่อการเคลื่อนย้าย แต่ทรัพยากร Base64 ที่ฝังอยู่ทำให้ไฟล์ใหญ่ หากแอปพลิเคชันของคุณต้องการไฟล์ภาพภายนอก ให้ Implement [ILinkEmbedController](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilinkembedcontroller/) และส่งผ่านให้กับคอนสตรัคเตอร์ของ [HtmlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/htmloptions/)

เมื่อคุณทำให้ทรัพยากรเป็นภายนอก ควรเลือกสองเส้นทางอย่างชัดเจน:

- เส้นทางการออกผลของระบบไฟล์ ที่แอปพลิเคชันของคุณเขียนไฟล์ภาพ, ฟอนต์, เสียง หรือวิดีโอที่สร้างขึ้น
- เส้นทาง URL ซึ่งเป็นเส้นทางที่เบราว์เซอร์ใช้จากเอกสาร HTML เพื่อโหลดไฟล์เหล่านั้น

## **ส่งออกไฟล์สื่อ**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) ส่งออกไฟล์วิดีโอและเสียงและเขียน HTML ที่สามารถเล่นสื่อเหล่านั้นในเบราว์เซอร์ คอนสตรัคเตอร์ของมันรับค่า:

- `path`: ไดเรกทอรีที่ไฟล์สื่อที่สร้างขึ้นจะถูกเขียน
- `fileName`: ชื่อไฟล์ HTML ที่กำลังสร้าง
- `baseUri`: คำนำหน้า URI แบบเต็มที่ใช้ในลิงก์ HTML ไปยังไฟล์สื่อ

หากไฟล์ HTML อยู่ที่ `html-output/presentation.html` และไฟล์สื่อบันทึกใน `html-output/media` `path` ควรชี้ไปยังไดเรกทอรีสื่อบนดิสก์ ส่วน `baseUri` ควรชี้ไปยังไดเรกทอรีเดียวกันจากมุมมองของเบราว์เซอร์ สำหรับการพรีวิวในเครื่องคุณสามารถสร้าง URI `file:///` จากไดเรกทอรีสื่อได้ สำหรับแอปพลิเคชันที่ปรับใช้ ให้ใช้ URL แบบเต็มของไดเรกทอรีสื่อที่เผยแพร่

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

ใช้ไดเรกทอรีผลลัพธ์ที่เป็นเอกลักษณ์สำหรับแต่ละงานส่งออก โดยเฉพาะในแอปพลิเคชันเซิร์ฟเวอร์ เส้นทางผลลัพธ์ที่แชร์กันอาจทำให้ไฟล์จากการแปลงต่าง ๆ เขียนทับกันได้

## **ประสิทธิภาพและการจัดการทรัพยากร**

การแปลงเป็น HTML เป็นการดำเนินการเรนเดอร์ ดังนั้นเวลาในการประมวลผลและการใช้หน่วยความจำจึงขึ้นกับจำนวนสไลด์, ความละเอียดภาพ, ฟอนต์, เอฟเฟกต์, แผนภูมิ, และสื่อที่ฝังไว้ ค่า DPI ของ `PicturesCompression` ที่สูงขึ้น, ฟอนต์ที่ฝัง, ผลลัพธ์ SVG, และการเก็บพื้นที่ภาพที่ถูกตัดไว้สามารถเพิ่มความแม่นยำได้แต่โดยทั่วไปจะเพิ่มขนาดไฟล์

สำหรับการแปลงเป็นชุด:

- ทำลายอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ทุกตัวทันที
- ใช้ไดเรกทอรีผลลัพธ์แยกกันสำหรับงานที่แตกต่างกัน
- หลีกเลี่ยงการฝังฟอนต์ทั่วไปเว้นแต่จำเป็นต้องความแม่นยำ
- ลด DPI ของภาพเมื่อ HTML ใช้สำหรับการพรีวิวหรือภาพย่อ
- เก็บงานนำเสนอต้นฉบับ, HTML ที่สร้าง, และทรัพยากรภายนอกไว้ด้วยกันจนกว่าจะกำหนดเส้นทางการปรับใช้ขั้นสุดท้าย

## **FAQ**

**ลิงก์ไฮเปอร์ลิงก์ถูกเก็บไว้ในผลลัพธ์ HTML หรือไม่?**

ใช่. ลิงก์ไฮเปอร์ลิงก์ของงานนำเสนอจะถูกส่งออกเป็น HTML และยังคงคลิกได้เมื่อ URL ปลายทางใช้งานได้

**ฉันสามารถแปลงงานนำเสนอเป็น HTML ในแบบขนานได้หรือไม่?**

ได้, แต่ห้ามใช้อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เดียวกันข้ามเธรด. ควรประมวลผลไฟล์ต่าง ๆ ด้วยอินสแตนซ์ Presentation แยก, สตรีมแยก, และไดเรกทอรีผลลัพธ์แยก. ดูคำแนะนำการทำงานหลายเธรดที่ [/slides/th/androidjava/multithreading/](/slides/th/androidjava/multithreading/) สำหรับรายละเอียด

**อ็อบเจ็กต์ Presentation มีความปลอดภัยต่อเธรดหรือไม่?**

ไม่มี. อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) หนึ่งตัวควรถูกโหลด, แก้ไข, บันทึก, และทำลายในเธรดเดียว. สำหรับงานขนาน ให้สร้างอินสแตนซ์อิสระต่อเธรดหรือกระบวนการ

**ทำไมไฟล์ HTML ที่สร้างขึ้นจึงมีขนาดใหญ่?**

การส่งออกค่าเริ่มต้นอาจฝังทรัพยากรลงใน HTML โดยตรง ฟอนต์ที่ฝัง, ภาพ DPI สูง, สื่อ, เนื้อหา SVG, และการเก็บพื้นที่ภาพที่ถูกตัดทั้งหมดทำให้ขนาดเพิ่มขึ้น ใช้ทรัพยากรภายนอก, ยกเว้นฟอนต์ทั่วไปจากการฝัง, และลด `PicturesCompression` เมื่อขนาดไฟล์สำคัญกว่าความแม่นยำสูงสุด

**ทำไมขนาดฟอนต์ PowerPoint เช่น 24 pt ถึงแสดงเป็น 17.999819 pt ใน HTML?**

สิ่งนี้อาจเกิดขึ้นเนื่องจาก PowerPoint และ HTML ใช้โมเดล DPI ที่แตกต่างกัน PowerPoint เก็บขนาดข้อความเป็นจุดแบบพิมพ์ (typographic points) โดยอิง 72 DPI ในขณะที่การจัดวางของ HTML อิงพิกเซล CSS ในโมเดล 96 DPI เมื่อ Aspose.Slides ส่งออกงานนำเสนอเป็น HTML ขนาดฟอนต์จะถูกแปลงระหว่างระบบเหล่านี้และการคำนวณอาจทำให้เกิดความแตกต่างเล็กน้อยในค่าการปัดเศษ

ค่าที่แสดงเหล่านี้ไม่ได้บ่งบอกว่าขนาดฟอนต์ที่มองเห็นจริงเปลี่ยนแปลงไป เพียงแค่อาจเป็นผลข้างเคียงทางคณิตศาสตร์ของการแปลงเมตริกซ์ข้อความระหว่าง PowerPoint และ HTML

**ฉันควรเลือก baseUri สำหรับการส่งออกสื่ออย่างไร?**

ควรเลือก `baseUri` จากมุมมองของเบราว์เซอร์และส่งผ่านเป็น URI แบบเต็ม สำหรับการพรีวิวในเครื่องคุณสามารถสร้างจากไดเรกทอรีผลลัพธ์ด้วย `mediaDirectory.toUri().toString()` สำหรับการปรับใช้ ให้ใช้ URL แบบเต็มของไดเรกทอรีสื่อที่เผยแพร่ `path` และ `baseUri` ไม่จำเป็นต้องเป็นสตริงเดียวกัน แต่ต้องอธิบายตำแหน่งทรัพยากรเดียวกัน

**ฉันสามารถรวมสไลด์ที่ซ่อนได้หรือไม่?**

ได้. ตั้งค่า `ShowHiddenSlides` เป็น `true` บน [HtmlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/htmloptions/) เมื่อสไลด์ที่ซ่อนต้องถูกส่งออก
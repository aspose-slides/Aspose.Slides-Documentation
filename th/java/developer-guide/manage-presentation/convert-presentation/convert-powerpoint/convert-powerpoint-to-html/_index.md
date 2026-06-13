---
title: แปลงงานนำเสนอ PowerPoint เป็น HTML ใน Java
linktitle: PowerPoint เป็น HTML
type: docs
weight: 30
url: /th/java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น HTML ใน Java ใช้ Aspose.Slides เพื่อส่งออกไฟล์ PPT และ PPTX รวมถึงสไลด์ที่เลือก, โน้ต, ฟอนต์, รูปภาพ, SVG, และสื่อ."
---
## **ภาพรวม**

Aspose.Slides for Java สามารถบันทึกงานนำเสนอ PowerPoint เป็น HTML ได้โดยไม่ต้องใช้ Microsoft PowerPoint การแปลงพื้นฐานคือการโหลด [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เพียงครั้งเดียวและเรียก `save` ด้วย [SaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/) ใช้ [HtmlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/htmloptions/) เมื่อคุณต้องการควบคุมการจัดเรียง, ฟอนต์, รูปภาพ, โน้ต, คอมเมนต์, ผลลัพธ์ SVG หรือแหล่งข้อมูลที่เชื่อมโยง

คำแนะนำนี้มุ่งเน้นที่สถานการณ์การส่งออก HTML ที่เป็นประโยชน์จริง:

- ส่งออกงานนำเสนอทั้งหมดหรือสไลด์ที่เลือก
- สร้าง HTML แบบเลย์เอาต์คงที่, แบบตอบสนอง, หรืออิง SVG
- รวมโน้ตผู้พูดและคอมเมนต์
- ควบคุมคุณภาพภาพและข้อมูลภาพที่ถูกครอบ
- ฝังฟอนต์หรือบันทึกไฟล์ฟอนต์แยกต่างหาก
- เลือกวิธีการเขียนและอ้างอิงทรัพยากรภายนอกและไฟล์สื่อ

โดยค่าเริ่มต้น การส่งออก HTML จะสร้างเอกสาร HTML แบบรวมทุกอย่างที่ส่วนใหญ่เป็นทรัพยากรฝังอยู่ นี่สะดวกสำหรับการแชร์ไฟล์เดียว แต่ทำให้ขนาดผลลัพธ์เพิ่มขึ้น สำหรับการเผยแพร่บนเว็บ พิจารณาใช้ทรัพยากรภายนอก ลด DPI ของภาพ และฝังฟอนต์เฉพาะที่ไม่มีในสภาพแวดล้อมเป้าหมาย

## **แปลงงานนำเสนอเป็น HTML**

เพื่อส่งออกงานนำเสนอเป็น HTML ให้โหลดด้วย [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) แล้วบันทึกด้วย [SaveFormat.Html](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

ตัวอย่างนี้เขียนไฟล์ HTML หนึ่งไฟล์ วัตถุ Presentation จะถูกทำลายในบล็อค `finally` ซึ่งจะปล่อยตัวจัดการไฟล์และทรัพยากรการเรนเดอร์หลังการส่งออก

## **ใช้ HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/htmloptions/) เป็นคลาสกำหนดค่าหลักสำหรับการส่งออก HTML การตั้งค่าทั่วไปได้แก่:

- `SlidesLayoutOptions`: เพิ่มโน้ต, คอมเมนต์, เอกสารสาระสำคัญ หรือข้อมูลการจัดเรียงอื่นๆ
- `HtmlFormatter`: เปลี่ยนโครงสร้างเอกสาร HTML หรือมอบหมายการฟอร์แมตให้กับคอนโทรลเลอร์
- `SlideImageFormat`: เปลี่ยนวิธีการแสดงสไลด์ เช่นเป็น SVG
- `PicturesCompression`: ควบคุม DPI ของภาพและขนาดผลลัพธ์
- `DeletePicturesCroppedAreas`: เก็บหรือเอาข้อมูลภาพที่ถูกครอบออก
- `SvgResponsiveLayout`: ทำให้เนื้อหา SVG ที่ส่งออกปรับตัวตามคอนเทนเนอร์
- `ShowHiddenSlides`: รวมสไลด์ที่ซ่อนไว้เมื่อจำเป็น

ส่วนต่อไปนี้แสดงตัวเลือกที่พบบ่อยที่สุดแยกกันเพื่อให้คุณสามารถรวมเฉพาะตัวเลือกที่เวิร์กโฟลว์ของคุณต้องการ

## **แปลงสไลด์ที่เลือกเป็น HTML**

`Presentation.save` overload ที่รับหมายเลขสไลด์ใช้ตำแหน่งสไลด์แบบ 1‑based ลูปด้านล่างบันทึกแต่ละสไลด์เป็นไฟล์ HTML แยกกัน.

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

ใช้รูปแบบนี้เมื่อเว็บไซต์หรือแอปพลิเคชันต้องการหน้า HTML หนึ่งหน้าต่อสไลด์ หากสไลด์แต่ละอันต้องการเลย์เอาต์เดียวกัน ให้สร้างอินสแตนซ์ [HtmlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/htmloptions/) หนึ่งตัวและส่งผ่านไปยังการเรียก `save` ทุกครั้ง

## **สร้าง HTML แบบตอบสนอง**

[ResponsiveHtmlController](https://reference.aspose.com/slides/th/java/com.aspose.slides/responsivehtmlcontroller/) ให้ผลลัพธ์ HTML แบบตอบสนองผ่าน [HtmlFormatter](https://reference.aspose.com/slides/th/java/com.aspose.slides/htmlformatter/) ใช้เมื่อหน้าที่ส่งออกต้องปรับตัวให้เข้ากับความกว้างของเบราว์เซอร์ได้ดีกว่า

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

สำหรับเลย์เอาต์ตอบสนองแบบ SVG ให้ตั้งค่า `SvgResponsiveLayout` บน [HtmlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/htmloptions/) ซึ่งเป็นประโยชน์เมื่อเนื้อหาสไลด์ถูกส่งออกเป็นมาร์กอัป SVG ที่ขยายได้

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

## **รวมโน้ตผู้พูดและคอมเมนต์**

ใช้ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/notescommentslayoutingoptions/) ผ่าน `HtmlOptions.setSlidesLayoutOptions` เพื่อรวมโน้ตผู้พูดหรือคอมเมนต์ โน้ตและคอมเมนต์จะถูกซ่อนไว้ตามค่าเริ่มต้น เว้นแต่คุณจะกำหนดตำแหน่งของมัน

สมมติว่าการนำเสนอแหล่งมีโน้ตผู้พูด:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

โค้ดต่อไปนี้ส่งออกเนื้อหาสไลด์พร้อมโน้ตผู้พูดใต้สไลด์

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

![HTML output with the slide and speaker notes](HTML_with_notes.png)

เพื่อส่งออกคอมเมนต์ ให้ตั้งค่า `CommentsPosition` ตัวอย่างเช่น `CommentsPositions.Right` หรือ `CommentsPositions.Bottom` หากต้องการเฉพาะคอมเมนต์ให้ละเว้น `NotesPosition` หากต้องการทั้งโน้ตและคอมเมนต์ให้ตั้งค่าแต่ละคุณสมบัติ

## **ควบคุมคุณภาพภาพและพื้นที่ที่ถูกครอบ**

การส่งออก HTML สามารถบีบอัดภาพสไลด์เพื่อลดขนาดผลลัพธ์ได้ ตั้งค่า `PicturesCompression` เป็นค่าที่มาจาก [PicturesCompression](https://reference.aspose.com/slides/th/java/com.aspose.slides/picturescompression/) เมื่อคุณต้องการคุณภาพภาพที่สูงขึ้น

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

โดยค่าเริ่มต้น พื้นที่ที่ถูกครอบของภาพอาจถูกลบออกจากผลลัพธ์ที่ส่งออก เก็บข้อมูลที่ครอบไว้เฉพาะเมื่อผู้ใช้จำเป็นต้องกู้คืนหรือตรวจสอบส่วนภาพที่ซ่อนนั้น การเก็บไว้จะทำให้ขนาด HTML เพิ่มขึ้น

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

สำหรับการจัดรูปแบบอย่างง่าย ให้ส่งสตริง CSS ไปยัง `HtmlFormatter.createDocumentFormatter` ซึ่งจะเปลี่ยนเอกสาร HTML รอบๆ ขณะที่ Aspose.Slides ยังคงเรนเดอร์เนื้อหาสไลด์ต่อไป

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

หากต้องการส่วนหัวของเอกสารแบบกำหนดเอง, ไฟล์ CSS ที่ลิงก์, หรือมาร์กอัปกำหนดเองรอบสไลด์และรูปร่าง ให้ทำการติดตั้ง [IHtmlFormattingController](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihtmlformattingcontroller/) แล้วส่งผ่านไปยัง [HtmlFormatter](https://reference.aspose.com/slides/th/java/com.aspose.slides/htmlformatter/) ด้วย `createCustomFormatter`

## **ฝังฟอนต์**

หากสภาพแวดล้อมเป้าหมายอาจไม่มีฟอนต์ของงานนำเสนอที่ติดตั้งไว้ ให้ฝังฟอนต์ลงใน HTML ด้วย [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/java/com.aspose.slides/embedallfontshtmlcontroller/) การฝังช่วยปรับปรุงความแม่นยำของภาพแต่จะเพิ่มขนาดผลลัพธ์

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

ให้ยกเว้นฟอนต์เฉพาะเมื่อคุณมั่นใจว่าบราวเซอร์หรือระบบเป้าหมายมีฟอนต์เหล่านั้นแล้ว สำหรับฟอนต์ของแบรนด์หรือฟอนต์ที่ไม่ค่อยพบ การฝังมักจะปลอดภัยกว่า

## **ลิงก์ไฟล์ฟอนต์แทนการฝัง**

เพื่อให้ขนาดไฟล์ HTML ลดลง คุณสามารถเขียนข้อมูลฟอนต์ลงในไฟล์ WOFF แยกต่างหากและเพิ่มกฎ `@font-face` ลงใน HTML ตัวช่วยด้านล่างขยาย [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/java/com.aspose.slides/embedallfontshtmlcontroller/) และเขียนทับ `writeFont`

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
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
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

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

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

ในตัวอย่างนี้ ไฟล์ฟอนต์จะถูกบันทึกไปที่ `html-output/fonts` และ HTML จะอ้างอิงพวกมันด้วย URL เช่น `fonts/BrandFont-normal-400.woff` หากไฟล์ HTML และฟอนต์ถูกปรับใช้ในตำแหน่งอื่น ให้เลือก `fontUrlPrefix` ให้ตรงกับเส้นทาง URL ที่ปรับใช้

## **บันทึกทรัพยากรเป็นไฟล์ภายนอก**

HTML แบบรวมทั้งหมดง่ายต่อการเคลื่อนย้าย แต่ทรัพยากร Base64 ที่ฝังอยู่ทำให้ไฟล์ใหญ่ หากแอปพลิเคชันของคุณต้องการไฟล์รูปภาพภายนอก ให้ทำการติดตั้ง [ILinkEmbedController](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) แล้วส่งผ่านไปยังคอนสตรัคเตอร์ของ [HtmlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/htmloptions/)

เมื่อคุณทำให้ทรัพยากรเป็นภายนอก ให้เลือกสองเส้นทางอย่างระมัดระวัง:

- เส้นทางการออกของระบบไฟล์ ซึ่งแอปพลิเคชันของคุณเขียนรูปภาพ, ฟอนต์, เสียง หรือวิดีโอที่สร้างขึ้น
- เส้นทาง URL ซึ่งเป็นสิ่งที่เบราว์เซอร์ใช้จากเอกสาร HTML เพื่อโหลดไฟล์เหล่านั้น

## **ส่งออกไฟล์สื่อ**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/th/java/com.aspose.slides/videoplayerhtmlcontroller/) ส่งออกวิดีโอและไฟล์เสียงและเขียน HTML ที่สามารถเล่นได้ในเบราว์เซอร์ ตัวสร้างของมันรับข้อมูล:

- `path`: ไดเรกทอรีที่ไฟล์สื่อที่สร้างขึ้นจะถูกเขียน
- `fileName`: ชื่อไฟล์ HTML ที่กำลังสร้าง
- `baseUri`: คำนำหน้าของ URI ที่เป็นแบบเต็มที่ใช้ในลิงก์ HTML ไปยังไฟล์สื่อ

หากไฟล์ HTML คือ `html-output/presentation.html` และไฟล์สื่อบันทึกไว้ใน `html-output/media` `path` ควรชี้ไปยังไดเรกทอรีสื่อบนดิสก์ ในขณะที่ `baseUri` ควรชี้ไปยังไดเรกทอรีเดียวกันจากมุมมองของเบราว์เซอร์ สำหรับการพรีวิวแบบโลคัล คุณสามารถสร้าง URI `file:///` จากไดเรกทอรีสื่อได้ สำหรับแอปพลิเคชันที่ปรับใช้ ให้ใช้ URL แบบเต็มของไดเรกทอรีสื่อที่เผยแพร่

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

ใช้ไดเรกทอรีผลลัพธ์ที่เป็นเอกลักษณ์ต่อแต่ละงานส่งออก โดยเฉพาะในแอปพลิเคชันเซิร์ฟเวอร์ เส้นทางผลลัพธ์ที่ใช้ร่วมกันอาจทำให้ไฟล์จากการแปลงต่างกันทับกันได้

## **ประสิทธิภาพและการจัดการทรัพยากร**

การแปลง HTML เป็นการดำเนินการเรนเดอร์ ดังนั้นเวลาในการประมวลผลและการใช้หน่วยความจำจะขึ้นอยู่กับจำนวนสไลด์, ความละเอียดของภาพ, ฟอนต์, เอฟเฟกต์, ชาร์ตและสื่อที่ฝังอยู่ ค่า DPI ของ `PicturesCompression` ที่สูงขึ้น, ฟอนต์ที่ฝัง, ผลลัพธ์ SVG และการเก็บส่วนที่ครอบของภาพสามารถเพิ่มความแม่นยำได้แต่โดยทั่วไปจะทำให้ขนาดผลลัพธ์เพิ่มขึ้น

- ทำลายอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ทุกครั้งทันที
- ใช้ไดเรกทอรีผลลัพธ์แยกกันสำหรับงานแยกต่างหาก
- หลีกเลี่ยงการฝังฟอนต์ที่ทั่วไป เว้นแต่ต้องการความแม่นยำ
- ลด DPI ของภาพเมื่อ HTML ใช้สำหรับพรีวิวหรือภาพขนาดย่อ
- เก็บงานนำเสนอแหล่ง, HTML ที่สร้าง, และทรัพยากรภายนอกไว้ด้วยกันจนกว่าจะมีเส้นทางการปรับใช้สุดท้าย

## **FAQ**

**ลิงก์ไฮเปอร์ลิงก์จะถูกเก็บไว้ในผลลัพธ์ HTML หรือไม่?**

ใช่ ลิงก์ไฮเปอร์ลิงก์ของงานนำเสนอจะถูกส่งออกเป็น HTML และยังคงคลิกได้เมื่อ URL ปลายทางใช้งานได้

**ฉันสามารถแปลงงานนำเสนอเป็น HTML พร้อมกันได้หรือไม่?**

ได้ แต่ห้ามแชร์อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เดียวกันข้ามเธรด ให้ประมวลผลไฟล์ต่างๆ ด้วยอินสแตนซ์งานนำเสนอแยกกัน, สตรีมแยกกัน, และไดเรกทอรีผลลัพธ์แยกกัน ดูที่ [multithreading guidance](/slides/th/java/multithreading/) เพื่อรายละเอียด

**วัตถุ Presentation ปลอดภัยต่อการทำงานหลายเธรดหรือไม่?**

ไม่ อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) หนึ่งควรถูกโหลด, แก้ไข, บันทึก, และทำลายบนเธรดเดียว สำหรับการทำงานพร้อมกัน ให้สร้างอินสแตนซ์แยกต่อเธรดหรือกระบวนการ

**ทำไมไฟล์ HTML ที่สร้างขึ้นถึงมีขนาดใหญ่?**

การส่งออกค่าเริ่มต้นอาจฝังทรัพยากรโดยตรงใน HTML ฟอนต์ที่ฝัง, ภาพ DPI สูง, สื่อ, เนื้อหา SVG, และการเก็บส่วนที่ครอบของภาพทั้งหมดทำให้ขนาดเพิ่มขึ้น ใช้ทรัพยากรภายนอก, ยกเว้นฟอนต์ที่ทั่วไปจากการฝัง, และลดค่า `PicturesCompression` เมื่อขนาดผลลัพธ์ที่เล็กลงมีความสำคัญมากกว่าความแม่นยำสูงสุด

**ทำไมขนาดฟอนต์ PowerPoint เช่น 24 pt จึงแสดงเป็น 17.999819 pt ใน HTML?**

สิ่งนี้เกิดขึ้นได้เนื่องจาก PowerPoint และ HTML ใช้โมเดล DPI ที่ต่างกัน PowerPoint เก็บขนาดข้อความเป็นจุดพิมพ์ตาม DPI 72 ส่วนการจัดรูปแบบ HTML พิจารณาเป็นพิกเซล CSS ในโมเดล DPI 96 เมื่อ Aspose.Slides ส่งออกงานนำเสนอเป็น HTML ขนาดฟอนต์จะถูกแปลงระหว่างสองระบบนี้ และการแปลงอาจทำให้เกิดการปัดเศษเล็กน้อย

ค่าดังกล่าวไม่ได้บ่งบอกว่าขนาดฟอนต์ที่มองเห็นจริงเปลี่ยนแปลง มันเป็นผลข้างเคียงทางคณิตศาสตร์ของการแปลงเมตริกซ์ข้อความระหว่าง PowerPoint และ HTML

**ฉันควรเลือก baseUri สำหรับการส่งออกสื่ออย่างไร?**

เลือกรายการ `baseUri` จากมุมมองของเบราว์เซอร์และส่งผ่านเป็น URI แบบเต็ม สำหรับพรีวิวโลคัล คุณสามารถสร้างจากไดเรกทอรีผลลัพธ์ด้วย `mediaDirectory.toUri().toString()` สำหรับการปรับใช้ ให้ใช้ URL แบบเต็มของไดเรกทอรีสื่อที่เผยแพร่ `path` ของระบบไฟล์และ `baseUri` ของเบราว์เซอร์ไม่จำเป็นต้องเป็นสตริงเดียวกัน แต่ต้องอธิบายตำแหน่งทรัพยากรเดียวกัน

**ฉันสามารถรวมสไลด์ที่ซ่อนได้หรือไม่?**

ได้ ตั้งค่า `ShowHiddenSlides` เป็น `true` บน [HtmlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/htmloptions/) เมื่อจำเป็นต้องส่งออกสไลด์ที่ซ่อน
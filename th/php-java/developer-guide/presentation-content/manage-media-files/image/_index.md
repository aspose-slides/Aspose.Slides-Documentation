---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในการนำเสนอด้วย PHP
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/php-java/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มรูป
- เพิ่มบิตแมพ
- แทนที่รูปภาพ
- แทนที่รูป
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- ทรัพยากร SVG ภายนอก
- ตัวแก้ไข SVG
- รูปภาพ SVG ที่เชื่อมโยง
- ฟอนต์ SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- presentation
- EMF
- SVG
- PHP
- Aspose.Slides
description: "ทำให้การจัดการรูปภาพใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java มีประสิทธิภาพมากขึ้นโดยเพิ่มประสิทธิภาพการทำงานและอัตโนมัติขั้นตอนการทำงานของคุณ."
---
## **บทนำ**

รูปภาพทำให้การนำเสนอมีความน่าสนใจและดึงดูดสายตามากขึ้น. ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพลงในสไลด์จากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ. เช่นเดียวกัน Aspose.Slides อนุญาตให้คุณเพิ่มรูปภาพลงในสไลด์การนำเสนอได้หลายวิธี.

{{% alert  title="เคล็ดลับ" color="primary" %}} 
Aspose มีตัวแปลงฟรี — [JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt) — ที่ช่วยให้คุณสร้างการนำเสนอจากภาพได้อย่างรวดเร็ว. 
{{% /alert %}} 

{{% alert title="ข้อมูล" color="info" %}}
หากคุณต้องการเพิ่มภาพเป็นกรอบรูป — โดยเฉพาะหากคุณตั้งใจจะปรับขนาด เพิ่มเอฟเฟกต์ หรือใช้ตัวเลือกการจัดรูปแบบมาตรฐานอื่น ๆ — ดูที่ [Picture Frame](/slides/th/php-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="หมายเหตุ" color="warning" %}}
คุณสามารถแปลงรูปภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้ ดูหน้าต่อไปนี้: แปลง [image to JPG](https://products.aspose.com/slides/th/php-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/th/php-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/th/php-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/th/php-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/th/php-java/conversion/png-to-svg/), และ [SVG to PNG](https://products.aspose.com/slides/th/php-java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides รองรับรูปภาพในรูปแบบที่เป็นที่นิยมเช่น JPEG, PNG, BMP, GIF และอื่น ๆ. 

## **เพิ่มรูปภาพที่เก็บไว้ในเครื่องลงสไลด์**

คุณสามารถเพิ่มรูปภาพหนึ่งหรือหลายรูปที่เก็บไว้บนคอมพิวเตอร์ของคุณลงในสไลด์การนำเสนอ ตัวอย่างโค้ด PHP ด้านล่างแสดงวิธีเพิ่มรูปภาพลงสไลด์:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **เพิ่มรูปภาพจากเว็บลงสไลด์**

หากรูปภาพที่คุณต้องการเพิ่มลงสไลด์ไม่ได้เก็บไว้ในคอมพิวเตอร์ของคุณ คุณสามารถเพิ่มโดยตรงจากเว็บได้

ตัวอย่างโค้ด PHP ด้านล่างแสดงวิธีเพิ่มรูปภาพจากเว็บลงสไลด์:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **เพิ่มรูปภาพลงใน Slide Master**

Slide Master จัดเก็บและควบคุมข้อมูลเช่นธีมและรูปแบบของสไลด์ที่ใช้มัน เมื่อคุณเพิ่มรูปภาพลงใน Slide Master รูปภาพจะปรากฏบนทุกสไลด์ที่อิงกับมาสเตอร์นั้น

ตัวอย่างโค้ด PHP ด้านล่างแสดงวิธีเพิ่มรูปภาพลงใน Slide Master:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **เพิ่มรูปภาพเป็นพื้นหลังสไลด์**

คุณสามารถใช้รูปภาพเป็นพื้นหลังของหนึ่งหรือหลายสไลด์ รายละเอียดเพิ่มเติมดูที่ *[Setting Images as Backgrounds for Slides](/slides/th/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **เพิ่ม SVG ลงในการนำเสนอ**

เนื้อหา SVG สามารถเพิ่มลงในการนำเสนอได้โดยใช้คลาส [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/). วัตถุ SVG ที่สร้างขึ้นสามารถเพิ่มลงใน Image Collection ของการนำเสนอและใช้สร้างกรอบรูปได้

ตัวอย่าง PHP ด้านล่างนำเข้า SVG string ที่เป็นอิสระทั้งหมด ทุกรูปภาพ สไตล์ และทรัพยากรอื่น ๆ ที่ใช้โดย SVG นี้ฝังอยู่โดยตรงในเนื้อหา SVG

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **นำเข้าเนื้อหา SVG พร้อมทรัพยากรภายนอก**

ไฟล์ SVG ที่ส่งออกจากเครื่องมือออกแบบ ตัวแก้ไขไดอะแกรม ระบบไอคอน และกระบวนการเว็บอาจอ้างอิงทรัพยากรที่จัดเก็บอยู่ภายนอกเอกสาร SVG ตัวอย่างเช่น SVG อาจมีลิงก์รูปภาพเช่น `images/photo.png` ค่า CSS `url(...)` หรือ URL ของฟอนต์

เพื่อเรียกเข้าเนื้อหา SVG ดังกล่าว ให้สร้างการนำเข้า [ExternalResourceResolver](https://reference.aspose.com/slides/th/php-java/aspose.slides/externalresourceresolver/) แล้วส่งร่วมกับ Base URI ไปยังคอนสตรัคเตอร์ของ [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/) ที่เหมาะสม Base URI ระบุตำแหน่งของเอกสาร SVG และใช้สำหรับแก้ไขลิงก์แบบสัมพันธ์

วัตถุ SVG image ให้เข้าถึงข้อมูลเกี่ยวกับ SVG ที่นำเข้าได้:

- `getSvgContent()` คืนค่า markup ของ SVG เป็นสตริง
- `getSvgData()` คืนค่าเนื้อหา SVG เป็นอาเรย์ไบต์
- `getBaseUri()` คืนค่า Base URI ที่ใช้สำหรับลิงก์แบบสัมพันธ์
- `getExternalResourceResolver()` คืนค่าตัวแก้ไขที่กำหนดให้กับวัตถุ SVG image

### **สร้างตัวแก้ไขทรัพยากรภายนอก**

ตัวแก้ไขมีสองเมธอด:

- `resolveUri` รวม Base URI กับลิงก์ทรัพยากรแบบสัมพันธ์และคืนค่า URI แบบเต็ม ให้คืนค่า `null` เมื่อไม่สามารถแก้ไขลิงก์หรือไม่อนุญาต
- `getEntity` คืนสตรีมที่อ่านได้สำหรับ URI ของทรัพยากรแบบเต็ม ให้คืนค่า `null` เมื่อทรัพยากรหาย บล็อก หรือไม่พร้อมใช้งาน สตรีมสำรองก็สามารถคืนค่าได้เมื่อเหมาะสม

ตัวอย่างตัวแก้ไขต่อไปนี้โหลดทรัพยากรที่เชื่อมโยงเฉพาะจากไดเรกทอรีในเครื่องที่ได้รับอนุญาต ทรัพยากรเครือข่ายและเส้นทางนอกไดเรกทอรีที่อนุญาตจะถูกบล็อก ภาพสำรองเลือกจะถูกคืนค่าถ้าลิงก์รูปภาพไม่สามารถแก้ไขได้

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // ตัวแก้ไขนี้ตั้งใจให้อนุญาตเฉพาะไฟล์ในเครื่องเท่านั้น.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // ใช้ภาพสำรองเฉพาะสำหรับทรัพยากรรูปภาพเท่านั้น การคืนสตรีมรูปภาพ
            // สำหรับฟอนต์หรือสไตล์ชีตที่หายไปจะไม่เป็นค่าที่ถูกต้อง.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **แก้ไขทรัพยากรที่เชื่อมโยงระหว่างการนำเข้า SVG**

สมมติว่า `assets/diagram.svg` มีการอ้างอิงแบบสัมพันธ์เช่น:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

ตัวอย่าง PHP ด้านล่างส่ง URI ของไฟล์ SVG เป็น Base URI และให้ตัวแก้ไขแบบกำหนดเอง ตัวแก้ไขจะเปลี่ยนลิงก์รูปภาพแบบสัมพันธ์เป็น URI แบบเต็มและคืนสตรีมที่มีทรัพยากรที่เชื่อมโยงขณะ Aspose.Slides ประมวลผล SVG

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// Base URI แสดงตำแหน่งของเอกสาร SVG.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// อ็อบเจ็กต์ SVG image เปิดเผยเนื้อหาแหล่งที่มา, ข้อมูลไบนารี, base URI และตัวแก้ไข.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

คลาส `SvgImage` ยังมีโอเวรโหลดที่รับข้อมูล SVG เป็นอาเรย์ไบต์หรือสตรีมอินพุตพร้อมตัวแก้ไขทรัพยากรภายนอกและ Base URI

{{% alert title="สำคัญ" color="warning" %}}
ตัวแก้ไขทรัพยากรทำให้ทรัพยากรภายนอกพร้อมใช้งานขณะ Aspose.Slides ประมวลผลและเรนเดอร์ SVG ไม่ได้แก้ไข markup ของ SVG ดั้งเดิมหรือฝังทรัพยากรที่แก้ไขเข้าไปโดยอัตโนมัติ

เมื่อเพิ่ม SVG image ลงใน Image Collection ของการนำเสนอ ไฟล์ PPTX อาจมีทั้งการแสดงผล SVG ดั้งเดิมและภาพ raster สำรอง ทรัพยากรที่เชื่อมโยงอาจปรากฏในภาพสำรองที่สร้างขึ้นขณะที่ลิงก์แบบสัมพันธ์เช่น `images/photo.png` ยังคงไม่เปลี่ยนแปลงใน SVG ที่เก็บไว้ แอปพลิเคชันที่เรนเดอร์ SVG ดั้งเดิมอาจละเว้นเนื้อหาที่เชื่อมโยงเมื่อทรัพยากรภายนอกต้นฉบับไม่พร้อมใช้งาน
{{% /alert %}}

### **สร้างรูปภาพ SVG แบบพกพา**

เพื่อสร้างรูปภาพ SVG ที่ไม่พึ่งพาไฟล์ภายนอก ให้ทำให้ SVG เป็นอิสระก่อนสร้าง `SvgImage` ตัวอย่างเช่น แทนที่ URL ของรูปภาพที่เชื่อมโยงด้วย URI `data:` ที่บรรจุข้อมูลรูปภาพ:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

หลังจากฝังทรัพยากรที่จำเป็นทั้งหมดในเนื้อหา SVG แล้ว ให้สร้าง `SvgImage` เพิ่มลงใน Image Collection ของการนำเสนอและแทรกลงในกรอบรูปตามตัวอย่างก่อนหน้า

### **จัดการกับทรัพยากรที่หายหรือถูกบล็อก**

ให้คืนค่า `null` จาก `resolveUri` เมื่อตัวระบุ URI ของทรัพยากรไม่ถูกต้อง ถูกห้าม หรือไม่สามารถแก้ไขได้ ให้คืนค่า `null` จาก `getEntity` เมื่อไม่สามารถอ่านทรัพยากรได้ Aspose.Slides จะดำเนินการประมวลผล SVG ต่อไปโดยไม่มีทรัพยากรนั้นเมื่อเป็นไปได้

สตรีมสำรองอาจคืนค่าเมื่อทรัพยากรหาย แต่เนื้อหาจะต้องเข้ากันได้กับประเภททรัพยากรที่ร้องขอ ตัวอย่างเช่น คืนสตรีมรูปภาพเฉพาะสำหรับรูปภาพที่หาย ไม่ใช่สำหรับฟอนต์หรือสไตล์ชีต

{{% alert title="ความปลอดภัย" color="warning" %}}
ห้ามแก้ไขเส้นทางไฟล์ใด ๆ หรือ URL เครือข่ายที่ไม่มีข้อจำกัดจากไฟล์ SVG ที่ไม่เชื่อถือได้ จำกัดสคีมที่อนุญาต ไดเรกทอรี และโฮสต์ที่อนุญาต สำหรับทรัพยากรเครือข่าย ให้กำหนดค่า timeout การเชื่อมต่อ ขนาดการตอบกลับสูงสุด และการตรวจสอบความถูกต้องของเนื้อหา
{{% /alert %}}

## **แปลง SVG เป็นชุดของรูปร่าง**

Aspose.Slides สามารถแปลง SVG ให้เป็นชุดของรูปร่างได้เช่นเดียวกับฟังก์ชันใน PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ให้โดยโอเวรโหลดของเมธอด [addGroupShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addgroupshape/) ของคลาส [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) ที่รับอ็อบเจ็กต์ [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/) เป็นอาร์กิวเมนต์แรก

ตัวอย่างโค้ด PHP ด้านล่างแสดงวิธีใช้เมธอดนี้เพื่อแปลงไฟล์ SVG เป็นชุดของรูปร่าง:

```php
// ชื่อไฟล์ SVG ต้นฉบับ.
$svgFileName = "sample.svg";

// ชื่อไฟล์การนำเสนอเอาต์พุต.
$outPptxPath = "presentation.pptx";

// สร้างการนำเสนอใหม่.
$presentation = new Presentation();
try {
    // อ่านเนื้อหาไฟล์ SVG.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // สร้างอ็อบเจกต์ SvgImage.
    $svgImage = new SvgImage($svgContent);

    // ดึงขนาดสไลด์.
    $slideSize = $presentation->getSlideSize()->getSize();

    // แปลงภาพ SVG เป็นกลุ่มของรูปร่างและปรับสเกลให้พอดีกับขนาดสไลด์.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // บันทึกการนำเสนอในรูปแบบ PPTX.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **เพิ่มรูปภาพเป็น EMF ลงสไลด์**

Aspose.Slides for PHP via Java อนุญาตให้คุณสร้างภาพ EMF จากแผ่นงาน Excel ด้วย Aspose.Cells แล้วเพิ่มลงสไลด์การนำเสนอ

ตัวอย่างโค้ด PHP ด้านล่างแสดงวิธีทำเช่นนั้น:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Save the workbook to a stream.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // เพิ่มไฟล์แบบเดิมเพื่อให้รูปภาพยังคงเป็นเวกเตอร์ EMF แทนที่จะถูกแรสเตอร์.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **แทนที่รูปภาพใน Image Collection**

Aspose.Slides ให้คุณแทนที่รูปภาพที่เก็บอยู่ใน Image Collection ของการนำเสนอ รวมถึงรูปภาพที่ใช้โดยรูปร่างของสไลด์ ส่วนนี้อธิบายวิธีอัปเดตรูปภาพในคอลเลกชันหลายวิธี คุณสามารถแทนที่รูปภาพโดยใช้ข้อมูลไบต์ดิบ อินสแตนซ์ของ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) หรือรูปภาพอื่นที่มีอยู่แล้วในคอลเลกชัน

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์การนำเสนอที่มีรูปภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. โหลดรูปภาพใหม่จากไฟล์เป็นอาเรย์ไบต์
3. แทนที่รูปภาพเป้าหมายด้วยรูปภาพใหม่โดยใช้เอาอาเรย์ไบต์
4. ในวิธีที่สอง โหลดรูปภาพเข้าสู่วัตถุ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) แล้วแทนที่รูปภาพเป้าหมายด้วยวัตถุนั้น
5. ในวิธีที่สาม แทนที่รูปภาพเป้าหมายด้วยรูปภาพที่มีอยู่แล้วใน Image Collection ของการนำเสนอ
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์การนำเสนอ.
$presentation = new Presentation("sample.pptx");
try {
    // วิธีแรก.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // วิธีที่สอง.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // วิธีที่สาม.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // บันทึกการนำเสนอลงไฟล์.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="ข้อมูล" color="info" %}}
ด้วยตัวแปลงฟรีของ Aspose อย่าง [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) คุณสามารถทำให้ข้อความเคลื่อนไหวและสร้าง GIF จากข้อความได้อย่างง่ายดาย. 
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความละเอียดของภาพต้นฉบับจะคงเดิมหลังจากแทรกหรือไม่?**

ใช่. พิกเซลต้นฉบับจะถูกเก็บไว้ แต่ลักษณะสุดท้ายขึ้นอยู่กับการปรับสเกลของ [picture](/slides/th/php-java/picture-frame/) ในสไลด์และการบีบอัดที่ทำในขั้นตอนบันทึก

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันบนหลายสิบสไลด์พร้อมกันคืออะไร?**

ใส่โลโก้ลงใน Master Slide หรือ Layout แล้วแทนที่ใน Image Collection ของการนำเสนอ — การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น

**SVG ที่แทรกเข้ามาสามารถแปลงเป็นรูปร่างที่แก้ไขได้หรือไม่?**

ได้. คุณสามารถแปลง SVG ให้เป็นกลุ่มของรูปร่าง หลังจากนั้นส่วนต่าง ๆ จะสามารถแก้ไขได้ด้วยคุณสมบัติของรูปร่างมาตรฐาน

**จะตั้งค่ารูปภาพเป็นพื้นหลังของหลายสไลด์พร้อมกันอย่างไร?**

[กำหนดรูปภาพเป็นพื้นหลัง](/slides/th/php-java/presentation-background/) ที่ Master Slide หรือ Layout ที่เกี่ยวข้อง — สไลด์ที่ใช้ Master/Layout นั้นจะสืบทอดพื้นหลังโดยอัตโนมัติ

**ทำอย่างไรเพื่อป้องกันไม่ให้การนำเสนอใหญ่เกินไปจากรูปภาพจำนวนมาก?**

ใช้รูปภาพเดียวซ้ำแทนการทำสำเนาเลือกความละเอียดที่เหมาะสมใช้การบีบอัดเมื่อบันทึกและเก็บกราฟิกที่ใช้บ่อยไว้บน Master เมื่อเหมาะสม
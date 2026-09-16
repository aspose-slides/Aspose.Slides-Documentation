---
title: ส่งออกงานนำเสนอเป็น XAML ใน Java
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/java/export-to-xaml/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- PowerPoint เป็น XAML
- OpenDocument เป็น XAML
- งานนำเสนอเป็น XAML
- PPT เป็น XAML
- PPTX เป็น XAML
- ODP เป็น XAML
- บันทึก PPT เป็น XAML
- บันทึก PPTX เป็น XAML
- บันทึก ODP เป็น XAML
- ส่งออก PPT เป็น XAML
- ส่งออก PPTX เป็น XAML
- ส่งออก ODP เป็น XAML
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ใน Java ด้วย Aspose.Slides—โซลูชันที่รวดเร็ว ปราศจาก Office ที่คงรูปแบบของคุณไว้ครบถ้วน."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการส่งออกงานนำเสนอ PowerPoint ไปยัง XAML โดยใช้ Aspose.Slides รวมถึงการแนะนำสั้น ๆ เกี่ยวกับ XAML แสดงวิธีการบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าปริยาย และสาธิตวิธีการปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความยังตอบคำถามทั่วไปบางข้อที่เกี่ยวกับฟอนท์สำรอง ความเข้ากันได้ของสแตก XAML และพฤติกรรมการส่งออกสไลด์ที่ซ่อนอยู่

## **เกี่ยวกับ XAML**

XAML เป็นภาษามาร์กอัปที่อิงตาม XML ใช้สำหรับอธิบายส่วนต่อประสานผู้ใช้ในเฟรมเวิร์กต่าง ๆ เช่น WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin.Forms

คุณสามารถทำงานกับไฟล์ XAML ในตัวออกแบบแบบภาพหรือเขียนและแก้ไขมาร์กอัปโดยตรง

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกปริยาย**

ตัวอย่าง Java ด้านล่างแสดงวิธีการส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าปริยาย:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

โดยปริยาย สไลด์ที่ส่งออกจะถูกบันทึกในโฟลเดอร์ย่อย `pres` ของไดเรกทอรีทำงานปัจจุบันของกระบวนการ ซึ่งได้จากการแก้ไขเส้นทางว่างโดยใช้ [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...). โฟลเดอร์จะถูกสร้างโดยอัตโนมัติ และภาพที่จำเป็นใด ๆ จะถูกบันทึกที่นั่นด้วย

ชื่อของโฟลเดอร์ผลลัพธ์ถูกนำมาจากชื่อไฟล์ต้นฉบับโดยไม่มีนามสกุล For `pres.pptx`, the output files are named `pres/Slide_1.xaml`, `pres/Slide_2.xaml` และต่อๆ ไป แม้คุณจะส่งพาธเต็มให้กับไฟล์อินพุต การสร้างโฟลเดอร์ผลลัพธ์จะทำแบบสัมพันธ์กับไดเรกทอรีทำงานปัจจุบัน ไม่ได้อยู่เคียงข้างไฟล์อินพุต

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกที่กำหนดเอง**

ใช้ interface [IXamlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloptions/) เพื่อควบคุมวิธีที่ Aspose.Slides ส่งออกงานนำเสนอเป็น XAML

เพื่อบันทึกผลลัพธ์ไปยังตำแหน่งที่กำหนดเอง ให้ implement [IXamlOutputSaver](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloutputsaver/) และส่งอ็อบเจกต์ของการทำงานของคุณไปยังเมธอด [setOutputSaver](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) ของ [XamlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/)

เพื่อรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ XAML ให้เรียก [setExportHiddenSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ด้วยค่า `true` ตามที่แสดงในตัวอย่าง Java ด้านล่าง:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **จับทุกผลงาน XAML ที่สร้างขึ้น**

การส่งออก XAML สามารถสร้างเอกสาร XAML สำหรับแต่ละสไลด์ที่ส่งออก รวมถึงรูปภาพและทรัพยากรสนับสนุนแยกต่างหาก กำหนด [IXamlOutputSaver](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloutputsaver/) ที่กำหนดเองให้กับ [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) เพื่อรับรายการเหล่านี้แทนการใช้ตัวบันทึกระบบไฟล์เริ่มต้น เริ่มการส่งออกด้วยเมธอดเฉพาะ XAML [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) ที่รับพารามิเตอร์ XAML options

### **ทำความเข้าใจวงจรชีวิตของ Callback**

Exporter จะเรียก [IXamlOutputSaver.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) แยกกันสำหรับแต่ละรายการที่สร้างขึ้น:

- `path` ระบุรายการและอาจรวมไดเรกทอรีแบบสัมพันธ์ เก็บข้อมูลนี้ไว้เพราะ XAML อาจอ้างอิงทรัพยากรด้วยเส้นทางสัมพันธ์
- `data` มีไบต์ของรายการ ภาพและทรัพยากรไบนารีอื่น ๆ ต้องไม่ถูกแปลงเป็นข้อความ
- ตัวบันทึกต้องรับผิดชอบในการเก็บหรือบันทึกข้อมูลก่อนคืนค่า ตัวอย่างจะคัดลอกอาร์เรย์ไบต์แต่ละอันไปยังหน่วยความจำของแอปพลิเคชัน
- ถือว่าการส่งออกสำเร็จก็ต่อเมื่อการบันทึกงานนำเสนอเสร็จสิ้นและทุก callback ทำงานสำเร็จ อย่าปกปิดข้อผิดพลาดการเก็บข้อมูลหรือเริ่มการเขียนเบื้องหลังโดยไม่ตรวจสอบ หากการบันทึกเกิดขึ้นภายหลัง ให้รายงานความสำเร็จรวมเฉพาะหลังขั้นตอนนั้นสำเร็จเช่นกัน

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ยังใช้กับตัวบันทึกที่กำหนดเอง การตั้งค่าเริ่มต้น `false` จะไม่รวมเอกสาร XAML ของสไลด์ที่ซ่อนอยู่ การตั้งค่าเป็น `true` จะรวมสไลด์และทรัพยากรที่จำเป็นสำหรับการส่งออก จำนวนทรัพยากรขึ้นอยู่กับงานนำเสนอ ไม่สมมติว่ามี callback หนึ่งครั้งต่อสไลด์หรือเรียงลำดับคงที่

### **ส่งออกไปยังหน่วยความจำและตรวจสอบรายการ**

ตัวอย่างเต็มนี้โหลด `pres.pptx` รวบรวมทุกรายการใน [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html), และพิมพ์ชื่อ, ประเภท และจำนวนไบต์ของแต่ละรายการ มันรักษาชื่อที่ให้มาอย่างแม่นยำ ชื่อซ้ำจะทำให้คอลเลกชันเป็นไม่ถูกต้องแทนการเขียนทับรายการโดยเงียบ ตัวอย่างจะตรวจสอบสิ่งนี้ก่อนใช้ผลลัพธ์

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // ทำการถอดรหัสเฉพาะ XAML เท่านั้น และเฉพาะเมื่อจำเป็นต้องตรวจสอบข้อความ
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

การตรวจสอบนามสกุลเป็นประโยชน์สำหรับการตรวจสอบ; เก็บรักษารายการทั้งหมดรวมถึงประเภททรัพยากรที่ไม่คุ้นเคย อย่าเปลี่ยนแปลงไบต์เมื่อต้องจัดเก็บหรือส่งต่อ ใช้ [String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) กับ UTF-8 เท่านั้นสำหรับ XAML ที่ต้องการการประมวลผลข้อความ

### **บรรจุรายการที่รวบรวมไว้ในไฟล์ ZIP**

ตัวอย่างแยกนี้รวบรวมการส่งออก, ตรวจสอบความถูกต้องของชื่อ, และเขียนไบต์ต้นฉบับลงในไฟล์ ZIP ชื่อไฟล์ ZIP ที่ไม่ซ้ำกันจะแยกงานส่งออกพร้อมกัน รายการใน ZIP ใช้สแลชหน้าและรักษาไดเรกทอรีสัมพันธ์ ชื่อที่ไม่ปลอดภัยหรือชื่อที่ชนกันหลังจากทำ normalization จะทำให้แพ็กเกจทั้งหมดถูกปฏิเสธก่อนเขียน

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // ไดเรกทอรี ZIP ได้รับการสรุปโดยการปิดก่อนการรายงานความสำเร็จ.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

ตัวอย่างใช้ [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) เพื่อเขียนไฟล์เก็บโลคัลหนึ่งไฟล์; ตัว exporter เองไม่เขียนไฟล์ XAML หรือรูปภาพแยก ส่วนการเก็บระยะไกล ให้แทนขั้นตอนการเขียนไฟล์ด้วยการอัปโหลดอาร์เรย์ไบต์ที่รวบรวม ใช้ตัวระบุงานส่งออกบวกกับชื่อรายการสัมพันธ์เต็มเป็นคีย์ blob หรือเก็บตัวระบุงาน, ชื่อสัมพันธ์, และข้อมูลไบต์ในแถวฐานข้อมูล เผยแพร่งานหลังจากอัปโหลดทั้งหมดสำเร็จหรือธุรกรรมฐานข้อมูล commit เรียกทำความสะอาดผลลัพธ์บางส่วนหากการบันทึกล้มเหลว

สำหรับงานนำเสนอขนาดใหญ่ ตัวบันทึกที่กำหนดเองสามารถบันทึกรายการแต่ละรายการโดยตรงไปยังที่เก็บของแอปพลิเคชันเพื่อหลีกเลี่ยงการเก็บสำเนาเพิ่มเติมของการส่งออกทั้งหมดในหน่วยความจำของแอปพลิเคชัน ให้ทำให้แต่ละ callback ทำงานแบบ synchronous จากมุมมองของ exporter: คืนค่าก็ต่อเมื่อปลายทางรับไบต์แล้ว และให้ข้อผิดพลาดส่งถึงผู้เรียกใช้

### **รักษาชื่อทรัพยากรและตรวจสอบการอ้างอิง**

- ทำการ normalize ตัวคั่นเส้นทางเมื่อปลายทางต้องการ แต่ให้รักษาไดเรกทอรีสัมพันธ์ อย่าใช้เฉพาะ [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) เว้นแต่ชื่อที่สร้างทั้งหมดเป็นเอกลักษณ์และการอ้างอิงทรัพยากรยังคงถูกต้อง
- ใช้การตรวจสอบชื่อเฉพาะปลายทาง เมื่อเขียนไฟล์แยก ให้ปฏิเสธพาธเริ่มต้นจาก root และส่วนการเดินย้อนกลับ แก้ไขปลายทางด้วย [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--), และตรวจสอบว่ามันอยู่ใต้ไดเรกทอรีส่งออกที่ตั้งไว้ รวมถึงตัวคั่นไดเรกทอรีในการตรวจสอบการครอบคลุม ใช้ไดเรกทอรีที่ควบคุมโดยแอปพลิเคชันโดยไม่มี symbolic links ที่อาจเปลี่ยนเส้นทางการเขียน
- ใช้ตัวบันทึกและเนมสเปซการเก็บแยกกันสำหรับแต่ละงานส่งออก ตรวจจับการชนกันหลังจากทำ normalization ของตัวคั่นและตามกฎการแยกแยะตัวพิมพ์ของปลายทาง
- ก่อนการเผยแพร่ ให้วิเคราะห์เอกสาร XAML แต่ละไฟล์เป็น XML และตรวจสอบการอ้างอิงทรัพยากรแบบไฟล์ เช่น แอตทริบิวต์ `Source` หรือ `ImageSource` ของรูปภาพ แก้ไข URI สัมพัทธ์แต่ละอันเทียบกับไดเรกทอรีของรายการ XAML ที่บรรจุ, ทำการ normalize ชื่อการเก็บที่ได้, และยืนยันว่าคีย์ในแผนที่, รายการ ZIP, หรืออ็อบเจกต์ที่เก็บมีอยู่ แยกการจัดการ URI ภายนอกและนิพจน์ XAML markup ออกจากชื่อไฟล์สัมพันธ์

เช่น ถ้า `pres/Slide_1.xaml` อ้างอิง `images/image1.png` ทรัพยากรที่เก็บต้องมีอยู่เป็น `pres/images/image1.png` การเก็บแค่ `image1.png` จะทำให้ความสัมพันธ์นี้เสียหาย สำหรับการเก็บแบบ object ให้รักษาโครงสร้างเดียวกันใต้คำนำหน้าของงานและทำให้ URL ของทรัพยากรเหล่านั้นเข้าถึงได้สำหรับผู้ใช้ XAML เปิด ZIP ที่เสร็จสมบูรณ์อีกครั้งเพื่อตรวจสอบชื่อรายการและไบต์ของทรัพยากร, และโหลดสไลด์ตัวอย่างในสภาพแวดล้อม XAML เป้าหมายเพื่อยืนยันว่ารูปภาพถูกแก้ไขอย่างถูกต้อง

## **คำถามที่พบบ่อย**

**ฉันจะทำให้ฟอนท์คาดการณ์ได้อย่างไรหากฟอนท์ดั้งเดิมไม่มีในเครื่อง?**

เรียกใช้ [setDefaultRegularFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) ใน [XamlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/) — มันจะถูกใช้เป็นฟอนท์สำรองระหว่างการส่งออกเมื่อฟอนท์ดั้งเดิมหายไป อย่างไรก็ตามไม่ได้รับประกันว่า XAML ที่สร้างจะอ้างอิงฟอนท์สำรองหรือว่าฟอนท์นั้นมีในเครื่องเป้าหมาย ตรวจสอบให้แน่ใจว่าฟอนท์ที่ XAML อ้างอิงมีอยู่ในสภาพแวดล้อมที่แสดงผล

**XAML ที่ส่งออกออกแบบมาสำหรับ WPF เท่านั้นหรือสามารถใช้กับสแตก XAML อื่นได้เช่นกัน?**

Aspose.Slides ส่งออก WPF XAML ผ่าน API สาธารณะของมัน ความเข้ากันได้กับสแตก XAML อื่น ๆ เช่น UWP และ Xamarin.Forms ไม่ได้รับประกัน ให้ทดสอบมาร์กอัปที่สร้างในสภาพแวดล้อมเป้าหมายของคุณ

**สไลด์ที่ซ่อนอยู่ได้รับการสนับสนุนหรือไม่, และวิธีป้องกันไม่ให้ถูกส่งออกโดยปริยาย?**

โดยปริยาย สไลด์ที่ซ่อนจะไม่ถูกรวม คุณสามารถควบคุมพฤติกรรมนี้ผ่าน [setExportHiddenSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ใน [XamlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/xamloptions/) — ปิดการใช้งานหากไม่ต้องการส่งออกสไลด์เหล่านั้น
---
title: ส่งออกงานนำเสนอเป็น XAML บน Android
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ด้วย Java ใช้ Aspose.Slides สำหรับ Android—โซลูชันรวดเร็ว ไม่ต้องใช้ Office ที่รักษาโครงร่างของคุณให้คงเดิม"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการส่งออกงานนำเสนอ PowerPoint ไปยัง XAML ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. มีบทนำสั้น ๆ เกี่ยวกับ XAML, แสดงวิธีการบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น, และสาธิตวิธีการปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อน. บทความยังตอบคำถามทั่วไปบางข้อที่เกี่ยวกับแบบอักษรสำรอง, ความเข้ากันได้ของสแตก XAML, และพฤติกรรมการส่งออกสไลด์ที่ซ่อน.

## **เกี่ยวกับ XAML**

XAML เป็นภาษามาร์คอัปที่อิง XML ใช้สำหรับอธิบายอินเทอร์เฟซผู้ใช้ในเฟรมเวิร์กเช่น WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin.Forms.

คุณสามารถทำงานกับไฟล์ XAML ในตัวออกแบบแบบภาพ หรือเขียนและแก้ไขมาร์คอัปโดยตรง.

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

ตัวอย่าง Java ด้านล่างแสดงวิธีการส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น:

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

โดยค่าเริ่มต้น, สไลด์ที่ส่งออกจะถูกบันทึกในโฟลเดอร์ย่อย `pres` ของไดเรกทอรีทำงานปัจจุบันของกระบวนการ. โฟลเดอร์นี้จะถูกสร้างโดยอัตโนมัติ, และรูปภาพที่ต้องการใด ๆ จะถูกบันทึกไว้ที่นั่นด้วย.

ชื่อโฟลเดอร์ผลลัพธ์จะถูกนำมาจากชื่อไฟล์ต้นฉบับโดยไม่มีส่วนขยาย. สำหรับ `pres.pptx`, ไฟล์ผลลัพธ์จะมีชื่อ `pres/Slide_1.xaml`, `pres/Slide_2.xaml` และต่อไป. แม้คุณจะส่งพาธแบบเต็มไปยังไฟล์นำเข้าก็ตาม, โฟลเดอร์ผลลัพธ์จะถูกสร้างสัมพันธ์กับไดเรกทอรีทำงานปัจจุบัน, ไม่ได้สร้างข้างเคียงไฟล์ต้นฉบับ.

บน Android, ใช้ไฟล์นำเข้าที่แอปของคุณสามารถเข้าถึงได้. ไดเรกทอรีทำงานอาจไม่สามารถเขียนได้; ใช้ตัวบันทึกผลลัพธ์แบบกำหนดเองเพื่อเก็บการส่งออกในหน่วยความจำหรือเขียนไปยังที่จัดเก็บของแอป, ตามที่แสดงด้านล่าง. XAML รูปแบบ WPF ที่สร้างขึ้นออกแบบมาสำหรับผู้รับที่เข้ากันได้และไม่ใช่ทรัพยากรเลเอาต์ของ Android.

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกที่กำหนดเอง**

ใช้อินเทอร์เฟซ [IXamlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ixamloptions/) เพื่อควบคุมวิธีที่ Aspose.Slides ส่งออกงานนำเสนอเป็น XAML.

เพื่อบันทึกผลลัพธ์ไปยังตำแหน่งที่กำหนดเอง, ให้ดำเนินการตาม [IXamlOutputSaver](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ixamloutputsaver/) แล้วส่งอ็อบเจ็กต์ของคุณไปยังเมธอด [setOutputSaver](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) ของ [XamlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/).

เพื่อรวมสไลด์ที่ซ่อนในผลลัพธ์ XAML, เรียก [setExportHiddenSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ด้วยค่า `true`, ตามตัวอย่าง Java ด้านล่าง:

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

## **จับทุกองค์ประกอบ XAML ที่สร้างขึ้น**

การส่งออก XAML สามารถสร้างเอกสาร XAML สำหรับแต่ละสไลด์ที่ส่งออกพร้อมกับรูปภาพและทรัพยากรสนับสนุนแยกต่างหาก. กำหนดตัว [IXamlOutputSaver](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ixamloutputsaver/) ที่กำหนดเองให้กับ [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) เพื่อรับองค์ประกอบเหล่านี้แทนการใช้ตัวบันทึกระบบไฟล์เริ่มต้น. เริ่มการส่งออกด้วยเมธอด overload ของ [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) ที่รับ XAML options.

### **เข้าใจวงจรของ Callback**

Exporter จะเรียก [IXamlOutputSaver.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) แยกกันสำหรับแต่ละองค์ประกอบที่สร้าง:

- `path` ระบุตัวอ้างอิงขององค์ประกอบและอาจรวมไดเรกทอรีสัมพันธ์. เก็บข้อมูลนี้ไว้เพราะ XAML อาจอ้างอิงทรัพยากรโดยใช้พาธสัมพันธ์.
- `data` มีไบต์ขององค์ประกอบ. รูปภาพและทรัพยากรไบนารีอื่น ๆ ต้องไม่ถอดรหัสเป็นข้อความ.
- ตัวบันทึกรับผิดชอบในการเก็บหรือคงข้อมูลก่อนคืนค่า. ตัวอย่างจะคัดลอกอาร์เรย์ไบต์แต่ละอันเข้าสู่หน่วยความจำที่เป็นของแอป.
- พิจารณาการส่งออกสำเร็จก็ต่อเมื่อเมธอดบันทึกงานนำเสนอคืนค่าและทุก callback ทำงานสำเร็จ. อย่าปิดข้อผิดพลาดการจัดเก็บหรือเริ่มการเขียนพื้นหลังที่ไม่ตรวจสอบ. หากการคงข้อมูลเกิดขึ้นภายหลัง, ให้รายงานความสำเร็จโดยรวมเฉพาะเมื่อขั้นตอนนั้นสำเร็จด้วย.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ยังใช้กับตัวบันทึกที่กำหนดเอง. การตั้งค่าเริ่มต้น `false` จะไม่รวมเอกสาร XAML ของสไลด์ที่ซ่อน. การตั้งค่าเป็น `true` จะรวมสไลด์เหล่านั้นและทรัพยากรที่จำเป็นสำหรับการส่งออก. จำนวนทรัพยากรขึ้นอยู่กับงานนำเสนอ; อย่าสันนิษฐานว่ามี callback หนึ่งครั้งต่อสไลด์หรือว่าเรียงลำดับคงที่.

### **ส่งออกไปยังหน่วยความจำและตรวจสอบองค์ประกอบ**

ตัวอย่างเต็มนี้โหลด `pres.pptx`, รวบรวมทุกองค์ประกอบใน [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) แล้วพิมพ์ชื่อ, ชนิด, และจำนวนไบต์. จะรักษาชื่อที่ให้มาตามเดิม. ชื่อซ้ำจะทำให้การรวบรวมเป็นข้อมูลไม่ถูกต้องแทนการเขททับโดยเงียบ. ตัวอย่างตรวจสอบก่อนใช้ผลลัพธ์.

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

    // ถอดรหัสเฉพาะ XAML เท่านั้น และทำเมื่อจำเป็นต้องตรวจสอบเป็นข้อความ
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

การตรวจสอบส่วนต่อท้ายเป็นประโยชน์สำหรับการสำรวจ; เก็บทุกองค์ประกอบรวมถึงประเภททรัพยากรที่ไม่คุ้นเคย. อยลี่ยบไบต์เมื่อจัดเก็บหรือส่งต่อ. ใช้ [String constructor](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) กับ UTF-8 เท่านั้นสำหรับ XAML ที่ต้องการการประมวลผลเป็นข้อความ.

### **บรรจุองค์ประกอบที่รวบรวมไว้ในไฟล์ ZIP**

ตัวอย่างอิสระนี้รวบรวมการส่งออก, ตรวจสอบชื่อ, และเขียนไบต์ดิบลงในไฟล์ ZIP. แทนที่ `/path/to/app/files` ด้วยพาธที่ได้จากเมธอด [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) ของคอนเท็กซ์ Android ของคุณ. ชื่อไฟล์ ZIP ที่ไม่ซ้ำกันจะแยกงานส่งออกพร้อมกัน. รายการ ZIP ใช้เครื่องหมายทศนิยมและเก็บไดเรกทอรีสัมพันธ์. ชื่อที่ไม่ปลอดภัยหรือที่ชนกันหลังการทำ normalization จะทำให้แพ็กเกจทั้งหมดถูกปฏิเสธก่อนเขียน.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
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

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // ไดเรกทอรี ZIP ถูกสรุปโดยการปิดก่อนรายงานความสำเร็จ.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

ตัวอย่างใช้ [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) เพื่อเขียนไฟล์ ZIP ท้องถิ่นหนึ่งไฟล์; ตัวส่งออกเองจะไม่เขียนไฟล์ XAML หรือรูปภาพแยกต่างหาก. สำหรับการจัดเก็บระยะไกล, แทนที่ขั้นตอนการเขียน ZIP ด้วยการอัปโหลดอาร์เรย์ไบต์ที่รวบรวมไว้. ใช้ตัวระบุงานส่งออกพร้อมชื่อทรัพยากรสัมพันธ์เต็มเป็นคีย์บล็อบ, หรือเก็บตัวระบุงาน, ชื่อสัมพันธ์, และข้อมูลไบนารีในแถวฐานข้อมูล. เผยแพร่งานหลังจากอัปโหลดทั้งหมดเสร็จหรือการทำธุรกรรมฐานข้อมูลคอมมิต. ทำความสะอาดผลลัพธ์บางส่วนหากการคงข้อมูลล้มเหลว.

สำหรับงานนำเสนอขนาดใหญ่, ตัวบันทึกที่กำหนดเองสามารถคงแต่ละองค์ประกอบโดยตรงไปยังที่จัดเก็บของแอปเพื่อหลีกเลี่ยงการเก็บสำเนาเพิ่มเติมของการส่งออกทั้งหมดในหน่วยความจำของแอป. รักษาแต่ละ callback ให้ทำงานแบบ synchronous จากมุมมองของผู้ส่งออก: คืนค่าก็ต่อเมื่อปลายทางรับไบต์แล้ว, และให้ข้อผิดพลาดส่งถึงผู้เรียก.

### **รักษาชื่อทรัพยากรและตรวจสอบการอ้างอิง**

- ปรับรูปแบบตัวคั่นพาธเมื่อปลายทางต้องการ, แต่คงไดเรกทอรีสัมพันธ์. อย่าใช้เฉพาะ [File.getName](https://developer.android.com/reference/java/io/File#getName()) เว้นแต่ชื่อที่สร้างทั้งหมดจะเป็นเอกลักษณ์และการอ้างอิงทรัพยากรยังคงใช้ได้.
- ใช้การตรวจสอบชื่อเฉพาะปลายทาง. เมื่เขียนไฟล์แยก, ปฏิเสธพาธที่เริ่มจากรากและส่วน traversal, แก้ปัญหาปลายทางด้วย [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()), แล้วตรวจสอบว่ามันยังคงอยู่ภายใต้ไดเรกทอรีส่งออกที่ตั้งใจ, รวมถึงตัวคั่นไดเรกทอรีในขั้นตอนการตรวจสอบ containment. ใช้ไดเรกทอรีที่แอปควบคุมโดยไม่มีลิงก์สัญลักษณ์ที่อาจเปลี่ยนเส้นทางการเขียน.
- ใช้ saver แยกและ namespace การจัดเก็บสำหรับแต่ละงานส่งออก. ตรวจจับการชนหลังการทำ normalization ของตัวคั่นและตามกฎความไวต่อกรณีของปลายทาง.
- ก่อนเผยแพร่, แยกวิเคราะห์แต่ละเอกสาร XAML เป็น XML และตรวจสอบการอ้างอิงทรัพยากรแบบไฟล์, เช่น attribute `Source` หรือ `ImageSource` ของรูปภาพ. แก้ URI สัมพัทธ์แต่ละอันเทียบกับไดเรกทอรีขององค์ประกอบ XAML ที่บรรจุ, ทำ normalization ของชื่อที่ได้, แล้วยืนยันว่าคีย์ใน map, รายการ ZIP, หรืออ็อบเจ็กต์ที่จัดเก็บมีอยู่. ปฏิบัติกับ URI ภายนอกและนิพจน์ markup ของ XAML แยกต่างหากจากชื่อไฟล์สัมพันธ์.

เช่น หาก `pres/Slide_1.xaml` อ้างอิง `images/image1.png`, ทรัพยากรที่จัดเก็บต้องมีอยู่เป็น `pres/images/image1.png`. การเก็บเฉพาะ `image1.png` จะทำให้ความสัมพันธ์นี้เสีย. สำหรับการจัดเก็บเป็นอ็อบเจ็กต์, คงโครงสร้างเดียวกันใต้ prefix ของงานและทำให้ URL ของทรัพยากรเหล่านั้นเข้าถึงได้สำหรับผู้ใช้ XAML. เปิดไฟล์ ZIP ที่เสร็จแล้วเพื่อยืนยันชื่อรายการและไบต์ของทรัพยากร, แล้วโหลดสไลด์ตัวอย่างในสภาพแวดล้อม XAML ปลายทางเพื่อยืนยันว่ารูปภาพถูกอ้างอิงอย่างถูกต้อง.

## **คำถามที่พบบ่อย**

**ฉันจะทำให้แน่ใจว่าแบบอักษรคาดเดาได้อย่างไรหากแบบอักษรต้นฉบับไม่มีในเครื่อง?**

เรียก [setDefaultRegularFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) ใน [XamlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/) — มันจะถูกใช้เป็นแบบอักษรสำรองในระหว่างการส่งออกเมื่อไม่พบแบบอักษรต้นฉบับ. สิ่งนี้ไม่รับประกันว่า XAML ที่สร้างจะอ้างอิงแบบอักษรสำรองหรือว่าแบบอักษรนั้นมีอยู่ในเครื่องเป้าหมาย. ตรวจสอบให้แน่ใจว่าแบบอักษรที่อ้างอิงโดย XAML มีอยู่ในสภาพแวดล้อมที่แสดงผล.

**XAML ที่ส่งออกออกแบบมาสำหรับ WPF เท่านั้นหรือสามารถใช้ในสแตก XAML อื่นได้หรือไม่?**

Aspose.Slides ส่งออก XAML รูปแบบ WPF ผ่าน API สาธารณะ. ความเข้ากันได้กับสแตก XAML อื่น, เช่น UWP และ Xamarin.Forms, ไม่ได้รับการรับประกัน. ทดสอบ markup ที่สร้างในสภาพแวดล้อมเป้าหมายของคุณ.

**สไลด์ที่ซ่อนได้รับการสนับสนุนหรือไม่และฉันจะป้องกันไม่ให้พวกมันถูกส่งออกโดยค่าเริ่มต้นได้อย่างไร?**

โดยค่าเริ่มต้น, สไลด์ที่ซ่อนจะไม่ถูกรวม. คุณสามารถควบคุมพฤติกรรมนี้ผ่าน [setExportHiddenSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ใน [XamlOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/xamloptions/) — ปิดการใช้งานหากคุณไม่จำเป็นต้องส่งออกสไลด์ที่ซ่อน.
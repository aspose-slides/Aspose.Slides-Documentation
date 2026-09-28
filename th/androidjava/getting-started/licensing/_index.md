---
title: การให้ใบอนุญาต
type: docs
weight: 90
url: /th/androidjava/licensing/
keywords:
- ใบอนุญาต
- ใบอนุญาตชั่วคราว
- ตั้งค่าใบอนุญาต
- ใช้ใบอนุญาต
- ตรวจสอบใบอนุญาต
- ไฟล์ใบอนุญาต
- เวอร์ชันทดลอง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ใช้, จัดการ และแก้ไขปัญหาใบอนุญาตใน Aspose.Slides สำหรับ Android via Java. รับประกันการเข้าถึงฟีเจอร์เต็มรูปแบบโดยไม่สะดุดด้วยคู่มือการให้ใบอนุญาตของเรา."
---
## **ภาพรวม**

Aspose.Slides สามารถใช้ได้ในโหมดประเมินหรือด้วยใบอนุญาตที่ถูกต้อง เวอร์ชันทดลองให้ฟังก์ชันการทำงานเดียวกับเวอร์ชันที่มีใบอนุญาต แต่จะเพิ่มลายน้ำการประเมินลงในทุกสไลด์ของแต่ละงานนำเสนอที่บันทึกและตัดข้อความที่โค้ดของคุณอ่านจากงานนำเสนอให้สั้นลง

บทความนี้อธิบายว่าการให้ใบอนุญาตทำงานอย่างไรใน Aspose.Slides และวิธีการใช้ใบอนุญาตก่อนใช้ไลบรารี สามารถโหลดใบอนุญาตจากไฟล์, สตรีม หรือทรัพยากรฝังตัวโดยใช้คลาส [คลาส License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) ได้ อีกทั้งบทความยังแสดงวิธีตรวจสอบว่าใบอนุญาตได้ถูกนำไปใช้อย่างถูกต้องหรือไม่

## **ประเมิน Aspose.Slides**

{{% alert color="info" title="Note" %}}
คุณสามารถดาวน์โหลดเวอร์ชันทดลองของ **Aspose.Slides for Android via Java** จาก[หน้าดาวน์โหลด](https://releases.aspose.com/slides/androidjava/). เวอร์ชันทดลองให้ฟังก์ชันการทำงานเดียวกับเวอร์ชันที่มีใบอนุญาตของผลิตภัณฑ์ แพ็คเกจทดลองเหมือนกับแพ็คเกจที่ซื้อ เวอร์ชันทดลองจะกลายเป็นแบบมีใบอนุญาตเมื่อคุณเพิ่มบรรทัดโค้ดบางส่วน (เพื่อใช้ใบอนุญาต)

เมื่อคุณพอใจกับการประเมิน **Aspose.Slides** คุณสามารถ[ซื้อใบอนุญาต](https://purchase.aspose.com/pricing/slides/android-java/)ได้ เราแนะนำให้คุณตรวจสอบประเภทการสมัครสมาชิกต่าง ๆ หากมีคำถาม ติดต่อทีมขายของ Aspose

ทุกใบอนุญาตของ Aspose มาพร้อมการสมัครสมาชิกหนึ่งปีสำหรับการอัปเกรดเป็นเวอร์ชันใหม่หรือการแก้ไขที่ปล่อยภายในระยะสมัครสมาชิก ผู้ใช้ที่มีผลิตภัณฑ์ที่มีใบอนุญาต (หรือแม้แต่เวอร์ชันทดลอง) จะได้รับการสนับสนุนทางเทคนิคฟรีและไม่จำกัดจำนวน
{{% /alert %}} 

**ข้อจำกัดของเวอร์ชันทดลอง**

* เวอร์ชันทดลอง (โดยไม่ระบุใบอนุญาต) ให้ฟังก์ชันการทำงานเต็มรูปแบบของผลิตภัณฑ์ แต่จะเพิ่มกล่องข้อความลายน้ำการประเมินลงในทุกสไลด์ของแต่ละงานนำเสนอที่บันทึก
* ข้อความที่โค้ดของคุณอ่านจากงานนำเสนอจะถูกตัดให้เหลือข้อความไม่กี่ตัวอักษรแรก ตามด้วยข้อความแจ้งข้อจำกัดของการประเมิน ข้อความที่โค้ดของคุณเขียนจะถูกบันทึกครบถ้วน

{{% alert color="info" title="Note" %}}
เพื่อทดสอบ Aspose.Slides โดยไม่มีข้อจำกัด คุณสามารถขอ**ใบอนุญาตชั่วคราว 30 วัน** ดูหน้าที่[วิธีขอใบอนุญาตชั่วคราว](https://purchase.aspose.com/temporary-license)สำหรับข้อมูลเพิ่มเติม
{{% /alert %}}

## **การให้ใบอนุญาตใน Aspose.Slides**

* เวอร์ชันทดลองจะกลายเป็นแบบมีใบอนุญาตเมื่อคุณซื้อใบอนุญาตและเพิ่มบรรทัดโค้ดบางส่วน (เพื่อใช้ใบอนุญาต)
* ใบอนุญาตเป็นไฟล์ XML ข้อความธรรมดาที่มีรายละเอียดเช่น ชื่อผลิตภัณฑ์ จำนวนผู้พัฒนาที่ได้รับใบอนุญาต วันที่หมดอายุการสมัครสมาชิก ฯลฯ
* ไฟล์ใบอนุญาตถูกเซ็นดิจิทัล ดังนั้นห้ามแก้ไขไฟล์ แม้การใส่บรรทัดว่างเพิ่มเข้าไปในเนื้อหาไฟล์ก็จะทำให้ใบอนุญาตไม่ถูกต้อง
* Aspose.Slides for Android via Java มักพยายามค้นหาใบอนุญาตในตำแหน่งต่อไปนี้:
  * เส้นทางที่ระบุโดยชัดเจน
  * โฟลเดอร์ที่มี Aspose.Slides.jar
* เพื่อหลีกเลี่ยงข้อจำกัดของเวอร์ชันทดลอง คุณต้องตั้งค่าใบอนุญาตก่อนใช้ **Aspose.Slides** คุณต้องตั้งค่าใบอนุญาตเพียงครั้งเดียวต่อแอปพลิเคชันหรือกระบวนการ

## **การใช้ใบอนุญาต**

ใบอนุญาตสามารถโหลดจาก **ไฟล์** หรือ **สตรีม** ได้

{{% alert color="info" title="Note" %}}
Aspose.Slides ให้คลาส [คลาส License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) สำหรับการทำงานที่เกี่ยวกับใบอนุญาต
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
ใบอนุญาตใหม่สามารถเปิดใช้งาน Aspose.Slides ได้เฉพาะกับเวอร์ชัน 21.4 ขึ้นไป เวอร์ชันก่อนหน้านี้ใช้ระบบใบอนุญาตที่แตกต่างและจะไม่รับรู้ใบอนุญาตเหล่านี้
{{% /alert %}}

### **ไฟล์**

วิธีง่ายที่สุดในการตั้งค่าใบอนุญาตคือการวางไฟล์ใบอนุญาตในโฟลเดอร์ที่มี Aspose.Slides.jar หรือใน JAR ของแอปของคุณ

{{% alert color="info" title="Note" %}}
บน Android ไลบรารีและแอปของคุณจะถูกรวมเป็น APK ดังนั้นจึงไม่มีโฟลเดอร์ที่มีไฟล์ JAR ของไลบรารี และเส้นทางแบบสัมพันธ์เช่น *Aspose.Slides.Android.via.Java.lic* จะไม่ชี้ไปยังไฟล์ในแอปของคุณ เพิ่มไฟล์ใบอนุญาตไปยัง assets ของแอปและโหลดจากสตรีมตามที่แสดงใน[สตรีมจากแอปแอสเซท์](#stream-from-app-assets)
{{% /alert %}}

โค้ด Java นี้แสดงวิธีตั้งค่าไฟล์ใบอนุญาต:

``` java
// สร้างอินสแตนซ์ของคลาส License
com.aspose.slides.License license = new com.aspose.slides.License();

// ตั้งค่าพาธไฟล์ใบอนุญาต
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
หากคุณวางไฟล์ใบอนุญาตในไดเรกทอรีอื่น เมื่อเรียกเมธอด [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) ชื่อไฟล์ใบอนุญาตที่อยู่ท้ายเส้นทางที่ระบุต้องตรงกับชื่อไฟล์ใบอนุญาตของคุณ

เช่นคุณอาจเปลี่ยนชื่อไฟล์ใบอนุญาตเป็น *Aspose.Slides.Android.via.Java.lic.xml* แล้วในโค้ดของคุณต้องส่งเส้นทางไปยังไฟล์ (จบด้วย *Aspose.Slides.Android.via.Java.lic.xml*) ไปยังเมธอด [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)
{{% /alert %}}

### **สตรีม**

คุณสามารถโหลดใบอนุญาตจากสตรีม โค้ด Java นี้แสดงวิธีใช้ใบอนุญาตจากสตรีม:

``` java
// สร้างอินสแตนซ์ของคลาส License
com.aspose.slides.License license = new com.aspose.slides.License();

// ตั้งค่าใบอนุญาตผ่านสตรีม
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **สตรีมจากแอปแอสเซ็ต**

ในแอป Android ให้วางไฟล์ใบอนุญาตในโฟลเดอร์ *assets* ของโมดูลแอป, *app/src/main/assets*, เพื่อให้รวมอยู่ใน APK เปิดไฟล์ด้วยเมธอด [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) และส่งสตรีมไปยังเมธอด [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) โค้ดจะทำงานภายใน `Activity` เช่นในเมธอด `onCreate` ก่อนที่แอปจะใช้ Aspose.Slides:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

ชื่อไฟล์ที่ส่งไปยังเมธอด [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) จะสัมพันธ์กับโฟลเดอร์ *assets* หากไฟล์ไม่อยู่ที่นั่น โค้ดจะบันทึกข้อผิดพลาดและ Aspose.Slides จะอยู่ในโหมดประเมิน เพื่อตรวจสอบว่าใบอนุญาตถูกใช้หรือไม่ ดู[การตรวจสอบใบอนุญาต](#validating-a-license)

## **การตรวจสอบใบอนุญาต**

เพื่อให้แน่ใจว่าใบอนุญาตตั้งค่าอย่างถูกต้อง คุณสามารถตรวจสอบได้ โค้ด Java นี้แสดงวิธีตรวจสอบใบอนุญาต:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **ความปลอดภัยในการทำงานหลายเธรด**

{{% alert color="warning" title="Warning" %}}
เมธอด [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) ไม่ปลอดภัยต่อการทำงานหลายเธรด หากเมธอดนี้ต้องถูกเรียกพร้อมกันจากหลายเธรด คุณอาจต้องใช้กลไกการซิงโครไนซ์ (เช่น lock) เพื่อหลีกเลี่ยงปัญหา
{{% /alert %}}

## **FAQ**

### ฉันสามารถใช้ใบอนุญาตในสภาพแวดล้อมที่ไม่มีการเชื่อมต่ออินเทอร์เน็ตได้หรือไม่?

ได้. การตรวจสอบใบอนุญาตทำในเครื่องโดยใช้ไฟล์ใบอนุญาต; ไม่จำเป็นต้องเชื่อมต่ออินเทอร์เน็ต

### จะเกิดอะไรขึ้นหลังจากการสมัครสมาชิกหนึ่งปีหมดอายุ? ไลบรารีจะหยุดทำงานหรือไม่?

ไม่. ใบอนุญาตเป็นแบบถาวร: คุณสามารถใช้เวอร์ชันที่ปล่อยก่อนวันที่สิ้นสุดการสมัครสมาชิกต่อไปได้; เพียงคุณจะไม่สามารถใช้เวอร์ชันใหม่ที่ออกหลังจากนั้นโดยไม่ต่ออายุใบอนุญาต
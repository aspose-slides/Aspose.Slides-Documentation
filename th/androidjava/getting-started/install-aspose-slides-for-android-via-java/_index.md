---
title: ติดตั้ง Aspose.Slides สำหรับ Android ผ่าน Java
type: docs
weight: 90
url: /th/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- ติดตั้ง Aspose.Slides
- ดาวน์โหลด Aspose.Slides
- ใช้ Aspose.Slides
- การติดตั้ง Aspose.Slides
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ติดตั้ง Aspose.Slides สำหรับ Android อย่างรวดเร็ว คู่มือแบบทีละขั้นตอน ข้อกำหนดระบบ และตัวอย่างโค้ด Java — เริ่มทำงานกับงานนำเสนอ PowerPoint ได้เลยวันนี้!"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการติดตั้ง Aspose.Slides for Android via Java และเพิ่มลงในโปรเจกต์ Android โดยอธิบายสองตัวเลือกการติดตั้ง: การเพิ่มไฟล์ JAR ของ Aspose.Slides ลงในโปรเจกต์ด้วยตนเองและการติดตั้งไลบรารีจาก Maven repository

บทความยังมีตัวอย่างขั้นตอนต่อขั้นตอนที่แสดงวิธีสร้างแอปพลิเคชัน Android ใหม่ใน Android Studio, อ้างอิงไลบรารี Aspose.Slides, สร้างงานนำเสนอ PowerPoint ด้วยโปรแกรม, และบันทึกเป็นรูปแบบ PPTX รวมถึงบันทึกย่อเกี่ยวกับการเวอร์ชันและตอบคำถามทั่วไปเกี่ยวกับการตรวจสอบการรวม, การจัดการการใช้หน่วยความจำ, และการลดขนาด JAR สุดท้าย

## **การติดตั้ง**
ก่อนหน้านี้ Aspose.Slides for Android via Java ถูกแจกจ่ายเป็นไฟล์ ZIP เดียวที่มีไฟล์ JAR, ตัวอย่างสาธิต, และเอกสารผลิตภัณฑ์

1. หากคุณต้องการใช้เวอร์ชันที่เก่ากว่า Aspose.Words for Android via Java 18.9 คุณต้องทำการเอาไฟล์ Aspose.Slides.Android.zip นั้นออกเป็นโฟลเดอร์ในไดเรกทอรีที่คุณต้องการ
1. เพิ่มไฟล์ Jar ที่แตกออกมาในแอปพลิเคชันของคุณโดยใช้การกำหนดค่า Build Path

### **เพิ่มการอ้างอิงถึง Aspose.Slides for Android via Java Jar**
1. ดาวน์โหลดเวอร์ชันล่าสุดของ [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/th/androidjava)
1. คัดลอก aspose-slides-18.9-android.via.java.jar ไปยังโฟลเดอร์ *libs/*ของโปรเจกต์ของคุณ

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **ติดตั้ง Aspose.Slides for Android via Java จาก Maven Repository**
1. เพิ่ม Maven repository ลงใน build.gradle ของคุณ.
1. เพิ่ม JAR ของ [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) เป็น dependency.

``` java

 // 1. เพิ่ม Maven repository ลงในไฟล์ build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. เพิ่ม JAR 'Aspose.Slides for Android via Java' เป็น dependency

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```
## **แอปพลิเคชันแรกของคุณที่ใช้ Aspose.Slides for Android via Java**
ในส่วนนี้ คุณจะได้เรียนรู้วิธีเริ่มต้นกับ Aspose.Slides for Android via Java เราจะแสดงวิธีตั้งค่าโปรเจกต์ Android ใหม่ตั้งแต่ต้น, เพิ่มการอ้างอิงถึงไฟล์ Aspose.Slides JAR, และสร้างงานนำเสนอ PowerPoint ใหม่ซึ่งบันทึกลงดิสก์ในรูปแบบ PPTX ตัวอย่างนี้ใช้ [Android Studio](https://developer.android.com/studio/index.html) สำหรับการพัฒนาและแอปทำงานบน Android Emulator เพื่อเริ่มต้นกับ Aspose.Slides for Android via Java ให้ทำตามขั้นตอนการสอนนี้เพื่อสร้างแอปที่ใช้ Aspose.Slides for Android via Java:

1. ดาวน์โหลดและติดตั้ง [Android Studio](https://developer.android.com/studio/index.html) ไปยังตำแหน่งใดก็ได้
1. เปิด Android Studio
1. สร้างโครงการ Android Application ใหม่

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)

1. คัดลอก aspose-slides-XX.XX-android.via.java.jar ไปยังโฟลเดอร์ libs ของโปรเจกต์ของคุณ

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)

1. เลือก Project Section (จากเมนูไฟล์) แล้วคลิกแท็บ Dependencies.
   1. คลิกปุ่ม "+" แล้วเลือกตัวเลือก file dependency.
   1. เลือกไลบรารี Aspose.Slides จากโฟลเดอร์ libs แล้วคลิก OK.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)

1. ซิงค์โปรเจกต์กับไฟล์ gradle หากจำเป็น. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)

1. เพื่อเข้าถึง SDcard จำเป็นต้องเพิ่มสิทธิพิเศษพิเศษ คลิกไฟล์ AndroidManifest.xml แล้วเลือกมุมมอง XML เพิ่มบรรทัดนี้ลงในไฟล์ <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />

![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)

1. กลับไปที่ส่วนโค้ดของแอปและเพิ่มการนำเข้าดังนี้: 

``` java

 import java.io.File;

import com.aspose.slides.IAutoShape;

import com.aspose.slides.IParagraph;

import com.aspose.slides.IPortion;

import com.aspose.slides.ISlide;

import com.aspose.slides.ITextFrame;

import com.aspose.slides.Presentation;

import com.aspose.slides.SaveFormat;

import com.aspose.slides.ShapeType;

import android.os.Environment;

```

จากนั้น ใส่โค้ดนี้ในบอดีของเมธอด onCreate เพื่อสร้าง Presentation ใหม่จากศูนย์โดยใช้ Aspose.Slides และบันทึกลง SDCard ในรูปแบบ PPTX.

``` java

 try

{

    // สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
    Presentation pres = new Presentation();



    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);



    // เพิ่ม AutoShape ประเภท Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // เพิ่ม TextFrame ให้กับ Rectangle
    ashp.addTextFrame(" ");



    // เข้าถึง text frame
    ITextFrame txtFrame = ashp.getTextFrame();



    // สร้างอ็อบเจ็กต์ Paragraph สำหรับ text frame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // สร้างอ็อบเจ็กต์ Portion สำหรับ paragraph
    IPortion portion = para.getPortions().get_Item(0);



    // ตั้งค่าข้อความ
    portion.setText("Aspose TextBox");



    // บันทึกไฟล์ PPTX ลงการ์ด
    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;
    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);
}

catch (Exception e)

{
   e.printStackTrace();
}

```

โค้ดเต็มควรหน้าตาดังนี้:

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)

1. ตอนนี้เรียกใช้งานแอปพลิเคชันอีกครั้ง ครั้งนี้โค้ด Aspose.Slides จะทำงานในพื้นหลังและสร้างเอกสารซึ่งบันทึกลง SDcard.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. เพื่อตรวจสอบเอกสารที่สร้างขึ้น ให้ไปที่เมนู Tools เลือก Android แล้วเลือก Android Device Monitor

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **การเวอร์ชัน**
ตั้งแต่ปี 2018 ระบบเวอร์ชันของ Aspose.Slides for Android via Java สอดคล้องกับ Aspose.Slides for Java

## **FAQ**

**ฉันจะตรวจสอบว่า Aspose.Slides ได้รวมอย่างถูกต้องหรือไม่?**

คอมไพล์โปรเจกต์ของคุณ, สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ว่างเปล่าและบันทึกด้วยชื่อใหม่ หากไฟล์ถูกสร้างโดยไม่เกิดข้อยกเว้น แสดงว่าไลบรารีได้ถูกรวมอย่างสำเร็จ

**ฉันจะจำกัดการใช้หน่วยความจำเมื่อประมวลผลงานนำเสนอขนาดใหญ่ได้อย่างไร?**

เพิ่มขีดจำกัดหน่วยความจำของ JVM เพียงเท่าที่จำเป็น และปิดแต่ละอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ในบล็อก `finally` เพื่อล้างแคชอย่างทันท่วงที การทำเช่นนี้จะป้องกันข้อผิดพลาด out‑of‑memory และทำให้การใช้หน่วยความจำโดยรวมคาดเดาได้ในกระบวนการแบบเป็นชุด

**ฉันสามารถตัดรูปแบบการส่งออกที่ไม่ต้องการเพื่อทำให้ขนาด JAR สุดท้ายเล็กลงได้หรือไม่?**

เวอร์ชันปัจจุบันของ Aspose.Slides จะจัดจำหน่ายเป็นไลบรารีแบบโมโนลิธเดียว ดังนั้นคุณไม่สามารถปิดการทำงานของตัวส่งออกเฉพาะเช่น PDF หรือ SVG ในขณะคอมไพล์ได้
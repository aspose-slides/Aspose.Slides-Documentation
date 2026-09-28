---
title: ติดตั้ง Aspose.Slides สำหรับ Android ผ่าน Java
type: docs
weight: 90
url: /th/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- ติดตั้ง Aspose.Slides
- ดาวน์โหลด Aspose.Slides
- ใช้งาน Aspose.Slides
- การติดตั้ง Aspose.Slides
- Gradle
- Maven repository
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่ม Aspose.Slides สำหรับ Android ผ่าน Java ลงในโปรเจกต์ Android Studio ด้วย Gradle จาก Maven repository ของ Aspose หรือเพิ่มไฟล์ JAR ด้วยตนเอง."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเพิ่ม Aspose.Slides for Android via Java ไปยังโครงการ Android วิธีที่แนะนำคือให้ Gradle ดาวน์โหลดไลบรารีจาก Maven repository ของ Aspose คุณยังสามารถดาวน์โหลดไฟล์ JAR และเพิ่มลงในโครงการของคุณด้วยตนเองได้

ไลบรารีนี้ไม่ได้เผยแพร่ไปยัง Maven Central หรือ Maven repository ของ Google แต่มีให้ใช้งานจาก repository ของ Aspose เองเป็น artifact `aspose-slides` พร้อม classifier `android.via.java`

## **ติดตั้งจาก Maven Repository ของ Aspose**

### **ขั้นตอนที่ 1: เพิ่ม Repository**

โครงการ Android Studio ใหม่จะประกาศ repository ของพวกมันในบล็อก `dependencyResolutionManagement` ของ *settings.gradle.kts* และ Gradle จะปฏิเสธ repository ที่ไฟล์ build ของโมดูลเพิ่มเข้ามา ให้เพิ่มบรรทัด `maven` ตามที่แสดงด้านล่างในบล็อก `repositories` ภายในบล็อกที่มีอยู่แล้วนั้น แทนการวางบล็อก `dependencyResolutionManagement` ที่สอง:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

### **ขั้นตอนที่ 2: เพิ่ม Dependency**

เพิ่มไลบรารีลงในบล็อก `dependencies` ของไฟล์ build ของโมดูลแอป, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

ส่วนสุดท้ายของพิกัด `android.via.java` คือ classifier ที่เลือกการสร้าง Android ของไลบรารี หากไม่มี Gradle จะไม่สามารถค้นหา artifact ได้

จากนั้นทำการ sync โปรเจกต์กับไฟล์ Gradle เพื่อให้ Gradle ดาวน์โหลดไลบรารี

### **เลือกเวอร์ชัน**

Aspose.Slides for Android via Java ไม่ได้สร้างสำหรับทุกเวอร์ชันใน repository การสร้างของมันเผยแพร่สำหรับบางเวอร์ชันของ Aspose.Slides for Java เท่านั้น และเวอร์ชันที่ไม่มีการสร้าง Android จะไม่สามารถ resolve ได้ เลือกเวอร์ชันที่ระบุในหน้า [Aspose.Slides for Android via Java download page](https://releases.aspose.com/slides/androidjava/)

### **สคริปต์การสร้าง Groovy**

หากโครงการของคุณใช้สคริปต์การสร้างแบบ Groovy ให้เพิ่มบรรทัด `maven` ไปยังบล็อก `repositories` ภายในบล็อก `dependencyResolutionManagement` ที่มีอยู่ของ *settings.gradle*:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

และเพิ่ม dependency ไปยัง *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **เพิ่มไฟล์ JAR ด้วยตนเอง**

หากคุณไม่สามารถใช้ Maven repository ได้ ให้นำไฟล์ JAR ไปใส่ในโปรเจกต์ของคุณ:

1. ดาวน์โหลดไฟล์ JAR จากโฟลเดอร์ของเวอร์ชันใน [Aspose's Maven repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) สำหรับเวอร์ชัน 26.9 ไฟล์คือ *aspose-slides-26.9-android.via.java.jar* ในโฟลเดอร์ *26.9*
1. คัดลอกไฟล์ไปยังโฟลเดอร์ *app/libs* ของโปรเจกต์ของคุณ สร้างโฟลเดอร์หากยังไม่มี
1. เพิ่มไฟล์ลงในบล็อก `dependencies` ของ *app/build.gradle.kts* แล้ว sync โปรเจกต์:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **สร้างการนำเสนอแรกของคุณ**

เมื่อโปรเจกต์ทำการ sync แล้ว ให้ดำเนินต่อกับ [Create Presentations](/slides/th/androidjava/create-presentation/) ตัวอย่างแรกของมันเพิ่มกล่องข้อความไปยังสไลด์และบันทึกการนำเสนอไปยังพื้นที่จัดเก็บส่วนตัวของแอปซึ่งไม่ต้องการสิทธิ์การเข้าถึง storage หากไม่มีไลเซนส์ Aspose.Slides จะใส่น้ำลายน้ำการประเมินผลบนทุกสไลด์ที่บันทึก; ดูที่ [Licensing](/slides/th/androidjava/licensing/)

## **การเวอร์ชัน**

ตั้งแต่ปี 2018 การกำหนดเวอร์ชันของ Aspose.Slides for Android via Java ได้ปฏิบัติตาม Aspose.Slides for Java การสร้างสำหรับ Android ไม่ได้เผยแพร่สำหรับทุกเวอร์ชันของ Java; ดูที่ [Choose a Version](#choose-a-version).

## **คำถามที่พบบ่อย**

### วิธีการตรวจสอบว่า Aspose.Slides ถูกผสานอย่างถูกต้องหรือไม่?

สร้างโปรเจกต์ของคุณ, สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ว่างและบันทึกด้วยชื่อใหม่ หากไฟล์ถูกสร้างขึ้นโดยไม่มีข้อยกเว้น แสดงว่าไลบรารีได้ถูกรวมอย่างสำเร็จ

### วิธีการจำกัดการใช้หน่วยความจำเมื่อประมวลผลการนำเสนอขนาดใหญ่?

เรียกเมธอด [dispose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#dispose--) ของแต่ละอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ในบล็อก `finally` เพื่อปล่อยทรัพยากรโดยเร็ว และประมวลผลการนำเสนอขนาดใหญ่ทีละหนึ่ง การทำเช่นนี้ช่วยป้องกันข้อผิดพลาด out-of-memory และทำให้การใช้หน่วยความจำโดยรวมคาดเดาได้ในกระบวนการแบบแบตช์

### ฉันสามารถยกเว้นรูปแบบการส่งออกที่ไม่ต้องการเพื่อทำให้ขนาด JAR สุดท้ายเล็กลงได้หรือไม่?

รุ่นปัจจุบันของ Aspose.Slides จะถูกจัดจำหน่ายเป็นไลบรารีโมโนลิธที่เป็นเอกเทศ ดังนั้นคุณไม่สามารถปิดการทำงานของตัวส่งออกเฉพาะเช่น PDF หรือ SVG ได้ในระหว่างการสร้าง
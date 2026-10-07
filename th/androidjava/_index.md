---
title: Aspose.Slides สำหรับ Android ผ่าน Java
second_title: Aspose.Slides สำหรับ Android
type: docs
weight: 40
url: /th/androidjava/
keywords:
- เอกสาร
- การประมวลผลการนำเสนอ
- การแปลงการนำเสนอ
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "เริ่มต้นที่นี่: เพิ่ม Aspose.Slides สำหรับ Android ผ่าน Java ลงในแอปของคุณ สร้างการนำเสนอแรก และค้นหาคู่มือสำหรับงานทั่วไป, อ้างอิง API และการสนับสนุน."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java เป็นไลบรารีคลาสสำหรับสร้าง อ่าน แก้ไข และแปลงงานนำเสนอ PowerPoint และ OpenDocument ในแอปพลิเคชัน Android โดยไม่ต้องใช้ Microsoft PowerPoint.

ไลบรารีนี้สามารถโหลดและบันทึกไฟล์ PPT, PPTX, PPS, POT และ ODP รวมถึงเวอร์ชันที่เปิดใช้งานมาโครและเทมเพลต และส่งออกเป็น PDF, XPS, HTML, SVG, TIFF, Markdown และรูปภาพ.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>เริ่มต้น</b></p>
<hr>
<p>เริ่มต้นใช้งาน</p>
<ul>
<li><a href="/slides/th/androidjava/install-aspose-slides-for-android-via-java/">การติดตั้ง</a></li>
<li><a href="/slides/th/androidjava/create-presentation/">สร้างการนำเสนอแรกของคุณ</a></li>
<li><a href="/slides/th/androidjava/getting-started/">คู่มือเริ่มต้น</a></li>
</ul>
<p>ประเมิน</p>
<ul>
<li><a href="/slides/th/androidjava/supported-file-formats/">รูปแบบไฟล์ที่รองรับ</a></li>
<li><a href="/slides/th/androidjava/evaluate-aspose-slides/">ข้อจำกัดของการทดลองใช้ฟรี</a></li>
<li><a href="/slides/th/androidjava/licensing/">การออกใบอนุญาต</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>สร้างด้วย Slides</b></p>
<hr>
<p>งานทั่วไป</p>
<ul>
<li><a href="/slides/th/androidjava/open-presentation/">เปิดการนำเสนอ</a></li>
<li><a href="/slides/th/androidjava/save-presentation/">บันทึกการนำเสนอ</a></li>
<li><a href="/slides/th/androidjava/convert-powerpoint-to-pdf/">แปลงเป็น PDF</a></li>
<li><a href="/slides/th/androidjava/convert-slide/">แปลงสไลด์เป็นรูปภาพ</a></li>
<li><a href="/slides/th/androidjava/manage-text/">แก้ไขข้อความและรูปร่าง</a></li>
</ul>
<p>เวิร์กโฟลว์ Slides</p>
<ul>
<li><a href="/slides/th/androidjava/powerpoint-charts/">ชาร์ต</a></li>
<li><a href="/slides/th/androidjava/powerpoint-animation/">แอนิเมชัน</a></li>
<li><a href="/slides/th/androidjava/manage-media-files/">เสียงและวิดีโอ</a></li>
<li><a href="/slides/th/androidjava/presentation-design/">การออกแบบสไลด์</a></li>
<li><a href="/slides/th/androidjava/merge-presentation/">รวมการนำเสนอ</a></li>
</ul>
<p>ตัวอย่าง</p>
<ul>
<li><a href="/slides/th/androidjava/examples/">ตัวอย่างตามองค์ประกอบสไลด์</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิงและสนับสนุน</b></p>
<hr>
<p>อ้างอิง</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">อ้างอิง API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">บันทึกการอัปเดต</a></li>
<li><a href="/slides/th/androidjava/known-issues/">ปัญหาที่ทราบ</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">หน้าผลิตภัณฑ์</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">ดาวน์โหลด</a></li>
</ul>
<p>การสนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">ฟอรั่มสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือสนับสนุนแบบชำระเงิน</a></li>
</ul>
</div>
</div>

------

## **การนำเสนอแรกของคุณ**

ไลบรารีนี้มาจาก Maven repository ของ Aspose โครงการ Android Studio ใหม่มีบล็อก `dependencyResolutionManagement` อยู่แล้วใน *settings.gradle.kts* เพิ่มบรรทัด `maven` ที่แสดงด้านล่างไปยังบล็อก `repositories` ภายในแทนการวางบล็อกที่สอง:

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

จากนั้นเพิ่มไลบรารีไปยัง *app/build.gradle.kts* แล้วซิงค์โครงการ:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installation](/slides/th/androidjava/install-aspose-slides-for-android-via-java/) ครอบคลุมสคริปต์การสร้างแบบ Groovy ไฟล์ JAR แบบแมนนวล และวิธีการเลือกเวอร์ชัน. โค้ดสำหรับการนำเสนอแรกของคุณอยู่ใน [Create Presentations](/slides/th/androidjava/create-presentation/): มันเพิ่มกล่องข้อความลงบนสไลด์และบันทึกการนำเสนอไปยังที่เก็บข้อมูลของแอป ตัวอย่างนี้ถูกคอมไพล์และสร้างเป็น APK; แต่ยังไม่ได้รันบนอุปกรณ์. หากไม่มีใบอนุญาต การนำเสนอที่บันทึกจะมีลายน้ำการประเมิน — ดูที่ [Licensing](/slides/th/androidjava/licensing/).
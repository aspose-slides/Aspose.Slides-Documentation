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
description: "เริ่มต้นที่นี่: เพิ่ม Aspose.Slides for Android via Java ไปยังแอปของคุณ สร้างการนำเสนอแรก และค้นหาคู่มือสำหรับงานทั่วไป การอ้างอิง API และการสนับสนุน"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java เป็นไลบรารีคลาสสำหรับการสร้าง อ่าน แก้ไข และแปลงการนำเสนอ PowerPoint และ OpenDocument ในแอปพลิเคชัน Android โดยไม่ต้องใช้ Microsoft PowerPoint.

ไลบรารีนี้สามารถโหลดและบันทึกไฟล์ PPT, PPTX, PPS, POT และ ODP รวมถึงรูปแบบที่มีมาโครและแม่แบบและสามารถส่งออกเป็น PDF, XPS, HTML, SVG, TIFF, Markdown และภาพได้.

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
<li><a href="/slides/th/androidjava/getting-started/">คู่มือเริ่มต้นใช้งาน</a></li>
</ul>
<p>ประเมิน</p>
<ul>
<li><a href="/slides/th/androidjava/supported-file-formats/">รูปแบบไฟล์ที่รองรับ</a></li>
<li><a href="/slides/th/androidjava/evaluate-aspose-slides/">ข้อจำกัดของการทดลองใช้</a></li>
<li><a href="/slides/th/androidjava/licensing/">การให้สิทธิ์การใช้งาน</a></li>
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
<li><a href="/slides/th/androidjava/convert-slide/">แปลงสไลด์เป็นภาพ</a></li>
<li><a href="/slides/th/androidjava/manage-text/">แก้ไขข้อความและรูปร่าง</a></li>
</ul>
<p>เวิร์กโฟลว์ของ Slides</p>
<ul>
<li><a href="/slides/th/androidjava/powerpoint-charts/">แผนภูมิ</a></li>
<li><a href="/slides/th/androidjava/powerpoint-animation/">แอนิเมชัน</a></li>
<li><a href="/slides/th/androidjava/manage-media-files/">ไฟล์เสียงและวิดีโอ</a></li>
<li><a href="/slides/th/androidjava/presentation-design/">การออกแบบสไลด์</a></li>
<li><a href="/slides/th/androidjava/merge-presentation/">ผสานการนำเสนอ</a></li>
</ul>
<p>ตัวอย่าง</p>
<ul>
<li><a href="/slides/th/androidjava/examples/">ตัวอย่างตามองค์ประกอบสไลด์</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิงและสนับสนุน</b></p>
<hr>
<p>เอกสารอ้างอิง</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">เอกสารอ้างอิง API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">บันทึกการปล่อย</a></li>
<li><a href="/slides/th/androidjava/known-issues/">ปัญหาที่ทราบ</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">ดาวน์โหลด</a></li>
</ul>
<p>สนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">ฟอรัมสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือสนับสนุนแบบจ่ายเงิน</a></li>
</ul>
</div>
</div>

------

## **การนำเสนอแรกของคุณ**

ไลบรารีนี้มาจากที่เก็บ Maven ของ Aspose โครงการ Android Studio ใหม่มักมีบล็อก `dependencyResolutionManagement` อยู่ใน *settings.gradle.kts* แล้ว เพิ่มบรรทัด `maven` ด้านล่างนี้เข้าไปในบล็อก `repositories` ภายในบล็อกนั้น แทนการวางบล็อกที่สอง:

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

จากนั้นเพิ่มไลบรารีไปที่ *app/build.gradle.kts* แล้วซิงค์โครงการ:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installation](/slides/th/androidjava/install-aspose-slides-for-android-via-java/) ครอบคลุมสคริปต์การสร้างด้วย Groovy ไฟล์ JAR แบบแมนนวล และวิธีเลือกเวอร์ชัน โค้ดสำหรับการนำเสนอแรกของคุณอยู่ที่ [Create Presentations](/slides/th/androidjava/create-presentation/): มันจะเพิ่มกล่องข้อความลงในสไลด์และบันทึกการนำเสนอไปยังที่เก็บของแอป ตัวอย่างนี้ได้ถูกคอมไพล์และสร้างเป็น APK แล้ว แต่ยังไม่ได้ทำงานบนอุปกรณ์ หากไม่มีใบอนุญาต การบันทึกการนำเสนอจะมีลายน้ำการประเมิน — ดูที่ [Licensing](/slides/th/androidjava/licensing/).
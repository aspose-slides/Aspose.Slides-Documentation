---
title: Aspose.Slides برای جاوا
second_title: Aspose.Slides برای جاوا
type: docs
weight: 20
url: /fa/java/
keywords:
- مستندات
- پردازش ارائه
- تبدیل ارائه
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "از اینجا شروع کنید: نصب Aspose.Slides برای Java، ایجاد اولین ارائه، و پیدا کردن راهنماها برای کارهای معمول، مرجع API و پشتیبانی."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java یک کتابخانهٔ کلاس برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument در برنامه‌های Java است، بدون نیاز به Microsoft PowerPoint.

این کتابخانه می‌تواند فایل‌های PPT، PPTX، PPS، POT و ODP را بارگذاری و ذخیره کند، از جمله نسخه‌های دارای ماکرو و قالب، و به فرمت‌های PDF، XPS، HTML، SVG، TIFF، Markdown و تصاویر صادر شود.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع کنید</b></p>
<hr>
<p>شروع کار</p>
<ul>
<li><a href="/slides/fa/java/installation/">نصب</a></li>
<li><a href="/slides/fa/java/create-presentation/">ایجاد اولین ارائهٔ خود</a></li>
<li><a href="/slides/fa/java/getting-started/">راهنمای شروع کار</a></li>
</ul>
<p>ارزیابی</p>
<ul>
<li><a href="/slides/fa/java/supported-file-formats/">فرمت‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/java/evaluate-aspose-slides/">محدودیت‌های نسخه آزمایشی</a></li>
<li><a href="/slides/fa/java/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>کارهای معمول</p>
<ul>
<li><a href="/slides/fa/java/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/java/save-presentation/">ذخیره یک ارائه</a></li>
<li><a href="/slides/fa/java/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/java/convert-slide/">رندر اسلایدها به‌صورت تصویر</a></li>
<li><a href="/slides/fa/java/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>جریان کارهای Slides</p>
<ul>
<li><a href="/slides/fa/java/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/java/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/java/manage-media-files/">صدا و ویدیو</a></li>
<li><a href="/slides/fa/java/presentation-design/">طراحی اسلاید</a></li>
<li><a href="/slides/fa/java/merge-presentation/">ادغام ارائه‌ها</a></li>
</ul>
<p>نمونه‌ها</p>
<ul>
<li><a href="/slides/fa/java/examples/">نمونه‌ها بر پایه عنصر اسلاید</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">نمونه‌ها در گیت‌هاب</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>مرجع و پشتیبانی</b></p>
<hr>
<p>مرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/fa/java/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/fa/java/release-notes/">یادداشت‌های انتشار</a></li>
<li><a href="/slides/fa/java/known-issues/">مشکلات شناخته‌شده</a></li>
<li><a href="https://releases.aspose.com/slides/fa/java/">بارگیری</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/fa/11">تالار گفت‌وگوی پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">پشتیبانی با هزینه</a></li>
</ul>
</div>
</div>

------

## **اولین ارائهٔ شما**

Aspose.Slides برای Java در مخزن Maven اختصاصی Aspose منتشر می‌شود، نه در Maven Central. یک پوشه برای پروژه Maven ایجاد کنید و این *pom.xml* را در آن ذخیره کنید. این فایل مخزن را اعلام می‌کند، کتابخانه را اضافه می‌کند و نام کلاسی که باید اجرا شود را مشخص می‌نماید:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloSlides</exec.mainClass>
    </properties>

    <repositories>
        <repository>
            <id>AsposeJavaAPI</id>
            <name>Aspose Java API</name>
            <url>https://releases.aspose.com/java/repo/</url>
        </repository>
    </repositories>

    <dependencies>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides</artifactId>
            <version>26.9</version>
            <classifier>jdk16</classifier>
        </dependency>
    </dependencies>

    <build>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
        </plugins>
    </build>
</project>
```

این کد را به‌عنوان *src/main/java/HelloSlides.java* ذخیره کنید:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // یک ارائه ایجاد کنید. این ارائه از پیش یک اسلاید خالی دارد.
        Presentation presentation = new Presentation();
        try {
            // دریافت اولین اسلاید.
            ISlide slide = presentation.getSlides().get_Item(0);

            // یک شکل ابر اضافه کنید و متن داخل آن قرار دهید.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // ارائه را به‌عنوان فایل PPTX ذخیره کنید.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

سپس، با نصب JDK 11 یا بالاتر و Apache Maven، این فرمان را در پوشهٔ پروژه اجرا کنید:

```bash
mvn compile exec:java
```

این برنامه *new_presentation.pptx* را در پوشهٔ پروژه ذخیره می‌کند، که شامل یک اسلاید با شکل ابر و متن است. در لینوکس، fontconfig و حداقل یک قلم باید نصب شده باشند؛ ببینید [نصب](/slides/fa/java/installation/#linux). بدون مجوز، فایل ذخیره‌شده یک واترمارک ارزیابی دارد — ببینید [مجوزدهی](/slides/fa/java/licensing/). برای روش‌های بیشتر جهت ایجاد و پر کردن یک ارائه، ببینید [ایجاد ارائه‌ها](/slides/fa/java/create-presentation/).
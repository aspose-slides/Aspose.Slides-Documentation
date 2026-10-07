---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
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
description: "از اینجا شروع کنید: Aspose.Slides برای Java را نصب کنید، اولین ارائه را ایجاد کنید، و راهنماهای وظایف رایج، استقرار و مرجع API را پیدا کنید."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides برای جاوا" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides برای جاوا یک کتابخانهٔ کلاس برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument در برنامه‌های Java است، بدون نیاز به Microsoft PowerPoint.

این کتابخانه PPT, PPTX, PPS, POT و ODP را بارگذاری و ذخیره می‌کند، شامل نسخه‌های دارای ماکرو و قالب، و به PDF، XPS، HTML، SVG، TIFF، Markdown و تصاویر خروجی می‌دهد.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع به کار</b></p>
<hr>
<p>آغاز کار</p>
<ul>
<li><a href="/slides/fa/java/installation/">نصب</a></li>
<li><a href="/slides/fa/java/create-presentation/">ایجاد اولین ارائه شما</a></li>
<li><a href="/slides/fa/java/system-requirements/">نیازمندی‌های سیستم</a></li>
<li><a href="/slides/fa/java/getting-started/">راهنمای شروع کار</a></li>
</ul>
<p>ارزیابی</p>
<ul>
<li><a href="/slides/fa/java/supported-file-formats/">قالب‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/java/features-overview/">بررسی ویژگی‌ها</a></li>
<li><a href="/slides/fa/java/evaluate-aspose-slides/">محدودیت‌های آزمایشی</a></li>
<li><a href="/slides/fa/java/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>وظایف عمومی</p>
<ul>
<li><a href="/slides/fa/java/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/java/save-presentation/">ذخیره یک ارائه</a></li>
<li><a href="/slides/fa/java/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/java/convert-slide/">رندر اسلایدها به عنوان تصویر</a></li>
<li><a href="/slides/fa/java/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>جریان‌های کاری Slides</p>
<ul>
<li><a href="/slides/fa/java/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/java/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/java/manage-media-files/">صدا و ویدئو</a></li>
<li><a href="/slides/fa/java/presentation-design/">طراحی اسلاید</a></li>
<li><a href="/slides/fa/java/merge-presentation/">ادغام ارائه‌ها</a></li>
</ul>
<p>نمونه‌ها</p>
<ul>
<li><a href="/slides/fa/java/examples/">نمونه‌ها بر اساس عنصر اسلاید</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">نمونه‌ها در گیت‌هاب</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>استقرار و پشتیبانی</b></p>
<hr>
<p>استقرار</p>
<ul>
<li><a href="/slides/fa/java/system-requirements/#linux">پیش‌نیازهای لینوکس</a></li>
<li><a href="/slides/fa/java/how-to-run-aspose-slides-in-docker/">اجرای در Docker</a></li>
<li><a href="/slides/fa/java/deploy-fonts/">فونت‌ها</a></li>
<li><a href="/slides/fa/java/security/">امنیت</a></li>
</ul>
<p>مرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">یادداشت‌های انتشار</a></li>
<li><a href="/slides/fa/java/known-issues/">مشکلات شناخته‌شده</a></li>
<li><a href="/slides/fa/java/api-limitations/">محدودیت‌های متادیتای خروجی</a></li>
<li><a href="https://products.aspose.com/slides/java/">صفحه محصول</a></li>
<li><a href="https://releases.aspose.com/slides/java/">دانلود</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">دفتر پشتیبانی پرداخت‌شده</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **اولین ارائه شما**

Aspose.Slides برای جاوا در مخزن Maven خود Aspose منتشر می‌شود، نه در Maven Central. یک پوشه برای پروژه Maven ایجاد کنید و این *pom.xml* را در آن ذخیره کنید. این فایل مخزن را تعریف می‌کند، کتابخانه را اضافه می‌کند و نام کلاس برای اجرا را مشخص می‌کند:

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

این کد را به عنوان *src/main/java/HelloSlides.java* ذخیره کنید:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // یک ارائه ایجاد کنید. این ارائه قبلاً یک اسلاید خالی دارد.
        Presentation presentation = new Presentation();
        try {
            // اولین اسلاید را دریافت کنید.
            ISlide slide = presentation.getSlides().get_Item(0);

            // یک شکل ابر اضافه کنید و متن داخل آن بگذارید.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // ارائه را به عنوان فایل PPTX ذخیره کنید.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

سپس، با JDK 11 یا بالاتر و نصب Apache Maven، این دستور را در پوشه پروژه اجرا کنید:

```bash
mvn compile exec:java
```

برنامه *new_presentation.pptx* را در پوشه پروژه ذخیره می‌کند، با یک اسلاید که شامل یک شکل ابر با متن است. در لینوکس، باید fontconfig و حداقل یک فونت نصب شود؛ به بخش [نصب](/slides/fa/java/installation/#linux) مراجعه کنید. بدون مجوز، فایل ذخیره‌شده دارای واترمارک ارزیابی است — به بخش [مجوزدهی](/slides/fa/java/licensing/) مراجعه کنید. برای روش‌های بیشتر برای ایجاد و پر کردن یک ارائه، به بخش [ایجاد ارائه‌ها](/slides/fa/java/create-presentation/) نگاه کنید.
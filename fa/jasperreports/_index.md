---
title: "Aspose.Slides برای JasperReports"
second_title: "Aspose.Slides برای JasperReports"
type: docs
weight: 70
url: /fa/jasperreports/
keywords:
- مستندات
- JasperReports
- JasperReports Server
- صادر کردن گزارش
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "از اینجا شروع کنید: نصب Aspose.Slides برای JasperReports، صادر کردن اولین گزارش به PowerPoint، و یافتن راهنماها برای صادرات، یکپارچه‌سازی JasperReports Server و پشتیبانی."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports یابنده‌های PowerPoint را به JasperReports Library و JasperReports Server اضافه می‌کند تا برنامه‌های جاوا و سرورهای گزارش بتوانند گزارش‌های پر شده را به‌عنوان ارائه‌نامه‌ها بدون Microsoft PowerPoint ذخیره کنند.

این ابزار یک گزارش پر شده را به فرمت‌های PPT و PPTX (یک اسلاید برای هر صفحه گزارش) و همچنین به PDF و HTML صادر می‌کند.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع کار</b></p>
<hr>
<p>شروع کار</p>
<ul>
<li><a href="/slides/fa/jasperreports/installing-aspose-slides-for-jasperreports/">نصب</a></li>
<li><a href="/slides/fa/jasperreports/product-overview/">نمای کلی محصول</a></li>
<li><a href="/slides/fa/jasperreports/system-requirements/">نیازمندی‌های سیستم</a></li>
<li><a href="/slides/fa/jasperreports/getting-started/">راهنمای شروع کار</a></li>
</ul>
<p>ارزیابی</p>
<ul>
<li><a href="/slides/fa/jasperreports/supported-file-formats/">قالب‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/jasperreports/evaluate-aspose-slides/">محدودیت‌های نسخه آزمایشی</a></li>
<li><a href="/slides/fa/jasperreports/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>صادر کردن</p>
<ul>
<li><a href="/slides/fa/jasperreports/ppt-pptx-pdf-and-html-export/">صادر به PPT، PPTX، PDF و HTML</a></li>
<li><a href="/slides/fa/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">نقشه‌برداری فونت‌ها</a></li>
<li><a href="/slides/fa/jasperreports/integration-with-jasperserver/">یکپارچه‌سازی با JasperReports Server</a></li>
</ul>
<p>مثال‌ها</p>
<ul>
<li><a href="/slides/fa/jasperreports/demos-setup/">پروژه‌های نمایشی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>مرجع &amp; پشتیبانی</b></p>
<hr>
<p>مرجع</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">یادداشت‌های انتشار</a></li>
<li><a href="https://products.aspose.com/slides/jasperreports/">صفحه محصول</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">دانلود</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">پشتیبانی پولی</a></li>
</ul>
</div>
</div>

------

## **اولین خروجی شما**

این مراحل یک گزارش تک‌خطی را کامپایل می‌کنند، آن را پر می‌سازند و با JasperReports 6.16.0 از Maven Central به PPTX صادر می‌کنند. شما به JDK 11 یا بالاتر و Apache Maven نیاز دارید.

1. ZIP را از [صفحه دانلود](https://releases.aspose.com/slides/jasperreport/) دانلود کرده و آن را استخراج کنید. پوشه *lib* آن دارای یک زیرپوشه برای هر بازه‌ای از نسخه‌های JasperReports است و هر کدام jar مربوط به آن بازه را شامل می‌شود. برای JasperReports 6.16.0، *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* را به یک پوشه پروژه خالی کپی کنید.

2. jar در داخل ZIP می‌آید نه از مخزن Maven، بنابراین آن را در مخزن محلی Maven خود نصب کنید. این فرمان را در پوشه پروژه اجرا کنید:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. این *pom.xml* را در پوشه پروژه ذخیره کنید. این فایل JasperReports 6.16.0 و jar‌ای که نصب کرده‌اید را اضافه می‌کند و کلاس اجرا را نام‌گذاری می‌کند. JasperReports 6.16.0 یک نسخه‌ی اصلاح‌شده‌ی iText را اعلام می‌کند که در Maven Central موجود نیست، بنابراین این فایل آن را حذف می‌کند؛ خروجی‌سازهای Aspose به آن نیازی ندارند.

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-jasper-export</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloExport</exec.mainClass>
    </properties>

    <dependencies>
        <dependency>
            <groupId>net.sf.jasperreports</groupId>
            <artifactId>jasperreports</artifactId>
            <version>6.16.0</version>
            <exclusions>
                <exclusion>
                    <groupId>com.lowagie</groupId>
                    <artifactId>itext</artifactId>
                </exclusion>
            </exclusions>
        </dependency>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides-jasperreports</artifactId>
            <version>26.6</version>
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

4. این طرح گزارش را به عنوان *hello.jrxml* در پوشه پروژه ذخیره کنید. این فایل یک خط متن در نوار عنوان چاپ می‌کند:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<jasperReport xmlns="http://jasperreports.sourceforge.net/jasperreports"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xsi:schemaLocation="http://jasperreports.sourceforge.net/jasperreports http://jasperreports.sourceforge.net/xsd/jasperreport.xsd"
        name="Hello" pageWidth="595" pageHeight="842" columnWidth="555"
        leftMargin="20" rightMargin="20" topMargin="20" bottomMargin="20">
    <title>
        <band height="50">
            <staticText>
                <reportElement x="0" y="0" width="555" height="40"/>
                <textElement>
                    <font size="24"/>
                </textElement>
                <text><![CDATA[Hello from JasperReports!]]></text>
            </staticText>
        </band>
    </title>
</jasperReport>
```

5. این کد را به عنوان *src/main/java/HelloExport.java* ذخیره کنید. این کد طرح را کامپایل می‌کند، آن را با یک رکورد خالی پر می‌کند و نتیجه را با `ASPptxExporter` صادر می‌کند:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class HelloExport {
    public static void main(String[] args) throws Exception {
        // طرح گزارش را کامپایل کرده و با یک رکورد خالی پر می‌کند.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // گزارش پر شده را به PPTX صادر می‌کند.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. این فرمان را در پوشه پروژه اجرا کنید:

```bash
mvn compile exec:java
```

برنامه *hello.pptx* را در پوشه پروژه ذخیره می‌کند، با یک اسلاید که متن گزارش را در خود دارد. کامپایلر اشاره می‌کند که کد از API منسوخ‌شده استفاده می‌کند: خروجی‌سازها ورودی و خروجی خود را از طریق `JRExporterParameter` می‌گیرند و پیکربندی جدید `setExporterInput` و `setExporterOutput` را پذیرفته نمی‌شوند. در لینوکس، باید fontconfig و حداقل یک قلم نصب باشد، در غیر این صورت پر کردن گزارش شکست می‌خورد. بدون لایسنس، هر اسلاید یک واترمارک ارزیابی در مرکز خود دارد — برای جزئیات به [مجوزدهی](/slides/fa/jasperreports/licensing/) مراجعه کنید. برای صادر کردن به PPT، PDF یا HTML، به [صادر به PPT، PPTX، PDF و HTML](/slides/fa/jasperreports/ppt-pptx-pdf-and-html-export/) نگاه کنید.
---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /ar/jasperreports/
keywords:
- توثيق
- JasperReports
- JasperReports Server
- تصدير التقارير
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "ابدأ هنا: قم بتثبيت Aspose.Slides for JasperReports، صدّر أول تقرير إلى PowerPoint، وتجد الأدلة الخاصة بالتصدير، وتكامل خادم JasperReports، والدعم."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

تضيف Aspose.Slides for JasperReports مُصدِّرات PowerPoint إلى مكتبة JasperReports وخادم JasperReports، بحيث يمكن لتطبيقات Java وخوادم التقارير حفظ التقارير المملوءة كعروض تقديمية دون الحاجة إلى Microsoft PowerPoint.

يقوم بتصدير تقرير مملوء إلى PPT وPPTX، شريحة واحدة لكل صفحة من التقرير، وكذلك إلى PDF وHTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>ابدأ</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/jasperreports/installing-aspose-slides-for-jasperreports/">التثبيت</a></li>
<li><a href="/slides/ar/jasperreports/product-overview/">نظرة عامة على المنتج</a></li>
<li><a href="/slides/ar/jasperreports/system-requirements/">متطلبات النظام</a></li>
<li><a href="/slides/ar/jasperreports/getting-started/">دليل البدء</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/jasperreports/supported-file-formats/">الصيغ المدعومة للملفات</a></li>
<li><a href="/slides/ar/jasperreports/evaluate-aspose-slides/">قيود النسخة التجريبية</a></li>
<li><a href="/slides/ar/jasperreports/licensing/">التراخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>إنشاء باستخدام Slides</b></p>
<hr>
<p>تصدير</p>
<ul>
<li><a href="/slides/ar/jasperreports/ppt-pptx-pdf-and-html-export/">التصدير إلى PPT وPPTX وPDF وHTML</a></li>
<li><a href="/slides/ar/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">تعيين الخطوط</a></li>
<li><a href="/slides/ar/jasperreports/integration-with-jasperserver/">تكامل خادم JasperReports</a></li>
</ul>
<p>الأمثلة</p>
<ul>
<li><a href="/slides/ar/jasperreports/demos-setup/">مشاريع تجريبية</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>المرجع والدعم</b></p>
<hr>
<p>المرجع</p>
<ul>
<li><a href="https://releases.aspose.com/slides/ar/jasperreport/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="https://releases.aspose.com/slides/ar/jasperreport/">التنزيل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ar/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب مساعدة الدعم المدفوع</a></li>
</ul>
</div>
</div>

------

## **تصديرك الأول**

تقوم هذه الخطوات بتجميع تقرير من سطر واحد، تعبئته، وتصديره إلى PPTX باستخدام JasperReports 6.16.0 من Maven Central. تحتاج إلى JDK 11 أو أحدث وApache Maven.

1. قم بتنزيل ملف ZIP من [صفحة التنزيل](https://releases.aspose.com/slides/ar/jasperreport/) وفك ضغطه. يحتوي مجلد *lib* على مجلد فرعي واحد لكل نطاق من إصدارات JasperReports، ويحوي كل منها ملف jar لذلك النطاق. بالنسبة لـ JasperReports 6.16.0، انسخ *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* إلى مجلد مشروع فارغ.

2. ملف jar يأتي داخل ZIP بدلاً من مستودع Maven، لذا قم بتثبيته في مستودع Maven المحلي الخاص بك. نفّذ هذا الأمر في مجلد المشروع:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. احفظ هذا الملف *pom.xml* في مجلد المشروع. يضيف JasperReports 6.16.0 وملف jar الذي ثبّتَه، ويحدد الفئة التي سيتم تشغيلها. يعلن JasperReports 6.16.0 عن بنية iText مُعدَّلة غير موجودة على Maven Central، لذلك يستثني الملف ذلك؛ ولا تحتاج مُصدِّرات Aspose إليه.

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

4. احفظ تصميم هذا التقرير كملف *hello.jrxml* في مجلد المشروع. يطبع سطرًا واحدًا من النص في شريط العنوان:

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

5. احفظ هذا الكود كملف *src/main/java/HelloExport.java*. يَجمع التصميم، يملؤه بسجل فارغ واحد، ويصدّر النتيجة باستخدام `ASPptxExporter`:

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
        // تجميع تصميم التقرير وتعبئته بسجل فارغ واحد.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // تصدير التقرير المملوء إلى PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. نفّذ هذا الأمر في مجلد المشروع:

```bash
mvn compile exec:java
```

يقوم البرنامج بحفظ *hello.pptx* في مجلد المشروع، مع شريحة واحدة تحتوي على نص التقرير. يلاحظ المترجم أن الكود يستخدم API مُهمل: فإن المُصدِّرات تأخذ مدخلاتها ومخرجاتها عبر `JRExporterParameter`، ولا تقبل التكوين الجديد `setExporterInput` و`setExporterOutput`. على نظام Linux، يجب تثبيت fontconfig وعلى الأقل خط واحد، وإلا سيفشل ملء التقرير. بدون ترخيص، تحمل كل شريحة علامة مائية للتقييم في مركزها — انظر [التراخيص](/slides/ar/jasperreports/licensing/). للتصدير إلى PPT أو PDF أو HTML، راجع [تصدير إلى PPT وPPTX وPDF وHTML](/slides/ar/jasperreports/ppt-pptx-pdf-and-html-export/).
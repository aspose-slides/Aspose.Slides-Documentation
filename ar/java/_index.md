---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /ar/java/
keywords:
- توثيق
- معالجة العروض التقديمية
- تحويل العروض التقديمية
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "ابدأ هنا: ثبّت Aspose.Slides for Java، أنشئ أول عرض تقديمي، وابحث عن الأدلة للمهام الشائعة، النشر ومرجع API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java هي مكتبة فصول لإنشاء وقراءة وتعديل وتحويل عروض PowerPoint وOpenDocument في تطبيقات Java، دون الحاجة إلى Microsoft PowerPoint.

تقوم بتحميل وحفظ ملفات PPT وPPTX وPPS وPOT وODP، بما في ذلك الإصدارات التي تدعم الماكرو والقوالب، وتصدّر إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>البدء</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/java/installation/">التثبيت</a></li>
<li><a href="/slides/ar/java/create-presentation/">إنشاء أول عرض تقديمي لك</a></li>
<li><a href="/slides/ar/java/system-requirements/">متطلبات النظام</a></li>
<li><a href="/slides/ar/java/getting-started/">دليل البدء</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/java/supported-file-formats/">تنسيقات الملفات المدعومة</a></li>
<li><a href="/slides/ar/java/features-overview/">نظرة عامة على الميزات</a></li>
<li><a href="/slides/ar/java/evaluate-aspose-slides/">قيود النسخة التجريبية</a></li>
<li><a href="/slides/ar/java/licensing/">الترخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>الإنشاء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/java/open-presentation/">فتح عرض تقديمي</a></li>
<li><a href="/slides/ar/java/save-presentation/">حفظ عرض تقديمي</a></li>
<li><a href="/slides/ar/java/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/java/convert-slide/">تحويل الشرائح إلى صور</a></li>
<li><a href="/slides/ar/java/manage-text/">تحرير النص والأشكال</a></li>
</ul>
<p>سير عمل Slides</p>
<ul>
<li><a href="/slides/ar/java/powerpoint-charts/">الرسوم البيانية</a></li>
<li><a href="/slides/ar/java/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/java/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/java/presentation-design/">تصميم الشريحة</a></li>
<li><a href="/slides/ar/java/merge-presentation/">دمج العروض التقديمية</a></li>
</ul>
<p>أمثلة</p>
<ul>
<li><a href="/slides/ar/java/examples/">أمثلة حسب عنصر الشريحة</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">أمثلة على GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>النشر والدعم</b></p>
<hr>
<p>النشر</p>
<ul>
<li><a href="/slides/ar/java/system-requirements/#linux">متطلبات Linux</a></li>
<li><a href="/slides/ar/java/how-to-run-aspose-slides-in-docker/">التشغيل في Docker</a></li>
<li><a href="/slides/ar/java/deploy-fonts/">الخطوط</a></li>
<li><a href="/slides/ar/java/security/">الأمان</a></li>
</ul>
<p>المرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ar/java/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/ar/java/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="/slides/ar/java/known-issues/">المشكلات المعروفة</a></li>
<li><a href="/slides/ar/java/api-limitations/">قيود بيانات التعريف الناتجة</a></li>
<li><a href="https://releases.aspose.com/slides/ar/java/">التنزيل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ar/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب الدعم المدفوع</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **العرض التقديمي الأول**

Aspose.Slides for Java يتم نشره في مستودع Maven الخاص بـ Aspose، وليس في Maven Central. أنشئ مجلدًا لمشروع Maven واحفظ ملف *pom.xml* فيه. يعلن عن المستودع، يضيف المكتبة، ويسمي الفئة التي يجب تشغيلها:

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

احفظ هذا الكود كملف *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // إنشاء عرض تقديمي. يحتوي بالفعل على شريحة فارغة واحدة.
        Presentation presentation = new Presentation();
        try {
            // احصل على الشريحة الأولى.
            ISlide slide = presentation.getSlides().get_Item(0);

            // إضافة شكل سحابة ووضع نص فيه.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // حفظ العرض التقديمي كملف PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

بعد ذلك، مع تثبيت JDK 11 أو أحدث وApache Maven، شغّل هذا الأمر داخل مجلد المشروع:

```bash
mvn compile exec:java
```

يقوم البرنامج بحفظ *new_presentation.pptx* في مجلد المشروع، مع شريحة واحدة تحتوي على شكل سحابة مع نص. على نظام Linux، يجب تثبيت fontconfig وعلى الأقل خط واحد؛ انظر [التثبيت](/slides/ar/java/installation/#linux). بدون ترخيص، يحمل الملف المحفوظ علامة مائية للتقييم — انظر [الترخيص](/slides/ar/java/licensing/). لمزيد من الطرق لإنشاء ملء عرض تقديمي، انظر [إنشاء عروض تقديمية](/slides/ar/java/create-presentation/).
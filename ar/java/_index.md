---
title: "Aspose.Slides للـ Java"
second_title: "Aspose.Slides للـ Java"
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
description: "ابدأ هنا: ثبت Aspose.Slides للـ Java، أنشئ أول عرض تقديمي، وابحث عن الأدلة للمهام الشائعة، والنشر، ومرجع API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java هو مكتبة فئة لإنشاء وقراءة وتحرير وتحويل عروض PowerPoint وOpenDocument في تطبيقات Java، دون الحاجة إلى Microsoft PowerPoint.

تقوم بتحميل وحفظ صيغ PPT وPPTX وPPS وPOT وODP، بما في ذلك الإصدارات التي تدعم الماكرو والقوالب، وتصدّر إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>ابدأ</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/java/installation/">التثبيت</a></li>
<li><a href="/slides/ar/java/create-presentation/">إنشاء أول عرض تقديمي لك</a></li>
<li><a href="/slides/ar/java/system-requirements/">متطلبات النظام</a></li>
<li><a href="/slides/ar/java/getting-started/">دليل البدء</a></li>
</ul>
<p>تقييم</p>
<ul>
<li><a href="/slides/ar/java/supported-file-formats/">صيغ الملفات المدعومة</a></li>
<li><a href="/slides/ar/java/features-overview/">نظرة عامة على الميزات</a></li>
<li><a href="/slides/ar/java/evaluate-aspose-slides/">قيود النسخة التجريبية</a></li>
<li><a href="/slides/ar/java/licensing/">الترخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>البناء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/java/open-presentation/">فتح عرض تقديمي</a></li>
<li><a href="/slides/ar/java/save-presentation/">حفظ عرض تقديمي</a></li>
<li><a href="/slides/ar/java/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/java/convert-slide/">تصيير الشرائح كصور</a></li>
<li><a href="/slides/ar/java/manage-text/">تحرير النصوص والأشكال</a></li>
</ul>
<p>سير عمل Slides</p>
<ul>
<li><a href="/slides/ar/java/powerpoint-charts/">المخططات</a></li>
<li><a href="/slides/ar/java/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/java/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/java/presentation-design/">تصميم الشرائح</a></li>
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
<li><a href="/slides/ar/java/how-to-run-aspose-slides-in-docker/">تشغيل في Docker</a></li>
<li><a href="/slides/ar/java/deploy-fonts/">الخطوط</a></li>
<li><a href="/slides/ar/java/security/">الأمان</a></li>
</ul>
<p>المرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">وثائق API</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="/slides/ar/java/known-issues/">المشكلات المعروفة</a></li>
<li><a href="/slides/ar/java/api-limitations/">قيود بيانات التعريف المخرجة</a></li>
<li><a href="https://products.aspose.com/slides/java/">صفحة المنتج</a></li>
<li><a href="https://releases.aspose.com/slides/java/">التنزيل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">دعم مدفوع</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **أول عرض تقديمي لك**

Aspose.Slides for Java منشور في مستودع Maven الخاص بـ Aspose، وليس في Maven Central. أنشئ مجلدًا لمشروع Maven واحفظ فيه هذا *pom.xml*. يعلن عن المستودع، يضيف المكتبة، ويحدد الفئة التي سيتم تشغيلها:

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

احفظ هذا الكود في *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // إنشاء عرض تقديمي. يحتوي بالفعل على شريحة فارغة واحدة.
        Presentation presentation = new Presentation();
        try {
            // احصل على الشريحة الأولى.
            ISlide slide = presentation.getSlides().get_Item(0);

            // أضف شكل سحابة وضع النص فيه.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // احفظ العرض التقديمي كملف PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

بعد ذلك، مع تثبيت JDK 11 أو أحدث وApache Maven، شغّل هذا الأمر في مجلد المشروع:

```bash
mvn compile exec:java
```

يقوم البرنامج بحفظ *new_presentation.pptx* في مجلد المشروع، مع شريحة واحدة تحتوي على شكل سحابة مع نص. على Linux، يجب تثبيت fontconfig وعلى الأقل خط واحد؛ انظر [التثبيت](/slides/ar/java/installation/#linux). بدون ترخيص، يحتوي الملف المحفوظ على علامة مائية تقييم — انظر [الترخيص](/slides/ar/java/licensing/). لمزيد من الطرق لإنشاء ملء عرض تقديمي، انظر [إنشاء عروض تقديمية](/slides/ar/java/create-presentation/).
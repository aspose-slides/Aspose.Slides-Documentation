---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /ar/java/
keywords:
- توثيق
- معالجة العروض
- تحويل العروض
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "ابدأ هنا: قم بتثبيت Aspose.Slides for Java، أنشئ أول عرض تقديمي، وابحث عن الأدلة للمهام الشائعة، ومرجع API والدعم."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java هي مكتبة فئات لإنشاء وقراءة وتعديل وتحويل عروض PowerPoint وOpenDocument في تطبيقات Java، دون الحاجة إلى Microsoft PowerPoint.

يتم تحميل وحفظ ملفات PPT وPPTX وPPS وPOT وODP، بما في ذلك المتغيرات المدعومة للماكرو والقوالب، ويصدر إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>البدء</b></p>
<hr>
<p>بدء الاستخدام</p>
<ul>
<li><a href="/slides/ar/java/installation/">التثبيت</a></li>
<li><a href="/slides/ar/java/create-presentation/">إنشاء عرضك الأول</a></li>
<li><a href="/slides/ar/java/getting-started/">دليل البدء</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/java/supported-file-formats/">تنسيقات الملفات المدعومة</a></li>
<li><a href="/slides/ar/java/evaluate-aspose-slides/">قيود النسخة التجريبية</a></li>
<li><a href="/slides/ar/java/licensing/">التراخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>إنشاء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/java/open-presentation/">فتح عرض</a></li>
<li><a href="/slides/ar/java/save-presentation/">حفظ عرض</a></li>
<li><a href="/slides/ar/java/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/java/convert-slide/">إخراج الشرائح كصور</a></li>
<li><a href="/slides/ar/java/manage-text/">تحرير النص والأشكال</a></li>
</ul>
<p>سير عمل Slides</p>
<ul>
<li><a href="/slides/ar/java/powerpoint-charts/">الرسوم البيانية</a></li>
<li><a href="/slides/ar/java/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/java/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/java/presentation-design/">تصميم الشرائح</a></li>
<li><a href="/slides/ar/java/merge-presentation/">دمج العروض</a></li>
</ul>
<p>الأمثلة</p>
<ul>
<li><a href="/slides/ar/java/examples/">أمثلة حسب عنصر الشريحة</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">أمثلة على GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>المرجع والدعم</b></p>
<hr>
<p>المرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="/slides/ar/java/known-issues/">المشكلات المعروفة</a></li>
<li><a href="https://releases.aspose.com/slides/java/">التنزيل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب المساعدة للدعم المدفوع</a></li>
</ul>
</div>
</div>

------

## **عرضك الأول**

Aspose.Slides for Java مُنُشَر في مستودع Maven الخاص بـ Aspose، وليس في Maven Central. أنشئ مجلدًا لمشروع Maven واحفظ ملف *pom.xml* فيه. يعلن عن المستودع، يضيف المكتبة، ويحدّد الفئة التي سيتم تشغيلها:

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

احفظ هذا الكود كـ *src/main/java/HelloSlides.java*:

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

            // حفظ العرض كملف PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

بعد ذلك، مع وجود JDK 11 أو أحدث وApache Maven مثبتين، شغِّل هذا الأمر في مجلد المشروع:

```bash
mvn compile exec:java
```

يحفظ البرنامج ملف *new_presentation.pptx* في مجلد المشروع، مع شريحة واحدة تحتوي على شكل سحابة مع نص. على لينكس، يجب تثبيت fontconfig وعلى الأقل خط واحد؛ راجع [التثبيت](/slides/ar/java/installation/#linux). بدون ترخيص، يحتوي الملف المحفوظ على علامة مائية للتقييم — راجع [التراخيص](/slides/ar/java/licensing/). لمزيد من الطرق لإنشاء وملء عرض، راجع [إنشاء عروض](/slides/ar/java/create-presentation/).
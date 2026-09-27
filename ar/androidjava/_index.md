---
title: Aspose.Slides لأندرويد عبر Java
second_title: Aspose.Slides لأندرويد
type: docs
weight: 40
url: /ar/androidjava/
keywords:
- التوثيق
- معالجة العروض
- تحويل العروض
- PowerPoint
- OpenDocument
- أندرويد
- Java
- Aspose.Slides
description: "ابدأ هنا: أضف Aspose.Slides لأندرويد عبر Java إلى تطبيقك، أنشئ أول عرض تقديمي، وابحث عن الأدلة للمهام الشائعة، ومرجع API والدعم."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides لأندرويد عبر Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides لأندرويد عبر Java هي مكتبة فئات لإنشاء وقراءة وتحرير وتحويل عروض PowerPoint وOpenDocument في تطبيقات Android، دون الحاجة إلى Microsoft PowerPoint.

تقوم بتحميل وحفظ ملفات PPT و PPTX و PPS و POT و ODP، بما في ذلك الإصدارات المدعومة للماكرو والقوالب، وتصدّر إلى PDF و XPS و HTML و SVG و TIFF و Markdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>ابدأ</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/ar/androidjava/install-aspose-slides-for-android-via-java/">التثبيت</a></li>
<li><a href="/slides/ar/androidjava/create-presentation/">إنشاء عرضك التقديمي الأول</a></li>
<li><a href="/slides/ar/androidjava/getting-started/">دليل البدء</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/androidjava/supported-file-formats/">صيغ الملفات المدعومة</a></li>
<li><a href="/slides/ar/androidjava/evaluate-aspose-slides/">قيود النسخة التجريبية</a></li>
<li><a href="/slides/ar/androidjava/licensing/">التراخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>البناء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/androidjava/open-presentation/">فتح عرض تقديمي</a></li>
<li><a href="/slides/ar/androidjava/save-presentation/">حفظ عرض تقديمي</a></li>
<li><a href="/slides/ar/androidjava/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/androidjava/convert-slide/">تصيير الشرائح كصور</a></li>
<li><a href="/slides/ar/androidjava/manage-text/">تحرير النصوص والأشكال</a></li>
</ul>
<p>عمليات عمل Slides</p>
<ul>
<li><a href="/slides/ar/androidjava/powerpoint-charts/">المخططات</a></li>
<li><a href="/slides/ar/androidjava/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/androidjava/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/androidjava/presentation-design/">تصميم الشرائح</a></li>
<li><a href="/slides/ar/androidjava/merge-presentation/">دمج العروض</a></li>
</ul>
<p>أمثلة</p>
<ul>
<li><a href="/slides/ar/androidjava/examples/">أمثلة حسب عنصر الشريحة</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>المرجع والدعم</b></p>
<hr>
<p>المرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ar/androidjava/">وثائق API</a></li>
<li><a href="https://releases.aspose.com/slides/ar/androidjava/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="/slides/ar/androidjava/known-issues/">المشكلات المعروفة</a></li>
<li><a href="https://releases.aspose.com/slides/ar/androidjava/">التنزيل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ar/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب المساعدة المدفوع</a></li>
</ul>
</div>
</div>

------

## **العرض التقديمي الأول**

المكتبة تأتي من مستودع Maven الخاص بـ Aspose. مشاريع Android Studio الجديدة تحتوي بالفعل على كتلة `dependencyResolutionManagement` في *settings.gradle.kts*. أضف سطر `maven` الموضح أدناه إلى كتلة `repositories` داخلها، بدلاً من لصق كتلة ثانية:

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

ثم أضف المكتبة إلى *app/build.gradle.kts* ومزامنة المشروع:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[التثبيت](/slides/ar/androidjava/install-aspose-slides-for-android-via-java/) يشرح سكريبتات البناء Groovy، ملف JAR اليدوي، وكيفية اختيار الإصدار. الكود الخاص بالعرض التقديمي الأول موجود في [إنشاء العروض](/slides/ar/androidjava/create-presentation/): يضيف مربع نص إلى شريحة ويحفظ العرض في مساحة تخزين تطبيقك. تم تجميع هذا المثال وبناؤه كملف APK؛ لم يتم تشغيله على جهاز. بدون ترخيص، تحمل العروض المحفوظة علامة مائية للتقييم — راجع [التراخيص](/slides/ar/androidjava/licensing/).
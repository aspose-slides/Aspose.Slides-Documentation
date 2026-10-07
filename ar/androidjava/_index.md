---
title: Aspose.Slides for Android via Java
second_title: Aspose.Slides for Android
type: docs
weight: 40
url: /ar/androidjava/
keywords:
- التوثيق
- معالجة العروض التقديمية
- تحويل العروض التقديمية
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "ابدأ هنا: أضف Aspose.Slides for Android via Java إلى تطبيقك، أنشئ أول عرض تقديمي، واعثر على الأدلة للمهام الشائعة، ومرجع API والدعم."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides لنظام Android عبر Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java هو مكتبة فئات لإنشاء وقراءة وتحرير وتحويل عروض PowerPoint وOpenDocument في تطبيقات Android، دون الحاجة إلى Microsoft PowerPoint.

يقوم بتحميل وحفظ ملفات PPT وPPTX وPPS وPOT وODP، بما في ذلك المتغيرات التي تدعم الماكرو والقوالب، ويصدر إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>ابدأ</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/androidjava/install-aspose-slides-for-android-via-java/">التثبيت</a></li>
<li><a href="/slides/ar/androidjava/create-presentation/">إنشاء العرض التقديمي الأول الخاص بك</a></li>
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
<p><b>الإنشاء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/androidjava/open-presentation/">فتح عرض تقديمي</a></li>
<li><a href="/slides/ar/androidjava/save-presentation/">حفظ عرض تقديمي</a></li>
<li><a href="/slides/ar/androidjava/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/androidjava/convert-slide/">عرض الشرائح كصور</a></li>
<li><a href="/slides/ar/androidjava/manage-text/">تحرير النصوص والأشكال</a></li>
</ul>
<p>تدفقات عمل Slides</p>
<ul>
<li><a href="/slides/ar/androidjava/powerpoint-charts/">الرسوم البيانية</a></li>
<li><a href="/slides/ar/androidjava/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/androidjava/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/androidjava/presentation-design/">تصميم الشريحة</a></li>
<li><a href="/slides/ar/androidjava/merge-presentation/">دمج العروض التقديمية</a></li>
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
<li><a href="https://reference.aspose.com/slides/androidjava/">وثائق API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="/slides/ar/androidjava/known-issues/">قضايا معروفة</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">صفحة المنتج</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">تحميل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب الدعم المدفوع</a></li>
</ul>
</div>
</div>

------

## **العرض التقديمي الأول**

المكتبة تأتي من مستودع Maven الخاص بـ Aspose. تحتوي مشاريع Android Studio الجديدة بالفعل على كتلة `dependencyResolutionManagement` في *settings.gradle.kts*. أضف سطر `maven` الموضح أدناه إلى كتلة `repositories` داخلها، بدلاً من لصق كتلة ثانية:

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

[التثبيت](/slides/ar/androidjava/install-aspose-slides-for-android-via-java/) يغطي سكربتات البناء Groovy، ملف JAR اليدوي، وكيفية اختيار نسخة. الكود الخاص بالعرض التقديمي الأول موجود في [إنشاء عروض تقديمية](/slides/ar/androidjava/create-presentation/): يضيف مربع نص إلى شريحة ويحفظ العرض في تخزين التطبيق. تم تجميع هذا المثال وبنائه في ملف APK؛ لم يتم تشغيله على جهاز. بدون ترخيص، تحمل العروض المحفوظة علامة مائية تقييمية — راجع [التراخيص](/slides/ar/androidjava/licensing/).
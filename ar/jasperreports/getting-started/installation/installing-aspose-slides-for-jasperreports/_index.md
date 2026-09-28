---
title: تثبيت Aspose.Slides لـ JasperReports
type: docs
weight: 40
url: /ar/jasperreports/installing-aspose-slides-for-jasperreports/
description: "اختر ملفات jar الخاصة بـ Aspose.Slides لـ JasperReports التي تتطابق مع إصدار JasperReports لديك، وأضفها إلى JasperReports أو إلى مشروع Maven أو إلى JasperReports Server."
---
## **اختر ملفات jar لإصدار JasperReports الخاص بك**

Aspose.Slides for JasperReports يتم توزيعه كملف ZIP على صفحة [download page](https://releases.aspose.com/slides/ar/jasperreport/). يحتوي مجلد *lib* على مجلد فرعي واحد لكل نطاق من إصدارات JasperReports. خذ ملفات jar من المجلد الفرعي الذي يغطي إصدار JasperReports الذي تستخدمه:

| إصدار JasperReports | المجلد الفرعي لـ *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

لا يوجد مجلد فرعي لإصدار JasperReports 6.17.0 أو أحدث، بما في ذلك JasperReports 7. المجلد الفرعي *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* لا يحتوي على ملفات jar، فقط ملاحظة أن الدعم لتلك الإصدارات انتهى في Aspose.Slides for JasperReports 17.6.

يحتوي كل مجلد فرعي على ملفي jar؛ *xx.x* في أسمائهما هو إصدار المنتج:

- *aspose.slides.jasperreports.library-xx.x.jar* يحتوي على المُصدِّرات لـ JasperReports Library (`ASPptExporter`، `ASPptxExporter`، `ASPdfExporter` و `ASHtmlExporter`) وفئة `License`.
- *aspose.slides.jasperreports.server-xx.x.jar* يحتوي على إجراءات التصدير لـ JasperReports Server. يعتمد على ملف jar المكتبة، لذا يحتاج الخادم دائمًا إلى كلا ملفي jar من نفس المجلد الفرعي.

## **أضف ملف jar المكتبة إلى JasperReports أو تطبيقك**

انسخ *aspose.slides.jasperreports.library-xx.x.jar* من المجلد الفرعي المطابق إلى مجلد *lib* الخاص بـ JasperReports أو إلى مسار الفئات (classpath) لتطبيقك. يمكن لتطبيقك بعد ذلك إنشاء المُصدِّرات في الشيفرة.

{{% alert color="info" title="Note" %}}
على نظام Linux، يحتاج JasperReports إلى fontconfig وعلى الأقل خطًا واحدًا مُثبتًا لتعبئة التقرير. بدون الخطوط، تفشل عملية التعبئة مع الخطأ "Error initializing graphic environment".
{{% /alert %}}

## **أضف ملف jar المكتبة إلى مشروع Maven**

يأتي ملف jar ضمن ملف ZIP وليس من مستودع Maven. لاستخدامه في بناء Maven، قم بتثبيته في مستودع Maven المحلي الخاص بك. للإصدار 26.6، نفّذ هذا الأمر في المجلد الذي يحتوي على ملف jar:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

ثم أضفه إلى التبعيات في *pom.xml*، جنبًا إلى جنب مع إصدار JasperReports الذي يغطيه المجلد الفرعي لملف jar:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

معرفات المجموعة (group) والقطعة (artifact) هي تلك التي تختارها في أمر التثبيت؛ يجب أن تتطابق فقط. مشروع كامل يستخدم JasperReports 6.16.0 موجود في [Your first export](/slides/ar/jasperreports/#your-first-export).

## **أضف ملفات jar إلى JasperReports Server**

انسخ كلا ملفي jar من المجلد الفرعي المطابق إلى مجلد *WEB-INF/lib* لتطبيق الويب JasperReports Server، ثم سجّل المُصدِّرات كما هو موضح في [Integration with JasperServer](/slides/ar/jasperreports/integration-with-jasperserver/).
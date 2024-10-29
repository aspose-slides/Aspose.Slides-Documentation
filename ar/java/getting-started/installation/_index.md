---
title: التثبيت
type: docs
weight: 70
url: /ar/java/installation/
---

{{% alert color="primary" %}} 

لا يتطلب Aspose.Slides for Java برنامج Microsoft PowerPoint. يقوم بإنشاء ملفات العروض التقديمية المطلوبة برمجياً. ومع ذلك، لعرض عرض تقديمي تم إنشاؤه، قد تحتاج إلى استخدام PowerPoint أو عارض عروض تقديمية. 

{{% /alert %}} 

## **تثبيت وتكوين Java**
جافا هي لغة برمجة شهيرة تتيح لك تشغيل البرامج على العديد من المنصات. 

لمعلومات حول تثبيت وتكوين جافا على أي نظام تشغيل، يمكنك زيارة https://java.com/.

## **تثبيت Aspose.Slides for Java من مستودع Maven**
تستضيف Aspose جميع واجهات برمجة التطبيقات الخاصة بجافا على [مستودعات Maven](https://releases.aspose.com/java/repo/com/aspose/). يمكنك استخدام [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) API مباشرةً في مشاريع Maven الخاصة بك مع تكوينات بسيطة.

1. **تحديد تكوين مستودع Maven**

   حدد تكوين/موقع مستودع Aspose Maven في ملف pom.xml الخاص بك على النحو التالي:

``` xml
<repositories>
    <repository>
        <id>AsposeJavaAPI</id>
        <name>Aspose Java API</name>
        <url>https://releases.aspose.com/java/repo/</url>
    </repository>
</repositories>
```
2. **تعريف اعتمادية Aspose.Slides for Java API**

   قم بتعريف اعتمادية Aspose.Slides for Java API في ملف pom.xml الخاص بك على النحو التالي:

``` xml
<dependencies>
    <dependency>
        <groupId>com.aspose</groupId>
        <artifactId>aspose-slides</artifactId>
        <version>XX.XX</version>
        <classifier>jdk16</classifier>
    </dependency>
    <dependency>
        <groupId>com.aspose</groupId>
        <artifactId>aspose-slides</artifactId>
        <version>XX.XX</version>
        <classifier>javadoc</classifier>
    </dependency>
</dependencies>
```

سيتم بعد ذلك تعريف اعتماد Aspose.Slides for Java في مشروع Maven الخاص بك.
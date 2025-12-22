---
title: تثبيت Aspose.Slides لنظام Android عبر Java
type: docs
weight: 90
url: /ar/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- تثبيت Aspose.Slides
- تنزيل Aspose.Slides
- استخدام Aspose.Slides
- تثبيت Aspose.Slides
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "قم بتثبيت Aspose.Slides لنظام Android بسرعة. دليل خطوة بخطوة، متطلبات النظام، وعينات كود Java — ابدأ العمل على عروض PowerPoint التقديمية اليوم!"
---

## **التثبيت**
سابقًا، تم توزيع Aspose.Slides for Android via Java كملف ZIP واحد يحتوي على ملف JAR والعروض التوضيحية ووثائق المنتج. 

1. إذا كنت تريد استخدام نسخة أقدم من Aspose.Words for Android via Java 18.9، يجب فك ضغط نسخة Aspose.Slides.Android.zip إلى الدليل المفضل لديك. 
1. أضف ملف JAR المستخرج إلى تطبيقك باستخدام تكوين Build Path. 
### **إضافة مرجع إلى Aspose.Slides for Android via Java Jar**
1. حمّل أحدث نسخة من [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/androidjava)
1. انسخ aspose-slides-18.9-android.via.java.jar إلى مجلد *libs/* الخاص بمشروعك

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **تثبيت Aspose.Slides for Android via Java من مستودع Maven**
1. أضف مستودع Maven إلى ملف build.gradle الخاص بك. 
1. أضف JAR الخاص بـ [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) كاعتماد.
``` java

 // 1. أضف مستودع maven إلى ملف build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. أضف JAR الخاص بـ 'Aspose.Slides for Android via Java' كاعتماد

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```

## **التطبيق الأول الخاص بك باستخدام Aspose.Slides for Android via Java**
في هذا القسم، ستتعلم كيفية البدء مع Aspose.Slides for Android via Java. نهدف إلى إظهار كيفية إعداد مشروع Android جديد من الصفر، إضافة مرجع إلى مكتبة Aspose.Slides JAR، وإنشاء عرض تقديمي PowerPoint جديد يُحفظ على القرص بتنسيق PPTX. المثال هنا يستخدم [Android Studio](https://developer.android.com/studio/index.html) للتطوير ويتم تشغيل التطبيق على محاكي Android. للبدء مع Aspose.Slides for Android via Java، اتبع هذا البرنامج التعليمي خطوة بخطوة لإنشاء تطبيق يستخدم Aspose.Slides for Android via Java:

1. حمّل [Android Studio](https://developer.android.com/studio/index.html) وثبتها في أي موقع.
1. شغّل Android Studio.
1. أنشئ مشروع Android Application جديد.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)

1. ضع aspose-slides-XX.XX-android.via.java.jar في مجلد libs الخاص بمشروعك

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)

1. حدد قسم Project (من قائمة File) وانقر على علامة التبويب Dependencies.
   1. انقر على زر "+" واختر خيار الاعتماد من ملف.
   1. اختر مكتبة Aspose.Slides من مجلد libs وانقر على موافق.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)

1. مزامنة المشروع مع ملفات gradle إذا لزم الأمر. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)

1. للوصول إلى بطاقة SD، يجب إضافة أذونات خاصة. انقر على ملف AndroidManifest.xml واختر عرض XML. أضف هذا السطر إلى الملف <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />

![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)

1. عد إلى قسم الكود في التطبيق وأضف هذه الاستيرادات: 
``` java

 import java.io.File;

import com.aspose.slides.IAutoShape;

import com.aspose.slides.IParagraph;

import com.aspose.slides.IPortion;

import com.aspose.slides.ISlide;

import com.aspose.slides.ITextFrame;

import com.aspose.slides.Presentation;

import com.aspose.slides.SaveFormat;

import com.aspose.slides.ShapeType;

import android.os.Environment; 
```


الآن، أدخل هذا الكود في جسم طريقة onCreate لإنشاء عرض تقديمي جديد من الصفر باستخدام Aspose.Slides وحفظه على بطاقة SD بتنسيق PPTX. 
``` java
 try

{

    // إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
    Presentation pres = new Presentation();



    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);



    // إضافة AutoShape من النوع مستطيل
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // إضافة TextFrame إلى المستطيل
    ashp.addTextFrame(" ");



    // الوصول إلى إطار النص
    ITextFrame txtFrame = ashp.getTextFrame();



    // إنشاء كائن Paragraph لإطار النص
    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // إنشاء كائن Portion للفقرة
    IPortion portion = para.getPortions().get_Item(0);



    // تعيين النص
    portion.setText("Aspose TextBox");



    // حفظ ملف PPTX إلى الذاكرة الخارجية
    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;
    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);
}
catch (Exception e)
{
   e.printStackTrace();
}
```


الكود الكامل يجب أن يبدو هكذا:

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)

1. الآن شغّل التطبيق مرة أخرى. هذه المرة، سيعمل كود Aspose.Slides في الخلفية وينتج مستندًا يُحفظ على بطاقة SD.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. لعرض المستند الذي تم إنشاؤه، انتقل إلى قائمة Tools. اختر Android ثم حدد Android Device Monitor

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **الإصدار**
منذ عام 2018، يتطابق نظام إصدار Aspose.Slides for Android via Java مع Aspose.Slides for Java. 

## **الأسئلة الشائعة**

**كيف يمكنني التحقق من أن Aspose.Slides مدمجة بشكل صحيح؟**

قم ببناء مشروعك، وأنشئ كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) فارغًا، واحفظه باسم جديد. إذا تم إنشاء الملف دون إلقاء استثناءات، فتم دمج المكتبة بنجاح.

**كيف يمكنني الحد من استهلاك الذاكرة عند معالجة عروض تقديمية كبيرة؟**

ارفع حدود الذاكرة في JVM فقط إلى ما يلزم، وأغلق كل كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) في كتلة `finally` لتحرير الذاكرة فورًا. هذا يمنع أخطاء نقص الذاكرة ويجعل استهلاك الذاكرة الكلي متوقعًا أثناء عمليات الدُفعة.

**هل يمكنني استبعاد صيغ تصدير غير مرغوب فيها لتقليل حجم JAR النهائي؟**

الإصدارات الحالية من Aspose.Slides تُوزَّع كمكتبة أحادية، لذا لا يمكنك تعطيل مُصدِّرات محددة مثل PDF أو SVG أثناء عملية البناء.
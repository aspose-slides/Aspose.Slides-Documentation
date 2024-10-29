---
title: تثبيت Aspose.Slides لأندرويد عبر جافا
type: docs
weight: 90
url: /ar/androidjava/install-aspose-slides-for-android-via-java/
---




## **التثبيت**
في السابق، كان يتم توزيع Aspose.Slides لأندرويد عبر جافا كملف ZIP واحد يحتوي على ملف JAR والعروض التوضيحية ووثائق المنتج.

1. إذا كنت ترغب في استخدام إصدار أقدم من Aspose.Words لأندرويد عبر جافا 18.9، تحتاج إلى فك ضغط ذلك الإصدار من Aspose.Slides.Android.zip في الدليل المفضل لديك.
1. أضف ملف JAR الذي تم استخراجه في تطبيقك باستخدام تكوين مسار البناء.
### **إضافة مرجع إلى Aspose.Slides لأندرويد عبر جافا JAR**
1. قم بتنزيل أحدث إصدار من [Aspose.Slides لأندرويد عبر جافا](https://downloads.aspose.com/slides/androidjava)
1. انسخ aspose-slides-18.9-android.via.java.jar إلى مجلد *libs/* الخاص بمشروعك

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **تثبيت Aspose.Slides لأندرويد عبر جافا من مستودع Maven**
1. أضف مستودع Maven إلى build.gradle الخاص بك.
1. أضف [Aspose.Slides لأندرويد عبر جافا](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) JAR كاعتماد.

``` java

 // 1. أضف مستودع Maven إلى build.gradle الخاص بك 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. أضف 'Aspose.Slides لأندرويد عبر جافا' JAR كاعتماد

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```
## **أول تطبيق لك باستخدام Aspose.Slides لأندرويد عبر جافا**
في هذا القسم، ستتعلم كيفية البدء باستخدام Aspose.Slides لأندرويد عبر جافا. نعتزم أن نوضح لك كيفية إعداد مشروع أندرويد جديد من الصفر، وإضافة مرجع إلى JAR الخاص بـ Aspose.Slides، وإنشاء عرض PowerPoint جديد يتم حفظه على القرص بتنسيق PPTX. المثال هنا يستخدم [Android Studio](https://developer.android.com/studio/index.html) للتطوير ويُشغل التطبيق على محاكي أندرويد. لبدء استخدام Aspose.Slides لأندرويد عبر جافا، اتبع هذا البرنامج التعليمي خطوة بخطوة لإنشاء تطبيق يستخدم Aspose.Slides لأندرويد عبر جافا:

1. قم بتنزيل [Android Studio](https://developer.android.com/studio/index.html) وتثبيته في أي موقع.
1. قم بتشغيل Android Studio.
1. أنشئ مشروع تطبيق أندرويد جديد.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)





1. انسخ aspose-slides-XX.XX-android.via.java.jar إلى مجلد libs/ الخاص بمشروعك

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)




1. اختر قسم المشروع (من قائمة الملفات) وانقر على علامة التبويب التبعيات.
   1. انقر على زر "+"، واختر خيار التبعية للملف.
   1. اختر مكتبة Aspose.Slides من مجلد libs وانقر على "موافق".

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. قم بمزامنة المشروع مع ملفات Gradle إذا لزم الأمر. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. للوصول إلى بطاقة SD، يجب إضافة أذونات خاصة. انقر على ملف AndroidManifest.xml واختر عرض XML. أضف هذا السطر إلى الملف <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />



![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. انتقل مرة أخرى إلى قسم الكود في التطبيق وأضف هذه الاستيرادات: 

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

الآن، أدخل هذا الكود في جسم دالة onCreate لإنشاء عرض تقديمي جديد من البداية باستخدام Aspose.Slides وحفظه على بطاقة SD بتنسيق PPTX.

``` java

 try

{

    // إنشئ فئة Presentation التي تمثل PPTX

    Presentation pres = new Presentation();



    // الوصول إلى الشريحة الأولى

    ISlide sld = pres.getSlides().get_Item(0);



    // أضف AutoShape من نوع Rectangle

    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // أضف TextFrame إلى المستطيل

    ashp.addTextFrame(" ");



    // الوصول إلى إطار النص

    ITextFrame txtFrame = ashp.getTextFrame();



    // إنشاء كائن الفقرة لإطار النص

    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // إنشاء كائن Portion للفقرة

    IPortion portion = para.getPortions().get_Item(0);



    // تعيين النص

    portion.setText("Aspose TextBox");



    // حفظ PPTX إلى البطاقة

    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;

    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);

}

catch (Exception e)

{

   e.printStackTrace();

}

```

يجب أن يبدو الكود الكامل مثل هذا:

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)



1. الآن قم بتشغيل التطبيق مرة أخرى. هذه المرة، سيتم تشغيل كود Aspose.Slides في الخلفية وإنشاء مستند يتم حفظه على بطاقة SD.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. لرؤية المستند الذي تم إنشاؤه، انتقل إلى قائمة الأدوات. اختر أندرويد ثم حدد مراقب جهاز أندرويد

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **إصدار**
منذ عام 2018، يتوافق إصدار Aspose.Slides لأندرويد عبر جافا مع Aspose.Slides لجافا.
---
title: تثبيت Aspose.Slides for Android via Java
type: docs
weight: 90
url: /ar/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- تثبيت Aspose.Slides
- تحميل Aspose.Slides
- استخدام Aspose.Slides
- تثبيت Aspose.Slides
- Gradle
- مستودع Maven
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إضافة Aspose.Slides for Android via Java إلى مشروع Android Studio باستخدام Gradle من مستودع Maven الخاص بـ Aspose، أو إضافة ملف JAR يدويًا."
---
## **نظرة عامة**

تصف هذه المقالة طريقة إضافة Aspose.Slides for Android via Java إلى مشروع Android. الطريقة المفضلة هي السماح لـ Gradle بتحميل المكتبة من مستودع Maven الخاص بـ Aspose. يمكنك أيضًا تحميل ملف JAR وإضافته إلى مشروعك يدويًا.

المكتبة غير منشورة في Maven Central أو مستودع Maven الخاص بجوجل. وهي متوفرة من مستودع Aspose الخاص، كحزمة `aspose-slides` مع المصنف `android.via.java`.

## **التثبيت من مستودع Maven الخاص بـ Aspose**

### **الخطوة 1: إضافة المستودع**

تعلن مشاريع Android Studio الجديدة عن مستودعاتها في كتلة `dependencyResolutionManagement` داخل *settings.gradle.kts*، ويقوم Gradle برفض المستودعات التي يضيفها ملف بناء الوحدة. أضف سطر `maven` الموضح أدناه إلى كتلة `repositories` داخل تلك الكتلة الموجودة، بدلاً من لصق كتلة `dependencyResolutionManagement` ثانية:

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

### **الخطوة 2: إضافة التبعية**

أضف المكتبة إلى كتلة `dependencies` في ملف بناء وحدة التطبيق، *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

الجزء الأخير من الإحداثيات، `android.via.java`، هو المصنف الذي يختار بناء Android من المكتبة. بدون هذا المصنف، لا يستطيع Gradle العثور على الحزمة.

ثم قم بمزامنة المشروع مع ملفات Gradle، حتى يقوم Gradle بتحميل المكتبة.

### **اختر إصدارًا**

لا يتم بناء Aspose.Slides for Android via Java لكل إصدار في المستودع. يتم نشر بناءاته لبعض إصدارات Aspose.Slides for Java فقط، والإصدار الذي لا يحتوي على بناء Android يفشل في الحل. اختر إصدارًا مدرجًا في صفحة [Aspose.Slides for Android via Java download page](https://releases.aspose.com/slides/ar/androidjava/).

### **سكربتات بناء Groovy**

إذا كان مشروعك يستخدم سكربتات بناء Groovy، أضف سطر `maven` إلى كتلة `repositories` داخل كتلة `dependencyResolutionManagement` الموجودة في *settings.gradle*:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

وأضف التبعية إلى *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **إضافة ملف JAR يدويًا**

إذا لم تتمكن من استخدام مستودع Maven، أضف ملف JAR إلى مشروعك:

1. حمّل ملف JAR من مجلد الإصدار في [Aspose's Maven repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). بالنسبة للإصدار 26.9، الملف هو *aspose-slides-26.9-android.via.java.jar* في مجلد *26.9*.
2. انسخ الملف إلى مجلد *app/libs* في مشروعك. أنشئ المجلد إذا لم يكن موجودًا.
3. أضف الملف إلى كتلة `dependencies` في *app/build.gradle.kts*، ثم قم بمزامنة المشروع:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **إنشاء العرض التقديمي الأول**

بعد مزامنة المشروع، استمر مع [Create Presentations](/slides/ar/androidjava/create-presentation/). يضيف المثال الأول مربع نص إلى شريحة ويحفظ العرض التقديمي في التخزين الخاص لتطبيقك، دون الحاجة إلى صلاحية التخزين. بدون ترخيص، يضيف Aspose.Slides علامة مائية تقييم إلى كل شريحة يتم حفظها؛ راجع [Licensing](/slides/ar/androidjava/licensing/).

## **الإصدار**

منذ عام 2018، يتطابق إصدار Aspose.Slides for Android via Java مع Aspose.Slides for Java. لا يتم نشر إصدارات Android لكل نسخة Java؛ راجع [Choose a Version](#choose-a-version).

## **الأسئلة المتكررة**

### كيف يمكنني التحقق من أن Aspose.Slides تم دمجه بشكل صحيح؟

قم ببناء مشروعك، أنشئ كائنًا فارغًا من نوع [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) واحفظه باسم جديد. إذا تم إنشاء الملف دون رمي استثناءات، فقد تم دمج المكتبة بنجاح.

### كيف يمكنني الحد من استهلاك الذاكرة عند معالجة عروض تقديمية كبيرة؟

استدعِ طريقة [dispose](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#dispose--) لكل كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) داخل كتلة `finally` لتحرير موارده فورًا، ومعالجة عرض تقديمي كبير واحد في كل مرة. يساعد ذلك في منع أخطاء نفاد الذاكرة ويجعل استهلاك الذاكرة الكلي قابلًا للتنبؤ أثناء عمليات الدفعات.

### هل يمكنني استبعاد تنسيقات تصدير غير مرغوب فيها لتقليل حجم ملف JAR النهائي؟

الإصدارات الحالية من Aspose.Slides يتم توزيعها كمكتبة أحادية ضخمة، لذا لا يمكنك تعطيل مُصدِّرات معينة مثل PDF أو SVG أثناء عملية البناء.
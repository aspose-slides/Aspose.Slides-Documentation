---
title: التثبيت
type: docs
weight: 70
url: /ar/nodejs-java/installation/
keySlides: "تحميل Aspose.Slides، تثبيت Aspose.Slides، تثبيت Aspose.Slides، ويندوز، macOS، لينكس، Javascript، Node.js"
description: "قم بتثبيت Aspose.Slides لـ Node.js عبر Java في ويندوز أو لينكس أو macOS"
---

Aspose.Slides لــ Node.js عبر Java هو واجهة برمجة تطبيقات مستقلة عن المنصة ويمكن استخدامها على أي منصة (ويندوز، لينكس وماكOS) حيث تم تثبيت `Node.js` وجسر [`java`](https://www.npmjs.com/package/java).

## **التثبيت من NPM**

يمكنك بسهولة تثبيت Aspose.Slides لــ Node.js عبر Java من [NPM](https://www.npmjs.com/).

قم بإنشاء مجلد جديد وبدء مشروع جديد باستخدام الأمر التالي:
```
$ npm init
```
املأ حقول العنوان والإصدار (اترك الحقول المتبقية بقيمها الافتراضية)

قم بتثبيت Aspose.Slides لــ Node.js عبر Java باستخدام الأمر التالي:
```
$ npm install aspose.slides.via.java
```

إذا واجهت أي مشكلة أثناء عملية التثبيت، يرجى الرجوع إلى هذه [المقالة](/nodejs-java/troubleshooting-installation/).

## **التثبيت من أرشيف ZIP**

لتثبيت واستخدام Aspose.Slides لــ Node.js عبر Java من أرشيف ZIP، اتبع هذه التعليمات بدلاً من ذلك:

### **ويندوز**

1. تثبيت JDK8 وتكوين متغير البيئة `JAVA_HOME`.
1. تثبيت Node.js (https://nodejs.org/en/download/) وإضافة node.exe إلى `PATH`.
1. تثبيت node-gyp.
1. تثبيت أدوات بناء ويندوز.
1. تثبيت جسر [`java`](https://www.npmjs.com/package/java) وتشغيل هذه الأوامر في موجه الأوامر كمسؤول:
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install -g node-gyp

$ npm install --global --production windows-build-tools

$ npm install java
```
6. [تحميل Aspose.Slides لــ Node.js عبر Java](https://releases.aspose.com/slides/nodejs-java/) وفك ضغطه إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. قم بإنشاء ملف باسم `hello.js` في مجلد `aspose.slides.nodejs` باستخدام الكود النموذجي التالي:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("عنوان الشريحة");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("تم");
```

8. الآن قم بتشغيل `node hello.js` في موجه الأوامر لتشغيله.

### **لينكس**

1. تثبيت Node.js (https://nodejs.org/en/download/).
1. تثبيت JDK8 للينكس وتكوين متغير البيئة `JAVA_HOME`.
1. تثبيت Python 2.x
1. تثبيت جسر [`java`](https://www.npmjs.com/package/java). يمكنك تشغيل هذه الأوامر في الطرفية:
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install java
```
5. [تحميل Aspose.Slides لــ Node.js عبر Java](https://releases.aspose.com/slides/nodejs-java/) وفك ضغطه إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. قم بإنشاء ملف اختبار باسم `hello.js` باستخدام هذا الكود النموذجي في مجلد `aspose.slides.nodejs`:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("عنوان الشريحة");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("تم");
```
7. الآن قم بتشغيل `node hello.js` في موجه الأوامر لتشغيله.

### **ماك**

1. تثبيت Node.js (https://nodejs.org/en/download/).
1. تثبيت JDK8 للماك وتكوين متغير البيئة `JAVA_HOME`.
1. تعديل قسم JVMCapabilities في `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` بامتياز المستخدم الجذر. يعتمد `jdk1.8.x_xxx.jdk` على إصدار JDK الخاص بك. اجعلها تبدو مثل هذا:
```xml
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
4. تثبيت Python 2.x (إذا لم يكن مثبتًا).
5. تثبيت أدوات سطر أوامر Xcode.
6. تثبيت جسر [`java`](https://www.npmjs.com/package/java). يمكنك تشغيل الأوامر أدناه في الطرفية:
```
$ mkdir aspose.slides.nodejs
 
$ cd aspose.slides.nodejs
 
$ npm install java
```
7. تحميل Aspose.Slides لــ Node.js عبر Java وفك ضغطه إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. قم بإنشاء ملف اختبار باسم `hello.js` باستخدام هذا الكود النموذجي في مجلد `aspose.slides.nodejs`:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("عنوان الشريحة");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("تم");
```
9. الآن قم بتشغيل `node hello.js` في موجه الأوامر لتشغيله.


{{% alert color="primary" %}}

يرجى استخدام [المقالة](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/) إذا واجهت أخطاء في الترجمة أثناء تثبيت Aspose.Slides لــ Node.js عبر Java.

{{% /alert %}}
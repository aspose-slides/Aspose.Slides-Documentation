---
title: التثبيت
type: docs
weight: 70
url: /ar/nodejs-java/installation/
keywords:
- تثبيت Aspose.Slides
- تنزيل Aspose.Slides
- استخدام Aspose.Slides
- تثبيت Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيف تُثبّت Aspose.Slides بسرعة. دليل خطوة بخطوة، متطلبات النظام، وعينات من الشيفرة — ابدأ العمل مع عروض PowerPoint التقديمية اليوم!"
---

Aspose.Slides لـ Node.js عبر Java هو واجهة برمجة تطبيقات غير مرتبطة بمنصة محددة ويمكن استخدامها على أي منصة (Windows، Linux وMacOS) حيث يتم تثبيت `Node.js` وجسر [`java`](https://www.npmjs.com/package/java).

## **التثبيت من NPM**

يمكنك بسهولة تثبيت Aspose.Slides لـ Node.js عبر Java من [NPM](https://www.npmjs.com/).

1. أنشئ مجلدًا جديدًا وابدأ مشروعًا جديدًا باستخدام الأمر التالي:
```
$ npm init
```

	
2. أدخل قيمتي العنوان والإصدار (اترك باقي الحقول بقيمها الافتراضية).

3. ثبّت Aspose.Slides لـ Node.js عبر Java باستخدام الأمر التالي:
```
	$ npm install aspose.slides.via.java
```


إذا واجهت أي مشكلة أثناء عملية التثبيت، يرجى الرجوع إلى هذا [المقال](/slides/ar/nodejs-java/troubleshooting-installation/).

**مثال على الاستخدام**:

أنشئ ملفًا باسم `hello.js` في مجلد المشروع وأضف الكود التجريبي التالي:
```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```


## **التثبيت من أرشيف ZIP**

لتثبيت واستخدام Aspose.Slides لـ Node.js عبر Java من أرشيف ZIP، اتبع التعليمات التالية بدلًا من ذلك:

### **Windows**

1. ثبّت JDK8 وقم بتكوين متغيّر البيئة `JAVA_HOME`.
1. ثبّت Node.js (https://nodejs.org/en/download/) وأضف node.exe إلى `PATH`.
1. ثبّت node-gyp.
1. ثبّت Windows Build Tools.
1. ثبّت جسر [`java`](https://www.npmjs.com/package/java) وقم بتنفيذ الأوامر التالية في موجه الأوامر كمسؤول:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```

6. [حمّل Aspose.Slides لـ Node.js عبر Java](https://releases.aspose.com/slides/nodejs-java/) واستخرجها إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. أنشئ ملفًا باسم `hello.js` في مجلد `aspose.slides.nodejs` باستخدام الكود التجريبي التالي:
```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```


8. الآن شغّل `node hello.js` في موجه الأوامر لتشغيله.

### **Linux**

1. ثبّت Node.js (https://nodejs.org/en/download/).
1. ثبّت JDK8 لـ Linux وقم بتكوين متغيّر البيئة `JAVA_HOME`.
1. ثبّت python 2.x
1. ثبّت جسر [`java`](https://www.npmjs.com/package/java). يمكنك تشغيل الأوامر التالية في الطرفية:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```

5. [حمّل Aspose.Slides لـ Node.js عبر Java](https://releases.aspose.com/slides/nodejs-java/) واستخرجها إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. أنشئ ملف اختبار باسم `hello.js` باستخدام هذا الكود التجريبي في مجلد `aspose.slides.nodejs`:
```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

7. الآن شغّل `node hello.js` في موجه الأوامر لتشغيله.

### **Mac**

1. ثبّت Node.js (https://nodejs.org/en/download/).
1. ثبّت JDK8 لـ Mac وقم بتكوين متغيّر البيئة `JAVA_HOME`.
1. عدّل قسم JVMCapabilities في `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` بامتيازات الجذر. يعتمد `jdk1.8.x_xxx.jdk` على إصدار JDK الخاص بك. اجعل المحتوى كما يلي:
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

4. ثبّت python 2.x (إذا لم يكن مثبتًا).
5. ثبّت أدوات سطر أوامر Xcode.
6. ثبّت جسر [`java`](https://www.npmjs.com/package/java). يمكنك تشغيل الأوامر التالية في الطرفية:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```

7. حمّل Aspose.Slides لـ Node.js عبر Java واستخرجها إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. أنشئ ملف اختبار باسم `hello.js` باستخدام هذا الكود التجريبي في مجلد `aspose.slides.nodejs`:
```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

9. الآن شغّل `node hello.js` في موجه الأوامر لتشغيله.

{{% alert color="primary" %}}
يرجى استخدام هذا [المقال](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/) إذا واجهت أخطاء تجميع أثناء تثبيت Aspose.Slides لـ Node.js عبر Java.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل هناك نسخة مجانية أو حد تجريبي؟**

نعم، بشكلٍ افتراضي يعمل Aspose.Slides في وضع التقييم، مما يضيف علامات مائية وقد يكون له قيود أخرى. لإزالة القيود، تحتاج إلى تطبيق [ترخيص](/slides/ar/nodejs-java/licensing/) صالح.
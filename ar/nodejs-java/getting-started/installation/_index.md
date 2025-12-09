---
title: التثبيت
type: docs
weight: 70
url: /ar/nodejs-java/installation/
keywords:
- تحميل Aspose.Slides
- تثبيت Aspose.Slides
- تثبيت Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "تثبيت Aspose.Slides for Node.js via Java في Windows أو Linux أو macOS"
---

Aspose.Slides for Node.js via Java هو واجهة برمجة تطبيقات مستقلة عن النظام الأساسي ويمكن استخدامها على أي منصة (Windows، Linux وMacOS) حيث تم تثبيت `Node.js` وجسر [`java`](https://www.npmjs.com/package/java).

## **التثبيت من NPM**

يمكنك بسهولة تثبيت Aspose.Slides for Node.js via Java من [NPM](https://www.npmjs.com/).

1. إنشاء مجلد جديد وبدء مشروع جديد باستخدام الأمر التالي:
```
	$ npm init
```

	
2. املأ حقلي العنوان والإصدار (اترك باقي الحقول بالقيم الافتراضية).

3. ثبت Aspose.Slides for Node.js via Java باستخدام الأمر التالي:
```
	$ npm install aspose.slides.via.java
```


إذا واجهت أي مشكلة أثناء عملية التثبيت، يرجى الرجوع إلى هذه [مقالة](/nodejs-java/troubleshooting-installation/).

**مثال على الاستخدام**:

أنشئ ملفًا باسم `hello.js` في مجلد المشروع وأضف الشيفرة النموذجية التالية:
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

لتثبيت واستخدام Aspose.Slides for Node.js via Java من أرشيف ZIP، اتبع هذه التعليمات بدلاً من ذلك:

### **ويندوز**

1. ثبت JDK8 وقم بتهيئة متغير البيئة `JAVA_HOME`.
1. ثبت Node.js (https://nodejs.org/en/download/) وأضف node.exe إلى `PATH`.
1. ثبت node-gyp.
1. ثبت أدوات بناء Windows.
1. ثبت جسر [`java`](https://www.npmjs.com/package/java) وشغّل هذه الأوامر في موجه الأوامر كمسؤول:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```

6. [قم بتحميل Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) واستخرجها إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. أنشئ ملفًا باسم `hello.js` في مجلد `aspose.slides.nodejs` باستخدام الشيفرة النموذجية التالية:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```


8. الآن شغّل `node hello.js` في موجه الأوامر لتنفذه.

### **لينكس**

1. ثبت Node.js (https://nodejs.org/en/download/).
1. ثبت JDK8 للينكس وقم بتهيئة متغير البيئة `JAVA_HOME`.
1. ثبت python 2.x
1. ثبت جسر [`java`](https://www.npmjs.com/package/java). يمكنك تشغيل هذه الأوامر في الطرفية:
```bash
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install java
```

5. [قم بتحميل Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) واستخرجها إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. أنشئ ملف اختبار باسم `hello.js` باستخدام هذه الشيفرة النموذجية في مجلد `aspose.slides.nodejs`:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

7. الآن شغّل `node hello.js` في موجه الأوامر لتنفذه.

### **ماك**

1. ثبت Node.js (https://nodejs.org/en/download/).
1. ثبت JDK8 للماك وقم بتهيئة متغير البيئة `JAVA_HOME`.
1. عدّل قسم JVMCapabilities في `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` بامتيازات الجذر. يعتمد `jdk1.8.x_xxx.jdk` على إصدار JDK الخاص بك. اجعلها تبدو هكذا:
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

4. ثبت python 2.x (إذا لم يكن مثبتًا).
5. ثبت أدوات سطر أوامر Xcode.
6. ثبت جسر [`java`](https://www.npmjs.com/package/java). يمكنك تشغيل الأوامر التالية في الطرفية:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```

7. قم بتحميل Aspose.Slides for Node.js via Java واستخرجها إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. أنشئ ملف اختبار باسم `hello.js` باستخدام هذه الشيفرة النموذجية في مجلد `aspose.slides.nodejs`:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

9. الآن شغّل `node hello.js` في موجه الأوامر لتنفذه.

{{% alert color="primary" %}}
يرجى استخدام [المقالة](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/) التالية إذا واجهت أخطاء تجميع أثناء تثبيت Aspose.Slides for Node.js via Java.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل هناك نسخة مجانية أو قيود على النسخة التجريبية؟**

نعم، بشكل افتراضي، يعمل Aspose.Slides في وضع التقييم، والذي يضيف علامات مائية وقد يحتوي على قيود أخرى. لإزالة القيود، تحتاج إلى تطبيق ترخيص صالح [رخصة](/slides/ar/nodejs-java/licensing/).
---
title: التثبيت
type: docs
weight: 70
url: /ar/nodejs-java/installation/
keywords:
- تنزيل Aspose.Slides
- تثبيت Aspose.Slides
- تثبيت Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "تثبيت Aspose.Slides لـ Node.js عبر Java في Windows أو Linux أو macOS"
---

Aspose.Slides for Node.js via Java هو واجهة برمجة تطبيقات مستقلة عن النظام الأساسي ويمكن استخدامها على أي منصة (Windows، Linux و macOS) حيث يتم تثبيت `Node.js` وجسر [`java`](https://www.npmjs.com/package/java).

## **التثبيت من NPM**

يمكنك بسهولة تثبيت Aspose.Slides for Node.js via Java من [NPM](https://www.npmjs.com/).

1. أنشئ مجلدًا جديدًا وابدأ مشروعًا جديدًا باستخدام الأمر التالي:
	```
	$ npm init
	```
	
2. املأ حقول العنوان والإصدار (اترك الحقول المتبقية بالقيم الافتراضية).

3. ثبّت Aspose.Slides for Node.js via Java باستخدام الأمر التالي:
	```
	$ npm install aspose.slides.via.java
	```

إذا واجهت أي مشكلة أثناء عملية التثبيت، يرجى الرجوع إلى هذا [المقال](/nodejs-java/troubleshooting-installation/).

**مثال على الاستخدام**:

أنشئ ملفًا باسم `hello.js` في مجلد مشروعك وأضف كود العينة التالي:

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

لتثبيت واستخدام Aspose.Slides for Node.js via Java من أرشيف ZIP، اتبع التعليمات التالية بدلاً من ذلك:

### **ويندوز**

1. ثبّت JDK8 وقم بتكوين متغير البيئة `JAVA_HOME`.
1. ثبّت Node.js (https://nodejs.org/en/download/) وأضف node.exe إلى `PATH`.
1. ثبّت node-gyp.
1. ثبّت Windows Build Tools.
1. ثبّت جسر [`java`](https://www.npmjs.com/package/java) وشغّل هذه الأوامر في موجه الأوامر كمسؤول:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [حمّل Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) واستخراجها إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. أنشئ ملفًا باسم `hello.js` في مجلد `aspose.slides.nodejs` باستخدام كود العينة التالي:

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

### **لينكس**

1. ثبّت Node.js (https://nodejs.org/en/download/).
1. ثبّت JDK8 لـ Linux وقم بتكوين متغير البيئة `JAVA_HOME`.
1. ثبّت python 2.x
1. ثبّت جسر [`java`](https://www.npmjs.com/package/java). يمكنك تشغيل هذه الأوامر في الطرفية:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [حمّل Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) واستخراجها إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. أنشئ ملف اختبار باسم `hello.js` باستخدام كود العينة هذا في مجلد `aspose.slides.nodejs`:

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

### **ماك**

1. ثبّت Node.js (https://nodejs.org/en/download/).
1. ثبّت JDK8 للماك وقم بتكوين متغير البيئة `JAVA_HOME`.
1. عدّل قسم JVMCapabilities في `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` بامتيازات الجذر. يعتمد `jdk1.8.x_xxx.jdk` على إصدار JDK الخاص بك. اجعل المحتوى كالتالي:
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
5. ثبّت Xcode Command Line Tools.
6. ثبّت جسر [`java`](https://www.npmjs.com/package/java). يمكنك تشغيل الأوامر التالية في الطرفية:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. حمّل Aspose.Slides for Node.js via Java واستخراجها إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. أنشئ ملف اختبار باسم `hello.js` باستخدام كود العينة هذا في مجلد `aspose.slides.nodejs`:

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
يرجى استخدام هذا [المقال](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/) إذا واجهت أخطاء تجميع أثناء تثبيت Aspose.Slides for Node.js via Java.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل هناك نسخة مجانية أو حدود على التجربة؟**

نعم، بشكل افتراضي، يعمل Aspose.Slides في وضع التقييم، الذي يضيف علامات مائية وقد يكون له قيود أخرى. لإزالة القيود، تحتاج إلى تطبيق [رخصة](/slides/ar/nodejs-java/licensing/) صالحة.
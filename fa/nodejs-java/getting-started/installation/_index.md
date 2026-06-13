---
title: نصب
type: docs
weight: 70
url: /fa/nodejs-java/installation/
keywords:
- نصب Aspose.Slides
- دانلود Aspose.Slides
- استفاده از Aspose.Slides
- نصب Aspose.Slides
- ویندوز
- لینوکس
- macOS
- پاورپوینت
- OpenDocument
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه Aspose.Slides را به سرعت نصب کنید. راهنمای گام به گام، الزامات سیستم و نمونه کد — همین امروز با ارائه‌های پاورپوینت کار کنید!"
---
## **معرفی**

Aspose.Slides for Node.js via Java یک API مستقل از پلتفرم است و می‌تواند بر روی هر پلتفرمی (Windows, Linux و MacOS) که `Node.js` و پل [`java`](https://www.npmjs.com/package/java) نصب شده باشد، استفاده شود.

## **نصب از NPM**

به راحتی می‌توانید Aspose.Slides for Node.js via Java را از [NPM](https://www.npmjs.com/) نصب کنید.

1. یک پوشه جدید بسازید و یک پروژه جدید را با استفاده از فرمان زیر آغاز کنید:
	```
	$ npm init
```
	
2. فیلدهای عنوان و نسخه را پر کنید (فیلدهای باقی‌مانده را با مقادیر پیش فرض بگذارید).

3. Aspose.Slides for Node.js via Java را با استفاده از فرمان زیر نصب کنید:
	```
	$ npm install aspose.slides.via.java
```

اگر در طول فرآیند نصب با مشکلی مواجه شدید، لطفاً به این [مقاله](/slides/fa/nodejs-java/troubleshooting-installation/) مراجعه کنید.

**مثال استفاده**:

یک فایل به نام `hello.js` در پوشه پروژه خود ایجاد کنید و کد نمونه زیر را اضافه کنید:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **نصب از آرشیو ZIP**

برای نصب و استفاده از Aspose.Slides for Node.js via Java از یک آرشیو ZIP، به جای آن این دستورالعمل‌ها را دنبال کنید:

### **Windows**

1. JDK8 را نصب کنید و متغیر محیطی `JAVA_HOME` را پیکربندی کنید.  
1. Node.js (https://nodejs.org/en/download/) را نصب کنید و `node.exe` را به `PATH` اضافه کنید.  
1. node-gyp را نصب کنید.  
1. Windows Build Tools را نصب کنید.  
1. پل [`java`](https://www.npmjs.com/package/java) را نصب کنید و این دستورات را در Command Prompt به عنوان مدیر اجرا کنید:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
```
6. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/fa/nodejs-java/) را دانلود کنید و آن را در `aspose.slides.nodejs/node_modules/aspose.slides.via.java` استخراج کنید.  
7. یک فایل به نام `hello.js` در پوشه `aspose.slides.nodejs` ایجاد کنید و از کد نمونه زیر استفاده کنید:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

8. حالا `node hello.js` را در خط فرمان اجرا کنید.

### **Linux**

1. Node.js (https://nodejs.org/en/download/) را نصب کنید.  
1. JDK8 برای لینوکس نصب کنید و متغیر محیطی `JAVA_HOME` را پیکربندی کنید.  
1. python 2.x را نصب کنید.  
1. پل [`java`](https://www.npmjs.com/package/java) را نصب کنید. می‌توانید این دستورات را در ترمینال اجرا کنید:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
```
5. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/fa/nodejs-java/) را دانلود کنید و آن را در `aspose.slides.nodejs/node_modules/aspose.slides.via.java` استخراج کنید.  
6. یک فایل آزمایشی به نام `hello.js` در پوشه `aspose.slides.nodejs` ایجاد کنید و از کد نمونه زیر استفاده کنید:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. حالا `node hello.js` را در خط فرمان اجرا کنید.

### **Mac**

1. Node.js (https://nodejs.org/en/download/) را نصب کنید.  
1. JDK8 برای مک نصب کنید و متغیر محیطی `JAVA_HOME` را پیکربندی کنید.  
1. بخش JVMCapabilities در `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` را با امتیاز ریشه (root) ویرایش کنید. `jdk1.8.x_xxx.jdk` بسته به نسخه JDK شما متفاوت است. آن را به شکل زیر تنظیم کنید:
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
4. python 2.x را نصب کنید (اگر نصب نشده باشد).  
5. ابزارهای خط فرمان Xcode را نصب کنید.  
6. پل [`java`](https://www.npmjs.com/package/java) را نصب کنید. می‌توانید دستورات زیر را در ترمینال اجرا کنید:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Aspose.Slides for Node.js via Java را دانلود کنید و در `aspose.slides.nodejs/node_modules/aspose.slides.via.java` استخراج کنید.  
8. یک فایل آزمایشی به نام `hello.js` در پوشه `aspose.slides.nodejs` ایجاد کنید و از کد نمونه زیر استفاده کنید:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. حالا `node hello.js` را در خط فرمان اجرا کنید.

{{% alert color="primary" %}}
اگر در هنگام نصب Aspose.Slides برای Node.js via Java با خطاهای کامپایل مواجه شدید، لطفاً از [مقاله](https://docs.aspose.com/slides/fa/nodejs-java/troubleshooting-installation/) زیر استفاده کنید.
{{% /alert %}}

## **سوالات متداول**

**آیا نسخه رایگان یا محدودیت آزمایشی وجود دارد؟**

بله، به طور پیش‌فرض Aspose.Slides در حالت ارزیابی اجرا می‌شود که واترمارک می‌گذارد و ممکن است محدودیت‌های دیگری داشته باشد. برای حذف محدودیت‌ها باید یک [license](/slides/fa/nodejs-java/licensing/) معتبر اعمال کنید.
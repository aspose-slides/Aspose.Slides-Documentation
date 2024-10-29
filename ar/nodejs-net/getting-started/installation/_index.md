---
title: التثبيت
type: docs
weight: 70
url: /ar/nodejs-net/installation/
keySlides: "تحميل Aspose.Slides، تثبيت Aspose.Slides، تثبيت Aspose.Slides، ويندوز، macOS، لينكس، Javascript، Node.js"
description: "تثبيت Aspose.Slides لـ Node.js عبر .NET على ويندوز أو لينكس أو macOS"
---

Aspose.Slides لـ Node.js عبر .NET هو واجهة برمجة تطبيقات مستقلة عن النظام الأساسي ويمكن استخدامها على أي نظام أساسي (ويندوز، لينكس وMacOS) حيث تم تثبيت `Node.js` وجسر `edge-js`.

## **التثبيت من NPM**

يمكنك بسهولة تثبيت Aspose.Slides لـ Node.js عبر .NET من [NPM](https://www.npmjs.com/) من خلال هذا الأمر:
```
$ npm install aspose.slides.via.net
```
إذا واجهت أي مشكلة أثناء عملية التثبيت، يرجى الرجوع إلى https://www.npmjs.com/package/edge-js.

## **التثبيت من ملف ZIP**

لتثبيت واستخدام Aspose.Slides لـ Node.js عبر .NET من ملف ZIP، اتبع هذه التعليمات بدلاً من ذلك:

### **ويندوز**

1. قم بتثبيت .NET6 أو أعلى.
1. قم بتثبيت Node.js (https://nodejs.org/en/download/) وأضف node.exe إلى `PATH`.
1. قم بتثبيت edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [تحميل Aspose.Slides لـ Node.js عبر .NET](https://releases.aspose.com/slides/nodejs-net/) واستخراجه إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. أنشئ ملفًا باسم `hello.js` في مجلد `aspose.slides.nodejs.net` باستخدام الكود النموذجي التالي:

```javascript
// استيراد وحدة Aspose.Slides لمعالجة ملفات PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// إضافة الفئات الضرورية من asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// إنشاء وتخزين عرض تقديمي فارغ لتوضيح الوظيفة الأساسية
function createEmptyPresentation() {
	
    // تهيئة عرض تقديمي جديد فارغ
    var emptyPresentation = new Presentation();
    
    // حفظ العرض التقديمي الفارغ بتنسيق PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // تحرير الموارد المرتبطة بالعرض التقديمي
    emptyPresentation.dispose();
}

createEmptyPresentation(); // تنفيذ الدالة لإنشاء عرض تقديمي فارغ
```

8. الآن قم بتشغيل `node hello.js` في موجه الأوامر لتشغيله.

### **لينيكس**

1. قم بتثبيت .NET6 أو أعلى.
1. قم بتثبيت Node.js (https://nodejs.org/en/download/) وأضف node.exe إلى `PATH`.
1. قم بتثبيت edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [تحميل Aspose.Slides لـ Node.js عبر Java](https://releases.aspose.com/slides/nodejs-net/) واستخراجه إلى `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. أنشئ ملف اختبار باسم `hello.js` باستخدام هذا الكود النموذجي في مجلد `aspose.slides.nodejs.net`:

```javascript
// استيراد وحدة Aspose.Slides لمعالجة ملفات PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// إضافة الفئات الضرورية من asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// إنشاء وتخزين عرض تقديمي فارغ لتوضيح الوظيفة الأساسية
function createEmptyPresentation() {
	
    // تهيئة عرض تقديمي جديد فارغ
    var emptyPresentation = new Presentation();
    
    // حفظ العرض التقديمي الفارغ بتنسيق PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // تحرير الموارد المرتبطة بالعرض التقديمي
    emptyPresentation.dispose();
}

createEmptyPresentation(); // تنفيذ الدالة لإنشاء عرض تقديمي فارغ
```
7. الآن قم بتشغيل `node hello.js` في موجه الأوامر لتشغيله.

### **ماك**

1. قم بتثبيت .NET6 أو أعلى.
1. قم بتثبيت Node.js (https://nodejs.org/en/download/) وأضف node.exe إلى `PATH`.
1. قم بتثبيت edge-js.

$ mkdir aspose.slides.nodejs.net
 
$ cd aspose.slides.nodejs.net
 
$ npm install edge-js
```

```javascript
// استيراد وحدة Aspose.Slides لمعالجة ملفات PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// إضافة الفئات الضرورية من asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// إنشاء وتخزين عرض تقديمي فارغ لتوضيح الوظيفة الأساسية
function createEmptyPresentation() {
	
    // تهيئة عرض تقديمي جديد فارغ
    var emptyPresentation = new Presentation();
    
    // حفظ العرض التقديمي الفارغ بتنسيق PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // تحرير الموارد المرتبطة بالعرض التقديمي
    emptyPresentation.dispose();
}

createEmptyPresentation(); // تنفيذ الدالة لإنشاء عرض تقديمي فارغ
```
9. الآن قم بتشغيل `node hello.js` في موجه الأوامر لتشغيله.
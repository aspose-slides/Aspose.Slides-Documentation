---
title: نصب
type: docs
weight: 70
url: /fa/nodejs-net/installation/
keywords:
- دانلود Aspose.Slides
- نصب Aspose.Slides
- نصب Aspose.Slides
- ویندوز
- macOS
- لینوکس
- جاوااسکریپت
- Node.js
description: "Aspose.Slides را برای Node.js از طریق .NET در ویندوز، لینوکس یا macOS نصب کنید"
---
Aspose.Slides برای Node.js از طریق .NET یک API مستقل از پلتفرم است و می‌تواند در هر پلتفرمی (Windows، Linux و macOS) که `Node.js` و پل `edge-js` نصب شده‌اند، استفاده شود.

## **نصب از NPM**

می‌توانید به‌راحتی Aspose.Slides برای Node.js از طریق .NET را از [NPM](https://www.npmjs.com/) با استفاده از این فرمان نصب کنید:
```
$ npm install aspose.slides.via.net
```
اگر در طول فرآیند نصب با مشکلی مواجه شدید، لطفاً به https://www.npmjs.com/package/edge-js مراجعه کنید.

## **نصب از آرشیو ZIP**

برای نصب و استفاده از Aspose.Slides برای Node.js از طریق .NET از یک آرشیو ZIP، به‌جای آن دستورالعمل‌های زیر را دنبال کنید:

### **ویندوز**

1. .NET6 یا بالاتر را نصب کنید.  
1. Node.js را نصب کنید (https://nodejs.org/en/download/) و node.exe را به `PATH` اضافه کنید.  
1. `edge-js` را نصب کنید.  
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```  
6. [دانلود Aspose.Slides برای Node.js از طریق .NET](https://releases.aspose.com/slides/fa/nodejs-net/) و استخراج آن به `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.  
7. فایلی به نام `hello.js` در پوشه `aspose.slides.nodejs.net` ایجاد کنید و از کد نمونه زیر استفاده کنید:

```javascript
// وارد کردن ماژول Aspose.Slides برای دستکاری فایل‌های پاورپوینت
const asposeSlides = require('aspose.slides.via.net');

// اضافه کردن کلاس‌های ضروری از asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// ایجاد و ذخیره یک ارائه خالی برای نشان دادن عملکرد پایه
function createEmptyPresentation() {
	
    // راه‌اندازی یک ارائه خالی جدید
    var emptyPresentation = new Presentation();
    
    // ذخیرهٔ ارائه خالی در قالب PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // آزادسازی منابع مرتبط با ارائه
    emptyPresentation.dispose();
}

createEmptyPresentation(); // اجرای تابع برای ایجاد یک ارائه خالی
```

8. حالا `node hello.js` را در خط فرمان اجرا کنید.

### **لینوکس**

1. .NET6 یا بالاتر را نصب کنید.  
1. Node.js را نصب کنید (https://nodejs.org/en/download/) و node.exe را به `PATH` اضافه کنید.  
1. `edge-js` را نصب کنید.  
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```  
5. [دانلود Aspose.Slides برای Node.js از طریق Java](https://releases.aspose.com/slides/fa/nodejs-net/) و استخراج آن به `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.  
6. یک فایل تست به نام `hello.js` در پوشه `aspose.slides.nodejs.net` ایجاد کنید و از این کد نمونه استفاده کنید:

```javascript
// وارد کردن ماژول Aspose.Slides برای دستکاری فایل PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// افزودن کلاس‌های لازم از asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// ایجاد و ذخیره یک ارائه خالی برای نمایش عملکرد پایه
function createEmptyPresentation() {
	
    // راه‌اندازی یک ارائه خالی جدید
    var emptyPresentation = new Presentation();
    
    // ذخیرهٔ ارائه خالی در قالب PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // آزادسازی منابع مرتبط با ارائه
    emptyPresentation.dispose();
}

createEmptyPresentation(); // اجرای تابع برای ایجاد یک ارائه خالی
```
7. حالا `node hello.js` را در خط فرمان اجرا کنید.

### **مک**

1. .NET6 یا بالاتر را نصب کنید.  
1. Node.js را نصب کنید (https://nodejs.org/en/download/) و node.exe را به `PATH` اضافه کنید.  
1. `edge-js` را نصب کنید.

$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```

```javascript
// Import the Aspose.Slides module for PowerPoint file manipulation
const asposeSlides = require('aspose.slides.via.net');

// Add necessary classes from the asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Create and save an empty presentation to demonstrate basic functionality
function createEmptyPresentation() {
	
    // Initialize a new empty presentation
    var emptyPresentation = new Presentation();
    
    // Save the empty presentation in PPTX format
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Release resources associated with the presentation
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Execute the function to create an empty presentation
9. حالا `node hello.js` را در خط فرمان اجرا کنید.
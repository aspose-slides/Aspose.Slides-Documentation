---
title: عیب‌یابی نصب Aspose.Slides برای Node.js از طریق Java
linktitle: عیب‌یابی نصب
type: docs
weight: 75
url: /fa/nodejs-java/troubleshooting-installation/
keywords:
- دانلود Aspose.Slides
- نصب Aspose.Slides
- عیب‌یابی نصب
- نیازمندی‌های نسخه
- ویندوز
- macOS
- لینوکس
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "عیب‌یابی مشکلات نصب Aspose.Slides برای Node.js از طریق Java، رفع خطاها و وابستگی‌های رایج، و اطمینان از عملکرد روان با فرمت‌های PPT، PPTX و ODP."
---
## **مقدمه**

هنگامی‌که با استفاده از `npm` [نصب](/slides/fa/nodejs-java/installation/) `aspose.slides.via.java` انجام می‌شود، مواردی وجود دارد که در زمان کامپایل ماژول‌های `java` و `node-gyp` خطا رخ می‌دهد. ما این خطاها را به‑صورت جامع‌تری بررسی کردیم و نیازمندی‌های خاصی برای نسخه‌های برنامه‌ها و بسته‌های نصب‌شده شناسایی کردیم.

## **نیازمندی‌های نسخه**

1. برای Node.js 12 و نسخه‌های پیشین:
   - Python با نسخه بالاتر از 3.10 نیست.
   - برای ویندوز، توصیه می‌شود Visual Studio Build Tools را که جدیدتر از 2017 نیست نصب کنید.
   - نسخه بسته npm java: 0.12.1.

2. برای Node.js 13:
   - همان نیازمندی‌های Node.js 12.

3. برای Node.js 14:
   - Python 3.10.
   - نسخه بسته npm java: 0.14.0.

4. برای Node.js 15:
   - Python 3.12.
   - نسخه بسته npm java: 0.14.0.

5. برای Node.js 16 و جدیدتر:
   - Python 3.12.
   - نسخه بسته npm java: 0.14.0.

**دستورالعمل‌های زیر را برای نصب برنامه‌های مورد نیاز دنبال کنید.**

### **نصب بر روی یونیکس**

- نصب [Node.js](https://nodejs.org/en/download).
- نصب [Python](https://devguide.python.org/versions/).
- نصب Java (JDK 1.8).
- نصب ابزار زنجیره کامپایلر C/C++ مناسب، مانند [GCC](https://gcc.gnu.org).

### **نصب بر روی macOS**

- نصب [Node.js](https://nodejs.org/en/download).
- نصب [Python](https://devguide.python.org/versions/).
- نصب Java (JDK 1.8) و بخش JVMCapabilities را در مسیر /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist با دسترسی ریشه ویرایش کنید. jdk1.8.x_xxx.jdk به نسخه JDK شما بستگی دارد. آن را به شکل زیر تنظیم کنید:
```
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
- نصب ابزارهای خط فرمان Xcode به‌صورت مستقل با اجرای `xcode-select --install`. -- OR -- به‌جای آن، اگر قبلاً [Xcode کامل نصب شده](https://developer.apple.com/xcode/download/) دارید، می‌توانید ابزارهای خط فرمان را از منوی `Xcode -> Open Developer Tool -> More Developer Tools...` نصب کنید.

### **نصب بر روی ویندوز**

- نصب [Node.js](https://nodejs.org/en/download).
- نصب [Python](https://devguide.python.org/versions/) از [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- نصب Java (JDK 1.8).
- نصب [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (در صورتی که نسخه‌ای قدیمی‌تر از VS2019 استفاده می‌کنید، «Visual C++ build tools» را انتخاب کنید؛ در غیر این صورت از workload «Desktop development with C++» یا [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) با workload «Desktop development with C++» استفاده کنید).

اطمینان حاصل کنید که Node.js، Python و Java به متغیر PATH اضافه شده‌اند.

## **نصب Aspose.Slides برای Node.js از طریق Java در نسخه 14 و بالاتر Node.js**

به سادگی از فرمان زیر استفاده کنید:
```
npm i aspose.slides.via.java
```

## **نصب Aspose.Slides برای Node.js از طریق Java در نسخه 12 یا 13 Node.js**

Aspose.Slides برای Node.js از طریق Java باید به‌صورت دستی نصب شود. از فرمان زیر استفاده کنید:

- برای Node.js 12:
```
npm i java@0.12.1
```
- برای Node.js 13:
```
npm i java@0.13.0
```

سپس [aspose.slides.via.java](https://releases.aspose.com/slides/fa/nodejs-java/) را دانلود کنید و آن را در پوشه `node_modules/aspose.slides.via.java` استخراج نمایید.

## **اعتبارسنجی نصب**

برای اعتبارسنجی نصب، یک فایل `index.js` در ریشهٔ پروژهٔ خود ایجاد کنید که محتوای زیر را داشته باشد:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

این فایل را با اجرای فرمان `node index.js` اجرا کنید.

## **اطلاعات تکمیلی**

امکان پوشش تمام مشکلات ممکن در چارچوب این مقاله وجود ندارد. از آنجا که مشکلات به‌دلیل کامپایل ماژول‌های `java` و `node-gyp` پیش می‌آیند، لینک‌های زیر نیز مفید خواهند بود:
- [نصب java](https://www.npmjs.com/package/java#installation) 
- [نصب node-gyp](https://www.npmjs.com/package/node-gyp#installation)
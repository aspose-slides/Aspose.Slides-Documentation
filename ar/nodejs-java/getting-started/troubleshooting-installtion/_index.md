---
title: استكشاف الأخطاء وإصلاحها عند تثبيت Aspose.Slides لـ Node.js عبر Java
type: docs
weight: 75
url: /nodejs-java/troubleshooting-installation/
keySlides: "تحميل Aspose.Slides، تثبيت Aspose.Slides، استكشاف الأخطاء وإصلاحها في تثبيت Aspose.Slides، ويندوز، macOS، لينكس، جافا سكريبت، Node.js"
description: "استكشاف الأخطاء وإصلاحها عند تثبيت Aspose.Slides لـ Node.js عبر Java في ويندوز أو لينكس أو macOS"
---

عند [تثبيت](/nodejs-java/installation/) `aspose.slides.via.java` باستخدام `npm`، هناك حالات تحدث فيها أخطاء أثناء تجميع وحدات `java` و `node-gyp`. لقد قمنا بالتحقيق في هذه الأخطاء بمزيد من التفصيل وحددنا متطلبات محددة لإصدارات البرامج والحزم المثبتة.

## **متطلبات الإصدار**

1. لـ Node.js 12 وما قبله:
   - بايثون لا يتجاوز 3.10.
   - بالنسبة لويندوز، يُنصح بتثبيت أدوات بناء Visual Studio لا تتجاوز 2017.
   - إصدار حزمة npm java: 0.12.1.

2. لـ Node.js 13:
   - نفس المتطلبات كما هو الحال في Node.js 12.

3. لـ Node.js 14:
   - بايثون 3.10.
   - إصدار حزمة npm java: 0.14.0.

4. لـ Node.js 15:
   - بايثون 3.12.
   - إصدار حزمة npm java: 0.14.0.

5. لـ Node.js 16 وما بعده:
   - بايثون 3.12.
   - إصدار حزمة npm java: 0.14.0.

**اتبع التعليمات أدناه لتثبيت البرامج المطلوبة.**

### **التثبيت على Unix**

- قم بتثبيت [Node.js](https://nodejs.org/en/download).
- قم بتثبيت [Python](https://devguide.python.org/versions/).
- قم بتثبيت Java (JDK 1.8).
- قم بتثبيت مجموعة أدوات مترجم C/C++ المناسبة، مثل [GCC](https://gcc.gnu.org).

### **التثبيت على macOS**

- قم بتثبيت [Node.js](https://nodejs.org/en/download).
- قم بتثبيت [Python](https://devguide.python.org/versions/).
- قم بتثبيت Java (JDK 1.8) وتعديل قسم JVMCapabilities في /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist بصلاحيات الجذر. يعتمد jdk1.8.x_xxx.jdk على إصدار jdk الخاص بك. اجعلها تبدو مثل هذا: 
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
- قم بتثبيت `Xcode Command Line Tools` بشكل مستقل عن طريق تشغيل `xcode-select --install`. -- أو -- بدلاً من ذلك، إذا كان لديك [Xcode الكامل مثبتًا](https://developer.apple.com/xcode/download/)، يمكنك تثبيت أدوات سطر الأوامر من قائمة `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **التثبيت على ويندوز**

- قم بتثبيت [Node.js](https://nodejs.org/en/download).
- قم بتثبيت [Python](https://devguide.python.org/versions/) من [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- قم بتثبيت Java (JDK 1.8).
- قم بتثبيت [بيئة بناء Visual C++](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (باستخدام "أدوات بناء Visual C++" إذا كنت تستخدم إصدارًا أقدم من VS2019، وإلا استخدم "تطوير سطح المكتب باستخدام C++" كحمل عمل أو [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) باستخدام "تطوير سطح المكتب باستخدام C++").

تأكد من إضافة Node.js وPython وJava إلى متغير PATH.

## **تثبيت Aspose.Slides لـ Node.js عبر Java على إصدار Node.js 14 وما بعده**

استخدم ببساطة الأمر:
```
npm i aspose.slides.via.java
```

## **تثبيت Aspose.Slides لـ Node.js عبر Java على إصدار Node.js 12 أو 13**

يجب تثبيت Aspose.Slides لـ Node.js عبر Java يدويًا. استخدم الأمر التالي:

- لـ Node.js 12:
```
npm i java@0.12.1
```
- لـ Node.js 13: 
```
npm i java@0.13.0
```

بعد ذلك، قم بتنزيل [aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/) واستخراجه إلى المجلد `node_modules/aspose.slides.via.java`.

## **التحقق من التثبيت**

للتحقق من التثبيت، أنشئ ملف `index.js` في جذر المشروع الخاص بك بالمحتوى التالي:

```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

نفذ هذا الملف باستخدام الأمر `node index.js`.

## **معلومات إضافية**

لا يمكن تغطية جميع المشكلات المحتملة ضمن نطاق هذه المقالة. نظرًا لأن المشاكل تنشأ بسبب تجميع وحدات `java` و `node-gyp`، ستكون الروابط التالية مفيدة أيضًا:
- [تثبيت java](https://www.npmjs.com/package/java#installation) 
- [تثبيت node-gyp](https://www.npmjs.com/package/node-gyp#installation)
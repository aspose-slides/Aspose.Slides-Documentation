---
title: استكشاف الأخطاء وإصلاحها لتثبيت Aspose.Slides لـ Node.js عبر Java
linktitle: استكشاف الأخطاء وإصلاحها للتثبيت
type: docs
weight: 75
url: /ar/nodejs-java/troubleshooting-installation/
keywords:
- تنزيل Aspose.Slides
- تثبيت Aspose.Slides
- استكشاف الأخطاء وإصلاحها للتثبيت
- متطلبات الإصدار
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "استكشاف الأخطاء وتثبيت Aspose.Slides لـ Node.js عبر Java، إصلاح الأخطاء والاعتماديات الشائعة، وضمان عمل سلس مع ملفات PPT و PPTX و ODP."
---

عند [تثبيت](/slides/ar/nodejs-java/installation/) `aspose.slides.via.java` باستخدام `npm`، هناك حالات تحدث فيها أخطاء أثناء تجميع وحدات `java` و `node-gyp`. لقد قمنا بالتحقق من هذه الأخطاء بمزيد من التفصيل وحددنا المتطلبات الخاصة بإصدارات البرامج والحزم المثبتة.

## **متطلبات الإصدار**

1. لـ Node.js 12 والإصدارات الأقدم:
   - Python لا يتجاوز 3.10.
   - بالنسبة لنظام Windows، يُنصح بتثبيت Visual Studio Build Tools ليس أحدث من 2017.
   - إصدار حزمة npm java: 0.12.1.

2. لـ Node.js 13:
   - نفس المتطلبات كما في Node.js 12.

3. لـ Node.js 14:
   - Python 3.10.
   - إصدار حزمة npm java: 0.14.0.

4. لـ Node.js 15:
   - Python 3.12.
   - إصدار حزمة npm java: 0.14.0.

5. لـ Node.js 16 والإصدارات الأحدث:
   - Python 3.12.
   - إصدار حزمة npm java: 0.14.0.

**اتبع التعليمات أدناه لتثبيت البرامج المطلوبة.**

### **التثبيت على Unix**

- تثبيت [Node.js](https://nodejs.org/en/download).
- تثبيت [Python](https://devguide.python.org/versions/).
- تثبيت Java (JDK 1.8).
- تثبيت أداة تجميع C/C++ مناسبة، مثل [GCC](https://gcc.gnu.org).

### **التثبيت على macOS**

- تثبيت [Node.js](https://nodejs.org/en/download).
- تثبيت [Python](https://devguide.python.org/versions/).
- تثبيت Java (JDK 1.8) وتعديل قسم JVMCapabilities في /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist باستخدام صلاحيات الجذر. jdk1.8.x_xxx.jdk يعتمد على إصدار jdk الخاص بك. اجعل المحتوى يبدو هكذا:
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

- تثبيت أدوات سطر الأوامر `Xcode Command Line Tools` بشكل منفصل بتشغيل `xcode-select --install`. -- OR -- بدلاً من ذلك، إذا كان لديك بالفعل [Xcode كامل مثبت](https://developer.apple.com/xcode/download/)، يمكنك تثبيت أدوات سطر الأوامر من القائمة `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **التثبيت على Windows**

- تثبيت [Node.js](https://nodejs.org/en/download).
- تثبيت [Python](https://devguide.python.org/versions/) من [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- تثبيت Java (JDK 1.8).
- تثبيت [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (استخدام "Visual C++ build tools" إذا كنت تستخدم إصدارًا أقدم من VS2019، وإلا استخدم مجموعة العمل "Desktop development with C++" أو [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) باستخدام مجموعة العمل "Desktop development with C++").
- تأكد من إضافة Node.js و Python و Java إلى متغيّر PATH.

## **تثبيت Aspose.Slides لـ Node.js عبر Java على إصدارات Node.js 14 والأحدث**

استخدم الأمر ببساطة:
```
npm i aspose.slides.via.java
```


## **تثبيت Aspose.Slides لـ Node.js عبر Java على إصدارات Node.js 12 أو 13**

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

للتحقق من التثبيت، أنشئ ملفًا `index.js` في جذر مشروعك بالمحتوى التالي:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```


قم بتنفيذ هذا الملف باستخدام الأمر `node index.js`.

## **معلومات إضافية**

ليس من الممكن تغطية جميع المشكلات المحتملة ضمن نطاق هذه المقالة. نظرًا لأن المشكلات تنشأ بسبب تجميع وحدات `java` و `node-gyp` فإن الروابط التالية ستكون مفيدة أيضًا:
- [تثبيت java](https://www.npmjs.com/package/java#installation)
- [تثبيت node-gyp](https://www.npmjs.com/package/node-gyp#installation)
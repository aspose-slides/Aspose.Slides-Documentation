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
- ويندوز
- لينكس
- ماك أو إس
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تثبيت Aspose.Slides لـ Node.js عبر Java من npm على ويندوز، لينكس، وماك أو إس: JDK، Python، وأدوات بناء C++ المطلوبة، أمر npm، وسكريبت أول للتحقق من التثبيت."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تثبيت Aspose.Slides for Node.js via Java على Windows وLinux وmacOS، وكيفية التحقق من أن التثبيت يعمل.

يتم توزيع Aspose.Slides for Node.js via Java كحزمة `aspose.slides.via.java` على npm. تعمل الحزمة على تشغيل Aspose.Slides داخل آلة افتراضية Java عبر حزمة [`java`](https://github.com/joeferner/node-java)، وهي إضافة أصلية لـ Node.js يقوم npm بتجميعها على جهازك أثناء التثبيت. لهذا السبب تحتاج عملية التثبيت، إلى جانب Node.js:

- **مجموعة تطوير جافا (JDK) الإصدار 8 أو أحدث.** لا يكفي وجود بيئة تشغيل جافا فقط: تحتاج عملية البناء إلى ملفات رؤوس JDK.
- **Python 3**، الذي يستخدمه أداة البناء [node-gyp](https://github.com/nodejs/node-gyp).
- **سلسلة أدوات بناء C++** الخاصة بنظام التشغيل الخاص بك.

## **تثبيت المتطلبات المسبقة**

### **Windows**

1. قم بتثبيت [Node.js](https://nodejs.org/en/download) الإصدار 20 أو أحدث.  
2. قم بتثبيت JDK، مثال ذلك [Eclipse Temurin](https://adoptium.net/)، وضع متغير البيئة `JAVA_HOME` إلى مجلد التثبيت. يستخدم البناء JDK الذي يشير إليه `JAVA_HOME`.  
3. قم بتثبيت [Python 3](https://www.python.org/downloads/).  
4. قم بتثبيت [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) مع مجموعة العمل **Desktop development with C++**. احتفظ بالمكونات الافتراضية لمجموعة العمل، والتي تشمل **MSVC v143 - VS 2022 C++ x64/x86 build tools** و **Windows 11 SDK**. لا يعمل Visual Studio 2026: إصدار node-gyp الذي تُجمع به حزمة `java` لا يتعرف عليه.

### **Linux**

قم بتثبيت Node.js 20 أو أحدث من [nodejs.org](https://nodejs.org/en/download) أو من مصدر حزم توزيعتك. ثم ثبّث JDK، Python 3، وأدوات بناء C++. على Debian وUbuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

في Linux، يجد البناء JDK المثبت تلقائيًا دون مزيد من الإعداد. إذا تم تثبيت عدة إصدارات من JDK، عيّن `JAVA_HOME` إلى الإصدار الذي تريد استخدامه.

### **macOS**

قم بتثبيت Node.js 20 أو أحدث، JDK، وأدوات سطر أوامر Xcode، التي تتضمن Python 3 ومترجم C++. راجع [Troubleshooting Installation](/slides/ar/nodejs-java/troubleshooting-installation/) للحصول على ملاحظات خاصة بنظام macOS.

## **التثبيت من npm**

أنشئ مجلد مشروع وقم بتثبيت الحزمة:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

يقوم npm بتنزيل Aspose.Slides وتجميع جسر `java`، وقد يستغرق ذلك بضع دقائق. إذا فشل التجميع، راجع [Troubleshooting Installation](/slides/ar/nodejs-java/troubleshooting-installation/).

## **التحقق من التثبيت**

أنشئ ملفًا باسم *hello.js* داخل مجلد المشروع بالمحتوى التالي. يُنشئ الملف عرضًا تقديميًا، يضيف مربع نص إلى الشريحة الأولى، ويحفظ النتيجة كملف *hello.pptx*:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides يعمل داخل آلة افتراضية Java تبقي Node.js قيد التشغيل، لذلك يجب إنهاء العملية بشكل صريح.
process.exit(0);
```

شغّل السكريبت:

```bash
node hello.js
```

إذا ظهر ملف *hello.pptx* في مجلد المشروع، فإن التثبيت يعمل. تحتفظ آلة Java الافتراضية التي تشغّل Aspose.Slides بـ Node.js من الخروج تلقائيًا، لذا ينتهي السكريبت بـ `process.exit(0)`. يوضح [Create Presentations](/slides/ar/nodejs-java/create-presentation/) الكود.

## **التثبيت من أرشيف ZIP**

الحزمة متوفرة أيضًا كأرشيف ZIP يحتوي على نفس محتوى حزمة npm. لتثبيتها من الأرشيف:

1. قم بتثبيت المتطلبات المسبقة لنظام تشغيلك كما هو موضح أعلاه.  
2. نزّل الأرشيف من صفحة تحميل [Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/).  
3. أنشئ مجلد مشروع:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. استخرج الأرشيف إلى مجلد فرعي باسم *aspose.slides.via.java* داخل مجلد المشروع، بحيث يكون ملف *package.json* الخاص بالأرشيف في المسار *hello-slides/aspose.slides.via.java/package.json*.  
5. قم بتثبيت الحزمة من هذا المجلد:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    يقوم npm بتثبيت جسر `java` الذي تعتمد عليه الحزمة ويجمعه، كما يفعل مع حزمة npm.

6. تحقق من التثبيت كما هو موضح في [Check the Installation](#check-the-installation).

## **FAQ**

**هل هناك نسخة مجانية أو حدود تجريبية؟**

نعم. بدون ترخيص، يعمل Aspose.Slides في وضع التقييم: يضيف علامة مائية تقييم إلى كل شريحة يتم حفظها ويقتطع النص المقروء من العروض التقديمية. لإزالة هذه القيود، طبّق ترخيصًا صالحًا [license](/slides/ar/nodejs-java/licensing/).

**لماذا لا ينتهي السكريبت تلقائيًا بعد الانتهاء؟**

تبدأ حزمة `java` آلة Java افتراضية داخل عملية Node.js، وتظل تلك الآلة تبقي العملية تعمل. استدعِ `process.exit` عندما ينتهي السكريبت من أداء مهمته.
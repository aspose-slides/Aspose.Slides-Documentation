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
description: "نصب Aspose.Slides برای Node.js از طریق Java با npm بر روی ویندوز، لینوکس و macOS: JDK، Python و ابزارهای ساخت C++ مورد نیاز، فرمان npm و یک اسکریپت اولیه برای بررسی نصب."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که چگونه Aspose.Slides for Node.js via Java را بر روی ویندوز، لینوکس و macOS نصب کنید و نحوهٔ بررسی عملکرد نصب را نشان می‌دهد.

Aspose.Slides for Node.js via Java به صورت بستهٔ `aspose.slides.via.java` در npm توزیع می‌شود. این بسته Aspose.Slides را در یک ماشین مجازی جاوا از طریق بستهٔ [`java`](https://github.com/joeferner/node-java) اجرا می‌کند، که یک افزونهٔ بومی Node.js است که npm در زمان نصب بر روی کامپیوتر شما کامپایل می‌کند. به همین دلیل نصب، علاوه بر Node.js، به موارد زیر نیاز دارد:

- **یک کیت توسعهٔ جاوا (JDK) نسخه ۸ یا بالاتر.** فقط داشتن محیط اجرای جاوا کافی نیست: ساخت نیاز به فایل‌های سرآیند JDK دارد.  
- **Python 3**، که ابزار ساخت [node-gyp](https://github.com/nodejs/node-gyp) از آن استفاده می‌کند.  
- **یک ابزار زنجیره ساخت C++** برای سیستم‌عامل شما.

## **نصب پیش‌نیازها**

### **ویندوز**

1. [Node.js](https://nodejs.org/en/download) نسخهٔ ۲۰ یا بالاتر را نصب کنید.  
2. یک JDK نصب کنید، برای مثال [Eclipse Temurin](https://adoptium.net/)، و متغیر محیطی `JAVA_HOME` را به پوشهٔ نصب آن مقداردهی کنید. ساخت از JDK‌ای که `JAVA_HOME` به آن اشاره دارد استفاده می‌کند.  
3. [Python 3](https://www.python.org/downloads/) را نصب کنید.  
4. [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) را با workload **Desktop development with C++** نصب کنید. مؤلفه‌های پیش‌فرض این workload شامل **MSVC v143 - VS 2022 C++ x64/x86 build tools** و **Windows 11 SDK** می‌شود. Visual Studio 2026 کار نمی‌کند: نسخهٔ node-gyp که بستهٔ `java` با آن کامپایل می‌شود، آن را نمی‌شناسد.

### **لینوکس**

Node.js نسخهٔ ۲۰ یا بالاتر را از [nodejs.org](https://nodejs.org/en/download) یا مخازن توزیع خود نصب کنید. سپس یک JDK، Python 3 و ابزارهای ساخت C++ را نصب کنید. در دبیان و اوبونتو:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

در لینوکس، ساخت به‌صورت خودکار JDK نصب‌شده را پیدا می‌کند. اگر چندین JDK نصب باشد، `JAVA_HOME` را به مسیر موردنظر تنظیم کنید.

### **macOS**

Node.js نسخهٔ ۲۰ یا بالاتر، یک JDK و ابزارهای خط فرمان Xcode را نصب کنید؛ این ابزارها شامل Python 3 و کامپایلر C++ هستند. برای یادداشت‌های مخصوص macOS به صفحهٔ [Troubleshooting Installation](/slides/fa/nodejs-java/troubleshooting-installation/) مراجعه کنید.

## **نصب از npm**

یک پوشهٔ پروژه ایجاد کنید و بسته را نصب کنید:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm Aspose.Slides را دریافت می‌کند و پل `java` را کامپایل می‌سازد؛ این فرآیند ممکن است چند دقیقه طول بکشد. در صورت بروز خطا، به [Troubleshooting Installation](/slides/fa/nodejs-java/troubleshooting-installation/) مراجعه کنید.

## **بررسی نصب**

فایلی به نام *hello.js* در پوشهٔ پروژه ایجاد کنید و کد زیر را در آن قرار دهید. این کد یک ارائه (presentation) می‌سازد، یک جعبهٔ متن به اولین اسلاید اضافه می‌کند و نتیجه را به صورت *hello.pptx* ذخیره می‌کند:

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

// Aspose.Slides در یک ماشین مجازی جاوا اجرا می‌شود که باعث می‌شود Node.js ادامه یابد، بنابراین فرآیند را به‌صورت صریح پایان دهید.
process.exit(0);
```

اسکریپت را اجرا کنید:

```bash
node hello.js
```

اگر *hello.pptx* در پوشهٔ پروژه ظاهر شود، نصب موفق است. ماشین مجازی جاوا که Aspose.Slides را اجرا می‌کند، مانع خروج خودکار Node.js می‌شود؛ به همین دلیل اسکریپت با `process.exit(0)` تمام می‌شود. برای توضیح کد به صفحهٔ [Create Presentations](/slides/fa/nodejs-java/create-presentation/) مراجعه کنید.

## **نصب از آرشیو ZIP**

این بسته همچنین به صورت آرشیو ZIP با محتوای مشابه بستهٔ npm موجود است. برای نصب از این آرشیو:

1. پیش‌نیازهای سیستم‌عامل خود را همانند بخش فوق نصب کنید.  
2. آرشیو را از [صفحهٔ دانلود Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/fa/nodejs-java/) دریافت کنید.  
3. یک پوشهٔ پروژه ایجاد کنید:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. آرشیو را در زیرپوشه‌ای به نام *aspose.slides.via.java* داخل پوشهٔ پروژه استخراج کنید، به‌طوری که فایل *package.json* آرشیو در مسیر *hello-slides/aspose.slides.via.java/package.json* قرار گیرد.  
5. بسته را از همان پوشه نصب کنید:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm پل `java` که بسته به آن وابسته است را نصب و کامپایل می‌کند، همان‌طور که برای بستهٔ npm انجام می‌شود.

6. نصب را همان‌طور که در بخش [Check the Installation](#check-the-installation) توضیح داده شده است، بررسی کنید.

## **پرسش‌های متداول**

**آیا نسخهٔ رایگان یا محدودیت آزمایشی وجود دارد؟**

بله. بدون داشتن لایسنس، Aspose.Slides در حالت ارزیابی اجرا می‌شود: یک واترمارک ارزیابی به هر اسلایدی که ذخیره می‌کند اضافه می‌کند و متن‌های خوانده‌شده از ارائه‌ها را کوتاه می‌نماید. برای حذف این محدودیت‌ها یک [license](/slides/fa/nodejs-java/licensing/) معتبر اعمال کنید.

**چرا اسکریپت من پس از اتمام کار متوقف نمی‌شود؟**

بستهٔ `java` یک ماشین مجازی جاوا را داخل فرآیند Node.js راه‌اندازی می‌کند و این ماشین مجازی باعث می‌شود فرآیند ادامه یابد. هنگامی که کار اسکریپت به‌پایان رسید، `process.exit` را فراخوانی کنید.
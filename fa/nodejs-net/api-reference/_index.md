---
title: مرجع API
type: docs
weight: 50
url: /fa/nodejs-net/api-reference/
description: "Aspose.Slides برای Node.js از طریق .NET توسط مرجع API Aspose.Slides برای .NET مستند شده است. ببینید نام کلاس‌ها و اعضای .NET چگونه به JavaScript نگاشت می‌شوند."
---
## **نمای کلی**

Aspose.Slides برای Node.js از طریق .NET مرجع API مخصوص خود را ندارد. این بسته کلاس‌های Aspose.Slides برای .NET را تحت همان نام‌ها به JavaScript عرضه می‌کند و نام اعضا به camelCase تبدیل می‌شود، بنابراین [مرجع API Aspose.Slides برای .NET](https://reference.aspose.com/slides/fa/net/) کلاس‌ها، اعضا و enumerationها را مستند می‌کند.

## **نگاشت نام‌های .NET به JavaScript**

برای استفاده از عضوی که در مرجع API .NET می‌بینید، قوانین زیر را اعمال کنید:

- **کلاس‌ها و enumerationها نام‌های .NET خود را حفظ می‌کنند** و همین‌طور مقادیر enumeration: `Presentation`، `ShapeType.Rectangle`، `SaveFormat.Pdf`. آن‌ها را از بسته وارد کنید: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **خصوصیات و متدها با حرف کوچک شروع می‌شوند.** `Presentation.Slides` به `presentation.slides` تبدیل می‌شود و `ShapeCollection.AddAutoShape` به `shapes.addAutoShape`. خصوصیات همچنان خصوصیت می‌مانند: بدون پرانتز می‌خوانید و مقداردهی می‌کنید.
- **آیتم‌های مجموعه با `get(index)` خوانده می‌شوند** و تعداد آیتم‌ها با `count` به دست می‌آید: `presentation.slides.get(0)` به جای `presentation.Slides[0]`.
- **برخی overloadها نام‌های جداگانه‌ای دارند.** به عنوان مثال overload `Slide.GetImage(Size)` به `slide.getImageWithImageSize({ width, height })` تبدیل می‌شود. سایر overloadها یک متد مشترک با آرگومان‌های اختیاری دارند: `presentation.save(path, format, options, slides)` چند overload `Presentation.Save` را پوشش می‌دهد و `new Presentation(null, buffer)` یک ارائه را از یک `Buffer` باز می‌کند. هر کلاس در یک فایل زیر پوشه `lib` بسته قرار دارد (مثلاً `node_modules/aspose.slides.via.net/lib/Slide.js`) که می‌توانید نام‌های دقیق را در آن جستجو کنید.
- **پس از اتمام کار ارائه‌ها را با `dispose` آزاد کنید**؛ JavaScript عبارت `using` ندارد.

این بسته همهٔ اعضای .NET را نمی‌پیچد. اگر عضوی از مرجع API .NET در فایل کلاس وجود نداشته باشد، در JavaScript در دسترس نیست.

## **مثال**

اسکریپت زیر از قوانین بالا استفاده می‌کند. هر کامنت فراخوانی .NET را نشان می‌دهد که خط بعدی متناظر با آن است. این اسکریپت یک مستطیل با متن به اولین اسلاید اضافه می‌کند، اسلاید را به تصویر PNG با اندازه 960 × 540 پیکسل رندر می‌کند و ارائه را به صورت PDF ذخیره می‌نماید. آن را از پوشهٔ پروژه‌ای که بسته همان‌طور که در [نصب](/slides/fa/nodejs-net/installation/) توضیح داده شده است، نصب شده، اجرا کنید.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

اسکریپت `slide.png` و `slide.pdf` را در پوشهٔ جاری می‌نویسد. هر دو مستطیل با متن را نشان می‌دهند. بدون داشتن لایسنس، یک watermark ارزیابی نیز نمایش داده می‌شود؛ برای جزئیات به [مجوزدهی](/slides/fa/nodejs-net/licensing/) مراجعه کنید.

برای جزئیات مربوط به اعضای استفاده شده در اینجا، به [Presentation]، [ShapeCollection.AddAutoShape]، [TextFrame.Text] و [Slide.GetImage] در مرجع API Aspose.Slides برای .NET مراجعه کنید.
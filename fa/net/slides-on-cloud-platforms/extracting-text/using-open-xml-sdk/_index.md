---
title: "چگونه متن را از فایل‌های PPT، PPTX و ODP با استفاده از Open XML SDK در .NET استخراج کنیم"
linktitle: "Open XML SDK"
type: docs
weight: 20
url: /fa/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- پلتفرم‌های ابری
- یکپارچه‌سازی ابری
- Open XML SDK
- استخراج متن PPTX
- پردازش اسلاید .NET
- استخراج متن ارائه
- اسلاید اصلی
- یادداشت‌های گوینده
- استخراج متن از اسلایدها
- C#
description: "یاد بگیرید چگونه در .NET با استفاده از Open XML SDK متن را از فایل‌های PPT، PPTX و ODP استخراج کنید؛ با دسترسی مبتنی بر XML، نکات عملکردی و راهکارهای تبدیل برای برنامه‌های ابری."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه متن را از فایل‌های ارائه با استفاده از Open XML SDK در .NET استخراج کنید. این مقاله بر دسترسی مستقیم به XML برای فایل‌های PPTX تمرکز دارد، جایی که متن می‌تواند از عناصر ساختاریافته اسلاید دریافت شود بدون رندر کردن اسلایدها یا نیاز به Microsoft PowerPoint. مقاله همچنین مزایای عملکردی مانند پردازش سریع‌تر و مصرف حافظه کمتر را توصیف می‌کند.

برای فایل‌های PPT و ODP، مقاله توضیح می‌دهد که متن نمی‌تواند به طور مستقیم با Open XML SDK استخراج شود. در عوض، این فرمت‌ها باید ابتدا به PPTX تبدیل شوند، پس از آن متن می‌تواند از فایل حاصل استخراج شود.

## **Open XML SDK**

**Open XML SDK** روشی بسیار ساختاریافته و کارآمد برای استخراج متن از فایل‌های ارائه ارائه می‌دهد—به‌ویژه **PPTX** که بر استاندارد Open XML پیروی می‌کند. با ارائه دسترسی مستقیم به XML پایه، این SDK امکان پردازش سریع‌تر و انعطاف‌پذیرتر محتویات اسلاید را نسبت به روش‌های سنتی فراهم می‌کند.

## **دسترسی مستقیم به XML**

- **تحلیل مستقیم متن**: SDK **Open XML** به شما امکان می‌دهد متن را از بخش‌های XML بدون رندر کردن اسلایدها استخراج کنید.
- **عناصر ساختاریافته**: چون متن در برچسب‌های XML به‌خوبی تعریف‌شده ذخیره می‌شود، بازیابی و پردازش آن ساده‌تر است.

### **مثال: استخراج مستقیم متن از محتوای XML اسلاید**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```

## **مزایای عملکرد**

- **استخراج سریع‌تر**: عبور از هزینه‌های باز کردن PowerPoint یا سایر APIهای سطح بالا.
- **مصرف کمتر حافظه**: فقط بخش‌های XML مرتبط دسترسی پیدا می‌شوند که مصرف منابع را کاهش می‌دهد.
- **بدون نیاز به Microsoft PowerPoint**: شما را از نیازهای نصب اضافی آزاد می‌کند.

### **مثال: استخراج مؤثر متن بدون بارگذاری کل ارائه**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```

## **شناسایی عناصر متن**

### **جزئیات استخراج متن از ارائه‌ها**

هنگام استخراج متن از ارائه‌ها، موارد زیر را در نظر بگیرید:

- **متن ممکن است در بخش‌های مختلف قرار گیرد**: اسلایدهای معمولی، اسلایدهای اصلی، قالب‌ها یا یادداشت‌های گوینده.
- **متن‌های پیش‌فرض**: اسلایدهای اصلی و قالب‌ها می‌توانند شامل متون پیش‌فرض (مثلاً «برای ویرایش سبک عنوان Master کلیک کنید») باشند که محتوای واقعی ارائه نیستند.
- **فیلتر کردن متن خالی یا مخفی**: برخی عناصر ممکن است خالی باشند یا برای نمایش منظوری نداشته باشند.

### **برچسب‌های حاوی متن**

در یک فایل **PPTX**، متن معمولاً در موارد زیر ذخیره می‌شود:

- عناصر `<a:t>` داخل `<a:p>` (پاراگراف‌ها)
- عناصر `<a:r>` (بخش‌های متنی داخل پاراگراف‌ها)

### **مثال: استخراج تمام عناصر متن از یک اسلاید**

```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## **ODP و PPT**

### **عدم امکان استخراج مستقیم متن**

- بر خلاف **PPTX**، **PPT** (فرمت باینری) و **ODP** (ارائه OpenDocument) **توسط Open XML SDK پشتیبانی نمی‌شوند**.
- **PPT** محتوا را در یک فرمت باینری بسته ذخیره می‌کند که استخراج متن را پیچیده می‌سازد.
- **ODP** بر **OpenDocument XML** متکی است که از نظر ساختاری با PPTX متفاوت است.

### **راه‌حل: تبدیل به PPTX**

برای استخراج متن از **PPT** یا **ODP**، روش پیشنهادی به شرح زیر است:

1. **تبدیل PPT → PPTX** با استفاده از PowerPoint یا ابزارهای شخص ثالث.
2. **تبدیل ODP → PPTX** از طریق LibreOffice یا PowerPoint.
3. **استخراج متن** از PPTX جدید با استفاده از Open XML SDK.

### **مثال: تبدیل ODP به PPTX با خط فرمان LibreOffice**

```sh
soffice --headless --convert-to pptx presentation.odp
```

## **پلتفرم‌ها و چارچوب‌های پشتیبانی‌شده**

- **Windows**: .NET Framework 4.6.1 و بالاتر، .NET Core 2.1+، .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+، .NET 5/6/7.
- **محیط‌های ابری**: Microsoft Azure Functions، AWS Lambda (.NET Core)، کانتینرسازی Docker.
- **سازگاری با برنامه‌های Office**: نیازی به نصب Microsoft Office نیست.
- **زبان‌های برنامه‌نویسی پشتیبانی‌شده**: Open XML SDK می‌تواند با **C#**، **VB.NET**، **F#** و سایر زبان‌های پشتیبانی‌شده توسط .NET استفاده شود.

## **نتیجه‌گیری**

استفاده از **Open XML SDK** برای **استخراج متن از PPTX** هم کارایی و هم وضوح را ارائه می‌دهد، در حالی که **PPT و ODP** برای پردازش روان نیاز به یک گام تبدیل اولیه دارند. اتخاذ این رویکرد اطمینان می‌دهد که **عملکرد بالا**، **انعطاف‌پذیری** و **سازگاری گسترده** با برنامه‌های مدرن .NET فراهم می‌شود.
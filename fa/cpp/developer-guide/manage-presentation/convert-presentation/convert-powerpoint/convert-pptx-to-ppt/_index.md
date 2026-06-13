---
title: تبدیل PPTX به PPT در C++
linktitle: PPTX به PPT
type: docs
weight: 21
url: /fa/cpp/convert-pptx-to-ppt/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPTX
- PPTX به PPT
- ذخیره PPTX به صورت PPT
- صادرات PPTX به PPT
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "به راحتی PPTX را با Aspose.Slides برای C++ به PPT تبدیل کنید — اطمینان از سازگاری بدون درز با فرمت‌های PowerPoint در حالی که چیدمان و کیفیت ارائه شما حفظ می‌شود."
---
## **بررسی کلی**

این مقاله نحوه تبدیل ارائه PowerPoint با فرمت PPTX به فرمت PPT را با استفاده از C++ توضیح می‌دهد. موضوع زیر پوشش داده شده است.

- تبدیل PPTX به PPT در C++

## **تبدیل PPTX به PPT در C++**

برای کد نمونه C++ جهت تبدیل PPTX به PPT، لطفاً به بخش زیر مراجعه کنید: [تبدیل PPTX به PPT](#convert-pptx-to-ppt). این نمونه فقط فایل PPTX را بارگیری کرده و در فرمت PPT ذخیره می‌کند. با تعیین فرمت‌های ذخیره‌سازی مختلف، می‌توانید فایل PPTX را به بسیاری از فرمت‌های دیگر مانند PDF، XPS، ODP، HTML و غیره نیز ذخیره کنید همان‌گونه که در این مقالات بحث شده است.

- [تبدیل PPTX به PDF در C++](/slides/fa/cpp/convert-powerpoint-to-pdf/)
- [تبدیل PPTX به XPS در C++](/slides/fa/cpp/convert-powerpoint-to-xps/)
- [تبدیل PPTX به HTML در C++](/slides/fa/cpp/convert-powerpoint-to-html/)
- [تبدیل PPTX به ODP در C++](/slides/fa/cpp/save-presentation/)
- [تبدیل PPTX به PNG در C++](/slides/fa/cpp/convert-powerpoint-to-png/)

## **تبدیل PPTX به PPT**
برای تبدیل یک فایل PPTX به PPT کافی است نام فایل و فرمت ذخیره‌سازی را به متد **Save** کلاس [**Presentation**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation/) پاس دهید. نمونه کد C++ زیر یک Presentation را از PPTX به PPT با استفاده از تنظیمات پیش‌فرض تبدیل می‌کند.

```cpp
// بارگذاری PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// ذخیره در فرمت PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **پرسش‌های متداول**

**آیا تمام افکت‌ها و ویژگی‌های PPTX هنگام ذخیره در قالب PPT (نسخه 97–2003) حفظ می‌شوند؟**

همیشه نیست. فرمت PPT برخی قابلیت‌های جدیدتر (مانند برخی افکت‌ها، اشیاء و رفتارها) را ندارد، بنابراین ممکن است ویژگی‌ها در حین تبدیل ساده‌سازی یا به تصویر رستری تبدیل شوند.

**آیا می‌توانم فقط اسلایدهای انتخاب‌شده را به PPT تبدیل کنم به‌جای کل ارائه؟**

ذخیره‌سازی مستقیم کل ارائه را هدف می‌گیرد. برای تبدیل اسلایدهای خاص، می‌توانید یک ارائه جدید فقط با آن اسلایدها ایجاد کنید و به‌عنوان PPT ذخیره کنید؛ یا از سرویس/API‌ای استفاده کنید که پارامترهای تبدیل بر پایه اسلاید را پشتیبانی کند.

**آیا ارائه‌های دارای رمز عبور پشتیبانی می‌شوند؟**

بله. می‌توانید تشخیص دهید که آیا فایلی محافظت شده است، آن را با رمز عبور باز کنید و همچنین [تنظیمات محافظت/رمزنگاری](/slides/fa/cpp/password-protected-presentation/) را برای PPT ذخیره‌شده پیکربندی کنید.
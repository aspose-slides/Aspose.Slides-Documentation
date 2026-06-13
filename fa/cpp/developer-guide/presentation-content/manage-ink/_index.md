---
title: مدیریت اشیاء جوهر ارائه در C++
linktitle: مدیریت جوهر
type: docs
weight: 95
url: /fa/cpp/manage-ink/
keywords:
- جوهر
- شیء جوهر
- ردیاب جوهر
- مدیریت جوهر
- رسم جوهر
- رسم
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "مدیریت اشیاء جوهر PowerPoint — ایجاد، ویرایش و قالب‌بندی جوهر دیجیتال با Aspose.Slides برای C++. دریافت نمونه‌های کد برای ردیاب‌ها، رنگ و اندازهٔ براش."
---
## **معرفی**

PowerPoint قابلیت نوشتن با قلم (ink) را فراهم می‌کند تا بتوانید اشکال غیر استاندارد را رسم کنید؛ این اشکال می‌توانند برای برجسته‌سازی اشیاء دیگر، نشان دادن ارتباطات و فرآیندها و جلب توجه به موارد خاص در یک اسلاید استفاده شوند.

Aspose.Slides رابط کاربری [Aspose.Slides.Ink](https://reference.aspose.com/slides/fa/cpp/aspose.slides.ink/) را ارائه می‌دهد که شامل انواع موردنیاز برای ایجاد و مدیریت اشیاء جوهر است.

## **تفاوت بین اشیاء معمولی و اشیاء جوهر**

اشیاء در یک اسلاید PowerPoint معمولاً به‌صورت اشیاء شکل (shape) نمایان می‌شوند. یک شیء شکل، در ساده‌ترین شکل خود، یک کانتینر است که محدودهٔ خود (قاب) را به همراه ویژگی‌هایش تعریف می‌کند. ویژگی‌های بعدی شامل اندازهٔ ناحیهٔ کانتینر، شکل کانتینر، پس‌زمینهٔ کانتینر و غیره می‌باشد. برای اطلاعات بیشتر، به [Shape Layout Format](https://docs.aspose.com/slides/fa/cpp/shape-manipulations/#access-layout-formats-for-shape) نگاه کنید.

اما وقتی PowerPoint با یک شیء جوهر سروکار دارد، تمام ویژگی‌های قاب شیء (کانتینر) به‌جز اندازهٔ آن نادیده گرفته می‌شود. اندازهٔ ناحیهٔ کانتینر توسط مقادیر استاندارد `width` و `height` تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردیابی Inkshape**

ردیاب (Trace) یک عنصر پایه یا استاندارد برای ضبط مسیر قلم هنگام نوشتن جوهر دیجیتال است. ردیاب‌ها ضبط‌هایی هستند که توالی نقاط متصل را توصیف می‌کنند.

ساده‌ترین شکل کدگذاری، مختصات X و Y هر نقطهٔ نمونه‌برداری را مشخص می‌کند. وقتی تمام نقاط متصل رندر شوند، تصویری مشابه زیر تولید می‌شود:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصوصیات Brush برای رسم**

می‌توانید از یک brush برای رسم خطوطی که نقاط عناصر ردیابی را به هم متصل می‌کنند، استفاده کنید. brush دارای رنگ و اندازهٔ خاص خود است که مطابق با ویژگی‌های `Brush.Color` و `Brush.Size` می‌باشد.

### **تنظیم رنگ Brush جوهر**

این کد C++ نشان می‌دهد چگونه رنگ یک brush تنظیم شود:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **تنظیم اندازه Brush جوهر**

این کد C++ نشان می‌دهد چگونه اندازهٔ یک brush تنظیم شود:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

به‌طور کلی، عرض و ارتفاع یک brush برابر نیستند، بنابراین PowerPoint اندازهٔ brush را نمایش نمی‌دهد (بخش داده‌ها خاکستری می‌شود). اما زمانی که عرض و ارتفاع brush برابر باشند، PowerPoint اندازهٔ آن را به این شکل نمایش می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح بیشتر، ارتفاع شیء جوهر را افزایش می‌دهیم و ابعاد مهم را مرور می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

کانتینر (قاب) اندازهٔ brush‌ها را در نظر نمی‌گیرد—همیشه فرض می‌کند ضخامت خط صفر است (به تصویر آخر توجه کنید).

بنابراین، برای تعیین ناحیهٔ قابل مشاهدهٔ کل شیء جوهر، باید سایز brushهای اشیاء ردیابی را در نظر بگیریم. در اینجا، شیء هدف (شیء ردیابی متن دست‌نویس) به اندازهٔ کانتینر (قاب) مقیاس‌بندی شده است. وقتی اندازهٔ کانتینر (قاب) تغییر می‌کند، اندازهٔ brush ثابت می‌ماند و بالعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint هنگام کار با متن‌ها رفتار مشابهی نشان می‌دهد:

![ink_powerpoint6](ink_powerpoint6.png)

**مطالعهٔ بیشتر**

* برای آشنایی با اشکال به‌طور کلی، قسمت [PowerPoint Shapes](https://docs.aspose.com/slides/fa/cpp/powerpoint-shapes/) را مطالعه کنید.  
* برای اطلاعات بیشتر درباره مقادیر مؤثر، به [Shape Effective Properties](https://docs.aspose.com/slides/fa/cpp/shape-effective-properties/#get-effective-font-height-value) مراجعه کنید.
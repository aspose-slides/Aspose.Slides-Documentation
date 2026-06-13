---
title: مدیریت سرصفحه‌ها و پاورقی‌های ارائه در .NET
linktitle: سرصفحه و پاورقی
type: docs
weight: 140
url: /fa/net/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پاورقی
- متن پاورقی
- تنظیم سرصفحه
- تنظیم پاورقی
- جزئیات
- یادداشت‌ها
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از Aspose.Slides برای .NET استفاده کنید تا سرصفحه‌ها و پاورقی‌ها را در ارائه‌های PowerPoint و OpenDocument اضافه و سفارشی کنید و ظاهر حرفه‌ای داشته باشید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان مدیریت تنظیمات سرصفحه و پاورقی را در ارائه‌های PowerPoint می‌دهد. سرصفحه‌ها و پاورقی‌ها در سطح مستر ارائه مدیریت می‌شوند و API روش‌هایی برای تنظیم متن پاورقی، تغییر قابلیت مشاهدهٔ پاورقی و به‌روزرسانی متن سرصفحه در اسلایدهای یادداشت مستر فراهم می‌کند.

همچنین می‌توانید سرصفحه و پاورقی‌ها را برای اسلایدهای جزئیات و یادداشت‌ها مدیریت کنید. این شامل تغییر قابلیت مشاهده و متن مکان‌دارهای سرصفحه، پاورقی، شمارهٔ اسلاید و تاریخ‑زمان برای مستر یادداشت‌ها، تمام اسلایدهای فرزند یادداشت یا یک اسلاید یادداشت خاص می‌شود.

## **مدیریت متن سرصفحه و پاورقی**

یادداشت‌های برخی اسلایدهای خاص می‌توانند همان‌گونه که در مثال زیر نشان داده شده است به‌روزرسانی شوند:

```c#
// بارگذاری ارائه
Presentation pres = new Presentation("headerTest.pptx");

// تنظیم پاورقی
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// دسترسی و به‌روزرسانی سرصفحه
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// ذخیره ارائه
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// روش تنظیم متن سرصفحه/پاورقی
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```




## **مدیریت سرصفحه و پاورقی در اسلایدهای جزئیات و یادداشت‌ها**
Aspose.Slides برای .NET، پشتیبانی از سرصفحه و پاورقی در اسلایدهای جزئیات و یادداشت‌ها را دارا است. لطفاً مراحل زیر را دنبال کنید:

- یک [Presentation ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation)حاوی ویدئو را بارگذاری کنید.
- تنظیمات سرصفحه و پاورقی را برای مستر یادداشت‌ها و تمام اسلایدهای یادداشت تغییر دهید.
- مکان‌دارهای پاورقی مستر یادداشت و تمام فرزندان آن را قابل مشاهده کنید.
- مکان‌دارهای تاریخ و زمان مستر یادداشت و تمام فرزندان آن را قابل مشاهده کنید.
- تنظیمات سرصفحه و پاورقی را فقط برای اولین اسلاید یادداشت تغییر دهید.
- مکان‌دار سرصفحهٔ اسلاید یادداشت را قابل مشاهده کنید.
- متن را به مکان‌دار سرصفحهٔ اسلاید یادداشت اختصاص دهید.
- متن را به مکان‌دار تاریخ‑زمان اسلاید یادداشت اختصاص دهید.
- فایل ارائهٔ اصلاح‌شده را بنویسید.

کد نمونه در مثال زیر ارائه شده است.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// تغییر تنظیمات سرصفحه و پاورقی برای مستر یادداشت‌ها و تمام اسلایدهای یادداشت
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // اسلاید مستر یادداشت و تمام مکان‌دارهای Footer فرزند را قابل مشاهده کنید
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // اسلاید مستر یادداشت و تمام مکان‌دارهای Header فرزند را قابل مشاهده کنید
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // اسلاید مستر یادداشت و تمام مکان‌دارهای SlideNumber فرزند را قابل مشاهده کنید
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // اسلاید مستر یادداشت و تمام مکان‌دارهای Date and time فرزند را قابل مشاهده کنید

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // متن را برای اسلاید مستر یادداشت و تمام مکان‌دارهای Header فرزند تنظیم کنید
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // متن را برای اسلاید مستر یادداشت و تمام مکان‌دارهای Footer فرزند تنظیم کنید
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // متن را برای اسلاید مستر یادداشت و تمام مکان‌دارهای Date and time فرزند تنظیم کنید
	}

	// تغییر تنظیمات سرصفحه و پاورقی فقط برای اولین اسلاید یادداشت
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // مکان‌دار Header این اسلاید یادداشت را قابل مشاهده کنید

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // مکان‌دار Footer این اسلاید یادداشت را قابل مشاهده کنید

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // مکان‌دار SlideNumber این اسلاید یادداشت را قابل مشاهده کنید

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // مکان‌دار Date-time این اسلاید یادداشت را قابل مشاهده کنید

		headerFooterManager.SetHeaderText("New header text"); // متن را برای مکان‌دار Header اسلاید یادداشت تنظیم کنید
		headerFooterManager.SetFooterText("New footer text"); // متن را برای مکان‌دار Footer اسلاید یادداشت تنظیم کنید
		headerFooterManager.SetDateTimeText("New date and time text"); // متن را برای مکان‌دار Date-time اسلاید یادداشت تنظیم کنید
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **سوالات متداول**

**آیا می‌توانم «سرصفحه» را به اسلایدهای معمولی اضافه کنم؟**

در PowerPoint، «سرصفحه» فقط برای یادداشت‌ها و جزئیات (handouts) وجود دارد؛ در اسلایدهای معمولی عناصر پشتیبانی‌شده فقط پاورقی، تاریخ/زمان و شمارهٔ اسلاید هستند. در Aspose.Slides این محدودیت‌ها به همان شکل اعمال می‌شود: سرصفحه فقط برای Notes/Handout، و در اسلایدها—Footer/DateTime/SlideNumber.

**اگر چیدمان شامل ناحیهٔ پاورقی نباشد، آیا می‌توانم قابلیت مشاهدهٔ آن را «فعال» کنم؟**

بله. با استفاده از مدیر سرصفحه/پاورقی قابلیت مشاهده را بررسی کنید و در صورت نیاز آن را فعال کنید. این شاخص‌ها و روش‌های API برای مواردی طراحی شده‌اند که مکان‌دار موجود نباشد یا مخفی باشد.

**چگونه می‌توانم شمارهٔ اسلاید را از مقداری غیر از ۱ شروع کنم؟**

عدد [first slide number](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/firstslidenumber/) ارائه را تنظیم کنید؛ پس از آن تمام شماره‌گذاری‌ها دوباره محاسبه می‌شوند. به‌عنوان مثال می‌توانید از ۰ یا ۱۰ شروع کنید و شماره را در اسلاید عنوان مخفی کنید.

**هنگام خروجی گرفتن به PDF/تصاویر/HTML، سرصفحه‌ها/پاورقی‌ها چه اتفاقی می‌افتند؟**

آنها به‌عنوان عناصر متنی معمولی در ارائه رندر می‌شوند. به این معنی که اگر این عناصر در اسلایدها/صفحات یادداشت قابل مشاهده باشند، در قالب خروجی نیز همراه با بقیه محتوا ظاهر می‌شوند.
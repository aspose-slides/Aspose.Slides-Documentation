---
title: "خودکارسازی تولید PowerPoint در C++: ایجاد ارائه‌های پویا به سادگی"
linktitle: "خودکارسازی تولید PowerPoint"
type: docs
weight: 20
url: /fa/cpp/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- پلتفرم‌های ابری
- خودکارسازی تولید PowerPoint
- ایجاد ارائه‌ها به صورت برنامه‌نویسی
- خودکارسازی PowerPoint
- ایجاد اسلایدهای پویا
- گزارش‌های تجاری خودکار
- خودکارسازی PPT
- ارائه C++
- C++
- Aspose.Slides
description: "ایجاد خودکار اسلایدها در پلتفرم‌های ابری با Aspose.Slides برای C++—تولید، ویرایش و تبدیل فایل‌های PowerPoint و OpenDocument به سرعت و به طور قابل اعتماد."
---
## **مقدمه**

ایجاد ارائه‌های PowerPoint به‌صورت دستی می‌تواند کار زمان‌بر و تکراری باشد—به‌ویژه وقتی محتوای آن بر پایه داده‌های پویا است که به‌طور مداوم تغییر می‌کنند. چه ساخت گزارش‌های هفتگی کسب‌وکار، ترکیب مطالب آموزشی، یا تولید دک‌های فروش آماده برای مشتری باشد، خودکارسازی می‌تواند ساعت‌ها زمان را صرفه‌جویی کند و تداوم را در میان تیم‌ها تضمین کند.

برای توسعه‌دهندگان C++، خودکارسازی ایجاد ارائه‌های PowerPoint امکان‌های قدرتمندی را فراهم می‌کند. می‌توانید تولید اسلایدها را در پورتال‌های وب، ابزارهای دسکتاپ، سرویس‌های بک‌اند یا پلتفرم‌های ابری یکپارچه کنید تا به‌صورت پویا داده‌ها را به ارائه‌های حرفه‌ای و برنددار تبدیل کنید—بر حسب نیاز.

در این مقاله موارد استفاده رایج برای تولید خودکار PowerPoint در برنامه‌های C++ (از جمله استقرار در پلتفرم‌های ابری) را بررسی می‌کنیم و دلایلی را که این ویژگی در راهکارهای مدرن ضروری می‌شود، بیان می‌کنیم. از استخراج داده‌های تجاری به‌صورت لحظه‌ای تا تبدیل متن یا تصاویر به اسلایدها، هدف تبدیل محتوای خام به قالب‌های بصری ساختاریافته‌ای است که مخاطب به‌سرعت درک کند.

## **موارد استفاده رایج برای خودکارسازی PowerPoint در C++**

خودکارسازی تولید PowerPoint به‌ویژه در سناریوهایی که محتوای ارائه باید به‌صورت پویا ترکیب، شخصی‌سازی یا به‌طور مکرر به‌روزرسانی شود، مفید است. برخی از رایج‌ترین موارد استفاده در دنیا عبارتند از:

- **گزارش‌ها و داشبوردهای تجاری**  
  تولید خلاصه‌های فروش، KPIها یا گزارش‌های عملکرد مالی با کشیدن داده‌های زنده از پایگاه‌های داده یا APIها.

- **دک‌های فروش و بازاریابی شخصی‌سازی‌شده**  
  ایجاد خودکار دک‌های پیشنهادی مخصوص هر مشتری با استفاده از داده‌های CRM یا فرم، که سرعت تحویل و سازگاری برند را تضمین می‌کند.

- **محتوای آموزشی**  
  تبدیل مطالب آموزشی، پرسش‌نامه‌ها یا خلاصه دوره‌ها به دک‌های ساختاریافته برای پلتفرم‌های e‑learning.

- **بینش‌های داده و AI**  
  استفاده از پردازش زبان طبیعی یا موتورهای تحلیلی برای تبدیل داده‌های خام یا متن طولانی به ارائه‌های خلاصه شده.

- **اسلایدهای مبتنی بر رسانه**  
  ترکیب ارائه‌ها از تصاویر بارگذاری‌شده، اسکرین‌شات‌های حاشیه‌نویسی‌شده یا فریم‌های کلیدی ویدئو همراه با توضیحات پشتیبان.

- **تبدیل اسناد**  
  تبدیل خودکار اسناد Word، PDF یا ورودی‌های فرم به ارائه‌های بصری با حداقل تلاش دستی.

- **ابزارهای توسعه‌دهنده و فنی**  
  ایجاد دموی فنی، مرور مستندات یا changelogها در قالب اسلاید به‌طور مستقیم از کد یا محتوای markdown.

با خودکارسازی این گردش‌کارها، سازمان‌ها می‌توانند مقیاس‌پذیری تولید محتوا را افزایش دهند، سازگاری را حفظ کرده و زمان را برای کارهای استراتژیک‌تر آزاد کنند.

## **بیایید کدنویسی کنیم**

برای این مثال، ما **[Aspose.Slides for C++](https://products.aspose.com/slides/fa/cpp/)** را برای نمایش خودکارسازی PowerPoint انتخاب کردیم چون مجموعه ویژگی‌های جامع و کاربری آسانی دارد که برای کار با ارائه‌ها به‌صورت برنامه‌نویسی مناسب است.

بر خلاف کتابخانه‌های سطح پایین که نیاز به کار مستقیم با ساختار Open XML دارند (که اغلب منجر به کدهای طولانی و کمتر خوانا می‌شود)، Aspose.Slides یک API سطح بالاتر ارائه می‌دهد. این کتابخانه پیچیدگی را پنهان می‌کند و به توسعه‌دهندگان اجازه می‌دهد بر منطق ارائه—مانند طرح‌بندی، قالب‌بندی و بایندینگ داده‌ها—تمرکز کنند بدون این‌که نیاز به درک جزئیات فرمت فایل PowerPoint داشته باشند.

اگرچه Aspose.Slides یک کتابخانه تجاری است، نسخهٔ [نسخه آزمایشی رایگان](https://releases.aspose.com/slides/fa/cpp/) آن به‌طور کامل قادر به اجرای مثال‌های ارائه‌شده در این مقاله است. برای نشان دادن ایده‌ها، آزمایش ویژگی‌ها یا ساخت یک proof of concept همان‌طور که در اینجا می‌بینید، نسخه آزمایشی کافی است. این گزینه برای آزمایش خودکارسازی PowerPoint بدون نیاز به خرید فوری لایسنس مناسب است.

خب، بیایید با ساخت یک ارائه نمونه با محتوای واقعی پیش برویم.

### **ایجاد اسلاید عنوان**

ابتدا یک ارائه جدید ایجاد می‌کنیم و یک اسلاید عنوان با عنوان اصلی و زیرعنوان می‌افزاییم.

```cpp
auto presentation = MakeObject<Presentation>();

auto slide0 = presentation->get_Slide(0);

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Title);
slide0->set_LayoutSlide(layoutSlide);

auto titleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(0));
auto subtitleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(1));

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review – Q1 2025");
subtitleShape->get_TextFrame()->set_Text(u"Prepared for Executive Team");
```

![اسلاید عنوان](slide_0.png)

### **افزودن اسلاید با نمودار ستونی**

سپس اسلایدی را می‌سازیم که عملکرد فروش منطقه‌ای را به‌صورت نمودار ستونی نمایش می‌دهد.

```cpp
auto layoutSlide1 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide1 = presentation->get_Slides()->AddEmptySlide(layoutSlide1);

auto chart = slide1->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 350, false);
chart->get_Legend()->set_Position(LegendPositionType::Bottom);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Data from January – March 2025");
chart->get_ChartTitle()->set_Overlay(false);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"North America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Europe")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Asia Pacific")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Latin America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 5, 0, ObjectExt::Box<String>(u"Middle East")));

auto series = chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Sales ($K)")), chart->get_Type());
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(480)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(365)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(290)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<int32_t>(150)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 5, 1, ObjectExt::Box<int32_t>(120)));
```

![اسلاید حاوی نمودار](slide_1.png)

### **افزودن اسلاید با جدول**

حال اسلایدی را اضافه می‌کنیم که معیارهای کلیدی عملکرد را به‌صورت جدول ارائه می‌دهد.

```cpp
auto layoutSlide2 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide2 = presentation->get_Slides()->AddEmptySlide(layoutSlide2);

auto columnWidths = MakeArray<double>({ 200, 100 });
auto rowHeights = MakeArray<double>({ 40, 40, 40, 40, 40 });

auto table = slide2->get_Shapes()->AddTable(200, 200, columnWidths, rowHeights);
table->get_Column(0)->idx_get(0)->get_TextFrame()->set_Text(u"Metric");
table->get_Column(1)->idx_get(0)->get_TextFrame()->set_Text(u"Value");
table->get_Column(0)->idx_get(1)->get_TextFrame()->set_Text(u"Total Revenue");
table->get_Column(1)->idx_get(1)->get_TextFrame()->set_Text(u"$1.4M");
table->get_Column(0)->idx_get(2)->get_TextFrame()->set_Text(u"Gross Margin");
table->get_Column(1)->idx_get(2)->get_TextFrame()->set_Text(u"54%");
table->get_Column(0)->idx_get(3)->get_TextFrame()->set_Text(u"New Customers");
table->get_Column(1)->idx_get(3)->get_TextFrame()->set_Text(u"340");
table->get_Column(0)->idx_get(4)->get_TextFrame()->set_Text(u"Customer Retention");
table->get_Column(1)->idx_get(4)->get_TextFrame()->set_Text(u"87%");
```

![اسلاید حاوی جدول](slide_2.png)

### **افزودن اسلاید خلاصه با نقاط بولت‌دار**

در نهایت، یک اسلاید خلاصه و برنامه عملیاتی با لیست سادهٔ نقطه‌ای اضافه می‌کنیم.

```cpp
static SharedPtr<IParagraph> CreateBulletParagraph(String text) {
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
    paragraph->get_ParagraphFormat()->set_Indent(15);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    paragraph->set_Text(text);
    return paragraph;
}
```
```cpp
auto layoutSlide3 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide3 = presentation->get_Slides()->AddEmptySlide(layoutSlide3);

auto bulletList = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 50, 600, 200);
bulletList->get_FillFormat()->set_FillType(FillType::NoFill);
bulletList->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

bulletList->get_TextFrame()->get_Paragraphs()->Clear();
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Strong performance in North America; growth opportunity in Asia Pacific"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Improve marketing outreach in underperforming regions"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Prepare new campaign strategy for Q2"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Schedule follow-up review in early July"));
```

![اسلاید حاوی متن](slide_3.png)

### **ذخیره ارائه**

در پایان، ارائه را روی دیسک ذخیره می‌کنیم:

```java
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **نتیجه‌گیری**

خودکارسازی تولید PowerPoint در برنامه‌های C++ مزایای واضحی از جمله صرفه‌جویی در زمان و کاهش تلاش دستی دارد. با ادغام محتوای پویا مانند نمودارها، جدول‌ها و متن، توسعه‌دهندگان می‌توانند به‌سرعت ارائه‌های سازگار و حرفه‌ای تولید کنند—ایده‌آل برای گزارش‌های تجاری، جلسات مشتری یا محتوای آموزشی.

در این مقاله، نحوهٔ خودکارسازی ساخت یک ارائه از صفر را نشان دادیم، شامل افزودن اسلاید عنوان، نمودارها و جدول‌ها. این رویکرد را می‌توان در انواع موارد استفاده که به ارائه‌های داده‌محور خودکار نیاز دارند، به‌کار برد.

با استفاده از ابزارهای مناسب، توسعه‌دهندگان C++ می‌توانند به‌صورت کارآمد PowerPoint را خودکار کنند، بهره‌وری را افزایش دهند و اطمینان از سازگاری در تمام ارائه‌ها داشته باشند.
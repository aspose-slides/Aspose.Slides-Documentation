---
title: مدیریت کنترل‌های ActiveX در ارائه‌ها در .NET
linktitle: ActiveX
type: docs
weight: 80
url: /fa/net/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- تغییر ActiveX
- پخش‌کننده رسانه
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "آموزش چگونگی استفاده Aspose.Slides برای .NET از ActiveX برای خودکارسازی و بهبود ارائه‌های PowerPoint، که به توسعه‌دهندگان کنترل قدرتمندی بر اسلایدها می‌دهد."
---
## **مقدمه**

کنترل‌های ActiveX در ارائه‌ها استفاده می‌شوند. Aspose.Slides for .NET به شما امکان مدیریت کنترل‌های ActiveX را می‌دهد، اما مدیریت آن‌ها کمی پیچیده‌تر و متفاوت از شکل‌های معمولی ارائه است. از نسخه Aspose.Slides for .NET 6.9.0، این کامپوننت از مدیریت کنترل‌های ActiveX پشتیبانی می‌کند. در حال حاضر می‌توانید به کنترل ActiveX اضافه شده در ارائه دسترسی پیدا کرده و با استفاده از ویژگی‌های مختلف آن را تغییر یا حذف کنید. به یاد داشته باشید که کنترل‌های ActiveX شکل نیستند و بخشی از IShapeCollection ارائه نیستند، بلکه در IControlCollection جداگانه قرار دارند. این مقاله نشان می‌دهد چگونه با آن‌ها کار کنید.

## **تغییر کنترل‌های ActiveX**
برای مدیریت یک کنترل ساده ActiveX مانند جعبه متن و دکمه فرمان ساده در یک اسلاید:

1. یک نمونه از کلاس Presentation ایجاد کنید و ارائه را که شامل کنترل‌های ActiveX است بارگذاری کنید.
2. یک مرجع اسلاید را بر اساس شاخص آن دریافت کنید.
3. با دسترسی به IControlCollection، کنترل‌های ActiveX موجود در اسلاید را دریافت کنید.
4. کنترل ActiveX TextBox1 را با استفاده از شیء ControlEx دسترسی پیدا کنید.
5. ویژگی‌های مختلف کنترل ActiveX TextBox1 از جمله متن، قلم، ارتفاع قلم و موقعیت فریم را تغییر دهید.
6. کنترل دوم به نام CommandButton1 را دسترسی پیدا کنید.
7. عنوان دکمه، قلم و موقعیت را تغییر دهید.
8. موقعیت فریم‌های کنترل‌های ActiveX را جابجا کنید.
9. ارائه اصلاح شده را به فایل PPTX بنویسید.

قطعه کد زیر کنترل‌های ActiveX را در اسلایدهای ارائه به‌روزرسانی می‌کند همان‌طور که در زیر نشان داده شده است.

```c#
// دسترسی به ارائه با کنترل‌های ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// دسترسی به اولین اسلاید در ارائه
ISlide slide = presentation.Slides[0];

// تغییر متن TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // تغییر تصویر جایگزین. Powerpoint این تصویر را هنگام فعال‌سازی ActiveX جایگزین می‌کند، بنابراین گاهی اوقات می‌توان تصویر را بدون تغییر گذاشت.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// تغییر عنوان دکمه
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // تغییر جایگزین
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// جابه‌جایی فریم‌های ActiveX به پایین 100 نقطه
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// ذخیرهٔ ارائه با کنترل‌های ActiveX ویرایش‌شده
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// اکنون حذف کنترل‌ها
slide.Controls.Clear();

// ذخیرهٔ ارائه با کنترل‌های ActiveX پاک‌شده
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **افزودن کنترل ActiveX Media Player**
برای افزودن کنترل ActiveX Media Player، لطفاً مراحل زیر را انجام دهید:

1. یک نمونه از کلاس Presentation ایجاد کنید و ارائه نمونه‌ای که شامل کنترل‌های Media Player ActiveX است بارگذاری کنید.
2. یک نمونه هدف از کلاس Presentation ایجاد کنید و یک ارائه خالی تولید کنید.
3. اسلاید حاوی کنترل Media Player ActiveX را از ارائه الگو به ارائه هدف کپی کنید.
4. اسلاید کپی شده در ارائه هدف را دسترسی پیدا کنید.
5. با دسترسی به IControlCollection، کنترل‌های ActiveX موجود در اسلاید را دریافت کنید.
6. کنترل Media Player ActiveX را دسترسی پیدا کنید و مسیر ویدیو را با استفاده از ویژگی‌های آن تنظیم کنید.
7. ارائه را به فایل PPTX ذخیره کنید.

```c#
// یک نمونه از کلاس Presentation که فایل PPTX را نمایندگی می‌کند
Presentation presentation = new Presentation("template.pptx");

// یک نمونهٔ خالی از ارائه ایجاد کنید
Presentation newPresentation = new Presentation();

// اسلاید پیش‌فرض را حذف کنید
newPresentation.Slides.RemoveAt(0);

// اسلاید حاوی کنترل Media Player ActiveX را کپی کنید
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// به کنترل Media Player ActiveX دسترسی پیدا کنید و مسیر ویدیو را تنظیم کنید
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// ارائه را ذخیره کنید
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**آیا Aspose.Slides کنترل‌های ActiveX را هنگام خواندن و ذخیره مجدد حفظ می‌کند حتی اگر در زمان اجرا .NET قابل اجرا نباشند؟**

بله. Aspose.Slides آنها را به‌عنوان بخشی از ارائه در نظر می‌گیرد و می‌تواند ویژگی‌ها و فریم‌های آنها را بخواند/تغییر دهد؛ اجرای خود کنترل‌ها برای حفظشان لازم نیست.

**کنترل‌های ActiveX چگونه با اشیاء OLE در یک ارائه متفاوت هستند؟**

کنترل‌های ActiveX کنترل‌های مدیریت‌شده تعاملی هستند (دکمه‌ها، جعبه‌های متن، Media Player)، در حالی که [OLE](/slides/fa/net/manage-ole/) به اشیای برنامه جاسازی‌شده (به‌ عنوان مثال یک برگه Excel) اشاره دارد. آنها به‌ شکل متفاوتی ذخیره و پردازش می‌شوند و مدل‌های ویژگی متفاوتی دارند.

**آیا رویدادهای ActiveX و ماکروهای VBA در صورتی که فایل توسط Aspose.Slides اصلاح شده باشد کار می‌کنند؟**

Aspose.Slides علامت‌گذاری و متادیتای موجود را حفظ می‌کند؛ با این حال، رویدادها و ماکروها تنها در PowerPoint روی ویندوز وقتی که امنیت اجازه دهد اجرا می‌شوند. این کتابخانه VBA را اجرا نمی‌کند.
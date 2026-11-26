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
- پخش‌کننده رسانه‌ای
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "جعبه‌های متن و دکمه‌های ActiveX را ویرایش کنید، پیش‌نمایش کنترل‌ها را به‌روز کنید و یک کنترل Windows Media Player را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET دوباره استفاده کنید."
---
## **معرفی**

کنترل‌های ActiveX عناصر تعاملی مانند جعبه‌های متن، دکمه‌های فرمان و پخش‌کننده‌های رسانه‌ای را به اسلاید PowerPoint می‌دهند. Aspose.Slides برای .NET کنترل‌های یک اسلاید را از طریق [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/) در دسترس قرار می‌دهد. از این مجموعه برای ویرایش یک کنترل، جابه‌جایی آن روی اسلاید یا حذف آن استفاده کنید.

## **فهرست کنترل‌های ActiveX و ویژگی‌های ذخیره‌شدهٔ آن‌ها**

برای بررسی یک قالب ناآشنا، آن را برای خواندن باز کنید و بر روی کنترل‌های هر اسلاید تکرار کنید. مثال شماره اسلاید، نام کنترل، [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/)، و هر جفت کلید‑مقدار در [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties) را گزارش می‌دهد. ارائه را بدون فعال‌سازی کنترل‌ها، فراخوانی رویدادها یا ماکروها، تغییر مقادیر یا ذخیرهٔ فایل می‌خواند.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

خروجی انتخابی از `ActiveX.pptm` یک جعبه متن و یک دکمه فرمان را نشان می‌دهد.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

یک مجموعهٔ ویژگی خالی به شکل `[]` ظاهر می‌شود. برای کنترل‌هایی که از ذخیره‌سازی باینری استفاده می‌کنند، `Properties` می‌تواند `null` برگرداند که به صورت `Properties unavailable` نمایش داده می‌شود. اگر فقط به نام‌ها نیاز دارید، پس از بررسی مقدار null از [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) استفاده کنید. گزارش ویژگی‌های موجود در ارائه را فهرست می‌کند. یک کنترل ممکن است در زمان اجرا ویژگی‌های اضافی را پشتیبانی کند.

## **تغییر کنترل‌های ActiveX**

مثال یک ارائهٔ فعال‌سازی‑ماکرو با یک جعبه متن به نام `TextBox1` و یک دکمه فرمان به نام `CommandButton1` در اسلاید اول انتظار دارد. از [control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) برای تغییر مقدار جعبه متن و عنوان دکمه استفاده می‌کند. هر کنترل همچنین یک پیش‌نمایش ثابت دارد که PowerPoint می‌تواند پیش از فعال‌سازی نمایش دهد. برای هر کنترل یک تصویر PNG که متن و ظاهر به‌روز شده را نشان می‌دهد، فراهم کنید. مثال این تصاویر را از طریق [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/) اختصاص می‌دهد.

مثال هر کنترل را در اسلاید اول به میزان 100 نقطه به سمت پایین جابه‌جا می‌کند با تغییر [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). ارائه ویرایش‌شده را در قالب PPTM ذخیره می‌کند، سپس با استفاده از [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) نسخهٔ دوم را که تمام کنترل‌های ActiveX از آن اسلاید حذف شده‌اند، ذخیره می‌نماید.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **افزودن کنترل پخش‌کنندهٔ رسانه‌ای ActiveX**

برای استفاده مجدد از یک کنترل پخش‌کنندهٔ Windows Media Player پیکربندی‌شده، با الگوی دارای یک پخش‌کننده به نام `WindowsMediaPlayer1` در اسلاید اول شروع کنید. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) کل اسلاید را به یک ارائهٔ جدید کپی می‌کند. مثال مقدار `URL` پخش‌کننده را در [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) تنظیم می‌کند و اسلاید کلون‌شده را به عنوان تنها اسلاید در خروجی ذخیره می‌نماید. ویدئو به‌صورت خارجی می‌ماند، بنابراین مسیر قابل دسترسی برای پخش‌کننده را انتخاب کنید.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند کنترل‌های ActiveX را بدون اجرای آن‌ها حفظ کند؟**

بله. Aspose.Slides می‌تواند کنترل‌ها را بخواند و ذخیره کند، از جمله ویژگی‌ها و موقعیت‌هایشان، بدون فعال‌سازی آن‌ها.

**تفاوت کنترل‌های ActiveX با اشیاء OLE چیست؟**

کنترل‌های ActiveX به کاربران اجازه می‌دهند با اسلاید تعامل داشته باشند، به عنوان مثال با وارد کردن متن یا کلیک کردن روی یک دکمه. یک [OLE object](/slides/fa/net/manage-ole/) به اسلاید امکان می‌دهد محتوایی که توسط برنامهٔ دیگری مدیریت می‌شود، مثل یک برگهٔ Excel، را شامل شود یا به آن لینک دهد.

**آیا رویدادهای ActiveX پس از ذخیرهٔ یک ارائه با Aspose.Slides همچنان ماکروهای VBA را فعال می‌کنند؟**

ارائه را در قالبی که ماکرو فعال است مانند PPTM ذخیره کنید تا پروژهٔ VBA آن حفظ شود. PowerPoint برای ویندوز می‌تواند‌Handlerهای رویداد موجود را اجرا کند وقتی تنظیمات امنیتی آن اجازهٔ استفاده همزمان از کنترل‌های ActiveX و ماکروها را می‌دهد.
---
title: إدارة عناصر التحكم ActiveX في العروض التقديمية في .NET
linktitle: ActiveX
type: docs
weight: 80
url: /ar/net/activex/
keywords:
- ActiveX
- عنصر تحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغّل وسائط
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحرير صناديق نصوص وأزرار ActiveX، وتحديث معاينات عناصر التحكم، وإعادة استخدام عنصر تحكم Windows Media Player في عروض PowerPoint التقديمية باستخدام Aspose.Slides for .NET."
---
## **المقدمة**

تمنح عناصر التحكم ActiveX شريحة PowerPoint عناصر تفاعلية مثل صناديق النص وأزرار الأوامر ومشغلات الوسائط. Aspose.Slides for .NET تكشف عن عناصر التحكم في الشريحة عبر [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). استخدم هذه المجموعة لتعديل عنصر التحكم، أو نقله على الشريحة، أو إزالته.

## **قائمة عناصر تحكم ActiveX وخصائصها المخزنة**

لتفقد قالب غير مألوف، افتحه للقراءة وتكرّر عبر عناصر التحكم في كل شريحة. يُظهر المثال رقم الشريحة، اسم عنصر التحكم، [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/)، وكل زوج مفتاح‑قيمة في [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). يقرأ العرض التقديمي دون تنشيط عناصر التحكم، أو استدعاء الأحداث أو الماكرو، أو تغيير القيم، أو حفظ الملف.

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

يُظهر الناتج المختار من `ActiveX.pptm` صندوق نص وزر أمر.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

تظهر مجموعة الخصائص الفارغة كـ `[]`. بالنسبة لعناصر التحكم التي تستخدم تخزينًا ثنائيًا، قد تُعيد `Properties` قيمة `null`، وتُعرض كـ `Properties unavailable`. إذا كنت بحاجة فقط إلى الأسماء، استخدم [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) بعد فحص القيمة `null`. يُدرج التقرير الخصائص المتوفرة في العرض التقديمي. قد يدعم عنصر التحكم خصائص إضافية أثناء التشغيل.

## **تعديل عناصر تحكم ActiveX**

يتوقع المثال عرضًا تقديميًا مدعومًا بالماكرو يحتوي على صندوق نص اسمه `TextBox1` وزر أمر اسمه `CommandButton1` في الشريحة الأولى. يستخدم [control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) لتغيير قيمة صندوق النص وعنوان الزر. لكل عنصر تحكم معاينة ثابتة يمكن لـ PowerPoint عرضها قبل التنشيط. قدّم صورة PNG لكل عنصر تحكم تُظهر النص المحدث والمظهر. يعيّن المثال هذه الصور عبر [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

يحرك المثال كل عنصر تحكم في الشريحة الأولى إلى الأسفل بمقدار 100 نقطة عن طريق تعديل [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). يحفظ العرض التقديمي المعدل بصيغة PPTM، ثم يستخدم [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) لحفظ نسخة ثانية تُزيل جميع عناصر تحكم ActiveX من تلك الشريحة.

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

## **إضافة عنصر تحكم مشغل وسائط ActiveX**

لإعادة استخدام عنصر تحكم Windows Media Player مُعد، ابدأ بقالب تحتوي شريحته الأولى على مشغل اسمه `WindowsMediaPlayer1`. تقوم [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) بنسخ الشريحة بالكامل إلى عرض تقديمي جديد. يضبط المثال خاصية `URL` الخاصة بالمشغل في [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) ويحفظ الشريحة المستنسخة كالشريحة الوحيدة في الناتج. يبقى الفيديو خارجيًا، لذا اختر مسارًا يمكن للمشغل الوصول إليه أثناء التشغيل.

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

## **التعليمات المتكررة**

**هل يمكن لـ Aspose.Slides حفظ عناصر تحكم ActiveX دون تشغيلها؟**  
نعم. يمكن لـ Aspose.Slides قراءة وحفظ عناصر التحكم، بما في ذلك خصائصها ومواقعها، دون تنشيطها.

**كيف تختلف عناصر تحكم ActiveX عن كائنات OLE؟**  
تسمح عناصر تحكم ActiveX للمستخدمين بالتفاعل مع الشريحة، على سبيل المثال عن طريق إدخال نص أو النقر على زر. يسمح [OLE object](/slides/ar/net/manage-ole/) للشريحة باحتواء أو ربط محتوى تُديره تطبيق آخر، مثل ورقة عمل Excel.

**هل ستستمر أحداث ActiveX في تشغيل ماكروات VBA بعد حفظ عرض تقديمي باستخدام Aspose.Slides؟**  
احفظ العرض التقديمي بصيغة تدعم الماكرو مثل PPTM للاحتفاظ بمشروع VBA الخاص به. يمكن لـ PowerPoint لنظام Windows تشغيل معالجات الأحداث الموجودة عندما تسمح إعدادات الأمان الخاصة به بكل من عناصر تحكم ActiveX والماكروات.
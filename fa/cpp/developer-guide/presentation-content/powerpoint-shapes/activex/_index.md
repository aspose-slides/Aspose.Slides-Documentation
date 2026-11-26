---
title: مدیریت کنترل‌های ActiveX در ارائه‌ها با استفاده از C++
linktitle: ActiveX
type: docs
weight: 80
url: /fa/cpp/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- اصلاح ActiveX
- پخش‌کننده رسانه‌ای
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "متن جعبه‌ها و دکمه‌های ActiveX را ویرایش کنید، پیش‌نمایش‌های کنترل را به‌روز کنید، و یک کنترل Windows Media Player را در ارائه‌های PowerPoint با Aspose.Slides برای C++ مجدداً استفاده کنید."
---
## **مقدمه**

کنترل‌های ActiveX عناصر تعاملی مانند جعبه‌های متن، دکمه‌های فرمان و پخش‌کننده‌های رسانه‌ای را به یک اسلاید PowerPoint می‌دهند. Aspose.Slides برای C++ کنترل‌های یک اسلاید را از طریق [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/) در دسترس قرار می‌دهد. از این مجموعه برای ویرایش یک کنترل، جابجا کردن آن در اسلاید یا حذف آن استفاده کنید.

## **فهرست کنترل‌های ActiveX و ویژگی‌های ذخیره‌شده آن‌ها**

برای بررسی یک الگو که با آن آشنا نیستید، آن را برای خواندن باز کنید و در هر اسلاید به مرور کنترل‌ها بپردازید. این مثال شماره اسلاید، نام کنترل، [class ID](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/)، و هر جفت کلید‑مقدار در [stored properties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/) را گزارش می‌دهد. ارائه را بدون فعال‌سازی کنترل‌ها، فراخوانی رویدادها یا ماکروها، تغییر مقادیر یا ذخیره فایل می‌خواند.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");

for (auto i = 0; i < presentation->get_Slides()->get_Count(); ++i)
{
    auto controls = presentation->get_Slide(i)->get_Controls();
    for (auto j = 0; j < controls->get_Count(); ++j)
    {
        auto control = controls->idx_get(j);
        Console::WriteLine(u"Slide {0} | {1} | {2}", i + 1, control->get_Name(), control->get_ClassId().ToString());
        auto properties = control->get_Properties();
        if (!properties)
        {
            Console::WriteLine(u"  Properties unavailable");
            continue;
        }

        if (properties->get_Count() == 0)
            Console::WriteLine(u"  []");

        auto entries = properties->GetEnumerator();
        while (entries->MoveNext())
        {
            auto property = entries->get_Current();
            Console::WriteLine(u"  {0} = {1}", property.get_Key(), property.get_Value());
        }
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

یک مجموعه ویژگی خالی به صورت `[]` نمایش داده می‌شود. برای کنترل‌هایی که از ذخیره‌سازی باینری استفاده می‌کنند، `get_Properties` می‌تواند `nullptr` برگرداند که به عنوان `Properties unavailable` نشان داده می‌شود. اگر فقط به نام‌ها نیاز دارید، پس از اطمینان از وجود مجموعه، از [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) استفاده کنید. گزارش ویژگی‌های موجود در ارائه را فهرست می‌کند. یک کنترل ممکن است در زمان اجرا ویژگی‌های اضافی داشته باشد.

## **تغییر کنترل‌های ActiveX**

این مثال انتظار دارد یک ارائه فعال‌سازی ماکرو با یک جعبه متن به نام `TextBox1` و یک دکمه فرمان به نام `CommandButton1` در اسلاید اول داشته باشد. از [control properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) برای تغییر مقدار جعبه متن و عنوان دکمه استفاده می‌کند. هر کنترل همچنین یک پیش‌نمایش ثابت دارد که PowerPoint می‌تواند پیش از فعال‌سازی نمایش دهد. برای هر کنترل یک فایل PNG که متن و ظاهر به‌روز شده را نشان می‌دهد فراهم کنید. مثال این تصاویر را از طریق [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/) اختصاص می‌دهد.

مثال هر کنترل در اسلاید اول را با تغییر [frame](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/) به میزان 100 پوینت به سمت پایین جابه‌جا می‌کند. ارائه ویرایش‌شده را در فرمت PPTM ذخیره می‌کند، سپس با استفاده از [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) نسخه دوم را ذخیره می‌کند که تمامی کنترل‌های ActiveX از آن اسلاید حذف شده‌اند.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");
auto controls = presentation->get_Slide(0)->get_Controls();
SharedPtr<IControl> textBox;
SharedPtr<IControl> button;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"TextBox1")
        textBox = control;
    else if (control->get_Name() == u"CommandButton1")
        button = control;
}

if (!textBox || !button || !textBox->get_Properties() || !button->get_Properties())
{
    Console::WriteLine(u"The first slide must contain both named controls with editable properties.");
    return;
}

if (!File::Exists(u"text-box-preview.png") || !File::Exists(u"button-preview.png"))
{
    Console::WriteLine(u"Supply both preview images before updating the controls.");
    return;
}

textBox->get_Properties()->idx_set(u"Value", u"Changed text");
button->get_Properties()->idx_set(u"Caption", u"Show message");

auto textBoxBytes = File::ReadAllBytes(u"text-box-preview.png");
auto buttonBytes = File::ReadAllBytes(u"button-preview.png");
auto textBoxPreview = presentation->get_Images()->AddImage(textBoxBytes);
auto buttonPreview = presentation->get_Images()->AddImage(buttonBytes);
textBox->get_SubstitutePictureFormat()->get_Picture()->set_Image(textBoxPreview);
button->get_SubstitutePictureFormat()->get_Picture()->set_Image(buttonPreview);

for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    auto frame = control->get_Frame();
    auto movedFrame = MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation());
    control->set_Frame(movedFrame);
}

presentation->Save(u"edited-controls.pptm", SaveFormat::Pptm);

controls->Clear();
presentation->Save(u"removed-controls.pptm", SaveFormat::Pptm);
```

## **افزودن یک کنترل Media Player فعال‌سازی شده (ActiveX)**

برای استفاده مجدد از یک کنترل Windows Media Player پیکربندی‌شده، با قالبی که اسلاید اول آن شامل یک پخش‌کننده به نام `WindowsMediaPlayer1` است شروع کنید. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) کل اسلاید را به یک ارائه جدید کپی می‌کند. مثال مقدار `URL` پخش‌کننده را در [properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) تنظیم می‌کند و اسلاید کپی‌شده را به عنوان تنها اسلاید در خروجی ذخیره می‌نماید. ویدیو به صورت خارجی باقی می‌ماند، بنابراین مسیری را انتخاب کنید که پخش‌کننده در زمان پخش به آن دسترسی داشته باشد.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto source = MakeObject<Presentation>(u"template.pptx");
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slides()->AddClone(source->get_Slide(0));
auto controls = slide->get_Controls();

SharedPtr<IControl> player;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"WindowsMediaPlayer1")
    {
        player = control;
        break;
    }
}

if (!player || !player->get_Properties())
{
    Console::WriteLine(u"The template slide must contain a named media player with editable properties.");
    return;
}

player->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

presentation->get_Slides()->RemoveAt(0);
presentation->Save(u"linked-video.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند کنترل‌های ActiveX را بدون اجرا حفظ کند؟**

بله. Aspose.Slides می‌تواند کنترل‌ها را به همراه ویژگی‌ها و موقعیت‌هایشان بخواند و ذخیره کند، بدون اینکه آن‌ها را فعال کند.

**کنترل‌های ActiveX چه تفاوتی با اشیای OLE دارند؟**

کنترل‌های ActiveX به کاربران امکان تعامل با اسلاید را می‌دهند، برای مثال با وارد کردن متن یا کلیک کردن روی دکمه. یک [OLE object](/slides/fa/cpp/manage-ole/) به اسلاید اجازه می‌دهد محتوایی را که توسط برنامه دیگری مدیریت می‌شود، مانند یک صفحه‌کاری Excel، در خود داشته باشد یا به آن لینک دهد.

**آیا رویدادهای ActiveX پس از ذخیرهٔ یک ارائه با Aspose.Slides هنوز ماکروهای VBA را فعال می‌کنند؟**

ارائه را در قالبی که ماکرو فعال است مانند PPTM ذخیره کنید تا پروژه VBA آن حفظ شود. PowerPoint برای ویندوز می‌تواند هندلرهای رویداد موجود را اجرا کند زمانی که تنظیمات امنیتی اجازهٔ استفاده همزمان از کنترل‌های ActiveX و ماکروها را می‌دهند.
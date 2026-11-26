---
title: "إدارة عناصر تحكم ActiveX في العروض التقديمية باستخدام C++"
linktitle: "ActiveX"
type: docs
weight: 80
url: /ar/cpp/activex/
keywords:
- "ActiveX"
- "عنصر تحكم ActiveX"
- "إدارة ActiveX"
- "إضافة ActiveX"
- "تعديل ActiveX"
- "مشغل وسائط"
- "PowerPoint"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "تحرير صناديق نص وأزرار ActiveX، وتحديث معارض عناصر التحكم، وإعادة استخدام عنصر تحكم Windows Media Player في عروض PowerPoint التقديمية باستخدام Aspose.Slides for C++."
---
## **المقدمة**

تضيف عناصر تحكم ActiveX إلى شريحة PowerPoint عناصر تفاعلية مثل صناديق النص، أزرار الأوامر، ومشغلات الوسائط. يُظهر Aspose.Slides for C++ التحكمات في الشريحة عبر [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). استخدم هذه المجموعة لتعديل عنصر تحكم، تحريكه داخل الشريحة، أو إزالته.

## **قائمة عناصر تحكم ActiveX وخصائصها المخزنة**

لفحص قالب غير مألوف، افتحه للقراءة وتكرّر عبر عناصر التحكم في كل شريحة. يوضح المثال رقم الشريحة، اسم عنصر التحكم، [معرف الفئة](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/)، وكل زوج مفتاح‑قيمة في [الخصائص المخزنة](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). يقرأ العرض التقديمي دون تفعيل عناصر التحكم، أو استدعاء الأحداث أو الماكروهات، أو تغيير القيم، أو حفظ الملف.

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

يعرض الإخراج المختار من `ActiveX.pptm` صندوق نص وزر أمر.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

تظهر مجموعة الخصائص الفارغة كـ `[]`. بالنسبة للعناصر التي تستخدم التخزين الثنائي، قد تُعيد `get_Properties` قيمة `nullptr`، وتُعرض كـ `Properties unavailable`. إذا كنت بحاجة فقط إلى الأسماء، استخدم [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) بعد التحقق من وجود المجموعة. يسرد التقرير الخصائص المتاحة من العرض التقديمي. قد يدعم العنصر خصائص إضافية أثناء التشغيل.

## **تعديل عناصر تحكم ActiveX**

يفترض المثال عرضًا تقديميًا ممكّنًا للماكرو يحتوي على صندوق نص اسمه `TextBox1` وزر أمر اسمه `CommandButton1` في الشريحة الأولى. يستخدم [control properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) لتغيير قيمة صندوق النص وعنوان الزر. لكل عنصر تحكم معاينة ثابتة يمكن لـ PowerPoint عرضها قبل التفعيل. قدِّم صورة PNG لكل عنصر تحكم تُظهر النص والمظهر المحدث. يعيّن المثال هذه الصور عبر [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

يقوم المثال بتحريك كل عنصر تحكم في الشريحة الأولى إلى الأسفل بمقدار 100 نقطة عبر تغيير [الإطار](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/). يحفظ العرض التقديمي المعدل بصيغة PPTM، ثم يستخدم [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) لحفظ نسخة ثانية مع إزالة جميع عناصر تحكم ActiveX من تلك الشريحة.

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

## **إضافة عنصر تحكم مشغل وسائط ActiveX**

لإعادة استخدام عنصر تحكم Windows Media Player مُكوَّن مسبقًا، ابدأ بقالب تحتوي شريحته الأولى على مشغل اسمه `WindowsMediaPlayer1`. يقوم [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) بنسخ الشريحة بالكامل إلى عرض تقديمي جديد. يحدد المثال عنوان URL الخاص بالمشغل في [properties collection](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) ويحفظ الشريحة المستنسخة كالشريحة الوحيدة في الناتج. يبقى الفيديو خارجيًا، لذا اختر مسارًا يمكن للمشغل الوصول إليه أثناء التشغيل.

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

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides الحفاظ على عناصر تحكم ActiveX دون تشغيلها؟**

نعم. يمكن لـ Aspose.Slides قراءة وحفظ عناصر التحكم، بما في ذلك خصائصها ومواقعها، دون تفعيلها.

**كيف تختلف عناصر تحكم ActiveX عن كائنات OLE؟**

تسمح عناصر تحكم ActiveX للمستخدمين بالتفاعل مع الشريحة، مثلاً بإدخال نص أو النقر على زر. يتيح [OLE object](/slides/ar/cpp/manage-ole/) للشريحة أن تحتوي أو ترتبط بمحتوى تُديره تطبيقات أخرى، مثل ورقة عمل Excel.

**هل ستظل أحداث ActiveX تُطلق ماكروهات VBA بعد حفظ العرض التقديمي باستخدام Aspose.Slides؟**

احفظ العرض التقديمي بصيغة تمكين الماكرو مثل PPTM للاحتفاظ بمشروع VBA الخاص به. يمكن لـ PowerPoint لنظام Windows تشغيل معالجات الأحداث الموجودة عندما تسمح إعدادات الأمان بتفعيل كل من عناصر تحكم ActiveX والماكروهات.
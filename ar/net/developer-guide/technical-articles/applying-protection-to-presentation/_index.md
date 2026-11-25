---
title: تقييد تعديل العروض باستخدام أقفال الأشكال في .NET
linktitle: تقييد تعديل العرض
type: docs
weight: 70
url: /ar/net/applying-protection-to-presentation/
keywords:
- منع التعديلات
- الحماية من التحرير
- قفل الشكل
- قفل الموضع
- قفل التحديد
- قفل تغيير الحجم
- قفل التجميع
- PowerPoint
- PPTX
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for .NET لتقييد التحديد، الحركة، تغيير الحجم، والتجميع."
---
## **الخلفية**

يُعد الاستخدام الشائع لـ Aspose.Slides for .NET هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل آلي. عند استلام المستخدمين لهذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تُتيح لك هذه الأقفال تقييد عمليات التحرير المحددة على الأشكال الفردية.

## **تكوين الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for .NET، يتم تمثيل كل عنصر على الشريحة بواسطة كائن يُطبق واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) أو يرث من فئة تقوم بذلك.

تكشف أنواع الأشكال المختلفة عن خيارات قفل مختلفة. الواجهة [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) هي الواجهة الأساسية لأقفال الأشكال. يوفر Aspose.Slides for .NET الواجهات القفلية التالية:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) تقفل الأشكال التلقائية.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) تقفل أشكال الموصل.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) تقفل الكائنات الرسومية.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) تقفل الأشكال المجمعة.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) تقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، قم بالتكرار عبر الشرائح وضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تستخدم محررات العروض المتوافقة أقفال الأشكال لتقييد عمليات التحرير الفردية. تشفير الملف وحماية الكتابة على مستوى المستند هي إعدادات [إعدادات حماية العرض](/slides/ar/net/password-protected-presentation/) منفصلة.

### **تطبيق الحماية على أشكال PPTX**

يوفر Aspose.Slides for .NET الواجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) للعمل مع الأشكال على الشريحة.

يضبط المثال الخصائص [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), و[SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) إلى `true` للأشكال التلقائية، مع أقفال مكافئة لأشكال المجموعات، الموصلات، وإطارات الصور. تستخدم الموصلات [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) للحركة؛ وتستخدم المجموعات أيضًا [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) لتقييد التجميع.

يقوم المثال بتحميل عرض PPTX موجود، يتحقق من الأشكال في مجموعة الأشكال لكل شريحة، ويحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المعالجة دون تغيير. لا يتجول الحلقة عبر الأشكال الفرعية داخل مجموعة.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **إزالة الحماية**

لإزالة قفل الشكل، اضبط قيمته إلى `false`. يقوم المثال التالي بتحميل عرض يحتوي على أقفال الأشكال ويزيل قيود الاختيار والحركة وتغيير الحجم من خلال [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), و[IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). كما يزيل [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) ويحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **الحفاظ على قص الصورة**

ضع صورة باسم `photo.jpg` في دليل العمل. يقوم المثال بقص 12% من اليسار و8% من اليمين، ثم يضبط [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) على إطار الصورة. يقيّد هذا العلم قصًا إضافيًا ويحافظ على القص الحالي.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` يخزن قفل القص كـ `true`. في PowerPoint، أمر **Crop** معطل عندما يتم اختيار الصورة.

### **الحفاظ على تجميع المخطط**

يقوم المثال بتجميع مستطيل وسهم، ثم يضبط [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) على المجموعة نفسها للحفاظ على مكونات المخطط معًا. تظل التعديلات الأخرى، مثل نقل المجموعة أو تغيير تعبئة أحد المكونات، متاحة.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` يخزن قفل إلغاء التجميع كـ `true`. في PowerPoint، أمر **Ungroup** معطل عندما يتم اختيار المخطط بالكامل.

### **تقرير الأقفال الحالية للأشكال**

لمراجعة قالب، افتحه واقرأ كائن القفل لكل شكل. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) يكون `true` عندما تكون جميع العلامات على ذلك الكائن معطلة و `false` عندما يكون على الأقل واحدة مفعلة. للمجموعة وأطفالها كائنات قفل منفصلة، لذا افحص الأطفال حتى عندما لا تحتوي المجموعة على أقفال.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

افترض أن الشريحة 1 من `Sample.pptx` تحتوي على مجموعة باسم `Layout` مع قفل إلغاء التجميع، وصورة باسم `Photo` داخلها مع قفل القص، ومستطيل غير مقفل باسم `Free`. يتجاوز التقرير `Free` ويطبع السطرين التاليين:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

يقرأ التقرير العلامات المخزنة للتحرير على مستوى الشكل دون تغييرها أو حفظ العرض. حماية الكتابة على مستوى المستند هي إعداد منفصل، وتطبيق كل علامة يعتمد على المحرر.

### **الخلاصة**

يتيح لك Aspose.Slides for .NET تقييد عمليات تحرير محددة على الأشكال الفردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمها إلى `false` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة المتكررة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تقيد عمليات تحرير محددة، بينما [حماية كلمة المرور](/slides/ar/net/password-protected-presentation/) يمكن أن تقيد فتح أو تعديل العرض. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على الآخرين؟**

نعم. طبق الأقفال فقط على الأشكال في الشرائح المحددة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق الأقفال على الأشكال الفردية داخل مجموعة؟**

قم بالتكرار عبر مجموعة [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) وتطبيق الأقفال المناسبة على كل شكل فرعي. كرر ذلك لأي مجموعات داخلية، وفقًا للتنقل في مثال التقرير.
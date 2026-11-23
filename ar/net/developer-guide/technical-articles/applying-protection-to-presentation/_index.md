---
title: تقييد تحرير العروض باستخدام أقفال الأشكال في .NET
linktitle: تقييد تحرير العروض
type: docs
weight: 70
url: /ar/net/applying-protection-to-presentation/
keywords:
- منع التعديلات
- حماية من التحرير
- قفل الشكل
- قفل الموقع
- قفل الاختيار
- قفل تغيير الحجم
- قفل التجميع
- PowerPoint
- PPTX
- العرض
- .NET
- C#
- Aspose.Slides
description: تعلم كيفية قفل وفك قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for .NET لتقييد الاختيار والحركة وتغيير الحجم والتجميع.
---
## **الخلفية**

استخدام شائع لـ Aspose.Slides for .NET هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل مؤتمت. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تتيح لك هذه الأقفال تقييد عمليات التحرير المحددة على الأشكال الفردية.

## **تكوين الشريحة**

تتكون شريحة العرض من مكوّنات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمّعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for .NET، يُمثَّل كل عنصر على الشريحة بكائن يطبق واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) أو يرث من فئة تقوم بذلك.

تُظهر أنواع الأشكال المختلفة خيارات قفل مختلفة. الواجهة [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) هي الواجهة الأساسية لأقفال الأشكال. توفر Aspose.Slides for .NET الواجهات القفلية التالية:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) يقفل الأشكال التلقائية.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) يقفل أشكال الموصل.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) يقفل الكائنات الرسومية.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) يقفل الأشكال المجمعة.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، قم بالتكرار عبر شرائحه وضع الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تستخدم محررات العرض المتوافقة أقفال الأشكال لتقييد عمليات التحرير الفردية. تشفير الملف وحماية الكتابة على مستوى المستند هي إعدادات [إعدادات حماية العرض](/slides/ar/net/password-protected-presentation/) منفصلة.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for .NET الواجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) للعمل مع الأشكال على الشريحة.

تقوم العينة بتعيين [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)، [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) و[SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) إلى `true` للأشكال التلقائية، مع أقفال مكافئة لأشكال المجموعة، الموصلات، وإطارات الصور. تستخدم الموصلات [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) للحركة؛ وتستخدم المجموعات أيضًا [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) لتقييد التجميع.

تقوم العينة بتحميل عرض PPTX موجود، تتحقق من الأشكال في مجموعة الأشكال لكل شريحة، وتحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المعالجة دون تغيير. لا يتجول الحلقة داخل الأشكال الفرعية داخل مجموعة.

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

لإزالة قفل شكل، قم بضبط قيمته إلى `false`. تقوم العينة التالية بتحميل عرض يحتوي على أقفال أشكال وتزيل قيود التحديد، الحركة، وتغيير الحجم من خلال [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), و[IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). كما أنها تزيل [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) وتحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

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

### **حفظ قص الصورة**

ضع صورة باسم `photo.jpg` في دليل العمل. تقوم العينة بقص 12% من اليسار و8% من اليمين، ثم تعيّن [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) على إطار الصورة. تُقيد هذه العلامة القص الإضافي وتحفظ القص الحالي.

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

`PictureLocked.pptx` يُخزِّن قفل القص كـ `true`. في PowerPoint، أمر **Crop** مُعطَّل عندما يتم تحديد الصورة.

### **حفظ المخطط مجموعة**

تقوم العينة بتجميع مستطيل وسهم، ثم تعيّن [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) على المجموعة نفسها للحفاظ على مكوّنات المخطط معًا. التعديلات الأخرى، مثل نقل المجموعة أو تغيير تعبئة مكوّن، تظل متاحة.

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

`DiagramLocked.pptx` يُخزِّن قفل إلغاء التجميع كـ `true`. في PowerPoint، أمر **Ungroup** مُعطَّل عندما يتم تحديد المخطط بالكامل.

### **الاستنتاج**

تتيح لك Aspose.Slides for .NET تقييد عمليات التحرير المحددة على أشكال فردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمها إلى `false` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تقيد عمليات تحرير معينة، بينما [حماية كلمة المرور](/slides/ar/net/password-protected-presentation/) يمكنها تقييد فتح أو تعديل العرض. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على أخرى؟**

نعم. قم بتطبيق الأقفال فقط على الأشكال في الشرائح المختارة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق الأقفال على أشكال فردية داخل مجموعة؟**

قم بالتكرار عبر مجموعة [الأشكال](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) وتطبيق الأقفال المناسبة على كل شكل فرعي. كرّر ذلك لأي مجموعات متداخلة. العينات أعلاه تعالج فقط مجموعة أشكال الشريحة، لذا لا تقوم بتعيين أقفال على أعضاء المجموعة الفرديين.
---
title: منع تعديل العروض باستخدام أقفال الشكل في .NET
linktitle: منع تعديل العرض
type: docs
weight: 70
url: /ar/net/applying-protection-to-presentation/
keywords:
- منع التعديلات
- حماية من التعديل
- قفل الشكل
- قفل الموضع
- قفل الاختيار
- قفل الحجم
- قفل التجميع
- PowerPoint
- OpenDocument
- العرض
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides for .NET بقفل أو إلغاء قفل الأشكال في ملفات PPT و PPTX و ODP، مما يؤمن العروض مع السماح بتعديلات مُتحكم فيها."
---

## **الخلفية**

استخدام شائع لـ Aspose.Slides هو إنشاء وتحديث وحفظ عروض Microsoft PowerPoint (PPTX) كجزء من سير عمل آلي. يحصل مستخدمو التطبيقات التي تستخدم Aspose.Slides بهذه الطريقة على الوصول إلى العروض المولدة، لذا فإن حماية هذه العروض من التعديل تُعدّ مصدر قلق شائع. من المهم أن تحتفظ العروض التي تُنشأ تلقائيًا بالتنسيق والمحتوى الأصليين.

تشرح هذه المقالة كيفية هيكلة العروض والشرائح وكيف يمكن لـ Aspose.Slides for .NET تطبيق الحماية على عرض ثم إزالتها لاحقًا. إنها توفر للمطورين وسيلة للتحكم في كيفية استخدام العروض التي تولدها تطبيقاتهم.

## **تكوين الشريحة**

تتكون شريحة العرض من مكوّنات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for .NET، يُمثَّل كل عنصر على الشريحة بواسطة كائن يُطبق واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) أو يرث من فئة تقوم بذلك.

بنية PPTX معقدة، لذا على عكس PPT حيث يمكن استخدام قفل عام لجميع أنواع الأشكال، تتطلب أنواع الأشكال المختلفة أقفالًا مختلفة. تُعد واجهة [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) الفئة العامة للقفل في PPTX. الأنواع التالية من الأقفال مدعومة في Aspose.Slides for .NET لـ PPTX:
- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) أقفال الأشكال التلقائية.
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) أقفال أشكال الموصل.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) أقفال الكائنات الرسومية.
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) أقفال الأشكال المجمعة.
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) أقفال إطارات الصورة.

أي عمل يُجرى على جميع كائنات الشكل في كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) يُطبق على العرض بأكمله.

## **تطبيق وإزالة الحماية**

يضمن تطبيق الحماية عدم إمكانية تحرير العرض. إنها تقنية مفيدة لحماية محتوى العرض.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for .NET واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) للعمل مع الأشكال على الشريحة.

كما ذكرنا سابقًا، كل فئة شكل لها فئة قفل شكل مرتبطة لها للحماية. تركّز هذه المقالة على أقفال NoSelect و NoMove و NoResize. تضمن هذه الأقفال عدم إمكانية اختيار الأشكال (من خلال نقرات الفأرة أو طرق اختيار أخرى) وعدم إمكانية تحريكها أو تغيير حجمها.

عينة الشيفرة التالية تُطبق الحماية على جميع أنواع الأشكال في عرض.
```cs
// إنشاء كائن Presentation الذي يمثل ملف PPTX.
using Presentation presentation = new Presentation("Sample.pptx");

// التنقل عبر جميع الشرائح في العرض.
foreach (ISlide slide in presentation.Slides)
{
    // التنقل عبر جميع الأشكال في الشريحة.
    foreach (IShape shape in slide.Shapes)
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

// حفظ ملف العرض.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```


### **إزالة الحماية**

لفك قفل شكل، اضبط قيمة القفل المطبق إلى `false`. تُظهر عينة الشيفرة التالية كيفية فك قفل الأشكال في عرض مقفل.
```cs
// إنشاء كائن Presentation الذي يمثل ملف PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// التنقل عبر جميع الشرائح في العرض.
foreach (ISlide slide in presentation.Slides)
{
    // التنقل عبر جميع الأشكال في الشريحة.
    foreach (IShape shape in slide.Shapes)
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

// حفظ ملف العرض.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```


### **الخلاصة**

توفر Aspose.Slides عدة خيارات لحماية الأشكال في عرض. يمكنك قفل شكل فردي أو تكرار جميع الأشكال في العرض وقفل كلٍ منها لتأمين الملف بالكامل بفعالية. يمكنك إزالة الحماية بضبط قيمة القفل إلى `false`.

## **الأسئلة المتكررة**

**هل يمكنني دمج أقفال الشكل وحماية كلمة المرور في نفس العرض؟**

نعم. تُقيد الأقفال تحرير الكائنات داخل الملف، بينما [حماية كلمة المرور](/slides/ar/net/password-protected-presentation/) يتحكم في الوصول إلى فتح العرض و/أو حفظ التغييرات. تكمل هذه الآليات بعضها البعض وتعمل معًا.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على غيرها؟**

نعم. يُطبق الأقفال على الأشكال في الشرائح المحددة؛ الشرائح المتبقية ستظل قابلة للتحرير.

**هل تنطبق أقفال الأشكال على الكائنات المجمعة والموصلات؟**

نعم. تُدعم أنواع أقفال مخصصة للمجموعات والموصلات والكائنات الرسومية وأنواع الأشكال الأخرى.
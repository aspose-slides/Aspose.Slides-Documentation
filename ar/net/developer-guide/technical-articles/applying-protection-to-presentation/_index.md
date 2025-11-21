---
title: منع تعديلات العرض التقديمي باستخدام أقفال الأشكال
linktitle: منع تعديلات العرض التقديمي
type: docs
weight: 70
url: /ar/net/applying-protection-to-presentation/
keywords:
- منع التعديلات
- حماية من التحرير
- قفل الشكل
- قفل الموقع
- قفل التحديد
- قفل الحجم
- قفل التجميع
- PowerPoint
- OpenDocument
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides for .NET بقفل أو فك قفل الأشكال في ملفات PPT و PPTX و ODP، مما يؤمن العروض التقديمية مع السماح بالتعديلات المتحكم فيها وتسليم أسرع."
---

## **الخلفية**

استخدام شائع لـ Aspose.Slides هو إنشاء وتحديث وحفظ عروض Microsoft PowerPoint (PPTX) كجزء من سير عمل تلقائي. يحصل مستخدمو التطبيقات التي تستخدم Aspose.Slides بهذه الطريقة على العروض المولدة، لذا فإن حمايتها من التحرير هو قلق شائع. من المهم أن تحتفظ العروض التي تم إنشاؤها تلقائيًا بالتنسيق والمحتوى الأصليين.

تشرح هذه المقالة كيف تُبنى العروض والشرائح وكيف يمكن لـ Aspose.Slides for .NET تطبيق الحماية على عرض تقديمي وإزالتها لاحقًا. وهي توفر للمطورين وسيلة للتحكم في كيفية استخدام العروض التي تُنشئها تطبيقاتهم.

## **تركيب الشريحة**

تتكون شريحة العرض من مكوّنات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for .NET، يُمثَّل كل عنصر في الشريحة ككائن يطبق واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) أو يرث من فئة تقوم بذلك.

بنية PPTX معقدة، لذا على عكس PPT حيث يمكن استخدام قفل عام لجميع أنواع الأشكال، تتطلب أنواع الأشكال المختلفة أقفالًا مختلفة. واجهة [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) هي الفئة العامة للقفل في PPTX. الأنواع التالية من الأقفال مدعومة في Aspose.Slides for .NET لـ PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) يقفل الأشكال التلقائية.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) يقفل أشكال الموصل.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) يقفل الكائنات الرسومية.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) يقفل أشكال المجموعات.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) يقفل إطارات الصورة.  

أي إجراء يُجرى على جميع كائنات الأشكال في كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) يُطبق على العرض بالكامل.

## **تطبيق وإزالة الحماية**

تطبيق الحماية يضمن عدم إمكانية تحرير العرض. إنها تقنية مفيدة لحماية محتوى العرض.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for .NET واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) للعمل مع الأشكال في الشريحة.

كما ذكرنا سابقًا، كل فئة شكل لها فئة قفل شكل مرتبطة للحماية. تركز هذه المقالة على أقفال NoSelect و NoMove و NoResize. تضمن هذه الأقفال عدم إمكانية اختيار الأشكال (عن طريق النقرات أو طرق اختيار أخرى) وعدم إمكانية تحريكها أو تغيير حجمها.

العينة البرمجية التالية تطبق الحماية على جميع أنواع الأشكال في عرض تقديمي.
```cs
// إنشاء كائن Presentation الذي يمثل ملف PPTX.
using Presentation presentation = new Presentation("Sample.pptx");

// استعراض جميع الشرائح في العرض.
foreach (ISlide slide in presentation.Slides)
{
    // استعراض جميع الأشكال في الشريحة.
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

لفك قفل شكل، اضبط قيمة القفل المطبق على `false`. تُظهر العينة البرمجية التالية كيفية فك أقفال الأشكال في عرض مؤمّن.
```cs
// إنشاء كائن Presentation الذي يمثل ملف PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// استعراض جميع الشرائح في العرض.
foreach (ISlide slide in presentation.Slides)
{
    // استعراض جميع الأشكال في الشريحة.
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

يقدّم Aspose.Slides عدة خيارات لحماية الأشكال في العرض. يمكنك قفل شكل فردي أو التجول عبر جميع الأشكال في عرض وتطبيق القفل على كل واحدة لتأمين الملف بالكامل بفعالية. يمكنك إزالة الحماية بضبط قيمة القفل إلى `false`.

## **الأسئلة الشائعة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض التقديمي؟**

نعم. الأقفال تقيد تحرير الكائنات داخل الملف، بينما [password protection](/slides/ar/net/password-protected-presentation/) تتحكم في الوصول إلى فتح الملف و/أو حفظ التغييرات. هذان الآليتان تكملان بعضهما وتعملان معًا.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على الأخرى؟**

نعم. طبق الأقفال على الأشكال في الشرائح المحددة؛ ستبقى الشرائح المتبقية قابلة للتحرير.

**هل تنطبق أقفال الأشكال على الكائنات المجمعة والموصلات؟**

نعم. هناك أنواع أقفال مخصصة للمجموعات، الموصلات، الكائنات الرسومية، وأنواع الأشكال الأخرى.
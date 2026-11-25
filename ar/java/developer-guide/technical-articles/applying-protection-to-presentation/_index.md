---
title: تقييد تعديل العروض باستخدام أقفال الشكل في Java
linktitle: تقييد تعديل العرض
type: docs
weight: 60
url: /ar/java/applying-protection-to-presentation/
keywords:
- منع التحرير
- حماية من التعديل
- قفل الشكل
- قفل الموضع
- قفل الاختيار
- قفل تغيير الحجم
- قفل التجميع
- PowerPoint
- PPTX
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for Java لتقييد التحديد، التحريك، تغيير الحجم، والتجميع."
---
## **الخلفية**

استخدام شائع لـ Aspose.Slides for Java هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل مؤتمت. عندما يتلقى المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

توضح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تُتيح لك هذه الأقفال تقييد عمليات تحرير محددة على الأشكال الفردية.

## **تكوين الشريحة**

تتكون شريحة العرض من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لإنشاء عرض تقديمي. في Aspose.Slides for Java، يُمثّل كل عنصر على الشريحة ككائن يُطبق واجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) أو يرث من فئة تقوم بذلك.

تُظهر أنواع الأشكال المختلفة خيارات قفل مختلفة. واجهة [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) هي الواجهة الأساسية لأقفال الأشكال. توفر Aspose.Slides for Java الواجهات القفلية التالية:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) يقفل الأشكال التلقائية.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) يقفل أشكال الموصل.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) يقفل الكائنات الرسومية.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) يقفل الأشكال المجمعة.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) يقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)، قم بالتكرار عبر شرائحه واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تستخدم محررات العروض المتوافقة أقفال الأشكال لتقييد عمليات التحرير الفردية. تشفير الملفات وحماية الكتابة على مستوى المستند هي إعدادات [إعدادات حماية العرض](/slides/ar/java/password-protected-presentation/) منفصلة.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for Java واجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) للعمل مع الأشكال على الشريحة.

يستدعي المثال [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-) و[setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) و[setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) بالقيمة `true` للأشكال التلقائية، مع أقفال مكافئة لأشكال المجموعات، الموصلات، وإطارات الصور. تستخدم الموصلات [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) للتحريك؛ وتستخدم المجموعات أيضًا [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) لتقييد التجميع.

يقوم المثال بتحميل عرض PPTX موجود، يتحقق من الأشكال في مجموعة الأشكال لكل شريحة، ويحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال التي لا تنتمي إلى الأنواع الأربعة المعالجة دون تغيير. لا يتجول الحلقة عبر الأشكال الفرعية داخل مجموعة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **إزالة الحماية**

لإزالة قفل الشكل، اضبط قيمته على `false`. يقوم المثال التالي بتحميل عرض يحتوي على أقفال الأشكال ويزيل قيود التحديد، والتحريك، وتغيير الحجم عبر [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) و[IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) و[IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) و[IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). كما يُزيل قيود التجميع بتمرير `false` إلى [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) ويحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **الحفاظ على قص الصورة**

ضع صورة باسم `photo.jpg` في دليل العمل. يقوم المثال بقص 12% من اليسار و8% من اليمين، ثم يستدعي [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) على قفل إطار الصورة. تمرير `true` يقيد المزيد من القص ويحافظ على القص الحالي.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` يخزن قفل القص كـ `true`. في PowerPoint، يتم تعطيل أمر **Crop** عندما يتم اختيار الصورة.

### **إبقاء المخطط مجمعًا**

يقوم المثال بتجميع مستطيل وسهم، ثم يستدعي [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) على قفل المجموعة للحفاظ على مكونات المخطط معًا. تظل عمليات التحرير الأخرى، مثل تحريك المجموعة أو تغيير تعبئة مكون، متاحة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` يخزن قفل فك التجميع كـ `true`. في PowerPoint، يتم تعطيل أمر **Ungroup** عندما يتم اختيار المخطط بأكمله.

### **تقرير أقفال الأشكال الموجودة**

لمراجعة قالب، افتحه واقرأ كائن القفل لكل شكل. تُرجع طريقة [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) القيمة `true` عندما تكون جميع العلامات على ذلك الكائن معطلة و`false` عندما يتم تمكين واحدة على الأقل. للمجموعة وأبنائها كائنات قفل منفصلة، لذا يجب فحص الأبناء حتى إذا لم تتضمن المجموعة أقفالاً.

يتحقق هذا المثال من التحريك للأشكال التلقائية، وإطارات الصور، والمجموعات. كما يتحقق من القص للصور وفك التجميع للمجموعات. يسرد التقرير العلامات المُمكّنة التي يتعرف عليها ويُشير إلى أنواع الأشكال التي لا يتم فحصها.

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

افترض أن الشريحة 1 من `Sample.pptx` تحتوي على مجموعة اسمها `Layout` مع قفل فك التجميع، وصورة اسمها `Photo` داخلها مع قفل القص، ومستطيل غير مقفل اسمه `Free`. يتجاوز التقرير `Free` ويطبع هذين السطرين:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

يقرأ التقرير العلامات التحريرية المخزنة على مستوى الشكل دون تغييرها أو حفظ العرض. حماية الكتابة على مستوى المستند هي إعداد منفصل، وتعتمد تنفيذ كل علامة على المحرر.

## **الخلاصة**

تتيح لك Aspose.Slides for Java تقييد عمليات تحرير محددة على الأشكال الفردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من قبل كل نوع شكل، واضبط قيمها على `false` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني الجمع بين أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تقيد عمليات تحرير محددة، بينما [حماية كلمة المرور](/slides/ar/java/password-protected-presentation/) يمكن أن تقيد فتح أو تعديل العرض. يمكنك استخدام كلاهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على الأخرى؟**

نعم. قم بتطبيق الأقفال فقط على الأشكال في الشرائح المحددة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق الأقفال على الأشكال الفردية داخل مجموعة؟**

قم بالتكرار عبر المجموعة التي تُرجعها طريقة [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) للمجموعة وطبّق الأقفال المناسبة على كل شكل فرعي. كرّر ذلك لأي مجموعات متداخلة، متبعًا عملية المرور في مثال التقرير.
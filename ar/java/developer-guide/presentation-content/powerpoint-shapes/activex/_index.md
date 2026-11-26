---
title: إدارة عناصر التحكم ActiveX في العروض التقديمية باستخدام Java
linktitle: ActiveX
type: docs
weight: 80
url: /ar/java/activex/
keywords:
- ActiveX
- عنصر التحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغل وسائط
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: تحرير صناديق النص وأزرار ActiveX، تحديث معاينات عناصر التحكم، وإعادة استخدام عنصر تحكم Windows Media Player في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Java.
---
## **المقدمة**

تمنح عناصر التحكم ActiveX الشريحة في PowerPoint عناصر تفاعلية مثل صناديق النص وأزرار الأوامر ومشغلات الوسائط. يتيح Aspose.Slides for Java الوصول إلى عناصر التحكم في الشريحة عبر [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). استخدم هذه المجموعة لتحرير عنصر تحكم أو تحريكه على الشريحة أو إزالته.

## **قائمة عناصر التحكم ActiveX وخصائصها المخزنة**

لفحص قالب غير مألوف، افتح الملف للقراءة وتكرر عبر عناصر التحكم في كل شريحة. يوضح المثال رقم الشريحة، اسم عنصر التحكم، [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--)، وكل زوج مفتاح‑قيمة في [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). يقرأ العرض التقديمي دون تنشيط العناصر، أو استدعاء الأحداث أو الماكروهات، أو تغيير القيم، أو حفظ الملف.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

يعرض النتيجة المختارة من `ActiveX.pptm` صندوق نص وزر أمر.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

يظهر مجموعة الخصائص الفارغة كـ `[]`. بالنسبة للعناصر التي تستخدم تخزينًا ثنائيًا، قد تُعيد [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) القيمة `null`، والتي تُعرض كـ `Properties unavailable`. إذا كنت تحتاج فقط إلى الأسماء، استخدم [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) بعد فحص القيمة `null`. يسرد التقرير الخصائص المتاحة من العرض التقديمي. قد يدعم العنصر خصائص إضافية أثناء التشغيل.

## **تعديل عناصر التحكم ActiveX**

يتوقع المثال عرضًا تمكينًا للماكرو يحتوي على صندوق نص اسمه `TextBox1` وزر أمر اسمه `CommandButton1` في الشريحة الأولى. يستخدم [مجموعة خصائص التحكم](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) لتغيير قيمة صندوق النص وعنوان الزر. لكل عنصر تحكم معاينة ثابتة يمكن لبرنامج PowerPoint عرضها قبل التنشيط. زوّد كل عنصر بصورة PNG تُظهر النص والمظهر المحدث. يعيّن المثال هذه الصور عبر [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

ينقل المثال كل عنصر تحكم في الشريحة الأولى إلى الأسفل بمقدار 100 نقطة عن طريق ضبط إطاره باستخدام [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). يحفظ العرض المعدل بصيغة PPTM، ثم يستخدم [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) لحفظ نسخة ثانية تُزيل جميع عناصر التحكم ActiveX من تلك الشريحة.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **إضافة عنصر تحكم مشغل وسائط ActiveX**

لإعادة استخدام عنصر تحكم Windows Media Player مُكوَّن مسبقًا، ابدأ بقالب تحتوي شريحته الأولى على مشغل باسم `WindowsMediaPlayer1`. تنسخ الدالة [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) الشريحة كاملة إلى عرض تقديمي جديد. يضبط المثال خاصية `URL` للمشغل في [مجموعة خصائصه](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) ويحفظ الشريحة المستنسخة كشريحة وحيدة في الناتج. يبقى الفيديو خارجيًا، لذا اختر مسارًا يمكن للمشغل الوصول إليه أثناء التشغيل.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides الحفاظ على عناصر التحكم ActiveX دون تشغيلها؟**

نعم. يمكن لـ Aspose.Slides قراءة وحفظ عناصر التحكم، بما في ذلك خصائصها ومواقعها، دون تنشيطها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE؟**

تتيح عناصر التحكم ActiveX للمستخدمين التفاعل مع الشريحة، على سبيل المثال بإدخال نص أو النقر على زر. يُتيح [كائن OLE](/slides/ar/java/manage-ole/) للشريحة احتواء أو ربط محتوى تديره تطبيقات أخرى، مثل ورقة عمل Excel.

**هل ستستمر أحداث ActiveX في تشغيل ماكروات VBA بعد أن أحفظ العرض التقديمي باستخدام Aspose.Slides؟**

احفظ العرض التقديمي بصيغة تمكين الماكرو مثل PPTM للاحتفاظ بمشروع VBA الخاص به. يمكن لبرنامج PowerPoint لنظام Windows تشغيل معالجات الأحداث الموجودة عندما تسمح إعدادات الأمان بتشغيل كل من عناصر التحكم ActiveX والماكروهات.
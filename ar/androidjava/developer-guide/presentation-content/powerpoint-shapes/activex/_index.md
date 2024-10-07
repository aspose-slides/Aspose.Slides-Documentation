---
title: ActiveX
type: docs
weight: 80
url: /androidjava/activex/
---


{{% alert color="primary" %}} 

تُستخدم عناصر ActiveX في العروض التقديمية. تسمح لك Aspose.Slides لـ Android عبر Java بإضافة وإدارة عناصر ActiveX، لكنها تتطلب بعض المهارة في الإدارة مقارنةً بأشكال العرض التقديمية العادية. لقد قمنا بتنفيذ دعم لإضافة عنصر التحكم في مشغل الوسائط Active في Aspose.Slides. لاحظ أن عناصر ActiveX ليست أشكالًا؛ بل هي جزء من [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection) المنفصلة بدلاً من [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IShapeCollection). في هذا الموضوع، سنوضح لك كيفية العمل معها.

{{% /alert %}} 

## **إضافة عنصر التحكم في مشغل الوسائط ActiveX إلى الشريحة**
لإضافة عنصر تحكم ActiveX لمشغل الوسائط، قم بما يلي:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وإنشاء مثال تقديم فارغ.
1. الوصول إلى الشريحة المستهدفة في [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. إضافة عنصر التحكم ActiveX لمشغل الوسائط باستخدام طريقة [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) المعروضة بواسطة [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).
1. الوصول إلى عنصر التحكم ActiveX لمشغل الوسائط وتعيين مسار الفيديو باستخدام خصائصه.
1. حفظ العرض التقديمي كملف PPTX.

تظهر عينة التعليمات البرمجية هذه، بناءً على الخطوات أعلاه، كيفية إضافة عنصر التحكم ActiveX لمشغل الوسائط إلى الشريحة:

```java
// إنشاء مثيل تقديم فارغ
Presentation pres = new Presentation();
try {
    // إضافة عنصر التحكم ActiveX لمشغل الوسائط
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // الوصول إلى عنصر التحكم ActiveX لمشغل الوسائط وتعيين مسار الفيديو
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // حفظ العرض التقديمي
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ت modifier عنصر التحكم ActiveX**
{{% alert color="primary" %}} 

تم تجهيز Aspose.Slides لـ Android عبر Java 7.1.0 والإصدارات الأحدث بمكونات لإدارة عناصر التحكم ActiveX. يمكنك الوصول إلى عنصر التحكم ActiveX المضاف بالفعل في عرضك التقديمي وتعديله أو حذفه من خلال خصائصه.

{{% /alert %}} 

لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة، قم بما يلي:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وتحميل العرض التقديمي مع عناصر التحكم ActiveX فيه.
1. الحصول على مرجع الشريحة حسب فهرسها.
1. الوصول إلى عناصر التحكم ActiveX في الشريحة من خلال الوصول إلى [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).
1. الوصول إلى عنصر التحكم ActiveX TextBox1 باستخدام كائن [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControl).
1. تغيير خصائص عنصر التحكم ActiveX TextBox1 التي تشمل النص، الخط، ارتفاع الخط، وموقع الإطار.
1. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.
1. تغيير عنوان الزر، الخط، والموقع.
1. نقل موقع إطارات عناصر التحكم ActiveX.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

تظهر عينة التعليمات البرمجية هذه، بناءً على الخطوات أعلاه، كيفية إدارة عنصر تحكم ActiveX بسيط: 

```java
// الوصول إلى العرض التقديمي مع عناصر التحكم ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // الوصول إلى الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // تغيير نص TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "تم تغيير النص";
        control.getProperties().set_Item("Value", newText);

        // تغيير الصورة البديلة. سيقوم PowerPoint باستبدال هذه الصورة أثناء تفعيل ActiveX،
        // لذلك في بعض الأحيان من الجيد ترك الصورة دون تغيير.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // تغيير عنوان الزر
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "عرض رسالة";
        control.getProperties().set_Item("Caption", newCaption);
        // تغيير الصورة البديلة
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // التحرك 100 نقطة للأسفل
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // إزالة العناصر
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
---
title: ActiveX
type: docs
weight: 80
url: /ar/java/activex/
---


{{% alert color="primary" %}} 

تستخدم عناصر التحكم ActiveX في العروض التقديمية. يسمح لك Aspose.Slides لـ Java بإضافة وإدارة عناصر التحكم ActiveX، لكنها أصعب قليلاً في الإدارة مقارنة مع أشكال العروض التقديمية العادية. قمنا بتنفيذ دعم لإضافة عنصر التحكم النشط Media Player في Aspose.Slides. لاحظ أن عناصر التحكم ActiveX ليست أشكالًا؛ فهي ليست جزءًا من [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IShapeCollection) للعروض التقديمية. إنها جزء من [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection) المنفصلة بدلاً من ذلك. في هذا الموضوع، سنوضح لك كيفية العمل معها. 

{{% /alert %}} 

## **إضافة عنصر التحكم ActiveX لـ Media Player إلى الشريحة**
لإضافة عنصر التحكم ActiveX الخاص بـ Media Player، قم بذلك:

1. أنشئ مثيلًا من فصل [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) وقم بإنشاء مثيل عرض تقديمي فارغ.
1. الوصول إلى الشريحة المستهدفة في [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. إضافة عنصر التحكم ActiveX الخاص بـ Media Player باستخدام طريقة [addControl](https://reference.aspose.com/slides/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) المعروضة بواسطة [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection).
1. الوصول إلى عنصر التحكم ActiveX الخاص بـ Media Player وتعيين مسار الفيديو باستخدام خصائصه.
1. حفظ العرض التقديمي كملف PPTX.

يوضح هذا الكود العينة، المستند إلى الخطوات أعلاه، كيفية إضافة عنصر التحكم ActiveX الخاص بـ Media Player إلى شريحة:

```java
// إنشاء مثيل عرض تقديمي فارغ
Presentation pres = new Presentation();
try {
    // إضافة عنصر التحكم ActiveX الخاص بـ Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // الوصول إلى عنصر التحكم ActiveX الخاص بـ Media Player وتعيين مسار الفيديو
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // حفظ العرض التقديمي
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعديل عنصر التحكم ActiveX**
{{% alert color="primary" %}} 

تحتوي نسخ Aspose.Slides لـ Java 7.1.0 والإصدارات الأحدث على مكونات لإدارة عناصر التحكم ActiveX. يمكنك الوصول إلى عنصر التحكم ActiveX المضاف بالفعل في العرض التقديمي الخاص بك وتعديله أو حذفه من خلال خصائصه.

{{% /alert %}} 

لإدارة عنصر تحكم ActiveX بسيط مثل مربع النص وزر الأمر البسيط في شريحة، قم بذلك:

1. أنشئ مثيلًا من فصل [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) وقم بتحميل العرض التقديمي مع عناصر التحكم ActiveX فيه.
1. احصل على مرجع الشريحة من خلال فهرسها.
1. الوصول إلى عناصر التحكم ActiveX في الشريحة من خلال الوصول إلى [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection).
1. الوصول إلى عنصر التحكم TextBox1 ActiveX باستخدام كائن [IControl](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControl).
1. تغيير خصائص عنصر التحكم TextBox1 ActiveX التي تشمل النص، الخط، ارتفاع الخط، وموقع الإطار.
1. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.
1. تغيير عنوان الزر، الخط، والموقع.
1. نقل موضع إطارات عناصر التحكم ActiveX.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

يوضح هذا الكود العينة، المستند إلى الخطوات أعلاه، كيفية إدارة عنصر التحكم ActiveX بسيط:

```java
// الوصول إلى العرض التقديمي مع عناصر التحكم ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // الوصول إلى الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // تغيير نص TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "النص المعدل";
        control.getProperties().set_Item("Value", newText);

        // تغيير الصورة البديلة. ستقوم PowerPoint باستبدال هذه الصورة أثناء تنشيط ActiveX،
        // لذلك في بعض الأحيان من المقبول ترك الصورة دون تغيير.
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
        String newCaption = "إظهار رسالة";
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

    // نقل 100 نقطة لأسفل
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
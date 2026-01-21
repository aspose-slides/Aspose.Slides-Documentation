---
title: إدارة عناصر التحكم ActiveX في العروض التقديمية باستخدام Java
linktitle: ActiveX
type: docs
weight: 80
url: /ar/java/activex/
keywords:
- ActiveX
- التحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغل وسائط
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرف على كيفية استفادة Aspose.Slides for Java من ActiveX لأتمتة وتحسين عروض PowerPoint التقديمية، مما يمنح المطورين تحكمًا قويًا في الشرائح."
---

{{% alert color="primary" %}} 
تُستخدم عناصر التحكم ActiveX في العروض التقديمية. يتيح لك Aspose.Slides for Java إضافة وإدارة عناصر التحكم ActiveX، لكنها تكون أكثر صعوبة في الإدارة مقارنة بأشكال العرض العادية. لقد نفذنا دعم إضافة عنصر التحكم النشط Media Player في Aspose.Slides. لاحظ أن عناصر التحكم ActiveX ليست أشكالًا؛ فهي ليست جزءًا من العرض التقديمي [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/). بل هي جزء من [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/) المنفصل بدلاً من ذلك. في هذا الموضوع، سنظهر لك كيفية العمل معها. 
{{% /alert %}} 

## **إضافة عنصر تحكم Media Player ActiveX إلى شريحة**
لإضافة عنصر تحكم Media Player ActiveX، قم بالآتي:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) وإنشاء نسخة فارغة من العرض التقديمي.  
2. الوصول إلى الشريحة المستهدفة في [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).  
3. إضافة عنصر تحكم Media Player ActiveX باستخدام الطريقة [addControl](https://reference.aspose.com/slides/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) المعروضة في [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/).  
4. الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.  
5. حفظ العرض التقديمي كملف PPTX.  

يعرض هذا المثال البرمجي، استنادًا إلى الخطوات السابقة، كيفية إضافة عنصر تحكم Media Player ActiveX إلى شريحة:
```java
// إنشاء نسخة عرض تقديمي فارغة
Presentation pres = new Presentation();
try {
    // إضافة عنصر تحكم Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // حفظ العرض التقديمي
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعديل عنصر تحكم ActiveX**
{{% alert color="primary" %}} 
يتضمن Aspose.Slides for Java 7.1.0 والإصدارات الأحدث مكونات لإدارة عناصر التحكم ActiveX. يمكنك الوصول إلى عنصر التحكم ActiveX المضاف بالفعل في عرضك التقديمي وتعديله أو حذفه عبر خصائصه. 
{{% /alert %}} 

لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة، قم بالآتي:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على عناصر تحكم ActiveX.  
2. الحصول على مرجع للشريحة عبر فهرسها.  
3. الوصول إلى عناصر تحكم ActiveX في الشريحة عبر الوصول إلى [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/).  
4. الوصول إلى عنصر تحكم ActiveX TextBox1 باستخدام كائن [IControl](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/).  
5. تغيير خصائص عنصر تحكم ActiveX TextBox1 التي تشمل النص، الخط، ارتفاع الخط، وموقع الإطار.  
6. الوصول إلى التحكم الثاني المسمى CommandButton1.  
7. تغيير عنوان الزر، الخط، والموقع.  
8. تحريك موقع أطر عناصر تحكم ActiveX.  
9. كتابة العرض التقديمي المعدل إلى ملف PPTX.  

يعرض هذا المثال البرمجي، استنادًا إلى الخطوات السابقة، كيفية إدارة عنصر تحكم ActiveX بسيط: 
```java
// الوصول إلى العرض التقديمي مع عناصر التحكم ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // الوصول إلى الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // تغيير نص مربع النص
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // تغيير صورة الاستبدال. سيستبدل PowerPoint هذه الصورة أثناء تفعيل ActiveX،
        // لذا قد يكون من المقبول ترك الصورة دون تغيير في بعض الأحيان.
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

    // تغيير تسمية الزر
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // تغيير الاستبدال
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

    // تحريك الأسفل 100 نقطة
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // إزالة العناصر التحكم
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يحافظ Aspose.Slides على عناصر تحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يمكن تنفيذها في بيئة تشغيل Java؟**

نعم. يعتبر Aspose.Slides هذه العناصر جزءًا من العرض التقديمي ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يتطلب حفظها تنفيذ عناصر التحكم نفسها.

**كيف تختلف عناصر تحكم ActiveX عن كائنات OLE في العرض التقديمي؟**

عناصر تحكم ActiveX هي عناصر تحكم تفاعلية مُدارة (أزرار، مربعات نص، مشغل وسائط)، بينما يشير [OLE](/slides/ar/java/manage-ole/) إلى كائنات تطبيق مدمجة (مثلاً ورقة عمل Excel). يتم تخزينها ومعالجتها بطريقة مختلفة وتملك نماذج خصائص مختلفة.

**هل تعمل أحداث ActiveX وماكرو VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**

يحافظ Aspose.Slides على العلامات والبيانات الوصفية الموجودة؛ ومع ذلك، تعمل الأحداث وماكرو VBA فقط داخل PowerPoint على Windows عندما تسمح الأمان بذلك. المكتبة لا تقوم بتنفيذ VBA.
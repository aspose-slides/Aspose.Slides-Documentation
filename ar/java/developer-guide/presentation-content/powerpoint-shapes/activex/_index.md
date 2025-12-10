---
title: "إدارة عناصر التحكم ActiveX في العروض التقديمية باستخدام Java"
linktitle: "ActiveX"
type: docs
weight: 80
url: /ar/java/activex/
keywords:
- "ActiveX"
- "عنصر التحكم ActiveX"
- "إدارة ActiveX"
- "إضافة ActiveX"
- "تعديل ActiveX"
- "مشغل وسائط"
- "PowerPoint"
- "عرض تقديمي"
- "Java"
- "Aspose.Slides"
description: "تعرّف على كيف يستخدم Aspose.Slides for Java تقنية ActiveX لأتمتة وتحسين عروض PowerPoint، مما يمنح المطورين تحكمًا قويًا في الشرائح."
---

{{% alert color="primary" %}} 
يتم استخدام عناصر التحكم ActiveX في العروض التقديمية. يتيح لك Aspose.Slides for Java إضافة وإدارة عناصر التحكم ActiveX، لكنها أصعب قليلاً في الإدارة مقارنةً بأشكال العرض العادية. قمنا بتنفيذ دعم لإضافة عنصر تحكم Media Player Active في Aspose.Slides. لاحظ أن عناصر التحكم ActiveX ليست أشكالًا؛ فهي ليست جزءًا من العرض التقديمي’s [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IShapeCollection). إنها جزء من [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection) المنفصل بدلاً من ذلك. في هذا الموضوع، سنوضح لك كيفية العمل معها. 
{{% /alert %}} 

## **إضافة عنصر تحكم Media Player ActiveX إلى شريحة**
لإضافة عنصر تحكم Media Player ActiveX، افعل ذلك:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) وإنشاء عرض تقديمي فارغ.
2. الوصول إلى الشريحة المستهدفة في [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
3. إضافة عنصر تحكم Media Player ActiveX باستخدام طريقة [addControl](https://reference.aspose.com/slides/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) التي توفرها [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection).
4. الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.
5. حفظ العرض التقديمي كملف PPTX.

يعرض رمز العينة هذا، استنادًا إلى الخطوات أعلاه، كيفية إضافة عنصر تحكم Media Player ActiveX إلى شريحة:
```java
// إنشاء مثال عرض تقديمي فارغ
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
يتم تزويد Aspose.Slides for Java 7.1.0 والإصدارات الأحدث بمكونات لإدارة عناصر التحكم ActiveX. يمكنك الوصول إلى عنصر التحكم ActiveX المضاف بالفعل في عرضك التقديمي وتعديله أو حذفه عبر خصائصه.
{{% /alert %}} 

لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة، افعل ذلك:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على عناصر تحكم ActiveX.
2. الحصول على مرجع الشريحة بواسطة الفهرس الخاص بها.
3. الوصول إلى عناصر التحكم ActiveX في الشريحة عبر الوصول إلى [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection).
4. الوصول إلى عنصر التحكم ActiveX TextBox1 باستخدام كائن [IControl](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControl).
5. تغيير خصائص عنصر التحكم ActiveX TextBox1 التي تشمل النص، الخط، ارتفاع الخط، وموقع الإطار.
6. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.
7. تغيير تسمية الزر، الخط، والموقع.
8. تحريك موقع إطارات عناصر التحكم ActiveX.
9. كتابة العرض التقديمي المعدل إلى ملف PPTX.

يعرض رمز العينة هذا، استنادًا إلى الخطوات أعلاه، كيفية إدارة عنصر تحكم ActiveX بسيط: 
```java
// الوصول إلى العرض التقديمي مع عناصر تحكم ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // الوصول إلى الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // تغيير نص مربع النص
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // تغيير صورة الاستبدال. سيستبدل PowerPoint هذه الصورة أثناء تنشيط ActiveX،
        // لذلك في بعض الأحيان يكون من المقبول ترك الصورة دون تغيير.
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

    // نقل 100 نقطة للأسفل
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



## **الأسئلة المتكررة**

**هل يحافظ Aspose.Slides على عناصر تحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يمكن تنفيذها في بيئة تشغيل Java؟**  
نعم. يعتبر Aspose.Slides أنها جزء من العرض التقديمي ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يلزم تنفيذ العناصر نفسها للحفاظ عليها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE في العرض التقديمي؟**  
عناصر التحكم ActiveX هي عناصر تفاعلية مُدارة (أزرار، مربعات نص، مشغل وسائط)، بينما تشير [OLE](/slides/ar/java/manage-ole/) إلى كائنات تطبيق مدمجة (مثلاً ورقة عمل Excel). يتم تخزينها ومعالجتها بطريقة مختلفة وتملك نماذج خصائص مختلفة.

**هل تعمل أحداث ActiveX وماكرو VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**  
يحافظ Aspose.Slides على العلامات والبيانات الوصفية الحالية؛ ومع ذلك، تعمل الأحداث والماكروهات فقط داخل PowerPoint على Windows عندما تسمح الأمان بذلك. المكتبة لا تنفذ VBA.
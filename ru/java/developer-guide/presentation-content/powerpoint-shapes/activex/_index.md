---
title: Управление ActiveX‑контролями в презентациях с помощью Java
linktitle: ActiveX
type: docs
weight: 80
url: /ru/java/activex/
keywords:
- ActiveX
- ActiveX‑контрол
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Java использует ActiveX для автоматизации и улучшения презентаций PowerPoint, предоставляя разработчикам мощный контроль над слайдами."
---

{{% alert color="primary" %}} 

ActiveX‑контролы используются в презентациях. Aspose.Slides for Java позволяет добавлять и управлять ActiveX‑контролами, но они несколько сложнее в управлении по сравнению с обычными фигурами презентации. Мы реализовали поддержку добавления элемента управления Media Player ActiveX в Aspose.Slides. Обратите внимание, что ActiveX‑контролы не являются фигурами; они не являются частью презентации [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/). Они являются частью отдельного [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/) вместо этого. В этой статье мы покажем, как работать с ними. 

{{% /alert %}} 

## **Добавить элемент управления Media Player ActiveX на слайд**
Чтобы добавить элемент управления Media Player ActiveX, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и создайте пустую презентацию.
2. Получите доступ к целевому слайду в [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
3. Добавьте элемент управления Media Player ActiveX с помощью метода [addControl](https://reference.aspose.com/slides/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) , предоставляемого интерфейсом [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/).
4. Получите доступ к элементу управления Media Player ActiveX и задайте путь к видео, используя его свойства.
5. Сохраните презентацию в файл PPTX.

Этот пример кода, основанный на приведённых выше шагах, показывает, как добавить элемент управления Media Player ActiveX на слайд:
```java
// Создать пустой экземпляр презентации
Presentation pres = new Presentation();
try {
    // Добавление элемента управления Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Получить доступ к элементу управления Media Player ActiveX и задать путь к видео
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Сохранить презентацию
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Изменить ActiveX‑контрол**
{{% alert color="primary" %}} 

Aspose.Slides for Java 7.1.0 и более поздних версий оснащён компонентами для управления ActiveX‑контролями. Вы можете получить доступ к уже добавленному ActiveX‑контролю в вашей презентации и изменить или удалить его с помощью его свойств.

{{% /alert %}} 

Чтобы управлять простым ActiveX‑контролем, например текстовым полем и простой кнопкой, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и загрузите презентацию, содержащую ActiveX‑контролы.
2. Получите ссылку на слайд по его индексу.
3. Получите доступ к ActiveX‑контролям на слайде, обратившись к [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/).
4. Получите доступ к ActiveX‑контролю TextBox1 с помощью объекта [IControl](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/).
5. Измените свойства ActiveX‑контроля TextBox1, включающие текст, шрифт, высоту шрифта и позицию кадра.
6. Получите доступ ко второму элементу управления под названием CommandButton1.
7. Измените подпись кнопки, шрифт и позицию.
8. Сдвиньте положение рамок ActiveX‑контролей.
9. Запишите изменённую презентацию в файл PPTX.

Этот пример кода, основанный на приведённых выше шагах, показывает, как управлять простым ActiveX‑контролем: 
```java
// Доступ к презентации с ActiveX‑контролями
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Доступ к первому слайду в презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // изменение текста TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Замена заменяющего изображения. PowerPoint заменит это изображение во время активации ActiveX,
        // поэтому иногда допустимо оставить изображение без изменений.
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

    // Изменение подписи кнопки
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Изменение заменяющего изображения
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

    // перемещение вниз на 100 пунктов
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // удаление контролов
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Сохраняет ли Aspose.Slides ActiveX‑контролы при чтении и повторном сохранении, если они не могут быть выполнены в среде Java?**

**Да.** Aspose.Slides рассматривает их как часть презентации и может читать/изменять их свойства и рамки; выполнение самих контролов не требуется для их сохранения.

**Чем ActiveX‑контролы отличаются от OLE‑объектов в презентации?**

ActiveX‑контролы — это интерактивные управляемые элементы (кнопки, текстовые поля, медиаплеер), тогда как [OLE](/slides/ru/java/manage-ole/) относится к встроенным объектам приложений (например, лист Excel). Они хранятся и обрабатываются по‑разному и имеют разные модели свойств.

**Работают ли события ActiveX и макросы VBA, если файл был изменён Aspose.Slides?**

Aspose.Slides сохраняет существующую разметку и метаданные; однако события и макросы выполняются только внутри PowerPoint на Windows, когда это разрешено параметрами безопасности. Библиотека не выполняет VBA.
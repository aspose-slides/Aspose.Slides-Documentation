---
title: Управление ActiveX элементами в презентациях на Android
linktitle: ActiveX
type: docs
weight: 80
url: /ru/androidjava/activex/
keywords:
- ActiveX
- элемент ActiveX
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Android via Java использует ActiveX для автоматизации и улучшения презентаций PowerPoint, предоставляя разработчикам мощный контроль над слайдами."
---

{{% alert color="primary" %}} 

ActiveX‑элементы используются в презентациях. Aspose.Slides for Android via Java позволяет добавлять и управлять ActiveX‑элементами, но они немного сложнее в управлении по сравнению с обычными фигурами презентации. Мы реализовали поддержку добавления Active‑control Media Player в Aspose.Slides. Обратите внимание, что ActiveX‑элементы не являются фигурами; они не являются частью [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) презентации. Вместо этого они входят в отдельный [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/). В этой статье мы покажем, как работать с ними.

{{% /alert %}} 

## **Add a Media Player ActiveX Control to a Slide**
Чтобы добавить ActiveX‑элемент Media Player, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и получите пустой объект презентации.
1. Получите целевой слайд в объекте [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Добавьте ActiveX‑элемент Media Player с помощью метода [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) из интерфейса [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/).
1. Получите доступ к элементу Media Player ActiveX и задайте путь к видео, используя его свойства.
1. Сохраните презентацию в файл формата PPTX.

Этот пример кода, основанный на перечисленных шагах, демонстрирует, как добавить ActiveX‑элемент Media Player на слайд:
```java
// Создать пустой экземпляр презентации
Presentation pres = new Presentation();
try {
    // Добавление ActiveX‑элемента Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Получить доступ к ActiveX‑элементу Media Player и задать путь к видео
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Сохранить презентацию
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modify an ActiveX Control**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java версии 7.1.0 и новее оснащён компонентами для управления ActiveX‑элементами. Вы можете получить доступ к уже добавленному ActiveX‑элементу в презентации и изменить или удалить его через свойства.

{{% /alert %}} 

Чтобы управлять простым ActiveX‑элементом, таким как текстовое поле или простая кнопка команды на слайде, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию, содержащую ActiveX‑элементы.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к ActiveX‑элементам на слайде, обратившись к [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/).
1. Получите доступ к элементу TextBox1 ActiveX через объект [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/).
1. Измените свойства элемента TextBox1 ActiveX, включая текст, шрифт, высоту шрифта и положение кадра.
1. Получите второй элемент управления под названием CommandButton1.
1. Измените подпись кнопки, шрифт и положение.
1. Сместите позиции кадров ActiveX‑элементов.
1. Запишите изменённую презентацию в файл формата PPTX.

Этот пример кода, основанный на перечисленных шагах, показывает, как управлять простым ActiveX‑элементом: 
```java
// Доступ к презентации с элементами ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Доступ к первому слайду в презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // изменение текста TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Изменение заменяющего изображения. PowerPoint заменит это изображение при активации ActiveX,
        // поэтому иногда можно оставить изображение без изменений.
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

    // сдвиг вниз на 100 пунктов
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // удаление элементов управления
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```



## **FAQ**

**Does Aspose.Slides preserve ActiveX controls when reading and re-saving if they cannot be executed in the Java runtime?**

Yes. Aspose.Slides treats them as part of the presentation and can read/modify their properties and frames; executing the controls themselves is not required to preserve them.

**How do ActiveX controls differ from OLE objects in a presentation?**

ActiveX controls are interactive managed controls (buttons, text boxes, media player), whereas [OLE](/slides/ru/androidjava/manage-ole/) refers to embedded application objects (for example, an Excel worksheet). They are stored and handled differently and have different property models.

**Do ActiveX events and VBA macros work if the file has been modified by Aspose.Slides?**

Aspose.Slides preserves the existing markup and metadata; however, events and macros run only inside PowerPoint on Windows when security allows it. The library does not execute VBA.
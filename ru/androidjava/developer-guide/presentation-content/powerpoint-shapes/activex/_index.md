---
title: ActiveX
type: docs
weight: 80
url: /androidjava/activex/
---


{{% alert color="primary" %}} 

Элементы управления ActiveX используются в презентациях. Aspose.Slides для Android через Java позволяет добавлять и управлять элементами управления ActiveX, но они немного сложнее в управлении по сравнению с обычными элементами презентации. Мы реализовали поддержку добавления активного элемента управления Media Player в Aspose.Slides. Обратите внимание, что элементы управления ActiveX не являются фигурами; они не являются частью [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IShapeCollection) презентации. Вместо этого они являются частью отдельной [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection). В этой теме мы покажем вам, как с ними работать.

{{% /alert %}} 

## **Добавление элемента управления Media Player ActiveX на слайд**
Чтобы добавить элемент управления ActiveX Media Player, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и создайте пустой экземпляр презентации.
1. Доступ к целевому слайду в [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Добавьте элемент управления ActiveX Media Player, используя метод [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-), предоставленный [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).
1. Получите доступ к элементу управления ActiveX Media Player и установите путь к видео, используя его свойства.
1. Сохраните презентацию в файл PPTX.

Этот образец кода, основанный на вышеуказанных действиях, показывает, как добавить элемент управления Media Player ActiveX на слайд:

```java
// Создание пустого экземпляра презентации
Presentation pres = new Presentation();
try {
    // Добавление элемента управления Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Доступ к элементу управления Media Player ActiveX и установка пути к видео
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Сохранение презентации
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Изменение элемента управления ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides для Android через Java 7.1.0 и более новые версии оборудованы компонентами для управления элементами управления ActiveX. Вы можете получить доступ к уже добавленному элементу управления ActiveX в вашей презентации и изменить или удалить его через его свойства.

{{% /alert %}} 

Чтобы управлять простым элементом управления ActiveX, таким как текстовое поле и простая кнопка на слайде, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию с элементами управления ActiveX в ней.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к элементам управления ActiveX на слайде, получив доступ к [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).
1. Получите доступ к элементу управления TextBox1 ActiveX, используя объект [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControl).
1. Измените свойства элемента управления TextBox1 ActiveX, включая текст, шрифт, высоту шрифта и позицию рамки.
1. Получите доступ ко второму элементу управления, названному CommandButton1.
1. Измените заголовок кнопки, шрифт и позицию.
1. Сдвиньте положение рамок элементов управления ActiveX.
1. Запишите измененную презентацию в файл PPTX.

Этот образец кода, основанный на вышеуказанных действиях, показывает, как управлять простым элементом управления ActiveX: 

```java
// Доступ к презентации с элементами управления ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Доступ к первому слайду в презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // изменение текста TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Измененный текст";
        control.getProperties().set_Item("Value", newText);

        // Изменение заменяющего изображения. PowerPoint заменит это изображение во время активации activeX,
        // так что иногда нормально оставить изображение без изменений.
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

    // Изменение заголовка кнопки
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Показать MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Изменение заменяющего
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

            // перемещение на 100 пунктов вниз
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
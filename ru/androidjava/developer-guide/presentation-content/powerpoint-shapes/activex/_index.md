---
title: Управление элементами управления ActiveX в презентациях на Android
linktitle: ActiveX
type: docs
weight: 80
url: /ru/androidjava/activex/
keywords:
- ActiveX
- Элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для Android через Java использует ActiveX для автоматизации и улучшения презентаций PowerPoint, предоставляя разработчикам мощный контроль над слайдами."
---
## **Введение**

Элементы управления ActiveX используются в презентациях. Aspose.Slides для Android через Java позволяет добавлять и управлять элементами управления ActiveX, но они немного сложнее в управлении по сравнению с обычными объектами презентации. Мы реализовали поддержку добавления элемента управления Media Player в Aspose.Slides. Обратите внимание, что элементы управления ActiveX не являются фигурами; они не входят в презентацию’s[IShapeCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/). Они находятся в отдельном[IControlCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icontrolcollection/) вместо этого. В этой статье мы покажем, как работать с ними.

## **Добавление элемента управления Media Player ActiveX на слайд**
Чтобы добавить элемент управления Media Player ActiveX, выполните следующее:

1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation)и получите пустую презентацию.
1. Получите целевой слайд в объекте[Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Добавьте элемент управления Media Player ActiveX, используя метод[addControl](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) , предоставляемый[IControlCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icontrolcollection/).
1. Получите элемент управления Media Player ActiveX и задайте путь к видео, используя его свойства.
1. Сохраните презентацию в файл PPTX.

Приведённый ниже пример кода, основанный на перечисленных шагах, показывает, как добавить элемент управления Media Player ActiveX на слайд:

```java
import com.aspose.slides.*;

// Создать пустой экземпляр презентации
Presentation pres = new Presentation();
try {
    // Добавление элемента управления Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Получить доступ к элементу управления Media Player ActiveX и установить путь к видео
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Сохранить презентацию
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Изменение элемента управления ActiveX**
{{% alert color="info" %}} 

Aspose.Slides для Android через Java 7.1.0 и более новые версии оснащены компонентами для управления элементами управления ActiveX. Вы можете получить доступ к уже добавленному элементу управления ActiveX в презентации и изменить или удалить его через его свойства.

{{% /alert %}} 

Чтобы управлять простым элементом управления ActiveX, таким как текстовое поле и простая кнопка команд, на слайде, выполните следующее:

1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation)и загрузите презентацию, содержащую элементы управления ActiveX.
1. Получите ссылку на слайд по его индексу.
1. Получите элементы управления ActiveX на слайде, обратившись к[IControlCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icontrolcollection/).
1. Получите элемент управления TextBox1 ActiveX, используя объект[IControl](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icontrol/).
1. Измените свойства элемента управления TextBox1 ActiveX, включая текст, шрифт, высоту шрифта и положение рамки.
1. Получите второй элемент управления под именем CommandButton1.
1. Измените подпись кнопки, шрифт и положение.
1. Сместите положение рамок элементов управления ActiveX.
1. Запишите изменённую презентацию в файл PPTX.

Приведённый ниже пример кода, основанный на перечисленных шагах, показывает, как управлять простым элементом управления ActiveX: 

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// Получение презентации с элементами управления ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Получение первого слайда в презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Изменение текста TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Изменение заменяющего изображения. PowerPoint заменит это изображение во время активации ActiveX,
        // поэтому иногда допускается оставить изображение без изменений.
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

    // Смещение на 100 пунктов вниз
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // Удаление элементов управления
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Сохраняет ли Aspose.Slides элементы управления ActiveX при чтении и повторном сохранении, если они не могут быть выполнены в среде выполнения Java?

Да. Aspose.Slides рассматривает их как часть презентации и может читать/изменять их свойства и рамки; для их сохранения не требуется выполнять сами элементы управления.

### Чем элементы управления ActiveX отличаются от объектов OLE в презентации?

Элементы управления ActiveX — это интерактивные управляемые элементы (кнопки, текстовые поля, медиаплеер), тогда как[OLE](/slides/ru/androidjava/manage-ole/) относится к встроенным объектам приложений (например, листу Excel). Они хранятся и обрабатываются по‑разному и имеют различную модель свойств.

### Работают ли события ActiveX и макросы VBA, если файл был изменён с помощью Aspose.Slides?

Aspose.Slides сохраняет существующую разметку и метаданные; однако события и макросы выполняются только в PowerPoint на Windows при разрешённой безопасности. Библиотека не исполняет VBA.
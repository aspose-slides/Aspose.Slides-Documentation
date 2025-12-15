---
title: Управление элементами ActiveX в презентациях на Android
linktitle: ActiveX
type: docs
weight: 80
url: /ru/androidjava/activex/
keywords:
- ActiveX
- элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- модификация ActiveX
- медиаплеер
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Android via Java использует ActiveX для автоматизации и улучшения презентаций PowerPoint, предоставляя разработчикам мощный контроль над слайдами."
---

{{% alert color="primary" %}} 

ActiveX‑элементы используются в презентациях. Aspose.Slides for Android via Java позволяет добавлять и управлять ActiveX‑элементами, но они несколько сложнее в управлении по сравнению с обычными фигурами презентации. Мы реализовали поддержку добавления ActiveX‑элемента Media Player в Aspose.Slides. Обратите внимание, что ActiveX‑элементы не являются фигурами; они не являются частью [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IShapeCollection) презентации. Они находятся в отдельной [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection). В этой теме мы покажем, как с ними работать.

{{% /alert %}} 

## **Добавить ActiveX‑элемент Media Player на слайд**
Чтобы добавить элемент управления ActiveX Media Player, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и сформируйте пустую презентацию.  
2. Получите целевой слайд в объекте [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
3. Добавьте элемент управления Media Player ActiveX с помощью метода [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) из интерфейса [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).  
4. Доступитесь к элементу управления Media Player ActiveX и укажите путь к видео, используя его свойства.  
5. Сохраните презентацию в файл PPTX.  

Этот пример кода, основанный на описанных выше шагах, демонстрирует, как добавить ActiveX‑элемент Media Player на слайд:
```java
// Создать пустой экземпляр презентации
Presentation pres = new Presentation();
try {
    // Добавление элемента управления ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Доступ к элементу управления ActiveX Media Player и установка пути к видео
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Сохранить презентацию
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Изменить ActiveX‑элемент**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java версии 7.1.0 и новее оснащён компонентами для управления ActiveX‑элементами. Вы можете получить доступ к уже добавленному элементу ActiveX в презентации и изменить или удалить его через свойства.

{{% /alert %}} 

Чтобы управлять простым ActiveX‑элементом, таким как текстовое поле и простая командная кнопка на слайде, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию, содержащую ActiveX‑элементы.  
2. Получите ссылку на слайд по его индексу.  
3. Получите доступ к ActiveX‑элементам на слайде через [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).  
4. Доступитесь к ActiveX‑элементу TextBox1 с помощью объекта [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControl).  
5. Измените свойства ActiveX‑элемента TextBox1, включая текст, шрифт, высоту шрифта и позицию рамки.  
6. Получите второй элемент управления под названием CommandButton1.  
7. Измените подпись кнопки, шрифт и позицию.  
8. Сдвиньте положение рамок ActiveX‑элементов.  
9. Запишите изменённую презентацию в файл PPTX.  

Этот пример кода, основанный на описанных выше шагах, показывает, как управлять простым ActiveX‑элементом:
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

        // Замена заменяющего изображения. PowerPoint заменит это изображение при активации ActiveX,
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
        // Замена заменяющего изображения
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


## **FAQ**

**Сохраняет ли Aspose.Slides ActiveX‑элементы при чтении и повторном сохранении, если они не могут быть выполнены в среде Java?**  

Да. Aspose.Slides рассматривает их как часть презентации и может читать/изменять их свойства и рамки; для их сохранения не требуется выполнение самих элементов.

**Чем ActiveX‑элементы отличаются от OLE‑объектов в презентации?**  

ActiveX‑элементы — это интерактивные управляемые элементы (кнопки, текстовые поля, медиаплеер), тогда как [OLE](/slides/ru/androidjava/manage-ole/) относится к встроенным объектам приложений (например, листу Excel). Они хранятся и обрабатываются иначе и имеют разные модели свойств.

**Работают ли события ActiveX и макросы VBA, если файл был изменён Aspose.Slides?**  

Aspose.Slides сохраняет существующую разметку и метаданные; однако события и макросы исполняются только внутри PowerPoint на Windows при разрешённой безопасности. Библиотека не выполняет VBA.
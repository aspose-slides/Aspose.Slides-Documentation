---
title: Управление ActiveX‑элементами в презентациях на Android
linktitle: ActiveX
type: docs
weight: 80
url: /ru/androidjava/activex/
keywords:
- ActiveX
- элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Редактирование текстовых полей и кнопок ActiveX, обновление предварительных просмотров элементов управления и повторное использование элемента Windows Media Player в презентациях PowerPoint с помощью Aspose.Slides for Android via Java."
---
## **Введение**

ActiveX‑элементы предоставляют слайду PowerPoint интерактивные объекты, такие как текстовые поля, кнопки команд и медиаплееры. Aspose.Slides for Android via Java открывает элементы управления слайда через [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--). Используйте эту коллекцию для редактирования элемента, перемещения его по слайду или удаления. В примерах ниже используйте пути к файлам, доступные вашему Android‑приложению, и выберите записываемое место для каждой выходной презентации.

## **Перечисление ActiveX‑элементов и их сохранённых свойств**

Чтобы исследовать незнакомый шаблон, откройте его для чтения и пройдитесь по элементам управления на каждом слайде. Пример выводит номер слайда, имя элемента, [getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--), а также каждую пару «ключ‑значение» из [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--). Презентация читается без активации элементов, вызова событий или макросов, изменения значений и сохранения файла.

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

Выбранный вывод из `ActiveX.pptm` показывает текстовое поле и кнопку команды.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Пустая коллекция свойств отображается как `[]`. Для элементов, использующих бинарное хранилище, [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) может возвращать `null`, что отображается как `Properties unavailable`. Если нужны только имена, используйте [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) после проверки на `null`. В отчёте перечисляются свойства, доступные в презентации. Элемент может поддерживать дополнительные свойства во время выполнения.

## **Изменение ActiveX‑элементов**

Пример ожидает презентацию с поддержкой макросов, содержащую текстовое поле с именем `TextBox1` и кнопку команды с именем `CommandButton1` на первом слайде. Он использует [control properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) для изменения значения текстового поля и подписи кнопки. Каждый элемент также имеет статический предварительный просмотр, который PowerPoint может показать до активации. Предоставьте PNG‑изображения для каждого элемента, показывающие обновлённый текст и внешний вид. Пример назначает эти изображения через [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Пример перемещает каждый элемент на первом слайде вниз на 100 пунктов, задав его кадр с помощью [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Затем он сохраняет отредактированную презентацию в формате PPTM, а затем использует [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) для сохранения второй копии без каких‑либо ActiveX‑элементов на этом слайде.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

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

    IPPImage textBoxPreview;
    IPPImage buttonPreview;
    try (FileInputStream textBoxStream = new FileInputStream("text-box-preview.png");
         FileInputStream buttonStream = new FileInputStream("button-preview.png")) {
        textBoxPreview = presentation.getImages().addImage(textBoxStream);
        buttonPreview = presentation.getImages().addImage(buttonStream);
    }
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

## **Добавление ActiveX‑медиаплеера**

Чтобы повторно использовать настроенный элемент Windows Media Player, начните с шаблона, где первый слайд содержит плеер с именем `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) копирует весь слайд в новую презентацию. Пример задаёт `URL` плеера в его [properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) и сохраняет клонированный слайд единственным слайдом в выводе. Видео остаётся внешним, поэтому укажите путь, к которому плеер может получить доступ во время воспроизведения.

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

## **FAQ**

**Может ли Aspose.Slides сохранять ActiveX‑элементы без их выполнения?**

Да. Aspose.Slides может читать и сохранять элементы управления, включая их свойства и позиции, без их активации.

**Чем ActiveX‑элементы отличаются от объектов OLE?**

ActiveX‑элементы позволяют пользователям взаимодействовать со слайдом, например вводить текст или нажимать кнопку. [OLE object](/slides/ru/androidjava/manage-ole/) позволяет слайду содержать или ссылаться на контент, управляемый другим приложением, например лист Excel.

**Будут ли события ActiveX по‑прежнему вызывать VBA‑макросы после сохранения презентации с помощью Aspose.Slides?**

Сохраните презентацию в формате, поддерживающем макросы, например PPTM, чтобы сохранить её проект VBA. PowerPoint for Windows может выполнять существующие обработчики событий, если его настройки безопасности позволяют как ActiveX‑элементы, так и макросы.
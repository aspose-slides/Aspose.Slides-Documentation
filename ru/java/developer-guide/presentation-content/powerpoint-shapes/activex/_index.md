---
title: Управление ActiveX‑элементами в презентациях на Java
linktitle: ActiveX
type: docs
weight: 80
url: /ru/java/activex/
keywords:
- ActiveX
- элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Редактировать текстовые поля и кнопки ActiveX, обновлять предварительные просмотры элементов управления и повторно использовать элемент Windows Media Player в презентациях PowerPoint с помощью Aspose.Slides для Java."
---
## **Введение**

ActiveX‑элементы предоставляют слайду PowerPoint интерактивные элементы, такие как текстовые поля, кнопки команд и медиаплееры. Aspose.Slides for Java раскрывает элементы управления слайда через [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). Используйте эту коллекцию для редактирования элемента управления, перемещения его по слайду или удаления.

## **Список ActiveX‑элементов и их сохранённых свойств**

Чтобы исследовать незнакомый шаблон, откройте его для чтения и пройдите по элементам управления на каждом слайде. Пример выводит номер слайда, имя элемента управления, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), а также каждую пару ключ‑значение из [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). Он читает презентацию без активации элементов управления, вызова событий или макросов, изменения значений или сохранения файла.

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

Пустая коллекция свойств отображается как `[]`. Для элементов управления, использующих бинарное хранилище, [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) может возвращать `null`, отображаемый как `Properties unavailable`. Если нужны только имена, используйте [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) после проверки на `null`. Отчёт перечисляет свойства, доступные из презентации. Элемент управления может поддерживать дополнительные свойства во время выполнения.

## **Изменить ActiveX‑элементы**

Пример ожидает презентацию с поддержкой макросов, содержащую текстовое поле с именем `TextBox1` и кнопку команды с именем `CommandButton1` на первом слайде. Он использует [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) для изменения значения текстового поля и подписи кнопки. Каждый элемент управления также имеет статический предварительный просмотр, который PowerPoint может показывать до активации. Предоставьте PNG для каждого элемента, показывающий обновлённый текст и внешний вид. Пример назначает эти изображения через [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Пример перемещает каждый элемент управления на первом слайде вниз на 100 пунктов, задавая его рамку с помощью [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Он сохраняет отредактированную презентацию в формате PPTM, затем использует [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) для сохранения второй копии без всех ActiveX‑элементов на этом слайде.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
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

## **Добавить элемент управления ActiveX Media Player**

Чтобы повторно использовать настроенный элемент управления Windows Media Player, начните с шаблона, в котором первый слайд содержит плеер с именем `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) копирует весь слайд в новую презентацию. Пример задает `URL` плеера в его [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) и сохраняет клонированный слайд единственным слайдом в выводе. Видео остаётся внешним, поэтому укажите путь, доступный плееру во время воспроизведения.

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

**Может ли Aspose.Slides сохранять ActiveX‑элементы, не запуская их?**

Да. Aspose.Slides может читать и сохранять элементы управления, включая их свойства и позиции, без их активации.

**Чем отличаются ActiveX‑элементы от OLE‑объектов?**

ActiveX‑элементы позволяют пользователям взаимодействовать со слайдом, например вводить текст или нажимать кнопку. [OLE object](/slides/ru/java/manage-ole/) позволяет слайду содержать или связывать контент, управляемый другим приложением, например таблицу Excel.

**Будут ли события ActiveX по‑прежнему вызывать VBA‑макросы после сохранения презентации с помощью Aspose.Slides?**

Сохраните презентацию в формате, поддерживающем макросы, например PPTM, чтобы сохранить её проект VBA. PowerPoint для Windows может выполнять существующие обработчики событий, когда настройки безопасности позволяют использовать как ActiveX‑элементы, так и макросы.
---
title: Управление элементами ActiveX в презентациях с помощью JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /ru/nodejs-java/activex/
keywords:
- ActiveX
- элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Редактируйте текстовые поля и кнопки ActiveX, обновляйте предварительные просмотры элементов управления и повторно используйте элемент Windows Media Player в презентациях PowerPoint с помощью Aspose.Slides для Node.js через Java."
---
## **Введение**

Элементы управления ActiveX предоставляют слайду PowerPoint интерактивные элементы, такие как текстовые поля, кнопки команд и медиаплееры. Aspose.Slides for Node.js через Java раскрывает элементы управления слайда через [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). Используйте эту коллекцию для изменения элемента управления, перемещения его на слайде или удаления.

## **Список ActiveX‑элементов управления и их сохранённых свойств**

Чтобы исследовать незнакомый шаблон, откройте его для чтения и пройдитесь по элементам управления на каждом слайде. Пример выводит номер слайда, имя элемента управления, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId), и каждую пару ключ‑значение в [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). Презентация читается без активации элементов управления, вызова событий или макросов, изменения значений и сохранения файла.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Выбранный вывод из `ActiveX.pptm` показывает текстовое поле и кнопку‑команду.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Пустая коллекция свойств отображается как `[]`. Для элементов управления, использующих бинарное хранилище, [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) может возвращать `null`, отображаемый как `Properties unavailable`. Если нужны только имена, используйте [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) после проверки на null. Отчёт перечисляет свойства, доступные из презентации. Элемент управления может поддерживать дополнительные свойства во время выполнения.

## **Изменение ActiveX‑элементов управления**

Пример предполагает презентацию с поддержкой макросов, содержащую текстовое поле с именем `TextBox1` и кнопку‑команду с именем `CommandButton1` на первом слайде. Он использует [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) для изменения значения текстового поля и подписи кнопки. Каждый элемент управления также имеет статический предварительный просмотр, который PowerPoint может отобразить до активации. Предоставьте PNG‑изображение для каждого элемента управления, показывающее обновлённый текст и внешний вид. Пример назначает эти изображения через [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

Пример смещает каждый элемент управления на первом слайде вниз на 100 пунктов, задавая его рамку с помощью [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). Он сохраняет отредактированную презентацию в формате PPTM, затем использует [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) для сохранения второй копии с удалёнными со слайда элементами управления ActiveX.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```
## **Добавление элемента управления ActiveX Media Player**

Чтобы повторно использовать настроенный элемент управления Windows Media Player, начните с шаблона, у которого на первом слайде находится плеер с именем `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) копирует весь слайд в новую презентацию. Пример задаёт `URL` плеера в его [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) и сохраняет клонированный слайд единственным слайдом в выводе. Видео остаётся внешним, поэтому выберите путь, к которому плеер может обратиться во время воспроизведения.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```
## **Часто задаваемые вопросы**

**Может ли Aspose.Slides сохранять элементы управления ActiveX без их выполнения?**

Да. Aspose.Slides может читать и сохранять элементы управления, включая их свойства и положения, без их активации.

**Чем элементы управления ActiveX отличаются от OLE‑объектов?**

Элементы управления ActiveX позволяют пользователям взаимодействовать со слайдом, например вводить текст или нажимать кнопку. [OLE объект](/slides/ru/nodejs-java/manage-ole/) позволяет слайду содержать или связывать контент, управляемый другим приложением, например лист Excel.

**Будут ли события ActiveX по‑прежнему вызывать макросы VBA после сохранения презентации с помощью Aspose.Slides?**

Сохраните презентацию в формате, поддерживающем макросы, например PPTM, чтобы сохранить её VBA‑проект. PowerPoint для Windows может выполнять существующие обработчики событий, если настройки безопасности позволяют использование как элементов управления ActiveX, так и макросов.
---
title: Управление ActiveX-элементами в презентациях с использованием PHP
linktitle: ActiveX
type: docs
weight: 80
url: /ru/php-java/activex/
keywords:
- ActiveX
- Элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- модификация ActiveX
- медиаплеер
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Редактирование текстовых полей и кнопок ActiveX, обновление предварительных просмотров элементов управления и повторное использование элемента Windows Media Player в презентациях PowerPoint с помощью Aspose.Slides for PHP via Java."
---
## **Введение**

ActiveX-элементы предоставляют слайду PowerPoint интерактивные элементы, такие как текстовые поля, командные кнопки и медиаплееры. Aspose.Slides for PHP via Java открывает элементы управления слайда через [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls). Используйте эту коллекцию, чтобы изменить элемент управления, переместить его на слайде или удалить.

## **Список ActiveX-элементов и их сохраняемых свойств**

Чтобы исследовать незнакомый шаблон, откройте его для чтения и пройдитесь по элементам управления на каждом слайде. Пример выводит номер слайда, имя элемента управления, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId) и каждую пару ключ‑значение из [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties). Он читает презентацию без активации элементов управления, вызова событий или макросов, изменения значений и сохранения файла.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ActiveX.pptm");
try {
    $slides = $presentation->getSlides();
    for ($i = 0; $i < java_values($slides->size()); $i++) {
        $controls = $slides->get_Item($i)->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            printf("Slide %d | %s | %s\n", $i + 1, $control->getName(), $control->getClassId());
            $properties = $control->getProperties();
            if (java_is_null($properties)) {
                echo "  Properties unavailable\n";
                continue;
            }
            if (java_values($properties->getCount()) === 0) {
                echo "  []\n";
                continue;
            }
            $names = $properties->getNamesOfProperties()->iterator();
            while (java_values($names->hasNext())) {
                $name = $names->next();
                printf("  %s = %s\n", $name, $properties->get_Item($name));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Выбранный вывод из `ActiveX.pptm` показывает текстовое поле и командную кнопку.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Пустая коллекция свойств отображается как `[]`. Для элементов, использующих бинарное хранилище, [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) может возвращать `null`, отображаемое как `Properties unavailable`. Если нужны только имена, используйте [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) после проверки на `null`. Отчёт перечисляет свойства, доступные в презентации. Элемент управления может поддерживать дополнительные свойства во время выполнения.

## **Изменить ActiveX-элементы**

Пример ожидает макроподдерживаемую презентацию с текстовым полем под именем `TextBox1` и командной кнопкой под именем `CommandButton1` на первом слайде. Он использует [control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) для изменения значения текстового поля и подписи кнопки. Каждый элемент управления также имеет статический предварительный просмотр, который PowerPoint может показать до активации. Предоставьте PNG‑изображение для каждого элемента, показывающее обновлённый текст и внешний вид. Пример назначает эти изображения через [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat).

Пример перемещает каждый элемент управления на первом слайде на 100 пунктов вниз, задавая его рамку с помощью [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). Он сохраняет отредактированную презентацию в формате PPTM, затем использует [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) для сохранения второй копии с удалёнными со слайда всеми ActiveX-элементами.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("ActiveX.pptm");
try {
    $controls = $presentation->getSlides()->get_Item(0)->getControls();
    $textBox = null;
    $button = null;
    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $name = (string) $control->getName();
        if ($name === "TextBox1") {
            $textBox = $control;
        } elseif ($name === "CommandButton1") {
            $button = $control;
        }
    }
    if ($textBox === null || $button === null || java_is_null($textBox->getProperties()) || java_is_null($button->getProperties())) {
        echo "The first slide must contain both named controls with editable properties.\n";
        return;
    }

    foreach ([[$textBox, "text-box-preview.png"], [$button, "button-preview.png"]] as [$control, $path]) {
        $image = Images::fromFile($path);
        try {
            $preview = $presentation->getImages()->addImage($image);
            $control->getSubstitutePictureFormat()->getPicture()->setImage($preview);
        } finally {
            $image->dispose();
        }
    }
    $textBox->getProperties()->set_Item("Value", "Changed text");
    $button->getProperties()->set_Item("Caption", "Show message");

    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $frame = $control->getFrame();
        $newY = java_values($frame->getY()) + 100;
        $moved = new ShapeFrame($frame->getX(), $newY, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation());
        $control->setFrame($moved);
    }
    $presentation->save("edited-controls.pptm", SaveFormat::Pptm);

    $controls->clear();
    $presentation->save("removed-controls.pptm", SaveFormat::Pptm);
} finally {
    $presentation->dispose();
}
```

## **Добавить элемент управления ActiveX Media Player**

Чтобы повторно использовать настроенный элемент Windows Media Player, начните с шаблона, в первом слайде которого находится плеер под именем `WindowsMediaPlayer1`. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) копирует весь слайд в новую презентацию. Пример задает `URL` плеера в его [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) и сохраняет склонированный слайд как единственный слайд в выводе. Видео остаётся внешним, поэтому укажите путь, к которому плеер может получить доступ во время воспроизведения.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$template = new Presentation("template.pptx");
try {
    $presentation = new Presentation();
    try {
        $slides = $presentation->getSlides();
        $sourceSlide = $template->getSlides()->get_Item(0);
        $slide = $slides->addClone($sourceSlide);
        $player = null;
        $controls = $slide->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            if ((string) $control->getName() === "WindowsMediaPlayer1") {
                $player = $control;
                break;
            }
        }
        if ($player === null || java_is_null($player->getProperties())) {
            echo "The template slide must contain a named media player with editable properties.\n";
            return;
        }
        $player->getProperties()->set_Item("URL", "Wildlife.mp4");
        $slides->removeAt(0);
        $presentation->save("linked-video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $template->dispose();
}
```

## **FAQ**

**Может ли Aspose.Slides сохранять ActiveX-элементы без их выполнения?**

Да. Aspose.Slides может читать и сохранять элементы управления, включая их свойства и позиции, без их активации.

**Чем отличаются ActiveX-элементы от OLE-объектов?**

ActiveX-элементы позволяют пользователям взаимодействовать со слайдом, например вводить текст или нажимать кнопку. [OLE-объект](/slides/ru/php-java/manage-ole/) позволяет слайду содержать или ссылаться на контент, управляемый другим приложением, например таблицу Excel.

**Будут ли события ActiveX по-прежнему запускать VBA‑макросы после сохранения презентации с помощью Aspose.Slides?**

Сохраните презентацию в формате, поддерживающем макросы, например PPTM, чтобы сохранить её VBA‑проект. PowerPoint для Windows может выполнять существующие обработчики событий, когда настройки безопасности позволяют как ActiveX-элементы, так и макросы.
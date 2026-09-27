---
title: Создание презентаций на JavaScript
linktitle: Создать презентацию
type: docs
weight: 10
url: /ru/nodejs-java/create-presentation/
keywords:
- создать презентацию
- новая презентация
- создать PPT
- новый PPT
- создать PPTX
- новый PPTX
- создать ODP
- новый ODP
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте презентации с помощью Aspose.Slides — получайте файлы PPT, PPTX и ODP, используйте поддержку OpenDocument и сохраняйте их программно для надёжных результатов."
---
## **Обзор**

Эта статья показывает, как создать презентацию в Aspose.Slides, добавить текстовое поле на первый слайд и сохранить результат в файл.

Перед тем как начать, установите пакет `aspose.slides.via.java` из npm вместе с JDK, Python и необходимыми инструментами сборки C++. См. [Установка](/slides/ru/nodejs-java/installation/).

## **Создание презентации PowerPoint**

Чтобы создать презентацию и добавить текстовое поле на её первый слайд, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/). Новая презентация уже содержит один пустой слайд.
1. Получите этот слайд из [slide collection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getslides/) по индексу 0.
1. Добавьте прямоугольник с помощью метода [addAutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/addautoshape/) и задайте его текст методом [setText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/settext/).
1. Сохраните презентацию в файл PPTX с помощью метода [save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/save/).
1. Освободите ресурсы презентации с помощью метода [dispose](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/dispose/), и завершите процесс.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides работает в виртуальной машине Java, которая удерживает Node.js запущенным, поэтому процесс необходимо завершить явно.
process.exit(0);
```

Левый верхний угол прямоугольника находится на расстоянии 50 пунктов от левого края и 50 пунктов от верхнего края слайда, ширина прямоугольника составляет 400 пунктов, а высота — 100 пунктов. Сохраните код как *hello.js* в папке проекта и запустите `node hello.js`: будет создан файл *hello.pptx* с одним слайдом, содержащим этот прямоугольник и его текст, в текущей папке.

Aspose.Slides работает в виртуальной машине Java, которую пакет `java` запускает внутри процесса Node.js. Эта виртуальная машина не позволяет Node.js завершиться самостоятельно после выполнения скрипта, поэтому пример заканчивается вызовом `process.exit(0)`.

Без лицензии Aspose.Slides также добавляет водяной знак оценки на каждый сохраняемый слайд; см. раздел [Licensing](/slides/ru/nodejs-java/licensing/).

## **FAQ**

### В какие форматы можно сохранить новую презентацию?

Вы можете сохранять в [PPTX, PPT, and ODP](/slides/ru/nodejs-java/save-presentation/), а также экспортировать в [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/ru/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/ru/nodejs-java/render-a-slide-as-an-svg-image/) и [images](/slides/ru/nodejs-java/convert-powerpoint-to-png/), среди прочего.

### Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?

Да. Загрузите шаблон и сохраните в требуемый формат; форматы POTX/POTM/PPTM и похожие форматы [are supported](/slides/ru/nodejs-java/supported-file-formats/).

### Как задать размер/соотношение сторон слайда при создании презентации?

Установите [slide size](/slides/ru/nodejs-java/slide-size/) (включая предустановки 4:3 и 16:9 или пользовательские размеры) и выберите, как масштабировать содержимое.

### В каких единицах измеряются размеры и координаты?

В пунктах: 1 дюйм = 72 пункта.

### Как работать с очень большими презентациями (с большим количеством медиафайлов), чтобы уменьшить потребление памяти?

Используйте [BLOB management strategies](/slides/ru/nodejs-java/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и отдайте предпочтение файловым процессам вместо полностью потоковой обработки в памяти.

### Могу ли я создавать/сохранять презентации параллельно?

Вы не можете работать с одним экземпляром [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) из [multiple threads](/slides/ru/nodejs-java/multithreading/). Запускайте отдельные, изолированные экземпляры для каждого потока или процесса.

### Как убрать пробный водяной знак и ограничения?

[Apply a license](/slides/ru/nodejs-java/licensing/) один раз на процесс. XML лицензии должно оставаться неизменным, и настройка лицензии должна быть синхронизирована, если участвуют несколько потоков.

### Могу ли я цифрово подписать созданный PPTX?

Да. [Digital signatures](/slides/ru/nodejs-java/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

### Поддерживаются ли макросы (VBA) в создаваемых презентациях?

Да. Вы можете [create/edit VBA projects](/slides/ru/nodejs-java/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.
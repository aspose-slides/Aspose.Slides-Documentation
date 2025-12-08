---
title: Создание презентации PowerPoint на JavaScript
linktitle: Создать презентацию
type: docs
weight: 10
url: /ru/nodejs-java/create-presentation/
keywords: создать ppt java, создать ppt презентацию, создать pptx java
description: Узнайте, как создавать презентации PowerPoint, например PPT, PPTX, с помощью JavaScript с нуля.
---

## **Создание презентации PowerPoint**

Чтобы добавить простую прямую линию на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте AutoShape типа Line, используя метод addAutoShape, предоставляемый объектом Shapes.
1. Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.
```javascript
// Создайте объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation();
try {
    // Получите первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Добавьте автоконтур типа линия
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**В какие форматы я могу сохранить новую презентацию?**

Вы можете сохранять в [PPTX, PPT, and ODP](/slides/ru/nodejs-java/save-presentation/), а также экспортировать в [PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/ru/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/ru/nodejs-java/convert-powerpoint-to-png/), и [images](/slides/ru/nodejs-java/convert-powerpoint-to-png/), среди прочих.

**Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/nodejs-java/supported-file-formats/).

**Как контролировать размер/соотношение сторон слайдов при создании презентации?**

Установите [slide size](/slides/ru/nodejs-java/slide-size/) (включая предустановки, такие как 4:3 и 16:9, или пользовательские размеры) и выберите, как должен масштабироваться контент.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм соответствует 72 единицам.

**Как работать с очень большими презентациями (с множеством медиафайлов), чтобы снизить использование памяти?**

Используйте [BLOB management strategies](/slides/ru/nodejs-java/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и предпочитайте файловые рабочие процессы вместо чисто потоковых решений в памяти.

**Могу ли я создавать/сохранять презентации параллельно?**

Вы не можете работать с тем же экземпляром [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) из [multiple threads](/slides/ru/nodejs-java/multithreading/). Запускайте отдельные, изолированные экземпляры для каждого потока или процесса.

**Как удалить водяной знак пробной версии и ограничения?**

[Apply a license](/slides/ru/nodejs-java/licensing/) один раз на процесс. XML лицензии должен оставаться неизменным, а настройка лицензии должна синхронизироваться, если задействовано несколько потоков.

**Могу ли я цифрово подписать созданный PPTX?**

Да. [Digital signatures](/slides/ru/nodejs-java/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [create/edit VBA projects](/slides/ru/nodejs-java/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.
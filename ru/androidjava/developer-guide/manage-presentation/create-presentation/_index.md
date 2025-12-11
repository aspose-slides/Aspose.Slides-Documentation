---
title: Создание презентаций на Android
linktitle: Создать презентацию
type: docs
weight: 10
url: /ru/androidjava/create-presentation/
keywords:
- создание презентации
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
- Android
- Java
- Aspose.Slides
description: "Создавайте презентации на Java с Aspose.Slides для Android — создавайте файлы PPT, PPTX и ODP, используйте поддержку OpenDocument и сохраняйте их программно для надёжных результатов."
---

## **Создать презентацию PowerPoint**
Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие действия:

1. Создайте экземпляр класса Presentation.
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте AutoShape типа Line, используя метод addAutoShape, предоставляемый объектом Shapes.
4. Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.
```java
// Создать объект Presentation, представляющий файл презентации
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавить автофигуру типа линия
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**В какие форматы я могу сохранить новую презентацию?**

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/androidjava/save-presentation/), а также экспортировать в [PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/ru/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/ru/androidjava/convert-powerpoint-to-html/), [SVG](/slides/ru/androidjava/convert-powerpoint-to-png/) и [изображения](/slides/ru/androidjava/convert-powerpoint-to-png/), и др.

**Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/androidjava/supported-file-formats/).

**Как управлять размером/соотношением сторон слайда при создании презентации?**

Установите [размер слайда](/slides/ru/androidjava/slide-size/) (включая предустановки, такие как 4:3 и 16:9, или пользовательские размеры) и выберите, как должно масштабироваться содержимое.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм равен 72 единицам.

**Как работать с очень большими презентациями (с множеством медиафайлов), чтобы уменьшить использование памяти?**

Используйте [стратегии управления BLOB](/slides/ru/androidjava/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и предпочтительно используйте файловые рабочие процессы вместо полностью потоковых в памяти.

**Могу ли я создавать/сохранять презентации параллельно?**

Вы не можете работать с тем же экземпляром [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) из [нескольких потоков](/slides/ru/androidjava/multithreading/). Запускайте отдельные изолированные экземпляры для каждого потока или процесса.

**Как удалить водяной знак и ограничения пробной версии?**

[Примените лицензию](/slides/ru/androidjava/licensing/) один раз на процесс. XML‑файл лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована при работе с несколькими потоками.

**Могу ли я добавить цифровую подпись к создаваемому PPTX?**

Да. [Цифровые подписи](/slides/ru/androidjava/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [создавать/редактировать VBA‑проекты](/slides/ru/androidjava/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.
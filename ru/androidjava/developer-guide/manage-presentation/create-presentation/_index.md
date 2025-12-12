---
title: Создание презентаций на Android
linktitle: Создать презентацию
type: docs
weight: 10
url: /ru/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Создавайте презентации на Java с Aspose.Slides для Android — создавайте файлы PPT, PPTX и ODP, получайте поддержку OpenDocument и сохраняйте их программно для надёжных результатов."
---

## **Создать презентацию PowerPoint**
Чтобы добавить простую линию к выбранному слайду презентации, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте AutoShape типа Line, используя метод addAutoShape, предоставляемый объектом Shapes.
1. Сохраните изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.
```java
// Создайте объект Presentation, представляющий файл презентации
Presentation pres = new Presentation();
try {
    // Получите первый слайд
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавьте автофигуру типа линия
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**В какие форматы можно сохранить новую презентацию?**

Вы можете сохранять в [PPTX, PPT, and ODP](/slides/ru/androidjava/save-presentation/), а также экспортировать в [PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/ru/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/ru/androidjava/convert-powerpoint-to-html/), [SVG](/slides/ru/androidjava/convert-powerpoint-to-png/) и [images](/slides/ru/androidjava/convert-powerpoint-to-png/), среди прочего.

**Можно ли начинать с шаблона (POTX/POTM) и сохранять как обычный PPTX?**

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и аналогичные форматы [поддерживаются](/slides/ru/androidjava/supported-file-formats/).

**Как управлять размером слайда/соотношением сторон при создании презентации?**

Установите [размер слайда](/slides/ru/androidjava/slide-size/) (включая предустановки 4:3 и 16:9 или пользовательские размеры) и выберите способ масштабирования содержимого.

**В каких единицах измеряются размеры и координаты?**

В пунктах: 1 дюйм равен 72 единицам.

**Как работать с очень большими презентациями (много медиафайлов), чтобы снизить использование памяти?**

Используйте [стратегии управления BLOB](/slides/ru/androidjava/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и предпочтите файловые рабочие процессы вместо полностью в‑памяти потоков.

**Можно ли создавать/сохранять презентации параллельно?**

Вы не можете работать с одним и тем же [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) из [нескольких потоков](/slides/ru/androidjava/multithreading/). Запускайте отдельные, изолированные экземпляры на каждый поток или процесс.

**Как удалить пробный водяной знак и ограничения?**

[Примените лицензию](/slides/ru/androidjava/licensing/) один раз на процесс. XML‑файл лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована при работе нескольких потоков.

**Можно ли цифровой подписать созданный PPTX?**

Да. [Цифровые подписи](/slides/ru/androidjava/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

**Поддерживаются ли макросы (VBA) в созданных презентациях?**

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/androidjava/presentation-via-vba/) и сохранять файлы с включёнными макросами, такие как PPTM/PPSM.
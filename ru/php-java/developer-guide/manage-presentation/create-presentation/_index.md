---
title: Создание презентаций в PHP
linktitle: Создать презентацию
type: docs
weight: 10
url: /ru/php-java/create-presentation/
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
- PHP
- Aspose.Slides
description: "Создавайте презентации с помощью Aspose.Slides для PHP через Java — генерируйте файлы PPT, PPTX и ODP и сохраняйте их программно для надёжных результатов."
---
## **Обзор**

Эта статья показывает, как создать презентацию в Aspose.Slides, добавить текстовое поле на первый слайд и сохранить результат в файл. Она также демонстрирует, как создать и сохранить пустую презентацию, а также как открыть существующую презентацию поддерживаемого формата и сохранить её в другом формате. Краткий раздел FAQ в конце охватывает часто задаваемые вопросы о форматах, шаблонах, размере слайдов, единицах измерения, использовании памяти, потоках, лицензировании, цифровых подписях и поддержке VBA.

Прежде чем начать, установите Aspose.Slides for PHP via Java с помощью Composer и запустите PHP/Java Bridge в Apache Tomcat. См. [Installation](/slides/ru/php-java/installation/) для полной настройки. Примеры ниже предполагают, что Tomcat работает на `localhost:8080`, а папка Composer `vendor` расположена рядом со скриптом.

## **Создание презентации PowerPoint**

Чтобы создать презентацию и разместить текстовое поле на её первом слайде, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Новая презентация уже содержит один пустой слайд.
2. Получите этот слайд из коллекции, возвращаемой [Presentation::getSlides](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/getslides/), по индексу 0.
3. Добавьте прямоугольник с помощью метода [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/addautoshape/) и задайте его текст с помощью [TextFrame::setText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/settext/).
4. Сохраните презентацию как файл PPTX с помощью метода [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/save/).

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ru/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Две строки `require_once` загружают клиент PHP/Java Bridge из Tomcat и классы Aspose.Slides из пакета Composer. Верхний левый угол прямоугольника находится на расстоянии 50 пунктов от левого края и 50 пунктов от верхнего края слайда, а ширина прямоугольника составляет 400 пунктов, высота — 100 пунктов. Сохранённый файл содержит один слайд с этим прямоугольником и его текстом. Без лицензии Aspose.Slides также добавляет водяной знак оценки на каждый сохраняемый слайд; см. [Licensing](/slides/ru/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides читает и записывает файлы внутри Tomcat, а не в вашем процессе PHP, поэтому относительный путь, такой как "hello.pptx", разрешается относительно рабочей папки Tomcat. Примеры на этой странице формируют абсолютные пути с помощью `__DIR__`, поэтому файлы читаются из и сохраняются рядом со скриптом.
{{% /alert %}}

## **Создание и сохранение презентации**

Чтобы создать пустую презентацию и сохранить её, создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и сохраните её в любом формате из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/). В результате будет презентация с одним пустым слайдом.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ru/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Открытие и сохранение презентации**

Чтобы преобразовать презентацию из одного формата в другой, откройте её, передав путь к файлу конструктору [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), затем сохраните в целевом формате. Aspose.Slides определяет входной формат, такой как PPT, PPTX или ODP, по самому файлу.

Пример ниже ожидает наличие презентации OpenDocument с именем *Sample.odp* рядом со скриптом и сохраняет её как PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ru/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

### В какие форматы я могу сохранить новую презентацию?

Вы можете сохранять в [PPTX, PPT и ODP](/slides/ru/php-java/save-presentation/), а также экспортировать в [PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/ru/php-java/convert-powerpoint-to-xps/), [HTML](/slides/ru/php-java/convert-powerpoint-to-html/), [SVG](/slides/ru/php-java/render-a-slide-as-an-svg-image/) и [изображения](/slides/ru/php-java/convert-powerpoint-to-png/), среди прочего.

### Могу ли я начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и подобные [поддерживаются](/slides/ru/php-java/supported-file-formats/).

### Как управлять размером слайда/соотношением сторон при создании презентации?

Установите [slide size](/slides/ru/php-java/slide-size/) (включая предустановки, такие как 4:3 и 16:9, или пользовательские размеры) и выберите, как масштабировать содержание.

### В каких единицах измеряются размеры и координаты?

В пунктах: 1 дюйм равен 72 единицам.

### Как обрабатывать очень большие презентации (с множеством медиафайлов), чтобы уменьшить использование памяти?

Используйте [BLOB management strategies](/slides/ru/php-java/manage-blob/), ограничьте хранение в памяти, используя временные файлы, и отдавайте предпочтение файловым рабочим процессам вместо полностью потоковых операций в памяти.

### Могу ли я создавать/сохранять презентации параллельно?

Вы не можете работать с тем же экземпляром [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) из [multiple threads](/slides/ru/php-java/multithreading/). Запускайте отдельные изолированные экземпляры для каждого потока или процесса.

### Как удалить пробный водяной знак и ограничения?

[Apply a license](/slides/ru/php-java/licensing/) один раз на процесс. XML лицензии должен оставаться неизменным, а настройка лицензии должна быть синхронизирована, если задействовано несколько потоков.

### Могу ли я цифрово подписать создаваемый PPTX?

Да. [Digital signatures](/slides/ru/php-java/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

### Поддерживаются ли макросы (VBA) в созданных презентациях?

Да. Вы можете [create/edit VBA projects](/slides/ru/php-java/presentation-via-vba/) и сохранять файлы с включёнными макросами, такие как PPTM/PPSM.
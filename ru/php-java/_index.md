---
title: Aspose.Slides для PHP через Java
second_title: Aspose.Slides для PHP
type: docs
weight: 45
url: /ru/php-java/
keywords:
- документация
- обработка презентаций
- конвертация презентаций
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Начните здесь: установите Aspose.Slides для PHP через Java, создайте первую презентацию и найдите руководства по обычным задачам, справочник API и поддержку."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java — это библиотека классов для создания, чтения, редактирования и конвертации презентаций PowerPoint и OpenDocument в PHP‑приложениях без Microsoft PowerPoint или автоматизации Office.

Библиотека загружает и сохраняет файлы PPT, PPTX, PPS, POT и ODP, включая варианты с макросами и шаблоны, а также экспортирует в PDF, XPS, HTML, SVG, TIFF, Markdown и изображения.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Начать работу</b></p>
<hr>
<p>НАЧАЛО РАБОТЫ</p>
<ul>
<li><a href="/slides/ru/php-java/installation/">Установка</a></li>
<li><a href="/slides/ru/php-java/create-presentation/">Создайте свою первую презентацию</a></li>
<li><a href="/slides/ru/php-java/getting-started/">Руководство по началу работы</a></li>
</ul>
<p>ОЦЕНКА</p>
<ul>
<li><a href="/slides/ru/php-java/supported-file-formats/">Поддерживаемые форматы файлов</a></li>
<li><a href="/slides/ru/php-java/evaluate-aspose-slides/">Ограничения пробной версии</a></li>
<li><a href="/slides/ru/php-java/licensing/">Лицензирование</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Создание с помощью Slides</b></p>
<hr>
<p>ОБЩИЕ ЗАДАЧИ</p>
<ul>
<li><a href="/slides/ru/php-java/open-presentation/">Открыть презентацию</a></li>
<li><a href="/slides/ru/php-java/save-presentation/">Сохранить презентацию</a></li>
<li><a href="/slides/ru/php-java/convert-powerpoint-to-pdf/">Конвертировать в PDF</a></li>
<li><a href="/slides/ru/php-java/convert-slide/">Рендерить слайды как изображения</a></li>
<li><a href="/slides/ru/php-java/manage-text/">Редактировать текст и фигуры</a></li>
</ul>
<p>РАБОЧИЕ ПРОЦЕССЫ SLIDES</p>
<ul>
<li><a href="/slides/ru/php-java/powerpoint-charts/">Диаграммы</a></li>
<li><a href="/slides/ru/php-java/powerpoint-animation/">Анимации</a></li>
<li><a href="/slides/ru/php-java/manage-media-files/">Аудио и видео</a></li>
<li><a href="/slides/ru/php-java/presentation-design/">Дизайн слайдов</a></li>
<li><a href="/slides/ru/php-java/merge-presentation/">Объединить презентации</a></li>
</ul>
<p>ПРИМЕРЫ</p>
<ul>
<li><a href="/slides/ru/php-java/examples/">Примеры по элементам слайдов</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Справка &amp; Поддержка</b></p>
<hr>
<p>СПРАВОЧНИК</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">Справочник API</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Примечания к выпуску</a></li>
<li><a href="/slides/ru/php-java/known-issues/">Известные проблемы</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">Страница продукта</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Скачать</a></li>
</ul>
<p>ПОДДЕРЖКА</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Бесплатный форум поддержки</a></li>
<li><a href="https://helpdesk.aspose.com/">Платная служба поддержки</a></li>
</ul>
</div>
</div>

------

## **Ваша первая презентация**

Aspose.Slides for PHP via Java работает на Java внутри Apache Tomcat, а ваши PHP‑скрипты обращаются к нему через PHP/Java Bridge. [Установка](/slides/ru/php-java/installation/) настраивает PHP 8.3 или более раннюю версию, Java, Tomcat и мост, а затем устанавливает пакет из Packagist в каталог проекта:

```bash
composer require aspose/slides
```

Затем скопируйте JAR‑файл пакета в мост и перезапустите Tomcat, как в шаге 4 [Установка в Linux](/slides/ru/php-java/installation/#install-on-linux) или шаге 6 [Установка в Windows](/slides/ru/php-java/installation/#install-on-windows). При запущенном Tomcat сохраните этот скрипт как *hello.php* в каталоге проекта и выполните `php hello.php`:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

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

Скрипт сохраняет *hello.pptx* рядом с собой, содержащий один слайд с текстовым полем. Без лицензии сохраняемый файл содержит водяной знак оценки — см. [Лицензирование](/slides/ru/php-java/licensing/). Для получения дополнительных способов создания и заполнения презентации см. [Создание презентаций](/slides/ru/php-java/create-presentation/).
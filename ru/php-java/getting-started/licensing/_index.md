---
title: Лицензирование
description: "Aspose.Slides для PHP через Java предлагает различные планы покупки или предлагает бесплатную пробную версию и 30-дневную временную лицензию для оценки с использованием политик лицензирования и подписки."
type: docs
weight: 80
url: /ru/php-java/licensing/
---

Иногда для достижения лучших результатов оценки может понадобиться практический подход. По этой причине Aspose.Slides предлагает различные планы покупки, а также предлагает бесплатную пробную версию и 30-дневную временную лицензию для оценки.

{{% alert color="primary" %}}

Обратите внимание, что существуют общие политики и практики, которые направляют вас по тому, как оценивать, правильно лицензировать и покупать наши продукты. Вы можете найти их в разделе ["Политики покупки и часто задаваемые вопросы"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Оценка Aspose.Slides**
Вы можете легко скачать Aspose.Slides для оценки. Пакет для оценки такой же, как и купленный пакет. Оценочная версия просто получает лицензию после того, как вы добавите несколько строк кода для применения лицензии.

## **Ограничения оценочной версии**
Оценочная версия Aspose.Slides (без указанной лицензии) предоставляет полную функциональность продукта, но вставляет водяной знак оценки в верхней части документа при открытии и сохранении. Вы также ограничены одной слайдом при извлечении текстов из слайдов презентации.

{{% alert color="primary" %}} 

Если вы хотите протестировать Aspose.Slides без ограничений оценочной версии, вы можете запросить **30-дневную временную лицензию**. Пожалуйста, обратитесь к [Как получить временную лицензию?](https://purchase.aspose.com/temporary-license) для получения дополнительной информации.

{{% /alert %}} 

## **О лицензии**
Вы можете легко скачать оценочную версию Aspose.Slides для PHP через Java со страницы [загрузки](https://packagist.org/packages/aspose/slides). Оценочная версия предоставляет абсолютно **такие же возможности**, как и лицензированная версия Aspose.Slides. Более того, оценочная версия просто получает лицензию после покупки лицензии и добавления пары строк кода для применения лицензии.

Лицензия — это текстовый XML-файл, который содержит такие детали, как название продукта, количество разработчиков, на которых она лицензируется, дата окончания подписки и так далее. Файл цифровой подписи, поэтому не изменяйте файл. Даже случайное добавление дополнительного переноса строки в содержимое файла приведет к его недействительности.

Чтобы избежать ограничений, связанных с оценочной версией, вы должны установить лицензию перед использованием **Aspose.Slides**. Вам нужно установить лицензию только один раз для приложения или процесса.

## Купленная лицензия

После покупки вам необходимо применить файл лицензии или поток. 

{{% alert color="primary" %}}

Вы должны установить лицензию:
* только один раз для домена приложения
* перед использованием любых других классов Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Вы можете найти информацию о ценах на странице [“Информация о ценах”](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Установка лицензии в Aspose.Slides для PHP через Java**

Лицензии могут быть применены из следующих мест:

* Явный путь
* Поток
* Как Лицензия по измерению – новый механизм лицензирования

{{% alert color="primary" %}}

Используйте метод **setLicense** для лицензирования компонента.

Хотя множественные вызовы **setLicense** не являются вредными, они являются расточительством ресурсов (процессора).

{{% /alert %}}

#### **Применение лицензии с использованием файла**

Этот фрагмент кода используется для установки файла лицензии:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

При вызове метода setLicense название лицензии должно совпадать с названием вашего файла лицензии. Например, вы можете изменить название файла лицензии на "Aspose.Slides.lic.xml". Затем в вашем коде нужно передать новое название лицензии (Aspose.Slides.lic.xml) в метод setLicense.

#### **Применение лицензии из потока**

Этот фрагмент кода используется для применения лицензии из потока:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

#### Применение лицензии по измерению

Aspose.Slides позволяет разработчикам применять ключ по измерению. Это новый механизм лицензирования.

Новый механизм лицензирования будет использоваться вместе с существующим методом лицензирования. Клиенты, которые хотят оплачивать услуги на основе использования функций API, могут использовать лицензирование по измерению.

После выполнения всех необходимых шагов для получения этого типа лицензии вы получите ключи, а не файл лицензии. Этот ключ по измерению можно применять с использованием класса **Metered**, специально введенного для этой цели.

Следующий пример кода показывает, как установить публичные и приватные ключи по измерению:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Metered;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

# Создайте экземпляр класса Metered
$metered = new Metered();

# Получите свойство set_metered_key и передайте публичные и приватные ключи в качестве параметров
$metered->setMeteredKey("*****", "*****");

# Получите количество данных по измерению перед вызовом API
$amountbefore = Metered::getConsumptionQuantity();
# Отобразите информацию
echo "<script>console.log('Количество потребленное до: " . java_values($amountbefore) . "' );</script>";

# Загрузите документ с диска.
$pres = new Presentation();
# Получите количество страниц документа
echo "<script>console.log('Количество потребленное после: " . java_values($pres->getSlides()->size()) . "' );</script>";
# сохраните как PDF
$pres->save("out_pdf.pdf", SaveFormat::Pdf);

# Получите количество данных по измерению после вызова API
$amountafter = Metered::getConsumptionQuantity();
# Отобразите информацию
echo "<script>console.log('Количество потребленное после: " . java_values($amountafter) . "' );</script>";
?>
```

{{% alert color="primary" %}}

Обратите внимание, что вам необходимо иметь стабильное интернет-соединение для правильного использования лицензии по измерению, так как механизм Metered требует постоянного взаимодействия с нашими сервисами для правильных расчетов. Для получения дополнительной информации обратитесь к разделу [“Часто задаваемые вопросы по лицензированию по измерению”](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}
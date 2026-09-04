---
title: Управление свойствами презентации в PHP
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/php-java/presentation-properties/
keywords:
- Свойства PowerPoint
- Свойства презентации
- Свойства документа
- Встроенные свойства
- Пользовательские свойства
- Продвинутые свойства
- Управление свойствами
- Изменение свойств
- Метаданные документа
- Редактирование метаданных
- Язык проверки орфографии
- Язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте свойствами презентаций в Aspose.Slides для PHP через Java и упрощайте поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документа: **Встроенные** и **Пользовательские**. Оба типа свойств можно легко получать и управлять ими с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами презентации через класс [DocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/) . Экземпляр этого класса возвращается методом [Presentation::getDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getDocumentProperties) . Ниже приведены примеры, показывающие, как читать, изменять и управлять этими свойствами.

{{% alert color="info" title="Note" %}}
Пожалуйста, обратите внимание, что поля **Application** и **AppVersion** изменить нельзя. Aspose.Slides переписывает их при каждом сохранении, поэтому сохранённая презентация всегда сообщает «Aspose.Slides for PHP via Java» и версию библиотеки, которая её создала. Любое значение, переданное в `setNameOfApplication`, отбрасывается при записи презентации.
{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять некоторые свойства в файлы презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два вида свойств документа:

- Системные (Встроенные) свойства
- Пользовательские (Custom) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как заголовок, имя автора, статистика документа и т.д. **Пользовательские** свойства — это пары **Имя/Значение**, определяемые пользователем. С помощью Aspose.Slides for PHP via Java разработчики могут получать и изменять как встроенные, так и пользовательские свойства.

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентаций. Всё, что нужно сделать — нажать значок Office и далее пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007, как показано ниже:

|**Выбор пункта меню Advanced Properties**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

После выбора пункта **Advanced Properties** появляется диалоговое окно, позволяющее управлять свойствами документа PowerPoint, как показано на рисунке:

|**Диалог свойств**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В приведённом **Диалоге свойств** видно множество вкладок: **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют настраивать разные виды информации, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

## **Работа со свойствами документа с помощью Aspose.Slides for PHP via Java**

Как уже было описано, Aspose.Slides for PHP via Java поддерживает два типа свойств документа: **Встроенные** и **Пользовательские**. Поэтому разработчики могут получать оба типа свойств через API Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java предоставляет класс [DocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties) , представляющий свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **DocumentProperties**, предоставляемое объектом [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation) , чтобы получить доступ к свойствам документа файлов презентаций, как описано ниже:

## **Чтение публичных свойств из зашифрованной презентации**

Пароль открытия обычно защищает как содержание презентации, так и свойства документа. Когда презентация зашифрована методом `false` в [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) , её свойства документа остаются публичными. Затем приложение может передать `true` в [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) и прочитать публичные метаданные без предоставления пароля открытия.

Опция загрузки только свойств документа контролирует, что именно загружает Aspose.Slides; она ничего не расшифровывает. Если свойства были включены в шифрование, загрузка их без пароля завершится неудачей. Если презентация не зашифрована, опция игнорируется и загружается полная презентация.

Следующий пример проверяет режим загрузки через [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) и затем читает встроенные свойства через [Presentation::getDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getDocumentProperties) :

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

В этом режиме содержимое слайдов не загружается. Слайды, шаблоны, макеты, фигуры, медиа и другие объекты презентации недоступны. Приложения всегда должны проверять [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ru/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) перед выполнением операций, требующих полной модели объектов презентации.

{{% alert color="warning" title="Warning" %}}
Публичные метаданные могут раскрыть имена авторов, заголовки, темы, ключевые слова, сведения о компании, комментарии и пользовательские значения. Шифруйте чувствительные свойства вместе с презентацией. Оставляйте их публичными только если системы индексации, классификации, поиска или управления документами требуют доступа к ним без пароля.
{{% /alert %}}

## **Обновление свойств зашифрованной презентации**

Для зашифрованного файла PPTX презентация, загруженная в режиме только свойств документа, предназначена для чтения публичных метаданных. Aspose.Slides не может сохранить изменённые свойства из этого объекта только с метаданными, потому что публичные свойства должны оставаться согласованными с соответствующими данными внутри зашифрованной презентации. Поэтому обновление требует правильного пароля открытия и полной загрузки.

Следующий пример открывает презентацию с помощью [LoadOptions::setPassword](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setPassword) , обновляет публичные встроенные свойства и сохраняет результат. Затем он использует [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#isEncrypted) для проверки сохранения шифрования и повторно открывает публичные метаданные без пароля, чтобы проверить новые значения:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Если приложение не имеет права расшифровывать или загружать содержимое презентации, оно должно рассматривать публичные свойства зашифрованного файла PPTX как только для чтения.

## **Доступ к встроенным свойствам**

Эти свойства, предоставляемые объектом [DocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties) , включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (Общедоступный?), **PresentationFormat**, **Subject** и **Title**.

```php
  # Создать экземпляр класса Presentation, представляющего презентацию
  $pres = new Presentation("Presentation.pptx");
  try {
    # Создать ссылку на объект IDocumentProperties, связанный с презентацией
    $dp = $pres->getDocumentProperties();
    # Отобразить встроенные свойства
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Изменение встроенных свойств**

Изменять встроенные свойства файлов презентаций так же просто, как их получать. Достаточно присвоить строковое значение нужному свойству, и значение будет изменено. В примере ниже показано, как можно изменить встроенные свойства документа презентации с помощью Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Создать ссылку на объект IDocumentProperties, связанный с презентацией
    $dp = $pres->getDocumentProperties();
    # Установить встроенные свойства
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Сохранить презентацию в файл
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Этот пример изменяет встроенные свойства презентации, что можно увидеть на следующем изображении:

|**Встроенные свойства документа после изменения**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**

Aspose.Slides for PHP via Java также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Пример ниже показывает, как установить пользовательские свойства для презентации.

```php
  $pres = new Presentation();
  try {
    # Получение свойств документа
    $dProps = $pres->getDocumentProperties();
    # Добавление пользовательских свойств
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Получение имени свойства по индексу
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Удаление выбранного свойства
    $dProps->removeCustomProperty($getPropertyName);
    # Сохранение презентации
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Добавлены пользовательские свойства документа**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for PHP via Java также позволяет разработчикам получать значения пользовательских свойств. Пример ниже показывает, как получить и изменить все эти пользовательские свойства презентации.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Создать ссылку на объект DocumentProperties, связанный с презентацией
    $dp = $pres->getDocumentProperties();
    # Получить доступ и изменить пользовательские свойства
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Отобразить имена и значения пользовательских свойств
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Изменить значения пользовательских свойств
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Сохранить презентацию в файл
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Этот пример изменяет пользовательские свойства [PPTX ](https://docs.fileformat.com/presentation/pptx/)презентации. На рисунках показаны пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Пользовательские свойства после изменения**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Продвинутые свойства документа**

{{% alert color="info" title="Note" %}}
Новые методы [readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) и [writeBindedPresentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) добавлены в класс [PresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo) , логика сеттера свойства [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#setLastSavedTime) изменена.
{{% /alert %}} 

Два новых метода [readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) и [updateDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) добавлены в класс [PresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo) . Они обеспечивают быстрый доступ к свойствам документа и позволяют изменять их без загрузки всей презентации.

Типичный сценарий — загрузить свойства, изменить некоторое значение и обновить документ — может быть реализован следующим образом:

```php
  # прочитать информацию о презентации
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # получить текущие свойства
  $props = $info->readDocumentProperties();
  # установить новые значения полей Author и Title
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # обновить презентацию новыми значениями
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Есть и другой способ использовать свойства конкретной презентации как шаблон для обновления свойств в других презентациях:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

Новый шаблон можно создать с нуля, а затем использовать его для обновления нескольких презентаций:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **Установка языка проверки орфографии**

Aspose.Slides предоставляет свойство LanguageId (доступное через класс PortionFormat) для установки языка проверки орфографии в документе PowerPoint. Язык проверки — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот PHP‑код показывает, как установить язык проверки орфографии для PowerPoint: xxx Почему LanguageId отсутствует в классе Java PortionFormat?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// установить идентификатор языка проверки орфографии

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка языка по умолчанию**

Этот PHP‑код показывает, как установить язык по умолчанию для всей презентации PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Добавляет новую форму прямоугольника с текстом
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Проверяет язык первой порции
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Онлайн‑пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ru/metadata) , чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## **FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их невозможно. Однако их можно изменить или установить пустыми, если конкретное свойство позволяет это.

**Что произойдёт, если я добавлю пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Предварительно удалять или проверять свойство не требуется — Aspose.Slides автоматически обновит значение свойства.

**Можно ли получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/) и затем [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#readDocumentProperties) для чтения сохранённых метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) . См. [Build a Lightweight Presentation Inventory](/slides/ru/php-java/examine-presentation/) для полного примера отчёта и ограничений, зависящих от формата.

**Можно ли прочитать публичные свойства зашифрованной презентации без пароля открытия?**

Да. Шифрование свойств документа должно было быть отключено до шифрования презентации, и презентация должна быть загружена в режиме только свойства документа.

**Можно ли обновить зашифрованный файл PPTX в режиме только свойства документа?**

Нет. Публичные и зашифрованные данные свойств должны оставаться согласованными, поэтому обновление зашифрованного файла PPTX требует полной загрузки презентации с правильным паролем открытия.
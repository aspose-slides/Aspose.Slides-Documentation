---
title: Управление свойствами презентации в PHP
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/php-java/presentation-properties/
keywords:
- Свойства PowerPoint
- свойства презентации
- свойства документа
- встроенные свойства
- пользовательские свойства
- расширенные свойства
- управление свойствами
- изменение свойств
- метаданные документа
- редактирование метаданных
- язык проверки орфографии
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Управляйте свойствами презентации в Aspose.Slides для PHP via Java и упрощайте поиск, брендинг и рабочие процессы в ваших файлах PowerPoint и OpenDocument."
---
## **Введение**

Aspose.Slides поддерживает два типа свойств документа: **Встроенные** и **Пользовательские**. Оба этих типа свойств легко доступны и управляются с помощью API Aspose.Slides.

Aspose.Slides позволяет работать со свойствами презентации через класс [DocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/) . Экземпляр этого класса возвращается методом [Presentation::getDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getDocumentProperties) . Ниже приведены примеры чтения, изменения и управления этими свойствами.

{{% alert color="info" title="Примечание" %}}
Обратите внимание, что поля **Application** и **AppVersion** изменить нельзя. Aspose.Slides переписывает их при каждом сохранении, поэтому сохранённая презентация всегда указывает «Aspose.Slides for PHP via Java» и версию библиотеки, которая её создала. Любое значение, переданное в `setNameOfApplication`, отбрасывается при записи презентации.
{{% /alert %}} 

## **Управление свойствами презентации**

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с файлами презентаций. Существует два типа свойств документа:

- Системные (встроенные) свойства
- Пользовательские (настраиваемые) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как название документа, имя автора, статистика и т.д. **Пользовательские** свойства определяются пользователем в виде пар **Имя/Значение**, где и имя, и значение задаются пользователем. С помощью Aspose.Slides for PHP via Java разработчики могут получать и изменять как встроенные, так и пользовательские свойства.

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами файлов презентаций. Достаточно нажать значок Office и выбрать пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007, как показано ниже:

|**Выбор пункта меню Advanced Properties**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

После выбора пункта **Advanced Properties** появляется диалог, позволяющий управлять свойствами файла PowerPoint, как показано на рисунке:

|**Диалог свойств**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В вышеуказанном **Диалог свойств** видно, что существует множество вкладок, таких как **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют настраивать разную информацию, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

## **Работа со свойствами документа с использованием Aspose.Slides for PHP via Java**

Как описывалось ранее, Aspose.Slides for PHP via Java поддерживает два вида свойств документа: **Встроенные** и **Пользовательские**. Поэтому разработчики могут получать доступ к обоим типам свойств с помощью API Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java предоставляет класс [DocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties) , представляющий свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **DocumentProperties**, доступное у объекта [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation) , для доступа к свойствам документа файлов презентаций, как показано ниже:

## **Доступ к встроенным свойствам**

Эти свойства, предоставляемые объектом [DocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties) , включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (Совместно используется разными производителями?), **PresentationFormat**, **Subject** и **Title**.

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

Изменять встроенные свойства файлов презентации так же просто, как и получать их. Достаточно присвоить строковое значение нужному свойству, и значение будет изменено. В примере ниже показано, как изменить встроенные свойства документа презентации с помощью Aspose.Slides for PHP via Java.

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

Этот пример изменяет встроенные свойства презентации, которые можно увидеть ниже:

|**Встроенные свойства документа после изменения**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**

Aspose.Slides for PHP via Java также позволяет разработчикам добавлять пользовательские значения к свойствам документа презентации. Ниже приведён пример, показывающий, как установить пользовательские свойства для презентации.

```php
  $pres = new Presentation();
  try {
    # Получение свойств документа
    $dProps = $pres->getDocumentProperties();
    # Добавление пользовательских свойств
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Получение имени свойства по указанному индексу
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

Aspose.Slides for PHP via Java также позволяет разработчикам получать значения пользовательских свойств. Ниже приведён пример, показывающий, как получить и изменить все эти пользовательские свойства для презентации.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Создать ссылку на объект DocumentProperties, связанный с презентацией
    $dp = $pres->getDocumentProperties();
    # Доступ и изменение пользовательских свойств
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

Этот пример изменяет пользовательские свойства [PPTX](https://docs.fileformat.com/presentation/pptx/) презентации. На следующих рисунках показаны пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Пользовательские свойства после изменения**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Продвинутые свойства документа**

{{% alert color="info" title="Примечание" %}}
Новые методы [readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) и [writeBindedPresentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) добавлены в [PresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo). Логика сеттера свойства [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ru/php-java/aspose.slides/documentproperties/#setLastSavedTime) изменена.
{{% /alert %}} 

Класс [PresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo) теперь содержит два новых метода — [readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) и [updateDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties). Они обеспечивают быстрый доступ к свойствам документа и позволяют изменять и обновлять свойства без загрузки полной презентации.

Типичный сценарий – загрузить свойства, изменить некоторое значение и обновить документ – может быть реализован следующим образом:

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

Существует другой способ использовать свойства конкретной презентации в качестве шаблона для обновления свойств в других презентациях:

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

Aspose.Slides предоставляет свойство LanguageId (доступно через класс PortionFormat), позволяющее задавать язык проверки орфографии для документа PowerPoint. Язык проверки — это язык, по которому проверяется орфография и грамматика в PowerPoint.

Этот PHP‑код показывает, как установить язык проверки орфографии для PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

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
    # Добавляет новую прямоугольную форму с текстом
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Проверяет язык первой части
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Живой пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ru/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ru/metadata)

## **Вопросы и ответы**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако можно изменить их значения или установить пустое значение, если это допускает конкретное свойство.

**Что происходит, если добавить пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущие значение будет перезаписано новым. Не требуется предварительно удалять или проверять свойство — Aspose.Slides автоматически обновляет значение свойства.

**Можно ли получить доступ к свойствам презентации без полной загрузки презентации?**

Да. Используйте [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationfactory/) и затем [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentationinfo/#readDocumentProperties) для чтения сохранённой метаданных документа без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) . Смотрите руководство [Build a Lightweight Presentation Inventory](/slides/ru/php-java/examine-presentation/) для полного примера отчёта и ограничений, зависящих от формата.
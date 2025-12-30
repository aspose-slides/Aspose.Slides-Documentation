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
- Настраиваемые свойства
- Расширенные свойства
- Управление свойствами
- Изменение свойств
- Метаданные документа
- Редактирование метаданных
- Язык проверки правописания
- Язык по умолчанию
- PowerPoint
- OpenDocument
- Презентация
- PHP
- Aspose.Slides
description: "Освойте свойства презентаций в Aspose.Slides for PHP via Java и упростите поиск, брендинг и рабочий процесс в файлах PowerPoint и OpenDocument."
---

{{% alert color="primary" %}} 

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два типа свойств документа:

- Системные (встроенные) свойства
- Пользовательские (настраиваемые) свойства

**Встроенные** свойства содержат общую информацию о документе, такую как название документа, имя автора, статистика документа и т.д. **Настраиваемые** свойства — это пары **Имя/Значение**, которые задаются пользователем. С помощью Aspose.Slides for PHP via Java разработчики могут получать доступ и изменять значения как встроенных, так и настраиваемых свойств.

{{% /alert %}} 

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документов файлов презентаций. Достаточно щёлкнуть значок Office и далее пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007, как показано ниже:

{{% alert color="primary" %}} 

Обратите внимание, что значения полей **Application** и **Producer** изменить нельзя, так как в этих полях будет отображаться Aspose Ltd. и Aspose.Slides for PHP via Java x.x.x.

{{% /alert %}} 

|**Выбор пункта меню Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
После выбора пункта **Advanced Properties** появится диалоговое окно, позволяющее управлять свойствами документа PowerPoint, как показано на рисунке ниже:

|**Диалоговое окно Свойства**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В приведённом **Диалоговом окне Свойства** видно, что есть несколько вкладок: **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют настроить различную информацию, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.

## Работа со свойствами документа с помощью Aspose.Slides for PHP via Java

Как описано ранее, Aspose.Slides for PHP via Java поддерживает два типа свойств документа: **встроенные** и **настраиваемые**. Поэтому разработчики могут обращаться к обоим типам свойств через API Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties), представляющий свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **IDocumentProperties**, доступное у объекта [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), для доступа к свойствам документов презентаций, как показано ниже:

## **Доступ к встроенным свойствам**

Эти свойства, предоставляемые объектом [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties), включают: **Creator** (Автор), **Description**, **Keywords**, **Created** (Дата создания), **Modified** (Дата изменения), **Printed** (Дата последней печати), **LastModifiedBy**, **SharedDoc** (Разделяется между разными производителями?), **PresentationFormat**, **Subject** и **Title**
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

Изменять встроенные свойства файлов презентаций так же просто, как и получать к ним доступ. Достаточно присвоить строковое значение нужному свойству, и значение будет изменено. В примере ниже показано, как изменить встроенные свойства документа презентации с помощью Aspose.Slides for PHP via Java.
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

|**Встроенные свойства документа после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**

Aspose.Slides for PHP via Java также позволяет разработчикам добавлять пользовательские значения к свойствам документа презентации. Ниже приведён пример, показывающий, как задать пользовательские свойства для презентации.
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


|**Добавленные пользовательские свойства документа**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for PHP via Java также позволяет разработчикам получать доступ к значениям пользовательских свойств. Ниже приведён пример, показывающий, как получить и изменить все эти пользовательские свойства презентации.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Создать ссылку на объект DocumentProperties, связанный с презентацией
    $dp = $pres->getDocumentProperties();
    # Доступ к пользовательским свойствам и их изменение
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


Этот пример изменяет пользовательские свойства [PPTX](https://docs.fileformat.com/presentation/pptx/) презентации. На рисунках показаны пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Пользовательские свойства после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Расширенные свойства документа**

{{% alert color="primary" %}} 

Новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), и [WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) добавлены в [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo); логика сеттера свойства [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) изменена.

{{% /alert %}} 

Два новых метода [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--) и [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) добавлены в интерфейс [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo). Они обеспечивают быстрый доступ к свойствам документа и позволяют изменять и обновлять свойства без загрузки полной презентации.

Типичный сценарий: загрузить свойства, изменить значение и обновить документ может быть реализован следующим образом:
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


Новый шаблон можно создать с нуля, а затем использовать для обновления нескольких презентаций:
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

Aspose.Slides предоставляет свойство LanguageId (в классе PortionFormat), позволяющее задать язык проверки орфографии для документа PowerPoint. Язык проверки используется для проверки правописания и грамматики в PowerPoint.

Этот PHP‑код показывает, как установить язык проверки орфографии для PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?
```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// установить идентификатор языка проверки

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
    # Добавляет новую прямоугольную фигуру с текстом
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

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Как удалить встроенное свойство из презентации?**

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако их можно изменить или установить пустым значением, если это допускает конкретное свойство.

**Что произойдёт, если добавить пользовательское свойство, которое уже существует?**

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Не требуется предварительно удалять или проверять наличие свойства — Aspose.Slides автоматически обновит значение.

**Можно ли получить доступ к свойствам презентации без полной её загрузки?**

Да, можно получить доступ к свойствам презентации без полной её загрузки, используя метод `getPresentationInfo` класса [PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/). Затем используйте метод `readDocumentProperties` класса [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/) для эффективного чтения свойств, экономя память и повышая производительность.
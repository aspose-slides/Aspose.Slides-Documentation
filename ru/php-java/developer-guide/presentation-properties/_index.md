---
title: У管理 презентации в PHP
linktitle: Свойства презентации
type: docs
weight: 70
url: /ru/php-java/presentation-properties/
keywords:
- свойства PowerPoint
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
description: "Освойте свойства презентаций в Aspose.Slides for PHP via Java и упростите поиск, брендинг и рабочий процесс в ваших файлах PowerPoint и OpenDocument."
---

{{% alert color="primary" %}} 

Microsoft PowerPoint предоставляет возможность добавлять свойства к файлам презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два типа свойств документа:

- System Defined (Built-in) Properties  
- User-Defined (Custom) Properties  

**Built-in** свойства содержат общую информацию о документе, такую как название документа, имя автора, статистика документа и т.д. **Custom** свойства — это свойства, определённые пользователем как пары **Name/Value**, где и имя, и значение задаются пользователем. С помощью Aspose.Slides for PHP via Java разработчики могут получать доступ к значениям встроенных свойств, а также изменять их, вместе с пользовательскими свойствами.  

{{% /alert %}} 

## **Свойства документа в PowerPoint**

Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентаций. Всё, что нужно сделать — нажать значок Office и далее выбрать пункт меню **Prepare | Properties | Advanced Properties** в Microsoft PowerPoint 2007, как показано ниже:  

{{% alert color="primary" %}} 

Обратите внимание, что вы не можете задать значения для полей **Application** и **Producer**, потому что в этих полях будет отображаться Aspose Ltd. и Aspose.Slides for PHP via Java x.x.x.  

{{% /alert %}} 

|**Выбор пункта меню Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

После выбора пункта меню **Advanced Properties** откроется диалоговое окно, позволяющее управлять свойствами документа PowerPoint, как показано на рисунке ниже:  

|**Диалог Свойств**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

В вышеуказанном **Диалоговом окне Свойств** вы можете увидеть несколько вкладок: **General**, **Summary**, **Statistics**, **Contents** и **Custom**. Все эти вкладки позволяют задавать разную информацию, связанную с файлами PowerPoint. Вкладка **Custom** используется для управления пользовательскими свойствами файлов PowerPoint.  

### Работа со свойствами документа с помощью Aspose.Slides for PHP via Java  

Как уже описывалось выше, Aspose.Slides for PHP via Java поддерживает два типа свойств документа: **Built-in** и **Custom**. Поэтому разработчики могут получать доступ к обоим типам свойств с помощью API Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java предоставляет класс [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties), который представляет свойства документа, связанные с файлом презентации, через свойство **Presentation.DocumentProperties**.  

Разработчики могут использовать свойство **DocumentProperties**, предоставляемое объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), для доступа к свойствам документа файлов презентаций, как описано ниже:  

## **Доступ к встроенным свойствам**

Эти свойства, получаемые через объект DocumentProperties, включают: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** и **Title**.  
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

Изменять встроенные свойства файлов презентаций так же просто, как получать к ним доступ. Достаточно присвоить строковое значение нужному свойству, и значение будет изменено. В примере ниже показано, как изменить встроенные свойства документа презентации с помощью Aspose.Slides for PHP via Java.  
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


Этот пример изменяет встроенные свойства презентации, что можно увидеть на изображении ниже:  

|**Встроенные свойства документа после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**

Aspose.Slides for PHP via Java также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Ниже приведён пример, показывающий, как задать пользовательские свойства для презентации.  
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


|**Добавлены пользовательские свойства документа**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Доступ и изменение пользовательских свойств**

Aspose.Slides for PHP via Java также позволяет разработчикам получать доступ к значениям пользовательских свойств. Ниже приведён пример, показывающий, как получить доступ и изменить все эти пользовательские свойства для презентации.  
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


Этот пример изменяет пользовательские свойства [PPTX](https://docs.fileformat.com/presentation/pptx/) презентации. На рисунках ниже показаны пользовательские свойства презентации до и после изменения:  

|**Пользовательские свойства до изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Пользовательские свойства после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Расширенные свойства документа**

{{% alert color="primary" %}} 

Новые методы [readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) и [writeBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) добавлены в класс [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo); логика сеттера свойства [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setLastSavedTime) была изменена.  

{{% /alert %}} 

Два новых метода [readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) и [updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) добавлены в класс [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo). Они обеспечивают быстрый доступ к свойствам документа и позволяют изменять и обновлять свойства без загрузки всей презентации.  

Типичный сценарий: загрузить свойства, изменить некоторое значение и обновить документ можно реализовать следующим образом:  
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


Существует другой способ использовать свойства конкретной презентации как шаблон для обновления свойств в других презентациях:  
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

Aspose.Slides предоставляет свойство LanguageId (доступное через класс PortionFormat), позволяющее задать язык проверки орфографии для документа PowerPoint. Язык проверки — это язык, для которого проверяются правописание и грамматика в PowerPoint.  

Этот PHP‑код показывает, как задать язык проверки орфографии для PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?  
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

Этот PHP‑код показывает, как задать язык по умолчанию для всей презентации PowerPoint:  
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


## **Онлайн‑пример**

Попробуйте онлайн‑приложение [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata), чтобы увидеть, как работать со свойствами документа через API Aspose.Slides:  

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Как удалить встроенное свойство из презентации?**  

Встроенные свойства являются неотъемлемой частью презентации и полностью удалить их нельзя. Однако вы можете изменить их значения или установить пустое значение, если это допускает конкретное свойство.  

**Что произойдёт, если добавить пользовательское свойство, которое уже существует?**  

Если добавить пользовательское свойство, которое уже существует, его текущее значение будет перезаписано новым. Удалять или проверять наличие свойства заранее не требуется — Aspose.Slides автоматически обновит значение свойства.  

**Можно ли получить доступ к свойствам презентации без полной загрузки презентации?**  

Да, можно получить доступ к свойствам презентации без полной её загрузки, используя метод `getPresentationInfo` класса [PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/). Затем используйте метод `readDocumentProperties`, предоставляемый классом [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/), чтобы эффективно считать свойства, экономя память и повышая производительность.
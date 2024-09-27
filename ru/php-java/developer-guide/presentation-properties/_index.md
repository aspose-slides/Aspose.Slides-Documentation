---
title: Свойства презентации
type: docs
weight: 70
url: /ru/php-java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint предоставляет функцию добавления свойств в файлы презентаций. Эти свойства документа позволяют хранить полезную информацию вместе с документами (файлами презентаций). Существует два типа свойств документа:

- Системные (встроенные) свойства
- Свойства, определенные пользователем (настраиваемые свойства)

**Встроенные** свойства содержат общую информацию о документе, такую как название документа, имя автора, статистика документа и так далее. **Настраиваемые** свойства — это те, которые определяются пользователями в виде пар **Имя/Значение**, где и имя, и значение определяются пользователем. Используя Aspose.Slides для PHP через Java, разработчики могут получать доступ и изменять значения встроенных и настраиваемых свойств.

{{% /alert %}} 

## **Свойства документа в PowerPoint**
Microsoft PowerPoint 2007 позволяет управлять свойствами документа файлов презентаций. Все, что вам нужно сделать, это нажать на значок Office и затем выбрать пункт меню **Подготовка | Свойства | Дополнительные свойства** в Microsoft PowerPoint 2007, как показано ниже:

{{% alert color="primary" %}} 

Обратите внимание, что вы не можете установить значения для полей **Приложение** и **Производитель**, так как здесь будут отображаться Aspose Ltd. и Aspose.Slides для PHP через Java x.x.x.

{{% /alert %}} 

|**Выбор пункта меню Дополнительные свойства**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
После выбора пункта меню **Дополнительные свойства** появится диалог, позволяющий вам управлять свойствами документа файла PowerPoint, как показано ниже на рисунке:

|**Диалог свойств**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
В вышеуказанном **Диалоге свойств** вы можете увидеть множество вкладок, таких как **Общие**, **Сводка**, **Статистика**, **Содержимое** и **Пользовательские**. Все эти вкладки позволяют настраивать различные виды информации, относящейся к файлам PowerPoint. Вкладка **Пользовательские** используется для управления настраиваемыми свойствами файлов PowerPoint.

Работа со свойствами документа с использованием Aspose.Slides для PHP через Java

Как мы описали ранее, Aspose.Slides для PHP через Java поддерживает два типа свойств документа: **Встроенные** и **Настраиваемые** свойства. Таким образом, разработчики могут получать доступ к обоим типам свойств с использованием API Aspose.Slides для PHP через Java. Aspose.Slides для PHP через Java предоставляет класс [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties), представляющий свойства документа, связанные с файлом презентации через свойство **Presentation.DocumentProperties**.

Разработчики могут использовать свойство **IDocumentProperties**, предоставляемое объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), для доступа к свойствам документа файлов презентаций, как описано ниже:

## **Получение встроенных свойств**
Эти свойства, предоставляемые объектом [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties), включают: **Автор** (Создатель), **Описание**, **Ключевые слова**, **Создано** (Дата создания), **Модифицировано** (Дата изменения), **Напечатано** (Последняя дата печати), **Последнее изменено кем**, **Ключевые слова**, **Общий документ** (Разделен ли между разными производителями?), **Формат презентации**, **Тема** и **Название**.

```php
  # Создайте экземпляр класса Presentation, который представляет презентацию
  $pres = new Presentation("Presentation.pptx");
  try {
    # Создайте ссылку на объект IDocumentProperties, связанный с презентацией
    $dp = $pres->getDocumentProperties();
    # Отобразите встроенные свойства
    echo("Категория : " . $dp->getCategory());
    echo("Текущий статус : " . $dp->getContentStatus());
    echo("Дата создания : " . $dp->getCreatedTime());
    echo("Автор : " . $dp->getAuthor());
    echo("Описание : " . $dp->getComments());
    echo("Ключевые слова : " . $dp->getKeywords());
    echo("Последнее изменено кем : " . $dp->getLastSavedBy());
    echo("Руководитель : " . $dp->getManager());
    echo("Дата изменения : " . $dp->getLastSavedTime());
    echo("Формат презентации : " . $dp->getPresentationFormat());
    echo("Последняя дата печати : " . $dp->getLastPrinted());
    echo("Общий документ : " . $dp->getSharedDoc());
    echo("Тема : " . $dp->getSubject());
    echo("Название : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Изменение встроенных свойств**
Изменение встроенных свойств файлов презентации так же просто, как и доступ к ним. Вы можете просто присвоить строковое значение любому желаемому свойству, и значение свойства будет изменено. В приведенном ниже примере мы показали, как мы можем изменить встроенные свойства документа файла презентации с использованием Aspose.Slides для PHP через Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Создайте ссылку на объект IDocumentProperties, связанный с презентацией
    $dp = $pres->getDocumentProperties();
    # Установите встроенные свойства
    $dp->setAuthor("Aspose.Slides для PHP через Java");
    $dp->setTitle("Изменение свойств презентации");
    $dp->setSubject("Тема Aspose");
    $dp->setComments("Описание Aspose");
    $dp->setManager("Руководитель Aspose");
    # Сохраните вашу презентацию в файл
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Этот пример изменяет встроенные свойства презентации, которые могут быть просмотрены, как показано ниже:

|**Встроенные свойства документа после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Добавление пользовательских свойств документа**
Aspose.Slides для PHP через Java также позволяет разработчикам добавлять пользовательские значения для свойств документа презентации. Пример приведен ниже, который показывает, как установить настраиваемые свойства для презентации.

```php
  $pres = new Presentation();
  try {
    # Получение свойств документа
    $dProps = $pres->getDocumentProperties();
    # Добавление пользовательских свойств
    $dProps->set_Item("Новый пользовательский", 12);
    $dProps->set_Item("Мое имя", "Мудассир");
    $dProps->set_Item("Пользовательский", 124);
    # Получение имени свойства по определенному индексу
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

|**Добавленные пользовательские свойства документа**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Доступ и изменение пользовательских свойств**
Aspose.Slides для PHP через Java также позволяет разработчикам получать доступ к значениям пользовательских свойств. Пример приведен ниже, который показывает, как можно получить доступ и изменить все эти пользовательские свойства для презентации.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Создайте ссылку на объект DocumentProperties, связанный с презентацией
    $dp = $pres->getDocumentProperties();
    # Доступ и изменение пользовательских свойств
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Отображение имен и значений пользовательских свойств
      echo("Имя пользовательского свойства : " . $dp->getCustomPropertyName($i));
      echo("Значение пользовательского свойства : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Изменение значений пользовательских свойств
      $dp->set_Item($dp->getCustomPropertyName($i), "Новое значение " . $i + 1);
    }
    # Сохраните вашу презентацию в файл
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Этот пример изменяет пользовательские свойства [PPTX](https://docs.fileformat.com/presentation/pptx/)презентации. Следующие фигуры показывают пользовательские свойства презентации до и после изменения:

|**Пользовательские свойства до изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Пользовательские свойства после изменения**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Расширенные свойства документа**
{{% alert color="primary" %}} 

Новые методы [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), и [WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) были добавлены в интерфейс [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo), логика сеттера свойства [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) была изменена.

{{% /alert %}} 

Два новых метода [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--) и [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) были добавлены в интерфейс [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo). Они обеспечивают быстрый доступ к свойствам документа и позволяют изменять и обновлять свойства без загрузки всей презентации.

Типичный сценарий загрузки свойств, изменения некоторого значения и обновления документа можно реализовать следующим образом:

```php
  # прочитать информацию о презентации
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # получить текущие свойства
  $props = $info->readDocumentProperties();
  # установить новые значения полей Автор и Название
  $props->setAuthor("Новый Автор");
  $props->setTitle("Новое Название");
  # обновить презентацию с новыми значениями
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");

```

Существует еще один способ использовать свойства конкретной презентации в качестве шаблона для обновления свойств в других презентациях:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Автор Шаблона");
  $template->setTitle("Название Шаблона");
  $template->setCategory("Категория Шаблона");
  $template->setKeywords("Ключевое слово1, Ключевое слово2, Ключевое слово3");
  $template->setCompany("Наша Компания");
  $template->setComments("Создано из шаблона");
  $template->setContentType("Содержимое Шаблона");
  $template->setSubject("Тема Шаблона");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

Новый шаблон может быть создан с нуля и затем использован для обновления нескольких презентаций:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Автор Шаблона");
  $template->setTitle("Название Шаблона");
  $template->setCategory("Категория Шаблона");
  $template->setKeywords("Ключевое слово1, Ключевое слово2, Ключевое слово3");
  $template->setCompany("Наша Компания");
  $template->setComments("Создано из шаблона");
  $template->setContentType("Содержимое Шаблона");
  $template->setSubject("Тема Шаблона");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

## **Проверка, изменена или создана ли презентация**
Aspose.Slides для PHP через Java предоставляет возможность проверки, была ли изменена или создана презентация. Пример приведен ниже, который показывает, как проверить, была ли презентация создана или изменена.

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("props.pptx");
  $props = $info->readDocumentProperties();
  $app = $props->getNameOfApplication();
  $ver = $props->getAppVersion();
  echo("Имя приложения: " . $app);
  echo("Версия приложения: " . $ver);

```

## **Установка языка проверки**

Aspose.Slides предоставляет свойство LanguageId (предоставляемое классом PortionFormat), чтобы позволить вам установить язык проверки для документа PowerPoint. Язык проверки — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Данный PHP код показывает, как установить язык проверки для PowerPoint: xxx Почему LanguageId отсутствует в классе Java PortionFormat?

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
    $portionFormat::setLanguageId("zh-CN");// установить Id языка проверки

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установка языка по умолчанию**

Данный PHP код показывает, как установить язык по умолчанию для всей презентации PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Добавление новой прямоугольной фигуры с текстом
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("Новый текст");
    # Проверка языка первой части
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
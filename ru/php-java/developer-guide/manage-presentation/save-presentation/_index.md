---
title: Сохранить Презентацию
type: docs
weight: 80
url: /ru/php-java/save-presentation/
---

## **Обзор**
{{% alert color="primary" %}} 

[Открытие Презентации](/slides/ru/php-java/open-presentation/) описывает, как использовать класс [Презентация](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) для открытия презентации. Эта статья объясняет, как создавать и сохранять презентации.

{{% /alert %}} 

Класс [Презентация](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) хранит содержимое презентации. Независимо от того, создаете ли вы презентацию с нуля или модифицируете существующую, по завершении вы захотите сохранить презентацию. С помощью Aspose.Slides для PHP через Java ее можно сохранить в виде **файла** или **потока**. Эта статья объясняет, как сохранить презентацию различными способами:

## **Сохранение Презентации в Файл**
Сохраните презентацию в файл, вызвав метод [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) класса [Презентация](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). Просто передайте имя файла и [**SaveFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/SaveFormat) в метод [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-).

Следующие примеры показывают, как сохранить презентацию с использованием Aspose.Slides для PHP через Java.

```php
  # Создание объекта Presentation, представляющего PPT файл
  $pres = new Presentation();
  try {
    # ...выполнение каких-то операций...
    # Сохраните вашу презентацию в файл
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Сохранение Презентации в Поток**
Можно сохранить презентацию в поток, передав выходной поток методу [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.io.OutputStream-int-) класса [Презентация](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). Существует множество типов потоков, в которые можно сохранить презентацию. В следующем примере мы создали новый файл Презентации, добавили текст в фигуру и сохранили презентацию в поток.

```php
  # Создание объекта Presentation, представляющего PPT файл
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 200, 200);
    # Добавить текст к фигуре
    $shape->getTextFrame()->setText("Этот демонстрационный пример показывает, как создать файл PowerPoint и сохранить его в поток.");
    $os = new Java("java.io.FileOutputStream", "Save_As_Stream_out.pptx");
    $pres->save($os, SaveFormat::Pptx);
    $os->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Сохранение Презентации с Предопределенным Типом Вида**
Aspose.Slides для PHP через Java предоставляет возможность установить тип вида для создаваемой презентации при ее открытии в PowerPoint с помощью класса [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties). Свойство [**setLastView**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#setLastView-int-) используется для установки типа вида с помощью перечисления [**ViewType**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewType).

```php
  # Открытие файла презентации
  $pres = new Presentation();
  try {
    # Установка типа вида
    $pres->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # Сохранение презентации
    $pres->save("newDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Сохранение Презентаций в Строгом Формате Office Open XML**
Aspose.Slides позволяет сохранять презентацию в строгом формате Office Open XML. Для этой цели предоставляется класс [**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions), в котором вы можете установить свойство Conformance во время сохранения файла презентации. Если вы установите его значение как [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict), тогда выходной файл презентации будет сохранен в строгом формате Open XML.

Следующий пример кода создает презентацию и сохраняет ее в строгом формате Office Open XML. При вызове метода [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) для презентации объект [**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions) передается в него с установленным свойством Conformance как [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict).

```php
  # Создание объекта Presentation, представляющего PPT файл
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Добавить автозащиту типа линия
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Установить параметры сохранения Строгого формата Office Open XML
    $options = new PptxOptions();
    $options->setConformance(Conformance->Iso29500_2008_Strict);
    # Сохранить вашу презентацию в файл
    $pres->save("demoPass.pptx", SaveFormat::Pptx, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Сохранение Презентаций в Формате Office Open XML в Режиме Zip64**
Файл Office Open XML является ZIP-архивом, который имеет ограничение в 4 ГБ (2^32 байт) на несжатый размер файла, сжатый размер файла и общий размер архива, а также ограничение в 65,535 (2^16-1) файлов в архиве. Расширения формата ZIP64 увеличивают эти лимиты до 2^64.

Новое свойство [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/) позволяет вам выбирать, когда использовать расширения формата ZIP64 для сохраненного файла Office Open XML.

Это свойство предоставляет следующие режимы:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) означает, что расширения формата ZIP64 будут использоваться только в том случае, если презентация выходит за пределы указанных ограничений. Это режим по умолчанию.
- [Zip64Mode.Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) означает, что расширения формата ZIP64 использоваться не будут. 
- [Zip64Mode.Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) означает, что расширения формата ZIP64 будут использоваться всегда.

Следующий код демонстрирует, как сохранить презентацию в формате PPTX с расширениями формата ZIP64:

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $pptxOptions = new PptxOptions();
    $pptxOptions->setZip64Mode(Zip64Mode::Always);
    
    $pres->save("Sample-zip64.pptx", SaveFormat::Pptx, $pptxOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="Примечание" color="warning" %}}

Сохранение в режиме Zip64Mode.Never вызовет [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/), если презентация не может быть сохранена в формате ZIP32.

{{% /alert %}}

## **Сохранение Обновлений Прогресса в Процентах**
Новый интерфейс [**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) был добавлен в интерфейс [**ISaveOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISaveOptions) и абстрактный класс [**SaveOptions** ](https://reference.aspose.com/slides/php-java/aspose.slides/SaveOptions). Интерфейс [**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) представляет собой объект обратного вызова для сохранения обновлений прогресса в процентах. 

Следующие примеры кода показывают, как использовать интерфейс [IProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback):

```php
  class ExportProgressHandler {
    function reporting($progressValue) {
      # Используйте значение процента прогресса здесь
      $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
      echo($progress . "% файл конвертирован");
    }
  }

  # Открытие файла презентации
  $pres = new Presentation("ConvertToPDF.pptx");
  try {
    $saveOptions = new PdfOptions();
    $progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));
    $saveOptions->setProgressCallback($progressHandler);
    $pres->save("ConvertToPDF.pdf", SaveFormat::Pdf, $saveOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="Информация" color="info" %}}

С помощью собственного API Aspose разработала [бесплатное приложение PowerPoint Splitter](https://products.aspose.app/slides/splitter), которое позволяет пользователям разбивать свои презентации на несколько файлов. По сути, приложение сохраняет выбранные слайды из заданной презентации в виде новых файлов PowerPoint (PPTX или PPT). 

{{% /alert %}}
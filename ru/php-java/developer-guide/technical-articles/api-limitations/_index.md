---
title: Ограничения API
type: docs
weight: 320
url: /ru/php-java/api-limitations/
keywords:
- ограничение API
- формат экспорта
- приложение
- производитель
- свойства документа
- метаданные
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Знайте ограничения Aspose.Slides for PHP: экспорт устанавливает фиксированные метаданные Application/Producer в PPT, PPTX, ODP и PDF — помогает планировать интеграции без сюрпризов."
---

## **Приложение и Производитель**

Когда вы создаёте или экспортируете презентации с помощью Aspose.Slides for PHP via Java, в файл записываются некоторые технические метаданные. Два поля часто вызывают вопросы:

**Application** определяет программу, которая создала или последняя сохраняла презентацию **PPTX**. В Aspose.Slides for PHP via Java это значение фиксировано и отображает поставщика библиотеки, а не название вашего приложения, даже если вы используете [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** определяет движок рендеринга, который сгенерировал окончательный файл при экспорте. При экспорте в **PDF** метаданные используют поля **Creator** и **Producer**. В Aspose.Slides for PHP via Java оба этих поля фиксированы и отражают библиотеку и её версию.

**What’s restricted** → **Что ограничено**

Вы не можете переопределить эти поля через API для указанных форматов. Для **PPTX** свойство Application записывается как «Aspose.Slides for PHP via Java». Для **PDF** свойства Creator и Producer записываются как «Aspose.Slides for PHP via Java x.x.x». Это поведение задумано и применяется независимо от того, как вы загружаете или сохраняете файл, и независимо от значений, назначенных с помощью [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setnameofapplication/).
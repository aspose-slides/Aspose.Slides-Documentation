---
title: Ограничения API
type: docs
weight: 320
url: /ru/python-java/api-limitations/
keywords:
- Ограничения API
- формат экспорта
- приложение
- производитель
- свойства документа
- метаданные
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте об ограничениях Aspose.Slides for Python via Java: фиксированные метаданные Application, Creator и Producer в файлах PPTX и PDF."
---
## **Обзор**

Когда презентации создаются или экспортируются с помощью Aspose.Slides, в выходной файл записываются определённые технические метаданные. В этой статье объясняются ограничения, связанные с полями метаданных `Application`, `Creator` и `Producer` в файлах PPTX и PDF.

## **Application и Producer**

Когда вы создаёте или экспортируете презентации с помощью Aspose.Slides for Python via Java, некоторые технические метаданные записываются в файл. Два поля часто вызывают вопросы:

**Application** идентифицирует программу, которая создала или последняя сохраняла презентацию **PPTX**. В Aspose.Slides for Python via Java это значение фиксировано и отображает поставщика библиотеки, а не название вашего приложения, даже если вы используете [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producer** идентифицирует движок рендеринга, который создал окончательный файл при экспорте. При экспорте в **PDF** метаданные используют поля **Creator** и **Producer**. В Aspose.Slides for Python via Java оба этих значения фиксированы и отражают библиотеку и её версию.

**Что ограничено**

Нельзя переопределить эти поля через API для указанных выше форматов. Для **PPTX** свойство Application записывается как "Aspose.Slides for Java". Для **PDF** свойства Creator и Producer записываются как "Aspose.Slides for Java x.x.x." Такое поведение задумано и применяется независимо от того, как вы загружаете или сохраняете файл, и независимо от значений, назначенных с помощью [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **FAQ**

**Могу ли я заменить значение Application в файле PPTX на название моего приложения?**

Нет. Значение фиксировано, даже если вы используете [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ru/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Могу ли я переопределить поля Creator и Producer при экспорте в PDF?**

Нет. Оба поля фиксированы и отражают библиотеку и её версию, независимо от того, как вы загружаете или сохраняете презентацию.
---
title: Ограничения API
type: docs
weight: 320
url: /ru/androidjava/api-limitations/
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
- Android
- Java
- Aspose.Slides
description: "Узнайте ограничения Aspose.Slides for Android: экспорт устанавливает фиксированные метаданные Application/Producer в PPT, PPTX, ODP и PDF - помогает планировать интеграцию без неожиданностей."
---

## **Application и Producer**

При создании или экспорте презентаций с помощью Aspose.Slides for Android via Java в файл записываются некоторые технические метаданные. Два поля часто вызывают вопросы:

**Application** определяет программу, которая создала или последней сохраняла презентацию **PPTX**. В Aspose.Slides for Android via Java это значение фиксировано и отображает поставщика библиотеки, а не имя вашего приложения, даже если вы используете [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** определяет движок рендеринга, который создал окончательный файл при экспорте. При экспорте в **PDF** метаданные используют поля **Creator** и **Producer**. В Aspose.Slides for Android via Java оба эти поля фиксированы и отражают библиотеку и её версию.

**What’s restricted**

Вы не можете переопределить эти поля через API для указанных выше форматов. Для **PPTX** свойство Application записывается как "Aspose.Slides for Android via Java". Для **PDF** свойства Creator и Producer записываются как "Aspose.Slides for Android via Java x.x.x." Такое поведение задумано и применяется независимо от того, как вы загружаете или сохраняете файл, и независимо от значений, установленных с помощью [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).
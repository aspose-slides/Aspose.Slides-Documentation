---
title: Ограничения API
type: docs
weight: 320
url: /ru/java/api-limitations/
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
- Java
- Aspose.Slides
description: "Узнайте о ограничениях Aspose.Slides for Java: при экспорте фиксируются метаданные Application/Producer в PPT, PPTX, ODP и PDF — это поможет планировать интеграцию без неожиданностей."
---

## **Приложение и Производитель**

Когда вы создаёте или экспортируете презентации с помощью Aspose.Slides for Java, в файл записываются некоторые технические метаданные. Два поля часто вызывают вопросы:

**Application** определяет программу, которая создала или последней сохраняла **PPTX**‑презентацию. В Aspose.Slides for Java это значение фиксировано и отображает поставщика библиотеки, а не имя вашего приложения, даже если вы используете [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** определяет движок рендеринга, который создал окончательный файл при экспорте. При экспорте в **PDF** метаданные используют поля **Creator** и **Producer**. В Aspose.Slides for Java оба этих поля фиксированы и отражают библиотеку и её версию.

**Что ограничено**

Вы не можете переопределять эти поля через API для указанных форматов. Для **PPTX** свойство Application записывается как "Aspose.Slides for Java". Для **PDF** свойства Creator и Producer записываются как "Aspose.Slides for Java x.x.x." Такое поведение задано по умолчанию и применимо независимо от того, как вы загружаете или сохраняете файл, и независимо от значений, присвоенных с помощью [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).
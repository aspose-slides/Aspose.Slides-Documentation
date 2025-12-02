---
title: Ограничения API
type: docs
weight: 320
url: /ru/nodejs-java/api-limitations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте об ограничениях Aspose.Slides для Node.js: экспорт задаёт фиксированные метаданные Application/Producer в PPT, PPTX, ODP и PDF - помогает планировать интеграцию без неожиданностей."
---

## **Приложение и Производитель**

Когда вы создаёте или экспортируете презентации с помощью Aspose.Slides for Node.js via Java, в файл записываются некоторые технические метаданные. Два поля часто вызывают вопросы:

**Application** определяет программу, которая создала или последняя сохранила презентацию **PPTX**. В Aspose.Slides for Node.js via Java это значение фиксировано и показывает поставщика библиотеки, а не имя вашего приложения, даже если вы используете [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** определяет движок рендеринга, который создал конечный файл при экспорте. В экспортах **PDF** метаданные используют поля **Creator** и **Producer**. При работе с Aspose.Slides for Node.js via Java оба этого поля фиксированы и отражают библиотеку и её версию.

**Что ограничено**

Вы не можете переопределить эти поля через API для указанных форматов. Для **PPTX** свойство Application записывается как "Aspose.Slides for Node.js via Java". Для **PDF** свойства Creator и Producer записываются как "Aspose.Slides for Node.js via Java x.x.x." Это поведение предусмотрено дизайном и применяется независимо от того, как вы загружаете или сохраняете файл, и независимо от значений, назначенных с помощью [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).
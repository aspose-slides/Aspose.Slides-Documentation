---
title: Ограничения API
type: docs
weight: 320
url: /ru/cpp/api-limitations/
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
- C++
- Aspose.Slides
description: "Узнайте о ограничениях Aspose.Slides for C++: экспорт фиксирует метаданные Application/Producer в PPT, PPTX, ODP и PDF — это поможет планировать интеграцию без сюрпризов."
---

## **Application and Producer**

Когда вы создаёте или экспортируете презентации с помощью Aspose.Slides for C++, в файл записываются некоторые технические метаданные. Два поля часто вызывают вопросы:

**Application** идентифицирует программу, которая создала или последняя сохранила презентацию **PPTX**. В Aspose.Slides for C++ это значение фиксировано и отображает поставщика библиотеки, а не название вашего приложения, даже если вы используете [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/) .

**Producer** идентифицирует движок рендеринга, который создал финальный файл при экспорте. При экспорте в **PDF** метаданные используют поля **Creator** и **Producer**. В Aspose.Slides for C++ оба этих поля фиксированы и отражают библиотеку и её версию.

**What’s restricted**

Вы не можете переопределить эти поля через API для указанных форматов. Для **PPTX** свойство Application записывается как "Aspose.Slides for C++". Для **PDF** свойства Creator и Producer записываются как "Aspose.Slides for C++ x.x.x". Такое поведение задумано и применяется независимо от того, как вы загружаете или сохраняете файл, и независимо от значений, присвоенных с помощью [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/) .
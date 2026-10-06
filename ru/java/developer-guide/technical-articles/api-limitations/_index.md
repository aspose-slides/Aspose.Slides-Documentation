---
title: Ограничения метаданных вывода
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
- генератор
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Aspose.Slides for Java записывает фиксированные метаданные application, creator и producer в сохранённые файлы PPTX, PDF и ODP, независимо от установленного вами имени приложения."
---
## **Обзор**

При создании или экспорте презентаций с помощью Aspose.Slides в выходной файл записываются определённые технические метаданные. В этой статье рассматриваются ограничения, связанные с полями метаданных `Application`, `Creator`, `Producer` и generator в файлах PPTX, PDF и ODP.

## **Application и Producer**

При создании или экспорте презентаций с Aspose.Slides for Java в файл записываются некоторые технические метаданные. Два поля часто вызывают вопросы:

**Application** идентифицирует программу, которая создала или последняя сохраняла презентацию **PPTX**. В Aspose.Slides for Java это значение фиксировано и отображает название библиотеки, а не название вашего приложения, даже если вы используете [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ru/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** идентифицирует движок рендеринга, который сгенерировал финальный файл при экспорте. При экспорте в **PDF** метаданные используют поля **Creator** и **Producer**. В Aspose.Slides for Java оба эти поля фиксированы и отражают библиотеку и её версию.

**Что ограничено**

Вы не можете переопределить эти поля через API для указанных форматов. Для **PPTX** свойство Application записывается как «Aspose.Slides for Java». Для **PDF** свойства Creator и Producer записываются как «Aspose.Slides for Java», после чего указывается версия библиотеки. Для **ODP** поле generator записывается как «Aspose.Slides for Java», после чего указывается версия библиотеки. Такое поведение задумано и применяется независимо от того, как вы загружаете или сохраняете файл, и независимо от значений, присвоенных с помощью [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ru/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

Это ограничение не применяется к файлам **PPT**: в файле PPT имя приложения, которое вы задаёте с помощью [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ru/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-), сохраняется.
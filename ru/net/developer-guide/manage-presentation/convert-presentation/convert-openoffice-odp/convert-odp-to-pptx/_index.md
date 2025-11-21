---
title: Преобразовать ODP в PPTX в .NET
linktitle: ODP в PPTX
type: docs
weight: 10
url: /ru/net/convert-odp-to-pptx/
keywords:
- конвертировать OpenDocument
- конвертировать презентацию
- конвертировать слайд
- конвертировать ODP
- OpenDocument в PPTX
- ODP в PPTX
- сохранить ODP как PPTX
- экспортировать ODP в PPTX
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Преобразуйте ODP в PPTX с помощью Aspose.Slides для .NET. Чистые примеры кода C#, советы по пакетной обработке и высококачественные результаты — без необходимости в PowerPoint."
---

## **Обзор**

Эта статья объясняет следующие темы.

- [C# Конвертация ODP в PPTX](#csharp-odp-to-pptx)
- [C# Конвертация ODP в PowerPoint](#csharp-odp-to-powerpoint)

## **Конвертация ODP в PPTX**

Aspose.Slides for .NET предлагает класс Presentation, который представляет файл презентации. [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) класс теперь также может получать доступ к ODP через конструктор Presentation при создании объекта. В следующем примере показано, как преобразовать презентацию ODP в презентацию PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Шаги: Конвертация ODP в PPTX в C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Шаги: Конвертация ODP в PowerPoint в C#</strong></a>
```c#
// Откройте файл ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Сохранение презентации ODP в формат PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **Рабочий пример**

Вы можете посетить веб‑приложение [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), построенное с помощью **Aspose.Slides API**. Приложение демонстрирует, как можно реализовать конвертацию ODP в PPTX с помощью Aspose.Slides API.

## **Часто задаваемые вопросы**

**Нужна ли установка Microsoft PowerPoint или LibreOffice для конвертации ODP в PPTX?**

Нет. Aspose.Slides работает автономно и не требует сторонних приложений для чтения или записи ODP/PPTX.

**Сохраняются ли шаблоны слайдов, макеты и темы при конвертации?**

Да. Библиотека использует полную модель объекта презентации и сохраняет структуру, включая шаблоны слайдов и макеты, поэтому дизайн остаётся корректным после конвертации.

**Можно ли конвертировать файлы ODP, защищённые паролем?**

Да. Aspose.Slides поддерживает обнаружение защиты, открытие и работу с [защищенные презентации](/slides/ru/net/password-protected-presentation/) (включая ODP), когда вы предоставляете пароль, а также настройку шифрования и доступ к свойствам документа.

**Подходит ли Aspose.Slides для облачных или REST‑основных сервисов конвертации?**

Да. Вы можете использовать локальную библиотеку в своём бэкенде или [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); оба варианта поддерживают конвертацию ODP → PPTX.
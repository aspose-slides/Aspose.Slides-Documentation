---
title: Преобразовать ODP в PPTX на C#
linktitle: Преобразовать ODP в PPTX
type: docs
weight: 10
url: /ru/net/convert-odp-to-pptx/
keywords: "Преобразовать презентацию OpenOffice, ODP, ODP в PPTX, C#, Csharp, .NET"
description: "Преобразовать OpenOffice ODP в презентацию PowerPoint PPTX на C# или .NET"
---

## **Обзор**

Эта статья объясняет следующие темы.

- [C# Преобразовать ODP в PPTX](#csharp-odp-to-pptx)
- [C# Преобразовать ODP в PowerPoint](#csharp-odp-to-powerpoint)

## **Преобразование ODP в PPTX**

Aspose.Slides for .NET предоставляет класс Presentation, который представляет файл презентации. [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) класс теперь также может получать доступ к ODP через конструктор Presentation при создании объекта. Ниже показан пример, как преобразовать ODP‑презентацию в PPTX‑презентацию.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Шаги: Преобразование ODP в PPTX на C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Шаги: Преобразование ODP в PowerPoint на C#</strong></a>
```c#
// Открыть файл ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Сохранение презентации ODP в формат PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **Пример в реальном времени**

Вы можете посетить веб‑приложение [**Конверсия Aspose.Slides**](https://products.aspose.app/slides/conversion/), построенное с использованием **Aspose.Slides API**. Приложение демонстрирует, как можно реализовать преобразование ODP в PPTX с помощью Aspose.Slides API.

## **Вопросы и ответы**

**Нужно ли устанавливать Microsoft PowerPoint или LibreOffice для преобразования ODP в PPTX?**

Нет. Aspose.Slides работает автономно и не требует сторонних приложений для чтения или записи ODP/PPTX.

**Сохраняются ли мастер‑слайды, макеты и темы при преобразовании?**

Да. Библиотека использует полную объектную модель презентации и сохраняет структуру, включая мастер‑слайды и макеты, поэтому дизайн остаётся корректным после преобразования.

**Могу ли я преобразовать защищённые паролем файлы ODP?**

Да. Aspose.Slides поддерживает обнаружение защиты, открытие и работу с [защищённые презентации](/slides/ru/net/password-protected-presentation/) (включая ODP), когда вы предоставляете пароль, а также настройку шифрования и доступ к свойствам документа.

**Подходит ли Aspose.Slides для облачных или REST‑ориентированных сервисов преобразования?**

Да. Вы можете использовать локальную библиотеку в своём бэкэнде или [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); оба варианта поддерживают преобразование ODP → PPTX.
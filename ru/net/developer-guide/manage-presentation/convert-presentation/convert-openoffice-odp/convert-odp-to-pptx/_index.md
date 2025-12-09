---
title: Преобразование ODP в PPTX в .NET
linktitle: ODP в PPTX
type: docs
weight: 10
url: /ru/net/convert-odp-to-pptx/
keywords:
- преобразовать OpenDocument
- преобразовать ODP
- OpenDocument в PPTX
- ODP в PPTX
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Преобразование ODP в PPTX с помощью Aspose.Slides для .NET. Чистый C# код, советы по пакетной обработке и высококачественные результаты — PowerPoint не требуется."
---

## **Обзор**

В этой статье рассматриваются следующие темы.

- [C# Преобразование ODP в PPTX](#csharp-odp-to-pptx)
- [C# Преобразование ODP в PowerPoint](#csharp-odp-to-powerpoint)

## **Преобразование ODP в PPTX**

Aspose.Slides for .NET предоставляет класс Presentation, представляющий файл презентации. Класс [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) теперь также может получить доступ к ODP через конструктор Presentation при создании объекта. Следующий пример показывает, как преобразовать презентацию ODP в презентацию PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Шаги: преобразовать ODP в PPTX в C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Шаги: преобразовать ODP в PowerPoint в C#</strong></a>
```c#
// Открыть файл ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Сохранение презентации ODP в формат PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **Рабочий пример**

Вы можете посетить веб‑приложение [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), построенное с использованием **Aspose.Slides API**. Приложение демонстрирует, как реализовать преобразование ODP в PPTX с помощью Aspose.Slides API.

## **FAQ**

**Нужно ли устанавливать Microsoft PowerPoint или LibreOffice для преобразования ODP в PPTX?**

Нет. Aspose.Slides работает автономно и не требует сторонних приложений для чтения или записи ODP/PPTX.

**Сохраняются ли мастер‑слайды, макеты и темы при преобразовании?**

Да. Библиотека использует полную модель объекта презентации и сохраняет структуру, включая мастер‑слайды и макеты, поэтому дизайн остаётся корректным после преобразования.

**Можно ли преобразовать защищённые паролем файлы ODP?**

Да. Aspose.Slides поддерживает обнаружение защиты, открытие и работу с [protected presentations](/slides/ru/net/password-protected-presentation/) (включая ODP), когда вы предоставляете пароль, а также настройку шифрования и доступ к свойствам документа.

**Подходит ли Aspose.Slides для облачных или REST‑базированных сервисов преобразования?**

Да. Вы можете использовать локальную библиотеку в своём backend или [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); оба варианта поддерживают преобразование ODP → PPTX.
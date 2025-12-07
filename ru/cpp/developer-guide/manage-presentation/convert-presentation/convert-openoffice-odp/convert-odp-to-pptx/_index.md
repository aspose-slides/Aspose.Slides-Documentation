---
title: Конвертировать ODP в PPTX на C++
linktitle: ODP в PPTX
type: docs
weight: 10
url: /ru/cpp/convert-odp-to-pptx/
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
- C++
- Aspose.Slides
description: "Конвертировать ODP в PPTX с помощью Aspose.Slides для C++. Чистые примеры кода, советы по пакетной обработке и результаты высокого качества - без PowerPoint."
---

## **Конвертация ODP в PPTX**

Aspose.Slides для .NET предоставляет класс Presentation, представляющий файл презентации. Класс [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) теперь также может получать доступ к ODP через конструктор Presentation при создании объекта. В следующем примере показано, как преобразовать презентацию ODP в презентацию PPTX.
``` cpp
// Путь к каталогу документов.
String dataDir = GetDataPath();

// Открыть файл ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Сохранение презентации ODP в формат PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Пример в реальном времени**

Вы можете посетить веб приложение [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), построенное с использованием **Aspose.Slides API**. Приложение демонстрирует, как можно реализовать конвертацию ODP в PPTX с помощью Aspose.Slides API.

## **Часто задаваемые вопросы**

**Нужно ли устанавливать Microsoft PowerPoint или LibreOffice для конвертации ODP в PPTX?**

Нет. Aspose.Slides работает автономно и не требует сторонних приложений для чтения или записи ODP/PPTX.

**Сохраняются ли мастер‑слайды, макеты и темы при конвертации?**

Да. Библиотека использует полную объектную модель презентации и сохраняет структуру, включая мастер‑слайды и макеты, поэтому дизайн остаётся корректным после конвертации.

**Можно ли конвертировать защищённые паролем файлы ODP?**

Да. Aspose.Slides поддерживает обнаружение защиты, открытие и работу с [защищённые презентации](/slides/ru/cpp/password-protected-presentation/) (включая ODP), когда вы предоставляете пароль, а также настройку шифрования и доступ к свойствам документа.

**Подойдёт ли Aspose.Slides для облачных или REST‑ориентированных сервисов конвертации?**

Да. Вы можете использовать локальную библиотеку в своем бэкенде или [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); оба варианта поддерживают конвертацию ODP → PPTX.
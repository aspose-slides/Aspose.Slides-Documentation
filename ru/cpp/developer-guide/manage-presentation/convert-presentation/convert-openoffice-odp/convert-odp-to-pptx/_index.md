---
title: Преобразовать ODP в PPTX на C++
linktitle: ODP в PPTX
type: docs
weight: 10
url: /ru/cpp/convert-odp-to-pptx/
keywords:
- преобразовать OpenDocument
- преобразовать презентацию
- преобразовать слайд
- преобразовать ODP
- OpenDocument в PPTX
- ODP в PPTX
- сохранить ODP как PPTX
- экспортировать ODP в PPTX
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Преобразуйте ODP в PPTX с помощью Aspose.Slides для C++. Чистые примеры кода, советы по пакетной обработке и результаты высокого качества - PowerPoint не требуется."
---

## **Преобразование ODP в PPTX**

Aspose.Slides for .NET предлагает класс Presentation, который представляет файл презентации. [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) класс теперь также может получить доступ к ODP через конструктор Presentation при создании объекта. Ниже приведён пример, показывающий, как преобразовать ODP‑презентацию в PPTX‑презентацию.
``` cpp
// Путь к каталогу документов.
String dataDir = GetDataPath();

// Открыть файл ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Сохранение презентации ODP в формате PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Пример**

Вы можете посетить веб‑приложение [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), построенное с **Aspose.Slides API.** Приложение демонстрирует, как можно реализовать преобразование ODP в PPTX с помощью Aspose.Slides API.

## **Вопросы и ответы**

**Нужно ли устанавливать Microsoft PowerPoint или LibreOffice для преобразования ODP в PPTX?**

Нет. Aspose.Slides работает автономно и не требует сторонних приложений для чтения или записи ODP/PPTX.

**Сохраняются ли мастер‑слайды, макеты и темы при преобразовании?**

Да. Библиотека использует полную модель объекта презентации и сохраняет структуру, включая мастер‑слайды и макеты, поэтому дизайн остаётся корректным после преобразования.

**Можно ли преобразовать ODP‑файлы, защищённые паролем?**

Да. Aspose.Slides поддерживает обнаружение защиты, открытие и работу с [защищёнными презентациями](/slides/ru/cpp/password-protected-presentation/) (в том числе ODP), когда вы предоставляете пароль, а также настройку шифрования и доступ к свойствам документа.

**Подходит ли Aspose.Slides для облачных или REST‑основанных сервисов конвертации?**

Да. Вы можете использовать локальную библиотеку в своём бэкенде или [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); оба варианта поддерживают преобразование ODP → PPTX.
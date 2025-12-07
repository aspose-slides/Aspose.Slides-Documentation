---
title: П转换 ODP в PPTX на C++
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
description: "Преобразуйте ODP в PPTX с помощью Aspose.Slides для C++. Чистые примеры кода, советы по пакетной обработке и высококачественные результаты — PowerPoint не требуется."
---

## **Конвертация ODP в PPTX**

Aspose.Slides for .NET предоставляет класс Presentation, который представляет файл презентации. [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) класс теперь также может получать доступ к ODP через конструктор Presentation при создании объекта. Следующий пример показывает, как сконвертировать презентацию ODP в презентацию PPTX.
```cpp
// Путь к каталогу документов.
String dataDir = GetDataPath();

// Открыть файл ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Сохранение презентации ODP в формате PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Пример в работе**

Вы можете посетить веб приложение [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), построенное с помощью **Aspose.Slides API**. Приложение демонстрирует, как можно реализовать конвертацию ODP в PPTX с использованием Aspose.Slides API.

## **FAQ**

**Нужно ли устанавливать Microsoft PowerPoint или LibreOffice для конвертации ODP в PPTX?**

Нет. Aspose.Slides работает автономно и не требует сторонних приложений для чтения или записи ODP/PPTX.

**Сохраняются ли мастер слайды, макеты и темы при конвертации?**

Да. Библиотека использует полную объектную модель презентации и сохраняет структуру, включая мастер слайды и макеты, поэтому дизайн остаётся корректным после конвертации.

**Можно ли конвертировать защищённые паролем файлы ODP?**

Да. Aspose.Slides поддерживает обнаружение защиты, открытие и работу с [защищённые презентации](/slides/ru/cpp/password-protected-presentation/) (включая ODP), когда вы предоставляете пароль, а также настройку шифрования и доступ к свойствам документа.

**Подходит ли Aspose.Slides для облачных или REST-ориентированных сервисов конвертации?**

Да. Вы можете использовать локальную библиотеку в своём бэкенде или [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); оба варианта поддерживают конвертацию ODP → PPTX.
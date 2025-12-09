---
title: "Как извлечь текст из файлов PPT, PPTX и ODP с помощью Open XML SDK в .NET"
linktitle: Open XML SDK
type: docs
weight: 20
url: /ru/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- облачные платформы
- интеграция с облаком
- Open XML SDK
- извлечение текста из PPTX
- обработка слайдов в .NET
- извлечение текста из презентации
- мастер-слайд
- заметки спикера
- извлечение текста со слайдов
- C#
description: "Узнайте, как извлекать текст из PPT, PPTX и ODP в .NET с помощью Open XML SDK, используя доступ к XML, советы по производительности и обходные пути конвертации для облачных приложений."
---

# Извлечение текста из PPT, PPTX, ODP с использованием Open XML SDK

## Open XML SDK

**Open XML SDK** предоставляет высоко структурированный и эффективный метод извлечения текста из файлов презентаций — особенно **PPTX**, который соответствует стандарту Open XML. Предоставляя прямой доступ к базовому XML, этот SDK обеспечивает более быструю и гибкую работу с содержимым слайдов по сравнению с традиционными методами.

## Прямой доступ к XML

- **Анализировать текст напрямую**: Open XML SDK позволяет извлекать текст из XML‑частей без рендеринга слайдов.
- **Структурированные элементы**: Поскольку текст хранится в четко определённых XML‑тегах, его проще получать и обрабатывать.

### Пример: Извлечение текста напрямую из XML‑содержимого слайда
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```


## Преимущества производительности

- **Быстрое извлечение**: Обходит накладные расходы на открытие PowerPoint или других высокоуровневых API.
- **Низкое потребление памяти**: Доступ только к релевантным XML‑частям, что снижает использование ресурсов.
- **Не требуется Microsoft PowerPoint**: Освобождает от дополнительных требований к установке.

### Пример: Эффективное извлечение текста без загрузки всей презентации
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```


## Идентификация текстовых элементов

### Особенности извлечения текста из презентаций

При извлечении текста из презентаций учитывайте следующие факторы:

- **Текст может находиться в разных разделах**: Обычные слайды, слайды‑мастер, макеты или заметки выступающего.
- **Стандартные плейсхолдеры**: Слайды‑мастер и макеты могут содержать плейсхолдеры (например, «Click to edit Master title style»), которые не являются реальным содержимым презентации.
- **Фильтрация пустого или скрытого текста**: Некоторые элементы могут быть пустыми или не предназначенными для отображения.

### Теги, содержащие текст

В файле **PPTX** текст обычно хранится в:
- элементах `<a:t>` внутри `<a:p>` (абзацы)
- элементах `<a:r>` (текстовые сегменты внутри абзацев)

### Пример: Извлечение всех текстовых элементов со слайда
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## ODP и PPT

### Невозможность прямого извлечения текста

- В отличие от **PPTX**, **PPT** (бинарный формат) и **ODP** (OpenDocument Presentation) **не поддерживаются** Open XML SDK.
- **PPT** хранит содержимое в закрытом бинарном формате, что усложняет извлечение текста.
- **ODP** использует **OpenDocument XML**, который структурно отличается от PPTX.

### Обходное решение: Конвертация в PPTX

Чтобы извлечь текст из **PPT** или **ODP**, рекомендуется следующий подход:

1. **Конвертировать PPT → PPTX** с помощью PowerPoint или стороннего инструмента.  
2. **Конвертировать ODP → PPTX** через LibreOffice или PowerPoint.  
3. **Извлечь текст** из полученного PPTX с использованием Open XML SDK.

### Пример: Конвертация ODP в PPTX через командную строку LibreOffice
```sh
soffice --headless --convert-to pptx presentation.odp
```


## Поддерживаемые платформы и фреймворки

- **Windows**: .NET Framework 4.6.1 и выше, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **Облачные среды**: Microsoft Azure Functions, AWS Lambda (.NET Core), контейнеры Docker.
- **Совместимость с офисными приложениями**: Не требуется установка Microsoft Office.
- **Поддерживаемые языки программирования**: Open XML SDK можно использовать с **C#**, **VB.NET**, **F#** и другими языками, поддерживаемыми .NET.

## Заключение

Использование **Open XML SDK** для **извлечения текста из PPTX** обеспечивает как **эффективность**, так и **четкость**, тогда как **PPT и ODP** требуют первоначального шага конвертации для **плавной обработки**. Такой подход гарантирует **высокую производительность**, **гибкость** и **широкую совместимость** с современными приложениями .NET.
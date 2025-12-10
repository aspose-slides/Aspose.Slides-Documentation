---
title: "Как извлекать текст из файлов PPT, PPTX и ODP с помощью Open XML SDK в .NET"
linktitle: "Open XML SDK"
type: docs
weight: 20
url: /ru/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- "облачные платформы"
- "облачная интеграция"
- "Open XML SDK"
- "извлечение текста PPTX"
- ".NET обработка слайдов"
- "извлечение текста презентаций"
- "мастер‑слайд"
- "заметки докладчика"
- "извлечение текста со слайдов"
- "C#"
description: "Узнайте, как извлекать текст из PPT, PPTX и ODP в .NET с помощью Open XML SDK, используя доступ к XML, рекомендации по производительности и обходные пути конвертации для облачных приложений."
---

## **Open XML SDK**

**Open XML SDK** предоставляет высоко структурированный и эффективный метод извлечения текста из файлов презентаций — особенно **PPTX**, которые соответствуют стандарту Open XML. Предоставляя прямой доступ к базовому XML, этот SDK обеспечивает более быструю и гибкую работу с содержимым слайдов по сравнению с традиционными методами.

## **Direct XML Access**

- **Analyze Text Directly**: **Open XML SDK** позволяет извлекать текст из XML‑частей без рендеринга слайдов.
- **Structured Elements**: Поскольку текст хранится в четко определенных XML‑тегах, его проще получать и обрабатывать.

### **Пример: Извлечение текста непосредственно из XML‑содержимого слайда**
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


## **Преимущества производительности**

- **Faster Extraction**: Обходит накладные расходы на открытие PowerPoint или других высокоуровневых API.
- **Lower Memory Usage**: Доступ только к релевантным XML‑частям, уменьшая потребление ресурсов.
- **No Microsoft PowerPoint Needed**: Освобождает от необходимости установки Microsoft PowerPoint.

### **Пример: Эффективное извлечение текста без загрузки полной презентации**
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


## **Идентификация текстовых элементов**

### **Особенности извлечения текста из презентаций**

При извлечении текста из презентаций учитывайте следующие моменты:

- **Text May Reside in Different Sections**: Обычные слайды, слайды‑шаблоны, макеты или заметки выступающего.
- **Default Placeholders**: Слайды‑шаблоны и макеты могут содержать заполнительные элементы (например, «Щелкните, чтобы отредактировать стиль заголовка шаблона»), которые не являются реальным содержимым презентации.
- **Filtering Empty or Hidden Text**: Некоторые элементы могут быть пустыми или не предназначенными для отображения.

### **Теги, содержащие текст**

В файле **PPTX** текст обычно хранится в:

- элементами `<a:t>` внутри `<a:p>` (абзацы)
- элементами `<a:r>` (текстовые сегменты внутри абзацев)

### **Пример: Извлечение всех текстовых элементов со слайда**
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## **ODP и PPT**

### **Невозможность прямого извлечения текста**

- В отличие от **PPTX**, **PPT** (бинарный формат) и **ODP** (презентация OpenDocument) **не поддерживаются** Open XML SDK.
- **PPT** хранит содержимое в закрытом бинарном формате, что усложняет извлечение текста.
- **ODP** использует **OpenDocument XML**, который структурно отличается от PPTX.

### **Обходной путь: Конвертация в PPTX**

Для извлечения текста из **PPT** или **ODP** рекомендуется следующий подход:

1. **Convert PPT → PPTX** с помощью PowerPoint или стороннего инструмента.  
2. **Convert ODP → PPTX** через LibreOffice или PowerPoint.  
3. **Extract text** из нового PPTX с помощью Open XML SDK.

### **Пример: Конвертация ODP в PPTX через командную строку LibreOffice**
```sh
soffice --headless --convert-to pptx presentation.odp
```


## **Поддерживаемые платформы и фреймворки**

- **Windows**: .NET Framework 4.6.1 и выше, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **Cloud Environments**: Microsoft Azure Functions, AWS Lambda (.NET Core), Docker‑контейнеры.
- **Compatibility with Office Applications**: Не требуется установка Microsoft Office.
- **Supported Programming Languages**: Open XML SDK можно использовать с **C#**, **VB.NET**, **F#** и другими поддерживаемыми .NET языками.

## **Заключение**

Использование **Open XML SDK** для извлечения текста из **PPTX** обеспечивает как эффективность, так и ясность, тогда как **PPT** и **ODP** требуют начального шага конвертации для корректной обработки. Применение этого подхода гарантирует **высокую производительность**, **гибкость** и **широкую совместимость** с современными .NET‑приложениями.
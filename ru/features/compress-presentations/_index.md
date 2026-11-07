---
title: Сжатие презентаций
description: Уменьшить размер презентации за счёт сжатия изображений и удаления неиспользуемого контента.
type: docs
url: /ru/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Обзор**

Сжимайте изображения, удаляйте области обрезанных картинок, когда они больше не нужны, и выбирайте настройки сжатия презентации перед сохранением. Это полезно для наборов с большими фотографиями или повторяющимися медиафайлами. Сэкономленная величина зависит от содержимого и выбранных настроек.

## **Пример использования**

Этот пример на C# загружает `input.pptx`, сжимает презентацию и сохраняет её как `compressed.pptx`.

Используйте Aspose.Slides for .NET 26.11 или новее. Для настройки см. [Установить Aspose.Slides for .NET](/slides/ru/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **Часто задаваемые вопросы**

### **Это переключатель для оптимизации всего файла?**

Aspose.Slides for .NET 26.11 добавляет [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), который сочетает удаление неиспользуемых макетов/шаблонов, подмножество внедрённых шрифтов и сжатие изображений с разрешением 150 DPI. Он постоянно удаляет области обрезанных изображений. Для обработки только изображений используйте [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); для более тонкого контроля смотрите [пример сжатия отдельного изображения](/slides/ru/net/examples/optimization-batch/compression/). Эти новые вспомогательные средства специфичны для указанной версии .NET; проверьте соответствующее руководство для других SDK.

### **Изменяет ли сжатие изображений редактируемый текст или диаграммы?**

Сжатие изображений направлено на данные изображений, а не на редактируемый текст или данные диаграмм. Проверьте изображения, так как изменение размера или повторное сжатие может уменьшить их детализацию.

### **Как выбрать разрешение для изображений в презентации?**

Выберите целевое значение, исходя из размера отображаемого изображения и предполагаемого использования на экране или при печати. Сохраняйте более высокое разрешение для больших дисплеев, печати и детализированных схем, и сравните полученный результат перед удалением оригинала.

## **Руководства**

- [Сжать всю презентацию в .NET](/slides/ru/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Оптимизировать управление изображениями в презентациях в .NET](/slides/ru/net/image/)

Связанная функция: [Удалить неиспользуемые шаблоны, макеты и медиа](/slides/ru/features/remove-unused-content/).

## Выполняемые примеры .NET

- [Уменьшить размер презентации](/slides/ru/net/examples/optimization-batch/compression/)
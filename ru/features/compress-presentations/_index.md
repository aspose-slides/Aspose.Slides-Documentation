---
title: Сжать презентации
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

Сжимайте изображения, удаляйте обрезанные области изображений, когда они больше не нужны, и выбирайте настройки сжатия презентации перед сохранением. Это полезно для наборов с большими фотографиями или повторяющимися медиафайлами. Сэкономленная ёмкость зависит от содержимого и выбранных настроек.

## **Пример использования**

Этот пример на C# загружает `input.pptx`, сжимает презентацию и сохраняет её как `compressed.pptx`.

Используйте Aspose.Slides for .NET 26.11 или позже. Для настройки см. [Установить Aspose.Slides for .NET](/slides/ru/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![Идентично масштабированные изображения до и после сжатия, с измеренными столбцами размера PPTX файла и сохранёнными размерами изображения.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Измерено на одном синтетическом тесте с сеткой деталей: 584,030 → 128,323 байт. Оба рендера используют одинаковый масштаб и рамку 252 × 336 пунктов. Сжатие удаляет обрезанные поля и уменьшает сохранённое изображение до 525 × 700 пикселей; экономия размера зависит от входных данных.*  
<!-- visual-explanation:compress-presentations:end -->

## **Часто задаваемые вопросы**

### **Это переключатель единой оптимизации файла?**

Aspose.Slides for .NET 26.11 добавляет [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), который объединяет удаление неиспользуемых макетов/шаблонов, подмножество встроенных шрифтов и сжатие изображений с разрешением 150 DPI. Он постоянно удаляет обрезанные области изображений. Для обработки только изображений используйте [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); для более тонкой настройки см. [пример сжатия отдельных изображений](/slides/ru/net/examples/optimization-batch/compression/). Начиная с версии 26.11, тот же вызов для всей презентации доступен также в Java, Node.js через Java, Python через .NET и C++. Пример и ссылки на этой странице предназначены для .NET.

### **Изменяет ли сжатие изображений редактируемый текст или диаграммы?**

Сжатие изображений затрагивает только данные изображений, а не редактируемый текст или данные диаграмм. Проверьте изображения, так как изменение размера или повторное сжатие может уменьшить их детализацию.

### **Как выбрать разрешение для изображений презентации?**

Выбирайте целевое значение, исходя из отображаемого размера изображения и предполагаемого использования на экране или при печати. Сохраняйте больше разрешения для больших дисплеев, печати и детализированных схем, и сравнивайте полученный результат перед удалением оригинала.

## **Руководства**

- [Сжать всю презентацию в .NET](/slides/ru/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Оптимизировать управление изображениями в презентациях в .NET](/slides/ru/net/image/)

Связанная функция: [Удалить неиспользуемые шаблоны, макеты и медиа](/slides/ru/features/remove-unused-content/).

## **Выполняемые примеры .NET**

- [Уменьшить размер презентации](/slides/ru/net/examples/optimization-batch/compression/)
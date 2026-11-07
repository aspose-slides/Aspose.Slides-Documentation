---
title: Сжатие презентаций
description: Уменьшить размер презентации с помощью сжатия изображений и сохранения настроек.
type: docs
url: /ru/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Обзор**

Сжимайте изображения, удаляйте обрезанные области изображений, когда они больше не нужны, и выбирайте параметры сжатия презентации перед сохранением. Это полезно для наборов с большими фотографиями или повторяющимися медиа. Сэкономленная величина зависит от содержимого и выбранных параметров.

## **Пример использования**

Этот пример на C# использует Aspose.Slides for .NET. Он явно генерирует градиентный PNG размером 1600 × 900 пикселей, вставляет его в небольшую рамку изображения и сохраняет *before.pptx*. Затем он сжимает это изображение до целевого разрешения 96 DPI и сохраняет *compressed.pptx*. Сравните размер обоих файлов и их превью: экономия зависит от исходного изображения и отображаемого размера.

Для настройки см. [Установить Aspose.Slides for .NET](/slides/ru/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **FAQ**

### **Это единый переключатель оптимизации всего файла?**

Aspose.Slides for .NET 26.11 добавляет [Compress.CompressPresentation](/slides/ru/net/low-code-presentation-operations/#compress-the-whole-presentation), который объединяет удаление неиспользуемых макетов/мастеров, подмножество встроенных шрифтов и сжатие изображений до 150 DPI. Он постоянно удаляет обрезанные области изображений. Для обработки только изображений используйте Compress.CompressImages; для более тонкого контроля сохраняйте вышеуказанный процесс per-picture. Эти новые вспомогательные функции специфичны для указанной версии .NET; проверьте соответствующее руководство для других SDK.

### **Изменяется ли редактируемый текст или диаграммы при сжатии изображений?**

Сжатие изображений влияет только на данные изображений, а не на редактируемый текст или данные диаграмм. Проверьте изображения, так как изменение размера или повторное сжатие может уменьшить их детализацию.

### **Как выбрать разрешение для изображений презентации?**

Выберите целевое разрешение исходя из отображаемого размера изображения и предполагаемого использования **экран** или **печать**. Сохраните больше разрешения для **больших** дисплеев, печати и детализированных **диаграмм**, и сравните полученный вывод перед удалением оригинала.

## **Руководства**

- [Оптимизация управления изображениями в презентациях в .NET](/slides/ru/net/image/)

Связанная функция: [Удалить неиспользуемые мастера, макеты и медиа](/slides/ru/features/remove-unused-content/).

## Выполняемые примеры .NET

- [Уменьшить размер презентации](/slides/ru/net/examples/optimization-batch/compression/)
---
title: Конвертация PowerPoint в Word
type: docs
weight: 110
url: /net/convert-powerpoint-to-word/
keywords: "Конвертация PowerPoint, PPT, PPTX, Презентация, Word, DOCX, DOC, PPTX в DOCX, PPT в DOC, PPTX в DOC, PPT в DOCX, C#, Csharp, .NET, Aspose.Slides"
description: "Конвертация презентации PowerPoint в Word на C# или .NET"
---

Если вы планируете использовать текстовый контент или информацию из презентации (PPT или PPTX) новыми способами, вам может быть полезно конвертировать презентацию в Word (DOC или DOCX).

* По сравнению с Microsoft PowerPoint, приложение Microsoft Word лучше оснащено инструментами или функциональностью для работы с контентом.
* Кроме функций редактирования в Word, вы также можете воспользоваться улучшенными возможностями сотрудничества, печати и обмена.

{{% alert color="primary" %}}

Вы можете попробовать наш [**Онлайн-конвертер презентаций в Word**](https://products.aspose.app/slides/conversion/ppt-to-word), чтобы увидеть, какие преимущества вы можете получить от работы с текстовым контентом слайдов.

{{% /alert %}}

### **Aspose.Slides и Aspose.Words**

Для конвертации файла PowerPoint (PPTX или PPT) в Word (DOCX или DOCX) вам понадобятся как [Aspose.Slides для .NET](https://products.aspose.com/slides/net/), так и [Aspose.Words для .NET](https://products.aspose.com/words/net/).

Как самостоятельный API, [Aspose.Slides](https://products.aspose.app/slides) для .NET предоставляет функции, которые позволяют извлекать текст из презентаций.

[Aspose.Words](https://docs.aspose.com/words/net/) — это продвинутый API для обработки документов, который позволяет приложениям генерировать, изменять, конвертировать, отображать, печатать файлы и выполнять другие задачи с документами без использования Microsoft Word.

## **Конвертация PowerPoint в Word**

1. Добавьте эти пространства имен в ваш файл program.cs:

   ```c#
   using System;
   using System.Drawing.Imaging;
   using System.IO;
   using Aspose.Slides;
   using Aspose.Words;
   using SkiaSharp;
   ```

2. Используйте этот фрагмент кода для конвертации PowerPoint в Word:

   ```c#
   using var presentation = new Presentation();
   var doc = new Document();
   var builder = new DocumentBuilder(doc);
   foreach (var slide in presentation.Slides)
   {
      // генерирует и вставляет изображение слайда
      using var bitmap = slide.GetThumbnail(1, 1);
      using var stream = new MemoryStream();
      bitmap.Save(stream, ImageFormat.Png);
      stream.Seek(0, SeekOrigin.Begin);
      using var skBitmap = SKBitmap.Decode(stream);
      builder.InsertImage(skBitmap);
   
      // вставляет тексты слайда
      foreach (var shape in slide.Shapes)
      {
         if (shape is AutoShape autoShape)
         {
            builder.Writeln(autoShape.TextFrame.Text);
         }
      }
   
      builder.InsertBreak(BreakType.PageBreak);
   }
   doc.Save("document.docx");
   ```
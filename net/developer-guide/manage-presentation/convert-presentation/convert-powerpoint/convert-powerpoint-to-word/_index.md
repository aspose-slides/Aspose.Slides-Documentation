---
title: Convert PowerPoint to Word
type: docs
weight: 110
url: /net/convert-powerpoint-to-word
keywords: "Convert PowerPoint, PPT, PPTX, Presentation, Word, DOCX, DOC, PPTX to DOCX, PPT to DOC, PPTX to DOC, PPT to DOCX, C#, Csharp, .NET, Aspose.Slides"
description: "Convert PowerPoint Presentation to Word in C# or .NET "
---

If you plan to use textual content or information from a presentation (PPT or PPTX) in new ways, you may benefit from converting the presentation to Word (DOC or DOCX). 

* When compared to Microsoft PowerPoint, the Microsoft Word app is more equipped with tools or functionalities for content. 
* Besides the editing functions in Word, you may also benefit from enhanced collaboration, printing, and sharing features. 

{{% alert color="primary" %}} 

You may want to try out our [**Presentation to Word Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) to see what you could gain from working with textual content from slides. 

{{% /alert %}} 

### **Aspose.Slides and Aspose.Words**

To convert a PowerPoint file (PPTX or PPT) to Word (DOCX or DOCX), you need both [Aspose.Slides for .NET](https://products.aspose.com/slides/net/) and [Aspose.Words for .NET](https://products.aspose.com/words/net/).

As a standalone API, [Aspose.Slides](https://products.aspose.app/slides) for .NET provides functions that allow you to extract texts from presentations. 

[Aspose.Words](https://docs.aspose.com/words/net/) is an advanced document processing API that allows applications to generate, modify, convert, render, print files, and perform other tasks with documents without utilizing Microsoft Word.

## **Convert PowerPoint to Word**

1. Add these namespaces to your program.cs file:

   ```c#
   using System;
   using System.Drawing.Imaging;
   using System.IO;
   using Aspose.Slides;
   using Aspose.Words;
   using SkiaSharp;
   ```

2. Use this code snippet to convert the PowerPoint to Word:

   ```c#
   using var presentation = new Presentation();
   var doc = new Document();
   var builder = new DocumentBuilder(doc);
   foreach (var slide in presentation.Slides)
   {
      // generates and inserts slide image
      using var bitmap = slide.GetThumbnail(1, 1);
      using var stream = new MemoryStream();
      bitmap.Save(stream, ImageFormat.Png);
      stream.Seek(0, SeekOrigin.Begin);
      using var skBitmap = SKBitmap.Decode(stream);
      builder.InsertImage(skBitmap);
   
      // inserts slide's texts
      foreach (var shape in slide.Shapes)
      {
         if (shape is AutoShape autoShape)
         {
            builder.Writeln(autoShape.TextFrame.Text);
         }
      }
   
      builder.InsertBreak(BreakType.PageBreak);
   }
   ```
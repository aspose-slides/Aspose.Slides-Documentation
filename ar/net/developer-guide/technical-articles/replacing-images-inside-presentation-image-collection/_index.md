---
title: استبدال الصور داخل مجموعة صور العرض
type: docs
weight: 110
url: /net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

تتيح Aspose.Slides لـ .NET إمكانية استبدال الصور المضافة في أشكال الشريحة. يشرح هذا المقال كيفية استبدال الصورة المضافة في مجموعة صور العرض باستخدام طرق مختلفة.

{{% /alert %}} 
## **استبدال الصورة داخل مجموعة صور العرض**
تقدم Aspose.Slides لـ .NET طرق API بسيطة لاستبدال الصور داخل مجموعة صور العرض. يرجى اتباع الخطوات التالية:

1. تحميل ملف العرض الذي يحتوي على الصورة باستخدام [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. تحميل صورة من ملف في مصفوفة بايت.
1. استبدال الصورة المستهدفة بصورة جديدة في مصفوفة بايت.
1. في الطريقة الثانية، تحميل الصورة في كائن Image واستبدال الصورة المستهدفة بالصورة المحملة.
1. في الطريقة الثالثة، استبدال الصورة بصورة تم إضافتها مسبقًا في مجموعة صور العرض.
1. كتابة العرض المعدل كملف PPTX.

```c#
//Instantiate the presentation
using Presentation presentation = new Presentation("presentation.pptx");

//the first way
byte[] data = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(data);

//the second way
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

//the third way
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

//Save the presentation
presentation.Save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
```
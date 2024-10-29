---
title: استبدال الصور داخل مجموعة صور العرض
type: docs
weight: 80
url: /ar/java/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

تجعل Aspose.Slides لـ Java من الممكن استبدال الصور في أشكال الشرائح. يشرح هذا المقال كيفية استبدال صورة تمت إضافتها إلى مجموعة صور العرض باستخدام طرق مختلفة.

{{% /alert %}} 
## **استبدال صورة داخل مجموعة صور العرض**
تقدم Aspose.Slides لـ Java طرق API بسيطة لاستبدال الصور داخل مجموعة صور العرض. يرجى اتباع الخطوات أدناه:

1. قم بتحميل ملف العرض مع الصورة داخله باستخدام فصل العرض.
1. قم بتحميل صورة من ملف في مصفوفة بايت.
1. استبدل الصورة المستهدفة بصورة جديدة في مصفوفة بايت.
1. في الطريقة الثانية، قم بتحميل الصورة في كائن صورة واستبدل الصورة المستهدفة بالصورة التي تم تحميلها.
1. في الطريقة الثالثة، استبدل الصورة بصورة تم إضافتها مسبقًا في مجموعة صور العرض.
1. قم بكتابة العرض المعدل كملف PPTX.

```java
//Instantiate the presentation
Presentation presentation = new Presentation("presentation.pptx");

//the first way
byte[] data = Files.readAllBytes(Paths.get("image0.jpeg"));
IPPImage oldImage = presentation.getImages().get_Item(0);
oldImage.replaceImage(data);

//the second way
IImage newImage = Images.fromFile("image1.png");
oldImage = presentation.getImages().get_Item(1);
oldImage.replaceImage(newImage);
newImage.dispose();

//the third way
oldImage = presentation.getImages().get_Item(2);
oldImage.replaceImage(presentation.getImages().get_Item(3));

//Save the presentation
presentation.save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
presentation.dispose();
```
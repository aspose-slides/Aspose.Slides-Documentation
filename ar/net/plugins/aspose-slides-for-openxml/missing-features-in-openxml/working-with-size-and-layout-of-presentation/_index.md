---
title: العمل مع حجم وتخطيط العرض
type: docs
weight: 90
url: /ar/net/working-with-size-and-layout-of-presentation/
---

**SlideSize.Type** و **SlideSize.Size** هي الخصائص في فئة العرض والتي يمكن تعيينها أو الحصول عليها كما هو موضح أدناه في المثال.
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//إ instantiate كائن Presentation يمثل ملف عرض 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//تعيين حجم الشريحة للعرض الناتجة ليكون حسب المصدر

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//حفظ العرض على القرص

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **تنزيل كود العينة**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **تنزيل المثال القابل للتشغيل**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Working With Size and Layout/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

للمزيد من التفاصيل، قم بزيارة [العمل مع حجم وتخطيط الشريحة](/slides/ar/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}
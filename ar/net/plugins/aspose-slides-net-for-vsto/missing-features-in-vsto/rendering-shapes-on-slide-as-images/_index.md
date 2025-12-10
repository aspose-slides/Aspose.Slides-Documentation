---
title: عرض الأشكال على الشريحة كصور
type: docs
weight: 120
url: /ar/net/rendering-shapes-on-slide-as-images/
---

هذا يغطي وظيفتين رئيسيتين:

- استخراج صورة من الشكل إلى ملف.
- استخراج الأشكال كملف صورة.
## **استخراج صورة من شكل إلى ملف**
يتم إضافة الصور في خلفية الشريحة والأشكال. في بعض الأحيان، يلزم استخراج الصور المضافة في أشكال العرض التقديمي.

في **Aspose.Slides for .NET**، يمكن إضافة الصور إلى شكل الشريحة وخلفية الشريحة. يتم إضافة الصور في **ImageCollectionEx** الخاصة بالعرض التقديمي. في هذا المثال، سنستعرض كل شكل داخل كل شريحة من العرض التقديمي ونرى ما إذا كان هناك أي صورة مضافة إلى شكل الشريحة. إذا تم العثور على صورة لأي شكل، سنستخرجها ونحفظها في ملف. مقتطف الشيفرة التالي سيؤدي الغرض.
``` csharp

 //الوصول إلى العرض التقديمي

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//الوصول إلى الشريحة الأولى

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// الوصول إلى الشكل الذي يحتوي على صورة

		ShapeEx sh = sl.Shapes[j];

		if (sh is AutoShapeEx)

		{

			AutoShapeEx ashp = (AutoShapeEx)sh;

			if (ashp.FillFormat.FillType == FillTypeEx.Picture)

			{

				img = ashp.FillFormat.PictureFillFormat.Picture.Image;

				ImageType = img.ContentType;

				ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);

				ifImageFound = true;

			}

		}

		else if (sh is PictureFrameEx)

		{

			PictureFrameEx pf = (PictureFrameEx)sh;

			if (pf.FillFormat.FillType == FillTypeEx.Picture)

			{

				img = pf.PictureFormat.Picture.Image;

				ImageType = img.ContentType;

				ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);

				ifImageFound = true;

			}

		}


		//

		//تحديد تنسيق الصورة المطلوب

		if (ifImageFound)

		{

			switch (ImageType)

			{

				case "jpeg":

					Format = System.Drawing.Imaging.ImageFormat.Jpeg;

					break;

				case "emf":

					Format = System.Drawing.Imaging.ImageFormat.Emf;

					break;

				case "bmp":

					Format = System.Drawing.Imaging.ImageFormat.Bmp;

					break;

				case "png":

					Format = System.Drawing.Imaging.ImageFormat.Png;

					break;

				case "wmf":

					Format = System.Drawing.Imaging.ImageFormat.Wmf;

					break;

				case "gif":

					Format = System.Drawing.Imaging.ImageFormat.Gif;

					break;

			}

			//

			img.Image.Save(path+"ResultedImage"+"." + ImageType, Format);

		}

		ifImageFound = false;

``` 
## **Download Sample Code**
- [Codeplex](http://goo.gl/G3JI6p)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Extract Shapes as Image Files**
```cs
//إنشاء كائن Presentation الذي يمثل ملف PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Accessing a slide using its slide position
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //الحصول على صورة المصغرة للشكل
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //حفظ صورة المصغرة بصيغة gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```


*ملاحظة:* استخراج الشكل مدعوم حالياً في ملف .ppt.
## **تحميل مثال الشيفرة**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812536)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
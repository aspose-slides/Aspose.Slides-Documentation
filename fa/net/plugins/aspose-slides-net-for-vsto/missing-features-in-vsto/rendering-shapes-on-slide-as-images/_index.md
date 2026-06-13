---
title: رندر کردن اشکال روی اسلاید به‌عنوان تصاویر
type: docs
weight: 120
url: /fa/net/rendering-shapes-on-slide-as-images/
---
این شامل دو عملکرد اصلی است:

- استخراج تصویر از شکل به فایل.
- استخراج اشکال به‌عنوان فایل تصویر.
## **استخراج یک تصویر از یک شکل به یک فایل**
تصاویر در پس‌زمینه اسلاید و اشکال اضافه می‌شوند. گاهی اوقات نیاز به استخراج تصاویر اضافه شده در اشکال ارائه است.

در **Aspose.Slides for .NET** می‌توان تصاویر را به شکل اسلاید و پس‌زمینه اسلاید اضافه کرد. تصاویر در **ImageCollectionEx** ارائه اضافه می‌شوند. در این مثال ما هر شکل داخل هر اسلاید ارائه را می‌گردیم تا بررسی کنیم آیا تصویر در شکل اسلاید اضافه شده است یا خیر. اگر تصویر برای هر شکل یافت شد، آن را استخراج کرده و در فایل ذخیره می‌کنیم. قطعه کد زیر این هدف را برآورده می‌کند.

``` csharp

 //دسترسی به ارائه

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//دسترسی به اولین اسلاید

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// دسترسی به شکل با تصویر

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

		//تنظیم قالب تصویر دلخواه

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
## **بارگیری کد نمونه**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **استخراج اشکال به عنوان فایل‌های تصویر**
```cs
// نمادسازی شی Presentation که یک فایل PPT را نشان می‌دهد
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

// دسترسی به اسلاید با استفاده از موقعیت آن
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    // دریافت تصویر بندانگشتی شکل
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        // ذخیره تصویر بندانگشتی در قالب gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*توجه:* استخراج شکل در حال حاضر در فایل .ppt پشتیبانی می‌شود.
## **بارگیری کد نمونه**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
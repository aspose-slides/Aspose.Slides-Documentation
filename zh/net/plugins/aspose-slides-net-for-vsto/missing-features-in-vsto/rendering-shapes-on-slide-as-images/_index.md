---
title: 在幻灯片上将形状渲染为图像
type: docs
weight: 120
url: /net/rendering-shapes-on-slide-as-images/
---

这涵盖了两个主要功能：

- 从形状提取图像到文件。
- 将形状提取为图像文件。
## **从形状提取图像到文件**
图像可以添加到幻灯片背景和形状中。有时，需要提取添加到演示文稿形状中的图像。

在 **Aspose.Slides for .NET** 中，图像可以添加到幻灯片形状和幻灯片背景中。这些图像添加在演示文稿的 **ImageCollectionEx** 中。在此示例中，我们将遍历演示文稿每个幻灯片中的每个形状，查看幻灯片形状中是否添加了任何图像。如果找到任何形状的图像，我们将提取并将其保存到文件中。以下代码片段将满足该目的。

``` csharp

 //访问演示文稿

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//访问第一个幻灯片

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// 访问包含图片的形状

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

		//设置所需的图片格式

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
## **下载示例代码**
- [Codeplex](http://goo.gl/G3JI6p)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **将形状提取为图像文件**
```cs
//实例化表示PPT文件的演示对象
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//使用其幻灯片位置访问幻灯片
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //获取形状的缩略图图像
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //以gif格式保存缩略图图像
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*注意：* 当前仅支持从.ppt文件中提取形状。
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812536)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
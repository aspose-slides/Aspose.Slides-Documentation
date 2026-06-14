---
title: 在投影片上將形狀渲染為圖像
type: docs
weight: 120
url: /zh-hant/net/rendering-shapes-on-slide-as-images/
---
本節涵蓋兩個主要功能：

- 從形狀提取圖像到檔案。
- 將形狀提取為圖像檔案。

## **從形狀提取圖像到檔案**
圖像可以加入投影片背景和形狀中。有時需要提取投影片形狀中加入的圖像。

在 **Aspose.Slides for .NET** 中，圖像可以加入投影片形狀和投影片背景。圖像會加入至簡報的 **ImageCollectionEx**。在本範例中，我們將遍歷簡報中每張投影片的每個形狀，檢查是否有圖像加入於投影片形狀。若在任何形狀中找到圖像，我們將提取該圖像並儲存為檔案。以下程式碼片段可完成此目的。

``` csharp

 //存取簡報

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//存取第一張投影片

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// 存取含圖片的形狀

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

		//設定所需的圖片格式

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
## **下載範例程式碼**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)

## **將形狀提取為圖像檔案**
```cs
//實例化代表 PPT 檔案的 Presentation 物件
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//使用投影片位置存取投影片
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //取得形狀的縮圖圖像
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //以 gif 格式儲存縮圖圖像
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*註:* 目前僅支援在 .ppt 檔案中提取形狀。

## **下載範例程式碼**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
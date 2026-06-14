---
title: Kết xuất các hình dạng trên slide thành hình ảnh
type: docs
weight: 120
url: /vi/net/rendering-shapes-on-slide-as-images/
---
Phần này bao gồm hai chức năng chính:

- Trích xuất hình ảnh từ hình dạng ra tệp.
- Trích xuất các hình dạng thành tệp hình ảnh.
## **Trích xuất hình ảnh từ một hình dạng ra tệp**
Hình ảnh được chèn vào nền slide và các hình dạng. Đôi khi, cần trích xuất các hình ảnh được chèn trong các hình dạng của bản trình chiếu.

Trong **Aspose.Slides for .NET**, hình ảnh có thể được chèn vào hình dạng slide và nền slide. Các hình ảnh được lưu trong **ImageCollectionEx** của bản trình chiếu. Trong ví dụ này, chúng ta sẽ duyệt qua từng hình dạng trong mỗi slide của bản trình chiếu và kiểm tra xem có hình ảnh nào được chèn vào hình dạng slide không. Nếu tìm thấy hình ảnh cho bất kỳ hình dạng nào, chúng ta sẽ trích xuất nó và lưu vào tệp. Đoạn mã dưới đây sẽ thực hiện mục đích này.

``` csharp

 //Truy cập vào bản trình chiếu

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Truy cập vào slide đầu tiên

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Truy cập vào hình dạng có hình ảnh

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

		//Đặt định dạng hình ảnh mong muốn

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
## **Tải mã mẫu**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Trích xuất các hình dạng thành tệp hình ảnh**
```cs
//Khởi tạo đối tượng Presentation đại diện cho tệp PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Truy cập slide bằng vị trí slide của nó
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Lấy hình ảnh thu nhỏ của shape
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Lưu hình ảnh thu nhỏ dưới định dạng gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Lưu ý:* Việc trích xuất hình dạng hiện chỉ hỗ trợ trong tệp .ppt.
## **Tải mã mẫu**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
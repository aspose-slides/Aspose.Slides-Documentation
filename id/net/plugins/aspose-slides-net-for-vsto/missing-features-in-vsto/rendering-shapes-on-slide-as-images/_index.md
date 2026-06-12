---
title: Menyajikan Bentuk pada Slide sebagai Gambar
type: docs
weight: 120
url: /id/net/rendering-shapes-on-slide-as-images/
---
Ini mencakup dua fungsi utama:

- Mengekstrak Gambar dari Bentuk ke file.
- Mengekstrak Bentuk sebagai file gambar.
## **Mengekstrak Gambar dari Bentuk ke File**
Gambar ditambahkan pada latar belakang slide dan bentuk. Terkadang, diperlukan untuk mengekstrak gambar yang ditambahkan pada bentuk dalam presentasi.

Di **Aspose.Slides for .NET**, gambar dapat ditambahkan ke bentuk slide dan latar belakang slide. Gambar-gambar tersebut ditambahkan dalam **ImageCollectionEx** presentasi. Dalam contoh ini kami akan menelusuri setiap bentuk di dalam setiap slide presentasi dan memeriksa apakah ada gambar yang ditambahkan pada bentuk slide. Jika gambar ditemukan pada suatu bentuk, kami akan mengekstraknya dan menyimpannya ke file. Potongan kode berikut akan memenuhi tujuan tersebut.

``` csharp

 //Mengakses presentasi

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Mengakses slide pertama

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Mengakses bentuk dengan gambar

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

		//Menetapkan format gambar yang diinginkan

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
## **Unduh Kode Contoh**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Mengekstrak Bentuk sebagai File Gambar**
```cs
//Membuat instance objek Presentation yang mewakili file PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Mengakses slide menggunakan posisi slide
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Mendapatkan gambar thumbnail dari shape
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Menyimpan gambar thumbnail dalam format gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Catatan:* Ekstraksi bentuk saat ini didukung dalam file .ppt.
## **Unduh Kode Contoh**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
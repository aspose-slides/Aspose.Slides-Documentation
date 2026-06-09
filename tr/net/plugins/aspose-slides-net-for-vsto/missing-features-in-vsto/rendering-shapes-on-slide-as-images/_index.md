---
title: Slaytta Şekilleri Görüntü Olarak İşleme
type: docs
weight: 120
url: /tr/net/rendering-shapes-on-slide-as-images/
---
Bu, iki ana işlevi kapsar:

- Şekilden Dosyaya Görüntü Çıkartma.
- Şekilleri Görüntü Dosyası Olarak Çıkartma.

## **Şekilden Dosyaya Görüntü Çıkartma**
Görüntüler slayt arka planına ve şekillere eklenir. Bazen, sunumdaki şekillere eklenen görüntüleri çıkarmak gerekir.

**Aspose.Slides for .NET**'de, görüntüler slayt şekline ve slayt arka planına eklenebilir. Görüntüler sunumun **ImageCollectionEx**'ine eklenir. Bu örnekte, sunumdaki her slaydın içindeki her şekli dolaşacak ve slayt şekline eklenmiş bir görüntü olup olmadığını kontrol edeceğiz. Eğer herhangi bir şekil için görüntü bulunursa, onu çıkartıp bir dosyaya kaydedeceğiz. Aşağıdaki kod snippet'i bu amacı yerine getirecektir.

``` csharp

 //Sunuma erişim

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//İlk slayta erişim

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Resim içeren şekle erişim

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

		//İstenen resim formatını ayarlama

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
## **Örnek Kodu İndir**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)

## **Şekilleri Görüntü Dosyaları Olarak Çıkartma**
```cs
//Bir PPT dosyasını temsil eden Presentation nesnesini oluştur
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Slayt konumunu kullanarak bir slayta erişim
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Şeklin küçük resim görüntüsünü alma
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Küçük resim görüntüsünü gif formatında kaydetme
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Not:* Şekil çıkartma şu anda .ppt dosyalarında desteklenmektedir.
## **Örnek Kodu İndir**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
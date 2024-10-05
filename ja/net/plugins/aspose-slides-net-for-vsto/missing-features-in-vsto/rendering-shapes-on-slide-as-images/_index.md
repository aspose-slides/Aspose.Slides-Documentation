---
title: スライド上の図形を画像としてレンダリング
type: docs
weight: 120
url: /net/rendering-shapes-on-slide-as-images/
---

これには主に二つの機能が含まれています：

- 画像を図形からファイルに抽出すること。
- 図形を画像ファイルとして抽出すること。
## **図形から画像をファイルに抽出すること**
画像はスライドの背景や図形に追加されます。時には、プレゼンテーションの図形に追加された画像を抽出する必要があります。

**Aspose.Slides for .NET** では、画像をスライドの図形やスライドの背景に追加できます。画像はプレゼンテーションの **ImageCollectionEx** に追加されます。この例では、プレゼンテーションの各スライド内の各図形を走査し、スライドの図形に追加されている画像があるかどうかを確認します。どの図形に対しても画像が見つかれば、それを抽出してファイルに保存します。以下のコードスニペットがその目的に役立ちます。

``` csharp

 //プレゼンテーションにアクセスする

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//最初のスライドにアクセスする

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// 画像を持つ図形にアクセスする

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

		//希望する画像形式を設定する

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
## **サンプルコードのダウンロード**
- [Codeplex](http://goo.gl/G3JI6p)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **図形を画像ファイルとして抽出すること**
```cs
//PPTファイルを表すPresentationオブジェクトをインスタンス化する
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//スライドの位置を使ってスライドにアクセスする
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //図形のサムネイル画像を取得する
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //gif形式でサムネイル画像を保存する
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*注:*図形の抽出は現在 .ppt ファイルでサポートされています。
## **サンプルコードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812536)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
---
title: スライド上のシェイプを画像としてレンダリング
type: docs
weight: 120
url: /ja/net/rendering-shapes-on-slide-as-images/
---

これでは主に2つの機能をカバーしています:

- 画像をシェイプからファイルへ抽出する。
- シェイプを画像ファイルとして抽出する。

## **シェイプから画像をファイルに抽出する**
画像はスライドの背景やシェイプに追加されます。プレゼンテーションのシェイプに追加された画像を抽出する必要がある場合があります。

**Aspose.Slides for .NET** では、画像をスライドのシェイプや背景に追加できます。画像はプレゼンテーションの **ImageCollectionEx** に追加されます。この例では、プレゼンテーションの各スライド内のすべてのシェイプを走査し、シェイプに画像が追加されているかどうかを確認します。シェイプに画像が見つかった場合、それを抽出してファイルに保存します。以下のコードスニペットが目的を果たします。
``` csharp

 //Accessing the presentation
 //プレゼンテーションにアクセス

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Accessing the first slide
	//最初のスライドにアクセス

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Accessing the shape with picture
		//画像付きシェイプにアクセス

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

		//Setting the desired picture format
		//目的の画像フォーマットを設定

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
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Extract Shapes as Image Files**
```cs
//Instantiate the Presentation object that represents a PPT file
//PPT ファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Accessing a slide using its slide position
//スライド位置を使用してスライドにアクセス
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Getting the thumbnail image of the shape
    //シェイプのサムネイル画像を取得
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Saving the thumbnail image in gif format
        //サムネイル画像を GIF 形式で保存
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```


*Note:* シェイプの抽出は現在 .ppt ファイルでのみサポートされています。
## **サンプルコードのダウンロード**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
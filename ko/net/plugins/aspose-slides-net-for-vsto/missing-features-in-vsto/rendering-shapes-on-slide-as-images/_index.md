---
title: 슬라이드에서 도형을 이미지로 렌더링
type: docs
weight: 120
url: /ko/net/rendering-shapes-on-slide-as-images/
---
이 문서는 두 가지 주요 기능을 다룹니다:

- 도형에서 이미지를 파일로 추출하기.
- 도형들을 이미지 파일로 추출하기.
## **도형에서 이미지를 파일로 추출하기**
이미지는 슬라이드 배경과 도형에 추가됩니다. 때때로 프레젠테이션 도형에 추가된 이미지를 추출해야 할 경우가 있습니다.

**Aspose.Slides for .NET**에서는 이미지 를 슬라이드 도형 및 슬라이드 배경에 추가할 수 있습니다. 이미지는 프레젠테이션의 **ImageCollectionEx**에 추가됩니다. 이 예제에서는 프레젠테이션의 모든 슬라이드에 있는 각 도형을 순회하면서 슬라이드 도형에 이미지가 추가되어 있는지 확인합니다. 도형에서 이미지가 발견되면 이를 추출하여 파일로 저장합니다. 다음 코드 스니펫이 그 목적을 수행합니다.

``` csharp

 //프레젠테이션에 접근

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//첫 번째 슬라이드에 접근

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// 그림이 포함된 도형에 접근

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

		//원하는 그림 형식 설정

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
## **샘플 코드 다운로드**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **도형을 이미지 파일로 추출하기**
```cs
//PPT 파일을 나타내는 Presentation 객체를 인스턴스화
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//슬라이드 위치를 사용하여 슬라이드에 접근
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //도형의 썸네일 이미지를 가져오기
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //썸네일 이미지를 gif 형식으로 저장하기
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Note:* 도형 추출은 현재 .ppt 파일에서만 지원됩니다.
## **샘플 코드 다운로드**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
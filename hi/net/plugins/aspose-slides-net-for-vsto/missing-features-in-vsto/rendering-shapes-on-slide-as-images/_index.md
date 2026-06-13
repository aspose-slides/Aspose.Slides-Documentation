---
title: स्लाइड पर आकारों को छवियों के रूप में रेंडर करना
type: docs
weight: 120
url: /hi/net/rendering-shapes-on-slide-as-images/
---
यह दो मुख्य फ़ंक्शन को कवर करता है:

- Shape से छवि को फ़ाइल में निकालना।
- Shapes को छवि फ़ाइल के रूप में निकालना।
## **Shape से छवि को फ़ाइल में निकालना**
छवियाँ स्लाइड पृष्ठभूमि और आकृतियों में जोड़ी जाती हैं। कभी-कभी प्रस्तुति आकृतियों में जोड़ी गई छवियों को निकालना आवश्यक होता है।

**Aspose.Slides for .NET** में, छवियों को स्लाइड आकृति और स्लाइड पृष्ठभूमि में जोड़ा जा सकता है। इन्हें प्रस्तुति की **ImageCollectionEx** में जोड़ा जाता है। इस उदाहरण में हम प्रस्तुति की प्रत्येक स्लाइड के भीतर प्रत्येक आकृति को पार करेंगे और देखेंगे कि क्या स्लाइड आकृति में कोई छवि जोड़ी गई है। यदि किसी आकृति में छवि मिलती है, तो हम उसे निकालेंगे और फ़ाइल में सहेजेंगे। निम्नलिखित कोड स्निपेट इस उद्देश्य को पूरा करेगा।

``` csharp

 //प्रस्तुति तक पहुँच रहे हैं

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//पहली स्लाइड तक पहुँच रहे हैं

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// चित्र के साथ आकार तक पहुँच रहे हैं

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

		//वांछित चित्र फ़ॉर्मेट सेट कर रहे हैं

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
## **नमूना कोड डाउनलोड करें**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Shapes को छवि फ़ाइलों के रूप में निकालना**
```cs
//PPT फ़ाइल का प्रतिनिधित्व करने वाले Presentation ऑब्जेक्ट को इंस्टैंशिएट करें
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//स्लाइड की पोजीशन का उपयोग करके स्लाइड तक पहुँच रहे हैं
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //आकृति की थंबनेल छवि प्राप्त कर रहे हैं
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //थंबनेल छवि को gif फ़ॉर्मेट में सहेज रहे हैं
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Note:* shape का निष्कर्षण वर्तमान में .ppt फ़ाइल में समर्थित है।
## **नमूना कोड डाउनलोड करें**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
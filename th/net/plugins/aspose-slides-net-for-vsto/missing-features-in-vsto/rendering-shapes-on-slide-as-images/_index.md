---
title: การแสดงรูปร่างบนสไลด์เป็นภาพ
type: docs
weight: 120
url: /th/net/rendering-shapes-on-slide-as-images/
---
This covers two main function:

- Extracting Image from Shape to file.
- Extracting Shapes as image file.
## **สกัดภาพจากรูปร่างเป็นไฟล์**
รูปภาพจะถูกเพิ่มในพื้นหลังของสไลด์และรูปทรง บางครั้งจำเป็นต้องสกัดรูปภาพที่เพิ่มในรูปทรงของงานนำเสนอ

ใน **Aspose.Slides for .NET**, สามารถเพิ่มรูปภาพลงในรูปร่างสไลด์และพื้นหลังสไลด์ได้ รูปภาพถูกเก็บใน **ImageCollectionEx** ของงานนำเสนอ ในตัวอย่างนี้เราจะวนผ่านแต่ละรูปร่างในทุกสไลด์ของงานนำเสนอและตรวจสอบว่ามีรูปภาพใดถูกเพิ่มในรูปร่างสไลด์หรือไม่ หากพบรูปภาพสำหรับรูปร่างใด เราจะสกัดและบันทึกลงไฟล์ โค้ดตัวอย่างต่อไปนี้จะทำหน้าที่ดังกล่าว

``` csharp

 //Accessing the presentation
PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");
ImageEx img = null;
int slideIndex = 0;
String ImageType = "";
bool ifImageFound = false;
for (int i = 0; i < pres.Slides.Count; i++)
{
	slideIndex++;
	//Accessing the first slide
	SlideEx sl = pres.Slides[i];
	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;
	for (int j = 0; j < sl.Shapes.Count; j++)
	{
		// Accessing the shape with picture
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
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **สกัดรูปร่างเป็นไฟล์ภาพ**
```cs
//สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์ PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//เข้าถึงสไลด์โดยใช้ตำแหน่งของสไลด์
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //รับภาพย่อของรูปร่าง
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //บันทึกภาพย่อในรูปแบบ gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*หมายเหตุ:* การสกัดรูปร่างในขณะนี้รองรับไฟล์ .ppt เท่านั้น.
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
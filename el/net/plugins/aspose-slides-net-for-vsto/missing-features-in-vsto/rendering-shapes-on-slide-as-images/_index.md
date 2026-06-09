---
title: Απόδοση σχημάτων στην διαφάνεια ως εικόνες
type: docs
weight: 120
url: /el/net/rendering-shapes-on-slide-as-images/
---
Αυτό καλύπτει δύο κύριες λειτουργίες:

- Εξαγωγή εικόνας από σχήμα σε αρχείο.
- Εξαγωγή σχημάτων ως αρχεία εικόνας.
## **Εξαγωγή εικόνας από σχήμα σε αρχείο**
Οι εικόνες προστίθενται στο φόντο της διαφάνειας και στα σχήματα. Μερικές φορές απαιτείται η εξαγωγή των εικόνων που έχουν προστεθεί στα σχήματα της παρουσίασης.

Στο **Aspose.Slides for .NET**, οι εικόνες μπορούν να προστεθούν σε σχήμα διαφάνειας και στο φόντο της διαφάνειας. Οι εικόνες προστίθενται στο **ImageCollectionEx** της παρουσίασης. Σε αυτό το παράδειγμα θα περάσουμε από κάθε σχήμα μέσα σε κάθε διαφάνεια της παρουσίασης και θα ελέγξουμε αν υπάρχει κάποια εικόνα προστιθέμενη στο σχήμα της διαφάνειας. Αν βρεθεί εικόνα για κάποιο σχήμα, θα την εξάγουμε και θα την αποθηκεύσουμε σε αρχείο. Το παρακάτω απόσπασμα κώδικα θα εξυπηρετήσει τον σκοπό.

``` csharp

 //Πρόσβαση στην παρουσίαση

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Πρόσβαση στην πρώτη διαφάνεια

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Πρόσβαση στο σχήμα με εικόνα

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

		//Ορισμός της επιθυμητής μορφής εικόνας

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
## **Λήψη δείγματος κώδικα**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Εξαγωγή σχημάτων ως αρχεία εικόνας**
```cs
//Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει αρχείο PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Πρόσβαση στη διαφάνεια χρησιμοποιώντας τη θέση της
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Λήψη της μικρογραφίας του σχήματος
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Αποθήκευση της μικρογραφίας σε μορφή gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Note:* Η εξαγωγή σχήματος υποστηρίζεται επί του παρόντος σε αρχείο .ppt.
## **Λήψη δείγματος κώδικα**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
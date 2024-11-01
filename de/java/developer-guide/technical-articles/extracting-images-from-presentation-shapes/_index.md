---
title: Extrahieren von Bildern aus Präsentationsformen
type: docs
weight: 100
url: /de/java/extracting-images-from-presentation-shapes/
keywords: "Bild extrahieren, PowerPoint, PPT, PPTX, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Bilder aus PowerPoint-Präsentationen in Java extrahieren"

---

{{% alert color="primary" %}} 

Bilder werden oft Formen hinzugefügt und auch häufig als Hintergründe von Folien verwendet. Die Bildobjekte werden über [IImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/), einer Sammlung von [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) Objekten, hinzugefügt. 

Dieser Artikel erklärt, wie Sie die Bilder, die in Präsentationen hinzugefügt wurden, extrahieren können. 

{{% /alert %}} 

Um ein Bild aus einer Präsentation zu extrahieren, müssen Sie das Bild zuerst suchen, indem Sie jede Folie durchgehen und dann jede Form durchgehen. Sobald das Bild gefunden oder identifiziert ist, können Sie es extrahieren und als neue Datei speichern. 

```java
    public void extractImages()
    {
        Presentation pres = new Presentation(folderPath + "ExtractImages.pptx");
        com.aspose.slides.IPPImage img = null;
        com.aspose.slides.IPPImage backImage = null;

        int slideIndex = 0;
        String imageType = "";
        boolean ifImageFound = false;
        for (int i = 0; i < pres.getSlides().size(); i++)
        {

            slideIndex++;
            //Zugriff auf die erste Folie
            ISlide sl = pres.getSlides().get_Item(i);


            //Zugriff auf die erste Folie Slide sl = pres.getSlideByPosition(i);
            if (sl.getBackground().getFillFormat().getFillType() == FillType.Picture)
            {
                //Holt das Hintergrundbild
                backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                imageType = getImageTType(backImage);

                String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "." + imageType;
                //Speichert das Bild
                backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
            } else
            {
                if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() == FillType.Picture)
                {
                    //Holt das Hintergrundbild
                    backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(backImage);

                    String imagePath = folderPath + "backImage_" + "LayoutSlide_" + slideIndex + "." + imageType;
                    //Speichert das Bild
                    backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
            }

            for (int j = 0; j < sl.getShapes().size(); j++)
            {
                // Zugriff auf die Form, die ein Bild enthält
                IShape sh = sl.getShapes().get_Item(j);

                if (sh instanceof IAutoShape)
                {
                    IAutoShape ashp = (IAutoShape) sh;
                    if (ashp.getFillFormat().getFillType() == FillType.Picture)
                    {
                        img = ashp.getFillFormat().getPictureFillFormat().getPicture().getImage();
                        imageType = getImageTType(img);
                        ifImageFound = true;
                    }
                } else if (sh instanceof IPictureFrame)
                {
                    IPictureFrame pf = (IPictureFrame) sh;
                    img = pf.getPictureFormat().getPicture().getImage();
                    imageType = getImageTType(img);
                    ifImageFound = true;
                }

                //Setzt das bevorzugte Bildformat
                if (ifImageFound)
                {
                    String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                    //Speichert das Bild
                    img.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
                ifImageFound = false;
            }
        }
    }

    private String getImageTType(IPPImage image)
    {
        String imageContentType = image.getContentType();
        imageContentType = imageContentType.substring(imageContentType.indexOf("/") + 1);
        imageContentType = imageContentType.substring(imageContentType.indexOf("-") + 1);
        return imageContentType;
    }

    private String capitalize(String str)
    {
        if (str == null || str.length() <= 1) return str;
        return str.substring(0, 1).toUpperCase() + str.substring(1);
    }
```
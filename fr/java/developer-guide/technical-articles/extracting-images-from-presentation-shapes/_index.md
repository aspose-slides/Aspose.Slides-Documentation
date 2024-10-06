---
title: Extraction d'images à partir de formes de présentation
type: docs
weight: 100
url: /java/extracting-images-from-presentation-shapes/
keywords: "Extraire image, PowerPoint, PPT, PPTX, présentation PowerPoint, Java, Aspose.Slides pour Java"
description: "Extraire des images d'une présentation PowerPoint en Java"

---

{{% alert color="primary" %}} 

Les images sont souvent ajoutées aux formes et sont également fréquemment utilisées en tant qu'arrière-plans de diapositives. Les objets image sont ajoutés via [IImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/), qui est une collection d'objets [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). 

Cet article explique comment vous pouvez extraire les images ajoutées aux présentations. 

{{% /alert %}} 

Pour extraire une image d'une présentation, vous devez d'abord localiser l'image en parcourant chaque diapositive, puis en parcourant chaque forme. Une fois que l'image est trouvée ou identifiée, vous pouvez l'extraire et la sauvegarder en tant que nouveau fichier. 

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
            //Accède à la première diapositive
            ISlide sl = pres.getSlides().get_Item(i);


            //Accède à la première diapositive Slide sl = pres.getSlideByPosition(i);
            if (sl.getBackground().getFillFormat().getFillType() == FillType.Picture)
            {
                //Récupère l'image d'arrière-plan
                backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                imageType = getImageTType(backImage);

                String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "." + imageType;
                //Sauvegarde l'image
                backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
            } else
            {
                if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() == FillType.Picture)
                {
                    //Récupère l'image d'arrière-plan
                    backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(backImage);

                    String imagePath = folderPath + "backImage_" + "LayoutSlide_" + slideIndex + "." + imageType;
                    //Sauvegarde l'image
                    backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
            }

            for (int j = 0; j < sl.getShapes().size(); j++)
            {
                // Accède à la forme contenant une image
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

                // Définit le format d'image préféré
                if (ifImageFound)
                {
                    String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                    //Sauvegarde l'image
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
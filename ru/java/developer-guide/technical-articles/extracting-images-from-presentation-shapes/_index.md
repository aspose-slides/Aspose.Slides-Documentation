---
title: Извлечение изображений из фигур в презентации
type: docs
weight: 100
url: /ru/java/extracting-images-from-presentation-shapes/
keywords: "Извлечение изображения, PowerPoint, PPT, PPTX, презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Извлечение изображений из презентации PowerPoint на Java"

---

{{% alert color="primary" %}} 

Изображения часто добавляются в фигуры и также часто используются в качестве фонов для слайдов. Объекты изображений добавляются через [IImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/), который является коллекцией объектов [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). 

Эта статья объясняет, как вы можете извлекать изображения, добавленные в презентации. 

{{% /alert %}} 

Чтобы извлечь изображение из презентации, вам необходимо сначала найти его, пройдя через каждый слайд, а затем через каждую фигуру. Как только изображение найдено или идентифицировано, вы можете извлечь его и сохранить в новом файле. 

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
            //Доступ к первому слайду
            ISlide sl = pres.getSlides().get_Item(i);


            //Доступ к первому слайду
            if (sl.getBackground().getFillFormat().getFillType() == FillType.Picture)
            {
                //Получает фоновое изображение
                backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                imageType = getImageTType(backImage);

                String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "." + imageType;
                //Сохраняет изображение
                backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
            } else
            {
                if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() == FillType.Picture)
                {
                    //Получает фоновое изображение
                    backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(backImage);

                    String imagePath = folderPath + "backImage_" + "LayoutSlide_" + slideIndex + "." + imageType;
                    //Сохраняет изображение
                    backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
            }

            for (int j = 0; j < sl.getShapes().size(); j++)
            {
                // Доступ к фигуре, содержащей изображение
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

                //Устанавливает предпочитаемый формат изображения
                if (ifImageFound)
                {
                    String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                    //Сохраняет изображение
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
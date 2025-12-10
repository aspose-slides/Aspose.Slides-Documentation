---
title: Extraire des images des formes de présentation
linktitle: Image depuis la forme
type: docs
weight: 100
url: /fr/java/extracting-images-from-presentation-shapes/
keywords:
- extraire image
- récupérer image
- arrière-plan de diapositive
- arrière-plan de forme
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Extraire des images des formes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Java — solution rapide et conviviale pour le code."
---

## **Extraire des images des formes**

{{% alert color="primary" %}} 

Les images sont souvent ajoutées aux formes et sont également fréquemment utilisées comme arrière‑plans des diapositives. Les objets image sont ajoutés via [IImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/), qui est une collection d’objets [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). 

Cet article explique comment vous pouvez extraire les images ajoutées aux présentations. 

{{% /alert %}} 

Pour extraire une image d’une présentation, vous devez d’abord localiser l’image en parcourant chaque diapositive puis chaque forme. Une fois l’image trouvée ou identifiée, vous pouvez l’extraire et l’enregistrer comme un nouveau fichier. 
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
                //Enregistre l'image
                backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
            } else
            {
                if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() == FillType.Picture)
                {
                    //Récupère l'image d'arrière-plan
                    backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(backImage);

                    String imagePath = folderPath + "backImage_" + "LayoutSlide_" + slideIndex + "." + imageType;
                    //Enregistre l'image
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

                //Définit le format d'image préféré
                if (ifImageFound)
                {
                    String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                    //Enregistre l'image
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


## **FAQ**

**Puis‑je extraire l’image originale sans aucun recadrage, effet ou transformation de forme ?**

Oui. Lorsque vous accédez à l’image d’une forme, vous obtenez l’objet image provenant de la [image collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) de la présentation, c’est‑à‑dire les pixels d’origine sans recadrage ni effets de style. Le workflow parcourt la collection d’images de la présentation et les objets [PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/), qui stockent les données brutes.

**Existe‑t‑il un risque de dupliquer des fichiers identiques lors de l’enregistrement de nombreuses images à la fois ?**

Oui, si vous enregistrez tout sans discernement. La [image collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) d’une présentation peut contenir des données binaires identiques référencées par différentes formes ou diapositives. Pour éviter les doublons, comparez les hachages, les tailles ou le contenu des données extraites avant l’écriture.

**Comment déterminer quelles formes sont liées à une image spécifique de la collection de la présentation ?**

Aspose.Slides ne stocke pas de liens inverses de [PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/) vers les formes. Créez une cartographie manuellement lors du parcours : chaque fois que vous trouvez une référence à un [PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/), enregistrez les formes qui l’utilisent.

**Puis‑je extraire les images intégrées dans des objets OLE, comme des documents joints ?**

Pas directement, car un objet OLE est un conteneur. Vous devez extraire le package OLE lui‑même puis analyser son contenu à l’aide d’outils séparés. Les formes d’image de la présentation fonctionnent via [PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/) ; OLE est un type d’objet différent.
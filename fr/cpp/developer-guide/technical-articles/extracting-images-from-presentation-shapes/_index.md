---
title: Extraire des images des formes de présentation
linktitle: Image depuis forme
type: docs
weight: 90
url: /fr/cpp/extracting-images-from-presentation-shapes/
keywords:
- extraire image
- récupérer image
- arrière-plan de diapositive
- arrière-plan de forme
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Extraire des images des formes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour C++ — solution rapide et conviviale pour le code."
---

## **Extraire les images des formes**

{{% alert color="primary" %}} 

Les images sont souvent ajoutées aux formes et sont également fréquemment utilisées comme arrière‑plans des diapositives. Les objets image sont ajoutés via [IImageCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection), qui est une collection d'objets [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/). 

Cet article explique comment extraire les images ajoutées aux présentations. 

{{% /alert %}} 

Pour extraire une image d’une présentation, vous devez d’abord localiser l’image en parcourant chaque diapositive, puis chaque forme. Une fois l’image trouvée ou identifiée, vous pouvez l’extraire et l’enregistrer comme un nouveau fichier. 
``` cpp
void Run()
{
    System::String path = u"D:\\Aspose Data\\";
    //Accède à la présentation
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(path + u"ExtractImages.pptx");
    System::SharedPtr<Aspose::Slides::IPPImage> img;
    System::SharedPtr<Aspose::Slides::IPPImage> Backimg;

    int32_t slideIndex = 0;
    System::String ImageType = u"";
    bool ifImageFound = false;
    for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
    {
        slideIndex++;
        //Accède à la première diapositive
        System::SharedPtr<ISlide> sl = pres->get_Slides()->idx_get(i);
        System::SharedPtr<System::Drawing::Imaging::ImageFormat> Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();

        if (sl->get_Background()->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
        {
            //Récupère l'image d'arrière-plan  
            Backimg = sl->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();

            //Définit le format d'image souhaité
            ImageType = Backimg->get_ContentType();
            ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
            Format = GetImageFormat(ImageType);

            System::String ImagePath = path + u"BackImage_";
            Backimg->get_SystemImage()->Save(ImagePath + u"Slide_" + System::Convert::ToString(slideIndex) + u"." + ImageType, Format);
        }
        else
        {
            if (sl->get_LayoutSlide()->get_Background()->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
            {
                //Récupère l'image d'arrière-plan  
                Backimg = sl->get_LayoutSlide()->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();

                //Définit le format d'image souhaité 
                ImageType = Backimg->get_ContentType();
                ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                Format = GetImageFormat(ImageType);

                System::String ImagePath = path + u"BackImage_Slide_" + i;
                Backimg->get_SystemImage()->Save(ImagePath + u"LayoutSlide_" + System::Convert::ToString(slideIndex) + u"." + ImageType, Format);
            }
        }

        for (int32_t j = 0; j < sl->get_Shapes()->get_Count(); j++)
        {
            // Accède à la forme contenant une image
            System::SharedPtr<IShape> sh = sl->get_Shapes()->idx_get(j);

            if (System::ObjectExt::Is<AutoShape>(sh))
            {
                System::SharedPtr<AutoShape> ashp = System::ExplicitCast<Aspose::Slides::AutoShape>(sh);
                if (ashp->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
                {
                    img = ashp->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();
                    ImageType = img->get_ContentType();
                    ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                    ifImageFound = true;

                }
            }
            else if (System::ObjectExt::Is<PictureFrame>(sh))
            {
                System::SharedPtr<IPictureFrame> pf = System::ExplicitCast<Aspose::Slides::IPictureFrame>(sh);
                if (pf->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
                {
                    img = pf->get_PictureFormat()->get_Picture()->get_Image();
                    ImageType = img->get_ContentType();
                    ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                    ifImageFound = true;
                }
            }

            //Définit le format d'image préféré
            if (ifImageFound)
            {
                Format = GetImageFormat(ImageType);
                System::String ImagePath = path + u"Slides\\Image_";
                img->get_SystemImage()->Save(ImagePath + u"Slide_" + System::Convert::ToString(slideIndex) + u"_Shape_" + System::Convert::ToString(j) + u"." + ImageType, Format);
            }

            ifImageFound = false;
        }
    }
}

System::SharedPtr<System::Drawing::Imaging::ImageFormat> GetImageFormat(System::String ImageType)
{
    System::SharedPtr<System::Drawing::Imaging::ImageFormat> Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();
    {
        const System::String& switch_value_0 = ImageType;
        do {
            if (switch_value_0 == u"jpeg")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();
                break;
            }
            if (switch_value_0 == u"emf")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Emf();
                break;
            }
            if (switch_value_0 == u"bmp")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Bmp();
                break;
            }
            if (switch_value_0 == u"png")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Png();
                break;
            }
            if (switch_value_0 == u"wmf")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Wmf();
                break;
            }
            if (switch_value_0 == u"gif")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Gif();
                break;
            }
        } while (false);
    }

    return Format;
}
```


## **FAQ**

**Puis‑je extraire l'image originale sans aucun rognage, effet ou transformation de forme ?**

Oui. Lorsque vous accédez à l'image d’une forme, vous récupérez l’objet image à partir de la [collection d'images](https://reference.aspose.com/slides/cpp/aspose.slides/imagecollection/) de la présentation, ce qui signifie les pixels d’origine sans rognage ni effets de style. Le flux de travail parcourt la collection d'images de la présentation et les objets [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/), qui conservent les données brutes.

**Existe‑t‑il un risque de dupliquer des fichiers identiques lors de l'enregistrement de nombreuses images en même temps ?**

Oui, si vous enregistrez tout sans discernement. La [collection d'images](https://reference.aspose.com/slides/cpp/aspose.slides/imagecollection/) d’une présentation peut contenir des données binaires identiques référencées par différentes formes ou diapositives. Pour éviter les doublons, comparez les hachages, les tailles ou le contenu des données extraites avant d’écrire.

**Comment puis‑je déterminer quelles formes sont liées à une image spécifique de la collection de la présentation ?**

Aspose.Slides ne conserve pas de liens inverses de [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/) vers les formes. Créez une correspondance manuellement pendant le parcours : chaque fois que vous trouvez une référence à un [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/), enregistrez les formes qui l’utilisent.

**Puis‑je extraire les images incorporées dans des objets OLE, comme des documents joints ?**

Pas directement, car un objet OLE est un conteneur. Vous devez extraire le paquet OLE lui‑même, puis analyser son contenu avec des outils séparés. Les formes d’image de présentation fonctionnent via [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/) ; OLE est un type d’objet différent.
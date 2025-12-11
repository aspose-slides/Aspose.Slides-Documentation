---
title: Извлечение изображений из фигур презентации
linktitle: Изображение из фигуры
type: docs
weight: 90
url: /ru/cpp/extracting-images-from-presentation-shapes/
keywords:
- извлечение изображения
- получение изображения
- фон слайда
- фон фигуры
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Извлекайте изображения из фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++ — быстрое, удобное для кода решение."
---

## **Извлечение изображений из фигур**

{{% alert color="primary" %}} 

Изображения часто добавляются к фигурам и также часто используются в качестве фонов слайдов. Объекты изображений добавляются через [IImageCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection), который представляет собой коллекцию объектов [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/). 

В этой статье объясняется, как можно извлечь изображения, добавленные в презентации. 

{{% /alert %}} 

Чтобы извлечь изображение из презентации, нужно сначала найти изображение, пройдя по каждому слайду, а затем по каждой фигуре. Как только изображение найдено или определено, его можно извлечь и сохранить как новый файл. 
``` cpp
void Run()
{
    System::String path = u"D:\\Aspify Data\\";
    //Получает презентацию
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(path + u"ExtractImages.pptx");
    System::SharedPtr<Aspose::Slides::IPPImage> img;
    System::SharedPtr<Aspose::Slides::IPPImage> Backimg;

    int32_t slideIndex = 0;
    System::String ImageType = u"";
    bool ifImageFound = false;
    for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
    {
        slideIndex++;
        //Получает первую слайд
        System::SharedPtr<ISlide> sl = pres->get_Slides()->idx_get(i);
        System::SharedPtr<System::Drawing::Imaging::ImageFormat> Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();

        if (sl->get_Background()->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
        {
            //Получает фон изображения  
            Backimg = sl->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();

            //Устанавливает требуемый формат изображения
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
                //Получает фон изображения  
                Backimg = sl->get_LayoutSlide()->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();

                //Устанавливает требуемый формат изображения 
                ImageType = Backimg->get_ContentType();
                ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                Format = GetImageFormat(ImageType);

                System::String ImagePath = path + u"BackImage_Slide_" + i;
                Backimg->get_SystemImage()->Save(ImagePath + u"LayoutSlide_" + System::Convert::ToString(slideIndex) + u"." + ImageType, Format);
            }
        }

        for (int32_t j = 0; j < sl->get_Shapes()->get_Count(); j++)
        {
            // Доступ к фигуре, содержащей изображение
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

            //Устанавливает предпочтительный формат изображения
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


## **Вопросы и ответы**

**Могу ли я извлечь оригинальное изображение без обрезки, эффектов или трансформаций фигуры?**

Да. Когда вы получаете изображение фигуры, вы берёте объект изображения из [image collection](https://reference.aspose.com/slides/cpp/aspose.slides/imagecollection/), что означает оригинальные пиксели без обрезки или стилистических эффектов. Рабочий процесс проходит по [image collection] презентации и объектам [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/), которые хранят сырой набор данных.

**Есть ли риск дублирования одинаковых файлов при сохранении большого количества изображений одновременно?**

Да, если сохранять всё без разбору. [image collection] презентации может содержать одинаковые бинарные данные, на которые ссылаются разные фигуры или слайды. Чтобы избежать дубликатов, сравнивайте хэши, размеры или содержимое извлечённых данных перед записью.

**Как определить, какие фигуры связаны с конкретным изображением из коллекции презентации?**

Aspose.Slides не хранит обратные ссылки от [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/) к фигурам. Создайте соответствие вручную во время обхода: каждый раз, когда находите ссылку на [PPImage], фиксируйте, какие фигуры её используют.

**Можно ли извлечь изображения, встроенные в объекты OLE, например вложенные документы?**

Не напрямую, потому что объект OLE является контейнером. Нужно извлечь сам пакет OLE, а затем анализировать его содержимое отдельными инструментами. Фигуры‑изображения презентации работают через [PPImage]; OLE — это другой тип объекта.
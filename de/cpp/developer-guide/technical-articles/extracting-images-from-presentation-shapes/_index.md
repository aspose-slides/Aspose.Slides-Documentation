---
title: Bilder aus Formen der Präsentation extrahieren
linktitle: Bild aus Form
type: docs
weight: 90
url: /de/cpp/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- Folienhintergrund
- Formhintergrund
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ extrahieren — schnelle, codefreundliche Lösung."
---

## **Bilder aus Formen extrahieren**

{{% alert color="primary" %}} 

Bilder werden häufig zu Formen hinzugefügt und auch oft als Folienhintergründe verwendet. Die Bildobjekte werden über [IImageCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) hinzugefügt, das eine Sammlung von [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)‑Objekten ist. 

Dieser Artikel erklärt, wie Sie die zu Präsentationen hinzugefügten Bilder extrahieren können. 

{{% /alert %}} 

Um ein Bild aus einer Präsentation zu extrahieren, müssen Sie das Bild zuerst finden, indem Sie jede Folie und anschließend jede Form durchgehen. Sobald das Bild gefunden bzw. identifiziert ist, können Sie es extrahieren und als neue Datei speichern. 
``` cpp
void Run()
{
    System::String path = u"D:\\Aspose Data\\";
    //Greift auf die Präsentation zu
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(path + u"ExtractImages.pptx");
    System::SharedPtr<Aspose::Slides::IPPImage> img;
    System::SharedPtr<Aspose::Slides::IPPImage> Backimg;

    int32_t slideIndex = 0;
    System::String ImageType = u"";
    bool ifImageFound = false;
    for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
    {
        slideIndex++;
        //Zugriff auf die erste Folie
        System::SharedPtr<ISlide> sl = pres->get_Slides()->idx_get(i);
        System::SharedPtr<System::Drawing::Imaging::ImageFormat> Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();

        if (sl->get_Background()->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
        {
            //Holt das Hintergrundbild  
            Backimg = sl->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();

            //Setzt das gewünschte Bildformat
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
                //Holt das Hintergrundbild  
                Backimg = sl->get_LayoutSlide()->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();

                //Setzt das gewünschte Bildformat 
                ImageType = Backimg->get_ContentType();
                ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                Format = GetImageFormat(ImageType);

                System::String ImagePath = path + u"BackImage_Slide_" + i;
                Backimg->get_SystemImage()->Save(ImagePath + u"LayoutSlide_" + System::Convert::ToString(slideIndex) + u"." + ImageType, Format);
            }
        }

        for (int32_t j = 0; j < sl->get_Shapes()->get_Count(); j++)
        {
            // Greift auf die Form zu, die ein Bild enthält
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

            //Setzt das bevorzugte Bildformat
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

**Kann ich das Originalbild ohne Zuschnitt, Effekte oder Formtransformationen extrahieren?**

Ja. Wenn Sie auf das Bild einer Form zugreifen, erhalten Sie das Bildobjekt aus der [image collection](https://reference.aspose.com/slides/cpp/aspose.slides/imagecollection/) der Präsentation, also die ursprünglichen Pixel ohne Zuschnitt oder Stil‑Effekte. Der Ablauf durchläuft die Bildsammlung der Präsentation und die [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/)‑Objekte, die die Rohdaten speichern.

**Besteht das Risiko, beim gleichzeitigen Speichern vieler Bilder identische Dateien zu duplizieren?**

Ja, wenn Sie alles unkritisch speichern. Eine [image collection](https://reference.aspose.com/slides/cpp/aspose.slides/imagecollection/) einer Präsentation kann identische Binärdaten enthalten, die von verschiedenen Formen oder Folien referenziert werden. Um Duplikate zu vermeiden, vergleichen Sie Hashes, Größen oder Inhalte der extrahierten Daten, bevor Sie schreiben.

**Wie kann ich bestimmen, welche Formen mit einem bestimmten Bild aus der Sammlung der Präsentation verknüpft sind?**

Aspose.Slides speichert keine Rückverweise von [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/) zu Formen. Erstellen Sie während der Traversierung manuell eine Zuordnung: Wann immer Sie eine Referenz zu einem [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/) finden, notieren Sie, welche Formen ihn verwenden.

**Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, z. B. angehängte Dokumente?**

Nicht direkt, weil ein OLE‑Objekt ein Container ist. Sie müssen das OLE‑Paket selbst extrahieren und dann dessen Inhalt mit separaten Tools analysieren. Bildformen in Präsentationen arbeiten über [PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/); OLE ist ein anderer Objekttyp.
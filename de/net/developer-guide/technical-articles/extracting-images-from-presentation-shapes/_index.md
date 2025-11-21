---
title: Bilder aus Präsentationsformen extrahieren
type: docs
weight: 90
url: /de/net/extracting-images-from-presentation-shapes/
keywords: "Bild extrahieren, PowerPoint, PPT, PPTX, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Bilder aus PowerPoint-Präsentation in C# oder .NET extrahieren"
---

## **Bilder aus Formen extrahieren**

{{% alert color="primary" %}} 

Bilder werden häufig zu Formen hinzugefügt und auch oft als Folienhintergründe verwendet. Die Bildobjekte werden über [IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/), das eine Sammlung von [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)‑Objekten ist, hinzugefügt. 

Dieser Artikel erklärt, wie Sie die zu Präsentationen hinzugefügten Bilder extrahieren können. 

{{% /alert %}} 

Um ein Bild aus einer Präsentation zu extrahieren, müssen Sie das Bild zuerst finden, indem Sie jede Folie und anschließend jede Form durchsuchen. Sobald das Bild gefunden oder identifiziert ist, können Sie es extrahieren und als neue Datei speichern. XXX 
```c#
public static void Run() {

    String path = @"D:\Aspose Data\";
    // Greift auf die Präsentation zu
    Presentation pres = new Presentation(path + "ExtractImages.pptx");
    Aspose.Slides.IPPImage img = null;
    Aspose.Slides.IPPImage Backimg = null;

    int slideIndex = 0;
    String ImageType = "";
    bool ifImageFound = false;
    for (int i = 0; i < pres.Slides.Count; i++)
    {

        slideIndex++;
        // Greift auf die erste Folie zu
        ISlide sl = pres.Slides[i];
        System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

        // Greift auf die erste Folie zu Slide sl = pres.getSlideByPosition(i);
        if (sl.Background.FillFormat.FillType == FillType.Picture)
        {
            // Holt das Hintergrundbild  
            Backimg = sl.Background.FillFormat.PictureFillFormat.Picture.Image;

            // Legt das bevorzugte Bildformat fest 

            ImageType = Backimg.ContentType;
            ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
            Format = GetImageFormat(ImageType);

            String ImagePath = path + "BackImage_";
            Backimg.SystemImage.Save(ImagePath + "Slide_" + slideIndex.ToString() + "." + ImageType, Format);

        }
        else
        {
            if (sl.LayoutSlide.Background.FillFormat.FillType == FillType.Picture)
            {
                // Holt das Hintergrundbild  
                Backimg = sl.LayoutSlide.Background.FillFormat.PictureFillFormat.Picture.Image;

                // Legt das bevorzugte Bildformat fest 

                ImageType = Backimg.ContentType;
                ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                Format = GetImageFormat(ImageType);

                String ImagePath = path + "BackImage_Slide_" + i;
                Backimg.SystemImage.Save(ImagePath + "LayoutSlide_" + slideIndex.ToString() + "." + ImageType, Format);

            }
        }

        for (int j = 0; j < sl.Shapes.Count; j++)
        {
            // Greift auf die Form zu, die ein Bild enthält
            IShape sh = sl.Shapes[j];

            if (sh is AutoShape)
            {
                AutoShape ashp = (AutoShape)sh;
                if (ashp.FillFormat.FillType == FillType.Picture)
                {
                    img = ashp.FillFormat.PictureFillFormat.Picture.Image;
                    ImageType = img.ContentType;
                    ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                    ifImageFound = true;

                }
            }

            else if (sh is PictureFrame)
            {
                IPictureFrame pf = (IPictureFrame)sh;
                if (pf.FillFormat.FillType == FillType.Picture)
                {
                    img = pf.PictureFormat.Picture.Image;
                    ImageType = img.ContentType;
                    ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                    ifImageFound = true;
                }
            }

            // Legt das bevorzugte Format für das extrahierte Bild fest
            if (ifImageFound)
            {
                Format = GetImageFormat(ImageType);
                String ImagePath = path + "Slides\\Image_";
                img.SystemImage.Save(ImagePath + "Slide_" + slideIndex.ToString() + "_Shape_" + j.ToString() + "." + ImageType, Format);
            }
            ifImageFound = false;
        }
    }
}

public static System.Drawing.Imaging.ImageFormat GetImageFormat(String ImageType)
{
    System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;
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
    return Format;
}
```


## **FAQ**

**Kann ich das Originalbild ohne Zuschnitt, Effekte oder Formtransformationen extrahieren?**

Ja. Wenn Sie auf das Bild einer Form zugreifen, erhalten Sie das Bildobjekt aus der [image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/), also die Originalpixel ohne Zuschnitt oder Stil‑Effekte. Der Ablauf geht die [image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) der Präsentation und die [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/)‑Objekte durch, die die Rohdaten speichern.

**Besteht das Risiko, identische Dateien zu duplizieren, wenn viele Bilder gleichzeitig gespeichert werden?**

Ja, wenn Sie alles ununterscheidend speichern. Die [image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) einer Präsentation kann identische Binärdaten enthalten, auf die von verschiedenen Formen oder Folien verwiesen wird. Um Duplikate zu vermeiden, vergleichen Sie Hashes, Größen oder Inhalte der extrahierten Daten, bevor Sie schreiben.

**Wie kann ich ermitteln, welche Formen mit einem bestimmten Bild aus der Bildsammlung der Präsentation verknüpft sind?**

Aspose.Slides speichert keine Rückverweise von [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) zu Formen. Erstellen Sie während der Durchquerung manuell eine Zuordnung: Jedes Mal, wenn Sie eine Referenz zu einem [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) finden, protokollieren Sie, welche Formen es verwenden.

**Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, z. B. angehängte Dokumente?**

Nicht direkt, da ein OLE‑Objekt ein Container ist. Sie müssen das OLE‑Paket selbst extrahieren und dann dessen Inhalt mit separaten Werkzeugen analysieren. Bildformen in Präsentationen arbeiten über [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/); OLE ist ein anderer Objekttyp.
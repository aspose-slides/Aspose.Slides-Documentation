---
title: Bilder aus Formen einer Präsentation in .NET
linktitle: Bild aus Form
type: docs
weight: 90
url: /de/net/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- Folienhintergrund
- Formhintergrund
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Extrahieren Sie Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET - schnelle, codefreundliche Lösung."
---

## **Bilder aus Formen extrahieren**

{{% alert color="primary" %}} 

Bilder werden häufig zu Formen hinzugefügt und auch oft als Folienhintergründe verwendet. Die Bildobjekte werden über [IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/) hinzugefügt, das eine Sammlung von [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)-Objekten ist. 

Dieser Artikel erklärt, wie Sie die zu Präsentationen hinzugefügten Bilder extrahieren können. 

{{% /alert %}} 

Um ein Bild aus einer Präsentation zu extrahieren, müssen Sie das Bild zuerst finden, indem Sie jede Folie und anschließend jede Form durchgehen. Sobald das Bild gefunden oder identifiziert ist, können Sie es extrahieren und als neue Datei speichern. XXX 
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
            // Ermittelt das Hintergrundbild  
            Backimg = sl.Background.FillFormat.PictureFillFormat.Picture.Image;

            // Setzt das bevorzugte Bildformat 

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
                // Ermittelt das Hintergrundbild  
                Backimg = sl.LayoutSlide.Background.FillFormat.PictureFillFormat.Picture.Image;

                // Setzt das bevorzugte Bildformat 

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

            // Setzt das bevorzugte Format für das extrahierte Bild
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

**Kann ich das Originalbild ohne Beschnitt, Effekte oder Form-Transformationen extrahieren?**

Ja. Wenn Sie auf das Bild einer Form zugreifen, erhalten Sie das Bildobjekt aus der Präsentation’s [Bildsammlung](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/), das die ursprünglichen Pixel ohne Beschnitt oder Stil‑Effekte enthält. Der Vorgang durchläuft die Bildsammlung der Präsentation und die [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/)-Objekte, die die Rohdaten speichern.

**Besteht das Risiko, bei gleichzeitiger Speicherung vieler Bilder identische Dateien zu duplizieren?**

Ja, wenn Sie alles ununterscheidend speichern. Die [Bildsammlung](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) einer Präsentation kann identische Binärdaten enthalten, auf die von verschiedenen Formen oder Folien verwiesen wird. Um Duplikate zu vermeiden, vergleichen Sie vor dem Schreiben Hashes, Größen oder Inhalte der extrahierten Daten.

**Wie kann ich feststellen, welche Formen mit einem bestimmten Bild aus der Bildsammlung der Präsentation verknüpft sind?**

Aspose.Slides speichert keine Rückverknüpfungen von [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) zu Formen. Erstellen Sie während der Durchlauf‑phase manuell eine Zuordnung: Jedes Mal, wenn Sie eine Referenz auf ein [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) finden, notieren Sie, welche Formen es verwenden.

**Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, z. B. angehängte Dokumente?**

Nicht direkt, da ein OLE‑Objekt ein Container ist. Sie müssen das OLE‑Paket selbst extrahieren und dann dessen Inhalte mit separaten Werkzeugen analysieren. Präsentations‑Bildformen arbeiten über [PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/); OLE ist ein anderer Objekttyp.
---
title: Bilder aus Formen einer Präsentation extrahieren
linktitle: Bild aus Form
type: docs
weight: 100
url: /de/java/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- Folienhintergrund
- Formhintergrund
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java extrahieren — schnelle, code-freundliche Lösung."
---

## **Bilder aus Formen extrahieren**

{{% alert color="primary" %}} 

Bilder werden häufig zu Formen hinzugefügt und auch oft als Folienhintergründe verwendet. Die Bildobjekte werden über [IImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/) hinzugefügt, welche eine Sammlung von [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)-Objekten ist. 

Dieser Artikel erklärt, wie Sie die zu Präsentationen hinzugefügten Bilder extrahieren können. 

{{% /alert %}} 

Um ein Bild aus einer Präsentation zu extrahieren, müssen Sie das Bild zunächst finden, indem Sie jede Folie und anschließend jede Form durchsuchen. Sobald das Bild gefunden oder identifiziert ist, können Sie es extrahieren und als neue Datei speichern. 
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
                //Greift auf die erste Folie zu
                ISlide sl = pres.getSlides().get_Item(i);


                //Greift auf die erste Folie zu Slide sl = pres.getSlideByPosition(i);
                if (sl.getBackground().getFillFormat().getFillType() == FillType.Picture)
                {
                    //Lädt das Hintergrundbild
                    backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(backImage);

                    String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "." + imageType;
                    //Speichert das Bild
                    backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                } else
                {
                    if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() == FillType.Picture)
                    {
                        //Lädt das Hintergrundbild
                        backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                        imageType = getImageTType(backImage);

                        String imagePath = folderPath + "backImage_" + "LayoutSlide_" + slideIndex + "." + imageType;
                        //Speichert das Bild
                        backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                    }
                }

                for (int j = 0; j < sl.getShapes().size(); j++)
                {
                    // Greift auf die Form zu, die ein Bild enthält
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

                    //Legt das bevorzugte Bildformat fest
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


## **FAQ**

**Kann ich das Originalbild ohne Zuschneiden, Effekte oder Form-Transformationen extrahieren?**

Ja. Wenn Sie auf das Bild einer Form zugreifen, erhalten Sie das Bildobjekt aus der [image collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) der Präsentation, also die ursprünglichen Pixel ohne Zuschneiden oder Stil‑Effekte. Der Vorgang durchläuft die [image collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) der Präsentation und die [PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/)-Objekte, die die Rohdaten speichern.

**Besteht das Risiko, beim gleichzeitigen Speichern vieler Bilder identische Dateien zu duplizieren?**

Ja, wenn Sie alles ununterscheidend speichern. Die [image collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) einer Präsentation kann identische Binärdaten enthalten, die von verschiedenen Formen oder Folien referenziert werden. Um Duplikate zu vermeiden, vergleichen Sie vor dem Schreiben Hash‑Werte, Größen oder Inhalte der extrahierten Daten.

**Wie kann ich ermitteln, welche Formen mit einem bestimmten Bild aus der Bildsammlung der Präsentation verknüpft sind?**

Aspose.Slides speichert keine Rückverweise von [PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/) zu Formen. Erstellen Sie während der Durchquerung manuell eine Zuordnung: Sobald Sie eine Referenz auf ein [PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/) finden, notieren Sie, welche Formen es verwenden.

**Kann ich Bilder, die in OLE‑Objekten eingebettet sind, wie z. B. angehängte Dokumente, extrahieren?**

Nicht direkt, da ein OLE‑Objekt ein Container ist. Sie müssen das OLE‑Paket selbst extrahieren und dann dessen Inhalte mit separaten Werkzeugen analysieren. Bildformen in Präsentationen arbeiten über [PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/); OLE ist ein anderer Objekttyp.
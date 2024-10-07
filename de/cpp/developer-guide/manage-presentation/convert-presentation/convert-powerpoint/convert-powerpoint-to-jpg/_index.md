---
title: Powerpoint PPT in JPG konvertieren
type: docs
weight: 60
url: /cpp/convert-powerpoint-to-jpg/
keywords:
- PowerPoint-Präsentation konvertieren
- JPG
- JPEG
- PowerPoint in JPG
- PowerPoint in JPEG
- PPT in JPG
- PPTX in JPG
- PPT in JPEG
- PPTX in JPEG
- C++
- Aspose.Slides
description: "PowerPoint in JPG konvertieren: PPT in JPG, PPTX in JPG in C++"
---

## **Präsentation in eine Bilderserie konvertieren**

In einigen Fällen ist es notwendig, die gesamte Präsentation in eine Bilderserie umzuwandeln, 
so wie es PowerPoint ermöglicht. Der C++-Code zeigt Ihnen, wie Sie eine Präsentation in JPG-Bilder konvertieren:

```c++
auto imageScale = 1.0f;

auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : pres->get_Slides())
{
    // Erstellt ein Vollbild-Bild
    System::SharedPtr<IImage> image = slide->GetImage(imageScale, imageScale);

    // Speichert das Bild im JPEG-Format auf der Festplatte
    auto imageFileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(imageFileName, ImageFormat::Jpeg);

    image->Dispose();
}

pres->Dispose();
```

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint in JPG-Bilder konvertiert, möchten Sie vielleicht diese kostenlosen Online-Konverter ausprobieren: PowerPoint [PPTX in JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT in JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

## **PowerPoint PPT/PPTX in JPG mit benutzerdefinierten Abmessungen konvertieren**

Um die Dimension des resultierenden Vorschaubildes und des JPG-Bildes zu ändern, können Sie die *ScaleX* und *ScaleY* Werte festlegen, indem Sie sie in `float scaleX, float Y` der [**ISlide::GetImage()**](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagefloat-float-method) Methode übergeben:

```c++
auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

// Definiert die Abmessungen
int32_t desiredX = 1200, desiredY = 800;

// Berechnet die skalierten Werte von X und Y
float scaleX = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Width()) * desiredX;
float scaleY = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Height()) * desiredY;

for (auto&& slide : pres->get_Slides())
{
    // Erstellt ein Vollbild-Bild
    System::SharedPtr<IImage> image = slide->GetImage(scaleX, scaleY);

    // Speichert das Bild im JPEG-Format auf der Festplatte
    auto imageFileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(imageFileName, ImageFormat::Jpeg);

    image->Dispose();
}

pres->Dispose();
```

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage-Webanwendung](https://products.aspose.app/slides/collage). Mit diesem Online-Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG-Bildern zusammenführen, [Fotokollagen](https://products.aspose.app/slides/collage/photo-grid) erstellen usw. 

Mit denselben Prinzipien, die in diesem Artikel beschrieben werden, können Sie Bilder von einem Format in ein anderes konvertieren. Für weitere Informationen, sehen Sie sich diese Seiten an: [Bild in JPG konvertieren](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); [JPG in Bild konvertieren](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); [JPG in PNG konvertieren](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), [PNG in JPG konvertieren](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); [PNG in SVG konvertieren](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), [SVG in PNG konvertieren](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Siehe auch**

Siehe weitere Optionen, um PPT/PPTX in Bilder zu konvertieren, wie:

- [PPT/PPTX zu SVG-Konvertierung](/slides/cpp/render-a-slide-as-an-svg-image/)
---
title: PowerPoint in PNG konvertieren
type: docs
weight: 30
url: /cpp/convert-powerpoint-to-png/
keywords: PowerPoint in PNG, PPT in PNG, PPTX in PNG, C++, Aspose.Slides für C++
description: PowerPoint-Präsentation in PNG konvertieren
---

## **Über die Konvertierung von PowerPoint in PNG**

Das PNG (Portable Network Graphics) Format ist nicht so populär wie JPEG (Joint Photographic Experts Group), aber dennoch sehr beliebt.

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe kein Problem darstellt, ist PNG ein besseres Bildformat als JPEG.

{{% alert title="Tipp" color="primary" %}} Sie sollten die kostenlosen **PowerPoint in PNG Konverter** von Aspose ausprobieren: [PPTX in PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT in PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Diese sind eine Live-Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint in PNG konvertieren**

Befolgen Sie diese Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Holen Sie das Folienobjekt aus der [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) Sammlung unter dem [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide) Interface.
3. Verwenden Sie die [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) Methode, um das Thumbnail für jede Folie zu erhalten.
4. Verwenden Sie die [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) Methode, um das Folien-Thumbnail im PNG-Format zu speichern.

Dieser C++ Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in PNG konvertieren:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Wenn Sie PNG-Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Thumbnails bestimmen.

Dieser Code in C++ demonstriert die beschriebene Operation:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Wenn Sie PNG-Dateien in einer bestimmten Größe erhalten möchten, können Sie Ihre bevorzugten `width` und `height` Argumente für `ImageSize` übergeben.

Dieser Code zeigt Ihnen, wie Sie eine PowerPoint in PNG konvertieren können, während Sie die Größe für die Bilder festlegen:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```
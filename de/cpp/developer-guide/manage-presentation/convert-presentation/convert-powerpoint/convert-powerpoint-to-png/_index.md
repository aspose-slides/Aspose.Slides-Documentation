---
title: PowerPoint‑Folien in PNG konvertieren in C++
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/cpp/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folie zu PNG
- PPT zu PNG
- PPTX zu PNG
- PPT als PNG speichern
- PPTX als PNG speichern
- PPT nach PNG exportieren
- PPTX nach PNG exportieren
- C++
- Aspose.Slides
description: "PowerPoint‑Präsentationen schnell in hochwertige PNG‑Bilder konvertieren mit Aspose.Slides für C++, um präzise, automatisierte Ergebnisse zu gewährleisten."
---

## **Über die PowerPoint‑zu‑PNG‑Konvertierung**

Das PNG‑Format (Portable Network Graphics) ist nicht so populär wie JPEG (Joint Photographic Experts Group), bleibt aber weiterhin sehr verbreitet. 

**Anwendungsfall:** Wenn Sie ein komplexes Bild haben und die Größe kein Problem darstellt, ist PNG ein besseres Bildformat als JPEG. 

{{% alert title="Tip" color="primary" %}} Sie möchten vielleicht Aspose kostenlose **PowerPoint‑zu‑PNG‑Konverter** prüfen: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie sind eine Live‑Implementierung des auf dieser Seite beschriebenen Prozesses. {{% /alert %}}

## **PowerPoint zu PNG konvertieren**

Gehen Sie die folgenden Schritte durch:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
2. Holen Sie das Folienobjekt aus der [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)‑Sammlung über die [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide)‑Schnittstelle.  
3. Verwenden Sie die Methode [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage), um das Miniaturbild für jede Folie zu erhalten.  
4. Verwenden Sie die Methode [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method), um das Folien‑Miniaturbild im PNG‑Format zu speichern.  

Dieser C++‑Code zeigt Ihnen, wie Sie eine PowerPoint‑Präsentation in PNG konvertieren:
```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```


## **PowerPoint zu PNG mit benutzerdefinierten Abmessungen konvertieren**

Wenn Sie PNG‑Dateien in einem bestimmten Maßstab erhalten möchten, können Sie die Werte für `desiredX` und `desiredY` festlegen, die die Abmessungen des resultierenden Miniaturbilds bestimmen. 

Dieser C++‑Code demonstriert die beschriebene Vorgehensweise:
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


## **PowerPoint zu PNG mit benutzerdefinierter Größe konvertieren**

Wenn Sie PNG‑Dateien in einer bestimmten Größe erhalten möchten, können Sie Ihre bevorzugten `width`‑ und `height`‑Argumente für `ImageSize` übergeben. 

Dieser Code zeigt Ihnen, wie Sie ein PowerPoint in PNG konvertieren und dabei die Größe der Bilder festlegen: 
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


## **FAQ**

**Wie kann ich nur eine bestimmte Form (z. B. Diagramm oder Bild) statt der gesamten Folie exportieren?**  
Aspose.Slides unterstützt [die Erzeugung von Miniaturbildern für einzelne Formen](/slides/de/cpp/create-shape-thumbnails/); Sie können eine Form als PNG‑Bild rendern.

**Wird die parallele Konvertierung auf einem Server unterstützt?**  
Ja, jedoch [nicht teilen](/slides/de/cpp/multithreading/) Sie eine einzelne Präsentationsinstanz über Threads hinweg. Verwenden Sie pro Thread oder Prozess eine separate Instanz.

**Was sind die Einschränkungen der Testversion beim Exportieren nach PNG?**  
Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und erzwingt [weitere Einschränkungen](/slides/de/cpp/licensing/), bis eine Lizenz angewendet wird.
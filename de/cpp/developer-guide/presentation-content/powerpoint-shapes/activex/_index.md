---
title: "ActiveX-Steuerelemente in Präsentationen mit C++ verwalten"
linktitle: "ActiveX"
type: docs
weight: 80
url: /de/cpp/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Media-Player
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für C++ ActiveX nutzt, um PowerPoint-Präsentationen zu automatisieren und zu verbessern, und Entwicklern eine leistungsstarke Kontrolle über Folien bietet."
---

ActiveX‑Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für C++ ermöglicht die Verwaltung von ActiveX‑Steuerelementen, aber deren Verwaltung ist etwas kniffliger und unterscheidet sich von normalen Präsentationsformen. Seit Aspose.Slides für C++ 18.1 unterstützt die Komponente die Verwaltung von ActiveX‑Steuerelementen. Derzeit können Sie bereits hinzugefügte ActiveX‑Steuerelemente in Ihrer Präsentation abrufen und sie über deren verschiedene Eigenschaften ändern oder löschen. Denken Sie daran, dass ActiveX‑Steuerelemente keine Formen sind und nicht Teil der IShapeCollection der Präsentation, sondern einer separaten IControlCollection sind. Dieser Artikel zeigt, wie man mit ihnen arbeitet.

## **ActiveX‑Steuerelement ändern**
Um ein einfaches ActiveX‑Steuerelement wie ein Textfeld und eine einfache Schaltfläche auf einer Folie zu verwalten:

1. Erstellen Sie eine Instanz der Klasse Presentation und laden Sie die Präsentation mit ActiveX‑Steuerelementen.
1. Holen Sie sich einen Folien‑Verweis über dessen Index.
1. Greifen Sie auf die ActiveX‑Steuerelemente in der Folie zu, indem Sie die IControlCollection verwenden.
1. Greifen Sie auf das TextBox1‑ActiveX‑Steuerelement über das ControlEx‑Objekt zu.
1. Ändern Sie die verschiedenen Eigenschaften des TextBox1‑ActiveX‑Steuerelements, einschließlich Text, Schriftart, Schriftgröße und Rahmenposition.
1. Greifen Sie auf das zweite Steuerelement mit dem Namen CommandButton1 zu.
1. Ändern Sie die Beschriftung, Schriftart und Position der Schaltfläche.
1. Verschieben Sie die Position der Rahmen der ActiveX‑Steuerelemente.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Der nachstehende Code‑Abschnitt aktualisiert die ActiveX‑Steuerelemente auf den Präsentationsfolien, wie unten gezeigt.
``` cpp
// Zugriff auf die Präsentation mit ActiveX-Steuerelementen
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Zugriff auf die erste Folie in der Präsentation
auto slide = presentation->get_Slides()->idx_get(0);

// Ändern des Textes im TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // Ändern des Ersatzbildes. PowerPoint ersetzt dieses Bild während der ActiveX-Aktivierung, daher ist es manchmal in Ordnung, das Bild unverändert zu lassen.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Ändern der Beschriftung der Schaltfläche
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // Ändern des Ersatzbildes
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Verschieben der ActiveX-Rahmen um 100 Punkte nach unten
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Speichern der Präsentation mit bearbeiteten ActiveX-Steuerelementen
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Jetzt werden die Steuerelemente entfernt
slide->get_Controls()->Clear();

// Speichern der Präsentation mit gelöschten ActiveX-Steuerelementen
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```


## **Media Player ActiveX‑Steuerelement hinzufügen**
ActiveX‑Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für C++ ermöglicht das Hinzufügen und Verwalten von ActiveX‑Steuerelementen, aber deren Verwaltung ist etwas kniffliger und unterscheidet sich von normalen Präsentationsformen. Seit Aspose.Slides für C++ 18.1 wurde die Unterstützung für das Hinzufügen von Media Player‑ActiveX‑Steuerelementen in Aspose.Slides integriert. Denken Sie daran, dass ActiveX‑Steuerelemente keine Formen sind und nicht Teil der IShapeCollection der Präsentation, sondern einer separaten IControlExCollection sind. Dieser Artikel zeigt, wie man mit ihnen arbeitet. Um ein Media Player‑ActiveX‑Steuerelement zu verwalten, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse Presentation und laden Sie die Beispielpräsentation mit Media Player‑ActiveX‑Steuerelementen.
1. Erstellen Sie eine Instanz der Ziel‑Presentation‑Klasse und erzeugen Sie eine leere Präsentationsinstanz.
1. Klonen Sie die Folie mit dem Media Player‑ActiveX‑Steuerelement aus der Vorlagenpräsentation in die Ziel‑Presentation.
1. Greifen Sie auf die geklonte Folie in der Ziel‑Presentation zu.
1. Greifen Sie auf die ActiveX‑Steuerelemente in der Folie zu, indem Sie die IControlCollection verwenden.
1. Greifen Sie auf das Media Player‑ActiveX‑Steuerelement zu und setzen Sie den Videopfad über dessen Eigenschaften.
1. Speichern Sie die Präsentation in einer PPTX‑Datei.
``` cpp
// Instanziiere die Presentation-Klasse, die die PPTX-Datei darstellt
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Erstelle eine leere Präsentationsinstanz
auto newPresentation = System::MakeObject<Presentation>();

// Entferne die Standardfolie
newPresentation->get_Slides()->RemoveAt(0);

// Klone die Folie mit dem Media Player ActiveX-Steuerelement
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Greife auf das Media Player ActiveX-Steuerelement zu und setze den Videopfad
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Speichere die Präsentation
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Behält Aspose.Slides ActiveX‑Steuerelemente bei, wenn sie beim Lesen und erneuten Speichern nicht in der C++‑Laufzeit ausgeführt werden können?**

Ja. Aspose.Slides behandelt sie als Teil der Präsentation und kann deren Eigenschaften und Rahmen lesen bzw. ändern; das Ausführen der Steuerelemente selbst ist nicht erforderlich, um sie zu erhalten.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten in einer Präsentation?**

ActiveX‑Steuerelemente sind interaktive, verwaltete Steuerelemente (Schaltflächen, Textfelder, Media Player), während [OLE](/slides/de/cpp/manage-ole/) sich auf eingebettete Anwendungsobjekte (zum Beispiel ein Excel‑Arbeitsblatt) bezieht. Sie werden anders gespeichert und behandelt und besitzen unterschiedliche Property‑Modelle.

**Funktionieren ActiveX‑Ereignisse und VBA‑Makros, wenn die Datei von Aspose.Slides geändert wurde?**

Aspose.Slides bewahrt das vorhandene Markup und die Metadaten; Ereignisse und Makros werden jedoch nur in PowerPoint unter Windows ausgeführt, wenn die Sicherheit dies zulässt. Die Bibliothek führt kein VBA aus.
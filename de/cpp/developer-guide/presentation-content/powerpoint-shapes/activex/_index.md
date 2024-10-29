---
title: ActiveX
type: docs
weight: 80
url: /de/cpp/activex/
---


ActiveX-Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für C++ ermöglicht Ihnen die Verwaltung von ActiveX-Steuerelementen, jedoch ist deren Verwaltung etwas komplizierter und unterscheidet sich von normalen Präsentationsformen. Ab Aspose.Slides für C++ 18.1 unterstützt die Komponente die Verwaltung von ActiveX-Steuerelementen. Momentan können Sie bereits hinzugefügte ActiveX-Steuerelemente in Ihrer Präsentation abrufen und diese mit verschiedenen Eigenschaften ändern oder löschen. Denken Sie daran, dass ActiveX-Steuerelemente keine Formen sind und nicht Teil der IShapeCollection der Präsentation, sondern Teil der separaten IControlCollection sind. Dieser Artikel zeigt, wie Sie mit ihnen arbeiten.

## **ActiveX-Steuerelement ändern**
Um ein einfaches ActiveX-Steuerelement wie ein Textfeld und eine einfache Schaltfläche auf einer Folie zu verwalten:

1. Erstellen Sie eine Instanz der Klasse Presentation und laden Sie die Präsentation mit ActiveX-Steuerelementen.
1. Erhalten Sie einen Folienverweis anhand ihres Index.
1. Greifen Sie auf die ActiveX-Steuerelemente in der Folie zu, indem Sie die IControlCollection abrufen.
1. Greifen Sie auf das ActiveX-Steuerelement TextBox1 über das ControlEx-Objekt zu.
1. Ändern Sie die verschiedenen Eigenschaften des ActiveX-Steuerelements TextBox1, einschließlich Text, Schriftart, Schriftgröß und Position des Rahmens.
1. Greifen Sie auf das zweite Steuerelement namens CommandButton1 zu.
1. Ändern Sie die Schaltflächenbeschriftung, Schriftart und Position.
1. Verschieben Sie die Position der ActiveX-Steuerelementrahmen.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Der folgende Codeausschnitt aktualisiert die ActiveX-Steuerelemente in den Präsentationsfolien wie unten gezeigt.

``` cpp
// Zugriff auf die Präsentation mit ActiveX-Steuerelementen
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Zugriff auf die erste Folie in der Präsentation
auto slide = presentation->get_Slides()->idx_get(0);

// Text des TextBox ändern
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Geänderter Text";
    control->get_Properties()->idx_set(u"Value", newText);

    // Ändern des Ersatzbildes. Powerpoint wird dieses Bild während der ActiveX-Aktivierung ersetzen, daher ist es manchmal in Ordnung, das Bild unverändert zu lassen.
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

// Schaltflächenbeschriftung ändern
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"NachrichtBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // Ersatzbild ändern
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

// ActiveX-Rahmen 100 Punkte nach unten verschieben
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Die Präsentation mit bearbeiteten ActiveX-Steuerelementen speichern
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Jetzt Steuerelemente entfernen
slide->get_Controls()->Clear();

// Präsentation mit geleerten ActiveX-Steuerelementen speichern
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Media Player ActiveX-Steuerelement hinzufügen**
ActiveX-Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für C++ ermöglicht Ihnen das Hinzufügen und Verwalten von ActiveX-Steuerelementen, jedoch ist deren Verwaltung etwas komplizierter und unterscheidet sich von normalen Präsentationsformen. Ab Aspose.Slides für C++ 18.1 wurde die Unterstützung zum Hinzufügen von Media Player ActiveX-Steuerelementen in Aspose.Slides hinzugefügt. Denken Sie daran, dass ActiveX-Steuerelemente keine Formen sind und nicht Teil der IShapeCollection der Präsentation, sondern Teil der separaten IControlExCollection sind. Dieser Artikel zeigt, wie Sie mit ihnen arbeiten. Um ein Media Player ActiveX-Steuerelement zu verwalten, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse Presentation und laden Sie die Beispieldpräsentation mit Media Player ActiveX-Steuerelementen.
1. Erstellen Sie eine Instanz der Ziel-Presentation-Klasse und generieren Sie eine leere Präsentationsinstanz.
1. Klonen Sie die Folie mit dem Media Player ActiveX-Steuerelement aus der Vorlage in die Ziel-Präsentation.
1. Greifen Sie auf die geklonte Folie in der Ziel-Präsentation zu.
1. Greifen Sie auf die ActiveX-Steuerelemente in der Folie zu, indem Sie die IControlCollection abrufen.
1. Greifen Sie auf das Media Player ActiveX-Steuerelement zu und setzen Sie den Videopfad über seine Eigenschaften.
1. Speichern Sie die Präsentation in einer PPTX-Datei.

``` cpp
// Instanziieren der Presentation-Klasse, die die PPTX-Datei darstellt
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Erstellen einer leeren Präsentationsinstanz
auto newPresentation = System::MakeObject<Presentation>();

// Entfernen der Standardfolie
newPresentation->get_Slides()->RemoveAt(0);

// Klonen der Folie mit dem Media Player ActiveX-Steuerelement
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Zugriff auf das Media Player ActiveX-Steuerelement und Festlegen des Videopfads
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Speichern der Präsentation
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```
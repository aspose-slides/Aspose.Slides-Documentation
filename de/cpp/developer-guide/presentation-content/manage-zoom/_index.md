---
title: Zoom verwalten
type: docs
weight: 60
url: /de/cpp/manage-zoom/
keywords: "Zoom, Zoomrahmen, Zoom hinzufügen, Zoomrahmen formatieren, Zusammenfassungszoom, PowerPoint-Präsentation, C++, Aspose.Slides für C++"
description: "Fügen Sie Zoom- oder Zoomrahmen zu PowerPoint-Präsentationen in C++ hinzu"
---

## **Übersicht**
Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Teilen einer Präsentation zu springen und zurück. Diese Fähigkeit, schnell durch Inhalte zu navigieren, kann während Ihrer Präsentation sehr nützlich sein.

![overview_image](Overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Zusammenfassungszoom](#Zusammenfassungszoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Folienzoom](#Folienzoom).
* Um nur einen einzigen Abschnitt anzuzeigen, verwenden Sie einen [Abschnittszoom](#Abschnittszoom).

## **Folienzoom**
Ein Folienzoom kann Ihre Präsentation dynamischer gestalten, da Sie frei zwischen Folien in beliebiger Reihenfolge navigieren können, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folienzooms sind ideal für kurze Präsentationen ohne viele Abschnitte, können jedoch auch in verschiedenen Präsentationsszenarien verwendet werden.

Folienzooms helfen Ihnen, in mehrere Informationsstücke einzutauchen, während Sie sich wie auf einer einzigen Leinwand fühlen.

![overview_image](slidezoomsel.png)

Für Folienzoom-Objekte bietet Aspose.Slides die [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2) Enumeration, die [IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame) Schnittstelle und einige Methoden unter der [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) Schnittstelle.

### **Zoomrahmen erstellen**

Sie können auf einer Folie einen Zoomrahmen folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erstellen Sie neue Folien, zu denen Sie die Zoomrahmen verlinken möchten.
3. Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4. Fügen Sie dem ersten Slide Zoomrahmen (die Verweise auf die erstellten Folien enthaltend) hinzu.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie einen Zoomrahmen auf einer Folie erstellen:

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt neue Folien zur Präsentation hinzu
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Erstellt einen Hintergrund für die zweite Folie
SetSlideBackground(slide2, Color::get_Cyan());

// Erstellt ein Textfeld für die zweite Folie
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Zweite Folie");

// Erstellt einen Hintergrund für die dritte Folie
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Erstellt ein Textfeld für die dritte Folie
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Dritte Folie");

//Fügt ZoomFrame-Objekte hinzu
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Zoomrahmen mit benutzerdefinierten Bildern erstellen**
Mit Aspose.Slides für C++ können Sie einen Zoomrahmen mit einem anderen Folienvorschau-Bild folgendermaßen erstellen:
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erstellen Sie eine neue Folie, zu der Sie den Zoomrahmen verlinken möchten.
3. Fügen Sie der Folie einen Identifikationstext und einen Hintergrund hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) Objekt, indem Sie ein Bild zur Bilderkollektion hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Objekt verbunden ist, das verwendet wird, um den Rahmen auszufüllen.
5. Fügen Sie Zoomrahmen (die den Verweis auf die erstellte Folie enthaltend) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie einen Zoomrahmen mit einem anderen Bild erstellen:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Erstellt einen Hintergrund für die zweite Folie
SetSlideBackground(slide, Color::get_Cyan());

// Erstellt ein Textfeld für die dritte Folie
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Zweite Folie");

// Erstellt ein neues Bild für das Zoomobjekt
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Fügt das ZoomFrame-Objekt hinzu
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Zoomrahmen formatieren**
In den vorherigen Abschnitten haben wir Ihnen gezeigt, wie Sie einfache Zoomrahmen erstellen. Um kompliziertere Zoomrahmen zu erstellen, müssen Sie die Formatierung eines einfachen Rahmens ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoomrahmen anwenden können.

Sie können die Formatierung eines Zoomrahmens auf einer Folie folgendermaßen steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erstellen Sie neue Folien, zu denen Sie die Zoomrahmen verlinken möchten.
3. Fügen Sie den erstellten Folien einige Identifikationstexte und Hintergründe hinzu.
4. Fügen Sie Zoomrahmen (die Referenzen zu den erstellten Folien enthaltend) zur ersten Folie hinzu.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) Objekt, indem Sie ein Bild zur Bilderkollektion hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Objekt verbunden ist, das verwendet wird, um den Rahmen auszufüllen.
6. Setzen Sie ein benutzerdefiniertes Bild für das erste Zoomrahmenobjekt.
7. Ändern Sie die Linienformatierung für das zweite Zoomrahmenobjekt.
8. Entfernen Sie den Hintergrund von einem Bild des zweiten Zoomrahmenobjekts.
5. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie die Formatierung eines Zoomrahmens auf einer Folie ändern:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Fügt neue Folien zur Präsentation hinzu
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Erstellt einen Hintergrund für die zweite Folie
SetSlideBackground(slide2, Color::get_Cyan());

// Erstellt ein Textfeld für die zweite Folie
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Zweite Folie");

// Erstellt einen Hintergrund für die dritte Folie
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Erstellt ein Textfeld für die dritte Folie
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Dritte Folie");

//Fügt ZoomFrame-Objekte hinzu
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Erstellt ein neues Bild für das Zoomobjekt
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Setzt das benutzerdefinierte Bild für das zoomFrame1-Objekt
zoomFrame1->set_Image(image);

// Setzt ein Zoomrahmenformat für das zoomFrame2-Objekt
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Einstellungen für Zeigen Sie den Hintergrund für das zoomFrame2-Objekt nicht an
zoomFrame2->set_ShowBackground(false);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Abschnittszoom**

Ein Abschnittszoom ist ein Link zu einem Abschnitt in Ihrer Präsentation. Sie können Abschnittszooms verwenden, um zu Abschnitten zurückzukehren, die Sie wirklich betonen möchten. Oder Sie können sie verwenden, um hervorzuheben, wie bestimmte Teile Ihrer Präsentation verbunden sind.

![overview_image](seczoomsel.png)

Für Abschnittszoom-Objekte bietet Aspose.Slides die [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) Schnittstelle und einige Methoden unter der [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) Schnittstelle.

### **Abschnittszoomrahmen erstellen**

Sie können einen Abschnittszoomrahmen zu einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie dem erstellten Slide einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoomrahmen verlinken möchten.
5. Fügen Sie einen Abschnittszoomrahmen (der Verweise auf den erstellten Abschnitt enthaltend) zur ersten Folie hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie einen Zoomrahmen auf einer Folie erstellen:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Abschnitt 1", slide);

// Fügt ein SectionZoomFrame-Objekt hinzu
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Abschnittszoomrahmen mit benutzerdefinierten Bildern erstellen**

Mit Aspose.Slides für C++ können Sie einen Abschnittszoomrahmen mit einem anderen Folienvorschau-Bild folgendermaßen erstellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie einem erstellten Slide einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoomrahmen verlinken möchten.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) Objekt, indem Sie ein Bild zur Bilderkollektion hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Objekt verbunden ist, das verwendet wird, um den Rahmen auszufüllen.
6. Fügen Sie einen Abschnittszoomrahmen (der einen Verweis auf den erstellten Abschnitt enthält) zur ersten Folie hinzu.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie einen Zoomrahmen mit einem anderen Bild erstellen:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Abschnitt 1", slide);

// Erstellt ein neues Bild für das Zoomobjekt
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Fügt das SectionZoomFrame-Objekt hinzu
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Abschnittszoomrahmen formatieren**

Um kompliziertere Abschnittszoomrahmen zu erstellen, müssen Sie die Formatierung eines einfachen Rahmens ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnittszoomrahmen anwenden können.

Sie können die Formatierung eines Abschnittszoomrahmens auf einer Folie folgendermaßen steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erstellen Sie eine neue Folie.
3. Fügen Sie einem erstellten Slide einen Identifikationshintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoomrahmen verlinken möchten.
5. Fügen Sie einen Abschnittszoomrahmen (der Verweise auf den erstellten Abschnitt enthaltend) zur ersten Folie hinzu.
6. Ändern Sie die Größe und Position des erstellten Abschnittszoomobjekts.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) Objekt, indem Sie ein Bild zur Bilderkollektion hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Objekt verbunden ist, das verwendet wird, um den Rahmen auszufüllen.
8. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoomrahmenobjekt.
9. Setzen Sie die Fähigkeit, zum ursprünglichen Slide aus dem verlinkten Abschnitt zurückzukehren.
10. Entfernen Sie den Hintergrund von einem Bild des Abschnittszoomrahmenobjekts.
11. Ändern Sie die Linienformatierung für das zweite Zoomrahmenobjekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie die Formatierung eines Abschnittszoomrahmens ändern:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Abschnitt 1", slide);

// Fügt das SectionZoomFrame-Objekt hinzu
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Formatierung für SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Zusammenfassungszoom**

Ein Zusammenfassungszoom ist wie eine Landing Page, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Wenn Sie präsentieren, können Sie den Zoom verwenden, um von einem Ort in Ihrer Präsentation an einen anderen in beliebiger Reihenfolge zu springen. Sie können kreativ werden, vorankommen oder Teile Ihrer Diashow besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Zusammenfassungszoom-Objekte bietet Aspose.Slides die [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) Schnittstellen und einige Methoden unter der [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) Schnittstelle.

### **Zusammenfassungszoom erstellen**

Sie können einen Zusammenfassungszoomrahmen zu einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neue Abschnitte für die erstellten Folien.
3. Fügen Sie den Zusammenfassungszoomrahmen zur ersten Folie hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie einen Zusammenfassungszoomrahmen auf einer Folie erstellen:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Abschnitt 1", slide);

// Fügt eine neue Folie zur Präsentation hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Abschnitt 2", slide);

// Fügt eine neue Folie zur Präsentation hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Abschnitt 3", slide);

// Fügt eine neue Folie zur Präsentation hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Abschnitt 4", slide);

// Fügt ein SummaryZoomFrame-Objekt hinzu
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Zusammenfassungszoom-Abschnitt hinzufügen und entfernen**

Alle Abschnitte in einem Zusammenfassungszoomrahmen sind durch [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section) Objekte dargestellt, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) Objekt gespeichert sind. Sie können ein Zusammenfassungszoomabschnittsobjekt über die [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) Schnittstelle folgendermaßen hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neue Abschnitte für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungszoomrahmen zur ersten Folie hinzu.
4. Fügen Sie eine neue Folie und einen neuen Abschnitt zur Präsentation hinzu.
5. Fügen Sie den erstellten Abschnitt zum Zusammenfassungszoomrahmen hinzu.
6. Entfernen Sie den ersten Abschnitt aus dem Zusammenfassungszoomrahmen.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie Abschnitte in einem Zusammenfassungszoomrahmen hinzufügen und entfernen:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Abschnitt 1", slide);

//Fügt eine neue Folie zur Präsentation hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Abschnitt 2", slide);

// Fügt ein SummaryZoomFrame-Objekt hinzu
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Fügt eine neue Folie zur Präsentation hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
auto section3 = pres->get_Sections()->AddSection(u"Abschnitt 3", slide);

// Fügt einen Abschnitt zum Zusammenfassungszoom hinzu
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Entfernt den Abschnitt aus dem Zusammenfassungszoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Zusammenfassungszoom-Abschnitte formatieren**

Um kompliziertere Zusammenfassungszoomabschnittsobjekte zu erstellen, müssen Sie die Formatierung eines einfachen Rahmens ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Zusammenfassungszoomabschnittsobjekt anwenden können.

Sie können die Formatierung für ein Zusammenfassungszoomabschnittsobjekt in einem Zusammenfassungszoomrahmen folgendermaßen steuern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erstellen Sie neue Folien mit Identifikationshintergrund und neue Abschnitte für die erstellten Folien.
3. Fügen Sie einen Zusammenfassungszoomrahmen zur ersten Folie hinzu.
4. Holen Sie sich ein Zusammenfassungszoomabschnittsobjekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) Objekt, indem Sie ein Bild zur Bilderkollektion hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Objekt verbunden ist, das verwendet wird, um den Rahmen auszufüllen.
6. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoomrahmenobjekt.
7. Setzen Sie die Fähigkeit, zum ursprünglichen Slide aus dem verlinkten Abschnitt zurückzukehren.
8. Ändern Sie die Linienformatierung für das zweite Zoomrahmenobjekt.
9. Ändern Sie die Übergangsdauer.
10. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie die Formatierung für ein Zusammenfassungszoomabschnittsobjekt ändern:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Abschnitt 1", slide);

//Fügt eine neue Folie zur Präsentation hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Abschnitt 2", slide);

// Fügt ein SummaryZoomFrame-Objekt hinzu
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Holt sich das erste SummaryZoomSection-Objekt
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Formatierung für SummaryZoomSection-Objekt
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
---
title: Verwalten von Präsentations-Zoom in C++
linktitle: Zoom verwalten
type: docs
weight: 60
url: /de/cpp/manage-zoom/
keywords:
- Zoom
- Zoom-Frame
- Folienzoom
- Abschnittszoom
- Übersichtszoom
- Zoom hinzufügen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen und anpassen von Zoom mit Aspose.Slides für C++ — zwischen Abschnitten springen, Miniaturansichten und Übergänge in PPT-, PPTX- und ODP‑Präsentationen hinzufügen."
---

## **Übersicht**
Zooms in PowerPoint ermöglichen das Springen zu und von bestimmten Folien, Abschnitten und Teilen einer Präsentation. Beim Vortragen kann diese Fähigkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein. 

![overview_image](Overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Summary Zoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Slide Zoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Section Zoom](#Section-Zoom).

## **Folienzoom**
Ein Folienzoom kann Ihre Präsentation dynamischer machen, indem er Ihnen ermöglicht, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folienzooms sind ideal für kurze Präsentationen ohne viele Abschnitte, können jedoch auch in verschiedenen Präsentationsszenarien eingesetzt werden.

Folienzooms helfen Ihnen, in mehrere Informationsstücke zu vertiefen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden. 

![overview_image](slidezoomsel.png)

Für Folien‑Zoom‑Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac0802a52a7f14a457b62e9761a77e8e2) , das Interface [IZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_zoom_frame) und einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) bereit.

### **Zoom‑Frames erstellen**

Sie können in folgender Weise einen Zoom‑Frame zu einer Folie hinzufügen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken möchten. 
3.	Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4.	Fügen Sie dem ersten Bild Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) hinzu.
5.	Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

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

//Adds new slides to the presentation
// Adds a background for the second slide
// Creates a text box for the second slide
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Creates a background for the third slide
// Create a text box for the third slide
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adds ZoomFrame objects
// Saves the presentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Zoom‑Frames mit benutzerdefinierten Bildern erstellen**
Mit Aspose.Slides für C++ können Sie in folgender Weise einen Zoom‑Frame mit einem anderen Folienvorschau‑Bild erstellen: 
1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Erstellen Sie eine neue Folie, zu der Sie den Zoom‑Frame verlinken möchten. 
3.	Fügen Sie der Folie einen Identifikationstext und einen Hintergrund hinzu.
4.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)‑Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
5.	Fügen Sie dem ersten Bild Zoom‑Frames (die den Verweis auf die erstellte Folie enthalten) hinzu.
6.	Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Erstellt einen Hintergrund für die zweite Folie
SetSlideBackground(slide, Color::get_Cyan());

// Erstellt ein Textfeld für die dritte Folie
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Erstellt ein neues Bild für das Zoom-Objekt
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Fügt das ZoomFrame-Objekt hinzu
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Zoom‑Frames formatieren**
Im vorherigen Abschnitt haben wir gezeigt, wie man einfache Zoom‑Frames erstellt. Um komplexere Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Zoom‑Frames auf einer Folie wie folgt steuern:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken möchten. 
3.	Fügen Sie den erstellten Folien etwas Identifikationstext und einen Hintergrund hinzu.
4.	Fügen Sie dem ersten Bild Zoom‑Frames (die Verweise auf die erstellten Folien enthalten) hinzu.
5.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)‑Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
6.	Setzen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt.
7.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
8.	Entfernen Sie den Hintergrund von einem Bild des zweiten Zoom‑Frame‑Objekts.
5.	Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
// Fügt neue Folien zur Präsentation hinzu
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Erstellt einen Hintergrund für die zweite Folie
SetSlideBackground(slide2, Color::get_Cyan());

// Erstellt ein Textfeld für die zweite Folie
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Erstellt einen Hintergrund für die dritte Folie
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Erstellt ein Textfeld für die dritte Folie
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

// Fügt ZoomFrame-Objekte hinzu
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Erstellt ein neues Bild für das Zoom-Objekt
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Setzt ein benutzerdefiniertes Bild für das zoomFrame1-Objekt
zoomFrame1->set_Image(image);

// Setzt ein Zoom-Frame-Format für das zoomFrame2-Objekt
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Einstellung: Hintergrund für zoomFrame2-Objekt nicht anzeigen
zoomFrame2->set_ShowBackground(false);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Abschnitts‑Zoom**

Ein Abschnitts‑Zoom ist ein Link zu einem Abschnitt Ihrer Präsentation. Sie können Abschnitts‑Zooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders betonen möchten. Oder Sie können sie nutzen, um hervorzuheben, wie bestimmte Teile Ihrer Präsentation zusammenhängen. 

![overview_image](seczoomsel.png)

Für Abschnitts‑Zoom‑Objekte stellt Aspose.Slides das Interface [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_section_zoom_frame) sowie einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) bereit.

### **Abschnitt‑Zoom‑Frames erstellen**

Sie können in folgender Weise einen Abschnitt‑Zoom‑Frame zu einer Folie hinzufügen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Erstellen Sie eine neue Folie. 
3.	Fügen Sie der erstellten Folie einen Identifikations‑Hintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.	Fügen Sie dem ersten Bild einen Abschnitt‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) hinzu.
6.	Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Section 1", slide);

// Fügt ein SectionZoomFrame-Objekt hinzu
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Abschnitts‑Zoom‑Frames mit benutzerdefinierten Bildern erstellen**

Durch die Verwendung von Aspose.Slides für C++ können Sie in folgender Weise einen Abschnitts‑Zoom‑Frame mit einem anderen Folienvorschau‑Bild erstellen: 

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Erstellen Sie eine neue Folie.
3.	Fügen Sie der erstellten Folie einen Identifikations‑Hintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)‑Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
5.	Fügen Sie dem ersten Bild einen Abschnitt‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) hinzu.
6.	Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Section 1", slide);

// Erstellt ein neues Bild für das Zoom-Objekt
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Fügt ein SectionZoomFrame-Objekt hinzu
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Abschnitt‑Zoom‑Frames formatieren**

Um komplexere Abschnitt‑Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnitt‑Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Abschnitt‑Zoom‑Frames auf einer Folie wie folgt steuern:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Erstellen Sie eine neue Folie.
3.	Fügen Sie der erstellten Folie einen Identifikations‑Hintergrund hinzu.
4.	Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5.	Fügen Sie dem ersten Bild einen Abschnitt‑Zoom‑Frame (der Verweise auf den erstellten Abschnitt enthält) hinzu.
6.	Ändern Sie die Größe und Position des erstellten Abschnitt‑Zoom‑Objekts.
7.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)‑Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
8.	Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitt‑Zoom‑Frame‑Objekt.
9.	Aktivieren Sie die *Rückkehr zur ursprünglichen Folie aus dem verlinkten Abschnitt*‑Funktion. 
10.	Entfernen Sie den Hintergrund von einem Bild des Abschnitt‑Zoom‑Frame‑Objekts.
11.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12.	Ändern Sie die Übergangsdauer.
13.	Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Section 1", slide);

// Fügt ein SectionZoomFrame-Objekt hinzu
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



## **Übersichts‑Zoom**

Ein Übersichts‑Zoom ist wie eine Landing‑Page, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Beim Vortragen können Sie den Zoom verwenden, um von einer Stelle Ihrer Präsentation zu einer anderen in beliebiger Reihenfolge zu springen. Sie können kreativ sein, vorausspringen oder einzelne Teile Ihrer Präsentation erneut aufrufen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Übersichts‑Zoom‑Objekte stellt Aspose.Slides die Interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_frame), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) sowie einige Methoden im Interface [IShapeCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) bereit.

### **Übersichts‑Zoom erstellen**

Sie können in folgender Weise einen Übersichts‑Zoom‑Frame zu einer Folie hinzufügen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie den Übersichts‑Zoom‑Frame dem ersten Bild hinzu.
4.	Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Section 1", slide);

// Fügt eine neue Folie zur Präsentation hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Section 2", slide);

// Fügt eine neue Folie zur Präsentation hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Section 3", slide);

// Fügt eine neue Folie zur Präsentation hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Section 4", slide);

// Fügt ein SummaryZoomFrame-Objekt hinzu
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Übersichts‑Zoom‑Abschnitt hinzufügen und entfernen**

Alle Abschnitte in einem Übersichts‑Zoom‑Frame werden durch [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section)‑Objekte repräsentiert, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection)‑Objekt gespeichert sind. Sie können über das Interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_summary_zoom_section_collection) einen Übersichts‑Zoom‑Abschnitt hinzufügen oder entfernen:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie einen Übersichts‑Zoom‑Frame in das erste Bild ein.
4.	Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5.	Fügen Sie den erstellten Abschnitt dem Übersichts‑Zoom‑Frame hinzu.
6.	Entfernen Sie den ersten Abschnitt aus dem Übersichts‑Zoom‑Frame.
7.	Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Section 1", slide);

//Fügt eine neue Folie zur Präsentation hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Section 2", slide);

// Fügt SummaryZoomFrame-Objekt hinzu
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Fügt eine neue Folie zur Präsentation hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Fügt einen Abschnitt zum Summary Zoom hinzu
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Entfernt Abschnitt aus dem Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Übersichts‑Zoom‑Abschnitte formatieren**

Um komplexere Übersichts‑Zoom‑Abschnitt‑Objekte zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Übersichts‑Zoom‑Abschnitt‑Objekt anwenden können. 

Sie können die Formatierung eines Übersichts‑Zoom‑Abschnitt‑Objekts in einem Übersichts‑Zoom‑Frame wie folgt steuern:

1.	Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2.	Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3.	Fügen Sie einen Übersichts‑Zoom‑Frame dem ersten Bild hinzu.
4.	Holen Sie ein Übersichts‑Zoom‑Abschnitt‑Objekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
7.	Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image)‑Objekt, indem Sie ein Bild zur Images‑Sammlung des [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Objekts hinzufügen, das zum Füllen des Frames verwendet wird.
8.	Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitt‑Zoom‑Frame‑Objekt.
9.	Aktivieren Sie die *Rückkehr zur ursprünglichen Folie aus dem verlinkten Abschnitt*‑Funktion. 
11.	Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12.	Ändern Sie die Übergangsdauer.
13.	Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt eine neue Folie zur Präsentation hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Section 1", slide);

//Fügt eine neue Folie zur Präsentation hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Fügt einen neuen Abschnitt zur Präsentation hinzu
pres->get_Sections()->AddSection(u"Section 2", slide);

// Fügt ein SummaryZoomFrame-Objekt hinzu
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Holt das erste SummaryZoomSection-Objekt
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Formatierung für das SummaryZoomSection-Objekt
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


## **FAQ**

**Kann ich die Rückkehr zur 'übergeordneten' Folie nach dem Anzeigen des Ziels steuern?**

Ja. Der [Zoom‑frame](https://reference.aspose.com/slides/cpp/aspose.slides/zoomframe/) oder das [section](https://reference.aspose.com/slides/cpp/aspose.slides/sectionzoomframe/) verfügt über die Methode `set_ReturnToParent`, die die Betrachter nach dem Besuch des Zielinhalts zurück zur Ausgangsfolie führt.

**Kann ich die 'Geschwindigkeit' oder Dauer der Zoom‑Übergangs anpassen?**

Ja. Zoom unterstützt das Festlegen einer Übergangsdauer, sodass Sie steuern können, wie lange die Sprunganimation dauert.

**Gibt es Grenzen, wie viele Zoom‑Objekte eine Präsentation enthalten kann?**

Es gibt kein fest definiertes API‑Limit. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistungsfähigkeit des Betrachters ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.
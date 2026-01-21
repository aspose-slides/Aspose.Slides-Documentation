---
title: Zoom für Präsentationen in C++ verwalten
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
description: "Zoom mit Aspose.Slides für C++ erstellen und anpassen — zwischen Abschnitten springen, Thumbnails und Übergänge in PPT-, PPTX- und ODP-Präsentationen hinzufügen."
---

## **Übersicht**
Zooms in PowerPoint ermöglichen es Ihnen, zu bestimmten Folien, Abschnitten und Teilen einer Präsentation zu springen und zurückzukehren. Beim Vortragen kann diese Fähigkeit, schnell durch Inhalte zu navigieren, sehr nützlich sein. 

![overview_image](Overview.png)

* Um eine gesamte Präsentation auf einer einzigen Folie zusammenzufassen, verwenden Sie einen [Summary Zoom](#Summary-Zoom).
* Um nur ausgewählte Folien anzuzeigen, verwenden Sie einen [Slide Zoom](#Slide-Zoom).
* Um nur einen einzelnen Abschnitt anzuzeigen, verwenden Sie einen [Section Zoom](#Section-Zoom).

## **Folienzoom**
Ein Folienzoom kann Ihre Präsentation dynamischer machen, indem er Ihnen erlaubt, frei zwischen Folien in beliebiger Reihenfolge zu navigieren, ohne den Fluss Ihrer Präsentation zu unterbrechen. Folienzooms eignen sich gut für kurze Präsentationen ohne viele Abschnitte, können aber auch in verschiedenen Präsentationsszenarien eingesetzt werden.

Folienzooms helfen Ihnen, in mehrere Informationsstücke einzutauchen, während Sie das Gefühl haben, sich auf einer einzigen Leinwand zu befinden. 

![overview_image](slidezoomsel.png)

Für Folienzoom‑Objekte stellt Aspose.Slides die Aufzählung [ZoomImageType](https://reference.aspose.com/slides/cpp/aspose.slides/zoomimagetype/)‑Enumeration, das Interface [IZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/izoomframe/) und einige Methoden unter dem Interface [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) bereit.

### **Zoom‑Frames erstellen**

Sie können einen Zoom‑Frame auf einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Erstellen Sie neue Folien, zu denen Sie die Zoom‑Frames verlinken möchten. 
3. Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4. Fügen Sie der ersten Folie Zoom‑Frames (die Referenzen zu den erstellten Folien enthalten) hinzu.
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

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
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Erstellt einen Hintergrund für die dritte Folie
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Erstellt ein Textfeld für die dritte Folie
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Fügt ZoomFrame-Objekte hinzu
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Zoom‑Frames mit benutzerdefinierten Bildern erstellen**
Mit Aspose.Slides for C++ können Sie einen Zoom‑Frame mit einem anderen Folienvorschau‑Bild folgendermaßen erstellen: 
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Erstellen Sie eine neue Folie, zu der Sie den Zoom‑Frame verlinken möchten. 
3. Fügen Sie der Folie einen Identifikationstext und einen Hintergrund hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)‑Objekt, indem Sie ein Bild zur Images‑Collection hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Objekt verknüpft ist und zum Füllen des Rahmens verwendet wird.
5. Fügen Sie der ersten Folie Zoom‑Frames (die Referenz zur erstellten Folie enthalten) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt der Präsentation eine neue Folie hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

//Erstellt einen Hintergrund für die zweite Folie
SetSlideBackground(slide, Color::get_Cyan());

//Erstellt ein Textfeld für die dritte Folie
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Erstellt ein neues Bild für das Zoom-Objekt
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Fügt das ZoomFrame-Objekt hinzu
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

//Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Zoom‑Frames formatieren**
In den vorigen Abschnitten haben wir Ihnen gezeigt, wie Sie einfache Zoom‑Frames erstellen. Um komplexere Zoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Zoom‑Frame anwenden können. 

Sie können die Formatierung eines Zoom‑Frames auf einer Folie folgendermaßen steuern:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Erstellen Sie neue Folien, zu denen Sie den Zoom‑Frame verlinken möchten. 
3. Fügen Sie den erstellten Folien einen Identifikationstext und einen Hintergrund hinzu.
4. Fügen Sie der ersten Folie Zoom‑Frames (die Referenzen zu den erstellten Folien enthalten) hinzu.
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)‑Objekt, indem Sie ein Bild zur Images‑Collection hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Objekt verknüpft ist und zum Füllen des Rahmens verwendet wird.
6. Setzen Sie ein benutzerdefiniertes Bild für das erste Zoom‑Frame‑Objekt.
7. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
8. Entfernen Sie den Hintergrund von einem Bild des zweiten Zoom‑Frame‑Objekts.
5. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Fügt neue Folien zur Präsentation hinzu
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

//Erstellt einen Hintergrund für die zweite Folie
SetSlideBackground(slide2, Color::get_Cyan());

//Erstellt ein Textfeld für die zweite Folie
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Erstellt einen Hintergrund für die dritte Folie
SetSlideBackground(slide3, Color::get_DarkKhaki());

//Erstellt ein Textfeld für die dritte Folie
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Fügt ZoomFrame-Objekte hinzu
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

//Erstellt ein neues Bild für das Zoom-Objekt
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
//Setzt ein benutzerdefiniertes Bild für das zoomFrame1-Objekt
zoomFrame1->set_Image(image);

//Setzt ein Zoom-Frame-Format für das zoomFrame2-Objekt
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

//Einstellung zum Ausblenden des Hintergrunds für das zoomFrame2-Objekt
zoomFrame2->set_ShowBackground(false);

//Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Abschnittszoom**

Ein Abschnittszoom ist ein Link zu einem Abschnitt Ihrer Präsentation. Sie können Abschnittszooms verwenden, um zu Abschnitten zurückzukehren, die Sie besonders hervorheben wollen. Oder Sie können sie nutzen, um zu zeigen, wie bestimmte Teile Ihrer Präsentation zusammenhängen. 

![overview_image](seczoomsel.png)

Für Abschnittszoom‑Objekte stellt Aspose.Slides das Interface [ISectionZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isectionzoomframe/) und einige Methoden unter dem Interface [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) bereit.

### **Abschnittszoom‑Frames erstellen**

Sie können einen Abschnittszoom‑Frame zu einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Erstellen Sie eine neue Folie. 
3. Fügen Sie der erstellten Folie einen Identifikations‑Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Fügen Sie der ersten Folie einen Abschnittszoom‑Frame (der Referenzen zum erstellten Abschnitt enthält) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt der Präsentation eine neue Folie hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Fügt der Präsentation einen neuen Abschnitt hinzu
pres->get_Sections()->AddSection(u"Section 1", slide);

// Fügt ein SectionZoomFrame-Objekt hinzu
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Abschnittszoom‑Frames mit benutzerdefinierten Bildern erstellen**

Mit Aspose.Slides for C++ können Sie einen Abschnittszoom‑Frame mit einem anderen Folienvorschau‑Bild folgendermaßen erstellen: 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikations‑Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)‑Objekt, indem Sie ein Bild zur Images‑Collection hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Objekt verknüpft ist und zum Füllen des Rahmens verwendet wird.
5. Fügen Sie der ersten Folie einen Abschnittszoom‑Frame (der eine Referenz zum erstellten Abschnitt enthält) hinzu.
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt der Präsentation eine neue Folie hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Fügt der Präsentation einen neuen Abschnitt hinzu
pres->get_Sections()->AddSection(u"Section 1", slide);

// Erstellt ein neues Bild für das Zoom-Objekt
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Fügt ein SectionZoomFrame-Objekt hinzu
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Abschnittszoom‑Frames formatieren**

Um komplexere Abschnittszoom‑Frames zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf einen Abschnittszoom‑Frame anwenden können. 

Sie können die Formatierung eines Abschnittszoom‑Frames auf einer Folie folgendermaßen steuern:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Erstellen Sie eine neue Folie.
3. Fügen Sie der erstellten Folie einen Identifikations‑Hintergrund hinzu.
4. Erstellen Sie einen neuen Abschnitt, zu dem Sie den Zoom‑Frame verlinken möchten. 
5. Fügen Sie der ersten Folie einen Abschnittszoom‑Frame (der Referenzen zum erstellten Abschnitt enthält) hinzu.
6. Ändern Sie Größe und Position für das erstellte Abschnittszoom‑Objekt.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)‑Objekt, indem Sie ein Bild zur Images‑Collection hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Objekt verknüpft ist und zum Füllen des Rahmens verwendet wird.
8. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnittszoom‑Frame‑Objekt.
9. Aktivieren Sie die *Rückkehr zur Originalfolie aus dem verlinkten Abschnitt*‑Funktion. 
10. Entfernen Sie den Hintergrund von einem Bild des Abschnittszoom‑Frame‑Objekts.
11. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt der Präsentation eine neue Folie hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

//Fügt der Präsentation einen neuen Abschnitt hinzu
pres->get_Sections()->AddSection(u"Section 1", slide);

//Fügt ein SectionZoomFrame-Objekt hinzu
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

//Formatierung für SectionZoomFrame
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

//Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```



## **Übersichtszoom**

Ein Übersichtszoom ist wie eine Landing‑Page, auf der alle Teile Ihrer Präsentation gleichzeitig angezeigt werden. Beim Vortragen können Sie den Zoom nutzen, um von einem beliebigen Ort Ihrer Präsentation zu einem anderen zu springen, in beliebiger Reihenfolge. Sie können kreativ sein, Vorsprünge machen oder Teile Ihrer Diashow erneut besuchen, ohne den Fluss Ihrer Präsentation zu unterbrechen.

![overview_image](sumzoomsel.png)

Für Übersichtszoom‑Objekte stellt Aspose.Slides die Interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/) und [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/) sowie einige Methoden unter dem Interface [IShapeCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/) bereit.

### **Übersichtszoom erstellen**

Sie können einen Übersichtszoom‑Frame zu einer Folie folgendermaßen hinzufügen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie dem ersten Slide den Übersichtszoom‑Frame hinzu.
4. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Fügt der Präsentation eine neue Folie hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Fügt der Präsentation einen neuen Abschnitt hinzu
pres->get_Sections()->AddSection(u"Section 1", slide);

// Fügt der Präsentation eine neue Folie hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Fügt der Präsentation einen neuen Abschnitt hinzu
pres->get_Sections()->AddSection(u"Section 2", slide);

// Fügt der Präsentation eine neue Folie hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Fügt der Präsentation einen neuen Abschnitt hinzu
pres->get_Sections()->AddSection(u"Section 3", slide);

// Fügt der Präsentation eine neue Folie hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Fügt der Präsentation einen neuen Abschnitt hinzu
pres->get_Sections()->AddSection(u"Section 4", slide);

// Fügt ein SummaryZoomFrame-Objekt hinzu
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Übersichtszoom‑Abschnitt hinzufügen und entfernen**

Alle Abschnitte in einem Übersichtszoom‑Frame werden durch [ISummaryZoomSection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsection/)-Objekte repräsentiert, die im [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/)-Objekt gespeichert werden. Sie können einen Übersichtszoom‑Abschnitt über das Interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isummaryzoomsectioncollection/) folgendermaßen hinzufügen oder entfernen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie dem ersten Slide einen Übersichtszoom‑Frame hinzu.
4. Fügen Sie der Präsentation eine neue Folie und einen neuen Abschnitt hinzu.
5. Fügen Sie den erstellten Abschnitt dem Übersichtszoom‑Frame hinzu.
6. Entfernen Sie den ersten Abschnitt aus dem Übersichtszoom‑Frame.
7. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt der Präsentation eine neue Folie hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Fügt der Präsentation einen neuen Abschnitt hinzu
pres->get_Sections()->AddSection(u"Section 1", slide);

//Fügt der Präsentation eine neue Folie hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Fügt der Präsentation einen neuen Abschnitt hinzu
pres->get_Sections()->AddSection(u"Section 2", slide);

// Fügt SummaryZoomFrame-Objekt hinzu
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Fügt der Präsentation eine neue Folie hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Fügt der Präsentation einen neuen Abschnitt hinzu
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Fügt einen Abschnitt zum Summary Zoom hinzu
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Entfernt Abschnitt aus dem Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Speichert die Präsentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


### **Übersichtszoom‑Abschnitte formatieren**

Um komplexere Übersichtszoom‑Abschnitts‑Objekte zu erstellen, müssen Sie die Formatierung eines einfachen Frames ändern. Es gibt mehrere Formatierungsoptionen, die Sie auf ein Übersichtszoom‑Abschnitts‑Objekt anwenden können. 

Sie können die Formatierung eines Übersichtszoom‑Abschnitts‑Objekts in einem Übersichtszoom‑Frame folgendermaßen steuern:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Erstellen Sie neue Folien mit Identifikations‑Hintergrund und neuen Abschnitten für die erstellten Folien.
3. Fügen Sie dem ersten Slide einen Übersichtszoom‑Frame hinzu.
4. Holen Sie ein Übersichtszoom‑Abschnitts‑Objekt für das erste Objekt aus der `ISummaryZoomSectionCollection`.
7. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)‑Objekt, indem Sie ein Bild zur Images‑Collection hinzufügen, die mit dem [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Objekt verknüpft ist und zum Füllen des Rahmens verwendet wird.
8. Setzen Sie ein benutzerdefiniertes Bild für das erstellte Abschnitts‑Zoom‑Frame‑Objekt.
9. Aktivieren Sie die *Rückkehr zur Originalfolie aus dem verlinkten Abschnitt*‑Funktion. 
11. Ändern Sie das Linienformat für das zweite Zoom‑Frame‑Objekt.
12. Ändern Sie die Übergangsdauer.
13. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Fügt der Präsentation eine neue Folie hinzu
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Fügt der Präsentation einen neuen Abschnitt hinzu
pres->get_Sections()->AddSection(u"Section 1", slide);

//Fügt der Präsentation eine neue Folie hinzu
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Fügt der Präsentation einen neuen Abschnitt hinzu
pres->get_Sections()->AddSection(u"Section 2", slide);

// Fügt ein SummaryZoomFrame-Objekt hinzu
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Erhält das erste SummaryZoomSection-Objekt
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

**Kann ich die Rückkehr zur 'Eltern'-Folie nach dem Anzeigen des Ziels steuern?**

Ja. Der [Zoom frame](https://reference.aspose.com/slides/cpp/aspose.slides/zoomframe/) oder [section](https://reference.aspose.com/slides/cpp/aspose.slides/sectionzoomframe/) hat eine `set_ReturnToParent`‑Methode, die den Betrachter nach dem Besuch des Zielinhalts zur Ausgangsfolie zurücksendet.

**Kann ich die 'Geschwindigkeit' oder Dauer des Zoom‑Übergangs anpassen?**

Ja. Zoom unterstützt das Festlegen einer Übergangsdauer, sodass Sie steuern können, wie lange die Sprunganimation dauert.

**Gibt es Grenzen für die Anzahl der Zoom‑Objekte, die eine Präsentation enthalten kann?**

Es gibt kein festes API‑Limit, das dokumentiert ist. Praktische Grenzen hängen von der Gesamtkomplexität der Präsentation und der Leistung des Viewers ab. Sie können viele Zoom‑Frames hinzufügen, sollten jedoch Dateigröße und Renderzeit berücksichtigen.
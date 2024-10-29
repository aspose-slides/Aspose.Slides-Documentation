---
title: Folienmaster
type: docs
weight: 80
url: /de/cpp/slide-master/
keywords: "Folienmaster hinzufügen, PPT Folienmaster, Folienmaster PowerPoint, Bild zu Folienmaster, Platzhalter, Mehrere Folienmaster, Folienmaster vergleichen, C++, CPP, Aspose.Slides für C++"
description: "Fügen Sie einen Folienmaster in einer PowerPoint-Präsentation in C++ hinzu oder bearbeiten Sie ihn."
---

## **Was ist ein Folienmaster in PowerPoint**

Ein **Folienmaster** ist eine Folienvorlage, die das Layout, die Stile, das Thema, die Schriftarten, den Hintergrund und andere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) mit demselben Stil und derselben Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Folienmaster verwenden. 

Ein Folienmaster ist nützlich, da er es ermöglicht, das Aussehen aller Präsentationsfolien gleichzeitig zu ändern. Aspose.Slides unterstützt den Folienmaster-Mechanismus von PowerPoint. 

VBA ermöglicht es ebenfalls, einen Folienmaster zu manipulieren und die selben in PowerPoint unterstützten Operationen auszuführen: Hintergründe ändern, Formen hinzufügen, das Layout anpassen, usw. Aspose.Slides bietet flexible Mechanismen, um Folienmaster zu verwenden und grundlegende Aufgaben mit ihnen durchzuführen. 

Dies sind grundlegende Folienmaster-Operationen:

- Erstellen oder Ändern eines Folienmasters.
- Anwenden von Folienmaster auf Präsentationsfolien.
- Ändern des Folienmaster-Hintergrunds. 
- Hinzufügen eines Bildes, Platzhalters, SmartArt usw. zum Folienmaster.

Dies sind fortgeschrittenere Operationen mit Folienmaster: 

- Vergleichen von Folienmastern.
- Zusammenführen von Folienmastern.
- Anwenden mehrerer Folienmaster.
- Kopieren einer Folie mit Folienmaster in eine andere Präsentation.
- Finden von doppelten Folienmastern in Präsentationen.
- Setzen des Folienmasters als Standardansicht der Präsentation.

{{% alert color="primary" %}} 

Es könnte sich lohnen, den Aspose [**Online PowerPoint-Viewer**](https://products.aspose.app/slides/viewer) auszuprobieren, da es eine Live-Implementierung einiger der hier beschriebenen Kernprozesse ist.

{{% /alert %}} 

## **Wie wird der Folienmaster angewendet**

Bevor Sie mit einem Folienmaster arbeiten, sollten Sie verstehen, wie er in Präsentationen verwendet und auf Folien angewendet wird. 

* Jede Präsentation hat standardmäßig mindestens einen Folienmaster. 
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und verwenden, um verschiedene Teile einer Präsentation auf unterschiedliche Weise zu gestalten. 

In **Aspose.Slides** wird ein Folienmaster durch den [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) Typ dargestellt. 

Das [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation
) Objekt von Aspose.Slides enthält die [**get_Masters()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) Liste des [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) Typs, die eine Liste aller Masterfolien enthält, die in einer Präsentation definiert sind. 

Neben CRUD-Operationen enthält das [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) Interface diese nützlichen Methoden: [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) und [**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311) Methoden. Diese Methoden sind von der grundlegenden Folienklonfunktion abgeleitet. Wenn man jedoch mit Folienmastern arbeitet, ermöglichen diese Methoden die Implementierung komplizierter Setups. 

Wenn eine neue Folie zu einer Präsentation hinzugefügt wird, wird automatisch ein Folienmaster auf sie angewendet. Der Folienmaster der vorherigen Folie wird standardmäßig ausgewählt. 

**Hinweis**: Präsentationsfolien werden in der [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) Liste gespeichert und jede neue Folie wird standardmäßig am Ende der Sammlung hinzugefügt. Wenn eine Präsentation nur einen Folienmaster enthält, wird dieser Folienmaster für alle neuen Folien ausgewählt. Aus diesem Grund müssen Sie den Folienmaster nicht für jede neue Folie definieren, die Sie erstellen.

Das Prinzip ist dasselbe für PowerPoint und Aspose.Slides. In PowerPoint können Sie beispielsweise, wenn Sie eine neue Präsentation hinzufügen, einfach auf die untere Linie unter der letzten Folie klicken, und dann wird eine neue Folie (mit dem Folienmaster der letzten Präsentation) erstellt:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie die gleiche Aufgabe mit der [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) Methode der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse ausführen.

## **Folienmaster in der Folienhierarchie**

Die Verwendung von Folienlayouts mit Folienmastern ermöglicht maximale Flexibilität. Ein Folienlayout erlaubt es Ihnen, alle gleichen Stile wie der Folienmaster (Hintergrund, Schriftarten, Formen usw.) festzulegen. Wenn jedoch mehrere Folienlayouts auf einem Folienmaster kombiniert werden, wird ein neuer Stil erstellt. Wenn Sie ein Folienlayout auf eine einzelne Folie anwenden, können Sie ihren Stil von dem, der vom Folienmaster angewendet wurde, ändern.

Der Folienmaster hat Vorrang vor allen Setups: Folienmaster -> Folienlayout -> Folie:

![todo:image_alt_text](slide-master_2)

Jedes [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) Objekt hat eine [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) Eigenschaft mit einer Liste von Folienlayouts. Ein [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) Typ hat eine [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8) Eigenschaft mit einem Verweis auf ein Folienlayout, das auf die Folie angewendet wurde. Die Interaktion zwischen einer Folie und dem Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Hinweis" %}}

* In Aspose.Slides sind alle Folieneinrichtungen (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Foliensobjekte, die das [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) Interface implementieren.
* Daher können Folienmaster und Folienlayouts dieselben Eigenschaften implementieren, und Sie müssen wissen, wie deren Werte auf ein [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) Objekt angewendet werden. Der Folienmaster wird zuerst auf eine Folie angewendet und dann das Folienlayout. Wenn der Folienmaster und das Folienlayout beide einen Hintergrundwert haben, erhält die Folie den Hintergrund des Folienlayouts.

{{% /alert %}}

## **Was ein Folienmaster umfasst**

Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die Kern Eigenschaften des [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/). 

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) - Hintergrund der Folie abrufen/setzen.
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) - Textstile des Folienkörpers abrufen/setzen.
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) - Alle Formen des Folienmasters abrufen/setzen (Platzhalter, Bilderrahmen usw.).
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) - ActiveX-Steuerelemente abrufen/setzen.
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) - Themen-Manager abrufen.
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) - Kopf- und Fußzeilen-Manager abrufen.

Methoden des Folienmasters:

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) - Alle Folien abrufen, die vom Folienmaster abhängen.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) - Ermöglicht die Erstellung eines neuen Folienmasters basierend auf dem aktuellen Folienmaster und einem neuen Thema. Der neue Folienmaster wird dann auf alle abhängigen Folien angewendet.

## **Folienmaster abrufen**

In PowerPoint kann der Folienmaster über das Menü Ansicht -> Folienmaster aufgerufen werden:

![todo:image_alt_text](slide-master_3.jpg)

Mit Aspose.Slides können Sie auf einen Folienmaster auf folgende Weise zugreifen:

```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```

Das [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) Interface repräsentiert einen Folienmaster. Die [get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) Eigenschaft (die sich auf den [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) Typ bezieht) enthält eine Liste aller Folienmaster, die in der Präsentation definiert sind.

## **Bild zum Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf allen Folien, die von diesem Folienmaster abhängen. 

Zum Beispiel können Sie das Logo Ihres Unternehmens und einige Bilder auf dem Folienmaster platzieren und dann zum Folienbearbeitungsmodus zurückkehren. Sie sollten das Bild auf jeder Folie sehen. 

![todo:image_alt_text](slide-master_4.png)

Sie können Bilder mit Aspose.Slides zu einem Folienmaster hinzufügen:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" title="Siehe auch" %}} 

Für weitere Informationen zum Hinzufügen von Bildern zu einer Folie, siehe den Artikel [Bilderrahmen](/slides/de/cpp/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Platzhalter zum Folienmaster hinzufügen**

Diese Textfelder sind standardmäßige Platzhalter auf einem Folienmaster: 

* Klicken Sie hier, um den Titelstil des Masters zu bearbeiten

* Bearbeiten Sie die Textstile des Masters

* Zweite Ebene

* Dritte Ebene 

  Sie erscheinen auch auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf einem Folienmaster bearbeiten, und die Änderungen werden automatisch auf die Folien angewendet. 

In PowerPoint können Sie einen Platzhalter über den Pfad Folienmaster -> Platzhalter einfügen hinzufügen:

![todo:image_alt_text](slide-master_5.png)

Lassen Sie uns ein komplizierteres Beispiel für Platzhalter mit Aspose.Slides betrachten. Betrachten Sie eine Folie mit Platzhaltern, die vom Folienmaster abgeleitet sind:

![todo:image_alt_text](slide-master_6.png)

Wir möchten die Formatierung von Titel und Untertitel auf dem Folienmaster folgendermaßen ändern:

![todo:image_alt_text](slide-master_7.png)

Zuerst rufen wir den Inhalt des Titelplatzhalters vom Folienmaster-Objekt ab und verwenden dann das `PlaceHolder.FillFormat` Feld: 

```c++
System::SharedPtr<IAutoShape> FindPlaceholder(System::SharedPtr<IMasterSlide> master, PlaceholderType type)
{
    for (auto& shape : master->get_Shapes())
    {
        System::SharedPtr<IAutoShape> autoShape = System::AsCast<Aspose::Slides::IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            if (autoShape->get_Placeholder()->get_Type() == type)
            {
                return autoShape;
            }
        }
    }
    return nullptr;
}

void Main()
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
    System::SharedPtr<IAutoShape> placeHolder = FindPlaceholder(master, Aspose::Slides::PlaceholderType::Title);
    auto fillFormat = placeHolder->get_FillFormat();
    fillFormat->set_FillType(Aspose::Slides::FillType::Gradient);
    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(Aspose::Slides::GradientShape::Linear);
    gradientFormat->get_GradientStops()->Add(0.0f, System::Drawing::Color::FromArgb(255, 0, 0));
    gradientFormat->get_GradientStops()->Add(255.0f, System::Drawing::Color::FromArgb(128, 0, 128));
    
    pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
}
```

Der Titelstil und die Formatierung ändern sich für alle Folien, die auf dem Folienmaster basieren:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Siehe auch" %}} 

* [Prompttext im Platzhalter festlegen](https://docs.aspose.com/slides/cpp/manage-placeholder/)
* [Textformatierung](https://docs.aspose.com/slides/cpp/text-formatting/)

{{% /alert %}}

## **Hintergrund im Folienmaster ändern**

Wenn Sie die Hintergrundfarbe eines Folienmasters ändern, erhalten alle normalen Folien in der Präsentation die neue Farbe. Dieser C++-Code demonstriert die Operation:

```c++
auto pres = System::MakeObject<Presentation>();

auto master = pres->get_Masters()->idx_get(0);
auto background = master->get_Background();
background->set_Type(Aspose::Slides::BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
background->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
    
pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="primary" title="Siehe auch" %}} 

- [Hintergrund der Präsentation](https://docs.aspose.com/slides/cpp/presentation-background/)

- [Thema der Präsentation](https://docs.aspose.com/slides/cpp/presentation-theme/)

{{% /alert %}}

## **Folienmaster in eine andere Präsentation klonen**

Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) Methode der Zielpräsentation zusammen mit einem in sie übergebenen Folienmaster auf. Dieser C++-Code zeigt, wie man einen Folienmaster in eine andere Präsentation klont:

```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```

## **Mehrere Folienmaster zur Präsentation hinzufügen**

Aspose.Slides ermöglicht es Ihnen, mehrere Folienmaster und Folienlayouts zu einer beliebigen Präsentation hinzuzufügen. Dies ermöglicht es Ihnen, Stil, Layouts und Formatierungsoptionen für Präsentationsfolien auf viele Arten einzurichten. 

In PowerPoint können Sie neue Folienmaster und Layouts (aus dem "Folienmaster-Menü) wie folgt hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides können Sie einen neuen Folienmaster hinzufügen, indem Sie die [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) Methode aufrufen:

```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```

## **Folienmaster vergleichen**

Ein Folienmaster implementiert das [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) Interface, das die [**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f) Methode enthält, die verwendet werden kann, um Folien zu vergleichen. Sie gibt `true` für Folienmaster zurück, die in Struktur und statischem Inhalt identisch sind. 

Zwei Folienmaster sind gleich, wenn ihre Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt keine eindeutigen Identifikatorwerte (z.B. SlideId) und dynamischen Inhalt (z.B. den aktuellen Datumwert im Datumsplatzhalter). 

## **Folienmaster als Standardansicht der Präsentation festlegen**

Aspose.Slides ermöglicht es Ihnen, einen Folienmaster als Standardansicht für eine Präsentation festzulegen. Die Standardansicht ist diejenige, die angezeigt wird, wenn Sie eine Präsentation öffnen. 

Dieser Code zeigt, wie Sie einen Folienmaster als Standardansicht einer Präsentation in C++ festlegen:

```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```

## **Nicht verwendeten Folienmaster entfernen**

Aspose.Slides bietet die [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) Methode (aus der [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) Klasse), um Ihnen zu ermöglichen, unerwünschte und ungenutzte Folienmaster zu löschen. Dieser C++-Code zeigt, wie Sie einen Folienmaster aus einer PowerPoint-Präsentation entfernen:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```
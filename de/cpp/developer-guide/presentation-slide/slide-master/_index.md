---
title: Verwalten von Präsentations-Folienmastern in C++
linktitle: Folienmaster
type: docs
weight: 80
url: /de/cpp/slide-master/
keywords:
- Folienmaster
- Masterfolie
- PPT-Masterfolie
- mehrere Masterfolien
- Masterfolien vergleichen
- Hintergrund
- Platzhalter
- Masterfolie klonen
- Masterfolie kopieren
- Masterfolie duplizieren
- unbenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten von Folienmastern in Aspose.Slides für C++: Erstellen, Bearbeiten und Anwenden von Layouts, Designs und Platzhaltern für PPT, PPTX und ODP mit prägnanten C++-Beispielen."
---

## **Was ist ein Folienmaster in PowerPoint**

Ein **Folienmaster** ist eine Folienvorlage, die das Layout, die Stile, das Design, die Schriftarten, den Hintergrund und weitere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) mit dem gleichen Stil und der gleichen Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Folienmaster verwenden.

Ein Folienmaster ist nützlich, weil er es Ihnen ermöglicht, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern. Aspose.Slides unterstützt den Folienmaster‑Mechanismus von PowerPoint.

VBA ermöglicht ebenfalls die Manipulation eines Folienmasters und die Ausführung derselben Operationen, die in PowerPoint unterstützt werden: Hintergründe ändern, Formen hinzufügen, Layout anpassen usw. Aspose.Slides stellt flexible Mechanismen bereit, mit denen Sie Folienmaster verwenden und grundlegende Aufgaben damit durchführen können.

Dies sind grundlegende Folienmaster‑Operationen:

- Erstellen oder **Slide Master**.
- Folienmaster auf Präsentationsfolien anwenden.
- Hintergrund des Folienmasters ändern. 
- Ein Bild, Platzhalter, SmartArt usw. zum Folienmaster hinzufügen.

Dies sind weiterführende Operationen mit Folienmastern:

- Folienmaster vergleichen.
- Folienmaster zusammenführen.
- Mehrere Folienmaster anwenden.
- Folie mit Folienmaster in eine andere Präsentation kopieren.
- Doppelte Folienmaster in Präsentationen finden.
- Folienmaster als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Vielleicht möchten Sie Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) ausprobieren, da er eine Live‑Implementierung einiger hier beschriebener Kernprozesse darstellt.

{{% /alert %}} 

## **Wie wird ein Folienmaster angewendet**

Bevor Sie mit einem Folienmaster arbeiten, sollten Sie verstehen, wie er in Präsentationen verwendet und auf Folien angewendet wird. 

* Jede Präsentation hat standardmäßig mindestens einen Folienmaster. 
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation unterschiedlich zu gestalten. 

In **Aspose.Slides** wird ein Folienmaster durch den Typ [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) repräsentiert. 

Das Aspose.Slides‑[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Objekt enthält die [**get_Masters()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29)‑Liste vom Typ [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection), die eine Liste aller in einer Präsentation definierten Folienmaster enthält. 

Neben CRUD‑Operationen enthält die Schnittstelle [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) nützliche Methoden: [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) und [**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311). Diese Methoden stammen aus der Grundfunktion zum Klonen von Folien. Beim Umgang mit Folienmastern ermöglichen sie jedoch komplexe Setups. 

Wenn einer neuen Folie einer Präsentation hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet. Standardmäßig wird der Folienmaster der vorherigen Folie übernommen. 

**Hinweis**: Präsentationsfolien werden in der [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)‑Liste gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung eingefügt. Enthält eine Präsentation einen einzigen Folienmaster, wird dieser für alle neuen Folien verwendet. Deshalb müssen Sie den Folienmaster nicht für jede neu erstellte Folie erneut festlegen.

Das Prinzip ist für PowerPoint und Aspose.Slides identisch. In PowerPoint können Sie zum Beispiel einfach am unteren Rand unter der letzten Folie klicken, um eine neue Folie (mit dem Folienmaster der letzten Folie) zu erzeugen:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie die gleiche Aufgabe mit der Methode [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ausführen.

## **Folienmaster in der Folienhierarchie**

Die Verwendung von Folienlayouts zusammen mit dem Folienmaster bietet maximale Flexibilität. Ein Folienlayout erlaubt es Ihnen, dieselben Stile wie beim Folienmaster (Hintergrund, Schriftarten, Formen usw.) festzulegen. Wenn mehrere Folienlayouts auf einem Folienmaster kombiniert werden, entsteht ein neuer Stil. Wird ein Folienlayout auf eine einzelne Folie angewendet, kann deren Stil vom Folienmaster‑Stil abweichen.

Der Folienmaster steht über allen anderen Setup‑Elementen: Folienmaster → Folienlayout → Folie:

![todo:image_alt_text](slide-master_2)

Jedes [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide)-Objekt besitzt die Eigenschaft [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) mit einer Liste von Folienlayouts. Ein [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide)-Typ hat die Eigenschaft [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8), die auf das angewendete Folienlayout verweist. Die Interaktion zwischen einer Folie und dem Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Note" %}}

* In Aspose.Slides sind alle Folien‑Setups (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die das Interface [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) implementieren.
* Daher können Folienmaster und Folienlayout dieselben Eigenschaften besitzen, und Sie müssen wissen, wie deren Werte auf ein [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide)-Objekt angewendet werden. Der Folienmaster wird zuerst auf die Folie angewendet, anschließend das Folienlayout. Haben sowohl Folienmaster als auch Folienlayout zum Beispiel einen Hintergrundwert, überschreibt der Hintergrund des Folienlayouts den des Folienmasters.

{{% /alert %}}

## **Woraus ein Folienmaster besteht**

Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die Kerneigenschaften von [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/):

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) – Hintergrund der Folie holen/setzen.
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) – Textstile des Folienkörpers holen/setzen.
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) – Alle Formen des Folienmasters (Platzhalter, Bildrahmen usw.) holen/setzen.
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) – ActiveX‑Steuerelemente holen/setzen.
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) – Theme‑Manager holen.
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) – Header‑ und Footer‑Manager holen.

Methoden des Folienmasters:

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) – Alle Folien holen, die vom Folienmaster abhängen.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) – Ermöglicht das Erstellen eines neuen Folienmasters basierend auf dem aktuellen Folienmaster und einem neuen Theme. Der neue Folienmaster wird anschließend auf alle abhängigen Folien angewendet.

## **Einen Folienmaster erhalten**

In PowerPoint kann der Folienmaster über das Menü **Ansicht → Folienmaster** aufgerufen werden:

![todo:image_alt_text](slide-master_3.jpg)

Mit Aspose.Slides greifen Sie so auf einen Folienmaster zu:
```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```


Die Schnittstelle [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) repräsentiert einen Folienmaster. Die Eigenschaft [get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) (bezogen auf den Typ [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)) enthält eine Liste aller in der Präsentation definierten Folienmaster.

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf allen Folien, die von diesem Master abhängen.

Beispielsweise können Sie das Firmenlogo und weitere Bilder auf dem Folienmaster platzieren und anschließend zum Folienbearbeitungsmodus zurückkehren – das Bild wird auf jeder Folie sichtbar sein.

![todo:image_alt_text](slide-master_4.png)

Bilder können Sie mit Aspose.Slides zu einem Folienmaster hinzufügen:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


{{% alert color="primary" title="See also" %}} 

Weitere Informationen zum Hinzufügen von Bildern zu einer Folie finden Sie im Artikel [Picture Frame](/slides/de/cpp/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Einen Platzhalter zu einem Folienmaster hinzufügen**

Diese Textfelder sind Standardplatzhalter auf einem Folienmaster:

* Klick zum Bearbeiten des Master‑Titelstils
* Master‑Textstile bearbeiten
* Zweite Ebene
* Dritte Ebene

Sie erscheinen ebenfalls auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf dem Folienmaster bearbeiten und die Änderungen werden automatisch auf die Folien übertragen.

In PowerPoint können Sie einen Platzhalter über den Pfad **Folienmaster → Platzhalter einfügen** hinzufügen:

![todo:image_alt_text](slide-master_5.png)

Betrachten wir ein komplexeres Beispiel für Platzhalter mit Aspose.Slides. Angenommen, wir haben eine Folie mit Platzhaltern, die aus dem Folienmaster stammen:

![todo:image_alt_text](slide-master_6.png)

Wir wollen die Formatierung von Titel und Untertitel auf dem Folienmaster wie folgt ändern:

![todo:image_alt_text](slide-master_7.png)

Zuerst holen wir den Inhalt des Titel‑Platzhalters aus dem Folienmaster‑Objekt und verwenden dann das Feld `PlaceHolder.FillFormat`:
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

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/cpp/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/cpp/text-formatting/)

{{% /alert %}}

## **Den Hintergrund eines Folienmasters ändern**

Wenn Sie die Hintergrundfarbe einer Master‑Folien ändern, erhalten alle normalen Folien in der Präsentation die neue Farbe. Dieser C++‑Code demonstriert die Operation:
```c++
auto pres = System::MakeObject<Presentation>();

auto master = pres->get_Masters()->idx_get(0);
auto background = master->get_Background();
background->set_Type(Aspose::Slides::BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
background->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
    
pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert color="primary" title="See also" %}} 

- [Presentation Background](https://docs.aspose.com/slides/cpp/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/cpp/presentation-theme/)

{{% /alert %}}

## **Einen Folienmaster in eine andere Präsentation klonen**

Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die Methode [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) der Zielpräsentation auf und übergeben den zu klonenden Folienmaster. Dieser C++‑Code zeigt, wie Sie einen Folienmaster in eine andere Präsentation klonen:
```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```


## **Mehrere Folienmaster zu einer Präsentation hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen mehrerer Folienmaster und Folienlayouts zu einer beliebigen Präsentation. Dadurch können Sie Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf verschiedene Weise festlegen.

In PowerPoint können Sie neue Folienmaster und Layouts (aus dem **Folienmaster‑Menü**) wie folgt hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides fügen Sie einen neuen Folienmaster hinzu, indem Sie die Methode [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) aufrufen:
```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```


## **Folienmaster vergleichen**

Ein Master‑Slide implementiert das Interface [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) mit der Methode [**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f), die zum Vergleich von Folien verwendet werden kann. Sie liefert `true` für Master‑Slides, die in Struktur und statischem Inhalt identisch sind.

Zwei Master‑Slides sind gleich, wenn ihre Formen, Stile, Texte, Animationen und weitere Einstellungen übereinstimmen. Der Vergleich berücksichtigt nicht eindeutige Kennungen (z. B. SlideId) und dynamische Inhalte (z. B. aktuelles Datum in einem Datums‑Platzhalter).

## **Einen Folienmaster als Standardansicht der Präsentation festlegen**

Aspose.Slides ermöglicht es, einen Folienmaster als Standardansicht einer Präsentation festzulegen. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie eine Präsentation öffnen.

Dieser Code zeigt, wie Sie in C++ einen Folienmaster als Standardansicht einer Präsentation festlegen:
```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```


## **Unbenutzte Master‑Slides entfernen**

Aspose.Slides stellt die Methode [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) der Klasse [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) zur Verfügung, um nicht benötigte und ungenutzte Master‑Slides zu löschen. Dieser C++‑Code zeigt, wie Sie einen Master‑Slide aus einer PowerPoint‑Präsentation entfernen:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Was ist ein Folienmaster in PowerPoint?**

Ein Folienmaster ist eine Folienvorlage, die Layout, Stile, Designs, Schriftarten, Hintergrund und weitere Eigenschaften für Folien in einer Präsentation definiert. Er ermöglicht das einheitliche Festlegen und Ändern des Aussehens aller Präsentationsfolien.

**Wie wird ein Folienmaster in einer Präsentation angewendet?**

Jede Präsentation enthält standardmäßig mindestens einen Folienmaster. Wenn eine neue Folie hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet, typischerweise der Master der vorherigen Folie. Eine Präsentation kann mehrere Folienmaster enthalten, um unterschiedliche Teile individuell zu gestalten.

**Welche Elemente können in einem Folienmaster angepasst werden?**

Ein Folienmaster besteht aus mehreren Kerneigenschaften, die angepasst werden können:

- **Background**: Folienhintergrund festlegen.
- **BodyStyle**: Textstile des Folienkörpers definieren.
- **Shapes**: Alle Formen auf dem Folienmaster verwalten, einschließlich Platzhalter und Bildrahmen.
- **Controls**: ActiveX‑Steuerelemente bearbeiten.
- **ThemeManager**: Zugriff auf den Theme‑Manager.
- **HeaderFooterManager**: Header‑ und Footer‑Verwaltung.

**Wie füge ich ein Bild zu einem Folienmaster hinzu?**

Durch das Hinzufügen eines Bildes zu einem Folienmaster wird es auf allen Folien angezeigt, die von diesem Master abhängen. Beispielsweise wird ein Firmenlogo, das auf dem Folienmaster platziert wird, auf jeder Folie der Präsentation angezeigt.

**Wie stehen Folienmaster und Folienlayouts zueinander?**

Folienlayouts arbeiten zusammen mit dem Folienmaster, um Flexibilität beim Foliendesign zu bieten. Während der Folienmaster übergeordnete Stile und Designs definiert, ermöglichen Folienlayouts Variationen in der Anordnung von Inhalten. Die Hierarchie lautet:

- **Folienmaster** → definiert globale Stile.
- **Folienlayout** → bietet unterschiedliche Inhaltsanordnungen.
- **Folie** → erbt das Design vom zugewiesenen Folienlayout.

**Kann ich mehrere Folienmaster in einer einzigen Präsentation haben?**

Ja, eine Präsentation kann mehrere Folienmaster enthalten. Das ermöglicht das unterschiedliche Gestalten verschiedener Abschnitte einer Präsentation und bietet damit Design‑Flexibilität.

**Wie greife ich mit Aspose.Slides auf einen Folienmaster zu und ändere ihn?**

In Aspose.Slides wird ein Folienmaster durch das Interface [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/) repräsentiert. Sie können auf einen Folienmaster über die Methode [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) des Objekts [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) zugreifen.
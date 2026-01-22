---
title: Verwaltung von Folienmastern auf Android
linktitle: Folienmaster
type: docs
weight: 70
url: /de/androidjava/slide-master/
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
- ungenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für Android: Erstellen, Bearbeiten und Anwenden von Layouts, Themes und Platzhaltern auf PPT, PPTX und ODP mit prägnanten Java-Beispielen."
---

## **Was ist ein Slide Master in PowerPoint**

Ein **Slide Master** ist eine Folienvorlage, die Layout, Stile, Thema, Schriften, Hintergrund und weitere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) mit demselben Stil und derselben Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Slide Master verwenden.  

Ein Slide Master ist nützlich, weil er Ihnen ermöglicht, das Aussehen aller Folien einer Präsentation gleichzeitig festzulegen und zu ändern. Aspose.Slides unterstützt den Slide‑Master‑Mechanismus von PowerPoint.  

VBA ermöglicht ebenfalls die Manipulation eines Slide Masters und die Ausführung derselben Operationen, die in PowerPoint unterstützt werden: Hintergründe ändern, Formen hinzufügen, Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, um Slide Masters zu nutzen und grundlegende Aufgaben damit auszuführen.  

Dies sind grundlegende Slide‑Master‑Operationen:

- Erstellen oder **Slide Master**.
- **Slide Master** auf Präsentationsfolien anwenden.
- Hintergrund des **Slide Master** ändern. 
- Ein Bild, Platzhalter, SmartArt usw. zum **Slide Master** hinzufügen.

Dies sind weiterführende Operationen mit Slide Master:

- Slide Masters vergleichen.
- Slide Masters zusammenführen.
- Mehrere Slide Masters anwenden.
- Folie mit Slide Master in eine andere Präsentation kopieren.
- Doppelte Slide Masters in Präsentationen finden.
- Slide Master als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Vielleicht möchten Sie Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) ausprobieren, da er eine Live‑Implementierung einiger hier beschriebener Kernvorgänge darstellt.

{{% /alert %}} 


## **Wie ein Slide Master angewendet wird**

Bevor Sie mit einem Slide Master arbeiten, sollten Sie verstehen, wie er in Präsentationen verwendet und auf Folien angewendet wird. 

* Jede Präsentation besitzt standardmäßig mindestens einen Slide Master. 
* Eine Präsentation kann mehrere Slide Masters enthalten. Sie können mehrere Slide Masters hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation unterschiedlich zu gestalten. 

In **Aspose.Slides** wird ein Slide Master durch den Typ [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) repräsentiert.

Das Aspose.Slides‑[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Objekt enthält die [**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--)‑Liste des Typs [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), die eine Liste aller in einer Präsentation definierten Master‑Folien enthält.

Neben CRUD‑Operationen liefert die [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/)‑Schnittstelle nützliche Methoden: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) und [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Diese Methoden werden von der Grundfunktion zum Klonen von Folien geerbt, ermöglichen jedoch bei Slide Masters komplexere Setups.

Wird einer Präsentation eine neue Folie hinzugefügt, wird automatisch ein Slide Master darauf angewendet. Standardmäßig wird der Slide Master der vorherigen Folie übernommen. 

**Hinweis**: Präsentationsfolien werden in der [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--)‑Liste gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung eingefügt. Enthält eine Präsentation nur einen Slide Master, wird dieser Master für alle neuen Folien verwendet. Deshalb müssen Sie den Slide Master nicht für jede neu erstellte Folie explizit festlegen.

Das Prinzip ist für PowerPoint und Aspose.Slides identisch. In PowerPoint können Sie beim Hinzufügen einer neuen Folie einfach auf die untere Zeile unterhalb der letzten Folie klicken; es wird dann eine neue Folie (mit dem Slide Master der vorherigen Folie) erstellt:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie denselben Vorgang mit der [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)‑Methode der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse ausführen.


## **Slide Master in der Slides‑Hierarchie**

Die Kombination von Slide Layouts mit einem Slide Master bietet maximale Flexibilität. Ein Slide Layout ermöglicht es Ihnen, dieselben Stile wie beim Slide Master (Hintergrund, Schriften, Formen usw.) festzulegen. Wenn mehrere Slide Layouts auf einem Slide Master kombiniert werden, entsteht ein neuer Stil. Wird ein Slide Layout einer einzelnen Folie zugewiesen, kann dessen Stil den vom Slide Master vorgegebenen Stil überschreiben.

Slide Master hat Vorrang vor allen anderen Einstellungen: Slide Master → Slide Layout → Folie:

![todo:image_alt_text](slide-master_2)



Jedes [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide)-Objekt besitzt die [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--)‑Eigenschaft mit einer Liste von Slide Layouts. Ein [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide)-Typ hat die [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--)‑Eigenschaft, die auf das dem Slide zugewiesene Layout verweist. Die Interaktion zwischen einer Folie und dem Slide Master erfolgt über ein Slide Layout.

{{% alert color="info" title="Hinweis" %}}

* In Aspose.Slides sind alle Folieneinstellungen (Slide Master, Slide Layout und die Folie selbst) tatsächlich Folienobjekte, die das [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide)‑Interface implementieren.
* Daher können Slide Master und Slide Layout dieselben Eigenschaften besitzen; Sie sollten wissen, wie deren Werte auf ein [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide)-Objekt angewendet werden. Zuerst wird der Slide Master auf die Folie angewendet, anschließend das Slide Layout. Hat beispielsweise sowohl der Slide Master als auch das Slide Layout einen Hintergrundwert, so endet die Folie mit dem Hintergrund des Slide Layouts.

{{% /alert %}}


## **Inhalt eines Slide Masters**

Um zu verstehen, wie ein Slide Master geändert werden kann, müssen Sie dessen Bestandteile kennen. Dazu gehören die Kern‑Properties des [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) – Liest/legt den Folienhintergrund fest.
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) – Liest/legt Textstile des Folienkörpers fest.
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) – Liest/legt alle Formen des Slide Masters (Platzhalter, Bildrahmen usw.) fest.
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) – Liest/legt ActiveX‑Steuerelemente fest.
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) – Liest den Theme‑Manager.
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) – Liest das Header‑ und Footer‑Management.

Methoden des Slide Masters:

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) – Ermittelt alle Folien, die vom Slide Master abhängen.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) – Erstellt einen neuen Slide Master auf Basis des aktuellen Masters und eines neuen Themes; der neue Master wird anschließend auf alle abhängigen Folien angewendet.


## **Einen Slide Master abrufen**

In PowerPoint kann man den Slide Master über das Menü **Ansicht → Folienmaster** öffnen:

![todo:image_alt_text](slide-master_3.jpg)



Mit Aspose.Slides greifen Sie auf einen Slide Master folgendermaßen zu: 
```java
Presentation pres = new Presentation();
try {
    // Gibt Zugriff auf die Master‑Folien der Präsentation
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


Das [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide)-Interface repräsentiert einen Slide Master. Die [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--)‑Eigenschaft (bezogen auf den Typ [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)) enthält eine Liste aller in der Präsentation definierten Slide Masters.


## **Ein Bild zu einem Slide Master hinzufügen**

Wird ein Bild zu einem Slide Master hinzugefügt, erscheint es auf allen Folien, die von diesem Master abhängen. 

Beispielsweise können Sie das Firmenlogo und weitere Bilder auf dem Slide Master platzieren und anschließend in den Bearbeitungsmodus zurückkehren – das Bild wird auf jeder Folie sichtbar sein. 

![todo:image_alt_text](slide-master_4.png)

Sie können Bilder zu einem Slide Master mit Aspose.Slides hinzufügen:
```java
Presentation pres = new Presentation();
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="Siehe auch" %}} 

Weitere Informationen zum Hinzufügen von Bildern zu einer Folie finden Sie im Artikel [Picture Frame](/slides/de/androidjava/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Einen Platzhalter zu einem Slide Master hinzufügen**

Diese Textfelder sind Standard‑Platzhalter auf einem Slide Master: 

* Klick zum Bearbeiten des Master‑Titelstils
* Master‑Textstile bearbeiten
* Zweite Ebene
* Dritte Ebene 

Sie erscheinen auch auf Folien, die auf dem Slide Master basieren. Änderungen an diesen Platzhaltern auf dem Slide Master werden automatisch auf die Folien übernommen. 

In PowerPoint können Sie einen Platzhalter über den Pfad **Slide Master → Platzhalter einfügen** hinzufügen:



![todo:image_alt_text](slide-master_5.png)



Ein komplexeres Beispiel für Platzhalter mit Aspose.Slides sehen Sie hier: Eine Folie mit vom Slide Master vorgefertigten Platzhaltern:



![todo:image_alt_text](slide-master_6.png)



Wir wollen die Formatierung von Titel und Untertitel auf dem Slide Master wie folgt ändern:

![todo:image_alt_text](slide-master_7.png)



Zunächst holen wir den Inhalt des Titel‑Platzhalters vom Slide Master‑Objekt und verwenden das Feld `PlaceHolder.FillFormat`:
```java
public static void main(String[] args) {
    Presentation pres = new Presentation();
    try {
        IMasterSlide master = pres.getMasters().get_Item(0);
        IAutoShape placeHolder = findPlaceholder(master, PlaceholderType.Title);
        placeHolder.getFillFormat().setFillType(FillType.Gradient);
        placeHolder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, new Color(255, 0, 0));
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, new Color(128, 0, 128));

        pres.save("pres.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
}

static IAutoShape findPlaceholder(IMasterSlide master, int type)
{
    for (IShape shape : master.getShapes())
    {
        IAutoShape autoShape = (IAutoShape) shape;
        if (autoShape != null)
        {
            if (autoShape.getPlaceholder().getType() == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```


Der Titel‑Stil und die Formatierung ändern sich für alle Folien, die auf dem Slide Master basieren:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Siehe auch" %}} 

* [Prompt‑Text in Platzhaltern festlegen](https://docs.aspose.com/slides/androidjava/manage-placeholder/)
* [Textformatierung](https://docs.aspose.com/slides/androidjava/text-formatting/)

{{% /alert %}}


## **Den Hintergrund eines Slide Masters ändern**

Ändern Sie die Hintergrundfarbe eines Master‑Slides, erhalten alle normalen Folien in der Präsentation die neue Farbe. Der folgende Java‑Code demonstriert die Operation:
```java
Presentation pres = new Presentation();
try {
    IMasterSlide master = pres.getMasters().get_Item(0);
    master.getBackground().setType(BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(FillType.Solid);
    master.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="Siehe auch" %}} 

- [Presentation Background](https://docs.aspose.com/slides/androidjava/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/androidjava/presentation-theme/)

{{% /alert %}}

## **Einen Slide Master in eine andere Präsentation klonen**

Um einen Slide Master in eine andere Präsentation zu klonen, rufen Sie die [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)‑Methode der Zielpräsentation auf und übergeben den zu klonenden Slide Master. Der folgende Java‑Code zeigt, wie ein Slide Master geklont wird:
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```



## **Mehrere Slide Masters zu einer Präsentation hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen mehrerer Slide Masters und Slide Layouts zu einer beliebigen Präsentation. Dadurch können Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf vielfältige Weise festgelegt werden. 

In PowerPoint können Sie neue Slide Masters und Layouts (über das **Slide‑Master‑Menü**) wie folgt hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides fügen Sie einen neuen Slide Master hinzu, indem Sie die [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)‑Methode verwenden:
```java
// Fügt eine neue Masterfolie hinzu
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Slide Masters vergleichen**

Ein Master‑Slide implementiert das [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide)‑Interface mit der [**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-)‑Methode, die zum Vergleich von Folien verwendet werden kann. Sie liefert `true`, wenn Master‑Slides in Struktur und statischem Inhalt identisch sind.

Zwei Master‑Slides sind gleich, wenn ihre Formen, Stile, Texte, Animationen und weitere Einstellungen exakt übereinstimmen. Der Vergleich berücksichtigt keine eindeutigen Kennungen (z. B. SlideId) und keinen dynamischen Inhalt (z. B. aktuelles Datum in einem Datums‑Platzhalter).


## **Slide Master als Standardansicht einer Präsentation festlegen**

Aspose.Slides ermöglicht das Festlegen eines Slide Masters als Standardansicht einer Präsentation. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie eine Präsentation öffnen. 

Der folgende Code zeigt, wie Sie in Java einen Slide Master als Standardansicht festlegen:
```java
// Instanziiert eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation presentation = new Presentation();
try {
    // Setzt die Standardansicht auf SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // Speichert die Präsentation
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```



## **Ungenutzte Master‑Slides entfernen**

Aspose.Slides stellt die Methode [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) der [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)‑Klasse bereit, um unerwünschte und ungenutzte Master‑Slides zu löschen. Der folgende Java‑Code demonstriert das Entfernen eines Master‑Slides aus einer PowerPoint‑Präsentation:
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```



## **FAQ**

**Was ist ein Slide Master in PowerPoint?**

Ein Slide Master ist eine Folienvorlage, die Layout, Stile, Themen, Schriften, Hintergrund und weitere Eigenschaften für Folien einer Präsentation definiert. Sie können damit das Aussehen aller Folien gleichzeitig festlegen und ändern.  

**Wie wird ein Slide Master in einer Präsentation angewendet?**

Jede Präsentation enthält standardmäßig mindestens einen Slide Master. Beim Hinzufügen einer neuen Folie wird automatisch ein Slide Master darauf angewendet, meist der Master der vorherigen Folie. Eine Präsentation kann mehrere Slide Masters enthalten, um verschiedene Teile individuell zu gestalten.  

**Welche Elemente können in einem Slide Master angepasst werden?**

Ein Slide Master besteht aus mehreren Kern‑Properties, die angepasst werden können:

- **Background**: Folienhintergrund festlegen.
- **BodyStyle**: Textstile des Folienkörpers definieren.
- **Shapes**: Alle Formen auf dem Slide Master verwalten, inkl. Platzhalter und Bildrahmen.
- **Controls**: ActiveX‑Steuerelemente verwalten.
- **ThemeManager**: Zugriff auf den Theme‑Manager.
- **HeaderFooterManager**: Header‑ und Footer‑Verwaltung.  

**Wie füge ich ein Bild zu einem Slide Master hinzu?**

Ein Bild, das Sie zu einem Slide Master hinzufügen, erscheint auf allen Folien, die von diesem Master abhängen. Beispiel: Das Firmenlogo auf dem Slide Master wird auf jeder Folie der Präsentation angezeigt.  

**Wie stehen Slide Masters zu Slide Layouts?**

Slide Layouts arbeiten zusammen mit Slide Masters, um Flexibilität im Foliendesign zu bieten. Während ein Slide Master globale Stile und Themen definiert, ermöglichen Slide Layouts Variationen in der Anordnung des Inhalts. Die Hierarchie lautet:

- **Slide Master** → Definiert globale Stile.
- **Slide Layout** → Bietet unterschiedliche Inhaltsanordnungen.
- **Slide** → Erbt das Design vom zugewiesenen Slide Layout.

**Kann ich mehrere Slide Masters in einer einzelnen Präsentation haben?**

Ja, eine Präsentation kann mehrere Slide Masters enthalten. Dadurch lassen sich verschiedene Abschnitte einer Präsentation unterschiedlich gestalten, was mehr Design‑Flexibilität bietet.  

**Wie greife ich mit Aspose.Slides auf einen Slide Master zu und ändere ihn?**

In Aspose.Slides wird ein Slide Master durch das [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/)‑Interface repräsentiert. Sie können einen Slide Master über die [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--)‑Methode des [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Objekts abrufen.